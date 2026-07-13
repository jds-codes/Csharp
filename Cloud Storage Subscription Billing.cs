using System;
using System.Collections.Generic;

class Subscription
{
    public double SubscriptionFee { get; set; }

    public virtual double GenerateBill()
    {
        return SubscriptionFee;
    }
}

class BasicPlan : Subscription
{
    public override double GenerateBill()
    {
        return SubscriptionFee;
    }
}

class ProfessionalPlan : Subscription
{
    public double StorageUsed { get; set; }
    public double StorageRate { get; set; }

    public override double GenerateBill()
    {
        return SubscriptionFee + (StorageUsed * StorageRate);
    }
}

class EnterprisePlan : Subscription
{
    public double StorageCharge { get; set; }
    public double UserLicenseFee { get; set; }

    public override double GenerateBill()
    {
        return SubscriptionFee + StorageCharge + UserLicenseFee;
    }
}

class Program
{
    static void Main()
    {
        List<Subscription> subscriptions = new List<Subscription>();

        subscriptions.Add(new BasicPlan
        {
            SubscriptionFee = 500
        });

        subscriptions.Add(new ProfessionalPlan
        {
            SubscriptionFee = 1000,
            StorageUsed = 50,
            StorageRate = 20
        });

        subscriptions.Add(new EnterprisePlan
        {
            SubscriptionFee = 2000,
            StorageCharge = 1500,
            UserLicenseFee = 1000
        });

        foreach (Subscription s in subscriptions)
        {
            Console.WriteLine("Monthly Bill = " + s.GenerateBill());
        }
    }
}