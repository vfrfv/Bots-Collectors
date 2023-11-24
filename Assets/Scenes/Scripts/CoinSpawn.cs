using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoinSpawn : MonoBehaviour
{
    [SerializeField] private Coin _coin;

    private float _maximumNumberCoins = 20;
    private float _coinId = 0;

    private void Start()
    {
        StartCoroutine(Creating());
    }

    private IEnumerator Creating()
    {
        float dryingTimer = 1;
        var delaySpawn = new WaitForSeconds(dryingTimer);

        for (int i = 0; i < _maximumNumberCoins; i++)       
        {
            float min = 4;
            float max = 10;

            float psitionX = UnityEngine.Random.Range(min, max);
            float psitionZ = UnityEngine.Random.Range(min, max);

            Coin coin = Instantiate(_coin, new Vector3(psitionX, 0, psitionZ), Quaternion.identity);
            _coinId++;
            coin.AssignId(_coinId);

            yield return delaySpawn;
        }
    }
}
