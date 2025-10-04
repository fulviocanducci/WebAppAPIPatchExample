using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace WebAppAPIPatchExample.Models
{
    public class People
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome completo.")]
        [MaxLength(100, ErrorMessage = "Número máximo de caracteres: 100.")]
        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Digite true ou false")]
        [AllowedValues(true, false, ErrorMessage = "Digite true ou false.")]
        [JsonProperty("status")]
        public bool Status { get; set; }
    }
}
