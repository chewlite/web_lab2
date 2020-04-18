using System;
using System.ComponentModel.DataAnnotations;

namespace MvcH.Models
{
    public class Hospital
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}