using Domain.Common.Interfaces;
using Domain.Entities;
using Domain.Enums;

namespace Domain.Services;

public class PlayerStatsCalculator : IPlayerStatsCalculator
{
    public PlayerStats CalculateStats(PlayerData playerData)
    {
        var stats = new PlayerStats(playerData.ShirtNo);
        
        stats.ServeReceive = CalculateServeReceive(playerData);
        stats.SettingStats = CalculateSetting(playerData);
        stats.AttackEfficiency = CalculateAttackEfficiency(playerData);
        stats.ServingPercentage = CalculateServingPercentage(playerData);
        stats.Aces = CalculateAces(playerData);
        stats.MissedServes = CalculateMissedServes(playerData);
        stats.Blocks = playerData.Blocks;
        stats.Digs = playerData.Digs;
        stats.SetsPlayed = playerData.SetsPlayed;

        return stats;
    }

    public double CalculateServeReceive(PlayerData playerData)
    {
        var threePasses = playerData.ServeReceives.Count(i => i == 3);
        var twoPasses = playerData.ServeReceives.Count(i => i == 2);
        var onePasses = playerData.ServeReceives.Count(i => i == 1);
        var totalPasses = playerData.ServeReceives.Count;

        return (double)(threePasses * 3 + twoPasses * 2 + onePasses) / totalPasses;
    }

    public SettingStats CalculateSetting(PlayerData playerData)
    {
        var stats = new SettingStats();
        var positionSets = new Dictionary<Position, List<int>>();
        foreach (var position in Enum.GetValues(typeof(Position)).Cast<Position>())
        {
            var sets = GetSetQualities(playerData.Sets, position);
            positionSets.Add(position, sets);
            stats.SetSettingQuantity(position, sets.Count);
        }

        foreach (var position in positionSets)
        {
            stats.SetSettingQuality(position.Key, position.Value.Average());
        }

        return stats;
    }

    private List<int> GetSetQualities(List<Tuple<Position,int>> sets, Position position)
    {
        var setQualities = new List<int>();
        foreach (var set in sets)
        {
            if (set.Item1 == position)
            {
                setQualities.Add(set.Item2);
            }
        }

        return setQualities;
    }

    public double CalculateAttackEfficiency(PlayerData playerData)
    {
        var kills = playerData.Attacks.Count(a => a == AttackValue.Kill);
        var errors = playerData.Attacks.Count(a => a == AttackValue.Error);
        var attempts = playerData.Attacks.Count;

        return (double)(kills - errors) / attempts;
    }

    public double CalculateServingPercentage(PlayerData playerData)
    {
        var aces = CalculateAces(playerData);
        var threes = playerData.Serves.Count(s => s == 3);
        var twos = playerData.Serves.Count(s => s == 2);
        var ones = playerData.Serves.Count(s => s == 1);
        var totalServes = playerData.Serves.Count;

        return (double)(4 * aces + 3 * threes + 2 * twos + ones) / totalServes;
    }

    public int CalculateAces(PlayerData playerData)
    {
        return playerData.Serves.Count(s => s == 4);
    }
    
    public int CalculateMissedServes(PlayerData playerData)
    {
        return playerData.Serves.Count(s => s == 0);
    }
}