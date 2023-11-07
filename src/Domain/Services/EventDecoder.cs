using System.Text.RegularExpressions;
using Domain.Common.Exceptions;
using Domain.Common.Interfaces;
using Domain.Entities;
using Domain.Enums;

namespace Domain.Services;

public partial class EventDecoder : IEventDecoder
{
    public RallyEvent DecodeString(string str)
    {
        // todo: eventually support team events e.g. no cover
        
        var playerStr = NumericRegex().Match(str).Value;
        var player = Convert.ToInt32(playerStr);
        var typeStr = str.Substring(playerStr.Length, 1);
        var type = DecodeType(typeStr);
        str = str.Substring(playerStr.Length + 1);

        var rallyEvent = new RallyEvent()
        {
            Type = type,
            PlayerResponsible = player
        };
        

        if (str.Length > 0 && Char.IsAsciiLetter(str[0]))
        {
            var adInfo = NonNumericRegex().Match(str).Value;
            FillAdditionalInfo(rallyEvent, adInfo);
            str = str.Substring(adInfo.Length);
        }

        if (str.Length > 0)
        {
            var quality = DecodeQuality(str);
            
            rallyEvent.NumericQuality = quality;
        }

        return rallyEvent;
    }

    private int DecodeQuality(string str)
    {
        return Convert.ToInt32(str);
    }

    private void FillAdditionalInfo(RallyEvent rallyEvent, string eventInfo)
    {
        switch (rallyEvent.Type)
        {
            case EventType.Set:
                rallyEvent.SetLocation = Config.PositionShorthands[eventInfo];
                return;
            case EventType.Attack:
                rallyEvent.AttackResult = Config.AttackShorthands[eventInfo];
                return;
            case EventType.Block:
                rallyEvent.BlockCredit = Config.BlockShorthands[eventInfo];
                return;
        }
    }

    private static EventType DecodeType(string str)
    {
        if (Config.EventShorthands.TryGetValue(str, out EventType value))
        {
            return value;
        }

        throw new UnknownEventTypeException();
    }

    [GeneratedRegex("^\\D*")]
    private static partial Regex NonNumericRegex();
    [GeneratedRegex("^\\d*")]
    private static partial Regex NumericRegex();
}