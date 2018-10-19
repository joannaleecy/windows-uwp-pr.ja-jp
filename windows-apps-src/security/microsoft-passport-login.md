---
title: Windows Hello ログイン アプリの作成
description: これは、従来のユーザー名とパスワードの認証システムの代わりに Windows Hello を使う Windows 10 UWP (ユニバーサル Windows プラットフォーム) アプリを作成する方法に関する詳しいチュートリアルのパート 1 です。
ms.assetid: A9E11694-A7F5-4E27-95EC-889307E0C0EF
author: PatrickFarley
ms.author: pafarley
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, セキュリティ
ms.localizationpriority: medium
ms.openlocfilehash: 106ea458502a95c53ecbf02d9118f3c31ff43978
ms.sourcegitcommit: 310a4555fedd4246188a98b31f6c094abb33ec60
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/19/2018
ms.locfileid: "5133764"
---
# <a name="create-a-windows-hello-login-app"></a>Windows Hello ログイン アプリの作成

これは、従来のユーザー名とパスワードの認証システムの代わりに Windows Hello を使う Windows 10 UWP (ユニバーサル Windows プラットフォーム) アプリを作成する方法に関する詳しいチュートリアルのパート 1 です。 アプリでは、サインインにユーザー名を使い、アカウントごとに Hello キーを作成します。 これらのアカウントは、Windows Hello の構成時に Windows の設定でセットアップされた暗証番号 (PIN) によって保護されます。

このチュートリアルは、アプリの作成とバックエンド サービスの接続の 2 つの部分に分かれています。 この記事を終了したら、パート 2「[Windows Hello ログイン サービス](microsoft-passport-login-auth-service.md)」に進んでください。

開始する前に、「[Windows Hello](microsoft-passport.md)」の概要を読んで、Windows Hello の全般的なしくみを理解してください。

## <a name="get-started"></a>開始


このプロジェクトを作成するには、C# と XAML の経験がいくらか必要です。 Visual Studio 2015 を使用する必要もあります (Community Edition 以上)、Windows 10 コンピューターで、Visual Studio の以降のリリース。 Visual Studio 2015 には、必要な最小バージョンが、最新の開発者とセキュリティ更新プログラムの最新バージョンの Visual Studio を使用することをお勧めします。

-   Visual Studio を開き、ファイルを選択 > 新規 > プロジェクトです。
-   [新しいプロジェクト] ウィンドウが開きます。 [テンプレート]、[Visual C#] の順に移動します。
-   [空白のアプリ (ユニバーサル Windows)] を選び、アプリケーションに "PassportLogin" という名前を付けます。
-   新しいアプリケーションをビルドして実行すると (F5)、画面に空白のウィンドウが表示されます。 アプリケーションを閉じます。

![Windows Hello の新しいプロジェクト](images/passport-login-1.png)

## <a name="exercise-1-login-with-microsoft-passport"></a>演習 1: Microsoft Passport でログインする


この演習では、コンピューターで Windows Hello がセットアップされているかどうかを確認する方法と、Windows Hello を使ってアカウントにサインインする方法について説明します。

-   新しいプロジェクトで、"Views" という新しいフォルダーをソリューションに作成します。 このフォルダーには、このサンプルで移動先となるページが置かれます。 ソリューション エクスプローラーでプロジェクトを右クリックし、[追加]、[新しいフォルダー] の順に選んでフォルダー名を Views に変更します。

    ![Windows Hello のフォルダーの追加](images/passport-login-2.png)

-   新しい Views フォルダーを右クリックし、[追加]、[新しい項目] の順に選び、[空白のページ] を選びます。 このページに "Login.xaml" という名前を付けます。

    ![Windows Hello の空白ページの追加](images/passport-login-3.png)

-   新しいログイン ページのユーザー インターフェイスを定義するには、次の XAML を追加します。 この XAML では、次の子を配置するために StackPanel が定義されます。

    -   タイトルが格納される TextBlock
    -   エラー メッセージ用の TextBlock
    -   ユーザー名を入力する TextBox
    -   登録ページに移動する Button
    -   Windows Hello の状態が格納される TextBlock
    -   バックエンド ユーザーまたは構成済みユーザーがない場合に Login ページについて説明する TextBlock

    ```xml
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
        <TextBlock Text="Don't have an account?"
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
            Text="Please Note: To demonstrate a login, validation will only occur using the default username 'sampleUsername'"/>
      </StackPanel>
    </Grid>
    ```

-   ソリューションをビルドするには、分離コードにいくつかのメソッドを追加する必要があります。 F7 キーを押すか、ソリューション エクスプローラーを使って Login.xaml.cs に移動します。 Login イベントと Register イベントを処理する次の 2 つのイベント メソッドを追加します。 この時点では、これらのメソッドは ErrorMessage.Text を空の文字列に設定します。

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

-   Login ページをレンダリングするため、MainPage コードを編集し、MainPage が読み込まれたときに Login ページに移動するようにします。 MainPage.xaml.cs ファイルを開きます。 ソリューション エクスプローラーで、MainPage.xaml.cs をダブルクリックします。 見つからない場合、MainPage.xaml の横にある小さい矢印をクリックして分離コードを表示します。 ログイン ページに移動する読み込みイベント ハンドラー メソッドを作成します。 Views 名前空間への参照を追加する必要があります。

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

-   Login ページでは、OnNavigatedTo イベントを処理して Windows Hello がこのコンピューターで利用できることを検証する必要があります。 Login.xaml.cs で、次の内容を実装します。 MicrosoftPassportHelper オブジェクトがエラーを示します。 これは、まだ実装していないためです。

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

-   MicrosoftPassportHelper クラスを作成するには、PassportLogin (ユニバーサル Windows) ソリューションを右クリックし、[追加]、[新しいフォルダー] の順にクリックします。 このフォルダーに Utils という名前を付けます。

    ![Passport のヘルパー クラスの作成](images/passport-login-5.png)

-   Utils フォルダーを右クリックし、[追加]、[クラス] の順にクリックします。 このクラスに "MicrosoftPassportHelper.cs" という名前を付けます。
-   MicrosoftPassportHelper のクラス定義をパブリック静的に変更した後、Windows Hello を使う準備ができたかどうかをユーザーに知らせる次のメソッドを追加します。 必要な名前空間を追加する必要があります。

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

-   Login.xaml.cs で、Utils 名前空間への参照を追加します。 これにより、OnNavigatedTo メソッドのエラーが解決されます。

    ```cs
    using PassportLogin.Utils;
    ```

-   アプリをビルドして実行します (F5)。 ログイン ページに自動的に移動し、Hello を使う準備ができているかどうかを示す Windows Hello バナーが表示されます。 コンピューターでの Windows Hello の状態を示す緑色または青色のバナーが表示されます。

    ![Windows Hello のログイン画面の準備](images/passport-login-6.png)

    ![Windows Hello のログイン画面 (セットアップされていない場合)](images/passport-login-7.png)

-   次に、サインインのロジックを作成する必要があります。 新しいフォルダーを "Models" という名前で作成します。
-   Models フォルダーで、"Account.cs" という新しいクラスを作成します。 このクラスは、アカウント モデルとして機能します。 これはサンプルのため、ユーザー名のみが含められます。 クラス定義をパブリックに変更し、Username プロパティを追加します。
    
    ```cs
    namespace PassportLogin.Models
    {
        public class Account
        {
            public string Username { get; set; }
        }
    }
    ```

-   アカウントを処理する方法が必要です。 このハンズオン ラボでは、サーバー (つまり、データベース) がないため、ユーザーの一覧の保存と読み込みはローカルで行われます。 Utils フォルダーを右クリックし、"AccountHelper.cs" という新しいクラスを追加します。 クラス定義をパブリック静的に変更します。 AccountHelper は、アカウントの一覧をローカルで保存して読み込むために必要なすべてのメソッドが追加される静的クラスです。 保存と読み込みは、XmlSerializer を使って機能します。 保存したファイルとその保存場所を覚えておく必要もあります。 追加の名前空間を参照する必要があります。
    
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

-   次に、アカウントのローカルの一覧からアカウントを追加および削除する方法を実装します。 これらの操作それぞれにより、一覧が保存されます。 このハンズオン ラボで必要となる最後のメソッドは、検証メソッドです。 ユーザーの認証サーバーまたはデータベースがないため、ハード コーディングされている単一のユーザーをこのメソッドが検証します。 これらのメソッドは、AccountHelper クラスに追加する必要があります。
    
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
            }
    ```

-   次に、ユーザーからのサインイン要求を処理する必要があります。 Login.xaml.cs で、現在のアカウント ログインを保持する新しいプライベート変数を作成します。 次に、新しいメソッド呼び出し SignInPassport を追加します。 これにより、AccountHelper.ValidateAccountCredentials メソッドを使ってアカウントの資格情報が検証されます。 入力されたユーザー名が、前の手順で設定したハード コーディングされた文字列値と同じ場合、こメソッドはブール値を返します。 このサンプルのハードコーディングされた値は、"sampleUsername" です。

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

-   MicrosoftPassportHelper のメソッドを参照しているコメント化されたコードがありました。 MicrosoftPassportHelper.cs で、CreatePassportKeyAsync という新しいメソッドを追加します。 このメソッドは、[**KeyCredentialManager**](https://msdn.microsoft.com/library/windows/apps/dn973043) で Windows Hello API を使います。 [**RequestCreateAsync**](https://msdn.microsoft.com/library/windows/apps/dn973048) を呼び出すと、*accountId* とローカル コンピューターに固有の Passport キーが作成されます。 実際のシナリオでこれを実装する場合は、switch ステートメント内のコメントに注目してください。

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

-   これで、CreatePassportKeyAsync メソッドが作成されました。Login.xaml.cs ファイルに戻り、SignInPassport メソッド内のコードのコメントを解除します。

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

-   アプリをビルドして実行します。 自動的に Login ページに移動します。 "sampleUsername" と入力し、[Login] をクリックします。 PIN の入力を求める Windows Hello プロンプトが表示されます。 PIN を正しく入力すると、CreatePassportKeyAsync メソッドが Windows Hello キーを作成できるようになります。 出力ウィンドウで、成功を示すメッセージが表示されるかどうかを確認してください。

    ![Windows Hello のログイン PIN の入力画面](images/passport-login-8.png)

## <a name="exercise-2-welcome-and-user-selection-pages"></a>演習 2: ウェルカム ページとユーザーの選択ページ


この演習は、前の演習の続きです。 ユーザーが正常にログインすると、ウェルカム ページに移動し、サインアウトしたり、アカウントを削除したりすることができます。 Windows Hello ではコンピューターごとにキーが作成されるため、そのコンピューターにサインインしたすべてのユーザーが表示されるユーザーの選択画面を作成できます。 その後、ユーザーはいずれかのアカウントを選び、パスワードを再入力しなくてもようこそ画面に直接移動することができます。コンピューターにアクセスするときに既に認証されているためです。

-   Views フォルダーで、"Welcome.xaml" という新しい空白のページを追加します。 次の XAML を追加して、ユーザー インターフェイスを完成させます。 これには、タイトル、ログインしているユーザー名、および 2 つのボタンが表示されます。 ボタンのうち 1 つはユーザーの一覧 (後で作成します) に戻るボタンで、もう 1 つのボタンはこのユーザーの消去を処理するボタンです。

    ```xml
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

-   Welcome.xaml.cs 分離コード ファイルで、ログオンしているアカウントを保持する新しいプライベート変数を追加します。 OnNavigateTo イベントをオーバーライドするメソッドを実装する必要があります、このメソッドには、ウェルカム ページに渡されたアカウントが格納されます。 また、XAML で定義された 2 つのボタンのクリック イベントも実装する必要があります。 Models フォルダーと Utils フォルダーへの参照が必要になります。

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

-   ユーザーの消去クリック イベントにコメント アウトされた行があることに注目してください。 アカウントは、ローカルの一覧から削除されますが、現在のところ Windows Hello から削除する方法はありません。 Windows Hello ユーザーの削除を処理する新しいメソッドを MicrosoftPassportHelper.cs に実装する必要があります。 このメソッドは、他の Windows Hello API を使ってアカウントを開いたり削除したりします。 実際の環境では、アカウントを削除するとサーバーやデータベースに通知されるため、ユーザー データベースは有効なままです。 Models フォルダーへの参照が必要になります。

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

-   Welcome.xaml.cs に戻り、RemovePassportAccountAsync を呼び出す行のコメントを解除します。

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

-   SignInPassport メソッド (Login.xaml.cs の) で、CreatePassportKeyAsync が成功すると、ようこそ画面に移動し、Account が渡されます。

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

-   アプリをビルドして実行します。 "sampleUsername" を使ってログインし、[Login] をクリックします。 PIN を入力し、成功した場合は、自動的にようこそ画面に移動します。 ユーザーの消去ボタンをクリックし、出力ウィンドウでユーザーが削除されたかどうかを確認してください。 ユーザーが削除されても、ウェルカム ページから移動しない点に注意してください。 アプリが移動できるユーザーの選択ページを作成する必要があります。

    ![Windows Hello のようこそ画面](images/passport-login-9.png)

-   Views フォルダーで、"UserSelection.xaml" という新しい空白ページを作成し、次の XAML を追加してユーザー インターフェイスを定義します。 このページには、ローカル アカウントの一覧にすべてのユーザーを表示する [**ListView**](https://msdn.microsoft.com/library/windows/apps/br242878) と、ログイン ページに移動してユーザーが別のアカウントを追加できるようにする Button が含められます。

    ```xml
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
    </Grid>
    ```

-   UserSelection.xaml.cs で、ローカルの一覧にアカウントが存在しない場合にログイン ページに移動する loaded メソッドを実装します。 ListView の SelectionChanged イベントと Button のクリック イベントも実装します。

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

-   アプリには、UserSelection ページへの移動が必要ないくつかの場所があります。 MainPage.xaml.cs では、Login ページではなく UserSelection ページに移動する必要があります。 MainPage で読み込みイベントが発生したときは、アカウントが存在することを UserSelection ページが確認できるようにアカウントの一覧を読み込む必要があります。 これには、loaded メソッドが非同期になるように変更するだけでなく、Utils フォルダーへの参照を追加することも必要です。

    ```cs
    using PassportLogin.Utils;

    private async void MainPage_Loaded(object sender, RoutedEventArgs e)
    {
        // Load the local Accounts List before navigating to the UserSelection page
        await AccountHelper.LoadAccountListAsync();
        Frame.Navigate(typeof(UserSelection));
    }
    ```

-   次に、ウェルカム ページから UserSelection ページに移動します。 どちらのクリック イベントでも、UserSelection ページに戻る必要があります。

    ```cs
    private void Button_Restart_Click(object sender, RoutedEventArgs e)
    {
        Frame.Navigate(typeof(UserSelection));
    }

    private void Button_Forget_User_Click(object sender, RoutedEventArgs e)
    {
        // Remove it from Microsoft Passport
        MicrosoftPassportHelper.RemovePassportAccountAsync(_activeAccount);

        // Remove it from the local accounts list and resave the updated list
        AccountHelper.RemoveAccount(_activeAccount);

        Debug.WriteLine("User " + _activeAccount.Username + " deleted.");

        // Navigate back to UserSelection page.
        Frame.Navigate(typeof(UserSelection));
    }
    ```

-   Login ページでは、UserSelection ページの一覧から選択されたアカウントにログインするためのコードが必要です。 OnNavigatedTo イベントには、ナビゲーションに渡されるアカウントを格納します。 まず、アカウントが既存のアカウントかどうかを識別する新しいプライベート変数を追加します。 次に、OnNavigatedTo イベントを処理します。

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

-   選択されたアカウントにサインインするには、SignInPassport メソッドを更新する必要があります。 MicrosoftPassportHelper には、Passport でアカウントを開くための別のメソッドが必要になります。アカウントには、既に Passport キーが作成されているためです。 MicrosoftPassportHelper.cs に新しいメソッドを実装し、Passport を使って既存のユーザーにサインインします。 コードの各部分については、コードのコメントをお読みください。

    ```cs
    /// <summary>
    /// Attempts to sign a message using the Passport key on the system for the accountId passed.
    /// </summary>
    /// <returns>Boolean representing if creating the Passport authentication message succeeded</returns>
    public static async Task<bool> GetPassportAuthenticationMessageAsync(Account account)
    {
        KeyCredentialRetrievalResult openKeyResult = await KeyCredentialManager.OpenAsync(account.Username);
        // Calling OpenAsync will allow the user access to what is available in the app and will not require user credentials again.
        // If you wanted to force the user to sign in again you can use the following:
        // var consentResult = await Windows.Security.Credentials.UI.UserConsentVerifier.RequestVerificationAsync(account.Username);
        // This will ask for the either the password of the currently signed in Microsoft Account or the PIN used for Microsoft Passport.

        if (openKeyResult.Status == KeyCredentialStatus.Success)
        {
            // If OpenAsync has succeeded, the next thing to think about is whether the client application requires access to backend services.
            // If it does here you would Request a challenge from the Server. The client would sign this challenge and the server
            // would check the signed challenge. If it is correct it would allow the user access to the backend.
            // You would likely make a new method called RequestSignAsync to handle all this
            // e.g. RequestSignAsync(openKeyResult);
            // Refer to the second Microsoft Passport sample for information on how to do this.

            // For this sample there is not concept of a server implemented so just return true.
            return true;
        }
        else if (openKeyResult.Status == KeyCredentialStatus.NotFound)
        {
            // If the _account is not found at this stage. It could be one of two errors. 
            // 1. Microsoft Passport has been disabled
            // 2. Microsoft Passport has been disabled and re-enabled cause the Microsoft Passport Key to change.
            // Calling CreatePassportKey and passing through the account will attempt to replace the existing Microsoft Passport Key for that account.
            // If the error really is that Microsoft Passport is disabled then the CreatePassportKey method will output that error.
            if (await CreatePassportKeyAsync(account.Username))
            {
                // If the Passport Key was again successfully created, Microsoft Passport has just been reset.
                // Now that the Passport Key has been reset for the _account retry sign in.
                return await GetPassportAuthenticationMessageAsync(account);
            }
        }

        // Can't use Passport right now, try again later
        return false;
    }
    ```

-   既存のアカウントを処理するには、Login.xaml.cs の SignInPassport メソッドを更新します。 この処理には、MicrosoftPassportHelper.cs の新しいメソッドが使われます。 成功した場合、アカウントにサインインされ、自動的にようこそ画面に移動します。

    ```cs
    private async void SignInPassport()
    {
        if (_isExistingAccount)
        {
            if (await MicrosoftPassportHelper.GetPassportAuthenticationMessageAsync(_account))
            {
                Frame.Navigate(typeof(Welcome), _account);
            }
        }
        else if (AccountHelper.ValidateAccountCredentials(UsernameTextBox.Text))
        {
            //Create and add a new local account
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

-   アプリをビルドして実行します。 "sampleUsername" を使ってログインします。 PIN を入力します。成功した場合は、自動的にようこそ画面に移動します。 ユーザーの一覧に戻るボタンをクリックします。 一覧にユーザーが表示されます。 この Passport をクリックすると、パスワードなどを再入力しなくても再度サインインできるようになります。

    ![Windows Hello のユーザー選択用の一覧](images/passport-login-10.png)

## <a name="exercise-3-registering-a-new-windows-hello-user"></a>演習 3: 新しい Windows Hello ユーザーを登録する


この演習では、Windows Hello を使って新しいアカウントを作成する新しいページを作成します。 このページは、Login ページの動作と似ています。 Login ページは、Windows Hello の使用に移行する既存のユーザーのために実装されます。 PassportRegister ページでは、新しいユーザーの Windows Hello の登録が作成されます。

-   Views フォルダーで、"PassportRegister.xaml" という新しい空白のページを作成します。 XAML で、次の内容を追加してユーザー インターフェイスをセットアップします。 このインターフェイスは、Login ページに似ています。

    ```xml
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

-   PassportRegister.xaml.cs 分離コード ファイルで、プライベート変数 Account と登録ボタンのクリック イベントを実装します。 これにより、新しいローカル アカウントが追加され、Passport キーが作成されます。

    ```cs
    using PassportLogin.Models;
    using PassportLogin.Utils;

    namespace PassportLogin.Views
    {
        public sealed partial class PassportRegister : Page
        {
            private Account _account;

            public PassportRegister()
            {
                InitializeComponent();
            }

            private async void RegisterButton_Click_Async(object sender, RoutedEventArgs e)
            {
                ErrorMessage.Text = "";

                //In the real world you would normally validate the entered credentials and information before 
                //allowing a user to register a new account. 
                //For this sample though we will skip that step and just register an account if username is not null.

                if (!string.IsNullOrEmpty(UsernameTextBox.Text))
                {
                    //Register a new account
                    _account = AccountHelper.AddAccount(UsernameTextBox.Text);
                    //Register new account with Microsoft Passport
                    await MicrosoftPassportHelper.CreatePassportKeyAsync(_account.Username);
                    //Navigate to the Welcome Screen. 
                    Frame.Navigate(typeof(Welcome), _account);
                }
                else
                {
                    ErrorMessage.Text = "Please enter a username";
                }
            }
        }
    }
    ```

-   登録ボタンがクリックされたら、Login ページからこのページに移動する必要があります。

    ```cs
    private void RegisterButtonTextBlock_OnPointerPressed(object sender, PointerRoutedEventArgs e)
    {
        ErrorMessage.Text = "";
        Frame.Navigate(typeof(PassportRegister));
    }
    ```

-   アプリをビルドして実行します。 新しいユーザーを登録してみます。 その後、ユーザーの一覧に戻り、そのユーザーを選んでログインできることを検証します。

    ![Windows Hello の新しいユーザーの登録](images/passport-login-11.png)

このラボでは、新しい Windows Hello API を使って既存のユーザーを認証し、新しいユーザーのアカウントを作成するために必要となる基本的なスキルを習得しました。 この新しい知識があれば、ユーザーはアプリケーションのパスワードを記憶する必要がなくなりますが、引き続きアプリケーションをユーザー認証によって確実に保護することができます。 Windows 10 では、Windows Hello の新しい認証テクノロジを使って、その生体認証ログイン オプションがサポートされます。

## <a name="related-topics"></a>関連トピック

* [Windows Hello](microsoft-passport.md)
* [Windows Hello ログイン サービス](microsoft-passport-login-auth-service.md)
