---
title: Xbox Live SDK の新規事項 - April 2016
author: KevinAsgari
description: Xbox Live SDK の新規事項 - April 2016
ms.assetid: a6f26ffd-f136-4753-b0cd-92b0da522d93
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: xbox live, xbox, ゲーム, uwp, windows 10, xbox one
ms.localizationpriority: medium
ms.openlocfilehash: 51c9aabc844c9971be4afec5023d55905c4261ef
ms.sourcegitcommit: e4f3e1b2d08a02b9920e78e802234e5b674e7223
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/26/2018
ms.locfileid: "4207227"
---
# <a name="whats-new-for-the-xbox-live-sdk---april-2016"></a>Xbox Live SDK の新規事項 - April 2016

2016 年 3 月に追加された内容については、「[新規事項 - March 2016](1603-whats-new.md)」を参照してください。

## <a name="os-and-tool-support"></a>OS とツールのサポート
Xbox Live SDK では、Windows 10 RTM [バージョン 10.0.10240] と Visual Studio 2015 RTM [バージョン 14.0.23107.0] がサポートされます。

## <a name="tournaments"></a>トーナメント
- Xbox Live Tournaments Tool が SDK に含まれるようになりました。  使い方に関する情報と共に、Tools ディレクトリに収められています。
- トーナメント用 API も使用できるようになりました。  Xbox::Services::Tournaments 名前空間を参照してください
- ドキュメントはプログラミング ガイドにもあります。

## <a name="documentation"></a>ドキュメント
- 「[サインインのトラブルシューティング](../using-xbox-live/troubleshooting/troubleshooting-sign-in.md)」に、サインインの失敗をデバッグするための一般的な方法と、エラー コード別の手順が示されています。
- Xbox One デベロッパー向けの[マーケットプレース](https://developer.microsoft.com/en-us/games/xbox/docs/xboxlive/xbox-live-partners/xbox-marketplace/marketplace-and-downloadable-content)に関するドキュメントは、プログラミング ガイドだけで提供されるようになりました。  UWP デベロッパーは、引き続き Windows デベロッパー センターでストアについてのドキュメントを参照してください。
- Xbox One タイトルをユニバーサル Windows プラットフォームに移行する方法については、「[XDK から UWP への Xbox Live コードの移植](../using-xbox-live/porting-xbox-live-code-from-xdk-to-uwp.md)」を参照してください。
- さまざまな Xbox Live サービス エンドポイントとシナリオへのレート制限の適用についての説明、および制限に関する情報については、「[きめ細かなレート制限](../using-xbox-live/best-practices/fine-grained-rate-limiting.md)」を参照してください。

## <a name="multiplayer-manager"></a>Multiplayer Manager
[Multiplayer Manager](../multiplayer/multiplayer-manager.md) は試験的機能ではなくなりました。  この API を使用したデベロッパーからのフィードバックが組み込まれて、API 間の整合性が向上しました。  マルチプレイヤー開発の起点として Multiplayer Manager を使用してください。複雑なマルチプレイヤー 2015 API を簡単な API で管理できます。

以下のセクションでは、API の新機能と、いくつかの大きな変更点について説明します。

#### <a name="completed-events"></a>完了イベント
すべての API には対応する ``` _competed``` イベントが存在するようになり、すべてのイベントは成功か失敗かに関係なく生成されます。 従来の動作では、タイトルが対処できるようにエラーがあったときにだけ生成されていました。 また、呼び出しはバッチ形式なので、完了時に、タイトルは複数の ```_competed``` イベントを受け取ります。

| API | 返されるイベント |
|-----|----------------|
| ```lobby_session()->set_local_member_properties``` |  ```local_member_property_write_completed ```
| ```lobby_session()->set_local_member_connection_address``` | ```local_member_connection_address_write_completed``` |
| ```lobby_session()->set_properties``` | ```session_property_write_completed``` |
| ```lobby_session()->set_synchronized_properties``` | ```session_synchronized_property_write_completed``` |
| ```lobby_session()->set_synchronized_host``` | ```synchronized_host_write_completed``` |

```game_session()``` と同じことが適用されます。

#### <a name="application-defined-context"></a>アプリケーション定義コンテキスト
オプションのアプリケーション定義コンテキストを各 set_* メソッドに渡して、マルチプレイヤー イベントを開始呼び出しに関連付けることができるようになりました。
次に例を示します。

```cpp
_XSAPIIMP xbox_live_result<void> set_properties(
        _In_ const string_t& name,
        _In_ const web::json::value& valueJson,
        _In_ context_t context = nullptr
       );
```

その後、コンテキストは ```_completed``` イベントによってタイトルに戻されます。

#### <a name="breaking-changes"></a>重要な変更

1.  両方の招待 API (```invite_friends``` & ```invite_users```) が同期するようになりました。 完了すると、invite_sent イベントを返します。

2.  ```write_synchronized_properties_and_commit``` は、名前が ```set_synchronized_properties``` に変更されました。 完了すると、```session_synchronized_property_write_completed``` イベントを返します。

3.  ```write_synchronized_host_and_commit``` は、名前が ```set_synchronized_host``` に変更されました。 完了すると、```synchronized_host_write_completed``` イベントを返します。

4.  オン ```lobby_session()```

  *削除*

```cpp
_XSAPIIMP const std::unordered_map<string_t, xbox::services:: multiplayer::multiplayer_session_tournaments_server& tournaments_server() const;
```

  *追加*

```cpp
_XSAPIIMP const std::unordered_map<string_t, xbox::services::tournaments::tournament_team_result>& tournament_team_results() const;
```

5.  オン ```game_session()```

  *削除*

```cpp
_XSAPIIMP const std::unordered_map<string_t, xbox::services:: multiplayer::multiplayer_session_tournaments_server& tournaments_server() const;
_XSAPIIMP const std::unordered_map<string_t, xbox::services:: multiplayer::multiplayer_session_arbitration_server& arbitration_server() const;
```
  *追加*

```cpp
_XSAPIIMP const std::unordered_map<string_t, multiplayer_session_reference>& tournament_teams() const;
_XSAPIIMP const std::unordered_map<string_t, xbox::services::tournaments::tournament_team_result>& tournament_team_results() const;
```

6.  イベントの種類の変更:

  *削除*

```cpp
write_pending_changes_failed,
tournament_property_changed,
arbitration_property_changed
```

  *名前変更*

  ```write_synchronized_properties_completed``` 変更後の名前 ```session_synchronized_property_write_completed```

  ```write_synchronized_host_completed``` 変更後の名前 ```synchronized_host_write_completed```
