using Domain.Enums;

namespace Domain.Entities;

public class RallyEvent
{
    public EventType Type { get; set; }
    public int PlayerResponsible { get; set; } //todo: can be player type eventually
    public double Quality { get; set; }
}