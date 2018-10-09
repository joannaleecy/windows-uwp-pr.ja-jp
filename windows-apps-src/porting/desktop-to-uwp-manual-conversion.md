---
author: normesta
Description: Shows how to manually package a Windows desktop application (like Win32, WPF, and Windows Forms) for Windows 10.
Search.Product: eADQiWindows 10XVcnh
title: アプリケーションを手動でパッケージ化 (デスクトップ ブリッジ)
ms.author: normesta
ms.date: 05/18/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.assetid: e8c2a803-9803-47c5-b117-73c4af52c5b6
ms.localizationpriority: medium
ms.openlocfilehash: 9f14e7f8747639ef139e774416e09af954211940
ms.sourcegitcommit: fbdc9372dea898a01c7686be54bea47125bab6c0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/08/2018
ms.locfileid: "4427515"
---
# <a name="package-a-desktop-application-manually"></a>デスクトップ アプリケーションを手動でパッケージ化します。

このトピックでは、Visual Studio、Desktop App Converter (DAC) などのツールを使用せず、アプリケーションをパッケージ化する方法を示します。

アプリを手動でパッケージ化するには、パッケージ マニフェスト ファイルを作成してから、Windows アプリ パッケージを生成するコマンド ライン ツールを実行します。

Xcopy コマンドを使用して、アプリケーションをインストールするか、アプリのインストーラーによるシステムへの変更を熟知している場合、手動によるパッケージ化を検討し、プロセスをさらに細かく制御します。

インストーラーによってどのような変更がシステムに加えられるのかわからない場合や、自動化ツールを使用してパッケージ マニフェストを生成する場合は、[こちら](desktop-to-uwp-root.md#convert)のオプションのいずれかを検討してください。

>[!IMPORTANT]
>デスクトップ アプリケーションの Windows アプリ パッケージを作成する機能 (、デスクトップ ブリッジとも呼ばれるを Windows 10 バージョン 1607 で導入されたそれ以外の場合と、Windows 10 Anniversary Update (10.0; をターゲットとするプロジェクトでのみ使用できますビルド 14393) 以降の Visual Studio でリリースされます。

## <a name="first-prepare-your-application"></a>まず、アプリケーションを準備します

アプリケーションのパッケージの作成を開始する前に、このガイドを確認:[デスクトップ アプリケーションのパッケージを準備](desktop-to-uwp-prepare.md)します。

## <a name="create-a-package-manifest"></a>パッケージ マニフェストを作成する

ファイルを作成し、**appxmanifest.xml** という名前を付けて、以下の XML を追加します。

これは、パッケージに必要な要素や属性が含まれた基本テンプレートです。 次のセクションで、これらに値を追加します。

```XML
<?xml version="1.0" encoding="utf-8"?>
<Package
    xmlns="http://schemas.microsoft.com/appx/manifest/foundation/windows10"
  xmlns:uap="http://schemas.microsoft.com/appx/manifest/uap/windows10"
  xmlns:rescap="http://schemas.microsoft.com/appx/manifest/foundation/windows10/restrictedcapabilities">
  <Identity Name="" Version="" Publisher="" ProcessorArchitecture="" />
    <Properties>
       <DisplayName></DisplayName>
       <PublisherDisplayName></PublisherDisplayName>
             <Description></Description>
      <Logo></Logo>
    </Properties>
    <Resources>
      <Resource Language="" />
    </Resources>
      <Dependencies>
      <TargetDeviceFamily Name="Windows.Desktop" MinVersion="" MaxVersionTested="" />
      </Dependencies>
      <Capabilities>
        <rescap:Capability Name="runFullTrust"/>
      </Capabilities>
    <Applications>
      <Application Id="" Executable="" EntryPoint="Windows.FullTrustApplication">
        <uap:VisualElements DisplayName="" Description=""   Square150x150Logo=""
                   Square44x44Logo=""   BackgroundColor="" />
      </Application>
     </Applications>
  </Package>
```

## <a name="fill-in-the-package-level-elements-of-your-file"></a>ファイルのパッケージ レベル要素に値を設定する

このテンプレートに、パッケージを説明する情報を設定します。

### <a name="identity-information"></a>Identity 情報

**Identity** 要素の例を以下に示します。各属性にはプレースホルダー テキストが指定されています。 ``ProcessorArchitecture`` 属性は、``x64`` または ``x86`` に設定できます。

```XML
<Identity Name="MyCompany.MySuite.MyApp"
          Version="1.0.0.0"
          Publisher="CN=MyCompany, O=MyCompany, L=MyCity, S=MyState, C=MyCountry"
                ProcessorArchitecture="x64">
```
> [!NOTE]
> Windows ストアでアプリケーション名を予約済み、Windows デベロッパー センター ダッシュ ボードを使用して、名前と発行元を取得できます。 他のシステムにアプリケーションをサイドローディングする場合は、アプリに署名証明書の名前と一致を選択する発行元名を使用する限り、独自の名前を提供できます。

### <a name="properties"></a>プロパティ

[Properties](https://docs.microsoft.com/uwp/schemas/appxpackage/appxmanifestschema/element-properties) 要素には、必須の子要素が 3 つあります。 次に示すのは、**Properties** ノードの例です。要素はプレースホルダー テキストが指定されています。 **表示名**は、ストアにアップロードされたアプリの場合、ストアで予約するアプリケーションの名前です。

```XML
<Properties>
  <DisplayName>MyApp</DisplayName>
  <PublisherDisplayName>MyCompany</PublisherDisplayName>
  <Logo>images\icon.png</Logo>
</Properties>
```

### <a name="resources"></a>リソース

次に [Resources](https://docs.microsoft.com/uwp/schemas/appxpackage/appxmanifestschema/element-resources) ノードの例を示します。

```XML
<Resources>
  <Resource Language="en-us" />
</Resources>
```
### <a name="dependencies"></a>依存関係

常に設定用のパッケージを作成するデスクトップ アプリの場合、``Name``属性を``Windows.Desktop``します。

```XML
<Dependencies>
<TargetDeviceFamily Name="Windows.Desktop" MinVersion="10.0.14316.0" MaxVersionTested="10.0.15063.0" />
</Dependencies>
```

### <a name="capabilities"></a>機能
追加する必要があるは、パッケージを作成するデスクトップ アプリの場合、``runFullTrust``機能します。

```XML
<Capabilities>
  <rescap:Capability Name="runFullTrust"/>
</Capabilities>
```
## <a name="fill-in-the-application-level-elements"></a>アプリケーション レベル要素に値を設定する

このテンプレートに、アプリを説明する情報を指定します。

### <a name="application-element"></a>Application 要素

デスクトップ アプリで、パッケージを作成する、 ``EntryPoint`` Application 要素の属性は常に``Windows.FullTrustApplication``します。

```XML
<Applications>
  <Application Id="MyApp"     
        Executable="MyApp.exe" EntryPoint="Windows.FullTrustApplication">
   </Application>
</Applications>
```

### <a name="visual-elements"></a>視覚要素

次に [VisualElements](https://docs.microsoft.com/uwp/schemas/appxpackage/appxmanifestschema/element-visualelements) ノードの例を示します。

```XML
<uap:VisualElements
    BackgroundColor="#464646"
    DisplayName="My App"
    Square150x150Logo="images\icon.png"
    Square44x44Logo="images\small_icon.png"
    Description="A useful description" />
```
<a id="target-based-assets" />

## <a name="optional-add-target-based-unplated-assets"></a>(省略可能) ターゲット ベースのプレートなしのアセットを追加する

ターゲット ベースのアセットは、Windows タスク バー、タスク ビュー、スナップ アシスト、Alt + Tab キーを押したとき、およびスタート画面のタイルの右下に表示されるアイコンおよびタイルで使用されます。 これらについて詳しくは、[こちら](https://docs.microsoft.com/windows/uwp/shell/tiles-and-notifications/app-assets#target-based-assets)をご覧ください。

1. 正しい 44 x 44 画像を取得して、画像保存用のフォルダー (Assets) にコピーします。

2. 各 44 x 44 画像のコピーを同じフォルダーに作成し、ファイル名の末尾に **.targetsize-44_altform-unplated** を追加します。 これにより、同じ画像で異なる名前のアイコンが、2 つずつフォルダーに保存されます。 たとえば、プロセスの完了後には、assets フォルダーに **MYAPP_44x44.png** と **MYAPP_44x44.targetsize-44_altform-unplated.png** のようなファイルが含まれています。

   > [!NOTE]
   > この例では、**MYAPP_44x44.png** という名前のアイコンは、Windows アプリ パッケージの ``Square44x44Logo`` ロゴ属性で参照するアイコンです。

3.  Windows アプリ パッケージで、透明にするすべてのアイコンについて ``BackgroundColor`` を設定します。

4. 次のサブセクションに進み、新しいパッケージ リソース インデックス ファイルを生成します。

<a id="make-pri" />

### <a name="generate-a-package-resource-index-pri-file"></a>パッケージ リソース インデックス (PRI) ファイルを生成する

前のセクションで説明したように、ターゲット ベースのアセットを作成するか、パッケージを作成したら、アプリケーションのビジュアル アセットのいずれかを変更する場合は、新しい PRI ファイルを生成する必要があります。

1.  **[開発者コマンド プロンプト for VS 2017]** を開きます。

    ![開発者コマンド プロンプト](images/desktop-to-uwp/developer-command-prompt.png)

2.  パッケージのルート フォルダーにディレクトリを変更した後、``makepri createconfig /cf priconfig.xml /dq en-US`` コマンドを実行して priconfig.xml ファイルを作成します。

5.  コマンド ``makepri new /pr <PHYSICAL_PATH_TO_FOLDER> /cf <PHYSICAL_PATH_TO_FOLDER>\priconfig.xml`` を使用して、resources.pri ファイルを作成します。

    たとえば、アプリケーションのコマンドが、これのようになります。:``makepri new /pr c:\MYAPP /cf c:\MYAPP\priconfig.xml``します。

6.  次の手順の説明に従って Windows アプリ パッケージをパッケージ化します。

<a id="make-appx" />

## <a name="generate-a-windows-app-package"></a>Windows アプリ パッケージを生成する

**MakeAppx.exe** を使用して、プロジェクトの Windows アプリ パッケージを生成します。 このツールは Windows 10 SDK に含まれています。Visual Studio をインストールしている場合は、お使いの Visual Studio バージョンの開発者コマンド プロンプトから簡単にアクセスできます。

「[MakeAppx.exe ツールを使ったアプリ パッケージの作成](https://docs.microsoft.com/windows/uwp/packaging/create-app-package-with-makeappx-tool)」をご覧ください。

## <a name="run-the-packaged-app"></a>パッケージ アプリを実行する

証明書を取得し、それに署名することがなくローカルでテストするアプリケーションを実行することができます。 次の PowerShell コマンドレットを実行するだけで済みます。

```Add-AppxPackage –Register AppxManifest.xml```

アプリの .exe または .dll ファイルを更新するには、パッケージ内の既存のファイルを新しいファイルに置き換え、AppxManifest.xml のバージョン番号を繰り上げて、上記のコマンドをもう一度実行します。

> [!NOTE]
> パッケージ化されたアプリケーションでは、常には、対話ユーザーとして実行されにパッケージ化されたアプリケーションをインストールするすべてのドライブを NTFS 形式にフォーマットする必要があります。

## <a name="next-steps"></a>次のステップ

**質問に対する回答を見つける**

ご質問がある場合は、 Stack Overflow でお問い合わせください。 Microsoft のチームでは、これらのチームがこれらの[タグ](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge)をチェックしています。[こちら](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D)から質問することもできます。

**フィードバックの提供または機能の提案を行う**

[UserVoice](https://wpdev.uservoice.com/forums/110705-universal-windows-platform/category/161895-desktop-bridge-centennial) のページをご覧ください。

**コードをステップ実行する/問題を見つけて修正する**

[実行、デバッグ、およびデスクトップ アプリケーションをパッケージ化されたテスト](desktop-to-uwp-debug.md)を参照してください。

**アプリケーションに署名して配布する.**

[デスクトップ アプリケーションのパッケージの配布](desktop-to-uwp-distribute.md)を参照してください。
