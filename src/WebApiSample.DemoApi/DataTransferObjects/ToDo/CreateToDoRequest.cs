﻿using System;
using System.ComponentModel.DataAnnotations;

namespace WebApiSample.DemoApi.DataTransferObjects.ToDo
{
    public class CreateToDoRequest
    {
        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string Title { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        public DateTime CreateDate { get; set; }

        public bool IsDone { get; set; }
    }
}