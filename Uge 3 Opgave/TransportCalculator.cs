using System.ComponentModel.DataAnnotations;

namespace Uge_3_Opgave;

public class TransportCalculator
{
    public int CalculateTransportPrice(TransportDetail transportDetail)
    {
        if (transportDetail.DistanceInKilometers < 5)
        {
            return transportDetail.WeightInKilograms < 10 ? 0 : 50;
        }

        return transportDetail.WeightInKilograms < 10 ? 75 : 100;
    }
}

public class TransportDetail
{
    public int DistanceInKilometers { get; }
    public int WeightInKilograms { get; }

    public TransportDetail(int distanceInKilometers, int weightInKilograms)
    {
        DistanceInKilometers = distanceInKilometers > 0
            ? distanceInKilometers
            : throw new ArgumentOutOfRangeException(nameof(distanceInKilometers));
        WeightInKilograms = weightInKilograms > 0
            ? weightInKilograms
            : throw new ArgumentOutOfRangeException(nameof(weightInKilograms));
    }
}