namespace SakuyoTxtAdvApp.Models
{
    public class ObservableSkill
    {
        public string? ObName { get; set; }
        public bool IsEmpty { get; set; }
        public ObservableSkill(string name) 
        {
            ObName = name;
        }
    }
}
