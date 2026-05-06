using ortegas4;

namespace ortegas4
{
    public partial class LoginPage : ContentPage
    {
        string[] usuarios = { "Carlos", "Ana", "Jose" };
        string[] claves = { "carlos123", "ana123", "jose123" };

        public LoginPage()
        {
            InitializeComponent();
        }

        private async void OnIngresarClicked(object? sender, EventArgs e)
        {
            string usuario = txtUsuario.Text?.Trim() ?? "";
            string password = txtPassword.Text?.Trim() ?? "";

            if (string.IsNullOrWhiteSpace(usuario) ||
                string.IsNullOrWhiteSpace(password))
            {
                await DisplayAlert("Advertencia", "Ingrese usuario y contraseña.", "OK");
                return;
            }

            bool accesoPermitido = false;

            for (int i = 0; i < usuarios.Length; i++)
            {
                if (usuario == usuarios[i] && password == claves[i])
                {
                    accesoPermitido = true;
                    break;
                }
            }

            if (accesoPermitido)
            {
                await DisplayAlert("Bienvenido", $"Bienvenido {usuario}", "OK");
                await Navigation.PushAsync(new MainPage());
            }
            else
            {
                await DisplayAlert("Error", "Usuario o contraseña incorrectos.", "OK");
            }
        }
    }
}