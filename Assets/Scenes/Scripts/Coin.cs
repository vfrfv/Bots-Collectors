using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private bool _isBusy = false;

    public void BorrowCoin()
    {
        _isBusy = true;
    }
}
