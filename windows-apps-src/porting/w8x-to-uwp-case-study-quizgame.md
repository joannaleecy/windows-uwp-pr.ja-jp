---
author: stevewhims
ms.assetid: 88e16ec8-deff-4a60-bda6-97c5dabc30b8
description: このトピックでは機能しているピア ツー ピア クイズ ゲーム WinRT 8.1 サンプル アプリを Windows 10 どこからでも Windows プラットフォーム (UWP) のアプリに移植のケース スタディが表示されます。
title: Windows の実行時に UWP のケース スタディ、QuizGame ピア ツー ピア サンプル アプリ 8.x
ms.author: stwhi
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 5513a4536f4df77be93a099cf826d85212621622
ms.sourcegitcommit: 897a111e8fc5d38d483800288ad01c523e924ef4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/13/2018
ms.locfileid: "303015"
---
# <a name="windows-runtime-8x-to-uwp-case-study-quizgame-sample-app"></a><span data-ttu-id="413fa-104">Windows の実行時に UWP のケース スタディ 8.x: QuizGame サンプル アプリ</span><span class="sxs-lookup"><span data-stu-id="413fa-104">Windows Runtime 8.x to UWP case study: QuizGame sample app</span></span>




<span data-ttu-id="413fa-105">このトピックでは機能しているピア ツー ピア クイズ ゲーム WinRT 8.1 サンプル アプリを Windows 10 どこからでも Windows プラットフォーム (UWP) のアプリに移植のケース スタディが表示されます。</span><span class="sxs-lookup"><span data-stu-id="413fa-105">This topic presents a case study of porting a functioning peer-to-peer quiz game WinRT 8.1 sample app to a Windows 10 Universal Windows Platform (UWP) app.</span></span>

<span data-ttu-id="413fa-106">ユニバーサル 8.1 のアプリが同じアプリの 2 つのバージョンを作成する: Windows 8.1 のいずれかのアプリのパッケージ化して Windows Phone 8.1 用の別のアプリ パッケージします。</span><span class="sxs-lookup"><span data-stu-id="413fa-106">A Universal 8.1 app is one that builds two versions of the same app: one app package for Windows 8.1, and a different app package for Windows Phone 8.1.</span></span> <span data-ttu-id="413fa-107">QuizGame の WinRT 8.1 バージョンは、どこからでも Windows アプリ プロジェクトの配置を使用して、別の方法がかかり、2 つのプラットフォームの機能のアプリの作成します。</span><span class="sxs-lookup"><span data-stu-id="413fa-107">The WinRT 8.1 version of QuizGame uses a Universal Windows app project arrangement, but it takes a different approach and it builds a functionally distinct app for the two platforms.</span></span> <span data-ttu-id="413fa-108">Windows 8.1 のアプリ パッケージとしてホスト クイズ ゲーム セッションは、Windows Phone 8.1 アプリ パッケージをホスト クライアントの役割の再生中にします。</span><span class="sxs-lookup"><span data-stu-id="413fa-108">The Windows 8.1 app package serves as the host for a quiz game session, while the Windows Phone 8.1 app package plays the role of the client to the host.</span></span> <span data-ttu-id="413fa-109">クイズ ゲーム セッションの 2 つの要素は、ピア ツー ピア ネットワークを使って連絡します。</span><span class="sxs-lookup"><span data-stu-id="413fa-109">The two halves of the quiz game session communicate via peer-to-peer networking.</span></span>

<span data-ttu-id="413fa-110">わかりやすくは、それぞれに、PC と電話番号、2 つの要素を調整します。</span><span class="sxs-lookup"><span data-stu-id="413fa-110">Tailoring the two halves to PC, and phone, respectively makes good sense.</span></span> <span data-ttu-id="413fa-111">ほうも選択するには、ほとんどのデバイスでホストとクライアントの両方を実行する可能性のある場合ですか。</span><span class="sxs-lookup"><span data-stu-id="413fa-111">But, wouldn't it be even better if you could run both the host and the client on just about any device of your choosing?</span></span> <span data-ttu-id="413fa-112">ここでは、調査場所は各構築にさまざまなデバイスにインストールできる 1 つのアプリ パッケージを Windows 10 に両方のアプリのポートはされます。</span><span class="sxs-lookup"><span data-stu-id="413fa-112">In this case study, we'll port both apps to Windows 10 where they will each build into a single app package that users can install onto a wide range of devices.</span></span>

<span data-ttu-id="413fa-113">アプリでは、通話のビューを使用して、モデルを表示するパターンを使用します。</span><span class="sxs-lookup"><span data-stu-id="413fa-113">The app uses patterns that make use of views and view models.</span></span> <span data-ttu-id="413fa-114">このを明確に分離、結果としてこのアプリの移植プロセスは非常に単純ですが表示されます。</span><span class="sxs-lookup"><span data-stu-id="413fa-114">As a result of this clean separation, the porting process for this app is very straightforward, as you'll see.</span></span>

<span data-ttu-id="413fa-115">**メモ** この例では送信または受信するユーザー設定の UDP にネットワークを構成する (ほとんどのホーム ネットワークには、社内ネットワークができないことがありますが) マルチ キャスト パケットをグループ化します。</span><span class="sxs-lookup"><span data-stu-id="413fa-115">**Note**  This sample assumes your network is configured to send and receive custom UDP group multicast packets (most home networks are, although your work network may not be).</span></span> <span data-ttu-id="413fa-116">また、サンプルは、送信し、TCP パケットを受け取ります。</span><span class="sxs-lookup"><span data-stu-id="413fa-116">The sample also sends and receives TCP packets.</span></span>

 

<span data-ttu-id="413fa-117">**メモ**  「Visual Studio 更新が必要です」というメッセージが表示される場合は、Visual Studio で QuizGame10 を開く、ときに、次[TargetPlatformVersion](w8x-to-uwp-troubleshooting.md)」の手順を実行します。</span><span class="sxs-lookup"><span data-stu-id="413fa-117">**Note**   When opening QuizGame10 in Visual Studio, if you see the message "Visual Studio update required", then follow the steps in [TargetPlatformVersion](w8x-to-uwp-troubleshooting.md).</span></span>

 

## <a name="downloads"></a><span data-ttu-id="413fa-118">ダウンロード</span><span class="sxs-lookup"><span data-stu-id="413fa-118">Downloads</span></span>

<span data-ttu-id="413fa-119">[QuizGame ユニバーサル 8.1 アプリをダウンロード](http://go.microsoft.com/fwlink/?linkid=532953)してください。</span><span class="sxs-lookup"><span data-stu-id="413fa-119">[Download the QuizGame Universal 8.1 app](http://go.microsoft.com/fwlink/?linkid=532953).</span></span> <span data-ttu-id="413fa-120">これは、アプリの移植よりも前の初期状態です。</span><span class="sxs-lookup"><span data-stu-id="413fa-120">This is the initial state of the app prior to porting.</span></span> 

<span data-ttu-id="413fa-121">[Windows 10 アプリをダウンロード、QuizGame10](http://go.microsoft.com/fwlink/?linkid=532954)します。</span><span class="sxs-lookup"><span data-stu-id="413fa-121">[Download the QuizGame10 Windows 10 app](http://go.microsoft.com/fwlink/?linkid=532954).</span></span> <span data-ttu-id="413fa-122">移植した後に、このアプリの状態です。</span><span class="sxs-lookup"><span data-stu-id="413fa-122">This is the state of the app just after  porting.</span></span> 

<span data-ttu-id="413fa-123">[このサンプル GitHub での最新バージョンを参照してください](https://github.com/Microsoft/Windows-appsample-quizgame)。</span><span class="sxs-lookup"><span data-stu-id="413fa-123">[See the latest version of this sample on GitHub](https://github.com/Microsoft/Windows-appsample-quizgame).</span></span>

## <a name="the-winrt-81-solution"></a><span data-ttu-id="413fa-124">WinRT 8.1 ソリューション</span><span class="sxs-lookup"><span data-stu-id="413fa-124">The WinRT 8.1 solution</span></span>


<span data-ttu-id="413fa-125">ここでは、どのような QuizGame などのアプリのポートを-ように表示されます。</span><span class="sxs-lookup"><span data-stu-id="413fa-125">Here’s what QuizGame—the app that we're going to port—looks like.</span></span>

![windows で実行されている quizgame ホストのアプリ](images/w8x-to-uwp-case-studies/c04-01-win81-how-the-host-app-looks.png)

<span data-ttu-id="413fa-127">Windows で実行されている QuizGame ホストのアプリ</span><span class="sxs-lookup"><span data-stu-id="413fa-127">The QuizGame host app running on Windows</span></span>

 

![windows phone で実行されている quizgame クライアント アプリケーション](images/w8x-to-uwp-case-studies/c04-02-wp81-how-the-client-app-looks.png)

<span data-ttu-id="413fa-129">Windows Phone で実行されている QuizGame クライアント アプリケーション</span><span class="sxs-lookup"><span data-stu-id="413fa-129">The QuizGame client app running on Windows Phone</span></span>

## <a name="a-walkthrough-of-quizgame-in-use"></a><span data-ttu-id="413fa-130">使用中の QuizGame のチュートリアル</span><span class="sxs-lookup"><span data-stu-id="413fa-130">A walkthrough of QuizGame in use</span></span>

<span data-ttu-id="413fa-131">これは、使用して、アプリの短い仮想的なアカウントが便利な情報を提供、ワイヤレス ネットワーク経由で自分用のアプリを試用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="413fa-131">This is a short hypothetical account of the app in use, but it provides useful info should you want to try out the app for yourself over your wireless network.</span></span>

<span data-ttu-id="413fa-132">楽しいクイズ ゲームがバーで実行されています。</span><span class="sxs-lookup"><span data-stu-id="413fa-132">A fun quiz game is taking place in a bar.</span></span> <span data-ttu-id="413fa-133">すべてのユーザーに表示されるバーには、大きな TV があります。</span><span class="sxs-lookup"><span data-stu-id="413fa-133">There's a big TV in the bar that everyone can see.</span></span> <span data-ttu-id="413fa-134">[Quizmaster TV の出力結果が表示されて、PC があります。</span><span class="sxs-lookup"><span data-stu-id="413fa-134">The quizmaster has a PC whose output is being shown on the TV.</span></span> <span data-ttu-id="413fa-135">その PC"ホスト アプリをされて"が実行されています。</span><span class="sxs-lookup"><span data-stu-id="413fa-135">That PC has "the host app" running on it.</span></span> <span data-ttu-id="413fa-136">テストだけに参加する人は、アプリをインストール"クライアント"の電話または等高線グラフに必要があります。</span><span class="sxs-lookup"><span data-stu-id="413fa-136">Anyone who wants to take part in the quiz just needs to install "the client app" on their phone or Surface.</span></span>

<span data-ttu-id="413fa-137">ロビー モードでは、ホストのアプリと大きな TV のことが通知する準備ができましたクライアント アプリケーションを接続します。</span><span class="sxs-lookup"><span data-stu-id="413fa-137">The host app is in lobby mode, and on the big TV, it's advertising that it's ready for client apps to connect.</span></span> <span data-ttu-id="413fa-138">ジャンヌは、自分のモバイル デバイスでクライアント アプリケーションを起動します。</span><span class="sxs-lookup"><span data-stu-id="413fa-138">Joan launches the client app on her mobile device.</span></span> <span data-ttu-id="413fa-139">アンナは [**プレーヤーの名前**] ボックスに自分の名前を入力して、**ゲームへの参加**をタップします。</span><span class="sxs-lookup"><span data-stu-id="413fa-139">She types her name into the **Player name** text box and taps **Join game**.</span></span> <span data-ttu-id="413fa-140">ホストのアプリをジャンヌが自分の名前を表示することによってへの参加を示し、ジャンヌのクライアント アプリケーションを開始するゲームの待機していることを確認します。</span><span class="sxs-lookup"><span data-stu-id="413fa-140">The host app acknowledges that Joan has joined by displaying her name, and Joan’s client app indicates that it's waiting for the game to begin.</span></span> <span data-ttu-id="413fa-141">次に、マックスウェルはモバイル デバイスでこれらの同じ手順を移動します。</span><span class="sxs-lookup"><span data-stu-id="413fa-141">Next, Maxwell goes through those same steps on his mobile device.</span></span>

<span data-ttu-id="413fa-142">[Quizmaster が**ゲームを開始**をクリックし、ホストのアプリは、質問と回答 (にも結合の選手の一覧に表示灰色での標準つ) が表示されます。 します。</span><span class="sxs-lookup"><span data-stu-id="413fa-142">The quizmaster clicks **Start game** and the host app shows a question and the possible answers (it also shows a list of the joined players in normal fontweight, colored gray).</span></span> <span data-ttu-id="413fa-143">同時に、回答が表示される結合のクライアント デバイス上のボタンに表示します。</span><span class="sxs-lookup"><span data-stu-id="413fa-143">Simultaneously, the answers appear displayed on buttons on joined client devices.</span></span> <span data-ttu-id="413fa-144">ジャンヌに「1975」という解を] ボタンをタップしてされ、自分のすべてのボタンが無効になります。</span><span class="sxs-lookup"><span data-stu-id="413fa-144">Joan taps the button with the answer "1975" on it whereupon all her buttons become disabled.</span></span> <span data-ttu-id="413fa-145">ホスト アプリケーションでジャンヌの名緑色を描画 (および太字になります) で自分の応答の開封済みメッセージの受信を確認します。</span><span class="sxs-lookup"><span data-stu-id="413fa-145">On the host app, Joan’s name is painted green (and becomes bold) in acknowledgment of the receipt of her answer.</span></span> <span data-ttu-id="413fa-146">マックスウェル回答もします。</span><span class="sxs-lookup"><span data-stu-id="413fa-146">Maxwell answers, also.</span></span> <span data-ttu-id="413fa-147">全選手の名前は緑、ことを示す、quizmaster は、**次の質問**をクリックします。</span><span class="sxs-lookup"><span data-stu-id="413fa-147">The quizmaster, noting that all players' names are green, clicks **Next question**.</span></span>

<span data-ttu-id="413fa-148">質問は、送信され、この同じサイクルで応答するのに進みます。</span><span class="sxs-lookup"><span data-stu-id="413fa-148">Questions continue to be asked and answered in this same cycle.</span></span> <span data-ttu-id="413fa-149">ホスト アプリケーション最後の質問には、表示されているの場合は、ボタン、およびされない**次の質問**の内容は**結果を表示します**。</span><span class="sxs-lookup"><span data-stu-id="413fa-149">When the last question is being shown on the host app, **Show results** is the content of the button, and not **Next question**.</span></span> <span data-ttu-id="413fa-150">**結果の表示**をクリックすると、結果が表示されます。</span><span class="sxs-lookup"><span data-stu-id="413fa-150">When **Show results** is clicked, the results are shown.</span></span> <span data-ttu-id="413fa-151">**ロビーに戻る**] をクリックを返します。 参加していることを除いてゲーム ライフ サイクルの先頭にままプレーヤーに結合します。</span><span class="sxs-lookup"><span data-stu-id="413fa-151">Clicking **Return to lobby** returns to the beginning of the game lifecycle with the exception that joined players remain joined.</span></span> <span data-ttu-id="413fa-152">しかし、ロビーに戻ってにより新しいプレイヤー結合の参加 (ただし、結合プレーヤーを**ゲームを終了**] をタップして、いつでもかまいません) のままにするための便利な時間、参加します。</span><span class="sxs-lookup"><span data-stu-id="413fa-152">But, going back to the lobby gives new players a chance to join, and even a convenient time for joined players to leave (although a joined player can leave at any time by tapping **Leave game**).</span></span>

## <a name="local-test-mode"></a><span data-ttu-id="413fa-153">ローカル テスト モード</span><span class="sxs-lookup"><span data-stu-id="413fa-153">Local test mode</span></span>

<span data-ttu-id="413fa-154">アプリと配分デバイスではなく 1 台の PC 上の相互作用には、ローカル テスト モードで、ホストのアプリを構築できます。</span><span class="sxs-lookup"><span data-stu-id="413fa-154">To try out the app and its interactions on a single PC instead of distributed across devices, you can build the host app in local test mode.</span></span> <span data-ttu-id="413fa-155">このモードは、ネットワークの使用を完全にバイパスします。</span><span class="sxs-lookup"><span data-stu-id="413fa-155">This mode completely bypasses use of the network.</span></span> <span data-ttu-id="413fa-156">代わりに、ホストのアプリの UI のウィンドウの左側にホスト部分を表示して、クライアント アプリケーション UI の 2 つのコピーを縦に並んだ右側で、(メモ、このバージョンでは、ローカル テスト モード UI が固定 PC で表示します。 それに適応しない小型のデバイス)。</span><span class="sxs-lookup"><span data-stu-id="413fa-156">Instead, the UI of the host app displays the host portion to the left of the window and, to the right, two copies of the client app UI stacked vertically (note that, in this version, the local test mode UI is fixed for a PC display; it does not adapt to small devices).</span></span> <span data-ttu-id="413fa-157">これらのセグメントを同じアプリ内のすべての UI のやり取りによる相互モック クライアント communicator、ネットワーク上の場所をそれ以外の場合の相互作用をシミュレートします。</span><span class="sxs-lookup"><span data-stu-id="413fa-157">These segments of UI, all in the same app, communicate with one another via a mock client communicator, which simulates the interactions that would otherwise take place over the network.</span></span>

<span data-ttu-id="413fa-158">ローカル テスト モードをアクティブに条件付きコンパイル記号として**LOCALTESTMODEON** (でプロジェクトのプロパティ) を定義し、[再構築します。</span><span class="sxs-lookup"><span data-stu-id="413fa-158">To activate local test mode, define **LOCALTESTMODEON** (in project properties) as a conditional compilation symbol, and rebuild.</span></span>

## <a name="porting-to-a-windows-10-project"></a><span data-ttu-id="413fa-159">Windows 10 プロジェクトへの移植</span><span class="sxs-lookup"><span data-stu-id="413fa-159">Porting to a Windows 10 project</span></span>

<span data-ttu-id="413fa-160">QuizGame には、次の部分があります。</span><span class="sxs-lookup"><span data-stu-id="413fa-160">QuizGame has the following pieces.</span></span>

-   <span data-ttu-id="413fa-161">P2PHelper します。</span><span class="sxs-lookup"><span data-stu-id="413fa-161">P2PHelper.</span></span> <span data-ttu-id="413fa-162">これは、ピア ツー ピア ネットワーク ロジックを含むポータブル クラス ライブラリです。</span><span class="sxs-lookup"><span data-stu-id="413fa-162">This is a portable class library that contains the peer-to-peer networking logic.</span></span>
-   <span data-ttu-id="413fa-163">QuizGame.Windows します。</span><span class="sxs-lookup"><span data-stu-id="413fa-163">QuizGame.Windows.</span></span> <span data-ttu-id="413fa-164">これは、Windows 8.1 を対象にする、ホストのアプリのアプリ パッケージをビルドするプロジェクト。</span><span class="sxs-lookup"><span data-stu-id="413fa-164">This is the project that builds the app package for the host app, which targets Windows 8.1.</span></span>
-   <span data-ttu-id="413fa-165">QuizGame.WindowsPhone します。</span><span class="sxs-lookup"><span data-stu-id="413fa-165">QuizGame.WindowsPhone.</span></span> <span data-ttu-id="413fa-166">これは、Windows Phone 8.1 を対象にする、クライアントのアプリのアプリ パッケージをビルドするプロジェクト。</span><span class="sxs-lookup"><span data-stu-id="413fa-166">This is the project that builds the app package for the client app, which targets Windows Phone 8.1.</span></span>
-   <span data-ttu-id="413fa-167">QuizGame.Shared します。</span><span class="sxs-lookup"><span data-stu-id="413fa-167">QuizGame.Shared.</span></span> <span data-ttu-id="413fa-168">これは、他の 2 つのプロジェクトの両方で使われるソース コード、マークアップ ファイル、および他のアセットやリソースを含むプロジェクトです。</span><span class="sxs-lookup"><span data-stu-id="413fa-168">This is the project that contains source code, markup files, and other assets and resources, that are used by both of the other two projects.</span></span>

<span data-ttu-id="413fa-169">このケース スタディでは、サポートするデバイスに関して、「[ユニバーサル 8.1 アプリがある場合](w8x-to-uwp-root.md)」で説明した通常のオプションを使います。</span><span class="sxs-lookup"><span data-stu-id="413fa-169">For this case study, we have the usual options described in [If you have a Universal 8.1 app](w8x-to-uwp-root.md) with respect to what devices to support.</span></span>

<span data-ttu-id="413fa-170">これらのオプションに基づき、QuizGameHost と呼ばれる新しい Windows 10 プロジェクトに QuizGame.Windows をポートされます。</span><span class="sxs-lookup"><span data-stu-id="413fa-170">Based on those options, we'll port QuizGame.Windows to a new Windows 10 project called QuizGameHost.</span></span> <span data-ttu-id="413fa-171">QuizGameClient と呼ばれる新しい Windows 10 プロジェクトに QuizGame.WindowsPhone をポートされます。</span><span class="sxs-lookup"><span data-stu-id="413fa-171">And, we'll port QuizGame.WindowsPhone to a new Windows 10 project called QuizGameClient.</span></span> <span data-ttu-id="413fa-172">任意のデバイスで実行されるため、これらのプロジェクトは、どこからでもデバイス ファミリをターゲットします。</span><span class="sxs-lookup"><span data-stu-id="413fa-172">These projects will target the universal device family, so they will run on any device.</span></span> <span data-ttu-id="413fa-173">いきます、QuizGame.Shared ソース ファイルで独自のフォルダーと、2 つの新しいプロジェクトに共有ファイルにリンクしています。</span><span class="sxs-lookup"><span data-stu-id="413fa-173">And, we'll keep the QuizGame.Shared source files, etc, in their own folder, and we'll link those shared files into the two new projects.</span></span> <span data-ttu-id="413fa-174">前に、スクリプトを紹介するすべてのアイテムでは、1 つのソリューションという名前に QuizGame10 と同じようにします。</span><span class="sxs-lookup"><span data-stu-id="413fa-174">Just like before, we'll keep everything in one solution and we'll name it QuizGame10.</span></span>

**<span data-ttu-id="413fa-175">QuizGame10 ソリューション</span><span class="sxs-lookup"><span data-stu-id="413fa-175">The QuizGame10 solution</span></span>**

-   <span data-ttu-id="413fa-176">新しいソリューションを作成する (**新しいプロジェクト** &gt; **その他のプロジェクトの種類** &gt; **Visual Studio ソリューション**)、QuizGame10 という名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="413fa-176">Create a new solution (**New Project** &gt; **Other Project Types** &gt; **Visual Studio Solutions**) and name it QuizGame10.</span></span>

**<span data-ttu-id="413fa-177">P2PHelper</span><span class="sxs-lookup"><span data-stu-id="413fa-177">P2PHelper</span></span>**

-   <span data-ttu-id="413fa-178">ソリューションでは、新しい Windows 10 のクラス ライブラリ プロジェクトを作成する (**新しいプロジェクト** &gt; **Windows ユニバーサル** &gt; **クラス ライブラリ (Windows ユニバーサル)**)、P2PHelper という名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="413fa-178">In the solution, create a new Windows 10 class library project (**New Project** &gt; **Windows Universal** &gt; **Class Library (Windows Universal)**) and name it P2PHelper.</span></span>
-   <span data-ttu-id="413fa-179">新しいプロジェクト Class1.cs を削除します。</span><span class="sxs-lookup"><span data-stu-id="413fa-179">Delete Class1.cs from the new project.</span></span>
-   <span data-ttu-id="413fa-180">新しいプロジェクトのフォルダーに、P2PSession.cs、P2PSessionClient.cs、および P2PSessionHost.cs をコピーし、新しいプロジェクトにコピーしたファイルが含まれます。</span><span class="sxs-lookup"><span data-stu-id="413fa-180">Copy P2PSession.cs, P2PSessionClient.cs, and P2PSessionHost.cs into the new project's folder and include the copied files in the new project.</span></span>
-   <span data-ttu-id="413fa-181">プロジェクトをさらに変更がなくてもビルドします。</span><span class="sxs-lookup"><span data-stu-id="413fa-181">The project will build without needing further changes.</span></span>

**<span data-ttu-id="413fa-182">共有ファイル</span><span class="sxs-lookup"><span data-stu-id="413fa-182">Shared files</span></span>**

-   <span data-ttu-id="413fa-183">一般的なモデル、ビュー、およびビューモデル フォルダーを \\QuizGame.Shared\\ から \\QuizGame10\\ にコピーします。</span><span class="sxs-lookup"><span data-stu-id="413fa-183">Copy the folders Common, Model, View, and ViewModel from \\QuizGame.Shared\\ to \\QuizGame10\\.</span></span>
-   <span data-ttu-id="413fa-184">一般的な場合は、モデル、ビュー、およびビューモデルはされます意味上に共有フォルダーを参照します。</span><span class="sxs-lookup"><span data-stu-id="413fa-184">Common, Model, View, and ViewModel are what we'll mean when we refer to the shared folders on disk.</span></span>

**<span data-ttu-id="413fa-185">QuizGameHost</span><span class="sxs-lookup"><span data-stu-id="413fa-185">QuizGameHost</span></span>**

-   <span data-ttu-id="413fa-186">プロジェクトを作成する新しい Windows 10 アプリ (**追加** &gt; **新しいプロジェクト** &gt; **Windows ユニバーサル** &gt; **空のアプリケーション (Windows ユニバーサル)**)、QuizGameHost という名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="413fa-186">Create a new Windows 10 app project (**Add** &gt; **New Project** &gt; **Windows Universal** &gt; **Blank Application (Windows Universal)**) and name it QuizGameHost.</span></span>
-   <span data-ttu-id="413fa-187">P2PHelper への参照を追加する (**[参照の追加** &gt; **プロジェクト** &gt; **ソリューション** &gt; **P2PHelper**)。</span><span class="sxs-lookup"><span data-stu-id="413fa-187">Add a reference to P2PHelper (**Add Reference** &gt; **Projects** &gt; **Solution** &gt; **P2PHelper**).</span></span>
-   <span data-ttu-id="413fa-188">**ソリューション エクスプ ローラー**で各ディスク上の共有フォルダーの新しいフォルダーを作成します。</span><span class="sxs-lookup"><span data-stu-id="413fa-188">In **Solution Explorer**, create a new folder for each of the shared folders on disk.</span></span> <span data-ttu-id="413fa-189">でき、作成した各フォルダーを右クリックし、[**追加**] をクリックして&gt;**既存のアイテム**フォルダーを移動します。</span><span class="sxs-lookup"><span data-stu-id="413fa-189">In turn, right-click each folder you just created and click **Add** &gt; **Existing Item** and navigate up a folder.</span></span> <span data-ttu-id="413fa-190">適切な共有フォルダーを開き、すべてのファイルを選択し、[**リンクとして追加**] をクリックします。</span><span class="sxs-lookup"><span data-stu-id="413fa-190">Open the appropriate shared folder, select all files, and then click **Add As Link**.</span></span>
-   <span data-ttu-id="413fa-191">\\QuizGame.Windows\\ から \\QuizGameHost\\ に MainPage.xaml をコピーし、QuizGameHost 名前空間に変更します。</span><span class="sxs-lookup"><span data-stu-id="413fa-191">Copy MainPage.xaml from \\QuizGame.Windows\\ to \\QuizGameHost\\ and change the namespace to QuizGameHost.</span></span>
-   <span data-ttu-id="413fa-192">\\QuizGame.Shared\\ から \\QuizGameHost\\ に App.xaml をコピーし、QuizGameHost 名前空間に変更します。</span><span class="sxs-lookup"><span data-stu-id="413fa-192">Copy App.xaml from \\QuizGame.Shared\\ to \\QuizGameHost\\ and change the namespace to QuizGameHost.</span></span>
-   <span data-ttu-id="413fa-193">App.xaml.cs を上書きするには、代わりには、新しいプロジェクトでのバージョンを残すし、くださいローカル テスト モードをサポートするために 1 つの対象となる変更します。</span><span class="sxs-lookup"><span data-stu-id="413fa-193">Instead of overwriting app.xaml.cs, we'll keep the version in the new project and just make one targeted change to it to support local test mode.</span></span> <span data-ttu-id="413fa-194">App.xaml.cs] で、次のコード行を置き換えます。</span><span class="sxs-lookup"><span data-stu-id="413fa-194">In app.xaml.cs, replace this line of code:</span></span>

```CSharp
rootFrame.Navigate(typeof(MainPage), e.Arguments);
```

<span data-ttu-id="413fa-195">こっちと：</span><span class="sxs-lookup"><span data-stu-id="413fa-195">with this:</span></span>

```CSharp
#if LOCALTESTMODEON
    rootFrame.Navigate(typeof(TestView), e.Arguments);
#else
    rootFrame.Navigate(typeof(MainPage), e.Arguments);
#endif
```

-   <span data-ttu-id="413fa-196">**プロパティ**に&gt;**ビルド** &gt; **条件付きコンパイル記号と特殊文字**LOCALTESTMODEON を追加します。</span><span class="sxs-lookup"><span data-stu-id="413fa-196">In **Properties** &gt; **Build** &gt; **conditional compilation symbols**, add LOCALTESTMODEON.</span></span>
-   <span data-ttu-id="413fa-197">App.xaml.cs に追加したコードに戻るし、TestView 型を解決できるようになりましたができます。</span><span class="sxs-lookup"><span data-stu-id="413fa-197">You'll now be able to go back to the code you added to app.xaml.cs and resolve the TestView type.</span></span>
-   <span data-ttu-id="413fa-198">Package.appxmanifest] では、機能名を internetClient から internetClientServer に変更します。</span><span class="sxs-lookup"><span data-stu-id="413fa-198">In package.appxmanifest, change the capability name from internetClient to internetClientServer.</span></span>

**<span data-ttu-id="413fa-199">QuizGameClient</span><span class="sxs-lookup"><span data-stu-id="413fa-199">QuizGameClient</span></span>**

-   <span data-ttu-id="413fa-200">プロジェクトを作成する新しい Windows 10 アプリ (**追加** &gt; **新しいプロジェクト** &gt; **Windows ユニバーサル** &gt; **空のアプリケーション (Windows ユニバーサル)**)、QuizGameClient という名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="413fa-200">Create a new Windows 10 app project (**Add** &gt; **New Project** &gt; **Windows Universal** &gt; **Blank Application (Windows Universal)**) and name it QuizGameClient.</span></span>
-   <span data-ttu-id="413fa-201">P2PHelper への参照を追加する (**[参照の追加** &gt; **プロジェクト** &gt; **ソリューション** &gt; **P2PHelper**)。</span><span class="sxs-lookup"><span data-stu-id="413fa-201">Add a reference to P2PHelper (**Add Reference** &gt; **Projects** &gt; **Solution** &gt; **P2PHelper**).</span></span>
-   <span data-ttu-id="413fa-202">**ソリューション エクスプ ローラー**で各ディスク上の共有フォルダーの新しいフォルダーを作成します。</span><span class="sxs-lookup"><span data-stu-id="413fa-202">In **Solution Explorer**, create a new folder for each of the shared folders on disk.</span></span> <span data-ttu-id="413fa-203">でき、作成した各フォルダーを右クリックし、[**追加**] をクリックして&gt;**既存のアイテム**フォルダーを移動します。</span><span class="sxs-lookup"><span data-stu-id="413fa-203">In turn, right-click each folder you just created and click **Add** &gt; **Existing Item** and navigate up a folder.</span></span> <span data-ttu-id="413fa-204">適切な共有フォルダーを開き、すべてのファイルを選択し、[**リンクとして追加**] をクリックします。</span><span class="sxs-lookup"><span data-stu-id="413fa-204">Open the appropriate shared folder, select all files, and then click **Add As Link**.</span></span>
-   <span data-ttu-id="413fa-205">\\QuizGame.WindowsPhone\\ から \\QuizGameClient\\ に MainPage.xaml をコピーし、QuizGameClient 名前空間に変更します。</span><span class="sxs-lookup"><span data-stu-id="413fa-205">Copy MainPage.xaml from \\QuizGame.WindowsPhone\\ to \\QuizGameClient\\ and change the namespace to QuizGameClient.</span></span>
-   <span data-ttu-id="413fa-206">\\QuizGame.Shared\\ から \\QuizGameClient\\ に App.xaml をコピーし、QuizGameClient 名前空間に変更します。</span><span class="sxs-lookup"><span data-stu-id="413fa-206">Copy App.xaml from \\QuizGame.Shared\\ to \\QuizGameClient\\ and change the namespace to QuizGameClient.</span></span>
-   <span data-ttu-id="413fa-207">Package.appxmanifest] では、機能名を internetClient から internetClientServer に変更します。</span><span class="sxs-lookup"><span data-stu-id="413fa-207">In package.appxmanifest, change the capability name from internetClient to internetClientServer.</span></span>

<span data-ttu-id="413fa-208">今すぐことができますを作成して実行します。</span><span class="sxs-lookup"><span data-stu-id="413fa-208">You'll now be able to build and run.</span></span>

## <a name="adaptive-ui"></a><span data-ttu-id="413fa-209">アダプティブ UI</span><span class="sxs-lookup"><span data-stu-id="413fa-209">Adaptive UI</span></span>

<span data-ttu-id="413fa-210">QuizGameHost Windows 10 アプリは、(これは大きなスクリーンを備えたデバイスでのみ)、ワイド ウィンドウで、アプリの実行時に問題が表示されます。</span><span class="sxs-lookup"><span data-stu-id="413fa-210">The QuizGameHost Windows 10 app looks fine when the app is running in a wide window (which is only possible on a device with a large screen).</span></span> <span data-ttu-id="413fa-211">ときに、アプリのウィンドウ狭くが (する、小さなデバイスとも大きなデバイスで発生することができます)、UI を読みやすくがないことも禁止がします。</span><span class="sxs-lookup"><span data-stu-id="413fa-211">When the app's window is narrow, though (which happens on a small device, and can also happen on a large device), the UI is squashed so much that it's unreadable.</span></span>

<span data-ttu-id="413fa-212">ここで説明するように、適応視覚的な状態マネージャー機能を使用して、、この問題を解決できますお[のケース スタディ: Bookstore2](w8x-to-uwp-case-study-bookstore2.md)します。</span><span class="sxs-lookup"><span data-stu-id="413fa-212">We can use the adaptive Visual State Manager feature to remedy this, as we explained in [Case study: Bookstore2](w8x-to-uwp-case-study-bookstore2.md).</span></span> <span data-ttu-id="413fa-213">最初に、既定では、UI が狭い状態でレイアウトように、視覚的な要素のプロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="413fa-213">First, set properties on visual elements so that, by default, the UI is laid out in the narrow state.</span></span> <span data-ttu-id="413fa-214">\\View\\HostView.xaml ですべての変更が行われます。</span><span class="sxs-lookup"><span data-stu-id="413fa-214">All of these changes take place in \\View\\HostView.xaml.</span></span>

-   <span data-ttu-id="413fa-215">メイン]**グリッド**では、最初の**わかり**「140」から「自動」の**高さ**を変更します。</span><span class="sxs-lookup"><span data-stu-id="413fa-215">In the main **Grid**, change the **Height** of the first **RowDefinition** from "140" to "Auto".</span></span>
-   <span data-ttu-id="413fa-216">**TextBlock**が含まれている**グリッド**で、名前付き`pageTitle`、`x:Name="pageTitleGrid"`と`Height="60"`します。</span><span class="sxs-lookup"><span data-stu-id="413fa-216">On the **Grid** that contains the **TextBlock** named `pageTitle`, set `x:Name="pageTitleGrid"` and `Height="60"`.</span></span> <span data-ttu-id="413fa-217">最初の 2 つの手順を視覚的な状態の設定を使ってその**わかり**の高さを効率的に制御できます。</span><span class="sxs-lookup"><span data-stu-id="413fa-217">These first two steps are so that we can effectively control the height of that **RowDefinition** via a setter in a visual state.</span></span>
-   <span data-ttu-id="413fa-218">`pageTitle`、`Margin="-30,0,0,0"`します。</span><span class="sxs-lookup"><span data-stu-id="413fa-218">On `pageTitle`, set `Margin="-30,0,0,0"`.</span></span>
-   <span data-ttu-id="413fa-219">コメントで表示された**グリッド**上で`<!-- Content -->`、`x:Name="contentGrid"`と`Margin="-18,12,0,0"`します。</span><span class="sxs-lookup"><span data-stu-id="413fa-219">On the **Grid** indicated by the comment `<!-- Content -->`, set `x:Name="contentGrid"` and `Margin="-18,12,0,0"`.</span></span>
-   <span data-ttu-id="413fa-220">コメントのすぐ上の**TextBlock**で`<!-- Options -->`、`Margin="0,0,0,24"`します。</span><span class="sxs-lookup"><span data-stu-id="413fa-220">On the **TextBlock** immediately above the comment `<!-- Options -->`, set `Margin="0,0,0,24"`.</span></span>
-   <span data-ttu-id="413fa-221">既定の**TextBlock**スタイル (ファイルの最初のリソース) には、「15」に**フォント サイズ**の設定の値を変更します。</span><span class="sxs-lookup"><span data-stu-id="413fa-221">In the default **TextBlock** style (the first resource in the file), change the **FontSize** setter's value to "15".</span></span>
-   <span data-ttu-id="413fa-222">`OptionContentControlStyle`、**フォント サイズ**の設定の値を「20」に変更します。</span><span class="sxs-lookup"><span data-stu-id="413fa-222">In `OptionContentControlStyle`, change the **FontSize** setter's value to "20".</span></span> <span data-ttu-id="413fa-223">ここでは、前の 1 つはご意見ご感想のすべてのデバイスで動作する適切な型に傾斜します。</span><span class="sxs-lookup"><span data-stu-id="413fa-223">This step and the previous one will give us a good type ramp that will work well on all devices.</span></span> <span data-ttu-id="413fa-224">Windows 8.1 のアプリを使用していた「30」よりもより柔軟なサイズです。</span><span class="sxs-lookup"><span data-stu-id="413fa-224">These are much more flexible sizes than the "30" we were using for the Windows 8.1 app.</span></span>
-   <span data-ttu-id="413fa-225">最後に、**グリッド**のルートに適切な視覚的な状態マネージャー変更履歴とコメントを追加します。</span><span class="sxs-lookup"><span data-stu-id="413fa-225">Finally, add the appropriate Visual State Manager markup to the root **Grid**.</span></span>

```xml
<VisualStateManager.VisualStateGroups>
    <VisualStateGroup>
        <VisualState x:Name="WideState">
            <VisualState.StateTriggers>
                <AdaptiveTrigger MinWindowWidth="548"/>
            </VisualState.StateTriggers>
            <VisualState.Setters>
                <Setter Target="pageTitleGrid.Height" Value="140"/>
                <Setter Target="pageTitle.Margin" Value="0,0,30,40"/>
                <Setter Target="contentGrid.Margin" Value="40,40,0,0"/>
            </VisualState.Setters>
        </VisualState>
    </VisualStateGroup>
</VisualStateManager.VisualStateGroups>
```

## <a name="universal-styling"></a><span data-ttu-id="413fa-226">ユニバーサル スタイル設定</span><span class="sxs-lookup"><span data-stu-id="413fa-226">Universal styling</span></span>


<span data-ttu-id="413fa-227">Windows 10 の場合は、ボタンが、そのテンプレート内のスペース同じタッチ ターゲット必要がないことがわかります。</span><span class="sxs-lookup"><span data-stu-id="413fa-227">You'll notice that in Windows 10, the buttons don't have the same touch-target padding in their template.</span></span> <span data-ttu-id="413fa-228">2 つの小さな変更を解決します。</span><span class="sxs-lookup"><span data-stu-id="413fa-228">Two small changes will remedy that.</span></span> <span data-ttu-id="413fa-229">まず、QuizGameHost と QuizGameClient の両方で app.xaml にこの変更履歴とコメントを追加します。</span><span class="sxs-lookup"><span data-stu-id="413fa-229">First, add this markup to app.xaml in both QuizGameHost and QuizGameClient.</span></span>

```xml
<Style TargetType="Button">
    <Setter Property="Margin" Value="12"/>
</Style>
```

<span data-ttu-id="413fa-230">次に、この設定を追加して`OptionButtonStyle`\\View\\ClientView.xaml にします。</span><span class="sxs-lookup"><span data-stu-id="413fa-230">And second, add this setter to `OptionButtonStyle` in \\View\\ClientView.xaml.</span></span>

```xml
<Setter Property="Margin" Value="6"/>
```

<span data-ttu-id="413fa-231">その最後の微調整にアプリの動作し、外観同じポートの前に、と、その他の値を持つことを実行場所でします。</span><span class="sxs-lookup"><span data-stu-id="413fa-231">With that last tweak, the app will behave and look just the same as it did before the port, with the additional value that it will now run everywhere.</span></span>

## <a name="conclusion"></a><span data-ttu-id="413fa-232">まとめ</span><span class="sxs-lookup"><span data-stu-id="413fa-232">Conclusion</span></span>

<span data-ttu-id="413fa-233">事例で移植ここでは、アプリでは、複数のプロジェクト、クラス ライブラリ、および非常に大量のコードとユーザー インターフェイスを含む比較的複雑な 1 つをしました。</span><span class="sxs-lookup"><span data-stu-id="413fa-233">The app that we ported in this case study was a relatively complex one involving several projects, a class library, and quite a large amount of code and user interface.</span></span> <span data-ttu-id="413fa-234">それでも、ポートの簡単なでした。</span><span class="sxs-lookup"><span data-stu-id="413fa-234">Even so, the port was straightforward.</span></span> <span data-ttu-id="413fa-235">移植性の一部は直接 Windows 10 の開発プラットフォームおよび Windows 8.1 および Windows Phone 8.1 プラットフォーム間の類似性します。</span><span class="sxs-lookup"><span data-stu-id="413fa-235">Some of the ease of porting is directly attributable to the similarity between the Windows 10 developer platform and the Windows 8.1 and Windows Phone 8.1 platforms.</span></span> <span data-ttu-id="413fa-236">一部が元のアプリケーションの設計されたモデル、モデルの表示、およびビューを別々 に保管する方法。</span><span class="sxs-lookup"><span data-stu-id="413fa-236">Some is due to the way the original app was designed to keep the models, the view models, and the views separate.</span></span>
