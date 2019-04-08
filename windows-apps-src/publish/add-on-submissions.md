---
Description: アドオン (またはアプリ内製品) は、パートナー センターを通じて公開されます。
title: アドオンの申請
ms.assetid: E175AF9E-A1D4-45DF-B353-5E24E573AE67
ms.date: 10/31/2018
ms.topic: article
keywords: windows 10, uwp, iap, アプリ内購入, アプリ内製品, iap の申請
ms.localizationpriority: medium
ms.openlocfilehash: 28383ed82c418ff15806c325d6eab5a05f9987bf
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57620367"
---
# <a name="add-on-submissions"></a>アドオンの申請

アドオン (アプリ内製品とも呼ばれる) は、お客様が購入可能なアプリの補助アイテムです。 アドオンは、楽しいと思う新しいゲーム レベル、またはその他の新機能はユーザーとのつながりを維持できます。 アドオンは収益を得るためだけでなく、お客様との意見交換や顧客エンゲージメントの獲得を促すためにも役立ちます。

アドオンは経由で公開[パートナー センター](https://partner.microsoft.com/dashboard)、する必要があります、アクティブなと[開発者アカウント](https://go.microsoft.com/fwlink/p/?LinkId=615100)。 また、アプリのコードで [アドオンを有効にする](../monetize/in-app-purchases-and-trials.md)ことも必要です。

アドオンの提出プロセスの最初の手順は、パートナー センターで、アドオンを作成する、[製品の種類と製品 ID を定義する](set-your-add-on-product-id.md)します。 その後、Microsoft Store を使用して、アドオンを購入できるように、提出を作成します。 [アプリの申請](app-submissions.md)と同時にまたは別々にアドオンを申請できます。 アプリがストアに公開された後は、アプリを再び申請することなく、アドオンを[更新](#updating-an-add-on-after-publication)できます。

> [!NOTE]
> ドキュメントのこのセクションでは、パートナー センターでアドオンを送信する方法について説明します。 ここで説明する方法以外に、[Microsoft Store 申請 API](../monetize/create-and-manage-submissions-using-windows-store-services.md) を使用してアドオン申請を自動化することもできます。


## <a name="checklist-for-submitting-an-add-on"></a>アドオンの申請用チェック リスト

アドオンの申請を作成するときに提供する情報の一覧を次に示します。 提供が必須である情報については、次の一覧に示してあります。 また、省略可能な情報もあります。既に提供されている既定値は必要に応じて変更できます。


### <a name="create-a-new-add-on-page"></a>新しいアドオン ページを作成する

| フィールド名                    | メモ                            |
|-------------------------------|----------------------------------|
| [**製品の種類**](set-your-add-on-product-id.md#product-type)      | 必須 |  
| [**製品 ID**](set-your-add-on-product-id.md#product-id)          | 必須 |        


### <a name="properties-page"></a>[プロパティ] ページ

| フィールド名                    | メモ                              |   
|-------------------------------|------------------------------------|
| [**製品の有効期間**](enter-add-on-properties.md#product-lifetime)  | 製品の種類が **[永続的]** である場合は必須です。 他の種類の製品には適用されません。 |
| [**数量**](enter-add-on-properties.md#quantity)  | 製品の種類が **[ストアで管理されるコンシューマブル]** の場合は必須です。 他の種類の製品には適用されません。 |
| [**サブスクリプション期間**](enter-add-on-properties.md#subscription-period)          | 製品の種類が **[サブスクリプション]** である場合は必須です。 他の種類の製品には適用されません。       |  
| [**無料試用版**](enter-add-on-properties.md#free-trial)          | 製品の種類が **[サブスクリプション]** である場合は必須です。 他の種類の製品には適用されません。       |
| [**コンテンツの種類**](enter-add-on-properties.md#content-type)          | 必須    |               
| [**キーワード**](enter-add-on-properties.md#keywords)                  | 省略可能 (10 キーワードまで、それぞれ 30 文字以内)。 |
| [**開発者がカスタム データ**](enter-add-on-properties.md#custom-developer-data)   | 省略可能 (3,000 文字以内)。            |


### <a name="pricing-and-availability-page"></a>[価格と使用可能状況] ページ

| フィールド名                    | メモ                                       |
|-------------------------------|---------------------------------------------|
| [**市場**](set-add-on-pricing-and-availability.md#markets)  | 既定:すべての可能な市場 |
| [**可視性**](set-add-on-pricing-and-availability.md#visibility)   | 既定:ご購入いただけます。 アプリのリストに表示されます |
| [**スケジュール**](set-add-on-pricing-and-availability.md#schedule)    | 既定:できるだけ早くリリース
| [**価格**](set-add-on-pricing-and-availability.md#pricing)                | 必須                                    |
| [**販売価格**](put-apps-and-add-ons-on-sale.md)               | 省略可能                    |


### <a name="store-listings"></a>ストア登録情報

1 つのストア登録情報が必要です。 アプリがサポートする各[言語](create-add-on-store-listings.md#store-listing-languages)でストア登録情報を提供することをお勧めします。

| フィールド名                    | メモ                                       |
|-------------------------------|---------------------------------------------|
| [**タイトル**](create-add-on-store-listings.md#title)                    | 必須 (100 文字以内)           |
| [**説明**](create-add-on-store-listings.md#description)       | 省略可能 (200 文字以内)            |
| [**アイコン**](create-add-on-store-listings.md#icon)                    | 省略可能 (.png、300 x 300 ピクセル)            |


これらの情報の入力が完了したら、**[Submit to the Store]** (ストアに提出) をクリックします。 ほとんどの場合、認定プロセスは約 1 時間かかります。 その後、アドオンはストアに公開され、お客様が購入できるようになります。

> [!NOTE]
> アドオンは、アプリのコードでも実装する必要があります。 詳しくは、「[アプリ内購入と試用版](../monetize/in-app-purchases-and-trials.md)」をご覧ください。


## <a name="updating-an-add-on-after-publication"></a>公開後のアドオンの更新

公開したアドオンはいつでも変更できます。 アドオンの変更は送信しを一般に、アドオンの価格または説明の更新などに変更するにはアプリ全体を更新する必要はありませんので、アプリとは無関係に発行します。

更新を送信するには、パートナー センターで、追加でのページに移動し、をクリックして**Update**します。 これにより、開始点として、前の送信からの情報を使用して、アドオンの新規サブミッションが作成されます。 をクリックした場合、変更を加える**ストアに送信**します。

既に提供されているアドオンを削除する場合は、新しい申請を作成して、[[分布と認知度]](set-add-on-pricing-and-availability.md) オプションを **[ストアに表示しない]** に変更し、**[購入の停止]** オプションを選択します。 アドオンへの参照を削除する必要に応じて、アプリのコードを更新してください (それ以前以前発行されたアプリに Windows 8.1 がサポートしている場合に特にこの可視性の設定には適用されません顧客)。

> [!IMPORTANT]
> 以前に発行アプリが Windows のユーザーに使用可能なかどうかは作成して、アドオンの更新プログラムを顧客に表示されるようにするために新しいアプリの提出を発行する必要がある 8.x、します。 同様に、アプリを公開した後で、Windows 8.x を対象とする新しいアドオンをアプリに追加する場合は、アドオンを参照するようにアプリのコードを更新して、アプリを再申請する必要があります。 それ以外の場合、新しいアドオンは、Windows 8.x のユーザーには表示されません。
