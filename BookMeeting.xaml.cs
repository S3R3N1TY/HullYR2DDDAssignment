using System;
using System.Collections.Generic;
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
    public partial class BookMeeting : Window
    {
        private Menu menu;
        private int bookMeetingID;
        private string bookMeetingFirstName;
        private string bookMeetingLastName;
        private TextBox recipientFirstNameTextBox;
        private TextBox recipientLastNameTextBox;
        private TextBox dateOfMeetingTextBox;
        private TextBox subjectOfMeetingTextBox;
        private string recipientFile;
        private string userFile;

        public BookMeeting(Menu menu, int menuID, string menuFirstName, string menuLastName)
        {
            InitializeComponent();

            this.menu = menu;
            bookMeetingID = menuID;
            bookMeetingFirstName = menuFirstName;
            bookMeetingLastName = menuLastName;

            Uri windowIcon = new Uri("pack://application:,,,/Personal Supervisor Software;component/UoHArms.svg.ico");
            this.Icon = BitmapFrame.Create(windowIcon);

            Canvas bookMeetingCanvas = new Canvas();
            this.Content = bookMeetingCanvas;

            Image uohLogo = new Image
            {
                Source = new BitmapImage(new Uri("pack://application:,,,/Personal Supervisor Software;component/UoHLogoNB.png")),
                Width = 175,
                Height = 175
            };
            Canvas.SetLeft(uohLogo, 5);
            Canvas.SetTop(uohLogo, -40);

            bookMeetingCanvas.Children.Add(uohLogo);

            TextBlock engageLink = new TextBlock
            {
                Text = "EngageLink",
                Foreground = Brushes.AntiqueWhite,
                FontFamily = new FontFamily("Microsoft JhengHei"),
                FontSize = 28
            };
            Canvas.SetRight(engageLink, 10);
            Canvas.SetTop(engageLink, 10);

            bookMeetingCanvas.Children.Add(engageLink);

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
            bookMeetingCanvas.Children.Add(backButton);

            recipientFirstNameTextBox = new TextBox
            {
                Text = "",
                FontFamily = new FontFamily("Microsoft JhengHei"),
                FontSize = 18,
                TextWrapping = TextWrapping.Wrap,
                Width = 300,
                Height = 30
            };

            Canvas.SetLeft(recipientFirstNameTextBox, (this.Width - recipientFirstNameTextBox.Width) / 2 + 80);
            Canvas.SetTop(recipientFirstNameTextBox, (this.Height - recipientFirstNameTextBox.Height) / 2 - 80);

            bookMeetingCanvas.Children.Add(recipientFirstNameTextBox);

            TextBlock recipientFirstNameLabel = new TextBlock
            {
                Text = "Recipient's First Name:",
                Width = 200,
                Height = 30,
                FontFamily = new FontFamily("Microsoft JhengHei"),
                FontSize = 14,
                Foreground = Brushes.Black,
            };
            Canvas.SetLeft(recipientFirstNameLabel, 30);
            Canvas.SetTop(recipientFirstNameLabel, (this.Height - recipientFirstNameTextBox.Height) / 2 - 75);

            bookMeetingCanvas.Children.Add(recipientFirstNameLabel);

            recipientLastNameTextBox = new TextBox
            {
                Text = "",
                FontFamily = new FontFamily("Microsoft JhengHei"),
                FontSize = 18,
                TextWrapping = TextWrapping.Wrap,
                Width = 300,
                Height = 30
            };

            Canvas.SetLeft(recipientLastNameTextBox, (this.Width - recipientLastNameTextBox.Width) / 2 + 80);
            Canvas.SetTop(recipientLastNameTextBox, (this.Height - recipientLastNameTextBox.Height) / 2 - 20);

            bookMeetingCanvas.Children.Add(recipientLastNameTextBox);

            TextBlock recipientLastNameLabel = new TextBlock
            {
                Text = "Recipient's Last Name:",
                Width = 200,
                Height = 30,
                FontFamily = new FontFamily("Microsoft JhengHei"),
                FontSize = 14,
                Foreground = Brushes.Black,
            };
            Canvas.SetLeft(recipientLastNameLabel, 30);
            Canvas.SetTop(recipientLastNameLabel, (this.Height - recipientLastNameTextBox.Height) / 2 - 15);

            bookMeetingCanvas.Children.Add(recipientLastNameLabel);

            dateOfMeetingTextBox = new TextBox
            {
                Text = "",
                FontFamily = new FontFamily("Microsoft JhengHei"),
                FontSize = 18,
                TextWrapping = TextWrapping.Wrap,
                Width = 300,
                Height = 30
            };

            Canvas.SetLeft(dateOfMeetingTextBox, (this.Width - dateOfMeetingTextBox.Width) / 2 + 80);
            Canvas.SetTop(dateOfMeetingTextBox, (this.Height - dateOfMeetingTextBox.Height) / 2 + 40);

            bookMeetingCanvas.Children.Add(dateOfMeetingTextBox);

            TextBlock dateOfMeetingLabel = new TextBlock
            {
                Text = "Date of Meeting:",
                Width = 200,
                Height = 30,
                FontFamily = new FontFamily("Microsoft JhengHei"),
                FontSize = 14,
                Foreground = Brushes.Black,
            };
            Canvas.SetLeft(dateOfMeetingLabel, 30);
            Canvas.SetTop(dateOfMeetingLabel, (this.Height - dateOfMeetingTextBox.Height) / 2 + 45);

            bookMeetingCanvas.Children.Add(dateOfMeetingLabel);

            subjectOfMeetingTextBox = new TextBox
            {
                Text = "",
                FontFamily = new FontFamily("Microsoft JhengHei"),
                FontSize = 18,
                TextWrapping = TextWrapping.Wrap,
                Width = 300,
                Height = 30
            };

            Canvas.SetLeft(subjectOfMeetingTextBox, (this.Width - subjectOfMeetingTextBox.Width) / 2 + 80);
            Canvas.SetTop(subjectOfMeetingTextBox, (this.Height - subjectOfMeetingTextBox.Height) / 2 + 100);

            bookMeetingCanvas.Children.Add(subjectOfMeetingTextBox);

            TextBlock subjectOfMeetingLabel = new TextBlock
            {
                Text = "Subject of Meeting:",
                Width = 200,
                Height = 30,
                FontFamily = new FontFamily("Microsoft JhengHei"),
                FontSize = 14,
                Foreground = Brushes.Black,
            };
            Canvas.SetLeft(subjectOfMeetingLabel, 30);
            Canvas.SetTop(subjectOfMeetingLabel, (this.Height - subjectOfMeetingTextBox.Height) / 2 + 105);

            bookMeetingCanvas.Children.Add(subjectOfMeetingLabel);

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

            Canvas.SetLeft(submitButton, (this.Width - subjectOfMeetingTextBox.Width) / 2 + 130);
            Canvas.SetBottom(submitButton, 20);

            submitButton.Click += SubmitButton_Click;
            bookMeetingCanvas.Children.Add(submitButton);

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            menu.NormalWindow();
            this.Close();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e )
        {
            string recipientFirstName = recipientFirstNameTextBox.Text;
            string recipientLastName = recipientLastNameTextBox.Text;
            string requestedDate = dateOfMeetingTextBox.Text;
            string requestedSubject = subjectOfMeetingTextBox.Text;

            try
            {
                string recipientFolderName = recipientFirstNameTextBox.Text + recipientLastNameTextBox.Text;
                string userFolderName = bookMeetingFirstName + bookMeetingLastName;

                string[] userRoles = { "PERSONAL SUPERVISOR", "SENIOR TUTOR", "STUDENT" };

                foreach (string role in userRoles)
                {
                    recipientFile = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "Users", role, recipientFolderName, "Meetings.txt");
                    recipientFile = System.IO.Path.GetFullPath(recipientFile);

                    break;
                }

                foreach (string role in userRoles)
                {
                    userFile = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "Users", role, userFolderName, "Meetings.txt");
                    userFile = System.IO.Path.GetFullPath(userFile);

                    break;
                }

                using (StreamWriter sw = File.AppendText(recipientFile))
                {
                    sw.WriteLine(bookMeetingFirstName);
                    sw.WriteLine(bookMeetingLastName);
                    sw.WriteLine(requestedDate);
                    sw.WriteLine(requestedSubject);
                }

                using (StreamWriter sw = File.AppendText(userFile))
                {
                    sw.WriteLine(recipientFirstName);
                    sw.WriteLine(recipientLastName);
                    sw.WriteLine(requestedDate);
                    sw.WriteLine(requestedSubject);
                }
            }
            catch
            {
                MessageBox.Show("Recipient cannot be found. Try checking your spelling for common errors.", "Data Error");
            }

            string logsPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "Logs.txt");
            logsPath = System.IO.Path.GetFullPath(logsPath);

            DateTime todayDateAndTime = DateTime.Now;
            DateTime todayDate = todayDateAndTime.Date;

            using (StreamWriter sw = File.AppendText(logsPath))
            {
                sw.WriteLine(todayDate);
                sw.WriteLine(bookMeetingFirstName + " " + bookMeetingLastName + " requested a meeting with " + recipientFirstName + " " + recipientLastName + " on " + dateOfMeetingTextBox.Text + " regarding " + subjectOfMeetingTextBox.Text + ".");
            }

            MessageBox.Show("Your meeting has been scheduled. Have a pleasant day!", "Success!");
            menu.NormalWindow();
            this.Close();

        }
    }
}
