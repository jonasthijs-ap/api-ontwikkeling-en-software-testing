﻿using ApiOntwikkelingProject.Entities.Properties;
using System.ComponentModel.DataAnnotations;

namespace ApiOntwikkelingProject.ViewModels
{
    public class CampingCreateViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public Address Address { get; set; }
    }
}