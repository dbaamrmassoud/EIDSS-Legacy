Imports System.Data
Imports System.Data.Common

Public Class NotificationSubscription_DB
    Inherits BaseDbService

    Public Const TableEventSubscription As String = "EventSubScription"
    Public Overrides Function GetDetail(ByVal ID As Object) As System.Data.DataSet
        Dim ds As New DataSet
        Try
            Dim cmd As IDbCommand = CreateSPCommand("spNotificationSubscription_SelectDetail")
            AddParam(cmd, "@ClientID", EIDSS.model.Core.EidssUserContext.ClientID)
            AddParam(cmd, "@LangID", bv.model.Model.Core.ModelUserContext.CurrentLanguage)
            Dim da As DbDataAdapter = CreateAdapter(cmd)
            da.Fill(ds, TableEventSubscription)
            ds.Tables(TableEventSubscription).Columns("Subscription").ReadOnly = False
            ds.AcceptChanges()
            Return ds
        Catch ex As Exception
            m_error = New ErrorMessage(StandardError.FillDatasetError, ex)
            Return Nothing
        End Try

    End Function

    Public Overrides Function PostDetail(ByVal ds As System.Data.DataSet, ByVal PostType As Integer, Optional ByVal transaction As System.Data.IDbTransaction = Nothing) As Boolean
        If ds Is Nothing Then Return True
        Try
            BaseDbService.ExecPostProcedure("spNotificationSubscription_Post", ds.Tables(TableEventSubscription), Connection, transaction)
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.PostError, ex)
            Return False
        End Try
        Return True

    End Function
End Class
