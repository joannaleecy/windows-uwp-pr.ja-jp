---
author: TylerMSFT
title: ユニバーサル Windows プラットフォームを使用してコンソール アプリを作成する
description: このトピックでは、コンソールウィンドウで実行される UWP アプリを記述する方法について説明します。
keywords: console uwp
ms.author: twhitney
ms.date: 08/02/2018
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 7e5923176f5f9fff1a6e4f30a7ba2419e99c074b
ms.sourcegitcommit: 3257416aebb5a7b1515e107866806f8bd57845a8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/17/2018
ms.locfileid: "7163782"
---
# <a name="create-a-universal-windows-platform-console-app"></a><span data-ttu-id="eeacc-104">ユニバーサル Windows プラットフォームを使用してコンソール アプリを作成する</span><span class="sxs-lookup"><span data-stu-id="eeacc-104">Create a Universal Windows Platform console app</span></span>

<span data-ttu-id="eeacc-105">作成する方法について説明、 [、C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)または、C++/cli CX ユニバーサル Windows プラットフォーム (UWP) コンソール アプリです。</span><span class="sxs-lookup"><span data-stu-id="eeacc-105">This topic describes how to create a [C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt) or C++/CX Universal Windows Platform (UWP) console app.</span></span>

<span data-ttu-id="eeacc-106">Windows 10、バージョン 1803 以降では次のことに書き込み、C++/WinRT または C + +/CX の UWP コンソール アプリ DOS や PowerShell コンソール ウィンドウなどのコンソール ウィンドウで実行できます。</span><span class="sxs-lookup"><span data-stu-id="eeacc-106">Starting with Windows 10, version 1803, you can write C++/WinRT or C++/CX UWP console apps that run in a console window, such as a DOS or PowerShell console window.</span></span> <span data-ttu-id="eeacc-107">コンソール アプリは、入力と出力、コンソール ウィンドウを使用し、 **printf**と**getchar**などの[ユニバーサル C ランタイム](/cpp/c-runtime-library/reference/crt-alphabetical-function-reference)の機能を使用できます。</span><span class="sxs-lookup"><span data-stu-id="eeacc-107">Console apps use the console window for input and output, and can use [Universal C Runtime](/cpp/c-runtime-library/reference/crt-alphabetical-function-reference) functions such as **printf** and **getchar**.</span></span> <span data-ttu-id="eeacc-108">Microsoft Store には、UWP コンソール アプリを公開することができます。</span><span class="sxs-lookup"><span data-stu-id="eeacc-108">UWP console apps can be published to the Microsoft Store.</span></span> <span data-ttu-id="eeacc-109">それらのアプリは、アプリのリストにエントリがあり、スタート メニューに固定することができるプライマリ タイルがあります。</span><span class="sxs-lookup"><span data-stu-id="eeacc-109">They have an entry in the app list, and a primary tile that can be pinned to the Start menu.</span></span> <span data-ttu-id="eeacc-110">UWP コンソール アプリは、コマンドラインから起動するは通常、スタート メニューから起動できます。</span><span class="sxs-lookup"><span data-stu-id="eeacc-110">UWP console apps can be launched from the Start menu, though you will typically launch them from the command-line.</span></span>

<span data-ttu-id="eeacc-111">いずれかの動作を確認するには、UWP コンソール アプリの作成に関するビデオを次に示します。</span><span class="sxs-lookup"><span data-stu-id="eeacc-111">To see one in action, here's a video about Creating a UWP Console App.</span></span>

> [!VIDEO https://www.youtube.com/embed/bwvfrguY20s]

## <a name="use-a-uwp-console-app-template"></a><span data-ttu-id="eeacc-112">UWP コンソール アプリ テンプレートを使用する</span><span class="sxs-lookup"><span data-stu-id="eeacc-112">Use a UWP Console app template</span></span> 

<span data-ttu-id="eeacc-113">UWP コンソール アプリを作成するには、まず [Visual Studio Marketplace](https://marketplace.visualstudio.com/items?itemName=AndrewWhitechapelMSFT.ConsoleAppUniversal) から入手できる**コンソール アプリ (ユニバーサル) プロジェクト テンプレート**をインストールします。</span><span class="sxs-lookup"><span data-stu-id="eeacc-113">To create a UWP console app, first install the **Console App (Universal) Project Templates**, available from the [Visual Studio Marketplace](https://marketplace.visualstudio.com/items?itemName=AndrewWhitechapelMSFT.ConsoleAppUniversal).</span></span> <span data-ttu-id="eeacc-114">インストール済みのテンプレートを利用し、[**新しいプロジェクト**] で > **インストール済み** > **他の言語** > **Visual C** > **Windows ユニバーサル\*\*\*\*コンソール アプリの内容として/WinRT (ユニバーサル Windows)** と**コンソール アプリ C + + CX (ユニバーサル Windows)** します。</span><span class="sxs-lookup"><span data-stu-id="eeacc-114">The installed templates are then available under **New Project** > **Installed** > **Other Languages** > **Visual C++** > **Windows Universal** as **Console App C++/WinRT (Universal Windows)** and **Console App C++/CX (Universal Windows)**.</span></span>

## <a name="add-your-code-to-main"></a><span data-ttu-id="eeacc-115">Main() にコードを追加します。</span><span class="sxs-lookup"><span data-stu-id="eeacc-115">Add your code to main()</span></span>

<span data-ttu-id="eeacc-116">テンプレートは **Program.cpp** を追加します。これには `main()` 関数が含まれています。</span><span class="sxs-lookup"><span data-stu-id="eeacc-116">The templates add **Program.cpp**, which contains the `main()` function.</span></span> <span data-ttu-id="eeacc-117">これは、UWP コンソール アプリで実行が開始される場所です。</span><span class="sxs-lookup"><span data-stu-id="eeacc-117">This is where execution begins in a UWP console app.</span></span> <span data-ttu-id="eeacc-118">`__argc` および `__argv` パラメーターでコマンドライン引数にアクセスします。</span><span class="sxs-lookup"><span data-stu-id="eeacc-118">Access the command-line arguments with the `__argc` and `__argv` parameters.</span></span> <span data-ttu-id="eeacc-119">制御が `main()` から返ってくると、UWP コンソール アプリは終了します。</span><span class="sxs-lookup"><span data-stu-id="eeacc-119">The UWP console app exits when control returns from `main()`.</span></span>

<span data-ttu-id="eeacc-120">**Program.cpp**の次の例がによって追加された、**コンソール アプリの内容/WinRT**テンプレート。</span><span class="sxs-lookup"><span data-stu-id="eeacc-120">The following example of **Program.cpp** is added by the **Console App C++/WinRT** template:</span></span>

```cppwinrt
#include "pch.h"

using namespace winrt;

// This example code shows how you could implement the required main function
// for a Console UWP Application. You can replace all the code inside main
// with your own custom code.

int __cdecl main()
{
    // You can get parsed command-line arguments from the CRT globals.
    wprintf(L"Parsed command-line arguments:\n");
    for (int i = 0; i < __argc; i++)
    {
        wprintf(L"__argv[%d] = %S\n", i, __argv[i]);
    }

    // Keep the console window alive in case you want to see console output when running from within Visual Studio
      wprintf(L"Press 'Enter' to continue: ");
    getchar();
}
```

## <a name="uwp-console-app-behavior"></a><span data-ttu-id="eeacc-121">UWP コンソール アプリの動作</span><span class="sxs-lookup"><span data-stu-id="eeacc-121">UWP Console app behavior</span></span>

<span data-ttu-id="eeacc-122">UWP コンソール アプリは、実行されているディレクトリ、およびその下のファイル システムにアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="eeacc-122">A UWP Console app can access the file-system from the directory it is run from, and below.</span></span> <span data-ttu-id="eeacc-123">テンプレートは [AppExecutionAlias](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-uap5-appexecutionalias) 拡張機能をアプリの Package.appxmanifest ファイルに追加するため、これが可能になります。</span><span class="sxs-lookup"><span data-stu-id="eeacc-123">This is possible because the template adds the [AppExecutionAlias](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-uap5-appexecutionalias) extension to your app's Package.appxmanifest file.</span></span> <span data-ttu-id="eeacc-124">この拡張機能を使用すると、コンソール ウィンドウからエイリアスを入力してアプリを起動することもできます。</span><span class="sxs-lookup"><span data-stu-id="eeacc-124">This extension also enables the user to type the alias from a console window to launch the app.</span></span> <span data-ttu-id="eeacc-125">アプリを起動するためにシステムパスに入る必要はありません。</span><span class="sxs-lookup"><span data-stu-id="eeacc-125">The app does not need to be in the system path to launch.</span></span>

<span data-ttu-id="eeacc-126">さらに、[ファイル アクセス許可](https://docs.microsoft.com/windows/uwp/files/file-access-permissions) で説明されているように、制限された機能 `broadFileSystemAccess` を追加することで、ファイルシステムへの広範なアクセスを UWP コンソール アプリに付与することができます。</span><span class="sxs-lookup"><span data-stu-id="eeacc-126">You can additionally give broad access to the file system to your UWP console app by adding the restricted capability `broadFileSystemAccess` as described in [File access permissions](https://docs.microsoft.com/windows/uwp/files/file-access-permissions).</span></span> <span data-ttu-id="eeacc-127">この機能は、[**Windows.Storage**](https://msdn.microsoft.com/library/windows/apps/BR227346) 名前空間の API で動作します。</span><span class="sxs-lookup"><span data-stu-id="eeacc-127">This capability works with APIs in the [**Windows.Storage**](https://msdn.microsoft.com/library/windows/apps/BR227346) namespace.</span></span>

<span data-ttu-id="eeacc-128">テンプレートによって [SupportsMultipleInstances](multi-instance-uwp.md) 機能がアプリの Package.appxmanifest ファイルに追加されるため、複数の UWP コンソール アプリのインスタンスを同時に実行できます。</span><span class="sxs-lookup"><span data-stu-id="eeacc-128">More than one instance of a UWP Console app can run at a time because the template adds the [SupportsMultipleInstances](multi-instance-uwp.md) capability to your app's Package.appxmanifest file.</span></span>

<span data-ttu-id="eeacc-129">テンプレートは Package.appxmanifest ファイルに `Subsystem="console"` の機能も追加します。これは、この UWP アプリがコンソール アプリであることを示しています。</span><span class="sxs-lookup"><span data-stu-id="eeacc-129">The template also adds the `Subsystem="console"` capability to the Package.appxmanifest file, which denotes that this UWP app is a console app.</span></span> <span data-ttu-id="eeacc-130">`desktop4` と iot2 `namespace` プレフィックスに注意してください。</span><span class="sxs-lookup"><span data-stu-id="eeacc-130">Note the `desktop4` and iot2 `namespace` prefixes.</span></span> <span data-ttu-id="eeacc-131">UWP コンソール アプリは、デスクトップやモノのインターネット (IoT) プロジェクトでのみサポートされています。</span><span class="sxs-lookup"><span data-stu-id="eeacc-131">UWP Console apps are only supported on desktop and Internet of Things (IoT) projects.</span></span>

```xml
<Package
  ...
  xmlns:desktop4="http://schemas.microsoft.com/appx/manifest/desktop/windows10/4" 
  xmlns:iot2="http://schemas.microsoft.com/appx/manifest/iot/windows10/2" 
  IgnorableNamespaces="uap mp uap5 desktop4 iot2">
  ...
  <Applications>
    <Application Id="App"
      ...
      desktop4:Subsystem="console" 
      desktop4:SupportsMultipleInstances="true" 
      iot2:Subsystem="console" 
      iot2:SupportsMultipleInstances="true"  >
      ...
      <Extensions>
          <uap5:Extension 
            Category="windows.appExecutionAlias" 
            Executable="YourApp.exe" 
            EntryPoint="YourApp.App">
            <uap5:AppExecutionAlias desktop4:Subsystem="console">
              <uap5:ExecutionAlias Alias="YourApp.exe" />
            </uap5:AppExecutionAlias>
          </uap5:Extension>
      </Extensions>
    </Application>
  </Applications>
    ...
</Package>
```

## <a name="additional-considerations-for-uwp-console-apps"></a><span data-ttu-id="eeacc-132">UWP コンソール アプリに関するその他の考慮事項</span><span class="sxs-lookup"><span data-stu-id="eeacc-132">Additional considerations for UWP console apps</span></span>

- <span data-ttu-id="eeacc-133">のみ、C++/WinRT および C + +/CX の UWP アプリがコンソール アプリ。</span><span class="sxs-lookup"><span data-stu-id="eeacc-133">Only C++/WinRT and C++/CX UWP apps may be console apps.</span></span>
- <span data-ttu-id="eeacc-134">UWP コンソール アプリはデスクトップまたは IoT プロジェクト タイプをターゲットにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="eeacc-134">UWP Console apps must target the Desktop, or IoT project type.</span></span>
- <span data-ttu-id="eeacc-135">UWP コンソール アプリは、ウィンドウを作成しない場合があります。</span><span class="sxs-lookup"><span data-stu-id="eeacc-135">UWP console apps may not create a window.</span></span> <span data-ttu-id="eeacc-136">ユーザーの同意プロンプトなど、MessageBox() または Location()、何らかの理由で、ウィンドウが作成できるその他の API は使用できません。</span><span class="sxs-lookup"><span data-stu-id="eeacc-136">They cannot use MessageBox(), or Location(), or any other API that may create a window for any reason, such as user consent prompts.</span></span>
- <span data-ttu-id="eeacc-137">UWP コンソール アプリは、バックグラウンド タスクを消費したり、バックグラウンド タスクとして機能したりしない場合があります。</span><span class="sxs-lookup"><span data-stu-id="eeacc-137">UWP console apps may not consume background tasks nor serve as a background task.</span></span>
- <span data-ttu-id="eeacc-138">[コマンド ラインのアクティブ化](https://blogs.windows.com/buildingapps/2017/07/05/command-line-activation-universal-windows-apps/#5YJUzjBoXCL4MhAe.97) を除き、UWP コンソール アプリは、ファイルの関連付け、プロトコルの関連付けなどのアクティブ化をサポートしていません。</span><span class="sxs-lookup"><span data-stu-id="eeacc-138">With the exception of [Command-Line activation](https://blogs.windows.com/buildingapps/2017/07/05/command-line-activation-universal-windows-apps/#5YJUzjBoXCL4MhAe.97), UWP console apps do not support activation contracts, including file association, protocol association, etc.</span></span>
- <span data-ttu-id="eeacc-139">UWP コンソール アプリは複数インスタンスをサポートしていますが、[複数インスタンスのリダイレクト](multi-instance-uwp.md) はサポートしていません</span><span class="sxs-lookup"><span data-stu-id="eeacc-139">Although UWP console apps support multi-instancing, they do not support [Multi-instancing redirection](multi-instance-uwp.md)</span></span>
- <span data-ttu-id="eeacc-140">UWP アプリで使用できる Win32 API の一覧については、「[UWP アプリ用の Win32 API と COM API](https://docs.microsoft.com/uwp/win32-and-com/win32-and-com-for-uwp-apps)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="eeacc-140">For a list of Win32 APIs that are available to UWP apps, see [Win32 and COM APIs for UWP apps](https://docs.microsoft.com/uwp/win32-and-com/win32-and-com-for-uwp-apps)</span></span>