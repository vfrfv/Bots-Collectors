using System.Collections;
using System.Diagnostics;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Unit : MonoBehaviour
{
    private float _speed = 3;
    private Coroutine _coroutine;
    //private Base _base;
    private Transform _baseCoordinate;

    public Transform BaseCoordinate => _baseCoordinate;
    public bool IsSent { get; private set; } = false;
    public float CoinId { get; private set; }

    public void MoveToTarget(Vector3 targetPosition)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
        _coroutine = StartCoroutine(MoveCoroutine(targetPosition));
    }

    //public void MoveToBase()
    //{
    //    if (_coroutine != null)
    //    {
    //        StopCoroutine(_coroutine);
    //    }
    //    _coroutine = StartCoroutine(MoveCoroutine(_baseCoordinate.position));
    //}

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

    public void SetBaseCoordinate(Transform target)
    {
        _baseCoordinate = target;
    }
}
