using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class TagReader
    {
        [Key]
        public string TagUii { get; set; }
        public string TagRssi { get; set; }
        public int Number { get; set; }
    }
}
