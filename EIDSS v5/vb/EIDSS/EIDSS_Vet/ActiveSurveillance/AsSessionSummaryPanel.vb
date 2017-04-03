﻿Imports eidss.Core
Imports bv.winclient.BasePanel
Imports bv.model.Model.Core
Imports DevExpress.XtraEditors
Imports bv.winclient.Core
Imports System.ComponentModel
Imports System.Collections.Generic
Imports DevExpress.XtraGrid.Columns
Imports eidss.model.Resources

Namespace ActiveSurveillance
    Public Class AsSessionSummaryPanel
        Private AsSessionSummaryService As AsSummary_DB
        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            AsSessionSummaryService = New AsSummary_DB
            DbService = AsSessionSummaryService
            btnPasteDiagnosis.Enabled = False
            btnPasteSamples.Enabled = False
        End Sub
        Protected Overrides Sub DefineBinding()
            AsSummaryGrid.DataSource = baseDataSet.Tables(AsSummary_DB.TableAsSummary)
            LookupBinder.BindBaseRepositoryLookup(cbSex, BaseReferenceType.rftAnimalGenderList, HACode.All, False)
            LookupBinder.BindBaseRepositoryLookup(cbSpecies, BaseReferenceType.rftSpeciesList, False)
            cbSpecies.ValueMember = "idfSpecies"
            cbSpecies.DataSource = SpeciesList
            eventManager.AttachDataHandler(AsSummary_DB.TableAsSummary + ".intSampledAnimalsQty", AddressOf UpdateTotals)
            eventManager.AttachDataHandler(AsSummary_DB.TableAsSummary + ".intSamplesQty", AddressOf UpdateTotals)
            eventManager.AttachDataHandler(AsSummary_DB.TableAsSummary + ".intPositiveAnimalsQty", AddressOf PositiveAnimalsQtyChanged)
            eventManager.AttachDataHandler(AsSummary_DB.TableAsSummary + ".idfSpecies", AddressOf SpeciesChanged)
            eventManager.Cascade(AsSummary_DB.TableAsSummary + ".intSampledAnimalsQty")

            AddHandler baseDataSet.Tables(AsSummary_DB.TableAsSummary).TableNewRow, AddressOf RowAdded
            AddHandler baseDataSet.Tables(AsSummary_DB.TableAsSummary).RowDeleted, AddressOf RowDeleted
            AddHandler baseDataSet.Tables(AsSummary_DB.TableAsSummary).RowChanged, AddressOf RowDeleted
        End Sub

        Private Sub PositiveAnimalsQtyChanged(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
            If (Utils.IsEmpty(e.Value) OrElse CInt(e.Value) <= 0) Then
                Dim rows As DataRow() = baseDataSet.Tables(AsSummary_DB.TableAsSummaryDiagnosis).Select(String.Format(String.Format("idfMonitoringSessionSummary ={0} ", e.Row("idfMonitoringSessionSummary"))))
                For Each row As DataRow In rows
                    If True.Equals(row("blnChecked")) Then
                        row("blnChecked") = False
                    End If
                Next
                MarkCheckListBoxes(Me, DiagnosisList)
            End If

            UpdateTotals()
        End Sub

        Private Sub SpeciesChanged(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
            SetSummarySpeciesType(e.Row, e.Value)
        End Sub

        Private Sub SetSummarySpeciesType(ByVal summaryRow As DataRow, ByVal idfSpecies As Object)
            If Not Utils.IsEmpty(idfSpecies) Then
                Dim row As DataRow = SpeciesList.Table.Rows.Find(idfSpecies)
                If Not row Is Nothing Then
                    summaryRow("idfsSpeciesType") = row("idfsReference")
                    summaryRow("strSpecies") = row("name")
                    Return
                End If

            End If
            summaryRow("idfsSpeciesType") = DBNull.Value
            summaryRow("strSpecies") = DBNull.Value

        End Sub

        Private Sub RowAdded(ByVal sender As Object, ByVal e As DataTableNewRowEventArgs)
            UpdateTotals()
        End Sub
        Private Sub RowDeleted(sender As Object, e As DataRowChangeEventArgs)
            UpdateTotals()
        End Sub

        Private Sub UpdateTotals()
            txtAnimalsQtyTotal.EditValue = baseDataSet.Tables(AsSummary_DB.TableAsSummary).Compute("sum(intSampledAnimalsQty)", Nothing)
            txtSamplesQtyTotal.EditValue = baseDataSet.Tables(AsSummary_DB.TableAsSummary).Compute("sum(intSamplesQty)", Nothing)
            txtPositiveQtyTotal.EditValue = baseDataSet.Tables(AsSummary_DB.TableAsSummary).Compute("sum(intPositiveAnimalsQty)", Nothing)
        End Sub
        Private Sub UpdateTotals(sender As Object, e As DataFieldChangeEventArgs)
            UpdateTotals()
        End Sub

        Private Sub txtFarmCode_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtFarmCode.ButtonClick
            Dim row As DataRow = AsSummaryView.GetDataRow(AsSummaryView.FocusedRowHandle)
            If (row Is Nothing) Then
                AsSummaryView.ShowEditor()
                If AsSummaryView.ActiveEditor IsNot Nothing Then
                    AsSummaryView.ActiveEditor.IsModified = True
                End If
                AsSummaryView.SetRowCellValue(AsSummaryView.FocusedRowHandle, AsSummaryView.Columns("strFarmCode"), "(new)")
                While (row Is Nothing)
                    Application.DoEvents()
                    row = AsSummaryView.GetDataRow(AsSummaryView.FocusedRowHandle)
                End While
                InvalidateColumn(colFarmID)
            End If
            If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis Then
                If row Is Nothing Then
                    Return
                End If
                'Dim IsNewFarm As Boolean = CBool(row("blnNewFarm"))
                Dim id As Object = row("idfFarm") ' IIf(IsNewFarm,row("idfFarmActual"), row("idfFarm")))
                Dim farmDetail As New FarmDetail
                If BaseFormManager.ShowModal(farmDetail, FindForm(), id, Nothing, Nothing) Then
                    row("strFarmCode") = farmDetail.FarmPanel.baseDataSet.Tables(0).Rows(0)("strFarmCode")
                    row("idfFarmActual") = farmDetail.FarmPanel.baseDataSet.Tables(0).Rows(0)("idfRootFarm")
                    row("idfFarm") = id
                    row("blnNewFarm") = False
                    row.EndEdit()
                    InvalidateColumn(colFarmID)
                    ASSession_DB.PopulateFarmSpecies(SpeciesList.Table, id)
                End If
            ElseIf e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph Then
                Dim farmList As IBaseListPanel = AsSession.CreateFarmSelectionForm()
                Dim rootFarm As IObject = BaseFormManager.ShowForSelection(farmList, FindForm())
                If Not rootFarm Is Nothing Then

                    Dim id As Long = FindFarm(row("idfMonitoringSessionSummary"), Utils.Str(rootFarm.GetValue("strFarmCode")))
                    If id <= 0 Then
                        id = CLng(ASSession_DB.CreateRootFarmCopy(rootFarm.Key, AsSessionSummaryService.ID))
                        Dim farmDetail As New FarmDetail
                        Dim startUpParam As New Dictionary(Of String, Object)
                        startUpParam("ShowHerdsTab") = True
                        If Not BaseFormManager.ShowModal(farmDetail, FindForm(), CType(id, Object), Nothing, startUpParam) Then
                            'if user clicked Cancel - we should delete just created farm
                            ASSession_DB.DeleteRootFarmCopy(id)
                            Return
                        End If
                    End If

                    row("idfFarm") = id
                    row("blnNewFarm") = False
                    row("idfFarmActual") = rootFarm.Key
                    row("strFarmCode") = Utils.Str(rootFarm.GetValue("strFarmCode"))
                    row.EndEdit()
                    InvalidateColumn(colFarmID)
                    ASSession_DB.PopulateFarmSpecies(SpeciesList.Table, id)
                End If
            End If

        End Sub

        Public Function FindFarmByCode(recordId As Object, farmCode As String) As Long
            Dim filter As String
            If Utils.IsEmpty(recordId) Then
                filter = String.Format("strFarmCode = '{0}'", farmCode)
            Else
                filter = String.Format("strFarmCode = '{0}' and idfMonitoringSessionSummary <> {1}", farmCode, recordId)
            End If
            Dim rows As DataRow() = baseDataSet.Tables(AsSummary_DB.TableAsSummary).Select(filter)
            If rows.Length > 0 Then
                Return CLng(rows(0)("idfFarm"))
            End If
            Return 0
        End Function
        Function FindFarmById(recordId As Object, farmId As Long) As Long
            Dim filter As String
            If Utils.IsEmpty(recordId) Then
                filter = String.Format("idfFarm = '{0}'", farmId)
            Else
                filter = String.Format("idfFarm = '{0}' and idfMonitoringSessionSummary <> {1}", farmId, recordId)
            End If
            Dim rows As DataRow() = baseDataSet.Tables(AsSummary_DB.TableAsSummary).Select(filter)
            If rows.Length > 0 Then
                Return CLng(rows(0)("idfFarm"))
            End If
            Return 0
        End Function
        Private ReadOnly Property AsSession As AsSessionDetail
            Get
                Return CType(FindBaseForm(Me), AsSessionDetail)
            End Get
        End Property
        Private Function FindFarm(recordId As Object, farmCode As String) As Long
            Return AsSession.FindFarm(recordId, farmCode)
        End Function
        Private Function FindFarm(recordId As Object, farmId As Long) As Long
            Return AsSession.FindFarm(recordId, farmId)
        End Function

        Private Sub cbSamples_QueryCloseUp(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cbSamples.QueryCloseUp
            InvalidateColumnAsync(colSampleType)
        End Sub
        Private Sub cbSamples_QueryPopUp(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cbSamples.QueryPopUp
            Dim row As DataRow = GetCurrentRow()
            SamplesList.DataSource = AsSessionSummaryService.GetSamples(baseDataSet, row("idfMonitoringSessionSummary"))
            MarkCheckListBoxes(Me, SamplesList)
        End Sub

        Private Sub cbDiagnosis_QueryCloseUp(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cbDiagnosis.QueryCloseUp
            InvalidateColumn(colDiagnosis)
        End Sub
        Private Sub cbDiagnosis_QueryPopUp(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cbDiagnosis.QueryPopUp
            Dim row As DataRow = GetCurrentRow()
            DiagnosisList.DataSource = AsSessionSummaryService.GetDiagnosis(baseDataSet, row, AsSession.baseDataSet.Tables(ASSession_DB.TableDiagnosis).DefaultView)
            MarkCheckListBoxes(Me, DiagnosisList)
        End Sub

        Private Sub SamplesList_ItemCheck(sender As Object, e As DevExpress.XtraEditors.Controls.ItemCheckEventArgs) Handles SamplesList.ItemCheck
            Dim lst As CheckedListBoxControl = CType(sender, CheckedListBoxControl)
            ItemCheck(lst, "strSamples", e)
        End Sub
        Private Sub DiagnosisList_ItemCheck(sender As Object, e As DevExpress.XtraEditors.Controls.ItemCheckEventArgs) Handles DiagnosisList.ItemCheck
            Dim lst As CheckedListBoxControl = CType(sender, CheckedListBoxControl)
            ItemCheck(lst, "strDiagnosis", e)
        End Sub

        Private Sub ItemCheck(lst As CheckedListBoxControl, boundFieldName As String, e As DevExpress.XtraEditors.Controls.ItemCheckEventArgs)
            Dim dv As DataView = CType(lst.DataSource, DataView)
            dv(e.Index)("blnChecked") = (e.State = CheckState.Checked)
            dv(e.Index).EndEdit()
            Dim displayValue As String = ""
            For Each row As DataRowView In dv
                If Not row("blnChecked") Is DBNull.Value AndAlso CBool(row("blnChecked")) Then
                    If (displayValue <> "") Then
                        displayValue += ", "
                    End If
                    displayValue += row("name").ToString
                End If
            Next
            Dim r As DataRow = GetCurrentRow()
            r(boundFieldName) = displayValue
            r.EndEdit()

        End Sub
        Public Shared Sub MarkCheckListBoxes(ByVal bf As BaseForm, ByVal lst As CheckedListBoxControl)
            bf.BeginUpdate()
            Dim i As Integer = 0
            If Not lst.DataSource Is Nothing And CType(lst.DataSource, DataView).Count > 0 Then
                lst.BeginUpdate()
                While Not lst.GetItem(i) Is Nothing
                    Dim row As DataRowView = CType(lst.GetItem(i), DataRowView)
                    lst.SetItemChecked(i, True.Equals(row("blnChecked")))
                    i += 1
                End While
                lst.EndUpdate()
            End If
            bf.EndUpdate()

        End Sub

        Private Sub btnDelete_Click(sender As Object, e As System.EventArgs) Handles btnDelete.Click
            Dim r As DataRow = AsSummaryView.GetFocusedDataRow()
            If Not r Is Nothing AndAlso WinUtils.ConfirmDelete Then
                Dim id As Object = r("idfMonitoringSessionSummary")
                Dim idfFarm As Long = FindFarm(r("idfMonitoringSessionSummary"), CLng(r("idfFarm")))
                If idfFarm <= 0 AndAlso Not AsSessionSummaryService.FarmsToDelete.Contains(CLng(r("idfFarm"))) Then
                    AsSessionSummaryService.FarmsToDelete.Add(CLng(r("idfFarm")))
                End If
                r.Delete()
                Dim rows() As DataRow = baseDataSet.Tables(AsSummary_DB.TableAsSummaryDiagnosis).Select(String.Format("idfMonitoringSessionSummary={0}", id))
                For i As Integer = rows.Length - 1 To 0 Step -1
                    rows(i).Delete()
                Next
            End If

        End Sub


        Private Sub AsSummaryView_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles AsSummaryView.InitNewRow
            Dim row As DataRow = AsSummaryView.GetDataRow(e.RowHandle)
            AsSessionSummaryService.InitNewSummaryRow(baseDataSet, AsSession.baseDataSet.Tables(ASSession_DB.TableDiagnosis).DefaultView, row)
        End Sub
        Private Sub ASSessionSummary_OnAfterPost(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.OnAfterPost
            If Not sender Is Me Then
                Return
            End If
            For Each row As DataRow In baseDataSet.Tables(AsSummary_DB.TableAsSummary).Rows
                row("blnNewFarm") = False
                row.AcceptChanges()
            Next
        End Sub

        Private Sub cbAnimalSpecies_QueryPopUp(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbSpecies.QueryPopUp
            If Not cbSpecies.DataSource Is Nothing Then
                Dim row As DataRow = AsSummaryView.GetDataRow(AsSummaryView.FocusedRowHandle)
                CType(cbSpecies.DataSource, DataView).RowFilter = String.Format("idfFarm = {0}", row("idfFarm")) + GetSessionSpeciesFilter()
            End If
        End Sub
        Private Sub cbAnimalSpecies_CloseUp(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.CloseUpEventArgs) Handles cbSpecies.CloseUp
            If Not cbSpecies.DataSource Is Nothing Then
                CType(cbSpecies.DataSource, DataView).RowFilter = ""
            End If
        End Sub

        Private Sub AsSummaryView_ShowingEditor(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles AsSummaryView.ShowingEditor
            If Not AsSummaryView.FocusedColumn Is colFarmID AndAlso Utils.Str(AsSummaryView.GetFocusedRowCellValue("strFarmCode")) = "" Then
                e.Cancel = True
            End If
            If Not AsSummaryView.FocusedColumn Is colSpecies AndAlso Not AsSummaryView.FocusedColumn Is colFarmID AndAlso Utils.Str(AsSummaryView.GetFocusedRowCellValue("idfSpecies")) = "" Then
                e.Cancel = True
            End If
            If AsSummaryView.FocusedColumn Is colDiagnosis AndAlso (Utils.IsEmpty(AsSummaryView.GetFocusedRowCellValue("intPositiveAnimalsQty")) OrElse CInt(AsSummaryView.GetFocusedRowCellValue("intPositiveAnimalsQty")) <= 0) Then
                e.Cancel = True
            End If
        End Sub

        Private m_SpeciesList As DataView
        <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Localizable(False)> _
        Public Property SpeciesList As DataView
            Get
                Return m_SpeciesList
            End Get
            Set(ByVal value As DataView)
                m_SpeciesList = value
            End Set
        End Property

        Private Sub ClearCheckBoxList(ByVal lst As CheckedListBoxControl)
            If Not lst.DataSource Is Nothing And CType(lst.DataSource, DataView).Count > 0 Then
                For Each row As DataRowView In CType(lst.DataSource, DataView)
                    row("blnChecked") = False
                    row.EndEdit()
                Next
            End If
            MarkCheckListBoxes(Me, lst)
        End Sub

        Private Sub CopyCheckBoxList(ByVal lst As CheckedListBoxControl, ByVal clipboard As List(Of Long), ByVal keyName As String)
            clipboard.Clear()
            If Not lst.DataSource Is Nothing And CType(lst.DataSource, DataView).Count > 0 Then
                For Each row As DataRowView In CType(lst.DataSource, DataView)
                    If (row("blnChecked").Equals(True)) Then
                        clipboard.Add(CLng(row(keyName)))
                    End If
                Next
            End If
        End Sub

        Private Sub PasteToCheckListBox(ByVal lst As CheckedListBoxControl, ByVal clipboard As List(Of Long), ByVal keyName As String)
            If Not lst.DataSource Is Nothing And CType(lst.DataSource, DataView).Count > 0 Then

                For Each row As DataRowView In CType(lst.DataSource, DataView)
                    If (clipboard.IndexOf(CLng(row(keyName))) >= 0) Then
                        row("blnChecked") = True
                    ElseIf row("blnChecked").Equals(True) Then
                        row("blnChecked") = False
                    End If
                Next

            End If
            MarkCheckListBoxes(Me, lst)
        End Sub

        Private m_SamplesClipboard As New List(Of Long)
        Private m_DiagnosisClipboard As New List(Of Long)
        Private Sub btnClearSamples_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearSamples.Click
            ClearCheckBoxList(SamplesList)
        End Sub

        Private Sub btnCopySamples_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopySamples.Click
            CopyCheckBoxList(SamplesList, m_SamplesClipboard, "idfsSampleType")
            btnPasteSamples.Enabled = True
        End Sub

        Private Sub btnPasteSamples_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPasteSamples.Click
            PasteToCheckListBox(SamplesList, m_SamplesClipboard, "idfsSampleType")
        End Sub


        Private Sub btnClearDiagnosis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearDiagnosis.Click
            ClearCheckBoxList(DiagnosisList)
        End Sub

        Private Sub btnCopyDiagnosis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopyDiagnosis.Click
            CopyCheckBoxList(DiagnosisList, m_DiagnosisClipboard, "idfsDiagnosis")
            btnPasteDiagnosis.Enabled = True
        End Sub

        Private Sub btnPasteDiagnosis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPasteDiagnosis.Click
            PasteToCheckListBox(DiagnosisList, m_DiagnosisClipboard, "idfsDiagnosis")
        End Sub

        Private Sub btnOkDiagnosis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOkdiagnosis.Click, btnOkSamples.Click
            If Not Me.AsSummaryGrid.FocusedView.ActiveEditor Is Nothing AndAlso TypeOf AsSummaryGrid.FocusedView.ActiveEditor Is PopupContainerEdit AndAlso CType(AsSummaryGrid.FocusedView.ActiveEditor, PopupContainerEdit).IsPopupOpen Then
                CType(AsSummaryGrid.FocusedView.ActiveEditor, PopupContainerEdit).ClosePopup()
            End If

        End Sub
        Delegate Sub InvalidateColumnDelegate(ByVal col As GridColumn)
        Private Sub InvalidateColumnAsync(ByVal col As GridColumn)
            Me.BeginInvoke(New InvalidateColumnDelegate(AddressOf InvalidateColumn), col)
        End Sub

        Private Sub InvalidateColumn(ByVal col As GridColumn)

            AsSummaryView.HideEditor()
            AsSummaryView.FocusedColumn = colSamplesQty
            Application.DoEvents()
            AsSummaryView.FocusedColumn = col

        End Sub
        Private Function GetSessionSpeciesFilter() As String
            Dim filter As String = AsSession.GetSpeciesFilter(True)
            If Not Utils.IsEmpty(filter) Then
                Return " and " + filter
            End If
            Return ""
        End Function

        Public Function ContainsSpeciesType(ByVal speciesType As Long) As Boolean
            Return baseDataSet.Tables(AsSummary_DB.TableAsSummary).Select(String.Format("idfsSpeciesType = {0}", speciesType)).Length > 0
        End Function

        Private Sub AsSummaryView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles AsSummaryView.ValidateRow
            If (CType(e.Row, DataRowView)("blnNewFarm").Equals(True)) Then
                e.Valid = False
                e.ErrorText = EidssMessages.Get("msgFarmIsNotDefined", "Some mandatory farm attributes are not defined. Press <...> button to edit farm or select other farm.")
                Return
            End If

            If Not AsSession.ValidateCollectionDate(CType(e.Row, DataRowView)("datCollectionDate")) Then
                e.Valid = False
                e.ErrorText = EidssMessages.Get("AsSession.SummaryItem.datCollectionDate_msgId")
            End If
        End Sub

    End Class
End Namespace
