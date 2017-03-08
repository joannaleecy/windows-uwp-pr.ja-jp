---
author: awkoren
Description: "このガイドでは、変換されたデスクトップ ブリッジ アプリを編集、デバッグ、パッケージ化するために Visual Studio ソリューションを構成する方法について説明します。"
Search.Product: eADQiWindows 10XVcnh
title: "Visual Studio による .NET デスクトップ アプリ用デスクトップ ブリッジ パッケージ ガイド"
ms.author: alkoren
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.assetid: 807a99a7-d285-46e7-af6a-7214da908907
translationtype: Human Translation
ms.sourcegitcommit: 5645eee3dc2ef67b5263b08800b0f96eb8a0a7da
ms.openlocfilehash: 8aa68312d6ce81c809c79ddcafe7732944a628be
ms.lasthandoff: 02/08/2017

---

# <a name="desktop-bridge-packaging-guide-for-net-desktop-apps-with-visual-studio"></a>Visual Studio による .NET デスクトップ アプリ用デスクトップ ブリッジ パッケージ ガイド

Windows 10 Anniversary Update により、開発者は、デスクトップ ブリッジを使用して、既存の Win32 アプリを新しいパッケージ モデル (.appx) でパッケージ化することができ、ストアでの公開やサイドローディングが容易になりました。 このガイドでは、アプリを編集、デバッグ、パッケージ化できるように Visual Studio ソリューションを構成する方法について説明します。 

始めるには、まず「[デスクトップ ブリッジを活用して、既存のアプリやゲームを Windows ストアに移行しましょう](https://developer.microsoft.com/windows/projects/campaigns/desktop-bridge)」のフォームに記入してください。 Microsoft から、オンボード プロセスを開始するためのご連絡があります。 アカウントでデスクトップ ブリッジ アプリを提出することが承認されたら、このドキュメントの手順に従って、appxupload パッケージをアップロードする準備をしてください。 

> デスクトップ ブリッジの使用時に発生した問題のフィードバックをお寄せいただく場合は、以下を参考にしてください。 機能のご提案については、[Windows 開発者向け UserVoice](https://wpdev.uservoice.com/forums/110705-universal-windows-platform/category/161895-desktop-bridge-centennial) までお寄せください。 ご質問やバグ レポートについては、[ユニバーサル Windows アプリ開発者向けフォーラム](https://social.msdn.microsoft.com/Forums/home?forum=wpdevelop)をご利用ください。

## <a name="default-universal-windows-platform-packages"></a>既定のユニバーサル Windows プラットフォーム パッケージ

Visual Studio では、Windows ストアやアプリのサイドローディングを使って配布できるパッケージを生成、デバッグ、リリースすることができます。 パッケージを容易に作成できるように、Visual Studio は以下の作成機能を備えています。 ストアへの提出に対応した appxupload ファイル。 詳しくは、「[UWP アプリのパッケージ化](..\packaging\packaging-uwp-apps.md)」をご覧ください。

## <a name="desktop-bridge-packages"></a>デスクトップ ブリッジ パッケージ

[デスクトップ ブリッジ](desktop-to-uwp-root.md)によって、さまざまな構成で、Win32 バイナリをアプリケーション パッケージ (appx) に統合することができます。 デスクトップ ブリッジの処理は、4 つの重要なステップを経て進んでいくと考えることができます。 

- **ステップ 1 - 変換**: コード変更をせずに、または最小限のコード変更で、既存の Win32 バイナリをパッケージ化します。
- **ステップ 2 - 強化**: 既存の Win32 コードから Windows.winmd を参照することによって、既存のアプリにいくつかの基本的な UWP 機能 (ライブ タイルなど) を含めます。
- **ステップ 3 - 拡張**: 既存のアプリと共に高度な UWP 機能 (バックグラウンド タスクなど) を含めます。 UWP コンポーネントと Win32 コンポーネントがマネージ言語 (C# や VB.Net など) を使って構築されている場合、結果のパッケージには、適切な .NET Native の処理を保証するために慎重に処理する必要があるバイナリが混在します。 
- **ステップ 4 - 移行**: UI を最新の XAML と C#/VB.NET に移行しましたが、従来の Win32 コードも残っています。 この時点でのエントリ ポイントは UWP .NET 実行可能ファイルですが、まだ一部の Win32 API を使用するバイナリがパッケージ内に存在します。

次の表に、4 つのステップでのアプリの相違点の概要を示します。 

| ステップ | バイナリ | エントリ ポイント | .NET Native | F5 デバッグ |
|---|---|---|---|---|
| 1 (変換) | Win32 | Win32 | 該当なし | VS 拡張機能 |
| 2 (強化) | WinMD を参照 | Win32 | 該当なし | VS 拡張機能 |
| 3 (拡張) | Win32 + CoreCLR (*) | Win32 | ユーザーが処理 (**) | VS 拡張機能 |
| 4 (移行)    | CoreCLR (*) + Win32 | UWP | ユーザーが処理 (**) | VS |
| 5 (UWP) | CoreCLR | UWP |ストアが処理 | VS |

(*) [CoreCLR](https://github.com/dotnet/coreclr) は、マネージ言語 (C#/VB.NET) で記述された UWP コンポーネントが依存する .NET Core ランタイムを参照します。 これらのコンポーネントでは .NET Native 処理も必要です。

(**) ステップ 3 および 4 では、ストアに公開する前に、ユーザーが CoreCLR アセンブリを処理して、.NET ネイティブ バイナリと、対応するシンボルを生成する必要があります。

## <a name="configure-your-visual-studio-solution"></a>Visual Studio ソリューションの構成

Visual Studio には、マニフェスト エディターやパッケージの作成ウィザードなど、アプリケーション パッケージの構成に必要なツールが含まれています。 これらのツールを使用するには、アプリの appx コンテナーとして機能する UWP プロジェクトを作成する必要があります。 任意の UWP プロジェクト (C#、VB.NET、C++、JavaScript など) を使用できますが、C#、VB.NET、C++ のプロジェクトには既知の問題 (このドキュメントの「[既知の問題](#known-issues-anchor)」を参照) があるため、この例では JavaScript を使います。 

appx アプリケーション モデルのコンテキストでアプリをデバッグする場合、F5 キーでの appx のデバッグを可能にする別のプロジェクトを追加する必要があります。 詳しくは、「[デスクトップ ブリッジ アプリのデバッグ](#debugging-anchor)」をご覧ください。

それでは、ステップ 1 から説明します。

### <a name="step-1-convert"></a>ステップ 1: 変換

このステップでは、既存の Win32 プロジェクトからデスクトップ ブリッジ アプリを作成する方法を示しています。 この例では、レジストリに対して読み取りと書き込みの操作を実行する、基本的な WinForms プロジェクトを使用します。

![](images/desktop-to-uwp/net-1.png)

#### <a name="add-the-uwp-project"></a>UWP プロジェクトを追加する 

デスクトップ ブリッジ パッケージを作成するには、同じソリューションに JavaScript UWP プロジェクトを追加します。

> 注: JavaScript UWP テンプレートを使用していますが、JavaScript コードは何も記述しません。 ツールとしてプロジェクトを使用しているだけです。

![](images/desktop-to-uwp/net-2.png)

#### <a name="add-the-win32-binaries-to-the-win32-folder"></a>win32 フォルダーに Win32 バイナリを追加する

すべての Win32 バイナリは、UWP プロジェクトでは、win32 という名前のフォルダーに格納されます (ただし、正確にこの名前にする必要はありません。任意の名前を使用できます)。

Visual Studio を使用している場合、プロジェクトを自動化して各ビルドの後でファイルをコピーし、開発ワークフローを向上させることができます。 プロジェクト ファイル (この例では .csproj) を編集して、次のように、すべての Win32 出力ファイル を UWP プロジェクトの win32 フォルダーにコピーする AfterBuild ターゲットを含めます。 

```xml
  <Target Name="AfterBuild">
    <PropertyGroup>
      <TargetUWP>..\MyDesktopApp.Package\win32\</TargetUWP>
    </PropertyGroup>
     <ItemGroup>
       <Win32Binaries Include="$(TargetDir)\*" />
     </ItemGroup>
    <Copy SourceFiles="@(Win32Binaries)" DestinationFolder="$(TargetUWP)" />
  </Target>
```

別のツールを使って Win32 バイナリを生成している場合は、実行時に必要なすべてのファイルを win32 フォルダーにコピーします。 

#### <a name="edit-the-app-manifest-to-enable-the-desktop-bridge-extensions"></a>アプリ マニフェストを編集してデスクトップ ブリッジ拡張機能を有効にする

このテンプレートには、デスクトップ ブリッジ拡張機能を追加するために使用できる package.appxmanifest が含まれています。 このファイルを編集するには、右クリックして [コードの表示] を選択し、次の項目を追加または変更します。 

- `<Package xmlns="http://schemas.microsoft.com/appx/manifest/foundation/windows10" xmlns:uap="http://schemas.microsoft.com/appx/manifest/uap/windows10" xmlns:rescap="http://schemas.microsoft.com/appx/manifest/foundation/windows10/restrictedcapabilities" IgnorableNamespaces="uap rescap">`

- `<TargetDeviceFamily Name="Windows.Desktop" MinVersion="10.0.14393.0" MaxVersionTested="10.0.14393.0" />`

- `<rescap:Capability Name="runFullTrust" />`

- `<Application Id="MyDesktopAppStep1" Executable="win32\MyDesktopApp.exe" EntryPoint="Windows.FullTrustApplication">`

マニフェスト ファイルの完全な例を次に示します。 

```xml
<?xml version="1.0" encoding="utf-8"?>
<Package xmlns="http://schemas.microsoft.com/appx/manifest/foundation/windows10"
        xmlns:uap="http://schemas.microsoft.com/appx/manifest/uap/windows10"

        xmlns:mp="http://schemas.microsoft.com/appx/2014/phone/manifest"
        xmlns:rescap="http://schemas.microsoft.com/appx/manifest/foundation/windows10/restrictedcapabilities"
        IgnorableNamespaces="uap rescap mp">
  <Identity Name="MyDesktopAppStep1"
            ProcessorArchitecture="x64"
            Publisher="CN=Microsoft Corporation, O=Microsoft Corporation, L=Redmond, S=Washington, C=US"
            Version="1.0.0.5" />
  <mp:PhoneIdentity PhoneProductId="6f6600a4-6da1-4d91-b493-35808d01f8de" PhonePublisherId="00000000-0000-0000-0000-000000000000" />
  <Properties>
    <DisplayName>MyDesktopAppStep1</DisplayName>
    <PublisherDisplayName>CN=Test</PublisherDisplayName>
    <Logo>Assets\SampleAppx.150x150.png</Logo>
  </Properties>
  <Resources>
    <Resource Language="en-us" />
  </Resources>
  <Dependencies>
    <TargetDeviceFamily Name="Windows.Desktop" 
                        MinVersion="10.0.14393.0" 
                        MaxVersionTested="10.0.14393.0" />
  </Dependencies>
  <Capabilities>
    <rescap:Capability Name="runFullTrust" />
  </Capabilities>
  <Applications>
    <Application Id="MyDesktopAppStep1" 
                 Executable="win32\MyDesktopApp.exe" 
                 EntryPoint="Windows.FullTrustApplication">
      <uap:VisualElements DisplayName="MyDesktopAppStep1" 
                          Description="MyDesktopAppStep1" 
                          BackgroundColor="#777777" 
                          Square150x150Logo="Assets\SampleAppx.150x150.png" 
                          Square44x44Logo="Assets\SampleAppx.44x44.png">
      </uap:VisualElements>
    </Application>
  </Applications>
</Package>
```

#### <a name="configure-the-win32-binaries"></a>Win32 バイナリを構成する

アプリが必要とするバイナリを出力パッケージに含めるには、Visual Studio で各ファイルを選択します。 プロパティを "コンテンツ" に、ビルドの動作を "新しい場合はコピーする" に設定します。 

![](images/desktop-to-uwp/net-3.png)

バイナリ ファイルをソース コードのリポジトリにコミットしない場合は、.gitignore ファイルを使用して win32 フォルダー内のすべてのファイルを除外することができます。 

#### <a name="optional-use-wildcards-to-specify-the-files-in-your-win32-folder"></a>省略可能: ワイルドカードを使用して win32 フォルダー内のファイルを指定する

Win32 アプリでいくつかのファイルを必要とする場合は、プロジェクト ファイルを編集してワイルドカードを使用し、ワイルドカード表現に基づいて "コンテンツ" としてマークする必要があるファイルを指定できます。 テキスト エディターで . jsproj ファイルを開き、次のように、必要なファイルを含める必要があります。

```xml
<Content Include="win32\*.dll">
  <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
</Content>
<Content Include="win32\*.exe">
  <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
</Content>
<Content Include="win32\*.config">
  <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
</Content>
<Content Include="win32\*.pdb">
  <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
</Content>
```

### <a name="step-2-enhance"></a>ステップ 2: 強化

Win32 コードから利用可能な UWP API を呼び出す場合は、`\Program Files (x86)\Windows Kits\10\UnionMetadata\Windows.winmd` への参照を追加する必要があります。 アプリで利用できるすべての UWP API の一覧については、「[デスクトップ ブリッジで変換されたアプリでサポートされている UWP API](desktop-to-uwp-supported-api.md)」をご覧ください。  

Windows 10では、このファイルは不要であるため配布する必要はありません。 参照のプロパティで、"ローカルにコピー" プロパティを False に設定します。

![](images/desktop-to-uwp/net-4.png)

Win32 バイナリを追加するには、ステップ 1 と同じ手順を使用します。 

### <a name="step-3-extend"></a>ステップ 3: 拡張 

この例では、バックグラウンド タスクを使って Win32 アプリを拡張します。 そのためには、UWP アプリの package.appxmanifest にバックグラウンド タスクを登録し、以下に示すように、バックグラウンド タスクを実装するプロジェクトへの参照を追加する必要があります。

```xml
<Extensions>
  <Extension Category="windows.backgroundTasks" 
              EntryPoint="BackgroundTasks.MyBackgroundTask">
    <BackgroundTasks>
      <Task Type="timer" />
    </BackgroundTasks>
  </Extension>
</Extensions>
```

C# または VB.NET を使ってバックグラウンド タスクを実装する場合、ステップ 3 と 4 で説明するように、結果の出力には、ストアに提出する前に .NET Native ツール チェーンで処理する必要がある CoreCLR バイナリが含まれます。 混在するバイナリを使って appxupload を作成します。

### <a name="step-4-migrate"></a>ステップ 4: 移行

このシナリオでは、既に C# UWP エントリ ポイントがあるため、新しい UWP プロジェクトを追加する必要はありません。 ただし、ステップ 1 で説明した手順に従って、Win32 バイナリを追加し、構成する必要があります。

Win32 プロセスを実行するには、[**FullTrustProcessLauncher**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.FullTrustProcessLauncher) API を使用します。 この API を使用するには、次のように、デスクトップの拡張機能と *fullTrustProcess* 機能をアプリのマニフェストに追加する必要があります。 

```xml
..
xmlns:desktop=http://schemas.microsoft.com/appx/manifest/desktop/windows10
..
<desktop:Extension Category="windows.fullTrustProcess" 
                    Executable="win32\MyDesktopApp.exe" />
```

## <a name="generate-packages-for-your-desktop-bridge-app"></a>デスクトップ ブリッジ アプリ用のパッケージの生成

上記の手順を実行している場合、「[UWP アプリのパッケージ化](..\packaging\packaging-uwp-apps.md)」で説明しているように、Visual Studio を使ってパッケージを生成する準備が整っている必要があります。 

### <a name="steps-1-and-2-create-appxupload-with-win32-binaries"></a>ステップ 1 と 2: Win32 バイナリを使って appxupload を作成する

*fullTrust* 機能を含むパッケージを提出するには、appxsym ファイル内の各プラットフォームのシンボルを含む appxupload ファイルと、appx プラットフォーム パッケージを含むバンドルを生成する必要があります。

ステップ 1 と 2 では、パッケージに CoreCLR バイナリは含まれていないため、どのプラットフォームを選択するかについて心配する必要はありません。 次の図のように、[ニュートラル] および [Release (任意のCPU)] を選択します。

![](images/desktop-to-uwp/net-5.png)

[ストア パッケージの生成] オプションを選択すると、ウィザードによって、ストアへの提出に対応した appxupload ファイルが生成されます。

### <a name="step-3-and-4-create-appxupload-with-mixed-binaries"></a>ステップ 3 と 4: 混在するバイナリを使って appxupload を作成する

また、リリース用にビルドすることも必要です。この場合、ターゲットにするプラットフォームを指定することが必要です。.NET Native で各プラットフォーム用のネイティブ バイナリを生成することが必要であるためです。

![](images/desktop-to-uwp/net-6.png)

新しい appxupload ファイルを作成するために、新しい zip アーカイブを作成して、生成された appxsym と appxbundle を _Testフォルダーから含めます。

appxsym ファイルと appxbundle ファイルを含む新しい zip ファイルを作成し、拡張子を appxupload に変更します。

![](images/desktop-to-uwp/net-7.png)

<span id="debugging-anchor" />
## <a name="debugging-your-desktop-bridge-app"></a>デスクトップ ブリッジ アプリのデバッグ

デバッグ (Ctrl + F5) を使用せずに Visual Studio からプロジェクトを開始することはできますが、Visual Studio は実行中のプロセスに自動的にアタッチできないという既知の問題があります。 ただし、後で、次のいずれかの方法でアタッチできます。

### <a name="attach-to-the-running-app"></a>実行中のアプリにアタッチする

#### <a name="attach-to-an-existing-process"></a>既存のプロセスにアタッチする

Ctrl キーを押しながら F5 キーを押してアプリを正常に起動した後、Win32 プロセスにアタッチすることができます。ただし、.NET Native モジュールをデバッグすることはできません。 

![](images/desktop-to-uwp/net-8.png)

#### <a name="attach-to-an-installed-app"></a>インストール済みのアプリにアタッチする

既存の Appx パッケージにアタッチすることもできます。これには、[デバッグ]、[その他のデバッグ ターゲット]、[インストールされているアプリケーション パッケージのデバッグ] の順にオプションを選びます。

![](images/desktop-to-uwp/net-9.png)

ここで、ローカル コンピューターを選択するか、リモート コンピューターに接続することができます。

![](images/desktop-to-uwp/net-10.png)

このオプションを使用すると、.NET Native コードをデバッグできます。

### <a name="use-visual-studio-extension-to-debug-your-desktop-bridge-app"></a>Visual Studio 拡張機能を使用してデスクトップ ブリッジ アプリをデバッグする 

F5 キーを使用してアプリのデバッグを実行する場合は、Visual Studio ギャラリーから、Visual Studio 2017 の拡張機能 [Desktop Bridge Debugging Project](https://marketplace.visualstudio.com/items?itemName=VisualStudioProductTeam.DesktoptoUWPPackagingProject) をインストールする必要があります。

このプロジェクトを使用すると、(このドキュメントで説明しているように) Visual Studio を使って、または Desktop App Converter を使って、UWP に移行しているすべての Win32 アプリをデバッグすることができます。

#### <a name="add-the-debugging-project-to-your-solution"></a>デバッグ プロジェクトをソリューションに追加する

まず、新しい Desktop Bridge Debugging Project をソリューションのプロジェクトに追加します。

![](images/desktop-to-uwp/net-11.png)

このプロジェクトを構成するには、デバッグに使用する各構成/プラットフォームのプロパティ ウィンドウで、PackageLayout プロパティを定義する必要があります。
Debug/x86 用に構成するために、相対パス `..\MyDesktopApp.Package\bin\x86\Debug` を使用して、パッケージ レイアウト プロパティを、UWP プロジェクトの bin\x86\debug フォルダーに設定します。 

![](images/desktop-to-uwp/net-12.png)

さらに、AppXFileLayout.xml ファイルを編集してエントリ ポイントを指定します。

```xml
<?xml version="1.0" encoding="utf-8"?>
<Project ToolsVersion="14.0" 
         xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  <PropertyGroup>
    <MyProjectOutputPath>$(PackageLayout)</MyProjectOutputPath>
  </PropertyGroup>
  <ItemGroup>
    <LayoutFile Include="$(MyProjectOutputPath)\win32\MyDesktopApp.exe">
      <PackagePath>$(PackageLayout)\win32\MyDesktopApp.exe</PackagePath>
    </LayoutFile>
  </ItemGroup>
</Project>
```

最後に、プロジェクトが適切な順序でビルドされるように、ソリューションの依存関係を構成する必要があります。 

例として、ステップ 3 用に作成されたソリューションを確認してみましょう。

![](images/desktop-to-uwp/net-13.png)

ビルドの順序を構成するには、プロジェクトの依存関係の構成を使用できます。 ソリューションを右クリックし、[プロジェクトの依存関係] オプションを選択します。 適切な依存関係を設定したら、以下に示すように、ビルドの順序を検証することができます (ステップ 3 の場合)。

![](images/desktop-to-uwp/net-14.png)

<span id="known-issues-anchor" />
## <a name="known-issues-with-cvbnet-and-c-uwp-projects"></a>C#/VB.NET と C++ UWP プロジェクトの既知の問題

C# プロジェクトを使用してアプリをパッケージ化する場合は、以下の既知の問題について理解しておく必要があります。 

- **Debug でアプリをビルドすると、次のようなエラーが出力されます。Microsoft.Net.CoreRuntime.targets(235,5): エラー: カスタム エントリ ポイントを持つアプリケーションの実行可能ファイルはサポートされていません。 パッケージ マニフェストでの Application 要素の Executable 属性を確認してください。** この問題を回避するには、代わりに Release モードを使用します。

- **UWP プロジェクトのルート フォルダーに格納されている Win32 バイナリは、Release では削除されます**。 Win32 バイナリを格納するフォルダーを使用しない場合、.NET Native コンパイラは最終的なパッケージからそれらのバイナリを削除します。これにより、実行可能ファイルのエントリ ポイントが見つからないため、マニフェストの検証エラーが出力されます。


