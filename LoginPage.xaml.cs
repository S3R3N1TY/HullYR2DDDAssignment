using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Personal_Supervisor_Software
{
    public partial class LoginPage : Window
    {
        TextBox idTextBox;
        PasswordBox passwordTextBox;
        public LoginPage()
        {
            InitializeComponent();

            Uri windowIcon = new Uri("pack://application:,,,/Personal Supervisor Software;component/UoHArms.svg.ico");
            this.Icon = BitmapFrame.Create(windowIcon);
            this.Background = new SolidColorBrush(Colors.LightGray);

            ColorAnimation loginPageBackgroundAnimation = new ColorAnimation
            {
                From = Colors.LightGray,
                To = Colors.Purple,
                Duration = TimeSpan.FromSeconds(2)
            };

            loginPageBackgroundAnimation.Completed += LoadLoginPageContents;
            this.Background.BeginAnimation(SolidColorBrush.ColorProperty, loginPageBackgroundAnimation);

        }

        private void LoadLoginPageContents(object loadLoginPageContentsObj, EventArgs loadLoginPageContentsEventArgs)
        {

            Canvas loginPageCanvas = new Canvas();
            this.Content = loginPageCanvas;

            Image uohLogo = new Image
            {
                Source = new BitmapImage(new Uri("pack://application:,,,/Personal Supervisor Software;component/UoHLogoNB.png")),
                Width = 175,
                Height = 175
            };
            Canvas.SetLeft(uohLogo, 5);
            Canvas.SetTop(uohLogo, -40);

            loginPageCanvas.Children.Add(uohLogo);

            TextBlock engageLink = new TextBlock
            {
                Text = "EngageLink",
                Foreground = Brushes.AntiqueWhite,
                FontFamily = new FontFamily("Microsoft JhengHei"),
                FontSize = 28
            };
            Canvas.SetRight(engageLink, 10);
            Canvas.SetTop(engageLink, 10);

            loginPageCanvas.Children.Add(engageLink);

            idTextBox = new TextBox
            {
                Text = "",
                FontFamily = new FontFamily("Microsoft JhengHei"),
                FontSize = 18,
                Width = 200,
                Height = 30,
            };

            Canvas.SetLeft(idTextBox, (this.Width - idTextBox.Width) / 2);
            Canvas.SetTop(idTextBox, (this.Height - idTextBox.Height) / 2 - 30);
            
            loginPageCanvas.Children.Add(idTextBox);

            TextBlock idLabel = new TextBlock
            {
                Text = "UoH ID:",
                Foreground = Brushes.Black,
                FontFamily = new FontFamily("Microsoft JhengHei"),
                FontSize = 18
            };
            Canvas.SetLeft(idLabel, ((this.Width - idTextBox.Width) / 2) - 70);
            Canvas.SetTop(idLabel, (this.Height - idTextBox.Height) / 2 - 30);

            loginPageCanvas.Children.Add(idLabel);

            passwordTextBox = new PasswordBox
            {
                Password = "",
                FontFamily = new FontFamily("Microsoft JhengHei"),
                FontSize = 12,
                Width = 200,
                Height = 30,
            };

            Canvas.SetLeft(passwordTextBox, (this.Width - passwordTextBox.Width) / 2);
            Canvas.SetTop(passwordTextBox, (this.Height - passwordTextBox.Height) / 2 + 30);

            loginPageCanvas.Children.Add(passwordTextBox);

            TextBlock passwordLabel = new TextBlock
            {
                Text = "Password:",
                Foreground = Brushes.Black,
                FontFamily = new FontFamily("Microsoft JhengHei"),
                FontSize = 18
            };
            Canvas.SetLeft(passwordLabel, (this.Width - passwordTextBox.Width) / 2 - 88);
            Canvas.SetTop(passwordLabel, (this.Height - passwordTextBox.Height) / 2 + 30);

            loginPageCanvas.Children.Add(passwordLabel);

            Button loginButton = new Button
            {
                Content = "Log In",
                FontFamily = new FontFamily("Microsoft JhengHei"),
                Width = 100,
                Height = 30
            };

            Canvas.SetLeft(loginButton, (this.Width - loginButton.Width) / 2);
            Canvas.SetTop(loginButton, (this.Height - loginButton.Height) / 2 + 90);

            loginPageCanvas.Children.Add(loginButton);

            loginButton.Click += LoginButtonClick;

            TextBlock queryText = new TextBlock
            {
                Text = "Forgot your password or want to register? Contact the software admin through ",
                Foreground = Brushes.Black,
                FontFamily = new FontFamily("Microsoft JhengHei"),
                FontSize = 11
            };

            Canvas.SetLeft(queryText, this.Width / 2 - 225);
            Canvas.SetTop(queryText, this.Height - 60);

            loginPageCanvas.Children.Add(queryText);

            Hyperlink hyperlink = new Hyperlink(new Run("MyHull"))
            {
                NavigateUri = new Uri("https://www.hull.ac.uk"),
            };

            hyperlink.RequestNavigate += (hyperlinkObj, hyperlinkEventArgs) =>
            {
                System.Diagnostics.Process.Start(hyperlinkEventArgs.Uri.ToString());
                hyperlinkEventArgs.Handled = true;
            };

            queryText.Inlines.Add(hyperlink);

        }

        private void LoginButtonClick(object LoginButtonClickObj, RoutedEventArgs LoginButtonClickEventArgs)
        {

            string idText = idTextBox.Text;
            string passwordText = passwordTextBox.Password;

            if (!IsValidID(idText) || !IsValidPassword(passwordText))
            {
                return;
            }

            string loginDetailsPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "LoginDetails.txt");
            loginDetailsPath = System.IO.Path.GetFullPath(loginDetailsPath);

            int idLineNumber = FindIDLineNumber(loginDetailsPath, idText);

            if (idLineNumber == -1)
            {
                MessageBox.Show("ID not found.", "ID Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string passwordStored = File.ReadLines(loginDetailsPath).ElementAt(idLineNumber + 1);
            if (passwordStored == passwordText)
            {
                string id = File.ReadLines(loginDetailsPath).ElementAt(idLineNumber);
                int parsedId = int.Parse(id);
                string email = File.ReadLines(loginDetailsPath).ElementAt(idLineNumber + 2);
                string firstName = File.ReadLines(loginDetailsPath).ElementAt(idLineNumber + 3);
                string lastName = File.ReadLines(loginDetailsPath).ElementAt(idLineNumber + 4);
                string accountType = File.ReadLines(loginDetailsPath).ElementAt(idLineNumber - 1);

                Menu menu = new Menu(parsedId, email, firstName, lastName, accountType);
                menu.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Incorrect Password.", "Password Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private bool IsValidID(string idText)
        {
            if (!int.TryParse(idText, out int idTextParsed) || idText.Length != 6)
            {
                MessageBox.Show("Your UoH ID must be an integer and contain 6 digits.", "ID Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        private bool IsValidPassword(string passwordText)
        {
            if (int.TryParse(passwordText, out _))
            {
                MessageBox.Show("Your password must be a mixture of both numerical and non-numerical characters.", "Password Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (passwordText.Length < 8 || passwordText.Length > 24)
            {
                MessageBox.Show("Your password must contain 8 to 24 characters.", "Password Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        private int FindIDLineNumber(string loginDetailsPath, string idText)
        {
            var lines = File.ReadAllLines(loginDetailsPath);
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains(idText))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
