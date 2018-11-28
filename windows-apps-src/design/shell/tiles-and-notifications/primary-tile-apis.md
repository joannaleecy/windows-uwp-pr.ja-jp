---
Description: You can programmatically pin your own app's primary tile to Start, just like you can pin secondary tiles. And you can check whether it's currently pinned.
title: プライマリ タイル API
label: Primary tile API's
template: detail.hbs
ms.date: 05/19/2017
ms.topic: article
keywords: Windows 10, UWP, StartScreenManager, プライマリ タイルをピン留めする, プライマリ タイル API, タイルのピン留めの確認, ライブ タイル
ms.localizationpriority: medium
ms.openlocfilehash: 04d7c66b358a3a465522ad3b56d8ae926358ae57
ms.sourcegitcommit: b11f305dbf7649c4b68550b666487c77ea30d98f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/27/2018
ms.locfileid: "7828044"
---
# <a name="primary-tile-apis"></a>プライマリ タイル API
 

プライマリ タイル API を使うと、スタートにアプリが現在ピン留めされているかどうかを確認して、アプリのプライマリ タイルのピン留めを要求できます。

> [!IMPORTANT]
> **Creators Update が必要**: プライマリ タイル API を使用するには、SDK 15063 以降をターゲットとし、ビルド 15063 以降を実行している必要があります。

> **重要な API**: [**StartScreenManager クラス**](https://docs.microsoft.com/uwp/api/windows.ui.startscreen.startscreenmanager)、[ContainsAppListEntryAsync](https://docs.microsoft.com/uwp/api/windows.ui.startscreen.startscreenmanager#Windows_UI_StartScreen_StartScreenManager_ContainsAppListEntryAsync_Windows_ApplicationModel_Core_AppListEntry_)、[RequestAddAppListEntryAsync](https://docs.microsoft.com/uwp/api/windows.ui.startscreen.startscreenmanager#Windows_UI_StartScreen_StartScreenManager_RequestAddAppListEntryAsync_Windows_ApplicationModel_Core_AppListEntry_)


## <a name="when-to-use-primary-tile-apis"></a>プライマリ タイル API を使う状況

アプリのプライマリ タイルに対する優れたエクスペリエンスの設計に多くの労力をかけたので、アプリのプライマリ タイルをスタート画面にピン留めするようユーザーに要求できるようになりました。 ただし、コードについて詳しく説明する前に、エクスペリエンスを設計するときの注意点を示します。

* アプリに "ライブ タイルのピン留め" を実行するよう明確に呼びかける、スムーズで簡単に無視できる UX を作成すること。****
* アプリのライブ タイルをピン留めするようユーザーに要求する前に、アプリのライブ タイルの価値について明確に説明すること。****
* タイルが既にピン留めされているか、デバイスでピン留めがサポートされていない場合、アプリのタイルをピン留めするようユーザーに要求しないこと (詳しくは後で説明します)。****
* アプリのタイルをピン留めするようユーザーに繰り返し要求しないこと (ユーザーが不快になる恐れがあります)。****
* 明示的なユーザー操作を必要としない場合や、アプリが最小化されているか開いていないときに、ピン留めの API を呼び出さないこと。****


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
> アプリが、フォア グラウンドでは、(たとえばの後、ユーザーは、タイルのピン留めについてのヒントに [はい] をクリックして) ユーザーがプライマリ タイル bepinned 要求した意図的にこの APIafterthe のみを呼び出す必要があります、UI スレッドからこの API を呼び出す必要があります。

ユーザーがプライマリ タイルをピン留めするボタンをクリックしたら、[RequestAddAppListEntryAsync](https://docs.microsoft.com/uwp/api/windows.ui.startscreen.startscreenmanager#Windows_UI_StartScreen_StartScreenManager_RequestAddAppListEntryAsync_Windows_ApplicationModel_Core_AppListEntry_) メソッドを呼び出して、タイルがスタート画面にピン留めされるよう要求します。 これにより、タイルをスタート画面にピン留めするかどうかの確認を求めるダイアログがユーザーに表示されます。

タイルがスタート画面にピン留めされたかどうかを表すブール値が返されます。 タイルが既にピン留めされている場合は、ユーザーにダイアログを表示せずに、すぐに true が返されます。 ユーザーがダイアログで [いいえ] をクリックしたか、タイルをスタート画面にピン留めすることがサポートされていない場合、false が返されます。 その他の場合は、ユーザーが [はい] をクリックしてタイルがピン留めされ、API から true が返されます。

```csharp
// Get your own app list entry
AppListEntry entry = (await Package.Current.GetAppListEntriesAsync())[0];

// And pin it to Start
bool isPinned = await StartScreenManager.GetDefault().RequestAddAppListEntryAsync(entry);
```


## <a name="resources"></a>リソース

* [GitHub での完全なコード サンプル](https://github.com/WindowsNotifications/quickstart-pin-primary-tile)
* [タスク バーにピン留めする](../pin-to-taskbar.md)
* [タイル、バッジ、および通知](index.md)
* [アダプティブ タイルのドキュメント](create-adaptive-tiles.md)
