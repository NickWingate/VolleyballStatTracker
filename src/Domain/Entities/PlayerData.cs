using Domain.Enums;

namespace Domain.Entities;

public class PlayerData
{
    public PlayerData(int shirtNo)
    {
        ShirtNo = shirtNo;
        Serves = new List<int>();
        ServeReceives = new List<int>();
    }

    public int ShirtNo { get; set; }
    public List<int> Serves { get; set; }
    public List<int> ServeReceives { get; set; }
    public List<Tuple<Position, int>> Sets { get; set; }
    public List<AttackValue> Attacks { get; set; }
    public int Digs { get; set; }
    public double Blocks { get; set; }
    public int SetsPlayed { get; set; }
}