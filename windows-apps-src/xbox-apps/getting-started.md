---
author: Mtoepke
title: Xbox One の UWP アプリ開発の概要
description: UWP 開発のために PC と Xbox One を設定する方法。
ms.author: scotmi
ms.date: 10/12/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: da260b4f9f5f50d97d39af883217dfbae91a566e
ms.sourcegitcommit: 1c6325aa572868b789fcdd2efc9203f67a83872a
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/17/2018
ms.locfileid: "4746764"
---
# <a name="getting-started-with-uwp-app-development-on-xbox-one"></a><span data-ttu-id="02282-104">Xbox One の UWP アプリ開発の概要</span><span class="sxs-lookup"><span data-stu-id="02282-104">Getting started with UWP app development on Xbox One</span></span>

<span data-ttu-id="02282-105">ユニバーサル Windows プラットフォーム (UWP) 開発のために PC と Xbox One を設定する方法の手順に**注意深く**従います。</span><span class="sxs-lookup"><span data-stu-id="02282-105">**Carefully** follow these steps to successfully set up your PC and Xbox One for Universal Windows Platform (UWP) development.</span></span> <span data-ttu-id="02282-106">この設定の完了後に、Xbox One の開発者モードと UWP アプリの構築について詳しくは、「[Xbox One の UWP](index.md)」ページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="02282-106">After you’ve got things set up, you can learn more about Developer Mode on Xbox One and building UWP apps on the [UWP for Xbox One](index.md) page.</span></span> 

## <a name="before-you-start"></a><span data-ttu-id="02282-107">開始前の作業</span><span class="sxs-lookup"><span data-stu-id="02282-107">Before you start</span></span>

<span data-ttu-id="02282-108">開始する前に、次の操作をする必要があります。</span><span class="sxs-lookup"><span data-stu-id="02282-108">Before you start you will need to do the following:</span></span>
-   <span data-ttu-id="02282-109">最新バージョンの Windows 10 での PC を設定します。</span><span class="sxs-lookup"><span data-stu-id="02282-109">Set up a PC with the latest version of Windows 10.</span></span>
<!-- -  Install Microsoft Visual Studio 2015 Update 3 or Microsoft Visual Studio 2017.

    > [!NOTE]
    > Visual Studio 2017 is required if you are using the Windows 10, build 15063 SDK. -->

- <span data-ttu-id="02282-110">Xbox One 本体上に少なくとも 5 GB の空き領域が必要です。</span><span class="sxs-lookup"><span data-stu-id="02282-110">Have at least five gigabytes of free space on your Xbox One console.</span></span>

## <a name="setting-up-your-development-pc"></a><span data-ttu-id="02282-111">開発用 PC のセットアップ</span><span class="sxs-lookup"><span data-stu-id="02282-111">Setting up your development PC</span></span>

1.  <span data-ttu-id="02282-112">Visual Studio 2015 Update 3 または Visual Studio 2017 をインストールします。</span><span class="sxs-lookup"><span data-stu-id="02282-112">Install Visual Studio 2015 Update 3 or Visual Studio 2017.</span></span>

    <span data-ttu-id="02282-113">Visual Studio 2015 Update 3 をインストールしている場合は、既定のインストールの一部ではないこと:**カスタム**インストールを選択して、**ユニバーサル Windows アプリ開発ツール**] チェック ボックスをオンを確認します。</span><span class="sxs-lookup"><span data-stu-id="02282-113">If you're installing Visual Studio 2015 Update 3, make sure that you choose **Custom** install and select the **Universal Windows App Development Tools** check box – it's not part of the default install.</span></span> <span data-ttu-id="02282-114">C++ 開発者の場合は、**カスタム インストール**と **C++** を選択してください。</span><span class="sxs-lookup"><span data-stu-id="02282-114">If you are a C++ developer, make sure that you choose **Custom install** and select **C++**.</span></span>

    <span data-ttu-id="02282-115">Visual Studio 2017 をインストールする場合、必ず**ユニバーサル Windows プラットフォーム開発**ワークロードを選択してください。</span><span class="sxs-lookup"><span data-stu-id="02282-115">If you're installing Visual Studio 2017, make sure that you choose the **Universal Windows Platform development** workload.</span></span> <span data-ttu-id="02282-116">場合 C++ 開発者が、右側の [**概要**] ウィンドウで、**ユニバーサル Windows プラットフォーム開発**、確認**C++ ユニバーサル Windows プラットフォーム ツール**のチェック ボックスを選択します。</span><span class="sxs-lookup"><span data-stu-id="02282-116">If you're a C++ developer, in the **Summary** pane on the right, under **Universal Windows Platform development**, make sure that you select the **C++ Universal Windows Platform tools** checkbox.</span></span> <span data-ttu-id="02282-117">既定のインストールの一部ではありません。</span><span class="sxs-lookup"><span data-stu-id="02282-117">It's not part of the default install.</span></span>

    <span data-ttu-id="02282-118">詳細については、 [UWP Xbox の開発環境をセットアップ](development-environment-setup.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="02282-118">For more information, see [Set up your UWP on Xbox development environment](development-environment-setup.md).</span></span>

2.  <span data-ttu-id="02282-119">最新の[Windows 10 SDK](https://developer.microsoft.com/windows/downloads/windows-10-sdk)をインストールします。</span><span class="sxs-lookup"><span data-stu-id="02282-119">Install the latest [Windows 10 SDK](https://developer.microsoft.com/windows/downloads/windows-10-sdk).</span></span>

3.  <span data-ttu-id="02282-120">開発用 PC の開発者モードを有効にする (**設定/更新とセキュリティ]、[開発者開発者向け機能を使用して//開発者モード**)。</span><span class="sxs-lookup"><span data-stu-id="02282-120">Enable Developer Mode for your development PC (**Settings / Update & Security / For developers / Use developer features / Developer mode**).</span></span>

<span data-ttu-id="02282-121">これで開発用 PC の準備は完了です。次のビデオをご覧ください。続きのセクションでは、Xbox One を開発用に設定し、UWP アプリを作成して展開する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="02282-121">Now that your development PC is ready, you can watch this video or continue reading to see how to set up your Xbox One for development and create and deploy a UWP app to it.</span></span>
</br>
</br>
<iframe src="https://channel9.msdn.com/Events/Xbox/App-Dev-on-Xbox/Get-started-with-App-Dev-on-Xbox/player#time=51s:paused" width="600" height="338"  allowFullScreen frameBorder="0"></iframe>

## <a name="setting-up-your-xbox-one-console"></a><span data-ttu-id="02282-122">Xbox One 本体の設定</span><span class="sxs-lookup"><span data-stu-id="02282-122">Setting up your Xbox One console</span></span>

1.  <span data-ttu-id="02282-123">Xbox One の開発者モードを有効にします。</span><span class="sxs-lookup"><span data-stu-id="02282-123">Activate Developer Mode on your Xbox One.</span></span> <span data-ttu-id="02282-124">アプリをダウンロード、アクティブ化コードを取得し、デベロッパー センター アカウントに[Xbox One 本体の管理](https://partner.microsoft.com/xboxactivate)ページに入力します。</span><span class="sxs-lookup"><span data-stu-id="02282-124">Download the app, get the activation code, and then enter it into the [Manage Xbox One consoles](https://partner.microsoft.com/xboxactivate) page in your Dev Center account.</span></span> <span data-ttu-id="02282-125">詳しくは、「[Xbox One の開発者モードのアクティブ化](devkit-activation.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="02282-125">For more information, see [Xbox One Developer Mode activation](devkit-activation.md).</span></span> 

2.  <span data-ttu-id="02282-126">**開発者モードのアクティブ化用**アプリを開き、**切り替えと再起動**を選択します。</span><span class="sxs-lookup"><span data-stu-id="02282-126">Open the **Dev Mode Activation** app and select **Switch and restart**.</span></span> <span data-ttu-id="02282-127">これで Xbox One は開発者モードとなりました。</span><span class="sxs-lookup"><span data-stu-id="02282-127">Congratulations, you now have an Xbox One in Developer Mode!</span></span>
  
  > [!NOTE]
  > <span data-ttu-id="02282-128">市販のゲームやアプリは開発者モードでは実行できません。自分で作成するアプリまたはゲームを実行できます。</span><span class="sxs-lookup"><span data-stu-id="02282-128">Your retail games and apps won’t run in Developer Mode, but the apps or games you create will.</span></span> <span data-ttu-id="02282-129">市販のゲームやアプリを実行するには、リテール モードに切り替えます。</span><span class="sxs-lookup"><span data-stu-id="02282-129">Switch back to Retail Mode to run your favorite games and apps.</span></span>
    
  > [!NOTE]
  > <span data-ttu-id="02282-130">開発者モードでアプリを Xbox One に展開するには、ユーザーを本体にサインインさせる必要があります。</span><span class="sxs-lookup"><span data-stu-id="02282-130">Before you can deploy an app to your Xbox One in Developer Mode, you must have a user signed in on the console.</span></span> <span data-ttu-id="02282-131">既存の Xbox Live アカウントを使用することも、開発者モードで本体の新しいアカウントを作成することもできます。</span><span class="sxs-lookup"><span data-stu-id="02282-131">You can either use your existing Xbox Live account or create a new account for your console in Developer Mode.</span></span> 

## <a name="creating-your-first-project-in-visual-studio"></a><span data-ttu-id="02282-132">Visual Studio での初めてのプロジェクトの作成</span><span class="sxs-lookup"><span data-stu-id="02282-132">Creating your first project in Visual Studio</span></span>

<span data-ttu-id="02282-133">詳細については、 [UWP Xbox の開発環境をセットアップ](development-environment-setup.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="02282-133">For more detailed information, see [Set up your UWP on Xbox development environment](development-environment-setup.md).</span></span>

1.  <span data-ttu-id="02282-134">**C# の**: 新しいユニバーサル Windows プロジェクトを作成し、**ソリューション エクスプ ローラー**でプロジェクトを右クリックし、**プロパティ**を選択します。</span><span class="sxs-lookup"><span data-stu-id="02282-134">**For C#**: Create a new Universal Windows project, and in the **Solution Explorer**, right-click the project and select **Properties**.</span></span> <span data-ttu-id="02282-135">**デバッグ**] タブを選択、**ターゲット デバイス**を**リモート コンピューター**に変更する、**リモート コンピューター** ] フィールドに IP アドレスまたは Xbox One 本体のホスト名を入力し、**で**ユニバーサル (暗号化されていないプロトコル)\*\* を選択認証モード\*\*ドロップダウン リスト。</span><span class="sxs-lookup"><span data-stu-id="02282-135">Select the **Debug** tab, change **Target device** to **Remote Machine**, type the IP address or hostname of your Xbox One console into the **Remote machine** field, and select **Universal (Unencrypted Protocol)** in the **Authentication Mode** drop-down list.</span></span>   

    <span data-ttu-id="02282-136">本体で Dev Home (ホーム画面の右側の大きなタイル) を開始すると、左上隅に Xbox One の IP アドレスが表示されます。</span><span class="sxs-lookup"><span data-stu-id="02282-136">You can find your Xbox One IP address by starting Dev Home on your console (the big tile on the right side of Home) and looking at the top left corner.</span></span> <span data-ttu-id="02282-137">Dev Home について詳しくは、「[Xbox One ツールの概要](introduction-to-xbox-tools.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="02282-137">For more information about Dev Home, see [Introduction to Xbox One tools](introduction-to-xbox-tools.md).</span></span>  

2.  <span data-ttu-id="02282-138">**C++ と Html/javascript プロジェクト**: と同様のパスを実行する c# プロジェクトの場合、プロジェクトのプロパティで、[**デバッグ**] タブに移動、ドロップダウン リストを開き、IP アドレスまたはホスト名の入力にデバッガーで**リモート コンピューター**を選択します**コンピューター名**] と [**ユニバーサル (暗号化されていないプロトコル)** **認証の種類**のフィールドに本体です。</span><span class="sxs-lookup"><span data-stu-id="02282-138">**For C++ and HTML/Javascript projects**: You follow a path similar to C# projects, but in the project properties go to the **Debugging** tab, select **Remote Machine** in the Debugger to open the drop-down list, type the IP address or hostname of the console into the **Machine Name** field, and select **Universal (Unencrypted Protocol)** in the **Authentication Type** field.</span></span>

3. <span data-ttu-id="02282-139">上部のメニュー バーで、緑色の再生ボタンの左側のドロップダウン リストから**x64**を選びます。</span><span class="sxs-lookup"><span data-stu-id="02282-139">Select **x64** from the dropdown to the left of the green play button in the top menu bar.</span></span>
   
4.  <span data-ttu-id="02282-140">F5 キーを押してアプリをビルドして、Xbox One での展開を開始します。</span><span class="sxs-lookup"><span data-stu-id="02282-140">When you press F5, your app will build and start to deploy on your Xbox One.</span></span>
  
5.  <span data-ttu-id="02282-141">初めてこれを行う際には、Visual Studio に Xbox One の PIN の入力を求められます。</span><span class="sxs-lookup"><span data-stu-id="02282-141">The first time you do this, Visual Studio will prompt you for a PIN for your Xbox One.</span></span> <span data-ttu-id="02282-142">Xbox One で Dev Home を開始して、 **Visual Studio pin の表示**] ボタンを選択して、PIN を取得できます。</span><span class="sxs-lookup"><span data-stu-id="02282-142">You can get a PIN by starting Dev Home on your Xbox One and selecting the **Show Visual Studio pin** button.</span></span>
  
6.  <span data-ttu-id="02282-143">ペアリングを行うと、アプリの展開が開始されます。</span><span class="sxs-lookup"><span data-stu-id="02282-143">After you have paired, your app will start to deploy.</span></span> <span data-ttu-id="02282-144">初めてこれを行う際には、(すべてのツールを Xbox にコピーする必要があるため) 少し時間がかかることがありますが、数分以上かかる場合には、何か問題がある場合があります。</span><span class="sxs-lookup"><span data-stu-id="02282-144">The first time you do this it might be a bit slow (we have to copy all the tools over to your Xbox), but if it takes more than a few minutes, something is probably wrong.</span></span> <span data-ttu-id="02282-145">上記のすべての手順を実行していることを確認します (特に **[認証モード]** を **[ユニバーサル]** に設定していることを確認します)。また Xbox One に有線接続していることを確認します。</span><span class="sxs-lookup"><span data-stu-id="02282-145">Make sure that you have followed all of the steps above (particularly, did you set the **Authentication Mode** to **Universal**?) and that you are using a wired network connection to your Xbox One.</span></span>  

7. <span data-ttu-id="02282-146">用意ができました。</span><span class="sxs-lookup"><span data-stu-id="02282-146">Sit back and relax.</span></span> <span data-ttu-id="02282-147">本体での初めてのアプリの実行をお楽しみください。</span><span class="sxs-lookup"><span data-stu-id="02282-147">Enjoy your first app running on the console!</span></span>  

## <a name="thats-it"></a><span data-ttu-id="02282-148">以上で作業は終了です。</span><span class="sxs-lookup"><span data-stu-id="02282-148">That's it!</span></span>

![Hello World](images/getting-started-hello-world.png)

## <a name="see-also"></a><span data-ttu-id="02282-150">関連項目</span><span class="sxs-lookup"><span data-stu-id="02282-150">See also</span></span>  
- [<span data-ttu-id="02282-151">よく寄せられる質問</span><span class="sxs-lookup"><span data-stu-id="02282-151">Frequently asked questions</span></span>](frequently-asked-questions.md)  
- [<span data-ttu-id="02282-152">Xbox 開発者プログラムの UWP の既知の問題</span><span class="sxs-lookup"><span data-stu-id="02282-152">Known issues with UWP on Xbox Developer Program</span></span>](known-issues.md)
- [<span data-ttu-id="02282-153">Xbox One の UWP</span><span class="sxs-lookup"><span data-stu-id="02282-153">UWP on Xbox One</span></span>](index.md) 
