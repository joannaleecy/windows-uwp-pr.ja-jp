---
title: ローカル接続ストレージの管理
description: 開発環境でローカル接続ストレージ データを管理する方法について説明します。
ms.assetid: 630cb5fc-5d48-4026-8d6c-3aa617d75b2e
ms.date: 02/27/2018
ms.topic: article
keywords: xbox live, xbox, ゲーム, uwp, windows 10, xbox one, 接続ストレージ
ms.localizationpriority: medium
ms.openlocfilehash: f4a0549a92a7855abb2c55bcef246018aacbb9b0
ms.sourcegitcommit: d7613c791107f74b6a3dc12a372d9de916c0454b
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/06/2018
ms.locfileid: "8748860"
---
# <a name="managing-local-connected-storage"></a>ローカル接続ストレージの管理
接続ストレージは、ゲーム データをクラウドに保存するために使用されますが、接続ストレージ サービスへのローカル ストレージ コンポーネントもあります。 PC を使っているか本体を使っているかに関係なく、接続ストレージ データのローカル キャッシュが存在し、クラウドに同期されたデータが含まれています。 XDK タイトルを作成するのか UWP タイトルを作成するのかに関係なく、ローカルの接続ストレージ データを管理できるツールが用意されています。

ローカルにキャッシュされた接続ストレージ データを管理するのに適したツールを見つけるには、次の表をご覧ください。

|タイトル分類  |デバイス  |ローカル ストレージ ツール  |
|---------|---------|---------|
|XDK     |Xbox One 本体     |*xbstorage*         |
|UWP     |PC         |*gamesaveutil*         |
|UWP     |Xbox One 本体     |Xbox Device Portal (XDP) |)

- *Xbstorage* は、Xbox One 本体でローカルにキャッシュされた接続ストレージを管理するためのコマンド ライン ツールで、XDK コマンド プロンプトから実行します。 *xbstorage* ツールは、パス **/Program Files (x86)/Microsoft Durango XDK/bin/xbstorage.exe** の Xbox One XDK にあります。
- *Gamesaveutil* は、PC のローカルにキャッシュされた UWP の接続ストレージを管理するためのコマンド ライン ツールです。 *gamesaveutil* ツールは、Fall Creators Update 以降 (ビルド 10.0.16299.15 以降) の [Windows 10 SDK](https://developer.microsoft.com/en-US/windows/downloads/windows-10-sdk) に付属しています。 該当するバージョンの Windows 10 SDK をインストールすると、フォルダー **ProgramFiles(x86)/Windows Kits/10/bin/[SDK Version]/x64/gamesaveutil.exe** に *gamesaveutil* が配置されます。
- *Xbox Device Portal (XDP)* は、Xbox One 本体のローカルにキャッシュされた接続ストレージ UWP データを管理できるオンライン ポータルです。 この記事では、XDP の使用については取り上げません。 XDP の使い方については、[Xbox 用のデバイス ポータルに関するページ](https://docs.microsoft.com/en-us/windows/uwp/debug-test-perf/device-portal-xbox)をご覧ください。

## <a name="xbstorage"></a>Xbstorage

*Xbstorage* では、ローカルにキャッシュされた接続ストレージ データをハード ドライブから消去したり、XML ファイルを使用して接続ストレージ領域からのユーザーまたはコンピューターのデータをインポートおよびエクスポートしたりできます。

*xbstorage* ツールを使ってローカル データに対して操作が実行されると、その操作がアプリケーション自体によって実行されたかのようにシステムが動作するため、接続ストレージ領域からローカル ファイルにデータを読み取る処理によってコピー前にクラウドとの同期が発生します。

同様に、開発用 PC 上の XML ファイルから Xbox One 開発キット上の接続ストレージ コンテナーにデータをコピーすると、本体がデータをクラウドにアップロードし始めます。 ただし、これが発生しない状況があります。開発キットがロックを取得できないか、本体上のコンテナーとクラウド内のコンテナーの間でデータの競合がある場合、保持するコンテナーの 1 つのバージョンを選ぶことによって競合を解決しないことをユーザーが決定したかのように本体は動作します。また本体は、次回タイトルが開始されるまで、ユーザーがオフラインでプレイしているかのように動作します。

これらのコマンドの 1 つの例外は **reset****/force** です。これは、すべての SCID およびユーザーのセーブ データのローカル ストレージを消去しますが、クラウドに格納されているデータは変更しません。 これは、タイトルのプレイ時にユーザーが本体にローミングしてクラウドからデータをダウンロードする場合の状態に本体を移行させるのに便利です。

### <a name="xbstorage-commands"></a>Xbstorage のコマンド

Xbstorage には、開発者が XDK コマンド プロンプトで使うことができる以下の 6 つのコマンドがあり、Xbox One 開発キットでローカル データを管理できます。

<a id="xbstorage_reset"></a>

|コマンド  |説明  |
|---------|---------|
|reset    |接続ストレージを工場出荷時の状態にリセットします。         |
|import   |指定された XML ファイルから接続ストレージ領域にデータをインポートします。         |
|export   |接続ストレージ領域から指定された XML ファイルにデータをエクスポートします。         |
|delete   |接続ストレージ領域からデータを削除します。         |
|generate |ダミー データを生成し、指定された XML ファイルに保存します。         |
|simulate |ストレージの領域不足状態をシミュレートします。         |

### <a name="xbstorage-reset"></a>Xbstorage reset

`xbstorage reset [/force]`

ローカル本体から接続ストレージ内のすべてのローカル データを消去し、工場出荷時の設定に戻します。 クラウドに保持されているデータは変更されず、必要に応じて再びダウンロードされます。

|オプション  |説明  |
|---------|---------|
|/force   |接続ストレージをリセットする必要があることを確認します。 **/force** を指定しないで reset コマンドを実行すると、次のメッセージが表示されます。接続ストレージを出荷時の状態にリセットすることは破壊的な操作である可能性があるため、このコマンドは **/force** フラグが存在しない限りリセットを実行しません。 |

<a id="xbstorage_import"></a>

### <a name="xbstorage-import"></a>Xbstorage import

`xbstorage import *file-name* [/scid:*SCID*] [/machine] [/msa:*account*] [/replace] [/verbose]`

*filename* に指定されたデータを接続ストレージ領域にインポートします。
このファイルはデータが含まれる XML ファイルです。 例については、「[xbstorage generate](#xbstorage_generate)」を参照してください。 ファイルの XML 形式の詳細については、後の「[インポートおよびエクスポートのファイル形式](#xbstorage_fileformat)」を参照してください。
接続ストレージ領域を指定するには 2 つの方法があります。

- 入力ファイルに **ContextDescription** セクションがあり適切に入力されている場合は、これを使用して接続ストレージ領域を指定します。
- ストレージ領域はコマンドライン パラメーターによって部分的または完全に指定することもでき、これは入力ファイルに指定されているストレージ領域の対応する要素よりも優先されます。

使用法の例:

```cmd
  xbstorage import mydata.xml
  xbstorage import mydata.xml /replace
  xbstorage import mydata.xml /machine /scid:2AAEB34B-DAB2-4879-B625-D970069C1D22
  xbstorage import mydata.xml /msa:user@domain.com /scid:2AAEB34B-DAB2-4879-B625-D970069C1D22
  xbstorage import mydata.xml /verbose 
```

> [!NOTE]
> 指定された接続ストレージ領域にインポートする前に、システムは、実行中のアプリが接続ストレージ領域を取得するときに実行するのと同じロジックを使用して、クラウドとの同期を試みます。
>
> 同じプライマリー SCID を持つアプリケーションが実行中である場合、この操作は競合状態を引き起こす可能性があり、接続ストレージ領域の内容が不確定な状態になる可能性があります。
>
> **/replace** が指定されていない場合、入力ファイルに指定されている BLOB を書き込む前に、入力ファイルに指定されたコンテナーが消去されます。 入力ファイルに指定されていない接続ストレージ領域内のコンテナーはそのまま維持されます。

|オプション  |説明  |
|---------|---------|
|*file-name*     |インポートするデータが含まれている XML ファイルを指定します。         |
|/scid:*SCID*    |サービス構成 ID (SCID) を指定します。         |
|/machine        |コンピューターごとの接続ストレージ領域を指定します。  このオプションと **/msa** オプションを同時に使用することはできません。         |
|/msa:*account*  |ユーザーごとの接続ストレージに使用するアカウントを指定します。 ユーザーが領域を使用するには、本体にサインインする必要があります。  このオプションと **/machine** オプションを同時に使用することはできません。         |
|/replace        |インポートを実行する前に、指定された接続ストレージ領域内のすべてのコンテナーを削除します。         |
|/verbose        |インポートの状態を表示します。         |


 <a id="xbstorage_export"></a>

### <a name="xbstorage-export"></a>Xbstorage export

`xbstorage export *outfile* [/context:*input-file*] [/scid:*SCID*] [/machine] [/msa:*account*] [/verbose]`

接続ストレージ領域から、**outfile** によって指定されたファイルにデータをエクスポートします。    このファイルはデータが含まれる XML ファイルです。 例を生成する方法については「[xbstorage generate](#xbstorage_generate)」を参照してください。 ファイルの XML 形式の詳細については、後の「[インポートおよびエクスポートのファイル形式](#xbstorage_fileformat)」を参照してください。 接続ストレージ領域を指定するには 2 つの方法があります。

- **/context** パラメーターが使用され、\<infile> によって指定された名前のファイルに **ContextDescription** セクションが存在し、そのセクションに正しい情報が入力されている場合、そのファイルを使用して接続ストレージ領域を指定します。
- ストレージ領域はコマンドライン パラメーターによって部分的または完全に指定することもでき、これは **/context** ファイルに指定されているストレージ領域の対応する要素よりも優先されます。

使用法の例:

```cmd
  xbstorage export exporteddata.xml /context:space.xml
  xbstorage export exporteddata.xml /machine /scid:2AAEB34B-DAB2-4879-B625-D970069C1D22
  xbstorage export exporteddata.xml /msa:user@domain.com /scid:2AAEB34B-DAB2-4879-B625-D970069C1D22
  xbstorage export exporteddata.xml /context:space.xml /verbose
```

> [!NOTE]
> 指定された接続ストレージ領域をエクスポートする前に、システムは、実行中のアプリが接続ストレージ領域を取得するときに実行するのと同じロジックを使用して、クラウドとの同期を試みます。
>
> 同じプライマリー SCID を持つアプリケーションが実行中である場合、この操作は競合状態を引き起こす可能性があり、接続ストレージ領域の内容が不確定な状態になる可能性があります。

|オプション  |説明  |
|---------|---------|
|*outfile*             |データのエクスポート先となる XML ファイル。         |
|/context:*input-file* |領域情報を読み取る入力ファイルを指定します。         |
|/scid:*SCID*          |サービス構成 ID (SCID) を指定します。         |
|/machine              |コンピューターごとの接続ストレージ領域を指定します。  このオプションと **/msa** オプションを同時に使用することはできません。         |
|/msa:*account*        |ユーザーごとの接続ストレージに使用するアカウントを指定します。 ユーザーが領域を使用するには、本体にサインインする必要があります。  このオプションと **/machine** オプションを同時に使用することはできません。         |
|/verbose              |エクスポート操作の状態を表示します。         |

<a id="xbstorage_delete"></a>

### <a name="xbstorage-delete"></a>Xbstorage delete

`xbstorage delete [/context:*input-file*] [/scid:*SCID*] [/machine] [/msa:*account*] [/verbose]`

接続ストレージ領域からすべてのデータを削除します。
接続ストレージ領域を指定するには 2 つの方法があります。

- **/context** パラメーターが使用され、\<infile> によって指定された名前のファイルに **ContextDescription** セクションが存在し、そのセクションに正しい情報が入力されている場合、そのファイルを使用して接続ストレージ領域を指定します。
- ストレージ領域はコマンドライン パラメーターによって部分的または完全に指定することもでき、これは **/context** ファイルに指定されているストレージ領域の対応する要素よりも優先されます。

使用法の例:

```cmd
  xbstorage delete /context:space.xml
  xbstorage delete /machine /scid:2AAEB34B-DAB2-4879-B625-D970069C1D22
  xbstorage delete /msa:user@domain.com /scid:2AAEB34B-DAB2-4879-B625-D970069C1D22
  xbstorage delete /context:space.xml /verbose
```

> [!NOTE]
> 指定された接続ストレージ領域を削除する前に、システムは、実行中のアプリが接続ストレージ領域を取得するときに実行するのと同じロジックを使用して、クラウドとの同期を試みます。
>> 同じプライマリー SCID を持つアプリケーションが実行中である場合、この操作は競合状態を引き起こす可能性があり、接続ストレージ領域の内容が不確定な状態になる可能性があります。

|オプション  |説明 |
|---------|---------|
|/context:*input-file*     |領域情報を読み取る入力ファイルを指定します。         |
|/scid:*SCID*              |サービス構成 ID (SCID) を指定します。         |
|/machine                  |コンピューターごとの接続ストレージ領域を指定します。  このオプションと **/msa** オプションを同時に使用することはできません。         |
|/msa:*account*            |ユーザーごとの接続ストレージに使用するアカウントを指定します。 ユーザーが領域を使用するには、本体にサインインする必要があります。  このオプションと **/machine** オプションを同時に使用することはできません。         |
|/verbose                  |削除操作の状態を表示します。         |

 <a id="xbstorage_generate"></a>

### <a name="xbstorage-generate"></a>Xbstorage generate

`xbstorage generate *file-name* [/containers:*n*] [/blobs:*n*] [/blobsize:*n*]`

ダミー データを生成し、\<filename> によって指定されたファイルに保存します。 ファイルの XML 形式の詳細については、後の「[インポートおよびエクスポートのファイル形式](#xbstorage_fileformat)」を参照してください。    サービス構成 ID (SCID) は 00000000-0000-0000-0000-000000000000 に設定され、コンピューターごとの接続ストレージ領域用にアカウントが設定されます。 これらの値を変更する場合は、生成された後のファイルを直接編集できます。

使用法の例:

```cmd
  xbstorage generate dummydata.xml
  xbstorage generate dummydata.xml /containers:4
  xbstorage generate dummydata.xml /blobs:10
  xbstorage generate dummydata.xml /containers:4 /blobs:10
  xbstorage generate dummydata.xml /containers:4 /blobs:10 /blobsize:512
```

> [!NOTE]
> バイト データは単純な昇順です。たとえば、5 バイトの BLOB は 00 01 02 03 04 のようなバイトで構成されます。 >>  ユーザーごとの接続ストレージ領域を指定する場合は、XML ファイルの **Account** ノードを次のように変更します。
>  ```
>    <Account msa="user@domain.com"/>
>  ```

|オプション  |説明  |
|---------|---------|
|*file-name*     | データの書き込み先となる XML ファイル。 |
|/containers:*n* | 生成するコンテナーの数を *n* で指定します。 既定値は 2 です。  |
|/blobs:*n*      | 生成する BLOB の数を *n* で指定します。 既定値は 3 です。  |
|/blobsize:*n*   | BLOB ごとのバイト数を *n* で指定します。 既定のサイズは 1024 バイトです。  |

 <a id="xbstorage_simulate"></a>

### <a name="xbstorage-simulate"></a>Xbstorage simulate

`xbstorage simulate [/reserveremainingspace] [/forceoutoflocalstorage] [/stop] [/verbose]`

接続ストレージ サービスのローカル ストレージが不足した状態をシミュレートします。

|オプション  |説明  |
|---------|---------|
|/reserveremainingspace | 接続ストレージの残りのすべての領域を予約します。 接続ストレージからデータを削除すると、使用できる領域が増加します。 |

|/forceoutoflocalstorage | 利用可能な領域が接続ストレージ サービスに残っていない状態をシミュレートします。 接続ストレージからデータを削除しても、引き続き接続ストレージ サービスからメモリー不足が報告されます。 |

|/stop | すべてのシミュレーションを停止します。 |

|/verbose | シミュレーション操作の状態を表示します。 |

 <a id="ID4E4MAC"></a>

### <a name="common-options"></a>共通のオプション

`xbstorage [/?] [/X*:address* [*+accesskey*] ]`

|オプション  |説明  |
|---------|---------|
| /?                           |  xbstorage.exe のヘルプを表示します。 |
| /X *:address* [*+accesskey*]  | ターゲットの本体のホスト名またはアドレス (本体に **Tools IP** として表示されます) を指定しますが、既定の本体は変更しません。 このオプションを使用しない場合、既定の本体が使用されます。*Accesskey* は、アクセス キーを知っている人だけに本体へのアクセスを制限するために使用できる文字列です。 **Xbconfig**コマンドを使用して、アクセス キーを設定**accesskey =。 キー、* です。アクセス キーを有効にする本体を再起動します。 アクセス キーが設定されている本体にアクセスするには、本体の IP アドレスまたはホスト名の後にプラス記号 (+) とアクセス キーを付け加える必要があります。
> [!NOTE]
> xbconnect で既定の本体を設定するときにアクセス キーを指定した場合、アクセス キーは既定の本体アドレスの一部として保存されます。
|

## <a name="gamesaveutil"></a>Gamesaveutil

*Gamesaveutil* を使うと、アプリのローカルにキャッシュされた接続ストレージを管理できます。*xbstorage* と同じ関数をすべて使うことができます。 xbstorage ツールと同様、*gamesaveutil* には同じ 6 つのデータ管理関数が用意されていますが、動作がいくらか異なります。 import、export、delete、reset の各コマンドを使うには、Xbox Live ユーザーがサインインしている必要があります。 Windows 10 で Xbox アプリを使うと、現在のユーザーを表示および変更できます。

### <a name="commands"></a>コマンド

|コマンド  |説明  |
|---------|---------|
|import   |指定された XML ファイルからデータをインポートします。         |
|export   |指定された xml ファイルにデータをエクスポートします。         |
|delete   |指定されたアプリからデータを削除します。        |
|reset    |指定されたアプリのローカル データのみ削除します。         |
|generate |ダミー データを生成し、指定された xml ファイルに保存します。         |
|simulate |テストすることが難しい特殊な条件をシミュレートします。         |

### <a name="gamesaveutil-import"></a>Gamesaveutil import

`gamesaveutil import <filename> [/pfn:<PFN>] [/scid:<SCID>] [/replace]`

\<filename> で指定されたデータをインポートします。

このファイルはデータが含まれる XML ファイルです。 「`gamesaveutil help generate`」と入力すると、例の生成方法を参照できます。

データが保存されるアプリの PFN と SCID を指定する方法は 2 つあります。

入力ファイルに ContextDescription セクションがあり適切に入力されている場合は、これを使用してターゲット アプリの PFN と SCID を指定します。

PFN と SCID は、コマンドライン パラメーターによって部分的または完全に指定することができ、これは入力ファイルで指定されている PFN と SCID の対応する要素よりも優先されます。

|オプション  |説明  |
|---------|---------|
|/pfn:\<PFN>       |アプリがインポートを実行するパッケージ ファミリ名 (PFN) を指定します。 アプリがインストールされている必要があります。         |
|/scid:\<SCID>     |サービス構成 ID (SCID) を指定します。 これは、Xbox Live 構成から取得されます。         |
|/replace         |インポートを実行する前に、すべてのコンテナーを削除します。         |

使用例:

```cmd
gamesaveutil import mydata.xml
gamesaveutil import mydata.xml /replace
gamesaveutil import mydata.xml /pfn:MyGame_xxxxxx /scid:2AAEB34B-DAB2-4879-B625-D970069C1D22
```


> [!NOTE]
> インポートするには、アプリがインストールされていて、データが既に同期されている必要があります。
> 
> /replace が指定されていない場合、入力ファイルで指定された場合を除き既存のコンテナーは変更されません。

### <a name="gamesaveutil-export"></a>Gamesaveutil export

`gamesaveutil export <outfile> [/pfn:<PFN>] [/scid:<SCID>] [/context:<infile>]`

\<outfile> により指定されたファイルにデータをエクスポートします。

このファイルはデータが含まれる XML ファイルです。 「gamesaveutil」と入力すると、例の生成方法を参照できます。

データをエクスポートする場所を指定する方法は 2 つあります。

/context パラメーターが使用され、\<infile> によって指定されたファイル名に ContextDescription セクションが存在し、そのセクションに正しい情報が入力されている場合、そのファイルを使用してソース データの場所を指定します。

場所はコマンドライン パラメーターによって指定することもでき、これは /context ファイルによって指定されている対応する要素よりも優先されます。

|オプション  |説明  |
|---------|---------|
|/context:\<infile>     |指定したファイルを使って、アプリの PFN と SCID を指定します。         |
|/pfn:\<PFN>            |アプリがエクスポートを実行するパッケージ ファミリ名 (PFN) を指定します。 アプリがインストールされている必要があります。       |
|/scid:\<SCID>          |サービス構成 ID (SCID) を指定します。 これは、Xbox Live 構成から取得されます。        |

使用例:

```cmd
gamesaveutil export exporteddata.xml /context:target.xml
gamesaveutil export exporteddata.xml /pfn:MyGame_xxxxxx /scid:2AAEB34B-DAB2-4879-B625-D970069C1D22
```


> [!NOTE]
> エクスポートするには、アプリがインストールされていて、データが既に同期されている必要があります。

### <a name="gamesaveutil-delete"></a>Gamesaveutil delete

`gamesaveutil delete [/pfn:<PFN>] [/scid:<SCID>] [/context:<infile>]`

指定した PFN と SCID のすべてのデータを削除します。

データを削除する場所を指定する方法は 2 つあります。

/context パラメーターが使用され、\<infile> によって指定されたファイル名に ContextDescription セクションが存在し、そのセクションに正しい情報が入力されている場合、そのファイルを使用してソース データの場所を指定します。

場所はコマンドライン パラメーターによって指定することもでき、これは /context ファイルによって指定されている対応する要素よりも優先されます。

|オプション  |説明  |
|---------|---------|
|/context:\<infile>     |指定したファイルを使って、アプリの PFN と SCID を指定します。         |
|/pfn:\<PFN>            |アプリがデータを削除するパッケージ ファミリ名 (PFN) を指定します。 アプリがインストールされている必要があります。       |
|/scid:\<SCID>          |サービス構成 ID (SCID) を指定します。 これは、Xbox Live 構成から取得されます。        |

使用例:

```cmd
gamesaveutil delete /context:target.xml
gamesaveutil delete /pfn:MyGame_xxxxxx /scid:2AAEB34B-DAB2-4879-B625-D970069C1D22
```


> [!NOTE]
> コンテナーを削除するには、アプリがインストールされている必要があります。

### <a name="gamesaveutil-reset"></a>Gamesaveutil reset

`gamesaveutil reset [/pfn:<PFN>] [/scid:<SCID>] [/context:<infile>]`

指定した PFN と SCID のすべてのローカル データを削除します。

データを削除する場所を指定する方法は 2 つあります。

/context パラメーターが使用され、\<infile> によって指定されたファイル名に ContextDescription セクションが存在し、そのセクションに正しい情報が入力されている場合、そのファイルを使用してソース データの場所を指定します。

場所はコマンドライン パラメーターによって指定することもでき、これは /context ファイルによって指定されている対応する要素よりも優先されます。

|オプション  |説明  |
|---------|---------|
|/context:\<infile>     |指定したファイルを使って、アプリの PFN と SCID を指定します。         |
|/pfn:\<PFN>            |アプリがデータを削除するパッケージ ファミリ名 (PFN) を指定します。 アプリがインストールされている必要があります。       |
|/scid:\<SCID>          |サービス構成 ID (SCID) を指定します。 これは、Xbox Live 構成から取得されます。        |

使用例:

```cmd
gamesaveutil reset /context:target.xml
gamesaveutil reset /pfn:MyGame_xxxxxx /scid:2AAEB34B-DAB2-4879-B625-D970069C1D22
```


> [!NOTE]
> ローカル データを削除するには、アプリがインストールされている必要があります。

### <a name="gamesaveutil-generate"></a>Gamesaveutil generate

`gamesaveutil generate <filename> [/containers:<n>] [/blobs:<n>] [/blobsize:<n>]`

ダミー データを生成し、\<filename> によって指定されたファイルに保存します。
サービス構成 ID (SCID) は、00000000-0000-0000-0000-000000000000 に設定されます。 必要に応じて、生成後にファイルを手動で編集してそれらの値を変更します。

|オプション  |説明  |
|---------|---------|
|/containers:\<n>     |生成するコンテナーの数を指定します。 既定値は 2 です。         |
|/blobs:\<n>          |生成するコンテナーごとの BLOB 数を指定します。 既定値は 3 です。        |
|/blobsize:\<n>       |BLOB ごとのバイト数を指定します。 既定値は 1024 です。         |

使用例:

```cmd
gamesaveutil generate dummydata.xml
gamesaveutil generate dummydata.xml /containers:4
gamesaveutil generate dummydata.xml /blobs:10
gamesaveutil generate dummydata.xml /containers:4 /blobs:10
gamesaveutil generate dummydata.xml /containers:4 /blobs:10 /blobsize:512
```


> [!NOTE]
> バイト データは単純な昇順です。つまり 5 バイトの BLOB は 00 01 02 03 04 のようなバイトで構成されます。

### <a name="gamesaveutil-simulate"></a>Gamesaveutil simulate

`gamesaveutil simulate [/markcontainerschanged] [/stop]`

特定のシナリオをテストするための特殊な条件をシミュレートします。

|オプション  |説明  |
|---------|---------|
|/markcontainerschanged     |アプリが一時停止から再開して新しいプロバイダーを取得したときに、すべてのコンテナーが変更されたように見えるよう強制します。 /stop でクリアされるまですべてのアプリに影響します。      |
|/stop                      |すべてのシミュレーションを停止します。         |


 <a id="xbstorage_fileformat"></a>

## <a name="import-and-export-file-format"></a>インポートおよびエクスポートのファイル形式

*xbstorage* ツールの **import**、**export**、**generate** の各コマンドで使用される XML ファイルは、次の例に示す形式になります。

```xml
<?xml version="1.0" encoding="UTF-8"?>
  <XbConnectedStorageSpace>
    <ContextDescription>
      <Account msa="user@domain.com" />
      <Title scid="00000000-0000-0000-0000-000000000000" />
    </ContextDescription>
    <Data>
      <Containers>
        <Container name="Container1" displayName="Optional Display Name">
          <Blobs>
            <Blob name="Blob1">
              <![CDATA[... ] ]>
            </Blob>
            ...
            <Blob name="BlobN">
              <![CDATA[... ] ]>
            </Blob>
          </Blobs>
        </Container>
        ...
        <Container name="ContainerN">
        ...
        </Container>
      </Containers>
    </Data>
  </XbConnectedStorageSpace>
```

*gamesaveutil* で **import**、**export**、**generate** に合わせてこの xml の形式を設定するには、\<ContextDescription> ノードの \<Account> メンバー ノードを \<PackageFamilyName> ノードに置き換えるだけでかまいません。
これにより、\<ContextDescription> ノードが変更されます。

```xml
<ContextDescription>
    <Account msa="user@domain.com" />
    <Title scid="00000000-0000-0000-0000-000000000000" />
</ContextDescription>
```

変更後は次のとおりです。

```xml
<ContextDescription>
    <PackageFamilyName pfn="MyGame_xxxxxx" />
    <Title scid="00000000-0000-0000-0000-000000000000" />
</ContextDescription>
```

> [!NOTE]
> これらの XML ファイルのデータ形式は、プラットフォームと同じではありません。インポートおよびエクスポート目的でのみ使います。 これらの XML ファイルのデータ形式は、今後変更される可能性があるため、アーカイブ形式ではなく、中間形式またはユーティリティ形式として扱う必要があります。

**ContextDescription** ノードは省略可能です。 コンピューターの接続ストレージ領域を作成している場合は、`<Account machine="true"/>` の代わりに `<Account msa="user@domain.com"/>` を使用できます。 これを使用しない場合は、インポートのコマンド ラインでコンテキストを指定できます。
BLOB およびコンテナーは、そのファイルの生成対象であるゲームまたはアプリケーションによって与えられた対応する名前を持つ必要があります。
各 BLOB の内容は、**CDATA** タグでラップされた文字列である必要があります。これは、**CRYPT_STRING_BASE64** フラグを指定して **CryptBinaryToStringW** を呼び出し、その BLOB のデータを RAW バイト配列として提供することによって生成されます。 逆に、**CryptStringToBinary** を呼び出し、元の暗号化された文字列を提供することによって、BLOB データを元の状態に変換できます。 これら 2 つの関数の使用例については、Visual Studio の MSDN フォーラムの「[CryptBinaryToString returns invalid bytes](http://social.msdn.microsoft.com/Forums/vstudio/en-US/9acac904-c226-4ae0-9b7f-261993b9fda2/cryptbinarytostring-returns-invalid-bytes?forum=vcgeneral)」を参照してください。

<a id="ID4EWBAE"></a>