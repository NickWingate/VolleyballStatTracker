using Domain.Common.Interfaces;
using Domain.Entities;
using Domain.Enums;
using Domain.Services;
using FluentAssertions;

namespace Domain.UnitTests.Services;

public class PlayerStatsCalculatorTests
{
    private IPlayerStatsCalculator _sut = new PlayerStatsCalculator();

    [Fact]
    public void CalculateServeReceive_WithValidData()
    {
        // Arrange
        var player = new PlayerData(1)
        {
            ServeReceives = new List<int>() { 3, 3, 2, 3, 1, 0, 0, 1 }
        };
        const double expected = (double)(3 * 3 + 1 * 2 + 2) / 8;

        // Act
        var actual = _sut.CalculateServeReceive(player);

        // Assert
        actual.Should().Be(expected);
    }

    [Fact]
    public void CalculateSetting_WithValidData()
    {
        // Arrange
        var player = new PlayerData(1)
        {
            Sets = new List<Tuple<Position, int>>()
            {
                new (Position.Outside, 2),
                new (Position.Outside, 2),
                new (Position.Outside, 1),
                new (Position.Outside, 3),
                new (Position.Middle, 3),
                new (Position.Middle, 2),
                new (Position.OppositeBack, 2),
                new (Position.OppositeFront, 3),
                new (Position.OppositeFront, 0),
                new (Position.Pipe, 3)
            }
        };

        var expectedDist = new Dictionary<Position, double>()
        {
            { Position.Outside, 0.4 },
            { Position.Middle, 0.2 },
            { Position.OppositeBack, 0.1 },
            { Position.OppositeFront, 0.2 },
            { Position.Pipe, 0.1 },
        };
        
        var expectedQuality = new Dictionary<Position, double>()
        {
            { Position.Outside, 2 },
            { Position.Middle, 2.5 },
            { Position.OppositeBack, 2 },
            { Position.OppositeFront, 1.5 },
            { Position.Pipe, 3 },
        };
        
        // Act
        var settingStats = _sut.CalculateSetting(player);
        var distribution = settingStats.GetSettingDistribution();
        var setQuality = settingStats.AverageSetQualities;

        // Assert

        distribution.Should().Equal(expectedDist);
        setQuality.Should().Equal(expectedQuality);
    }
}