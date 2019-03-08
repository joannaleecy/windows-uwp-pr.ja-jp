---
ms.assetid: 88e16ec8-deff-4a60-bda6-97c5dabc30b8
description: このトピックでは、機能しているピア ツー ピア クイズ ゲーム WinRT 8.1 サンプル アプリを Windows 10 ユニバーサル Windows プラットフォーム (UWP) アプリへの移植のケース スタディを表示します。
title: Windows ランタイム 8.x から UWP へのケース スタディ - QuizGame ピア ツー ピアのサンプル アプリ
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: d2d1b2b4e6875730d5a6bfa8dd711e11ac5d049c
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57642917"
---
# <a name="windows-runtime-8x-to-uwp-case-study-quizgame-sample-app"></a><span data-ttu-id="b5698-104">Windows ランタイム 8.x UWP の事例に。QuizGame サンプル アプリ</span><span class="sxs-lookup"><span data-stu-id="b5698-104">Windows Runtime 8.x to UWP case study: QuizGame sample app</span></span>




<span data-ttu-id="b5698-105">このトピックでは、機能しているピア ツー ピア クイズ ゲーム WinRT 8.1 サンプル アプリを Windows 10 ユニバーサル Windows プラットフォーム (UWP) アプリへの移植のケース スタディを表示します。</span><span class="sxs-lookup"><span data-stu-id="b5698-105">This topic presents a case study of porting a functioning peer-to-peer quiz game WinRT 8.1 sample app to a Windows 10 Universal Windows Platform (UWP) app.</span></span>

<span data-ttu-id="b5698-106">8.1 ユニバーサル アプリは、同じアプリの 2 つのバージョンをビルドする 1 つ。 1 つのアプリ パッケージの Windows 8.1、および Windows Phone 8.1 用の別のアプリ パッケージ。</span><span class="sxs-lookup"><span data-stu-id="b5698-106">A Universal 8.1 app is one that builds two versions of the same app: one app package for Windows 8.1, and a different app package for Windows Phone 8.1.</span></span> <span data-ttu-id="b5698-107">QuizGame の WinRT 8.1 バージョンでは、ユニバーサル Windows アプリ プロジェクトに用意されているデータを使いますが、独自の方法が採用されており、2 つのプラットフォームに対して機能的に異なるアプリがビルドされます。</span><span class="sxs-lookup"><span data-stu-id="b5698-107">The WinRT 8.1 version of QuizGame uses a Universal Windows app project arrangement, but it takes a different approach and it builds a functionally distinct app for the two platforms.</span></span> <span data-ttu-id="b5698-108">Windows 8.1 アプリ パッケージでは、クイズ ゲーム セッションのホストとして機能、Windows Phone 8.1 アプリ パッケージをホストに、クライアントの役割の再生中にします。</span><span class="sxs-lookup"><span data-stu-id="b5698-108">The Windows 8.1 app package serves as the host for a quiz game session, while the Windows Phone 8.1 app package plays the role of the client to the host.</span></span> <span data-ttu-id="b5698-109">クイズ ゲーム セッションの 2 つの要素は、ピア ツー ピア ネットワークを経由して通信します。</span><span class="sxs-lookup"><span data-stu-id="b5698-109">The two halves of the quiz game session communicate via peer-to-peer networking.</span></span>

<span data-ttu-id="b5698-110">これら 2 つの要素を PC や電話向けにそれぞれ調整することで、適切なアプリを作ることができます。</span><span class="sxs-lookup"><span data-stu-id="b5698-110">Tailoring the two halves to PC, and phone, respectively makes good sense.</span></span> <span data-ttu-id="b5698-111">また、必要となるほとんどのデバイスでホストとクライアントの両方を実行できたら、より便利ではないでしょうか。</span><span class="sxs-lookup"><span data-stu-id="b5698-111">But, wouldn't it be even better if you could run both the host and the client on just about any device of your choosing?</span></span> <span data-ttu-id="b5698-112">ここで調査では、それらが各ビルド場所をユーザーがさまざまなデバイスにインストールできる 1 つのアプリ パッケージに Windows 10 に両方のアプリを移植します。</span><span class="sxs-lookup"><span data-stu-id="b5698-112">In this case study, we'll port both apps to Windows 10 where they will each build into a single app package that users can install onto a wide range of devices.</span></span>

<span data-ttu-id="b5698-113">アプリでは、ビューとビュー モデルを使うパターンを採用します。</span><span class="sxs-lookup"><span data-stu-id="b5698-113">The app uses patterns that make use of views and view models.</span></span> <span data-ttu-id="b5698-114">このパターンではビューとビュー モデルが明確に分離されているため、以下の説明をご覧になるとわかりますが、このアプリの移植プロセスは非常に簡単です。</span><span class="sxs-lookup"><span data-stu-id="b5698-114">As a result of this clean separation, the porting process for this app is very straightforward, as you'll see.</span></span>

<span data-ttu-id="b5698-115">**注**  このサンプルは、カスタムの UDP を送受信するネットワークが構成されている前提としています。 マルチキャスト パケット数 (ほとんどのホーム ネットワークは、職場のネットワークができない可能性がありますが) をグループ化します。</span><span class="sxs-lookup"><span data-stu-id="b5698-115">**Note**  This sample assumes your network is configured to send and receive custom UDP group multicast packets (most home networks are, although your work network may not be).</span></span> <span data-ttu-id="b5698-116">また、このサンプルでは TCP パケットを送受信します。</span><span class="sxs-lookup"><span data-stu-id="b5698-116">The sample also sends and receives TCP packets.</span></span>

 

<span data-ttu-id="b5698-117">**注**  とき"Visual Studio の更新に必要な"メッセージを表示する場合は、Visual Studio で、QuizGame10 を開いてし、手順に従います[TargetPlatformVersion](w8x-to-uwp-troubleshooting.md)します。</span><span class="sxs-lookup"><span data-stu-id="b5698-117">**Note**   When opening QuizGame10 in Visual Studio, if you see the message "Visual Studio update required", then follow the steps in [TargetPlatformVersion](w8x-to-uwp-troubleshooting.md).</span></span>

 

## <a name="downloads"></a><span data-ttu-id="b5698-118">ダウンロード</span><span class="sxs-lookup"><span data-stu-id="b5698-118">Downloads</span></span>

<span data-ttu-id="b5698-119">[QuizGame ユニバーサル 8.1 アプリをダウンロードします](https://go.microsoft.com/fwlink/?linkid=532953)。</span><span class="sxs-lookup"><span data-stu-id="b5698-119">[Download the QuizGame Universal 8.1 app](https://go.microsoft.com/fwlink/?linkid=532953).</span></span> <span data-ttu-id="b5698-120">これは、移植前の初期状態のアプリです。</span><span class="sxs-lookup"><span data-stu-id="b5698-120">This is the initial state of the app prior to porting.</span></span> 

<span data-ttu-id="b5698-121">[Windows 10 アプリのダウンロード、QuizGame10](https://go.microsoft.com/fwlink/?linkid=532954)します。</span><span class="sxs-lookup"><span data-stu-id="b5698-121">[Download the QuizGame10 Windows 10 app](https://go.microsoft.com/fwlink/?linkid=532954).</span></span> <span data-ttu-id="b5698-122">これは、移植直後の状態のアプリです。</span><span class="sxs-lookup"><span data-stu-id="b5698-122">This is the state of the app just after  porting.</span></span> 

<span data-ttu-id="b5698-123">[このサンプルの最新バージョンについては GitHub をご覧ください](https://github.com/Microsoft/Windows-appsample-quizgame)。</span><span class="sxs-lookup"><span data-stu-id="b5698-123">[See the latest version of this sample on GitHub](https://github.com/Microsoft/Windows-appsample-quizgame).</span></span>

## <a name="the-winrt-81-solution"></a><span data-ttu-id="b5698-124">WinRT 8.1 ソリューション</span><span class="sxs-lookup"><span data-stu-id="b5698-124">The WinRT 8.1 solution</span></span>


<span data-ttu-id="b5698-125">次に、ここで移植するアプリ QuizGame の外観を示します。</span><span class="sxs-lookup"><span data-stu-id="b5698-125">Here’s what QuizGame—the app that we're going to port—looks like.</span></span>

![Windows で実行されている QuizGame ホスト アプリ](images/w8x-to-uwp-case-studies/c04-01-win81-how-the-host-app-looks.png)

<span data-ttu-id="b5698-127">Windows で実行されている QuizGame ホスト アプリ</span><span class="sxs-lookup"><span data-stu-id="b5698-127">The QuizGame host app running on Windows</span></span>

 

![Windows Phone で実行されている QuizGame クライアント アプリ](images/w8x-to-uwp-case-studies/c04-02-wp81-how-the-client-app-looks.png)

<span data-ttu-id="b5698-129">Windows Phone で実行されている QuizGame クライアント アプリ</span><span class="sxs-lookup"><span data-stu-id="b5698-129">The QuizGame client app running on Windows Phone</span></span>

## <a name="a-walkthrough-of-quizgame-in-use"></a><span data-ttu-id="b5698-130">このケース スタディで使う QuizGame のチュートリアル</span><span class="sxs-lookup"><span data-stu-id="b5698-130">A walkthrough of QuizGame in use</span></span>

<span data-ttu-id="b5698-131">ここで使うアプリの簡単な説明を示します。これは架空のアプリの説明ですが、ワイヤレス ネットワークでアプリを使う場合に役立つ情報も記載されています。</span><span class="sxs-lookup"><span data-stu-id="b5698-131">This is a short hypothetical account of the app in use, but it provides useful info should you want to try out the app for yourself over your wireless network.</span></span>

<span data-ttu-id="b5698-132">楽しいクイズ ゲームがバーで行われています。</span><span class="sxs-lookup"><span data-stu-id="b5698-132">A fun quiz game is taking place in a bar.</span></span> <span data-ttu-id="b5698-133">バーには大型テレビがあり、全員がそのテレビを見ることができます。</span><span class="sxs-lookup"><span data-stu-id="b5698-133">There's a big TV in the bar that everyone can see.</span></span> <span data-ttu-id="b5698-134">クイズ番組の司会者は PC を使っており、その出力画面が TV に映し出されています。</span><span class="sxs-lookup"><span data-stu-id="b5698-134">The quizmaster has a PC whose output is being shown on the TV.</span></span> <span data-ttu-id="b5698-135">その PC では "ホスト アプリ" が実行されています。</span><span class="sxs-lookup"><span data-stu-id="b5698-135">That PC has "the host app" running on it.</span></span> <span data-ttu-id="b5698-136">クイズへの参加を希望する視聴者は、"クライアント アプリ" を自分の携帯電話や Surface にインストールするだけです。</span><span class="sxs-lookup"><span data-stu-id="b5698-136">Anyone who wants to take part in the quiz just needs to install "the client app" on their phone or Surface.</span></span>

<span data-ttu-id="b5698-137">ホスト アプリはロビー モードになっており、大型テレビでは、クライアント アプリ接続の準備ができていることを通知しています。</span><span class="sxs-lookup"><span data-stu-id="b5698-137">The host app is in lobby mode, and on the big TV, it's advertising that it's ready for client apps to connect.</span></span> <span data-ttu-id="b5698-138">Joan は、モバイル デバイスでクライアント アプリを起動します。</span><span class="sxs-lookup"><span data-stu-id="b5698-138">Joan launches the client app on her mobile device.</span></span> <span data-ttu-id="b5698-139">彼女は、**[Player name] (プレーヤー名)** テキスト ボックスに自分の名前を入力してから **[Join game] (ゲームに参加)** をタップします。</span><span class="sxs-lookup"><span data-stu-id="b5698-139">She types her name into the **Player name** text box and taps **Join game**.</span></span> <span data-ttu-id="b5698-140">ホスト アプリでは Joan の名前が表示され、彼女の参加が認識されました。また、Joan のクライアント アプリでは、ゲームの開始を待機していることが示されています。</span><span class="sxs-lookup"><span data-stu-id="b5698-140">The host app acknowledges that Joan has joined by displaying her name, and Joan’s client app indicates that it's waiting for the game to begin.</span></span> <span data-ttu-id="b5698-141">次に、Maxwell が同じ手順を自分のモバイル デバイスで実行しました。</span><span class="sxs-lookup"><span data-stu-id="b5698-141">Next, Maxwell goes through those same steps on his mobile device.</span></span>

<span data-ttu-id="b5698-142">クイズ番組の司会者が **[Start game] (ゲームの開始)** をクリックすると、ホスト アプリには質問と正しいと思われる回答がいくつか表示されます (参加しているプレイヤーの一覧も表示されます。この一覧では、フォントの太さは通常、色は灰色で表示されます)。</span><span class="sxs-lookup"><span data-stu-id="b5698-142">The quizmaster clicks **Start game** and the host app shows a question and the possible answers (it also shows a list of the joined players in normal fontweight, colored gray).</span></span> <span data-ttu-id="b5698-143">同時に、参加しているクライアント デバイスでは、回答がボタンで表示されます。</span><span class="sxs-lookup"><span data-stu-id="b5698-143">Simultaneously, the answers appear displayed on buttons on joined client devices.</span></span> <span data-ttu-id="b5698-144">Joan は "1975" と示されている回答のボタンをタップしました。するとすぐに、すべてのボタンが無効になりました。</span><span class="sxs-lookup"><span data-stu-id="b5698-144">Joan taps the button with the answer "1975" on it whereupon all her buttons become disabled.</span></span> <span data-ttu-id="b5698-145">ホスト アプリでは、Joan の名前が太字の緑色で表示され、彼女の回答が受信されたことが示されました。</span><span class="sxs-lookup"><span data-stu-id="b5698-145">On the host app, Joan’s name is painted green (and becomes bold) in acknowledgment of the receipt of her answer.</span></span> <span data-ttu-id="b5698-146">Maxwell の回答しました。</span><span class="sxs-lookup"><span data-stu-id="b5698-146">Maxwell answers, also.</span></span> <span data-ttu-id="b5698-147">クイズ番組の司会者はすべてプレーヤーの名前が緑色になったことを確認して、**[Next question] (次の質問)** をクリックしました。</span><span class="sxs-lookup"><span data-stu-id="b5698-147">The quizmaster, noting that all players' names are green, clicks **Next question**.</span></span>

<span data-ttu-id="b5698-148">引き続き、同じ手順で質問の表示と回答が繰り返されました。</span><span class="sxs-lookup"><span data-stu-id="b5698-148">Questions continue to be asked and answered in this same cycle.</span></span> <span data-ttu-id="b5698-149">最後の質問がホスト アプリに表示されると、ボタンの内容は **[Next question] (次の質問)** ではなく、**[Show results] (結果の表示)** となりました。</span><span class="sxs-lookup"><span data-stu-id="b5698-149">When the last question is being shown on the host app, **Show results** is the content of the button, and not **Next question**.</span></span> <span data-ttu-id="b5698-150">**[Show results] (結果の表示)** をクリックすると、結果が表示されました。</span><span class="sxs-lookup"><span data-stu-id="b5698-150">When **Show results** is clicked, the results are shown.</span></span> <span data-ttu-id="b5698-151">**[Return to lobby] (ロビーに戻る)** をクリックすると、ゲームのライフ サイクルの最初に戻りますが、プレイヤーは参加したままになります。</span><span class="sxs-lookup"><span data-stu-id="b5698-151">Clicking **Return to lobby** returns to the beginning of the game lifecycle with the exception that joined players remain joined.</span></span> <span data-ttu-id="b5698-152">ただし、ロビーに戻ると、新しいプレイヤーが参加できるようになります。このとき、参加していたプレイヤーはゲームの参加をやめることができます (**[Leave game] (ゲームの参加をやめる)** をタップすることで、参加しているプレイヤーはいつでもゲームをやめることができます)。</span><span class="sxs-lookup"><span data-stu-id="b5698-152">But, going back to the lobby gives new players a chance to join, and even a convenient time for joined players to leave (although a joined player can leave at any time by tapping **Leave game**).</span></span>

## <a name="local-test-mode"></a><span data-ttu-id="b5698-153">ローカル テスト モード</span><span class="sxs-lookup"><span data-stu-id="b5698-153">Local test mode</span></span>

<span data-ttu-id="b5698-154">アプリとその操作を、(複数のデバイスに分散された状態ではなく) 1 台の PC でテストする場合は、ローカル テスト モードでホスト アプリをビルドできます。</span><span class="sxs-lookup"><span data-stu-id="b5698-154">To try out the app and its interactions on a single PC instead of distributed across devices, you can build the host app in local test mode.</span></span> <span data-ttu-id="b5698-155">このモードでは、ネットワークはまったく使われません。</span><span class="sxs-lookup"><span data-stu-id="b5698-155">This mode completely bypasses use of the network.</span></span> <span data-ttu-id="b5698-156">代わりに、ホスト アプリの UI では、ウィンドウの左側にはホスト部分の画面が表示され、右側にはクライアント アプリの UI をコピーした 2 つの画面が上下に並べて表示されます (このバージョンでは、ローカル テスト モードの UI は PC のディスプレイ用に固定されており、小型のデバイスには対応していません)。</span><span class="sxs-lookup"><span data-stu-id="b5698-156">Instead, the UI of the host app displays the host portion to the left of the window and, to the right, two copies of the client app UI stacked vertically (note that, in this version, the local test mode UI is fixed for a PC display; it does not adapt to small devices).</span></span> <span data-ttu-id="b5698-157">UI のこれらのセグメント (すべて同じアプリに属しています) は、モック クライアント コミュニケーターを経由して相互に通信します。このコミュニケーターは、ネットワークを通じて実行される操作をシミュレートします。</span><span class="sxs-lookup"><span data-stu-id="b5698-157">These segments of UI, all in the same app, communicate with one another via a mock client communicator, which simulates the interactions that would otherwise take place over the network.</span></span>

<span data-ttu-id="b5698-158">ローカル テスト モードを有効にするには、**LOCALTESTMODEON** (プロジェクトのプロパティ) を条件付きコンパイル シンボルとして定義して、リビルドします。</span><span class="sxs-lookup"><span data-stu-id="b5698-158">To activate local test mode, define **LOCALTESTMODEON** (in project properties) as a conditional compilation symbol, and rebuild.</span></span>

## <a name="porting-to-a-windows10-project"></a><span data-ttu-id="b5698-159">Windows 10 プロジェクトへの移植</span><span class="sxs-lookup"><span data-stu-id="b5698-159">Porting to a Windows 10 project</span></span>

<span data-ttu-id="b5698-160">QuizGame には、次の要素が含まれています。</span><span class="sxs-lookup"><span data-stu-id="b5698-160">QuizGame has the following pieces.</span></span>

-   <span data-ttu-id="b5698-161">P2PHelper。</span><span class="sxs-lookup"><span data-stu-id="b5698-161">P2PHelper.</span></span> <span data-ttu-id="b5698-162">これは、ピア ツー ピアのネットワーク ロジックを含むポータブル クラス ライブラリです。</span><span class="sxs-lookup"><span data-stu-id="b5698-162">This is a portable class library that contains the peer-to-peer networking logic.</span></span>
-   <span data-ttu-id="b5698-163">QuizGame.Windows。</span><span class="sxs-lookup"><span data-stu-id="b5698-163">QuizGame.Windows.</span></span> <span data-ttu-id="b5698-164">これは、ホストのアプリでは、Windows 8.1 を対象とするアプリ パッケージをビルドするプロジェクトです。</span><span class="sxs-lookup"><span data-stu-id="b5698-164">This is the project that builds the app package for the host app, which targets Windows 8.1.</span></span>
-   <span data-ttu-id="b5698-165">QuizGame.WindowsPhone。</span><span class="sxs-lookup"><span data-stu-id="b5698-165">QuizGame.WindowsPhone.</span></span> <span data-ttu-id="b5698-166">これは、Windows Phone 8.1 を対象とするクライアント アプリのアプリ パッケージをビルドするプロジェクトです。</span><span class="sxs-lookup"><span data-stu-id="b5698-166">This is the project that builds the app package for the client app, which targets Windows Phone 8.1.</span></span>
-   <span data-ttu-id="b5698-167">QuizGame.Shared。</span><span class="sxs-lookup"><span data-stu-id="b5698-167">QuizGame.Shared.</span></span> <span data-ttu-id="b5698-168">これは、他の 2 つのプロジェクトの両方で使われるソース コード、マークアップ ファイル、および他のアセットやリソースを含むプロジェクトです。</span><span class="sxs-lookup"><span data-stu-id="b5698-168">This is the project that contains source code, markup files, and other assets and resources, that are used by both of the other two projects.</span></span>

<span data-ttu-id="b5698-169">このケース スタディでは、サポートするデバイスに関して、「[ユニバーサル 8.1 アプリがある場合](w8x-to-uwp-root.md)」で説明した通常のオプションを使います。</span><span class="sxs-lookup"><span data-stu-id="b5698-169">For this case study, we have the usual options described in [If you have a Universal 8.1 app](w8x-to-uwp-root.md) with respect to what devices to support.</span></span>

<span data-ttu-id="b5698-170">これらのオプションに基づき、QuizGameHost と呼ばれる新しい Windows 10 プロジェクトへ QuizGame.Windows のポートがいます。</span><span class="sxs-lookup"><span data-stu-id="b5698-170">Based on those options, we'll port QuizGame.Windows to a new Windows 10 project called QuizGameHost.</span></span> <span data-ttu-id="b5698-171">また、QuizGame.WindowsPhone QuizGameClient と呼ばれる新しい Windows 10 プロジェクトに移植しました。</span><span class="sxs-lookup"><span data-stu-id="b5698-171">And, we'll port QuizGame.WindowsPhone to a new Windows 10 project called QuizGameClient.</span></span> <span data-ttu-id="b5698-172">これらのプロジェクトはユニバーサル デバイス ファミリを対象としているため、どのようなデバイスでも実行できます。</span><span class="sxs-lookup"><span data-stu-id="b5698-172">These projects will target the universal device family, so they will run on any device.</span></span> <span data-ttu-id="b5698-173">また、QuizGame.Shared ソース ファイルなどのファイルを独自のフォルダーに保存し、これらの共有ファイルを 2 つの新しいプロジェクトにリンクします。</span><span class="sxs-lookup"><span data-stu-id="b5698-173">And, we'll keep the QuizGame.Shared source files, etc, in their own folder, and we'll link those shared files into the two new projects.</span></span> <span data-ttu-id="b5698-174">これまでと同様に、すべてのデータを 1 つのソリューションに保存し、QuizGame10 という名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="b5698-174">Just like before, we'll keep everything in one solution and we'll name it QuizGame10.</span></span>

<span data-ttu-id="b5698-175">**QuizGame10 ソリューション**</span><span class="sxs-lookup"><span data-stu-id="b5698-175">**The QuizGame10 solution**</span></span>

-   <span data-ttu-id="b5698-176">新しいソリューションを作成 (**新しいプロジェクト** &gt; **その他のプロジェクトの種類** &gt; **Visual Studio ソリューション**) QuizGame10 名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="b5698-176">Create a new solution (**New Project** &gt; **Other Project Types** &gt; **Visual Studio Solutions**) and name it QuizGame10.</span></span>

<span data-ttu-id="b5698-177">**P2PHelper**</span><span class="sxs-lookup"><span data-stu-id="b5698-177">**P2PHelper**</span></span>

-   <span data-ttu-id="b5698-178">ソリューションでは、新しい Windows 10 クラス ライブラリ プロジェクトを作成します (**新しいプロジェクト** &gt; **Windows ユニバーサル** &gt; **クラス ライブラリ (Windows ユニバーサル)**) P2PHelper 名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="b5698-178">In the solution, create a new Windows 10 class library project (**New Project** &gt; **Windows Universal** &gt; **Class Library (Windows Universal)**) and name it P2PHelper.</span></span>
-   <span data-ttu-id="b5698-179">新しいプロジェクトから Class1.cs を削除します。</span><span class="sxs-lookup"><span data-stu-id="b5698-179">Delete Class1.cs from the new project.</span></span>
-   <span data-ttu-id="b5698-180">P2PSession.cs、P2PSessionClient.cs、P2PSessionHost.cs を新しいプロジェクトのフォルダーにコピーし、コピーしたファイルを新しいプロジェクトに追加します。</span><span class="sxs-lookup"><span data-stu-id="b5698-180">Copy P2PSession.cs, P2PSessionClient.cs, and P2PSessionHost.cs into the new project's folder and include the copied files in the new project.</span></span>
-   <span data-ttu-id="b5698-181">プロジェクトをビルドします。その他の変更は必要ありません。</span><span class="sxs-lookup"><span data-stu-id="b5698-181">The project will build without needing further changes.</span></span>

<span data-ttu-id="b5698-182">**共有ファイル**</span><span class="sxs-lookup"><span data-stu-id="b5698-182">**Shared files**</span></span>

-   <span data-ttu-id="b5698-183">一般的なモデル、ビュー、およびビューモデルからフォルダーをコピー \\QuizGame.Shared\\に\\QuizGame10\\します。</span><span class="sxs-lookup"><span data-stu-id="b5698-183">Copy the folders Common, Model, View, and ViewModel from \\QuizGame.Shared\\ to \\QuizGame10\\.</span></span>
-   <span data-ttu-id="b5698-184">Common、Model、View、ViewModel は、ディスク上の共有フォルダーを参照するときに意味のある名前です。</span><span class="sxs-lookup"><span data-stu-id="b5698-184">Common, Model, View, and ViewModel are what we'll mean when we refer to the shared folders on disk.</span></span>

<span data-ttu-id="b5698-185">**QuizGameHost**</span><span class="sxs-lookup"><span data-stu-id="b5698-185">**QuizGameHost**</span></span>

-   <span data-ttu-id="b5698-186">新しい Windows 10 アプリ プロジェクトの作成 (**追加** &gt; **新しいプロジェクト** &gt; **Windows ユニバーサル** &gt; **空白アプリケーション (Windows ユニバーサル)**) QuizGameHost 名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="b5698-186">Create a new Windows 10 app project (**Add** &gt; **New Project** &gt; **Windows Universal** &gt; **Blank Application (Windows Universal)**) and name it QuizGameHost.</span></span>
-   <span data-ttu-id="b5698-187">P2PHelper への参照の追加 (**参照の追加** &gt; **プロジェクト** &gt; **ソリューション** &gt; **P2PHelper**).</span><span class="sxs-lookup"><span data-stu-id="b5698-187">Add a reference to P2PHelper (**Add Reference** &gt; **Projects** &gt; **Solution** &gt; **P2PHelper**).</span></span>
-   <span data-ttu-id="b5698-188">**ソリューション エクスプ ローラー**で、ディスク上の各共有フォルダー用に新しいフォルダーを作成します。</span><span class="sxs-lookup"><span data-stu-id="b5698-188">In **Solution Explorer**, create a new folder for each of the shared folders on disk.</span></span> <span data-ttu-id="b5698-189">さらに、作成した各フォルダーを右クリックし、クリックして**追加** &gt; **既存項目の**フォルダーを移動します。</span><span class="sxs-lookup"><span data-stu-id="b5698-189">In turn, right-click each folder you just created and click **Add** &gt; **Existing Item** and navigate up a folder.</span></span> <span data-ttu-id="b5698-190">適切な共有フォルダーを開き、すべてのファイルを選んで、**[リンクとして追加]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="b5698-190">Open the appropriate shared folder, select all files, and then click **Add As Link**.</span></span>
-   <span data-ttu-id="b5698-191">MainPage.xaml からコピー \\QuizGame.Windows\\に\\QuizGameHost\\ QuizGameHost を名前空間を変更します。</span><span class="sxs-lookup"><span data-stu-id="b5698-191">Copy MainPage.xaml from \\QuizGame.Windows\\ to \\QuizGameHost\\ and change the namespace to QuizGameHost.</span></span>
-   <span data-ttu-id="b5698-192">App.xaml からコピー \\QuizGame.Shared\\に\\QuizGameHost\\ QuizGameHost を名前空間を変更します。</span><span class="sxs-lookup"><span data-stu-id="b5698-192">Copy App.xaml from \\QuizGame.Shared\\ to \\QuizGameHost\\ and change the namespace to QuizGameHost.</span></span>
-   <span data-ttu-id="b5698-193">app.xaml.cs を上書きせずに、このファイルのバージョンを新しいプロジェクトに保存しておきます。ローカル テスト モードをサポートするように、対象となる変更を 1 つだけそのファイルに加えます。</span><span class="sxs-lookup"><span data-stu-id="b5698-193">Instead of overwriting app.xaml.cs, we'll keep the version in the new project and just make one targeted change to it to support local test mode.</span></span> <span data-ttu-id="b5698-194">app.xaml.cs で、次のコード行を置き換えます。</span><span class="sxs-lookup"><span data-stu-id="b5698-194">In app.xaml.cs, replace this line of code:</span></span>

```CSharp
rootFrame.Navigate(typeof(MainPage), e.Arguments);
```

<span data-ttu-id="b5698-195">上のコード行を次のコード行と置き換えます。</span><span class="sxs-lookup"><span data-stu-id="b5698-195">with this:</span></span>

```CSharp
#if LOCALTESTMODEON
    rootFrame.Navigate(typeof(TestView), e.Arguments);
#else
    rootFrame.Navigate(typeof(MainPage), e.Arguments);
#endif
```

-   <span data-ttu-id="b5698-196">**プロパティ** &gt; **ビルド** &gt; **条件付きコンパイル シンボル**LOCALTESTMODEON を追加します。</span><span class="sxs-lookup"><span data-stu-id="b5698-196">In **Properties** &gt; **Build** &gt; **conditional compilation symbols**, add LOCALTESTMODEON.</span></span>
-   <span data-ttu-id="b5698-197">これで、app.xaml.cs に追加したコードに戻り、TestView 型を解決できます。</span><span class="sxs-lookup"><span data-stu-id="b5698-197">You'll now be able to go back to the code you added to app.xaml.cs and resolve the TestView type.</span></span>
-   <span data-ttu-id="b5698-198">package.appxmanifest で、機能名を internetClient から internetClientServer に変更します。</span><span class="sxs-lookup"><span data-stu-id="b5698-198">In package.appxmanifest, change the capability name from internetClient to internetClientServer.</span></span>

<span data-ttu-id="b5698-199">**QuizGameClient**</span><span class="sxs-lookup"><span data-stu-id="b5698-199">**QuizGameClient**</span></span>

-   <span data-ttu-id="b5698-200">新しい Windows 10 アプリ プロジェクトの作成 (**追加** &gt; **新しいプロジェクト** &gt; **Windows ユニバーサル** &gt; **空白アプリケーション (Windows ユニバーサル)**) QuizGameClient 名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="b5698-200">Create a new Windows 10 app project (**Add** &gt; **New Project** &gt; **Windows Universal** &gt; **Blank Application (Windows Universal)**) and name it QuizGameClient.</span></span>
-   <span data-ttu-id="b5698-201">P2PHelper への参照の追加 (**参照の追加** &gt; **プロジェクト** &gt; **ソリューション** &gt; **P2PHelper**).</span><span class="sxs-lookup"><span data-stu-id="b5698-201">Add a reference to P2PHelper (**Add Reference** &gt; **Projects** &gt; **Solution** &gt; **P2PHelper**).</span></span>
-   <span data-ttu-id="b5698-202">**ソリューション エクスプ ローラー**で、ディスク上の各共有フォルダー用に新しいフォルダーを作成します。</span><span class="sxs-lookup"><span data-stu-id="b5698-202">In **Solution Explorer**, create a new folder for each of the shared folders on disk.</span></span> <span data-ttu-id="b5698-203">さらに、作成した各フォルダーを右クリックし、クリックして**追加** &gt; **既存項目の**フォルダーを移動します。</span><span class="sxs-lookup"><span data-stu-id="b5698-203">In turn, right-click each folder you just created and click **Add** &gt; **Existing Item** and navigate up a folder.</span></span> <span data-ttu-id="b5698-204">適切な共有フォルダーを開き、すべてのファイルを選んで、**[リンクとして追加]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="b5698-204">Open the appropriate shared folder, select all files, and then click **Add As Link**.</span></span>
-   <span data-ttu-id="b5698-205">MainPage.xaml からコピー \\QuizGame.WindowsPhone\\に\\QuizGameClient\\ QuizGameClient を名前空間を変更します。</span><span class="sxs-lookup"><span data-stu-id="b5698-205">Copy MainPage.xaml from \\QuizGame.WindowsPhone\\ to \\QuizGameClient\\ and change the namespace to QuizGameClient.</span></span>
-   <span data-ttu-id="b5698-206">App.xaml からコピー \\QuizGame.Shared\\に\\QuizGameClient\\ QuizGameClient を名前空間を変更します。</span><span class="sxs-lookup"><span data-stu-id="b5698-206">Copy App.xaml from \\QuizGame.Shared\\ to \\QuizGameClient\\ and change the namespace to QuizGameClient.</span></span>
-   <span data-ttu-id="b5698-207">package.appxmanifest で、機能名を internetClient から internetClientServer に変更します。</span><span class="sxs-lookup"><span data-stu-id="b5698-207">In package.appxmanifest, change the capability name from internetClient to internetClientServer.</span></span>

<span data-ttu-id="b5698-208">これで、ビルドして実行することができます。</span><span class="sxs-lookup"><span data-stu-id="b5698-208">You'll now be able to build and run.</span></span>

## <a name="adaptive-ui"></a><span data-ttu-id="b5698-209">アダプティブ UI</span><span class="sxs-lookup"><span data-stu-id="b5698-209">Adaptive UI</span></span>

<span data-ttu-id="b5698-210">(これは、大画面のデバイスでのみ)、ワイド ウィンドウで、アプリが実行されているときに、QuizGameHost Windows 10 アプリは問題ないようです。</span><span class="sxs-lookup"><span data-stu-id="b5698-210">The QuizGameHost Windows 10 app looks fine when the app is running in a wide window (which is only possible on a device with a large screen).</span></span> <span data-ttu-id="b5698-211">ただし、アプリのウィンドウが狭い場合は (小型のデバイスが該当しますが、大型のデバイスの場合もあり得ます)、UI がかなり縮小され、認識するのが難しくなります。</span><span class="sxs-lookup"><span data-stu-id="b5698-211">When the app's window is narrow, though (which happens on a small device, and can also happen on a large device), the UI is squashed so much that it's unreadable.</span></span>

<span data-ttu-id="b5698-212">説明したように、これを修正するアダプティブ Visual State Manager 機能を使用しましたできます[ケース スタディ。Bookstore2](w8x-to-uwp-case-study-bookstore2.md)します。</span><span class="sxs-lookup"><span data-stu-id="b5698-212">We can use the adaptive Visual State Manager feature to remedy this, as we explained in [Case study: Bookstore2](w8x-to-uwp-case-study-bookstore2.md).</span></span> <span data-ttu-id="b5698-213">最初に、既定で UI が幅の狭い状態でレイアウトされるように、視覚要素のプロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="b5698-213">First, set properties on visual elements so that, by default, the UI is laid out in the narrow state.</span></span> <span data-ttu-id="b5698-214">これらすべての変更が行わ\\ビュー\\HostView.xaml します。</span><span class="sxs-lookup"><span data-stu-id="b5698-214">All of these changes take place in \\View\\HostView.xaml.</span></span>

-   <span data-ttu-id="b5698-215">メインの **Grid** で、最初の **RowDefinition** の **Height** を、"140" から "Auto" に変更します。</span><span class="sxs-lookup"><span data-stu-id="b5698-215">In the main **Grid**, change the **Height** of the first **RowDefinition** from "140" to "Auto".</span></span>
-   <span data-ttu-id="b5698-216">`pageTitle` という名前の **TextBlock** を含んでいる **Grid** で、`x:Name="pageTitleGrid"` と `Height="60"` を設定します。</span><span class="sxs-lookup"><span data-stu-id="b5698-216">On the **Grid** that contains the **TextBlock** named `pageTitle`, set `x:Name="pageTitleGrid"` and `Height="60"`.</span></span> <span data-ttu-id="b5698-217">最初の 2 つの手順は、表示状態の setter を使って **RowDefinition** の高さを効果的に制御できるようにするための手順です。</span><span class="sxs-lookup"><span data-stu-id="b5698-217">These first two steps are so that we can effectively control the height of that **RowDefinition** via a setter in a visual state.</span></span>
-   <span data-ttu-id="b5698-218">`pageTitle` で、`Margin="-30,0,0,0"` を設定します。</span><span class="sxs-lookup"><span data-stu-id="b5698-218">On `pageTitle`, set `Margin="-30,0,0,0"`.</span></span>
-   <span data-ttu-id="b5698-219">コメント `<!-- Content -->` で示されている **Grid** で、`x:Name="contentGrid"` と `Margin="-18,12,0,0"` を設定します。</span><span class="sxs-lookup"><span data-stu-id="b5698-219">On the **Grid** indicated by the comment `<!-- Content -->`, set `x:Name="contentGrid"` and `Margin="-18,12,0,0"`.</span></span>
-   <span data-ttu-id="b5698-220">コメント `<!-- Options -->` のすぐ上にある **TextBlock** で、`Margin="0,0,0,24"` を設定します。</span><span class="sxs-lookup"><span data-stu-id="b5698-220">On the **TextBlock** immediately above the comment `<!-- Options -->`, set `Margin="0,0,0,24"`.</span></span>
-   <span data-ttu-id="b5698-221">既定の **TextBlock** スタイル (ファイル内の最初のリソース) で、**FontSize** setter の値を "15" に変更します。</span><span class="sxs-lookup"><span data-stu-id="b5698-221">In the default **TextBlock** style (the first resource in the file), change the **FontSize** setter's value to "15".</span></span>
-   <span data-ttu-id="b5698-222">`OptionContentControlStyle` で、**FontSize** setter の値を "20" に変更します。</span><span class="sxs-lookup"><span data-stu-id="b5698-222">In `OptionContentControlStyle`, change the **FontSize** setter's value to "20".</span></span> <span data-ttu-id="b5698-223">この手順と前の手順によって、すべてのデバイスで適切に動作する優れた書体見本を使うことができます。</span><span class="sxs-lookup"><span data-stu-id="b5698-223">This step and the previous one will give us a good type ramp that will work well on all devices.</span></span> <span data-ttu-id="b5698-224">これらは、Windows 8.1 アプリに使用した「30」よりもサイズが非常に優れた柔軟性です。</span><span class="sxs-lookup"><span data-stu-id="b5698-224">These are much more flexible sizes than the "30" we were using for the Windows 8.1 app.</span></span>
-   <span data-ttu-id="b5698-225">最後に、適切な Visual State Manager のマークアップをルートの **Grid** に追加します。</span><span class="sxs-lookup"><span data-stu-id="b5698-225">Finally, add the appropriate Visual State Manager markup to the root **Grid**.</span></span>

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

## <a name="universal-styling"></a><span data-ttu-id="b5698-226">ユニバーサル スタイル設定</span><span class="sxs-lookup"><span data-stu-id="b5698-226">Universal styling</span></span>


<span data-ttu-id="b5698-227">Windows 10 では、ボタンが、そのテンプレート内のスペース同じタッチ ターゲット必要がないことがわかります。</span><span class="sxs-lookup"><span data-stu-id="b5698-227">You'll notice that in Windows 10, the buttons don't have the same touch-target padding in their template.</span></span> <span data-ttu-id="b5698-228">小規模な変更を 2 つ行うことによって、この問題が解決されます。</span><span class="sxs-lookup"><span data-stu-id="b5698-228">Two small changes will remedy that.</span></span> <span data-ttu-id="b5698-229">最初に、QuizGameHost と QuizGameClient の両方の app.xaml に、次のマークアップを追加します。</span><span class="sxs-lookup"><span data-stu-id="b5698-229">First, add this markup to app.xaml in both QuizGameHost and QuizGameClient.</span></span>

```xml
<Style TargetType="Button">
    <Setter Property="Margin" Value="12"/>
</Style>
```

<span data-ttu-id="b5698-230">第 2 に、このに set アクセス操作子を追加および`OptionButtonStyle`で\\ビュー\\ClientView.xaml します。</span><span class="sxs-lookup"><span data-stu-id="b5698-230">And second, add this setter to `OptionButtonStyle` in \\View\\ClientView.xaml.</span></span>

```xml
<Setter Property="Margin" Value="6"/>
```

<span data-ttu-id="b5698-231">上に示した最後の調整を行うことで、アプリの動作と外観が移植前と同じになります。また、アプリはどのデバイスでも実行できるという機能が追加されます。</span><span class="sxs-lookup"><span data-stu-id="b5698-231">With that last tweak, the app will behave and look just the same as it did before the port, with the additional value that it will now run everywhere.</span></span>

## <a name="conclusion"></a><span data-ttu-id="b5698-232">まとめ</span><span class="sxs-lookup"><span data-stu-id="b5698-232">Conclusion</span></span>

<span data-ttu-id="b5698-233">このケース スタディで移植したアプリは、複数のプロジェクト、1 つのクラス ライブラリ、および多くのコードやユーザー インターフェイスを含んでいるため、比較的複雑なアプリになっています。</span><span class="sxs-lookup"><span data-stu-id="b5698-233">The app that we ported in this case study was a relatively complex one involving several projects, a class library, and quite a large amount of code and user interface.</span></span> <span data-ttu-id="b5698-234">それでも、移植は非常に簡単に行われました。</span><span class="sxs-lookup"><span data-stu-id="b5698-234">Even so, the port was straightforward.</span></span> <span data-ttu-id="b5698-235">移植の容易さの一部は、Windows 10 開発プラットフォームと Windows 8.1 および Windows Phone 8.1 プラットフォーム間の類似性に起因する直接します。</span><span class="sxs-lookup"><span data-stu-id="b5698-235">Some of the ease of porting is directly attributable to the similarity between the Windows 10 developer platform and the Windows 8.1 and Windows Phone 8.1 platforms.</span></span> <span data-ttu-id="b5698-236">また、元のアプリがモデル、ビュー モデル、およびビューを別個に維持するように設計されていたことも、その原因の 1 つです。</span><span class="sxs-lookup"><span data-stu-id="b5698-236">Some is due to the way the original app was designed to keep the models, the view models, and the views separate.</span></span>
