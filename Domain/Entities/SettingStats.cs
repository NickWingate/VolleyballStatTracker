namespace Domain.Entities;

public class SettingStats
{
    public int OutsideSets { get; set; }
    public int MiddleSets { get; set; }
    public int OppositeFrontSets { get; set; }
    public int OppositeBackSets { get; set; }
    public int PipeSets { get; set; }

    public float AverageOutsideQuality { get; set; }
    public float AverageMiddleQuality { get; set; }
    public float AverageOppositeFrontQuality { get; set; }
    public float AverageOppositeBackQuality { get; set; }
    public float AveragePipeQuality { get; set; }

    public int TotalSets => OutsideSets + MiddleSets + OppositeFrontSets + OppositeBackSets + PipeSets;
    
    public float OutsideShare => OutsideSets / TotalSets;
    public float MiddleShare => MiddleSets / TotalSets;
    public float OppositeShare => (OppositeFrontSets + OppositeBackSets) / TotalSets;
    public float OppositeFrontShare => OppositeFrontSets / TotalSets;
    public float OppositeBackShare => OppositeBackSets / TotalSets;
    public float PipeShare => PipeSets / TotalSets;
    
}