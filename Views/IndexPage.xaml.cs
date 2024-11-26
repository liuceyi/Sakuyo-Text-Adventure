namespace SakuyoTxtAdvApp.Views;

public partial class IndexPage : ContentView
{
	public IndexPage()
	{
		InitializeComponent();
	}

    private async void PlayerPanelBtnClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//PlayerPanel");
    }
}