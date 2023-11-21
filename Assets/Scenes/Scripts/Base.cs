using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField] private CoinSpawn _coinSpawn;
    [SerializeField] private List<Unit> _units;

    private Queue<Coin> _coins;
    private Queue<Unit> _unitQueue;
    private float _numberCoins = 0;

    private void Awake()
    {
        _unitQueue = new Queue<Unit>(_units);
    }

    private void Update()
    {
        _coins = _coinSpawn.GetCoins();

        if (_coins.Count > 0 && _unitQueue.Count > 0)
        {
            Unit currentUnit = _unitQueue.Peek();

            if (currentUnit.IsSent == false)
            {
                currentUnit.MoveToTarget(_coins.Peek().transform.position);
                currentUnit.ChangeStatus();

                _coins.Dequeue();
                _unitQueue.Dequeue();
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
            Debug.Log($"Количество монет {_numberCoins}");
        }
    }
}
