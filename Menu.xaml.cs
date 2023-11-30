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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Globalization;

namespace Personal_Supervisor_Software
{

    public partial class Menu : Window
    {
        private int menuID;
        private string menuEmail;
        private string menuFirstName;
        private string menuLastName;
        private string menuAccountType;

        public Menu(int newId, string email, string firstName, string lastName, string accountType)
        {

            InitializeComponent();

            Uri windowIcon = new Uri("pack://application:,,,/Personal Supervisor Software;component/UoHArms.svg.ico");
            this.Icon = BitmapFrame.Create(windowIcon);

            menuID = newId;
            menuEmail = email;
            menuFirstName = firstName;
            menuLastName = lastName;
            menuAccountType = accountType;

            Canvas menuCanvas = new Canvas();
            this.Content = menuCanvas;

            Image uohLogo = new Image
            {
                Source = new BitmapImage(new Uri("pack://application:,,,/Personal Supervisor Software;component/UoHLogoNB.png")),
                Width = 175,
                Height = 175
            };
            Canvas.SetLeft(uohLogo, 5);
            Canvas.SetTop(uohLogo, -40);

            menuCanvas.Children.Add(uohLogo);

            TextBlock engageLink = new TextBlock
            {
                Text = "EngageLink",
                Foreground = Brushes.AntiqueWhite,
                FontFamily = new FontFamily("Microsoft JhengHei"),
                FontSize = 28
            };
            Canvas.SetRight(engageLink, 10);
            Canvas.SetTop(engageLink, 10);

            menuCanvas.Children.Add(engageLink);

            TextBlock welcomeMessage = new TextBlock
            {
                Text = "Welcome, " + menuFirstName + " " + menuLastName,
                Width = 200,
                Height = 30,
                FontFamily = new FontFamily("Microsoft JhengHei"),
                FontSize = 16,
                Foreground = Brushes.Black,
            };
            Canvas.SetLeft(welcomeMessage, 10);
            Canvas.SetTop(welcomeMessage, 90);

            menuCanvas.Children.Add(welcomeMessage);

            TextBlock userIDMessage = new TextBlock
            {
                Text = "ID: " + menuAccountType + " " + menuID.ToString(),
                Width = 300,
                Height = 30,
                FontFamily = new FontFamily("Microsoft JhengHei"),
                FontSize = 16,
                Foreground = Brushes.Black,
            };
            Canvas.SetLeft(userIDMessage, 10);
            Canvas.SetTop(userIDMessage, 110);

            menuCanvas.Children.Add(userIDMessage);

            Button exitButton = new Button
            {
                Content = "Exit",
                FontFamily = new FontFamily("Microsoft JhengHei"),
                FontSize = 12,
                Foreground = Brushes.White,
                Background = Brushes.DimGray,
                BorderBrush = Brushes.White,
                Width = 75,
                Height = 50
            };

            Canvas.SetLeft(exitButton, (this.Width - exitButton.Width) / 2);
            Canvas.SetTop(exitButton, 20);

            exitButton.Click += ExitButton_Click;
            menuCanvas.Children.Add(exitButton);

            TextBlock quoteBox = new TextBlock
            {
                Text = QuoteGeneration(),
                Width = 225,
                Height = 250,
                FontFamily = new FontFamily("Malgun Gothic"),
                FontSize = 16,
                FontStyle = FontStyles.Italic,
                Foreground = Brushes.Black,
                TextWrapping = TextWrapping.Wrap
            };
            Canvas.SetLeft(quoteBox, 10);
            Canvas.SetTop(quoteBox, 150);

            menuCanvas.Children.Add(quoteBox);

            Button thoughtsAndFeelingsAddButton = new Button
            {
                Content = "How are you feeling today?",
                FontFamily = new FontFamily("Microsoft JhengHei"),
                FontSize= 12,
                Foreground = Brushes.White,
                Background = Brushes.DimGray,
                BorderBrush = Brushes.White,
                Width = 200,
                Height = 50
            };

            Canvas.SetLeft(thoughtsAndFeelingsAddButton, (this.Width - thoughtsAndFeelingsAddButton.Width) / 2 + 80);
            Canvas.SetTop(thoughtsAndFeelingsAddButton, 80);

            thoughtsAndFeelingsAddButton.Click += ThoughtsAndFeelingsAddButton_Click;
            menuCanvas.Children.Add(thoughtsAndFeelingsAddButton);

            Button thoughtsAndFeelingsDiaryButton = new Button
            {
                Content = "Thoughts and Feelings Diary",
                FontFamily = new FontFamily("Microsoft JhengHei"),
                FontSize = 12,
                Foreground = Brushes.White,
                Background = Brushes.DimGray,
                BorderBrush = Brushes.White,
                Width = 200,
                Height = 50
            };

            Canvas.SetLeft(thoughtsAndFeelingsDiaryButton, (this.Width - thoughtsAndFeelingsDiaryButton.Width) / 2 + 80);
            Canvas.SetTop(thoughtsAndFeelingsDiaryButton, 135);

            thoughtsAndFeelingsDiaryButton.Click += ThoughtsAndFeelingsDiaryButton_Click;
            menuCanvas.Children.Add(thoughtsAndFeelingsDiaryButton);

            Button bookMeetingButton = new Button
            {
                Content = "Book a Meeting",
                FontFamily = new FontFamily("Microsoft JhengHei"),
                FontSize = 12,
                Foreground = Brushes.White,
                Background = Brushes.DimGray,
                BorderBrush = Brushes.White,
                Width = 200,
                Height = 50
            };

            Canvas.SetLeft(bookMeetingButton, (this.Width - bookMeetingButton.Width) / 2 + 80);
            Canvas.SetTop(bookMeetingButton, 190);

            bookMeetingButton.Click += BookMeetingButton_Click;
            menuCanvas.Children.Add(bookMeetingButton);

            Button viewMeetingsButton = new Button
            {
                Content = "View Meetings",
                FontFamily = new FontFamily("Microsoft JhengHei"),
                FontSize = 12,
                Foreground = Brushes.White,
                Background = Brushes.DimGray,
                BorderBrush = Brushes.White,
                Width = 200,
                Height = 50
            };

            Canvas.SetLeft(viewMeetingsButton, (this.Width - viewMeetingsButton.Width) / 2 + 80);
            Canvas.SetTop(viewMeetingsButton, 245);

            viewMeetingsButton.Click += ViewMeetingsButton_Click;
            menuCanvas.Children.Add(viewMeetingsButton);

            Button viewInteractionsButton = new Button
            {
                Content = "View Interactions",
                FontFamily = new FontFamily("Microsoft JhengHei"),
                FontSize = 12,
                Foreground = Brushes.White,
                Background = Brushes.DimGray,
                BorderBrush = Brushes.White,
                Width = 200,
                Height = 50
            };

            Canvas.SetLeft(viewInteractionsButton, (this.Width - viewInteractionsButton.Width) / 2 + 80);
            Canvas.SetTop(viewInteractionsButton, 300);

            viewInteractionsButton.Click += ViewInteractionsButton_Click;
            menuCanvas.Children.Add(viewInteractionsButton);

            Button editUsersButton = new Button
            {
                Content = "Edit Users",
                FontFamily = new FontFamily("Microsoft JhengHei"),
                FontSize = 12,
                Foreground = Brushes.White,
                Background = Brushes.DimGray,
                BorderBrush = Brushes.White,
                Width = 200,
                Height = 50
            };

            Canvas.SetLeft(editUsersButton, (this.Width - editUsersButton.Width) / 2 + 80);
            Canvas.SetTop(editUsersButton, 355);

            editUsersButton.Click += EditUsersButton_Click;
            menuCanvas.Children.Add(editUsersButton);

            string selectedFile = "";
            string folderName = "";
            int lineCounter = 0;
            int dateLine = 0;
            string storedDate = "";

            switch (menuAccountType)
            {
                case "STUDENT":
                    viewInteractionsButton.Visibility = Visibility.Collapsed;
                    editUsersButton.Visibility = Visibility.Collapsed;

                    folderName = menuFirstName + menuLastName;
                    selectedFile = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "Users", "STUDENT", folderName, "ThoughtsAndFeelings.txt");
                    selectedFile = System.IO.Path.GetFullPath(selectedFile);
                    using (var reader = new StreamReader(selectedFile))
                    {
                        while (reader.ReadLine() != null)
                        {
                            lineCounter++;
                        }
                    }
                    dateLine = lineCounter - 4;
                    storedDate = File.ReadLines(selectedFile).ElementAt(dateLine);

                    if (DateTime.TryParse(storedDate, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime storedDateTime))
                    {
                        DateTime currentDateTime = DateTime.Now;
                        TimeSpan difference = currentDateTime - storedDateTime;
                        if (difference.TotalDays >= 7)
                        {
                            DispatcherTimer colorChangeTimer = new DispatcherTimer();
                            colorChangeTimer.Interval = TimeSpan.FromMilliseconds(500); // Half-second interval
                            colorChangeTimer.Tick += (sender, e) => ColorChangeTimer_Tick(thoughtsAndFeelingsAddButton, e);
                            colorChangeTimer.Start();
                        }
                    }
                    break;

                case "PERSONAL SUPERVISOR":
                    thoughtsAndFeelingsAddButton.Visibility = Visibility.Collapsed;
                    viewInteractionsButton.Visibility = Visibility.Collapsed;
                    editUsersButton.Visibility = Visibility.Collapsed;
                    break;

                case "SENIOR TUTOR":
                    thoughtsAndFeelingsAddButton.Visibility = Visibility.Collapsed;
                    editUsersButton.Visibility = Visibility.Collapsed;
                    break;

                case "SYSTEMS ADMINISTRATOR":
                    thoughtsAndFeelingsAddButton.Visibility = Visibility.Collapsed;
                    thoughtsAndFeelingsDiaryButton.Visibility = Visibility.Collapsed;
                    bookMeetingButton.Visibility = Visibility.Collapsed;
                    viewMeetingsButton.Visibility = Visibility.Collapsed;
                    viewInteractionsButton.Visibility = Visibility.Collapsed;
                    break;
            }



        }

        public void NormalWindow()
        {
            this.WindowState = WindowState.Normal;
        }

        private string QuoteGeneration()
        {
            string quotesPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "Quotes.txt");
            quotesPath = System.IO.Path.GetFullPath(quotesPath);
            string[] lines = File.ReadAllLines(quotesPath);
            int numberOfLines = lines.Length;

            Random random = new Random();
            int quoteLineNumber = random.Next(0, numberOfLines);

            string quote = lines[quoteLineNumber];

            return quote;
        }

        private void ColorChangeTimer_Tick(Button button, EventArgs e)
        {
            if (button.Foreground == Brushes.White)
            {
                button.Foreground = Brushes.Red;
                button.BorderBrush = Brushes.Red;
            }
            else
            {
                button.Foreground = Brushes.White;
                button.BorderBrush = Brushes.White;
            }
        }

        private void ThoughtsAndFeelingsAddButton_Click(object sender, RoutedEventArgs e)
        {
            ThoughtsAndFeelingsAdd thoughtsAndFeelingsAdd = new ThoughtsAndFeelingsAdd(this, menuFirstName, menuLastName);
            thoughtsAndFeelingsAdd.Show();
            this.WindowState = WindowState.Minimized;
        }

        private void ThoughtsAndFeelingsDiaryButton_Click(object sender, RoutedEventArgs e)
        {
            ThoughtsAndFeelingsDiary thoughtsAndFeelingsDiary = new ThoughtsAndFeelingsDiary(this, menuAccountType, menuFirstName, menuLastName);//////////////////
            thoughtsAndFeelingsDiary.Show();
            this.WindowState = WindowState.Minimized;
        }

        private void BookMeetingButton_Click(object sender, RoutedEventArgs e)
        {
            BookMeeting bookMeeting = new BookMeeting(this, menuID, menuFirstName, menuLastName);
            bookMeeting.Show();
            this.WindowState = WindowState.Minimized;
        }
        private void ViewMeetingsButton_Click(object sender, RoutedEventArgs e)
        {
            ViewMeetings viewMeetings = new ViewMeetings(this, menuAccountType, menuFirstName, menuLastName);///////////////////
            viewMeetings.Show();
            this.WindowState = WindowState.Minimized;
        }
        private void ViewInteractionsButton_Click(object sender, RoutedEventArgs e)
        {
            ViewInteractions viewInteractions = new ViewInteractions(this);
            viewInteractions.Show();
            this.WindowState = WindowState.Minimized;
        }
        private void EditUsersButton_Click(object sender, RoutedEventArgs e)
        {
            EditUsers editUsers = new EditUsers(this);
            editUsers.Show();
            this.WindowState = WindowState.Minimized;
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
