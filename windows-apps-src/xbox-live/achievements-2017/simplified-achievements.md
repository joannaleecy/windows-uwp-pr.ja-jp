---
title: Achievements 2017
author: KevinAsgari
description: Achievements 2017
ms.assetid: d424db04-328d-470c-81d3-5d4b82cb792f
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 04d2fab9aa836d36a0dba202b2292c311b6d4979
ms.sourcegitcommit: 933e71a31989f8063b020746fdd16e9da94a44c4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/11/2018
ms.locfileid: "4539953"
---
# <a name="achievements-2017"></a>Achievements 2017

Achievements 2017 システムでは、ゲーム デベロッパーは直接呼び出しモデルを使用して、Xbox One、Windows 10、Windows 10 Phone、Android、iOS 上の新しい Xbox Live ゲームの実績をロックを解除できます。

## <a name="introduction"></a>概要

Xbox One では、ゲーム内テレメトリー イベントを送信するだけで、ユーザー統計、実績、リッチ プレゼンス、マルチプレイヤーなどの Xbox Live 機能のデータを活用できる、新しいクラウド版実績システムが導入されました。 これにより、1 つのイベントで複数の Xbox Live 機能のデータを更新できたり、Xbox Live の構成がクライアントではなくサーバーに保持されるといった、多くの新しい利点があります。

Xbox One の発売から数年、ゲーム デベロッパーからのフィードバックを聞いてきましたが、デベロッパーは一貫して次のような共通認識を持っています。

1.  **直接呼び出しパターンを使用して実績のロックを解除したい。** 多くのデベロッパーはさまざまなプラットフォーム向けのゲームを開発しており、その中には以前のバージョンの Xbox も含まれます。また、これらのプラットフォームでの実績類似システムでは直接呼び出し方式が使用されています。 Xbox One および他の最新世代の Xbox プラットフォームで直接ロック解除呼び出しがサポートされると、クロスプラットフォーム ゲーム開発のニーズが緩和され、開発時のコストを削減できます。

2.  **構成の複雑さを最小限に抑える。** クラウド版実績システムでは、タイトルの統計データを解釈する方法およびユーザーの実績をロック解除するタイミングをサービスが認識できるように、実績のロック解除ロジックを Xbox Live で構成する必要があります。 この機能は、それ以前は存在しなかった実績の構成の新しい実績ルール セクションを使用して実現されました。 クラウドにロック解除ロジックを置くことは非常に強力ですが、この追加構成要件によってタイトルの実績の設計と作成の複雑さが増します。

3.  **トラブルシューティングが困難です。** クラウド版実績システムではさまざまな便利な機能が導入されましたが、実績のロック解除が、ゲーム自体によって直接制御されるのではなく、サービス上に存在するルールによって間接的にトリガーされるため、ゲーム デベロッパーによる実績の検証とトラブルシューティングの困難さも増します。

フィードバックではクラウド版実績システムと共に導入された特定の機能がたびたび高く評価されていることにも注目する必要があります。

1.  実績の進行状況、リアルタイム更新、コンセプト アート リワード、アクティビティ フィードへのロック解除の送信などの新しいユーザー エクスペリエンス機能。

2.  ゲーム パッケージに含める必要があるローカル構成の代わりのサービス構成 (つまり、gameconfig、XLAST、SPA など) や、ゲーム出荷後に実績の文字列とイメージを簡単に編集する機能などの、構成機能の改善。

既存のクラウド版実績システムに代わるものとして将来のタイトルのために作成されている Achievements 2017 では、実績の構成、ゲーム コードへの実績のロック解除と更新の統合、実績が期待どおりに動作していることの検証が、容易になっています。

## <a name="whats-different-with-achievements-2017"></a>Achievements 2017 の特長

|                          | Achievements 2017 システム        | クラウド版実績システム      |
|--------------------------|---------------------------------------|----------------------------------------|
| ロック解除トリガー           | API 呼び出しによって直接的                 | テレメトリー イベントによって間接的        |
| ロック解除の所有者             | タイトル                                 | Xbox Live                              |
| 構成            | 文字列、イメージ、リワード              | 文字列、イメージ、リワード、ロック解除ルール \[+ 統計情報、+ イベント\]                    |
| 進行状況              | サポートされる <br>*API 呼び出しによって直接的*                | サポートされる <br> *テレメトリー イベントによって間接的*       |
| リアルタイム アクティビティ (RTA) | サポートされる                             | サポートされる                              |
| チャレンジ               | サポートされない   | サポートされる                      |

## <a name="title-requirements"></a>タイトルの要件

Achievements 2017 システムを使用するタイトルの要件を次に示します。

1.  **新しい (未リリースの) タイトルでなければなりません。** 既にリリースされていてクラウド版実績システムを使用しているタイトルは対象外です。 詳しくは、「[既存のタイトルを新しい Achievements 2017 システムに "移行" できないのはなぜですか?](#_Why_can’t_existing)」を参照してください。

2.  **August 2016 XDK 以降を使用する必要があります。** Update_Achievement API は、August 2016 XDK でリリースされました。

3.  **XDK または UWP タイトルでなければなりません。** Achievements 2017 システムは、Xbox 360、Windows 8.x 以前、Windows Phone 8 以前などの従来のプラットフォームでは使用できません。

## <a name="updateachievement-api"></a>Update_Achievement API

XDP または [UDC](../configure-xbl/dev-center/achievements-in-udc.md) を介して実績を構成し、開発サンドボックスに公開したら、タイトルで Update_Achievement API を呼び出して実績のロックを解除できます。

この API は XDK と Xbox Live SDK の両方で使用できます。

### <a name="api-signature"></a>API のシグネチャ

API のシグネチャは次のとおりです。

```c++
/// <summary>
    /// Allow achievement progress to be updated and achievements to be unlocked.  
    /// This API will work even when offline. On PC and Xbox One, updates will be posted by the system when connection is re-established even if the title isn't running
    /// </summary>
    /// <param name="xboxUserId">The Xbox User ID of the player.</param>
    /// <param name="titleId">The title ID.</param>
    /// <param name="serviceConfigurationId">The service configuration ID (SCID) for the title.</param>
    /// <param name="achievementId">The achievement ID as defined by XDP or Dev Center.</param>
    /// <param name="percentComplete">The completion percentage of the achievement to indicate progress.
    /// Valid values are from 1 to 100. Set to 100 to unlock the achievement.  
    /// Progress will be set by the server to the highest value sent</param>
    /// <remarks>
    /// Returns a task<T> object that represents the state of the asynchronous operation.
    ///
    /// This method calls V2 GET /users/xuid({xuid})/achievements/{scid}/update
    /// </remarks>
    _XSAPIIMP pplx::task<xbox::services::xbox_live_result<void>> update_achievement(
        _In_ const string_t& xboxUserId,
        _In_ uint32_t titleId,
        _In_ const string_t& serviceConfigurationId,
        _In_ const string_t& achievementId,
        _In_ uint32_t percentComplete
        );
```

`xbox::services::xbox_live_result<T>` は、すべての C++ Xbox Live Services API 呼び出しに対する戻りの呼び出しです。

詳細については、Xfest 2015 の講演「XSAPI: C++, No Exceptions!」をご覧ください。<br>
[ビデオ](http://go.microsoft.com/?linkid=9888207) |  [スライド](https://developer.xboxlive.com/en-us/platform/documentlibrary/events/Documents/Xfest_2015/Xbox_Live_Track/XSAPI_Cpp_No_Exceptions.pptx)

### <a name="unlocking-via-updateachievement-api"></a>Update_Achievement API によるロック解除

実績のロックを解除するには、*percentComplete* を 100 に設定します。

ユーザーがオンラインの場合、要求は Xbox Live 実績サービスに直ちに送信されて、次のユーザー エクスペリエンスをトリガーします。

-   ユーザーは実績ロック解除通知を受け取ります。

-   指定された実績が、ユーザーのタイトルの実績リストに Unlocked として表示されます。

-   ロック解除された実績が、ユーザーのアクティビティ フィードに追加されます。

> *注意: タイトルが Achievements 2017 システムまたはクラウド版実績システムのどちらを使用していても、実績のユーザー エクスペリエンスの表示に違いはありません。*

ユーザーがオフラインの場合は、ロック解除要求はユーザーのデバイスのローカルなキューに入れられます。 ユーザーのデバイスがネットワークに再び接続すると、要求は実績サービスに自動的に送信され (注: このトリガーにゲームのアクションは必要ありません)、上記のエクスペリエンスが説明したとおりに行われます。

### <a name="updating-completion-progress-via-updateachievement-api"></a>Update_Achievement API による進行状況の更新

実績のロック解除に向けたユーザーの進行状況を更新するには、*percentComplete* を 1 ～ 100 の範囲の適切な整数に設定します。

実績の進行状況は増やすことだけが可能です。 *percentComplete* を実績の最後の *percentComplete* 値より小さい値に設定すると、更新は無視されます。 たとえば、実績の *percentComplete* の前回の値が 75 の場合、値 25 を指定して更新を送信すると無視されて、実績の進行状況の表示は 75% のままになります。

*percentComplete* を 100 に設定すると、実績のロックが解除されます。

*percentComplete* を 100 より大きい値に設定すると、API は 100 ちょうどに設定した場合と同じように動作します。

## <a name="frequently-asked-questions"></a>よく寄せられる質問

### <a name="span-idwhyarechallenges-classanchorspancan-i-ship-my-title-using-the-achievements-2017-system-yet"></a><span id="_Why_are_Challenges" class="anchor"></span>Achievements 2017 システムを使用するタイトルはもう出荷できますか?

もちろんです。 すべての新規タイトルでは、クラウド版実績システムの代わりに Achievements 2017 システムを使用することが歓迎され、奨励されます。

### <a name="why-are-challenges-not-supported-in-the-achievements-2017-system"></a>Achievements 2017 システムでチャレンジがサポートされていないのはなぜですか?

Xbox ゲーム全体の使用データを調べたところ、チャレンジの現在の実装と提供はほとんどのゲーム デベロッパーのニーズを満たしていないことがわかりました。 引き続きこの部分に関するデベロッパーの意見とフィードバックを収集し、デベロッパーのニーズにいっそう沿った機能を提供する予定です。 新しくリリースされる Xbox Arena は、新しくはあっても大きくは異ならない方向で Xbox ゲームに新しい対戦型環境を導入する機能の例です。

### <a name="can-i-still-add-new-achievements-every-calendar-quarter-if-my-title-is-using-the-achievements-2017-system"></a>タイトルが Achievements 2017 システムを使用している場合でも、3 か月ごとに新しい実績を追加できますか?

できます。 実績ポリシーの変更はありません。

### <a name="span-idwhycantexisting-classanchorspanwhy-cant-existing-titles-migrate-onto-the-new-achievements-2017-system"></a><span id="_Why_can’t_existing" class="anchor"></span>既存のタイトルを新しい Achievements 2017 システムに "移行" できないのはなぜですか?

既存タイトルの大部分については、Achievements 2017 システムへの "移行" は、サービス構成の更新と、実績ロック解除呼び出しのイベント書き込みの変更だけでは済みません。しかも、これらの変更だけでも、非常にコストがかかり、実績が修復不可能なほど破損するようなエラーと意図しない動作が発生する大きなリスクがあります。 さらに、ほとんどの既存タイトルには、既存のデータを持っているユーザーがいます。 クラウド版実績システムを既に使用しているライブ ゲームの変換は、デベロッパーと Xbox の双方にとって、それほどコストのかかる作業ではありませんが、既存のユーザーのプロフィールとゲーム エクスペリエンスは大きな危険にさらされます。

### <a name="if-my-title-was-released-using-the-cloud-powered-achievements-system-can-any-future-dlc-for-the-title-switch-to-achievements-2017"></a>クラウド版実績システムを使用しているリリース済みタイトルは、タイトルの将来の DLC で Achievements 2017 に切り替えることができますか?

タイトルのすべての実績は、同じ実績システムを使用する必要があります。 ベース ゲームの実績で使用されている実績システムを、タイトルの将来のすべての実績に使用する必要があります。

### <a name="while-testing-achievements-in-my-dev-sandbox-can-i-mix-and-match-between-using-the-achievements-2017-system-and-the-cloud-powered-achievements-system"></a>開発サンドボックスで実績をテストするときに、Achievements 2017 システムとクラウド版実績システムを組み合わせて使用することはできますか?

できません。 タイトルのすべての実績は、同じ実績システムを使用する必要があります。

### <a name="does-achievements-2017-also-include-offline-unlocks"></a>Achievements 2017 にはオフライン ロック解除も含まれていますか?

デバイスがオフラインの間にタイトルで実績をロック解除すると、Update_Achievement API はオフライン ロック解除要求を自動的にキューに入れ、デバイスが再びネットワークに接続すると、Xbox Live と自動的に同期します。これは、現在のクラウド版実績システムのオフライン エクスペリエンスと同様です。 ユーザーがオフラインの間は、実績のロック解除は行われません。

### <a name="i-see-a-new-achievementupdate-event-in-xdp-if-my-title-uses-that-event-does-that-mean-it-has-achievements-2017"></a>XDP には新しい "AchievementUpdate" イベントがあります。 タイトルでそのイベントを使用すると、タイトルは Achievements 2017 を使用していることになりますか?

*AchievementUpdate* ベース イベントは、バックエンド用に Xbox Live で必要です。 このイベントは無視しても安全です。 このベース イベント タイプを使用するイベントをタイトルで構成した場合、Xbox Live はそのイベントによる書き込みを無視します。 クラウド版実績システムを使用するタイトルでは、引き続き他のベース イベント タイプを使用してイベントを構成する必要があります。 Achievements 2017 システムを使用するタイトルでは、実績のためにイベントを構成する必要は一切ありません**。
