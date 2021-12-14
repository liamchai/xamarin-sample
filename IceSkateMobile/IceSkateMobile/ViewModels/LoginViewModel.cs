using IceSkateMobile.Validations;
using IceSkateMobile.Views;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace IceSkateMobile.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private ValidatableObject<string> phonenumber;
        private ValidatableObject<string> password;

        public ValidatableObject<string> Phonenumber
        {
            get => phonenumber;
            set => SetProperty(ref phonenumber, value);
        }

        public ValidatableObject<string> Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }

        public ICommand LoginCommand { get; }
        public ICommand RegisterCommand { get; }
        public ICommand ValidatePhonenumberCommand { get; }
        public ICommand ValidatePasswordCommand { get; }
        public ICommand PageAppearingCommand { get; }

        public LoginViewModel()
        {
            phonenumber = new ValidatableObject<string>();
            password = new ValidatableObject<string>();

            LoginCommand = new Command(OnLoginClicked);
            RegisterCommand = new Command(OnRegisterClicked);
            ValidatePhonenumberCommand = new Command(OnPhonenumberTextChanged);
            ValidatePasswordCommand = new Command(OnPasswordTextChanged);
            PageAppearingCommand = new Command(OnPageAppearing);

            AddValidations();
        }

        // TODO : need to fix this after meeting
        private void OnPageAppearing(object obj)
        {
            Phonenumber.Value = "";
            Phonenumber.IsValid = true;
            Password.Value = "";
            Password.IsValid = true;
        }

        private void OnPhonenumberTextChanged(object obj)
        {
            ValidatePhonenumber();
        }

        private void OnPasswordTextChanged(object obj)
        {
            ValidatePassword();
        }

        private async void OnLoginClicked(object obj)
        {
            bool isValid = Validate();
            if (!isValid)
            {
                // if fails return
                return;
            }
            // TODO : Sent API
            await Shell.Current.GoToAsync($"//{nameof(SettingPage)}");

            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            //await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }

        private async void OnRegisterClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"{nameof(RegisterPage)}");
        }

        private bool Validate()
        {
            bool isValidPhonenumber = ValidatePhonenumber();
            bool isValidPassword = ValidatePassword();

            return isValidPhonenumber && isValidPassword;
        }

        private bool ValidatePhonenumber()
        {
            return phonenumber.Validate();
        }

        private bool ValidatePassword()
        {
            return password.Validate();
        }

        private void AddValidations()
        {
            phonenumber.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Phonenumber is required." });
            password.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Password is required." });
        }

    }
}
