using System.Collections;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private float _speed = 3;
    private Coroutine _coroutine;

    public bool IsSent { get; private set; } = false;
    public float CoinId { get; private set; }

    public void MoveToTarget(Vector3 targetPosition, float id)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
        _coroutine = StartCoroutine(MoveCoroutine(targetPosition));
    }

    public void AssignId(float coinId)
    {
        CoinId = coinId;
    }

    public void ChangeStatus()
    {
        IsSent = !IsSent;
    }

    private IEnumerator MoveCoroutine(Vector3 targetPosition)
    {
        while (transform.position != targetPosition)
        {
            transform.LookAt(targetPosition);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, _speed * Time.deltaTime);

            yield return null;
        }
    }
}
