---
author: v-angraf
ms.assetid: a56156e4-7adb-bf37-527b-fc3243e04b46
title: コンソール (Dev ホーム) に開発ホーム
description: Xbox 1 つの開発ホーム アプリについてを説明します。
ms.author: v-angraf@microsoft.com
ms.date: 08/09/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
permalink: en-us/docs/xdk/dev-home.html
ms.localizationpriority: medium
ms.openlocfilehash: 3b802b9b53811e03e11ee3afd78f69db4bfd9986
ms.sourcegitcommit: 897a111e8fc5d38d483800288ad01c523e924ef4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/13/2018
ms.locfileid: "1015361"
---
# <a name="developer-home-on-the-console-dev-home"></a><span data-ttu-id="1beea-104">コンソール (Dev ホーム) に開発ホーム</span><span class="sxs-lookup"><span data-stu-id="1beea-104">Developer Home on the Console (Dev Home)</span></span>
   
  
<span data-ttu-id="1beea-105">開発ホームは、開発者の生産性を支援するために設計された Xbox 1 つの開発キットのツール エクスペリエンスです。</span><span class="sxs-lookup"><span data-stu-id="1beea-105">Dev Home is a tools experience on the Xbox One development kit designed to aid developer productivity.</span></span> <span data-ttu-id="1beea-106">開発ホーム キャプチャし、トレースを管理して、開発キットを構成する、ユーザーを管理する、インストールされているタイトルを起動して実行するための機能を提供します。</span><span class="sxs-lookup"><span data-stu-id="1beea-106">Dev Home offers functionality to manage and configure your development kit, manage users, launch installed titles and perform captures and traces.</span></span> <span data-ttu-id="1beea-107">将来のリリースで引き続きのフィードバックには、その他の機能を有効にして、機能拡張と独自のツールの追加を有効にする機能を拡張します。</span><span class="sxs-lookup"><span data-stu-id="1beea-107">In future releases we will continue to expand the functionality to enable additional features based on your feedback, and also to enable extensibility and the addition of your own tools.</span></span>   
   
  
<span data-ttu-id="1beea-108">開発ホームと表示をサポートする、最も興味のあるシナリオに関するフィードバックを非常に興味います。</span><span class="sxs-lookup"><span data-stu-id="1beea-108">We are very interested in your feedback on Dev Home and the scenarios you are most interested in seeing it support.</span></span> <span data-ttu-id="1beea-109">アプリのメイン メニューの [**フィードバックの送信**に説明する方法または開発アカウント マネージャー (DAM) を通じて、コメントを入力してください。</span><span class="sxs-lookup"><span data-stu-id="1beea-109">Please provide your comments through the methods described under **Send Feedback** in the main menu of the app or through your Developer Account Manager (DAM).</span></span>   
   
  
<span data-ttu-id="1beea-110">年 2015年 11 月で開発ホームまたはそれ以降の回復を起動します。</span><span class="sxs-lookup"><span data-stu-id="1beea-110">To launch Dev Home on the November 2015 or later recovery:</span></span>  
 
   1. <span data-ttu-id="1beea-111">[ホーム]、または二重 Nexus] ボタンをクリックすると移動して、ガイドを開く</span><span class="sxs-lookup"><span data-stu-id="1beea-111">Open the guide by moving left on Home, or double clicking the Nexus button</span></span>  
   1. <span data-ttu-id="1beea-112">**設定**(歯車アイコン) を作成します。</span><span class="sxs-lookup"><span data-stu-id="1beea-112">Move down to **Settings** (the gear icon)</span></span>   
   1. <span data-ttu-id="1beea-113">**すべての設定**を選択します。</span><span class="sxs-lookup"><span data-stu-id="1beea-113">Select **All settings**</span></span>  
   1. <span data-ttu-id="1beea-114">既定の **[開発**] ページで、**開発ホーム**([ホーム] のアイコン) を選択します。</span><span class="sxs-lookup"><span data-stu-id="1beea-114">From the default **Developer** page, select **Developer Home** (the home icon)</span></span>   

 ![](images/dev_home_icons.png)   
  
<span data-ttu-id="1beea-115">以前の回復の開発ホーム タイル、ホーム画面の右側にある**おすすめコンテンツ**のまたは Xbox 1 人のマネージャーでアプリケーションの一覧を表示を**開発ホーム**を起動します。</span><span class="sxs-lookup"><span data-stu-id="1beea-115">On earlier recoveries select the Dev Home tile on the right side of the home screen in **featured content** or view the application list in Xbox One Manager and launch **Dev Home**.</span></span>   
 ![](images/dev_home_1.png) 
<a id="ID4EBC"></a>

   

## <a name="user-interface"></a><span data-ttu-id="1beea-116">ユーザー インターフェイス</span><span class="sxs-lookup"><span data-stu-id="1beea-116">User Interface</span></span>  
   
  
<span data-ttu-id="1beea-117">開発ホーム ユーザー インターフェイスのヘッダーには、次の「ひとめ」重要なが含まれている開発コンソールについての情報。</span><span class="sxs-lookup"><span data-stu-id="1beea-117">The header of the Dev Home user interface contains the following important "at a glance" info about the development console:</span></span>   
 
   *  <span data-ttu-id="1beea-118">**コンソール IP:** コンソールの現在の IP アドレス。</span><span class="sxs-lookup"><span data-stu-id="1beea-118">**Console IP:** The current IP address of the console.</span></span>   
   *  <span data-ttu-id="1beea-119">**コンソール名:** コンソールの現在のホスト名です。</span><span class="sxs-lookup"><span data-stu-id="1beea-119">**Console name:** The current hostname of the console.</span></span>  
   *  <span data-ttu-id="1beea-120">**サンド ボックス:** サンド ボックスに、コンソールがあるの名前。</span><span class="sxs-lookup"><span data-stu-id="1beea-120">**Sandbox:** The name of the sandbox that the console is in.</span></span>  
   *  <span data-ttu-id="1beea-121">**OS のバージョン:** コンソールで実行されている現在の回復バージョン。</span><span class="sxs-lookup"><span data-stu-id="1beea-121">**OS version:** The current recovery version that is running on the console.</span></span>
   *  <span data-ttu-id="1beea-122">システムの現在の時刻。</span><span class="sxs-lookup"><span data-stu-id="1beea-122">Current system time.</span></span>   

   
  
<span data-ttu-id="1beea-123">開発ホーム UI の残りの部分は、次のページに分けられます。</span><span class="sxs-lookup"><span data-stu-id="1beea-123">The rest of the Dev Home UI is divided into the following pages.</span></span> <span data-ttu-id="1beea-124">これらのページで、ツールの詳細については、個々 のトピックを参照してください。</span><span class="sxs-lookup"><span data-stu-id="1beea-124">For more information about the tools on these pages, see their individual topics.</span></span>   
 
   *  [<span data-ttu-id="1beea-125">ホーム</span><span class="sxs-lookup"><span data-stu-id="1beea-125">Home</span></span>](devhome-home.md)  
   *  [<span data-ttu-id="1beea-126">Xbox Live</span><span class="sxs-lookup"><span data-stu-id="1beea-126">Xbox Live</span></span>](devhome-live.md)  
   *  [<span data-ttu-id="1beea-127">設定</span><span class="sxs-lookup"><span data-stu-id="1beea-127">Settings</span></span>](devhome-settings.md)  
   *  [<span data-ttu-id="1beea-128">メディアのキャプチャ</span><span class="sxs-lookup"><span data-stu-id="1beea-128">Media capture</span></span>](devhome-capture.md)  
   *  [<span data-ttu-id="1beea-129">ネットワーク</span><span class="sxs-lookup"><span data-stu-id="1beea-129">Networking</span></span>](devhome-networking.md)  
   *  [<span data-ttu-id="1beea-130">パフォーマンス</span><span class="sxs-lookup"><span data-stu-id="1beea-130">Performance</span></span>](devhome-performance.md)  

  
<a id="ID4EKE"></a>

   

## <a name="main-menu"></a><span data-ttu-id="1beea-131">メイン メニュー</span><span class="sxs-lookup"><span data-stu-id="1beea-131">Main Menu</span></span>  
   
  
<span data-ttu-id="1beea-132">コント ローラーの [**メニュー** ] ボタンを押すと、アプリケーションのワークスペースについては、アプリでフィードバックを提供するネットワーク上の場所にアクセスするための資格情報を管理する機能を設定できるメイン メニューにアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="1beea-132">By pressing the **menu** button on your controller, you can access the main menu that allows configuration of the app workspace, the ability to manage credentials for accessing network locations and information on providing feedback on the app.</span></span>   
  
<a id="ID4EUE"></a>

   

## <a name="snap-mode-ux"></a><span data-ttu-id="1beea-133">スナップ モードのユーザー エクスペリエンス</span><span class="sxs-lookup"><span data-stu-id="1beea-133">Snap Mode UX</span></span>  
   
  
<span data-ttu-id="1beea-134">ネットワークとマルチプレイヤーなどの開発ホームにいくつかの既存と今後のツールが使用するためできるようにするツールに簡単にアクセスをテストしているときに、タイトルを実行しているときに側にスナップします。</span><span class="sxs-lookup"><span data-stu-id="1beea-134">Several existing and upcoming tools in Dev Home, such as Networking and Multiplayer, are designed to be used snapped to the side while you are running your title, so that you can have easy access to tools while you are testing.</span></span>   
   
  
<span data-ttu-id="1beea-135">スナップ モードにアクセスするには、[適切なツールのタイトルを強調表示コント ローラー、[**ビュー** ] ボタンを押した、コンテキスト メニューの [**スナップ**] を選びます。</span><span class="sxs-lookup"><span data-stu-id="1beea-135">To access Snap mode, highlight the title of the appropriate tool, press the **view** button on your controller, and select **snap** from the context menu:</span></span>  
 ![](images/dev_home_4.png)   
  
<span data-ttu-id="1beea-136">Dev Home は右にスナップします。</span><span class="sxs-lookup"><span data-stu-id="1beea-136">Dev Home will snap right.</span></span> <span data-ttu-id="1beea-137">通常どおり [連結] ボタンをダブル タップすると、コンテキストを切り替えることができます。</span><span class="sxs-lookup"><span data-stu-id="1beea-137">You can switch context by double tapping the Nexus button as usual.</span></span>  
 ![](images/dev_home_5.png)  
<a id="ID4EKF"></a>

   

## <a name="customizing-dev-home"></a><span data-ttu-id="1beea-138">Dev Home のカスタマイズ</span><span class="sxs-lookup"><span data-stu-id="1beea-138">Customizing Dev Home</span></span>  
   
  
<span data-ttu-id="1beea-139">Dev Home は、カスタマイズして個人用に設定できるように設計されています。</span><span class="sxs-lookup"><span data-stu-id="1beea-139">Dev Home has been designed to be customizable and personal.</span></span> <span data-ttu-id="1beea-140">、ワークフローを好きなように、アプリを構成して、ワークスペースとして保存することができます。</span><span class="sxs-lookup"><span data-stu-id="1beea-140">You can configure the app to suit your workflow, and then save that as a workspace.</span></span> <span data-ttu-id="1beea-141">このワークスペースをエクスポートして、できるので、インポートしたレイアウトを他のコンソールにコピーすることが必要です。</span><span class="sxs-lookup"><span data-stu-id="1beea-141">This workspace can be exported and imported, allowing you to copy the layout to other consoles as needed.</span></span> <span data-ttu-id="1beea-142">**ワークスペース**のメイン メニューでは、これらのオプションが表示されます。</span><span class="sxs-lookup"><span data-stu-id="1beea-142">These options are found in the main menu under **workspace**.</span></span> <span data-ttu-id="1beea-143">エクスポートしたファイルはでスクラッチ システム ドライブにある、`Dev Home\Workspaces`ディレクトリ。</span><span class="sxs-lookup"><span data-stu-id="1beea-143">The exported file will be located on the system scratch drive in the `Dev Home\Workspaces` directory.</span></span>   
 
<a id="ID4EVF"></a>

   

### <a name="resizing-and-reordering-tools"></a><span data-ttu-id="1beea-144">サイズを変更し、ツールの順序を変更します。</span><span class="sxs-lookup"><span data-stu-id="1beea-144">Resizing and Reordering Tools</span></span>  
   
  
<span data-ttu-id="1beea-145">サイズまたはツールの位置を変更するのには、タイトルの中に、コンテキスト メニュー ボタン (コント ローラーの表示] ボタン) を使用してフォーカスがあります。</span><span class="sxs-lookup"><span data-stu-id="1beea-145">To change the size or position of a tool, use the context menu button (view button on your controller) while the title has focus.</span></span> <span data-ttu-id="1beea-146">コンテキスト メニューの [**移動**または**サイズ変更**を選択します。</span><span class="sxs-lookup"><span data-stu-id="1beea-146">From the context menu select **Move** or **Resize**.</span></span>   
 ![](images/dev_home_6.png)  
<a id="ID4EEG"></a>

   

### <a name="changing-theme-color-and-background-image"></a><span data-ttu-id="1beea-147">テーマの色と背景画像の変更</span><span class="sxs-lookup"><span data-stu-id="1beea-147">Changing theme color and background image</span></span>  
   
  
<span data-ttu-id="1beea-148">[メイン] メニューから**ワークスペース**し、[**テーマの色の変更**を選択します。</span><span class="sxs-lookup"><span data-stu-id="1beea-148">From the Main Menu, you can select **Workspace** and then **Change theme color**.</span></span> <span data-ttu-id="1beea-149">新しい色を選択し、**保存**フォーカスが強調表示するテーマの色を更新する] を選択します。</span><span class="sxs-lookup"><span data-stu-id="1beea-149">Select a new color and select **Save** to update the theme color used for focus highlighting.</span></span>   
 ![](images/dev_home_7.png)  
<a id="ID4EVG"></a>

   

### <a name="setting-the-default-application-for-a-package"></a><span data-ttu-id="1beea-150">パッケージの既定のアプリケーションの設定</span><span class="sxs-lookup"><span data-stu-id="1beea-150">Setting the default application for a package</span></span>  
   
  
<span data-ttu-id="1beea-151">パッケージに複数のアプリケーションが含まれている場合 Dev ホームすることが起動されるように既定のアプリケーションを設定します。</span><span class="sxs-lookup"><span data-stu-id="1beea-151">If a package contains multiple applications, Dev Home will allow you to set the default application to be launched.</span></span> <span data-ttu-id="1beea-152">起動ツールでパッケージをハイライトし **、利用可能なアプリケーションのリストを開くボタン**を押します。</span><span class="sxs-lookup"><span data-stu-id="1beea-152">Highlight the package in the launcher and press the **A** button to open the list of available applications.</span></span> <span data-ttu-id="1beea-153">1 つの既定として設定し**表示**] をクリックし、ショートカット メニューから [**既定値として設定**] を選びますしたいを強調表示します。</span><span class="sxs-lookup"><span data-stu-id="1beea-153">Highlight the one you wish to set as the default and press the **view** button, and then choose **Set as Default** from the context menu.</span></span>   
 ![](images/dev_home_setdefault.png)  
<a id="ID4EGH"></a>

   

### <a name="using-dev-home-to-register-and-launch-titles-from-a-network-share"></a><span data-ttu-id="1beea-154">開発ホームを使用して登録して、ネットワーク共有にタイトルを起動するには</span><span class="sxs-lookup"><span data-stu-id="1beea-154">Using Dev Home to register and launch titles from a network share</span></span>  
   
  
<span data-ttu-id="1beea-155">インストール済みのアプリとゲーム] ボックスの一覧の下部にある、起動ツールからには、タイトルの柔軟なファイルのバージョンをリモートで実行する**ネットワーク共有からゲームを登録する**オプションを選択することができます。</span><span class="sxs-lookup"><span data-stu-id="1beea-155">From the launcher, at the bottom of the installed apps and games list, you can select the option **Register a game from a network share** to run a loose file version of a title remotely.</span></span>   
 ![](images/dev_home_8.png)   
  
<span data-ttu-id="1beea-156">登録したいタイトルとして appxmanifest.xml ファイルにネットワーク パスを入力することができます。</span><span class="sxs-lookup"><span data-stu-id="1beea-156">You can then enter the network path to the appxmanifest.xml file for the title you wish to register.</span></span> <span data-ttu-id="1beea-157">開発ホームは、共有するため、既存の資格情報を使用してタイトルを登録しようとしていますと if 新しいネットワークの資格情報を求めるために必要な表示されます。</span><span class="sxs-lookup"><span data-stu-id="1beea-157">Dev Home will attempt to register the title using any existing credentials for that share, and if needed will prompt for new network credentials.</span></span> <span data-ttu-id="1beea-158">その他の共有 (たとえばリソースにアクセスするシンボリック リンクされている別のサーバー上) にアクセスする必要がある場合は、次のオプションを使用して、追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="1beea-158">If you need to access additional shares (for example to access symbolically linked resources on a separate server) then you will need to add those via the option below.</span></span>   
   
  
<span data-ttu-id="1beea-159">これらの格納された資格情報を管理する (を追加)、メイン メニューの**ネットワークの資格情報を管理する**オプションを使用してコンソールにします。</span><span class="sxs-lookup"><span data-stu-id="1beea-159">You can manage these stored credentials (and add additional ones) on the console via the main menu's **Manage network credentials** option.</span></span>   
 ![](images/dev_home_9.png)   
  
<span data-ttu-id="1beea-160">コンソールに現在の資格情報を表示し、資格情報を編集するには、資格情報のパスを選択し、**ボタン**をクリックすると、資格情報を削除するには、リンクの削除] を選択し、**ボタン**をクリックすることができます。</span><span class="sxs-lookup"><span data-stu-id="1beea-160">You can view the credentials currently on the console, edit credentials by selecting the path of the credential and clicking **A** button and remove a credential by selecting the remove link and clicking **A** button.</span></span>   
   
<a id="ID4EGAAC"></a>

   

## <a name="in-this-section"></a><span data-ttu-id="1beea-161">このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="1beea-161">In this section</span></span>  
  
[<span data-ttu-id="1beea-162">ホーム ページ (Dev ホーム)</span><span class="sxs-lookup"><span data-stu-id="1beea-162">Home Page (Dev Home)</span></span>](devhome-home.md)  


<span data-ttu-id="1beea-163">&nbsp;&nbsp;開発コンソールにさらに定期的に実行されるタスクへのすばやいアクセスを提供します。</span><span class="sxs-lookup"><span data-stu-id="1beea-163">&nbsp;&nbsp;Provides quick access to the tasks that are routinely performed on a development console.</span></span> 
  
  
[<span data-ttu-id="1beea-164">Xbox Live ページ (Dev ホーム)</span><span class="sxs-lookup"><span data-stu-id="1beea-164">Xbox Live Page (Dev Home)</span></span>](devhome-live.md)  


<span data-ttu-id="1beea-165">&nbsp;&nbsp;マルチ プレーヤーの情報を収集し、Xbox Live サービスの現在の状態を表示します。</span><span class="sxs-lookup"><span data-stu-id="1beea-165">&nbsp;&nbsp;Captures multiplayer information and displays the current status of the Xbox Live service.</span></span> 
  
  
[<span data-ttu-id="1beea-166">設定] ページ (Dev ホーム)</span><span class="sxs-lookup"><span data-stu-id="1beea-166">Settings Page (Dev Home)</span></span>](devhome-settings.md)  


<span data-ttu-id="1beea-167">&nbsp;&nbsp;開発コンソールのさまざまな設定には、アクセスを提供します。</span><span class="sxs-lookup"><span data-stu-id="1beea-167">&nbsp;&nbsp;Provides access to various settings for the development console.</span></span> 
  
  
[<span data-ttu-id="1beea-168">メディア ページ (Dev ホーム) を取得します。</span><span class="sxs-lookup"><span data-stu-id="1beea-168">Media Capture Page (Dev Home)</span></span>](devhome-capture.md)  


<span data-ttu-id="1beea-169">&nbsp;&nbsp;**メディアをキャプチャ**Dev ホーム ページでは、タイトル コンソールで現在実行中のビデオをキャプチャします。</span><span class="sxs-lookup"><span data-stu-id="1beea-169">&nbsp;&nbsp;The **Media capture** page of Dev Home captures video of the title that is currently running on the console.</span></span> 
  
  
[<span data-ttu-id="1beea-170">[ネットワーク] ページ (Dev ホーム)</span><span class="sxs-lookup"><span data-stu-id="1beea-170">Networking Page (Dev Home)</span></span>](devhome-networking.md)  


<span data-ttu-id="1beea-171">&nbsp;&nbsp;トラブルシューティングのためのさまざまなネットワークの状態をシミュレートします。</span><span class="sxs-lookup"><span data-stu-id="1beea-171">&nbsp;&nbsp;Simulates various networking conditions for troubleshooting purposes.</span></span> 
  
  
[<span data-ttu-id="1beea-172">パフォーマンスのページ (Dev ホーム)</span><span class="sxs-lookup"><span data-stu-id="1beea-172">Performance Page (Dev Home)</span></span>](devhome-performance.md)  


<span data-ttu-id="1beea-173">&nbsp;&nbsp;さまざまなディスクのアクティビティやトラブルシューティングのための CPU 使用条件をシミュレートします。</span><span class="sxs-lookup"><span data-stu-id="1beea-173">&nbsp;&nbsp;Simulates various disk activity and CPU usage conditions for troubleshooting purposes.</span></span> 
 