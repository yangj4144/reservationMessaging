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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Web;
using Newtonsoft.Json;
//using System.Web.UI;
//using System.Web.Script.Serialization;

namespace hotel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<Guest> Guests = new List<Guest>();

        List<Company> Hotels = new List<Company>();

        List<String> guestNames = new List<String>();

        List<String> companyNames = new List<string>();

        public MainWindow()
        {
            InitializeComponent();

            // This will get the current WORKING directory (i.e. \bin\Debug)
            string workingDirectory = Environment.CurrentDirectory;
            // or: Directory.GetCurrentDirectory() gives the same result


            // This will get the current PROJECT directory
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;




            var guestJson = File.ReadAllText(projectDirectory + "/appfiles/Guests.json");
            var guestsCollection = JsonConvert.DeserializeObject<IList<Guest>>(guestJson);
                       

            this.Guests = (List<Guest>)guestsCollection;


            LstGreet.ItemsSource = this.Guests;

         

            var jsonText = File.ReadAllText(projectDirectory + "/appfiles/Companies.json");
            var companies = JsonConvert.DeserializeObject<IList<Company>>(jsonText);

            this.Hotels = (List<Company>)companies;


           // LstCompany.ItemsSource = companies;

            //boxGuest.ItemsSource = typeof(Guest).GetProperties();

            foreach (Guest guest in this.Guests)
            {
                string tempName = "";
                tempName = $"{guest.FirstName} {guest.LastName}";
                this.guestNames.Add(tempName);
            }

            foreach (Company company in this.Hotels)
            {
                string tempName = "";
                tempName = $"{company.company}";
                this.companyNames.Add(tempName);
            }



            boxGuest.ItemsSource = this.guestNames;
            boxCompany.ItemsSource = this.companyNames;



        }

        

        private void ButtonAddName_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void lstNames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void LstGreet_Click(object sender, RoutedEventArgs e)
        {

        }

        private void guestClick_Click(object sender, RoutedEventArgs e)
        {
            List<Guest> selectedGuest = this.Guests;



           var currentGuest = LstGreet.SelectedItem;

            

            if (currentGuest != null)
            {
                string guestString = currentGuest.ToString();



                foreach (Guest guest in this.Guests)
                {
                    if ( guestString.Contains(guest.FirstName + " " + guest.LastName)== true)
                    {
                        string greetGuest = "(Good morning)" + guest.FirstName + " " + guest.LastName + ", and welcome to" + "(HOTEL COMPANY) room " + guest.Reservation.RoomNumber + " is now ready you.Enjoy your stay, and let us know if you need anything.";



                        MessageBox.Show(greetGuest);
                    }
                }
            }
            else MessageBox.Show("Please select a customer first before clicking the button.");
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void boxCompany_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void boxGuest_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

       

        private void customMsg_Click(object sender, RoutedEventArgs e)
        {
            string customGuest = boxGuest.Text;

            string customCompany = boxCompany.Text;

            if (customGuest != null && customCompany != null)
            {
                string customGreet = $"Good Morning {customGuest}, and welcome to {customCompany}. Enjoy your stay, and let us know if you need anything.";
                MessageBox.Show(customGreet);
            }
            else MessageBox.Show("Plese select a guest and hotel first.");
            

            
        }
    }
}
