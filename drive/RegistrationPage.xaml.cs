namespace drive;

public partial class RegistrationPage : ContentPage
{
	public RegistrationPage()
	{
		InitializeComponent();
	}

    private void ISVisiblePassword_button_Clicked(object sender, EventArgs e)
    {
        PasswordEntry.IsPassword = !PasswordEntry.IsPassword;
        ISVisiblePassword_button.Text = PasswordEntry.IsPassword ? "^": "^^";
    }

    private void AGAIN_ISVisiblePassword_button_Clicked(object sender, EventArgs e)
    {
        AgainPasswordEntry.IsPassword = !AgainPasswordEntry.IsPassword;
        AGAIN_ISVisiblePassword_button.Text = AgainPasswordEntry.IsPassword ? "^" : "^^";
    }

    private void ContinueRegistration_button_Clicked(object sender, EventArgs e)
    {

    }

    private void Login_button_Clicked(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new LoginPage());
    }
}