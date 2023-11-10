using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public List<ShopItem> shopItems;
    public List<ShopItem> ownedItems;
    public SpriteRenderer playerSpriteRenderer;
    public int playerBalance;

    public void BuyItem(ShopItem item)
    {
        if (playerBalance >= item.price)
        {
            playerBalance -= item.price;
            ownedItems.Add(item);
        }
    }

    public void SelectItem(ShopItem item)
    {
        if (ownedItems.Contains(item))
        {
            playerSpriteRenderer.sprite = item.sprite;
        }
    }
}

[System.Serializable]
public class ShopItem
{
    public string name;
    public int price;
    public Sprite sprite;
}
