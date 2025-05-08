using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp3.Model;

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
         


            var db = new dbUczelnia();

            wyświelt(db);
        }

        void wyświelt(dbUczelnia db)
        {
            lb.Items.Clear();

            foreach (var student in db.Students.OrderBy(s => s.Ocena))
            {
                lb.Items.Add(student);
            }
        }

        private void btndodaj_Click(object sender, RoutedEventArgs e)
        {
            try 
            { 
             using (var db= new dbUczelnia())
                {
                    var nowyStudent = new Student
                    {
                        Imie = txtimie.Text.Trim(),
                        Nazwisko = txtNazwisko.Text.Trim(),
                        Wiek = byte.Parse(txtwiek.Text.Trim()),
                        Ocena = string.IsNullOrWhiteSpace(txtOcena.Text) ? (double?)null : double.Parse(txtOcena.Text.Trim())


                    };
                    db.Students.Add(nowyStudent);
                    db.SaveChanges();
                    wyświelt(db);
                }
            }
            catch(Exception ex)
            {

            }

        }
    }
}