---
author: jnHs
Description: You can cross-promote your app with apps published by other developers. We call this feature community ads.
title: コミュニティ広告について
ms.assetid: F55CE478-99AF-4B70-90D1-D16419562136
ms.author: wdg-dev-content
ms.date: 10/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: ada2e0610e81e986deba3ddab5e87547e05fe108
ms.sourcegitcommit: 753dfcd0f9fdfc963579dd0b217b445c4b110a18
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/27/2018
ms.locfileid: "2864881"
---
# <a name="about-community-ads"></a>コミュニティ広告について

かどうかは、アプリ[のバナーまたはスポット バナーが表示されます](../monetize/display-ads-in-your-app.md)] クロス-昇格できますアプリについては、Microsoft ストア内のアプリを使用して他の開発者無料します。 この機能を*コミュニティ広告*と呼びます。  

このプログラムの内容を次に示します。

* 後もコミュニティ広告以下のように、[無料のコミュニティ広告キャンペーンを作成](create-an-ad-campaign-for-your-app.md)することができます。 [アプリも広告のコミュニティに参加するその他の開発者が宣伝広告のスペースを共有します。 自分のアプリに、コミュニティ広告に参加している他の開発者が公開したアプリの広告が表示され、他の開発者のアプリに自分のアプリの広告が表示されます。
* アプリにコミュニティ広告を表示することによって、他のアプリ内のプロモーション用の広告スペースのクレジットを獲得できます。 次のプロセスに従ってクレジットが計算されます。
  * コミュニティ広告を提供するアプリが利用可能な国や地域ごとに、現在の市場レートの eCPM (1000 回の広告表示あたりの有効な料金) 値に、その国や地域でアプリが作成するコミュニティ広告に対するリクエスト数が掛けられます。 この値は、対象の国や地域でアプリが獲得したクレジットです。
  * 特定の期間に獲得したクレジットの合計は、それぞれの国や地域でコミュニティ広告を提供する各アプリによって獲得したすべてのクレジットの合計と同じになります。
* クレジットは、すべてのアクティブなコミュニティ広告キャンペーンで均等に分割され、コミュニティ広告キャンペーンの対象となる国の現在の市場レートの eCPM 値に基づいてアプリの広告インプレッション数に変換されます。
* アプリ内のコミュニティ広告のパフォーマンスを追跡するには、「[[広告パフォーマンス] レポート](advertising-performance-report.md)」をご覧ください。

### <a name="opt-in-to-community-ads"></a>コミュニティ広告へのオプトイン

**Monetize**に加入する必要がありますコミュニティ ad キャンペーンを作成するには、アプリのいずれか、前に&gt;Windows デベロッパー センターのダッシュ ボードでの**アプリで広告**ページです。

コミュニティ広告に UWP アプリの選択します。

1. [**アプリの広告**] ページで [**仲介 settings** ] セクションで、アプリで使用している ad 単位を選択します。
2. 場合は **、Microsoft がアプリの最適な仲介設定を選択**オプションを選択すると、コミュニティ広告、ad 単位の自動的に有効にします。 それ以外の場合、**対象**] ボックスで、基準計画または市場に固有の構成を選択して、**他の広告ネットワーク**リストの場合は、[ **Microsoft コミュニティ広告**ボックスを確認します。

    > [!NOTE]
    > **太さ**のフィールドを使用すると、有料のネットワークとコミュニティ広告を含めて他の ad ネットワークから表示する広告の比率を指定します。

Windows のコミュニティ広告に加入するのには 8.x または Windows Phone 8.x アプリでは、

1. [**アプリの広告**ページで、**アプリのコミュニティ広告を表示する**] ボックスを確認します。

この設定をした後にアプリを再公開する必要はありません。 オプトインすると、[広告キャンペーンを作成](create-an-ad-campaign-for-your-app.md)するときに、キャンペーンの種類に **[コミュニティ広告 (無料)]** を選べるようになります。

### <a name="related-topics"></a>関連トピック

* [アプリ内広告](in-app-ads.md)
* [アプリ向けの広告キャンペーンの作成](create-an-ad-campaign-for-your-app.md)
