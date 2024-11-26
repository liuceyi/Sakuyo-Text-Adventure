
class Equip: Item
{
    # region attr
    // 装备基础属性
    private int _HPMax;
    public int HPMax 
    {
        get {return _HPMax;}
        set {_HPMax = value;}
    }
    private int _MPMax;
    public int MPMax 
    {
        get {return _MPMax;}
        set {_MPMax = value;}
    }

    private int _ATK; // 基本物攻属性，影响物理类攻击和技能伤害
    public int ATK 
    {
        get {return _ATK;}
        set {_ATK = value;}
    }
    private int _DEF; // 基本护甲属性，格挡部分物理伤害
    public int DEF
    {
        get {return _DEF;}
        set {_DEF = value;}
    }
    int _AGI; // 基本敏捷属性，影响回合充能速度和闪避率
    public int AGI
    {
        get {return _AGI;}
        set {_AGI = value;}
    }
    int _INT; // 基本魔攻属性，影响魔法类攻击和技能伤害或效果
    public int INT
    {
        get {return _INT;}
        set {_INT = value;}
    }
    int _RES; // 基本魔抗属性，格挡部分魔法伤害，削弱受到的debuff效果
    public int RES
    {
        get {return _RES;}
        set {_RES = value;}
    }
    
    // 装备战斗属性
    private float _criticalRate; // 暴击率
    public float CriticalRate
    {
        get {return _criticalRate;}
        set {_criticalRate = value;}
    }
    private float _criticalPower; // 暴击系数
    public float CriticalPower
    {
        get {return _criticalPower;}
        set {_criticalPower = value;}
    }
    private float _escapeRate; // 闪避率
    public float EscapeRate
    {
        get {return _escapeRate;}
        set {_escapeRate = value;}
    }
    private float _phyPierceRate; // 物穿比例
    public float PhyPierceRate
    {
        get {return _phyPierceRate;}
        set {_phyPierceRate = value;}
    }
    private float _magPierceRate; // 法穿比例


    public float MagPierceRate
    {
        get {return _magPierceRate;}
        set {_magPierceRate = value;}
    }
    # endregion

    # region method
    
    public Equip(string name, ItemSlot itemSlot) : base(name, itemSlot) // 自动执行父类初始化
    {

    }
    # endregion
}