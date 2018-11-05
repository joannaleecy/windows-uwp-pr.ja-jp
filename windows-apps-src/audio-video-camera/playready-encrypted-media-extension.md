---
author: drewbatgit
ms.assetid: 79C284CA-C53A-4C24-807E-6D4CE1A29BFA
description: このセクションでは、以前の Windows8.1 バージョンから windows 10 バージョンに加えられた変更をサポートするために、PlayReady web アプリを変更する方法について説明します。
title: PlayReady の Encrypted Media Extension
ms.author: drewbat
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: b73464ea10aa835b82df17605e983ebdfb9cd890
ms.sourcegitcommit: e814a13978f33654d8e995584f4b047cb53e0aef
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/05/2018
ms.locfileid: "6036972"
---
# <a name="playready-encrypted-media-extension"></a><span data-ttu-id="bb777-104">PlayReady の Encrypted Media Extension</span><span class="sxs-lookup"><span data-stu-id="bb777-104">PlayReady Encrypted Media Extension</span></span>



<span data-ttu-id="bb777-105">このセクションでは、以前の Windows8.1 バージョンから windows 10 バージョンに加えられた変更をサポートするために、PlayReady web アプリを変更する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="bb777-105">This section describes how to modify your PlayReady web app to support the changes made from the previous Windows8.1 version to the Windows10 version.</span></span>

<span data-ttu-id="bb777-106">Internet Explorer で PlayReady メディア要素を使うと、開発者はコンテンツ プロバイダーが定義したアクセス ルールを適用しながら、ユーザーに PlayReady コンテンツを提供することのできる Web アプリを作成することができます。</span><span class="sxs-lookup"><span data-stu-id="bb777-106">Using PlayReady media elements in Internet Explorer enables developers to create web apps capable of providing PlayReady content to the user while enforcing the access rules defined by the content provider.</span></span> <span data-ttu-id="bb777-107">ここでは、HTML5 と JavaScript のみを使って、既存の Web アプリに PlayReady メディア要素を追加する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="bb777-107">This section describes how to add PlayReady media elements to your existing web apps by using only HTML5 and JavaScript.</span></span>

## <a name="whats-new-in-playready-encrypted-media-extension"></a><span data-ttu-id="bb777-108">PlayReady の Encrypted Media Extension の新機能</span><span class="sxs-lookup"><span data-stu-id="bb777-108">What's new in PlayReady Encrypted Media Extension</span></span>

<span data-ttu-id="bb777-109">このセクションでは、windows 10 で PlayReady コンテンツ保護を有効にするために、PlayReady Encrypted Media Extension (EME) を加えられた変更の一覧を示します。</span><span class="sxs-lookup"><span data-stu-id="bb777-109">This section provides a list of changes made to the PlayReady Encrypted Media Extension (EME) to enable PlayReady content protection on Windows10.</span></span>

<span data-ttu-id="bb777-110">次の一覧では、新しい機能と windows 10 の PlayReady Encrypted Media Extension に加えられた変更について説明します。</span><span class="sxs-lookup"><span data-stu-id="bb777-110">The following list describes the new features and changes made to PlayReady Encrypted Media Extension for Windows10:</span></span>

-   <span data-ttu-id="bb777-111">追加されたハードウェア デジタル著作権管理 (DRM)。</span><span class="sxs-lookup"><span data-stu-id="bb777-111">Added hardware digital rights management (DRM).</span></span>

    <span data-ttu-id="bb777-112">ハードウェア ベースのコンテンツ保護により、複数のデバイス プラットフォーム上で、高解像度 (HD) と超高解像度 (UHD) のコンテンツを安全に再生できます。</span><span class="sxs-lookup"><span data-stu-id="bb777-112">Hardware-based content protection support enables secure playback of high definition (HD) and ultra-high definition (UHD) content on multiple device platforms.</span></span> <span data-ttu-id="bb777-113">キー マテリアル (秘密キー、コンテンツ キー、これらのキーを派生またはロック解除するために使われるその他のキー マテリアルを含みます)、および暗号化解除された圧縮および非圧縮ビデオ サンプルは、ハードウェア セキュリティを利用して保護されます。</span><span class="sxs-lookup"><span data-stu-id="bb777-113">Key material (including private keys, content keys, and any other key material used to derive or unlock said keys), and decrypted compressed and uncompressed video samples are protected by leveraging hardware security.</span></span>

-   <span data-ttu-id="bb777-114">永続的でないライセンスの事前の取得を提供します。</span><span class="sxs-lookup"><span data-stu-id="bb777-114">Provides proactive acquisition of non-persistent licenses.</span></span>
-   <span data-ttu-id="bb777-115">1 つのメッセージで複数のライセンスを取得できるようにします。</span><span class="sxs-lookup"><span data-stu-id="bb777-115">Provides acquisition of multiple licenses in one message.</span></span>

    <span data-ttu-id="bb777-116">複数のキー識別子 (Keyid)、Windows8.1 に示すように PlayReady オブジェクトを使用するかと複数の Keyid [content decryption model データ (CDMData)](https://go.microsoft.com/fwlink/p/?LinkID=626819)を使用します。</span><span class="sxs-lookup"><span data-stu-id="bb777-116">You can either use a PlayReady object with multiple key identifiers (KeyIDs) as in Windows8.1, or use [content decryption model data (CDMData)](https://go.microsoft.com/fwlink/p/?LinkID=626819) with multiple KeyIDs.</span></span>

    > [!NOTE]
    > <span data-ttu-id="bb777-117">下で windows 10 では、複数のキー識別子がサポートされている&lt;KeyID&gt; CDMData にします。</span><span class="sxs-lookup"><span data-stu-id="bb777-117">In Windows10, multiple key identifiers are supported under &lt;KeyID&gt; in CDMData.</span></span>

-   <span data-ttu-id="bb777-118">リアルタイムの有効期限のサポートや期間限定ライセンス (LDL) が追加されました。</span><span class="sxs-lookup"><span data-stu-id="bb777-118">Added real time expiration support, or limited duration license (LDL).</span></span>

    <span data-ttu-id="bb777-119">ライセンスに対してリアルタイムの有効期限を設定することができます。</span><span class="sxs-lookup"><span data-stu-id="bb777-119">Provides the ability to set real-time expiration on licenses.</span></span>

-   <span data-ttu-id="bb777-120">HDCP Type 1 (バージョン 2.2) ポリシーのサポートを追加しました。</span><span class="sxs-lookup"><span data-stu-id="bb777-120">Added HDCP Type 1 (version 2.2) policy support.</span></span>
-   <span data-ttu-id="bb777-121">Miracast が暗黙的な出力となりました。</span><span class="sxs-lookup"><span data-stu-id="bb777-121">Miracast is now implicit as an output.</span></span>
-   <span data-ttu-id="bb777-122">セキュア ストップが追加されました。</span><span class="sxs-lookup"><span data-stu-id="bb777-122">Added secure stop.</span></span>

    <span data-ttu-id="bb777-123">セキュア ストップによって、特定のコンテンツについてのメディア再生が停止したメディア ストリーミング サービスに対して、PlayReady デバイスが確実にアサートするための手段が提供されます。</span><span class="sxs-lookup"><span data-stu-id="bb777-123">Secure stop provides the means for a PlayReady device to confidently assert to a media streaming service that media playback has stopped for any given piece of content.</span></span>

-   <span data-ttu-id="bb777-124">オーディオとビデオに関するライセンスの分離が追加されました。</span><span class="sxs-lookup"><span data-stu-id="bb777-124">Added audio and video license separation.</span></span>

    <span data-ttu-id="bb777-125">トラックを分離することによって、ビデオがオーディオにデコードされるのを防ぐことができます。これにより、さらに強力なコンテンツ保護が可能になります。</span><span class="sxs-lookup"><span data-stu-id="bb777-125">Separate tracks prevent video from being decoded as audio; enabling more robust content protection.</span></span> <span data-ttu-id="bb777-126">最新の標準では、オーディオ トラックと映像トラックに対して別々のキーが必要になります。</span><span class="sxs-lookup"><span data-stu-id="bb777-126">Emerging standards are requiring separate keys for audio and visual tracks.</span></span>

-   <span data-ttu-id="bb777-127">MaxResDecode が追加されました。</span><span class="sxs-lookup"><span data-stu-id="bb777-127">Added MaxResDecode.</span></span>

    <span data-ttu-id="bb777-128">この機能は、コンテンツの再生を最大解像度に制限するために追加されました (ライセンスではなく、より強力なキーを所有している場合にも制限を受けます)。</span><span class="sxs-lookup"><span data-stu-id="bb777-128">This feature was added to limit playback of content to a maximum resolution even when in possession of a more capable key (but not a license).</span></span> <span data-ttu-id="bb777-129">これは、複数のストリーム サイズが 1 つのキーでエンコードされる状況をサポートします。</span><span class="sxs-lookup"><span data-stu-id="bb777-129">It supports cases where multiple stream sizes are encoded with a single key.</span></span>

## <a name="encrypted-media-extension-support-in-playready"></a><span data-ttu-id="bb777-130">PlayReady の Encrypted Media Extension のサポート</span><span class="sxs-lookup"><span data-stu-id="bb777-130">Encrypted Media Extension support in PlayReady</span></span>

<span data-ttu-id="bb777-131">このセクションでは、PlayReady でサポートされている W3C 暗号化メディア拡張機能のバージョンについて説明します。</span><span class="sxs-lookup"><span data-stu-id="bb777-131">This section describes the version of the W3C Encrypted Media Extension supported by PlayReady.</span></span>

<span data-ttu-id="bb777-132">Web アプリ用の PlayReady は、現在 [2013 年 5 月 10 日付けの W3C Encrypted Media Extension (EME) 草案](http://www.w3.org/TR/2013/WD-encrypted-media-20130510/)に準拠しています。</span><span class="sxs-lookup"><span data-stu-id="bb777-132">PlayReady for Web Apps is currently bound to the [W3C Encrypted Media Extension (EME) draft of May 10, 2013](http://www.w3.org/TR/2013/WD-encrypted-media-20130510/).</span></span> <span data-ttu-id="bb777-133">このサポートは、将来のバージョンの Windows では更新された EME 仕様に合わせて変更されます。</span><span class="sxs-lookup"><span data-stu-id="bb777-133">This support will be changed to the updated EME specification in future versions of Windows.</span></span>

## <a name="use-hardware-drm"></a><span data-ttu-id="bb777-134">ハードウェア DRM の使用</span><span class="sxs-lookup"><span data-stu-id="bb777-134">Use hardware DRM</span></span>

<span data-ttu-id="bb777-135">このセクションでは、Web アプリで PlayReady ハードウェア DRM を使う方法と、保護されたコンテンツがハードウェア DRM をサポートしていない場合にそれを無効にする方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="bb777-135">This section describes how your web app can use PlayReady hardware DRM, and how to disable hardware DRM if the protected content does not support it.</span></span>

<span data-ttu-id="bb777-136">PlayReady ハードウェア DRM を使うには、JavaScript Web アプリは、キー システム識別子 `com.microsoft.playready.hardware` と共に **isTypeSupported** EME メソッドを使って、ブラウザーから PlayReady ハードウェア DRM のサポートを照会する必要があります。</span><span class="sxs-lookup"><span data-stu-id="bb777-136">To use PlayReady hardware DRM, your JavaScript web app should use the **isTypeSupported** EME method with a key system identifier of `com.microsoft.playready.hardware` to query for PlayReady hardware DRM support from the browser.</span></span>

<span data-ttu-id="bb777-137">一部のコンテンツは、ハードウェア DRM ではサポートされない場合があります。</span><span class="sxs-lookup"><span data-stu-id="bb777-137">Occasionally, some content is not supported in hardware DRM.</span></span> <span data-ttu-id="bb777-138">Cocktail コンテンツがハードウェア DRM でサポートされることはありません。Cocktail コンテンツを再生する場合は、ハードウェア DRM を除外する必要があります。</span><span class="sxs-lookup"><span data-stu-id="bb777-138">Cocktail content is never supported in hardware DRM; if you want to play cocktail content, you must opt out of hardware DRM.</span></span> <span data-ttu-id="bb777-139">一部のハードウェア DRM は HEVC をサポートしますが、サポートしないものもあります。HEVC コンテンツを再生したいが、ハードウェア DRM がサポートしていない場合も、これを除外してください。</span><span class="sxs-lookup"><span data-stu-id="bb777-139">Some hardware DRM will support HEVC and some will not; if you want to play HEVC content and hardware DRM doesn’t support it, you will want to opt out as well.</span></span>

> [!NOTE]
> <span data-ttu-id="bb777-140">HEVC コンテンツがサポートされているかどうかを判断するには、`com.microsoft.playready` をインスタンス化した後で、[**PlayReadyStatics.CheckSupportedHardware**](https://msdn.microsoft.com/library/windows/apps/dn986441) メソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="bb777-140">To determine whether HEVC content is supported, after instantiating `com.microsoft.playready`, use the [**PlayReadyStatics.CheckSupportedHardware**](https://msdn.microsoft.com/library/windows/apps/dn986441) method.</span></span>

## <a name="add-secure-stop-to-your-web-app"></a><span data-ttu-id="bb777-141">Web アプリにセキュア ストップを追加する</span><span class="sxs-lookup"><span data-stu-id="bb777-141">Add secure stop to your web app</span></span>

<span data-ttu-id="bb777-142">このセクションでは、Web アプリにセキュア ストップを追加する方法を説明します。</span><span class="sxs-lookup"><span data-stu-id="bb777-142">This section describes how to add secure stop to your web app.</span></span>

<span data-ttu-id="bb777-143">セキュア ストップによって、特定のコンテンツについてのメディア再生が停止したメディア ストリーミング サービスに対して、PlayReady デバイスが確実にアサートするための手段が提供されます。</span><span class="sxs-lookup"><span data-stu-id="bb777-143">Secure stop provides the means for a PlayReady device to confidently assert to a media streaming service that media playback has stopped for any given piece of content.</span></span> <span data-ttu-id="bb777-144">この機能により、メディア ストリーミング サービスは、特定のアカウントのさまざまなデバイスに対する使用制限を正しく適用し報告することができるようになります。</span><span class="sxs-lookup"><span data-stu-id="bb777-144">This capability ensures your media streaming services provide accurate enforcement and reporting of usage limitations on different devices for a given account.</span></span>

<span data-ttu-id="bb777-145">セキュア ストップのチャレンジを送信する主なシナリオが 2 つあります。</span><span class="sxs-lookup"><span data-stu-id="bb777-145">There are two primary scenarios for sending a secure stop challenge:</span></span>

-   <span data-ttu-id="bb777-146">コンテンツの最後に達したか、ユーザーがメディア プレゼンテーションを途中で停止したため、メディア プレゼンテーションが停止した場合。</span><span class="sxs-lookup"><span data-stu-id="bb777-146">When the media presentation stops because end of content was reached or when the user stopped the media presentation somewhere in the middle.</span></span>
-   <span data-ttu-id="bb777-147">(システムまたはアプリのクラッシュなどにより) 前回のセッションが予期せずに終了した場合。</span><span class="sxs-lookup"><span data-stu-id="bb777-147">When the previous session ends unexpectedly (for example, due to a system or app crash).</span></span> <span data-ttu-id="bb777-148">アプリは、起動時またはシャットダウン時に、未処理のセキュア ストップ セッションについて照会し、その他のメディア再生とは別にチャレンジを送信する必要があります。</span><span class="sxs-lookup"><span data-stu-id="bb777-148">The app will need to query, either at startup or shutdown, for any outstanding secure stop sessions and send challenge(s) separate from any other media playback.</span></span>

<span data-ttu-id="bb777-149">次の手順は、さまざまなシナリオでセキュア ストップを設定する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="bb777-149">The following procedures describe how to set up secure stop for various scenarios.</span></span>

<span data-ttu-id="bb777-150">プレゼンテーションの通常の終了時にセキュア ストップを設定するには</span><span class="sxs-lookup"><span data-stu-id="bb777-150">To set up secure stop for a normal end of a presentation:</span></span>

1.  <span data-ttu-id="bb777-151">再生が開始する前に **onEnded** イベントを登録します。</span><span class="sxs-lookup"><span data-stu-id="bb777-151">Register the **onEnded** event before playback starts.</span></span>
2.  <span data-ttu-id="bb777-152">**onEnded** イベント ハンドラーは、ビデオ/オーディオ要素のオブジェクトから `removeAttribute(“src”)` を呼び出し、ソースを **NULL** に設定する必要があります。これにより、メディア ファンデーションをトリガーしてトポロジを終了し、暗号化解除機能を破棄して、停止状態を設定します。</span><span class="sxs-lookup"><span data-stu-id="bb777-152">The **onEnded** event handler needs to call `removeAttribute(“src”)` from the video/audio element object to set the source to **NULL** which will trigger the media foundation to tear down the topology, destroy the decryptor(s), and set the stop state.</span></span>
3.  <span data-ttu-id="bb777-153">ハンドラー内の CDM セッションのセキュア ストップを開始し、セキュア ストップ チャレンジをサーバーに送信して、現在は再生が停止したが、後でも実行できることを通知できます。</span><span class="sxs-lookup"><span data-stu-id="bb777-153">You can start the secure stop CDM session inside the handler to send the secure stop challenge to the server to notify the playback has stopped at this time, but it can be done later as well.</span></span>

<span data-ttu-id="bb777-154">ユーザーがページから移動したか、タブまたはブラウザーを閉じた場合にセキュア ストップを設定するには</span><span class="sxs-lookup"><span data-stu-id="bb777-154">To set up secure stop if the user navigates away from the page or closes down the tab or browser:</span></span>

-   <span data-ttu-id="bb777-155">停止状態を記録するためにアプリの操作は必要ありません。自動的に記録されます。</span><span class="sxs-lookup"><span data-stu-id="bb777-155">No app action is required to record the stop state; it will be recorded for you.</span></span>

<span data-ttu-id="bb777-156">カスタム ページ コントロールまたはユーザーの操作 (カスタム ナビゲーション ボタンや、現在のプレゼンテーションを完了する前に新しいプレゼンテーションを開始するなど) のセキュア ストップを設定するには</span><span class="sxs-lookup"><span data-stu-id="bb777-156">To set up secure stop for custom page controls or user actions (such as custom navigation buttons or starting a new presentation before the current presentation completed):</span></span>

-   <span data-ttu-id="bb777-157">カスタム ユーザー アクションが発生すると、アプリは、ソースを **NULL** に設定する必要があります。これにより、メディア ファンデーションをトリガーして、トポロジを終了し、暗号化解除機能を破棄して、停止状態を設定します。</span><span class="sxs-lookup"><span data-stu-id="bb777-157">When custom user action occurs, the app needs to set the source to **NULL** which will trigger the media foundation to tear down the topology, destroy the decryptor(s), and set the stop state.</span></span>

<span data-ttu-id="bb777-158">次の例は、Web アプリでのセキュア ストップの使い方を示しています。</span><span class="sxs-lookup"><span data-stu-id="bb777-158">The following example demonstrates how to use secure stop in your web app:</span></span>

```JavaScript
// JavaScript source code

var g_prkey = null;
var g_keySession = null;
var g_fUseSpecificSecureStopSessionID = false;
var g_encodedMeteringCert = 'Base64 encoded of your metering cert (aka publisher cert)';

// Note: g_encodedLASessionId is the CDM session ID of the proactive or reactive license acquisition 
//       that we want to initiate the secure stop process.
var g_encodedLASessionId = null;

function main()
{
    ...

    g_prkey = new MSMediaKeys("com.microsoft.playready");

    ...

    // add 'onended' event handler to the video element
    // Assume 'myvideo' is the ID of the video element
    var videoElement = document.getElementById("myvideo");
    videoElement.onended = function (e) { 

        //
        // Calling removeAttribute("src") will set the source to null
        // which will trigger the MF to tear down the topology, destroy the
        // decryptor(s) and set the stop state.  This is required in order
        // to set the stop state.
        //
        videoElement.removeAttribute("src");
        videoElement.load();

        onEndOfStream();
    };
}

function onEndOfStream()
{
    ...

    createSecureStopCDMSession();

    ...    
}

function createSecureStopCDMSession()
{
    try{    
        var targetMediaCodec = "video/mp4";
        var customData = "my custom data";

        var encodedSessionId = g_encodedLASessionId;
        if( !g_fUseSpecificSecureStopSessionID )
        {
            // Use "*" (wildcard) as the session ID to include all secure stop sessions
            // TODO: base64 encode "*" and place encoded result to encodedSessionId
        }

        var int8ArrayCDMdata = formatSecureStopCDMData( encodedSessionId, customData,  g_encodedMeteringCert );
        var emptyArrayofInitData = new Uint8Array();

        g_keySession = g_prkey.createSession(targetMediaCodec, emptyArrayofInitData, int8ArrayCDMdata);

        addPlayreadyKeyEventHandler();

    } catch( e )
    {
        // TODO: Handle exception
    }
}

function addPlayreadyKeyEventHandler()
{
    // add 'keymessage' eventhandler   
    g_keySession.addEventListener('mskeymessage', function (event) {

        // TODO: Get the keyMessage from event.message.buffer which contains the secure stop challenge
        //       The keyMessage format for the secure stop is similar to LA as below:
        //
        //            <PlayReadyKeyMessage type="SecureStop" >
        //              <SecureStop version="1.0" >
        //                <Challenge encoding="base64encoded">
        //                    secure stop challenge
        //                </Challenge>
        //                <HttpHeaders>
        //                    <HttpHeader>
        //                      <name>Content-Type</name>
        //                         <value>"content type data"</value>
        //                    </HttpHeader>
        //                    <HttpHeader>
        //                         <name>SOAPAction</name>
        //                         <value>soap action</value>
        //                     </HttpHeader>
        //                    ....
        //                </HttpHeaders>
        //              </SecureStop>
        //            </PlayReadyKeyMessage>
                
        // TODO: send the secure stop challenge to a server that handles the secure stop challenge

        // TODO: Recevie and response and call event.target.Update() to proecess the response
    });
    
    // add 'keyerror' eventhandler
    g_keySession.addEventListener('mskeyerror', function (event) {
        var session = event.target;
        
        ...

        session.close();
    });
    
    // add 'keyadded' eventhandler
    g_keySession.addEventListener('mskeyadded', function (event) {
        
        var session = event.target;

        ...

        session.close();             
    });
}

/**
* desc@ formatSecureStopCDMData
*   generate playready CDMData
*   CDMData is in xml format:
*   <PlayReadyCDMData type="SecureStop">
*     <SecureStop version="1.0">
*       <SessionID>B64 encoded session ID</SessionID>
*       <CustomData>B64 encoded custom data</CustomData>
*       <ServerCert>B64 encoded server cert</ServerCert>
*     </SecureCert>
* </PlayReadyCDMData>        
*/
function formatSecureStopCDMData(encodedSessionId, customData, encodedPublisherCert) 
{
    var encodedCustomData = null;

    // TODO: base64 encode the custom data and place the encoded result to encodedCustomData

    var CDMDataStr = "<PlayReadyCDMData type=\"SecureStop\">" +
                     "<SecureStop version=\"1.0\" >" +
                     "<SessionID>" + encodedSessionId + "</SessionID>" +
                     "<CustomData>" + encodedCustomData + "</CustomData>" +
                     "<ServerCert>" + encodedPublisherCert + "</ServerCert>" +
                     "</SecureStop></PlayReadyCDMData>";
    
    var int8ArrayCDMdata = null

    // TODO: Convert CDMDataStr to Uint8 byte array and palce the converted result to int8ArrayCDMdata

    return int8ArrayCDMdata;
}
```

> [!NOTE]
> <span data-ttu-id="bb777-159">前のセキュア ストップのデータの `<SessionID>B64 encoded session ID</SessionID>` は、アスタリスク (\*) にすることができます。これは、記録されたすべてのセキュア ストップ セッション用のワイルドカードです。</span><span class="sxs-lookup"><span data-stu-id="bb777-159">The secure stop data’s `<SessionID>B64 encoded session ID</SessionID>` in the sample above can be an asterisk (\*), which is a wild card for all the secure stop sessions recorded.</span></span> <span data-ttu-id="bb777-160">つまり、**SessionID** タグは特定のセッションにするか、すべてのセキュア ストップ セッションを選択するワイルドカード (\*) にすることができます。</span><span class="sxs-lookup"><span data-stu-id="bb777-160">That is, the **SessionID** tag can be a specific session, or a wild card (\*) to select all the secure stop sessions.</span></span>

## <a name="programming-considerations-for-encrypted-media-extension"></a><span data-ttu-id="bb777-161">Encrypted Media Extension のプログラミングについての考慮事項</span><span class="sxs-lookup"><span data-stu-id="bb777-161">Programming considerations for Encrypted Media Extension</span></span>

<span data-ttu-id="bb777-162">このセクションでは、windows 10 の PlayReady が有効な web アプリを作成するときに考慮プログラミングの考慮事項を示します。</span><span class="sxs-lookup"><span data-stu-id="bb777-162">This section lists the programming considerations that you should take into account when creating your PlayReady-enabled web app for Windows10.</span></span>

<span data-ttu-id="bb777-163">アプリで作成した **MSMediaKeys** オブジェクトと **MSMediaKeySession** オブジェクトは、アプリが終了するまで有効なままである必要があります。</span><span class="sxs-lookup"><span data-stu-id="bb777-163">The **MSMediaKeys** and **MSMediaKeySession** objects created by your app must be kept alive until your app closes.</span></span> <span data-ttu-id="bb777-164">これらのオブジェクトが必ず有効な状態にとどまるようにする方法の 1 つは、それらをグローバル変数として割り当てることです (関数内でローカル変数宣言された場合、変数はスコープ外になり、ガベージ コレクションの対象になります)。</span><span class="sxs-lookup"><span data-stu-id="bb777-164">One way of ensuring these objects stay alive is to assign them as global variables (the variables would become out of scope and subject to garbage collection if declared as a local variable inside of a function).</span></span> <span data-ttu-id="bb777-165">次の例では、変数 *g\_msMediaKeys* と *g\_mediaKeySession* をグローバル変数として割り当てています。これらの変数は、関数内で **MSMediaKeys** オブジェクトと **MSMediaKeySession** オブジェクトに割り当てられます。</span><span class="sxs-lookup"><span data-stu-id="bb777-165">For example, the following sample assigns the variables *g\_msMediaKeys* and *g\_mediaKeySession* as global variables, which are then assigned to the **MSMediaKeys** and **MSMediaKeySession** objects in the function.</span></span>

``` syntax
var g_msMediaKeys;
var g_mediaKeySession;

function foo() {
  ...
  g_msMediaKeys = new MSMediaKeys("com.microsoft.playready");
  ...
  g_mediaKeySession = g_msMediaKeys.createSession("video/mp4", intiData, null);
  g_mediaKeySession.addEventListener(this.KEYMESSAGE_EVENT, function (e) 
  {
    ...
    downloadPlayReadyKey(url, keyMessage, function (data) 
    {
      g_mediaKeySession.update(data);
    });
  });
  g_mediaKeySession.addEventListener(this.KEYADDED_EVENT, function () 
  {
    ...
    g_mediaKeySession.close();
    g_mediaKeySession = null;
  });
}
```

<span data-ttu-id="bb777-166">詳しくは、[サンプル アプリケーション](https://code.msdn.microsoft.com/windowsapps/PlayReady-samples-for-124a3738)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="bb777-166">For more information, see the [sample applications](https://code.msdn.microsoft.com/windowsapps/PlayReady-samples-for-124a3738).</span></span>

## <a name="see-also"></a><span data-ttu-id="bb777-167">参照</span><span class="sxs-lookup"><span data-stu-id="bb777-167">See also</span></span>
- [<span data-ttu-id="bb777-168">PlayReady DRM</span><span class="sxs-lookup"><span data-stu-id="bb777-168">PlayReady DRM</span></span>](playready-client-sdk.md)




