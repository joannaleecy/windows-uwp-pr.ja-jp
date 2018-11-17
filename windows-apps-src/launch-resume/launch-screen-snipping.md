---
author: QuinnRadich
title: 画面切り取りの起動
description: このトピックでは、ms screenclip と ms screensketch URI スキームについて説明します。 アプリは、これらの URI スキームを使用して、切り取り領域とスケッチ アプリを起動したり、新しい切り取り領域を開いたりすることができます。
ms.author: quradic
ms.date: 8/1/2017
ms.topic: article
keywords: windows 10、uwp、uri、切り取り、スケッチ
ms.localizationpriority: medium
ms.custom: RS5
ms.openlocfilehash: ef83c3b5c23b703fcd40f7e4a7570b263cbc8e00
ms.sourcegitcommit: 3257416aebb5a7b1515e107866806f8bd57845a8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/17/2018
ms.locfileid: "7163183"
---
# <a name="launch-screen-snipping"></a>画面切り取りの起動

**Ms screenclip:** と**ms screensketch:** URI スキームでは、開始 snipping やスクリーン ショットを編集することができます。

## <a name="open-a-new-snip-from-your-app"></a>アプリから新しい切り取り領域を開く

**Ms screenclip:** URI が自動的開き、新しい切り取り領域を開始するアプリを使用します。 結果として得られるの切り取り領域は、ユーザーのクリップボードにコピーされますが、開いたアプリに戻るに自動的に渡されません。

**ms screenclip:** は次のパラメーターを受け取ります。

| パラメーター | 型 | 必須かどうか | 説明 |
| --- | --- | --- | --- |
| ソース | string | いいえ | フリー フォーム URI を起動したソースを指定する文字列。 |
| delayInSeconds | int | × | 1 ~ 30 の整数値。 URI の呼び出しと snipping の開始時の間の完全な秒単位で、遅延を指定します。 |

## <a name="launching-the-snip--sketch-app"></a>切り取り領域 & スケッチ アプリを起動します。

**Ms screensketch:** URI を使用すると、プログラムで切り取り領域とスケッチのアプリを起動し、注釈をそのアプリで特定のイメージを開きます。

**ms screensketch:** は次のパラメーターを受け取ります。

| パラメーター | 型 | 必須かどうか | 説明 |
| --- | --- | --- | --- |
| sharedAccessToken | string | いいえ | 切り取り領域とスケッチ アプリで開くには、ファイルを識別するトークンです。 [SharedStorageAccessManager.AddFile](https://docs.microsoft.com/uwp/api/windows.applicationmodel.datatransfer.sharedstorageaccessmanager.addfile)から取得されます。 このパラメーターを省略すると、開いているファイルを使用せずに、アプリが起動されます。 |
| ソース | string | いいえ | フリー フォーム URI を起動したソースを指定する文字列。 |
| isTemporary | bool | × | 場合は、画面スケッチが True に設定は、開いた後、ファイルを削除しようとしています。 |

次の例では、ユーザーのアプリからの切り取り領域とスケッチに画像を送信する[LaunchUriAsync](https://docs.microsoft.com/uwp/api/Windows.System.Launcher#Windows_System_Launcher_LaunchUriAsync_Windows_Foundation_Uri_)メソッドを呼び出します。

```csharp

bool result = await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-screensketch:edit?source=MyApp&isTemporary=false&sharedAccessToken=2C37ADDA-B054-40B5-8B38-11CED1E1A2D"));

```
