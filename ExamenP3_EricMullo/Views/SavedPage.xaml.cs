namespace ExamenP3_EricMullo.Views
{
    public partial class SavedPage : ContentPage
    {
        public SavedPage(ExamenTercerProgreso_Eric.ViewModels.SavedViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}