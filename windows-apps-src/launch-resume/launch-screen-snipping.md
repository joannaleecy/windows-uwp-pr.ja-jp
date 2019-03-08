---
title: 画面切り取りの起動
description: このトピックでは、ms screenclip と ms screensketch URI スキームについて説明します。 アプリは、これらの URI スキームを使用して、切り取り領域の & スケッチのアプリを起動する場合や新しい切り取り領域を開くことができます。
ms.date: 08/09/2017
ms.topic: article
keywords: windows 10、uwp、uri、切り取り領域、スケッチ
ms.localizationpriority: medium
ms.custom: RS5
ms.openlocfilehash: 06e988387f574b74d511b14a2ebca24b0a149158
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57595387"
---
# <a name="launch-screen-snipping"></a>画面切り取りの起動

**Ms screenclip:** と**ms screensketch:** URI スキームでは、snipping またはスクリーン ショットの編集を開始できます。

## <a name="open-a-new-snip-from-your-app"></a>アプリから新しい切り取り領域を開く

**Ms screenclip:** URI は、アプリを自動的に起動し、新しい切り取り領域を開始できます。 結果として得られる、切り取り領域はユーザーのクリップボードにコピーされますが、アプリを開いてが自動的に渡されない。

**ms screenclip:** は次のパラメーターを受け取ります。

| パラメーター | 種類 | 必須 | 説明 |
| --- | --- | --- | --- |
| ソース | string | no | URI を起動したソースを示す自由形式の文字列。 |
| delayInSeconds | int | no | 1 ~ 30 の整数値。 URI の呼び出しと snipping の開始時の間の完全な秒の遅延を指定します。 |
| callbackformat | string | no | このパラメーターは使用できません。 |

## <a name="launching-the-snip--sketch-app"></a>切り取り領域とスケッチ アプリを起動します。

**Ms screensketch:** URI を使用すると、プログラムで、切り取り領域の & スケッチ アプリを起動し、注釈には、そのアプリで特定のイメージを開くことができます。

**ms screensketch:** は次のパラメーターを受け取ります。

| パラメーター | 種類 | 必須 | 説明 |
| --- | --- | --- | --- |
| sharedAccessToken | string | no | 切り取り領域の & スケッチのアプリで開くファイルを識別するトークンです。 取得した[SharedStorageAccessManager.AddFile](https://docs.microsoft.com/uwp/api/windows.applicationmodel.datatransfer.sharedstorageaccessmanager.addfile)します。 このパラメーターを省略した場合は、開いているファイルを使用せず、アプリが起動されます。 |
| secondarySharedAccessToken | string | no | 切り取り領域についてのメタデータを含む JSON ファイルを識別する文字列。 メタデータを含めることができます、 **clipPoints**フィールドに、x、y 座標の配列、または[userActivity](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.useractivity)します。 |
| ソース | string | no | URI を起動したソースを示す自由形式の文字列。 |
| IsTemporary | bool | no | 画面のスケッチを True に設定するが開いた後、ファイルを削除しようとするとします。 |

次の例では、 [LaunchUriAsync](https://docs.microsoft.com/uwp/api/Windows.System.Launcher#Windows_System_Launcher_LaunchUriAsync_Windows_Foundation_Uri_)スケッチ (&)、切り取り領域に、ユーザーのアプリからイメージを送信する方法。

```csharp

bool result = await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-screensketch:edit?source=MyApp&isTemporary=false&sharedAccessToken=2C37ADDA-B054-40B5-8B38-11CED1E1A2D"));

```

次の例では、どのようなファイルで指定された、 **secondarySharedAccessToken**パラメーターの**ms screensketch**が含まれます。

```json
{
  "clipPoints": [
    {
      "x": 0,
      "y": 0
    },
    {
      "x": 2080,
      "y": 0
    },
    {
      "x": 2080,
      "y": 780
    },
    {
      "x": 0,
      "y": 780
    }
  ],
  "userActivity": "{\"$schema\":\"http://activity.windows.com/user-activity.json\",\"UserActivity\":\"type\",\"1.0\":\"version\",\"cross-platform-identifiers\":[{\"platform\":\"windows_universal\",\"application\":\"Microsoft.MicrosoftEdge_8wekyb3d8bbwe!MicrosoftEdge\"},{\"platform\":\"host\",\"application\":\"edge.activity.windows.com\"}],\"activationUrl\":\"microsoft-edge:https://support.microsoft.com/en-us/help/13776/windows-use-snipping-tool-to-capture-screenshots\",\"contentUrl\":\"https://support.microsoft.com/en-us/help/13776/windows-use-snipping-tool-to-capture-screenshots\",\"visualElements\":{\"attribution\":{\"iconUrl\":\"https://www.microsoft.com/favicon.ico?v2\",\"alternateText\":\"microsoft.com\"},\"description\":\"https://support.microsoft.com/en-us/help/13776/windows-use-snipping-tool-to-capture-screenshots\",\"backgroundColor\":\"#FF0078D7\",\"displayText\":\"Use snipping tool to capture screenshots - Windows Help\",\"content\":{\"$schema\":\"http://adaptivecards.io/schemas/adaptive-card.json\",\"type\":\"AdaptiveCard\",\"version\":\"1.0\",\"body\":[{\"type\":\"Container\",\"items\":[{\"type\":\"TextBlock\",\"text\":\"Use snipping tool to capture screenshots - Windows Help\",\"weight\":\"bolder\",\"size\":\"large\",\"wrap\":true,\"maxLines\":3},{\"type\":\"TextBlock\",\"text\":\"https://support.microsoft.com/en-us/help/13776/windows-use-snipping-tool-to-capture-screenshots\",\"size\":\"normal\",\"wrap\":true,\"maxLines\":3}]}]}},\"isRoamable\":true,\"appActivityId\":\"https://support.microsoft.com/en-us/help/13776/windows-use-snipping-tool-to-capture-screenshots\"}"
}

```
