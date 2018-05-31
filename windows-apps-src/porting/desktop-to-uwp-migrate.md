---
author: normesta
Description: Share code between a desktop app and a UWP app
Search.Product: eADQiWindows 10XVcnh
title: デスクトップ アプリと UWP アプリでコードを共有する
ms.author: normesta
ms.date: 10/03/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: ec676446562d5d97ff2a7020fc494f248323450b
ms.sourcegitcommit: 1eabcf511c7c7803a19eb31f600c6ac4a0067786
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/28/2018
ms.locfileid: "1691941"
---
# <a name="share-code-between-a-desktop-app-and-a-uwp-app"></a><span data-ttu-id="93286-103">デスクトップ アプリと UWP アプリでコードを共有する</span><span class="sxs-lookup"><span data-stu-id="93286-103">Share code between a desktop app and a UWP app</span></span>

<span data-ttu-id="93286-104">お持ちのコードを .NET Standard ライブラリに移行し、ユニバーサル Windows プラットフォーム (UWP) アプリを作成すると、すべての Windows 10 デバイスをターゲットにすることができます。</span><span class="sxs-lookup"><span data-stu-id="93286-104">You can move your code into .NET Standard libraries, and then create a Universal Windows Platform (UWP) app to reach all Windows 10 devices.</span></span> <span data-ttu-id="93286-105">デスクトップ アプリケーションを UWP アプリに変換できるツールはありませんが、多くの既存コードを再利用できるため、UWP アプリの作成コストを削減できます。</span><span class="sxs-lookup"><span data-stu-id="93286-105">While there's no tool that can convert a desktop application to a UWP app, you can reuse a lot of your existing code and that lowers the cost of building one.</span></span> <span data-ttu-id="93286-106">このガイドでは、その方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="93286-106">This guide shows you how to do that.</span></span>

## <a name="share-code-in-a-net-standard-20-library"></a><span data-ttu-id="93286-107">.NET Standard 2.0 ライブラリでコードを共有する</span><span class="sxs-lookup"><span data-stu-id="93286-107">Share code in a .NET Standard 2.0 library</span></span>

<span data-ttu-id="93286-108">できる限り多くのコードを .NET Standard 2.0 クラス ライブラリに配置してください。</span><span class="sxs-lookup"><span data-stu-id="93286-108">Place as much code as you can into .NET Standard 2.0 class libraries.</span></span>  <span data-ttu-id="93286-109">標準で定義されている API を使用しているコードは、UWP アプリで再利用できます。</span><span class="sxs-lookup"><span data-stu-id="93286-109">As long as your code uses APIs that are defined in the standard, you can reuse it in a UWP app.</span></span> <span data-ttu-id="93286-110">.NET Standard 2.0 に含まれる API が大幅に増えたため、.NET Standard ライブラリでのコード共有は、従来よりずっと簡単になっています。</span><span class="sxs-lookup"><span data-stu-id="93286-110">It's easier than it's ever been to share code in a .NET Standard library because so many more APIs are included in the .NET Standard 2.0.</span></span>

<span data-ttu-id="93286-111">詳しい解説は、こちらのビデオでご覧ください。</span><span class="sxs-lookup"><span data-stu-id="93286-111">Here's a great video that tells you more about it.</span></span>
<br><br>
<iframe src="https://www.youtube.com/embed/YI4MurjfMn8?list=PLRAdsfhKI4OWx321A_pr-7HhRNk7wOLLY&amp;ecver=1" width="636" height="480" allowFullScreen frameBorder="0"></iframe>

### <a name="add-net-standard-libraries"></a><span data-ttu-id="93286-112">.NET Standard ライブラリを追加する</span><span class="sxs-lookup"><span data-stu-id="93286-112">Add .NET Standard libraries</span></span>

<span data-ttu-id="93286-113">まず、1 つ以上の .NET Standard クラス ライブラリをソリューションに追加します。</span><span class="sxs-lookup"><span data-stu-id="93286-113">First, add one or more .NET Standard class libraries to your solution.</span></span>  

![.NET Standard プロジェクトの追加](images/desktop-to-uwp/dot-net-standard-project-template.png)

<span data-ttu-id="93286-115">ソリューションに追加するライブラリの数は、計画しているコード編成によって異なります。</span><span class="sxs-lookup"><span data-stu-id="93286-115">The number of libraries that you add to your solution depends on how you plan to organize your code.</span></span>

<span data-ttu-id="93286-116">各クラス ライブラリのターゲットが **.NET Standard 2.0** になっていることを確認してください。</span><span class="sxs-lookup"><span data-stu-id="93286-116">Make sure that each class library targets the **.NET Standard 2.0**.</span></span>

![.NET Standard 2.0 をターゲットにする](images/desktop-to-uwp/target-standard-20.png)

<span data-ttu-id="93286-118">この設定には、クラス ライブラリ プロジェクトのプロパティ ページからアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="93286-118">You can find this setting in the property pages of the class library project.</span></span>

<span data-ttu-id="93286-119">デスクトップ アプリケーション プロジェクトから、クラス ライブラリ プロジェクトへの参照を追加します。</span><span class="sxs-lookup"><span data-stu-id="93286-119">From your desktop application project, add a reference to the class library project.</span></span>

![クラス ライブラリ参照](images/desktop-to-uwp/class-library-reference.png)

<span data-ttu-id="93286-121">次に、ツールを使用して、どの程度のコードが標準に準拠しているか調べます。</span><span class="sxs-lookup"><span data-stu-id="93286-121">Next, use tools to determine how much of your code conforms to the standard.</span></span> <span data-ttu-id="93286-122">これにより、コードをライブラリに移行する前に、どの部分を再利用でき、どの部分で最小限の変更が必要になり、どの部分がアプリケーション固有にしておくのかを決定できます。</span><span class="sxs-lookup"><span data-stu-id="93286-122">That way, before you move code into the library, you can decide which parts you can reuse, which parts require minimal modification, and which parts will remain application-specific.</span></span>

### <a name="check-library-and-code-compatibility"></a><span data-ttu-id="93286-123">ライブラリとコードの互換性を確認する</span><span class="sxs-lookup"><span data-stu-id="93286-123">Check library and code compatibility</span></span>

<span data-ttu-id="93286-124">まず Nuget パッケージと、サード パーティから取得したその他の dll ファイルから始めます。</span><span class="sxs-lookup"><span data-stu-id="93286-124">We'll start with Nuget Packages and other dll files that you obtained from a third party.</span></span>

<span data-ttu-id="93286-125">アプリケーションでこれらを使用する場合は、.NET Standard 2.0 と互換性があるかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="93286-125">If your application uses any of them, determine if they are compatible with the .NET Standard 2.0.</span></span> <span data-ttu-id="93286-126">そのためには、Visual Studio 拡張機能またはコマンド ライン ユーティリティを使用できます。</span><span class="sxs-lookup"><span data-stu-id="93286-126">You can use a Visual Studio extension or a command-line utility to do that.</span></span>

<span data-ttu-id="93286-127">これらの同じツールを使用して、コードを分析します。</span><span class="sxs-lookup"><span data-stu-id="93286-127">Use these same tools to analyze your code.</span></span> <span data-ttu-id="93286-128">ここでツール ([dotnet apiport](https://github.com/Microsoft/dotnet-apiport/releases)) をダウンロードし、使用方法に関するビデオをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="93286-128">Download the tools here ([dotnet-apiport](https://github.com/Microsoft/dotnet-apiport/releases)) and then watch this video to learn how to use them.</span></span>
<br><br>
<iframe src="https://www.youtube.com/embed/rzs_FGPyAlY?list=PLRAdsfhKI4OWx321A_pr-7HhRNk7wOLLY&amp;ecver=2" width="636" height="480" allowFullScreen frameBorder="0"></iframe>

 <span data-ttu-id="93286-129">コードに標準との互換性がない場合は、そのコードを実装するための他の方法を検討してください。</span><span class="sxs-lookup"><span data-stu-id="93286-129">If your code isn't compatible with the standard, consider other ways that you could implement that code.</span></span> <span data-ttu-id="93286-130">まず [.NET API ブラウザー](https://docs.microsoft.com/dotnet/api/?view=netstandard-2.0)を開きます。</span><span class="sxs-lookup"><span data-stu-id="93286-130">Start by opening the [.NET API Browser](https://docs.microsoft.com/dotnet/api/?view=netstandard-2.0).</span></span> <span data-ttu-id="93286-131">このブラウザーを使用して、.NET Standard 2.0 に含まれている API を確認します。</span><span class="sxs-lookup"><span data-stu-id="93286-131">You can use that browser to review the API's that are available in the .NET Standard 2.0.</span></span> <span data-ttu-id="93286-132">一覧の範囲として .NET Standard 2.0 を指定してください。</span><span class="sxs-lookup"><span data-stu-id="93286-132">Make sure to scope the list to the .NET Standard 2.0.</span></span>

![.NET オプション](images/desktop-to-uwp/dot-net-option.png)

<span data-ttu-id="93286-134">コードの一部はプラットフォーム固有でありデスクトップ アプリケーション プロジェクト内に残す必要があります。</span><span class="sxs-lookup"><span data-stu-id="93286-134">Some of your code will be platform-specific and will need to remain in your desktop application project.</span></span>

### <a name="example-migrating-data-access-code-to-a-net-standard-20-library"></a><span data-ttu-id="93286-135">例: .NET Standard 2.0 ライブラリにデータ アクセス コードを移行する</span><span class="sxs-lookup"><span data-stu-id="93286-135">Example: Migrating data access code to a .NET Standard 2.0 library</span></span>

<span data-ttu-id="93286-136">Northwind のサンプル データベースに含まれる顧客を表示する基本的な Windows フォーム アプリがあると仮定します。</span><span class="sxs-lookup"><span data-stu-id="93286-136">Let's assume that we have a very basic Windows Forms app that shows customers from our Northwind sample database.</span></span>

![Windows フォーム アプリ](images/desktop-to-uwp/win-forms-app.png)

<span data-ttu-id="93286-138">このプロジェクトには、.NET Standard 2.0 クラス ライブラリおよび **Northwind** という静的クラスが含まれています。</span><span class="sxs-lookup"><span data-stu-id="93286-138">The project contains a .NET Standard 2.0 class library with a static class named **Northwind**.</span></span> <span data-ttu-id="93286-139">このコードでは ``SQLConnection`` クラス、``SqlCommand`` クラス、``SqlDataReader`` クラスが使用されており、これらのクラスが .NET Standard 2.0 にないため、**Northwind** クラスに移行してもコンパイルできません。</span><span class="sxs-lookup"><span data-stu-id="93286-139">If we move this code into the **Northwind** class, it won't compile because it uses the ``SQLConnection``, ``SqlCommand``, and ``SqlDataReader`` classes, and those classes that are not available in the .NET Standard 2.0.</span></span>

```csharp
public static ArrayList GetCustomerNames()
{
    ArrayList customers = new ArrayList();

    using (SqlConnection conn = new SqlConnection())
    {
        conn.ConnectionString =
            @"Data Source=" +
            @"<Your Server Name>\SQLEXPRESS;Initial Catalog=NORTHWIND;Integrated Security=SSPI";

        conn.Open();

        SqlCommand command = new SqlCommand("select ContactName from customers order by ContactName asc", conn);

        using (SqlDataReader reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                customers.Add(reader[0]);
            }
        }
    }

    return customers;
}

```
<span data-ttu-id="93286-140">[.NET API ブラウザー](https://docs.microsoft.com/dotnet/api/?view=netstandard-2.0)には、代わりのクラスが表示されます。</span><span class="sxs-lookup"><span data-stu-id="93286-140">The [.NET API Browser](https://docs.microsoft.com/dotnet/api/?view=netstandard-2.0) shows us an alternative though.</span></span> <span data-ttu-id="93286-141">.NET Standard 2.0 で利用可能な ``DbConnection`` クラス、``DbCommand`` クラス、``DbDataReader`` クラスを使用できます。</span><span class="sxs-lookup"><span data-stu-id="93286-141">We can use the ``DbConnection``, ``DbCommand``, and ``DbDataReader`` classes because those classes are available in the .NET Standard 2.0.</span></span>  

<span data-ttu-id="93286-142">この改訂バージョンではこれらのクラスを使用して顧客の一覧を取得しますが、``DbConnection`` クラスを作成するには、クライアント アプリケーションで作成するファクトリ オブジェクトを渡す必要があります。</span><span class="sxs-lookup"><span data-stu-id="93286-142">This revised version uses those classes to get a list of customers, but to create a ``DbConnection`` class, we'll need to pass in a factory object that we create in the client application.</span></span>

```csharp
public static ArrayList GetCustomerNames(DbProviderFactory factory)
{
    ArrayList customers = new ArrayList();

    using (DbConnection conn = factory.CreateConnection())
    {
        conn.ConnectionString = @"Data Source=" +
                        @"<Your Server Name>\SQLEXPRESS;Initial Catalog=NORTHWIND;Integrated Security=SSPI";

        conn.Open();

        DbCommand command = factory.CreateCommand();
        command.Connection = conn;
        command.CommandText = "select ContactName from customers order by ContactName asc";

        using (DbDataReader reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                customers.Add(reader[0]);
            }
        }
    }

    return customers;
}
```  

<span data-ttu-id="93286-143">Windows フォームの分離コード ページでは、ファクトリ インスタンスを作成しメソッドに渡すことができます。</span><span class="sxs-lookup"><span data-stu-id="93286-143">In the code-behind page of the Windows Form, we can just create factory instance and pass it into our method.</span></span>

```csharp
public partial class Customers : Form
{
    public Customers()
    {
        InitializeComponent();

        dataGridView1.Rows.Clear();

        SqlClientFactory factory = SqlClientFactory.Instance;

        foreach (string customer in Northwind.GetCustomerNames(factory))
        {
            dataGridView1.Rows.Add(customer);
        }
    }
}
```

## <a name="reach-all-windows-devices"></a><span data-ttu-id="93286-144">すべての Windows デバイスにリーチ</span><span class="sxs-lookup"><span data-stu-id="93286-144">Reach all Windows devices</span></span>

<span data-ttu-id="93286-145">これで、ソリューションに UWP アプリを追加する準備ができました。</span><span class="sxs-lookup"><span data-stu-id="93286-145">Now you're ready to add a UWP app to your solution.</span></span>
<div style="float: left; padding: 10px">
    ![Desktop to UWP Bridge のイメージ](images/desktop-to-uwp/adaptive-ui.png)
</div>
<span data-ttu-id="93286-147">UI ページは XAML で設計し、デバイス固有またはプラットフォーム固有のコードも記述する必要がありますが、完了すると、すべての Windows 10 デバイスをターゲットにすることができます。アプリ ページはさまざまな画面サイズや解像度に合わせて調整されるモダンな使用感になります。</span><span class="sxs-lookup"><span data-stu-id="93286-147">You'll still have to design UI pages in XAML and write any device or platform-specific code, but when you are done, you'll be able to reach the full breadth of Windows 10 devices and your app pages will have a modern feel that adapts well to different screen sizes and resolutions.</span></span>

<span data-ttu-id="93286-148">アプリはキーボードとマウスだけではなく、他の入力メカニズムにも応答し、さまざまなデバイスで直感的に機能や設定を使用できます。</span><span class="sxs-lookup"><span data-stu-id="93286-148">Your app will respond to input mechanisms other than just a keyboard and mouse, and features and settings will be intuitive across devices.</span></span> <span data-ttu-id="93286-149">つまり、ユーザーが操作方法を 1 回だけ学習すると、デバイスに関係なく慣れた方法で操作できます。</span><span class="sxs-lookup"><span data-stu-id="93286-149">This means that users learn how to do things one time, and then it works in a very familiar way no matter the device.</span></span>

<span data-ttu-id="93286-150">これらは、UWP による利点のごく一部です。</span><span class="sxs-lookup"><span data-stu-id="93286-150">These are just a few of the goodies that come with UWP.</span></span> <span data-ttu-id="93286-151">詳しくは、「[Windowsで優れたエクスペリエンスを実現](https://developer.microsoft.com/windows/why-build-for-uwp)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="93286-151">To learn more, see [Build great experiences with Windows](https://developer.microsoft.com/windows/why-build-for-uwp).</span></span>

### <a name="add-a-uwp-project"></a><span data-ttu-id="93286-152">UWP プロジェクトを追加する</span><span class="sxs-lookup"><span data-stu-id="93286-152">Add a UWP project</span></span>

<span data-ttu-id="93286-153">まず、UWP プロジェクトをソリューションに追加します。</span><span class="sxs-lookup"><span data-stu-id="93286-153">First, add a UWP project to your solution.</span></span>

![UWP プロジェクト](images/desktop-to-uwp/new-uwp-app.png)

<span data-ttu-id="93286-155">次に、UWP プロジェクトから、.NET Standard 2.0 ライブラリ プロジェクトへの参照を追加します。</span><span class="sxs-lookup"><span data-stu-id="93286-155">Then, from your UWP project, add a reference the .NET Standard 2.0 library project.</span></span>

![クラス ライブラリ参照](images/desktop-to-uwp/class-library-reference2.png)

### <a name="build-your-pages"></a><span data-ttu-id="93286-157">ページをビルドする</span><span class="sxs-lookup"><span data-stu-id="93286-157">Build your pages</span></span>

<span data-ttu-id="93286-158">XAML ページを追加し、.NET Standard 2.0 ライブラリ内のコードを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="93286-158">Add XAML pages and call the code in your .NET Standard 2.0 library.</span></span>

![UWP アプリ](images/desktop-to-uwp/uwp-app.png)

```xml
<Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
    <StackPanel x:Name="customerStackPanel">
        <ListView x:Name="customerList"/>
    </StackPanel>
</Grid>
```

```csharp
public sealed partial class MainPage : Page
{
    public MainPage()
    {
        this.InitializeComponent();

        SqlClientFactory factory = SqlClientFactory.Instance;

        customerList.ItemsSource = Northwind.GetCustomerNames(factory);
    }
}
```


<span data-ttu-id="93286-160">UWP を使い始めるには、「[UWP アプリとは](https://docs.microsoft.com/windows/uwp/get-started/universal-application-platform-guide)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="93286-160">To get started with UWP, see [What's a UWP app](https://docs.microsoft.com/windows/uwp/get-started/universal-application-platform-guide).</span></span>

## <a name="reach-ios-and-android-devices"></a><span data-ttu-id="93286-161">iOS および Android デバイスへのリーチ</span><span class="sxs-lookup"><span data-stu-id="93286-161">Reach iOS and Android devices</span></span>

<span data-ttu-id="93286-162">Xamarin プロジェクトを追加することにより、Android デバイスと iOS デバイスをターゲットにすることができます。</span><span class="sxs-lookup"><span data-stu-id="93286-162">You can reach Android and iOS devices by adding Xamarin projects.</span></span>  
<div style="float: left; padding: 10px">
    ![Xamarin アプリ](images/desktop-to-uwp/xamarin-apps.png)
</div>

<span data-ttu-id="93286-164">これらのプロジェクトでは、C# でプラットフォーム固有およびデバイスに固有の API へのフル アクセスを使用して、Android アプリと iOS アプリを構築できます。</span><span class="sxs-lookup"><span data-stu-id="93286-164">These projects let you use C# to build Android and iOS apps with full access to platform-specific and device-specific APIs.</span></span> <span data-ttu-id="93286-165">これらのアプリはプラットフォーム固有のハードウェア アクセラレーションを利用し、ネイティブ パフォーマンス用にコンパイルできます。</span><span class="sxs-lookup"><span data-stu-id="93286-165">These apps leverage platform-specific hardware acceleration, and are compiled for native performance.</span></span>

<span data-ttu-id="93286-166">これらのアプリでは、iBeacons や Android フラグメントなどのプラットフォーム固有機能を含めて、基盤となるプラットフォームおよびデバイスによって公開される機能に全面的にアクセスできます。標準のネイティブ ユーザー インターフェイス コントロールを使用すると、ユーザーが期待する外観と操作感の UI を構築できます。</span><span class="sxs-lookup"><span data-stu-id="93286-166">They have access to the full spectrum of functionality exposed by the underlying platform and device, including platform-specific capabilities like iBeacons and Android Fragments and you'll use standard native user interface controls to build UIs that look and feel the way that users expect them to.</span></span>

<span data-ttu-id="93286-167">UWP の場合と同様、.NET Standard 2.0 クラス ライブラリに用意されているビジネス ロジックを再利用できるため、Android アプリまたは iOS アプリを追加するコストが低くなります。</span><span class="sxs-lookup"><span data-stu-id="93286-167">Just like UWPs, the cost to add an Android or iOS app is lower because you can reuse business logic in a .NET Standard 2.0 class library.</span></span> <span data-ttu-id="93286-168">UI ページは XAML で設計し、デバイス固有またはプラットフォーム固有のコードを記述する必要があります。</span><span class="sxs-lookup"><span data-stu-id="93286-168">You'll have to design your UI pages in XAML and write any device or platform-specific code.</span></span>

### <a name="add-a-xamarin-project"></a><span data-ttu-id="93286-169">Xamarin プロジェクトを追加する</span><span class="sxs-lookup"><span data-stu-id="93286-169">Add a Xamarin project</span></span>

<span data-ttu-id="93286-170">まず、**Android**、**iOS**、または**クロス プラットフォーム**のプロジェクトをソリューションに追加します。</span><span class="sxs-lookup"><span data-stu-id="93286-170">First, add an **Android**, **iOS**, or **Cross-Platform** project to your solution.</span></span>

<span data-ttu-id="93286-171">これらのテンプレートは、**[新しいプロジェクトの追加]** ダイアログ ボックスの **[Visual C#]** グループにあります。</span><span class="sxs-lookup"><span data-stu-id="93286-171">You can find these templates in the **Add New Project** dialog box under the **Visual C#** group.</span></span>

![Xamarin アプリ](images/desktop-to-uwp/xamarin-projects.png)

>[!NOTE]
><span data-ttu-id="93286-173">クロスプラット フォーム プロジェクトは、プラットフォーム固有の機能がほとんどないアプリに最適です。</span><span class="sxs-lookup"><span data-stu-id="93286-173">Cross-platform projects are great for apps with little platform-specific functionality.</span></span> <span data-ttu-id="93286-174">これらを使用して、iOS、Android、および Windows で実行されるネイティブの XAML ベース UI を 1 つ構築できます。</span><span class="sxs-lookup"><span data-stu-id="93286-174">You can use them to build one native XAML-based UI that runs on iOS, Android, and Windows.</span></span> <span data-ttu-id="93286-175">[こちら](https://www.xamarin.com/forms)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="93286-175">Learn more [here](https://www.xamarin.com/forms).</span></span>

<span data-ttu-id="93286-176">次に、Android、iOS、またはクロスプラットフォーム プロジェクトから、クラス ライブラリ プロジェクトの参照を追加します。</span><span class="sxs-lookup"><span data-stu-id="93286-176">Then, from your Android, iOS, or cross-platform project, add a reference the class library project.</span></span>

![クラス ライブラリ参照](images/desktop-to-uwp/class-library-reference3.png)

### <a name="build-your-pages"></a><span data-ttu-id="93286-178">ページをビルドする</span><span class="sxs-lookup"><span data-stu-id="93286-178">Build your pages</span></span>

<span data-ttu-id="93286-179">この例では、Android アプリに顧客の一覧が示されます。</span><span class="sxs-lookup"><span data-stu-id="93286-179">Our example shows a list of customers in an Android app.</span></span>

![Android アプリ](images/desktop-to-uwp/android-app.png)

```xml
<?xml version="1.0" encoding="utf-8"?>
<TextView xmlns:android="http://schemas.android.com/apk/res/android"
    android:layout_width="fill_parent"
    android:layout_height="fill_parent"
    android:padding="10dp" android:textSize="16sp"
    android:id="@android:id/list">
</TextView>
```

```csharp
[Activity(Label = "MyAndroidApp", MainLauncher = true)]
public class MainActivity : ListActivity
{
    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        SqlClientFactory factory = SqlClientFactory.Instance;

        var customers = (string[])Northwind.GetCustomerNames(factory).ToArray(typeof(string));

        ListAdapter = new ArrayAdapter<string>(this, Resource.Layout.list_item, customers);
    }
}
```

<span data-ttu-id="93286-181">Android プロジェクト、iOS プロジェクト、およびクロスプラットフォーム プロジェクトの概要については、[Xamarin 開発者ポータル](https://developer.xamarin.com/)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="93286-181">To get started with Android, iOS, and cross-platform projects, see the [Xamarin developer portal](https://developer.xamarin.com/).</span></span>

## <a name="next-steps"></a><span data-ttu-id="93286-182">次のステップ</span><span class="sxs-lookup"><span data-stu-id="93286-182">Next steps</span></span>

**<span data-ttu-id="93286-183">質問に対する回答を見つける</span><span class="sxs-lookup"><span data-stu-id="93286-183">Find answers to your questions</span></span>**

<span data-ttu-id="93286-184">ご質問がある場合は、</span><span class="sxs-lookup"><span data-stu-id="93286-184">Have questions?</span></span> <span data-ttu-id="93286-185">Stack Overflow でお問い合わせください。</span><span class="sxs-lookup"><span data-stu-id="93286-185">Ask us on Stack Overflow.</span></span> <span data-ttu-id="93286-186">Microsoft のチームでは、これらの[タグ](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge)をチェックしています。</span><span class="sxs-lookup"><span data-stu-id="93286-186">Our team monitors these [tags](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge).</span></span> <span data-ttu-id="93286-187">[こちら](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D)から質問することもできます。</span><span class="sxs-lookup"><span data-stu-id="93286-187">You can also ask us [here](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D).</span></span>

**<span data-ttu-id="93286-188">フィードバックの提供または機能の提案を行う</span><span class="sxs-lookup"><span data-stu-id="93286-188">Give feedback or make feature suggestions</span></span>**

<span data-ttu-id="93286-189">[UserVoice](https://wpdev.uservoice.com/forums/110705-universal-windows-platform/category/161895-desktop-bridge-centennial) のページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="93286-189">See [UserVoice](https://wpdev.uservoice.com/forums/110705-universal-windows-platform/category/161895-desktop-bridge-centennial).</span></span>
