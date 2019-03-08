---
Description: トースト通知でカスタムの音声を使用する方法について説明します。
title: トーストでのカスタム オーディオの使用
label: Custom audio on toasts
template: detail.hbs
ms.date: 12/15/2017
ms.topic: article
keywords: windows 10, uwp, トースト, カスタム オーディオ, 通知, オーディオ, サウンド
ms.localizationpriority: medium
ms.openlocfilehash: 982340901d13f17945c1e7ffa11099f52732f619
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57644067"
---
# <a name="custom-audio-on-toasts"></a><span data-ttu-id="b3beb-104">トーストでのカスタム オーディオの使用</span><span class="sxs-lookup"><span data-stu-id="b3beb-104">Custom audio on toasts</span></span>

<span data-ttu-id="b3beb-105">トースト通知でカスタム オーディオを使用して、アプリでブランド独自のサウンド エフェクトを表現できます。</span><span class="sxs-lookup"><span data-stu-id="b3beb-105">Toast notifications can use custom audio, which lets your app express your brand's unique sound effects.</span></span> <span data-ttu-id="b3beb-106">たとえば、メッセージング アプリで、トースト通知に汎用の通知サウンドではなく、独自のメッセージング サウンドを使用すると、ユーザーは特定のアプリから通知を受け取ったことが即座にわかります。</span><span class="sxs-lookup"><span data-stu-id="b3beb-106">For example, a messaging app can use their own messaging sound on their Toast notifications, so that the user can instantly know that they received a notification from the app, rather than hearing the generic notification sound.</span></span>

## <a name="install-uwp-community-toolkit-nuget-package"></a><span data-ttu-id="b3beb-107">UWP コミュニティ ツールキットの NuGet パッケージをインストールする</span><span class="sxs-lookup"><span data-stu-id="b3beb-107">Install UWP Community Toolkit NuGet package</span></span>

<span data-ttu-id="b3beb-108">コードを利用して通知を作成するには、通知 XML コンテンツのオブジェクト モデルを提供する UWP コミュニティ ツールキットの Notifications ライブラリの使用を強くお勧めします。</span><span class="sxs-lookup"><span data-stu-id="b3beb-108">In order to create notifications via code, we strongly recommend using the UWP Community Toolkit Notifications library, which provides an object model for the notification XML content.</span></span> <span data-ttu-id="b3beb-109">手動で通知用 XML を構築することもできますが、ミスが発生しやすく煩雑です。</span><span class="sxs-lookup"><span data-stu-id="b3beb-109">You could manually construct the notification XML, but that is error-prone and messy.</span></span> <span data-ttu-id="b3beb-110">UWP コミュニティ ツールキットに用意された Notifications ライブラリは、Microsoft の通知を担当しているチームが構築して管理しています。</span><span class="sxs-lookup"><span data-stu-id="b3beb-110">The Notifications library inside UWP Community Toolkit is built and maintained by the team that owns notifications at Microsoft.</span></span>

<span data-ttu-id="b3beb-111">NuGet から [Microsoft.Toolkit.Uwp.Notifications](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/) をインストールします (このページのサンプルでは、バージョン 1.0.0 を使用しています)。</span><span class="sxs-lookup"><span data-stu-id="b3beb-111">Install [Microsoft.Toolkit.Uwp.Notifications](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/) from NuGet (we're using version 1.0.0 in this documentation).</span></span>


## <a name="add-namespace-declarations"></a><span data-ttu-id="b3beb-112">名前空間宣言を追加する</span><span class="sxs-lookup"><span data-stu-id="b3beb-112">Add namespace declarations</span></span>

<span data-ttu-id="b3beb-113">`Windows.UI.Notifications` タイルとトースト API が含まれています。</span><span class="sxs-lookup"><span data-stu-id="b3beb-113">`Windows.UI.Notifications` includes the Tile and Toast API's.</span></span> <span data-ttu-id="b3beb-114">`Microsoft.Toolkit.Uwp.Notifications` 通知ライブラリが含まれています。</span><span class="sxs-lookup"><span data-stu-id="b3beb-114">`Microsoft.Toolkit.Uwp.Notifications` includes the Notifications library.</span></span>

```csharp
using Microsoft.Toolkit.Uwp.Notifications;
using Windows.UI.Notifications;
```


## <a name="construct-the-notification"></a><span data-ttu-id="b3beb-115">通知を作成する</span><span class="sxs-lookup"><span data-stu-id="b3beb-115">Construct the notification</span></span>

<span data-ttu-id="b3beb-116">トースト通知のコンテンツには、テキストや画像のほか、ボタンや入力も含まれています。</span><span class="sxs-lookup"><span data-stu-id="b3beb-116">The toast notification content includes text and images, and also buttons and inputs.</span></span> <span data-ttu-id="b3beb-117">完全なコード スニペットについては、[ローカル トースト通知の送信](send-local-toast.md) をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b3beb-117">Please see [send local toast](send-local-toast.md) to see a full code snippet.</span></span>

```csharp
ToastContent toastContent = new ToastContent()
{
    Visual = new ToastVisual()
    {
        ... (omitted)
    }
};
```


## <a name="add-the-custom-audio"></a><span data-ttu-id="b3beb-118">カスタム オーディオを追加する</span><span class="sxs-lookup"><span data-stu-id="b3beb-118">Add the custom audio</span></span>

<span data-ttu-id="b3beb-119">Windows Mobile は、常にトースト通知でカスタム オーディオがサポートされてきました。</span><span class="sxs-lookup"><span data-stu-id="b3beb-119">Windows Mobile has always supported custom audio in Toast notifications.</span></span> <span data-ttu-id="b3beb-120">しかし、デスクトップ版では、バージョン 1511 (ビルド 10586) で初めてカスタム オーディオのサポートが追加されました。</span><span class="sxs-lookup"><span data-stu-id="b3beb-120">However, Desktop only added support for custom audio in Version 1511 (build 10586).</span></span> <span data-ttu-id="b3beb-121">バージョン 1511 より前のデスクトップ デバイスに、カスタム オーディオを含んだトーストを送信すると、トーストは無音となります。</span><span class="sxs-lookup"><span data-stu-id="b3beb-121">If you send a Toast that contains custom audio to a Desktop device before Version 1511, the toast will be silent.</span></span> <span data-ttu-id="b3beb-122">そのため、バージョン 1511 より前のバージョンのデスクトップでは、トースト通知にカスタム オーディオを含めないでください。これにより、通知の際に、少なくとも既定の通知サウンドが使用されます。</span><span class="sxs-lookup"><span data-stu-id="b3beb-122">Therefore, for Desktop pre-Version 1511, you should NOT include the custom audio in your Toast notification, so that the notification will at least use the default notification sound.</span></span>

<span data-ttu-id="b3beb-123">**既知の問題**:デスクトップ バージョン 1511 を使用している場合、カスタムのトースト オーディオはストアを経由して、アプリがインストールされている場合をのみ機能します。</span><span class="sxs-lookup"><span data-stu-id="b3beb-123">**Known Issue**: If you're using Desktop Version 1511, the custom toast audio will only work if your app is installed via the Store.</span></span> <span data-ttu-id="b3beb-124">そのため、Microsoft Store への提出前に、ローカル デスクトップでカスタムのオーディオをテストすることはできませんが、Microsoft Store からインストールしたときには、オーディオが正常に機能します。</span><span class="sxs-lookup"><span data-stu-id="b3beb-124">That means you cannot locally test your custom audio on Desktop before submitting to the Store - but the audio will work fine once installed from the Store.</span></span> <span data-ttu-id="b3beb-125">Anniversary update ではこの問題が修正され、ローカルに展開されたアプリからでもカスタム オーディオが正常に動作します。</span><span class="sxs-lookup"><span data-stu-id="b3beb-125">We fixed this in the Anniversary Update, so that custom audio from your locally deployed app will work correctly.</span></span>

```csharp
?
bool supportsCustomAudio = true;
 
// If we're running on Desktop before Version 1511, do NOT include custom audio
// since it was not supported until Version 1511, and would result in a silent toast.
if (AnalyticsInfo.VersionInfo.DeviceFamily.Equals("Windows.Desktop")
    && !ApiInformation.IsApiContractPresent("Windows.Foundation.UniversalApiContract", 2))
{
    supportsCustomAudio = false;
}
 
if (supportsCustomAudio)
{
    toastContent.Audio = new ToastAudio()
    {
        Src = new Uri("ms-appx:///Assets/Audio/CustomToastAudio.m4a")
    };
}
```

<span data-ttu-id="b3beb-126">サポートされているオーディオ ファイルの種類は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="b3beb-126">Supported audio file types include...</span></span>

- <span data-ttu-id="b3beb-127">.aac</span><span class="sxs-lookup"><span data-stu-id="b3beb-127">.aac</span></span>
- <span data-ttu-id="b3beb-128">.flac</span><span class="sxs-lookup"><span data-stu-id="b3beb-128">.flac</span></span>
- <span data-ttu-id="b3beb-129">.m4a</span><span class="sxs-lookup"><span data-stu-id="b3beb-129">.m4a</span></span>
- <span data-ttu-id="b3beb-130">.mp3</span><span class="sxs-lookup"><span data-stu-id="b3beb-130">.mp3</span></span>
- <span data-ttu-id="b3beb-131">.wav</span><span class="sxs-lookup"><span data-stu-id="b3beb-131">.wav</span></span>
- <span data-ttu-id="b3beb-132">.wma</span><span class="sxs-lookup"><span data-stu-id="b3beb-132">.wma</span></span>


## <a name="send-the-notification"></a><span data-ttu-id="b3beb-133">通知を送信する</span><span class="sxs-lookup"><span data-stu-id="b3beb-133">Send the notification</span></span>

<span data-ttu-id="b3beb-134">トースト コンテンツが完了した後は、簡単に通知を送信できます。</span><span class="sxs-lookup"><span data-stu-id="b3beb-134">Now that your toast content is complete, sending the notification is quite simple.</span></span>

```csharp
// Create the toast notification from the previous toast content
ToastNotification notification = new ToastNotification(toastContent.GetXml());
             
// And then send the toast
ToastNotificationManager.CreateToastNotifier().Show(notification);
```


## <a name="related-topics"></a><span data-ttu-id="b3beb-135">関連トピック</span><span class="sxs-lookup"><span data-stu-id="b3beb-135">Related topics</span></span>

- [<span data-ttu-id="b3beb-136">GitHub の完全なコード サンプル</span><span class="sxs-lookup"><span data-stu-id="b3beb-136">Full code sample on GitHub</span></span>](https://github.com/WindowsNotifications/quickstart-toast-with-custom-audio)
- [<span data-ttu-id="b3beb-137">ローカルのトーストを送信します。</span><span class="sxs-lookup"><span data-stu-id="b3beb-137">Send a local toast</span></span>](send-local-toast.md)
- [<span data-ttu-id="b3beb-138">トーストのコンテンツのドキュメント</span><span class="sxs-lookup"><span data-stu-id="b3beb-138">Toast content documentation</span></span>](adaptive-interactive-toasts.md)