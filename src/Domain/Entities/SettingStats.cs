using Domain.Enums;

namespace Domain.Entities;

public class SettingStats
{
    public Dictionary<Position, int> SetQuantities { get; set; } = new();
    public Dictionary<Position, double> AverageSetQualities { get; set; } = new();

    public int TotalSets => SetQuantities.Values.Sum();

    public void SetSettingQuantity(Position position, int quantity)
    {
        SetQuantities[position] = quantity;
    }

    public void SetSettingQuality(Position position, double quality)
    {
        AverageSetQualities[position] = quality;
    }

    public double GetPositionSetShare(Position position)
    {
        return (double)SetQuantities[position] / TotalSets;
    }

    public Dictionary<Position, double> GetSettingDistribution()
    {
        var distribution = new Dictionary<Position, double>();
        var totalSets = TotalSets;
        foreach (var kvp in SetQuantities)
        {
            distribution[kvp.Key] = (double)kvp.Value / totalSets;
        }

        return distribution;
    }

    public int GetSetQuantity(Position position)
    {
        return SetQuantities[position];
    }

    public double GetSetQuality(Position position)
    {
        return AverageSetQualities[position];
    }
    
    
    
}