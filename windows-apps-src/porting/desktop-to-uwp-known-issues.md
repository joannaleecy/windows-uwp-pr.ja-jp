---
author: normesta
Description: This article contains known issues with the Desktop Bridge.
Search.Product: eADQiWindows 10XVcnh
title: 既知の問題 (デスクトップ ブリッジ)
ms.author: normesta
ms.date: 06/20/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.assetid: 71f8ffcb-8a99-4214-ae83-2d4b718a750e
ms.localizationpriority: medium
ms.openlocfilehash: 50a455dc43007a433bfabd995af7968e93fe1900
ms.sourcegitcommit: 933e71a31989f8063b020746fdd16e9da94a44c4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/11/2018
ms.locfileid: "4531279"
---
# <a name="known-issues-with-packaged-desktop-applications"></a>パッケージ デスクトップ アプリケーションに関する既知の問題

この記事でには、デスクトップ アプリケーションの Windows アプリ パッケージを作成するときに発生する可能性がある既知の問題が含まれています。

<a id="app-converter" />

## <a name="known-issues-with-the-desktop-app-converter"></a>Desktop App Converter の既知の問題

### <a name="ecreatingisolatedenvfailed-an-estartingisolatedenvfailed-errors"></a>E_CREATING_ISOLATED_ENV_FAILED エラーと E_STARTING_ISOLATED_ENV_FAILED エラー    

これらのエラーのうちいずれかが発生した場合は、[ダウンロード センター](https://aka.ms/converterimages)から取得した有効な基本イメージを使用しているか確認してください。
有効な基本イメージを使っている場合は、コマンドに ``-Cleanup All`` を含めてみてください。
それでも問題が解決しない場合は、調査用としてログを converter@microsoft.com にお送りください。

### <a name="new-containernetwork-the-object-already-exists-error"></a>"New-ContainerNetwork: オブジェクトは既に存在します" エラー

新しい基本イメージをセットアップするときは、このエラーが発生する可能性があります。 Desktop App Converter が先にインストールされた開発用コンピューターに Windows Insider フライトがある場合に、このエラーが発生することがあります。

この問題を解決するには、管理者特権で開いたコマンド プロンプトで `Netsh int ipv4 reset` コマンドを実行して、コンピューターを再起動します。

### <a name="your-net-application-is-compiled-with-the-anycpu-build-option-and-fails-to-install"></a>.NET アプリケーションが"AnyCPU"ビルド オプションでコンパイルし、インストールに失敗するには

この問題は、メインの実行可能ファイルまたは何らかの依存ファイルが、**Program Files** または **Windows\System32** のフォルダー階層に配置された場合に発生することがあります。

この問題を解決するには、アーキテクチャ固有のデスクトップ インストーラー (32 ビットまたは 64 ビット) を使って Windowsアプリ パッケージを生成してみてください。

### <a name="publishing-public-side-by-side-fusion-assemblies-wont-work"></a>パブリック side-by-side Fusion アセンブリの公開が機能しない

 アプリケーションは、インストール中にパブリック side-by-side Fusion アセンブリを公開して、他のプロセスからアクセスできるようにします。 これらのアセンブリは、プロセスのアクティブ化コンテキストの作成中に、CSRSS.exe という名前のシステム プロセスによって取得されます。 変換プロセスでこれが行われると、アクティブ化コンテキスト作成とこれらのアセンブリのモジュール読み込みは失敗します。 side-by-side Fusion アセンブリは、次の場所に登録されています。
  + レジストリ: `HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\SideBySide\Winners`
  + ファイル システム: %windir%\\SideBySide

これは、既知の制限であり、今のところ回避策はありません。 ただし、ComCtl などの受信トレイ アセンブリは OS に同梱されているため、これらのアセンブリに依存していても安全です。

### <a name="error-found-in-xml-the-executable-attribute-is-invalid---the-value-myappexe-is-invalid-according-to-its-datatype"></a>XML にエラーが見つかり、 'Executable' 属性が無効 - 'MyApp.EXE' の値がデータ型に対して無効

この問題は、アプリケーションに含まれる実行可能ファイルの **.EXE** 拡張子が大文字になっている場合に発生することがあります。 ただし、この拡張機能の大文字小文字の区別しないように、アプリケーションを実行するかどうかに影響を与える、これにより、このエラーを生成するように DAC に。

この問題を解決するには、パッケージ化を行うときに **-AppExecutable** フラグを指定し、メインの実行可能ファイルの拡張子として小文字の ".exe" を使用してみてください (例: MYAPP.exe)。    代わりに大文字小文字から、アプリケーションですべての実行可能ファイルの大文字と小文字を変更できます (例: からです。EXE を .exe) します。

### <a name="corrupted-or-malformed-authenticode-signatures"></a>Authenticode 署名が破損しているか、形式が正しくない

このセクションでは、Windows アプリ パッケージ内の移植可能な実行可能ファイル (PE) で、Authenticode 署名が破損しているかまたは形式が正しくない問題を特定する方法について説明します。 任意のバイナリ形式 (.exe、.dll、.chm など) の PE ファイルに対する無効な Authenticode 署名によって、パッケージが正しく署名されない場合や、Windows アプリ パッケージから展開できない場合があります。

PE ファイルの Authenticode 署名の場所は、Optional Header Data Directories の Certificate Table エントリおよび関連付けられている Attribute Certificate Table で指定されます。 署名を検証する場合、これらの構造体で指定されている情報を使用して、PE ファイルの署名を検出します。 これらの値が壊れている場合、ファイルの署名が無効であるように見える可能性があります。

Authenticode 署名が正しいと見なされるには、Authenticode 署名が次の条件を満たしている必要があります。

- PE ファイル内の **WIN_CERTIFICATE** エントリの先頭は、実行可能ファイルの終わりを超えて拡張できない
- **WIN_CERTIFCATE** エントリは、イメージの最後に置かれている必要がある
- **WIN_CERTIFICATE** エントリのサイズは正の値である必要がある
- **WIN_CERTIFICATE** エントリは、32 ビット実行可能ファイルの場合は **IMAGE_NT_HEADERS32** 構造体より後、64 ビット実行可能ファイルの場合は IMAGE_NT_HEADERS64 構造体より後に開始する必要がある

詳しくは、[移植可能な実行可能ファイルの Authenticode 署名の仕様に関するドキュメント](http://download.microsoft.com/download/9/c/5/9c5b2167-8017-4bae-9fde-d599bac8184a/Authenticode_PE.docx)と [PE ファイル形式の仕様に関するページ](https://msdn.microsoft.com/windows/hardware/gg463119.aspx)をご覧ください。

Windows アプリ パッケージに署名するときに、SignTool.exe で、壊れているバイナリや形式が正しくないバイナリの一覧を出力できます。 これを行うには、環境変数 APPXSIP_LOG を 1 に設定して (例: ```set APPXSIP_LOG=1```) 詳細なログを有効にし、SignTool.exe を再度実行します。

これらの形式が正しくないバイナリを修正するには、上記の要件に準拠していることを確認します。

## <a name="you-receive-the-error----msb4018-the-generateresource-task-failed-unexpectedly"></a>次のエラーが表示されます。MSB4018: "GenerateResource" タスクが予期せずに失敗しました

これは、サテライト アセンブリをパッケージ リソース インデックス (PRI) ファイルに変換しようとすると発生することがあります。

Microsoft ではこの問題を把握しており、より長期的な解決策に取り組んでいるところです。 一時的な回避策として、次の XML 行をホスティング プロジェクト ファイルの最初の PropertyGroup 要素に追加することで、リソース ジェネレータを無効にできます。

``<AppxGeneratePrisForPortableLibrariesEnabled>false</AppxGeneratePrisForPortableLibrariesEnabled>``

## <a name="blue-screen-with-error-code-0x139-kernelsecuritycheckfailure"></a>エラー コード 0x139 のブルー スクリーン (KERNEL_SECURITY_CHECK_FAILURE)

Microsoft Store のアプリをインストールまたは起動した後、予期せず **0x139 (KERNEL\_SECURITY\_CHECK\_ FAILURE)** というエラーでコンピューターの再起動が発生することがあります。

影響を受けることがわかっているアプリには、Kodi、JT2Go、Ear Trumpet、Teslagrad などがあります。

この問題に対処するための重要な修正プログラムが含まれた [Windows 更新プログラム (Version 14393.351 - KB3197954)](https://support.microsoft.com/kb/3197954) が 2016 年 10 月 27 日にリリースされました。 この問題が発生した場合は、コンピューターを更新してください。 ログインする前にコンピューターが再起動されるため PC を更新できない場合は、システムの復元を使用して、影響を受けたアプリをインストールする前の状態にシステムを回復する必要があります。 システムを復元する方法について詳しくは、「[Windows 10 の回復オプション](https://support.microsoft.com/help/12415/windows-10-recovery-options)」をご覧ください。

更新しても問題が解決しない場合や、PC を回復する方法がわからない場合は、[Microsoft サポート](https://support.microsoft.com/contactus/)にお問い合わせください。

開発者様には、この更新プログラムが含まれていないバージョンの Windows にパッケージ化されたアプリケーションをインストールしないことをお勧めします。 この操作を行うアプリケーションを更新プログラムをインストールしていないユーザーに利用できなくなることに注意します。 この更新プログラムをインストールしているユーザーに、アプリケーションの可用性を制限するため、AppxManifest.xml ファイルに次のように変更します。

```<TargetDeviceFamily Name="Windows.Desktop" MinVersion="10.0.14393.351" MaxVersionTested="10.0.14393.351"/>```

Windows 更新プログラムについて詳しくは、以下をご覧ください。
* https://support.microsoft.com/kb/3197954
* https://support.microsoft.com/help/12387/windows-10-update-history

## <a name="common-errors-that-can-appear-when-you-sign-your-app"></a>アプリへのサインインの際に表示される可能性のある一般的なエラー

### <a name="publisher-and-cert-mismatch-causes-signtool-error-error-signersign-failed--21470248850x8007000b"></a>発行元と証明書の不一致により、Signtool で「エラー: SignerSign() が失敗しました」(-2147024885/0x8007000b) というエラーが発生する

Windows アプリ パッケージ マニフェストの発行元エントリは、署名に使用する証明書のサブジェクトと一致する必要があります。  次の方法のいずれかを使用して、証明書のサブジェクトを表示できます。

**オプション1: Powershell**

次の PowerShell コマンドを実行します。 同じ発行元情報を持つ .cer または .pfx のいずれかを証明書ファイルとして使用できます。

```ps
(Get-PfxCertificate <cert_file>).Subject
```

**オプション2: エクスプローラー**

エクスプローラーで証明書をダブルクリックし、*[詳細]* タブを選び、一覧の *[サブジェクト]* フィールドを選びます。 内容をコピーすることができます。

**オプション3: CertUtil**

コマンドラインから PFX ファイルに **certutil** を実行し、出力から *[サブジェクト]* フィールドをコピーします。

```cmd
certutil -dump <cert_file.pfx>
```

<a id="bad-pe-cert" />

### <a name="bad-pe-certificate-0x800700c1"></a>不適切な PE 証明書 (番号: 0x800700C1)

これは、パッケージには、破損した証明書を持つバイナリが含まれている場合に発生します。 これは、発生理由理由の一部を次に示します。

* 証明書のスタート画面は画像の終了時にありません。  

* 証明書のサイズは正の値はありません。

* 証明書のスタート画面のない後、`IMAGE_NT_HEADERS32`または後に 32 ビット実行可能ファイルの構造体、 `IMAGE_NT_HEADERS64` 64 ビット実行可能ファイルの構造。

* 証明書のポインターがない、正しく WIN_CERTIFICATE 構造体に配置されます。

無効な PE 証明書を含むファイルを検索する**コマンド プロンプト**を開き、という名前の環境変数を設定`APPXSIP_LOG`1 の値にします。

```
set APPXSIP_LOG=1
```

次に、**コマンド プロンプト**で、もう一度アプリケーションに署名します。 例:

```
signtool.exe sign /a /v /fd SHA256 /f APPX_TEST_0.pfx C:\Users\Contoso\Desktop\pe\VLC.appx
```

無効な PE 証明書を含むファイルに関する情報は、**コンソール ウィンドウ**に表示されます。 例:

```
...

ERROR: [AppxSipCustomLoggerCallback] File has malformed certificate: uninstall.exe

...   
```
## <a name="next-steps"></a>次のステップ

**質問に対する回答を見つける**

ご質問がある場合は、 Stack Overflow でお問い合わせください。 Microsoft のチームでは、これらの[タグ](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge)をチェックしています。 [こちら](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D)から質問することもできます。

**フィードバックの提供または機能の提案を行う**

[UserVoice](https://wpdev.uservoice.com/forums/110705-universal-windows-platform/category/161895-desktop-bridge-centennial) のページをご覧ください。
