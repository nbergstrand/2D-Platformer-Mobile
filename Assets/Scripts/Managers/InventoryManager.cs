using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InventoryManager : MonoBehaviour
{
    #region Singleton
    private static InventoryManager _instance;
    public static InventoryManager Instance { get{ return _instance; } }
    #endregion
    public int Diamonds { private set; get; }
    public static Action<int> OnDiamondAmountChange;

    private void Awake()
    {
        _instance = this;
    }

    public void UpdateDiamondAmount(int amount)
    {
        Diamonds += amount;

        if(OnDiamondAmountChange != null)
        {
            OnDiamondAmountChange(Diamonds);
        }
    }
}
