---
author: Xansky
Description: Learn about several ways you can programmatically enable customers to rate and review your app.
title: アプリの評価とレビューを求める
ms.author: mhopkins
ms.date: 06/15/2018
ms.topic: article
keywords: Windows 10, UWP, 評価, レビュー
ms.localizationpriority: medium
ms.openlocfilehash: c00e69ed7d5057db4f835f3d91320806067d86e1
ms.sourcegitcommit: 144f5f127fc4fbd852f2f6780ef26054192d68fc
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/02/2018
ms.locfileid: "5981191"
---
# <a name="request-ratings-and-reviews-for-your-app"></a>アプリの評価とレビューを求める

ユニバーサル Windows プラットフォーム (UWP) アプリでは、プログラムによってユーザーにアプリの評価やレビューを求めるコードを追加できます。 これを実現する方法にはいくつかあります。
* アプリのコンテキストで評価とレビュー ダイアログを直接表示する。
* Microsoft Store のアプリの評価とレビュー ページをプログラムで開く。

評価とレビューのデータを分析する準備ができたら、パートナー センターでデータを表示したり、Microsoft Store 分析 API を使用してプログラムでこのデータを取得できます。

> [!IMPORTANT]
> アプリ内で評価関数を追加するには、すべてのレビューは星評価選んだに関係なく、ストアの評価のメカニズムをユーザーに送信する必要があります。 ユーザーからのフィードバックやご意見を収集する場合は、明確なは、アプリの評価やストアでのレビューに関連しないが、アプリ開発者に直接送信されることがあります。 開発者倫理規定[Fraudulent または悪意を持つアクティビティ](https://docs.microsoft.com/legal/windows/agreements/store-developer-code-of-conduct#3-fraudulent-or-dishonest-activities)に関連する詳細情報を参照してください。

## <a name="show-a-rating-and-review-dialog-in-your-app"></a>アプリ内での評価とレビュー ダイアログの表示

アプリを評価してレビューを提出するようにユーザーに求めるダイアログを、アプリ内からプログラムによって表示するには、[Windows.Services.Store](https://docs.microsoft.com/uwp/api/windows.services.store) 名前空間の [SendRequestAsync](https://docs.microsoft.com/uwp/api/windows.services.store.storerequesthelper.sendrequestasync) メソッドを呼び出します。 以下のコード例に示すように、*requestKind* パラメーターには整数 16 を渡し、*parametersAsJson* パラメーターには空の文字列を渡します。 この例では、Newtonsoft の [Json.NET](http://www.newtonsoft.com/json) ライブラリと、**Windows.Services.Store**、**System.Threading.Tasks**、**Newtonsoft.Json.Linq** の各名前空間に対する using ステートメントが必要です。

> [!IMPORTANT]
> 評価とレビュー ダイアログを表示する要求は、アプリの UI スレッドで呼び出す必要があります。

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

**SendRequestAsync** メソッドは、シンプルな整数ベースの要求システムと JSON ベースのデータ パラメーターを使って、さまざまな Store 操作をアプリに公開します。 *requestKind* パラメーターに整数 16 を渡すと、評価とレビュー ダイアログを表示する要求を発行したことになり、関連するデータが Store に送信されます。 このメソッドは Windows 10 Version 1607 で導入され、Visual Studio で **Windows 10 Anniversary Edition (10.0、ビルド 14393)** 以降のリリースをターゲットとするプロジェクトでのみ使用できます。 このメソッドの一般的な概要については、「[Store に要求を送信する](send-requests-to-the-store.md)」をご覧ください。

### <a name="response-data-for-the-rating-and-review-request"></a>評価とレビューの要求に対する応答データ

評価とレビュー ダイアログを表示する要求を送信すると、[StoreSendRequestResult](https://docs.microsoft.com/uwp/api/windows.services.store.storesendrequestresult) の戻り値の [Response](https://docs.microsoft.com/uwp/api/windows.services.store.storesendrequestresult.Response) プロパティに、要求が成功したかどうかを示す JSON 形式の文字列が含められます。

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

|  フィールド  |  説明  |
|----------------------|---------------|
|  *status*                   |  ユーザーから評価またはレビューが正しく提出されたかどうかを示す文字列です。 サポートされる値は **success** と **aborted** です。   |
|  *data*                   |  *updated* という名前の単一のブール値を含むオブジェクトです。 この値は、ユーザーが既存の評価またはレビューを更新したかどうかを示します。 *data* オブジェクトは、成功の応答にのみ含まれます。   |
|  *errorDetails*                   |  要求のエラーの詳細を含む文字列です。 |

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
