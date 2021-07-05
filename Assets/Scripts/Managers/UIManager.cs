using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region Singleton
    private static UIManager _instance;
    public static UIManager Instance
    {
        get{
            return _instance;
        }
    }
    #endregion
    [SerializeField]
    Text _diamondText;
    
    [SerializeField]
    GameObject _shop;
    
    [SerializeField]
    Text _shopGemAmount;

    [SerializeField]
    Image _selectionImage;

    private void Awake()
    {
        _instance = this;
        InventoryManager.OnDiamondAmountChange += UpdateUI;
    }
    private void UpdateUI(int amount)
    {
        _diamondText.text = "Gems: " + amount;
       
    }

    public void OpenShop()
    {
        _shop.SetActive(true);
        _shopGemAmount.text = "" + InventoryManager.Instance.Diamonds + "G";
    }

    public void CloseShop()
    {
        _shop.SetActive(false);

    }

    public void UpdateSelectionPosition(float yPosition)
    {
        _selectionImage.rectTransform.anchoredPosition = new Vector2(_selectionImage.rectTransform.anchoredPosition.x, yPosition);
    }
}
