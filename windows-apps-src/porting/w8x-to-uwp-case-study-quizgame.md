---
author: stevewhims
ms.assetid: 88e16ec8-deff-4a60-bda6-97c5dabc30b8
description: このトピックでは、機能しているピア ツー ピアのクイズ ゲーム WinRT 8.1 サンプル アプリを windows 10 ユニバーサル Windows プラットフォーム (UWP) アプリを移植するケース スタディを示します。
title: Windows ランタイム 8.x から UWP へのケース スタディ、QuizGame ピア ツー ピアのサンプル アプリ
ms.author: stwhi
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 69aae85f4e0bb01833114ae5b2cbfab45e9dd84d
ms.sourcegitcommit: 9f8010fe67bb3372db1840de9f0be36097ed6258
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/16/2018
ms.locfileid: "7128932"
---
# <a name="windows-runtime-8x-to-uwp-case-study-quizgame-sample-app"></a><span data-ttu-id="4f9c0-104">Windows ランタイム 8.x から UWP へのケース スタディ: QuizGame サンプル アプリ</span><span class="sxs-lookup"><span data-stu-id="4f9c0-104">Windows Runtime 8.x to UWP case study: QuizGame sample app</span></span>




<span data-ttu-id="4f9c0-105">このトピックでは、機能しているピア ツー ピアのクイズ ゲーム WinRT 8.1 サンプル アプリを移植 Windows10Universal Windows プラットフォーム (UWP) アプリのケース スタディします。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-105">This topic presents a case study of porting a functioning peer-to-peer quiz game WinRT 8.1 sample app to a Windows10Universal Windows Platform (UWP) app.</span></span>

<span data-ttu-id="4f9c0-106">ユニバーサル 8.1 アプリは、同じアプリの 2 つのバージョンを構築する 1 つ: Windows8.1、用の 1 つのアプリ パッケージと Windows Phone 8.1 用の別のアプリ パッケージです。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-106">A Universal 8.1 app is one that builds two versions of the same app: one app package for Windows8.1, and a different app package for Windows Phone 8.1.</span></span> <span data-ttu-id="4f9c0-107">QuizGame の WinRT 8.1 バージョンは、ユニバーサル Windows アプリ プロジェクトの配置を使用してが異なるアプローチがかかり、2 つのプラットフォーム用の機能的に異なるアプリをビルドします。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-107">The WinRT 8.1 version of QuizGame uses a Universal Windows app project arrangement, but it takes a different approach and it builds a functionally distinct app for the two platforms.</span></span> <span data-ttu-id="4f9c0-108">Windows8.1 アプリ パッケージでは、クイズ ゲーム セッションのホストとして機能 Windows Phone 8.1 アプリ パッケージをホストするクライアントの役割の再生中にします。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-108">The Windows8.1 app package serves as the host for a quiz game session, while the Windows Phone 8.1 app package plays the role of the client to the host.</span></span> <span data-ttu-id="4f9c0-109">クイズ ゲーム セッションの 2 つの要素は、ピア ツー ピア ネットワーク経由で通信します。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-109">The two halves of the quiz game session communicate via peer-to-peer networking.</span></span>

<span data-ttu-id="4f9c0-110">適切であるは、それぞれに PC とスマート フォンで 2 つの要素を調整します。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-110">Tailoring the two halves to PC, and phone, respectively makes good sense.</span></span> <span data-ttu-id="4f9c0-111">ただし、できればより高い場合は、選択した場合のほぼ任意のデバイスで、ホストおよびクライアントの両方を実行する可能性がありますか。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-111">But, wouldn't it be even better if you could run both the host and the client on just about any device of your choosing?</span></span> <span data-ttu-id="4f9c0-112">ここでスタディでは、移植します両方のアプリを windows 10 では各を構築する際にユーザーが、多様なデバイスにインストールできる単一のアプリ パッケージにします。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-112">In this case study, we'll port both apps to Windows10 where they will each build into a single app package that users can install onto a wide range of devices.</span></span>

<span data-ttu-id="4f9c0-113">アプリでは、ビューの使用し、モデルの表示を構成するパターンを使用します。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-113">The app uses patterns that make use of views and view models.</span></span> <span data-ttu-id="4f9c0-114">このクリーンの分離した結果としてこのアプリの移植プロセスは非常に単純ですが表示されます。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-114">As a result of this clean separation, the porting process for this app is very straightforward, as you'll see.</span></span>

<span data-ttu-id="4f9c0-115">**注:** このサンプルでは、カスタム UDP を送受信する、ネットワークが構成されていると想定しています (ほとんどのホーム ネットワークは、会社のネットワークができない可能性がありますが) マルチキャストをグループ化します。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-115">**Note**This sample assumes your network is configured to send and receive custom UDP group multicast packets (most home networks are, although your work network may not be).</span></span> <span data-ttu-id="4f9c0-116">このサンプルも送信し、TCP パケットを受信します。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-116">The sample also sends and receives TCP packets.</span></span>

 

<span data-ttu-id="4f9c0-117">**注:** とき、Visual Studio で QuizGame10 を開く「Visual Studio 更新プログラムが必要」、メッセージが表示し、手順に従います[TargetPlatformVersion](w8x-to-uwp-troubleshooting.md)します。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-117">**Note** When opening QuizGame10 in Visual Studio, if you see the message "Visual Studio update required", then follow the steps in [TargetPlatformVersion](w8x-to-uwp-troubleshooting.md).</span></span>

 

## <a name="downloads"></a><span data-ttu-id="4f9c0-118">ダウンロード</span><span class="sxs-lookup"><span data-stu-id="4f9c0-118">Downloads</span></span>

<span data-ttu-id="4f9c0-119">[QuizGame ユニバーサル 8.1 アプリをダウンロード](http://go.microsoft.com/fwlink/?linkid=532953)します。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-119">[Download the QuizGame Universal 8.1 app](http://go.microsoft.com/fwlink/?linkid=532953).</span></span> <span data-ttu-id="4f9c0-120">これは、移植する前に、アプリの初期状態です。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-120">This is the initial state of the app prior to porting.</span></span> 

<span data-ttu-id="4f9c0-121">[Windows 10 アプリをダウンロード、QuizGame10](http://go.microsoft.com/fwlink/?linkid=532954)します。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-121">[Download the QuizGame10 Windows10 app](http://go.microsoft.com/fwlink/?linkid=532954).</span></span> <span data-ttu-id="4f9c0-122">これは、アプリの状態は、移植直後後です。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-122">This is the state of the app just after  porting.</span></span> 

<span data-ttu-id="4f9c0-123">[このサンプル github の最新バージョンを参照してください](https://github.com/Microsoft/Windows-appsample-quizgame)。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-123">[See the latest version of this sample on GitHub](https://github.com/Microsoft/Windows-appsample-quizgame).</span></span>

## <a name="the-winrt-81-solution"></a><span data-ttu-id="4f9c0-124">WinRT 8.1 ソリューション</span><span class="sxs-lookup"><span data-stu-id="4f9c0-124">The WinRT 8.1 solution</span></span>


<span data-ttu-id="4f9c0-125">どのような QuizGame を次に示します: ポートを行いましょうアプリなどのようになります。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-125">Here’s what QuizGame—the app that we're going to port—looks like.</span></span>

![windows で実行されている quizgame ホスト アプリ](images/w8x-to-uwp-case-studies/c04-01-win81-how-the-host-app-looks.png)

<span data-ttu-id="4f9c0-127">Windows で実行されている QuizGame ホスト アプリ</span><span class="sxs-lookup"><span data-stu-id="4f9c0-127">The QuizGame host app running on Windows</span></span>

 

![windows phone で実行されている quizgame クライアント アプリ](images/w8x-to-uwp-case-studies/c04-02-wp81-how-the-client-app-looks.png)

<span data-ttu-id="4f9c0-129">Windows Phone で実行されている QuizGame クライアント アプリ</span><span class="sxs-lookup"><span data-stu-id="4f9c0-129">The QuizGame client app running on Windows Phone</span></span>

## <a name="a-walkthrough-of-quizgame-in-use"></a><span data-ttu-id="4f9c0-130">QuizGame の使用のチュートリアル</span><span class="sxs-lookup"><span data-stu-id="4f9c0-130">A walkthrough of QuizGame in use</span></span>

<span data-ttu-id="4f9c0-131">これは、使用中のアプリの短い仮定アカウントが、ワイヤレス ネットワーク経由で自分のアプリを試す便利な情報を提供します。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-131">This is a short hypothetical account of the app in use, but it provides useful info should you want to try out the app for yourself over your wireless network.</span></span>

<span data-ttu-id="4f9c0-132">楽しいクイズ ゲームで行われてバー。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-132">A fun quiz game is taking place in a bar.</span></span> <span data-ttu-id="4f9c0-133">すべてのユーザーに表示されるバーには、大きなテレビがあります。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-133">There's a big TV in the bar that everyone can see.</span></span> <span data-ttu-id="4f9c0-134">Quizmaster では、テレビでの出力が表示されている PC があります。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-134">The quizmaster has a PC whose output is being shown on the TV.</span></span> <span data-ttu-id="4f9c0-135">その PC では、「ホスト アプリ」ことで実行されているがあります。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-135">That PC has "the host app" running on it.</span></span> <span data-ttu-id="4f9c0-136">クイズだけで参加する必要のあるユーザーは、スマート フォンやサーフェスに「クライアント アプリ」をインストールする必要があります。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-136">Anyone who wants to take part in the quiz just needs to install "the client app" on their phone or Surface.</span></span>

<span data-ttu-id="4f9c0-137">ホスト アプリ ロビー モードでは、大きなテレビでそれが広告クライアント アプリが接続できる状態であります。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-137">The host app is in lobby mode, and on the big TV, it's advertising that it's ready for client apps to connect.</span></span> <span data-ttu-id="4f9c0-138">ジャンヌは、自分のモバイル デバイスで、クライアント アプリを起動します。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-138">Joan launches the client app on her mobile device.</span></span> <span data-ttu-id="4f9c0-139">彼女は、**プレイヤーの名前**] ボックスに自分の名前を入力し、**ゲームへの参加**をタップします。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-139">She types her name into the **Player name** text box and taps **Join game**.</span></span> <span data-ttu-id="4f9c0-140">ホスト アプリでは、ジャンヌが自分の名前を表示することによって参加しているし、ジャンヌのクライアント アプリがゲームを開始するを待機していることを示すことを確認します。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-140">The host app acknowledges that Joan has joined by displaying her name, and Joan’s client app indicates that it's waiting for the game to begin.</span></span> <span data-ttu-id="4f9c0-141">次に、マックスウェルは自分のモバイル デバイスで同じ手順を通過します。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-141">Next, Maxwell goes through those same steps on his mobile device.</span></span>

<span data-ttu-id="4f9c0-142">Quizmaster をクリックして**ゲームを開始**して、ホスト アプリは、質問と回答 (も示しますに参加しているプレイヤーの一覧で通常 fontweight を灰色で表示) を示しています。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-142">The quizmaster clicks **Start game** and the host app shows a question and the possible answers (it also shows a list of the joined players in normal fontweight, colored gray).</span></span> <span data-ttu-id="4f9c0-143">同時に、回答が表示されるに参加しているクライアント デバイス上のボタンに表示されます。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-143">Simultaneously, the answers appear displayed on buttons on joined client devices.</span></span> <span data-ttu-id="4f9c0-144">ジャンヌがよく、自分のすべてのボタンを無効になる上の答え「1975」ボタンをタップします。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-144">Joan taps the button with the answer "1975" on it whereupon all her buttons become disabled.</span></span> <span data-ttu-id="4f9c0-145">ホスト アプリでジャンヌの名緑色に描画されます (および太字になります) その応答の受領通知の受信します。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-145">On the host app, Joan’s name is painted green (and becomes bold) in acknowledgment of the receipt of her answer.</span></span> <span data-ttu-id="4f9c0-146">マックスウェル回答もします。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-146">Maxwell answers, also.</span></span> <span data-ttu-id="4f9c0-147">すべてのプレイヤーの名が、緑色であることが示されます、quizmaster では、**次の質問**をクリックします。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-147">The quizmaster, noting that all players' names are green, clicks **Next question**.</span></span>

<span data-ttu-id="4f9c0-148">質問を続行し、この同じサイクルで応答します。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-148">Questions continue to be asked and answered in this same cycle.</span></span> <span data-ttu-id="4f9c0-149">最後の質問は、ホスト アプリで表示されると、**結果の表示**は、ボタンと**次の質問**ではないのコンテンツです。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-149">When the last question is being shown on the host app, **Show results** is the content of the button, and not **Next question**.</span></span> <span data-ttu-id="4f9c0-150">**結果の表示**がクリックされると、結果が表示されます。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-150">When **Show results** is clicked, the results are shown.</span></span> <span data-ttu-id="4f9c0-151">**ロビーに戻す**] をクリックして返しますに参加していることを除いて、ゲームのライフ サイクルの先頭にプレイヤーのままに参加しています。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-151">Clicking **Return to lobby** returns to the beginning of the game lifecycle with the exception that joined players remain joined.</span></span> <span data-ttu-id="4f9c0-152">ただし、新しいプレイヤーに参加しているプレイヤー (ただしに参加しているプレイヤーを**ゲームのままに**タップすると、いつでもでもかまいません) のままにする便利な時間に参加する機会が得られますロビーに戻っています。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-152">But, going back to the lobby gives new players a chance to join, and even a convenient time for joined players to leave (although a joined player can leave at any time by tapping **Leave game**).</span></span>

## <a name="local-test-mode"></a><span data-ttu-id="4f9c0-153">ローカル テスト モード</span><span class="sxs-lookup"><span data-stu-id="4f9c0-153">Local test mode</span></span>

<span data-ttu-id="4f9c0-154">アプリとデバイス間で分散型ではなく 1 台の PC では、その操作を試すには、ローカルのテスト モードでホスト アプリを構築できます。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-154">To try out the app and its interactions on a single PC instead of distributed across devices, you can build the host app in local test mode.</span></span> <span data-ttu-id="4f9c0-155">このモードでは、ネットワークの使用がまったく実行されません。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-155">This mode completely bypasses use of the network.</span></span> <span data-ttu-id="4f9c0-156">代わりに、ホスト アプリの UI は、ウィンドウの左側にホスト部分を表示し、クライアント アプリの UI の 2 つのコピーを縦に並んだ、右に (、今回のバージョンではローカル テスト モード UI が修正されたに注意してください。 PC ディスプレイ。 それに適応しない小型のデバイス)。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-156">Instead, the UI of the host app displays the host portion to the left of the window and, to the right, two copies of the client app UI stacked vertically (note that, in this version, the local test mode UI is fixed for a PC display; it does not adapt to small devices).</span></span> <span data-ttu-id="4f9c0-157">すべてで、同じアプリに、UI のこれらのセグメントはそうしないと実施、ネットワーク経由での操作をシミュレートするモック クライアント通信経由で相互に通信します。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-157">These segments of UI, all in the same app, communicate with one another via a mock client communicator, which simulates the interactions that would otherwise take place over the network.</span></span>

<span data-ttu-id="4f9c0-158">ローカル テスト モードをアクティブ化するには、条件付きコンパイル シンボルとして**LOCALTESTMODEON** ([プロジェクトのプロパティ) を定義し、リビルドしてください。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-158">To activate local test mode, define **LOCALTESTMODEON** (in project properties) as a conditional compilation symbol, and rebuild.</span></span>

## <a name="porting-to-a-windows10-project"></a><span data-ttu-id="4f9c0-159">Windows 10 プロジェクトへの移植</span><span class="sxs-lookup"><span data-stu-id="4f9c0-159">Porting to a Windows10 project</span></span>

<span data-ttu-id="4f9c0-160">QuizGame では、次の部分があります。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-160">QuizGame has the following pieces.</span></span>

-   <span data-ttu-id="4f9c0-161">P2PHelper します。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-161">P2PHelper.</span></span> <span data-ttu-id="4f9c0-162">これは、ピア ツー ピア ネットワーク ロジックが含まれているポータブル クラス ライブラリです。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-162">This is a portable class library that contains the peer-to-peer networking logic.</span></span>
-   <span data-ttu-id="4f9c0-163">QuizGame.Windows します。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-163">QuizGame.Windows.</span></span> <span data-ttu-id="4f9c0-164">これは、Windows8.1 をターゲットとなるホスト アプリのアプリ パッケージを構築するプロジェクトです。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-164">This is the project that builds the app package for the host app, which targets Windows8.1.</span></span>
-   <span data-ttu-id="4f9c0-165">QuizGame.WindowsPhone します。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-165">QuizGame.WindowsPhone.</span></span> <span data-ttu-id="4f9c0-166">これは、Windows Phone 8.1 を対象となるクライアント アプリのアプリ パッケージを構築するプロジェクトです。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-166">This is the project that builds the app package for the client app, which targets Windows Phone 8.1.</span></span>
-   <span data-ttu-id="4f9c0-167">QuizGame.Shared します。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-167">QuizGame.Shared.</span></span> <span data-ttu-id="4f9c0-168">これは、他の 2 つのプロジェクトの両方で使われるソース コード、マークアップ ファイル、および他のアセットやリソースを含むプロジェクトです。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-168">This is the project that contains source code, markup files, and other assets and resources, that are used by both of the other two projects.</span></span>

<span data-ttu-id="4f9c0-169">このケース スタディでは、サポートするデバイスに関して、「[ユニバーサル 8.1 アプリがある場合](w8x-to-uwp-root.md)」で説明した通常のオプションを使います。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-169">For this case study, we have the usual options described in [If you have a Universal 8.1 app](w8x-to-uwp-root.md) with respect to what devices to support.</span></span>

<span data-ttu-id="4f9c0-170">これらのオプションに基づき、QuizGameHost と呼ばれる新しい windows 10 プロジェクトを QuizGame.Windows を移植します。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-170">Based on those options, we'll port QuizGame.Windows to a new Windows10 project called QuizGameHost.</span></span> <span data-ttu-id="4f9c0-171">また、QuizGame.WindowsPhone QuizGameClient と呼ばれる新しい windows 10 プロジェクトを移植します。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-171">And, we'll port QuizGame.WindowsPhone to a new Windows10 project called QuizGameClient.</span></span> <span data-ttu-id="4f9c0-172">任意のデバイスで実行されるため、これらのプロジェクトは、ユニバーサル デバイス ファミリをターゲットします。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-172">These projects will target the universal device family, so they will run on any device.</span></span> <span data-ttu-id="4f9c0-173">いきます、QuizGame.Shared ソース ファイルなど、独自のフォルダーと、2 つの新しいプロジェクトにそれらの共有ファイルにリンクします。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-173">And, we'll keep the QuizGame.Shared source files, etc, in their own folder, and we'll link those shared files into the two new projects.</span></span> <span data-ttu-id="4f9c0-174">前に、1 つのソリューションではそのまましますがここでは、名前 QuizGame10 と同じようにします。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-174">Just like before, we'll keep everything in one solution and we'll name it QuizGame10.</span></span>

**<span data-ttu-id="4f9c0-175">QuizGame10 ソリューション</span><span class="sxs-lookup"><span data-stu-id="4f9c0-175">The QuizGame10 solution</span></span>**

-   <span data-ttu-id="4f9c0-176">新しいソリューションを作成 (**新しいプロジェクト** &gt; **その他のプロジェクトの種類** &gt; **Visual Studio ソリューション**) と QuizGame10 名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-176">Create a new solution (**New Project** &gt; **Other Project Types** &gt; **Visual Studio Solutions**) and name it QuizGame10.</span></span>

**<span data-ttu-id="4f9c0-177">P2PHelper</span><span class="sxs-lookup"><span data-stu-id="4f9c0-177">P2PHelper</span></span>**

-   <span data-ttu-id="4f9c0-178">ソリューションでは、新しい windows 10 クラス ライブラリ プロジェクトを作成します (**新しいプロジェクト** &gt; **Windows ユニバーサル** &gt; **クラス ライブラリ (Windows ユニバーサル)**) と P2PHelper 名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-178">In the solution, create a new Windows10 class library project (**New Project** &gt; **Windows Universal** &gt; **Class Library (Windows Universal)**) and name it P2PHelper.</span></span>
-   <span data-ttu-id="4f9c0-179">新しいプロジェクトの Class1.cs を削除します。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-179">Delete Class1.cs from the new project.</span></span>
-   <span data-ttu-id="4f9c0-180">新しいプロジェクトのフォルダーに P2PSession.cs、P2PSessionClient.cs、および P2PSessionHost.cs をコピーし、新しいプロジェクトにコピーしたファイルを含めます。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-180">Copy P2PSession.cs, P2PSessionClient.cs, and P2PSessionHost.cs into the new project's folder and include the copied files in the new project.</span></span>
-   <span data-ttu-id="4f9c0-181">さらに変更を必要とすることがなく、プロジェクトがビルドされます。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-181">The project will build without needing further changes.</span></span>

**<span data-ttu-id="4f9c0-182">共有ファイル</span><span class="sxs-lookup"><span data-stu-id="4f9c0-182">Shared files</span></span>**

-   <span data-ttu-id="4f9c0-183">\\QuizGame.Shared\\ から \\QuizGame10\\ に一般的に、モデル、ビュー、および ViewModel フォルダーをコピーします。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-183">Copy the folders Common, Model, View, and ViewModel from \\QuizGame.Shared\\ to \\QuizGame10\\.</span></span>
-   <span data-ttu-id="4f9c0-184">一般的なモデル、ビュー、および ViewModel は何を意味しますディスク上の共有フォルダーを参照するときです。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-184">Common, Model, View, and ViewModel are what we'll mean when we refer to the shared folders on disk.</span></span>

**<span data-ttu-id="4f9c0-185">QuizGameHost</span><span class="sxs-lookup"><span data-stu-id="4f9c0-185">QuizGameHost</span></span>**

-   <span data-ttu-id="4f9c0-186">新しい windows 10 アプリ プロジェクトを作成 (**追加** &gt; **新しいプロジェクト** &gt; **Windows ユニバーサル** &gt; **空のアプリケーション (Windows ユニバーサル)**) と QuizGameHost 名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-186">Create a new Windows10 app project (**Add** &gt; **New Project** &gt; **Windows Universal** &gt; **Blank Application (Windows Universal)**) and name it QuizGameHost.</span></span>
-   <span data-ttu-id="4f9c0-187">P2PHelper への参照を追加 (**参照の追加** &gt; **プロジェクト** &gt; **ソリューション** &gt; **P2PHelper**)。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-187">Add a reference to P2PHelper (**Add Reference** &gt; **Projects** &gt; **Solution** &gt; **P2PHelper**).</span></span>
-   <span data-ttu-id="4f9c0-188">**ソリューション エクスプ ローラー**では、各ディスク上の共有フォルダーの新しいフォルダーを作成します。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-188">In **Solution Explorer**, create a new folder for each of the shared folders on disk.</span></span> <span data-ttu-id="4f9c0-189">次に、先ほど作成した各フォルダーを右クリックし、[**追加**] をクリックして&gt;**既存項目**のフォルダーを移動します。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-189">In turn, right-click each folder you just created and click **Add** &gt; **Existing Item** and navigate up a folder.</span></span> <span data-ttu-id="4f9c0-190">適切な共有フォルダーを開き、すべてのファイルを選択し、**追加のリンク**をクリックします。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-190">Open the appropriate shared folder, select all files, and then click **Add As Link**.</span></span>
-   <span data-ttu-id="4f9c0-191">\\QuizGameHost\\ を \\QuizGame.Windows\\ から MainPage.xaml をコピーし、名前空間を QuizGameHost に変更します。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-191">Copy MainPage.xaml from \\QuizGame.Windows\\ to \\QuizGameHost\\ and change the namespace to QuizGameHost.</span></span>
-   <span data-ttu-id="4f9c0-192">App.xaml を \\QuizGame.Shared\\ から \\QuizGameHost\\ にコピーし、名前空間を QuizGameHost に変更します。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-192">Copy App.xaml from \\QuizGame.Shared\\ to \\QuizGameHost\\ and change the namespace to QuizGameHost.</span></span>
-   <span data-ttu-id="4f9c0-193">App.xaml.cs を上書きするのではなくおをで新しいプロジェクトのバージョンを保持し、ローカル テスト モードをサポートするために 1 つの対象となる変更を加えるだけです。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-193">Instead of overwriting app.xaml.cs, we'll keep the version in the new project and just make one targeted change to it to support local test mode.</span></span> <span data-ttu-id="4f9c0-194">App.xaml.cs ファイルでは、次のコード行を置き換えます。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-194">In app.xaml.cs, replace this line of code:</span></span>

```CSharp
rootFrame.Navigate(typeof(MainPage), e.Arguments);
```

<span data-ttu-id="4f9c0-195">こっちと：</span><span class="sxs-lookup"><span data-stu-id="4f9c0-195">with this:</span></span>

```CSharp
#if LOCALTESTMODEON
    rootFrame.Navigate(typeof(TestView), e.Arguments);
#else
    rootFrame.Navigate(typeof(MainPage), e.Arguments);
#endif
```

-   <span data-ttu-id="4f9c0-196">**プロパティ**で&gt;**ビルド** &gt; **条件付きコンパイル シンボル**が LOCALTESTMODEON を追加します。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-196">In **Properties** &gt; **Build** &gt; **conditional compilation symbols**, add LOCALTESTMODEON.</span></span>
-   <span data-ttu-id="4f9c0-197">App.xaml.cs に追加したコードに戻り、TestView 型を解決することがなります。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-197">You'll now be able to go back to the code you added to app.xaml.cs and resolve the TestView type.</span></span>
-   <span data-ttu-id="4f9c0-198">、Package.appxmanifest で internetClientServer を internetClient から機能名を変更します。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-198">In package.appxmanifest, change the capability name from internetClient to internetClientServer.</span></span>

**<span data-ttu-id="4f9c0-199">QuizGameClient</span><span class="sxs-lookup"><span data-stu-id="4f9c0-199">QuizGameClient</span></span>**

-   <span data-ttu-id="4f9c0-200">新しい windows 10 アプリ プロジェクトを作成 (**追加** &gt; **新しいプロジェクト** &gt; **Windows ユニバーサル** &gt; **空のアプリケーション (Windows ユニバーサル)**) と QuizGameClient 名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-200">Create a new Windows10 app project (**Add** &gt; **New Project** &gt; **Windows Universal** &gt; **Blank Application (Windows Universal)**) and name it QuizGameClient.</span></span>
-   <span data-ttu-id="4f9c0-201">P2PHelper への参照を追加 (**参照の追加** &gt; **プロジェクト** &gt; **ソリューション** &gt; **P2PHelper**)。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-201">Add a reference to P2PHelper (**Add Reference** &gt; **Projects** &gt; **Solution** &gt; **P2PHelper**).</span></span>
-   <span data-ttu-id="4f9c0-202">**ソリューション エクスプ ローラー**では、各ディスク上の共有フォルダーの新しいフォルダーを作成します。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-202">In **Solution Explorer**, create a new folder for each of the shared folders on disk.</span></span> <span data-ttu-id="4f9c0-203">次に、先ほど作成した各フォルダーを右クリックし、[**追加**] をクリックして&gt;**既存項目**のフォルダーを移動します。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-203">In turn, right-click each folder you just created and click **Add** &gt; **Existing Item** and navigate up a folder.</span></span> <span data-ttu-id="4f9c0-204">適切な共有フォルダーを開き、すべてのファイルを選択し、**追加のリンク**をクリックします。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-204">Open the appropriate shared folder, select all files, and then click **Add As Link**.</span></span>
-   <span data-ttu-id="4f9c0-205">\\QuizGameClient\\ を \\QuizGame.WindowsPhone\\ から MainPage.xaml をコピーし、名前空間を QuizGameClient に変更します。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-205">Copy MainPage.xaml from \\QuizGame.WindowsPhone\\ to \\QuizGameClient\\ and change the namespace to QuizGameClient.</span></span>
-   <span data-ttu-id="4f9c0-206">App.xaml を \\QuizGame.Shared\\ から \\QuizGameClient\\ にコピーし、名前空間を QuizGameClient に変更します。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-206">Copy App.xaml from \\QuizGame.Shared\\ to \\QuizGameClient\\ and change the namespace to QuizGameClient.</span></span>
-   <span data-ttu-id="4f9c0-207">、Package.appxmanifest で internetClientServer を internetClient から機能名を変更します。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-207">In package.appxmanifest, change the capability name from internetClient to internetClientServer.</span></span>

<span data-ttu-id="4f9c0-208">今すぐことができますをビルドして実行します。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-208">You'll now be able to build and run.</span></span>

## <a name="adaptive-ui"></a><span data-ttu-id="4f9c0-209">アダプティブ UI</span><span class="sxs-lookup"><span data-stu-id="4f9c0-209">Adaptive UI</span></span>

<span data-ttu-id="4f9c0-210">(これは、大規模なスクリーンを備えたデバイスでのみ) 幅の広いウィンドウで、アプリが実行されている場合、QuizGameHost windows 10 アプリは正常表示になります。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-210">The QuizGameHost Windows10 app looks fine when the app is running in a wide window (which is only possible on a device with a large screen).</span></span> <span data-ttu-id="4f9c0-211">とき、アプリのウィンドウが狭い場合は (小型のデバイスで行われます、、大型のデバイスもあります)、UI を読み取ることがないことずっと禁止されます。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-211">When the app's window is narrow, though (which happens on a small device, and can also happen on a large device), the UI is squashed so much that it's unreadable.</span></span>

<span data-ttu-id="4f9c0-212">説明した、これを修正するアダプティブな Visual State Manager 機能を使うできます[ケース スタディ: Bookstore2](w8x-to-uwp-case-study-bookstore2.md)します。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-212">We can use the adaptive Visual State Manager feature to remedy this, as we explained in [Case study: Bookstore2](w8x-to-uwp-case-study-bookstore2.md).</span></span> <span data-ttu-id="4f9c0-213">最初に、既定では、UI が幅の狭い状態でレイアウトされるよう視覚要素のプロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-213">First, set properties on visual elements so that, by default, the UI is laid out in the narrow state.</span></span> <span data-ttu-id="4f9c0-214">\\View\\HostView.xaml でこれらすべての変更が行われます。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-214">All of these changes take place in \\View\\HostView.xaml.</span></span>

-   <span data-ttu-id="4f9c0-215">メイン**Grid**では、最初の**RowDefinition** 「140」から「自動」の**高さ**を変更します。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-215">In the main **Grid**, change the **Height** of the first **RowDefinition** from "140" to "Auto".</span></span>
-   <span data-ttu-id="4f9c0-216">という名前の**TextBlock**が含まれている**グリッド**で`pageTitle`設定`x:Name="pageTitleGrid"`と`Height="60"`します。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-216">On the **Grid** that contains the **TextBlock** named `pageTitle`, set `x:Name="pageTitleGrid"` and `Height="60"`.</span></span> <span data-ttu-id="4f9c0-217">最初の 2 つの手順は表示状態 setter 経由でその**RowDefinition**の高さを効果的に制御できます。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-217">These first two steps are so that we can effectively control the height of that **RowDefinition** via a setter in a visual state.</span></span>
-   <span data-ttu-id="4f9c0-218">`pageTitle`設定`Margin="-30,0,0,0"`します。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-218">On `pageTitle`, set `Margin="-30,0,0,0"`.</span></span>
-   <span data-ttu-id="4f9c0-219">コメント**グリッド**で`<!-- Content -->`設定`x:Name="contentGrid"`と`Margin="-18,12,0,0"`します。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-219">On the **Grid** indicated by the comment `<!-- Content -->`, set `x:Name="contentGrid"` and `Margin="-18,12,0,0"`.</span></span>
-   <span data-ttu-id="4f9c0-220">コメントのすぐ上、 **TextBlock**で`<!-- Options -->`設定`Margin="0,0,0,24"`します。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-220">On the **TextBlock** immediately above the comment `<!-- Options -->`, set `Margin="0,0,0,24"`.</span></span>
-   <span data-ttu-id="4f9c0-221">既定の**TextBlock**スタイル (ファイルの最初のリソース) では、 **FontSize** setter の値を「15」に変更します。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-221">In the default **TextBlock** style (the first resource in the file), change the **FontSize** setter's value to "15".</span></span>
-   <span data-ttu-id="4f9c0-222">`OptionContentControlStyle`、 **FontSize** setter の値を「20」に変更します。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-222">In `OptionContentControlStyle`, change the **FontSize** setter's value to "20".</span></span> <span data-ttu-id="4f9c0-223">この手順と、前のタスクは得るすべてのデバイスで適切に動作する優れた書体見本できます。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-223">This step and the previous one will give us a good type ramp that will work well on all devices.</span></span> <span data-ttu-id="4f9c0-224">これらは、Windows8.1 アプリで使っていた「30」よりもはるかに柔軟なサイズです。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-224">These are much more flexible sizes than the "30" we were using for the Windows8.1 app.</span></span>
-   <span data-ttu-id="4f9c0-225">最後に、ルート**グリッド**に適切な Visual State Manager のマークアップを追加します。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-225">Finally, add the appropriate Visual State Manager markup to the root **Grid**.</span></span>

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

## <a name="universal-styling"></a><span data-ttu-id="4f9c0-226">ユニバーサル スタイル設定</span><span class="sxs-lookup"><span data-stu-id="4f9c0-226">Universal styling</span></span>


<span data-ttu-id="4f9c0-227">Windows 10 では、ボタンが、パディングのテンプレートでは、同じタッチ ターゲット必要がないということがわかります。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-227">You'll notice that in Windows10, the buttons don't have the same touch-target padding in their template.</span></span> <span data-ttu-id="4f9c0-228">2 つの小規模な変更を修正します。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-228">Two small changes will remedy that.</span></span> <span data-ttu-id="4f9c0-229">まず、app.xaml QuizGameHost と QuizGameClient の両方でをこのマークアップを追加します。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-229">First, add this markup to app.xaml in both QuizGameHost and QuizGameClient.</span></span>

```xml
<Style TargetType="Button">
    <Setter Property="Margin" Value="12"/>
</Style>
```

<span data-ttu-id="4f9c0-230">2 番目をこの setter を追加および`OptionButtonStyle`\\View\\ClientView.xaml にします。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-230">And second, add this setter to `OptionButtonStyle` in \\View\\ClientView.xaml.</span></span>

```xml
<Setter Property="Margin" Value="6"/>
```

<span data-ttu-id="4f9c0-231">その最後の調整と、アプリが動作して、見て同じポートの前に、と、その他の値を持つことは、実行どこからでも。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-231">With that last tweak, the app will behave and look just the same as it did before the port, with the additional value that it will now run everywhere.</span></span>

## <a name="conclusion"></a><span data-ttu-id="4f9c0-232">まとめ</span><span class="sxs-lookup"><span data-stu-id="4f9c0-232">Conclusion</span></span>

<span data-ttu-id="4f9c0-233">スタディで移植ここではアプリは、複数のプロジェクト、クラス ライブラリ、およびしばらくたちますが大量のコードとユーザー インターフェイスや、筋肉比較的複雑なものでした。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-233">The app that we ported in this case study was a relatively complex one involving several projects, a class library, and quite a large amount of code and user interface.</span></span> <span data-ttu-id="4f9c0-234">それでも、ポートは、単純な作業でした。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-234">Even so, the port was straightforward.</span></span> <span data-ttu-id="4f9c0-235">移植性の一部は、windows 10 開発者向けプラットフォームおよび Windows8.1 と Windows Phone 8.1 のプラットフォーム間の類似性に直接起因します。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-235">Some of the ease of porting is directly attributable to the similarity between the Windows10 developer platform and the Windows8.1 and Windows Phone 8.1 platforms.</span></span> <span data-ttu-id="4f9c0-236">いくつかが元のアプリが、モデル、ビュー モデル、ビューを別々 に保管するように設計された方法は、原因です。</span><span class="sxs-lookup"><span data-stu-id="4f9c0-236">Some is due to the way the original app was designed to keep the models, the view models, and the views separate.</span></span>
