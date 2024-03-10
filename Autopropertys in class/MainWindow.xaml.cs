using System;
using System.Windows;

namespace Autopropertys_in_class
{    
    public partial class MainWindow : Window
    {
        static int maxRecordCount = 17;
        int recordCount = 0;
        (string Name, int Age)[] Data = new (string Name, int Age)[maxRecordCount];
        (string Name, int Age)[] temp = new (string Name, int Age)[maxRecordCount];
        public MainWindow()
        {
            InitializeComponent();
        }

        private void PrintResult()
        {
            InputBox.Text = "";
            OutputBox.Text = "";
            for (int i = 0; i < recordCount; i++)
            {
                OutputBox.Text += $"ID: {i}, Name: {Data[i].Name}, Age: {Data[i].Age}\n";
            }
        }

        private void Input_Button_Click(object sender, RoutedEventArgs e)
        {
            if(recordCount < maxRecordCount)
            {
                string[] parts = (InputBox.Text).Trim().Split(new char[] { ' ', '\t', ',', ';', ':' }, StringSplitOptions.RemoveEmptyEntries);
                if (int.TryParse(parts[1], out int age))
                {
                    Data[recordCount].Name = parts[0]; 
                    Data[recordCount].Age = age;
                    OutputBox.Text += $"ID: {recordCount}, Name: {Data[recordCount].Name}, Age: {Data[recordCount].Age}\n";
                    InputBox.Text = "";
                    recordCount += 1;
                }
                else
                {
                    InputBox.Text = "Invalid age";
                }
                    
            }

            else
            {
                InputBox.Text = "No space left";
            }
            
        }

        private void Sort_Age_Button_Click(object sender, RoutedEventArgs e)
        {
            
            for (int z = 0; z < recordCount; z++)
                for (int i = 0; i < recordCount - 1; i++)
                {
                    if (Data[i].Age > Data[i + 1].Age)
                    {
                        temp[0] = Data[i];
                        Data[i] = Data[i + 1];
                        Data[i + 1] = temp[0];
                    }
                }

            PrintResult();

        }

        private void Sort_Name_Button_Click (object sender, RoutedEventArgs e)
        {

            for (int z = 0; z < recordCount; z++)
                for (int i = 0; i < recordCount - 1; i++)
                {
                    if (Data[i].Name.CompareTo(Data[i + 1].Name) > 0)
                    {
                        temp[0] = Data[i];
                        Data[i] = Data[i + 1];
                        Data[i + 1] = temp[0];
                    }
                }

           PrintResult();

        }

        private void Search_Age_Button_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(InputBox.Text, out int Age))
            {
                for(int i = 0; i < recordCount; i++)
                {
                    if (Data[i].Age == Age)
                    {
                        InputBox.Text = $"ID: {i}, Name: {Data[i].Name}, Age: {Data[i].Age}";
                    }
                }
            }
            else
            {
                InputBox.Text = "Invalid Age";
            }

        }

        private void Search_Name_Button_Click(object sender, RoutedEventArgs e)
        {
            bool nameFound = false;
            Name = InputBox.Text;
            for (int i = 0; i < recordCount; i++)
            {
                if (Name == Data[i].Name)
                {
                    nameFound = true;
                    InputBox.Text = $"ID: {i}, Name: {Data[i].Name}, Age: {Data[i].Age}";
                }
            }
            if (!nameFound)
            {
                InputBox.Text = "No such person in DataBase";
            }
                    
        }

        private void Delete_ID_Button_Click(object sender, RoutedEventArgs e)
        {

            if (int.TryParse(InputBox.Text, out int ID) && ID < recordCount)
            {
                for (int i = ID; i < recordCount - 1; i++)
                {
                    Data[ID].Name = Data[ID + 1].Name;
                    Data[ID].Age = Data[ID + 1].Age;
                }

                recordCount--;
                PrintResult();
            }
            else
            {
                InputBox.Text = "Invalid ID";
            }
        }
    }
}

