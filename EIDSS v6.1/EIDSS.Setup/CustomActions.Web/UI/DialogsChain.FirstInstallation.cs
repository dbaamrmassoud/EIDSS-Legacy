namespace CustomActions.UI
{
  using Microsoft.Deployment.WindowsInstaller;


  internal sealed class FirstInstallationDialogsChain : DialogsChain
  {
    internal FirstInstallationDialogsChain(Session session, InstallMode installMode)
      : base(session, installMode)
    {
    }

    protected override void FillChain()
    {
      AddDialog(Dialogs.CustomCustomizeDlg);
      AddDialog(Dialogs.DbSettingsDlg);
      AddDialog(Dialogs.ArchiveDbSettingsDlg);
      AddDialog(Dialogs.ServiceAccountDlg, m_installMode.IsServiceConfigurationDlgRequired);
      AddDialog(Dialogs.SharedWebsitePortDlg, m_installMode.IsPortSharingConfigurationRequired);
      AddDialog(Dialogs.GisMapsFolderDlg, m_installMode.IsGisMapsConfigurationRequired);
      AddDialog(Dialogs.WebSettingsDlg, m_installMode.IsWebConfigurationRequired);
      AddDialog(Dialogs.WebAppSettingsDlg, m_installMode.IsWebConfigurationRequired);
      AddDialog(Dialogs.DbSettingsForAvrDlg, m_installMode.IsDbSettingsForAvrConfigurationRequired);
      AddDialog(Dialogs.AvrSvcSettingsDlg, m_installMode.IsAvrConfigurationRequired);
      AddDialog(Dialogs.MobileDlg, m_installMode.IsMobileConfigurationRequired);
      AddDialog(Dialogs.AppPoolSettingsDlg, m_installMode.IsAppPoolConfigurationRequired);
      AddDialog(Dialogs.SmartphoneDlg, m_installMode.IsSmartphoneConfigurationRequired);
      AddDialog(Dialogs.OpenApiDlg, m_installMode.IsOpenAPIConfigurationRequired);
      AddDialog(Dialogs.ReportsSvcSettingsDlg, m_installMode.IsReportsSvcConfigurationRequired);
      AddDialog(Dialogs.LogPathsDlg);
      AddDialog(Dialogs.VerifyReadyDlg);
    }
  }
}