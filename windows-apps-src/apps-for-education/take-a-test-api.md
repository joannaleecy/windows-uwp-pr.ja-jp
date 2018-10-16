---
Description: The JavaScript API for the Microsoft Take a Test app allows you to do secure assessments. Take a Test provides a secure browser that prevents students from using other computer or internet resources during a test.
title: テスト JavaScript API。
author: PatrickFarley
ms.author: pafarley
ms.assetid: 9bff6318-504c-4d0e-ba80-1a5ea45743da
ms.date: 08/08/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, 教育
ms.localizationpriority: medium
ms.openlocfilehash: 38596ad12ac309db5dc60e4a5183eee9bf8c7b7c
ms.sourcegitcommit: 9354909f9351b9635bee9bb2dc62db60d2d70107
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/16/2018
ms.locfileid: "4683559"
---
# <a name="take-a-test-javascript-api"></a>テスト JavaScript API

[テスト](https://technet.microsoft.com/edu/windows/take-tests-in-windows-10)はテストは、厳正なオンライン評価をロック ダウンをレンダリングするブラウザー ベースの UWP アプリ評価に集中する教育者のセキュリティで保護されたテスト環境を提供する方法ではなくコンテンツを許可します。 これを実現するには、任意の Web アプリケーションで利用できる JavaScript API を使用します。 テスト API は、重要な共通学力テストの [SBAC ブラウザー API 標準](http://www.smarterapp.org/documents/SecureBrowserRequirementsSpecifications_0-3.pdf)に対応しています。

アプリ自体の詳細については、「[テスト アプリ技術リファレンス](https://technet.microsoft.com/edu/windows/take-a-test-app-technical?f=255&MSPPError=-2147217396)」を参照してください。 トラブルシューティングについては、「[イベント ビューアーを使用して、Microsoft テストをトラブルシューティングする](troubleshooting.md)」を参照してください。

## <a name="reference-documentation"></a>リファレンス ドキュメント
テスト API は、次の名前空間に存在します。 すべての API は、グローバルな `SecureBrowser` オブジェクトに依存する点に注意してください。

| 名前空間 | 説明 |
|-----------|-------------|
|[セキュリティ名前空間](#security-namespace)|テストのためにデバイスをロックダウンし、テスト環境を強化できるようにする API が含まれます。 |

### <a name="security-namespace"></a>セキュリティ名前空間

セキュリティ名前空間を使用すると、デバイスをロックダウン、ユーザーとシステム プロセスの一覧の確認、MAC および IP アドレスの取得およびキャッシュされている web リソースをクリアできます。

| メソッド | 説明   |
|--------|---------------|
|[lockDown](#lockDown) | テストのためにデバイスをロックダウンします。 |
|[isEnvironmentSecure](#isEnvironmentSecure) | ロックダウン コンテキストがデバイスにまだ適用されるかどうかを確認します。 |
|[getDeviceInfo](#getDeviceInfo) | テスト アプリケーションが実行されているプラットフォームの詳細を取得します。 |
|[examineProcessList](#examineProcessList)|実行中のユーザーとシステム プロセスの一覧を取得します。|
|[close](#close) | ブラウザーを閉じて、デバイスのロックを解除します。 |
|[getPermissiveMode](#getPermissiveMode)|制限解除モードがオンまたはオフかどうかを確認します。|
|[setPermissiveMode](#setPermissiveMode)|制限解除モードのオンとオフを切り替えます。|
|[emptyClipBoard](#emptyClipBoard)|システム クリップボードがクリアされます。|
|[getMACAddress](#getMACAddress)|デバイスの MAC アドレスの一覧を取得します。|
|[getStartTime](#getStartTime) | テスト アプリが開始された時刻を取得します。 |
|[getCapability](#getCapability) | 機能が有効であるか、無効であるかを照会します。 |
|[setCapability](#setCapability)|指定された機能を有効または無効にします。| 
|[isRemoteSession](#isRemoteSession) | 現在のセッションがリモートからログインされているかどうかを確認します。 |
|[isVMSession](#isVMSession) | 現在のセッションが、仮想マシンで実行されているかどうかを確認します。 |

---

<span id="lockDown"/>

### <a name="lockdown"></a>lockDown
デバイスをロックダウンします。 デバイスのロック解除にも使用します。 テスト Web アプリケーションは、受講者がテストを開始できるようにする前にこの呼び出しを起動します。 この実装は、テスト環境をセキュリティで保護するために必要なすべてのアクションを実行するために必要です。 環境をセキュリティで保護するために実行する手順はデバイス固有です。この手順には、たとえば、画面のキャプチャを無効にする、保護モードのときにボイス チャットを無効にする、システム クリップボードをクリアする、キオスク モードに移行する、OSX 10.7 以降のデバイスでスペースを無効にするなどの側面が含まれます。テスト アプリケーションは、評価が開始する前にロックダウンを有効にし、受講者が評価を完了してセキュリティ保護されたテストを終了したときにロックダウンを無効にします。

**構文**  
`void SecureBrowser.security.lockDown(Boolean enable, Function onSuccess, Function onError);`

**パラメーター**  
* `enable` - **true** は、ロック画面上でテスト アプリを実行し、この[ドキュメント](https://technet.microsoft.com/edu/windows/take-a-test-app-technical?f=255&MSPPError=-2147217396)で説明されているポリシーを適用します。 **false** は、アプリがロックダウンされていない場合は、ロック画面上で実行しているテスト アプリを停止して閉じます。アプリがロックダウンされている場合は、何も行われません。  
* `onSuccess` - [オプション] ロックダウンが正常に有効または無効にされた後で呼び出す関数です。 `Function(Boolean currentlockdownstate)` という形式にする必要があります。  
* `onError` - [オプション] ロックダウン操作に失敗した場合に呼び出す関数です。 `Function(Boolean currentlockdownstate)` という形式にする必要があります。  

**要件**  
Windows 10 バージョン 1709

---

<span id="isEnvironmentSecure" />

### <a name="isenvironmentsecure"></a>isEnvironmentSecure
ロックダウン コンテキストがデバイスにまだ適用されるかどうかを確認します。 テスト Web アプリケーションは、受講者がテストを開始できるようにする前に、また受講者がテスト内にいる場合に定期的にこれを呼び出します。

**構文**  
`void SecureBrowser.security.isEnvironmentSecure(Function callback);`

**パラメーター**  
* `callback` - この関数が完了したときに呼び出す関数です。 `Function(String state)` という形式にする必要があります。ここでは、`state` は 2 つのフィールドを含む JSON 文字列です。 1 つ目は `secure` フィールドで、必要なすべてのロックが有効化 (または機能が無効化) され、テスト環境をセキュリティ保護できるようにする場合にのみ `true` を表示します。アプリがロックダウン モードに入ってから、いずれのロックも侵害されていません。 もう 1 つのフィールド `messageKey` には、その他の詳細またはベンダー固有の情報が含まれます。 ここでの意図は、ベンダーがブール値 `secure` フラグを強化する追加の情報を含めることができるようにすることです。

```JSON
{
    'secure' : "true/false",
    'messageKey' : "some message"
}
```

**要件**  
Windows 10 バージョン 1709

---

<span id="getDeviceInfo" />

### <a name="getdeviceinfo"></a>getDeviceInfo
テスト アプリケーションが実行されているプラットフォームの詳細を取得します。 これは、ユーザー エージェントから認識できるすべての情報を拡張するために使用されます。

**構文**  
`void SecureBrowser.security.getDeviceInfo(Function callback);`

**パラメーター**  
* `callback` - この関数が完了したときに呼び出す関数です。 `Function(String infoObj)` という形式にする必要があります。ここでは、`infoObj` は複数のフィールドを含む JSON 文字列です。 次のフィールドがサポートされる必要があります。
    * `os` OS の種類を表します (例: Windows、macOS、Linux、iOS、Android)。
    * `name` 存在する場合、OS リリースの名前を表します (例: シエラ、Ubuntu)。
    * `version` OS バージョンを表します (例: 10.1、10 Pro)。
    * `brand` セキュリティで保護されたブラウザーのブランドを表します (例: OAKS、CA、SmarterApp)。
    * `model` モバイル デバイスのデバイス モデルのみを表します。デスクトップ ブラウザーに対しては null または未使用です。

**要件**  
Windows 10 バージョン 1709

---

<span id="examineProcessList" />

### <a name="examineprocesslist"></a>examineProcessList
ユーザーが所有するクライアント コンピューター上で実行されているすべてのプロセスの一覧を取得します。 テスト アプリケーションはこれを呼び出して一覧を確認し、テスト サイクル中にブラックリストの対象と見なされたプロセスの一覧と比較します。 この呼び出しは、評価の開始時と、受講者が評価を受ける間に定期的に呼び出される必要があります。 ブラックリストに追加したプロセスが検出された場合は、テストの整合性を保つために評価を停止する必要があります。

**構文**  
`void SecureBrowser.security.examineProcessList(String[] blacklistedProcessList, Function callback);`

**パラメーター**  
* `blacklistedProcessList` - テスト アプリケーションがブラック リストに追加した評価の一覧です。  
`callback` - アクティブなプロセスが見つかった後で呼び出す関数です。 `Function(String foundBlacklistedProcesses)` という形式にする必要があります。ここでは、`foundBlacklistedProcesses` は `"['process1.exe','process2.exe','processEtc.exe']"` という形式になります。 ブラック リストに追加されたプロセスが見つからなかった場合は、空になります。 Null の場合、元の関数呼び出しでエラーが発生したことを示します。

**解説** 一覧にはシステム プロセスは含まれません。

**要件**  
Windows 10 バージョン 1709

---

<span id="close"/>

### <a name="close"></a>close
ブラウザーを閉じて、デバイスのロックを解除します。 ユーザーがブラウザーを終了するときに、テスト アプリケーションでこれを呼び出す必要があります。

**構文**  
`void SecureBrowser.security.close(restart);`

**パラメーター**  
* `restart` - このパラメーターは無視されますが、指定する必要があります。

**解説** Windows 10 バージョン 1607 では、最初にデバイスをロックダウンする必要があります。 以降のバージョンでは、このメソッドは、デバイスがロックダウンされているかどうかに関係なく、ブラウザーを閉じます。

**要件**  
Windows 10 バージョン 1709

---

<span id="getPermissiveMode" />

### <a name="getpermissivemode"></a>getPermissiveMode
テスト Web アプリケーションは、制限解除モードがオンまたはオフかどうかを判断するためにこれを呼び出す必要があります。 制限解除モードで、ブラウザーは、いくつかのセキュリティで保護された厳格なフックを緩和し、支援技術がセキュリティ保護されたブラウザーで動作できるようにすることが求められます。 たとえば、他のアプリケーション UI がブラウザーの最上位に表示されるのを積極的に防止するブラウザーでは、制限解除モードのときにこれを緩和する必要があります。 

**構文**  
`void SecureBrowser.security.getPermissiveMode(Function callback)`

**パラメーター**  
* `callback` - この呼び出しが完了したときに呼び出す関数です。 `Function(Boolean permissiveMode)` という形式にする必要があります。ここでは、`permissiveMode` はブラウザーが現在、制限解除モードであるかどうかを示します。 定義されていないか null の場合は、Get 操作でエラーが発生しました。

**要件**  
Windows 10 バージョン 1709

---

<span id="setPermissiveMode" />

### <a name="setpermissivemode"></a>setPermissiveMode
テストの Web アプリケーションには、寛容モードのオンとオフを切り替えるのにこれを呼び出す必要があります。 制限解除モードで、ブラウザーは、いくつかのセキュリティで保護された厳格なフックを緩和し、支援技術がセキュリティ保護されたブラウザーで動作できるようにすることが求められます。 たとえば、他のアプリケーション UI がブラウザーの最上位に表示されるのを積極的に防止するブラウザーでは、制限解除モードのときにこれを緩和する必要があります。 

**構文**  
`void SecureBrowser.security.setPermissiveMode(Boolean enable, Function callback)`

**パラメーター**  
* `enable` - 目的の制限解除モードの状態を示すための Boolean 値。  
* `callback` - この呼び出しが完了したときに呼び出す関数です。 `Function(Boolean permissiveMode)` という形式にする必要があります。ここでは、`permissiveMode` はブラウザーが現在、制限解除モードであるかどうかを示します。 定義されていないか null の場合は、Set 操作でエラーが発生しました。

**要件**  
Windows 10 バージョン 1709

---

<span id="emptyClipBoard"/>

### <a name="emptyclipboard"></a>emptyClipBoard
システム クリップボードがクリアされます。 テスト アプリケーションは、これを呼び出して、システム クリップボードに保存されている可能性があるデータを強制的にクリアする必要があります。 **[lockDown](#lockDown)** 関数もこの操作を実行します。

**構文**  
`void SecureBrowser.security.emptyClipBoard();`

**要件**  
Windows 10 バージョン 1709

---

<span id="getMACAddress" />

### <a name="getmacaddress"></a>getMACAddress
デバイスの MAC アドレスの一覧を取得します。 テスト アプリケーションは、これを呼び出して診断で役立てる必要があります。 

**構文**  
`void SecureBrowser.security.getMACAddress(Function callback);`

**パラメーター**  
* `callback` - この呼び出しが完了したときに呼び出す関数です。 `Function(String addressArray)` という形式にする必要があります。ここでは、`addressArray` は `"['00:11:22:33:44:55','etc']"` という形式です。

**コメント**  
ファイアウォール/NAT/プロキシは通常、学校で使用されるため、テスト サーバー内でエンド ユーザーのコンピューターを区別するために、ソース IP アドレスに依存するのは困難です。 MAC アドレスは、診断のために、一般的なファイアウォールの背後にあるエンド クライアント コンピューターをアプリが区別できるようにします。

**要件**  
Windows 10 バージョン 1709

---

<span id="getStartTime" />

### <a name="getstarttime"></a>getStartTime
テスト アプリが開始された時刻を取得します。

**構文**  
`DateTime SecureBrowser.settings.getStartTime();`

**戻り値**  
テスト アプリが開始された日時を示す DateTime オブジェクト。

**要件**  
Windows 10 バージョン 1709

---

<span id="getCapability"/>

### <a name="getcapability"></a>getCapability
機能が有効であるか、無効であるかを照会します。 

**構文**  
`Object SecureBrowser.security.getCapability(String feature)`

**パラメーター**  
`feature` - 照会する機能を特定する文字列。 有効な機能の文字列は、"screenMonitoring"、"printing"、"textSuggestions" (大文字と小文字を区別しない) です。

**戻り値**  
この関数は、JavaScript Object または `{<feature>:true|false}` の形式のリテラルのいずれかを返します。 照会した機能が有効である場合は **true**、機能が有効になっていないか、機能の文字列が正しくない場合は **false**。

**要件** Windows 10 バージョン 1703

---

<span id="setCapability"/>

### <a name="setcapability"></a>setCapability
特定の機能をブラウザーで有効または無効にします。

**構文**  
`void SecureBrowser.security.setCapability(String feature, String value, Function onSuccess, Function onError)`

**パラメーター**  
* `feature` - 設定する機能を特定する文字列。 有効な機能の文字列は、`"screenMonitoring"`、`"printing"`、`"textSuggestions"` (大文字と小文字を区別しない) です。  
* `value` - 機能の目的の設定です。 `"true"` または `"false"` にする必要があります。  
* `onSuccess` - [オプション] Set 操作の後に呼び出す関数は、正常に完了しました。 `Function(String jsonValue)` という形式にする必要があります。ここでは、*jsonValue* は `{<feature>:true|false|undefined}` という形式です。  
* `onError` - [オプション] Set 操作に失敗した場合に呼び出す関数です。 `Function(String jsonValue)` という形式にする必要があります。ここでは、*jsonValue* は `{<feature>:true|false|undefined}` という形式です。

**コメント**  
対象となる機能がブラウザーに不明である場合、この関数は `undefined` の値をコールバック関数に渡します。

**要件** Windows 10 バージョン 1703

---

<span id="isRemoteSession"/>

### <a name="isremotesession"></a>isRemoteSession
現在のセッションがリモートからログインされているかどうかを確認します。

**構文**  
`Boolean SecureBrowser.security.isRemoteSession();`

**戻り値**  
現在のセッションがリモートの場合は **true**、それ以外の場合は **false** です。

**要件**  
Windows 10 バージョン 1709

---

<span id="isVMSession"/>

### <a name="isvmsession"></a>isVMSession
現在のセッションが、仮想マシン内で実行されているかどうかを確認します。

**構文**  
`Boolean SecureBrowser.security.isVMSession();`

**戻り値**  
現在のセッションが仮想マシンで実行されている場合は **true**、それ以外の場合は **false** です。

**コメント**  
この API のチェックは、適切な API を実装している特定のハイパーバイザーで実行されている VM セッションのみを検出できます。

**要件**  
Windows 10 バージョン 1709

---