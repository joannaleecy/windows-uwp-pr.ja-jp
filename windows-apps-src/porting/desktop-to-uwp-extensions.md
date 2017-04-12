---
author: normesta
Description: "すべての UWP アプリで利用できる標準の API に加えて、変換されたデスクトップ アプリでのみ利用できる拡張機能と API があります。 この記事では、これらの拡張機能とその使用方法について説明します。"
Search.Product: eADQiWindows 10XVcnh
title: "Desktop to UWP Bridge のアプリの拡張機能"
ms.author: normesta
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.assetid: 0a8cedac-172a-4efd-8b6b-67fd3667df34
ms.openlocfilehash: a3c29f0d36cec9a5816d5c20eb43a6634260cc43
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
# <a name="desktop-to-uwp-bridge-app-extensions"></a>Desktop to UWP Bridge: アプリの拡張機能

変換されたデスクトップ アプリケーションは、幅広いユニバーサル Windows プラットフォーム (UWP) API を使用して拡張できます。 ただし、すべての UWP アプリで利用できる標準の API に加えて、変換されたデスクトップ アプリでのみ利用できる拡張機能と API があります。 これらの機能は、ユーザーのログオン時のプロセスの起動やエクスプローラーの統合などのシナリオに重点を置いており、元のデスクトップ アプリと変換後のアプリ パッケージの間でのスムーズな移行を目的として設計されています。

この記事では、これらの拡張機能とその使用方法について説明します。 ほとんどの場合、変換されたアプリのマニフェスト ファイルを手動で変更する必要があります。これには、アプリで利用する拡張機能に関する宣言が含まれます。 マニフェストを編集するには、Visual Studio ソリューションの **Package.appxmanifest** ファイルを右クリックし、*[コードの表示]* を選びます。

## <a name="manifest-xml-namespaces"></a>マニフェストの XML 名前空間

デスクトップ ブリッジのアプリの拡張機能では、いくつかの異なる XML 名前空間が必要です。 これらの名前空間は、次のように、マニフェスト ファイルのルートにある `<Package>` 要素で定義する必要があります。

```xml
<Package
  ...
  xmlns:uap2="http://schemas.microsoft.com/appx/manifest/uap/windows10/2"
  xmlns:uap3="http://schemas.microsoft.com/appx/manifest/uap/windows10/3"
  xmlns:desktop="http://schemas.microsoft.com/appx/manifest/desktop/windows10"
  ...
  IgnorableNamespaces="uap uap2 uap3 mp rescap desktop">
```

マニフェスト ファイルがコンパイル エラーを出力している場合は、必要な名前空間をすべて含めていることと、その子の XML 要素に適切な名前空間を使ってプレフィックスが設定されていることを確認します。 完全な、機能するマニフェスト ファイルについては、[GitHub のデスクトップ ブリッジのサンプル リポジトリ](https://github.com/Microsoft/DesktopBridgeToUWP-Samples)をご覧ください。

## <a name="startup-tasks"></a>スタートアップ タスク

スタートアップ タスクによって、アプリでは、ユーザーがログオンするたびに自動的に実行可能ファイルを実行できます。

スタートアップ タスクを宣言するには、次のコードをアプリのマニフェストに追加します。

```XML
<desktop:Extension Category="windows.startupTask" Executable="bin\MyStartupTask.exe" EntryPoint="Windows.FullTrustApplication">
    <desktop:StartupTask TaskId="MyStartupTask" Enabled="true" DisplayName="My App Service" />
</desktop:Extension>
```
- *Extension Category* の値は常に "windows.startupTask" にしてください。
- *Extension Executable* は起動する .exe への相対パスです。
- *Extension EntryPoint* の値は常に "Windows.FullTrustApplication" にしてください。
- *StartupTask TaskId* はタスクの一意の識別子です。 この識別子を使用して、アプリは [**Windows.ApplicationModel.StartupTask**](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.StartupTask) クラスの API を呼び出し、プログラムでスタートアップ タスクを有効または無効にすることができます。
- *StartupTask Enabled* は、最初に起動するタスクを有効にするか、無効にするかを指定します。 有効になっているタスクは、(ユーザーが無効にしていない限り) 次回ユーザーがログオンするときに実行されます。
- *StartupTask DisplayName* は、タスク マネージャーに表示されるタスクの名前です。 この文字列は、```ms-resource``` を使用してローカライズすることができます。

アプリでは、複数のスタートアップ タスクを宣言できます。各タスクは独立して起動および実行されます。 すべてのスタートアップ タスクは、タスク マネージャーの **[スタートアップ]** タブに、アプリのマニフェストで指定した名前とアプリのアイコンを使って表示されます。 タスク マネージャーによって、タスクの起動への影響が自動的に分析されます。 ユーザーは、タスク マネージャーを使用して、アプリのスタートアップ タスクを手動で無効にすることができます。ユーザーがタスクを無効にした場合、プログラムでタスクを再度有効にすることはできません。

## <a name="app-execution-alias"></a>アプリの実行エイリアス

アプリの実行エイリアスによって、アプリのキーワード名を指定できます。 ユーザーや他のプロセスは、このキーワードを使用することによって、アプリが PATH 変数で指定されている場合と同様に、完全なパスを指定せずに、Run やコマンド プロンプトなどから簡単にアプリを実行できます。 たとえば、"Foo" というエイリアスを宣言している場合、ユーザーは cmd.exe から「Foo Bar.txt」と入力することができ、アクティブ化イベント引数の一部として "Bar.txt" へのパスを使用してアプリがアクティブ化されます。

アプリ実行のエイリアスを指定するには、次のコードをアプリのマニフェストに追加します。

```XML
<uap3:Extension Category="windows.appExecutionAlias" Executable="exes\launcher.exe" EntryPoint="Windows.FullTrustApplication">
    <uap3:AppExecutionAlias>
        <desktop:ExecutionAlias Alias="Foo.exe" />
    </uap3:AppExecutionAlias>
</uap3:Extension>
```

- *Extension Category* の値は常に "windows.appExecutionAlias" にしてください。
- *Extension Executable* は、エイリアスが呼び出されたときに起動する実行可能ファイルへの相対パスです。
- *Extension EntryPoint* の値は常に "Windows.FullTrustApplication" にしてください。
- *ExecutionAlias Alias* はアプリの短い名前です。 常に、拡張子 ".exe" で終わっている必要があります。

パッケージ内のアプリケーションごとにアプリの実行エイリアスは 1 つだけ指定できます。 複数のアプリで同じエイリアスが登録されている場合、システムは最後に登録されたアプリを呼び出します。したがって、他のアプリが上書きする可能性が低い一意のエイリアスを選んでください。

## <a name="protocol-associations"></a>プロトコルの関連付け

プロトコルの関連付けによって、変換後のアプリとその他のプログラムやシステム コンポーネントとの間の相互運用のシナリオが実現されます。 プロトコルを使用して変換後のアプリを起動する場合、アプリが適切に動作できるように、特定のパラメーターを指定してアプリのアクティブ化イベント引数に渡すことができます。 パラメーターは、変換された完全に信頼できるアプリでのみサポートされています。UWP アプリでは、パラメーターを使用できません。  

プロトコルの関連付けを宣言するには、次のコードをアプリのマニフェストに追加します。

```XML
<uap3:Extension Category="windows.protocol">
    <uap3:Protocol Name="myapp-cmd" Parameters="/p &quot;%1&quot;" />
</uap3:Extension>
```

- *Extension Category* の値は常に "windows.protocol" にしてください。
- *Protocol Name* はプロトコルの名前です。
- *Protocol Parameters* は、アクティブ化するときのイベント引数としてアプリに渡すパラメーターや値のリストです。 変数にファイルのパスを含めることができる場合は、スペースを含むパスを渡すときにパスが分割されないように、値を引用符で囲む必要があることに注意してください。

## <a name="files-and-file-explorer-integration"></a>ファイルとエクスプローラーの統合

変換後のアプリには、特定の種類のファイルの処理を登録したり、エクスプ ローラーに統合したりするためのさまざまなオプションがあります。 これにより、ユーザーは通常のワークフローの一部として簡単にアプリにアクセスできます。

最初に、次のコードをアプリのマニフェストに追加します。

```XML
<uap3:Extension Category="windows.fileTypeAssociation">
    <uap3:FileTypeAssociation Name="myapp">
        ... additional elements here ...
    </uap3:FileTypeAssociation>
</uap3:Extension>
```

- *Extension Category* の値は常に "windows.fileTypeAssociation" にしてください。
- *FileTypeAssociation Name* は一意の ID です。 この ID は、ファイルの種類の関連付けによって関連付けられたハッシュ対象の ProgID を生成するために内部で使用されます。 この ID を使って、アプリの今後のバージョンで変更を管理することができます。 たとえば、ファイル拡張子のアイコンを変更する場合、別の名前を持つ新しい FileTypeAssociation に移行できます。  

次に、必要な特定の機能に基づいて、このエントリに新しい子要素を追加します。 使用可能なオプションについて以下に説明します。

### <a name="supported-file-types"></a>サポートされているファイルの種類

アプリでは、特定の種類のファイルを開くことをサポートしていることを指定できます。 ユーザーがファイルを右クリックして [プログラムから開く] を選んだ場合、候補の一覧にアプリが表示されます。

例: 

```XML
<uap:SupportedFileTypes>
    <uap:FileType>.txt</uap:FileType>
    <uap:FileType>.avi</uap:FileType>
</uap:SupportedFileTypes>
```

- *FileType* はアプリがサポートする拡張子です。

### <a name="file-context-menu-verbs"></a>ファイル コンテキスト メニューの動詞

通常、ユーザーは、ファイルをダブルクリックして開きます。 ただし、ユーザーがファイルを右クリックした場合、コンテキスト メニューに [開く]、[編集]、[プレビュー]、[印刷] など、ファイルの操作方法に関する詳細を提供するさまざまなオプション ("動詞" と呼ばれる) が表示されます。

サポートされているファイルの種類を指定すると、自動的に動詞 "開く" が追加されます。 ただし、アプリで、エクスプローラーのショートカット メニューにカスタム動詞を追加することもできます。 これにより、ファイルを開くときに、ユーザーの選択内容に基づき、特定の方法でアプリを起動できます。

例:

```XML
<uap2:SupportedVerbs>
    <uap3:Verb Id="Edit" Parameters="/e &quot;%1&quot;">Edit</uap3:Verb>
    <uap3:Verb Id="Print" Extended="true" Parameters="/p &quot;%1&quot;">Print</uap3:Verb>
</uap2:SupportedVerbs>
```

- *Verb Id* は動詞の一意の ID です。 アプリが UWP アプリである場合、アプリがユーザーの選択内容を適切に処理できるように、この ID がアクティブ化イベント引数の一部としてアプリに渡されます。 アプリが完全に信頼できる変換後のアプリである場合は、代わりにパラメーターを受け取ります (次の項目をご覧ください)。
- *Verb Parameters* は、動詞に関連付けられている引数のパラメーターと値のリストです。 アプリが完全に信頼できる変換後のアプリである場合、これらはアプリがアクティブ化されるときにイベント引数としてアプリに渡されるため、さまざまなアクティブ化の動詞に対して動作をカスタマイズできます。 変数にファイルのパスを含めることができる場合は、スペースを含むパスを渡すときにパスが分割されないように、値を引用符で囲む必要があります。 アプリが UWP アプリである場合、パラメーターを渡すことはできません。アプリは代わりに ID を受け取ります (前の項目をご覧ください)。
- *Verb Extended* は、ユーザーが **Shift** キーを押しながらファイルを右クリックしてショートカット メニューを表示した場合にのみ表示される動詞を指定します。 この属性は省略可能であり、指定されていない場合の既定値は *False* (つまり、常に動詞を表示する) です。 この動作は各動詞について個別に指定します ("開く" は例外で、常に *False*)。
- *Verb* は、エクスプローラーのショートカット メニューに表示される名前です。 この文字列は、```ms-resource``` を使用してローカライズすることができます。

### <a name="shell-context-menu-verbs"></a>シェル コンテキスト メニューの動詞

シェルのフォルダー コンテキスト メニューへの項目の追加は、現在サポートされていません。

### <a name="multiple-selection-model"></a>複数選択モデル

複数選択によって、ユーザーがアプリで同時に複数のファイルを開く場合 (エクスプローラーで 10 個のファイルを選んで [開く] をタップする場合など) の処理方法を指定できます。

変換後のデスクトップ アプリでは、通常のデスクトップ アプリと同じ 3 つのオプションがあります。
- *Player*: 選択したすべてのファイルを引数パラメーターとして渡して、アプリが 1 回アクティブ化されます。
- *Single*: 選択した最初のファイルについて、アプリが 1 回アクティブ化されます。 その他のファイルは無視されます。
- *Document*: 選択した各ファイルについて、アプリの新しい独立したインスタンスがアクティブ化されます。

ファイルの種類やアクションごとに、さまざまな環境設定項目を設定できます。 たとえば、*Documents* は *Document* モードで開き、*Images* は *Player* モードで開くことができます。

アプリの動作を設定するには、マニフェストでファイルの種類やファイルの起動に関連する要素に *MultiSelectModel* 属性を追加します。

サポートされているファイルの種類のモデルの設定:

```XML
<uap3:FileTypeAssociation Name="myapp" MultiSelectModel="Document">
    <uap:SupportedFileTypes>
        <uap:FileType>.txt</uap:FileType>
</uap:SupportedFileTypes>
```

動詞のモデルの設定:

```XML
<uap3:Verb Id="Edit" MultiSelectModel="Player">Edit</uap3:Verb>
<uap3:Verb Id="Preview" MultiSelectModel="Document">Preview</uap3:Verb>
```

アプリで複数選択のオプションを指定していない場合、ユーザーが 15 個以下のファイルを開いたときの既定値は *Player* です。 それ以外で、アプリが変換後のアプリである場合、既定値は *Document* です。 UWP アプリは常に *Player* として起動されます。

### <a name="complete-example"></a>完全な例

これまでに説明したファイルとエクスプローラーに関連する要素の多くを統合した完全な例を、以下に示します。

```XML
<uap3:Extension Category="windows.fileTypeAssociation">
    <uap3:FileTypeAssociation Name="myapp" MultiSelectModel="Document">
        <uap:SupportedFileTypes>
            <uap:FileType>.txt</uap:FileType>
            <uap:FileType>.foo</uap:FileType>
    </uap:SupportedFileTypes>
    <uap2:SupportedVerbs>
            <uap3:Verb Id="Edit" Parameters="/e &quot;%1&quot;">Edit</uap3:Verb>
            <uap3:Verb Id="Print" Parameters="/p &quot;%1&quot;">Print</uap3:Verb>
    </uap2:SupportedVerbs>
    <uap:Logo>Assets\MyExtensionLogo.png</uap:Logo>
    </uap3:FileTypeAssociation>
</uap3:Extension>
```

## <a name="see-also"></a>参照

- [アプリ パッケージ マニフェスト](https://msdn.microsoft.com/library/windows/apps/br211474.aspx)
