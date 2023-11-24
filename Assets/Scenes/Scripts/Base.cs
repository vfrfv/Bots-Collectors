using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField] private Scanner _scanner;
    [SerializeField] private List<Unit> _units;

    private Queue<Coin> _allCoins = new Queue<Coin>();
    private Queue<Unit> _unitQueue;
    private float _numberCoins = 0;

    private void Awake()
    {
        _unitQueue = new Queue<Unit>(_units);
    }

    private void Update()
    {
        Queue<Coin> coins = _scanner.GetCoins();

        while (coins.Count > 0)
        {
            Coin coin = coins.Dequeue();
            _allCoins.Enqueue(coin);
        }

        if (_allCoins.Count > 0 && _unitQueue.Count > 0)
        {
            Unit currentUnit = _unitQueue.Peek();
            Coin currentCoin = _allCoins.Peek();

            currentUnit.AssignId(currentCoin.Id);

            if (currentUnit.IsSent == false)
            {
                currentUnit.MoveToTarget(currentCoin.transform.position, currentUnit.CoinId);
                currentUnit.ChangeStatus();

                currentCoin.ChangeColor();

                _unitQueue.Dequeue();
                _allCoins.Dequeue();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Unit>(out Unit unit) && unit.IsSent == true)
        {
            unit.ChangeStatus();
            _unitQueue.Enqueue(unit);

            _numberCoins++;
        }
    }
}
