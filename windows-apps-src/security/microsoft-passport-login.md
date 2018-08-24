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
keywords: windows 10、uwp、セキュリティ
ms.localizationpriority: medium
ms.openlocfilehash: 284609399f167a7229d0c7bb5858d0f0eda451ce
ms.sourcegitcommit: c6d6f8b54253e79354f8db14e5cf3b113a3e5014
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/24/2018
ms.locfileid: "2841077"
---
# <a name="create-a-windows-hello-login-app"></a><span data-ttu-id="eeb73-104">Windows Hello ログイン アプリの作成</span><span class="sxs-lookup"><span data-stu-id="eeb73-104">Create a Windows Hello login app</span></span>




<span data-ttu-id="eeb73-105">\[一部の情報はリリース前の製品に関する事項であり、正式版がリリースされるまでに大幅に変更される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="eeb73-105">\[Some information relates to pre-released product which may be substantially modified before it's commercially released.</span></span> <span data-ttu-id="eeb73-106">ここに記載された情報について、Microsoft は明示または黙示を問わずいかなる保証をするものでもありません。\]</span><span class="sxs-lookup"><span data-stu-id="eeb73-106">Microsoft makes no warranties, express or implied, with respect to the information provided here.\]</span></span>

<span data-ttu-id="eeb73-107">これは、従来のユーザー名とパスワードの認証システムの代わりに Windows Hello を使う Windows 10 UWP (ユニバーサル Windows プラットフォーム) アプリを作成する方法に関する詳しいチュートリアルのパート 1 です。</span><span class="sxs-lookup"><span data-stu-id="eeb73-107">This is Part 1 of a complete walkthrough on how to create a Windows 10 UWP (Universal Windows Platform) app that uses Windows Hello as an alternative to traditional username and password authentication systems.</span></span> <span data-ttu-id="eeb73-108">アプリでは、サインインにユーザー名を使い、アカウントごとに Hello キーを作成します。</span><span class="sxs-lookup"><span data-stu-id="eeb73-108">The app uses a username for sign-in and create a Hello Key for each account.</span></span> <span data-ttu-id="eeb73-109">これらのアカウントは、Windows Hello の構成時に Windows の設定でセットアップされた暗証番号 (PIN) によって保護されます。</span><span class="sxs-lookup"><span data-stu-id="eeb73-109">These accounts will be protected by the PIN that is setup in Windows Settings on configuration of Windows Hello.</span></span>

<span data-ttu-id="eeb73-110">このチュートリアルは、アプリの作成とバックエンド サービスの接続の 2 つの部分に分かれています。</span><span class="sxs-lookup"><span data-stu-id="eeb73-110">This walkthrough is split into two parts: building the app and connecting the backend service.</span></span> <span data-ttu-id="eeb73-111">この記事を終了したら、パート 2「[Windows Hello ログイン サービス](microsoft-passport-login-auth-service.md)」に進んでください。</span><span class="sxs-lookup"><span data-stu-id="eeb73-111">When you're finished with this article, continue on to Part 2: [Windows Hello login service](microsoft-passport-login-auth-service.md).</span></span>

<span data-ttu-id="eeb73-112">開始する前に、「[Windows Hello](microsoft-passport.md)」の概要を読んで、Windows Hello の全般的なしくみを理解してください。</span><span class="sxs-lookup"><span data-stu-id="eeb73-112">Before you begin, you should read the [Windows Hello](microsoft-passport.md) overview for a general understanding of how Windows Hello works.</span></span>

## <a name="get-started"></a><span data-ttu-id="eeb73-113">開始</span><span class="sxs-lookup"><span data-stu-id="eeb73-113">Get started</span></span>


<span data-ttu-id="eeb73-114">このプロジェクトを作成するには、C# と XAML の経験がいくらか必要です。</span><span class="sxs-lookup"><span data-stu-id="eeb73-114">In order to build this project, you'll need some experience with C#, and XAML.</span></span> <span data-ttu-id="eeb73-115">Visual Studio 2015 を使用する必要もあります (コミュニティ Edition またはそれ以上)、または Windows 10 のコンピューターで、Visual Studio の今後のリリースします。</span><span class="sxs-lookup"><span data-stu-id="eeb73-115">You'll also need to be using Visual Studio 2015 (Community Edition or greater), or a later release of Visual Studio, on a Windows 10 machine.</span></span> <span data-ttu-id="eeb73-116">Visual Studio 2015 最低限必要なバージョンですが、最新の開発とセキュリティ更新プログラムは、Visual Studio の最新バージョンを使用することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="eeb73-116">While Visual Studio 2015 is the minimum required version, we recommend that you use the latest version of Visual Studio for the latest developer and security updates.</span></span>

-   <span data-ttu-id="eeb73-117">Visual Studio を開き、ファイルを選択して > 新規 > プロジェクト。</span><span class="sxs-lookup"><span data-stu-id="eeb73-117">Open Visual Studio and select File > New > Project.</span></span>
-   <span data-ttu-id="eeb73-118">[新しいプロジェクト] ウィンドウが開きます。</span><span class="sxs-lookup"><span data-stu-id="eeb73-118">This will open a “New Project” window.</span></span> <span data-ttu-id="eeb73-119">[テンプレート]、[Visual C#] の順に移動します。</span><span class="sxs-lookup"><span data-stu-id="eeb73-119">Navigation to Templates > Visual C#.</span></span>
-   <span data-ttu-id="eeb73-120">[空白のアプリ (ユニバーサル Windows)] を選び、アプリケーションに "PassportLogin" という名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="eeb73-120">Choose Blank App (Universal Windows) and name your application "PassportLogin".</span></span>
-   <span data-ttu-id="eeb73-121">新しいアプリケーションをビルドして実行すると (F5)、画面に空白のウィンドウが表示されます。</span><span class="sxs-lookup"><span data-stu-id="eeb73-121">Build and Run the new application (F5), you should see a blank window shown on the screen.</span></span> <span data-ttu-id="eeb73-122">アプリケーションを閉じます。</span><span class="sxs-lookup"><span data-stu-id="eeb73-122">Close the application.</span></span>

![Windows Hello の新しいプロジェクト](images/passport-login-1.png)

## <a name="exercise-1-login-with-microsoft-passport"></a><span data-ttu-id="eeb73-124">演習 1: Microsoft Passport でログインする</span><span class="sxs-lookup"><span data-stu-id="eeb73-124">Exercise 1: Login with Microsoft Passport</span></span>


<span data-ttu-id="eeb73-125">この演習では、コンピューターで Windows Hello がセットアップされているかどうかを確認する方法と、Windows Hello を使ってアカウントにサインインする方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="eeb73-125">In this exercise you will learn how to check if Windows Hello is setup on the machine, and how to sign into an account using Windows Hello.</span></span>

-   <span data-ttu-id="eeb73-126">新しいプロジェクトで、"Views" という新しいフォルダーをソリューションに作成します。</span><span class="sxs-lookup"><span data-stu-id="eeb73-126">In the new project create a new folder in the solution called "Views".</span></span> <span data-ttu-id="eeb73-127">このフォルダーには、このサンプルで移動先となるページが置かれます。</span><span class="sxs-lookup"><span data-stu-id="eeb73-127">This folder will contain the pages that will be navigated to in this sample.</span></span> <span data-ttu-id="eeb73-128">ソリューション エクスプローラーでプロジェクトを右クリックし、[追加]、[新しいフォルダー] の順に選んでフォルダー名を Views に変更します。</span><span class="sxs-lookup"><span data-stu-id="eeb73-128">Right click on the project in solution explorer, select Add > New Folder, then rename the folder to Views.</span></span>

    ![Windows Hello のフォルダーの追加](images/passport-login-2.png)

-   <span data-ttu-id="eeb73-130">新しい Views フォルダーを右クリックし、[追加]、[新しい項目] の順に選び、[空白のページ] を選びます。</span><span class="sxs-lookup"><span data-stu-id="eeb73-130">Right click on the new Views folder, select Add > New Item and select Blank Page.</span></span> <span data-ttu-id="eeb73-131">このページに "Login.xaml" という名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="eeb73-131">Name this page "Login.xaml".</span></span>

    ![Windows Hello の空白ページの追加](images/passport-login-3.png)

-   <span data-ttu-id="eeb73-133">新しいログイン ページのユーザー インターフェイスを定義するには、次の XAML を追加します。</span><span class="sxs-lookup"><span data-stu-id="eeb73-133">To define the user interface for the new login page, add the following XAML.</span></span> <span data-ttu-id="eeb73-134">この XAML では、次の子を配置するために StackPanel が定義されます。</span><span class="sxs-lookup"><span data-stu-id="eeb73-134">This XAML defines a StackPanel to align the following children:</span></span>

    -   <span data-ttu-id="eeb73-135">タイトルが格納される TextBlock</span><span class="sxs-lookup"><span data-stu-id="eeb73-135">TextBlock that will contain a title.</span></span>
    -   <span data-ttu-id="eeb73-136">エラー メッセージ用の TextBlock</span><span class="sxs-lookup"><span data-stu-id="eeb73-136">TextBlock for error messages.</span></span>
    -   <span data-ttu-id="eeb73-137">ユーザー名を入力する TextBox</span><span class="sxs-lookup"><span data-stu-id="eeb73-137">TextBox for the username to input.</span></span>
    -   <span data-ttu-id="eeb73-138">登録ページに移動する Button</span><span class="sxs-lookup"><span data-stu-id="eeb73-138">Button to navigate to a register page.</span></span>
    -   <span data-ttu-id="eeb73-139">Windows Hello の状態が格納される TextBlock</span><span class="sxs-lookup"><span data-stu-id="eeb73-139">TextBlock to contain the status of Windows Hello.</span></span>
    -   <span data-ttu-id="eeb73-140">バックエンド ユーザーまたは構成済みユーザーがない場合に Login ページについて説明する TextBlock</span><span class="sxs-lookup"><span data-stu-id="eeb73-140">TextBlock to explain the Login page as there is no backend or configured users.</span></span>

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

-   <span data-ttu-id="eeb73-141">ソリューションをビルドするには、分離コードにいくつかのメソッドを追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="eeb73-141">A few methods need to be added to the code behind to get the solution building.</span></span> <span data-ttu-id="eeb73-142">F7 キーを押すか、ソリューション エクスプローラーを使って Login.xaml.cs に移動します。</span><span class="sxs-lookup"><span data-stu-id="eeb73-142">Either press F7 or use the Solution Explorer to get to the Login.xaml.cs.</span></span> <span data-ttu-id="eeb73-143">Login イベントと Register イベントを処理する次の 2 つのイベント メソッドを追加します。</span><span class="sxs-lookup"><span data-stu-id="eeb73-143">Add in the following two event methods to handle the Login and Register events.</span></span> <span data-ttu-id="eeb73-144">この時点では、これらのメソッドは ErrorMessage.Text を空の文字列に設定します。</span><span class="sxs-lookup"><span data-stu-id="eeb73-144">For now these methods will set the ErrorMessage.Text to an empty string.</span></span>

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

-   <span data-ttu-id="eeb73-145">Login ページをレンダリングするため、MainPage コードを編集し、MainPage が読み込まれたときに Login ページに移動するようにします。</span><span class="sxs-lookup"><span data-stu-id="eeb73-145">In order to render the Login page, edit the MainPage code to navigate to the Login page when the MainPage is loaded.</span></span> <span data-ttu-id="eeb73-146">MainPage.xaml.cs ファイルを開きます。</span><span class="sxs-lookup"><span data-stu-id="eeb73-146">Open the MainPage.xaml.cs file.</span></span> <span data-ttu-id="eeb73-147">ソリューション エクスプローラーで、MainPage.xaml.cs をダブルクリックします。</span><span class="sxs-lookup"><span data-stu-id="eeb73-147">In the solution explorer double click on MainPage.xaml.cs.</span></span> <span data-ttu-id="eeb73-148">見つからない場合、MainPage.xaml の横にある小さい矢印をクリックして分離コードを表示します。</span><span class="sxs-lookup"><span data-stu-id="eeb73-148">If you can’t find this click the little arrow next to MainPage.xaml to show the code behind.</span></span> <span data-ttu-id="eeb73-149">ログイン ページに移動する読み込みイベント ハンドラー メソッドを作成します。</span><span class="sxs-lookup"><span data-stu-id="eeb73-149">Create a loaded event handler method that will navigate to the login page.</span></span> <span data-ttu-id="eeb73-150">Views 名前空間への参照を追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="eeb73-150">You will need to add a reference to the Views namespace.</span></span>

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

-   <span data-ttu-id="eeb73-151">Login ページでは、OnNavigatedTo イベントを処理して Windows Hello がこのコンピューターで利用できることを検証する必要があります。</span><span class="sxs-lookup"><span data-stu-id="eeb73-151">In the Login page you need to handle the OnNavigatedTo event to validate if Windows Hello is available on this machine.</span></span> <span data-ttu-id="eeb73-152">Login.xaml.cs で、次の内容を実装します。</span><span class="sxs-lookup"><span data-stu-id="eeb73-152">In Login.xaml.cs implement the following.</span></span> <span data-ttu-id="eeb73-153">MicrosoftPassportHelper オブジェクトがエラーを示します。</span><span class="sxs-lookup"><span data-stu-id="eeb73-153">You will notice that the MicrosoftPassportHelper object flags an error.</span></span> <span data-ttu-id="eeb73-154">これは、まだ実装していないためです。</span><span class="sxs-lookup"><span data-stu-id="eeb73-154">This is because we have not implement it yet.</span></span>

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

-   <span data-ttu-id="eeb73-155">MicrosoftPassportHelper クラスを作成するには、PassportLogin (ユニバーサル Windows) ソリューションを右クリックし、[追加]、[新しいフォルダー] の順にクリックします。</span><span class="sxs-lookup"><span data-stu-id="eeb73-155">To create the MicrosoftPassportHelper class, right click on the solution PassportLogin (Universal Windows) and click Add > New Folder.</span></span> <span data-ttu-id="eeb73-156">このフォルダーに Utils という名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="eeb73-156">Name this folder Utils.</span></span>

    ![Passport のヘルパー クラスの作成](images/passport-login-5.png)

-   <span data-ttu-id="eeb73-158">Utils フォルダーを右クリックし、[追加]、[クラス] の順にクリックします。</span><span class="sxs-lookup"><span data-stu-id="eeb73-158">Right click on the Utils folder and click Add > Class.</span></span> <span data-ttu-id="eeb73-159">このクラスに "MicrosoftPassportHelper.cs" という名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="eeb73-159">Name this class "MicrosoftPassportHelper.cs".</span></span>
-   <span data-ttu-id="eeb73-160">MicrosoftPassportHelper のクラス定義をパブリック静的に変更した後、Windows Hello を使う準備ができたかどうかをユーザーに知らせる次のメソッドを追加します。</span><span class="sxs-lookup"><span data-stu-id="eeb73-160">Change the class definition of MicrosoftPassportHelper to public static, then add the following method that to inform the user if Windows Hello is ready to be used or not.</span></span> <span data-ttu-id="eeb73-161">必要な名前空間を追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="eeb73-161">You will need to add the required namespaces.</span></span>

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

-   <span data-ttu-id="eeb73-162">Login.xaml.cs で、Utils 名前空間への参照を追加します。</span><span class="sxs-lookup"><span data-stu-id="eeb73-162">In Login.xaml.cs add a reference to the Utils namespace.</span></span> <span data-ttu-id="eeb73-163">これにより、OnNavigatedTo メソッドのエラーが解決されます。</span><span class="sxs-lookup"><span data-stu-id="eeb73-163">This will resolve the error in the OnNavigatedTo method.</span></span>

    ```cs
    using PassportLogin.Utils;
    ```

-   <span data-ttu-id="eeb73-164">アプリをビルドして実行します (F5)。</span><span class="sxs-lookup"><span data-stu-id="eeb73-164">Build and run the application (F5).</span></span> <span data-ttu-id="eeb73-165">ログイン ページに自動的に移動し、Hello を使う準備ができているかどうかを示す Windows Hello バナーが表示されます。</span><span class="sxs-lookup"><span data-stu-id="eeb73-165">You will be navigated to the login page and the Windows Hello banner will indicate to you if Hello is ready to be used.</span></span> <span data-ttu-id="eeb73-166">コンピューターでの Windows Hello の状態を示す緑色または青色のバナーが表示されます。</span><span class="sxs-lookup"><span data-stu-id="eeb73-166">You should see either the green or blue banner indicating the Windows Hello status on your machine.</span></span>

    ![Windows Hello のログイン画面の準備](images/passport-login-6.png)

    ![Windows Hello のログイン画面 (セットアップされていない場合)](images/passport-login-7.png)

-   <span data-ttu-id="eeb73-169">次に、サインインのロジックを作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="eeb73-169">The next thing you need to do is build the logic for signing in.</span></span> <span data-ttu-id="eeb73-170">新しいフォルダーを "Models" という名前で作成します。</span><span class="sxs-lookup"><span data-stu-id="eeb73-170">Create a new folder called "Models".</span></span>
-   <span data-ttu-id="eeb73-171">Models フォルダーで、"Account.cs" という新しいクラスを作成します。</span><span class="sxs-lookup"><span data-stu-id="eeb73-171">In the Models folder create a new class called "Account.cs".</span></span> <span data-ttu-id="eeb73-172">このクラスは、アカウント モデルとして機能します。</span><span class="sxs-lookup"><span data-stu-id="eeb73-172">This class will act as your account model.</span></span> <span data-ttu-id="eeb73-173">これはサンプルのため、ユーザー名のみが含められます。</span><span class="sxs-lookup"><span data-stu-id="eeb73-173">As this is a sample it will only contain a username.</span></span> <span data-ttu-id="eeb73-174">クラス定義をパブリックに変更し、Username プロパティを追加します。</span><span class="sxs-lookup"><span data-stu-id="eeb73-174">Change the class definition to public and add the Username property.</span></span>
    
    ```cs
    namespace PassportLogin.Models
    {
        public class Account
        {
            public string Username { get; set; }
        }
    }
    ```

-   <span data-ttu-id="eeb73-175">アカウントを処理する方法が必要です。</span><span class="sxs-lookup"><span data-stu-id="eeb73-175">You will need a way to handle accounts.</span></span> <span data-ttu-id="eeb73-176">このハンズオン ラボでは、サーバー (つまり、データベース) がないため、ユーザーの一覧の保存と読み込みはローカルで行われます。</span><span class="sxs-lookup"><span data-stu-id="eeb73-176">For this hands on lab as there is no server, or a database, a list of users will be saved and loaded locally.</span></span> <span data-ttu-id="eeb73-177">Utils フォルダーを右クリックし、"AccountHelper.cs" という新しいクラスを追加します。</span><span class="sxs-lookup"><span data-stu-id="eeb73-177">Right click on the Utils folder and add a new class called "AccountHelper.cs".</span></span> <span data-ttu-id="eeb73-178">クラス定義をパブリック静的に変更します。</span><span class="sxs-lookup"><span data-stu-id="eeb73-178">Change the class definition to be public static.</span></span> <span data-ttu-id="eeb73-179">AccountHelper は、アカウントの一覧をローカルで保存して読み込むために必要なすべてのメソッドが追加される静的クラスです。</span><span class="sxs-lookup"><span data-stu-id="eeb73-179">The AccountHelper is a static class that will contain all the necessary methods to save and load the list of accounts locally.</span></span> <span data-ttu-id="eeb73-180">保存と読み込みは、XmlSerializer を使って機能します。</span><span class="sxs-lookup"><span data-stu-id="eeb73-180">Saving and loading will work by using an XmlSerializer.</span></span> <span data-ttu-id="eeb73-181">保存したファイルとその保存場所を覚えておく必要もあります。</span><span class="sxs-lookup"><span data-stu-id="eeb73-181">You will also need to remember the file you saved and where you saved it.</span></span> <span data-ttu-id="eeb73-182">追加の名前空間を参照する必要があります。</span><span class="sxs-lookup"><span data-stu-id="eeb73-182">Additional namespaces will be need to be referenced.</span></span>
    
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

-   <span data-ttu-id="eeb73-183">次に、アカウントのローカルの一覧からアカウントを追加および削除する方法を実装します。</span><span class="sxs-lookup"><span data-stu-id="eeb73-183">Next, implement a way to add and remove an account from the local list of accounts.</span></span> <span data-ttu-id="eeb73-184">これらの操作それぞれにより、一覧が保存されます。</span><span class="sxs-lookup"><span data-stu-id="eeb73-184">These actions will each save the list.</span></span> <span data-ttu-id="eeb73-185">このハンズオン ラボで必要となる最後のメソッドは、検証メソッドです。</span><span class="sxs-lookup"><span data-stu-id="eeb73-185">The final method that you will need for this hands on lab is a validation method.</span></span> <span data-ttu-id="eeb73-186">ユーザーの認証サーバーまたはデータベースがないため、ハード コーディングされている単一のユーザーをこのメソッドが検証します。</span><span class="sxs-lookup"><span data-stu-id="eeb73-186">As there is no auth server or database of users, this will validate against a single user which is hard coded.</span></span> <span data-ttu-id="eeb73-187">これらのメソッドは、AccountHelper クラスに追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="eeb73-187">These methods should be added to the AccountHelper class.</span></span>
    
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

-   <span data-ttu-id="eeb73-188">次に、ユーザーからのサインイン要求を処理する必要があります。</span><span class="sxs-lookup"><span data-stu-id="eeb73-188">The next thing you need to do is handle a sign in request from the user.</span></span> <span data-ttu-id="eeb73-189">Login.xaml.cs で、現在のアカウント ログインを保持する新しいプライベート変数を作成します。</span><span class="sxs-lookup"><span data-stu-id="eeb73-189">In Login.xaml.cs create a new private variable that will hold the current account logging in.</span></span> <span data-ttu-id="eeb73-190">次に、新しいメソッド呼び出し SignInPassport を追加します。</span><span class="sxs-lookup"><span data-stu-id="eeb73-190">Then add a new method call SignInPassport.</span></span> <span data-ttu-id="eeb73-191">これにより、AccountHelper.ValidateAccountCredentials メソッドを使ってアカウントの資格情報が検証されます。</span><span class="sxs-lookup"><span data-stu-id="eeb73-191">This will validate the account credentials using the AccountHelper.ValidateAccountCredentials method.</span></span> <span data-ttu-id="eeb73-192">入力されたユーザー名が、前の手順で設定したハード コーディングされた文字列値と同じ場合、こメソッドはブール値を返します。</span><span class="sxs-lookup"><span data-stu-id="eeb73-192">This method will return a Boolean value if the entered user name is the same as the hard coded string value you set in the previous step.</span></span> <span data-ttu-id="eeb73-193">このサンプルのハードコーディングされた値は、"sampleUsername" です。</span><span class="sxs-lookup"><span data-stu-id="eeb73-193">The hard coded value for this sample is "sampleUsername".</span></span>

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

-   <span data-ttu-id="eeb73-194">MicrosoftPassportHelper のメソッドを参照しているコメント化されたコードがありました。</span><span class="sxs-lookup"><span data-stu-id="eeb73-194">You may have noticed the commented code that was referencing a method in MicrosoftPassportHelper.</span></span> <span data-ttu-id="eeb73-195">MicrosoftPassportHelper.cs で、CreatePassportKeyAsync という新しいメソッドを追加します。</span><span class="sxs-lookup"><span data-stu-id="eeb73-195">In MicrosoftPassportHelper.cs add in a new method called CreatePassportKeyAsync.</span></span> <span data-ttu-id="eeb73-196">このメソッドは、[**KeyCredentialManager**](https://msdn.microsoft.com/library/windows/apps/dn973043) で Windows Hello API を使います。</span><span class="sxs-lookup"><span data-stu-id="eeb73-196">This method uses the Windows Hello API in the [**KeyCredentialManager**](https://msdn.microsoft.com/library/windows/apps/dn973043).</span></span> <span data-ttu-id="eeb73-197">[**RequestCreateAsync**](https://msdn.microsoft.com/library/windows/apps/dn973048) を呼び出すと、*accountId* とローカル コンピューターに固有の Passport キーが作成されます。</span><span class="sxs-lookup"><span data-stu-id="eeb73-197">Calling [**RequestCreateAsync**](https://msdn.microsoft.com/library/windows/apps/dn973048) will create a Passport key that is specific to the *accountId* and the local machine.</span></span> <span data-ttu-id="eeb73-198">実際のシナリオでこれを実装する場合は、switch ステートメント内のコメントに注目してください。</span><span class="sxs-lookup"><span data-stu-id="eeb73-198">Please note the comments in the switch statement if you are interested in implementing this in a real world scenario.</span></span>

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

-   <span data-ttu-id="eeb73-199">これで、CreatePassportKeyAsync メソッドが作成されました。Login.xaml.cs ファイルに戻り、SignInPassport メソッド内のコードのコメントを解除します。</span><span class="sxs-lookup"><span data-stu-id="eeb73-199">Now you have created the CreatePassportKeyAsync method, return to the Login.xaml.cs file and uncomment the code inside the SignInPassport method.</span></span>

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

-   <span data-ttu-id="eeb73-200">アプリをビルドして実行します。</span><span class="sxs-lookup"><span data-stu-id="eeb73-200">Build and run the application.</span></span> <span data-ttu-id="eeb73-201">自動的に Login ページに移動します。</span><span class="sxs-lookup"><span data-stu-id="eeb73-201">You will be taken to the Login page.</span></span> <span data-ttu-id="eeb73-202">"sampleUsername" と入力し、[Login] をクリックします。</span><span class="sxs-lookup"><span data-stu-id="eeb73-202">Type in "sampleUsername" and click login.</span></span> <span data-ttu-id="eeb73-203">PIN の入力を求める Windows Hello プロンプトが表示されます。</span><span class="sxs-lookup"><span data-stu-id="eeb73-203">You will be prompted with a Windows Hello prompt asking you to enter your PIN.</span></span> <span data-ttu-id="eeb73-204">PIN を正しく入力すると、CreatePassportKeyAsync メソッドが Windows Hello キーを作成できるようになります。</span><span class="sxs-lookup"><span data-stu-id="eeb73-204">Upon entering your PIN correctly the CreatePassportKeyAsync method will be able to create a Windows Hello key.</span></span> <span data-ttu-id="eeb73-205">出力ウィンドウで、成功を示すメッセージが表示されるかどうかを確認してください。</span><span class="sxs-lookup"><span data-stu-id="eeb73-205">Monitor the output windows to see if the messages indicating success are shown.</span></span>

    ![Windows Hello のログイン PIN の入力画面](images/passport-login-8.png)

## <a name="exercise-2-welcome-and-user-selection-pages"></a><span data-ttu-id="eeb73-207">演習 2: ウェルカム ページとユーザーの選択ページ</span><span class="sxs-lookup"><span data-stu-id="eeb73-207">Exercise 2: Welcome and User Selection Pages</span></span>


<span data-ttu-id="eeb73-208">この演習は、前の演習の続きです。</span><span class="sxs-lookup"><span data-stu-id="eeb73-208">In this exercise, you will continue from the previous exercise.</span></span> <span data-ttu-id="eeb73-209">ユーザーが正常にログインすると、ウェルカム ページに移動し、サインアウトしたり、アカウントを削除したりすることができます。</span><span class="sxs-lookup"><span data-stu-id="eeb73-209">When a person successfully logs in they should be taken to a welcome page where they can sign out or delete their account.</span></span> <span data-ttu-id="eeb73-210">Windows Hello ではコンピューターごとにキーが作成されるため、そのコンピューターにサインインしたすべてのユーザーが表示されるユーザーの選択画面を作成できます。</span><span class="sxs-lookup"><span data-stu-id="eeb73-210">As Windows Hello creates a key for every machine, a user selection screen can be created, which displays all users that have been signed in on that machine.</span></span> <span data-ttu-id="eeb73-211">その後、ユーザーはいずれかのアカウントを選び、パスワードを再入力しなくてもようこそ画面に直接移動することができます。コンピューターにアクセスするときに既に認証されているためです。</span><span class="sxs-lookup"><span data-stu-id="eeb73-211">A user can then select one of these accounts and go directly to the welcome screen without needed to re-enter a password as they have already authenticated to access the machine.</span></span>

-   <span data-ttu-id="eeb73-212">Views フォルダーで、"Welcome.xaml" という新しい空白のページを追加します。</span><span class="sxs-lookup"><span data-stu-id="eeb73-212">In the Views folder add a new blank page called "Welcome.xaml".</span></span> <span data-ttu-id="eeb73-213">次の XAML を追加して、ユーザー インターフェイスを完成させます。</span><span class="sxs-lookup"><span data-stu-id="eeb73-213">Add the following XAML to complete the user interface.</span></span> <span data-ttu-id="eeb73-214">これには、タイトル、ログインしているユーザー名、および 2 つのボタンが表示されます。</span><span class="sxs-lookup"><span data-stu-id="eeb73-214">This will display a title, the logged in username, and two buttons.</span></span> <span data-ttu-id="eeb73-215">ボタンのうち 1 つはユーザーの一覧 (後で作成します) に戻るボタンで、もう 1 つのボタンはこのユーザーの消去を処理するボタンです。</span><span class="sxs-lookup"><span data-stu-id="eeb73-215">One of the buttons will navigate back to a user list (that you will create later), and the other button will handle forgetting this user.</span></span>

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

-   <span data-ttu-id="eeb73-216">Welcome.xaml.cs 分離コード ファイルで、ログオンしているアカウントを保持する新しいプライベート変数を追加します。</span><span class="sxs-lookup"><span data-stu-id="eeb73-216">In the Welcome.xaml.cs code behind file, add a new private variable that will hold the account that is logged in.</span></span> <span data-ttu-id="eeb73-217">OnNavigateTo イベントをオーバーライドするメソッドを実装する必要があります、このメソッドには、ウェルカム ページに渡されたアカウントが格納されます。</span><span class="sxs-lookup"><span data-stu-id="eeb73-217">You will need to implement a method to override the OnNavigateTo event, this will store the account passed to the welcome page.</span></span> <span data-ttu-id="eeb73-218">また、XAML で定義された 2 つのボタンのクリック イベントも実装する必要があります。</span><span class="sxs-lookup"><span data-stu-id="eeb73-218">You will also need to implement the click event for the two buttons defined in the XAML.</span></span> <span data-ttu-id="eeb73-219">Models フォルダーと Utils フォルダーへの参照が必要になります。</span><span class="sxs-lookup"><span data-stu-id="eeb73-219">You will need a reference to the Models and Utils folders.</span></span>

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

-   <span data-ttu-id="eeb73-220">ユーザーの消去クリック イベントにコメント アウトされた行があることに注目してください。</span><span class="sxs-lookup"><span data-stu-id="eeb73-220">You may have noticed a line commented out in the forget user click event.</span></span> <span data-ttu-id="eeb73-221">アカウントは、ローカルの一覧から削除されますが、現在のところ Windows Hello から削除する方法はありません。</span><span class="sxs-lookup"><span data-stu-id="eeb73-221">The account is being removed from your local list but currently there is no way to be removed from Windows Hello.</span></span> <span data-ttu-id="eeb73-222">Windows Hello ユーザーの削除を処理する新しいメソッドを MicrosoftPassportHelper.cs に実装する必要があります。</span><span class="sxs-lookup"><span data-stu-id="eeb73-222">You need to implement a new method in MicrosoftPassportHelper.cs that will handle removing a Windows Hello user.</span></span> <span data-ttu-id="eeb73-223">このメソッドは、他の Windows Hello API を使ってアカウントを開いたり削除したりします。</span><span class="sxs-lookup"><span data-stu-id="eeb73-223">This method will use other Windows Hello APIs to open and delete the account.</span></span> <span data-ttu-id="eeb73-224">実際の環境では、アカウントを削除するとサーバーやデータベースに通知されるため、ユーザー データベースは有効なままです。</span><span class="sxs-lookup"><span data-stu-id="eeb73-224">In the real world when you delete an account the server or database should be notified so the user database remains valid.</span></span> <span data-ttu-id="eeb73-225">Models フォルダーへの参照が必要になります。</span><span class="sxs-lookup"><span data-stu-id="eeb73-225">You will need a reference to the Models folder.</span></span>

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

-   <span data-ttu-id="eeb73-226">Welcome.xaml.cs に戻り、RemovePassportAccountAsync を呼び出す行のコメントを解除します。</span><span class="sxs-lookup"><span data-stu-id="eeb73-226">Back in Welcome.xaml.cs, uncomment the line that calls RemovePassportAccountAsync.</span></span>

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

-   <span data-ttu-id="eeb73-227">SignInPassport メソッド (Login.xaml.cs の) で、CreatePassportKeyAsync が成功すると、ようこそ画面に移動し、Account が渡されます。</span><span class="sxs-lookup"><span data-stu-id="eeb73-227">In the SignInPassport method (of Login.xaml.cs), once the CreatePassportKeyAsync is successful it should navigate to the Welcome screen and pass the Account.</span></span>

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

-   <span data-ttu-id="eeb73-228">アプリをビルドして実行します。</span><span class="sxs-lookup"><span data-stu-id="eeb73-228">Build and run the application.</span></span> <span data-ttu-id="eeb73-229">"sampleUsername" を使ってログインし、[Login] をクリックします。</span><span class="sxs-lookup"><span data-stu-id="eeb73-229">Login with "sampleUsername" and click login.</span></span> <span data-ttu-id="eeb73-230">PIN を入力し、成功した場合は、自動的にようこそ画面に移動します。</span><span class="sxs-lookup"><span data-stu-id="eeb73-230">Enter your PIN and if successful you should be navigated to the welcome screen.</span></span> <span data-ttu-id="eeb73-231">ユーザーの消去ボタンをクリックし、出力ウィンドウでユーザーが削除されたかどうかを確認してください。</span><span class="sxs-lookup"><span data-stu-id="eeb73-231">Try clicking forget user and monitor the output window to see if the user was deleted.</span></span> <span data-ttu-id="eeb73-232">ユーザーが削除されても、ウェルカム ページから移動しない点に注意してください。</span><span class="sxs-lookup"><span data-stu-id="eeb73-232">Notice that when the user is deleted you remain on the welcome page.</span></span> <span data-ttu-id="eeb73-233">アプリが移動できるユーザーの選択ページを作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="eeb73-233">You will need to create a user selection page that the app can navigate to.</span></span>

    ![Windows Hello のようこそ画面](images/passport-login-9.png)

-   <span data-ttu-id="eeb73-235">Views フォルダーで、"UserSelection.xaml" という新しい空白ページを作成し、次の XAML を追加してユーザー インターフェイスを定義します。</span><span class="sxs-lookup"><span data-stu-id="eeb73-235">In the Views folder create a new blank page called "UserSelection.xaml" and add the following XAML to define the user interface.</span></span> <span data-ttu-id="eeb73-236">このページには、ローカル アカウントの一覧にすべてのユーザーを表示する [**ListView**](https://msdn.microsoft.com/library/windows/apps/br242878) と、ログイン ページに移動してユーザーが別のアカウントを追加できるようにする Button が含められます。</span><span class="sxs-lookup"><span data-stu-id="eeb73-236">This page will contain a [**ListView**](https://msdn.microsoft.com/library/windows/apps/br242878) that displays all the users in the local accounts list, and a Button that will navigate to the login page to allow the user to add another account.</span></span>

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

-   <span data-ttu-id="eeb73-237">UserSelection.xaml.cs で、ローカルの一覧にアカウントが存在しない場合にログイン ページに移動する loaded メソッドを実装します。</span><span class="sxs-lookup"><span data-stu-id="eeb73-237">In UserSelection.xaml.cs implement the loaded method that will navigate to the login page if there are no accounts in the local list.</span></span> <span data-ttu-id="eeb73-238">ListView の SelectionChanged イベントと Button のクリック イベントも実装します。</span><span class="sxs-lookup"><span data-stu-id="eeb73-238">Also implement the SelectionChanged event for the ListView and a click event for the Button.</span></span>

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

-   <span data-ttu-id="eeb73-239">アプリには、UserSelection ページへの移動が必要ないくつかの場所があります。</span><span class="sxs-lookup"><span data-stu-id="eeb73-239">There are a few places in the app where you want to navigated to the UserSelection page.</span></span> <span data-ttu-id="eeb73-240">MainPage.xaml.cs では、Login ページではなく UserSelection ページに移動する必要があります。</span><span class="sxs-lookup"><span data-stu-id="eeb73-240">In MainPage.xaml.cs you should navigate to the UserSelection page instead of the Login page.</span></span> <span data-ttu-id="eeb73-241">MainPage で読み込みイベントが発生したときは、アカウントが存在することを UserSelection ページが確認できるようにアカウントの一覧を読み込む必要があります。</span><span class="sxs-lookup"><span data-stu-id="eeb73-241">While you are in the loaded event in MainPage you will need to load the accounts list so that the UserSelection page can check if there are any accounts.</span></span> <span data-ttu-id="eeb73-242">これには、loaded メソッドが非同期になるように変更するだけでなく、Utils フォルダーへの参照を追加することも必要です。</span><span class="sxs-lookup"><span data-stu-id="eeb73-242">This will require changing the loaded method to be async and also adding a reference to the Utils folder.</span></span>

    ```cs
    using PassportLogin.Utils;

    private async void MainPage_Loaded(object sender, RoutedEventArgs e)
    {
        // Load the local Accounts List before navigating to the UserSelection page
        await AccountHelper.LoadAccountListAsync();
        Frame.Navigate(typeof(UserSelection));
    }
    ```

-   <span data-ttu-id="eeb73-243">次に、ウェルカム ページから UserSelection ページに移動します。</span><span class="sxs-lookup"><span data-stu-id="eeb73-243">Next you will want to navigate to the UserSelection page from the Welcome page.</span></span> <span data-ttu-id="eeb73-244">どちらのクリック イベントでも、UserSelection ページに戻る必要があります。</span><span class="sxs-lookup"><span data-stu-id="eeb73-244">In both click events you should navigate back to the UserSelection page.</span></span>

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

-   <span data-ttu-id="eeb73-245">Login ページでは、UserSelection ページの一覧から選択されたアカウントにログインするためのコードが必要です。</span><span class="sxs-lookup"><span data-stu-id="eeb73-245">In the Login page you need code to log in to the account selected from the list in the UserSelection page.</span></span> <span data-ttu-id="eeb73-246">OnNavigatedTo イベントには、ナビゲーションに渡されるアカウントを格納します。</span><span class="sxs-lookup"><span data-stu-id="eeb73-246">In OnNavigatedTo event store the account passed to the navigation.</span></span> <span data-ttu-id="eeb73-247">まず、アカウントが既存のアカウントかどうかを識別する新しいプライベート変数を追加します。</span><span class="sxs-lookup"><span data-stu-id="eeb73-247">Start by adding a new private variable that will identify if the account is an existing account.</span></span> <span data-ttu-id="eeb73-248">次に、OnNavigatedTo イベントを処理します。</span><span class="sxs-lookup"><span data-stu-id="eeb73-248">Then handle the OnNavigatedTo event.</span></span>

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

-   <span data-ttu-id="eeb73-249">選択されたアカウントにサインインするには、SignInPassport メソッドを更新する必要があります。</span><span class="sxs-lookup"><span data-stu-id="eeb73-249">The SignInPassport method will need to be updated to sign in to the selected account.</span></span> <span data-ttu-id="eeb73-250">MicrosoftPassportHelper には、Passport でアカウントを開くための別のメソッドが必要になります。アカウントには、既に Passport キーが作成されているためです。</span><span class="sxs-lookup"><span data-stu-id="eeb73-250">The MicrosoftPassportHelper will need another method to open the account with Passport, as the account already has a Passport key created for it.</span></span> <span data-ttu-id="eeb73-251">MicrosoftPassportHelper.cs に新しいメソッドを実装し、Passport を使って既存のユーザーにサインインします。</span><span class="sxs-lookup"><span data-stu-id="eeb73-251">Implement the new method in MicrosoftPassportHelper.cs to sign in an existing user with passport.</span></span> <span data-ttu-id="eeb73-252">コードの各部分については、コードのコメントをお読みください。</span><span class="sxs-lookup"><span data-stu-id="eeb73-252">For information on each part of the code please read through the code comments.</span></span>

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

-   <span data-ttu-id="eeb73-253">既存のアカウントを処理するには、Login.xaml.cs の SignInPassport メソッドを更新します。</span><span class="sxs-lookup"><span data-stu-id="eeb73-253">Update the SignInPassport method in Login.xaml.cs to handle the existing account.</span></span> <span data-ttu-id="eeb73-254">この処理には、MicrosoftPassportHelper.cs の新しいメソッドが使われます。</span><span class="sxs-lookup"><span data-stu-id="eeb73-254">This will use the new method in the MicrosoftPassportHelper.cs.</span></span> <span data-ttu-id="eeb73-255">成功した場合、アカウントにサインインされ、自動的にようこそ画面に移動します。</span><span class="sxs-lookup"><span data-stu-id="eeb73-255">If successful the account will be signed in and the user navigated to the welcome screen.</span></span>

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

-   <span data-ttu-id="eeb73-256">アプリをビルドして実行します。</span><span class="sxs-lookup"><span data-stu-id="eeb73-256">Build and run the application.</span></span> <span data-ttu-id="eeb73-257">"sampleUsername" を使ってログインします。</span><span class="sxs-lookup"><span data-stu-id="eeb73-257">Login with "sampleUsername".</span></span> <span data-ttu-id="eeb73-258">PIN を入力します。成功した場合は、自動的にようこそ画面に移動します。</span><span class="sxs-lookup"><span data-stu-id="eeb73-258">Type in your PIN and if successful you will be navigated to the Welcome screen.</span></span> <span data-ttu-id="eeb73-259">ユーザーの一覧に戻るボタンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="eeb73-259">Click back to user list.</span></span> <span data-ttu-id="eeb73-260">一覧にユーザーが表示されます。</span><span class="sxs-lookup"><span data-stu-id="eeb73-260">You should now see a user in the list.</span></span> <span data-ttu-id="eeb73-261">この Passport をクリックすると、パスワードなどを再入力しなくても再度サインインできるようになります。</span><span class="sxs-lookup"><span data-stu-id="eeb73-261">If you click on this Passport enables you to sign back in without having to re-enter any passwords etc.</span></span>

    ![Windows Hello のユーザー選択用の一覧](images/passport-login-10.png)

## <a name="exercise-3-registering-a-new-windows-hello-user"></a><span data-ttu-id="eeb73-263">演習 3: 新しい Windows Hello ユーザーを登録する</span><span class="sxs-lookup"><span data-stu-id="eeb73-263">Exercise 3: Registering a new Windows Hello user</span></span>


<span data-ttu-id="eeb73-264">この演習では、Windows Hello を使って新しいアカウントを作成する新しいページを作成します。</span><span class="sxs-lookup"><span data-stu-id="eeb73-264">In this exercise you will be creating a new page that will create a new account with Windows Hello.</span></span> <span data-ttu-id="eeb73-265">このページは、Login ページの動作と似ています。</span><span class="sxs-lookup"><span data-stu-id="eeb73-265">This will work similarly to how the Login page works.</span></span> <span data-ttu-id="eeb73-266">Login ページは、Windows Hello の使用に移行する既存のユーザーのために実装されます。</span><span class="sxs-lookup"><span data-stu-id="eeb73-266">The Login page is implemented for an existing user that is migrating to use Windows Hello.</span></span> <span data-ttu-id="eeb73-267">PassportRegister ページでは、新しいユーザーの Windows Hello の登録が作成されます。</span><span class="sxs-lookup"><span data-stu-id="eeb73-267">A PassportRegister page will create Windows Hello registration for a new user.</span></span>

-   <span data-ttu-id="eeb73-268">Views フォルダーで、"PassportRegister.xaml" という新しい空白のページを作成します。</span><span class="sxs-lookup"><span data-stu-id="eeb73-268">In the views folder create a new blank page called "PassportRegister.xaml".</span></span> <span data-ttu-id="eeb73-269">XAML で、次の内容を追加してユーザー インターフェイスをセットアップします。</span><span class="sxs-lookup"><span data-stu-id="eeb73-269">In the XAML add in the following to setup the user interface.</span></span> <span data-ttu-id="eeb73-270">このインターフェイスは、Login ページに似ています。</span><span class="sxs-lookup"><span data-stu-id="eeb73-270">The interface here is similar to the Login page.</span></span>

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

-   <span data-ttu-id="eeb73-271">PassportRegister.xaml.cs 分離コード ファイルで、プライベート変数 Account と登録ボタンのクリック イベントを実装します。</span><span class="sxs-lookup"><span data-stu-id="eeb73-271">In the PassportRegister.xaml.cs code behind file implement a private Account variable and a click event for the register Button.</span></span> <span data-ttu-id="eeb73-272">これにより、新しいローカル アカウントが追加され、Passport キーが作成されます。</span><span class="sxs-lookup"><span data-stu-id="eeb73-272">This will add a new local account and create a Passport key.</span></span>

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

-   <span data-ttu-id="eeb73-273">登録ボタンがクリックされたら、Login ページからこのページに移動する必要があります。</span><span class="sxs-lookup"><span data-stu-id="eeb73-273">You need to navigate to this page from the Login page when register is clicked.</span></span>

    ```cs
    private void RegisterButtonTextBlock_OnPointerPressed(object sender, PointerRoutedEventArgs e)
    {
        ErrorMessage.Text = "";
        Frame.Navigate(typeof(PassportRegister));
    }
    ```

-   <span data-ttu-id="eeb73-274">アプリをビルドして実行します。</span><span class="sxs-lookup"><span data-stu-id="eeb73-274">Build and run the application.</span></span> <span data-ttu-id="eeb73-275">新しいユーザーを登録してみます。</span><span class="sxs-lookup"><span data-stu-id="eeb73-275">Try to register a new user.</span></span> <span data-ttu-id="eeb73-276">その後、ユーザーの一覧に戻り、そのユーザーを選んでログインできることを検証します。</span><span class="sxs-lookup"><span data-stu-id="eeb73-276">Then return to the user list and validate that you can select that user and login.</span></span>

    ![Windows Hello の新しいユーザーの登録](images/passport-login-11.png)

<span data-ttu-id="eeb73-278">このラボでは、新しい Windows Hello API を使って既存のユーザーを認証し、新しいユーザーのアカウントを作成するために必要となる基本的なスキルを習得しました。</span><span class="sxs-lookup"><span data-stu-id="eeb73-278">In this lab you have learned the essential skills you need to use the new Windows Hello API to authenticate existing users and create accounts for new users.</span></span> <span data-ttu-id="eeb73-279">この新しい知識があれば、ユーザーはアプリケーションのパスワードを記憶する必要がなくなりますが、引き続きアプリケーションをユーザー認証によって確実に保護することができます。</span><span class="sxs-lookup"><span data-stu-id="eeb73-279">With this new knowledge you can start removing the need for users to remember passwords for your application, yet remain confident that your applications remain protected by user authentication.</span></span> <span data-ttu-id="eeb73-280">Windows 10 では、Windows Hello の新しい認証テクノロジを使って、その生体認証ログイン オプションがサポートされます。</span><span class="sxs-lookup"><span data-stu-id="eeb73-280">Windows 10 uses Windows Hello's new authentication technology to support its biometrics login options.</span></span>

## <a name="related-topics"></a><span data-ttu-id="eeb73-281">関連トピック</span><span class="sxs-lookup"><span data-stu-id="eeb73-281">Related topics</span></span>

* [<span data-ttu-id="eeb73-282">Windows Hello</span><span class="sxs-lookup"><span data-stu-id="eeb73-282">Windows Hello</span></span>](microsoft-passport.md)
* [<span data-ttu-id="eeb73-283">Windows Hello ログイン サービス</span><span class="sxs-lookup"><span data-stu-id="eeb73-283">Windows Hello login service</span></span>](microsoft-passport-login-auth-service.md)
