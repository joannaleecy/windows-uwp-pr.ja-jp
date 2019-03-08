---
ms.assetid: a56156e4-7adb-bf37-527b-fc3243e04b46
title: コンソールにおける開発者ホーム (Dev Home)
description: Xbox One 用の Dev Home アプリに関する情報を提供します。
ms.date: 08/09/2017
ms.topic: article
keywords: windows 10, uwp
permalink: en-us/docs/xdk/dev-home.html
ms.localizationpriority: medium
ms.openlocfilehash: 4113df37446d93883cf395e7c1e86b1de6c1b328
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57620847"
---
# <a name="developer-home-on-the-console-dev-home"></a><span data-ttu-id="8d19d-104">コンソールにおける開発者ホーム (Dev Home)</span><span class="sxs-lookup"><span data-stu-id="8d19d-104">Developer Home on the Console (Dev Home)</span></span>
   
  
<span data-ttu-id="8d19d-105">Dev Home は、Xbox One 開発キットに含まれ、開発者の生産性をサポートするための 1 つのツール エクスペリエンスです。</span><span class="sxs-lookup"><span data-stu-id="8d19d-105">Dev Home is a tools experience on the Xbox One development kit designed to aid developer productivity.</span></span> <span data-ttu-id="8d19d-106">Dev Home には、開発キットの管理と構成、ユーザーの管理、インストールされているタイトルの起動、キャプチャとトレースの実行を行う機能が備わっています。</span><span class="sxs-lookup"><span data-stu-id="8d19d-106">Dev Home offers functionality to manage and configure your development kit, manage users, launch installed titles and perform captures and traces.</span></span> <span data-ttu-id="8d19d-107">将来のリリースでは、機能を継続的に拡張していくことで、フィードバックに基づいて追加の機能を搭載し、拡張性と独自ツールの追加を実現する予定です。</span><span class="sxs-lookup"><span data-stu-id="8d19d-107">In future releases we will continue to expand the functionality to enable additional features based on your feedback, and also to enable extensibility and the addition of your own tools.</span></span>   
   
  
<span data-ttu-id="8d19d-108">Microsoft では、Dev Home についてのフィードバックや、お客様がサポートを希望されるシナリオに関するフィードバックをお待ちしております。</span><span class="sxs-lookup"><span data-stu-id="8d19d-108">We are very interested in your feedback on Dev Home and the scenarios you are most interested in seeing it support.</span></span> <span data-ttu-id="8d19d-109">アプリのメイン メニューまたは開発者アカウント マネージャー (DAM) を通じて、「**フィードバックの送信**」で説明する方法に従ってコメントをお寄せください。</span><span class="sxs-lookup"><span data-stu-id="8d19d-109">Please provide your comments through the methods described under **Send Feedback** in the main menu of the app or through your Developer Account Manager (DAM).</span></span>   
   
  
<span data-ttu-id="8d19d-110">2015 年 11 月 以降の回復で Dev Home を起動するには、次の手順に従います。</span><span class="sxs-lookup"><span data-stu-id="8d19d-110">To launch Dev Home on the November 2015 or later recovery:</span></span>  
 
   1. <span data-ttu-id="8d19d-111">[ホーム] で左に移動するか、Nexus ボタンをダブルクリックしてガイドを開く</span><span class="sxs-lookup"><span data-stu-id="8d19d-111">Open the guide by moving left on Home, or double clicking the Nexus button</span></span>  
   1. <span data-ttu-id="8d19d-112">**[設定]** (歯車アイコン) まで下に移動する</span><span class="sxs-lookup"><span data-stu-id="8d19d-112">Move down to **Settings** (the gear icon)</span></span>   
   1. <span data-ttu-id="8d19d-113">**[すべての設定]** を選ぶ</span><span class="sxs-lookup"><span data-stu-id="8d19d-113">Select **All settings**</span></span>  
   1. <span data-ttu-id="8d19d-114">既定の **[開発者]** ページで、**[開発者ホーム]** (ホーム アイコン) を選ぶ</span><span class="sxs-lookup"><span data-stu-id="8d19d-114">From the default **Developer** page, select **Developer Home** (the home icon)</span></span>   

 ![](images/dev_home_icons.png)   
  
<span data-ttu-id="8d19d-115">それ以前の回復っでは、**特集コンテンツ** のホーム画面の右側にある Dev Home タイルを選ぶか、Xbox One マネージャーでアプリケーションの一覧を表示して **Dev Home** を起動します。</span><span class="sxs-lookup"><span data-stu-id="8d19d-115">On earlier recoveries select the Dev Home tile on the right side of the home screen in **featured content** or view the application list in Xbox One Manager and launch **Dev Home**.</span></span>   
 ![](images/dev_home_1.png) 
<a id="ID4EBC"></a>

   

## <a name="user-interface"></a><span data-ttu-id="8d19d-116">ユーザー インターフェイス</span><span class="sxs-lookup"><span data-stu-id="8d19d-116">User Interface</span></span>  
   
  
<span data-ttu-id="8d19d-117">Dev Home のユーザー インターフェイスのヘッダーには、開発に関する次の重要な "概要" 情報が含まれています。</span><span class="sxs-lookup"><span data-stu-id="8d19d-117">The header of the Dev Home user interface contains the following important "at a glance" info about the development console:</span></span>   
 
   *  <span data-ttu-id="8d19d-118">**コンソールの IP:** コンソールの現在の IP アドレス。</span><span class="sxs-lookup"><span data-stu-id="8d19d-118">**Console IP:** The current IP address of the console.</span></span>   
   *  <span data-ttu-id="8d19d-119">**コンソール名:** コンソールの現在のホスト名。</span><span class="sxs-lookup"><span data-stu-id="8d19d-119">**Console name:** The current hostname of the console.</span></span>  
   *  <span data-ttu-id="8d19d-120">**サンド ボックス:** コンソールがサンド ボックスの名前。</span><span class="sxs-lookup"><span data-stu-id="8d19d-120">**Sandbox:** The name of the sandbox that the console is in.</span></span>  
   *  <span data-ttu-id="8d19d-121">**OS のバージョン:** コンソールで実行されている現在の復旧バージョン。</span><span class="sxs-lookup"><span data-stu-id="8d19d-121">**OS version:** The current recovery version that is running on the console.</span></span>
   *  <span data-ttu-id="8d19d-122">現在のシステム時刻。</span><span class="sxs-lookup"><span data-stu-id="8d19d-122">Current system time.</span></span>   

   
  
<span data-ttu-id="8d19d-123">Dev Home の UI の残りの部分は、以下のページに分かれています。</span><span class="sxs-lookup"><span data-stu-id="8d19d-123">The rest of the Dev Home UI is divided into the following pages.</span></span> <span data-ttu-id="8d19d-124">これらのページのツールについて詳しくは、個々のトピックをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="8d19d-124">For more information about the tools on these pages, see their individual topics.</span></span>   
 
   *  [<span data-ttu-id="8d19d-125">ホーム</span><span class="sxs-lookup"><span data-stu-id="8d19d-125">Home</span></span>](devhome-home.md)  
   *  [<span data-ttu-id="8d19d-126">Xbox Live</span><span class="sxs-lookup"><span data-stu-id="8d19d-126">Xbox Live</span></span>](devhome-live.md)  
   *  [<span data-ttu-id="8d19d-127">設定</span><span class="sxs-lookup"><span data-stu-id="8d19d-127">Settings</span></span>](devhome-settings.md)  
   *  [<span data-ttu-id="8d19d-128">メディアをキャプチャします。</span><span class="sxs-lookup"><span data-stu-id="8d19d-128">Media capture</span></span>](devhome-capture.md)  
   *  [<span data-ttu-id="8d19d-129">ネットワーク</span><span class="sxs-lookup"><span data-stu-id="8d19d-129">Networking</span></span>](devhome-networking.md)  
   *  [<span data-ttu-id="8d19d-130">パフォーマンス</span><span class="sxs-lookup"><span data-stu-id="8d19d-130">Performance</span></span>](devhome-performance.md)  

  
<a id="ID4EKE"></a>

   

## <a name="main-menu"></a><span data-ttu-id="8d19d-131">メイン メニュー</span><span class="sxs-lookup"><span data-stu-id="8d19d-131">Main Menu</span></span>  
   
  
<span data-ttu-id="8d19d-132">コントローラーの**メニュー** ボタンを押すと、アプリのワークスペースを構成できるメイン メニュー、ネットワークの場所にアクセスするための資格情報を管理する機能、アプリのフィードバックの提供に関する情報にアクセスすることができます。</span><span class="sxs-lookup"><span data-stu-id="8d19d-132">By pressing the **menu** button on your controller, you can access the main menu that allows configuration of the app workspace, the ability to manage credentials for accessing network locations and information on providing feedback on the app.</span></span>   
  
<a id="ID4EUE"></a>

   

## <a name="snap-mode-ux"></a><span data-ttu-id="8d19d-133">スナップ モード UX</span><span class="sxs-lookup"><span data-stu-id="8d19d-133">Snap Mode UX</span></span>  
   
  
<span data-ttu-id="8d19d-134">ネットワーキングやマルチプレーヤーなど、Dev Home にある既存のツールと今後リリース予定のツールのうちいくつかは、テスト時にツールにアクセスしやすいように、タイトルの実行中に端にスナップして使うことができるように設計されています。</span><span class="sxs-lookup"><span data-stu-id="8d19d-134">Several existing and upcoming tools in Dev Home, such as Networking and Multiplayer, are designed to be used snapped to the side while you are running your title, so that you can have easy access to tools while you are testing.</span></span>   
   
  
<span data-ttu-id="8d19d-135">スナップ モードにアクセスするには、該当するツールのタイトルを強調表示して、コントローラーの **[ビュー]** ボタンを押し、コンテキスト メニューで **[スナップ]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="8d19d-135">To access Snap mode, highlight the title of the appropriate tool, press the **view** button on your controller, and select **snap** from the context menu:</span></span>  
 ![](images/dev_home_4.png)   
  
<span data-ttu-id="8d19d-136">Dev Home は右にスナップします。</span><span class="sxs-lookup"><span data-stu-id="8d19d-136">Dev Home will snap right.</span></span> <span data-ttu-id="8d19d-137">通常どおり [連結] ボタンをダブル タップすると、コンテキストを切り替えることができます。</span><span class="sxs-lookup"><span data-stu-id="8d19d-137">You can switch context by double tapping the Nexus button as usual.</span></span>  
 ![](images/dev_home_5.png)  
<a id="ID4EKF"></a>

   

## <a name="customizing-dev-home"></a><span data-ttu-id="8d19d-138">Dev Home のカスタマイズ</span><span class="sxs-lookup"><span data-stu-id="8d19d-138">Customizing Dev Home</span></span>  
   
  
<span data-ttu-id="8d19d-139">Dev Home は、カスタマイズして個人用に設定できるように設計されています。</span><span class="sxs-lookup"><span data-stu-id="8d19d-139">Dev Home has been designed to be customizable and personal.</span></span> <span data-ttu-id="8d19d-140">ワークフローに合わせてアプリを構成して、ワークスペースとして保存できます。</span><span class="sxs-lookup"><span data-stu-id="8d19d-140">You can configure the app to suit your workflow, and then save that as a workspace.</span></span> <span data-ttu-id="8d19d-141">このワークスペースは、エクスポートおよびインポートできるので、必要に応じて他のコンソールにレイアウトをコピーできます。</span><span class="sxs-lookup"><span data-stu-id="8d19d-141">This workspace can be exported and imported, allowing you to copy the layout to other consoles as needed.</span></span> <span data-ttu-id="8d19d-142">これらのオプションは、**ワークスペース**の下のメイン メニューにあります。</span><span class="sxs-lookup"><span data-stu-id="8d19d-142">These options are found in the main menu under **workspace**.</span></span> <span data-ttu-id="8d19d-143">エクスポートしたファイルは、`Dev Home\Workspaces` ディレクトリのシステム スクラッチ ドライブに配置されます。</span><span class="sxs-lookup"><span data-stu-id="8d19d-143">The exported file will be located on the system scratch drive in the `Dev Home\Workspaces` directory.</span></span>   
 
<a id="ID4EVF"></a>

   

### <a name="resizing-and-reordering-tools"></a><span data-ttu-id="8d19d-144">ツールのサイズ変更と並べ替え</span><span class="sxs-lookup"><span data-stu-id="8d19d-144">Resizing and Reordering Tools</span></span>  
   
  
<span data-ttu-id="8d19d-145">ツールのサイズや位置を変更するには、タイトルにフォーカスがあるときに、コンテキスト メニュー ボタン (コントローラー上の [ビュー] ボタン) を使用します。</span><span class="sxs-lookup"><span data-stu-id="8d19d-145">To change the size or position of a tool, use the context menu button (view button on your controller) while the title has focus.</span></span> <span data-ttu-id="8d19d-146">コンテキスト メニューで **[移動]** または **[サイズ変更]**  を選択します。</span><span class="sxs-lookup"><span data-stu-id="8d19d-146">From the context menu select **Move** or **Resize**.</span></span>   
 ![](images/dev_home_6.png)  
<a id="ID4EEG"></a>

   

### <a name="changing-theme-color-and-background-image"></a><span data-ttu-id="8d19d-147">テーマの色と背景画像の変更</span><span class="sxs-lookup"><span data-stu-id="8d19d-147">Changing theme color and background image</span></span>  
   
  
<span data-ttu-id="8d19d-148">メイン メニューでは、**[ワークスペース]** を選択して **[テーマの色の変更]** を選択できます。</span><span class="sxs-lookup"><span data-stu-id="8d19d-148">From the Main Menu, you can select **Workspace** and then **Change theme color**.</span></span> <span data-ttu-id="8d19d-149">新しい色を選択し、**[保存]** を選択してフォーカスが強調表示されたテーマの色を更新します。</span><span class="sxs-lookup"><span data-stu-id="8d19d-149">Select a new color and select **Save** to update the theme color used for focus highlighting.</span></span>   
 ![](images/dev_home_7.png)  
<a id="ID4EVG"></a>

   

### <a name="setting-the-default-application-for-a-package"></a><span data-ttu-id="8d19d-150">パッケージの既定のアプリケーションを設定する</span><span class="sxs-lookup"><span data-stu-id="8d19d-150">Setting the default application for a package</span></span>  
   
  
<span data-ttu-id="8d19d-151">パッケージに複数のアプリケーションが含まれている場合、Dev Home では既定のアプリケーションが起動されるように設定できます。</span><span class="sxs-lookup"><span data-stu-id="8d19d-151">If a package contains multiple applications, Dev Home will allow you to set the default application to be launched.</span></span> <span data-ttu-id="8d19d-152">ランチャーでパッケージを強調表示し、**A** ボタンを押してを利用可能なアプリケーションの一覧を開きます。</span><span class="sxs-lookup"><span data-stu-id="8d19d-152">Highlight the package in the launcher and press the **A** button to open the list of available applications.</span></span> <span data-ttu-id="8d19d-153">既定として設定するアプリケーションを強調表示して、**[ビュー]** ボタンを選択し、コンテキスト メニューから **[既定値として設定]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="8d19d-153">Highlight the one you wish to set as the default and press the **view** button, and then choose **Set as Default** from the context menu.</span></span>   
 ![](images/dev_home_setdefault.png)  
<a id="ID4EGH"></a>

   

### <a name="using-dev-home-to-register-and-launch-titles-from-a-network-share"></a><span data-ttu-id="8d19d-154">Dev Home を使ってネットワーク共有からタイトルを登録して起動する</span><span class="sxs-lookup"><span data-stu-id="8d19d-154">Using Dev Home to register and launch titles from a network share</span></span>  
   
  
<span data-ttu-id="8d19d-155">ランチャーのインストールされているアプリとゲームの一覧の下部では、**[ネットワーク共有からゲームを登録]** オプションを選択してタイトルの緩やかなファイル バージョンをリモートで実行できます。</span><span class="sxs-lookup"><span data-stu-id="8d19d-155">From the launcher, at the bottom of the installed apps and games list, you can select the option **Register a game from a network share** to run a loose file version of a title remotely.</span></span>   
 ![](images/dev_home_8.png)   
  
<span data-ttu-id="8d19d-156">その後、登録するタイトルの appxmanifest.xml ファイルにネットワーク パスを入力できます。</span><span class="sxs-lookup"><span data-stu-id="8d19d-156">You can then enter the network path to the appxmanifest.xml file for the title you wish to register.</span></span> <span data-ttu-id="8d19d-157">Dev Home は、その共有の既存の資格情報を使ってタイトルを登録しようとし、必要に応じて新しいネットワーク資格情報を求めます。</span><span class="sxs-lookup"><span data-stu-id="8d19d-157">Dev Home will attempt to register the title using any existing credentials for that share, and if needed will prompt for new network credentials.</span></span> <span data-ttu-id="8d19d-158">追加の共有にアクセスする必要がある場合 (たとえば、別のサーバーのシンボリック リンク リソースにアクセスするためなど)、以下のオプションを使ってそれらの共有を追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8d19d-158">If you need to access additional shares (for example to access symbolically linked resources on a separate server) then you will need to add those via the option below.</span></span>   
   
  
<span data-ttu-id="8d19d-159">このような保存された資格情報の管理 (および他の資格情報の追加) は、コンソールのメイン メニューの **[ネットワーク資格情報の管理]** オプションから行うことができます。</span><span class="sxs-lookup"><span data-stu-id="8d19d-159">You can manage these stored credentials (and add additional ones) on the console via the main menu's **Manage network credentials** option.</span></span>   
 ![](images/dev_home_9.png)   
  
<span data-ttu-id="8d19d-160">コンソールでの現在の資格情報の表示、資格情報のパスを選択して **A** ボタンをクリックすることによる資格情報の編集、削除リンクを選択して **A** ボタンをクリックすることによる資格情報の削除を行うことができます。</span><span class="sxs-lookup"><span data-stu-id="8d19d-160">You can view the credentials currently on the console, edit credentials by selecting the path of the credential and clicking **A** button and remove a credential by selecting the remove link and clicking **A** button.</span></span>   
   
<a id="ID4EGAAC"></a>

   

## <a name="in-this-section"></a><span data-ttu-id="8d19d-161">このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="8d19d-161">In this section</span></span>  
  
[<span data-ttu-id="8d19d-162">ホーム ページ (Dev ホーム)</span><span class="sxs-lookup"><span data-stu-id="8d19d-162">Home Page (Dev Home)</span></span>](devhome-home.md)  


<span data-ttu-id="8d19d-163">&nbsp;&nbsp;日常的に開発コンソール上で実行されるタスクにすばやくアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="8d19d-163">&nbsp;&nbsp;Provides quick access to the tasks that are routinely performed on a development console.</span></span> 
  
  
[<span data-ttu-id="8d19d-164">Xbox Live (Dev ホーム) ページ</span><span class="sxs-lookup"><span data-stu-id="8d19d-164">Xbox Live Page (Dev Home)</span></span>](devhome-live.md)  


<span data-ttu-id="8d19d-165">&nbsp;&nbsp;マルチ プレーヤーの情報をキャプチャし、Xbox Live サービスの現在の状態を表示します。</span><span class="sxs-lookup"><span data-stu-id="8d19d-165">&nbsp;&nbsp;Captures multiplayer information and displays the current status of the Xbox Live service.</span></span> 
  
  
[<span data-ttu-id="8d19d-166">設定 ページ (Dev ホーム)</span><span class="sxs-lookup"><span data-stu-id="8d19d-166">Settings Page (Dev Home)</span></span>](devhome-settings.md)  


<span data-ttu-id="8d19d-167">&nbsp;&nbsp;開発コンソールのさまざまな設定にアクセスをできます。</span><span class="sxs-lookup"><span data-stu-id="8d19d-167">&nbsp;&nbsp;Provides access to various settings for the development console.</span></span> 
  
  
[<span data-ttu-id="8d19d-168">メディアのキャプチャ (Dev ホーム) ページ</span><span class="sxs-lookup"><span data-stu-id="8d19d-168">Media Capture Page (Dev Home)</span></span>](devhome-capture.md)  


<span data-ttu-id="8d19d-169">&nbsp;&nbsp;**メディアのキャプチャ**の開発のホーム ページは、コンソールで現在実行されているタイトルのビデオをキャプチャします。</span><span class="sxs-lookup"><span data-stu-id="8d19d-169">&nbsp;&nbsp;The **Media capture** page of Dev Home captures video of the title that is currently running on the console.</span></span> 
  
  
<span data-ttu-id="8d19d-170">[[ネットワーク] ページ (Dev ホーム)](devhome-networking.md)</span><span class="sxs-lookup"><span data-stu-id="8d19d-170">[Networking Page (Dev Home)](devhome-networking.md)</span></span>  


<span data-ttu-id="8d19d-171">&nbsp;&nbsp;トラブルシューティングのためのさまざまなネットワーク条件をシミュレートします。</span><span class="sxs-lookup"><span data-stu-id="8d19d-171">&nbsp;&nbsp;Simulates various networking conditions for troubleshooting purposes.</span></span> 
  
  
<span data-ttu-id="8d19d-172">[[パフォーマンス] ページ (Dev ホーム)](devhome-performance.md)</span><span class="sxs-lookup"><span data-stu-id="8d19d-172">[Performance Page (Dev Home)](devhome-performance.md)</span></span>  


<span data-ttu-id="8d19d-173">&nbsp;&nbsp;さまざまなディスク利用状況とトラブルシューティングの目的で CPU の使用条件をシミュレートします。</span><span class="sxs-lookup"><span data-stu-id="8d19d-173">&nbsp;&nbsp;Simulates various disk activity and CPU usage conditions for troubleshooting purposes.</span></span> 
 