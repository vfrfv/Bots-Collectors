using System.Collections;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Unit : MonoBehaviour
{
    [SerializeField] private Base _prefabBase;

    private float _speed = 3;
    private Coroutine _coroutine;
    private Transform _baseCoordinate;

    public Transform BaseCoordinate => _baseCoordinate;
    public bool IsSent { get; private set; } = false;
    public float CoinId { get; private set; }

    public void MoveToTarget(Transform target)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
        _coroutine = StartCoroutine(MoveCoroutine(target));
    }

    public void AssignId(float coinId)
    {
        CoinId = coinId;
    }

    public void ChangeStatus()
    {
        IsSent = !IsSent;
    }

    public void SetBaseCoordinate(Transform target)
    {
        _baseCoordinate = target;
    }

    private IEnumerator MoveCoroutine(Transform target)
    {
        while (transform.position != target.position)
        {
            transform.LookAt(target.position);
            transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

            yield return null;
        }
    }
}
