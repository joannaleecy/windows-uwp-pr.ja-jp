---
xxxxx: Xxxxxx x Xxxxxxxxx Xxxxxxxx xxxxx xxx
xxxxxxxxxxx: Xxxx xx Xxxx Y xx x xxxxxxxx xxxxxxxxxxx xx xxx xx xxxxxx x Xxxxxxx YY XXX (Xxxxxxxxx Xxxxxxx Xxxxxxxx) xxx xxxx xxxx Xxxxxxxxx Xxxxxxxx xx xx xxxxxxxxxxx xx xxxxxxxxxxx xxxxxxxx xxx xxxxxxxx xxxxxxxxxxxxxx xxxxxxx.
xx.xxxxxxx: XYXYYYYY-XYXY-YXYY-YYXX-YYYYYYXYXYXX
---

# Xxxxxx x Xxxxxxxxx Xxxxxxxx xxxxx xxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


\[Xxxx xxxxxxxxxxx xxxxxxx xx xxx-xxxxxxxx xxxxxxx xxxxx xxx xx xxxxxxxxxxxxx xxxxxxxx xxxxxx xx'x xxxxxxxxxxxx xxxxxxxx. Xxxxxxxxx xxxxx xx xxxxxxxxxx, xxxxxxx xx xxxxxxx, xxxx xxxxxxx xx xxx xxxxxxxxxxx xxxxxxxx xxxx.\]

Xxxx xx Xxxx Y xx x xxxxxxxx xxxxxxxxxxx xx xxx xx xxxxxx x Xxxxxxx YY XXX (Xxxxxxxxx Xxxxxxx Xxxxxxxx) xxx xxxx xxxx Xxxxxxxxx Xxxxxxxx xx xx xxxxxxxxxxx xx xxxxxxxxxxx xxxxxxxx xxx xxxxxxxx xxxxxxxxxxxxxx xxxxxxx. Xxx xxx xxxx x xxxxxxxx xxx xxxx-xx xxx xxxxxx x Xxxxxxxx Xxx xxx xxxx xxxxxxx. Xxxxx xxxxxxxx xxxx xx xxxxxxxxx xx xxx XXX xxxx xx xxxxx xx Xxxxxxx Xxxxxxxx xx xxxxxxxxxxxxx xx Xxxxxxxxx Xxxxxxxx.

Xxxx xxxxxxxxxxx xx xxxxx xxxx xxx xxxxx: xxxxxxxx xxx xxx xxx xxxxxxxxxx xxx xxxxxxx xxxxxxx. Xxxx xxx'xx xxxxxxxx xxxx xxxx xxxxxxx, xxxxxxxx xx xx Xxxx Y: [Xxxxxxxxx Xxxxxxxx xxxxx xxxxxxx](microsoft-passport-login-auth-service.md).

Xxxxxx xxx xxxxx, xxx xxxxxx xxxx xxx [Xxxxxxxxx Xxxxxxxx xxx Xxxxxxx Xxxxx](microsoft-passport.md) xxxxxxxx xxx x xxxxxxx xxxxxxxxxxxxx xx xxx Xxxxxxxxx Xxxxxxxx xxxxx.

## Xxx xxxxxxx


Xx xxxxx xx xxxxx xxxx xxxxxxx, xxx'xx xxxx xxxx xxxxxxxxxx xxxx X#, xxx XXXX. Xxx'xx xxxx xxxx xx xx xxxxx Xxxxxx Xxxxxx YYYY (Xxxxxxxxx Xxxxxxx xx xxxxxxx) xx x Xxxxxxx YY xxxxxxx.

-   Xxxx Xxxxxx Xxxxxx YYYY xxx xxxxxx Xxxx > Xxx > Xxxxxxx.
-   Xxxx xxxx xxxx x “Xxx Xxxxxxx” xxxxxx. Xxxxxxxxxx xx Xxxxxxxxx > Xxxxxx X#.
-   Xxxxxx Xxxxx Xxx (Xxxxxxxxx Xxxxxxx) xxx xxxx xxxx xxxxxxxxxxx "XxxxxxxxXxxxx".
-   Xxxxx xxx Xxx xxx xxx xxxxxxxxxxx (XY), xxx xxxxxx xxx x xxxxx xxxxxx xxxxx xx xxx xxxxxx. Xxxxx xxx xxxxxxxxxxx.

![](images/passport-login-1.png)

## Xxxxxxxx Y: Xxxxx xxxx Xxxxxxxxx Xxxxxxxx


Xx xxxx xxxxxxxx xxx xxxx xxxxx xxx xx xxxxx xx Xxxxxxxxx Xxxxxxxx xx xxxxx xx xxx xxxxxxx, xxx xxx xx xxxx xxxx xx xxxxxxx xxxxx Xxxxxxxxx Xxxxxxxx.

-   Xx xxx xxx xxxxxxx xxxxxx x xxx xxxxxx xx xxx xxxxxxxx xxxxxx "Xxxxx". Xxxx xxxxxx xxxx xxxxxxx xxx xxxxx xxxx xxxx xx xxxxxxxxx xx xx xxxx xxxxxx. Xxxxx xxxxx xx xxx xxxxxxx xx xxxxxxxx xxxxxxxx, xxxxxx Xxx > Xxx Xxxxxx, xxxx xxxxxx xxx xxxxxx xx Xxxxx.

    ![](images/passport-login-2.png)

-   Xxxxx xxxxx xx xxx xxx Xxxxx xxxxxx, xxxxxx Xxx > Xxx Xxxx xxx xxxxxx Xxxxx Xxxx. Xxxx xxxx xxxx "Xxxxx.xxxx".

    ![](images/passport-login-3.png)

-   Xx xxxxxx xxx xxxx xxxxxxxxx xxx xxx xxx xxxxx xxxx, xxx xxx xxxxxxxxx XXXX. Xxxx XXXX xxxxxxx x XxxxxXxxxx xx xxxxx xxx xxxxxxxxx xxxxxxxx:

    -   XxxxXxxxx xxxx xxxx xxxxxxx x xxxxx.
    -   XxxxXxxxx xxx xxxxx xxxxxxxx.
    -   XxxxXxx xxx xxx xxxxxxxx xx xxxxx.
    -   Xxxxxx xx xxxxxxxx xx x xxxxxxxx xxxx.
    -   XxxxXxxxx xx xxxxxxx xxx xxxxxx xx Xxxxxxxxx Xxxxxxxx.
    -   XxxxXxxxx xx xxxxxxx xxx Xxxxx xxxx xx xxxxx xx xx xxxxxxx xx xxxxxxxxxx xxxxx.

    ```xaml
    <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
      <StackPanel Orientation="Vertical">
        <TextBlock Text="Login" FontSize="36" Margin="4" TextAlignment="Center"/>
        <TextBlock x:Name="ErrorMessage" Text="" FontSize="20" Margin="4" Foreground="Red" TextAlignment="Center"/>
        <TextBlock Text="Enter your username below" Margin="0,0,0,20"
                   TextWrapping="Wrap" Width="300"
                   TextAlignment="Center" VerticalAlignment="Center" FontSize="16"/>
        <TextBox x:Name="UsernameTextBox" Margin="4" Width="250"/>
        <Button x:Name="PassportSignInButton" Content="Login" Background="DodgerBlue" Foreground="White"
            Click="PassportSignInButton_Click" Width="80" HorizontalAlignment="Center" Margin="0,20"/>
        <TextBlock Text="Don&#39;t have an account?"
                    TextAlignment="Center" VerticalAlignment="Center" FontSize="16"/>
        <TextBlock x:Name="RegisterButtonTextBlock" Text="Register now"
                   PointerPressed="RegisterButtonTextBlock_OnPointerPressed"
                   Foreground="DodgerBlue"
                   TextAlignment="Center" VerticalAlignment="Center" FontSize="16"/>
        <Border x:Name="PassportStatus" Background="#22B14C"
                   Margin="0,20" Height="100" >
          <TextBlock x:Name="PassportStatusText" Text="Microsoft Passport is ready to use!"
                 Margin="4" TextAlignment="Center" VerticalAlignment="Center" FontSize="20"/>
        </Border>
        <TextBlock x:Name="LoginExplaination" FontSize="24" TextAlignment="Center" TextWrapping="Wrap" 
            Text="Please Note: To demonstrate a login, validation will only occur using the default username &#39;sampleUsername&#39;"/>
      </StackPanel>
    </Grid>
    ```

-   X xxx xxxxxxx xxxx xx xx xxxxx xx xxx xxxx xxxxxx xx xxx xxx xxxxxxxx xxxxxxxx. Xxxxxx xxxxx XY xx xxx xxx Xxxxxxxx Xxxxxxxx xx xxx xx xxx Xxxxx.xxxx.xx. Xxx xx xxx xxxxxxxxx xxx xxxxx xxxxxxx xx xxxxxx xxx Xxxxx xxx Xxxxxxxx xxxxxx. Xxx xxx xxxxx xxxxxxx xxxx xxx xxx XxxxxXxxxxxx.Xxxx xx xx xxxxx xxxxxx.

    ```cs
    namespace PassportLogin.Views
    {
        public sealed partial class Login : Page
        {
            public Login()
            {
                this.InitializeComponent();
            }
     
            private void PassportSignInButton_Click(object sender, RoutedEventArgs e)
            {
                ErrorMessage.Text = "";
            }
            private void RegisterButtonTextBlock_OnPointerPressed(object sender, PointerRoutedEventArgs e)
            {
                ErrorMessage.Text = "";
            }
        }
    }
    ```

-   Xx xxxxx xx xxxxxx xxx Xxxxx xxxx, xxxx xxx XxxxXxxx xxxx xx xxxxxxxx xx xxx Xxxxx xxxx xxxx xxx XxxxXxxx xx xxxxxx. Xxxx xxx XxxxXxxx.xxxx.xx xxxx. Xx xxx xxxxxxxx xxxxxxxx xxxxxx xxxxx xx XxxxXxxx.xxxx.xx. Xx xxx xxx’x xxxx xxxx xxxxx xxx xxxxxx xxxxx xxxx xx XxxxXxxx.xxxx xx xxxx xxx xxxx xxxxxx. Xxxxxx x xxxxxx xxxxx xxxxxxx xxxxxx xxxx xxxx xxxxxxxx xx xxx xxxxx xxxx. Xxx xxxx xxxx xx xxx x xxxxxxxxx xx xxx Xxxxx xxxxxxxxx.

    ```cs
    using PassportLogin.Views;
     
    namespace PassportLogin
    {
        public sealed partial class MainPage : Page
        {
            public MainPage()
            {
                this.InitializeComponent();
                Loaded += MainPage_Loaded;
            }
     
            private void MainPage_Loaded(object sender, RoutedEventArgs e)
            {
                Frame.Navigate(typeof(Login));
            }
        }
    }
    ```

-   Xx xxx Xxxxx xxxx xxx xxxx xx xxxxxx xxx XxXxxxxxxxxXx xxxxx xx xxxxxxxx xx Xxxxxxxxx Xxxxxxxx xx xxxxxxxxx xx xxxx xxxxxxx. Xx Xxxxx.xxxx.xx xxxxxxxxx xxx xxxxxxxxx. Xxx xxxx xxxxxx xxxx xxx XxxxxxxxxXxxxxxxxXxxxxx xxxxxx xxxxx xx xxxxx. Xxxx xx xxxxxxx xx xxxx xxx xxxxxxxxx xx xxx.

    ```cs
    public sealed partial class Login : Page
    {
        public Login()
        {
            this.InitializeComponent();
        }
     
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            // Check Microsoft Passport is setup and available on this machine
            if (await MicrosoftPassportHelper.MicrosoftPassportAvailableCheckAsync())
            {
            }
            else
            {
                // Microsoft Passport is not setup so inform the user
                PassportStatus.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 50, 170, 207));
                PassportStatusText.Text = "Microsoft Passport is not setup!\n" + 
                    "Please go to Windows Settings and set up a PIN to use it.";
                PassportSignInButton.IsEnabled = false;
            }
        }
    }
    ```

-   Xx xxxxxx xxx XxxxxxxxxXxxxxxxxXxxxxx xxxxx, xxxxx xxxxx xx xxx xxxxxxxx XxxxxxxxXxxxx (Xxxxxxxxx Xxxxxxx) xxx xxxxx Xxx > Xxx Xxxxxx. Xxxx xxxx xxxxxx Xxxxx.

    ![](images/passport-login-5.png)

-   Xxxxx xxxxx xx xxx Xxxxx xxxxxx xxx xxxxx Xxx > Xxxxx. Xxxx xxxx xxxxx "XxxxxxxxxXxxxxxxxXxxxxx.xx".
-   Xxxxxx xxx xxxxx xxxxxxxxxx xx XxxxxxxxxXxxxxxxxXxxxxx xx xxxxxx xxxxxx, xxxx xxx xxx xxxxxxxxx xxxxxx xxxx xx xxxxxx xxx xxxx xx Xxxxxxxxx Xxxxxxxx xx xxxxx xx xx xxxx xx xxx. Xxx xxxx xxxx xx xxx xxx xxxxxxxx xxxxxxxxxx.

    ```cs
    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using Windows.Security.Credentials;
     
    namespace PassportLogin.Utils
    {
        public static class MicrosoftPassportHelper
        {
            /// <summary>
            /// Checks to see if Passport is ready to be used.
            /// 
            /// Passport has dependencies on:
            ///     1. Having a connected Microsoft Account
            ///     2. Having a Windows PIN set up for that _account on the local machine
            /// </summary>
            public static async Task<bool> MicrosoftPassportAvailableCheckAsync()
            {
                bool keyCredentialAvailable = await KeyCredentialManager.IsSupportedAsync();
                if (keyCredentialAvailable == false)
                {
                    // Key credential is not enabled yet as user 
                    // needs to connect to a Microsoft Account and select a PIN in the connecting flow.
                    Debug.WriteLine("Microsoft Passport is not setup!\nPlease go to Windows Settings and set up a PIN to use it.");
                    return false;
                }
     
                return true;
            }
        }
    }
    ```

-   Xx Xxxxx.xxxx.xx xxx x xxxxxxxxx xx xxx Xxxxx xxxxxxxxx. Xxxx xxxx xxxxxxx xxx xxxxx xx xxx XxXxxxxxxxxXx xxxxxx.

    ```cs
    using PassportLogin.Utils;
    ```

-   Xxxxx xxx xxx xxx xxxxxxxxxxx (XY). Xxx xxxx xx xxxxxxxxx xx xxx xxxxx xxxx xxx xxx Xxxxxxxxx Xxxxxxxx xxxxxx xxxx xxxxxxxx xx xxx xx Xxxxxxxx xx xxxxx xx xx xxxx. Xxx xxxxxx xxx xxxxxx xxx xxxxx xx xxxx xxxxxx xxxxxxxxxx xxx Xxxxxxxxx Xxxxxxxx xxxxxx xx xxxx xxxxxxx.

    ![](images/passport-login-6.png)

    ![](images/passport-login-7.png)

-   Xxx xxxx xxxxx xxx xxxx xx xx xx xxxxx xxx xxxxx xxx xxxxxxx xx. Xxxxxx x xxx xxxxxx xxxxxx "Xxxxxx".
-   Xx xxx Xxxxxx xxxxxx xxxxxx x xxx xxxxx xxxxxx "Xxxxxxx.xx". Xxxx xxxxx xxxx xxx xx xxxx xxxxxxx xxxxx. Xx xxxx xx x xxxxxx xx xxxx xxxx xxxxxxx x xxxxxxxx. Xxxxxx xxx xxxxx xxxxxxxxxx xx xxxxxx xxx xxx xxx Xxxxxxxx xxxxxxxx.
    
    ```cs
    namespace PassportLogin.Models
    {
        public class Account
        {
            public string Username { get; set; }
        }
    }
    ```

-   Xxx xxxx xxxx x xxx xx xxxxxx xxxxxxxx. Xxx xxxx xxxxx xx xxx xx xxxxx xx xx xxxxxx, xx x xxxxxxxx, x xxxx xx xxxxx xxxx xx xxxxx xxx xxxxxx xxxxxxx. Xxxxx xxxxx xx xxx Xxxxx xxxxxx xxx xxx x xxx xxxxx xxxxxx "XxxxxxxXxxxxx.xx". Xxxxxx xxx xxxxx xxxxxxxxxx xx xx xxxxxx xxxxxx. Xxx XxxxxxxXxxxxx xx x xxxxxx xxxxx xxxx xxxx xxxxxxx xxx xxx xxxxxxxxx xxxxxxx xx xxxx xxx xxxx xxx xxxx xx xxxxxxxx xxxxxxx. Xxxxxx xxx xxxxxxx xxxx xxxx xx xxxxx xx XxxXxxxxxxxxx. Xxx xxxx xxxx xxxx xx xxxxxxxx xxx xxxx xxx xxxxx xxx xxxxx xxx xxxxx xx. Xxxxxxxxxx xxxxxxxxxx xxxx xx xxxx xx xx xxxxxxxxxx.
    
    ```cs
    using System.IO;
    using System.Xml.Serialization;
    using Windows.Storage;
    using PassportLogin.Models;

    namespace PassportLogin.Utils
    {
        public static class AccountHelper
        {
            // In the real world this would not be needed as there would be a server implemented that would host a user account database.
            // For this tutorial we will just be storing accounts locally.
            private const string USER_ACCOUNT_LIST_FILE_NAME = "accountlist.txt";
            private static string _accountListPath = Path.Combine(ApplicationData.Current.LocalFolder.Path, USER_ACCOUNT_LIST_FILE_NAME);
            public static List<Account> AccountList = new List<Account>();
     
            /// <summary>
            /// Create and save a useraccount list file. (Updating the old one)
            /// </summary>
            private static async void SaveAccountListAsync()
            {
                string accountsXml = SerializeAccountListToXml();
     
                if (File.Exists(_accountListPath))
                {
                    StorageFile accountsFile = await StorageFile.GetFileFromPathAsync(_accountListPath);
                    await FileIO.WriteTextAsync(accountsFile, accountsXml);
                }
                else
                {
                    StorageFile accountsFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(USER_ACCOUNT_LIST_FILE_NAME);
                    await FileIO.WriteTextAsync(accountsFile, accountsXml);
                }
            }
     
            /// <summary>
            /// Gets the useraccount list file and deserializes it from XML to a list of useraccount objects.
            /// </summary>
            /// <returns>List of useraccount objects</returns>
            public static async Task<List<Account>> LoadAccountListAsync()
            {
                if (File.Exists(_accountListPath))
                {
                    StorageFile accountsFile = await StorageFile.GetFileFromPathAsync(_accountListPath);
     
                    string accountsXml = await FileIO.ReadTextAsync(accountsFile);
                    DeserializeXmlToAccountList(accountsXml);
                }
     
                return AccountList;
            }
     
            /// <summary>
            /// Uses the local list of accounts and returns an XML formatted string representing the list
            /// </summary>
            /// <returns>XML formatted list of accounts</returns>
            public static string SerializeAccountListToXml()
            {
                XmlSerializer xmlizer = new XmlSerializer(typeof(List<Account>));
                StringWriter writer = new StringWriter();
                xmlizer.Serialize(writer, AccountList);
     
                return writer.ToString();
            }
     
            /// <summary>
            /// Takes an XML formatted string representing a list of accounts and returns a list object of accounts
            /// </summary>
            /// <param name="listAsXml">XML formatted list of accounts</param>
            /// <returns>List object of accounts</returns>
            public static List<Account> DeserializeXmlToAccountList(string listAsXml)
            {
                XmlSerializer xmlizer = new XmlSerializer(typeof(List<Account>));
                TextReader textreader = new StreamReader(new MemoryStream(Encoding.UTF8.GetBytes(listAsXml)));
     
                return AccountList = (xmlizer.Deserialize(textreader)) as List<Account>;
            }
        }
    }
    ```

-   Xxxx, xxxxxxxxx x xxx xx xxx xxx xxxxxx xx xxxxxxx xxxx xxx xxxxx xxxx xx xxxxxxxx. Xxxxx xxxxxxx xxxx xxxx xxxx xxx xxxx. Xxx xxxxx xxxxxx xxxx xxx xxxx xxxx xxx xxxx xxxxx xx xxx xx x xxxxxxxxxx xxxxxx. Xx xxxxx xx xx xxxx xxxxxx xx xxxxxxxx xx xxxxx, xxxx xxxx xxxxxxxx xxxxxxx x xxxxxx xxxx xxxxx xx xxxx xxxxx. Xxxxx xxxxxxx xxxxxx xx xxxxx xx xxx XxxxxxxXxxxxx xxxxx.
    
    ```cs
    public static Account AddAccount(string username)
            {
                // Create a new account with the username
                Account account = new Account() { Username = username };
                // Add it to the local list of accounts
                AccountList.Add(account);
                // SaveAccountList and return the account
                SaveAccountListAsync();
                return account;
            }
     
            public static void RemoveAccount(Account account)
            {
                // Remove the account from the accounts list
                AccountList.Remove(account);
                // Re save the updated list
                SaveAccountListAsync();
            }
     
            public static bool ValidateAccountCredentials(string username)
            {
                // In the real world, this method would call the server to authenticate that the account exists and is valid.
                // For this tutorial however we will just have a existing sample user that is just "sampleUsername"
                // If the username is null or does not match "sampleUsername" it will fail validation. In which case the user should register a new passport user
     
                if (string.IsNullOrEmpty(username))
                {
                    return false;
                }
     
                if (!string.Equals(username, "sampleUsername"))
                {
                    return false;
                }
     
                return true;
            }<
    ```

-   Xxx xxxx xxxxx xxx xxxx xx xx xx xxxxxx x xxxx xx xxxxxxx xxxx xxx xxxx. Xx Xxxxx.xxxx.xx xxxxxx x xxx xxxxxxx xxxxxxxx xxxx xxxx xxxx xxx xxxxxxx xxxxxxx xxxxxxx xx. Xxxx xxx x xxx xxxxxx xxxx XxxxXxXxxxxxxx. Xxxx xxxx xxxxxxxx xxx xxxxxxx xxxxxxxxxxx xxxxx xxx XxxxxxxXxxxxx.XxxxxxxxXxxxxxxXxxxxxxxxxx xxxxxx. Xxxx xxxxxx xxxx xxxxxx x Xxxxxxx xxxxx xx xxx xxxxxxx xxxx xxxx xx xxx xxxx xx xxx xxxx xxxxx xxxxxx xxxxx xxx xxx xx xxx xxxxxxxx xxxx. Xxx xxxx xxxxx xxxxx xxx xxxx xxxxxx xx "xxxxxxXxxxxxxx".

    ```cs
    using PassportLogin.Models;
    using PassportLogin.Utils;
    using System.Diagnostics;
     
    namespace PassportLogin.Views
    {
        public sealed partial class Login : Page
        {
            private Account _account;
     
            public Login()
            {
                this.InitializeComponent();
            }
     
            protected override async void OnNavigatedTo(NavigationEventArgs e)
            {
                // Check Microsoft Passport is setup and available on this machine
                if (await MicrosoftPassportHelper.MicrosoftPassportAvailableCheckAsync())
                {
                }
                else
                {
                    // Microsoft Passport is not setup so inform the user
                    PassportStatus.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 50, 170, 207));
                    PassportStatusText.Text = "Microsoft Passport is not setup!\nPlease go to Windows Settings and set up a PIN to use it.";
                    PassportSignInButton.IsEnabled = false;
                }
            }
     
            private void PassportSignInButton_Click(object sender, RoutedEventArgs e)
            {
                ErrorMessage.Text = "";
                SignInPassport();
            }
     
            private void RegisterButtonTextBlock_OnPointerPressed(object sender, PointerRoutedEventArgs e)
            {
                ErrorMessage.Text = "";
            }
     
            private async void SignInPassport()
            {
                if (AccountHelper.ValidateAccountCredentials(UsernameTextBox.Text))
                {
                    // Create and add a new local account
                    _account = AccountHelper.AddAccount(UsernameTextBox.Text);
                    Debug.WriteLine("Successfully signed in with traditional credentials and created local account instance!");
     
                    //if (await MicrosoftPassportHelper.CreatePassportKeyAsync(UsernameTextBox.Text))
                    //{
                    //    Debug.WriteLine("Successfully signed in with Microsoft Passport!");
                    //}
                }
                else
                {
                    ErrorMessage.Text = "Invalid Credentials";
                }
            }
        }
    }
    ```

-   Xxx xxx xxxx xxxxxxx xxx xxxxxxxxx xxxx xxxx xxx xxxxxxxxxxx x xxxxxx xx XxxxxxxxxXxxxxxxxXxxxxx. Xx XxxxxxxxxXxxxxxxxXxxxxx.xx xxx xx x xxx xxxxxx xxxxxx XxxxxxXxxxxxxxXxxXxxxx. Xxxx xxxxxx xxxx xxx Xxxxxxxxx Xxxxxxxx XXX xx xxx [**XxxXxxxxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn973043). Xxxxxxx [**XxxxxxxXxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn973048) xxxx xxxxxx x Xxxxxxxx xxx xxxx xx xxxxxxxx xx xxx *xxxxxxxXx* xxx xxx xxxxx xxxxxxx. Xxxxxx xxxx xxx xxxxxxxx xx xxx xxxxxx xxxxxxxxx xx xxx xxx xxxxxxxxxx xx xxxxxxxxxxxx xxxx xx x xxxx xxxxx xxxxxxxx.

    ```cs
    /// <summary>
    /// Creates a Passport key on the machine using the _account id passed.
    /// </summary>
    /// <param name="accountId">The _account id associated with the _account that we are enrolling into Passport</param>
    /// <returns>Boolean representing if creating the Passport key succeeded</returns>
    public static async Task<bool> CreatePassportKeyAsync(string accountId)
    {
        KeyCredentialRetrievalResult keyCreationResult = await KeyCredentialManager.RequestCreateAsync(accountId, KeyCredentialCreationOption.ReplaceExisting);

        switch (keyCreationResult.Status)
        {
            case KeyCredentialStatus.Success:
                Debug.WriteLine("Successfully made key");

                // In the real world authentication would take place on a server.
                // So every time a user migrates or creates a new Microsoft Passport account Passport details should be pushed to the server.
                // The details that would be pushed to the server include:
                // The public key, keyAttesation if available, 
                // certificate chain for attestation endorsement key if available,  
                // status code of key attestation result: keyAttestationIncluded or 
                // keyAttestationCanBeRetrievedLater and keyAttestationRetryType
                // As this sample has no concept of a server it will be skipped for now
                // for information on how to do this refer to the second Passport sample

                //For this sample just return true
                return true;
            case KeyCredentialStatus.UserCanceled:
                Debug.WriteLine("User cancelled sign-in process.");
                break;
            case KeyCredentialStatus.NotFound:
                // User needs to setup Microsoft Passport
                Debug.WriteLine("Microsoft Passport is not setup!\nPlease go to Windows Settings and set up a PIN to use it.");
                break;
            default:
                break;
        }

        return false;
    }
    ```

-   Xxx xxx xxxx xxxxxxx xxx XxxxxxXxxxxxxxXxxXxxxx xxxxxx, xxxxxx xx xxx Xxxxx.xxxx.xx xxxx xxx xxxxxxxxx xxx xxxx xxxxxx xxx XxxxXxXxxxxxxx xxxxxx.

    ```cs
    private async void SignInPassport()
    {
        if (AccountHelper.ValidateAccountCredentials(UsernameTextBox.Text))
        {
            //Create and add a new local account
            _account = AccountHelper.AddAccount(UsernameTextBox.Text);
            Debug.WriteLine("Successfully signed in with traditional credentials and created local account instance!");

            if (await MicrosoftPassportHelper.CreatePassportKeyAsync(UsernameTextBox.Text))
            {
                Debug.WriteLine("Successfully signed in with Microsoft Passport!");
            }
        }
        else
        {
            ErrorMessage.Text = "Invalid Credentials";
        }
    }
    ```

-   Xxxxx xxx xxx xxx xxxxxxxxxxx. Xxx xxxx xx xxxxx xx xxx Xxxxx xxxx. Xxxx xx "xxxxxxXxxxxxxx" xxx xxxxx xxxxx. Xxx xxxx xx xxxxxxxx xxxx x Xxxxxxxxx Xxxxxxxx xxxxxx xxxxxx xxx xx xxxxx xxxx XXX. Xxxx xxxxxxxx xxxx XXX xxxxxxxxx xxx XxxxxxXxxxxxxxXxxXxxxx xxxxxx xxxx xx xxxx xx xxxxxx x Xxxxxxxx xxx. Xxxxxxx xxx xxxxxx xxxxxxx xx xxx xx xxx xxxxxxxx xxxxxx xxxxxxxxxx xxx xxxxx.

    ![](images/passport-login-8.png)

## Xxxxxxxx Y: Xxxxxxx xxx Xxxx Xxxxxxxxx Xxxxx


Xx xxxx xxxxxxxx, xxx xxxx xxxxxxxx xxxx xxx xxxxxxxx xxxxxxxx. Xxxx x xxxxxx xxxxxxxxxxxx xxxx xx xxxx xxxxxx xx xxxxx xx x xxxxxxx xxxx xxxxx xxxx xxx xxxx xxx xx xxxxxx xxxxx xxxxxxx. Xx Xxxxxxxx xxxxxxx x xxx xxx xxxxx xxxxxxx, x xxxx xxxxxxxxx xxxxxx xxx xx xxxxxxx, xxxxx xxxxxxxx xxx xxxxx xxxx xxxx xxxx xxxxxx xx xx xxxx xxxxxxx. X xxxx xxx xxxx xxxxxx xxx xx xxxxx xxxxxxxx xxx xx xxxxxxxx xx xxx xxxxxxx xxxxxx xxxxxxx xxxxxx xx xx-xxxxx x xxxxxxxx xx xxxx xxxx xxxxxxx xxxxxxxxxxxxx xx xxxxxx xxx xxxxxxx.

-   1. Xx xxx Xxxxx xxxxxx xxx x xxx xxxxx xxxx xxxxxx "Xxxxxxx.xxxx". Xxx xxx xxxxxxxxx XXXX xx xxxxxxxx xxx xxxx xxxxxxxxx. Xxxx xxxx xxxxxxx x xxxxx, xxx xxxxxx xx xxxxxxxx, xxx xxx xxxxxxx. Xxx xx xxx xxxxxxx xxxx xxxxxxxx xxxx xx x xxxx xxxx (xxxx xxx xxxx xxxxxx xxxxx), xxx xxx xxxxx xxxxxx xxxx xxxxxx xxxxxxxxxx xxxx xxxx.

    ```xaml
    <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
      <StackPanel Orientation="Vertical">
        <TextBlock x:Name="Title" Text="Welcome" FontSize="40" TextAlignment="Center"/>
        <TextBlock x:Name="UserNameText" FontSize="28" TextAlignment="Center" Foreground="Black"/>

        <Button x:Name="BackToUserListButton" Content="Back to User List" Click="Button_Restart_Click"
                HorizontalAlignment="Center" Margin="0,20" Foreground="White" Background="DodgerBlue"/>

        <Button x:Name="ForgetButton" Content="Forget Me" Click="Button_Forget_User_Click"
                Foreground="White"
                Background="Gray"
                HorizontalAlignment="Center"/>
      </StackPanel>
    </Grid>
    ```

-   Xx xxx Xxxxxxx.xxxx.xx xxxx xxxxxx xxxx, xxx x xxx xxxxxxx xxxxxxxx xxxx xxxx xxxx xxx xxxxxxx xxxx xx xxxxxx xx. Xxx xxxx xxxx xx xxxxxxxxx x xxxxxx xx xxxxxxxx xxx XxXxxxxxxxXx xxxxx, xxxx xxxx xxxxx xxx xxxxxxx xxxxxx xx xxx xxxxxxx xxxx. Xxx xxxx xxxx xxxx xx xxxxxxxxx xxx xxxxx xxxxx xxx xxx xxx xxxxxxx xxxxxxx xx xxx XXXX. Xxx xxxx xxxx x xxxxxxxxx xx xxx Xxxxxx xxx Xxxxx xxxxxxx.

    ```cs
    using PassportLogin.Models;
    using PassportLogin.Utils;
    using System.Diagnostics;
     
    namespace PassportLogin.Views
    {
        public sealed partial class Welcome : Page
        {
            private Account _activeAccount;
     
            public Welcome()
            {
                InitializeComponent();
            }
     
            protected override void OnNavigatedTo(NavigationEventArgs e)
            {
                _activeAccount = (Account)e.Parameter;
                if (_activeAccount != null)
                {
                    UserNameText.Text = _activeAccount.Username;
                }
            }
     
            private void Button_Restart_Click(object sender, RoutedEventArgs e)
            {
            }
     
            private void Button_Forget_User_Click(object sender, RoutedEventArgs e)
            {
                // Remove it from Microsoft Passport
                // MicrosoftPassportHelper.RemovePassportAccountAsync(_activeAccount);
     
                // Remove it from the local accounts list and resave the updated list
                AccountHelper.RemoveAccount(_activeAccount);
     
                Debug.WriteLine("User " + _activeAccount.Username + " deleted.");
            }
        }
    }
    ```

-   Xxx xxx xxxx xxxxxxx x xxxx xxxxxxxxx xxx xx xxx xxxxxx xxxx xxxxx xxxxx. Xxx xxxxxxx xx xxxxx xxxxxxx xxxx xxxx xxxxx xxxx xxx xxxxxxxxx xxxxx xx xx xxx xx xx xxxxxxx xxxx Xxxxxxxx. Xxx xxxx xx xxxxxxxxx x xxx xxxxxx xx XxxxxxxxxXxxxxxxxXxxxxx.xx xxxx xxxx xxxxxx xxxxxxxx x Xxxxxxxx xxxx. Xxxx xxxxxx xxxx xxx xxxxx Xxxxxxxxx Xxxxxxxx XXX’x xx xxxx xxx xxxxxx xxx xxxxxxx. Xx xxx xxxx xxxxx xxxx xxx xxxxxx xx xxxxxxx xxx xxxxxx xx xxxxxxxx xxxxxx xx xxxxxxxx xx xxx xxxx xxxxxxxx xxxxxxx xxxxx. Xxx xxxx xxxx x xxxxxxxxx xx xxx Xxxxxx xxxxxx.

    ```cs
    using PassportLogin.Models;

    /// <summary>
    /// Function to be called when user requests deleting their account.
    /// Checks the KeyCredentialManager to see if there is a Passport for the current user
    /// Then deletes the local key associated with the Passport.
    /// </summary>
    public static async void RemovePassportAccountAsync(Account account)
    {
        // Open the account with Passport
        KeyCredentialRetrievalResult keyOpenResult = await KeyCredentialManager.OpenAsync(account.Username);

        if (keyOpenResult.Status == KeyCredentialStatus.Success)
        {
            // In the real world you would send key information to server to unregister
            //e.g. RemovePassportAccountOnServer(account);
        }

        // Then delete the account from the machines list of Passport Accounts
        await KeyCredentialManager.DeleteAsync(account.Username);
    }
    ```

-   Xxxx xx Xxxxxxx.xxxx.xx, xxxxxxxxx xxx xxxx xxxx xxxxx XxxxxxXxxxxxxxXxxxxxxXxxxx.

    ```cs
    private void Button_Forget_User_Click(object sender, RoutedEventArgs e)
    {
        // Remove it from Microsoft Passport
        MicrosoftPassportHelper.RemovePassportAccountAsync(_activeAccount);
     
        // Remove it from the local accounts list and resave the updated list
        AccountHelper.RemoveAccount(_activeAccount);
     
        Debug.WriteLine("User " + _activeAccount.Username + " deleted.");
    }
    ```

-   Xx xxx XxxxXxXxxxxxxx xxxxxx (xx Xxxxx.xxxx.xx), xxxx xxx XxxxxxXxxxxxxxXxxXxxxx xx xxxxxxxxxx xx xxxxxx xxxxxxxx xx xxx Xxxxxxx xxxxxx xxx xxxx xxx Xxxxxxx.

    ```cs
    private async void SignInPassport()
    {
        if (AccountHelper.ValidateAccountCredentials(UsernameTextBox.Text))
        {
            // Create and add a new local account
            _account = AccountHelper.AddAccount(UsernameTextBox.Text);
            Debug.WriteLine("Successfully signed in with traditional credentials and created local account instance!");

            if (await MicrosoftPassportHelper.CreatePassportKeyAsync(UsernameTextBox.Text))
            {
                Debug.WriteLine("Successfully signed in with Microsoft Passport!");
                Frame.Navigate(typeof(Welcome), _account);
            }
        }
        else
        {
            ErrorMessage.Text = "Invalid Credentials";
        }
    }
    ```

-   Xxxxx xxx xxx xxx xxxxxxxxxxx. Xxxxx xxxx "xxxxxxXxxxxxxx" xxx xxxxx xxxxx. Xxxxx xxxx XXX xxx xx xxxxxxxxxx xxx xxxxxx xx xxxxxxxxx xx xxx xxxxxxx xxxxxx. Xxx xxxxxxxx xxxxxx xxxx xxx xxxxxxx xxx xxxxxx xxxxxx xx xxx xx xxx xxxx xxx xxxxxxx. Xxxxxx xxxx xxxx xxx xxxx xx xxxxxxx xxx xxxxxx xx xxx xxxxxxx xxxx. Xxx xxxx xxxx xx xxxxxx x xxxx xxxxxxxxx xxxx xxxx xxx xxx xxx xxxxxxxx xx.

    ![](images/passport-login-9.png)

-   Xx xxx Xxxxx xxxxxx xxxxxx x xxx xxxxx xxxx xxxxxx "XxxxXxxxxxxxx.xxxx" xxx xxx xxx xxxxxxxxx XXXX xx xxxxxx xxx xxxx xxxxxxxxx. Xxxx xxxx xxxx xxxxxxx x [**XxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br242878) xxxx xxxxxxxx xxx xxx xxxxx xx xxx xxxxx xxxxxxxx xxxx, xxx x Xxxxxx xxxx xxxx xxxxxxxx xx xxx xxxxx xxxx xx xxxxx xxx xxxx xx xxx xxxxxxx xxxxxxx.

    ```xaml
    <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
      <StackPanel Orientation="Vertical">
        <TextBlock x:Name="Title" Text="Select a User" FontSize="36" Margin="4" TextAlignment="Center" HorizontalAlignment="Center"/>

        <ListView x:Name="UserListView" Margin="4" MaxHeight="200" MinWidth="250" Width="250" HorizontalAlignment="Center">
          <ListView.ItemTemplate>
            <DataTemplate>
              <Grid Background="DodgerBlue" Height="50" Width="250" HorizontalAlignment="Stretch" VerticalAlignment="Stretch">
                <TextBlock Text="{Binding Username}" HorizontalAlignment="Center" TextAlignment="Center" VerticalAlignment="Center" Foreground="White"/>
              </Grid>
            </DataTemplate>
          </ListView.ItemTemplate>
        </ListView>

        <Button x:Name="AddUserButton" Content="+" FontSize="36" Width="60" Click="AddUserButton_Click" HorizontalAlignment="Center"/>
      </StackPanel>
    </Grid><
    ```

-   Xx XxxxXxxxxxxxx.xxxx.xx xxxxxxxxx xxx xxxxxx xxxxxx xxxx xxxx xxxxxxxx xx xxx xxxxx xxxx xx xxxxx xxx xx xxxxxxxx xx xxx xxxxx xxxx. Xxxx xxxxxxxxx xxx XxxxxxxxxXxxxxxx xxxxx xxx xxx XxxxXxxx xxx x xxxxx xxxxx xxx xxx Xxxxxx.

    ```cs
    using System.Diagnostics;
    using PassportLogin.Models;
    using PassportLogin.Utils;

    namespace PassportLogin.Views
    {
        public sealed partial class UserSelection : Page
        {
            public UserSelection()
            {
                InitializeComponent();
                Loaded += UserSelection_Loaded;
            }

            private void UserSelection_Loaded(object sender, RoutedEventArgs e)
            {
                if (AccountHelper.AccountList.Count == 0)
                {
                    //If there are no accounts navigate to the LoginPage
                    Frame.Navigate(typeof(Login));
                }


                UserListView.ItemsSource = AccountHelper.AccountList;
                UserListView.SelectionChanged += UserSelectionChanged;
            }

            /// <summary>
            /// Function called when an account is selected in the list of accounts
            /// Navigates to the Login page and passes the chosen account
            /// </summary>
            private void UserSelectionChanged(object sender, RoutedEventArgs e)
            {
                if (((ListView)sender).SelectedValue != null)
                {
                    Account account = (Account)((ListView)sender).SelectedValue;
                    if (account != null)
                    {
                        Debug.WriteLine("Account " + account.Username + " selected!");
                    }
                    Frame.Navigate(typeof(Login), account);
                }
            }

            /// <summary>
            /// Function called when the "+" button is clicked to add a new user.
            /// Navigates to the Login page with nothing filled out
            /// </summary>
            private void AddUserButton_Click(object sender, RoutedEventArgs e)
            {
                Frame.Navigate(typeof(Login));
            }
        }
    }
    ```

<!-- -->

-   Xxxxx xxx x xxx xxxxxx xx xxx xxx xxxxx xxx xxxx xx xxxxxxxxx xx xxx XxxxXxxxxxxxx xxxx. Xx XxxxXxxx.xxxx.xx xxx xxxxxx xxxxxxxx xx xxx XxxxXxxxxxxxx xxxx xxxxxxx xx xxx Xxxxx xxxx. Xxxxx xxx xxx xx xxx xxxxxx xxxxx xx XxxxXxxx xxx xxxx xxxx xx xxxx xxx xxxxxxxx xxxx xx xxxx xxx XxxxXxxxxxxxx xxxx xxx xxxxx xx xxxxx xxx xxx xxxxxxxx. Xxxx xxxx xxxxxxx xxxxxxxx xxx xxxxxx xxxxxx xx xx xxxxx xxx xxxx xxxxxx x xxxxxxxxx xx xxx Xxxxx xxxxxx.

    ```xx
    xxxxx XxxxxxxxXxxxx.Xxxxx;

    xxxxxxx xxxxx xxxx XxxxXxxx_Xxxxxx(xxxxxx xxxxxx, XxxxxxXxxxxXxxx x)
    {
        // Xxxx xxx xxxxx Xxxxxxxx Xxxx xxxxxx xxxxxxxxxx xx xxx XxxxXxxxxxxxx xxxx
        xxxxx XxxxxxxXxxxxx.XxxxXxxxxxxXxxxXxxxx();
        Xxxxx.Xxxxxxxx(xxxxxx(XxxxXxxxxxxxx));
    }
    ```

-   Xxxx xxx xxxx xxxx xx xxxxxxxx xx xxx XxxxXxxxxxxxx xxxx xxxx xxx Xxxxxxx xxxx. Xx xxxx xxxxx xxxxxx xxx xxxxxx xxxxxxxx xxxx xx xxx XxxxXxxxxxxxx xxxx.

    ```xx
    xxxxxxx xxxx Xxxxxx_Xxxxxxx_Xxxxx(xxxxxx xxxxxx, XxxxxxXxxxxXxxx x)
    {
        Xxxxx.Xxxxxxxx(xxxxxx(XxxxXxxxxxxxx));
    }

    xxxxxxx xxxx Xxxxxx_Xxxxxx_Xxxx_Xxxxx(xxxxxx xxxxxx, XxxxxxXxxxxXxxx x)
    {
        // Xxxxxx xx xxxx Xxxxxxxxx Xxxxxxxx
        XxxxxxxxxXxxxxxxxXxxxxx.XxxxxxXxxxxxxxXxxxxxxXxxxx(_xxxxxxXxxxxxx);

        // Xxxxxx xx xxxx xxx xxxxx xxxxxxxx xxxx xxx xxxxxx xxx xxxxxxx xxxx
        XxxxxxxXxxxxx.XxxxxxXxxxxxx(_xxxxxxXxxxxxx);

        Xxxxx.XxxxxXxxx("Xxxx " + _xxxxxxXxxxxxx.Xxxxxxxx + " xxxxxxx.");

        // Xxxxxxxx xxxx xx XxxxXxxxxxxxx xxxx.
        Xxxxx.Xxxxxxxx(xxxxxx(XxxxXxxxxxxxx));
    }
    ```

-   Xx xxx Xxxxx xxxx xxx xxxx xxxx xx xxx xx xx xxx xxxxxxx xxxxxxxx xxxx xxx xxxx xx xxx XxxxXxxxxxxxx xxxx. Xx XxXxxxxxxxxXx xxxxx xxxxx xxx xxxxxxx xxxxxx xx xxx xxxxxxxxxx. Xxxxx xx xxxxxx x xxx xxxxxxx xxxxxxxx xxxx xxxx xxxxxxxx xx xxx xxxxxxx xx xx xxxxxxxx xxxxxxx. Xxxx xxxxxx xxx XxXxxxxxxxxXx xxxxx.

    ```cs
    namespace PassportLogin.Views
    {
        public sealed partial class Login : Page
        {
            private Account _account;
            private bool _isExistingAccount;

            public Login()
            {
                InitializeComponent();
            }

            /// <summary>
            /// Function called when this frame is navigated to.
            /// Checks to see if Microsoft Passport is available and if an account was passed in.
            /// If an account was passed in set the "_isExistingAccount" flag to true and set the _account
            /// </summary>
            protected override async void OnNavigatedTo(NavigationEventArgs e)
            {
                // Check Microsoft Passport is setup and available on this machine
                if (await MicrosoftPassportHelper.MicrosoftPassportAvailableCheckAsync())
                {
                    if (e.Parameter != null)
                    {
                        _isExistingAccount = true;
                        // Set the account to the existing account being passed in
                        _account = (Account)e.Parameter;
                        UsernameTextBox.Text = _account.Username;
                        SignInPassport();
                    }
                }
                else
                {
                    // Microsoft Passport is not setup so inform the user
                    PassportStatus.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 50, 170, 207));
                    PassportStatusText.Text = "Microsoft Passport is not setup!\n" + 
                        "Please go to Windows Settings and set up a PIN to use it.";
                    PassportSignInButton.IsEnabled = false;
                }
            }
        }
    }
    ```

-   Xxx XxxxXxXxxxxxxx xxxxxx xxxx xxxx xx xx xxxxxxx xx xxxx xx xx xxx xxxxxxxx xxxxxxx. Xxx XxxxxxxxxXxxxxxxxXxxxxx xxxx xxxx xxxxxxx xxxxxx xx xxxx xxx xxxxxxx xxxx Xxxxxxxx, xx xxx xxxxxxx xxxxxxx xxx x Xxxxxxxx xxx xxxxxxx xxx xx. Xxxxxxxxx xxx xxx xxxxxx xx XxxxxxxxxXxxxxxxxXxxxxx.xx xx xxxx xx xx xxxxxxxx xxxx xxxx xxxxxxxx. Xxx xxxxxxxxxxx xx xxxx xxxx xx xxx xxxx xxxxxx xxxx xxxxxxx xxx xxxx xxxxxxxx.

    ```cs
    /// <summary>
    /// Attempts to sign a message using the Passport key on the system for the accountId passed.
    /// </summary>
    /// <returns>Xxxxxxx xxxxxxxxxxxx xx xxxxxxxx xxx Xxxxxxxx xxxxxxxxxxxxxx xxxxxxx xxxxxxxxx</returns>
    public static async Task<bool> XxxXxxxxxxxXxxxxxxxxxxxxxXxxxxxxXxxxx(Xxxxxxx xxxxxxx)
    {
        XxxXxxxxxxxxxXxxxxxxxxXxxxxx xxxxXxxXxxxxx = xxxxx XxxXxxxxxxxxxXxxxxxx.XxxxXxxxx(xxxxxxx.Xxxxxxxx);
        // Xxxxxxx XxxxXxxxx xxxx xxxxx xxx xxxx xxxxxx xx xxxx xx xxxxxxxxx xx xxx xxx xxx xxxx xxx xxxxxxx xxxx xxxxxxxxxxx xxxxx.
        // Xx xxx xxxxxx xx xxxxx xxx xxxx xx xxxx xx xxxxx xxx xxx xxx xxx xxxxxxxxx:
        // xxx xxxxxxxXxxxxx = xxxxx Xxxxxxx.Xxxxxxxx.Xxxxxxxxxxx.XX.XxxxXxxxxxxXxxxxxxx.XxxxxxxXxxxxxxxxxxxXxxxx(xxxxxxx.Xxxxxxxx);
        // Xxxx xxxx xxx xxx xxx xxxxxx xxx xxxxxxxx xx xxx xxxxxxxxx xxxxxx xx Xxxxxxxxx Xxxxxxx xx xxx XXX xxxx xxx Xxxxxxxxx Xxxxxxxx.

        xx (xxxxXxxXxxxxx.Xxxxxx == XxxXxxxxxxxxxXxxxxx.Xxxxxxx)
        {
            // Xx XxxxXxxxx xxx xxxxxxxxx, xxx xxxx xxxxx xx xxxxx xxxxx xx xxxxxxx xxx xxxxxx xxxxxxxxxxx xxxxxxxx xxxxxx xx xxxxxxx xxxxxxxx.
            // Xx xx xxxx xxxx xxx xxxxx Xxxxxxx x xxxxxxxxx xxxx xxx Xxxxxx. Xxx xxxxxx xxxxx xxxx xxxx xxxxxxxxx xxx xxx xxxxxx
            // xxxxx xxxxx xxx xxxxxx xxxxxxxxx. Xx xx xx xxxxxxx xx xxxxx xxxxx xxx xxxx xxxxxx xx xxx xxxxxxx.
            // Xxx xxxxx xxxxxx xxxx x xxx xxxxxx xxxxxx XxxxxxxXxxxXxxxx xx xxxxxx xxx xxxx
            // x.x. XxxxxxxXxxxXxxxx(xxxxXxxXxxxxx);
            // Xxxxx xx xxx xxxxxx Xxxxxxxxx Xxxxxxxx xxxxxx xxx xxxxxxxxxxx xx xxx xx xx xxxx.

            // Xxx xxxx xxxxxx xxxxx xx xxx xxxxxxx xx x xxxxxx xxxxxxxxxxx xx xxxx xxxxxx xxxx.
            xxxxxx xxxx;
        }
        xxxx xx (xxxxXxxXxxxxx.Xxxxxx == XxxXxxxxxxxxxXxxxxx.XxxXxxxx)
        {
            // Xx xxx _xxxxxxx xx xxx xxxxx xx xxxx xxxxx. Xx xxxxx xx xxx xx xxx xxxxxx. 
            // Y. Xxxxxxxxx Xxxxxxxx xxx xxxx xxxxxxxx
            // Y. Xxxxxxxxx Xxxxxxxx xxx xxxx xxxxxxxx xxx xx-xxxxxxx xxxxx xxx Xxxxxxxxx Xxxxxxxx Xxx xx xxxxxx.
            // Xxxxxxx XxxxxxXxxxxxxxXxx xxx xxxxxxx xxxxxxx xxx xxxxxxx xxxx xxxxxxx xx xxxxxxx xxx xxxxxxxx Xxxxxxxxx Xxxxxxxx Xxx xxx xxxx xxxxxxx.
            // Xx xxx xxxxx xxxxxx xx xxxx Xxxxxxxxx Xxxxxxxx xx xxxxxxxx xxxx xxx XxxxxxXxxxxxxxXxx xxxxxx xxxx xxxxxx xxxx xxxxx.
            xx (xxxxx XxxxxxXxxxxxxxXxxXxxxx(xxxxxxx.Xxxxxxxx))
            {
                // Xx xxx Xxxxxxxx Xxx xxx xxxxx xxxxxxxxxxxx xxxxxxx, Xxxxxxxxx Xxxxxxxx xxx xxxx xxxx xxxxx.
                // Xxx xxxx xxx Xxxxxxxx Xxx xxx xxxx xxxxx xxx xxx _xxxxxxx xxxxx xxxx xx.
                xxxxxx xxxxx XxxXxxxxxxxXxxxxxxxxxxxxxXxxxxxxXxxxx(xxxxxxx);
            }
        }

        // Xxx&#YY;x xxx Xxxxxxxx xxxxx xxx, xxx xxxxx xxxxx
        xxxxxx xxxxx;
    }
    ```

-   Xxxxxx xxx XxxxXxXxxxxxxx xxxxxx xx Xxxxx.xxxx.xx xx xxxxxx xxx xxxxxxxx xxxxxxx. Xxxx xxxx xxx xxx xxx xxxxxx xx xxx XxxxxxxxxXxxxxxxxXxxxxx.xx. Xx xxxxxxxxxx xxx xxxxxxx xxxx xx xxxxxx xx xxx xxx xxxx xxxxxxxxx xx xxx xxxxxxx xxxxxx.

    ```xx
    xxxxxxx xxxxx xxxx XxxxXxXxxxxxxx()
    {
        xx (_xxXxxxxxxxXxxxxxx)
        {
            xx (xxxxx XxxxxxxxxXxxxxxxxXxxxxx.XxxXxxxxxxxXxxxxxxxxxxxxxXxxxxxxXxxxx(_xxxxxxx))
            {
                Xxxxx.Xxxxxxxx(xxxxxx(Xxxxxxx), _xxxxxxx);
            }
        }
        xxxx xx (XxxxxxxXxxxxx.XxxxxxxxXxxxxxxXxxxxxxxxxx(XxxxxxxxXxxxXxx.Xxxx))
        {
            //Xxxxxx xxx xxx x xxx xxxxx xxxxxxx
            _xxxxxxx = XxxxxxxXxxxxx.XxxXxxxxxx(XxxxxxxxXxxxXxx.Xxxx);
            Xxxxx.XxxxxXxxx("Xxxxxxxxxxxx xxxxxx xx xxxx xxxxxxxxxxx xxxxxxxxxxx xxx xxxxxxx xxxxx xxxxxxx xxxxxxxx!");

            xx (xxxxx XxxxxxxxxXxxxxxxxXxxxxx.XxxxxxXxxxxxxxXxxXxxxx(XxxxxxxxXxxxXxx.Xxxx))
            {
                Xxxxx.XxxxxXxxx("Xxxxxxxxxxxx xxxxxx xx xxxx Xxxxxxxxx Xxxxxxxx!");
                Xxxxx.Xxxxxxxx(xxxxxx(Xxxxxxx), _xxxxxxx);
            }
        }
        xxxx
        {
            XxxxxXxxxxxx.Xxxx = "Xxxxxxx Xxxxxxxxxxx";
        }
    }
    ```

-   Xxxxx xxx xxx xxx xxxxxxxxxxx. Xxxxx xxxx "xxxxxxXxxxxxxx". Xxxx xx xxxx XXX xxx xx xxxxxxxxxx xxx xxxx xx xxxxxxxxx xx xxx Xxxxxxx xxxxxx. Xxxxx xxxx xx xxxx xxxx. Xxx xxxxxx xxx xxx x xxxx xx xxx xxxx. Xx xxx xxxxx xx xxxx Xxxxxxxx xxxxxxx xxx xx xxxx xxxx xx xxxxxxx xxxxxx xx xx-xxxxx xxx xxxxxxxxx xxx.

    ![](images/passport-login-10.png)

## Xxxxxxxx Y: Xxxxxxxxxxx x xxx Xxxxxxxx xxxx


Xx xxxx xxxxxxxx xxx xxxx xx xxxxxxxx x xxx xxxx xxxx xxxx xxxxxx x xxx xxxxxxx xxxx Xxxxxxxx. Xxxx xxxx xxxx xxxxxxxxx xx xxx xxx Xxxxx xxxx xxxxx. Xxx Xxxxx xxxx xx xxxxxxxxxxx xxx xx xxxxxxxx xxxx xxxx xx xxxxxxxxx xx xxx Xxxxxxxx. X XxxxxxxxXxxxxxxx xxxx xxxx xxxxxx Xxxxxxxx xxxxxxxxxxxx xxx x xxx xxxx.

-   Xx xxx xxxxx xxxxxx xxxxxx x xxx xxxxx xxxx xxxxxx "XxxxxxxxXxxxxxxx.xxxx". Xx xxx XXXX xxx xx xxx xxxxxxxxx xx xxxxx xxx xxxx xxxxxxxxx. Xxx xxxxxxxxx xxxx xx xxxxxxx xx xxx Xxxxx xxxx.

    ```xaml
    <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
      <StackPanel Orientation="Vertical">
        <TextBlock x:Name="Title" Text="Register New Passport User" FontSize="24" Margin="4" TextAlignment="Center"/>

        <TextBlock x:Name="ErrorMessage" Text="" FontSize="20" Margin="4" Foreground="Red" TextAlignment="Center"/>

        <TextBlock Text="Enter your new username below" Margin="0,0,0,20"
                   TextWrapping="Wrap" Width="300"
                   TextAlignment="Center" VerticalAlignment="Center" FontSize="16"/>

        <TextBox x:Name="UsernameTextBox" Margin="4" Width="250"/>

        <Button x:Name="PassportRegisterButton" Content="Register" Background="DodgerBlue" Foreground="White"
            Click="RegisterButton_Click_Async" Width="80" HorizontalAlignment="Center" Margin="0,20"/>

        <Border x:Name="PassportStatus" Background="#22B14C"
                   Margin="4" Height="100">
          <TextBlock x:Name="PassportStatusText" Text="Microsoft Passport is ready to use!" FontSize="20"
                 Margin="4" TextAlignment="Center" VerticalAlignment="Center"/>
        </Border>
      </StackPanel>
    </Grid>
    ```

-   Xx xxx XxxxxxxxXxxxxxxx.xxxx.xx xxxx xxxxxx xxxx xxxxxxxxx x xxxxxxx Xxxxxxx xxxxxxxx xxx x xxxxx xxxxx xxx xxx xxxxxxxx Xxxxxx. Xxxx xxxx xxx x xxx xxxxx xxxxxxx xxx xxxxxx x Xxxxxxxx xxx.

    ```xx
    xxxxx XxxxxxxxXxxxx.Xxxxxx;
    xxxxx XxxxxxxxXxxxx.Xxxxx;

    xxxxxxxxx XxxxxxxxXxxxx.Xxxxx
    {
        xxxxxx xxxxxx xxxxxxx xxxxx XxxxxxxxXxxxxxxx : Xxxx
        {
            xxxxxxx Xxxxxxx _xxxxxxx;

            xxxxxx XxxxxxxxXxxxxxxx()
            {
                XxxxxxxxxxXxxxxxxxx();
            }

            xxxxxxx xxxxx xxxx XxxxxxxxXxxxxx_Xxxxx_Xxxxx(xxxxxx xxxxxx, XxxxxxXxxxxXxxx x)
            {
                XxxxxXxxxxxx.Xxxx = "";

                //Xx xxx xxxx xxxxx xxx xxxxx xxxxxxxx xxxxxxxx xxx xxxxxxx xxxxxxxxxxx xxx xxxxxxxxxxx xxxxxx 
                //xxxxxxxx x xxxx xx xxxxxxxx x xxx xxxxxxx. 
                //Xxx xxxx xxxxxx xxxxxx xx xxxx xxxx xxxx xxxx xxx xxxx xxxxxxxx xx xxxxxxx xx xxxxxxxx xx xxx xxxx.

                xx (!xxxxxx.XxXxxxXxXxxxx(XxxxxxxxXxxxXxx.Xxxx))
                {
                    //Xxxxxxxx x xxx xxxxxxx
                    _xxxxxxx = XxxxxxxXxxxxx.XxxXxxxxxx(XxxxxxxxXxxxXxx.Xxxx);
                    //Xxxxxxxx xxx xxxxxxx xxxx Xxxxxxxxx Xxxxxxxx
                    xxxxx XxxxxxxxxXxxxxxxxXxxxxx.XxxxxxXxxxxxxxXxxXxxxx(_xxxxxxx.Xxxxxxxx);
                    //Xxxxxxxx xx xxx Xxxxxxx Xxxxxx. 
                    Xxxxx.Xxxxxxxx(xxxxxx(Xxxxxxx), _xxxxxxx);
                }
                xxxx
                {
                    XxxxxXxxxxxx.Xxxx = "Xxxxxx xxxxx x xxxxxxxx";
                }
            }
        }
    }
    ```

-   Xxx xxxx xx xxxxxxxx xx xxxx xxxx xxxx xxx Xxxxx xxxx xxxx xxxxxxxx xx xxxxxxx.

    ```xx
    xxxxxxx xxxx XxxxxxxxXxxxxxXxxxXxxxx_XxXxxxxxxXxxxxxx(xxxxxx xxxxxx, XxxxxxxXxxxxxXxxxxXxxx x)
    {
        XxxxxXxxxxxx.Xxxx = "";
        Xxxxx.Xxxxxxxx(xxxxxx(XxxxxxxxXxxxxxxx));
    }
    ```

-   Xxxxx xxx xxx xxx xxxxxxxxxxx. Xxx xx xxxxxxxx x xxx xxxx. Xxxx xxxxxx xx xxx xxxx xxxx xxx xxxxxxxx xxxx xxx xxx xxxxxx xxxx xxxx xxx xxxxx.

    ![](images/passport-login-11.png)

Xx xxxx xxx xxx xxxx xxxxxxx xxx xxxxxxxxx xxxxxx xxx xxxx xx xxx xxx xxx Xxxxxxxxx Xxxxxxxx XXX xx xxxxxxxxxxxx xxxxxxxx xxxxx xxx xxxxxx xxxxxxxx xxx xxx xxxxx. Xxxx xxxx xxx xxxxxxxxx xxx xxx xxxxx xxxxxxxx xxx xxxx xxx xxxxx xx xxxxxxxx xxxxxxxxx xxx xxxx xxxxxxxxxxx, xxx xxxxxx xxxxxxxxx xxxx xxxx xxxxxxxxxxxx xxxxxx xxxxxxxxx xx xxxx xxxxxxxxxxxxxx. Xxxxxxx YY xxxx xxx Xxxxxxxx xxxxxxxxxx xx xxxxxxx xxx xxxxxxxxxx xxxxx xx Xxxxxxx Xxxxx. Xx xxx xxxx xxxx xxxxx x xxxxxxx xxxx xxxxxxxx Xxxxxxx Xxxxx xxx xxxx xxxx xxxx xxxx xxxx xxx xx xxxxxxxxx xxxxxxx xxxxxxxx Xxxxxxx Xxxxx.

Xxxxx xx xx xxxxx xxxx xxx xx x xxxxxxxxx xxxx xx xx xx xxxxx xx xxxxxxx Xxxxxxx Xxxxx xxxx xxx xxxx xxxxxxxxxxx xxxxxxx xxx Xxxxxxxxx Xxxxxxxx.

## Xxxxxxx xxxxxx

* [Microsoft Passport and Windows Hello](microsoft-passport.md)
* [Microsoft Passport login service](microsoft-passport-login-auth-service.md)


<!--HONumber=Mar16_HO1-->
