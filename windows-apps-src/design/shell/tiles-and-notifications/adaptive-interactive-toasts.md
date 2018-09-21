---
author: andrewleader
Description: Adaptive and interactive toast notifications let you create flexible pop-up notifications with more content, optional inline images, and optional user interaction.
title: トーストのコンテンツ
ms.assetid: 1FCE66AF-34B4-436A-9FC9-D0CF4BDA5A01
label: Toast content
template: detail.hbs
ms.author: mijacobs
ms.date: 11/20/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, トースト通知, 対話型トースト, アダプティブ トースト, トーストのコンテンツ, トースト ペイロード
ms.localizationpriority: medium
ms.openlocfilehash: de999528d07e6bd7d243e53708e9afc465004af7
ms.sourcegitcommit: 4f6dc806229a8226894c55ceb6d6eab391ec8ab6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/20/2018
ms.locfileid: "4090343"
---
# <a name="toast-content"></a><span data-ttu-id="7a0c3-103">トーストのコンテンツ</span><span class="sxs-lookup"><span data-stu-id="7a0c3-103">Toast content</span></span>

<span data-ttu-id="7a0c3-104">アダプティブ トースト通知と対話型トースト通知を使うと、テキスト、画像、ボタンと入力を含む柔軟性のある通知を作成できます。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-104">Adaptive and interactive toast notifications let you create flexible notifications with text, images, and buttons/inputs.</span></span>

> <span data-ttu-id="7a0c3-105">**重要な API**: [UWP Community Toolkit Notifications NuGet パッケージ](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/)</span><span class="sxs-lookup"><span data-stu-id="7a0c3-105">**Important APIs**: [UWP Community Toolkit Notifications nuget package](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/)</span></span>

> [!NOTE]
> <span data-ttu-id="7a0c3-106">Windows 8.1 や Windows Phone 8.1 の従来のテンプレートについては、「[トースト テンプレート カタログ (Windows ランタイム アプリ)](https://msdn.microsoft.com/library/windows/apps/hh761494)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-106">To see the legacy templates from Windows 8.1 and Windows Phone 8.1, see the [legacy toast template catalog](https://msdn.microsoft.com/library/windows/apps/hh761494).</span></span>


## <a name="getting-started"></a><span data-ttu-id="7a0c3-107">概要</span><span class="sxs-lookup"><span data-stu-id="7a0c3-107">Getting started</span></span>

**<span data-ttu-id="7a0c3-108">Notifications ライブラリをインストールします。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-108">Install Notifications library.</span></span>** <span data-ttu-id="7a0c3-109">XML の代わりに C# を使って通知を生成する場合は、[Microsoft.Toolkit.Uwp.Notifications](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/) という名前の NuGet パッケージをインストールします (「notifications uwp」を検索してください)。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-109">If you'd like to use C# instead of XML to generate notifications, install the NuGet package named [Microsoft.Toolkit.Uwp.Notifications](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/) (search for "notifications uwp").</span></span> <span data-ttu-id="7a0c3-110">この記事で示している C# のサンプルでは、NuGet パッケージの Version 1.0.0 を使っています。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-110">The C# samples provided in this article use version 1.0.0 of the NuGet package.</span></span>

**<span data-ttu-id="7a0c3-111">Notifications Visualizer をインストールします。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-111">Install Notifications Visualizer.</span></span>** <span data-ttu-id="7a0c3-112">この無料の UWP アプリは、Visual Studio の XAML エディター/デザイン ビューと同様、トーストの編集時に視覚的なプレビューが即座に表示されるため、対話型トースト通知のデザインに便利です。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-112">This free UWP app helps you design interactive toast notifications by providing an instant visual preview of your toast as you edit it, similar to Visual Studio's XAML editor/design view.</span></span> <span data-ttu-id="7a0c3-113">詳しくは、「[Notifications Visualizer](notifications-visualizer.md)」をご覧になるか、[Notifications Visualizer を Microsoft Store からダウンロード](https://www.microsoft.com/store/apps/notifications-visualizer/9nblggh5xsl1)してください。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-113">See [Notifications Visualizer](notifications-visualizer.md) for more information, or [download Notifications Visualizer from the Store](https://www.microsoft.com/store/apps/notifications-visualizer/9nblggh5xsl1).</span></span>


## <a name="sending-a-toast-notification"></a><span data-ttu-id="7a0c3-114">トースト通知の送信</span><span class="sxs-lookup"><span data-stu-id="7a0c3-114">Sending a toast notification</span></span>

<span data-ttu-id="7a0c3-115">通知を送信する方法については、「[ローカル トースト通知の送信](send-local-toast.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-115">To learn how to send a notification, see [Send local toast](send-local-toast.md).</span></span> <span data-ttu-id="7a0c3-116">このドキュメントでは、トースト コンテンツの作成についてのみ説明します。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-116">This documentation only covers creating the toast content.</span></span>


## <a name="toast-notification-structure"></a><span data-ttu-id="7a0c3-117">トースト通知の構造体</span><span class="sxs-lookup"><span data-stu-id="7a0c3-117">Toast notification structure</span></span>

<span data-ttu-id="7a0c3-118">トースト通知は、Tag や Group (通知を識別できます) などのいくつかのデータ プロパティと*トースト コンテンツ*を組み合わせたものです。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-118">Toast notifications are a combination of some data properties like Tag/Group (which let you identify the notification) and the *toast content*.</span></span>

<span data-ttu-id="7a0c3-119">トースト通知のコンテンツのコア コンポーネントは次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-119">The core components of toast content are...</span></span>
* <span data-ttu-id="7a0c3-120">**launch**: ユーザーがトーストをクリックしたときにアプリに渡される引数を定義します。これにより、トーストに表示されていた正しいコンテンツにディープ リンクできます。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-120">**launch**: This defines what arguments will be passed back to your app when the user clicks your toast, allowing you to deep link into the correct content that the toast was displaying.</span></span> <span data-ttu-id="7a0c3-121">詳しくは、「[ローカル トースト通知の送信](send-local-toast.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-121">To learn more, see [Send local toast](send-local-toast.md).</span></span>
* <span data-ttu-id="7a0c3-122">**visual**: トーストの視覚的な部分 (テキストや画像が含まれている汎用バインディングなど) です。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-122">**visual**: The visual portion of the toast, including the generic binding that contains text and images.</span></span>
* <span data-ttu-id="7a0c3-123">**actions**: トーストの対話的な部分 (入力やアクションなど) です。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-123">**actions**: The interactive portion of the toast, including inputs and actions.</span></span>
* <span data-ttu-id="7a0c3-124">**audio**: トーストがユーザーに表示されるときに再生されるオーディオを制御します。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-124">**audio**: Controls the audio played when the toast is shown to the user.</span></span>

<span data-ttu-id="7a0c3-125">トースト コンテンツは生の XML で定義されますが、トースト コンテンツを作成するために、[NuGet ライブラリ](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/)を使って C# (または C++) オブジェクト モデルを取得することができます。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-125">The toast content is defined in raw XML, but you can use our [NuGet library](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/) to get a C# (or C++) object model for constructing the toast content.</span></span> <span data-ttu-id="7a0c3-126">この記事では、トースト コンテンツ内に含まれるすべてのものについて説明します。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-126">This article documents everything that goes within the toast content.</span></span>

```csharp
ToastContent content = new ToastContent()
{
    Launch = "app-defined-string",
 
    Visual = new ToastVisual()
    {
        BindingGeneric = new ToastBindingGeneric() { ... }
    },
 
    Actions = new ToastActionsCustom() { ... },
 
    Audio = new ToastAudio() { ... }
};
```

```xml
<toast launch="app-defined-string">

  <visual>
    <binding template="ToastGeneric">
      ...
    </binding>
  </visual>

  <actions>
    ...
  </actions>

  <audio src="ms-winsoundevent:Notification.Reminder"/>

</toast>
```

<span data-ttu-id="7a0c3-127">トースト コンテンツの視覚的な表示は、次のようになります。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-127">Here is a visual representation of the toast's content:</span></span>

![トースト通知の構造体](images/adaptivetoasts-structure.jpg)


## <a name="visual"></a><span data-ttu-id="7a0c3-129">visual</span><span class="sxs-lookup"><span data-stu-id="7a0c3-129">Visual</span></span>

<span data-ttu-id="7a0c3-130">各トーストでは visual を指定し、その中に汎用トースト バインディングを設定する必要があります。この汎用トースト バインディングには、テキストや画像などを含めることができます。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-130">Each toast must specify a visual, where you must provide a generic toast binding, which can contain text, images, and more.</span></span> <span data-ttu-id="7a0c3-131">これらの要素は、デスクトップ、電話、タブレット、Xbox など、さまざまな Windows デバイスでレンダリングされます。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-131">These elements will be rendered on various Windows devices, including desktop, phones, tablets, and Xbox.</span></span>

<span data-ttu-id="7a0c3-132">visual セクションとその子要素でサポートされているすべての属性については、[スキーマのドキュメント](toast-schema.md#toastvisual)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-132">For all attributes supported in the visual section and its child elements, [see the schema documentation](toast-schema.md#toastvisual).</span></span>

<span data-ttu-id="7a0c3-133">トースト通知ではアプリの識別情報は、アプリ アイコンによって表示されます。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-133">Your app's identity on the toast notification is conveyed via your app icon.</span></span> <span data-ttu-id="7a0c3-134">ただし、アプリ ロゴの上書きを使った場合は、テキスト行の下にアプリ名が表示されます。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-134">However, if you use the app logo override, we will display your app name beneath your lines of text.</span></span>

| <span data-ttu-id="7a0c3-135">標準のトーストでのアプリの識別情報</span><span class="sxs-lookup"><span data-stu-id="7a0c3-135">App identity for normal toast</span></span> | <span data-ttu-id="7a0c3-136">appLogoOverride 使用時のアプリの識別情報</span><span class="sxs-lookup"><span data-stu-id="7a0c3-136">App identity with appLogoOverride</span></span> |
| -- | -- |
| <img src="images/adaptivetoasts-withoutapplogooverride.jpg" alt="notification without appLogoOverride" width="364"/> | <img alt="notification with appLogoOverride" src="images/adaptivetoasts-withapplogooverride.jpg" width="364"/> |


## <a name="text-elements"></a><span data-ttu-id="7a0c3-137">テキスト要素</span><span class="sxs-lookup"><span data-stu-id="7a0c3-137">Text elements</span></span>

<span data-ttu-id="7a0c3-138">各トーストには少なくとも 1 つのテキスト要素が必須であり、それ以外に 2 つのテキスト要素 (いずれも [**AdaptiveText**](toast-schema.md#adaptivetext) 型) を追加することができます。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-138">Each toast must have at least one text element, and can contain two additional text elements, all of type [**AdaptiveText**](toast-schema.md#adaptivetext).</span></span>

<img alt="Toast with title and description" src="images/toast-title-and-description.jpg" width="364"/>

<span data-ttu-id="7a0c3-139">Windows 10 Anniversary Update 以降は、そのテキストに対して **HintMaxLines** プロパティを使うことで、表示されるテキストの行数を制御できます。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-139">Since the Windows 10 Anniversary Update, you can control how many lines of text are displayed by using the **HintMaxLines** property on the text.</span></span> <span data-ttu-id="7a0c3-140">既定値 (最大値) は、タイトルのテキストが最大 2 行であり、それに加えて、2 つの説明要素 (2 番目と 3 番目の **AdaptiveText**) を合計で最大 4 行まで含めることができます。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-140">The default (and maximum) is up to 2 lines of text for the title, and up to 4 lines (combined) for the two additional description elements (the second and third **AdaptiveText**).</span></span>

```csharp
new ToastBindingGeneric()
{
    Children =
    {
        new AdaptiveText()
        {
            Text = "Adaptive Tiles Meeting",
            HintMaxLines = 1
        },

        new AdaptiveText()
        {
            Text = "Conf Room 2001 / Building 135"
        },

        new AdaptiveText()
        {
            Text = "10:00 AM - 10:30 AM"
        }
    }
}
```

```xml
<binding template="ToastGeneric">
    <text hint-maxLines="1">Adaptive Tiles Meeting</text>
    <text>Conf Room 2001 / Building 135</text>
    <text>10:00 AM - 10:30 AM</text>
</binding>
```


## <a name="app-logo-override"></a><span data-ttu-id="7a0c3-141">アプリ ロゴの上書き</span><span class="sxs-lookup"><span data-stu-id="7a0c3-141">App logo override</span></span>

<span data-ttu-id="7a0c3-142">既定では、トーストにアプリのロゴが表示されます。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-142">By default, your toast will display your app's logo.</span></span> <span data-ttu-id="7a0c3-143">ただし、このロゴは独自の [**ToastGenericAppLogo**](toast-schema.md#toastgenericapplogo) 画像で上書きできます。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-143">However, you can override this logo with your own [**ToastGenericAppLogo**](toast-schema.md#toastgenericapplogo) image.</span></span> <span data-ttu-id="7a0c3-144">たとえば、これが他のユーザーからの通知である場合は、アプリ ロゴをそのユーザーの写真で上書きすることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-144">For example, if this is a notification from a person, we recommend overriding the app logo with a picture of that person.</span></span>

<img alt="Toast with app logo override" src="images/toast-applogooverride.jpg" width="364"/>

<span data-ttu-id="7a0c3-145">画像のトリミングは、**HintCrop** プロパティを使って変更できます。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-145">You can use the **HintCrop** property to change the cropping of the image.</span></span> <span data-ttu-id="7a0c3-146">たとえば、**Circle** を使うと、画像が丸くトリミングされます。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-146">For example, **Circle** results in a circle-cropped image.</span></span> <span data-ttu-id="7a0c3-147">その他の場合、画像は正方形です。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-147">Otherwise, the image is square.</span></span> <span data-ttu-id="7a0c3-148">画像サイズは 100% のスケーリングで 48x48 ピクセルです。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-148">Image dimensions are 48x48 pixels at 100% scaling.</span></span>

```csharp
new ToastBindingGeneric()
{
    ...

    AppLogoOverride = new ToastGenericAppLogo()
    {
        Source = "https://picsum.photos/48?image=883",
        HintCrop = ToastGenericAppLogoCrop.Circle
    }
}
```

```xml
<binding template="ToastGeneric">
    ...
    <image placement="appLogoOverride" hint-crop="circle" src="https://picsum.photos/48?image=883"/>
</binding>
```


## <a name="hero-image"></a><span data-ttu-id="7a0c3-149">ヒーロー イメージ</span><span class="sxs-lookup"><span data-stu-id="7a0c3-149">Hero image</span></span>

<span data-ttu-id="7a0c3-150">**Anniversary Update の新機能**: トーストには、ヒーロー イメージを表示できます。ヒーロー イメージとは、トースト バナー内や、アクション センター内にいるときに、目立つように表示されるメイン ビジュアルの [**ToastGenericHeroImage**](toast-schema.md#toastgenericheroimage) です。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-150">**New in Anniversary Update**: Toasts can display a hero image, which is a featured [**ToastGenericHeroImage**](toast-schema.md#toastgenericheroimage) displayed prominently within the toast banner and while inside Action Center.</span></span> <span data-ttu-id="7a0c3-151">画像サイズは 100% のスケーリングで 364x180 ピクセルです。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-151">Image dimensions are 364x180 pixels at 100% scaling.</span></span>

<img alt="Toast with hero image" src="images/toast-heroimage.jpg" width="364"/>

```csharp
new ToastBindingGeneric()
{
    ...

    HeroImage = new ToastGenericHeroImage()
    {
        Source = "https://picsum.photos/364/180?image=1043"
    }
}
```

```xml
<binding template="ToastGeneric">
    ...
    <image placement="hero" src="https://picsum.photos/364/180?image=1043"/>
</binding>
```


## <a name="inline-image"></a><span data-ttu-id="7a0c3-152">インライン画像</span><span class="sxs-lookup"><span data-stu-id="7a0c3-152">Inline image</span></span>

<span data-ttu-id="7a0c3-153">トーストを展開したときに表示される全幅のインライン画像を指定できます。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-153">You can provide a full-width inline-image that appears when you expand the toast.</span></span>

<img alt="Toast with additional image" src="images/toast-additionalimage.jpg" width="364"/>

```csharp
new ToastBindingGeneric()
{
    Children =
    {
        ...

        new AdaptiveImage()
        {
            Source = "https://picsum.photos/360/202?image=1043"
        }
    }
}
```

```xml
<binding template="ToastGeneric">
    ...
    <image src="https://picsum.photos/360/202?image=1043" />
</binding>
```


## <a name="image-size-restrictions"></a><span data-ttu-id="7a0c3-154">画像サイズの制限</span><span class="sxs-lookup"><span data-stu-id="7a0c3-154">Image size restrictions</span></span>

<span data-ttu-id="7a0c3-155">トースト通知で使用する画像は、以下の場所から取得できます。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-155">The images you use in your toast notification can be sourced from...</span></span>

 - <span data-ttu-id="7a0c3-156">http://</span><span class="sxs-lookup"><span data-stu-id="7a0c3-156">http://</span></span>
 - <span data-ttu-id="7a0c3-157">ms-appx:///</span><span class="sxs-lookup"><span data-stu-id="7a0c3-157">ms-appx:///</span></span>
 - <span data-ttu-id="7a0c3-158">ms-appdata:///</span><span class="sxs-lookup"><span data-stu-id="7a0c3-158">ms-appdata:///</span></span>

<span data-ttu-id="7a0c3-159">http および https のリモート Web 画像では、各画像のファイル サイズに制限があります。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-159">For http and https remote web images, there are limits on the file size of each individual image.</span></span> <span data-ttu-id="7a0c3-160">Fall Creators Update (16299) では、この制限が通常の接続で 3 MB、従量制課金接続で 1 MB に拡大しました。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-160">In the Fall Creators Update (16299), we increased the limit to be 3 MB on normal connections and 1 MB on metered connections.</span></span> <span data-ttu-id="7a0c3-161">それより前のバージョンでは、いずれの場合も画像サイズの上限は 200 KB です。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-161">Before that, images were always limited to 200 KB.</span></span>

| <span data-ttu-id="7a0c3-162">通常の接続</span><span class="sxs-lookup"><span data-stu-id="7a0c3-162">Normal connection</span></span> | <span data-ttu-id="7a0c3-163">従量制課金接続</span><span class="sxs-lookup"><span data-stu-id="7a0c3-163">Metered connection</span></span> | <span data-ttu-id="7a0c3-164">Fall Creators Update より前のバージョン</span><span class="sxs-lookup"><span data-stu-id="7a0c3-164">Before Fall Creators Update</span></span> |
| - | - | - |
| <span data-ttu-id="7a0c3-165">3 MB</span><span class="sxs-lookup"><span data-stu-id="7a0c3-165">3 MB</span></span> | <span data-ttu-id="7a0c3-166">1 MB</span><span class="sxs-lookup"><span data-stu-id="7a0c3-166">1 MB</span></span> | <span data-ttu-id="7a0c3-167">200 KB</span><span class="sxs-lookup"><span data-stu-id="7a0c3-167">200 KB</span></span> |

<span data-ttu-id="7a0c3-168">画像がこのファイル サイズを超えている場合、画像がダウンロードできない場合、またはタイム アウトした場合は、画像が表示されず、通知の残りの部分のみが表示されます。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-168">If an image exceeds the file size, or fails to download, or times out, the image will be dropped and the rest of the notification will be displayed.</span></span>


## <a name="attribution-text"></a><span data-ttu-id="7a0c3-169">属性テキスト</span><span class="sxs-lookup"><span data-stu-id="7a0c3-169">Attribution text</span></span>

<span data-ttu-id="7a0c3-170">**Anniversary Update の新機能**: コンテンツのソースを参照する必要がある場合、属性テキストを使うことができます。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-170">**New in Anniversary Update**: If you need to reference the source of your content, you can use attribution text.</span></span> <span data-ttu-id="7a0c3-171">このテキストは常に、アプリの ID または通知のタイムスタンプと共に通知の下部に表示されます。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-171">This text is always displayed at the bottom of your notification, along with your app's identity or the notification's timestamp.</span></span>

<span data-ttu-id="7a0c3-172">属性テキストをサポートしていない以前のバージョンの Windows では、テキストは単に別のテキスト要素として表示されます (3 つのテキスト要素を最大限に含めていない場合)。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-172">On older versions of Windows that don't support attribution text, the text will simply be displayed as another text element (assuming you don't already have the maximum of three text elements).</span></span>

<img alt="Toast with attribution text" src="images/toast-attributiontext.jpg" width="364"/>

```csharp
new ToastBindingGeneric()
{
    ...

    Attribution = new ToastGenericAttributionText()
    {
        Text = "Via SMS"
    }
}
```

```xml
<binding template="ToastGeneric">
    ...
    <text placement="attribution">Via SMS</text>
</binding>
```


## <a name="custom-timestamp"></a><span data-ttu-id="7a0c3-173">カスタム タイムスタンプ</span><span class="sxs-lookup"><span data-stu-id="7a0c3-173">Custom timestamp</span></span>

<span data-ttu-id="7a0c3-174">**Creators Update の新機能**: システムが提供するタイムスタンプを、メッセージ、情報、コンテンツが生成された時点を正確に表す独自のタイムスタンプで上書きできるようになりました。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-174">**New in Creators Update**: You can now override the system-provided timestamp with your own timestamp that accurately represents when the message/information/content was generated.</span></span> <span data-ttu-id="7a0c3-175">このタイムスタンプはアクション センターに表示されます。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-175">This timestamp is visible within Action Center.</span></span>

<img alt="Toast with custom timestamp" src="images/toast-customtimestamp.jpg" width="396"/>

<span data-ttu-id="7a0c3-176">カスタム タイムスタンプの使用について詳しくは、「[トーストに表示されるカスタム タイムスタンプ](custom-timestamps-on-toasts.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-176">To learn more about using a custom timestamp, please see [custom timestamps on toasts](custom-timestamps-on-toasts.md).</span></span>

```csharp
ToastContent toastContent = new ToastContent()
{
    DisplayTimestamp = new DateTime(2017, 04, 15, 19, 45, 00, DateTimeKind.Utc),
    ...
};
```

```xml
<toast displayTimestamp="2017-04-15T19:45:00Z">
  ...
</toast>
```


## <a name="progress-bar"></a><span data-ttu-id="7a0c3-177">進行状況バー</span><span class="sxs-lookup"><span data-stu-id="7a0c3-177">Progress bar</span></span>

<span data-ttu-id="7a0c3-178">**Creators Update の新機能**: トースト通知に進行状況バーを表示して、ダウンロードなどの操作の進行状況をユーザーに示すことができます。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-178">**New in Creators Update**: You can provide a progress bar on your toast notification to keep the user informed of the progress of operations, like downloads and more.</span></span>

<img alt="Toast with progress bar" src="images/toast-progressbar.png" width="364"/>

<span data-ttu-id="7a0c3-179">進行状況バーの使用について詳しくは、「[トーストの進行状況バー](toast-progress-bar.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-179">To learn more about using a progress bar, please see [Toast progress bar](toast-progress-bar.md).</span></span>


## <a name="headers"></a><span data-ttu-id="7a0c3-180">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="7a0c3-180">Headers</span></span>

<span data-ttu-id="7a0c3-181">**Creators Update の新機能**: アクション センターのヘッダーの下で、複数の通知をグループ化することができます。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-181">**New in Creators Update**: You can group notifications under headers within Action Center.</span></span> <span data-ttu-id="7a0c3-182">たとえば、グループ チャットのグループ メッセージをヘッダーの下でグループ化したり、共通のテーマのグループ通知をヘッダーの下でグループ化したりすることができます。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-182">For example, you can group messages from a group chat under a header, or group notifications of a common theme under a header, or more.</span></span>

<img alt="Toasts with header" src="images/toast-headers-action-center.png" width="396"/>

<span data-ttu-id="7a0c3-183">ヘッダーの使用について詳しくは、「[トーストのヘッダー](toast-headers.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-183">To learn more about using headers, please see [Toast headers](toast-headers.md).</span></span>


## <a name="adaptive-content"></a><span data-ttu-id="7a0c3-184">アダプティブ コンテンツ</span><span class="sxs-lookup"><span data-stu-id="7a0c3-184">Adaptive content</span></span>

<span data-ttu-id="7a0c3-185">**Anniversary Update の新機能**: 上記で指定したコンテンツ以外に、トーストが展開されたときに表示される追加のアダプティブ コンテンツを表示することもできます。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-185">**New in Anniversary Update**: In addition to the content specified above, you can also display additional adaptive content that is visible when the toast is expanded.</span></span>

<span data-ttu-id="7a0c3-186">この追加コンテンツは Adaptive を使って指定されます。詳しくは、[アダプティブ タイルのドキュメント](create-adaptive-tiles.md)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-186">This additional content is specified using Adaptive, which you can learn more about by reading the [Adaptive Tiles documentation](create-adaptive-tiles.md).</span></span>

<span data-ttu-id="7a0c3-187">すべてのアダプティブ コンテンツは [**AdaptiveGroup**](https://docs.microsoft.com/windows/uwp/design/shell/tiles-and-notifications/toast-schema#adaptivegroup) 内に含める必要があることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-187">Note that any adaptive content must be contained within an [**AdaptiveGroup**](https://docs.microsoft.com/windows/uwp/design/shell/tiles-and-notifications/toast-schema#adaptivegroup).</span></span> <span data-ttu-id="7a0c3-188">それ以外の場合、Adaptive を使ってレンダリングされません。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-188">Otherwise it will not be rendered using adaptive.</span></span>


### <a name="columns-and-text-elements"></a><span data-ttu-id="7a0c3-189">列とテキスト要素</span><span class="sxs-lookup"><span data-stu-id="7a0c3-189">Columns and text elements</span></span>

<span data-ttu-id="7a0c3-190">列といくつかの詳細なアダプティブ テキスト要素が使われている例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-190">Here's an example where columns and some advanced adaptive text elements are used.</span></span> <span data-ttu-id="7a0c3-191">テキスト要素は \*\*AdaptiveGroup \*\*内にあるため、すべてのリッチ アダプティブ スタイル指定プロパティをサポートします。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-191">Since the text elements are within an **AdaptiveGroup**, they support all the rich adaptive styling properties.</span></span>

<img alt="Toast with additional text" src="images/toast-additionaltext.jpg" width="364"/>

```csharp
new ToastBindingGeneric()
{
    Children =
    {
        ...

        new AdaptiveGroup()
        {
            Children =
            {
                new AdaptiveSubgroup()
                {
                    Children =
                    {
                        new AdaptiveText()
                        {
                            Text = "52 attendees",
                            HintStyle = AdaptiveTextStyle.Base
                        },
                        new AdaptiveText()
                        {
                            Text = "23 minute drive",
                            HintStyle = AdaptiveTextStyle.CaptionSubtle
                        }
                    }
                },
                new AdaptiveSubgroup()
                {
                    Children =
                    {
                        new AdaptiveText()
                        {
                            Text = "1 Microsoft Way",
                            HintStyle = AdaptiveTextStyle.CaptionSubtle,
                            HintAlign = AdaptiveTextAlign.Right
                        },
                        new AdaptiveText()
                        {
                            Text = "Bellevue, WA 98008",
                            HintStyle = AdaptiveTextStyle.CaptionSubtle,
                            HintAlign = AdaptiveTextAlign.Right
                        }
                    }
                }
            }
        }
    }
}
```

```xml
<binding template="ToastGeneric">
    ...
    <group>
        <subgroup>
            <text hint-style="base">52 attendees</text>
            <text hint-style="captionSubtle">23 minute drive</text>
        </subgroup>
        <subgroup>
            <text hint-style="captionSubtle" hint-align="right">1 Microsoft Way</text>
            <text hint-style="captionSubtle" hint-align="right">Bellevue, WA 98008</text>
        </subgroup>
    </group>
</binding>
```


## <a name="buttons"></a><span data-ttu-id="7a0c3-192">ボタン</span><span class="sxs-lookup"><span data-stu-id="7a0c3-192">Buttons</span></span>

<span data-ttu-id="7a0c3-193">ボタンを使うとトーストを対話的にすることができ、ユーザーはトースト通知に対してクイック アクションを実行できます。その際、現在のワークフローは中断されません。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-193">Buttons make your toast interactive, letting the user take quick actions on your toast notification without interrupting their current workflow.</span></span> <span data-ttu-id="7a0c3-194">たとえば、ユーザーはトースト内からメッセージに直接返信したり、メール アプリを開かずにメールを削除したりすることができます。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-194">For example, users can reply to a message directly from within a toast, or delete an email without even opening the email app.</span></span> <span data-ttu-id="7a0c3-195">ボタンは、通知の展開した部分に表示されます。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-195">Buttons appear in the expanded portion of your notification.</span></span>

<span data-ttu-id="7a0c3-196">ボタンのエンドツーエンドの実装について詳しくは、「[ローカル トースト通知の送信](send-local-toast.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-196">To learn more about implementing buttons end-to-end, see [Send local toast](send-local-toast.md).</span></span>

<span data-ttu-id="7a0c3-197">ボタンは次のようなさまざまな操作を実行できます。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-197">Buttons can perform the following different actions...</span></span>

-   <span data-ttu-id="7a0c3-198">特定のページやコンテキストへの移動に使うことができる引数を指定して、アプリをフォアグラウンドでアクティブ化します。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-198">Activating the app in the foreground, with an argument that can be used to navigate to a specific page/context.</span></span>
-   <span data-ttu-id="7a0c3-199">クイック返信や同様のシナリオで、アプリのバックグラウンド タスクをアクティブ化します。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-199">Activating the app's background task, for a quick-reply or similar scenario.</span></span>
-   <span data-ttu-id="7a0c3-200">プロトコル起動を利用して別のアプリをアクティブ化します。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-200">Activating another app via protocol launch.</span></span>
-   <span data-ttu-id="7a0c3-201">再通知や通知の無視などのシステム操作を実行します。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-201">Performing a system action, like snoozing or dismissing the notification.</span></span>

> [!NOTE]
> <span data-ttu-id="7a0c3-202">設定できるボタン (後述のコンキスト メニュー項目を含む) の数は最大 5 つです。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-202">You can only have up to 5 buttons (including context menu items which we discuss later).</span></span>

<img alt="notification with actions, example 1" src="images/adaptivetoasts-xmlsample02.jpg" width="364"/>

```csharp
ToastContent content = new ToastContent()
{
    ...
 
    Actions = new ToastActionsCustom()
    {
        Buttons =
        {
            new ToastButton("See more details", "action=viewdetails&contentId=351")
            {
                ActivationType = ToastActivationType.Foreground
            },

            new ToastButton("Remind me later", "action=remindlater&contentId=351")
            {
                ActivationType = ToastActivationType.Background
            }
        }
    }
};
```

```xml
<toast launch="app-defined-string">

    ...

    <actions>

        <action
            content="See more details"
            arguments="action=viewdetails&amp;contentId=351"
            activationType="foreground"/>

        <action
            content="Remind me later"
            arguments="action=remindlater&amp;contentId=351"
            activationType="background"/>

    </actions>

</toast>
```


### <a name="buttons-with-icons"></a><span data-ttu-id="7a0c3-203">アイコンの付いたボタン</span><span class="sxs-lookup"><span data-stu-id="7a0c3-203">Buttons with icons</span></span>

<span data-ttu-id="7a0c3-204">ボタンにはアイコンを追加することができます。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-204">You can add icons to your buttons.</span></span> <span data-ttu-id="7a0c3-205">これらのアイコンは、100% のスケーリングで 16 x 16 ピクセルの白い透明な画像であり、画像自体にパディングを含めることはできません。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-205">These icons are white transparent 16x16 pixel images at 100% scaling, and should have no padding included in the image itself.</span></span> <span data-ttu-id="7a0c3-206">トースト通知にアイコンを表示する場合、ボタンのスタイルがアイコン ボタンに変更されるため、通知内のすべてのボタンに対してアイコンを表示する必要があります。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-206">If you choose to provide icons on a toast notification, you must provide icons for ALL of your buttons in the notification, as it transforms the style of your buttons into icon buttons.</span></span>

> [!NOTE]
> <span data-ttu-id="7a0c3-207">アクセシビリティを確保するため、ユーザーが "ハイ コントラスト 白" モードをオンにしてもアイコンが見えるように、必ずコントラスト (白) バージョンのアイコン (白い背景に黒いアイコン) を指定します。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-207">For accessibility, be sure to include a contrast-white version of the icon (a black icon for white backgrounds), so that when the user turns on High Contrast White mode, your icon is visible.</span></span> <span data-ttu-id="7a0c3-208">詳しくは、[トーストのアクセシビリティに関するページ](tile-toast-language-scale-contrast.md)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-208">Learn more on the [toast accessiblity page](tile-toast-language-scale-contrast.md).</span></span>

<img src="images\adaptivetoasts-buttonswithicons.png" width="364" alt="Toast that has buttons with icons"/>

```csharp
new ToastButton("Dismiss", "dismiss")
{
    ActivationType = ToastActivationType.Background,
    ImageUri = "Assets/ToastButtonIcons/Dismiss.png"
}
```


```xml
<action
    content="Dismiss"
    imageUri="Assets/ToastButtonIcons/Dismiss.png"
    arguments="dismiss"
    activationType="background"/>
```


### <a name="buttons-with-pending-update-activation"></a><span data-ttu-id="7a0c3-209">更新の保留アクティブ化機能を備えたボタン</span><span class="sxs-lookup"><span data-stu-id="7a0c3-209">Buttons with pending update activation</span></span>

<span data-ttu-id="7a0c3-210">**Fall Creators Update の新機能**: バックグラウンドのアクティブ化ボタンで、**PendingUpdate** のアクティブ化後の動作を使用して、トースト通知で複数ステップの対話を作成できます。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-210">**New in Fall Creators Update**: On background activation buttons, you can use an after activation behavior of **PendingUpdate** to create multi-step interactions in your toast notifications.</span></span> <span data-ttu-id="7a0c3-211">ユーザーがボタンをクリックすると、バックグラウンド タスクがアクティブ化し、トーストが "更新の保留中" 状態になります。トーストは、バックグラウンド タスクによって新しいトーストに置き換えられるまで、表示されたままになります。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-211">When the user clicks your button, your background task is activated, and the toast gets placed in a "pending update" state, where it stays on screen till your background task replaces the toast with a new toast.</span></span>

<span data-ttu-id="7a0c3-212">この機能を実装する方法については、[トーストの更新の保留に関するページ](toast-pending-update.md)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-212">To learn how to implement this, see [Toast pending update](toast-pending-update.md).</span></span>

![更新の保留を使ったトースト](images/toast-pendingupdate.gif)


### <a name="context-menu-actions"></a><span data-ttu-id="7a0c3-214">コンテキスト メニューのアクション</span><span class="sxs-lookup"><span data-stu-id="7a0c3-214">Context menu actions</span></span>

<span data-ttu-id="7a0c3-215">**Anniversary Update の新機能**: ユーザーがアクション センター内でトーストを右クリックしたときに表示される追加のコンテキスト メニュー アクションを既存のコンテキスト メニューに追加できます。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-215">**New in Anniversary Update**: You can add additional context menu actions to the existing context menu that appears when the user right clicks your toast from within Action Center.</span></span> <span data-ttu-id="7a0c3-216">このメニューは、アクション センターで右クリックした場合にのみ表示されることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-216">Note that this menu only appears when right clicked from Action Center.</span></span> <span data-ttu-id="7a0c3-217">トーストのポップアップ バナーを右クリックしても表示されません。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-217">It does not appear when right clicking a toast popup banner.</span></span>

> [!NOTE]
> <span data-ttu-id="7a0c3-218">従来のデバイスでは、これらの追加のコンテキスト メニュー アクションが、単に通常のボタンとしてトースト上に表示されます。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-218">On older devices, these additional context menu actions will simply appear as normal buttons on your toast.</span></span>

<span data-ttu-id="7a0c3-219">追加した別のコンテキスト メニュー アクション ("場所の変更" など) は、2 つの既定のシステム エントリの上に表示されます。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-219">The additional context menu actions you add (like "Change location") appear above the two default system entries.</span></span>

<img alt="Toast with context menu" src="images/toast-contextmenu.png" width="444"/>

```csharp
ToastContent content = new ToastContent()
{
    ...
 
    Actions = new ToastActionsCustom()
    {
        ContextMenuItems =
        {
            new ToastContextMenuItem("Change location", "action=changeLocation")
        }
    }
};
```

```xml
<toast>

    ...

    <actions>

        <action
            placement="contextMenu"
            content="Change location"
            arguments="action=changeLocation"/>

    </actions>

</toast>
```

> [!NOTE]
> <span data-ttu-id="7a0c3-220">追加のコンテキスト メニュー項目は、トーストの合計ボタン数の上限である 5 つのボタンに含まれます。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-220">Additional context menu items contribute to the total limit of 5 buttons on a toast.</span></span>

<span data-ttu-id="7a0c3-221">追加のコンテキスト メニュー項目のアクティブ化は、トーストのボタンと同じ手順で処理されます。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-221">Activation of additional context menu items is handled identical to toast buttons.</span></span>


## <a name="inputs"></a><span data-ttu-id="7a0c3-222">入力</span><span class="sxs-lookup"><span data-stu-id="7a0c3-222">Inputs</span></span>

<span data-ttu-id="7a0c3-223">入力はトーストのトースト領域の Actions 領域内で指定します。つまり、これらはトーストが展開されたときにのみ表示されます。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-223">Inputs are specified within the Actions region of the toast region of the toast, meaning they are only visible when the toast is expanded.</span></span>


### <a name="quick-reply-text-box"></a><span data-ttu-id="7a0c3-224">クイック返信テキスト ボックス</span><span class="sxs-lookup"><span data-stu-id="7a0c3-224">Quick reply text box</span></span>

<span data-ttu-id="7a0c3-225">クイック返信テキスト ボックスを有効にするには、メッセージング シナリオの場合と同様、テキスト入力とボタンを追加し、テキスト入力の ID を参照してボタンが入力の横に表示されるようにします。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-225">To enable a quick reply text box, like for a messaging scenario, add a text input and a button, and reference the text input's id so that the button is displayed adjacent to the input.</span></span>

<img alt="notification with text input and actions" src="images/adaptivetoasts-xmlsample05.jpg" width="364"/>

```csharp
ToastContent content = new ToastContent()
{
    ...
 
    Actions = new ToastActionsCustom()
    {
        Inputs =
        {
            new ToastTextBox("tbReply")
            {
                PlaceholderContent = "Type a reply"
            }
        },

        Buttons =
        {
            new ToastButton("Reply", "action=reply&convId=9318")
            {
                ActivationType = ToastActivationType.Background,

                // To place the button next to the text box,
                // reference the text box's Id and provide an image
                TextBoxId = "tbReply",
                ImageUri = "Assets/Reply.png"
            }
        }
    }
};
```

```xml
<toast launch="app-defined-string">

    ...

    <actions>

        <input id="textBox" type="text" placeHolderContent="Type a reply"/>

        <action
            content="Send"
            arguments="action=reply&amp;convId=9318"
            activationType="background"
            hint-inputId="textBox"
            imageUri="Assets/Reply.png"/>

    </actions>

</toast>
```


### <a name="inputs-with-buttons-bar"></a><span data-ttu-id="7a0c3-226">入力とボタン バー</span><span class="sxs-lookup"><span data-stu-id="7a0c3-226">Inputs with buttons bar</span></span>

<span data-ttu-id="7a0c3-227">1 つ (または複数) の入力と、その入力の下に通常のボタンが表示されるように設定することもできます。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-227">You also can have one (or many) inputs with normal buttons displayed below the inputs.</span></span>

<img alt="notification with text and input actions" src="images/adaptivetoasts-xmlsample04.jpg" width="364"/>

```csharp
ToastContent content = new ToastContent()
{
    ...
 
    Actions = new ToastActionsCustom()
    {
        Inputs =
        {
            new ToastTextBox("tbReply")
            {
                PlaceholderContent = "Type a reply"
            }
        },

        Buttons =
        {
            new ToastButton("Reply", "action=reply&threadId=9218")
            {
                ActivationType = ToastActivationType.Background
            },

            new ToastButton("Video call", "action=videocall&threadId=9218")
            {
                ActivationType = ToastActivationType.Foreground
            }
        }
    }
};
```

```xml
<toast launch="app-defined-string">

    ...

    <actions>

        <input id="textBox" type="text" placeHolderContent="Type a reply"/>

        <action
            content="Reply"
            arguments="action=reply&amp;threadId=9218"
            activationType="background"/>

        <action
            content="Video call"
            arguments="action=videocall&amp;threadId=9218"
            activationType="foreground"/>

    </actions>

</toast>
```


### <a name="selection-input"></a><span data-ttu-id="7a0c3-228">選択入力</span><span class="sxs-lookup"><span data-stu-id="7a0c3-228">Selection input</span></span>

<span data-ttu-id="7a0c3-229">テキスト ボックスに加えて、選択メニューを使うこともできます。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-229">In addition to text boxes, you can also use a selection menu.</span></span>

<img alt="notification with selection input and actions" src="images/adaptivetoasts-xmlsample06.jpg" width="364"/>

```csharp
ToastContent content = new ToastContent()
{
    ...
 
    Actions = new ToastActionsCustom()
    {
        Inputs =
        {
            new ToastSelectionBox("time")
            {
                DefaultSelectionBoxItemId = "lunch",
                Items =
                {
                    new ToastSelectionBoxItem("breakfast", "Breakfast"),
                    new ToastSelectionBoxItem("lunch", "Lunch"),
                    new ToastSelectionBoxItem("dinner", "Dinner")
                }
            }
        },

        Buttons = { ... }
};
```

```xml
<toast launch="app-defined-string">

    ...

    <actions>

        <input id="time" type="selection" defaultInput="lunch">
            <selection id="breakfast" content="Breakfast" />
            <selection id="lunch" content="Lunch" />
            <selection id="dinner" content="Dinner" />
        </input>

        ...

    </actions>

</toast>
```


### <a name="snoozedismiss"></a><span data-ttu-id="7a0c3-230">[一時停止する] と [無視]</span><span class="sxs-lookup"><span data-stu-id="7a0c3-230">Snooze/dismiss</span></span>

<span data-ttu-id="7a0c3-231">選択メニューと 2 つのボタンを使って、システムの再通知操作と無視操作を利用するリマインダー通知を作成できます。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-231">Using a selection menu and two buttons, we can create a reminder notification that utilizes the system snooze and dismiss actions.</span></span> <span data-ttu-id="7a0c3-232">通知をリマインダーのように動作するように、必ずシナリオに Reminder を設定します。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-232">Make sure to set the scenario to Reminder for the notification to behave like a reminder.</span></span>

<img alt="reminder notification" src="images/adaptivetoasts-xmlsample07.jpg" width="364"/>

<span data-ttu-id="7a0c3-233">ここでは、トースト ボタンで **SelectionBoxId** プロパティを使って、[一時停止] ボタンを選択メニューの入力に関連付けています。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-233">We link the Snooze button to the selection menu input using the **SelectionBoxId** property on the toast button.</span></span>

```csharp
ToastContent content = new ToastContent()
{
    Scenario = ToastScenario.Reminder,

    ...
 
    Actions = new ToastActionsCustom()
    {
        Inputs =
        {
            new ToastSelectionBox("snoozeTime")
            {
                DefaultSelectionBoxItemId = "15",
                Items =
                {
                    new ToastSelectionBoxItem("5", "5 minutes"),
                    new ToastSelectionBoxItem("15", "15 minutes"),
                    new ToastSelectionBoxItem("60", "1 hour"),
                    new ToastSelectionBoxItem("240", "4 hours"),
                    new ToastSelectionBoxItem("1440", "1 day")
                }
            }
        },

        Buttons =
        {
            new ToastButtonSnooze()
            {
                SelectionBoxId = "snoozeTime"
            },
 
            new ToastButtonDismiss()
        }
    }
};
```

```xml
<toast scenario="reminder" launch="action=viewEvent&amp;eventId=1983">
   
  ...
 
  <actions>
     
    <input id="snoozeTime" type="selection" defaultInput="15">
      <selection id="1" content="1 minute"/>
      <selection id="15" content="15 minutes"/>
      <selection id="60" content="1 hour"/>
      <selection id="240" content="4 hours"/>
      <selection id="1440" content="1 day"/>
    </input>
 
    <action activationType="system" arguments="snooze" hint-inputId="snoozeTime" content="" />
 
    <action activationType="system" arguments="dismiss" content=""/>
     
  </actions>
   
</toast>
```

<span data-ttu-id="7a0c3-234">システムの再通知操作と無視操作を使うには、次の手順を実行します。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-234">To use the system snooze and dismiss actions:</span></span>

-   <span data-ttu-id="7a0c3-235">**ToastButtonSnooze** または **ToastButtonDismiss** を指定する</span><span class="sxs-lookup"><span data-stu-id="7a0c3-235">Specify a **ToastButtonSnooze** or **ToastButtonDismiss**</span></span>
-   <span data-ttu-id="7a0c3-236">必要に応じてカスタムのコンテンツ文字列を指定する</span><span class="sxs-lookup"><span data-stu-id="7a0c3-236">Optionally specify a custom content string:</span></span>
    -   <span data-ttu-id="7a0c3-237">文字列を指定しない場合、"Snooze" と "Dismiss" のローカライズされた文字列が自動的に使われます。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-237">If you don't provide a string, we'll automatically use localized strings for "Snooze" and "Dismiss".</span></span>
-   <span data-ttu-id="7a0c3-238">必要に応じて **SelectionBoxId** を指定する</span><span class="sxs-lookup"><span data-stu-id="7a0c3-238">Optionally specify the **SelectionBoxId**:</span></span>
    -   <span data-ttu-id="7a0c3-239">再通知の間隔をユーザーが選ぶのではなく、システム定義の時間間隔 (OS 全体で一貫しています) に応じて 1 回だけ再通知を行う場合は、&lt;input&gt; を指定しないでください。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-239">If you don't want the user to select a snooze interval and instead just want your notification to snooze only once for a system-defined time interval (that is consistent across the OS), then don't construct any &lt;input&gt; at all.</span></span>
    -   <span data-ttu-id="7a0c3-240">再通知の間隔に関する選択項目を指定する場合:</span><span class="sxs-lookup"><span data-stu-id="7a0c3-240">If you want to provide snooze interval selections:</span></span>
        -   <span data-ttu-id="7a0c3-241">再通知操作に **SelectionBoxId** を指定する</span><span class="sxs-lookup"><span data-stu-id="7a0c3-241">Specify **SelectionBoxId** in the snooze action</span></span>
        -   <span data-ttu-id="7a0c3-242">input の id に、再通知操作の **SelectionBoxId** と同じ値を指定する</span><span class="sxs-lookup"><span data-stu-id="7a0c3-242">Match the id of the input with the **SelectionBoxId** of the snooze action</span></span>
        -   <span data-ttu-id="7a0c3-243">**ToastSelectionBoxItem** の値を、再通知の間隔を分単位で表す nonNegativeInteger になるよう指定する</span><span class="sxs-lookup"><span data-stu-id="7a0c3-243">Specify **ToastSelectionBoxItem**'s value to be a nonNegativeInteger which represents snooze interval in minutes.</span></span>



## <a name="audio"></a><span data-ttu-id="7a0c3-244">オーディオ</span><span class="sxs-lookup"><span data-stu-id="7a0c3-244">Audio</span></span>

<span data-ttu-id="7a0c3-245">カスタム オーディオは、Mobile では常にサポートされ、Desktop では Version 1511 (ビルド 10586) 以降でサポートされます。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-245">Custom audio has always been supported by Mobile, and is supported in Desktop Version 1511 (build 10586) or newer.</span></span> <span data-ttu-id="7a0c3-246">カスタム オーディオは次のパスで参照できます。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-246">Custom audio can be referenced via the following paths:</span></span>

-   <span data-ttu-id="7a0c3-247">ms-appx:///</span><span class="sxs-lookup"><span data-stu-id="7a0c3-247">ms-appx:///</span></span>
-   <span data-ttu-id="7a0c3-248">ms-appdata:///</span><span class="sxs-lookup"><span data-stu-id="7a0c3-248">ms-appdata:///</span></span>

<span data-ttu-id="7a0c3-249">または、[ms-winsoundevent の一覧に関するページ](/uwp/schemas/tiles/toastschema/element-audio#attributes-and-elements)から選ぶこともできます。これらは、常に両方のプラットフォームでサポートされます。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-249">Alternatively, you can pick from the [list of ms-winsoundevents](/uwp/schemas/tiles/toastschema/element-audio#attributes-and-elements), which have always been supported on both platforms.</span></span>

```csharp
ToastContent content = new ToastContent()
{
    ...

    Audio = new ToastAudio()
    {
        Src = new Uri("ms-appx:///Assets/NewMessage.mp3")
    }
}
```

```xml
<toast launch="app-defined-string">

    ...

    <audio src="ms-appx:///Assets/NewMessage.mp3"/>

</toast>
```

<span data-ttu-id="7a0c3-250">トースト通知でのオーディオについては、[オーディオ スキーマに関するページ](/uwp/schemas/tiles/toastschema/element-audio)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-250">See the [audio schema page](/uwp/schemas/tiles/toastschema/element-audio) for information on audio in toast notifications.</span></span> <span data-ttu-id="7a0c3-251">カスタム オーディオを使うトーストの送信方法については、[トーストでのカスタム オーディオの使用](custom-audio-on-toasts.md)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-251">To learn how to send a toast using custom audio, see [custom audio on toasts](custom-audio-on-toasts.md).</span></span>


## <a name="alarms-reminders-and-incoming-calls"></a><span data-ttu-id="7a0c3-252">アラーム、リマインダー、着信呼び出し</span><span class="sxs-lookup"><span data-stu-id="7a0c3-252">Alarms, reminders, and incoming calls</span></span>

<span data-ttu-id="7a0c3-253">アラーム、リマインダー、着信呼び出しの通知を作成するには、単にシナリオの値が割り当てられた標準のトースト通知を使います。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-253">To create alarms, reminders, and incoming call notifications, you simply use a normal toast notification with a scenario value assigned to it.</span></span> <span data-ttu-id="7a0c3-254">シナリオはいくつかの動作を調整して、一貫性のある統一されたユーザー エクスペリエンスをもたらします。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-254">The scenario adusts a few behaviors to create a consistent and unified user experience.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="7a0c3-255">リマインダーやアラームを使用する場合、トースト通知に少なくとも 1 つのボタンを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-255">When using Reminder or Alarm, you must provide at least one button on your toast notification.</span></span> <span data-ttu-id="7a0c3-256">そうでない場合、トーストは、標準のトーストとして扱われます。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-256">Otherwise, the toast will be treated as a normal toast.</span></span>

* <span data-ttu-id="7a0c3-257">**Reminder**: 通知は、ユーザーが通知を無視するか、操作を実行するまで画面上に表示されたままになります。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-257">**Reminder**: The notification will stay on screen until the user dismisses it or takes action.</span></span> <span data-ttu-id="7a0c3-258">Windows Mobile では、トーストは既に展開された状態で表示されます。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-258">On Windows Mobile, the toast will also show pre-expanded.</span></span> <span data-ttu-id="7a0c3-259">リマインダー音が再生されます。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-259">A reminder sound will be played.</span></span>
* <span data-ttu-id="7a0c3-260">**Alarm**: リマインダーの動作に加えて、アラームは既定のアラーム音を使ってオーディオをループします。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-260">**Alarm**: In addition to the reminder behaviors, alarms will additionally loop audio with a default alarm sound.</span></span>
* <span data-ttu-id="7a0c3-261">**IncomingCall**: 着信呼び出し通知は、Windows Mobile デバイスでは全画面で表示されます。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-261">**IncomingCall**: Incoming call notifications are displayed full screen on Windows Mobile devices.</span></span> <span data-ttu-id="7a0c3-262">その他の点では、着信音オーディオを使うことと、ボタンのスタイルが異なることを除き、アラームと同じ動作が実行されます。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-262">Otherwise, they have the same behaviors as alarms except they use ringtone audio and their buttons are styled differently.</span></span>

```csharp
ToastContent content = new ToastContent()
{
    Scenario = ToastScenario.Reminder,

    ...
}
```

```xml
<toast scenario="reminder" launch="app-defined-string">

    ...

</toast>
```


## <a name="localization-and-accessibility"></a><span data-ttu-id="7a0c3-263">ローカライズとアクセシビリティ</span><span class="sxs-lookup"><span data-stu-id="7a0c3-263">Localization and accessibility</span></span>

<span data-ttu-id="7a0c3-264">タイルやトーストには、表示言語や、表示倍率、ハイ コントラストなど、実行時のコンテキストに合わせた文字列や画像を読み込むことができます。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-264">Your tiles and toasts can load strings and images tailored for display language, display scale factor, high contrast, and other runtime contexts.</span></span> <span data-ttu-id="7a0c3-265">詳しくは、「[言語、スケール、ハイ コントラストに合わせたタイルとトースト通知のサポート](tile-toast-language-scale-contrast.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-265">For more info, see [Tile and toast notification support for language, scale, and high contrast](tile-toast-language-scale-contrast.md).</span></span>


## <a name="handling-activation"></a><span data-ttu-id="7a0c3-266">アクティブ化の処理</span><span class="sxs-lookup"><span data-stu-id="7a0c3-266">Handling activation</span></span>
<span data-ttu-id="7a0c3-267">トーストのアクティブ化を処理する方法 (ユーザーがトーストをクリックするか、トースト上のボタンをクリックする) については、「[ローカル トースト通知の送信](send-local-toast.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7a0c3-267">To learn how to handle toast activations (the user clicking your toast or buttons on the toast), see [Send local toast](send-local-toast.md).</span></span>
 
## <a name="related-topics"></a><span data-ttu-id="7a0c3-268">関連トピック</span><span class="sxs-lookup"><span data-stu-id="7a0c3-268">Related topics</span></span>

* [<span data-ttu-id="7a0c3-269">ローカル トースト通知の送信</span><span class="sxs-lookup"><span data-stu-id="7a0c3-269">Send a local toast and handle activation</span></span>](send-local-toast.md)
* [<span data-ttu-id="7a0c3-270">GitHub の通知ライブラリ (UWP コミュニティ ツールキットの一部)</span><span class="sxs-lookup"><span data-stu-id="7a0c3-270">Notifications library on GitHub (part of the UWP Community Toolkit)</span></span>](https://github.com/Microsoft/UWPCommunityToolkit/tree/master/Microsoft.Toolkit.Uwp.Notifications)
* [<span data-ttu-id="7a0c3-271">言語、スケール、ハイ コントラストに合わせたタイルとトースト通知のサポート</span><span class="sxs-lookup"><span data-stu-id="7a0c3-271">Tile and toast notification support for language, scale, and high contrast</span></span>](tile-toast-language-scale-contrast.md)
