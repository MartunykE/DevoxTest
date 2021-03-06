﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DevoxTestTask.DataAccess.Models
{
    public class Project
    {
        public Project()
        {
            EmployeeActivites = new List<EmployeeActivity>();
        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<EmployeeActivity> EmployeeActivites { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
