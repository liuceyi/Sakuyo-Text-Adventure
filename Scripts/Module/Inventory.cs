using System.Collections;


class Inventory
{
    # region attr
    private Dictionary<Item.ItemSlot, ArrayList> _invList = new Dictionary<Item.ItemSlot, ArrayList>();

    public int Size 
    {
        get 
        {
            int totalNum = 0;
            foreach (var value in _invList.Values) 
            {
                if (value == null) continue;
                // Console.WriteLine("value = {0}", value);
                totalNum += value.Count;
            };
            return totalNum;
        }
    }

    # endregion

    # region method
    public Inventory() 
    {
        //foreach (Item.ItemSlot invSlot in Enum.GetValues(typeof(Item.ItemSlot)))
        //{
        //    _invList[invSlot] = new ArrayList();
        //}
        _invList[Item.ItemSlot.Weapon] = new ArrayList();
        _invList[Item.ItemSlot.Item] = new ArrayList();
        _invList[Item.ItemSlot.Head] = new ArrayList();
        _invList[Item.ItemSlot.Feet] = new ArrayList();
        _invList[Item.ItemSlot.Necklace] = new ArrayList();
        _invList[Item.ItemSlot.Leg] = new ArrayList();
        _invList[Item.ItemSlot.Body] = new ArrayList();
        _invList[Item.ItemSlot.Hand] = new ArrayList();
        _invList[Item.ItemSlot.Ring] = new ArrayList();
    }
    public int GetSlotNum(Item.ItemSlot invSlot) 
    {
        return _invList[invSlot].Count;
    }
    public bool AddSlotItem(Item newItem)
    {
        Item.ItemSlot invSlot = newItem.Slot;
        int originSlotNum = GetSlotNum(invSlot);
        _invList[invSlot].Add(newItem);
        return GetSlotNum(invSlot) - originSlotNum == 1;
    }
    public bool RemoveSlotItem(Item.ItemSlot invSlot, int itemIndex) 
    {
        int originSlotNum = GetSlotNum(invSlot);
        _invList[invSlot].RemoveAt(itemIndex);
        return GetSlotNum(invSlot) - originSlotNum == -1;
    }
    public bool RemoveSlotItem(Item.ItemSlot invSlot, Item targetItem) 
    {
        int originSlotNum = GetSlotNum(invSlot);
        try
        {
            _invList[invSlot].Remove(targetItem);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{targetItem.Name}移除失败, 原因为{ex.Message}");
        }
        
        return GetSlotNum(invSlot) - originSlotNum == -1;
    }
    
    public void GetInvSlots() 
    {
        foreach (Item.ItemSlot invSlot in Enum.GetValues(typeof(Item.ItemSlot)))
        {
            Console.WriteLine($"【{(int)invSlot}】{Item.GetSlotName(invSlot)}({GetSlotNum(invSlot)})");
        }
        
    }
    public void GetSlotItems(Item.ItemSlot invSlot) 
    {
        for (int i = 0; i < _invList[invSlot].Count; i++)
        {
            Item? item = (Item?)_invList[invSlot][i];
            if (item != null) Console.WriteLine($"【{i}】{item.Name}");
        }
    }
    # endregion
}