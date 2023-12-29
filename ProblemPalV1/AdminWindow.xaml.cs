using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ProblemPalV1
{
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
        }

        private void Post_Click(object sender, RoutedEventArgs e)
        {
            // Get the complaint text from the input field
            string complaintText = Complaint.Text;

            if (!string.IsNullOrWhiteSpace(complaintText))
            {
                // Create UI elements to display the complaint text and buttons
                StackPanel postContainer = new StackPanel
                {
                    Width = 500,
                    Margin = new Thickness(0, 0, 0, 10)
                };

                // Border to contain the complaint text
                Border postBorder = new Border
                {
                    BorderThickness = new Thickness(4),
                    BorderBrush = Brushes.LightBlue,
                    CornerRadius = new CornerRadius(5),
                };

                // TextBlock to display the complaint text
                TextBlock postTextBlock = new TextBlock
                {
                    Text = complaintText,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    TextWrapping = TextWrapping.Wrap,
                    VerticalAlignment = VerticalAlignment.Center,
                    Height = 86,
                    Width = 480
                };

                // Panel to hold approve and delete buttons
                StackPanel buttonsPanel = new StackPanel
                {
                    Orientation = Orientation.Horizontal,
                    HorizontalAlignment = HorizontalAlignment.Right
                };

                // Approve button
                Button approveButton = new Button
                {
                    Content = "Approve",
                    Width = 80,
                    Height = 25,
                    Margin = new Thickness(5),
                    Background = Brushes.Green
                };

                // Delete button
                Button deleteButton = new Button
                {
                    Content = "Delete",
                    Width = 80,
                    Height = 25,
                    Margin = new Thickness(5),
                    Background = Brushes.Red
                };

                // Event handlers for approve and delete button clicks
                approveButton.Click += (s, args) => ToggleApproveButton(approveButton, postContainer);
                deleteButton.Click += (s, args) => ToggleDeleteButton(postContainer);

                // Assemble UI elements
                postBorder.Child = postTextBlock;
                buttonsPanel.Children.Add(approveButton);
                buttonsPanel.Children.Add(deleteButton);

                postContainer.Children.Add(postBorder);
                postContainer.Children.Add(buttonsPanel);

                // Add the post container to the main posts container
                PostsContainer.Children.Add(postContainer);

                // Clear the complaint input field
                Complaint.Clear();
            }
            else
            {
                // Show a message if the complaint text is empty
                MessageBox.Show("Please enter a complaint.");
            }
        }

        private void ToggleDeleteButton(StackPanel postContainer)
        {
            // Implement logic to delete the post (remove from UI)
            PostsContainer.Children.Remove(postContainer);
        }

        private void ToggleApproveButton(Button approveButton, StackPanel postContainer)
        {
            if (approveButton.Content.ToString() == "Approve")
            {
                approveButton.Content = "Approved";
                MessageBox.Show("Approved!");
                // Implement any logic related to approving the post
            }
            else
            {
                approveButton.Content = "Approve";
                // Implement any logic related to undoing approval of the post
            }
        }
    }
}

