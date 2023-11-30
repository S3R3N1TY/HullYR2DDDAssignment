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
    public partial class ThoughtsAndFeelingsAdd : Window
    {
        private Menu menu;
        private string thoughtsAndFeelingsFirstName;
        private string thoughtsAndFeelingsLastName;
        private DateTime todayDateAndTime;
        private DateTime todayDate;
        private TextBox howAreYouFeelingTextBox;
        private TextBox whyAreYouFeelingTextBox;
        private TextBox extraThoughtsTextBox;

        public ThoughtsAndFeelingsAdd(Menu menu, string firstName, string lastName)
        {
            InitializeComponent();

            this.menu = menu;
            thoughtsAndFeelingsFirstName = firstName;
            thoughtsAndFeelingsLastName = lastName;
            todayDateAndTime = DateTime.Now;
            todayDate = todayDateAndTime.Date;
            string formattedDate = todayDate.ToString("dd/MM/yyyy");

            Uri windowIcon = new Uri("pack://application:,,,/Personal Supervisor Software;component/UoHArms.svg.ico");
            this.Icon = BitmapFrame.Create(windowIcon);

            Canvas thoughtsAndFeelingsAddCanvas = new Canvas();
            this.Content = thoughtsAndFeelingsAddCanvas;

            Image uohLogo = new Image
            {
                Source = new BitmapImage(new Uri("pack://application:,,,/Personal Supervisor Software;component/UoHLogoNB.png")),
                Width = 175,
                Height = 175
            };
            Canvas.SetLeft(uohLogo, 5);
            Canvas.SetTop(uohLogo, -40);

            thoughtsAndFeelingsAddCanvas.Children.Add(uohLogo);

            TextBlock engageLink = new TextBlock
            {
                Text = "EngageLink",
                Foreground = Brushes.AntiqueWhite,
                FontFamily = new FontFamily("Microsoft JhengHei"),
                FontSize = 28
            };
            Canvas.SetRight(engageLink, 10);
            Canvas.SetTop(engageLink, 10);

            thoughtsAndFeelingsAddCanvas.Children.Add(engageLink);

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
            thoughtsAndFeelingsAddCanvas.Children.Add(backButton);

            TextBlock dateTextBox = new TextBlock
            {
                Text = formattedDate,
                Width = 200,
                Height = 30,
                FontFamily = new FontFamily("Microsoft JhengHei"),
                FontSize = 16,
                Foreground = Brushes.Black,
            };
            Canvas.SetLeft(dateTextBox, 10);
            Canvas.SetTop(dateTextBox, 90);

            thoughtsAndFeelingsAddCanvas.Children.Add(dateTextBox);

            howAreYouFeelingTextBox = new TextBox
            {
                Text = "",
                FontFamily = new FontFamily("Microsoft JhengHei"),
                FontSize = 11,
                TextWrapping = TextWrapping.Wrap,
                Width = 300,
                Height = 75
            };

            Canvas.SetLeft(howAreYouFeelingTextBox, (this.Width - howAreYouFeelingTextBox.Width) / 2 + 80);
            Canvas.SetTop(howAreYouFeelingTextBox, (this.Height - howAreYouFeelingTextBox.Height) / 2 - 60);

            thoughtsAndFeelingsAddCanvas.Children.Add(howAreYouFeelingTextBox);

            TextBlock howAreYouFeelingLabel = new TextBlock
            {
                Text = "How are you feeling?",
                Width = 200,
                Height = 30,
                FontFamily = new FontFamily("Microsoft JhengHei"),
                FontSize = 14,
                Foreground = Brushes.Black,
            };
            Canvas.SetLeft(howAreYouFeelingLabel, 20);
            Canvas.SetTop(howAreYouFeelingLabel, (this.Height - howAreYouFeelingTextBox.Height) / 2 - 35);

            thoughtsAndFeelingsAddCanvas.Children.Add(howAreYouFeelingLabel);

            whyAreYouFeelingTextBox = new TextBox
            {
                Text = "",
                FontFamily = new FontFamily("Microsoft JhengHei"),
                FontSize = 11,
                TextWrapping = TextWrapping.Wrap,
                Width = 300,
                Height = 75
            };

            Canvas.SetLeft(whyAreYouFeelingTextBox, (this.Width - whyAreYouFeelingTextBox.Width) / 2 + 80);
            Canvas.SetTop(whyAreYouFeelingTextBox, (this.Height - whyAreYouFeelingTextBox.Height) / 2 + 20);

            thoughtsAndFeelingsAddCanvas.Children.Add(whyAreYouFeelingTextBox);

            TextBlock whyAreYouFeelingLabel = new TextBlock
            {
                Text = "Why are you feeling this way?",
                Width = 200,
                Height = 30,
                FontFamily = new FontFamily("Microsoft JhengHei"),
                FontSize = 14,
                Foreground = Brushes.Black,
            };
            Canvas.SetLeft(whyAreYouFeelingLabel, 20);
            Canvas.SetTop(whyAreYouFeelingLabel, (this.Height - whyAreYouFeelingTextBox.Height) / 2 + 45);

            thoughtsAndFeelingsAddCanvas.Children.Add(whyAreYouFeelingLabel);

            extraThoughtsTextBox = new TextBox
            {
                Text = "",
                FontFamily = new FontFamily("Microsoft JhengHei"),
                FontSize = 11,
                TextWrapping = TextWrapping.Wrap,
                Width = 300,
                Height = 75
            };

            Canvas.SetLeft(extraThoughtsTextBox, (this.Width - extraThoughtsTextBox.Width) / 2 + 80);
            Canvas.SetTop(extraThoughtsTextBox, (this.Height - extraThoughtsTextBox.Height) / 2 + 100);

            thoughtsAndFeelingsAddCanvas.Children.Add(extraThoughtsTextBox);

            TextBlock extraThoughtsLabel = new TextBlock
            {
                Text = "Any extra thoughts?",
                Width = 200,
                Height = 30,
                FontFamily = new FontFamily("Microsoft JhengHei"),
                FontSize = 14,
                Foreground = Brushes.Black,
            };
            Canvas.SetLeft(extraThoughtsLabel, 20);
            Canvas.SetTop(extraThoughtsLabel, (this.Height - extraThoughtsTextBox.Height) / 2 + 125);

            thoughtsAndFeelingsAddCanvas.Children.Add(extraThoughtsLabel);

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

            Canvas.SetLeft(submitButton, (this.Width - extraThoughtsTextBox.Width) / 2 + 130);
            Canvas.SetBottom(submitButton, 10);

            submitButton.Click += SubmitButton_Click;
            thoughtsAndFeelingsAddCanvas.Children.Add(submitButton);

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            menu.NormalWindow();
            this.Close();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            string folderName = thoughtsAndFeelingsFirstName + thoughtsAndFeelingsLastName;
            string selectedFile = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "Users", "STUDENT", folderName, "ThoughtsAndFeelings.txt");
            selectedFile = System.IO.Path.GetFullPath(selectedFile);

            using (StreamWriter sw = File.AppendText(selectedFile))
            {
                sw.WriteLine(todayDate);
                sw.WriteLine(howAreYouFeelingTextBox.Text);
                sw.WriteLine(whyAreYouFeelingTextBox.Text);
                sw.WriteLine(extraThoughtsTextBox.Text);
            }

            string logsPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "Logs.txt");
            logsPath = System.IO.Path.GetFullPath(logsPath);

            using (StreamWriter sw = File.AppendText(logsPath))
            {
                sw.WriteLine(todayDate);
                sw.WriteLine(thoughtsAndFeelingsFirstName + " " + thoughtsAndFeelingsLastName + " updated their Thoughts and Feelings Diary.");
                sw.WriteLine("They feel \"" + howAreYouFeelingTextBox.Text + "\" because \"" + whyAreYouFeelingTextBox);
            }

            MessageBox.Show("Your response has been recorded. Have a pleasant day!", "Success!");
            menu.NormalWindow();
            this.Close();
        }
    }
}
