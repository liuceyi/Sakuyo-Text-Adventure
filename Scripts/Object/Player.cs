using SakuyoTxtAdvApp.Models;

class Player: Object // 实例化玩家时自动实例化玩家信息和背包
{
    public Inventory Inv = new();
    public Player(string name="玩家") : base(name)
    {

    }



    void learnSKill() 
    {

    }
    void removeSkill() 
    {
        
    }
};