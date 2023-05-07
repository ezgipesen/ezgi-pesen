using System;
using System.Collections.Generic;
using Microsoft.Maui.Controls;

namespace ANASAYFA
{
    public partial class yapýlacaklar : ContentPage
    {
        List<string> todoItems = new List<string>();

        public yapýlacaklar()
        {
            InitializeComponent();
            todoList.ItemsSource = todoItems;
        }

        void OnAddTodoClicked(object sender, EventArgs e)
        {
            string todoText = todoEntry.Text;
            if (!string.IsNullOrEmpty(todoText))
            {
                todoItems.Add(todoText);
                todoEntry.Text = "";
                todoList.ItemsSource = null;
                todoList.ItemsSource = todoItems;
            }
        }

        void OnCompleteTodoClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string completedTodo = button.BindingContext.ToString();
            todoItems.Remove(completedTodo);
            todoList.ItemsSource = null;
            todoList.ItemsSource = todoItems;
        }

        void OnSaveClicked(object sender, EventArgs e)
        {
            // Save todoItems to file or database
            DisplayAlert("Kaydedildi", "Yapýlacaklar kaydedildi", "Tamam");
        }
    }
}