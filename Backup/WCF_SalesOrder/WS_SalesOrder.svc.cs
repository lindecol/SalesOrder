namespace WCF_SalesOrder
{
    using System;
    using System.Xml;
    using System.Xml.Serialization;
    using System.Data;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.Text;
    using System.Collections;
    using System.IO;
    using BC_SalesOrder;
    using System.ServiceModel.Web;
    using System.Net;
    using System.Data.OracleClient;

    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "WS_SalesOrder" en el código, en svc y en el archivo de configuración a la vez.

    /// <summary>
    /// Servicio que contiene toda la logica de SalesOrder
    /// </summary>
    [ServiceBehavior(Namespace = "http://www.praxair.com.co/SalesOrder")]
    public class WS_SalesOrder : IWS_SalesOrder
    {
        /// <summary>
        /// Identificador Sales Order
        /// </summary>
        private int SalesOrderId { get; set; }

        /// <summary>
        /// Comfirma que la orden de compra de fusion se realizo correcatemente
        /// </summary>
        /// <param name="mcu">Almacen</param>
        /// <param name="legacyConsecutive">Consecutivo</param>
        /// <param name="legacyPrefix">Prefijo</param>
        /// <param name="dcto">Typo de Orden</param>
        /// <param name="interfaceStatus">Estado</param>
        /// <returns></returns>
        public clsResponse[] Confirmation(string mcu, string legacyConsecutive, string legacyPrefix, string dcto, string interfaceStatus)
        {
            try
            {
                clsComunes Validar = new clsComunes();

                if (mcu.Length != 8)
                {
                    throw new ArgumentException("El valor del MCU debe poseer una longitud de 8 caracteres");
                }

                if (!Validar.IsNumeric(mcu))
                {
                    throw new ArgumentException("El valor del MCU debe representar un dato numérico");
                }

                if (dcto.Length != 2)
                {
                    throw new ArgumentException("El valor del DCTO debe poseer una longitud de 2 caracteres");
                }

                if (interfaceStatus.Length != 1)
                {
                    throw new ArgumentException("El valor del INTERFACESTATUS debe poseer una longitud de 1 caracter");
                }

                if (legacyPrefix.Length != 5)
                {
                    throw new ArgumentException("El valor del LEGACYPREFIX debe poseer una longitud de 5 caracteres");
                }

                if (!Validar.IsNumeric(legacyPrefix))
                {
                    throw new ArgumentException("El valor del LEGACYPREFIX debe representar un dato numérico");
                }

                if (legacyConsecutive.Length != 8)
                {
                    throw new ArgumentException("El valor del LEGACYCONSECUTIVE debe poseer una longitud de 8 caracteres");
                }

                if (!Validar.IsNumeric(legacyConsecutive))
                {
                    throw new ArgumentException("El valor del LEGACYCONSECUTIVE debe representar un dato numérico");
                }

                clsSalesOrder SalesOrder = new clsSalesOrder();                
                SalesOrder.LEGACY_COMPANY = SalesOrder.Get_Cia(mcu);
                SalesOrder.INTERFACE_STATUS = interfaceStatus;
                SalesOrder.LEGACY_PREFIX = legacyPrefix;
                SalesOrder.LEGACY_CONSECUTIVE = legacyConsecutive;
                SalesOrder.ORDER_TYPE = dcto;
                SalesOrder.Confirmation();

                using (ServicioLog.UtilitiesClient swLog = new ServicioLog.UtilitiesClient())
                {
                    swLog.InsertError(this.SalesOrderId, 24, ServicioLog.ProcessId.SalesOrder, "OK Confirmación de Fusion LEGACY_CONSECUTIVE: " + SalesOrder.LEGACY_CONSECUTIVE + " LEGACY_PREFIX: " + SalesOrder.LEGACY_PREFIX + " LEGACY_COMPANY: " + SalesOrder.LEGACY_COMPANY.ToString() + " INTERFACE_STATUS: " + SalesOrder.INTERFACE_STATUS + " ORDER_TYPE: " + SalesOrder.ORDER_TYPE);
                }

                List<clsResponse> Resp = new List<clsResponse>();
                Resp.Add(new clsResponse { TypeDesc = "OK", MessageDesc = "Almacenado Con Exito" });
                return Resp.ToArray();
            }

            catch (OracleException ex1)//TYPE ERROR = CONNECTION THEN THIS 
            {
                using (ServicioLog.UtilitiesClient swLog = new ServicioLog.UtilitiesClient())
                {
                    swLog.InsertError(this.SalesOrderId, 24, ServicioLog.ProcessId.SalesOrder, "ERROR BASE DE DATOS " + ex1.Message);
                }
                throw new FaultException<clsResponse>(new clsResponse { MessageDesc = ex1.Message, TypeDesc = "REPLICATION" }, "");

            }
            catch (Exception e)
            {
                using (ServicioLog.UtilitiesClient swLog = new ServicioLog.UtilitiesClient())
                {
                    swLog.InsertError(this.SalesOrderId, 24, ServicioLog.ProcessId.SalesOrder, e.Message + " LEGACY_CONSECUTIVE: " + legacyConsecutive + " LEGACY_PREFIX: " + legacyPrefix + " LEGACY_COMPANY: " + mcu + " INTERFACE_STATUS: " + interfaceStatus + " ORDER_TYPE: " + dcto);
                }

                throw new FaultException<clsResponse>(new clsResponse { MessageDesc = e.Message, TypeDesc = "EXCEPTION" }, "");
            }
        }

        /// <summary>
        /// SalesOrder por Estado
        /// </summary>
        /// <param name="InterfaceStatus">string InterfaceStatus</param>
        public void GetSalesOrder(string InterfaceStatus)
        {
            clsSalesOrder SalesOrder = new clsSalesOrder();
            
            //bool blnValidaSucursal = true;
            string strMCUInvalido = "";

            SalesOrder.INTERFACE_STATUS = InterfaceStatus;

            //validación si la cia viene en 0 
            //if (SalesOrder.LEGACY_COMPANY == 0)
            //{
            //    SalesOrder.INTERFACE_STATUS = "P";
            //    using (ServicioLog.UtilitiesClient swLog = new ServicioLog.UtilitiesClient())
            //    {
            //        swLog.InsertError(this.SalesOrderId, 24, ServicioLog.ProcessId.SalesOrder, "ERROR LA COMPAÑIA NO PUEDE SER NULA" );
            //        return;
            //    }
            //}

            foreach (var item in SalesOrder.Get_SalesOrder())
            {
                try
                {                   
                    this.SalesOrderId = item.SALES_ORDER_ID;
                    SalesOrder = item;

                    DataSet datasSalesOrder = new DataSet();
                    datasSalesOrder = SalesOrder.Get_ListaSalesOrderDcto();
                    
                    if (datasSalesOrder.Tables[0].Rows.Count != 0 || datasSalesOrder.Tables[1].Rows.Count != 0)
                    {
                        ServicioSalesOrder.CreateSalesOrderPraxReqABCSImplClient SerSalesOrder = new ServicioSalesOrder.CreateSalesOrderPraxReqABCSImplClient();
                        ServicioSalesOrder.SalesOrder objSalesOrder = new ServicioSalesOrder.SalesOrder();

                        clsComunes Comunes = new clsComunes();

                        objSalesOrder.Header = new ServicioSalesOrder.SalesOrderHeader();


                        //validación si la sucursal existe en jde
                        if (SalesOrder.Get_ScrValida(int.Parse(datasSalesOrder.Tables[0].Rows[0]["MCU"].ToString())) == 0)
                        {
                            strMCUInvalido = datasSalesOrder.Tables[0].Rows[0]["MCU"].ToString();
                            SalesOrder.INTERFACE_STATUS = "P";

                            using (ServicioLog.UtilitiesClient swLog = new ServicioLog.UtilitiesClient())
                            {
                                swLog.InsertError(this.SalesOrderId, 24, ServicioLog.ProcessId.SalesOrder, "ERROR NO SE ENCONTRO MCU EN JDE, MCU NO ENCONTRADO: " + strMCUInvalido + " LEGACY_CONSECUTIVE: " + item.LEGACY_CONSECUTIVE + " LEGACY_PREFIX: " + item.LEGACY_PREFIX + " LEGACY_COMPANY: " + item.LEGACY_COMPANY);
                                SalesOrder.INTERFACE_STATUS = "P";
                                SalesOrder.ConfirmationDcto();
                                break;
                            }
                        }


                        if (datasSalesOrder.Tables[0].Rows[0]["AN8"] != null && Comunes.IsNumeric(datasSalesOrder.Tables[0].Rows[0]["AN8"].ToString()))
                        {
                            objSalesOrder.Header.AN8 = int.Parse(datasSalesOrder.Tables[0].Rows[0]["AN8"].ToString());
                        }

                        objSalesOrder.Header.TRDJ = DateTime.Parse(datasSalesOrder.Tables[0].Rows[0]["TRDJ"].ToString());

                        objSalesOrder.Header.CRCD = datasSalesOrder.Tables[0].Rows[0]["CRCD"].ToString();
                        objSalesOrder.Header.DCTO = datasSalesOrder.Tables[0].Rows[0]["DCTO"].ToString();

                        objSalesOrder.Header.MCU = datasSalesOrder.Tables[0].Rows[0]["MCU"].ToString();                        
                        
                        if (datasSalesOrder.Tables[0].Rows[0]["SHAN"] != null && Comunes.IsNumeric(datasSalesOrder.Tables[0].Rows[0]["SHAN"].ToString()))
                        {
                            objSalesOrder.Header.SHAN = int.Parse(datasSalesOrder.Tables[0].Rows[0]["SHAN"].ToString());
                        }

                        List<ServicioSalesOrder.Detail> ListDetalle = new List<ServicioSalesOrder.Detail>();


                        for (int i = 0; i < datasSalesOrder.Tables[1].Rows.Count; i++)
                        {
                            ServicioSalesOrder.Detail objDetalle = new ServicioSalesOrder.Detail();
                            objDetalle.MCU = datasSalesOrder.Tables[1].Rows[i]["MCU"].ToString();

                            if (datasSalesOrder.Tables[1].Rows[i]["SHAN"] != null && Comunes.IsNumeric(datasSalesOrder.Tables[1].Rows[i]["SHAN"].ToString()))
                            {
                                objDetalle.SHAN = int.Parse(datasSalesOrder.Tables[1].Rows[i]["SHAN"].ToString());
                            }

                            objDetalle.VR01 = datasSalesOrder.Tables[1].Rows[i]["VR01"].ToString();
                            objDetalle.VR02 = datasSalesOrder.Tables[1].Rows[i]["VR02"].ToString();
                            objDetalle.LOTN = datasSalesOrder.Tables[1].Rows[i]["LOTN"].ToString();
                            objDetalle.EMCU = datasSalesOrder.Tables[1].Rows[i]["EMCU"].ToString();

                            if (datasSalesOrder.Tables[1].Rows[i]["UORG"] != null && Comunes.IsNumeric(datasSalesOrder.Tables[1].Rows[i]["UORG"].ToString()))
                            {
                                objDetalle.UORG = decimal.Parse(datasSalesOrder.Tables[1].Rows[i]["UORG"].ToString());
                            }

                            if (datasSalesOrder.Tables[1].Rows[i]["AEXP"] != null && Comunes.IsNumeric(datasSalesOrder.Tables[1].Rows[i]["AEXP"].ToString()))
                            {
                                objDetalle.AEXP = decimal.Parse(datasSalesOrder.Tables[1].Rows[i]["AEXP"].ToString());
                            }

                            if (datasSalesOrder.Tables[1].Rows[i]["URAT"] != null && Comunes.IsNumeric(datasSalesOrder.Tables[1].Rows[i]["URAT"].ToString()))
                            {
                                objDetalle.URAT = decimal.Parse(datasSalesOrder.Tables[1].Rows[i]["URAT"].ToString());
                            }

                            objDetalle.Item = new ServicioSalesOrder.Item();

                            objDetalle.Item.LITM = datasSalesOrder.Tables[1].Rows[i]["LITM"].ToString();
                            objDetalle.Item.ITM = datasSalesOrder.Tables[1].Rows[i]["ITM"].ToString();
                            objDetalle.Item.SKTK = datasSalesOrder.Tables[1].Rows[i]["SKTK"].ToString();
                            objDetalle.Item.UOM = datasSalesOrder.Tables[1].Rows[i]["UOM"].ToString();

                            ListDetalle.Add(objDetalle);
                            objSalesOrder.Details = ListDetalle.ToArray();
                        }


                        System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(objSalesOrder.GetType());
                        System.Text.StringBuilder sb = new System.Text.StringBuilder();
                        System.IO.StringWriter writer = new System.IO.StringWriter(sb);

                        System.Xml.Serialization.XmlSerializerNamespaces espacioDeNombres = new System.Xml.Serialization.XmlSerializerNamespaces();
                        espacioDeNombres.Add("cus", @"http://www.praxair.com.co/SalesOrder");

                        ser.Serialize(writer, objSalesOrder, espacioDeNombres);

                        string objSales = sb.ToString();

                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml(objSales);

                        objSales = objSales.Replace("utf-16", "utf-8");

                        XmlSerializer xmlSerz = new XmlSerializer(objSalesOrder.GetType());
                        StringReader strReader = new StringReader(objSales);

                        object obj = xmlSerz.Deserialize(strReader);

                        //aqui llama al servicio web de jde para crear la orden de venta enviandole el xml 
                        SerSalesOrder.CreateSalesOrder((ServicioSalesOrder.SalesOrder)obj);

                        //Este estado se marca con G cuando sale de PRAX luego Fusion modifica el estado a S cuando fue procesado correctamente
                        SalesOrder.INTERFACE_STATUS = "G";
                        SalesOrder.ConfirmationDcto();

                        using (ServicioLog.UtilitiesClient swLog = new ServicioLog.UtilitiesClient())
                        {
                            swLog.InsertError(this.SalesOrderId, 24, ServicioLog.ProcessId.SalesOrder, "OK LEGACY_CONSECUTIVE: " + item.LEGACY_CONSECUTIVE + " LEGACY_PREFIX: " + item.LEGACY_PREFIX + " LEGACY_COMPANY: " + item.LEGACY_COMPANY);
                        }

                          
                    }
                    else
                    {
                        using (ServicioLog.UtilitiesClient swLog = new ServicioLog.UtilitiesClient())
                        {
                            swLog.InsertError(this.SalesOrderId, 24, ServicioLog.ProcessId.SalesOrder, "No se encontraron datos de factura CONSECUTIVE: " + item.LEGACY_CONSECUTIVE + " PREFIX: " + item.LEGACY_PREFIX);
                        }
                    }
                }

                catch (System.ServiceModel.EndpointNotFoundException e)
                {
                    using (ServicioLog.UtilitiesClient swLog = new ServicioLog.UtilitiesClient())
                    {
                        swLog.InsertError(this.SalesOrderId, 24, ServicioLog.ProcessId.SalesOrder, "ERROR DE CONEXIÓN " + e.Message);
                    }
                }
                    
                catch (Exception e)
                {
                    using (ServicioLog.UtilitiesClient swLog = new ServicioLog.UtilitiesClient())
                    {
                        swLog.InsertError(this.SalesOrderId, 24, ServicioLog.ProcessId.SalesOrder, e.Message + " LEGACY_CONSECUTIVE: " + item.LEGACY_CONSECUTIVE.ToString() + " LEGACY_PREFIX: " + item.LEGACY_PREFIX.ToString() + " LEGACY_COMPANY: " + item.LEGACY_COMPANY.ToString());
                    }
                }
            }
        }
    }
}
