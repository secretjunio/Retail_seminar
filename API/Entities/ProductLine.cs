using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Entities
{
    public class ProductLine
    {
        [Key]
        public string product_line_id { get; set; }
        public string name { get; set; }
        public string price { get; set; }
        public string stock { get; set; }
    }
}
