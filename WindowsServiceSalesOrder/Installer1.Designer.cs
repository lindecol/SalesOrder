namespace WindowsServiceSalesOrder
{
    /// <summary>
    /// Instalación de Sales Order
    /// </summary>
     public partial class Installer1
    {
         /// <summary>
        /// System.ServiceProcess.ServiceInstaller serviceInstaller1
         /// </summary>
        private System.ServiceProcess.ServiceInstaller serviceInstaller1;

         /// <summary>
        /// System.ServiceProcess.ServiceProcessInstaller serviceProcessInstaller1
         /// </summary>
        private System.ServiceProcess.ServiceProcessInstaller serviceProcessInstaller1;

        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.serviceInstaller1 = new System.ServiceProcess.ServiceInstaller();
            this.serviceProcessInstaller1 = new System.ServiceProcess.ServiceProcessInstaller();
            // 
            // serviceInstaller1
            // 
            this.serviceInstaller1.Description = "Servicio de lanzamiento de Sales Orders Interface JDE";
            this.serviceInstaller1.DisplayName = "Servicio de Sales Orders Interface JDE";
            this.serviceInstaller1.ServiceName = "ServicioSalesOrders Interface JDE";
            this.serviceInstaller1.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // serviceProcessInstaller1
            // 
            this.serviceProcessInstaller1.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.serviceProcessInstaller1.Password = null;
            this.serviceProcessInstaller1.Username = null;
            // 
            // Installer1
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.serviceInstaller1,
            this.serviceProcessInstaller1});

        }

        #endregion
   }
}