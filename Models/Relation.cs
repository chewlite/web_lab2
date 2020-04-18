using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MvcH.Models
{
    public class Relation
    {
        [Key]
        [ForeignKey("Patient")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Patient")]
        public int PatientID { get; set; }
        public virtual Patient Patient { get; set; }

        [ForeignKey("Hospital")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Hospital")]
        public int HospitalID { get; set; }
        public virtual Hospital Hospital { get; set; }

        [ForeignKey("Room")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Room")]
        public int RoomID { get; set; }
        public virtual Room Room { get; set; }

        [ForeignKey("Doctor")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Doctor")]
        public int DoctorID { get; set; }
        public virtual Doctor Doctor { get; set; }
    }
}