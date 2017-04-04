Imports bv.common.Enums

Public Class AvianFarmDetail_DB
    Inherits BaseDbService
    Public Sub New()
        ObjectName = "Farm"
    End Sub

    Public Const TableFarm As String = "Farm"

    Public Overrides Function GetDetail(ByVal ID As Object) As DataSet
        Dim ds As New DataSet
        Try

            Dim cmd As IDbCommand = CreateSPCommand("spAvianFarmDetail_SelectDetail")

            AddParam(cmd, "@idfFarm", ID)
            FillDataset(cmd, ds, TableFarm)
            CorrectTable(ds.Tables(0), )
            ClearColumnsAttibutes(ds)
            ds.EnforceConstraints = False

            If ID Is Nothing Then
                ID = NewIntID()
            End If
            If ds.Tables(TableFarm).Rows.Count = 0 Then
                Dim r As DataRow = ds.Tables(TableFarm).NewRow
                r("idfFarm") = ID
                ds.EnforceConstraints = False
                ds.Tables(TableFarm).Rows.Add(r)
                ForceTableChanges(ds.Tables(TableFarm))
                m_IsNewObject = True
            End If

            m_ID = ID
            Return ds
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.FillDatasetError, ex)
            Return Nothing
        End Try
    End Function
    Public Overrides Function PostDetail(ByVal ds As DataSet, ByVal postType As Integer, Optional ByVal transaction As IDbTransaction = Nothing) As Boolean
        If ds Is Nothing Then Return True
        Try
            ExecPostProcedure("spAvianFarmDetail_Post", ds.Tables(TableFarm), Connection, transaction)
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.PostError, ex)
            Return False
        End Try
        Return True
    End Function

End Class
