---
author: TylerMSFT
title: 自動再生による自動起動
description: 自動再生を使って、コンピューターにデバイスが接続されたときのオプションとしてアプリを提供できます。 これには、カメラやメディア プレーヤーなどのボリューム デバイス以外のデバイス、または USB サム ドライブ、SD カード、DVD などのボリューム デバイスが含まれます。
ms.assetid: AD4439EA-00B0-4543-887F-2C1D47408EA7
ms.author: twhitney
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 98c537ef3b2a5d002644cc554eae72b89a1799b0
ms.sourcegitcommit: e2fca6c79f31e521ba76f7ecf343cf8f278e6a15
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/15/2018
ms.locfileid: "6968981"
---
# <a name="span-iddevlaunchresumeauto-launchingwithautoplayspanauto-launching-with-autoplay"></a><span data-ttu-id="b6774-105"><span id="dev_launch_resume.auto-launching_with_autoplay"></span>自動再生による自動起動</span><span class="sxs-lookup"><span data-stu-id="b6774-105"><span id="dev_launch_resume.auto-launching_with_autoplay"></span>Auto-launching with AutoPlay</span></span>

<span data-ttu-id="b6774-106">**自動再生**を使って、コンピューターにデバイスが接続されたときのオプションとしてアプリを提供できます。</span><span class="sxs-lookup"><span data-stu-id="b6774-106">You can use **AutoPlay** to provide your app as an option when a user connects a device to their PC.</span></span> <span data-ttu-id="b6774-107">これには、カメラやメディア プレーヤーなどのボリューム デバイス以外のデバイス、または USB サム ドライブ、SD カード、DVD などのボリューム デバイスが含まれます。</span><span class="sxs-lookup"><span data-stu-id="b6774-107">This includes non-volume devices such as a camera or media player, or volume devices such as a USB thumb drive, SD card, or DVD.</span></span> <span data-ttu-id="b6774-108">また**自動再生**では、近接通信 (タップ) を使って 2 台の PC 間でユーザーがファイルを共有するときにアプリをオプションとして提供することもできます。</span><span class="sxs-lookup"><span data-stu-id="b6774-108">You can also use **AutoPlay** to offer your app as an option when users share files between two PCs by using proximity (tapping).</span></span>

> <span data-ttu-id="b6774-109">**注:** デバイスの製造元がデバイスの**自動再生**ハンドラーとして、 [Microsoft Store デバイス アプリ](http://go.microsoft.com/fwlink/p/?LinkID=301381)を関連付ける場合は、デバイス メタデータでアプリを識別することができます。</span><span class="sxs-lookup"><span data-stu-id="b6774-109">**Note**If you are a device manufacturer and you want to associate your [Microsoft Store device app](http://go.microsoft.com/fwlink/p/?LinkID=301381) as an **AutoPlay** handler for your device, you can identify that app in the device metadata.</span></span> <span data-ttu-id="b6774-110">詳しくは、「[Microsoft Store デバイス アプリの自動再生](http://go.microsoft.com/fwlink/p/?LinkId=306684)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b6774-110">For more info, see [AutoPlay for Microsoft Store device apps](http://go.microsoft.com/fwlink/p/?LinkId=306684).</span></span>

## <a name="register-for-autoplay-content"></a><span data-ttu-id="b6774-111">自動再生コンテンツに登録する</span><span class="sxs-lookup"><span data-stu-id="b6774-111">Register for AutoPlay content</span></span>

<span data-ttu-id="b6774-112">アプリを**自動再生**コンテンツ イベントのオプションとして登録できます。</span><span class="sxs-lookup"><span data-stu-id="b6774-112">You can register apps as options for **AutoPlay** content events.</span></span> <span data-ttu-id="b6774-113">**自動再生**コンテンツ イベントは、カメラのメモリ カード、サム ドライブ、DVD などのボリューム デバイスが PC に挿入されたときに発生します。</span><span class="sxs-lookup"><span data-stu-id="b6774-113">**AutoPlay** content events are raised when a volume device such as a camera memory card, thumb drive, or DVD is inserted into the PC.</span></span> <span data-ttu-id="b6774-114">ここでは、カメラのボリューム デバイスが挿入されたときに**自動再生**オプションとしてアプリを識別する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="b6774-114">Here we show how to identify your app as an **AutoPlay** option when a volume device from a camera is inserted.</span></span>

<span data-ttu-id="b6774-115">このチュートリアルでは、画像ファイルを表示したり、ピクチャにそれらの画像をコピーしたりするアプリを作成しました。</span><span class="sxs-lookup"><span data-stu-id="b6774-115">In this tutorial, you created an app that displays image files or copies them to Pictures.</span></span> <span data-ttu-id="b6774-116">自動再生 **ShowPicturesOnArrival** コンテンツ イベントにアプリを登録しました。</span><span class="sxs-lookup"><span data-stu-id="b6774-116">You registered the app for the AutoPlay **ShowPicturesOnArrival** content event.</span></span>

<span data-ttu-id="b6774-117">自動再生では、近接通信 (タップ) を使って PC 間で共有されるコンテンツのコンテンツ イベントも発生します。</span><span class="sxs-lookup"><span data-stu-id="b6774-117">AutoPlay also raises content events for content shared between PCs using proximity (tapping).</span></span> <span data-ttu-id="b6774-118">このセクションで説明した手順とコードを使って、近接通信を使用する PC 間で共有されるファイルを処理できます。</span><span class="sxs-lookup"><span data-stu-id="b6774-118">You can use the steps and code in this section to handle files that are shared between PCs that use proximity.</span></span> <span data-ttu-id="b6774-119">次の表に、近接通信を使ってコンテンツを共有できる自動再生コンテンツ イベントを示します。</span><span class="sxs-lookup"><span data-stu-id="b6774-119">The following table lists the AutoPlay content events that are available for sharing content by using proximity.</span></span>

| <span data-ttu-id="b6774-120">アクション</span><span class="sxs-lookup"><span data-stu-id="b6774-120">Action</span></span>         | <span data-ttu-id="b6774-121">自動再生コンテンツ イベント</span><span class="sxs-lookup"><span data-stu-id="b6774-121">AutoPlay content event</span></span>  |
|----------------|-------------------------|
| <span data-ttu-id="b6774-122">音楽の共有</span><span class="sxs-lookup"><span data-stu-id="b6774-122">Sharing music</span></span>  | <span data-ttu-id="b6774-123">PlayMusicFilesOnArrival</span><span class="sxs-lookup"><span data-stu-id="b6774-123">PlayMusicFilesOnArrival</span></span> |
| <span data-ttu-id="b6774-124">ビデオの共有</span><span class="sxs-lookup"><span data-stu-id="b6774-124">Sharing videos</span></span> | <span data-ttu-id="b6774-125">PlayVideoFilesOnArrival</span><span class="sxs-lookup"><span data-stu-id="b6774-125">PlayVideoFilesOnArrival</span></span> |

 
<span data-ttu-id="b6774-126">ファイルが近接通信を使って共有されている場合、**FileActivatedEventArgs** オブジェクトの **Files** プロパティには、すべての共有ファイルを含むルート フォルダーへの参照が含まれます。</span><span class="sxs-lookup"><span data-stu-id="b6774-126">When files are shared by using proximity, the **Files** property of the **FileActivatedEventArgs** object contains a reference to a root folder that contains all of the shared files.</span></span>

### <a name="step-1-create-a-new-project-and-add-autoplay-declarations"></a><span data-ttu-id="b6774-127">手順 1: 新しいプロジェクトを作成し、自動再生宣言を追加する</span><span class="sxs-lookup"><span data-stu-id="b6774-127">Step 1: Create a new project and add AutoPlay declarations</span></span>

1.  <span data-ttu-id="b6774-128">Microsoft Visual Studio を開き、**[ファイル]** メニューの **[新しいプロジェクト]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="b6774-128">Open Microsoft Visual Studio and select **New Project** from the **File** menu.</span></span> <span data-ttu-id="b6774-129">**Visual C#** セクションの **[Windows]** で **[空白のアプリ (ユニバーサル Windows)]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="b6774-129">In the **Visual C#** section, under **Windows**, select **Blank App (Universal Windows)**.</span></span> <span data-ttu-id="b6774-130">アプリに **AutoPlayDisplayOrCopyImages** という名前を付け、**[OK]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="b6774-130">Name the app **AutoPlayDisplayOrCopyImages** and click **OK.**</span></span>
2.  <span data-ttu-id="b6774-131">[Package.appxmanifest] ファイルを開き、**[機能] \*\* タブを選択します。**[リムーバブル記憶域]\*\* と **[ピクチャ ライブラリ]** 機能を選択します。</span><span class="sxs-lookup"><span data-stu-id="b6774-131">Open the Package.appxmanifest file and select the **Capabilities** tab. Select the **Removable Storage** and **Pictures Library** capabilities.</span></span> <span data-ttu-id="b6774-132">これで、アプリはカメラ メモリのリムーバブル ストレージ デバイスと、ローカルの画像にアクセスできるようになります。</span><span class="sxs-lookup"><span data-stu-id="b6774-132">This gives the app access to removable storage devices for camera memory, and access to local pictures.</span></span>
3.  <span data-ttu-id="b6774-133">マニフェスト ファイルで **[宣言]** タブを選び、**[使用可能な宣言]** ドロップダウンから **[自動再生コンテンツ]** を選んで **[追加]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="b6774-133">In the manifest file, select the **Declarations** tab. In the **Available Declarations** drop-down list, select **AutoPlay Content** and click **Add**.</span></span> <span data-ttu-id="b6774-134">**[サポートされる宣言]** ボックスの一覧に追加された新しい **[自動再生コンテンツ]** 項目を選びます。</span><span class="sxs-lookup"><span data-stu-id="b6774-134">Select the new **AutoPlay Content** item that was added to the **Supported Declarations** list.</span></span>
4.  <span data-ttu-id="b6774-135">**[自動再生コンテンツ]** 宣言は、自動再生でコンテンツ イベントが発生したときに該当のアプリがオプションとして識別されます。</span><span class="sxs-lookup"><span data-stu-id="b6774-135">An **AutoPlay Content** declaration identifies your app as an option when AutoPlay raises a content event.</span></span> <span data-ttu-id="b6774-136">イベントは DVD やサム ドライブなどのボリューム デバイスのコンテンツに基づきます。</span><span class="sxs-lookup"><span data-stu-id="b6774-136">The event is based on the content of a volume device such as a DVD or a thumb drive.</span></span> <span data-ttu-id="b6774-137">自動再生ではボリューム デバイスのコンテンツを調べて、発生させるコンテンツ イベントを決定します。</span><span class="sxs-lookup"><span data-stu-id="b6774-137">AutoPlay examines the content of the volume device and determines which content event to raise.</span></span> <span data-ttu-id="b6774-138">ボリュームのルートに DCIM、AVCHD、または PRIVATE\\ACHD フォルダーが含まれる場合、または自動再生コントロール パネルで **[各メディア タイプの処理方法を選択する]** を有効にしていてボリュームのルートで画像が見つかった場合、自動再生で **ShowPicturesOnArrival** イベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="b6774-138">If the root of the volume contains a DCIM, AVCHD, or PRIVATE\\ACHD folder, or if a user has enabled **Choose what to do with each type of media** in the AutoPlay Control Panel and pictures are found in the root of the volume, then AutoPlay raises the **ShowPicturesOnArrival** event.</span></span> <span data-ttu-id="b6774-139">**[起動アクション]** セクションで、最初の起動アクションに対して下記の表 1 の値を入力します。</span><span class="sxs-lookup"><span data-stu-id="b6774-139">In the **Launch Actions** section, enter the values from Table 1 below for the first launch action.</span></span>
5.  <span data-ttu-id="b6774-140">**[自動再生コンテンツ]** 項目の **[起動アクション]** セクションで、**[新規追加]** をクリックし、2 つ目の起動アクションを追加します。</span><span class="sxs-lookup"><span data-stu-id="b6774-140">In the **Launch Actions** section for the **AutoPlay Content** item, click **Add New** to add a second launch action.</span></span> <span data-ttu-id="b6774-141">2 つ目の起動アクションについて、下記の表 2 の値を入力します。</span><span class="sxs-lookup"><span data-stu-id="b6774-141">Enter the values in Table 2 below for the second launch action.</span></span>
6.  <span data-ttu-id="b6774-142">**[使用可能な宣言]** ドロップダウン リストで、**[ファイルの種類の関連付け]** を選び、**[追加]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="b6774-142">In the **Available Declarations** drop-down list, select **File Type Associations** and click **Add**.</span></span> <span data-ttu-id="b6774-143">新しい **[ファイルの種類の関連付け]** 宣言の [プロパティ] で、**[表示名]** フィールドを **"自動再生コピー" または "画像を表示する"**、**[名前]** フィールドを **image\_association1** に設定します。</span><span class="sxs-lookup"><span data-stu-id="b6774-143">In the Properties of the new **File Type Associations** declaration, set the **Display Name** field to **AutoPlay Copy or Show Images** and the **Name** field to **image\_association1**.</span></span> <span data-ttu-id="b6774-144">**[サポートされるファイルの種類]** セクションで、**[新規追加]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="b6774-144">In the **Supported File Types** section, click **Add New**.</span></span> <span data-ttu-id="b6774-145">**[ファイルの種類]** フィールドを **.jpg** に設定します。</span><span class="sxs-lookup"><span data-stu-id="b6774-145">Set the **File Type** field to **.jpg**.</span></span> <span data-ttu-id="b6774-146">**[サポートされるファイルの種類]** セクションで、新しいファイルの関連付けの **[ファイルの種類]** フィールドを **.png** に設定します。</span><span class="sxs-lookup"><span data-stu-id="b6774-146">In the **Supported File Types** section, set the **File Type** field of the new file association to **.png**.</span></span> <span data-ttu-id="b6774-147">コンテンツ イベントの場合は、自動再生で、アプリに明示的に関連付けられていないファイルの種類はすべて除外されます。</span><span class="sxs-lookup"><span data-stu-id="b6774-147">For content events, AutoPlay filters out any file types that are not explicitly associated with your app.</span></span>
7.  <span data-ttu-id="b6774-148">マニフェスト ファイルを保存して閉じます。</span><span class="sxs-lookup"><span data-stu-id="b6774-148">Save and close the manifest file.</span></span>

**<span data-ttu-id="b6774-149">表 1</span><span class="sxs-lookup"><span data-stu-id="b6774-149">Table 1</span></span>**

| <span data-ttu-id="b6774-150">設定</span><span class="sxs-lookup"><span data-stu-id="b6774-150">Setting</span></span>             | <span data-ttu-id="b6774-151">値</span><span class="sxs-lookup"><span data-stu-id="b6774-151">Value</span></span>                 |
|---------------------|-----------------------|
| <span data-ttu-id="b6774-152">動詞</span><span class="sxs-lookup"><span data-stu-id="b6774-152">Verb</span></span>                | <span data-ttu-id="b6774-153">show</span><span class="sxs-lookup"><span data-stu-id="b6774-153">show</span></span>                  |
| <span data-ttu-id="b6774-154">アクションの表示名</span><span class="sxs-lookup"><span data-stu-id="b6774-154">Action Display Name</span></span> | <span data-ttu-id="b6774-155">画像を表示する</span><span class="sxs-lookup"><span data-stu-id="b6774-155">Show Pictures</span></span>         |
| <span data-ttu-id="b6774-156">コンテンツ イベント</span><span class="sxs-lookup"><span data-stu-id="b6774-156">Content Event</span></span>       | <span data-ttu-id="b6774-157">ShowPicturesOnArrival</span><span class="sxs-lookup"><span data-stu-id="b6774-157">ShowPicturesOnArrival</span></span> |

<span data-ttu-id="b6774-158">**[アクションの表示名]** 設定では、アプリの自動再生で表示される文字列を指定します。</span><span class="sxs-lookup"><span data-stu-id="b6774-158">The **Action Display Name** setting identifies the string that AutoPlay displays for your app.</span></span> <span data-ttu-id="b6774-159">**[動詞]** 設定では、選んだオプションでアプリに渡される値を指定します。</span><span class="sxs-lookup"><span data-stu-id="b6774-159">The **Verb** setting identifies a value that is passed to your app for the selected option.</span></span> <span data-ttu-id="b6774-160">自動再生のイベントの起動アクションは複数指定できます。また、**[動詞]** 設定を使って、ユーザーがアプリで選んだアクションを確認できます。</span><span class="sxs-lookup"><span data-stu-id="b6774-160">You can specify multiple launch actions for an AutoPlay event and use the **Verb** setting to determine which option a user has selected for your app.</span></span> <span data-ttu-id="b6774-161">アプリに渡される起動イベント引数の **verb** プロパティを調べることでユーザーが選んだオプションを確認できます。</span><span class="sxs-lookup"><span data-stu-id="b6774-161">You can tell which option the user selected by checking the **verb** property of the startup event arguments passed to your app.</span></span> <span data-ttu-id="b6774-162">**[動詞]** 設定には任意の値を使うことができます。ただし、予約されている **open** を除きます。</span><span class="sxs-lookup"><span data-stu-id="b6774-162">You can use any value for the **Verb** setting except, **open**, which is reserved.</span></span>

**<span data-ttu-id="b6774-163">表 2</span><span class="sxs-lookup"><span data-stu-id="b6774-163">Table 2</span></span>**  

| <span data-ttu-id="b6774-164">設定</span><span class="sxs-lookup"><span data-stu-id="b6774-164">Setting</span></span>             | <span data-ttu-id="b6774-165">値</span><span class="sxs-lookup"><span data-stu-id="b6774-165">Value</span></span>                      |
|--------------------:|----------------------------|
| <span data-ttu-id="b6774-166">動詞</span><span class="sxs-lookup"><span data-stu-id="b6774-166">Verb</span></span>                | <span data-ttu-id="b6774-167">copy</span><span class="sxs-lookup"><span data-stu-id="b6774-167">copy</span></span>                       |
| <span data-ttu-id="b6774-168">アクションの表示名</span><span class="sxs-lookup"><span data-stu-id="b6774-168">Action Display Name</span></span> | <span data-ttu-id="b6774-169">ライブラリに画像をコピーする</span><span class="sxs-lookup"><span data-stu-id="b6774-169">Copy Pictures Into Library</span></span> |
| <span data-ttu-id="b6774-170">コンテンツ イベント</span><span class="sxs-lookup"><span data-stu-id="b6774-170">Content Event</span></span>       | <span data-ttu-id="b6774-171">ShowPicturesOnArrival</span><span class="sxs-lookup"><span data-stu-id="b6774-171">ShowPicturesOnArrival</span></span>      |

### <a name="step-2-add-xaml-ui"></a><span data-ttu-id="b6774-172">手順 2: XAML UI を追加する</span><span class="sxs-lookup"><span data-stu-id="b6774-172">Step 2: Add XAML UI</span></span>

<span data-ttu-id="b6774-173">MainPage.xaml ファイルを開き、次の XAML を既定の &lt;Grid&gt; セクションに追加します。</span><span class="sxs-lookup"><span data-stu-id="b6774-173">Open the MainPage.xaml file and add the following XAML to the default &lt;Grid&gt; section.</span></span>

```xml
<TextBlock FontSize="18">File List</TextBlock>
<TextBlock x:Name="FilesBlock" HorizontalAlignment="Left" TextWrapping="Wrap"
           VerticalAlignment="Top" Margin="0,20,0,0" Height="280" Width="240" />
<Canvas x:Name="FilesCanvas" HorizontalAlignment="Left" VerticalAlignment="Top"
        Margin="260,20,0,0" Height="280" Width="100"/>
```

### <a name="step-3-add-initialization-code"></a><span data-ttu-id="b6774-174">手順 3: 初期化コードを追加する</span><span class="sxs-lookup"><span data-stu-id="b6774-174">Step 3: Add initialization code</span></span>

<span data-ttu-id="b6774-175">この手順のコードでは、**Verb** プロパティの verb 値をチェックします。これは、**OnFileActivated** イベントの間にアプリに渡される起動引数の 1 つです。</span><span class="sxs-lookup"><span data-stu-id="b6774-175">The code in this step checks the verb value in the **Verb** property, which is one of the startup arguments passed to the app during the **OnFileActivated** event.</span></span> <span data-ttu-id="b6774-176">次に、ユーザーが選んだオプションに関連するメソッドが呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="b6774-176">The code then calls a method related to the option that the user selected.</span></span> <span data-ttu-id="b6774-177">カメラのメモリ イベントの場合、自動再生により、カメラ ストレージのルート フォルダーがアプリに渡されます。</span><span class="sxs-lookup"><span data-stu-id="b6774-177">For the camera memory event, AutoPlay passes the root folder of the camera storage to the app.</span></span> <span data-ttu-id="b6774-178">このフォルダーは **Files** プロパティの最初の要素から取得できます。</span><span class="sxs-lookup"><span data-stu-id="b6774-178">You can retrieve this folder from the first element of the **Files** property.</span></span>

<span data-ttu-id="b6774-179">App.xaml.cs ファイルを開いて、次のコードを **App** クラスに追加します。</span><span class="sxs-lookup"><span data-stu-id="b6774-179">Open the App.xaml.cs file and add the following code to the **App** class.</span></span>

```cs
protected override void OnFileActivated(FileActivatedEventArgs args)
{
    if (args.Verb == "show")
    {
        Frame rootFrame = (Frame)Window.Current.Content;
        MainPage page = (MainPage)rootFrame.Content;

        // Call DisplayImages with root folder from camera storage.
        page.DisplayImages((Windows.Storage.StorageFolder)args.Files[0]);
    }

    if (args.Verb == "copy")
    {
        Frame rootFrame = (Frame)Window.Current.Content;
        MainPage page = (MainPage)rootFrame.Content;

        // Call CopyImages with root folder from camera storage.
        page.CopyImages((Windows.Storage.StorageFolder)args.Files[0]);
    }

    base.OnFileActivated(args);
}
```

> <span data-ttu-id="b6774-180">**注:**、`DisplayImages`と`CopyImages`メソッドは、次の手順で追加されます。</span><span class="sxs-lookup"><span data-stu-id="b6774-180">**Note**The `DisplayImages` and `CopyImages` methods are added in the following steps.</span></span>

### <a name="step-4-add-code-to-display-images"></a><span data-ttu-id="b6774-181">手順 4: 画像を表示するコードを追加する</span><span class="sxs-lookup"><span data-stu-id="b6774-181">Step 4: Add code to display images</span></span>

<span data-ttu-id="b6774-182">MainPage.xaml.cs ファイルで、次のコードを **MainPage** クラスに追加します。</span><span class="sxs-lookup"><span data-stu-id="b6774-182">In the MainPage.xaml.cs file add the following code to the **MainPage** class.</span></span>

```cs
async internal void DisplayImages(Windows.Storage.StorageFolder rootFolder)
{
    // Display images from first folder in root\DCIM.
    var dcimFolder = await rootFolder.GetFolderAsync("DCIM");
    var folderList = await dcimFolder.GetFoldersAsync();
    var cameraFolder = folderList[0];
    var fileList = await cameraFolder.GetFilesAsync();
    for (int i = 0; i < fileList.Count; i++)
    {
        var file = (Windows.Storage.StorageFile)fileList[i];
        WriteMessageText(file.Name + "\n");
        DisplayImage(file, i);
    }
}

async private void DisplayImage(Windows.Storage.IStorageItem file, int index)
{
    try
    {
        var sFile = (Windows.Storage.StorageFile)file;
        Windows.Storage.Streams.IRandomAccessStream imageStream =
            await sFile.OpenAsync(Windows.Storage.FileAccessMode.Read);
        Windows.UI.Xaml.Media.Imaging.BitmapImage imageBitmap =
            new Windows.UI.Xaml.Media.Imaging.BitmapImage();
        imageBitmap.SetSource(imageStream);
        var element = new Image();
        element.Source = imageBitmap;
        element.Height = 100;
        Thickness margin = new Thickness();
        margin.Top = index * 100;
        element.Margin = margin;
        FilesCanvas.Children.Add(element);
    }
    catch (Exception e)
    {
       WriteMessageText(e.Message + "\n");
    }
}

// Write a message to MessageBlock on the UI thread.
private Windows.UI.Core.CoreDispatcher messageDispatcher = Window.Current.CoreWindow.Dispatcher;

private async void WriteMessageText(string message, bool overwrite = false)
{
    await messageDispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
        () =>
        {
            if (overwrite)
                FilesBlock.Text = message;
            else
                FilesBlock.Text += message;
        });
}
```

### <a name="step-5-add-code-to-copy-images"></a><span data-ttu-id="b6774-183">手順 5: 画像をコピーするコードを追加する</span><span class="sxs-lookup"><span data-stu-id="b6774-183">Step 5: Add code to copy images</span></span>

<span data-ttu-id="b6774-184">MainPage.xaml.cs ファイルで、次のコードを **MainPage** クラスに追加します。</span><span class="sxs-lookup"><span data-stu-id="b6774-184">In the MainPage.xaml.cs file add the following code to the **MainPage** class.</span></span>

```cs
async internal void CopyImages(Windows.Storage.StorageFolder rootFolder)
{
    // Copy images from first folder in root\DCIM.
    var dcimFolder = await rootFolder.GetFolderAsync("DCIM");
    var folderList = await dcimFolder.GetFoldersAsync();
    var cameraFolder = folderList[0];
    var fileList = await cameraFolder.GetFilesAsync();

    try
    {
        var folderName = "Images " + DateTime.Now.ToString("yyyy-MM-dd HHmmss");
        Windows.Storage.StorageFolder imageFolder = await
            Windows.Storage.KnownFolders.PicturesLibrary.CreateFolderAsync(folderName);

        foreach (Windows.Storage.IStorageItem file in fileList)
        {
            CopyImage(file, imageFolder);
        }
    }
    catch (Exception e)
    {
        WriteMessageText("Failed to copy images.\n" + e.Message + "\n");
    }
}

async internal void CopyImage(Windows.Storage.IStorageItem file,
                              Windows.Storage.StorageFolder imageFolder)
{
    try
    {
        Windows.Storage.StorageFile sFile = (Windows.Storage.StorageFile)file;
        await sFile.CopyAsync(imageFolder, sFile.Name);
        WriteMessageText(sFile.Name + " copied.\n");
    }
    catch (Exception e)
    {
        WriteMessageText("Failed to copy file.\n" + e.Message + "\n");
    }
}
```

### <a name="step-6-build-and-run-the-app"></a><span data-ttu-id="b6774-185">手順 6: アプリをビルドして実行する</span><span class="sxs-lookup"><span data-stu-id="b6774-185">Step 6: Build and run the app</span></span>

1.  <span data-ttu-id="b6774-186">F5 キーを押して、アプリを (デバッグ モードで) ビルドおよび展開します。</span><span class="sxs-lookup"><span data-stu-id="b6774-186">Press F5 to build and deploy the app (in debug mode).</span></span>
2.  <span data-ttu-id="b6774-187">アプリを実行するには、カメラのメモリ カードまたはカメラの他のストレージ デバイスを PC に挿入します。</span><span class="sxs-lookup"><span data-stu-id="b6774-187">To run your app, insert a camera memory card or another storage device from a camera into your PC.</span></span> <span data-ttu-id="b6774-188">次に、自動再生のオプションの一覧から package.appxmanifest ファイルで指定したコンテンツ イベント オプションのいずれかを選びます。</span><span class="sxs-lookup"><span data-stu-id="b6774-188">Then, select one of the content event options that you specified in your package.appxmanifest file from the AutoPlay list of options.</span></span> <span data-ttu-id="b6774-189">このサンプル コードは、カメラのメモリ カードの DCIM フォルダーにある画像の表示またはコピーのみを行います。</span><span class="sxs-lookup"><span data-stu-id="b6774-189">This sample code only displays or copies pictures in the DCIM folder of a camera memory card.</span></span> <span data-ttu-id="b6774-190">カメラのメモリ カードの AVCHD または PRIVATE\\ACHD フォルダーに画像が格納される場合は、適宜コードを更新する必要があります。</span><span class="sxs-lookup"><span data-stu-id="b6774-190">If your camera memory card stores pictures in an AVCHD or PRIVATE\\ACHD folder, you will need to update the code accordingly.</span></span>
    <span data-ttu-id="b6774-191">**注:** 場合は、ルートに**DCIM**をという名前のフォルダーがあり、画像が含まれている DCIM フォルダーのサブフォルダーがある場合に、フラッシュ ドライブを使用するカメラのメモリ カードがない場合。</span><span class="sxs-lookup"><span data-stu-id="b6774-191">**Note**If you don't have a camera memory card, you can use a flash drive if it has a folder named **DCIM** in the root and if the DCIM folder has a subfolder that contains images.</span></span>

## <a name="register-for-an-autoplay-device"></a><span data-ttu-id="b6774-192">自動再生デバイスに登録する</span><span class="sxs-lookup"><span data-stu-id="b6774-192">Register for an AutoPlay device</span></span>


<span data-ttu-id="b6774-193">アプリを**自動再生**デバイス イベントのオプションとして登録できます。</span><span class="sxs-lookup"><span data-stu-id="b6774-193">You can register apps as options for **AutoPlay** device events.</span></span> <span data-ttu-id="b6774-194">**自動再生**デバイス イベントは、デバイスがコンピューターに接続されると発生します。</span><span class="sxs-lookup"><span data-stu-id="b6774-194">**AutoPlay** device events are raised when a device is connected to a PC.</span></span>

<span data-ttu-id="b6774-195">ここでは、PC にカメラが接続されたときに**自動再生**オプションとしてアプリを識別する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="b6774-195">Here we show how to identify your app as an **AutoPlay** option when a camera is connected to a PC.</span></span> <span data-ttu-id="b6774-196">アプリは、**WPD\\ImageSourceAutoPlay** イベントのハンドラーとして登録されます。</span><span class="sxs-lookup"><span data-stu-id="b6774-196">The app registers as a handler for the **WPD\\ImageSourceAutoPlay** event.</span></span> <span data-ttu-id="b6774-197">これは、カメラなどのイメージング デバイスが MTP を使う ImageSource であることを通知するときに Windows ポータブル デバイス (WPD) システムによって生成される一般的なイベントです。</span><span class="sxs-lookup"><span data-stu-id="b6774-197">This is a common event that the Windows Portable Device (WPD) system raises when cameras and other imaging devices notify it that they are an ImageSource using MTP.</span></span> <span data-ttu-id="b6774-198">詳しくは、「[Windows ポータブル デバイス](https://msdn.microsoft.com/library/windows/hardware/ff597729)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b6774-198">For more info, see [Windows Portable Devices](https://msdn.microsoft.com/library/windows/hardware/ff597729).</span></span>

<span data-ttu-id="b6774-199">**重要な** [**Windows.Devices.Portable.StorageDevice**](https://msdn.microsoft.com/library/windows/apps/br225654) Api は、[デスクトップ デバイス ファミリ](https://msdn.microsoft.com/library/windows/apps/dn894631)の一部です。</span><span class="sxs-lookup"><span data-stu-id="b6774-199">**Important**The [**Windows.Devices.Portable.StorageDevice**](https://msdn.microsoft.com/library/windows/apps/br225654) APIs are part of the [desktop device family](https://msdn.microsoft.com/library/windows/apps/dn894631).</span></span> <span data-ttu-id="b6774-200">アプリでは、Pc など、デスクトップ デバイス ファミリで windows 10 デバイスでのみこれらの Api を使用できます。</span><span class="sxs-lookup"><span data-stu-id="b6774-200">Apps can use these APIs only on Windows10 devices in the desktop device family, such as PCs.</span></span>

 

### <a name="step-1-create-a-new-project-and-add-autoplay-declarations"></a><span data-ttu-id="b6774-201">手順 1: 新しいプロジェクトを作成し、自動再生宣言を追加する</span><span class="sxs-lookup"><span data-stu-id="b6774-201">Step 1: Create a new project and add AutoPlay declarations</span></span>

1.  <span data-ttu-id="b6774-202">Visual Studio を開き、**[ファイル]** メニューの **[新しいプロジェクト]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="b6774-202">Open Visual Studio and select **New Project** from the **File** menu.</span></span> <span data-ttu-id="b6774-203">**Visual C#** セクションの **[Windows]** で **[空白のアプリ (ユニバーサル Windows)]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="b6774-203">In the **Visual C#** section, under **Windows**, select **Blank App (Universal Windows)**.</span></span> <span data-ttu-id="b6774-204">アプリに **AutoPlayDevice\_Camera** という名前を付け、**[OK]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="b6774-204">Name the app **AutoPlayDevice\_Camera** and click **OK.**</span></span>
2.  <span data-ttu-id="b6774-205">[Package.appxmanifest] ファイルを開き、**[機能]** タブを選択します。**[リムーバブル記憶域]** 機能を選択します。</span><span class="sxs-lookup"><span data-stu-id="b6774-205">Open the Package.appxmanifest file and select the **Capabilities** tab. Select the **Removable Storage** capability.</span></span> <span data-ttu-id="b6774-206">これで、アプリはリムーバブル記憶域ボリューム デバイスとしてカメラ上のデータにアクセスできるようになります。</span><span class="sxs-lookup"><span data-stu-id="b6774-206">This gives the app access to the data on the camera as a removable storage volume device.</span></span>
3.  <span data-ttu-id="b6774-207">マニフェスト ファイルで **[宣言]** タブを選び、**[使用可能な宣言]** ドロップダウンから **[自動再生デバイス]** を選んで **[追加]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="b6774-207">In the manifest file, select the **Declarations** tab. In the **Available Declarations** drop-down list, select **AutoPlay Device** and click **Add**.</span></span> <span data-ttu-id="b6774-208">**[サポートされる宣言]** ボックスの一覧に追加された新しい **[自動再生デバイス]** 項目を選びます。</span><span class="sxs-lookup"><span data-stu-id="b6774-208">Select the new **AutoPlay Device** item that was added to the **Supported Declarations** list.</span></span>
4.  <span data-ttu-id="b6774-209">**[自動再生デバイス]** 宣言では、自動再生で既知のイベントのデバイス イベントが発生したときに該当のアプリがオプションとして識別されます。</span><span class="sxs-lookup"><span data-stu-id="b6774-209">An **AutoPlay Device** declaration identifies your app as an option when AutoPlay raises a device event for known events.</span></span> <span data-ttu-id="b6774-210">**[起動アクション]** セクションで、最初の起動アクションに対して下記の表の値を入力します。</span><span class="sxs-lookup"><span data-stu-id="b6774-210">In the **Launch Actions** section, enter the values in the table below for the first launch action.</span></span>
5.  <span data-ttu-id="b6774-211">**[使用可能な宣言]** ドロップダウン リストで、**[ファイルの種類の関連付け]** を選び、**[追加]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="b6774-211">In the **Available Declarations** drop-down list, select **File Type Associations** and click **Add**.</span></span> <span data-ttu-id="b6774-212">新しい **[ファイルの種類の関連付け]** 宣言の [プロパティ] で、**[表示名]** フィールドを **"カメラの画像を表示する"**、**[名前]** フィールドを **camera\_association1** に設定します。</span><span class="sxs-lookup"><span data-stu-id="b6774-212">In the Properties of the new **File Type Associations** declaration, set the **Display Name** field to **Show Images from Camera** and the **Name** field to **camera\_association1**.</span></span> <span data-ttu-id="b6774-213">**[サポートされるファイルの種類]** セクションで、**[新規追加]** をクリックします (必要な場合)。</span><span class="sxs-lookup"><span data-stu-id="b6774-213">In the **Supported File Types** section, click **Add New** (if needed).</span></span> <span data-ttu-id="b6774-214">**[ファイルの種類]** フィールドを **.jpg** に設定します。</span><span class="sxs-lookup"><span data-stu-id="b6774-214">Set the **File Type** field to **.jpg**.</span></span> <span data-ttu-id="b6774-215">**[サポートされるファイルの種類]** セクションで、**[新規追加]** をもう一度クリックします。</span><span class="sxs-lookup"><span data-stu-id="b6774-215">In the **Supported File Types** section, click **Add New** again.</span></span> <span data-ttu-id="b6774-216">新しいファイルの関連付けの **[ファイルの種類]** フィールドを **.png** に設定します。</span><span class="sxs-lookup"><span data-stu-id="b6774-216">Set the **File Type** field of the new file association to **.png**.</span></span> <span data-ttu-id="b6774-217">コンテンツ イベントの場合は、自動再生で、アプリに明示的に関連付けられていないファイルの種類はすべて除外されます。</span><span class="sxs-lookup"><span data-stu-id="b6774-217">For content events, AutoPlay filters out any file types that are not explicitly associated with your app.</span></span>
6.  <span data-ttu-id="b6774-218">マニフェスト ファイルを保存して閉じます。</span><span class="sxs-lookup"><span data-stu-id="b6774-218">Save and close the manifest file.</span></span>

| <span data-ttu-id="b6774-219">設定</span><span class="sxs-lookup"><span data-stu-id="b6774-219">Setting</span></span>             | <span data-ttu-id="b6774-220">値</span><span class="sxs-lookup"><span data-stu-id="b6774-220">Value</span></span>            |
|---------------------|------------------|
| <span data-ttu-id="b6774-221">動詞</span><span class="sxs-lookup"><span data-stu-id="b6774-221">Verb</span></span>                | <span data-ttu-id="b6774-222">show</span><span class="sxs-lookup"><span data-stu-id="b6774-222">show</span></span>             |
| <span data-ttu-id="b6774-223">アクションの表示名</span><span class="sxs-lookup"><span data-stu-id="b6774-223">Action Display Name</span></span> | <span data-ttu-id="b6774-224">画像を表示する</span><span class="sxs-lookup"><span data-stu-id="b6774-224">Show Pictures</span></span>    |
| <span data-ttu-id="b6774-225">コンテンツ イベント</span><span class="sxs-lookup"><span data-stu-id="b6774-225">Content Event</span></span>       | <span data-ttu-id="b6774-226">WPD\\ImageSource</span><span class="sxs-lookup"><span data-stu-id="b6774-226">WPD\\ImageSource</span></span> |

<span data-ttu-id="b6774-227">**[アクションの表示名]** 設定では、アプリの自動再生で表示される文字列を指定します。</span><span class="sxs-lookup"><span data-stu-id="b6774-227">The **Action Display Name** setting identifies the string that AutoPlay displays for your app.</span></span> <span data-ttu-id="b6774-228">**[動詞]** 設定では、選んだオプションでアプリに渡される値を指定します。</span><span class="sxs-lookup"><span data-stu-id="b6774-228">The **Verb** setting identifies a value that is passed to your app for the selected option.</span></span> <span data-ttu-id="b6774-229">自動再生のイベントの起動アクションは複数指定できます。また、**[動詞]** 設定を使って、ユーザーがアプリで選んだアクションを確認できます。</span><span class="sxs-lookup"><span data-stu-id="b6774-229">You can specify multiple launch actions for an AutoPlay event and use the **Verb** setting to determine which option a user has selected for your app.</span></span> <span data-ttu-id="b6774-230">アプリに渡される起動イベント引数の **verb** プロパティを調べることでユーザーが選んだオプションを確認できます。</span><span class="sxs-lookup"><span data-stu-id="b6774-230">You can tell which option the user selected by checking the **verb** property of the startup event arguments passed to your app.</span></span> <span data-ttu-id="b6774-231">**[動詞]** 設定には任意の値を使うことができます。ただし、予約されている **open** を除きます。</span><span class="sxs-lookup"><span data-stu-id="b6774-231">You can use any value for the **Verb** setting except, **open**, which is reserved.</span></span> <span data-ttu-id="b6774-232">1 つのアプリで複数の動詞を使う例については、「[自動再生コンテンツに登録する](#register-for-autoplay-content)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b6774-232">For an example of using multiple verbs in a single app, see [Register for AutoPlay content](#register-for-autoplay-content).</span></span>

### <a name="step-2-add-assembly-reference-for-the-desktop-extensions"></a><span data-ttu-id="b6774-233">手順 2: デスクトップ拡張機能に対するアセンブリ参照を追加する</span><span class="sxs-lookup"><span data-stu-id="b6774-233">Step 2: Add assembly reference for the desktop extensions</span></span>

<span data-ttu-id="b6774-234">Windows ポータブル デバイス上の記憶域にアクセスするために必要な API である [**Windows.Devices.Portable.StorageDevice**](https://msdn.microsoft.com/library/windows/apps/br225654) は、デスクトップ [デスクトップ デバイス ファミリ](https://msdn.microsoft.com/library/windows/apps/dn894631) の一部です。</span><span class="sxs-lookup"><span data-stu-id="b6774-234">The APIs required to access storage on a Windows Portable Device, [**Windows.Devices.Portable.StorageDevice**](https://msdn.microsoft.com/library/windows/apps/br225654), are part of the desktop [desktop device family](https://msdn.microsoft.com/library/windows/apps/dn894631).</span></span> <span data-ttu-id="b6774-235">つまり、この API を使うには特別なアセンブリが必要であり、その呼び出しはデスクトップ デバイス ファミリ (PC など) でのみ機能します。</span><span class="sxs-lookup"><span data-stu-id="b6774-235">This means a special assembly is required to use the APIs and those calls will only work on a device in the desktop device family (such as a PC).</span></span>

1.  <span data-ttu-id="b6774-236">**ソリューション エクスプローラー**で、**[参照設定]** を右クリックし、**[参照の追加]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="b6774-236">In **Solution Explorer**, right click on **References** and then **Add Reference...**.</span></span>
2.  <span data-ttu-id="b6774-237">**[ユニバーサル Windows]** を展開し、**[拡張機能]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="b6774-237">Expand **Universal Windows** and click **Extensions**.</span></span>
3.  <span data-ttu-id="b6774-238">**[Windows Desktop Extensions for the UWP]** を選び、**[OK]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="b6774-238">Then select **Windows Desktop Extensions for the UWP** and click **OK**.</span></span>

### <a name="step-3-add-xaml-ui"></a><span data-ttu-id="b6774-239">手順 3: XAML UI を追加する</span><span class="sxs-lookup"><span data-stu-id="b6774-239">Step 3: Add XAML UI</span></span>

<span data-ttu-id="b6774-240">MainPage.xaml ファイルを開き、次の XAML を既定の &lt;Grid&gt; セクションに追加します。</span><span class="sxs-lookup"><span data-stu-id="b6774-240">Open the MainPage.xaml file and add the following XAML to the default &lt;Grid&gt; section.</span></span>

```xml
<StackPanel Orientation="Vertical" Margin="10,0,-10,0">
    <TextBlock FontSize="24">Device Information</TextBlock>
    <StackPanel Orientation="Horizontal">
        <TextBlock x:Name="DeviceInfoTextBlock" FontSize="18" Height="400" Width="400" VerticalAlignment="Top" />
        <ListView x:Name="ImagesList" HorizontalAlignment="Left" Height="400" VerticalAlignment="Top" Width="400">
            <ListView.ItemTemplate>
                <DataTemplate>
                    <StackPanel Orientation="Vertical">
                        <Image Source="{Binding Path=Source}" />
                        <TextBlock Text="{Binding Path=Name}" />
                    </StackPanel>
                </DataTemplate>
            </ListView.ItemTemplate>
            <ListView.ItemsPanel>
                <ItemsPanelTemplate>
                    <WrapGrid Orientation="Horizontal" ItemHeight="100" ItemWidth="120"></WrapGrid>
                </ItemsPanelTemplate>
            </ListView.ItemsPanel>
        </ListView>
    </StackPanel>
</StackPanel>
```

### <a name="step-4-add-activation-code"></a><span data-ttu-id="b6774-241">手順 4: アクティブ化コードを追加する</span><span class="sxs-lookup"><span data-stu-id="b6774-241">Step 4: Add activation code</span></span>

<span data-ttu-id="b6774-242">この手順のコードは、カメラのデバイス情報 ID を [**FromId**](https://msdn.microsoft.com/library/windows/apps/br225655) メソッドに渡すことによって、カメラを [**StorageDevice**](https://msdn.microsoft.com/library/windows/apps/br225654) として参照します。</span><span class="sxs-lookup"><span data-stu-id="b6774-242">The code in this step references the camera as a [**StorageDevice**](https://msdn.microsoft.com/library/windows/apps/br225654) by passing the device information Id of the camera to the [**FromId**](https://msdn.microsoft.com/library/windows/apps/br225655) method.</span></span> <span data-ttu-id="b6774-243">カメラのデバイス情報 ID を取得するには、まずイベント引数を [**DeviceActivatedEventArgs**](https://msdn.microsoft.com/library/windows/apps/br224710) としてキャストし、次に [**DeviceInformationId**](https://msdn.microsoft.com/library/windows/apps/br224711) プロパティから値を取得します。</span><span class="sxs-lookup"><span data-stu-id="b6774-243">The device information Id of the camera is obtained by first casting the event arguments as [**DeviceActivatedEventArgs**](https://msdn.microsoft.com/library/windows/apps/br224710), and then getting the value from the [**DeviceInformationId**](https://msdn.microsoft.com/library/windows/apps/br224711) property.</span></span>

<span data-ttu-id="b6774-244">App.xaml.cs ファイルを開いて、次のコードを **App** クラスに追加します。</span><span class="sxs-lookup"><span data-stu-id="b6774-244">Open the App.xaml.cs file and add the following code to the **App** class.</span></span>

```cs
protected override void OnActivated(IActivatedEventArgs args)
{
   if (args.Kind == ActivationKind.Device)
   {
      Frame rootFrame = null;
      // Ensure that the current page exists and is activated
      if (Window.Current.Content == null)
      {
         rootFrame = new Frame();
         rootFrame.Navigate(typeof(MainPage));
         Window.Current.Content = rootFrame;
      }
      else
      {
         rootFrame = Window.Current.Content as Frame;
      }
      Window.Current.Activate();

      // Make sure the necessary APIs are present on the device
      bool storageDeviceAPIPresent =
      Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Devices.Portable.StorageDevice");

      if (storageDeviceAPIPresent)
      {
         // Reference the current page as type MainPage
         var mPage = rootFrame.Content as MainPage;

         // Cast the activated event args as DeviceActivatedEventArgs and show images
         var deviceArgs = args as DeviceActivatedEventArgs;
         if (deviceArgs != null)
         {
            mPage.ShowImages(Windows.Devices.Portable.StorageDevice.FromId(deviceArgs.DeviceInformationId));
         }
      }
      else
      {
         // Handle case where APIs are not present (when the device is not part of the desktop device family)
      }

   }

   base.OnActivated(args);
}
```

> <span data-ttu-id="b6774-245">**注:**、`ShowImages`メソッドは、次の手順で追加されます。</span><span class="sxs-lookup"><span data-stu-id="b6774-245">**Note**The `ShowImages` method is added in the following step.</span></span>

### <a name="step-5-add-code-to-display-device-information"></a><span data-ttu-id="b6774-246">手順 5: デバイス情報を表示するコードを追加する</span><span class="sxs-lookup"><span data-stu-id="b6774-246">Step 5: Add code to display device information</span></span>

<span data-ttu-id="b6774-247">カメラに関する情報は、[**StorageDevice**](https://msdn.microsoft.com/library/windows/apps/br225654) クラスのプロパティから取得できます。</span><span class="sxs-lookup"><span data-stu-id="b6774-247">You can obtain information about the camera from the properties of the [**StorageDevice**](https://msdn.microsoft.com/library/windows/apps/br225654) class.</span></span> <span data-ttu-id="b6774-248">この手順のコードは、アプリの実行時にデバイス名などの情報をユーザーに表示します。</span><span class="sxs-lookup"><span data-stu-id="b6774-248">The code in this step displays the device name and other info to the user when the app runs.</span></span> <span data-ttu-id="b6774-249">続いて、GetImageList メソッドと GetThumbnail メソッドを呼び出します。これらのメソッドは、カメラに格納されている画像のサムネイルを表示するために、次の手順で追加します。</span><span class="sxs-lookup"><span data-stu-id="b6774-249">The code then calls the GetImageList and GetThumbnail methods, which you will add in the next step, to display thumbnails of the images stored on the camera</span></span>

<span data-ttu-id="b6774-250">MainPage.xaml.cs ファイルで、次のコードを **MainPage** クラスに追加します。</span><span class="sxs-lookup"><span data-stu-id="b6774-250">In the MainPage.xaml.cs file, add the following code to the **MainPage** class.</span></span>

```cs
private Windows.Storage.StorageFolder rootFolder;

internal async void ShowImages(Windows.Storage.StorageFolder folder)
{
    DeviceInfoTextBlock.Text = "Display Name = " + folder.DisplayName + "\n";
    DeviceInfoTextBlock.Text += "Display Type =  " + folder.DisplayType + "\n";
    DeviceInfoTextBlock.Text += "FolderRelativeId = " + folder.FolderRelativeId + "\n";

    // Reference first folder of the device as the root
    rootFolder = (await folder.GetFoldersAsync())[0];
    var imageList = await GetImageList(rootFolder);

    foreach (Windows.Storage.StorageFile img in imageList)
    {
        ImagesList.Items.Add(await GetThumbnail(img));
    }
}
```

> <span data-ttu-id="b6774-251">**注:**、`GetImageList`と`GetThumbnail`メソッドは、次の手順で追加されます。</span><span class="sxs-lookup"><span data-stu-id="b6774-251">**Note**The `GetImageList` and `GetThumbnail` methods are added in the following step.</span></span>

### <a name="step-6-add-code-to-display-images"></a><span data-ttu-id="b6774-252">手順 6: 画像を表示するコードを追加する</span><span class="sxs-lookup"><span data-stu-id="b6774-252">Step 6: Add code to display images</span></span>

<span data-ttu-id="b6774-253">この手順のコードは、カメラに格納されている画像のサムネイルを表示します。</span><span class="sxs-lookup"><span data-stu-id="b6774-253">The code in this step displays thumbnails of the images stored on the camera.</span></span> <span data-ttu-id="b6774-254">このコードは、カメラの非同期呼び出しを行ってサムネイル イメージを取得します。</span><span class="sxs-lookup"><span data-stu-id="b6774-254">The code makes asynchronous calls to the camera to get the thumbnail image.</span></span> <span data-ttu-id="b6774-255">ただし、次の非同期呼び出しは、前の非同期呼び出しが完了するまで行われません。</span><span class="sxs-lookup"><span data-stu-id="b6774-255">However, the next asynchronous call doesn't occur until the previous asynchronous call completes.</span></span> <span data-ttu-id="b6774-256">これにより、カメラに対する要求が一度に 1 つだけ実行されるようになります。</span><span class="sxs-lookup"><span data-stu-id="b6774-256">This ensures that only one request is made to the camera at a time.</span></span>

<span data-ttu-id="b6774-257">MainPage.xaml.cs ファイルで、次のコードを **MainPage** クラスに追加します。</span><span class="sxs-lookup"><span data-stu-id="b6774-257">In the MainPage.xaml.cs file, add the following code to the **MainPage** class.</span></span>

```cs
async private System.Threading.Tasks.Task<List<Windows.Storage.StorageFile>> GetImageList(Windows.Storage.StorageFolder folder)
{
    var result = await folder.GetFilesAsync();
    var subFolders = await folder.GetFoldersAsync();
    foreach (Windows.Storage.StorageFolder f in subFolders)
        result = result.Union(await GetImageList(f)).ToList();

    return (from f in result orderby f.Name select f).ToList();
}

async private System.Threading.Tasks.Task<Image> GetThumbnail(Windows.Storage.StorageFile img)
{
    // Get the thumbnail to display
    var thumbnail = await img.GetThumbnailAsync(Windows.Storage.FileProperties.ThumbnailMode.SingleItem,
                                                100,
                                                Windows.Storage.FileProperties.ThumbnailOptions.UseCurrentScale);

    // Create a XAML Image object bind to on the display page
    var result = new Image();
    result.Height = thumbnail.OriginalHeight;
    result.Width = thumbnail.OriginalWidth;
    result.Name = img.Name;
    var imageBitmap = new Windows.UI.Xaml.Media.Imaging.BitmapImage();
    imageBitmap.SetSource(thumbnail);
    result.Source = imageBitmap;

    return result;
}
```

### <a name="step-7-build-and-run-the-app"></a><span data-ttu-id="b6774-258">手順 7: アプリをビルドして実行する</span><span class="sxs-lookup"><span data-stu-id="b6774-258">Step 7: Build and run the app</span></span>

1.  <span data-ttu-id="b6774-259">F5 キーを押して、アプリを (デバッグ モードで) ビルドおよび展開します。</span><span class="sxs-lookup"><span data-stu-id="b6774-259">Press F5 to build and deploy the app (in debug mode).</span></span>
2.  <span data-ttu-id="b6774-260">アプリを実行するには、コンピューターにカメラを接続します。</span><span class="sxs-lookup"><span data-stu-id="b6774-260">To run your app, connect a camera to your machine.</span></span> <span data-ttu-id="b6774-261">次に、自動再生オプションの一覧からアプリを選びます。</span><span class="sxs-lookup"><span data-stu-id="b6774-261">Then select the app from the AutoPlay list of options.</span></span>
    <span data-ttu-id="b6774-262">**注:** **\\imagesource**自動再生デバイス イベントのすべてのカメラをアドバタイズします。</span><span class="sxs-lookup"><span data-stu-id="b6774-262">**Note**Not all cameras advertise for the **WPD\\ImageSource** AutoPlay device event.</span></span>

## <a name="configure-removable-storage"></a><span data-ttu-id="b6774-263">リムーバブル記憶域を構成する</span><span class="sxs-lookup"><span data-stu-id="b6774-263">Configure removable storage</span></span>

<span data-ttu-id="b6774-264">メモリ カードやサム ドライブなどのボリューム デバイスが PC に接続されたとき、そのボリューム デバイスを**自動再生**デバイスとして識別することができます。</span><span class="sxs-lookup"><span data-stu-id="b6774-264">You can identify a volume device such as a memory card or thumb drive as an **AutoPlay** device when the volume device is connected to a PC.</span></span> <span data-ttu-id="b6774-265">これは、特定のアプリを**自動再生**に関連付けて、ボリューム デバイスのユーザーに提示する場合などに活用できます。</span><span class="sxs-lookup"><span data-stu-id="b6774-265">This is especially useful when you want to associate a specific app for **AutoPlay** to present to the user for your volume device.</span></span>

<span data-ttu-id="b6774-266">ここでは、**自動再生**デバイスとしてボリューム デバイスを識別する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="b6774-266">Here we show how to identify your volume device as an **AutoPlay** device.</span></span>

<span data-ttu-id="b6774-267">ボリューム デバイスを**自動再生**デバイスとして識別するには、デバイスのルート ドライブに autorun.inf ファイルを追加します。</span><span class="sxs-lookup"><span data-stu-id="b6774-267">To identify your volume device as an **AutoPlay** device, add an autorun.inf file to the root drive of your device.</span></span> <span data-ttu-id="b6774-268">そして、autorun.inf ファイルの **AutoRun** セクションに **CustomEvent** キーを追加します。</span><span class="sxs-lookup"><span data-stu-id="b6774-268">In the autorun.inf file, add a **CustomEvent** key to the **AutoRun** section.</span></span> <span data-ttu-id="b6774-269">PC にボリューム デバイスが接続されると、**自動再生**が autorun.inf ファイルを検索し、ボリュームをデバイスとして扱います。</span><span class="sxs-lookup"><span data-stu-id="b6774-269">When your volume device connects to a PC, **AutoPlay** will find the autorun.inf file and treat your volume as a device.</span></span> <span data-ttu-id="b6774-270">**自動再生**は、**CustomEvent** キーに指定された名前を使って**自動再生**イベントを作成します。</span><span class="sxs-lookup"><span data-stu-id="b6774-270">**AutoPlay** will create an **AutoPlay** event by using the name that you supplied for the **CustomEvent** key.</span></span> <span data-ttu-id="b6774-271">それからアプリを作成し、その**自動再生**イベントのハンドラーとしてアプリを登録できます。</span><span class="sxs-lookup"><span data-stu-id="b6774-271">You can then create an app and register the app as a handler for that **AutoPlay** event.</span></span> <span data-ttu-id="b6774-272">PC にデバイスが接続されると、**自動再生**が、ボリューム デバイスのハンドラーとしてアプリを表示します。</span><span class="sxs-lookup"><span data-stu-id="b6774-272">When the device is connected to the PC, **AutoPlay** will show your app as a handler for your volume device.</span></span> <span data-ttu-id="b6774-273">autorun.inf ファイルについて詳しくは、「[Autorun.inf エントリ](https://msdn.microsoft.com/library/windows/desktop/cc144200)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b6774-273">For more info on autorun.inf files, see [autorun.inf entries](https://msdn.microsoft.com/library/windows/desktop/cc144200).</span></span>

### <a name="step-1-create-an-autoruninf-file"></a><span data-ttu-id="b6774-274">手順 1: autorun.inf ファイルを作成する</span><span class="sxs-lookup"><span data-stu-id="b6774-274">Step 1: Create an autorun.inf file</span></span>

<span data-ttu-id="b6774-275">ボリューム デバイスのルート ドライブに autorun.inf という名前のファイルを追加します。</span><span class="sxs-lookup"><span data-stu-id="b6774-275">In the root drive of your volume device, add a file named autorun.inf.</span></span> <span data-ttu-id="b6774-276">autorun.inf ファイルを開き、次のテキストを追加します。</span><span class="sxs-lookup"><span data-stu-id="b6774-276">Open the autorun.inf file and add the following text.</span></span>

``` syntax
[AutoRun]
CustomEvent=AutoPlayCustomEventQuickstart
```

### <a name="step-2-create-a-new-project-and-add-autoplay-declarations"></a><span data-ttu-id="b6774-277">手順 2: 新しいプロジェクトを作成し、自動再生宣言を追加する</span><span class="sxs-lookup"><span data-stu-id="b6774-277">Step 2: Create a new project and add AutoPlay declarations</span></span>

1.  <span data-ttu-id="b6774-278">Visual Studio を開き、**[ファイル]** メニューの **[新しいプロジェクト]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="b6774-278">Open Visual Studio and select **New Project** from the **File** menu.</span></span> <span data-ttu-id="b6774-279">**Visual C#** セクションの **[Windows]** で **[空白のアプリ (ユニバーサル Windows)]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="b6774-279">In the **Visual C#** section, under **Windows**, select **Blank App (Universal Windows)**.</span></span> <span data-ttu-id="b6774-280">アプリに **AutoPlayCustomEvent** という名前を付け、**[OK]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="b6774-280">Name the application **AutoPlayCustomEvent** and click **OK.**</span></span>
2.  <span data-ttu-id="b6774-281">[Package.appxmanifest] ファイルを開き、**[機能]** タブを選択します。**[リムーバブル記憶域]** 機能を選択します。</span><span class="sxs-lookup"><span data-stu-id="b6774-281">Open the Package.appxmanifest file and select the **Capabilities** tab. Select the **Removable Storage** capability.</span></span> <span data-ttu-id="b6774-282">これで、アプリはリムーバブル記憶域デバイス上のファイルとフォルダーにアクセスできるようになります。</span><span class="sxs-lookup"><span data-stu-id="b6774-282">This gives the app access to the files and folders on removable storage devices.</span></span>
3.  <span data-ttu-id="b6774-283">マニフェスト ファイルで **[宣言]** タブを選び、**[使用可能な宣言]** ドロップダウンから **[自動再生コンテンツ]** を選んで **[追加]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="b6774-283">In the manifest file, select the **Declarations** tab. In the **Available Declarations** drop-down list, select **AutoPlay Content** and click **Add**.</span></span> <span data-ttu-id="b6774-284">**[サポートされる宣言]** ボックスの一覧に追加された新しい **[自動再生コンテンツ]** 項目を選びます。</span><span class="sxs-lookup"><span data-stu-id="b6774-284">Select the new **AutoPlay Content** item that was added to the **Supported Declarations** list.</span></span>

    <span data-ttu-id="b6774-285">**注:** または、こともできますカスタム自動再生イベントに対して**自動再生デバイス**宣言を追加します。</span><span class="sxs-lookup"><span data-stu-id="b6774-285">**Note**Alternatively, you can also choose to add an **AutoPlay Device** declaration for your custom AutoPlay event.</span></span>  
4.  <span data-ttu-id="b6774-286">**[自動再生コンテンツ]** イベント宣言の **[起動アクション]** セクションで、最初の起動アクションについて下記の表の値を入力します。</span><span class="sxs-lookup"><span data-stu-id="b6774-286">In the **Launch Actions** section for your **AutoPlay Content** event declaration, enter the values in the table below for the first launch action.</span></span>
5.  <span data-ttu-id="b6774-287">**[使用可能な宣言]** ドロップダウン リストで、**[ファイルの種類の関連付け]** を選び、**[追加]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="b6774-287">In the **Available Declarations** drop-down list, select **File Type Associations** and click **Add**.</span></span> <span data-ttu-id="b6774-288">新しい **[ファイルの種類の関連付け]** 宣言の [プロパティ] で、**[表示名]** フィールドを **".ms ファイルを表示する"**、**[名前]** フィールドを **ms\_association** に設定します。</span><span class="sxs-lookup"><span data-stu-id="b6774-288">In the Properties of the new **File Type Associations** declaration, set the **Display Name** field to **Show .ms Files** and the **Name** field to **ms\_association**.</span></span> <span data-ttu-id="b6774-289">**[サポートされるファイルの種類]** セクションで、**[新規追加]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="b6774-289">In the **Supported File Types** section, click **Add New**.</span></span> <span data-ttu-id="b6774-290">**[ファイルの種類]** フィールドを **.ms** に設定します。</span><span class="sxs-lookup"><span data-stu-id="b6774-290">Set the **File Type** field to **.ms**.</span></span> <span data-ttu-id="b6774-291">コンテンツ イベントの場合は、自動再生で、アプリに明示的に関連付けられていないファイルの種類はすべて除外されます。</span><span class="sxs-lookup"><span data-stu-id="b6774-291">For content events, AutoPlay filters out any file types that aren't explicitly associated with your app.</span></span>
6.  <span data-ttu-id="b6774-292">マニフェスト ファイルを保存して閉じます。</span><span class="sxs-lookup"><span data-stu-id="b6774-292">Save and close the manifest file.</span></span>

| <span data-ttu-id="b6774-293">設定</span><span class="sxs-lookup"><span data-stu-id="b6774-293">Setting</span></span>             | <span data-ttu-id="b6774-294">値</span><span class="sxs-lookup"><span data-stu-id="b6774-294">Value</span></span>                         |
|---------------------|-------------------------------|
| <span data-ttu-id="b6774-295">動詞</span><span class="sxs-lookup"><span data-stu-id="b6774-295">Verb</span></span>                | <span data-ttu-id="b6774-296">show</span><span class="sxs-lookup"><span data-stu-id="b6774-296">show</span></span>                          |
| <span data-ttu-id="b6774-297">アクションの表示名</span><span class="sxs-lookup"><span data-stu-id="b6774-297">Action Display Name</span></span> | <span data-ttu-id="b6774-298">ファイルを表示する</span><span class="sxs-lookup"><span data-stu-id="b6774-298">Show Files</span></span>                    |
| <span data-ttu-id="b6774-299">コンテンツ イベント</span><span class="sxs-lookup"><span data-stu-id="b6774-299">Content Event</span></span>       | <span data-ttu-id="b6774-300">AutoPlayCustomEventQuickstart</span><span class="sxs-lookup"><span data-stu-id="b6774-300">AutoPlayCustomEventQuickstart</span></span> |

<span data-ttu-id="b6774-301">**[コンテンツ イベント]** の値は、autorun.inf ファイルの **CustomEvent** キーに指定したテキストです。</span><span class="sxs-lookup"><span data-stu-id="b6774-301">The **Content Event** value is the text that you supplied for the **CustomEvent** key in your autorun.inf file.</span></span> <span data-ttu-id="b6774-302">**[アクションの表示名]** 設定では、アプリの自動再生で表示される文字列を指定します。</span><span class="sxs-lookup"><span data-stu-id="b6774-302">The **Action Display Name** setting identifies the string that AutoPlay displays for your app.</span></span> <span data-ttu-id="b6774-303">**[動詞]** 設定では、選んだオプションでアプリに渡される値を指定します。</span><span class="sxs-lookup"><span data-stu-id="b6774-303">The **Verb** setting identifies a value that is passed to your app for the selected option.</span></span> <span data-ttu-id="b6774-304">自動再生のイベントの起動アクションは複数指定できます。また、**[動詞]** 設定を使って、ユーザーがアプリで選んだアクションを確認できます。</span><span class="sxs-lookup"><span data-stu-id="b6774-304">You can specify multiple launch actions for an AutoPlay event and use the **Verb** setting to determine which option a user has selected for your app.</span></span> <span data-ttu-id="b6774-305">アプリに渡される起動イベント引数の **verb** プロパティを調べることでユーザーが選んだオプションを確認できます。</span><span class="sxs-lookup"><span data-stu-id="b6774-305">You can tell which option the user selected by checking the **verb** property of the startup event arguments passed to your app.</span></span> <span data-ttu-id="b6774-306">**[動詞]** 設定には任意の値を使うことができます。ただし、予約されている **open** を除きます。</span><span class="sxs-lookup"><span data-stu-id="b6774-306">You can use any value for the **Verb** setting except, **open**, which is reserved.</span></span>

### <a name="step-3-add-xaml-ui"></a><span data-ttu-id="b6774-307">手順 3: XAML UI を追加する</span><span class="sxs-lookup"><span data-stu-id="b6774-307">Step 3: Add XAML UI</span></span>

<span data-ttu-id="b6774-308">MainPage.xaml ファイルを開き、次の XAML を既定の &lt;Grid&gt; セクションに追加します。</span><span class="sxs-lookup"><span data-stu-id="b6774-308">Open the MainPage.xaml file and add the following XAML to the default &lt;Grid&gt; section.</span></span>

```xml
<StackPanel Orientation="Vertical">
    <TextBlock FontSize="28" Margin="10,0,800,0">Files</TextBlock>
    <TextBlock x:Name="FilesBlock" FontSize="22" Height="600" Margin="10,0,800,0" />
</StackPanel>
```

### <a name="step-4-add-activation-code"></a><span data-ttu-id="b6774-309">手順 4: アクティブ化コードを追加する</span><span class="sxs-lookup"><span data-stu-id="b6774-309">Step 4: Add activation code</span></span>

<span data-ttu-id="b6774-310">この手順のコードは、ボリューム デバイスのルート ドライブにあるフォルダーを表示するメソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="b6774-310">The code in this step calls a method to display the folders in the root drive of your volume device.</span></span> <span data-ttu-id="b6774-311">自動再生コンテンツ イベントの場合、自動再生により、**OnFileActivated** イベント中にアプリに渡された起動引数でストレージ デバイスのルート フォルダーが渡されます。</span><span class="sxs-lookup"><span data-stu-id="b6774-311">For the AutoPlay content events, AutoPlay passes the root folder of the storage device in the startup arguments passed to the application during the **OnFileActivated** event.</span></span> <span data-ttu-id="b6774-312">このフォルダーは **Files** プロパティの最初の要素から取得できます。</span><span class="sxs-lookup"><span data-stu-id="b6774-312">You can retrieve this folder from the first element of the **Files** property.</span></span>

<span data-ttu-id="b6774-313">App.xaml.cs ファイルを開いて、次のコードを **App** クラスに追加します。</span><span class="sxs-lookup"><span data-stu-id="b6774-313">Open the App.xaml.cs file and add the following code to the **App** class.</span></span>

```cs
protected override void OnFileActivated(FileActivatedEventArgs args)
{
    var rootFrame = Window.Current.Content as Frame;
    var page = rootFrame.Content as MainPage;

    // Call ShowFolders with root folder from device storage.
    page.DisplayFiles(args.Files[0] as Windows.Storage.StorageFolder);

    base.OnFileActivated(args);
}
```

> <span data-ttu-id="b6774-314">**注:**、`DisplayFiles`メソッドは、次の手順で追加されます。</span><span class="sxs-lookup"><span data-stu-id="b6774-314">**Note**The `DisplayFiles` method is added in the following step.</span></span>

 

### <a name="step-5-add-code-to-display-folders"></a><span data-ttu-id="b6774-315">手順 5: フォルダーを表示するコードを追加する</span><span class="sxs-lookup"><span data-stu-id="b6774-315">Step 5: Add code to display folders</span></span>

<span data-ttu-id="b6774-316">MainPage.xaml.cs ファイルで、次のコードを **MainPage** クラスに追加します。</span><span class="sxs-lookup"><span data-stu-id="b6774-316">In the MainPage.xaml.cs file add the following code to the **MainPage** class.</span></span>

```cs
internal async void DisplayFiles(Windows.Storage.StorageFolder folder)
{
    foreach (Windows.Storage.StorageFile f in await ReadFiles(folder, ".ms"))
    {
        FilesBlock.Text += "  " + f.Name + "\n";
    }
}

internal async System.Threading.Tasks.Task<IReadOnlyList<Windows.Storage.StorageFile>>
    ReadFiles(Windows.Storage.StorageFolder folder, string fileExtension)
{
    var options = new Windows.Storage.Search.QueryOptions();
    options.FileTypeFilter.Add(fileExtension);
    var query = folder.CreateFileQueryWithOptions(options);
    var files = await query.GetFilesAsync();

    return files;
}
```

### <a name="step-6-build-and-run-the-qpp"></a><span data-ttu-id="b6774-317">手順 6: アプリをビルドして実行する</span><span class="sxs-lookup"><span data-stu-id="b6774-317">Step 6: Build and run the qpp</span></span>

1.  <span data-ttu-id="b6774-318">F5 キーを押して、アプリを (デバッグ モードで) ビルドおよび展開します。</span><span class="sxs-lookup"><span data-stu-id="b6774-318">Press F5 to build and deploy the app (in debug mode).</span></span>
2.  <span data-ttu-id="b6774-319">アプリを実行するには、メモリ カードまたは他のストレージ デバイスを PC に挿入します。</span><span class="sxs-lookup"><span data-stu-id="b6774-319">To run your app, insert a memory card or another storage device into your PC.</span></span> <span data-ttu-id="b6774-320">そして、自動再生ハンドラー オプションの一覧からアプリを選びます。</span><span class="sxs-lookup"><span data-stu-id="b6774-320">Then select your app from the list of AutoPlay handler options.</span></span>

## <a name="autoplay-event-reference"></a><span data-ttu-id="b6774-321">自動再生イベント リファレンス</span><span class="sxs-lookup"><span data-stu-id="b6774-321">AutoPlay event reference</span></span>


<span data-ttu-id="b6774-322">**自動再生**システムを使うと、さまざまなデバイスやボリューム (ディスク) の到着イベントにアプリを登録できます。</span><span class="sxs-lookup"><span data-stu-id="b6774-322">The **AutoPlay** system allows apps to register for a variety of device and volume (disk) arrival events.</span></span> <span data-ttu-id="b6774-323">**自動再生**コンテンツ イベントに登録するには、パッケージ マニフェストで **[リムーバブル記憶域]** 機能を有効にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="b6774-323">To register for **AutoPlay** content events, you must enable the **Removable Storage** capability in your package manifest.</span></span> <span data-ttu-id="b6774-324">次の表で、登録できるイベントと、それらのイベントが発生するタイミングについて説明します。</span><span class="sxs-lookup"><span data-stu-id="b6774-324">This table shows the events that you can register for and when they are raised.</span></span>

| <span data-ttu-id="b6774-325">シナリオ</span><span class="sxs-lookup"><span data-stu-id="b6774-325">Scenario</span></span>                                                           | <span data-ttu-id="b6774-326">イベント</span><span class="sxs-lookup"><span data-stu-id="b6774-326">Event</span></span>                              | <span data-ttu-id="b6774-327">説明</span><span class="sxs-lookup"><span data-stu-id="b6774-327">Description</span></span>   |
|--------------------------------------------------------------------|------------------------------------|---------------|
| <span data-ttu-id="b6774-328">カメラで写真を使う</span><span class="sxs-lookup"><span data-stu-id="b6774-328">Using photos on a Camera</span></span>                                           | **<span data-ttu-id="b6774-329">WPD\ImageSource</span><span class="sxs-lookup"><span data-stu-id="b6774-329">WPD\ImageSource</span></span>**                | <span data-ttu-id="b6774-330">Windows ポータブル デバイスとして指定されているカメラに対して発生し、ImageSource 機能を提供します。</span><span class="sxs-lookup"><span data-stu-id="b6774-330">Raised for cameras that are identified as Windows Portable Devices and offer the ImageSource capability.</span></span> |
| <span data-ttu-id="b6774-331">オーディオ プレーヤーで音楽を使う</span><span class="sxs-lookup"><span data-stu-id="b6774-331">Using music on an audio player</span></span>                                     | **<span data-ttu-id="b6774-332">WPD\AudioSource</span><span class="sxs-lookup"><span data-stu-id="b6774-332">WPD\AudioSource</span></span>**                | <span data-ttu-id="b6774-333">Windows ポータブル デバイスとして指定されているメディア プレーヤーに対して発生し、AudioSource 機能を提供します。</span><span class="sxs-lookup"><span data-stu-id="b6774-333">Raised for media players that are identified as Windows Portable Devices and offer the AudioSource capability.</span></span> |
| <span data-ttu-id="b6774-334">ビデオ カメラでビデオを使う</span><span class="sxs-lookup"><span data-stu-id="b6774-334">Using videos on a video camera</span></span>                                     | **<span data-ttu-id="b6774-335">WPD\VideoSource</span><span class="sxs-lookup"><span data-stu-id="b6774-335">WPD\VideoSource</span></span>**                | <span data-ttu-id="b6774-336">Windows ポータブル デバイスとして指定されているビデオ カメラに対して発生し、VideoSource 機能を提供します。</span><span class="sxs-lookup"><span data-stu-id="b6774-336">Raised for video cameras that are identified as Windows Portable Devices and offer the VideoSource capability.</span></span> |
| <span data-ttu-id="b6774-337">接続されているフラッシュ ドライブまたは外部ハード ドライブにアクセスする</span><span class="sxs-lookup"><span data-stu-id="b6774-337">Access a connected flash drive or external hard drive</span></span>              | **<span data-ttu-id="b6774-338">StorageOnArrival</span><span class="sxs-lookup"><span data-stu-id="b6774-338">StorageOnArrival</span></span>**               | <span data-ttu-id="b6774-339">ドライブまたはボリュームが PC 接続されると発生します。</span><span class="sxs-lookup"><span data-stu-id="b6774-339">Raised when a drive or volume is connected to the PC.</span></span>   <span data-ttu-id="b6774-340">ドライブまたはボリュームのディスクのルートに DCIM、AVCHD、または PRIVATE\ACHD フォルダーが含まれている場合、代わりに **ShowPicturesOnArrival** イベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="b6774-340">If the drive or volume contains a DCIM, AVCHD, or PRIVATE\ACHD folder in the root of the disk, the **ShowPicturesOnArrival** event is raised instead.</span></span> |
| <span data-ttu-id="b6774-341">大容量記憶装置 (レガシ) の写真を使う</span><span class="sxs-lookup"><span data-stu-id="b6774-341">Using photos from mass storage (legacy)</span></span>                            | **<span data-ttu-id="b6774-342">ShowPicturesOnArrival</span><span class="sxs-lookup"><span data-stu-id="b6774-342">ShowPicturesOnArrival</span></span>**          | <span data-ttu-id="b6774-343">ドライブまたはボリュームのディスクのルートに DCIM、AVCHD、または PRIVATE\ACHD フォルダーが含まれている場合に発生します。</span><span class="sxs-lookup"><span data-stu-id="b6774-343">Raised when a drive or volume contains a DCIM, AVCHD, or PRIVATE\ACHD folder in the root of the disk.</span></span> <span data-ttu-id="b6774-344">自動再生コントロール パネルで **[各メディア タイプの処理方法を選択する]** を有効にしている場合は、自動再生によって PC に接続されているボリュームが調べられ、ディスク上のコンテンツの種類が確認されます。</span><span class="sxs-lookup"><span data-stu-id="b6774-344">IIf a user  has enabled **Choose what to do with each type of media** in the AutoPlay Control Panel, AutoPlay will examine a volume connected to the PC to determine the type of content on the disk.</span></span> <span data-ttu-id="b6774-345">画像が見つかると、**ShowPicturesOnArrival** が発生します。</span><span class="sxs-lookup"><span data-stu-id="b6774-345">When pictures are found, **ShowPicturesOnArrival** is raised.</span></span> |
| <span data-ttu-id="b6774-346">近接共有 (タップして送信) で写真を受信する</span><span class="sxs-lookup"><span data-stu-id="b6774-346">Receiving photos with Proximity Sharing (tap and send)</span></span>             | **<span data-ttu-id="b6774-347">ShowPicturesOnArrival</span><span class="sxs-lookup"><span data-stu-id="b6774-347">ShowPicturesOnArrival</span></span>**          | <span data-ttu-id="b6774-348">コンテンツを近接通信を使って送信 (タップして送信) すると、自動再生によって共有ファイルが調べられ、コンテンツの種類が確認されます。</span><span class="sxs-lookup"><span data-stu-id="b6774-348">When users send content with using proximity (tap and send), AutoPlay will examine the shared files to determine the type of content.</span></span> <span data-ttu-id="b6774-349">画像が見つかった場合、**ShowPicturesOnArrival** が発生します。</span><span class="sxs-lookup"><span data-stu-id="b6774-349">If pictures are found, **ShowPicturesOnArrival** is raised.</span></span> |
| <span data-ttu-id="b6774-350">大容量記憶装置 (レガシ) の音楽を使う</span><span class="sxs-lookup"><span data-stu-id="b6774-350">Using music from mass storage (legacy)</span></span>                             | **<span data-ttu-id="b6774-351">PlayMusicFilesOnArrival</span><span class="sxs-lookup"><span data-stu-id="b6774-351">PlayMusicFilesOnArrival</span></span>**        | <span data-ttu-id="b6774-352">自動再生コントロール パネルで **[各メディア タイプの処理方法を選択する]** を有効にしている場合は、自動再生によって PC に接続されているボリュームが調べられ、ディスク上のコンテンツの種類が確認されます。</span><span class="sxs-lookup"><span data-stu-id="b6774-352">If a user has enabled **Choose what to do with each type of media** in the AutoPlay Control Panel, AutoPlay will examine a volume connected to the PC to determine the type of content on the disk.</span></span>  <span data-ttu-id="b6774-353">音楽ファイルが見つかると、**PlayMusicFilesOnArrival** が発生します。</span><span class="sxs-lookup"><span data-stu-id="b6774-353">When music files are found, **PlayMusicFilesOnArrival** is raised.</span></span> |
| <span data-ttu-id="b6774-354">近接共有 (タップして送信) で音楽を受信する</span><span class="sxs-lookup"><span data-stu-id="b6774-354">Receiving music with Proximity Sharing (tap and send)</span></span>              | **<span data-ttu-id="b6774-355">PlayMusicFilesOnArrival</span><span class="sxs-lookup"><span data-stu-id="b6774-355">PlayMusicFilesOnArrival</span></span>**        | <span data-ttu-id="b6774-356">コンテンツを近接通信を使って送信 (タップして送信) すると、自動再生によって共有ファイルが調べられ、コンテンツの種類が確認されます。</span><span class="sxs-lookup"><span data-stu-id="b6774-356">When users send content with using proximity (tap and send), AutoPlay will examine the shared files to determine the type of content.</span></span> <span data-ttu-id="b6774-357">音楽ファイルが見つかった場合、**PlayMusicFilesOnArrival** が発生します。</span><span class="sxs-lookup"><span data-stu-id="b6774-357">If music files are found, **PlayMusicFilesOnArrival** is raised.</span></span> |
| <span data-ttu-id="b6774-358">大容量記憶装置 (レガシ) のビデオを使う</span><span class="sxs-lookup"><span data-stu-id="b6774-358">Using videos from mass storage (legacy)</span></span>                            | **<span data-ttu-id="b6774-359">PlayVideoFilesOnArrival</span><span class="sxs-lookup"><span data-stu-id="b6774-359">PlayVideoFilesOnArrival</span></span>**        | <span data-ttu-id="b6774-360">自動再生コントロール パネルで **[各メディア タイプの処理方法を選択する]** を有効にしている場合は、自動再生によって PC に接続されているボリュームが調べられ、ディスク上のコンテンツの種類が確認されます。</span><span class="sxs-lookup"><span data-stu-id="b6774-360">If a user has enabled **Choose what to do with each type of media** in the AutoPlay Control Panel, AutoPlay will examine a volume connected to the PC to determine the type of content on the disk.</span></span> <span data-ttu-id="b6774-361">ビデオ ファイルが見つかると、**PlayVideoFilesOnArrival** が発生します。</span><span class="sxs-lookup"><span data-stu-id="b6774-361">When video files are found, **PlayVideoFilesOnArrival** is raised.</span></span> |
| <span data-ttu-id="b6774-362">近接共有 (タップして送信) でビデオを受信する</span><span class="sxs-lookup"><span data-stu-id="b6774-362">Receiving videos with Proximity Sharing (tap and send)</span></span>             | **<span data-ttu-id="b6774-363">PlayVideoFilesOnArrival</span><span class="sxs-lookup"><span data-stu-id="b6774-363">PlayVideoFilesOnArrival</span></span>**        | <span data-ttu-id="b6774-364">コンテンツを近接通信を使って送信 (タップして送信) すると、自動再生によって共有ファイルが調べられ、コンテンツの種類が確認されます。</span><span class="sxs-lookup"><span data-stu-id="b6774-364">When users send content with using proximity (tap and send), AutoPlay will examine the shared files to determine the type of content.</span></span> <span data-ttu-id="b6774-365">ビデオ ファイルが見つかった場合、**PlayVideoFilesOnArrival** が発生します。</span><span class="sxs-lookup"><span data-stu-id="b6774-365">If video files are found, **PlayVideoFilesOnArrival** is raised.</span></span> |
| <span data-ttu-id="b6774-366">接続先デバイスの混在したファイルのセットを処理する</span><span class="sxs-lookup"><span data-stu-id="b6774-366">Handling mixed sets of files from a connected device</span></span>               | **<span data-ttu-id="b6774-367">MixedContentOnArrival</span><span class="sxs-lookup"><span data-stu-id="b6774-367">MixedContentOnArrival</span></span>**          | <span data-ttu-id="b6774-368">自動再生コントロール パネルで **[各メディア タイプの処理方法を選択する]** を有効にしている場合は、自動再生によって PC に接続されているボリュームが調べられ、ディスク上のコンテンツの種類が確認されます。</span><span class="sxs-lookup"><span data-stu-id="b6774-368">If a user has enabled **Choose what to do with each type of media** in the AutoPlay Control Panel, AutoPlay will examine a volume connected to the PC to determine the type of content on the disk.</span></span> <span data-ttu-id="b6774-369">特定のコンテンツの種類が見つかると (画像など)、**MixedContentOnArrival** が発生します。</span><span class="sxs-lookup"><span data-stu-id="b6774-369">If no specific content type is found (for example, pictures), **MixedContentOnArrival** is raised.</span></span> |
| <span data-ttu-id="b6774-370">近接共有 (タップして送信) で混在したファイルのセットを処理する</span><span class="sxs-lookup"><span data-stu-id="b6774-370">Handling mixed sets of files with Proximity Sharing (tap and send)</span></span> | **<span data-ttu-id="b6774-371">MixedContentOnArrival</span><span class="sxs-lookup"><span data-stu-id="b6774-371">MixedContentOnArrival</span></span>**          | <span data-ttu-id="b6774-372">コンテンツを近接通信を使って送信 (タップして送信) すると、自動再生によって共有ファイルが調べられ、コンテンツの種類が確認されます。</span><span class="sxs-lookup"><span data-stu-id="b6774-372">When users send content with using proximity (tap and send), AutoPlay will examine the shared files to determine the type of content.</span></span> <span data-ttu-id="b6774-373">特定のコンテンツの種類が見つかると (画像など)、**MixedContentOnArrival** が発生します。</span><span class="sxs-lookup"><span data-stu-id="b6774-373">If no specific content type is found (for example, pictures), **MixedContentOnArrival** is raised.</span></span> |
| <span data-ttu-id="b6774-374">光学式メディアのビデオを処理する</span><span class="sxs-lookup"><span data-stu-id="b6774-374">Handle video from optical media</span></span>                                    | **<span data-ttu-id="b6774-375">PlayDVDMovieOnArrival</span><span class="sxs-lookup"><span data-stu-id="b6774-375">PlayDVDMovieOnArrival</span></span>**<br />**<span data-ttu-id="b6774-376">PlayBluRayOnArrival</span><span class="sxs-lookup"><span data-stu-id="b6774-376">PlayBluRayOnArrival</span></span>**<br />**<span data-ttu-id="b6774-377">PlayVideoCDMovieOnArrival</span><span class="sxs-lookup"><span data-stu-id="b6774-377">PlayVideoCDMovieOnArrival</span></span>**<br />**<span data-ttu-id="b6774-378">PlaySuperVideoCDMovieOnArrival</span><span class="sxs-lookup"><span data-stu-id="b6774-378">PlaySuperVideoCDMovieOnArrival</span></span>** | <span data-ttu-id="b6774-379">光学式ドライブにディスクが挿入されると、自動再生はファイルを確認して、コンテンツの種類を決定します。</span><span class="sxs-lookup"><span data-stu-id="b6774-379">When a disk is inserted into the optical drive, AutoPlay will examine the files to determine the type of content.</span></span> <span data-ttu-id="b6774-380">ビデオのファイルが見つかった場合は、光学ディスクの種類に対応するイベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="b6774-380">When video files are found, the event corresponding to the type of optical disk is raised.</span></span> |
| <span data-ttu-id="b6774-381">光学式メディアの音楽を処理する</span><span class="sxs-lookup"><span data-stu-id="b6774-381">Handle music from optical media</span></span>                                    | **<span data-ttu-id="b6774-382">PlayCDAudioOnArrival</span><span class="sxs-lookup"><span data-stu-id="b6774-382">PlayCDAudioOnArrival</span></span>**<br />**<span data-ttu-id="b6774-383">PlayDVDAudioOnArrival</span><span class="sxs-lookup"><span data-stu-id="b6774-383">PlayDVDAudioOnArrival</span></span>** | <span data-ttu-id="b6774-384">光学式ドライブにディスクが挿入されると、自動再生はファイルを確認して、コンテンツの種類を決定します。</span><span class="sxs-lookup"><span data-stu-id="b6774-384">When a disk is inserted into the optical drive, AutoPlay will examine the files to determine the type of content.</span></span> <span data-ttu-id="b6774-385">音楽のファイルが見つかった場合は、光学ディスクの種類に対応するイベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="b6774-385">When music files are found, the event corresponding to the type of optical disk is raised.</span></span> |
| <span data-ttu-id="b6774-386">エンハンス ディスクを再生する</span><span class="sxs-lookup"><span data-stu-id="b6774-386">Play enhanced disks</span></span>                                                | **<span data-ttu-id="b6774-387">PlayEnhancedCDOnArrival</span><span class="sxs-lookup"><span data-stu-id="b6774-387">PlayEnhancedCDOnArrival</span></span>**<br />**<span data-ttu-id="b6774-388">PlayEnhancedDVDOnArrival</span><span class="sxs-lookup"><span data-stu-id="b6774-388">PlayEnhancedDVDOnArrival</span></span>** | <span data-ttu-id="b6774-389">光学式ドライブにディスクが挿入されると、自動再生はファイルを確認して、コンテンツの種類を決定します。</span><span class="sxs-lookup"><span data-stu-id="b6774-389">When a disk is inserted into the optical drive, AutoPlay will examine the files to determine the type of content.</span></span> <span data-ttu-id="b6774-390">エンハンス ディスクが見つかった場合は、光学ディスクの種類に対応するイベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="b6774-390">When an enhanced disk is found, the event corresponding to the type of optical disk is raised.</span></span> |
| <span data-ttu-id="b6774-391">書き込み可能な光学式ディスクを処理する</span><span class="sxs-lookup"><span data-stu-id="b6774-391">Handle writeable optical disks</span></span>                                     | **<span data-ttu-id="b6774-392">HandleCDBurningOnArrival</span><span class="sxs-lookup"><span data-stu-id="b6774-392">HandleCDBurningOnArrival</span></span>** <br />**<span data-ttu-id="b6774-393">HandleDVDBurningOnArrival</span><span class="sxs-lookup"><span data-stu-id="b6774-393">HandleDVDBurningOnArrival</span></span>** <br />**<span data-ttu-id="b6774-394">HandleBDBurningOnArrival</span><span class="sxs-lookup"><span data-stu-id="b6774-394">HandleBDBurningOnArrival</span></span>** | <span data-ttu-id="b6774-395">光学式ドライブにディスクが挿入されると、自動再生はファイルを確認して、コンテンツの種類を決定します。</span><span class="sxs-lookup"><span data-stu-id="b6774-395">When a disk is inserted into the optical drive, AutoPlay will examine the files to determine the type of content.</span></span> <span data-ttu-id="b6774-396">書き込み可能なディスクが見つかった場合は、光学ディスクの種類に対応するイベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="b6774-396">When a writable disk is found, the event corresponding to the type of optical disk is raised.</span></span> |
| <span data-ttu-id="b6774-397">他のデバイスまたはボリュームの接続を処理する</span><span class="sxs-lookup"><span data-stu-id="b6774-397">Handle any other device or volume connection</span></span>                       | **<span data-ttu-id="b6774-398">UnknownContentOnArrival</span><span class="sxs-lookup"><span data-stu-id="b6774-398">UnknownContentOnArrival</span></span>**        | <span data-ttu-id="b6774-399">自動再生コンテンツ イベントのいずれとも一致しないコンテンツが見つかった場合にすべてのイベントで発生します。</span><span class="sxs-lookup"><span data-stu-id="b6774-399">Raised for all events in case content is found that does not match any of the AutoPlay content events.</span></span> <span data-ttu-id="b6774-400">このイベントを使うことはお勧めできません。</span><span class="sxs-lookup"><span data-stu-id="b6774-400">Use of this event is not recommended.</span></span> <span data-ttu-id="b6774-401">処理できる特定の自動再生イベントにのみアプリを登録する必要があります。</span><span class="sxs-lookup"><span data-stu-id="b6774-401">You should only register your application for the specific AutoPlay events that it can handle.</span></span> |

<span data-ttu-id="b6774-402">ボリュームの autorun.inf ファイルの **CustomEvent** エントリを使って、自動再生でカスタムの自動再生コンテンツ イベントが発生することを指定できます。</span><span class="sxs-lookup"><span data-stu-id="b6774-402">You can specify that AutoPlay raise a custom AutoPlay Content event using the **CustomEvent** entry in the autorun.inf file for a volume.</span></span> <span data-ttu-id="b6774-403">詳しくは、「[Autorun.inf エントリ](https://msdn.microsoft.com/library/windows/desktop/cc144200)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b6774-403">For more info, see [Autorun.inf entries](https://msdn.microsoft.com/library/windows/desktop/cc144200).</span></span>

<span data-ttu-id="b6774-404">自動再生コンテンツまたは自動再生デバイスのイベント ハンドラーとしてアプリを登録するには、アプリの package.appxmanifest ファイルに拡張機能を追加します。</span><span class="sxs-lookup"><span data-stu-id="b6774-404">You can register your app as an AutoPlay Content or AutoPlay Device event handler by adding an extension to the package.appxmanifest file for your app.</span></span> <span data-ttu-id="b6774-405">Visual Studio を使う場合は、**[宣言]** タブで **[自動再生コンテンツ]** または **[自動再生デバイス]** の宣言を追加します。アプリの package.appxmanifest ファイルを直接編集する場合は、パッケージ マニフェストに[**拡張機能**](https://msdn.microsoft.com/library/windows/apps/br211400) 要素を追加し、**カテゴリ** として **windows.autoPlayContent** または **windows.autoPlayDevice** を指定します。</span><span class="sxs-lookup"><span data-stu-id="b6774-405">If you are using Visual Studio, you can add an **AutoPlay Content** or **AutoPlay Device** declaration in the **Declarations** tab. If you are editing the package.appxmanifest file for your app directly, add an [**Extension**](https://msdn.microsoft.com/library/windows/apps/br211400) element to your package manifest that specifies either **windows.autoPlayContent** or **windows.autoPlayDevice** as the **Category**.</span></span> <span data-ttu-id="b6774-406">たとえば、次のパッケージ マニフェストのエントリでは、**自動再生コンテンツ**拡張機能を追加して、アプリを **ShowPicturesOnArrival** イベントのハンドラーとして登録しています。</span><span class="sxs-lookup"><span data-stu-id="b6774-406">For example, the following entry in the package manifest adds an **AutoPlay Content** extension to register the app as a handler for the **ShowPicturesOnArrival** event.</span></span>

```xml
  <Applications>
    <Application Id="AutoPlayHandlerSample.App">
      <Extensions>
        <Extension Category="windows.autoPlayContent">
          <AutoPlayContent>
            <LaunchAction Verb="show" ActionDisplayName="Show Pictures"
                          ContentEvent="ShowPicturesOnArrival" />
          </AutoPlayContent>
        </Extension>
      </Extensions>
    </Application>
  </Applications>
```

 

 
