using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    public event Action UnitHasArrived;

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Unit>(out Unit unit))
        {
            UnitHasArrived?.Invoke();
            _isInstalled = false;

            unit.BuildBase(transform);
            //Destroy(gameObject);
        }
    }
}
