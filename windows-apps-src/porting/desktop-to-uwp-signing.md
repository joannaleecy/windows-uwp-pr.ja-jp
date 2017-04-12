---
author: normesta
Description: "この記事では、ユニバーサル Windows プラットフォーム (UWP) に変換したデスクトップ アプリに署名する方法について説明します。"
Search.Product: eADQiWindows 10XVcnh
title: "Desktop to UWP Bridge での署名"
ms.author: normesta
ms.date: 03/09/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.assetid: 232c3012-71ff-4f76-a81e-b1758febb596
ms.openlocfilehash: bed23b75a966e3a858d1e34a686fa3ba2730354c
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
# <a name="desktop-to-uwp-bridge-sign"></a>Desktop to UWP Bridge: 署名

この記事では、ユニバーサル Windows プラットフォーム (UWP) に変換したデスクトップ アプリに署名する方法について説明します。 Windows アプリ パッケージを展開する前に、証明書で署名する必要があります。

## <a name="automatically-sign-using-the-desktop-app-converter-dac"></a>Desktop App Converter (DAC) を使った自動的な署名

DAC を実行しているときに ```-Sign``` フラグを使用して、Windows アプリ パッケージに自動的に署名します。 詳細については、「[Desktop App Converter プレビュー](desktop-to-uwp-run-desktop-app-converter.md)」をご覧ください。

## <a name="manually-sign-using-signtoolexe"></a>SignTool.exe を使った手動での署名

最初に MakeCert.exe を使用して証明書を作成します。 パスワードの入力を求められた場合は、[なし] を選択します。

```cmd
C:\> MakeCert.exe -r -h 0 -n "CN=<publisher_name>" -eku 1.3.6.1.5.5.7.3.3 -pe -sv <my.pvk> <my.cer>
```

次に、pvk2pfx.exe を使用して公開キーと秘密キーの情報を証明書にコピーします。

```cmd
C:\> pvk2pfx.exe -pvk <my.pvk> -spc <my.cer> -pfx <my.pfx>
```
最後に、SignTool.exe を使用して、証明書で Windows アプリ パッケージに署名します。

```cmd
C:\> signtool.exe sign -f <my.pfx> -fd SHA256 -v .\<outputAppX>.appx
```

詳しくは、「[SignTool を使ってアプリ パッケージに署名する方法](https://msdn.microsoft.com/library/windows/desktop/jj835835.aspx)」をご覧ください。

上記の 3 つのツールはすべて Microsoft Windows 10 SDK に含まれています。 これらのツールを直接呼び出すには、コマンド プロンプトから ```C:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\Tools\VsDevCmd.bat``` スクリプトを呼び出します。

## <a name="common-errors"></a>一般的なエラー

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

## <a name="see-also"></a>参照

- [SignTool](https://msdn.microsoft.com/library/windows/desktop/aa387764.aspx)
- [SignTool.exe (署名ツール)](https://msdn.microsoft.com/library/8s9b9yaz.aspx)
- [SignTool を使ってアプリ パッケージに署名する方法](https://msdn.microsoft.com/library/windows/desktop/jj835835.aspx)
