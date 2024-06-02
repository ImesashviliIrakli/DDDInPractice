namespace Logic;

public class Money
{
    public int OneCentCount { get; private set; }
    public int TenCentCount { get; private set; }
    public int QuarterCount { get; private set; }
    public int OneDollarCount { get; private set; }
    public int FiveDollarCount { get; private set; }
    public int TwentyDollarCount { get; private set; }

    public Money(
         int oneCentCount,
         int tenCentCount,
         int quarterCount,
         int oneDollarCount,
         int fiveDollarCount,
         int twentyDollarCount
        )
    {
        OneCentCount = oneCentCount;
        TenCentCount = tenCentCount;
        QuarterCount = quarterCount;
        OneDollarCount = oneDollarCount;
        FiveDollarCount = fiveDollarCount;
        TwentyDollarCount = twentyDollarCount;
    }

    public static Money operator +( Money a, Money b )
    {
        Money sum = new Money(
                a.OneCentCount + b.OneCentCount,
                a.TenCentCount + b.TenCentCount,
                a.QuarterCount + b.QuarterCount,
                a.OneDollarCount + b.OneDollarCount,
                a.FiveDollarCount + b.FiveDollarCount,
                a.TwentyDollarCount + b.TwentyDollarCount
            );

        return sum;
    }
}
