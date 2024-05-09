namespace WindowsServiceSalesOrder
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Configuration.Install;
    using System.Linq;

    /// <summary>
    /// Entidad principal para instalador
    /// </summary>
    [RunInstaller(true)]
    public partial class Installer1 : System.Configuration.Install.Installer
    {
        /// <summary>
        /// Initializes a new instance of the Installer1 class.
        /// </summary>
        public Installer1()
        {
            this.InitializeComponent();
        }
    }
}
