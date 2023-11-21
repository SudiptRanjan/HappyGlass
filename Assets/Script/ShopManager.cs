using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShopItem
{
    public string name;
    // public int price;
    // public Sprite sprite;
    public Color color; // new color property
}
public class ShopManager : MonoBehaviour
{
    public List<ShopItem> shopItems;
    public List<ShopItem> ownedItems;
    public SpriteRenderer playerSpriteRenderer;
    public int playerBalance;

    public void BuyItem(ShopItem item)
    {
        // if (playerBalance >= item.price)
        {
            // playerBalance -= item.price;
            ownedItems.Add(item);
        }
    }

    public void SelectItem(ShopItem item)
    {
            // print("Selected " + item.name);

        // if (ownedItems.Contains(item))
        {
            playerSpriteRenderer.color = item.color;
            // print("Selected " + item.name);
        }
    }
    
    
    public void SelectItem2(string itemName)
    {
        ShopItem item = ownedItems.Find(x => x.name == itemName);
        Debug.Log("Selected " + item.name);
        if (item != null)
        {
            SelectItem(item);
            Debug.Log("Selected " + item.name);
        }
    }
    public void BuyItem2(string itemName)
    {
        ShopItem item = shopItems.Find(x => x.name == itemName);

        if (item != null)
        {
            BuyItem(item);
            // Debug.Log("Bought " + item.name);
        }
    }

}

