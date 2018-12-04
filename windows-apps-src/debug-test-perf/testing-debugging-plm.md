---
description: アプリがプロセス ライフタイム管理と連携する方法をデバッグしてテストするためのツールと手法。
title: プロセス ライフタイム管理 (PLM) のテスト ツールとデバッグ ツール
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.assetid: 8ac6d127-3475-4512-896d-80d1e1d66ccd
ms.localizationpriority: medium
ms.openlocfilehash: 8b3e37d4de3a346e0f29909727a46d3b31f9d59d
ms.sourcegitcommit: b4c502d69a13340f6e3c887aa3c26ef2aeee9cee
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/03/2018
ms.locfileid: "8473467"
---
# <a name="testing-and-debugging-tools-for-process-lifetime-management-plm"></a>プロセス ライフタイム管理 (PLM) のテスト ツールとデバッグ ツール

UWP アプリと従来のデスクトップ アプリケーションの主な違いの 1 つは、UWP のタイトルがプロセス ライフサイクル管理 (PLM) の対象となるアプリ コンテナーに配置されることです。 ランタイム ブローカー サービスによって、UWP アプリはすべてのプラットフォームで中断、再開、または終了することができ、このような状態遷移を処理するコードをテストまたはデバッグするときに状態遷移を強制する目的で使う専用ツールがあります。

## <a name="features-in-visual-studio-2015"></a>Visual Studio 2015 の機能

Visual Studio 2015 の組み込みのデバッガーを使うと、UWP 専用の機能を使うときの潜在的な問題を調査することができます。 タイトルを実行してデバッグするときに表示される **[ライフサイクル イベント]** ツール バーを使うと、アプリケーションをさまざまな PLM の状態へと強制できます。

![[ライフサイクル イベント] ツールバー](images/gs-debug-uwp-apps-001.png)

## <a name="the-plmdebug-tool"></a>PLMDebug ツール

PLMDebug.exe は、アプリケーション パッケージの PLM の状態を制御できるようにするコマンド ライン ツールであり、Windows SDK の一部としてリリースされています。 インストール後、ツールは既定で *C:\Program Files (x86)\Windows Kits\10\Debuggers\x64* に配置されます。 

PLMDebug を使うと、一部のデバッガーで必要とされるインストール済みアプリ パッケージの PLM を無効にすることもできます。 PLM を無効にすると、ランタイム ブローカー サービスでは、デバッグ前にアプリを終了できなくなります。 PLM を無効にするには、UWP アプリの*完全なパッケージ名* (短い名前、パッケージ ファミリ名、またはパッケージの AUMID は機能しません) が後に続く、**/enableDebug** スイッチを使います。

```
plmdebug /enableDebug [PackageFullName]
```

Visual Studio の UWP アプリを展開すると、出力ウィンドウに完全なパッケージ名が表示されます。 または、PowerShell コンソールで **Get-AppxPackage** を実行することによって、完全なパッケージ名を取得することもできます。

![Get-AppxPackage の実行](images/gs-debug-uwp-apps-003.png)

必要に応じて、アプリ パッケージがアクティブになると自動的に起動されるデバッガーの絶対パスを指定できます。 Visual Studio を使って指定する場合は、デバッガーとして VSJITDebugger.exe を指定する必要があります。 ただし、VSJITDebugger.exe では、UWP アプリのプロセス ID (PID) と共に "-p" スイッチを指定する必要があります。 事前に UWP アプリの PID を把握することはできないため、このシナリオはそのままでは使用できません。

この制限は、ゲームのプロセスを特定するスクリプトまたはツールを記述することによって回避でき、シェルは、UWP アプリの PID を渡した VSJITDebugger.exe を実行します。 次の C# コード サンプルは、これを実行するための簡単なアプローチを示しています。

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

PLMDebug と組み合わせた使用例を次に示します。

```
plmdebug /enableDebug 279f7062-ce35-40e8-a69f-cc22c08e0bb8_1.0.0.0_x86__c6sq6kwgxxfcg "\"C:\VSJITLauncher.exe\" Game"
```
`Game` はプロセス名であり、`279f7062-ce35-40e8-a69f-cc22c08e0bb8_1.0.0.0_x86__c6sq6kwgxxfcg` は UWP アプリ パッケージ例の完全なパッケージ名です。

**/enableDebug** のすべての呼び出しは、後ほど **/disableDebug** スイッチを使って別の PLMDebug の呼び出しに結合する必要があります。 さらに、デバッガーのパスは絶対パスにする必要があります (相対パスはサポートされていません)。

## <a name="related-topics"></a>関連トピック
- [UWP アプリの展開とデバッグ](deploying-and-debugging-uwp-apps.md)
- [デバッグ、テスト、パフォーマンス](index.md)
