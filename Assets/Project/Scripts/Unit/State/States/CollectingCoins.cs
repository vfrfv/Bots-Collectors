using UnityEngine;

public class CollectingCoins : State
{
    [SerializeField] private float _speed = 1;

    private Coin _coin;

    public void Enter()
    {

    }

    public void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _coin.transform.position, Time.deltaTime * _speed);

        if (transform.position == _coin.transform.position)
        {
            _coin.transform.SetParent(transform);
        }
    }

    public void SetTargetCoin(Coin coin)
    {
        _coin = coin;
    }
}
