---
Description: You can use the SendRequestAsync method to send requests to the Microsoft Store for operations that do not yet have an API available in the Windows SDK.
title: Microsoft Store に要求を送信する
ms.assetid: 070B9CA4-6D70-4116-9B18-FBF246716EF0
ms.date: 03/22/2018
ms.topic: article
keywords: Windows 10, UWP, StoreRequestHelper, SendRequestAsync
ms.localizationpriority: medium
ms.openlocfilehash: d492bc7dde990404552689516731850974c31a7c
ms.sourcegitcommit: b4c502d69a13340f6e3c887aa3c26ef2aeee9cee
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/03/2018
ms.locfileid: "8468101"
---
# <a name="send-requests-to-the-microsoft-store"></a>Microsoft Store に要求を送信する

Windows 10 Version 1607 以降、Windows SDK の [Windows.Services.Store](https://docs.microsoft.com/uwp/api/windows.services.store) 名前空間には、Store に関連する操作 (アプリ内購入など) のための API が用意されています。 ただし、ストアをサポートするサービスは OS がリリースされるたびに継続的に更新、拡張、強化されていますが、新しい API は通常 OS のメジャー リリース時にのみ Windows SDK に追加されます。

[SendRequestAsync](https://docs.microsoft.com/uwp/api/windows.services.store.storerequesthelper.sendrequestasync) メソッドは、新しいバージョンの Windows SDK がリリースされる前にユニバーサル Windows プラットフォーム (UWP) アプリで新しいストアの操作を利用できるようにする柔軟な方法として用意されています。 このメソッドを使うと、最新リリースの Windows SDK に対応する API がまだない新しい操作の要求をストアに送信することができます。

> [!NOTE]
> **SendRequestAsync** メソッドは、Windows 10 バージョン 1607 以降をターゲットとするアプリにのみ使うことができます。 このメソッドでサポートされている要求の一部は、Windows 10 バージョン 1607 より後のリリースでのみサポートされます。

**SendRequestAsync** は、[StoreRequestHelper](https://docs.microsoft.com/uwp/api/windows.services.store.storerequesthelper) クラスの静的メソッドです。 このメソッドを呼び出すには、次の情報をメソッドに渡す必要があります。
* 操作を実行するユーザーに関する情報を提供する [StoreContext](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext) オブジェクト。 このオブジェクトについて詳しくは、「[StoreContext クラスの概要](in-app-purchases-and-trials.md#get-started-with-the-storecontext-class)」をご覧ください。
* ストアに送信する要求を識別する整数。
* 要求が任意の引数をサポートする場合、要求と共に渡す引数を含む JSON 形式の文字列も渡すことができます。

次の例は、このメソッドを呼び出す方法を示しています。 この例では、**Windows.Services.Store** 名前空間と **System.Threading.Tasks** 名前空間のステートメントを使う必要があります。

```csharp
public async Task<bool> AddUserToFlightGroup()
{
    StoreSendRequestResult result = await StoreRequestHelper.SendRequestAsync(
        StoreContext.GetDefault(), 8,
        "{ \"type\": \"AddToFlightGroup\", \"parameters\": \"{ \"flightGroupId\": \"your group ID\" }\" }");

    if (result.ExtendedError == null)
    {
        return true;
    }

    return false;
}
```

**SendRequestAsync** メソッドで現在利用可能な要求については、以下のセクションをご覧ください。 この記事は、新しい要求のサポートが追加されると更新されます。

## <a name="request-for-in-app-ratings-and-reviews"></a>アプリ内での評価とレビューの要求

**SendRequestAsync** メソッドに要求の整数として 16 を渡すと、アプリを評価してレビューを提出するようにユーザーに求めるダイアログを、アプリ内からプログラムによって起動することができます。 詳しくは、「[アプリ内での評価とレビュー ダイアログの表示](request-ratings-and-reviews.md#show-a-rating-and-review-dialog-in-your-app)」をご覧ください。

## <a name="requests-for-flight-group-scenarios"></a>フライト グループ シナリオの要求

> [!IMPORTANT]
> 現在のところ、このセクションで説明されているフライト グループ要求はすべて、ほとんどの開発者アカウントで使用できません。 開発者用アカウントが Microsoft によって特にプロビジョニングされない限り、これらの要求は失敗します。

**SendRequestAsync** メソッドは、フライト グループへのユーザーまたはデバイスの追加など、フライト グループ シナリオの一連の要求をサポートしています。 これらの要求を提出するには、値 7 または 8 を *requestKind* パラメーターに渡すと同時に、関連する引数と共に提出する要求を示す *parametersAsJson* パラメーターに JSON 形式文字列を渡します。 これらの *requestKind* 値は、次の点で異なります。

|  要求の種類を表す値  |  説明  |
|----------------------|---------------|
|  7                   |  要求は、現在のデバイスのコンテキストで実行されます。 この値は、Windows 10 バージョン 1703 以降でのみ使用できます。  |
|  8                   |  要求は、ストアに現在サインインしているユーザーのコンテキストで実行されます。 この値は、Windows 10 バージョン 1607 以降で使用できます。  |

現在のところ、次のフライト グループ要求が実装されています。

### <a name="retrieve-remote-variables-for-the-highest-ranked-flight-group"></a>最も順位の高いフライト グループのリモート変数を取得する

> [!IMPORTANT]
> この要求は、現在のところほとんどの開発者アカウントで使用できません。 開発者用アカウントが Microsoft によって特にプロビジョニングされない限り、この要求は失敗します。

この要求は、現在のユーザーまたはデバイスの最も順位の高いフライト グループのリモート変数を取得します。 この要求を送信するには、次の情報を **SendRequestAsync** メソッドの *requestKind* パラメーターと *parametersAsJson* パラメーターに渡します。

|  パラメーター  |  説明  |
|----------------------|---------------|
|  *requestKind*                   |  デバイスの最も順位の高いフライト グループを返すには 7 を指定し、現在のユーザーとデバイスの最も順位の高いフライト グループを返すには 8 を指定します。 *requestKind* パラメーターには値 8 を使うことをお勧めします。この値は、現在のユーザーおよびデバイスの両方のメンバーシップにおいて最も順位の高いフライト グループを返すためです。  |
|  *parametersAsJson*                   |  次の例に示すように、データを含む JSON 形式の文字列を渡します。  |

次の例は、JSON 形式のデータを *parametersAsJson* に渡す方法を示しています。 *type* フィールドは、文字列 *GetRemoteVariables* に割り当てる必要があります。 パートナー センターでリモート変数を定義したプロジェクトの ID を*projectId*フィールドを割り当てます。

```json
{ 
    "type": "GetRemoteVariables", 
    "parameters": "{ \"projectId\": \"your project ID\" }" 
}
```

この要求を提出すると、[StoreSendRequestResult](https://docs.microsoft.com/uwp/api/windows.services.store.storesendrequestresult) の戻り値の [Response](https://docs.microsoft.com/uwp/api/windows.services.store.storesendrequestresult.Response) プロパティには、次のフィールドを持つ JSON 形式の文字列が含められます。

|  フィールド  |  説明  |
|----------------------|---------------|
|  *anonymous*                   |  ブール値。**true** はユーザーまたはデバイス ID が要求に存在していなかったことを示し、**false** はユーザーまたはデバイス ID が要求に存在していたことを示します。  |
|  *name*                   |  デバイスまたはユーザーが所属する最も順位の高いフライト グループの名前を含む文字列です。  |
|  *settings*                   |  開発者がフライト グループに構成したリモート変数の名前を値を含むキー/値ペアのディクショナリです。  |

次の例では、この要求の戻り値を示します。

```json
{ 
  "anonymous": false, 
  "name": "Insider Slow",
  "settings":
  {
      "Audience": "Slow"
      ...
  }
}
```

### <a name="add-the-current-device-or-user-to-a-flight-group"></a>フライト グループに現在のデバイスまたはユーザーを追加する

> [!IMPORTANT]
> この要求は、現在のところほとんどの開発者アカウントで使用できません。 開発者用アカウントが Microsoft によって特にプロビジョニングされない限り、この要求は失敗します。

この要求を送信するには、次の情報を **SendRequestAsync** メソッドの *requestKind* パラメーターと *parametersAsJson* パラメーターに渡します。

|  パラメーター  |  説明  |
|----------------------|---------------|
|  *requestKind*                   |  デバイスをフライト グループに追加するには 7 を指定し、現在ストアにサインインしているユーザーをフライト グループに追加するには 8 を指定します。  |
|  *parametersAsJson*                   |  次の例に示すように、データを含む JSON 形式の文字列を渡します。  |

次の例は、JSON 形式のデータを *parametersAsJson* に渡す方法を示しています。 *type* フィールドは、文字列 *AddToFlightGroup* に割り当てる必要があります。 *flightGroupId* フィールドを、デバイスまたはユーザーを追加するフライト グループの ID に割り当てます。

```json
{ 
    "type": "AddToFlightGroup", 
    "parameters": "{ \"flightGroupId\": \"your group ID\" }" 
}
```

要求でエラーが発生した場合、[StoreSendRequestResult](https://docs.microsoft.com/uwp/api/windows.services.store.storesendrequestresult) の戻り値の [HttpStatusCode](https://docs.microsoft.com/uwp/api/windows.services.store.storesendrequestresult.HttpStatusCode) プロパティには応答コードが含められます。

### <a name="remove-the-current-device-or-user-from-a-flight-group"></a>フライト グループから現在のデバイスまたはユーザーを削除する

> [!IMPORTANT]
> この要求は、現在のところほとんどの開発者アカウントで使用できません。 開発者用アカウントが Microsoft によって特にプロビジョニングされない限り、この要求は失敗します。

この要求を送信するには、次の情報を **SendRequestAsync** メソッドの *requestKind* パラメーターと *parametersAsJson* パラメーターに渡します。

|  パラメーター  |  説明  |
|----------------------|---------------|
|  *requestKind*                   |  デバイスをフライト グループから削除するには 7 を指定し、現在ストアにサインインしているユーザーをフライト グループから削除するには 8 を指定します。  |
|  *parametersAsJson*                   |  次の例に示すように、データを含む JSON 形式の文字列を渡します。  |

次の例は、JSON 形式のデータを *parametersAsJson* に渡す方法を示しています。 *type* フィールドは、文字列 *RemoveFromFlightGroup* に割り当てる必要があります。 *flightGroupId* フィールドを、デバイスまたはユーザーを削除するフライト グループの ID に割り当てます。

```json
{ 
    "type": "RemoveFromFlightGroup", 
    "parameters": "{ \"flightGroupId\": \"your group ID\" }" 
}
```

要求でエラーが発生した場合、[StoreSendRequestResult](https://docs.microsoft.com/uwp/api/windows.services.store.storesendrequestresult) の戻り値の [HttpStatusCode](https://docs.microsoft.com/uwp/api/windows.services.store.storesendrequestresult.HttpStatusCode) プロパティには応答コードが含められます。

## <a name="related-topics"></a>関連トピック

* [アプリ内での評価とレビュー ダイアログの表示](request-ratings-and-reviews.md#show-a-rating-and-review-dialog-in-your-app)
* [SendRequestAsync](https://docs.microsoft.com/uwp/api/windows.services.store.storerequesthelper.sendrequestasync)
