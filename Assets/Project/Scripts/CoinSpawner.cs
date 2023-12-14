using System.Collections;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _prefabCoin;

    [SerializeField] private float _maximumNumberCoins;
    private float _newCoinId = 0;
    private Coroutine _coroutine;

    private void Start()
    {
        TryToStopCoroutine();

        _coroutine = StartCoroutine(Creating());
    }

    private void TryToStopCoroutine()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
    }

    private void OnDestroy()
    {
        StopCoroutine(_coroutine);
    }

    private IEnumerator Creating()
    {
        float dryingTimer = 1;
        var delaySpawn = new WaitForSeconds(dryingTimer);

        for (int i = 0; i < _maximumNumberCoins; i++)
        {
            float min = 4;
            float max = 10;

            float positionX = UnityEngine.Random.Range(min, max);
            float positionZ = UnityEngine.Random.Range(min, max);

            Coin coin = Instantiate(_prefabCoin, new Vector3(positionX, 0, positionZ), Quaternion.identity);
            _newCoinId++;
            coin.AssignId(_newCoinId);

            yield return delaySpawn;
        }
    }
}
