---
author: Mtoepke
title: Xbox One の UWP アプリ開発の概要
description: UWP 開発のために PC と Xbox One を設定する方法。
ms.author: mtoepke
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: ea8262f0aad4112ce2ce6d661156f5692541a4ce
ms.sourcegitcommit: de6bc8acec2cd5ebc36bb21b2ce1a9980c3e78b2
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/17/2017
ms.locfileid: "900996"
---
#<a name="getting-started-with-uwp-app-development-on-xbox-one"></a><span data-ttu-id="34e61-104">Xbox One の UWP アプリ開発の概要</span><span class="sxs-lookup"><span data-stu-id="34e61-104">Getting started with UWP app development on Xbox One</span></span>

<span data-ttu-id="34e61-105">ユニバーサル Windows プラットフォーム (UWP) 開発のために PC と Xbox One を設定する方法の手順に**注意深く**従います。</span><span class="sxs-lookup"><span data-stu-id="34e61-105">**Carefully** follow these steps to successfully set up your PC and Xbox One for Universal Windows Platform (UWP) development.</span></span> <span data-ttu-id="34e61-106">この設定の完了後に、Xbox One の開発者モードと UWP アプリの構築について詳しくは、「[Xbox One の UWP](index.md)」ページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="34e61-106">After you’ve got things set up, you can learn more about Developer Mode on Xbox One and building UWP apps on the [UWP for Xbox One](index.md) page.</span></span> 

## <a name="before-you-start"></a><span data-ttu-id="34e61-107">開始前の作業</span><span class="sxs-lookup"><span data-stu-id="34e61-107">Before you start</span></span>
<span data-ttu-id="34e61-108">開始する前に、次の操作をする必要があります。</span><span class="sxs-lookup"><span data-stu-id="34e61-108">Before you start you will need to do the following:</span></span>
-   <span data-ttu-id="34e61-109">Windows 10 で PC を設定します。</span><span class="sxs-lookup"><span data-stu-id="34e61-109">Set up a PC with Windows 10.</span></span>
-   <span data-ttu-id="34e61-110">Microsoft Visual Studio2015 Update3 をインストールします。</span><span class="sxs-lookup"><span data-stu-id="34e61-110">Install Microsoft Visual Studio 2015 Update 3.</span></span>
- <span data-ttu-id="34e61-111">Xbox One 本体上に少なくとも 5 GB の空き領域が必要です。</span><span class="sxs-lookup"><span data-stu-id="34e61-111">Have at least five gigabytes of free space on your Xbox One console.</span></span>

## <a name="setting-up-your-development-pc"></a><span data-ttu-id="34e61-112">開発用 PC のセットアップ</span><span class="sxs-lookup"><span data-stu-id="34e61-112">Setting up your development PC</span></span>
1.  <span data-ttu-id="34e61-113">Visual Studio 2015 Update をインストールします。</span><span class="sxs-lookup"><span data-stu-id="34e61-113">Install Visual Studio 2015 Update.</span></span> <span data-ttu-id="34e61-114">既定のインストールには含まれていないため、**カスタム** インストールを選択し、**[ユニバーサル Windows アプリ開発ツール]** チェック ボックスをオンにします。</span><span class="sxs-lookup"><span data-stu-id="34e61-114">Make sure that you choose **Custom** install and select the **Universal Windows App Development Tools** check box – it's not part of the default install.</span></span> <span data-ttu-id="34e61-115">C++ 開発者の場合は、**カスタム インストール**と **C++** を選択してください。</span><span class="sxs-lookup"><span data-stu-id="34e61-115">If you are a C++ developer, make sure that you choose **Custom install** and select **C++**.</span></span> <span data-ttu-id="34e61-116">詳しくは、「[開発環境のセットアップ](development-environment-setup.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="34e61-116">For more information, see [Development environment setup](development-environment-setup.md).</span></span> 

2.  <span data-ttu-id="34e61-117">最新の Windows 10 SDK をインストールします。</span><span class="sxs-lookup"><span data-stu-id="34e61-117">Install the latest Windows 10 SDK.</span></span> <span data-ttu-id="34e61-118">これは [https://developer.microsoft.com/windows/downloads/windows-10-sdk](https://developer.microsoft.com/windows/downloads/windows-10-sdk) から入手できます。</span><span class="sxs-lookup"><span data-stu-id="34e61-118">You can get this from [https://developer.microsoft.com/windows/downloads/windows-10-sdk](https://developer.microsoft.com/windows/downloads/windows-10-sdk).</span></span>

3.  <span data-ttu-id="34e61-119">開発用 PC の開発者モードを有効にします ([設定]、[更新とセキュリティ]、[開発者向け]、[開発者モード])。</span><span class="sxs-lookup"><span data-stu-id="34e61-119">Enable Developer Mode for your development PC (Settings / Update & security / For developers / Developer mode).</span></span>


<span data-ttu-id="34e61-120">これで開発用 PC の準備は完了です。次のビデオをご覧ください。続きのセクションでは、Xbox One を開発用に設定し、UWP アプリを作成して展開する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="34e61-120">Now that your development PC is ready, you can watch this video or continue reading to see how to set up your Xbox One for development and create and deploy a UWP app to it.</span></span>
</br>
</br>
<iframe src="https://channel9.msdn.com/Events/Xbox/App-Dev-on-Xbox/Get-started-with-App-Dev-on-Xbox/player#time=51s:paused" width="600" height="338"  allowFullScreen frameBorder="0"></iframe>

## <a name="setting-up-your-xbox-one-console"></a><span data-ttu-id="34e61-121">Xbox One 本体の設定</span><span class="sxs-lookup"><span data-stu-id="34e61-121">Setting up your Xbox One console</span></span>

1.  <span data-ttu-id="34e61-122">Xbox One で開発者モードを有効にします。</span><span class="sxs-lookup"><span data-stu-id="34e61-122">Activate Developer Mode on your Xbox One.</span></span> <span data-ttu-id="34e61-123">アプリをダウンロードして、アクティブ化コードを取得し、デベロッパー センターのアカウントを使って、xboxactivate ページでそれを入力します。</span><span class="sxs-lookup"><span data-stu-id="34e61-123">Download the app, get the activation code, and then enter it into the xboxactivate page in your Dev Center account.</span></span> <span data-ttu-id="34e61-124">詳しくは、「[Xbox One で開発者モードを有効にする](devkit-activation.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="34e61-124">For more information, see [Enabling Developer Mode on Xbox One](devkit-activation.md).</span></span> 

2.  <span data-ttu-id="34e61-125">開発者モードのアクティブ化のアプリに移動し、**[切り替えと再起動]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="34e61-125">Go into the Dev Mode Activation app and select **Switch and restart**.</span></span> <span data-ttu-id="34e61-126">これで Xbox One は開発者モードとなりました。</span><span class="sxs-lookup"><span data-stu-id="34e61-126">Congratulations, you now have an Xbox One in Developer Mode!</span></span>
  
  > [!NOTE]
  > <span data-ttu-id="34e61-127">市販のゲームやアプリは開発者モードでは実行できません。自分で作成するアプリまたはゲームを実行できます。</span><span class="sxs-lookup"><span data-stu-id="34e61-127">Your retail games and apps won’t run in Developer Mode, but the apps or games you create will.</span></span> <span data-ttu-id="34e61-128">市販のゲームやアプリを実行するには、リテール モードに切り替えます。</span><span class="sxs-lookup"><span data-stu-id="34e61-128">Switch back to Retail Mode to run your favorite games and apps.</span></span>
    
  > [!NOTE]
  > <span data-ttu-id="34e61-129">開発者モードでアプリを Xbox One に展開するには、ユーザーを本体にサインインさせる必要があります。</span><span class="sxs-lookup"><span data-stu-id="34e61-129">Before you can deploy an app to your Xbox One in Developer Mode, you must have a user signed in on the console.</span></span> <span data-ttu-id="34e61-130">既存の Xbox Live アカウントを使用することも、開発者モードで本体の新しいアカウントを作成することもできます。</span><span class="sxs-lookup"><span data-stu-id="34e61-130">You can either use your existing Xbox Live account or create a new account for your console in Developer Mode.</span></span> 

## <a name="creating-your-first-project-in-visual-studio-2015"></a><span data-ttu-id="34e61-131">Visual Studio 2015 の初めてのプロジェクトの作成</span><span class="sxs-lookup"><span data-stu-id="34e61-131">Creating your first project in Visual Studio 2015</span></span>

<span data-ttu-id="34e61-132">詳しくは、「[開発環境のセットアップ](development-environment-setup.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="34e61-132">For more detailed information, see [Development environment setup](development-environment-setup.md).</span></span>

1.  <span data-ttu-id="34e61-133">**C# の場合**: 新しいユニバーサル Windows プロジェクトを作成し、プロジェクトのプロパティに移動して、**[デバッグ]** タブを選択し、**[ターゲット デバイス]** を **[リモート コンピューター]** に変更して、Xbox One コンソールの IP アドレスまたはホスト名を **[リモート コンピューター]** フィールドに入力し、**[認証モード]** のドロップダウン リストで **[ユニバーサル (暗号化されていないプロトコル)]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="34e61-133">**For C#**: Create a new Universal Windows project, go into the project properties and select the **Debug** tab, change **Target device** to **Remote Machine**, type the IP address or hostname of your Xbox One console into the **Remote machine** field, and select **Universal (Unencrypted Protocol)** in the **Authentication Mode** drop-down list.</span></span>   

    <span data-ttu-id="34e61-134">本体で Dev Home (ホーム画面の右側の大きなタイル) を開始すると、左上隅に Xbox One の IP アドレスが表示されます。</span><span class="sxs-lookup"><span data-stu-id="34e61-134">You can find your Xbox One IP address by starting Dev Home on your console (the big tile on the right side of Home) and looking at the top left corner.</span></span> <span data-ttu-id="34e61-135">Dev Home について詳しくは、「[Xbox One ツールの概要](introduction-to-xbox-tools.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="34e61-135">For more information about Dev Home, see [Introduction to Xbox One tools](introduction-to-xbox-tools.md).</span></span>  

2.  <span data-ttu-id="34e61-136">**C++ と HTML/Javascript プロジェクトの場合**: 同様の手順を行いますが、プロジェクトのプロパティで **[デバッグ]** タブに移動し、デバッガーで **[リモート コンピューター]** を選択してドロップダウン リストを開き、**[コンピューター名]** フィールドに本体の IP アドレスまたはホスト名を入力して、**[認証の種類]** フィールドで **[ユニバーサル (暗号化されていないプロトコル)]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="34e61-136">**For C++ and HTML/Javascript projects**:  You follow a similar path, but in project properties go to the **Debugging** tab, select **Remote Machine** in the Debugger to open the drop-down list, type the IP address or hostname of the console into the **Machine Name** field, and select **Universal (Unencrypted Protocol)** in the **Authentication Type** field.</span></span>
   
3.  <span data-ttu-id="34e61-137">F5 キーを押してアプリをビルドして、Xbox One での展開を開始します。</span><span class="sxs-lookup"><span data-stu-id="34e61-137">When you press F5, your app will build and start to deploy on your Xbox One.</span></span>
  
4.  <span data-ttu-id="34e61-138">初めてこれを行う際には、Visual Studio に Xbox One の PIN の入力を求められます。</span><span class="sxs-lookup"><span data-stu-id="34e61-138">The first time you do this, Visual Studio will prompt you for a PIN for your Xbox One.</span></span> <span data-ttu-id="34e61-139">Xbox One で Dev Home を開始して、**[Pair with Visual Studio]** ボタンを選択すると PIN を取得できます。</span><span class="sxs-lookup"><span data-stu-id="34e61-139">You can get a PIN by starting Dev Home on your Xbox One and selecting the **Pair with Visual Studio** button.</span></span>
  
5.  <span data-ttu-id="34e61-140">ペアリングを行うと、アプリの展開が開始されます。</span><span class="sxs-lookup"><span data-stu-id="34e61-140">After you have paired, your app will start to deploy.</span></span> <span data-ttu-id="34e61-141">初めてこれを行う際には、(すべてのツールを Xbox にコピーする必要があるため) 少し時間がかかることがありますが、数分以上かかる場合には、何か問題がある場合があります。</span><span class="sxs-lookup"><span data-stu-id="34e61-141">The first time you do this it might be a bit slow (we have to copy all the tools over to your Xbox), but if it takes more than a few minutes, something is probably wrong.</span></span> <span data-ttu-id="34e61-142">上記のすべての手順を実行していることを確認します (特に **[認証モード]** を **[ユニバーサル]** に設定していることを確認します)。また Xbox One に有線接続していることを確認します。</span><span class="sxs-lookup"><span data-stu-id="34e61-142">Make sure that you have followed all of the steps above (particularly, did you set the **Authentication Mode** to **Universal**?) and that you are using a wired network connection to your Xbox One.</span></span>  

6. <span data-ttu-id="34e61-143">用意ができました。</span><span class="sxs-lookup"><span data-stu-id="34e61-143">Sit back and relax.</span></span> <span data-ttu-id="34e61-144">本体での初めてのアプリの実行をお楽しみください。</span><span class="sxs-lookup"><span data-stu-id="34e61-144">Enjoy your first app running on the console!</span></span>  

## <a name="thats-it"></a><span data-ttu-id="34e61-145">以上で作業は終了です。</span><span class="sxs-lookup"><span data-stu-id="34e61-145">That's it!</span></span>

![Hello World](images/getting-started-hello-world.png)

## <a name="see-also"></a><span data-ttu-id="34e61-147">参照</span><span class="sxs-lookup"><span data-stu-id="34e61-147">See also</span></span>  
- [<span data-ttu-id="34e61-148">FAQ</span><span class="sxs-lookup"><span data-stu-id="34e61-148">FAQ</span></span>](frequently-asked-questions.md)  
- [<span data-ttu-id="34e61-149">既知の問題</span><span class="sxs-lookup"><span data-stu-id="34e61-149">Known issues</span></span>](known-issues.md)
- [<span data-ttu-id="34e61-150">Xbox One の UWP</span><span class="sxs-lookup"><span data-stu-id="34e61-150">UWP on Xbox One</span></span>](index.md) 
