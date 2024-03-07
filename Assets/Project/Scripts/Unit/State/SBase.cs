using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SBase : MonoBehaviour
{
    private UnitStateMachine _unitStateMachine;

    private void Awake()
    {
        _unitStateMachine = new UnitStateMachine();
    }


}
