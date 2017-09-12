---
author: normesta
Description: "この記事では、デスクトップ ブリッジに関する既知の問題について説明します。"
Search.Product: eADQiWindows 10XVcnh
title: "既知の問題 (デスクトップ ブリッジ)"
ms.author: normesta
ms.date: 07/18/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.assetid: 71f8ffcb-8a99-4214-ae83-2d4b718a750e
ms.openlocfilehash: bf0e81d4a6ff7bd091f25963b1cf26cdecc93636
ms.sourcegitcommit: de6bc8acec2cd5ebc36bb21b2ce1a9980c3e78b2
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/17/2017
---
# <a name="known-issues-desktop-bridge"></a>既知の問題 (デスクトップ ブリッジ)

この記事では、デスクトップ ブリッジに関する既知の問題について説明します。

## <a name="blue-screen-with-error-code-0x139-kernelsecuritycheckfailure"></a>エラー コード 0x139 のブルー スクリーン (KERNEL_SECURITY_CHECK_FAILURE)

Windows ストアのアプリをインストールまたは起動した後、予期せず **0x139 (KERNEL\_SECURITY\_CHECK\_ FAILURE)** というエラーでコンピューターの再起動が発生することがあります。

影響を受けることがわかっているアプリには、Kodi、JT2Go、Ear Trumpet、Teslagrad などがあります。

この問題に対処するための重要な修正プログラムが含まれた [Windows 更新プログラム (Version 14393.351 - KB3197954)](https://support.microsoft.com/kb/3197954) が 2016 年 10 月 27 日にリリースされました。 この問題が発生した場合は、コンピューターを更新してください。 ログインする前にコンピューターが再起動されるため PC を更新できない場合は、システムの復元を使用して、影響を受けたアプリをインストールする前の状態にシステムを回復する必要があります。 システムを復元する方法について詳しくは、「[Windows 10 の回復オプション](https://support.microsoft.com/help/12415/windows-10-recovery-options)」をご覧ください。

更新しても問題が解決しない場合や、PC を回復する方法がわからない場合は、[Microsoft サポート](https://support.microsoft.com/contactus/)にお問い合わせください。

開発者様には、この更新プログラムが含まれていないバージョンの Windows に Desktop Bridge アプリをインストールしないことをお勧めします。 その場合、更新プログラムをインストールしていないユーザーはアプリを利用できません。 この更新プログラムをインストールしたユーザーだけがアプリを使用できるようにするには、AppxManifest.xml ファイルを次のように変更します。

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

エクスプローラーで証明書をダブルクリックし、*[詳細]* タブを選び、一覧の *[サブジェクト]*フィールドを選びます。 内容をコピーすることができます。

**オプション3: CertUtil**

コマンドラインから PFX ファイルに **certutil** を実行し、出力から *[サブジェクト]* フィールドをコピーします。

```cmd
certutil -dump <cert_file.pfx>
```

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

<span id="known-issues-anchor" />
## <a name="known-issues-with-cvbnet-and-c-uwp-projects"></a>C#/VB.NET と C++ UWP プロジェクトの既知の問題

C# プロジェクトを使用してアプリをパッケージ化する場合は、以下の既知の問題について理解しておく必要があります。

- Debug モードでアプリをビルドすると、次のようなエラーが出力されます。_Microsoft.Net.CoreRuntime.targets(235,5): エラー: カスタム エントリ ポイントを持つアプリケーションの実行可能ファイルはサポートされていません。パッケージ マニフェストでの Application 要素の Executable 属性を確認してください。_

  この問題を解決するには、代わりに Release モードを使用します。

- UWP プロジェクトのルート フォルダーに格納されている Win32 バイナリは、Release では削除されます。 .NET Native コンパイラは最終的なパッケージからそれらのバイナリを削除します。これにより、実行可能ファイルのエントリ ポイントが見つからないため、マニフェストの検証エラーが出力されます。

  この問題を解決するには、Win32 バイナリを保存するプロジェクトのサブフォルダーを作成します。


## <a name="you-receive-the-error----msb4018-the-generateresource-task-failed-unexpectedly"></a>次のエラーが表示されます。MSB4018: "GenerateResource" タスクが予期せずに失敗しました

これは、サテライト アセンブリをパッケージ リソース インデックス (PRI) ファイルに変換しようとすると発生することがあります。

Microsoft ではこの問題を把握しており、より長期的な解決策に取り組んでいるところです。 一時的な回避策として、次の XML 行をホスティング プロジェクト ファイルの最初の PropertyGroup 要素に追加することで、リソース ジェネレータを無効にできます。

``<AppxGeneratePrisForPortableLibrariesEnabled>false</AppxGeneratePrisForPortableLibrariesEnabled>``
