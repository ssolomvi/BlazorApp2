using System.ComponentModel.DataAnnotations;
using BlazorApp2.Pages.dto;

namespace Pax_AC_Design.ModuleCalculate.Request;

public enum EngineType
{
    [Display(Name = "Турбореактивный двигатель")]
    Turbojet,

    [Display(Name = "Турбовинтовой двигатель")]
    Turboprop
}

public class RequestEngine : IRequest
{
    // тип двигателя                                                    BLOCK 1
    // [Required(ErrorMessage = "Engine type is required.")]
    public EngineType EngineType { get; set; }

    // количество двигателей, n_E                                       BLOCK 3
    // [Required(ErrorMessage = "Number of engines is required.")]
    public int NumberOfEngines { get; set; }

    // степень двухконтурности, BPR (bypass ratio), мю                  BLOCK 7
    // [Required(ErrorMessage = "Bypass ratio required.")]
    public double BypassRatio { get; set; }

    public RequestEngine(RequestEngineDto dto)
        : this(dto.EngineType, dto.NumberOfEngines, dto.BypassRatio)
    {
    }

    public RequestEngine(
        EngineType engineType,
        int numberOfEngines,
        double bypassRatio)
    {
        EngineType = engineType;
        NumberOfEngines = numberOfEngines;
        BypassRatio = bypassRatio;
    }
}