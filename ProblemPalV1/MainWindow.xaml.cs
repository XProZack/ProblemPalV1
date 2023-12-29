using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ProblemPalV1
{
    public partial class MainWindow : Window
    {   
     
        // Dictionaries to store like and dislike counts for each post
        private Dictionary<StackPanel, int> likeCounts = new Dictionary<StackPanel, int>();
        private Dictionary<StackPanel, int> dislikeCounts = new Dictionary<StackPanel, int>();

        public MainWindow()
        {
            InitializeComponent();
        }

        // Event handler for the "Post" button click
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
                    BorderBrush = System.Windows.Media.Brushes.LightBlue,
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

                // Panel to hold like, dislike buttons, and their counts
                StackPanel buttonsPanel = new StackPanel
                {
                    Orientation = Orientation.Horizontal,
                    HorizontalAlignment = HorizontalAlignment.Right
                };

                // Like button
                Button likeButton = new Button
                {
                    Content = "Like",
                    Width = 50,
                    Height = 25,
                    Margin = new Thickness(5),
                    Background = System.Windows.Media.Brushes.Green
                };

                // Dislike button
                Button dislikeButton = new Button
                {
                    Content = "Dislike",
                    Width = 50,
                    Height = 25,
                    Margin = new Thickness(5),
                    Background = System.Windows.Media.Brushes.Red
                };

                // TextBlock to display like count
                TextBlock likeCountTextBlock = new TextBlock
                {
                    Text = "Likes: 0",
                    Margin = new Thickness(5),
                    VerticalAlignment = VerticalAlignment.Center
                };

                // TextBlock to display dislike count
                TextBlock dislikeCountTextBlock = new TextBlock
                {
                    Text = "Dislikes: 0",
                    Margin = new Thickness(5),
                    VerticalAlignment = VerticalAlignment.Center
                };

                // Event handlers for like and dislike button clicks
                likeButton.Click += (s, args) => ToggleLikeButton(likeButton, likeCountTextBlock, postContainer, dislikeButton);
                dislikeButton.Click += (s, args) => ToggleDislikeButton(dislikeButton, dislikeCountTextBlock, postContainer, likeButton);

                // Assemble UI elements
                postBorder.Child = postTextBlock;
                buttonsPanel.Children.Add(likeButton);
                buttonsPanel.Children.Add(dislikeButton);
                buttonsPanel.Children.Add(likeCountTextBlock);
                buttonsPanel.Children.Add(dislikeCountTextBlock);

                postContainer.Children.Add(postBorder);
                postContainer.Children.Add(buttonsPanel);

                // Add the post container to the main posts container
                PostsContainer.Children.Add(postContainer);

                // Initialize like and dislike counts for this post
                likeCounts.Add(postContainer, 0);
                dislikeCounts.Add(postContainer, 0);

                // Clear the complaint input field
                Complaint.Clear();
            }
            else
            {
                // Show a message if the complaint text is empty
                MessageBox.Show("Please enter a complaint.");
            }
        }

        // Event handler to show rules popup
        private void ShowRules_Click(object sender, RoutedEventArgs e)
        {
            RulesPopup.IsOpen = true;
        }

        // Event handler for agreeing to rules
        private void IAgree_Click(object sender, RoutedEventArgs e)
        {
            RulesPopup.IsOpen = false;
        }

        // Event handler to show contacts
        private void ShowContacts_Click(object sender, RoutedEventArgs e)
        {
            Contact.IsOpen = true;
        }

        // Event handler to close contacts
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Contact.IsOpen = false;
        }

        private void OpenAdmin_Click(object sender, RoutedEventArgs e)
        {
            // Open the AdminPanelWindow
            Admin adminPanel = new Admin();
            adminPanel.Show();
        }

        // Toggle function for the like button
        private void ToggleLikeButton(Button likeButton, TextBlock likeCountTextBlock, StackPanel postContainer, Button dislikeButton)
        {
            if (likeButton.Content.ToString() == "Like")
            {
                likeButton.Content = "Liked";
                MessageBox.Show("Liked!");
                likeCounts[postContainer]++;
                likeCountTextBlock.Text = "Likes: " + likeCounts[postContainer];

                // Disable the dislike button
                dislikeButton.IsEnabled = false;
            }
            else
            {
                likeButton.Content = "Like";
                likeCounts[postContainer]--;
                likeCountTextBlock.Text = "Likes: " + likeCounts[postContainer];

                // Enable the dislike button
                dislikeButton.IsEnabled = true;
            }
        }

        // Toggle function for the dislike button
        private void ToggleDislikeButton(Button dislikeButton, TextBlock dislikeCountTextBlock, StackPanel postContainer, Button likeButton)
        {
            if (dislikeButton.Content.ToString() == "Dislike")
            {
                dislikeButton.Content = "Disliked";
                MessageBox.Show("Disliked!");
                dislikeCounts[postContainer]++;
                dislikeCountTextBlock.Text = "Dislikes: " + dislikeCounts[postContainer];

                // Disable the like button
                likeButton.IsEnabled = false;
            }
            else
            {
                dislikeButton.Content = "Dislike";
                dislikeCounts[postContainer]--;
                dislikeCountTextBlock.Text = "Dislikes: " + dislikeCounts[postContainer];

                // Enable the like button
                likeButton.IsEnabled = true;
            }
        }
    }
}
