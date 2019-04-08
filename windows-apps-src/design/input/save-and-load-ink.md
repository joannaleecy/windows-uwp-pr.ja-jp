---
Description: Windows Ink をサポートしている UWP アプリでは、インク ストロークを Ink Serialized Format (ISF) ファイルにシリアル化および逆シリアル化することができます。 ISF ファイルは、すべてのインク ストロークのプロパティと動作に関する追加のメタデータを含む GIF 画像です。 インク対応ではないアプリでは、アルファ チャンネルの背景色の透明度を含めて、静的な GIF 画像を表示できます。
title: Windows Ink ストローク データの保存と取得
ms.assetid: C96C9D2F-DB69-4883-9809-4A0DF7CEC506
label: Store and retrieve Windows Ink stroke data
template: detail.hbs
keywords: Windows Ink, Windows の手書き入力, DirectInk, InkPresenter, InkCanvas, ISF, Ink Serialized Format, ユーザー操作, 入力
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 0c12e5cb7012ba9ff9a4ed383427e37b79835983
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57645847"
---
# <a name="store-and-retrieve-windows-ink-stroke-data"></a><span data-ttu-id="281df-106">Windows Ink ストローク データの保存と取得</span><span class="sxs-lookup"><span data-stu-id="281df-106">Store and retrieve Windows Ink stroke data</span></span>


<span data-ttu-id="281df-107">Windows Ink をサポートしている UWP アプリでは、インク ストロークを Ink Serialized Format (ISF) ファイルにシリアル化および逆シリアル化することができます。</span><span class="sxs-lookup"><span data-stu-id="281df-107">UWP apps that support Windows Ink can serialize and deserialize ink strokes to an Ink Serialized Format (ISF) file.</span></span> <span data-ttu-id="281df-108">ISF ファイルは、すべてのインク ストロークのプロパティと動作に関する追加のメタデータを含む GIF 画像です。</span><span class="sxs-lookup"><span data-stu-id="281df-108">The ISF file is a GIF image with additional metadata for all ink stroke properties and behaviors.</span></span> <span data-ttu-id="281df-109">インク対応ではないアプリでは、アルファ チャンネルの背景色の透明度を含めて、静的な GIF 画像を表示できます。</span><span class="sxs-lookup"><span data-stu-id="281df-109">Apps that are not ink-enabled, can view the static GIF image, including alpha-channel background transparency.</span></span>

> [!NOTE]
> <span data-ttu-id="281df-110">ISF は、最もコンパクトなインクの永続表現です。</span><span class="sxs-lookup"><span data-stu-id="281df-110">ISF is the most compact persistent representation of ink.</span></span> <span data-ttu-id="281df-111">バイナリ ドキュメント形式 (GIF ファイルなど) に埋め込むことも、クリップボードに直接配置することもできます。</span><span class="sxs-lookup"><span data-stu-id="281df-111">It can be embedded within a binary document format, such as a GIF file, or placed directly on the Clipboard.</span></span>

> <span data-ttu-id="281df-112">**重要な API**:[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535)、 [ **Windows.UI.Input.Inking**](https://msdn.microsoft.com/library/windows/apps/br208524)</span><span class="sxs-lookup"><span data-stu-id="281df-112">**Important APIs**: [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535), [**Windows.UI.Input.Inking**](https://msdn.microsoft.com/library/windows/apps/br208524)</span></span>

## <a name="save-ink-strokes-to-a-file"></a><span data-ttu-id="281df-113">インク ストロークをファイルに保存する</span><span class="sxs-lookup"><span data-stu-id="281df-113">Save ink strokes to a file</span></span>

<span data-ttu-id="281df-114">ここでは、[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) コントロールに描画されたインク ストロークの保存方法を説明します。</span><span class="sxs-lookup"><span data-stu-id="281df-114">Here, we demonstrate how to save ink strokes drawn on an [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) control.</span></span>

<span data-ttu-id="281df-115">**このサンプルをからダウンロード[を保存し、インク ストロークを形式 ISF (Ink Serialized) ファイルから読み込む](https://github.com/MicrosoftDocs/windows-topic-specific-samples/archive/uwp-ink-store.zip)**</span><span class="sxs-lookup"><span data-stu-id="281df-115">**Download this sample from [Save and load ink strokes from an Ink Serialized Format (ISF) file](https://github.com/MicrosoftDocs/windows-topic-specific-samples/archive/uwp-ink-store.zip)**</span></span>

1.  <span data-ttu-id="281df-116">まず、UI を設定します。</span><span class="sxs-lookup"><span data-stu-id="281df-116">First, we set up the UI.</span></span>

    <span data-ttu-id="281df-117">UI には [Save]、[Load]、[Clear] の各ボタンと、[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) が含まれています。</span><span class="sxs-lookup"><span data-stu-id="281df-117">The UI includes "Save", "Load", and "Clear" buttons, and the [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535).</span></span>
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

2.  <span data-ttu-id="281df-118">次に、基本的なインク入力の動作をいくつか設定します。</span><span class="sxs-lookup"><span data-stu-id="281df-118">We then set some basic ink input behaviors.</span></span>

    <span data-ttu-id="281df-119">[  **InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) は、ペンとマウスのいずれからの入力データもインク ストローク ([**InputDeviceTypes**](https://msdn.microsoft.com/library/windows/apps/dn922019)) として解釈するように構成します。各ボタンのイベントに対するリスナーも宣言します。</span><span class="sxs-lookup"><span data-stu-id="281df-119">The [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) is configured to interpret input data from both pen and mouse as ink strokes ([**InputDeviceTypes**](https://msdn.microsoft.com/library/windows/apps/dn922019)), and listeners for the click events on the buttons are declared.</span></span>
```csharp
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

3.  <span data-ttu-id="281df-120">最後に、**[Save]** ボタンのクリック イベント ハンドラーで、インクを保存します。</span><span class="sxs-lookup"><span data-stu-id="281df-120">Finally, we save the ink in the click event handler of the **Save** button.</span></span>

    <span data-ttu-id="281df-121">[  **FileSavePicker**](https://msdn.microsoft.com/library/windows/apps/br207871) を使用すると、インク データの保存先としてファイルと場所の両方をユーザーが選択できます。</span><span class="sxs-lookup"><span data-stu-id="281df-121">A [**FileSavePicker**](https://msdn.microsoft.com/library/windows/apps/br207871) lets the user select both the file and the location where the ink data is saved.</span></span>

    <span data-ttu-id="281df-122">ファイルが選択されたら、[**ReadWrite**](https://msdn.microsoft.com/library/windows/apps/br241635) に設定された [**IRandomAccessStream**](https://msdn.microsoft.com/library/windows/apps/br241731) ストリームを開きます。</span><span class="sxs-lookup"><span data-stu-id="281df-122">Once a file is selected, we open an [**IRandomAccessStream**](https://msdn.microsoft.com/library/windows/apps/br241731) stream set to [**ReadWrite**](https://msdn.microsoft.com/library/windows/apps/br241635).</span></span>

    <span data-ttu-id="281df-123">次に [**SaveAsync**](https://msdn.microsoft.com/library/windows/apps/br242114) を呼び出して、[**InkStrokeContainer**](https://msdn.microsoft.com/library/windows/apps/br208492) によって管理されているインク ストロークをストリームにシリアル化します。</span><span class="sxs-lookup"><span data-stu-id="281df-123">We then call [**SaveAsync**](https://msdn.microsoft.com/library/windows/apps/br242114) to serialize the ink strokes managed by the [**InkStrokeContainer**](https://msdn.microsoft.com/library/windows/apps/br208492) to the stream.</span></span>

```csharp
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
> <span data-ttu-id="281df-124">インク データの保存用にサポートされるファイル形式は GIF のみです。</span><span class="sxs-lookup"><span data-stu-id="281df-124">GIF is the only file format supported for saving ink data.</span></span> <span data-ttu-id="281df-125">ただし、[**LoadAsync**](https://msdn.microsoft.com/library/windows/apps/hh701607) メソッド (次のセクションで説明します) では、下位互換性のためにその他の形式もサポートされています。</span><span class="sxs-lookup"><span data-stu-id="281df-125">However, the [**LoadAsync**](https://msdn.microsoft.com/library/windows/apps/hh701607) method (demonstrated in the next section) does support additional formats for backward compatibility.</span></span>

## <a name="load-ink-strokes-from-a-file"></a><span data-ttu-id="281df-126">インク ストロークをファイルから読み込む</span><span class="sxs-lookup"><span data-stu-id="281df-126">Load ink strokes from a file</span></span>

<span data-ttu-id="281df-127">ここでは、ファイルからインク ストロークを読み込んで [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) コントロールにレンダリングする方法を示します。</span><span class="sxs-lookup"><span data-stu-id="281df-127">Here, we demonstrate how to load ink strokes from a file and render them on an [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) control.</span></span>

<span data-ttu-id="281df-128">**このサンプルをからダウンロード[を保存し、インク ストロークを形式 ISF (Ink Serialized) ファイルから読み込む](https://github.com/MicrosoftDocs/windows-topic-specific-samples/archive/uwp-ink-store.zip)**</span><span class="sxs-lookup"><span data-stu-id="281df-128">**Download this sample from [Save and load ink strokes from an Ink Serialized Format (ISF) file](https://github.com/MicrosoftDocs/windows-topic-specific-samples/archive/uwp-ink-store.zip)**</span></span>

1.  <span data-ttu-id="281df-129">まず、UI を設定します。</span><span class="sxs-lookup"><span data-stu-id="281df-129">First, we set up the UI.</span></span>

    <span data-ttu-id="281df-130">UI には [Save]、[Load]、[Clear] の各ボタンと、[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) が含まれています。</span><span class="sxs-lookup"><span data-stu-id="281df-130">The UI includes "Save", "Load", and "Clear" buttons, and the [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535).</span></span>
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

2.  <span data-ttu-id="281df-131">次に、基本的なインク入力の動作をいくつか設定します。</span><span class="sxs-lookup"><span data-stu-id="281df-131">We then set some basic ink input behaviors.</span></span>

    <span data-ttu-id="281df-132">[  **InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) は、ペンとマウスのいずれからの入力データもインク ストローク ([**InputDeviceTypes**](https://msdn.microsoft.com/library/windows/apps/dn922019)) として解釈するように構成します。各ボタンのイベントに対するリスナーも宣言します。</span><span class="sxs-lookup"><span data-stu-id="281df-132">The [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) is configured to interpret input data from both pen and mouse as ink strokes ([**InputDeviceTypes**](https://msdn.microsoft.com/library/windows/apps/dn922019)), and listeners for the click events on the buttons are declared.</span></span>
```csharp
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

3.  <span data-ttu-id="281df-133">最後に、**[Load]** ボタンのクリック イベント ハンドラーで、インクを読み込みます。</span><span class="sxs-lookup"><span data-stu-id="281df-133">Finally, we load the ink in the click event handler of the **Load** button.</span></span>

    <span data-ttu-id="281df-134">[  **FileOpenPicker**](https://msdn.microsoft.com/library/windows/apps/br207847) を使用すると、保存済みインク データを取得するためのファイルと場所の両方をユーザーが選択できます。</span><span class="sxs-lookup"><span data-stu-id="281df-134">A [**FileOpenPicker**](https://msdn.microsoft.com/library/windows/apps/br207847) lets the user select both the file and the location from where to retrieve the saved ink data.</span></span>

    <span data-ttu-id="281df-135">ファイルが選択されたら、[**Read**](https://msdn.microsoft.com/library/windows/apps/br241635) に設定された [**IRandomAccessStream**](https://msdn.microsoft.com/library/windows/apps/br241731) ストリームを開きます。</span><span class="sxs-lookup"><span data-stu-id="281df-135">Once a file is selected, we open an [**IRandomAccessStream**](https://msdn.microsoft.com/library/windows/apps/br241731) stream set to [**Read**](https://msdn.microsoft.com/library/windows/apps/br241635).</span></span>

    <span data-ttu-id="281df-136">次に [**LoadAsync**](https://msdn.microsoft.com/library/windows/apps/hh701607) を呼び出して、保存済みのインク ストロークの読み取りと逆シリアル化を行い、[**InkStrokeContainer**](https://msdn.microsoft.com/library/windows/apps/br208492) に読み込みます。</span><span class="sxs-lookup"><span data-stu-id="281df-136">We then call [**LoadAsync**](https://msdn.microsoft.com/library/windows/apps/hh701607) to read, de-serialize, and load the saved ink strokes into the [**InkStrokeContainer**](https://msdn.microsoft.com/library/windows/apps/br208492).</span></span> <span data-ttu-id="281df-137">ストロークを **InkStrokeContainer** に読み込むと、[**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) は直ちにストロークを [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) にレンダリングします。</span><span class="sxs-lookup"><span data-stu-id="281df-137">Loading the strokes into the **InkStrokeContainer** causes the [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) to immediately render them to the [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535).</span></span>

    > [!NOTE]
    > <span data-ttu-id="281df-138">新しいストロークが読み込まれる前には、InkStrokeContainer 内の既存のストロークがすべて消去されます。</span><span class="sxs-lookup"><span data-stu-id="281df-138">All existing strokes in the InkStrokeContainer are cleared before new strokes are loaded.</span></span>

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
> <span data-ttu-id="281df-139">インク データの保存用にサポートされるファイル形式は GIF のみです。</span><span class="sxs-lookup"><span data-stu-id="281df-139">GIF is the only file format supported for saving ink data.</span></span> <span data-ttu-id="281df-140">ただし、[**LoadAsync**](https://msdn.microsoft.com/library/windows/apps/hh701607) メソッドでは、下位互換性のために次の形式もサポートされています。</span><span class="sxs-lookup"><span data-stu-id="281df-140">However, the [**LoadAsync**](https://msdn.microsoft.com/library/windows/apps/hh701607) method does support the following formats for backward compatibility.</span></span>

| <span data-ttu-id="281df-141">表記</span><span class="sxs-lookup"><span data-stu-id="281df-141">Format</span></span>                    | <span data-ttu-id="281df-142">説明</span><span class="sxs-lookup"><span data-stu-id="281df-142">Description</span></span> |
|---------------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="281df-143">InkSerializedFormat</span><span class="sxs-lookup"><span data-stu-id="281df-143">InkSerializedFormat</span></span>       | <span data-ttu-id="281df-144">ISF で永続化されたインクを指定します。</span><span class="sxs-lookup"><span data-stu-id="281df-144">Specifies ink that is persisted using ISF.</span></span> <span data-ttu-id="281df-145">これは最もコンパクトなインクの永続表現です。</span><span class="sxs-lookup"><span data-stu-id="281df-145">This is the most compact persistent representation of ink.</span></span> <span data-ttu-id="281df-146">バイナリ ドキュメント形式への埋め込みまたはクリップボードへの直接配置を実行できます。</span><span class="sxs-lookup"><span data-stu-id="281df-146">It can be embedded within a binary document format or placed directly on the Clipboard.</span></span>                                                                                                                                                                                                         |
| <span data-ttu-id="281df-147">Base64InkSerializedFormat</span><span class="sxs-lookup"><span data-stu-id="281df-147">Base64InkSerializedFormat</span></span> | <span data-ttu-id="281df-148">base64 ストリームとして ISF をエンコードすることで永続化されたインクを指定します。</span><span class="sxs-lookup"><span data-stu-id="281df-148">Specifies ink that is persisted by encoding the ISF as a base64 stream.</span></span> <span data-ttu-id="281df-149">この形式を指定すると、インクを XML ファイルや HTML ファイルで直接エンコードできます。</span><span class="sxs-lookup"><span data-stu-id="281df-149">This format is provided so ink can be encoded directly in an XML or HTML file.</span></span>                                                                                                                                                                                                                                                |
| <span data-ttu-id="281df-150">Gif</span><span class="sxs-lookup"><span data-stu-id="281df-150">Gif</span></span>                       | <span data-ttu-id="281df-151">ファイル内に ISF がメタデータとして埋め込まれた GIF ファイルで永続化されたインクを指定します。</span><span class="sxs-lookup"><span data-stu-id="281df-151">Specifies ink that is persisted by using a GIF file that contains ISF as metadata embedded within the file.</span></span> <span data-ttu-id="281df-152">この形式では、インクに対応していないアプリケーションでインクを表示でき、インク対応のアプリケーションに返されたときもまったく同じように再現できます。</span><span class="sxs-lookup"><span data-stu-id="281df-152">This enables ink to be viewed in applications that are not ink-enabled and maintain its full ink fidelity when it returns to an ink-enabled application.</span></span> <span data-ttu-id="281df-153">この形式は、HTML ファイル内のインクのコンテンツを転送して、インク アプリとインク対応でないアプリで使えるようにする場合に適しています。</span><span class="sxs-lookup"><span data-stu-id="281df-153">This format is ideal when transporting ink content within an HTML file and for making it usable by ink and non-ink applications.</span></span> |
| <span data-ttu-id="281df-154">Base64Gif</span><span class="sxs-lookup"><span data-stu-id="281df-154">Base64Gif</span></span>                 | <span data-ttu-id="281df-155">base64 エンコードの拡張 GIF で永続化されたインクを指定します。</span><span class="sxs-lookup"><span data-stu-id="281df-155">Specifies ink that is persisted by using a base64-encoded fortified GIF.</span></span> <span data-ttu-id="281df-156">この形式は、後で画像に変換するために、インクを XML ファイルや HTML ファイルで直接エンコードする場合に指定します。</span><span class="sxs-lookup"><span data-stu-id="281df-156">This format is provided when ink is to be encoded directly in an XML or HTML file for later conversion into an image.</span></span> <span data-ttu-id="281df-157">すべてのインク情報を格納するために生成された XML 形式で、Extensible Stylesheet Language Transformations (XSLT) を介して HTML を生成するために使うことができます。</span><span class="sxs-lookup"><span data-stu-id="281df-157">A possible use of this is in an XML format generated to contain all ink information and used to generate HTML through Extensible Stylesheet Language Transformations (XSLT).</span></span> 

## <a name="copy-and-paste-ink-strokes-with-the-clipboard"></a><span data-ttu-id="281df-158">クリップボードを使ってインク ストロークのコピーと貼り付けを行う</span><span class="sxs-lookup"><span data-stu-id="281df-158">Copy and paste ink strokes with the clipboard</span></span>

<span data-ttu-id="281df-159">ここでは、クリップボードを使って、アプリ間でインク ストロークを転送する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="281df-159">Here, we demonstrate how to use the clipboard to transfer ink strokes between apps.</span></span>

<span data-ttu-id="281df-160">クリップボード機能をサポートするために、組み込みの [**InkStrokeContainer**](https://msdn.microsoft.com/library/windows/apps/br208492) の切り取り/コピー コマンドでは、1 つまたは複数のインク ストロークの選択が求められます。</span><span class="sxs-lookup"><span data-stu-id="281df-160">To support clipboard functionality, the built-in [**InkStrokeContainer**](https://msdn.microsoft.com/library/windows/apps/br208492) cut and copy commands require one or more ink strokes be selected.</span></span>

<span data-ttu-id="281df-161">次の例では、ペン バレル ボタン (またはマウスの右ボタン) で入力が変更された場合にストロークを選べるようにする手順を示しています。</span><span class="sxs-lookup"><span data-stu-id="281df-161">For this example, we enable stroke selection when input is modified with a pen barrel button (or right mouse button).</span></span> <span data-ttu-id="281df-162">ストローク選択の実装方法を示す詳しい例については、「[ペン操作とスタイラス操作](pen-and-stylus-interactions.md)」の「高度な処理のための入力のパススルー」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="281df-162">For a complete example of how to implement stroke selection, see Pass-through input for advanced processing in [Pen and stylus interactions](pen-and-stylus-interactions.md).</span></span>

<span data-ttu-id="281df-163">**このサンプルをからダウンロード[保存し、クリップボードからインク ストロークを読み込む](https://github.com/MicrosoftDocs/windows-topic-specific-samples/archive/uwp-ink-store-clipboard.zip)**</span><span class="sxs-lookup"><span data-stu-id="281df-163">**Download this sample from [Save and load ink strokes from the clipboard](https://github.com/MicrosoftDocs/windows-topic-specific-samples/archive/uwp-ink-store-clipboard.zip)**</span></span>

1.  <span data-ttu-id="281df-164">まず、UI を設定します。</span><span class="sxs-lookup"><span data-stu-id="281df-164">First, we set up the UI.</span></span>

    <span data-ttu-id="281df-165">UI には、[Cut]、[Copy]、[Paste]、[Clear] の各ボタン、[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535)、選択キャンバスが含まれています。</span><span class="sxs-lookup"><span data-stu-id="281df-165">The UI includes "Cut", "Copy", "Paste", and "Clear" buttons, along with the [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) and a selection canvas.</span></span>
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

2.  <span data-ttu-id="281df-166">次に、基本的なインク入力の動作をいくつか設定します。</span><span class="sxs-lookup"><span data-stu-id="281df-166">We then set some basic ink input behaviors.</span></span>

    <span data-ttu-id="281df-167">[  **InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) は、ペンとマウスのいずれからの入力データもインク ストローク ([**InputDeviceTypes**](https://msdn.microsoft.com/library/windows/apps/dn922019)) として解釈するように構成します。</span><span class="sxs-lookup"><span data-stu-id="281df-167">The [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) is configured to interpret input data from both pen and mouse as ink strokes ([**InputDeviceTypes**](https://msdn.microsoft.com/library/windows/apps/dn922019)).</span></span> <span data-ttu-id="281df-168">ここでは、ボタンのクリック イベント、選択機能のポインター イベントおよびストローク イベントに対するリスナーも宣言されています。</span><span class="sxs-lookup"><span data-stu-id="281df-168">Listeners for the click events on the buttons as well as pointer and stroke events for selection functionality are also declared here.</span></span>

    <span data-ttu-id="281df-169">ストローク選択の実装方法を示す詳しい例については、「[ペン操作とスタイラス操作](pen-and-stylus-interactions.md)」の「高度な処理のための入力のパススルー」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="281df-169">For a complete example of how to implement stroke selection, see Pass-through input for advanced processing in [Pen and stylus interactions](pen-and-stylus-interactions.md).</span></span>
```csharp
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

3.  <span data-ttu-id="281df-170">最後に、ストローク選択サポートを追加した後で、**[Cut]** ボタン、**[Copy]** ボタン、**[Paste]** ボタンのクリック イベント ハンドラーにクリップボード機能を実装します。</span><span class="sxs-lookup"><span data-stu-id="281df-170">Finally, after adding stroke selection support, we implement clipboard functionality in the click event handlers of the **Cut**, **Copy**, and **Paste** buttons.</span></span>

    <span data-ttu-id="281df-171">切り取りの場合は、まず [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn922011) の [**InkStrokeContainer**](https://msdn.microsoft.com/library/windows/apps/br208492) で [**CopySelectedToClipboard**](https://msdn.microsoft.com/library/windows/apps/br244232) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="281df-171">For cut, we first call [**CopySelectedToClipboard**](https://msdn.microsoft.com/library/windows/apps/br244232) on the [**InkStrokeContainer**](https://msdn.microsoft.com/library/windows/apps/br208492) of the [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn922011).</span></span>

    <span data-ttu-id="281df-172">次に [**DeleteSelected**](https://msdn.microsoft.com/library/windows/apps/br244233) を呼び出して、インク キャンバスからストロークを削除します。</span><span class="sxs-lookup"><span data-stu-id="281df-172">We then call [**DeleteSelected**](https://msdn.microsoft.com/library/windows/apps/br244233) to remove the strokes from the ink canvas.</span></span>

    <span data-ttu-id="281df-173">最後に、選択キャンバスからすべてのストローク選択を削除します。</span><span class="sxs-lookup"><span data-stu-id="281df-173">Finally, we delete all selection strokes from the selection canvas.</span></span>
    
```csharp
private void btnCut_Click(object sender, RoutedEventArgs e)
    {
        inkCanvas.InkPresenter.StrokeContainer.CopySelectedToClipboard();
        inkCanvas.InkPresenter.StrokeContainer.DeleteSelected();
        ClearSelection();
    }
```
```csharp
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

<span data-ttu-id="281df-174">コピーの場合は、[**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn922011) の [**InkStrokeContainer**](https://msdn.microsoft.com/library/windows/apps/br208492) で [**CopySelectedToClipboard**](https://msdn.microsoft.com/library/windows/apps/br244232) を呼び出すだけです。</span><span class="sxs-lookup"><span data-stu-id="281df-174">For copy, we simply call [**CopySelectedToClipboard**](https://msdn.microsoft.com/library/windows/apps/br244232) on the [**InkStrokeContainer**](https://msdn.microsoft.com/library/windows/apps/br208492) of the [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn922011).</span></span>


```csharp
private void btnCopy_Click(object sender, RoutedEventArgs e)
    {
        inkCanvas.InkPresenter.StrokeContainer.CopySelectedToClipboard();
    }
```

<span data-ttu-id="281df-175">貼り付けの場合は、クリップボードのコンテンツをインク キャンバスに貼り付けることができるように、[**CanPasteFromClipboard**](https://msdn.microsoft.com/library/windows/apps/br208495) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="281df-175">For paste, we call [**CanPasteFromClipboard**](https://msdn.microsoft.com/library/windows/apps/br208495) to ensure that the content on the clipboard can be pasted to the ink canvas.</span></span>

<span data-ttu-id="281df-176">その場合は、[**PasteFromClipboard**](https://msdn.microsoft.com/library/windows/apps/br208503) を呼び出して、クリップボード内のインク ストロークを [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn922011) の [**InkStrokeContainer**](https://msdn.microsoft.com/library/windows/apps/br208492) に挿入します。これにより、ストロークがインク キャンバスにレンダリングされます。</span><span class="sxs-lookup"><span data-stu-id="281df-176">If so, we call [**PasteFromClipboard**](https://msdn.microsoft.com/library/windows/apps/br208503) to insert the clipboard ink strokes into the [**InkStrokeContainer**](https://msdn.microsoft.com/library/windows/apps/br208492) of the [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn922011), which then renders the strokes to the ink canvas.</span></span>

```csharp
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

## <a name="related-articles"></a><span data-ttu-id="281df-177">関連記事</span><span class="sxs-lookup"><span data-stu-id="281df-177">Related articles</span></span>

* [<span data-ttu-id="281df-178">ペン操作とスタイラス操作</span><span class="sxs-lookup"><span data-stu-id="281df-178">Pen and stylus interactions</span></span>](pen-and-stylus-interactions.md)

<span data-ttu-id="281df-179">**トピックのサンプル**</span><span class="sxs-lookup"><span data-stu-id="281df-179">**Topic samples**</span></span>
* [<span data-ttu-id="281df-180">保存し、インク ストロークを形式 ISF (Ink Serialized) ファイルから読み込む</span><span class="sxs-lookup"><span data-stu-id="281df-180">Save and load ink strokes from an Ink Serialized Format (ISF) file</span></span>](https://github.com/MicrosoftDocs/windows-topic-specific-samples/archive/uwp-ink-store.zip)
* [<span data-ttu-id="281df-181">保存し、クリップボードからインク ストロークを読み込む</span><span class="sxs-lookup"><span data-stu-id="281df-181">Save and load ink strokes from the clipboard</span></span>](https://github.com/MicrosoftDocs/windows-topic-specific-samples/archive/uwp-ink-store-clipboard.zip)

<span data-ttu-id="281df-182">**その他のサンプル**</span><span class="sxs-lookup"><span data-stu-id="281df-182">**Other samples**</span></span>
* [<span data-ttu-id="281df-183">単純なインクのサンプル (C#/C++)</span><span class="sxs-lookup"><span data-stu-id="281df-183">Simple ink sample (C#/C++)</span></span>](https://go.microsoft.com/fwlink/p/?LinkID=620312)
* [<span data-ttu-id="281df-184">複雑なインクのサンプル (C++)</span><span class="sxs-lookup"><span data-stu-id="281df-184">Complex ink sample (C++)</span></span>](https://go.microsoft.com/fwlink/p/?LinkID=620314)
* [<span data-ttu-id="281df-185">インクのサンプル (JavaScript)</span><span class="sxs-lookup"><span data-stu-id="281df-185">Ink sample (JavaScript)</span></span>](https://go.microsoft.com/fwlink/p/?LinkID=620308)
* [<span data-ttu-id="281df-186">チュートリアルを開始します。UWP アプリでのインクをサポートします。</span><span class="sxs-lookup"><span data-stu-id="281df-186">Get Started Tutorial: Support ink in your UWP app</span></span>](https://aka.ms/appsample-ink)
* [<span data-ttu-id="281df-187">書籍のサンプルを色分け表示</span><span class="sxs-lookup"><span data-stu-id="281df-187">Coloring book sample</span></span>](https://aka.ms/cpubsample-coloringbook)
* [<span data-ttu-id="281df-188">ファミリのノートのサンプル</span><span class="sxs-lookup"><span data-stu-id="281df-188">Family notes sample</span></span>](https://aka.ms/cpubsample-familynotessample)



