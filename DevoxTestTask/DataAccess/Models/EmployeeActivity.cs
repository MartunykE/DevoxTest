using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DevoxTestTask.DataAccess.Models
{
    public class EmployeeActivity
    {
       // public int Id { get; set; }
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
        public Role Role { get; set; }
        public ActivityType ActivityType { get; set; }
        public Project Project { get; set; }
        public int ProjectId { get; set; }
        public DateTime Date { get; set; }
        
        public double Hours { get; set; }
    }
}
