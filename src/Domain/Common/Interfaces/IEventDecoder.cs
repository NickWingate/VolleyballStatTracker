using Domain.Entities;

namespace Domain.Common.Interfaces;

public interface IEventDecoder
{
    public RallyEvent DecodeString(string str);
}