---
author: v-angraf
ms.assetid: a56156e4-7adb-bf37-527b-fc3243e04b46
title: コンソール (Dev Home) における開発者ホーム
description: Xbox one Dev Home アプリについてを説明します。
ms.author: v-angraf@microsoft.com
ms.date: 08/09/2017
ms.topic: article
keywords: Windows 10, UWP
permalink: en-us/docs/xdk/dev-home.html
ms.localizationpriority: medium
ms.openlocfilehash: 232770ab4b746663a105982605d1cedcb92adbe3
ms.sourcegitcommit: 3257416aebb5a7b1515e107866806f8bd57845a8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/17/2018
ms.locfileid: "7150348"
---
# <a name="developer-home-on-the-console-dev-home"></a><span data-ttu-id="356c6-104">コンソール (Dev Home) における開発者ホーム</span><span class="sxs-lookup"><span data-stu-id="356c6-104">Developer Home on the Console (Dev Home)</span></span>
   
  
<span data-ttu-id="356c6-105">Dev Home は、開発者の生産性を支援するために設計された Xbox One 開発キット上のツール エクスペリエンスです。</span><span class="sxs-lookup"><span data-stu-id="356c6-105">Dev Home is a tools experience on the Xbox One development kit designed to aid developer productivity.</span></span> <span data-ttu-id="356c6-106">Dev Home は、管理し、開発キットを構成する、ユーザーの管理、インストールされているタイトルを起動および実行するための機能をキャプチャし、トレースを提供します。</span><span class="sxs-lookup"><span data-stu-id="356c6-106">Dev Home offers functionality to manage and configure your development kit, manage users, launch installed titles and perform captures and traces.</span></span> <span data-ttu-id="356c6-107">将来のリリースで引き続きお客様のフィードバックに基づいて、追加の機能を有効にして、拡張機能と、独自のツールの追加を有効にする機能を拡張します。</span><span class="sxs-lookup"><span data-stu-id="356c6-107">In future releases we will continue to expand the functionality to enable additional features based on your feedback, and also to enable extensibility and the addition of your own tools.</span></span>   
   
  
<span data-ttu-id="356c6-108">Dev Home と表示をサポートする最も興味のあるシナリオでお客様のフィードバックに非常に関心を持つしています。</span><span class="sxs-lookup"><span data-stu-id="356c6-108">We are very interested in your feedback on Dev Home and the scenarios you are most interested in seeing it support.</span></span> <span data-ttu-id="356c6-109">[**フィードバックの送信**、アプリのメイン メニューで説明した方法またはデベロッパー アカウント マネージャー (DAM) を通じて、コメントを提供してください。</span><span class="sxs-lookup"><span data-stu-id="356c6-109">Please provide your comments through the methods described under **Send Feedback** in the main menu of the app or through your Developer Account Manager (DAM).</span></span>   
   
  
<span data-ttu-id="356c6-110">2015 年 11 月で Dev Home またはそれ以降の回復を起動します。</span><span class="sxs-lookup"><span data-stu-id="356c6-110">To launch Dev Home on the November 2015 or later recovery:</span></span>  
 
   1. <span data-ttu-id="356c6-111">移動、自宅で左または double Nexus ボタンをクリックして、ガイドを開く</span><span class="sxs-lookup"><span data-stu-id="356c6-111">Open the guide by moving left on Home, or double clicking the Nexus button</span></span>  
   1. <span data-ttu-id="356c6-112">**設定**(歯車アイコン) を作成します。</span><span class="sxs-lookup"><span data-stu-id="356c6-112">Move down to **Settings** (the gear icon)</span></span>   
   1. <span data-ttu-id="356c6-113">**すべての設定**を選択します。</span><span class="sxs-lookup"><span data-stu-id="356c6-113">Select **All settings**</span></span>  
   1. <span data-ttu-id="356c6-114">既定の**開発者**のページから**開発者 Home** (ホーム アイコン) を選択します。</span><span class="sxs-lookup"><span data-stu-id="356c6-114">From the default **Developer** page, select **Developer Home** (the home icon)</span></span>   

 ![](images/dev_home_icons.png)   
  
<span data-ttu-id="356c6-115">以前の回復の**コンテンツの機能を備えた**で、ホーム画面の右側にある Dev Home タイルを選択または Xbox One Manager でアプリケーションの一覧を表示し、 **Dev Home**を起動します。</span><span class="sxs-lookup"><span data-stu-id="356c6-115">On earlier recoveries select the Dev Home tile on the right side of the home screen in **featured content** or view the application list in Xbox One Manager and launch **Dev Home**.</span></span>   
 ![](images/dev_home_1.png) 
<a id="ID4EBC"></a>

   

## <a name="user-interface"></a><span data-ttu-id="356c6-116">ユーザー インターフェイス</span><span class="sxs-lookup"><span data-stu-id="356c6-116">User Interface</span></span>  
   
  
<span data-ttu-id="356c6-117">Dev Home のユーザー インターフェイスのヘッダーには、次の重要な"概要"が含まれている開発機本体に関する情報。</span><span class="sxs-lookup"><span data-stu-id="356c6-117">The header of the Dev Home user interface contains the following important "at a glance" info about the development console:</span></span>   
 
   *  <span data-ttu-id="356c6-118">**本体の IP:** コンソールの現在の IP アドレス。</span><span class="sxs-lookup"><span data-stu-id="356c6-118">**Console IP:** The current IP address of the console.</span></span>   
   *  <span data-ttu-id="356c6-119">**コンソール名:** コンソールの現在のホスト名。</span><span class="sxs-lookup"><span data-stu-id="356c6-119">**Console name:** The current hostname of the console.</span></span>  
   *  <span data-ttu-id="356c6-120">**サンド ボックス:** 本体で公開されているサンド ボックスの名前です。</span><span class="sxs-lookup"><span data-stu-id="356c6-120">**Sandbox:** The name of the sandbox that the console is in.</span></span>  
   *  <span data-ttu-id="356c6-121">**OS のバージョン:** 本体で実行されている現在の回復バージョン。</span><span class="sxs-lookup"><span data-stu-id="356c6-121">**OS version:** The current recovery version that is running on the console.</span></span>
   *  <span data-ttu-id="356c6-122">現在のシステム時刻。</span><span class="sxs-lookup"><span data-stu-id="356c6-122">Current system time.</span></span>   

   
  
<span data-ttu-id="356c6-123">Dev Home の UI の残りの部分は、次のページに分かれています。</span><span class="sxs-lookup"><span data-stu-id="356c6-123">The rest of the Dev Home UI is divided into the following pages.</span></span> <span data-ttu-id="356c6-124">これらのページで、ツールについて詳しくは、自分の個々 のトピックを参照してください。</span><span class="sxs-lookup"><span data-stu-id="356c6-124">For more information about the tools on these pages, see their individual topics.</span></span>   
 
   *  [<span data-ttu-id="356c6-125">ホーム</span><span class="sxs-lookup"><span data-stu-id="356c6-125">Home</span></span>](devhome-home.md)  
   *  [<span data-ttu-id="356c6-126">Xbox Live</span><span class="sxs-lookup"><span data-stu-id="356c6-126">Xbox Live</span></span>](devhome-live.md)  
   *  [<span data-ttu-id="356c6-127">Settings</span><span class="sxs-lookup"><span data-stu-id="356c6-127">Settings</span></span>](devhome-settings.md)  
   *  [<span data-ttu-id="356c6-128">メディアのキャプチャ</span><span class="sxs-lookup"><span data-stu-id="356c6-128">Media capture</span></span>](devhome-capture.md)  
   *  [<span data-ttu-id="356c6-129">ネットワーク</span><span class="sxs-lookup"><span data-stu-id="356c6-129">Networking</span></span>](devhome-networking.md)  
   *  [<span data-ttu-id="356c6-130">パフォーマンス</span><span class="sxs-lookup"><span data-stu-id="356c6-130">Performance</span></span>](devhome-performance.md)  

  
<a id="ID4EKE"></a>

   

## <a name="main-menu"></a><span data-ttu-id="356c6-131">メイン メニュー</span><span class="sxs-lookup"><span data-stu-id="356c6-131">Main Menu</span></span>  
   
  
<span data-ttu-id="356c6-132">コント ローラーの**メニュー**ボタンを押して、アプリ] ワークスペースで、ネットワークの場所と、アプリでフィードバックを提供することに関する情報にアクセスするための資格情報を管理する機能の構成が許可されるメイン メニューを表示できます。</span><span class="sxs-lookup"><span data-stu-id="356c6-132">By pressing the **menu** button on your controller, you can access the main menu that allows configuration of the app workspace, the ability to manage credentials for accessing network locations and information on providing feedback on the app.</span></span>   
  
<a id="ID4EUE"></a>

   

## <a name="snap-mode-ux"></a><span data-ttu-id="356c6-133">スナップ モード UX</span><span class="sxs-lookup"><span data-stu-id="356c6-133">Snap Mode UX</span></span>  
   
  
<span data-ttu-id="356c6-134">マルチプレイヤーでは、ネットワークなど、Dev Home でいくつかの既存と今後予定されているツールは、できるようにするツールに簡単にアクセスをテストするときは、タイトルの実行中に、端にスナップ使用される設計されています。</span><span class="sxs-lookup"><span data-stu-id="356c6-134">Several existing and upcoming tools in Dev Home, such as Networking and Multiplayer, are designed to be used snapped to the side while you are running your title, so that you can have easy access to tools while you are testing.</span></span>   
   
  
<span data-ttu-id="356c6-135">スナップ モードにアクセスするに適切なツールのタイトルを強調表示して、コント ローラーの**ビュー**ボタンを押して、**スナップ**コンテキスト メニューを選択します。</span><span class="sxs-lookup"><span data-stu-id="356c6-135">To access Snap mode, highlight the title of the appropriate tool, press the **view** button on your controller, and select **snap** from the context menu:</span></span>  
 ![](images/dev_home_4.png)   
  
<span data-ttu-id="356c6-136">Dev Home は右にスナップします。</span><span class="sxs-lookup"><span data-stu-id="356c6-136">Dev Home will snap right.</span></span> <span data-ttu-id="356c6-137">通常どおり [連結] ボタンをダブル タップすると、コンテキストを切り替えることができます。</span><span class="sxs-lookup"><span data-stu-id="356c6-137">You can switch context by double tapping the Nexus button as usual.</span></span>  
 ![](images/dev_home_5.png)  
<a id="ID4EKF"></a>

   

## <a name="customizing-dev-home"></a><span data-ttu-id="356c6-138">Dev Home のカスタマイズ</span><span class="sxs-lookup"><span data-stu-id="356c6-138">Customizing Dev Home</span></span>  
   
  
<span data-ttu-id="356c6-139">Dev Home は、カスタマイズして個人用に設定できるように設計されています。</span><span class="sxs-lookup"><span data-stu-id="356c6-139">Dev Home has been designed to be customizable and personal.</span></span> <span data-ttu-id="356c6-140">取引先企業、ワークスペースとして保存するワークフローに合わせてアプリを構成できます。</span><span class="sxs-lookup"><span data-stu-id="356c6-140">You can configure the app to suit your workflow, and then save that as a workspace.</span></span> <span data-ttu-id="356c6-141">このワークスペースをエクスポートし、できるので、インポートされたレイアウトとして他の本体にコピーすることです。</span><span class="sxs-lookup"><span data-stu-id="356c6-141">This workspace can be exported and imported, allowing you to copy the layout to other consoles as needed.</span></span> <span data-ttu-id="356c6-142">これらのオプション **] ワークスペース**で、メイン メニューがあります。</span><span class="sxs-lookup"><span data-stu-id="356c6-142">These options are found in the main menu under **workspace**.</span></span> <span data-ttu-id="356c6-143">エクスポートされたファイルはシステム スクラッチ ドライブのある、`Dev Home\Workspaces`ディレクトリ。</span><span class="sxs-lookup"><span data-stu-id="356c6-143">The exported file will be located on the system scratch drive in the `Dev Home\Workspaces` directory.</span></span>   
 
<a id="ID4EVF"></a>

   

### <a name="resizing-and-reordering-tools"></a><span data-ttu-id="356c6-144">サイズ変更とツールの並べ替え</span><span class="sxs-lookup"><span data-stu-id="356c6-144">Resizing and Reordering Tools</span></span>  
   
  
<span data-ttu-id="356c6-145">サイズやツールの位置を変更するには、コンテキスト メニュー ボタン (コント ローラーのビュー ボタン) を使用して、タイトルの中にフォーカスがあります。</span><span class="sxs-lookup"><span data-stu-id="356c6-145">To change the size or position of a tool, use the context menu button (view button on your controller) while the title has focus.</span></span> <span data-ttu-id="356c6-146">コンテキスト メニューから**移動**または**サイズ変更**を選択します。</span><span class="sxs-lookup"><span data-stu-id="356c6-146">From the context menu select **Move** or **Resize**.</span></span>   
 ![](images/dev_home_6.png)  
<a id="ID4EEG"></a>

   

### <a name="changing-theme-color-and-background-image"></a><span data-ttu-id="356c6-147">テーマの色と背景画像の変更</span><span class="sxs-lookup"><span data-stu-id="356c6-147">Changing theme color and background image</span></span>  
   
  
<span data-ttu-id="356c6-148">メイン メニューから**ワークスペース**し、**テーマの色の変更**を選択できます。</span><span class="sxs-lookup"><span data-stu-id="356c6-148">From the Main Menu, you can select **Workspace** and then **Change theme color**.</span></span> <span data-ttu-id="356c6-149">新しい色を選択し、フォーカスが強調表示されたテーマの色を更新する**保存**をを選択します。</span><span class="sxs-lookup"><span data-stu-id="356c6-149">Select a new color and select **Save** to update the theme color used for focus highlighting.</span></span>   
 ![](images/dev_home_7.png)  
<a id="ID4EVG"></a>

   

### <a name="setting-the-default-application-for-a-package"></a><span data-ttu-id="356c6-150">パッケージの既定のアプリケーションの設定</span><span class="sxs-lookup"><span data-stu-id="356c6-150">Setting the default application for a package</span></span>  
   
  
<span data-ttu-id="356c6-151">パッケージに複数のアプリケーションが含まれている場合 Dev Home を起動する既定のアプリケーションを設定することが許可されます。</span><span class="sxs-lookup"><span data-stu-id="356c6-151">If a package contains multiple applications, Dev Home will allow you to set the default application to be launched.</span></span> <span data-ttu-id="356c6-152">ランチャーでパッケージを強調表示し、利用可能なアプリケーションの一覧を開く、 **A**ボタンを押します。</span><span class="sxs-lookup"><span data-stu-id="356c6-152">Highlight the package in the launcher and press the **A** button to open the list of available applications.</span></span> <span data-ttu-id="356c6-153">既定の設定し**表示**] ボタンを押すし、**既定として設定**コンテキスト メニューから選択するかを選択します。</span><span class="sxs-lookup"><span data-stu-id="356c6-153">Highlight the one you wish to set as the default and press the **view** button, and then choose **Set as Default** from the context menu.</span></span>   
 ![](images/dev_home_setdefault.png)  
<a id="ID4EGH"></a>

   

### <a name="using-dev-home-to-register-and-launch-titles-from-a-network-share"></a><span data-ttu-id="356c6-154">Dev Home を使用して登録し、ネットワーク共有からタイトルを起動するには</span><span class="sxs-lookup"><span data-stu-id="356c6-154">Using Dev Home to register and launch titles from a network share</span></span>  
   
  
<span data-ttu-id="356c6-155">インストール済みのアプリとゲームの一覧の下部にある、ランチャーからタイトルのルーズ ファイルのバージョンをリモートで実行する **、ネットワーク共有からゲームを登録する**オプションを選択できます。</span><span class="sxs-lookup"><span data-stu-id="356c6-155">From the launcher, at the bottom of the installed apps and games list, you can select the option **Register a game from a network share** to run a loose file version of a title remotely.</span></span>   
 ![](images/dev_home_8.png)   
  
<span data-ttu-id="356c6-156">登録するタイトルの appxmanifest.xml ファイルへのネットワーク パスを入力できます。</span><span class="sxs-lookup"><span data-stu-id="356c6-156">You can then enter the network path to the appxmanifest.xml file for the title you wish to register.</span></span> <span data-ttu-id="356c6-157">Dev Home は、その共有用の既存の資格情報を使用してタイトルを登録しようとします。 場合は新しいネットワーク資格情報を求めるために必要な表示されます。</span><span class="sxs-lookup"><span data-stu-id="356c6-157">Dev Home will attempt to register the title using any existing credentials for that share, and if needed will prompt for new network credentials.</span></span> <span data-ttu-id="356c6-158">(たとえばリソースにアクセスするシンボリック リンクされている別のサーバーに) 追加の共有にアクセスする必要がある場合は、以下のオプションを通じてこれらを追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="356c6-158">If you need to access additional shares (for example to access symbolically linked resources on a separate server) then you will need to add those via the option below.</span></span>   
   
  
<span data-ttu-id="356c6-159">これらの保存された資格情報の管理 (して追加)、メイン メニューの**ネットワーク資格情報の管理**オプションを使用して本体にします。</span><span class="sxs-lookup"><span data-stu-id="356c6-159">You can manage these stored credentials (and add additional ones) on the console via the main menu's **Manage network credentials** option.</span></span>   
 ![](images/dev_home_9.png)   
  
<span data-ttu-id="356c6-160">本体に現在の資格情報を表示、資格情報を編集するには、資格情報のパスを選択し、 **A**ボタンをクリックすると、および資格情報を削除するには、リンクの削除] を選択し、 **A**ボタンをクリックできます。</span><span class="sxs-lookup"><span data-stu-id="356c6-160">You can view the credentials currently on the console, edit credentials by selecting the path of the credential and clicking **A** button and remove a credential by selecting the remove link and clicking **A** button.</span></span>   
   
<a id="ID4EGAAC"></a>

   

## <a name="in-this-section"></a><span data-ttu-id="356c6-161">このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="356c6-161">In this section</span></span>  
  
[<span data-ttu-id="356c6-162">ホーム ページ (Dev Home)</span><span class="sxs-lookup"><span data-stu-id="356c6-162">Home Page (Dev Home)</span></span>](devhome-home.md)  


<span data-ttu-id="356c6-163">&nbsp;&nbsp;開発機本体で定期的に実行されるタスクへのクイック アクセスを提供します。</span><span class="sxs-lookup"><span data-stu-id="356c6-163">&nbsp;&nbsp;Provides quick access to the tasks that are routinely performed on a development console.</span></span> 
  
  
[<span data-ttu-id="356c6-164">Xbox Live ページ (Dev Home)</span><span class="sxs-lookup"><span data-stu-id="356c6-164">Xbox Live Page (Dev Home)</span></span>](devhome-live.md)  


<span data-ttu-id="356c6-165">&nbsp;&nbsp;マルチプレイヤーの情報をキャプチャーし、Xbox Live サービスの現在の状態が表示されます。</span><span class="sxs-lookup"><span data-stu-id="356c6-165">&nbsp;&nbsp;Captures multiplayer information and displays the current status of the Xbox Live service.</span></span> 
  
  
[<span data-ttu-id="356c6-166">[設定] ページ (Dev Home)</span><span class="sxs-lookup"><span data-stu-id="356c6-166">Settings Page (Dev Home)</span></span>](devhome-settings.md)  


<span data-ttu-id="356c6-167">&nbsp;&nbsp;開発機本体のさまざまな設定をへのアクセスを提供します。</span><span class="sxs-lookup"><span data-stu-id="356c6-167">&nbsp;&nbsp;Provides access to various settings for the development console.</span></span> 
  
  
[<span data-ttu-id="356c6-168">メディア キャプチャ ページ (Dev Home)</span><span class="sxs-lookup"><span data-stu-id="356c6-168">Media Capture Page (Dev Home)</span></span>](devhome-capture.md)  


<span data-ttu-id="356c6-169">&nbsp;&nbsp;Dev Home の**メディア キャプチャ**ページでは、本体で現在実行されているタイトルのビデオをキャプチャします。</span><span class="sxs-lookup"><span data-stu-id="356c6-169">&nbsp;&nbsp;The **Media capture** page of Dev Home captures video of the title that is currently running on the console.</span></span> 
  
  
[<span data-ttu-id="356c6-170">[ネットワーク] ページ (Dev Home)</span><span class="sxs-lookup"><span data-stu-id="356c6-170">Networking Page (Dev Home)</span></span>](devhome-networking.md)  


<span data-ttu-id="356c6-171">&nbsp;&nbsp;トラブルシューティングのためのさまざまなネットワーク条件をシミュレートします。</span><span class="sxs-lookup"><span data-stu-id="356c6-171">&nbsp;&nbsp;Simulates various networking conditions for troubleshooting purposes.</span></span> 
  
  
[<span data-ttu-id="356c6-172">パフォーマンス ページ (Dev Home)</span><span class="sxs-lookup"><span data-stu-id="356c6-172">Performance Page (Dev Home)</span></span>](devhome-performance.md)  


<span data-ttu-id="356c6-173">&nbsp;&nbsp;さまざまなディスクのアクティビティやトラブルシューティングのために、CPU 使用条件をシミュレートします。</span><span class="sxs-lookup"><span data-stu-id="356c6-173">&nbsp;&nbsp;Simulates various disk activity and CPU usage conditions for troubleshooting purposes.</span></span> 
 