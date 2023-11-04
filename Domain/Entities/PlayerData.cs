using Domain.Enums;

namespace Domain.Entities;

public class PlayerData
{
    public PlayerData()
    {
        Serves = new List<int>();
        ServeReceives = new List<int>();
    }

    public int ShirtNo { get; set; }
    public List<int> Serves { get; set; }
    public List<int> ServeReceives { get; set; }
    public Dictionary<Position, int> Sets { get; set; }
    public List<AttackValue> Attacks { get; set; }
    public int Digs { get; set; }
    public List<float> Blocks { get; set; }
}