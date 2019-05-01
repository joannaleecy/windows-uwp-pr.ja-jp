---
description: 支払いの要求の API は、支払情報を入力し、出荷方法を選択するユーザーを要求する場合のプロセスをバイパスする UWP アプリの統合ソリューションを提供します。
title: 支払い要求 API で支払いを簡略化する
ms.date: 09/26/2017
ms.topic: article
keywords: windows 10、uwp、支払い要求
ms.openlocfilehash: a40b8265e3445319bd7baa530df0f9e9eaae0f31
ms.sourcegitcommit: fca0132794ec187e90b2ebdad862f22d9f6c0db8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/24/2019
ms.locfileid: "63804491"
---
# <a name="simplify-payments-with-the-payment-request-api"></a>支払い要求 API で支払いを簡略化する
UWP アプリの支払い要求 API がに基づいて、 [W3C 支払い要求の API 仕様](https://w3c.github.io/browser-payment-api/)します。これは、UWP アプリでチェック アウト プロセスを効率化機能を提供します。 ユーザーには、チェック アウトをお支払い方法を使用して、送付先住所が既に Microsoft アカウントを使って保存の高速化できます。 コンバージョン率を向上し、支払情報をトークン化されたため、データ漏えいのリスクを軽減できます。 以降、Windows 10 Creators Update では、ユーザーは UWP アプリでのエクスペリエンス全体で簡単に支払いに、保存済みのお支払い方法を使用できます。

## <a name="prerequisites"></a>前提条件
支払い要求 API の使用を開始する前に、いくつかの点に注意してくださいまたは行う必要があります。

### <a name="getting-a-merchant-id"></a>マーチャント ID の取得
支払い要求プロセスの一環として、Microsoft は、サービス プロバイダーから、あなたに代わって支払いトークンを要求します。 したがって、API を使用する前にそれらのトークンを要求するユーザーの承認が必要です。  販売者アカウントの登録を行い、必要な権限を提供する、いくつかの手順に従ってください。 移動するには、 [Microsoft 販売者 Center](https://seller.microsoft.com/en-us/dashboard/registration/seller/?accountprogram=uwp)します。 これを完了したら、コピー結果として得られる販売者から支払いの要求を構築するときに、アプリにパートナー センターの ID。 次に、アプリケーションでは、支払いの要求を送信するときに、お客様の支払いを送信する必要がありますプロセッサから支払トークンを受け取ります。

### <a name="geographic-restrictions-and-language-support"></a>地理的な制限事項および言語のサポート
支払いの要求の API は、米国の州のトランザクションの処理に米国の企業でのみ使用できます。

## <a name="using-the-payment-request-api-in-your-app-step-by-step"></a>アプリで、支払いの要求の API の使用: ステップ バイ ステップ
このセクションで使用する方法を示す、 [UWP 支払い要求 API](https://docs.microsoft.com/en-us/uwp/api/windows.applicationmodel.payments)アプリ。 わかりやすくする最も単純な形式でここで API を使用しています。 これらの Api のより高度な用途の例は、次を参照してください。、 [github アプリのサンプルを UWP ショッピング](https://github.com/Microsoft/Windows-appsample-shopping)します。

### <a name="1-create-a-set-of-all-the-payment-options-that-you-accept"></a>1. そのまま使用するすべてのお支払い方法のセットを作成します。
> [!Note]
> 置換、**マーチャント id から seller ポータル**Seller センターから受信した販売者とテキストが ID。

[!code-csharp[SnippetEnumerate](./code/PaymentsApiSample/PaymentsApiSample/MainPage.xaml.cs#SnippetEnumerate)]

### <a name="2-pull-the-payment-details-together"></a>2. お支払いの詳細をまとめてプルします。 

これらの詳細は、支払いアプリでユーザーに表示されます。 

[!code-csharp[SnippetDisplayItems](./code/PaymentsApiSample/PaymentsApiSample/MainPage.xaml.cs#SnippetDisplayItems)]

### <a name="3-include-the-sales-tax"></a>3.売上税が含まれます。 

> [!Important]
> API は、項目を追加または売上税を計算するはできません。 税率が管轄によって異なることに注意してください。 わかりやすくするために、仮定の 9.5% 税率を使用します。

[!code-csharp[SnippetTaxes](./code/PaymentsApiSample/PaymentsApiSample/MainPage.xaml.cs#SnippetTaxes)]

### <a name="4-optional--add-discounts-or-other-modifiers-to-the-total"></a>4。(省略可能) 合計割引またはその他の修飾子を追加します。 

表示項目に特定の Contoso クレジット カードを使用するための割引を追加する例を次に示します。 (*Contoso*架空の名前を指定します)。

[!code-csharp[SnippetDiscountRate](./code/PaymentsApiSample/PaymentsApiSample/MainPage.xaml.cs#SnippetDiscountRate)]

### <a name="5-assemble-all-the-payment-details"></a>5。すべてのお支払いの詳細をアセンブルします。

[!code-csharp[SnippetAggregate](./code/PaymentsApiSample/PaymentsApiSample/MainPage.xaml.cs#SnippetAggregate)]
[!code-csharp[SnippetPaymentOptions](./code/PaymentsApiSample/PaymentsApiSample/MainPage.xaml.cs#SnippetPaymentOptions)]

### <a name="6-submit-the-payment-request"></a>6。支払いの要求を送信します。 

呼び出す、 **SubmitPaymentRequestAsync**メソッドして支払いのリクエストを送信します。 使用可能な支払いオプションを表示した支払いアプリが表示されます。

[!code-csharp[SnippetSubmit](./code/PaymentsApiSample/PaymentsApiSample/MainPage.xaml.cs#SnippetSubmit)]

Microsoft アカウントでサインインを求められます。

ユーザーがサインインした後お支払い方法と保存された送付先住所を選択できます。

![支払い要求 UI](./images/33.png "支払い要求 UI")

アプリをユーザーがタップ待ちます**支払い**、し、注文を完了します。

[!code-csharp[SnippetComplete](./code/PaymentsApiSample/PaymentsApiSample/MainPage.xaml.cs#SnippetComplete)]

支払いが完了すると、ユーザーがで表示されます、**注文確認済**画面。

![注文確認済](./images/44.png "順序の確認 ")

## <a name="see-also"></a>関連項目
- [Windows.ApplicationModel.Payments リファレンス ドキュメント](https://docs.microsoft.com/en-us/uwp/api/windows.applicationmodel.payments)
- [GitHub での UWP ショッピング アプリのサンプル](https://github.com/Microsoft/Windows-appsample-shopping)
- [W3C 支払い要求の API 仕様](https://www.w3.org/TR/payment-request/)
- [支払い要求 API ](https://docs.microsoft.com/en-us/microsoft-edge/dev-guide/device/payment-request-api)

