---
Description: Learn about several ways you can programmatically enable customers to rate and review your app.
title: アプリの評価とレビューを求める
ms.date: 06/15/2018
ms.topic: article
keywords: Windows 10, UWP, 評価, レビュー
ms.localizationpriority: medium
ms.openlocfilehash: 377b71dba2fb62dfc562b56d40e65e43b0bd49c9
ms.sourcegitcommit: 49d58bc66c1c9f2a4f81473bcb25af79e2b1088d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8946863"
---
# <a name="request-ratings-and-reviews-for-your-app"></a><span data-ttu-id="6d678-103">アプリの評価とレビューを求める</span><span class="sxs-lookup"><span data-stu-id="6d678-103">Request ratings and reviews for your app</span></span>

<span data-ttu-id="6d678-104">ユニバーサル Windows プラットフォーム (UWP) アプリでは、プログラムによってユーザーにアプリの評価やレビューを求めるコードを追加できます。</span><span class="sxs-lookup"><span data-stu-id="6d678-104">You can add code to your Universal Windows Platform (UWP) app to programmatically prompt your customers to rate or review your app.</span></span> <span data-ttu-id="6d678-105">これを実現する方法にはいくつかあります。</span><span class="sxs-lookup"><span data-stu-id="6d678-105">There are several ways you can do this:</span></span>
* <span data-ttu-id="6d678-106">アプリのコンテキストで評価とレビュー ダイアログを直接表示する。</span><span class="sxs-lookup"><span data-stu-id="6d678-106">You can show a rating and review dialog directly in the context of your app.</span></span>
* <span data-ttu-id="6d678-107">Microsoft Store のアプリの評価とレビュー ページをプログラムで開く。</span><span class="sxs-lookup"><span data-stu-id="6d678-107">You can programmatically open the rating and review page for your app in the Microsoft Store.</span></span>

<span data-ttu-id="6d678-108">評価とレビューのデータを分析する準備ができたら、パートナー センターでデータを表示したり、Microsoft Store 分析 API を使用してプログラムでこのデータを取得できます。</span><span class="sxs-lookup"><span data-stu-id="6d678-108">When you are ready to analyze your ratings and reviews data, you can view the data in Partner Center or use the Microsoft Store analytics API to retrieve this data programmatically.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="6d678-109">アプリ内で評価関数を追加するには、すべてのレビューは星評価選んだに関係なく、ストアの評価のメカニズムをユーザーに送信する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6d678-109">When adding a rating function within your app, all reviews must send the user to the Store’s rating mechanisms, regardless of star rating chosen.</span></span> <span data-ttu-id="6d678-110">ユーザーからのフィードバックやご意見を収集する場合は、明確なは、アプリの評価やストアでのレビューに関連しないが、アプリの開発者に直接送信されることがあります。</span><span class="sxs-lookup"><span data-stu-id="6d678-110">If you collect feedback or comments from users, it must be clear that it is not related to the app rating or reviews in the Store but is sent directly to the app developer.</span></span> <span data-ttu-id="6d678-111">開発者倫理規定[Fraudulent または悪意を持つアクティビティ](https://docs.microsoft.com/legal/windows/agreements/store-developer-code-of-conduct#3-fraudulent-or-dishonest-activities)に関連する詳細情報を参照してください。</span><span class="sxs-lookup"><span data-stu-id="6d678-111">See the Developer Code of Conduct for more information related to [Fraudulent or Dishonest Activities](https://docs.microsoft.com/legal/windows/agreements/store-developer-code-of-conduct#3-fraudulent-or-dishonest-activities).</span></span>

## <a name="show-a-rating-and-review-dialog-in-your-app"></a><span data-ttu-id="6d678-112">アプリ内での評価とレビュー ダイアログの表示</span><span class="sxs-lookup"><span data-stu-id="6d678-112">Show a rating and review dialog in your app</span></span>

<span data-ttu-id="6d678-113">アプリを評価してレビューを提出するようにユーザーに求めるダイアログを、アプリ内からプログラムによって表示するには、[Windows.Services.Store](https://docs.microsoft.com/uwp/api/windows.services.store) 名前空間の [SendRequestAsync](https://docs.microsoft.com/uwp/api/windows.services.store.storerequesthelper.sendrequestasync) メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="6d678-113">To programmatically show a dialog from your app that asks your customer to rate your app and submit a review, call the [SendRequestAsync](https://docs.microsoft.com/uwp/api/windows.services.store.storerequesthelper.sendrequestasync) method in the [Windows.Services.Store](https://docs.microsoft.com/uwp/api/windows.services.store) namespace.</span></span> <span data-ttu-id="6d678-114">以下のコード例に示すように、*requestKind* パラメーターには整数 16 を渡し、*parametersAsJson* パラメーターには空の文字列を渡します。</span><span class="sxs-lookup"><span data-stu-id="6d678-114">Pass the integer 16 to the *requestKind* parameter and an empty string to the *parametersAsJson* parameter as shown in this code example.</span></span> <span data-ttu-id="6d678-115">この例では、Newtonsoft の [Json.NET](http://www.newtonsoft.com/json) ライブラリと、**Windows.Services.Store**、**System.Threading.Tasks**、**Newtonsoft.Json.Linq** の各名前空間に対する using ステートメントが必要です。</span><span class="sxs-lookup"><span data-stu-id="6d678-115">This example requires the [Json.NET](http://www.newtonsoft.com/json) library from Newtonsoft, and it requires using statements for the **Windows.Services.Store**, **System.Threading.Tasks**, and **Newtonsoft.Json.Linq** namespaces.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="6d678-116">評価とレビュー ダイアログを表示する要求は、アプリの UI スレッドで呼び出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="6d678-116">The request to show the rating and review dialog must be called on the UI thread in your app.</span></span>

```csharp
public async Task<bool> ShowRatingReviewDialog()
{
    StoreSendRequestResult result = await StoreRequestHelper.SendRequestAsync(
        StoreContext.GetDefault(), 16, String.Empty);

    if (result.ExtendedError == null)
    {
        JObject jsonObject = JObject.Parse(result.Response);
        if (jsonObject.SelectToken("status").ToString() == "success")
        {
            // The customer rated or reviewed the app.
            return true;
        }
    }

    // There was an error with the request, or the customer chose not to
    // rate or review the app.
    return false;
}
```

<span data-ttu-id="6d678-117">**SendRequestAsync** メソッドは、シンプルな整数ベースの要求システムと JSON ベースのデータ パラメーターを使って、さまざまな Store 操作をアプリに公開します。</span><span class="sxs-lookup"><span data-stu-id="6d678-117">The **SendRequestAsync** method uses a simple integer-based request system and JSON-based data parameters to expose miscellaneous Store operations to apps.</span></span> <span data-ttu-id="6d678-118">*requestKind* パラメーターに整数 16 を渡すと、評価とレビュー ダイアログを表示する要求を発行したことになり、関連するデータが Store に送信されます。</span><span class="sxs-lookup"><span data-stu-id="6d678-118">When you pass the integer 16 to the *requestKind* parameter, you issue a request to show the rating and review dialog and send the related data to the Store.</span></span> <span data-ttu-id="6d678-119">このメソッドは Windows 10 Version 1607 で導入され、Visual Studio で **Windows 10 Anniversary Edition (10.0、ビルド 14393)** 以降のリリースをターゲットとするプロジェクトでのみ使用できます。</span><span class="sxs-lookup"><span data-stu-id="6d678-119">This method was introduced in Windows 10, version 1607, and it can only be used in projects that target **Windows 10 Anniversary Edition (10.0; Build 14393)** or a later release in Visual Studio.</span></span> <span data-ttu-id="6d678-120">このメソッドの一般的な概要については、「[Store に要求を送信する](send-requests-to-the-store.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6d678-120">For a general overview of this method, see [Send requests to the Store](send-requests-to-the-store.md).</span></span>

### <a name="response-data-for-the-rating-and-review-request"></a><span data-ttu-id="6d678-121">評価とレビューの要求に対する応答データ</span><span class="sxs-lookup"><span data-stu-id="6d678-121">Response data for the rating and review request</span></span>

<span data-ttu-id="6d678-122">評価とレビュー ダイアログを表示する要求を送信すると、[StoreSendRequestResult](https://docs.microsoft.com/uwp/api/windows.services.store.storesendrequestresult) の戻り値の [Response](https://docs.microsoft.com/uwp/api/windows.services.store.storesendrequestresult.Response) プロパティに、要求が成功したかどうかを示す JSON 形式の文字列が含められます。</span><span class="sxs-lookup"><span data-stu-id="6d678-122">After you submit the request to display the rating and review dialog, the [Response](https://docs.microsoft.com/uwp/api/windows.services.store.storesendrequestresult.Response) property of the [StoreSendRequestResult](https://docs.microsoft.com/uwp/api/windows.services.store.storesendrequestresult) return value contains a JSON-formatted string that indicates whether the request was successful.</span></span>

<span data-ttu-id="6d678-123">次の例は、ユーザーが評価またはレビューを正しく提出した後のこの要求の戻り値を示しています。</span><span class="sxs-lookup"><span data-stu-id="6d678-123">The following example demonstrates the return value for this request after the customer successfully submits a rating or review.</span></span>

```json
{ 
  "status": "success", 
  "data": {
    "updated": false
  },
  "errorDetails": "Success"
}
```

<span data-ttu-id="6d678-124">次の例は、ユーザーが評価またはレビューを提出しなかった後のこの要求の戻り値を示しています。</span><span class="sxs-lookup"><span data-stu-id="6d678-124">The following example demonstrates the return value for this request after the customer chooses not to submit a rating or review.</span></span>

```json
{ 
  "status": "aborted", 
  "errorDetails": "Navigation was unsuccessful"
}
```

<span data-ttu-id="6d678-125">次の表では、JSON 形式のデータ文字列に含まれるフィールドについて説明します。</span><span class="sxs-lookup"><span data-stu-id="6d678-125">The following table describes the fields in the JSON-formatted data string.</span></span>

|  <span data-ttu-id="6d678-126">フィールド</span><span class="sxs-lookup"><span data-stu-id="6d678-126">Field</span></span>  |  <span data-ttu-id="6d678-127">説明</span><span class="sxs-lookup"><span data-stu-id="6d678-127">Description</span></span>  |
|----------------------|---------------|
|  *<span data-ttu-id="6d678-128">status</span><span class="sxs-lookup"><span data-stu-id="6d678-128">status</span></span>*                   |  <span data-ttu-id="6d678-129">ユーザーから評価またはレビューが正しく提出されたかどうかを示す文字列です。</span><span class="sxs-lookup"><span data-stu-id="6d678-129">A string that indicates whether the customer successfully submitted a rating or review.</span></span> <span data-ttu-id="6d678-130">サポートされる値は **success** と **aborted** です。</span><span class="sxs-lookup"><span data-stu-id="6d678-130">The supported values are **success** and **aborted**.</span></span>   |
|  *<span data-ttu-id="6d678-131">data</span><span class="sxs-lookup"><span data-stu-id="6d678-131">data</span></span>*                   |  <span data-ttu-id="6d678-132">*updated* という名前の単一のブール値を含むオブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="6d678-132">An object that contains a single Boolean value named *updated*.</span></span> <span data-ttu-id="6d678-133">この値は、ユーザーが既存の評価またはレビューを更新したかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="6d678-133">This value indicates whether the customer updated an existing rating or review.</span></span> <span data-ttu-id="6d678-134">*data* オブジェクトは、成功の応答にのみ含まれます。</span><span class="sxs-lookup"><span data-stu-id="6d678-134">The *data* object is included in success responses only.</span></span>   |
|  *<span data-ttu-id="6d678-135">errorDetails</span><span class="sxs-lookup"><span data-stu-id="6d678-135">errorDetails</span></span>*                   |  <span data-ttu-id="6d678-136">要求のエラーの詳細を含む文字列です。</span><span class="sxs-lookup"><span data-stu-id="6d678-136">A string that contains the error details for the request.</span></span> |

## <a name="launch-the-rating-and-review-page-for-your-app-in-the-store"></a><span data-ttu-id="6d678-137">Store でのアプリの評価とレビュー ページの起動</span><span class="sxs-lookup"><span data-stu-id="6d678-137">Launch the rating and review page for your app in the Store</span></span>

<span data-ttu-id="6d678-138">Store のアプリの評価とレビュー ページをプログラムによって開くには、次のコード例に示すように、```ms-windows-store://review``` URI スキームを指定して [LaunchUriAsync](https://docs.microsoft.com/uwp/api/windows.system.launcher.launchuriasync) メソッドを使用します。</span><span class="sxs-lookup"><span data-stu-id="6d678-138">If you want to programmatically open the rating and review page for your app in the Store, you can use the [LaunchUriAsync](https://docs.microsoft.com/uwp/api/windows.system.launcher.launchuriasync) method with the ```ms-windows-store://review``` URI scheme as demonstrated in this code example.</span></span>

```csharp
bool result = await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-windows-store://review/?ProductId=9WZDNCRFHVJL"));
```

<span data-ttu-id="6d678-139">詳しくは、「[Microsoft Store アプリの起動](../launch-resume/launch-store-app.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6d678-139">For more information, see [Launch the Microsoft Store app](../launch-resume/launch-store-app.md).</span></span>

## <a name="analyze-your-ratings-and-reviews-data"></a><span data-ttu-id="6d678-140">評価とレビュー データの分析</span><span class="sxs-lookup"><span data-stu-id="6d678-140">Analyze your ratings and reviews data</span></span>

<span data-ttu-id="6d678-141">ユーザーから提出された評価とレビューのデータを分析するには、いくつかの方法があります。</span><span class="sxs-lookup"><span data-stu-id="6d678-141">To analyze the ratings and reviews data from your customers, you have several options:</span></span>
* <span data-ttu-id="6d678-142">パートナー センターで[レビュー](../publish/reviews-report.md)レポートを使用すると、顧客から評価とレビューを参照してください。</span><span class="sxs-lookup"><span data-stu-id="6d678-142">You can use the [Reviews](../publish/reviews-report.md) report in Partner Center to see the ratings and reviews from your customers.</span></span> <span data-ttu-id="6d678-143">このレポートは、ダウンロードしてオフラインで参照することもできます。</span><span class="sxs-lookup"><span data-stu-id="6d678-143">You can also download this report to view it offline.</span></span>
* <span data-ttu-id="6d678-144">Microsoft Store 分析 API の[アプリの評価の取得](get-app-ratings.md)メソッドと[アプリのレビューの取得](get-app-reviews.md)メソッドを使って、ユーザーから提出された評価とレビューをプログラムによって JSON 形式で取得できます。</span><span class="sxs-lookup"><span data-stu-id="6d678-144">You can use the [Get app ratings](get-app-ratings.md) and [Get app reviews](get-app-reviews.md) methods in the Store analytics API to programmatically retrieve the ratings and reviews from your customers in JSON format.</span></span>

## <a name="related-topics"></a><span data-ttu-id="6d678-145">関連トピック</span><span class="sxs-lookup"><span data-stu-id="6d678-145">Related topics</span></span>

* [<span data-ttu-id="6d678-146">Store に要求を送信する</span><span class="sxs-lookup"><span data-stu-id="6d678-146">Send requests to the Store</span></span>](send-requests-to-the-store.md)
* [<span data-ttu-id="6d678-147">Microsoft Store アプリの起動</span><span class="sxs-lookup"><span data-stu-id="6d678-147">Launch the Microsoft Store app</span></span>](../launch-resume/launch-store-app.md)
* [<span data-ttu-id="6d678-148">[レビュー] レポート</span><span class="sxs-lookup"><span data-stu-id="6d678-148">Reviews report</span></span>](../publish/reviews-report.md)
