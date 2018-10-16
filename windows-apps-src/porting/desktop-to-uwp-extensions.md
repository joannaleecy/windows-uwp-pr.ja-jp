---
author: normesta
Description: You can use extensions to integrate your packaged desktop app with Windows 10 in predefined ways.
Search.Product: eADQiWindows 10XVcnh
title: Windows 10 にアプリを統合する (デスクトップ ブリッジ)
ms.author: normesta
ms.date: 04/18/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.assetid: 0a8cedac-172a-4efd-8b6b-67fd3667df34
ms.localizationpriority: medium
ms.openlocfilehash: fadd9c2b6a35a1418a782ab0a6ef419e3f127f42
ms.sourcegitcommit: 106aec1e59ba41aae2ac00f909b81bf7121a6ef1
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/15/2018
ms.locfileid: "4617269"
---
# <a name="integrate-your-packaged-desktop-application-with-windows-10"></a>Windows 10 にパッケージ化されたデスクトップ アプリケーションを統合します。

拡張機能を使用すると、あらかじめ定義された方法で Windows 10 にパッケージ化されたデスクトップ アプリケーションを統合します。

たとえば、ファイアウォールの例外を作成、アプリケーションのファイルの種類の既定のアプリケーションにする、またはアプリのパッケージ バージョンをスタート画面のタイルをポイントする拡張機能を使用します。 拡張機能は、アプリのパッケージ マニフェスト ファイルに XML を追加するだけで使用できます。 コードは必要ありません。

このトピックでは、これらの拡張機能について説明し、拡張機能を使って実行できるタスクについても示します。

## <a name="transition-users-to-your-app"></a>ユーザーをアプリに移行する

ユーザーによってパッケージ アプリが使用されるように、移行を促します。

* [既存のスタート タイルとタスク バー ボタンの参照先をパッケージ アプリに設定する](#point)
* [デスクトップ アプリではなくファイルを開き、パッケージ化されたアプリケーションを作成します。](#make)
* [ファイルの種類のセットをパッケージ化されたアプリケーションを関連付ける](#associate)
* [特定の種類のファイルのコンテキスト メニューにオプションを追加する](#add)
* [URL を使用して特定の種類のファイルを直接開く](#open)

<a id="point" />

### <a name="point-existing-start-tiles-and-taskbar-buttons-to-your-packaged-app"></a>既存のスタート タイルとタスク バー ボタンの参照先をパッケージ アプリに設定する

ユーザーによって、デスクトップ アプリがタスク バーまたはスタート メニューにピン留めされている可能性があります。 これらのショートカットの参照先を新しいパッケージ アプリに変更できます。

#### <a name="xml-namespace"></a>XML 名前空間

http://schemas.microsoft.com/appx/manifest/foundation/windows10/restrictedcapabilities/3

#### <a name="elements-and-attributes-of-this-extension"></a>この拡張機能の要素と属性

```XML
<Extension Category="windows.desktopAppMigration">
    <DesktopAppMigration>
        <DesktopApp AumId="[your_app_aumid]" />
        <DesktopApp ShortcutPath="[path]" />
    </DesktopAppMigration>
</Extension>

```

完全なスキーマ リファレンスについては、[こちら](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-rescap3-desktopappmigration)をご覧ください。

|名前 | 説明 |
|-------|-------------|
|Category |常に ``windows.desktopAppMigration`` です。
|AumID |パッケージ アプリのアプリケーション ユーザー モデル ID。 |
|ShortcutPath |アプリのデスクトップ バージョンを起動する .lnk ファイルへのパス。 |

#### <a name="example"></a>例

```XML
<Package
  xmlns:rescap3="http://schemas.microsoft.com/appx/manifest/foundation/windows10/restrictedcapabilities/3"
  IgnorableNamespaces="rescap3">
  <Applications>
    <Application>
      <Extensions>
        <rescap3:Extension Category="windows.desktopAppMigration">
          <rescap3:DesktopAppMigration>
            <rescap3:DesktopApp AumId="[your_app_aumid]" />
            <rescap3:DesktopApp ShortcutPath="%USERPROFILE%\Desktop\[my_app].lnk" />
            <rescap3:DesktopApp ShortcutPath="%APPDATA%\Microsoft\Windows\Start Menu\Programs\[my_app].lnk" />
            <rescap3:DesktopApp ShortcutPath="%PROGRAMDATA%\Microsoft\Windows\Start Menu\Programs\[my_app_folder]\[my_app].lnk"/>
         </rescap3:DesktopAppMigration>
        </rescap3:Extension>
      </Extensions>
    </Application>
  </Applications>
</Package>
```
#### <a name="related-sample"></a>関連するサンプル

[WPF picture viewer with transition/migration/uninstallation](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/DesktopAppTransition)

<a id="make" />

### <a name="make-your-packaged-application-open-files-instead-of-your-desktop-app"></a>デスクトップ アプリではなくファイルを開き、パッケージ化されたアプリケーションを作成します。

ユーザーが既定では特定の種類のファイルを開くときに、アプリのデスクトップ バージョンではなく、新しいパッケージ化されたアプリケーションを開くことを確認することができます。

これを行うには、ファイルの関連付けを継承するために、関連付けされている各アプリケーションの[プログラム識別子 (ProgID)](https://msdn.microsoft.com/library/windows/desktop/cc144152.aspx) を指定します。

#### <a name="xml-namespaces"></a>XML 名前空間

* http://schemas.microsoft.com/appx/manifest/uap/windows10/3
* http://schemas.microsoft.com/appx/manifest/foundation/windows10/restrictedcapabilities/3

#### <a name="elements-and-attributes-of-this-extension"></a>この拡張機能の要素と属性

```XML
<Extension Category="windows.fileTypeAssociation">
<FileTypeAssociation Name="[AppID]">
         <MigrationProgIds>
            <MigrationProgId>"[ProgID]"</MigrationProgId>
        </MigrationProgIds>
    </FileTypeAssociation>
</Extension>
```

完全なスキーマ リファレンスについては、[こちら](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-uap-filetypeassociation)をご覧ください。

|名前 |説明 |
|-------|-------------|
|Category |常に ``windows.fileTypeAssociation`` です。
|名前 |アプリの一意の ID。 この ID は、ファイルの種類の関連付けによって関連付けられたハッシュ対象の[プログラム識別子 (ProgID)](https://msdn.microsoft.com/library/windows/desktop/cc144152.aspx) を生成するために内部で使用されます。 この ID を使って、アプリの今後のバージョンで変更を管理することができます。 |
|MigrationProgId |アプリケーション、コンポーネント、およびファイルの関連付けを継承するデスクトップ アプリケーションのバージョンを記述した[プログラム識別子 (ProgID)](https://msdn.microsoft.com/library/windows/desktop/cc144152.aspx)します。|

#### <a name="example"></a>例

```XML
<Package
  xmlns:uap3="http://schemas.microsoft.com/appx/manifest/uap/windows10/3"
  xmlns:rescap3="http://schemas.microsoft.com/appx/manifest/foundation/windows10/restrictedcapabilities/3"
  IgnorableNamespaces="uap3, rescap3">
  <Applications>
    <Application>
      <Extensions>
        <uap:Extension Category="windows.fileTypeAssociation">
          <uap3:FileTypeAssociation Name="Contoso">
            <rescap3:MigrationProgIds>
              <rescap3:MigrationProgId>Foo.Bar.1</rescap3:MigrationProgId>
              <rescap3:MigrationProgId>Foo.Bar.2</rescap3:MigrationProgId>
            </rescap3:MigrationProgIds>
          </uap3:FileTypeAssociation>
        </uap:Extension>
      </Extensions>
    </Application>
  </Applications>
</Package>
```
#### <a name="related-sample"></a>関連するサンプル

[WPF picture viewer with transition/migration/uninstallation](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/DesktopAppTransition)

<a id="associate" />

### <a name="associate-your-packaged-application-with-a-set-of-file-types"></a>ファイルの種類のセットをパッケージ化されたアプリケーションを関連付ける

パッケージ化されたアプリケーションは、ファイル拡張子に関連付けられていることができます。 ユーザーは、ファイルを右クリックし、**プログラムから開く**] オプションを選択し、候補の一覧に、アプリケーションが表示されます。

#### <a name="xml-namespace"></a>XML 名前空間

* http://schemas.microsoft.com/appx/manifest/uap/windows10
* http://schemas.microsoft.com/appx/manifest/uap/windows10/3

#### <a name="elements-and-attributes-of-this-extension"></a>この拡張機能の要素と属性

```XML
<Extension Category="windows.fileTypeAssociation">
    <FileTypeAssociation Name="[AppID]">
        <SupportedFileTypes>
            <FileType>"[file extension]"</FileType>
        </SupportedFileTypes>
    </FileTypeAssociation>
</Extension>
```

完全なスキーマ リファレンスについては、[こちら](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-uap-filetypeassociation)をご覧ください。

|名前 |説明 |
|-------|-------------|
|Category |常に ``windows.fileTypeAssociation`` です。
|名前 |アプリの一意の ID。 この ID は、ファイルの種類の関連付けによって関連付けられたハッシュ対象の[プログラム識別子 (ProgID)](https://msdn.microsoft.com/library/windows/desktop/cc144152.aspx) を生成するために内部で使用されます。 この ID を使って、アプリの今後のバージョンで変更を管理することができます。   |
|FileType |アプリでサポートされているファイル拡張子。 |

#### <a name="example"></a>例

```XML
<Package
  xmlns:uap="http://schemas.microsoft.com/appx/manifest/uap/windows10"
  xmlns:uap3="http://schemas.microsoft.com/appx/manifest/uap/windows10/3"
  IgnorableNamespaces="uap, uap3">
  <Applications>
    <Application>
      <Extensions>
        <uap:Extension Category="windows.fileTypeAssociation">
          <uap3:FileTypeAssociation Name="Contoso">
            <uap:SupportedFileTypes>
              <uap:FileType>.txt</uap:FileType>
              <uap:FileType>.avi</uap:FileType>
            </uap:SupportedFileTypes>
          </uap3:FileTypeAssociation>
        </uap:Extension>
      </Extensions>
    </Application>
  </Applications>
</Package>
```

#### <a name="related-sample"></a>関連するサンプル

[WPF picture viewer with transition/migration/uninstallation](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/DesktopAppTransition)

<a id="add" />

### <a name="add-options-to-the-context-menus-of-files-that-have-a-certain-file-type"></a>特定の種類のファイルのコンテキスト メニューにオプションを追加する

ほとんどの場合、ユーザーはファイルをダブルクリックして開きます。 ユーザーがファイルを右クリックすると、さまざまなオプションが表示されます。

このメニューには、オプションを追加できます。 これらのオプションを使用すると、ファイルの印刷、編集、プレビューなど、ファイルの操作を別の方法で行うことができます。

#### <a name="xml-namespaces"></a>XML 名前空間

* http://schemas.microsoft.com/appx/manifest/uap/windows10
* http://schemas.microsoft.com/appx/manifest/uap/windows10/2
* http://schemas.microsoft.com/appx/manifest/uap/windows10/3


#### <a name="elements-and-attributes-of-this-extension"></a>この拡張機能の要素と属性

```XML
<Extension Category="windows.fileTypeAssociation">
    <FileTypeAssociation Name="[AppID]">
        <SupportedVerbs>
              <Verb Id="[ID]" Extended="[Extended]" Parameters="[parameters]">"[verb label]"</Verb>
        </SupportedVerbs>
    </FileTypeAssociation>
</Extension>
```

完全なスキーマ リファレンスについては、[こちら](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-uap-filetypeassociation)をご覧ください。

|名前 |説明 |
|-------|-------------|
|Category | 常に ``windows.fileTypeAssociation`` です。
|名前 |アプリの一意の ID。 |
|Verb |エクスプローラーのコンテキスト メニューに表示される名前です。 この文字列は、```ms-resource``` を使用してローカライズできます。|
|Id |動詞の一意の ID。 アプリが UWP アプリの場合は、ユーザーの選択内容を適切に処理できるようにアクティブ化イベント引数の一部としてアプリに渡されます。 アプリが完全に信頼できるパッケージ アプリの場合は、パラメーターを受け取ります (次の項目をご覧ください)。 |
|パラメーター |動詞に関連付けられている引数のパラメーターと値のリスト。 アプリが完全に信頼できるパッケージ アプリの場合は、アプリケーションがアクティブ化されるときに、これらのパラメーターがイベント引数としてアプリケーションに渡されます。 さまざまなアクティブ化の動詞に基づいてアプリの動作をカスタマイズすることができます。 変数にファイル パスが含まれる可能性がある場合は、パラメーター値を引用符で囲みます。 これにより、パスにスペースが含まれている場合に発生する問題を回避できます。 アプリが UWP アプリの場合は、パラメーターを渡すことはできません。 アプリは、代わりに ID を受け取ります (前の項目を参照してください)。|
|Extended |ユーザーが **Shift** キーを押しながらファイルを右クリックすることでコンテキスト メニューを表示した場合にのみ表示される動詞を指定します。 この属性は省略可能であり、指定されていない場合の既定値は **False** (常に動詞を表示する) です。 この動作は各動詞について個別に指定します ("開く" は例外で、常に **False**)。|

#### <a name="example"></a>例

```XML
<Package
  xmlns:uap="http://schemas.microsoft.com/appx/manifest/uap/windows10"
  xmlns:uap2="http://schemas.microsoft.com/appx/manifest/uap/windows10/2"
  xmlns:uap3="http://schemas.microsoft.com/appx/manifest/uap/windows10/3"

  IgnorableNamespaces="uap, uap2, uap3">
  <Applications>
    <Application>
      <Extensions>
        <uap:Extension Category="windows.fileTypeAssociation">
          <uap3:FileTypeAssociation Name="Contoso">
            <uap2:SupportedVerbs>
              <uap3:Verb Id="Edit" Parameters="/e &quot;%1&quot;">Edit</uap3:Verb>
              <uap3:Verb Id="Print" Extended="true" Parameters="/p &quot;%1&quot;">Print</uap3:Verb>
            </uap2:SupportedVerbs>
          </uap3:FileTypeAssociation>
        </uap:Extension>
      </Extensions>
    </Application>
  </Applications>
</Package>
```
#### <a name="related-sample"></a>関連するサンプル

[WPF picture viewer with transition/migration/uninstallation](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/DesktopAppTransition)

<a id="open" />

### <a name="open-certain-types-of-files-directly-by-using-a-url"></a>URL を使用して特定の種類のファイルを直接開く

ユーザーが既定では特定の種類のファイルを開くときに、アプリのデスクトップ バージョンではなく、新しいパッケージ化されたアプリケーションを開くことを確認することができます。

#### <a name="xml-namespaces"></a>XML 名前空間

* http://schemas.microsoft.com/appx/manifest/uap/windows10
* http://schemas.microsoft.com/appx/manifest/uap/windows10/3"

#### <a name="elements-and-attributes-of-this-extension"></a>この拡張機能の要素と属性

```XML
<Extension Category="windows.fileTypeAssociation">
    <FileTypeAssociation Name="[AppID]" UseUrl="true" Parameters="%1">
        <SupportedFileTypes>
            <FileType>"[FileExtension]"</FileType>
        </SupportedFileTypes> 
    </FileTypeAssociation>
</Extension>
```

完全なスキーマ リファレンスについては、[こちら](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-uap-filetypeassociation)をご覧ください。

|名前 |説明 |
|-------|-------------|
|Category |常に ``windows.fileTypeAssociation`` です。
|名前 |アプリの一意の ID。 |
|UseUrl |URL ターゲットから直接ファイルを開くかどうかを示します。 この値を設定しない場合は、システムを使って URL 原因、最初のダウンロード ファイルをローカル ファイルを開くアプリケーションでしようとします。 |
|パラメーター |省略可能なパラメーター。 |
|FileType |関連するファイル拡張子。 |

#### <a name="example"></a>例

```XML
<Package
  xmlns:uap="http://schemas.microsoft.com/appx/manifest/uap/windows10"
  xmlns:uap3="http://schemas.microsoft.com/appx/manifest/uap/windows10/3"
  IgnorableNamespaces="uap, uap3">
  <Applications>
      <Application>
        <Extensions>
          <uap:Extension Category="windows.fileTypeAssociation">
            <uap3:FileTypeAssociation Name="documenttypes" UseUrl="true" Parameters="%1">
              <uap:SupportedFileTypes>
                <uap:FileType>.txt</uap:FileType>
                <uap:FileType>.doc</uap:FileType>
              </uap:SupportedFileTypes> 
            </uap3:FileTypeAssociation>
          </uap:Extension>
        </Extensions>
      </Application>
    </Applications>
</Package>
```

## <a name="perform-setup-tasks"></a>セットアップ タスクを実行する

* [アプリのファイアウォール例外を作成する](#rules)
* [DLL ファイルをパッケージの任意のフォルダーに配置します。](#load-paths)

<a id="rules" />

### <a name="create-firewall-exception-for-your-app"></a>アプリのファイアウォール例外を作成する

アプリケーションは、ポート経由で通信を必要とする場合は、ファイアウォールの例外の一覧にアプリを追加できます。

#### <a name="xml-namespace"></a>XML 名前空間

http://schemas.microsoft.com/appx/manifest/desktop/windows10/2

#### <a name="elements-and-attributes-of-this-extension"></a>この拡張機能の要素と属性

```XML
<Extension Category="windows.firewallRules">  
  <FirewallRules Executable="[executable file name]">  
    <Rule
      Direction="[Direction]"
      IPProtocol="[Protocol]"
      LocalPortMin="[LocalPortMin]"
      LocalPortMax="LocalPortMax"
      RemotePortMin="RemotePortMin"
      RemotePortMax="RemotePortMax"
      Profile="[Profile]"/>  
  </FirewallRules>  
</Extension>
```
完全なスキーマ リファレンスについては、[こちら](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-desktop2-firewallrules)をご覧ください。

|名前 |説明 |
|-------|-------------|
|Category |常に  ``windows.firewallRules``|
|Executable |ファイアウォールの例外の一覧に追加する実行可能ファイルの名前。 |
|Direction |規則が受信規則か送信規則かを示します。 |
|IPProtocol |通信プロトコル。 |
|LocalPortMin |ローカル ポート番号の範囲を示すポート番号の下限。 |
|LocalPortMax |ローカル ポート番号の範囲を示すポート番号の上限。 |
|RemotePortMax |リモート ポート番号の範囲を示すポート番号の下限。 |
|RemotePortMax |リモート ポート番号の範囲を示すポート番号の上限。 |
|Profile |ネットワークの種類。 |



#### <a name="example"></a>例

```XML
<Package
  xmlns:desktop2="http://schemas.microsoft.com/appx/manifest/desktop/windows10/2"
  IgnorableNamespaces="desktop2">
  <Extensions>
    <desktop2:Extension Category="windows.firewallRules">  
      <desktop2:FirewallRules Executable="Contoso.exe">  
          <desktop2:Rule Direction="in" IPProtocol="TCP" Profile="all"/>  
          <desktop2:Rule Direction="in" IPProtocol="UDP" LocalPortMin="1337" LocalPortMax="1338" Profile="domain"/>  
          <desktop2:Rule Direction="in" IPProtocol="UDP" LocalPortMin="1337" LocalPortMax="1338" Profile="public"/>  
          <desktop2:Rule Direction="out" IPProtocol="UDP" LocalPortMin="1339" LocalPortMax="1340" RemotePortMin="15"
                         RemotePortMax="19" Profile="domainAndPrivate"/>  
          <desktop2:Rule Direction="out" IPProtocol="GRE" Profile="private"/>  
      </desktop2:FirewallRules>  
  </desktop2:Extension>
</Extensions>
</Package>
```

<a id="load-paths" />

### <a name="place-your-dll-files-into-any-folder-of-the-package"></a>DLL ファイルをパッケージの任意のフォルダーに配置します。

拡張機能を使ってそれらのフォルダーを指定します。 これにより、システムは配置したファイルを見つけて読み込むことができます。 この拡張機能は、_%PATH%_ 環境変数の置き換えと考えてください。

この拡張機能を使わない場合、システムはプロセスのパッケージの依存関係グラフ、パッケージ ルート フォルダー、システム ディレクトリ (_%SystemRoot%\system32_) の順で検索します。 詳しくは、[Windows アプリの検索順序に関するページ](https://msdn.microsoft.com/library/windows/desktop/ms682586.aspx#_search_order_for_windows_store_apps)をご覧ください。

各パッケージには、これらの拡張機能を 1 つだけ含めることができます。 つまり、1 つをメイン パッケージに追加し、他の拡張機能は[オプション パッケージと関連するセット](https://docs.microsoft.com/windows/uwp/packaging/optional-packages)それぞれに 1 つずつ追加できます。

#### <a name="xml-namespace"></a>XML 名前空間

http://schemas.microsoft.com/appx/manifest/uap/windows10/6

#### <a name="elements-and-attributes-of-this-extension"></a>この拡張機能の要素と属性
アプリケーション マニフェストのパッケージ レベルでこの拡張機能を宣言します。

```XML
<Extension Category="windows.loaderSearchPathOverride">
  <LoaderSearchPathOverride>
    <LoaderSearchPathEntry FolderPath="[path]"/>
  </LoaderSearchPathOverride>
</Extension>

```

|名前 | 説明 |
|-------|-------------|
|Category |常に ``windows.loaderSearchPathOverride`` です。
|FolderPath | dll ファイルが含まれているフォルダーのパス。 パッケージのルート フォルダーの相対パスを指定します。 1 つの拡張機能で最大 5 つのパスを指定できます。 システムがパッケージのルート フォルダーにあるファイルを検索するようにする場合、これらのパスのいずれかに空の文字列を使用します。 重複するパスを含めないでください。パスの先頭と末尾にスラッシュや円記号を使わないでください。 <br><br> システムはサブフォルダーを検索しないため、システムが読み込む DLL ファイルが含まれている各フォルダーを明示的に一覧表示してください。|

#### <a name="example"></a>例

```XML
<Package
  xmlns:uap3="http://schemas.microsoft.com/appx/manifest/uap/windows10/6"
  IgnorableNamespaces="uap6">
  ...
    <Extensions>
      <uap6:Extension Category="windows.loaderSearchPathOverride">
        <uap6:LoaderSearchPathOverride>
          <uap6:LoaderSearchPathEntry FolderPath=""/>
          <uap6:LoaderSearchPathEntry FolderPath="folder1/subfolder1"/>
          <uap6:LoaderSearchPathEntry FolderPath="folder2/subfolder2"/>
        </uap6:LoaderSearchPathOverride>
      </uap6:Extension>
    </Extensions>
...
</Package>
```

## <a name="integrate-with-file-explorer"></a>エクスプローラーに統合する

ユーザーが慣れた方法でファイルを整理し操作できるようになります。

* [ユーザーが選択し、同時に複数のファイルを開くときに、アプリケーションの動作を定義します。](#define)
* [エクスプ ローラーでサムネイル画像のファイル内容を表示する](#show)
* [エクスプローラーのプレビュー ウィンドウにファイル内容を表示する](#preview)
* [ユーザーがエクスプローラーの [種類] 列を使用してファイルをグループ化できるようにする](#enable)
* [ファイルのプロパティを検索、インデックス、プロパティ ダイアログ、詳細ウィンドウに利用できるようにする](#make-file-properties)
* [クラウド サービスのファイルがエクスプローラーに表示されるようにする](#cloud-files)

<a id="define" />

### <a name="define-how-your-application-behaves-when-users-select-and-open-multiple-files-at-the-same-time"></a>ユーザーが選択し、同時に複数のファイルを開くときに、アプリケーションの動作を定義します。

ユーザーが同時に複数のファイルを開いたときに、アプリケーションの動作を指定します。

#### <a name="xml-namespaces"></a>XML 名前空間

* http://schemas.microsoft.com/appx/manifest/uap/windows10
* http://schemas.microsoft.com/appx/manifest/uap/windows10/2
* http://schemas.microsoft.com/appx/manifest/uap/windows10/3

#### <a name="elements-and-attributes-of-this-extension"></a>この拡張機能の要素と属性

```XML
<Extension Category="windows.fileTypeAssociation">
    <FileTypeAssociation Name="[AppID]" MultiSelectModel="[SelectionModel]">
        <SupportedVerbs>
            <Verb Id="Edit" MultiSelectModel="[SelectionModel]">Edit</Verb>
        </SupportedVerbs>
          <SupportedFileTypes>
                <FileType>"[FileExtension]"</FileType>
        </SupportedFileTypes>
</Extension>
```
完全なスキーマ リファレンスについては、[こちら](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-uap-filetypeassociation)をご覧ください。

|名前 |説明 |
|-------|-------------|
|Category |常に ``windows.fileTypeAssociation`` です。
|名前 |アプリの一意の ID。 |
|MultiSelectModel |下を参照 |
|FileType |関連するファイル拡張子。 |

**MultSelectModel**

パッケージ デスクトップ アプリには、通常のデスクトップ アプリと同じ 3 つのオプションがあります。

 * ``Player``: アプリケーションは、1 回アクティブ化されます。 すべての選択したファイルは、引数パラメーターとして、アプリケーションに渡されます。
 * ``Single``: アプリケーションは、最初に選択したファイルに 1 回アクティブ化されます。 その他のファイルは無視されます。
 * ``Document``選択された各ファイルについては、アプリケーションの: 新しい別のインスタンスがアクティブ化します。

 ファイルの種類やアクションごとに、さまざまな環境設定項目を設定できます。 たとえば、*Documents* は *Document* モードで開き、*Images* は *Player* モードで開くことができます。

#### <a name="example"></a>例

```XML
<Package
  xmlns:uap="http://schemas.microsoft.com/appx/manifest/uap/windows10"
  xmlns:uap2="http://schemas.microsoft.com/appx/manifest/uap/windows10/2"
  xmlns:uap3="http://schemas.microsoft.com/appx/manifest/uap/windows10/3"
  IgnorableNamespaces="uap, uap2, uap3">
  <Applications>
    <Application>
      <Extensions>
        <uap:Extension Category="windows.fileTypeAssociation">
          <uap3:FileTypeAssociation Name="myapp" MultiSelectModel="Document">
            <uap2:SupportedVerbs>
              <uap3:Verb Id="Edit" MultiSelectModel="Player">Edit</uap3:Verb>
              <uap3:Verb Id="Preview" MultiSelectModel="Document">Preview</uap3:Verb>
            </uap2:SupportedVerbs>
            <uap:SupportedFileTypes>
                <uap:FileType>.txt</uap:FileType>
            </uap:SupportedFileTypes>
        </uap:Extension>
      </Extensions>
    </Application>
  </Applications>
</Package>
```

ユーザーが 15 個以下のファイルを開いた場合、**MultiSelectModel** 属性の既定値は *Player* になります。 それ以外の場合、既定値は *Document* です。 UWP アプリは常に *Player* として起動されます。

<a id="show" />

### <a name="show-file-contents-in-a-thumbnail-image-within-file-explorer"></a>エクスプ ローラーでサムネイル画像のファイル内容を表示する

ファイルが中アイコン、大アイコン、特大アイコンで表示された場合に、ファイル内容のサムネイル画像をユーザーが確認できるようにします。

#### <a name="xml-namespace"></a>XML 名前空間

* http://schemas.microsoft.com/appx/manifest/uap/windows10
* http://schemas.microsoft.com/appx/manifest/uap/windows10/2
* http://schemas.microsoft.com/appx/manifest/uap/windows10/3
* http://schemas.microsoft.com/appx/manifest/desktop/windows10/2

#### <a name="elements-and-attributes-of-this-extension"></a>この拡張機能の要素と属性

```XML
<Extension Category="windows.fileTypeAssociation">
    <FileTypeAssociation Name="[AppID]">
        <SupportedFileTypes>
            <FileType>"[FileExtension]"</FileType>
        </SupportedFileTypes>
        <ThumbnailHandler
            Clsid  ="[Clsid  ]" />
    </FileTypeAssociation>
</Extension>
```

完全なスキーマ リファレンスについては、[こちら](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-uap-filetypeassociation)をご覧ください。

|名前 |説明 |
|-------|-------------|
|Category |常に ``windows.fileTypeAssociation`` です。
|名前 |アプリの一意の ID。 |
|FileType |関連するファイル拡張子。 |
|Clsid   |アプリのクラス ID。 |

#### <a name="example"></a>例

```XML
<Package
  xmlns:uap="http://schemas.microsoft.com/appx/manifest/uap/windows10"
  xmlns:uap2="http://schemas.microsoft.com/appx/manifest/uap/windows10/2"
  xmlns:uap3="http://schemas.microsoft.com/appx/manifest/uap/windows10/3"
  xmlns:desktop2="http://schemas.microsoft.com/appx/manifest/desktop/windows10/2"
  IgnorableNamespaces="uap, uap2, uap3, desktop2">
  <Applications>
    <Application>
      <Extensions>
        <uap:Extension Category="windows.fileTypeAssociation">
          <uap3:FileTypeAssociation Name="Contoso">
            <uap2:SupportedFileTypes>
              <uap:FileType>.bar</uap:FileType>
            </uap2:SupportedFileTypes>
            <desktop2:ThumbnailHandler
              Clsid  ="20000000-0000-0000-0000-000000000001"  />
            </uap3:FileTypeAssociation>
         </uap::Extension>
      </Extensions>
    </Application>
  </Applications>
</Package>
```

<a id="preview" />

### <a name="show-file-contents-in-the-preview-pane-of-file-explorer"></a>エクスプローラーのプレビュー ウィンドウにファイル内容を表示する

エクスプローラーのプレビュー ウィンドウで、ユーザーがファイルの内容をプレビューできるようにします。

#### <a name="xml-namespace"></a>XML 名前空間

* http://schemas.microsoft.com/appx/manifest/uap/windows10
* http://schemas.microsoft.com/appx/manifest/uap/windows10/2
* http://schemas.microsoft.com/appx/manifest/uap/windows10/3
* http://schemas.microsoft.com/appx/manifest/desktop/windows10/2

#### <a name="elements-and-attributes-of-this-extension"></a>この拡張機能の要素と属性

```XML
<Extension Category="windows.fileTypeAssociation">
    <FileTypeAssociation Name="[AppID]">
        <SupportedFileTypes>
            <FileType>"[FileExtension]"</FileType>
        </SupportedFileTypes>
        <DesktopPreviewHandler Clsid  ="[Clsid  ]" />
    </FileTypeAssociation>
</Extension>
```

完全なスキーマ リファレンスについては、[こちら](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-uap-filetypeassociation)をご覧ください。

|名前 |説明 |
|-------|-------------|
|Category |常に ``windows.fileTypeAssociation`` です。
|名前 |アプリの一意の ID。 |
|FileType |関連するファイル拡張子。 |
|Clsid   |アプリのクラス ID。 |

#### <a name="example"></a>例

```XML
<Package
  xmlns:uap="http://schemas.microsoft.com/appx/manifest/uap/windows10"
  xmlns:uap2="http://schemas.microsoft.com/appx/manifest/uap/windows10/2"
  xmlns:uap3="http://schemas.microsoft.com/appx/manifest/uap/windows10/3"
  xmlns:desktop2="http://schemas.microsoft.com/appx/manifest/desktop/windows10/2"
  IgnorableNamespaces="uap, uap2, uap3, desktop2">
  <Applications>
    <Application>
      <Extensions>
        <uap:Extension Category="windows.fileTypeAssociation">
          <uap3:FileTypeAssociation Name="Contoso">
            <uap2SupportedFileTypes>
              <uap:FileType>.bar</uap:FileType>
                </uap2SupportedFileTypes>
              <desktop2:DesktopPreviewHandler Clsid ="20000000-0000-0000-0000-000000000001" />
           </uap3:FileTypeAssociation>
        </uap:Extension>
      </Extensions>
    </Application>
  </Applications>
</Package>
```

<a id="enable" />

### <a name="enable-users-to-group-files-by-using-the-kind-column-in-file-explorer"></a>ユーザーがエクスプローラーの [種類] 列を使用してファイルをグループ化できるようにする

ファイルの種類に関する 1 つまたは複数の定義済みの値を **Kind** フィールドに関連付けることができます。

ユーザーはエクスプローラーでこのフィールドを使用して、ファイルをグループ化できます。 また、このフィールドは、システム コンポーネントによって、インデックス作成などのさまざまな目的にも使用されます。

**Kind** フィールドの詳細と、このフィールドに使用できる値については、「[種類名の使用](https://msdn.microsoft.com/library/windows/desktop/cc144136.aspx)」をご覧ください。

#### <a name="xml-namespaces"></a>XML 名前空間

* http://schemas.microsoft.com/appx/manifest/uap/windows10
* http://schemas.microsoft.com/appx/manifest/foundation/windows10/restrictedcapabilities/3

#### <a name="elements-and-attributes-of-this-extension"></a>この拡張機能の要素と属性

```XML
<Extension Category="windows.fileTypeAssociation">
    <FileTypeAssociation Name="[AppID]">
        <SupportedFileTypes>
            <FileType>"[FileExtension]"</FileType>
        </SupportedFileTypes>
        <KindMap>
            <Kind value="[KindValue]">
        </KindMap>
    </FileTypeAssociation>
</Extension>
```
完全なスキーマ リファレンスについては、[こちら](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-uap-filetypeassociation)をご覧ください。

|名前 |説明 |
|-------|-------------|
|Category |常に ``windows.fileTypeAssociation`` です。
|名前 |アプリの一意の ID。 |
|FileType |関連するファイル拡張子。 |
|value |有効な [Kind 値](https://msdn.microsoft.com/en-us/library/windows/desktop/cc144136.aspx#kind_hierarchy)。 |

#### <a name="example"></a>例

```XML
<Package
  xmlns:uap="http://schemas.microsoft.com/appx/manifest/uap/windows10"
  xmlns:rescap="http://schemas.microsoft.com/appx/manifest/foundation/windows10/restrictedcapabilities/3"
  IgnorableNamespaces="uap, rescap">
  <Applications>
    <Application>
      <Extensions>
        <uap:Extension Category="windows.fileTypeAssociation">
           <uap:FileTypeAssociation Name="Contoso">
             <uap:SupportedFileTypes>
               <uap:FileType>.m4a</uap:FileType>
               <uap:FileType>.mta</uap:FileType>
             </uap:SupportedFileTypes>
             <rescap:KindMap>
               <rescap:Kind value="Item">
               <rescap:Kind value="Communications">
               <rescap:Kind value="Task">
             </rescap:KindMap>
          </uap:FileTypeAssociation>
      </uap:Extension>
      </Extensions>
    </Application>
  </Applications>
</Package>
```
<a id="make-file-properties" />

### <a name="make-file-properties-available-to-search-index-property-dialogs-and-the-details-pane"></a>ファイルのプロパティを検索、インデックス、プロパティ ダイアログ、詳細ウィンドウに利用できるようにする

#### <a name="xml-namespace"></a>XML 名前空間

* http://schemas.microsoft.com/appx/manifest/uap/windows10
* http://schemas.microsoft.com/appx/manifest/uap/windows10/3
* http://schemas.microsoft.com/appx/manifest/desktop/windows10/2

#### <a name="elements-and-attributes-of-this-extension"></a>この拡張機能の要素と属性

```XML
<uap:Extension Category="windows.fileTypeAssociation">
    <uap:FileTypeAssociation Name="[AppID]">
        <SupportedFileTypes>
            <FileType>.bar</FileType>
        </SupportedFileTypes>
        <DesktopPropertyHandler Clsid ="[Clsid]"/>
    </uap:FileTypeAssociation>
</uap:Extension>
```
完全なスキーマ リファレンスについては、[こちら](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-uap-filetypeassociation)をご覧ください。

|名前 |説明 |
|-------|-------------|
|Category |常に ``windows.fileTypeAssociation`` です。
|名前 |アプリの一意の ID。 |
|FileType |関連するファイル拡張子。 |
|Clsid  |アプリのクラス ID。 |

#### <a name="example"></a>例

```XML
<Package
  xmlns:uap="http://schemas.microsoft.com/appx/manifest/uap/windows10"
  xmlns:uap3="http://schemas.microsoft.com/appx/manifest/uap/windows10/3"
  xmlns:desktop2="http://schemas.microsoft.com/appx/manifest/desktop/windows10/2"
  IgnorableNamespaces="uap, uap3, desktop2">
  <Applications>
    <Application>
      <Extensions>
        <uap:Extension Category="windows.fileTypeAssociation">
          <uap3:FileTypeAssociation Name="Contoso">
            <uap:SupportedFileTypes>
              <uap:FileType>.bar</uap:FileType>
            </uap:SupportedFileTypes>
            <desktop2:DesktopPropertyHandler Clsid ="20000000-0000-0000-0000-000000000001"/>
          </uap3:FileTypeAssociation>
        </uap:Extension>
      </Extensions>
    </Application>
  </Applications>
</Package>
```

<a id="cloud-files" />

### <a name="make-files-from-your-cloud-service-appear-in-file-explorer"></a>クラウド サービスのファイルがエクスプローラーに表示されるようにする

アプリに実装するハンドラーを登録する ユーザーがエクスプローラーでクラウド ベースのファイルを右クリックしたときに表示されるコンテキスト メニュー オプションを追加することもできます。

#### <a name="xml-namespace"></a>XML 名前空間

* http://schemas.microsoft.com/appx/manifest/desktop/windows10

#### <a name="elements-and-attributes-of-this-extension"></a>この拡張機能の要素と属性

```XML
<Extension Category="windows.cloudfiles" >
    <CloudFiles IconResource="[Icon]">
        <CustomStateHandler Clsid ="[Clsid]"/>
        <ThumbnailProviderHandler Clsid ="[Clsid]"/>
        <ExtendedPropertyhandler Clsid ="[Clsid]"/>
        <CloudFilesContextMenus>
            <Verb Id ="Command3" Clsid= "[GUID]">[Verb Label]</Verb>
        </CloudFilesContextMenus>
    </CloudFiles>
</Extension>

```

|名前 |説明 |
|-------|-------------|
|Category |常に ``windows.cloudfiles`` です。
|iconResource |クラウド ファイル プロバイダー サービスを表すアイコン。 このアイコンは、エクスプローラーのナビゲーション ウィンドウに表示されます。  ユーザーは、このアイコンを選んでクラウド サービスのファイルを表示します。 |
|CustomStateHandler Clsid |CustomStateHandler を実装するアプリケーションのクラス ID。 システムは、このクラス ID を使ってクラウド ファイルのカスタム状態と列を要求します。 |
|ThumbnailProviderHandler Clsid |ThumbnailProviderHandler を実装するアプリケーションのクラス ID。 システムは、このクラス ID を使ってクラウド ファイルの縮小版イメージを要求します。 |
|ExtendedPropertyHandler Clsid |ExtendedPropertyHandler を実装するアプリケーションのクラス ID。  システムは、このクラス ID を使ってクラウド ファイルの拡張プロパティを要求します。 |
|Verb |クラウド サービスによって提供されるファイルのエクスプローラー コンテキスト メニューに表示される名前です。 |
|Id |動詞の一意の ID。 |

#### <a name="example"></a>例

```XML
<Package
    xmlns:desktop="http://schemas.microsoft.com/appx/manifest/desktop/windows10"
    IgnorableNamespaces="desktop">
  <Applications>
    <Application>
      <Extensions>
        <Extension Category="windows.cloudfiles" >
            <CloudFiles IconResource="images\Wide310x150Logo.png">
                <CustomStateHandler Clsid ="20000000-0000-0000-0000-000000000001"/>
                <ThumbnailProviderHandler Clsid ="20000000-0000-0000-0000-000000000001"/>
                <ExtendedPropertyhandler Clsid ="20000000-0000-0000-0000-000000000001"/>
                <desktop:CloudFilesContextMenus>
                    <desktop:Verb Id ="keep" Clsid=     
                       "20000000-0000-0000-0000-000000000001">
                       Always keep on this device</desktop:Verb>
                </desktop:CloudFilesContextMenus>
            </CloudFiles>
          </Extension>
      </Extensions>
    </Application>
  </Applications>
</Package>
```

<a id="start" />

## <a name="start-your-application-in-different-ways"></a>さまざまな方法でアプリケーションを起動します。

* [プロトコルを使用してアプリケーションを起動します。](#protocol)
* [エイリアスを使用して、アプリケーションを起動します。](#alias)
* [ユーザーが Windows にログオンしたときに実行可能ファイルを起動する](#executable)
* [デバイスを自分の PC に接続するときに、アプリケーションを起動できるようにします。](#autoplay)
* [Microsoft Store から更新プログラムを受信した後、自動的に再起動する](#updates)

<a id="protocol" />

### <a name="start-your-application-by-using-a-protocol"></a>プロトコルを使用してアプリケーションを起動します。

プロトコルの関連付けによって、他のプログラムやシステム コンポーネントがパッケージ アプリと相互運用できるようにします。 プロトコルを使用してパッケージ化されたアプリケーションが開始されると、それに応じて動作ことができるように、アクティブ化イベント引数に渡す特定のパラメーターを指定できます。 パラメーターは、完全に信頼できるパッケージ アプリでのみサポートされています。 UWP アプリでは、パラメーターを使用できません。  

#### <a name="xml-namespace"></a>XML 名前空間

http://schemas.microsoft.com/appx/manifest/uap/windows10/3


#### <a name="elements-and-attributes-of-this-extension"></a>この拡張機能の要素と属性

```XML
<Extension
    Category="windows.protocol">
    <Protocol
      Name="[Protocol name]"
      Parameters="[Parameters]" />
</Extension>
```

完全なスキーマ リファレンスについては、[こちら](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-uap-protocol)をご覧ください。

|名前 |説明 |
|-------|-------------|
|Category |常に ``windows.protocol`` です。
|Name |プロトコルの名前。 |
|パラメーター |パラメーターと、アプリケーションがアクティブ化されるときにイベント引数としてアプリに渡す値の一覧。 変数にファイル パスが含まれる可能性がある場合は、パラメーター値を引用符で囲みます。 これにより、パスにスペースが含まれている場合に発生する問題を回避できます。 |

### <a name="example"></a>例

```XML
<Package
  xmlns:uap3="http://schemas.microsoft.com/appx/manifest/uap/windows10/3"
  IgnorableNamespaces="uap3">
  <Applications>
    <Application>
      <Extensions>
        <uap3:Extension
          Category="windows.protocol">
        <uap3:Protocol
          Name="myapp-cmd"
          Parameters="/p &quot;%1&quot;" />
        </uap3:Extension>
      </Extensions>
    </Application>
  </Applications>
</Package>
```
<a id="alias" />

### <a name="start-your-application-by-using-an-alias"></a>エイリアスを使用して、アプリケーションを起動します。

ユーザーおよびその他のプロセスは、アプリへの完全パスを指定するのにことがなく、アプリケーションを開始するのに、エイリアスを使用することができます。 そのエイリアス名を指定できます。

#### <a name="xml-namespaces"></a>XML 名前空間

* http://schemas.microsoft.com/appx/manifest/uap/windows10/3
* http://schemas.microsoft.com/appx/manifest/desktop/windows10


#### <a name="elements-and-attributes-of-this-extension"></a>この拡張機能の要素と属性

```XML
<Extension
    Category="windows.appExecutionAlias"
    Executable="[ExecutableName]"
    EntryPoint="Windows.FullTrustApplication">
    <AppExecutionAlias>
            <desktop:ExecutionAlias Alias="[AliasName]" />
      </AppExecutionAlias>
</Extension>
```

|名前 |説明 |
|-------|-------------|
|Category |常に ``windows.appExecutionAlias`` です。
|Executable |エイリアスが呼び出されたときに起動する実行可能ファイルの相対パス。 |
|Alias |アプリの短い名前。 常に、拡張子 ".exe" で終わっている必要があります。 パッケージ内のアプリケーションごとにアプリの実行エイリアスは 1 つだけ指定できます。 複数のアプリで同じエイリアスが登録されている場合、システムは最後に登録されたアプリを呼び出します。したがって、他のアプリが上書きする可能性が低い一意のエイリアスを選んでください。
|

#### <a name="example"></a>例

```XML
<Package
  xmlns:uap3="http://schemas.microsoft.com/appx/manifest/uap/windows10/3"
  xmlns:desktop="http://schemas.microsoft.com/appx/manifest/desktop/windows10"
  IgnorableNamespaces="uap3, desktop">
  ...
  <uap3:Extension
        Category="windows.appExecutionAlias"
        Executable="exes\launcher.exe"
        EntryPoint="Windows.FullTrustApplication">
        <uap3:AppExecutionAlias>
            <desktop:ExecutionAlias Alias="Contoso.exe" />
        </uap3:AppExecutionAlias>
  </uap3:Extension>
...
</Package>
```

完全なスキーマ リファレンスについては、[こちら](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-uap-filetypeassociation)をご覧ください。

<a id="executable" />

### <a name="start-an-executable-file-when-users-log-into-windows"></a>ユーザーが Windows にログオンしたときに実行可能ファイルを起動する

スタートアップ タスクは、ユーザーがログオンするたびに、実行可能ファイルを自動的に実行するアプリケーションを許可します。

> [!NOTE]
> ユーザーは、このスタートアップ タスクを登録するアプリケーションで少なくとも 1 回の開始があります。

アプリケーションでは、複数のスタートアップ タスクを宣言できます。 各タスクは独立して起動されます。 すべてのスタートアップ タスクは、タスク マネージャーの **[スタートアップ]** タブに、アプリのマニフェストで指定した名前とアプリのアイコンを使って表示されます。 タスク マネージャーによって、タスクの起動への影響が自動的に分析されます。

ユーザーは、タスク マネージャーを使用して、アプリのスタートアップ タスクを手動で無効にすることができます。 ユーザーがタスクを無効にした場合、プログラムでタスクを再度有効にすることはできません。

#### <a name="xml-namespace"></a>XML 名前空間

http://schemas.microsoft.com/appx/manifest/desktop/windows10

#### <a name="elements-and-attributes-of-this-extension"></a>この拡張機能の要素と属性

```XML
<Extension
    Category="windows.startupTask"
    Executable="[ExecutableName]"
    EntryPoint="Windows.FullTrustApplication">
    <StartupTask
      TaskId="[TaskID]"
      Enabled="true"
      DisplayName="[DisplayName]" />
</Extension>
```

|名前 |説明 |
|-------|-------------|
|Category |常に ``windows.startupTask`` です。|
|Executable |起動する実行可能ファイルへの相対パス。 |
|TaskId |タスクの一意の識別子。 この識別子を使用して、アプリケーションはプログラムによって有効にするまたはスタートアップ タスクを無効にするには、 [Windows.ApplicationModel.StartupTask](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.StartupTask)クラスで Api を呼び出すことができます。 |
|有効 |初めて起動したタスクを有効にするか、無効にするかを指定します。 有効になっているタスクは、(ユーザーが無効にしていない限り) 次回ユーザーがログオンするときに実行されます。 |
|DisplayName |タスク マネージャーに表示されるタスクの名前。 この文字列は、```ms-resource``` を使用してローカライズできます。 |

#### <a name="example"></a>例

```XML
<Package
  xmlns:desktop="http://schemas.microsoft.com/appx/manifest/desktop/windows10"
  IgnorableNamespaces="desktop">
  <Applications>
    <Application>
      <Extensions>
        <desktop:Extension
          Category="windows.startupTask"
          Executable="bin\MyStartupTask.exe"
          EntryPoint="Windows.FullTrustApplication">
          <desktop:StartupTask
          TaskId="MyStartupTask"
          Enabled="true"
          DisplayName="My App Service" />
        </desktop:Extension>
      </Extensions>
    </Application>
  </Applications>
 </Package>
```
<a id="autoplay" />

### <a name="enable-users-to-start-your-application-when-they-connect-a-device-to-their-pc"></a>デバイスを自分の PC に接続するときに、アプリケーションを起動できるようにします。

自動再生は、ユーザーがデバイスを自分の PC に接続するときにオプションとしてアプリを表示できます。

#### <a name="xml-namespace"></a>XML 名前空間

http://schemas.microsoft.com/appx/manifest/desktop/windows10/3


#### <a name="elements-and-attributes-of-this-extension"></a>この拡張機能の要素と属性

```XML
<Extension Category="windows.autoPlayHandler">
  <AutoPlayHandler>
    <InvokeAction ActionDisplayName="[action string]" ProviderDisplayName="[name of your app/service]">
      <Content ContentEvent="[Content event]" Verb="[any string]" DropTargetHandler="[Clsid]" />
      <Content ContentEvent="[Content event]" Verb="[any string]" Parameters="[Initialization parameter]"/>
      <Device DeviceEvent="[Device event]" HWEventHandler="[Clsid]" InitCmdLine="[Initialization parameter]"/>
    </InvokeAction>
  </AutoPlayHandler>
```

|名前 |説明 |
|-------|-------------|
|Category |常に ``windows.autoPlayHandler`` です。
|ActionDisplayName |ユーザーが PC に接続したときにデバイスで実行できるアクションを表す文字列 (例: "ファイルのインポート" や "ビデオの再生")。 |
|ProviderDisplayName | アプリケーションまたはサービスを表す文字列 (例:「Contoso ビデオ プレーヤー」)。 |
|ContentEvent |ユーザーに ``ActionDisplayName`` と ``ProviderDisplayName`` をプロンプト表示する原因となるコンテンツ イベントの名前。 コンテンツ イベントは、カメラのメモリ カード、サム ドライブ、DVD などのボリューム デバイスが PC に挿入されたときに発生します。 これらのイベントの詳しい一覧については、[ここ](https://docs.microsoft.com/windows/uwp/launch-resume/auto-launching-with-autoplay#autoplay-event-reference)をご覧ください。  |
|動詞 |[動詞] 設定では、選択したオプションのアプリケーションに渡される値を識別します。 自動再生のイベントの起動アクションは複数指定できます。また、[動詞] 設定を使って、ユーザーがアプリで選んだアクションを確認できます。 アプリに渡される起動イベント引数の verb プロパティを調べることでユーザーが選んだオプションを確認できます。 [動詞] 設定には任意の値を使うことができます。ただし、予約されている open を除きます。 |
|DropTargetHandler |[IDropTarget](https://docs.microsoft.com/dotnet/api/microsoft.visualstudio.ole.interop.idroptarget?view=visualstudiosdk-2017)インターフェイスを実装するアプリケーションのクラス ID。 リムーバブル メディアのファイルは、[IDropTarget](https://docs.microsoft.com/dotnet/api/microsoft.visualstudio.ole.interop.idroptarget?view=visualstudiosdk-2017) 実装の [Drop](https://docs.microsoft.com/dotnet/api/microsoft.visualstudio.ole.interop.idroptarget.drop?view=visualstudiosdk-2017#Microsoft_VisualStudio_OLE_Interop_IDropTarget_Drop_Microsoft_VisualStudio_OLE_Interop_IDataObject_System_UInt32_Microsoft_VisualStudio_OLE_Interop_POINTL_System_UInt32__) メソッドに渡されます。  |
|パラメーター |すべてのコンテンツ イベントで [IDropTarget](https://docs.microsoft.com/dotnet/api/microsoft.visualstudio.ole.interop.idroptarget?view=visualstudiosdk-2017) インターフェイスを実装する必要はありません。 どのコンテンツ イベントにも、[IDropTarget](https://docs.microsoft.com/dotnet/api/microsoft.visualstudio.ole.interop.idroptarget?view=visualstudiosdk-2017) インターフェイスを実装する代わりにコマンド ライン パラメーターを指定することができます。 これらのイベントでは、自動再生がこれらのコマンド ライン パラメーターを使用してアプリケーションを起動します。 アプリの初期化コードでそれらのパラメーターを解析して、自動再生によって起動したかどうかを判断し、カスタム実装を提供することができます。 |
|DeviceEvent |ユーザーに ``ActionDisplayName`` と ``ProviderDisplayName`` をプロンプト表示する原因となるデバイス イベントの名前。 デバイス イベントは、デバイスが PC に接続されると発生します。 デバイス イベントの先頭は文字列 ``WPD`` です。一覧については[ここ](https://docs.microsoft.com/windows/uwp/launch-resume/auto-launching-with-autoplay#autoplay-event-reference)をご覧ください。 |
|HWEventHandler |[IHWEventHandler](https://msdn.microsoft.com/library/windows/desktop/bb775492.aspx)インターフェイスを実装するアプリケーションのクラス ID。 |
|InitCmdLine |[IHWEventHandler](https://msdn.microsoft.com/library/windows/desktop/bb775492.aspx) インターフェイスの [Initialize](https://msdn.microsoft.com/en-us/library/windows/desktop/bb775495.aspx) メソッドに渡す文字列パラメーター。 |

### <a name="example"></a>例

```XML
<Package
  xmlns:desktop3="http://schemas.microsoft.com/appx/manifest/desktop/windows10/3"
  IgnorableNamespaces="desktop3">
  <Applications>
    <Application>
      <Extensions>
        <desktop3:Extension Category="windows.autoPlayHandler">
          <desktop3:AutoPlayHandler>
            <desktop3:InvokeAction ActionDisplayName="Import my files" ProviderDisplayName="ms-resource:AutoPlayDisplayName">
              <desktop3:Content ContentEvent="ShowPicturesOnArrival" Verb="show" DropTargetHandler="CD041BAE-0DEA-4472-9B7B-C98043D26EA8"/>
              <desktop3:Content ContentEvent="PlayVideoFilesOnArrival" Verb="play" Parameters="%1" />
              <desktop3:Device DeviceEvent="WPD\ImageSource" HWEventHandler="CD041BAE-0DEA-4472-9B7B-C98043D26EA8" InitCmdLine="/autoplay"/>
            </desktop3:InvokeAction>
          </desktop3:AutoPlayHandler>
      </Extensions>
    </Application>
  </Applications>
</Package>
```
<a id="updates" />

### <a name="restart-automatically-after-receiving-an-update-from-the-microsoft-store"></a>Microsoft Store から更新プログラムを受信した後、自動的に再起動する

ユーザーを更新プログラムをインストールするときに、アプリケーションが開いている場合は、アプリケーションを閉じます。

更新の完了後に再起動するようにアプリケーションを設定する場合は、再起動するすべてのプロセスで[RegisterApplicationRestart](https://msdn.microsoft.com/library/windows/desktop/aa373347.aspx)関数を呼び出します。

アプリの各アクティブ ウィンドウでは、 [WM_QUERYENDSESSION](https://msdn.microsoft.com/library/windows/desktop/aa376890.aspx)メッセージを受け取ります。 この時点で、アプリケーションでは、必要に応じて、コマンド ラインを更新するには、もう一度[RegisterApplicationRestart](https://msdn.microsoft.com/library/windows/desktop/aa373347.aspx)関数を呼び出すことができます。

アプリケーションの各アクティブ ウィンドウでは、 [WM_ENDSESSION](https://msdn.microsoft.com/library/windows/desktop/aa376889.aspx)メッセージを受信した場合、アプリケーションがデータを保存、シャット ダウンする必要があります。

>[!NOTE]
アクティブ ウィンドウは、アプリケーションが[WM_ENDSESSION](https://msdn.microsoft.com/library/windows/desktop/aa376889.aspx)メッセージを処理しない場合にも[WM_CLOSE](https://msdn.microsoft.com/library/windows/desktop/ms632617.aspx)メッセージを受け取ります。

この時点で、アプリケーション 30 秒、独自のプロセスを終了するか、または終了しなければ、プラットフォームです。

更新が完了したら、アプリを再起動します。

## <a name="work-with-other-applications"></a>他のアプリケーションと連携する

他のアプリとの統合、他のプロセスの開始、情報の共有が可能です。

* [印刷をサポートするアプリケーションで印刷先として表示される、アプリケーションを作成します。](#printing)
* [他の Windows アプリケーションとフォントを共有する](#fonts)
* [ユニバーサル Windows プラットフォーム (UWP) アプリから Win32 プロセスを開始する](#win32-process)

<a id="printing" />

### <a name="make-your-application-appear-as-the-print-target-in-applications-that-support-printing"></a>印刷をサポートするアプリケーションで印刷先として表示される、アプリケーションを作成します。

ユーザーは、メモ帳など別のアプリケーションからデータを印刷する場合、利用できる印刷先のアプリの一覧で印刷先として表示されるアプリケーションを行うことができます。

XML Paper Specification (XPS) 形式で印刷データを受信できるように、アプリケーションを変更する必要があります。

#### <a name="xml-namespaces"></a>XML 名前空間

http://schemas.microsoft.com/appx/manifest/desktop/windows10/2

#### <a name="elements-and-attributes-of-this-extension"></a>この拡張機能の要素と属性

```XML
<Extension Category="windows.appPrinter">
    <AppPrinter
        DisplayName="[DisplayName]"
        Parameters="[Parameters]" />
</Extension>
```

完全なスキーマ リファレンスについては、[こちら](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-desktop2-appprinter)をご覧ください。

|名前 |説明 |
|-------|-------------|
|Category |常に ``windows.appPrinter`` です。
|DisplayName |アプリの印刷先一覧に表示する名前。 |
|パラメーター |要求を適切に処理して、アプリケーションが必要なパラメーターです。 |

#### <a name="example"></a>例

```XML
<Package
  xmlns:desktop2="http://schemas.microsoft.com/appx/manifest/desktop/windows10/2"
  IgnorableNamespaces="desktop2">
  <Applications>
  <Application>
    <Extensions>
      <desktop2:Extension Category="windows.appPrinter">
        <desktop2:AppPrinter
          DisplayName="Send to Contoso"
          Parameters="/insertdoc %1" />
      </desktop2:Extension>
    </Extensions>
  </Application>
</Applications>
</Package>
```
この拡張機能を使用するサンプルについては、[こちら](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/PrintToPDF)をご覧ください。

<a id="fonts" />

### <a name="share-fonts-with-other-windows-applications"></a>他の Windows アプリケーションとフォントを共有する

他の Windows アプリケーションとカスタム フォントを共有できます。

#### <a name="xml-namespaces"></a>XML 名前空間

http://schemas.microsoft.com/appx/manifest/desktop/windows10/2

#### <a name="elements-and-attributes-of-this-extension"></a>この拡張機能の要素と属性

```XML
<Extension Category="windows.sharedFonts">
    <SharedFonts>
      <Font File="[FontFile]" />
    </SharedFonts>
  </Extension>
```

完全なスキーマ リファレンスについては、[こちら](https://review.docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-uap4-sharedfonts)をご覧ください。


|名前 |説明 |
|-------|-------------|
|Category |常に ``windows.sharedFonts`` です。
|File |共有するフォントが格納されたファイル。 |

#### <a name="example"></a>例

```XML
<Package
  xmlns:uap4="http://schemas.microsoft.com/appx/manifest/uap/windows10/4"
  IgnorableNamespaces="uap4">
  <Applications>
    <Application>
      <Extensions>
        <uap4:Extension Category="windows.sharedFonts">
          <uap4:SharedFonts>
            <uap4:Font File="Fonts\JustRealize.ttf" />
            <uap4:Font File="Fonts\JustRealizeBold.ttf" />
          </uap4:SharedFonts>
        </uap4:Extension>
      </Extensions>
    </Application>
  </Applications>
</Package>
```
<a id="win32-process" />

### <a name="start-a-win32-process-from-a-universal-windows-platform-uwp-app"></a>ユニバーサル Windows プラットフォーム (UWP) アプリから Win32 プロセスを開始する

完全信頼で実行される Win32 プロセスを開始します。

#### <a name="xml-namespaces"></a>XML 名前空間

http://schemas.microsoft.com/appx/manifest/desktop/windows10

#### <a name="elements-and-attributes-of-this-extension"></a>この拡張機能の要素と属性

```XML
<Extension Category="windows.fullTrustProcess" Executable="[executable file]">
  <FullTrustProcess>
    <ParameterGroup GroupId="[GroupID]" Parameters="[Parameters]"/>
  </FullTrustProcess>
</Extension>
```

|名前 |説明 |
|-------|-------------|
|Category |常に ``windows.fullTrustProcess`` です。
|GroupID |実行可能ファイルに渡すパラメーターのセットを識別するための文字列。 |
|Parameters |実行可能ファイルに渡すパラメーター。 |

#### <a name="example"></a>例

```XML
<Package xmlns="http://schemas.microsoft.com/appx/manifest/foundation/windows10"
         xmlns:uap="http://schemas.microsoft.com/appx/manifest/uap/windows10"
         xmlns:rescap=
"http://schemas.microsoft.com/appx/manifest/foundation/windows10/restrictedcapabilities"
         xmlns:desktop="http://schemas.microsoft.com/appx/manifest/desktop/windows10">
  ...
  <Capabilities>
      <rescap:Capability Name="runFullTrust"/>
  </Capabilities>
  <Applications>
    <Application>
      <Extensions>
          <desktop:Extension Category="windows.fullTrustProcess" Executable="fulltrustprocess.exe">
              <desktop:FullTrustProcess>
                  <desktop:ParameterGroup GroupId="SyncGroup" Parameters="/Sync"/>
                  <desktop:ParameterGroup GroupId="OtherGroup" Parameters="/Other"/>
              </desktop:FullTrustProcess>
           </desktop:Extension>
      </Extensions>
    </Application>
  </Applications>
</Package>
```
この拡張機能をすべてのデバイスで実行されるユニバーサル Windows プラットフォームのユーザー インターフェイスを作成する場合に役立つことがありますが、完全信頼で実行を続ける Win32 アプリケーションのコンポーネントをします。

Win32 アプリの Windows アプリ パッケージの作成だけです。 そのうえで、この拡張機能を UWP アプリのパッケージ ファイルに追加してください。 この拡張機能では、Windows アプリ パッケージで実行可能ファイルを開始することを示します。  UWP アプリと Win32 アプリの間でやり取りを行うには、1 つまたは複数の[アプリ サービス](../launch-resume/app-services.md)を設定します。 このシナリオについては詳しくは、[こちら](https://blogs.msdn.microsoft.com/appconsult/2016/12/19/desktop-bridge-the-migrate-phase-invoking-a-win32-process-from-a-uwp-app/)をご覧ください。

## <a name="next-steps"></a>次のステップ

**質問に対する回答を見つける**

ご質問がある場合は、 Stack Overflow でお問い合わせください。 Microsoft のチームでは、これらの[タグ](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge)をチェックしています。 [こちら](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D)から質問することもできます。

**フィードバックの提供または機能の提案を行う**

[UserVoice](https://wpdev.uservoice.com/forums/110705-universal-windows-platform/category/161895-desktop-bridge-centennial) のページをご覧ください。
