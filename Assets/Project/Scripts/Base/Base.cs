using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    public event Action Installed;

    [SerializeField] private Scanner _scanner;
    [SerializeField] private Unit _prefabUnit;

    private Queue<Unit> _unitQueue = new Queue<Unit>();
    private float _numberCoins = 0;
    private float _coinsCreateUnit = 3;
    private bool _isFlagSet = false;

    public bool IsFlagSet => _isFlagSet;

    private void Start()
    {
        CreateStartingUnits();
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

    public void SetFlag()
    {
        _isFlagSet = true;

        Installed?.Invoke();
    }

    private void CreateUnit()
    {
        Unit newUnit = Instantiate(_prefabUnit, transform.position, Quaternion.identity);
        newUnit.SetBaseCoordinate(transform);
        _unitQueue.Enqueue(newUnit);
    }

    private void CreateStartingUnits()
    {
        int numberStartingUnits = 3;

        for (int i = 0; i < numberStartingUnits; i++)
        {
            CreateUnit();
        }
    }

    private void Update()
    {
        if(_numberCoins >= _coinsCreateUnit)
        {
            CreateUnit();

            _numberCoins -= _coinsCreateUnit;
        }
    }
}
