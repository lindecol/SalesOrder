﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WCF_SalesOrder.ServicioSalesOrder {
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18408")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://praxair.com/PraxairBusinessFault")]
    public partial class PraxairBusinessFault : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string codeField;
        
        private string detailField;
        
        private string summaryField;
        
        private StackFault[] stackFaultField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string code {
            get {
                return this.codeField;
            }
            set {
                this.codeField = value;
                this.RaisePropertyChanged("code");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string detail {
            get {
                return this.detailField;
            }
            set {
                this.detailField = value;
                this.RaisePropertyChanged("detail");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string summary {
            get {
                return this.summaryField;
            }
            set {
                this.summaryField = value;
                this.RaisePropertyChanged("summary");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("StackFault", Order=3)]
        public StackFault[] StackFault {
            get {
                return this.stackFaultField;
            }
            set {
                this.stackFaultField = value;
                this.RaisePropertyChanged("StackFault");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18408")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://praxair.com/PraxairBusinessFault")]
    public partial class StackFault : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string codeField;
        
        private string messageField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string code {
            get {
                return this.codeField;
            }
            set {
                this.codeField = value;
                this.RaisePropertyChanged("code");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string message {
            get {
                return this.messageField;
            }
            set {
                this.messageField = value;
                this.RaisePropertyChanged("message");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://praxair.com/PraxairBusinessFault", ConfigurationName="ServicioSalesOrder.PraxairBusinessFaultPortType")]
    public interface PraxairBusinessFaultPortType {
        
        // CODEGEN: Generating message contract since the operation process is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="process", ReplyAction="*")]
        [System.ServiceModel.FaultContractAttribute(typeof(WCF_SalesOrder.ServicioSalesOrder.PraxairBusinessFault), Action="process", Name="PraxairBusinessFault")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        WCF_SalesOrder.ServicioSalesOrder.processRequest process(WCF_SalesOrder.ServicioSalesOrder.processRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class processRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://praxair.com/PraxairBusinessFault", Order=0)]
        public WCF_SalesOrder.ServicioSalesOrder.PraxairBusinessFault PraxairBusinessFault;
        
        public processRequest() {
        }
        
        public processRequest(WCF_SalesOrder.ServicioSalesOrder.PraxairBusinessFault PraxairBusinessFault) {
            this.PraxairBusinessFault = PraxairBusinessFault;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface PraxairBusinessFaultPortTypeChannel : WCF_SalesOrder.ServicioSalesOrder.PraxairBusinessFaultPortType, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class PraxairBusinessFaultPortTypeClient : System.ServiceModel.ClientBase<WCF_SalesOrder.ServicioSalesOrder.PraxairBusinessFaultPortType>, WCF_SalesOrder.ServicioSalesOrder.PraxairBusinessFaultPortType {
        
        public PraxairBusinessFaultPortTypeClient() {
        }
        
        public PraxairBusinessFaultPortTypeClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public PraxairBusinessFaultPortTypeClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PraxairBusinessFaultPortTypeClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PraxairBusinessFaultPortTypeClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        WCF_SalesOrder.ServicioSalesOrder.processRequest WCF_SalesOrder.ServicioSalesOrder.PraxairBusinessFaultPortType.process(WCF_SalesOrder.ServicioSalesOrder.processRequest request) {
            return base.Channel.process(request);
        }
        
        public void process(ref WCF_SalesOrder.ServicioSalesOrder.PraxairBusinessFault PraxairBusinessFault) {
            WCF_SalesOrder.ServicioSalesOrder.processRequest inValue = new WCF_SalesOrder.ServicioSalesOrder.processRequest();
            inValue.PraxairBusinessFault = PraxairBusinessFault;
            WCF_SalesOrder.ServicioSalesOrder.processRequest retVal = ((WCF_SalesOrder.ServicioSalesOrder.PraxairBusinessFaultPortType)(this)).process(inValue);
            PraxairBusinessFault = retVal.PraxairBusinessFault;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://xmlns.oracle.com/ABCSImpl/JDEE1/Core/CreateSalesOrderPraxReqABCSImpl/V1", ConfigurationName="ServicioSalesOrder.CreateSalesOrderPraxReqABCSImpl")]
    public interface CreateSalesOrderPraxReqABCSImpl {
        
        // CODEGEN: Generating message contract since the operation CreateSalesOrder is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="CreateSalesOrder")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        void CreateSalesOrder(WCF_SalesOrder.ServicioSalesOrder.CreateSalesOrder request);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18408")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.praxair.com.co/createsalesorder")]
    public partial class SalesOrder : object, System.ComponentModel.INotifyPropertyChanged {
        
        private SalesOrderHeader headerField;
        
        private Detail[] detailsField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public SalesOrderHeader Header {
            get {
                return this.headerField;
            }
            set {
                this.headerField = value;
                this.RaisePropertyChanged("Header");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=1)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable=false)]
        public Detail[] Details {
            get {
                return this.detailsField;
            }
            set {
                this.detailsField = value;
                this.RaisePropertyChanged("Details");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18408")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.praxair.com.co/createsalesorder")]
    public partial class SalesOrderHeader : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string dCTOField;
        
        private string mCUField;
        
        private int aN8Field;
        
        private int sHANField;
        
        private string cRCDField;
        
        private System.DateTime tRDJField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string DCTO {
            get {
                return this.dCTOField;
            }
            set {
                this.dCTOField = value;
                this.RaisePropertyChanged("DCTO");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string MCU {
            get {
                return this.mCUField;
            }
            set {
                this.mCUField = value;
                this.RaisePropertyChanged("MCU");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public int AN8 {
            get {
                return this.aN8Field;
            }
            set {
                this.aN8Field = value;
                this.RaisePropertyChanged("AN8");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public int SHAN {
            get {
                return this.sHANField;
            }
            set {
                this.sHANField = value;
                this.RaisePropertyChanged("SHAN");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string CRCD {
            get {
                return this.cRCDField;
            }
            set {
                this.cRCDField = value;
                this.RaisePropertyChanged("CRCD");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", Order=5)]
        public System.DateTime TRDJ {
            get {
                return this.tRDJField;
            }
            set {
                this.tRDJField = value;
                this.RaisePropertyChanged("TRDJ");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18408")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.praxair.com.co/createsalesorder")]
    public partial class Detail : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string mCUField;
        
        private int sHANField;
        
        private string vR01Field;
        
        private string vR02Field;
        
        private string lOTNField;
        
        private string eMCUField;
        
        private decimal uORGField;
        
        private decimal aEXPField;
        
        private decimal uRATField;
        
        private Item itemField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string MCU {
            get {
                return this.mCUField;
            }
            set {
                this.mCUField = value;
                this.RaisePropertyChanged("MCU");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public int SHAN {
            get {
                return this.sHANField;
            }
            set {
                this.sHANField = value;
                this.RaisePropertyChanged("SHAN");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string VR01 {
            get {
                return this.vR01Field;
            }
            set {
                this.vR01Field = value;
                this.RaisePropertyChanged("VR01");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string VR02 {
            get {
                return this.vR02Field;
            }
            set {
                this.vR02Field = value;
                this.RaisePropertyChanged("VR02");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string LOTN {
            get {
                return this.lOTNField;
            }
            set {
                this.lOTNField = value;
                this.RaisePropertyChanged("LOTN");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string EMCU {
            get {
                return this.eMCUField;
            }
            set {
                this.eMCUField = value;
                this.RaisePropertyChanged("EMCU");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public decimal UORG {
            get {
                return this.uORGField;
            }
            set {
                this.uORGField = value;
                this.RaisePropertyChanged("UORG");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public decimal AEXP {
            get {
                return this.aEXPField;
            }
            set {
                this.aEXPField = value;
                this.RaisePropertyChanged("AEXP");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public decimal URAT {
            get {
                return this.uRATField;
            }
            set {
                this.uRATField = value;
                this.RaisePropertyChanged("URAT");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public Item Item {
            get {
                return this.itemField;
            }
            set {
                this.itemField = value;
                this.RaisePropertyChanged("Item");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18408")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.praxair.com.co/createsalesorder")]
    public partial class Item : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string iTMField;
        
        private string lITMField;
        
        private string uOMField;
        
        private string sKTKField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string ITM {
            get {
                return this.iTMField;
            }
            set {
                this.iTMField = value;
                this.RaisePropertyChanged("ITM");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string LITM {
            get {
                return this.lITMField;
            }
            set {
                this.lITMField = value;
                this.RaisePropertyChanged("LITM");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string UOM {
            get {
                return this.uOMField;
            }
            set {
                this.uOMField = value;
                this.RaisePropertyChanged("UOM");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string SKTK {
            get {
                return this.sKTKField;
            }
            set {
                this.sKTKField = value;
                this.RaisePropertyChanged("SKTK");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class CreateSalesOrder {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.praxair.com.co/createsalesorder", Order=0)]
        public WCF_SalesOrder.ServicioSalesOrder.SalesOrder SalesOrder;
        
        public CreateSalesOrder() {
        }
        
        public CreateSalesOrder(WCF_SalesOrder.ServicioSalesOrder.SalesOrder SalesOrder) {
            this.SalesOrder = SalesOrder;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface CreateSalesOrderPraxReqABCSImplChannel : WCF_SalesOrder.ServicioSalesOrder.CreateSalesOrderPraxReqABCSImpl, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CreateSalesOrderPraxReqABCSImplClient : System.ServiceModel.ClientBase<WCF_SalesOrder.ServicioSalesOrder.CreateSalesOrderPraxReqABCSImpl>, WCF_SalesOrder.ServicioSalesOrder.CreateSalesOrderPraxReqABCSImpl {
        
        public CreateSalesOrderPraxReqABCSImplClient() {
        }
        
        public CreateSalesOrderPraxReqABCSImplClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CreateSalesOrderPraxReqABCSImplClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CreateSalesOrderPraxReqABCSImplClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CreateSalesOrderPraxReqABCSImplClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        void WCF_SalesOrder.ServicioSalesOrder.CreateSalesOrderPraxReqABCSImpl.CreateSalesOrder(WCF_SalesOrder.ServicioSalesOrder.CreateSalesOrder request) {
            base.Channel.CreateSalesOrder(request);
        }
        
        public void CreateSalesOrder(WCF_SalesOrder.ServicioSalesOrder.SalesOrder SalesOrder) {
            WCF_SalesOrder.ServicioSalesOrder.CreateSalesOrder inValue = new WCF_SalesOrder.ServicioSalesOrder.CreateSalesOrder();
            inValue.SalesOrder = SalesOrder;
            ((WCF_SalesOrder.ServicioSalesOrder.CreateSalesOrderPraxReqABCSImpl)(this)).CreateSalesOrder(inValue);
        }
    }
}