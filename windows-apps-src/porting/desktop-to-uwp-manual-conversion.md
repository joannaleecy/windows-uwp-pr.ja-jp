---
Description: Windows 10 用の Windows デスクトップ アプリケーション (Win32、WPF、Windows フォームなど) を手動でパッケージ化する方法を示します。
Search.Product: eADQiWindows 10XVcnh
title: アプリケーションを手動でパッケージ化 (デスクトップ ブリッジ)
ms.date: 05/18/2018
ms.topic: article
keywords: windows 10, uwp
ms.assetid: e8c2a803-9803-47c5-b117-73c4af52c5b6
ms.localizationpriority: medium
ms.custom: RS5
ms.openlocfilehash: 1dd159b7cd04a7641bf3f89605e054a00a0bad58
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57651177"
---
# <a name="package-a-desktop-application-manually"></a>デスクトップ アプリケーションを手動でパッケージ化します。

このトピックでは、Visual Studio や Desktop App Converter (DAC) などのツールを使用せず、アプリケーションをパッケージ化する方法を示します。

アプリを手動でパッケージ化するには、パッケージ マニフェスト ファイルを作成してから、Windows アプリ パッケージを生成するコマンド ライン ツールを実行します。

プロセスをより詳細な制御と xcopy コマンドを使用して、アプリケーションをインストールすることも、アプリのインストーラーが、システムに変更を使い慣れている場合は、手動のパッケージ化を検討してください。

インストーラーによってどのような変更がシステムに加えられるのかわからない場合や、自動化ツールを使用してパッケージ マニフェストを生成する場合は、[こちら](desktop-to-uwp-root.md#convert)のオプションのいずれかを検討してください。

>[!IMPORTANT]
>(それ以外の場合は、デスクトップ ブリッジと呼ばれます) デスクトップ アプリケーションの Windows アプリ パッケージを作成する機能は Windows 10 バージョン 1607 で導入され、Windows 10 Anniversary Update (10.0; を対象とするプロジェクトでのみ使用できます。ビルド 14393) または Visual Studio の今後のリリース。

## <a name="first-prepare-your-application"></a>まず、アプリケーションを準備します

アプリケーションのパッケージの作成を開始する前に、このガイドを確認します。[デスクトップ アプリケーションをパッケージ化するための準備](desktop-to-uwp-prepare.md)します。

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
> パブリッシャーと名前を取得を使用して Microsoft Store でアプリケーション名に予約した場合[パートナー センター](https://partner.microsoft.com/dashboard)します。 他のシステム上にアプリをサイドロードにする場合、アプリに署名する証明書の名前と一致するを選択したパブリッシャー名を使用する限り、これらの独自の名前を指定できます。

### <a name="properties"></a>プロパティ

[Properties](https://docs.microsoft.com/uwp/schemas/appxpackage/appxmanifestschema/element-properties) 要素には、必須の子要素が 3 つあります。 次に示すのは、**Properties** ノードの例です。要素はプレースホルダー テキストが指定されています。 **DisplayName**アプリ ストアにアップロードされるストア内に予約するアプリケーションの名前を指定します。

```XML
<Properties>
  <DisplayName>MyApp</DisplayName>
  <PublisherDisplayName>MyCompany</PublisherDisplayName>
  <Logo>images\icon.png</Logo>
</Properties>
```

### <a name="resources"></a>参考資料

次に [Resources](https://docs.microsoft.com/uwp/schemas/appxpackage/appxmanifestschema/element-resources) ノードの例を示します。

```XML
<Resources>
  <Resource Language="en-us" />
</Resources>
```
### <a name="dependencies"></a>依存関係

デスクトップのアプリのパッケージを作成するで、常に設定、``Name``属性を``Windows.Desktop``します。

```XML
<Dependencies>
<TargetDeviceFamily Name="Windows.Desktop" MinVersion="10.0.14316.0" MaxVersionTested="10.0.15063.0" />
</Dependencies>
```

### <a name="capabilities"></a>機能
パッケージを作成する、追加する必要がありますのデスクトップ アプリ、``runFullTrust``機能します。

```XML
<Capabilities>
  <rescap:Capability Name="runFullTrust"/>
</Capabilities>
```
## <a name="fill-in-the-application-level-elements"></a>アプリケーション レベル要素に値を設定する

このテンプレートに、アプリを説明する情報を指定します。

### <a name="application-element"></a>Application 要素

パッケージを作成するデスクトップ アプリ、 ``EntryPoint`` Application 要素の属性は常に``Windows.FullTrustApplication``します。

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

ターゲット ベースのアセットは、Windows タスク バー、タスク ビュー、スナップ アシスト、Alt + Tab キーを押したとき、およびスタート画面のタイルの右下に表示されるアイコンおよびタイルで使用されます。 これらについて詳しくは、[こちら](https://docs.microsoft.com/windows/uwp/design/style/app-icons-and-logos#unplated-assets)をご覧ください。

1. 正しい 44 x 44 画像を取得して、画像保存用のフォルダー (Assets) にコピーします。

2. 各 44 x 44 画像のコピーを同じフォルダーに作成し、ファイル名の末尾に **.targetsize-44_altform-unplated** を追加します。 これにより、同じ画像で異なる名前のアイコンが、2 つずつフォルダーに保存されます。 たとえば、プロセスの完了後には、assets フォルダーに **MYAPP_44x44.png** と **MYAPP_44x44.targetsize-44_altform-unplated.png** のようなファイルが含まれています。

   > [!NOTE]
   > この例では、**MYAPP_44x44.png** という名前のアイコンは、Windows アプリ パッケージの ``Square44x44Logo`` ロゴ属性で参照するアイコンです。

3.  Windows アプリ パッケージで、透明にするすべてのアイコンについて ``BackgroundColor`` を設定します。

4. 次のサブセクションに進み、新しいパッケージ リソース インデックス ファイルを生成します。

<a id="make-pri" />

### <a name="generate-a-package-resource-index-pri-file"></a>パッケージ リソース インデックス (PRI) ファイルを生成する

ターゲット ベースの資産を作成するように、上記のセクションで説明されている場合は、パッケージを作成した後、アプリケーションのビジュアル資産のいずれかを変更する、新しい PRI ファイルを生成する必要があります。

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

証明書を取得し、署名することがなくローカルでテストするアプリケーションを実行することができます。 次の PowerShell コマンドレットを実行するだけで済みます。

```Add-AppxPackage –Register AppxManifest.xml```

アプリの .exe または .dll ファイルを更新するには、パッケージ内の既存のファイルを新しいファイルに置き換え、AppxManifest.xml のバージョン番号を繰り上げて、上記のコマンドをもう一度実行します。

> [!NOTE]
> パッケージ化されたアプリケーションでは、常には、対話型のユーザーとして実行されにパッケージ化されたアプリケーションをインストールする任意のドライブを NTFS 形式に書式設定する必要があります。

## <a name="next-steps"></a>次のステップ

**質問の回答を検索**

ご質問がある場合は、 Stack Overflow でお問い合わせください。 Microsoft のチームでは、これらのチームがこれらの[タグ](https://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge)をチェックしています。[こちら](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D)から質問することもできます。

**ご意見や機能を提案します。**

[UserVoice](https://wpdev.uservoice.com/forums/110705-universal-windows-platform/category/161895-desktop-bridge-centennial) のページをご覧ください。

**コードをステップ実行/検索、および問題を修正**

参照してください[実行、デバッグ、およびデスクトップ アプリケーションをパッケージ化されたテスト](desktop-to-uwp-debug.md)

**アプリケーションに署名し、配布**

参照してください[パッケージ化されたデスクトップ アプリケーションの配布](desktop-to-uwp-distribute.md)
