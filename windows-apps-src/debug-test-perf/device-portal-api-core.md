---
author: dbirtolo
ms.assetid: bfabd3d5-dd56-4917-9572-f3ba0de4f8c0
title: "デバイス ポータル コア API リファレンス"
description: "Windows Device Portal コア REST API について説明します。これによって、データにアクセスし、プログラムを使ってデバイスを制御することが可能になります。"
translationtype: Human Translation
ms.sourcegitcommit: fae2c6b31c9c6c07026abc4718959b02a36e6600
ms.openlocfilehash: 226ecaecd93e4996e438f56f780926ca63c184fd

---

# デバイス ポータル コア API リファレンス

Windows Device Portal の機能はすべて、REST API の上に構築されています。REST API は、プログラムからデータにアクセスしてデバイスを制御するために使用できます。

## アプリの展開

---
### アプリをインストールする

**要求**

次の要求形式を使用して、アプリをインストールできます。

メソッド      | 要求 URI
:------     | :-----
POST | /api/app/packagemanager/package
<br />
**URI パラメーター**

次の追加パラメーターを要求 URI に指定できます。

URI パラメーター | 説明
:---          | :---
package   | (**必須**) インストールするパッケージのファイル名。
<br />
**要求ヘッダー**

- なし

**要求本文**

- .appx または .appxbundle ファイル、およびアプリが必要とする依存関係。 
- デバイスが IoT または Windows デスクトップの場合、アプリの署名に使う証明書。 その他のプラットフォームでは、証明書は必要ありません。 

**応答**

**状態コード**

この API では次の状態コードが返される可能性があります。

HTTP 状態コード      | 説明
:------     | :-----
200 | 展開要求は受け入れられ、処理されています。
4XX | エラー コード
5XX | エラー コード
<br />
**利用可能なデバイス ファミリ**

* Windows Mobile
* Windows デスクトップ
* Xbox
* HoloLens
* IoT

---
### アプリのインストール状態を取得する

**要求**

次の要求形式を使用して、現在進行中のアプリのインストールの状態を取得できます。
 
メソッド      | 要求 URI
:------     | :-----
GET | /api/app/packagemanager/state
<br />
**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

**状態コード**

この API では次の状態コードが返される可能性があります。

HTTP 状態コード      | 説明
:------     | :-----
200 | 最後の展開の結果
204 | インストールは実行中です
404 | インストール操作は見つかりませんでした
<br />
**利用可能なデバイス ファミリ**

* Windows Mobile
* Windows デスクトップ
* Xbox
* HoloLens
* IoT

---
### アプリをアンインストールする

**要求**

次の要求形式を使用して、アプリをアンインストールできます。
 
メソッド      | 要求 URI
:------     | :-----
DELETE | /api/app/packagemanager/package
<br />

**URI パラメーター**

URI パラメーター | 説明
:---          | :---
package   | (**必須**) ターゲット アプリの PackageFullName (GET /api/app/packagemanager/packages から)

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

**状態コード**

この API では次の状態コードが返される可能性があります。

HTTP 状態コード      | 説明
:------     | :-----
200 | OK
4XX | エラー コード
5XX | エラー コード
<br />
**利用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* Xbox
* HoloLens
* IoT

---
### インストールされたアプリを取得する

**要求**

次の要求形式を使用して、システムにインストールされているアプリの一覧を取得できます。
 
メソッド      | 要求 URI
:------     | :-----
GET | /api/app/packagemanager/packages
<br />

**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

応答には、インストールされているパッケージの一覧と関連する詳細情報が含まれます。 この応答のテンプレートは次のとおりです。
```
{"InstalledPackages": [
    {
        "Name": string,
        "PackageFamilyName": string,
        "PackageFullName": string,
        "PackageOrigin": int, (https://msdn.microsoft.com/en-us/library/windows/desktop/dn313167(v=vs.85).aspx)
        "PackageRelativeId": string,
        "Publisher": string,
        "Version": {
            "Build": int,
            "Major": int,
            "Minor": int,
            "Revision": int
     },
     "RegisteredUsers": [
     {
        "UserDisplayName": string,
        "UserSID": string
     },...
     ]
    },...
]}
```
**状態コード**

この API では次の状態コードが返される可能性があります。

HTTP 状態コード      | 説明
:------     | :-----
200 | OK
4XX | エラー コード
5XX | エラー コード
<br />
**利用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* Xbox
* HoloLens
* IoT

---
## デバイス マネージャー
---
### コンピューターにインストールされているデバイスを取得する

**要求**

次の要求形式を使用して、コンピューターにインストールされているデバイスの一覧を取得できます。
 
メソッド      | 要求 URI
:------     | :-----
GET | /api/devicemanager/devices
<br />

**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

応答には、デバイスにアタッチされているデバイスの JSON 配列が含まれます。
``` 
{"DeviceList": [
    {
        "Class": string,
        "Description": string,
        "ID": string,
        "Manufacturer": string,
        "ParentID": string,
        "ProblemCode": int,
        "StatusCode": int
    },...
]}
```

**状態コード**

この API では次の状態コードが返される可能性があります。

HTTP 状態コード      | 説明
:------     | :-----
200 | OK
4XX | エラー コード
5XX | エラー コード
<br />
**利用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* IoT

---
## ダンプの収集
---
### アプリのすべてのクラッシュ ダンプの一覧を取得する

**要求**

次の要求形式を使用して、サイドローディングされたすべてのアプリについて、利用可能なすべてのクラッシュ ダンプの一覧を取得できます。
 
メソッド      | 要求 URI
:------     | :-----
GET | /api/debug/dump/usermode/dumps
<br />

**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

応答には、サイドローディングされたアプリケーションごとにクラッシュ ダンプの一覧が含まれます。

**状態コード**

この API では次の状態コードが返される可能性があります。

HTTP 状態コード      | 説明
:------     | :-----
200 | OK
4XX | エラー コード
5XX | エラー コード
<br />
**利用可能なデバイス ファミリ**

* Windows Desktop
* HoloLens
* IoT

---
### アプリのクラッシュ ダンプ収集設定を取得する

**要求**

次の要求形式を使用して、サイドローディングされたアプリのクラッシュ ダンプ収集設定を取得できます。
 
メソッド      | 要求 URI
:------     | :-----
GET | /api/debug/dump/usermode/crashcontrol
<br />

**URI パラメーター**

次の追加パラメーターを要求 URI に指定できます。

URI パラメーター | 説明
:---          | :---
packageFullname   | (**必須**) サイドローディングされたアプリのパッケージの完全な名前。
<br />
**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

応答は、次の形式になります。
```
{"CrashDumpEnabled": bool}
```

**状態コード**

この API では次の状態コードが返される可能性があります。

HTTP 状態コード      | 説明
:------     | :-----
200 | OK
4XX | エラー コード
5XX | エラー コード
<br />
**利用可能なデバイス ファミリ**

* Windows Desktop
* HoloLens
* IoT

---
### サイドローディングされたアプリのクラッシュ ダンプを削除する

**要求**

次の要求形式を使用して、サイドローディングされたアプリのクラッシュ ダンプを削除できます。
 
メソッド      | 要求 URI
:------     | :-----
DELETE | /api/debug/dump/usermode/crashdump
<br />

**URI パラメーター**

次の追加パラメーターを要求 URI に指定できます。

URI パラメーター | 説明
:---          | :---
packageFullname   | (**必須**) サイドローディングされたアプリのパッケージの完全な名前。
fileName   | (**必須**) 削除する必要があるダンプ ファイルの名前。
<br />
**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

**状態コード**

この API では次の状態コードが返される可能性があります。

HTTP 状態コード      | 説明
:------     | :-----
200 | OK
4XX | エラー コード
5XX | エラー コード
<br />
**利用可能なデバイス ファミリ**

* Windows Desktop
* HoloLens
* IoT

---
### サイドローディングされたアプリのクラッシュ ダンプを無効にする

**要求**

次の要求形式を使用して、サイドローディングされたアプリのクラッシュ ダンプを無効にすることができます。
 
メソッド      | 要求 URI
:------     | :-----
DELETE | /api/debug/dump/usermode/crashcontrol

<br />
**URI パラメーター**

次の追加パラメーターを要求 URI に指定できます。

URI パラメーター | 説明
:---          | :---
packageFullname   | (**必須**) サイドローディングされたアプリのパッケージの完全な名前。
<br />
**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

**状態コード**

この API では次の状態コードが返される可能性があります。

HTTP 状態コード      | 説明
:------     | :-----
200 | OK
4XX | エラー コード
5XX | エラー コード
<br />
**利用可能なデバイス ファミリ**

* Windows Desktop
* HoloLens
* IoT

---
### サイドローディングされたアプリのクラッシュ ダンプをダウンロードする

**要求**

次の要求形式を使用して、サイドローディングされたアプリのクラッシュ ダンプをダウンロードできます。
 
メソッド      | 要求 URI
:------     | :-----
GET | /api/debug/dump/usermode/crashdump
<br />

**URI パラメーター**

次の追加パラメーターを要求 URI に指定できます。

URI パラメーター | 説明
:---          | :---
packageFullname   | (**必須**) サイドローディングされたアプリのパッケージの完全な名前。
fileName   | (**必須**) ダウンロードするダンプ ファイルの名前。
<br />
**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

応答には、ダンプ ファイルが含まれます。 WinDbg または Visual Studio を使用して、ダンプ ファイルを検証できます。

**状態コード**

この API では次の状態コードが返される可能性があります。

HTTP 状態コード      | 説明
:------     | :-----
200 | OK
4XX | エラー コード
5XX | エラー コード
<br />
**利用可能なデバイス ファミリ**

* Windows Desktop
* HoloLens
* IoT

---
### サイドローディングされたアプリのクラッシュ ダンプを有効にする

**要求**

次の要求形式を使用して、サイドローディングされたアプリのクラッシュ ダンプを有効にすることができます。
 
メソッド      | 要求 URI
:------     | :-----
POST | /api/debug/dump/usermode/crashcontrol
<br />

**URI パラメーター**

次の追加パラメーターを要求 URI に指定できます。

URI パラメーター | 説明
:---          | :---
packageFullname   | (**必須**) サイドローディングされたアプリのパッケージの完全な名前。
<br />
**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

**状態コード**

この API では次の状態コードが返される可能性があります。

HTTP 状態コード      | 説明
:------     | :-----
200 | OK
<br />
**利用可能なデバイス ファミリ**

* Windows Desktop
* HoloLens
* IoT

---
### バグチェック ファイルの一覧を取得する

**要求**

次の要求形式を使用して、バグチェックのミニダンプ ファイルの一覧を取得できます。
 
メソッド      | 要求 URI
:------     | :-----
GET | /api/debug/dump/kernel/dumplist
<br />

**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

応答には、ダンプ ファイル名とこれらのファイルのサイズの一覧が含まれます。 一覧は、次の形式になります。 2 つ目の *FileName* パラメーターは、ファイルのサイズです。 これは、既知のバグです。
```
{"DumpFiles": [
    {
        "FileName": string,
        "FileName": string
    },...
]}
```

**状態コード**

この API では次の状態コードが返される可能性があります。

HTTP 状態コード      | 説明
:------     | :-----
200 | OK
<br />
**利用可能なデバイス ファミリ**

* Windows Desktop
* IoT

---
### バグチェックのダンプ ファイルをダウンロードする

**要求**

次の要求形式を使用して、バグチェックのダンプ ファイルをダウンロードできます。
 
メソッド      | 要求 URI
:------     | :-----
GET | /api/debug/dump/kernel/dump
<br />

**URI パラメーター**

次の追加パラメーターを要求 URI に指定できます。

URI パラメーター | 説明
:---          | :---
filename   | (**必須**) ダンプ ファイルのファイル名。 API を使ってダンプの一覧を取得することによって確認できます。
<br />
**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

応答には、ダンプ ファイルが含まれます。 WinDbg を使用してこのファイルを調べることができます。

**状態コード**

この API では次の状態コードが返される可能性があります。

HTTP 状態コード      | 説明
:------     | :-----
200 | OK
4XX | エラー コード
5XX | エラー コード
<br />
**利用可能なデバイス ファミリ**

* Windows Desktop
* IoT

---
### バグチェックのクラッシュ制御の設定を取得する

**要求**

次の要求形式を使用して、バグチェックのクラッシュ制御の設定を取得できます。
 
メソッド      | 要求 URI
:------     | :-----
GET | /api/debug/dump/kernel/crashcontrol

<br />
**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

応答には、クラッシュの制御の設定が含まれます。 CrashControl について詳しくは、「[CrashControl](https://technet.microsoft.com/library/cc951703.aspx)」をご覧ください。 応答のテンプレートは次のとおりです。
```
{
    "autoreboot": int,
    "dumptype": int,
    "maxdumpcount": int,
    "overwrite": int
}
```

**状態コード**

この API では次の状態コードが返される可能性があります。

HTTP 状態コード      | 説明
:------     | :-----
200 | OK
4XX | エラー コード
5XX | エラー コード
<br />
**利用可能なデバイス ファミリ**

* Windows Desktop
* IoT

---
### ライブ カーネル ダンプを取得する

**要求**

次の要求形式を使用して、ライブ カーネル ダンプを取得できます。
 
メソッド      | 要求 URI
:------     | :-----
GET | /api/debug/dump/livekernel
<br />

**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

応答には、カーネル モードの完全なダンプが含まれます。 WinDbg を使用してこのファイルを調べることができます。

**状態コード**

この API では次の状態コードが返される可能性があります。

HTTP 状態コード      | 説明
:------     | :-----
200 | OK
4XX | エラー コード
5XX | エラー コード
<br />
**利用可能なデバイス ファミリ**

* Windows Desktop
* IoT

---
### ライブ ユーザー プロセスからダンプを取得する

**要求**

次の要求形式を使用して、ライブ ユーザー プロセスのダンプを取得できます。
 
メソッド      | 要求 URI
:------     | :-----
GET | /api/debug/dump/usermode/live
<br />

**URI パラメーター**

次の追加パラメーターを要求 URI に指定できます。

URI パラメーター | 説明
:---          | :---
pid   | (**必須**) 目的のプロセスの一意のプロセス ID。
<br />
**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

応答には、プロセス ダンプが含まれます。 WinDbg または Visual Studio を使用してこのファイルを調べることができます。

**状態コード**

この API では次の状態コードが返される可能性があります。

HTTP 状態コード      | 説明
:------     | :-----
200 | OK
4XX | エラー コード
5XX | エラー コード
<br />
**利用可能なデバイス ファミリ**

* Windows Desktop
* IoT

---
### バグチェックのクラッシュ制御の設定を行う

**要求**

次の要求形式を使用して、バグチェック データの収集に関する設定を行うことができます。
 
メソッド      | 要求 URI
:------     | :-----
POST | /api/debug/dump/kernel/crashcontrol
<br />

**URI パラメーター**

次の追加パラメーターを要求 URI に指定できます。

URI パラメーター | 説明
:---          | :---
autoreboot   | (**オプション**) true または false。 これは、エラーやロックの発生後に、システムが自動的に再起動するかどうかを示します。
dumptype   | (**オプション**) dump タイプ。 サポートされる値については、「[CrashDumpType 列挙体](https://msdn.microsoft.com/library/azure/microsoft.azure.management.insights.models.crashdumptype.aspx)」をご覧ください。
maxdumpcount   | (**オプション**) 保存するダンプの最大数。
overwrite   | (**オプション**) true または false。 これは、*maxdumpcount* で指定されているダンプ カウンターの制限に達した場合に古いダンプを上書きするかどうかを示します。
<br />
**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

**状態コード**

この API では次の状態コードが返される可能性があります。

HTTP 状態コード      | 説明
:------     | :-----
200 | OK
4XX | エラー コード
5XX | エラー コード
<br />
**利用可能なデバイス ファミリ**

* Windows Desktop
* IoT

---
## ETW
---
### websocket 経由でリアルタイムの ETW セッションを作成する

**要求**

次の要求形式を使用して、リアルタイムの ETW セッションを作成できます。 これは、websocket 経由で管理されます。  ETW イベントは、サーバーで一括処理され、1 秒に 1 回クライアントに送信されます。 
 
メソッド      | 要求 URI
:------     | :-----
GET/WebSocket | /api/etw/session/realtime
<br />

**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

応答には、有効なプロバイダーの ETW イベントが含まれます。  以下の「ETW WebSocket コマンド」を参照してください。 

**状態コード**

この API では次の状態コードが返される可能性があります。

HTTP 状態コード      | 説明
:------     | :-----
200 | OK
4XX | エラー コード
5XX | エラー コード
<br />
**利用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* HoloLens
* IoT

### ETW WebSocket コマンド
次のコマンドは、クライアントからサーバーに送信されます。

コマンド | 説明
:----- | :-----
provider *{guid}* enable *{level}* | *{guid}* で指定されたプロバイダー (括弧は不要) を指定されたレベルで有効にします。 *{level}* は、1 (最小限の詳細) ～ 5 (詳細) の **int** です。
provider *{guid}* disable | *{guid}* で指定されたプロバイダー (括弧は不要) を無効にします。

この応答は、サーバーからクライアントに送信されます。 これは、テキストとして送信され、JSON で解析すると次の形式になります。
```
{
    "Events":[
        {
            "Timestamp": int,
            "Provider": string,
            "ID": int, 
            "TaskName": string,
            "Keyword": int,
            "Level": int,
            payload objects...
        },...
    ],
    "Frequency": int
}
```

payload objects は、追加のキーと値のペア (文字列: 文字列) で、元の ETW イベントから提供されます。

例:
```
{
    "ID" : 42, 
    "Keyword" : 9223372036854775824, 
    "Level" : 4, 
    "Message" : "UDPv4: 412 bytes transmitted from 10.81.128.148:510 to 132.215.243.34:510. ",
    "PID" : "1218", 
    "ProviderName" : "Microsoft-Windows-Kernel-Network", 
    "TaskName" : "KERNEL_NETWORK_TASK_UDPIP", 
    "Timestamp" : 131039401761757686, 
    "connid" : "0", 
    "daddr" : "132.245.243.34", 
    "dport" : "500", 
    "saddr" : "10.82.128.118", 
    "seqnum" : "0", 
    "size" : "412", 
    "sport" : "500"
}
```

---
### 登録済みの ETW プロバイダーを列挙する

**要求**

次の要求形式を使用して、登録済みプロバイダーを列挙できます。
 
メソッド      | 要求 URI
:------     | :-----
GET | /api/etw/providers
<br />

**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

応答には、ETW プロバイダーの一覧が含まれます。 一覧には、各プロバイダーのフレンドリ名と GUID が次の形式で含まれます。
```
{"Providers": [
    {
        "GUID": string, (GUID)
        "Name": string
    },...
]}
```

**状態コード**

この API では次の状態コードが返される可能性があります。

HTTP 状態コード      | 説明
:------     | :-----
200 | OK
<br />
**利用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* HoloLens
* IoT

---
### プラットフォームによって公開されているカスタム ETW プロバイダーを列挙します。

**要求**

次の要求形式を使用して、登録済みプロバイダーを列挙できます。
 
メソッド      | 要求 URI
:------     | :-----
GET | /api/etw/customproviders
<br />

**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

200 OK。 応答には、ETW プロバイダーの一覧が含まれます。 一覧には、各プロバイダーのフレンドリ名と GUID が含まれます。

```
{"Providers": [
    {
        "GUID": string, (GUID)
        "Name": string
    },...
]}
```

**状態コード**

- 標準の状態コード。
<br />
**利用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* HoloLens
* IoT

---
## OS 情報
---
### コンピューター名を取得する

**要求**

次の要求形式を使用して、コンピューターの名前を取得できます。
 
メソッド      | 要求 URI
:------     | :-----
GET | /api/os/machinename
<br />

**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

応答には、コンピューター名が次の形式で含まれます。 

```
{"ComputerName": string}
```

**状態コード**

この API では次の状態コードが返される可能性があります。

HTTP 状態コード      | 説明
:------     | :-----
200 | OK
4XX | エラー コード
5XX | エラー コード
<br />
**利用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* Xbox
* HoloLens
* IoT

---
### オペレーティング システムの情報を取得する

**要求**

次の要求形式を使用して、コンピューターの OS 情報を取得できます。
 
メソッド      | 要求 URI
:------     | :-----
GET | /api/os/info
<br />

**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

応答には、OS 情報が次の形式で含まれます。

```
{
    "ComputerName": string,
    "OsEdition": string,
    "OsEditionId": int,
    "OsVersion": string,
    "Platform": string
}
```

**状態コード**

この API では次の状態コードが返される可能性があります。

HTTP 状態コード      | 説明
:------     | :-----
200 | OK
4XX | エラー コード
5XX | エラー コード
<br />
**利用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* Xbox
* HoloLens
* IoT

---
### デバイス ファミリを取得する 

**要求**

次の要求形式を使用して、デバイス ファミリ (Xbox、携帯電話、デスクトップなど) を取得できます。
 
メソッド      | 要求 URI
:------     | :-----
GET | /api/os/devicefamily
<br />

**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

応答には、デバイス ファミリ (SKU - デスクトップ、Xbox など) が含まれます。

```
{
   "DeviceType" : string
}
```

DeviceType は、"Windows.Xbox"、"Windows.Desktop" などのようになります。 

**状態コード**

この API では次の状態コードが返される可能性があります。

HTTP 状態コード      | 説明
:------     | :-----
200 | OK
4XX | エラー コード
5XX | エラー コード

**利用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* Xbox
* HoloLens
* IoT

---
### コンピューター名を設定する

**要求**

次の要求形式を使用して、コンピューターの名前を設定できます。
 
メソッド      | 要求 URI
:------     | :-----
POST | /api/os/machinename
<br />

**URI パラメーター**

次の追加パラメーターを要求 URI に指定できます。

URI パラメーター | 説明
:---          | :---
name | (**必須**) コンピューターの新しい名前。
<br />
**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

**状態コード**

この API では次の状態コードが返される可能性があります。

HTTP 状態コード      | 説明
:------     | :-----
200 | OK
<br />
**利用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* Xbox
* HoloLens
* IoT

---
## パフォーマンス データ
---
### 実行中のプロセスの一覧を取得する

**要求**

次の要求形式を使用して、現在実行中のプロセスの一覧を取得できます。  これは、WebSocket 接続にアップグレードすることもでき、1 秒に 1 度クライアントにプッシュされる同じ JSON データを取得できます。 
 
メソッド      | 要求 URI
:------     | :-----
GET | /api/resourcemanager/processes
GET/WebSocket | /api/resourcemanager/processes
<br />

**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

応答には、プロセスの一覧と各プロセスの詳細情報が含まれます。 情報は JSON 形式で、テンプレートは次のとおりです。
```
{"Processes": [
    {
        "CPUUsage": int,
        "ImageName": string,
        "PageFileUsage": int,
        "PrivateWorkingSet": int,
        "ProcessId": int,
        "SessionId": int,
        "UserName": string,
        "VirtualSize": int,
        "WorkingSetSize": int
    },...
]}
```

**状態コード**

この API では次の状態コードが返される可能性があります。

HTTP 状態コード      | 説明
:------     | :-----
200 | OK
4XX | エラー コード
5XX | エラー コード
<br />
**利用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* HoloLens
* IoT

---
### システム パフォーマンスの統計情報を取得する

**要求**

次の要求形式を使用して、システム パフォーマンスの統計情報を取得できます。 これには、読み取りと書き込みのサイクルや、使用されているメモリの量などの情報が含まれます。
 
メソッド      | 要求 URI
:------     | :-----
GET | /api/resourcemanager/systemperf
GET/WebSocket | /api/resourcemanager/systemperf
<br />
これは、WebSocket 接続にアップグレードできます。  1 秒に 1 度以下と同じ JSON データが提供されます。 

**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

応答には、CPU と GPU の使用量、メモリ アクセス、ネットワーク アクセスなど、システムのパフォーマンス統計情報が含まれます。 この情報は JSON 形式で、テンプレートは次のとおりです。
```
{
    "AvailablePages": int,
    "CommitLimit": int,
    "CommittedPages": int,
    "CpuLoad": int,
    "IOOtherSpeed": int,
    "IOReadSpeed": int,
    "IOWriteSpeed": int,
    "NonPagedPoolPages": int,
    "PageSize": int,
    "PagedPoolPages": int,
    "TotalInstalledInKb": int,
    "TotalPages": int,
    "GPUData": 
    {
        "AvailableAdapters": [{ (One per detected adapter)
            "DedicatedMemory": int,
            "DedicatedMemoryUsed": int,
            "Description": string,
            "SystemMemory": int,
            "SystemMemoryUsed": int,
            "EnginesUtilization": [ float,... (One per detected engine)]
        },...
    ]},
    "NetworkingData": {
        "NetworkInBytes": int,
        "NetworkOutBytes": int
    }
}
```

**状態コード**

この API では次の状態コードが返される可能性があります。

HTTP 状態コード      | 説明
:------     | :-----
200 | OK
4XX | エラー コード
5XX | エラー コード
<br />
**利用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* Xbox
* HoloLens
* IoT

---
## 電源
---
### 現在のバッテリ状態を取得する

**要求**

次の要求形式を使用して、バッテリの現在の状態を取得できます。
 
メソッド      | 要求 URI
:------     | :-----
GET | /api/power/battery
<br />

**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

現在のバッテリ状態に関する情報が次の形式で返されます。
```
{
    "AcOnline": int (0 | 1),
    "BatteryPresent": int (0 | 1),
    "Charging": int (0 | 1),
    "DefaultAlert1": int,
    "DefaultAlert2": int,
    "EstimatedTime": int,
    "MaximumCapacity": int,
    "RemainingCapacity": int
}
```

**状態コード**

この API では次の状態コードが返される可能性があります。

HTTP 状態コード      | 説明
:------     | :-----
200 | OK
4XX | エラー コード
5XX | エラー コード
<br />
**利用可能なデバイス ファミリ**

* Windows Desktop
* HoloLens
* IoT
* モバイル

---
### アクティブな電源設定を取得する

**要求**

次の要求形式を使用して、アクティブな電源設定を取得できます。
 
メソッド      | 要求 URI
:------     | :-----
GET | /api/power/activecfg
<br />

**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

アクティブな電源設定の形式は、次のとおりです。
```
{"ActivePowerScheme": string (guid of scheme)}
```

**状態コード**

この API では次の状態コードが返される可能性があります。

HTTP 状態コード      | 説明
:------     | :-----
200 | OK
4XX | エラー コード
5XX | エラー コード
<br />
**利用可能なデバイス ファミリ**

* Windows Desktop
* IoT

---
### 電源設定のサブ値を取得する

**要求**

次の要求形式を使用して、電源設定のサブ値を取得できます。
 
メソッド      | 要求 URI
:------     | :-----
GET | /api/power/cfg/*<power scheme path>*
<br />
オプション:
- SCHEME_CURRENT

**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**

利用可能な電源状態の完全な一覧は、アプリケーションごとが基本で、バッテリ低下、重要なバッテリといったさまざまな電源状態がフラグ設定されています。 

**応答**

**状態コード**

この API では次の状態コードが返される可能性があります。

HTTP 状態コード      | 説明
:------     | :-----
200 | OK
4XX | エラー コード
5XX | エラー コード
<br />
**利用可能なデバイス ファミリ**

* Windows Desktop
* IoT

---
### システムの電源状態を取得する

**要求**

次の要求形式を使用して、システムの電源状態を確認できます。 これによって、低電力状態になっているかどうかを確認できます。
 
メソッド      | 要求 URI
:------     | :-----
GET | /api/power/state
<br />

**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

電源状態の情報のテンプレートは次のとおりです。
```
{"LowPowerStateAvailable": bool}
```

**状態コード**

この API では次の状態コードが返される可能性があります。

HTTP 状態コード      | 説明
:------     | :-----
200 | OK
4XX | エラー コード
5XX | エラー コード
<br />
**利用可能なデバイス ファミリ**

* Windows Desktop
* HoloLens
* IoT

---
### アクティブな電源設定を行う

**要求**

次の要求形式を使用して、アクティブな電源設定を行うことができます。
 
メソッド      | 要求 URI
:------     | :-----
POST | /api/power/activecfg
<br />

**URI パラメーター**

次の追加パラメーターを要求 URI に指定できます。

URI パラメーター | 説明
:---          | :---
scheme | (**必須**) システムのアクティブな電源設定として設定するスキームの GUID。
<br />
**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

**状態コード**

この API では次の状態コードが返される可能性があります。

HTTP 状態コード      | 説明
:------     | :-----
200 | OK
4XX | エラー コード
5XX | エラー コード
<br />
**利用可能なデバイス ファミリ**

* Windows Desktop
* IoT

---
### 電源設定のサブ値を設定する

**要求**

次の要求形式を使用して、電源設定のサブ値を設定できます。
 
メソッド      | 要求 URI
:------     | :-----
POST | /api/power/cfg/*<power scheme path>*
<br />

**URI パラメーター**

次の追加パラメーターを要求 URI に指定できます。

URI パラメーター | 説明
:---          | :---
valueAC | (**必須**) AC 電源に使用する値。
valueDC | (**必須**) バッテリ電源に使用する値。
<br />
**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

**状態コード**

この API では次の状態コードが返される可能性があります。

HTTP 状態コード      | 説明
:------     | :-----
200 | OK
<br />
**利用可能なデバイス ファミリ**

* Windows Desktop
* IoT

---
### SleepStudy レポートを取得する

**要求**

メソッド      | 要求 URI
:------     | :-----
GET | /api/power/sleepstudy/report
<br />
次の要求形式を使用して、SleepStudy レポートを取得できます。

**URI パラメーター**
URI パラメーター | 説明
:---          | :---
FileName | (**必須**) ダウンロードするファイルの完全な名前。 この値は、hex64 エンコードされている必要があります。
<br />
**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

応答は、スリープ検査の結果が含まれているファイルです。 

**状態コード**

この API では次の状態コードが返される可能性があります。

HTTP 状態コード      | 説明
:------     | :-----
200 | OK
4XX | エラー コード
5XX | エラー コード
<br />
**利用可能なデバイス ファミリ**

* Windows Desktop
* IoT

---
### 利用可能な SleepStudy レポートを列挙する

**要求**

次の要求形式を使用して、利用可能な SleepStudy レポートを列挙できます。
 
メソッド      | 要求 URI
:------     | :-----
GET | /api/power/sleepstudy/reports
<br />

**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

利用可能なレポートの一覧のテンプレートは次のとおりです。

```
{"Reports": [
    {
        "FileName": string
    },...
]}
```

**状態コード**

この API では次の状態コードが返される可能性があります。

HTTP 状態コード      | 説明
:------     | :-----
200 | OK
4XX | エラー コード
5XX | エラー コード
<br />
**利用可能なデバイス ファミリ**

* Windows Desktop
* IoT

---
### スリープ スタディ変換を取得する

**要求**

次の要求形式を使用して、スリープ スタディ変換を取得できます。 この変換は、SleepStudy レポートを、ユーザーが読み取ることができる XML 形式に変換する XSLT です。
 
メソッド      | 要求 URI
:------     | :-----
GET | /api/power/sleepstudy/transform
<br />

**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

応答には、スリープ スタディ変換が含まれます。

**状態コード**

この API では次の状態コードが返される可能性があります。

HTTP 状態コード      | 説明
:------     | :-----
200 | OK
4XX | エラー コード
5XX | エラー コード
<br />
**利用可能なデバイス ファミリ**

* Windows Desktop
* IoT

---
## リモート制御
---
### ターゲット コンピューターを再起動する

**要求**

次の要求形式を使用して、ターゲット コンピューターを再起動できます。
 
メソッド      | 要求 URI
:------     | :-----
POST | /api/control/restart
<br />

**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

**状態コード**

この API では次の状態コードが返される可能性があります。

HTTP 状態コード      | 説明
:------     | :-----
200 | OK
<br />
**利用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* Xbox
* HoloLens
* IoT

---
### ターゲット コンピューターをシャットダウンする

**要求**

次の要求形式を使用して、ターゲット コンピューターをシャット ダウンできます。
 
メソッド      | 要求 URI
:------     | :-----
POST | /api/control/shutdown
<br />

**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

**状態コード**

この API では次の状態コードが返される可能性があります。

HTTP 状態コード      | 説明
:------     | :-----
200 | OK
4XX | エラー コード
5XX | エラー コード
<br />
**利用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* Xbox
* HoloLens
* IoT

---
## タスク マネージャー
---
### 最新のアプリを起動する

**要求**

次の要求形式を使用して、最新のアプリを起動できます。
 
メソッド      | 要求 URI
:------     | :-----
POST | /api/taskmanager/app
<br />

**URI パラメーター**

次の追加パラメーターを要求 URI に指定できます。

URI パラメーター | 説明
:---          | :---
appid   | (**必須**) 起動するアプリの PRAID。 この値は、hex64 エンコードされている必要があります。
package   | (**必須**) 起動するアプリ パッケージの完全な名前。 この値は、hex64 エンコードされている必要があります。
<br />
**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

**状態コード**

この API では次の状態コードが返される可能性があります。

HTTP 状態コード      | 説明
:------     | :-----
200 | OK
4XX | エラー コード
5XX | エラー コード
<br />
**利用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* Xbox
* HoloLens
* IoT

---
### 最新のアプリを停止する

**要求**

次の要求形式を使用して、最新のアプリを停止できます。
 
メソッド      | 要求 URI
:------     | :-----
DELETE | /api/taskmanager/app
<br />

**URI パラメーター**

次の追加パラメーターを要求 URI に指定できます。

URI パラメーター | 説明
:---          | :---
package   | (**必須**) 停止するアプリ パッケージの完全な名前。 この値は、hex64 エンコードされている必要があります。
forcestop   | (**オプション**) 値が **yes** の場合は、システムがすべてのプロセスを強制的に停止することを示します。
<br />
**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

**状態コード**

この API では次の状態コードが返される可能性があります。

HTTP 状態コード      | 説明
:------     | :-----
200 | OK
4XX | エラー コード
5XX | エラー コード
<br />
**利用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* Xbox
* HoloLens
* IoT

---
## Networking (ネットワーク)
---
### 現在の IP 構成を取得する

**要求**

次の要求形式を使用して、現在の IP 構成を取得できます。
 
メソッド      | 要求 URI
:------     | :-----
GET | /api/networking/ipconfig
<br />

**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

応答には、次のテンプレートの IP 構成が含まれます。

```
{"Adapters": [
    {
        "Description": string,
        "HardwareAddress": string,
        "Index": int,
        "Name": string,
        "Type": string,
        "DHCP": {
            "LeaseExpires": int, (timestamp)
            "LeaseObtained": int, (timestamp)
            "Address": {
                "IpAddress": string,
                "Mask": string
            }
        },
        "WINS": {(WINS is optional)
            "Primary": {
                "IpAddress": string,
                "Mask": string
            },
            "Secondary": {
                "IpAddress": string,
                "Mask": string
            }
        },
        "Gateways": [{ (always 1+)
            "IpAddress": "10.82.128.1",
            "Mask": "255.255.255.255"
            },...
        ],
        "IpAddresses": [{ (always 1+)
            "IpAddress": "10.82.128.148",
            "Mask": "255.255.255.0"
            },...
        ]
    },...
]}
```

**状態コード**

この API では次の状態コードが返される可能性があります。

HTTP 状態コード      | 説明
:------     | :-----
200 | OK
4XX | エラー コード
5XX | エラー コード
<br />
**利用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* Xbox
* HoloLens
* IoT

--
### ワイヤレス ネットワーク インターフェイスを列挙する

**要求**

次の要求形式を使用して、利用可能なワイヤレス ネットワーク インターフェイスを列挙できます。
 
メソッド      | 要求 URI
:------     | :-----
GET | /api/wifi/interfaces
<br />

**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

次の形式の利用可能なワイヤレス インターフェイスと詳細の一覧。

``` 
{"Interfaces": [{
    "Description": string,
    "GUID": string (guid with curly brackets),
    "Index": int,
    "ProfilesList": [
        {
            "GroupPolicyProfile": bool,
            "Name": string, (Network currently connected to)
            "PerUserProfile": bool
        },...
    ]
    }
]}
```

**状態コード**

この API では次の状態コードが返される可能性があります。

HTTP 状態コード      | 説明
:------     | :-----
200 | OK
4XX | エラー コード
5XX | エラー コード
<br />
**利用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* Xbox
* HoloLens
* IoT

---
### ワイヤレス ネットワークを列挙する

**要求**

次の要求形式を使用して、指定されたインターフェイスのワイヤレス ネットワークの一覧を列挙できます。
 
メソッド      | 要求 URI
:------     | :-----
GET | /api/wifi/networks
<br />

**URI パラメーター**

次の追加パラメーターを要求 URI に指定できます。

URI パラメーター | 説明
:---          | :---
interface   | (**必須**) ワイヤレス ネットワークの検索に使用するネットワーク インターフェイスの GUID (括弧は不要)。 
<br />
**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

指定された*インターフェイス*で見つかったワイヤレス ネットワークの一覧。 これには、ネットワークの詳細が次の形式で含まれます。

```
{"AvailableNetworks": [
    {
        "AlreadyConnected": bool,
        "AuthenticationAlgorithm": string, (WPA2, etc)
        "Channel": int,
        "CipherAlgorithm": string, (e.g. AES)
        "Connectable": int, (0 | 1)
        "InfrastructureType": string,
        "ProfileAvailable": bool,
        "ProfileName": string,
        "SSID": string,
        "SecurityEnabled": int, (0 | 1)
        "SignalQuality": int,
        "BSSID": [int,...],
        "PhysicalTypes": [string,...]
    },...
]}
```

**状態コード**

この API では次の状態コードが返される可能性があります。

HTTP 状態コード      | 説明
:------     | :-----
200 | OK
4XX | エラー コード
5XX | エラー コード
<br />
**利用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* Xbox
* HoloLens
* IoT

---
### Wi-Fi ネットワークを接続および切断する

**要求**

次の要求形式を使用して、Wi-Fi ネットワークを接続および切断できます。
 
メソッド      | 要求 URI
:------     | :-----
POST | /api/wifi/network
<br />

**URI パラメーター**

次の追加パラメーターを要求 URI に指定できます。

URI パラメーター | 説明
:---          | :---
interface   | (**必須**) ネットワークへの接続に使用するネットワーク インターフェイスの GUID。
op   | (**必須**) 実行するアクションを示します。 設定可能な値は、connect または disconnect です。
ssid   | (**op* == connect の場合は必須*) 接続先 SSID。
key   | (**op* == connect and network requires authentication の場合は必須*) 共有キー。
createprofile | (**必要**) デバイスでネットワークのプロファイルを作成します。  これにより、今後、デバイスはネットワークに自動接続されます。 **yes** または **no** を指定できます。 

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

**状態コード**

この API では次の状態コードが返される可能性があります。

HTTP 状態コード      | 説明
:------     | :-----
200 | OK
<br />
**利用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* Xbox
* HoloLens
* IoT

---
### Wi-Fi のプロファイルを削除する

**要求**

次の要求形式を使用して、特定のインターフェイス上のネットワークに関連付けられたプロファイルを削除できます。
 
メソッド      | 要求 URI
:------     | :-----
DELETE | /api/wifi/network
<br />

**URI パラメーター**

次の追加パラメーターを要求 URI に指定できます。

URI パラメーター | 説明
:---          | :---
interface   | (**必須**) 削除するプロファイルに関連付けられたネットワーク インターフェイスの GUID。
profile   | (**必須**) 削除するプロファイルの名前。
<br />
**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

**状態コード**

この API では次の状態コードが返される可能性があります。

HTTP 状態コード      | 説明
:------     | :-----
200 | OK
<br />
**利用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* Xbox
* HoloLens
* IoT

---
## Windows エラー報告 (WER)
---
### Windows エラー報告 (WER) ファイルをダウンロードする

**要求**

次の要求形式を使用して、WER 関連のファイルをダウンロードできます。
 
メソッド      | 要求 URI
:------     | :-----
GET | /api/wer/report/file
<br />

**URI パラメーター**

次の追加パラメーターを要求 URI に指定できます。

URI パラメーター | 説明
:---          | :---
user   | (**必須**) レポートに関連付けられたユーザー名。
type   | (**必須**) レポートの種類。 これは **queried** または **archived** のいずれかになります。
name   | (**必須**) レポートの名前。 base64 でエンコードされている必要があります。 
file   | (**必須**) レポートからダウンロードするファイルの名前。 base64 でエンコードされている必要があります。 
<br />
**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

- 応答には、要求したファイルが含まれています。 

**状態コード**

この API では次の状態コードが返される可能性があります。

HTTP 状態コード      | 説明
:------     | :-----
200 | OK
4XX | エラー コード
5XX | エラー コード
<br />
**利用可能なデバイス ファミリ**

* Windows Desktop
* HoloLens
* IoT

---
### Windows エラー報告 (WER) レポート内のファイルを列挙する

**要求**

次の要求形式を使用して、WER レポート内のファイルを列挙できます。
 
メソッド      | 要求 URI
:------     | :-----
GET | /api/wer/report/files
<br />

**URI パラメーター**

次の追加パラメーターを要求 URI に指定できます。

URI パラメーター | 説明
:---          | :---
user   | (**必須**) レポートに関連付けられたユーザー。
type   | (**必須**) レポートの種類。 これは **queried** または **archived** のいずれかになります。
name   | (**必須**) レポートの名前。 base64 でエンコードされている必要があります。 
<br />
**要求ヘッダー**

- なし

**要求本文**

```
{"Files": [
    {
        "Name": string, (Filename, not base64 encoded)
        "Size": int (bytes)
    },...
]}
```

**応答**

**状態コード**

この API では次の状態コードが返される可能性があります。

HTTP 状態コード      | 説明
:------     | :-----
200 | OK
4XX | エラー コード
5XX | エラー コード
<br />
**利用可能なデバイス ファミリ**

* Windows Desktop
* HoloLens
* IoT

---
### Windows エラー報告 (WER) レポートを一覧表示する

**要求**

次の要求形式を使用して、WER レポートを取得できます。
 
メソッド      | 要求 URI
:------     | :-----
GET | /api/wer/reports
<br />

**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

WER 報告の形式は次のとおりです。

```
{"WerReports": [
    {
        "User": string,
        "Reports": [
            {
                "CreationTime": int,
                "Name": string, (not base64 encoded)
                "Type": string ("Queue" or "Archive")
            },
    },...
]}
```

**状態コード**

この API では次の状態コードが返される可能性があります。

HTTP 状態コード      | 説明
:------     | :-----
200 | OK
4XX | エラー コード
5XX | エラー コード
<br />
**利用可能なデバイス ファミリ**

* Windows Desktop
* HoloLens
* IoT

---
## Windows Performance Recorder (WPR) 
---
### カスタム プロファイルを使用してトレースを開始する

**要求**

次の要求形式を使用して、WPR プロファイルをアップロードし、そのプロファイルを使用してトレースを開始できます。  一度に実行できるトレースは 1 つのみです。 プロファイルはデバイス上に残りません。 
 
メソッド      | 要求 URI
:------     | :-----
POST | /api/wpr/customtrace
<br />

**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**

- カスタム WPR プロファイルが含まれる、原則に従ったマルチパートの http 本文。

**応答**

WPR セッション状態の形式は次のとおりです。

```
{
    "SessionType": string, (Running or Idle) 
    "State": string (normal or boot)
}
```

**状態コード**

この API では次の状態コードが返される可能性があります。

HTTP 状態コード      | 説明
:------     | :-----
200 | OK
4XX | エラー コード
5XX | エラー コード
<br />
**利用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* HoloLens
* IoT

---
### 起動パフォーマンス トレース セッションを開始する

**要求**

次の要求形式を使用して、WPR の起動トレース セッションを開始できます。 これは、パフォーマンス トレース セッションとも呼びます。
 
メソッド      | 要求 URI
:------     | :-----
POST | /api/wpr/boottrace
<br />

**URI パラメーター**

次の追加パラメーターを要求 URI に指定できます。

URI パラメーター | 説明
:---          | :---
profile   | (**必須**) このパラメーターは起動時に必要です。 パフォーマンス トレース セッションを開始する必要があるプロファイルの名前。 指定可能なプロファイルは、perfprofiles/profiles.json に格納されています。
<br />
**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

この API は、開始時に次の形式で WPR セッション状態を返します。

```
{
    "SessionType": string, (Running or Idle) 
    "State": string (boot)
}
```

**状態コード**

この API では次の状態コードが返される可能性があります。

HTTP 状態コード      | 説明
:------     | :-----
200 | OK
4XX | エラー コード
5XX | エラー コード
<br />
**利用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* HoloLens
* IoT

---
### 起動パフォーマンス トレース セッションを停止する

**要求**

次の要求形式を使用して、WPR の起動トレース セッションを停止できます。 これは、パフォーマンス トレース セッションとも呼びます。
 
メソッド      | 要求 URI
:------     | :-----
GET | /api/wpr/boottrace
<br />

**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

- トレース ETL ファイルを返します。

**状態コード**

この API では次の状態コードが返される可能性があります。

HTTP 状態コード      | 説明
:------     | :-----
200 | OK
4XX | エラー コード
5XX | エラー コード
<br />
**利用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* HoloLens
* IoT

---
### パフォーマンス トレース セッションを開始する

**要求**

次の要求形式を使用して、WPR のトレース セッションを開始できます。 これは、パフォーマンス トレース セッションとも呼びます。  一度に実行できるトレースは 1 つのみです。 
 
メソッド      | 要求 URI
:------     | :-----
POST | /api/wpr/trace
<br />

**URI パラメーター**

次の追加パラメーターを要求 URI に指定できます。

URI パラメーター | 説明
:---          | :---
profile   | (**必須**) パフォーマンス トレース セッションを開始する必要があるプロファイルの名前。 指定可能なプロファイルは、perfprofiles/profiles.json に格納されています。
<br />
**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

この API は、開始時に次の形式で WPR セッション状態を返します。

```
{
    "SessionType": string, (Running or Idle) 
    "State": string (normal)
}
```

**状態コード**

この API では次の状態コードが返される可能性があります。

HTTP 状態コード      | 説明
:------     | :-----
200 | OK
4XX | エラー コード
5XX | エラー コード
<br />
**利用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* HoloLens
* IoT

---
### パフォーマンスのトレース セッションを停止する

**要求**

次の要求形式を使用して、WPR のトレース セッションを停止できます。 これは、パフォーマンス トレース セッションとも呼びます。
 
メソッド      | 要求 URI
:------     | :-----
GET | /api/wpr/trace
<br />

**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

- なし。  **注:** これは時間のかかる処理です。  ETL のディスクへの書き込みが終了すると、制御が戻ります。  

**状態コード**

この API では次の状態コードが返される可能性があります。

HTTP 状態コード      | 説明
:------     | :-----
200 | OK
4XX | エラー コード
5XX | エラー コード
<br />
**利用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* HoloLens
* IoT

---
### トレース セッションの状態を取得する

**要求**

次の要求形式を使用して、現在の WPR セッションの状態を取得できます。
 
メソッド      | 要求 URI
:------     | :-----
GET | /api/wpr/status
<br />

**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

WPR トレース セッションの状態の形式は次のとおりです。

```
{
    "SessionType": string, (Running or Idle) 
    "State": string (normal or boot)
}
```

**状態コード**

この API では次の状態コードが返される可能性があります。

HTTP 状態コード      | 説明
:------     | :-----
200 | OK
4XX | エラー コード
5XX | エラー コード
<br />
**利用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* HoloLens
* IoT

---
### 完了したトレース セッション (ETL) を一覧表示する

**要求**

次の要求形式を使用して、デバイス上の ETL トレースの一覧を取得できます。 

メソッド      | 要求 URI
:------     | :-----
GET | /api/wpr/tracefiles
<br />

**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

完了したトレース セッションの一覧は次の形式で提供されます。

```
{"Items": [{
    "CurrentDir": string (filepath),
    "DateCreated": int (File CreationTime),
    "FileSize": int (bytes),
    "Id": string (filename),
    "Name": string (filename),
    "SubPath": string (filepath),
    "Type": int
}]}
```

**状態コード**

この API では次の状態コードが返される可能性があります。

HTTP 状態コード      | 説明
:------     | :-----
200 | OK
4XX | エラー コード
5XX | エラー コード
<br />
**利用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* HoloLens
* IoT

---
### トレース セッション (ETL) をダウンロードする

**要求**

次の要求形式を使用して、トレースファイル (ブート トレースまたはユーザー モード トレース) をダウンロードできます。 

メソッド      | 要求 URI
:------     | :-----
GET | /api/wpr/tracefile
<br />

**URI パラメーター**

次の追加パラメーターを要求 URI に指定できます。

URI パラメーター | 説明
:---          | :---
filename   | (**必須**) ダウンロードする ETL トレースの名前。  これらは /api/wpr/tracefiles にあります。

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

- トレース ETL ファイルを返します。

**状態コード**

この API では次の状態コードが返される可能性があります。

HTTP 状態コード      | 説明
:------     | :-----
200 | OK
4XX | エラー コード
5XX | エラー コード
<br />
**利用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* HoloLens
* IoT

---
### トレース セッション (ETL) を削除する

**要求**

次の要求形式を使用して、トレースファイル (ブート トレースまたはユーザー モード トレース) を削除できます。 

メソッド      | 要求 URI
:------     | :-----
DELETE | /api/wpr/tracefile
<br />

**URI パラメーター**

次の追加パラメーターを要求 URI に指定できます。

URI パラメーター | 説明
:---          | :---
filename   | (**必須**) 削除する ETL トレースの名前。  これらは /api/wpr/tracefiles にあります。

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

- トレース ETL ファイルを返します。

**状態コード**

この API では次の状態コードが返される可能性があります。

HTTP 状態コード      | 説明
:------     | :-----
200 | OK
4XX | エラー コード
5XX | エラー コード
<br />
**利用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* HoloLens
* IoT

---
## DNS SD タグ 
---
### タグを表示する

**要求**

デバイスに現在適用されているタグを表示します。  これらのタグは、T キー内の DNS-SD TXT レコードを使用してアドバタイズされます。  
 
メソッド      | 要求 URI
:------     | :-----
GET | /api/dns-sd/tags
<br />

**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答** 現在適用されているタグの形式は次のとおりです。 
```
 {
    "tags": [
        "tag1", 
        "tag2", 
        ...
     ]
}
```

**状態コード**

この API では次の状態コードが返される可能性があります。

HTTP 状態コード      | 説明
:------     | :-----
200 | OK
5XX | サーバー エラー 

<br />
**利用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* Xbox
* HoloLens
* IoT

---
### タグを削除する

**要求**

DNS-SD によって現在アドバタイズされているすべてのタグを削除します。   
 
メソッド      | 要求 URI
:------     | :-----
DELETE | /api/dns-sd/tags
<br />

**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**
 - なし

**状態コード**

この API では次の状態コードが返される可能性があります。

HTTP 状態コード      | 説明
:------     | :-----
200 | OK
5XX | サーバー エラー 

<br />
**利用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* Xbox
* HoloLens
* IoT

---
### タグを削除する

**要求**

DNS-SD によって現在アドバタイズされている 1 つのタグを削除します。   
 
メソッド      | 要求 URI
:------     | :-----
DELETE | /api/dns-sd/tag
<br />

**URI パラメーター**

URI パラメーター | 説明
:------     | :-----
tagValue | (**必須**) 削除するタグ。

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**
 - なし

**状態コード**

この API では次の状態コードが返される可能性があります。

HTTP 状態コード      | 説明
:------     | :-----
200 | OK

<br />
**利用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* Xbox
* HoloLens
* IoT
 
---
### タグを追加する

**要求**

DNS-SD アドバタイズにタグを追加します。   
 
メソッド      | 要求 URI
:------     | :-----
POST | /api/dns-sd/tag
<br />

**URI パラメーター**

URI パラメーター | 説明
:------     | :-----
tagValue | (**必要**) 追加するタグ。

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**
 - なし

**状態コード**

この API では次の状態コードが返される可能性があります。

HTTP 状態コード      | 説明
:------     | :-----
200 | OK
401 | タグ領域のオーバーフロー。  提供されたタグが、結果として生成される DNS-SD サービス レコードに対して長すぎます。  

<br />
**利用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* Xbox
* HoloLens
* IoT

## アプリのエクスプローラー

---
### 既知のフォルダーを取得する

**要求**

アクセス可能なトップ レベル フォルダーの一覧を取得します。

メソッド      | 要求 URI
:------     | :-----
GET | /api/filesystem/apps/knownfolders
<br />

**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答** 利用可能なフォルダーの形式は次のとおりです。 
```
 {"KnownFolders": [
    "folder0",
    "folder1",...
]}
```
**状態コード**

この API では次の状態コードが返される可能性があります。

HTTP 状態コード      | 説明
:------     | :-----
200 | 展開要求は受け入れられ、処理されています。
4XX | エラー コード
5XX | エラー コード
<br />

**利用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* HoloLens
* Xbox
* IoT

---
### ファイルを取得する

**要求**

フォルダー内のファイルの一覧を取得します。

メソッド      | 要求 URI
:------     | :-----
GET | /api/filesystem/apps/files
<br />

**URI パラメーター**

URI パラメーター | 説明
:------     | :-----
knownfolderid | (**必須**) 必要なファイルの一覧の対象となるトップレベル ディレクトリ。 サイドロードされたアプリにアクセスするには、**LocalAppData** を使用します。 
packagefullname | (*knownfolderid* == *LocalAppData の場合は必須*) 対象となるアプリのパッケージのフルネーム。 
path | (**オプション**) 上で指定したフォルダーまたはパッケージ内のサブディレクトリ。 

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答** 利用可能なフォルダーの形式は次のとおりです。 
```
{"Items": [
    {
        "CurrentDir": string (folder under the requested known folder),
        "DateCreated": int,
        "FileSize": int (bytes),
        "Id": string,
        "Name": string,
        "SubPath": string (present if this item is a folder, this is the name of the folder),
        "Type": int
    },...
]}
```
**状態コード**

この API では次の状態コードが返される可能性があります。

HTTP 状態コード      | 説明
:------     | :-----
200 | OK
4XX | エラー コード
5XX | エラー コード
<br />
**利用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* HoloLens
* Xbox
* IoT

---
### ファイルをダウンロードする

**要求**

既知のフォルダーまたは appLocalData からファイルを取得します。

メソッド      | 要求 URI
:------     | :-----
GET | /api/filesystem/apps/file

**URI パラメーター**

URI パラメーター | 説明
:------     | :-----
knownfolderid | (**必須**) ファイルをダウンロードするトップレベル ディレクトリ。 サイドロードされたアプリにアクセスするには、**LocalAppData** を使用します。 
filename | (**必須**) ダウンロードするファイルの名前。 
packagefullname | (*knownfolderid* == *LocalAppData の場合は必須*) 対象となるパッケージのフルネーム。 
path | (**オプション**) 上で指定したフォルダーまたはパッケージ内のサブディレクトリ。

**要求ヘッダー**

- なし

**要求本文**

- 要求するファイル (存在する場合)

**応答**

**状態コード**

この API では次の状態コードが返される可能性があります。

HTTP 状態コード      | 説明
:------     | :-----
200 | 要求したファイル
404 | ファイルが見つかりません
5XX | エラー コード
<br />
**利用可能なデバイス ファミリ**

* Windows Mobile
* Windows デスクトップ
* HoloLens
* Xbox
* IoT

---
### ファイルの名前の変更

**要求**

フォルダー内のファイルの名前を変更します。

メソッド      | 要求 URI
:------     | :-----
POST | /api/filesystem/apps/rename

<br />
**URI パラメーター**

URI パラメーター | 説明
:------     | :-----
knownfolderid | (**必須**) ファイルが存在するトップレベル ディレクトリ。 サイドロードされたアプリにアクセスするには、**LocalAppData** を使用します。 
filename | (**必須**) 名前を変更するファイルの元の名前。 
newfilename | (**必須**) ファイルの新しい名前。
packagefullname | (*knownfolderid* == *LocalAppData の場合は必須*) 対象となるアプリのパッケージのフルネーム。 
path | (**オプション**) 上で指定したフォルダーまたはパッケージ内のサブディレクトリ。 

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

- なし

**状態コード**

この API では次の状態コードが返される可能性があります。

HTTP 状態コード      | 説明
:------     | :-----
200 | OK。 ファイルの名前が変更されました
404 | ファイルが見つかりません
5XX | エラー コード
<br />
**利用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* HoloLens
* Xbox
* IoT

---
### ファイルを削除する

**要求**

フォルダー内のファイルを削除します。

メソッド      | 要求 URI
:------     | :-----
DELETE | /api/filesystem/apps/file
<br />
**URI パラメーター**

URI パラメーター | 説明
:------     | :-----
knownfolderid | (**必須**) ファイルを削除するトップレベル ディレクトリ。 サイドロードされたアプリにアクセスするには、**LocalAppData** を使用します。 
filename | (**必須**) 削除するファイルの名前。 
packagefullname | (*knownfolderid* == *LocalAppData の場合は必須*) 対象となるアプリのパッケージのフルネーム。 
path | (**オプション**) 上で指定したフォルダーまたはパッケージ内のサブディレクトリ。

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

- なし 

**状態コード**

この API では次の状態コードが返される可能性があります。

HTTP 状態コード      | 説明
:------     | :-----
200 | OK。 ファイルが削除されます。
404 | ファイルが見つかりません
5XX | エラー コード
<br />
**利用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* HoloLens
* Xbox
* IoT

---
### ファイルをアップロードする

**要求**

フォルダーにファイルをアップロードします。  この場合、同じ名前を持つ既存のファイルは上書きされますが、新しいフォルダーは作成されません。 

メソッド      | 要求 URI
:------     | :-----
POST | /api/filesystem/apps/file
<br />
**URI パラメーター**

URI パラメーター | 説明
:------     | :-----
knownfolderid | (**必須**) ファイルをアップロードするトップレベル ディレクトリ。 サイドロードされたアプリにアクセスするには、**LocalAppData** を使用します。
packagefullname | (*knownfolderid* == *LocalAppData の場合は必須*) 対象となるアプリのパッケージのフルネーム。 
path | (**オプション**) 上で指定したフォルダーまたはパッケージ内のサブディレクトリ。

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

**状態コード**

この API では次の状態コードが返される可能性があります。

HTTP 状態コード      | 説明
:------     | :-----
200 | OK。 ファイルがアップロードされます。
4XX | エラー コード
5XX | エラー コード
<br />
**利用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* HoloLens
* Xbox
* IoT



<!--HONumber=Aug16_HO3-->


