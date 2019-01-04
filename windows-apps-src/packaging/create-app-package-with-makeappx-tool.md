---
title: MakeAppx.exe ツールを使ったアプリ パッケージの作成
description: MakeAppx.exe は、アプリ パッケージとバンドルからのファイルの作成、暗号化、暗号化解除、抽出を行います。
ms.date: 01/02/2019
ms.topic: article
keywords: Windows 10, UWP, パッケージ化
ms.assetid: 7c1c3355-8bf7-4c9f-b13b-2b9874b7c63c
ms.localizationpriority: medium
ms.custom: RS5
ms.openlocfilehash: 3c6958491092498451743085af38b2d0fa6bdf8a
ms.sourcegitcommit: 62bc4936ca8ddf1fea03d43a4ede5d14a5755165
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 01/04/2019
ms.locfileid: "8991608"
---
# <a name="create-an-app-package-with-the-makeappxexe-tool"></a>MakeAppx.exe ツールを使ったアプリ パッケージの作成


**MakeAppx.exe**は、パッケージ バンドル (.msixbundle または .appxbundle) .msix (.appx)、アプリ パッケージとアプリの両方を作成します。 **MakeAppx.exe**はまた、アプリ パッケージまたはバンドルからのファイルの抽出や、アプリ パッケージとバンドルの暗号化または暗号化解除を行うこともできます。 このツールは、Windows 10 SDK に含まれており、コマンド プロンプトまたはスクリプト ファイルから使用できます。

> [!IMPORTANT]
> Visual Studio を使用してアプリを開発する場合は、Visual Studio のウィザードを使ってアプリ パッケージを作成することをお勧めします。 詳しくは、「[Visual Studio での UWP アプリのパッケージ化](packaging-uwp-apps.md)」をご覧ください。

> [!IMPORTANT]
> **MakeAppx.exe**は作成すること、[アプリ パッケージ アップロード ファイル (.appxupload または .msixupload)](packaging-uwp-apps.md#types-of-app-packages)、[パートナー センターへの申請](../publish/upload-app-packages.md)の有効なアプリ パッケージの推奨される型では注意してください。 アプリ パッケージ アップロード ファイルは、手動で作成もできますが、 [Visual Studio のパッケージ化プロセスの一部として作成](packaging-uwp-apps.md#create-an-app-package-upload-file)、通常です。

## <a name="using-makeappxexe"></a>MakeAppx.exe の使用

SDK のインストール パスに基づき、**MakeAppx.exe** は Windows 10 PC の以下の場所にあります。
- x86: C:\Program Files (x86) \Windows Kits\10\bin\\&lt;ビルド番号&gt;\x86\makeappx.exe
- x64: C:\Program Files (x86) \Windows Kits\10\bin\\&lt;ビルド番号&gt;\x64\makeappx.exe

このツールの ARM バージョンはありません。

### <a name="makeappxexe-syntax-and-options"></a>MakeAppx.exe の構文とオプション

一般的な **MakeAppx.exe** の構文:

``` Usage
MakeAppx <command> [options]      
```

次の表では、**MakeAppx.exe** のコマンドについて説明します。

| **コマンド**   | **説明**                       |
|---------------|---------------------------------------|
| pack          | パッケージを作成します。                    |
| unpack        | 指定されたパッケージ内のすべてのファイルを、指定された出力ディレクトリに抽出します。 |
| bundle        | バンドルを作成します。                     |
| unbundle      | 指定された出力パスの下に、バンドルの完全な名前に基づく名前のサブディレクトリを作成し、すべてのパッケージをそのディレクトリにアンパックします。 |
| encrypt       | 入力パッケージ/バンドルから、暗号化されたアプリ パッケージやバンドルを作成し、指定された出力パッケージ/バンドルとして保存します。 |
| decrypt       | 入力アプリ パッケージ/バンドルから、暗号化解除されたアプリ パッケージやバンドルを作成し、指定された出力パッケージ/バンドルとして保存します。 |


このオプションの一覧は、すべてのコマンドに適用されます。

| **オプション**    | **説明**                       |
|---------------|---------------------------------------|
| /d            | 入力ディレクトリ、出力ディレクトリ、またはコンテンツ ディレクトリを指定します。 |
| /l            | ローカライズされたパッケージに対して使用されます。 既定の検証が、ローカライズされたパッケージで無効になります。 このオプションを使用すると、すべての検証を無効にすることなく、その特定の検証のみが無効になります。 |
| /kf           | 指定したキー ファイルのキーを使って、パッケージやバンドルを暗号化または暗号化解除します。 このオプションは、/kt と一緒に使うことはできません。 |
| /kt           | グローバル テスト キーを使ってパッケージやバンドルを暗号化または暗号化解除します。 これは、/kf と一緒に使うことはできません。 |
| /no           | 出力ファイルが存在する場合に、出力ファイルを上書きしません。 このオプションか /o オプションのいずれも指定しない場合は、ファイルを上書きするかどうかを尋ねるメッセージが表示されます。 |
| /nv           | セマンティクス検証をスキップします。 このオプションを指定しない場合、パッケージの完全な検証が実行されます。 |
| /o            | 存在する場合は、出力ファイルを上書きします。 このオプションも /no オプションも指定しない場合は、ファイルを上書きするかどうかを尋ねるメッセージが表示されます。 |
| /p            | アプリ パッケージまたはバンドルを指定します。  |
| /v            | コンソールへの詳細なログ出力を有効にします。 |
| /?            | ヘルプ テキストを表示します。                   |


次の一覧では、使用可能な引数を示します。

| **引数**                          | **説明**                       |
|---------------------------------------|---------------------------------------|
| &lt;出力パッケージの名前&gt;           | 作成されるパッケージの名前。 これは、末尾に .msix または .appx ファイル名です。 |
| &lt;暗号化された出力パッケージの名前&gt; | 作成される暗号化されたパッケージの名前。 これは、末尾に .emsix または .eappx ファイル名です。 |
| &lt;入力パッケージ名&gt;            | パッケージの名前。 これは、末尾に .msix または .appx ファイル名です。 |
| &lt;暗号化された入力パッケージ名&gt;  | 暗号化されたパッケージの名前。 これは、末尾に .emsix または .eappx ファイル名です。 |
| &lt;出力バンドル名&gt;            | 作成されるバンドルの名前。 これは、末尾に .msixbundle または .appxbundle ファイル名です。 |
| &lt;暗号化された出力バンドル名&gt;  | 作成される暗号化されたバンドルの名前。 これは、末尾に .emsixbundle または .eappxbundle ファイル名です。 |
| &lt;入力バンドル名&gt;             | バンドルの名前。 これは、末尾に .msixbundle または .appxbundle ファイル名です。 |
| &lt;暗号化された入力バンドル名&gt;   | 暗号化されたバンドルの名前です。 これは、末尾に .emsixbundle または .eappxbundle ファイル名です。 |
| &lt;コンテンツ ディレクトリ&gt;             | アプリ パッケージまたはバンドルのコンテンツのパス。 |
| &lt;マッピング ファイル&gt;                  | パッケージのソースとターゲットを指定するファイル名。 |
| &lt;出力ディレクトリ&gt;              | 出力パッケージとバンドルのディレクトリへのパス。 |
| &lt;キー ファイル&gt;                      | 暗号化キーまたは暗号化解除キーが含まれているファイルの名前です。 |
| &lt;アルゴリズム ID&gt;                  | ブロック マップの作成時に使用されるアルゴリズム。 有効なアルゴリズムには、SHA256 (既定)、SHA384、SHA512 があります。 |


### <a name="create-an-app-package"></a>アプリ パッケージを作成する

アプリ パッケージは、.msix または .appx パッケージ ファイルにパッケージ化されたアプリのファイルの完全なセットです。 **pack** コマンドを使ってアプリ パッケージを作成するには、パッケージの保存場所としてコンテンツ ディレクトリまたはマッピング ファイルを指定する必要があります。 また作成時にパッケージを暗号化することもできます。 パッケージを暗号化する場合は、/ep を使って、キー ファイル (/kf) とグローバル テスト キー (/kt) のいずれを使うかを指定する必要があります。 暗号化されたパッケージを作成する方法について詳しくは、「[パッケージまたはバンドルを暗号化または暗号化解除する](#encrypt-or-decrypt-a-package-or-bundle)」をご覧ください。

**pack** コマンドに固有のオプション:

| **オプション**    | **説明**                       |
|---------------|---------------------------------------|
| /f            | マッピング ファイルを指定します。           |
| /h            | ブロック マップを作成するときに使うハッシュ アルゴリズムを指定します。 これは、pack コマンドでのみ使うことができます。 有効なアルゴリズムには、SHA256 (既定)、SHA384、SHA512 があります。 |
| /m            | 入力アプリ マニフェストへのパスを指定します。出力アプリ パッケージまたはリソース パッケージのマニフェストは、このパスに基づいて生成されます。  このオプションを使用するときには、/f を一緒に使用すると共にマッピング ファイルに [ResourceMetadata] セクションを追加し、生成されるマニフェストに含まれるリソースの次元を指定する必要があります。|
| /nc           | パッケージ ファイルを圧縮しないことを指定します。 既定では、検出されたファイルの種類に基づいてファイルが圧縮されます。 |
| /r            | リソース パッケージを作成します。 これは /m と共に使う必要があり、/l オプションを使用することを意味します。 |  


以下では、**pack**コマンドの構文オプションの使用例を示します。

``` syntax
MakeAppx pack [options] /d <content directory> /p <output package name>
MakeAppx pack [options] /f <mapping file> /p <output package name>
MakeAppx pack [options] /m <app package manifest> /f <mapping file> /p <output package name>
MakeAppx pack [options] /r /m <app package manifest> /f <mapping file> /p <output package name>
MakeAppx pack [options] /d <content directory> /ep <encrypted output package name> /kf <key file>
MakeAppx pack [options] /d <content directory> /ep <encrypted output package name> /kt

```
以下では、**pack** コマンドのコマンド ラインの例を示します。

``` examples
MakeAppx pack /v /h SHA256 /d "C:\My Files" /p MyPackage.msix
MakeAppx pack /v /o /f MyMapping.txt /p MyPackage.msix
MakeAppx pack /m "MyApp\AppxManifest.xml" /f MyMapping.txt /p AppPackage.msix
MakeAppx pack /r /m "MyApp\AppxManifest.xml" /f MyMapping.txt /p ResourcePackage.msix
MakeAppx pack /v /h SHA256 /d "C:\My Files" /ep MyPackage.emsix /kf MyKeyFile.txt
MakeAppx pack /v /h SHA256 /d "C:\My Files" /ep MyPackage.emsix /kt
```

### <a name="create-an-app-bundle"></a>アプリ バンドルを作成する

アプリ バンドルはアプリ パッケージに似ていますが、バンドルではユーザーがダウンロードするアプリのサイズを小さくすることができます。 たとえば、言語固有のアセットや多様な画像倍率のアセット、特定バージョンの Microsoft DirectX に適用されるリソースが含まれる場合などは、アプリ バンドルを使うと便利です。 アプリ パッケージが作成時に暗号化できるのと同様、アプリ バンドルもバンドル時に暗号化できます。 アプリ バンドルを暗号化するには、/ep オプションを使って、キー ファイル (/kf) とグローバル テスト キー (/kt) のいずれを使うかを指定します。 暗号化されたバンドルを作成する方法について詳しくは、「[パッケージまたはバンドルを暗号化または暗号化解除する](#encrypt-or-decrypt-a-package-or-bundle)」をご覧ください。

**bundle** コマンドに固有のオプション:

| **オプション**    | **説明**                       |
|---------------|---------------------------------------|
| /bv           | バンドルのバージョン番号を指定します。 バージョン番号は、4 つの部分をピリオドで区切って、&lt;メジャー番号&gt;.&lt;マイナー番号&gt;.&lt;ビルド&gt;.&lt;リビジョン&gt; の形式で指定します。 |
| /f            | マッピング ファイルを指定します。           |

バンドルのバージョンが指定されていないか、"0.0.0.0" に設定されている場合は、現在の日付と時刻を使用してバンドルが作成されることに注意してください。

以下では、**bundle**コマンドの構文オプションの使用例を示します。

``` syntax
MakeAppx bundle [options] /d <content directory> /p <output bundle name>
MakeAppx bundle [options] /f <mapping file> /p <output bundle name>
MakeAppx bundle [options] /d <content directory> /ep <encrypted output bundle name> /kf MyKeyFile.txt
MakeAppx bundle [options] /f <mapping file> /ep <encrypted output bundle name> /kt
```
以下のブロックでは、**bundle** コマンドの例を示します。

``` examples
MakeAppx bundle /v /d "C:\My Files" /p MyBundle.msixbundle
MakeAppx bundle /v /o /bv 1.0.1.2096 /f MyMapping.txt /p MyBundle.msixbundle
MakeAppx bundle /v /o /bv 1.0.1.2096 /f MyMapping.txt /ep MyBundle.emsixbundle /kf MyKeyFile.txt
MakeAppx bundle /v /o /bv 1.0.1.2096 /f MyMapping.txt /ep MyBundle.emsixbundle /kt
```

### <a name="extract-files-from-a-package-or-bundle"></a>パッケージまたはバンドルからファイルを抽出する

**MakeAppx.exe** はアプリのパッケージとバンドルだけでなく、既存のパッケージのアンパックやアンバンドルに使うこともできます。 展開されたファイルの保存先としてコンテンツ ディレクトリを指定する必要があります。 暗号化されたパッケージまたはバンドルからファイルを抽出する場合は、/ep オプションを使って、暗号化解除にキー ファイル (/kf) とグローバル テスト キー (/kt) のいずれを使うかを指定することで、ファイルの暗号化解除と抽出を同時に実行できます。 パッケージまたはバンドルを暗号化解除する方法について詳しくは、「[パッケージまたはバンドルを暗号化または暗号化解除する](#encrypt-or-decrypt-a-package-or-bundle)」をご覧ください。

**unpack** コマンドと **unbundle** コマンドに固有のオプション:

| **オプション**    | **説明**                       |
|---------------|---------------------------------------|
| /nd           | パッケージやバンドルをアンパックまたはアンバンドルするときに、暗号化解除を行いません。 |
| /pfn          | 指定した出力パスの下に、パッケージまたはバンドルの完全な名前に基づく名前のサブディレクトリが作成され、アンパックまたはアンバンドルしたすべてのファイルが保存されます。 |

以下では、**unpack** コマンドと **unbundle** コマンドの構文オプションの使用例を示します。

``` syntax
MakeAppx unpack [options] /p <input package name> /d <output directory>
MakeAppx unpack [options] /ep <encrypted input package name> /d <output directory> /kf <key file>
MakeAppx unpack [options] /ep <encrypted input package name> /d <output directory> /kt

MakeAppx unbundle [options] /p <input bundle name> /d <output directory>
MakeAppx unbundle [options] /ep <encrypted input bundle name> /d <output directory> /kf <key file>
MakeAppx unbundle [options] /ep <encrypted input bundle name> /d <output directory> /kt
```

以下のブロックでは、**unpack** コマンドと **unbundle** コマンドの使用例を示します。

``` examples
MakeAppx unpack /v /p MyPackage.msix /d "C:\My Files"
MakeAppx unpack /v /ep MyPackage.emsix /d "C:\My Files" /kf MyKeyFile.txt
MakeAppx unpack /v /ep MyPackage.emsix /d "C:\My Files" /kt

MakeAppx unbundle /v /p MyBundle.msixbundle /d "C:\My Files"
MakeAppx unbundle /v /ep MyBundle.emsixbundle /d "C:\My Files" /kf MyKeyFile.txt
MakeAppx unbundle /v /ep MyBundle.emsixbundle /d "C:\My Files" /kt
```

### <a name="encrypt-or-decrypt-a-package-or-bundle"></a>パッケージまたはバンドルを暗号化または暗号化解除する

**MakeAppx.exe**ツールでは、既存のパッケージやバンドルの暗号化や暗号化解除を行うこともできます。 これには、パッケージ名と出力パッケージ名に加え、暗号化や暗号化解除にキー ファイル (/kf) とグローバル テスト キー (/kt) のいずれを使用するかを指定します。

暗号化と暗号化解除は、Visual Studio パッケージ ウィザードでは実行できません。

 **encrypt** コマンドと **decrypt** コマンド固有のオプション:

| **オプション**    | **説明**                       |
|---------------|---------------------------------------|
| /ep           | 暗号化されたアプリ パッケージまたはバンドルを指定します。 |

以下では、**encrypt** コマンドと **decrypt** コマンドの構文オプションの使用例を示します。

``` syntax
MakeAppx encrypt [options] /p <package name> /ep <output package name> /kf <key file>
MakeAppx encrypt [options] /p <package name> /ep <output package name> /kt

MakeAppx decrypt [options] /ep <package name> /p <output package name> /kf <key file>
MakeAppx decrypt [options] /ep <package name> /p <output package name> /kt
```

以下のブロックでは、**encrypt** コマンドと **decrypt** コマンドの使用例を示します。

``` examples
MakeAppx.exe encrypt /p MyPackage.msix /ep MyEncryptedPackage.emsix /kt
MakeAppx.exe encrypt /p MyPackage.msix /ep MyEncryptedPackage.emsix /kf MyKeyFile.txt

MakeAppx.exe decrypt /p MyPackage.msix /ep MyEncryptedPackage.emsix /kt
MakeAppx.exe decrypt p MyPackage.msix /ep MyEncryptedPackage.emsix /kf MyKeyFile.txt
```

## <a name="key-files"></a>キー ファイル

キー ファイルは、1 行目で文字列 "[Keys]" を指定し、2 行目以降で各パッケージを暗号化するキーを記述する必要があります。 各キーは、それぞれが引用符で囲まれた文字列を 2 つ 1 組として空白またはタブで区切って表します。 最初の文字列は base64 でエンコードされた 32 バイトのキー ID を表し、2 番目の文字列は base64 でエンコードされた 32 バイトの暗号化キーを表します。 キー ファイルには、単純なテキスト ファイルを使う必要があります。

キー ファイルの例

``` Example
[Keys]
"OWVwSzliRGY1VWt1ODk4N1Q4R2Vqc04zMzIzNnlUREU="    "MjNFTlFhZGRGZEY2YnVxMTBocjd6THdOdk9pZkpvelc="
```

## <a name="mapping-files"></a>マッピング ファイル
マッピング ファイルでは、1 行目に文字列 "[Files]" を指定し、2 行目以降で各パッケージに追加するファイルを記述する必要があります。 各ファイルは、それぞれが引用符で囲まれたパスを 2 つ 1 組として空白またはタブで区切って表します。 各ファイルは、ソース (ディスク上) とターゲット (パッケージ内) を表します。 マッピング ファイルには、単純なテキスト ファイルを使う必要があります。

マッピング ファイルの例 (/m オプションを使用しない場合)

``` Example
[Files]
"C:\MyApp\StartPage.html"               "default.html"
"C:\Program Files (x86)\example.txt"    "misc\example.txt"
"\\MyServer\path\icon.png"              "icon.png"
"my app files\readme.txt"               "my app files\readme.txt"
"CustomManifest.xml"                    "AppxManifest.xml"
```

マッピング ファイルを使用する場合は、/m オプションを使用するかどうかを選択できます。 /m オプションを使うと、マッピング ファイル内のリソースのメタデータを生成されたマニフェストに含めるように指定できます。 /m オプションを使う場合、マッピング ファイル内にそれに対応するセクションを設ける必要があります。このセクションは 1 行目に "[ResourceMetadata]" と指定し、それに続く行で "ResourceDimensions" と "ResourceId" を指定します。 アプリ パッケージには複数の "ResourceDimensions" を含めることができますが、"ResourceId" は 1 つだけです。

マッピング ファイルの例 (/m オプションを使用する場合)

``` Example
[ResourceMetadata]
"ResourceDimensions"                    "language-en-us"
"ResourceId"                            "English"

[Files]
"images\en-us\logo.png"                 "en-us\logo.png"
"en-us.pri"                             "resources.pri"
```

## <a name="semantic-validation-performed-by-makeappxexe"></a>MakeAppx.exe が実行するセマンティックの検証

**MakeAppx.exe** では、限定的なセマンティックの検証機能により、一般的な展開エラーを検出し、アプリ パッケージの有効性を確認します。 **MakeAppx.exe** を使うときに検証をスキップする場合は、/nv オプションをご覧ください。

この検証では、次の点を確認します。
- パッケージ マニフェストで参照されているすべてのファイルがアプリ パッケージに含まれていること。
- アプリケーションに、同一の 2 つのキーが存在しないこと。
- アプリケーションが、SMB、FILE、MS-WWA-WEB、MS-WWA のリストに記載された禁止プロトコルを登録していないこと。

これは一般的なエラーのみをチェックするように設計された機能であり、完全なセマンティックの検証ではありません。 **MakeAppx.exe** によって作成されたパッケージのインストール可能性については保証されていません。
