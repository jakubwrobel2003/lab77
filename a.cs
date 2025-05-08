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
using Microsoft.Data.SqlClient;


namespace WpfApp2
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
            lst.Items.Clear();
            using (var połączenie = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Sklep;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"))
            {
                SqlCommand polcenie = new SqlCommand("Select * from Towary", połączenie);
                połączenie.Open();
                SqlDataReader czytnik = polcenie.ExecuteReader();
                while (czytnik.Read())
                {
                    lst.Items.Add($"{czytnik["TowarId"]} {czytnik["Nazwa"]} {czytnik["Ilosc"]} {czytnik["Cena"]}");
                }
                czytnik.Close();
                polcenie = new SqlCommand("SELECT AVG(Cena) from Towary", połączenie);
                decimal avg = (decimal)polcenie.ExecuteScalar();
                MessageBox.Show(avg.ToString());
                
                połączenie.Close();

            }
        }
    }
}