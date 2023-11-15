using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField] private CoinSpawn _coinSpawn;
    [SerializeField] private List<Unit> _units;
    [SerializeField] private Coin _coin;

    //public event Action UnitSent;

    [SerializeField] private Queue<Coin> _coins;
    private Coroutine _coroutine;
    private Queue<Unit> _unitQueue;

    private void Awake()
    {
        _unitQueue = new Queue<Unit>(_units);
    }

    private void Update()
    {
        _coins = _coinSpawn.GetCoins();

        if (_coins.Count > 0 && _unitQueue.Count > 0)
        {
            Debug.Log(_unitQueue.Peek());
            Debug.Log(_coins.Peek());

            Coin target = _coins.Peek();

            _unitQueue.Peek().SetTarget(target);

            _unitQueue.Dequeue();
            _coins.Dequeue();
        }
    }
}
