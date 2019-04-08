---
ms.assetid: 08C8F359-E8B6-4A45-8F4B-8A1962F0CE38
description: Windows にとっての Microsoft Visual Studio は、iOS や Mac OS にとっての Xcode に相当します。 このチュートリアルでは、Visual Studio の使い方に慣れる訓練を行います。
title: Visual Studio でのプロジェクトの作成
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 1b6ea9fdf2e504e1ceee71658eab308751e1745c
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57601447"
---
# <a name="getting-started-creating-a-project"></a><span data-ttu-id="a5d05-105">概要: プロジェクトの作成</span><span class="sxs-lookup"><span data-stu-id="a5d05-105">Getting started: Creating a project</span></span>

## <a name="creating-a-project"></a><span data-ttu-id="a5d05-106">プロジェクトの作成</span><span class="sxs-lookup"><span data-stu-id="a5d05-106">Creating a project</span></span>

<span data-ttu-id="a5d05-107">Windows にとっての Microsoft Visual Studio は、iOS や Mac OS にとっての Xcode に相当します。</span><span class="sxs-lookup"><span data-stu-id="a5d05-107">Microsoft Visual Studio is to Windows as Xcode is to iOS and Mac OS.</span></span> <span data-ttu-id="a5d05-108">このチュートリアルでは、Visual Studio の使い方に慣れる訓練を行います。</span><span class="sxs-lookup"><span data-stu-id="a5d05-108">In this walkthrough, we help you get comfortable using Visual Studio.</span></span> <span data-ttu-id="a5d05-109">このチュートリアルを通して、開始にあたって知っておく必要がある最も基本的な事柄を確認できます。</span><span class="sxs-lookup"><span data-stu-id="a5d05-109">It shows you the absolute basics you'll need to know to get started.</span></span> <span data-ttu-id="a5d05-110">アプリを作るたびに、この手順に従うことになります。</span><span class="sxs-lookup"><span data-stu-id="a5d05-110">Each time you create an app, you'll follow steps similar to these.</span></span>

<span data-ttu-id="a5d05-111">次のビデオでは、Xcode と Visual Studio を比較しています。</span><span class="sxs-lookup"><span data-stu-id="a5d05-111">The following video compares Xcode and Visual Studio.</span></span>

> [!VIDEO https://channel9.msdn.com/Blogs/One-Dev-Minute/Comparing-Xcode-to-Visual-Studio/player]

<span data-ttu-id="a5d05-112">この [Windows 用アプリ開発ブログの記事](https://blogs.windows.com/buildingapps/2016/01/27/visual-studio-walkthrough-for-ios-developers/)も非常に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="a5d05-112">You will also find this [Building apps for Windows blog posting](https://blogs.windows.com/buildingapps/2016/01/27/visual-studio-walkthrough-for-ios-developers/) very helpful.</span></span>

<span data-ttu-id="a5d05-113">(正式には、ユニバーサル Windows プラットフォーム (UWP) アプリと呼ばれます)、Windows 10 用アプリケーションの作成はストーリー ボードを使用して iOS アプリの作成ではなくと似ています。</span><span class="sxs-lookup"><span data-stu-id="a5d05-113">Creating an app for Windows 10 (more formally referred to as a Universal Windows Platform (UWP) app) is rather like creating an iOS app using Storyboards.</span></span> <span data-ttu-id="a5d05-114">Web サイトのように、ユーザー インターフェイスの別の部分を格納している各ページ、Windows 10 アプリは複数のページにわたって多くの場合、構成されます。</span><span class="sxs-lookup"><span data-stu-id="a5d05-114">The Windows 10 app is often constructed over several pages, each page containing a different part of the user interface, like a web site.</span></span> <span data-ttu-id="a5d05-115">各ページには通常、2 つのソース ファイルが関連付けられています。1 つは [XAML の概要](https://msdn.microsoft.com/library/windows/apps/mt185595)形式のユーザー インターフェイスを格納するファイルで、もう 1 つはソース コードを記述したファイルです (多くの場合 C#)。</span><span class="sxs-lookup"><span data-stu-id="a5d05-115">Each page usually has two associated source files: one to store the user interface in [XAML overview](https://msdn.microsoft.com/library/windows/apps/mt185595) format, and one that contains the source code, often C#.</span></span> <span data-ttu-id="a5d05-116">ユーザーは、アプリとやり取りするときに、これらのページの間を移動します。</span><span class="sxs-lookup"><span data-stu-id="a5d05-116">As your user interacts with your app, they will navigate between these pages.</span></span> <span data-ttu-id="a5d05-117">このチュートリアルでは、ページを 2 つ持つアプリを作成します。</span><span class="sxs-lookup"><span data-stu-id="a5d05-117">In this walkthrough, you will create an app with two pages.</span></span>

<span data-ttu-id="a5d05-118">**注**  Windows 10 アプリの重要な機能は、同じのソース コードと同じ API セットがプラットフォームに関係なく利用可能なことです。</span><span class="sxs-lookup"><span data-stu-id="a5d05-118">**Note**  An important feature of Windows 10 apps is the fact that the same source code, and the same API set, is available to you no matter the platform.</span></span> <span data-ttu-id="a5d05-119">ご存知のように、iPhone や iPad 向けのユニバーサル iOS アプリを作っている場合、実行時にアプリを実行するプラットフォームを決定して、適切なアクションを実行できます。</span><span class="sxs-lookup"><span data-stu-id="a5d05-119">As you know, when you are writing a universal iOS app for iPhone and iPad, you can determine at run-time which platform your app is running on, and take the appropriate action.</span></span> <span data-ttu-id="a5d05-120">同様の方法で Windows 10 アプリ分かるように、実行時にで実行されているデバイス。</span><span class="sxs-lookup"><span data-stu-id="a5d05-120">In a similar way, Windows 10 apps can tell, at run-time, the device they are running on.</span></span> <span data-ttu-id="a5d05-121">UWP アプリで使用する必要はありません\#ifdef デスクトップと phone を作成するソース コードでビルドします。</span><span class="sxs-lookup"><span data-stu-id="a5d05-121">With a UWP app, there is no need to use \#ifdef's in your source code to create phone versus desktop builds.</span></span> <span data-ttu-id="a5d05-122">便利なことは、Windows 10 アプリは、デバイスによって、ユーザー インターフェイス コントロールも適切を使用しますたとえば、アプリは、日付の選択コントロールを参照できます、コントロールは自動的に検索しがかどうかによって動作が異なります。デスクトップまたは [電話] 画面で実行されています。</span><span class="sxs-lookup"><span data-stu-id="a5d05-122">Conveniently, Windows 10 apps also intelligently use their user interface controls depending on the device: for example, your app may reference a date picker control, and the control will automatically look and function differently depending on whether it's running on a desktop or a phone screen.</span></span> <span data-ttu-id="a5d05-123">ただし、ソース コードは変わりません。</span><span class="sxs-lookup"><span data-stu-id="a5d05-123">Your source code, however, remains the same.</span></span>

<span data-ttu-id="a5d05-124">Windows 10 アプリを作成する方法を見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="a5d05-124">Let's see how we can create a Windows 10 app.</span></span> <span data-ttu-id="a5d05-125">Visual Studio の実行から始めます。</span><span class="sxs-lookup"><span data-stu-id="a5d05-125">Start by running Visual Studio.</span></span> <span data-ttu-id="a5d05-126">Visual Studio を初めて起動すると、開発者用ライセンスを取得するように求められます。</span><span class="sxs-lookup"><span data-stu-id="a5d05-126">The first time you run it, Visual Studio will ask you to get a developer license.</span></span> <span data-ttu-id="a5d05-127">開発者用ライセンスでは、UWP アプリを Microsoft Store に提出する前にローカル コンピューター上にインストールしてテストできます。</span><span class="sxs-lookup"><span data-stu-id="a5d05-127">A developer license lets you install and test UWP apps on your local computer before you submit them to the Microsoft Store.</span></span> <span data-ttu-id="a5d05-128">ライセンスを取得するには、画面の指示に従って、Microsoft アカウントを使ってサインインします。</span><span class="sxs-lookup"><span data-stu-id="a5d05-128">To get a license, follow the on-screen directions to sign in with a Microsoft account.</span></span> <span data-ttu-id="a5d05-129">Microsoft アカウントがない場合は、**[開発者用ライセンス]** ダイアログ ボックスの **[新規登録]** リンクをクリックし、画面の指示に従います。</span><span class="sxs-lookup"><span data-stu-id="a5d05-129">If you don't have one, click the **Sign up** link in the **Developer License** dialog box, and follow the on-screen directions.</span></span>

<span data-ttu-id="a5d05-130">Xcode では、初めて起動したときに次のような **[Welcome to Xcode]** (Xcode へようこそ) 画面が表示されます。比較してください。</span><span class="sxs-lookup"><span data-stu-id="a5d05-130">For comparison, when you start Xcode, the first thing you see is the **Welcome to Xcode** screen, similar to the following figure.</span></span>

![Xcode のようこそ画面](images/ios-to-uwp/ios-to-uwp-xcode-welcome.png)

<span data-ttu-id="a5d05-132">Visual Studio もこれに似ています。</span><span class="sxs-lookup"><span data-stu-id="a5d05-132">Visual Studio is very similar.</span></span> <span data-ttu-id="a5d05-133">次の図に示すように、**[スタート ページ]** が表示されます。</span><span class="sxs-lookup"><span data-stu-id="a5d05-133">You'll see the **Start Page**, as shown in the following figure.</span></span>

![Visual Studio のスタート画面](images/ios-to-uwp/ios-to-uwp-vs-welcome.png)

<span data-ttu-id="a5d05-135">新しいアプリを作るには、次のどちらかの操作を行って、プロジェクトの作成を開始します。</span><span class="sxs-lookup"><span data-stu-id="a5d05-135">To create a new app, start by making a project by doing one of the following:</span></span>

-   <span data-ttu-id="a5d05-136">**[開始]** 領域で、**[新しいプロジェクト]** をタップします。</span><span class="sxs-lookup"><span data-stu-id="a5d05-136">In the **Start** area, tap **New Project**.</span></span>
-   <span data-ttu-id="a5d05-137">**[ファイル]** メニュー、**[新しいプロジェクト]** の順にタップします。</span><span class="sxs-lookup"><span data-stu-id="a5d05-137">Tap the **File** menu, and then tap **New Project**.</span></span>

<span data-ttu-id="a5d05-138">Xcode で新しいプロジェクトを作るときは、次の図に示すようなプロジェクト テンプレートの一覧が表示されます。比較してください。</span><span class="sxs-lookup"><span data-stu-id="a5d05-138">For comparison, when you create a new project in Xcode, you see a list of project templates like those shown in the following figure.</span></span>

![Xcode のプロジェクトの新規作成ダイアログ ボックス](images/ios-to-uwp/ios-to-uwp-xcode-choose-template.png)

<span data-ttu-id="a5d05-140">Visual Studio の場合も、次の図に示すように、いくつかのプロジェクト テンプレートから選択できるようになっています。</span><span class="sxs-lookup"><span data-stu-id="a5d05-140">In Visual Studio, there are also several project templates to choose from, as shown in the following figure.</span></span>

<span data-ttu-id="a5d05-141">![visual studio の新しいプロジェクト ダイアログ ボックス](images/ios-to-uwp/ios-to-uwp-vs-choose-template.png)このチュートリアルでは、タップ**Visual C#** 、 をタップし、 **Windows**、 **Windows ユニバーサル**と**空のアプリ (Windows ユニバーサル)** します。</span><span class="sxs-lookup"><span data-stu-id="a5d05-141">![visual studio new project dialog box](images/ios-to-uwp/ios-to-uwp-vs-choose-template.png) For this walkthrough, tap **Visual C#**, and then tap **Windows**, **Windows Universal** and **Blank App (Windows Universal)**.</span></span> <span data-ttu-id="a5d05-142">**[名前]** ボックスに「MyApp」と入力し、**[OK]** をタップします。</span><span class="sxs-lookup"><span data-stu-id="a5d05-142">In the **Name** box, type "MyApp", and then tap **OK**.</span></span> <span data-ttu-id="a5d05-143">Visual Studio によって初めてのプロジェクトが作成され、表示されます。</span><span class="sxs-lookup"><span data-stu-id="a5d05-143">Visual Studio creates and then displays your first project.</span></span> <span data-ttu-id="a5d05-144">これで、アプリの設計を開始して、コードを追加できるようになりました。</span><span class="sxs-lookup"><span data-stu-id="a5d05-144">Now, you can begin to design your app and add code to it.</span></span>

## <a name="next-step"></a><span data-ttu-id="a5d05-145">次の手順</span><span class="sxs-lookup"><span data-stu-id="a5d05-145">Next step</span></span>

[<span data-ttu-id="a5d05-146">はじめに。プログラミング言語の選択</span><span class="sxs-lookup"><span data-stu-id="a5d05-146">Getting started: Choosing a programming language</span></span>](getting-started-choosing-a-programming-language.md)
