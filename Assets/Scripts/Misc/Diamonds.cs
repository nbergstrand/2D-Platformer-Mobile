using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamonds : MonoBehaviour
{
    [SerializeField]
    int _diamondAmount;
       

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            InventoryManager.Instance.UpdateDiamondAmount(_diamondAmount);
            Destroy(gameObject);
        }
    }

    public void SetAmount(int amount)
    {
        _diamondAmount = amount;
    }
}
