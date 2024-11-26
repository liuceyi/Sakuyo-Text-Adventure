namespace SakuyoTxtAdvApp.Models
{
    internal class PlayerInfo // 顺序：读取存档（如有，无则创建新档、实例化角色）->读取角色信息
    {
        public string? Name { get; set; }
        public long XP { get; set; }
        public long XPMax { get; set; }
        public string? XPStr {  get; set; }
        public string? StageStr { get; set; }
    }
}
