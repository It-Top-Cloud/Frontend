namespace drive;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

    private void Register_label_Clicked(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new RegistrationPage());
    }

    private void Login_button_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MainPage());
    }

    private void ForgotPassword_Tapped(object sender, TappedEventArgs e)
    {

    }

    private void LoginISVisiblePassword_button_Clicked(object sender, EventArgs e)
    {
        LoginPasswordEntry.IsPassword = !LoginPasswordEntry.IsPassword;
        LoginISVisiblePassword_button.Text = LoginPasswordEntry.IsPassword ? "^" : "^^";
    }
}