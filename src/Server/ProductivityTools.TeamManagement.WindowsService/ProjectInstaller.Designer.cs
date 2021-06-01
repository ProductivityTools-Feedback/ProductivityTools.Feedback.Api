namespace PSTeamManagement.WindowsService
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PSTeamManagmentServiceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.PSTeamManagmentServiceInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // PSTeamManagmentServiceProcessInstaller
            // 
            this.PSTeamManagmentServiceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.PSTeamManagmentServiceProcessInstaller.Password = null;
            this.PSTeamManagmentServiceProcessInstaller.Username = null;
            // 
            // PSTeamManagmentServiceInstaller
            // 
            this.PSTeamManagmentServiceInstaller.DisplayName = "PSTeamManagement";
            this.PSTeamManagmentServiceInstaller.ServiceName = "PSTeamManagement";
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.PSTeamManagmentServiceProcessInstaller,
            this.PSTeamManagmentServiceInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller PSTeamManagmentServiceProcessInstaller;
        private System.ServiceProcess.ServiceInstaller PSTeamManagmentServiceInstaller;
    }
}