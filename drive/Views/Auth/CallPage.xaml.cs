namespace drive.Auth;

public partial class CallPage : ContentPage
{
	public CallPage()
	{
		InitializeComponent();
	}

    private void FinishReg_Clicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new MainPage());
    }
}