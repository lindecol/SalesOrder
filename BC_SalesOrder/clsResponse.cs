using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
 
namespace WCF_SalesOrder
{
    /// <summary>
    /// clase de respuesta para resultado de insersion
    /// </summary>   
    [DataContract(Namespace = "http://www.praxair.com.co/SalesOrder", Name = "clsResponse")]
    public class clsResponse
    {
        /// <summary>
        /// tipo de mensaje, error, y resultado de la transaccion
        /// </summary>
        [DataMember]
        public string TypeDesc { get; set; } 
        /// <summary>
        /// mensaje de la operacion
        /// </summary>
         [DataMember]
        public string MessageDesc { get; set; }   
    }
}