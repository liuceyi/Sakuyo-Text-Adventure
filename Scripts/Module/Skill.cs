using System.Collections;

class SkillBase
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public enum SkillActType
    {
        Active, // 主动
        Passive, // 被动
        Auto, // 自动
    };
    public SkillActType ActType; // 技能释放类型
    public enum SkillConsumeType 
    {
        MP,
        HP,
        Free
    }
    public SkillConsumeType ConsumeType;
    public enum SkillTarget 
    {
        Self,
        Ally,
        Team,
        Enemy,
        AOE,
    }
    public SkillTarget Target;
    public enum SkillDmgType 
    {
        Attack,
        Physic,
        Magic,
        Heal,
        MagicAttack,
        PhysicAndMagicAttack,
        HealAttack,
    }
    public SkillDmgType DmgType;
    public enum SkillBuffType 
    {
    }
    public SkillBuffType BuffType;
    public bool HasBuff;
}

class Skill 
{
    public float cd;
    public bool IsCd;
    public ArrayList SkillList = new();
    public string Name;
    public string? Description { get; set; }
    public Skill(string name) 
    {
        Name = name;
    }
}

