---
author: Karl-Bridge-Microsoft
Description: "Windows Ink をサポートしている UWP アプリでは、インク ストロークを Ink Serialized Format (ISF) ファイルにシリアル化および逆シリアル化することができます。 ISF ファイルは、すべてのインク ストロークのプロパティと動作に関する追加のメタデータを含む GIF 画像です。 インク対応ではないアプリでは、アルファ チャンネルの背景色の透明度を含めて、静的な GIF 画像を表示できます。"
title: "Windows Ink ストローク データの保存と取得"
ms.assetid: C96C9D2F-DB69-4883-9809-4A0DF7CEC506
label: Store and retrieve Windows Ink stroke data
template: detail.hbs
keywords: "Windows Ink, Windows の手書き入力, DirectInk, InkPresenter, InkCanvas, ISF, Ink Serialized Format, ユーザー操作, 入力"
ms.author: kbridge
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
ms.openlocfilehash: 52a8a309758a02db072de5f8050b4e7183ff629d
ms.sourcegitcommit: c519e3d34bef37f87bb44f02b295187849bb5eea
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/25/2017
---
# <a name="store-and-retrieve-windows-ink-stroke-data"></a><span data-ttu-id="e9a67-106">Windows Ink ストローク データの保存と取得</span><span class="sxs-lookup"><span data-stu-id="e9a67-106">Store and retrieve Windows Ink stroke data</span></span>
<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css">

<span data-ttu-id="e9a67-107">Windows Ink をサポートしている UWP アプリでは、インク ストロークを Ink Serialized Format (ISF) ファイルにシリアル化および逆シリアル化することができます。</span><span class="sxs-lookup"><span data-stu-id="e9a67-107">UWP apps that support Windows Ink can serialize and deserialize ink strokes to an Ink Serialized Format (ISF) file.</span></span> <span data-ttu-id="e9a67-108">ISF ファイルは、すべてのインク ストロークのプロパティと動作に関する追加のメタデータを含む GIF 画像です。</span><span class="sxs-lookup"><span data-stu-id="e9a67-108">The ISF file is a GIF image with additional metadata for all ink stroke properties and behaviors.</span></span> <span data-ttu-id="e9a67-109">インク対応ではないアプリでは、アルファ チャンネルの背景色の透明度を含めて、静的な GIF 画像を表示できます。</span><span class="sxs-lookup"><span data-stu-id="e9a67-109">Apps that are not ink-enabled, can view the static GIF image, including alpha-channel background transparency.</span></span>

> [!NOTE]
> <span data-ttu-id="e9a67-110">ISF は、最もコンパクトなインクの永続表現です。</span><span class="sxs-lookup"><span data-stu-id="e9a67-110">ISF is the most compact persistent representation of ink.</span></span> <span data-ttu-id="e9a67-111">バイナリ ドキュメント形式 (GIF ファイルなど) に埋め込むことも、クリップボードに直接配置することもできます。</span><span class="sxs-lookup"><span data-stu-id="e9a67-111">It can be embedded within a binary document format, such as a GIF file, or placed directly on the Clipboard.</span></span>

<div class="important-apis" >
<b><span data-ttu-id="e9a67-112">重要な API</span><span class="sxs-lookup"><span data-stu-id="e9a67-112">Important APIs</span></span></b><br/>
<ul>
<li>[**<span data-ttu-id="e9a67-113">InkCanvas</span><span class="sxs-lookup"><span data-stu-id="e9a67-113">InkCanvas</span></span>**](https://msdn.microsoft.com/library/windows/apps/dn858535)</li>
<li>[**<span data-ttu-id="e9a67-114">Windows.UI.Input.Inking</span><span class="sxs-lookup"><span data-stu-id="e9a67-114">Windows.UI.Input.Inking</span></span>**](https://msdn.microsoft.com/library/windows/apps/br208524)</li>
</ul>
</div>


 

## <a name="save-ink-strokes-to-a-file"></a><span data-ttu-id="e9a67-115">インク ストロークをファイルに保存する</span><span class="sxs-lookup"><span data-stu-id="e9a67-115">Save ink strokes to a file</span></span>


<span data-ttu-id="e9a67-116">ここでは、[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) コントロールに描画されたインク ストロークの保存方法を説明します。</span><span class="sxs-lookup"><span data-stu-id="e9a67-116">Here, we demonstrate how to save ink strokes drawn on an [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) control.</span></span>

1.  <span data-ttu-id="e9a67-117">まず、UI を設定します。</span><span class="sxs-lookup"><span data-stu-id="e9a67-117">First, we set up the UI.</span></span>

    <span data-ttu-id="e9a67-118">UI には [Save]、[Load]、[Clear] の各ボタンと、[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) が含まれています。</span><span class="sxs-lookup"><span data-stu-id="e9a67-118">The UI includes "Save", "Load", and "Clear" buttons, and the [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535).</span></span>
```    XAML
<Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="*"/>
        </Grid.RowDefinitions>
        <StackPanel x:Name="HeaderPanel" Orientation="Horizontal" Grid.Row="0">
            <TextBlock x:Name="Header" 
                       Text="Basic ink store sample" 
                       Style="{ThemeResource HeaderTextBlockStyle}" 
                       Margin="10,0,0,0" />
            <Button x:Name="btnSave" 
                    Content="Save" 
                    Margin="50,0,10,0"/>
            <Button x:Name="btnLoad" 
                    Content="Load" 
                    Margin="50,0,10,0"/>
            <Button x:Name="btnClear" 
                    Content="Clear" 
                    Margin="50,0,10,0"/>
        </StackPanel>
        <Grid Grid.Row="1">
            <InkCanvas x:Name="inkCanvas" />
        </Grid>
    </Grid>
```

2.  <span data-ttu-id="e9a67-119">次に、基本的なインク入力の動作をいくつか設定します。</span><span class="sxs-lookup"><span data-stu-id="e9a67-119">We then set some basic ink input behaviors.</span></span>

    <span data-ttu-id="e9a67-120">[**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) は、ペンとマウスのいずれからの入力データもインク ストローク ([**InputDeviceTypes**](https://msdn.microsoft.com/library/windows/apps/dn922019)) として解釈するように構成します。各ボタンのイベントに対するリスナーも宣言します。</span><span class="sxs-lookup"><span data-stu-id="e9a67-120">The [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) is configured to interpret input data from both pen and mouse as ink strokes ([**InputDeviceTypes**](https://msdn.microsoft.com/library/windows/apps/dn922019)), and listeners for the click events on the buttons are declared.</span></span>
```    CSharp
public MainPage()
    {
        this.InitializeComponent();

        // Set supported inking device types.
        inkCanvas.InkPresenter.InputDeviceTypes =
            Windows.UI.Core.CoreInputDeviceTypes.Mouse |
            Windows.UI.Core.CoreInputDeviceTypes.Pen;

        // Listen for button click to initiate save.
        btnSave.Click += btnSave_Click;
        // Listen for button click to initiate load.
        btnLoad.Click += btnLoad_Click;
        // Listen for button click to clear ink canvas.
        btnClear.Click += btnClear_Click;
    }
```

3.  <span data-ttu-id="e9a67-121">最後に、**[Save]** ボタンのクリック イベント ハンドラーで、インクを保存します。</span><span class="sxs-lookup"><span data-stu-id="e9a67-121">Finally, we save the ink in the click event handler of the **Save** button.</span></span>

    <span data-ttu-id="e9a67-122">[**FileSavePicker**](https://msdn.microsoft.com/library/windows/apps/br207871) を使用すると、インク データの保存先としてファイルと場所の両方をユーザーが選択できます。</span><span class="sxs-lookup"><span data-stu-id="e9a67-122">A [**FileSavePicker**](https://msdn.microsoft.com/library/windows/apps/br207871) lets the user select both the file and the location where the ink data is saved.</span></span>

    <span data-ttu-id="e9a67-123">ファイルが選択されたら、[**ReadWrite**](https://msdn.microsoft.com/library/windows/apps/br241635) に設定された [**IRandomAccessStream**](https://msdn.microsoft.com/library/windows/apps/br241731) ストリームを開きます。</span><span class="sxs-lookup"><span data-stu-id="e9a67-123">Once a file is selected, we open an [**IRandomAccessStream**](https://msdn.microsoft.com/library/windows/apps/br241731) stream set to [**ReadWrite**](https://msdn.microsoft.com/library/windows/apps/br241635).</span></span>

    <span data-ttu-id="e9a67-124">次に [**SaveAsync**](https://msdn.microsoft.com/library/windows/apps/br242114) を呼び出して、[**InkStrokeContainer**](https://msdn.microsoft.com/library/windows/apps/br208492) によって管理されているインク ストロークをストリームにシリアル化します。</span><span class="sxs-lookup"><span data-stu-id="e9a67-124">We then call [**SaveAsync**](https://msdn.microsoft.com/library/windows/apps/br242114) to serialize the ink strokes managed by the [**InkStrokeContainer**](https://msdn.microsoft.com/library/windows/apps/br208492) to the stream.</span></span>
```    CSharp
// Save ink data to a file.
    private async void btnSave_Click(object sender, RoutedEventArgs e)
    {
        // Get all strokes on the InkCanvas.
        IReadOnlyList<InkStroke> currentStrokes = inkCanvas.InkPresenter.StrokeContainer.GetStrokes();

        // Strokes present on ink canvas.
        if (currentStrokes.Count > 0)
        {
            // Let users choose their ink file using a file picker.
            // Initialize the picker.
            Windows.Storage.Pickers.FileSavePicker savePicker = 
                new Windows.Storage.Pickers.FileSavePicker();
            savePicker.SuggestedStartLocation = 
                Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            savePicker.FileTypeChoices.Add(
                "GIF with embedded ISF", 
                new List<string>() { ".gif" });
            savePicker.DefaultFileExtension = ".gif";
            savePicker.SuggestedFileName = "InkSample";

            // Show the file picker.
            Windows.Storage.StorageFile file = 
                await savePicker.PickSaveFileAsync();
            // When chosen, picker returns a reference to the selected file.
            if (file != null)
            {
                // Prevent updates to the file until updates are 
                // finalized with call to CompleteUpdatesAsync.
                Windows.Storage.CachedFileManager.DeferUpdates(file);
                // Open a file stream for writing.
                IRandomAccessStream stream = await file.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite);
                // Write the ink strokes to the output stream.
                using (IOutputStream outputStream = stream.GetOutputStreamAt(0))
                {
                    await inkCanvas.InkPresenter.StrokeContainer.SaveAsync(outputStream);
                    await outputStream.FlushAsync();
                }
                stream.Dispose();

                // Finalize write so other apps can update file.
                Windows.Storage.Provider.FileUpdateStatus status =
                    await Windows.Storage.CachedFileManager.CompleteUpdatesAsync(file);

                if (status == Windows.Storage.Provider.FileUpdateStatus.Complete)
                {
                    // File saved.
                }
                else
                {
                    // File couldn't be saved.
                }
            }
            // User selects Cancel and picker returns null.
            else
            {
                // Operation cancelled.
            }
        }
    }
```

> [!NOTE]  
> <span data-ttu-id="e9a67-125">インク データの保存用にサポートされるファイル形式は GIF のみです。</span><span class="sxs-lookup"><span data-stu-id="e9a67-125">GIF is the only file format supported for saving ink data.</span></span> <span data-ttu-id="e9a67-126">ただし、[**LoadAsync**](https://msdn.microsoft.com/library/windows/apps/hh701607) メソッド (次のセクションで説明します) では、下位互換性のためにその他の形式もサポートされています。</span><span class="sxs-lookup"><span data-stu-id="e9a67-126">However, the [**LoadAsync**](https://msdn.microsoft.com/library/windows/apps/hh701607) method (demonstrated in the next section) does support additional formats for backward compatibility.</span></span>

## <a name="load-ink-strokes-from-a-file"></a><span data-ttu-id="e9a67-127">インク ストロークをファイルから読み込む</span><span class="sxs-lookup"><span data-stu-id="e9a67-127">Load ink strokes from a file</span></span>

<span data-ttu-id="e9a67-128">ここでは、ファイルからインク ストロークを読み込んで [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) コントロールにレンダリングする方法を示します。</span><span class="sxs-lookup"><span data-stu-id="e9a67-128">Here, we demonstrate how to load ink strokes from a file and render them on an [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) control.</span></span>

1.  <span data-ttu-id="e9a67-129">まず、UI を設定します。</span><span class="sxs-lookup"><span data-stu-id="e9a67-129">First, we set up the UI.</span></span>

    <span data-ttu-id="e9a67-130">UI には [Save]、[Load]、[Clear] の各ボタンと、[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) が含まれています。</span><span class="sxs-lookup"><span data-stu-id="e9a67-130">The UI includes "Save", "Load", and "Clear" buttons, and the [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535).</span></span>
```    XAML
<Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="*"/>
        </Grid.RowDefinitions>
        <StackPanel x:Name="HeaderPanel" Orientation="Horizontal" Grid.Row="0">
            <TextBlock x:Name="Header" 
                       Text="Basic ink store sample" 
                       Style="{ThemeResource HeaderTextBlockStyle}" 
                       Margin="10,0,0,0" />
            <Button x:Name="btnSave" 
                    Content="Save" 
                    Margin="50,0,10,0"/>
            <Button x:Name="btnLoad" 
                    Content="Load" 
                    Margin="50,0,10,0"/>
            <Button x:Name="btnClear" 
                    Content="Clear" 
                    Margin="50,0,10,0"/>
        </StackPanel>
        <Grid Grid.Row="1">
            <InkCanvas x:Name="inkCanvas" />
        </Grid>
    </Grid>
```

2.  <span data-ttu-id="e9a67-131">次に、基本的なインク入力の動作をいくつか設定します。</span><span class="sxs-lookup"><span data-stu-id="e9a67-131">We then set some basic ink input behaviors.</span></span>

    <span data-ttu-id="e9a67-132">[**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) は、ペンとマウスのいずれからの入力データもインク ストローク ([**InputDeviceTypes**](https://msdn.microsoft.com/library/windows/apps/dn922019)) として解釈するように構成します。各ボタンのイベントに対するリスナーも宣言します。</span><span class="sxs-lookup"><span data-stu-id="e9a67-132">The [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) is configured to interpret input data from both pen and mouse as ink strokes ([**InputDeviceTypes**](https://msdn.microsoft.com/library/windows/apps/dn922019)), and listeners for the click events on the buttons are declared.</span></span>
```    CSharp
public MainPage()
    {
        this.InitializeComponent();

        // Set supported inking device types.
        inkCanvas.InkPresenter.InputDeviceTypes =
            Windows.UI.Core.CoreInputDeviceTypes.Mouse |
            Windows.UI.Core.CoreInputDeviceTypes.Pen;

        // Listen for button click to initiate save.
        btnSave.Click += btnSave_Click;
        // Listen for button click to initiate load.
        btnLoad.Click += btnLoad_Click;
        // Listen for button click to clear ink canvas.
        btnClear.Click += btnClear_Click;
    }
```

3.  <span data-ttu-id="e9a67-133">最後に、**[Load]** ボタンのクリック イベント ハンドラーで、インクを読み込みます。</span><span class="sxs-lookup"><span data-stu-id="e9a67-133">Finally, we load the ink in the click event handler of the **Load** button.</span></span>

    <span data-ttu-id="e9a67-134">[**FileOpenPicker**](https://msdn.microsoft.com/library/windows/apps/br207847) を使用すると、保存済みインク データを取得するためのファイルと場所の両方をユーザーが選択できます。</span><span class="sxs-lookup"><span data-stu-id="e9a67-134">A [**FileOpenPicker**](https://msdn.microsoft.com/library/windows/apps/br207847) lets the user select both the file and the location from where to retrieve the saved ink data.</span></span>

    <span data-ttu-id="e9a67-135">ファイルが選択されたら、[**Read**](https://msdn.microsoft.com/library/windows/apps/br241635) に設定された [**IRandomAccessStream**](https://msdn.microsoft.com/library/windows/apps/br241731) ストリームを開きます。</span><span class="sxs-lookup"><span data-stu-id="e9a67-135">Once a file is selected, we open an [**IRandomAccessStream**](https://msdn.microsoft.com/library/windows/apps/br241731) stream set to [**Read**](https://msdn.microsoft.com/library/windows/apps/br241635).</span></span>

    <span data-ttu-id="e9a67-136">次に [**LoadAsync**](https://msdn.microsoft.com/library/windows/apps/hh701607) を呼び出して、保存済みのインク ストロークの読み取りと逆シリアル化を行い、[**InkStrokeContainer**](https://msdn.microsoft.com/library/windows/apps/br208492) に読み込みます。</span><span class="sxs-lookup"><span data-stu-id="e9a67-136">We then call [**LoadAsync**](https://msdn.microsoft.com/library/windows/apps/hh701607) to read, de-serialize, and load the saved ink strokes into the [**InkStrokeContainer**](https://msdn.microsoft.com/library/windows/apps/br208492).</span></span> <span data-ttu-id="e9a67-137">ストロークを **InkStrokeContainer** に読み込むと、[**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) は直ちにストロークを [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) にレンダリングします。</span><span class="sxs-lookup"><span data-stu-id="e9a67-137">Loading the strokes into the **InkStrokeContainer** causes the [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) to immediately render them to the [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535).</span></span>

    > [!NOTE]
    > <span data-ttu-id="e9a67-138">新しいストロークが読み込まれる前には、InkStrokeContainer 内の既存のストロークがすべて消去されます。</span><span class="sxs-lookup"><span data-stu-id="e9a67-138">All existing strokes in the InkStrokeContainer are cleared before new strokes are loaded.</span></span>

``` csharp
// Load ink data from a file.
private async void btnLoad_Click(object sender, RoutedEventArgs e)
{
    // Let users choose their ink file using a file picker.
    // Initialize the picker.
    Windows.Storage.Pickers.FileOpenPicker openPicker =
        new Windows.Storage.Pickers.FileOpenPicker();
    openPicker.SuggestedStartLocation =
        Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
    openPicker.FileTypeFilter.Add(".gif");
    // Show the file picker.
    Windows.Storage.StorageFile file = await openPicker.PickSingleFileAsync();
    // User selects a file and picker returns a reference to the selected file.
    if (file != null)
    {
        // Open a file stream for reading.
        IRandomAccessStream stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
        // Read from file.
        using (var inputStream = stream.GetInputStreamAt(0))
        {
            await inkCanvas.InkPresenter.StrokeContainer.LoadAsync(inputStream);
        }
        stream.Dispose();
    }
    // User selects Cancel and picker returns null.
    else
    {
        // Operation cancelled.
    }
}
```

> [!NOTE]
> <span data-ttu-id="e9a67-139">インク データの保存用にサポートされるファイル形式は GIF のみです。</span><span class="sxs-lookup"><span data-stu-id="e9a67-139">GIF is the only file format supported for saving ink data.</span></span> <span data-ttu-id="e9a67-140">ただし、[**LoadAsync**](https://msdn.microsoft.com/library/windows/apps/hh701607) メソッドでは、下位互換性のために次の形式もサポートされています。</span><span class="sxs-lookup"><span data-stu-id="e9a67-140">However, the [**LoadAsync**](https://msdn.microsoft.com/library/windows/apps/hh701607) method does support the following formats for backward compatibility.</span></span>

| <span data-ttu-id="e9a67-141">形式</span><span class="sxs-lookup"><span data-stu-id="e9a67-141">Format</span></span>                    | <span data-ttu-id="e9a67-142">説明</span><span class="sxs-lookup"><span data-stu-id="e9a67-142">Description</span></span> |
|---------------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="e9a67-143">InkSerializedFormat</span><span class="sxs-lookup"><span data-stu-id="e9a67-143">InkSerializedFormat</span></span>       | <span data-ttu-id="e9a67-144">ISF で永続化されたインクを指定します。</span><span class="sxs-lookup"><span data-stu-id="e9a67-144">Specifies ink that is persisted using ISF.</span></span> <span data-ttu-id="e9a67-145">これは最もコンパクトなインクの永続表現です。</span><span class="sxs-lookup"><span data-stu-id="e9a67-145">This is the most compact persistent representation of ink.</span></span> <span data-ttu-id="e9a67-146">バイナリ ドキュメント形式への埋め込みまたはクリップボードへの直接配置を実行できます。</span><span class="sxs-lookup"><span data-stu-id="e9a67-146">It can be embedded within a binary document format or placed directly on the Clipboard.</span></span>                                                                                                                                                                                                         |
| <span data-ttu-id="e9a67-147">Base64InkSerializedFormat</span><span class="sxs-lookup"><span data-stu-id="e9a67-147">Base64InkSerializedFormat</span></span> | <span data-ttu-id="e9a67-148">base64 ストリームとして ISF をエンコードすることで永続化されたインクを指定します。</span><span class="sxs-lookup"><span data-stu-id="e9a67-148">Specifies ink that is persisted by encoding the ISF as a base64 stream.</span></span> <span data-ttu-id="e9a67-149">この形式を指定すると、インクを XML ファイルや HTML ファイルで直接エンコードできます。</span><span class="sxs-lookup"><span data-stu-id="e9a67-149">This format is provided so ink can be encoded directly in an XML or HTML file.</span></span>                                                                                                                                                                                                                                                |
| <span data-ttu-id="e9a67-150">Gif</span><span class="sxs-lookup"><span data-stu-id="e9a67-150">Gif</span></span>                       | <span data-ttu-id="e9a67-151">ファイル内に ISF がメタデータとして埋め込まれた GIF ファイルで永続化されたインクを指定します。</span><span class="sxs-lookup"><span data-stu-id="e9a67-151">Specifies ink that is persisted by using a GIF file that contains ISF as metadata embedded within the file.</span></span> <span data-ttu-id="e9a67-152">この形式では、インクに対応していないアプリケーションでインクを表示でき、インク対応のアプリケーションに返されたときもまったく同じように再現できます。</span><span class="sxs-lookup"><span data-stu-id="e9a67-152">This enables ink to be viewed in applications that are not ink-enabled and maintain its full ink fidelity when it returns to an ink-enabled application.</span></span> <span data-ttu-id="e9a67-153">この形式は、HTML ファイル内のインクのコンテンツを転送して、インク アプリとインク対応でないアプリで使えるようにする場合に適しています。</span><span class="sxs-lookup"><span data-stu-id="e9a67-153">This format is ideal when transporting ink content within an HTML file and for making it usable by ink and non-ink applications.</span></span> |
| <span data-ttu-id="e9a67-154">Base64Gif</span><span class="sxs-lookup"><span data-stu-id="e9a67-154">Base64Gif</span></span>                 | <span data-ttu-id="e9a67-155">base64 エンコードの拡張 GIF で永続化されたインクを指定します。</span><span class="sxs-lookup"><span data-stu-id="e9a67-155">Specifies ink that is persisted by using a base64-encoded fortified GIF.</span></span> <span data-ttu-id="e9a67-156">この形式は、後で画像に変換するために、インクを XML ファイルや HTML ファイルで直接エンコードする場合に指定します。</span><span class="sxs-lookup"><span data-stu-id="e9a67-156">This format is provided when ink is to be encoded directly in an XML or HTML file for later conversion into an image.</span></span> <span data-ttu-id="e9a67-157">すべてのインク情報を格納するために生成された XML 形式で、Extensible Stylesheet Language Transformations (XSLT) を介して HTML を生成するために使うことができます。</span><span class="sxs-lookup"><span data-stu-id="e9a67-157">A possible use of this is in an XML format generated to contain all ink information and used to generate HTML through Extensible Stylesheet Language Transformations (XSLT).</span></span> 

## <a name="copy-and-paste-ink-strokes-with-the-clipboard"></a><span data-ttu-id="e9a67-158">クリップボードを使ってインク ストロークのコピーと貼り付けを行う</span><span class="sxs-lookup"><span data-stu-id="e9a67-158">Copy and paste ink strokes with the clipboard</span></span>


<span data-ttu-id="e9a67-159">ここでは、クリップボードを使って、アプリ間でインク ストロークを転送する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="e9a67-159">Here, we demonstrate how to use the clipboard to transfer ink strokes between apps.</span></span>

<span data-ttu-id="e9a67-160">クリップボード機能をサポートするために、組み込みの [**InkStrokeContainer**](https://msdn.microsoft.com/library/windows/apps/br208492) の切り取り/コピー コマンドでは、1 つまたは複数のインク ストロークの選択が求められます。</span><span class="sxs-lookup"><span data-stu-id="e9a67-160">To support clipboard functionality, the built-in [**InkStrokeContainer**](https://msdn.microsoft.com/library/windows/apps/br208492) cut and copy commands require one or more ink strokes be selected.</span></span>

<span data-ttu-id="e9a67-161">次の例では、ペン バレル ボタン (またはマウスの右ボタン) で入力が変更された場合にストロークを選べるようにする手順を示しています。</span><span class="sxs-lookup"><span data-stu-id="e9a67-161">For this example, we enable stroke selection when input is modified with a pen barrel button (or right mouse button).</span></span> <span data-ttu-id="e9a67-162">ストローク選択の実装方法を示す詳しい例については、「[UWP アプリでのペン操作と Windows Ink](pen-and-stylus-interactions.md)」の「高度な処理のための入力のパススルー」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e9a67-162">For a complete example of how to implement stroke selection, see Pass-through input for advanced processing in [Pen and stylus interactions](pen-and-stylus-interactions.md).</span></span>

1.  <span data-ttu-id="e9a67-163">まず、UI を設定します。</span><span class="sxs-lookup"><span data-stu-id="e9a67-163">First, we set up the UI.</span></span>

    <span data-ttu-id="e9a67-164">UI には、[Cut]、[Copy]、[Paste]、[Clear] の各ボタン、[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535)、選択キャンバスが含まれています。</span><span class="sxs-lookup"><span data-stu-id="e9a67-164">The UI includes "Cut", "Copy", "Paste", and "Clear" buttons, along with the [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) and a selection canvas.</span></span>
```    XAML
<Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="*"/>
        </Grid.RowDefinitions>
        <StackPanel x:Name="HeaderPanel" Orientation="Horizontal" Grid.Row="0">
            <TextBlock x:Name="tbHeader" 
                       Text="Basic ink store sample" 
                       Style="{ThemeResource HeaderTextBlockStyle}" 
                       Margin="10,0,0,0" />
            <Button x:Name="btnCut" 
                    Content="Cut" 
                    Margin="20,0,10,0"/>
            <Button x:Name="btnCopy" 
                    Content="Copy" 
                    Margin="20,0,10,0"/>
            <Button x:Name="btnPaste" 
                    Content="Paste" 
                    Margin="20,0,10,0"/>
            <Button x:Name="btnClear" 
                    Content="Clear" 
                    Margin="20,0,10,0"/>
        </StackPanel>
        <Grid x:Name="gridCanvas" Grid.Row="1">
            <!-- Canvas for displaying selection UI. -->
            <Canvas x:Name="selectionCanvas"/>
            <!-- Inking area -->
            <InkCanvas x:Name="inkCanvas"/>
        </Grid>
    </Grid>
```

2.  <span data-ttu-id="e9a67-165">次に、基本的なインク入力の動作をいくつか設定します。</span><span class="sxs-lookup"><span data-stu-id="e9a67-165">We then set some basic ink input behaviors.</span></span>

    <span data-ttu-id="e9a67-166">[**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) は、ペンとマウスのいずれからの入力データもインク ストローク ([**InputDeviceTypes**](https://msdn.microsoft.com/library/windows/apps/dn922019)) として解釈するように構成します。</span><span class="sxs-lookup"><span data-stu-id="e9a67-166">The [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) is configured to interpret input data from both pen and mouse as ink strokes ([**InputDeviceTypes**](https://msdn.microsoft.com/library/windows/apps/dn922019)).</span></span> <span data-ttu-id="e9a67-167">ここでは、ボタンのクリック イベント、選択機能のポインター イベントおよびストローク イベントに対するリスナーも宣言されています。</span><span class="sxs-lookup"><span data-stu-id="e9a67-167">Listeners for the click events on the buttons as well as pointer and stroke events for selection functionality are also declared here.</span></span>

    <span data-ttu-id="e9a67-168">ストローク選択の実装方法を示す詳しい例については、「[UWP アプリでのペン操作と Windows Ink](pen-and-stylus-interactions.md)」の「高度な処理のための入力のパススルー」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e9a67-168">For a complete example of how to implement stroke selection, see Pass-through input for advanced processing in [Pen and stylus interactions](pen-and-stylus-interactions.md).</span></span>
```    CSharp
public MainPage()
    {
        this.InitializeComponent();

        // Set supported inking device types.
        inkCanvas.InkPresenter.InputDeviceTypes =
            Windows.UI.Core.CoreInputDeviceTypes.Mouse |
            Windows.UI.Core.CoreInputDeviceTypes.Pen;

        // Listen for button click to cut ink strokes.
        btnCut.Click += btnCut_Click;
        // Listen for button click to copy ink strokes.
        btnCopy.Click += btnCopy_Click;
        // Listen for button click to paste ink strokes.
        btnPaste.Click += btnPaste_Click;
        // Listen for button click to clear ink canvas.
        btnClear.Click += btnClear_Click;

        // By default, the InkPresenter processes input modified by 
        // a secondary affordance (pen barrel button, right mouse 
        // button, or similar) as ink.
        // To pass through modified input to the app for custom processing 
        // on the app UI thread instead of the background ink thread, set 
        // InputProcessingConfiguration.RightDragAction to LeaveUnprocessed.
        inkCanvas.InkPresenter.InputProcessingConfiguration.RightDragAction =
            InkInputRightDragAction.LeaveUnprocessed;

        // Listen for unprocessed pointer events from modified input.
        // The input is used to provide selection functionality.
        inkCanvas.InkPresenter.UnprocessedInput.PointerPressed +=
            UnprocessedInput_PointerPressed;
        inkCanvas.InkPresenter.UnprocessedInput.PointerMoved +=
            UnprocessedInput_PointerMoved;
        inkCanvas.InkPresenter.UnprocessedInput.PointerReleased +=
            UnprocessedInput_PointerReleased;

        // Listen for new ink or erase strokes to clean up selection UI.
        inkCanvas.InkPresenter.StrokeInput.StrokeStarted +=
            StrokeInput_StrokeStarted;
        inkCanvas.InkPresenter.StrokesErased +=
            InkPresenter_StrokesErased;
    }
```

3.  <span data-ttu-id="e9a67-169">最後に、ストローク選択サポートを追加した後で、**[Cut]** ボタン、**[Copy]** ボタン、**[Paste]** ボタンのクリック イベント ハンドラーにクリップボード機能を実装します。</span><span class="sxs-lookup"><span data-stu-id="e9a67-169">Finally, after adding stroke selection support, we implement clipboard functionality in the click event handlers of the **Cut**, **Copy**, and **Paste** buttons.</span></span>

    <span data-ttu-id="e9a67-170">切り取りの場合は、まず [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn922011) の [**InkStrokeContainer**](https://msdn.microsoft.com/library/windows/apps/br208492) で [**CopySelectedToClipboard**](https://msdn.microsoft.com/library/windows/apps/br244232) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="e9a67-170">For cut, we first call [**CopySelectedToClipboard**](https://msdn.microsoft.com/library/windows/apps/br244232) on the [**InkStrokeContainer**](https://msdn.microsoft.com/library/windows/apps/br208492) of the [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn922011).</span></span>

    <span data-ttu-id="e9a67-171">次に [**DeleteSelected**](https://msdn.microsoft.com/library/windows/apps/br244233) を呼び出して、インク キャンバスからストロークを削除します。</span><span class="sxs-lookup"><span data-stu-id="e9a67-171">We then call [**DeleteSelected**](https://msdn.microsoft.com/library/windows/apps/br244233) to remove the strokes from the ink canvas.</span></span>

    <span data-ttu-id="e9a67-172">最後に、選択キャンバスからすべてのストローク選択を削除します。</span><span class="sxs-lookup"><span data-stu-id="e9a67-172">Finally, we delete all selection strokes from the selection canvas.</span></span>
```    CSharp
private void btnCut_Click(object sender, RoutedEventArgs e)
    {
        inkCanvas.InkPresenter.StrokeContainer.CopySelectedToClipboard();
        inkCanvas.InkPresenter.StrokeContainer.DeleteSelected();
        ClearSelection();
    }
```
```    CSharp
// Clean up selection UI.
    private void ClearSelection()
    {
        var strokes = inkCanvas.InkPresenter.StrokeContainer.GetStrokes();
        foreach (var stroke in strokes)
        {
            stroke.Selected = false;
        }
        ClearDrawnBoundingRect();
    }

    private void ClearDrawnBoundingRect()
    {
        if (selectionCanvas.Children.Any())
        {
            selectionCanvas.Children.Clear();
            boundingRect = Rect.Empty;
        }
    }
```

    For copy, we simply call [**CopySelectedToClipboard**](https://msdn.microsoft.com/library/windows/apps/br244232) on the [**InkStrokeContainer**](https://msdn.microsoft.com/library/windows/apps/br208492) of the [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn922011).
```    CSharp
private void btnCopy_Click(object sender, RoutedEventArgs e)
    {
        inkCanvas.InkPresenter.StrokeContainer.CopySelectedToClipboard();
    }
```

    For paste, we call [**CanPasteFromClipboard**](https://msdn.microsoft.com/library/windows/apps/br208495) to ensure that the content on the clipboard can be pasted to the ink canvas.

    If so, we call [**PasteFromClipboard**](https://msdn.microsoft.com/library/windows/apps/br208503) to insert the clipboard ink strokes into the [**InkStrokeContainer**](https://msdn.microsoft.com/library/windows/apps/br208492) of the [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn922011), which then renders the strokes to the ink canvas.
```    CSharp
private void btnPaste_Click(object sender, RoutedEventArgs e)
    {
        if (inkCanvas.InkPresenter.StrokeContainer.CanPasteFromClipboard())
        {
            inkCanvas.InkPresenter.StrokeContainer.PasteFromClipboard(
                new Point(0, 0));
        }
        else
        {
            // Cannot paste from clipboard.
        }
    }
```

## <a name="related-articles"></a><span data-ttu-id="e9a67-173">関連記事</span><span class="sxs-lookup"><span data-stu-id="e9a67-173">Related articles</span></span>

* [<span data-ttu-id="e9a67-174">ペン操作とスタイラス操作</span><span class="sxs-lookup"><span data-stu-id="e9a67-174">Pen and stylus interactions</span></span>](pen-and-stylus-interactions.md)

**<span data-ttu-id="e9a67-175">サンプル</span><span class="sxs-lookup"><span data-stu-id="e9a67-175">Samples</span></span>**
* [<span data-ttu-id="e9a67-176">単純なインクのサンプル (C#/C++)</span><span class="sxs-lookup"><span data-stu-id="e9a67-176">Simple ink sample (C#/C++)</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=620312)
* [<span data-ttu-id="e9a67-177">複雑なインクのサンプル (C++)</span><span class="sxs-lookup"><span data-stu-id="e9a67-177">Complex ink sample (C++)</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=620314)
* [<span data-ttu-id="e9a67-178">インクのサンプル (JavaScript)</span><span class="sxs-lookup"><span data-stu-id="e9a67-178">Ink sample (JavaScript)</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=620308)
* [<span data-ttu-id="e9a67-179">入門チュートリアル: UWP アプリでのインクのサポート</span><span class="sxs-lookup"><span data-stu-id="e9a67-179">Get Started Tutorial: Support ink in your UWP app</span></span>](https://aka.ms/appsample-ink)
* [<span data-ttu-id="e9a67-180">塗り絵帳のサンプル</span><span class="sxs-lookup"><span data-stu-id="e9a67-180">Coloring book sample</span></span>](https://aka.ms/cpubsample-coloringbook)
* [<span data-ttu-id="e9a67-181">Family Notes のサンプル</span><span class="sxs-lookup"><span data-stu-id="e9a67-181">Family notes sample</span></span>](https://aka.ms/cpubsample-familynotessample)



