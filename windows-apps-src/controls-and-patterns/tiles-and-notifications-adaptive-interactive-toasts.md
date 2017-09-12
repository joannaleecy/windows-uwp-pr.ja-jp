---
author: mijacobs
Description: "アダプティブ トースト通知と対話型トースト通知を使うと、より多くのコンテンツやオプションのインライン画像を含み、オプションのユーザー操作を備えた柔軟性のあるポップアップ通知を作成できます。"
title: "アダプティブ トースト通知と対話型トースト通知"
ms.assetid: 1FCE66AF-34B4-436A-9FC9-D0CF4BDA5A01
label: Adaptive and interactive toast notifications
template: detail.hbs
ms.author: mijacobs
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: c8e77773b9118c3177dc958ddc7b51d32a452fa5
ms.sourcegitcommit: 9d1ca16a7edcbbcae03fad50a4a10183a319c63a
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 06/09/2017
---
# <a name="adaptive-and-interactive-toast-notifications"></a><span data-ttu-id="4cd3e-104">アダプティブ トースト通知と対話型トースト通知</span><span class="sxs-lookup"><span data-stu-id="4cd3e-104">Adaptive and interactive toast notifications</span></span>

<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css">

<span data-ttu-id="4cd3e-105">アダプティブ トースト通知と対話型トースト通知を使うと、テキスト、画像、ボタンや入力を含む柔軟性のある通知を作成できます。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-105">Adaptive and interactive toast notifications let you create flexible notifications with text, images, and buttons/inputs.</span></span>

> <span data-ttu-id="4cd3e-106">**重要な API**: [UWP Community Toolkit Notifications NuGet パッケージ](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/)</span><span class="sxs-lookup"><span data-stu-id="4cd3e-106">**Important APIs**: [UWP Community Toolkit Notifications nuget package](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/)</span></span>

> [!NOTE]
> <span data-ttu-id="4cd3e-107">Windows 8.1 や Windows Phone 8.1 の従来のテンプレートについては、「[トースト テンプレート カタログ (Windows ランタイム アプリ)](https://msdn.microsoft.com/library/windows/apps/hh761494)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-107">To see the legacy templates from Windows 8.1 and Windows Phone 8.1, see the [legacy toast template catalog](https://msdn.microsoft.com/library/windows/apps/hh761494).</span></span>


## <a name="getting-started"></a><span data-ttu-id="4cd3e-108">概要</span><span class="sxs-lookup"><span data-stu-id="4cd3e-108">Getting started</span></span>

**<span data-ttu-id="4cd3e-109">Notifications ライブラリをインストールします。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-109">Install Notifications library.</span></span>** <span data-ttu-id="4cd3e-110">XML の代わりに C# を使って通知を生成する場合は、[Microsoft.Toolkit.Uwp.Notifications](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/) という名前の NuGet パッケージをインストールします (「notifications uwp」を検索してください)。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-110">If you'd like to use C# instead of XML to generate notifications, install the NuGet package named [Microsoft.Toolkit.Uwp.Notifications](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/) (search for "notifications uwp").</span></span> <span data-ttu-id="4cd3e-111">この記事で示している C# のサンプルでは、NuGet パッケージの Version 1.0.0 を使っています。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-111">The C# samples provided in this article use version 1.0.0 of the NuGet package.</span></span>

**<span data-ttu-id="4cd3e-112">Notifications Visualizer をインストールします。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-112">Install Notifications Visualizer.</span></span>** <span data-ttu-id="4cd3e-113">この無料の UWP アプリは、Visual Studio の XAML エディター/デザイン ビューと同様、トーストの編集時に視覚的なプレビューが即座に表示されるため、対話型トースト通知のデザインに便利です。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-113">This free UWP app helps you design interactive toast notifications by providing an instant visual preview of your toast as you edit it, similar to Visual Studio's XAML editor/design view.</span></span> <span data-ttu-id="4cd3e-114">詳しくは、[このブログ記事](http://blogs.msdn.com/b/tiles_and_toasts/archive/2015/09/22/introducing-notifications-visualizer-for-windows-10.aspx)をご覧ください。Notifications Visualizer は[こちら](https://www.microsoft.com/store/apps/notifications-visualizer/9nblggh5xsl1)からダウンロードできます。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-114">You can read [this blog post](http://blogs.msdn.com/b/tiles_and_toasts/archive/2015/09/22/introducing-notifications-visualizer-for-windows-10.aspx) for more information, and you can download Notifications Visualizer [here](https://www.microsoft.com/store/apps/notifications-visualizer/9nblggh5xsl1).</span></span>


## <a name="sending-a-toast-notification"></a><span data-ttu-id="4cd3e-115">トースト通知の送信</span><span class="sxs-lookup"><span data-stu-id="4cd3e-115">Sending a toast notification</span></span>

<span data-ttu-id="4cd3e-116">通知を送信する方法については、「[ローカル トースト通知の送信](tiles-and-notifications-send-local-toast.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-116">To learn how to send a notification, see [Send local toast](tiles-and-notifications-send-local-toast.md).</span></span> <span data-ttu-id="4cd3e-117">このドキュメントでは、トースト コンテンツの作成についてのみ説明します。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-117">This documentation only covers creating the toast content.</span></span>


## <a name="toast-notification-structure"></a><span data-ttu-id="4cd3e-118">トースト通知の構造体</span><span class="sxs-lookup"><span data-stu-id="4cd3e-118">Toast notification structure</span></span>

<span data-ttu-id="4cd3e-119">トースト通知は、Tag や Group (通知を識別できます) などのいくつかのデータ プロパティと*トースト コンテンツ*を組み合わせたものです。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-119">Toast notifications are a combination of some data properties like Tag/Group (which let you identify the notification) and the *toast content*.</span></span>

<span data-ttu-id="4cd3e-120">トースト通知のコンテンツのコア コンポーネントは次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-120">The core components of toast content are...</span></span>
* <span data-ttu-id="4cd3e-121">**launch**: ユーザーがトーストをクリックしたときにアプリに渡される引数を定義します。これにより、トーストに表示されていた正しいコンテンツにディープ リンクできます。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-121">**launch**: This defines what arguments will be passed back to your app when the user clicks your toast, allowing you to deep link into the correct content that the toast was displaying.</span></span> <span data-ttu-id="4cd3e-122">詳しくは、「[ローカル トースト通知の送信](tiles-and-notifications-send-local-toast.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-122">To learn more, see [Send local toast](tiles-and-notifications-send-local-toast.md).</span></span>
* <span data-ttu-id="4cd3e-123">**visual**: トーストの視覚的な部分 (テキスト、画像、アプリ ロゴを含む汎用バインディングなど) です。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-123">**visual**: The visual portion of the toast, including the generic binding that contains text, images, and app logos.</span></span>
* <span data-ttu-id="4cd3e-124">**actions**: トーストの対話的な部分 (入力やアクションなど) です。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-124">**actions**: The interactive portion of the toast, including inputs and actions.</span></span>
* <span data-ttu-id="4cd3e-125">**audio**: トーストがユーザーに表示されるときに再生されるオーディオを制御します。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-125">**audio**: Controls the audio played when the toast is shown to the user.</span></span>

<span data-ttu-id="4cd3e-126">トースト コンテンツは生の XML で定義されますが、トースト コンテンツを作成するために、[NuGet ライブラリ](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/)を使って C# (または C++) オブジェクト モデルを取得することができます。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-126">The toast content is defined in raw XML, but you can use our [NuGet library](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/) to get a C# (or C++) object model for constructing the toast content.</span></span> <span data-ttu-id="4cd3e-127">この記事では、トースト コンテンツ内に含まれるすべてのものについて説明します。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-127">This article documents everything that goes within the toast content.</span></span>

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

<span data-ttu-id="4cd3e-128">トースト コンテンツの視覚的な表示は、次のようになります。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-128">Here is a visual representation of the toast's content:</span></span>

![トースト通知の構造体](images/adaptivetoasts-structure.jpg)


## <a name="visual"></a><span data-ttu-id="4cd3e-130">視覚</span><span class="sxs-lookup"><span data-stu-id="4cd3e-130">Visual</span></span>

<span data-ttu-id="4cd3e-131">各トーストでは visual を指定する必要があり、この場所で、テキスト、画像、ロゴなどを含めることができる汎用トースト バインディングを提供する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-131">Each toast must specify a visual, where you must provide a generic toast binding, which can contain text, images, logos, and more.</span></span> <span data-ttu-id="4cd3e-132">これらの要素は、デスクトップ、電話、タブレット、Xbox など、さまざまな Windows デバイスでレンダリングされます。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-132">These elements will be rendered on various Windows devices, including desktop, phones, tablets, and Xbox.</span></span>

<span data-ttu-id="4cd3e-133">visual セクションとその子要素でサポートされているすべての属性については、[スキーマのドキュメント](tiles-and-notifications-toast-schema.md#toastvisual)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-133">For all attributes supported in the visual section and its child elements, [see the schema documentation](tiles-and-notifications-toast-schema.md#toastvisual).</span></span>

<span data-ttu-id="4cd3e-134">トースト通知ではアプリの識別情報は、アプリ アイコンによって表示されます。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-134">Your app's identity on the toast notification is conveyed via your app icon.</span></span> <span data-ttu-id="4cd3e-135">ただし、appLogoOverride を使った場合は、テキスト行の下にアプリ名が表示されます。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-135">However, if you use the app logo override, we will display your app name beneath your lines of text.</span></span>

| <span data-ttu-id="4cd3e-136">標準のトースト</span><span class="sxs-lookup"><span data-stu-id="4cd3e-136">Normal toast</span></span>                                                                              | <span data-ttu-id="4cd3e-137">appLogoOverride を使ったトースト</span><span class="sxs-lookup"><span data-stu-id="4cd3e-137">Toast with appLogoOverride</span></span>                                                          |
| ----------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- |
| ![appLogoOverride を使わない通知](images/adaptivetoasts-withoutapplogooverride.jpg) | ![appLogoOverride を使った通知](images/adaptivetoasts-withapplogooverride.jpg) |


## <a name="text-elements"></a><span data-ttu-id="4cd3e-140">テキスト要素</span><span class="sxs-lookup"><span data-stu-id="4cd3e-140">Text elements</span></span>

<span data-ttu-id="4cd3e-141">各トーストには少なくとも 1 つの text 要素が必要で、2 つの text 要素 (すべて [AdaptiveText](tiles-and-notifications-toast-schema.md#adaptivetext) 型) を追加で含めることができます。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-141">Each toast must have at least one text element, and can contain two additional text elements, all of type [AdaptiveText](tiles-and-notifications-toast-schema.md#adaptivetext).</span></span>

![タイトルと説明が含まれたトースト](images/toast-title-and-description.jpg)

<span data-ttu-id="4cd3e-143">Anniversary Update 以降、text で **HintMaxLines** プロパティを使うことによって、表示されるテキストの行数を制御できます。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-143">Since the Anniversary Update, you can control how many lines of text are displayed by using the **HintMaxLines** property on the text.</span></span> <span data-ttu-id="4cd3e-144">既定では、タイトルには最大 2 行のテキストが表示され、各説明行には最大 4 行のテキストが表示されます。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-144">By default, the title displays up to 2 lines of text, and the description lines each display up to 4 lines of text.</span></span>

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


## <a name="app-logo-override"></a><span data-ttu-id="4cd3e-145">アプリ ロゴの上書き</span><span class="sxs-lookup"><span data-stu-id="4cd3e-145">App logo override</span></span>

<span data-ttu-id="4cd3e-146">既定では、トーストにはアプリ ロゴが表示されます。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-146">By default, your toast will display your app's logo.</span></span> <span data-ttu-id="4cd3e-147">ただし、このロゴは独自の [ToastGenericAppLogo](tiles-and-notifications-toast-schema.md#toastgenericapplogo) 画像で上書きできます。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-147">However, you can override this logo with your own [ToastGenericAppLogo](tiles-and-notifications-toast-schema.md#toastgenericapplogo) image.</span></span> <span data-ttu-id="4cd3e-148">たとえば、これがある人からの通知である場合、その人の写真でアプリ ロゴを上書きすることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-148">For example, if this is a notification from a person, we recommend overriding the app logo with a picture of that person.</span></span>

![appLogoOverride を使ったトースト](images/toast-applogooverride.jpg)

<span data-ttu-id="4cd3e-150">**HintCrop** プロパティを使って、画像のトリミングを変更できます。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-150">You can use the **HintCrop** property to change the cropping of the image.</span></span> <span data-ttu-id="4cd3e-151">たとえば、*circle* は丸くトリミングされた画像になります。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-151">For example, *circle* results in a circle-cropped image.</span></span> <span data-ttu-id="4cd3e-152">その他の場合、画像は正方形です。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-152">Otherwise, the image is square.</span></span> <span data-ttu-id="4cd3e-153">画像サイズは 100% のスケーリングで 64 x 64 ピクセルです。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-153">Image dimensions are 64x64 pixels at 100% scaling.</span></span>

```csharp
new ToastBindingGeneric()
{
    ...

    AppLogoOverride = new ToastGenericAppLogo()
    {
        Source = "https://unsplash.it/64?image=883",
        HintCrop = ToastGenericAppLogoCrop.Circle
    }
}
```

```xml
<binding template="ToastGeneric">
    ...
    <image placement="appLogoOverride" hint-crop="circle" src="https://unsplash.it/64?image=883"/>
</binding>
```


## <a name="hero-image"></a><span data-ttu-id="4cd3e-154">ヒーロー イメージ</span><span class="sxs-lookup"><span data-stu-id="4cd3e-154">Hero image</span></span>

<span data-ttu-id="4cd3e-155">**Anniversary Update の新機能**: トーストには、ヒーロー イメージを表示できます。ヒーロー イメージとは、トースト バナー内や、アクション センター内にいるときに、目立つ場所に表示されるおすすめの [ToastGenericHeroImage](tiles-and-notifications-toast-schema.md#toastgenericheroimage) です。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-155">**New in Anniversary Update**: Toasts can display a hero image, which is a featured [ToastGenericHeroImage](tiles-and-notifications-toast-schema.md#toastgenericheroimage) displayed prominently within the toast banner and while inside Action Center.</span></span> <span data-ttu-id="4cd3e-156">画像サイズは 100% のスケーリングで 360 x 180 ピクセルです。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-156">Image dimensions are 360x180 pixels at 100% scaling.</span></span>

![ヒーロー イメージが含まれたトースト](images/toast-heroimage.jpg)

```csharp
new ToastBindingGeneric()
{
    ...

    HeroImage = new ToastHeroImage()
    {
        Source = "https://unsplash.it/360/180?image=1043"
    }
}
```

```xml
<binding template="ToastGeneric">
    ...
    <image placement="hero" src="https://unsplash.it/360/180?image=1043"/>
</binding>
```


## <a name="inline-image"></a><span data-ttu-id="4cd3e-158">インライン画像</span><span class="sxs-lookup"><span data-stu-id="4cd3e-158">Inline image</span></span>

<span data-ttu-id="4cd3e-159">トーストを展開したときに表示される全幅のインライン画像を指定できます。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-159">You can provide a full-width inline-image that appears when you expand the toast.</span></span>

![追加の画像が含まれたトースト](images/toast-additionalimage.jpg)

```csharp
new ToastBindingGeneric()
{
    Children =
    {
        ...

        new AdaptiveImage()
        {
            Source = "https://unsplash.it/360/180?image=1043"
        }
    }
}
```

```xml
<binding template="ToastGeneric">
    ...
    <image src="https://unsplash.it/360/180?image=1043" />
</binding>
```


## <a name="attribution-text"></a><span data-ttu-id="4cd3e-161">属性テキスト</span><span class="sxs-lookup"><span data-stu-id="4cd3e-161">Attribution text</span></span>

<span data-ttu-id="4cd3e-162">**Anniversary Update の新機能**: コンテンツのソースを参照する必要がある場合、属性テキストを使うことができます。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-162">**New in Anniversary Update**: If you need to reference the source of your content, you can use attribution text.</span></span> <span data-ttu-id="4cd3e-163">このテキストは常に、アプリの ID または通知のタイムスタンプと共に通知の下部に表示されます。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-163">This text is always displayed at the bottom of your notification, along with your app's identity or the notification's timestamp.</span></span>

<span data-ttu-id="4cd3e-164">属性テキストをサポートしていない以前のバージョンの Windows では、テキストは単に別のテキスト要素として表示されます (3 つのテキスト要素を最大限に含めていない場合)。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-164">On older versions of Windows that don't support attribution text, the text will simply be displayed as another text element (assuming you don't already have the maximum of three text elements).</span></span>

![属性テキストが含まれたトースト](images/toast-attributiontext.jpg)

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


## <a name="custom-timestamp"></a><span data-ttu-id="4cd3e-166">カスタム タイムスタンプ</span><span class="sxs-lookup"><span data-stu-id="4cd3e-166">Custom timestamp</span></span>

<span data-ttu-id="4cd3e-167">**Creators Update の新機能**: システムが提供するタイムスタンプを、メッセージ、情報、コンテンツが生成された時点を正確に表す独自のタイムスタンプで上書きできるようになりました。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-167">**New in Creators Update**: You can now override the system-provided timestamp with your own timestamp that accurately represents when the message/information/content was generated.</span></span> <span data-ttu-id="4cd3e-168">このタイムスタンプはアクション センターに表示されます。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-168">This timestamp is visible within Action Center.</span></span>

![カスタム タイムスタンプが含まれたトースト](images/toast-customtimestamp.jpg)

<span data-ttu-id="4cd3e-170">カスタム タイムスタンプの使用について詳しくは、[このブログ記事](https://blogs.msdn.microsoft.com/tiles_and_toasts/2017/01/09/custom-timestamp-on-toast-notifications-windows-10-creators-update/)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-170">To learn more about using a custom timestamp, please [see this blog post](https://blogs.msdn.microsoft.com/tiles_and_toasts/2017/01/09/custom-timestamp-on-toast-notifications-windows-10-creators-update/).</span></span>

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


## <a name="adaptive-content"></a><span data-ttu-id="4cd3e-171">アダプティブ コンテンツ</span><span class="sxs-lookup"><span data-stu-id="4cd3e-171">Adaptive content</span></span>

<span data-ttu-id="4cd3e-172">**Anniversary Update の新機能**: 上記で指定したコンテンツ以外に、トーストが展開されたときに表示される追加のアダプティブ コンテンツを表示することもできます。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-172">**New in Anniversary Update**: In addition to the content specified above, you can also display additional adaptive content that is visible when the toast is expanded.</span></span>

<span data-ttu-id="4cd3e-173">この追加コンテンツは Adaptive を使って指定されます。詳しくは、[アダプティブ タイルのドキュメント](tiles-and-notifications-create-adaptive-tiles.md)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-173">This additional content is specified using Adaptive, which you can learn more about by reading the [Adaptive Tiles documentation](tiles-and-notifications-create-adaptive-tiles.md).</span></span>

<span data-ttu-id="4cd3e-174">アダプティブ コンテンツは AdaptiveGroup 内に含める必要があることに注意しください。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-174">Note that any adaptive content must be contained within an AdaptiveGroup.</span></span> <span data-ttu-id="4cd3e-175">それ以外の場合、Adaptive を使ってレンダリングされません。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-175">Otherwise it will not be rendered using adaptive.</span></span>


### <a name="columns-and-text-elements"></a><span data-ttu-id="4cd3e-176">列とテキスト要素</span><span class="sxs-lookup"><span data-stu-id="4cd3e-176">Columns and text elements</span></span>

<span data-ttu-id="4cd3e-177">列といくつかの詳細なアダプティブ テキスト要素が使われている例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-177">Here's an example where columns and some advanced adaptive text elements are used.</span></span> <span data-ttu-id="4cd3e-178">テキスト要素は AdaptiveGroup 内にあるので、すべてのリッチ アダプティブ スタイル指定プロパティをサポートします。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-178">Since the text elements are within an AdaptiveGroup, they support all the rich adaptive styling properties.</span></span>

![追加のテキストが含まれたトースト](images/toast-additionaltext.jpg)

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


## <a name="inputs-and-buttons"></a><span data-ttu-id="4cd3e-180">入力とボタン</span><span class="sxs-lookup"><span data-stu-id="4cd3e-180">Inputs and buttons</span></span>

<span data-ttu-id="4cd3e-181">入力とボタンはトーストのトースト領域の Actions 領域内で指定されます。つまり、トーストが展開されたときにのみ表示されます。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-181">Inputs and buttons are specified within the Actions region of the toast region of the toast, meaning they are only visible when the toast is expanded.</span></span>


### <a name="quick-reply-text-box"></a><span data-ttu-id="4cd3e-182">クイック返信テキスト ボックス</span><span class="sxs-lookup"><span data-stu-id="4cd3e-182">Quick reply text box</span></span>

<span data-ttu-id="4cd3e-183">クイック返信テキスト ボックスを有効にするには、メッセージング シナリオの場合と同様、テキスト入力とボタンを追加し、テキスト入力の ID を参照してボタンが入力の横に表示されるようにします。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-183">To enable a quick reply text box, like for a messaging scenario, add a text input and a button, and reference the text input's id so that the button is displayed adjacent to the input.</span></span>

![テキスト入力と操作を使った通知](images/adaptivetoasts-xmlsample05.jpg)

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

        <input id="textBox" type="text" placeholderContent="Type a reply"/>

        <action
            content="Send",
            arguments="action=reply&amp;convId=9318"
            activationType="background"
            hint-inputId="textBox"
            imageUri="Assets/Reply.png"/>

    </actions>

</toast>
```


### <a name="inputs-with-buttons-bar"></a><span data-ttu-id="4cd3e-185">入力とボタンのバー</span><span class="sxs-lookup"><span data-stu-id="4cd3e-185">Inputs with buttons bar</span></span>

<span data-ttu-id="4cd3e-186">1 つ (または複数) の入力と、入力の下に表示する通常のボタンを設定することもできます。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-186">You also can have one (or many) inputs with normal buttons displayed below the inputs.</span></span>

![テキスト入力と操作を使った通知](images/adaptivetoasts-xmlsample04.jpg)

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

        <input id="textBox" type="text" placeholderContent="Type a reply"/>

        <action
            content="Reply",
            arguments="action=reply&amp;threadId=9218"
            activationType="background"/>

        <action
            content="Video call",
            arguments="action=videocall&amp;threadId=9218"
            activationType="foreground"/>

    </actions>

</toast>
```


### <a name="selection-input"></a><span data-ttu-id="4cd3e-188">選択入力</span><span class="sxs-lookup"><span data-stu-id="4cd3e-188">Selection input</span></span>

<span data-ttu-id="4cd3e-189">テキスト ボックスに加えて、選択メニューを使うこともできます。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-189">In addition to text boxes, you can also use a selection menu.</span></span>

![選択入力と操作を使った通知](images/adaptivetoasts-xmlsample06.jpg)

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


## <a name="buttons"></a><span data-ttu-id="4cd3e-191">ボタン</span><span class="sxs-lookup"><span data-stu-id="4cd3e-191">Buttons</span></span>

<span data-ttu-id="4cd3e-192">Buttons を使うとトーストを対話的にすることができ、ユーザーはトースト通知に対してクイック アクションを実行できます。その際、現在のワークフローは中断されません。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-192">Buttons make your toast interactive, letting the user take quick actions on your toast notification without interrupting their current workflow.</span></span> <span data-ttu-id="4cd3e-193">たとえば、ユーザーはトースト内からメッセージに直接返信したり、メール アプリを開かずにメールを削除することができます。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-193">For example, users can reply to a message directly from within a toast, or delete an email without even opening the email app.</span></span>

<span data-ttu-id="4cd3e-194">Buttons は次のようなさまざまな操作を実行できます。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-194">Buttons can perform the following different actions...</span></span>

-   <span data-ttu-id="4cd3e-195">特定のページやコンテキストへの移動に使うことができる引数を指定して、アプリをフォアグラウンドでアクティブ化します。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-195">Activating the app in the foreground, with an argument that can be used to navigate to a specific page/context.</span></span>
-   <span data-ttu-id="4cd3e-196">クイック返信や同様のシナリオで、アプリのバックグラウンド タスクをアクティブ化します。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-196">Activating the app's background task, for a quick-reply or similar scenario.</span></span>
-   <span data-ttu-id="4cd3e-197">プロトコル起動を利用して別のアプリをアクティブ化します。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-197">Activating another app via protocol launch.</span></span>
-   <span data-ttu-id="4cd3e-198">再通知や通知を閉じるなどのシステム操作を実行します。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-198">Performing a system action, like snoozing or dismissing the notification.</span></span>

<span data-ttu-id="4cd3e-199">設定できるボタン (後ほど説明するコンテキスト メニュー項目を含む) の数は最大 5 つであることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-199">Note that you can only have up to 5 buttons (including context menu items which we discuss later).</span></span>

![操作を使った通知の例 1](images/adaptivetoasts-xmlsample02.jpg)

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
            content="See more details",
            arguments="action=viewdetails&amp;contentId=351"
            activationType="foreground"/>

        <action
            content="Remind me later",
            arguments="action=remindlater&amp;contentId=351"
            activationType="background"/>

    </actions>

</toast>
```


### <a name="snoozedismiss-buttons"></a><span data-ttu-id="4cd3e-201">再通知ボタンと閉じるボタン</span><span class="sxs-lookup"><span data-stu-id="4cd3e-201">Snooze/dismiss buttons</span></span>

<span data-ttu-id="4cd3e-202">選択メニューと 2 つのボタンを使って、システムの再通知操作と閉じる操作を利用するリマインダー通知を作成できます。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-202">Using a selection menu and two buttons, we can create a reminder notification that utilizes the system snooze and dismiss actions.</span></span> <span data-ttu-id="4cd3e-203">シナリオに Reminder を設定して、通知がリマインダーのように動作するようにしてください。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-203">Make sure to set the scenario to Reminder for the notification to behave like a reminder.</span></span>

![リマインダー通知](images/adaptivetoasts-xmlsample07.jpg)

<span data-ttu-id="4cd3e-205">ここでは、トースト ボタンに *SelectionBoxId* プロパティを使って、[Snooze] (再通知) ボタンを選択メニューの入力に関連付けています。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-205">We link the Snooze button to the selection menu input using the *SepectionBoxId* property on the toast button.</span></span>

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

<span data-ttu-id="4cd3e-206">システムの再通知操作と閉じる操作を使うには、次の操作を行います。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-206">To use the system snooze and dismiss actions, do the following:</span></span>

-   <span data-ttu-id="4cd3e-207">ToastButtonSnooze または ToastButtonDismiss を指定する</span><span class="sxs-lookup"><span data-stu-id="4cd3e-207">Specify a ToastButtonSnooze or ToastButtonDismiss</span></span>
-   <span data-ttu-id="4cd3e-208">必要に応じてカスタムのコンテンツ文字列を指定する</span><span class="sxs-lookup"><span data-stu-id="4cd3e-208">Optionally specify a custom content string:</span></span>
    -   <span data-ttu-id="4cd3e-209">文字列を指定しない場合、"Snooze" と "Dismiss" のローカライズされた文字列が自動的に使われます。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-209">If you don't provide a string, we'll automatically use localized strings for "Snooze" and "Dismiss".</span></span>
-   <span data-ttu-id="4cd3e-210">必要に応じて *SelectionBoxId* を指定する</span><span class="sxs-lookup"><span data-stu-id="4cd3e-210">Optionally specify the *SelectionBoxId*:</span></span>
    -   <span data-ttu-id="4cd3e-211">再通知の間隔をユーザーが選ぶのではなく、システム定義の時間間隔 (OS 全体で一貫しています) に応じて 1 回だけ再通知を行う場合は、&lt;input&gt; を指定しないでください。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-211">If you don't want the user to select a snooze interval and instead just want your notification to snooze only once for a system-defined time interval (that is consistent across the OS), then don't construct any &lt;input&gt; at all.</span></span>
    -   <span data-ttu-id="4cd3e-212">再通知の間隔に関する選択項目を指定する場合:</span><span class="sxs-lookup"><span data-stu-id="4cd3e-212">If you want to provide snooze interval selections:</span></span>
        -   <span data-ttu-id="4cd3e-213">再通知操作に *SelectionBoxId* を指定する</span><span class="sxs-lookup"><span data-stu-id="4cd3e-213">Specify *SelectionBoxId* in the snooze action</span></span>
        -   <span data-ttu-id="4cd3e-214">input の id に、再通知操作の *SelectionBoxId* と同じ値を指定する</span><span class="sxs-lookup"><span data-stu-id="4cd3e-214">Match the id of the input with the *SelectionBoxId* of the snooze action</span></span>
        -   <span data-ttu-id="4cd3e-215">*ToastSelectionBoxItem* の値を、再通知の間隔を分単位で表す nonNegativeInteger になるよう指定する</span><span class="sxs-lookup"><span data-stu-id="4cd3e-215">Specify *ToastSelectionBoxItem*'s value to be a nonNegativeInteger which represents snooze interval in minutes.</span></span>



## <a name="audio"></a><span data-ttu-id="4cd3e-216">オーディオ</span><span class="sxs-lookup"><span data-stu-id="4cd3e-216">Audio</span></span>

<span data-ttu-id="4cd3e-217">カスタム オーディオは、Mobile では常にサポートされ、Desktop では Version 1511 (ビルド 10586) 以降でサポートされます。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-217">Custom audio has always been supported by Mobile, and is supported in Desktop Version 1511 (build 10586) or newer.</span></span> <span data-ttu-id="4cd3e-218">カスタム オーディオは次のパスで参照できます。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-218">Custom audio can be referenced via the following paths:</span></span>

-   <span data-ttu-id="4cd3e-219">ms-appx:///</span><span class="sxs-lookup"><span data-stu-id="4cd3e-219">ms-appx:///</span></span>
-   <span data-ttu-id="4cd3e-220">ms-appdata:///</span><span class="sxs-lookup"><span data-stu-id="4cd3e-220">ms-appdata:///</span></span>

<span data-ttu-id="4cd3e-221">または、[ms-winsoundevent の一覧に関するページ](https://msdn.microsoft.com/library/windows/apps/br230842)から選ぶこともできます。これらは、常に両方のプラットフォームでサポートされます。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-221">Alternatively, you can pick from the [list of ms-winsoundevents](https://msdn.microsoft.com/library/windows/apps/br230842), which have always been supported on both platforms.</span></span>

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

<span data-ttu-id="4cd3e-222">トースト通知でのオーディオについては、[オーディオ スキーマに関するページ](https://msdn.microsoft.com/library/windows/apps/br230842)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-222">See the [audio schema page](https://msdn.microsoft.com/library/windows/apps/br230842) for information on audio in toast notifications.</span></span> <span data-ttu-id="4cd3e-223">カスタム オーディオを使うトーストを送信する方法については、[このブログ記事](https://blogs.msdn.microsoft.com/tiles_and_toasts/2016/06/18/quickstart-sending-a-toast-notification-with-custom-audio/)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-223">To learn how to send a toast using custom audio, [see this blog post](https://blogs.msdn.microsoft.com/tiles_and_toasts/2016/06/18/quickstart-sending-a-toast-notification-with-custom-audio/).</span></span>


## <a name="alarms-reminders-and-incoming-calls"></a><span data-ttu-id="4cd3e-224">アラーム、リマインダー、着信呼び出し</span><span class="sxs-lookup"><span data-stu-id="4cd3e-224">Alarms, reminders, and incoming calls</span></span>

<span data-ttu-id="4cd3e-225">アラーム、リマインダー、着信呼び出しの通知を作成するには、単にシナリオの値が割り当てられた標準のトースト通知を使います。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-225">To create alarms, reminders, and incoming call notifications, you simply use a normal toast notification with a scenario value assigned to it.</span></span> <span data-ttu-id="4cd3e-226">シナリオではいくつかの動作を調整し、一貫性のある統一されたユーザー エクスペリエンスを作成します。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-226">The scenario adusts a few behaviors to create a consistent and unified user experience.</span></span>

* <span data-ttu-id="4cd3e-227">**Reminder**: 通知は、ユーザーが通知を閉じるか、操作を実行するまで画面上に表示されたままになります。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-227">**Reminder**: The notification will stay on screen until the user dismisses it or takes action.</span></span> <span data-ttu-id="4cd3e-228">Windows Mobile では、トーストは既に展開された状態で表示されます。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-228">On Windows Mobile, the toast will also show pre-expanded.</span></span> <span data-ttu-id="4cd3e-229">リマインダー音が再生されます。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-229">A reminder sound will be played.</span></span>
* <span data-ttu-id="4cd3e-230">**Alarm**: リマインダーの動作に加えて、アラームは既定のアラーム音を使ってオーディオをループします。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-230">**Alarm**: In addition to the reminder behaviors, alarms will additionally loop audio with a default alarm sound.</span></span>
* <span data-ttu-id="4cd3e-231">**IncomingCall**: 着信呼び出し通知は、Windows Mobile デバイスでは全画面で表示されます。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-231">**IncomingCall**: Incoming call notifications are displayed full screen on Windows Mobile devices.</span></span> <span data-ttu-id="4cd3e-232">その他の点では、着信音オーディオを使う点を除き、アラームと同じ動作です。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-232">Otherwise, they have the same behaviors as alarms except they use ringtone audio.</span></span>

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


## <a name="handling-activation"></a><span data-ttu-id="4cd3e-233">アクティブ化の処理</span><span class="sxs-lookup"><span data-stu-id="4cd3e-233">Handling activation</span></span>
<span data-ttu-id="4cd3e-234">トーストのアクティブ化を処理する方法 (ユーザーがトーストをクリックするか、トースト上のボタンをクリックする) については、「[ローカル トースト通知の送信](tiles-and-notifications-send-local-toast.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4cd3e-234">To learn how to handle toast activations (the user clicking your toast or buttons on the toast), see [Send local toast](tiles-and-notifications-send-local-toast.md).</span></span>


 
## <a name="related-topics"></a><span data-ttu-id="4cd3e-235">関連トピック</span><span class="sxs-lookup"><span data-stu-id="4cd3e-235">Related topics</span></span>

* [<span data-ttu-id="4cd3e-236">ローカル トースト通知の送信</span><span class="sxs-lookup"><span data-stu-id="4cd3e-236">Send a local toast and handle activation</span></span>](tiles-and-notifications-send-local-toast.md)
* [<span data-ttu-id="4cd3e-237">GitHub の Notifications ライブラリ</span><span class="sxs-lookup"><span data-stu-id="4cd3e-237">Notifications library on GitHub</span></span>](https://github.com/Microsoft/UWPCommunityToolkit/tree/dev/Notifications)