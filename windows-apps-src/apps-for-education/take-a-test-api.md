---
author: TylerMSFT
Description: "Microsoft テスト アプリ用の JavaScript API を使用すると、セキュリティ保護された評価を行うことができます。 テスト アプリでは、学生がテスト中に他のコンピューターやインターネットのリソースを使用することを防ぐセキュリティ保護されたブラウザーが提供されます。"
title: "テスト JavaScript API。"
ms.author: twhitney
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.assetid: 9bff6318-504c-4d0e-ba80-1a5ea45743da
ms.openlocfilehash: e308280fcecf825061ddf503ce91f8607fcece72
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
# <a name="take-a-test-javascript-api"></a>テスト JavaScript API

[テスト](https://technet.microsoft.com/edu/windows/take-tests-in-windows-10)は、重大な影響をもたらすテストに対応した、厳正なオンライン評価を提供するブラウザー ベースのアプリです。 テスト アプリは、重要な全米共通学力テストに対する SBAC ブラウザー API 標準をサポートするので、Windows をロックダウンする方法ではなくコンテンツの評価に集中することができます。

Microsoft Edge ブラウザーを利用するテストでは、JavaScript API を Web アプリケーションで使用すると、テストを実施するためのロックダウンされた環境を提供できます。

[Common Core SBAC API](http://www.smarterapp.org/documents/SecureBrowserRequirementsSpecifications_0-3.pdf) に基づく API では、音声合成機能、およびデバイスがロックダウンされているか、どのユーザー プロセスとシステム プロセスを実行しているかなどを確認するための機能が提供されます。

アプリ自体については、「[テスト アプリ技術リファレンス](https://technet.microsoft.com/edu/windows/take-a-test-app-technical)」をご覧ください。

> [!Important]
> これらの API はリモート セッションでは動作しません。  

トラブルシューティングについては、「[イベント ビューアーを使用して、Microsoft テストをトラブルシューティングする](troubleshooting.md)」をご覧ください。

## <a name="reference-documentation"></a>リファレンス ドキュメント
テスト API は、次の名前空間で構成されます。 

| 名前空間 | 説明 |
|-----------|-------------|
|[セキュリティ名前空間](#security-namespace)|デバイスをロックダウンできるようにします|
|[TTS 名前空間](#tts-namespace)|音声合成機能|


 ### <a name="security-namespace"></a>セキュリティ名前空間

セキュリティ名前空間を使用すると、デバイスのロックダウン、ユーザー プロセスとシステム プロセスの一覧の確認、MAC および IP アドレスの取得、キャッシュされている Web リソースのクリアを行うことができます。

| メソッド | 説明   |
|--------|---------------|
|[clearCache](#clearCache) | キャッシュされている Web リソースをクリアします |
|[close](#close) | ブラウザーを閉じて、デバイスのロックを解除します |
|[enableLockDown](#enableLockDown) | デバイスをロックダウンします。 デバイスのロック解除にも使用します |
|[getIPAddressList](#getIPAddressList) | デバイスの IP アドレスの一覧を取得します |
|[getMACAddress](#getMACAddress)|デバイスの MAC アドレスの一覧を取得します|
|[getProcessList](#getProcessList)|実行中のユーザーとシステム プロセスの一覧を取得します|
|[isEnvironmentSecure](#isEnvironmentSecure)|ロックダウン コンテキストがデバイスにまだ適用されるかどうかを確認します|  

---
<span id="clearCache"/>
### <a name="void-clearcache"></a>void clearCache()
キャッシュされている Web リソースをクリアします。

**構文**  
`browser.security.clearCache();`

**パラメーター**  
`None`

**戻り値**  
`None`

**要件**  
Windows 10 Version 1607

---

<span id="close"/>
### <a name="closeboolean-restart"></a>close(boolean restart)
ブラウザーを閉じて、デバイスのロックを解除します。

**構文**  
`browser.security.close(false);`

**パラメーター**  
`restart` - このパラメーターは無視されますが、指定する必要があります。

**戻り値**  
`None`

**要件**  
Windows 10 Version 1607

---

<span id="enableLockDown"/>
### <a name="enablelockdownboolean-lockdown"></a>enableLockdown(boolean lockdown)
デバイスをロックダウンします。 デバイスのロック解除にも使用します。

**構文**  
`browser.security.enableLockDown(true|false);`

**パラメーター**  
`lockdown` - `true` は、ロック画面上でテスト アプリを実行し、この[ドキュメント](https://technet.microsoft.com/edu/windows/take-a-test-app-technical?f=255&MSPPError=-2147217396)で説明されているポリシーを適用します。 `False` は、アプリがロックダウンされていない場合は、ロック画面上で実行しているテスト アプリを停止して閉じます。アプリがロックダウンされている場合は、何も行われません。

**戻り値**  
`None`

**要件**  
Windows 10 Version 1607

---

<span id="getIPAddressList"/>
### <a name="string-getipaddresslist"></a>string[] getIPAddressList()
デバイスの IP アドレスの一覧を取得します。

**構文**  
`browser.security.getIPAddressList();`

**パラメーター**  
`None`

**戻り値**  
`An array of IP addresses.`

---

<span id="getMACAddress" />
### <a name="string-getmacaddress"></a>string[] getMACAddress()
デバイスの MAC アドレスの一覧を取得します。

**構文**  
`browser.security.getMACAddress();`

**パラメーター**  
`None`

**戻り値**  
`An array of MAC addresses.`

**要件**  
Windows 10 Version 1607

---

<span id="getProcessList" />
### <a name="string-getprocesslist"></a>string[] getProcessList()
ユーザーの実行中プロセスの一覧を取得します。

**構文**  
`browser.security.getProcessList();`

**パラメーター**  
`None`

**戻り値**  
`An array of running process names.`

**解説** 一覧にはシステム プロセスは含まれません。

**要件**  
Windows 10 Version 1607

---

<span id="isEnvironmentSecure" />
### <a name="boolean-isenvironmentsecure"></a>boolean isEnvironmentSecure()
ロックダウン コンテキストがデバイスにまだ適用されるかどうかを確認します。

**構文**  
`browser.security.isEnvironmentSecure();`

**パラメーター**  
`None`

**戻り値**  
`True indicates that the lockdown context is applied to the device; otherwise false.`

**要件**  
Windows 10 Version 1607

---

### <a name="tts-namespace"></a>TTS 名前空間

TTS 名前空間は、アプリの音声合成機能を処理します。

| メソッド | [説明] |
|--------|-------------|
|[getStatus](#getStatus) | 音声の再生状態を取得します|
|[getVoices](#getVoices) | 利用可能な音声パックの一覧を取得します|
|[pause](#pause)|音声の合成を一時停止します|
|[resume](#resume)|一時停止されている音声の合成を再開します|
|[speak](#speak)|クライアント側の音声合成|
|[stop](#stop)|音声合成を停止します|

> [!Tip]
> [Microsoft Edge 音声合成 API](https://blogs.windows.com/msedgedev/2016/06/01/introducing-speech-synthesis-api/) は [W3C Speech API](https://dvcs.w3.org/hg/speech-api/raw-file/tip/webspeechapi.html) の実装であり、可能な場合は、開発者はこの API を使用することをお勧めします。

---

<span id="getStatus" />
### <a name="string-getstatus"></a>string getStatus()
音声の再生状態を取得します。

**構文**  
`browser.tts.getStatus();`

**パラメーター**  
`None`

**戻り値**  
`The speech playback status. Possible values are: “available”, “idle”, “paused”, and “speaking”.`

**要件**  
Windows 10 Version 1607

---

<span id="getVoices" />
### <a name="string-getvoices"></a>string[] getVoices()
利用可能な音声パックの一覧を取得します。

**構文**  
`browser.tts.getVoices();`

**パラメーター**  
`None`

**戻り値**  
`The available voice packs. For example: “Microsoft Zira Mobile”, “Microsoft Mark Mobile”`

**要件**  
Windows 10 Version 1607

---

<span id="pause" />
### <a name="void-pause"></a>void pause()

音声の合成を一時停止します。

**構文**  
`browser.tts.pause();`

**パラメーター**

`None`

**戻り値**

`None`

**要件**  
Windows 10 Version 1607

---

<span id="resume" />
### <a name="void-resume"></a>void resume()
一時停止されている音声の合成を再開します。

**構文**  
`browser.tts.resume();`

**パラメーター**
`None`

**戻り値**
`None`

**要件**  
Windows 10 Version 1607

---

<span id="speak" />
### <a name="void-speakstring-text-object-options-function-callback"></a>void speak(string text, object options, function callback)
クライアント側の音声合成を開始します。

**構文**  
`void browser.tts.speak(“Hello world”, options, callback);`

**パラメーター**  
`Speech options such as gender, pitch, rate, volume. For example:`  
```
var options = {
   'gender': this.currentGender,
   'language': this.currentLanguage,
   'pitch': 1,
   'rate': 1,
   'voice': this.currentVoice,
   'volume': 1
};
```

**戻り値**  
`None`

**解説** オプションの変数は小文字にする必要があります。 gender、language、voice パラメーターは文字列を受け取ります。
volume、pitch、rate は、options オブジェクト内ではなく、Speech Synthesis Markup Language (SSML) ファイル内でマークアップする必要があります。
options オブジェクトは、上に示した順序、命名、大文字と小文字の使い分けに従う必要があります。

**要件**  
Windows 10 Version 1607

---

<span id="stop" />
### <a name="void-stop"></a>void stop()
音声の合成を停止します。

**構文**  
`void browser.tts.speak(“Hello world”, options, callback);`

**パラメーター**  
`None`

**戻り値**  
`None`

**要件**  
Windows 10 Version 1607
