using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientDataHarvester.WebApi.Models
{
    public class ClientData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(255)]
        public string? ClientName { get; set; }

        [Required]
        [MaxLength(255)]
        public string? DataType { get; set; }

        [Required]
        public string? JSONData { get; set; }

        public DateTime TimeAdded { get; set; } = DateTime.UtcNow;

    }
}
