using System.Windows;
using System.Windows.Controls;

namespace WpfApp3
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_add_Click(object sender, RoutedEventArgs e)
        {
            TasksPanel.Visibility = Visibility.Visible;
            Scroll.Visibility = Visibility.Visible;
            read.Visibility = Visibility.Visible;
            string task = TaskInput.Text;

            if (!string.IsNullOrEmpty(task))
            {

                StackPanel taskPanel = new StackPanel
                {
                    Orientation = Orientation.Horizontal,
                    Margin = new Thickness(0, 5, 0, 5)
                };


                CheckBox taskCheckBox = new CheckBox
                {
                    VerticalAlignment = VerticalAlignment.Center,
                    Margin = new Thickness(5, 0, 0, 0)
                };


                Label taskLabel = new Label
                {
                    Content = task,
                    VerticalAlignment = VerticalAlignment.Center,
                    Margin = new Thickness(7, 0, 0, 0)
                };
                Label readLabel = new Label
                {
                    Content = task,
                    VerticalAlignment = VerticalAlignment.Center,
                    Margin = new Thickness(7, 0, 0, 0)
                };

                Button deleteButton = new Button
                {
                    Content = "Delete",
                    Height = 30,
                    Width = 60,
                    Margin = new Thickness(12, 0, 0, 0),
                    Visibility = Visibility.Collapsed
                };

                Button update = new Button
                {
                    Content = "update",
                    Height = 30,
                    Width = 60,
                    Margin = new Thickness(17, 0, 0, 0),
                    Visibility = Visibility.Collapsed
                };
                Button Ok = new Button
                {
                    Content = "OK",
                    Height = 30,
                    Width = 30,
                    Margin = new Thickness(17, 0, 0, 0),
                    Visibility = Visibility.Collapsed
                };
                update.Click += (s, ev) =>
                {
                    TaskInput.Text = task;
                    Ok.Visibility = Visibility.Visible;
                };
                Ok.Click += (s, ev) =>
                {

                    task = TaskInput.Text;
                    taskLabel.Content = task;
                    readLabel.Content = task;
                    TaskInput.Text = string.Empty;
                    Ok.Visibility = Visibility.Collapsed;
                };
                taskCheckBox.Checked += (s, ev) =>
                {
                    readLabel.Content = task;
                    deleteButton.Visibility = Visibility.Visible;
                    update.Visibility = Visibility.Visible;
                    read.Children.Add(readLabel);

                };

                taskCheckBox.Unchecked += (s, ev) =>
                {

                    deleteButton.Visibility = Visibility.Collapsed;
                    update.Visibility = Visibility.Collapsed;
                    Ok.Visibility = Visibility.Collapsed;
                    TaskInput.Text = string.Empty;
                    read.Children.Remove(readLabel);
                };

                deleteButton.Click += (s, ev) =>
                {
                    TasksPanel.Children.Remove(taskPanel);
                };
                taskPanel.Children.Add(taskCheckBox);
                taskPanel.Children.Add(taskLabel);
                taskPanel.Children.Add(deleteButton);
                taskPanel.Children.Add(update);
                taskPanel.Children.Add(Ok);
                TasksPanel.Children.Add(taskPanel);
                TaskInput.Text = string.Empty;
            }
        }
    }
}