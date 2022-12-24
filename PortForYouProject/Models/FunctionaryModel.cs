using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PortForYouProject.Models
{
    public class FunctionaryModel
    {
        [Required, MaxLength(255)]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [Required, MaxLength(100)]
        [JsonPropertyName("ocuppation")]
        public string Ocuppation { get; set; }
    }
}
