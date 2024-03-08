public class BuildingBase : IBaseState
{
    private Base _base;
    private int _coinsCreateBase = 5;

    public BuildingBase(Base currentBase)
    {
        _base = currentBase;
    }

    public void Run()
    {
        if (_base.HasCoins(_coinsCreateBase) && _base.HasFreeUnit())
        {
            _base.SendToFlag();
            _base.SubtractCoins(_coinsCreateBase);
        }
    }
}
