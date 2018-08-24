---
author: anbare
Description: Learn how Win32 C++ WRL apps can send local toast notifications and handle the user clicking the toast.
title: デスクトップ C++ WRL アプリからのローカル トースト通知の送信
label: Send a local toast notification from desktop C++ WRL apps
template: detail.hbs
ms.author: mijacobs
ms.date: 03/7/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, win32, デスクトップ, トースト通知, トーストの送信, ローカル トーストの送信, デスクトップ ブリッジ, C++, cpp, c プラスプラス, WRL
ms.localizationpriority: medium
ms.openlocfilehash: 00d6d67bccf9eb91e1d90aa547d9e857cfa83c19
ms.sourcegitcommit: f91aa1e402f1bc093b48a03fbae583318fc7e05d
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/24/2018
ms.locfileid: "1917731"
---
# <a name="send-a-local-toast-notification-from-desktop-c-wrl-apps"></a><span data-ttu-id="6d836-103">デスクトップ C++ WRL アプリからのローカル トースト通知の送信</span><span class="sxs-lookup"><span data-stu-id="6d836-103">Send a local toast notification from desktop C++ WRL apps</span></span>

<span data-ttu-id="6d836-104">デスクトップ アプリ (デスクトップ ブリッジと従来の Win32) は、ユニバーサル Windows プラットフォーム (UWP) アプリと同様の対話型トースト通知を送信できます。</span><span class="sxs-lookup"><span data-stu-id="6d836-104">Desktop apps (both Desktop Bridge and classic Win32) can send interactive toast notifications just like Universal Windows Platform (UWP) apps.</span></span> <span data-ttu-id="6d836-105">ただし、デスクトップ アプリの場合は、いくつかの特別な手順があります。これは、アクティブ化スキームが異なるためであり、またデスクトップ ブリッジを使用していない場合には、パッケージ ID が存在しない可能性があるためです。</span><span class="sxs-lookup"><span data-stu-id="6d836-105">However, there are a few special steps for desktop apps due to the different activation schemes and the potential lack of package identity if you're not using the Desktop Bridge.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="6d836-106">UWP アプリを作成している場合は、[UWP のドキュメント](send-local-toast.md) をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6d836-106">If you're writing a UWP app, please see the [UWP documentation](send-local-toast.md).</span></span> <span data-ttu-id="6d836-107">その他のデスクトップ言語については、[Desktop C# に関するページ](send-local-toast-desktop.md) をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6d836-107">For other desktop languages, please see [Desktop C#](send-local-toast-desktop.md).</span></span>


## <a name="step-1-enable-the-windows-10-sdk"></a><span data-ttu-id="6d836-108">手順 1: Windows 10 SDK を有効にする</span><span class="sxs-lookup"><span data-stu-id="6d836-108">Step 1: Enable the Windows 10 SDK</span></span>

<span data-ttu-id="6d836-109">Win32 アプリ向けの Windows 10 SDK がまだ有効でない場合は、まず有効にします。</span><span class="sxs-lookup"><span data-stu-id="6d836-109">If you haven't enabled the Windows 10 SDK for your Win32 app, you must do that first.</span></span> <span data-ttu-id="6d836-110">主な手順は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="6d836-110">There are a few key steps...</span></span>

1. <span data-ttu-id="6d836-111">**[追加の依存ファイル]** に `runtimeobject.lib` を追加する</span><span class="sxs-lookup"><span data-stu-id="6d836-111">Add `runtimeobject.lib` to **Additional Dependencies**</span></span>
2. <span data-ttu-id="6d836-112">Windows 10 SDK をターゲットとして設定する</span><span class="sxs-lookup"><span data-stu-id="6d836-112">Target the Windows 10 SDK</span></span>

<span data-ttu-id="6d836-113">プロジェクトを右クリックし、**[プロパティ]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="6d836-113">Right click your project and select **Properties**.</span></span>

<span data-ttu-id="6d836-114">上部にある **[構成]** メニューで、**[すべての構成]** を選択し、[Debug] と [Release] の両方で次の変更を行います。</span><span class="sxs-lookup"><span data-stu-id="6d836-114">In the top **Configuration** menu, select **All Configurations** so that the following change is applied to both Debug and Release.</span></span>

<span data-ttu-id="6d836-115">**[リンカー] -> [入力]** で、**[追加の依存ファイル]** に `runtimeobject.lib` を追加します。</span><span class="sxs-lookup"><span data-stu-id="6d836-115">Under **Linker -> Input**, add `runtimeobject.lib` to the **Additional Dependencies**.</span></span>

<span data-ttu-id="6d836-116">次に、**[全般]** の下で、**[Windows SDK バージョン]** が 10.0 以上のいずれかのバージョンであること (Windows 8.1 ではないこと) を確認します。</span><span class="sxs-lookup"><span data-stu-id="6d836-116">Then under **General**, make sure that the **Windows SDK Version** is set to something 10.0 or higher (not Windows 8.1).</span></span>


## <a name="step-2-copy-compat-library-code"></a><span data-ttu-id="6d836-117">手順 2: compat ライブラリのコードをコピーする</span><span class="sxs-lookup"><span data-stu-id="6d836-117">Step 2: Copy compat library code</span></span>

<span data-ttu-id="6d836-118">GitHub の [DesktopNotificationManagerCompat.h](https://raw.githubusercontent.com/WindowsNotifications/desktop-toasts/master/CPP-WRL/DesktopToastsCppWrlApp/DesktopNotificationManagerCompat.h) ファイルと [DesktopNotificationManagerCompat.cpp](https://raw.githubusercontent.com/WindowsNotifications/desktop-toasts/master/CPP-WRL/DesktopToastsCppWrlApp/DesktopNotificationManagerCompat.cpp) ファイルをプロジェクトにコピーします。</span><span class="sxs-lookup"><span data-stu-id="6d836-118">Copy the [DesktopNotificationManagerCompat.h](https://raw.githubusercontent.com/WindowsNotifications/desktop-toasts/master/CPP-WRL/DesktopToastsCppWrlApp/DesktopNotificationManagerCompat.h) and [DesktopNotificationManagerCompat.cpp](https://raw.githubusercontent.com/WindowsNotifications/desktop-toasts/master/CPP-WRL/DesktopToastsCppWrlApp/DesktopNotificationManagerCompat.cpp) file from GitHub into your project.</span></span> <span data-ttu-id="6d836-119">compat ライブラリを使用することで、デスクトップ通知の複雑な部分の多くが抽象化されます。</span><span class="sxs-lookup"><span data-stu-id="6d836-119">The compat library abstracts much of the complexity of desktop notifications.</span></span> <span data-ttu-id="6d836-120">次の手順では、compat ライブラリが必要です。</span><span class="sxs-lookup"><span data-stu-id="6d836-120">The following instructions require the compat library.</span></span>

<span data-ttu-id="6d836-121">プリコンパイル済みヘッダーを使用している場合は、必ず `#include "stdafx.h"` を DesktopNotificationManagerCompat.cpp ファイルの最初の行として指定します。</span><span class="sxs-lookup"><span data-stu-id="6d836-121">If you're using precompiled headers, make sure to `#include "stdafx.h"` as the first line of the DesktopNotificationManagerCompat.cpp file.</span></span>


## <a name="step-3-include-the-header-files-and-namespaces"></a><span data-ttu-id="6d836-122">手順 3: ヘッダー ファイルと名前空間をインクルードする</span><span class="sxs-lookup"><span data-stu-id="6d836-122">Step 3: Include the header files and namespaces</span></span>

<span data-ttu-id="6d836-123">compat ライブラリのヘッダー ファイル、および UWP トースト API の使用に関連するヘッダー ファイルと名前空間をインクルードします。</span><span class="sxs-lookup"><span data-stu-id="6d836-123">Include the compat library header file, and the header files and namespaces related to using the UWP toast APIs.</span></span>

```cpp
#include "DesktopNotificationManagerCompat.h"
#include "NotificationActivationCallback.h"
#include <windows.ui.notifications.h>

using namespace ABI::Windows::Data::Xml::Dom;
using namespace ABI::Windows::UI::Notifications;
using namespace Microsoft::WRL;
```


## <a name="step-4-implement-the-activator"></a><span data-ttu-id="6d836-124">手順 4: アクティベーターを実装する</span><span class="sxs-lookup"><span data-stu-id="6d836-124">Step 4: Implement the activator</span></span>

<span data-ttu-id="6d836-125">ユーザーがトーストをクリックしたときにアプリが動作できるように、トーストをアクティブ化するためのハンドラーを実装する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6d836-125">You must impelment a handler for toast activation, so that when the user clicks on your toast, your app can do something.</span></span> <span data-ttu-id="6d836-126">これは、アクション センターにトーストを継続的に表示するために必要です (トーストは、数日後、アプリが閉じているときにクリックされる可能性があります)。</span><span class="sxs-lookup"><span data-stu-id="6d836-126">This is required for your toast to persist in Action Center (since the toast could be clicked days later when your app is closed).</span></span> <span data-ttu-id="6d836-127">このクラスは、プロジェクトの任意の位置に指定できます。</span><span class="sxs-lookup"><span data-stu-id="6d836-127">This class can be placed anywhere in your project.</span></span>

<span data-ttu-id="6d836-128">以下に示すように、UUID を含めて **INotificationActivationCallback** インターフェイスを実装し、**CoCreatableClass** を呼び出して、クラスを COM 作成可能としてフラグ設定します。</span><span class="sxs-lookup"><span data-stu-id="6d836-128">Implement the **INotificationActivationCallback** interface as seen below, including a UUID, and also call **CoCreatableClass** to flag your class as COM creatable.</span></span> <span data-ttu-id="6d836-129">UUID は、任意のオンライン GUID ジェネレーターを使用して、一意の GUID を作成します。</span><span class="sxs-lookup"><span data-stu-id="6d836-129">For your UUID, create a unique GUID using one of the many online GUID generators.</span></span> <span data-ttu-id="6d836-130">アクション センターは、この GUID CLSID (クラス識別子) に基づいて、COM アクティブ化するクラスを認識します。</span><span class="sxs-lookup"><span data-stu-id="6d836-130">This GUID CLSID (class identifier) is how Action Center knows what class to COM activate.</span></span>

```cpp
// The UUID CLSID must be unique to your app. Create a new GUID if copying this code.
class DECLSPEC_UUID("replaced-with-your-guid-C173E6ADF0C3") NotificationActivator WrlSealed WrlFinal
    : public RuntimeClass<RuntimeClassFlags<ClassicCom>, INotificationActivationCallback>
{
public:
    virtual HRESULT STDMETHODCALLTYPE Activate(
        _In_ LPCWSTR appUserModelId,
        _In_ LPCWSTR invokedArgs,
        _In_reads_(dataCount) const NOTIFICATION_USER_INPUT_DATA* data,
        ULONG dataCount) override
    {
        // TODO: Handle activation
    }
};

// Flag class as COM creatable
CoCreatableClass(NotificationActivator);
```


## <a name="step-5-register-with-notification-platform"></a><span data-ttu-id="6d836-131">手順 5: 通知プラットフォームに登録する</span><span class="sxs-lookup"><span data-stu-id="6d836-131">Step 5: Register with notification platform</span></span>

<span data-ttu-id="6d836-132">次に、通知プラットフォームに登録します。</span><span class="sxs-lookup"><span data-stu-id="6d836-132">Then, you must register with the notification platform.</span></span> <span data-ttu-id="6d836-133">デスクトップ ブリッジと従来の Win32 のどちらを使用するかによって、手順が異なります。</span><span class="sxs-lookup"><span data-stu-id="6d836-133">There are different steps depending on whether you are using the Desktop Bridge or classic Win32.</span></span> <span data-ttu-id="6d836-134">両方をサポートする場合は、両方の手順を行う必要があります (コードをフォークする必要はありません。ライブラリがすべて自動的に処理します)。</span><span class="sxs-lookup"><span data-stu-id="6d836-134">If you support both, you must do both steps (however, no need to fork your code, our library handles that for you!).</span></span>


### <a name="desktop-bridge"></a><span data-ttu-id="6d836-135">デスクトップ ブリッジ</span><span class="sxs-lookup"><span data-stu-id="6d836-135">Desktop Bridge</span></span>

<span data-ttu-id="6d836-136">デスクトップ ブリッジを使用する場合 (または両方をサポートする場合) は、**Package.appxmanifest** に以下を追加します。</span><span class="sxs-lookup"><span data-stu-id="6d836-136">If you're using Desktop Bridge (or if you support both), in your **Package.appxmanifest**, add:</span></span>

1. <span data-ttu-id="6d836-137">**xmlns:com** のための宣言</span><span class="sxs-lookup"><span data-stu-id="6d836-137">Declaration for **xmlns:com**</span></span>
2. <span data-ttu-id="6d836-138">**xmlns:desktop** のための宣言</span><span class="sxs-lookup"><span data-stu-id="6d836-138">Declaration for **xmlns:desktop**</span></span>
3. <span data-ttu-id="6d836-139">**IgnorableNamespaces** 属性に **com** と **desktop** を追加</span><span class="sxs-lookup"><span data-stu-id="6d836-139">In the **IgnorableNamespaces** attribute, **com** and **desktop**</span></span>
4. <span data-ttu-id="6d836-140">手順 4 で取得した GUID を使用して、COM アクティベーターの **com:Extension** を追加</span><span class="sxs-lookup"><span data-stu-id="6d836-140">**com:Extension** for the COM activator using the GUID from step #4.</span></span> <span data-ttu-id="6d836-141">トーストから起動されたことがわかるように、必ず、`Arguments="-ToastActivated"` を指定します。</span><span class="sxs-lookup"><span data-stu-id="6d836-141">Be sure to include the `Arguments="-ToastActivated"` so that you know your launch was from a toast</span></span>
5. <span data-ttu-id="6d836-142">**windows.toastNotificationActivation** の **desktop:Extension** を追加して、トースト アクティベーター  CLSID (手順 4 の GUID) を宣言します。</span><span class="sxs-lookup"><span data-stu-id="6d836-142">**desktop:Extension** for **windows.toastNotificationActivation** to declare your toast activator CLSID (the GUID from step #4).</span></span>

**<span data-ttu-id="6d836-143">Package.appxmanifest</span><span class="sxs-lookup"><span data-stu-id="6d836-143">Package.appxmanifest</span></span>**

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


### <a name="classic-win32"></a><span data-ttu-id="6d836-144">従来の Win32</span><span class="sxs-lookup"><span data-stu-id="6d836-144">Classic Win32</span></span>

<span data-ttu-id="6d836-145">従来の Win32 を使用する場合 (または両方をサポートする場合) は、スタート メニューのアプリのショートカットで、アプリケーション ユーザー モデル ID (AUMID) とトースト アクティベーター CLSID (手順 4 の GUID) を宣言する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6d836-145">If you're using classic Win32 (or if you support both), you have to declare your Application User Model ID (AUMID) and toast activator CLSID (the GUID from step #4) on your app's shortcut in Start.</span></span>

<span data-ttu-id="6d836-146">対象の Win32 アプリを識別する一意の AUMID を選択します。</span><span class="sxs-lookup"><span data-stu-id="6d836-146">Pick a unique AUMID that will identify your Win32 app.</span></span> <span data-ttu-id="6d836-147">これは通常、[CompanyName].[AppName] の形式です。すべてのアプリを通じて、一意である必要があります (任意の数字を自由に追加できます)。</span><span class="sxs-lookup"><span data-stu-id="6d836-147">This is typically in the form of [CompanyName].[AppName], but you want to ensure this is unique across all apps (feel free to add some digits at the end).</span></span>

#### <a name="step-51-wix-installer"></a><span data-ttu-id="6d836-148">手順 5.1: WiX インストーラー</span><span class="sxs-lookup"><span data-stu-id="6d836-148">Step 5.1: WiX Installer</span></span>

<span data-ttu-id="6d836-149">インストーラーに WiX を使用している場合は、以下に示すように **Product.wxs** ファイルを編集して、スタート メニューのショートカットに 2 つのショートカット プロパティを追加します。</span><span class="sxs-lookup"><span data-stu-id="6d836-149">If you're using WiX for your installer, edit the **Product.wxs** file to add the two shortcut properties to your Start menu shortcut as seen below.</span></span> <span data-ttu-id="6d836-150">下のように、手順 4 の GUID を必ず `{}` で囲みます。</span><span class="sxs-lookup"><span data-stu-id="6d836-150">Be sure that your GUID from step #4 is enclosed in `{}` as seen below.</span></span>

**<span data-ttu-id="6d836-151">Product.wxs</span><span class="sxs-lookup"><span data-stu-id="6d836-151">Product.wxs</span></span>**

```xml
<Shortcut Id="ApplicationStartMenuShortcut" Name="Wix Sample" Description="Wix Sample" Target="[INSTALLFOLDER]WixSample.exe" WorkingDirectory="INSTALLFOLDER">
                    
    <!--AUMID-->
    <ShortcutProperty Key="System.AppUserModel.ID" Value="YourCompany.YourApp"/>
    
    <!--COM CLSID-->
    <ShortcutProperty Key="System.AppUserModel.ToastActivatorCLSID" Value="{replaced-with-your-guid-C173E6ADF0C3}"/>
    
</Shortcut>
```

> [!IMPORTANT]
> <span data-ttu-id="6d836-152">実際に通知を使用するためには、通常のデバッグ前に、アプリをインストーラー経由でインストールして、AUMID と CLSID を使用したスタート ショートカットを表示する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6d836-152">In order to actually use notifications, you must install your app through the installer once before debugging normally, so that the Start shortcut with your AUMID and CLSID is present.</span></span> <span data-ttu-id="6d836-153">スタート ショートカットが表示された後は、Visual Studio で F5 キーを使用してデバッグできます。</span><span class="sxs-lookup"><span data-stu-id="6d836-153">After the Start shortcut is present, you can debug using F5 from Visual Studio.</span></span>


#### <a name="step-52-register-aumid-and-com-server"></a><span data-ttu-id="6d836-154">手順 5.2: AUMID と COM サーバーを登録する</span><span class="sxs-lookup"><span data-stu-id="6d836-154">Step 5.2: Register AUMID and COM server</span></span>

<span data-ttu-id="6d836-155">次に、どちらのインストーラーを使用する場合も、(通知 API を呼び出す前に) アプリのスタートアップ コード内で、**RegisterAumidAndComServer** メソッドを呼び出して、上記の手順 4 の通知アクティベーター クラスと AUMID を指定します。</span><span class="sxs-lookup"><span data-stu-id="6d836-155">Then, regardless of your installer, in your app's startup code (before calling any notification APIs), call the **RegisterAumidAndComServer** method, specifying your notification activator class from step #4 and your AUMID used above.</span></span>

```cpp
// Register AUMID and COM server (for Desktop Bridge apps, this no-ops)
hr = DesktopNotificationManagerCompat::RegisterAumidAndComServer(L"YourCompany.YourApp", __uuidof(NotificationActivator));
```

<span data-ttu-id="6d836-156">デスクトップ ブリッジと従来の Win32 の両方をサポートする場合も、問題なくこのメソッドを呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="6d836-156">If you support both Desktop Bridge and classic Win32, feel free to call this method regardless.</span></span> <span data-ttu-id="6d836-157">デスクトップ ブリッジで実行する場合、このメソッドは即座に戻ります。</span><span class="sxs-lookup"><span data-stu-id="6d836-157">If you're running under Desktop Bridge, this method will simply return immediately.</span></span> <span data-ttu-id="6d836-158">コードをフォークする必要はありません。</span><span class="sxs-lookup"><span data-stu-id="6d836-158">There's no need to fork your code.</span></span>

<span data-ttu-id="6d836-159">このメソッドを使用することで、AUMID を常に提供する必要なしに、compat API を呼び出して通知を送信および管理できます。</span><span class="sxs-lookup"><span data-stu-id="6d836-159">This method allows you to call the compat APIs to send and manage notifications without having to constantly provide your AUMID.</span></span> <span data-ttu-id="6d836-160">またこのメソッドによって、COM サーバーの LocalServer32 レジストリ キーが挿入されます。</span><span class="sxs-lookup"><span data-stu-id="6d836-160">And it inserts the LocalServer32 registry key for the COM server.</span></span>


## <a name="step-6-register-com-activator"></a><span data-ttu-id="6d836-161">手順 6: COM サーバーを登録する</span><span class="sxs-lookup"><span data-stu-id="6d836-161">Step 6: Register COM activator</span></span>

<span data-ttu-id="6d836-162">デスクトップ ブリッジと従来の Win32 アプリのいずれを使用する場合も、トーストのアクティブ化を処理するためには、通知アクティベーター タイプを登録する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6d836-162">For both Desktop Bridge and classic Win32 apps, you must register your notification activator type, so that you can handle toast activations.</span></span>

<span data-ttu-id="6d836-163">アプリのスタートアップ コードで、次の **RegisterActivator**メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="6d836-163">In your app's startup code, call the following **RegisterActivator** method.</span></span> <span data-ttu-id="6d836-164">これにより、トーストのアクティブ化を受信できるようになります。</span><span class="sxs-lookup"><span data-stu-id="6d836-164">This must be called in order for you to receive any toast activations.</span></span>

```cpp
// Register activator type
hr = DesktopNotificationManagerCompat::RegisterActivator();
```


## <a name="step-7-send-a-notification"></a><span data-ttu-id="6d836-165">手順 7: 通知を送信する</span><span class="sxs-lookup"><span data-stu-id="6d836-165">Step 7: Send a notification</span></span>

<span data-ttu-id="6d836-166">通知を送信する手順は、**DesktopNotificationManagerCompat** を使用して **ToastNotifier** を作成することを除き、UWP アプリとまったく同じです。</span><span class="sxs-lookup"><span data-stu-id="6d836-166">Sending a notification is identical to UWP apps, except that you will use **DesktopNotificationManagerCompat** to create a **ToastNotifier**.</span></span> <span data-ttu-id="6d836-167">デスクトップ ブリッジと従来の Win32 の間で異なる部分は、compat ライブラリによって自動的に処理されるため、コードをフォークする必要はありません。</span><span class="sxs-lookup"><span data-stu-id="6d836-167">The compat library automatically handles the difference between Desktop Bridge and classic Win32 so you do not have to fork your code.</span></span> <span data-ttu-id="6d836-168">従来の Win32 では、**RegisterAumidAndComServer** の呼び出し時に、指定した AUMID が compat ライブラリによってキャッシュされるため、AUMID を指定するタイミングや指定するかどうかを検討する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="6d836-168">For classic Win32, the compat library caches your AUMID you provided when calling **RegisterAumidAndComServer** so that you don't need to worry about when to provide or not provide the AUMID.</span></span>

<span data-ttu-id="6d836-169">レガシの Windows 8.1 のトースト通知テンプレートでは、手順 4 で作成した COM 通知アクティベーターがアクティブ化されないため、以下に示すように、**ToastGeneric** バインディングを必ず使用します。</span><span class="sxs-lookup"><span data-stu-id="6d836-169">Make sure you use the **ToastGeneric** binding as seen below since the legacy Windows 8.1 toast notification templates will not activate your COM notification activator you created in step #4.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="6d836-170">http イメージは、マニフェストにインターネット機能を持つデスクトップ ブリッジ アプリでのみサポートされます。</span><span class="sxs-lookup"><span data-stu-id="6d836-170">Http images are only supported in Desktop Bridge apps that have the internet capability in their manifest.</span></span> <span data-ttu-id="6d836-171">従来の Win32 アプリは http イメージをサポートしていないため、ローカル アプリ データにイメージをダウンロードし、それをローカルに参照する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6d836-171">Classic Win32 apps do not support http images; you must download the image to your local app data and reference it locally.</span></span>

```cpp
// Construct XML
ComPtr<IXmlDocument> doc;
hr = DesktopNotificationManagerCompat::CreateXmlDocumentFromString(
    L"<toast><visual><binding template='ToastGeneric'><text>Hello world</text></binding></visual></toast>",
    &doc);
if (SUCCEEDED(hr))
{
    // See full code sample to learn how to inject dynamic text, buttons, and more

    // Create the notifier
    // Classic Win32 apps MUST use the compat method to create the notifier
    ComPtr<IToastNotifier> notifier;
    hr = DesktopNotificationManagerCompat::CreateToastNotifier(&notifier);
    if (SUCCEEDED(hr))
    {
        // Create the notification itself (using helper method from compat library)
        ComPtr<IToastNotification> toast;
        hr = DesktopNotificationManagerCompat::CreateToastNotification(doc, &toast);
        if (SUCCEEDED(hr))
        {
            // And show it!
            hr = notifier->Show(toast.Get());
        }
    }
}
```

> [!IMPORTANT]
> <span data-ttu-id="6d836-172">従来の Win32 アプリでは、レガシ トースト テンプレート (ToastText02 など) を使用できません。</span><span class="sxs-lookup"><span data-stu-id="6d836-172">Classic Win32 apps cannot use legacy toast templates (like ToastText02).</span></span> <span data-ttu-id="6d836-173">COM CLSID を指定すると、レガシ テンプレートのアクティブ化は失敗します。</span><span class="sxs-lookup"><span data-stu-id="6d836-173">Activation of the legacy templates will fail when the COM CLSID is specified.</span></span> <span data-ttu-id="6d836-174">上記のように Windows 10 ToastGeneric テンプレートを使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6d836-174">You must use the Windows 10 ToastGeneric templates as seen above.</span></span>


## <a name="step-8-handling-activation"></a><span data-ttu-id="6d836-175">手順 8: アクティブ化を処理する</span><span class="sxs-lookup"><span data-stu-id="6d836-175">Step 8: Handling activation</span></span>

<span data-ttu-id="6d836-176">ユーザーがトースト、またはトーストのボタンをクリックすると、**NotificationActivator** クラスの **Activate** メソッドが呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="6d836-176">When the user clicks on your toast, or buttons in the toast, the **Activate** method of your **NotificationActivator** class is invoked.</span></span>

<span data-ttu-id="6d836-177">Activate メソッド内では、トーストで指定した引数を解析し、ユーザーが入力または選択したユーザー入力を取得したうえで、それに応じてアプリをアクティブ化できます。</span><span class="sxs-lookup"><span data-stu-id="6d836-177">Inside the Activate method, you can parse the args that you specified in the toast and obtain the user input that the user typed or selected, and then activate your app accordingly.</span></span>

> [!NOTE]
> <span data-ttu-id="6d836-178">**Activate** メソッドは、メイン スレッドとは別のスレッドで呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="6d836-178">The **Activate** method is called on a separte thread from your main thread.</span></span>

```cpp
// The GUID must be unique to your app. Create a new GUID if copying this code.
class DECLSPEC_UUID("replaced-with-your-guid-C173E6ADF0C3") NotificationActivator WrlSealed WrlFinal
    : public RuntimeClass<RuntimeClassFlags<ClassicCom>, INotificationActivationCallback>
{
public: 
    virtual HRESULT STDMETHODCALLTYPE Activate(
        _In_ LPCWSTR appUserModelId,
        _In_ LPCWSTR invokedArgs,
        _In_reads_(dataCount) const NOTIFICATION_USER_INPUT_DATA* data,
        ULONG dataCount) override
    {
        std::wstring arguments(invokedArgs);
        HRESULT hr = S_OK;

        // Background: Quick reply to the conversation
        if (arguments.find(L"action=reply") == 0)
        {
            // Get the response user typed.
            // We know this is first and only user input since our toasts only have one input
            LPCWSTR response = data[0].Value;

            hr = DesktopToastsApp::SendResponse(response);
        }

        else
        {
            // The remaining scenarios are foreground activations,
            // so we first make sure we have a window open and in foreground
            hr = DesktopToastsApp::GetInstance()->OpenWindowIfNeeded();
            if (SUCCEEDED(hr))
            {
                // Open the image
                if (arguments.find(L"action=viewImage") == 0)
                {
                    hr = DesktopToastsApp::GetInstance()->OpenImage();
                }

                // Open the app itself
                // User might have clicked on app title in Action Center which launches with empty args
                else
                {
                    // Nothing to do, already launched
                }
            }
        }

        if (FAILED(hr))
        {
            // Log failed HRESULT
        }

        return S_OK;
    }

    ~NotificationActivator()
    {
        // If we don't have window open
        if (!DesktopToastsApp::GetInstance()->HasWindow())
        {
            // Exit (this is for background activation scenarios)
            exit(0);
        }
    }
};

// Flag class as COM creatable
CoCreatableClass(NotificationActivator);
```

<span data-ttu-id="6d836-179">アプリが閉じている間の起動を適切にサポートするため、WinMain 関数内で、トーストから起動しているかどうかを判定することができます。</span><span class="sxs-lookup"><span data-stu-id="6d836-179">To properly support being launched while your app is closed, in your WinMain function, you'll want to determine whether you're being launched from a toast or not.</span></span> <span data-ttu-id="6d836-180">トーストから起動している場合は、起動引数が "-ToastActivated" に指定されています。</span><span class="sxs-lookup"><span data-stu-id="6d836-180">If launched from a toast, there will be a launch arg of "-ToastActivated".</span></span> <span data-ttu-id="6d836-181">この引数が指定されている場合、通常の起動アクティブ化コードの実行をすべて停止し、必要に応じて **NotificationActivator** によるウィンドウの起動処理が完了するのを待つ必要があります。</span><span class="sxs-lookup"><span data-stu-id="6d836-181">When you see this, you should stop performing any normal launch activation code, and allow your **NotificationActivator** to handle launching windows if needed.</span></span>

```cpp
// Main function
int WINAPI wWinMain(_In_ HINSTANCE hInstance, _In_opt_ HINSTANCE, _In_ LPWSTR cmdLineArgs, _In_ int)
{
    RoInitializeWrapper winRtInitializer(RO_INIT_MULTITHREADED);

    HRESULT hr = winRtInitializer;
    if (SUCCEEDED(hr))
    {
        // Register AUMID and COM server (for Desktop Bridge apps, this no-ops)
        hr = DesktopNotificationManagerCompat::RegisterAumidAndComServer(L"WindowsNotifications.DesktopToastsCpp", __uuidof(NotificationActivator));
        if (SUCCEEDED(hr))
        {
            // Register activator type
            hr = DesktopNotificationManagerCompat::RegisterActivator();
            if (SUCCEEDED(hr))
            {
                DesktopToastsApp app;
                app.SetHInstance(hInstance);

                std::wstring cmdLineArgsStr(cmdLineArgs);

                // If launched from toast
                if (cmdLineArgsStr.find(TOAST_ACTIVATED_LAUNCH_ARG) != std::string::npos)
                {
                    // Let our NotificationActivator handle activation
                }

                else
                {
                    // Otherwise launch like normal
                    app.Initialize(hInstance);
                }

                app.RunMessageLoop();
            }
        }
    }

    return SUCCEEDED(hr);
}
```


### <a name="activation-sequence-of-events"></a><span data-ttu-id="6d836-182">イベントのアクティブ化シーケンス</span><span class="sxs-lookup"><span data-stu-id="6d836-182">Activation sequence of events</span></span>

<span data-ttu-id="6d836-183">アクティブ化シーケンスは、次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="6d836-183">The activation sequence is the following...</span></span>

<span data-ttu-id="6d836-184">アプリが既に実行されている場合:</span><span class="sxs-lookup"><span data-stu-id="6d836-184">If your app is already running:</span></span>

1. <span data-ttu-id="6d836-185">**NotificationActivator** で **Activate** が呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="6d836-185">**Activate** in your **NotificationActivator** is called</span></span>

<span data-ttu-id="6d836-186">アプリが実行されていない場合:</span><span class="sxs-lookup"><span data-stu-id="6d836-186">If your app is not running:</span></span>

1. <span data-ttu-id="6d836-187">アプリが EXE 起動され、"-ToastActivated" というコマンド ライン引数を取得します。</span><span class="sxs-lookup"><span data-stu-id="6d836-187">Your app is EXE launched, you get a command line args of "-ToastActivated"</span></span>
2. <span data-ttu-id="6d836-188">**NotificationActivator** で **Activate** が呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="6d836-188">**Activate** in your **NotificationActivator** is called</span></span>


### <a name="foreground-vs-background-activation"></a><span data-ttu-id="6d836-189">フォアグラウンドとバックグラウンドのアクティブ化</span><span class="sxs-lookup"><span data-stu-id="6d836-189">Foreground vs background activation</span></span>
<span data-ttu-id="6d836-190">デスクトップ アプリでは、フォア グラウンドとバック グラウンドのアクティブ化はいずれも、COM アクティベーターの呼び出しという同じ手順で処理されます。</span><span class="sxs-lookup"><span data-stu-id="6d836-190">For desktop apps, foreground and background activation is handled identically - your COM activator is called.</span></span> <span data-ttu-id="6d836-191">ウィンドウを表示するか、ウィンドウを表示せずに作業を行うだけで終了するかは、アプリのコードによって決定されます。</span><span class="sxs-lookup"><span data-stu-id="6d836-191">It's up to your app's code to decide whether to show a window or to simply perform some work and then exit.</span></span> <span data-ttu-id="6d836-192">したがって、トーストのコンテンツで **activationType** に **background** を指定しても、動作は変わりません。</span><span class="sxs-lookup"><span data-stu-id="6d836-192">Therefore, specifying an **activationType** of **background** in your toast content doesn't change the behavior.</span></span>


## <a name="step-9-remove-and-manage-notifications"></a><span data-ttu-id="6d836-193">手順 9: 通知を削除および管理する</span><span class="sxs-lookup"><span data-stu-id="6d836-193">Step 9: Remove and manage notifications</span></span>

<span data-ttu-id="6d836-194">通知を削除および管理する手順は、UWP アプリと同じです。</span><span class="sxs-lookup"><span data-stu-id="6d836-194">Removing and managing notifications is identical to UWP apps.</span></span> <span data-ttu-id="6d836-195">ただし、compat ライブラリを使用して **DesktopNotificationHistoryCompat** を取得することをお勧めします。これにより、従来の Win32 を使用している場合も、AUMID を提供する必要がなくなります。</span><span class="sxs-lookup"><span data-stu-id="6d836-195">However, we recommend you use our compat library to obtain a **DesktopNotificationHistoryCompat** so you don't have to worry about providing the AUMID if you're using classic Win32.</span></span>

```cpp
std::unique_ptr<DesktopNotificationHistoryCompat> history;
auto hr = DesktopNotificationManagerCompat::get_History(&history);
if (SUCCEEDED(hr))
{
    // Remove a specific toast
    hr = history->Remove(L"Message2");

    // Clear all toasts
    hr = history->Clear();
}
```


## <a name="step-10-deploying-and-debugging"></a><span data-ttu-id="6d836-196">手順 10: 展開とデバッグ</span><span class="sxs-lookup"><span data-stu-id="6d836-196">Step 10: Deploying and debugging</span></span>

<span data-ttu-id="6d836-197">デスクトップ ブリッジ アプリの展開とデバッグについては、「[パッケージ デスクトップ アプリの実行、デバッグ、テスト](/porting/desktop-to-uwp-debug.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6d836-197">To deploy and debug your Desktop Bridge app, see [Run, debug, and test a packaged desktop app](/porting/desktop-to-uwp-debug.md).</span></span>

<span data-ttu-id="6d836-198">従来の Win32 アプリを展開およびデバッグするには、通常のデバッグ前に、アプリをインストーラー経由でインストールして、AUMID と CLSID を使用したスタート ショートカットを表示する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6d836-198">To deploy and debug your classic Win32 app, you must install your app through the installer once before debugging normally, so that the Start shortcut with your AUMID and CLSID is present.</span></span> <span data-ttu-id="6d836-199">スタート ショートカットが表示された後は、Visual Studio で F5 キーを使用してデバッグできます。</span><span class="sxs-lookup"><span data-stu-id="6d836-199">After the Start shortcut is present, you can debug using F5 from Visual Studio.</span></span>

<span data-ttu-id="6d836-200">従来の Win32 アプリに通知がまったく表示されない場合 (かつ例外がスローされない場合)、原因として、スタート ショートカットが存在しないか (インストーラー経由でアプリをインストールしてください)、コード内で使用されている AUMID とスタート ショートカットの AUMID が一致していないことが考えられます。</span><span class="sxs-lookup"><span data-stu-id="6d836-200">If your notifications simply fail to appear in your classic Win32 app (and no exceptions are thrown), that likely means the Start shortcut isn't present (install your app via the installer), or the AUMID you used in code doesn't match the AUMID in your Start shortcut.</span></span>

<span data-ttu-id="6d836-201">通知は表示されるが、アクション センターに表示されたままにならない (ポップアップを無視すると表示されなくなる) 場合は、COM アクティベーターが正しく実装されていません。</span><span class="sxs-lookup"><span data-stu-id="6d836-201">If your notifications appear but aren't persisted in Action Center (disappearing after the popup is dismissed), that means you haven't implemented the COM activator correctly.</span></span>

<span data-ttu-id="6d836-202">デスクトップ ブリッジ アプリと従来の Win32 アプリの両方をインストールした場合、トーストのアクティブ化を処理するときに、デスクトップ ブリッジ アプリが従来の Win32 アプリに優先することに注意してください。</span><span class="sxs-lookup"><span data-stu-id="6d836-202">If you've installed both your Desktop Bridge and classic Win32 app, note that the Desktop Bridge app will supersede the classic Win32 app when handling toast activations.</span></span> <span data-ttu-id="6d836-203">そのため、従来の Win32 アプリから表示されたトーストをクリックしても、デスクトップ ブリッジ アプリが起動します。</span><span class="sxs-lookup"><span data-stu-id="6d836-203">That means that toasts from the classic Win32 app will still launch the Desktop Bridge app when clicked.</span></span> <span data-ttu-id="6d836-204">デスクトップ ブリッジ アプリをアンインストールすると、従来の Win32 アプリがアクティブ化されます。</span><span class="sxs-lookup"><span data-stu-id="6d836-204">Uninstalling the Desktop Bridge app will revert activations back to the classic Win32 app.</span></span>

<span data-ttu-id="6d836-205">`HRESULT 0x800401f0 CoInitialize has not been called.` が発生する場合は、アプリで `CoInitialize(nullptr)` を呼び出した後に API を呼び出していることを確認してください。</span><span class="sxs-lookup"><span data-stu-id="6d836-205">If you receive `HRESULT 0x800401f0 CoInitialize has not been called.`, be sure to call `CoInitialize(nullptr)` in your app before calling the APIs.</span></span>

<span data-ttu-id="6d836-206">compat API の呼び出し中に、`HRESULT 0x8000000e A method was called at an unexpected time.` が発生する場合は、必要な Register メソッドが呼び出されていない可能性があります (またはデスクトップ ブリッジ アプリの場合、現在、デスクトップ ブリッジのコンテキストでアプリが実行されていません)。</span><span class="sxs-lookup"><span data-stu-id="6d836-206">If you receive `HRESULT 0x8000000e A method was called at an unexpected time.` while calling the Compat APIs, that likely means you failed to call the required Register methods (or if a Desktop Bridge app, you're not currently running your app under the Desktop Bridge context).</span></span>

<span data-ttu-id="6d836-207">多数の `unresolved external symbol` コンパイル エラーが発生する場合、手順 1 で **[追加の依存ファイル]** に `runtimeobject.lib` を追加していない (または [Debug] の構成にのみ追加し、[Release] の構成には追加していない) 可能性があります。</span><span class="sxs-lookup"><span data-stu-id="6d836-207">If you get numerous `unresolved external symbol` compilation errors, you likely forgot to add `runtimeobject.lib` to the **Additional Dependencies** in step #1 (or you only added it to the Debug configuration and not Release configuration).</span></span>


## <a name="handling-older-versions-of-windows"></a><span data-ttu-id="6d836-208">従来のバージョンの Windows の処理</span><span class="sxs-lookup"><span data-stu-id="6d836-208">Handling older versions of Windows</span></span>

<span data-ttu-id="6d836-209">Windows 8.1 以下をサポートする場合は、実行時に Windows 10 を実行しているかどうかを確認した後、**DesktopNotificationManagerCompat** API の呼び出しや、ToastGeneric トースト通知の送信を行います。</span><span class="sxs-lookup"><span data-stu-id="6d836-209">If you support Windows 8.1 or lower, you'll want to check at runtime whether you're running on Windows 10 before calling any **DesktopNotificationManagerCompat** APIs or sending any ToastGeneric toasts.</span></span>

<span data-ttu-id="6d836-210">トースト通知は Windows 8 で導入されましたが、ToastText01 などの[レガシ トースト テンプレート](https://docs.microsoft.com/en-us/previous-versions/windows/apps/hh761494(v=win.10))が使用されていました。</span><span class="sxs-lookup"><span data-stu-id="6d836-210">Windows 8 introduced toast notifications, but used the [legacy toast templates](https://docs.microsoft.com/en-us/previous-versions/windows/apps/hh761494(v=win.10)), like ToastText01.</span></span> <span data-ttu-id="6d836-211">トーストは短時間のポップアップにすぎず、継続的に表示されるものではなかったため、**ToastNotification** クラスのインメモリ **Activated** イベントによって処理されていました。</span><span class="sxs-lookup"><span data-stu-id="6d836-211">Activation was handled by the in-memory **Activated** event on the **ToastNotification** class since toasts were only brief popups that weren't persisted.</span></span> <span data-ttu-id="6d836-212">Windows 10 では、[対話型の ToastGeneric トースト](adaptive-interactive-toasts.md) が導入され、さらに通知が数日間継続して表示されるアクション センターが導入されました。</span><span class="sxs-lookup"><span data-stu-id="6d836-212">Windows 10 introduced [interactive ToastGeneric toasts](adaptive-interactive-toasts.md), and also introduced Action Center where notifications are persisted for multiple days.</span></span> <span data-ttu-id="6d836-213">アクション センターの導入には、トーストが作成から数日後もアクティブ化できるように、COM アクティベーターの導入が必須でした。</span><span class="sxs-lookup"><span data-stu-id="6d836-213">The introduction of Action Center required the introduction of a COM activator, so that your toast can be activated days after you created it.</span></span>

| <span data-ttu-id="6d836-214">OS</span><span class="sxs-lookup"><span data-stu-id="6d836-214">OS</span></span> | <span data-ttu-id="6d836-215">ToastGeneric</span><span class="sxs-lookup"><span data-stu-id="6d836-215">ToastGeneric</span></span> | <span data-ttu-id="6d836-216">COM アクティベーター</span><span class="sxs-lookup"><span data-stu-id="6d836-216">COM activator</span></span> | <span data-ttu-id="6d836-217">レガシ トースト テンプレート</span><span class="sxs-lookup"><span data-stu-id="6d836-217">Legacy toast templates</span></span> |
| -- | ------------ | ------------- | ---------------------- |
| <span data-ttu-id="6d836-218">Windows 10</span><span class="sxs-lookup"><span data-stu-id="6d836-218">Windows 10</span></span> | <span data-ttu-id="6d836-219">サポート対象</span><span class="sxs-lookup"><span data-stu-id="6d836-219">Supported</span></span> | <span data-ttu-id="6d836-220">サポート対象</span><span class="sxs-lookup"><span data-stu-id="6d836-220">Supported</span></span> | <span data-ttu-id="6d836-221">サポート対象 (ただし COM サーバーをアクティブ化しない)</span><span class="sxs-lookup"><span data-stu-id="6d836-221">Supported (but won't activate COM server)</span></span> |
| <span data-ttu-id="6d836-222">Windows 8.1 / 8</span><span class="sxs-lookup"><span data-stu-id="6d836-222">Windows 8.1 / 8</span></span> | <span data-ttu-id="6d836-223">該当せず</span><span class="sxs-lookup"><span data-stu-id="6d836-223">N/A</span></span> | <span data-ttu-id="6d836-224">該当せず</span><span class="sxs-lookup"><span data-stu-id="6d836-224">N/A</span></span> | <span data-ttu-id="6d836-225">サポート対象</span><span class="sxs-lookup"><span data-stu-id="6d836-225">Supported</span></span> |
| <span data-ttu-id="6d836-226">Windows 7 以下</span><span class="sxs-lookup"><span data-stu-id="6d836-226">Windows 7 and lower</span></span> | <span data-ttu-id="6d836-227">該当せず</span><span class="sxs-lookup"><span data-stu-id="6d836-227">N/A</span></span> | <span data-ttu-id="6d836-228">なし</span><span class="sxs-lookup"><span data-stu-id="6d836-228">N/A</span></span> | <span data-ttu-id="6d836-229">該当せず</span><span class="sxs-lookup"><span data-stu-id="6d836-229">N/A</span></span> |

<span data-ttu-id="6d836-230">Windows 10 で実行しているかどうかを確認するには、`<VersionHelpers.h>` ヘッダーをインクルードし、**IsWindows10OrGreater** メソッドを確認します。</span><span class="sxs-lookup"><span data-stu-id="6d836-230">To check if you're running on Windows 10, include the `<VersionHelpers.h>` header and check the **IsWindows10OrGreater** method.</span></span> <span data-ttu-id="6d836-231">これが true を返す場合は、続いてこのドキュメントで説明されているすべてのメソッドを呼び出してください。</span><span class="sxs-lookup"><span data-stu-id="6d836-231">If this returns true, continue calling all the methods described in this documentation!</span></span> 

```cpp
#include <VersionHelpers.h>

if (IsWindows10OrGreater())
{
    // Running Windows 10, continue with sending Windows 10 toasts!
}
```


## <a name="known-issues"></a><span data-ttu-id="6d836-232">既知の問題</span><span class="sxs-lookup"><span data-stu-id="6d836-232">Known issues</span></span>

<span data-ttu-id="6d836-233">**修正済み: トーストのクリック後、アプリがフォーカスされない**: ビルド 15063 以前では、COM サーバーをアクティブ化したときに、フォアグラウンドの権利がアプリケーションに移転されませんでした。</span><span class="sxs-lookup"><span data-stu-id="6d836-233">**FIXED: App doesn't become focused after clicking toast**: In builds 15063 and earlier, foreground rights weren't being transferred to your application when we activated the COM server.</span></span> <span data-ttu-id="6d836-234">そのため、アプリをフォアグラウンドに移動しようとしても、点滅するのみで移動できませんでした。</span><span class="sxs-lookup"><span data-stu-id="6d836-234">Therefore, your app would simply flash when you tried to move it to the foreground.</span></span> <span data-ttu-id="6d836-235">この問題を解決する方法はありませんでした。</span><span class="sxs-lookup"><span data-stu-id="6d836-235">There was no workaround for this issue.</span></span> <span data-ttu-id="6d836-236">この問題は、16299 以降のビルドでは解決済みです。</span><span class="sxs-lookup"><span data-stu-id="6d836-236">We fixed this in builds 16299 and higher.</span></span>


## <a name="resources"></a><span data-ttu-id="6d836-237">リソース</span><span class="sxs-lookup"><span data-stu-id="6d836-237">Resources</span></span>

* [<span data-ttu-id="6d836-238">GitHub での完全なコード サンプル</span><span class="sxs-lookup"><span data-stu-id="6d836-238">Full code sample on GitHub</span></span>](https://github.com/WindowsNotifications/desktop-toasts)
* [<span data-ttu-id="6d836-239">デスクトップ アプリからのトースト通知</span><span class="sxs-lookup"><span data-stu-id="6d836-239">Toast notifications from desktop apps</span></span>](toast-desktop-apps.md)
* [<span data-ttu-id="6d836-240">トースト コンテンツのドキュメント</span><span class="sxs-lookup"><span data-stu-id="6d836-240">Toast content documentation</span></span>](adaptive-interactive-toasts.md)