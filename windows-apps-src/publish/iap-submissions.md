---
author: jnHs
Description: "IAP は Windows デベロッパー センター ダッシュボードを使って公開します。"
title: "IAP の申請"
ms.assetid: E175AF9E-A1D4-45DF-B353-5E24E573AE67
ms.sourcegitcommit: 97f4aee47cab9064ac053e7a6e16441d6960d41f
ms.openlocfilehash: 4a1764dfb8f94409aba973a28ba2999854179196

---

# IAP の申請


IAP (アプリ内製品) は、お客様が購入可能なアプリの補助アイテムです。 IAP には、楽しいアドオン新機能、新しいゲーム レベル、またはユーザーの関心を引くと思われるその他のアイテムなどがあります。 IAP は収益を得るためだけでなく、お客様との意見交換や顧客エンゲージメントの獲得を促すためにも役立ちます。

IAP は Windows デベロッパー センター ダッシュボードを使って公開します。 また、アプリのコードで [IAP を有効にする](../monetize/enable-in-app-product-purchases.md)ことも必要です。

IAP の申請プロセスでは、最初に、[その製品の種類と製品 ID を定義](set-your-iap-product-id.md)して、ダッシュボードで IAP を作成します。 その後、IAP が Windows ストアで購入可能になるように申請を作成できます。 [アプリの申請](app-submissions.md)と同時にまたは別々に IAP を申請できます。 アプリがストアに公開された後は、アプリを再び申請することなく、IAP を[更新](#updating-an-iap-after-submission)できます。

## IAP の申請用チェック リスト

IAP の申請を作成するときに提供する情報の一覧を次に示します。 提供が必須である情報については、次の一覧に示してあります。 また、省略可能な情報もあります。既に提供されている既定値は必要に応じて変更できます。

### [新しい IAP の作成] ページ
| フィールド名                    | コメント                            | 
|-------------------------------|----------------------------------|
| [**製品の種類**](set-your-iap-product-id.md#product-type)      | 必須。 **[永続的]** を選んだ場合は、**[製品の有効期限]** を指定する必要があります。 |  
| [**製品 ID**](set-your-iap-product-id.md#product-id)          | 必須 |        

### [プロパティ] ページ
| フィールド名                    | コメント                              |   
|-------------------------------|------------------------------------|
| [**製品の有効期限**](enter-iap-properties.md#product-lifetime)  | 製品の種類が **[永続的]** である場合は、必須です。 製品の種類が **[消費可能]** の場合は適用されません。 | 
| [**コンテンツの種類**](enter-iap-properties.md#content-type)          | 必須       |               
| [**キーワード**](enter-iap-properties.md#keywords)                  | 省略可能 (最大で 10 個まで。それぞれ 30 文字以内)。 | 
| [**タグ**](enter-iap-properties.md#tag)                               | 省略可能 (3,000 文字以内)。             | 

### [価格と使用可能状況] ページ 
| フィールド名                    | コメント                                       | 
|-------------------------------|---------------------------------------------|
| [**基本価格**](set-iap-pricing-and-availability.md#base-price)                | 必須                                    | 
| [**市場とカスタム価格**](set-iap-pricing-and-availability.md#markets-and-custom-prices)  | 既定: お客様は対象となるすべての市場で購入できます。 | 
| [**セール価格**](put-apps-and-iaps-on-sale.md)               | 省略可能。                             |
| [**Distribution and visibility (配布と表示)**](set-iap-pricing-and-availability.md#distribution-and-visibility)   | 既定: お客様はストアを参照または検索することで IAP を見つけることができます。 | 
| [**公開日**](set-iap-pricing-and-availability.md#publish-date)                | 既定: IAP は認定に合格するとすぐに公開されます。 |

### [説明] ページ
1 つの説明が必要です。 アプリがサポートする各[言語](create-iap-descriptions.md#languages)で説明を提供することをお勧めします。

| フィールド名                    | コメント                                       | 
|-------------------------------|---------------------------------------------|
| [**タイトル**](create-iap-descriptions.md#title)                    | 必須 (100 文字以内)              |
| [**説明**](create-iap-descriptions.md#description)       | 省略可能 (200 文字以内)              |
| [**アイコン**](create-iap-descriptions.md#icon)                    | 省略可能 (.png、300 x 300 ピクセル)             | 

これらの情報の入力が完了したら、**[Submit to the Store]** (ストアに提出) をクリックします。 ほとんどの場合、認定プロセスは約 1 時間かかります。 その後、IAP はストアに公開され、お客様が購入できるようになります。

**注**  IAP は、アプリのコードでも実装する必要があります。 詳しくは、「[アプリ内製品購入の有効化](../monetize/enable-in-app-product-purchases.md)」をご覧ください。


## 公開後の IAP の更新

公開した IAP はいつでも変更できます。 IAP の変更はアプリとは別に申請および公開されるため、一般的には、価格や説明の更新などの IAP に対する変更ではアプリ全体を更新する必要はありません。

> **重要**  Windows 8.x のユーザーがこのアプリを利用できる場合、IAP の更新がこれらのユーザーにも表示されるようにするために、新しいアプリの申請を作成して公開する必要があります。 同様に、アプリを公開した後で、Windows 8.x を対象とする新しい IAP をアプリに追加する場合は、IAP を参照するようにアプリのコードを更新して、アプリを再申請する必要があります。 それ以外の場合、新しい IAP は、Windows 8.x のユーザーには表示されません。

更新を申請するには、ダッシュボードで IAP のページに移動し、**[更新]** をクリックします。 これにより、以前の申請からの情報をひな型として、IAP の新しい申請が作成されます。 目的の情報を変更したら、**[Submit to the Store]** (ストアに提出) をクリックします。

既に提供されている IAP を削除する場合は、新しい申請を作成し、[分布と認知度](set-iap-pricing-and-availability.md) オプションを **[購入不可。アプリのリストには表示されません]** に変更します。 必要に応じて、アプリのコードを更新し、IAP への参照も削除してください。




<!--HONumber=Jun16_HO4-->


