using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace SakuyoTxtAdvApp.ViewModels
{
    internal class PlayerInfoViewModel: INotifyCollectionChanged // 顺序：读取存档（如有，无则创建新档、实例化角色）->读取角色信息
    {
        public string? Name { get; set; }
        public long XP { get; set; }
        public long XPMax { get; set; }
        public string? XPStr {  get; set; }
        public string? StageStr { get; set; }
        //public ObservableCollection<ObservableSkill> Skills { get; set; } = new();
        public PlayerInfoViewModel() 
        {
            LoadInfo();
        } 

        public void LoadInfo() 
        {
            //Skills.Clear();
            if (MainSystem.Instance.GameData is not null)
            {
                Name = MainSystem.Instance.GameData.Player.Name;
                XP = MainSystem.Instance.GameData.Player.XP;
                XPMax = MainSystem.Instance.XPList[MainSystem.Instance.GameData.Player.Lvl];
                XPStr = $"{XP}/{XPMax}";
                StageStr = MainSystem.Instance.GameData.Player.StageStr;
            }
            else 
            {
                Debug.WriteLine("读取MainSystem.GameData失败");
            } 
        }
        #region INotifyCollectionChanged
        public event PropertyChangedEventHandler? PropertyChanged;
        public event NotifyCollectionChangedEventHandler? CollectionChanged;

        protected void SetProperty<T>(ref T storage, T value, [CallerMemberName] string? propertyName = null)
        {
            if (Equals(storage, value)) return;

            storage = value;
            OnPropertyChanged(propertyName);
        }

        protected void OnPropertyChanged(string? propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
