using Pax_AC_Design.ModuleCalculate.Request;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp2.Pages.dto;

public record RequestEngineDto()
{

    [Display(Name = "Тип двигателя")]
    public EngineType EngineType { get; set; } = EngineType.Turbojet;

    [Display(Name = "Количество двигателей")]
    public int NumberOfEngines { get; set; }

    [Display(Name = "Степень двухконтурности")]
    public double BypassRatio { get; set; }

}