using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeBookWebApp.Models;

public class Recipe
{
    public int Id { get; set; }

    [Required]
    [StringLength(150)]
    public string Title { get; set; } = string.Empty;

    [StringLength(100)]
    public string? Category { get; set; }

    [Range(1, 100)]
    public int Servings { get; set; } = 4;

    [Display(Name = "Prep Time (minutes)")]
    [Range(0, 1440)]
    public int PrepTimeMinutes { get; set; }

    [Display(Name = "Cook Time (minutes)")]
    [Range(0, 1440)]
    public int CookTimeMinutes { get; set; }

    [Required]
    [Display(Name = "Ingredients & Measurements")]
    public string Ingredients { get; set; } = string.Empty;

    [Required]
    public string Instructions { get; set; } = string.Empty;

    public string? Notes { get; set; }

    [Display(Name = "Source / URL")]
    public string? Source { get; set; }

    [Display(Name = "Created")]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    [NotMapped]
    public int TotalTimeMinutes => PrepTimeMinutes + CookTimeMinutes;
}
