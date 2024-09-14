using CommunityToolkit.Mvvm.ComponentModel;

namespace MyFinanceManager.Presentation;

public class HomeViewModel : ObservableObject
{
    public string Title { get; set; } = "Home";
    
    public HomeViewModel()
    {
    }
}