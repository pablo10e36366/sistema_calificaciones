namespace ortegas4
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnCalcularClicked(object? sender, EventArgs e)
        {
            string estudiante = pickerEstudiante.SelectedItem?.ToString() ?? "";
            string fecha = $"{dateFecha.Date:dd/MM/yyyy}";

            string seguimiento1Texto = txtSeguimiento1.Text?.Trim() ?? "";
            string examen1Texto = txtExamen1.Text?.Trim() ?? "";
            string seguimiento2Texto = txtSeguimiento2.Text?.Trim() ?? "";
            string examen2Texto = txtExamen2.Text?.Trim() ?? "";

            if (string.IsNullOrWhiteSpace(estudiante) ||
                string.IsNullOrWhiteSpace(seguimiento1Texto) ||
                string.IsNullOrWhiteSpace(examen1Texto) ||
                string.IsNullOrWhiteSpace(seguimiento2Texto) ||
                string.IsNullOrWhiteSpace(examen2Texto))
            {
                await DisplayAlert("Advertencia", "Por favor completa todos los campos.", "OK");
                return;
            }

            if (!double.TryParse(seguimiento1Texto, out double seguimiento1) ||
                !double.TryParse(examen1Texto, out double examen1) ||
                !double.TryParse(seguimiento2Texto, out double seguimiento2) ||
                !double.TryParse(examen2Texto, out double examen2))
            {
                await DisplayAlert("Advertencia", "Las notas deben ser valores numéricos.", "OK");
                return;
            }

            if (!ValidarRango(seguimiento1) ||
                !ValidarRango(examen1) ||
                !ValidarRango(seguimiento2) ||
                !ValidarRango(examen2))
            {
                await DisplayAlert("Advertencia", "Todas las notas deben estar entre 0 y 10.", "OK");
                return;
            }

            double notaParcial1 = (seguimiento1 * 0.3) + (examen1 * 0.2);
            double notaParcial2 = (seguimiento2 * 0.3) + (examen2 * 0.2);
            double notaFinal = notaParcial1 + notaParcial2;

            string estado;

            if (notaFinal >= 7)
            {
                estado = "APROBADO";
            }
            else if (notaFinal >= 5 && notaFinal <= 6.9)
            {
                estado = "COMPLEMENTARIO";
            }
            else
            {
                estado = "REPROBADO";
            }

            await DisplayAlert(
                "Resultado",
                $"Nombre: {estudiante}\n" +
                $"Fecha: {fecha}\n" +
                $"Nota Parcial 1: {notaParcial1:F2}\n" +
                $"Nota Parcial 2: {notaParcial2:F2}\n" +
                $"Nota Final: {notaFinal:F2}\n" +
                $"Estado: {estado}",
                "OK"
            );
        }

        private bool ValidarRango(double nota)
        {
            return nota >= 0 && nota <= 10;
        }
    }
}