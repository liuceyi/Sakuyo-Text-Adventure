

class Item 
{
    public enum ItemSlot {
        Item,
        Weapon,
        Head,
        Body,
        Leg,
        Feet,
        Hand,
        Necklace,
        Ring
    };
    static string[] _slotLabels = new string[] {
        "道具",
        "武器",
        "头部",
        "身体",
        "腿部",
        "脚部",
        "手部",
        "项链",
        "戒指"
    };
    // 物品基本属性
    string _name = "";
    public string Name 
    {
        get {return _name;}
    }
    private ItemSlot _slot;
    public ItemSlot Slot 
    {
        get {return _slot;}
    }
    // 物品商品属性
    int _price;
    public int Price 
    {
        get {return _price;}
        set {_price = value;}
    }
    // 物品装备属性

    # region method
    public Item(string name, ItemSlot itemSlot) 
    {
        _name = name;
        _slot = itemSlot;
    }
    public static string GetSlotName(ItemSlot itemSlot) 
    {
        return _slotLabels[(int)itemSlot];
    }
    # endregion
}