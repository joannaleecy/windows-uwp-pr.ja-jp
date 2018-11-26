---
Description: UWP apps that support Windows Ink can serialize and deserialize ink strokes to an Ink Serialized Format (ISF) file. The ISF file is a GIF image with additional metadata for all ink stroke properties and behaviors. Apps that are not ink-enabled, can view the static GIF image, including alpha-channel background transparency.
title: Windows Ink ストローク データの保存と取得
ms.assetid: C96C9D2F-DB69-4883-9809-4A0DF7CEC506
label: Store and retrieve Windows Ink stroke data
template: detail.hbs
keywords: Windows Ink, Windows の手書き入力, DirectInk, InkPresenter, InkCanvas, ISF, Ink Serialized Format, ユーザー操作, 入力
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 1196b5dd11f006e42d43e15efd56b2be92f35c4b
ms.sourcegitcommit: 681c70f964210ab49ac5d06357ae96505bb78741
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/26/2018
ms.locfileid: "7719193"
---
# <a name="store-and-retrieve-windows-ink-stroke-data"></a><span data-ttu-id="c8d55-103">Windows Ink ストローク データの保存と取得</span><span class="sxs-lookup"><span data-stu-id="c8d55-103">Store and retrieve Windows Ink stroke data</span></span>


<span data-ttu-id="c8d55-104">Windows Ink をサポートしている UWP アプリでは、インク ストロークを Ink Serialized Format (ISF) ファイルにシリアル化および逆シリアル化することができます。</span><span class="sxs-lookup"><span data-stu-id="c8d55-104">UWP apps that support Windows Ink can serialize and deserialize ink strokes to an Ink Serialized Format (ISF) file.</span></span> <span data-ttu-id="c8d55-105">ISF ファイルは、すべてのインク ストロークのプロパティと動作に関する追加のメタデータを含む GIF 画像です。</span><span class="sxs-lookup"><span data-stu-id="c8d55-105">The ISF file is a GIF image with additional metadata for all ink stroke properties and behaviors.</span></span> <span data-ttu-id="c8d55-106">インク対応ではないアプリでは、アルファ チャンネルの背景色の透明度を含めて、静的な GIF 画像を表示できます。</span><span class="sxs-lookup"><span data-stu-id="c8d55-106">Apps that are not ink-enabled, can view the static GIF image, including alpha-channel background transparency.</span></span>

> [!NOTE]
> <span data-ttu-id="c8d55-107">ISF は、最もコンパクトなインクの永続表現です。</span><span class="sxs-lookup"><span data-stu-id="c8d55-107">ISF is the most compact persistent representation of ink.</span></span> <span data-ttu-id="c8d55-108">バイナリ ドキュメント形式 (GIF ファイルなど) に埋め込むことも、クリップボードに直接配置することもできます。</span><span class="sxs-lookup"><span data-stu-id="c8d55-108">It can be embedded within a binary document format, such as a GIF file, or placed directly on the Clipboard.</span></span>

> <span data-ttu-id="c8d55-109">**重要な API**: [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535)、[**Windows.UI.Input.Inking**](https://msdn.microsoft.com/library/windows/apps/br208524)</span><span class="sxs-lookup"><span data-stu-id="c8d55-109">**Important APIs**: [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535), [**Windows.UI.Input.Inking**](https://msdn.microsoft.com/library/windows/apps/br208524)</span></span>

## <a name="save-ink-strokes-to-a-file"></a><span data-ttu-id="c8d55-110">インク ストロークをファイルに保存する</span><span class="sxs-lookup"><span data-stu-id="c8d55-110">Save ink strokes to a file</span></span>

<span data-ttu-id="c8d55-111">ここでは、[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) コントロールに描画されたインク ストロークの保存方法を説明します。</span><span class="sxs-lookup"><span data-stu-id="c8d55-111">Here, we demonstrate how to save ink strokes drawn on an [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) control.</span></span>

**<span data-ttu-id="c8d55-112">このサンプルは、「[Save and load ink strokes from an Ink Serialized Format (ISF) file](https://github.com/MicrosoftDocs/windows-topic-specific-samples/archive/uwp-ink-store.zip)」(インク ストロークを Ink Serialized Format (ISF) ファイルに保存し、読み込む) でダウンロードしてください。</span><span class="sxs-lookup"><span data-stu-id="c8d55-112">Download this sample from [Save and load ink strokes from an Ink Serialized Format (ISF) file](https://github.com/MicrosoftDocs/windows-topic-specific-samples/archive/uwp-ink-store.zip)</span></span>**

1.  <span data-ttu-id="c8d55-113">まず、UI を設定します。</span><span class="sxs-lookup"><span data-stu-id="c8d55-113">First, we set up the UI.</span></span>

    <span data-ttu-id="c8d55-114">UI には [Save]、[Load]、[Clear] の各ボタンと、[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) が含まれています。</span><span class="sxs-lookup"><span data-stu-id="c8d55-114">The UI includes "Save", "Load", and "Clear" buttons, and the [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535).</span></span>
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

2.  <span data-ttu-id="c8d55-115">次に、基本的なインク入力の動作をいくつか設定します。</span><span class="sxs-lookup"><span data-stu-id="c8d55-115">We then set some basic ink input behaviors.</span></span>

    <span data-ttu-id="c8d55-116">[**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) は、ペンとマウスのいずれからの入力データもインク ストローク ([**InputDeviceTypes**](https://msdn.microsoft.com/library/windows/apps/dn922019)) として解釈するように構成します。各ボタンのイベントに対するリスナーも宣言します。</span><span class="sxs-lookup"><span data-stu-id="c8d55-116">The [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) is configured to interpret input data from both pen and mouse as ink strokes ([**InputDeviceTypes**](https://msdn.microsoft.com/library/windows/apps/dn922019)), and listeners for the click events on the buttons are declared.</span></span>
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

3.  <span data-ttu-id="c8d55-117">最後に、**[Save]** ボタンのクリック イベント ハンドラーで、インクを保存します。</span><span class="sxs-lookup"><span data-stu-id="c8d55-117">Finally, we save the ink in the click event handler of the **Save** button.</span></span>

    <span data-ttu-id="c8d55-118">[**FileSavePicker**](https://msdn.microsoft.com/library/windows/apps/br207871) を使用すると、インク データの保存先としてファイルと場所の両方をユーザーが選択できます。</span><span class="sxs-lookup"><span data-stu-id="c8d55-118">A [**FileSavePicker**](https://msdn.microsoft.com/library/windows/apps/br207871) lets the user select both the file and the location where the ink data is saved.</span></span>

    <span data-ttu-id="c8d55-119">ファイルが選択されたら、[**ReadWrite**](https://msdn.microsoft.com/library/windows/apps/br241635) に設定された [**IRandomAccessStream**](https://msdn.microsoft.com/library/windows/apps/br241731) ストリームを開きます。</span><span class="sxs-lookup"><span data-stu-id="c8d55-119">Once a file is selected, we open an [**IRandomAccessStream**](https://msdn.microsoft.com/library/windows/apps/br241731) stream set to [**ReadWrite**](https://msdn.microsoft.com/library/windows/apps/br241635).</span></span>

    <span data-ttu-id="c8d55-120">次に [**SaveAsync**](https://msdn.microsoft.com/library/windows/apps/br242114) を呼び出して、[**InkStrokeContainer**](https://msdn.microsoft.com/library/windows/apps/br208492) によって管理されているインク ストロークをストリームにシリアル化します。</span><span class="sxs-lookup"><span data-stu-id="c8d55-120">We then call [**SaveAsync**](https://msdn.microsoft.com/library/windows/apps/br242114) to serialize the ink strokes managed by the [**InkStrokeContainer**](https://msdn.microsoft.com/library/windows/apps/br208492) to the stream.</span></span>

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
> <span data-ttu-id="c8d55-121">インク データの保存用にサポートされるファイル形式は GIF のみです。</span><span class="sxs-lookup"><span data-stu-id="c8d55-121">GIF is the only file format supported for saving ink data.</span></span> <span data-ttu-id="c8d55-122">ただし、[**LoadAsync**](https://msdn.microsoft.com/library/windows/apps/hh701607) メソッド (次のセクションで説明します) では、下位互換性のためにその他の形式もサポートされています。</span><span class="sxs-lookup"><span data-stu-id="c8d55-122">However, the [**LoadAsync**](https://msdn.microsoft.com/library/windows/apps/hh701607) method (demonstrated in the next section) does support additional formats for backward compatibility.</span></span>

## <a name="load-ink-strokes-from-a-file"></a><span data-ttu-id="c8d55-123">インク ストロークをファイルから読み込む</span><span class="sxs-lookup"><span data-stu-id="c8d55-123">Load ink strokes from a file</span></span>

<span data-ttu-id="c8d55-124">ここでは、ファイルからインク ストロークを読み込んで [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) コントロールにレンダリングする方法を示します。</span><span class="sxs-lookup"><span data-stu-id="c8d55-124">Here, we demonstrate how to load ink strokes from a file and render them on an [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) control.</span></span>

**<span data-ttu-id="c8d55-125">このサンプルは、「[Save and load ink strokes from an Ink Serialized Format (ISF) file](https://github.com/MicrosoftDocs/windows-topic-specific-samples/archive/uwp-ink-store.zip)」(インク ストロークを Ink Serialized Format (ISF) ファイルに保存し、読み込む) でダウンロードしてください。</span><span class="sxs-lookup"><span data-stu-id="c8d55-125">Download this sample from [Save and load ink strokes from an Ink Serialized Format (ISF) file](https://github.com/MicrosoftDocs/windows-topic-specific-samples/archive/uwp-ink-store.zip)</span></span>**

1.  <span data-ttu-id="c8d55-126">まず、UI を設定します。</span><span class="sxs-lookup"><span data-stu-id="c8d55-126">First, we set up the UI.</span></span>

    <span data-ttu-id="c8d55-127">UI には [Save]、[Load]、[Clear] の各ボタンと、[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) が含まれています。</span><span class="sxs-lookup"><span data-stu-id="c8d55-127">The UI includes "Save", "Load", and "Clear" buttons, and the [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535).</span></span>
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

2.  <span data-ttu-id="c8d55-128">次に、基本的なインク入力の動作をいくつか設定します。</span><span class="sxs-lookup"><span data-stu-id="c8d55-128">We then set some basic ink input behaviors.</span></span>

    <span data-ttu-id="c8d55-129">[**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) は、ペンとマウスのいずれからの入力データもインク ストローク ([**InputDeviceTypes**](https://msdn.microsoft.com/library/windows/apps/dn922019)) として解釈するように構成します。各ボタンのイベントに対するリスナーも宣言します。</span><span class="sxs-lookup"><span data-stu-id="c8d55-129">The [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) is configured to interpret input data from both pen and mouse as ink strokes ([**InputDeviceTypes**](https://msdn.microsoft.com/library/windows/apps/dn922019)), and listeners for the click events on the buttons are declared.</span></span>
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

3.  <span data-ttu-id="c8d55-130">最後に、**[Load]** ボタンのクリック イベント ハンドラーで、インクを読み込みます。</span><span class="sxs-lookup"><span data-stu-id="c8d55-130">Finally, we load the ink in the click event handler of the **Load** button.</span></span>

    <span data-ttu-id="c8d55-131">[**FileOpenPicker**](https://msdn.microsoft.com/library/windows/apps/br207847) を使用すると、保存済みインク データを取得するためのファイルと場所の両方をユーザーが選択できます。</span><span class="sxs-lookup"><span data-stu-id="c8d55-131">A [**FileOpenPicker**](https://msdn.microsoft.com/library/windows/apps/br207847) lets the user select both the file and the location from where to retrieve the saved ink data.</span></span>

    <span data-ttu-id="c8d55-132">ファイルが選択されたら、[**Read**](https://msdn.microsoft.com/library/windows/apps/br241635) に設定された [**IRandomAccessStream**](https://msdn.microsoft.com/library/windows/apps/br241731) ストリームを開きます。</span><span class="sxs-lookup"><span data-stu-id="c8d55-132">Once a file is selected, we open an [**IRandomAccessStream**](https://msdn.microsoft.com/library/windows/apps/br241731) stream set to [**Read**](https://msdn.microsoft.com/library/windows/apps/br241635).</span></span>

    <span data-ttu-id="c8d55-133">次に [**LoadAsync**](https://msdn.microsoft.com/library/windows/apps/hh701607) を呼び出して、保存済みのインク ストロークの読み取りと逆シリアル化を行い、[**InkStrokeContainer**](https://msdn.microsoft.com/library/windows/apps/br208492) に読み込みます。</span><span class="sxs-lookup"><span data-stu-id="c8d55-133">We then call [**LoadAsync**](https://msdn.microsoft.com/library/windows/apps/hh701607) to read, de-serialize, and load the saved ink strokes into the [**InkStrokeContainer**](https://msdn.microsoft.com/library/windows/apps/br208492).</span></span> <span data-ttu-id="c8d55-134">ストロークを **InkStrokeContainer** に読み込むと、[**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) は直ちにストロークを [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) にレンダリングします。</span><span class="sxs-lookup"><span data-stu-id="c8d55-134">Loading the strokes into the **InkStrokeContainer** causes the [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) to immediately render them to the [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535).</span></span>

    > [!NOTE]
    > <span data-ttu-id="c8d55-135">新しいストロークが読み込まれる前には、InkStrokeContainer 内の既存のストロークがすべて消去されます。</span><span class="sxs-lookup"><span data-stu-id="c8d55-135">All existing strokes in the InkStrokeContainer are cleared before new strokes are loaded.</span></span>

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
> <span data-ttu-id="c8d55-136">インク データの保存用にサポートされるファイル形式は GIF のみです。</span><span class="sxs-lookup"><span data-stu-id="c8d55-136">GIF is the only file format supported for saving ink data.</span></span> <span data-ttu-id="c8d55-137">ただし、[**LoadAsync**](https://msdn.microsoft.com/library/windows/apps/hh701607) メソッドでは、下位互換性のために次の形式もサポートされています。</span><span class="sxs-lookup"><span data-stu-id="c8d55-137">However, the [**LoadAsync**](https://msdn.microsoft.com/library/windows/apps/hh701607) method does support the following formats for backward compatibility.</span></span>

| <span data-ttu-id="c8d55-138">形式</span><span class="sxs-lookup"><span data-stu-id="c8d55-138">Format</span></span>                    | <span data-ttu-id="c8d55-139">説明</span><span class="sxs-lookup"><span data-stu-id="c8d55-139">Description</span></span> |
|---------------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="c8d55-140">InkSerializedFormat</span><span class="sxs-lookup"><span data-stu-id="c8d55-140">InkSerializedFormat</span></span>       | <span data-ttu-id="c8d55-141">ISF で永続化されたインクを指定します。</span><span class="sxs-lookup"><span data-stu-id="c8d55-141">Specifies ink that is persisted using ISF.</span></span> <span data-ttu-id="c8d55-142">これは最もコンパクトなインクの永続表現です。</span><span class="sxs-lookup"><span data-stu-id="c8d55-142">This is the most compact persistent representation of ink.</span></span> <span data-ttu-id="c8d55-143">バイナリ ドキュメント形式への埋め込みまたはクリップボードへの直接配置を実行できます。</span><span class="sxs-lookup"><span data-stu-id="c8d55-143">It can be embedded within a binary document format or placed directly on the Clipboard.</span></span>                                                                                                                                                                                                         |
| <span data-ttu-id="c8d55-144">Base64InkSerializedFormat</span><span class="sxs-lookup"><span data-stu-id="c8d55-144">Base64InkSerializedFormat</span></span> | <span data-ttu-id="c8d55-145">base64 ストリームとして ISF をエンコードすることで永続化されたインクを指定します。</span><span class="sxs-lookup"><span data-stu-id="c8d55-145">Specifies ink that is persisted by encoding the ISF as a base64 stream.</span></span> <span data-ttu-id="c8d55-146">この形式を指定すると、インクを XML ファイルや HTML ファイルで直接エンコードできます。</span><span class="sxs-lookup"><span data-stu-id="c8d55-146">This format is provided so ink can be encoded directly in an XML or HTML file.</span></span>                                                                                                                                                                                                                                                |
| <span data-ttu-id="c8d55-147">Gif</span><span class="sxs-lookup"><span data-stu-id="c8d55-147">Gif</span></span>                       | <span data-ttu-id="c8d55-148">ファイル内に ISF がメタデータとして埋め込まれた GIF ファイルで永続化されたインクを指定します。</span><span class="sxs-lookup"><span data-stu-id="c8d55-148">Specifies ink that is persisted by using a GIF file that contains ISF as metadata embedded within the file.</span></span> <span data-ttu-id="c8d55-149">この形式では、インクに対応していないアプリケーションでインクを表示でき、インク対応のアプリケーションに返されたときもまったく同じように再現できます。</span><span class="sxs-lookup"><span data-stu-id="c8d55-149">This enables ink to be viewed in applications that are not ink-enabled and maintain its full ink fidelity when it returns to an ink-enabled application.</span></span> <span data-ttu-id="c8d55-150">この形式は、HTML ファイル内のインクのコンテンツを転送して、インク アプリとインク対応でないアプリで使えるようにする場合に適しています。</span><span class="sxs-lookup"><span data-stu-id="c8d55-150">This format is ideal when transporting ink content within an HTML file and for making it usable by ink and non-ink applications.</span></span> |
| <span data-ttu-id="c8d55-151">Base64Gif</span><span class="sxs-lookup"><span data-stu-id="c8d55-151">Base64Gif</span></span>                 | <span data-ttu-id="c8d55-152">base64 エンコードの拡張 GIF で永続化されたインクを指定します。</span><span class="sxs-lookup"><span data-stu-id="c8d55-152">Specifies ink that is persisted by using a base64-encoded fortified GIF.</span></span> <span data-ttu-id="c8d55-153">この形式は、後で画像に変換するために、インクを XML ファイルや HTML ファイルで直接エンコードする場合に指定します。</span><span class="sxs-lookup"><span data-stu-id="c8d55-153">This format is provided when ink is to be encoded directly in an XML or HTML file for later conversion into an image.</span></span> <span data-ttu-id="c8d55-154">すべてのインク情報を格納するために生成された XML 形式で、Extensible Stylesheet Language Transformations (XSLT) を介して HTML を生成するために使うことができます。</span><span class="sxs-lookup"><span data-stu-id="c8d55-154">A possible use of this is in an XML format generated to contain all ink information and used to generate HTML through Extensible Stylesheet Language Transformations (XSLT).</span></span> 

## <a name="copy-and-paste-ink-strokes-with-the-clipboard"></a><span data-ttu-id="c8d55-155">クリップボードを使ってインク ストロークのコピーと貼り付けを行う</span><span class="sxs-lookup"><span data-stu-id="c8d55-155">Copy and paste ink strokes with the clipboard</span></span>

<span data-ttu-id="c8d55-156">ここでは、クリップボードを使って、アプリ間でインク ストロークを転送する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="c8d55-156">Here, we demonstrate how to use the clipboard to transfer ink strokes between apps.</span></span>

<span data-ttu-id="c8d55-157">クリップボード機能をサポートするために、組み込みの [**InkStrokeContainer**](https://msdn.microsoft.com/library/windows/apps/br208492) の切り取り/コピー コマンドでは、1 つまたは複数のインク ストロークの選択が求められます。</span><span class="sxs-lookup"><span data-stu-id="c8d55-157">To support clipboard functionality, the built-in [**InkStrokeContainer**](https://msdn.microsoft.com/library/windows/apps/br208492) cut and copy commands require one or more ink strokes be selected.</span></span>

<span data-ttu-id="c8d55-158">次の例では、ペン バレル ボタン (またはマウスの右ボタン) で入力が変更された場合にストロークを選べるようにする手順を示しています。</span><span class="sxs-lookup"><span data-stu-id="c8d55-158">For this example, we enable stroke selection when input is modified with a pen barrel button (or right mouse button).</span></span> <span data-ttu-id="c8d55-159">ストローク選択の実装方法を示す詳しい例については、「[ペン操作とスタイラス操作](pen-and-stylus-interactions.md)」の「高度な処理のための入力のパススルー」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c8d55-159">For a complete example of how to implement stroke selection, see Pass-through input for advanced processing in [Pen and stylus interactions](pen-and-stylus-interactions.md).</span></span>

**<span data-ttu-id="c8d55-160">このサンプルは、「[Save and load ink strokes from the clipboard](https://github.com/MicrosoftDocs/windows-topic-specific-samples/archive/uwp-ink-store-clipboard.zip)」(インク ストロークをクリップボードに保存し、読み込む) でダウンロードしてください。</span><span class="sxs-lookup"><span data-stu-id="c8d55-160">Download this sample from [Save and load ink strokes from the clipboard](https://github.com/MicrosoftDocs/windows-topic-specific-samples/archive/uwp-ink-store-clipboard.zip)</span></span>**

1.  <span data-ttu-id="c8d55-161">まず、UI を設定します。</span><span class="sxs-lookup"><span data-stu-id="c8d55-161">First, we set up the UI.</span></span>

    <span data-ttu-id="c8d55-162">UI には、[Cut]、[Copy]、[Paste]、[Clear] の各ボタン、[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535)、選択キャンバスが含まれています。</span><span class="sxs-lookup"><span data-stu-id="c8d55-162">The UI includes "Cut", "Copy", "Paste", and "Clear" buttons, along with the [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) and a selection canvas.</span></span>
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

2.  <span data-ttu-id="c8d55-163">次に、基本的なインク入力の動作をいくつか設定します。</span><span class="sxs-lookup"><span data-stu-id="c8d55-163">We then set some basic ink input behaviors.</span></span>

    <span data-ttu-id="c8d55-164">[**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) は、ペンとマウスのいずれからの入力データもインク ストローク ([**InputDeviceTypes**](https://msdn.microsoft.com/library/windows/apps/dn922019)) として解釈するように構成します。</span><span class="sxs-lookup"><span data-stu-id="c8d55-164">The [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) is configured to interpret input data from both pen and mouse as ink strokes ([**InputDeviceTypes**](https://msdn.microsoft.com/library/windows/apps/dn922019)).</span></span> <span data-ttu-id="c8d55-165">ここでは、ボタンのクリック イベント、選択機能のポインター イベントおよびストローク イベントに対するリスナーも宣言されています。</span><span class="sxs-lookup"><span data-stu-id="c8d55-165">Listeners for the click events on the buttons as well as pointer and stroke events for selection functionality are also declared here.</span></span>

    <span data-ttu-id="c8d55-166">ストローク選択の実装方法を示す詳しい例については、「[UWP アプリでのペン操作と Windows Ink](pen-and-stylus-interactions.md)」の「高度な処理のための入力のパススルー」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c8d55-166">For a complete example of how to implement stroke selection, see Pass-through input for advanced processing in [Pen and stylus interactions](pen-and-stylus-interactions.md).</span></span>
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

3.  <span data-ttu-id="c8d55-167">最後に、ストローク選択サポートを追加した後で、**[Cut]** ボタン、**[Copy]** ボタン、**[Paste]** ボタンのクリック イベント ハンドラーにクリップボード機能を実装します。</span><span class="sxs-lookup"><span data-stu-id="c8d55-167">Finally, after adding stroke selection support, we implement clipboard functionality in the click event handlers of the **Cut**, **Copy**, and **Paste** buttons.</span></span>

    <span data-ttu-id="c8d55-168">切り取りの場合は、まず [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn922011) の [**InkStrokeContainer**](https://msdn.microsoft.com/library/windows/apps/br208492) で [**CopySelectedToClipboard**](https://msdn.microsoft.com/library/windows/apps/br244232) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="c8d55-168">For cut, we first call [**CopySelectedToClipboard**](https://msdn.microsoft.com/library/windows/apps/br244232) on the [**InkStrokeContainer**](https://msdn.microsoft.com/library/windows/apps/br208492) of the [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn922011).</span></span>

    <span data-ttu-id="c8d55-169">次に [**DeleteSelected**](https://msdn.microsoft.com/library/windows/apps/br244233) を呼び出して、インク キャンバスからストロークを削除します。</span><span class="sxs-lookup"><span data-stu-id="c8d55-169">We then call [**DeleteSelected**](https://msdn.microsoft.com/library/windows/apps/br244233) to remove the strokes from the ink canvas.</span></span>

    <span data-ttu-id="c8d55-170">最後に、選択キャンバスからすべてのストローク選択を削除します。</span><span class="sxs-lookup"><span data-stu-id="c8d55-170">Finally, we delete all selection strokes from the selection canvas.</span></span>
    
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

<span data-ttu-id="c8d55-171">コピーの場合は、[**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn922011) の [**InkStrokeContainer**](https://msdn.microsoft.com/library/windows/apps/br208492) で [**CopySelectedToClipboard**](https://msdn.microsoft.com/library/windows/apps/br244232) を呼び出すだけです。</span><span class="sxs-lookup"><span data-stu-id="c8d55-171">For copy, we simply call [**CopySelectedToClipboard**](https://msdn.microsoft.com/library/windows/apps/br244232) on the [**InkStrokeContainer**](https://msdn.microsoft.com/library/windows/apps/br208492) of the [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn922011).</span></span>


```csharp
private void btnCopy_Click(object sender, RoutedEventArgs e)
    {
        inkCanvas.InkPresenter.StrokeContainer.CopySelectedToClipboard();
    }
```

<span data-ttu-id="c8d55-172">貼り付けの場合は、クリップボードのコンテンツをインク キャンバスに貼り付けることができるように、[**CanPasteFromClipboard**](https://msdn.microsoft.com/library/windows/apps/br208495) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="c8d55-172">For paste, we call [**CanPasteFromClipboard**](https://msdn.microsoft.com/library/windows/apps/br208495) to ensure that the content on the clipboard can be pasted to the ink canvas.</span></span>

<span data-ttu-id="c8d55-173">その場合は、[**PasteFromClipboard**](https://msdn.microsoft.com/library/windows/apps/br208503) を呼び出して、クリップボード内のインク ストロークを [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn922011) の [**InkStrokeContainer**](https://msdn.microsoft.com/library/windows/apps/br208492) に挿入します。これにより、ストロークがインク キャンバスにレンダリングされます。</span><span class="sxs-lookup"><span data-stu-id="c8d55-173">If so, we call [**PasteFromClipboard**](https://msdn.microsoft.com/library/windows/apps/br208503) to insert the clipboard ink strokes into the [**InkStrokeContainer**](https://msdn.microsoft.com/library/windows/apps/br208492) of the [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn922011), which then renders the strokes to the ink canvas.</span></span>

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

## <a name="related-articles"></a><span data-ttu-id="c8d55-174">関連記事</span><span class="sxs-lookup"><span data-stu-id="c8d55-174">Related articles</span></span>

* [<span data-ttu-id="c8d55-175">ペン操作とスタイラス操作</span><span class="sxs-lookup"><span data-stu-id="c8d55-175">Pen and stylus interactions</span></span>](pen-and-stylus-interactions.md)

**<span data-ttu-id="c8d55-176">トピックのサンプル</span><span class="sxs-lookup"><span data-stu-id="c8d55-176">Topic samples</span></span>**
* [<span data-ttu-id="c8d55-177">インク ストロークを Ink Serialized Format (ISF) ファイルに保存し、読み込む</span><span class="sxs-lookup"><span data-stu-id="c8d55-177">Save and load ink strokes from an Ink Serialized Format (ISF) file</span></span>](https://github.com/MicrosoftDocs/windows-topic-specific-samples/archive/uwp-ink-store.zip)
* [<span data-ttu-id="c8d55-178">インク ストロークをクリップボードに保存し、読み込む</span><span class="sxs-lookup"><span data-stu-id="c8d55-178">Save and load ink strokes from the clipboard</span></span>](https://github.com/MicrosoftDocs/windows-topic-specific-samples/archive/uwp-ink-store-clipboard.zip)

**<span data-ttu-id="c8d55-179">その他のサンプル</span><span class="sxs-lookup"><span data-stu-id="c8d55-179">Other samples</span></span>**
* [<span data-ttu-id="c8d55-180">単純なインクのサンプル (C#/C++)</span><span class="sxs-lookup"><span data-stu-id="c8d55-180">Simple ink sample (C#/C++)</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=620312)
* [<span data-ttu-id="c8d55-181">複雑なインクのサンプル (C++)</span><span class="sxs-lookup"><span data-stu-id="c8d55-181">Complex ink sample (C++)</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=620314)
* [<span data-ttu-id="c8d55-182">インクのサンプル (JavaScript)</span><span class="sxs-lookup"><span data-stu-id="c8d55-182">Ink sample (JavaScript)</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=620308)
* [<span data-ttu-id="c8d55-183">入門チュートリアル: UWP アプリでのインクのサポート</span><span class="sxs-lookup"><span data-stu-id="c8d55-183">Get Started Tutorial: Support ink in your UWP app</span></span>](https://aka.ms/appsample-ink)
* [<span data-ttu-id="c8d55-184">塗り絵帳のサンプル</span><span class="sxs-lookup"><span data-stu-id="c8d55-184">Coloring book sample</span></span>](https://aka.ms/cpubsample-coloringbook)
* [<span data-ttu-id="c8d55-185">Family Notes のサンプル</span><span class="sxs-lookup"><span data-stu-id="c8d55-185">Family notes sample</span></span>](https://aka.ms/cpubsample-familynotessample)



