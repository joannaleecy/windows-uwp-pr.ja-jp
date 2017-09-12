---
author: normesta
Description: "署名せずにパッケージ アプリを実行し、その外観を確認してみましょう。 その後、ブレークポイントを設定し、コード全体をステップ実行します。 運用環境でアプリをテストする準備ができたら、アプリに署名してインストールします。"
Search.Product: eADQiWindows 10XVcnh
title: "パッケージ デスクトップ アプリの実行、デバッグ、テスト (デスクトップ ブリッジ)"
ms.author: normesta
ms.date: 06/20/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.assetid: f45d8b14-02d1-42e1-98df-6c03ce397fd3
ms.openlocfilehash: c160fecc530a6366de48f4f2ecc24df2463c0469
ms.sourcegitcommit: 77bbd060f9253f2b03f0b9d74954c187bceb4a30
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/11/2017
---
# <a name="run-debug-and-test-a-packaged-desktop-app-desktop-bridge"></a>パッケージ デスクトップ アプリの実行、デバッグ、テスト (デスクトップ ブリッジ)

署名せずにパッケージ アプリを実行し、その外観を確認してみましょう。 その後、ブレークポイントを設定し、コード全体をステップ実行します。 運用環境でアプリをテストする準備ができたら、アプリに署名してインストールします。 このトピックでは、これらの作業を行う方法について説明します。

<span id="run-app" />
## <a name="run-your-app"></a>アプリを実行する

証明書を取得して署名する作業を行わなくても、アプリをローカルで実行およびテストできます。

Visual Studio の UWP プロジェクトを使用してパッケージを作成した場合、パッケージ プロジェクトをスタートアップ プロジェクトに設定するだけで、Ctrl キーを押しながら F5 キーを押すことでアプリが起動するようになります。

Desktop App Converter を使用した場合やアプリを手動でパッケージ化した場合は、Windows PowerShell コマンド プロンプトを開き、出力フォルダーの **PacakgeFiles** サブフォルダーから次のコマンドレットを実行します。

```
Add-AppxPackage –Register AppxManifest.xml
```
アプリを起動するには、そのアプリを Windows スタート メニューで見つけます。

![スタート メニューに表示されたパッケージ アプリ](images/desktop-to-uwp/converted-app-installed.png)

> [!NOTE]
> パッケージ アプリは、常に対話ユーザーとして実行されます。パッケージ アプリをインストールするドライブは、NTFS 形式にフォーマットされている必要があります。

## <a name="debug-your-app"></a>アプリのデバッグ

アプリをデバッグするたびにダイアログ ボックスでパッケージを選択するか、拡張機能をインストールして、セッションを開始するたびにパッケージを選ぶことなくアプリをデバッグできます。

### <a name="debug-your-app-by-selecting-the-package"></a>パッケージを選択してアプリをデバッグする

このオプションでは、セットアップの時間は最短ですが、デバッグ セッションを開始するたびに余分な手順が必要になります。


1. パッケージ アプリがローカル コンピューターにインストールされるように、必ず、パッケージ アプリを 1 回以上起動します。

   上の「[アプリを実行する](#run-app)」セクションをご覧ください。

2. Visual Studio を起動します。

   管理者特権でアプリをデバッグする場合は、**[管理者として実行]** オプションを使用して Visual Studio を起動します。

3. Visual Studio で、**[デバッグ]**->**[その他のデバッグ ターゲット]**->**[インストールされているアプリケーション パッケージのデバッグ]** の順に選択します。

4. **[インストールされているアプリケーション パッケージのデバッグ]** リストで、目的のアプリ パッケージを選び、**[アタッチ]** ボタンを選択します。


### <a name="debug-your-app-without-having-to-select-the-package"></a>パッケージを選択せずにアプリをデバッグする

このオプションでは、セットアップの時間が最長になりますが、アプリを起動するたびにインストールされているパッケージを選択する必要がありません。 このアプローチを使用するには、[Visual Studio 2017](https://www.visualstudio.com/vs/whatsnew/) をインストールする必要があります。

1. まず、[Desktop Bridge Debugging Project](http://go.microsoft.com/fwlink/?LinkId=797871)をインストールします。

2. Visual Studio を起動し、デスクトップ アプリケーション プロジェクトを開きます。

6. **Desktop Bridge Debugging Project** をソリューションに追加します。

   プロジェクトのテンプレートは、インストール済みテンプレートの **[その他のプロジェクトの種類]** グループにあります。

    ![alt](images/desktop-to-uwp/debug-2.png)

    **Desktop Bridge Debugging Project** がソリューションに表示されます。

    ![alt](images/desktop-to-uwp/debug-3.png)

7. **Desktop Bridge Debugging Project** のプロパティ ページを開きます。

8. **[パッケージ レイアウト]** フィールドをパッケージ マニフェスト ファイル (AppxManifest.xml) の場所に設定し、**[スタート画面のタイル]** ドロップダウン リストからアプリの実行可能ファイルを選択します。

     ![alt](images/desktop-to-uwp/debug-4.png)

8. コード エディターで、AppXPackageFileList.xml ファイルを開きます。

9. 以下の要素について、XML ブロックのコメントを解除し、値を追加します。

   **MyProjectOutputPath**: デスクトップ アプリケーションのデバッグ フォルダーの相対パス。

   **LayoutFile**: デスクトップ アプリケーションのデバッグ フォルダーにある実行可能ファイル。

   **PackagePath**: 変換プロセス中に Windows アプリ パッケージ フォルダーにコピーされた、デスクトップ アプリケーションの実行可能ファイルの完全修飾ファイル名。

    次に例を示します。

    ```XML
  <?xml version="1.0" encoding="utf-8"?>
  <Project ToolsVersion="14.0" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
    <PropertyGroup>
     <MyProjectOutputPath>..\MyDesktopApp\bin\Debug</MyProjectOutputPath>
    </PropertyGroup>
    <ItemGroup>
      <LayoutFile Include="$(MyProjectOutputPath)\MyDesktopApp.exe">
        <PackagePath>$(PackageLayout)\MyDesktopApp.exe</PackagePath>
      </LayoutFile>
    </ItemGroup>
  </Project>
    ```

  ソリューション内の他のプロジェクトから生成された dll ファイルをアプリで使用する場合に、これらの DLL に含まれるコードにステップ インするには、各 dll ファイル用の **LayoutFile** 要素を含めます。

  ```XML
  ...
      <LayoutFile Include="$(MyProjectOutputPath)\MyDesktopApp.Models.dll">
      <PackagePath>$(PackageLayout)\MyDesktopApp.Models.dll</PackagePath>
      </LayoutFile>
  ...
  ```

10. パッケージ プロジェクトをスタートアップ プロジェクトに設定します。  

    ![alt](images/desktop-to-uwp/debug-5.png)

11. デスクトップ アプリケーション コードにブレークポイントを設定し、デバッガーを起動します。

  ![デバッグ ボタン](images/desktop-to-uwp/debugger-button.png)

  Visual Studio は、XML ファイルで指定した実行可能ファイルと dll ファイルを Windows アプリ パッケージにコピーして、デバッガーを起動します。

#### <a name="handle-multiple-build-configurations"></a>複数のビルド構成を処理する

複数のビルド構成 (Release と Debug など) を定義した場合は、デバッガーの起動時に Visual Studio で選択されたビルド構成に一致するファイルのみがコピーされるように、AppXPackageFileList.xml ファイルを修正することができます。

次に例を示します。

```XML
<PropertyGroup>
    <MyProjectOutputPath Condition="$(Configuration) == 'Debug'">..\MyDesktopApp\bin\Debug</MyProjectOutputPath>
    <MyProjectOutputPath Condition="$(Configuration) == 'Release'"> ..\MyDesktopApp\bin\Release</MyProjectOutputPath>
</PropertyGroup>
```

#### <a name="debug-uwp-enhancements-to-your-app"></a>アプリに対する UWP 機能強化についてデバッグする

ライブ タイルなどの最新のエクスペリエンスでアプリの機能を強化することもできます。 その場合は、条件付きコンパイルを使用して、指定されたビルド構成でコード パスを有効にします。

1. まず、Visual Studio でビルド構成を定義し、「DesktopUWP」などの名前を付けます。

2. プロジェクトのプロジェクト プロパティの **[ビルド]** タブで、その名前を **[条件付きコンパイル シンボル]** フィールドに追加します。

     ![alt](images/desktop-to-uwp/debug-8.png)

3. 条件付きコード ブロックを追加します。 このコードは、**DesktopUWP** ビルド構成に対してのみコンパイルできます。

    ```csharp
    [Conditional("DesktopUWP")]
    private void showtile()
    {
        XmlDocument tileXml = TileUpdateManager.GetTemplateContent(TileTemplateType.TileSquare150x150Text01);
        XmlNodeList textNodes = tileXml.GetElementsByTagName("text");
        textNodes[0].InnerText = string.Format("Welcome to DesktopUWP!");
        TileNotification tileNotification = new TileNotification(tileXml);
        TileUpdateManager.CreateTileUpdaterForApplication().Update(tileNotification);
    }
    ```

### <a name="debug-the-entire-app-lifecycle"></a>アプリ全体のライフ サイクルについてデバッグする

場合によっては、アプリを開始する前にデバッグを行うなど、デバッグ プロセスを細かく制御する必要があります。

[PLMDebug](https://msdn.microsoft.com/library/windows/hardware/jj680085(v=vs.85).aspx) を使用すると、中断、再開、終了などを含むアプリのライフ サイクルについて、完全に制御できます。

[PLMDebug](https://msdn.microsoft.com/library/windows/hardware/jj680085(v=vs.85).aspx) は Windows SDK に含まれています。


### <a name="modify-your-app-in-between-debug-sessions"></a>デバッグ セッションと次のデバッグ セッションの間にアプリを変更する

バグを修正するための変更をアプリに加えた場合は、MakeAppx ツールを使ってアプリを再パッケージ化します。 「[MakeAppx ツールを実行する](desktop-to-uwp-manual-conversion.md#make-appx)」をご覧ください。

## <a name="test-your-app"></a>アプリのテスト

配布用の準備の一環として現実的な設定でアプリをテストするには、アプリに署名し、インストールすることをお勧めします。

Visual Studio を使ってアプリをパッケージ化した場合は、アプリに署名してインストールするスクリプトを実行できます。 「[アプリ パッケージをサイドローディングする](../packaging/packaging-uwp-apps.md#sideload-your-app-package)」をご覧ください。

Desktop App Converter を使用してアプリをパッケージ化する場合は、``sign`` パラメーターを使用し、生成された証明書を使って、アプリに自動的に署名します。 その証明書をインストールしてから、アプリをインストールする必要があります。 「[パッケージ アプリを実行する](desktop-to-uwp-run-desktop-app-converter.md#run-app)」をご覧ください。   

アプリには、手動で署名することもできます。 その方法は、次のとおりです。

1. 証明書を作成します。 「[証明書を作成する](../packaging/create-certificate-package-signing.md)」をご覧ください。

2. その証明書をシステム上の証明書ストア ("**信頼されたルート**" または "**信頼されたユーザー**") にインストールします。

3. その証明書を使ってアプリに署名します。「[SignTool を使ってアプリ パッケージに署名する](../packaging/sign-app-package-using-signtool.md)」をご覧ください。

  > [!IMPORTANT]
  > 証明書の発行元名がアプリの発行者名と一致することを確認してください。

### <a name="related-sample"></a>関連するサンプル

[SigningCerts](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/SigningCerts)


### <a name="test-your-app-for-windows-10-s"></a>アプリの Windows 10 S 対応をテストする

アプリを公開する前に、Windows 10 S を実行するデバイスでそのアプリが正しく動作することを確認してください。実際、Windows ストアにアプリを公開する予定がある場合はこの作業を行わなければなりません。それがストア要件になっているためです。 Windows 10 S を実行するデバイスで正しく動作しないアプリは認定されません。 

「[Windows アプリの Windows 10 S 対応をテストする](https://docs.microsoft.com/windows/uwp/porting/desktop-to-uwp-test-windows-s)」をご覧ください。

### <a name="run-another-process-inside-the-full-trust-container"></a>完全な信頼コンテナー内で別のプロセスを実行する

指定されたアプリ パッケージのコンテナー内でカスタムのプロセスを起動することができます。 これは、シナリオをテストするために役立つ場合があります (たとえば、カスタムのテスト ハーネスがあり、アプリの出力をテストする必要がある場合など)。 これを行うには、```Invoke-CommandInDesktopPackage``` PowerShell コマンドレットを使用します。

```CMD
Invoke-CommandInDesktopPackage [-PackageFamilyName] <string> [-AppId] <string> [-Command] <string> [[-Args]
    <string>]  [<CommonParameters>]
```

## <a name="next-steps"></a>次のステップ

**特定の質問に対する回答を見つける**

マイクロソフトのチームでは、[StackOverflow タグ](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge)をチェックしています。

**この記事に関するフィードバックを送信する**

下のコメント セクションをご利用ください。
