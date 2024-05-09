namespace BC_SalesOrder
{
    using System;
    using System.Data.Common;
    using System.Data;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.Practices.EnterpriseLibrary.Data;

    /// <summary>
    /// Definicioón de la clase clsSalesOrder.
    /// </summary>
    public class clsSalesOrder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="clsSalesOrder"/> class.
        /// </summary>
        public clsSalesOrder()
        {
        }

        /// <summary>
        /// Initializes a new instance of the clsSalesOrder class.
        /// </summary>
        /// <param name="salesOrderId">int salesOrderId</param>
        /// <param name="legacyCompany">int legacyCompany</param>
        /// <param name="legacyPrefix">string legacyPrefix</param>
        /// <param name="legacyConsecutive">string legacyConsecutive</param>
        /// <param name="interfaceStatus">string interfaceStatus</param>
        private clsSalesOrder(int salesOrderId, int legacyCompany, string legacyPrefix, string legacyConsecutive, string interfaceStatus,int stagging,string orderType)
        {
            this.SALES_ORDER_ID = salesOrderId;
            this.LEGACY_COMPANY = legacyCompany;
            this.LEGACY_PREFIX = legacyPrefix;
            this.LEGACY_CONSECUTIVE = legacyConsecutive;
            this.INTERFACE_STATUS = interfaceStatus;
            this.IDSTAGGING = stagging;
            this.ORDER_TYPE = orderType;
        }

        /// <summary>
        /// Identificador único tabla Sales Order 
        /// </summary>
        public int SALES_ORDER_ID { get; set; }

        /// <summary>
        /// Identificador Legacy Company
        /// </summary>
        public int LEGACY_COMPANY { get; set; }

        /// <summary>
        /// Identificador Legacy Prefix
        /// </summary>
        public string LEGACY_PREFIX { get; set; }

        /// <summary>
        /// Identificador Legacy Consecutive
        /// </summary>
        public string LEGACY_CONSECUTIVE { get; set; }

        /// <summary>
        /// Identificador Interface Status
        /// </summary>
        public string INTERFACE_STATUS { get; set; }

        /// <summary>
        /// Tipo de Orden de compra
        /// </summary>
        public string ORDER_TYPE { get; set; }
        
        /// <summary>
        /// Identificador Stagging
        /// </summary>
        public int IDSTAGGING { get; set; }

        /// <summary>
        /// Permite almacenar el estado de la la confirmación de Fussion 
        /// </summary>
        public void Confirmation()
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand comand = db.GetStoredProcCommand("SPPQ_PRAX_SALES_ORDER.SPSP_CONFIRMATION");
                db.AddInParameter(comand, "P_LEGACY_COMPANY", DbType.Int32, this.LEGACY_COMPANY);
                db.AddInParameter(comand, "P_LEGACY_PREFIX", DbType.String, this.LEGACY_PREFIX);
                db.AddInParameter(comand, "P_LEGACY_CONSECUTIVE", DbType.String, this.LEGACY_CONSECUTIVE);
                db.AddInParameter(comand, "P_ORDER_TYPE", DbType.String, this.ORDER_TYPE);
                db.AddInParameter(comand, "P_INTERFACE_STATUS", DbType.String, this.INTERFACE_STATUS);
                db.ExecuteNonQuery(comand);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void ConfirmationDcto()
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand comand = db.GetStoredProcCommand("SPPQ_PRAX_SALES_ORDER.SPSP_CONFIRMATION_DCTO");
                db.AddInParameter(comand, "P_LEGACY_COMPANY", DbType.Int32, this.LEGACY_COMPANY);
                db.AddInParameter(comand, "P_LEGACY_PREFIX", DbType.String, this.LEGACY_PREFIX);
                db.AddInParameter(comand, "P_LEGACY_CONSECUTIVE", DbType.String, this.LEGACY_CONSECUTIVE);
                db.AddInParameter(comand, "P_ORDER_TYPE", DbType.String, this.ORDER_TYPE);
                db.AddInParameter(comand, "P_INTERFACE_STATUS", DbType.String, this.INTERFACE_STATUS);
                db.AddInParameter(comand, "P_sequence_aud", DbType.String, this.IDSTAGGING);
                db.ExecuteNonQuery(comand);
            }
            catch (Exception e)
            {
                throw e;
            }
        }





        
        /// <summary>
        /// Genera un listado con todos los registros por estado 
        /// </summary>
        /// <returns>Lista clsSalesOrder</returns>
        public List<clsSalesOrder> Get_SalesOrder()
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand selectcomand = db.GetStoredProcCommand("SPPQ_PRAX_SALES_ORDER.SPSP_FACTURA");
                db.AddInParameter(selectcomand, "P_INTERFACE_STATUS", DbType.String, this.INTERFACE_STATUS);

                List<clsSalesOrder> ListaDatos = new List<clsSalesOrder>();

                using (IDataReader dato = db.ExecuteReader(selectcomand))
                {
                    while (dato.Read())
                    {
                        ListaDatos.Add(new clsSalesOrder(int.Parse(dato.GetValue(0).ToString()), int.Parse(dato.GetValue(1).ToString()), dato.GetValue(2).ToString(), dato.GetValue(3).ToString(), dato.GetValue(4).ToString(), int.Parse(dato.GetValue(5).ToString()), dato.GetValue(6).ToString()));
                    }
                }

                return ListaDatos;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Permite generar el documento xml con toda la estructura de datos de Sales Order.
        /// </summary>
        /// <returns>DataSet con el conjunto de tablas</returns>
        public DataSet Get_ListaSalesOrder()
        {
            Database db = DatabaseFactory.CreateDatabase();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();

                try
                {
                    DataSet DsDatos = new DataSet("FACTURA");

                    DbCommand comandCabecera = db.GetStoredProcCommand("SPPQ_PRAX_SALES_ORDER.SPSP_ENCABEZADO_FACTURA");
                    db.AddInParameter(comandCabecera, "P_LEGACY_CONSECUTIVE", DbType.String, this.LEGACY_CONSECUTIVE);
                    db.AddInParameter(comandCabecera, "P_LEGACY_PREFIX", DbType.String, this.LEGACY_PREFIX);
                    db.AddInParameter(comandCabecera, "P_LEGACY_COMPANY", DbType.Int32, this.LEGACY_COMPANY);

                    DsDatos.Tables.Add("ENCABEZADO_FACTURA");
                    DsDatos.Tables[0].Merge(db.ExecuteDataSet(comandCabecera, transaction).Tables[0]);

                    

                    DbCommand comandDetalle = db.GetStoredProcCommand("SPPQ_PRAX_SALES_ORDER.SPSP_DETALLE_FACTURA");
                    db.AddInParameter(comandDetalle, "P_LEGACY_CONSECUTIVE", DbType.String, this.LEGACY_CONSECUTIVE);
                    db.AddInParameter(comandDetalle, "P_LEGACY_PREFIX", DbType.String, this.LEGACY_PREFIX);
                    db.AddInParameter(comandDetalle, "P_LEGACY_COMPANY", DbType.Int32, this.LEGACY_COMPANY);

                    DsDatos.Tables.Add("DETALLE_FACTURA");
                    DsDatos.Tables[1].Merge(db.ExecuteDataSet(comandDetalle, transaction).Tables[0]);

                    transaction.Commit();

                    return DsDatos;
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw e;
                }
            }
        }

        /// <summary>
        /// metodo con dcto
        /// </summary>
        /// <returns></returns>
        public DataSet Get_ListaSalesOrderDcto()
        {
            Database db = DatabaseFactory.CreateDatabase();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();

                try
                {
                    DataSet DsDatos = new DataSet("FACTURA");

                    DbCommand comandCabecera = db.GetStoredProcCommand("SPPQ_PRAX_SALES_ORDER.SPSP_ENCABEZADO_FACTURA_DCTO");
                    db.AddInParameter(comandCabecera, "P_LEGACY_CONSECUTIVE", DbType.String, this.LEGACY_CONSECUTIVE);
                    db.AddInParameter(comandCabecera, "P_LEGACY_PREFIX", DbType.String, this.LEGACY_PREFIX);
                    db.AddInParameter(comandCabecera, "P_LEGACY_COMPANY", DbType.Int32, this.LEGACY_COMPANY);
                    db.AddInParameter(comandCabecera, "P_DCTO", DbType.String, this.ORDER_TYPE);

                    DsDatos.Tables.Add("ENCABEZADO_FACTURA");
                    DsDatos.Tables[0].Merge(db.ExecuteDataSet(comandCabecera, transaction).Tables[0]);



                    DbCommand comandDetalle = db.GetStoredProcCommand("SPPQ_PRAX_SALES_ORDER.SPSP_DETALLE_FACTURA_DCTO");
                    db.AddInParameter(comandDetalle, "P_LEGACY_CONSECUTIVE", DbType.String, this.LEGACY_CONSECUTIVE);
                    db.AddInParameter(comandDetalle, "P_LEGACY_PREFIX", DbType.String, this.LEGACY_PREFIX);
                    db.AddInParameter(comandDetalle, "P_LEGACY_COMPANY", DbType.Int32, this.LEGACY_COMPANY);
                    db.AddInParameter(comandDetalle, "P_DCTO", DbType.String, this.ORDER_TYPE);

                    DsDatos.Tables.Add("DETALLE_FACTURA");
                    DsDatos.Tables[1].Merge(db.ExecuteDataSet(comandDetalle, transaction).Tables[0]);

                    transaction.Commit();

                    return DsDatos;
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw e;
                }
            }
        }

        /// <summary>
        /// metodo que obtiene la compañia apartir del codigo mcu de jde
        /// </summary>
        /// <returns></returns>
        public int Get_Cia(string mcu_jde)
        {

            Database db = DatabaseFactory.CreateDatabase();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();

                try
                {
                    DataSet DsDatos = new DataSet("EQUIVALENCIA");
                    int intCia = 0;

                    DbCommand comandCabecera = db.GetStoredProcCommand("SPPQ_PRAX_SALES_ORDER.SPSP_GETCOMPANYMCUJDE");
                    db.AddInParameter(comandCabecera, "PMCU_JDE", DbType.String, mcu_jde);

                    DsDatos.Tables.Add("CIA");
                    DsDatos.Tables[0].Merge(db.ExecuteDataSet(comandCabecera, transaction).Tables[0]);

                    transaction.Commit();


                    if (DsDatos.Tables[0].Rows.Count > 0)
                    {
                        intCia = int.Parse(DsDatos.Tables[0].Rows[0][0].ToString());
                    }

                    return intCia;
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw e;
                }
            }

        }


        /// <summary>
        /// Metodo que valida que el MCU (sucursal) se encuentra en la base de datos de jde
        /// </summary>
        /// <param name="IBMCU">codigo jde de la sucursal</param>
        /// <returns></returns>
        public int Get_ScrValida(int IBMCU)
        {

            Database db = DatabaseFactory.CreateDatabase();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();

                try
                {
                    DataSet DsDatos = new DataSet("SUCURSALJDE");
                    int intScr = 0;

                    DbCommand comandCabecera = db.GetStoredProcCommand("SPPQ_PRAX_SALES_ORDER.SPSP_GET_SCR_JDE");
                    db.AddInParameter(comandCabecera, "IBMCU", DbType.Int32, IBMCU);

                    DsDatos.Tables.Add("SUCURSAL");
                    DsDatos.Tables[0].Merge(db.ExecuteDataSet(comandCabecera, transaction).Tables[0]);

                    transaction.Commit();


                    if (DsDatos.Tables[0].Rows.Count > 0)
                    {
                        intScr = int.Parse(DsDatos.Tables[0].Rows[0][0].ToString());
                    }

                    return intScr;
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw e;
                }
            }

        }


    }
}
