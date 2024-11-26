using System;
using System.Collections;
using System.Diagnostics;

class Object 
{
    # region attr
    // 实体基础属性
    private long _xp;
    public long XP 
    {
        get { return _xp; }
        set { _xp = value; }
    }
    private int _lvl 
    {
        get 
        {
            for (int i = 0; i < MainSystem.Instance.XPList.Length; i++)
            {
                if (XP < MainSystem.Instance.XPList[i]) 
                {
                    return i;
                }
            }
            return MainSystem.Instance.XPList.Length - 1;
        }
    }
    public int Lvl 
    {
        get { return _lvl; }
    }
    public enum StageDef 
    {
        F,
        E,
        D,
        C,
        B,
        A,
        S,
        SS,
        SSS
    }

    private static string[] _stageStr = new string[] 
    {
        "养气",
        "炼身",
        "勘灵",
        "蕴神",
        "破虚",
        "归元",
        "通玄",
        "求道",
        "武周"
    };

    public int Stage 
    {
        get 
        {
            StageDef stage = (StageDef)((Lvl - 1) / 9);
            return (int)stage;
        }
    }

    public string StageStr
    {
        get 
        {
            if (Lvl == 0) return "凡人";
            return $"{_stageStr[Stage]}{((Lvl - 1) % 9) + 1}重"; 
        }
    }

    private int _hp;
    public int HP 
    {
        get {return _hp;}
        set {_hp = value;}
    }
    private int _mp;
    public int MP 
    {
        get {return _mp;}
        set {_mp = value;}
    }
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
    
    // 实体战斗属性
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

    private ArrayList _skills = new();
    public ArrayList Skills 
    {
        get 
        {
            return _skills;
        }
    }
    private int _skillExtraSlots = 1;

    // 实体信息属性
    private string _name = "";
    public string Name 
    {
        get {return _name;} 
        set {_name = value;} 
    }

    // 实体装备栏
    public EquipSet EquipSet = new();
    # endregion

    # region method
    public Object(string name) 
    {
        Name = name;
        UpdateSkillSlots();
    }
    public int GetFullATK() 
    {
        return ATK + EquipSet.ATK;
    }
    public int GetFullDEF() 
    {
        return DEF + EquipSet.DEF;
    }
    public int GetFullAGI() 
    {
        return AGI + EquipSet.AGI;
    }
    public int GetFullINT() 
    {
        return INT + EquipSet.INT;
    }
    public int GetFullRES() 
    {
        return RES + EquipSet.RES;
    }



    /// <summary>仅计算受到的真实伤害，忽略伤害计算</summary>
    /// <param name="damage">受到的真实伤害</param>
    public void Hurt(int damage) 
    {
        HP -= damage;
    }

    /// <summary>普通攻击，默认视为物理伤害，可被护甲格挡</summary>
    /// <param name="target">目标实体</param>
    public void Attack(Object target) 
    {
        if (Util.RandTrigger(target.EscapeRate)) // 判定是否闪避成功
        {
            Console.WriteLine($"{target.Name}闪避了{Name}的攻击!");
            return;
        }
        int basicDmg = target.GetFullATK(); // 要修改为获取实体全物攻（基础物攻+装备物攻）
        int dmg = basicDmg;
        // 实体暴击判定
        bool isCritical = Util.RandTrigger(CriticalRate);
        float criticalPower = isCritical ? CriticalPower : 1.00f;
        dmg = (int)(dmg * criticalPower); // 如果随机数落在0-暴击率之间则乘以暴击倍率，否则乘以1
        // 实体穿甲计算: 暴击计算后伤害 - 受击方护甲值 *（1 - 攻击方穿甲系数）
        dmg -= (int)(target.GetFullDEF() * (1 - PhyPierceRate));

        Console.WriteLine($"{(isCritical?"暴击! ":"")}{Name}受到了{dmg}点伤害!");
        target.Hurt(dmg);
        return;
    }

    /// <summary>添加技能</summary>
    /// <param name="skillSlotIndex">目标技能槽位</param>
    /// <param name="skill">新增技能</param>
    public void AddSkill(int skillSlotIndex, Skill skill) 
    {
        if (_skills.Count <= skillSlotIndex) return;
        _skills[skillSlotIndex] = skill;
    }

    /// <summary>移除指定槽位技能</summary>
    /// <param name="skillSlotIndex">目标技能槽位</param>
    public void RemoveSkill(int skillSlotIndex) 
    {
        if (skillSlotIndex > _skills.Count) return;
        _skills[skillSlotIndex] = null;
    }

    /// <summary>清空所有技能</summary>
    public void ClearSkills() 
    {
        for (int i = 0; i < _skills.Count; i++)
        {
            _skills[i] = null;
        }
    }

    /// <summary>更新技能槽位数量（补充空槽位）</summary>
    public void UpdateSkillSlots() 
    {
        int maxSkillSlots = Stage + _skillExtraSlots;
        int initSkillSlots = _skills.Count;
        for (int i = 0; i < maxSkillSlots - initSkillSlots; i++)
        {
            _skills.Add(null);
        }
    }

    # endregion
};