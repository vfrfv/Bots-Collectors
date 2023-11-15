using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField] private CoinSpawn _coinSpawn;
    [SerializeField] private Queue<Unit> _units;

    //public event Action UnitSent;

    private Queue<Coin> _coins;
    private Coroutine _coroutine;

    private void Start()
    {
        _coinSpawn.OnStartMoveUnit += () =>
        {
            if (_coroutine != null && _units.Count <= 0)
            {
                StopCoroutine(SendUnit(GetUnit(), GetCoin()));
            }
            else if (_coroutine == null && _units.Count > 0)
            {
                _coroutine = StartCoroutine(SendUnit(GetUnit(), GetCoin()));
            }
        };
    }

    private Coin GetCoin()
    {
        _coins = _coinSpawn.GetListCoins();

        return _coins.Peek();
    }

    private Unit GetUnit()
    {
        return _units.Peek();
    }

    private IEnumerator SendUnit(Unit unit, Coin coin)
    {
        bool isUnitSent = true;

        while (isUnitSent)
        {
            unit.MoveUnit(coin);

            yield return null;
        }
    }
}
