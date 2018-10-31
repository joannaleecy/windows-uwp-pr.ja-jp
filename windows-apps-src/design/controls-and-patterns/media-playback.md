---
author: Jwmsft
Description: The media player is used to view and listen to video, audio, and images.
title: メディア プレーヤー
ms.assetid: 9AABB5DE-1D81-4791-AB47-7F058F64C491
dev.assetid: AF2F2008-9B53-430C-BBC3-8888F631B0B0
label: Media player
template: detail.hbs
ms.author: jimwalk
ms.date: 05/19/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 113acbe1f4e9bb3814b2f9b61beb79488995d3e3
ms.sourcegitcommit: ca96031debe1e76d4501621a7680079244ef1c60
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/31/2018
ms.locfileid: "5839943"
---
# <a name="media-player"></a><span data-ttu-id="a188e-103">メディア プレーヤー</span><span class="sxs-lookup"><span data-stu-id="a188e-103">Media player</span></span>



<span data-ttu-id="a188e-104">ビデオやオーディオを表示したり聴いたりするには、メディア プレーヤーを使います。</span><span class="sxs-lookup"><span data-stu-id="a188e-104">The media player is used to view and listen to video and audio.</span></span> <span data-ttu-id="a188e-105">メディアはインラインで (ページに埋め込むか、その他のコントロールのグループを使う) 再生するか、専用の全画面表示で再生できます。</span><span class="sxs-lookup"><span data-stu-id="a188e-105">Media playback can be inline (embedded in a page or with a group of other controls) or in a dedicated full-screen view.</span></span> <span data-ttu-id="a188e-106">プレーヤーのボタン セットやコントロール バーの背景を変更したり、必要に応じてレイアウトを整理したりできます。</span><span class="sxs-lookup"><span data-stu-id="a188e-106">You can modify the player's button set, change the background of the control bar, and arrange layouts as you see fit.</span></span> <span data-ttu-id="a188e-107">ユーザーが必要とするのは基本的なコントロール セット (再生/一時停止、巻き戻し、早送り) です。</span><span class="sxs-lookup"><span data-stu-id="a188e-107">Just keep in mind that users expect a basic control set (play/pause, skip back, skip forward).</span></span>

![トランスポート コントロールを含むメディア プレーヤー要素](images/controls/mtc_double_video_inprod.png)

> <span data-ttu-id="a188e-109">**重要な API**: [MediaPlayerElement クラス](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.aspx)、[MediaTransportControls クラス](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediatransportcontrols)</span><span class="sxs-lookup"><span data-stu-id="a188e-109">**Important APIs**: [MediaPlayerElement class](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.aspx), [MediaTransportControls class](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediatransportcontrols)</span></span>


> [!NOTE]
> <span data-ttu-id="a188e-110">**MediaPlayerElement** は Windows 10 バージョン 1607 以降でのみ使用できます。</span><span class="sxs-lookup"><span data-stu-id="a188e-110">**MediaPlayerElement** is only available in Windows 10, version 1607 and up.</span></span> <span data-ttu-id="a188e-111">Windows 10 の以前のバージョン用にアプリを開発する場合は、代わりに [MediaElement](https://msdn.microsoft.com/library/windows/apps/br242926) を使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="a188e-111">If you are developing an app for an earlier version of Windows 10 you will need to use [MediaElement](https://msdn.microsoft.com/library/windows/apps/br242926) instead.</span></span> <span data-ttu-id="a188e-112">このページの推奨事項はすべて MediaElement にも適用されます。</span><span class="sxs-lookup"><span data-stu-id="a188e-112">All of the recommendations on this page apply to MediaElement as well.</span></span>

## <a name="is-this-the-right-control"></a><span data-ttu-id="a188e-113">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="a188e-113">Is this the right control?</span></span>

<span data-ttu-id="a188e-114">アプリでオーディオまたはビデオを再生する場合は、メディア プレーヤーを使います。</span><span class="sxs-lookup"><span data-stu-id="a188e-114">Use a media player when you want to play audio or video in your app.</span></span> <span data-ttu-id="a188e-115">画像のコレクションを表示するには、[フリップ ビュー](flipview.md)を使います。</span><span class="sxs-lookup"><span data-stu-id="a188e-115">To display a collection of images, use a [Flip view](flipview.md).</span></span>

## <a name="examples"></a><span data-ttu-id="a188e-116">例</span><span class="sxs-lookup"><span data-stu-id="a188e-116">Examples</span></span>

<table>
<th align="left"><span data-ttu-id="a188e-117">XAML コントロール ギャラリー</span><span class="sxs-lookup"><span data-stu-id="a188e-117">XAML Controls Gallery</span></span><th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><span data-ttu-id="a188e-118"><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックしてアプリを開き、<a href="xamlcontrolsgallery:/item/MediaPlayerElement">MediaPlayerElement</a> または <a href="xamlcontrolsgallery:/item/MediaPlayer">MediaPlayer</a> の動作を確認してください。</span><span class="sxs-lookup"><span data-stu-id="a188e-118">If you have the <strong style="font-weight: semi-bold">XAML Controls Gallery</strong> app installed, click here to open the app and see the <a href="xamlcontrolsgallery:/item/MediaPlayerElement">MediaPlayerElement</a> or <a href="xamlcontrolsgallery:/item/MediaPlayer">MediaPlayer</a> in action.</span></span></p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT"><span data-ttu-id="a188e-119">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</span><span class="sxs-lookup"><span data-stu-id="a188e-119">Get the XAML Controls Gallery app (Microsoft Store)</span></span></a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics"><span data-ttu-id="a188e-120">ソース コード (GitHub) を入手する</span><span class="sxs-lookup"><span data-stu-id="a188e-120">Get the source code (GitHub)</span></span></a></li>
    </ul>
</td>
</tr>
</table>

<span data-ttu-id="a188e-121">Windows 10 Get Started アプリのメディア プレイヤー。</span><span class="sxs-lookup"><span data-stu-id="a188e-121">A media player in the Windows 10 Get Started app.</span></span>

![Windows 10 Get Started アプリのメディア要素](images/control-examples/mtc_getstarted_example.png)

## <a name="create-a-media-player"></a><span data-ttu-id="a188e-123">メディア プレーヤーの作成</span><span class="sxs-lookup"><span data-stu-id="a188e-123">Create a media player</span></span>
<span data-ttu-id="a188e-124">XAML で [MediaPlayerElement](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.aspx) オブジェクトを作成してアプリにメディアを追加し、オーディオやビデオ ファイルを指定する [MediaSource](https://msdn.microsoft.com/library/windows/apps/windows.media.core.mediasource.aspx) に [Source](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.source.aspx) を設定します。</span><span class="sxs-lookup"><span data-stu-id="a188e-124">Add media to your app by creating a [MediaPlayerElement](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.aspx) object in XAML and set the [Source](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.source.aspx) to a [MediaSource](https://msdn.microsoft.com/library/windows/apps/windows.media.core.mediasource.aspx) that points to an audio or video file.</span></span>

<span data-ttu-id="a188e-125">この XAML は [MediaPlayerElement](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.aspx) を作成し、その [Source](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.source.aspx) プロパティをアプリのローカルにあるビデオ ファイルの URI に設定するコードを示します。</span><span class="sxs-lookup"><span data-stu-id="a188e-125">This XAML creates a [MediaPlayerElement](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.aspx) and sets its [Source](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.source.aspx) property to the URI of a video file that's local to the app.</span></span> <span data-ttu-id="a188e-126">ページが読み込まれると、**MediaPlayerElement** によって再生が開始します。</span><span class="sxs-lookup"><span data-stu-id="a188e-126">The **MediaPlayerElement** begins playing when the page loads.</span></span> <span data-ttu-id="a188e-127">メディアがすぐに再生されないようにするには、[AutoPlay](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.autoplay.aspx) プロパティを **false** に設定します。</span><span class="sxs-lookup"><span data-stu-id="a188e-127">To suppress media from starting right away, you can set the [AutoPlay](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.autoplay.aspx) property to **false**.</span></span>

```xaml
<MediaPlayerElement x:Name="mediaSimple"
                    Source="Videos/video1.mp4"
                    Width="400" AutoPlay="True"/>
```

<span data-ttu-id="a188e-128">この XAML は、組み込みのトランスポート コントロールを有効化し、さらに [AutoPlay](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.autoplay.aspx) プロパティを **false** に設定した [MediaPlayerElement](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.aspx) を作成します。</span><span class="sxs-lookup"><span data-stu-id="a188e-128">This XAML creates a [MediaPlayerElement](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.aspx) with the built in transport controls enabled and the [AutoPlay](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.autoplay.aspx) property set to **false.**</span></span>


```xaml
<MediaPlayerElement x:Name="mediaPlayer"
                    Source="Videos/video1.mp4"
                    Width="400"
                    AutoPlay="False"
                    AreTransportControlsEnabled="True"/>
```

### <a name="media-transport-controls"></a><span data-ttu-id="a188e-129">メディア トランスポート コントロール</span><span class="sxs-lookup"><span data-stu-id="a188e-129">Media transport controls</span></span>
<span data-ttu-id="a188e-130">[MediaPlayerElement](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.aspx) には、再生、停止、一時停止、音量、ミュート、シーク (進行状況)、字幕、オーディオ トラックの選択を処理する組み込みのトランスポート コントロールがあります。</span><span class="sxs-lookup"><span data-stu-id="a188e-130">[MediaPlayerElement](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.aspx) has built in transport controls that handle play, stop, pause, volume, mute, seeking/progress, closed captions, and audio track selection.</span></span> <span data-ttu-id="a188e-131">これらのコントロールを有効にするには、[AreTransportControlsEnabled](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.AreTransportControlsEnabled.aspx) を **true** に設定します。</span><span class="sxs-lookup"><span data-stu-id="a188e-131">To enable these controls, set [AreTransportControlsEnabled](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.AreTransportControlsEnabled.aspx) to **true**.</span></span> <span data-ttu-id="a188e-132">これらのコントロールを無効にするには、**AreTransportControlsEnabled** を **false** に設定します。</span><span class="sxs-lookup"><span data-stu-id="a188e-132">To disable them, set **AreTransportControlsEnabled** to **false**.</span></span> <span data-ttu-id="a188e-133">トランスポート コントロールは、[MediaTransportControls](https://msdn.microsoft.com/library/windows/apps/dn831962) クラスで表されます。</span><span class="sxs-lookup"><span data-stu-id="a188e-133">The transport controls are represented by the [MediaTransportControls](https://msdn.microsoft.com/library/windows/apps/dn831962) class.</span></span> <span data-ttu-id="a188e-134">トランスポート コントロールは、そのまま使用することも、さまざまな方法でカスタマイズすることもできます。</span><span class="sxs-lookup"><span data-stu-id="a188e-134">You can use the transport controls as-is, or customize them in various ways.</span></span> <span data-ttu-id="a188e-135">詳しくは、[MediaTransportControls](https://msdn.microsoft.com/library/windows/apps/dn831962) クラスのリファレンスと「[Create custom transport controls](custom-transport-controls.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a188e-135">For more info, see the [MediaTransportControls](https://msdn.microsoft.com/library/windows/apps/dn831962) class reference and [Create custom transport controls](custom-transport-controls.md).</span></span>

<span data-ttu-id="a188e-136">トランスポート コントロールは 1 行および 2 行のレイアウトをサポートします。</span><span class="sxs-lookup"><span data-stu-id="a188e-136">The transport controls support single- and double-row layouts.</span></span> <span data-ttu-id="a188e-137">最初の例は、メディアのタイムラインの左側に再生/一時停止ボタンを配置した 1 行のレイアウトです。</span><span class="sxs-lookup"><span data-stu-id="a188e-137">The first example here is a single-row layout, with the play/pause button located to the left of the media timeline.</span></span> <span data-ttu-id="a188e-138">このレイアウトは、インライン メディア再生とコンパクトな画面に適しています。</span><span class="sxs-lookup"><span data-stu-id="a188e-138">This layout is best reserved for inline media playback and compact screens.</span></span>

![1 行の MTC コントロールの例](images/controls/mtc_single_inprod_02.png)

<span data-ttu-id="a188e-140">ほとんどの使用シナリオ (特に大きな画面) では、2 行のコントロールのレイアウト (下の図) をお勧めします。</span><span class="sxs-lookup"><span data-stu-id="a188e-140">The double-row controls layout (below) is recommended for most usage scenarios, especially on larger screens.</span></span> <span data-ttu-id="a188e-141">このレイアウトでは、コントロールの領域がより多く確保されており、ユーザーが簡単にタイムラインを操作できます。</span><span class="sxs-lookup"><span data-stu-id="a188e-141">This layout provides more space for controls and makes the timeline easier for the user to operate.</span></span>

![携帯電話に表示される 2 行の MTC コントロールの例](images/controls/mtc_double_inprod.png)

**<span data-ttu-id="a188e-143">システム メディア トランスポート コントロール</span><span class="sxs-lookup"><span data-stu-id="a188e-143">System media transport controls</span></span>**

<span data-ttu-id="a188e-144">[MediaPlayerElement](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.aspx) は、システム メディア トランスポート コントロールと自動的に統合されます。</span><span class="sxs-lookup"><span data-stu-id="a188e-144">[MediaPlayerElement](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.aspx) is automatically integrated with the system media transport controls.</span></span> <span data-ttu-id="a188e-145">システム メディア トランスポート コントロールは、キーボードのメディア ボタンなどのハードウェア メディア キーを押すとポップアップするコントロールです。</span><span class="sxs-lookup"><span data-stu-id="a188e-145">The system media transport controls are the controls that pop up when hardware media keys are pressed, such as the media buttons on keyboards.</span></span> <span data-ttu-id="a188e-146">詳しくは、[SystemMediaTransportControls](https://msdn.microsoft.com/library/windows/apps/dn278677) をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a188e-146">For more info, see [SystemMediaTransportControls](https://msdn.microsoft.com/library/windows/apps/dn278677).</span></span>

> <span data-ttu-id="a188e-147">**注**&nbsp;&nbsp; [MediaElement](https://msdn.microsoft.com/library/windows/apps/br242926) は、システム メディア トランスポート コントロールと自動的に統合されないため、自分で接続する必要があります。</span><span class="sxs-lookup"><span data-stu-id="a188e-147">**Note**&nbsp;&nbsp; [MediaElement](https://msdn.microsoft.com/library/windows/apps/br242926) does not automatically integrate with the system media transport controls so you must connect them yourself.</span></span> <span data-ttu-id="a188e-148">詳しくは、「[システム メディア トランスポート コントロール](https://msdn.microsoft.com/library/windows/apps/mt228338)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a188e-148">For more information, see [System Media Transport Controls](https://msdn.microsoft.com/library/windows/apps/mt228338).</span></span>


### <a name="set-the-media-source"></a><span data-ttu-id="a188e-149">メディア ソースを設定する</span><span class="sxs-lookup"><span data-stu-id="a188e-149">Set the media source</span></span>
<span data-ttu-id="a188e-150">ネットワーク上のファイルまたはアプリに埋め込まれたファイルを再生する場合は、ファイルのパスを使用して [Source](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.source.aspx) プロパティを [MediaSource](https://msdn.microsoft.com/library/windows/apps/windows.media.core.mediasource.aspx) に設定します。</span><span class="sxs-lookup"><span data-stu-id="a188e-150">To play files on the network or files embedded with the app, set the [Source](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.source.aspx) property to a [MediaSource](https://msdn.microsoft.com/library/windows/apps/windows.media.core.mediasource.aspx) with the path of the file.</span></span>

<span data-ttu-id="a188e-151">**ヒント:**、インターネットからファイルを開くには、アプリのマニフェスト (Package.appxmanifest) での**インターネット (クライアント)** 機能を宣言する必要があります。</span><span class="sxs-lookup"><span data-stu-id="a188e-151">**Tip**To open files from the internet, you need to declare the **Internet (Client)** capability in your app's manifest (Package.appxmanifest).</span></span> <span data-ttu-id="a188e-152">機能の宣言について詳しくは、「[アプリ機能の宣言](https://msdn.microsoft.com/library/windows/apps/mt270968)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a188e-152">For more info about declaring capabilities, see [App capability declarations](https://msdn.microsoft.com/library/windows/apps/mt270968).</span></span>

 

<span data-ttu-id="a188e-153">次のコードでは、XAML で定義した [MediaPlayerElement](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.aspx) の [Source](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.source.aspx) プロパティを、[TextBox](https://msdn.microsoft.com/library/windows/apps/br209683) に入力したファイルのパスに設定してみます。</span><span class="sxs-lookup"><span data-stu-id="a188e-153">This code attempts to set the [Source](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.source.aspx) property of the [MediaPlayerElement](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.aspx) defined in XAML to the path of a file entered into a [TextBox](https://msdn.microsoft.com/library/windows/apps/br209683).</span></span>

```xaml
<TextBox x:Name="txtFilePath" Width="400"
         FontSize="20"
         KeyUp="TxtFilePath_KeyUp"
         Header="File path"
         PlaceholderText="Enter file path"/>
```

```csharp
private void TxtFilePath_KeyUp(object sender, KeyRoutedEventArgs e)
{
    if (e.Key == Windows.System.VirtualKey.Enter)
    {
        TextBox tbPath = sender as TextBox;

        if (tbPath != null)
        {
            LoadMediaFromString(tbPath.Text);
        }
    }
}

private void LoadMediaFromString(string path)
{
    try
    {
        Uri pathUri = new Uri(path);
        mediaPlayer.Source = MediaSource.CreateFromUri(pathUri);
    }
    catch (Exception ex)
    {
        if (ex is FormatException)
        {
            // handle exception.
            // For example: Log error or notify user problem with file
        }
    }
}
```

<span data-ttu-id="a188e-154">メディア ソースをアプリに埋め込まれたメディア ファイルに設定するには、**ms-appx:///** で始まるパスで [Uri](https://msdn.microsoft.com/library/windows/apps/br226017) を初期化し、その Uri で [MediaSource](https://msdn.microsoft.com/library/windows/apps/windows.media.core.mediasource.aspx) を作成してから、[Source](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.source.aspx) をその Uri に設定します。</span><span class="sxs-lookup"><span data-stu-id="a188e-154">To set the media source to a media file embedded in the app, initialize a [Uri](https://msdn.microsoft.com/library/windows/apps/br226017) with the path prefixed with **ms-appx:///**, create a [MediaSource](https://msdn.microsoft.com/library/windows/apps/windows.media.core.mediasource.aspx) with the Uri and then set the [Source](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.source.aspx) to the Uri.</span></span> <span data-ttu-id="a188e-155">たとえば、**Videos** サブフォルダーにある **video1.mp4** というファイルのパスは、**ms-appx:///Videos/video1.mp4** のようになります。</span><span class="sxs-lookup"><span data-stu-id="a188e-155">For example, for a file called **video1.mp4** that is in a **Videos** subfolder, the path would look like: **ms-appx:///Videos/video1.mp4**</span></span>

<span data-ttu-id="a188e-156">次のコードは、XAML で以前に定義した [MediaPlayerElement](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.aspx) の [Source](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.source.aspx) プロパティを **ms-appx:///Videos/video1.mp4** に設定します。</span><span class="sxs-lookup"><span data-stu-id="a188e-156">This code sets the [Source](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.source.aspx) property of the [MediaPlayerElement](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.aspx) defined previously in XAML to **ms-appx:///Videos/video1.mp4**.</span></span>

```csharp
private void LoadEmbeddedAppFile()
{
    try
    {
        Uri pathUri = new Uri("ms-appx:///Videos/video1.mp4");
        mediaPlayer.Source = MediaSource.CreateFromUri(pathUri);
    }
    catch (Exception ex)
    {
        if (ex is FormatException)
        {
            // handle exception.
            // For example: Log error or notify user problem with file
        }
    }
}
```

### <a name="open-local-media-files"></a><span data-ttu-id="a188e-157">ローカル メディア ファイルを開く</span><span class="sxs-lookup"><span data-stu-id="a188e-157">Open local media files</span></span>
<span data-ttu-id="a188e-158">ローカル システムや OneDrive のファイルを開くには、[FileOpenPicker](https://msdn.microsoft.com/library/windows/apps/br207847) を使ってファイルを取得し、[Source](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.source.aspx) を使ってメディア ソースを設定します。または、プログラムによってユーザーのメディア フォルダーにアクセスすることもできます。</span><span class="sxs-lookup"><span data-stu-id="a188e-158">To open files on the local system or from OneDrive, you can use the [FileOpenPicker](https://msdn.microsoft.com/library/windows/apps/br207847) to get the file and [Source](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.source.aspx) to set the media source, or you can programmatically access the user media folders.</span></span>

<span data-ttu-id="a188e-159">アプリがユーザーの操作なしで、**Music** または **Video** フォルダーにアクセスする必要がある場合、たとえばユーザーのコレクションのすべての音楽ファイルやビデオ ファイルを列挙し、アプリで表示する場合は、**音楽ライブラリ**および**ビデオ ライブラリ**機能を宣言する必要があります。</span><span class="sxs-lookup"><span data-stu-id="a188e-159">If your app needs access without user interaction to the **Music** or **Video** folders, for example, if you are enumerating all the music or video files in the user's collection and displaying them in your app, then you need to declare the **Music Library** and **Video Library** capabilities.</span></span> <span data-ttu-id="a188e-160">詳しくは、「[ミュージック、画像、およびビデオ ライブラリのファイルとフォルダー](https://msdn.microsoft.com/library/windows/apps/mt188703)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a188e-160">For more info, see [Files and folders in the Music, Pictures, and Videos libraries](https://msdn.microsoft.com/library/windows/apps/mt188703).</span></span>

<span data-ttu-id="a188e-161">ユーザーはどのファイルにアクセスしているかを完全に制御できるので、[FileOpenPicker](https://msdn.microsoft.com/library/windows/apps/br207847) には、ユーザーの **Music** または **Video** フォルダーなど、ローカル ファイル システム上のファイルにアクセスするための特別な機能は必要ありません。</span><span class="sxs-lookup"><span data-stu-id="a188e-161">The [FileOpenPicker](https://msdn.microsoft.com/library/windows/apps/br207847) does not require special capabilities to access files on the local file system, such as the user's **Music** or **Video** folders, since the user has complete control over which file is being accessed.</span></span> <span data-ttu-id="a188e-162">セキュリティとプライバシーの観点から、アプリで使用する機能の数は最小限にすることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="a188e-162">From a security and privacy standpoint, it is best to minimize the number of capabilities your app uses.</span></span>

**<span data-ttu-id="a188e-163">FileOpenPicker を使用してローカル メディア開くには</span><span class="sxs-lookup"><span data-stu-id="a188e-163">To open local media using FileOpenPicker</span></span>**

1.  <span data-ttu-id="a188e-164">ユーザーがメディア ファイルを選べるようにするには、[FileOpenPicker](https://msdn.microsoft.com/library/windows/apps/br207847) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="a188e-164">Call [FileOpenPicker](https://msdn.microsoft.com/library/windows/apps/br207847) to let the user pick a media file.</span></span>

    <span data-ttu-id="a188e-165">[FileOpenPicker](https://msdn.microsoft.com/library/windows/apps/br207847) クラスを使って、メディア ファイルを選びます。</span><span class="sxs-lookup"><span data-stu-id="a188e-165">Use the [FileOpenPicker](https://msdn.microsoft.com/library/windows/apps/br207847) class to select a media file.</span></span> <span data-ttu-id="a188e-166">**FileOpenPicker** が表示するファイルの種類を指定する [FileTypeFilter](https://msdn.microsoft.com/library/windows/apps/br207850) を設定します。</span><span class="sxs-lookup"><span data-stu-id="a188e-166">Set the [FileTypeFilter](https://msdn.microsoft.com/library/windows/apps/br207850) to specify which file types the **FileOpenPicker** displays.</span></span> <span data-ttu-id="a188e-167">[PickSingleFileAsync](https://msdn.microsoft.com/library/windows/apps/jj635275) を呼び出して、ファイル ピッカーを起動し、ファイルを取得します。</span><span class="sxs-lookup"><span data-stu-id="a188e-167">Call [PickSingleFileAsync](https://msdn.microsoft.com/library/windows/apps/jj635275) to launch the file picker and get the file.</span></span>

2.  <span data-ttu-id="a188e-168">[MediaSource](https://msdn.microsoft.com/library/windows/apps/windows.media.core.mediasource.aspx) を使用して、選んだメディア ファイルを [MediaPlayerElement.Source](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.source.aspx) として設定します。</span><span class="sxs-lookup"><span data-stu-id="a188e-168">Use a [MediaSource](https://msdn.microsoft.com/library/windows/apps/windows.media.core.mediasource.aspx) to set the chosen media file as the [MediaPlayerElement.Source](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.source.aspx).</span></span>

    <span data-ttu-id="a188e-169">[FileOpenPicker](https://msdn.microsoft.com/library/windows/apps/br207847) から返された [StorageFile](https://msdn.microsoft.com/library/windows/apps/br227171) を使用するには、[MediaSource](https://msdn.microsoft.com/library/windows/apps/windows.media.core.mediasource.aspx) で [CreateFromStorageFile](https://msdn.microsoft.com/library/windows/apps/windows.media.core.mediasource.createfromstoragefile.aspx) メソッドを呼び出して、それを [MediaPlayerElement](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.aspx) の [Source](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.source.aspx) として設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="a188e-169">To use the [StorageFile](https://msdn.microsoft.com/library/windows/apps/br227171) returned from the [FileOpenPicker](https://msdn.microsoft.com/library/windows/apps/br207847), you need to call the [CreateFromStorageFile](https://msdn.microsoft.com/library/windows/apps/windows.media.core.mediasource.createfromstoragefile.aspx) method on [MediaSource](https://msdn.microsoft.com/library/windows/apps/windows.media.core.mediasource.aspx) and set it as the [Source](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.source.aspx) of [MediaPlayerElement](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.aspx).</span></span> <span data-ttu-id="a188e-170">その後、[MediaPlayerElement.MediaPlayer](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.mediaplayer.aspx) で [Play](https://msdn.microsoft.com/library/windows/apps/windows.media.playback.mediaplayer.play.aspx) を呼び出して、メディアを開始します。</span><span class="sxs-lookup"><span data-stu-id="a188e-170">Then call [Play](https://msdn.microsoft.com/library/windows/apps/windows.media.playback.mediaplayer.play.aspx) on the [MediaPlayerElement.MediaPlayer](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.mediaplayer.aspx) to start the media.</span></span>


<span data-ttu-id="a188e-171">この例は、[FileOpenPicker](https://msdn.microsoft.com/library/windows/apps/br207847) を使ってファイルを選び、そのファイルを [MediaPlayerElement](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.aspx) の [Source](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.source.aspx) に設定する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="a188e-171">This example shows how to use the [FileOpenPicker](https://msdn.microsoft.com/library/windows/apps/br207847) to choose a file and set the file as the [Source](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.source.aspx) of a [MediaPlayerElement](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.aspx).</span></span>

```xaml
<MediaPlayerElement x:Name="mediaPlayer"/>
...
<Button Content="Choose file" Click="Button_Click"/>
```

```csharp
private async void Button_Click(object sender, RoutedEventArgs e)
{
    await SetLocalMedia();
}

async private System.Threading.Tasks.Task SetLocalMedia()
{
    var openPicker = new Windows.Storage.Pickers.FileOpenPicker();

    openPicker.FileTypeFilter.Add(".wmv");
    openPicker.FileTypeFilter.Add(".mp4");
    openPicker.FileTypeFilter.Add(".wma");
    openPicker.FileTypeFilter.Add(".mp3");

    var file = await openPicker.PickSingleFileAsync();

    // mediaPlayer is a MediaPlayerElement defined in XAML
    if (file != null)
    {
        mediaPlayer.Source = MediaSource.CreateFromStorageFile(file);

        mediaPlayer.MediaPlayer.Play();
    }
}
```

### <a name="set-the-poster-source"></a><span data-ttu-id="a188e-172">ポスター ソースを設定する</span><span class="sxs-lookup"><span data-stu-id="a188e-172">Set the poster source</span></span>
<span data-ttu-id="a188e-173">[PosterSource](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.PosterSource.aspx) プロパティを使って、メディアの読み込みが終わるまで  [MediaPlayerElement](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.aspx) に視覚的な表示を提供することができます。</span><span class="sxs-lookup"><span data-stu-id="a188e-173">You can use the [PosterSource](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.PosterSource.aspx) property to provide your [MediaPlayerElement](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.aspx) with a visual representation before the media is loaded.</span></span> <span data-ttu-id="a188e-174">**PosterSource** は、スクリーン ショットや映画のポスターなど、メディアの代わりに表示される画像です。</span><span class="sxs-lookup"><span data-stu-id="a188e-174">A **PosterSource** is an image, such as a screen shot or movie poster, that is displayed in place of the media.</span></span> <span data-ttu-id="a188e-175">**PosterSource** は、次のような状況で表示されます。</span><span class="sxs-lookup"><span data-stu-id="a188e-175">The **PosterSource** is displayed in the following situations:</span></span>

-   <span data-ttu-id="a188e-176">有効なソースが設定されていないとき。</span><span class="sxs-lookup"><span data-stu-id="a188e-176">When a valid source is not set.</span></span> <span data-ttu-id="a188e-177">たとえば、[Source](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.source.aspx) が設定されていないとき、**Source** が **Null** に設定されているとき、またはソースが無効であるとき ([MediaFailed](https://msdn.microsoft.com/library/windows/apps/windows.media.playback.mediaplayer.mediafailed.aspx) イベントが発生したときと同様) です。</span><span class="sxs-lookup"><span data-stu-id="a188e-177">For example, [Source](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.source.aspx) is not set, **Source** was set to **Null**, or the source is invalid (as is the case when a [MediaFailed](https://msdn.microsoft.com/library/windows/apps/windows.media.playback.mediaplayer.mediafailed.aspx) event occurs).</span></span>
-   <span data-ttu-id="a188e-178">メディアの読み込み中。</span><span class="sxs-lookup"><span data-stu-id="a188e-178">While media is loading.</span></span> <span data-ttu-id="a188e-179">たとえば、有効なソースが設定されていても、[MediaOpened](https://msdn.microsoft.com/library/windows/apps/windows.media.playback.mediaplayer.mediaopened.aspx) イベントがまだ発生していないときです。</span><span class="sxs-lookup"><span data-stu-id="a188e-179">For example, a valid source is set, but the [MediaOpened](https://msdn.microsoft.com/library/windows/apps/windows.media.playback.mediaplayer.mediaopened.aspx) event has not occurred yet.</span></span>
-   <span data-ttu-id="a188e-180">別のデバイスにメディアをストリーミングしているとき。</span><span class="sxs-lookup"><span data-stu-id="a188e-180">When media is streaming to another device.</span></span>
-   <span data-ttu-id="a188e-181">メディアがオーディオのみであるとき。</span><span class="sxs-lookup"><span data-stu-id="a188e-181">When the media is audio only.</span></span>

<span data-ttu-id="a188e-182">[Source](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.source.aspx) がアルバムのトラックに設定され、[PosterSource](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.PosterSource.aspx) がアルバムの表紙の画像を設定された [MediaPlayerElement](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.aspx) を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="a188e-182">Here's a [MediaPlayerElement](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.aspx) with its [Source](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.source.aspx) set to an album track, and it's [PosterSource](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.PosterSource.aspx) set to an image of the album cover.</span></span>

```xaml
<MediaPlayerElement Source="Media/Track1.mp4" PosterSource="Media/AlbumCover.png"/>
```

### <a name="keep-the-devices-screen-active"></a><span data-ttu-id="a188e-183">デバイスの画面をアクティブに維持する</span><span class="sxs-lookup"><span data-stu-id="a188e-183">Keep the device's screen active</span></span>
<span data-ttu-id="a188e-184">通常、ユーザーがいないときはバッテリーを節約するために画面が暗くなり、最終的には電源がオフになりますが、ビデオ アプリでは、ユーザーがビデオを見られるように画面をオンのままにしておく必要があります。</span><span class="sxs-lookup"><span data-stu-id="a188e-184">Typically, a device dims the display (and eventually turns it off) to save battery life when the user is away, but video apps need to keep the screen on so the user can see the video.</span></span> <span data-ttu-id="a188e-185">アプリでビデオを再生しているときなど、無操作状態が検出されてもディスプレイの電源が切れないようにするには、[DisplayRequest.RequestActive](https://msdn.microsoft.com/library/windows/apps/br241818) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="a188e-185">To prevent the display from being deactivated when user action is no longer detected, such as when an app is playing video, you can call [DisplayRequest.RequestActive](https://msdn.microsoft.com/library/windows/apps/br241818).</span></span> <span data-ttu-id="a188e-186">[DisplayRequest](https://msdn.microsoft.com/library/windows/apps/br241816) クラスを使うと、ユーザーがビデオを見られるように画面をオンのままにするよう Windows に指示することができます。</span><span class="sxs-lookup"><span data-stu-id="a188e-186">The [DisplayRequest](https://msdn.microsoft.com/library/windows/apps/br241816) class lets you tell Windows to keep the display turned on so the user can see the video.</span></span>

<span data-ttu-id="a188e-187">消費電力とバッテリーの駆動時間を節約するため、不要になったら、[DisplayRequest.RequestRelease](https://msdn.microsoft.com/library/windows/apps/br241819) を呼び出して表示要求を解放してください。</span><span class="sxs-lookup"><span data-stu-id="a188e-187">To conserve power and battery life, you should call [DisplayRequest.RequestRelease](https://msdn.microsoft.com/library/windows/apps/br241819) to release the display request when it is no longer required.</span></span> <span data-ttu-id="a188e-188">Windows は、アプリが画面から消されると自動的にアプリのアクティブな表示要求を非アクティブ化し、アプリがフォアグラウンドに戻ると再びアクティブ化します。</span><span class="sxs-lookup"><span data-stu-id="a188e-188">Windows automatically deactivates your app's active display requests when your app moves off screen, and re-activates them when your app comes back to the foreground.</span></span>

<span data-ttu-id="a188e-189">表示要求を解放する必要があるのは、次のような場合です。</span><span class="sxs-lookup"><span data-stu-id="a188e-189">Here are some situations when you should release the display request:</span></span>

-   <span data-ttu-id="a188e-190">ユーザーの操作、バッファリング、限られた帯域幅のための調整などでビデオの再生が一時停止になる。</span><span class="sxs-lookup"><span data-stu-id="a188e-190">Video playback is paused, for example, by user action, buffering, or adjustment due to limited bandwidth.</span></span>
-   <span data-ttu-id="a188e-191">再生が停止する。</span><span class="sxs-lookup"><span data-stu-id="a188e-191">Playback stops.</span></span> <span data-ttu-id="a188e-192">たとえば、ビデオの再生が完了したり、プレゼンテーションが終了したりする。</span><span class="sxs-lookup"><span data-stu-id="a188e-192">For example, the video is done playing or the presentation is over.</span></span>
-   <span data-ttu-id="a188e-193">再生エラーが発生した。</span><span class="sxs-lookup"><span data-stu-id="a188e-193">A playback error has occurred.</span></span> <span data-ttu-id="a188e-194">たとえば、ネットワーク接続の問題や破損したファイル。</span><span class="sxs-lookup"><span data-stu-id="a188e-194">For example, network connectivity issues or a corrupted file.</span></span>

> <span data-ttu-id="a188e-195">**注**&nbsp;&nbsp; [MediaPlayerElement.IsFullWindow](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.IsFullWindow.aspx) が true に設定されていて、メディアが再生中である場合、ディスプレイは自動的に非アクティブ化されなくなります。</span><span class="sxs-lookup"><span data-stu-id="a188e-195">**Note**&nbsp;&nbsp; If [MediaPlayerElement.IsFullWindow](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.IsFullWindow.aspx) is set to true and media is playing, the display will automatically be prevented from deactivating.</span></span>

**<span data-ttu-id="a188e-196">画面をアクティブに維持するには</span><span class="sxs-lookup"><span data-stu-id="a188e-196">To keep the screen active</span></span>**

1.  <span data-ttu-id="a188e-197">[DisplayRequest](https://msdn.microsoft.com/library/windows/apps/br241816) グローバル変数を作成します。</span><span class="sxs-lookup"><span data-stu-id="a188e-197">Create a global [DisplayRequest](https://msdn.microsoft.com/library/windows/apps/br241816) variable.</span></span> <span data-ttu-id="a188e-198">null に初期化します。</span><span class="sxs-lookup"><span data-stu-id="a188e-198">Initialize it to null.</span></span>
```csharp
// Create this variable at a global scope. Set it to null.
private DisplayRequest appDisplayRequest = null;
```

2.  <span data-ttu-id="a188e-199">[RequestActive](https://msdn.microsoft.com/library/windows/apps/br241818) を呼び出して、アプリで表示をオンのままにする必要があることを Windows に通知します。</span><span class="sxs-lookup"><span data-stu-id="a188e-199">Call [RequestActive](https://msdn.microsoft.com/library/windows/apps/br241818) to notify Windows that the app requires the display to remain on.</span></span>

3.  <span data-ttu-id="a188e-200">ビデオの再生が再生エラーによって停止、一時停止、中断したときには必ず、[RequestRelease](https://msdn.microsoft.com/library/windows/apps/br241819) を呼び出して表示要求を解放します。</span><span class="sxs-lookup"><span data-stu-id="a188e-200">Call [RequestRelease](https://msdn.microsoft.com/library/windows/apps/br241819) to release the display request whenever video playback is stopped, paused, or interrupted by a playback error.</span></span> <span data-ttu-id="a188e-201">アプリにアクティブな表示要求がなくなった場合、Windows は、デバイスが使われていないときには表示を暗くし、最終的には電源をオフにしてバッテリーを節約します。</span><span class="sxs-lookup"><span data-stu-id="a188e-201">When your app no longer has any active display requests, Windows saves battery life by dimming the display (and eventually turning it off) when the device is not being used.</span></span>

    <span data-ttu-id="a188e-202">各 [MediaPlayerElement.MediaPlayer](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.mediaplayer.aspx) には、[PlaybackRate](https://msdn.microsoft.com/library/windows/apps/windows.media.playback.mediaplaybacksession.playbackrate.aspx)、[PlaybackState](https://msdn.microsoft.com/library/windows/apps/windows.media.playback.mediaplaybacksession.playbackstate.aspx)、[Position](https://msdn.microsoft.com/library/windows/apps/windows.media.playback.mediaplaybacksession.position.aspx) など、メディア再生のさまざまな側面を制御する [MediaPlaybackSession](https://msdn.microsoft.com/library/windows/apps/windows.media.playback.mediaplaybacksession.aspx) 型の [PlaybackSession](https://msdn.microsoft.com/library/windows/apps/windows.media.playback.mediaplayer.playbacksession.aspx) があります。</span><span class="sxs-lookup"><span data-stu-id="a188e-202">Each [MediaPlayerElement.MediaPlayer](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.mediaplayer.aspx) has a [PlaybackSession](https://msdn.microsoft.com/library/windows/apps/windows.media.playback.mediaplayer.playbacksession.aspx) of type [MediaPlaybackSession](https://msdn.microsoft.com/library/windows/apps/windows.media.playback.mediaplaybacksession.aspx) that controls various aspects of media playback such as [PlaybackRate](https://msdn.microsoft.com/library/windows/apps/windows.media.playback.mediaplaybacksession.playbackrate.aspx), [PlaybackState](https://msdn.microsoft.com/library/windows/apps/windows.media.playback.mediaplaybacksession.playbackstate.aspx) and [Position](https://msdn.microsoft.com/library/windows/apps/windows.media.playback.mediaplaybacksession.position.aspx).</span></span> <span data-ttu-id="a188e-203">ここでは、[MediaPlayer.PlaybackSession](https://msdn.microsoft.com/library/windows/apps/windows.media.playback.mediaplayer.playbacksession.aspx) で [PlaybackStateChanged](https://msdn.microsoft.com/library/windows/apps/windows.media.playback.mediaplaybacksession.playbackstatechanged.aspx) イベントを使って、表示要求を解放する必要がある状況を検出します。</span><span class="sxs-lookup"><span data-stu-id="a188e-203">Here, you use the [PlaybackStateChanged](https://msdn.microsoft.com/library/windows/apps/windows.media.playback.mediaplaybacksession.playbackstatechanged.aspx) event on  [MediaPlayer.PlaybackSession](https://msdn.microsoft.com/library/windows/apps/windows.media.playback.mediaplayer.playbacksession.aspx) to detect situations when you should release the display request.</span></span> <span data-ttu-id="a188e-204">次に、[NaturalVideoHeight](https://msdn.microsoft.com/library/windows/apps/windows.media.playback.mediaplaybacksession.naturalvideoheight.aspx) プロパティを使って、オーディオ ファイルとビデオ ファイルのどちらが再生されているかを確認し、ビデオが再生されている場合にのみ画面をアクティブなままにします。</span><span class="sxs-lookup"><span data-stu-id="a188e-204">Then, use the [NaturalVideoHeight](https://msdn.microsoft.com/library/windows/apps/windows.media.playback.mediaplaybacksession.naturalvideoheight.aspx) property to determine whether an audio or video file is playing, and keep the screen active only if video is playing.</span></span>
    ```xaml
<MediaPlayerElement x:Name="mpe" Source="Media/video1.mp4"/>
    ```

    ```csharp
    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        mpe.MediaPlayer.PlaybackSession.PlaybackStateChanged += MediaPlayerElement_CurrentStateChanged;
        base.OnNavigatedTo(e);
    }

    private void MediaPlayerElement_CurrentStateChanged(object sender, RoutedEventArgs e)
    {
        MediaPlaybackSession playbackSession = sender as MediaPlaybackSession;
        if (playbackSession != null && playbackSession.NaturalVideoHeight != 0)
        {
            if(playbackSession.PlaybackState == MediaPlaybackState.Playing)
            {
                if(appDisplayRequest == null)
                {
                    // This call creates an instance of the DisplayRequest object
                    appDisplayRequest = new DisplayRequest();
                    appDisplayRequest.RequestActive();
                }
            }
            else // PlaybackState is Buffering, None, Opening or Paused
            {
                if(appDisplayRequest != null)
                {
                      // Deactivate the displayr request and set the var to null
                      appDisplayRequest.RequestRelease();
                      appDisplayRequest = null;
                }
            }
        }

    }
    ```

### <a name="control-the-media-player-programmatically"></a><span data-ttu-id="a188e-205">プログラムでメディア プレーヤーを制御する</span><span class="sxs-lookup"><span data-stu-id="a188e-205">Control the media player programmatically</span></span>
<span data-ttu-id="a188e-206">[MediaPlayerElement](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.aspx) には、[MediaPlayerElement.MediaPlayer](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.mediaplayer.aspx) プロパティを介してオーディオやビデオの再生を制御するプロパティ、メソッド、イベントが多数用意されています。</span><span class="sxs-lookup"><span data-stu-id="a188e-206">[MediaPlayerElement](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.aspx) provides numerous properties, methods, and events for controlling audio and video playback through the [MediaPlayerElement.MediaPlayer](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.mediaplayer.aspx) property.</span></span> <span data-ttu-id="a188e-207">プロパティ、メソッド、イベントの完全な一覧については、[MediaPlayer](https://msdn.microsoft.com/library/windows/apps/windows.media.playback.mediaplayer.aspx) のリファレンス ページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a188e-207">For a full listing of properties, methods, and events, see the [MediaPlayer](https://msdn.microsoft.com/library/windows/apps/windows.media.playback.mediaplayer.aspx) reference page.</span></span>

### <a name="advanced-media-playback-scenarios"></a><span data-ttu-id="a188e-208">高度なメディア再生のシナリオ</span><span class="sxs-lookup"><span data-stu-id="a188e-208">Advanced media playback scenarios</span></span>
<span data-ttu-id="a188e-209">プレイリストを再生するような複雑なメディア再生のシナリオでは、オーディオ言語間を切り替えたり、カスタム メタデータ トラックを作成したりするため、[MediaPlayerElement.Source](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.source.aspx) を [MediaPlaybackItem](https://msdn.microsoft.com/library/windows/apps/windows.media.playback.mediaplaybackitem.aspx) または [MediaPlaybackList](https://msdn.microsoft.com/library/windows/apps/windows.media.playback.mediaplaybacklist.aspx) に設定します。</span><span class="sxs-lookup"><span data-stu-id="a188e-209">For more complex media playback scenarios like playing a playlist, switching between audio languages or creating custom metadata tracks set the [MediaPlayerElement.Source](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.source.aspx) to a [MediaPlaybackItem](https://msdn.microsoft.com/library/windows/apps/windows.media.playback.mediaplaybackitem.aspx) or a [MediaPlaybackList](https://msdn.microsoft.com/library/windows/apps/windows.media.playback.mediaplaybacklist.aspx).</span></span> <span data-ttu-id="a188e-210">さまざまな高度なメディア機能を有効にする方法について詳しくは、デベロッパー センターの [メディアの再生](https://msdn.microsoft.com/windows/uwp/audio-video-camera/media-playback-with-mediasource) のページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a188e-210">See the [Media playback](https://msdn.microsoft.com/windows/uwp/audio-video-camera/media-playback-with-mediasource) page in the dev center for more information on how to enable various advanced media functionality.</span></span>

### <a name="enable-full-window-video-rendering"></a><span data-ttu-id="a188e-211">フル ウィンドウのビデオ レンダリングを有効にする</span><span class="sxs-lookup"><span data-stu-id="a188e-211">Enable full window video rendering</span></span>

<span data-ttu-id="a188e-212">フル ウィンドウのレンダリングを有効または無効にするには、[IsFullWindow](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.isfullwindow.aspx) プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="a188e-212">Set the [IsFullWindow](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.isfullwindow.aspx) property to enable and disable full window rendering.</span></span> <span data-ttu-id="a188e-213">プログラムを使ってアプリにフル ウィンドウのレンダリングを設定する場合、手動で行う代わりに **IsFullWindow** を常に使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="a188e-213">When you programmatically set full window rendering in your app, you should always use **IsFullWindow** instead of doing it manually.</span></span> <span data-ttu-id="a188e-214">**IsFullWindow** により、システム レベルの最適化が実行され、パフォーマンスとバッテリーの寿命が向上します。</span><span class="sxs-lookup"><span data-stu-id="a188e-214">**IsFullWindow** insures that system level optimizations are performed that improve performance and battery life.</span></span> <span data-ttu-id="a188e-215">フル ウィンドウのレンダリングが正しく設定されていない場合、これらの最適化が有効になっていない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="a188e-215">If full window rendering is not set up correctly, these optimizations may not be enabled.</span></span>

<span data-ttu-id="a188e-216">フル ウィンドウのレンダリングを切り替える [AppBarButton](https://msdn.microsoft.com/library/windows/apps/dn279244) を作成するコードを次に示します。</span><span class="sxs-lookup"><span data-stu-id="a188e-216">Here is some code that creates an [AppBarButton](https://msdn.microsoft.com/library/windows/apps/dn279244) that toggles full window rendering.</span></span>

```xaml
<AppBarButton Icon="FullScreen"
              Label="Full Window"
              Click="FullWindow_Click"/>>
```

```csharp
private void FullWindow_Click(object sender, object e)
{
    mediaPlayer.IsFullWindow = !media.IsFullWindow;
}
```

### <a name="resize-and-stretch-video"></a><span data-ttu-id="a188e-217">ビデオのサイズを変更し、拡大する</span><span class="sxs-lookup"><span data-stu-id="a188e-217">Resize and stretch video</span></span>

<span data-ttu-id="a188e-218">[Stretch](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.stretch.aspx) プロパティを使って、コンテナー内でのビデオ コンテンツや [PosterSource](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.postersource.aspx) のサイズを変更します。</span><span class="sxs-lookup"><span data-stu-id="a188e-218">Use the [Stretch](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.stretch.aspx) property to change how the video content and/or the [PosterSource](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.postersource.aspx) fills the container it's in.</span></span> <span data-ttu-id="a188e-219">この要素は、[Stretch](https://msdn.microsoft.com/library/windows/apps/br242968) の値に応じてビデオのサイズ変更と拡大を行います。</span><span class="sxs-lookup"><span data-stu-id="a188e-219">This resizes and stretches the video depending on the [Stretch](https://msdn.microsoft.com/library/windows/apps/br242968) value.</span></span> <span data-ttu-id="a188e-220">**Stretch** 状態は、多くのテレビ セットの画像サイズの設定に似ています。</span><span class="sxs-lookup"><span data-stu-id="a188e-220">The **Stretch** states are similar to picture size settings on many TV sets.</span></span> <span data-ttu-id="a188e-221">ボタンにフックしてユーザーが好みの設定を選ぶことができるようにします。</span><span class="sxs-lookup"><span data-stu-id="a188e-221">You can hook this up to a button and allow the user to choose which setting they prefer.</span></span>

-   <span data-ttu-id="a188e-222">[None](https://msdn.microsoft.com/library/windows/apps/br242968) は、元のサイズでコンテンツのネイティブの解像度を表示します。</span><span class="sxs-lookup"><span data-stu-id="a188e-222">[None](https://msdn.microsoft.com/library/windows/apps/br242968) displays the native resolution of the content in its original size.</span></span>
-   <span data-ttu-id="a188e-223">[Uniform](https://msdn.microsoft.com/library/windows/apps/br242968) は、縦横比、画像コンテンツを維持したままスペースを最大限に使用します。</span><span class="sxs-lookup"><span data-stu-id="a188e-223">[Uniform](https://msdn.microsoft.com/library/windows/apps/br242968) fills up as much of the space as possible while preserving the aspect ratio and the image content.</span></span> <span data-ttu-id="a188e-224">これにより、ビデオの端に水平方向または垂直方向の黒いバーが表示されることがあります。</span><span class="sxs-lookup"><span data-stu-id="a188e-224">This can result in horizontal or vertical black bars at the edges of the video.</span></span> <span data-ttu-id="a188e-225">これはワイドスクリーン モードに似ています。</span><span class="sxs-lookup"><span data-stu-id="a188e-225">This is similar to wide-screen modes.</span></span>
-   <span data-ttu-id="a188e-226">[UniformToFill](https://msdn.microsoft.com/library/windows/apps/br242968) は、縦横比を維持したままスペース全体を使用します。</span><span class="sxs-lookup"><span data-stu-id="a188e-226">[UniformToFill](https://msdn.microsoft.com/library/windows/apps/br242968) fills up the entire space while preserving the aspect ratio.</span></span> <span data-ttu-id="a188e-227">これにより、画像の一部がトリミングされることがあります。</span><span class="sxs-lookup"><span data-stu-id="a188e-227">This can result in some of the image being cropped.</span></span> <span data-ttu-id="a188e-228">これは全画面モードに似ています。</span><span class="sxs-lookup"><span data-stu-id="a188e-228">This is similar to full-screen modes.</span></span>
-   <span data-ttu-id="a188e-229">[Fill](https://msdn.microsoft.com/library/windows/apps/br242968) は、縦横比を維持せずに、スペース全体を使用します。</span><span class="sxs-lookup"><span data-stu-id="a188e-229">[Fill](https://msdn.microsoft.com/library/windows/apps/br242968) fills up the entire space, but does not preserve the aspect ratio.</span></span> <span data-ttu-id="a188e-230">画像はトリミングされませんが、拡大されることがあります。</span><span class="sxs-lookup"><span data-stu-id="a188e-230">None of image is cropped, but stretching may occur.</span></span> <span data-ttu-id="a188e-231">これはストレッチ モードに似ています。</span><span class="sxs-lookup"><span data-stu-id="a188e-231">This is similar to stretch modes.</span></span>

![Stretch 列挙値](images/Image_Stretch.jpg)

<span data-ttu-id="a188e-233">ここでは、[AppBarButton](https://msdn.microsoft.com/library/windows/apps/dn279244) を使って、[Stretch](https://msdn.microsoft.com/library/windows/apps/br242968) オプションを順に切り替えます。</span><span class="sxs-lookup"><span data-stu-id="a188e-233">Here, an [AppBarButton](https://msdn.microsoft.com/library/windows/apps/dn279244) is used to cycle through the [Stretch](https://msdn.microsoft.com/library/windows/apps/br242968) options.</span></span> <span data-ttu-id="a188e-234">**switch** ステートメントは、[Stretch](https://msdn.microsoft.com/library/windows/apps/br227422) プロパティの現在の状態をチェックし、**Stretch** 列挙で次の値を設定します。</span><span class="sxs-lookup"><span data-stu-id="a188e-234">A **switch** statement checks the current state of the [Stretch](https://msdn.microsoft.com/library/windows/apps/br227422) property and sets it to the next value in the **Stretch** enumeration.</span></span> <span data-ttu-id="a188e-235">これにより、ユーザーはさまざまな拡大の状態を順番に表示することができます。</span><span class="sxs-lookup"><span data-stu-id="a188e-235">This lets the user cycle through the different stretch states.</span></span>

```xaml
<AppBarButton Icon="Switch"
              Label="Resize Video"
              Click="PictureSize_Click" />
```

```csharp
private void PictureSize_Click(object sender, RoutedEventArgs e)
{
    switch (mediaPlayer.Stretch)
    {
        case Stretch.Fill:
            mediaPlayer.Stretch = Stretch.None;
            break;
        case Stretch.None:
            mediaPlayer.Stretch = Stretch.Uniform;
            break;
        case Stretch.Uniform:
            mediaPlayer.Stretch = Stretch.UniformToFill;
            break;
        case Stretch.UniformToFill:
            mediaPlayer.Stretch = Stretch.Fill;
            break;
        default:
            break;
    }
}
```

### <a name="enable-low-latency-playback"></a><span data-ttu-id="a188e-236">待機時間が短い再生を可能にする</span><span class="sxs-lookup"><span data-stu-id="a188e-236">Enable low-latency playback</span></span>

<span data-ttu-id="a188e-237">[RealTimePlayback](https://msdn.microsoft.com/library/windows/apps/windows.media.playback.mediaplayer.realtimeplayback.aspx) プロパティを **true** に設定すると、[MediaPlayerElement.MediaPlayer](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.mediaplayer.aspx) の再生の最初の待機時間を短くすることができます。</span><span class="sxs-lookup"><span data-stu-id="a188e-237">Set the [RealTimePlayback](https://msdn.microsoft.com/library/windows/apps/windows.media.playback.mediaplayer.realtimeplayback.aspx) property to **true** on a [MediaPlayerElement.MediaPlayer](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.mediaplayer.aspx) to enable the media player element to reduce the initial latency for playback.</span></span> <span data-ttu-id="a188e-238">これは双方向通信アプリには重要で、ゲームのシナリオにも適用できる場合があります。</span><span class="sxs-lookup"><span data-stu-id="a188e-238">This is critical for two-way communications apps, and can be applicable to some gaming scenarios.</span></span> <span data-ttu-id="a188e-239">このモードでは、リソースがより多く消費され、電力効率が低下する点に注意してください。</span><span class="sxs-lookup"><span data-stu-id="a188e-239">Be aware that this mode is more resource intensive and less power-efficient.</span></span>

<span data-ttu-id="a188e-240">この例では、[MediaPlayerElement](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.aspx) を作って、[RealTimePlayback](https://msdn.microsoft.com/library/windows/apps/windows.media.playback.mediaplayer.realtimeplayback.aspx) を **true** に設定します。</span><span class="sxs-lookup"><span data-stu-id="a188e-240">This example creates a [MediaPlayerElement](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.aspx) and sets [RealTimePlayback](https://msdn.microsoft.com/library/windows/apps/windows.media.playback.mediaplayer.realtimeplayback.aspx) to **true**.</span></span>


```csharp
MediaPlayerElement mp = new MediaPlayerElement();
mp.MediaPlayer.RealTimePlayback = true;
```

## <a name="recommendations"></a><span data-ttu-id="a188e-241">推奨事項</span><span class="sxs-lookup"><span data-stu-id="a188e-241">Recommendations</span></span>

<span data-ttu-id="a188e-242">メディア プレイヤーは淡色テーマと濃色テーマの両方をサポートしていますが、ほとんどのエンターテインメント シナリオでは、濃色テーマを使用することでエクスペリエンスが向上します。</span><span class="sxs-lookup"><span data-stu-id="a188e-242">The media player supports both light and dark themes, but dark theme provides a better experience for most entertainment scenarios.</span></span> <span data-ttu-id="a188e-243">暗い背景を使うと、(特に高感度条件では) コントラストが強調され、表示エクスペリエンスに影響を及ぼすコントロール バーが制限されます。</span><span class="sxs-lookup"><span data-stu-id="a188e-243">The dark background provides better contrast, in particular for low-light conditions, and limits the control bar from interfering in the viewing experience.</span></span>

<span data-ttu-id="a188e-244">ビデオ コンテンツを再生する場合、インライン モードよりも全画面表示モードを促進することにより、専用の表示エクスペリエンスを使うことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="a188e-244">When playing video content, encourage a dedicated viewing experience by promoting full-screen mode over inline mode.</span></span> <span data-ttu-id="a188e-245">全画面表示エクスペリエンスが最適であり、インライン モードではオプションが制限されます。</span><span class="sxs-lookup"><span data-stu-id="a188e-245">The full-screen viewing experience is optimal, and options are restricted in the inline mode.</span></span>

<span data-ttu-id="a188e-246">画面領域がある場合や、10 フィート エクスペリエンス向けに設計する場合は、2 行のレイアウトを採用します。</span><span class="sxs-lookup"><span data-stu-id="a188e-246">If you have the screen real estate or are designing for the 10-foot experience, go with the double-row layout.</span></span> <span data-ttu-id="a188e-247">このレイアウトでは、コンパクトな 1 行のレイアウトよりもコントロールの領域が多く確保され、10 フィート環境ではゲームパッドによる移動が簡単になります。</span><span class="sxs-lookup"><span data-stu-id="a188e-247">It provides more space for controls than the compact single-row layout and it is easier to navigate using gamepad for 10-foot.</span></span>

> <span data-ttu-id="a188e-248">**注**&nbsp;&nbsp; アプリケーションを 10 フィート エクスペリエンスに最適化する方法について詳しくは、「[Xbox およびテレビ向け設計](../devices/designing-for-tv.md)」の記事をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a188e-248">**Note**&nbsp;&nbsp; Visit the [Designing for Xbox and TV](../devices/designing-for-tv.md) article for more information on optimizing your application for the 10-foot experience.</span></span>

<span data-ttu-id="a188e-249">既定のコントロールはメディア再生に最適化されていますが、アプリに最適なエクスペリエンスを実現するために、必要なカスタム オプションをメディア プレーヤーに追加できます。</span><span class="sxs-lookup"><span data-stu-id="a188e-249">The default controls have been optimized for media playback, however you have the ability to add custom options you need to the media player in order to provide the best experience for you app.</span></span> <span data-ttu-id="a188e-250">カスタム コントロールの追加について詳しくは、「[カスタム トランスポート コントロールを作成する](custom-transport-controls.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a188e-250">Visit [Create custom transport controls](custom-transport-controls.md) to learn more about adding custom controls.</span></span>

## <a name="get-the-sample-code"></a><span data-ttu-id="a188e-251">サンプル コードを入手する</span><span class="sxs-lookup"><span data-stu-id="a188e-251">Get the sample code</span></span>

- <span data-ttu-id="a188e-252">[XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - インタラクティブな形で XAML コントロールのすべてを参照できます。</span><span class="sxs-lookup"><span data-stu-id="a188e-252">[XAML Controls Gallery sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - See all the XAML controls in an interactive format.</span></span>

## <a name="related-articles"></a><span data-ttu-id="a188e-253">関連記事</span><span class="sxs-lookup"><span data-stu-id="a188e-253">Related articles</span></span>

- [<span data-ttu-id="a188e-254">UWP アプリのコマンド設計の基本</span><span class="sxs-lookup"><span data-stu-id="a188e-254">Command design basics for UWP apps</span></span>](https://msdn.microsoft.com/library/windows/apps/dn958433)
- [<span data-ttu-id="a188e-255">UWP アプリのコンテンツ デザインの基本</span><span class="sxs-lookup"><span data-stu-id="a188e-255">Content design basics for UWP apps</span></span>](https://msdn.microsoft.com/library/windows/apps/dn958434)
