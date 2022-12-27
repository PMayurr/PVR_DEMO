using System;
using System.ComponentModel.DataAnnotations;

namespace PVR.Models
{
    public class Movie
    {
        
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Screen { get; set; }
        public bool isDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime MovieDateTime { get; set; }

    }
}