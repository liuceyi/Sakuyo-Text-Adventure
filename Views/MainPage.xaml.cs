using System.Diagnostics;

namespace SakuyoTxtAdvApp.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            MainSystem.Instance.Init("玩家");
        }
    }
}