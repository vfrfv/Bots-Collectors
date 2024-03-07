using UnityEngine;

[RequireComponent(typeof(Unit))]

public class Collector : MonoBehaviour
{
    //[SerializeField] private Base _base;
    [SerializeField] private Transform _targetBase;
   
    private Unit _unit;
    private Coin _coin;


    private void Awake()
    {
        _unit = GetComponent<Unit>();
        
    }

    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.TryGetComponent<Base>(out Base bass))
    //    {
    //        if (_coin != null)
    //        {
    //            Destroy(_coin.gameObject);
    //        }
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Coin>(out Coin coin) && _unit.CoinId == coin.Id)
        {
            coin.transform.SetParent(transform);
            coin.GetComponent<BoxCollider>().enabled = false;
            _coin = coin;

            Transform targetBase = _unit.BaseCoordinate;
            _unit.MoveToTarget(targetBase);
        }

        if (other.TryGetComponent<Base>(out Base bass))
        {
            if (_coin != null)
            {
                Destroy(_coin.gameObject);
            }
        }
    }
}
