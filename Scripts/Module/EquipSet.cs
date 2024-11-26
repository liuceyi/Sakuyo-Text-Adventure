using System.Collections.Generic;
using System;
class EquipSet
{
    # region attr
    public enum EquipSlot 
    {
        Weapon,
        Head,
        Body,
        Leg,
        Feet,
        Hand,
        Necklace,
        Ring
    }
    private Dictionary<EquipSlot, Equip?> _equips = new Dictionary<EquipSlot, Equip?>();

    private string[] _equipLabels = new string[] {
        "武器",
        "头部",
        "身体",
        "腿部",
        "脚部",
        "手部",
        "项链",
        "戒指"
    };

    public int HPMax 
    {
        get 
        {
            int totalHPMax = 0;
            foreach (var value in _equips.Values) 
            {
                if (value == null) continue;
                // Console.WriteLine("value = {0}", value);
                totalHPMax += value.HPMax;
            };
            return totalHPMax;
        }
    } 
    
    public int MPMax
    {
        get
        {
            int totalMPMax = 0;
            foreach (var value in _equips.Values) 
            {
                if (value == null) continue;
                // Console.WriteLine("value = {0}", value);
                totalMPMax += value.MPMax;
            };
            return totalMPMax;
        }
    }

    public int ATK 
    {
        get
        {
            int totalATK = 0;
            foreach (var value in _equips.Values) 
            {
                if (value == null) continue;
                // Console.WriteLine("value = {0}", value);
                totalATK += value.ATK;
            };
            return totalATK;
        }
    }
    public int DEF
    {
        get
        {
            int totalDEF = 0;
            foreach (var value in _equips.Values) 
            {
                if (value == null) continue;
                // Console.WriteLine("value = {0}", value);
                totalDEF += value.DEF;
            };
            return totalDEF;
        }
    }
    public int AGI 
    {
        get
        {
            int totalAGI = 0;
            foreach (var value in _equips.Values) 
            {
                if (value == null) continue;
                // Console.WriteLine("value = {0}", value);
                totalAGI += value.AGI;
            };
            return totalAGI;
        }
    }
    public int INT
    {
        get
        {
            int totalINT = 0;
            foreach (var value in _equips.Values) 
            {
                if (value == null) continue;
                // Console.WriteLine("value = {0}", value);
                totalINT += value.INT;
            };
            return totalINT;
        }
    }
    public int RES 
    {
        get
        {
            int totalRES = 0;
            foreach (var value in _equips.Values) 
            {
                if (value == null) continue;
                // Console.WriteLine("value = {0}", value);
                totalRES += value.RES;
            };
            return totalRES;
        }
    }
    public float CriticalRate
    {
        get
        {
            float totalCriticalRate = 0;
            foreach (var value in _equips.Values) 
            {
                if (value == null) continue;
                // Console.WriteLine("value = {0}", value);
                totalCriticalRate += value.CriticalRate;
            };
            return totalCriticalRate;
        }
    }
    public float CriticalPower
    {
        get
        {
            float totalCriticalPower = 0;
            foreach (var value in _equips.Values) 
            {
                if (value == null) continue;
                // Console.WriteLine("value = {0}", value);
                totalCriticalPower *= value.CriticalPower;
            };
            return totalCriticalPower;
        }
    }
    public float EscapeRate
    {
        get
        {
            float totalEscapeRate = 0;
            foreach (var value in _equips.Values) 
            {
                if (value == null) continue;
                // Console.WriteLine("value = {0}", value);
                totalEscapeRate *= value.EscapeRate;
            };
            return totalEscapeRate;
        }
    }
    public float PhyPierceRate
    {
        get
        {
            float totalPhyPierceRate = 0;
            foreach (var value in _equips.Values) 
            {
                if (value == null) continue;
                // Console.WriteLine("value = {0}", value);
                totalPhyPierceRate *= (1 + value.PhyPierceRate);
            };
            return totalPhyPierceRate;
        }
    }
    public float MagPierceRate
    {
        get
        {
            float totalMagPierceRate = 0;
            foreach (var value in _equips.Values) 
            {
                if (value == null) continue;
                // Console.WriteLine("value = {0}", value);
                totalMagPierceRate *= 1 + value.MagPierceRate;
            };
            return totalMagPierceRate;
        }
    }

    # endregion

    # region method
    public EquipSet() 
    {
        _equips[EquipSlot.Weapon] = null;
        _equips[EquipSlot.Head] = null;
        _equips[EquipSlot.Body] = null;
        _equips[EquipSlot.Leg] = null;
        _equips[EquipSlot.Feet] = null;
        _equips[EquipSlot.Hand] = null;
        _equips[EquipSlot.Necklace] = null;
        _equips[EquipSlot.Ring] = null;
        return;
    }
    public bool Equip(EquipSlot targetSlot, Equip newEquip) 
    {
        if (!_equips.ContainsKey(targetSlot)) return false;  
        _equips[targetSlot] = newEquip;
        return true;
    }
    public bool Unequip(EquipSlot targetSlot) 
    {
        if (!_equips.ContainsKey(targetSlot)) return false;  
        _equips[targetSlot] = null;
        return true;
    }
    # endregion
}