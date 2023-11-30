using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Personal_Supervisor_Software
{
    public partial class EditUsers : Window
    {
        private Menu menu;
        private string selectedRole;
        private TextBox newUoHIDTextBox;
        private TextBox newPasswordTextBox;
        private TextBox newEmailTextBox;
        private TextBox newFirstNameTextBox;
        private TextBox newLastNameTextBox;

        public EditUsers(Menu menu)
        {
            InitializeComponent();

            this.menu = menu;

            Uri windowIcon = new Uri("pack://application:,,,/Personal Supervisor Software;component/UoHArms.svg.ico");
            this.Icon = BitmapFrame.Create(windowIcon);

            Canvas editUsersCanvas = new Canvas();
            this.Content = editUsersCanvas;

            Image uohLogo = new Image
            {
                Source = new BitmapImage(new Uri("pack://application:,,,/Personal Supervisor Software;component/UoHLogoNB.png")),
                Width = 175,
                Height = 175
            };
            Canvas.SetLeft(uohLogo, 5);
            Canvas.SetTop(uohLogo, -40);

            editUsersCanvas.Children.Add(uohLogo);

            TextBlock engageLink = new TextBlock
            {
                Text = "EngageLink",
                Foreground = Brushes.AntiqueWhite,
                FontFamily = new FontFamily("Microsoft JhengHei"),
                FontSize = 28
            };
            Canvas.SetRight(engageLink, 10);
            Canvas.SetTop(engageLink, 10);

            editUsersCanvas.Children.Add(engageLink);

            Button backButton = new Button
            {
                Content = "Back",
                FontFamily = new FontFamily("Microsoft JhengHei"),
                FontSize = 12,
                Foreground = Brushes.White,
                Background = Brushes.DimGray,
                BorderBrush = Brushes.White,
                Width = 75,
                Height = 50
            };

            Canvas.SetLeft(backButton, (this.Width - backButton.Width) / 2);
            Canvas.SetTop(backButton, 20);

            backButton.Click += BackButton_Click;
            editUsersCanvas.Children.Add(backButton);

            ComboBox newRoleDropDown = new ComboBox
            {
                Width = 300,
                Height = 30,
                FontFamily = new FontFamily("Microsoft JhengHei"),
                FontSize = 18
            };

            Canvas.SetLeft(newRoleDropDown, (this.Width - newRoleDropDown.Width) / 2 + 80);
            Canvas.SetTop(newRoleDropDown, (this.Height - newRoleDropDown.Height) / 2 - 80);

            ComboBoxItem roleStudent = new ComboBoxItem { Content = "STUDENT" };
            ComboBoxItem rolePersonalSupervisor = new ComboBoxItem { Content = "PERSONAL SUPERVISOR" };
            ComboBoxItem roleSeniorTutor = new ComboBoxItem { Content = "SENIOR TUTOR" };

            newRoleDropDown.Items.Add(roleStudent);
            newRoleDropDown.Items.Add(rolePersonalSupervisor);
            newRoleDropDown.Items.Add(roleSeniorTutor);

            newRoleDropDown.SelectionChanged += NewRoleDropDown_SelectionChanged;

            editUsersCanvas.Children.Add(newRoleDropDown);

            TextBlock newRoleLabel = new TextBlock
            {
                Text = "User's Role:",
                Width = 200,
                Height = 30,
                FontFamily = new FontFamily("Microsoft JhengHei"),
                FontSize = 14,
                Foreground = Brushes.Black,
            };
            Canvas.SetLeft(newRoleLabel, 50);
            Canvas.SetTop(newRoleLabel, (this.Height - newRoleDropDown.Height) / 2 - 75);

            editUsersCanvas.Children.Add(newRoleLabel);

            newUoHIDTextBox = new TextBox
            {
                Text = "",
                FontFamily = new FontFamily("Microsoft JhengHei"),
                FontSize = 18,
                TextWrapping = TextWrapping.Wrap,
                Width = 300,
                Height = 30
            };

            Canvas.SetLeft(newUoHIDTextBox, (this.Width - newUoHIDTextBox.Width) / 2 + 80);
            Canvas.SetTop(newUoHIDTextBox, (this.Height - newUoHIDTextBox.Height) / 2 - 40);

            editUsersCanvas.Children.Add(newUoHIDTextBox);

            TextBlock newUoHIDLabel = new TextBlock
            {
                Text = "User's UoH ID:",
                Width = 200,
                Height = 30,
                FontFamily = new FontFamily("Microsoft JhengHei"),
                FontSize = 14,
                Foreground = Brushes.Black,
            };
            Canvas.SetLeft(newUoHIDLabel, 50);
            Canvas.SetTop(newUoHIDLabel, (this.Height - newUoHIDTextBox.Height) / 2 - 35);

            editUsersCanvas.Children.Add(newUoHIDLabel);

            newPasswordTextBox = new TextBox
            {
                Text = "",
                FontFamily = new FontFamily("Microsoft JhengHei"),
                FontSize = 18,
                TextWrapping = TextWrapping.Wrap,
                Width = 300,
                Height = 30
            };

            Canvas.SetLeft(newPasswordTextBox, (this.Width - newPasswordTextBox.Width) / 2 + 80);
            Canvas.SetTop(newPasswordTextBox, (this.Height - newPasswordTextBox.Height) / 2);

            editUsersCanvas.Children.Add(newPasswordTextBox);

            TextBlock newPasswordLabel = new TextBlock
            {
                Text = "User's Password:",
                Width = 200,
                Height = 30,
                FontFamily = new FontFamily("Microsoft JhengHei"),
                FontSize = 14,
                Foreground = Brushes.Black,
            };
            Canvas.SetLeft(newPasswordLabel, 50);
            Canvas.SetTop(newPasswordLabel, (this.Height - newPasswordTextBox.Height) / 2 + 5);

            editUsersCanvas.Children.Add(newPasswordLabel);

            newEmailTextBox = new TextBox
            {
                Text = "",
                FontFamily = new FontFamily("Microsoft JhengHei"),
                FontSize = 18,
                TextWrapping = TextWrapping.Wrap,
                Width = 300,
                Height = 30
            };

            Canvas.SetLeft(newEmailTextBox, (this.Width - newEmailTextBox.Width) / 2 + 80);
            Canvas.SetTop(newEmailTextBox, (this.Height - newEmailTextBox.Height) / 2 + 40);

            editUsersCanvas.Children.Add(newEmailTextBox);

            TextBlock newEmailLabel = new TextBlock
            {
                Text = "User's Email:",
                Width = 200,
                Height = 30,
                FontFamily = new FontFamily("Microsoft JhengHei"),
                FontSize = 14,
                Foreground = Brushes.Black,
            };
            Canvas.SetLeft(newEmailLabel, 50);
            Canvas.SetTop(newEmailLabel, (this.Height - newEmailTextBox.Height) / 2 + 45);

            editUsersCanvas.Children.Add(newEmailLabel);

            newFirstNameTextBox = new TextBox
            {
                Text = "",
                FontFamily = new FontFamily("Microsoft JhengHei"),
                FontSize = 18,
                TextWrapping = TextWrapping.Wrap,
                Width = 300,
                Height = 30
            };

            Canvas.SetLeft(newFirstNameTextBox, (this.Width - newFirstNameTextBox.Width) / 2 + 80);
            Canvas.SetTop(newFirstNameTextBox, (this.Height - newFirstNameTextBox.Height) / 2 + 80);

            editUsersCanvas.Children.Add(newFirstNameTextBox);

            TextBlock newFirstNameLabel = new TextBlock
            {
                Text = "User's First Name:",
                Width = 200,
                Height = 30,
                FontFamily = new FontFamily("Microsoft JhengHei"),
                FontSize = 14,
                Foreground = Brushes.Black,
            };
            Canvas.SetLeft(newFirstNameLabel, 50);
            Canvas.SetTop(newFirstNameLabel, (this.Height - newFirstNameTextBox.Height) / 2 + 85);

            editUsersCanvas.Children.Add(newFirstNameLabel);

            newLastNameTextBox = new TextBox
            {
                Text = "",
                FontFamily = new FontFamily("Microsoft JhengHei"),
                FontSize = 18,
                TextWrapping = TextWrapping.Wrap,
                Width = 300,
                Height = 30
            };

            Canvas.SetLeft(newLastNameTextBox, (this.Width - newLastNameTextBox.Width) / 2 + 80);
            Canvas.SetTop(newLastNameTextBox, (this.Height - newLastNameTextBox.Height) / 2 + 120);

            editUsersCanvas.Children.Add(newLastNameTextBox);

            TextBlock newLastNameLabel = new TextBlock
            {
                Text = "User's Last Name:",
                Width = 200,
                Height = 30,
                FontFamily = new FontFamily("Microsoft JhengHei"),
                FontSize = 14,
                Foreground = Brushes.Black,
            };
            Canvas.SetLeft(newLastNameLabel, 50);
            Canvas.SetTop(newLastNameLabel, (this.Height - newLastNameTextBox.Height) / 2 + 125);

            editUsersCanvas.Children.Add(newLastNameLabel);

            Button submitButton = new Button
            {
                Content = "Submit",
                FontFamily = new FontFamily("Microsoft JhengHei"),
                FontSize = 12,
                Foreground = Brushes.White,
                Background = Brushes.DimGray,
                BorderBrush = Brushes.White,
                Width = 200,
                Height = 25
            };

            Canvas.SetLeft(submitButton, (this.Width - newLastNameTextBox.Width) / 2 + 130);
            Canvas.SetBottom(submitButton, 20);

            submitButton.Click += SubmitButton_Click;
            editUsersCanvas.Children.Add(submitButton);

            Button editUserButton = new Button
            {
                Content = "Edit Users",
                FontFamily = new FontFamily("Microsoft JhengHei"),
                FontSize = 12,
                Foreground = Brushes.White,
                Background = Brushes.DimGray,
                BorderBrush = Brushes.White,
                Width = 125,
                Height = 50
            };

            Canvas.SetRight(editUserButton, 25);
            Canvas.SetTop(editUserButton, 60);

            editUserButton.Click += EditUserButton_Click;
            editUsersCanvas.Children.Add(editUserButton);

        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            menu.NormalWindow();
            this.Close();

        }

        private void NewRoleDropDown_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            selectedRole = ((ComboBoxItem)comboBox.SelectedItem).Content.ToString();

        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {

            if (!IsValidUoHID(newUoHIDTextBox.Text))
            {
                MessageBox.Show("Your UoH ID must be an integer and contain 6 digits.", "ID Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!IsValidPassword(newPasswordTextBox.Text))
            {
                MessageBox.Show("Your password must be a mixture of both numerical and non-numerical characters.", "Password Error", MessageBoxButton.OK, MessageBoxImage.Error);
                MessageBox.Show("Your password must contain 8 to 24 characters.", "Password Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!IsValidEmail(newEmailTextBox.Text))
            {
                MessageBox.Show("Your email must end with \"@hull.ac.uk\".", "Email Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            string filePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "LoginDetails.txt");
            filePath = System.IO.Path.GetFullPath(filePath);

            using (StreamWriter sw = File.AppendText(filePath))
            {
                sw.WriteLine(selectedRole);
                sw.WriteLine(newUoHIDTextBox.Text);
                sw.WriteLine(newPasswordTextBox.Text);
                sw.WriteLine(newEmailTextBox.Text);
                sw.WriteLine(newFirstNameTextBox.Text);
                sw.WriteLine(newLastNameTextBox.Text);
            }

            string logsPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "Logs.txt");
            logsPath = System.IO.Path.GetFullPath(logsPath);

            DateTime todayDateAndTime = DateTime.Now;
            DateTime todayDate = todayDateAndTime.Date;

            using (StreamWriter sw = File.AppendText(logsPath))
            {
                sw.WriteLine(todayDate);
                sw.WriteLine("A new user was created: " + selectedRole + " " + newUoHIDTextBox.Text + " " + newFirstNameTextBox.Text + " " + newLastNameTextBox.Text + ".");
            }

            MessageBox.Show("The new User has been recorded. Have a pleasant day!", "Success!");
            this.Close();
        }

        private bool IsValidUoHID(string uohid)
        {
            return uohid.Length == 6 && uohid.All(char.IsDigit);
        }

        private bool IsValidPassword(string password)
        {
            return password.Length >= 8 && password.Length <= 24 &&
                   password.Any(char.IsDigit) &&
                   password.Any(char.IsLetter);
        }

        private bool IsValidEmail(string email)
        {
            return email.EndsWith("@hull.ac.uk", StringComparison.OrdinalIgnoreCase);
        }

        private void EditUserButton_Click(object sender, RoutedEventArgs e)
        {
            string filePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..");
            filePath = System.IO.Path.GetFullPath(filePath);

            Process.Start("explorer.exe", filePath);
        }
    }
}
