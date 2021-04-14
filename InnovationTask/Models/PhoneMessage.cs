using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InnovationTask.Models
{
    public class PhoneMessage
    {
        public int ID { get; set; }
        
        [DataType(DataType.MultilineText)]
        public string message { get; set; }
        [Required]
        public string phoneNumber { get; set; }

    }
}
