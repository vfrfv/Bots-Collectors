using System;
using UnityEngine;

public class Flag : MonoBehaviour
{
    public event Action<Unit> UnitHasArrived;

    private bool _isInstalled = false;
    private CapsuleCollider _capsuleCollider;

    public bool IsInstalled => _isInstalled;

    private void Awake()
    {
        _capsuleCollider = GetComponent<CapsuleCollider>();
        _capsuleCollider.enabled = false;
    }

    public void SetFlag()
    {
        _isInstalled = true;
        _capsuleCollider.enabled = true;
    }

    public void Retire()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Unit>(out Unit unit))
        {
            UnitHasArrived?.Invoke(unit);
            _isInstalled = false;
        }
    }
}
