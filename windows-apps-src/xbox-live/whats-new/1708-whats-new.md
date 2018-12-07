---
title: Xbox Live API の新規事項 - August 2017
description: Xbox Live API の新規事項 - August 2017
ms.assetid: ''
ms.date: 08/16/2017
ms.topic: article
keywords: xbox live, xbox, ゲーム, uwp, windows 10, xbox one, 新規事項, august 2017
ms.localizationpriority: medium
ms.openlocfilehash: db9ffd47e9ee383abb53bdede8de1854aae6b164
ms.sourcegitcommit: d7613c791107f74b6a3dc12a372d9de916c0454b
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/06/2018
ms.locfileid: "8730833"
---
# <a name="whats-new-for-the-xbox-live-apis---august-2017"></a>Xbox Live API の新規事項 - August 2017

July 2017 リリースで追加された内容については、「[新規事項 - July 2017](1707-whats-new.md)」を参照してください。

[Xbox Live API GitHub コミット履歴](https://github.com/Microsoft/xbox-live-api/commits/master)に関するページで、Xbox Live API に最近加えられたすべてのコード変更について確認することもできます。

## <a name="xbox-live-features"></a>Xbox Live の機能

### <a name="in-game-clubs"></a>ゲーム内クラブ

開発者は、"ゲーム内クラブ" を作成できるようになりました。 ゲーム内クラブは、開発者が完全にカスタマイズ可能であり、ゲームの内部と外部の両方で使うことができる点で標準の Xbox クラブとは異なります、 ゲーム開発者は、これらを使って、チーム、仲間、スクワッドなど、独自の要件を満たすあらゆる種類の永続グループ シナリオをゲーム内にすばやく構築することができます。

Xbox Live メンバーは、Xbox コンソール、PC、または iOS/Android デバイスで自由にチャット、フィード、LFG、Mixer などのクラブ機能を使って、どの Xbox エクスペリエンスにおいてもゲームの外部でゲーム内クラブにアクセスして相互につながり、ゲームとの接続を維持できます。

API を使うと、ゲーム内から直接ゲーム内クラブを作成および管理できます。 これらの API は、xbox::services::clubs 名前空間に存在します。
