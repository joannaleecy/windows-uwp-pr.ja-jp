---
author: mijacobs
Description: "プログラムを使って、アプリをタスク バーにピン留めすることができます。また現在ピン留めされているかどうかを確認できます。"
title: "アプリをタスク バーにピン留めする"
template: detail.hbs
ms.author: mijacobs
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, タスク バー、タスク バー マネージャー、タスク バーにピン留め、プライマリ タイル"
ms.openlocfilehash: c12a84250454b6f3934f4985d6b6bc9421ce7470
ms.sourcegitcommit: ae93435e1f9c010a054f55ed7d6bd2f268223957
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/10/2017
---
# <a name="pin-your-app-to-the-taskbar"></a>アプリをタスク バーにピン留めする

[アプリをスタート メニューにピン留め](tiles-and-notifications-primary-tile-apis.md)できるのと同様に、プログラムを使ってアプリをタスク バーにピン留めすることができます。 アプリが現在ピン留めされているかどうか、またタスク バーがピン留めを許可しているかどうかを確認できます。 

![タスク バー](images/taskbar/taskbar.png)

> [!IMPORTANT]
> **プレリリース | Fall Creators Update が必要**: タスク バー API を使うには、[Insider SDK 16225](https://www.microsoft.com/en-us/software-download/windowsinsiderpreviewSDK) をターゲットとし、[Insider ビルド 16226](https://blogs.windows.com/windowsexperience/2017/06/21/announcing-windows-10-insider-preview-build-16226-pc/) 以降を実行している必要があります。

> **重要な API**: [TaskbarManager クラス](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager) 


## <a name="when-should-you-ask-the-user-to-pin-your-app-to-the-taskbar"></a>アプリのタスク バーへのピン留めをユーザーに確認する 

[TaskbarManager クラス](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager)を使うと、アプリのタスク バーへのピン留めをユーザーに確認できます。ユーザーは要求を承認する必要があります。 多くの労力をかけて優れたアプリを作成したら、ユーザーにそのアプリをタスク バーにピン留めするように求めることができます。 コードについて詳しく説明する前に、エクスペリエンスを設計するときの注意点を示します。

* "タスク バーへのピン留め" を実行するよう明確に呼びかける、スムーズで簡単に閉じることができる UX をアプリで作成すること。**** このためには、ダイアログとポップアップを使用しないようにします。 
* アプリをピン留めするようユーザーに要求する前に、アプリのピン留めの価値について明確に説明すること。****
* タイルが既にピン留めされているか、デバイスでピン留めがサポートされていない場合、アプリをピン留めするようユーザーに要求しないこと。**** (この記事では、ピン留めがサポートされているかどうかを判別する方法を説明します。)
* アプリをピン留めするようユーザーに繰り返し要求しないこと (ユーザーが不快になる恐れがあります)。****
* 明示的なユーザー操作を必要としない場合や、アプリが最小化されているか開いていないときに、ピン留めの API を呼び出さないこと。****


## <a name="1-check-whether-the-required-apis-exist"></a>1. 必要な API が存在するかどうかを確認する

アプリで Windows 10 の以前のバージョンをサポートする場合は、TaskbarManager クラスが利用できるかどうかを確認する必要があります。 [ApiInformation.IsTypePresent メソッド](https://docs.microsoft.com/en-us/uwp/api/windows.foundation.metadata.apiinformation#Windows_Foundation_Metadata_ApiInformation_IsTypePresent_System_String_)を使ってこの確認を行えます。 TaskbarManager クラスを利用できない場合は、API への呼び出しを実行しないでください。

```csharp
if (ApiInformation.IsTypePresent("Windows.UI.Shell.TaskbarManager"))
{
    // Taskbar APIs exist!
}

else
{
    // Older version of Windows, no taskbar APIs
}
```


## <a name="2-check-whether-taskbar-is-present-and-allows-pinning"></a>2. タスク バーが存在し、ピン留めを使用できるかどうかを確認する

UWP アプリはさまざまなデバイスで実行できます。それらのすべてがタスク バーをサポートするとは限りません。 現時点では、デスクトップ デバイスのみがタスク バーをサポートしています。 

タスク バーが利用できる場合でも、ユーザーのコンピューターのグループ ポリシーにより、タスク バーのピン留めが無効になっている場合があります。 そのため、アプリをピン留めする前に、タスク バーへのピン留めがサポートされているかどうかを確認する必要があります。 [TaskbarManager.IsPinningAllowed プロパティ](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager#Windows_UI_Shell_TaskbarManager_IsPinningAllowed)は、タスク バーが存在してピン留めを使用できる場合には true を返します。 

```csharp
// Check if taskbar allows pinning (Group Policy can disable it, or some device families don't have taskbar)
bool isPinningAllowed = TaskbarManager.GetDefault().IsPinningAllowed;
```

> [!NOTE]
> アプリのタスク バーへのピン留めを行わず、タスク バーが利用できるかどうかだけを確認するには、[TaskbarManager.IsSupported プロパティ](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager#Windows_UI_Shell_TaskbarManager_IsSupported)を使用します。


## <a name="3-check-whether-your-app-is-currently-pinned-to-the-taskbar"></a>3. アプリが現在タスク バーにピン留めされているかどうかを確認する

アプリが既にタスク バーにピン留めされている場合には、アプリのタスク バーへのピン留めをユーザーに求める意味がありません。 ユーザーに要求する前に、[TaskbarManager.IsCurrentAppPinnedAsync メソッド](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager#Windows_UI_Shell_TaskbarManager_IsCurrentAppPinnedAsync)を使うと、アプリが既にピン留めされているかどうかを確認できます。

```csharp
// Check whether your app is currently pinned
bool isPinned = await TaskbarManager.GetDefault().IsCurrentAppPinnedAsync();

if (isPinned)
{
    // The app is already pinned--no point in asking to pin it again!
}
else 
{
    //The app is not pinned. 
}
```


##  <a name="4-pin-your-app"></a>4. アプリをピン留めする

タスク バーが存在し、ピン留めが許可されており、アプリが現在ピン留めされていない場合には、ユーザーがアプリをピン留めできることをユーザーに知らせる、控えめなヒントを表示することができます。 たとえば、UI のどこかにピンのアイコンを表示して、ユーザーがクリックできるようにすることができます。 

ユーザーがピン留めのお勧めの UI をクリックした場合、[TaskbarManager.RequestPinCurrentAppAsync メソッド](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager#Windows_UI_Shell_TaskbarManager_RequestPinCurrentAppAsync)を呼び出すことができます。 このメソッドにより、アプリをタスク バーにピン留めするかどうかの確認を求めるダイアログがユーザーに表示されます。

> [!IMPORTANT]
> これは、フォアグラウンド UI スレッドから呼び出す必要があります。それ以外の場合は例外がスローされます。

```csharp
// Request to be pinned to the taskbar
bool isPinned = await TaskbarManager.GetDefault().RequestPinCurrentAppAsync();
```

![ピン留めのダイアログ](images/taskbar/pin-dialog.png)

このメソッドは、アプリがタスク バーにピン留めされたかどうかを示す、ブール値を返します。 アプリが既にピン留めされている場合は、このメソッドは、ユーザーにダイアログを表示せずに、すぐに true を返します。 ユーザーがダイアログで [いいえ] をクリックしたか、アプリをタスク バーにピン留めすることが許可されていない場合、メソッドは false を返します。 ユーザーが [はい] をクリックすると、アプリがピン留めされ、API から true が返されます。


## <a name="resources"></a>リソース

* [GitHub での完全なコード サンプル](https://github.com/WindowsNotifications/quickstart-pin-to-taskbar)
* [TaskbarManager クラス](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager)
* [スタート メニューにアプリをピン留めする](tiles-and-notifications-primary-tile-apis.md)
* [タイル、バッジ、および通知](tiles-badges-notifications.md)