using System.ComponentModel.DataAnnotations;

namespace CustomerAccessControl.Models
{
    public class Center
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

