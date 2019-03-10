using System;
using System.ComponentModel.DataAnnotations;

namespace WebApiSample.DemoApi.Data.Models
{
    public class ToDoDatabaseModel
    {
        [Required]
        public string Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string Title { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        [Required]
        public bool IsDone { get; set; }
    }
}