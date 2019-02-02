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
# <a name="request-ratings-and-reviews-for-your-app"></a>アプリの評価とレビューを求める

ユニバーサル Windows プラットフォーム (UWP) アプリでは、プログラムによってユーザーにアプリの評価やレビューを求めるコードを追加できます。 これを実現する方法にはいくつかあります。
* アプリのコンテキストで評価とレビュー ダイアログを直接表示する。
* Microsoft Store のアプリの評価とレビュー ページをプログラムで開く。

評価とレビューのデータを分析する準備ができたら、パートナー センターでデータを表示したり、Microsoft Store 分析 API を使用してプログラムでこのデータを取得できます。

> [!IMPORTANT]
> アプリ内で評価関数を追加するには、すべてのレビューは星評価選んだに関係なく、ストアの評価のメカニズムをユーザーに送信する必要があります。 ユーザーからのフィードバックやご意見を収集する場合は、明確なは、アプリの評価やストアでレビューに関連しないが、アプリの開発者に直接送信されることがあります。 開発者倫理規定[Fraudulent または悪意を持つアクティビティ](https://docs.microsoft.com/legal/windows/agreements/store-developer-code-of-conduct#3-fraudulent-or-dishonest-activities)に関連する詳細情報を参照してください。

## <a name="show-a-rating-and-review-dialog-in-your-app"></a>アプリ内での評価とレビュー ダイアログの表示

プログラムによって、お客様にアプリの評価とレビューを提出するように求めるアプリからのダイアログを表示するには、 [Windows.Services.Store](https://docs.microsoft.com/uwp/api/windows.services.store)名前空間で、 [RequestRateAndReviewAppAsync](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.requestrateandreviewappasync)メソッドを呼び出します。 

> [!IMPORTANT]
> 評価とレビュー ダイアログを表示する要求は、アプリの UI スレッドで呼び出す必要があります。

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

**RequestRateAndReviewAppAsync**メソッドは、Windows 10 version 1809 で導入され、 **Windows 10 October 2018 をターゲットとするプロジェクトでのみ使用できます (10.0、更新プログラムビルド 17763)** Visual Studio で以降のリリースです。

### <a name="response-data-for-the-rating-and-review-request"></a>評価とレビューの要求に対する応答データ

表示の評価とレビュー ダイアログに要求を送信した後、 [StoreRateAndReviewResult](https://docs.microsoft.com/uwp/api/windows.services.store.storerateandreviewresult)クラスの[ExtendedJsonData](https://docs.microsoft.com/uwp/api/windows.services.store.storerateandreviewresult.extendedjsondata)プロパティには、要求が成功したかどうかを示す JSON 形式の文字列が含まれています。

次の例は、ユーザーが評価またはレビューを正しく提出した後のこの要求の戻り値を示しています。

```json
{ 
  "status": "success", 
  "data": {
    "updated": false
  },
  "errorDetails": "Success"
}
```

次の例は、ユーザーが評価またはレビューを提出しなかった後のこの要求の戻り値を示しています。

```json
{ 
  "status": "aborted", 
  "errorDetails": "Navigation was unsuccessful"
}
```

次の表では、JSON 形式のデータ文字列に含まれるフィールドについて説明します。

| フィールド          | 説明                                                                                                                                   |
|----------------|-----------------------------------------------------------------------------------------------------------------------------------------------|
| *status*       | ユーザーから評価またはレビューが正しく提出されたかどうかを示す文字列です。 サポートされる値は **success** と **aborted** です。 |
| *data*         | *updated* という名前の単一のブール値を含むオブジェクトです。 この値は、ユーザーが既存の評価またはレビューを更新したかどうかを示します。 *data* オブジェクトは、成功の応答にのみ含まれます。 |
| *errorDetails* | 要求のエラーの詳細を含む文字列です。                                                                                     |

## <a name="launch-the-rating-and-review-page-for-your-app-in-the-store"></a>Store でのアプリの評価とレビュー ページの起動

Store のアプリの評価とレビュー ページをプログラムによって開くには、次のコード例に示すように、```ms-windows-store://review``` URI スキームを指定して [LaunchUriAsync](https://docs.microsoft.com/uwp/api/windows.system.launcher.launchuriasync) メソッドを使用します。

```csharp
bool result = await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-windows-store://review/?ProductId=9WZDNCRFHVJL"));
```

詳しくは、「[Microsoft Store アプリの起動](../launch-resume/launch-store-app.md)」をご覧ください。

## <a name="analyze-your-ratings-and-reviews-data"></a>評価とレビュー データの分析

ユーザーから提出された評価とレビューのデータを分析するには、いくつかの方法があります。
* パートナー センターで[レビュー](../publish/reviews-report.md)レポートを使用すると、顧客から評価とレビューを参照してください。 このレポートは、ダウンロードしてオフラインで参照することもできます。
* Microsoft Store 分析 API の[アプリの評価の取得](get-app-ratings.md)メソッドと[アプリのレビューの取得](get-app-reviews.md)メソッドを使って、ユーザーから提出された評価とレビューをプログラムによって JSON 形式で取得できます。

## <a name="related-topics"></a>関連トピック

* [Store に要求を送信する](send-requests-to-the-store.md)
* [Microsoft Store アプリの起動](../launch-resume/launch-store-app.md)
* [[レビュー] レポート](../publish/reviews-report.md)
