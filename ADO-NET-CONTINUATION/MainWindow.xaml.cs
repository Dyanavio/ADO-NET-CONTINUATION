using ADO_NET_CONTINUATION.Data;
using ADO_NET_CONTINUATION.Data.Entities;
using System.Data;
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

namespace ADO_NET_CONTINUATION;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private DataContext context;
    public MainWindow()
    {
        context = new();
        InitializeComponent();
    }

    private void Button1_Click(object sender, RoutedEventArgs e)
    {
        // Basic queries in Entity Framework
        var query = context.Users.Where(u => u.Birthdate.Equals(DateTime.Now));
        // IQueryable - query was not executed
        // IEnumerable - query was executed
        // Query was not executed. It is the command that is created
        // To execute query:
        // a) use agregation function
        // b) start the loop
        // c) use direct type conversion (.ToArray, .ToList(), .AsEnumerable(), ...)
        //TextBlock1.Text = $"There are {query.Count()} users in 'Users' table that have been born already";
    }

    private void Button2_Click(object sender, RoutedEventArgs e)
    {
        var query = context.Users.Join                      //Users
            (                                               //Join
                context.UsersAccesses,                      //UsersAccesses
                u => u.Id,                                  //ON Users.Id
                ua => ua.UserId,                            // = UsersAccesses.UserId
                (u, ua) => new { User = u, Access = ua }    // Select *
            );
        int i = 1;
        foreach(var item in query)
        {
            TextBlock1.Text += $"{i++}) {item.User.Name} | {item.Access.RoleId}\n";
        }
        TextBlock1.Text += "------------------------\n";
        // Nevigation Properties can replace JOIN
        i = 1;
        foreach (var ua in context.UsersAccesses)
        {
            TextBlock1.Text += $"{i++}) {ua.User.Name} {ua.RoleId}\n";
        }
    }

    private void Button3_Click(object sender, RoutedEventArgs e)
    {
        // Ordering
        foreach(var item in context.Users.OrderBy(u => u.Name))
        {
            TextBlock1.Text += $"{item.Name} {item.Birthdate}\n";
        }
        TextBlock1.Text += "\n";
        foreach(var item in context.Users.OrderByDescending(u => u.Birthdate))
        {
            TextBlock1.Text += $"{item.Name} {item.Birthdate}\n";
        }
    }

    private void Button4_Click(object sender, RoutedEventArgs e)
    {
        // Grouping by
        TextBlock1.Text += string.Join('\n', context.Users.GroupJoin
                        (
                            context.UsersAccesses,
                            u => u.Id,
                            ua => ua.UserId,
                            (u, uas) => $"{u.Name} {uas.Count()}"
                        ));
        // Also you can use Navigation properties
        TextBlock1.Text += string.Join('\n', context.Users.GroupJoin
                        (
                            context.UsersAccesses,
                            u => u.Id,
                            ua => ua.UserId,
                            (u, uas) => $"{u.Name} {uas.Count()}"
                        ));
    }
    //---------------- HOMEWORK ----------------
    private void Button5_Click(object sender, RoutedEventArgs e)
    {
        var query = from user in context.Users where user.Birthdate == (from u in context.Users select u.Birthdate).Min() select user;
        foreach(var item in query)
        {
            TextBlock1.Text += $"The oldest: {item.Name} {item.Birthdate}";
        }
    }

    private void Button6_Click(object sender, RoutedEventArgs e)
    {
        var query = (from user in context.Users orderby user.RegisteredAt descending select user).Take(3);
        foreach(var item in query)
        {
            TextBlock1.Text += $"{item.Name} {item.RegisteredAt}\n";
        }
    }

    private void Button7_Click(object sender, RoutedEventArgs e)
    {
        var query = from u in context.Users join ua in context.UsersAccesses on u.Id equals ua.UserId join ur in context.UsersRoles on ua.RoleId equals ur.Id group u by ur.Id into roleGroup
                    select new
                    {
                        Role = roleGroup.Key,
                        Count = roleGroup.Count()
                    };

        foreach (var item in query)
        {
            TextBlock1.Text += $"{item.Role} - {item.Count}\n";
        }

    }
}
//Homework
// Create Entity framework queries for the following tasks:
//  1) Output the oldest user (by age)
//  2) Output 3 most recently registered Users (by RegistrationDate)
//  3) Output (role name) - (number of customers that have this role)