---
Description: Learn about several ways you can programmatically enable customers to rate and review your app.
title: アプリの評価とレビューを求める
ms.date: 01/22/2019
ms.topic: article
keywords: Windows 10, UWP, 評価, レビュー
ms.localizationpriority: medium
ms.openlocfilehash: b167f4cc40ee72e6405436bacee28f2f20b4623c
ms.sourcegitcommit: 7a1899358cd5ce9d2f9fa1bd174a123740f98e7a
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 02/01/2019
ms.locfileid: "9042638"
---
# <a name="request-ratings-and-reviews-for-your-app"></a><span data-ttu-id="9bcf1-103">アプリの評価とレビューを求める</span><span class="sxs-lookup"><span data-stu-id="9bcf1-103">Request ratings and reviews for your app</span></span>

<span data-ttu-id="9bcf1-104">ユニバーサル Windows プラットフォーム (UWP) アプリでは、プログラムによってユーザーにアプリの評価やレビューを求めるコードを追加できます。</span><span class="sxs-lookup"><span data-stu-id="9bcf1-104">You can add code to your Universal Windows Platform (UWP) app to programmatically prompt your customers to rate or review your app.</span></span> <span data-ttu-id="9bcf1-105">これを実現する方法にはいくつかあります。</span><span class="sxs-lookup"><span data-stu-id="9bcf1-105">There are several ways you can do this:</span></span>
* <span data-ttu-id="9bcf1-106">アプリのコンテキストで評価とレビュー ダイアログを直接表示する。</span><span class="sxs-lookup"><span data-stu-id="9bcf1-106">You can show a rating and review dialog directly in the context of your app.</span></span>
* <span data-ttu-id="9bcf1-107">Microsoft Store のアプリの評価とレビュー ページをプログラムで開く。</span><span class="sxs-lookup"><span data-stu-id="9bcf1-107">You can programmatically open the rating and review page for your app in the Microsoft Store.</span></span>

<span data-ttu-id="9bcf1-108">評価とレビューのデータを分析する準備ができたら、パートナー センターでデータを表示したり、Microsoft Store 分析 API を使用してプログラムでこのデータを取得できます。</span><span class="sxs-lookup"><span data-stu-id="9bcf1-108">When you are ready to analyze your ratings and reviews data, you can view the data in Partner Center or use the Microsoft Store analytics API to retrieve this data programmatically.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="9bcf1-109">アプリ内で評価関数を追加するには、すべてのレビューは星評価選んだに関係なく、ストアの評価のメカニズムをユーザーに送信する必要があります。</span><span class="sxs-lookup"><span data-stu-id="9bcf1-109">When adding a rating function within your app, all reviews must send the user to the Store's rating mechanisms, regardless of star rating chosen.</span></span> <span data-ttu-id="9bcf1-110">ユーザーからのフィードバックやご意見を収集する場合は、明確なは、アプリの評価やストアでレビューに関連しないが、アプリの開発者に直接送信されることがあります。</span><span class="sxs-lookup"><span data-stu-id="9bcf1-110">If you collect feedback or comments from users, it must be clear that it is not related to the app rating or reviews in the Store but is sent directly to the app developer.</span></span> <span data-ttu-id="9bcf1-111">開発者倫理規定[Fraudulent または悪意を持つアクティビティ](https://docs.microsoft.com/legal/windows/agreements/store-developer-code-of-conduct#3-fraudulent-or-dishonest-activities)に関連する詳細情報を参照してください。</span><span class="sxs-lookup"><span data-stu-id="9bcf1-111">See the Developer Code of Conduct for more information related to [Fraudulent or Dishonest Activities](https://docs.microsoft.com/legal/windows/agreements/store-developer-code-of-conduct#3-fraudulent-or-dishonest-activities).</span></span>

## <a name="show-a-rating-and-review-dialog-in-your-app"></a><span data-ttu-id="9bcf1-112">アプリ内での評価とレビュー ダイアログの表示</span><span class="sxs-lookup"><span data-stu-id="9bcf1-112">Show a rating and review dialog in your app</span></span>

<span data-ttu-id="9bcf1-113">プログラムによって、お客様にアプリの評価とレビューを提出するように求めるアプリからのダイアログを表示するには、 [Windows.Services.Store](https://docs.microsoft.com/uwp/api/windows.services.store)名前空間で、 [RequestRateAndReviewAppAsync](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.requestrateandreviewappasync)メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="9bcf1-113">To programmatically show a dialog from your app that asks your customer to rate your app and submit a review, call the [RequestRateAndReviewAppAsync](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.requestrateandreviewappasync) method in the [Windows.Services.Store](https://docs.microsoft.com/uwp/api/windows.services.store) namespace.</span></span> 

> [!IMPORTANT]
> <span data-ttu-id="9bcf1-114">評価とレビュー ダイアログを表示する要求は、アプリの UI スレッドで呼び出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="9bcf1-114">The request to show the rating and review dialog must be called on the UI thread in your app.</span></span>

```csharp
using Windows.ApplicationModel.Store;

private StoreContext _storeContext;

public async Task Initialize()
{
    if (App.IsMultiUserApp) // pseudo-code
    {
        IReadOnlyList<User> users = await User.FindAllAsync();
        User firstUser = users[0];
        _storeContext = StoreContext.GetForUser(firstUser);
    }
    else
    {
        _storeContext = StoreContext.GetDefault();
    }
}

private async Task PromptUserToRateApp()
{
    // Check if we’ve recently prompted user to review, we don’t want to bother user too often and only between version changes
    if (HaveWePromptedUserInPastThreeMonths())  // pseudo-code
    {
        return;
    }

    StoreRateAndReviewResult result = await 
        _storeContext.RequestRateAndReviewAppAsync();

    // Check status
    switch (result.Status)
    { 
        case StoreRateAndReviewStatus.Succeeded:
            // Was this an updated review or a new review, if Updated is false it means it was a users first time reviewing
            if (result.UpdatedExistingRatingOrReview)
            {
                // This was an updated review thank user
                ThankUserForReview(); // pseudo-code
            }
            else
            {
                // This was a new review, thank user for reviewing and give some free in app tokens
                ThankUserForReviewAndGrantTokens(); // pseudo-code
            }
            // Keep track that we prompted user and don’t do it again for a while
            SetUserHasBeenPrompted(); // pseudo-code
            break;

        case StoreRateAndReviewStatus.CanceledByUser:
            // Keep track that we prompted user and don’t prompt again for a while
            SetUserHasBeenPrompted(); // pseudo-code

            break;

        case StoreRateAndReviewStatus.NetworkError:
            // User is probably not connected, so we’ll try again, but keep track so we don’t try too often
            SetUserHasBeenPromptedButHadNetworkError(); // pseudo-code

            break;

        // Something else went wrong
        case StoreRateAndReviewStatus.OtherError:
        default:
            // Log error, passing in ExtendedJsonData however it will be empty for now
            LogError(result.ExtendedError, result.ExtendedJsonData); // pseudo-code
            break;
    }
}
```

<span data-ttu-id="9bcf1-115">**RequestRateAndReviewAppAsync**メソッドは、Windows 10 version 1809 で導入され、 **Windows 10 October 2018 をターゲットとするプロジェクトでのみ使用できます (10.0、更新プログラムビルド 17763)** Visual Studio で以降のリリースです。</span><span class="sxs-lookup"><span data-stu-id="9bcf1-115">The **RequestRateAndReviewAppAsync** method was introduced in Windows 10, version 1809, and it can only be used in projects that target **Windows 10 October 2018 Update (10.0; Build 17763)** or a later release in Visual Studio.</span></span>

### <a name="response-data-for-the-rating-and-review-request"></a><span data-ttu-id="9bcf1-116">評価とレビューの要求に対する応答データ</span><span class="sxs-lookup"><span data-stu-id="9bcf1-116">Response data for the rating and review request</span></span>

<span data-ttu-id="9bcf1-117">表示の評価とレビュー ダイアログに要求を送信した後、 [StoreRateAndReviewResult](https://docs.microsoft.com/uwp/api/windows.services.store.storerateandreviewresult)クラスの[ExtendedJsonData](https://docs.microsoft.com/uwp/api/windows.services.store.storerateandreviewresult.extendedjsondata)プロパティには、要求が成功したかどうかを示す JSON 形式の文字列が含まれています。</span><span class="sxs-lookup"><span data-stu-id="9bcf1-117">After you submit the request to display the rating and review dialog, the [ExtendedJsonData](https://docs.microsoft.com/uwp/api/windows.services.store.storerateandreviewresult.extendedjsondata) property of the [StoreRateAndReviewResult](https://docs.microsoft.com/uwp/api/windows.services.store.storerateandreviewresult) class contains a JSON-formatted string that indicates whether the request was successful.</span></span>

<span data-ttu-id="9bcf1-118">次の例は、ユーザーが評価またはレビューを正しく提出した後のこの要求の戻り値を示しています。</span><span class="sxs-lookup"><span data-stu-id="9bcf1-118">The following example demonstrates the return value for this request after the customer successfully submits a rating or review.</span></span>

```json
{ 
  "status": "success", 
  "data": {
    "updated": false
  },
  "errorDetails": "Success"
}
```

<span data-ttu-id="9bcf1-119">次の例は、ユーザーが評価またはレビューを提出しなかった後のこの要求の戻り値を示しています。</span><span class="sxs-lookup"><span data-stu-id="9bcf1-119">The following example demonstrates the return value for this request after the customer chooses not to submit a rating or review.</span></span>

```json
{ 
  "status": "aborted", 
  "errorDetails": "Navigation was unsuccessful"
}
```

<span data-ttu-id="9bcf1-120">次の表では、JSON 形式のデータ文字列に含まれるフィールドについて説明します。</span><span class="sxs-lookup"><span data-stu-id="9bcf1-120">The following table describes the fields in the JSON-formatted data string.</span></span>

| <span data-ttu-id="9bcf1-121">フィールド</span><span class="sxs-lookup"><span data-stu-id="9bcf1-121">Field</span></span>          | <span data-ttu-id="9bcf1-122">説明</span><span class="sxs-lookup"><span data-stu-id="9bcf1-122">Description</span></span>                                                                                                                                   |
|----------------|-----------------------------------------------------------------------------------------------------------------------------------------------|
| *<span data-ttu-id="9bcf1-123">status</span><span class="sxs-lookup"><span data-stu-id="9bcf1-123">status</span></span>*       | <span data-ttu-id="9bcf1-124">ユーザーから評価またはレビューが正しく提出されたかどうかを示す文字列です。</span><span class="sxs-lookup"><span data-stu-id="9bcf1-124">A string that indicates whether the customer successfully submitted a rating or review.</span></span> <span data-ttu-id="9bcf1-125">サポートされる値は **success** と **aborted** です。</span><span class="sxs-lookup"><span data-stu-id="9bcf1-125">The supported values are **success** and **aborted**.</span></span> |
| *<span data-ttu-id="9bcf1-126">data</span><span class="sxs-lookup"><span data-stu-id="9bcf1-126">data</span></span>*         | <span data-ttu-id="9bcf1-127">*updated* という名前の単一のブール値を含むオブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="9bcf1-127">An object that contains a single Boolean value named *updated*.</span></span> <span data-ttu-id="9bcf1-128">この値は、ユーザーが既存の評価またはレビューを更新したかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="9bcf1-128">This value indicates whether the customer updated an existing rating or review.</span></span> <span data-ttu-id="9bcf1-129">*data* オブジェクトは、成功の応答にのみ含まれます。</span><span class="sxs-lookup"><span data-stu-id="9bcf1-129">The *data* object is included in success responses only.</span></span> |
| *<span data-ttu-id="9bcf1-130">errorDetails</span><span class="sxs-lookup"><span data-stu-id="9bcf1-130">errorDetails</span></span>* | <span data-ttu-id="9bcf1-131">要求のエラーの詳細を含む文字列です。</span><span class="sxs-lookup"><span data-stu-id="9bcf1-131">A string that contains the error details for the request.</span></span>                                                                                     |

## <a name="launch-the-rating-and-review-page-for-your-app-in-the-store"></a><span data-ttu-id="9bcf1-132">Store でのアプリの評価とレビュー ページの起動</span><span class="sxs-lookup"><span data-stu-id="9bcf1-132">Launch the rating and review page for your app in the Store</span></span>

<span data-ttu-id="9bcf1-133">Store のアプリの評価とレビュー ページをプログラムによって開くには、次のコード例に示すように、```ms-windows-store://review``` URI スキームを指定して [LaunchUriAsync](https://docs.microsoft.com/uwp/api/windows.system.launcher.launchuriasync) メソッドを使用します。</span><span class="sxs-lookup"><span data-stu-id="9bcf1-133">If you want to programmatically open the rating and review page for your app in the Store, you can use the [LaunchUriAsync](https://docs.microsoft.com/uwp/api/windows.system.launcher.launchuriasync) method with the ```ms-windows-store://review``` URI scheme as demonstrated in this code example.</span></span>

```csharp
bool result = await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-windows-store://review/?ProductId=9WZDNCRFHVJL"));
```

<span data-ttu-id="9bcf1-134">詳しくは、「[Microsoft Store アプリの起動](../launch-resume/launch-store-app.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="9bcf1-134">For more information, see [Launch the Microsoft Store app](../launch-resume/launch-store-app.md).</span></span>

## <a name="analyze-your-ratings-and-reviews-data"></a><span data-ttu-id="9bcf1-135">評価とレビュー データの分析</span><span class="sxs-lookup"><span data-stu-id="9bcf1-135">Analyze your ratings and reviews data</span></span>

<span data-ttu-id="9bcf1-136">ユーザーから提出された評価とレビューのデータを分析するには、いくつかの方法があります。</span><span class="sxs-lookup"><span data-stu-id="9bcf1-136">To analyze the ratings and reviews data from your customers, you have several options:</span></span>
* <span data-ttu-id="9bcf1-137">パートナー センターで[レビュー](../publish/reviews-report.md)レポートを使用すると、顧客から評価とレビューを参照してください。</span><span class="sxs-lookup"><span data-stu-id="9bcf1-137">You can use the [Reviews](../publish/reviews-report.md) report in Partner Center to see the ratings and reviews from your customers.</span></span> <span data-ttu-id="9bcf1-138">このレポートは、ダウンロードしてオフラインで参照することもできます。</span><span class="sxs-lookup"><span data-stu-id="9bcf1-138">You can also download this report to view it offline.</span></span>
* <span data-ttu-id="9bcf1-139">Microsoft Store 分析 API の[アプリの評価の取得](get-app-ratings.md)メソッドと[アプリのレビューの取得](get-app-reviews.md)メソッドを使って、ユーザーから提出された評価とレビューをプログラムによって JSON 形式で取得できます。</span><span class="sxs-lookup"><span data-stu-id="9bcf1-139">You can use the [Get app ratings](get-app-ratings.md) and [Get app reviews](get-app-reviews.md) methods in the Store analytics API to programmatically retrieve the ratings and reviews from your customers in JSON format.</span></span>

## <a name="related-topics"></a><span data-ttu-id="9bcf1-140">関連トピック</span><span class="sxs-lookup"><span data-stu-id="9bcf1-140">Related topics</span></span>

* [<span data-ttu-id="9bcf1-141">Store に要求を送信する</span><span class="sxs-lookup"><span data-stu-id="9bcf1-141">Send requests to the Store</span></span>](send-requests-to-the-store.md)
* [<span data-ttu-id="9bcf1-142">Microsoft Store アプリの起動</span><span class="sxs-lookup"><span data-stu-id="9bcf1-142">Launch the Microsoft Store app</span></span>](../launch-resume/launch-store-app.md)
* [<span data-ttu-id="9bcf1-143">[レビュー] レポート</span><span class="sxs-lookup"><span data-stu-id="9bcf1-143">Reviews report</span></span>](../publish/reviews-report.md)
