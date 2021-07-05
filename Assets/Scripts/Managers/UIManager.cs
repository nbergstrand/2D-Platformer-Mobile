using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    Text _diamondText;


    private void Awake()
    {
        InventoryManager.OnDiamondAmountChange += UpdateUI;
    }
    private void UpdateUI(int amount)
    {
        _diamondText.text = "Diamonds: " + amount;
    }
}
