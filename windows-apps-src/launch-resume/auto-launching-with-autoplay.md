---
author: TylerMSFT
title: "自動再生による自動起動"
description: "自動再生を使って、コンピューターにデバイスが接続されたときのオプションとしてアプリを提供できます。 これには、カメラやメディア プレーヤーなどのボリューム デバイス以外のデバイス、または USB サム ドライブ、SD カード、DVD などのボリューム デバイスが含まれます。"
ms.assetid: AD4439EA-00B0-4543-887F-2C1D47408EA7
ms.author: twhitney
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: 92d8ed53f39f750755bc4fc2d23d4ca365718696
ms.sourcegitcommit: ba0d20f6fad75ce98c25ceead78aab6661250571
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/24/2017
---
# <a name="span-iddevlaunchresumeauto-launchingwithautoplayspanauto-launching-with-autoplay"></a><span data-ttu-id="07648-105"><span id="dev_launch_resume.auto-launching_with_autoplay"></span>自動再生による自動起動</span><span class="sxs-lookup"><span data-stu-id="07648-105"><span id="dev_launch_resume.auto-launching_with_autoplay"></span>Auto-launching with AutoPlay</span></span>


<span data-ttu-id="07648-106">\[Windows 10 の UWP アプリ向けに更新。</span><span class="sxs-lookup"><span data-stu-id="07648-106">\[ Updated for UWP apps on Windows 10.</span></span> <span data-ttu-id="07648-107">Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132) をご覧ください\]</span><span class="sxs-lookup"><span data-stu-id="07648-107">For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]</span></span>


<span data-ttu-id="07648-108">**自動再生**を使って、コンピューターにデバイスが接続されたときのオプションとしてアプリを提供できます。</span><span class="sxs-lookup"><span data-stu-id="07648-108">You can use **AutoPlay** to provide your app as an option when a user connects a device to their PC.</span></span> <span data-ttu-id="07648-109">これには、カメラやメディア プレーヤーなどのボリューム デバイス以外のデバイス、または USB サム ドライブ、SD カード、DVD などのボリューム デバイスが含まれます。</span><span class="sxs-lookup"><span data-stu-id="07648-109">This includes non-volume devices such as a camera or media player, or volume devices such as a USB thumb drive, SD card, or DVD.</span></span> <span data-ttu-id="07648-110">また**自動再生**では、近接通信 (タップ) を使って 2 台の PC 間でユーザーがファイルを共有するときにアプリをオプションとして提供することもできます。</span><span class="sxs-lookup"><span data-stu-id="07648-110">You can also use **AutoPlay** to offer your app as an option when users share files between two PCs by using proximity (tapping).</span></span>

> <span data-ttu-id="07648-111">**注:** デバイスの製造元がデバイスの**自動再生**ハンドラーとして [Windows ストア デバイス アプリ](http://go.microsoft.com/fwlink/p/?LinkID=301381)を関連付ける場合は、デバイス メタデータでアプリを識別することができます。</span><span class="sxs-lookup"><span data-stu-id="07648-111">**Note**  If you are a device manufacturer and you want to associate your [Windows Store device app](http://go.microsoft.com/fwlink/p/?LinkID=301381) as an **AutoPlay** handler for your device, you can identify that app in the device metadata.</span></span> <span data-ttu-id="07648-112">詳しくは、「[Windows ストア デバイス アプリの自動再生](http://go.microsoft.com/fwlink/p/?LinkId=306684)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="07648-112">For more info, see [AutoPlay for Windows Store device apps](http://go.microsoft.com/fwlink/p/?LinkId=306684).</span></span>

## <a name="register-for-autoplay-content"></a><span data-ttu-id="07648-113">自動再生コンテンツに登録する</span><span class="sxs-lookup"><span data-stu-id="07648-113">Register for AutoPlay content</span></span>

<span data-ttu-id="07648-114">アプリを**自動再生**コンテンツ イベントのオプションとして登録できます。</span><span class="sxs-lookup"><span data-stu-id="07648-114">You can register apps as options for **AutoPlay** content events.</span></span> <span data-ttu-id="07648-115">**自動再生**コンテンツ イベントは、カメラのメモリ カード、サム ドライブ、DVD などのボリューム デバイスが PC に挿入されたときに発生します。</span><span class="sxs-lookup"><span data-stu-id="07648-115">**AutoPlay** content events are raised when a volume device such as a camera memory card, thumb drive, or DVD is inserted into the PC.</span></span> <span data-ttu-id="07648-116">ここでは、カメラのボリューム デバイスが挿入されたときに**自動再生**オプションとしてアプリを識別する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="07648-116">Here we show how to identify your app as an **AutoPlay** option when a volume device from a camera is inserted.</span></span>

<span data-ttu-id="07648-117">このチュートリアルでは、画像ファイルを表示したり、ピクチャにそれらの画像をコピーしたりするアプリを作成しました。</span><span class="sxs-lookup"><span data-stu-id="07648-117">In this tutorial, you created an app that displays image files or copies them to Pictures.</span></span> <span data-ttu-id="07648-118">自動再生 **ShowPicturesOnArrival** コンテンツ イベントにアプリを登録しました。</span><span class="sxs-lookup"><span data-stu-id="07648-118">You registered the app for the AutoPlay **ShowPicturesOnArrival** content event.</span></span>

<span data-ttu-id="07648-119">自動再生では、近接通信 (タップ) を使って PC 間で共有されるコンテンツのコンテンツ イベントも発生します。</span><span class="sxs-lookup"><span data-stu-id="07648-119">AutoPlay also raises content events for content shared between PCs using proximity (tapping).</span></span> <span data-ttu-id="07648-120">このセクションで説明した手順とコードを使って、近接通信を使用する PC 間で共有されるファイルを処理できます。</span><span class="sxs-lookup"><span data-stu-id="07648-120">You can use the steps and code in this section to handle files that are shared between PCs that use proximity.</span></span> <span data-ttu-id="07648-121">次の表に、近接通信を使ってコンテンツを共有できる自動再生コンテンツ イベントを示します。</span><span class="sxs-lookup"><span data-stu-id="07648-121">The following table lists the AutoPlay content events that are available for sharing content by using proximity.</span></span>

| <span data-ttu-id="07648-122">アクション</span><span class="sxs-lookup"><span data-stu-id="07648-122">Action</span></span>         | <span data-ttu-id="07648-123">自動再生コンテンツ イベント</span><span class="sxs-lookup"><span data-stu-id="07648-123">AutoPlay content event</span></span>  |
|----------------|-------------------------|
| <span data-ttu-id="07648-124">音楽の共有</span><span class="sxs-lookup"><span data-stu-id="07648-124">Sharing music</span></span>  | <span data-ttu-id="07648-125">PlayMusicFilesOnArrival</span><span class="sxs-lookup"><span data-stu-id="07648-125">PlayMusicFilesOnArrival</span></span> |
| <span data-ttu-id="07648-126">ビデオの共有</span><span class="sxs-lookup"><span data-stu-id="07648-126">Sharing videos</span></span> | <span data-ttu-id="07648-127">PlayVideoFilesOnArrival</span><span class="sxs-lookup"><span data-stu-id="07648-127">PlayVideoFilesOnArrival</span></span> |

 
<span data-ttu-id="07648-128">ファイルが近接通信を使って共有されている場合、**FileActivatedEventArgs** オブジェクトの **Files** プロパティには、すべての共有ファイルを含むルート フォルダーへの参照が含まれます。</span><span class="sxs-lookup"><span data-stu-id="07648-128">When files are shared by using proximity, the **Files** property of the **FileActivatedEventArgs** object contains a reference to a root folder that contains all of the shared files.</span></span>

### <a name="step-1-create-a-new-project-and-add-autoplay-declarations"></a><span data-ttu-id="07648-129">手順 1: 新しいプロジェクトを作成し、自動再生宣言を追加する</span><span class="sxs-lookup"><span data-stu-id="07648-129">Step 1: Create a new project and add AutoPlay declarations</span></span>

1.  <span data-ttu-id="07648-130">Microsoft Visual Studio を開き、**[ファイル]** メニューの **[新しいプロジェクト]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="07648-130">Open Microsoft Visual Studio and select **New Project** from the **File** menu.</span></span> <span data-ttu-id="07648-131">**Visual C#** セクションの **[Windows]** で **[空白のアプリ (ユニバーサル Windows)]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="07648-131">In the **Visual C#** section, under **Windows**, select **Blank App (Universal Windows)**.</span></span> <span data-ttu-id="07648-132">アプリに **AutoPlayDisplayOrCopyImages** という名前を付け、**[OK]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="07648-132">Name the app **AutoPlayDisplayOrCopyImages** and click **OK.**</span></span>
2.  <span data-ttu-id="07648-133">Package.appxmanifest ファイルを開き、**[機能]** タブをクリックします。</span><span class="sxs-lookup"><span data-stu-id="07648-133">Open the Package.appxmanifest file and select the **Capabilities** tab.</span></span> <span data-ttu-id="07648-134">**[リムーバブル記憶域]** 機能と **[画像ライブラリ]** 機能を選びます。</span><span class="sxs-lookup"><span data-stu-id="07648-134">Select the **Removable Storage** and **Pictures Library** capabilities.</span></span> <span data-ttu-id="07648-135">これで、アプリはカメラ メモリのリムーバブル ストレージ デバイスと、ローカルの画像にアクセスできるようになります。</span><span class="sxs-lookup"><span data-stu-id="07648-135">This gives the app access to removable storage devices for camera memory, and access to local pictures.</span></span>
3.  <span data-ttu-id="07648-136">マニフェスト ファイルで、**[宣言]** タブをクリックします。</span><span class="sxs-lookup"><span data-stu-id="07648-136">In the manifest file, select the **Declarations** tab.</span></span> <span data-ttu-id="07648-137">**[使用可能な宣言]** ドロップダウン リストで、**[自動再生コンテンツ]** を選び、**[追加]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="07648-137">In the **Available Declarations** drop-down list, select **AutoPlay Content** and click **Add**.</span></span> <span data-ttu-id="07648-138">**[サポートされる宣言]** ボックスの一覧に追加された新しい **[自動再生コンテンツ]** 項目を選びます。</span><span class="sxs-lookup"><span data-stu-id="07648-138">Select the new **AutoPlay Content** item that was added to the **Supported Declarations** list.</span></span>
4.  <span data-ttu-id="07648-139">**[自動再生コンテンツ]** 宣言は、自動再生でコンテンツ イベントが発生したときに該当のアプリがオプションとして識別されます。</span><span class="sxs-lookup"><span data-stu-id="07648-139">An **AutoPlay Content** declaration identifies your app as an option when AutoPlay raises a content event.</span></span> <span data-ttu-id="07648-140">イベントは DVD やサム ドライブなどのボリューム デバイスのコンテンツに基づきます。</span><span class="sxs-lookup"><span data-stu-id="07648-140">The event is based on the content of a volume device such as a DVD or a thumb drive.</span></span> <span data-ttu-id="07648-141">自動再生ではボリューム デバイスのコンテンツを調べて、発生させるコンテンツ イベントを決定します。</span><span class="sxs-lookup"><span data-stu-id="07648-141">AutoPlay examines the content of the volume device and determines which content event to raise.</span></span> <span data-ttu-id="07648-142">ボリュームのルートに DCIM、AVCHD、または PRIVATE\\ACHD フォルダーが含まれる場合、または自動再生コントロール パネルで **[各メディア タイプの処理方法を選択する]** を有効にしていてボリュームのルートで画像が見つかった場合、自動再生で **ShowPicturesOnArrival** イベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="07648-142">If the root of the volume contains a DCIM, AVCHD, or PRIVATE\\ACHD folder, or if a user has enabled **Choose what to do with each type of media** in the AutoPlay Control Panel and pictures are found in the root of the volume, then AutoPlay raises the **ShowPicturesOnArrival** event.</span></span> <span data-ttu-id="07648-143">**[起動アクション]** セクションで、最初の起動アクションに対して下記の表 1 の値を入力します。</span><span class="sxs-lookup"><span data-stu-id="07648-143">In the **Launch Actions** section, enter the values from Table 1 below for the first launch action.</span></span>
5.  <span data-ttu-id="07648-144">**[自動再生コンテンツ]** 項目の **[起動アクション]** セクションで、**[新規追加]** をクリックし、2 つ目の起動アクションを追加します。</span><span class="sxs-lookup"><span data-stu-id="07648-144">In the **Launch Actions** section for the **AutoPlay Content** item, click **Add New** to add a second launch action.</span></span> <span data-ttu-id="07648-145">2 つ目の起動アクションについて、下記の表 2 の値を入力します。</span><span class="sxs-lookup"><span data-stu-id="07648-145">Enter the values in Table 2 below for the second launch action.</span></span>
6.  <span data-ttu-id="07648-146">**[使用可能な宣言]** ドロップダウン リストで、**[ファイルの種類の関連付け]** を選び、**[追加]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="07648-146">In the **Available Declarations** drop-down list, select **File Type Associations** and click **Add**.</span></span> <span data-ttu-id="07648-147">新しい **[ファイルの種類の関連付け]** 宣言の [プロパティ] で、**[表示名]** フィールドを **"自動再生コピー" または "画像を表示する"**、**[名前]** フィールドを **image\_association1** に設定します。</span><span class="sxs-lookup"><span data-stu-id="07648-147">In the Properties of the new **File Type Associations** declaration, set the **Display Name** field to **AutoPlay Copy or Show Images** and the **Name** field to **image\_association1**.</span></span> <span data-ttu-id="07648-148">**[サポートされるファイルの種類]** セクションで、**[新規追加]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="07648-148">In the **Supported File Types** section, click **Add New**.</span></span> <span data-ttu-id="07648-149">**[ファイルの種類]** フィールドを **.jpg** に設定します。</span><span class="sxs-lookup"><span data-stu-id="07648-149">Set the **File Type** field to **.jpg**.</span></span> <span data-ttu-id="07648-150">**[サポートされるファイルの種類]** セクションで、新しいファイルの関連付けの **[ファイルの種類]** フィールドを **.png** に設定します。</span><span class="sxs-lookup"><span data-stu-id="07648-150">In the **Supported File Types** section, set the **File Type** field of the new file association to **.png**.</span></span> <span data-ttu-id="07648-151">コンテンツ イベントの場合は、自動再生で、アプリに明示的に関連付けられていないファイルの種類はすべて除外されます。</span><span class="sxs-lookup"><span data-stu-id="07648-151">For content events, AutoPlay filters out any file types that are not explicitly associated with your app.</span></span>
7.  <span data-ttu-id="07648-152">マニフェスト ファイルを保存して閉じます。</span><span class="sxs-lookup"><span data-stu-id="07648-152">Save and close the manifest file.</span></span>


**<span data-ttu-id="07648-153">表 1</span><span class="sxs-lookup"><span data-stu-id="07648-153">Table 1</span></span>**

| <span data-ttu-id="07648-154">設定</span><span class="sxs-lookup"><span data-stu-id="07648-154">Setting</span></span>             | <span data-ttu-id="07648-155">値</span><span class="sxs-lookup"><span data-stu-id="07648-155">Value</span></span>                 |
|---------------------|-----------------------|
| <span data-ttu-id="07648-156">動詞</span><span class="sxs-lookup"><span data-stu-id="07648-156">Verb</span></span>                | <span data-ttu-id="07648-157">show</span><span class="sxs-lookup"><span data-stu-id="07648-157">show</span></span>                  |
| <span data-ttu-id="07648-158">アクションの表示名</span><span class="sxs-lookup"><span data-stu-id="07648-158">Action Display Name</span></span> | <span data-ttu-id="07648-159">画像を表示する</span><span class="sxs-lookup"><span data-stu-id="07648-159">Show Pictures</span></span>         |
| <span data-ttu-id="07648-160">コンテンツ イベント</span><span class="sxs-lookup"><span data-stu-id="07648-160">Content Event</span></span>       | <span data-ttu-id="07648-161">ShowPicturesOnArrival</span><span class="sxs-lookup"><span data-stu-id="07648-161">ShowPicturesOnArrival</span></span> |

<span data-ttu-id="07648-162">**[アクションの表示名]** 設定では、アプリの自動再生で表示される文字列を指定します。</span><span class="sxs-lookup"><span data-stu-id="07648-162">The **Action Display Name** setting identifies the string that AutoPlay displays for your app.</span></span> <span data-ttu-id="07648-163">**[動詞]** 設定では、選んだオプションでアプリに渡される値を指定します。</span><span class="sxs-lookup"><span data-stu-id="07648-163">The **Verb** setting identifies a value that is passed to your app for the selected option.</span></span> <span data-ttu-id="07648-164">自動再生のイベントの起動アクションは複数指定できます。また、**[動詞]** 設定を使って、ユーザーがアプリで選んだアクションを確認できます。</span><span class="sxs-lookup"><span data-stu-id="07648-164">You can specify multiple launch actions for an AutoPlay event and use the **Verb** setting to determine which option a user has selected for your app.</span></span> <span data-ttu-id="07648-165">アプリに渡される起動イベント引数の **verb** プロパティを調べることでユーザーが選んだオプションを確認できます。</span><span class="sxs-lookup"><span data-stu-id="07648-165">You can tell which option the user selected by checking the **verb** property of the startup event arguments passed to your app.</span></span> <span data-ttu-id="07648-166">**[動詞]** 設定には任意の値を使うことができます。ただし、予約されている **open** を除きます。</span><span class="sxs-lookup"><span data-stu-id="07648-166">You can use any value for the **Verb** setting except, **open**, which is reserved.</span></span>

**<span data-ttu-id="07648-167">表 2</span><span class="sxs-lookup"><span data-stu-id="07648-167">Table 2</span></span>**  

| <span data-ttu-id="07648-168">設定</span><span class="sxs-lookup"><span data-stu-id="07648-168">Setting</span></span>             | <span data-ttu-id="07648-169">値</span><span class="sxs-lookup"><span data-stu-id="07648-169">Value</span></span>                      |
|---------------------|----------------------------|
| <span data-ttu-id="07648-170">動詞</span><span class="sxs-lookup"><span data-stu-id="07648-170">Verb</span></span>                | <span data-ttu-id="07648-171">copy</span><span class="sxs-lookup"><span data-stu-id="07648-171">copy</span></span>                       |
| <span data-ttu-id="07648-172">アクションの表示名</span><span class="sxs-lookup"><span data-stu-id="07648-172">Action Display Name</span></span> | <span data-ttu-id="07648-173">ライブラリに画像をコピーする</span><span class="sxs-lookup"><span data-stu-id="07648-173">Copy Pictures Into Library</span></span> |
| <span data-ttu-id="07648-174">コンテンツ イベント</span><span class="sxs-lookup"><span data-stu-id="07648-174">Content Event</span></span>       | <span data-ttu-id="07648-175">ShowPicturesOnArrival</span><span class="sxs-lookup"><span data-stu-id="07648-175">ShowPicturesOnArrival</span></span>      |

### <a name="step-2-add-xaml-ui"></a><span data-ttu-id="07648-176">手順 2: XAML UI を追加する</span><span class="sxs-lookup"><span data-stu-id="07648-176">Step 2: Add XAML UI</span></span>

<span data-ttu-id="07648-177">MainPage.xaml ファイルを開き、次の XAML を既定の &lt;Grid&gt; セクションに追加します。</span><span class="sxs-lookup"><span data-stu-id="07648-177">Open the MainPage.xaml file and add the following XAML to the default &lt;Grid&gt; section.</span></span>

```xml
<TextBlock FontSize="18">File List</TextBlock>
<TextBlock x:Name="FilesBlock" HorizontalAlignment="Left" TextWrapping="Wrap"
           VerticalAlignment="Top" Margin="0,20,0,0" Height="280" Width="240" />
<Canvas x:Name="FilesCanvas" HorizontalAlignment="Left" VerticalAlignment="Top"
        Margin="260,20,0,0" Height="280" Width="100"/>
```

### <a name="step-3-add-initialization-code"></a><span data-ttu-id="07648-178">手順 3: 初期化コードを追加する</span><span class="sxs-lookup"><span data-stu-id="07648-178">Step 3: Add initialization code</span></span>

<span data-ttu-id="07648-179">この手順のコードでは、**Verb** プロパティの verb 値をチェックします。これは、**OnFileActivated** イベントの間にアプリに渡される起動引数の 1 つです。</span><span class="sxs-lookup"><span data-stu-id="07648-179">The code in this step checks the verb value in the **Verb** property, which is one of the startup arguments passed to the app during the **OnFileActivated** event.</span></span> <span data-ttu-id="07648-180">次に、ユーザーが選んだオプションに関連するメソッドが呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="07648-180">The code then calls a method related to the option that the user selected.</span></span> <span data-ttu-id="07648-181">カメラのメモリ イベントの場合、自動再生により、カメラ ストレージのルート フォルダーがアプリに渡されます。</span><span class="sxs-lookup"><span data-stu-id="07648-181">For the camera memory event, AutoPlay passes the root folder of the camera storage to the app.</span></span> <span data-ttu-id="07648-182">このフォルダーは **Files** プロパティの最初の要素から取得できます。</span><span class="sxs-lookup"><span data-stu-id="07648-182">You can retrieve this folder from the first element of the **Files** property.</span></span>

<span data-ttu-id="07648-183">App.xaml.cs ファイルを開いて、次のコードを **App** クラスに追加します。</span><span class="sxs-lookup"><span data-stu-id="07648-183">Open the App.xaml.cs file and add the following code to the **App** class.</span></span>

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

> <span data-ttu-id="07648-184">**注:** `DisplayImages` メソッドと `CopyImages` メソッドは、以下の手順で追加されます。</span><span class="sxs-lookup"><span data-stu-id="07648-184">**Note**  The `DisplayImages` and `CopyImages` methods are added in the following steps.</span></span>

### <a name="step-4-add-code-to-display-images"></a><span data-ttu-id="07648-185">手順 4: 画像を表示するコードを追加する</span><span class="sxs-lookup"><span data-stu-id="07648-185">Step 4: Add code to display images</span></span>

<span data-ttu-id="07648-186">MainPage.xaml.cs ファイルで、次のコードを **MainPage** クラスに追加します。</span><span class="sxs-lookup"><span data-stu-id="07648-186">In the MainPage.xaml.cs file add the following code to the **MainPage** class.</span></span>

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

### <a name="step-5-add-code-to-copy-images"></a><span data-ttu-id="07648-187">手順 5: 画像をコピーするコードを追加する</span><span class="sxs-lookup"><span data-stu-id="07648-187">Step 5: Add code to copy images</span></span>

<span data-ttu-id="07648-188">MainPage.xaml.cs ファイルで、次のコードを **MainPage** クラスに追加します。</span><span class="sxs-lookup"><span data-stu-id="07648-188">In the MainPage.xaml.cs file add the following code to the **MainPage** class.</span></span>

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

### <a name="step-6-build-and-run-the-app"></a><span data-ttu-id="07648-189">手順 6: アプリをビルドして実行する</span><span class="sxs-lookup"><span data-stu-id="07648-189">Step 6: Build and run the app</span></span>

1.  <span data-ttu-id="07648-190">F5 キーを押して、アプリを (デバッグ モードで) ビルドおよび展開します。</span><span class="sxs-lookup"><span data-stu-id="07648-190">Press F5 to build and deploy the app (in debug mode).</span></span>
2.  <span data-ttu-id="07648-191">アプリを実行するには、カメラのメモリ カードまたはカメラの他のストレージ デバイスを PC に挿入します。</span><span class="sxs-lookup"><span data-stu-id="07648-191">To run your app, insert a camera memory card or another storage device from a camera into your PC.</span></span> <span data-ttu-id="07648-192">次に、自動再生のオプションの一覧から package.appxmanifest ファイルで指定したコンテンツ イベント オプションのいずれかを選びます。</span><span class="sxs-lookup"><span data-stu-id="07648-192">Then, select one of the content event options that you specified in your package.appxmanifest file from the AutoPlay list of options.</span></span> <span data-ttu-id="07648-193">このサンプル コードは、カメラのメモリ カードの DCIM フォルダーにある画像の表示またはコピーのみを行います。</span><span class="sxs-lookup"><span data-stu-id="07648-193">This sample code only displays or copies pictures in the DCIM folder of a camera memory card.</span></span> <span data-ttu-id="07648-194">カメラのメモリ カードの AVCHD または PRIVATE\\ACHD フォルダーに画像が格納される場合は、適宜コードを更新する必要があります。</span><span class="sxs-lookup"><span data-stu-id="07648-194">If your camera memory card stores pictures in an AVCHD or PRIVATE\\ACHD folder, you will need to update the code accordingly.</span></span>
    <span data-ttu-id="07648-195">**注:** カメラのメモリ カードがない場合は、ルートに **DCIM** という名前のフォルダーがあり、DCIM フォルダーに画像が含まれるサブフォルダーがあれば、フラッシュ ドライブを使うことができます。</span><span class="sxs-lookup"><span data-stu-id="07648-195">**Note**  If you don't have a camera memory card, you can use a flash drive if it has a folder named **DCIM** in the root and if the DCIM folder has a subfolder that contains images.</span></span>

## <a name="register-for-an-autoplay-device"></a><span data-ttu-id="07648-196">自動再生デバイスに登録する</span><span class="sxs-lookup"><span data-stu-id="07648-196">Register for an AutoPlay device</span></span>


<span data-ttu-id="07648-197">アプリを**自動再生**デバイス イベントのオプションとして登録できます。</span><span class="sxs-lookup"><span data-stu-id="07648-197">You can register apps as options for **AutoPlay** device events.</span></span> <span data-ttu-id="07648-198">**自動再生**デバイス イベントは、デバイスがコンピューターに接続されると発生します。</span><span class="sxs-lookup"><span data-stu-id="07648-198">**AutoPlay** device events are raised when a device is connected to a PC.</span></span>

<span data-ttu-id="07648-199">ここでは、PC にカメラが接続されたときに**自動再生**オプションとしてアプリを識別する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="07648-199">Here we show how to identify your app as an **AutoPlay** option when a camera is connected to a PC.</span></span> <span data-ttu-id="07648-200">アプリは、**WPD\\ImageSourceAutoPlay** イベントのハンドラーとして登録されます。</span><span class="sxs-lookup"><span data-stu-id="07648-200">The app registers as a handler for the **WPD\\ImageSourceAutoPlay** event.</span></span> <span data-ttu-id="07648-201">これは、カメラなどのイメージング デバイスが MTP を使う ImageSource であることを通知するときに Windows ポータブル デバイス (WPD) システムによって生成される一般的なイベントです。</span><span class="sxs-lookup"><span data-stu-id="07648-201">This is a common event that the Windows Portable Device (WPD) system raises when cameras and other imaging devices notify it that they are an ImageSource using MTP.</span></span> <span data-ttu-id="07648-202">詳しくは、「[Windows ポータブル デバイス](https://msdn.microsoft.com/library/windows/hardware/ff597729)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="07648-202">For more info, see [Windows Portable Devices](https://msdn.microsoft.com/library/windows/hardware/ff597729).</span></span>

<span data-ttu-id="07648-203">**重要:** [**Windows.Devices.Portable.StorageDevice**](https://msdn.microsoft.com/library/windows/apps/br225654) API は[デスクトップ デバイス ファミリ](https://msdn.microsoft.com/library/windows/apps/dn894631)の一部です。</span><span class="sxs-lookup"><span data-stu-id="07648-203">**Important**  The [**Windows.Devices.Portable.StorageDevice**](https://msdn.microsoft.com/library/windows/apps/br225654) APIs are part of the [desktop device family](https://msdn.microsoft.com/library/windows/apps/dn894631).</span></span> <span data-ttu-id="07648-204">アプリでは、デスクトップ デバイス ファミリの Windows 10 デバイス (PC など) でのみこれらの API を使えます。</span><span class="sxs-lookup"><span data-stu-id="07648-204">Apps can use these APIs only on Windows 10 devices in the desktop device family, such as PCs.</span></span>

 

### <a name="step-1-create-a-new-project-and-add-autoplay-declarations"></a><span data-ttu-id="07648-205">手順 1: 新しいプロジェクトを作成し、自動再生宣言を追加する</span><span class="sxs-lookup"><span data-stu-id="07648-205">Step 1: Create a new project and add AutoPlay declarations</span></span>

1.  <span data-ttu-id="07648-206">Visual Studio を開き、**[ファイル]** メニューの **[新しいプロジェクト]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="07648-206">Open Visual Studio and select **New Project** from the **File** menu.</span></span> <span data-ttu-id="07648-207">**Visual C#** セクションの **[Windows]** で **[空白のアプリ (ユニバーサル Windows)]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="07648-207">In the **Visual C#** section, under **Windows**, select **Blank App (Universal Windows)**.</span></span> <span data-ttu-id="07648-208">アプリに **AutoPlayDevice\_Camera** という名前を付け、**[OK]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="07648-208">Name the app **AutoPlayDevice\_Camera** and click **OK.**</span></span>
2.  <span data-ttu-id="07648-209">Package.appxmanifest ファイルを開き、**[機能]** タブをクリックします。</span><span class="sxs-lookup"><span data-stu-id="07648-209">Open the Package.appxmanifest file and select the **Capabilities** tab.</span></span> <span data-ttu-id="07648-210">**[リムーバブル記憶域]** 機能をクリックします。</span><span class="sxs-lookup"><span data-stu-id="07648-210">Select the **Removable Storage** capability.</span></span> <span data-ttu-id="07648-211">これで、アプリはリムーバブル記憶域ボリューム デバイスとしてカメラ上のデータにアクセスできるようになります。</span><span class="sxs-lookup"><span data-stu-id="07648-211">This gives the app access to the data on the camera as a removable storage volume device.</span></span>
3.  <span data-ttu-id="07648-212">マニフェスト ファイルで、**[宣言]** タブをクリックします。</span><span class="sxs-lookup"><span data-stu-id="07648-212">In the manifest file, select the **Declarations** tab.</span></span> <span data-ttu-id="07648-213">**[使用可能な宣言]** ドロップダウン リストで、**[自動再生デバイス]** を選び、**[追加]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="07648-213">In the **Available Declarations** drop-down list, select **AutoPlay Device** and click **Add**.</span></span> <span data-ttu-id="07648-214">**[サポートされる宣言]** ボックスの一覧に追加された新しい **[自動再生デバイス]** 項目を選びます。</span><span class="sxs-lookup"><span data-stu-id="07648-214">Select the new **AutoPlay Device** item that was added to the **Supported Declarations** list.</span></span>
4.  <span data-ttu-id="07648-215">**[自動再生デバイス]** 宣言では、自動再生で既知のイベントのデバイス イベントが発生したときに該当のアプリがオプションとして識別されます。</span><span class="sxs-lookup"><span data-stu-id="07648-215">An **AutoPlay Device** declaration identifies your app as an option when AutoPlay raises a device event for known events.</span></span> <span data-ttu-id="07648-216">**[起動アクション]** セクションで、最初の起動アクションに対して下記の表の値を入力します。</span><span class="sxs-lookup"><span data-stu-id="07648-216">In the **Launch Actions** section, enter the values in the table below for the first launch action.</span></span>
5.  <span data-ttu-id="07648-217">**[使用可能な宣言]** ドロップダウン リストで、**[ファイルの種類の関連付け]** を選び、**[追加]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="07648-217">In the **Available Declarations** drop-down list, select **File Type Associations** and click **Add**.</span></span> <span data-ttu-id="07648-218">新しい **[ファイルの種類の関連付け]** 宣言の [プロパティ] で、**[表示名]** フィールドを **"カメラの画像を表示する"**、**[名前]** フィールドを **camera\_association1** に設定します。</span><span class="sxs-lookup"><span data-stu-id="07648-218">In the Properties of the new **File Type Associations** declaration, set the **Display Name** field to **Show Images from Camera** and the **Name** field to **camera\_association1**.</span></span> <span data-ttu-id="07648-219">**[サポートされるファイルの種類]** セクションで、**[新規追加]** をクリックします (必要な場合)。</span><span class="sxs-lookup"><span data-stu-id="07648-219">In the **Supported File Types** section, click **Add New** (if needed).</span></span> <span data-ttu-id="07648-220">**[ファイルの種類]** フィールドを **.jpg** に設定します。</span><span class="sxs-lookup"><span data-stu-id="07648-220">Set the **File Type** field to **.jpg**.</span></span> <span data-ttu-id="07648-221">**[サポートされるファイルの種類]** セクションで、**[新規追加]** をもう一度クリックします。</span><span class="sxs-lookup"><span data-stu-id="07648-221">In the **Supported File Types** section, click **Add New** again.</span></span> <span data-ttu-id="07648-222">新しいファイルの関連付けの **[ファイルの種類]** フィールドを **.png** に設定します。</span><span class="sxs-lookup"><span data-stu-id="07648-222">Set the **File Type** field of the new file association to **.png**.</span></span> <span data-ttu-id="07648-223">コンテンツ イベントの場合は、自動再生で、アプリに明示的に関連付けられていないファイルの種類はすべて除外されます。</span><span class="sxs-lookup"><span data-stu-id="07648-223">For content events, AutoPlay filters out any file types that are not explicitly associated with your app.</span></span>
6.  <span data-ttu-id="07648-224">マニフェスト ファイルを保存して閉じます。</span><span class="sxs-lookup"><span data-stu-id="07648-224">Save and close the manifest file.</span></span>

| <span data-ttu-id="07648-225">設定</span><span class="sxs-lookup"><span data-stu-id="07648-225">Setting</span></span>             | <span data-ttu-id="07648-226">値</span><span class="sxs-lookup"><span data-stu-id="07648-226">Value</span></span>            |
|---------------------|------------------|
| <span data-ttu-id="07648-227">動詞</span><span class="sxs-lookup"><span data-stu-id="07648-227">Verb</span></span>                | <span data-ttu-id="07648-228">show</span><span class="sxs-lookup"><span data-stu-id="07648-228">show</span></span>             |
| <span data-ttu-id="07648-229">アクションの表示名</span><span class="sxs-lookup"><span data-stu-id="07648-229">Action Display Name</span></span> | <span data-ttu-id="07648-230">画像を表示する</span><span class="sxs-lookup"><span data-stu-id="07648-230">Show Pictures</span></span>    |
| <span data-ttu-id="07648-231">コンテンツ イベント</span><span class="sxs-lookup"><span data-stu-id="07648-231">Content Event</span></span>       | <span data-ttu-id="07648-232">WPD\\ImageSource</span><span class="sxs-lookup"><span data-stu-id="07648-232">WPD\\ImageSource</span></span> |

<span data-ttu-id="07648-233">**[アクションの表示名]** 設定では、アプリの自動再生で表示される文字列を指定します。</span><span class="sxs-lookup"><span data-stu-id="07648-233">The **Action Display Name** setting identifies the string that AutoPlay displays for your app.</span></span> <span data-ttu-id="07648-234">**[動詞]** 設定では、選んだオプションでアプリに渡される値を指定します。</span><span class="sxs-lookup"><span data-stu-id="07648-234">The **Verb** setting identifies a value that is passed to your app for the selected option.</span></span> <span data-ttu-id="07648-235">自動再生のイベントの起動アクションは複数指定できます。また、**[動詞]** 設定を使って、ユーザーがアプリで選んだアクションを確認できます。</span><span class="sxs-lookup"><span data-stu-id="07648-235">You can specify multiple launch actions for an AutoPlay event and use the **Verb** setting to determine which option a user has selected for your app.</span></span> <span data-ttu-id="07648-236">アプリに渡される起動イベント引数の **verb** プロパティを調べることでユーザーが選んだオプションを確認できます。</span><span class="sxs-lookup"><span data-stu-id="07648-236">You can tell which option the user selected by checking the **verb** property of the startup event arguments passed to your app.</span></span> <span data-ttu-id="07648-237">**[動詞]** 設定には任意の値を使うことができます。ただし、予約されている **open** を除きます。</span><span class="sxs-lookup"><span data-stu-id="07648-237">You can use any value for the **Verb** setting except, **open**, which is reserved.</span></span> <span data-ttu-id="07648-238">1 つのアプリで複数の動詞を使う例については、「[自動再生コンテンツに登録する](#register-for-autoplay-content)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="07648-238">For an example of using multiple verbs in a single app, see [Register for AutoPlay content](#register-for-autoplay-content).</span></span>

### <a name="step-2-add-assembly-reference-for-the-desktop-extensions"></a><span data-ttu-id="07648-239">手順 2: デスクトップ拡張機能に対するアセンブリ参照を追加する</span><span class="sxs-lookup"><span data-stu-id="07648-239">Step 2: Add assembly reference for the desktop extensions</span></span>

<span data-ttu-id="07648-240">Windows ポータブル デバイス上の記憶域にアクセスするために必要な API である [**Windows.Devices.Portable.StorageDevice**](https://msdn.microsoft.com/library/windows/apps/br225654) は、デスクトップ [デスクトップ デバイス ファミリ](https://msdn.microsoft.com/library/windows/apps/dn894631) の一部です。</span><span class="sxs-lookup"><span data-stu-id="07648-240">The APIs required to access storage on a Windows Portable Device, [**Windows.Devices.Portable.StorageDevice**](https://msdn.microsoft.com/library/windows/apps/br225654), are part of the desktop [desktop device family](https://msdn.microsoft.com/library/windows/apps/dn894631).</span></span> <span data-ttu-id="07648-241">つまり、この API を使うには特別なアセンブリが必要であり、その呼び出しはデスクトップ デバイス ファミリ (PC など) でのみ機能します。</span><span class="sxs-lookup"><span data-stu-id="07648-241">This means a special assembly is required to use the APIs and those calls will only work on a device in the desktop device family (such as a PC).</span></span>

1.  <span data-ttu-id="07648-242">**ソリューション エクスプローラー**で、**[参照設定]** を右クリックし、**[参照の追加]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="07648-242">In **Solution Explorer**, right click on **References** and then **Add Reference...**.</span></span>
2.  <span data-ttu-id="07648-243">**[ユニバーサル Windows]** を展開し、**[拡張機能]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="07648-243">Expand **Universal Windows** and click **Extensions**.</span></span>
3.  <span data-ttu-id="07648-244">**[Windows Desktop Extensions for the UWP]** を選び、**[OK]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="07648-244">Then select **Windows Desktop Extensions for the UWP** and click **OK**.</span></span>

### <a name="step-3-add-xaml-ui"></a><span data-ttu-id="07648-245">手順 3: XAML UI を追加する</span><span class="sxs-lookup"><span data-stu-id="07648-245">Step 3: Add XAML UI</span></span>

<span data-ttu-id="07648-246">MainPage.xaml ファイルを開き、次の XAML を既定の &lt;Grid&gt; セクションに追加します。</span><span class="sxs-lookup"><span data-stu-id="07648-246">Open the MainPage.xaml file and add the following XAML to the default &lt;Grid&gt; section.</span></span>

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

### <a name="step-4-add-activation-code"></a><span data-ttu-id="07648-247">手順 4: アクティブ化コードを追加する</span><span class="sxs-lookup"><span data-stu-id="07648-247">Step 4: Add activation code</span></span>

<span data-ttu-id="07648-248">この手順のコードは、カメラのデバイス情報 ID を [**FromId**](https://msdn.microsoft.com/library/windows/apps/br225655) メソッドに渡すことによって、カメラを [**StorageDevice**](https://msdn.microsoft.com/library/windows/apps/br225654) として参照します。</span><span class="sxs-lookup"><span data-stu-id="07648-248">The code in this step references the camera as a [**StorageDevice**](https://msdn.microsoft.com/library/windows/apps/br225654) by passing the device information Id of the camera to the [**FromId**](https://msdn.microsoft.com/library/windows/apps/br225655) method.</span></span> <span data-ttu-id="07648-249">カメラのデバイス情報 ID を取得するには、まずイベント引数を [**DeviceActivatedEventArgs**](https://msdn.microsoft.com/library/windows/apps/br224710) としてキャストし、次に [**DeviceInformationId**](https://msdn.microsoft.com/library/windows/apps/br224711) プロパティから値を取得します。</span><span class="sxs-lookup"><span data-stu-id="07648-249">The device information Id of the camera is obtained by first casting the event arguments as [**DeviceActivatedEventArgs**](https://msdn.microsoft.com/library/windows/apps/br224710), and then getting the value from the [**DeviceInformationId**](https://msdn.microsoft.com/library/windows/apps/br224711) property.</span></span>

<span data-ttu-id="07648-250">App.xaml.cs ファイルを開いて、次のコードを **App** クラスに追加します。</span><span class="sxs-lookup"><span data-stu-id="07648-250">Open the App.xaml.cs file and add the following code to the **App** class.</span></span>

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

> <span data-ttu-id="07648-251">**注:** `ShowImages` メソッドは、次の手順で追加されます。</span><span class="sxs-lookup"><span data-stu-id="07648-251">**Note**  The `ShowImages` method is added in the following step.</span></span>

### <a name="step-5-add-code-to-display-device-information"></a><span data-ttu-id="07648-252">手順 5: デバイス情報を表示するコードを追加する</span><span class="sxs-lookup"><span data-stu-id="07648-252">Step 5: Add code to display device information</span></span>

<span data-ttu-id="07648-253">カメラに関する情報は、[**StorageDevice**](https://msdn.microsoft.com/library/windows/apps/br225654) クラスのプロパティから取得できます。</span><span class="sxs-lookup"><span data-stu-id="07648-253">You can obtain information about the camera from the properties of the [**StorageDevice**](https://msdn.microsoft.com/library/windows/apps/br225654) class.</span></span> <span data-ttu-id="07648-254">この手順のコードは、アプリの実行時にデバイス名などの情報をユーザーに表示します。</span><span class="sxs-lookup"><span data-stu-id="07648-254">The code in this step displays the device name and other info to the user when the app runs.</span></span> <span data-ttu-id="07648-255">続いて、GetImageList メソッドと GetThumbnail メソッドを呼び出します。これらのメソッドは、カメラに格納されている画像のサムネイルを表示するために、次の手順で追加します。</span><span class="sxs-lookup"><span data-stu-id="07648-255">The code then calls the GetImageList and GetThumbnail methods, which you will add in the next step, to display thumbnails of the images stored on the camera</span></span>

<span data-ttu-id="07648-256">MainPage.xaml.cs ファイルで、次のコードを **MainPage** クラスに追加します。</span><span class="sxs-lookup"><span data-stu-id="07648-256">In the MainPage.xaml.cs file, add the following code to the **MainPage** class.</span></span>

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

> <span data-ttu-id="07648-257">**注:** `GetImageList` メソッドと `GetThumbnail` メソッドは、以下の手順で追加されます。</span><span class="sxs-lookup"><span data-stu-id="07648-257">**Note**  The `GetImageList` and `GetThumbnail` methods are added in the following step.</span></span>

 

### <a name="step-6-add-code-to-display-images"></a><span data-ttu-id="07648-258">手順 6: 画像を表示するコードを追加する</span><span class="sxs-lookup"><span data-stu-id="07648-258">Step 6: Add code to display images</span></span>

<span data-ttu-id="07648-259">この手順のコードは、カメラに格納されている画像のサムネイルを表示します。</span><span class="sxs-lookup"><span data-stu-id="07648-259">The code in this step displays thumbnails of the images stored on the camera.</span></span> <span data-ttu-id="07648-260">このコードは、カメラの非同期呼び出しを行ってサムネイル イメージを取得します。</span><span class="sxs-lookup"><span data-stu-id="07648-260">The code makes asynchronous calls to the camera to get the thumbnail image.</span></span> <span data-ttu-id="07648-261">ただし、次の非同期呼び出しは、前の非同期呼び出しが完了するまで行われません。</span><span class="sxs-lookup"><span data-stu-id="07648-261">However, the next asynchronous call doesn't occur until the previous asynchronous call completes.</span></span> <span data-ttu-id="07648-262">これにより、カメラに対する要求が一度に 1 つだけ実行されるようになります。</span><span class="sxs-lookup"><span data-stu-id="07648-262">This ensures that only one request is made to the camera at a time.</span></span>

<span data-ttu-id="07648-263">MainPage.xaml.cs ファイルで、次のコードを **MainPage** クラスに追加します。</span><span class="sxs-lookup"><span data-stu-id="07648-263">In the MainPage.xaml.cs file, add the following code to the **MainPage** class.</span></span>

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

### <a name="step-7-build-and-run-the-app"></a><span data-ttu-id="07648-264">手順 7: アプリをビルドして実行する</span><span class="sxs-lookup"><span data-stu-id="07648-264">Step 7: Build and run the app</span></span>

1.  <span data-ttu-id="07648-265">F5 キーを押して、アプリを (デバッグ モードで) ビルドおよび展開します。</span><span class="sxs-lookup"><span data-stu-id="07648-265">Press F5 to build and deploy the app (in debug mode).</span></span>
2.  <span data-ttu-id="07648-266">アプリを実行するには、コンピューターにカメラを接続します。</span><span class="sxs-lookup"><span data-stu-id="07648-266">To run your app, connect a camera to your machine.</span></span> <span data-ttu-id="07648-267">次に、自動再生オプションの一覧からアプリを選びます。</span><span class="sxs-lookup"><span data-stu-id="07648-267">Then select the app from the AutoPlay list of options.</span></span>
    <span data-ttu-id="07648-268">**注:** すべてのカメラが **WPD\\ImageSource** 自動再生デバイス イベントのためのアドバタイズを行うわけではありません。</span><span class="sxs-lookup"><span data-stu-id="07648-268">**Note**  Not all cameras advertise for the **WPD\\ImageSource** AutoPlay device event.</span></span>

     

## <a name="configure-removable-storage"></a><span data-ttu-id="07648-269">リムーバブル記憶域を構成する</span><span class="sxs-lookup"><span data-stu-id="07648-269">Configure removable storage</span></span>


<span data-ttu-id="07648-270">メモリ カードやサム ドライブなどのボリューム デバイスが PC に接続されたとき、そのボリューム デバイスを**自動再生**デバイスとして識別することができます。</span><span class="sxs-lookup"><span data-stu-id="07648-270">You can identify a volume device such as a memory card or thumb drive as an **AutoPlay** device when the volume device is connected to a PC.</span></span> <span data-ttu-id="07648-271">これは、特定のアプリを**自動再生**に関連付けて、ボリューム デバイスのユーザーに提示する場合などに活用できます。</span><span class="sxs-lookup"><span data-stu-id="07648-271">This is especially useful when you want to associate a specific app for **AutoPlay** to present to the user for your volume device.</span></span>

<span data-ttu-id="07648-272">ここでは、**自動再生**デバイスとしてボリューム デバイスを識別する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="07648-272">Here we show how to identify your volume device as an **AutoPlay** device.</span></span>

<span data-ttu-id="07648-273">ボリューム デバイスを**自動再生**デバイスとして識別するには、デバイスのルート ドライブに autorun.inf ファイルを追加します。</span><span class="sxs-lookup"><span data-stu-id="07648-273">To identify your volume device as an **AutoPlay** device, add an autorun.inf file to the root drive of your device.</span></span> <span data-ttu-id="07648-274">そして、autorun.inf ファイルの **AutoRun** セクションに **CustomEvent** キーを追加します。</span><span class="sxs-lookup"><span data-stu-id="07648-274">In the autorun.inf file, add a **CustomEvent** key to the **AutoRun** section.</span></span> <span data-ttu-id="07648-275">PC にボリューム デバイスが接続されると、**自動再生**が autorun.inf ファイルを検索し、ボリュームをデバイスとして扱います。</span><span class="sxs-lookup"><span data-stu-id="07648-275">When your volume device connects to a PC, **AutoPlay** will find the autorun.inf file and treat your volume as a device.</span></span> <span data-ttu-id="07648-276">**自動再生**は、**CustomEvent** キーに指定された名前を使って**自動再生**イベントを作成します。</span><span class="sxs-lookup"><span data-stu-id="07648-276">**AutoPlay** will create an **AutoPlay** event by using the name that you supplied for the **CustomEvent** key.</span></span> <span data-ttu-id="07648-277">それからアプリを作成し、その**自動再生**イベントのハンドラーとしてアプリを登録できます。</span><span class="sxs-lookup"><span data-stu-id="07648-277">You can then create an app and register the app as a handler for that **AutoPlay** event.</span></span> <span data-ttu-id="07648-278">PC にデバイスが接続されると、**自動再生**が、ボリューム デバイスのハンドラーとしてアプリを表示します。</span><span class="sxs-lookup"><span data-stu-id="07648-278">When the device is connected to the PC, **AutoPlay** will show your app as a handler for your volume device.</span></span> <span data-ttu-id="07648-279">autorun.inf ファイルについて詳しくは、「[Autorun.inf エントリ](https://msdn.microsoft.com/library/windows/desktop/cc144200)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="07648-279">For more info on autorun.inf files, see [autorun.inf entries](https://msdn.microsoft.com/library/windows/desktop/cc144200).</span></span>

### <a name="step-1-create-an-autoruninf-file"></a><span data-ttu-id="07648-280">手順 1: autorun.inf ファイルを作成する</span><span class="sxs-lookup"><span data-stu-id="07648-280">Step 1: Create an autorun.inf file</span></span>

<span data-ttu-id="07648-281">ボリューム デバイスのルート ドライブに autorun.inf という名前のファイルを追加します。</span><span class="sxs-lookup"><span data-stu-id="07648-281">In the root drive of your volume device, add a file named autorun.inf.</span></span> <span data-ttu-id="07648-282">autorun.inf ファイルを開き、次のテキストを追加します。</span><span class="sxs-lookup"><span data-stu-id="07648-282">Open the autorun.inf file and add the following text.</span></span>

``` syntax
[AutoRun]
CustomEvent=AutoPlayCustomEventQuickstart
```

### <a name="step-2-create-a-new-project-and-add-autoplay-declarations"></a><span data-ttu-id="07648-283">手順 2: 新しいプロジェクトを作成し、自動再生宣言を追加する</span><span class="sxs-lookup"><span data-stu-id="07648-283">Step 2: Create a new project and add AutoPlay declarations</span></span>

1.  <span data-ttu-id="07648-284">Visual Studio を開き、**[ファイル]** メニューの **[新しいプロジェクト]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="07648-284">Open Visual Studio and select **New Project** from the **File** menu.</span></span> <span data-ttu-id="07648-285">**Visual C#** セクションの **[Windows]** で **[空白のアプリ (ユニバーサル Windows)]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="07648-285">In the **Visual C#** section, under **Windows**, select **Blank App (Universal Windows)**.</span></span> <span data-ttu-id="07648-286">アプリに **AutoPlayCustomEvent** という名前を付け、**[OK]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="07648-286">Name the application **AutoPlayCustomEvent** and click **OK.**</span></span>
2.  <span data-ttu-id="07648-287">Package.appxmanifest ファイルを開き、**[機能]** タブをクリックします。</span><span class="sxs-lookup"><span data-stu-id="07648-287">Open the Package.appxmanifest file and select the **Capabilities** tab.</span></span> <span data-ttu-id="07648-288">**[リムーバブル記憶域]** 機能をクリックします。</span><span class="sxs-lookup"><span data-stu-id="07648-288">Select the **Removable Storage** capability.</span></span> <span data-ttu-id="07648-289">これで、アプリはリムーバブル記憶域デバイス上のファイルとフォルダーにアクセスできるようになります。</span><span class="sxs-lookup"><span data-stu-id="07648-289">This gives the app access to the files and folders on removable storage devices.</span></span>
3.  <span data-ttu-id="07648-290">マニフェスト ファイルで、**[宣言]** タブをクリックします。</span><span class="sxs-lookup"><span data-stu-id="07648-290">In the manifest file, select the **Declarations** tab.</span></span> <span data-ttu-id="07648-291">**[使用可能な宣言]** ドロップダウン リストで、**[自動再生コンテンツ]** を選び、**[追加]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="07648-291">In the **Available Declarations** drop-down list, select **AutoPlay Content** and click **Add**.</span></span> <span data-ttu-id="07648-292">**[サポートされる宣言]** ボックスの一覧に追加された新しい **[自動再生コンテンツ]** 項目を選びます。</span><span class="sxs-lookup"><span data-stu-id="07648-292">Select the new **AutoPlay Content** item that was added to the **Supported Declarations** list.</span></span>

    <span data-ttu-id="07648-293">**注:** また、カスタム自動再生イベントに対して **[自動再生デバイス]** の宣言を追加することもできます。</span><span class="sxs-lookup"><span data-stu-id="07648-293">**Note**  Alternatively, you can also choose to add an **AutoPlay Device** declaration for your custom AutoPlay event.</span></span>
    
4.  <span data-ttu-id="07648-294">**[自動再生コンテンツ]** イベント宣言の **[起動アクション]** セクションで、最初の起動アクションについて下記の表の値を入力します。</span><span class="sxs-lookup"><span data-stu-id="07648-294">In the **Launch Actions** section for your **AutoPlay Content** event declaration, enter the values in the table below for the first launch action.</span></span>
5.  <span data-ttu-id="07648-295">**[使用可能な宣言]** ドロップダウン リストで、**[ファイルの種類の関連付け]** を選び、**[追加]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="07648-295">In the **Available Declarations** drop-down list, select **File Type Associations** and click **Add**.</span></span> <span data-ttu-id="07648-296">新しい **[ファイルの種類の関連付け]** 宣言の [プロパティ] で、**[表示名]** フィールドを **".ms ファイルを表示する"**、**[名前]** フィールドを **ms\_association** に設定します。</span><span class="sxs-lookup"><span data-stu-id="07648-296">In the Properties of the new **File Type Associations** declaration, set the **Display Name** field to **Show .ms Files** and the **Name** field to **ms\_association**.</span></span> <span data-ttu-id="07648-297">**[サポートされるファイルの種類]** セクションで、**[新規追加]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="07648-297">In the **Supported File Types** section, click **Add New**.</span></span> <span data-ttu-id="07648-298">**[ファイルの種類]** フィールドを **.ms** に設定します。</span><span class="sxs-lookup"><span data-stu-id="07648-298">Set the **File Type** field to **.ms**.</span></span> <span data-ttu-id="07648-299">コンテンツ イベントの場合は、自動再生で、アプリに明示的に関連付けられていないファイルの種類はすべて除外されます。</span><span class="sxs-lookup"><span data-stu-id="07648-299">For content events, AutoPlay filters out any file types that aren't explicitly associated with your app.</span></span>
6.  <span data-ttu-id="07648-300">マニフェスト ファイルを保存して閉じます。</span><span class="sxs-lookup"><span data-stu-id="07648-300">Save and close the manifest file.</span></span>

| <span data-ttu-id="07648-301">設定</span><span class="sxs-lookup"><span data-stu-id="07648-301">Setting</span></span>             | <span data-ttu-id="07648-302">値</span><span class="sxs-lookup"><span data-stu-id="07648-302">Value</span></span>                         |
|---------------------|-------------------------------|
| <span data-ttu-id="07648-303">動詞</span><span class="sxs-lookup"><span data-stu-id="07648-303">Verb</span></span>                | <span data-ttu-id="07648-304">show</span><span class="sxs-lookup"><span data-stu-id="07648-304">show</span></span>                          |
| <span data-ttu-id="07648-305">アクションの表示名</span><span class="sxs-lookup"><span data-stu-id="07648-305">Action Display Name</span></span> | <span data-ttu-id="07648-306">ファイルを表示する</span><span class="sxs-lookup"><span data-stu-id="07648-306">Show Files</span></span>                    |
| <span data-ttu-id="07648-307">コンテンツ イベント</span><span class="sxs-lookup"><span data-stu-id="07648-307">Content Event</span></span>       | <span data-ttu-id="07648-308">AutoPlayCustomEventQuickstart</span><span class="sxs-lookup"><span data-stu-id="07648-308">AutoPlayCustomEventQuickstart</span></span> |

<span data-ttu-id="07648-309">**[コンテンツ イベント]** の値は、autorun.inf ファイルの **CustomEvent** キーに指定したテキストです。</span><span class="sxs-lookup"><span data-stu-id="07648-309">The **Content Event** value is the text that you supplied for the **CustomEvent** key in your autorun.inf file.</span></span> <span data-ttu-id="07648-310">**[アクションの表示名]** 設定では、アプリの自動再生で表示される文字列を指定します。</span><span class="sxs-lookup"><span data-stu-id="07648-310">The **Action Display Name** setting identifies the string that AutoPlay displays for your app.</span></span> <span data-ttu-id="07648-311">**[動詞]** 設定では、選んだオプションでアプリに渡される値を指定します。</span><span class="sxs-lookup"><span data-stu-id="07648-311">The **Verb** setting identifies a value that is passed to your app for the selected option.</span></span> <span data-ttu-id="07648-312">自動再生のイベントの起動アクションは複数指定できます。また、**[動詞]** 設定を使って、ユーザーがアプリで選んだアクションを確認できます。</span><span class="sxs-lookup"><span data-stu-id="07648-312">You can specify multiple launch actions for an AutoPlay event and use the **Verb** setting to determine which option a user has selected for your app.</span></span> <span data-ttu-id="07648-313">アプリに渡される起動イベント引数の **verb** プロパティを調べることでユーザーが選んだオプションを確認できます。</span><span class="sxs-lookup"><span data-stu-id="07648-313">You can tell which option the user selected by checking the **verb** property of the startup event arguments passed to your app.</span></span> <span data-ttu-id="07648-314">**[動詞]** 設定には任意の値を使うことができます。ただし、予約されている **open** を除きます。</span><span class="sxs-lookup"><span data-stu-id="07648-314">You can use any value for the **Verb** setting except, **open**, which is reserved.</span></span>

### <a name="step-3-add-xaml-ui"></a><span data-ttu-id="07648-315">手順 3: XAML UI を追加する</span><span class="sxs-lookup"><span data-stu-id="07648-315">Step 3: Add XAML UI</span></span>

<span data-ttu-id="07648-316">MainPage.xaml ファイルを開き、次の XAML を既定の &lt;Grid&gt; セクションに追加します。</span><span class="sxs-lookup"><span data-stu-id="07648-316">Open the MainPage.xaml file and add the following XAML to the default &lt;Grid&gt; section.</span></span>

```xml
<StackPanel Orientation="Vertical">
    <TextBlock FontSize="28" Margin="10,0,800,0">Files</TextBlock>
    <TextBlock x:Name="FilesBlock" FontSize="22" Height="600" Margin="10,0,800,0" />
</StackPanel>
```

### <a name="step-4-add-activation-code"></a><span data-ttu-id="07648-317">手順 4: アクティブ化コードを追加する</span><span class="sxs-lookup"><span data-stu-id="07648-317">Step 4: Add activation code</span></span>

<span data-ttu-id="07648-318">この手順のコードは、ボリューム デバイスのルート ドライブにあるフォルダーを表示するメソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="07648-318">The code in this step calls a method to display the folders in the root drive of your volume device.</span></span> <span data-ttu-id="07648-319">自動再生コンテンツ イベントの場合、自動再生により、**OnFileActivated** イベント中にアプリに渡された起動引数でストレージ デバイスのルート フォルダーが渡されます。</span><span class="sxs-lookup"><span data-stu-id="07648-319">For the AutoPlay content events, AutoPlay passes the root folder of the storage device in the startup arguments passed to the application during the **OnFileActivated** event.</span></span> <span data-ttu-id="07648-320">このフォルダーは **Files** プロパティの最初の要素から取得できます。</span><span class="sxs-lookup"><span data-stu-id="07648-320">You can retrieve this folder from the first element of the **Files** property.</span></span>

<span data-ttu-id="07648-321">App.xaml.cs ファイルを開いて、次のコードを **App** クラスに追加します。</span><span class="sxs-lookup"><span data-stu-id="07648-321">Open the App.xaml.cs file and add the following code to the **App** class.</span></span>

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

> <span data-ttu-id="07648-322">**注:**  `DisplayFiles` メソッドは、次の手順で追加されます。</span><span class="sxs-lookup"><span data-stu-id="07648-322">**Note**  The `DisplayFiles` method is added in the following step.</span></span>

 

### <a name="step-5-add-code-to-display-folders"></a><span data-ttu-id="07648-323">手順 5: フォルダーを表示するコードを追加する</span><span class="sxs-lookup"><span data-stu-id="07648-323">Step 5: Add code to display folders</span></span>

<span data-ttu-id="07648-324">MainPage.xaml.cs ファイルで、次のコードを **MainPage** クラスに追加します。</span><span class="sxs-lookup"><span data-stu-id="07648-324">In the MainPage.xaml.cs file add the following code to the **MainPage** class.</span></span>

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

### <a name="step-6-build-and-run-the-qpp"></a><span data-ttu-id="07648-325">手順 6: アプリをビルドして実行する</span><span class="sxs-lookup"><span data-stu-id="07648-325">Step 6: Build and run the qpp</span></span>

1.  <span data-ttu-id="07648-326">F5 キーを押して、アプリを (デバッグ モードで) ビルドおよび展開します。</span><span class="sxs-lookup"><span data-stu-id="07648-326">Press F5 to build and deploy the app (in debug mode).</span></span>
2.  <span data-ttu-id="07648-327">アプリを実行するには、メモリ カードまたは他のストレージ デバイスを PC に挿入します。</span><span class="sxs-lookup"><span data-stu-id="07648-327">To run your app, insert a memory card or another storage device into your PC.</span></span> <span data-ttu-id="07648-328">そして、自動再生ハンドラー オプションの一覧からアプリを選びます。</span><span class="sxs-lookup"><span data-stu-id="07648-328">Then select your app from the list of AutoPlay handler options.</span></span>

## <a name="autoplay-event-reference"></a><span data-ttu-id="07648-329">自動再生イベント リファレンス</span><span class="sxs-lookup"><span data-stu-id="07648-329">AutoPlay event reference</span></span>


<span data-ttu-id="07648-330">**自動再生**システムを使うと、さまざまなデバイスやボリューム (ディスク) の到着イベントにアプリを登録できます。</span><span class="sxs-lookup"><span data-stu-id="07648-330">The **AutoPlay** system allows apps to register for a variety of device and volume (disk) arrival events.</span></span> <span data-ttu-id="07648-331">**自動再生**コンテンツ イベントに登録するには、パッケージ マニフェストで **[リムーバブル記憶域]** 機能を有効にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="07648-331">To register for **AutoPlay** content events, you must enable the **Removable Storage** capability in your package manifest.</span></span> <span data-ttu-id="07648-332">次の表で、登録できるイベントと、それらのイベントが発生するタイミングについて説明します。</span><span class="sxs-lookup"><span data-stu-id="07648-332">This table shows the events that you can register for and when they are raised.</span></span>

| <span data-ttu-id="07648-333">シナリオ</span><span class="sxs-lookup"><span data-stu-id="07648-333">Scenario</span></span>                                                           | <span data-ttu-id="07648-334">イベント</span><span class="sxs-lookup"><span data-stu-id="07648-334">Event</span></span>                              | <span data-ttu-id="07648-335">説明</span><span class="sxs-lookup"><span data-stu-id="07648-335">Description</span></span>   |
|--------------------------------------------------------------------|------------------------------------|---------------|
| <span data-ttu-id="07648-336">カメラで写真を使う</span><span class="sxs-lookup"><span data-stu-id="07648-336">Using photos on a Camera</span></span>                                           | **<span data-ttu-id="07648-337">WPD\ImageSource</span><span class="sxs-lookup"><span data-stu-id="07648-337">WPD\ImageSource</span></span>**                | <span data-ttu-id="07648-338">Windows ポータブル デバイスとして指定されているカメラに対して発生し、ImageSource 機能を提供します。</span><span class="sxs-lookup"><span data-stu-id="07648-338">Raised for cameras that are identified as Windows Portable Devices and offer the ImageSource capability.</span></span> |
| <span data-ttu-id="07648-339">オーディオ プレーヤーで音楽を使う</span><span class="sxs-lookup"><span data-stu-id="07648-339">Using music on an audio player</span></span>                                     | **<span data-ttu-id="07648-340">WPD\AudioSource</span><span class="sxs-lookup"><span data-stu-id="07648-340">WPD\AudioSource</span></span>**                | <span data-ttu-id="07648-341">Windows ポータブル デバイスとして指定されているメディア プレーヤーに対して発生し、AudioSource 機能を提供します。</span><span class="sxs-lookup"><span data-stu-id="07648-341">Raised for media players that are identified as Windows Portable Devices and offer the AudioSource capability.</span></span> |
| <span data-ttu-id="07648-342">ビデオ カメラでビデオを使う</span><span class="sxs-lookup"><span data-stu-id="07648-342">Using videos on a video camera</span></span>                                     | **<span data-ttu-id="07648-343">WPD\VideoSource</span><span class="sxs-lookup"><span data-stu-id="07648-343">WPD\VideoSource</span></span>**                | <span data-ttu-id="07648-344">Windows ポータブル デバイスとして指定されているビデオ カメラに対して発生し、VideoSource 機能を提供します。</span><span class="sxs-lookup"><span data-stu-id="07648-344">Raised for video cameras that are identified as Windows Portable Devices and offer the VideoSource capability.</span></span> |
| <span data-ttu-id="07648-345">接続されているフラッシュ ドライブまたは外部ハード ドライブにアクセスする</span><span class="sxs-lookup"><span data-stu-id="07648-345">Access a connected flash drive or external hard drive</span></span>              | **<span data-ttu-id="07648-346">StorageOnArrival</span><span class="sxs-lookup"><span data-stu-id="07648-346">StorageOnArrival</span></span>**               | <span data-ttu-id="07648-347">ドライブまたはボリュームが PC 接続されると発生します。</span><span class="sxs-lookup"><span data-stu-id="07648-347">Raised when a drive or volume is connected to the PC.</span></span>   <span data-ttu-id="07648-348">ドライブまたはボリュームのディスクのルートに DCIM、AVCHD、または PRIVATE\ACHD フォルダーが含まれている場合、代わりに **ShowPicturesOnArrival** イベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="07648-348">If the drive or volume contains a DCIM, AVCHD, or PRIVATE\ACHD folder in the root of the disk, the **ShowPicturesOnArrival** event is raised instead.</span></span> |
| <span data-ttu-id="07648-349">大容量記憶装置 (レガシ) の写真を使う</span><span class="sxs-lookup"><span data-stu-id="07648-349">Using photos from mass storage (legacy)</span></span>                            | **<span data-ttu-id="07648-350">ShowPicturesOnArrival</span><span class="sxs-lookup"><span data-stu-id="07648-350">ShowPicturesOnArrival</span></span>**          | <span data-ttu-id="07648-351">ドライブまたはボリュームのディスクのルートに DCIM、AVCHD、または PRIVATE\ACHD フォルダーが含まれている場合に発生します。</span><span class="sxs-lookup"><span data-stu-id="07648-351">Raised when a drive or volume contains a DCIM, AVCHD, or PRIVATE\ACHD folder in the root of the disk.</span></span> <span data-ttu-id="07648-352">自動再生コントロール パネルで **[各メディア タイプの処理方法を選択する]** を有効にしている場合は、自動再生によって PC に接続されているボリュームが調べられ、ディスク上のコンテンツの種類が確認されます。</span><span class="sxs-lookup"><span data-stu-id="07648-352">IIf a user  has enabled **Choose what to do with each type of media** in the AutoPlay Control Panel, AutoPlay will examine a volume connected to the PC to determine the type of content on the disk.</span></span> <span data-ttu-id="07648-353">画像が見つかると、**ShowPicturesOnArrival** が発生します。</span><span class="sxs-lookup"><span data-stu-id="07648-353">When pictures are found, **ShowPicturesOnArrival** is raised.</span></span> |
| <span data-ttu-id="07648-354">近接共有 (タップして送信) で写真を受信する</span><span class="sxs-lookup"><span data-stu-id="07648-354">Receiving photos with Proximity Sharing (tap and send)</span></span>             | **<span data-ttu-id="07648-355">ShowPicturesOnArrival</span><span class="sxs-lookup"><span data-stu-id="07648-355">ShowPicturesOnArrival</span></span>**          | <span data-ttu-id="07648-356">コンテンツを近接通信を使って送信 (タップして送信) すると、自動再生によって共有ファイルが調べられ、コンテンツの種類が確認されます。</span><span class="sxs-lookup"><span data-stu-id="07648-356">When users send content with using proximity (tap and send), AutoPlay will examine the shared files to determine the type of content.</span></span> <span data-ttu-id="07648-357">画像が見つかった場合、**ShowPicturesOnArrival** が発生します。</span><span class="sxs-lookup"><span data-stu-id="07648-357">If pictures are found, **ShowPicturesOnArrival** is raised.</span></span> |
| <span data-ttu-id="07648-358">大容量記憶装置 (レガシ) の音楽を使う</span><span class="sxs-lookup"><span data-stu-id="07648-358">Using music from mass storage (legacy)</span></span>                             | **<span data-ttu-id="07648-359">PlayMusicFilesOnArrival</span><span class="sxs-lookup"><span data-stu-id="07648-359">PlayMusicFilesOnArrival</span></span>**        | <span data-ttu-id="07648-360">自動再生コントロール パネルで **[各メディア タイプの処理方法を選択する]** を有効にしている場合は、自動再生によって PC に接続されているボリュームが調べられ、ディスク上のコンテンツの種類が確認されます。</span><span class="sxs-lookup"><span data-stu-id="07648-360">If a user has enabled **Choose what to do with each type of media** in the AutoPlay Control Panel, AutoPlay will examine a volume connected to the PC to determine the type of content on the disk.</span></span>  <span data-ttu-id="07648-361">音楽ファイルが見つかると、**PlayMusicFilesOnArrival** が発生します。</span><span class="sxs-lookup"><span data-stu-id="07648-361">When music files are found, **PlayMusicFilesOnArrival** is raised.</span></span> |
| <span data-ttu-id="07648-362">近接共有 (タップして送信) で音楽を受信する</span><span class="sxs-lookup"><span data-stu-id="07648-362">Receiving music with Proximity Sharing (tap and send)</span></span>              | **<span data-ttu-id="07648-363">PlayMusicFilesOnArrival</span><span class="sxs-lookup"><span data-stu-id="07648-363">PlayMusicFilesOnArrival</span></span>**        | <span data-ttu-id="07648-364">コンテンツを近接通信を使って送信 (タップして送信) すると、自動再生によって共有ファイルが調べられ、コンテンツの種類が確認されます。</span><span class="sxs-lookup"><span data-stu-id="07648-364">When users send content with using proximity (tap and send), AutoPlay will examine the shared files to determine the type of content.</span></span> <span data-ttu-id="07648-365">音楽ファイルが見つかった場合、**PlayMusicFilesOnArrival** が発生します。</span><span class="sxs-lookup"><span data-stu-id="07648-365">If music files are found, **PlayMusicFilesOnArrival** is raised.</span></span> |
| <span data-ttu-id="07648-366">大容量記憶装置 (レガシ) のビデオを使う</span><span class="sxs-lookup"><span data-stu-id="07648-366">Using videos from mass storage (legacy)</span></span>                            | **<span data-ttu-id="07648-367">PlayVideoFilesOnArrival</span><span class="sxs-lookup"><span data-stu-id="07648-367">PlayVideoFilesOnArrival</span></span>**        | <span data-ttu-id="07648-368">自動再生コントロール パネルで **[各メディア タイプの処理方法を選択する]** を有効にしている場合は、自動再生によって PC に接続されているボリュームが調べられ、ディスク上のコンテンツの種類が確認されます。</span><span class="sxs-lookup"><span data-stu-id="07648-368">If a user has enabled **Choose what to do with each type of media** in the AutoPlay Control Panel, AutoPlay will examine a volume connected to the PC to determine the type of content on the disk.</span></span> <span data-ttu-id="07648-369">ビデオ ファイルが見つかると、**PlayVideoFilesOnArrival** が発生します。</span><span class="sxs-lookup"><span data-stu-id="07648-369">When video files are found, **PlayVideoFilesOnArrival** is raised.</span></span> |
| <span data-ttu-id="07648-370">近接共有 (タップして送信) でビデオを受信する</span><span class="sxs-lookup"><span data-stu-id="07648-370">Receiving videos with Proximity Sharing (tap and send)</span></span>             | **<span data-ttu-id="07648-371">PlayVideoFilesOnArrival</span><span class="sxs-lookup"><span data-stu-id="07648-371">PlayVideoFilesOnArrival</span></span>**        | <span data-ttu-id="07648-372">コンテンツを近接通信を使って送信 (タップして送信) すると、自動再生によって共有ファイルが調べられ、コンテンツの種類が確認されます。</span><span class="sxs-lookup"><span data-stu-id="07648-372">When users send content with using proximity (tap and send), AutoPlay will examine the shared files to determine the type of content.</span></span> <span data-ttu-id="07648-373">ビデオ ファイルが見つかった場合、**PlayVideoFilesOnArrival** が発生します。</span><span class="sxs-lookup"><span data-stu-id="07648-373">If video files are found, **PlayVideoFilesOnArrival** is raised.</span></span> |
| <span data-ttu-id="07648-374">接続先デバイスの混在したファイルのセットを処理する</span><span class="sxs-lookup"><span data-stu-id="07648-374">Handling mixed sets of files from a connected device</span></span>               | **<span data-ttu-id="07648-375">MixedContentOnArrival</span><span class="sxs-lookup"><span data-stu-id="07648-375">MixedContentOnArrival</span></span>**          | <span data-ttu-id="07648-376">自動再生コントロール パネルで **[各メディア タイプの処理方法を選択する]** を有効にしている場合は、自動再生によって PC に接続されているボリュームが調べられ、ディスク上のコンテンツの種類が確認されます。</span><span class="sxs-lookup"><span data-stu-id="07648-376">If a user has enabled **Choose what to do with each type of media** in the AutoPlay Control Panel, AutoPlay will examine a volume connected to the PC to determine the type of content on the disk.</span></span> <span data-ttu-id="07648-377">特定のコンテンツの種類が見つかると (画像など)、**MixedContentOnArrival** が発生します。</span><span class="sxs-lookup"><span data-stu-id="07648-377">If no specific content type is found (for example, pictures), **MixedContentOnArrival** is raised.</span></span> |
| <span data-ttu-id="07648-378">近接共有 (タップして送信) で混在したファイルのセットを処理する</span><span class="sxs-lookup"><span data-stu-id="07648-378">Handling mixed sets of files with Proximity Sharing (tap and send)</span></span> | **<span data-ttu-id="07648-379">MixedContentOnArrival</span><span class="sxs-lookup"><span data-stu-id="07648-379">MixedContentOnArrival</span></span>**          | <span data-ttu-id="07648-380">コンテンツを近接通信を使って送信 (タップして送信) すると、自動再生によって共有ファイルが調べられ、コンテンツの種類が確認されます。</span><span class="sxs-lookup"><span data-stu-id="07648-380">When users send content with using proximity (tap and send), AutoPlay will examine the shared files to determine the type of content.</span></span> <span data-ttu-id="07648-381">特定のコンテンツの種類が見つかると (画像など)、**MixedContentOnArrival** が発生します。</span><span class="sxs-lookup"><span data-stu-id="07648-381">If no specific content type is found (for example, pictures), **MixedContentOnArrival** is raised.</span></span> |
| <span data-ttu-id="07648-382">光学式メディアのビデオを処理する</span><span class="sxs-lookup"><span data-stu-id="07648-382">Handle video from optical media</span></span>                                    | **<span data-ttu-id="07648-383">PlayDVDMovieOnArrival</span><span class="sxs-lookup"><span data-stu-id="07648-383">PlayDVDMovieOnArrival</span></span>**<br />**<span data-ttu-id="07648-384">PlayBluRayOnArrival</span><span class="sxs-lookup"><span data-stu-id="07648-384">PlayBluRayOnArrival</span></span>**<br />**<span data-ttu-id="07648-385">PlayVideoCDMovieOnArrival</span><span class="sxs-lookup"><span data-stu-id="07648-385">PlayVideoCDMovieOnArrival</span></span>**<br />**<span data-ttu-id="07648-386">PlaySuperVideoCDMovieOnArrival</span><span class="sxs-lookup"><span data-stu-id="07648-386">PlaySuperVideoCDMovieOnArrival</span></span>** | <span data-ttu-id="07648-387">光学式ドライブにディスクが挿入されると、自動再生はファイルを確認して、コンテンツの種類を決定します。</span><span class="sxs-lookup"><span data-stu-id="07648-387">When a disk is inserted into the optical drive, AutoPlay will examine the files to determine the type of content.</span></span> <span data-ttu-id="07648-388">ビデオのファイルが見つかった場合は、光学ディスクの種類に対応するイベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="07648-388">When video files are found, the event corresponding to the type of optical disk is raised.</span></span> |
| <span data-ttu-id="07648-389">光学式メディアの音楽を処理する</span><span class="sxs-lookup"><span data-stu-id="07648-389">Handle music from optical media</span></span>                                    | **<span data-ttu-id="07648-390">PlayCDAudioOnArrival</span><span class="sxs-lookup"><span data-stu-id="07648-390">PlayCDAudioOnArrival</span></span>**<br />**<span data-ttu-id="07648-391">PlayDVDAudioOnArrival</span><span class="sxs-lookup"><span data-stu-id="07648-391">PlayDVDAudioOnArrival</span></span>** | <span data-ttu-id="07648-392">光学式ドライブにディスクが挿入されると、自動再生はファイルを確認して、コンテンツの種類を決定します。</span><span class="sxs-lookup"><span data-stu-id="07648-392">When a disk is inserted into the optical drive, AutoPlay will examine the files to determine the type of content.</span></span> <span data-ttu-id="07648-393">音楽のファイルが見つかった場合は、光学ディスクの種類に対応するイベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="07648-393">When music files are found, the event corresponding to the type of optical disk is raised.</span></span> |
| <span data-ttu-id="07648-394">エンハンス ディスクを再生する</span><span class="sxs-lookup"><span data-stu-id="07648-394">Play enhanced disks</span></span>                                                | **<span data-ttu-id="07648-395">PlayEnhancedCDOnArrival</span><span class="sxs-lookup"><span data-stu-id="07648-395">PlayEnhancedCDOnArrival</span></span>**<br />**<span data-ttu-id="07648-396">PlayEnhancedDVDOnArrival</span><span class="sxs-lookup"><span data-stu-id="07648-396">PlayEnhancedDVDOnArrival</span></span>** | <span data-ttu-id="07648-397">光学式ドライブにディスクが挿入されると、自動再生はファイルを確認して、コンテンツの種類を決定します。</span><span class="sxs-lookup"><span data-stu-id="07648-397">When a disk is inserted into the optical drive, AutoPlay will examine the files to determine the type of content.</span></span> <span data-ttu-id="07648-398">エンハンス ディスクが見つかった場合は、光学ディスクの種類に対応するイベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="07648-398">When an enhanced disk is found, the event corresponding to the type of optical disk is raised.</span></span> |
| <span data-ttu-id="07648-399">書き込み可能な光学式ディスクを処理する</span><span class="sxs-lookup"><span data-stu-id="07648-399">Handle writeable optical disks</span></span>                                     | **<span data-ttu-id="07648-400">HandleCDBurningOnArrival</span><span class="sxs-lookup"><span data-stu-id="07648-400">HandleCDBurningOnArrival</span></span>** <br />**<span data-ttu-id="07648-401">HandleDVDBurningOnArrival</span><span class="sxs-lookup"><span data-stu-id="07648-401">HandleDVDBurningOnArrival</span></span>** <br />**<span data-ttu-id="07648-402">HandleBDBurningOnArrival</span><span class="sxs-lookup"><span data-stu-id="07648-402">HandleBDBurningOnArrival</span></span>** | <span data-ttu-id="07648-403">光学式ドライブにディスクが挿入されると、自動再生はファイルを確認して、コンテンツの種類を決定します。</span><span class="sxs-lookup"><span data-stu-id="07648-403">When a disk is inserted into the optical drive, AutoPlay will examine the files to determine the type of content.</span></span> <span data-ttu-id="07648-404">書き込み可能なディスクが見つかった場合は、光学ディスクの種類に対応するイベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="07648-404">When a writable disk is found, the event corresponding to the type of optical disk is raised.</span></span> |
| <span data-ttu-id="07648-405">他のデバイスまたはボリュームの接続を処理する</span><span class="sxs-lookup"><span data-stu-id="07648-405">Handle any other device or volume connection</span></span>                       | **<span data-ttu-id="07648-406">UnknownContentOnArrival</span><span class="sxs-lookup"><span data-stu-id="07648-406">UnknownContentOnArrival</span></span>**        | <span data-ttu-id="07648-407">自動再生コンテンツ イベントのいずれとも一致しないコンテンツが見つかった場合にすべてのイベントで発生します。</span><span class="sxs-lookup"><span data-stu-id="07648-407">Raised for all events in case content is found that does not match any of the AutoPlay content events.</span></span> <span data-ttu-id="07648-408">このイベントを使うことはお勧めできません。</span><span class="sxs-lookup"><span data-stu-id="07648-408">Use of this event is not recommended.</span></span> <span data-ttu-id="07648-409">処理できる特定の自動再生イベントにのみアプリを登録する必要があります。</span><span class="sxs-lookup"><span data-stu-id="07648-409">You should only register your application for the specific AutoPlay events that it can handle.</span></span> |

<span data-ttu-id="07648-410">ボリュームの autorun.inf ファイルの **CustomEvent** エントリを使って、自動再生でカスタムの自動再生コンテンツ イベントが発生することを指定できます。</span><span class="sxs-lookup"><span data-stu-id="07648-410">You can specify that AutoPlay raise a custom AutoPlay Content event using the **CustomEvent** entry in the autorun.inf file for a volume.</span></span> <span data-ttu-id="07648-411">詳しくは、「[Autorun.inf エントリ](https://msdn.microsoft.com/library/windows/desktop/cc144200)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="07648-411">For more info, see [Autorun.inf entries](https://msdn.microsoft.com/library/windows/desktop/cc144200).</span></span>

<span data-ttu-id="07648-412">自動再生コンテンツまたは自動再生デバイスのイベント ハンドラーとしてアプリを登録するには、アプリの package.appxmanifest ファイルに拡張機能を追加します。</span><span class="sxs-lookup"><span data-stu-id="07648-412">You can register your app as an AutoPlay Content or AutoPlay Device event handler by adding an extension to the package.appxmanifest file for your app.</span></span> <span data-ttu-id="07648-413">Visual Studio を使う場合は、**[宣言]** タブで **[自動再生コンテンツ]** または **[自動再生デバイス]** の宣言を追加します。</span><span class="sxs-lookup"><span data-stu-id="07648-413">If you are using Visual Studio, you can add an **AutoPlay Content** or **AutoPlay Device** declaration in the **Declarations** tab.</span></span> <span data-ttu-id="07648-414">アプリの package.appxmanifest ファイルを直接編集する場合は、パッケージ マニフェストに [**Extension**](https://msdn.microsoft.com/library/windows/apps/br211400) 要素を追加し、**Category** として **windows.autoPlayContent** または **windows.autoPlayDevice** を指定します。</span><span class="sxs-lookup"><span data-stu-id="07648-414">If you are editing the package.appxmanifest file for your app directly, add an [**Extension**](https://msdn.microsoft.com/library/windows/apps/br211400) element to your package manifest that specifies either **windows.autoPlayContent** or **windows.autoPlayDevice** as the **Category**.</span></span> <span data-ttu-id="07648-415">たとえば、次のパッケージ マニフェストのエントリでは、**自動再生コンテンツ**拡張機能を追加して、アプリを **ShowPicturesOnArrival** イベントのハンドラーとして登録しています。</span><span class="sxs-lookup"><span data-stu-id="07648-415">For example, the following entry in the package manifest adds an **AutoPlay Content** extension to register the app as a handler for the **ShowPicturesOnArrival** event.</span></span>

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

 

 
