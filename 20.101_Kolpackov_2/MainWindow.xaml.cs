using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using _20._101_Kolpackov_2.Entity;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _20._101_Kolpackov_2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadTableData();//Обращение к методу вывода содержимого таблицы из БД
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                //Проверка на наличение результата поиска
                if (EntTeacher.GetContext().Teachers.Where(x => x.IdSpeciality == 1).OrderBy(x => x.LastName).Count() != 0)
                {
                    //Загрузка результата поиска
                    LoadData.ItemsSource = EntTeacher.GetContext().Teachers.Where(x => x.IdSpeciality == 1).OrderBy(x => x.LastName).ToList();
                }
                else 
                {
                    //Вывод сообщения о отсутсвии результата поиска
                    MessageBox.Show("Ничего не найдено");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void LoadTableData()
        {
            try
            {
                //Загрузка содержимого таблицы из БД
                LoadData.ItemsSource = EntTeacher.GetContext().Teachers.ToList();
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.ToString());
            }
            
        }
    }
}
