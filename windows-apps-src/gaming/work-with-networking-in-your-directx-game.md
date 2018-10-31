---
author: mtoepke
title: ゲームのネットワーク
description: ネットワーク機能を開発し、DirectX ゲームに組み込む方法について説明します。
ms.assetid: 212eee15-045c-8ba1-e274-4532b2120c55
ms.author: mtoepke
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, ネットワーク, DirectX
ms.localizationpriority: medium
ms.openlocfilehash: cc30a66db3fb01edebf4705ecb2e85ea4dbb94d6
ms.sourcegitcommit: ca96031debe1e76d4501621a7680079244ef1c60
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/31/2018
ms.locfileid: "5835566"
---
# <a name="networking-for-games"></a><span data-ttu-id="41346-104">ゲームのネットワーク</span><span class="sxs-lookup"><span data-stu-id="41346-104">Networking for games</span></span>



<span data-ttu-id="41346-105">ネットワーク機能を開発し、DirectX ゲームに組み込む方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="41346-105">Learn how to develop and incorporate networking features into your DirectX game.</span></span>

## <a name="concepts-at-a-glance"></a><span data-ttu-id="41346-106">概要</span><span class="sxs-lookup"><span data-stu-id="41346-106">Concepts at a glance</span></span>


<span data-ttu-id="41346-107">単純なスタンドアロン ゲームか多人数のマルチプレイヤー ゲームかにかかわらず、DirectX ゲームには、さまざまなネットワーク機能を使うことができます。</span><span class="sxs-lookup"><span data-stu-id="41346-107">A variety of networking features can be used in your DirectX game, whether it is a simple standalone game to massively multi-player games.</span></span> <span data-ttu-id="41346-108">ネットワークの最も単純な用途は、一元的なネットワーク サーバーにユーザー名とゲーム スコアを保存することです。</span><span class="sxs-lookup"><span data-stu-id="41346-108">The simplest use of networking would be to store user names and game scores on a central network server.</span></span>

<span data-ttu-id="41346-109">Networking API は、インフラストラクチャ (クライアント サーバーまたはインターネット ピア ツー ピア) モデルを使うマルチプレイヤー ゲームや、アドホック (ローカル ピア ツー ピア) ゲームに必要です。</span><span class="sxs-lookup"><span data-stu-id="41346-109">Networking APIs are needed in multi-player games that use the infrastructure (client-server or internet peer-to-peer) model and also by ad hoc (local peer-to-peer) games.</span></span> <span data-ttu-id="41346-110">サーバー ベースのマルチプレイヤー ゲームでは、ゲーム操作のほとんどを通常はセントラル ゲーム サーバーで処理し、入力、グラフィックス表示、オーディオ再生などの機能にクライアント ゲーム アプリを使います。</span><span class="sxs-lookup"><span data-stu-id="41346-110">For server-based multi-player games, a central game server usually handles most of the game operations and the client game app is used for input, displaying graphics, playing audio, and other features.</span></span> <span data-ttu-id="41346-111">ネットワーク転送の速度と待機時間は、満足度の高いゲーム エクスペリエンスを実現するための課題です。</span><span class="sxs-lookup"><span data-stu-id="41346-111">The speed and latency of network transfers is a concern for a satisfactory game experience.</span></span>

<span data-ttu-id="41346-112">ピア ツー ピア ゲームでは、各プレイヤーのアプリで、入力とグラフィックスを処理します。</span><span class="sxs-lookup"><span data-stu-id="41346-112">For peer-to-peer games, each player's app handles the input and graphics.</span></span> <span data-ttu-id="41346-113">ほとんどの場合、各ゲーム プレイヤーはきわめて近い場所にいるため、ネットワーク待機時間は長くありませんが、重要度に変わりはありません。</span><span class="sxs-lookup"><span data-stu-id="41346-113">In most cases, the game players are located in close proximity so that network latency should be lower but is still a concern.</span></span> <span data-ttu-id="41346-114">ピアの検出と接続の確立も、重要事項です。</span><span class="sxs-lookup"><span data-stu-id="41346-114">How to discovery peers and establish a connection becomes a concern.</span></span>

<span data-ttu-id="41346-115">単一プレイヤーのゲームでは、ユーザー名、ゲームのスコア、その他のさまざまな情報を保存するために、セントラル Web サーバーまたはサービスがよく使われます。</span><span class="sxs-lookup"><span data-stu-id="41346-115">For single-player games, a central Web server or service is often used to store user names, game scores, and other miscellaneous information.</span></span> <span data-ttu-id="41346-116">これらのゲームでは、直接ゲーム操作に影響しないため、ネットワーク転送の速度と待機時間はそれほど大きな問題ではありません。</span><span class="sxs-lookup"><span data-stu-id="41346-116">In these games, the speed and latency of networking transfers is less of a concern since it doesn't directly affect game operation.</span></span>

<span data-ttu-id="41346-117">ネットワークの状態はいつでも変化する可能性があり、Networking API を使うゲームでは、発生する可能性のあるネットワーク例外を処理できるようにしておく必要があります。</span><span class="sxs-lookup"><span data-stu-id="41346-117">Network conditions can change at any time, so any game that uses networking APIs needs to handle network exceptions that may occur.</span></span> <span data-ttu-id="41346-118">ネットワーク例外の処理について詳しくは、「[ネットワークの基本](https://msdn.microsoft.com/library/windows/apps/mt280233)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="41346-118">To learn more about handling network exceptions, see [Networking basics](https://msdn.microsoft.com/library/windows/apps/mt280233).</span></span>

<span data-ttu-id="41346-119">ファイアウォールと Web プロキシは一般的で、ネットワーク機能の使用に影響する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="41346-119">Firewalls and web proxies are common and can affect the ability to use networking features.</span></span> <span data-ttu-id="41346-120">ネットワークを使うゲームでは、ファイアウォールとプロキシを適切に処理できるようにしておく必要があります。</span><span class="sxs-lookup"><span data-stu-id="41346-120">A game that uses networking needs to be prepared to properly handle firewalls and proxies.</span></span>

<span data-ttu-id="41346-121">モバイル デバイスでは、ローミングまたはデータのコストが大きい従量制課金接続を使う場合、利用できるネットワーク リソースを監視し、それに従って動作することが重要です。</span><span class="sxs-lookup"><span data-stu-id="41346-121">For mobile devices, it is important to monitor available network resources and behave accordingly when on metered networks where roaming or data costs can be significant.</span></span>

<span data-ttu-id="41346-122">ネットワーク分離は、Windows で採用されているアプリ セキュリティ モデルの一部です。</span><span class="sxs-lookup"><span data-stu-id="41346-122">Network isolation is part of the app security model used by Windows.</span></span> <span data-ttu-id="41346-123">Windows がネットワークの境界を能動的に検出し、ネットワーク アクセスの制限を強制的に適用することによって、ネットワーク分離が実現されています。</span><span class="sxs-lookup"><span data-stu-id="41346-123">Windows actively discovers network boundaries and enforces network access restrictions for network isolation.</span></span> <span data-ttu-id="41346-124">アプリがネットワーク アクセスのスコープを定義するには、ネットワーク分離機能を宣言する必要があります。</span><span class="sxs-lookup"><span data-stu-id="41346-124">Apps must declare network isolation capabilities in order to define the scope of network access.</span></span> <span data-ttu-id="41346-125">この機能を宣言しないと、アプリはネットワーク リソースにアクセスできません。</span><span class="sxs-lookup"><span data-stu-id="41346-125">Without declaring these capabilities, your app will not have access to network resources.</span></span> <span data-ttu-id="41346-126">Windows でアプリにネットワーク分離が適用されるしくみについて詳しくは、「[ネットワーク分離機能を構成する方法](https://msdn.microsoft.com/library/windows/apps/hh770532)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="41346-126">To learn more about how Windows enforces network isolation for apps, see [How to configure network isolation capabilities](https://msdn.microsoft.com/library/windows/apps/hh770532).</span></span>

## <a name="design-considerations"></a><span data-ttu-id="41346-127">設計時の考慮事項</span><span class="sxs-lookup"><span data-stu-id="41346-127">Design considerations</span></span>


<span data-ttu-id="41346-128">DirectX ゲームに使うことのできる Networking API は、多数あります。</span><span class="sxs-lookup"><span data-stu-id="41346-128">A variety of networking APIs can be used in DirectX games.</span></span> <span data-ttu-id="41346-129">このため、適切な API を選ぶことが重要です。</span><span class="sxs-lookup"><span data-stu-id="41346-129">So, it is important to pick the right API.</span></span> <span data-ttu-id="41346-130">Windows では、アプリがインターネットまたはプライベート ネットワーク上で他のコンピューターやデバイスと通信するために使うことができるさまざまな Networking API がサポートされています。</span><span class="sxs-lookup"><span data-stu-id="41346-130">Windows supports a variety of networking APIs that your app can use to communicate with other computers and devices over either the Internet or private networks.</span></span> <span data-ttu-id="41346-131">最初のステップは、アプリに必要なネットワーク機能を理解することです。</span><span class="sxs-lookup"><span data-stu-id="41346-131">Your first step is to figure out what networking features your app needs.</span></span>

<span data-ttu-id="41346-132">ゲームに使うことができる主要なネットワーク API には、次のようなものがあります。</span><span class="sxs-lookup"><span data-stu-id="41346-132">The more popular network APIs for games include:</span></span>

-   <span data-ttu-id="41346-133">TCP とソケット - 信頼性の高い接続を実現します。</span><span class="sxs-lookup"><span data-stu-id="41346-133">TCP and sockets - Provides a reliable connection.</span></span> <span data-ttu-id="41346-134">TCP は、セキュリティを必要としないゲーム操作に使います。</span><span class="sxs-lookup"><span data-stu-id="41346-134">Use TCP for game operations that don’t need security.</span></span> <span data-ttu-id="41346-135">TCP を使うとサーバーの規模変更が容易であるため、インフラストラクチャ (クライアント サーバーまたはインターネット ピア ツー ピア) モデルのゲームでよく使われます。</span><span class="sxs-lookup"><span data-stu-id="41346-135">TCP allows the server to easily scale, so it is commonly used in games that use the infrastructure (client-server or internet peer-to-peer) model.</span></span> <span data-ttu-id="41346-136">TCP は、Wi-Fi Direct と Bluetooth を経由したアドホック (ローカル ピア ツー ピア) ゲームでも使うことができます。</span><span class="sxs-lookup"><span data-stu-id="41346-136">TCP can also be used by ad hoc (local peer-to-peer) games over Wi-Fi Direct and Bluetooth.</span></span> <span data-ttu-id="41346-137">TCP は一般的に、ゲーム オブジェクトの動き、文字操作、テキスト チャットなどの操作に使います。</span><span class="sxs-lookup"><span data-stu-id="41346-137">TCP is commonly used for game object movement, character interaction, text chat, and other operations.</span></span> <span data-ttu-id="41346-138">[**StreamSocket**](https://msdn.microsoft.com/library/windows/apps/br226882)クラスは、Microsoft Store ゲームで使用できる TCP ソケットを提供します。</span><span class="sxs-lookup"><span data-stu-id="41346-138">The [**StreamSocket**](https://msdn.microsoft.com/library/windows/apps/br226882) class provides a TCP socket that can be used in Microsoft Store games.</span></span> <span data-ttu-id="41346-139">**StreamSocket** クラスは、[**Windows::Networking::Sockets**](https://msdn.microsoft.com/library/windows/apps/br226960) 名前空間の関連クラスと共に使われます。</span><span class="sxs-lookup"><span data-stu-id="41346-139">The **StreamSocket** class is used with related classes in the [**Windows::Networking::Sockets**](https://msdn.microsoft.com/library/windows/apps/br226960) namespace.</span></span>
-   <span data-ttu-id="41346-140">SSL を使う TCP とソケット - 信頼性の高い接続を提供して改ざんを防ぎます。</span><span class="sxs-lookup"><span data-stu-id="41346-140">TCP and sockets using SSL - Provides a reliable connection that prevents eavesdropping.</span></span> <span data-ttu-id="41346-141">SSL を伴う TCP 接続は、セキュリティを必要とするゲーム操作で使います。</span><span class="sxs-lookup"><span data-stu-id="41346-141">Use TCP connections with SSL for game operations that need security.</span></span> <span data-ttu-id="41346-142">SSL の暗号化とオーバーヘッドにより、待機時間とパフォーマンスのコストが増加するため、セキュリティが必要な場合にのみ使うようにします。</span><span class="sxs-lookup"><span data-stu-id="41346-142">The encryption and overhead of SSL adds a cost in latency and performance, so it is only used when security is needed.</span></span> <span data-ttu-id="41346-143">一般的に、SSL を伴う TCP は、ログイン、アセットの購入とトレーディング、ゲーム キャラクターの作成と管理に使います。</span><span class="sxs-lookup"><span data-stu-id="41346-143">TCP with SSL is commonly used for login, purchasing and trading assets, game character creation and management.</span></span> <span data-ttu-id="41346-144">SSL をサポートする TCP ソケットは、[**StreamSocket**](https://msdn.microsoft.com/library/windows/apps/br226882) クラスで提供されます。</span><span class="sxs-lookup"><span data-stu-id="41346-144">The [**StreamSocket**](https://msdn.microsoft.com/library/windows/apps/br226882) class provides a TCP socket that supports SSL.</span></span>
-   <span data-ttu-id="41346-145">UDP とソケット - 信頼性の低いネットワーク転送を低いオーバーヘッドで提供します。</span><span class="sxs-lookup"><span data-stu-id="41346-145">UDP and sockets - Provides unreliable network transfers with low overhead.</span></span> <span data-ttu-id="41346-146">UDP は、待機時間を短くする必要があり、ある程度のパケット損失を許容できるゲーム操作に使われます。</span><span class="sxs-lookup"><span data-stu-id="41346-146">UDP is used for game operations that require low latency and can tolerate some packet loss.</span></span> <span data-ttu-id="41346-147">これは、ファイティング ゲーム、シューティング、トレーサー、ネットワーク オーディオ、ボイス チャットなどによく使われます。</span><span class="sxs-lookup"><span data-stu-id="41346-147">This is often used for fighting games, shooting and tracers, network audio, and voice chat.</span></span> <span data-ttu-id="41346-148">[**DatagramSocket**](https://msdn.microsoft.com/library/windows/apps/br241319)クラスは、Microsoft Store ゲームで使用できる UDP ソケットを提供します。</span><span class="sxs-lookup"><span data-stu-id="41346-148">The [**DatagramSocket**](https://msdn.microsoft.com/library/windows/apps/br241319) class provides a UDP socket that can be used in Microsoft Store games.</span></span> <span data-ttu-id="41346-149">**DatagramSocket** クラスは、[**Windows::Networking::Sockets**](https://msdn.microsoft.com/library/windows/apps/br226960) 名前空間の関連クラスと共に使われます。</span><span class="sxs-lookup"><span data-stu-id="41346-149">The **DatagramSocket** class is used with related classes in the [**Windows::Networking::Sockets**](https://msdn.microsoft.com/library/windows/apps/br226960) namespace.</span></span>
-   <span data-ttu-id="41346-150">HTTP クライアント - HTTP サーバーへの、信頼性の高い接続を実現します。</span><span class="sxs-lookup"><span data-stu-id="41346-150">HTTP Client - Provides a reliable connection to HTTP servers.</span></span> <span data-ttu-id="41346-151">最も一般的なネットワーク シナリオは、Web サイトにアクセスして情報を取得または保存することです。</span><span class="sxs-lookup"><span data-stu-id="41346-151">The most common networking scenario is to access a web site to retrieve or store information.</span></span> <span data-ttu-id="41346-152">単純な例としては、Web サイトを使ってユーザー情報とゲームのスコアを保存するゲームが考えられます。</span><span class="sxs-lookup"><span data-stu-id="41346-152">A simple example would be a game that uses a website to store user information and game scores.</span></span> <span data-ttu-id="41346-153">HTTP クライアントは、SSL と組み合わせてセキュリティを強化すると、ログイン、購入、アセットのトレーディング、ゲーム キャラクターの作成、管理に使うことができます。</span><span class="sxs-lookup"><span data-stu-id="41346-153">When used with SSL for security, an HTTP client can be used for login, purchasing, trading assets, game character creation, and management.</span></span> <span data-ttu-id="41346-154">[**HttpClient**](https://msdn.microsoft.com/library/windows/apps/dn298639)クラスは、最新の HTTP クライアント API の使用では、Microsoft Store ゲームを提供します。</span><span class="sxs-lookup"><span data-stu-id="41346-154">The [**HttpClient**](https://msdn.microsoft.com/library/windows/apps/dn298639) class provides a modern HTTP client API for use in Microsoft Store games.</span></span> <span data-ttu-id="41346-155">**HttpClient** クラスは、[**Windows::Web::Http**](https://msdn.microsoft.com/library/windows/apps/dn279692) 名前空間の関連クラスと共に使われます。</span><span class="sxs-lookup"><span data-stu-id="41346-155">The **HttpClient** class is used with related classes in the [**Windows::Web::Http**](https://msdn.microsoft.com/library/windows/apps/dn279692) namespace.</span></span>

## <a name="handling-network-exceptions-in-your-directx-game"></a><span data-ttu-id="41346-156">DirectX ゲームでのネットワーク例外の処理</span><span class="sxs-lookup"><span data-stu-id="41346-156">Handling network exceptions in your DirectX game</span></span>


<span data-ttu-id="41346-157">DirectX ゲームでのネットワーク例外の発生は、重大な問題やエラーを示します。</span><span class="sxs-lookup"><span data-stu-id="41346-157">When a network exception occurs in your DirectX game, this indicates a significant problem or failure.</span></span> <span data-ttu-id="41346-158">Networking API を使う場合、例外はさまざまな理由で発生します。</span><span class="sxs-lookup"><span data-stu-id="41346-158">Exceptions can occur for many reasons when using networking APIs.</span></span> <span data-ttu-id="41346-159">リモート ホストやサーバー側でネットワーク接続を変更したなど、ネットワークの問題のために例外が発生することもよくあります。</span><span class="sxs-lookup"><span data-stu-id="41346-159">Often, the exception can result from changes in network connectivity or other networking issues with the remote host or server.</span></span>

<span data-ttu-id="41346-160">Networking API を使う場合の例外の理由には、次のようなものがあります。</span><span class="sxs-lookup"><span data-stu-id="41346-160">Some causes of exceptions when using networking APIs include the following:</span></span>

-   <span data-ttu-id="41346-161">ホスト名や URI のユーザー入力にエラーがあり有効ではない</span><span class="sxs-lookup"><span data-stu-id="41346-161">Input from the user for a hostname or a URI contains errors and is not valid.</span></span>
-   <span data-ttu-id="41346-162">ホスト名または URI の参照時の名前解決の失敗</span><span class="sxs-lookup"><span data-stu-id="41346-162">Name resolutions failures when looking up a hostname or a URi.</span></span>
-   <span data-ttu-id="41346-163">ネットワーク接続の切断または変更</span><span class="sxs-lookup"><span data-stu-id="41346-163">Loss or change in network connectivity.</span></span>
-   <span data-ttu-id="41346-164">ソケットと HTTP クライアント API を使っているネットワーク接続の失敗</span><span class="sxs-lookup"><span data-stu-id="41346-164">Network connection failures using sockets or the HTTP client APIs.</span></span>
-   <span data-ttu-id="41346-165">ネットワーク サーバーまたはリモート エンドポイントのエラー</span><span class="sxs-lookup"><span data-stu-id="41346-165">Network server or remote endpoint errors.</span></span>
-   <span data-ttu-id="41346-166">その他のネットワーク エラー</span><span class="sxs-lookup"><span data-stu-id="41346-166">Miscellaneous networking errors.</span></span>

<span data-ttu-id="41346-167">ネットワークのエラーによる例外 (たとえば、接続の切断または変更、接続エラー、サーバー エラー) は、いつでも発生する場合があります。</span><span class="sxs-lookup"><span data-stu-id="41346-167">Exceptions from network errors (for example, loss or change of connectivity, connection failures, and server failures) can happen at any time.</span></span> <span data-ttu-id="41346-168">これらのエラーが起きると、例外がスローされます。</span><span class="sxs-lookup"><span data-stu-id="41346-168">These errors result in exceptions being thrown.</span></span> <span data-ttu-id="41346-169">例外がアプリによって処理されない場合、ランタイムによってアプリ全体が終了されることがあります。</span><span class="sxs-lookup"><span data-stu-id="41346-169">If an exception is not handled by your app, it can cause your entire app to be terminated by the runtime.</span></span>

<span data-ttu-id="41346-170">非同期ネットワーク メソッドの多くは、呼び出す場合、例外を処理するようにコードを記述する必要があります。</span><span class="sxs-lookup"><span data-stu-id="41346-170">You must write code to handle exceptions when you call most asynchronous network methods.</span></span> <span data-ttu-id="41346-171">例外の発生時に、場合によっては、問題を解決するためにネットワーク メソッドが再試行されることがあります。</span><span class="sxs-lookup"><span data-stu-id="41346-171">Sometimes, when an exception occurs, a network method can be retried as a way to resolve the problem.</span></span> <span data-ttu-id="41346-172">また、ネットワーク接続なしで、以前にキャッシュされたデータを使ってアプリを継続するように計画しなければならない場合もあります。</span><span class="sxs-lookup"><span data-stu-id="41346-172">Other times, your app may need to plan to continue without network connectivity using previously cached data.</span></span>

<span data-ttu-id="41346-173">ユニバーサル Windows プラットフォーム (UWP) アプリは、一般に、1 つの例外をスローします。</span><span class="sxs-lookup"><span data-stu-id="41346-173">Universal Windows Platform (UWP) apps generally throw a single exception.</span></span> <span data-ttu-id="41346-174">エラーについてよく理解し、適切な判断ができるように、例外ハンドラーは例外の原因についての詳しい情報を取得できます。</span><span class="sxs-lookup"><span data-stu-id="41346-174">Your exception handler can retrieve more detailed information about the cause of the exception to better understand the failure and make appropriate decisions.</span></span>

<span data-ttu-id="41346-175">例外が UWP アプリである DirectX ゲームで発生すると、エラーの原因の **HRESULT** 値を取得できます。</span><span class="sxs-lookup"><span data-stu-id="41346-175">When an exception occurs in a DirectX game that is a UWP app, the **HRESULT** value for the cause of the error can be retrieved.</span></span> <span data-ttu-id="41346-176">*Winerror.h* インクルード ファイルには、ネットワーク エラーを含む、出力される可能性がある **HRESULT** 値の大きなリストが格納されています。</span><span class="sxs-lookup"><span data-stu-id="41346-176">The *Winerror.h* include file contains a large list of possible **HRESULT** values that includes network errors.</span></span>

<span data-ttu-id="41346-177">Networking API は、例外の原因についての詳しい情報を取得するために、さまざまなメソッドをサポートしています。</span><span class="sxs-lookup"><span data-stu-id="41346-177">The networking APIs support different methods for retrieving this detailed information about the cause of an exception.</span></span>

-   <span data-ttu-id="41346-178">例外の原因となったエラーの **HRESULT** 値を取得するメソッド。</span><span class="sxs-lookup"><span data-stu-id="41346-178">A method to retrieve the **HRESULT** value of the error that caused the exception.</span></span> <span data-ttu-id="41346-179">可能な **HRESULT** 値の一覧はサイズが大きく指定されていません。</span><span class="sxs-lookup"><span data-stu-id="41346-179">The possible list of potential **HRESULT** values is large and unspecified.</span></span> <span data-ttu-id="41346-180">Networking API の 1 つを使っている場合は **HRESULT** の値を取得できます。</span><span class="sxs-lookup"><span data-stu-id="41346-180">The **HRESULT** value can be retrieved when using any of the networking APIs.</span></span>
-   <span data-ttu-id="41346-181">**HRESULT** 値を列挙値に変換するヘルパー メソッド。</span><span class="sxs-lookup"><span data-stu-id="41346-181">A helper method that converts the **HRESULT** value to an enumeration value.</span></span> <span data-ttu-id="41346-182">可能な列挙値の一覧は指定されていて、比較的小さいサイズです。</span><span class="sxs-lookup"><span data-stu-id="41346-182">The list of possible enumeration values is specified and relatively small.</span></span> <span data-ttu-id="41346-183">[**Windows::Networking::Sockets**](https://msdn.microsoft.com/library/windows/apps/br226960) 内のソケット クラスにヘルパー メソッドを使うことができます。</span><span class="sxs-lookup"><span data-stu-id="41346-183">A helper method is available for the socket classes in the [**Windows::Networking::Sockets**](https://msdn.microsoft.com/library/windows/apps/br226960).</span></span>

### <a name="exceptions-in-windowsnetworkingsockets"></a><span data-ttu-id="41346-184">Windows.Networking.Sockets の例外</span><span class="sxs-lookup"><span data-stu-id="41346-184">Exceptions in Windows.Networking.Sockets</span></span>

<span data-ttu-id="41346-185">ソケットと共に使われる [**HostName**](https://msdn.microsoft.com/library/windows/apps/br207113) クラスのコンストラクターは、有効なホスト名ではない (ホスト名に使うことができない文字が含まれている) 文字列が渡された場合に例外をスローすることができます。</span><span class="sxs-lookup"><span data-stu-id="41346-185">The constructor for the [**HostName**](https://msdn.microsoft.com/library/windows/apps/br207113) class used with sockets can throw an exception if the string passed is not a valid hostname (contains characters that are not allowed in a host name).</span></span> <span data-ttu-id="41346-186">アプリがゲームのピア接続用にユーザーから **HostName** の入力を取得する場合、このコンストラクターを try/catch ブロックに配置する必要があります。</span><span class="sxs-lookup"><span data-stu-id="41346-186">If an app gets input from the user for the **HostName** for a peer connection for gaming, the constructor should be in a try/catch block.</span></span> <span data-ttu-id="41346-187">例外がスローされた場合、アプリは、ユーザーに通知し、新しいホスト名を要求することができます。</span><span class="sxs-lookup"><span data-stu-id="41346-187">If an exception is thrown, the app can notify the user and request a new hostname.</span></span>

<span data-ttu-id="41346-188">ユーザーが指定したホスト名の文字列を検証するコードの追加</span><span class="sxs-lookup"><span data-stu-id="41346-188">Add code to validate a string for a hostname from the user</span></span>

```cpp

    // Define some variables at the class level.
    Windows::Networking::HostName^ remoteHost;

    bool isHostnameFromUser = false;
    bool isHostnameValid = false;

    ///...

    // If the value of 'remoteHostname' is set by the user in a control as input 
    // and is therefore untrusted input and could contain errors. 
    // If we can't create a valid hostname, we notify the user in statusText 
    // about the incorrect input.

    String ^hostString = remoteHostname;

    try 
    {
        remoteHost = ref new Windows::Networking:Host(hostString);
        isHostnameValid = true;
    }
    catch (InvalidArgumentException ^ex)
    {
        statusText->Text = "You entered a bad hostname, please re-enter a valid hostname.";
        return;
    }

    isHostnameFromUser = true;


    // ... Continue with code to execute with a valid hostname.
```

<span data-ttu-id="41346-189">[**Windows.Networking.Sockets**](https://msdn.microsoft.com/library/windows/apps/br226960) 名前空間には、ソケットを使う場合のエラー処理に便利なヘルパー メソッドと列挙があります。</span><span class="sxs-lookup"><span data-stu-id="41346-189">The [**Windows.Networking.Sockets**](https://msdn.microsoft.com/library/windows/apps/br226960) namespace has convenient helper methods and enumerations for handling errors when using sockets.</span></span> <span data-ttu-id="41346-190">これは、アプリで特定のネットワーク例外を異なる方法で処理する場合に役立つことがあります。</span><span class="sxs-lookup"><span data-stu-id="41346-190">This can be useful for handling specific network exceptions differently in your app.</span></span>

<span data-ttu-id="41346-191">スローされた例外の [**DatagramSocket**](https://msdn.microsoft.com/library/windows/apps/br241319)、[**StreamSocket**](https://msdn.microsoft.com/library/windows/apps/br226882)、[**StreamSocketListener**](https://msdn.microsoft.com/library/windows/apps/br226906) の操作結果で発生したエラー。</span><span class="sxs-lookup"><span data-stu-id="41346-191">An error encountered on [**DatagramSocket**](https://msdn.microsoft.com/library/windows/apps/br241319), [**StreamSocket**](https://msdn.microsoft.com/library/windows/apps/br226882), or [**StreamSocketListener**](https://msdn.microsoft.com/library/windows/apps/br226906) operation results in an exception being thrown.</span></span> <span data-ttu-id="41346-192">例外の原因は、**HRESULT** として表現されるエラー値です。</span><span class="sxs-lookup"><span data-stu-id="41346-192">The cause of the exception is an error value represented as an **HRESULT** value.</span></span> <span data-ttu-id="41346-193">[**SocketError.GetStatus**](https://msdn.microsoft.com/library/windows/apps/hh701462) メソッドは、ネットワーク エラーをソケット操作から [**SocketErrorStatus**](https://msdn.microsoft.com/library/windows/apps/hh701457) 列挙値に変換するために使われます。</span><span class="sxs-lookup"><span data-stu-id="41346-193">The [**SocketError.GetStatus**](https://msdn.microsoft.com/library/windows/apps/hh701462) method is used to convert a network error from a socket operation to a [**SocketErrorStatus**](https://msdn.microsoft.com/library/windows/apps/hh701457) enumeration value.</span></span> <span data-ttu-id="41346-194">ほとんどの **SocketErrorStatus** 列挙値は、ネイティブ Windows ソケット操作から返されるエラーに対応しています。</span><span class="sxs-lookup"><span data-stu-id="41346-194">Most of the **SocketErrorStatus** enumeration values correspond to an error returned by the native Windows sockets operation.</span></span> <span data-ttu-id="41346-195">アプリは特定の **SocketErrorStatus** 列挙値に対するフィルター処理を行い、例外の原因に応じてアプリの動作を変更できます。</span><span class="sxs-lookup"><span data-stu-id="41346-195">An app can filter on specific **SocketErrorStatus** enumeration values to modify app behavior depending on the cause of the exception.</span></span>

<span data-ttu-id="41346-196">パラメーター検証エラーの場合、アプリは例外からの **HRESULT** を使って、その例外の原因となったエラーの詳細情報を確認することもできます。</span><span class="sxs-lookup"><span data-stu-id="41346-196">For parameter validation errors, an app can also use the **HRESULT** from the exception to learn more detailed information about the error that caused the exception.</span></span> <span data-ttu-id="41346-197">使うことができる **HRESULT** 値は、*Winerror.h* ヘッダー ファイルに記載されています。</span><span class="sxs-lookup"><span data-stu-id="41346-197">Possible **HRESULT** values are listed in the *Winerror.h* header file.</span></span> <span data-ttu-id="41346-198">ほとんどのパラメーター検証エラーの場合、返される **HRESULT** は **E\_INVALIDARG** です。</span><span class="sxs-lookup"><span data-stu-id="41346-198">For most parameter validation errors, the **HRESULT** returned is **E\_INVALIDARG**.</span></span>

<span data-ttu-id="41346-199">ストリーム ソケット接続の実行時に発生する例外を処理するコードの追加</span><span class="sxs-lookup"><span data-stu-id="41346-199">Add code to handle exceptions when trying to make a stream socket connection</span></span>

```cpp
using namespace Windows::Networking;
using namespace Windows::Networking::Sockets;

    
    // Define some more variables at the class level.

    bool isSocketConnected = false
    bool retrySocketConnect = false;

    // The number of times we have tried to connect the socket.
    unsigned int retryConnectCount = 0;

    // The maximum number of times to retry a connect operation.
    unsigned int maxRetryConnectCount = 5; 
    ///...

    // We pass in a valid remoteHost and serviceName parameter.
    // The hostname can contain a name or an IP address.
    // The servicename can contain a string or a TCP port number.

    StreamSocket ^ socket = ref new StreamSocket();
    SocketErrorStatus errorStatus; 
    HResult hr;

    // Save the socket, so any subsequent steps can use it.
    CoreApplication::Properties->Insert("clientSocket", socket);

    // Connect to the remote server. 
    create_task(socket->ConnectAsync(
            remoteHost,
            serviceName,
            SocketProtectionLevel::PlainSocket)).then([this] (task<void> previousTask)
    {
        try
        {
            // Try getting all exceptions from the continuation chain above this point.
            previousTask.get();

            isSocketConnected = true;
            // Mark the socket as connected. We do not really care about the value of the property, but the mere 
            // existence of  it means that we are connected.
            CoreApplication::Properties->Insert("connected", nullptr);
        }
        catch (Exception^ ex)
        {
            hr = ex.HResult;
            errorStatus = SocketStatus::GetStatus(hr); 
            if (errorStatus != Unknown)
            {
                                                                switch (errorStatus) 
                   {
                    case HostNotFound:
                        // If the hostname is from the user, this may indicate a bad input.
                        // Set a flag to ask the user to re-enter the hostname.
                        isHostnameValid = false;
                        return;
                        break;
                    case ConnectionRefused:
                        // The server might be temporarily busy.
                        retrySocketConnect = true;
                        return;
                        break; 
                    case NetworkIsUnreachable: 
                        // This could be a connectivity issue.
                        retrySocketConnect = true;
                        break;
                    case UnreachableHost: 
                        // This could be a connectivity issue.
                        retrySocketConnect = true;
                        break;
                    case NetworkIsDown: 
                        // This could be a connectivity issue.
                        retrySocketConnect = true;
                        break;
                    // Handle other errors. 
                    default: 
                        // The connection failed and no options are available.
                        // Try to use cached data if it is available. 
                        // You may want to tell the user that the connect failed.
                        break;
                }
                }
                else 
                {
                    // Received an Hresult that is not mapped to an enum.
                    // This could be a connectivity issue.
                    retrySocketConnect = true;
                }
            }
        });
    }

```

### <a name="exceptions-in-windowswebhttp"></a><span data-ttu-id="41346-200">Windows.Web.Http の例外</span><span class="sxs-lookup"><span data-stu-id="41346-200">Exceptions in Windows.Web.Http</span></span>

<span data-ttu-id="41346-201">[**Windows::Web::Http::HttpClient**](https://msdn.microsoft.com/library/windows/apps/dn298639) と共に使われる [**Windows::Foundation::Uri**](https://msdn.microsoft.com/library/windows/apps/br225998) クラスのコンストラクターは、有効な URI ではない (URI に使うことができない文字が含まれている) 文字列が渡された場合に例外をスローすることができます。</span><span class="sxs-lookup"><span data-stu-id="41346-201">The constructor for the [**Windows::Foundation::Uri**](https://msdn.microsoft.com/library/windows/apps/br225998) class used with [**Windows::Web::Http::HttpClient**](https://msdn.microsoft.com/library/windows/apps/dn298639) can throw an exception if the string passed is not a valid URI (contains characters that are not allowed in a URI).</span></span> <span data-ttu-id="41346-202">C++ では、URI として渡される文字列を試行して解析するメソッドはありません。</span><span class="sxs-lookup"><span data-stu-id="41346-202">In C++, there is no method to try and parse a string to a URI.</span></span> <span data-ttu-id="41346-203">アプリがユーザーから **Windows::Foundation::Uri** の入力を取得する場合、このコンストラクターを try/catch ブロックに配置する必要があります。</span><span class="sxs-lookup"><span data-stu-id="41346-203">If an app gets input from the user for the **Windows::Foundation::Uri**, the constructor should be in a try/catch block.</span></span> <span data-ttu-id="41346-204">例外がスローされた場合、アプリは、ユーザーに通知して、新しい URI を要求することができます。</span><span class="sxs-lookup"><span data-stu-id="41346-204">If an exception is thrown, the app can notify the user and request a new URI.</span></span>

<span data-ttu-id="41346-205">アプリでは、URI 内のスキーマが HTTP または HTTPS であることも確認する必要があります。[**Windows::Web::Http::HttpClient**](https://msdn.microsoft.com/library/windows/apps/dn298639) では、これらのスキーマしかサポートされていないためです。</span><span class="sxs-lookup"><span data-stu-id="41346-205">Your app should also check that the scheme in the URI is HTTP or HTTPS since these are the only schemes supported by the [**Windows::Web::Http::HttpClient**](https://msdn.microsoft.com/library/windows/apps/dn298639).</span></span>

<span data-ttu-id="41346-206">ユーザーが指定した URI の文字列を検証するコードの追加</span><span class="sxs-lookup"><span data-stu-id="41346-206">Add code to validate a string for a URI from the user</span></span>

```cpp

    // Define some variables at the class level.
    Windows::Foundation::Uri^ resourceUri;

    bool isUriFromUser = false;
    bool isUriValid = false;

    ///...

    // If the value of 'inputUri' is set by the user in a control as input 
    // and is therefore untrusted input and could contain errors. 
    // If we can't create a valid hostname, we notify the user in statusText 
    // about the incorrect input.

    String ^uriString = inputUri;

    try 
    {
        isUriValid = false;
        resourceUri = ref new Windows::Foundation:Uri(uriString);

        if (resourceUri->SchemeName != "http" && resourceUri->SchemeName != "https")
        {
            statusText->Text = "Only 'http' and 'https' schemes supported. Please re-enter URI";
            return;
        }
        isUriValid = true;
    }
    catch (InvalidArgumentException ^ex)
    {
        statusText->Text = "You entered a bad URI, please re-enter Uri to continue.";
        return;
    }

    isUriFromUser = true;


    // ... Continue with code to execute with a valid URI.
```

<span data-ttu-id="41346-207">[**Windows::Web::Http**](https://msdn.microsoft.com/library/windows/apps/windows.web.http.aspx) 名前空間には便利な関数がありません。</span><span class="sxs-lookup"><span data-stu-id="41346-207">The [**Windows::Web::Http**](https://msdn.microsoft.com/library/windows/apps/windows.web.http.aspx) namespace lacks a convenience function.</span></span> <span data-ttu-id="41346-208">そのため、この名前空間の [**HttpClient**](https://msdn.microsoft.com/library/windows/apps/dn298639) と他のクラスを使うアプリは、**HRESULT** 値を使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="41346-208">So, an app using [**HttpClient**](https://msdn.microsoft.com/library/windows/apps/dn298639) and other classes in this namespace needs to use the **HRESULT** value.</span></span>

<span data-ttu-id="41346-209">C++ を使うアプリでは、アプリの実行中に例外が発生したときに、[**Platform::Exception**](https://msdn.microsoft.com/library/windows/apps/hh755825.aspx) がエラーを表します。</span><span class="sxs-lookup"><span data-stu-id="41346-209">In apps using C++, the [**Platform::Exception**](https://msdn.microsoft.com/library/windows/apps/hh755825.aspx) represents an error during app execution when an exception occurs.</span></span> <span data-ttu-id="41346-210">[**Platform::Exception::HResult**](https://msdn.microsoft.com/library/windows/apps/hh763371.aspx) プロパティは、特定の例外に割り当てられた **HRESULT** を返します。</span><span class="sxs-lookup"><span data-stu-id="41346-210">The [**Platform::Exception::HResult**](https://msdn.microsoft.com/library/windows/apps/hh763371.aspx) property returns the **HRESULT** assigned to the specific exception.</span></span> <span data-ttu-id="41346-211">[**Platform::Exception::Message**](https://msdn.microsoft.com/library/windows/apps/hh763375.aspx) プロパティは、**HRESULT** 値に関連付けられた、システムが提供する文字列を返します。</span><span class="sxs-lookup"><span data-stu-id="41346-211">The [**Platform::Exception::Message**](https://msdn.microsoft.com/library/windows/apps/hh763375.aspx) property returns the system-provided string that is associated with the **HRESULT** value.</span></span> <span data-ttu-id="41346-212">使うことができる **HRESULT** 値は、*Winerror.h* ヘッダー ファイルに記載されています。</span><span class="sxs-lookup"><span data-stu-id="41346-212">Possible **HRESULT** values are listed in the *Winerror.h* header file.</span></span> <span data-ttu-id="41346-213">アプリは特定の **HRESULT** 値に対するフィルター処理を行い、例外の原因に応じてアプリの動作を変更できます。</span><span class="sxs-lookup"><span data-stu-id="41346-213">An app can filter on specific **HRESULT** values to modify app behavior depending on the cause of the exception.</span></span>

<span data-ttu-id="41346-214">ほとんどのパラメーター検証エラーの場合、返される **HRESULT** は **E\_INVALIDARG** です。</span><span class="sxs-lookup"><span data-stu-id="41346-214">For most parameter validation errors, the **HRESULT** returned is **E\_INVALIDARG**.</span></span> <span data-ttu-id="41346-215">一部の無効なメソッド呼び出しでは、返される **HRESULT** は **E\_ILLEGAL\_METHOD\_CALL** です。</span><span class="sxs-lookup"><span data-stu-id="41346-215">For some illegal method calls, the **HRESULT** returned is **E\_ILLEGAL\_METHOD\_CALL**.</span></span>

<span data-ttu-id="41346-216">[**HttpClient**](https://msdn.microsoft.com/library/windows/apps/dn298639) を使って HTTP サーバーに接続するときに発生する例外を処理するコードの追加</span><span class="sxs-lookup"><span data-stu-id="41346-216">Add code to handle exceptions when trying to use [**HttpClient**](https://msdn.microsoft.com/library/windows/apps/dn298639) to connect to an HTTP server</span></span>

```cpp
using namespace Windows::Foundation;
using namespace Windows::Web::Http;
    
    // Define some more variables at the class level.

    bool isHttpClientConnected = false
    bool retryHttpClient = false;

    // The number of times we have tried to connect the socket
    unsigned int retryConnectCount = 0;

    // The maximum number of times to retry a connect operation.
    unsigned int maxRetryConnectCount = 5; 
    ///...

    // We pass in a valid resourceUri parameter.
    // The URI must contain a scheme and a name or an IP address.

    HttpClient ^ httpClient = ref new HttpClient();
    HResult hr;

    // Save the httpClient, so any subsequent steps can use it.
    CoreApplication::Properties->Insert("httpClient", httpClient);

    // Send a GET request to the HTTP server. 
    create_task(httpClient->GetAsync(resourceUri)).then([this] (task<void> previousTask)
    {
        try
        {
            // Try getting all exceptions from the continuation chain above this point.
            previousTask.get();

            isHttpClientConnected = true;
            // Mark the HttClient as connected. We do not really care about the value of the property, but the mere 
            // existence of  it means that we are connected.
            CoreApplication::Properties->Insert("connected", nullptr);
        }
        catch (Exception^ ex)
        {
            hr = ex.HResult;
                                                switch (errorStatus) 
               {
                case WININET_E_NAME_NOT_RESOLVED:
                    // If the Uri is from the user, this may indicate a bad input.
                    // Set a flag to ask user to re-enter the Uri.
                    isUriValid = false;
                    return;
                    break;
                case WININET_E_CANNOT_CONNECT:
                    // The server might be temporarily busy.
                    retryHttpClientConnect = true;
                    return;
                    break; 
                case WININET_E_CONNECTION_ABORTED: 
                    // This could be a connectivity issue.
                    retryHttpClientConnect = true;
                    break;
                case WININET_E_CONNECTION_RESET: 
                    // This could be a connectivity issue.
                    retryHttpClientConnect = true;
                    break;
                case INET_E_RESOURCE_NOT_FOUND: 
                    // The server cannot locate the resource specified in the uri.
                    // If the Uri is from user, this may indicate a bad input.
                    // Set a flag to ask the user to re-enter the Uri
                    isUriValid = false;
                    return;
                    break;
                // Handle other errors. 
                default: 
                    // The connection failed and no options are available.
                    // Try to use cached data if it is available. 
                    // You may want to tell the user that the connect failed.
                    break;
            }
            else 
            {
                // Received an Hresult that is not mapped to an enum.
                // This could be a connectivity issue.
                retrySocketConnect = true;
            }
        }
    });
    

```

## <a name="related-topics"></a><span data-ttu-id="41346-217">関連トピック</span><span class="sxs-lookup"><span data-stu-id="41346-217">Related topics</span></span>


**<span data-ttu-id="41346-218">その他のリソース</span><span class="sxs-lookup"><span data-stu-id="41346-218">Other resources</span></span>**

* [<span data-ttu-id="41346-219">データグラム ソケットを使った接続</span><span class="sxs-lookup"><span data-stu-id="41346-219">Connecting with a datagram socket</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/jj635238)
* [<span data-ttu-id="41346-220">ストリーム ソケットによるネットワーク リソースへの接続</span><span class="sxs-lookup"><span data-stu-id="41346-220">Connecting to a network resource with a stream socket</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/jj150599)
* [<span data-ttu-id="41346-221">ネットワーク サービスへの接続</span><span class="sxs-lookup"><span data-stu-id="41346-221">Connecting to network services</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/hh452976)
* [<span data-ttu-id="41346-222">Web サービスへの接続</span><span class="sxs-lookup"><span data-stu-id="41346-222">Connecting to web services</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/hh761504)
* [<span data-ttu-id="41346-223">ネットワークの基本</span><span class="sxs-lookup"><span data-stu-id="41346-223">Networking basics</span></span>](https://msdn.microsoft.com/library/windows/apps/mt280233)
* [<span data-ttu-id="41346-224">ネットワーク分離機能を構成する方法</span><span class="sxs-lookup"><span data-stu-id="41346-224">How to configure network isolation capabilities</span></span>](https://msdn.microsoft.com/library/windows/apps/hh770532)
* [<span data-ttu-id="41346-225">ループバックを有効にする方法とネットワーク分離のトラブルシューティングを行う方法</span><span class="sxs-lookup"><span data-stu-id="41346-225">How to enable loopback and debug network isolation</span></span>](https://msdn.microsoft.com/library/windows/apps/hh780593)

**<span data-ttu-id="41346-226">リファレンス</span><span class="sxs-lookup"><span data-stu-id="41346-226">Reference</span></span>**

* [**<span data-ttu-id="41346-227">DatagramSocket</span><span class="sxs-lookup"><span data-stu-id="41346-227">DatagramSocket</span></span>**](https://msdn.microsoft.com/library/windows/apps/br241319)
* [**<span data-ttu-id="41346-228">HttpClient</span><span class="sxs-lookup"><span data-stu-id="41346-228">HttpClient</span></span>**](https://msdn.microsoft.com/library/windows/apps/dn298639)
* [**<span data-ttu-id="41346-229">StreamSocket</span><span class="sxs-lookup"><span data-stu-id="41346-229">StreamSocket</span></span>**](https://msdn.microsoft.com/library/windows/apps/br226882)
* [**<span data-ttu-id="41346-230">Windows::Web::Http</span><span class="sxs-lookup"><span data-stu-id="41346-230">Windows::Web::Http</span></span>**](https://msdn.microsoft.com/library/windows/apps/dn279692)
* [**<span data-ttu-id="41346-231">Windows::Networking::Sockets</span><span class="sxs-lookup"><span data-stu-id="41346-231">Windows::Networking::Sockets</span></span>**](https://msdn.microsoft.com/library/windows/apps/br226960)

**<span data-ttu-id="41346-232">サンプル</span><span class="sxs-lookup"><span data-stu-id="41346-232">Samples</span></span>**

* [<span data-ttu-id="41346-233">DatagramSocket のサンプル</span><span class="sxs-lookup"><span data-stu-id="41346-233">DatagramSocket sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=243037)
* [<span data-ttu-id="41346-234">HttpClient のサンプル</span><span class="sxs-lookup"><span data-stu-id="41346-234">HttpClient Sample</span></span>]( http://go.microsoft.com/fwlink/p/?linkid=242550)
* [<span data-ttu-id="41346-235">近接通信のサンプル</span><span class="sxs-lookup"><span data-stu-id="41346-235">Proximity sample</span></span>](http://go.microsoft.com/fwlink/p/?linkid=245082)
* [<span data-ttu-id="41346-236">StreamSocket のサンプルに関するページ</span><span class="sxs-lookup"><span data-stu-id="41346-236">StreamSocket sample</span></span>](http://go.microsoft.com/fwlink/p/?linkid=243037)
