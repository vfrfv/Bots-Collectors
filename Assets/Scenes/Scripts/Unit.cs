using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private float _speed = 2;

    public void MoveUnit(Coin coin)
    {
        transform.LookAt(coin.transform.position);

        transform.position = Vector3.MoveTowards(transform.position, coin.transform.position, _speed * Time.deltaTime);
    }
}
