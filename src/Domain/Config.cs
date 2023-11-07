using Domain.Enums;

namespace Domain;

public static class Config
{
    public static readonly Dictionary<string, EventType> EventShorthands = new()
    {
        { "r", EventType.ServeReceive },
        { "v", EventType.Serve },
        { "h", EventType.Attack },
        { "s", EventType.Set },
        { "b", EventType.Block },
        { "d", EventType.Dig },
    };

    public static readonly Dictionary<string, Position> PositionShorthands = new()
    {
        { "o", Position.Outside },
        { "m", Position.Middle },
        { "p", Position.Pipe },
        { "of", Position.OppositeFront },
        { "ob", Position.OppositeBack },
    };
    
    public static readonly Dictionary<string, AttackValue> AttackShorthands = new()
    {
        { "k", AttackValue.Kill },
        { "e", AttackValue.Error },
        { "n", AttackValue.Neutral },
    };
    
    public static readonly Dictionary<string, BlockCredit> BlockShorthands = new()
    {
        { "s", BlockCredit.Solo },
        { "a", BlockCredit.Assist },
    };
}