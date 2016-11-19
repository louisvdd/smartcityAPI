using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Service
    {
        public long Id { get; set; }
        public string DescriptionService { get; set; }
        public CategoryService Category { get; set; }
        public DateTime DateService { get; set; }
    }
}
