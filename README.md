# reservation Messaging using WPF

MainWindow.xaml.cs is the main file to look at and contains all the logic.

This application messages a guest about their reservation made at a hotel

This application has 2 main parts to it.  On the left hand side of the application, a list of all the guests and their information is displayed to the user.

You will then select a guest from the list and click the auto message button to send an automated message to the guest using pre filled information we got from the json files.

On the right hand side, you will select a guest from a drop down menu, and you will also select a company from the drop down menu.  After selecting a guest and company/hotel you will click the custom msg button to send a custom message 




# An overview of design decisions
I created a guest class, company class, and reservation class.  The guest class mirrored the json provided and had an Id, first name, last name, and then a reservation. 

I created a reservation class to mirror the json data that was included with the guest json file.  The reservation class had properties for room number, starting time, and ending time.

The company class mirrored the info given from the json file too and had the fields for Id, company name, city, and timezone.

Overall, I was able to import all the data from the provided json files and was able to use that data in my application.



# What language you picked and why

I went with C# because that is the language I am the most comfortable with.




# Your process for verifying the correctness of you program

I did many console logs and setting break points as I looped through all my data sets.  This was to verify that I was converting the JSON file to actual objects correctly and that they had all the correct data.

I used null checks to make sure that my application wouldn't crash because I was using lists and drop down boxes that are naturally empty and null to begin with and that will crash the application if you dont select something and then click the buttons.



# What didn't you get to, or what else might you do with more time?

The one thing that gave me trouble was the start times and ending times.  I assumed that it was epoch times using milleseconds and converted the data that way into a date and time.  Although that worked, I still wasn't 100 percent sure if it was correct and would have liked to ask someone about this information so I could provide a better solution.
