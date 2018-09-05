---
author: jnHs
Description: Add-ons are published through the Windows Dev Center dashboard.
title: アドオンの申請
ms.assetid: E175AF9E-A1D4-45DF-B353-5E24E573AE67
ms.author: wdg-dev-content
ms.date: 05/09/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, iap, アプリ内購入, アプリ内製品, iap の申請
ms.localizationpriority: medium
ms.openlocfilehash: 37d05722578ed945fbf75040f96360bb569c6d06
ms.sourcegitcommit: 7aa1933e6970f878faf50d59e1f799b90afd7cc7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/05/2018
ms.locfileid: "3382688"
---
# <a name="add-on-submissions"></a>アドオンの申請

アドオン (アプリ内製品とも呼ばれる) は、お客様が購入可能なアプリの補助アイテムです。 アドオンは、楽しいと考えられる新しいゲーム レベル、またはその他の新機能に対するユーザーのエンゲージメントとできます。 アドオンは収益を得るためだけでなく、お客様との意見交換や顧客エンゲージメントの獲得を促すためにも役立ちます。

アドオンは Windows デベロッパー センター ダッシュボードを使って公開します。 また、アプリのコードで [アドオンを有効にする](../monetize/in-app-purchases-and-trials.md)ことも必要です。

アドオンの申請プロセスでは、最初に、[その製品の種類と製品 ID を定義](set-your-add-on-product-id.md)して、ダッシュボードでアドオンを作成します。 その後、Microsoft Store 経由でアドオンを購入できるように、申請を作成します。 [アプリの申請](app-submissions.md)と同時にまたは別々にアドオンを申請できます。 アプリがストアに公開された後は、アプリを再び申請することなく、アドオンを[更新](#updating-an-add-on-after-publication)できます。

> [!NOTE]
> ドキュメントのこのセクションでは、デベロッパー センター ダッシュボードでアドオンを申請する方法について説明します。 ここで説明する方法以外に、[Microsoft Store 申請 API](../monetize/create-and-manage-submissions-using-windows-store-services.md) を使用してアドオン申請を自動化することもできます。


## <a name="checklist-for-submitting-an-add-on"></a>アドオンの申請用チェック リスト

アドオンの申請を作成するときに提供する情報の一覧を次に示します。 提供が必須である情報については、次の一覧に示してあります。 また、省略可能な情報もあります。既に提供されている既定値は必要に応じて変更できます。


### <a name="create-a-new-add-on-page"></a>新しいアドオン ページを作成する

| フィールド名                    | コメント                            |
|-------------------------------|----------------------------------|
| [**製品の種類**](set-your-add-on-product-id.md#product-type)      | 必須 |  
| [**製品 ID**](set-your-add-on-product-id.md#product-id)          | 必須 |        


### <a name="properties-page"></a>[プロパティ] ページ

| フィールド名                    | コメント                              |   
|-------------------------------|------------------------------------|
| [**製品の有効期限**](enter-add-on-properties.md#product-lifetime)  | 製品の種類が **[永続的]** である場合は必須です。 他の種類の製品には適用されません。 |
| [**数量**](enter-add-on-properties.md#quantity)  | 製品の種類が **[ストアで管理されるコンシューマブル]** の場合は必須です。 他の種類の製品には適用されません。 |
| [**サブスクリプション期間**](enter-add-on-properties.md#subscription-period)          | 製品の種類が **[サブスクリプション]** である場合は必須です。 他の種類の製品には適用されません。       |  
| [**無料試用版**](enter-add-on-properties.md#free-trial)          | 製品の種類が **[サブスクリプション]** である場合は必須です。 他の種類の製品には適用されません。       |
| [**コンテンツの種類**](enter-add-on-properties.md#content-type)          | 必須    |               
| [**キーワード**](enter-add-on-properties.md#keywords)                  | 省略可能 (最大で 10 個まで。それぞれ 30 文字以内)。 |
| [**カスタムの開発者データ**](enter-add-on-properties.md#custom-developer-data)   | 省略可能 (3,000 文字以内)。            |


### <a name="pricing-and-availability-page"></a>[価格と使用可能状況] ページ

| フィールド名                    | メモ                                       |
|-------------------------------|---------------------------------------------|
| [**市場**](set-add-on-pricing-and-availability.md#markets)  | 既定値: 対象となるすべての市場 |
| [**表示**](set-add-on-pricing-and-availability.md#visibility)   | 既定値: 購入可能。 アプリのリストに表示されます |
| [**スケジュール**](set-add-on-pricing-and-availability.md#schedule)    | 既定値: 最短でリリース
| [**価格設定**](set-add-on-pricing-and-availability.md#pricing)                | 必須                                    |
| [**セール価格**](put-apps-and-add-ons-on-sale.md)               | 省略可能                    |


### <a name="store-listings"></a>ストア登録情報

1 つのストア登録情報が必要です。 アプリがサポートする各[言語](create-add-on-store-listings.md#store-listing-languages)でストア登録情報を提供することをお勧めします。

| フィールド名                    | コメント                                       |
|-------------------------------|---------------------------------------------|
| [**タイトル**](create-add-on-store-listings.md#title)                    | 必須 (100 文字以内)           |
| [**説明**](create-add-on-store-listings.md#description)       | 省略可能 (200 文字以内)            |
| [**アイコン**](create-add-on-store-listings.md#icon)                    | 省略可能 (.png、300 x 300 ピクセル)            |


これらの情報の入力が完了したら、**[ストアに提出]** をクリックします。 ほとんどの場合、認定プロセスは約 1 時間かかります。 その後、アドオンはストアに公開され、お客様が購入できるようになります。

> [!NOTE]
> アドオンは、アプリのコードでも実装する必要があります。 詳しくは、「[アプリ内購入と試用版](../monetize/in-app-purchases-and-trials.md)」をご覧ください。


## <a name="updating-an-add-on-after-publication"></a>公開後のアドオンの更新

公開したアドオンはいつでも変更できます。 アドオンの変更が送られ、アプリに独立して公開されるためを一般に、価格や説明の更新などのアドオンを変更するためにアプリ全体を更新する必要はありません。

> [!IMPORTANT]
> Windows 8.x のユーザーがこのアプリを利用できる場合、アドオンの更新がこれらのユーザーにも表示されるようにするために、新しいアプリの申請を作成して公開する必要があります。 同様に、アプリを公開した後で、Windows 8.x を対象とする新しいアドオンをアプリに追加する場合は、アドオンを参照するようにアプリのコードを更新して、アプリを再申請する必要があります。 それ以外の場合、新しいアドオンは、Windows 8.x のユーザーには表示されません。

更新を申請するには、ダッシュボードでアドオンのページに移動し、**[更新]** をクリックします。 これにより、開始点として、以前の申請から情報を使用して、アドオンの新しい申請が作成されます。 変更をし、**ストアに提出**] をクリックします。

既に提供されているアドオンを削除する場合は、新しい申請を作成して、[[分布と認知度]](set-add-on-pricing-and-availability.md) オプションを **[ストアに表示しない]** に変更し、**[購入の停止]** オプションを選択します。 アドオンへの参照も削除するには、必要に応じて、アプリのコードを更新してください (特にアプリが以前に Windows 8.1 をサポートしていた場合、この表示の設定はそれらのユーザーには適用されません)。
