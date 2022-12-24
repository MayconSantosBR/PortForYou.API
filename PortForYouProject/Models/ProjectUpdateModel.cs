using PortForYouProject.Models.Enuns;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PortForYouProject.Models
{
    public class ProjectUpdateModel
    {
        [Required, MaxLength(255)]
        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [Required, MaxLength(255)]
        [JsonPropertyName("manager")]
        public string Manager { get; set; } = null!;

        [Required]
        [JsonPropertyName("status")]
        public Status Status { get; set; } = 0!;

        [Required]
        [JsonPropertyName("risk")]
        public Risk Risk { get; set; } = 0!;

        [JsonPropertyName("startDate")]
        public DateTime? StartDate { get; set; }

        [Required]
        [JsonPropertyName("estimatedDate")]
        public DateTime EstimatedDate { get; set; }

        [JsonPropertyName("finishDate")]
        public DateTime? FinishDate { get; set; }

        [JsonPropertyName("totalBudget")]
        public double? TotalBudget { get; set; }

        [JsonPropertyName("idFuncionaries")]
        public List<int> IdFuncionaries { get; set; }
    }
}
