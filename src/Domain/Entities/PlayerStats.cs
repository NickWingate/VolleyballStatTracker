namespace Domain.Entities;

public class PlayerStats
{
    public PlayerStats(int shirtNo)
    {
        ShirtNo = shirtNo;
    }

    public int ShirtNo { get; set; }
    public double ServeReceive { get; set; }
    public SettingStats? SettingStats { get; set; }
    public double AttackEfficiency { get; set; }
    public double ServingPercentage { get; set; }
    public int Aces { get; set; }
    public int MissedServes { get; set; }
    public double Blocks { get; set; }
    public int Digs { get; set; }
    public int SetsPlayed { get; set; }
}