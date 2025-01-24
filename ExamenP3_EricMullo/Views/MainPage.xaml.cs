namespace ExamenP3_EricMullo.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnBuscarClicked(object sender, EventArgs e)
        {
            string pais = emullo_entryPais.Text;

            if (!string.IsNullOrWhiteSpace(pais))
            {
                emullo_lblResultado.Text = $"Resultado de la búsqueda para: {pais}";
            }
            else
            {
                emullo_lblResultado.Text = "Por favor, ingrese un país.";
            }
        }

        private void OnLimpiarClicked(object sender, EventArgs e)
        {
            emullo_entryPais.Text = string.Empty;
            emullo_lblResultado.Text = string.Empty;
        }
    }
}
