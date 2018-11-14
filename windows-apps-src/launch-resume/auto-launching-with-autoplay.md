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
ms.sourcegitcommit: 38f06f1714334273d865935d9afb80efffe97a17
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/09/2018
ms.locfileid: "6194733"
---
# <a name="span-iddevlaunchresumeauto-launchingwithautoplayspanauto-launching-with-autoplay"></a><span id="dev_launch_resume.auto-launching_with_autoplay"></span>自動再生による自動起動

**自動再生**を使って、コンピューターにデバイスが接続されたときのオプションとしてアプリを提供できます。 これには、カメラやメディア プレーヤーなどのボリューム デバイス以外のデバイス、または USB サム ドライブ、SD カード、DVD などのボリューム デバイスが含まれます。 また**自動再生**では、近接通信 (タップ) を使って 2 台の PC 間でユーザーがファイルを共有するときにアプリをオプションとして提供することもできます。

> **注:** デバイスの製造元がデバイスの**自動再生**ハンドラーとして、 [Microsoft Store デバイス アプリ](http://go.microsoft.com/fwlink/p/?LinkID=301381)を関連付ける場合は、デバイス メタデータでアプリを識別することができます。 詳しくは、「[Microsoft Store デバイス アプリの自動再生](http://go.microsoft.com/fwlink/p/?LinkId=306684)」をご覧ください。

## <a name="register-for-autoplay-content"></a>自動再生コンテンツに登録する

アプリを**自動再生**コンテンツ イベントのオプションとして登録できます。 **自動再生**コンテンツ イベントは、カメラのメモリ カード、サム ドライブ、DVD などのボリューム デバイスが PC に挿入されたときに発生します。 ここでは、カメラのボリューム デバイスが挿入されたときに**自動再生**オプションとしてアプリを識別する方法を示します。

このチュートリアルでは、画像ファイルを表示したり、ピクチャにそれらの画像をコピーしたりするアプリを作成しました。 自動再生 **ShowPicturesOnArrival** コンテンツ イベントにアプリを登録しました。

自動再生では、近接通信 (タップ) を使って PC 間で共有されるコンテンツのコンテンツ イベントも発生します。 このセクションで説明した手順とコードを使って、近接通信を使用する PC 間で共有されるファイルを処理できます。 次の表に、近接通信を使ってコンテンツを共有できる自動再生コンテンツ イベントを示します。

| アクション         | 自動再生コンテンツ イベント  |
|----------------|-------------------------|
| 音楽の共有  | PlayMusicFilesOnArrival |
| ビデオの共有 | PlayVideoFilesOnArrival |

 
ファイルが近接通信を使って共有されている場合、**FileActivatedEventArgs** オブジェクトの **Files** プロパティには、すべての共有ファイルを含むルート フォルダーへの参照が含まれます。

### <a name="step-1-create-a-new-project-and-add-autoplay-declarations"></a>手順 1: 新しいプロジェクトを作成し、自動再生宣言を追加する

1.  Microsoft Visual Studio を開き、**[ファイル]** メニューの **[新しいプロジェクト]** をクリックします。 **Visual C#** セクションの **[Windows]** で **[空白のアプリ (ユニバーサル Windows)]** を選びます。 アプリに **AutoPlayDisplayOrCopyImages** という名前を付け、**[OK]** をクリックします。
2.  [Package.appxmanifest] ファイルを開き、**[機能] ** タブを選択します。**[リムーバブル記憶域]** と **[ピクチャ ライブラリ]** 機能を選択します。 これで、アプリはカメラ メモリのリムーバブル ストレージ デバイスと、ローカルの画像にアクセスできるようになります。
3.  マニフェスト ファイルで **[宣言]** タブを選び、**[使用可能な宣言]** ドロップダウンから **[自動再生コンテンツ]** を選んで **[追加]** をクリックします。 **[サポートされる宣言]** ボックスの一覧に追加された新しい **[自動再生コンテンツ]** 項目を選びます。
4.  **[自動再生コンテンツ]** 宣言は、自動再生でコンテンツ イベントが発生したときに該当のアプリがオプションとして識別されます。 イベントは DVD やサム ドライブなどのボリューム デバイスのコンテンツに基づきます。 自動再生ではボリューム デバイスのコンテンツを調べて、発生させるコンテンツ イベントを決定します。 ボリュームのルートに DCIM、AVCHD、または PRIVATE\\ACHD フォルダーが含まれる場合、または自動再生コントロール パネルで **[各メディア タイプの処理方法を選択する]** を有効にしていてボリュームのルートで画像が見つかった場合、自動再生で **ShowPicturesOnArrival** イベントが発生します。 **[起動アクション]** セクションで、最初の起動アクションに対して下記の表 1 の値を入力します。
5.  **[自動再生コンテンツ]** 項目の **[起動アクション]** セクションで、**[新規追加]** をクリックし、2 つ目の起動アクションを追加します。 2 つ目の起動アクションについて、下記の表 2 の値を入力します。
6.  **[使用可能な宣言]** ドロップダウン リストで、**[ファイルの種類の関連付け]** を選び、**[追加]** をクリックします。 新しい **[ファイルの種類の関連付け]** 宣言の [プロパティ] で、**[表示名]** フィールドを **"自動再生コピー" または "画像を表示する"**、**[名前]** フィールドを **image\_association1** に設定します。 **[サポートされるファイルの種類]** セクションで、**[新規追加]** をクリックします。 **[ファイルの種類]** フィールドを **.jpg** に設定します。 **[サポートされるファイルの種類]** セクションで、新しいファイルの関連付けの **[ファイルの種類]** フィールドを **.png** に設定します。 コンテンツ イベントの場合は、自動再生で、アプリに明示的に関連付けられていないファイルの種類はすべて除外されます。
7.  マニフェスト ファイルを保存して閉じます。

**表 1**

| 設定             | 値                 |
|---------------------|-----------------------|
| 動詞                | show                  |
| アクションの表示名 | 画像を表示する         |
| コンテンツ イベント       | ShowPicturesOnArrival |

**[アクションの表示名]** 設定では、アプリの自動再生で表示される文字列を指定します。 **[動詞]** 設定では、選んだオプションでアプリに渡される値を指定します。 自動再生のイベントの起動アクションは複数指定できます。また、**[動詞]** 設定を使って、ユーザーがアプリで選んだアクションを確認できます。 アプリに渡される起動イベント引数の **verb** プロパティを調べることでユーザーが選んだオプションを確認できます。 **[動詞]** 設定には任意の値を使うことができます。ただし、予約されている **open** を除きます。

**表 2**  

| 設定             | 値                      |
|--------------------:|----------------------------|
| 動詞                | copy                       |
| アクションの表示名 | ライブラリに画像をコピーする |
| コンテンツ イベント       | ShowPicturesOnArrival      |

### <a name="step-2-add-xaml-ui"></a>手順 2: XAML UI を追加する

MainPage.xaml ファイルを開き、次の XAML を既定の &lt;Grid&gt; セクションに追加します。

```xml
<TextBlock FontSize="18">File List</TextBlock>
<TextBlock x:Name="FilesBlock" HorizontalAlignment="Left" TextWrapping="Wrap"
           VerticalAlignment="Top" Margin="0,20,0,0" Height="280" Width="240" />
<Canvas x:Name="FilesCanvas" HorizontalAlignment="Left" VerticalAlignment="Top"
        Margin="260,20,0,0" Height="280" Width="100"/>
```

### <a name="step-3-add-initialization-code"></a>手順 3: 初期化コードを追加する

この手順のコードでは、**Verb** プロパティの verb 値をチェックします。これは、**OnFileActivated** イベントの間にアプリに渡される起動引数の 1 つです。 次に、ユーザーが選んだオプションに関連するメソッドが呼び出されます。 カメラのメモリ イベントの場合、自動再生により、カメラ ストレージのルート フォルダーがアプリに渡されます。 このフォルダーは **Files** プロパティの最初の要素から取得できます。

App.xaml.cs ファイルを開いて、次のコードを **App** クラスに追加します。

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

> **注:**、`DisplayImages`と`CopyImages`メソッドは、次の手順で追加されます。

### <a name="step-4-add-code-to-display-images"></a>手順 4: 画像を表示するコードを追加する

MainPage.xaml.cs ファイルで、次のコードを **MainPage** クラスに追加します。

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

### <a name="step-5-add-code-to-copy-images"></a>手順 5: 画像をコピーするコードを追加する

MainPage.xaml.cs ファイルで、次のコードを **MainPage** クラスに追加します。

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

### <a name="step-6-build-and-run-the-app"></a>手順 6: アプリをビルドして実行する

1.  F5 キーを押して、アプリを (デバッグ モードで) ビルドおよび展開します。
2.  アプリを実行するには、カメラのメモリ カードまたはカメラの他のストレージ デバイスを PC に挿入します。 次に、自動再生のオプションの一覧から package.appxmanifest ファイルで指定したコンテンツ イベント オプションのいずれかを選びます。 このサンプル コードは、カメラのメモリ カードの DCIM フォルダーにある画像の表示またはコピーのみを行います。 カメラのメモリ カードの AVCHD または PRIVATE\\ACHD フォルダーに画像が格納される場合は、適宜コードを更新する必要があります。
    **注:** 場合は、ルートに**DCIM**をという名前のフォルダーがあり、画像が含まれている DCIM フォルダーのサブフォルダーがある場合に、フラッシュ ドライブを使用するカメラのメモリ カードがない場合。

## <a name="register-for-an-autoplay-device"></a>自動再生デバイスに登録する


アプリを**自動再生**デバイス イベントのオプションとして登録できます。 **自動再生**デバイス イベントは、デバイスがコンピューターに接続されると発生します。

ここでは、PC にカメラが接続されたときに**自動再生**オプションとしてアプリを識別する方法を示します。 アプリは、**WPD\\ImageSourceAutoPlay** イベントのハンドラーとして登録されます。 これは、カメラなどのイメージング デバイスが MTP を使う ImageSource であることを通知するときに Windows ポータブル デバイス (WPD) システムによって生成される一般的なイベントです。 詳しくは、「[Windows ポータブル デバイス](https://msdn.microsoft.com/library/windows/hardware/ff597729)」をご覧ください。

**重要な** [**Windows.Devices.Portable.StorageDevice**](https://msdn.microsoft.com/library/windows/apps/br225654) Api は、[デスクトップ デバイス ファミリ](https://msdn.microsoft.com/library/windows/apps/dn894631)の一部です。 アプリでは、Pc など、デスクトップ デバイス ファミリで windows 10 デバイスでのみこれらの Api を使用できます。

 

### <a name="step-1-create-a-new-project-and-add-autoplay-declarations"></a>手順 1: 新しいプロジェクトを作成し、自動再生宣言を追加する

1.  Visual Studio を開き、**[ファイル]** メニューの **[新しいプロジェクト]** をクリックします。 **Visual C#** セクションの **[Windows]** で **[空白のアプリ (ユニバーサル Windows)]** を選びます。 アプリに **AutoPlayDevice\_Camera** という名前を付け、**[OK]** をクリックします。
2.  [Package.appxmanifest] ファイルを開き、**[機能]** タブを選択します。**[リムーバブル記憶域]** 機能を選択します。 これで、アプリはリムーバブル記憶域ボリューム デバイスとしてカメラ上のデータにアクセスできるようになります。
3.  マニフェスト ファイルで **[宣言]** タブを選び、**[使用可能な宣言]** ドロップダウンから **[自動再生デバイス]** を選んで **[追加]** をクリックします。 **[サポートされる宣言]** ボックスの一覧に追加された新しい **[自動再生デバイス]** 項目を選びます。
4.  **[自動再生デバイス]** 宣言では、自動再生で既知のイベントのデバイス イベントが発生したときに該当のアプリがオプションとして識別されます。 **[起動アクション]** セクションで、最初の起動アクションに対して下記の表の値を入力します。
5.  **[使用可能な宣言]** ドロップダウン リストで、**[ファイルの種類の関連付け]** を選び、**[追加]** をクリックします。 新しい **[ファイルの種類の関連付け]** 宣言の [プロパティ] で、**[表示名]** フィールドを **"カメラの画像を表示する"**、**[名前]** フィールドを **camera\_association1** に設定します。 **[サポートされるファイルの種類]** セクションで、**[新規追加]** をクリックします (必要な場合)。 **[ファイルの種類]** フィールドを **.jpg** に設定します。 **[サポートされるファイルの種類]** セクションで、**[新規追加]** をもう一度クリックします。 新しいファイルの関連付けの **[ファイルの種類]** フィールドを **.png** に設定します。 コンテンツ イベントの場合は、自動再生で、アプリに明示的に関連付けられていないファイルの種類はすべて除外されます。
6.  マニフェスト ファイルを保存して閉じます。

| 設定             | 値            |
|---------------------|------------------|
| 動詞                | show             |
| アクションの表示名 | 画像を表示する    |
| コンテンツ イベント       | WPD\\ImageSource |

**[アクションの表示名]** 設定では、アプリの自動再生で表示される文字列を指定します。 **[動詞]** 設定では、選んだオプションでアプリに渡される値を指定します。 自動再生のイベントの起動アクションは複数指定できます。また、**[動詞]** 設定を使って、ユーザーがアプリで選んだアクションを確認できます。 アプリに渡される起動イベント引数の **verb** プロパティを調べることでユーザーが選んだオプションを確認できます。 **[動詞]** 設定には任意の値を使うことができます。ただし、予約されている **open** を除きます。 1 つのアプリで複数の動詞を使う例については、「[自動再生コンテンツに登録する](#register-for-autoplay-content)」をご覧ください。

### <a name="step-2-add-assembly-reference-for-the-desktop-extensions"></a>手順 2: デスクトップ拡張機能に対するアセンブリ参照を追加する

Windows ポータブル デバイス上の記憶域にアクセスするために必要な API である [**Windows.Devices.Portable.StorageDevice**](https://msdn.microsoft.com/library/windows/apps/br225654) は、デスクトップ [デスクトップ デバイス ファミリ](https://msdn.microsoft.com/library/windows/apps/dn894631) の一部です。 つまり、この API を使うには特別なアセンブリが必要であり、その呼び出しはデスクトップ デバイス ファミリ (PC など) でのみ機能します。

1.  **ソリューション エクスプローラー**で、**[参照設定]** を右クリックし、**[参照の追加]** をクリックします。
2.  **[ユニバーサル Windows]** を展開し、**[拡張機能]** をクリックします。
3.  **[Windows Desktop Extensions for the UWP]** を選び、**[OK]** をクリックします。

### <a name="step-3-add-xaml-ui"></a>手順 3: XAML UI を追加する

MainPage.xaml ファイルを開き、次の XAML を既定の &lt;Grid&gt; セクションに追加します。

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

### <a name="step-4-add-activation-code"></a>手順 4: アクティブ化コードを追加する

この手順のコードは、カメラのデバイス情報 ID を [**FromId**](https://msdn.microsoft.com/library/windows/apps/br225655) メソッドに渡すことによって、カメラを [**StorageDevice**](https://msdn.microsoft.com/library/windows/apps/br225654) として参照します。 カメラのデバイス情報 ID を取得するには、まずイベント引数を [**DeviceActivatedEventArgs**](https://msdn.microsoft.com/library/windows/apps/br224710) としてキャストし、次に [**DeviceInformationId**](https://msdn.microsoft.com/library/windows/apps/br224711) プロパティから値を取得します。

App.xaml.cs ファイルを開いて、次のコードを **App** クラスに追加します。

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

> **注:**、`ShowImages`メソッドは、次の手順で追加されます。

### <a name="step-5-add-code-to-display-device-information"></a>手順 5: デバイス情報を表示するコードを追加する

カメラに関する情報は、[**StorageDevice**](https://msdn.microsoft.com/library/windows/apps/br225654) クラスのプロパティから取得できます。 この手順のコードは、アプリの実行時にデバイス名などの情報をユーザーに表示します。 続いて、GetImageList メソッドと GetThumbnail メソッドを呼び出します。これらのメソッドは、カメラに格納されている画像のサムネイルを表示するために、次の手順で追加します。

MainPage.xaml.cs ファイルで、次のコードを **MainPage** クラスに追加します。

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

> **注:**、`GetImageList`と`GetThumbnail`メソッドは、次の手順で追加されます。

### <a name="step-6-add-code-to-display-images"></a>手順 6: 画像を表示するコードを追加する

この手順のコードは、カメラに格納されている画像のサムネイルを表示します。 このコードは、カメラの非同期呼び出しを行ってサムネイル イメージを取得します。 ただし、次の非同期呼び出しは、前の非同期呼び出しが完了するまで行われません。 これにより、カメラに対する要求が一度に 1 つだけ実行されるようになります。

MainPage.xaml.cs ファイルで、次のコードを **MainPage** クラスに追加します。

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

### <a name="step-7-build-and-run-the-app"></a>手順 7: アプリをビルドして実行する

1.  F5 キーを押して、アプリを (デバッグ モードで) ビルドおよび展開します。
2.  アプリを実行するには、コンピューターにカメラを接続します。 次に、自動再生オプションの一覧からアプリを選びます。
    **注:** **\\imagesource**自動再生デバイス イベントのすべてのカメラをアドバタイズします。

## <a name="configure-removable-storage"></a>リムーバブル記憶域を構成する

メモリ カードやサム ドライブなどのボリューム デバイスが PC に接続されたとき、そのボリューム デバイスを**自動再生**デバイスとして識別することができます。 これは、特定のアプリを**自動再生**に関連付けて、ボリューム デバイスのユーザーに提示する場合などに活用できます。

ここでは、**自動再生**デバイスとしてボリューム デバイスを識別する方法を示します。

ボリューム デバイスを**自動再生**デバイスとして識別するには、デバイスのルート ドライブに autorun.inf ファイルを追加します。 そして、autorun.inf ファイルの **AutoRun** セクションに **CustomEvent** キーを追加します。 PC にボリューム デバイスが接続されると、**自動再生**が autorun.inf ファイルを検索し、ボリュームをデバイスとして扱います。 **自動再生**は、**CustomEvent** キーに指定された名前を使って**自動再生**イベントを作成します。 それからアプリを作成し、その**自動再生**イベントのハンドラーとしてアプリを登録できます。 PC にデバイスが接続されると、**自動再生**が、ボリューム デバイスのハンドラーとしてアプリを表示します。 autorun.inf ファイルについて詳しくは、「[Autorun.inf エントリ](https://msdn.microsoft.com/library/windows/desktop/cc144200)」をご覧ください。

### <a name="step-1-create-an-autoruninf-file"></a>手順 1: autorun.inf ファイルを作成する

ボリューム デバイスのルート ドライブに autorun.inf という名前のファイルを追加します。 autorun.inf ファイルを開き、次のテキストを追加します。

``` syntax
[AutoRun]
CustomEvent=AutoPlayCustomEventQuickstart
```

### <a name="step-2-create-a-new-project-and-add-autoplay-declarations"></a>手順 2: 新しいプロジェクトを作成し、自動再生宣言を追加する

1.  Visual Studio を開き、**[ファイル]** メニューの **[新しいプロジェクト]** をクリックします。 **Visual C#** セクションの **[Windows]** で **[空白のアプリ (ユニバーサル Windows)]** を選びます。 アプリに **AutoPlayCustomEvent** という名前を付け、**[OK]** をクリックします。
2.  [Package.appxmanifest] ファイルを開き、**[機能]** タブを選択します。**[リムーバブル記憶域]** 機能を選択します。 これで、アプリはリムーバブル記憶域デバイス上のファイルとフォルダーにアクセスできるようになります。
3.  マニフェスト ファイルで **[宣言]** タブを選び、**[使用可能な宣言]** ドロップダウンから **[自動再生コンテンツ]** を選んで **[追加]** をクリックします。 **[サポートされる宣言]** ボックスの一覧に追加された新しい **[自動再生コンテンツ]** 項目を選びます。

    **注:** または、こともできますカスタム自動再生イベントに対して**自動再生デバイス**宣言を追加します。  
4.  **[自動再生コンテンツ]** イベント宣言の **[起動アクション]** セクションで、最初の起動アクションについて下記の表の値を入力します。
5.  **[使用可能な宣言]** ドロップダウン リストで、**[ファイルの種類の関連付け]** を選び、**[追加]** をクリックします。 新しい **[ファイルの種類の関連付け]** 宣言の [プロパティ] で、**[表示名]** フィールドを **".ms ファイルを表示する"**、**[名前]** フィールドを **ms\_association** に設定します。 **[サポートされるファイルの種類]** セクションで、**[新規追加]** をクリックします。 **[ファイルの種類]** フィールドを **.ms** に設定します。 コンテンツ イベントの場合は、自動再生で、アプリに明示的に関連付けられていないファイルの種類はすべて除外されます。
6.  マニフェスト ファイルを保存して閉じます。

| 設定             | 値                         |
|---------------------|-------------------------------|
| 動詞                | show                          |
| アクションの表示名 | ファイルを表示する                    |
| コンテンツ イベント       | AutoPlayCustomEventQuickstart |

**[コンテンツ イベント]** の値は、autorun.inf ファイルの **CustomEvent** キーに指定したテキストです。 **[アクションの表示名]** 設定では、アプリの自動再生で表示される文字列を指定します。 **[動詞]** 設定では、選んだオプションでアプリに渡される値を指定します。 自動再生のイベントの起動アクションは複数指定できます。また、**[動詞]** 設定を使って、ユーザーがアプリで選んだアクションを確認できます。 アプリに渡される起動イベント引数の **verb** プロパティを調べることでユーザーが選んだオプションを確認できます。 **[動詞]** 設定には任意の値を使うことができます。ただし、予約されている **open** を除きます。

### <a name="step-3-add-xaml-ui"></a>手順 3: XAML UI を追加する

MainPage.xaml ファイルを開き、次の XAML を既定の &lt;Grid&gt; セクションに追加します。

```xml
<StackPanel Orientation="Vertical">
    <TextBlock FontSize="28" Margin="10,0,800,0">Files</TextBlock>
    <TextBlock x:Name="FilesBlock" FontSize="22" Height="600" Margin="10,0,800,0" />
</StackPanel>
```

### <a name="step-4-add-activation-code"></a>手順 4: アクティブ化コードを追加する

この手順のコードは、ボリューム デバイスのルート ドライブにあるフォルダーを表示するメソッドを呼び出します。 自動再生コンテンツ イベントの場合、自動再生により、**OnFileActivated** イベント中にアプリに渡された起動引数でストレージ デバイスのルート フォルダーが渡されます。 このフォルダーは **Files** プロパティの最初の要素から取得できます。

App.xaml.cs ファイルを開いて、次のコードを **App** クラスに追加します。

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

> **注:**、`DisplayFiles`メソッドは、次の手順で追加されます。

 

### <a name="step-5-add-code-to-display-folders"></a>手順 5: フォルダーを表示するコードを追加する

MainPage.xaml.cs ファイルで、次のコードを **MainPage** クラスに追加します。

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

### <a name="step-6-build-and-run-the-qpp"></a>手順 6: アプリをビルドして実行する

1.  F5 キーを押して、アプリを (デバッグ モードで) ビルドおよび展開します。
2.  アプリを実行するには、メモリ カードまたは他のストレージ デバイスを PC に挿入します。 そして、自動再生ハンドラー オプションの一覧からアプリを選びます。

## <a name="autoplay-event-reference"></a>自動再生イベント リファレンス


**自動再生**システムを使うと、さまざまなデバイスやボリューム (ディスク) の到着イベントにアプリを登録できます。 **自動再生**コンテンツ イベントに登録するには、パッケージ マニフェストで **[リムーバブル記憶域]** 機能を有効にする必要があります。 次の表で、登録できるイベントと、それらのイベントが発生するタイミングについて説明します。

| シナリオ                                                           | イベント                              | 説明   |
|--------------------------------------------------------------------|------------------------------------|---------------|
| カメラで写真を使う                                           | **WPD\ImageSource**                | Windows ポータブル デバイスとして指定されているカメラに対して発生し、ImageSource 機能を提供します。 |
| オーディオ プレーヤーで音楽を使う                                     | **WPD\AudioSource**                | Windows ポータブル デバイスとして指定されているメディア プレーヤーに対して発生し、AudioSource 機能を提供します。 |
| ビデオ カメラでビデオを使う                                     | **WPD\VideoSource**                | Windows ポータブル デバイスとして指定されているビデオ カメラに対して発生し、VideoSource 機能を提供します。 |
| 接続されているフラッシュ ドライブまたは外部ハード ドライブにアクセスする              | **StorageOnArrival**               | ドライブまたはボリュームが PC 接続されると発生します。   ドライブまたはボリュームのディスクのルートに DCIM、AVCHD、または PRIVATE\ACHD フォルダーが含まれている場合、代わりに **ShowPicturesOnArrival** イベントが発生します。 |
| 大容量記憶装置 (レガシ) の写真を使う                            | **ShowPicturesOnArrival**          | ドライブまたはボリュームのディスクのルートに DCIM、AVCHD、または PRIVATE\ACHD フォルダーが含まれている場合に発生します。 自動再生コントロール パネルで **[各メディア タイプの処理方法を選択する]** を有効にしている場合は、自動再生によって PC に接続されているボリュームが調べられ、ディスク上のコンテンツの種類が確認されます。 画像が見つかると、**ShowPicturesOnArrival** が発生します。 |
| 近接共有 (タップして送信) で写真を受信する             | **ShowPicturesOnArrival**          | コンテンツを近接通信を使って送信 (タップして送信) すると、自動再生によって共有ファイルが調べられ、コンテンツの種類が確認されます。 画像が見つかった場合、**ShowPicturesOnArrival** が発生します。 |
| 大容量記憶装置 (レガシ) の音楽を使う                             | **PlayMusicFilesOnArrival**        | 自動再生コントロール パネルで **[各メディア タイプの処理方法を選択する]** を有効にしている場合は、自動再生によって PC に接続されているボリュームが調べられ、ディスク上のコンテンツの種類が確認されます。  音楽ファイルが見つかると、**PlayMusicFilesOnArrival** が発生します。 |
| 近接共有 (タップして送信) で音楽を受信する              | **PlayMusicFilesOnArrival**        | コンテンツを近接通信を使って送信 (タップして送信) すると、自動再生によって共有ファイルが調べられ、コンテンツの種類が確認されます。 音楽ファイルが見つかった場合、**PlayMusicFilesOnArrival** が発生します。 |
| 大容量記憶装置 (レガシ) のビデオを使う                            | **PlayVideoFilesOnArrival**        | 自動再生コントロール パネルで **[各メディア タイプの処理方法を選択する]** を有効にしている場合は、自動再生によって PC に接続されているボリュームが調べられ、ディスク上のコンテンツの種類が確認されます。 ビデオ ファイルが見つかると、**PlayVideoFilesOnArrival** が発生します。 |
| 近接共有 (タップして送信) でビデオを受信する             | **PlayVideoFilesOnArrival**        | コンテンツを近接通信を使って送信 (タップして送信) すると、自動再生によって共有ファイルが調べられ、コンテンツの種類が確認されます。 ビデオ ファイルが見つかった場合、**PlayVideoFilesOnArrival** が発生します。 |
| 接続先デバイスの混在したファイルのセットを処理する               | **MixedContentOnArrival**          | 自動再生コントロール パネルで **[各メディア タイプの処理方法を選択する]** を有効にしている場合は、自動再生によって PC に接続されているボリュームが調べられ、ディスク上のコンテンツの種類が確認されます。 特定のコンテンツの種類が見つかると (画像など)、**MixedContentOnArrival** が発生します。 |
| 近接共有 (タップして送信) で混在したファイルのセットを処理する | **MixedContentOnArrival**          | コンテンツを近接通信を使って送信 (タップして送信) すると、自動再生によって共有ファイルが調べられ、コンテンツの種類が確認されます。 特定のコンテンツの種類が見つかると (画像など)、**MixedContentOnArrival** が発生します。 |
| 光学式メディアのビデオを処理する                                    | **PlayDVDMovieOnArrival**<br />**PlayBluRayOnArrival**<br />**PlayVideoCDMovieOnArrival**<br />**PlaySuperVideoCDMovieOnArrival** | 光学式ドライブにディスクが挿入されると、自動再生はファイルを確認して、コンテンツの種類を決定します。 ビデオのファイルが見つかった場合は、光学ディスクの種類に対応するイベントが発生します。 |
| 光学式メディアの音楽を処理する                                    | **PlayCDAudioOnArrival**<br />**PlayDVDAudioOnArrival** | 光学式ドライブにディスクが挿入されると、自動再生はファイルを確認して、コンテンツの種類を決定します。 音楽のファイルが見つかった場合は、光学ディスクの種類に対応するイベントが発生します。 |
| エンハンス ディスクを再生する                                                | **PlayEnhancedCDOnArrival**<br />**PlayEnhancedDVDOnArrival** | 光学式ドライブにディスクが挿入されると、自動再生はファイルを確認して、コンテンツの種類を決定します。 エンハンス ディスクが見つかった場合は、光学ディスクの種類に対応するイベントが発生します。 |
| 書き込み可能な光学式ディスクを処理する                                     | **HandleCDBurningOnArrival** <br />**HandleDVDBurningOnArrival** <br />**HandleBDBurningOnArrival** | 光学式ドライブにディスクが挿入されると、自動再生はファイルを確認して、コンテンツの種類を決定します。 書き込み可能なディスクが見つかった場合は、光学ディスクの種類に対応するイベントが発生します。 |
| 他のデバイスまたはボリュームの接続を処理する                       | **UnknownContentOnArrival**        | 自動再生コンテンツ イベントのいずれとも一致しないコンテンツが見つかった場合にすべてのイベントで発生します。 このイベントを使うことはお勧めできません。 処理できる特定の自動再生イベントにのみアプリを登録する必要があります。 |

ボリュームの autorun.inf ファイルの **CustomEvent** エントリを使って、自動再生でカスタムの自動再生コンテンツ イベントが発生することを指定できます。 詳しくは、「[Autorun.inf エントリ](https://msdn.microsoft.com/library/windows/desktop/cc144200)」をご覧ください。

自動再生コンテンツまたは自動再生デバイスのイベント ハンドラーとしてアプリを登録するには、アプリの package.appxmanifest ファイルに拡張機能を追加します。 Visual Studio を使う場合は、**[宣言]** タブで **[自動再生コンテンツ]** または **[自動再生デバイス]** の宣言を追加します。アプリの package.appxmanifest ファイルを直接編集する場合は、パッケージ マニフェストに[**拡張機能**](https://msdn.microsoft.com/library/windows/apps/br211400) 要素を追加し、**カテゴリ** として **windows.autoPlayContent** または **windows.autoPlayDevice** を指定します。 たとえば、次のパッケージ マニフェストのエントリでは、**自動再生コンテンツ**拡張機能を追加して、アプリを **ShowPicturesOnArrival** イベントのハンドラーとして登録しています。

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

 

 
