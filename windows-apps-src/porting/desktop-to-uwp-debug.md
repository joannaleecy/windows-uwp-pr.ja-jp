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
ms.openlocfilehash: b5110eebde087593f07704e89c2e4708b2fcbb8b
ms.sourcegitcommit: 49aab071aa2bd88f1c165438ee7e5c854b3e4f61
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/09/2018
ms.locfileid: "4463513"
---
# <a name="run-debug-and-test-a-packaged-desktop-application"></a>実行、デバッグ、およびデスクトップ アプリケーションをパッケージ化されたテスト

パッケージ化されたアプリケーションを実行し、それに署名することがなくの外観を確認します。 その後、ブレークポイントを設定し、コード全体をステップ実行します。 実稼働環境でアプリケーションをテストする準備ができたら、アプリケーションに署名し、それをインストールします。 このトピックでは、これらの作業を行う方法について説明します。

<a id="run-app" />

## <a name="run-your-application"></a>アプリケーションを実行します。

証明書を取得し、それに署名することがなくローカルでテストするアプリケーションを実行することができます。 ツールによって異なりますアプリケーションを実行する方法、パッケージを作成するために使用します。

### <a name="you-created-the-package-by-using-visual-studio"></a>Visual Studio を使ってパッケージを作成した

パッケージ プロジェクトをスタートアップ プロジェクトとして設定し、Ctrl キーを押しながら F5 キーを押してアプリを起動します。

### <a name="you-created-the-package-manually-or-by-using-the-desktop-app-converter"></a>手動で、または Desktop App Converter を使ってパッケージを作成した

Windows PowerShell コマンド プロンプトを開き、出力フォルダーの **PackageFiles** サブフォルダーからこのコマンドレットを実行します。

```
Add-AppxPackage –Register AppxManifest.xml
```
アプリを起動するには、そのアプリを Windows スタート メニューで見つけます。

![[スタート] メニューでパッケージ化されたアプリケーション](images/desktop-to-uwp/converted-app-installed.png)

> [!NOTE]
> パッケージ化されたアプリケーションでは、常には、対話ユーザーとして実行されにパッケージ化されたアプリケーションをインストールするすべてのドライブを NTFS 形式にフォーマットする必要があります。

## <a name="debug-your-app"></a>アプリのデバッグ

ツールによって異なりますアプリケーションをデバッグする方法について、パッケージを作成するために使用します。

Visual Studio 2017 リリース 15.4 で使用可能な[新しいパッケージ プロジェクト](desktop-to-uwp-packaging-dot-net.md#new-packaging-project)を使ってパッケージを作成した場合、パッケージ プロジェクトをスタートアップ プロジェクトに設定するだけで、F5 キーを押すことでアプリをデバッグできます。

その他のツールを使用してパッケージを作成した場合は、以下の手順を実行します。

1. ローカル コンピューターにインストールされているようにパッケージ化されたアプリケーションで少なくとも 1 回を開始することを確認します。

   上の「[アプリを実行する](#run-app)」セクションをご覧ください。

2. Visual Studio を起動します。

   管理者特権のアクセス許可を使用してアプリケーションをデバッグする場合、**管理者として実行**] オプションを使用して、Visual Studio を起動します。

3. Visual Studio で、**[デバッグ]**->**[その他のデバッグ ターゲット]**->**[インストールされているアプリケーション パッケージのデバッグ]** の順に選択します。

4. **[インストールされているアプリケーション パッケージのデバッグ]** リストで、目的のアプリ パッケージを選び、**[アタッチ]** ボタンを選択します。

#### <a name="modify-your-application-in-between-debug-sessions"></a>デバッグ セッションの間に、アプリケーションを変更します。

バグの修正をアプリケーションに変更を加えた場合は、MakeAppx ツールを使用して再パッケージ化します。 「[MakeAppx ツールを実行する](desktop-to-uwp-manual-conversion.md#make-appx)」をご覧ください。

### <a name="debug-the-entire-application-lifecycle"></a>全体のアプリケーションのライフ サイクルをデバッグします。

場合によっては、開始する前に、アプリをデバッグする機能など、デバッグ プロセスを細かくきめ細かい制御を必要があります。

[PLMDebug](https://msdn.microsoft.com/library/windows/hardware/jj680085(v=vs.85).aspx)を使用するには、中断、再開、および終了など、アプリケーションのライフ サイクルの完全な制御を取得します。

[PLMDebug](https://msdn.microsoft.com/library/windows/hardware/jj680085(v=vs.85).aspx) は Windows SDK に含まれています。

## <a name="test-your-app"></a>アプリのテスト

配布用に準備する現実的な設定で、アプリケーションをテストするには、アプリケーションに署名し、それをインストールすることをお勧めします。

### <a name="test-an-application-that-you-packaged-by-using-visual-studio"></a>Visual Studio を使ってパッケージ化されたアプリケーションをテストします。

Visual Studio では、テスト証明書を使用して、アプリケーションが署名します。 その証明書は、**アプリ パッケージの作成**ウィザードにより生成される出力フォルダーに置かれます。 証明書ファイルには、 *.cer*拡張機能と、アプリケーションでテストする PC 上の**信頼されたルート証明機関**ストアにその証明書をインストールする必要があります。 「[アプリ パッケージをサイドローディングする](../packaging/packaging-uwp-apps.md#sideload-your-app-package)」をご覧ください。

### <a name="test-an-application-that-you-packaged-by-using-the-desktop-app-converter-dac"></a>Desktop App Converter (DAC) を使用してパッケージ化されたアプリケーションをテストします。

Desktop App Converter を使用して、アプリケーションをパッケージ化する場合は使ってできます、``sign``パラメーターを自動的に生成された証明書を使用して、アプリケーションに署名します。 その証明書をインストールしてから、アプリをインストールする必要があります。 「[パッケージ アプリを実行する](desktop-to-uwp-run-desktop-app-converter.md#run-app)」をご覧ください。   


### <a name="manually-sign-apps-optional"></a>アプリに手動で署名する (省略可能)

また、アプリケーションを手動で署名できます。 その方法は、次のとおりです。

1. 証明書を作成します。 「[証明書を作成する](../packaging/create-certificate-package-signing.md)」をご覧ください。

2. その証明書をシステム上の証明書ストア ("**信頼されたルート**" または "**信頼されたユーザー**") にインストールします。

3. その証明書を使用して、アプリケーションの署名、[サインイン、アプリ パッケージが SignTool を使って](../packaging/sign-app-package-using-signtool.md)を参照してください。

  > [!IMPORTANT]
  > 証明書の発行元名がアプリの発行者名と一致することを確認してください。

    **関連するサンプル**

    [SigningCerts](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/SigningCerts)


### <a name="test-your-application-for-windows-10-s"></a>アプリケーションを Windows 10 S をテストします。

アプリを公開する前に Windows 10 秒を実行するデバイスで正しく動作すること確認します。実際には、Microsoft Store にアプリを公開する場合は、する必要がありますこれを行うため、これはストア要件です。 Windows 10 S を実行するデバイスで正しく動作しないアプリは認定されません。

[テストの Windows 10 S、Windows アプリケーション](https://docs.microsoft.com/windows/uwp/porting/desktop-to-uwp-test-windows-s)を参照してください。

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
