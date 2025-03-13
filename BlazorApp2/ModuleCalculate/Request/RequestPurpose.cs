using BlazorApp2.Pages.dto;
using System.ComponentModel.DataAnnotations;

namespace Pax_AC_Design.ModuleCalculate.Request;

public enum AircraftType
{
    [Display(Name = "Самолет бизнес-класса")]
    BusinessJet,
    [Display(Name = "Реактивный самолет малой дальности полета")]
    ShortRangeJetTransport,
    [Display(Name = "Реактивный самолет средней дальности полета")]
    MediumRangeJetTransport,
    [Display(Name = "Реактивный самолет большой дальности полета")]
    LongRangeJetTransport,
    [Display(Name = "Реактивный самолет сверхбольшой дальности полета")]
    UltraLongRangeJetTransport,
    [Display(Name = "Истребитель")]
    Fighter,
    [Display(Name = "Сверхзвуковой крейсерский самолет")]
    SupersonicCruise
}

public enum HighLiftDevice
{
    [Display(Name = "Чистый аэродинамический профиль")]
    CleanAirfoil,
    [Display(Name = "Простой закрылок")]
    PlainFlap,
    [Display(Name = "Закрылок с одной прорезью")]
    SingleSlottedFlap,
    [Display(Name = "Закрылок с двумя прорезями")]
    DoubleSlottedFlap,
    [Display(Name = "Разделенный закрылок")]
    SplitFlap,
    [Display(Name = "Двухкрылые юнкерсы")]
    DoubleWingJunkers,
    [Display(Name = "Закрылок Фаулера")]
    FowlerFlap,
    [Display(Name = "Предкрылок")]
    Slat,
    [Display(Name = "Простой закрылок и предкрылок")]
    PlainFlapAndSlat,
    [Display(Name = "Закрылок с одной прорезью и предкрылок")]
    SingleSlottedFlapAndSlat,
    [Display(Name = "Закрылок с двумя прорезями и предкрылок")]
    DoubleSlottedFlapAndSlat,
    [Display(Name = "Закрылок Фаулера и предкрылок")]
    FowlerFlapAndSlat
}

public enum DesignRangeClassification
{
    ShortRange,
    MediumRange,
    LongRange,
    UltraLongRange
}

public class RequestPurpose : IRequest
{
    #region Поля, берущиеся из конструктора

    // тип самолета                                                                         BLOCK 1
    public AircraftType AircraftType { get; set; }

    // тип механизации крыла (закрылок и предкрылок)                                        BLOCK 1
    public HighLiftDevice HighLiftDevice { get; set; }

    // todo: высота над уровнем моря, sigma ?                                               BLOCK 1
    public double HeightAboveSeaLevel { get; set; }

    // посадочный путь, s_L                                                                 BLOCK 1
    public double LandingDistance { get; set; }

    // путь по земле при взлете, s_TOG                                                      BLOCK 2
    public double TakeOffGroundRoll { get; set; }

    // соотношение сторон крыла, A                                                          BLOCK 4
    public double WingAspectRatio { get; set; }

    // отношение площади смачивания самолета к площади крыла, S_wet / S_W                   BLOCK 6
    public double WingWettedArea { get; set; }

    #endregion

    #region Расчетные значения

    // максимальный коэффициент подъемной силы, C_L,max                                     BLOCK 1
    public double MaxLiftCoefficient { get; set; }

    // отношение максимальной посадочной массы к максимальной взлетной массе, m_ML/m_MTO    BLOCK 1
    public double MaxLandingMassToMaxTakeOffMassRatio { get; set; }

    // максимальная нагрузка на крыло m/S (или m_MTO/S_W)                                   BLOCK 1
    public double MaxWingLoading { get; set; }

    // максимальный коэффициент подъемной силы при взлете, C_L,max,TO                       BLOCK 2
    public double MaxLiftCoefficientTakeOff { get; set; }

    // коэффициент зависимости тяговооруженности от нагрузки на крыло,
    // (T_TO / (m_MTO * g)) / (m_MTO / S_W)                                                 BLOCK 2
    public double ThrustToWeightRatioAndWingLoadingCoefficient { get; set; }

    // длина взлетного пути (поля), s_TOFL                                                  BLOCK 2
    public double TakeOffFieldLength { get; set; }

    // угол набора высоты, gamma                                                            BLOCK 3
    public double ClimbAngle { get; set; }

    // минимальная тяговооруженность во время 2nd Segment, min(T_TO / (m_MTO * g))          BLOCK 3/4
    public double MinThrustToWeightRatio2Segment { get; set; }

    // отношение подъемной силы к лобовому сопротивлению с шасси и закрылками, E            BLOCK 4
    public double LiftToDragRatio { get; set; }

    // минимальная тяговооруженность во время Missed Approach, min(T_TO / (m_MTO * g))      BLOCK 5
    public double MinThrustToWeightRatioMissedApproach { get; set; }

    // коэффициент подъемной силы во время круизного полета, C_L                            BLOCK 6
    public double LiftCoefficientCruise { get; set; }

    // отношение подъемной силы к лобовому сопротивлению во время Cruise, E                 BLOCK 6
    public double LiftToDragRatioCruise { get; set; }

    // делегат-Func для сохранения зависимости тяговооруженности от высоты                  BLOCK 7
    public Func<double, double> ThrustToWeightFunctionCruise { get; set; }

    // делегат-Func для сохранения зависимости нагрузки на крыло от высоты                  BLOCK 7
    public Func<double, double> WingLoadingFunctionCruise { get; set; }

    // высота крейсерского полета, h_CR                                                     BLOCK 8
    public double AltitudeCruise { get; set; }

    // удельная нагрузка на крыло, m/S (или m_MTO/S_W)                                      BLOCK 8
    public double WingLoading { get; set; }

    // тяговооруженность, T_TO / (m_MTO * g)                                                BLOCK 8
    public double ThrustToWeightRatio { get; set; }

    #endregion

    public RequestPurpose(RequestPurposeDto dto)
        : this(dto.AircraftType,
            dto.HighLiftDevice,
            dto.HeightAboveSeaLevel,
            dto.LandingDistance,
            dto.TakeOffGroundRoll,
            dto.WingAspectRatio,
            dto.WingWettedArea)
    {
    }

    public RequestPurpose(
        AircraftType aircraftType,
        HighLiftDevice highLiftDevice,
        double heightAboveSeaLevel,
        double landingDistance,
        double takeOffGroundRoll,
        double wingAspectRatio,
        double wingWettedArea)
    {
        AircraftType = aircraftType;
        HighLiftDevice = highLiftDevice;
        HeightAboveSeaLevel = heightAboveSeaLevel;
        LandingDistance = landingDistance;
        TakeOffGroundRoll = takeOffGroundRoll;
        WingAspectRatio = wingAspectRatio;
        WingWettedArea = wingWettedArea;
    }
}