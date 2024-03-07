using System.Collections.Generic;

public class UnitStateMachine
{
    private List<IBaseStste> _states;
    private IBaseStste _currentState;

    public UnitStateMachine()
    {
        _states = new List<IBaseStste>()
        {

        };

        _currentState = _states[0];
        _currentState.Enter();
    }

    public void SwitchState(IBaseStste state)
    {
        _currentState.Exit();
        _currentState = state;
        _currentState.Enter();
    }
}
