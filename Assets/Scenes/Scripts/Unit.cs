using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private float _speed = 2;

    private bool _isSend = false;
    private Coin _targetCoin;

    private void Update()
    {
        if(_targetCoin != null)
        {
            MoveUnit();
        }
    }

    public void SetTarget(Coin coin)
    {
        _targetCoin = coin;
    }

    private void MoveUnit()
    {
        transform.LookAt(_targetCoin.transform.position);

        transform.position = Vector3.MoveTowards(transform.position, _targetCoin.transform.position, _speed * Time.deltaTime);
    }

    public void Send()
    {
        _isSend = true;
    }
}
