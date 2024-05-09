namespace WindowsServiceSalesOrder
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.ServiceProcess;
    using System.Text;
    using System.Timers;
    using System.IO;
    using System.Configuration;

    /// <summary>
    /// Entidad SalesOrder
    /// </summary>
    public partial class SalesOrder : ServiceBase
    {
        /// <summary>
        /// Timer periodo
        /// </summary>
        private Timer periodo = null;
        private bool _iniciar;

        /// <summary>
        /// Initializes a new instance of the SalesOrder class.
        /// </summary>
        public SalesOrder()
        {
            this.InitializeComponent();
            int intervalo = int.Parse(ConfigurationManager.AppSettings["Intervalo"].ToString());
            this.periodo = new Timer(intervalo);            
            this.periodo.Elapsed += new ElapsedEventHandler(this.Proceso);
        }

        /// <summary>
        /// Inicial el Servicio Windows
        /// </summary>
        /// <param name="args">Parametro que contiene el estado</param>
        protected override void OnStart(string[] args)
        {
            _iniciar = true;
            this.periodo.Start();
        }

        /// <summary>
        /// Detinene el Servicio Windows
        /// </summary>
        protected override void OnStop()
        {
            //this.periodo.Stop();
            _iniciar = false;
        }

        /// <summary>
        /// Función de almacenamiento del log
        /// </summary>
        /// <param name="estado">tipo de dato string</param>
        private void Log(string estado)
        {
            try
            {
                string path = ConfigurationManager.AppSettings["RutaLog"].ToString();
                TextWriter tw = new StreamWriter(path, true);
                tw.WriteLine(DateTime.Now.ToString() + ", Intervalo: " + this.periodo.Interval.ToString() + " " + estado + "\n");
                tw.Close();
            }
            catch (Exception ex)
            {
                System.Diagnostics.EventLog.WriteEntry("Application", "Exception: " + ex.Message);
            }
        }
        
        /// <summary>
        /// Ejecuta el proceso de llamado al Servicio Web solo registra en el log cuando ocurra error
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">ElapsedEventArgs e</param>
        private void Proceso(object sender, ElapsedEventArgs e)
        {
            if (_iniciar)
            {
                _iniciar = false;
                try
                {
                    ServicioSalesOrder.WS_SalesOrderClient ServSalesOrder = new ServicioSalesOrder.WS_SalesOrderClient();
                    ServSalesOrder.GetSalesOrder(ConfigurationManager.AppSettings["EstadoOrden"].ToString());
                }
                catch (Exception ex)
                {
                    this.Log("Error " + ex.Message);
                }
                _iniciar = true;
            }
            
        }
    }
}
