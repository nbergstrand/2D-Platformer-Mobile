using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InventoryManager : MonoBehaviour
{

    private int _diamonds;
    public static Action<int> OnDiamondAmountChange;

    public void UpdateDiamondAmount(int amount)
    {
        _diamonds += amount;

        if(OnDiamondAmountChange != null)
        {
            OnDiamondAmountChange(_diamonds);
        }
    }
}
