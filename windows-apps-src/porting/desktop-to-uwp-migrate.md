---
author: normesta
Description: Share code between a desktop application and a UWP app
Search.Product: eADQiWindows 10XVcnh
title: デスクトップ アプリケーションと UWP アプリの間でコードを共有します。
ms.author: normesta
ms.date: 10/03/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 4a4eda15a18a441da2e06db17aaf7bea3d1842d1
ms.sourcegitcommit: 71e8eae5c077a7740e5606298951bb78fc42b22c
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/13/2018
ms.locfileid: "6658048"
---
# <a name="share-code-between-a-desktop-application-and-a-uwp-app"></a><span data-ttu-id="f8a10-103">デスクトップ アプリケーションと UWP アプリの間でコードを共有します。</span><span class="sxs-lookup"><span data-stu-id="f8a10-103">Share code between a desktop application and a UWP app</span></span>

<span data-ttu-id="f8a10-104">お持ちのコードを .NET Standard ライブラリに移行し、ユニバーサル Windows プラットフォーム (UWP) アプリを作成すると、すべての Windows 10 デバイスをターゲットにすることができます。</span><span class="sxs-lookup"><span data-stu-id="f8a10-104">You can move your code into .NET Standard libraries, and then create a Universal Windows Platform (UWP) app to reach all Windows 10 devices.</span></span> <span data-ttu-id="f8a10-105">デスクトップ アプリケーションを UWP アプリに変換できるツールはありませんが、多くの既存コードを再利用できるため、UWP アプリの作成コストを削減できます。</span><span class="sxs-lookup"><span data-stu-id="f8a10-105">While there's no tool that can convert a desktop application to a UWP app, you can reuse a lot of your existing code and that lowers the cost of building one.</span></span> <span data-ttu-id="f8a10-106">このガイドでは、その方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="f8a10-106">This guide shows you how to do that.</span></span>

## <a name="share-code-in-a-net-standard-20-library"></a><span data-ttu-id="f8a10-107">.NET Standard 2.0 ライブラリでコードを共有する</span><span class="sxs-lookup"><span data-stu-id="f8a10-107">Share code in a .NET Standard 2.0 library</span></span>

<span data-ttu-id="f8a10-108">できる限り多くのコードを .NET Standard 2.0 クラス ライブラリに配置してください。</span><span class="sxs-lookup"><span data-stu-id="f8a10-108">Place as much code as you can into .NET Standard 2.0 class libraries.</span></span>  <span data-ttu-id="f8a10-109">標準で定義されている API を使用しているコードは、UWP アプリで再利用できます。</span><span class="sxs-lookup"><span data-stu-id="f8a10-109">As long as your code uses APIs that are defined in the standard, you can reuse it in a UWP app.</span></span> <span data-ttu-id="f8a10-110">.NET Standard 2.0 に含まれる API が大幅に増えたため、.NET Standard ライブラリでのコード共有は、従来よりずっと簡単になっています。</span><span class="sxs-lookup"><span data-stu-id="f8a10-110">It's easier than it's ever been to share code in a .NET Standard library because so many more APIs are included in the .NET Standard 2.0.</span></span>

<span data-ttu-id="f8a10-111">詳しい解説は、こちらのビデオでご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f8a10-111">Here's a great video that tells you more about it.</span></span>
<span data-ttu-id="f8a10-112">&nbsp;</span><span class="sxs-lookup"><span data-stu-id="f8a10-112">&nbsp;</span></span>
> [!VIDEO https://www.youtube.com/embed/YI4MurjfMn8]

### <a name="add-net-standard-libraries"></a><span data-ttu-id="f8a10-113">.NET Standard ライブラリを追加する</span><span class="sxs-lookup"><span data-stu-id="f8a10-113">Add .NET Standard libraries</span></span>

<span data-ttu-id="f8a10-114">まず、1 つ以上の .NET Standard クラス ライブラリをソリューションに追加します。</span><span class="sxs-lookup"><span data-stu-id="f8a10-114">First, add one or more .NET Standard class libraries to your solution.</span></span>  

![.NET Standard プロジェクトの追加](images/desktop-to-uwp/dot-net-standard-project-template.png)

<span data-ttu-id="f8a10-116">ソリューションに追加するライブラリの数は、計画しているコード編成によって異なります。</span><span class="sxs-lookup"><span data-stu-id="f8a10-116">The number of libraries that you add to your solution depends on how you plan to organize your code.</span></span>

<span data-ttu-id="f8a10-117">各クラス ライブラリのターゲットが **.NET Standard 2.0** になっていることを確認してください。</span><span class="sxs-lookup"><span data-stu-id="f8a10-117">Make sure that each class library targets the **.NET Standard 2.0**.</span></span>

![.NET Standard 2.0 をターゲットにする](images/desktop-to-uwp/target-standard-20.png)

<span data-ttu-id="f8a10-119">この設定には、クラス ライブラリ プロジェクトのプロパティ ページからアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="f8a10-119">You can find this setting in the property pages of the class library project.</span></span>

<span data-ttu-id="f8a10-120">デスクトップ アプリケーション プロジェクトから、クラス ライブラリ プロジェクトへの参照を追加します。</span><span class="sxs-lookup"><span data-stu-id="f8a10-120">From your desktop application project, add a reference to the class library project.</span></span>

![クラス ライブラリ参照](images/desktop-to-uwp/class-library-reference.png)

<span data-ttu-id="f8a10-122">次に、ツールを使用して、どの程度のコードが標準に準拠しているか調べます。</span><span class="sxs-lookup"><span data-stu-id="f8a10-122">Next, use tools to determine how much of your code conforms to the standard.</span></span> <span data-ttu-id="f8a10-123">これにより、コードをライブラリに移行する前に、どの部分を再利用でき、どの部分で最小限の変更が必要になり、どの部分がアプリケーション固有にしておくのかを決定できます。</span><span class="sxs-lookup"><span data-stu-id="f8a10-123">That way, before you move code into the library, you can decide which parts you can reuse, which parts require minimal modification, and which parts will remain application-specific.</span></span>

### <a name="check-library-and-code-compatibility"></a><span data-ttu-id="f8a10-124">ライブラリとコードの互換性を確認する</span><span class="sxs-lookup"><span data-stu-id="f8a10-124">Check library and code compatibility</span></span>

<span data-ttu-id="f8a10-125">まず Nuget パッケージと、サード パーティから取得したその他の dll ファイルから始めます。</span><span class="sxs-lookup"><span data-stu-id="f8a10-125">We'll start with Nuget Packages and other dll files that you obtained from a third party.</span></span>

<span data-ttu-id="f8a10-126">アプリケーションでこれらを使用する場合は、.NET Standard 2.0 と互換性があるかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="f8a10-126">If your application uses any of them, determine if they are compatible with the .NET Standard 2.0.</span></span> <span data-ttu-id="f8a10-127">そのためには、Visual Studio 拡張機能またはコマンド ライン ユーティリティを使用できます。</span><span class="sxs-lookup"><span data-stu-id="f8a10-127">You can use a Visual Studio extension or a command-line utility to do that.</span></span>

<span data-ttu-id="f8a10-128">これらの同じツールを使用して、コードを分析します。</span><span class="sxs-lookup"><span data-stu-id="f8a10-128">Use these same tools to analyze your code.</span></span> <span data-ttu-id="f8a10-129">ここでツール ([dotnet apiport](https://github.com/Microsoft/dotnet-apiport/releases)) をダウンロードし、使用方法に関するビデオをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f8a10-129">Download the tools here ([dotnet-apiport](https://github.com/Microsoft/dotnet-apiport/releases)) and then watch this video to learn how to use them.</span></span>
<span data-ttu-id="f8a10-130">&nbsp;</span><span class="sxs-lookup"><span data-stu-id="f8a10-130">&nbsp;</span></span>
> [!VIDEO https://www.youtube.com/embed/rzs_FGPyAlY]

<span data-ttu-id="f8a10-131">コードに標準との互換性がない場合は、そのコードを実装するための他の方法を検討してください。</span><span class="sxs-lookup"><span data-stu-id="f8a10-131">If your code isn't compatible with the standard, consider other ways that you could implement that code.</span></span> <span data-ttu-id="f8a10-132">まず [.NET API ブラウザー](https://docs.microsoft.com/dotnet/api/?view=netstandard-2.0)を開きます。</span><span class="sxs-lookup"><span data-stu-id="f8a10-132">Start by opening the [.NET API Browser](https://docs.microsoft.com/dotnet/api/?view=netstandard-2.0).</span></span> <span data-ttu-id="f8a10-133">このブラウザーを使用して、.NET Standard 2.0 に含まれている API を確認します。</span><span class="sxs-lookup"><span data-stu-id="f8a10-133">You can use that browser to review the API's that are available in the .NET Standard 2.0.</span></span> <span data-ttu-id="f8a10-134">一覧の範囲として .NET Standard 2.0 を指定してください。</span><span class="sxs-lookup"><span data-stu-id="f8a10-134">Make sure to scope the list to the .NET Standard 2.0.</span></span>

![.NET オプション](images/desktop-to-uwp/dot-net-option.png)

<span data-ttu-id="f8a10-136">コードの一部はプラットフォーム固有でありデスクトップ アプリケーション プロジェクト内に残す必要があります。</span><span class="sxs-lookup"><span data-stu-id="f8a10-136">Some of your code will be platform-specific and will need to remain in your desktop application project.</span></span>

### <a name="example-migrating-data-access-code-to-a-net-standard-20-library"></a><span data-ttu-id="f8a10-137">例: .NET Standard 2.0 ライブラリにデータ アクセス コードを移行する</span><span class="sxs-lookup"><span data-stu-id="f8a10-137">Example: Migrating data access code to a .NET Standard 2.0 library</span></span>

<span data-ttu-id="f8a10-138">Northwind サンプル データベースから顧客を表示する非常に基本的な Windows フォーム アプリケーションがあると仮定します。</span><span class="sxs-lookup"><span data-stu-id="f8a10-138">Let's assume that we have a very basic Windows Forms application that shows customers from our Northwind sample database.</span></span>

![Windows フォーム アプリ](images/desktop-to-uwp/win-forms-app.png)

<span data-ttu-id="f8a10-140">このプロジェクトには、.NET Standard 2.0 クラス ライブラリおよび **Northwind** という静的クラスが含まれています。</span><span class="sxs-lookup"><span data-stu-id="f8a10-140">The project contains a .NET Standard 2.0 class library with a static class named **Northwind**.</span></span> <span data-ttu-id="f8a10-141">このコードでは ``SQLConnection`` クラス、``SqlCommand`` クラス、``SqlDataReader`` クラスが使用されており、これらのクラスが .NET Standard 2.0 にないため、**Northwind** クラスに移行してもコンパイルできません。</span><span class="sxs-lookup"><span data-stu-id="f8a10-141">If we move this code into the **Northwind** class, it won't compile because it uses the ``SQLConnection``, ``SqlCommand``, and ``SqlDataReader`` classes, and those classes that are not available in the .NET Standard 2.0.</span></span>

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
<span data-ttu-id="f8a10-142">ただし、[.NET API ブラウザー](https://docs.microsoft.com/dotnet/api/?view=netstandard-2.0)を使用して代わりのクラスを見つけることができます。</span><span class="sxs-lookup"><span data-stu-id="f8a10-142">We can use the [.NET API Browser](https://docs.microsoft.com/dotnet/api/?view=netstandard-2.0) to find an alternative though.</span></span> <span data-ttu-id="f8a10-143">``DbConnection``、``DbCommand``、``DbDataReader`` の各クラスはすべて .NET Standard 2.0 で利用可能であるため、それらを代わりに使用することができます。</span><span class="sxs-lookup"><span data-stu-id="f8a10-143">The ``DbConnection``, ``DbCommand``, and ``DbDataReader`` classes are all available in the .NET Standard 2.0 so we can use them instead.</span></span>  

<span data-ttu-id="f8a10-144">この改訂バージョンではこれらのクラスを使用して顧客の一覧を取得しますが、``DbConnection`` クラスを作成するには、クライアント アプリケーションで作成するファクトリ オブジェクトを渡す必要があります。</span><span class="sxs-lookup"><span data-stu-id="f8a10-144">This revised version uses those classes to get a list of customers, but to create a ``DbConnection`` class, we'll need to pass in a factory object that we create in the client application.</span></span>

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

<span data-ttu-id="f8a10-145">Windows フォームの分離コード ページでは、ファクトリ インスタンスを作成しメソッドに渡すことができます。</span><span class="sxs-lookup"><span data-stu-id="f8a10-145">In the code-behind page of the Windows Form, we can just create factory instance and pass it into our method.</span></span>

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

## <a name="reach-all-windows-devices"></a><span data-ttu-id="f8a10-146">すべての Windows デバイスにリーチ</span><span class="sxs-lookup"><span data-stu-id="f8a10-146">Reach all Windows devices</span></span>

<span data-ttu-id="f8a10-147">これで、ソリューションに UWP アプリを追加する準備ができました。</span><span class="sxs-lookup"><span data-stu-id="f8a10-147">Now you're ready to add a UWP app to your solution.</span></span>

![Desktop to UWP Bridge のイメージ](images/desktop-to-uwp/adaptive-ui.png)

<span data-ttu-id="f8a10-149">UI ページは XAML で設計し、デバイス固有またはプラットフォーム固有のコードも記述する必要がありますが、完了すると、すべての Windows 10 デバイスをターゲットにすることができます。アプリ ページはさまざまな画面サイズや解像度に合わせて調整されるモダンな使用感になります。</span><span class="sxs-lookup"><span data-stu-id="f8a10-149">You'll still have to design UI pages in XAML and write any device or platform-specific code, but when you are done, you'll be able to reach the full breadth of Windows 10 devices and your app pages will have a modern feel that adapts well to different screen sizes and resolutions.</span></span>

<span data-ttu-id="f8a10-150">アプリはキーボードとマウスだけではなく、他の入力メカニズムにも応答し、さまざまなデバイスで直感的に機能や設定を使用できます。</span><span class="sxs-lookup"><span data-stu-id="f8a10-150">Your app will respond to input mechanisms other than just a keyboard and mouse, and features and settings will be intuitive across devices.</span></span> <span data-ttu-id="f8a10-151">つまり、ユーザーが操作方法を 1 回だけ学習すると、デバイスに関係なく慣れた方法で操作できます。</span><span class="sxs-lookup"><span data-stu-id="f8a10-151">This means that users learn how to do things one time, and then it works in a very familiar way no matter the device.</span></span>

<span data-ttu-id="f8a10-152">これらは、UWP による利点のごく一部です。</span><span class="sxs-lookup"><span data-stu-id="f8a10-152">These are just a few of the goodies that come with UWP.</span></span> <span data-ttu-id="f8a10-153">詳しくは、「[Windowsで優れたエクスペリエンスを実現](https://developer.microsoft.com/windows/why-build-for-uwp)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f8a10-153">To learn more, see [Build great experiences with Windows](https://developer.microsoft.com/windows/why-build-for-uwp).</span></span>

### <a name="add-a-uwp-project"></a><span data-ttu-id="f8a10-154">UWP プロジェクトを追加する</span><span class="sxs-lookup"><span data-stu-id="f8a10-154">Add a UWP project</span></span>

<span data-ttu-id="f8a10-155">まず、UWP プロジェクトをソリューションに追加します。</span><span class="sxs-lookup"><span data-stu-id="f8a10-155">First, add a UWP project to your solution.</span></span>

![UWP プロジェクト](images/desktop-to-uwp/new-uwp-app.png)

<span data-ttu-id="f8a10-157">次に、UWP プロジェクトから、.NET Standard 2.0 ライブラリ プロジェクトへの参照を追加します。</span><span class="sxs-lookup"><span data-stu-id="f8a10-157">Then, from your UWP project, add a reference the .NET Standard 2.0 library project.</span></span>

![クラス ライブラリ参照](images/desktop-to-uwp/class-library-reference2.png)

### <a name="build-your-pages"></a><span data-ttu-id="f8a10-159">ページをビルドする</span><span class="sxs-lookup"><span data-stu-id="f8a10-159">Build your pages</span></span>

<span data-ttu-id="f8a10-160">XAML ページを追加し、.NET Standard 2.0 ライブラリ内のコードを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="f8a10-160">Add XAML pages and call the code in your .NET Standard 2.0 library.</span></span>

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


<span data-ttu-id="f8a10-162">UWP を使い始めるには、「[UWP アプリとは](https://docs.microsoft.com/windows/uwp/get-started/universal-application-platform-guide)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f8a10-162">To get started with UWP, see [What's a UWP app](https://docs.microsoft.com/windows/uwp/get-started/universal-application-platform-guide).</span></span>

## <a name="reach-ios-and-android-devices"></a><span data-ttu-id="f8a10-163">iOS および Android デバイスへのリーチ</span><span class="sxs-lookup"><span data-stu-id="f8a10-163">Reach iOS and Android devices</span></span>

<span data-ttu-id="f8a10-164">Xamarin プロジェクトを追加することにより、Android デバイスと iOS デバイスをターゲットにすることができます。</span><span class="sxs-lookup"><span data-stu-id="f8a10-164">You can reach Android and iOS devices by adding Xamarin projects.</span></span>  

![Xamarin アプリ](images/desktop-to-uwp/xamarin-apps.png)

<span data-ttu-id="f8a10-166">これらのプロジェクトでは、C# でプラットフォーム固有およびデバイスに固有の API へのフル アクセスを使用して、Android アプリと iOS アプリを構築できます。</span><span class="sxs-lookup"><span data-stu-id="f8a10-166">These projects let you use C# to build Android and iOS apps with full access to platform-specific and device-specific APIs.</span></span> <span data-ttu-id="f8a10-167">これらのアプリはプラットフォーム固有のハードウェア アクセラレーションを利用し、ネイティブ パフォーマンス用にコンパイルできます。</span><span class="sxs-lookup"><span data-stu-id="f8a10-167">These apps leverage platform-specific hardware acceleration, and are compiled for native performance.</span></span>

<span data-ttu-id="f8a10-168">これらのアプリでは、iBeacons や Android フラグメントなどのプラットフォーム固有機能を含めて、基盤となるプラットフォームおよびデバイスによって公開される機能に全面的にアクセスできます。標準のネイティブ ユーザー インターフェイス コントロールを使用すると、ユーザーが期待する外観と操作感の UI を構築できます。</span><span class="sxs-lookup"><span data-stu-id="f8a10-168">They have access to the full spectrum of functionality exposed by the underlying platform and device, including platform-specific capabilities like iBeacons and Android Fragments and you'll use standard native user interface controls to build UIs that look and feel the way that users expect them to.</span></span>

<span data-ttu-id="f8a10-169">UWP の場合と同様、.NET Standard 2.0 クラス ライブラリに用意されているビジネス ロジックを再利用できるため、Android アプリまたは iOS アプリを追加するコストが低くなります。</span><span class="sxs-lookup"><span data-stu-id="f8a10-169">Just like UWPs, the cost to add an Android or iOS app is lower because you can reuse business logic in a .NET Standard 2.0 class library.</span></span> <span data-ttu-id="f8a10-170">UI ページは XAML で設計し、デバイス固有またはプラットフォーム固有のコードを記述する必要があります。</span><span class="sxs-lookup"><span data-stu-id="f8a10-170">You'll have to design your UI pages in XAML and write any device or platform-specific code.</span></span>

### <a name="add-a-xamarin-project"></a><span data-ttu-id="f8a10-171">Xamarin プロジェクトを追加する</span><span class="sxs-lookup"><span data-stu-id="f8a10-171">Add a Xamarin project</span></span>

<span data-ttu-id="f8a10-172">まず、**Android**、**iOS**、または**クロス プラットフォーム**のプロジェクトをソリューションに追加します。</span><span class="sxs-lookup"><span data-stu-id="f8a10-172">First, add an **Android**, **iOS**, or **Cross-Platform** project to your solution.</span></span>

<span data-ttu-id="f8a10-173">これらのテンプレートは、**[新しいプロジェクトの追加]** ダイアログ ボックスの **[Visual C#]** グループにあります。</span><span class="sxs-lookup"><span data-stu-id="f8a10-173">You can find these templates in the **Add New Project** dialog box under the **Visual C#** group.</span></span>

![Xamarin アプリ](images/desktop-to-uwp/xamarin-projects.png)

>[!NOTE]
><span data-ttu-id="f8a10-175">クロスプラット フォーム プロジェクトは、プラットフォーム固有の機能がほとんどないアプリに最適です。</span><span class="sxs-lookup"><span data-stu-id="f8a10-175">Cross-platform projects are great for apps with little platform-specific functionality.</span></span> <span data-ttu-id="f8a10-176">これらを使用して、iOS、Android、および Windows で実行されるネイティブの XAML ベース UI を 1 つ構築できます。</span><span class="sxs-lookup"><span data-stu-id="f8a10-176">You can use them to build one native XAML-based UI that runs on iOS, Android, and Windows.</span></span> <span data-ttu-id="f8a10-177">[こちら](https://www.xamarin.com/forms)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f8a10-177">Learn more [here](https://www.xamarin.com/forms).</span></span>

<span data-ttu-id="f8a10-178">次に、Android、iOS、またはクロスプラットフォーム プロジェクトから、クラス ライブラリ プロジェクトの参照を追加します。</span><span class="sxs-lookup"><span data-stu-id="f8a10-178">Then, from your Android, iOS, or cross-platform project, add a reference the class library project.</span></span>

![クラス ライブラリ参照](images/desktop-to-uwp/class-library-reference3.png)

### <a name="build-your-pages"></a><span data-ttu-id="f8a10-180">ページをビルドする</span><span class="sxs-lookup"><span data-stu-id="f8a10-180">Build your pages</span></span>

<span data-ttu-id="f8a10-181">この例では、Android アプリに顧客の一覧が示されます。</span><span class="sxs-lookup"><span data-stu-id="f8a10-181">Our example shows a list of customers in an Android app.</span></span>

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

<span data-ttu-id="f8a10-183">Android プロジェクト、iOS プロジェクト、およびクロスプラットフォーム プロジェクトの概要については、[Xamarin 開発者ポータル](https://developer.xamarin.com/)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f8a10-183">To get started with Android, iOS, and cross-platform projects, see the [Xamarin developer portal](https://developer.xamarin.com/).</span></span>

## <a name="next-steps"></a><span data-ttu-id="f8a10-184">次のステップ</span><span class="sxs-lookup"><span data-stu-id="f8a10-184">Next steps</span></span>

**<span data-ttu-id="f8a10-185">質問に対する回答を見つける</span><span class="sxs-lookup"><span data-stu-id="f8a10-185">Find answers to your questions</span></span>**

<span data-ttu-id="f8a10-186">ご質問がある場合は、</span><span class="sxs-lookup"><span data-stu-id="f8a10-186">Have questions?</span></span> <span data-ttu-id="f8a10-187">Stack Overflow でお問い合わせください。</span><span class="sxs-lookup"><span data-stu-id="f8a10-187">Ask us on Stack Overflow.</span></span> <span data-ttu-id="f8a10-188">Microsoft のチームでは、これらの[タグ](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge)をチェックしています。</span><span class="sxs-lookup"><span data-stu-id="f8a10-188">Our team monitors these [tags](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge).</span></span> <span data-ttu-id="f8a10-189">[こちら](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D)から質問することもできます。</span><span class="sxs-lookup"><span data-stu-id="f8a10-189">You can also ask us [here](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D).</span></span>

**<span data-ttu-id="f8a10-190">フィードバックの提供または機能の提案を行う</span><span class="sxs-lookup"><span data-stu-id="f8a10-190">Give feedback or make feature suggestions</span></span>**

<span data-ttu-id="f8a10-191">[UserVoice](https://wpdev.uservoice.com/forums/110705-universal-windows-platform/category/161895-desktop-bridge-centennial) のページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f8a10-191">See [UserVoice](https://wpdev.uservoice.com/forums/110705-universal-windows-platform/category/161895-desktop-bridge-centennial).</span></span>
