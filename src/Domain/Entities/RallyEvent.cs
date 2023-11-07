using Domain.Enums;

namespace Domain.Entities;

public class RallyEvent
{
    public EventType Type { get; set; }
    public int PlayerResponsible { get; set; } //todo: can be player type eventually
    public double NumericQuality { get; set; }
    public Position SetLocation { get; set; }
    public AttackValue AttackResult { get; set; }
    public BlockCredit BlockCredit { get; set; }
}