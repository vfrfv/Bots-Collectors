using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField] private CoinSpawn _coinSpawn;
    [SerializeField] private List<Unit> _units;

    //public event Action UnitSent;

    private List<Coin> _coins;
    private Coroutine _coroutine;

    private void Start()
    {
        _coinSpawn.OnStartMoveUnit += () =>
        {
            if (_coroutine != null)
            {
                StopCoroutine(SendUnit(GetUnit(), GetCoin()));
            }
            _coroutine = StartCoroutine(SendUnit(GetUnit(), GetCoin()));
        };
    }

    private Coin GetCoin()
    {
        _coins = _coinSpawn.GetListCoins();

        for (int i = 0; i < _coins.Count; i++)
        {
            int randomCoin = UnityEngine.Random.Range(0, _coins.Count);

            return _coins[randomCoin];
        }

        return null;
    }

    private Unit GetUnit()
    {
        for (int i = 0; i < _units.Count; i++)
        {
            int randomUnit = UnityEngine.Random.Range(0, _units.Count);

            return _units[randomUnit];
        }

        return null;
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
