using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpdeskApp.Models
{
    public class DataItem
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int ContactId { get; set; }
        public Contact Contact { get; set; }
        public int AssignmentGroupId { get; set; }
        public AssignmentGroup AssignmentGroup { get; set; }
    }
}
