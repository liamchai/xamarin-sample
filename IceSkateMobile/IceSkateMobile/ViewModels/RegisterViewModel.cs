using IceSkateMobile.Validations;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace IceSkateMobile.ViewModels
{
    public class RegisterViewModel : ObservableObject
    {

        private ValidatableObject<string> email;
        private ValidatableObject<string> name;
        private ValidatableObject<string> phonenumber;
        private ValidatableObject<string> password;
        private ValidatableObject<string> confirmPassword;

        public ValidatableObject<string> Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }

        public ValidatableObject<string> Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

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

        public ValidatableObject<string> ConfirmPassword
        {
            get => confirmPassword;
            set => SetProperty(ref confirmPassword, value);
        }

        public ICommand LoginCommand { get; }
        public ICommand RegisterCommand { get; }
        public ICommand ValidatePhonenumberCommand { get; }
        public ICommand ValidatePasswordCommand { get; }
        public ICommand ValidateConfirmPasswordCommand { get; }
        public ICommand ValidateNameCommand { get; }
        public ICommand ValidateEmailCommand { get; }

        public RegisterViewModel()
        {
            name = new ValidatableObject<string>();
            email = new ValidatableObject<string>();
            phonenumber = new ValidatableObject<string>();
            password = new ValidatableObject<string>();
            confirmPassword = new ValidatableObject<string>();

            LoginCommand = new Command(OnLoginClicked);
            RegisterCommand = new Command(OnRegisterClicked);
            ValidatePhonenumberCommand = new Command(OnPhonenumberTextChanged);
            ValidatePasswordCommand = new Command(OnPasswordTextChanged);
            ValidateConfirmPasswordCommand = new Command(OnConfirmPasswordTextChanged);
            ValidateNameCommand = new Command(OnNameTextChanged);
            ValidateEmailCommand = new Command(OnEmailTextChanged);

            AddValidations();
        }

        private void OnRegisterClicked(object obj)
        {
            bool isValid = Validate();
            if (!isValid)
            {
                return;
            }
            // if valid
            // TODO : send API
        }

        private async void OnLoginClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync("..");
        }

        private void OnNameTextChanged(object obj)
        {
            ValidateName();
        }

        private void OnEmailTextChanged(object obj)
        {
            ValidateEmail();
        }

        private void OnPhonenumberTextChanged(object obj)
        {
            ValidatePhonenumber();
        }

        private void OnPasswordTextChanged(object obj)
        {
            ValidatePassword();
            // trigger validation to check if password same as confirm password
            ValidateConfirmPassword();
        }

        private void OnConfirmPasswordTextChanged(object obj)
        {
            ValidateConfirmPassword();
            // trigger validation to check if password same as confirm password
            ValidatePassword();
        }

        private bool Validate()
        {
            bool isValidName = ValidateName();
            bool isValidEmail = ValidateEmail();
            bool isValidPhonenumber = ValidatePhonenumber();
            bool isValidPassword = ValidatePassword();
            bool isValidConfirmPassword = ValidateConfirmPassword();

            return isValidName && isValidEmail && isValidPhonenumber && isValidPassword && isValidConfirmPassword;
        }

        private bool ValidateName()
        {
            return name.Validate();
        }

        private bool ValidateEmail()
        {
            return email.Validate();
        }

        private bool ValidatePhonenumber()
        {
            return phonenumber.Validate();
        }

        private bool ValidatePassword()
        {
            return password.Validate();
        }

        private bool ValidateConfirmPassword()
        {
            return confirmPassword.Validate();
        }

        private void AddValidations()
        {
            email.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Email is required." });
            email.Validations.Add(new IsValidEmailRule<string> { ValidationMessage = "Invalid email." });
            name.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Name is required." });
            phonenumber.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Phonenumber is required." });
            password.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Password is required." });
            password.Validations.Add(new CompareRule<string>() { CompareFunction = () => confirmPassword.Value, ValidationMessage = "Password and Confirm Password must match" });
            confirmPassword.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Confirm Password is required." });
            confirmPassword.Validations.Add(new CompareRule<string>() { CompareFunction = () => password.Value, ValidationMessage = "Password and Confirm Password must match" });
        }
    }
}
