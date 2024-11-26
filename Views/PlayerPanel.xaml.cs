using SakuyoTxtAdvApp.Models;
using SakuyoTxtAdvApp.ViewModels;
namespace SakuyoTxtAdvApp.Views;

public partial class PlayerPanel : ContentPage
{
	public PlayerPanel()
	{
		InitializeComponent();
        BindingContext = new PlayerInfoViewModel();
        skillsCollection.BindingContext = new ObservableSkillsViewModel();
    }
    protected override void OnAppearing()
    {
        //((PlayerInfo)BindingContext).LoadInfo();
    }

    private void LearnSkillButton_Clicked(object sender, EventArgs e)
    {

    }
}