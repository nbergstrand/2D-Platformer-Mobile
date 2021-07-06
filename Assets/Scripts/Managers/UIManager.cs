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
    Text _gemText;
    
    [SerializeField]
    GameObject _shop;
    
    [SerializeField]
    Text _shopGemAmount;

    [SerializeField]
    Image _selectionImage;

    [SerializeField]
    Image _health;

    private void Awake()
    {
        _instance = this;
        InventoryManager.OnGemAmountChange += UpdateGemUI;
    }
    private void UpdateGemUI(int amount)
    {
        _gemText.text = "" + amount;
        _shopGemAmount.text = "" + InventoryManager.Instance.Gems + "G";

    }

    public void OpenShop()
    {
        _shop.SetActive(true);
        _shopGemAmount.text = "" + InventoryManager.Instance.Gems + "G";
    }

    public void CloseShop()
    {
        _shop.SetActive(false);

    }

    public void UpdateSelectionPosition(float yPosition)
    {
        _selectionImage.rectTransform.anchoredPosition = new Vector2(_selectionImage.rectTransform.anchoredPosition.x, yPosition);
    }

    public void UpdateHealthUI(int health)
    {
        _health.fillAmount = (float)health / 100;
    }
}
