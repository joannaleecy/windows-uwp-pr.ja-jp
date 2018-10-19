---
author: jnHs
Description: The Pricing and availability page of the app submission process lets you determine how much your app will cost, whether you'll offer a free trial, and how, when, and where it will be available to customers.
title: アプリの価格と使用可能状況の設定
ms.assetid: 37BE7C25-AA74-43CD-8969-CBA3BD481575
ms.author: wdg-dev-content
ms.date: 05/11/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, 価格, 使用可能状況, 見つけやすさ, 無料試用版, 試用版, トライアル, アプリ, リリース日
ms.localizationpriority: medium
ms.openlocfilehash: 20c52687b375f9bf33dd491eeb37d4142acace99
ms.sourcegitcommit: e16c9845b52d5bd43fc02bbe92296a9682d96926
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/19/2018
ms.locfileid: "4949124"
---
# <a name="set-app-pricing-and-availability"></a>アプリの価格と使用可能状況の設定


[アプリ申請プロセス](app-submissions.md)の **[価格と使用可能状況]** のページでは、アプリの料金、無料の試用版を提供するかどうか、およびいつ、どこで、どのようにアプリをユーザーに提供するかを決定できます。 ここでは、このページのオプションと、この情報を入力するときに考慮する必要がある事項を順に説明します。


## <a name="markets"></a>市場

Microsoft Store は、世界中の 200 以上の国と地域のお客様が利用できます。 既定では、対象となるすべての市場にアプリが提供されます。 必要に応じて、アプリを提供する特定の市場を選ぶこともできます。 

詳しくは、「[市場の選択の定義](define-pricing-and-market-selection.md)」をご覧ください。


## <a name="visibility"></a>表示

**[表示]** セクションでは、ユーザーが Microsoft Store でアプリを見つけたり、その Store 登録情報を表示したりできるかどうかなど、アプリを見つけて入手する方法の制限を設定することができます。

詳しくは、「[表示オプションを選択する](choose-visibility-options.md)」をご覧ください。


## <a name="schedule"></a>スケジュール

既定では ([[表示]](choose-visibility-options.md#discoverability) セクションで **[この製品を Microsoft Store で提供しますが、検索はできないようにします]** のオプションのいずれかを選択した場合を除き)、アプリが認定に合格して公開プロセスが完了すると、そのアプリはすぐにユーザーが利用できるようになります。 他の日付を選択するには、**[オプションの表示]** を選択してこのセクションを展開します。 

詳しくは、「[正確なリリース スケジュールの構成](configure-precise-release-scheduling.md)」をご覧ください。


## <a name="pricing"></a>価格設定

開発者は ([[表示]](choose-visibility-options.md#discoverability) セクションの **[この製品を Microsoft Store で提供しますが、検索はできないようにします]** で **[購入の停止]** オプションを選択した場合を除き)、アプリの基本価格として、**[無料]** または用意されている価格帯のいずれかを選択する必要があります。 価格変更をスケジュールして、アプリの価格を変更する日時を指定することもできます。 さらに、これらの変更を特定の市場向けにカスタマイズすることもできます。 

詳しくは、「[アプリの価格の設定とスケジュール](set-and-schedule-app-pricing.md)」をご覧ください。


## <a name="free-trial"></a>無料試用版

多くの開発者は、ストアが提供する試用版の機能を使って、ユーザーが無料でアプリを試用できるようにすることを選択します。 既定では **[無料評価版はありません]** が選択され、アプリの試用版は提供されません。 試用版を提供する場合は、**[無料試用版]** ドロップダウンからいずれかの値を選択できます。

選択できる試用版は 2 種類あり、試用版の提供を開始する日時と終了する日時を構成することができます。

### <a name="time-limited"></a>時間制限

ユーザーが一定の日数だけアプリを無料で試用できるようにするには、**[時間制限]** で、**[1 日]**、**[7 日間]**、**[15 日間]**、または **[30 日間]** を選択します。 [試用版で機能を除外または制限する](../monetize/in-app-purchases-and-trials.md)コードを追加して機能を制限することも、指定した期間だけユーザーがすべての機能を使えるようにすることもできます。 
> [!NOTE]
> 期限付きの試用版は、Windows 10 ビルド 10.0.10586 以前のユーザーと Windows Phone 8.1 以前のユーザーには表示されません。

### <a name="unlimited"></a>無制限

ユーザーが期限なしに無料でアプリにアクセスできるようにするには、**[無制限]** を選びます。 ユーザーに通常版の購入を促す場合は、[試用版の機能を除外または制限する](../monetize/in-app-purchases-and-trials.md)コードを追加します。

### <a name="start-and-end-dates"></a>開始時刻と終了時刻

既定では、試用版はアプリが公開されるとすぐに利用可能になり、提供が終了することはありません。 必要に応じて、試用版の提供を開始する日時と終了する日時を指定できます。 

>[!NOTE]
> これらの日付は、Windows 10 (Xbox を含む) のユーザーにのみ適用されます。 以前の OS バージョンのユーザーが利用できるアプリの場合、製品が利用可能である限りこれらのユーザーにも試用版が提供されます。 

試用版を Windows 10 のユーザーに提供する期間を設定するには、**[開始]** ドロップダウンと **[終了]** ドロップダウン、またはそのどちらかを **[次の時点]** に変更し、日付と時刻を選択します。 このとき、**[UTC]** を選択して世界標準時 (UTC) の時刻を指定するか、または **[ローカル]** を選択して、市場に関連付けられている各タイム ゾーンの時刻を指定することができます  (複数のタイム ゾーンがある市場では、その市場のタイム ゾーンの 1 つだけが使われます。 米国東部標準時が使われます。)いずれかの市場のさまざまな日付を設定する場合は、**特定の市場向けにカスタマイズ**を選択できます。


## <a name="sale-pricing"></a>セール価格

期間限定でアプリを割引価格で提供する場合は、特売を作成し、そのスケジュールを設定できます。

詳しくは、「[アプリとアドオンの販売](put-apps-and-add-ons-on-sale.md)」をご覧ください。


## <a name="organizational-licensing"></a>組織のライセンス

既定では、アプリは組織がボリューム購入できるように提供されます。 このセクションでは、アプリを提供するかどうかとその方法を指定できます。

詳しくは、「[組織のライセンス オプション](organizational-licensing.md)」をご覧ください。


## <a name="publish-date"></a>公開日

以前は、**[公開日]** セクションはこのページに表示されていました。 この機能は、**[Publishing hold options]** (公開の保留オプション) セクションの [[Submission options]](manage-submission-options.md) (申請オプション) ページに移動しました。 (アプリを Microsoft Store に公開するタイミングを制御するため、**[価格と使用可能情報]** ページの [[スケジュール]](configure-precise-release-scheduling.md) セクションを使うことをお勧めします)。


