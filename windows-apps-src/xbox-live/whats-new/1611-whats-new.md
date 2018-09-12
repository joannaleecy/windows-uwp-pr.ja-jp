---
title: Xbox Live SDK の新規事項 - November 2016
author: KevinAsgari
description: Xbox Live SDK の新規事項 - November 2016
ms.assetid: 5cf9ba9d-5a15-4e62-bc1f-45ff8b8bf3b0
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: xbox live, xbox, ゲーム, uwp, windows 10, xbox one
ms.localizationpriority: medium
ms.openlocfilehash: 642d15a85837ed23ea98dc3f9bd39b8d50d860b2
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3882016"
---
# <a name="whats-new-for-the-xbox-live-sdk---november-2016"></a>Xbox Live SDK の新規事項 - November 2016

August 2016 リリースで追加された内容については、「[新規事項 - August 2016](1608-whats-new.md)」を参照してください。

## <a name="xbox-services-api"></a>Xbox サービス API

### <a name="simplified-achievements"></a>簡素化された実績

* [簡素化された実績](../achievements-2017/simplified-achievements.md)は、実績をより単純に構成および使用するための新しい手段です。  実績がロック解除された際に、イベントを送信して Xbox Live サービスに判定してもらう必要がなくなりました。  その判定は、タイトルによって行われます。
* 簡素化された実績の早期パイロットに参加したユーザーにも、オフライン サポートが追加されました。
* SimplifiedAchievements という新しいサンプルでは、非常に簡単に使用できることが示されています。

### <a name="multiplayer"></a>マルチプレイヤー

* [セッション ブラウズ](../multiplayer/session-browse.md)は、ユーザーがマルチプレイヤー ゲームを探すための新しい手段です。  セッション ブラウズを使用すると、指定された条件を満たすオープン マルチプレイヤー ゲーム セッションの一覧を検索できます。
* [Multiplayer Manager](../multiplayer/multiplayer-manager.md) に自動入力機能が備わりました。  有効にすると、Multiplayer Manager はマッチメイキングを使用してメンバーを検索し、ゲームプレイ中に開いているスロットに入力します。
* プレプロダクション バージョンの [XIM (Xbox Integrated Multiplayer)](../multiplayer/xbox-integrated-multiplayer.md) が、ERA 開発に利用できるようになりました。  XIM は、Xbox Live サービスの機能を使用してマルチプレイヤー リアルタイム ネットワークおよびチャット コミュニケーションをゲームに簡単に追加できる自己完結型のインターフェイスです。

### <a name="social-manager"></a>Social Manager

* さまざまな [Social Manager](../social-platform/intro-to-social-manager.md) API の変更点:
    * Social Manager により、実験的な名前空間が残されました。 早期に導入され、フィードバックをくださった方々に深く感謝します。
    * `xbox_social_user`
        * `string_t` オブジェクトが `char*` オブジェクトに変更されました
        * 6 個の `social_manager_presence_title_record` までのカスタム プレゼンス レコード (各:  `social_manager_presence_record`
    * `social_event`
        * 次の代わりに `std::vector<xbox_user_id_container>` を返します。 `std::vector<xbox_social_user>`
        * このベクトルは、新しい API に渡すことができます。 `xbox_social_user_group::get_users_from_xbox_user_ids()`
    * `xbox_social_user_group`
        * `users()` API が `std::vector<xbox_social_user*>` 返すようになりました。 これらのポインターは、次の呼び出しで無効になります。 `social_manager::do_work()`
        * `get_copy_of_users` は、social_user_group 内の現在のユーザーのコピーとして `std::vector<xbox_social_user>` を呼び出し元に返します。 この関数を呼び出すと、`do_work` の完了時間に影響を与える可能性があります。
* Social Manager が初期化後に失敗しなくなりました。 Social Manager は切断時に自動的に RTA を再試行します。 `error` イベントと `rta_disconnect_error` イベントが推奨されなくなったため、削除されました。
* タイトルでカスタム メモリー アロケーターを指定できます。 新しいドキュメント「[Social Manager のメモリーとパフォーマンス](../social-platform/social-manager-memory-and-performance-overview.md)」を参照してください

### <a name="xbox-one-uwp"></a>Xbox One UWP
* TCUI API に、Xbox One UWP アプリのマルチ ユーザー向けのサポートが追加されました。  XSAPI C++ にユーザーを指定する新しい Windows::System::User^ パラメーターが追加され、XSAPI WinRT API に ForUserAsync API が追加されました。
* Xbox のマルチ ユーザーをサポートするために更新された UWP のサンプル

### <a name="other"></a>その他

* C++/WinRT サポートが追加されました。   詳細については、[ここ](../introduction-to-xbox-live-apis.md)を参照してください
* 自身のログ コールバックを追加および削除する新しい機能が追加されました。  診断のレベルは、動作を細かく調整できるように、コールバックに渡されます。  `microsoft::xbox::services::system::xbox_live_services_settings` 名前空間の `add_logging_handler` と `remove_logging_handler` をご覧ください

## <a name="documentation"></a>ドキュメント
* Xbox Live 向けの [Multiplayer Manager](../multiplayer/multiplayer-manager.md)、[XIM](../multiplayer/xbox-integrated-multiplayer.md)、および [multiplayer concepts](../multiplayer/multiplayer-concepts.md) についての新しいドキュメントがあります。
* 「[Xbox Live introduction](../get-started-with-partner/get-started-with-xbox-live-partner.md)」セクションが書き換えられました。  Xbox Live が有効な新しいタイトルを作成しているか、他の Xbox Live 機能をゲームに組み込むことに興味がある場合は、[ここ](../get-started-with-partner/get-started-with-xbox-live-partner.md)で新しいドキュメントを参照してください。

## <a name="tools"></a>ツール
* Xbox Live Trace Analyzer は、これ[http://aka.ms/XboxLiveTools](http://aka.ms/XboxLiveTools)CERT モードようになりました。  
* また、Xbox Live Trace Analyzer に複数の本体のサポートも追加されました。  複数の本体の HTTP 要求が含まれる Fiddler トレースを渡すと、それぞれの独立したレポートが生成されます。
