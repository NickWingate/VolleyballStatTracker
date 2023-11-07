using System.Diagnostics;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;
using System.Xml.Serialization;
using Domain.Common.Interfaces;
using Domain.Entities;
using Domain.Enums;
using Domain.Services;
using FluentAssertions;

namespace Domain.UnitTests.Services;

public class EventDecoderTests
{
    private IEventDecoder _sut = new EventDecoder();

    [Theory]
    [InlineData("1v3", 1, EventType.Serve, 3)]
    [InlineData("11v1", 11, EventType.Serve, 1)]
    [InlineData("1d", 1, EventType.Dig, 0)]
    [InlineData("11d", 11, EventType.Dig, 0)]
    [InlineData("111r2", 111, EventType.ServeReceive, 2)]
    [InlineData("1r2", 1, EventType.ServeReceive, 2)]
    public void DecodeString_ShouldDecodeBasicEvent_WhenValidData(
        string input, int player, EventType type, double quality)
    {
        // Arrange
        var expected = new RallyEvent()
        {
            Type = type,
            PlayerResponsible = player,
            NumericQuality = quality
        };

        // Act
        var actual = _sut.DecodeString(input);

        // Assert

        actual.Should().BeEquivalentTo(expected);
    }

    [Theory]
    [InlineData("1so3", 1, Position.Outside, 3)]
    [InlineData("11so2", 11, Position.Outside, 2)]
    [InlineData("1sof1", 1, Position.OppositeFront, 1)]
    [InlineData("1sob0", 1, Position.OppositeBack, 0)]
    public void DecodeString_ShouldDecodeSet_WhenValidData(
        string input, int player, Position location, double quality)
    {
        // Arrange
        var expected = new RallyEvent()
        {
            Type = EventType.Set,
            PlayerResponsible = player,
            NumericQuality = quality,
            SetLocation = location,
        };

        // Act
        var actual = _sut.DecodeString(input);

        // Assert

        actual.Should().BeEquivalentTo(expected);

    }
    
    [Theory]
    [InlineData("1hk", 1, AttackValue.Kill)]
    [InlineData("11he", 11, AttackValue.Error)]
    [InlineData("111hn", 111, AttackValue.Neutral)]
    public void DecodeString_ShouldDecodeAttack_WhenValidData(
        string input, int player, AttackValue result)
    {
        // Arrange
        var expected = new RallyEvent()
        {
            Type = EventType.Attack,
            PlayerResponsible = player,
            AttackResult = result,
        };

        // Act
        var actual = _sut.DecodeString(input);

        // Assert

        actual.Should().BeEquivalentTo(expected);

    }

}