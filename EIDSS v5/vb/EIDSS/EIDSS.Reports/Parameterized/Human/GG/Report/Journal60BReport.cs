using System;
using System.Data.SqlClient;
using EIDSS.Reports.BaseControls.Report;
using bv.model.BLToolkit;
using eidss.model.Reports.Common;
using eidss.model.Reports.GG;

namespace EIDSS.Reports.Parameterized.Human.GG.Report
{
    public sealed partial class Journal60BReport : BaseIntervalReport
    {
        public Journal60BReport()
        {
            InitializeComponent();
        }

        public void SetParameters(DbManagerProxy manager, Hum60BJournalModel model)
        {
            SetParameters(manager, (BaseIntervalModel) model);

            Action<SqlConnection> action = (connection =>
                {
                    spRepJournal60BTableAdapter1.Connection = connection;
                    spRepJournal60BTableAdapter1.Transaction = (SqlTransaction)manager.Transaction;
                    spRepJournal60BTableAdapter1.CommandTimeout = CommandTimeout;

                    journal60BDataSet1.EnforceConstraints = false;

                    spRepJournal60BTableAdapter1.Fill(
                        journal60BDataSet1.spRepJournal60B,
                        model.Language,
                        model.StartDate,
                        model.EndDate,
                        model.Diagnosis);
                });

            FillDataTableWithArchive(action,
                                     (SqlConnection) manager.Connection,
                                     journal60BDataSet1.spRepJournal60B,
                                     model.UseArchive,
                                     new[] {"strCaseId"});
            DetailReport.DataAdapter = null;
            DataAdapter = null;
        }
    }
}