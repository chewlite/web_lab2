using System;
using System.ComponentModel.DataAnnotations;

namespace MvcH.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }
        public SpecialtyEnum Specialty { get; set; }
    }

    public enum SpecialtyEnum {
        Therapist,
        Surgeon,
        Dentist,
        Gynecologist,
        Endocrinologist,
        Neurologist
    }
}