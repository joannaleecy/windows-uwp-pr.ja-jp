---
author: jnHs
Description: "アドオンは Windows デベロッパー センター ダッシュボードを使って公開します。"
title: "アドオンの申請"
ms.assetid: E175AF9E-A1D4-45DF-B353-5E24E573AE67
ms.author: wdg-dev-content
ms.date: 06/26/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: 85ad5e297eed8daa5205aedc1253191fcff5fd49
ms.sourcegitcommit: 8c4d50ef819ed1a2f8cac4eebefb5ccdaf3fa898
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 06/27/2017
---
# <a name="add-on-submissions"></a>アドオンの申請

アドオン (アプリ内製品とも呼ばれる) は、お客様が購入可能なアプリの補助アイテムです。 アドオンには、楽しいアドオン新機能、新しいゲーム レベル、またはユーザーの関心を引くと思われるその他のアイテムなどがあります。 アドオンは収益を得るためだけでなく、お客様との意見交換や顧客エンゲージメントの獲得を促すためにも役立ちます。

アドオンは Windows デベロッパー センター ダッシュボードを使って公開します。 また、アプリのコードで [アドオンを有効にする](../monetize/in-app-purchases-and-trials.md)ことも必要です。

アドオンの申請プロセスでは、最初に、[その製品の種類と製品 ID を定義](set-your-add-on-product-id.md)して、ダッシュボードでアドオンを作成します。 その後、アドオンが Windows ストアで購入可能になるように申請を作成できます。 [アプリの申請](app-submissions.md)と同時にまたは別々にアドオンを申請できます。 アプリがストアに公開された後は、アプリを再び申請することなく、アドオンを[更新](#updating-an-add-on-after-publication)できます。

> [!NOTE]
> ドキュメントのこのセクションでは、デベロッパー センター ダッシュボードでアドオンを申請する方法について説明します。 ここで説明する方法以外に、[Windows ストア申請 API](../monetize/create-and-manage-submissions-using-windows-store-services.md) を使用してアドオン申請を自動化することもできます。

## <a name="checklist-for-submitting-an-add-on"></a>アドオンの申請用チェック リスト

アドオンの申請を作成するときに提供する情報の一覧を次に示します。 提供が必須である情報については、次の一覧に示してあります。 また、省略可能な情報もあります。既に提供されている既定値は必要に応じて変更できます。

### <a name="create-a-new-add-on-page"></a>新しいアドオン ページを作成する
| フィールド名                    | コメント                            |
|-------------------------------|----------------------------------|
| [**製品の種類**](set-your-add-on-product-id.md#product-type)      | 必須。 **[永続的]** を選んだ場合は、**[製品の有効期限]** を指定する必要があります。 |  
| [**製品 ID**](set-your-add-on-product-id.md#product-id)          | 必須 |        

<span/>

### <a name="properties-page"></a>[プロパティ] ページ
| フィールド名                    | コメント                              |   
|-------------------------------|------------------------------------|
| [**製品の有効期限**](enter-add-on-properties.md#product-lifetime)  | 製品の種類が **[永続的]** である場合は必須です。 他の種類の製品には適用されません。 |
| [**数量**](enter-add-on-properties.md#quantity)  | 製品の種類が **[ストアで管理されるコンシューマブル]** の場合は必須です。 他の種類の製品には適用されません。
| [**コンテンツの種類**](enter-add-on-properties.md#content-type)          | 必須       |               
| [**キーワード**](enter-add-on-properties.md#keywords)                  | 省略可能 (最大で 10 個まで。それぞれ 30 文字以内)。 |
| [**カスタムの開発者データ**](enter-add-on-properties.md#custom-developer-data)                               | 省略可能 (3000 文字以内)             |

<span/>

### <a name="pricing-and-availability-page"></a>[価格と使用可能状況] ページ
| フィールド名                    | メモ                                       |
|-------------------------------|---------------------------------------------|
| [**市場**](set-add-on-pricing-and-availability.md#markets)  | 既定値: 対象となるすべての市場 |
| [**表示**](set-add-on-pricing-and-availability.md#visibility)   | 既定値: 購入可能。 アプリのリストに表示されます |
| [**スケジュール**](set-add-on-pricing-and-availability.md#schedule)    | 既定値: 最短でリリース
| [**価格設定**](set-add-on-pricing-and-availability.md#pricing)                | 必須                                    |
| [**セール価格**](put-apps-and-add-ons-on-sale.md)               | 省略可能                             |
| [**公開日**](set-add-on-pricing-and-availability.md#publish-date)                | 既定値: できるだけ早く公開する |

<span/>

### <a name="store-listings"></a>ストア登録情報
1 つのストア登録情報が必要です。 アプリがサポートする各[言語](create-add-on-store-listings.md#store-listing-languages)でストア登録情報を提供することをお勧めします。

| フィールド名                    | コメント                                       |
|-------------------------------|---------------------------------------------|
| [**タイトル**](create-add-on-store-listings.md#title)                    | 必須 (100 文字以内)              |
| [**説明**](create-add-on-store-listings.md#description)       | 省略可能 (200 文字以内)              |
| [**アイコン**](create-add-on-store-listings.md#icon)                    | 省略可能 (.png、300 x 300 ピクセル)             |

<span/>

これらの情報の入力が完了したら、**[ストアに提出]** をクリックします。 ほとんどの場合、認定プロセスは約 1 時間かかります。 その後、アドオンはストアに公開され、お客様が購入できるようになります。

> [!NOTE]
> アドオンは、アプリのコードでも実装する必要があります。 詳しくは、「[アプリ内購入と試用版](../monetize/in-app-purchases-and-trials.md)」をご覧ください。


## <a name="updating-an-add-on-after-publication"></a>公開後のアドオンの更新

公開したアドオンはいつでも変更できます。 アドオンの変更はアプリとは別に申請および公開されるため、一般的には、価格や説明の更新などのアドオンに対する変更ではアプリ全体を更新する必要はありません。

> [!IMPORTANT]
> Windows 8.x のユーザーがこのアプリを利用できる場合、アドオンの更新がこれらのユーザーにも表示されるようにするために、新しいアプリの申請を作成して公開する必要があります。 同様に、アプリを公開した後で、Windows 8.x を対象とする新しいアドオンをアプリに追加する場合は、アドオンを参照するようにアプリのコードを更新して、アプリを再申請する必要があります。 それ以外の場合、新しいアドオンは、Windows 8.x のユーザーには表示されません。

更新を申請するには、ダッシュボードでアドオンのページに移動し、**[更新]** をクリックします。 これにより、以前の申請からの情報をひな型として、アドオンの新しい申請が作成されます。 目的の情報を変更したら、**[ストアに提出]** をクリックします。

既に提供されているアドオンを削除する場合は、新しい申請を作成し、[分布と認知度](set-add-on-pricing-and-availability.md) オプションを **[購入不可。アプリのリストには表示されません]** に変更します。 必要に応じて、アプリのコードを更新し、アドオンへの参照も削除してください。
