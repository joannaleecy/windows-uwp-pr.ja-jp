---
Description: SendRequestAsync メソッドを使用すると、Windows SDK で利用できる API がまだない操作のための Microsoft Store に要求を送信します。
title: Microsoft Store に要求を送信する
ms.assetid: 070B9CA4-6D70-4116-9B18-FBF246716EF0
ms.date: 03/22/2018
ms.topic: article
keywords: Windows 10, UWP, StoreRequestHelper, SendRequestAsync
ms.localizationpriority: medium
ms.openlocfilehash: d492bc7dde990404552689516731850974c31a7c
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57589797"
---
# <a name="send-requests-to-the-microsoft-store"></a><span data-ttu-id="f429f-104">Microsoft Store に要求を送信する</span><span class="sxs-lookup"><span data-stu-id="f429f-104">Send requests to the Microsoft Store</span></span>

<span data-ttu-id="f429f-105">Windows 10 バージョン 1607 以降、Windows SDK の [Windows.Services.Store](https://docs.microsoft.com/uwp/api/windows.services.store) 名前空間にはストアに関連する操作 (アプリ内購入など) の API が用意されています。</span><span class="sxs-lookup"><span data-stu-id="f429f-105">Starting in Windows 10, version 1607, the Windows SDK provides APIs for Store-related operations (such as in-app purchases) in the [Windows.Services.Store](https://docs.microsoft.com/uwp/api/windows.services.store) namespace.</span></span> <span data-ttu-id="f429f-106">ただし、ストアをサポートするサービスは OS がリリースされるたびに継続的に更新、拡張、強化されていますが、新しい API は通常 OS のメジャー リリース時にのみ Windows SDK に追加されます。</span><span class="sxs-lookup"><span data-stu-id="f429f-106">However, although the services that support the Store are constantly being updated, expanded, and improved between OS releases, new APIs are typically added to the Windows SDK only during major OS releases.</span></span>

<span data-ttu-id="f429f-107">[SendRequestAsync](https://docs.microsoft.com/uwp/api/windows.services.store.storerequesthelper.sendrequestasync) メソッドは、新しいバージョンの Windows SDK がリリースされる前にユニバーサル Windows プラットフォーム (UWP) アプリで新しいストアの操作を利用できるようにする柔軟な方法として用意されています。</span><span class="sxs-lookup"><span data-stu-id="f429f-107">We provide the [SendRequestAsync](https://docs.microsoft.com/uwp/api/windows.services.store.storerequesthelper.sendrequestasync) method as a flexible way to make new Store operations available to Universal Windows Platform (UWP) apps before a new version of the Windows SDK is released.</span></span> <span data-ttu-id="f429f-108">このメソッドを使うと、最新リリースの Windows SDK に対応する API がまだない新しい操作の要求をストアに送信することができます。</span><span class="sxs-lookup"><span data-stu-id="f429f-108">You can use this method to send requests to the Store for new operations that do not yet have a corresponding API available in the latest release of the Windows SDK.</span></span>

> [!NOTE]
> <span data-ttu-id="f429f-109">**SendRequestAsync** メソッドは、Windows 10 バージョン 1607 以降をターゲットとするアプリにのみ使うことができます。</span><span class="sxs-lookup"><span data-stu-id="f429f-109">The **SendRequestAsync** method is available only to apps that target Windows 10, version 1607, or later.</span></span> <span data-ttu-id="f429f-110">このメソッドでサポートされている要求の一部は、Windows 10 バージョン 1607 より後のリリースでのみサポートされます。</span><span class="sxs-lookup"><span data-stu-id="f429f-110">Some of the requests supported by this method are only supported in releases after Windows 10, version 1607.</span></span>

<span data-ttu-id="f429f-111">**SendRequestAsync** は、[StoreRequestHelper](https://docs.microsoft.com/uwp/api/windows.services.store.storerequesthelper) クラスの静的メソッドです。</span><span class="sxs-lookup"><span data-stu-id="f429f-111">**SendRequestAsync** is a static method of the [StoreRequestHelper](https://docs.microsoft.com/uwp/api/windows.services.store.storerequesthelper) class.</span></span> <span data-ttu-id="f429f-112">このメソッドを呼び出すには、次の情報をメソッドに渡す必要があります。</span><span class="sxs-lookup"><span data-stu-id="f429f-112">To call this method, you must pass the following information to the method:</span></span>
* <span data-ttu-id="f429f-113">操作を実行するユーザーに関する情報を提供する [StoreContext](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext) オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="f429f-113">A [StoreContext](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext) object that provides information about the user for which you want to perform the operation.</span></span> <span data-ttu-id="f429f-114">このオブジェクトについて詳しくは、「[StoreContext クラスの概要](in-app-purchases-and-trials.md#get-started-with-the-storecontext-class)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f429f-114">For more information about this object, see [Get started with the StoreContext class](in-app-purchases-and-trials.md#get-started-with-the-storecontext-class).</span></span>
* <span data-ttu-id="f429f-115">ストアに送信する要求を識別する整数。</span><span class="sxs-lookup"><span data-stu-id="f429f-115">An integer that identifies the request that you want to send to the Store.</span></span>
* <span data-ttu-id="f429f-116">要求が任意の引数をサポートする場合、要求と共に渡す引数を含む JSON 形式の文字列も渡すことができます。</span><span class="sxs-lookup"><span data-stu-id="f429f-116">If the request supports any arguments, you can also pass a JSON-formatted string that contains the arguments to pass along with the request.</span></span>

<span data-ttu-id="f429f-117">次の例は、このメソッドを呼び出す方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="f429f-117">The following example demonstrates how to call this method.</span></span> <span data-ttu-id="f429f-118">この例では、**Windows.Services.Store** 名前空間と **System.Threading.Tasks** 名前空間のステートメントを使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="f429f-118">This example requires using statements for the **Windows.Services.Store** and **System.Threading.Tasks** namespaces.</span></span>

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

<span data-ttu-id="f429f-119">**SendRequestAsync** メソッドで現在利用可能な要求については、以下のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f429f-119">See the following sections for information about the requests that are currently available via the **SendRequestAsync** method.</span></span> <span data-ttu-id="f429f-120">この記事は、新しい要求のサポートが追加されると更新されます。</span><span class="sxs-lookup"><span data-stu-id="f429f-120">We will update this article when support for new requests are added.</span></span>

## <a name="request-for-in-app-ratings-and-reviews"></a><span data-ttu-id="f429f-121">アプリ内での評価とレビューの要求</span><span class="sxs-lookup"><span data-stu-id="f429f-121">Request for in-app ratings and reviews</span></span>

<span data-ttu-id="f429f-122">**SendRequestAsync** メソッドに要求の整数として 16 を渡すと、アプリを評価してレビューを提出するようにユーザーに求めるダイアログを、アプリ内からプログラムによって起動することができます。</span><span class="sxs-lookup"><span data-stu-id="f429f-122">You can programmatically launch a dialog from your app that asks your customer to rate your app and submit a review by passing the request integer 16 to the **SendRequestAsync** method.</span></span> <span data-ttu-id="f429f-123">詳しくは、「[アプリ内での評価とレビュー ダイアログの表示](request-ratings-and-reviews.md#show-a-rating-and-review-dialog-in-your-app)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f429f-123">For more information, see [Show a rating and review dialog in your app](request-ratings-and-reviews.md#show-a-rating-and-review-dialog-in-your-app).</span></span>

## <a name="requests-for-flight-group-scenarios"></a><span data-ttu-id="f429f-124">フライト グループ シナリオの要求</span><span class="sxs-lookup"><span data-stu-id="f429f-124">Requests for flight group scenarios</span></span>

> [!IMPORTANT]
> <span data-ttu-id="f429f-125">現在のところ、このセクションで説明されているフライト グループ要求はすべて、ほとんどの開発者アカウントで使用できません。</span><span class="sxs-lookup"><span data-stu-id="f429f-125">All of the flight group requests described in this section are currently not available to most developer accounts.</span></span> <span data-ttu-id="f429f-126">開発者用アカウントが Microsoft によって特にプロビジョニングされない限り、これらの要求は失敗します。</span><span class="sxs-lookup"><span data-stu-id="f429f-126">These requests will fail unless your developer account is specially provisioned by Microsoft.</span></span>

<span data-ttu-id="f429f-127">**SendRequestAsync** メソッドは、フライト グループへのユーザーまたはデバイスの追加など、フライト グループ シナリオの一連の要求をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="f429f-127">The **SendRequestAsync** method supports a set of requests for flight group scenarios, such as adding a user or device to a flight group.</span></span> <span data-ttu-id="f429f-128">これらの要求を提出するには、値 7 または 8 を *requestKind* パラメーターに渡すと同時に、関連する引数と共に提出する要求を示す *parametersAsJson* パラメーターに JSON 形式文字列を渡します。</span><span class="sxs-lookup"><span data-stu-id="f429f-128">To submit these requests, pass the value 7 or 8 to the *requestKind* parameter along with a JSON-formatted string to the *parametersAsJson* parameter that indicates the request you want to submit along with any related arguments.</span></span> <span data-ttu-id="f429f-129">これらの *requestKind* 値は、次の点で異なります。</span><span class="sxs-lookup"><span data-stu-id="f429f-129">These *requestKind* values differ in the following ways.</span></span>

|  <span data-ttu-id="f429f-130">要求の種類を表す値</span><span class="sxs-lookup"><span data-stu-id="f429f-130">Request kind value</span></span>  |  <span data-ttu-id="f429f-131">説明</span><span class="sxs-lookup"><span data-stu-id="f429f-131">Description</span></span>  |
|----------------------|---------------|
|  <span data-ttu-id="f429f-132">7</span><span class="sxs-lookup"><span data-stu-id="f429f-132">7</span></span>                   |  <span data-ttu-id="f429f-133">要求は、現在のデバイスのコンテキストで実行されます。</span><span class="sxs-lookup"><span data-stu-id="f429f-133">The requests are performed in the context of the current device.</span></span> <span data-ttu-id="f429f-134">この値は、Windows 10 バージョン 1703 以降でのみ使用できます。</span><span class="sxs-lookup"><span data-stu-id="f429f-134">This value can only be used on Windows 10, version 1703, or later.</span></span>  |
|  <span data-ttu-id="f429f-135">8</span><span class="sxs-lookup"><span data-stu-id="f429f-135">8</span></span>                   |  <span data-ttu-id="f429f-136">要求は、ストアに現在サインインしているユーザーのコンテキストで実行されます。</span><span class="sxs-lookup"><span data-stu-id="f429f-136">The requests are performed in the context of the user who is currently signed in to the Store.</span></span> <span data-ttu-id="f429f-137">この値は、Windows 10 バージョン 1607 以降で使用できます。</span><span class="sxs-lookup"><span data-stu-id="f429f-137">This value can be used on Windows 10, version 1607, or later.</span></span>  |

<span data-ttu-id="f429f-138">現在のところ、次のフライト グループ要求が実装されています。</span><span class="sxs-lookup"><span data-stu-id="f429f-138">The following flight group requests are currently implemented.</span></span>

### <a name="retrieve-remote-variables-for-the-highest-ranked-flight-group"></a><span data-ttu-id="f429f-139">最も順位の高いフライト グループのリモート変数を取得する</span><span class="sxs-lookup"><span data-stu-id="f429f-139">Retrieve remote variables for the highest-ranked flight group</span></span>

> [!IMPORTANT]
> <span data-ttu-id="f429f-140">この要求は、現在のところほとんどの開発者アカウントで使用できません。</span><span class="sxs-lookup"><span data-stu-id="f429f-140">This request is currently not available to most developer accounts.</span></span> <span data-ttu-id="f429f-141">開発者用アカウントが Microsoft によって特にプロビジョニングされない限り、この要求は失敗します。</span><span class="sxs-lookup"><span data-stu-id="f429f-141">This request will fail unless your developer account is specially provisioned by Microsoft.</span></span>

<span data-ttu-id="f429f-142">この要求は、現在のユーザーまたはデバイスの最も順位の高いフライト グループのリモート変数を取得します。</span><span class="sxs-lookup"><span data-stu-id="f429f-142">This request retrieves the remote variables for the highest-ranked flight group for the current user or device.</span></span> <span data-ttu-id="f429f-143">この要求を送信するには、次の情報を **SendRequestAsync** メソッドの *requestKind* パラメーターと *parametersAsJson* パラメーターに渡します。</span><span class="sxs-lookup"><span data-stu-id="f429f-143">To send this request, pass the following information to the *requestKind* and *parametersAsJson* parameters of the **SendRequestAsync** method.</span></span>

|  <span data-ttu-id="f429f-144">パラメーター</span><span class="sxs-lookup"><span data-stu-id="f429f-144">Parameter</span></span>  |  <span data-ttu-id="f429f-145">説明</span><span class="sxs-lookup"><span data-stu-id="f429f-145">Description</span></span>  |
|----------------------|---------------|
|  <span data-ttu-id="f429f-146">*requestKind*</span><span class="sxs-lookup"><span data-stu-id="f429f-146">*requestKind*</span></span>                   |  <span data-ttu-id="f429f-147">デバイスの最も順位の高いフライト グループを返すには 7 を指定し、現在のユーザーとデバイスの最も順位の高いフライト グループを返すには 8 を指定します。</span><span class="sxs-lookup"><span data-stu-id="f429f-147">Specify 7 to return the highest-ranked flight group for the device, or specify 8 to return the highest-ranked flight group for the current user and device.</span></span> <span data-ttu-id="f429f-148">*requestKind* パラメーターには値 8 を使うことをお勧めします。この値は、現在のユーザーおよびデバイスの両方のメンバーシップにおいて最も順位の高いフライト グループを返すためです。</span><span class="sxs-lookup"><span data-stu-id="f429f-148">We recommend using the value 8 for the *requestKind* parameter, because this value will return the highest-ranked flight group across the membership for both the current user and device.</span></span>  |
|  <span data-ttu-id="f429f-149">*parametersAsJson*</span><span class="sxs-lookup"><span data-stu-id="f429f-149">*parametersAsJson*</span></span>                   |  <span data-ttu-id="f429f-150">次の例に示すように、データを含む JSON 形式の文字列を渡します。</span><span class="sxs-lookup"><span data-stu-id="f429f-150">Pass a JSON-formatted string that contains the data shown in the example below.</span></span>  |

<span data-ttu-id="f429f-151">次の例は、JSON 形式のデータを *parametersAsJson* に渡す方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="f429f-151">The following example shows the format of the JSON data to pass to *parametersAsJson*.</span></span> <span data-ttu-id="f429f-152">*type* フィールドは、文字列 *GetRemoteVariables* に割り当てる必要があります。</span><span class="sxs-lookup"><span data-stu-id="f429f-152">The *type* field must be assigned to the string *GetRemoteVariables*.</span></span> <span data-ttu-id="f429f-153">割り当てる、 *projectId*フィールドをパートナー センターでリモート変数が定義されているプロジェクトの ID。</span><span class="sxs-lookup"><span data-stu-id="f429f-153">Assign the *projectId* field to the ID of the project in which you defined the remote variables in Partner Center.</span></span>

```json
{ 
    "type": "GetRemoteVariables", 
    "parameters": "{ \"projectId\": \"your project ID\" }" 
}
```

<span data-ttu-id="f429f-154">この要求を提出すると、[StoreSendRequestResult](https://docs.microsoft.com/uwp/api/windows.services.store.storesendrequestresult) の戻り値の [Response](https://docs.microsoft.com/uwp/api/windows.services.store.storesendrequestresult.Response) プロパティには、次のフィールドを持つ JSON 形式の文字列が含められます。</span><span class="sxs-lookup"><span data-stu-id="f429f-154">After you submit this request, the [Response](https://docs.microsoft.com/uwp/api/windows.services.store.storesendrequestresult.Response) property of the [StoreSendRequestResult](https://docs.microsoft.com/uwp/api/windows.services.store.storesendrequestresult) return value contains a JSON-formatted string with the following fields.</span></span>

|  <span data-ttu-id="f429f-155">フィールド</span><span class="sxs-lookup"><span data-stu-id="f429f-155">Field</span></span>  |  <span data-ttu-id="f429f-156">説明</span><span class="sxs-lookup"><span data-stu-id="f429f-156">Description</span></span>  |
|----------------------|---------------|
|  <span data-ttu-id="f429f-157">*匿名*</span><span class="sxs-lookup"><span data-stu-id="f429f-157">*anonymous*</span></span>                   |  <span data-ttu-id="f429f-158">ブール値。**true** はユーザーまたはデバイス ID が要求に存在していなかったことを示し、**false** はユーザーまたはデバイス ID が要求に存在していたことを示します。</span><span class="sxs-lookup"><span data-stu-id="f429f-158">A Boolean value, where **true** indicates that the user or device identity was not present in the request, and **false** indicates that user or device identity was present in the request.</span></span>  |
|  <span data-ttu-id="f429f-159">*name*</span><span class="sxs-lookup"><span data-stu-id="f429f-159">*name*</span></span>                   |  <span data-ttu-id="f429f-160">デバイスまたはユーザーが所属する最も順位の高いフライト グループの名前を含む文字列です。</span><span class="sxs-lookup"><span data-stu-id="f429f-160">A string that contains the name of the highest-ranked flight group to which the device or user belongs.</span></span>  |
|  <span data-ttu-id="f429f-161">*設定*</span><span class="sxs-lookup"><span data-stu-id="f429f-161">*settings*</span></span>                   |  <span data-ttu-id="f429f-162">開発者がフライト グループに構成したリモート変数の名前を値を含むキー/値ペアのディクショナリです。</span><span class="sxs-lookup"><span data-stu-id="f429f-162">A dictionary of key/value pairs that contain the name and value of the remote variables that the developer has configured for the flight group.</span></span>  |

<span data-ttu-id="f429f-163">次の例では、この要求の戻り値を示します。</span><span class="sxs-lookup"><span data-stu-id="f429f-163">The following example demonstrates a return value for this request.</span></span>

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

### <a name="add-the-current-device-or-user-to-a-flight-group"></a><span data-ttu-id="f429f-164">フライト グループに現在のデバイスまたはユーザーを追加する</span><span class="sxs-lookup"><span data-stu-id="f429f-164">Add the current device or user to a flight group</span></span>

> [!IMPORTANT]
> <span data-ttu-id="f429f-165">この要求は、現在のところほとんどの開発者アカウントで使用できません。</span><span class="sxs-lookup"><span data-stu-id="f429f-165">This request is currently not available to most developer accounts.</span></span> <span data-ttu-id="f429f-166">開発者用アカウントが Microsoft によって特にプロビジョニングされない限り、この要求は失敗します。</span><span class="sxs-lookup"><span data-stu-id="f429f-166">This request will fail unless your developer account is specially provisioned by Microsoft.</span></span>

<span data-ttu-id="f429f-167">この要求を送信するには、次の情報を **SendRequestAsync** メソッドの *requestKind* パラメーターと *parametersAsJson* パラメーターに渡します。</span><span class="sxs-lookup"><span data-stu-id="f429f-167">To send this request, pass the following information to the *requestKind* and *parametersAsJson* parameters of the **SendRequestAsync** method.</span></span>

|  <span data-ttu-id="f429f-168">パラメーター</span><span class="sxs-lookup"><span data-stu-id="f429f-168">Parameter</span></span>  |  <span data-ttu-id="f429f-169">説明</span><span class="sxs-lookup"><span data-stu-id="f429f-169">Description</span></span>  |
|----------------------|---------------|
|  <span data-ttu-id="f429f-170">*requestKind*</span><span class="sxs-lookup"><span data-stu-id="f429f-170">*requestKind*</span></span>                   |  <span data-ttu-id="f429f-171">デバイスをフライト グループに追加するには 7 を指定し、現在ストアにサインインしているユーザーをフライト グループに追加するには 8 を指定します。</span><span class="sxs-lookup"><span data-stu-id="f429f-171">Specify 7 to add the device to a flight group, or specify 8 to add the user who is currently signed in to the Store to a flight group.</span></span>  |
|  <span data-ttu-id="f429f-172">*parametersAsJson*</span><span class="sxs-lookup"><span data-stu-id="f429f-172">*parametersAsJson*</span></span>                   |  <span data-ttu-id="f429f-173">次の例に示すように、データを含む JSON 形式の文字列を渡します。</span><span class="sxs-lookup"><span data-stu-id="f429f-173">Pass a JSON-formatted string that contains the data shown in the example below.</span></span>  |

<span data-ttu-id="f429f-174">次の例は、JSON 形式のデータを *parametersAsJson* に渡す方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="f429f-174">The following example shows the format of the JSON data to pass to *parametersAsJson*.</span></span> <span data-ttu-id="f429f-175">*type* フィールドは、文字列 *AddToFlightGroup* に割り当てる必要があります。</span><span class="sxs-lookup"><span data-stu-id="f429f-175">The *type* field must be assigned to the string *AddToFlightGroup*.</span></span> <span data-ttu-id="f429f-176">*flightGroupId* フィールドを、デバイスまたはユーザーを追加するフライト グループの ID に割り当てます。</span><span class="sxs-lookup"><span data-stu-id="f429f-176">Assign the *flightGroupId* field to the ID of the flight group to which you want to add the device or user.</span></span>

```json
{ 
    "type": "AddToFlightGroup", 
    "parameters": "{ \"flightGroupId\": \"your group ID\" }" 
}
```

<span data-ttu-id="f429f-177">要求でエラーが発生した場合、[StoreSendRequestResult](https://docs.microsoft.com/uwp/api/windows.services.store.storesendrequestresult) の戻り値の [HttpStatusCode](https://docs.microsoft.com/uwp/api/windows.services.store.storesendrequestresult.HttpStatusCode) プロパティには応答コードが含められます。</span><span class="sxs-lookup"><span data-stu-id="f429f-177">If there is an error with the request, the [HttpStatusCode](https://docs.microsoft.com/uwp/api/windows.services.store.storesendrequestresult.HttpStatusCode) property of the [StoreSendRequestResult](https://docs.microsoft.com/uwp/api/windows.services.store.storesendrequestresult) return value contains the response code.</span></span>

### <a name="remove-the-current-device-or-user-from-a-flight-group"></a><span data-ttu-id="f429f-178">フライト グループから現在のデバイスまたはユーザーを削除する</span><span class="sxs-lookup"><span data-stu-id="f429f-178">Remove the current device or user from a flight group</span></span>

> [!IMPORTANT]
> <span data-ttu-id="f429f-179">この要求は、現在のところほとんどの開発者アカウントで使用できません。</span><span class="sxs-lookup"><span data-stu-id="f429f-179">This request is currently not available to most developer accounts.</span></span> <span data-ttu-id="f429f-180">開発者用アカウントが Microsoft によって特にプロビジョニングされない限り、この要求は失敗します。</span><span class="sxs-lookup"><span data-stu-id="f429f-180">This request will fail unless your developer account is specially provisioned by Microsoft.</span></span>

<span data-ttu-id="f429f-181">この要求を送信するには、次の情報を **SendRequestAsync** メソッドの *requestKind* パラメーターと *parametersAsJson* パラメーターに渡します。</span><span class="sxs-lookup"><span data-stu-id="f429f-181">To send this request, pass the following information to the *requestKind* and *parametersAsJson* parameters of the **SendRequestAsync** method.</span></span>

|  <span data-ttu-id="f429f-182">パラメーター</span><span class="sxs-lookup"><span data-stu-id="f429f-182">Parameter</span></span>  |  <span data-ttu-id="f429f-183">説明</span><span class="sxs-lookup"><span data-stu-id="f429f-183">Description</span></span>  |
|----------------------|---------------|
|  <span data-ttu-id="f429f-184">*requestKind*</span><span class="sxs-lookup"><span data-stu-id="f429f-184">*requestKind*</span></span>                   |  <span data-ttu-id="f429f-185">デバイスをフライト グループから削除するには 7 を指定し、現在ストアにサインインしているユーザーをフライト グループから削除するには 8 を指定します。</span><span class="sxs-lookup"><span data-stu-id="f429f-185">Specify 7 to remove the device from a flight group, or specify 8 to remove the user who is currently signed in to the Store from a flight group.</span></span>  |
|  <span data-ttu-id="f429f-186">*parametersAsJson*</span><span class="sxs-lookup"><span data-stu-id="f429f-186">*parametersAsJson*</span></span>                   |  <span data-ttu-id="f429f-187">次の例に示すように、データを含む JSON 形式の文字列を渡します。</span><span class="sxs-lookup"><span data-stu-id="f429f-187">Pass a JSON-formatted string that contains the data shown in the example below.</span></span>  |

<span data-ttu-id="f429f-188">次の例は、JSON 形式のデータを *parametersAsJson* に渡す方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="f429f-188">The following example shows the format of the JSON data to pass to *parametersAsJson*.</span></span> <span data-ttu-id="f429f-189">*type* フィールドは、文字列 *RemoveFromFlightGroup* に割り当てる必要があります。</span><span class="sxs-lookup"><span data-stu-id="f429f-189">The *type* field must be assigned to the string *RemoveFromFlightGroup*.</span></span> <span data-ttu-id="f429f-190">*flightGroupId* フィールドを、デバイスまたはユーザーを削除するフライト グループの ID に割り当てます。</span><span class="sxs-lookup"><span data-stu-id="f429f-190">Assign the *flightGroupId* field to the ID of the flight group from which you want to remove the device or user.</span></span>

```json
{ 
    "type": "RemoveFromFlightGroup", 
    "parameters": "{ \"flightGroupId\": \"your group ID\" }" 
}
```

<span data-ttu-id="f429f-191">要求でエラーが発生した場合、[StoreSendRequestResult](https://docs.microsoft.com/uwp/api/windows.services.store.storesendrequestresult) の戻り値の [HttpStatusCode](https://docs.microsoft.com/uwp/api/windows.services.store.storesendrequestresult.HttpStatusCode) プロパティには応答コードが含められます。</span><span class="sxs-lookup"><span data-stu-id="f429f-191">If there is an error with the request, the [HttpStatusCode](https://docs.microsoft.com/uwp/api/windows.services.store.storesendrequestresult.HttpStatusCode) property of the [StoreSendRequestResult](https://docs.microsoft.com/uwp/api/windows.services.store.storesendrequestresult) return value contains the response code.</span></span>

## <a name="related-topics"></a><span data-ttu-id="f429f-192">関連トピック</span><span class="sxs-lookup"><span data-stu-id="f429f-192">Related topics</span></span>

* [<span data-ttu-id="f429f-193">評価を表示して、アプリのダイアログを確認してください。</span><span class="sxs-lookup"><span data-stu-id="f429f-193">Show a rating and review dialog in your app</span></span>](request-ratings-and-reviews.md#show-a-rating-and-review-dialog-in-your-app)
* [<span data-ttu-id="f429f-194">SendRequestAsync</span><span class="sxs-lookup"><span data-stu-id="f429f-194">SendRequestAsync</span></span>](https://docs.microsoft.com/uwp/api/windows.services.store.storerequesthelper.sendrequestasync)
