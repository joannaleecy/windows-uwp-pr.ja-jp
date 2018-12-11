---
title: Windows 10 ユニバーサル Windows プラットフォーム (UWP) アプリの自動起動
description: 開発者はプロトコルのアクティブ化および起動アクティブ化を使って、自動テスト用に UWP アプリや UWP ゲームを自動で起動できます。
ms.topic: article
ms.localizationpriority: medium
ms.date: 02/08/2017
ms.openlocfilehash: fb68b4bbd1b751591e9f336efe5dad3c22b3bf92
ms.sourcegitcommit: 8921a9cc0dd3e5665345ae8eca7ab7aeb83ccc6f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8890282"
---
# <a name="automate-launching-windows-10-uwp-apps"></a><span data-ttu-id="01d63-103">Windows 10 UWP アプリの自動起動</span><span class="sxs-lookup"><span data-stu-id="01d63-103">Automate launching Windows 10 UWP apps</span></span>

## <a name="introduction"></a><span data-ttu-id="01d63-104">はじめに</span><span class="sxs-lookup"><span data-stu-id="01d63-104">Introduction</span></span>

<span data-ttu-id="01d63-105">開発者はいくつかの方法でユニバーサル Windows プラットフォーム (UWP) アプリの自動起動を実現できます。</span><span class="sxs-lookup"><span data-stu-id="01d63-105">Developers have several options for achieving automated launching of Universal Windows Platform (UWP) apps.</span></span> <span data-ttu-id="01d63-106">ここでは、プロトコルのアクティブ化と起動アクティブ化を使ってアプリを起動する方法を説明します。</span><span class="sxs-lookup"><span data-stu-id="01d63-106">In this paper we will explore methods of launching an app by using protocol activation and launch activation.</span></span>

<span data-ttu-id="01d63-107">*プロトコルのアクティブ化*では、アプリ自体を特定のプロトコルのハンドラーとして登録できます。</span><span class="sxs-lookup"><span data-stu-id="01d63-107">*Protocol activation* allows an app to register itself as a handler for a given protocol.</span></span> 

<span data-ttu-id="01d63-108">*起動アクティブ化*では、アプリのタイルなど、通常の方法でアプリを起動します。</span><span class="sxs-lookup"><span data-stu-id="01d63-108">*Launch activation* is the normal launching of an app, such as launching from the app tile.</span></span>

<span data-ttu-id="01d63-109">これらのアクティブ化はどちらも、コマンド ラインまたはランチャー アプリケーションを使って実行できます。</span><span class="sxs-lookup"><span data-stu-id="01d63-109">With each activation method, you have the option of using the command line or a launcher application.</span></span> <span data-ttu-id="01d63-110">いずれの方法でアクティブ化を行う場合も、アプリが実行中のときは、アクティブ化によってアプリがフォアグラウンドになり (再アクティブ化され)、新しいアクティブ化引数が提供されます。</span><span class="sxs-lookup"><span data-stu-id="01d63-110">For all activation methods, if the app is currently running, the activation will bring the app to the foreground (which reactivates it) and provide the new activation arguments.</span></span> <span data-ttu-id="01d63-111">そのため、アクティブ化コマンドを使ってアプリに新しいメッセージを柔軟に提供できます。</span><span class="sxs-lookup"><span data-stu-id="01d63-111">This allows flexibility to use activation commands to provide new messages to the app.</span></span> <span data-ttu-id="01d63-112">アクティブ化メソッドで更新後の新しいアプリが実行されるようにするには、プロジェクトをコンパイルして展開する必要があることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="01d63-112">It is important to note that the project needs to be compiled and deployed for the activation method to run the newly updated app.</span></span> 

## <a name="protocol-activation"></a><span data-ttu-id="01d63-113">プロトコルのアクティブ化</span><span class="sxs-lookup"><span data-stu-id="01d63-113">Protocol activation</span></span>

<span data-ttu-id="01d63-114">アプリに対してプロトコルのアクティブ化を設定するには、次の手順に従います。</span><span class="sxs-lookup"><span data-stu-id="01d63-114">Follow these steps to set up protocol activation for apps:</span></span> 

1. <span data-ttu-id="01d63-115">Visual Studio で **Package.appxmanifest** ファイルを開きます。</span><span class="sxs-lookup"><span data-stu-id="01d63-115">Open the **Package.appxmanifest** file in Visual Studio.</span></span>
2. <span data-ttu-id="01d63-116">**[宣言]** タブをクリックします。</span><span class="sxs-lookup"><span data-stu-id="01d63-116">Select the **Declarations** tab.</span></span>
3. <span data-ttu-id="01d63-117">**[使用可能な宣言]** ボックスの一覧で **[プロトコル]** を選び、**[追加]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="01d63-117">Under the **Available Declarations** drop-down, select **Protocol**, and then select **Add**.</span></span>
4. <span data-ttu-id="01d63-118">**[プロパティ]** の **[名前]** フィールドに、アプリの起動に使うプロトコルの一意の名前を入力します。</span><span class="sxs-lookup"><span data-stu-id="01d63-118">Under **Properties**, in the **Name** field, enter a unique name to launch the app.</span></span> 

    ![プロトコルのアクティブ化](images/automate-uwp-apps-1.png)

5. <span data-ttu-id="01d63-120">ファイルを保存し、プロジェクトを展開します。</span><span class="sxs-lookup"><span data-stu-id="01d63-120">Save the file and deploy the project.</span></span> 
6. <span data-ttu-id="01d63-121">プロジェクトの展開が完了したら、プロトコルのアクティブ化を設定します。</span><span class="sxs-lookup"><span data-stu-id="01d63-121">After the project has been deployed, the protocol activation should be set.</span></span> 
7. <span data-ttu-id="01d63-122">**[コントロール パネル]、[すべてのコントロール パネル項目]、[既定のプログラム]** の順にクリックし、**[ファイルの種類またはプロトコルのプログラムへの関連付け]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="01d63-122">Go to **Control Panel\All Control Panel Items\Default Programs** and select **Associate a file type or protocol with a specific program**.</span></span> <span data-ttu-id="01d63-123">**[プロトコル]** セクションまでスクロールし、プロトコルが一覧に表示されていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="01d63-123">Scroll to the **Protocols** section to see if the protocol is listed.</span></span> 

<span data-ttu-id="01d63-124">プロトコルのアクティブ化を設定したら、2 つの方法 (コマンド ラインまたはランチャー アプリケーション) のどちらかを使用して、プロトコルを使ってアプリをアクティブ化できます。</span><span class="sxs-lookup"><span data-stu-id="01d63-124">Now that protocol activation is set up, you have two options (the command line or launcher application) for activating the app by using the protocol.</span></span> 

### <a name="command-line"></a><span data-ttu-id="01d63-125">コマンド ライン</span><span class="sxs-lookup"><span data-stu-id="01d63-125">Command line</span></span>

<span data-ttu-id="01d63-126">コマンド ラインでプロトコルのアクティブ化を使ってアプリを起動するには、start コマンドを使います。このコマンドで、先ほど設定したプロトコル名を指定し、コロン (“:”) に続けて任意のパラメーターを指定します。</span><span class="sxs-lookup"><span data-stu-id="01d63-126">The app can be protocol-activated by using the command line with the command start followed by the protocol name set previously, a colon (“:”), and any parameters.</span></span> <span data-ttu-id="01d63-127">パラメーターには任意の文字列を指定できますが、Uniform Resource Identifier (URI) の機能を利用できるように、URI の標準の形式に従うことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="01d63-127">The parameters can be any arbitrary string; however, to take advantage of the Uniform Resource Identifier (URI) capabilities, it is advisable to follow the standard URI format:</span></span> 

  ```
  scheme://username:password@host:port/path.extension?query#fragment
  ```

<span data-ttu-id="01d63-128">この形式の URI 文字列は、Uri オブジェクトのメソッドで解析できます。</span><span class="sxs-lookup"><span data-stu-id="01d63-128">The Uri object has methods of parsing a URI string in this format.</span></span> <span data-ttu-id="01d63-129">詳しくは、[MSDN の Uri クラスのトピック](https://msdn.microsoft.com/library/windows/apps/windows.foundation.uri.aspx)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="01d63-129">For more information, see [Uri class (MSDN)](https://msdn.microsoft.com/library/windows/apps/windows.foundation.uri.aspx).</span></span> 

<span data-ttu-id="01d63-130">例:</span><span class="sxs-lookup"><span data-stu-id="01d63-130">Examples:</span></span>

  ```
  >start bingnews:
  >start myapplication:protocol-parameter
  >start myapplication://single-player/level3?godmode=1&ammo=200
  ```

<span data-ttu-id="01d63-131">コマンド ラインによるプロトコルのアクティブ化では、生の URI で指定できる Unicode 文字は 2038 文字までに制限されます。</span><span class="sxs-lookup"><span data-stu-id="01d63-131">Protocol command-line activation supports Unicode characters up to a 2038-character limit on the raw URI.</span></span> 

### <a name="launcher-application"></a><span data-ttu-id="01d63-132">ランチャー アプリケーション</span><span class="sxs-lookup"><span data-stu-id="01d63-132">Launcher application</span></span>

<span data-ttu-id="01d63-133">WinRT API をサポートするアプリケーションを起動用に別途作成します。</span><span class="sxs-lookup"><span data-stu-id="01d63-133">For launching, create a separate application that supports the WinRT API.</span></span> <span data-ttu-id="01d63-134">プロトコルのアクティブ化を使ってアプリを起動するランチャー プログラムの C++ コードの例を次に示します。**PackageURI** は、アプリケーションの URI を示す任意の引数です (例: `myapplication:`、`myapplication:protocol activation arguments`)。</span><span class="sxs-lookup"><span data-stu-id="01d63-134">The C++ code for launching with protocol activation in a launcher program is shown in the following sample, where **PackageURI** is the URI for the application with any arguments; for example `myapplication:` or `myapplication:protocol activation arguments`.</span></span>

```
bool ProtocolLaunchURI(Platform::String^ URI)
{
       IAsyncOperation<bool>^ protocolLaunchAsyncOp;
       try
       {
              protocolLaunchAsyncOp = Windows::System::Launcher::LaunchUriAsync(ref new 
Uri(URI));
       }
       catch (Platform::Exception^ e)
       {
              Platform::String^ dbgStr = "ProtocolLaunchURI Exception Thrown: " 
+ e->ToString() + "\n";
              OutputDebugString(dbgStr->Data());
              return false;
       }

       concurrency::create_task(protocolLaunchAsyncOp).wait();

       if (protocolLaunchAsyncOp->Status == AsyncStatus::Completed)
       {
              bool LaunchResult = protocolLaunchAsyncOp->GetResults();
              Platform::String^ dbgStr = "ProtocolLaunchURI " + URI 
+ " completed. Launch result " + LaunchResult + "\n";
              OutputDebugString(dbgStr->Data());
              return LaunchResult;
       }
       else
       {
              Platform::String^ dbgStr = "ProtocolLaunchURI " + URI + " failed. Status:" 
+ protocolLaunchAsyncOp->Status.ToString() + " ErrorCode:" 
+ protocolLaunchAsyncOp->ErrorCode.ToString() + "\n";
              OutputDebugString(dbgStr->Data());
              return false;
       }
}
```
<span data-ttu-id="01d63-135">ランチャー アプリケーションでプロトコルのアクティブ化を行う場合も、引数の制限はコマンド ラインの場合と同じです。</span><span class="sxs-lookup"><span data-stu-id="01d63-135">Protocol activation with the launcher application has the same limitations for arguments as protocol activation with the command line.</span></span> <span data-ttu-id="01d63-136">どちらを使う場合も、生の URI で指定できる Unicode 文字は 2038 文字までです。</span><span class="sxs-lookup"><span data-stu-id="01d63-136">Both support Unicode characters up to a 2038-character limit on the raw URI.</span></span> 

## <a name="launch-activation"></a><span data-ttu-id="01d63-137">起動アクティブ化</span><span class="sxs-lookup"><span data-stu-id="01d63-137">Launch activation</span></span>

<span data-ttu-id="01d63-138">起動アクティブ化を使ってアプリを起動することもできます。</span><span class="sxs-lookup"><span data-stu-id="01d63-138">You can also launch the app by using launch activation.</span></span> <span data-ttu-id="01d63-139">セットアップは必要ありませんが、UWP アプリのアプリケーション ユーザー モデル ID (AUMID) が必要になります。</span><span class="sxs-lookup"><span data-stu-id="01d63-139">No setup is required, but the Application User Model ID (AUMID) of the UWP app is needed.</span></span> <span data-ttu-id="01d63-140">AUMID は、パッケージ ファミリ名とアプリケーション ID を感嘆符で区切った形式で表されます。</span><span class="sxs-lookup"><span data-stu-id="01d63-140">The AUMID is the package family name followed by an exclamation point and the application ID.</span></span> 

<span data-ttu-id="01d63-141">パッケージ ファミリ名を取得するには、次の手順に従うと最も簡単です。</span><span class="sxs-lookup"><span data-stu-id="01d63-141">The best way to obtain the package family name is to complete these steps:</span></span>

1. <span data-ttu-id="01d63-142">**Package.appxmanifest** ファイルを開きます。</span><span class="sxs-lookup"><span data-stu-id="01d63-142">Open the **Package.appxmanifest** file.</span></span>
2. <span data-ttu-id="01d63-143">**[パッケージ化]** タブで、**[パッケージ名]** を入力します。</span><span class="sxs-lookup"><span data-stu-id="01d63-143">On the **Packaging** tab, enter the **Package name**.</span></span>

    ![起動アクティブ化](images/automate-uwp-apps-2.png)

3. <span data-ttu-id="01d63-145">**[パッケージ ファミリ名]** が表示されない場合は、PowerShell を開いて `>get-appxpackage MyPackageName` を実行し、**PackageFamilyName** を探します。</span><span class="sxs-lookup"><span data-stu-id="01d63-145">If the **Package family name** is not listed, open PowerShell and run `>get-appxpackage MyPackageName` to find the **PackageFamilyName**.</span></span>

<span data-ttu-id="01d63-146">アプリケーション ID は、**Package.appxmanifest** ファイル (XML ビューで開く) の `<Applications>` 要素で確認できます。</span><span class="sxs-lookup"><span data-stu-id="01d63-146">The application ID can be found in the **Package.appxmanifest** file (opened in XML view) under the `<Applications>` element.</span></span>

### <a name="command-line"></a><span data-ttu-id="01d63-147">コマンド ライン</span><span class="sxs-lookup"><span data-stu-id="01d63-147">Command line</span></span>

<span data-ttu-id="01d63-148">UWP アプリの起動アクティブ化を実行するためのツールは Windows 10 SDK に付属しています。</span><span class="sxs-lookup"><span data-stu-id="01d63-148">A tool for performing a launch activation of a UWP app is installed with the Windows 10 SDK.</span></span> <span data-ttu-id="01d63-149">このツールはコマンド ラインから実行することができ、起動するアプリの AUMID を引数として指定できます。</span><span class="sxs-lookup"><span data-stu-id="01d63-149">It can be run from the command line, and it takes the AUMID of the app to be launched as an argument.</span></span>

```
C:\Program Files (x86)\Windows Kits\10\App Certification Kit\microsoft.windows.softwarelogo.appxlauncher.exe <AUMID>
```

<span data-ttu-id="01d63-150">たとえば、次のようになります。</span><span class="sxs-lookup"><span data-stu-id="01d63-150">It would look something like this:</span></span>

```
"C:\Program Files (x86)\Windows Kits\10\App Certification Kit\microsoft.windows.softwarelogo.appxlauncher.exe" MyPackageName_ph1m9x8skttmg!AppId
```

<span data-ttu-id="01d63-151">この方法では、コマンド ライン引数はサポートされません。</span><span class="sxs-lookup"><span data-stu-id="01d63-151">This option does not support command-line arguments.</span></span> 

### <a name="launcher-application"></a><span data-ttu-id="01d63-152">ランチャー アプリケーション</span><span class="sxs-lookup"><span data-stu-id="01d63-152">Launcher application</span></span>

<span data-ttu-id="01d63-153">COM の使用をサポートするアプリケーションを起動用に別途作成できます。</span><span class="sxs-lookup"><span data-stu-id="01d63-153">You can create a separate application that supports using COM to use for launching.</span></span> <span data-ttu-id="01d63-154">起動アクティブ化を使ってアプリを起動するランチャー プログラムの C++ コードの例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="01d63-154">The following example shows C++ code for launching with launch activation in a launcher program.</span></span> <span data-ttu-id="01d63-155">このコードでは、**ApplicationActivationManager** を作成して **ActivateApplication** を呼び出し、先ほど確認した AUMID と任意の引数を渡すことができます。</span><span class="sxs-lookup"><span data-stu-id="01d63-155">With this code, you can create an **ApplicationActivationManager** object and call **ActivateApplication** passing in the AUMID found previously and any arguments.</span></span> <span data-ttu-id="01d63-156">その他のパラメーターについて詳しくは、[MSDN の IApplicationActivationManager::ActivateApplication メソッドのトピック](https://msdn.microsoft.com/library/windows/desktop/hh706903(v=vs.85).aspx)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="01d63-156">For more information about the other parameters, see [IApplicationActivationManager::ActivateApplication method (MSDN)](https://msdn.microsoft.com/library/windows/desktop/hh706903(v=vs.85).aspx).</span></span>

```
#include <ShObjIdl.h>
#include <atlbase.h>

HRESULT LaunchApp(LPCWSTR AUMID)
{
     HRESULT hr = CoInitializeEx(nullptr, COINIT_APARTMENTTHREADED);
     if (FAILED(hr))
     {
            wprintf(L"LaunchApp %s: Failed to init COM. hr = 0x%08lx \n", AUMID, hr);
     }
     {
            CComPtr<IApplicationActivationManager> AppActivationMgr = nullptr;
            if (SUCCEEDED(hr))
            {
                   hr = CoCreateInstance(CLSID_ApplicationActivationManager, nullptr,  
CLSCTX_LOCAL_SERVER, IID_PPV_ARGS(&AppActivationMgr));
                   if (FAILED(hr))
                   {
                         wprintf(L"LaunchApp %s: Failed to create Application Activation 
Manager. hr = 0x%08lx \n", AUMID, hr);
                   }
            }
            if (SUCCEEDED(hr))
            {
                   DWORD pid = 0;
                   hr = AppActivationMgr->ActivateApplication(AUMID, nullptr, AO_NONE, 
&pid);
                   if (FAILED(hr))
                   {
                         wprintf(L"LaunchApp %s: Failed to Activate App. hr = 0x%08lx 
\n", AUMID, hr);
                   }
            }
     }
     CoUninitialize();
     return hr;
}
```

<span data-ttu-id="01d63-157">この方法では、コマンド ラインを使った先ほどの起動方法とは異なり、引数を渡すことができることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="01d63-157">It is worth noting that this method does support arguments being passed in, unlike the previous method for launching (that is, using the command line).</span></span>

## <a name="accepting-arguments"></a><span data-ttu-id="01d63-158">引数を受け取る</span><span class="sxs-lookup"><span data-stu-id="01d63-158">Accepting arguments</span></span>

<span data-ttu-id="01d63-159">UWP アプリのアクティブ化で渡される引数を受け取るには、アプリにコードを追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="01d63-159">To accept arguments passed in on activation of the UWP app, you must add some code to the app.</span></span> <span data-ttu-id="01d63-160">プロトコルのアクティブ化または起動アクティブ化が実行されたかどうかを判断するのには、**OnActivated** イベントをオーバーライドして引数の型を確認し、生の文字列または Uri オブジェクトの事前解析値を取得します。</span><span class="sxs-lookup"><span data-stu-id="01d63-160">To determine if protocol activation or launch activation occurred, override the **OnActivated** event and check the argument type, and then get the raw string or Uri object’s pre-parsed values.</span></span> 

<span data-ttu-id="01d63-161">次の例は、生の文字列を取得する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="01d63-161">This example shows how to get the raw string.</span></span>

```
void OnActivated(IActivatedEventArgs^ args)
{
        // Check for launch activation
        if (args->Kind == ActivationKind::Launch)
        {
            auto launchArgs = static_cast<LaunchActivatedEventArgs^>(args); 
            Platform::String^ argval = launchArgs->Arguments;
            // Manipulate arguments …
        }

        // Check for protocol activation
        if (args->Kind == ActivationKind::Protocol)
        {
            auto protocolArgs = static_cast< ProtocolActivatedEventArgs^>(args);
            Platform::String^ argval = protocolArgs->Uri->ToString();
            // Manipulate arguments …
        }
}
```

## <a name="summary"></a><span data-ttu-id="01d63-162">要約</span><span class="sxs-lookup"><span data-stu-id="01d63-162">Summary</span></span>
<span data-ttu-id="01d63-163">以上のように、UWP アプリはさまざまな方法で起動することができます。</span><span class="sxs-lookup"><span data-stu-id="01d63-163">In summary, you can use various methods to launch the UWP app.</span></span> <span data-ttu-id="01d63-164">要件や用途に応じて、適切な方法を利用してください。</span><span class="sxs-lookup"><span data-stu-id="01d63-164">Depending on the requirements and use cases, different methods may be better suited than others.</span></span> 

## <a name="see-also"></a><span data-ttu-id="01d63-165">関連項目</span><span class="sxs-lookup"><span data-stu-id="01d63-165">See also</span></span>
- [<span data-ttu-id="01d63-166">Xbox One の UWP</span><span class="sxs-lookup"><span data-stu-id="01d63-166">UWP on Xbox One</span></span>](index.md)

