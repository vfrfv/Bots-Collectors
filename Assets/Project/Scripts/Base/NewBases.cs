using System.Collections.Generic;
using UnityEngine;

public class NewBases : MonoBehaviour
{
    [SerializeField] private Base _prefabBase;
    [SerializeField] private Flag _flag;

    private void OnEnable()
    {
        _flag.UnitHasArrived += CreateNewBase;
    }

    private void OnDisable()
    {
        _flag.UnitHasArrived -= CreateNewBase;
    }

    private void CreateNewBase(Unit unit)
    {
        Base newBase = Instantiate(_prefabBase, _flag.transform.position, Quaternion.identity);
        unit.SetBaseCoordinate(newBase.transform);
        newBase.AssignUnit(unit);

        _flag.Retire();
    }
}
