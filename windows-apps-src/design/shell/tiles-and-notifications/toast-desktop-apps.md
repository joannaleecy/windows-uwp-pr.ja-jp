---
author: andrewleader
Description: Discover the different options desktop Win32 apps have for sending toast notifications
title: デスクトップ アプリからのトースト通知
label: Toast notifications from desktop apps
template: detail.hbs
ms.author: mijacobs
ms.date: 05/01/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, win32, デスクトップ, トースト通知, デスクトップ ブリッジ, トーストの送信のオプション, com サーバー, com アクティベーター, com, 偽の com, com なし, com なし, トーストの送信
ms.localizationpriority: medium
ms.openlocfilehash: 9f54519fd0ddc975c1e57c2aebde583ef971850d
ms.sourcegitcommit: d10fb9eb5f75f2d10e1c543a177402b50fe4019e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/12/2018
ms.locfileid: "4575231"
---
# <a name="toast-notifications-from-desktop-apps"></a>デスクトップ アプリからのトースト通知

デスクトップ アプリ (デスクトップ ブリッジと従来の Win32) は、ユニバーサル Windows プラットフォーム (UWP) アプリと同様の対話型トースト通知を送信できます。 ただし、異なるアクティブ化スキームのために、いくつかの異なるデスクトップ アプリのオプションがあります。

この記事では、Windows 10 でトースト通知の送信に使用するためのオプションを一覧表示します。 すべてのオプションでは、以下が完全にサポートされています。

* アクション センター内での保持
* ポップアップとアクション センター内の両方からアクティブ化可能
* EXE が実行されていないときにアクティブ化可能

## <a name="all-options"></a>すべてのオプション

次の表は、デスクトップ アプリ内のトーストをサポートするためのオプション、および対応するサポートされる機能を示しています。 この表を使用してシナリオに最適なオプションを選択します。<br/><br/>

| オプション | 視覚効果 | アクション | 入力 | プロセス内でのアクティブ化 |
| -- | -- | -- | -- | -- |
| [COM アクティベーター](#preferred-option---com-activator) | ✔️ | ✔️ | ✔️ | ✔️ |
| [COM なし / Stub CLSID](#alternative-option---no-com--stub-clsid) | ✔️ | ✔️ | ❌ | ❌ |


## <a name="preferred-option---com-activator"></a>推奨されるオプション - COM アクティベーター

これは、デスクトップ ブリッジと従来の Win32 の両方に対して機能し、すべての通知機能をサポートする推奨されるオプションです。 "COM アクティベーター" について心配することはありません。以前に COM サーバーを記述したことがない場合でも、これを非常に簡単にするライブラリ [C#](send-local-toast-desktop.md) および [C++ アプリ](send-local-toast-desktop-cpp-wrl.md)があります。<br/><br/>

| 視覚効果 | アクション | 入力 | プロセス内でのアクティブ化 |
| -- | -- | -- | -- |
| ✔️ | ✔️ | ✔️ | ✔️ |

COM アクティベーター オプションでは、アプリで次の通知テンプレートとライセンス認証の種類を使用できます。<br/><br/>

| テンプレートとライセンス認証の種類 | デスクトップ ブリッジ | 従来の Win32 |
| -- | -- | -- |
| ToastGeneric フォアグラウンド | ✔️ | ✔️ |
| ToastGeneric バックグラウンド | ✔️ | ✔️ |
| ToastGeneric プロトコル | ✔️ | ✔️ |
| レガシ テンプレート | ✔️ | ❌ |

> [!NOTE]
> COM アクティベーターを既存のデスクトップ ブリッジ アプリに追加すると、フォアグラウンド/バックグラウンドおよび従来の通知のアクティブ化により、コマンド ラインではなく COM アクティベーターがアクティブ化されます。

このオプションを使用する方法については、「[デスクトップ C# アプリからのローカル トースト通知の送信](send-local-toast-desktop.md)」または「[デスクトップ C++ WRL アプリからのローカル トースト通知の送信](send-local-toast-desktop-cpp-wrl.md)」を参照してください。


## <a name="alternative-option---no-com--stub-clsid"></a>代替オプション - COM なし / Stub CLSID

これは、COM アクティベーターを実装できない場合の代替オプションです。 ただし、入力サポート (トーストでのテキスト ボックス) やプロセス内でのアクティブ化など、いくつかの機能が犠牲になります。<br/><br/>

| 視覚効果 | アクション | 入力 | プロセス内でのアクティブ化 |
| -- | -- | -- | -- |
| ✔️ | ✔️ | ❌ | ❌ |

このオプションでは、従来の Win32 をサポートする場合、次に示すように、使用できる通知テンプレートとライセンス認証の種類がはるかに制限されます。<br/><br/>

| テンプレートとライセンス認証の種類 | デスクトップ ブリッジ | 従来の Win32 |
| -- | -- | -- |
| ToastGeneric フォアグラウンド | ✔️ | ❌ |
| ToastGeneric バックグラウンド | ✔️ | ❌ |
| ToastGeneric プロトコル | ✔️ | ✔️ |
| レガシ テンプレート | ✔️ | ❌ |

今後、このオプションを使用する方法を示すドキュメントを公開する予定です。 基本的には、デスクトップ ブリッジ アプリでは、UWP アプリで行うのと同様にトースト通知を送信します。 ユーザーがトーストをクリックすると、アプリは、トーストで指定した起動引数でコマンド ラインから起動されます。

従来の Win32 アプリでは、トースト通知を送信し、ショートカットで CLSID を指定できるように AUMID を設定します。 ランダムな GUID を指定できます。 COM サーバー/アクティベーターを追加しないでください。 "stub" COM CLSID を追加することで、アクション センターで通知が保持されます。 スタブ CLSID は他のトーストのアクティブ化を中断するため、プロトコルのアクティブ化のトーストのみを使用できる点に注意してください。 そのため、プロトコルのアクティブ化をサポートするようにアプリを更新し、トースト プロトコルで各自のアプリをアクティブ化する必要があります。


## <a name="resources"></a>リソース

* [デスクトップ C# アプリからのローカル トースト通知の送信](send-local-toast-desktop.md)
* [デスクトップ C++ WRL アプリからのローカル トースト通知の送信](send-local-toast-desktop-cpp-wrl.md)
* [トースト コンテンツのドキュメント](adaptive-interactive-toasts.md)