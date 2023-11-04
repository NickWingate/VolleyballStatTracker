﻿namespace Domain.Entities;

public class PlayerStats
{
    public int ShirtNumber { get; set; }
    public float ServeReceive { get; set; }
    public SettingStats SettingStats { get; set; }
    public float AttackEfficiency { get; set; }
    public float ServingPercentage { get; set; }
    public int Aces { get; set; }
    public float Blocks { get; set; }
    public int SetsPlayed { get; set; }
}