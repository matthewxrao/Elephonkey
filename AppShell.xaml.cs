using Elephonkey.Views;

namespace Elephonkey
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("article", typeof(ArticlePage));

            var getuserSavedkey = Preferences.Get("UserAlreadyloggedIn", false);

            if(getuserSavedkey == true)
            {
                MyAppShell.CurrentItem = HomeTab;
            }
            else
            {
                MyAppShell.CurrentItem = MyLoginPage;
            }

            this.HomeTab.Icon = ImageSource.FromResource("Elephonkey.Resources.Images.home.svg", this.GetType().Assembly);
            this.SurveyTab.Icon = ImageSource.FromResource("Elephonkey.Resources.Images.survey.png", this.GetType().Assembly);
            this.ArticlesTab.Icon = ImageSource.FromResource("Elephonkey.Resources.Images.articles.svg", this.GetType().Assembly);
            this.ResultsTab.Icon = ImageSource.FromResource("Elephonkey.Resources.Images.results.svg", this.GetType().Assembly);
            this.SettingsTab.Icon = ImageSource.FromResource("Elephonkey.Resources.Images.settings.svg", this.GetType().Assembly);
        }
    }
}