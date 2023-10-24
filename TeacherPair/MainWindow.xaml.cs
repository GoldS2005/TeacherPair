using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TeacherPair
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public class TimeTableRow
    {
        public int PairNumber { get; set; }
        public string AudNumber { get; set; }
        public string Displine { get; set; }
        public string TeacherFullName { get; set; }

        public override string ToString()
        {
            return $"{PairNumber} - {Displine} [{AudNumber}] ({TeacherFullName})";
        }

    }

    
    public partial class MainWindow : Window
    {
        private List<TimeTableRow> timeTableRows;
        
        public MainWindow()
        {
            InitializeComponent();
            timeTableRows = new List<TimeTableRow>();
            UpdateTimetableListBox();

        }

        private void UpdateTimetableListBox()
        {
            timetableListBox.Items.Clear();
            foreach (TimeTableRow row in timeTableRows)
            {
                timetableListBox.Items.Add(row.ToString());
            }
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            
            TimeTableRow newRow = new TimeTableRow();
            newRow.PairNumber = timeTableRows.Count + 1;
            newRow.Displine = displineComboBox.Text;
            newRow.AudNumber = audComboBox.Text;
            newRow.TeacherFullName = teacherComboBox.Text;
            timeTableRows.Add(newRow);
            UpdateTimetableListBox();
            
        }


        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (timetableListBox.SelectedIndex >= 0)
            {
                timeTableRows.RemoveAt(timetableListBox.SelectedIndex);
                RenumberTimetableRows();
                UpdateTimetableListBox();
            }
        }

        private void RenumberTimetableRows()
        {
            for (int i = 0; i < timeTableRows.Count; i++)
            {
                timeTableRows[i].PairNumber = i + 1;
            }
               
        }
       

        private void addButton1_Click(object sender, RoutedEventArgs e)
        {
   
            TimeTableRow newRow = new TimeTableRow();
            newRow.Displine = displineTextBox.Text;
            displineComboBox.Items.Add(displineTextBox.Text);
            displineTextBox.Clear();

        }

        

        private void addButton2_Click(object sender, RoutedEventArgs e)
        {
            
            TimeTableRow newRow = new TimeTableRow();
            newRow.TeacherFullName = teacherTextBox.Text;
            teacherComboBox.Items.Add(teacherTextBox.Text);
            teacherTextBox.Clear();
           
            
        }


        private void addButton3_Click(object sender, RoutedEventArgs e)
        {
            TimeTableRow newRow = new TimeTableRow();
            newRow.AudNumber = audTextBox.Text;
            audComboBox.Items.Add(audTextBox.Text);
            audTextBox.Clear();
            
        }

       private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
       {
            if (string.IsNullOrEmpty(displineTextBox.Text))
            {
                addButton1.IsEnabled = false;
            }
            else
            {
                addButton1.IsEnabled = true;
            }

            if (string.IsNullOrEmpty(teacherTextBox.Text))
            {
                addButton2.IsEnabled = false;
            }
            else
            {
                addButton2.IsEnabled = true;
            }

            if (string.IsNullOrEmpty(audTextBox.Text))
            {
                addButton3.IsEnabled = false;
            }
            else
            {
                addButton3.IsEnabled = true;
            }

       }

        
    }
}
