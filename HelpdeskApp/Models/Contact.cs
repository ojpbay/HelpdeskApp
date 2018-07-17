using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpdeskApp.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public List<DataItem> DataItems { get; set; }
    }
}
