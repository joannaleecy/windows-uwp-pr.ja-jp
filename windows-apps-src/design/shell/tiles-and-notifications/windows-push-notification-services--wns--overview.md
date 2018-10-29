---
author: mijacobs
Description: The Windows Push Notification Services (WNS) enables third-party developers to send toast, tile, badge, and raw updates from their own cloud service. This provides a mechanism to deliver new updates to your users in a power-efficient and dependable way.
title: Windows プッシュ通知サービス (WNS) の概要
ms.assetid: 2125B09F-DB90-4515-9AA6-516C7E9ACCCD
template: detail.hbs
ms.author: mijacobs
ms.date: 05/19/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 2b7d9adfd9e058d4364470b07ef3e9129ade88b3
ms.sourcegitcommit: 753e0a7160a88830d9908b446ef0907cc71c64e7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/29/2018
ms.locfileid: "5751794"
---
# <a name="windows-push-notification-services-wns-overview"></a><span data-ttu-id="87680-103">Windows プッシュ通知サービス (WNS) の概要</span><span class="sxs-lookup"><span data-stu-id="87680-103">Windows Push Notification Services (WNS) overview</span></span>
 

<span data-ttu-id="87680-104">Windows プッシュ通知サービス (WNS) を利用することで、サード パーティの開発者が独自のクラウド サービスからトースト更新、タイル更新、バッジ更新、直接更新を送ることができます。</span><span class="sxs-lookup"><span data-stu-id="87680-104">The Windows Push Notification Services (WNS) enables third-party developers to send toast, tile, badge, and raw updates from their own cloud service.</span></span> <span data-ttu-id="87680-105">これにより、新しい更新を電力効率に優れた信頼できる方法でユーザーに配信するためのメカニズムが提供されます。</span><span class="sxs-lookup"><span data-stu-id="87680-105">This provides a mechanism to deliver new updates to your users in a power-efficient and dependable way.</span></span>

## <a name="how-it-works"></a><span data-ttu-id="87680-106">しくみ</span><span class="sxs-lookup"><span data-stu-id="87680-106">How it works</span></span>


<span data-ttu-id="87680-107">次の図に、プッシュ通知を送るときの全体のデータ フローを示します。</span><span class="sxs-lookup"><span data-stu-id="87680-107">The following diagram shows the complete data flow for sending a push notification.</span></span> <span data-ttu-id="87680-108">次の手順で行われます。</span><span class="sxs-lookup"><span data-stu-id="87680-108">It involves these steps:</span></span>

1.  <span data-ttu-id="87680-109">アプリがユニバーサル Windows プラットフォームにプッシュ通知チャネルを要求します。</span><span class="sxs-lookup"><span data-stu-id="87680-109">Your app requests a push notification channel from the Universal Windows Platform.</span></span>
2.  <span data-ttu-id="87680-110">Windows が、通知チャネルを作成するように WNS に要求します。</span><span class="sxs-lookup"><span data-stu-id="87680-110">Windows asks WNS to create a notification channel.</span></span> <span data-ttu-id="87680-111">このチャネルは、Uniform Resource Identifier (URI) の形式で呼び出し元のデバイスに返されます。</span><span class="sxs-lookup"><span data-stu-id="87680-111">This channel is returned to the calling device in the form of a Uniform Resource Identifier (URI).</span></span>
3.  <span data-ttu-id="87680-112">通知チャネルの URI が、Windows によってアプリに返されます。</span><span class="sxs-lookup"><span data-stu-id="87680-112">The notification channel URI is returned by Windows to your app.</span></span>
4.  <span data-ttu-id="87680-113">アプリから独自のクラウド サービスに URI を送ります。</span><span class="sxs-lookup"><span data-stu-id="87680-113">Your app sends the URI to your own cloud service.</span></span> <span data-ttu-id="87680-114">その後で、URI をユーザー独自のクラウド サービスに保存し、通知を送るときに URI にアクセスできるようにします。</span><span class="sxs-lookup"><span data-stu-id="87680-114">You then store the URI on your own cloud service so that you can access the URI when you send notifications.</span></span> <span data-ttu-id="87680-115">この URI は、独自のアプリと独自のサービスの間のインターフェイスです。このインターフェイスは、セキュリティで保護された安全な Web 標準に従って実装する必要があります。</span><span class="sxs-lookup"><span data-stu-id="87680-115">The URI is an interface between your own app and your own service; it's your responsibility to implement this interface with safe and secure web standards.</span></span>
5.  <span data-ttu-id="87680-116">送られる更新情報がクラウド サービスにある場合、チャネルの URI を使って WNS に通知されます。</span><span class="sxs-lookup"><span data-stu-id="87680-116">When your cloud service has an update to send, it notifies WNS using the channel URI.</span></span> <span data-ttu-id="87680-117">この処理では、通知ペイロードを含む HTTP POST 要求が Secure Sockets Layer (SSL) 経由で発行されます。</span><span class="sxs-lookup"><span data-stu-id="87680-117">This is done by issuing an HTTP POST request, including the notification payload, over Secure Sockets Layer (SSL).</span></span> <span data-ttu-id="87680-118">この手順では認証が必要になります。</span><span class="sxs-lookup"><span data-stu-id="87680-118">This step requires authentication.</span></span>
6.  <span data-ttu-id="87680-119">WNS が要求を受け取り、適切なデバイスに通知をルーティングします。</span><span class="sxs-lookup"><span data-stu-id="87680-119">WNS receives the request and routes the notification to the appropriate device.</span></span>

![プッシュ通知の WNS データ フローの図](images/wns-diagram-01.png)

## <a name="registering-your-app-and-receiving-the-credentials-for-your-cloud-service"></a><span data-ttu-id="87680-121">アプリの登録とクラウド サービスの資格情報の取得</span><span class="sxs-lookup"><span data-stu-id="87680-121">Registering your app and receiving the credentials for your cloud service</span></span>


<span data-ttu-id="87680-122">WNS を使って通知を送るには、アプリをストア ダッシュボードに登録しておく必要があります。</span><span class="sxs-lookup"><span data-stu-id="87680-122">Before you can send notifications using WNS, your app must be registered with the Store Dashboard.</span></span> <span data-ttu-id="87680-123">これにより、WNS に対する認証を行うときにクラウド サービスで使うアプリの資格情報が提供されます。</span><span class="sxs-lookup"><span data-stu-id="87680-123">This will provide you with credentials for your app that your cloud service will use in authenticating with WNS.</span></span> <span data-ttu-id="87680-124">これらの資格情報は、パッケージ セキュリティ識別子 (SID) と秘密鍵で構成されます。</span><span class="sxs-lookup"><span data-stu-id="87680-124">These credentials consist of a Package Security Identifier (SID) and a secret key.</span></span> <span data-ttu-id="87680-125">この登録を行うには、[Windows デベロッパー センター](http://go.microsoft.com/fwlink/p/?linkid=511146)にアクセスし、**ダッシュボード**をクリックします。</span><span class="sxs-lookup"><span data-stu-id="87680-125">To perform this registration, go to the [Windows Dev Center](http://go.microsoft.com/fwlink/p/?linkid=511146) and select **Dashboard**.</span></span> <span data-ttu-id="87680-126">アプリの作成後、**[アプリの管理 - WNS/MPNS]** のページの手順に従って、認証情報を取得できます。</span><span class="sxs-lookup"><span data-stu-id="87680-126">After you create your app, you can retrieve the credentials by following the instructions on the **App Management - WNS/MPNS** page.</span></span> <span data-ttu-id="87680-127">Live サービス ソリューションを使用する場合は、このページの **Live サービス サイト**のリンクにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="87680-127">If you want to use the Live Services solution, follow the **Live services site** link on this page.</span></span>

<span data-ttu-id="87680-128">アプリにはそれぞれ、クラウド サービスの独自の資格情報が割り当てられます。</span><span class="sxs-lookup"><span data-stu-id="87680-128">Each app has its own set of credentials for its cloud service.</span></span> <span data-ttu-id="87680-129">これらの資格情報を使って他のアプリに通知を送ることはできません。</span><span class="sxs-lookup"><span data-stu-id="87680-129">These credentials cannot be used to send notifications to any other app.</span></span>

<span data-ttu-id="87680-130">アプリの登録方法について詳しくは、「[Windows 通知サービス (WNS) に対して認証する方法](https://msdn.microsoft.com/library/windows/apps/hh465407)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="87680-130">For more details on how to register your app, please see [How to authenticate with the Windows Notification Service (WNS)](https://msdn.microsoft.com/library/windows/apps/hh465407).</span></span>

## <a name="requesting-a-notification-channel"></a><span data-ttu-id="87680-131">通知チャネルの要求</span><span class="sxs-lookup"><span data-stu-id="87680-131">Requesting a notification channel</span></span>


<span data-ttu-id="87680-132">プッシュ通知を受け取ることができるアプリを実行するときは、最初に [**CreatePushNotificationChannelForApplicationAsync**](https://docs.microsoft.com/uwp/api/Windows.Networking.PushNotifications.PushNotificationChannelManager#Windows_Networking_PushNotifications_PushNotificationChannelManager_CreatePushNotificationChannelForApplicationAsync_System_String_) を使って通知チャネルを要求する必要があります。</span><span class="sxs-lookup"><span data-stu-id="87680-132">When an app that is capable of receiving push notifications runs, it must first request a notification channel through the [**CreatePushNotificationChannelForApplicationAsync**](https://docs.microsoft.com/uwp/api/Windows.Networking.PushNotifications.PushNotificationChannelManager#Windows_Networking_PushNotifications_PushNotificationChannelManager_CreatePushNotificationChannelForApplicationAsync_System_String_).</span></span> <span data-ttu-id="87680-133">詳しい説明とコード例については、「[通知チャネルを要求、作成、保存する方法](https://msdn.microsoft.com/library/windows/apps/hh465412)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="87680-133">For a full discussion and example code, see [How to request, create, and save a notification channel](https://msdn.microsoft.com/library/windows/apps/hh465412).</span></span> <span data-ttu-id="87680-134">この API から返されるチャネルの URI は、呼び出し元のアプリケーションとそのタイルに一意にリンクされます。これには送信可能なすべての種類の通知が使われます。</span><span class="sxs-lookup"><span data-stu-id="87680-134">This API returns a channel URI that is uniquely linked to the calling application and its tile, and through which all notification types can be sent.</span></span>

<span data-ttu-id="87680-135">アプリでは、チャネルの URI の作成が正常に完了すると、その URI に関連付けられるアプリ固有のメタデータと一緒にクラウド サービスに送ります。</span><span class="sxs-lookup"><span data-stu-id="87680-135">After the app has successfully created a channel URI, it sends it to its cloud service, together with any app-specific metadata that should be associated with this URI.</span></span>

### <a name="important-notes"></a><span data-ttu-id="87680-136">重要な注意</span><span class="sxs-lookup"><span data-stu-id="87680-136">Important notes</span></span>

-   <span data-ttu-id="87680-137">アプリの通知チャネルの URI は、常に同じであるとは限りません。</span><span class="sxs-lookup"><span data-stu-id="87680-137">We do not guarantee that the notification channel URI for an app will always remain the same.</span></span> <span data-ttu-id="87680-138">アプリを実行するたびに新しいチャネルを要求し、URI が変更されたらサービスを更新することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="87680-138">We advise that the app requests a new channel every time it runs and updates its service when the URI changes.</span></span> <span data-ttu-id="87680-139">チャネルの URI の文字列はブラック ボックスと見なし、変更しないようにしてください。</span><span class="sxs-lookup"><span data-stu-id="87680-139">The developer should never modify the channel URI and should consider it as a black-box string.</span></span> <span data-ttu-id="87680-140">現時点で、チャネルの URI は 30 日が経過すると有効期限切れになります。</span><span class="sxs-lookup"><span data-stu-id="87680-140">At this time, channel URIs expire after 30 days.</span></span> <span data-ttu-id="87680-141">場合は、windows 10 アプリを定期的に更新、バック グラウンドでそのチャネル Windows8.1[プッシュ通知と定期的な通知のサンプル](http://go.microsoft.com/fwlink/p/?linkid=231476)をダウンロードして、ソース コードやパターンを示してを再利用することができます。</span><span class="sxs-lookup"><span data-stu-id="87680-141">If your Windows10 app will periodically renew its channel in the background then you can download the [Push and periodic notifications sample](http://go.microsoft.com/fwlink/p/?linkid=231476) for Windows8.1 and re-use its source code and/or the pattern it demonstrates.</span></span>
-   <span data-ttu-id="87680-142">クラウド サービスとクライアント アプリの間のインターフェイスは開発者が実装します。</span><span class="sxs-lookup"><span data-stu-id="87680-142">The interface between the cloud service and the client app is implemented by you, the developer.</span></span> <span data-ttu-id="87680-143">独自のサービスに対するアプリの認証プロセスでは、データの送信に HTTPS などのセキュリティで保護されたプロトコルを使うことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="87680-143">We recommend that the app go through an authentication process with its own service and transmit data over a secure protocol such as HTTPS.</span></span>
-   <span data-ttu-id="87680-144">クラウド サービスでは、チャネルの URI で必ず "notify.windows.com" ドメインを使うことが重要です。</span><span class="sxs-lookup"><span data-stu-id="87680-144">It is important that the cloud service always ensures that the channel URI uses the domain "notify.windows.com".</span></span> <span data-ttu-id="87680-145">他のドメインのチャネルに通知をプッシュしないでください。</span><span class="sxs-lookup"><span data-stu-id="87680-145">The service should never push notifications to a channel on any other domain.</span></span> <span data-ttu-id="87680-146">アプリのコールバックが侵害された場合、悪意のある攻撃者によってチャネルの URI が送信され、WNS がなりすまされるおそれがあります。</span><span class="sxs-lookup"><span data-stu-id="87680-146">If the callback for your app is ever compromised, a malicious attacker could submit a channel URI to spoof WNS.</span></span> <span data-ttu-id="87680-147">ドメインを調べないと、そのような攻撃者に対して、気付かないうちに情報を開示してしまう可能性があります。</span><span class="sxs-lookup"><span data-stu-id="87680-147">Without inspecting the domain, your cloud service could be potentially disclose information to this attacker unknowingly.</span></span>
-   <span data-ttu-id="87680-148">クラウド サービスが期限切れのチャネルに通知を配信しようとすると、WNS は[応答コード 410](https://msdn.microsoft.com/library/windows/apps/hh465435.aspx#WNSResponseCodes) を返します。</span><span class="sxs-lookup"><span data-stu-id="87680-148">If your cloud service attempts to deliver a notification to an expired channel, WNS will return [response code 410](https://msdn.microsoft.com/library/windows/apps/hh465435.aspx#WNSResponseCodes).</span></span> <span data-ttu-id="87680-149">このコードを受け取った後、サービスはその URI に対して通知を送らないようにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="87680-149">In response to that code, your service should no longer attempt to send notifications to that URI.</span></span>

## <a name="authenticating-your-cloud-service"></a><span data-ttu-id="87680-150">クラウド サービスの認証</span><span class="sxs-lookup"><span data-stu-id="87680-150">Authenticating your cloud service</span></span>


<span data-ttu-id="87680-151">通知を送るには、クラウド サービスが WNS に認証される必要があります。</span><span class="sxs-lookup"><span data-stu-id="87680-151">To send a notification, the cloud service must be authenticated through WNS.</span></span> <span data-ttu-id="87680-152">そのためには、まず、アプリを Microsoft Store のダッシュボードに登録します。</span><span class="sxs-lookup"><span data-stu-id="87680-152">The first step in this process occurs when you register your app with the Microsoft Store Dashboard.</span></span> <span data-ttu-id="87680-153">この登録プロセスで、アプリにパッケージ セキュリティ識別子 (SID) と秘密鍵が割り当てられます。</span><span class="sxs-lookup"><span data-stu-id="87680-153">During the registration process, your app is given a Package security identifier (SID) and a secret key.</span></span> <span data-ttu-id="87680-154">クラウド サービスでは、この情報を使って WNS に対する認証を行います。</span><span class="sxs-lookup"><span data-stu-id="87680-154">This information is used by your cloud service to authenticate with WNS.</span></span>

<span data-ttu-id="87680-155">WNS の認証方式は、[OAuth 2.0](http://go.microsoft.com/fwlink/p/?linkid=226787) プロトコルのクライアント資格情報のプロファイルを使って実装されます。</span><span class="sxs-lookup"><span data-stu-id="87680-155">The WNS authentication scheme is implemented using the client credentials profile from the [OAuth 2.0](http://go.microsoft.com/fwlink/p/?linkid=226787) protocol.</span></span> <span data-ttu-id="87680-156">資格情報 (パッケージ SID と秘密鍵) を指定して、WNS に対してクラウド サービスの認証を行うと、</span><span class="sxs-lookup"><span data-stu-id="87680-156">The cloud service authenticates with WNS by providing its credentials (Package SID and secret key).</span></span> <span data-ttu-id="87680-157">アクセス トークンを受け取ります。</span><span class="sxs-lookup"><span data-stu-id="87680-157">In return, it receives an access token.</span></span> <span data-ttu-id="87680-158">このアクセス トークンを使って、クラウド サービスで通知を送ることができます。</span><span class="sxs-lookup"><span data-stu-id="87680-158">This access token allows a cloud service to send a notification.</span></span> <span data-ttu-id="87680-159">このトークンは、WNS に送るすべての通知要求で必要になります。</span><span class="sxs-lookup"><span data-stu-id="87680-159">The token is required with every notification request sent to the WNS.</span></span>

<span data-ttu-id="87680-160">大まかな情報の流れを次に示します。</span><span class="sxs-lookup"><span data-stu-id="87680-160">At a high level, the information chain is as follows:</span></span>

1.  <span data-ttu-id="87680-161">クラウド サービスから WNS に、OAuth 2.0 プロトコルに従って HTTPS 経由で資格情報が送られます。</span><span class="sxs-lookup"><span data-stu-id="87680-161">The cloud service sends its credentials to WNS over HTTPS following the OAuth 2.0 protocol.</span></span> <span data-ttu-id="87680-162">これにより、WNS でサービスが認証されます。</span><span class="sxs-lookup"><span data-stu-id="87680-162">This authenticates the service with WNS.</span></span>
2.  <span data-ttu-id="87680-163">認証に成功すると、WNS からアクセス トークンが返されます。</span><span class="sxs-lookup"><span data-stu-id="87680-163">WNS returns an access token if the authentication was successful.</span></span> <span data-ttu-id="87680-164">このアクセス トークンを、有効期限切れになるまで以降のすべての通知要求で使います。</span><span class="sxs-lookup"><span data-stu-id="87680-164">This access token is used in all subsequent notification requests until it expires.</span></span>

![クラウド サービス認証の WNS の図](images/wns-diagram-02.png)

<span data-ttu-id="87680-166">WNS に対する認証では、クラウド サービスからの HTTP 要求の送信に Secure Sockets Layer (SSL) を使います。</span><span class="sxs-lookup"><span data-stu-id="87680-166">In the authentication with WNS, the cloud service submits an HTTP request over Secure Sockets Layer (SSL).</span></span> <span data-ttu-id="87680-167">パラメーターの形式は "application/x-www-for-urlencoded" です。</span><span class="sxs-lookup"><span data-stu-id="87680-167">The parameters are supplied in the "application/x-www-for-urlencoded" format.</span></span> <span data-ttu-id="87680-168">"client\_id" フィールドにパッケージ SID を指定し、"client\_secret" フィールドに秘密鍵を指定します。</span><span class="sxs-lookup"><span data-stu-id="87680-168">Supply your Package SID in the "client\_id" field and your secret key in the "client\_secret" field.</span></span> <span data-ttu-id="87680-169">構文について詳しくは、[アクセス トークン要求](https://msdn.microsoft.com/library/windows/apps/hh465435.aspx#access_token_request)のリファレンスをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="87680-169">For syntax details, see the [access token request](https://msdn.microsoft.com/library/windows/apps/hh465435.aspx#access_token_request) reference.</span></span>

<span data-ttu-id="87680-170">**注:** これは、例、独自のコードで使用できる正常にない切り取り、貼り付けコードだけです。</span><span class="sxs-lookup"><span data-stu-id="87680-170">**Note**This is just an example, not cut-and-paste code that you can successfully use in your own code.</span></span>

 

``` http
 POST /accesstoken.srf HTTP/1.1
 Content-Type: application/x-www-form-urlencoded
 Host: https://login.live.com
 Content-Length: 211
 
 grant_type=client_credentials&client_id=ms-app%3a%2f%2fS-1-15-2-2972962901-2322836549-3722629029-1345238579-3987825745-2155616079-650196962&client_secret=Vex8L9WOFZuj95euaLrvSH7XyoDhLJc7&scope=notify.windows.com
```

<span data-ttu-id="87680-171">WNS はクラウド サービスを認証し、成功した場合、"200 OK" という応答を送ります。</span><span class="sxs-lookup"><span data-stu-id="87680-171">The WNS authenticates the cloud service and, if successful, sends a response of "200 OK".</span></span> <span data-ttu-id="87680-172">アクセス トークンは、"application/json" メディア タイプを使って、HTTP 応答の本文に含まれるパラメーターで返されます。</span><span class="sxs-lookup"><span data-stu-id="87680-172">The access token is returned in the parameters included in the body of the HTTP response, using the "application/json" media type.</span></span> <span data-ttu-id="87680-173">アクセス トークンを受け取ると、通知を送ることができるようになります。</span><span class="sxs-lookup"><span data-stu-id="87680-173">After your service has received the access token, you are ready to send notifications.</span></span>

<span data-ttu-id="87680-174">次の例は、アクセス トークンを含む認証成功時の応答を示しています。</span><span class="sxs-lookup"><span data-stu-id="87680-174">The following example shows a successful authentication response, including the access token.</span></span> <span data-ttu-id="87680-175">構文について詳しくは、「[プッシュ通知サービスの要求ヘッダーと応答ヘッダー](https://msdn.microsoft.com/library/windows/apps/hh465435)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="87680-175">For syntax details, see [Push notification service request and response headers](https://msdn.microsoft.com/library/windows/apps/hh465435).</span></span>

``` http
 HTTP/1.1 200 OK   
 Cache-Control: no-store
 Content-Length: 422
 Content-Type: application/json
 
 {
     "access_token":"EgAcAQMAAAAALYAAY/c+Huwi3Fv4Ck10UrKNmtxRO6Njk2MgA=", 
     "token_type":"bearer"
 }
```

### <a name="important-notes"></a><span data-ttu-id="87680-176">重要な注意</span><span class="sxs-lookup"><span data-stu-id="87680-176">Important notes</span></span>

-   <span data-ttu-id="87680-177">この手順でサポートされる OAuth 2.0 プロトコルは、草案の第 16 版に準拠したものです。</span><span class="sxs-lookup"><span data-stu-id="87680-177">The OAuth 2.0 protocol supported in this procedure follows draft version V16.</span></span>
-   <span data-ttu-id="87680-178">OAuth の Request for Comments (RFC) では、クラウド サービスのことを "クライアント" と表現しています。</span><span class="sxs-lookup"><span data-stu-id="87680-178">The OAuth Request for Comments (RFC) uses the term "client" to refer to the cloud service.</span></span>
-   <span data-ttu-id="87680-179">この手順は、OAuth の草案が完成したときに変更される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="87680-179">There might be changes to this procedure when the OAuth draft is finalized.</span></span>
-   <span data-ttu-id="87680-180">アクセス トークンは、複数の通知要求に再利用できます。</span><span class="sxs-lookup"><span data-stu-id="87680-180">The access token can be reused for multiple notification requests.</span></span> <span data-ttu-id="87680-181">そのため、クラウド サービスを 1 回認証するだけで、複数の通知を送ることができます。</span><span class="sxs-lookup"><span data-stu-id="87680-181">This allows the cloud service to authenticate just once to send many notifications.</span></span> <span data-ttu-id="87680-182">ただし、アクセス トークンの有効期限が切れた場合は、認証をもう一度行って新しいアクセス トークンを受け取る必要があります。</span><span class="sxs-lookup"><span data-stu-id="87680-182">However, when the access token expires, the cloud service must authenticate again to receive a new access token.</span></span>

## <a name="sending-a-notification"></a><span data-ttu-id="87680-183">通知の送信</span><span class="sxs-lookup"><span data-stu-id="87680-183">Sending a notification</span></span>


<span data-ttu-id="87680-184">クラウド サービスにユーザー向けの更新があるときは、チャネルの URI を使って通知を送ることができます。</span><span class="sxs-lookup"><span data-stu-id="87680-184">Using the channel URI, the cloud service can send a notification whenever it has an update for the user.</span></span>

<span data-ttu-id="87680-185">既に説明したように、アクセス トークンは複数の通知要求に再利用できます。そのため、通知のたびに新しいアクセス トークンを要求する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="87680-185">The access token described above can be reused for multiple notification requests; the cloud server is not required to request a new access token for every notification.</span></span> <span data-ttu-id="87680-186">アクセス トークンの有効期限が切れると、通知要求でエラーが返されます。</span><span class="sxs-lookup"><span data-stu-id="87680-186">If the access token has expired, the notification request will return an error.</span></span> <span data-ttu-id="87680-187">アクセス トークンが拒否されたときに通知の送信を何度も再試行しないようにしてください。</span><span class="sxs-lookup"><span data-stu-id="87680-187">We recommended that you do not try to re-send your notification more than once if the access token is rejected.</span></span> <span data-ttu-id="87680-188">このエラーが発生した場合は、新しいアクセス トークンを要求して通知を再送する必要があります。</span><span class="sxs-lookup"><span data-stu-id="87680-188">If you encounter this error, you will need to request a new access token and resend the notification.</span></span> <span data-ttu-id="87680-189">具体的なエラー コードについては、「[プッシュ通知の応答コード](https://msdn.microsoft.com/library/windows/apps/hh465435)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="87680-189">For the exact error code, see [Push notification response codes](https://msdn.microsoft.com/library/windows/apps/hh465435).</span></span>

1.  <span data-ttu-id="87680-190">クラウド サービスで、チャネルの URI に対する HTTP POST 要求を行います。</span><span class="sxs-lookup"><span data-stu-id="87680-190">The cloud service makes an HTTP POST to the channel URI.</span></span> <span data-ttu-id="87680-191">この要求は SSL 経由で行う必要があります。要求には、必要なヘッダーと通知のペイロードが含まれます。</span><span class="sxs-lookup"><span data-stu-id="87680-191">This request must be made over SSL and contains the necessary headers and the notification payload.</span></span> <span data-ttu-id="87680-192">承認用に取得したアクセス トークンを承認ヘッダーに含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="87680-192">The authorization header must include the acquired access token for authorization.</span></span>

    <span data-ttu-id="87680-193">要求の例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="87680-193">An example request is shown here.</span></span> <span data-ttu-id="87680-194">構文について詳しくは、「[プッシュ通知の応答コード](https://msdn.microsoft.com/library/windows/apps/hh465435)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="87680-194">For syntax details, see [Push notification response codes](https://msdn.microsoft.com/library/windows/apps/hh465435).</span></span>

    <span data-ttu-id="87680-195">通知のペイロードの構成について詳しくは、「[クイック スタート: プッシュ通知の送信](https://msdn.microsoft.com/library/windows/apps/xaml/hh868252)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="87680-195">For details on composing the notification payload, see [Quickstart: Sending a push notification](https://msdn.microsoft.com/library/windows/apps/xaml/hh868252).</span></span> <span data-ttu-id="87680-196">タイル、トースト、またはバッジのプッシュ通知のペイロードは、それぞれの定義済み[アダプティブ タイル スキーマ](adaptive-tiles-schema.md)または[レガシ タイル スキーマ](https://msdn.microsoft.com/library/windows/apps/br212853)に準拠した XML コンテンツとして提供されます。</span><span class="sxs-lookup"><span data-stu-id="87680-196">The payload of a tile, toast, or badge push notification is supplied as XML content that adheres to their respective defined [Adaptive tiles schema](adaptive-tiles-schema.md) or [Legacy tiles schema](https://msdn.microsoft.com/library/windows/apps/br212853).</span></span> <span data-ttu-id="87680-197">直接通知のペイロードには、指定された構造体はありません。</span><span class="sxs-lookup"><span data-stu-id="87680-197">The payload of a raw notification does not have a specified structure.</span></span> <span data-ttu-id="87680-198">これは、アプリによって厳密に定義されます。</span><span class="sxs-lookup"><span data-stu-id="87680-198">It is strictly app-defined.</span></span>

    ``` http
     POST https://cloud.notify.windows.com/?token=AQE%bU%2fSjZOCvRjjpILow%3d%3d HTTP/1.1
     Content-Type: text/xml
     X-WNS-Type: wns/tile
     Authorization: Bearer EgAcAQMAAAAALYAAY/c+Huwi3Fv4Ck10UrKNmtxRO6Njk2MgA=
     Host: cloud.notify.windows.com
     Content-Length: 24

     <body>
     ....
    ```

2.  <span data-ttu-id="87680-199">WNS から、受け取った通知を次回の配信時に送ることを示す応答を受け取ります。</span><span class="sxs-lookup"><span data-stu-id="87680-199">WNS responds to indicate that the notification has been received and will be delivered at the next available opportunity.</span></span> <span data-ttu-id="87680-200">ただし、WNS では、デバイスやアプリケーションで通知を受け取ったかどうかに関するエンド ツー エンドの確認は行われません。</span><span class="sxs-lookup"><span data-stu-id="87680-200">However, WNS does not provide end-to-end confirmation that your notification has been received by the device or application.</span></span>

<span data-ttu-id="87680-201">次の図はデータ フローを示しています。</span><span class="sxs-lookup"><span data-stu-id="87680-201">This diagram illustrates the data flow:</span></span>

![通知送信の WNS の図](images/wns-diagram-03.png)

### <a name="important-notes"></a><span data-ttu-id="87680-203">重要な注意</span><span class="sxs-lookup"><span data-stu-id="87680-203">Important notes</span></span>

-   <span data-ttu-id="87680-204">WNS では、通知の信頼性や待機時間については保証されません。</span><span class="sxs-lookup"><span data-stu-id="87680-204">WNS does not guarantee the reliability or latency of a notification.</span></span>
-   <span data-ttu-id="87680-205">機密データや重要なデータは通知に含めないでください。</span><span class="sxs-lookup"><span data-stu-id="87680-205">Notifications should never include confidential or sensitive data.</span></span>
-   <span data-ttu-id="87680-206">通知を送るには、事前に WNS に対してクラウド サービスを認証し、アクセス トークンを受け取る必要があります。</span><span class="sxs-lookup"><span data-stu-id="87680-206">To send a notification, the cloud service must first authenticate with WNS and receive an access token.</span></span>
-   <span data-ttu-id="87680-207">アクセス トークンを使用する場合、クラウド サービスはそのトークンが作成された単一のアプリに対してのみ通知を送信できます。</span><span class="sxs-lookup"><span data-stu-id="87680-207">An access token only allows a cloud service to send notifications to the single app for which the token was created.</span></span> <span data-ttu-id="87680-208">1 つのアクセス トークンで複数のアプリに通知を送ることはできません。</span><span class="sxs-lookup"><span data-stu-id="87680-208">One access token cannot be used to send notifications across multiple apps.</span></span> <span data-ttu-id="87680-209">そのため、クラウド サービスで複数のアプリをサポートしている場合は、それぞれのチャネルの URI に通知をプッシュするときに、該当するアプリの正しいアクセス トークンを指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="87680-209">Therefore, if your cloud service supports multiple apps, it must provide the correct access token for the app when pushing a notification to each channel URI.</span></span>
-   <span data-ttu-id="87680-210">デバイスがオフラインの場合、WNS では既定で、チャネル URI ごとに最大 5 つ (キューが有効になっていない場合は 1 つ) のタイル通知と 1 つのバッジ通知が保存されます。直接通知は保存されません。</span><span class="sxs-lookup"><span data-stu-id="87680-210">When the device is offline, by default WNS will store up to five tile notifications (if queuing is enabled; otherwise, one tile notification) and one badge notification for each channel URI, and no raw notifications.</span></span> <span data-ttu-id="87680-211">この既定のキャッシュ処理は、[X-WNS-Cache-Policy ヘッダー](https://msdn.microsoft.com/library/windows/apps/hh465435.aspx#pncodes_x_wns_cache)を使って変更することができます。</span><span class="sxs-lookup"><span data-stu-id="87680-211">This default caching behavior can be changed through the [X-WNS-Cache-Policy header](https://msdn.microsoft.com/library/windows/apps/hh465435.aspx#pncodes_x_wns_cache).</span></span> <span data-ttu-id="87680-212">デバイスがオフラインである場合、トースト通知は保存されませんので注意してください。</span><span class="sxs-lookup"><span data-stu-id="87680-212">Note that toast notifications are never stored when the device is offline.</span></span>
-   <span data-ttu-id="87680-213">通知の内容がユーザーごとに異なる場合、WNS では、クラウド サービスでそれらの更新を受け取ったら、それらを直ちに送るように推奨されています。</span><span class="sxs-lookup"><span data-stu-id="87680-213">In scenarios where the notification content is personalized to the user, WNS recommends that the cloud service immediately send those updates when those are received.</span></span> <span data-ttu-id="87680-214">これには、たとえば、ソーシャル メディアのフィードの更新、即座の通知への招待、新しいメッセージの通知、アラートなどが該当します。</span><span class="sxs-lookup"><span data-stu-id="87680-214">Examples of this scenario include social media feed updates, instant communication invitations, new message notifications, or alerts.</span></span> <span data-ttu-id="87680-215">また、天気、株価情報、ニュースの更新など、多くのユーザーに同じ更新を頻繁に配信する場合もあります。</span><span class="sxs-lookup"><span data-stu-id="87680-215">As an alternative, you can have scenarios in which the same generic update is frequently delivered to a large subset of your users; for example, weather, stock, and news updates.</span></span> <span data-ttu-id="87680-216">WNS のガイドラインでは、それらの更新頻度を 30 分に 1 回までにするように規定されています。</span><span class="sxs-lookup"><span data-stu-id="87680-216">WNS guidelines specify that the frequency of these updates should be at most one every 30 minutes.</span></span> <span data-ttu-id="87680-217">それよりも頻繁に更新を配信すると、エンド ユーザーや WNS に不正な通知と見なされる場合があります。</span><span class="sxs-lookup"><span data-stu-id="87680-217">The end user or WNS may determine more frequent routine updates to be abusive.</span></span>

## <a name="expiration-of-tile-and-badge-notifications"></a><span data-ttu-id="87680-218">タイル通知とバッジ通知の有効期限</span><span class="sxs-lookup"><span data-stu-id="87680-218">Expiration of tile and badge notifications</span></span>


<span data-ttu-id="87680-219">既定では、タイル通知とバッジ通知は、ダウンロードされたときから 3 日後に有効期限切れになります。</span><span class="sxs-lookup"><span data-stu-id="87680-219">By default, tile and badge notifications expire three days after being downloaded.</span></span> <span data-ttu-id="87680-220">通知の有効期限が切れると、タイルまたはキューからコンテンツが削除され、ユーザーに表示されなくなります。</span><span class="sxs-lookup"><span data-stu-id="87680-220">When a notification expires, the content is removed from the tile or queue and is no longer shown to the user.</span></span> <span data-ttu-id="87680-221">すべてのタイル通知とバッジ通知には、アプリにとって適切な時間を使って有効期限を設定し、タイルのコンテンツの意味がなくなっても保持されないようにすることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="87680-221">It's a best practice to set an expiration (using a time that makes sense for your app) on all tile and badge notifications so that your tile's content doesn't persist longer than it is relevant.</span></span> <span data-ttu-id="87680-222">明示的な有効期限は、コンテンツの存続期間が決まっている場合に重要です。</span><span class="sxs-lookup"><span data-stu-id="87680-222">An explicit expiration time is essential for content with a defined lifespan.</span></span> <span data-ttu-id="87680-223">また、クラウド サービスによる通知の送信が停止した場合や、ユーザーがネットワークに長時間接続していない場合に、古いコンテンツを確実に削除することができます。</span><span class="sxs-lookup"><span data-stu-id="87680-223">This also assures the removal of stale content if your cloud service stops sending notifications, or if the user disconnects from the network for an extended period.</span></span>

<span data-ttu-id="87680-224">クラウド サービスでは、送信後の通知が有効である時間を秒単位で指定する X-WNS-TTL HTTP ヘッダーを設定することで、通知ごとに有効期限を設定できます。</span><span class="sxs-lookup"><span data-stu-id="87680-224">Your cloud service can set an expiration for each notification by setting the X-WNS-TTL HTTP header to specify the time (in seconds) that your notification will remain valid after it is sent.</span></span> <span data-ttu-id="87680-225">詳しくは、「[プッシュ通知サービスの要求ヘッダーと応答ヘッダー](https://msdn.microsoft.com/library/windows/apps/hh465435.aspx#pncodes_x_wns_ttl)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="87680-225">For more information, see [Push notification service request and response headers](https://msdn.microsoft.com/library/windows/apps/hh465435.aspx#pncodes_x_wns_ttl).</span></span>

<span data-ttu-id="87680-226">たとえば、株式市場の取引が活発な日は、株価の更新の有効期限を送信間隔の有効期限の 2 倍に設定することをお勧めします (30 分ごとに通知を送っている場合は有効期限を受け取り後 1 時間にするなど)。</span><span class="sxs-lookup"><span data-stu-id="87680-226">For example, during a stock market's active trading day, you can set the expiration for a stock price update to twice that of your sending interval (such as one hour after receipt if you are sending notifications every half-hour).</span></span> <span data-ttu-id="87680-227">また、ニュース アプリの場合、毎日のニュースを表示するタイルの更新の有効期限は 1 日が適しています。</span><span class="sxs-lookup"><span data-stu-id="87680-227">As another example, a news app might determine that one day is an appropriate expiration time for a daily news tile update.</span></span>

## <a name="push-notifications-and-battery-saver"></a><span data-ttu-id="87680-228">プッシュ通知とバッテリー セーバー</span><span class="sxs-lookup"><span data-stu-id="87680-228">Push notifications and battery saver</span></span>


<span data-ttu-id="87680-229">バッテリー セーバーは、デバイスでのバックグラウンド アクティビティを制限することでバッテリーの寿命を延ばします。</span><span class="sxs-lookup"><span data-stu-id="87680-229">Battery saver extends battery life by limiting background activity on the device.</span></span> <span data-ttu-id="87680-230">Windows 10 では、ユーザーがバッテリが指定したしきい値を下回ったときに自動的にオンにする、バッテリー節約機能を設定できます。</span><span class="sxs-lookup"><span data-stu-id="87680-230">Windows10 lets the user set battery saver to turn on automatically when the battery drops below a specified threshold.</span></span> <span data-ttu-id="87680-231">バッテリー セーバーがオンのときは、電力を節約するため、プッシュ通知の受信は無効になります。</span><span class="sxs-lookup"><span data-stu-id="87680-231">When battery saver is on, the receipt of push notifications is disabled to save energy.</span></span> <span data-ttu-id="87680-232">ただし、これにはいくつかの例外があります。</span><span class="sxs-lookup"><span data-stu-id="87680-232">But there are a couple exceptions to this.</span></span> <span data-ttu-id="87680-233">(、**設定**アプリが見つかりません) 次の windows 10 バッテリ セーバー設定では、アプリがバッテリー セーバーがオンにしている場合でも、プッシュ通知を受信できるようにします。</span><span class="sxs-lookup"><span data-stu-id="87680-233">The following Windows10 battery saver settings (found in the **Settings** app) allow your app to receive push notifications even when battery saver is on.</span></span>

-   <span data-ttu-id="87680-234">**[バッテリー節約機能がオンのときも、すべてのアプリケーションからのプッシュ通知を許可する]**: この設定では、バッテリー節約機能がオンになっているときでも、すべてのアプリがプッシュ通知を受け取ることができます。</span><span class="sxs-lookup"><span data-stu-id="87680-234">**Allow push notifications from any app while in battery saver**: This setting lets all apps receive push notifications while battery saver is on.</span></span> <span data-ttu-id="87680-235">この設定が windows 10 デスクトップ エディション (Home、Pro、Enterprise、および Education) にのみ適用されることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="87680-235">Note that this setting applies only to Windows10 for desktop editions (Home, Pro, Enterprise, and Education).</span></span>
-   <span data-ttu-id="87680-236">**[常に許可]**: この設定では、バッテリー節約機能がオンになっているときでも、プッシュ通知の受け取りを含めて、バックグラウンドで特定のアプリを実行できます。</span><span class="sxs-lookup"><span data-stu-id="87680-236">**Always allowed**: This setting lets specific apps run in the background while battery saver is on - including receiving push notifications.</span></span> <span data-ttu-id="87680-237">この一覧は、ユーザーによって手動で管理されます。</span><span class="sxs-lookup"><span data-stu-id="87680-237">This list is maintained manually by the user.</span></span>

<span data-ttu-id="87680-238">これら 2 つの設定の状態を確認する方法はありませんが、バッテリ セーバーの状態を確認することはできます。</span><span class="sxs-lookup"><span data-stu-id="87680-238">There is no way to check the state of these two settings, but you can check the state of battery saver.</span></span> <span data-ttu-id="87680-239">Windows 10 には、バッテリ セーバーの状態をチェックする[**EnergySaverStatus**](https://docs.microsoft.com/uwp/api/Windows.System.Power.PowerManager.EnergySaverStatus)プロパティを使います。</span><span class="sxs-lookup"><span data-stu-id="87680-239">In Windows10, use the [**EnergySaverStatus**](https://docs.microsoft.com/uwp/api/Windows.System.Power.PowerManager.EnergySaverStatus) property to check battery saver state.</span></span> <span data-ttu-id="87680-240">アプリでは、[**EnergySaverStatusChanged**](https://docs.microsoft.com/uwp/api/Windows.System.Power.PowerManager.EnergySaverStatusChanged) イベントを使って、バッテリ セーバーの変更をリッスンすることもできます。</span><span class="sxs-lookup"><span data-stu-id="87680-240">Your app can also use the [**EnergySaverStatusChanged**](https://docs.microsoft.com/uwp/api/Windows.System.Power.PowerManager.EnergySaverStatusChanged) event to listen for changes to battery saver.</span></span>

<span data-ttu-id="87680-241">アプリがプッシュ通知を多用している場合は、バッテリ セーバーがオンの時は通知を受け取らないことをユーザーに通知し、**バッテリ セーバーの設定**を簡単に調整できるようにすることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="87680-241">If your app depends heavily on push notifications, we recommend notifying users that they may not receive notifications while battery saver is on and to make it easy for them to adjust **battery saver settings**.</span></span> <span data-ttu-id="87680-242">バッテリー節約機能設定の URI スキームを使用して、windows 10 で`ms-settings:batterysaver-settings`、設定アプリへの便利なリンクを提供することができます。</span><span class="sxs-lookup"><span data-stu-id="87680-242">Using the battery saver settings URI scheme in Windows10, `ms-settings:batterysaver-settings`, you can provide a convenient link to the Settings app.</span></span>

<span data-ttu-id="87680-243">**ヒント:**  、今後このメッセージを抑制する方法を提供することをお勧めしますバッテリ セーバーの設定に関するユーザーに通知するという場合です。</span><span class="sxs-lookup"><span data-stu-id="87680-243">**Tip** When notifying the user about battery saver settings, we recommend providing a way to suppress the message in the future.</span></span> <span data-ttu-id="87680-244">たとえば、次の例の [`dontAskMeAgainBox`] チェックボックスは、[**LocalSettings**](https://docs.microsoft.com/uwp/api/Windows.Storage.ApplicationData.LocalSettings) でユーザーの設定を保持します。</span><span class="sxs-lookup"><span data-stu-id="87680-244">For example, the `dontAskMeAgainBox` checkbox in the following example persists the user's preference in [**LocalSettings**](https://docs.microsoft.com/uwp/api/Windows.Storage.ApplicationData.LocalSettings).</span></span>

 

<span data-ttu-id="87680-245">バッテリー節約機能がオンである windows 10 で確認する方法の例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="87680-245">Here's an example of how to check if battery saver is turned on in Windows10.</span></span> <span data-ttu-id="87680-246">この例では、ユーザーに通知し、[設定] アプリを**バッテリ セーバー設定**で起動します。</span><span class="sxs-lookup"><span data-stu-id="87680-246">This example notifies the user and launches the Settings app to **battery saver settings**.</span></span> <span data-ttu-id="87680-247">`dontAskAgainSetting` により、ユーザーは再度通知を表示しないようにする場合に、メッセージを非表示にすることができます。</span><span class="sxs-lookup"><span data-stu-id="87680-247">The `dontAskAgainSetting` lets the user suppress the message if they don't want to be notified again.</span></span>

```cs
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.System;
using Windows.System.Power;
...
...
async public void CheckForEnergySaving()
{
   //Get reminder preference from LocalSettings
   bool dontAskAgain;
   var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
   object dontAskSetting = localSettings.Values["dontAskAgainSetting"];
   if (dontAskSetting == null)
   {  // Setting does not exist
      dontAskAgain = false;
   }
   else
   {  // Retrieve setting value
      dontAskAgain = Convert.ToBoolean(dontAskSetting);
   }
   
   // Check if battery saver is on and that it's okay to raise dialog
   if ((PowerManager.EnergySaverStatus == EnergySaverStatus.On)
         && (dontAskAgain == false))
   {
      // Check dialog results
      ContentDialogResult dialogResult = await saveEnergyDialog.ShowAsync();
      if (dialogResult == ContentDialogResult.Primary)
      {
         // Launch battery saver settings (settings are available only when a battery is present)
         await Launcher.LaunchUriAsync(new Uri("ms-settings:batterysaver-settings"));
      }

      // Save reminder preference
      if (dontAskAgainBox.IsChecked == true)
      {  // Don't raise dialog again
         localSettings.Values["dontAskAgainSetting"] = "true";
      }
   }
}
```

<span data-ttu-id="87680-248">これは、次の例で使われている [**ContentDialog**](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ContentDialog) の XAML です。</span><span class="sxs-lookup"><span data-stu-id="87680-248">This is the XAML for the [**ContentDialog**](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ContentDialog) featured in this example.</span></span>

```xaml
<ContentDialog x:Name="saveEnergyDialog"
               PrimaryButtonText="Open battery saver settings"
               SecondaryButtonText="Ignore"
               Title="Battery saver is on."> 
   <StackPanel>
      <TextBlock TextWrapping="WrapWholeWords">
         <LineBreak/><Run>Battery saver is on and you may 
          not receive push notifications.</Run><LineBreak/>
         <LineBreak/><Run>You can choose to allow this app to work normally
         while in battery saver, including receiving push notifications.</Run>
         <LineBreak/>
      </TextBlock>
      <CheckBox x:Name="dontAskAgainBox" Content="OK, got it."/>
   </StackPanel>
</ContentDialog>
```

## <a name="related-topics"></a><span data-ttu-id="87680-249">関連トピック</span><span class="sxs-lookup"><span data-stu-id="87680-249">Related topics</span></span>


* [<span data-ttu-id="87680-250">ローカル タイル通知の送信</span><span class="sxs-lookup"><span data-stu-id="87680-250">Send a local tile notification</span></span>](sending-a-local-tile-notification.md)
* [<span data-ttu-id="87680-251">クイック スタート: プッシュ通知の送信</span><span class="sxs-lookup"><span data-stu-id="87680-251">Quickstart: Sending a push notification</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/hh868252)
* [<span data-ttu-id="87680-252">プッシュ通知を使用してバッジを更新する方法</span><span class="sxs-lookup"><span data-stu-id="87680-252">How to update a badge through push notifications</span></span>](https://msdn.microsoft.com/library/windows/apps/hh465450)
* [<span data-ttu-id="87680-253">通知チャネルを要求、作成、保存する方法</span><span class="sxs-lookup"><span data-stu-id="87680-253">How to request, create, and save a notification channel</span></span>](https://msdn.microsoft.com/library/windows/apps/hh465412)
* [<span data-ttu-id="87680-254">実行中のアプリの通知を中断する方法</span><span class="sxs-lookup"><span data-stu-id="87680-254">How to intercept notifications for running applications</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/jj709907.aspx)
* [<span data-ttu-id="87680-255">Windows プッシュ通知サービス (WNS) に対して認証する方法</span><span class="sxs-lookup"><span data-stu-id="87680-255">How to authenticate with the Windows Push Notification Service (WNS)</span></span>](https://msdn.microsoft.com/library/windows/apps/hh465407)
* [<span data-ttu-id="87680-256">プッシュ通知サービスの要求ヘッダーと応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="87680-256">Push notification service request and response headers</span></span>](https://msdn.microsoft.com/library/windows/apps/hh465435)
* [<span data-ttu-id="87680-257">プッシュ通知のガイドラインとチェック リスト</span><span class="sxs-lookup"><span data-stu-id="87680-257">Guidelines and checklist for push notifications</span></span>](https://msdn.microsoft.com/library/windows/apps/hh761462)
* [<span data-ttu-id="87680-258">直接通知</span><span class="sxs-lookup"><span data-stu-id="87680-258">Raw notifications</span></span>](https://msdn.microsoft.com/library/windows/apps/hh761488)
 

 




