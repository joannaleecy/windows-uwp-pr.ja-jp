---
Description: セカンダリ タイルをスタート画面にピン留めできるのと同様、独自のアプリのプライマリ タイルをプログラムでスタート画面にピン留めできます。 また、現在ピン留めされているかどうかを確認できます。
title: プライマリ タイル API
label: Primary tile API's
template: detail.hbs
ms.date: 05/19/2017
ms.topic: article
keywords: Windows 10, UWP, StartScreenManager, プライマリ タイルをピン留めする, プライマリ タイル API, タイルのピン留めの確認, ライブ タイル
ms.localizationpriority: medium
ms.openlocfilehash: 04d7c66b358a3a465522ad3b56d8ae926358ae57
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57596197"
---
# <a name="primary-tile-apis"></a>プライマリ タイル API
 

プライマリ タイル API を使うと、スタートにアプリが現在ピン留めされているかどうかを確認して、アプリのプライマリ タイルのピン留めを要求できます。

> [!IMPORTANT]
> **Creators Update が必要です**:SDK 15063 を対象にして、15063 以降、プライマリ タイル Api を使用するビルドを実行します。

> **重要な API**:[**StartScreenManager クラス**](https://docs.microsoft.com/uwp/api/windows.ui.startscreen.startscreenmanager)、 [ContainsAppListEntryAsync](https://docs.microsoft.com/uwp/api/windows.ui.startscreen.startscreenmanager#Windows_UI_StartScreen_StartScreenManager_ContainsAppListEntryAsync_Windows_ApplicationModel_Core_AppListEntry_)、 [RequestAddAppListEntryAsync](https://docs.microsoft.com/uwp/api/windows.ui.startscreen.startscreenmanager#Windows_UI_StartScreen_StartScreenManager_RequestAddAppListEntryAsync_Windows_ApplicationModel_Core_AppListEntry_)


## <a name="when-to-use-primary-tile-apis"></a>プライマリ タイル API を使う状況

アプリのプライマリ タイルに対する優れたエクスペリエンスの設計に多くの労力をかけたので、アプリのプライマリ タイルをスタート画面にピン留めするようユーザーに要求できるようになりました。 ただし、コードについて詳しく説明する前に、エクスペリエンスを設計するときの注意点を示します。

* **アプリに** "ライブ タイルのピン留め" を実行するよう明確に呼びかける、スムーズで簡単に無視できる UX を作成すること。
* **アプリのライブ** タイルをピン留めするようユーザーに要求する前に、アプリのライブ タイルの価値について明確に説明すること。
* **タイルが既にピ**ン留めされているか、デバイスでピン留めがサポートされていない場合、アプリのタイルをピン留めするようユーザーに要求しないこと (詳しくは後で説明します)。
* **アプリ**のタイルをピン留めするようユーザーに繰り返し要求しないこと (ユーザーが不快になる恐れがあります)。
* **明示的なユ**ーザー操作を必要としない場合や、アプリが最小化されているか開いていないときに、ピン留めの API を呼び出さないこと。


## <a name="checking-whether-the-apis-exist"></a>API が存在するかどうかを確認する

アプリで Windows 10 の以前のバージョンをサポートする場合は、プライマリ タイル API が利用できるかどうかを確認する必要があります。 これを行うには、ApiInformation を使います。 プライマリ タイル API を利用できない場合は、API への呼び出しを実行しないでください。

```csharp
if (ApiInformation.IsTypePresent("Windows.UI.StartScreen.StartScreenManager"))
{
    // Primary tile API's supported!
}
else
{
    // Older version of Windows, no primary tile API's
}
```


## <a name="check-if-start-supports-your-app"></a>スタート画面がアプリをサポートしているかどうかを確認する

現在のスタート メニューとアプリの種類によっては、現在のスタート画面にアプリをピン留めすることがサポートされていない場合があります。 プライマリ タイルをスタート画面にピン留めできるのは、Desktop と Mobile だけです。 そのため、ピンの UI を表示またはピン コードを実行する前に、まずはアプリが現在のスタート画面でサポートされているかどうかを確認する必要があります。 サポートされていない場合は、タイルをピン留めするよう求めるメッセージをユーザーに表示しないでください。

```csharp
// Get your own app list entry
// (which is always the first app list entry assuming you are not a multi-app package)
AppListEntry entry = (await Package.Current.GetAppListEntriesAsync())[0];

// Check if Start supports your app
bool isSupported = StartScreenManager.GetDefault().SupportsAppListEntry(entry);
```


## <a name="check-whether-youre-currently-pinned"></a>現在ピン留めされているかどうかを確認する

プライマリ タイルが現在スタート画面にピン留めされているかどうかを調べるには、[ContainsAppListEntryAsync](https://docs.microsoft.com/uwp/api/windows.ui.startscreen.startscreenmanager#Windows_UI_StartScreen_StartScreenManager_ContainsAppListEntryAsync_Windows_ApplicationModel_Core_AppListEntry_) メソッドを使います。

```csharp
// Get your own app list entry
AppListEntry entry = (await Package.Current.GetAppListEntriesAsync())[0];

// Check if your app is currently pinned
bool isPinned = await StartScreenManager.GetDefault().ContainsAppListEntryAsync(entry);
```


##  <a name="pin-your-primary-tile"></a>プライマリ タイルをピン留めする

プライマリ タイルが現在ピン留めされていなくて、タイルがスタート画面でサポートされている場合、プライマリ タイルをピン留めできることを伝えるヒントをユーザーに表示できます。

> [!NOTE]
> アプリがフォア グラウンドでは、(たとえば、ユーザーは、タイルをピン留めに関するヒントを [はい] クリックした) 後、プライマリ タイルがピン留めするユーザーが意図的に要求した後のみ、この API を呼び出す必要があります、UI スレッドからこの API を呼び出す必要があります。

ユーザーがプライマリ タイルをピン留めするボタンをクリックしたら、[RequestAddAppListEntryAsync](https://docs.microsoft.com/uwp/api/windows.ui.startscreen.startscreenmanager#Windows_UI_StartScreen_StartScreenManager_RequestAddAppListEntryAsync_Windows_ApplicationModel_Core_AppListEntry_) メソッドを呼び出して、タイルがスタート画面にピン留めされるよう要求します。 これにより、タイルをスタート画面にピン留めするかどうかの確認を求めるダイアログがユーザーに表示されます。

タイルがスタート画面にピン留めされたかどうかを表すブール値が返されます。 タイルが既にピン留めされている場合は、ユーザーにダイアログを表示せずに、すぐに true が返されます。 ユーザーがダイアログで [いいえ] をクリックしたか、タイルをスタート画面にピン留めすることがサポートされていない場合、false が返されます。 その他の場合は、ユーザーが [はい] をクリックしてタイルがピン留めされ、API から true が返されます。

```csharp
// Get your own app list entry
AppListEntry entry = (await Package.Current.GetAppListEntriesAsync())[0];

// And pin it to Start
bool isPinned = await StartScreenManager.GetDefault().RequestAddAppListEntryAsync(entry);
```


## <a name="resources"></a>参考資料

* [GitHub の完全なコード サンプル](https://github.com/WindowsNotifications/quickstart-pin-primary-tile)
* [タスク バーにピン留め](../pin-to-taskbar.md)
* [タイル、バッジ、通知](index.md)
* [適応型タイルのドキュメント](create-adaptive-tiles.md)
