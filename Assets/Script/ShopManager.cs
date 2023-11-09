using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public List<Item> items;
    public SpriteRenderer pencilSpriteRenderer;
    public SpriteRenderer glassSpriteRenderer;
    public Color waterColor;

    // Call this method when an item is purchased from the shop
    public void OnItemPurchased(Item item)
    {
        switch (item.type)
        {
            case ItemType.Pencil:
                pencilSpriteRenderer.sprite = item.sprite;
                break;
            case ItemType.Glass:
                glassSpriteRenderer.sprite = item.sprite;
                break;
            case ItemType.WaterColor:
                waterColor = item.color;
                break;
            default:
                Debug.LogError("Unknown item type: " + item.type);
                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Populate the list of items with different types of pencils and glasses
        items = new List<Item>();
        items.Add(new Item(ItemType.Pencil, "Pencil 1", pencilSpriteRenderer.sprite));
        items.Add(new Item(ItemType.Pencil, "Pencil 2", Resources.Load<Sprite>("Pencil2")));
        items.Add(new Item(ItemType.Glass, "Glass 1", glassSpriteRenderer.sprite));
        items.Add(new Item(ItemType.Glass, "Glass 2", Resources.Load<Sprite>("Glass2")));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public enum ItemType
{
    Pencil,
    Glass,
    WaterColor
}

public class Item
{
    public ItemType type;
    public string name;
    public Sprite sprite;
    public Color color;

    public Item(ItemType type, string name, Sprite sprite)
    {
        this.type = type;
        this.name = name;
        this.sprite = sprite;
    }

    public Item(ItemType type, string name, Color color)
    {
        this.type = type;
        this.name = name;
        this.color = color;
    }
}
