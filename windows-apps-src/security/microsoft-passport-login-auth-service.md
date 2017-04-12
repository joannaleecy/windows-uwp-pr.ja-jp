---
title: "Windows Hello ログイン サービスの作成"
description: "これは、Windows 10 UWP (ユニバーサル Windows プラットフォーム) アプリで従来のユーザー名とパスワードの認証システムの代わりに Windows Hello を使う方法に関する詳しいチュートリアルのパート 2 です。"
ms.assetid: ECC9EF3D-E0A1-4BC4-94FA-3215E6CFF0E4
author: awkoren
ms.author: alkoren
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: e33c7bd29fe8750d81ca1304c3854dc1c93d0929
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
# <a name="create-a-windows-hello-login-service"></a>Windows Hello ログイン サービスの作成


\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください。\]


\[一部の情報はリリース前の製品に関することであり、正式版がリリースされるまでに大幅に変更される可能性があります。 ここに記載された情報について、Microsoft は明示または黙示を問わずいかなる保証をするものでもありません。\]

これは、Windows 10 UWP (ユニバーサル Windows プラットフォーム) アプリで従来のユーザー名とパスワードの認証システムの代わりに Windows Hello を使う方法に関する詳しいチュートリアルのパート 2 です。 この記事では、パート 1「[Windows Hello ログイン アプリ](microsoft-passport-login.md)」で省略した機能を取り上げ、Windows Hello を既存のアプリケーションに統合する方法について説明します。

このプロジェクトを作成するには、C# と XAML の経験がいくらか必要です。 Windows 10 コンピューターで Visual Studio 2015 (Community Edition 以上) を使う必要もあります。

## <a name="exercise-1-server-side-logic"></a>演習 1: サーバー側のロジック


この演習では、最初のタブに組み込まれた Windows Hello アプリケーションを使って作業を開始し、ローカルのモック サーバーとモック データベースを作成します。 このハンズオン ラボの目的は、Windows Hello を既存のシステムに統合する方法を説明することです。 モック サーバーとモック データベースを使うと、関係のない多くの設定が省略されます。 実際のアプリケーションでは、モック オブジェクトを実際のサービスとデータベースに置き換える必要があります。

-   作業を始めるには、最初の Passport ハンズオン ラボから PassportLogin ソリューションを開きます。
-   まず、モック サーバーとモック データベースを実装します。 新しいフォルダーを "AuthService" という名前で作成します。 ソリューション エクスプローラーで、[PassportLogin (ユニバーサル Windows)] ソリューションを右クリックし、[追加]、[新しいフォルダー] の順に選びます。
-   モック データベースに保存するデータ モデルの役割を果たす UserAccount クラスと PassportDevices クラスを作成します。 UserAccount は、従来型の認証サーバーに実装されているユーザー モデルと同様です。 AuthService フォルダーを右クリックし、"UserAccount.cs" という新しいクラスを追加します。

    ![Windows Hello の認証作成用フォルダー](images/passport-auth-1.png)

    ![Windows Hello の認証作成用クラス](images/passport-auth-2.png)

-   クラス定義をパブリックに変更し、次のパブリック プロパティを追加します。 次の参照が必要です。

    ```cs
    using System.ComponentModel.DataAnnotations;
     
    namespace PassportLogin.AuthService
    {
        public class UserAccount
        {
            [Key, Required]
            public Guid UserId { get; set; }
            [Required]
            public string Username { get; set; }
            public string Password { get; set; }
            // public List<PassportDevice> PassportDevices = new List<PassportDevice>();
        }
    }
    ```

    PassportDevices のコメント アウトされた一覧があります。 現在の実装の既存のユーザー モデルにこの変更を加える必要があります。 PassportDevices の一覧には deviceID、Windows Hello から生成された公開キー、[**KeyCredentialAttestationResult**](https://msdn.microsoft.com/library/windows/apps/dn973034) が含められます。 このハンズオン ラボでは、keyAttestationResult を実装する必要があります。これらが、TPM (Trusted Platform Modules) チップを搭載するデバイスの Windows Hello によってのみ提供されるためです。 **KeyCredentialAttestationResult** は、複数のプロパティの組み合わせであるため、保存してデータベースに読み込むには分割する必要があります。

-   AuthService フォルダーに "PassportDevice.cs" という新しいクラスを作成します。 これは、上で説明した Windows Hello デバイスのモデルです。 クラス定義をパブリックに変更し、次のプロパティを追加します。

    ```cs
    namespace PassportLogin.AuthService
    {
        public class PassportDevice
        {
            // These are the new variables that will need to be added to the existing UserAccount in the Database
            // The DeviceName is used to support multiple devices for the one user.
            // This way the correct public key is easier to find as a new public key is made for each device.
            // The KeyAttestationResult is only used if the User device has a TPM (Trusted Platform Module) chip, 
            // in most cases it will not. So will be left out for this hands on lab.
            public Guid DeviceId { get; set; }
            public byte[] PublicKey { get; set; }
            // public KeyCredentialAttestationResult KeyAttestationResult { get; set; }
        }
    }
    ```

-   UserAccount.cs に戻り、Windows Hello デバイスの一覧のコメントを解除します。

    ```cs
    using System.Collections.Generic;
     
    namespace PassportLogin.AuthService
    {
        public class UserAccount
        {
            [Key, Required]
            public Guid UserId { get; set; }
            [Required]
            public string Username { get; set; }
            public string Password { get; set; }
            public List<PassportDevice> PassportDevices = new List<PassportDevice>();
        }
    }
    ```

-   UserAccount と PassportDevice のモデルが作成されたら、モック データベースとして機能する AuthService で別の新しいクラスを作成する必要があります。 これはモック データベースであるため、ユーザー アカウントの一覧の保存と読み込みはローカルで行います。 実際にはデータベース実装になります。 AuthService で "MockStore.cs" という新しいクラスを作成します。 クラス定義をパブリックに変更します。
-   モック ストアではユーザー アカウントの一覧の保存と読み込みがローカルで行われるため、XmlSerializer を使ってその一覧の保存と読み込みを行うためのロジックを実装できます。 ファイル名と保存場所も記憶する必要があります。 MockStore.cs で、次の内容を実装します。

```cs
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;
    using Windows.Storage;

    namespace PassportLogin.AuthService
    {
        public class MockStore
        {
            private const string USER_ACCOUNT_LIST_FILE_NAME = "userAccountsList.txt";
            // This cannot be a const because the LocalFolder is accessed at runtime
            private string _userAccountListPath = Path.Combine(
                ApplicationData.Current.LocalFolder.Path, USER_ACCOUNT_LIST_FILE_NAME);
            private List<UserAccount> _mockDatabaseUserAccountsList;
     
    #region Save and Load Helpers
            /// <summary>
            /// Create and save a useraccount list file. (Replacing the old one)
            /// </summary>
            private async void SaveAccountListAsync()
            {
                string accountsXml = SerializeAccountListToXml();
     
                if (File.Exists(_userAccountListPath))
                {
                    StorageFile accountsFile = await StorageFile.GetFileFromPathAsync(_userAccountListPath);
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
            private async void LoadAccountListAsync()
            {
                if (File.Exists(_userAccountListPath))
                {
                    StorageFile accountsFile = await StorageFile.GetFileFromPathAsync(_userAccountListPath);
     
                    string accountsXml = await FileIO.ReadTextAsync(accountsFile);
                    DeserializeXmlToAccountList(accountsXml);
                }
     
                // If the UserAccountList does not contain the sampleUser Initialize the sample users
                // This is only needed as it in a Hand on Lab to demonstrate a user migrating
                // In the real world user accounts would just be in a database
                if (!_mockDatabaseUserAccountsList.Any(f => f.Username.Equals("sampleUsername")))
                {
                    //If the list is empty InitializeSampleAccounts and return the list
                    //InitializeSampleUserAccounts();
                }
            }
     
            /// <summary>
            /// Uses the local list of accounts and returns an XML formatted string representing the list
            /// </summary>
            /// <returns>XML formatted list of accounts</returns>
            private string SerializeAccountListToXml()
            {
                XmlSerializer xmlizer = new XmlSerializer(typeof(List<UserAccount>));
                StringWriter writer = new StringWriter();
                xmlizer.Serialize(writer, _mockDatabaseUserAccountsList);
                return writer.ToString();
            }
     
            /// <summary>
            /// Takes an XML formatted string representing a list of accounts and returns a list object of accounts
            /// </summary>
            /// <param name="listAsXml">XML formatted list of accounts</param>
            /// <returns>List object of accounts</returns>
            private List<UserAccount> DeserializeXmlToAccountList(string listAsXml)
            {
                XmlSerializer xmlizer = new XmlSerializer(typeof(List<UserAccount>));
                TextReader textreader = new StreamReader(new MemoryStream(Encoding.UTF8.GetBytes(listAsXml)));
                return _mockDatabaseUserAccountsList = (xmlizer.Deserialize(textreader)) as List<UserAccount>;
            }
    #endregion
        }
    }
```

-   load メソッドでは、InitializeSampleUserAccounts メソッドがコメント アウトされている点に注目してください。 このメソッドは、MockStore.cs で作成する必要があります。 このメソッドによりユーザー アカウントの一覧が入力され、ログインできるようになります。 実際には、ユーザー データベースには情報が既に入力されています。 この手順では、ユーザーの一覧を初期化し、load を呼び出すコンストラクターも作成します。

    ```cs
    namespace PassportLogin.AuthService
    {
        public class MockStore
        {
            private const string USER_ACCOUNT_LIST_FILE_NAME = "userAccountsList.txt";
            // This cannot be a const because the LocalFolder is accessed at runtime
            private string _userAccountListPath = Path.Combine(
                ApplicationData.Current.LocalFolder.Path, USER_ACCOUNT_LIST_FILE_NAME);
            private List<UserAccount> _mockDatabaseUserAccountsList;
     
            public MockStore()
            {
                _mockDatabaseUserAccountsList = new List& lt; UserAccount & gt; ();
                LoadAccountListAsync();
            }

            private void InitializeSampleUserAccounts()
            {
                // Create a sample Traditional User Account that only has a Username and Password
                // This will be used initially to demonstrate how to migrate to use Windows Hello

                UserAccount sampleUserAccount = new UserAccount()
                {
                    UserId = Guid.NewGuid(),
                    Username = "sampleUsername",
                    Password = "samplePassword",
                };

                // Add the sampleUserAccount to the _mockDatabase
                _mockDatabaseUserAccountsList.Add(sampleUserAccount);
                SaveAccountListAsync();
            }
        }
    }
    ```

-   これで InitalizeSampleUserAccounts メソッドが作成されたため、LoadAccountListAsync メソッドでのメソッド呼び出しをコメント解除します。

    ```cs
    private async void LoadAccountListAsync()
    {
        if (File.Exists(_userAccountListPath))
        {
            StorageFile accountsFile = await StorageFile.GetFileFromPathAsync(_userAccountListPath);

            string accountsXml = await FileIO.ReadTextAsync(accountsFile);
            DeserializeXmlToAccountList(accountsXml);
        }

        // If the UserAccountList does not contain the sampleUser Initialize the sample users
        // This is only needed as it in a Hand on Lab to demonstrate a user migrating
        // In the real world user accounts would just be in a database
        if (!_mockDatabaseUserAccountsList.Any(f = > f.Username.Equals("sampleUsername")))
                {
            //If the list is empty InitializeSampleAccounts and return the list
            InitializeSampleUserAccounts();
        }
    }
    ```

-   モック ストア内のユーザー アカウントの一覧を保存し、読み込むことができるようになります。 アプリケーションの他の部分はこの一覧にアクセスできる必要があるため、このデータを取得するためにいくつかのメソッドが必要になります。 InitializeSampleUserAccounts メソッドの下に、次の get メソッドを追加します。 これらのメソッドにより、userid、単一のユーザー、特定の Windows Hello デバイスのユーザー一覧を取得することができ、特定のデバイスのユーザーの公開キーを取得することもできます。

    ```cs
    public Guid GetUserId(string username)
    {
        if (_mockDatabaseUserAccountsList.Any())
        {
            UserAccount account = _mockDatabaseUserAccountsList.FirstOrDefault(f => f.Username.Equals(username));
            if (account != null)
            {
                return account.UserId;
            }
        }
        return Guid.Empty;
    }

    public UserAccount GetUserAccount(Guid userId)
    {
        return _mockDatabaseUserAccountsList.FirstOrDefault(f => f.UserId.Equals(userId));
    }

    public List<UserAccount> GetUserAccountsForDevice(Guid deviceId)
    {
        List<UserAccount> usersForDevice = new List<UserAccount>();

        foreach (UserAccount account in _mockDatabaseUserAccountsList)
        {
            if (account.PassportDevices.Any(f => f.DeviceId.Equals(deviceId)))
            {
                usersForDevice.Add(account);
            }
        }

        return usersForDevice;
    }

    public byte[] GetPublicKey(Guid userId, Guid deviceId)
    {
        UserAccount account = _mockDatabaseUserAccountsList.FirstOrDefault(f => f.UserId.Equals(userId));
        if (account != null)
        {
            if (account.PassportDevices.Any())
            {
                return account.PassportDevices.FirstOrDefault(p => p.DeviceId.Equals(deviceId)).PublicKey;
            }
        }
        return null;
    }
    ```

-   次に実装するメソッドは、アカウントの追加、アカウントの削除、およびデバイスの削除を行う簡単な操作を処理します。 Windows Hello はデバイスに固有のため、デバイスの削除が必要です。 ログインするデバイスごとに、Windows Hello によって新しい公開キーと秘密キーのペアが作成されます。 サインインするデバイスごとに異なるパスワードを使うようなものです。ただし、パスワードはすべてサーバーに保存されるため記憶する必要はありません。 MockStore.cs に次のメソッドを追加します。

    ```cs
    public UserAccount AddAccount(string username)
    {
        UserAccount newAccount = null;
        try
        {
            newAccount = new UserAccount()
            {
                UserId = Guid.NewGuid(),
                Username = username,
            };

            _mockDatabaseUserAccountsList.Add(newAccount);
            SaveAccountListAsync();
        }
        catch (Exception)
        {
            throw;
        }
        return newAccount;
    }

    public bool RemoveAccount(Guid userId)
    {
        UserAccount userAccount = GetUserAccount(userId);
        if (userAccount != null)
        {
            _mockDatabaseUserAccountsList.Remove(userAccount);
            SaveAccountListAsync();
            return true;
        }
        return false;
    }

    public bool RemoveDevice(Guid userId, Guid deviceId)
    {
        UserAccount userAccount = GetUserAccount(userId);
        PassportDevice deviceToRemove = null;
        if (userAccount != null)
        {
            foreach (PassportDevice device in userAccount.PassportDevices)
            {
                if (device.DeviceId.Equals(deviceId))
                {
                    deviceToRemove = device;
                    break;
                }
            }
        }

        if (deviceToRemove != null)
        {
            //Remove the PassportDevice
            userAccount.PassportDevices.Remove(deviceToRemove);
            SaveAccountListAsync();
        }

        return true;
    }
    ```

-   MockStore クラスで、Windows Hello 関連の情報を既存の UserAccount に追加するメソッドを追加します。 このメソッドは、PassportUpdateDetails と呼ばれ、ユーザーと Windows Hello の詳細を識別するためのパラメーターを使います。 PassportDevice を作成するときに KeyAttestationResult はコメント アウトされていましたが、実際のアプリケーションではこれが必要になります。

   ```cs
   using Windows.Security.Credentials;

    public void PassportUpdateDetails(Guid userId, Guid deviceId, byte[] publicKey, 
        KeyCredentialAttestationResult keyAttestationResult)
    {
        UserAccount existingUserAccount = GetUserAccount(userId);
        if (existingUserAccount != null)
        {
            if (!existingUserAccount.PassportDevices.Any(f => f.DeviceId.Equals(deviceId)))
            {
                existingUserAccount.PassportDevices.Add(new PassportDevice()
                {
                    DeviceId = deviceId,
                    PublicKey = publicKey,
                    // KeyAttestationResult = keyAttestationResult,
                });
            }
        }
        SaveAccountListAsync();
    }
    ```

-   MockStore クラスはこれで完成です。これはデータベースを表すため、プライベートと見なされます。 MockStore にアクセスするには、データベース データを操作するために AuthService クラスが必要です。 AuthService フォルダーに "AuthService.cs" という新しいクラスを作成します。 クラス定義をパブリックに変更し、シングルトン インスタンス パターンを追加して、これまでインスタンスが 1 つしか作成されていないことを確認します。

    ```cs
    namespace PassportLogin.AuthService
    {
        public class AuthService
        {
            // Singleton instance of the AuthService
            // The AuthService is a mock of what a real world server and service implementation would be
            private static AuthService _instance;
            public static AuthService Instance
            {
                get
                {
                    if (null == _instance)
                    {
                        _instance = new AuthService();
                    }
                    return _instance;
                }
            }

            private AuthService()
            { }
        }
    }
    ```

-   AuthService クラスは、MockStore クラスのインスタンスを作成し、MockStore オブジェクトのプロパティへのアクセスを提供する必要があります。

    ```cs
    namespace PassportLogin.AuthService
    {
        public class AuthService
        {
            //Singleton instance of the AuthService
            //The AuthService is a mock of what a real world server and database implementation would be
            private static AuthService _instance;
            public static AuthService Instance
            {
                get
                {
                    if (null == _instance)
                    {
                        _instance = new AuthService();
                    }
                    return _instance;
                }
            }
     
            private MockStore _mockStore = new MockStore();
     
            public Guid GetUserId(string username)
            {
                return _mockStore.GetUserId(username);
            }
     
            public UserAccount GetUserAccount(Guid userId)
            {
                return _mockStore.GetUserAccount(userId);
            }
     
            public List<UserAccount> GetUserAccountsForDevice(Guid deviceId)
            {
                return _mockStore.GetUserAccountsForDevice(deviceId);
            }
        }
    }
    ```

-   MockStore オブジェクトの Passport 詳細の追加、削除、更新メソッドにアクセスするには、AuthService クラスにメソッドが必要です。 AuthService クラス ファイルの末尾に、次のメソッドを追加します。

    ```cs
    using Windows.Security.Credentials;

    public void Register(string username)
    {
        _mockStore.AddAccount(username);
    }

    public bool PassportRemoveUser(Guid userId)
    {
        return _mockStore.RemoveAccount(userId);
    }

    public bool PassportRemoveDevice(Guid userId, Guid deviceId)
    {
        return _mockStore.RemoveDevice(userId, deviceId);
    }

    public void PassportUpdateDetails(Guid userId, Guid deviceId, byte[] publicKey, 
        KeyCredentialAttestationResult keyAttestationResult)
    {
        _mockStore.PassportUpdateDetails(userId, deviceId, publicKey, keyAttestationResult);
    }
    ```

-   AuthService クラスは、資格情報を検証するメソッドを提供する必要があります。 このメソッドは、ユーザー名とパスワードを取得し、そのアカウントが存在していてパスワードが有効であることを確認します。 既存のシステムには、ユーザーに権限があることを確認する、これと同等のメソッドが用意されています。 次の ValidateCredentials を AuthService.cs ファイルに追加します。

    ```cs
    public bool ValidateCredentials(string username, string password)
    {
        if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
        {
            // This would be used for existing accounts migrating to use Passport
            Guid userId = GetUserId(username);
            if (userId != Guid.Empty)
            {
                UserAccount account = GetUserAccount(userId);
                if (account != null)
                {
                    if (string.Equals(password, account.Password))
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }
    ```

-   AuthService クラスには、クライアントにチャレンジを返してそのユーザーが要求元のユーザーであることを検証する要求チャレンジ メソッドが必要です。 その場合、クライアントから返された署名済みチャレンジを受信するメソッドが AuthService クラスに必要です。 このハンズオン ラボでは、署名済みチャレンジが完了したかどうかを判断する方法のメソッドが不完全なままになっています。 既存の認証システムに実装されている Windows Hello は、実装ごとに少しずつ異なります。 サーバーに保存されている公開キーは、クライアントがサーバーに返す結果と一致している必要があります。 AuthService.cs にこれらの 2 つのメソッドを追加します。

    ```cs
    using Windows.Security.Cryptography;
    using Windows.Storage.Streams;

    public IBuffer PassportRequestChallenge()
    {
        return CryptographicBuffer.ConvertStringToBinary("ServerChallenge", BinaryStringEncoding.Utf8);
    }

    public bool SendServerSignedChallenge(Guid userId, Guid deviceId, byte[] signedChallenge)
    {
        // Depending on your company polices and procedures this step will be different
        // It is at this point you will need to validate the signedChallenge that is sent back from the client.
        // Validation is used to ensure the correct user is trying to access this account. 
        // The validation process will use the signedChallenge and the stored PublicKey 
        // for the username and the specific device signin is called from.
        // Based on the validation result you will return a bool value to allow access to continue or to block the account.

        // For this sample validation will not happen as a best practice solution does not apply and will need to 
           // be configured for each company.
        // Simply just return true.

        // You could get the User's Public Key with something similar to the following:
        byte[] userPublicKey = _mockStore.GetPublicKey(userId, deviceId);
        return true;
    }
    ```

## <a name="exercise-2-client-side-logic"></a>演習 2: クライアント側のロジック


この演習では、最初のラボのクライアント側ビューとヘルパー クラスを変更して、AuthService クラスを使います。 実際には、AuthService が認証サーバーとなり、Web API を使ってサーバーとの間でデータを送受信する必要があります。 このハンズオン ラボでは、わかりやすいようにクライアントとサーバーはすべてローカルになっています。 目的は、Windows Hello API を使う方法を学習することです。

-   MainPage.xaml.cs では、アカウント一覧を読み込む MockStore のインスタンスが AuthService クラスによって作成されたときに loaded メソッドで AccountHelper.LoadAccountListAsync メソッド呼び出しを削除できます。 loaded メソッドは、次のようになります。 非同期メソッド定義を待機しているものはないため削除される点に注意してください。

    ```cs
    private void MainPage_Loaded(object sender, RoutedEventArgs e)
    {
        Frame.Navigate(typeof(UserSelection));
    }
    ```

-   Login ページのインターフェイスを更新して、パスワードの入力を要求します。 このハンズオン ラボでは、既存のシステムを移行して Windows Hello を使う方法を示します。既存のアカウントには、ユーザー名とパスワードが設定されます。 また、XAML の下部にある説明を更新して既定のパスワードを追加します。 Login.xaml で次の XAML を更新します。

    ```xml
    <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
      <StackPanel Orientation="Vertical">
        <TextBlock Text="Login" FontSize="36" Margin="4" TextAlignment="Center"/>

        <TextBlock x:Name="ErrorMessage" Text="" FontSize="20" Margin="4" Foreground="Red" TextAlignment="Center"/>

        <TextBlock Text="Enter your credentials below" Margin="0,0,0,20"
                   TextWrapping="Wrap" Width="300"
                   TextAlignment="Center" VerticalAlignment="Center" FontSize="16"/>

        <StackPanel Orientation="Horizontal" HorizontalAlignment="Center">
          <!-- Username Input -->
          <TextBlock x:Name="UserNameTextBlock" Text="Username: "
                 FontSize="20" Margin="4" Width="100"/>
          <TextBox x:Name="UsernameTextBox" PlaceholderText="sampleUsername" Width="200" Margin="4"/>
        </StackPanel>

        <StackPanel Orientation="Horizontal" HorizontalAlignment="Center">
          <!-- Password Input -->
          <TextBlock x:Name="PasswordTextBlock" Text="Password: "
                 FontSize="20" Margin="4" Width="100"/>
          <PasswordBox x:Name="PasswordBox" PlaceholderText="samplePassword" Width="200" Margin="4"/>
        </StackPanel>

        <Button x:Name="PassportSignInButton" Content="Login" Background="DodgerBlue" Foreground="White"
            Click="PassportSignInButton_Click" Width="80" HorizontalAlignment="Center" Margin="0,20"/>

        <TextBlock Text="Don't have an account?"
                    TextAlignment="Center" VerticalAlignment="Center" FontSize="16"/>
        <TextBlock x:Name="RegisterButtonTextBlock" Text="Register now"
                   PointerPressed="RegisterButtonTextBlock_OnPointerPressed"
                   Foreground="DodgerBlue"
                   TextAlignment="Center" VerticalAlignment="Center" FontSize="16"/>

        <Border x:Name="PassportStatus" Background="#22B14C"
                   Margin="0,20" Height="100">
          <TextBlock x:Name="PassportStatusText" Text="Windows Hello is ready to use!"
                 Margin="4" TextAlignment="Center" VerticalAlignment="Center" FontSize="20"/>
        </Border>

        <TextBlock x:Name="LoginExplaination" FontSize="24" TextAlignment="Center" TextWrapping="Wrap" 
            Text="Please Note: To demonstrate a login, validation will only occur using the default username 
            'sampleUsername' and default password 'samplePassword'"/>

      </StackPanel>
    </Grid>
    ```

-   Login クラスの分離コードで、クラスの先頭にある Account プライベート変数を変更して UserAccount にする必要があります。 OnNavigateTo イベントを変更して型が UserAccount になるようにキャストします。 次の参照が必要です。

    ```cs
    using PassportLogin.AuthService;

    namespace PassportLogin.Views
    {
        public sealed partial class Login : Page
        {
            private UserAccount _account;
            private bool _isExistingAccount;

            public Login()
            {
                this.InitializeComponent();
            }

            protected override async void OnNavigatedTo(NavigationEventArgs e)
            {
                //Check Windows Hello is setup and available on this machine
                if (await MicrosoftPassportHelper.MicrosoftPassportAvailableCheckAsync())
                {
                    if (e.Parameter != null)
                    {
                        _isExistingAccount = true;
                        //Set the account to the existing account being passed in
                        _account = (UserAccount)e.Parameter;
                        UsernameTextBox.Text = _account.Username;
                        SignInPassport();
                    }
                }
            }
        }
    }
    ```

-   Login ページは以前の Account オブジェクトの代わりに UserAccount オブジェクトを使うため、UserAccount がいくつかのメソッドのパラメーターとして使われるように MicrosoftPassportHelper.cs を更新する必要があります。 CreatePassportKeyAsync、RemovePassportAccountAsync、GetPassportAuthenticationMessageAsync の各メソッドの次のパラメーターを変更する必要があります。 UserAccount クラスには、UserId の Guid があるため、多くの場所でより具体的になるように Id を使い始めることになります。

    ```cs
    public static async Task<bool> CreatePassportKeyAsync(Guid userId, string username)
    {
        KeyCredentialRetrievalResult keyCreationResult = await KeyCredentialManager.RequestCreateAsync(username, KeyCredentialCreationOption.ReplaceExisting);
    }

    public static async void RemovePassportAccountAsync(UserAccount account)
    {

    }
    public static async Task<bool> GetPassportAuthenticationMessageAsync(UserAccount account)
    {
        KeyCredentialRetrievalResult openKeyResult = await KeyCredentialManager.OpenAsync(account.Username);
        //Calling OpenAsync will allow the user access to what is available in the app and will not require user credentials again.
        //If you wanted to force the user to sign in again you can use the following:
        //var consentResult = await Windows.Security.Credentials.UI.UserConsentVerifier.RequestVerificationAsync(account.Username);
        //This will ask for the either the password of the currently signed in Microsoft Account or the PIN used for Windows Hello.

        if (openKeyResult.Status == KeyCredentialStatus.Success)
        {
            //If OpenAsync has succeeded, the next thing to think about is whether the client application requires access to backend services.
            //If it does here you would Request a challenge from the Server. The client would sign this challenge and the server
            //would check the signed challenge. If it is correct it would allow the user access to the backend.
            //You would likely make a new method called RequestSignAsync to handle all this
            //e.g. RequestSignAsync(openKeyResult);
            //Refer to the second Windows Hello sample for information on how to do this.

            //For this sample there is not concept of a server implemented so just return true.
            return true;
        }
        else if (openKeyResult.Status == KeyCredentialStatus.NotFound)
        {
            //If the _account is not found at this stage. It could be one of two errors. 
            //1. Windows Hello has been disabled
            //2. Windows Hello has been disabled and re-enabled cause the Windows Hello Key to change.
            //Calling CreatePassportKey and passing through the account will attempt to replace the existing Windows Hello Key for that account.
            //If the error really is that Windows Hello is disabled then the CreatePassportKey method will output that error.
            if (await CreatePassportKeyAsync(account.UserId, account.Username))
            {
                //If the Passport Key was again successfully created, Windows Hello has just been reset.
                //Now that the Passport Key has been reset for the _account retry sign in.
                return await GetPassportAuthenticationMessageAsync(account);
            }
        }

        // Can't use Passport right now, try again later
        return false;
    }
    ```

-   AccountHelper の代わりに AuthService が使われるように、Login.xaml.cs ファイルの SignInPassport メソッドを更新する必要があります。 資格情報の検証は、AuthService を通じて行われます。 このハンズオン ラボでは、構成済みのアカウントは "sampleUsername" のみです。 このアカウントは、MockStore.cs の InitializeSampleUserAccounts メソッドで作成されます。 ここで、Login.xaml.cs で SignInPassport メソッドを更新し、以下のコード スニペットを反映します。

    ```cs
    private async void SignInPassportAsync()
    {
        if (_isExistingLocalAccount)
        {
            if (await MicrosoftPassportHelper.GetPassportAuthenticationMessageAsync(_account))
            {
                Frame.Navigate(typeof(Welcome), _account);
            }
        }
        else if (AuthService.AuthService.Instance.ValidateCredentials(UsernameTextBox.Text, PasswordBox.Password))
        {
            Guid userId = AuthService.AuthService.Instance.GetUserId(UsernameTextBox.Text);

            if (userId != Guid.Empty)
            {
                //Now that the account exists on server try and create the necessary passport details and add them to the account
                bool isSuccessful = await MicrosoftPassportHelper.CreatePassportKeyAsync(userId, UsernameTextBox.Text);
                if (isSuccessful)
                {
                    Debug.WriteLine("Successfully signed in with Windows Hello!");
                    //Navigate to the Welcome Screen. 
                    _account = AuthService.AuthService.Instance.GetUserAccount(userId);
                    Frame.Navigate(typeof(Welcome), _account);
                }
                else
                {
                    //The passport account creation failed.
                    //Remove the account from the server as passport details were not configured
                    AuthService.AuthService.Instance.PassportRemoveUser(userId);

                    ErrorMessage.Text = "Account Creation Failed";
                }
            }
        }
        else
        {
            ErrorMessage.Text = "Invalid Credentials";
        }
    }
    ```

-   Windows Hello では、各デバイスのアカウントごとに異なる公開キーおよび秘密キーのペアが作成されるため、ウェルカム ページにはログインしたアカウントの登録済みデバイスの一覧を表示して、各デバイスの記録を消去できるようにする必要があります。 Welcome.xaml で、ForgetButton の下に次の XAML を追加します。 これにより、デバイスの記録を消去するボタン、エラー テキスト領域、すべてのデバイスが表示される一覧が実装されます。

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

        <Button x:Name="ForgetDeviceButton" Content="Forget Device" Click="Button_Forget_Device_Click"
               Foreground="White"
               Background="Gray"
               Margin="0,40,0,20"
               HorizontalAlignment="Center"/>

        <TextBlock x:Name="ForgetDeviceErrorTextBlock" Text="Select a device first"
                  TextWrapping="Wrap" Width="300" Foreground="Red"
                  TextAlignment="Center" VerticalAlignment="Center" FontSize="16" Visibility="Collapsed"/>

        <ListView x:Name="UserListView" MaxHeight="500" MinWidth="350" Width="350" HorizontalAlignment="Center">
          <ListView.ItemTemplate>
            <DataTemplate>
              <Grid Background="Gray" Height="50" Width="350" HorizontalAlignment="Center" VerticalAlignment="Stretch" >
                <TextBlock Text="{Binding DeviceId}" HorizontalAlignment="Center" TextAlignment="Center" VerticalAlignment="Center"
                          Foreground="White"/>
              </Grid>
            </DataTemplate>
          </ListView.ItemTemplate>
        </ListView>
      </StackPanel>
    </Grid>
    ```

-   Welcome.xaml.cs ファイルで、クラスの先頭にあるプライベート変数 Account をプライベート変数 UserAccount となるように変更する必要があります。 次に、AuthService を使うように OnNavigatedTo メソッドを更新し、現在のアカウントの情報を取得します。 アカウント情報がある場合、デバイスを表示する一覧の itemsource を設定することができます。 AuthService 名前空間への参照を追加する必要があります。

   ```cs
   using PassportLogin.AuthService;

    namespace PassportLogin.Views
    {
        public sealed partial class Welcome : Page
        {
            private UserAccount _activeAccount;

            public Welcome()
            {
                InitializeComponent();
            }

            protected override void OnNavigatedTo(NavigationEventArgs e)
            {
                _activeAccount = (UserAccount)e.Parameter;
                if (_activeAccount != null)
                {
                    UserAccount account = AuthService.AuthService.Instance.GetUserAccount(_activeAccount.UserId);
                    if (account != null)
                    {
                        UserListView.ItemsSource = account.PassportDevices;
                        UserNameText.Text = account.Username;
                    }
                }
            }
        }
    }
    ```

-   アカウントの削除に AuthService を使うとき、Button\_Forget\_User\_Click メソッド内の AccountHelper への参照は削除できます。 この結果、メソッドは次のようになります。

    ```cs
    private void Button_Forget_User_Click(object sender, RoutedEventArgs e)
    {
        //Remove it from Windows Hello
        MicrosoftPassportHelper.RemovePassportAccountAsync(_activeAccount);

        Debug.WriteLine("User " + _activeAccount.Username + " deleted.");

        //Navigate back to UserSelection page.
        Frame.Navigate(typeof(UserSelection));
    }
    ```

-   MicrosoftPassportHelper メソッドは、アカウントの削除に AuthService を使いません。 AuthService への呼び出しを行って userId を渡す必要があります。

    ```cs
    public static async void RemovePassportAccountAsync(UserAccount account)
    {
        //Open the account with Windows Hello
        KeyCredentialRetrievalResult keyOpenResult = await KeyCredentialManager.OpenAsync(account.Username);

        if (keyOpenResult.Status == KeyCredentialStatus.Success)
        {
            // In the real world you would send key information to server to unregister
            AuthService.AuthService.Instance.PassportRemoveUser(account.UserId);
        }

        //Then delete the account from the machines list of Passport Accounts
        await KeyCredentialManager.DeleteAsync(account.Username);
    }
    ```

-   ウェルカム ページ クラスの実装を終了するには、デバイスの削除を可能にするメソッドを MicrosoftPassportHelper.cs で作成する必要があります。 AuthService で PassportRemoveDevice を呼び出す新しいメソッドを作成します。

   ```cs
   public static void RemovePassportDevice(UserAccount account, Guid deviceId)
    {
        AuthService.AuthService.Instance.PassportRemoveDevice(account.UserId, deviceId);
    }
    ```

-   Welcome.xaml.cs では、Forget Device クリック イベントを実装します。 このイベントは、デバイスの一覧から選択されたデバイスを使い、Passport ヘルパーを使ってデバイスの削除を呼び出します。

    ```cs
    private void Button_Forget_Device_Click(object sender, RoutedEventArgs e)
    {
        PassportDevice selectedDevice = UserListView.SelectedItem as PassportDevice;
        if (selectedDevice != null)
        {
            //Remove it from Windows Hello
            MicrosoftPassportHelper.RemovePassportDevice(_activeAccount, selectedDevice.DeviceId);

            Debug.WriteLine("User " + _activeAccount.Username + " deleted.");

            if (!UserListView.Items.Any())
            {
                //Navigate back to UserSelection page.
                Frame.Navigate(typeof(UserSelection));
            }
        }
        else
        {
            ForgetDeviceErrorTextBlock.Visibility = Visibility.Visible;
        }
    }
    ```

-   更新する次のページは、UserSelection ページです。 UserSelection ページは、現在のデバイスのすべてのユーザー アカウントを取得するために AuthService を使う必要があります。 現在のところ、デバイス ID を取得して AuthService に渡す方法はないため、そのデバイスのユーザー アカウントを返すことができます。 Utils フォルダーで、"Helpers.cs" という新しいクラスを作成します。 クラス定義をパブリック静的に変更し、現在のデバイス ID の取得を可能にする次のメソッドを追加します。

    ```cs
    using Windows.Security.ExchangeActiveSyncProvisioning;

    namespace PassportLogin.Utils
    {
        public static class Helpers
        {
            public static Guid GetDeviceId()
            {
                //Get the Device ID to pass to the server
                EasClientDeviceInformation deviceInformation = new EasClientDeviceInformation();
                return deviceInformation.Id;
            }
        }
    }
    ```

-   UserSelection ページ クラスでは、ユーザー インターフェイスではなく分離コードのみを変更する必要があります。 UserSelection.xaml.cs では、loaded メソッドとユーザー選択メソッドを更新して、Account クラスの代わりに UserAccount クラスを使うようにします。 AuthService を通じてこのデバイスのすべてのユーザーを取得する必要もあります。

    ```cs
    using System.Linq;
    using PassportLogin.AuthService;

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
                List<UserAccount> accounts = AuthService.AuthService.Instance.GetUserAccountsForDevice(Helpers.GetDeviceId());

                if (accounts.Any())
                {
                    UserListView.ItemsSource = accounts;
                    UserListView.SelectionChanged += UserSelectionChanged;
                }
                else
                {
                    //If there are no accounts navigate to the LoginPage
                    Frame.Navigate(typeof(Login));
                }
            }

            /// <summary>
            /// Function called when an account is selected in the list of accounts
            /// Navigates to the Login page and passes the chosen account
            /// </summary>
            private void UserSelectionChanged(object sender, RoutedEventArgs e)
            {
                if (((ListView)sender).SelectedValue != null)
                {
                    UserAccount account = (UserAccount)((ListView)sender).SelectedValue;
                    if (account != null)
                    {
                        Debug.WriteLine("Account " + account.Username + " selected!");
                    }
                    Frame.Navigate(typeof(Login), account);
                }
            }
        }
    }
    ```

-   PassportRegister ページは、分離コードを更新する必要があります。ユーザー インターフェイスを変更する必要はありません。 PassportRegister.xaml.cs では、クラスの先頭にあるプライベート変数 Account が不要になったため削除します。 RegisterButton クリック イベントを更新して AuthService を使うようにします。 このメソッドは、新しい UserAccount を作成し、Passport の詳細を試して更新します。 Passport が Passport キーの作成に失敗した場合、登録プロセスが失敗するためアカウントは削除されます。

    ```cs
    private async void RegisterButton_Click_Async(object sender, RoutedEventArgs e)
    {
        ErrorMessage.Text = "";

        //Validate entered credentials are acceptable
        if (!string.IsNullOrEmpty(UsernameTextBox.Text))
        {
            //Register an Account on the AuthService so that we can get back a userId
            AuthService.AuthService.Instance.Register(UsernameTextBox.Text);
            Guid userId = AuthService.AuthService.Instance.GetUserId(UsernameTextBox.Text);

            if (userId != Guid.Empty)
            {
                //Now that the account exists on server try and create the necessary passport details and add them to the account
                bool isSuccessful = await MicrosoftPassportHelper.CreatePassportKeyAsync(userId, UsernameTextBox.Text);
                if (isSuccessful)
                {
                    //Navigate to the Welcome Screen. 
                    Frame.Navigate(typeof(Welcome), AuthService.AuthService.Instance.GetUserAccount(userId));
                }
                else
                {
                    //The passport account creation failed.
                    //Remove the account from the server as passport details were not configured
                    AuthService.AuthService.Instance.PassportRemoveUser(userId);

                    ErrorMessage.Text = "Account Creation Failed";
                }
            }
        }
        else
        {
            ErrorMessage.Text = "Please enter a username";
        }
    }
    ```

-   アプリをビルドして実行します (F5)。 資格情報 "sampleUsername" および "samplePassword" を使って、サンプル ユーザー アカウントにサインインします。 ようこそ画面には、デバイスを消去するボタンが表示されてもデバイスがないことがあります。 ユーザーを作成するときや Windows Hello を使うようにユーザーを移行するとき、Passport 情報は AuthService にプッシュされません。

    ![Windows Hello のログイン画面](images/passport-auth-3.png)

    ![Windows Hello のログインの成功](images/passport-auth-4.png)

-   Passport 情報を AuthService に送るには、MicrosoftPassportHelper.cs を更新する必要があります。 CreatePassportKeyAsync メソッドでは、成功した場合に true を返すだけではなく、KeyAttestation の取得を試みる新しいメソッドを呼び出す必要があります。 このハンズオン ラボではこの情報が AuthService に記録されないため、この情報をクライアント側で取得する方法を説明します。 CreatePassportKeyAsync メソッドを更新します。

    ```cs
    public static async Task<bool> CreatePassportKeyAsync(Guid userId, string username)
    {
        KeyCredentialRetrievalResult keyCreationResult = await KeyCredentialManager.RequestCreateAsync(username, KeyCredentialCreationOption.ReplaceExisting);

        switch (keyCreationResult.Status)
        {
            case KeyCredentialStatus.Success:
                Debug.WriteLine("Successfully made key");
                await GetKeyAttestationAsync(userId, keyCreationResult);
                return true;
            case KeyCredentialStatus.UserCanceled:
                Debug.WriteLine("User cancelled sign-in process.");
                break;
            case KeyCredentialStatus.NotFound:
                // User needs to setup Windows Hello
                Debug.WriteLine("Windows Hello is not setup!\nPlease go to Windows Settings and set up a PIN to use it.");
                break;
            default:
                break;
        }

        return false;
    }
    ```

-   MicrosoftPassportHelper.cs でこの GetKeyAttestationAsync メソッドを作成します。 このメソッドは、特定のデバイス上のアカウントごとに Windows Hello により提供可能な必要なすべての情報を取得する方法を示します。

    ```cs
    using Windows.Storage.Streams;

    private static async Task GetKeyAttestationAsync(Guid userId, KeyCredentialRetrievalResult keyCreationResult)
    {
        KeyCredential userKey = keyCreationResult.Credential;
        IBuffer publicKey = userKey.RetrievePublicKey();
        KeyCredentialAttestationResult keyAttestationResult = await userKey.GetAttestationAsync();
        IBuffer keyAttestation = null;
        IBuffer certificateChain = null;
        bool keyAttestationIncluded = false;
        bool keyAttestationCanBeRetrievedLater = false;
        KeyCredentialAttestationStatus keyAttestationRetryType = 0;

        if (keyAttestationResult.Status == KeyCredentialAttestationStatus.Success)
        {
            keyAttestationIncluded = true;
            keyAttestation = keyAttestationResult.AttestationBuffer;
            certificateChain = keyAttestationResult.CertificateChainBuffer;
            Debug.WriteLine("Successfully made key and attestation");
        }
        else if (keyAttestationResult.Status == KeyCredentialAttestationStatus.TemporaryFailure)
        {
            keyAttestationRetryType = KeyCredentialAttestationStatus.TemporaryFailure;
            keyAttestationCanBeRetrievedLater = true;
            Debug.WriteLine("Successfully made key but not attestation");
        }
        else if (keyAttestationResult.Status == KeyCredentialAttestationStatus.NotSupported)
        {
            keyAttestationRetryType = KeyCredentialAttestationStatus.NotSupported;
            keyAttestationCanBeRetrievedLater = false;
            Debug.WriteLine("Key created, but key attestation not supported");
        }

        Guid deviceId = Helpers.GetDeviceId();
        //Update the Pasport details with the information we have just gotten above.
        //UpdatePassportDetails(userId, deviceId, publicKey.ToArray(), keyAttestationResult);
    }
    ```

-   先ほど追加した GetKeyAttestationAsync メソッドでは、最後の行がコメント アウトされています。 新しいメソッドとして作成するのはこの最後の行であり、すべての Windows Hello 情報を AuthService に送信します。 実際の環境では、Web API を使って実際のサーバーにこれを送信する必要があります。

    ```cs
    using System.Runtime.InteropServices.WindowsRuntime;

    public static bool UpdatePassportDetails(Guid userId, Guid deviceId, byte[] publicKey, KeyCredentialAttestationResult keyAttestationResult)
    {
        //In the real world you would use an API to add Passport signing info to server for the signed in _account.
        //For this tutorial we do not implement a WebAPI for our server and simply mock the server locally 
        //The CreatePassportKey method handles adding the Windows Hello account locally to the device using the KeyCredential Manager

        //Using the userId the existing account should be found and updated.
        AuthService.AuthService.Instance.PassportUpdateDetails(userId, deviceId, publicKey, keyAttestationResult);
        return true;
    }
    ```

-   Windows Hello 情報が AuthService に送信されるように、GetKeyAttestationAsync メソッドの最後の行のコメントを解除します。
-   アプリケーションをビルドして実行し、既定の資格情報を使ってサインインします。 ようこそ画面に、デバイス ID が表示されるのがわかります。 別のデバイスでサインインした場合、それもここに表示されます (クラウド ホスト型認証サービスを使っていた場合)。 このハンズオン ラボでは、実際のデバイス ID が表示されます。 実際の実装では、ユーザーが理解して各デバイスの特定に使うことができるフレンドリ名を表示できます。

    ![Windows Hello でのログインに成功したデバイス ID](images/passport-auth-5.png)

-   21. このハンズオン ラボを完了するには、ユーザー選択ページから選んでもう一度サインインするときにユーザーの要求とチャレンジが必要です。 AuthService には、チャレンジを要求するために作成した 2 つのメソッドと、署名済みのチャレンジを使う 1 つのメソッドがあります。 MicrosoftPassportHelper.cs で、"RequestSignAsync" という新しいメソッドを作成します。このメソッドは、AuthService にチャレンジを要求し、Passport API を使ってそのチャレンジにローカルに署名して、署名済みのチャレンジを AuthService に送信します。 このハンズオン ラボでは、AuthService が署名済みのチャレンジを受け取って true を返します。 実際の実装では、チャレンジが適切なデバイスの適切なユーザーによって署名されたことを判断する検証メカニズムを実装する必要があります。 次のメソッドを MicrosoftPassportHelper.cs に追加します。

    ```cs
    private static async Task<bool> RequestSignAsync(Guid userId, KeyCredentialRetrievalResult openKeyResult)
    {
        // Calling userKey.RequestSignAsync() prompts the uses to enter the PIN or use Biometrics (Windows Hello).
        // The app would use the private key from the user account to sign the sign-in request (challenge)
        // The client would then send it back to the server and await the servers response.
        IBuffer challengeMessage = AuthService.AuthService.Instance.PassportRequestChallenge();
        KeyCredential userKey = openKeyResult.Credential;
        KeyCredentialOperationResult signResult = await userKey.RequestSignAsync(challengeMessage);

        if (signResult.Status == KeyCredentialStatus.Success)
        {
            // If the challenge from the server is signed successfully
            // send the signed challenge back to the server and await the servers response
            return AuthService.AuthService.Instance.SendServerSignedChallenge(
                userId, Helpers.GetDeviceId(), signResult.Result.ToArray());
        }
        else if (signResult.Status == KeyCredentialStatus.UserCanceled)
        {
            // User cancelled the Windows Hello PIN entry.
        }
        else if (signResult.Status == KeyCredentialStatus.NotFound)
        {
            // Must recreate Windows Hello key
        }
        else if (signResult.Status == KeyCredentialStatus.SecurityDeviceLocked)
        {
            // Can't use Windows Hello right now, remember that hardware failed and suggest restart
        }
        else if (signResult.Status == KeyCredentialStatus.UnknownError)
        {
            // Can't use Windows Hello right now, try again later
        }

        return false;
    }
    ```

-   22. MicrosoftPassportHelper クラスで、GetPassportAuthenticationMessageAsync メソッドから RequestSignAsync メソッドを呼び出します。

    ```cs
    public static async Task<bool> GetPassportAuthenticationMessageAsync(UserAccount account)
    {
        KeyCredentialRetrievalResult openKeyResult = await KeyCredentialManager.OpenAsync(account.Username);
        // Calling OpenAsync will allow the user access to what is available in the app and will not require user credentials again.
        // If you wanted to force the user to sign in again you can use the following:
        // var consentResult = await Windows.Security.Credentials.UI.UserConsentVerifier.RequestVerificationAsync(account.Username);
        // This will ask for the either the password of the currently signed in Microsoft Account or the PIN used for Windows Hello.

        if (openKeyResult.Status == KeyCredentialStatus.Success)
        {
            //If OpenAsync has succeeded, the next thing to think about is whether the client application requires access to backend services.
            //If it does here you would Request a challenge from the Server. The client would sign this challenge and the server
            //would check the signed challenge. If it is correct it would allow the user access to the backend.
            //You would likely make a new method called RequestSignAsync to handle all this
            //e.g. RequestSignAsync(openKeyResult);
            //Refer to the second Windows Hello sample for information on how to do this.

            return await RequestSignAsync(account.UserId, openKeyResult);
        }
        else if (openKeyResult.Status == KeyCredentialStatus.NotFound)
        {
            //If the _account is not found at this stage. It could be one of two errors. 
            //1. Windows Hello has been disabled
            //2. Windows Hello has been disabled and re-enabled cause the Windows Hello Key to change.
            //Calling CreatePassportKey and passing through the account will attempt to replace the existing Windows Hello Key for that account.
            //If the error really is that Windows Hello is disabled then the CreatePassportKey method will output that error.
            if (await CreatePassportKeyAsync(account.UserId, account.Username))
            {
                //If the Passport Key was again successfully created, Windows Hello has just been reset.
                //Now that the Passport Key has been reset for the _account retry sign in.
                return await GetPassportAuthenticationMessageAsync(account);
            }
        }

        // Can't use Windows Hello right now, try again later
        return false;
    }
    ```

-   この演習を通じて、クライアント側のアプリケーションを更新して AuthService を使うようにしました。 こうすることで、Account クラスと AccountHelper クラスを省略することができました。 Utils フォルダーで Account クラス、Models フォルダー、AccountHelper クラスを削除します。 ソリューションを正常にビルドするには、アプリケーション全体で Models 名前空間への参照をすべて削除する必要があります。
-   アプリケーションをビルドして実行し、モック サービスとモック データベースで Windows Hello を使ってみます。

このハンズオン ラボでは、Windows 10 コンピューターから認証を使う場合に、Windows Hello API を使ってパスワードの入力を不要にする方法を習得しました。 パスワードの管理と既存のシステムで失われたパスワードのサポートにユーザーが費やす労力を考えると、Windows Hello のこの新しい認証システムに移行するメリットがわかります。

練習用として、サービスとサーバー側で認証を実装する方法の詳細を記載しておきました。 ほとんどの場合、Windows Hello を使い始めるために移行が必要な既存のシステムがあり、各システムの詳細は異なっていることが予想されます。

## <a name="related-topics"></a>関連トピック

* [Windows Hello](microsoft-passport.md)
* [Windows Hello ログイン アプリ](microsoft-passport-login.md)