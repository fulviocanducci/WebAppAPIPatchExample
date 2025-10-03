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

        [Required(ErrorMessage = "Digite o sexo M para masculino e F para feminino.")]
        [MaxLength(1, ErrorMessage = "Número máximo de caracteres: 1.")]
        [AllowedValues("M", "F", ErrorMessage = "Escolhe M ou F")]
        [JsonProperty("sex")]
        public string Sex { get; set; } = string.Empty; // m ou f

        [JsonProperty("sexDescription")]
        public string SexDescription
        {
            get
            {
                return string.Equals(Sex, "M", StringComparison.OrdinalIgnoreCase) 
                    ? "Masculino" 
                    : "Feminino";
            }
        }
    }
}
