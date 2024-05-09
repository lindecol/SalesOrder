namespace WCF_SalesOrder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.Text;
    using System.Data.OracleClient;

    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IWS_SalesOrder" en el código y en el archivo de configuración a la vez.
    
    /// <summary>
    /// Interfase de servicio logica Sales Order
    /// </summary>
    [ServiceContract(Namespace = "http://www.praxair.com.co/SalesOrder")]
    public interface IWS_SalesOrder
    {
        /// <summary>
        /// SalesOrder por Estado
        /// </summary>
        /// <param name="InterfaceStatus">string InterfaceStatus</param>
        [OperationContract]
        void GetSalesOrder(string InterfaceStatus);

        /// <summary>
        /// Permite que Fusion envie una respueta sobre el estado de la orden de compra enviada
        /// </summary>
        /// <param name="mcu">Almacen</param>
        /// <param name="legacyConsecutive">Consecutivo</param>
        /// <param name="legacyPrefix">Prefijo</param>
        /// <param name="dcto">Tipo de Orden</param>
        /// <param name="interfaceStatus">Estado</param>
        [FaultContract(typeof(clsResponse), Name = "InternalException", Namespace = "http://www.praxair.com.co/SalesOrder")]
        [OperationContract]
        clsResponse[] Confirmation(string mcu, string legacyConsecutive, string legacyPrefix, string dcto, string interfaceStatus);
    }
}
