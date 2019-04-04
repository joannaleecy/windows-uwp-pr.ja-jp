---
description: 支払いの要求の API は、支払情報を入力し、出荷方法を選択するユーザーを要求する場合のプロセスをバイパスする UWP アプリの統合ソリューションを提供します。
title: 支払い要求 API で支払いを簡略化する
ms.date: 09/26/2017
ms.topic: article
keywords: windows 10、uwp、支払い要求
ms.openlocfilehash: e5fb5cead7833b8cc213c6633cae6cee0da3466b
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57607867"
---
# <a name="simplify-payments-with-the-payment-request-api"></a><span data-ttu-id="8ca2f-104">支払い要求 API で支払いを簡略化する</span><span class="sxs-lookup"><span data-stu-id="8ca2f-104">Simplify payments with the Payment Request API</span></span>
<span data-ttu-id="8ca2f-105">UWP アプリの支払い要求 API がに基づいて、 [W3C 支払い要求の API 仕様](https://w3c.github.io/browser-payment-api/)します。これは、UWP アプリでチェック アウト プロセスを効率化機能を提供します。</span><span class="sxs-lookup"><span data-stu-id="8ca2f-105">The Payment Request API  for UWP apps is based on the [W3C Payment Request API spec](https://w3c.github.io/browser-payment-api/). It gives you the ability to streamline the checkout process in your UWP apps.</span></span> <span data-ttu-id="8ca2f-106">ユーザーには、チェック アウトをお支払い方法を使用して、送付先住所が既に Microsoft アカウントを使って保存の高速化できます。</span><span class="sxs-lookup"><span data-stu-id="8ca2f-106">Users can speed through checkout by using payment options and shipping addresses already saved with their Microsoft account.</span></span> <span data-ttu-id="8ca2f-107">コンバージョン率を向上し、支払情報をトークン化されたため、データ漏えいのリスクを軽減できます。</span><span class="sxs-lookup"><span data-stu-id="8ca2f-107">You can increase your conversion rate and reduce your risk of data breaches because the payment information is tokenized.</span></span> <span data-ttu-id="8ca2f-108">以降、Windows 10 Creators Update では、ユーザーは UWP アプリでのエクスペリエンス全体で簡単に支払いに、保存済みのお支払い方法を使用できます。</span><span class="sxs-lookup"><span data-stu-id="8ca2f-108">Starting with the Windows 10 Creators Update, users can use their saved payment options to pay easily across  experiences in UWP apps.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="8ca2f-109">前提条件</span><span class="sxs-lookup"><span data-stu-id="8ca2f-109">Prerequisites</span></span>
<span data-ttu-id="8ca2f-110">支払い要求 API の使用を開始する前に、いくつかの点に注意してくださいまたは行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="8ca2f-110">Before you begin using the Payment Request API, there are a few things you must do or be aware of.</span></span>

### <a name="getting-a-merchant-id"></a><span data-ttu-id="8ca2f-111">マーチャント ID の取得</span><span class="sxs-lookup"><span data-stu-id="8ca2f-111">Getting a Merchant ID</span></span>
<span data-ttu-id="8ca2f-112">支払い要求プロセスの一環として、Microsoft は、サービス プロバイダーから、あなたに代わって支払いトークンを要求します。</span><span class="sxs-lookup"><span data-stu-id="8ca2f-112">As part of the payment-request process, Microsoft requests payment tokens on your behalf from your service provider.</span></span> <span data-ttu-id="8ca2f-113">したがって、API を使用する前にそれらのトークンを要求するユーザーの承認が必要です。</span><span class="sxs-lookup"><span data-stu-id="8ca2f-113">So before you can start using the API, we need your authorization to request those tokens.</span></span>  <span data-ttu-id="8ca2f-114">販売者アカウントの登録を行い、必要な権限を提供する、いくつかの手順に従ってください。</span><span class="sxs-lookup"><span data-stu-id="8ca2f-114">You must follow a few steps to register for a seller account and provide the necessary authorization.</span></span> <span data-ttu-id="8ca2f-115">移動するには、 [Microsoft 販売者 Center](https://seller.microsoft.com/en-us/dashboard/registration/seller/?accountprogram=uwp)します。</span><span class="sxs-lookup"><span data-stu-id="8ca2f-115">To do that, go to [Microsoft Seller Center](https://seller.microsoft.com/en-us/dashboard/registration/seller/?accountprogram=uwp).</span></span> <span data-ttu-id="8ca2f-116">これを完了したら、コピー結果として得られる販売者から支払いの要求を構築するときに、アプリにパートナー センターの ID。</span><span class="sxs-lookup"><span data-stu-id="8ca2f-116">Once you have done this, copy the resulting merchant ID from Partner Center into your app when constructing the payment request.</span></span> <span data-ttu-id="8ca2f-117">次に、アプリケーションでは、支払いの要求を送信するときに、お客様の支払いを送信する必要がありますプロセッサから支払トークンを受け取ります。</span><span class="sxs-lookup"><span data-stu-id="8ca2f-117">Then, when your application submits a payment request, you will receive a payment token from your processor which you will need to submit your payment.</span></span>

### <a name="geographic-restrictions-and-language-support"></a><span data-ttu-id="8ca2f-118">地理的な制限事項および言語のサポート</span><span class="sxs-lookup"><span data-stu-id="8ca2f-118">Geographic restrictions and language support</span></span>
<span data-ttu-id="8ca2f-119">支払いの要求の API は、米国の州のトランザクションの処理に米国の企業でのみ使用できます。</span><span class="sxs-lookup"><span data-stu-id="8ca2f-119">The Payment Request API can be used only by US-based businesses to process transactions in the United States.</span></span>

## <a name="using-the-payment-request-api-in-your-app-step-by-step"></a><span data-ttu-id="8ca2f-120">アプリで、支払いの要求の API の使用: ステップ バイ ステップ</span><span class="sxs-lookup"><span data-stu-id="8ca2f-120">Using the Payment Request API in your app: step by step</span></span>
<span data-ttu-id="8ca2f-121">このセクションで使用する方法を示す、 [UWP 支払い要求 API](https://docs.microsoft.com/en-us/uwp/api/windows.applicationmodel.payments)アプリ。</span><span class="sxs-lookup"><span data-stu-id="8ca2f-121">This section demonstrates how to use the [UWP Payment Request API](https://docs.microsoft.com/en-us/uwp/api/windows.applicationmodel.payments) in your app.</span></span> <span data-ttu-id="8ca2f-122">わかりやすくする最も単純な形式でここで API を使用しています。</span><span class="sxs-lookup"><span data-stu-id="8ca2f-122">We use the API here in its simplest form for the sake of clarity.</span></span> <span data-ttu-id="8ca2f-123">これらの Api のより高度な用途の例は、、 [github アプリのサンプルを UWP ショッピング](https://github.com/Microsoft/Windows-appsample-shopping)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="8ca2f-123">For an example of more advanced use of these APIs, see the [UWP Shopping app sample on GitHub](https://github.com/Microsoft/Windows-appsample-shopping).</span></span>

### <a name="1-create-a-set-of-all-the-payment-options-that-you-accept"></a><span data-ttu-id="8ca2f-124">1. そのまま使用するすべてのお支払い方法のセットを作成します。</span><span class="sxs-lookup"><span data-stu-id="8ca2f-124">1. Create a set of all the payment options that you accept.</span></span>
> [!Note]
> <span data-ttu-id="8ca2f-125">置換、**マーチャント id から seller ポータル**Seller センターから受信した販売者とテキストが ID。</span><span class="sxs-lookup"><span data-stu-id="8ca2f-125">Replace the **merchant-id-from-seller-portal** text with the merchant ID that you received from the Seller Center.</span></span>

[!code-cs[SnippetEnumerate](./code/PaymentsApiSample/PaymentsApiSample/MainPage.xaml.cs#SnippetEnumerate)]

### <a name="2-pull-the-payment-details-together"></a><span data-ttu-id="8ca2f-126">2. お支払いの詳細をまとめてプルします。</span><span class="sxs-lookup"><span data-stu-id="8ca2f-126">2. Pull the payment details together.</span></span> 

<span data-ttu-id="8ca2f-127">これらの詳細は、支払いアプリでユーザーに表示されます。</span><span class="sxs-lookup"><span data-stu-id="8ca2f-127">These details will be shown to the user in the payment app.</span></span> 

[!code-cs[SnippetDisplayItems](./code/PaymentsApiSample/PaymentsApiSample/MainPage.xaml.cs#SnippetDisplayItems)]

### <a name="3-include-the-sales-tax"></a><span data-ttu-id="8ca2f-128">3.売上税が含まれます。</span><span class="sxs-lookup"><span data-stu-id="8ca2f-128">3. Include the sales tax.</span></span> 

> [!Important]
> <span data-ttu-id="8ca2f-129">API は、項目を追加または売上税を計算するはできません。</span><span class="sxs-lookup"><span data-stu-id="8ca2f-129">The API does not add up items or calculate the sales tax for you.</span></span> <span data-ttu-id="8ca2f-130">税率が管轄によって異なることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="8ca2f-130">Remember that tax rates vary by jurisdiction.</span></span> <span data-ttu-id="8ca2f-131">わかりやすくするために、仮定の 9.5% 税率を使用します。</span><span class="sxs-lookup"><span data-stu-id="8ca2f-131">For clarity, we use a hypothetical 9.5% tax rate.</span></span>

[!code-cs[SnippetTaxes](./code/PaymentsApiSample/PaymentsApiSample/MainPage.xaml.cs#SnippetTaxes)]

### <a name="4-optional--add-discounts-or-other-modifiers-to-the-total"></a><span data-ttu-id="8ca2f-132">4。(省略可能) 合計割引またはその他の修飾子を追加します。</span><span class="sxs-lookup"><span data-stu-id="8ca2f-132">4. (Optional)  Add discounts or other modifiers to the total.</span></span> 

<span data-ttu-id="8ca2f-133">表示項目に特定の Contoso クレジット カードを使用するための割引を追加する例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="8ca2f-133">Here's an example of adding a discount for using a specific Contoso credit card to the display items.</span></span> <span data-ttu-id="8ca2f-134">(*Contoso*架空の名前を指定します)。</span><span class="sxs-lookup"><span data-stu-id="8ca2f-134">(*Contoso* is a fictitious name.)</span></span>

[!code-cs[SnippetDiscountRate](./code/PaymentsApiSample/PaymentsApiSample/MainPage.xaml.cs#SnippetDiscountRate)]

### <a name="5-assemble-all-the-payment-details"></a><span data-ttu-id="8ca2f-135">5。すべてのお支払いの詳細をアセンブルします。</span><span class="sxs-lookup"><span data-stu-id="8ca2f-135">5. Assemble all the payment details.</span></span>

[!code-cs[SnippetAggregate](./code/PaymentsApiSample/PaymentsApiSample/MainPage.xaml.cs#SnippetAggregate)]
[!code-cs[SnippetPaymentOptions](./code/PaymentsApiSample/PaymentsApiSample/MainPage.xaml.cs#SnippetPaymentOptions)]

### <a name="6-submit-the-payment-request"></a><span data-ttu-id="8ca2f-136">6。支払いの要求を送信します。</span><span class="sxs-lookup"><span data-stu-id="8ca2f-136">6. Submit the payment request.</span></span> 

<span data-ttu-id="8ca2f-137">呼び出す、 **SubmitPaymentRequestAsync**メソッドして支払いのリクエストを送信します。</span><span class="sxs-lookup"><span data-stu-id="8ca2f-137">Call the **SubmitPaymentRequestAsync** method to submit your payment request.</span></span> <span data-ttu-id="8ca2f-138">使用可能な支払いオプションを表示した支払いアプリが表示されます。</span><span class="sxs-lookup"><span data-stu-id="8ca2f-138">This brings up the payment app showing the available payment options.</span></span>

[!code-cs[SnippetSubmit](./code/PaymentsApiSample/PaymentsApiSample/MainPage.xaml.cs#SnippetSubmit)]

<span data-ttu-id="8ca2f-139">Microsoft アカウントでサインインを求められます。</span><span class="sxs-lookup"><span data-stu-id="8ca2f-139">The user is prompted to sign in with their Microsoft account.</span></span>

<span data-ttu-id="8ca2f-140">ユーザーがサインインした後お支払い方法と保存された送付先住所を選択できます。</span><span class="sxs-lookup"><span data-stu-id="8ca2f-140">After the user signs in, they can select payment options and shipping address that were previously saved.</span></span>

<span data-ttu-id="8ca2f-141">![支払い要求 UI](./images/33.png "支払い要求 UI")</span><span class="sxs-lookup"><span data-stu-id="8ca2f-141">![Payment Request UI](./images/33.png "Payment Request UI")</span></span>

<span data-ttu-id="8ca2f-142">アプリをユーザーがタップ待ちます**支払い**、し、注文を完了します。</span><span class="sxs-lookup"><span data-stu-id="8ca2f-142">Your app waits for the user to tap **Pay**, then completes the order.</span></span>

[!code-cs[SnippetComplete](./code/PaymentsApiSample/PaymentsApiSample/MainPage.xaml.cs#SnippetComplete)]

<span data-ttu-id="8ca2f-143">支払いが完了すると、ユーザーがで表示されます、**注文確認済**画面。</span><span class="sxs-lookup"><span data-stu-id="8ca2f-143">After payment is complete, the user is presented with an **Order confirmed** screen.</span></span>

<span data-ttu-id="8ca2f-144">![注文確認済](./images/44.png "順序の確認 ")</span><span class="sxs-lookup"><span data-stu-id="8ca2f-144">![Order confirmed](./images/44.png "Order confirmed ")</span></span>

## <a name="see-also"></a><span data-ttu-id="8ca2f-145">関連項目</span><span class="sxs-lookup"><span data-stu-id="8ca2f-145">See also</span></span>
- [<span data-ttu-id="8ca2f-146">Windows.ApplicationModel.Payments リファレンス ドキュメント</span><span class="sxs-lookup"><span data-stu-id="8ca2f-146">Windows.ApplicationModel.Payments reference documentation</span></span>](https://docs.microsoft.com/en-us/uwp/api/windows.applicationmodel.payments)
- [<span data-ttu-id="8ca2f-147">GitHub での UWP ショッピング アプリのサンプル</span><span class="sxs-lookup"><span data-stu-id="8ca2f-147">UWP shopping app sample on GitHub</span></span>](https://github.com/Microsoft/Windows-appsample-shopping)
- [<span data-ttu-id="8ca2f-148">W3C 支払い要求の API 仕様</span><span class="sxs-lookup"><span data-stu-id="8ca2f-148">W3C Payment Request API specification</span></span>](https://www.w3.org/TR/payment-request/)
- [<span data-ttu-id="8ca2f-149">支払い要求 API </span><span class="sxs-lookup"><span data-stu-id="8ca2f-149">Payment Request API </span></span>](https://docs.microsoft.com/en-us/microsoft-edge/dev-guide/device/payment-request-api)

