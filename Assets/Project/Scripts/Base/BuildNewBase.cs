using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildNewBase : MonoBehaviour
{
    private float _coinsBuild = 5;
    private Base _base;

    private void Awake()
    {
        _base = GetComponent<Base>();
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

    private void SendUnitFlag()
    {
        if(_base.NumberCoins >= _coinsBuild)
        {

        }
    }
}
