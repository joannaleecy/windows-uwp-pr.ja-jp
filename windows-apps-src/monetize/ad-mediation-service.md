---
author: Xansky
description: マイクロソフトの広告仲介サービスを利用すると、複数の広告ネットワークから広告を表示して、広告収益とアプリ プロモーションの機能を最大限に引き出すことができます。
title: マイクロソフトの広告仲介サービス
ms.author: mhopkins
ms.date: 06/05/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, 広告, 広告, 広告仲介
ms.localizationpriority: medium
ms.openlocfilehash: cfcb2402a9a0246060a619cbc65337e2b2c69d78
ms.sourcegitcommit: 106aec1e59ba41aae2ac00f909b81bf7121a6ef1
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/15/2018
ms.locfileid: "4610884"
---
# <a name="microsoft-ad-mediation-service"></a>マイクロソフトの広告仲介サービス

[Microsoft Advertising SDK](http://aka.ms/ads-sdk-uwp) を使用して[アプリに広告を表示する場合](display-ads-in-your-app.md)、必要に応じてマイクロソフトの広告仲介サービスを使って、広告の収益を最大化できます。 この記事では、広告仲介サービスとその目標の概要を示します。

広告仲介サービスは、[マイクロソフトの広告の収益化プラットフォーム](https://developer.microsoft.com/windows/ad-monetization-platform)の一部です。 プラットフォームは、次の部分で構成されます。

![addreferences](images/ad-mediation-service.png)

広告仲介サービスは、これらの機能に基づいて構築することにより、アプリの広告収益を最大化することを目的としています。

## <a name="diversity-of-demand-by-market-and-format"></a>市場と形式による需要の多様性

広告仲介サービスは、(バナー、スポット バナー、スポット ビデオ、およびネイティブ) のさまざまな広告形式で、さまざまな広告ネットワークと統合されます。 広告仲介サービスは、各広告ネットワークと連携しエンド ユーザーとのエンゲージメントを最大限に高める可能性のある広告を提供できるようにします。 引き続きさまざまな広告パートナーを追加して、需要の多様性と質を拡大する予定です。

## <a name="manage-complexity-of-ad-network-relationships"></a>広告ネットワークの関係の複雑さの管理  

広告仲介サービスはさまざまな広告ネットワークと統合されるため、開発者がこの作業を行う必要はありません。 Microsoft Advertising SDK を使用してアプリで広告を表示したら、[デベロッパー センター ダッシュボードを使用して](../publish/in-app-ads.md#mediation-settings)広告仲介設定を変更し、複数の広告ネットワークからの広告を表示します。 コードを変更することなく、新しい広告ネットワークから広告を取得できるという利点があります。

マイクロソフトでは、開発者に代わって広告ネットワークとのエンド ツー エンドの関係を管理します。 開発者が余分な手間をかける必要はなく、広告ネットワークの統合から、広告の提供、レポートおよび支払いまですべてマイクロソフトが行います。

## <a name="machine-learning-based-yield-optimization-algorithms"></a>機械学習に基づく収益最適化のアルゴリズム

広告仲介サービスは、開発者の最大の収益を生成するのに役立ちます。 そのために、機械学習に基づく収益最適化のアルゴリズムを採用しています。 すべての広告呼び出しで、広告ネットワークが開発者の収益を最大化するために呼び出される必要がある最適な*連鎖的*順序をアルゴリズムが決定します。 これは次のような多くの要因を考慮して行われます。

* 要求を行っているユーザー。
* 要求の対象となるアプリケーション。
* 広告ネットワークの過去のパフォーマンス。
* 要求の送信元である広告形式と市場。
* 広告呼び出しの回数。
* アプリのコンテンツのカテゴリー。
* ユーザー セグメント。
* ユーザーの位置情報。

新しい広告ネットワークは自動的に含まれ、学習予算を通じてパフォーマンスが評価されます。 短時間に、広告ネットワークは大量のイベント内で自分の場所を見つけます。 これにより、広告ネットワークの競争力が強化され、開発者は、アプリの収益化を最大限に活用できます。

[推奨される仲介設定](../publish/in-app-ads.md#mediation-settings)を使用してアプリ内広告で得られる収入を最大化することを強くお勧めします。 これにより、アルゴリズムでアプリの最適な収益を可能にすることができます。 ただし、デベロッパー センター ダッシュボードで独自の仲介設定を自由に選択し、広告を提供する広告ネットワークや広告を提供する順序をより詳細に制御することもできます。

## <a name="rich-data-and-signals"></a>豊富なデータと信号

広告仲介サービスは、各ユーザーにとってより関連性の高い広告を表示するためのユーザーのターゲット設定を向上させるためにさまざまな広告ネットワークと連携します。 これは、プライバシー要件を考慮しながら、ユーザーやアプリに関する豊富な信号を広告ネットワークに送信することで行われます。

## <a name="related-topics"></a>関連トピック

* [Microsoft Advertising SDK](http://aka.ms/ads-sdk-uwp)
* [仲介設定](../publish/in-app-ads.md#mediation-settings)
* [[広告パフォーマンス] レポート](../publish/advertising-performance-report.md)
