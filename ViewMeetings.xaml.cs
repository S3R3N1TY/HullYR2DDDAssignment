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
    public partial class ViewMeetings : Window
    {
        private Menu menu;
        private string viewMeetingsAccountType;
        private string viewMeetingsFirstName;
        private string viewMeetingsLastName;
        private TextBox viewMeetingsTextBox;
        private string selectedStudent;

        public ViewMeetings(Menu menu, string menuAccountType, string firstName, string lastName)
        {
            InitializeComponent();

            this.menu = menu;
            viewMeetingsAccountType = menuAccountType;
            viewMeetingsFirstName = firstName;
            viewMeetingsLastName = lastName;

            Uri windowIcon = new Uri("pack://application:,,,/Personal Supervisor Software;component/UoHArms.svg.ico");
            this.Icon = BitmapFrame.Create(windowIcon);

            Canvas viewMeetingsCanvas = new Canvas();
            this.Content = viewMeetingsCanvas;

            Image uohLogo = new Image
            {
                Source = new BitmapImage(new Uri("pack://application:,,,/Personal Supervisor Software;component/UoHLogoNB.png")),
                Width = 175,
                Height = 175
            };
            Canvas.SetLeft(uohLogo, 5);
            Canvas.SetTop(uohLogo, -40);

            viewMeetingsCanvas.Children.Add(uohLogo);

            TextBlock engageLink = new TextBlock
            {
                Text = "EngageLink",
                Foreground = Brushes.AntiqueWhite,
                FontFamily = new FontFamily("Microsoft JhengHei"),
                FontSize = 28
            };
            Canvas.SetRight(engageLink, 10);
            Canvas.SetTop(engageLink, 10);

            viewMeetingsCanvas.Children.Add(engageLink);

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
            viewMeetingsCanvas.Children.Add(backButton);

            viewMeetingsTextBox = new TextBox
            {
                Text = "",
                FontFamily = new FontFamily("Microsoft JhengHei"),
                FontSize = 11,
                TextWrapping = TextWrapping.Wrap,
                Width = 500,
                Height = 250
            };

            Canvas.SetLeft(viewMeetingsTextBox, (this.Width - viewMeetingsTextBox.Width) / 2 - 20);
            Canvas.SetTop(viewMeetingsTextBox, (this.Height - viewMeetingsTextBox.Height) / 2 + 20);

            ScrollViewer scrollViewer = new ScrollViewer
            {
                Content = viewMeetingsTextBox,
                VerticalScrollBarVisibility = ScrollBarVisibility.Visible,
                HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled
            };

            Canvas.SetLeft(scrollViewer, (this.Width - viewMeetingsTextBox.Width) / 2 - 20);
            Canvas.SetTop(scrollViewer, (this.Height - viewMeetingsTextBox.Height) / 2 + 40);

            viewMeetingsCanvas.Children.Add(scrollViewer);

            switch (viewMeetingsAccountType.ToUpper())
            {
                case "STUDENT":
                case "PERSONAL SUPERVISOR":

                    string userFolder = viewMeetingsFirstName + viewMeetingsLastName;
                    string userFile = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "Users", viewMeetingsAccountType, userFolder, "Meetings.txt");
                    userFile = System.IO.Path.GetFullPath(userFile);

                    string userFileContent = File.ReadAllText(userFile);
                    viewMeetingsTextBox.Text = userFileContent;

                    break;

                case "SENIOR TUTOR":

                    ComboBox newStudentDropDown = new ComboBox
                    {
                        Width = 200,
                        Height = 30,
                        FontFamily = new FontFamily("Microsoft JhengHei"),
                        FontSize = 18
                    };

                    Canvas.SetLeft(newStudentDropDown, (this.Width - newStudentDropDown.Width) / 2);
                    Canvas.SetTop(newStudentDropDown, 95);

                    string studentFolder = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "Users", "STUDENT");
                    studentFolder = System.IO.Path.GetFullPath(studentFolder);
                    string[] students = System.IO.Directory.GetDirectories(studentFolder).Select(path => System.IO.Path.GetFileName(path)).ToArray();
                    foreach (var student in students)
                    {
                        newStudentDropDown.Items.Add(student);
                    }
                    newStudentDropDown.SelectionChanged += NewStudentDropDown_SelectionChanged;

                    string studentViewMeetingsFile = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "Users", "STUDENT");
                    studentViewMeetingsFile = System.IO.Path.GetFullPath(studentViewMeetingsFile);

                    viewMeetingsCanvas.Children.Add(newStudentDropDown);

                    Button openButton = new Button
                    {
                        Content = "Open",
                        FontFamily = new FontFamily("Microsoft JhengHei"),
                        FontSize = 12,
                        Foreground = Brushes.White,
                        Background = Brushes.DimGray,
                        BorderBrush = Brushes.White,
                        Width = 75,
                        Height = 30
                    };

                    Canvas.SetLeft(openButton, (this.Width - newStudentDropDown.Width) / 2 + 200);
                    Canvas.SetTop(openButton, 95);

                    openButton.Click += OpenButton_Click;
                    viewMeetingsCanvas.Children.Add(openButton);

                    break;
            }

        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            menu.NormalWindow();
            this.Close();

        }

        private void NewStudentDropDown_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            selectedStudent = comboBox.SelectedItem?.ToString();
        }

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            string studentViewMeetingsFile = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "Users", "STUDENT", selectedStudent, "Meetings.txt");
            string studentFileContent = File.ReadAllText(studentViewMeetingsFile);
            viewMeetingsTextBox.Text = studentFileContent;
        }
    }
}