using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public MeshRenderer _meshRenderer;

    public float Id { get; private set; } = 0;
    public bool IsUnique { get; private set; } = true;
    //public bool IsBusy { get; private set; } = false;

    public void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    public void AssignId(float currentId)
    {
        Id = currentId;
    }

    public void ChangeUniqueness()
    {
        IsUnique = !IsUnique;
    }

    //public void ChangeStatus()
    //{
    //    IsBusy = !IsBusy;
    //}

    public void ChangeColor()
    {
        _meshRenderer.material.color = Color.red;
    }
}
