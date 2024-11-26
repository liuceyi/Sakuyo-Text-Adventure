using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class MainSystem: Singleton<MainSystem>
{
    public GameData? GameData;
    public long[] XPList = new long[81];
    public void Init(string fileName) 
    {
        // 初始化游戏系统
        for (int i = 0; i < 9*9; i++)
        {
            XPList[i] = (long)((i%9+1)*(Math.Pow(10, (i/9)+1)));
        }
        //Debug.WriteLine(string.Join(" ", XPList));
        GameData = new();
        // 尝试读取存档
        SaveSystem.Instance.Load(fileName);
        if (SaveSystem.Instance.Data is not null)
        {
            GameData.Player = SaveSystem.Instance.Data.Player;
            GameData.Stat = SaveSystem.Instance.Data.Stat;
            GameData.Config = SaveSystem.Instance.Data.Config;
        }
    }
}

class GameData 
{
    public Player Player = new();
    public Stat Stat = new();
    public Config Config = new();
}

class Stat 
{
}


