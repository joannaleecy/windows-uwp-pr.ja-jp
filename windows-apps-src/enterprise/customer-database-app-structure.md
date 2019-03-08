---
title: 顧客データベース アプリケーション構造
description: 顧客データベース チュートリアルでは、構造を確認およびその理由は方法が構築されます。
keywords: enterprise、チュートリアル、顧客、データ、crud
ms.date: 05/07/2018
ms.topic: article
ms.localizationpriority: med
ms.openlocfilehash: b1f8f8c8a2fd1522d8c304a45514d5257543f222
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57656617"
---
# <a name="customer-database-app-structure"></a><span data-ttu-id="6b731-104">顧客データベース アプリケーション構造</span><span class="sxs-lookup"><span data-stu-id="6b731-104">Customer database app structure</span></span>

<span data-ttu-id="6b731-105">複雑な基幹業務アプリ多くの場合がある多くのページと機能、優れたコードの行数。</span><span class="sxs-lookup"><span data-stu-id="6b731-105">Complex line-of-business apps often have many pages and features and a great many lines of code.</span></span> <span data-ttu-id="6b731-106">このため、これが重要予測可能な構造を軸のアプリを設計することです。</span><span class="sxs-lookup"><span data-stu-id="6b731-106">Because of this, it's of vital importance that you design your app around a predictable structure.</span></span> <span data-ttu-id="6b731-107">エンタープライズのアプリに適したアプリケーション設計パターンをいくつかありますが、すべて大規模なアプリケーションを簡単に理解し、操作の目的に構築されます。</span><span class="sxs-lookup"><span data-stu-id="6b731-107">There are several application design patterns which are suitable for enterprise apps, but they are all built around the goal of making a large-scale application easier to understand and work with.</span></span>

<span data-ttu-id="6b731-108">中に、[顧客データベース チュートリアル](customer-database-tutorial.md)シングル ページ アプリを表示します。 わかりやすくするために、アクションでは、この考え方を紹介するモデル-ビュー-ビューモデル (MVVM) アプリの設計パターンを実装します。</span><span class="sxs-lookup"><span data-stu-id="6b731-108">While the [Customer database tutorial](customer-database-tutorial.md) presents a single-page app for simplicity's sake, it implements the Model-View-ViewModel (MVVM) app design pattern to showcase these ideas in action.</span></span> <span data-ttu-id="6b731-109">名前が示すように、MVVM デザイン パターンは、3 つのカテゴリにコア アプリケーション ロジックを分離します。</span><span class="sxs-lookup"><span data-stu-id="6b731-109">As the name implies, the MVVM design pattern separates the core app logic into three categories:</span></span>

* <span data-ttu-id="6b731-110">モデルは、アプリケーションのデータを含むクラスです。</span><span class="sxs-lookup"><span data-stu-id="6b731-110">Models are the classes that contain the application's data.</span></span>
* <span data-ttu-id="6b731-111">ビューは、指定されたページの UI です。</span><span class="sxs-lookup"><span data-stu-id="6b731-111">Views are the UI of any given page.</span></span>
* <span data-ttu-id="6b731-112">Viewmodel は、アプリケーション ロジックを提供します。</span><span class="sxs-lookup"><span data-stu-id="6b731-112">ViewModels provide the application logic.</span></span> <span data-ttu-id="6b731-113">これは、ビューからユーザーのアクションの処理やモデルとの対話の管理に含めることができます。</span><span class="sxs-lookup"><span data-stu-id="6b731-113">This can include handling user actions from the View and/or managing interactions with the Models.</span></span>

<span data-ttu-id="6b731-114">このアプリは MVVM の完全なと architypical の例ではありませんは、主な懸念事項の分離の原則をアクションに表示します。</span><span class="sxs-lookup"><span data-stu-id="6b731-114">While this app isn't a perfect and architypical example of MVVM, it does show the main principles of separation of concerns in action.</span></span> [<span data-ttu-id="6b731-115">ここで、アプリを確認します。</span><span class="sxs-lookup"><span data-stu-id="6b731-115">Check out the app here.</span></span>](https://github.com/Microsoft/windows-tutorials-customer-database)

## <a name="application-structure"></a><span data-ttu-id="6b731-116">アプリケーションの構造</span><span class="sxs-lookup"><span data-stu-id="6b731-116">Application structure</span></span>

<span data-ttu-id="6b731-117">アプリを開いた後の起動を調べることで、**ソリューション エクスプ ローラー。**</span><span class="sxs-lookup"><span data-stu-id="6b731-117">After you open the app, start by examining the **Solution Explorer.**</span></span> <span data-ttu-id="6b731-118">表示する前に、UWP アプリで作業したことがある場合に使い慣れたありますが、フォルダーのコレクションを確認しますの一部を保持するアプリのコンポーネント部分。</span><span class="sxs-lookup"><span data-stu-id="6b731-118">Some of what you see there should be familiar if you've worked with a UWP app before, but you'll also see a collection of folders that hold the app's component parts.</span></span>

![アプリのソリューション エクスプ ローラーでの開始点](images/customer-database-tutorial/solution-explorer.png)

### <a name="views"></a><span data-ttu-id="6b731-120">ビュー</span><span class="sxs-lookup"><span data-stu-id="6b731-120">Views</span></span>

<span data-ttu-id="6b731-121">すべてのアプリの UI は、ビュー フォルダーで定義されます。</span><span class="sxs-lookup"><span data-stu-id="6b731-121">All the app's UI is defined in the Views folder.</span></span> <span data-ttu-id="6b731-122">このチュートリアルでは、シングル ページ アプリを今すぐはであるために、- 1 つのビューがあるつまり**CustomerListPage**します。</span><span class="sxs-lookup"><span data-stu-id="6b731-122">Because our tutorial is a single-page app right now, this means there's only one view - **CustomerListPage**.</span></span> <span data-ttu-id="6b731-123">XAML UI のマークアップと xaml.cs コード分離の両方があります: これら 2 つのファイルが 1 つのビューを構成します。</span><span class="sxs-lookup"><span data-stu-id="6b731-123">It has both XAML UI markup and xaml.cs code-behind - these two files make up one View.</span></span> <span data-ttu-id="6b731-124">UI 要素を追加する**CustomerListPage.xaml**します。</span><span class="sxs-lookup"><span data-stu-id="6b731-124">You'll be adding UI elements to **CustomerListPage.xaml**.</span></span>

> [!NOTE]
> <span data-ttu-id="6b731-125">このアプリで、MainPage がないことに注意してください可能性があります。</span><span class="sxs-lookup"><span data-stu-id="6b731-125">You might notice that this app doesn't have a MainPage.</span></span> <span data-ttu-id="6b731-126">指定しますだ**App.xaml.cs**アプリを起動する必要があります**CustomerListPage**を起動するとします。</span><span class="sxs-lookup"><span data-stu-id="6b731-126">That's because we specify in **App.xaml.cs** that the app should launch **CustomerListPage** upon launching.</span></span>

### <a name="viewmodels"></a><span data-ttu-id="6b731-127">ビューモデル</span><span class="sxs-lookup"><span data-stu-id="6b731-127">ViewModels</span></span>

<span data-ttu-id="6b731-128">このアプリには、1 つのビューはのみが 2 つのビューモデルが。</span><span class="sxs-lookup"><span data-stu-id="6b731-128">Though this app only has one View, is has two ViewModels.</span></span> <span data-ttu-id="6b731-129">それはなぜか。</span><span class="sxs-lookup"><span data-stu-id="6b731-129">Why is this?</span></span>

<span data-ttu-id="6b731-130">**CustomerListPageViewModel.cs** MVVM パターンで標準的な ViewModel が。</span><span class="sxs-lookup"><span data-stu-id="6b731-130">**CustomerListPageViewModel.cs** is a standard ViewModel in the MVVM pattern.</span></span> <span data-ttu-id="6b731-131">アプリのページの基本的なロジックがあるあり、ページ操作する、チュートリアルでは、ほとんどをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="6b731-131">It's where the fundamental logic of the app's page is located, and the page you'll be working with the most in the tutorial.</span></span> <span data-ttu-id="6b731-132">ユーザーが行うすべての UI アクションは、表示を使用して処理するためには、このビューモデルに渡されます。</span><span class="sxs-lookup"><span data-stu-id="6b731-132">Every UI action taken by the user is passed through the View to this ViewModel for processing.</span></span>

<span data-ttu-id="6b731-133">**CustomerViewModel.cs**、ただし、特定の任意のビューに関連付けられていません。</span><span class="sxs-lookup"><span data-stu-id="6b731-133">**CustomerViewModel.cs**, however, isn't associated with any specific View.</span></span> <span data-ttu-id="6b731-134">代わりに、個々 の顧客のモデルに含まれるデータ (プロパティを編集した) プログラムの概念を関連付けます。</span><span class="sxs-lookup"><span data-stu-id="6b731-134">Instead, it associates a programmatic concept (which properties have been edited) with the data contained in an individual customer's Model.</span></span>

### <a name="models"></a><span data-ttu-id="6b731-135">モデル</span><span class="sxs-lookup"><span data-stu-id="6b731-135">Models</span></span>

<span data-ttu-id="6b731-136">このアプリには、アプリのデータを格納し、リポジトリと対話するためのインターフェイスを提供する 3 つのモデルが含まれています。</span><span class="sxs-lookup"><span data-stu-id="6b731-136">This app contains three Models, which store the app's data and provide interfaces for interacting with the repository.</span></span> <span data-ttu-id="6b731-137">これらは、アプリの重要な部分が、このチュートリアルで直接編集することはありません。</span><span class="sxs-lookup"><span data-stu-id="6b731-137">While these are critical parts of the app, they aren't something that you'll be directly editing in the tutorial.</span></span>

<span data-ttu-id="6b731-138">最も重要なは**Customer.cs**チュートリアルで使用する顧客のデータ構造をについて説明します。</span><span class="sxs-lookup"><span data-stu-id="6b731-138">Most important is **Customer.cs**, which describes the Customer data structure which you'll be using in the tutorial.</span></span>

> [!NOTE]
> <span data-ttu-id="6b731-139">このチュートリアルでは無視されます、*電子メール*と*Phone* Customer オブジェクトのプロパティ。</span><span class="sxs-lookup"><span data-stu-id="6b731-139">The tutorial ignores the *Email* and *Phone* properties of the Customer object.</span></span> <span data-ttu-id="6b731-140">超える場合提示された内容ここでは、アプリの UI にこれら 2 つのプロパティを追加することが優れた第一歩です。</span><span class="sxs-lookup"><span data-stu-id="6b731-140">If you want to go beyond what's presented here, adding these two properties into the UI of the app is a good first step.</span></span>

### <a name="repository"></a><span data-ttu-id="6b731-141">リポジトリ</span><span class="sxs-lookup"><span data-stu-id="6b731-141">Repository</span></span>

<span data-ttu-id="6b731-142">リポジトリ フォルダーには、構築し、ローカルの SQLite データベースと対話するクラスが含まれています。</span><span class="sxs-lookup"><span data-stu-id="6b731-142">The Repository folder contains classes that construct and interact with the local SQLite database.</span></span> <span data-ttu-id="6b731-143">チュートリアルでは、SQLite データベースとして表示されます。-です。</span><span class="sxs-lookup"><span data-stu-id="6b731-143">For the tutorial, the SQLite database is presented as-is.</span></span> <span data-ttu-id="6b731-144">コードに追加するときに**CustomerListPageViewModel.cs**これらのクラスによって定義されたメソッドを呼び出すには、それらを設定するために変更を加える必要はありません。</span><span class="sxs-lookup"><span data-stu-id="6b731-144">While you'll be adding in code to **CustomerListPageViewModel.cs** to call methods defined by these classes, you won't need to make any changes in order to set them up.</span></span>

<span data-ttu-id="6b731-145">詳細については、UWP での SQLite[この記事を参照してください](../data-access/sqlite-databases.md)します。</span><span class="sxs-lookup"><span data-stu-id="6b731-145">For more information on SQLite in UWP, [see this article](../data-access/sqlite-databases.md).</span></span>

<span data-ttu-id="6b731-146">チュートリアルの「進む」セクションしようとすると、これは、リモートの残りのデータベースに接続するためのクラスを作成します。</span><span class="sxs-lookup"><span data-stu-id="6b731-146">If you try the "Going further" section of the tutorial, this is where you'll create a class to connect to the remote REST database.</span></span> <span data-ttu-id="6b731-147">実装も、 **ICustomerRepository**インターフェイスは、モデルのセクションで定義されているが、SQLite の対応するよりも大きく異なることになります。</span><span class="sxs-lookup"><span data-stu-id="6b731-147">It will also implement the **ICustomerRepository** interface defined in the Models section, but it will look very different than its SQLite counterpart.</span></span>

### <a name="other-elements"></a><span data-ttu-id="6b731-148">その他の要素</span><span class="sxs-lookup"><span data-stu-id="6b731-148">Other elements</span></span>

<span data-ttu-id="6b731-149">アプリケーションの起動の動作が定義されている UWP アプリの通常は、 **App.xaml.cs**クラス。</span><span class="sxs-lookup"><span data-stu-id="6b731-149">As is usual for UWP apps, the application launch behavior is defined in the **App.xaml.cs** class.</span></span> <span data-ttu-id="6b731-150">次のコードのほとんどは、すべての UWP アプリの既定のコードです。</span><span class="sxs-lookup"><span data-stu-id="6b731-150">Most of the code here is the default code for any UWP app.</span></span> <span data-ttu-id="6b731-151">ただし、いくつかの小さな変更を既に行いました。</span><span class="sxs-lookup"><span data-stu-id="6b731-151">But we've already made a few small changes:</span></span>

* <span data-ttu-id="6b731-152">アプリを表示することを指定しました**CustomerListPage**で起動します。</span><span class="sxs-lookup"><span data-stu-id="6b731-152">We've specified that the app should display **CustomerListPage** on launch.</span></span>
* <span data-ttu-id="6b731-153">使用してデータ ソースを保持するリポジトリ オブジェクトを作成しました。</span><span class="sxs-lookup"><span data-stu-id="6b731-153">We've created a Repository object, which will hold the data source we're using.</span></span>
* <span data-ttu-id="6b731-154">追加されました、 **SQLiteDatabase**メソッドでは、ローカル データベースを初期化し、指定されたリポジトリとして設定します。</span><span class="sxs-lookup"><span data-stu-id="6b731-154">We've added a **SQLiteDatabase** method, which initializes the local database and sets it as the specified Repository.</span></span>

<span data-ttu-id="6b731-155">「進む」セクションしようとすると、残りの部分のリポジトリ オブジェクトを初期化するために同様のメソッドを追加します。</span><span class="sxs-lookup"><span data-stu-id="6b731-155">If you try the "Going further" section, you'll add a similar method to initialize a REST Respository object.</span></span> <span data-ttu-id="6b731-156">当社の懸念事項を分離した SQLite と REST の両方の操作に対して定義されているのと同じインターフェイスを使用しているため、SQLite の代わりに、アプリで REST を使用して変更する必要がありますのみの既存のコードになります。</span><span class="sxs-lookup"><span data-stu-id="6b731-156">Because we've separated our concerns and are using the same defined interface for both SQLite and REST operations, this will be the only existing code you'll need to change to use REST instead of SQLite in your app.</span></span>

## <a name="next-steps"></a><span data-ttu-id="6b731-157">次のステップ</span><span class="sxs-lookup"><span data-stu-id="6b731-157">Next steps</span></span>

<span data-ttu-id="6b731-158">チュートリアルでは、既に完了しているかどうかは、チェック アウトすることができます、[完全なサンプル アプリ](https://github.com/Microsoft/Windows-appsample-customers-orders-database)を大きな規模でこれらの機能を実装する方法を確認します。</span><span class="sxs-lookup"><span data-stu-id="6b731-158">If you've already completed the tutorial, then you can check out the [full sample app](https://github.com/Microsoft/Windows-appsample-customers-orders-database) to see how these features are implemented on a larger scale.</span></span>

<span data-ttu-id="6b731-159">それがなぜすべてはことがわかったら、する必要があります[のチュートリアルに戻り](customer-database-tutorial.md)だけを取り上げました構造を処理します。</span><span class="sxs-lookup"><span data-stu-id="6b731-159">Otherwise, now that you know why everything is where it is, you should [return to the tutorial](customer-database-tutorial.md) and work with the structure that we've just covered.</span></span>