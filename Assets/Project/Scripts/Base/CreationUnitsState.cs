public class CreationUnitsState : IBaseState
{
    private Base _base;
    private int _coinsCreateUnit = 3;

    public CreationUnitsState(Base currentBase)
    {
        _base = currentBase;
    }

    public void Run()
    {
        if (_base.HasCoins(_coinsCreateUnit))
        {
            _base.CreateUnit();
            _base.SubtractCoins(_coinsCreateUnit);
        }
    }
}
