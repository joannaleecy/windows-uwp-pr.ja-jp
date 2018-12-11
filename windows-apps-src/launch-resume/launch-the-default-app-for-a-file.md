---
title: ファイルに応じた既定のアプリの起動
description: ファイルに応じて既定のアプリを起動する方法について説明します。
ms.assetid: BB45FCAF-DF93-4C99-A8B5-59B799C7BD98
ms.date: 07/05/2018
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: f8e59ae5fb20ce8e1a900f7c1415a699715215e0
ms.sourcegitcommit: 49d58bc66c1c9f2a4f81473bcb25af79e2b1088d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8925024"
---
# <a name="launch-the-default-app-for-a-file"></a><span data-ttu-id="c0699-104">ファイルに応じた既定のアプリの起動</span><span class="sxs-lookup"><span data-stu-id="c0699-104">Launch the default app for a file</span></span>

**<span data-ttu-id="c0699-105">重要な API</span><span class="sxs-lookup"><span data-stu-id="c0699-105">Important APIs</span></span>**

-   [**<span data-ttu-id="c0699-106">Windows.System.Launcher.LaunchFileAsync</span><span class="sxs-lookup"><span data-stu-id="c0699-106">Windows.System.Launcher.LaunchFileAsync</span></span>**](https://msdn.microsoft.com/library/windows/apps/hh701461)

<span data-ttu-id="c0699-107">ファイルに応じて既定のアプリを起動する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="c0699-107">Learn how to launch the default app for a file.</span></span> <span data-ttu-id="c0699-108">多くのアプリでは、アプリ自体で処理できないファイルを操作する必要が生じる場合があります。</span><span class="sxs-lookup"><span data-stu-id="c0699-108">Many apps need to work with files that they can't handle themselves.</span></span> <span data-ttu-id="c0699-109">たとえば、さまざまな種類のファイルを受け取るメール アプリは、これらのファイルを既定のハンドラーで起動する手段を備えている必要があります。</span><span class="sxs-lookup"><span data-stu-id="c0699-109">For example, e-mail apps receive a variety of file types and need a way to launch these files in their default handlers.</span></span> <span data-ttu-id="c0699-110">以下の手順では、[**Windows.System.Launcher**](https://msdn.microsoft.com/library/windows/apps/br241801) API を使って、アプリがそれ自体で処理できないファイルの既定のハンドラーを起動する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="c0699-110">These steps show how to use the [**Windows.System.Launcher**](https://msdn.microsoft.com/library/windows/apps/br241801) API to launch the default handler for a file that your app can't handle itself.</span></span>

## <a name="get-the-file-object"></a><span data-ttu-id="c0699-111">ファイル オブジェクトを取得する</span><span class="sxs-lookup"><span data-stu-id="c0699-111">Get the file object</span></span>

<span data-ttu-id="c0699-112">最初にファイルの [**Windows.Storage.StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171) オブジェクトを取得します。</span><span class="sxs-lookup"><span data-stu-id="c0699-112">First, get a [**Windows.Storage.StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171) object for the file.</span></span>

<span data-ttu-id="c0699-113">ファイルがアプリのパッケージに含まれている場合は、[**Package.InstalledLocation**](https://msdn.microsoft.com/library/windows/apps/br224681) プロパティで [**Windows.Storage.StorageFolder**](https://msdn.microsoft.com/library/windows/apps/br227230) オブジェクトを取得し、[**Windows.Storage.StorageFolder.GetFileAsync**](https://msdn.microsoft.com/library/windows/apps/br227272) メソッドで [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171) オブジェクトを取得します。</span><span class="sxs-lookup"><span data-stu-id="c0699-113">If the file is included in the package for your app, you can use the [**Package.InstalledLocation**](https://msdn.microsoft.com/library/windows/apps/br224681) property to get a [**Windows.Storage.StorageFolder**](https://msdn.microsoft.com/library/windows/apps/br227230) object and the [**Windows.Storage.StorageFolder.GetFileAsync**](https://msdn.microsoft.com/library/windows/apps/br227272) method to get the [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171) object.</span></span>

<span data-ttu-id="c0699-114">ファイルが既知のフォルダー内にある場合には、[**Windows.Storage.KnownFolders**](https://msdn.microsoft.com/library/windows/apps/br227151) クラスのプロパティで [**StorageFolder**](https://msdn.microsoft.com/library/windows/apps/br227230) を取得し、[**GetFileAsync**](https://msdn.microsoft.com/library/windows/apps/br227272) メソッドで [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171) オブジェクトを取得します。</span><span class="sxs-lookup"><span data-stu-id="c0699-114">If the file is in a known folder, you can use the properties of the [**Windows.Storage.KnownFolders**](https://msdn.microsoft.com/library/windows/apps/br227151) class to get a [**StorageFolder**](https://msdn.microsoft.com/library/windows/apps/br227230) and the [**GetFileAsync**](https://msdn.microsoft.com/library/windows/apps/br227272) method to get the [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171) object.</span></span>

## <a name="launch-the-file"></a><span data-ttu-id="c0699-115">ファイルを起動する</span><span class="sxs-lookup"><span data-stu-id="c0699-115">Launch the file</span></span>

<span data-ttu-id="c0699-116">Windows には、ファイルの既定のハンドラーを起動するためのいくつかの異なるオプションが用意されています。</span><span class="sxs-lookup"><span data-stu-id="c0699-116">Windows provides several different options for launching the default handler for a file.</span></span> <span data-ttu-id="c0699-117">これらのオプションについて、次の表とセクションで説明します。</span><span class="sxs-lookup"><span data-stu-id="c0699-117">These options are described in this chart and in the sections that follow.</span></span>

| <span data-ttu-id="c0699-118">オプション</span><span class="sxs-lookup"><span data-stu-id="c0699-118">Option</span></span> | <span data-ttu-id="c0699-119">メソッド</span><span class="sxs-lookup"><span data-stu-id="c0699-119">Method</span></span> | <span data-ttu-id="c0699-120">説明</span><span class="sxs-lookup"><span data-stu-id="c0699-120">Description</span></span> |
|--------|--------|-------------|
| <span data-ttu-id="c0699-121">既定の起動</span><span class="sxs-lookup"><span data-stu-id="c0699-121">Default launch</span></span> | [**<span data-ttu-id="c0699-122">LaunchFileAsync(IStorageFile)</span><span class="sxs-lookup"><span data-stu-id="c0699-122">LaunchFileAsync(IStorageFile)</span></span>**](https://msdn.microsoft.com/library/windows/apps/hh701471) | <span data-ttu-id="c0699-123">指定されたファイルを既定のハンドラーで起動します。</span><span class="sxs-lookup"><span data-stu-id="c0699-123">Launch the specified file with the default handler.</span></span> |
| <span data-ttu-id="c0699-124">[プログラムから開く] を使った起動</span><span class="sxs-lookup"><span data-stu-id="c0699-124">Open With launch</span></span> | [**<span data-ttu-id="c0699-125">LaunchFileAsync(IStorageFile, LauncherOptions)</span><span class="sxs-lookup"><span data-stu-id="c0699-125">LaunchFileAsync(IStorageFile, LauncherOptions)</span></span>**](https://msdn.microsoft.com/library/windows/apps/hh701465) | <span data-ttu-id="c0699-126">指定されたファイルを [プログラムから開く] ダイアログでユーザーによって選択されたハンドラーを使って起動します。</span><span class="sxs-lookup"><span data-stu-id="c0699-126">Launch the specified file letting the user pick the handler through the Open With dialog.</span></span> |
| <span data-ttu-id="c0699-127">推奨されるアプリ フォールバックを使った起動</span><span class="sxs-lookup"><span data-stu-id="c0699-127">Launch with a recommended app fallback</span></span> | [**<span data-ttu-id="c0699-128">LaunchFileAsync(IStorageFile, LauncherOptions)</span><span class="sxs-lookup"><span data-stu-id="c0699-128">LaunchFileAsync(IStorageFile, LauncherOptions)</span></span>**](https://msdn.microsoft.com/library/windows/apps/hh701465) | <span data-ttu-id="c0699-129">指定されたファイルを既定のハンドラーで起動します。</span><span class="sxs-lookup"><span data-stu-id="c0699-129">Launch the specified file with the default handler.</span></span> <span data-ttu-id="c0699-130">ハンドラーがシステムにインストールされていない場合は、ストアにあるアプリをユーザーに勧めます。</span><span class="sxs-lookup"><span data-stu-id="c0699-130">If no handler is installed on the system, recommend an app in the store to the user.</span></span> |
| <span data-ttu-id="c0699-131">画面上に留まった適切なビューを使った起動</span><span class="sxs-lookup"><span data-stu-id="c0699-131">Launch with a desired remaining view</span></span> | <span data-ttu-id="c0699-132">[**LaunchFileAsync(IStorageFile, LauncherOptions)**](https://msdn.microsoft.com/library/windows/apps/hh701465) (Windows のみ)</span><span class="sxs-lookup"><span data-stu-id="c0699-132">[**LaunchFileAsync(IStorageFile, LauncherOptions)**](https://msdn.microsoft.com/library/windows/apps/hh701465) (Windows-only)</span></span> | <span data-ttu-id="c0699-133">指定されたファイルを既定のハンドラーで起動します。</span><span class="sxs-lookup"><span data-stu-id="c0699-133">Launch the specified file with the default handler.</span></span> <span data-ttu-id="c0699-134">起動後も画面上に留まるように指定し、特定のウィンドウ サイズを要求します。</span><span class="sxs-lookup"><span data-stu-id="c0699-134">Specify a preference to stay on screen after the launch and request a specific window size.</span></span> <span data-ttu-id="c0699-135">[**LauncherOptions.DesiredRemainingView**](https://msdn.microsoft.com/library/windows/apps/dn298314) はモバイル デバイス ファミリではサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="c0699-135">[**LauncherOptions.DesiredRemainingView**](https://msdn.microsoft.com/library/windows/apps/dn298314) isn't supported on the mobile device family.</span></span> |

### <a name="default-launch"></a><span data-ttu-id="c0699-136">既定の起動</span><span class="sxs-lookup"><span data-stu-id="c0699-136">Default launch</span></span>

<span data-ttu-id="c0699-137">既定のアプリを起動するには、[**Windows.System.Launcher.LaunchFileAsync(IStorageFile)**](https://msdn.microsoft.com/library/windows/apps/hh701471) メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="c0699-137">Call the [**Windows.System.Launcher.LaunchFileAsync(IStorageFile)**](https://msdn.microsoft.com/library/windows/apps/hh701471) method to launch the default app.</span></span> <span data-ttu-id="c0699-138">この例では [**Windows.Storage.StorageFolder.GetFileAsync**](https://msdn.microsoft.com/library/windows/apps/br227272) メソッドを使って、このアプリ パッケージに含まれる画像ファイル test.png を起動します。</span><span class="sxs-lookup"><span data-stu-id="c0699-138">This example uses the [**Windows.Storage.StorageFolder.GetFileAsync**](https://msdn.microsoft.com/library/windows/apps/br227272) method to launch an image file, test.png, that is included in the app package.</span></span>

```csharp
async void DefaultLaunch()
{
   // Path to the file in the app package to launch
   string imageFile = @"images\test.png";
   
   var file = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync(imageFile);
   
   if (file != null)
   {
      // Launch the retrieved file
      var success = await Windows.System.Launcher.LaunchFileAsync(file);

      if (success)
      {
         // File launched
      }
      else
      {
         // File launch failed
      }
   }
   else
   {
      // Could not find file
   }
}
```

```vb
async Sub DefaultLaunch()
   ' Path to the file in the app package to launch
   Dim imageFile = "images\test.png"
   Dim file = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync(imageFile)
   
   If file IsNot Nothing Then
      ' Launch the retrieved file
      Dim success = await Windows.System.Launcher.LaunchFileAsync(file)

      If success Then
         ' File launched
      Else
         ' File launch failed
      End If
   Else
      ' Could not find file
   End If
End Sub
```

```cppwinrt
Windows::Foundation::IAsyncAction MainPage::DefaultLaunch()
{
    auto installFolder{ Windows::ApplicationModel::Package::Current().InstalledLocation() };

    Windows::Storage::StorageFile file{ co_await installFolder.GetFileAsync(L"images\\test.png") };

    if (file)
    {
        // Launch the retrieved file
        bool success = co_await Windows::System::Launcher::LaunchFileAsync(file);
        if (success)
        {
            // File launched
        }
        else
        {
            // File launch failed
        }
    }
    else
    {
        // Could not find file
    }
}
```

```cpp
void MainPage::DefaultLaunch()
{
   auto installFolder = Windows::ApplicationModel::Package::Current->InstalledLocation;

   concurrency::task<Windows::Storage::StorageFile^getFileOperation(installFolder->GetFileAsync("images\\test.png"));
   getFileOperation.then([](Windows::Storage::StorageFile^ file)
   {
      if (file != nullptr)
      {
         // Launch the retrieved file
         concurrency::task<bool> launchFileOperation(Windows::System::Launcher::LaunchFileAsync(file));
         launchFileOperation.then([](bool success)
         {
            if (success)
            {
               // File launched
            }
            else
            {
               // File launch failed
            }
         });
      }
      else
      {
         // Could not find file
      }
   });
}
```

### <a name="open-with-launch"></a><span data-ttu-id="c0699-139">[プログラムから開く] を使った起動</span><span class="sxs-lookup"><span data-stu-id="c0699-139">Open With launch</span></span>

<span data-ttu-id="c0699-140">[**LauncherOptions.DisplayApplicationPicker**](https://msdn.microsoft.com/library/windows/apps/hh701438) を **true** に設定して [**Windows.System.Launcher.LaunchFileAsync(IStorageFile, LauncherOptions)**](https://msdn.microsoft.com/library/windows/apps/hh701465) メソッドを呼び出して、ユーザーが **[プログラムから開く]** ダイアログ ボックスで選んだアプリを起動します。</span><span class="sxs-lookup"><span data-stu-id="c0699-140">Call the [**Windows.System.Launcher.LaunchFileAsync(IStorageFile, LauncherOptions)**](https://msdn.microsoft.com/library/windows/apps/hh701465) method with [**LauncherOptions.DisplayApplicationPicker**](https://msdn.microsoft.com/library/windows/apps/hh701438) set to **true** to launch the app that the user selects from the **Open With** dialog box.</span></span>

<span data-ttu-id="c0699-141">ユーザーが特定のファイルに既定以外のアプリを選ぶ場合は、**[プログラムから開く]** ダイアログ ボックスを使うことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="c0699-141">We recommend that you use the **Open With** dialog box when the user may want to select an app other than the default for a particular file.</span></span> <span data-ttu-id="c0699-142">たとえば、アプリで画像ファイルを起動できる場合、既定のハンドラーは多くの場合ビューアー アプリです。</span><span class="sxs-lookup"><span data-stu-id="c0699-142">For example, if your app allows the user to launch an image file, the default handler will likely be a viewer app.</span></span> <span data-ttu-id="c0699-143">場合によっては、ユーザーが画像の表示ではなく編集を行うこともあります。</span><span class="sxs-lookup"><span data-stu-id="c0699-143">In some cases, the user may want to edit the image instead of viewing it.</span></span> <span data-ttu-id="c0699-144">**[プログラムから開く]** オプションを **AppBar** またはコンテキスト メニューで代替コマンドと共に使って、ユーザーが **[プログラムから開く]** ダイアログを開き、このようなシナリオでエディター アプリを選択できるようにします。</span><span class="sxs-lookup"><span data-stu-id="c0699-144">Use the **Open With** option along with an alternative command in the **AppBar** or in a context menu to let the user bring up the **Open With** dialog and select the editor app in these types of scenarios.</span></span>

![.png ファイルの起動のための [プログラムから開く] ダイアログ。](images/checkboxopenwithdialog.png)

```csharp
async void DefaultLaunch()
{
   // Path to the file in the app package to launch
      string imageFile = @"images\test.png";
      
   var file = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync(imageFile);

   if (file != null)
   {
      // Set the option to show the picker
      var options = new Windows.System.LauncherOptions();
      options.DisplayApplicationPicker = true;

      // Launch the retrieved file
      bool success = await Windows.System.Launcher.LaunchFileAsync(file, options);
      if (success)
      {
         // File launched
      }
      else
      {
         // File launch failed
      }
   }
   else
   {
      // Could not find file
   }
}
```

```vb
async Sub DefaultLaunch()

   ' Path to the file in the app package to launch
   Dim imageFile = "images\test.png"

   Dim file = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync(imageFile)

   If file IsNot Nothing Then
      ' Set the option to show the picker
      Dim options = Windows.System.LauncherOptions()
      options.DisplayApplicationPicker = True

      ' Launch the retrieved file
      Dim success = await Windows.System.Launcher.LaunchFileAsync(file)

      If success Then
         ' File launched
      Else
         ' File launch failed
      End If
   Else
      ' Could not find file
   End If
End Sub
```

```cppwinrt
Windows::Foundation::IAsyncAction MainPage::DefaultLaunch()
{
    auto installFolder{ Windows::ApplicationModel::Package::Current().InstalledLocation() };

    Windows::Storage::StorageFile file{ co_await installFolder.GetFileAsync(L"images\\test.png") };

    if (file)
    {
        // Set the option to show the picker
        Windows::System::LauncherOptions launchOptions;
        launchOptions.DisplayApplicationPicker(true);

        // Launch the retrieved file
        bool success = co_await Windows::System::Launcher::LaunchFileAsync(file, launchOptions);
        if (success)
        {
            // File launched
        }
        else
        {
            // File launch failed
        }
    }
    else
    {
        // Could not find file
    }
}
```

```cpp
void MainPage::DefaultLaunch()
{
   auto installFolder = Windows::ApplicationModel::Package::Current->InstalledLocation;

   concurrency::task<Windows::Storage::StorageFile^> getFileOperation(installFolder->GetFileAsync("images\\test.png"));
   getFileOperation.then([](Windows::Storage::StorageFile^ file)
   {
      if (file != nullptr)
      {
         // Set the option to show the picker
         auto launchOptions = ref new Windows::System::LauncherOptions();
         launchOptions->DisplayApplicationPicker = true;

         // Launch the retrieved file
         concurrency::task<bool> launchFileOperation(Windows::System::Launcher::LaunchFileAsync(file, launchOptions));
         launchFileOperation.then([](bool success)
         {
            if (success)
            {
               // File launched
            }
            else
            {
               // File launch failed
            }
         });
      }
      else
      {
         // Could not find file
      }
   });
}
```

**<span data-ttu-id="c0699-148">推奨されるアプリ フォールバックを使った起動</span><span class="sxs-lookup"><span data-stu-id="c0699-148">Launch with a recommended app fallback</span></span>**

<span data-ttu-id="c0699-149">場合によっては、起動中のファイルを処理するためのアプリがインストールされていないこともあります。</span><span class="sxs-lookup"><span data-stu-id="c0699-149">In some cases the user may not have an app installed to handle the file that you are launching.</span></span> <span data-ttu-id="c0699-150">既定では、Windows はストア上の適切なアプリを検索するリンクを表示して、これらのケースに対処します。</span><span class="sxs-lookup"><span data-stu-id="c0699-150">By default, Windows will handle these cases by providing the user with a link to search for an appropriate app on the store.</span></span> <span data-ttu-id="c0699-151">このシナリオで入手するアプリに関する特定の推奨事項を示す場合は、起動中のファイルと共に推奨事項を渡すことができます。</span><span class="sxs-lookup"><span data-stu-id="c0699-151">If you would like to give the user a specific recommendation for which app to acquire in this scenario, you may do so by passing that recommendation along with the file that you are launching.</span></span> <span data-ttu-id="c0699-152">そのためには、[**LauncherOptions.PreferredApplicationPackageFamilyName**](https://msdn.microsoft.com/library/windows/apps/hh965482) を推奨するストア内のアプリのパッケージのファミリ名に設定して、[**Windows.System.Launcher.launchFileAsync(IStorageFile, LauncherOptions)**](https://msdn.microsoft.com/library/windows/apps/hh701465) メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="c0699-152">To do this, call the [**Windows.System.Launcher.launchFileAsync(IStorageFile, LauncherOptions)**](https://msdn.microsoft.com/library/windows/apps/hh701465) method with [**LauncherOptions.PreferredApplicationPackageFamilyName**](https://msdn.microsoft.com/library/windows/apps/hh965482) set to the package family name of the app in the Store that you want to recommend.</span></span> <span data-ttu-id="c0699-153">その後、[**LauncherOptions.PreferredApplicationDisplayName**](https://msdn.microsoft.com/library/windows/apps/hh965481) をそのアプリの名前に設定します。</span><span class="sxs-lookup"><span data-stu-id="c0699-153">Then, set the [**LauncherOptions.PreferredApplicationDisplayName**](https://msdn.microsoft.com/library/windows/apps/hh965481) to the name of that app.</span></span> <span data-ttu-id="c0699-154">Windows ではこの情報を使って、ストア内のアプリを検索する一般的なオプションを、ストアから推奨アプリを入手する固有のオプションに置き換えます。</span><span class="sxs-lookup"><span data-stu-id="c0699-154">Windows will use this information to replace the general option to search for an app in the store with a specific option to acquire the recommended app from the Store.</span></span>

> [!NOTE]
> <span data-ttu-id="c0699-155">どちらのアプリを推奨するオプションを設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c0699-155">You must set both of these options to recommend an app.</span></span> <span data-ttu-id="c0699-156">どちらか一方のみを設定した場合は、エラーになります。</span><span class="sxs-lookup"><span data-stu-id="c0699-156">Setting one without the other will result in a failure.</span></span>

![.contoso ファイルの起動のための [プログラムから開く] ダイアログ。](images/howdoyouwanttoopen.png)

```csharp
async void DefaultLaunch()
{
   // Path to the file in the app package to launch
   string imageFile = @"images\test.contoso";

   // Get the image file from the package's image directory
   var file = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync(imageFile);

   if (file != null)
   {
      // Set the recommended app
      var options = new Windows.System.LauncherOptions();
      options.PreferredApplicationPackageFamilyName = "Contoso.FileApp_8wknc82po1e";
      options.PreferredApplicationDisplayName = "Contoso File App";

      // Launch the retrieved file pass in the recommended app
      // in case the user has no apps installed to handle the file
      bool success = await Windows.System.Launcher.LaunchFileAsync(file, options);
      if (success)
      {
         // File launched
      }
      else
      {
         // File launch failed
      }
   }
   else
   {
      // Could not find file
   }
}
```

```vb
async Sub DefaultLaunch()

   ' Path to the file in the app package to launch
   Dim imageFile = "images\test.contoso"

   ' Get the image file from the package's image directory
   Dim file = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync(imageFile)

   If file IsNot Nothing Then
      ' Set the recommended app
      Dim options = Windows.System.LauncherOptions()
      options.PreferredApplicationPackageFamilyName = "Contoso.FileApp_8wknc82po1e";
      options.PreferredApplicationDisplayName = "Contoso File App";

      ' Launch the retrieved file pass in the recommended app
      ' in case the user has no apps installed to handle the file
      Dim success = await Windows.System.Launcher.LaunchFileAsync(file)

      If success Then
         ' File launched
      Else
         ' File launch failed
      End If
   Else
      ' Could not find file
   End If
End Sub
```

```cppwinrt
Windows::Foundation::IAsyncAction MainPage::DefaultLaunch()
{
    auto installFolder{ Windows::ApplicationModel::Package::Current().InstalledLocation() };

    Windows::Storage::StorageFile file{ co_await installFolder.GetFileAsync(L"images\\test.png") };

    if (file)
    {
        // Set the recommended app
        Windows::System::LauncherOptions launchOptions;
        launchOptions.PreferredApplicationPackageFamilyName(L"Contoso.FileApp_8wknc82po1e");
        launchOptions.PreferredApplicationDisplayName(L"Contoso File App");

        // Launch the retrieved file, and pass in the recommended app
        // in case the user has no apps installed to handle the file.
        bool success = co_await Windows::System::Launcher::LaunchFileAsync(file, launchOptions);
        if (success)
        {
            // File launched
        }
        else
        {
            // File launch failed
        }
    }
    else
    {
        // Could not find file
    }
}
```

```cpp
void MainPage::DefaultLaunch()
{
   auto installFolder = Windows::ApplicationModel::Package::Current->InstalledLocation;

   concurrency::task<Windows::Storage::StorageFile^> getFileOperation(installFolder->GetFileAsync("images\\test.contoso"));
   getFileOperation.then([](Windows::Storage::StorageFile^ file)
   {
      if (file != nullptr)
      {
         // Set the recommended app
         auto launchOptions = ref new Windows::System::LauncherOptions();
         launchOptions->PreferredApplicationPackageFamilyName = "Contoso.FileApp_8wknc82po1e";
         launchOptions->PreferredApplicationDisplayName = "Contoso File App";
         
         // Launch the retrieved file pass, and in the recommended app
         // in case the user has no apps installed to handle the file.
         concurrency::task<bool> launchFileOperation(Windows::System::Launcher::LaunchFileAsync(file, launchOptions));
         launchFileOperation.then([](bool success)
         {
            if (success)
            {
               // File launched
            }
            else
            {
               // File launch failed
            }
         });
      }
      else
      {
         // Could not find file
      }
   });
}
```

### <a name="launch-with-a-desired-remaining-view-windows-only"></a><span data-ttu-id="c0699-160">画面上に留まった適切なビューを使った起動 (Windows のみ)</span><span class="sxs-lookup"><span data-stu-id="c0699-160">Launch with a Desired Remaining View (Windows-only)</span></span>

<span data-ttu-id="c0699-161">[**LaunchFileAsync**](https://msdn.microsoft.com/library/windows/apps/hh701461) を呼び出すソース アプリは、ファイルの起動後も画面上に留まることを要求できます。</span><span class="sxs-lookup"><span data-stu-id="c0699-161">Source apps that call [**LaunchFileAsync**](https://msdn.microsoft.com/library/windows/apps/hh701461) can request that they remain on screen after a file launch.</span></span> <span data-ttu-id="c0699-162">既定では、利用可能なスペース全体がソース アプリとファイルを処理するターゲット アプリとで均等に共有されます。</span><span class="sxs-lookup"><span data-stu-id="c0699-162">By default, Windows attempts to share all available space equally between the source app and the target app that handles the file.</span></span> <span data-ttu-id="c0699-163">ソース アプリでは、[**DesiredRemainingView**](https://msdn.microsoft.com/library/windows/apps/dn298314) プロパティを使って、利用可能なスペースをソース アプリのウィンドウがどの程度占めるかをオペレーティング システムに指示できます。</span><span class="sxs-lookup"><span data-stu-id="c0699-163">Source apps can use the [**DesiredRemainingView**](https://msdn.microsoft.com/library/windows/apps/dn298314) property to indicate to the operating system that they prefer their app window to take up more or less of the available space.</span></span> <span data-ttu-id="c0699-164">
              この \*\*DesiredRemainingView\*\* では、ファイルの起動後にソース アプリが画面上に留まる必要がなく、ターゲット アプリに完全に置き換わってもよいことも示せます。</span><span class="sxs-lookup"><span data-stu-id="c0699-164">**DesiredRemainingView** can also be used to indicate that the source app does not need to remain on screen after the file launch and can be completely replaced by the target app.</span></span> <span data-ttu-id="c0699-165">このプロパティは呼び出し元アプリの優先ウィンドウのサイズだけを指定します。</span><span class="sxs-lookup"><span data-stu-id="c0699-165">This property only specifies the preferred window size of the calling app.</span></span> <span data-ttu-id="c0699-166">画面に同時に表示されている可能性のある他のアプリの動作は指定しません。</span><span class="sxs-lookup"><span data-stu-id="c0699-166">It doesn't specify the behavior of other apps that may happen to also be on screen at the same time.</span></span>

> [!NOTE]
> <span data-ttu-id="c0699-167">Windows では、複数の異なる要素など、ソース アプリの最終的なウィンドウのサイズを決定する場合、ソース アプリの基本設定、画面、画面の向き、上のアプリの数が考慮されます。</span><span class="sxs-lookup"><span data-stu-id="c0699-167">Windows takes into account multiple different factors when it determines the source app's final window size, for example, the preference of the source app, the number of apps on screen, the screen orientation, and so on.</span></span> <span data-ttu-id="c0699-168">[**DesiredRemainingView**](https://msdn.microsoft.com/library/windows/apps/dn298314) を設定しても、ソース アプリの特定のウィンドウ動作が保証されるわけではありません。</span><span class="sxs-lookup"><span data-stu-id="c0699-168">By setting [**DesiredRemainingView**](https://msdn.microsoft.com/library/windows/apps/dn298314), you aren't guaranteed a specific windowing behavior for the source app.</span></span>

<span data-ttu-id="c0699-169">**モバイル デバイス ファミリ:**[**LauncherOptions.DesiredRemainingView**](https://msdn.microsoft.com/library/windows/apps/dn298314)は、モバイル デバイス ファミリでサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="c0699-169">**Mobile device family:**[**LauncherOptions.DesiredRemainingView**](https://msdn.microsoft.com/library/windows/apps/dn298314) isn't supported on the mobile device family.</span></span>

```csharp
async void DefaultLaunch()
{
   // Path to the file in the app package to launch
   string imageFile = @"images\test.png";
   
   var file = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync(imageFile);

   if (file != null)
   {
      // Set the desired remaining view
      var options = new Windows.System.LauncherOptions();
      options.DesiredRemainingView = Windows.UI.ViewManagement.ViewSizePreference.UseLess;

      // Launch the retrieved file
      bool success = await Windows.System.Launcher.LaunchFileAsync(file, options);
      if (success)
      {
         // File launched
      }
      else
      {
         // File launch failed
      }
   }
   else
   {
      // Could not find file
   }
}
```

```cppwinrt
Windows::Foundation::IAsyncAction MainPage::DefaultLaunch()
{
    auto installFolder{ Windows::ApplicationModel::Package::Current().InstalledLocation() };

    Windows::Storage::StorageFile file{ co_await installFolder.GetFileAsync(L"images\\test.png") };

    if (file)
    {
        // Set the desired remaining view.
        Windows::System::LauncherOptions launchOptions;
        launchOptions.DesiredRemainingView(Windows::UI::ViewManagement::ViewSizePreference::UseLess);

        // Launch the retrieved file.
        bool success = co_await Windows::System::Launcher::LaunchFileAsync(file, launchOptions);
        if (success)
        {
            // File launched
        }
        else
        {
            // File launch failed
        }
    }
    else
    {
        // Could not find file
    }
}
```

```cpp
void MainPage::DefaultLaunch()
{
   auto installFolder = Windows::ApplicationModel::Package::Current->InstalledLocation;

   concurrency::task<Windows::Storage::StorageFile^> getFileOperation(installFolder->GetFileAsync("images\\test.png"));
   getFileOperation.then([](Windows::Storage::StorageFile^ file)
   {
      if (file != nullptr)
      {
         // Set the desired remaining view.
         auto launchOptions = ref new Windows::System::LauncherOptions();
         launchOptions->DesiredRemainingView = Windows::UI::ViewManagement::ViewSizePreference::UseLess;

         // Launch the retrieved file.
         concurrency::task<bool> launchFileOperation(Windows::System::Launcher::LaunchFileAsync(file, launchOptions));
         launchFileOperation.then([](bool success)
         {
            if (success)
            {
               // File launched
            }
            else
            {
               // File launch failed
            }
         });
      }
      else
      {
         // Could not find file
      }
   });
}
```

## <a name="remarks"></a><span data-ttu-id="c0699-170">注釈</span><span class="sxs-lookup"><span data-stu-id="c0699-170">Remarks</span></span>

<span data-ttu-id="c0699-171">起動するアプリをアプリが選ぶことはできません。</span><span class="sxs-lookup"><span data-stu-id="c0699-171">Your app can't select the app that is launched.</span></span> <span data-ttu-id="c0699-172">どのアプリを起動するかはユーザーが決めます。</span><span class="sxs-lookup"><span data-stu-id="c0699-172">The user determines which app is launched.</span></span> <span data-ttu-id="c0699-173">ユーザーは、ユニバーサル Windows プラットフォーム (UWP) アプリまたは Windows デスクトップ アプリを選択できます。</span><span class="sxs-lookup"><span data-stu-id="c0699-173">The user can select either a Universal Windows Platform (UWP) app or a Windows desktop app.</span></span>

<span data-ttu-id="c0699-174">ファイルの起動時、アプリはユーザーに表示されるフォアグラウンド アプリである必要があります。</span><span class="sxs-lookup"><span data-stu-id="c0699-174">When launching a file, your app must be the foreground app, that is, it must be visible to the user.</span></span> <span data-ttu-id="c0699-175">この要件は、ユーザーが制御を維持するのに役立ちます。</span><span class="sxs-lookup"><span data-stu-id="c0699-175">This requirement helps ensure that the user remains in control.</span></span> <span data-ttu-id="c0699-176">この要件を満たすために、すべてのファイル起動がアプリの UI に直接結び付けられていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="c0699-176">To meet this requirement, make sure that you tie all file launches directly to the UI of your app.</span></span> <span data-ttu-id="c0699-177">ほとんどの場合、ファイル起動を開始するには、常にユーザーがなんらかの操作を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="c0699-177">Most likely, the user must always take some action to initiate a file launch.</span></span>

<span data-ttu-id="c0699-178">.exe、.msi、.js ファイルなど、オペレーティング システムによって自動的に実行されるコードまたはスクリプトを含むファイルの種類を起動することはできません。</span><span class="sxs-lookup"><span data-stu-id="c0699-178">You can't launch file types that contain code or script if they are executed automatically by the operating system, such as, .exe, .msi, and .js files.</span></span> <span data-ttu-id="c0699-179">この制約により、オペレーティング システムを変更する可能性のある、悪意のあるファイルからユーザーを保護できます。</span><span class="sxs-lookup"><span data-stu-id="c0699-179">This restriction protects users from potentially malicious files that could modify the operating system.</span></span> <span data-ttu-id="c0699-180">この方法では、.docx ファイルなど、スクリプトを分離するアプリによって実行されるスクリプトを含むファイルの種類を起動できます。</span><span class="sxs-lookup"><span data-stu-id="c0699-180">You can use this method to launch file types that can contain script if they are executed by an app that isolates the script, such as, .docx files.</span></span> <span data-ttu-id="c0699-181">Microsoft Word などのアプリは、.docx ファイルのスクリプトがオペレーティング システムを変更しないようにします。</span><span class="sxs-lookup"><span data-stu-id="c0699-181">Apps like Microsoft Word keep the script in .docx files from modifying the operating system.</span></span>

<span data-ttu-id="c0699-182">制限されている種類のファイルを起動しようとすると、起動は失敗し、エラー コールバックが呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="c0699-182">If you try to launch a restricted file type, the launch will fail and your error callback will be invoked.</span></span> <span data-ttu-id="c0699-183">アプリがさまざまな種類のファイルを処理するため、このエラーの発生が予想される場合は、ユーザーにフォールバックを提供することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="c0699-183">If your app handles many different types of files and you expect that you will hit this error, we recommend that you provide a fallback experience to your user.</span></span> <span data-ttu-id="c0699-184">たとえば、ファイルをデスクトップに保存してそこで開けるようなオプションをユーザーに提供することができます。</span><span class="sxs-lookup"><span data-stu-id="c0699-184">For example, you could give the user an option to save the file to the desktop, and they could open it there.</span></span>

## <a name="related-topics"></a><span data-ttu-id="c0699-185">関連トピック</span><span class="sxs-lookup"><span data-stu-id="c0699-185">Related topics</span></span>

### <a name="tasks"></a><span data-ttu-id="c0699-186">処理手順</span><span class="sxs-lookup"><span data-stu-id="c0699-186">Tasks</span></span>

* [<span data-ttu-id="c0699-187">URI に応じた既定のアプリの起動</span><span class="sxs-lookup"><span data-stu-id="c0699-187">Launch the default app for a URI</span></span>](launch-default-app.md)
* [<span data-ttu-id="c0699-188">ファイルのアクティブ化の処理</span><span class="sxs-lookup"><span data-stu-id="c0699-188">Handle file activation</span></span>](handle-file-activation.md)

### <a name="guidelines"></a><span data-ttu-id="c0699-189">ガイドライン</span><span class="sxs-lookup"><span data-stu-id="c0699-189">Guidelines</span></span>

* [<span data-ttu-id="c0699-190">ファイルの種類と URI のガイドライン</span><span class="sxs-lookup"><span data-stu-id="c0699-190">Guidelines for file types and URIs</span></span>](https://msdn.microsoft.com/library/windows/apps/hh700321)

### <a name="reference"></a><span data-ttu-id="c0699-191">リファレンス</span><span class="sxs-lookup"><span data-stu-id="c0699-191">Reference</span></span>

* [**<span data-ttu-id="c0699-192">Windows.Storage.StorageFile</span><span class="sxs-lookup"><span data-stu-id="c0699-192">Windows.Storage.StorageFile</span></span>**](https://msdn.microsoft.com/library/windows/apps/br227171)
* [**<span data-ttu-id="c0699-193">Windows.System.Launcher.LaunchFileAsync</span><span class="sxs-lookup"><span data-stu-id="c0699-193">Windows.System.Launcher.LaunchFileAsync</span></span>**](https://msdn.microsoft.com/library/windows/apps/hh701461)
