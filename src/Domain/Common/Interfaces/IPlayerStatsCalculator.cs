using Domain.Entities;

namespace Domain.Common.Interfaces;

public interface IPlayerStatsCalculator
{
    public PlayerStats CalculateStats(PlayerData playerData);
    public double CalculateServeReceive(PlayerData playerData);
    public SettingStats CalculateSetting(PlayerData playerData);
    public double CalculateAttackEfficiency(PlayerData playerData);
    public double CalculateServingPercentage(PlayerData playerData);
    public int CalculateAces(PlayerData playerData);
    public int CalculateMissedServes(PlayerData playerData);
}