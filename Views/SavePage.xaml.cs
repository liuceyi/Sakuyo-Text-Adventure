namespace SakuyoTxtAdvApp.Views;

public partial class SavePage : ContentPage
{
    public SavePage()
	{
		InitializeComponent();
        
    }
    private void SaveButton_Clicked(object sender, EventArgs e)
    {
        // Save the file.
        SaveSystem.Instance.Save("save1.json");
    }

    private void LoadButton_Clicked(object sender, EventArgs e) 
    {
        SaveSystem.Instance.Load("save1.json");
    }

    private void DeleteButton_Clicked(object sender, EventArgs e)
    {
        // Delete the file.
        SaveSystem.Instance.Delete("save1.json");
        TextEditor.Text = string.Empty;
    }
}