using drive.Auth;
namespace drive;

public partial class RegistrationPage : ContentPage
{
	public RegistrationPage()
	{
		InitializeComponent();
	}

    private void OnPhoneChanhed(object sender, TextChangedEventArgs e)
    {
        var entry = (Entry)sender;
        var newText = e.NewTextValue;

        if (string.IsNullOrEmpty(newText) || !newText.StartsWith("+7"))
        {
            entry.Text = "+7";
            return;
        }

        if (newText.Length > 2)
        {
            var numbers = new string(newText.Substring(2).Where(char.IsDigit).ToArray());

            if (numbers.Length > 10)
                numbers = numbers.Substring(0, 10);

            entry.Text = "+7" + numbers;

            entry.CursorPosition = entry.Text.Length;
        }
    }

    private void ISVisiblePassword_button_Clicked(object sender, EventArgs e)
    {
        PasswordEntry.IsPassword = !PasswordEntry.IsPassword;
        AgainPasswordEntry.IsPassword = !AgainPasswordEntry.IsPassword;
    }

    private async void ContinueRegistration_button_Clicked(object sender, EventArgs e)
    {
       await Navigation.PushAsync(new CallPage());
    }

    private async void Login_button_Clicked(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new LoginPage());
    }


}