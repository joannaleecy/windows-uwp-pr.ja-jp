---
author: PatrickFarley
description: アプリがプロセス ライフタイム管理と連携する方法をデバッグしてテストするためのツールと手法。
title: プロセス ライフタイム管理 (PLM) のテスト ツールとデバッグ ツール
ms.author: pafarley
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.assetid: 8ac6d127-3475-4512-896d-80d1e1d66ccd
ms.localizationpriority: medium
ms.openlocfilehash: 92d03ce30443f6efe8b19f4938b35d4040d7ea70
ms.sourcegitcommit: 3257416aebb5a7b1515e107866806f8bd57845a8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/17/2018
ms.locfileid: "7166534"
---
# <a name="testing-and-debugging-tools-for-process-lifetime-management-plm"></a><span data-ttu-id="079f4-104">プロセス ライフタイム管理 (PLM) のテスト ツールとデバッグ ツール</span><span class="sxs-lookup"><span data-stu-id="079f4-104">Testing and debugging tools for Process Lifetime Management (PLM)</span></span>

<span data-ttu-id="079f4-105">UWP アプリと従来のデスクトップ アプリケーションの主な違いの 1 つは、UWP のタイトルがプロセス ライフサイクル管理 (PLM) の対象となるアプリ コンテナーに配置されることです。</span><span class="sxs-lookup"><span data-stu-id="079f4-105">One of the key differences between UWP apps and traditional desktop applications is that UWP titles reside in an app container subject to Process Lifecycle Management (PLM).</span></span> <span data-ttu-id="079f4-106">ランタイム ブローカー サービスによって、UWP アプリはすべてのプラットフォームで中断、再開、または終了することができ、このような状態遷移を処理するコードをテストまたはデバッグするときに状態遷移を強制する目的で使う専用ツールがあります。</span><span class="sxs-lookup"><span data-stu-id="079f4-106">UWP apps can be suspended, resumed, or terminated across all platforms by the Runtime Broker service, and there are dedicated tools for you to use to force those transitions when you are testing or debugging the code that handles them.</span></span>

## <a name="features-in-visual-studio-2015"></a><span data-ttu-id="079f4-107">Visual Studio 2015 の機能</span><span class="sxs-lookup"><span data-stu-id="079f4-107">Features in Visual Studio 2015</span></span>

<span data-ttu-id="079f4-108">Visual Studio 2015 の組み込みのデバッガーを使うと、UWP 専用の機能を使うときの潜在的な問題を調査することができます。</span><span class="sxs-lookup"><span data-stu-id="079f4-108">The built-in debugger in Visual Studio 2015 can help you investigate potential issues when using UWP-exclusive features.</span></span> <span data-ttu-id="079f4-109">タイトルを実行してデバッグするときに表示される **[ライフサイクル イベント]** ツール バーを使うと、アプリケーションをさまざまな PLM の状態へと強制できます。</span><span class="sxs-lookup"><span data-stu-id="079f4-109">You can force your application into different PLM states by using the **Lifecycle Events** toolbar, which becomes visible when you run and debug your title.</span></span>

![[ライフサイクル イベント] ツールバー](images/gs-debug-uwp-apps-001.png)

## <a name="the-plmdebug-tool"></a><span data-ttu-id="079f4-111">PLMDebug ツール</span><span class="sxs-lookup"><span data-stu-id="079f4-111">The PLMDebug tool</span></span>

<span data-ttu-id="079f4-112">PLMDebug.exe は、アプリケーション パッケージの PLM の状態を制御できるようにするコマンド ライン ツールであり、Windows SDK の一部としてリリースされています。</span><span class="sxs-lookup"><span data-stu-id="079f4-112">PLMDebug.exe is a command-line tool that allows you to control the PLM state of an application package, and is shipped as part of the Windows SDK.</span></span> <span data-ttu-id="079f4-113">インストール後、ツールは既定で *C:\Program Files (x86)\Windows Kits\10\Debuggers\x64* に配置されます。</span><span class="sxs-lookup"><span data-stu-id="079f4-113">After it is installed, the tool resides in *C:\Program Files (x86)\Windows Kits\10\Debuggers\x64* by default.</span></span> 

<span data-ttu-id="079f4-114">PLMDebug を使うと、一部のデバッガーで必要とされるインストール済みアプリ パッケージの PLM を無効にすることもできます。</span><span class="sxs-lookup"><span data-stu-id="079f4-114">PLMDebug also allows you to disable PLM for any installed app package, which is necessary for some debuggers.</span></span> <span data-ttu-id="079f4-115">PLM を無効にすると、ランタイム ブローカー サービスでは、デバッグ前にアプリを終了できなくなります。</span><span class="sxs-lookup"><span data-stu-id="079f4-115">Disabling PLM prevents the Runtime Broker service from terminating your app before you have a chance to debug.</span></span> <span data-ttu-id="079f4-116">PLM を無効にするには、UWP アプリの*完全なパッケージ名* (短い名前、パッケージ ファミリ名、またはパッケージの AUMID は機能しません) が後に続く、**/enableDebug** スイッチを使います。</span><span class="sxs-lookup"><span data-stu-id="079f4-116">To disable PLM, use the **/enableDebug** switch, followed by the *full package name* of your UWP app (the short name, package family name, or AUMID of a package will not work):</span></span>

```
plmdebug /enableDebug [PackageFullName]
```

<span data-ttu-id="079f4-117">Visual Studio の UWP アプリを展開すると、出力ウィンドウに完全なパッケージ名が表示されます。</span><span class="sxs-lookup"><span data-stu-id="079f4-117">After deploying your UWP app from Visual Studio, the full package name is displayed in the output window.</span></span> <span data-ttu-id="079f4-118">または、PowerShell コンソールで **Get-AppxPackage** を実行することによって、完全なパッケージ名を取得することもできます。</span><span class="sxs-lookup"><span data-stu-id="079f4-118">Alternatively, you can also retrieve the full package name by running **Get-AppxPackage** in a PowerShell console.</span></span>

![Get-AppxPackage の実行](images/gs-debug-uwp-apps-003.png)

<span data-ttu-id="079f4-120">必要に応じて、アプリ パッケージがアクティブになると自動的に起動されるデバッガーの絶対パスを指定できます。</span><span class="sxs-lookup"><span data-stu-id="079f4-120">Optionally, you can specify an absolute path to a debugger that will automatically launch when your app package is activated.</span></span> <span data-ttu-id="079f4-121">Visual Studio を使って指定する場合は、デバッガーとして VSJITDebugger.exe を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="079f4-121">If you wish to do this using Visual Studio, you’ll need to specify VSJITDebugger.exe as the debugger.</span></span> <span data-ttu-id="079f4-122">ただし、VSJITDebugger.exe では、UWP アプリのプロセス ID (PID) と共に "-p" スイッチを指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="079f4-122">However, VSJITDebugger.exe requires that you specify the “-p” switch, along with the process ID (PID) of the UWP app.</span></span> <span data-ttu-id="079f4-123">事前に UWP アプリの PID を把握することはできないため、このシナリオはそのままでは使用できません。</span><span class="sxs-lookup"><span data-stu-id="079f4-123">Because it’s not possible to know the PID of your UWP app beforehand, this scenario is not possible out of the box.</span></span>

<span data-ttu-id="079f4-124">この制限は、ゲームのプロセスを特定するスクリプトまたはツールを記述することによって回避でき、シェルは、UWP アプリの PID を渡した VSJITDebugger.exe を実行します。</span><span class="sxs-lookup"><span data-stu-id="079f4-124">You can work around this limitation by writing a script or tool that identifies your game’s process, and then the shell runs VSJITDebugger.exe, passing in the PID of your UWP app.</span></span> <span data-ttu-id="079f4-125">次の C# コード サンプルは、これを実行するための簡単なアプローチを示しています。</span><span class="sxs-lookup"><span data-stu-id="079f4-125">The following C# code sample illustrates a straightforward approach to accomplish this.</span></span>

```
using System.Diagnostics;

namespace VSJITLauncher
{
    class Program
    {
        static void Main(string[] args)
        {
            // Name of UWP process, which can be retrieved via Task Manager.
            Process[] processes = Process.GetProcessesByName(args[0]);

            // Get PID of most recent instance
            // Note the highest PID is arbitrary. Windows may recycle or wrap the PID at any time.
            int highestId = 0;
            foreach (Process detectedProcess in processes)
            {
                if (detectedProcess.Id > highestId)
                    highestId = detectedProcess.Id;
            }

            // Launch VSJITDebugger.exe, which resides in C:\Windows\System32
            ProcessStartInfo startInfo = new ProcessStartInfo("vsjitdebugger.exe", "-p " + highestId);
            startInfo.UseShellExecute = true;

            Process process = new Process();
            process.StartInfo = startInfo;
            process.Start();
        }
    }
}
```

<span data-ttu-id="079f4-126">PLMDebug と組み合わせた使用例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="079f4-126">Example usage of this in conjunction with PLMDebug:</span></span>

```
plmdebug /enableDebug 279f7062-ce35-40e8-a69f-cc22c08e0bb8_1.0.0.0_x86__c6sq6kwgxxfcg "\"C:\VSJITLauncher.exe\" Game"
```
<span data-ttu-id="079f4-127">`Game` はプロセス名であり、`279f7062-ce35-40e8-a69f-cc22c08e0bb8_1.0.0.0_x86__c6sq6kwgxxfcg` は UWP アプリ パッケージ例の完全なパッケージ名です。</span><span class="sxs-lookup"><span data-stu-id="079f4-127">where `Game` is the process name, and `279f7062-ce35-40e8-a69f-cc22c08e0bb8_1.0.0.0_x86__c6sq6kwgxxfcg` is the full package name of the example UWP app package.</span></span>

<span data-ttu-id="079f4-128">**/enableDebug** のすべての呼び出しは、後ほど **/disableDebug** スイッチを使って別の PLMDebug の呼び出しに結合する必要があります。</span><span class="sxs-lookup"><span data-stu-id="079f4-128">Note that every call to **/enableDebug** must be later coupled to another PLMDebug call with the **/disableDebug** switch.</span></span> <span data-ttu-id="079f4-129">さらに、デバッガーのパスは絶対パスにする必要があります (相対パスはサポートされていません)。</span><span class="sxs-lookup"><span data-stu-id="079f4-129">Furthermore, the path to a debugger must be absolute (relative paths are not supported).</span></span>

## <a name="related-topics"></a><span data-ttu-id="079f4-130">関連トピック</span><span class="sxs-lookup"><span data-stu-id="079f4-130">Related topics</span></span>
- [<span data-ttu-id="079f4-131">UWP アプリの展開とデバッグ</span><span class="sxs-lookup"><span data-stu-id="079f4-131">Deploying and debugging UWP apps</span></span>](deploying-and-debugging-uwp-apps.md)
- [<span data-ttu-id="079f4-132">デバッグ、テスト、パフォーマンス</span><span class="sxs-lookup"><span data-stu-id="079f4-132">Debugging, testing, and performance</span></span>](index.md)
