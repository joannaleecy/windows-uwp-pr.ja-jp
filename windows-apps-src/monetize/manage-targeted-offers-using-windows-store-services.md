---
ms.assetid: 9F0A59A1-FAD7-4AD5-B78B-C1280F215D23
description: アプリの現在のユーザーが利用できるターゲット オファーを取得するには、Microsoft Store ターゲット オファー API を使います。
title: Store サービスを使ってターゲット オファーを管理する
ms.date: 10/10/2017
ms.topic: article
keywords: Windows 10, UWP, Store サービス, Microsoft Store ターゲット オファー API, ターゲット オファー
ms.localizationpriority: medium
ms.openlocfilehash: bcf270bd56d17936ef404adbc3663034b58e7a2c
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57615687"
---
# <a name="manage-targeted-offers-using-store-services"></a>Store サービスを使ってターゲット オファーを管理する

作成する場合、*対象となるプラン*で、**エンゲージ > プランの対象となる**パートナー センターの使用、アプリのページ、*対象となる Microsoft Store API を提供する*でアプリのコードを対象となるプランのアプリ内エクスペリエンスを実装するのに役立つ情報を取得します。 ターゲット オファーについてとダッシュボードで作成する方法について詳しくは、「[ターゲット オファーによるエンゲージメントとコンバージョンの最大化](../publish/use-targeted-offers-to-maximize-engagement-and-conversions.md)」をご覧ください。

ターゲット オファー API はシンプルな REST API で、これを使用すると、ユーザーがターゲット オファーの顧客セグメントに属しているかどうかに基づいて、現在のユーザーに適用されるターゲット オファーを取得できます。 アプリのコードでこの API を使うには、次の手順に従います。

1.  アプリの現在のサインインしているユーザーの [Microsoft アカウント トークンを取得します](#obtain-a-microsoft-account-token)。
2.  [現在のユーザーのターゲット オファーを取得します](#get-targeted-offers)。
3.  ターゲット オファーの 1 つに関連付けられているアドオンのアプリ内購入エクスペリエンスを実装します。 アプリ内購入の実装について詳しくは、[こちらの記事](enable-in-app-purchases-of-apps-and-add-ons.md)をご覧ください。

上記のすべての手順を示す完全なコード例については、この記事の最後にある[コード例](#code-example)をご覧ください。 以降のセクションでは、各手順についてさらに詳しく説明します。

<span id="obtain-a-microsoft-account-token" />

## <a name="get-a-microsoft-account-token-for-the-current-user"></a>現在のユーザーの Microsoft アカウント トークンを取得する

アプリのコードで、現在サインインしているユーザーの Microsoft アカウント (MSA) トークンを取得します。 このトークンを Microsoft Store ターゲット オファー API の ```Authorization``` 要求ヘッダーに渡す必要があります。 このトークンは、現在のユーザーが利用できるターゲット オファーを取得するために Store によって使用されます。

MSA トークンを取得するには、[WebAuthenticationCoreManager](https://docs.microsoft.com/uwp/api/windows.security.authentication.web.core.webauthenticationcoremanager) クラスを使い、スコープ ```devcenter_implicit.basic,wl.basic``` を設定してトークンを要求します。 次の例は、この処理を実行する方法を示しています。 この例は、[完全な例](#code-example)からの抜粋です。また、完全な例で提供されている **using** ステートメントが必要です。

[!code-cs[TargetedOffers](./code/StoreServicesExamples_TargetedOffers/cs/TargetedOffers.cs#GetMSAToken)]

MSA トークンの取得について詳しくは、「[Web アカウント マネージャー](../security/web-account-manager.md)」をご覧ください。

<span id="get-targeted-offers" />

## <a name="get-the-targeted-offers-for-the-current-user"></a>現在のユーザーのターゲット オファーを取得する

現在のユーザーの MSA トークンがある場合、```https://manage.devcenter.microsoft.com/v2.0/my/storeoffers/user``` URI の GET メソッドを呼び出して、現在のユーザーの利用可能なターゲット オファーを取得します。 この REST メソッドについて詳しくは、「[ターゲット オファーを取得する](get-targeted-offers.md)」をご覧ください。

このメソッドは、現在のユーザーが利用可能なターゲット オファーに関連付けられているアドオンの製品 ID を返します。 この情報を使って、1 つ以上のターゲット オファーをアプリ内での購入としてユーザーに提供できます。

次の例は、現在のユーザーのターゲット オファーを取得する方法を示しています。 この例は、[完全な例](#code-example)からの抜粋です。 また、Newtonsoft の [Json.NET](https://www.newtonsoft.com/json) ライブラリ、および完全な例で提供されている追加クラスと **using** ステートメントが必要です。

[!code-cs[TargetedOffers](./code/StoreServicesExamples_TargetedOffers/cs/TargetedOffers.cs#GetTargetedOffers)]

<span id="code-example" />

## <a name="complete-code-example"></a>完全なコード例

次のコード例は、次のタスクを示しています。

* 現在のユーザーの MSA トークンを取得する。
* 「[ターゲット オファーを取得する](get-targeted-offers.md)」の方法を使って、現在のユーザーのすべてのターゲット オファーを取得する。
* ターゲット オファーに関連付けられているアドオンを購入する。

この例では、Newtonsoft の [Json.NET](https://www.newtonsoft.com/json) ライブラリが必要です。 この例では、このライブラリを使って JSON 形式のデータをシリアル化および逆シリアル化します。

[!code-cs[TargetedOffers](./code/StoreServicesExamples_TargetedOffers/cs/TargetedOffers.cs#GetTargetedOffersSample)]

## <a name="related-topics"></a>関連トピック

* [Engagement と変換を最大化するのに対象となるプランを使用します。](../publish/use-targeted-offers-to-maximize-engagement-and-conversions.md)
* [対象となるプランを取得します。](get-targeted-offers.md)
