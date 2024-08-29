using System;
using System.Collections.Generic;

namespace Domain.ViewModels
{
    public class MastersList
    {
        public long Id { get; set; } // Assuming you have an Id property in your base class or entity
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public bool? IsActive { get; set; }
    }
}
