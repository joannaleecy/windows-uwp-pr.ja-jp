---
author: normesta
Description: Run your packaged app and see how it looks without having to sign it. Then, set breakpoints and step through code. When you're ready to test your app in a production environment, sign your app and then install it.
Search.Product: eADQiWindows 10XVcnh
title: パッケージ デスクトップ アプリの実行、デバッグ、テスト (デスクトップ ブリッジ)
ms.author: normesta
ms.date: 08/31/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.assetid: f45d8b14-02d1-42e1-98df-6c03ce397fd3
ms.localizationpriority: medium
ms.openlocfilehash: 0f8d443bc201d0e60387673edb7f9b73e2e47490
ms.sourcegitcommit: 1773bec0f46906d7b4d71451ba03f47017a87fec
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/17/2018
ms.locfileid: "1662682"
---
# <a name="run-debug-and-test-a-packaged-desktop-app-desktop-bridge"></a>パッケージ デスクトップ アプリの実行、デバッグ、テスト (デスクトップ ブリッジ)

署名せずにパッケージ アプリを実行し、その外観を確認してみましょう。 その後、ブレークポイントを設定し、コード全体をステップ実行します。 運用環境でアプリをテストする準備ができたら、アプリに署名してインストールします。 このトピックでは、これらの作業を行う方法について説明します。

<a id="run-app" />

## <a name="run-your-app"></a>アプリを実行する

証明書を取得して署名する作業を行わなくても、アプリをローカルで実行およびテストできます。 アプリを実行する方法は、パッケージの作成に使うツールによって異なります。

### <a name="you-created-the-package-by-using-visual-studio"></a>Visual Studio を使ってパッケージを作成した

パッケージ プロジェクトをスタートアップ プロジェクトとして設定し、Ctrl キーを押しながら F5 キーを押してアプリを起動します。

### <a name="you-created-the-package-manually-or-by-using-the-desktop-app-converter"></a>手動で、または Desktop App Converter を使ってパッケージを作成した

Windows PowerShell コマンド プロンプトを開き、出力フォルダーの **PackageFiles** サブフォルダーからこのコマンドレットを実行します。

```
Add-AppxPackage –Register AppxManifest.xml
```
アプリを起動するには、そのアプリを Windows スタート メニューで見つけます。

![スタート メニューに表示されたパッケージ アプリ](images/desktop-to-uwp/converted-app-installed.png)

> [!NOTE]
> パッケージ アプリは、常に対話ユーザーとして実行されます。パッケージ アプリをインストールするドライブは、NTFS 形式にフォーマットされている必要があります。

## <a name="debug-your-app"></a>アプリのデバッグ

アプリをデバッグする方法は、パッケージの作成に使うツールによって異なります。

Visual Studio 2017 リリース 15.4 で使用可能な[新しいパッケージ プロジェクト](desktop-to-uwp-packaging-dot-net.md#new-packaging-project)を使ってパッケージを作成した場合、パッケージ プロジェクトをスタートアップ プロジェクトに設定するだけで、F5 キーを押すことでアプリをデバッグできます。

その他のツールを使用してパッケージを作成した場合は、以下の手順を実行します。

1. パッケージ アプリがローカル コンピューターにインストールされるように、必ず、パッケージ アプリを 1 回以上起動します。

   上の「[アプリを実行する](#run-app)」セクションをご覧ください。

2. Visual Studio を起動します。

   管理者特権でアプリをデバッグする場合は、**[管理者として実行]** オプションを使用して Visual Studio を起動します。

3. Visual Studio で、**[デバッグ]**->**[その他のデバッグ ターゲット]**->**[インストールされているアプリケーション パッケージのデバッグ]** の順に選択します。

4. **[インストールされているアプリケーション パッケージのデバッグ]** リストで、目的のアプリ パッケージを選び、**[アタッチ]** ボタンを選択します。

#### <a name="modify-your-app-in-between-debug-sessions"></a>デバッグ セッションと次のデバッグ セッションの間にアプリを変更する

バグを修正するための変更をアプリに加えた場合は、MakeAppx ツールを使ってアプリを再パッケージ化します。 「[MakeAppx ツールを実行する](desktop-to-uwp-manual-conversion.md#make-appx)」をご覧ください。

### <a name="debug-the-entire-app-lifecycle"></a>アプリ全体のライフ サイクルについてデバッグする

場合によっては、アプリを開始する前にデバッグを行うなど、デバッグ プロセスを細かく制御する必要があります。

[PLMDebug](https://msdn.microsoft.com/library/windows/hardware/jj680085(v=vs.85).aspx) を使用すると、中断、再開、終了などを含むアプリのライフ サイクルについて、完全に制御できます。

[PLMDebug](https://msdn.microsoft.com/library/windows/hardware/jj680085(v=vs.85).aspx) は Windows SDK に含まれています。

## <a name="test-your-app"></a>アプリのテスト

配布用の準備の一環として現実的な設定でアプリをテストするには、アプリに署名し、インストールすることをお勧めします。

### <a name="test-an-app-that-you-packaged-by-using-visual-studio"></a>Visual Studio を使ってパッケージ化したアプリをテストする

Visual Studio は、テスト証明書を使ってアプリに署名します。 その証明書は、**アプリ パッケージの作成**ウィザードにより生成される出力フォルダーに置かれます。 証明書ファイルに *.cer* 拡張子が付いている場合、アプリをテストする PC の**信頼されたルート証明機関**ストアにその証明書をインストールする必要があります。 「[アプリ パッケージをサイドローディングする](../packaging/packaging-uwp-apps.md#sideload-your-app-package)」をご覧ください。

### <a name="test-an-app-that-you-packaged-by-using-the-desktop-app-converter-dac"></a>Desktop App Converter (DAC)を使ってパッケージ化したアプリをテストする

Desktop App Converter を使用してアプリをパッケージ化する場合は、``sign`` パラメーターを使用し、生成された証明書を使って、アプリに自動的に署名します。 その証明書をインストールしてから、アプリをインストールする必要があります。 「[パッケージ アプリを実行する](desktop-to-uwp-run-desktop-app-converter.md#run-app)」をご覧ください。   


### <a name="manually-sign-apps-optional"></a>アプリに手動で署名する (省略可能)

アプリには、手動で署名することもできます。 その方法は、次のとおりです。

1. 証明書を作成します。 「[証明書を作成する](../packaging/create-certificate-package-signing.md)」をご覧ください。

2. その証明書をシステム上の証明書ストア ("**信頼されたルート**" または "**信頼されたユーザー**") にインストールします。

3. その証明書を使ってアプリに署名します。「[SignTool を使ってアプリ パッケージに署名する](../packaging/sign-app-package-using-signtool.md)」をご覧ください。

  > [!IMPORTANT]
  > 証明書の発行元名がアプリの発行者名と一致することを確認してください。

    **関連するサンプル**

    [SigningCerts](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/SigningCerts)


### <a name="test-your-app-for-windows-10-s"></a>アプリの Windows 10 S 対応をテストする

アプリを公開する前に、Windows 10 S を実行するデバイスでそのアプリが正しく動作することを確認してください。実際、Microsoft Store にアプリを公開する予定がある場合はこの作業を行わなければなりません。それが Microsoft Store 要件になっているためです。 Windows 10 S を実行するデバイスで正しく動作しないアプリは認定されません。

「[Windows アプリの Windows 10 S 対応をテストする](https://docs.microsoft.com/windows/uwp/porting/desktop-to-uwp-test-windows-s)」をご覧ください。

### <a name="run-another-process-inside-the-full-trust-container"></a>完全な信頼コンテナー内で別のプロセスを実行する

指定されたアプリ パッケージのコンテナー内でカスタムのプロセスを起動することができます。 これは、シナリオをテストするために役立つ場合があります (たとえば、カスタムのテスト ハーネスがあり、アプリの出力をテストする必要がある場合など)。 これを行うには、```Invoke-CommandInDesktopPackage``` PowerShell コマンドレットを使用します。

```CMD
Invoke-CommandInDesktopPackage [-PackageFamilyName] <string> [-AppId] <string> [-Command] <string> [[-Args]
    <string>]  [<CommonParameters>]
```

## <a name="next-steps"></a>次のステップ

**質問に対する回答を見つける**

ご質問がある場合は、 Stack Overflow でお問い合わせください。 Microsoft のチームでは、これらの[タグ](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge)をチェックしています。 [こちら](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D)から質問することもできます。

**フィードバックの提供または機能の提案を行う**

[UserVoice](https://wpdev.uservoice.com/forums/110705-universal-windows-platform/category/161895-desktop-bridge-centennial) のページをご覧ください。
