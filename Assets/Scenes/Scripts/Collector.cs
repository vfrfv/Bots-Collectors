using UnityEngine;

[RequireComponent(typeof(Unit))]

public class Collector : MonoBehaviour
{
    [SerializeField] private Base _base;

    private Unit _unit;
    private bool _isTookCoin = false;
    private Coin _coin;

    private void Awake()
    {
        _unit = GetComponent<Unit>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<Base>(out Base bass))
        {
            if (_coin != null)
            {
                Destroy(_coin.gameObject);
                _isTookCoin = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Coin>(out Coin coin))
        {
            coin.transform.SetParent(transform);
            coin.GetComponent<BoxCollider>().enabled = false;
            _coin = coin;

            _unit.MoveToTarget(_base.transform.position);
            _isTookCoin = true;
        }
    }
}
