namespace WPF.Views.Frames;

public partial class Home : Page
{
    public Home()
    {
        InitializeComponent();
        this.DataContext = new HomeViewModel();
    }
}
