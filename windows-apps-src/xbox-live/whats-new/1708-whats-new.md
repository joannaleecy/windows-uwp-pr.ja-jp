---
title: "Xbox Live API の新規事項 - August 2017"
author: KevinAsgari
description: "Xbox Live API の新規事項 - August 2017"
ms.assetid: 
ms.author: kevinasg
ms.date: 08-16-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "xbox live, xbox, ゲーム, uwp, windows 10, xbox one, 新規事項, august 2017"
ms.openlocfilehash: 74a1e4c90cfd40942643bab4ed95869b2b8528c7
ms.sourcegitcommit: 2b436dc5e5681b8884e0531ee303f851a3e3ccf2
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/18/2017
---
# <a name="whats-new-for-the-xbox-live-apis---august-2017"></a>Xbox Live API の新規事項 - August 2017

July 2017 リリースで追加された内容については、「[新規事項 - July 2017](1707-whats-new.md)」を参照してください。

[Xbox Live API GitHub コミット履歴](https://github.com/Microsoft/xbox-live-api/commits/master)に関するページで、Xbox Live API に最近加えられたすべてのコード変更について確認することもできます。

## <a name="xbox-live-features"></a>Xbox Live の機能

### <a name="in-game-clubs"></a>ゲーム内クラブ

開発者は、"ゲーム内クラブ" を作成できるようになりました。 ゲーム内クラブは、開発者が完全にカスタマイズ可能であり、ゲームの内部と外部の両方で使うことができる点で標準の Xbox クラブとは異なります、 ゲーム開発者は、これらを使って、チーム、仲間、スクワッドなど、独自の要件を満たすあらゆる種類の永続グループ シナリオをゲーム内にすばやく構築することができます。

Xbox Live メンバーは、Xbox コンソール、PC、または iOS/Android デバイスで自由にチャット、フィード、LFG、Mixer などのクラブ機能を使って、どの Xbox エクスペリエンスにおいてもゲームの外部でゲーム内クラブにアクセスして相互につながり、ゲームとの接続を維持できます。

API を使うと、ゲーム内から直接ゲーム内クラブを作成および管理できます。 これらの API は、xbox::services::clubs 名前空間に存在します。
