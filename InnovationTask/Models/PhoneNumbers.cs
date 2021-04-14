using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InnovationTask.Models
{
    public class PhoneNumbers
    {
        public int ID { get; set; }
        [Required]
        [StringLength(11)]
        public string PhoneNumber { get; set; }
    }
}
