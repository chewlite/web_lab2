using System;
using System.ComponentModel.DataAnnotations;

namespace MvcH.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        [DataType(DataType.Date)]
        public DateTime AdmissionDate { get; set; }
    }
}