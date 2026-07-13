using System;
class Ride
{
    public double BaseFare { get; set; }
    public double Distance { get; set; }
    public virtual double CalculateFare()
    {
        return BaseFare;
    }
}
class EconomyRide : Ride
{
    public double RatePerKm { get; set; }
    public override double CalculateFare()
    {
        return BaseFare + (Distance * RatePerKm);
    }
}
class PremiumRide : Ride
{
    public double PremiumPerKm { get; set; }
    public double LuxuryFee { get; set; }
    public override double CalculateFare()
    {
        return BaseFare + (Distance * PremiumPerKm) + LuxuryFee ;

    }
}
class SharedRide : Ride
{
    public double RatePerKm { get; set; }
    public int NumberOfPassengers { get; set; }
    public override double CalculateFare()
    {
        double distanceCharfe = Distance * RatePerKm;
        return (BaseFare + distanceCharfe) / NumberOfPassengers;
    }
}
class Program
{
    static void Main()
    {
        Ride[] rides = new Ride[3];
        rides[0] = new EconomyRide 
        { BaseFare = 50, 
        Distance = 10, 
        RatePerKm = 15
        };
        rides[1] = new PremiumRide 
        { BaseFare = 60,
            Distance = 10,
            PremiumPerKm = 25,
            LuxuryFee = 100
        };
        rides[2] = new SharedRide 
        { BaseFare = 50,
            Distance = 10,
            RatePerKm = 15,
            NumberOfPassengers = 4
        };

        foreach (Ride ride in rides)
        {
            Console.WriteLine("Fare= "  + ride.CalculateFare());
        }
    }
}