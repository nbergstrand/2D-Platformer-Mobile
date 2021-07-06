using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamonds : MonoBehaviour
{
    [SerializeField]
    int _gemAmount;
       

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            InventoryManager.Instance.UpdateGemAmount(_gemAmount);
            Destroy(gameObject);
        }
    }

    public void SetAmount(int amount)
    {
        _gemAmount = amount;
    }
}
