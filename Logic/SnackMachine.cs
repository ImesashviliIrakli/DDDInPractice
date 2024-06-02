namespace Logic;

public class SnackMachine : Entity
{
    public Money MoneyInside { get; private set; }
    public Money MoneyInTransaction { get; private set; }

    public SnackMachine()
    {
        MoneyInside = Money.None;
        MoneyInTransaction = Money.None;
    }

    public void InsertMoney(Money money)
    {
        Money[] coinsAndNotes = { Money.Cent, Money.TenCent, Money.Qaurter, Money.Dollar, Money.FiveDollar, Money.TwentyDollad };

        if (!coinsAndNotes.Contains(money))
            throw new InvalidOperationException();

        MoneyInTransaction += money;
    }

    public void ReturnMoney()
    {
        MoneyInTransaction = Money.None;
    }

    public void BuySnack()
    {
        MoneyInside += MoneyInTransaction;

        MoneyInTransaction = Money.None;
    }
}
