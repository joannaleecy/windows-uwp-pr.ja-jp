---
title: Windows Hello ログイン サービスの作成
description: これは、Windows 10 UWP (ユニバーサル Windows プラットフォーム) アプリで従来のユーザー名とパスワードの認証システムの代わりに Windows Hello を使う方法に関する詳しいチュートリアルのパート 2 です。
ms.assetid: ECC9EF3D-E0A1-4BC4-94FA-3215E6CFF0E4
author: PatrickFarley
ms.author: pafarley
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, セキュリティ
ms.localizationpriority: medium
ms.openlocfilehash: 2c69edc018ae01beba50b93b7dd9f4125544a001
ms.sourcegitcommit: 1c6325aa572868b789fcdd2efc9203f67a83872a
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/17/2018
ms.locfileid: "4754024"
---
# <a name="create-a-windows-hello-login-service"></a><span data-ttu-id="b8b2f-104">Windows Hello ログイン サービスの作成</span><span class="sxs-lookup"><span data-stu-id="b8b2f-104">Create a Windows Hello login service</span></span>

<span data-ttu-id="b8b2f-105">これは、Windows 10 UWP (ユニバーサル Windows プラットフォーム) アプリで従来のユーザー名とパスワードの認証システムの代わりに Windows Hello を使う方法に関する詳しいチュートリアルのパート 2 です。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-105">This is Part 2 of a complete walkthrough on how to use Windows Hello as an alternative to traditional username and password authentication systems in Windows 10 UWP (Universal Windows platform) apps.</span></span> <span data-ttu-id="b8b2f-106">この記事では、パート 1「[Windows Hello ログイン アプリ](microsoft-passport-login.md)」で省略した機能を取り上げ、Windows Hello を既存のアプリケーションに統合する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-106">This article picks up where Part 1, [Windows Hello login app](microsoft-passport-login.md), left off and extends the functionality to demonstrate how you can integrate Windows Hello into your existing application.</span></span>

<span data-ttu-id="b8b2f-107">このプロジェクトを作成するには、C# と XAML の経験がいくらか必要です。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-107">In order to build this project, you'll need some experience with C#, and XAML.</span></span> <span data-ttu-id="b8b2f-108">Windows 10 コンピューターで Visual Studio 2015 (Community Edition 以上) を使う必要もあります。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-108">You'll also need to be using Visual Studio 2015 (Community Edition or greater) on a Windows 10 machine.</span></span>

## <a name="exercise-1-server-side-logic"></a><span data-ttu-id="b8b2f-109">演習 1: サーバー側のロジック</span><span class="sxs-lookup"><span data-stu-id="b8b2f-109">Exercise 1: Server Side Logic</span></span>


<span data-ttu-id="b8b2f-110">この演習では、最初のタブに組み込まれた Windows Hello アプリケーションを使って作業を開始し、ローカルのモック サーバーとモック データベースを作成します。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-110">In this exercise you will be starting with the Windows Hello application built in the first lab and creating a local mock server and database.</span></span> <span data-ttu-id="b8b2f-111">このハンズオン ラボの目的は、Windows Hello を既存のシステムに統合する方法を説明することです。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-111">This hands on lab is designed to teach how Windows Hello could be integrated into an existing system.</span></span> <span data-ttu-id="b8b2f-112">モック サーバーとモック データベースを使うと、関係のない多くの設定が省略されます。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-112">By using a mock server and mock database a lot of unrelated setup is eliminated.</span></span> <span data-ttu-id="b8b2f-113">実際のアプリケーションでは、モック オブジェクトを実際のサービスとデータベースに置き換える必要があります。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-113">In your own applications you will need to replace the mock objects with the real services and databases.</span></span>

-   <span data-ttu-id="b8b2f-114">作業を始めるには、最初の Passport ハンズオン ラボから PassportLogin ソリューションを開きます。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-114">To begin, open up the PassportLogin solution from the first Passport Hands On Lab.</span></span>
-   <span data-ttu-id="b8b2f-115">まず、モック サーバーとモック データベースを実装します。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-115">You will start by implementing the mock server and mock database.</span></span> <span data-ttu-id="b8b2f-116">新しいフォルダーを "AuthService" という名前で作成します。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-116">Create a new folder called "AuthService".</span></span> <span data-ttu-id="b8b2f-117">ソリューション エクスプローラーで、[PassportLogin (ユニバーサル Windows)] ソリューションを右クリックし、[追加]、[新しいフォルダー] の順に選びます。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-117">In solution explorer right click on the solution "PassportLogin (Universal Windows)" and select Add > New Folder.</span></span>
-   <span data-ttu-id="b8b2f-118">モック データベースに保存するデータ モデルの役割を果たす UserAccount クラスと PassportDevices クラスを作成します。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-118">Create UserAccount and PassportDevices classes that will act as models for data to be saved in the mock database.</span></span> <span data-ttu-id="b8b2f-119">UserAccount は、従来型の認証サーバーに実装されているユーザー モデルと同様です。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-119">The UserAccount will be similar to the user model implemented on a traditional authentication server.</span></span> <span data-ttu-id="b8b2f-120">AuthService フォルダーを右クリックし、"UserAccount.cs" という新しいクラスを追加します。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-120">Right click on the AuthService folder and add a new class called "UserAccount.cs."</span></span>

    ![Windows Hello の認証作成用フォルダー](images/passport-auth-1.png)

    ![Windows Hello の認証作成用クラス](images/passport-auth-2.png)

-   <span data-ttu-id="b8b2f-123">クラス定義をパブリックに変更し、次のパブリック プロパティを追加します。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-123">Change the class definition to be public and then add the following public properties.</span></span> <span data-ttu-id="b8b2f-124">次の参照が必要です。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-124">You will need the following reference.</span></span>

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

    <span data-ttu-id="b8b2f-125">PassportDevices のコメント アウトされた一覧があります。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-125">You may have noticed the commented out list of PassportDevices.</span></span> <span data-ttu-id="b8b2f-126">現在の実装の既存のユーザー モデルにこの変更を加える必要があります。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-126">This is a modification you will need to make to an existing user model in your current implementation.</span></span> <span data-ttu-id="b8b2f-127">PassportDevices の一覧には deviceID、Windows Hello から生成された公開キー、[**KeyCredentialAttestationResult**](https://msdn.microsoft.com/library/windows/apps/dn973034) が含められます。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-127">The list of PassportDevices will contain a deviceID, the public key made from Windows Hello, and a [**KeyCredentialAttestationResult**](https://msdn.microsoft.com/library/windows/apps/dn973034).</span></span> <span data-ttu-id="b8b2f-128">このハンズオン ラボでは、keyAttestationResult を実装する必要があります。これらが、TPM (Trusted Platform Modules) チップを搭載するデバイスの Windows Hello によってのみ提供されるためです。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-128">For this hands on lab you will need to implement the keyAttestationResult as they are only provided by Windows Hello on devices that have a TPM (Trusted Platform Modules) chip.</span></span> <span data-ttu-id="b8b2f-129">**KeyCredentialAttestationResult** は、複数のプロパティの組み合わせであるため、保存してデータベースに読み込むには分割する必要があります。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-129">The **KeyCredentialAttestationResult** is a combination of multiple properties and would need to be split in order to save and load them with a database.</span></span>

-   <span data-ttu-id="b8b2f-130">AuthService フォルダーに "PassportDevice.cs" という新しいクラスを作成します。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-130">Create a new class in the AuthService folder called "PassportDevice.cs".</span></span> <span data-ttu-id="b8b2f-131">これは、上で説明した Windows Hello デバイスのモデルです。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-131">This is the model for the Windows Hello devices as discussed above.</span></span> <span data-ttu-id="b8b2f-132">クラス定義をパブリックに変更し、次のプロパティを追加します。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-132">Change the class definition to be public and add the following properties.</span></span>

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

-   <span data-ttu-id="b8b2f-133">UserAccount.cs に戻り、Windows Hello デバイスの一覧のコメントを解除します。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-133">Return to in UserAccount.cs and uncomment the list of Windows Hello devices.</span></span>

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

-   <span data-ttu-id="b8b2f-134">UserAccount と PassportDevice のモデルが作成されたら、モック データベースとして機能する AuthService で別の新しいクラスを作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-134">With the model for the UserAccount and the PassportDevice created, you need to create another new class in the AuthService that will act as the mock database.</span></span> <span data-ttu-id="b8b2f-135">これはモック データベースであるため、ユーザー アカウントの一覧の保存と読み込みはローカルで行います。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-135">As this is a mock database from where you will be saving and loading a list of user accounts locally.</span></span> <span data-ttu-id="b8b2f-136">実際にはデータベース実装になります。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-136">In the real world this would be your database implementation.</span></span> <span data-ttu-id="b8b2f-137">AuthService で "MockStore.cs" という新しいクラスを作成します。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-137">Create a new class in AuthService called "MockStore.cs".</span></span> <span data-ttu-id="b8b2f-138">クラス定義をパブリックに変更します。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-138">Change the class definition to public.</span></span>
-   <span data-ttu-id="b8b2f-139">モック ストアではユーザー アカウントの一覧の保存と読み込みがローカルで行われるため、XmlSerializer を使ってその一覧の保存と読み込みを行うためのロジックを実装できます。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-139">As the mock store will save and load a list of user accounts locally you can implement the logic to save and load that list using an XmlSerializer.</span></span> <span data-ttu-id="b8b2f-140">ファイル名と保存場所も記憶する必要があります。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-140">You will also need to remember the filename and save location.</span></span> <span data-ttu-id="b8b2f-141">MockStore.cs で、次の内容を実装します。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-141">In MockStore.cs implement the following:</span></span>

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

-   <span data-ttu-id="b8b2f-142">読み込みメソッドでは、InitializeSampleUserAccounts メソッドがコメント アウトされている点に注目してください。このメソッドは、MockStore.cs で作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-142">In the load method you may have noticed that an InitializeSampleUserAccounts method was commented out. You will need to create this method in the MockStore.cs.</span></span> <span data-ttu-id="b8b2f-143">このメソッドによりユーザー アカウントの一覧が入力され、ログインできるようになります。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-143">This method will populate the user accounts list so that a login can take place.</span></span> <span data-ttu-id="b8b2f-144">実際には、ユーザー データベースには情報が既に入力されています。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-144">In the real world the user database would already be populated.</span></span> <span data-ttu-id="b8b2f-145">この手順では、ユーザーの一覧を初期化し、load を呼び出すコンストラクターも作成します。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-145">In this step you will also be creating a constructor that will initialise the user list and call load.</span></span>

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

-   <span data-ttu-id="b8b2f-146">これで InitalizeSampleUserAccounts メソッドが作成されたため、LoadAccountListAsync メソッドでのメソッド呼び出しをコメント解除します。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-146">Now that the InitalizeSampleUserAccounts method exists uncomment the method call in the LoadAccountListAsync method.</span></span>

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

-   <span data-ttu-id="b8b2f-147">モック ストア内のユーザー アカウントの一覧を保存し、読み込むことができるようになります。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-147">The user accounts list in mock store can now be saved and loaded.</span></span> <span data-ttu-id="b8b2f-148">アプリケーションの他の部分はこの一覧にアクセスできる必要があるため、このデータを取得するためにいくつかのメソッドが必要になります。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-148">Other parts of the application will need to have access to this list so there will need to be some methods to retrieve this data.</span></span> <span data-ttu-id="b8b2f-149">InitializeSampleUserAccounts メソッドの下に、次の get メソッドを追加します。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-149">Underneath the InitializeSampleUserAccounts method, add the following get methods.</span></span> <span data-ttu-id="b8b2f-150">これらのメソッドにより、userid、単一のユーザー、特定の Windows Hello デバイスのユーザー一覧を取得することができ、特定のデバイスのユーザーの公開キーを取得することもできます。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-150">They will allow you to get a userid, a single user, a list of users for a specific Windows Hello device, and also get the public key for the user on a specific device.</span></span>

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

-   <span data-ttu-id="b8b2f-151">次に実装するメソッドは、アカウントの追加、アカウントの削除、およびデバイスの削除を行う簡単な操作を処理します。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-151">The next methods to implement will handle simple operations to add account, remove account, and also remove device.</span></span> <span data-ttu-id="b8b2f-152">Windows Hello はデバイスに固有のため、デバイスの削除が必要です。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-152">Remove device is needed as Windows Hello is device specific.</span></span> <span data-ttu-id="b8b2f-153">ログインするデバイスごとに、Windows Hello によって新しい公開キーと秘密キーのペアが作成されます。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-153">For each device to which you log in, a new public and private key pair will be created by Windows Hello.</span></span> <span data-ttu-id="b8b2f-154">サインインするデバイスごとに異なるパスワードを使うようなものです。ただし、パスワードはすべてサーバーに保存されるため記憶する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-154">It is like having a different password for each device you sign in on, the only thing is you don’t need to remember all those passwords the server does.</span></span> <span data-ttu-id="b8b2f-155">MockStore.cs に次のメソッドを追加します。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-155">Add the following methods into the MockStore.cs</span></span>

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

- <span data-ttu-id="b8b2f-156">MockStore クラスで、Windows Hello 関連の情報を既存の UserAccount に追加するメソッドを追加します。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-156">In the MockStore class add a method that will add Windows Hello related information to an existing UserAccount.</span></span> <span data-ttu-id="b8b2f-157">このメソッドは、PassportUpdateDetails と呼ばれ、ユーザーと Windows Hello の詳細を識別するためのパラメーターを使います。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-157">This method will be called PassportUpdateDetails and will take parameters to identify the user, and the Windows Hello details.</span></span> <span data-ttu-id="b8b2f-158">PassportDevice を作成するときに KeyAttestationResult はコメント アウトされていましたが、実際のアプリケーションではこれが必要になります。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-158">The KeyAttestationResult has been commented out when creating a PassportDevice, in a real world application you would require this.</span></span>

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
                    // KeyAttestationResult = keyAttestationResult
                });
            }
        }
        SaveAccountListAsync();
    }
    ```

- <span data-ttu-id="b8b2f-159">MockStore クラスはこれで完成です。これはデータベースを表すため、プライベートと見なされます。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-159">The MockStore class is now complete, as this represents the database it should be considered private.</span></span> <span data-ttu-id="b8b2f-160">MockStore にアクセスするには、データベース データを操作するために AuthService クラスが必要です。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-160">In order to access the MockStore an AuthService class is needed to manipulate the database data.</span></span> <span data-ttu-id="b8b2f-161">AuthService フォルダーに "AuthService.cs" という新しいクラスを作成します。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-161">In the AuthService folder create a new class called "AuthService.cs".</span></span> <span data-ttu-id="b8b2f-162">クラス定義をパブリックに変更し、シングルトン インスタンス パターンを追加して、これまでインスタンスが 1 つしか作成されていないことを確認します。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-162">Change the class definition to public and add a singleton instance pattern to make sure only one instance is ever created.</span></span>

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

-   <span data-ttu-id="b8b2f-163">AuthService クラスは、MockStore クラスのインスタンスを作成し、MockStore オブジェクトのプロパティへのアクセスを提供する必要があります。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-163">The AuthService class will need to create an instance of the MockStore class and provide access to the properties of the MockStore object.</span></span>

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

-   <span data-ttu-id="b8b2f-164">MockStore オブジェクトの Passport 詳細の追加、削除、更新メソッドにアクセスするには、AuthService クラスにメソッドが必要です。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-164">You need methods in the AuthService class to access add, remove, and update passport details methods in the MockStore object.</span></span> <span data-ttu-id="b8b2f-165">AuthService クラス ファイルの末尾に、次のメソッドを追加します。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-165">At the end of the AuthService class file add the following methods.</span></span>

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

-   <span data-ttu-id="b8b2f-166">AuthService クラスは、資格情報を検証するメソッドを提供する必要があります。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-166">The AuthService class will need to provide a method to validate credentials.</span></span> <span data-ttu-id="b8b2f-167">このメソッドは、ユーザー名とパスワードを取得し、そのアカウントが存在していてパスワードが有効であることを確認します。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-167">This method will take a username and password and make sure that account exists and the password is valid.</span></span> <span data-ttu-id="b8b2f-168">既存のシステムには、ユーザーに権限があることを確認する、これと同等のメソッドが用意されています。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-168">An existing system would have an equivalent method to this that checks the user is authorized.</span></span> <span data-ttu-id="b8b2f-169">次の ValidateCredentials を AuthService.cs ファイルに追加します。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-169">Add the following ValidateCredentials to the AuthService.cs file.</span></span>

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

-   <span data-ttu-id="b8b2f-170">AuthService クラスには、クライアントにチャレンジを返してそのユーザーが要求元のユーザーであることを検証する要求チャレンジ メソッドが必要です。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-170">The AuthService class needs a request challenge method that will return a challenge to the client to validate the user is who they claim to be.</span></span> <span data-ttu-id="b8b2f-171">その場合、クライアントから返された署名済みチャレンジを受信するメソッドが AuthService クラスに必要です。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-171">Then a method is needed in the AuthService class to receive the signed challenge back from the client.</span></span> <span data-ttu-id="b8b2f-172">このハンズオン ラボでは、署名済みチャレンジが完了したかどうかを判断する方法のメソッドが不完全なままになっています。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-172">For this hands on lab the method of how you determine if the signed challenge has been completed has been left incomplete.</span></span> <span data-ttu-id="b8b2f-173">既存の認証システムに実装されている Windows Hello は、実装ごとに少しずつ異なります。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-173">Every implementation of Windows Hello into an existing authentication system will be slightly different.</span></span> <span data-ttu-id="b8b2f-174">サーバーに保存されている公開キーは、クライアントがサーバーに返す結果と一致している必要があります。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-174">The public key stored on the server needs to match with the result the client returned to the server.</span></span> <span data-ttu-id="b8b2f-175">AuthService.cs にこれらの 2 つのメソッドを追加します。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-175">Add these two methods to AuthService.cs.</span></span>

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

## <a name="exercise-2-client-side-logic"></a><span data-ttu-id="b8b2f-176">演習 2: クライアント側のロジック</span><span class="sxs-lookup"><span data-stu-id="b8b2f-176">Exercise 2: Client Side Logic</span></span>

<span data-ttu-id="b8b2f-177">この演習では、最初のラボのクライアント側ビューとヘルパー クラスを変更して、AuthService クラスを使います。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-177">In this exercise you will be changing the client side views and helper classes from the first lab to use the AuthService class.</span></span> <span data-ttu-id="b8b2f-178">実際には、AuthService が認証サーバーとなり、Web API を使ってサーバーとの間でデータを送受信する必要があります。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-178">In the real world the AuthService would be the authentication server and you would need to use Web API’s to send and receive data from the server.</span></span> <span data-ttu-id="b8b2f-179">このハンズオン ラボでは、わかりやすいようにクライアントとサーバーはすべてローカルになっています。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-179">For this hands on lab client and server are all local to keep things simple.</span></span> <span data-ttu-id="b8b2f-180">目的は、Windows Hello API を使う方法を学習することです。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-180">The objective is to learn how to use the Windows Hello APIs.</span></span>

-   <span data-ttu-id="b8b2f-181">MainPage.xaml.cs では、アカウント一覧を読み込む MockStore のインスタンスが AuthService クラスによって作成されたときに loaded メソッドで AccountHelper.LoadAccountListAsync メソッド呼び出しを削除できます。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-181">In the MainPage.xaml.cs you can remove the AccountHelper.LoadAccountListAsync method call in the loaded method as the AuthService class creates an instance of the MockStore which loads the accounts list.</span></span> <span data-ttu-id="b8b2f-182">loaded メソッドは、次のようになります。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-182">The loaded method should now look like below.</span></span> <span data-ttu-id="b8b2f-183">非同期メソッド定義を待機しているものはないため削除される点に注意してください。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-183">Note the async method definition is removed as nothing is being awaiting.</span></span>

    ```cs
    private void MainPage_Loaded(object sender, RoutedEventArgs e)
    {
        Frame.Navigate(typeof(UserSelection));
    }
    ```

-   <span data-ttu-id="b8b2f-184">Login ページのインターフェイスを更新して、パスワードの入力を要求します。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-184">Update the Login page interface to require a passport be entered.</span></span> <span data-ttu-id="b8b2f-185">このハンズオン ラボでは、既存のシステムを移行して Windows Hello を使う方法を示します。既存のアカウントには、ユーザー名とパスワードが設定されます。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-185">This hands on lab demonstrates how an existing system could be migrated to use Windows Hello and existing accounts will have a username and a password.</span></span> <span data-ttu-id="b8b2f-186">また、XAML の下部にある説明を更新して既定のパスワードを追加します。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-186">Also update the explanation at the bottom of the XAML to include the default password.</span></span> <span data-ttu-id="b8b2f-187">Login.xaml で次の XAML を更新します。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-187">Update the following XAML in Login.xaml</span></span>

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

-   <span data-ttu-id="b8b2f-188">Login クラスの分離コードで、クラスの先頭にある Account プライベート変数を変更して UserAccount にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-188">In the Login class code behind you will need to change the Account private variable at the top of the class to be a UserAccount.</span></span> <span data-ttu-id="b8b2f-189">OnNavigateTo イベントを変更して型が UserAccount になるようにキャストします。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-189">Change the OnNavigateTo event to cast the type to be a UserAccount.</span></span> <span data-ttu-id="b8b2f-190">次の参照が必要です。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-190">You will need the following reference.</span></span>

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

-   <span data-ttu-id="b8b2f-191">Login ページは以前の Account オブジェクトの代わりに UserAccount オブジェクトを使うため、UserAccount がいくつかのメソッドのパラメーターとして使われるように MicrosoftPassportHelper.cs を更新する必要があります。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-191">As the Login page is using a UserAccount object instead of the previous Account object the MicrosoftPassportHelper.cs will need to be updated to use a UserAccount as a parameter for some methods.</span></span> <span data-ttu-id="b8b2f-192">CreatePassportKeyAsync、RemovePassportAccountAsync、GetPassportAuthenticationMessageAsync の各メソッドの次のパラメーターを変更する必要があります。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-192">You will need to change the following parameters for the CreatePassportKeyAsync, RemovePassportAccountAsync and GetPassportAuthenticationMessageAsync methods.</span></span> <span data-ttu-id="b8b2f-193">UserAccount クラスには、UserId の Guid があるため、多くの場所でより具体的になるように Id を使い始めることになります。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-193">As the UserAccount class has a Guid for a UserId you will start using the Id in more places to be more specific.</span></span>

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

-   <span data-ttu-id="b8b2f-194">AccountHelper の代わりに AuthService が使われるように、Login.xaml.cs ファイルの SignInPassport メソッドを更新する必要があります。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-194">The SignInPassport method in Login.xaml.cs file will need to be updated to use the AuthService instead of the AccountHelper.</span></span> <span data-ttu-id="b8b2f-195">資格情報の検証は、AuthService を通じて行われます。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-195">Validation of credentials will happen through the AuthService.</span></span> <span data-ttu-id="b8b2f-196">このハンズオン ラボでは、構成済みのアカウントは "sampleUsername" のみです。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-196">For this hands on lab the only configured account is "sampleUsername".</span></span> <span data-ttu-id="b8b2f-197">このアカウントは、MockStore.cs の InitializeSampleUserAccounts メソッドで作成されます。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-197">This account is created in the InitializeSampleUserAccounts method in MockStore.cs.</span></span> <span data-ttu-id="b8b2f-198">ここで、Login.xaml.cs で SignInPassport メソッドを更新し、以下のコード スニペットを反映します。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-198">Update the SignInPassport method in Login.xaml.cs now to reflect the code snippet below.</span></span>

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

-   <span data-ttu-id="b8b2f-199">Windows Hello では、各デバイスのアカウントごとに異なる公開キーおよび秘密キーのペアが作成されるため、ウェルカム ページにはログインしたアカウントの登録済みデバイスの一覧を表示して、各デバイスの記録を消去できるようにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-199">As Windows Hello will create a different public and private key pair for each account on each device the Welcome page will need to display a list of registered devices for the logged in account, and allow each one to be forgotten.</span></span> <span data-ttu-id="b8b2f-200">Welcome.xaml で、ForgetButton の下に次の XAML を追加します。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-200">In Welcome.xaml add in the following XAML underneath the ForgetButton.</span></span> <span data-ttu-id="b8b2f-201">これにより、デバイスの記録を消去するボタン、エラー テキスト領域、すべてのデバイスが表示される一覧が実装されます。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-201">This will implement a forget device button, an error text area and a list to display all devices.</span></span>

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

-   <span data-ttu-id="b8b2f-202">Welcome.xaml.cs ファイルで、クラスの先頭にあるプライベート変数 Account をプライベート変数 UserAccount となるように変更する必要があります。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-202">In the Welcome.xaml.cs file you will need to change the private Account variable at the top of the class to be a private UserAccount variable.</span></span> <span data-ttu-id="b8b2f-203">次に、AuthService を使うように OnNavigatedTo メソッドを更新し、現在のアカウントの情報を取得します。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-203">Then update the OnNavigatedTo method to use the AuthService and retrieve information for the current account.</span></span> <span data-ttu-id="b8b2f-204">アカウント情報がある場合、デバイスを表示する一覧の itemsource を設定することができます。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-204">When you have the account information you can set the itemsource of the list to display the devices.</span></span> <span data-ttu-id="b8b2f-205">AuthService 名前空間への参照を追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-205">You will need to add a reference to the AuthService namespace.</span></span>

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

-   <span data-ttu-id="b8b2f-206">アカウントの削除に AuthService を使うとき、Button\_Forget\_User\_Click メソッド内の AccountHelper への参照は削除できます。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-206">As you will be using the AuthService when removing an account the reference to the AccountHelper in the Button\_Forget\_User\_Click method can be removed.</span></span> <span data-ttu-id="b8b2f-207">この結果、メソッドは次のようになります。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-207">The method should now look as below.</span></span>

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

-   <span data-ttu-id="b8b2f-208">MicrosoftPassportHelper メソッドは、アカウントの削除に AuthService を使いません。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-208">The MicrosoftPassportHelper method is not using the AuthService to remove the account.</span></span> <span data-ttu-id="b8b2f-209">AuthService への呼び出しを行って userId を渡す必要があります。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-209">You need to make a call to the AuthService and pass the userId.</span></span>

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

-   <span data-ttu-id="b8b2f-210">ウェルカム ページ クラスの実装を終了するには、デバイスの削除を可能にするメソッドを MicrosoftPassportHelper.cs で作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-210">Before you can finish implementing the Welcome page class, you need to create a method in MicrosoftPassportHelper.cs that will allow a device to be removed.</span></span> <span data-ttu-id="b8b2f-211">AuthService で PassportRemoveDevice を呼び出す新しいメソッドを作成します。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-211">Create a new method that will call PassportRemoveDevice in AuthService.</span></span>

    ```cs
    public static void RemovePassportDevice(UserAccount account, Guid deviceId)
    {
        AuthService.AuthService.Instance.PassportRemoveDevice(account.UserId, deviceId);
    }
    ```

-   <span data-ttu-id="b8b2f-212">Welcome.xaml.cs では、Forget Device クリック イベントを実装します。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-212">In Welcome.xaml.cs implement the Forget Device click event.</span></span> <span data-ttu-id="b8b2f-213">このイベントは、デバイスの一覧から選択されたデバイスを使い、Passport ヘルパーを使ってデバイスの削除を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-213">This will use the selected device from the list of devices and use the passport helper to call remove device.</span></span>

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

-   <span data-ttu-id="b8b2f-214">更新する次のページは、UserSelection ページです。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-214">The next page you will update is the UserSelection page.</span></span> <span data-ttu-id="b8b2f-215">UserSelection ページは、現在のデバイスのすべてのユーザー アカウントを取得するために AuthService を使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-215">The UserSelection page will need to use the AuthService to retrieve all user accounts for the current device.</span></span> <span data-ttu-id="b8b2f-216">現在のところ、デバイス ID を取得して AuthService に渡す方法はないため、そのデバイスのユーザー アカウントを返すことができます。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-216">Currently there is no way for you get a device id to pass to the AuthService so it can return user accounts for that device.</span></span> <span data-ttu-id="b8b2f-217">Utils フォルダーで、"Helpers.cs" という新しいクラスを作成します。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-217">In the Utils folder create a new class called "Helpers.cs".</span></span> <span data-ttu-id="b8b2f-218">クラス定義をパブリック静的に変更し、現在のデバイス ID の取得を可能にする次のメソッドを追加します。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-218">Change the class definition to be public static and then add the following method that will allow you to retrieve the current device id.</span></span>

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

-   <span data-ttu-id="b8b2f-219">UserSelection ページ クラスでは、ユーザー インターフェイスではなく分離コードのみを変更する必要があります。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-219">In the UserSelection page class only the code behind needs to change, not the user interface.</span></span> <span data-ttu-id="b8b2f-220">UserSelection.xaml.cs では、loaded メソッドとユーザー選択メソッドを更新して、Account クラスの代わりに UserAccount クラスを使うようにします。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-220">In UserSelection.xaml.cs update the loaded method and the user selection method to use the UserAccount class instead of the Account class.</span></span> <span data-ttu-id="b8b2f-221">AuthService を通じてこのデバイスのすべてのユーザーを取得する必要もあります。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-221">You will also need to get all users for this device through the AuthService.</span></span>

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

-   <span data-ttu-id="b8b2f-222">PassportRegister ページは、分離コードを更新する必要があります。ユーザー インターフェイスを変更する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-222">The PassportRegister page needs to update the code behind, the user interface does not need changing.</span></span> <span data-ttu-id="b8b2f-223">PassportRegister.xaml.cs では、クラスの先頭にあるプライベート変数 Account が不要になったため削除します。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-223">In PassportRegister.xaml.cs remove the private Account variable at the top of the class as it is no longer needed.</span></span> <span data-ttu-id="b8b2f-224">RegisterButton クリック イベントを更新して AuthService を使うようにします。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-224">Update the RegisterButton click event to use the AuthService.</span></span> <span data-ttu-id="b8b2f-225">このメソッドは、新しい UserAccount を作成し、Passport の詳細を試して更新します。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-225">This method will create a new UserAccount and then try and update its passport details.</span></span> <span data-ttu-id="b8b2f-226">Passport が Passport キーの作成に失敗した場合、登録プロセスが失敗するためアカウントは削除されます。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-226">If passport fails to create a passport key the account will be removed as the registration process failed.</span></span>

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

-   <span data-ttu-id="b8b2f-227">アプリをビルドして実行します (F5)。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-227">Build and run the application (F5).</span></span> <span data-ttu-id="b8b2f-228">資格情報 "sampleUsername" および "samplePassword" を使って、サンプル ユーザー アカウントにサインインします。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-228">Sign into the sample user account, with the credentials "sampleUsername" and "samplePassword".</span></span> <span data-ttu-id="b8b2f-229">ようこそ画面には、デバイスを消去するボタンが表示されてもデバイスがないことがあります。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-229">On the welcome screen you may notice the Forget devices button is displayed but there are no devices.</span></span> <span data-ttu-id="b8b2f-230">ユーザーを作成するときや Windows Hello を使うようにユーザーを移行するとき、Passport 情報は AuthService にプッシュされません。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-230">When you are creating or migrating a user to work with Windows Hello the passport information is not being pushed to the AuthService.</span></span>

    ![Windows Hello のログイン画面](images/passport-auth-3.png)

    ![Windows Hello のログインの成功](images/passport-auth-4.png)

-   <span data-ttu-id="b8b2f-233">Passport 情報を AuthService に送るには、MicrosoftPassportHelper.cs を更新する必要があります。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-233">To get the passport information to the AuthService the MicrosoftPassportHelper.cs will need to be updated.</span></span> <span data-ttu-id="b8b2f-234">CreatePassportKeyAsync メソッドでは、成功した場合に true を返すだけではなく、KeyAttestation の取得を試みる新しいメソッドを呼び出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-234">In the CreatePassportKeyAsync method, instead of only returning true in the case that it is successful, you will need to call a new method which will try to get the KeyAttestation.</span></span> <span data-ttu-id="b8b2f-235">このハンズオン ラボではこの情報が AuthService に記録されないため、この情報をクライアント側で取得する方法を説明します。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-235">While this hands on lab is not recording this information in the AuthService you will learn how you would get it this information on the client side.</span></span> <span data-ttu-id="b8b2f-236">CreatePassportKeyAsync メソッドを更新します。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-236">Update the CreatePassportKeyAsync method.</span></span>

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

-   <span data-ttu-id="b8b2f-237">MicrosoftPassportHelper.cs でこの GetKeyAttestationAsync メソッドを作成します。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-237">Create this GetKeyAttestationAsync method in MicrosoftPassportHelper.cs.</span></span> <span data-ttu-id="b8b2f-238">このメソッドは、特定のデバイス上のアカウントごとに Windows Hello により提供可能な必要なすべての情報を取得する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-238">This method will demonstrate how to obtain all the necessary information that can be provided by Windows Hello for each account on a specific device.</span></span>

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

-   <span data-ttu-id="b8b2f-239">先ほど追加した GetKeyAttestationAsync メソッドでは、最後の行がコメント アウトされている点に注目してください。新しいメソッドとして作成するのはこの最後の行であり、すべての Windows Hello 情報を AuthService に送信します。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-239">You may have noticed in the GetKeyAttestationAsync method that you just added the last line was commented out. This last line will be a new method you create that will send all the Windows Hello information to the AuthService.</span></span> <span data-ttu-id="b8b2f-240">実際の環境では、Web API を使って実際のサーバーにこれを送信する必要があります。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-240">In the real world you would need to send this to an actual server with a Web API.</span></span>

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

-   <span data-ttu-id="b8b2f-241">Windows Hello 情報が AuthService に送信されるように、GetKeyAttestationAsync メソッドの最後の行のコメントを解除します。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-241">Uncomment the last line in the GetKeyAttestationAsync method so that the Windows Hello information is being sent to the AuthService.</span></span>
-   <span data-ttu-id="b8b2f-242">アプリケーションをビルドして実行し、既定の資格情報を使ってサインインします。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-242">Build and run the application and sign in with the default credentials as before.</span></span> <span data-ttu-id="b8b2f-243">ようこそ画面に、デバイス ID が表示されるのがわかります。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-243">On the welcome screen you will now see that the device Id is displayed.</span></span> <span data-ttu-id="b8b2f-244">別のデバイスでサインインした場合、それもここに表示されます (クラウド ホスト型認証サービスを使っていた場合)。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-244">If you signed in on another device that would also be displayed here (if you had a cloud hosted auth service).</span></span> <span data-ttu-id="b8b2f-245">このハンズオン ラボでは、実際のデバイス ID が表示されます。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-245">For this hands on lab the actual device Id is being displayed.</span></span> <span data-ttu-id="b8b2f-246">実際の実装では、ユーザーが理解して各デバイスの特定に使うことができるフレンドリ名を表示できます。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-246">In a real implementation you would want to display a friendly name that a person could understand and use to determine each device.</span></span>

    ![Windows Hello でのログインに成功したデバイス ID](images/passport-auth-5.png)

-   21. <span data-ttu-id="b8b2f-248">このハンズオン ラボを完了するには、ユーザー選択ページから選んでもう一度サインインするときにユーザーの要求とチャレンジが必要です。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-248">To complete this hands on lab you need a request and challenge for the user when they select from the user selection page and sign back in.</span></span> <span data-ttu-id="b8b2f-249">AuthService には、チャレンジを要求するために作成した 2 つのメソッドと、署名済みのチャレンジを使う 1 つのメソッドがあります。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-249">The AuthService has two methods that you created to request a challenge, one that uses a signed challenge.</span></span> <span data-ttu-id="b8b2f-250">MicrosoftPassportHelper.cs で、"RequestSignAsync" という新しいメソッドを作成します。このメソッドは、AuthService にチャレンジを要求し、Passport API を使ってそのチャレンジにローカルに署名して、署名済みのチャレンジを AuthService に送信します。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-250">In MicrosoftPassportHelper.cs create a new method called "RequestSignAsync" This will request a challenge from the AuthService, locally sign that challenge using a Passport API and send the signed challenge to the AuthService.</span></span> <span data-ttu-id="b8b2f-251">このハンズオン ラボでは、AuthService が署名済みのチャレンジを受け取って true を返します。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-251">In this hands on lab the AuthService will receive the signed challenge and return true.</span></span> <span data-ttu-id="b8b2f-252">実際の実装では、チャレンジが適切なデバイスの適切なユーザーによって署名されたことを判断する検証メカニズムを実装する必要があります。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-252">In an actual implementation you would need to implement a verification mechanism to determine is the challenge was signed by the correct user on the correct device.</span></span> <span data-ttu-id="b8b2f-253">次のメソッドを MicrosoftPassportHelper.cs に追加します。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-253">Add the method below to the MicrosoftPassportHelper.cs</span></span>

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

-   22. <span data-ttu-id="b8b2f-254">MicrosoftPassportHelper クラスで、GetPassportAuthenticationMessageAsync メソッドから RequestSignAsync メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-254">In the MicrosoftPassportHelper class call the RequestSignAsync method from the GetPassportAuthenticationMessageAsync method.</span></span>

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

-   <span data-ttu-id="b8b2f-255">この演習を通じて、クライアント側のアプリケーションを更新して AuthService を使うようにしました。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-255">Throughout this exercise, you have updated the client side application to use the AuthService.</span></span> <span data-ttu-id="b8b2f-256">こうすることで、Account クラスと AccountHelper クラスを省略することができました。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-256">By doing this you have been able to eliminate the need for the Account class and the AccountHelper class.</span></span> <span data-ttu-id="b8b2f-257">Utils フォルダーで Account クラス、Models フォルダー、AccountHelper クラスを削除します。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-257">Delete the Account class, the Models folder, and the AccountHelper class in the Utils folder.</span></span> <span data-ttu-id="b8b2f-258">ソリューションを正常にビルドするには、アプリケーション全体で Models 名前空間への参照をすべて削除する必要があります。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-258">You will need to remove all reference to the Models namespace throughout the application before the solution will successfully build.</span></span>
-   <span data-ttu-id="b8b2f-259">アプリケーションをビルドして実行し、モック サービスとモック データベースで Windows Hello を使ってみます。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-259">Build and run the application and enjoy using Windows Hello with the mock service and database.</span></span>

<span data-ttu-id="b8b2f-260">このハンズオン ラボでは、Windows 10 コンピューターから認証を使う場合に、Windows Hello API を使ってパスワードの入力を不要にする方法を習得しました。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-260">In this hands on lab you have learned how to use the Windows Hello APIs to replace the need for passwords when using authenticate from a Windows 10 machine.</span></span> <span data-ttu-id="b8b2f-261">パスワードの管理と既存のシステムで失われたパスワードのサポートにユーザーが費やす労力を考えると、Windows Hello のこの新しい認証システムに移行するメリットがわかります。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-261">When you consider how much energy is expended by people maintaining passwords and supporting lost passwords in existing systems, you should see the benefit of moving to this new Windows Hello system of authentication.</span></span>

<span data-ttu-id="b8b2f-262">練習用として、サービスとサーバー側で認証を実装する方法の詳細を記載しておきました。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-262">We have left as an exercise for you the details of how you will implement the authentication on the service and server side.</span></span> <span data-ttu-id="b8b2f-263">ほとんどの場合、Windows Hello を使い始めるために移行が必要な既存のシステムがあり、各システムの詳細は異なっていることが予想されます。</span><span class="sxs-lookup"><span data-stu-id="b8b2f-263">It is expected that most of you will have existing systems that will need to be migrated to start working with Windows Hello and the details of each system will differ.</span></span>

## <a name="related-topics"></a><span data-ttu-id="b8b2f-264">関連トピック</span><span class="sxs-lookup"><span data-stu-id="b8b2f-264">Related topics</span></span>

* [<span data-ttu-id="b8b2f-265">Windows Hello</span><span class="sxs-lookup"><span data-stu-id="b8b2f-265">Windows Hello</span></span>](microsoft-passport.md)
* [<span data-ttu-id="b8b2f-266">Windows Hello ログイン アプリ</span><span class="sxs-lookup"><span data-stu-id="b8b2f-266">Windows Hello login app</span></span>](microsoft-passport-login.md)