---
author: andrewleader
Description: Learn how Win32 C# apps can send local toast notifications and handle the user clicking the toast.
title: デスクトップ C# アプリからのローカル トースト通知の送信
ms.assetid: E9AB7156-A29E-4ED7-B286-DA4A6E683638
label: Send a local toast notification from desktop C# apps
template: detail.hbs
ms.author: mijacobs
ms.date: 01/23/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, win32, デスクトップ, トースト通知, トーストの送信, ローカル トーストの送信, デスクトップ ブリッジ, C#, c シャープ
ms.localizationpriority: medium
ms.openlocfilehash: 3bda3e85fd89ef7a8b819fcd809acea4fd9a276b
ms.sourcegitcommit: a160b91a554f8352de963d9fa37f7df89f8a0e23
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/22/2018
ms.locfileid: "4131169"
---
# <a name="send-a-local-toast-notification-from-desktop-c-apps"></a><span data-ttu-id="c55a5-103">デスクトップ C# アプリからのローカル トースト通知の送信</span><span class="sxs-lookup"><span data-stu-id="c55a5-103">Send a local toast notification from desktop C# apps</span></span>

<span data-ttu-id="c55a5-104">デスクトップ アプリ (デスクトップ ブリッジと従来の Win32) は、ユニバーサル Windows プラットフォーム (UWP) アプリと同様の対話型トースト通知を送信できます。</span><span class="sxs-lookup"><span data-stu-id="c55a5-104">Desktop apps (both Desktop Bridge and classic Win32) can send interactive toast notifications just like Universal Windows Platform (UWP) apps.</span></span> <span data-ttu-id="c55a5-105">ただし、デスクトップ アプリの場合は、いくつかの特別な手順があります。これは、アクティブ化スキームが異なるためであり、またデスクトップ ブリッジを使用していない場合には、パッケージ ID が存在しない可能性があるためです。</span><span class="sxs-lookup"><span data-stu-id="c55a5-105">However, there are a few special steps for desktop apps due to the different activation schemes and the potential lack of package identity if you're not using the Desktop Bridge.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="c55a5-106">UWP アプリを作成している場合は、[UWP のドキュメント](send-local-toast.md) をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c55a5-106">If you're writing a UWP app, please see the [UWP documentation](send-local-toast.md).</span></span> <span data-ttu-id="c55a5-107">その他のデスクトップ言語については、[デスクトップ C++ WRLに関するページ](send-local-toast-desktop-cpp-wrl.md) をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c55a5-107">For other desktop languages, please see [Desktop C++ WRL](send-local-toast-desktop-cpp-wrl.md).</span></span>


## <a name="step-1-enable-the-windows-10-sdk"></a><span data-ttu-id="c55a5-108">手順 1: Windows 10 SDK を有効にする</span><span class="sxs-lookup"><span data-stu-id="c55a5-108">Step 1: Enable the Windows 10 SDK</span></span>

<span data-ttu-id="c55a5-109">Win32 アプリ向けの Windows 10 SDK がまだ有効でない場合は、まず有効にします。</span><span class="sxs-lookup"><span data-stu-id="c55a5-109">If you haven't enabled the Windows 10 SDK for your Win32 app, you must do that first.</span></span>

<span data-ttu-id="c55a5-110">プロジェクトを右クリックし、**[プロジェクトのアンロード]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="c55a5-110">Right click your project and select **Unload Project**.</span></span>

![プロジェクトのアンロード](images/win32-unload-project.png)

<span data-ttu-id="c55a5-112">プロジェクトをもう一度右クリックし、**[[プロジェクト名].csproj の編集]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="c55a5-112">Then right click your project again, and select **Edit [projectname].csproj**</span></span>

![プロジェクトの編集](images/win32-edit-project.png)

<span data-ttu-id="c55a5-114">既存の `<TargetFrameworkVersion>` ノードの下に、サポートされる Windows 10 の最小バージョンを指定して、新しい `<TargetPlatformVersion>` ノードを追加します。</span><span class="sxs-lookup"><span data-stu-id="c55a5-114">Below the existing `<TargetFrameworkVersion>` node, add a new `<TargetPlatformVersion>` node specifying your min version of Windows 10 supported.</span></span> <span data-ttu-id="c55a5-115">使用される実際の SDK は、開発用マシンにインストールされている最新の SDK です。</span><span class="sxs-lookup"><span data-stu-id="c55a5-115">The actual SDK used will be the latest SDK that you have installed on your dev machine.</span></span> <span data-ttu-id="c55a5-116">これだけで、サポートされる最小バージョンが指定されます (また Windows SDK を参照できるようになります)。</span><span class="sxs-lookup"><span data-stu-id="c55a5-116">This simply specifies your min allowed version (and allows you to reference the Windows SDK).</span></span>

```xml
...
<TargetFrameworkVersion>...</TargetFrameworkVersion>
<TargetPlatformVersion>10.0.10240.0</TargetPlatformVersion>
...
```

<span data-ttu-id="c55a5-117">変更を保存し、プロジェクトを再度読み込みます。</span><span class="sxs-lookup"><span data-stu-id="c55a5-117">Save your changes and then reload your project.</span></span>

![プロジェクトの再読み込み](images/win32-reload-project.png)


## <a name="step-2-reference-the-apis"></a><span data-ttu-id="c55a5-119">手順 2: API を参照する</span><span class="sxs-lookup"><span data-stu-id="c55a5-119">Step 2: Reference the APIs</span></span>

<span data-ttu-id="c55a5-120">参照マネージャーを開きます (プロジェクトを右クリックして、**[追加] -> [参照]** を選択)。**[Windows] -> [コア]** を選択し、以下の参照を追加します。</span><span class="sxs-lookup"><span data-stu-id="c55a5-120">Open the Reference Manager (right click project, select **Add -> Reference**), and select **Windows -> Core** and include the following references:</span></span>

* <span data-ttu-id="c55a5-121">Windows.Data</span><span class="sxs-lookup"><span data-stu-id="c55a5-121">Windows.Data</span></span>
* <span data-ttu-id="c55a5-122">Windows.UI</span><span class="sxs-lookup"><span data-stu-id="c55a5-122">Windows.UI</span></span>

![参照マネージャー](images/win32-add-windows-reference.png)


## <a name="step-3-copy-compat-library-code"></a><span data-ttu-id="c55a5-124">手順 3: compat ライブラリのコードをコピーする</span><span class="sxs-lookup"><span data-stu-id="c55a5-124">Step 3: Copy compat library code</span></span>

<span data-ttu-id="c55a5-125">[DesktopNotificationManagerCompat.cs file from GitHub](https://raw.githubusercontent.com/WindowsNotifications/desktop-toasts/master/CS/DesktopToastsApp/DesktopNotificationManagerCompat.cs) をプロジェクトにコピーします。</span><span class="sxs-lookup"><span data-stu-id="c55a5-125">Copy the [DesktopNotificationManagerCompat.cs file from GitHub](https://raw.githubusercontent.com/WindowsNotifications/desktop-toasts/master/CS/DesktopToastsApp/DesktopNotificationManagerCompat.cs) into your project.</span></span> <span data-ttu-id="c55a5-126">compat ライブラリを使用することで、デスクトップ通知の複雑な部分の多くが抽象化されます。</span><span class="sxs-lookup"><span data-stu-id="c55a5-126">The compat library abstracts much of the complexity of desktop notifications.</span></span> <span data-ttu-id="c55a5-127">次の手順では、compat ライブラリが必要です。</span><span class="sxs-lookup"><span data-stu-id="c55a5-127">The following instructions require the compat library.</span></span>


## <a name="step-4-implement-the-activator"></a><span data-ttu-id="c55a5-128">手順 4: アクティベーターを実装する</span><span class="sxs-lookup"><span data-stu-id="c55a5-128">Step 4: Implement the activator</span></span>

<span data-ttu-id="c55a5-129">ユーザーがトーストをクリックすると、アプリが動作できるトーストのアクティブ化するためのハンドラーを実装する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c55a5-129">You must implement a handler for toast activation, so that when the user clicks on your toast, your app can do something.</span></span> <span data-ttu-id="c55a5-130">これは、アクション センターにトーストを継続的に表示するために必要です (トーストは、数日後、アプリが閉じているときにクリックされる可能性があります)。</span><span class="sxs-lookup"><span data-stu-id="c55a5-130">This is required for your toast to persist in Action Center (since the toast could be clicked days later when your app is closed).</span></span> <span data-ttu-id="c55a5-131">このクラスは、プロジェクトの任意の位置に指定できます。</span><span class="sxs-lookup"><span data-stu-id="c55a5-131">This class can be placed anywhere in your project.</span></span>

<span data-ttu-id="c55a5-132">**NotificationActivator** クラスを展開し、以下の 3 つの属性を追加します。任意のオンライン GUID ジェネレーターを使用して、アプリ用に一意の GUID CLSID を作成します。</span><span class="sxs-lookup"><span data-stu-id="c55a5-132">Extend the **NotificationActivator** class and then add the three attributes listed below, and create a unique GUID CLSID for your app using one of the many online GUID generators.</span></span> <span data-ttu-id="c55a5-133">アクション センターは、この CLSID (クラス識別子) に基づいて、COM アクティブ化するクラスを認識します。</span><span class="sxs-lookup"><span data-stu-id="c55a5-133">This CLSID (class identifier) is how Action Center knows what class to COM activate.</span></span>

```csharp
// The GUID CLSID must be unique to your app. Create a new GUID if copying this code.
[ClassInterface(ClassInterfaceType.None)]
[ComSourceInterfaces(typeof(INotificationActivationCallback))]
[Guid("replaced-with-your-guid-C173E6ADF0C3"), ComVisible(true)]
public class MyNotificationActivator : NotificationActivator
{
    public override void OnActivated(string invokedArgs, NotificationUserInput userInput, string appUserModelId)
    {
        // TODO: Handle activation
    }
}
```


## <a name="step-5-register-with-notification-platform"></a><span data-ttu-id="c55a5-134">手順 5: 通知プラットフォームに登録する</span><span class="sxs-lookup"><span data-stu-id="c55a5-134">Step 5: Register with notification platform</span></span>

<span data-ttu-id="c55a5-135">次に、通知プラットフォームに登録します。</span><span class="sxs-lookup"><span data-stu-id="c55a5-135">Then, you must register with the notification platform.</span></span> <span data-ttu-id="c55a5-136">デスクトップ ブリッジと従来の Win32 のどちらを使用するかによって、手順が異なります。</span><span class="sxs-lookup"><span data-stu-id="c55a5-136">There are different steps depending on whether you are using the Desktop Bridge or classic Win32.</span></span> <span data-ttu-id="c55a5-137">両方をサポートする場合は、両方の手順を行う必要があります (コードをフォークする必要はありません。ライブラリがすべて自動的に処理します)。</span><span class="sxs-lookup"><span data-stu-id="c55a5-137">If you support both, you must do both steps (however, no need to fork your code, our library handles that for you!).</span></span>


### <a name="desktop-bridge"></a><span data-ttu-id="c55a5-138">デスクトップ ブリッジ</span><span class="sxs-lookup"><span data-stu-id="c55a5-138">Desktop Bridge</span></span>

<span data-ttu-id="c55a5-139">デスクトップ ブリッジを使用する場合 (または両方をサポートする場合) は、**Package.appxmanifest** に以下を追加します。</span><span class="sxs-lookup"><span data-stu-id="c55a5-139">If you're using Desktop Bridge (or if you support both), in your **Package.appxmanifest**, add:</span></span>

1. <span data-ttu-id="c55a5-140">**xmlns:com** のための宣言</span><span class="sxs-lookup"><span data-stu-id="c55a5-140">Declaration for **xmlns:com**</span></span>
2. <span data-ttu-id="c55a5-141">**xmlns:desktop** のための宣言</span><span class="sxs-lookup"><span data-stu-id="c55a5-141">Declaration for **xmlns:desktop**</span></span>
3. <span data-ttu-id="c55a5-142">**IgnorableNamespaces** 属性に **com** と **desktop** を追加</span><span class="sxs-lookup"><span data-stu-id="c55a5-142">In the **IgnorableNamespaces** attribute, **com** and **desktop**</span></span>
4. <span data-ttu-id="c55a5-143">手順 4 で取得した GUID を使用して、COM アクティベーターの **com:Extension** を追加</span><span class="sxs-lookup"><span data-stu-id="c55a5-143">**com:Extension** for the COM activator using the GUID from step #4.</span></span> <span data-ttu-id="c55a5-144">トーストから起動されたことがわかるように、必ず、`Arguments="-ToastActivated"` を指定します。</span><span class="sxs-lookup"><span data-stu-id="c55a5-144">Be sure to include the `Arguments="-ToastActivated"` so that you know your launch was from a toast</span></span>
5. <span data-ttu-id="c55a5-145">**windows.toastNotificationActivation** の **desktop:Extension** を追加して、トースト アクティベーター  CLSID (手順 4 の GUID) を宣言します。</span><span class="sxs-lookup"><span data-stu-id="c55a5-145">**desktop:Extension** for **windows.toastNotificationActivation** to declare your toast activator CLSID (the GUID from step #4).</span></span>

**<span data-ttu-id="c55a5-146">Package.appxmanifest</span><span class="sxs-lookup"><span data-stu-id="c55a5-146">Package.appxmanifest</span></span>**

```xml
<Package
  ...
  xmlns:com="http://schemas.microsoft.com/appx/manifest/com/windows10"
  xmlns:desktop="http://schemas.microsoft.com/appx/manifest/desktop/windows10"
  IgnorableNamespaces="... com desktop">
  ...
  <Applications>
    <Application>
      ...
      <Extensions>

        <!--Register COM CLSID LocalServer32 registry key-->
        <com:Extension Category="windows.comServer">
          <com:ComServer>
            <com:ExeServer Executable="YourProject\YourProject.exe" Arguments="-ToastActivated" DisplayName="Toast activator">
              <com:Class Id="replaced-with-your-guid-C173E6ADF0C3" DisplayName="Toast activator"/>
            </com:ExeServer>
          </com:ComServer>
        </com:Extension>

        <!--Specify which CLSID to activate when toast clicked-->
        <desktop:Extension Category="windows.toastNotificationActivation">
          <desktop:ToastNotificationActivation ToastActivatorCLSID="replaced-with-your-guid-C173E6ADF0C3" /> 
        </desktop:Extension>

      </Extensions>
    </Application>
  </Applications>
 </Package>
```


### <a name="classic-win32"></a><span data-ttu-id="c55a5-147">従来の Win32</span><span class="sxs-lookup"><span data-stu-id="c55a5-147">Classic Win32</span></span>

<span data-ttu-id="c55a5-148">従来の Win32 を使用する場合 (または両方をサポートする場合) は、スタート メニューのアプリのショートカットで、アプリケーション ユーザー モデル ID (AUMID) とトースト アクティベーター CLSID (手順 4 の GUID) を宣言する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c55a5-148">If you're using classic Win32 (or if you support both), you have to declare your Application User Model ID (AUMID) and toast activator CLSID (the GUID from step #4) on your app's shortcut in Start.</span></span>

<span data-ttu-id="c55a5-149">対象の Win32 アプリを識別する一意の AUMID を選択します。</span><span class="sxs-lookup"><span data-stu-id="c55a5-149">Pick a unique AUMID that will identify your Win32 app.</span></span> <span data-ttu-id="c55a5-150">これは通常、[CompanyName].[AppName] の形式です。すべてのアプリを通じて、一意である必要があります (任意の数字を自由に追加できます)。</span><span class="sxs-lookup"><span data-stu-id="c55a5-150">This is typically in the form of [CompanyName].[AppName], but you want to ensure this is unique across all apps (feel free to add some digits at the end).</span></span>

#### <a name="step-51-wix-installer"></a><span data-ttu-id="c55a5-151">手順 5.1: WiX インストーラー</span><span class="sxs-lookup"><span data-stu-id="c55a5-151">Step 5.1: WiX Installer</span></span>

<span data-ttu-id="c55a5-152">インストーラーに WiX を使用している場合は、以下に示すように **Product.wxs** ファイルを編集して、スタート メニューのショートカットに 2 つのショートカット プロパティを追加します。</span><span class="sxs-lookup"><span data-stu-id="c55a5-152">If you're using WiX for your installer, edit the **Product.wxs** file to add the two shortcut properties to your Start menu shortcut as seen below.</span></span> <span data-ttu-id="c55a5-153">下のように、手順 4 の GUID を必ず `{}` で囲みます。</span><span class="sxs-lookup"><span data-stu-id="c55a5-153">Be sure that your GUID from step #4 is enclosed in `{}` as seen below.</span></span>

**<span data-ttu-id="c55a5-154">Product.wxs</span><span class="sxs-lookup"><span data-stu-id="c55a5-154">Product.wxs</span></span>**

```xml
<Shortcut Id="ApplicationStartMenuShortcut" Name="Wix Sample" Description="Wix Sample" Target="[INSTALLFOLDER]WixSample.exe" WorkingDirectory="INSTALLFOLDER">
                    
    <!--AUMID-->
    <ShortcutProperty Key="System.AppUserModel.ID" Value="YourCompany.YourApp"/>
    
    <!--COM CLSID-->
    <ShortcutProperty Key="System.AppUserModel.ToastActivatorCLSID" Value="{replaced-with-your-guid-C173E6ADF0C3}"/>
    
</Shortcut>
```

> [!IMPORTANT]
> <span data-ttu-id="c55a5-155">実際に通知を使用するためには、通常のデバッグ前に、アプリをインストーラー経由でインストールして、AUMID と CLSID を使用したスタート ショートカットを表示する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c55a5-155">In order to actually use notifications, you must install your app through the installer once before debugging normally, so that the Start shortcut with your AUMID and CLSID is present.</span></span> <span data-ttu-id="c55a5-156">スタート ショートカットが表示された後は、Visual Studio で F5 キーを使用してデバッグできます。</span><span class="sxs-lookup"><span data-stu-id="c55a5-156">After the Start shortcut is present, you can debug using F5 from Visual Studio.</span></span>


#### <a name="step-52-register-aumid-and-com-server"></a><span data-ttu-id="c55a5-157">手順 5.2: AUMID と COM サーバーを登録する</span><span class="sxs-lookup"><span data-stu-id="c55a5-157">Step 5.2: Register AUMID and COM server</span></span>

<span data-ttu-id="c55a5-158">次に、どちらのインストーラーを使用する場合も、(通知 API を呼び出す前に) アプリのスタートアップ コード内で、**RegisterAumidAndComServer** メソッドを呼び出して、上記の手順 4 の通知アクティベーター クラスと AUMID を指定します。</span><span class="sxs-lookup"><span data-stu-id="c55a5-158">Then, regardless of your installer, in your app's startup code (before calling any notification APIs), call the **RegisterAumidAndComServer** method, specifying your notification activator class from step #4 and your AUMID used above.</span></span>

```csharp
// Register AUMID and COM server (for Desktop Bridge apps, this no-ops)
DesktopNotificationManagerCompat.RegisterAumidAndComServer<MyNotificationActivator>("YourCompany.YourApp");
```

<span data-ttu-id="c55a5-159">デスクトップ ブリッジと従来の Win32 の両方をサポートする場合も、問題なくこのメソッドを呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="c55a5-159">If you support both Desktop Bridge and classic Win32, feel free to call this method regardless.</span></span> <span data-ttu-id="c55a5-160">デスクトップ ブリッジで実行する場合、このメソッドは即座に戻ります。</span><span class="sxs-lookup"><span data-stu-id="c55a5-160">If you're running under Desktop Bridge, this method will simply return immediately.</span></span> <span data-ttu-id="c55a5-161">コードをフォークする必要はありません。</span><span class="sxs-lookup"><span data-stu-id="c55a5-161">There's no need to fork your code.</span></span>

<span data-ttu-id="c55a5-162">このメソッドを使用することで、AUMID を常に提供する必要なしに、compat API を呼び出して通知を送信および管理できます。</span><span class="sxs-lookup"><span data-stu-id="c55a5-162">This method allows you to call the compat APIs to send and manage notifications without having to constantly provide your AUMID.</span></span> <span data-ttu-id="c55a5-163">またこのメソッドによって、COM サーバーの LocalServer32 レジストリ キーが挿入されます。</span><span class="sxs-lookup"><span data-stu-id="c55a5-163">And it inserts the LocalServer32 registry key for the COM server.</span></span>


## <a name="step-6-register-com-activator"></a><span data-ttu-id="c55a5-164">手順 6: COM サーバーを登録する</span><span class="sxs-lookup"><span data-stu-id="c55a5-164">Step 6: Register COM activator</span></span>

<span data-ttu-id="c55a5-165">デスクトップ ブリッジと従来の Win32 アプリのいずれを使用する場合も、トーストのアクティブ化を処理するためには、通知アクティベーター タイプを登録する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c55a5-165">For both Desktop Bridge and classic Win32 apps, you must register your notification activator type, so that you can handle toast activations.</span></span>

<span data-ttu-id="c55a5-166">アプリのスタートアップ コードで、手順 4 で作成した **NotificationActivator** クラスを次の **RegisterActivator** メソッドに渡して呼び出します。</span><span class="sxs-lookup"><span data-stu-id="c55a5-166">In your app's startup code, call the following **RegisterActivator** method, passing in your implementation of the **NotificationActivator** class you created in step #4.</span></span> <span data-ttu-id="c55a5-167">これにより、トーストのアクティブ化を受信できるようになります。</span><span class="sxs-lookup"><span data-stu-id="c55a5-167">This must be called in order for you to receive any toast activations.</span></span>

```csharp
// Register COM server and activator type
DesktopNotificationManagerCompat.RegisterActivator<MyNotificationActivator>();
```


## <a name="step-7-send-a-notification"></a><span data-ttu-id="c55a5-168">手順 7: 通知を送信する</span><span class="sxs-lookup"><span data-stu-id="c55a5-168">Step 7: Send a notification</span></span>

<span data-ttu-id="c55a5-169">通知を送信する手順は、**DesktopNotificationManagerCompat** クラスを使用して **ToastNotifier** を作成することを除き、UWP アプリとまったく同じです。</span><span class="sxs-lookup"><span data-stu-id="c55a5-169">Sending a notification is identical to UWP apps, except that you will use the **DesktopNotificationManagerCompat** class to create a **ToastNotifier**.</span></span> <span data-ttu-id="c55a5-170">デスクトップ ブリッジと従来の Win32 の間で異なる部分は、compat ライブラリによって自動的に処理されるため、コードをフォークする必要はありません。</span><span class="sxs-lookup"><span data-stu-id="c55a5-170">The compat library automatically handles the difference between Desktop Bridge and classic Win32 so you do not have to fork your code.</span></span> <span data-ttu-id="c55a5-171">従来の Win32 では、**RegisterAumidAndComServer** の呼び出し時に、指定した AUMID が compat ライブラリによってキャッシュされるため、AUMID を指定するタイミングや指定するかどうかを検討する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="c55a5-171">For classic Win32, the compat library caches your AUMID you provided when calling **RegisterAumidAndComServer** so that you don't need to worry about when to provide or not provide the AUMID.</span></span>

> [!NOTE]
> <span data-ttu-id="c55a5-172">[Notifications ライブラリ](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/) をインストールすると、以下に示すように、生の XML ではなく、C# を使って通知を作成できます。</span><span class="sxs-lookup"><span data-stu-id="c55a5-172">Install the [Notifications library](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/) so that you can construct notifications using C# as seen below, instead of using raw XML.</span></span>

<span data-ttu-id="c55a5-173">レガシの Windows 8.1 のトースト通知テンプレートでは、手順 4 で作成した COM 通知アクティベーターがアクティブ化されないため、以下に示すように、**ToastContent** (または XML を手作業で作成している場合は、ToastGeneric テンプレート) を必ず使用します。</span><span class="sxs-lookup"><span data-stu-id="c55a5-173">Make sure you use the **ToastContent** seen below (or the ToastGeneric template if you're hand-crafting XML) since the legacy Windows 8.1 toast notification templates will not activate your COM notification activator you created in step #4.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="c55a5-174">http イメージは、マニフェストにインターネット機能を持つデスクトップ ブリッジ アプリでのみサポートされます。</span><span class="sxs-lookup"><span data-stu-id="c55a5-174">Http images are only supported in Desktop Bridge apps that have the internet capability in their manifest.</span></span> <span data-ttu-id="c55a5-175">従来の Win32 アプリは http イメージをサポートしていないため、ローカル アプリ データにイメージをダウンロードし、それをローカルに参照する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c55a5-175">Classic Win32 apps do not support http images; you must download the image to your local app data and reference it locally.</span></span>

```csharp
// Construct the visuals of the toast (using Notifications library)
ToastContent toastContent = new ToastContent()
{
    // Arguments when the user taps body of toast
    Launch = "action=viewConversation&conversationId=5",

    Visual = new ToastVisual()
    {
        BindingGeneric = new ToastBindingGeneric()
        {
            Children =
            {
                new AdaptiveText()
                {
                    Text = "Hello world!"
                }
            }
        }
    }
};

// Create the XML document (BE SURE TO REFERENCE WINDOWS.DATA.XML.DOM)
var doc = new XmlDocument();
doc.LoadXml(toastContent.GetContent());

// And create the toast notification
var toast = new ToastNotification(doc);

// And then show it
DesktopNotificationManagerCompat.CreateToastNotifier().Show(toast);
```

> [!IMPORTANT]
> <span data-ttu-id="c55a5-176">従来の Win32 アプリでは、レガシ トースト テンプレート (ToastText02 など) を使用できません。</span><span class="sxs-lookup"><span data-stu-id="c55a5-176">Classic Win32 apps cannot use legacy toast templates (like ToastText02).</span></span> <span data-ttu-id="c55a5-177">COM CLSID を指定すると、レガシ テンプレートのアクティブ化は失敗します。</span><span class="sxs-lookup"><span data-stu-id="c55a5-177">Activation of the legacy templates will fail when the COM CLSID is specified.</span></span> <span data-ttu-id="c55a5-178">上記のように Windows 10 ToastGeneric テンプレートを使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c55a5-178">You must use the Windows 10 ToastGeneric templates as seen above.</span></span>


## <a name="step-8-handling-activation"></a><span data-ttu-id="c55a5-179">手順 8: アクティブ化を処理する</span><span class="sxs-lookup"><span data-stu-id="c55a5-179">Step 8: Handling activation</span></span>

<span data-ttu-id="c55a5-180">ユーザーがトーストをクリックすると、**NotificationActivator** クラスの **OnActivated** メソッドが呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="c55a5-180">When the user clicks on your toast, the **OnActivated** method of your **NotificationActivator** class is invoked.</span></span>

<span data-ttu-id="c55a5-181">OnActivated メソッド内では、トーストで指定した引数を解析し、ユーザーが入力または選択したユーザー入力を取得したうえで、それに応じてアプリをアクティブ化できます。</span><span class="sxs-lookup"><span data-stu-id="c55a5-181">Inside the OnActivated method, you can parse the args that you specified in the toast and obtain the user input that the user typed or selected, and then activate your app accordingly.</span></span>

> [!NOTE]
> <span data-ttu-id="c55a5-182">**OnActivated** メソッドは UI スレッドでは呼び出されません。</span><span class="sxs-lookup"><span data-stu-id="c55a5-182">The **OnActivated** method is not called on the UI thread.</span></span> <span data-ttu-id="c55a5-183">UI スレッド操作を実行する場合は、`Application.Current.Dispatcher.Invoke(callback)` を呼び出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="c55a5-183">If you'd like to perform UI thread operations, you must call `Application.Current.Dispatcher.Invoke(callback)`.</span></span>

```csharp
// The GUID must be unique to your app. Create a new GUID if copying this code.
[ClassInterface(ClassInterfaceType.None)]
[ComSourceInterfaces(typeof(INotificationActivationCallback))]
[Guid("replaced-with-your-guid-C173E6ADF0C3"), ComVisible(true)]
public class MyNotificationActivator : NotificationActivator
{
    public override void OnActivated(string invokedArgs, NotificationUserInput userInput, string appUserModelId)
    {
        Application.Current.Dispatcher.Invoke(delegate
        {
            // Tapping on the top-level header launches with empty args
            if (arguments.Length == 0)
            {
                // Perform a normal launch
                OpenWindowIfNeeded();
                return;
            }

            // Parse the query string (using NuGet package QueryString.NET)
            QueryString args = QueryString.Parse(invokedArgs);

            // See what action is being requested 
            switch (args["action"])
            {
                // Open the image
                case "viewImage":

                    // The URL retrieved from the toast args
                    string imageUrl = args["imageUrl"];

                    // Make sure we have a window open and in foreground
                    OpenWindowIfNeeded();

                    // And then show the image
                    (App.Current.Windows[0] as MainWindow).ShowImage(imageUrl);

                    break;

                // Background: Quick reply to the conversation
                case "reply":

                    // Get the response the user typed
                    string msg = userInput["tbReply"];

                    // And send this message
                    SendMessage(msg);

                    // If there's no windows open, exit the app
                    if (App.Current.Windows.Count == 0)
                    {
                        Application.Current.Shutdown();
                    }

                    break;
            }
        });
    }

    private void OpenWindowIfNeeded()
    {
        // Make sure we have a window open (in case user clicked toast while app closed)
        if (App.Current.Windows.Count == 0)
        {
            new MainWindow().Show();
        }

        // Activate the window, bringing it to focus
        App.Current.Windows[0].Activate();

        // And make sure to maximize the window too, in case it was currently minimized
        App.Current.Windows[0].WindowState = WindowState.Normal;
    }
}
```

<span data-ttu-id="c55a5-184">アプリが閉じている間の起動を適切にサポートするため、`App.xaml.cs` ファイル内で **OnStartup** メソッド (WPF アプリ用) を上書きして、トーストから起動しているかどうかを判定することができます。</span><span class="sxs-lookup"><span data-stu-id="c55a5-184">To properly support being launched while your app is closed, in your `App.xaml.cs` file, you'll want to override **OnStartup** method (for WPF apps) to determine whether you're being launched from a toast or not.</span></span> <span data-ttu-id="c55a5-185">トーストから起動している場合は、起動引数が "-ToastActivated" に指定されています。</span><span class="sxs-lookup"><span data-stu-id="c55a5-185">If launched from a toast, there will be a launch arg of "-ToastActivated".</span></span> <span data-ttu-id="c55a5-186">この引数が指定されている場合、通常の起動アクティブ化コードの実行をすべて停止して、**OnActivated** コードによる起動処理が完了するのを待つ必要があります。</span><span class="sxs-lookup"><span data-stu-id="c55a5-186">When you see this, you should stop performing any normal launch activation code, and allow your **OnActivated** code handle launching.</span></span>

```csharp
protected override async void OnStartup(StartupEventArgs e)
{
    // Register AUMID, COM server, and activator
    DesktopNotificationManagerCompat.RegisterAumidAndComServer<MyNotificationActivator>("YourCompany.YourApp");
    DesktopNotificationManagerCompat.RegisterActivator<MyNotificationActivator>();

    // If launched from a toast
    if (e.Args.Contains("-ToastActivated"))
    {
        // Our NotificationActivator code will run after this completes,
        // and will show a window if necessary.
    }

    else
    {
        // Show the window
        // In App.xaml, be sure to remove the StartupUri so that a window doesn't
        // get created by default, since we're creating windows ourselves (and sometimes we
        // don't want to create a window if handling a background activation).
        new MainWindow().Show();
    }

    base.OnStartup(e);
}
```


### <a name="activation-sequence-of-events"></a><span data-ttu-id="c55a5-187">イベントのアクティブ化シーケンス</span><span class="sxs-lookup"><span data-stu-id="c55a5-187">Activation sequence of events</span></span>

<span data-ttu-id="c55a5-188">WPF の場合、アクティブ化シーケンスは次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="c55a5-188">For WPF, the activation sequence is the following...</span></span>

<span data-ttu-id="c55a5-189">アプリが既に実行されている場合:</span><span class="sxs-lookup"><span data-stu-id="c55a5-189">If your app is already running:</span></span>

1. <span data-ttu-id="c55a5-190">**NotificationActivator** で **OnActivated** が呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="c55a5-190">**OnActivated** in your **NotificationActivator** is called</span></span>

<span data-ttu-id="c55a5-191">アプリが実行されていない場合:</span><span class="sxs-lookup"><span data-stu-id="c55a5-191">If your app is not running:</span></span>

1. <span data-ttu-id="c55a5-192">`App.xaml.cs` で、**Args** に "-ToastActivated" を指定して **OnStartup** が呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="c55a5-192">**OnStartup** in `App.xaml.cs` is called with **Args** of "-ToastActivated"</span></span>
2. <span data-ttu-id="c55a5-193">**NotificationActivator** で **OnActivated** が呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="c55a5-193">**OnActivated** in your **NotificationActivator** is called</span></span>


### <a name="foreground-vs-background-activation"></a><span data-ttu-id="c55a5-194">フォアグラウンドとバックグラウンドのアクティブ化</span><span class="sxs-lookup"><span data-stu-id="c55a5-194">Foreground vs background activation</span></span>
<span data-ttu-id="c55a5-195">デスクトップ アプリでは、フォア グラウンドとバック グラウンドのアクティブ化はいずれも、COM アクティベーターの呼び出しという同じ手順で処理されます。</span><span class="sxs-lookup"><span data-stu-id="c55a5-195">For desktop apps, foreground and background activation is handled identically - your COM activator is called.</span></span> <span data-ttu-id="c55a5-196">ウィンドウを表示するか、ウィンドウを表示せずに作業を行うだけで終了するかは、アプリのコードによって決定されます。</span><span class="sxs-lookup"><span data-stu-id="c55a5-196">It's up to your app's code to decide whether to show a window or to simply perform some work and then exit.</span></span> <span data-ttu-id="c55a5-197">したがって、トーストのコンテンツで **ActivationType** に **Background** を指定しても、動作は変わりません。</span><span class="sxs-lookup"><span data-stu-id="c55a5-197">Therefore, specifying an **ActivationType** of **Background** in your toast content doesn't change the behavior.</span></span>


## <a name="step-9-remove-and-manage-notifications"></a><span data-ttu-id="c55a5-198">手順 9: 通知を削除および管理する</span><span class="sxs-lookup"><span data-stu-id="c55a5-198">Step 9: Remove and manage notifications</span></span>

<span data-ttu-id="c55a5-199">通知を削除および管理する手順は、UWP アプリと同じです。</span><span class="sxs-lookup"><span data-stu-id="c55a5-199">Removing and managing notifications is identical to UWP apps.</span></span> <span data-ttu-id="c55a5-200">ただし、compat ライブラリを使用して **DesktopNotificationHistoryCompat** を取得することをお勧めします。これにより、従来の Win32 を使用している場合も、AUMID を提供する必要がなくなります。</span><span class="sxs-lookup"><span data-stu-id="c55a5-200">However, we recommend you use our compat library to obtain a **DesktopNotificationHistoryCompat** so you don't have to worry about providing the AUMID if you're using classic Win32.</span></span>

```csharp
// Remove the toast with tag "Message2"
DesktopNotificationManagerCompat.History.Remove("Message2");

// Clear all toasts
DesktopNotificationManagerCompat.History.Clear();
```


## <a name="step-10-deploying-and-debugging"></a><span data-ttu-id="c55a5-201">手順 10: 展開とデバッグ</span><span class="sxs-lookup"><span data-stu-id="c55a5-201">Step 10: Deploying and debugging</span></span>

<span data-ttu-id="c55a5-202">デスクトップ ブリッジ アプリの展開とデバッグについては、「[パッケージ デスクトップ アプリの実行、デバッグ、テスト](/porting/desktop-to-uwp-debug.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c55a5-202">To deploy and debug your Desktop Bridge app, see [Run, debug, and test a packaged desktop app](/porting/desktop-to-uwp-debug.md).</span></span>

<span data-ttu-id="c55a5-203">従来の Win32 アプリを展開およびデバッグするには、通常のデバッグ前に、アプリをインストーラー経由でインストールして、AUMID と CLSID を使用したスタート ショートカットを表示する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c55a5-203">To deploy and debug your classic Win32 app, you must install your app through the installer once before debugging normally, so that the Start shortcut with your AUMID and CLSID is present.</span></span> <span data-ttu-id="c55a5-204">スタート ショートカットが表示された後は、Visual Studio で F5 キーを使用してデバッグできます。</span><span class="sxs-lookup"><span data-stu-id="c55a5-204">After the Start shortcut is present, you can debug using F5 from Visual Studio.</span></span>

<span data-ttu-id="c55a5-205">従来の Win32 アプリに通知がまったく表示されない場合 (かつ例外がスローされない場合)、原因として、スタート ショートカットが存在しないか (インストーラー経由でアプリをインストールしてください)、コード内で使用されている AUMID とスタート ショートカットの AUMID が一致していないことが考えられます。</span><span class="sxs-lookup"><span data-stu-id="c55a5-205">If your notifications simply fail to appear in your classic Win32 app (and no exceptions are thrown), that likely means the Start shortcut isn't present (install your app via the installer), or the AUMID you used in code doesn't match the AUMID in your Start shortcut.</span></span>

<span data-ttu-id="c55a5-206">通知は表示されるが、アクション センターに表示されたままにならない (ポップアップを無視すると表示されなくなる) 場合は、COM アクティベーターが正しく実装されていません。</span><span class="sxs-lookup"><span data-stu-id="c55a5-206">If your notifications appear but aren't persisted in Action Center (disappearing after the popup is dismissed), that means you haven't implemented the COM activator correctly.</span></span>

<span data-ttu-id="c55a5-207">デスクトップ ブリッジ アプリと従来の Win32 アプリの両方をインストールした場合、トーストのアクティブ化を処理するときに、デスクトップ ブリッジ アプリが従来の Win32 アプリに優先することに注意してください。</span><span class="sxs-lookup"><span data-stu-id="c55a5-207">If you've installed both your Desktop Bridge and classic Win32 app, note that the Desktop Bridge app will supersede the classic Win32 app when handling toast activations.</span></span> <span data-ttu-id="c55a5-208">そのため、従来の Win32 アプリから表示されたトーストをクリックしても、デスクトップ ブリッジ アプリが起動します。</span><span class="sxs-lookup"><span data-stu-id="c55a5-208">That means that toasts from the classic Win32 app will still launch the Desktop Bridge app when clicked.</span></span> <span data-ttu-id="c55a5-209">デスクトップ ブリッジ アプリをアンインストールすると、従来の Win32 アプリがアクティブ化されます。</span><span class="sxs-lookup"><span data-stu-id="c55a5-209">Uninstalling the Desktop Bridge app will revert activations back to the classic Win32 app.</span></span>


## <a name="known-issues"></a><span data-ttu-id="c55a5-210">既知の問題</span><span class="sxs-lookup"><span data-stu-id="c55a5-210">Known issues</span></span>

<span data-ttu-id="c55a5-211">**修正済み: トーストのクリック後、アプリがフォーカスされない**: ビルド 15063 以前では、COM サーバーをアクティブ化したときに、フォアグラウンドの権利がアプリケーションに移転されませんでした。</span><span class="sxs-lookup"><span data-stu-id="c55a5-211">**FIXED: App doesn't become focused after clicking toast**: In builds 15063 and earlier, foreground rights weren't being transferred to your application when we activated the COM server.</span></span> <span data-ttu-id="c55a5-212">そのため、アプリをフォアグラウンドに移動しようとしても、点滅するのみで移動できませんでした。</span><span class="sxs-lookup"><span data-stu-id="c55a5-212">Therefore, your app would simply flash when you tried to move it to the foreground.</span></span> <span data-ttu-id="c55a5-213">この問題を解決する方法はありませんでした。</span><span class="sxs-lookup"><span data-stu-id="c55a5-213">There was no workaround for this issue.</span></span> <span data-ttu-id="c55a5-214">この問題は、16299 以降のビルドでは解決済みです。</span><span class="sxs-lookup"><span data-stu-id="c55a5-214">We fixed this in builds 16299 and higher.</span></span>


## <a name="resources"></a><span data-ttu-id="c55a5-215">リソース</span><span class="sxs-lookup"><span data-stu-id="c55a5-215">Resources</span></span>

* [<span data-ttu-id="c55a5-216">GitHub での完全なコード サンプル</span><span class="sxs-lookup"><span data-stu-id="c55a5-216">Full code sample on GitHub</span></span>](https://github.com/WindowsNotifications/desktop-toasts)
* [<span data-ttu-id="c55a5-217">デスクトップ アプリからのトースト通知</span><span class="sxs-lookup"><span data-stu-id="c55a5-217">Toast notifications from desktop apps</span></span>](toast-desktop-apps.md)
* [<span data-ttu-id="c55a5-218">トースト コンテンツのドキュメント</span><span class="sxs-lookup"><span data-stu-id="c55a5-218">Toast content documentation</span></span>](adaptive-interactive-toasts.md)

