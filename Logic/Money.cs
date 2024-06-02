namespace Logic;

public class Money : ValueObject<Money>
{
    public static readonly Money None = new Money(0, 0, 0, 0, 0, 0);
    public static readonly Money Cent = new Money(1, 0, 0, 0, 0, 0);
    public static readonly Money TenCent = new Money(0, 1, 0, 0, 0, 0);
    public static readonly Money Qaurter = new Money(0, 0, 1, 0, 0, 0);
    public static readonly Money Dollar = new Money(0, 0, 0, 1, 0, 0);
    public static readonly Money FiveDollar = new Money(0, 0, 0, 0, 1, 0);
    public static readonly Money TwentyDollad = new Money(0, 0, 0, 0, 0, 1);

    public int OneCentCount { get;}
    public int TenCentCount { get;}
    public int QuarterCount { get;}
    public int OneDollarCount { get;}
    public int FiveDollarCount { get;}
    public int TwentyDollarCount { get;}

    public decimal Amount
    {
        get
        {
            return OneCentCount * 0.01m +
                TenCentCount * 0.10m +
                QuarterCount * 0.25m +
                OneDollarCount +
                FiveDollarCount * 5 +
                TwentyDollarCount * 20;
        }
    
    }

    public Money(
         int oneCentCount,
         int tenCentCount,
         int quarterCount,
         int oneDollarCount,
         int fiveDollarCount,
         int twentyDollarCount
        )
    {
        if (oneCentCount < 0)
            throw new InvalidOperationException();
        if (tenCentCount < 0)
            throw new InvalidOperationException();
        if (quarterCount < 0)
            throw new InvalidOperationException();
        if (oneDollarCount < 0)
            throw new InvalidOperationException();
        if (fiveDollarCount < 0)
            throw new InvalidOperationException();
        if (twentyDollarCount < 0)
            throw new InvalidOperationException();

        OneCentCount = oneCentCount;
        TenCentCount = tenCentCount;
        QuarterCount = quarterCount;
        OneDollarCount = oneDollarCount;
        FiveDollarCount = fiveDollarCount;
        TwentyDollarCount = twentyDollarCount;
    }

    public static Money operator +(Money a, Money b)
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

    public static Money operator -(Money a, Money b)
    {
        return new Money(
                a.OneCentCount - b.OneCentCount,
                a.TenCentCount - b.TenCentCount,
                a.QuarterCount - b.QuarterCount,
                a.OneDollarCount - b.OneDollarCount,
                a.FiveDollarCount - b.FiveDollarCount,
                a.TwentyDollarCount - b.TwentyDollarCount
            );
    }

    public override bool EqualsCore(Money valueObject)
    {
        return OneCentCount == valueObject.OneCentCount &&
            TenCentCount == valueObject.TenCentCount &&
            QuarterCount == valueObject.QuarterCount &&
            OneDollarCount == valueObject.OneDollarCount &&
            FiveDollarCount == valueObject.FiveDollarCount &&
            TwentyDollarCount == valueObject.TwentyDollarCount;
    }

    public override int GetHashCodeCore()
    {
        unchecked
        {
            int hashCode = OneCentCount;
            hashCode = (hashCode * 397) ^ TenCentCount;
            hashCode = (hashCode * 397) ^ QuarterCount;
            hashCode = (hashCode * 397) ^ OneDollarCount;
            hashCode = (hashCode * 397) ^ FiveDollarCount;
            hashCode = (hashCode * 397) ^ TwentyDollarCount;
            return hashCode;
        }
    }
}
