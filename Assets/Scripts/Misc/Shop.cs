using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
        
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
                break;

            case 1:
                UIManager.Instance.UpdateSelectionPosition(3.5f);
                break;

            case 2:
                UIManager.Instance.UpdateSelectionPosition(-46);
                break;
        }
    }

   

}
