using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField] private Scanner _scanner;
    [SerializeField] private List<Unit> _units;

    private Queue<Unit> _unitQueue;
    private float _numberCoins = 0;

    private void Awake()
    {
        _unitQueue = new Queue<Unit>(_units);
    }

    private void Start()
    {
        StartCoroutine(Work());
    }

    private IEnumerator Work()
    {
        bool IsCoinsFound = true;

        while (IsCoinsFound)
        {
            float coinCheckTimer = 4;
            var checking—oins = new WaitForSeconds(coinCheckTimer);
         
            Queue<Coin> freeCoins = _scanner.GetCoins();

            int count = Mathf.Min(freeCoins.Count, _unitQueue.Count);

            for (int i = 0; i < count; i++)
            {
                Unit currentUnit = _unitQueue.Peek();
                Coin currentCoin = freeCoins.Peek();

                currentUnit.AssignId(currentCoin.Id);

                if (currentUnit.IsSent == false)
                {
                    currentUnit.MoveToTarget(currentCoin.transform.position);

                    currentUnit.ChangeStatus();
                    currentCoin.ChangeColor();

                    _unitQueue.Dequeue();
                    freeCoins.Dequeue();
                }
            }

            yield return checking—oins;
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
