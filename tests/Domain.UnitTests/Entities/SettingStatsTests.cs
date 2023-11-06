using Domain.Entities;
using Domain.Enums;
using FluentAssertions;

namespace Domain.UnitTests.Entities;

public class SettingStatsTests
{
    [Fact]
    public void TotalSets_Tests()
    {
        // arrange
        var stats = new SettingStats();
        stats.SetSettingQuantity(Position.Outside, 10);
        stats.SetSettingQuantity(Position.Pipe, 3);
        stats.SetSettingQuantity(Position.Middle, 5);
        stats.SetSettingQuantity(Position.OppositeFront, 6);
        stats.SetSettingQuantity(Position.OppositeBack, 4);

        var expected = 28;

        // act
        var actual = stats.TotalSets;

        // assert

        actual.Should().Be(expected);
    }
}