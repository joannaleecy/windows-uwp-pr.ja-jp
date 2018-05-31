---
author: normesta
Description: Shows how to manually package a Windows desktop application (like Win32, WPF, and Windows Forms) for Windows 10.
Search.Product: eADQiWindows 10XVcnh
title: アプリを手動でパッケージ化する (デスクトップ ブリッジ)
ms.author: normesta
ms.date: 05/25/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp
ms.assetid: e8c2a803-9803-47c5-b117-73c4af52c5b6
ms.localizationpriority: medium
ms.openlocfilehash: 81d5b9b0b52ef0f7529b277215e7fe0b95683f0a
ms.sourcegitcommit: 6618517dc0a4e4100af06e6d27fac133d317e545
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/28/2018
ms.locfileid: "1689768"
---
# <a name="package-an-app-manually-desktop-bridge"></a>アプリを手動でパッケージ化する (デスクトップ ブリッジ)

このトピックでは、Visual Studio、Desktop App Converter (DAC) などのツールを使用せずにアプリをパッケージ化する方法を示します。

アプリを手動でパッケージ化するには、パッケージ マニフェスト ファイルを作成してから、Windows アプリ パッケージを生成するコマンド ライン ツールを実行します。

xcopy コマンドを使用してアプリをインストールする場合や、アプリのインストーラーがシステムに加える変更を熟知したうえで、プロセスをきめ細かく制御する必要がある場合は、手動によるパッケージ化を検討してください。

インストーラーによってどのような変更がシステムに加えられるのかわからない場合や、自動化ツールを使用してパッケージ マニフェストを生成する場合は、[こちら](desktop-to-uwp-root.md#convert)のオプションのいずれかを検討してください。

>[!IMPORTANT]
>デスクトップ ブリッジは、Windows 10 Version 1607 で導入されており、Windows 10 Anniversary Update (10.0、ビルド 14393) 以降のリリースをターゲットとする Visual Studio プロジェクトでのみ使用できます。

## <a name="first-consider-how-youll-distribute-your-app"></a>まず、アプリの配布方法を検討する
アプリを [Microsoft Store](https://www.microsoft.com/store/apps) に公開する予定であれば、[このフォーム](https://developer.microsoft.com/windows/projects/campaigns/desktop-bridge)への記入から開始します。 Microsoft から、オンボード プロセスを開始するための連絡があります。 このプロセスでは、ストア内の名前を予約し、アプリをパッケージ化するための情報を取得します。

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
> Windows ストアでアプリ名を予約済みの場合は、Windows デベロッパー センターのダッシュ ボードを使用して、名前と発行元を取得できます。 アプリを他のシステムにサイドローディング展開する場合は、独自の名前を指定できます。ただし、選択する発行元名は、アプリへの署名に使用する証明書の名前と一致する必要があります。

### <a name="properties"></a>Properties

[Properties](https://docs.microsoft.com/uwp/schemas/appxpackage/appxmanifestschema/element-properties) 要素には、必須の子要素が 3 つあります。 次に示すのは、**Properties** ノードの例です。要素はプレースホルダー テキストが指定されています。 **DisplayName** は、ストアにアップロードするアプリに対して、ストアで予約するアプリの名前です。

```XML
<Properties>
  <DisplayName>MyApp</DisplayName>
  <PublisherDisplayName>MyCompany</PublisherDisplayName>
  <Logo>images\icon.png</Logo>
</Properties>
```

### <a name="resources"></a>Resources

次に [Resources](https://docs.microsoft.com/uwp/schemas/appxpackage/appxmanifestschema/element-resources) ノードの例を示します。

```XML
<Resources>
  <Resource Language="en-us" />
</Resources>
```
### <a name="dependencies"></a>Dependencies

デスクトップ ブリッジ アプリでは、``Name`` 属性は常に ``Windows.Desktop`` に設定します。

```XML
<Dependencies>
<TargetDeviceFamily Name="Windows.Desktop" MinVersion="10.0.14316.0" MaxVersionTested="10.0.15063.0" />
</Dependencies>
```

### <a name="capabilities"></a>Capabilities
デスクトップ ブリッジ アプリには、``runFullTrust`` 機能を追加する必要があります。

```XML
<Capabilities>
  <rescap:Capability Name="runFullTrust"/>
</Capabilities>
```
## <a name="fill-in-the-application-level-elements"></a>アプリケーション レベル要素に値を設定する

このテンプレートに、アプリを説明する情報を指定します。

### <a name="application-element"></a>Application 要素

デスクトップ ブリッジ アプリの場合、Application 要素の ``EntryPoint`` 属性は常に ``Windows.FullTrustApplication`` です。

```XML
<Applications>
  <Application Id="MyApp"     
        Executable="MyApp.exe" EntryPoint="Windows.FullTrustApplication">
   </Application>
</Applications>
```

### <a name="visual-elements"></a>VisualElements

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

前のセクションで説明したようにターゲット ベースのアセットを作成する場合や、パッケージを作成した後、アプリのビジュアル アセットのいずれかを変更する場合は、新しい PRI ファイルを生成する必要があります。

1.  **[開発者コマンド プロンプト for VS 2017]** を開きます。

    ![開発者コマンド プロンプト](images/desktop-to-uwp/developer-command-prompt.png)

2.  パッケージのルート フォルダーにディレクトリを変更した後、``makepri createconfig /cf priconfig.xml /dq en-US`` コマンドを実行して priconfig.xml ファイルを作成します。

5.  コマンド ``makepri new /pr <PHYSICAL_PATH_TO_FOLDER> /cf <PHYSICAL_PATH_TO_FOLDER>\priconfig.xml`` を使用して、resources.pri ファイルを作成します。

    たとえば、アプリのコマンドは、``makepri new /pr c:\MYAPP /cf c:\MYAPP\priconfig.xml`` のようになります。

6.  次の手順の説明に従って Windows アプリ パッケージをパッケージ化します。

<a id="make-appx" />

## <a name="generate-a-windows-app-package"></a>Windows アプリ パッケージを生成する

**MakeAppx.exe** を使用して、プロジェクトの Windows アプリ パッケージを生成します。 このツールは Windows 10 SDK に含まれています。Visual Studio をインストールしている場合は、お使いの Visual Studio バージョンの開発者コマンド プロンプトから簡単にアクセスできます。

「[MakeAppx.exe ツールを使ったアプリ パッケージの作成](https://docs.microsoft.com/windows/uwp/packaging/create-app-package-with-makeappx-tool)」をご覧ください。

## <a name="run-the-packaged-app"></a>パッケージ アプリを実行する

証明書を取得して署名する作業を行わなくても、アプリをローカルで実行およびテストできます。 次の PowerShell コマンドレットを実行するだけで済みます。

```Add-AppxPackage –Register AppxManifest.xml```

アプリの .exe または .dll ファイルを更新するには、パッケージ内の既存のファイルを新しいファイルに置き換え、AppxManifest.xml のバージョン番号を繰り上げて、上記のコマンドをもう一度実行します。

> [!NOTE]
> パッケージ アプリは、常に対話ユーザーとして実行されます。パッケージ アプリをインストールするドライブは、NTFS 形式にフォーマットされている必要があります。

## <a name="next-steps"></a>次のステップ

**質問に対する回答を見つける**

ご質問がある場合は、 Stack Overflow でお問い合わせください。 Microsoft のチームでは、これらのチームがこれらの[タグ](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge)をチェックしています。[こちら](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D)から質問することもできます。

**フィードバックの提供または機能の提案を行う**

[UserVoice](https://wpdev.uservoice.com/forums/110705-universal-windows-platform/category/161895-desktop-bridge-centennial) のページをご覧ください。

**コードをステップ実行する/問題を見つけて修正する**

[パッケージ デスクトップ アプリの実行、デバッグ、テスト (デスクトップ ブリッジ)](desktop-to-uwp-debug.md) をご覧ください。

**アプリに署名して配布する**

[パッケージ デスクトップ アプリの配布 (デスクトップ ブリッジ)](desktop-to-uwp-distribute.md) をご覧ください。
