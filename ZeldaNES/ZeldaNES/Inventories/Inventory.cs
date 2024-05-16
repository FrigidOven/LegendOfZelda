using System.Collections.Generic;
using ZeldaNES.Items;
using ZeldaNES.Items.Classes;
using ZeldaNES.Players.Link;
using ZeldaNES.Players.Link.Classes;
using ZeldaNES.Weapons.Classes.Clock;

namespace ZeldaNES.Inventories;

public class Inventory
{
    private ILink link;

    // no need to check if link has a bow, we can just check if the primary item or secondary item is a bow.
    private IEquippableItem primaryItem;
    private IEquippableItem secondaryItem;
    public List<IItem> ItemsBuffer { get; set; }
    public List<IItem> Items { get; set; }

    private int rupees;
    private int bombs;
    private int keys;

    // will be kept track of in the UI
    public IEquippableItem GetPrimaryItem()
    {
        return primaryItem;
    }
    public IEquippableItem GetSecondaryItem()
    {
        return secondaryItem;
    }
    public int Rupees
    {
        get { return rupees; }
        set { rupees = value; }
    }
    public int Bombs
    {
        get { return bombs; }
        set { bombs = value; }
    }
    public int Keys
    {
        get { return keys; }
        set { keys = value; }
    }

    // includes bows, candles, meat, etc. Items that
    // are in the ui inventory box.
    private List<IEquippableItem> equippableItems = new List<IEquippableItem>();


    public List<IEquippableItem> EquippableItems() {
        return equippableItems;
    }

    public void AddItem(IItem item)
    {
        if (item is IPassiveItem) {
            ItemsBuffer.Add(item);
        }
        if (item is IHealingItem)
        {
            link.Health += ((IHealingItem)item).HealAmount;
            item.SetDeletable(true);
            return;
        }
        if (item is IMonetaryItem)
        {
            rupees += ((IMonetaryItem)item).Value;
            item.SetDeletable(true);
        }
        if (item is BombItem)
        {
            bombs += 1;
        }
        if (item is KeyItem)
        {
            keys += 1;
        }
        if (item is IEquippableItem)
        {
            equippableItems.Add((IEquippableItem)item);
            item.SetDeletable(true);
            return;
        }
    }

    public void CheatAdd()
    {
        keys += 10;
        bombs += 10;
        rupees += 10;
    }

    public Inventory(ILink link)
    {
        Items = new List<IItem>();
        ItemsBuffer = new List<IItem>();

        this.link = link;
        rupees = 10;
        bombs = 10;
    }
    public Inventory()
    {
        //this.link = new Link(); //TODO:?????
    }

    private static bool isBow(IItem i)
    {
        if (i is BowItem)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private static bool isClock(IItem i)
    {
        if (i is ClockItem)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool hasBow(List<IEquippableItem> i)
    {

        return EquippableItems().Exists(isBow);
        /*foreach (IEquippableItem item in equippableItems) {
            if (item is BowItem) {
                return true;
            }
        }
        return false;*/
    }

    public bool hasClock(List<IEquippableItem> i)
    {

        return EquippableItems().Exists(isClock);
    }
}