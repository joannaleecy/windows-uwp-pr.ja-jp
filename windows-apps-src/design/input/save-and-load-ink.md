---
author: Karl-Bridge-Microsoft
Description: UWP apps that support Windows Ink can serialize and deserialize ink strokes to an Ink Serialized Format (ISF) file. The ISF file is a GIF image with additional metadata for all ink stroke properties and behaviors. Apps that are not ink-enabled, can view the static GIF image, including alpha-channel background transparency.
title: Windows Ink ストローク データの保存と取得
ms.assetid: C96C9D2F-DB69-4883-9809-4A0DF7CEC506
label: Store and retrieve Windows Ink stroke data
template: detail.hbs
keywords: Windows Ink, Windows の手書き入力, DirectInk, InkPresenter, InkCanvas, ISF, Ink Serialized Format, ユーザー操作, 入力
ms.author: kbridge
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 946e8421cf21c37c929e7a9f9687117c3d7aca92
ms.sourcegitcommit: 086001cffaf436e6e4324761d59bcc5e598c15ea
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5711249"
---
# <a name="store-and-retrieve-windows-ink-stroke-data"></a>Windows Ink ストローク データの保存と取得


Windows Ink をサポートしている UWP アプリでは、インク ストロークを Ink Serialized Format (ISF) ファイルにシリアル化および逆シリアル化することができます。 ISF ファイルは、すべてのインク ストロークのプロパティと動作に関する追加のメタデータを含む GIF 画像です。 インク対応ではないアプリでは、アルファ チャンネルの背景色の透明度を含めて、静的な GIF 画像を表示できます。

> [!NOTE]
> ISF は、最もコンパクトなインクの永続表現です。 バイナリ ドキュメント形式 (GIF ファイルなど) に埋め込むことも、クリップボードに直接配置することもできます。

> **重要な API**: [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535)、[**Windows.UI.Input.Inking**](https://msdn.microsoft.com/library/windows/apps/br208524)

## <a name="save-ink-strokes-to-a-file"></a>インク ストロークをファイルに保存する

ここでは、[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) コントロールに描画されたインク ストロークの保存方法を説明します。

**このサンプルは、「[Save and load ink strokes from an Ink Serialized Format (ISF) file](https://github.com/MicrosoftDocs/windows-topic-specific-samples/archive/uwp-ink-store.zip)」(インク ストロークを Ink Serialized Format (ISF) ファイルに保存し、読み込む) でダウンロードしてください。**

1.  まず、UI を設定します。

    UI には [Save]、[Load]、[Clear] の各ボタンと、[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) が含まれています。
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

2.  次に、基本的なインク入力の動作をいくつか設定します。

    [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) は、ペンとマウスのいずれからの入力データもインク ストローク ([**InputDeviceTypes**](https://msdn.microsoft.com/library/windows/apps/dn922019)) として解釈するように構成します。各ボタンのイベントに対するリスナーも宣言します。
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

3.  最後に、**[Save]** ボタンのクリック イベント ハンドラーで、インクを保存します。

    [**FileSavePicker**](https://msdn.microsoft.com/library/windows/apps/br207871) を使用すると、インク データの保存先としてファイルと場所の両方をユーザーが選択できます。

    ファイルが選択されたら、[**ReadWrite**](https://msdn.microsoft.com/library/windows/apps/br241635) に設定された [**IRandomAccessStream**](https://msdn.microsoft.com/library/windows/apps/br241731) ストリームを開きます。

    次に [**SaveAsync**](https://msdn.microsoft.com/library/windows/apps/br242114) を呼び出して、[**InkStrokeContainer**](https://msdn.microsoft.com/library/windows/apps/br208492) によって管理されているインク ストロークをストリームにシリアル化します。

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
> インク データの保存用にサポートされるファイル形式は GIF のみです。 ただし、[**LoadAsync**](https://msdn.microsoft.com/library/windows/apps/hh701607) メソッド (次のセクションで説明します) では、下位互換性のためにその他の形式もサポートされています。

## <a name="load-ink-strokes-from-a-file"></a>インク ストロークをファイルから読み込む

ここでは、ファイルからインク ストロークを読み込んで [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) コントロールにレンダリングする方法を示します。

**このサンプルは、「[Save and load ink strokes from an Ink Serialized Format (ISF) file](https://github.com/MicrosoftDocs/windows-topic-specific-samples/archive/uwp-ink-store.zip)」(インク ストロークを Ink Serialized Format (ISF) ファイルに保存し、読み込む) でダウンロードしてください。**

1.  まず、UI を設定します。

    UI には [Save]、[Load]、[Clear] の各ボタンと、[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) が含まれています。
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

2.  次に、基本的なインク入力の動作をいくつか設定します。

    [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) は、ペンとマウスのいずれからの入力データもインク ストローク ([**InputDeviceTypes**](https://msdn.microsoft.com/library/windows/apps/dn922019)) として解釈するように構成します。各ボタンのイベントに対するリスナーも宣言します。
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

3.  最後に、**[Load]** ボタンのクリック イベント ハンドラーで、インクを読み込みます。

    [**FileOpenPicker**](https://msdn.microsoft.com/library/windows/apps/br207847) を使用すると、保存済みインク データを取得するためのファイルと場所の両方をユーザーが選択できます。

    ファイルが選択されたら、[**Read**](https://msdn.microsoft.com/library/windows/apps/br241635) に設定された [**IRandomAccessStream**](https://msdn.microsoft.com/library/windows/apps/br241731) ストリームを開きます。

    次に [**LoadAsync**](https://msdn.microsoft.com/library/windows/apps/hh701607) を呼び出して、保存済みのインク ストロークの読み取りと逆シリアル化を行い、[**InkStrokeContainer**](https://msdn.microsoft.com/library/windows/apps/br208492) に読み込みます。 ストロークを **InkStrokeContainer** に読み込むと、[**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) は直ちにストロークを [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) にレンダリングします。

    > [!NOTE]
    > 新しいストロークが読み込まれる前には、InkStrokeContainer 内の既存のストロークがすべて消去されます。

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
> インク データの保存用にサポートされるファイル形式は GIF のみです。 ただし、[**LoadAsync**](https://msdn.microsoft.com/library/windows/apps/hh701607) メソッドでは、下位互換性のために次の形式もサポートされています。

| 形式                    | 説明 |
|---------------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| InkSerializedFormat       | ISF で永続化されたインクを指定します。 これは最もコンパクトなインクの永続表現です。 バイナリ ドキュメント形式への埋め込みまたはクリップボードへの直接配置を実行できます。                                                                                                                                                                                                         |
| Base64InkSerializedFormat | base64 ストリームとして ISF をエンコードすることで永続化されたインクを指定します。 この形式を指定すると、インクを XML ファイルや HTML ファイルで直接エンコードできます。                                                                                                                                                                                                                                                |
| Gif                       | ファイル内に ISF がメタデータとして埋め込まれた GIF ファイルで永続化されたインクを指定します。 この形式では、インクに対応していないアプリケーションでインクを表示でき、インク対応のアプリケーションに返されたときもまったく同じように再現できます。 この形式は、HTML ファイル内のインクのコンテンツを転送して、インク アプリとインク対応でないアプリで使えるようにする場合に適しています。 |
| Base64Gif                 | base64 エンコードの拡張 GIF で永続化されたインクを指定します。 この形式は、後で画像に変換するために、インクを XML ファイルや HTML ファイルで直接エンコードする場合に指定します。 すべてのインク情報を格納するために生成された XML 形式で、Extensible Stylesheet Language Transformations (XSLT) を介して HTML を生成するために使うことができます。 

## <a name="copy-and-paste-ink-strokes-with-the-clipboard"></a>クリップボードを使ってインク ストロークのコピーと貼り付けを行う

ここでは、クリップボードを使って、アプリ間でインク ストロークを転送する方法について説明します。

クリップボード機能をサポートするために、組み込みの [**InkStrokeContainer**](https://msdn.microsoft.com/library/windows/apps/br208492) の切り取り/コピー コマンドでは、1 つまたは複数のインク ストロークの選択が求められます。

次の例では、ペン バレル ボタン (またはマウスの右ボタン) で入力が変更された場合にストロークを選べるようにする手順を示しています。 ストローク選択の実装方法を示す詳しい例については、「[ペン操作とスタイラス操作](pen-and-stylus-interactions.md)」の「高度な処理のための入力のパススルー」をご覧ください。

**このサンプルは、「[Save and load ink strokes from the clipboard](https://github.com/MicrosoftDocs/windows-topic-specific-samples/archive/uwp-ink-store-clipboard.zip)」(インク ストロークをクリップボードに保存し、読み込む) でダウンロードしてください。**

1.  まず、UI を設定します。

    UI には、[Cut]、[Copy]、[Paste]、[Clear] の各ボタン、[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535)、選択キャンバスが含まれています。
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

2.  次に、基本的なインク入力の動作をいくつか設定します。

    [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) は、ペンとマウスのいずれからの入力データもインク ストローク ([**InputDeviceTypes**](https://msdn.microsoft.com/library/windows/apps/dn922019)) として解釈するように構成します。 ここでは、ボタンのクリック イベント、選択機能のポインター イベントおよびストローク イベントに対するリスナーも宣言されています。

    ストローク選択の実装方法を示す詳しい例については、「[UWP アプリでのペン操作と Windows Ink](pen-and-stylus-interactions.md)」の「高度な処理のための入力のパススルー」をご覧ください。
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

3.  最後に、ストローク選択サポートを追加した後で、**[Cut]** ボタン、**[Copy]** ボタン、**[Paste]** ボタンのクリック イベント ハンドラーにクリップボード機能を実装します。

    切り取りの場合は、まず [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn922011) の [**InkStrokeContainer**](https://msdn.microsoft.com/library/windows/apps/br208492) で [**CopySelectedToClipboard**](https://msdn.microsoft.com/library/windows/apps/br244232) を呼び出します。

    次に [**DeleteSelected**](https://msdn.microsoft.com/library/windows/apps/br244233) を呼び出して、インク キャンバスからストロークを削除します。

    最後に、選択キャンバスからすべてのストローク選択を削除します。
    
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

コピーの場合は、[**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn922011) の [**InkStrokeContainer**](https://msdn.microsoft.com/library/windows/apps/br208492) で [**CopySelectedToClipboard**](https://msdn.microsoft.com/library/windows/apps/br244232) を呼び出すだけです。


```csharp
private void btnCopy_Click(object sender, RoutedEventArgs e)
    {
        inkCanvas.InkPresenter.StrokeContainer.CopySelectedToClipboard();
    }
```

貼り付けの場合は、クリップボードのコンテンツをインク キャンバスに貼り付けることができるように、[**CanPasteFromClipboard**](https://msdn.microsoft.com/library/windows/apps/br208495) を呼び出します。

その場合は、[**PasteFromClipboard**](https://msdn.microsoft.com/library/windows/apps/br208503) を呼び出して、クリップボード内のインク ストロークを [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn922011) の [**InkStrokeContainer**](https://msdn.microsoft.com/library/windows/apps/br208492) に挿入します。これにより、ストロークがインク キャンバスにレンダリングされます。

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

## <a name="related-articles"></a>関連記事

* [ペン操作とスタイラス操作](pen-and-stylus-interactions.md)

**トピックのサンプル**
* [インク ストロークを Ink Serialized Format (ISF) ファイルに保存し、読み込む](https://github.com/MicrosoftDocs/windows-topic-specific-samples/archive/uwp-ink-store.zip)
* [インク ストロークをクリップボードに保存し、読み込む](https://github.com/MicrosoftDocs/windows-topic-specific-samples/archive/uwp-ink-store-clipboard.zip)

**その他のサンプル**
* [単純なインクのサンプル (C#/C++)](http://go.microsoft.com/fwlink/p/?LinkID=620312)
* [複雑なインクのサンプル (C++)](http://go.microsoft.com/fwlink/p/?LinkID=620314)
* [インクのサンプル (JavaScript)](http://go.microsoft.com/fwlink/p/?LinkID=620308)
* [入門チュートリアル: UWP アプリでのインクのサポート](https://aka.ms/appsample-ink)
* [塗り絵帳のサンプル](https://aka.ms/cpubsample-coloringbook)
* [Family Notes のサンプル](https://aka.ms/cpubsample-familynotessample)



