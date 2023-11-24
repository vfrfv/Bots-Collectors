using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    private float _scanRadius = 100;

    private Queue<Coin> _coins = new Queue<Coin>();

    private void Start()
    {
        StartCoroutine(StartScanner());
    }

    public Queue<Coin> GetCoins()
    {
        return _coins;
    }

    private IEnumerator StartScanner()
    {
        float scanTimer = 3;
        var delayScan = new WaitForSeconds(scanTimer);

        while (true)
        {
            Scan();
            //Debug.Log($"ѕроизошло сканирование обнаружено {_coins.Count} монеток");

            yield return delayScan;
        }
    }

    private void Scan()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _scanRadius);

        for (int i = 0; i < colliders.Length; i++)
        {
            Coin coin = colliders[i].gameObject.GetComponent<Coin>();

            if(coin != null && coin.IsUnique == true)
            {
                _coins.Enqueue(coin);
                coin.ChangeUniqueness();
            }
        }
    }
}
