using System;
using System.ComponentModel.DataAnnotations;

namespace CustomerAccessControl.Models
{
    public class Entry
    {
        [Key]
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int CenterId { get; set; }
        public DateTime EntryDate { get; set; }
    }
}

