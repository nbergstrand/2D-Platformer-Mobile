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
    public int Gems { private set; get; }
    public static Action<int> OnGemAmountChange;

    public bool HasFlameSword { get; private set; }
    public bool HasBootsOfFlight { get; private set; }
    public bool HasKeyToCastle { get; private set; }


    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        OnGemAmountChange(Gems);
    }

    public void UpdateGemAmount(int amount)
    {
        Gems += amount;

        if(OnGemAmountChange != null)
        {
            OnGemAmountChange(Gems);
        }
    }

    public void AddItem(int item)
    {
        switch (item)
        {
            case 0:
                HasFlameSword = true;
                break;

            case 1:
                HasBootsOfFlight = true;
                break;

            case 2:
                HasKeyToCastle = true;
                break;
        }

        Debug.Log("Bought item " + item);
    }

    
}
