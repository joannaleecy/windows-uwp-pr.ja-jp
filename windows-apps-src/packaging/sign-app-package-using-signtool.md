---
author: laurenhughes
title: SignTool を使ってアプリ パッケージに署名する
description: SignTool を使って手動でアプリ パッケージに証明書による署名を行います。
ms.author: lahugh
ms.date: 09/30/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.assetid: 171f332d-2a54-4c68-8aa0-52975d975fb1
ms.localizationpriority: medium
ms.openlocfilehash: c238855f4f018e8e3142509842221c6b9d97fae3
ms.sourcegitcommit: 310a4555fedd4246188a98b31f6c094abb33ec60
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/19/2018
ms.locfileid: "5127756"
---
# <a name="sign-an-app-package-using-signtool"></a>SignTool を使ってアプリ パッケージに署名する


**SignTool** は、アプリ パッケージへのデジタル署名や証明書のバンドルに使用するコマンド ライン ツールです。 証明書は、(テスト目的で) ユーザーが作成することも、(配布目的で) 企業が作成することもできます。 アプリ パッケージに署名すると、アプリのデータが署名後に変更されていないこと、また、アプリ パッケージに署名したユーザーまたは企業の ID が正しいことをユーザーに保証できます。 **SignTool** では、暗号化されているかどうかを問わずアプリ パッケージとアプリ バンドルに署名できます。

> [!IMPORTANT] 
> Visual Studio を使用してアプリを開発する場合は、Visual Studio のウィザードを使ってアプリ パッケージを作成し、署名することをお勧めします。 詳しくは、「[Visual Studio での UWP アプリのパッケージ化](https://msdn.microsoft.com/windows/uwp/packaging/packaging-uwp-apps)」をご覧ください。

コード署名と証明書について詳しくは、「[Introduction to Code Signing](https://msdn.microsoft.com/library/windows/desktop/aa380259.aspx#introduction_to_code_signing)」(コード署名の概要) を参照してください。

## <a name="prerequisites"></a>前提条件
- **パッケージ アプリ**  
    手動でのアプリ パッケージの作成の詳細については、「[MakeAppx.exe ツールを使ったアプリ パッケージの作成](https://msdn.microsoft.com/windows/uwp/packaging/create-app-package-with-makeappx-tool)」を参照してください。 

- **有効な署名証明書**  
    有効な署名証明書の作成またはインポートの詳細については、「[パッケージ署名用の証明書を作成する](https://msdn.microsoft.com/windows/uwp/packaging/create-certificate-package-signing)」を参照してください。

- **SignTool.exe**  
    SDK のインストール パスに基づき、**SignTool** は Windows 10 PC の以下の場所にあります。
    - x86: C:\Program Files (x86)\Windows Kits\10\bin\x86\SignTool.exe
    - x64: C:\Program Files (x86)\Windows Kits\10\bin\x64\SignTool.exe

## <a name="using-signtool"></a>SignTool の使用

**SignTool** は、ファイルの署名、署名やタイプスタンプの確認、署名の削除などに使用できます。 ここでは、アプリ パッケージの署名に関連がある、**sign** コマンドについて説明します。 **SignTool** の詳細については、[SignTool](https://msdn.microsoft.com/library/windows/desktop/aa387764.aspx) のリファレンス ページを参照してください。 

### <a name="determine-the-hash-algorithm"></a>ハッシュ アルゴリズムの特定
**SignTool** を使用してアプリ パッケージやアプリ バンドルを署名するときは、**SignTool** で使用するハッシュ アルゴリズムとアプリのパッケージ作成に使用したアルゴリズムは同じである必要があります。 たとえば、**MakeAppx.exe** を使用して既定の設定でアプリ パッケージを作成した場合、**SignTool** を使用するときは、**MakeAppx.exe** によって使用される既定のアルゴリズムである SHA256 を使用する必要があります。

アプリのパッケージ作成時に使用したハッシュ アルゴリズムを確認するには、アプリ パッケージのコンテンツを抽出し、AppxBlockMap.xml ファイルを調べます。 アプリ パッケージのアンパック方法や抽出方法については、「[パッケージまたはバンドルからファイルを抽出する](https://msdn.microsoft.com/windows/uwp/packaging/create-app-package-with-makeappx-tool#extract-files-from-a-package-or-bundle)」を参照してください。 hash メソッドは BlockMap 要素に含まれ、形式は次のとおりです。
```
<BlockMap xmlns="http://schemas.microsoft.com/appx/2010/blockmap" 
HashMethod="http://www.w3.org/2001/04/xmlenc#sha256">
```

各 HashMethod の値とそれに対応するハッシュ アルゴリズムを次の表に示します。


| HashMethod 値                              | ハッシュ アルゴリズム |
|-----------------------------------------------|----------------|
| http://www.w3.org/2001/04/xmlenc#sha256       | SHA256         |
| http://www.w3.org/2001/04/xmldsig-more#sha384 | SHA384         |
| http://www.w3.org/2001/04/xmlenc#sha512       | SHA512         |

> [!NOTE]
> **SignTool** の既定のアルゴリズムは (**MakeAppx.exe** で使用できない) SHA1 であるため、**SignTool** を使用するときは、必ずハッシュ アルゴリズムを指定する必要があります。

### <a name="sign-the-app-package"></a>アプリ パッケージの署名

すべての前提条件が整い、アプリのパッケージの作成に使用したハッシュ アルゴリズムを特定できたら、アプリ パッケージに署名することができます。 

**SignTool** のパッケージ署名に通常使用するコマンド ライン構文は、次のとおりです。
```
SignTool sign [options] <filename(s)>
```

アプリの署名に使用する証明書は .pfx ファイルであるか、証明書ストアにインストールされている必要があります。

.pfx ファイルの証明書を使用してアプリ パッケージに署名するには、次の構文を使用します。
```
SignTool sign /fd <Hash Algorithm> /a /f <Path to Certificate>.pfx /p <Your Password> <File path>.appx
```
```
SignTool sign /fd <Hash Algorithm> /a /f <Path to Certificate>.pfx /p <Your Password> <File path>.msix
```
`/a` オプションを使用すると、**SignTool** によって自動的に最適な証明書が選択されます。

.pfx ファイルの証明書ではない場合は、次の構文を使用します。
```
SignTool sign /fd <Hash Algorithm> /n <Name of Certificate> <File Path>.appx
```
```
SignTool sign /fd <Hash Algorithm> /n <Name of Certificate> <File Path>.msix
```

または、次の構文を使用して、&lt;証明署名&gt; ではなく、使用する証明書の SHA1 ハッシュを指定することもできます。
```
SignTool sign /fd <Hash Algorithm> /sha1 <SHA1 hash> <File Path>.appx
```
```
SignTool sign /fd <Hash Algorithm> /sha1 <SHA1 hash> <File Path>.msix
```

証明書の中には、パスワードを使用しないものもあります。 証明書がパスワードを使用していない場合は、サンプル コマンドの "/p &lt;パスワード&gt;" を省略してください。

アプリ パッケージが有効な証明書で署名されると、パッケージをストアにアップロードできます。 ストアへのアプリのアップロードと申請の詳しいガイダンスについては、「[アプリの申請](https://msdn.microsoft.com/windows/uwp/publish/app-submissions)」を参照してください。

## <a name="common-errors-and-troubleshooting"></a>一般的なエラーとトラブルシューティング
**SignTool** の使用時に発生する最も一般的なエラーは内部エラーで、代表的なエラーは次の通りです。

```
SignTool Error: An unexpected internal error has occurred.
Error information: "Error: SignerSign() failed." (-2147024885 / 0x8007000B) 
```

0x80080206 (APPX_E_CORRUPT_CONTENT) など、エラー コードが 0x8008 で始まる場合、署名対象のパッケージは無効です。 このようなエラーが発生した場合は、パッケージをビルドし直し、**SignTool** をもう一度実行してください。

**SignTool** には、証明書のエラーとフィルタリングを表示できるデバッグ オプションがあります。 デバッグ機能を使用するには、`/debug` オプションを `sign` の直後に指定し、その後ろに完全な **SignTool** コマンドを指定します。
```
SignTool sign /debug [options]
``` 

さらに一般的なエラーとしては、0x8007000B があります。 この種類のエラーについては、イベント ログで詳細を確認してください。
 
イベント ログで詳細を参照するには、次の手順を実行します。
- Eventvwr.msc を実行します。
- イベント ログを開きます。[イベント ビューアー (ローカル)]、[アプリケーションとサービス ログ]、[Microsoft]、[Windows]、[AppxPackagingOM]、[Microsoft-Windows-AppxPackaging/稼働中] の順に展開します。
- 最新のエラー イベントを検索します。

内部エラーの 0x8007000B は、通常、次のいずれかの値に対応しています。

| **イベント ID** | **イベント文字列の例** | **推奨事項** |
|--------------|--------------------------|----------------|
| 150          | エラー 0x8007000B: アプリ マニフェストの発行元の名前 (CN=Contoso) は、署名証明書のサブジェクト名 (CN=Contoso, C=US) と同じにする必要があります。 | アプリ マニフェストの発行元の名前は、署名のサブジェクト名と完全に一致する必要があります。               |
| 151          | エラー 0x8007000B: 指定されている署名ハッシュ方式 (SHA512) は、アプリ バンドルのブロック マップで使用されているハッシュ方式 (SHA256) と同じにする必要があります。     | /fd パラメーターに指定されている hashAlgorithm が、正しくありません。 (アプリ パッケージの作成に使用した) アプリ パッケージのブロック マップと一致する hashAlgorithm を使用して **SignTool** を再実行してください。  |
| 152          | エラー 0x8007000B: アプリ パッケージの内容は、そのブロック マップに対して検証する必要があります。                                                           | アプリ パッケージは破損しています。再ビルドして、新しいブロック マップを生成する必要があります。 アプリ パッケージの作成の詳細については、「[MakeAppx.exe ツールを使ったアプリ パッケージの作成](https://msdn.microsoft.com/windows/uwp/packaging/create-app-package-with-makeappx-tool)」を参照してください。 |