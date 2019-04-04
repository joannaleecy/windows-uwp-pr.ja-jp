---
title: Xbox One の UWP アプリ開発の概要
description: UWP 開発のために PC と Xbox One を設定する方法。
ms.date: 10/12/2017
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: c94d27e87853b570268e3a39fe941c817b3eda6a
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57590977"
---
# <a name="getting-started-with-uwp-app-development-on-xbox-one"></a><span data-ttu-id="b87b8-104">Xbox One の UWP アプリ開発の概要</span><span class="sxs-lookup"><span data-stu-id="b87b8-104">Getting started with UWP app development on Xbox One</span></span>

<span data-ttu-id="b87b8-105">ユニバーサル Windows プラットフォーム (UWP) 開発のために PC と Xbox One を設定する方法の手順に**注意深く**従います。</span><span class="sxs-lookup"><span data-stu-id="b87b8-105">**Carefully** follow these steps to successfully set up your PC and Xbox One for Universal Windows Platform (UWP) development.</span></span> <span data-ttu-id="b87b8-106">この設定の完了後に、Xbox One の開発者モードと UWP アプリの構築について詳しくは、「[Xbox one の UWP](index.md)」ページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b87b8-106">After you’ve got things set up, you can learn more about Developer Mode on Xbox One and building UWP apps on the [UWP for Xbox One](index.md) page.</span></span> 

## <a name="before-you-start"></a><span data-ttu-id="b87b8-107">開始前の作業</span><span class="sxs-lookup"><span data-stu-id="b87b8-107">Before you start</span></span>

<span data-ttu-id="b87b8-108">開始する前に、次の操作をする必要があります。</span><span class="sxs-lookup"><span data-stu-id="b87b8-108">Before you start you will need to do the following:</span></span>
-   <span data-ttu-id="b87b8-109">インストールされた最新のバージョンの Windows 10 PC を設定します。</span><span class="sxs-lookup"><span data-stu-id="b87b8-109">Set up a PC with the latest version of Windows 10.</span></span>
<!-- -  Install Microsoft Visual Studio 2015 Update 3 or Microsoft Visual Studio 2017.

    > [!NOTE]
    > Visual Studio 2017 is required if you are using the Windows 10, build 15063 SDK. -->

- <span data-ttu-id="b87b8-110">Xbox One 本体上に少なくとも 5 GB の空き領域が必要です。</span><span class="sxs-lookup"><span data-stu-id="b87b8-110">Have at least five gigabytes of free space on your Xbox One console.</span></span>

## <a name="setting-up-your-development-pc"></a><span data-ttu-id="b87b8-111">開発用 PC のセットアップ</span><span class="sxs-lookup"><span data-stu-id="b87b8-111">Setting up your development PC</span></span>

1.  <span data-ttu-id="b87b8-112">Visual Studio 2015 Update 3 または Visual Studio 2017 をインストールします。</span><span class="sxs-lookup"><span data-stu-id="b87b8-112">Install Visual Studio 2015 Update 3 or Visual Studio 2017.</span></span>

    <span data-ttu-id="b87b8-113">Visual Studio 2015 Update 3 をインストールする場合は選択するように**カスタム**インストールし、選択、**ユニバーサル Windows アプリ開発ツール**– チェック ボックスは既定値の一部をインストールします。</span><span class="sxs-lookup"><span data-stu-id="b87b8-113">If you're installing Visual Studio 2015 Update 3, make sure that you choose **Custom** install and select the **Universal Windows App Development Tools** check box – it's not part of the default install.</span></span> <span data-ttu-id="b87b8-114">C++ 開発者の場合は、**カスタム インストール**と **C++** を選択してください。</span><span class="sxs-lookup"><span data-stu-id="b87b8-114">If you are a C++ developer, make sure that you choose **Custom install** and select **C++**.</span></span>

    <span data-ttu-id="b87b8-115">Visual Studio 2017 をインストールする場合、必ず**ユニバーサル Windows プラットフォーム開発**ワークロードを選択してください。</span><span class="sxs-lookup"><span data-stu-id="b87b8-115">If you're installing Visual Studio 2017, make sure that you choose the **Universal Windows Platform development** workload.</span></span> <span data-ttu-id="b87b8-116">C++ の開発者の場合、**概要**、右側のペインで**ユニバーサル Windows プラットフォーム開発**を選択することを確認、 **C++ ユニバーサル Windows プラットフォーム ツール**チェック ボックスをオンします。</span><span class="sxs-lookup"><span data-stu-id="b87b8-116">If you're a C++ developer, in the **Summary** pane on the right, under **Universal Windows Platform development**, make sure that you select the **C++ Universal Windows Platform tools** checkbox.</span></span> <span data-ttu-id="b87b8-117">既定のインストールの一部ではありません。</span><span class="sxs-lookup"><span data-stu-id="b87b8-117">It's not part of the default install.</span></span>

    <span data-ttu-id="b87b8-118">詳細については、[Xbox 開発環境で、UWP 設定](development-environment-setup.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="b87b8-118">For more information, see [Set up your UWP on Xbox development environment](development-environment-setup.md).</span></span>

2.  <span data-ttu-id="b87b8-119">最新のインストール[Windows 10 SDK](https://developer.microsoft.com/windows/downloads/windows-10-sdk)します。</span><span class="sxs-lookup"><span data-stu-id="b87b8-119">Install the latest [Windows 10 SDK](https://developer.microsoft.com/windows/downloads/windows-10-sdk).</span></span>

3.  <span data-ttu-id="b87b8-120">開発用 PC の開発者モードを有効にする (**設定/更新とセキュリティ]、[開発者向け]、[開発者向けの機能を使用して/開発者モード**)。</span><span class="sxs-lookup"><span data-stu-id="b87b8-120">Enable Developer Mode for your development PC (**Settings / Update & Security / For developers / Use developer features / Developer mode**).</span></span>

<span data-ttu-id="b87b8-121">これで開発用 PC の準備は完了です。次のビデオをご覧ください。続きのセクションでは、Xbox One を開発用に設定し、UWP アプリを作成して展開する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="b87b8-121">Now that your development PC is ready, you can watch this video or continue reading to see how to set up your Xbox One for development and create and deploy a UWP app to it.</span></span>
</br>
</br>
<iframe src="https://channel9.msdn.com/Events/Xbox/App-Dev-on-Xbox/Get-started-with-App-Dev-on-Xbox/player#time=51s:paused" width="600" height="338"  allowFullScreen frameBorder="0"></iframe>

## <a name="setting-up-your-xbox-one-console"></a><span data-ttu-id="b87b8-122">Xbox One 本体の設定</span><span class="sxs-lookup"><span data-stu-id="b87b8-122">Setting up your Xbox One console</span></span>

1.  <span data-ttu-id="b87b8-123">Xbox One の開発者モードを有効にします。</span><span class="sxs-lookup"><span data-stu-id="b87b8-123">Activate Developer Mode on your Xbox One.</span></span> <span data-ttu-id="b87b8-124">アプリをダウンロードして、アクティブ化コードを取得しに入力、 **Xbox One の管理コンソール**パートナー センターのアプリの開発者アカウントでページ。</span><span class="sxs-lookup"><span data-stu-id="b87b8-124">Download the app, get the activation code, and then enter it into the **Manage Xbox One consoles** page in your Partner Center app developer account.</span></span> <span data-ttu-id="b87b8-125">詳しくは、「[Xbox One の開発者モードのアクティブ化](devkit-activation.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b87b8-125">For more information, see [Xbox One Developer Mode activation](devkit-activation.md).</span></span> 

2.  <span data-ttu-id="b87b8-126">開く、**開発モードのアクティブ化**アプリと選択**スイッチと再起動**します。</span><span class="sxs-lookup"><span data-stu-id="b87b8-126">Open the **Dev Mode Activation** app and select **Switch and restart**.</span></span> <span data-ttu-id="b87b8-127">これで Xbox One は開発者モードとなりました。</span><span class="sxs-lookup"><span data-stu-id="b87b8-127">Congratulations, you now have an Xbox One in Developer Mode!</span></span>
  
  > [!NOTE]
  > <span data-ttu-id="b87b8-128">市販のゲームやアプリは開発者モードでは実行できません。自分で作成するアプリまたはゲームを実行できます。</span><span class="sxs-lookup"><span data-stu-id="b87b8-128">Your retail games and apps won’t run in Developer Mode, but the apps or games you create will.</span></span> <span data-ttu-id="b87b8-129">市販のゲームやアプリを実行するには、リテール モードに切り替えます。</span><span class="sxs-lookup"><span data-stu-id="b87b8-129">Switch back to Retail Mode to run your favorite games and apps.</span></span>
    
  > [!NOTE]
  > <span data-ttu-id="b87b8-130">開発者モードでアプリを Xbox One に展開するには、ユーザーを本体にサインインさせる必要があります。</span><span class="sxs-lookup"><span data-stu-id="b87b8-130">Before you can deploy an app to your Xbox One in Developer Mode, you must have a user signed in on the console.</span></span> <span data-ttu-id="b87b8-131">既存の Xbox Live アカウントを使用することも、開発者モードで本体の新しいアカウントを作成することもできます。</span><span class="sxs-lookup"><span data-stu-id="b87b8-131">You can either use your existing Xbox Live account or create a new account for your console in Developer Mode.</span></span> 

## <a name="creating-your-first-project-in-visual-studio"></a><span data-ttu-id="b87b8-132">Visual Studio での最初のプロジェクトの作成</span><span class="sxs-lookup"><span data-stu-id="b87b8-132">Creating your first project in Visual Studio</span></span>

<span data-ttu-id="b87b8-133">詳細についてを参照してください。 [Xbox 開発環境で、UWP 設定](development-environment-setup.md)します。</span><span class="sxs-lookup"><span data-stu-id="b87b8-133">For more detailed information, see [Set up your UWP on Xbox development environment](development-environment-setup.md).</span></span>

1.  <span data-ttu-id="b87b8-134">**C#** :新しいユニバーサル Windows プロジェクトを作成し、**ソリューション エクスプ ローラー**プロジェクトを右クリックし、選択、**プロパティ**します。</span><span class="sxs-lookup"><span data-stu-id="b87b8-134">**For C#**: Create a new Universal Windows project, and in the **Solution Explorer**, right-click the project and select **Properties**.</span></span> <span data-ttu-id="b87b8-135">選択、**デバッグ** タブで、変更**ターゲット デバイス**に**リモート コンピューター**、IP アドレスまたはホスト名に Xbox One、コンソールの入力、**リモート コンピューター**フィールド、および select**ユニバーサル (暗号化されていないプロトコル)** で、**認証モード**ドロップダウン リスト。</span><span class="sxs-lookup"><span data-stu-id="b87b8-135">Select the **Debug** tab, change **Target device** to **Remote Machine**, type the IP address or hostname of your Xbox One console into the **Remote machine** field, and select **Universal (Unencrypted Protocol)** in the **Authentication Mode** drop-down list.</span></span>   

    <span data-ttu-id="b87b8-136">本体で Dev Home (ホーム画面の右側の大きなタイル) を開始すると、左上隅に Xbox One の IP アドレスが表示されます。</span><span class="sxs-lookup"><span data-stu-id="b87b8-136">You can find your Xbox One IP address by starting Dev Home on your console (the big tile on the right side of Home) and looking at the top left corner.</span></span> <span data-ttu-id="b87b8-137">Dev Home について詳しくは、「[Xbox One ツールの概要](introduction-to-xbox-tools.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b87b8-137">For more information about Dev Home, see [Introduction to Xbox One tools](introduction-to-xbox-tools.md).</span></span>  

2.  <span data-ttu-id="b87b8-138">**C++ および Html/javascript プロジェクト**:ようなパスに従うC#プロジェクトでは、プロジェクトのプロパティに移動、**デバッグ**] タブで [**リモート マシン**をドロップダウン リストを開くデバッガー、IP アドレスまたはホスト名の入力コンソール、**マシン名**フィールド、および選択**ユニバーサル (暗号化されていないプロトコル)** で、**認証の種類**フィールド。</span><span class="sxs-lookup"><span data-stu-id="b87b8-138">**For C++ and HTML/Javascript projects**: You follow a path similar to C# projects, but in the project properties go to the **Debugging** tab, select **Remote Machine** in the Debugger to open the drop-down list, type the IP address or hostname of the console into the **Machine Name** field, and select **Universal (Unencrypted Protocol)** in the **Authentication Type** field.</span></span>

3. <span data-ttu-id="b87b8-139">選択**x64**上部のメニュー バーに緑色の再生ボタンの左側のドロップダウン リストから。</span><span class="sxs-lookup"><span data-stu-id="b87b8-139">Select **x64** from the dropdown to the left of the green play button in the top menu bar.</span></span>
   
4.  <span data-ttu-id="b87b8-140">F5 キーを押してアプリをビルドして、Xbox One での展開を開始します。</span><span class="sxs-lookup"><span data-stu-id="b87b8-140">When you press F5, your app will build and start to deploy on your Xbox One.</span></span>
  
5.  <span data-ttu-id="b87b8-141">初めてこれを行う際には、Visual Studio に Xbox One の PIN の入力を求められます。</span><span class="sxs-lookup"><span data-stu-id="b87b8-141">The first time you do this, Visual Studio will prompt you for a PIN for your Xbox One.</span></span> <span data-ttu-id="b87b8-142">Xbox One でホームの開発を開始しを選択すると、暗証番号 (pin) を取得できます、**を表示する Visual Studio のピン留め**ボタンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="b87b8-142">You can get a PIN by starting Dev Home on your Xbox One and selecting the **Show Visual Studio pin** button.</span></span>
  
6.  <span data-ttu-id="b87b8-143">ペアリングを行うと、アプリの展開が開始されます。</span><span class="sxs-lookup"><span data-stu-id="b87b8-143">After you have paired, your app will start to deploy.</span></span> <span data-ttu-id="b87b8-144">初めてこれを行う際には、(すべてのツールを Xbox にコピーする必要があるため) 少し時間がかかることがありますが、数分以上かかる場合には、何か問題がある場合があります。</span><span class="sxs-lookup"><span data-stu-id="b87b8-144">The first time you do this it might be a bit slow (we have to copy all the tools over to your Xbox), but if it takes more than a few minutes, something is probably wrong.</span></span> <span data-ttu-id="b87b8-145">上記のすべての手順を実行していることを確認します (特に **[認証モード]** を **[ユニバーサル]** に設定していることを確認します)。また Xbox One に有線接続していることを確認します。</span><span class="sxs-lookup"><span data-stu-id="b87b8-145">Make sure that you have followed all of the steps above (particularly, did you set the **Authentication Mode** to **Universal**?) and that you are using a wired network connection to your Xbox One.</span></span>  

7. <span data-ttu-id="b87b8-146">用意ができました。</span><span class="sxs-lookup"><span data-stu-id="b87b8-146">Sit back and relax.</span></span> <span data-ttu-id="b87b8-147">本体での初めてのアプリの実行をお楽しみください。</span><span class="sxs-lookup"><span data-stu-id="b87b8-147">Enjoy your first app running on the console!</span></span>  

## <a name="thats-it"></a><span data-ttu-id="b87b8-148">以上で作業は終了です。</span><span class="sxs-lookup"><span data-stu-id="b87b8-148">That's it!</span></span>

![Hello World](images/getting-started-hello-world.png)

## <a name="see-also"></a><span data-ttu-id="b87b8-150">関連項目</span><span class="sxs-lookup"><span data-stu-id="b87b8-150">See also</span></span>  
- [<span data-ttu-id="b87b8-151">よく寄せられる質問</span><span class="sxs-lookup"><span data-stu-id="b87b8-151">Frequently asked questions</span></span>](frequently-asked-questions.md)  
- [<span data-ttu-id="b87b8-152">Xbox 開発者プログラムに UWP に関する既知の問題</span><span class="sxs-lookup"><span data-stu-id="b87b8-152">Known issues with UWP on Xbox Developer Program</span></span>](known-issues.md)
- [<span data-ttu-id="b87b8-153">Xbox One の UWP</span><span class="sxs-lookup"><span data-stu-id="b87b8-153">UWP on Xbox One</span></span>](index.md) 
