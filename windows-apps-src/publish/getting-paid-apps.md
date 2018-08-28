---
author: jnHs
Description: Here’s some important info you’ll need to ensure that you receive payment for your apps, in-app products (IAPs), and advertising earnings.
title: 支払いの受け取り
ms.assetid: 37D1EF45-C4A8-4849-8819-3D4A4898215C
ms.author: wdg-dev-content
ms.date: 02/05/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, 支払い, アプリの販売, アプリの収益, 受け取り, Microsoft Store の手数料, 支払い保留, パーセント
ms.localizationpriority: medium
ms.openlocfilehash: 0c128bedd1c889f4c2dcf0565c7c10575eb75013
ms.sourcegitcommit: 9a17266f208ec415fc718e5254d5b4c08835150c
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/28/2018
ms.locfileid: "2881975"
---
# <a name="getting-paid"></a>支払いの受け取り
ここでは、アプリ、アドオン、広告収益の支払いを受け取るために確認する必要のある重要な情報について説明します。

> [!IMPORTANT]
> Microsoft Store でのアプリ販売に対して支払いを受けるには、事前に[受け取りアカウントを設定して税関連の書類に入力する](setting-up-your-payout-account-and-tax-forms.md)必要があります。

## <a name="store-fee"></a>Microsoft Store の手数料

[開発者アカウントを登録する](http://go.microsoft.com/fwlink/p/?LinkID=615100)際に、開発者は[アプリ開発者契約](https://docs.microsoft.com/legal/windows/agreements/app-developer-agreement)に同意します。 この契約には、Microsoft Store でのアプリ販売に関する、開発者と Microsoft との関係が説明されています。これには、Microsoft がすべての販売に対して課金する Microsoft Store の手数料に関する規定も含まれています。

ほとんどの場合、Microsoft Store の手数料は 30% です。 これらの手数料は、[アプリ開発者契約](https://docs.microsoft.com/legal/windows/agreements/app-developer-agreement)で正式に定められています。 疑問がある場合は、常にこの契約を確認してください。

Microsoft Store の手数料は、アドオンも含めて、Microsoft Store で生じたすべてのアプリ販売に適用されます。


## <a name="price-tiers"></a>価格帯

価格帯を選ぶと、アプリを配布するすべての国における[販売価格](set-and-schedule-app-pricing.md#base-price)が設定されます。 [市場により異なる価格を選ぶ](set-and-schedule-app-pricing.md#override-base-price-for-specific-markets)機能や、[アプリの特売](put-apps-and-add-ons-on-sale.md)をする機能など、その他の価格設定機能を使うこともできます。

アプリを無料で提供することも、ユーザーがアプリを購入する際に支払う価格を選ぶこともできます。 価格帯は、0.99 米国ドルから、段階的に設定されています (1.09 米国ドル、1.19 米国ドルなど)。 価格が高くなるにつれ、価格の増分も大きくなります。

> [!NOTE] 
> これらの価格帯は、アプリ内で提供するすべてのアドオンにも適用されます。

各価格帯には、ストアで提供されている通貨ごとに対応する値があります。 これらの値は、世界中で同等の小売価格でアプリを販売するために使われます。 ただし、外国為替相場の変動により、正確な売上高は通貨ごとに若干異なる場合があります。

選択した自由設定価格を特定の市場の現地通貨で入力することもできます。 新しい価格で更新プログラムを提出する場合を除き、このオプションでは (コンバージョン率が変化しても) 価格が調整されません。 

選んだ価格には、お客様が支払う必要のある売上税や付加価値税が含まれている場合があることに注意してください。 詳しくは、「[有料アプリの税の詳細](tax-details-for-paid-apps.md)」をご覧ください。


## <a name="payout-reporting"></a>支払いレポート

Windows デベロッパー センター ダッシュ ボードの **[支払の概要]** で、支払い情報に関する詳細を表示し、レポートをダウンロードできます。 ここに表示される情報について詳しくは、「[支払いの要約](payout-summary.md)」をご覧ください。


## <a name="payout-timeframe"></a>支払いの時期

支払いは毎月行われます (支払いのしきい値に達していて、下記の支払いの保留処理を行っていない場合)。 通常、支払いは、該当する月の 15 日に行われます。 支払いが受取りアカウントに到着するまで、通常は 3 ～ 10 営業日かかることに注意してください。 詳しくは、「[支払しきい値、方法、期間](payment-thresholds-methods-and-timeframes.md)」をご覧ください。


##  <a name="payout-hold-status"></a>支払い保留の状態

既定では、上記で説明したように、支払いは毎月行われます。 ただし、支払いを保留にして、アカウントへの支払いの送信を行わないようにするオプションがあります。 支払いを保留にした場合、獲得した収益は引き続き記録され、**支払いの要約**でその詳細が提供されます。 ただし、保留を解除するまでは、アカウントへの支払いは送信されません。 

支払いを保留にするには、**[アカウントの設定]** に移動します。 **[財務詳細]** の **[支払い保留状態]** セクションで、スライダーを**オン**に切り替えます。 支払い保留状態はいつでも変更できますが、これは次の月の支払いに影響を及ぼすことに注意してください。 たとえば、4 月の支払いを保留にする場合には、支払い保留状態を 3 月末以前に**オン**に設定します。

支払い保留状態を**オン**に設定すると、スライダーを**オフ**に戻すまで、すべての支払いは保留されます。 スライダーをオフに戻すと、次の月の支払いサイクルに含まれます (支払いのしきい値に達している場合)。 たとえば、支払いを保留にしたが、6 月に支払いを受けたい場合には、5 月末以前に支払い保留状態を**オフ**に戻すようにします。

> [!NOTE]
> **[支払い保留状態]** セクションは、Windows デベロッパー センターを通じて支払われる**すべて**の収益源 (Microsoft Store、広告、Azure Marketplace など) に適用されます。 収益源ごとに異なる保留状態を選択することはできません。


 

 




