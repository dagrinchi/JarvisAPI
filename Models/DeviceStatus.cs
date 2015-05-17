using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jarvis.Models
{

    [DataContract]
    public class DeviceStatus
    {

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        [Required]
        public String Identification { get; set; }

        [DataMember]
        [Required]
        public int Status { get; set; }

        [Required]
        [DataMember]
        public int Created { get; set; }

    }
}