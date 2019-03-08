---
Description: 署名せずにパッケージ アプリを実行し、その外観を確認してみましょう。 その後、ブレークポイントを設定し、コード全体をステップ実行します。 運用環境でアプリをテストする準備ができたら、アプリに署名してインストールします。
Search.Product: eADQiWindows 10XVcnh
title: パッケージ デスクトップ アプリの実行、デバッグ、テスト (デスクトップ ブリッジ)
ms.date: 08/31/2017
ms.topic: article
keywords: windows 10, uwp
ms.assetid: f45d8b14-02d1-42e1-98df-6c03ce397fd3
ms.localizationpriority: medium
ms.openlocfilehash: 8b2350c8164548121baec231335e747166f1c082
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57589757"
---
# <a name="run-debug-and-test-a-packaged-desktop-application"></a>実行、デバッグ、およびデスクトップ アプリケーションをパッケージ化されたテスト

パッケージ化されたアプリケーションを実行し、それに署名することがなくの外観を確認します。 その後、ブレークポイントを設定し、コード全体をステップ実行します。 運用環境でアプリケーションをテストする準備ができたら、アプリケーションに署名してからインストールします。 このトピックでは、これらの作業を行う方法について説明します。

<a id="run-app" />

## <a name="run-your-application"></a>アプリケーションを実行します。

証明書を取得し、署名することがなくローカルでテストするアプリケーションを実行することができます。 どのようなツールに依存アプリケーションを実行する方法、パッケージを作成するために使用します。

### <a name="you-created-the-package-by-using-visual-studio"></a>Visual Studio を使ってパッケージを作成した

パッケージ プロジェクトをスタートアップ プロジェクトとして設定し、Ctrl キーを押しながら F5 キーを押してアプリを起動します。

### <a name="you-created-the-package-manually-or-by-using-the-desktop-app-converter"></a>手動で、または Desktop App Converter を使ってパッケージを作成した

Windows PowerShell コマンド プロンプトを開き、出力フォルダーの **PackageFiles** サブフォルダーからこのコマンドレットを実行します。

```
Add-AppxPackage –Register AppxManifest.xml
```
アプリを起動するには、そのアプリを Windows スタート メニューで見つけます。

![[スタート] メニューで、パッケージ化されたアプリケーション](images/desktop-to-uwp/converted-app-installed.png)

> [!NOTE]
> パッケージ化されたアプリケーションでは、常には、対話型のユーザーとして実行されにパッケージ化されたアプリケーションをインストールする任意のドライブを NTFS 形式に書式設定する必要があります。

## <a name="debug-your-app"></a>アプリのデバッグ

どのようなツールに依存アプリケーションをデバッグする方法について、パッケージを作成するために使用します。

Visual Studio 2017 リリース 15.4 で使用可能な[新しいパッケージ プロジェクト](desktop-to-uwp-packaging-dot-net.md#new-packaging-project)を使ってパッケージを作成した場合、パッケージ プロジェクトをスタートアップ プロジェクトに設定するだけで、F5 キーを押すことでアプリをデバッグできます。

その他のツールを使用してパッケージを作成した場合は、以下の手順を実行します。

1. ローカル コンピューターにインストールができるようにパッケージ化されたアプリケーションに少なくとも 1 つの時間を始めることを確認します。

   上の「[アプリを実行する](#run-app)」セクションをご覧ください。

2. Visual Studio を起動します。

   昇格されたアクセス許可を使用してアプリケーションをデバッグする場合を使用して Visual Studio を起動、**管理者として実行**オプション。

3. Visual Studio で、**[デバッグ]**->**[その他のデバッグ ターゲット]**->**[インストールされているアプリケーション パッケージのデバッグ]** の順に選択します。

4. **[インストールされているアプリケーション パッケージのデバッグ]** リストで、目的のアプリ パッケージを選び、**[アタッチ]** ボタンを選択します。

#### <a name="modify-your-application-in-between-debug-sessions"></a>デバッグ セッションの間、アプリケーションを変更します。

バグを修正するアプリケーションに変更を加えた場合は、MakeAppx ツールを使用して再パッケージ化します。 「[MakeAppx ツールを実行する](desktop-to-uwp-manual-conversion.md#make-appx)」をご覧ください。

### <a name="debug-the-entire-application-lifecycle"></a>全体のアプリケーションのライフ サイクルをデバッグします。

場合によっては、開始する前に、アプリケーションをデバッグする機能など、デバッグ プロセスをより細かく制御する必要があります。

使用することができます[PLMDebug](https://msdn.microsoft.com/library/windows/hardware/jj680085(v=vs.85).aspx)中断、再開、終了などのアプリケーション ライフ サイクルを完全に制御を取得します。

[PLMDebug](https://msdn.microsoft.com/library/windows/hardware/jj680085(v=vs.85).aspx) は Windows SDK に含まれています。

## <a name="test-your-app"></a>アプリのテスト

ディストリビューションを準備するときは、現実的な設定で、アプリケーションをテストするには、アプリケーションに署名し、インストールすることをお勧めします。

### <a name="test-an-application-that-you-packaged-by-using-visual-studio"></a>Visual Studio を使用してパッケージ化されているアプリケーションをテストします。

Visual Studio テスト証明書を使用して、アプリケーションに署名します。 その証明書は、**アプリ パッケージの作成**ウィザードにより生成される出力フォルダーに置かれます。 証明書ファイルが、 *.cer*と拡張機能は、その証明書をインストールする必要があります、**信頼されたルート証明機関**でアプリケーションをテストする PC に保存します。 「[アプリ パッケージをサイドローディングする](../packaging/packaging-uwp-apps.md#sideload-your-app-package)」をご覧ください。

### <a name="test-an-application-that-you-packaged-by-using-the-desktop-app-converter-dac"></a>Desktop App Converter (DAC) を使用してパッケージ化されているアプリケーションをテストします。

使用することができます、Desktop App Converter を使用して、アプリケーションをパッケージ化する場合、``sign``パラメーターを自動的に生成された証明書を使用して、アプリケーションに署名します。 その証明書をインストールしてから、アプリをインストールする必要があります。 「[パッケージ アプリを実行する](desktop-to-uwp-run-desktop-app-converter.md#run-app)」をご覧ください。   


### <a name="manually-sign-apps-optional"></a>アプリに手動で署名する (省略可能)

また、アプリケーションを手動でサインインできます。 その方法は、次のとおりです。

1. 証明書を作成します。 「[証明書を作成する](../packaging/create-certificate-package-signing.md)」をご覧ください。

2. その証明書をシステム上の証明書ストア ("**信頼されたルート**" または "**信頼されたユーザー**") にインストールします。

3. その証明書を使用して、アプリケーションの署名は、「 [SignTool を使用して、アプリ パッケージの署名](../packaging/sign-app-package-using-signtool.md)します。

  > [!IMPORTANT]
  > 証明書の発行元名がアプリの発行者名と一致することを確認してください。

**関連のサンプル**

[SigningCerts](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/SigningCerts)


### <a name="test-your-application-for-windows-10-s"></a>Windows 10 S 用アプリケーションをテストします。

アプリを発行する前に Windows 10 s. を実行するデバイスで正しく動作は、必ず実際には、Microsoft Store にアプリケーションを発行する場合は、これを行うストアの要件があるためです。 Windows 10 S を実行するデバイスで正しく動作しないアプリは認定されません。

参照してください[Windows アプリケーションの Windows 10 S テスト](https://docs.microsoft.com/windows/uwp/porting/desktop-to-uwp-test-windows-s)します。

### <a name="run-another-process-inside-the-full-trust-container"></a>完全な信頼コンテナー内で別のプロセスを実行する

指定されたアプリ パッケージのコンテナー内でカスタムのプロセスを起動することができます。 これは、シナリオをテストするために役立つ場合があります (たとえば、カスタムのテスト ハーネスがあり、アプリの出力をテストする必要がある場合など)。 これを行うには、```Invoke-CommandInDesktopPackage``` PowerShell コマンドレットを使用します。

```CMD
Invoke-CommandInDesktopPackage [-PackageFamilyName] <string> [-AppId] <string> [-Command] <string> [[-Args]
    <string>]  [<CommonParameters>]
```

## <a name="next-steps"></a>次のステップ

**質問の回答を検索**

ご質問がある場合は、 Stack Overflow でお問い合わせください。 Microsoft のチームでは、これらの[タグ](https://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge)をチェックしています。 [こちら](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D)から質問することもできます。

**ご意見や機能を提案します。**

[UserVoice](https://wpdev.uservoice.com/forums/110705-universal-windows-platform/category/161895-desktop-bridge-centennial) のページをご覧ください。
