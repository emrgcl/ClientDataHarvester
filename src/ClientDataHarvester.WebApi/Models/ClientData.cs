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
        public string? ClientName { get; set; }

        [Required]
        public string? DataType { get; set; }

        [Required]
        public string? JSONData { get; set; }
    }
}
