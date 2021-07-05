using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamonds : MonoBehaviour
{
    [SerializeField]
    int _diamondAmount;

    InventoryManager _inventoryManager;

    private void Awake()
    {
        _inventoryManager = GameObject.FindObjectOfType<InventoryManager>();
        if (_inventoryManager == null)
            Debug.LogError("Not Inventory Manager found");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            _inventoryManager.UpdateDiamondAmount(_diamondAmount);
            Destroy(gameObject);
        }
    }

    public void SetAmount(int amount)
    {
        _diamondAmount = amount;
    }
}
