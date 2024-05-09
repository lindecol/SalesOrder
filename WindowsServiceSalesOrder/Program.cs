namespace WindowsServiceSalesOrder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.ServiceProcess;
    using System.Text;

    /// <summary>
    /// Clase principal program
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        private static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
            {
               new SalesOrder() 
            };

            ServiceBase.Run(ServicesToRun);
        }
    }
}
