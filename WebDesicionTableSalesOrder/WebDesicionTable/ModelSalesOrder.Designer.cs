﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;

[assembly: EdmSchemaAttribute()]
namespace WebDesicionTable
{
    #region Contextos
    
    /// <summary>
    /// No hay documentación de metadatos disponible.
    /// </summary>
    public partial class strConexion : ObjectContext
    {
        #region Constructores
    
        /// <summary>
        /// Inicializa un nuevo objeto strConexion usando la cadena de conexión encontrada en la sección 'strConexion' del archivo de configuración de la aplicación.
        /// </summary>
        public strConexion() : base("name=strConexion", "strConexion")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Inicializar un nuevo objeto strConexion.
        /// </summary>
        public strConexion(string connectionString) : base(connectionString, "strConexion")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Inicializar un nuevo objeto strConexion.
        /// </summary>
        public strConexion(EntityConnection connection) : base(connection, "strConexion")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Métodos parciales
    
        partial void OnContextCreated();
    
        #endregion
    
        #region Propiedades de ObjectSet
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        public ObjectSet<SPH_DECISION_TABLE> SPH_DECISION_TABLE
        {
            get
            {
                if ((_SPH_DECISION_TABLE == null))
                {
                    _SPH_DECISION_TABLE = base.CreateObjectSet<SPH_DECISION_TABLE>("SPH_DECISION_TABLE");
                }
                return _SPH_DECISION_TABLE;
            }
        }
        private ObjectSet<SPH_DECISION_TABLE> _SPH_DECISION_TABLE;

        #endregion

        #region Métodos AddTo
    
        /// <summary>
        /// Método desusado para agregar un nuevo objeto al EntitySet SPH_DECISION_TABLE. Considere la posibilidad de usar el método .Add de la propiedad ObjectSet&lt;T&gt; asociada.
        /// </summary>
        public void AddToSPH_DECISION_TABLE(SPH_DECISION_TABLE sPH_DECISION_TABLE)
        {
            base.AddObject("SPH_DECISION_TABLE", sPH_DECISION_TABLE);
        }

        #endregion

    }

    #endregion

    #region Entidades
    
    /// <summary>
    /// No hay documentación de metadatos disponible.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="SalesOrderModel", Name="SPH_DECISION_TABLE")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class SPH_DECISION_TABLE : EntityObject
    {
        #region Método de generador
    
        /// <summary>
        /// Crear un nuevo objeto SPH_DECISION_TABLE.
        /// </summary>
        /// <param name="iD_COMPANY">Valor inicial de la propiedad ID_COMPANY.</param>
        /// <param name="aPPLICATION">Valor inicial de la propiedad APPLICATION.</param>
        /// <param name="cUSTOMER_TYPE">Valor inicial de la propiedad CUSTOMER_TYPE.</param>
        /// <param name="tRANSACTION_TYPE">Valor inicial de la propiedad TRANSACTION_TYPE.</param>
        /// <param name="tYPE_APPROVAL">Valor inicial de la propiedad TYPE_APPROVAL.</param>
        /// <param name="tYPE_CREDIT_NOTE">Valor inicial de la propiedad TYPE_CREDIT_NOTE.</param>
        /// <param name="bILL_REFER">Valor inicial de la propiedad BILL_REFER.</param>
        /// <param name="rELATED_REFERRALS">Valor inicial de la propiedad RELATED_REFERRALS.</param>
        /// <param name="pROFORMA_INVOICE">Valor inicial de la propiedad PROFORMA_INVOICE.</param>
        /// <param name="rESULT">Valor inicial de la propiedad RESULT.</param>
        /// <param name="tRIGGER_TABLE">Valor inicial de la propiedad TRIGGER_TABLE.</param>
        /// <param name="aCTION">Valor inicial de la propiedad ACTION.</param>
        /// <param name="aNULA">Valor inicial de la propiedad ANULA.</param>
        /// <param name="iD_DESICION_TABLE">Valor inicial de la propiedad ID_DESICION_TABLE.</param>
        public static SPH_DECISION_TABLE CreateSPH_DECISION_TABLE(global::System.Int16 iD_COMPANY, global::System.String aPPLICATION, global::System.String cUSTOMER_TYPE, global::System.String tRANSACTION_TYPE, global::System.String tYPE_APPROVAL, global::System.String tYPE_CREDIT_NOTE, global::System.String bILL_REFER, global::System.String rELATED_REFERRALS, global::System.String pROFORMA_INVOICE, global::System.String rESULT, global::System.String tRIGGER_TABLE, global::System.String aCTION, global::System.String aNULA, global::System.Decimal iD_DESICION_TABLE)
        {
            SPH_DECISION_TABLE sPH_DECISION_TABLE = new SPH_DECISION_TABLE();
            sPH_DECISION_TABLE.ID_COMPANY = iD_COMPANY;
            sPH_DECISION_TABLE.APPLICATION = aPPLICATION;
            sPH_DECISION_TABLE.CUSTOMER_TYPE = cUSTOMER_TYPE;
            sPH_DECISION_TABLE.TRANSACTION_TYPE = tRANSACTION_TYPE;
            sPH_DECISION_TABLE.TYPE_APPROVAL = tYPE_APPROVAL;
            sPH_DECISION_TABLE.TYPE_CREDIT_NOTE = tYPE_CREDIT_NOTE;
            sPH_DECISION_TABLE.BILL_REFER = bILL_REFER;
            sPH_DECISION_TABLE.RELATED_REFERRALS = rELATED_REFERRALS;
            sPH_DECISION_TABLE.PROFORMA_INVOICE = pROFORMA_INVOICE;
            sPH_DECISION_TABLE.RESULT = rESULT;
            sPH_DECISION_TABLE.TRIGGER_TABLE = tRIGGER_TABLE;
            sPH_DECISION_TABLE.ACTION = aCTION;
            sPH_DECISION_TABLE.ANULA = aNULA;
            sPH_DECISION_TABLE.ID_DESICION_TABLE = iD_DESICION_TABLE;
            return sPH_DECISION_TABLE;
        }

        #endregion

        #region Propiedades primitivas
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int16 ID_COMPANY
        {
            get
            {
                return _ID_COMPANY;
            }
            set
            {
                OnID_COMPANYChanging(value);
                ReportPropertyChanging("ID_COMPANY");
                _ID_COMPANY = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("ID_COMPANY");
                OnID_COMPANYChanged();
            }
        }
        private global::System.Int16 _ID_COMPANY;
        partial void OnID_COMPANYChanging(global::System.Int16 value);
        partial void OnID_COMPANYChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String APPLICATION
        {
            get
            {
                return _APPLICATION;
            }
            set
            {
                OnAPPLICATIONChanging(value);
                ReportPropertyChanging("APPLICATION");
                _APPLICATION = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("APPLICATION");
                OnAPPLICATIONChanged();
            }
        }
        private global::System.String _APPLICATION;
        partial void OnAPPLICATIONChanging(global::System.String value);
        partial void OnAPPLICATIONChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String CUSTOMER_TYPE
        {
            get
            {
                return _CUSTOMER_TYPE;
            }
            set
            {
                OnCUSTOMER_TYPEChanging(value);
                ReportPropertyChanging("CUSTOMER_TYPE");
                _CUSTOMER_TYPE = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("CUSTOMER_TYPE");
                OnCUSTOMER_TYPEChanged();
            }
        }
        private global::System.String _CUSTOMER_TYPE;
        partial void OnCUSTOMER_TYPEChanging(global::System.String value);
        partial void OnCUSTOMER_TYPEChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String TRANSACTION_TYPE
        {
            get
            {
                return _TRANSACTION_TYPE;
            }
            set
            {
                OnTRANSACTION_TYPEChanging(value);
                ReportPropertyChanging("TRANSACTION_TYPE");
                _TRANSACTION_TYPE = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("TRANSACTION_TYPE");
                OnTRANSACTION_TYPEChanged();
            }
        }
        private global::System.String _TRANSACTION_TYPE;
        partial void OnTRANSACTION_TYPEChanging(global::System.String value);
        partial void OnTRANSACTION_TYPEChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String TYPE_APPROVAL
        {
            get
            {
                return _TYPE_APPROVAL;
            }
            set
            {
                OnTYPE_APPROVALChanging(value);
                ReportPropertyChanging("TYPE_APPROVAL");
                _TYPE_APPROVAL = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("TYPE_APPROVAL");
                OnTYPE_APPROVALChanged();
            }
        }
        private global::System.String _TYPE_APPROVAL;
        partial void OnTYPE_APPROVALChanging(global::System.String value);
        partial void OnTYPE_APPROVALChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String TYPE_CREDIT_NOTE
        {
            get
            {
                return _TYPE_CREDIT_NOTE;
            }
            set
            {
                OnTYPE_CREDIT_NOTEChanging(value);
                ReportPropertyChanging("TYPE_CREDIT_NOTE");
                _TYPE_CREDIT_NOTE = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("TYPE_CREDIT_NOTE");
                OnTYPE_CREDIT_NOTEChanged();
            }
        }
        private global::System.String _TYPE_CREDIT_NOTE;
        partial void OnTYPE_CREDIT_NOTEChanging(global::System.String value);
        partial void OnTYPE_CREDIT_NOTEChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String BILL_REFER
        {
            get
            {
                return _BILL_REFER;
            }
            set
            {
                OnBILL_REFERChanging(value);
                ReportPropertyChanging("BILL_REFER");
                _BILL_REFER = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("BILL_REFER");
                OnBILL_REFERChanged();
            }
        }
        private global::System.String _BILL_REFER;
        partial void OnBILL_REFERChanging(global::System.String value);
        partial void OnBILL_REFERChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String RELATED_REFERRALS
        {
            get
            {
                return _RELATED_REFERRALS;
            }
            set
            {
                OnRELATED_REFERRALSChanging(value);
                ReportPropertyChanging("RELATED_REFERRALS");
                _RELATED_REFERRALS = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("RELATED_REFERRALS");
                OnRELATED_REFERRALSChanged();
            }
        }
        private global::System.String _RELATED_REFERRALS;
        partial void OnRELATED_REFERRALSChanging(global::System.String value);
        partial void OnRELATED_REFERRALSChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String PROFORMA_INVOICE
        {
            get
            {
                return _PROFORMA_INVOICE;
            }
            set
            {
                OnPROFORMA_INVOICEChanging(value);
                ReportPropertyChanging("PROFORMA_INVOICE");
                _PROFORMA_INVOICE = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("PROFORMA_INVOICE");
                OnPROFORMA_INVOICEChanged();
            }
        }
        private global::System.String _PROFORMA_INVOICE;
        partial void OnPROFORMA_INVOICEChanging(global::System.String value);
        partial void OnPROFORMA_INVOICEChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String RESULT
        {
            get
            {
                return _RESULT;
            }
            set
            {
                OnRESULTChanging(value);
                ReportPropertyChanging("RESULT");
                _RESULT = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("RESULT");
                OnRESULTChanged();
            }
        }
        private global::System.String _RESULT;
        partial void OnRESULTChanging(global::System.String value);
        partial void OnRESULTChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String TRIGGER_TABLE
        {
            get
            {
                return _TRIGGER_TABLE;
            }
            set
            {
                OnTRIGGER_TABLEChanging(value);
                ReportPropertyChanging("TRIGGER_TABLE");
                _TRIGGER_TABLE = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("TRIGGER_TABLE");
                OnTRIGGER_TABLEChanged();
            }
        }
        private global::System.String _TRIGGER_TABLE;
        partial void OnTRIGGER_TABLEChanging(global::System.String value);
        partial void OnTRIGGER_TABLEChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String ACTION
        {
            get
            {
                return _ACTION;
            }
            set
            {
                OnACTIONChanging(value);
                ReportPropertyChanging("ACTION");
                _ACTION = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("ACTION");
                OnACTIONChanged();
            }
        }
        private global::System.String _ACTION;
        partial void OnACTIONChanging(global::System.String value);
        partial void OnACTIONChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String ANULA
        {
            get
            {
                return _ANULA;
            }
            set
            {
                OnANULAChanging(value);
                ReportPropertyChanging("ANULA");
                _ANULA = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("ANULA");
                OnANULAChanged();
            }
        }
        private global::System.String _ANULA;
        partial void OnANULAChanging(global::System.String value);
        partial void OnANULAChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Decimal ID_DESICION_TABLE
        {
            get
            {
                return _ID_DESICION_TABLE;
            }
            set
            {
                if (_ID_DESICION_TABLE != value)
                {
                    OnID_DESICION_TABLEChanging(value);
                    ReportPropertyChanging("ID_DESICION_TABLE");
                    _ID_DESICION_TABLE = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("ID_DESICION_TABLE");
                    OnID_DESICION_TABLEChanged();
                }
            }
        }
        private global::System.Decimal _ID_DESICION_TABLE;
        partial void OnID_DESICION_TABLEChanging(global::System.Decimal value);
        partial void OnID_DESICION_TABLEChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String FINANCIAL_MEMO_NOTE
        {
            get
            {
                return _FINANCIAL_MEMO_NOTE;
            }
            set
            {
                OnFINANCIAL_MEMO_NOTEChanging(value);
                ReportPropertyChanging("FINANCIAL_MEMO_NOTE");
                _FINANCIAL_MEMO_NOTE = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("FINANCIAL_MEMO_NOTE");
                OnFINANCIAL_MEMO_NOTEChanged();
            }
        }
        private global::System.String _FINANCIAL_MEMO_NOTE;
        partial void OnFINANCIAL_MEMO_NOTEChanging(global::System.String value);
        partial void OnFINANCIAL_MEMO_NOTEChanged();

        #endregion

    
    }

    #endregion

    
}