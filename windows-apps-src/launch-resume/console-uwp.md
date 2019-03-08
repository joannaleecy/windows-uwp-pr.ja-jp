---
title: ユニバーサル Windows プラットフォームを使用してコンソール アプリを作成する
description: このトピックでは、コンソールウィンドウで実行される UWP アプリを記述する方法について説明します。
keywords: console uwp
ms.date: 08/02/2018
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 111ef4d5e8830485a5de3b44d69826df256d1c4d
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57592107"
---
# <a name="create-a-universal-windows-platform-console-app"></a>ユニバーサル Windows プラットフォームを使用してコンソール アプリを作成する

このトピックでは、作成する方法を説明します、 [C +/cli WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)または C++/cli CX ユニバーサル Windows プラットフォーム (UWP) コンソール アプリです。

以降では、Windows 10、バージョン 1803 では、次を記述できます C +/cli WinRT または C++/cli DOS または PowerShell のコンソール ウィンドウなどのコンソール ウィンドウで実行される CX UWP コンソール アプリです。 コンソール アプリの入力と出力をコンソール ウィンドウを使用し、使用できます[ユニバーサル C ランタイム](/cpp/c-runtime-library/reference/crt-alphabetical-function-reference)などの関数**printf**と**getchar**します。 Microsoft Store には、UWP コンソール アプリを公開することができます。 それらのアプリは、アプリのリストにエントリがあり、スタート メニューに固定することができるプライマリ タイルがあります。 コマンドラインから起動する、通常は、UWP コンソール アプリをスタート メニューから起動できます。

アクションのいずれかを表示するには、UWP のコンソール アプリケーションの作成に関するビデオを次に示します。

> [!VIDEO https://www.youtube.com/embed/bwvfrguY20s]

## <a name="use-a-uwp-console-app-template"></a>UWP コンソール アプリ テンプレートを使用する 

UWP コンソール アプリを作成するには、まず [Visual Studio Marketplace](https://marketplace.visualstudio.com/items?itemName=AndrewWhitechapelMSFT.ConsoleAppUniversal) から入手できる**コンソール アプリ (ユニバーサル) プロジェクト テンプレート**をインストールします。 インストール済みのテンプレートは、で利用できます**新しいプロジェクト** > **インストール済み** > **他の言語** >  **Visual C** > **Windows ユニバーサル**として**コンソール アプリ C +/cli WinRT (ユニバーサル Windows)** と**コンソール アプリ C + + CX (ユニバーサル Windows)**.

## <a name="add-your-code-to-main"></a>Main() にコードを追加します。

テンプレートは **Program.cpp** を追加します。これには `main()` 関数が含まれています。 これは、UWP コンソール アプリで実行が開始される場所です。 `__argc` および `__argv` パラメーターでコマンドライン引数にアクセスします。 制御が `main()` から返ってくると、UWP コンソール アプリは終了します。

次の例の**Program.cpp**で追加、**コンソール アプリ C+/cli WinRT**テンプレート。

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

## <a name="uwp-console-app-behavior"></a>UWP コンソール アプリの動作

UWP コンソール アプリは、実行されているディレクトリ、およびその下のファイル システムにアクセスできます。 テンプレートは [AppExecutionAlias](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-uap5-appexecutionalias) 拡張機能をアプリの Package.appxmanifest ファイルに追加するため、これが可能になります。 この拡張機能を使用すると、コンソール ウィンドウからエイリアスを入力してアプリを起動することもできます。 アプリを起動するためにシステムパスに入る必要はありません。

さらに、[ファイル アクセス許可](https://docs.microsoft.com/windows/uwp/files/file-access-permissions) で説明されているように、制限された機能 `broadFileSystemAccess` を追加することで、ファイルシステムへの広範なアクセスを UWP コンソール アプリに付与することができます。 この機能は、[**Windows.Storage**](https://msdn.microsoft.com/library/windows/apps/BR227346) 名前空間の API で動作します。

テンプレートによって [SupportsMultipleInstances](multi-instance-uwp.md) 機能がアプリの Package.appxmanifest ファイルに追加されるため、複数の UWP コンソール アプリのインスタンスを同時に実行できます。

テンプレートは Package.appxmanifest ファイルに `Subsystem="console"` の機能も追加します。これは、この UWP アプリがコンソール アプリであることを示しています。 `desktop4` と iot2 `namespace` プレフィックスに注意してください。 UWP コンソール アプリは、デスクトップやモノのインターネット (IoT) プロジェクトでのみサポートされています。

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

## <a name="additional-considerations-for-uwp-console-apps"></a>UWP コンソール アプリに関するその他の考慮事項

- のみ C +/cli WinRT および C++/cli コンソール アプリが CX の UWP アプリにあります。
- UWP コンソール アプリはデスクトップまたは IoT プロジェクト タイプをターゲットにする必要があります。
- UWP のコンソール アプリ ウィンドウを作成できません。 ユーザーの同意プロンプトなど、MessageBox() または Location()、またはその他何らかの理由でウィンドウを作成することがありますの API を使用できません。
- UWP コンソール アプリは、バックグラウンド タスクを消費したり、バックグラウンド タスクとして機能したりしない場合があります。
- [コマンド ラインのアクティブ化](https://blogs.windows.com/buildingapps/2017/07/05/command-line-activation-universal-windows-apps/#5YJUzjBoXCL4MhAe.97) を除き、UWP コンソール アプリは、ファイルの関連付け、プロトコルの関連付けなどのアクティブ化をサポートしていません。
- UWP コンソール アプリは複数インスタンスをサポートしていますが、[複数インスタンスのリダイレクト](multi-instance-uwp.md) はサポートしていません
- UWP アプリで使用できる Win32 API の一覧については、「[UWP アプリ用の Win32 API と COM API](https://docs.microsoft.com/uwp/win32-and-com/win32-and-com-for-uwp-apps)」をご覧ください。