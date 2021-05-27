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
        // list of guests
        List<Guest> Guests = new List<Guest>();

        // list of hotel/company names
        List<Company> Hotels = new List<Company>();

        // list of guest names only
        List<String> guestNames = new List<String>();

        // list of hotel names only
        List<String> companyNames = new List<string>();

        public MainWindow()
        {
            InitializeComponent();

            // This will get the current WORKING directory (i.e. \bin\Debug)
            string workingDirectory = Environment.CurrentDirectory;
            // or: Directory.GetCurrentDirectory() gives the same result


            // This will get the current PROJECT directory
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;



            // read json file
            var guestJson = File.ReadAllText(projectDirectory + "/appfiles/Guests.json");
            // guests list
            var guestsCollection = JsonConvert.DeserializeObject<IList<Guest>>(guestJson);

            // local guest list to global list
            this.Guests = (List<Guest>)guestsCollection;

            // set list box in gui
            LstGreet.ItemsSource = this.Guests;


            // read json file
            var jsonText = File.ReadAllText(projectDirectory + "/appfiles/Companies.json");
            // create local list of company objects
            var companies = JsonConvert.DeserializeObject<IList<Company>>(jsonText);

            // convert to global company list
            this.Hotels = (List<Company>)companies;



            // loop through all guests and get first and last names, then convert to name only list
            foreach (Guest guest in this.Guests)
            {
                string tempName = "";
                tempName = $"{guest.FirstName} {guest.LastName}";
                this.guestNames.Add(tempName);
            }

            // looop through all companies and get name of the company and add to company  name only list
            foreach (Company company in this.Hotels)
            {
                string tempName = "";
                tempName = $"{company.company}";
                this.companyNames.Add(tempName);
            }


            // set drop down list for guest names and company names
            boxGuest.ItemsSource = this.guestNames;
            boxCompany.ItemsSource = this.companyNames;



        }

        /// <summary>
        /// Convert Epoch to date time
        /// </summary>
        /// <param name="epochValue"></param>
        /// <returns></returns>
        public DateTime convertEpochTime(int epochValue)
        {
            DateTime convertedDate = new DateTime();

            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            epoch = epoch.AddMilliseconds(epochValue);




            return epoch;
        }




        /// <summary>
        /// button click for list, using auto generated formatting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void guestClick_Click(object sender, RoutedEventArgs e)
        {
            // guest list
            List<Guest> selectedGuest = this.Guests;


            // get current selected guest from list
            var currentGuest = LstGreet.SelectedItem;


            // if check not null
            if (currentGuest != null)
            {
                // to string guest
                string guestString = currentGuest.ToString();


                // loop through all guests in the guest list
                foreach (Guest guest in this.Guests)
                {
                    // if first name and last name match in guest list found
                    if (guestString.Contains(guest.FirstName + " " + guest.LastName) == true)
                    {
                        // convert time
                        DateTime convertDate = this.convertEpochTime(guest.Reservation.StartTimestamp);
                        //convertDate = convertDate + TimeSpan.Parse(string.Format("{0:HH:mm}", convertDate)); // trim to minute

                        string hour = convertDate.ToString("%h tt");

                        string timeGreeting = "";

                        // greet guest using guest values.
                        string greetGuest = "Good Morning" +
                        " " + guest.FirstName + " " + guest.LastName + ", room " + guest.Reservation.RoomNumber + " is now ready you. Enjoy your stay, and let us know if you need anything.";

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



        /// <summary>
        /// custom greet guest button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void customMsg_Click(object sender, RoutedEventArgs e)
        {
            // get selected guest from drop down list
            string customGuest = boxGuest.Text;

            // get selected company from drop down list
            string customCompany = boxCompany.Text;

            // Null checks
            if (customGuest != null || customCompany != null)
            {
                // greet customer using selected values from drop down lists.
                string customGreet = $"Good Morning {customGuest}, and welcome to {customCompany}. Enjoy your stay, and let us know if you need anything.";
                MessageBox.Show(customGreet);
            }
            else MessageBox.Show("Plese select a guest and hotel first.");



        }
    }
}
