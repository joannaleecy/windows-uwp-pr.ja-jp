---
author: stevewhims
description: ネットワーク対応アプリで実行する必要がある事柄について説明します。
title: ネットワークの基本
ms.assetid: 1F47D33B-6F00-4F74-A52D-538851FD38BE
ms.author: stwhi
ms.date: 06/01/2018
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 50ac9fcf984fa6c4ebad7e480ebfc2d002256e26
ms.sourcegitcommit: 6cc275f2151f78db40c11ace381ee2d35f0155f9
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5569693"
---
# <a name="networking-basics"></a><span data-ttu-id="bcf5d-104">ネットワークの基本</span><span class="sxs-lookup"><span data-stu-id="bcf5d-104">Networking basics</span></span>
<span data-ttu-id="bcf5d-105">ネットワーク対応アプリで実行する必要がある事柄について説明します。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-105">Things you must do for any network-enabled app.</span></span>

## <a name="capabilities"></a><span data-ttu-id="bcf5d-106">機能</span><span class="sxs-lookup"><span data-stu-id="bcf5d-106">Capabilities</span></span>
<span data-ttu-id="bcf5d-107">ネットワークを使うには、アプリ マニフェストに適切な機能要素を追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-107">In order to use networking, you must add appropriate capability elements to your app manifest.</span></span> <span data-ttu-id="bcf5d-108">アプリ マニフェストにネットワーク機能が指定されていない場合、アプリはネットワーク機能を持たないため、ネットワークへの接続は失敗します。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-108">If no network capability is specified in your app's manifest, your app will have no networking capability, and any attempt to connect to the network will fail.</span></span>

<span data-ttu-id="bcf5d-109">最もよく使われるネットワーク機能を次に示します。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-109">The following are the most-used networking capabilities.</span></span>

| <span data-ttu-id="bcf5d-110">機能</span><span class="sxs-lookup"><span data-stu-id="bcf5d-110">Capability</span></span> | <span data-ttu-id="bcf5d-111">説明</span><span class="sxs-lookup"><span data-stu-id="bcf5d-111">Description</span></span> |
|------------|-------------|
| **<span data-ttu-id="bcf5d-112">internetClient</span><span class="sxs-lookup"><span data-stu-id="bcf5d-112">internetClient</span></span>** | <span data-ttu-id="bcf5d-113">インターネットや、公共の場所のネットワーク (空港、喫茶店など) への出力方向のアクセスを提供します。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-113">Provides outbound access to the Internet and networks in public places, like airports and coffee shop.</span></span> <span data-ttu-id="bcf5d-114">インターネットにアクセスする必要があるほとんどのアプリは、この機能を使います。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-114">Most apps that require Internet access should use this capability.</span></span> |
| **<span data-ttu-id="bcf5d-115">internetClientServer</span><span class="sxs-lookup"><span data-stu-id="bcf5d-115">internetClientServer</span></span>** | <span data-ttu-id="bcf5d-116">インターネットや、公共の場所のネットワーク (空港、喫茶店など) からの入力方向と出力方向のネットワーク アクセスをアプリに提供します。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-116">Gives the app inbound and outbound network access from the Internet and networks in public places like airports and coffee shops.</span></span> |
| **<span data-ttu-id="bcf5d-117">privateNetworkClientServer</span><span class="sxs-lookup"><span data-stu-id="bcf5d-117">privateNetworkClientServer</span></span>** | <span data-ttu-id="bcf5d-118">ユーザーの信頼する場所 (自宅、職場など) において、入力方向と出力方向のネットワーク アクセスをアプリに提供します。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-118">Gives the app inbound and outbound network access at the user's trusted places, like home and work.</span></span> |

<span data-ttu-id="bcf5d-119">特定の状況では、上記以外の機能がアプリで必要になることがあります。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-119">There are other capabilities that might be necessary for your app, in certain circumstances.</span></span>

| <span data-ttu-id="bcf5d-120">機能</span><span class="sxs-lookup"><span data-stu-id="bcf5d-120">Capability</span></span> | <span data-ttu-id="bcf5d-121">説明</span><span class="sxs-lookup"><span data-stu-id="bcf5d-121">Description</span></span> |
|------------|-------------|
| **<span data-ttu-id="bcf5d-122">enterpriseAuthentication</span><span class="sxs-lookup"><span data-stu-id="bcf5d-122">enterpriseAuthentication</span></span>** | <span data-ttu-id="bcf5d-123">ドメイン資格情報を必要とするネットワーク リソースにアプリが接続できるようにします。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-123">Allows an app to connect to network resources that require domain credentials.</span></span> <span data-ttu-id="bcf5d-124">この機能を使う場合、すべてのアプリの機能をドメイン管理者が有効にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-124">This capability will require a domain administrator to enable the functionality for all apps.</span></span> <span data-ttu-id="bcf5d-125">たとえば、プライベート イントラネットの SharePoint サーバーからデータを取得するアプリが該当します。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-125">An example would be an app that retrieves data from SharePoint servers on a private Intranet.</span></span> <br/> <span data-ttu-id="bcf5d-126">この機能を使うと、資格情報を必要とするネットワーク上のリソースに、自分の資格情報を使ってアクセスすることができます。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-126">With this capability your credentials can be used to access network resources on a network that requires credentials.</span></span> <span data-ttu-id="bcf5d-127">この機能を持ったアプリは、ネットワーク上でユーザーを偽装することができます。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-127">An app with this capability can impersonate you on the network.</span></span> <br/> <span data-ttu-id="bcf5d-128">この機能を使う場合、認証プロキシ経由でのインターネットへのアクセスをアプリに許可する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-128">This capability is not required to allow an app to access the Internet via an authenticating proxy.</span></span> |
| **<span data-ttu-id="bcf5d-129">proximity</span><span class="sxs-lookup"><span data-stu-id="bcf5d-129">proximity</span></span>** | <span data-ttu-id="bcf5d-130">コンピューターときわめて近い場所にあるデバイスとの近距離近接通信で必要となります。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-130">Required for near-field proximity communication with devices in close proximity to the computer.</span></span> <span data-ttu-id="bcf5d-131">近距離近接通信は、近くのデバイス上のアプリケーションに接続したりデータを送ったりするときに使われます。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-131">Near-field proximity may be used to send or connect with an application on a nearby device.</span></span> <br/> <span data-ttu-id="bcf5d-132">この機能を有効にすると、アプリは、ユーザーの同意に基づいて相手を招待したり招待に応じたりしながら、ネットワークにアクセスし、きわめて近い場所にあるデバイスに接続することができます。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-132">This capability allows an app to access the network to connect to a device in close proximity, with user consent to send an invite or accept an invite.</span></span> |
| **<span data-ttu-id="bcf5d-133">sharedUserCertificates</span><span class="sxs-lookup"><span data-stu-id="bcf5d-133">sharedUserCertificates</span></span>** | <span data-ttu-id="bcf5d-134">ソフトウェア証明書とハードウェア証明書 (スマート カード証明書など) にアプリがアクセスできるようにします。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-134">This capability allows an app to access software and hardware certificates, such as smart card certificates.</span></span> <span data-ttu-id="bcf5d-135">この機能が実行時に呼び出されると、ユーザーは、カードの挿入や証明書の選択などの行動をとる必要があります。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-135">When this capability is invoked at runtime, the user must take action, such as inserting a card or selecting a certificate.</span></span> <br/> <span data-ttu-id="bcf5d-136">この機能では、ソフトウェア証明書やハードウェア証明書、スマート カードが、アプリでの身分証明に使われます。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-136">With this capability, your software and hardware certificates or a smart card are used for identification in the app.</span></span> <span data-ttu-id="bcf5d-137">この機能は、企業や銀行、行政サービスで身分証明に使うことができます。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-137">This capability may be used by your employer, bank, or government services for identification.</span></span> |

## <a name="communicating-when-your-app-is-not-in-the-foreground"></a><span data-ttu-id="bcf5d-138">アプリがフォア グラウンドにないときの通信</span><span class="sxs-lookup"><span data-stu-id="bcf5d-138">Communicating when your app is not in the foreground</span></span>
<span data-ttu-id="bcf5d-139">「[バックグラウンド タスクによるアプリのサポート](https://msdn.microsoft.com/library/windows/apps/mt299103)」には、アプリがフォアグラウンドでないときにバックグラウンド タスクを使って処理を実行する方法に関する一般的な情報が含まれています。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-139">[Support your app with background tasks](https://msdn.microsoft.com/library/windows/apps/mt299103) contains general information about using background tasks to do work when your app is not in the foreground.</span></span> <span data-ttu-id="bcf5d-140">具体的には、アプリがフォアグラウンド アプリでないときにネットワーク経由でそのアプリのデータが到着した場合は、到着通知を受け取るための特別な手順のコードを実行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-140">More specifically, your code must take special steps to be notified when it is not the current foreground app and data arrives over the network for it.</span></span> <span data-ttu-id="bcf5d-141">この目的で Windows8、コントロール チャネル トリガーを使用して、windows 10 で引き続きサポートされています。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-141">You used Control Channel Triggers for this purpose in Windows8, and they are still supported in Windows10.</span></span> <span data-ttu-id="bcf5d-142">コントロール チャネル トリガーの使い方について詳しくは[**ここ**](https://msdn.microsoft.com/library/windows/apps/hh701032)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-142">Full information about using Control Channel Triggers is available [**here**](https://msdn.microsoft.com/library/windows/apps/hh701032).</span></span> <span data-ttu-id="bcf5d-143">Windows 10 の新しいテクノロジでプッシュ対応ストリーム ソケットなどのいくつかのシナリオのオーバーヘッドが小さい優れた機能を提供します。 ソケット ブローカーとソケット アクティビティ トリガーします。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-143">A new technology in Windows10 provides better functionality with lower overhead for some scenarios, such as push-enabled stream sockets: the socket broker and socket activity triggers.</span></span>

<span data-ttu-id="bcf5d-144">アプリで [**DatagramSocket**](https://msdn.microsoft.com/library/windows/apps/br241319)、[**StreamSocket**](https://msdn.microsoft.com/library/windows/apps/br226882)、または [**StreamSocketListener**](https://msdn.microsoft.com/library/windows/apps/br226906) を使っている場合は、開いているソケットの所有権をシステムが提供するソケット ブローカーに移譲した後、フォアグラウンドから離れるか、アプリを終了できます。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-144">If your app uses [**DatagramSocket**](https://msdn.microsoft.com/library/windows/apps/br241319), [**StreamSocket**](https://msdn.microsoft.com/library/windows/apps/br226882), or [**StreamSocketListener**](https://msdn.microsoft.com/library/windows/apps/br226906), then your app can transfer ownership of an open socket to a socket broker provided by the system, and then leave the foreground, or even terminate.</span></span> <span data-ttu-id="bcf5d-145">移譲されたソケットで接続が行われるか、そのソケットでトラフィックが到着すると、アプリまたは指定されたバックグラウンド タスクがアクティブ化します。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-145">When a connection is made on the transferred socket, or traffic arrives on that socket, then your app or its designated background task are activated.</span></span> <span data-ttu-id="bcf5d-146">アプリが実行されていない場合は、開始されます。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-146">If your app is not running, it is started.</span></span> <span data-ttu-id="bcf5d-147">その後、ソケット ブローカーは、[**SocketActivityTrigger**](https://msdn.microsoft.com/library/windows/apps/dn806009) を使って、新しいトラフィックが到着していることをアプリに通知します。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-147">The socket broker then notifies your app using a [**SocketActivityTrigger**](https://msdn.microsoft.com/library/windows/apps/dn806009) that new traffic has arrived.</span></span> <span data-ttu-id="bcf5d-148">アプリは、ソケット ブローカーからソケットを取り戻し、そのソケットのトラフィックを処理します。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-148">Your app reclaims the socket from the socket broker and process the traffic on the socket.</span></span> <span data-ttu-id="bcf5d-149">つまり、アプリがネットワーク トラフィックをアクティブに処理していないときに消費するシステム リソースが非常に少なくなります。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-149">This means that your app consumes far less system resources when it is not actively processing network traffic.</span></span>

<span data-ttu-id="bcf5d-150">ソケット ブローカーはコントロール チャネル トリガーと同じ機能を少ない制限と小さなメモリ使用量で提供するため、ソケット ブローカーの目的は、適切な場所でコントロール チャネル トリガーと交代することです。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-150">The socket broker is intended to replace Control Channel Triggers where it is applicable, because it provides the same functionality, but with fewer restrictions and a smaller memory footprint.</span></span> <span data-ttu-id="bcf5d-151">ソケット ブローカーは、ロック画面に表示するアプリ以外のアプリで使うことができ、電話でも他のデバイスと同じように使うことができます。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-151">Socket broker can be used by apps that are not lock screen apps, and it is used the same way on phones as on other devices.</span></span> <span data-ttu-id="bcf5d-152">ソケット ブローカーによってアクティブ化するために、トラフィックの到着時にアプリが実行されている必要はありません。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-152">Apps need not be running when traffic arrives in order to be activated by the socket broker.</span></span> <span data-ttu-id="bcf5d-153">さらに、ソケット ブローカーは、TCP ソケットでのリッスンをサポートします。これはコントロール チャネル トリガーではサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-153">And the socket broker supports listening on TCP sockets, which Control Channel Triggers do not support.</span></span>

### <a name="choosing-a-network-trigger"></a><span data-ttu-id="bcf5d-154">ネットワーク トリガーの選択</span><span class="sxs-lookup"><span data-stu-id="bcf5d-154">Choosing a network trigger</span></span>
<span data-ttu-id="bcf5d-155">どちらの種類のトリガーが適しているかを判断するいくつかのシナリオがあります。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-155">There are some scenarios where either kind of trigger would be suitable.</span></span> <span data-ttu-id="bcf5d-156">アプリで使うトリガーの種類を選択するときは、次のアドバイスを検討してください。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-156">When you are choosing which kind of trigger to use in your app, consider the following advice.</span></span>

-   <span data-ttu-id="bcf5d-157">[**IXMLHTTPRequest2**](https://msdn.microsoft.com/library/windows/desktop/hh831151)、[**System.Net.Http.HttpClient**](https://msdn.microsoft.com/library/windows/apps/dn298639)、または [System.Net.Http.HttpClientHandler](http://go.microsoft.com/fwlink/p/?linkid=241638) を使う場合は、[**ControlChannelTrigger**](https://msdn.microsoft.com/library/windows/apps/hh701032) を使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-157">If you are using [**IXMLHTTPRequest2**](https://msdn.microsoft.com/library/windows/desktop/hh831151), [**System.Net.Http.HttpClient**](https://msdn.microsoft.com/library/windows/apps/dn298639) or [System.Net.Http.HttpClientHandler](http://go.microsoft.com/fwlink/p/?linkid=241638), you must use [**ControlChannelTrigger**](https://msdn.microsoft.com/library/windows/apps/hh701032).</span></span>
-   <span data-ttu-id="bcf5d-158">プッシュ対応 **StreamSockets** を使っている場合、コントロール チャネル トリガーを使うことができますが、[**SocketActivityTrigger**](https://msdn.microsoft.com/library/windows/apps/dn806009) をお勧めします。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-158">If you are using push-enabled **StreamSockets**, you can use control channel triggers, but should prefer [**SocketActivityTrigger**](https://msdn.microsoft.com/library/windows/apps/dn806009).</span></span> <span data-ttu-id="bcf5d-159">後者を選ぶと、接続がアクティブに使われていない場合は、システムによってメモリが解放され、電力要件が低減されます。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-159">The latter choice allows the system to free up memory and reduce power requirements when the connection is not being actively used.</span></span>
-   <span data-ttu-id="bcf5d-160">アプリがネットワーク要求をアクティブに処理していないときのメモリ使用量をできる限り少なくする場合は、可能な限り [**SocketActivityTrigger**](https://msdn.microsoft.com/library/windows/apps/dn806009) をお勧めします。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-160">If you want to minimize the memory footprint of your app when it is not actively servicing network requests, prefer [**SocketActivityTrigger**](https://msdn.microsoft.com/library/windows/apps/dn806009) when possible.</span></span>
-   <span data-ttu-id="bcf5d-161">システムがコネクト スタンバイ モードにあるときにアプリがデータを受信できるようにする場合は、[**SocketActivityTrigger**](https://msdn.microsoft.com/library/windows/apps/dn806009) を使います。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-161">If you want your app to be able to receive data while the system is in Connected Standby mode, use [**SocketActivityTrigger**](https://msdn.microsoft.com/library/windows/apps/dn806009).</span></span>

<span data-ttu-id="bcf5d-162">ソケット ブローカーの使い方の説明と例については、「[バックグラウンドでのネットワーク通信](network-communications-in-the-background.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-162">For details and examples of how to use the socket broker, see [Network communications in the background](network-communications-in-the-background.md).</span></span>

## <a name="secured-connections"></a><span data-ttu-id="bcf5d-163">セキュリティ保護された接続</span><span class="sxs-lookup"><span data-stu-id="bcf5d-163">Secured connections</span></span>
<span data-ttu-id="bcf5d-164">Secure Sockets Layer (SSL) とより新しいトランスポート層セキュリティ (TLS) は、ネットワーク通信の認証と暗号化を実現するように設計された暗号化プロトコルです。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-164">Secure Sockets Layer (SSL) and the more recent Transport Layer Security (TLS) are cryptographic protocols designed to provide authentication and encryption for network communication.</span></span> <span data-ttu-id="bcf5d-165">これらのプロトコルは、ネットワーク データの送受信時に傍受や改ざんを防ぐように設計されています。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-165">These protocols are designed to prevent eavesdropping and tampering when sending and receiving network data.</span></span> <span data-ttu-id="bcf5d-166">これらのプロトコルでは、クライアント/サーバー モデルを使ってプロトコル交換が行われます。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-166">These protocols use a client-server model for the protocol exchanges.</span></span> <span data-ttu-id="bcf5d-167">また、デジタル証明書と証明機関を使って、サーバーが本物であることが確認されます。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-167">These protocols also use digital certificates and certificate authorities to verify that the server is who it claims to be.</span></span>

### <a name="creating-secure-socket-connections"></a><span data-ttu-id="bcf5d-168">セキュリティが確保されたソケット接続の作成</span><span class="sxs-lookup"><span data-stu-id="bcf5d-168">Creating secure socket connections</span></span>
<span data-ttu-id="bcf5d-169">[**StreamSocket**](https://msdn.microsoft.com/library/windows/apps/br226882) オブジェクトは、クライアントとサーバー間の通信に SSL/TLS を使うように構成できます。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-169">A [**StreamSocket**](https://msdn.microsoft.com/library/windows/apps/br226882) object can be configured to use SSL/TLS for communications between the client and the server.</span></span> <span data-ttu-id="bcf5d-170">この SSL/TLS のサポートは、SSL/TLS ネゴシエーションで **StreamSocket** オブジェクトをクライアントとして使うことに制限されます。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-170">This support for SSL/TLS is limited to using the **StreamSocket** object as the client in the SSL/TLS negotiation.</span></span> <span data-ttu-id="bcf5d-171">サーバーとしての SSL/TLS ネゴシエーションは **StreamSocket** クラスで実装されていないため、着信接続を受信したときに [**StreamSocketListener**](https://msdn.microsoft.com/library/windows/apps/br226906) によって作成された **StreamSocket** と共に SSL/TLS を使うことはできません。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-171">You cannot use SSL/TLS with the **StreamSocket** created by a [**StreamSocketListener**](https://msdn.microsoft.com/library/windows/apps/br226906) when incoming communications are received, because SSL/TLS negotiation as a server is not implemented by the **StreamSocket** class.</span></span>

<span data-ttu-id="bcf5d-172">[**StreamSocket**](https://msdn.microsoft.com/library/windows/apps/br226882) 接続のセキュリティを確保するには 2 つの方法があります。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-172">There are two ways to secure a [**StreamSocket**](https://msdn.microsoft.com/library/windows/apps/br226882) connection with SSL/TLS:</span></span>

-   <span data-ttu-id="bcf5d-173">[**ConnectAsync**](https://msdn.microsoft.com/library/windows/apps/hh701504) - ネットワーク サービスへの最初の接続を確立してすぐに、すべての通信で SSL/TLS を使うようにネゴシエートします。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-173">[**ConnectAsync**](https://msdn.microsoft.com/library/windows/apps/hh701504) - Make the initial connection to a network service and negotiate immediately to use SSL/TLS for all communications.</span></span>
-   <span data-ttu-id="bcf5d-174">[**UpgradeToSslAsync**](https://msdn.microsoft.com/library/windows/apps/br226922) - 最初に暗号化なしでネットワーク サービスに接続します。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-174">[**UpgradeToSslAsync**](https://msdn.microsoft.com/library/windows/apps/br226922) - Connect initially to a network service without encryption.</span></span> <span data-ttu-id="bcf5d-175">アプリでデータが送受信される場合があります。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-175">The app may send or receive data.</span></span> <span data-ttu-id="bcf5d-176">その後、以降のすべての通信で SSL/TLS を使うように接続をアップグレードします。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-176">Then, upgrade the connection to use SSL/TLS for all further communications.</span></span>

<span data-ttu-id="bcf5d-177">SocketProtectionLevel は、アプリが接続を確立またはアップグレードする際に必要なソケット保護レベルを指定します。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-177">The SocketProtectionLevel specifies the desired socket protection level the app wants to establish or upgrade the connection with.</span></span> <span data-ttu-id="bcf5d-178">ただし、確立される接続の最終的な保護レベルは接続の両方のエンドポイント間のネゴシエーション プロセスで決まります。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-178">However, the eventual protection level of the established connection is determined in a negotiation process between both endpoints of the connection.</span></span> <span data-ttu-id="bcf5d-179">指定した保護レベルは、相手のエンドポイントでより低いレベルが要求されている場合、より低くなることがあります。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-179">The result can be a lower protection level than the one you specified, if the other endpoint requests a lower level.</span></span> 

 <span data-ttu-id="bcf5d-180">非同期操作が正常に完了した後、[**ConnectAsync**](https://msdn.microsoft.com/library/windows/apps/hh701504) または [**UpgradeToSslAsync**](https://msdn.microsoft.com/library/windows/apps/br226922) の呼び出しで要求された保護レベルは、[**StreamSocketinformation.ProtectionLevel**](https://msdn.microsoft.com/library/windows/apps/hh967868) プロパティで取得できます。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-180">After the async operation has completed successfully, you can retrieve the requested protection level used in the [**ConnectAsync**](https://msdn.microsoft.com/library/windows/apps/hh701504) or [**UpgradeToSslAsync**](https://msdn.microsoft.com/library/windows/apps/br226922) call through the  [**StreamSocketinformation.ProtectionLevel**](https://msdn.microsoft.com/library/windows/apps/hh967868) property.</span></span> <span data-ttu-id="bcf5d-181">ただし、これは接続で実際に使用されている保護レベルを反映していません。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-181">However, this does not reflect the actual protection level the connection is using.</span></span>

> [!NOTE]
> <span data-ttu-id="bcf5d-182">コードでは、特定の保護レベルの使用に暗黙的に依存しないように、つまり特定のセキュリティ レベルの既定での使用を前提にしないようにしてください。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-182">Your code should not implicitly depend on using a particular protection level, or on the assumption that a given security level is used by default.</span></span> <span data-ttu-id="bcf5d-183">セキュリティ環境は変わり続けており、プロトコルと既定の保護レベルは、既知の弱点のあるプロトコルの使用を避けるように、刻々と変更されています。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-183">The security landscape changes constantly, and protocols and default protection levels change over time in order to avoid the use of protocols with known weaknesses.</span></span> <span data-ttu-id="bcf5d-184">既定値は、個々のコンピューターの構成、つまりインストールされているソフトウェアや適用されているパッチによって異なることがあります。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-184">Defaults can vary depending on individual machine configuration, or on which software is installed and which patches have been applied.</span></span> <span data-ttu-id="bcf5d-185">アプリが特定のセキュリティ レベルの使用に依存する場合は、明示的にそのレベルを指定したうえで、実際にそのレベルを使って接続が確立されたことを確認する必要があります。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-185">If your app depends on the use of a particular security level, then you must explicitly specify that level and then check to be sure that it is actually in use on the established connection.</span></span>

### <a name="use-connectasync"></a><span data-ttu-id="bcf5d-186">ConnectAsync の使用</span><span class="sxs-lookup"><span data-stu-id="bcf5d-186">Use ConnectAsync</span></span>
<span data-ttu-id="bcf5d-187">[**ConnectAsync**](https://msdn.microsoft.com/library/windows/apps/hh701504)ネットワーク サービスへの最初の接続を確立してすぐに、すべての通信で SSL/TLS を使うようにネゴシエートするのに使えます。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-187">[**ConnectAsync**](https://msdn.microsoft.com/library/windows/apps/hh701504) can be used to establish the initial connection with a network service and then negotiate immediately to use SSL/TLS for all communications.</span></span> <span data-ttu-id="bcf5d-188">*protectionLevel* パラメーターを渡すことができる **ConnectAsync** メソッドは 2 つあります。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-188">There are two **ConnectAsync** methods that support passing a *protectionLevel* parameter:</span></span>

-   <span data-ttu-id="bcf5d-189">[**ConnectAsync(EndpointPair, SocketProtectionLevel)**](https://msdn.microsoft.com/library/windows/apps/hh701511) - [**StreamSocket**](https://msdn.microsoft.com/library/windows/apps/br226882) オブジェクトで、[**EndpointPair**](https://msdn.microsoft.com/library/windows/apps/hh700953) オブジェクトと [**SocketProtectionLevel**](https://msdn.microsoft.com/library/windows/apps/br226880) で指定したリモート ネットワークの宛先に接続する非同期操作を開始します。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-189">[**ConnectAsync(EndpointPair, SocketProtectionLevel)**](https://msdn.microsoft.com/library/windows/apps/hh701511) - Starts an asynchronous operation on a [**StreamSocket**](https://msdn.microsoft.com/library/windows/apps/br226882) object to connect to a remote network destination specified as an [**EndpointPair**](https://msdn.microsoft.com/library/windows/apps/hh700953) object and a [**SocketProtectionLevel**](https://msdn.microsoft.com/library/windows/apps/br226880).</span></span>
-   <span data-ttu-id="bcf5d-190">[**ConnectAsync(HostName, String, SocketProtectionLevel)**](https://msdn.microsoft.com/library/windows/apps/br226916) - [**StreamSocket**](https://msdn.microsoft.com/library/windows/apps/br226882) オブジェクトで、リモート ホスト名、リモート サービス名、[**SocketProtectionLevel**](https://msdn.microsoft.com/library/windows/apps/br226880) で指定したリモートの宛先に接続する非同期操作を開始します。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-190">[**ConnectAsync(HostName, String, SocketProtectionLevel)**](https://msdn.microsoft.com/library/windows/apps/br226916) - Starts an asynchronous operation on a [**StreamSocket**](https://msdn.microsoft.com/library/windows/apps/br226882) object to connect to a remote destination specified by a remote hostname, a remote service name, and a [**SocketProtectionLevel**](https://msdn.microsoft.com/library/windows/apps/br226880).</span></span>

<span data-ttu-id="bcf5d-191">先ほどのいずれかの [**ConnectAsync**](https://msdn.microsoft.com/library/windows/apps/hh701504) メソッドを呼び出すときに *protectionLevel* パラメーターが **Windows.Networking.Sockets.SocketProtectionLevel.Ssl** に設定されていると、[**StreamSocket**](https://msdn.microsoft.com/library/windows/apps/br226882) による通信の暗号化に SSL/TLS を使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-191">If the *protectionLevel* parameter is set to **Windows.Networking.Sockets.SocketProtectionLevel.Ssl** when calling either of the above [**ConnectAsync**](https://msdn.microsoft.com/library/windows/apps/hh701504) methods, the [**StreamSocket**](https://msdn.microsoft.com/library/windows/apps/br226882) must will be established to use SSL/TLS for encryption.</span></span> <span data-ttu-id="bcf5d-192">この値を指定すると暗号化が必要になり、NULL 暗号を使うことはできません。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-192">This value requires encryption and never allows a NULL cipher to be used.</span></span>

<span data-ttu-id="bcf5d-193">これらの [**ConnectAsync**](https://msdn.microsoft.com/library/windows/apps/hh701504) メソッドで使う一般的な手順は同じです。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-193">The normal sequence to use with one of these [**ConnectAsync**](https://msdn.microsoft.com/library/windows/apps/hh701504) methods is the same.</span></span>

-   <span data-ttu-id="bcf5d-194">[**StreamSocket**](https://msdn.microsoft.com/library/windows/apps/br226882) を作成します。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-194">Create a [**StreamSocket**](https://msdn.microsoft.com/library/windows/apps/br226882).</span></span>
-   <span data-ttu-id="bcf5d-195">ソケットの詳細オプションが必要な場合は、[**StreamSocket.Control**](https://msdn.microsoft.com/library/windows/apps/br226917) プロパティを使って、[**StreamSocket**](https://msdn.microsoft.com/library/windows/apps/br226882) オブジェクトに関連付けられている [**StreamSocketControl**](https://msdn.microsoft.com/library/windows/apps/br226893) インスタンスを取得します。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-195">If an advanced option on the socket is needed, use the [**StreamSocket.Control**](https://msdn.microsoft.com/library/windows/apps/br226917) property to get the [**StreamSocketControl**](https://msdn.microsoft.com/library/windows/apps/br226893) instance associated with a [**StreamSocket**](https://msdn.microsoft.com/library/windows/apps/br226882) object.</span></span> <span data-ttu-id="bcf5d-196">**StreamSocketControl** のプロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-196">Set a property on the **StreamSocketControl**.</span></span>
-   <span data-ttu-id="bcf5d-197">上記のいずれかの [**ConnectAsync**](https://msdn.microsoft.com/library/windows/apps/hh701504) メソッドを呼び出し、リモートの宛先に接続する操作を開始してすぐに、SSL/TLS の使用をネゴシエートします。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-197">Call one of the above [**ConnectAsync**](https://msdn.microsoft.com/library/windows/apps/hh701504) methods to start an operation to connect to a remote destination and immediately negotiate the use of SSL/TLS.</span></span>
-   <span data-ttu-id="bcf5d-198">[**ConnectAsync**](https://msdn.microsoft.com/library/windows/apps/hh701504) を使って実際にネゴシエートされる SSL の強度は、非同期操作の成功後に取得される [**StreamSocketinformation.ProtectionLevel**](https://msdn.microsoft.com/library/windows/apps/hh967868) プロパティによって決まります。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-198">The SSL strength actually negotiated using [**ConnectAsync**](https://msdn.microsoft.com/library/windows/apps/hh701504) can be determined by getting the [**StreamSocketinformation.ProtectionLevel**](https://msdn.microsoft.com/library/windows/apps/hh967868) property after the async operation has completed successfully.</span></span>

<span data-ttu-id="bcf5d-199">次の例では、[**StreamSocket**](https://msdn.microsoft.com/library/windows/apps/br226882) を作り、ネットワーク サービスへの接続を確立してすぐに、SSL/TLS を使うようにネゴシエートします。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-199">The following example creates a [**StreamSocket**](https://msdn.microsoft.com/library/windows/apps/br226882) and tries to establish a connection to the network service and negotiate immediately to use SSL/TLS.</span></span> <span data-ttu-id="bcf5d-200">ネゴシエーションに成功すると、クライアントとネットワーク サーバー間で **StreamSocket** を使うすべてのネットワーク通信が暗号化されます。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-200">If the negotiation is successful, all network communication using the **StreamSocket** between the client the network server will be encrypted.</span></span>

```csharp
using Windows.Networking;
using Windows.Networking.Sockets;

    // Define some variables and set values
    StreamSocket clientSocket = new StreamSocket();
     
    HostName serverHost = new HostName("www.contoso.com");
    string serverServiceName = "https";
    
    // For simplicity, the sample omits implementation of the
    // NotifyUser method used to display status and error messages 
    
    // Try to connect to contoso using HTTPS (port 443)
    try {

        // Call ConnectAsync method with SSL
        await clientSocket.ConnectAsync(serverHost, serverServiceName, SocketProtectionLevel.Ssl);

        NotifyUser("Connected");
    }
    catch (Exception exception) {
        // If this is an unknown status it means that the error is fatal and retry will likely fail.
        if (SocketError.GetStatus(exception.HResult) == SocketErrorStatus.Unknown) {
            throw;
        }
        
        NotifyUser("Connect failed with error: " + exception.Message);
        // Could retry the connection, but for this simple example
        // just close the socket.
        
        clientSocket.Dispose();
        clientSocket = null; 
    }
           
    // Add code to send and receive data using the clientSocket
    // and then close the clientSocket
```

```cppwinrt
#include <winrt/Windows.Networking.Sockets.h>

using namespace winrt;
...
    // Define some variables, and set values.
    Windows::Networking::Sockets::StreamSocket clientSocket;

    Windows::Networking::HostName serverHost{ L"www.contoso.com" };
    winrt::hstring serverServiceName{ L"https" };

    // For simplicity, the sample omits implementation of the
    // NotifyUser method used to display status and error messages.

    // Try to connect to the server using HTTPS and SSL (port 443).
    try
    {
        co_await clientSocket.ConnectAsync(serverHost, serverServiceName, Windows::Networking::Sockets::SocketProtectionLevel::Tls12);
        NotifyUser(L"Connected");
    }
    catch (winrt::hresult_error const& exception)
    {
        NotifyUser(L"Connect failed with error: " + exception.message());
        clientSocket = nullptr;
    }
    // Add code to send and receive data using the clientSocket,
    // then set the clientSocket to nullptr when done to close it.
```

```cpp
using Windows::Networking;
using Windows::Networking::Sockets;

    // Define some variables and set values
    StreamSocket^ clientSocket = new ref StreamSocket();
 
    HostName^ serverHost = new ref HostName("www.contoso.com");
    String serverServiceName = "https";

    // For simplicity, the sample omits implementation of the
    // NotifyUser method used to display status and error messages 

    // Try to connect to the server using HTTPS and SSL (port 443)
    task<void>(clientSocket->ConnectAsync(serverHost, serverServiceName, SocketProtectionLevel::SSL)).then([this] (task<void> previousTask) {
        try
        {
            // Try getting all exceptions from the continuation chain above this point.
            previousTask.Get();
            NotifyUser("Connected");
        }
        catch (Exception^ exception)
        {
            NotifyUser("Connect failed with error: " + exception->Message);
            
            clientSocket.Close();
            clientSocket = null;
        }
    });
    // Add code to send and receive data using the clientSocket
    // Then close the clientSocket when done
```

### <a name="use-upgradetosslasync"></a><span data-ttu-id="bcf5d-201">UpgradeToSslAsync の使用</span><span class="sxs-lookup"><span data-stu-id="bcf5d-201">Use UpgradeToSslAsync</span></span>
<span data-ttu-id="bcf5d-202">コードで [**UpgradeToSslAsync**](https://msdn.microsoft.com/library/windows/apps/br226922) を使うときは、ネットワーク サービスへの最初の接続を暗号化なしで確立します。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-202">When your code uses [**UpgradeToSslAsync**](https://msdn.microsoft.com/library/windows/apps/br226922), it first establishes a connection to a network service without encryption.</span></span> <span data-ttu-id="bcf5d-203">アプリでデータが送受信される可能性があるため、以降のすべての通信で SSL/TLS を使うように接続をアップグレードします。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-203">The app may send or receive some data, then upgrade the connection to use SSL/TLS for all further communications.</span></span>

<span data-ttu-id="bcf5d-204">[**UpgradeToSslAsync**](https://msdn.microsoft.com/library/windows/apps/br226922) メソッドは 2 つのパラメーターを受け取ります。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-204">The [**UpgradeToSslAsync**](https://msdn.microsoft.com/library/windows/apps/br226922) method takes two parameters.</span></span> <span data-ttu-id="bcf5d-205">*protectionLevel* パラメーターは、目的の保護レベルを示します。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-205">The *protectionLevel* parameter indicates the protection level desired.</span></span> <span data-ttu-id="bcf5d-206">*validationHostName* パラメーターは、SSL へのアップグレード時の検証に使われるリモート ネットワークの宛先のホスト名です。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-206">The *validationHostName* parameter is the hostname of the remote network destination that is used for validation when upgrading to SSL.</span></span> <span data-ttu-id="bcf5d-207">通常、*validationHostName* は、アプリが最初に接続を確立するときに使ったホスト名と同じです。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-207">Normally the *validationHostName* would be the same hostname that the app used to initially establish the connection.</span></span> <span data-ttu-id="bcf5d-208">**UpgradeToSslAsync** を呼び出すときに *protectionLevel* パラメーターが **Windows.System.Socket.SocketProtectionLevel.Ssl** に設定されていると、[**StreamSocket**](https://msdn.microsoft.com/library/windows/apps/br226882) による以降の通信の暗号化に SSL/TLS を使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-208">If the *protectionLevel* parameter is set to **Windows.System.Socket.SocketProtectionLevel.Ssl** when calling **UpgradeToSslAsync**, the [**StreamSocket**](https://msdn.microsoft.com/library/windows/apps/br226882) must use the SSL/TLS for encryption on further communications over the socket.</span></span> <span data-ttu-id="bcf5d-209">この値を指定すると暗号化が必要になり、NULL 暗号を使うことはできません。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-209">This value requires encryption and never allows a NULL cipher to be used.</span></span>

<span data-ttu-id="bcf5d-210">[**UpgradeToSslAsync**](https://msdn.microsoft.com/library/windows/apps/br226922) メソッドで使う一般的な手順は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-210">The normal sequence to use with the [**UpgradeToSslAsync**](https://msdn.microsoft.com/library/windows/apps/br226922) method is as follows:</span></span>

-   <span data-ttu-id="bcf5d-211">[**StreamSocket**](https://msdn.microsoft.com/library/windows/apps/br226882) を作成します。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-211">Create a [**StreamSocket**](https://msdn.microsoft.com/library/windows/apps/br226882).</span></span>
-   <span data-ttu-id="bcf5d-212">ソケットの詳細オプションが必要な場合は、[**StreamSocket.Control**](https://msdn.microsoft.com/library/windows/apps/br226917) プロパティを使って、[**StreamSocket**](https://msdn.microsoft.com/library/windows/apps/br226882) オブジェクトに関連付けられている [**StreamSocketControl**](https://msdn.microsoft.com/library/windows/apps/br226893) インスタンスを取得します。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-212">If an advanced option on the socket is needed, use the [**StreamSocket.Control**](https://msdn.microsoft.com/library/windows/apps/br226917) property to get the [**StreamSocketControl**](https://msdn.microsoft.com/library/windows/apps/br226893) instance associated with a [**StreamSocket**](https://msdn.microsoft.com/library/windows/apps/br226882) object.</span></span> <span data-ttu-id="bcf5d-213">**StreamSocketControl** のプロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-213">Set a property on the **StreamSocketControl**.</span></span>
-   <span data-ttu-id="bcf5d-214">データを暗号化せずに送受信する必要がある場合は、ここで送信します。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-214">If any data needs to be sent and received unencrypted, send it now.</span></span>
-   <span data-ttu-id="bcf5d-215">[**UpgradeToSslAsync**](https://msdn.microsoft.com/library/windows/apps/br226922) メソッドを呼び出して、SSL/TLS を使うように接続をアップグレードする操作を開始します。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-215">Call the [**UpgradeToSslAsync**](https://msdn.microsoft.com/library/windows/apps/br226922) method to start an operation to upgrade the connection to use SSL/TLS.</span></span>
-   <span data-ttu-id="bcf5d-216">[**UpgradeToSslAsync**](https://msdn.microsoft.com/library/windows/apps/br226922) を使って実際にネゴシエートされる SSL の強度は、非同期操作の成功後に取得される [**StreamSocketinformation.ProtectionLevel**](https://msdn.microsoft.com/library/windows/apps/hh967868) プロパティによって決まります。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-216">The SSL strength actually negotiated using [**UpgradeToSslAsync**](https://msdn.microsoft.com/library/windows/apps/br226922) can be determined by getting the [**StreamSocketinformation.ProtectionLevel**](https://msdn.microsoft.com/library/windows/apps/hh967868) property after the async operation completes successfully.</span></span>

<span data-ttu-id="bcf5d-217">次の例では、[**StreamSocket**](https://msdn.microsoft.com/library/windows/apps/br226882) を作り、ネットワーク サービスへの接続を確立して最初のデータを送って、SSL/TLS を使うようにネゴシエートします。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-217">The following example creates a [**StreamSocket**](https://msdn.microsoft.com/library/windows/apps/br226882), tries to establish a connection to the network service, sends some initial data, and then negotiates to use SSL/TLS.</span></span> <span data-ttu-id="bcf5d-218">ネゴシエーションに成功すると、クライアントとネットワーク サーバー間で **StreamSocket** を使うすべてのネットワーク通信が暗号化されます。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-218">If the negotiation is successful, all network communication using the **StreamSocket** between the client and the network server will be encrypted.</span></span>

```csharp
using Windows.Networking;
using Windows.Networking.Sockets;
using Windows.Storage.Streams;

    // Define some variables and set values
    StreamSocket clientSocket = new StreamSocket();
 
    HostName serverHost = new HostName("www.contoso.com");
    string serverServiceName = "http";

    // For simplicity, the sample omits implementation of the
    // NotifyUser method used to display status and error messages 

    // Try to connect to contoso using HTTP (port 80)
    try {
        // Call ConnectAsync method with a plain socket
        await clientSocket.ConnectAsync(serverHost, serverServiceName, SocketProtectionLevel.PlainSocket);

        NotifyUser("Connected");

    }
    catch (Exception exception) {
        // If this is an unknown status it means that the error is fatal and retry will likely fail.
        if (SocketError.GetStatus(exception.HResult) == SocketErrorStatus.Unknown) {
            throw;
        }

        NotifyUser("Connect failed with error: " + exception.Message, NotifyType.ErrorMessage);
        // Could retry the connection, but for this simple example
        // just close the socket.

        clientSocket.Dispose();
        clientSocket = null; 
        return;
    }

    // Now try to send some data
    DataWriter writer = new DataWriter(clientSocket.OutputStream);
    string hello = "Hello, World! ☺ ";
    Int32 len = (int) writer.MeasureString(hello); // Gets the UTF-8 string length.
    writer.WriteInt32(len);
    writer.WriteString(hello);
    NotifyUser("Client: sending hello");

    try {
        // Call StoreAsync method to store the hello message
        await writer.StoreAsync();

        NotifyUser("Client: sent data");

        writer.DetachStream(); // Detach stream, if not, DataWriter destructor will close it.
    }
    catch (Exception exception) {
        NotifyUser("Store failed with error: " + exception.Message);
        // Could retry the store, but for this simple example
            // just close the socket.

            clientSocket.Dispose();
            clientSocket = null; 
            return;
    }

    // Now upgrade the client to use SSL
    try {
        // Try to upgrade to SSL
        await clientSocket.UpgradeToSslAsync(SocketProtectionLevel.Ssl, serverHost);

        NotifyUser("Client: upgrade to SSL completed");
           
        // Add code to send and receive data 
        // The close clientSocket when done
    }
    catch (Exception exception) {
        // If this is an unknown status it means that the error is fatal and retry will likely fail.
        if (SocketError.GetStatus(exception.HResult) == SocketErrorStatus.Unknown) {
            throw;
        }

        NotifyUser("Upgrade to SSL failed with error: " + exception.Message);

        clientSocket.Dispose();
        clientSocket = null; 
        return;
    }
```

```cppwinrt
#include <winrt/Windows.Networking.Sockets.h>
#include <winrt/Windows.Storage.Streams.h>

using namespace winrt;
using namespace Windows::Storage::Streams;
...
    // Define some variables, and set values.
    Windows::Networking::Sockets::StreamSocket clientSocket;

    Windows::Networking::HostName serverHost{ L"www.contoso.com" };
    winrt::hstring serverServiceName{ L"https" };

    // For simplicity, the sample omits implementation of the
    // NotifyUser method used to display status and error messages. 

    // Try to connect to the server using HTTP (port 80).
    try
    {
        co_await clientSocket.ConnectAsync(serverHost, serverServiceName, Windows::Networking::Sockets::SocketProtectionLevel::PlainSocket);
        NotifyUser(L"Connected");
    }
    catch (winrt::hresult_error const& exception)
    {
        NotifyUser(L"Connect failed with error: " + exception.message());
        clientSocket = nullptr;
    }

    // Now, try to send some data.
    DataWriter writer{ clientSocket.OutputStream() };
    winrt::hstring hello{ L"Hello, World! ☺ " };
    uint32_t len{ writer.MeasureString(hello) }; // Gets the size of the string, in bytes.
    writer.WriteInt32(len);
    writer.WriteString(hello);
    NotifyUser(L"Client: sending hello");

    try
    {
        co_await writer.StoreAsync();
        NotifyUser(L"Client: sent hello");

        writer.DetachStream(); // Detach the stream when you want to continue using it; otherwise, the DataWriter destructor closes it.
    }
    catch (winrt::hresult_error const& exception)
    {
        NotifyUser(L"Store failed with error: " + exception.message());
        // We could retry the store operation. But, for this simple example, just close the socket by setting it to nullptr.
        clientSocket = nullptr;
        co_return;
    }

    // Now, upgrade the client to use SSL.
    try
    {
        co_await clientSocket.UpgradeToSslAsync(Windows::Networking::Sockets::SocketProtectionLevel::Tls12, serverHost);
        NotifyUser(L"Client: upgrade to SSL completed");

        // Add code to send and receive data using the clientSocket,
        // then set the clientSocket to nullptr when done to close it.
    }
    catch (winrt::hresult_error const& exception)
    {
        // If this is an unknown status, then the error is fatal and retry will likely fail.
        Windows::Networking::Sockets::SocketErrorStatus socketErrorStatus{ Windows::Networking::Sockets::SocketError::GetStatus(exception.to_abi()) };
        if (socketErrorStatus == Windows::Networking::Sockets::SocketErrorStatus::Unknown)
        {
            throw;
        }

        NotifyUser(L"Upgrade to SSL failed with error: " + exception.message());
        // We could retry the store operation. But for this simple example, just close the socket by setting it to nullptr.
        clientSocket = nullptr;
        co_return;
    }
```

```cpp
using Windows::Networking;
using Windows::Networking::Sockets;
using Windows::Storage::Streams;

    // Define some variables and set values
    StreamSocket^ clientSocket = new ref StreamSocket();
 
    Hostname^ serverHost = new ref HostName("www.contoso.com");
    String serverServiceName = "http";

    // For simplicity, the sample omits implementation of the
    // NotifyUser method used to display status and error messages 

    // Try to connect to contoso using HTTP (port 80)
    task<void>(clientSocket->ConnectAsync(serverHost, serverServiceName, SocketProtectionLevel::PlainSocket)).then([this] (task<void> previousTask) {
        try
        {
            // Try getting all exceptions from the continuation chain above this point.
            previousTask.Get();
            NotifyUser("Connected");
        }
        catch (Exception^ exception)
        {
            NotifyUser("Connect failed with error: " + exception->Message);
 
            clientSocket->Close();
            clientSocket = null;
        }
    });
       
    // Now try to send some data
    DataWriter^ writer = new ref DataWriter(clientSocket.OutputStream);
    String hello = "Hello, World! ☺ ";
    Int32 len = (int) writer->MeasureString(hello); // Gets the UTF-8 string length.
    writer->writeInt32(len);
    writer->writeString(hello);
    NotifyUser("Client: sending hello");

    task<void>(writer->StoreAsync()).then([this] (task<void> previousTask) {
        try {
            // Try getting all exceptions from the continuation chain above this point.
            previousTask.Get();

            NotifyUser("Client: sent hello");

            writer->DetachStream(); // Detach stream, if not, DataWriter destructor will close it.
       }
       catch (Exception^ exception) {
               NotifyUser("Store failed with error: " + exception->Message);
               // Could retry the store, but for this simple example
               // just close the socket.
 
               clientSocket->Close();
               clientSocket = null;
               return
       }
    });

    // Now upgrade the client to use SSL
    task<void>(clientSocket->UpgradeToSslAsync(clientSocket.SocketProtectionLevel.Ssl, serverHost)).then([this] (task<void> previousTask) {
        try {
            // Try getting all exceptions from the continuation chain above this point.
            previousTask.Get();

           NotifyUser("Client: upgrade to SSL completed");
           
           // Add code to send and receive data 
           // Then close clientSocket when done
        }
        catch (Exception^ exception) {
            // If this is an unknown status it means that the error is fatal and retry will likely fail.
            if (SocketError.GetStatus(exception.HResult) == SocketErrorStatus.Unknown) {
                throw;
            }

            NotifyUser("Upgrade to SSL failed with error: " + exception.Message);

            clientSocket->Close();
            clientSocket = null; 
            return;
        }
    });
```

### <a name="creating-secure-websocket-connections"></a><span data-ttu-id="bcf5d-219">セキュリティが確保された WebSocket 接続の作成</span><span class="sxs-lookup"><span data-stu-id="bcf5d-219">Creating secure WebSocket connections</span></span>
<span data-ttu-id="bcf5d-220">従来のソケット接続と同様に、[**StreamWebSocket**](https://msdn.microsoft.com/library/windows/apps/br226923) と [**MessageWebSocket**](https://msdn.microsoft.com/library/windows/apps/br226842) の機能を UWP アプリで使う際に、トランスポート層セキュリティ (TLS)/Secure Sockets Layer (SSL) を使って WebSocket 接続を暗号化することもできます。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-220">Like traditional socket connections, WebSocket connections can also be encrypted with Transport Layer Security (TLS)/Secure Sockets Layer (SSL) when using the [**StreamWebSocket**](https://msdn.microsoft.com/library/windows/apps/br226923) and [**MessageWebSocket**](https://msdn.microsoft.com/library/windows/apps/br226842) features for a UWP app.</span></span> <span data-ttu-id="bcf5d-221">ほとんどの場合、WebSocket 接続にはセキュリティを確保する必要があります。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-221">In most cases you'll want to use a secure WebSocket connection.</span></span> <span data-ttu-id="bcf5d-222">多くのプロキシは、暗号化されていない WebSocket 接続を拒否するため、接続の成功率が高くなります。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-222">This will increase the chances that your connection will succeed, as many proxies will reject unencrypted WebSocket connections.</span></span>

<span data-ttu-id="bcf5d-223">セキュリティが確保されたソケット接続を作成したりネットワーク サービスへとアップグレードする方法の例については、「[TLS/SSL を使って WebSocket 接続のセキュリティを確保する方法](https://msdn.microsoft.com/library/windows/apps/xaml/hh994399)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-223">For examples of how to create, or upgrade to, a secure socket connection to a network service, see [How to secure WebSocket connections with TLS/SSL](https://msdn.microsoft.com/library/windows/apps/xaml/hh994399).</span></span>

<span data-ttu-id="bcf5d-224">最初のハンドシェークを完了するために、サーバーでは TLS/SSL 暗号化だけでなく **Sec-WebSocket-Protocol** ヘッダー値を要求することもあります。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-224">In addition to TLS/SSL encryption, a server may require a **Sec-WebSocket-Protocol** header value to complete the initial handshake.</span></span> <span data-ttu-id="bcf5d-225">この値は [**StreamWebSocketInformation.Protocol**](https://msdn.microsoft.com/library/windows/apps/hh701514) プロパティと [**MessageWebSocketInformation.Protocol**](https://msdn.microsoft.com/library/windows/apps/hh701358) プロパティで表され、接続のプロトコル バージョンを示し、開いているハンドシェークとその後に交換されるデータをサーバーが正しく解釈できるようにします。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-225">This value, represented by the [**StreamWebSocketInformation.Protocol**](https://msdn.microsoft.com/library/windows/apps/hh701514) and [**MessageWebSocketInformation.Protocol**](https://msdn.microsoft.com/library/windows/apps/hh701358) properties, indicate the protocol version of the connection and enables the server to correctly interpret the opening handshake and the data being exchanged afterwards.</span></span> <span data-ttu-id="bcf5d-226">このプロトコル情報を使うと、サーバーが着信するデータを安全な方法で解釈できないような状況になったときに、接続を閉じることができます。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-226">Using this protocol information, if at any point if the server cannot interpret the incoming data in a safe manner the connection can be closed.</span></span>

<span data-ttu-id="bcf5d-227">クライアントからの最初の要求にこの値が含まれていない場合、または含まれている値がサーバーで想定されるものと一致しない場合は、WebSocket ハンドシェーク エラーでサーバーから想定される値がクライアントに送信されます。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-227">If the initial request from the client either does not contain this value, or provides a value that doesn't match what the server expects, the expected value is sent from the server to the client on WebSocket handshake error.</span></span>

## <a name="authentication"></a><span data-ttu-id="bcf5d-228">認証</span><span class="sxs-lookup"><span data-stu-id="bcf5d-228">Authentication</span></span>
<span data-ttu-id="bcf5d-229">ネットワーク経由で接続するときに、認証資格情報を提供する方法。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-229">How to provide authentication credentials when connecting over the network.</span></span>

### <a name="providing-a-client-certificate-with-the-streamsocket-class"></a><span data-ttu-id="bcf5d-230">StreamSocket クラスによるクライアント証明書の提供</span><span class="sxs-lookup"><span data-stu-id="bcf5d-230">Providing a client certificate with the StreamSocket class</span></span>
<span data-ttu-id="bcf5d-231">[**Windows.Networking.StreamSocket**](https://msdn.microsoft.com/library/windows/apps/br226882) クラスは、SSL/TLS を使ったアプリの接続先サーバーの認証をサポートします。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-231">The [**Windows.Networking.StreamSocket**](https://msdn.microsoft.com/library/windows/apps/br226882) class supports using SSL/TLS to authenticate the server the app is talking to.</span></span> <span data-ttu-id="bcf5d-232">場合によっては、アプリは、TLS クライアント証明書を使って自身をサーバーに対して認証する必要があります。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-232">In certain cases, the app also needs to authenticate itself to the server using a TLS client certificate.</span></span> <span data-ttu-id="bcf5d-233">、Windows 10 では、 [**StreamSocket.Control**](https://msdn.microsoft.com/library/windows/apps/br226893) (このする必要がありますが設定されるオブジェクトは TLS ハンドシェイクが開始される前に) のクライアント証明書を提供できます。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-233">In Windows10, you can provide a client certificate on the [**StreamSocket.Control**](https://msdn.microsoft.com/library/windows/apps/br226893) object (this must be set before the TLS handshake is started).</span></span> <span data-ttu-id="bcf5d-234">サーバーがクライアント証明書を要求した場合、Windows が提供された証明書を使って応答します。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-234">If the server requests the client certificate, Windows will respond with the certificate provided.</span></span>

<span data-ttu-id="bcf5d-235">これを実装する方法を示すコード スニペットを次に示します。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-235">Here is a code snippet showing how to implement this:</span></span>

```csharp
var socket = new StreamSocket();
Windows.Security.Cryptography.Certificates.Certificate certificate = await GetClientCert();
socket.Control.ClientCertificate = certificate;
await socket.ConnectAsync(destination, SocketProtectionLevel.Tls12);
```

### <a name="providing-authentication-credentials-to-a-web-service"></a><span data-ttu-id="bcf5d-236">Web サービスへの認証資格情報の提供</span><span class="sxs-lookup"><span data-stu-id="bcf5d-236">Providing authentication credentials to a web service</span></span>
<span data-ttu-id="bcf5d-237">Networking API は、セキュリティが確保された Web サービスとアプリが連携できるようにします。この API のそれぞれが、サーバーとプロキシの認証資格情報を使ってクライアントの初期化または要求ヘッダーの設定を行う独自のメソッドを提供します。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-237">The networking APIs that enable apps to interact with secure web services each provide their own methods to either initialize a client or set a request header with server and proxy authentication credentials.</span></span> <span data-ttu-id="bcf5d-238">各メソッドは、[**PasswordCredential**](https://msdn.microsoft.com/library/windows/apps/br227061) オブジェクトを使って設定されます。このオブジェクトは、ユーザー名、パスワード、それぞれの資格情報が使われるリソースを示します。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-238">Each method is set with a [**PasswordCredential**](https://msdn.microsoft.com/library/windows/apps/br227061) object that indicates a user name, password, and the resource for which these credentials are used.</span></span> <span data-ttu-id="bcf5d-239">次の表では、これらの API のマッピングについて説明します。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-239">The following table provides a mapping of these APIs:</span></span>

| **<span data-ttu-id="bcf5d-240">WebSocket</span><span class="sxs-lookup"><span data-stu-id="bcf5d-240">WebSockets</span></span>** | [**<span data-ttu-id="bcf5d-241">MessageWebSocketControl.ServerCredential</span><span class="sxs-lookup"><span data-stu-id="bcf5d-241">MessageWebSocketControl.ServerCredential</span></span>**](https://msdn.microsoft.com/library/windows/apps/br226848) |
|-------------------------|----------------------------------------------------------------------------------------------------------|
|  | [**<span data-ttu-id="bcf5d-242">MessageWebSocketControl.ProxyCredential</span><span class="sxs-lookup"><span data-stu-id="bcf5d-242">MessageWebSocketControl.ProxyCredential</span></span>**](https://msdn.microsoft.com/library/windows/apps/br226847) |
|  | [**<span data-ttu-id="bcf5d-243">StreamWebSocketControl.ServerCredential</span><span class="sxs-lookup"><span data-stu-id="bcf5d-243">StreamWebSocketControl.ServerCredential</span></span>**](https://msdn.microsoft.com/library/windows/apps/br226928) |
|  | [**<span data-ttu-id="bcf5d-244">StreamWebSocketControl.ProxyCredential</span><span class="sxs-lookup"><span data-stu-id="bcf5d-244">StreamWebSocketControl.ProxyCredential</span></span>**](https://msdn.microsoft.com/library/windows/apps/br226927) |
| **<span data-ttu-id="bcf5d-245">バックグラウンド転送</span><span class="sxs-lookup"><span data-stu-id="bcf5d-245">Background Transfer</span></span>** | [**<span data-ttu-id="bcf5d-246">BackgroundDownloader.ServerCredential</span><span class="sxs-lookup"><span data-stu-id="bcf5d-246">BackgroundDownloader.ServerCredential</span></span>**](https://msdn.microsoft.com/library/windows/apps/hh701076) |
|  | [**<span data-ttu-id="bcf5d-247">BackgroundDownloader.ProxyCredential</span><span class="sxs-lookup"><span data-stu-id="bcf5d-247">BackgroundDownloader.ProxyCredential</span></span>**](https://msdn.microsoft.com/library/windows/apps/hh701068) |
|  | [**<span data-ttu-id="bcf5d-248">BackgroundUploader.ServerCredential</span><span class="sxs-lookup"><span data-stu-id="bcf5d-248">BackgroundUploader.ServerCredential</span></span>**](https://msdn.microsoft.com/library/windows/apps/hh701184) |
|  | [**<span data-ttu-id="bcf5d-249">BackgroundUploader.ProxyCredential</span><span class="sxs-lookup"><span data-stu-id="bcf5d-249">BackgroundUploader.ProxyCredential</span></span>**](https://msdn.microsoft.com/library/windows/apps/hh701178) |
| **<span data-ttu-id="bcf5d-250">配信</span><span class="sxs-lookup"><span data-stu-id="bcf5d-250">Syndication</span></span>** | [**<span data-ttu-id="bcf5d-251">SyndicationClient(PasswordCredential)</span><span class="sxs-lookup"><span data-stu-id="bcf5d-251">SyndicationClient(PasswordCredential)</span></span>**](https://msdn.microsoft.com/library/windows/apps/hh702355) |
|  | [**<span data-ttu-id="bcf5d-252">SyndicationClient.ServerCredential</span><span class="sxs-lookup"><span data-stu-id="bcf5d-252">SyndicationClient.ServerCredential</span></span>**](https://msdn.microsoft.com/library/windows/apps/br243461) |
|  | [**<span data-ttu-id="bcf5d-253">SyndicationClient.ProxyCredential</span><span class="sxs-lookup"><span data-stu-id="bcf5d-253">SyndicationClient.ProxyCredential</span></span>**](https://msdn.microsoft.com/library/windows/apps/br243459) |
| **<span data-ttu-id="bcf5d-254">AtomPub</span><span class="sxs-lookup"><span data-stu-id="bcf5d-254">AtomPub</span></span>** | [**<span data-ttu-id="bcf5d-255">AtomPubClient(PasswordCredential)</span><span class="sxs-lookup"><span data-stu-id="bcf5d-255">AtomPubClient(PasswordCredential)</span></span>**](https://msdn.microsoft.com/library/windows/apps/hh702262) |
|  | [**<span data-ttu-id="bcf5d-256">AtomPubClient.ServerCredential</span><span class="sxs-lookup"><span data-stu-id="bcf5d-256">AtomPubClient.ServerCredential</span></span>**](https://msdn.microsoft.com/library/windows/apps/br243428) |
|  | [**<span data-ttu-id="bcf5d-257">AtomPubClient.ProxyCredential</span><span class="sxs-lookup"><span data-stu-id="bcf5d-257">AtomPubClient.ProxyCredential</span></span>**](https://msdn.microsoft.com/library/windows/apps/br243423) |

## <a name="handling-network-exceptions"></a><span data-ttu-id="bcf5d-258">ネットワーク例外を処理する</span><span class="sxs-lookup"><span data-stu-id="bcf5d-258">Handling network exceptions</span></span>
<span data-ttu-id="bcf5d-259">ほとんどのプログラミング領域では、例外は、プログラムの不具合によって発生した重大な問題やエラーを示します。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-259">In most areas of programming, an exception indicates a significant problem or failure, caused by some flaw in the program.</span></span> <span data-ttu-id="bcf5d-260">ネットワーク プログラミングでは、さらに、ネットワークそのものとネットワーク通信の特性という、例外の発生源があります。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-260">In network programming, there is an additional source for exceptions: the network itself, and the nature of network communications.</span></span> <span data-ttu-id="bcf5d-261">ネットワーク通信は、本質的に信頼性が低く、予期しない障害が発生する傾向があります。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-261">Network communications are inherently unreliable and prone to unexpected failure.</span></span> <span data-ttu-id="bcf5d-262">アプリでネットワークを使う方法のそれぞれについて、状態情報を維持する必要があります。アプリのコードは、その状態情報を更新し、通信エラーが発生したときに接続を再び確立するか再試行する適切なロジックを開始することで、ネットワーク例外を処理する必要があります。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-262">For each of the ways your app uses networking, you must maintain some state information; and your app code must handle network exceptions by updating that state information and initiating appropriate logic for your app to re-establish or retry communication failures.</span></span>

<span data-ttu-id="bcf5d-263">ユニバーサル Windows アプリで例外がスローされると、例外ハンドラーは例外の原因についての詳しい情報を取得することでエラーの内容を理解して適切な判断を下すことができます。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-263">When Universal Windows apps throw an exception, your exception handler can retrieve more detailed information on the cause of the exception to better understand the failure and make appropriate decisions.</span></span>

<span data-ttu-id="bcf5d-264">各言語のプロジェクションは、この詳しい情報にアクセスするためのメソッドをサポートしています。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-264">Each language projection supports a method to access this more detailed information.</span></span> <span data-ttu-id="bcf5d-265">例外は、ユニバーサル Windows アプリの **HRESULT** 値としてプロジェクションされます。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-265">An exception projects as an **HRESULT** value in Universal Windows apps.</span></span> <span data-ttu-id="bcf5d-266">*Winerror.h* インクルード ファイルには、ネットワーク エラーを含む、出力される可能性がある **HRESULT** 値の大きなリストが格納されています。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-266">The *Winerror.h* include file contains a very large list of possible **HRESULT** values that includes network errors.</span></span>

<span data-ttu-id="bcf5d-267">Networking API は、例外の原因についての詳しい情報を取得するために、他のメソッドをサポートしています。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-267">The networking APIs support different methods for retrieving this detailed information on the cause of an exception.</span></span>

-   <span data-ttu-id="bcf5d-268">一部の API には、例外の **HRESULT** 値を列挙値に変換するヘルパー メソッドがあります。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-268">Some APIs provide a helper method that converts the **HRESULT** value from the exception to an enumeration value.</span></span>
-   <span data-ttu-id="bcf5d-269">その他の API には、実際の **HRESULT** 値を取得するメソッドがあります。</span><span class="sxs-lookup"><span data-stu-id="bcf5d-269">Other APIs provide a method to retrieve the actual **HRESULT** value.</span></span>

## <a name="related-topics"></a><span data-ttu-id="bcf5d-270">関連トピック</span><span class="sxs-lookup"><span data-stu-id="bcf5d-270">Related topics</span></span>
* [<span data-ttu-id="bcf5d-271">Windows 10 での Networking API の機能強化</span><span class="sxs-lookup"><span data-stu-id="bcf5d-271">Networking API Improvements in Windows 10</span></span>](http://blogs.windows.com/buildingapps/2015/07/02/networking-api-improvements-in-windows-10/)
