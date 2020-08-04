﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevoxTestTask.DataAccess.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<EmployeeActivity> EmployeeActivites { get; set; }                
    }
}