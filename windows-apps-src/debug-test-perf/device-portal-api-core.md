---
ms.assetid: bfabd3d5-dd56-4917-9572-f3ba0de4f8c0
title: デバイス ポータル コア API リファレンス
description: Windows Device Portal コア REST API について説明します。これによって、データにアクセスし、プログラムを使ってデバイスを制御することが可能になります。
ms.custom: 19H1
ms.date: 04/19/2019
ms.topic: article
keywords: windows 10、uwp、デバイス ポータル
ms.localizationpriority: medium
ms.openlocfilehash: 910e3108009704d444fb81b195f9dd9eae3daa9d
ms.sourcegitcommit: fca0132794ec187e90b2ebdad862f22d9f6c0db8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/24/2019
ms.locfileid: "63798183"
---
# <a name="device-portal-core-api-reference"></a>デバイス ポータル コア API リファレンス

デバイス ポータルのすべての機能は、REST API の上に構築されています。開発者は REST API を直接呼び出して、プログラムからリソースにアクセスし、デバイスを制御することができます。

## <a name="app-deployment"></a>アプリの展開

### <a name="install-an-app"></a>アプリをインストールする

**要求**

次の要求形式を使用して、アプリをインストールできます。

| メソッド      | 要求 URI |
| :------     | :----- |
| POST | /api/app/packagemanager/package |

**URI パラメーター**

次の追加パラメーターを要求 URI に指定できます。

| URI パラメーター | 説明 |
| :------          | :------ |
| パッケージ (package)   | (**必須**) インストールするパッケージのファイル名。 |

**要求ヘッダー**

- なし

**要求本文**

- .appx または .appxbundle ファイル、およびアプリが必要とする依存関係。 
- デバイスが IoT または Windows デスクトップの場合、アプリの署名に使う証明書。 その他のプラットフォームでは、証明書は必要ありません。 

**応答**

**状態コード**

この API では次の状態コードが返される可能性があります。

|  HTTP 状態コード      | 説明 | 
| :------     | :----- |
| 200 | 展開要求は受け入れられ、処理されています。 |
| 4XX | エラー コード |
| 5XX | エラー コード |

**使用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* Xbox
* HoloLens
* IoT

<hr>

### <a name="install-a-related-set"></a>関連セットをインストールする

**要求**

次の要求形式を使用して、[関連セット](https://blogs.msdn.microsoft.com/appinstaller/2017/05/12/tooling-to-create-a-related-set/)をインストールできます。

| メソッド      | 要求 URI |
| :------     | :------ |
| POST | /api/app/packagemanager/package |

**URI パラメーター**

次の追加パラメーターを要求 URI に指定できます。

| URI パラメーター | 説明 |
| :------          | :------ |
| パッケージ (package)   | (**必須**) インストールするパッケージのファイル名。 |

**要求ヘッダー**

- なし

**要求本文** 
- オプション パッケージをパラメーターとして指定するときは、"foo.appx.opt"、"bar.appxbundle.opt" などのようにパッケージのファイル名に ".opt" を追加します。 
- .appx または .appxbundle ファイル、およびアプリが必要とする依存関係。 
- デバイスが IoT または Windows デスクトップの場合、アプリの署名に使う証明書。 その他のプラットフォームでは、証明書は必要ありません。 

**応答**

**状態コード**

この API では次の状態コードが返される可能性があります。

|  HTTP 状態コード      | 説明 | 
| :------     | :----- |
| 200 | 展開要求は受け入れられ、処理されています。 |
| 4XX | エラー コード |
| 5XX | エラー コード |

**使用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* Xbox
* HoloLens
* IoT

<hr>

### <a name="register-an-app-in-a-loose-folder"></a>アプリをルース フォルダーに登録する

**要求**

次の要求形式を使用して、アプリをルース フォルダーに登録できます。

| メソッド      | 要求 URI |
| :------     | :----- |
| POST | /api/app/packagemanager/networkapp |

**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**

```json
{
    "mainpackage" :
    {
        "networkshare" : "\\some\share\path",
        "username" : "optional_username",
        "password" : "optional_password"
    }
}
```

**応答**

**状態コード**

この API では次の状態コードが返される可能性があります。

|  HTTP 状態コード      | 説明 | 
| :------     | :----- |
| 200 | 展開要求は受け入れられ、処理されています。 |
| 4XX | エラー コード |
| 5XX | エラー コード |

**使用可能なデバイス ファミリ**

* Windows Desktop
* Xbox
* HoloLens
* IoT

<hr>

### <a name="register-a-related-set-in-loose-file-folders"></a>関連セットをルース ファイル フォルダーに登録する

**要求**

次の要求形式を使用して、[関連セット](https://blogs.msdn.microsoft.com/appinstaller/2017/05/12/tooling-to-create-a-related-set/)をルース フォルダーに登録できます。

| メソッド      | 要求 URI |
| :------     | :----- |
| POST | /api/app/packagemanager/networkapp |

**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**

```json
{
    "mainpackage" :
    {
        "networkshare" : "\\some\share\path",
        "username" : "optional_username",
        "password" : "optional_password"
    },
    "optionalpackages" :
    [
        {
            "networkshare" : "\\some\share\path2",
            "username" : "optional_username2",
            "password" : "optional_password2"
        },
        ...
    ]
}
```

**応答**

**状態コード**

この API では次の状態コードが返される可能性があります。

|  HTTP 状態コード      | 説明 | 
| :------     | :----- |
| 200 | 展開要求は受け入れられ、処理されています。 |
| 4XX | エラー コード |
| 5XX | エラー コード |

**使用可能なデバイス ファミリ**

* Windows Desktop
* Xbox
* HoloLens
* IoT

<hr>

### <a name="get-app-installation-status"></a>アプリのインストール状態を取得する

**要求**

次の要求形式を使用して、現在進行中のアプリのインストールの状態を取得できます。
 
| メソッド      | 要求 URI |
| :------     | :----- |
| GET | /api/app/packagemanager/state |

**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

**状態コード**

この API では次の状態コードが返される可能性があります。

|  HTTP 状態コード      | 説明 | 
| :------     | :----- |
| 200 | 最後の展開の結果 |
| 204 | インストールは実行中です |
| 404 | インストール操作は見つかりませんでした |

**使用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* Xbox
* HoloLens
* IoT

<hr>

### <a name="uninstall-an-app"></a>アプリをアンインストールする

**要求**

次の要求形式を使用して、アプリをアンインストールできます。
 
| メソッド      | 要求 URI |
| :------     | :----- |
| Del | /api/app/packagemanager/package |

**URI パラメーター**

| URI パラメーター | 説明 |
| :------          | :------ |
| パッケージ (package)   | (**必須**) ターゲット アプリの PackageFullName (GET /api/app/packagemanager/packages から) |

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

**状態コード**

この API では次の状態コードが返される可能性があります。

|  HTTP 状態コード      | 説明 | 
| :------     | :----- |
|  200 | OK | 
| 4XX | エラー コード |
| 5XX | エラー コード |

**使用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* Xbox
* HoloLens
* IoT

<hr>

### <a name="get-installed-apps"></a>インストールされたアプリを取得する

**要求**

次の要求形式を使用して、システムにインストールされているアプリの一覧を取得できます。
 
| メソッド      | 要求 URI |
| :------     | :----- |
| GET | /api/app/packagemanager/packages |


**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

応答には、インストールされているパッケージの一覧と関連する詳細情報が含まれます。 この応答のテンプレートは次のとおりです。
```json
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

|  HTTP 状態コード      | 説明 | 
| :------     | :----- |
|  200 | OK | 
| 4XX | エラー コード |
| 5XX | エラー コード |

**使用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* Xbox
* HoloLens
* IoT

<hr>

## <a name="bluetooth"></a>Bluetooth

<hr>

### <a name="get-the-bluetooth-radios-on-the-machine"></a>コンピューターの Bluetooth 無線を取得する

**要求**

次の要求形式を使用して、コンピューターにインストールされている Bluetooth 無線の一覧を取得できます。 これは、同じ JSON データを同様に、WebSocket 接続にアップグレードできます。
 
| メソッド        | 要求 URI |
| :------          | :------ |
| GET           | /api/bt/getradios |
| GET/WebSocket | /api/bt/getradios |


**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

応答には、デバイスにアタッチされている Bluetooth 無線の JSON 配列が含まれます。
```json
{"BluetoothRadios" : [
    {
        "BluetoothAddress" : int64,
        "DisplayName" : string,
        "HasUnknownUsbDevice" : boolean,
        "HasProblem" : boolean,
        "ID" : string,
        "ProblemCode" : int,
        "State" : string
    },...
]}
```
**状態コード**

この API では次の状態コードが返される可能性があります。

| HTTP 状態コード | 説明 |
| :------             | :------ |
| 200              | OK |
| 4XX              | エラー コード |
| 5XX              | エラー コード |

**使用可能なデバイス ファミリ**

* Windows Desktop
* HoloLens
* IoT

<hr>

### <a name="turn-the-bluetooth-radio-on-or-off"></a>Bluetooth 無線をオンまたはオフにします。

**要求**

特定の Bluetooth 無線をオンまたはオフに設定します。
 
| メソッド | 要求 URI |
| :------   | :------ |
| POST   | /api/bt/setradio |

**URI パラメーター**

次の追加パラメーターを要求 URI に指定できます。

| URI パラメーター | 説明 |
| :------          | :------ |
| ID            | (**必須**) Bluetooth 無線のデバイス ID であり、base 64 でエンコードされている必要があります。 |
| 状態         | (**必要**) これは、`"On"`または`"Off"`します。 |

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

**状態コード**

この API では次の状態コードが返される可能性があります。

| HTTP 状態コード | 説明 |
| :------             | :------ |
| 200              | OK |
| 4XX              | エラー コード |
| 5XX              | エラー コード |

**使用可能なデバイス ファミリ**

* Windows Desktop
* HoloLens
* IoT

---
### <a name="get-a-list-of-paired-bluetooth-devices"></a>ペアリングされた Bluetooth デバイスの一覧を取得します。

**要求**

次の要求形式を使用して、ペアになっている現在の Bluetooth デバイスの一覧を取得できます。 これは、同じ JSON データで WebSocket 接続にアップグレードできます。 WebSocket 接続の有効期間中、デバイスの一覧を変更できます。 デバイスの完全な一覧は、更新プログラムがあるたびに WebSocket 接続経由で送信されます。

| メソッド        | 要求 URI       |
| :---          | :---              |
| GET           | /api/bt/getpaired |
| GET/WebSocket | /api/bt/getpaired |

**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

応答には、現在はペアになっている Bluetooth デバイスの JSON 配列が含まれています。
```json
{"PairedDevices": [
    {
        "Name" : string,
        "ID" : string,
        "AudioConnectionStatus" : string
    },...
]}
```
*AudioConnectionStatus*フィールドが存在するは、このシステムでのオーディオ デバイスを使用できる場合になります。 (ポリシーと省略可能なコンポーネントが影響。)*AudioConnectionStatus* 「接続済み」または「切断」のいずれかになります。

---
### <a name="get-a-list-of-available-bluetooth-devices"></a>使用可能な Bluetooth デバイスの一覧を取得します。

**要求**

次の要求形式を使用してペアリングの Bluetooth デバイスの一覧を取得することができます。 これは、同じ JSON データで WebSocket 接続にアップグレードできます。 WebSocket 接続の有効期間中、デバイスの一覧を変更できます。 デバイスの完全な一覧は、更新プログラムがあるたびに WebSocket 接続経由で送信されます。

| メソッド        | 要求 URI          |
| :---          | :---                 |
| GET           | /api/bt/getavailable |
| GET/WebSocket | /api/bt/getavailable |

**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

応答には、ペアリングには現在使用できる Bluetooth デバイスの JSON 配列が含まれています。
```json
{"AvailableDevices": [
    {
        "Name" : string,
        "ID" : string
    },...
]}
```

---
### <a name="connect-a-bluetooth-device"></a>Bluetooth デバイスを接続します。

**要求**

このシステムでのオーディオ デバイスを使用できる場合、デバイスに接続されます。 (ポリシーと省略可能なコンポーネントが影響。)

| メソッド       | 要求 URI           |
| :---         | :---                  |
| POST         | /api/bt/connectdevice |

**URI パラメーター**

| URI パラメーター | 説明 |
| :---          | :--- |
| ID            | (**必要**)、Bluetooth デバイスの関連付けのエンドポイント ID と Base64 でエンコードする必要があります。 |

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

**状態コード**

この API では次の状態コードが返される可能性があります。

| HTTP 状態コード | 説明 |
| :---             | :--- |
| 200              | OK |
| 4XX              | エラー コード |
| 5XX              | エラー コード |

**使用可能なデバイス ファミリ**

* Windows Desktop
* HoloLens
* IoT


---
### <a name="disconnect-a-bluetooth-device"></a>Bluetooth デバイスを切断します。

**要求**

このシステムでのオーディオ デバイスを使用できる場合、デバイスが切断されます。 (ポリシーと省略可能なコンポーネントが影響。)

| メソッド       | 要求 URI              |
| :---         | :---                     |
| POST         | /api/bt/disconnectdevice |

**URI パラメーター**

| URI パラメーター | 説明 |
| :---          | :--- |
| ID            | (**必要**)、Bluetooth デバイスの関連付けのエンドポイント ID と Base64 でエンコードする必要があります。 |

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

**状態コード**

この API では次の状態コードが返される可能性があります。

| HTTP 状態コード | 説明 |
| :---             | :--- |
| 200              | OK |
| 4XX              | エラー コード |
| 5XX              | エラー コード |

**使用可能なデバイス ファミリ**

* Windows Desktop
* HoloLens
* IoT

---
## <a name="device-manager"></a>デバイス マネージャー
<hr>

### <a name="get-the-installed-devices-on-the-machine"></a>コンピューターにインストールされているデバイスを取得する

**要求**

次の要求形式を使用して、コンピューターにインストールされているデバイスの一覧を取得できます。

| メソッド      | 要求 URI |
| :------     | :----- |
| GET | /api/devicemanager/devices |

**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

応答には、デバイスにアタッチされているデバイスの JSON 配列が含まれます。
```json
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

|  HTTP 状態コード      | 説明 | 
| :------     | :----- |
|  200 | OK | 
| 4XX | エラー コード |
| 5XX | エラー コード |

**使用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* IoT

<hr>

### <a name="get-data-on-connected-usb-deviceshubs"></a>接続された USB デバイス/ハブのデータを取得する

**要求**

次の要求形式を使用して、接続された USB デバイスおよびハブの USB 記述子の一覧を取得できます。

| メソッド      | 要求 URI |
| :------     | :----- |
| GET | /ext/devices/usbdevices |


**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

応答は、ハブの USB 記述子およびポート情報と共に、USB デバイスのデバイス ID が含まれる JSON です。
```json
{
    "DeviceList": [
        {
        "ID": string,
        "ParentID": string, // Will equal an "ID" within the list, or be blank
        "Description": string, // optional
        "Manufacturer": string, // optional
        "ProblemCode": int, // optional
        "StatusCode": int // optional
        },
        ...
    ]
}
```

**サンプル データを返す**
```json
{
    "DeviceList": [{
        "ID": "System",
        "ParentID": ""
    }, {
        "Class": "USB",
        "Description": "Texas Instruments USB 3.0 xHCI Host Controller",
        "ID": "PCI\\VEN_104C&DEV_8241&SUBSYS_1589103C&REV_02\\4&37085792&0&00E7",
        "Manufacturer": "Texas Instruments",
        "ParentID": "System",
        "ProblemCode": 0,
        "StatusCode": 25174026
    }, {
        "Class": "USB",
        "Description": "USB Composite Device",
        "DeviceDriverKey": "{36fc9e60-c465-11cf-8056-444553540000}\\0016",
        "ID": "USB\\VID_045E&PID_00DB\\8&2994096B&0&1",
        "Manufacturer": "(Standard USB Host Controller)",
        "ParentID": "USB\\VID_0557&PID_8021\\7&2E9A8711&0&4",
        "ProblemCode": 0,
        "StatusCode": 25182218
    }]
}
```

**状態コード**

この API では次の状態コードが返される可能性があります。

|  HTTP 状態コード      | 説明 | 
| :------     | :----- |
|  200 | OK | 
| 5XX | エラー コード |

**使用可能なデバイス ファミリ**

* Windows Desktop
* IoT

<hr>

## <a name="dump-collection"></a>ダンプの収集

<hr>

### <a name="get-the-list-of-all-crash-dumps-for-apps"></a>アプリのすべてのクラッシュ ダンプの一覧を取得する

**要求**

次の要求形式を使用して、サイドローディングされたすべてのアプリについて、利用可能なすべてのクラッシュ ダンプの一覧を取得できます。
 
| メソッド      | 要求 URI |
| :------     | :----- |
| GET | /api/debug/dump/usermode/dumps |


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

|  HTTP 状態コード      | 説明 | 
| :------     | :----- |
|  200 | OK | 
| 4XX | エラー コード |
| 5XX | エラー コード |

**使用可能なデバイス ファミリ**

* Window Mobile (Windows Insider Program のみ)
* Windows Desktop
* HoloLens
* IoT

<hr>

### <a name="get-the-crash-dump-collection-settings-for-an-app"></a>アプリのクラッシュ ダンプ収集設定を取得する

**要求**

次の要求形式を使用して、サイドローディングされたアプリのクラッシュ ダンプ収集設定を取得できます。
 
| メソッド      | 要求 URI |
| :------     | :----- |
| GET | /api/debug/dump/usermode/crashcontrol |


**URI パラメーター**

次の追加パラメーターを要求 URI に指定できます。

| URI パラメーター | 説明 |
| :------          | :------ |
| packageFullname   | (**必須**) サイドローディングされたアプリのパッケージの完全な名前。 |

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

応答は、次の形式になります。
```json
{"CrashDumpEnabled": bool}
```

**状態コード**

この API では次の状態コードが返される可能性があります。

|  HTTP 状態コード      | 説明 | 
| :------     | :----- |
|  200 | OK | 
| 4XX | エラー コード |
| 5XX | エラー コード |

**使用可能なデバイス ファミリ**

* Window Mobile (Windows Insider Program のみ)
* Windows Desktop
* HoloLens
* IoT

<hr>

### <a name="delete-a-crash-dump-for-a-sideloaded-app"></a>サイドローディングされたアプリのクラッシュ ダンプを削除する

**要求**

次の要求形式を使用して、サイドローディングされたアプリのクラッシュ ダンプを削除できます。
 
| メソッド      | 要求 URI |
| :------     | :----- |
| Del | /api/debug/dump/usermode/crashdump |


**URI パラメーター**

次の追加パラメーターを要求 URI に指定できます。

| URI パラメーター | 説明 |
| :---          | :--- |
| packageFullname   | (**必須**) サイドローディングされたアプリのパッケージの完全な名前。 |
| fileName   | (**必須**) 削除する必要があるダンプ ファイルの名前。 |

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

**状態コード**

この API では次の状態コードが返される可能性があります。

|  HTTP 状態コード      | 説明 | 
| :------     | :----- |
|  200 | OK | 
| 4XX | エラー コード |
| 5XX | エラー コード |

**使用可能なデバイス ファミリ**

* Window Mobile (Windows Insider Program のみ)
* Windows Desktop
* HoloLens
* IoT

<hr>

### <a name="disable-crash-dumps-for-a-sideloaded-app"></a>サイドローディングされたアプリのクラッシュ ダンプを無効にする

**要求**

次の要求形式を使用して、サイドローディングされたアプリのクラッシュ ダンプを無効にすることができます。
 
| メソッド      | 要求 URI |
| :------     | :----- |
| Del | /api/debug/dump/usermode/crashcontrol |


**URI パラメーター**

次の追加パラメーターを要求 URI に指定できます。

| URI パラメーター | 説明 |
| :---          | :--- |
| packageFullname   | (**必須**) サイドローディングされたアプリのパッケージの完全な名前。 |

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

**状態コード**

この API では次の状態コードが返される可能性があります。

|  HTTP 状態コード      | 説明 | 
| :------     | :----- |
|  200 | OK | 
| 4XX | エラー コード |
| 5XX | エラー コード |

**使用可能なデバイス ファミリ**

* Window Mobile (Windows Insider Program のみ)
* Windows Desktop
* HoloLens
* IoT

<hr>

### <a name="download-the-crash-dump-for-a-sideloaded-app"></a>サイドローディングされたアプリのクラッシュ ダンプをダウンロードする

**要求**

次の要求形式を使用して、サイドローディングされたアプリのクラッシュ ダンプをダウンロードできます。
 
| メソッド      | 要求 URI |
| :------     | :----- |
| GET | /api/debug/dump/usermode/crashdump |


**URI パラメーター**

次の追加パラメーターを要求 URI に指定できます。

| URI パラメーター | 説明 |
| :------          | :------ |
| packageFullname   | (**必須**) サイドローディングされたアプリのパッケージの完全な名前。 |
| fileName   | (**必須**) ダウンロードするダンプ ファイルの名前。 |

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

応答には、ダンプ ファイルが含まれます。 WinDbg または Visual Studio を使用して、ダンプ ファイルを検証できます。

**状態コード**

この API では次の状態コードが返される可能性があります。

| HTTP 状態コード      | 説明 |
| :------     | :----- |
|  200 | OK | 
| 4XX | エラー コード |
| 5XX | エラー コード |

**使用可能なデバイス ファミリ**

* Window Mobile (Windows Insider Program のみ)
* Windows Desktop
* HoloLens
* IoT

<hr>

### <a name="enable-crash-dumps-for-a-sideloaded-app"></a>サイドローディングされたアプリのクラッシュ ダンプを有効にする

**要求**

次の要求形式を使用して、サイドローディングされたアプリのクラッシュ ダンプを有効にすることができます。
 
| メソッド      | 要求 URI |
| :------     | :----- |
| POST | /api/debug/dump/usermode/crashcontrol |


**URI パラメーター**

次の追加パラメーターを要求 URI に指定できます。

| URI パラメーター | 説明 |
| :---          | :--- |
| packageFullname   | (**必須**) サイドローディングされたアプリのパッケージの完全な名前。 |

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

**状態コード**

この API では次の状態コードが返される可能性があります。

|  HTTP 状態コード      | 説明 | 
| :------     | :----- |
|  200 | OK | 

**使用可能なデバイス ファミリ**

* Window Mobile (Windows Insider Program のみ)
* Windows Desktop
* HoloLens
* IoT

<hr>

### <a name="get-the-list-of-bugcheck-files"></a>バグチェック ファイルの一覧を取得する

**要求**

次の要求形式を使用して、バグチェックのミニダンプ ファイルの一覧を取得できます。
 
| メソッド      | 要求 URI |
| :------     | :----- |
| GET | /api/debug/dump/kernel/dumplist |


**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

応答には、ダンプ ファイル名とこれらのファイルのサイズの一覧が含まれます。 一覧は、次の形式になります。 
```json
{"DumpFiles": [
    {
        "FileName": string,
        "FileSize": int
    },...
]}
```

**状態コード**

この API では次の状態コードが返される可能性があります。

|  HTTP 状態コード      | 説明 | 
| :------     | :----- |
|  200 | OK | 

**使用可能なデバイス ファミリ**

* Windows Desktop
* IoT

<hr>

### <a name="download-a-bugcheck-dump-file"></a>バグチェックのダンプ ファイルをダウンロードする

**要求**

次の要求形式を使用して、バグチェックのダンプ ファイルをダウンロードできます。
 
| メソッド      | 要求 URI |
| :------     | :----- |
| GET | /api/debug/dump/kernel/dump |


**URI パラメーター**

次の追加パラメーターを要求 URI に指定できます。

| URI パラメーター | 説明 |
| :------          | :------ |
| &lt;ファイル名&gt;   | (**必須**) ダンプ ファイルのファイル名。 API を使ってダンプの一覧を取得することによって確認できます。 |


**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

応答には、ダンプ ファイルが含まれます。 WinDbg を使用してこのファイルを調べることができます。

**状態コード**

この API では次の状態コードが返される可能性があります。

|  HTTP 状態コード      | 説明 | 
| :------     | :----- |
|  200 | OK | 
| 4XX | エラー コード |
| 5XX | エラー コード |

**使用可能なデバイス ファミリ**

* Windows Desktop
* IoT

<hr>

### <a name="get-the-bugcheck-crash-control-settings"></a>バグチェックのクラッシュ制御の設定を取得する

**要求**

次の要求形式を使用して、バグチェックのクラッシュ制御の設定を取得できます。
 
| メソッド      | 要求 URI |
| :------     | :----- |
| GET | /api/debug/dump/kernel/crashcontrol |


**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

応答には、クラッシュの制御の設定が含まれます。 CrashControl について詳しくは、「[CrashControl](https://technet.microsoft.com/library/cc951703.aspx)」をご覧ください。 応答のテンプレートは次のとおりです。
```json
{
    "autoreboot": bool (0 or 1),
    "dumptype": int (0 to 4),
    "maxdumpcount": int,
    "overwrite": bool (0 or 1)
}
```

**ダンプの種類**

0:Disabled

1:完全メモリ ダンプを (すべての使用中のメモリを収集します)

2:カーネル メモリ ダンプが (ユーザー モードのメモリは無視されます)

3:制限付きのカーネルのミニダンプ

**状態コード**

この API では次の状態コードが返される可能性があります。

|  HTTP 状態コード      | 説明 | 
| :------     | :----- |
|  200 | OK | 
| 4XX | エラー コード |
| 5XX | エラー コード |

**使用可能なデバイス ファミリ**

* Windows Desktop
* IoT

<hr>

### <a name="get-a-live-kernel-dump"></a>ライブ カーネル ダンプを取得する

**要求**

次の要求形式を使用して、ライブ カーネル ダンプを取得できます。
 
| メソッド      | 要求 URI |
| :------     | :----- |
| GET | /api/debug/dump/livekernel |


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

|  HTTP 状態コード      | 説明 | 
| :------     | :----- |
|  200 | OK | 
| 4XX | エラー コード |
| 5XX | エラー コード |

**使用可能なデバイス ファミリ**

* Windows Desktop
* IoT

<hr>

### <a name="get-a-dump-from-a-live-user-process"></a>ライブ ユーザー プロセスからダンプを取得する

**要求**

次の要求形式を使用して、ライブ ユーザー プロセスのダンプを取得できます。
 
| メソッド      | 要求 URI |
| :------     | :----- |
| GET | /api/debug/dump/usermode/live |


**URI パラメーター**

次の追加パラメーターを要求 URI に指定できます。

| URI パラメーター | 説明 |
| :------          | :------ |
| pid   | (**必須**) 目的のプロセスの一意のプロセス ID。 |

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

応答には、プロセス ダンプが含まれます。 WinDbg または Visual Studio を使用してこのファイルを調べることができます。

**状態コード**

この API では次の状態コードが返される可能性があります。

|  HTTP 状態コード      | 説明 | 
| :------     | :----- |
|  200 | OK | 
| 4XX | エラー コード |
| 5XX | エラー コード |

**使用可能なデバイス ファミリ**

* Windows Desktop
* IoT

<hr>

### <a name="set-the-bugcheck-crash-control-settings"></a>バグチェックのクラッシュ制御の設定を行う

**要求**

次の要求形式を使用して、バグチェック データの収集に関する設定を行うことができます。
 
| メソッド      | 要求 URI |
| :------     | :----- |
| POST | /api/debug/dump/kernel/crashcontrol |


**URI パラメーター**

次の追加パラメーターを要求 URI に指定できます。

| URI パラメーター | 説明 |
| :---          | :--- |
| autoreboot   | (**オプション**) true または false。 これは、エラーやロックの発生後に、システムが自動的に再起動するかどうかを示します。 |
| dumptype   | (**オプション**) dump タイプ。 サポートされる値については、「[CrashDumpType 列挙体](https://msdn.microsoft.com/library/azure/microsoft.azure.management.insights.models.crashdumptype.aspx)」をご覧ください。|
| maxdumpcount   | (**オプション**) 保存するダンプの最大数。 |
| overwrite   | (**オプション**) true または false。 これは、*maxdumpcount*で指定されているダンプ カウンターの制限に達した場合に古いダンプを上書きするかどうかを示します。 |

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

**状態コード**

この API では次の状態コードが返される可能性があります。

|  HTTP 状態コード      | 説明 | 
| :------     | :----- |
|  200 | OK | 
| 4XX | エラー コード |
| 5XX | エラー コード |

**使用可能なデバイス ファミリ**

* Windows Desktop
* IoT

<hr>

## <a name="etw"></a>ETW

<hr>

### <a name="create-a-realtime-etw-session-over-a-websocket"></a>websocket 経由でリアルタイムの ETW セッションを作成する

**要求**

次の要求形式を使用して、リアルタイムの ETW セッションを作成できます。 これは、websocket 経由で管理されます。  ETW イベントは、サーバーで一括処理され、1 秒に 1 回クライアントに送信されます。 
 
| メソッド      | 要求 URI |
| :------     | :----- |
| GET/WebSocket | /api/etw/session/realtime |


**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

応答には、有効なプロバイダーの ETW イベントが含まれます。  以下の「ETW WebSocket コマンド」をご覧ください。 

**状態コード**

この API では次の状態コードが返される可能性があります。

|  HTTP 状態コード      | 説明 | 
| :------     | :----- |
|  200 | OK | 
| 4XX | エラー コード |
| 5XX | エラー コード |

**使用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* HoloLens
* IoT

### <a name="etw-websocket-commands"></a>ETW WebSocket コマンド
次のコマンドは、クライアントからサーバーに送信されます。

| コマンド | 説明 |
| :----- | :----- |
| provider *{guid}* enable *{level}* | *{guid}* で指定されたプロバイダー (括弧は不要) を指定されたレベルで有効にします。 *{level}* は、1 (最小限の詳細) ～ 5 (詳細) の **int** です。 |
| provider *{guid}* disable | *{guid}* で指定されたプロバイダー (括弧は不要) を無効にします。 |

この応答は、サーバーからクライアントに送信されます。 これは、テキストとして送信され、JSON で解析すると次の形式になります。
```json
{
    "Events":[
        {
            "Timestamp": int,
            "ProviderName": string,
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

以下に例を示します。
```json
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

<hr>

### <a name="enumerate-the-registered-etw-providers"></a>登録済みの ETW プロバイダーを列挙する

**要求**

次の要求形式を使用して、登録済みプロバイダーを列挙できます。
 
| メソッド      | 要求 URI |
| :------     | :----- |
| GET | /api/etw/providers |


**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

応答には、ETW プロバイダーの一覧が含まれます。 一覧には、各プロバイダーのフレンドリ名と GUID が次の形式で含まれます。
```json
{"Providers": [
    {
        "GUID": string, (GUID)
        "Name": string
    },...
]}
```

**状態コード**

この API では次の状態コードが返される可能性があります。

|  HTTP 状態コード      | 説明 | 
| :------     | :----- |
|  200 | OK | 

**使用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* HoloLens
* IoT

<hr>

### <a name="enumerate-the-custom-etw-providers-exposed-by-the-platform"></a>プラットフォームによって公開されているカスタム ETW プロバイダーを列挙します。

**要求**

次の要求形式を使用して、登録済みプロバイダーを列挙できます。
 
| メソッド      | 要求 URI |
| :------     | :----- |
| GET | /api/etw/customproviders |


**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

200 OK。 応答には、ETW プロバイダーの一覧が含まれます。 一覧には、各プロバイダーのフレンドリ名と GUID が含まれます。

```json
{"Providers": [
    {
        "GUID": string, (GUID)
        "Name": string
    },...
]}
```

**状態コード**

- 標準の状態コード。

**使用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* HoloLens
* IoT

<hr>

## <a name="location"></a>Location

<hr>

### <a name="get-location-override-mode"></a>場所の上書きモードを取得する

**要求**

次の要求型式を使用して、デバイスの場所スタック上書き状態を取得できます。 この呼び出しを成功させるには、開発者モードを有効にしておく必要があります。
 
| メソッド      | 要求 URI |
| :------     | :----- |
| GET | /ext/location/override |


**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

応答には、デバイスの上書き状態が次の形式で含まれます。 

```json
{"Override" : bool}
```

**状態コード**

この API では次の状態コードが返される可能性があります。

| HTTP 状態コード      | 説明 |
| :------     | :----- |
|  200 | OK | 
| 4XX | エラー コード |
| 5XX | エラー コード |

**使用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* Xbox
* HoloLens
* IoT

### <a name="set-location-override-mode"></a>場所の上書きモードを設定する

**要求**

次の要求型式を使用して、デバイスの場所スタック上書き状態を設定できます。 有効になっている場合は、場所スタックによって位置挿入が許可されます。 この呼び出しを成功させるには、開発者モードを有効にしておく必要があります。

| メソッド      | 要求 URI |
| :------     | :----- |
| PUT | /ext/location/override |


**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**

```json
{"Override" : bool}
```

**応答**

応答には、デバイスに設定されている上書き状態が次の形式で含まれます。 

```json
{"Override" : bool}
```

**状態コード**

この API では次の状態コードが返される可能性があります。

| HTTP 状態コード      | 説明 |
| :------     | :----- |
| 200 | OK |
| 4XX | エラー コード |
| 5XX | エラー コード |

**使用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* Xbox
* HoloLens
* IoT

### <a name="get-the-injected-position"></a>挿入された位置を取得する

**要求**

次の要求型式を使用して、デバイスの挿入 (スプーフィング) された場所を取得できます。 挿入された場所を設定する必要があります。設定されなかった場合は、エラーがスローされます。
 
| メソッド      | 要求 URI |
| :------     | :----- |
| GET | /ext/location/position |


**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

応答には、現在の挿入された緯度と経度の値が次の形式で含まれます。 

```json
{
    "Latitude" : double,
    "Longitude" : double
}
```

**状態コード**

この API では次の状態コードが返される可能性があります。

|  HTTP 状態コード      | 説明 | 
| :------     | :----- |
| 200 | OK |
| 4XX | エラー コード |
| 5XX | エラー コード |

**使用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* Xbox
* HoloLens
* IoT

### <a name="set-the-injected-position"></a>挿入された位置を設定する

**要求**

次の要求型式を使用して、デバイスの挿入 (スプーフィング) された場所を設定できます。 あらかじめデバイス上で場所の上書きモードが有効になっており、設定される場所も有効である必要があります。それ以外の場合はエラーがスローされます。

| メソッド      | 要求 URI |
| :------     | :----- |
| PUT | /ext/location/override |


**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**

```json
{
    "Latitude" : double,
    "Longitude" : double
}
```

**応答**

応答には、設定された場所の情報が次の形式で含まれます。 

```json
{
    "Latitude" : double,
    "Longitude" : double
}
```

**状態コード**

この API では次の状態コードが返される可能性があります。

| HTTP 状態コード      | 説明 |
| :------     | :----- |
| 200 | OK |
| 4XX | エラー コード |
| 5XX | エラー コード |

**使用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* Xbox
* HoloLens
* IoT

<hr>

## <a name="os-information"></a>OS 情報

<hr>

### <a name="get-the-machine-name"></a>コンピューター名を取得する

**要求**

次の要求形式を使用して、コンピューターの名前を取得できます。
 
| メソッド      | 要求 URI |
| :------     | :----- |
| GET | /api/os/machinename |


**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

応答には、コンピューター名が次の形式で含まれます。 

```json
{"ComputerName": string}
```

**状態コード**

この API では次の状態コードが返される可能性があります。

| HTTP 状態コード      | 説明 |
| :------     | :----- |
| 200 | OK |
| 4XX | エラー コード |
| 5XX | エラー コード |

**使用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* Xbox
* HoloLens
* IoT

<hr>

### <a name="get-the-operating-system-information"></a>オペレーティング システムの情報を取得する

**要求**

次の要求形式を使用して、コンピューターの OS 情報を取得できます。
 
| メソッド      | 要求 URI |
| :------     | :----- |
| GET | /api/os/info |


**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

応答には、OS 情報が次の形式で含まれます。

```json
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

| HTTP 状態コード      | 説明 |
| :------     | :----- |
| 200 | OK |
| 4XX | エラー コード |
| 5XX | エラー コード |

**使用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* Xbox
* HoloLens
* IoT

<hr>

### <a name="get-the-device-family"></a>デバイス ファミリを取得する 

**要求**

次の要求形式を使用して、デバイス ファミリ (Xbox、携帯電話、デスクトップなど) を取得できます。
 
| メソッド      | 要求 URI |
| :------     | :----- |
| GET | /api/os/devicefamily |


**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

応答には、デバイス ファミリ (SKU - デスクトップ、Xbox など) が含まれます。

```json
{
   "DeviceType" : string
}
```

DeviceType は、"Windows.Xbox"、"Windows.Desktop" などのようになります。 

**状態コード**

この API では次の状態コードが返される可能性があります。

| HTTP 状態コード      | 説明 |
| :------     | :----- |
| 200 | OK |
| 4XX | エラー コード |
| 5XX | エラー コード |

**使用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* Xbox
* HoloLens
* IoT

<hr>

### <a name="set-the-machine-name"></a>コンピューター名を設定する

**要求**

次の要求形式を使用して、コンピューターの名前を設定できます。
 
| メソッド      | 要求 URI |
| :------     | :----- |
| POST | /api/os/machinename |


**URI パラメーター**

次の追加パラメーターを要求 URI に指定できます。

| URI パラメーター | 説明 |
| :------          | :------ |
| name | (**必須**) コンピューターの新しい名前。 |

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

**状態コード**

この API では次の状態コードが返される可能性があります。

| HTTP 状態コード      | 説明 |
| :------     | :----- |
| 200 | OK |

**使用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* Xbox
* HoloLens
* IoT

<hr>

## <a name="user-information"></a>ユーザー情報

<hr>

### <a name="get-the-active-user"></a>アクティブ ユーザーを取得する

**要求**

次の要求形式を使用して、デバイスのアクティブ ユーザーの名前を取得できます。
 
| メソッド      | 要求 URI |
| :------     | :----- |
| GET | /api/users/activeuser |


**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

応答には、ユーザー情報が次の形式で含まれます。 

成功した場合: 
```json
{
    "UserDisplayName" : string, 
    "UserSID" : string
}
```
失敗した場合:
```json
{
    "Code" : int, 
    "CodeText" : string, 
    "Reason" : string, 
    "Success" : bool
}
```

**状態コード**

この API では次の状態コードが返される可能性があります。

| HTTP 状態コード      | 説明 |
| :------     | :----- |
| 200 | OK |
| 4XX | エラー コード |
| 5XX | エラー コード |

**使用可能なデバイス ファミリ**

* Windows Desktop
* HoloLens
* IoT

<hr>

## <a name="performance-data"></a>パフォーマンス データ

<hr>

### <a name="get-the-list-of-running-processes"></a>実行中のプロセスの一覧を取得する

**要求**

次の要求形式を使用して、現在実行中のプロセスの一覧を取得できます。  これは、WebSocket 接続にアップグレードすることもでき、1 秒に 1 度クライアントにプッシュされる同じ JSON データを取得できます。 
 
| メソッド      | 要求 URI |
| :------     | :----- |
| GET | /api/resourcemanager/processes |
| GET/WebSocket | /api/resourcemanager/processes |


**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

応答には、プロセスの一覧と各プロセスの詳細情報が含まれます。 情報は JSON 形式で、テンプレートは次のとおりです。
```json
{"Processes": [
    {
        "CPUUsage": float,
        "ImageName": string,
        "PageFileUsage": long,
        "PrivateWorkingSet": long,
        "ProcessId": int,
        "SessionId": int,
        "UserName": string,
        "VirtualSize": long,
        "WorkingSetSize": long
    },...
]}
```

**状態コード**

この API では次の状態コードが返される可能性があります。

| HTTP 状態コード      | 説明 |
| :------     | :----- |
| 200 | OK |
| 4XX | エラー コード |
| 5XX | エラー コード |

**使用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* HoloLens
* IoT

<hr>

### <a name="get-the-system-performance-statistics"></a>システム パフォーマンスの統計情報を取得する

**要求**

次の要求形式を使用して、システム パフォーマンスの統計情報を取得できます。 これには、読み取りと書き込みのサイクルや、使用されているメモリの量などの情報が含まれます。
 
| メソッド      | 要求 URI |
| :------     | :----- |
| GET | /api/resourcemanager/systemperf |
| GET/WebSocket | /api/resourcemanager/systemperf |

これは、WebSocket 接続にアップグレードできます。  1 秒に 1 度以下と同じ JSON データが提供されます。 

**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

応答には、CPU と GPU の使用量、メモリ アクセス、ネットワーク アクセスなど、パフォーマンスの統計情報が含まれます。 この情報は JSON 形式で、テンプレートは次のとおりです。
```json
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

| HTTP 状態コード      | 説明 |
| :------     | :----- |
| 200 | OK |
| 4XX | エラー コード |
| 5XX | エラー コード |

**使用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* Xbox
* HoloLens
* IoT

<hr>

## <a name="power"></a>Power

<hr>

### <a name="get-the-current-battery-state"></a>現在のバッテリ状態を取得する

**要求**

次の要求形式を使用して、バッテリの現在の状態を取得できます。
 
| メソッド      | 要求 URI |
| :------     | :----- |
| GET | /api/power/battery |


**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

現在のバッテリ状態に関する情報が次の形式で返されます。
```json
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

| HTTP 状態コード      | 説明 |
| :------     | :----- |
| 200 | OK |
| 4XX | エラー コード |
| 5XX | エラー コード |

**使用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* HoloLens
* IoT

<hr>

### <a name="get-the-active-power-scheme"></a>アクティブな電源設定を取得する

**要求**

次の要求形式を使用して、アクティブな電源設定を取得できます。
 
| メソッド      | 要求 URI |
| :------     | :----- |
| GET | /api/power/activecfg |


**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

アクティブな電源設定の形式は、次のとおりです。
```json
{"ActivePowerScheme": string (guid of scheme)}
```

**状態コード**

この API では次の状態コードが返される可能性があります。

| HTTP 状態コード      | 説明 |
| :------     | :----- |
| 200 | OK |
| 4XX | エラー コード |
| 5XX | エラー コード |

**使用可能なデバイス ファミリ**

* Windows Desktop
* IoT

<hr>

### <a name="get-the-sub-value-for-a-power-scheme"></a>電源設定のサブ値を取得する

**要求**

次の要求形式を使用して、電源設定のサブ値を取得できます。
 
| メソッド      | 要求 URI |
| :------     | :----- |
| GET | /api/power/cfg/*<power scheme path>* |

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

| HTTP 状態コード      | 説明 |
| :------     | :----- |
| 200 | OK |
| 4XX | エラー コード |
| 5XX | エラー コード |

**使用可能なデバイス ファミリ**

* Windows Desktop
* IoT

<hr>

### <a name="get-the-power-state-of-the-system"></a>システムの電源状態を取得する

**要求**

次の要求形式を使用して、システムの電源状態を確認できます。 これによって、低電力状態になっているかどうかを確認できます。
 
| メソッド      | 要求 URI |
| :------     | :----- |
| GET | /api/power/state |


**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

電源状態の情報のテンプレートは次のとおりです。
```json
{"LowPowerState" : false, "LowPowerStateAvailable" : true }
```

**状態コード**

この API では次の状態コードが返される可能性があります。

| HTTP 状態コード      | 説明 |
| :------     | :----- |
| 200 | OK |
| 4XX | エラー コード |
| 5XX | エラー コード |

**使用可能なデバイス ファミリ**

* Windows Desktop
* HoloLens
* IoT

<hr>

### <a name="set-the-active-power-scheme"></a>アクティブな電源設定を行う

**要求**

次の要求形式を使用して、アクティブな電源設定を設定できます。
 
| メソッド      | 要求 URI |
| :------     | :----- |
| POST | /api/power/activecfg |


**URI パラメーター**

次の追加パラメーターを要求 URI に指定できます。

| URI パラメーター | 説明 |
| :---          | :--- |
| scheme | (**必須**) システムのアクティブな電源設定として設定するスキームの GUID。 |

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

**状態コード**

この API では次の状態コードが返される可能性があります。

| HTTP 状態コード      | 説明 |
| :------     | :----- |
| 200 | OK |
| 4XX | エラー コード |
| 5XX | エラー コード |

**使用可能なデバイス ファミリ**

* Windows Desktop
* IoT

<hr>

### <a name="set-the-sub-value-for-a-power-scheme"></a>電源設定のサブ値を設定する

**要求**

次の要求形式を使用して、電源設定のサブ値を設定できます。
 
| メソッド      | 要求 URI |
| :------     | :----- |
| POST | /api/power/cfg/*<power scheme path>* |


**URI パラメーター**

次の追加パラメーターを要求 URI に指定できます。

| URI パラメーター | 説明 |
| :------          | :------ |
| valueAC | (**必須**) AC 電源に使用する値。 |
| valueDC | (**必須**) バッテリ電源に使用する値。 |

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

**状態コード**

この API では次の状態コードが返される可能性があります。

| HTTP 状態コード      | 説明 |
| :------     | :----- |
| 200 | OK |

**使用可能なデバイス ファミリ**

* Windows Desktop
* IoT

<hr>

### <a name="get-a-sleep-study-report"></a>SleepStudy レポートを取得する

**要求**

| メソッド      | 要求 URI |
| :------     | :----- |
| GET | /api/power/sleepstudy/report |

次の要求形式を使用して、SleepStudy レポートを取得できます。

**URI パラメーター**
| URI パラメーター | 説明 |
| :------          | :------ |
| FileName | (**必須**) ダウンロードするファイルの完全な名前。 この値は、hex64 エンコードされている必要があります。 |

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

応答は、スリープ検査の結果が含まれているファイルです。 

**状態コード**

この API では次の状態コードが返される可能性があります。

| HTTP 状態コード      | 説明 |
| :------     | :----- |
| 200 | OK |
| 4XX | エラー コード |
| 5XX | エラー コード |

**使用可能なデバイス ファミリ**

* Windows Desktop
* IoT

<hr>

### <a name="enumerate-the-available-sleep-study-reports"></a>利用可能な SleepStudy レポートを列挙する

**要求**

次の要求形式を使用して、利用可能な SleepStudy レポートを列挙できます。
 
| メソッド      | 要求 URI |
| :------     | :----- |
| GET | /api/power/sleepstudy/reports |


**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

利用可能なレポートの一覧のテンプレートは次のとおりです。

```json
{"Reports": [
    {
        "FileName": string
    },...
]}
```

**状態コード**

この API では次の状態コードが返される可能性があります。

| HTTP 状態コード      | 説明 |
| :------     | :----- |
| 200 | OK |
| 4XX | エラー コード |
| 5XX | エラー コード |

**使用可能なデバイス ファミリ**

* Windows Desktop
* IoT

<hr>

### <a name="get-the-sleep-study-transform"></a>スリープ スタディ変換を取得する

**要求**

次の要求形式を使用して、スリープ スタディ変換を取得できます。 この変換は、SleepStudy レポートを、ユーザーが読み取ることができる XML 形式に変換する XSLT です。
 
| メソッド      | 要求 URI |
| :------     | :----- |
| GET | /api/power/sleepstudy/transform |


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

| HTTP 状態コード      | 説明 |
| :------     | :----- |
| 200 | OK |
| 4XX | エラー コード |
| 5XX | エラー コード |

**使用可能なデバイス ファミリ**

* Windows Desktop
* IoT

<hr>

## <a name="remote-control"></a>リモコン

<hr>

### <a name="restart-the-target-computer"></a>ターゲット コンピューターを再起動する

**要求**

次の要求形式を使用して、ターゲット コンピューターを再起動できます。
 
| メソッド      | 要求 URI |
| :------     | :----- |
| POST | /api/control/restart |


**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

**状態コード**

この API では次の状態コードが返される可能性があります。

| HTTP 状態コード      | 説明 |
| :------     | :----- |
| 200 | OK |

**使用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* Xbox
* HoloLens
* IoT

<hr>

### <a name="shut-down-the-target-computer"></a>ターゲット コンピューターをシャットダウンする

**要求**

次の要求形式を使用して、ターゲット コンピューターをシャット ダウンできます。
 
| メソッド      | 要求 URI |
| :------     | :----- |
| POST | /api/control/shutdown |


**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

**状態コード**

この API では次の状態コードが返される可能性があります。

| HTTP 状態コード      | 説明 |
| :------     | :----- |
| 200 | OK |
| 4XX | エラー コード |
| 5XX | エラー コード |

**使用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* Xbox
* HoloLens
* IoT

<hr>

## <a name="task-manager"></a>タスク マネージャー

<hr>

### <a name="start-a-modern-app"></a>最新のアプリを起動する

**要求**

次の要求形式を使用して、最新のアプリを起動できます。
 
| メソッド      | 要求 URI |
| :------     | :----- |
| POST | /api/taskmanager/app |


**URI パラメーター**

次の追加パラメーターを要求 URI に指定できます。

| URI パラメーター | 説明 |
| :---          | :--- |
| appid   | (**必須**) 起動するアプリの PRAID。 この値は、hex64 エンコードされている必要があります。 |
| パッケージ (package)   | (**必須**) 起動するアプリ パッケージの完全な名前。 この値は、hex64 エンコードされている必要があります。 |

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

**状態コード**

この API では次の状態コードが返される可能性があります。

| HTTP 状態コード      | 説明 |
| :------     | :----- |
| 200 | OK |
| 4XX | エラー コード |
| 5XX | エラー コード |

**使用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* Xbox
* HoloLens
* IoT

<hr>

### <a name="stop-a-modern-app"></a>最新のアプリを停止する

**要求**

次の要求形式を使用して、最新のアプリを停止できます。
 
| メソッド      | 要求 URI |
| :------     | :----- |
| Del | /api/taskmanager/app |


**URI パラメーター**

次の追加パラメーターを要求 URI に指定できます。

| URI パラメーター | 説明 |
| :---          | :--- |
| パッケージ (package)   | (**必須**) 停止するアプリ パッケージの完全な名前。 この値は、hex64 エンコードされている必要があります。 |
| forcestop   | (**オプション**) 値が **yes** の場合は、システムがすべてのプロセスを強制的に停止することを示します。 |

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

**状態コード**

この API では次の状態コードが返される可能性があります。

| HTTP 状態コード      | 説明 |
| :------     | :----- |
| 200 | OK |
| 4XX | エラー コード |
| 5XX | エラー コード |

**使用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* Xbox
* HoloLens
* IoT

<hr>

### <a name="kill-process-by-pid"></a>PID でプロセスを強制終了する

**要求**

次の要求形式を使用して、プロセスを強制終了できます。
 
| メソッド      | 要求 URI |
| :------     | :----- |
| Del | /api/taskmanager/process |


**URI パラメーター**

次の追加パラメーターを要求 URI に指定できます。

| URI パラメーター | 説明 |
| :------          | :------ |
| pid   | (**必須**) 終了するプロセスの一意のプロセス ID。 |

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

**状態コード**

この API では次の状態コードが返される可能性があります。

| HTTP 状態コード      | 説明 |
| :------     | :----- |
| 200 | OK |
| 4XX | エラー コード |
| 5XX | エラー コード |

**使用可能なデバイス ファミリ**

* Windows Desktop
* HoloLens
* IoT

<hr>

## <a name="networking"></a>ネットワーク

<hr>

### <a name="get-the-current-ip-configuration"></a>現在の IP 構成を取得する

**要求**

次の要求形式を使用して、現在の IP 構成を取得できます。
 
| メソッド      | 要求 URI |
| :------     | :----- |
| GET | /api/networking/ipconfig |


**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

応答には、次のテンプレートの IP 構成が含まれます。

```json
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

| HTTP 状態コード      | 説明 |
| :------     | :----- |
| 200 | OK |
| 4XX | エラー コード |
| 5XX | エラー コード |

**使用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* Xbox
* HoloLens
* IoT

<hr>

### <a name="set-a-static-ip-address-ipv4-configuration"></a>静的 IP アドレス (IPV4 構成) の設定します。

**要求**

静的 IP と DNS で IPV4 構成を設定します。 静的 IP が指定されていない場合は、DHCP が使用できます。 静的 IP が指定されている場合は、DNS も指定する必要があります。
 
| メソッド      | 要求 URI |
| :------     | :----- |
| PUT | /api/networking/ipv4config |


**URI パラメーター**

| URI パラメーター | 説明 |
| :---          | :--- |
| AdapterName | (**必要**) ネットワーク インターフェイスの GUID。 |
| IPAddress | 設定する静的 IP アドレス。 |
| サブネット マスク | (**必要**場合*IPAddress*が null でない)、静的なサブネット マスク。 |
| DefaultGateway | (**必要**場合*IPAddress*が null でない)、静的な既定ゲートウェイ。 |
| PrimaryDNS | (**必要**場合*IPAddress*が null でない) を設定する静的なプライマリ DNS。 |
| SecondayDNS | (**必要**場合*PrimaryDNS*が null でない) を設定する静的セカンダリ DNS。 |

わかりやすくするため、DHCP にインターフェイスを設定するシリアル化、`AdapterName`ネットワーク上で。

```json
{
    "AdapterName":"{82F86C1B-2BAE-41E3-B08D-786CA44FEED7}"
}
```

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

**状態コード**

この API では次の状態コードが返される可能性があります。

| HTTP 状態コード      | 説明 |
| :------     | :----- |
| 200 | OK |
| 4XX | エラー コード |
| 5XX | エラー コード |

**使用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* Xbox
* HoloLens
* IoT

<hr>

### <a name="enumerate-wireless-network-interfaces"></a>ワイヤレス ネットワーク インターフェイスを列挙する

**要求**

次の要求形式を使用して、利用可能なワイヤレス ネットワーク インターフェイスを列挙できます。
 
| メソッド      | 要求 URI |
| :------     | :----- |
| GET | /api/wifi/interfaces |


**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

次の形式の利用可能なワイヤレス インターフェイスと詳細の一覧。

```json 
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

| HTTP 状態コード      | 説明 |
| :------     | :----- |
| 200 | OK |
| 4XX | エラー コード |
| 5XX | エラー コード |

**使用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* Xbox
* HoloLens
* IoT

<hr>

### <a name="enumerate-wireless-networks"></a>ワイヤレス ネットワークを列挙する

**要求**

次の要求形式を使用して、指定されたインターフェイスのワイヤレス ネットワークの一覧を列挙できます。
 
| メソッド      | 要求 URI |
| :------     | :----- |
| GET | /api/wifi/networks |


**URI パラメーター**

次の追加パラメーターを要求 URI に指定できます。

| URI パラメーター | 説明 |
| :------          | :------ |
| インターフェイス   | (**必須**) ワイヤレス ネットワークの検索に使用するネットワーク インターフェイスの GUID (括弧は不要)。 |

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

指定された*インターフェイス*で見つかったワイヤレス ネットワークの一覧。 これには、ネットワークの詳細が次の形式で含まれます。

```json
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

| HTTP 状態コード      | 説明 |
| :------     | :----- |
| 200 | OK |
| 4XX | エラー コード |
| 5XX | エラー コード |

**使用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* Xbox
* HoloLens
* IoT

<hr>

### <a name="connect-and-disconnect-to-a-wi-fi-network"></a>Wi-Fi ネットワークを接続および切断する

**要求**

次の要求形式を使用して、Wi-Fi ネットワークを接続および切断できます。
 
| メソッド      | 要求 URI |
| :------     | :----- |
| POST | /api/wifi/network |


**URI パラメーター**

次の追加パラメーターを要求 URI に指定できます。

| URI パラメーター | 説明 |
| :------          | :------ |
| インターフェイス   | (**必須**) ネットワークへの接続に使用するネットワーク インターフェイスの GUID。 |
| op   | (**必須**) 実行するアクションを示します。 設定可能な値は、connect または disconnect です。|
| ssid   | (***op* == connect の場合は必須**) 接続先 SSID。 |
| key   | (***op* == connect で、ネットワークで認証が必要な場合は必須**) 共有キー。 |
| createprofile | (**必要**) デバイスでネットワークのプロファイルを作成します。  これにより、今後、デバイスはネットワークに自動接続されます。 **yes** または **no** を指定できます。 |

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

**状態コード**

この API では次の状態コードが返される可能性があります。

| HTTP 状態コード      | 説明 |
| :------     | :----- |
| 200 | OK |

**使用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* Xbox
* HoloLens
* IoT

<hr>

### <a name="delete-a-wi-fi-profile"></a>Wi-Fi のプロファイルを削除する

**要求**

次の要求形式を使用して、特定のインターフェイス上のネットワークに関連付けられたプロファイルを削除できます。
 
| メソッド      | 要求 URI |
| :------     | :----- |
| Del | /api/wifi/profile |


**URI パラメーター**

次の追加パラメーターを要求 URI に指定できます。

| URI パラメーター | 説明 |
| :------          | :------ |
| インターフェイス   | (**必須**) 削除するプロファイルに関連付けられたネットワーク インターフェイスの GUID。 |
| プロファイル   | (**必須**) 削除するプロファイルの名前。 |

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

**状態コード**

この API では次の状態コードが返される可能性があります。

| HTTP 状態コード      | 説明 |
| :------     | :----- |
| 200 | OK |

**使用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* Xbox
* HoloLens
* IoT

<hr>

## <a name="windows-error-reporting-wer"></a>Windows エラー報告 (WER)

<hr>

### <a name="download-a-windows-error-reporting-wer-file"></a>Windows エラー報告 (WER) ファイルをダウンロードする

**要求**

次の要求形式を使用して、WER 関連のファイルをダウンロードできます。
 
| メソッド      | 要求 URI |
| :------     | :----- |
| GET | /api/wer/report/file |


**URI パラメーター**

次の追加パラメーターを要求 URI に指定できます。

| URI パラメーター | 説明 |
| :------          | :------ |
| ユーザー   | (**必須**) レポートに関連付けられたユーザー名。 |
| type   | (**必須**) レポートの種類。 これは **queried** または **archived** のいずれかになります。 |
| name   | (**必須**) レポートの名前。 base64 でエンコードされている必要があります。 |
| ファイル   | (**必須**) レポートからダウンロードするファイルの名前。 base64 でエンコードされている必要があります。 |

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

- 応答には、要求したファイルが含まれています。 

**状態コード**

この API では次の状態コードが返される可能性があります。

| HTTP 状態コード      | 説明 |
| :------     | :----- |
| 200 | OK |
| 4XX | エラー コード |
| 5XX | エラー コード |

**使用可能なデバイス ファミリ**

* Windows Desktop
* HoloLens
* IoT

<hr>

### <a name="enumerate-files-in-a-windows-error-reporting-wer-report"></a>Windows エラー報告 (WER) レポート内のファイルを列挙する

**要求**

次の要求形式を使用して、WER レポート内のファイルを列挙できます。
 
| メソッド      | 要求 URI |
| :------     | :----- |
| GET | /api/wer/report/files |


**URI パラメーター**

次の追加パラメーターを要求 URI に指定できます。

| URI パラメーター | 説明 |
| :------          | :------ |
| ユーザー   | (**必須**) レポートに関連付けられたユーザー。 |
| type   | (**必須**) レポートの種類。 これは **queried** または **archived** のいずれかになります。 |
| name   | (**必須**) レポートの名前。 base64 でエンコードされている必要があります。 |

**要求ヘッダー**

- なし

**要求本文**

```json
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

| HTTP 状態コード      | 説明 |
| :------     | :----- |
| 200 | OK |
| 4XX | エラー コード |
| 5XX | エラー コード |

**使用可能なデバイス ファミリ**

* Windows Desktop
* HoloLens
* IoT

<hr>

### <a name="list-the-windows-error-reporting-wer-reports"></a>Windows エラー報告 (WER) レポートを一覧表示する

**要求**

次の要求形式を使用して、WER レポートを取得できます。
 
| メソッド      | 要求 URI |
| :------     | :----- |
| GET | /api/wer/reports |


**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

WER 報告の形式は次のとおりです。

```json
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

| HTTP 状態コード      | 説明 |
| :------     | :----- |
| 200 | OK |
| 4XX | エラー コード |
| 5XX | エラー コード |

**使用可能なデバイス ファミリ**

* Windows Desktop
* HoloLens
* IoT

<hr>

## <a name="windows-performance-recorder-wpr"></a>Windows Performance Recorder (WPR) 

<hr>

### <a name="start-tracing-with-a-custom-profile"></a>カスタム プロファイルを使用してトレースを開始する

**要求**

次の要求形式を使用して、WPR プロファイルをアップロードし、そのプロファイルを使用してトレースを開始できます。  一度に実行できるトレースは 1 つのみです。 プロファイルはデバイス上に残りません。 
 
| メソッド      | 要求 URI |
| :------     | :----- |
| POST | /api/wpr/customtrace |


**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**

- カスタム WPR プロファイルが含まれる、原則に従ったマルチパートの http 本文。

**応答**

WPR セッション状態の形式は次のとおりです。

```json
{
    "SessionType": string, (Running or Idle) 
    "State": string (normal or boot)
}
```

**状態コード**

この API では次の状態コードが返される可能性があります。

| HTTP 状態コード      | 説明 |
| :------     | :----- |
| 200 | OK |
| 4XX | エラー コード |
| 5XX | エラー コード |

**使用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* HoloLens
* IoT

<hr>

### <a name="start-a-boot-performance-tracing-session"></a>起動パフォーマンス トレース セッションを開始する

**要求**

次の要求形式を使用して、WPR の起動トレース セッションを開始できます。 これは、パフォーマンス トレース セッションとも呼びます。
 
| メソッド      | 要求 URI |
| :------     | :----- |
| POST | /api/wpr/boottrace |


**URI パラメーター**

次の追加パラメーターを要求 URI に指定できます。

| URI パラメーター | 説明 |
| :------          | :------ |
| プロファイル   | (**必須**) このパラメーターは起動時に必要です。 パフォーマンス トレース セッションを開始する必要があるプロファイルの名前。 指定可能なプロファイルは、perfprofiles/profiles.json に格納されています。 |

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

この API は、開始時に次の形式で WPR セッション状態を返します。

```json
{
    "SessionType": string, (Running or Idle) 
    "State": string (boot)
}
```

**状態コード**

この API では次の状態コードが返される可能性があります。

| HTTP 状態コード      | 説明 |
| :------     | :----- |
| 200 | OK |
| 4XX | エラー コード |
| 5XX | エラー コード |

**使用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* HoloLens
* IoT

<hr>

### <a name="stop-a-boot-performance-tracing-session"></a>起動パフォーマンス トレース セッションを停止する

**要求**

次の要求形式を使用して、WPR の起動トレース セッションを停止できます。 これは、パフォーマンス トレース セッションとも呼びます。
 
| メソッド      | 要求 URI |
| :------     | :----- |
| GET | /api/wpr/boottrace |


**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

-  なし。  **注:** これは、実行時間の長い操作です。  ETL のディスクへの書き込みが終了すると、制御が戻ります。

**状態コード**

この API では次の状態コードが返される可能性があります。

| HTTP 状態コード      | 説明 |
| :------     | :----- |
| 200 | OK |
| 4XX | エラー コード |
| 5XX | エラー コード |

**使用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* HoloLens
* IoT

<hr>

### <a name="start-a-performance-tracing-session"></a>パフォーマンス トレース セッションを開始する

**要求**

次の要求形式を使用して、WPR のトレース セッションを開始できます。 これは、パフォーマンス トレース セッションとも呼びます。  一度に実行できるトレースは 1 つのみです。 
 
| メソッド      | 要求 URI |
| :------     | :----- |
| POST | /api/wpr/trace |


**URI パラメーター**

次の追加パラメーターを要求 URI に指定できます。

| URI パラメーター | 説明 |
| :------          | :------ |
| プロファイル   | (**必須**) パフォーマンス トレース セッションを開始する必要があるプロファイルの名前。 指定可能なプロファイルは、perfprofiles/profiles.json に格納されています。 |

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

この API は、開始時に次の形式で WPR セッション状態を返します。

```json
{
    "SessionType": string, (Running or Idle) 
    "State": string (normal)
}
```

**状態コード**

この API では次の状態コードが返される可能性があります。

| HTTP 状態コード      | 説明 |
| :------     | :----- |
| 200 | OK |
| 4XX | エラー コード |
| 5XX | エラー コード |

**使用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* HoloLens
* IoT

<hr>

### <a name="stop-a-performance-tracing-session"></a>パフォーマンスのトレース セッションを停止する

**要求**

次の要求形式を使用して、WPR のトレース セッションを停止できます。 これは、パフォーマンス トレース セッションとも呼びます。
 
| メソッド      | 要求 URI |
| :------     | :----- |
| GET | /api/wpr/trace |


**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

- なし。  **注:** これは、実行時間の長い操作です。  ETL のディスクへの書き込みが終了すると、制御が戻ります。  

**状態コード**

この API では次の状態コードが返される可能性があります。

| HTTP 状態コード      | 説明 |
| :------     | :----- |
| 200 | OK |
| 4XX | エラー コード |
| 5XX | エラー コード |

**使用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* HoloLens
* IoT

<hr>

### <a name="retrieve-the-status-of-a-tracing-session"></a>トレース セッションの状態を取得する

**要求**

次の要求形式を使用して、現在の WPR セッションの状態を取得できます。
 
| メソッド      | 要求 URI |
| :------     | :----- |
| GET | /api/wpr/status |


**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

WPR トレース セッションの状態の形式は次のとおりです。

```json
{
    "SessionType": string, (Running or Idle) 
    "State": string (normal or boot)
}
```

**状態コード**

この API では次の状態コードが返される可能性があります。

| HTTP 状態コード      | 説明 |
| :------     | :----- |
| 200 | OK |
| 4XX | エラー コード |
| 5XX | エラー コード |

**使用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* HoloLens
* IoT

<hr>

### <a name="list-completed-tracing-sessions-etls"></a>完了したトレース セッション (ETL) を一覧表示する

**要求**

次の要求形式を使用して、デバイス上の ETL トレースの一覧を取得できます。 

| メソッド      | 要求 URI |
| :------     | :----- |
| GET | /api/wpr/tracefiles |


**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

完了したトレース セッションの一覧は次の形式で提供されます。

```json
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

| HTTP 状態コード      | 説明 |
| :------     | :----- |
| 200 | OK |
| 4XX | エラー コード |
| 5XX | エラー コード |

**使用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* HoloLens
* IoT

<hr>

### <a name="download-a-tracing-session-etl"></a>トレース セッション (ETL) をダウンロードする

**要求**

次の要求形式を使用して、トレースファイル (ブート トレースまたはユーザー モード トレース) をダウンロードできます。 

| メソッド      | 要求 URI |
| :------     | :----- |
| GET | /api/wpr/tracefile |


**URI パラメーター**

次の追加パラメーターを要求 URI に指定できます。

| URI パラメーター | 説明 |
| :------          | :------ |
| &lt;ファイル名&gt;   | (**必須**) ダウンロードする ETL トレースの名前。  これらは /api/wpr/tracefiles にあります。 |

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

- トレース ETL ファイルを返します。

**状態コード**

この API では次の状態コードが返される可能性があります。

| HTTP 状態コード      | 説明 |
| :------     | :----- |
| 200 | OK |
| 4XX | エラー コード |
| 5XX | エラー コード |

**使用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* HoloLens
* IoT

<hr>

### <a name="delete-a-tracing-session-etl"></a>トレース セッション (ETL) を削除する

**要求**

次の要求形式を使用して、トレースファイル (ブート トレースまたはユーザー モード トレース) を削除できます。 

| メソッド      | 要求 URI |
| :------     | :----- |
| Del | /api/wpr/tracefile |


**URI パラメーター**

次の追加パラメーターを要求 URI に指定できます。

| URI パラメーター | 説明 |
| :------          | :------ |
| &lt;ファイル名&gt;   | (**必須**) 削除する ETL トレースの名前。  これらは /api/wpr/tracefiles にあります。 |

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

- トレース ETL ファイルを返します。

**状態コード**

この API では次の状態コードが返される可能性があります。

| HTTP 状態コード      | 説明 |
| :------     | :----- |
| 200 | OK |
| 4XX | エラー コード |
| 5XX | エラー コード |

**使用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* HoloLens
* IoT

<hr>

## <a name="dns-sd-tags"></a>DNS SD タグ 

<hr>

### <a name="view-tags"></a>タグを表示する

**要求**

デバイスに現在適用されているタグを表示します。  これらのタグは、T キー内の DNS-SD TXT レコードを使用してアドバタイズされます。  
 
| メソッド      | 要求 URI |
| :------     | :----- |
| GET | /api/dns-sd/tags |


**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答** 現在適用されているタグの形式は次のとおりです。 
```json
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

| HTTP 状態コード      | 説明 |
| :------     | :----- |
| 200 | OK |
| 5XX | サーバー エラー |


**使用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* Xbox
* HoloLens
* IoT

<hr>

### <a name="delete-tags"></a>タグを削除する

**要求**

DNS-SD によって現在アドバタイズされているすべてのタグを削除します。   
 
| メソッド      | 要求 URI |
| :------     | :----- |
| Del | /api/dns-sd/tags |


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

| HTTP 状態コード      | 説明 |
| :------     | :----- |
| 200 | OK |
| 5XX | サーバー エラー |


**使用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* Xbox
* HoloLens
* IoT

<hr>

### <a name="delete-tag"></a>タグを削除する

**要求**

DNS-SD によって現在アドバタイズされている 1 つのタグを削除します。   
 
| メソッド      | 要求 URI |
| :------     | :----- |
| Del | /api/dns-sd/tag |


**URI パラメーター**

| URI パラメーター | 説明 |
| :------     | :----- |
| tagValue | (**必須**) 削除するタグ。 |

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**
 - なし

**状態コード**

この API では次の状態コードが返される可能性があります。

| HTTP 状態コード      | 説明 |
| :------     | :----- |
| 200 | OK |


**使用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* Xbox
* HoloLens
* IoT
 
<hr>

### <a name="add-a-tag"></a>タグを追加する

**要求**

DNS-SD アドバタイズにタグを追加します。   
 
| メソッド      | 要求 URI |
| :------     | :----- |
| POST | /api/dns-sd/tag |


**URI パラメーター**

| URI パラメーター | 説明 |
| :------     | :----- |
| tagValue | (**必要**) 追加するタグ。 |

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**
 - なし

**状態コード**

この API では次の状態コードが返される可能性があります。

| HTTP 状態コード      | 説明 |
| :------     | :----- |
| 200 | OK |
| 401 | タグ領域のオーバーフロー。  提供されたタグが、結果として生成される DNS-SD サービス レコードに対して長すぎます。 |


**使用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* Xbox
* HoloLens
* IoT

## <a name="app-file-explorer"></a>アプリのエクスプローラー

<hr>

### <a name="get-known-folders"></a>既知のフォルダーを取得する

**要求**

アクセス可能なトップ レベル フォルダーの一覧を取得します。

| メソッド      | 要求 URI |
| :------     | :----- |
| GET | /api/filesystem/apps/knownfolders |


**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答** 利用可能なフォルダーの形式は次のとおりです。 
```json
 {"KnownFolders": [
    "folder0",
    "folder1",...
]}
```
**状態コード**

この API では次の状態コードが返される可能性があります。

| HTTP 状態コード      | 説明 |
| :------     | :----- |
| 200 | 展開要求は受け入れられ、処理されています。 |
| 4XX | エラー コード |
| 5XX | エラー コード |


**使用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* HoloLens
* Xbox
* IoT

<hr>

### <a name="get-files"></a>ファイルを取得する

**要求**

フォルダー内のファイルの一覧を取得します。

| メソッド      | 要求 URI |
| :------     | :----- |
| GET | /api/filesystem/apps/files |


**URI パラメーター**

| URI パラメーター | 説明 |
| :------     | :----- |
| knownfolderid | (**必須**) 必要なファイルの一覧の対象となるトップレベル ディレクトリ。 サイドロードされたアプリにアクセスするには、**LocalAppData** を使用します。 |
| packagefullname | (***knownfolderid* == LocalAppData の場合は必須**) 対象となるアプリのパッケージのフルネーム。 |
| path | (**オプション**) 上で指定したフォルダーまたはパッケージ内のサブディレクトリ。 |

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答** 利用可能なフォルダーの形式は次のとおりです。 
```json
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

| HTTP 状態コード      | 説明 |
| :------     | :----- |
| 200 | OK |
| 4XX | エラー コード |
| 5XX | エラー コード |

**使用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* HoloLens
* Xbox
* IoT

<hr>

### <a name="download-a-file"></a>ファイルをダウンロードする

**要求**

既知のフォルダーまたは appLocalData からファイルを取得します。

| メソッド      | 要求 URI |
| :------     | :----- |
| GET | /api/filesystem/apps/file |

**URI パラメーター**

| URI パラメーター | 説明 |
| :------     | :----- |
| knownfolderid | (**必須**) ファイルをダウンロードするトップレベル ディレクトリ。 サイドロードされたアプリにアクセスするには、**LocalAppData** を使用します。 |
| &lt;ファイル名&gt; | (**必須**) ダウンロードするファイルの名前。 |
| packagefullname | (***knownfolderid* == LocalAppData の場合は必須**) 対象となるパッケージのフルネーム。 |
| path | (**オプション**) 上で指定したフォルダーまたはパッケージ内のサブディレクトリ。 |

**要求ヘッダー**

- なし

**要求本文**

- 要求するファイル (存在する場合)

**応答**

**状態コード**

この API では次の状態コードが返される可能性があります。

| HTTP 状態コード      | 説明 |
| :------     | :----- |
| 200 | 要求したファイル |
| 404 | ファイルが見つからない |
| 5XX | エラー コード |

**使用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* HoloLens
* Xbox
* IoT

<hr>

### <a name="rename-a-file"></a>ファイルの名前の変更

**要求**

フォルダー内のファイルの名前を変更します。

| メソッド      | 要求 URI |
| :------     | :----- |
| POST | /api/filesystem/apps/rename |


**URI パラメーター**

| URI パラメーター | 説明 |
| :------     | :----- |
| knownfolderid | (**必須**) ファイルが存在するトップレベル ディレクトリ。 サイドロードされたアプリにアクセスするには、**LocalAppData** を使用します。 |
| &lt;ファイル名&gt; | (**必須**) 名前を変更するファイルの元の名前。 |
| newfilename | (**必須**) ファイルの新しい名前。|
| packagefullname | (***knownfolderid* == LocalAppData の場合は必須**) 対象となるアプリのパッケージのフルネーム。 |
| path | (**オプション**) 上で指定したフォルダーまたはパッケージ内のサブディレクトリ。 |

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

- なし

**状態コード**

この API では次の状態コードが返される可能性があります。

| HTTP 状態コード      | 説明 |
| :------     | :----- |
| 200 | OK |. ファイルの名前が変更されました
| 404 | ファイルが見つからない |
| 5XX | エラー コード |

**使用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* HoloLens
* Xbox
* IoT

<hr>

### <a name="delete-a-file"></a>ファイルを削除する

**要求**

フォルダー内のファイルを削除します。

| メソッド      | 要求 URI |
| :------     | :----- |
| Del | /api/filesystem/apps/file |

**URI パラメーター**

| URI パラメーター | 説明 |
| :------     | :----- |
| knownfolderid | (**必須**) ファイルを削除するトップレベル ディレクトリ。 サイドロードされたアプリにアクセスするには、**LocalAppData** を使用します。 |
| &lt;ファイル名&gt; | (**必須**) 削除するファイルの名前。 |
| packagefullname | (***knownfolderid* == LocalAppData の場合は必須**) 対象となるアプリのパッケージのフルネーム。 |
| path | (**オプション**) 上で指定したフォルダーまたはパッケージ内のサブディレクトリ。 |

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

- なし 

**状態コード**

この API では次の状態コードが返される可能性があります。

| HTTP 状態コード      | 説明 |
| :------     | :----- |
| 200 | OK |. ファイルが削除されます。 |
| 404 | ファイルが見つからない |
| 5XX | エラー コード |

**使用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* HoloLens
* Xbox
* IoT

<hr>

### <a name="upload-a-file"></a>ファイルをアップロードする

**要求**

フォルダーにファイルをアップロードします。  この場合、同じ名前を持つ既存のファイルは上書きされますが、新しいフォルダーは作成されません。 

| メソッド      | 要求 URI |
| :------     | :----- |
| POST | /api/filesystem/apps/file |

**URI パラメーター**

| URI パラメーター | 説明 |
| :------     | :----- |
| knownfolderid | (**必須**) ファイルをアップロードするトップレベル ディレクトリ。 サイドロードされたアプリにアクセスするには、**LocalAppData** を使用します。 |
| packagefullname | (***knownfolderid* == LocalAppData の場合は必須**) 対象となるアプリのパッケージのフルネーム。 |
| path | (**オプション**) 上で指定したフォルダーまたはパッケージ内のサブディレクトリ。 |

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**

**状態コード**

この API では次の状態コードが返される可能性があります。

| HTTP 状態コード      | 説明 |
| :------     | :----- |
| 200 | OK |. ファイルがアップロードされます。 |
| 4XX | エラー コード |
| 5XX | エラー コード |

**使用可能なデバイス ファミリ**

* Windows Mobile
* Windows Desktop
* HoloLens
* Xbox
* IoT
