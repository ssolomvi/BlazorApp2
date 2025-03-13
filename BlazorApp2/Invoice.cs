using System.ComponentModel.DataAnnotations;

namespace BlazorApp2;

public class Invoice
{
    [Required(ErrorMessage = "Price required.")]
    [Range(60, 500, ErrorMessage = "Price should be between 60 and 500.")]
    public decimal? Price { get; set; } = 232M;

    [Range(0, 50, ErrorMessage = "Discount should be between 0 and 50.")]
    public decimal? Discount { get; set; }

    [Required(ErrorMessage = "Amount required.")]
    [Range(10, 500, ErrorMessage = "Total should be between 60 and 500.")]
    public decimal? Total { get; set; }
}