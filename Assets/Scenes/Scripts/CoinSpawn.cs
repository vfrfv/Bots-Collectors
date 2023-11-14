using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawn : MonoBehaviour
{
    [SerializeField] private Coin _coin;

    public event Action OnStartMoveUnit;

    private List<Coin> _coins = new List<Coin>();

    private void Start()
    {
        StartCoroutine(Creating());
    }

    public List<Coin> GetListCoins()
    {
        return _coins;
    }

    private IEnumerator Creating()
    {
        float dryingTimer = 3;
        bool IsBeingCreated = true;
        var delaySpawn = new WaitForSeconds(dryingTimer);

        while (IsBeingCreated)
        {
            float min = 4;
            float max = 10;

            float psitionX = UnityEngine.Random.Range(min, max);
            float psitionZ = UnityEngine.Random.Range(min, max);

            Coin coin = Instantiate(_coin, new Vector3(psitionX, 0, psitionZ), Quaternion.identity);           

            _coins.Add(coin);

            OnStartMoveUnit?.Invoke();

            yield return delaySpawn;
        }
    }
}
