using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{

    int _itemToBuy = 0;
    int _currentItemCost = 250;

    private void OnTriggerEnter2D(Collider2D other)
    {

        if(other.tag == "Player")
        {
            UIManager.Instance.OpenShop();
        }
          
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            UIManager.Instance.CloseShop();

        }
           
    }

    public void SelectItem(int selectedItem)
    {
        switch(selectedItem)
        {
            case 0:
                UIManager.Instance.UpdateSelectionPosition(50);
                _itemToBuy = 0;
                _currentItemCost = 250;
                break;

            case 1:
                UIManager.Instance.UpdateSelectionPosition(3.5f);
                _itemToBuy = 1;
                _currentItemCost = 400;
                break;

            case 2:
                UIManager.Instance.UpdateSelectionPosition(-46);
                _itemToBuy = 2;
                _currentItemCost = 100;
                break;
        }
    }

    public void BuyItem()
    {

        if (_currentItemCost <= InventoryManager.Instance.Gems)
        {
            InventoryManager.Instance.UpdateGemAmount(-_currentItemCost);
            InventoryManager.Instance.AddItem(_itemToBuy);

        }
        else
        {
            Debug.Log("Not eough gems");
        }
    }
}

   


