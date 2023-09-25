using FluentAssertions;
using Uge_3_Opgave;

namespace Uge_3_Tests;

public class TransportTest
{
    [Theory]
    [InlineData(2, 9, 0)]
    [InlineData(2, 11, 50)]
    [InlineData(6, 9, 75)]
    [InlineData(6, 11, 100)]
    public void Transportation_cost_changes_based_off_of_size_and_weight(int distanceInKilometers, int weightInKilograms, int expectedPrice)
    {
        //Arrange
        var calculator = new TransportCalculator();

        //Act
        var actualPrice = calculator.CalculateTransportPrice(new TransportDetail(distanceInKilometers, weightInKilograms));

        //Assert
        actualPrice.Should().Be(expectedPrice);
    }

    [Theory]
    [InlineData(-1, 9)]
    [InlineData(1, -9)]
    [InlineData(-1, -9)]
    public void Transportation_cost_cannot_be_calculated_for_negative_values(int distanceInKilometers, int weightInKilograms)
    {
        //Arrange
        var calculator = new TransportCalculator();
        
        //Act
        var action = () =>
            calculator.CalculateTransportPrice(new TransportDetail(distanceInKilometers, weightInKilograms));

        //Assert
        action.Should().Throw<ArgumentOutOfRangeException>();
    }
}