using SakuyoTxtAdvApp.Models;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;


namespace SakuyoTxtAdvApp.ViewModels
{
    public class ObservableSkillsViewModel : INotifyCollectionChanged
    {
        public ObservableCollection<ObservableSkill> Skills { get; set; }
        public ObservableSkillsViewModel()
        {
            Skills = new();
            LoadSkills();
        }

        public void LoadSkills() 
        {
            if (MainSystem.Instance.GameData is null) return;
            
            for (int i = 0; i < MainSystem.Instance.GameData.Player.Skills.Count; i++)
            {
                object? skill = MainSystem.Instance.GameData.Player.Skills[i];
                if (skill is null)
                {
                    Skills.Add(new ObservableSkill("空技能栏") { IsEmpty = true });
                }
                else
                {
                    ObservableSkill obSkill = (ObservableSkill)skill;
                    obSkill.IsEmpty = false;
                    Skills.Add(obSkill);
                }
            }
            Debug.WriteLine($"Observable Skill Slots:{Skills.Count}");
        }

        # region INotifyCollectionChanged
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
