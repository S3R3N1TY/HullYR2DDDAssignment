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
    public partial class ViewInteractions : Window
    {
        private Menu menu;
        private TextBox viewInteractionsTextBox;

        public ViewInteractions(Menu menu)
        {
            InitializeComponent();

            this.menu = menu;

            Uri windowIcon = new Uri("pack://application:,,,/Personal Supervisor Software;component/UoHArms.svg.ico");
            this.Icon = BitmapFrame.Create(windowIcon);

            Canvas viewInteractionsCanvas = new Canvas();
            this.Content = viewInteractionsCanvas;

            Image uohLogo = new Image
            {
                Source = new BitmapImage(new Uri("pack://application:,,,/Personal Supervisor Software;component/UoHLogoNB.png")),
                Width = 175,
                Height = 175
            };
            Canvas.SetLeft(uohLogo, 5);
            Canvas.SetTop(uohLogo, -40);

            viewInteractionsCanvas.Children.Add(uohLogo);

            TextBlock engageLink = new TextBlock
            {
                Text = "EngageLink",
                Foreground = Brushes.AntiqueWhite,
                FontFamily = new FontFamily("Microsoft JhengHei"),
                FontSize = 28
            };
            Canvas.SetRight(engageLink, 10);
            Canvas.SetTop(engageLink, 10);

            viewInteractionsCanvas.Children.Add(engageLink);

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
            viewInteractionsCanvas.Children.Add(backButton);

            viewInteractionsTextBox = new TextBox
            {
                Text = "",
                FontFamily = new FontFamily("Microsoft JhengHei"),
                FontSize = 11,
                TextWrapping = TextWrapping.Wrap,
                Width = 500,
                Height = 300
            };

            Canvas.SetLeft(viewInteractionsTextBox, (this.Width - viewInteractionsTextBox.Width) / 2 - 20);
            Canvas.SetTop(viewInteractionsTextBox, (this.Height - viewInteractionsTextBox.Height) / 2 + 20);

            ScrollViewer scrollViewer = new ScrollViewer
            {
                Content = viewInteractionsTextBox,
                VerticalScrollBarVisibility = ScrollBarVisibility.Visible,
                HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled
            };

            Canvas.SetLeft(scrollViewer, (this.Width - viewInteractionsTextBox.Width) / 2 - 20);
            Canvas.SetTop(scrollViewer, (this.Height - viewInteractionsTextBox.Height) / 2 + 20);

            viewInteractionsCanvas.Children.Add(scrollViewer);

            string selectedFile = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "Logs.txt");
            selectedFile = System.IO.Path.GetFullPath(selectedFile);

            string fileContent = File.ReadAllText(selectedFile);
            viewInteractionsTextBox.Text = fileContent;
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            menu.NormalWindow();
            this.Close();

        }
    }
}