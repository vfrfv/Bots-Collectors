using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    private float _scanRadius = 100;
    private readonly Queue<Coin> _coins = new Queue<Coin>();
    private Coroutine _coroutine;

    private void Start()
    {
       _coroutine = StartCoroutine(StartScanner());
    }

    private void OnDestroy()
    {
        StopCoroutine(_coroutine);
    }

    public Queue<Coin> GetCoins()
    {
        return _coins; 
    }

    private IEnumerator StartScanner()
    {
        float scanTimer = 3;
        var delayScan = new WaitForSeconds(scanTimer);
        bool isScan = true;

        while (isScan)
        {
            Scan();

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
