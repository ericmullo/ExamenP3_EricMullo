using ExamenTercerProgreso_Eric.ViewModels;
public partial class SavedPage : ContentPage
{
    public SavedPage(SavedViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}