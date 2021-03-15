using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject shopPanel;
    public int currentSelectedItem;
    public int currentItemCost;

    private Player _player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _player = collision.GetComponent<Player>();
        if (_player) 
        {
            UIManager.Instance.OpenShop(_player.diamonds);
            shopPanel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>())
        {
            shopPanel.SetActive(false);
        }
    }

    public void SelectItem(int itemNumber)
    {
        switch (itemNumber)
        {
            case 0:
                UIManager.Instance.UpdateShopSelection(73);
                currentSelectedItem = 0;
                currentItemCost = 200;
                break;
            case 1:
                UIManager.Instance.UpdateShopSelection(-35);
                currentSelectedItem = 1;
                currentItemCost = 400;
                break;
            case 2:
                UIManager.Instance.UpdateShopSelection(-145);
                currentSelectedItem = 2;
                currentItemCost = 100;
                break;
            default:
                break;
        }
        //Debug.Log("peidei");
    }

    public void BuyItem()
    {
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        if (player.diamonds >= currentItemCost)
        {
            if (currentSelectedItem == 2)
            {
                GameManager.Instance.HasKeyToCastle = true;
            }
            player.diamonds -= currentItemCost;
            shopPanel.SetActive(false);
        }
        else
        {
            shopPanel.SetActive(false);
        }
    }
}
