using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelpdeskApp.Models.ViewModels
{
    public class CreateViewModel
    {
        [Required]
        public string Description { get; set; }

        [Required]
        public int ContactId { get; set; }

        [Required]
        public int AssignmentGroupId { get; set; }

        public List<Contact> Contacts { get; set; }
        
        public List<AssignmentGroup> AssignmentGroups { get; set; }
    }
}
