namespace WCF_SalesOrder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    /// <summary>
    /// Contiene las funciones que se utilizan en todo el servicio
    /// </summary>
    public class clsComunes
    {
        /// <summary>
        /// Valida si el valor ingresado es de tipo Int
        /// </summary>
        /// <param name="svalor">string sdate</param>
        /// <returns>Retorna bool</returns>
        public bool IsInt(string svalor)
        {
            int dt;
            bool dato = true;
            try
            {
                dt = int.Parse(svalor);
            }
            catch
            {
                dato = false;
            }

            return dato;
        }
    }
}