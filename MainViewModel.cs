using System.Windows.Input;

namespace Navigation.WPF
{
    public class MainViewModel : ViewModelBase
    {
        public ICommand NavigateToFirstView { get; }
        public ICommand NavigateToSecondView { get; }
        public ICommand NavigateToThirdView { get; }

        public override string CurrentPage => "Main page";

        public INavigationService NavigationService { get; }

        public MainViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;

            NavigateToFirstView = Navigation(nameof(FirstView));
            NavigateToSecondView = Navigation(nameof(SecondView));
            NavigateToThirdView = Navigation(nameof(ThirdView));
        }

        private void NavigateTo(string route) => NavigationService.Navigate(route);

        private ICommand Navigation(string route)
        {
            return new RelayCommand(() => NavigateTo(route));
        }
    }
}