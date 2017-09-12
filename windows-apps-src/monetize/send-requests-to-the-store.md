---
author: mcleanbyron
Description: "SendRequestAsync メソッドを使うと、Windows SDK に利用できる API がまだない操作の要求を Windows ストアに送信することができます。"
title: "Windows ストアに要求を送信する"
ms.assetid: 070B9CA4-6D70-4116-9B18-FBF246716EF0
ms.author: mcleans
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, uwp, StoreRequestHelper, SendRequestAsync
ms.openlocfilehash: a949b3c93bb5b4a056f9e1fa4679e8ddca05d899
ms.sourcegitcommit: a9e4be98688b3a6125fd5dd126190fcfcd764f95
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/21/2017
---
# <a name="send-requests-to-the-windows-store"></a><span data-ttu-id="6157d-104">Windows ストアに要求を送信する</span><span class="sxs-lookup"><span data-stu-id="6157d-104">Send requests to the Windows Store</span></span>

<span data-ttu-id="6157d-105">Windows 10 バージョン 1607 以降、Windows SDK の [Windows.Services.Store](https://docs.microsoft.com/uwp/api/windows.services.store) 名前空間にはストアに関連する操作 (アプリ内購入など) の API が用意されています。</span><span class="sxs-lookup"><span data-stu-id="6157d-105">Starting in Windows 10, version 1607, the Windows SDK provides APIs for Store-related operations (such as in-app purchases) in the [Windows.Services.Store](https://docs.microsoft.com/uwp/api/windows.services.store) namespace.</span></span> <span data-ttu-id="6157d-106">ただし、ストアをサポートするサービスは OS がリリースされるたびに継続的に更新、拡張、強化されていますが、新しい API は通常 OS のメジャー リリース時にのみ Windows SDK に追加されます。</span><span class="sxs-lookup"><span data-stu-id="6157d-106">However, although the services that support the Store are constantly being updated, expanded, and improved between OS releases, new APIs are typically added to the Windows SDK only during major OS releases.</span></span>

<span data-ttu-id="6157d-107">[SendRequestAsync](https://docs.microsoft.com/uwp/api/Windows.Services.Store.StoreRequestHelper#Windows_Services_Store_StoreRequestHelper_SendRequestAsync_Windows_Services_Store_StoreContext_System_UInt32_System_String_) メソッドは、新しいバージョンの Windows SDK がリリースされる前にユニバーサル Windows プラットフォーム (UWP) アプリで新しいストアの操作を利用できるようにする柔軟な方法として用意されています。</span><span class="sxs-lookup"><span data-stu-id="6157d-107">We provide the [SendRequestAsync](https://docs.microsoft.com/uwp/api/Windows.Services.Store.StoreRequestHelper#Windows_Services_Store_StoreRequestHelper_SendRequestAsync_Windows_Services_Store_StoreContext_System_UInt32_System_String_) method as a flexible way to make new Store operations available to Universal Windows Platform (UWP) apps before a new version of the Windows SDK is released.</span></span> <span data-ttu-id="6157d-108">このメソッドを使うと、最新リリースの Windows SDK に対応する API がまだない新しい操作の要求をストアに送信することができます。</span><span class="sxs-lookup"><span data-stu-id="6157d-108">You can use this method to send requests to the Store for new operations that do not yet have a corresponding API available in the latest release of the Windows SDK.</span></span>

> [!NOTE]
> <span data-ttu-id="6157d-109">**SendRequestAsync** メソッドは、Windows 10 バージョン 1607 以降をターゲットとするアプリにのみ使うことができます。</span><span class="sxs-lookup"><span data-stu-id="6157d-109">The **SendRequestAsync** method is available only to apps that target Windows 10, version 1607, or later.</span></span> <span data-ttu-id="6157d-110">このメソッドでサポートされている要求の一部は、Windows 10 バージョン 1607 より後のリリースでのみサポートされます。</span><span class="sxs-lookup"><span data-stu-id="6157d-110">Some of the requests supported by this method are only supported in releases after Windows 10, version 1607.</span></span>

<span data-ttu-id="6157d-111">**SendRequestAsync** は、[StoreRequestHelper](https://docs.microsoft.com/uwp/api/windows.services.store.storerequesthelper) クラスの静的メソッドです。</span><span class="sxs-lookup"><span data-stu-id="6157d-111">**SendRequestAsync** is a static method of the [StoreRequestHelper](https://docs.microsoft.com/uwp/api/windows.services.store.storerequesthelper) class.</span></span> <span data-ttu-id="6157d-112">このメソッドを呼び出すには、次の情報をメソッドに渡す必要があります。</span><span class="sxs-lookup"><span data-stu-id="6157d-112">To call this method, you must pass the following information to the method:</span></span>
* <span data-ttu-id="6157d-113">操作を実行するユーザーに関する情報を提供する [StoreContext](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext) オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="6157d-113">A [StoreContext](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext) object that provides information about the user for which you want to perform the operation.</span></span> <span data-ttu-id="6157d-114">このオブジェクトについて詳しくは、「[StoreContext クラスの概要](in-app-purchases-and-trials.md#get-started-with-the-storecontext-class)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6157d-114">For more information about this object, see [Get started with the StoreContext class](in-app-purchases-and-trials.md#get-started-with-the-storecontext-class).</span></span>
* <span data-ttu-id="6157d-115">ストアに送信する要求を識別する整数。</span><span class="sxs-lookup"><span data-stu-id="6157d-115">An integer that identifies the request that you want to send to the Store.</span></span>
* <span data-ttu-id="6157d-116">要求が任意の引数をサポートする場合、要求と共に渡す引数を含む JSON 形式の文字列も渡すことができます。</span><span class="sxs-lookup"><span data-stu-id="6157d-116">If the request supports any arguments, you can also pass a JSON-formatted string that contains the arguments to pass along with the request.</span></span>

<span data-ttu-id="6157d-117">次の例は、このメソッドを呼び出す方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="6157d-117">The following example demonstrates how to call this method.</span></span> <span data-ttu-id="6157d-118">この例では、**Windows.Services.Store** 名前空間と **System.Threading.Tasks** 名前空間のステートメントを使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="6157d-118">This example requires using statements for the **Windows.Services.Store** and **System.Threading.Tasks** namespaces.</span></span>

```csharp
public async Task<bool> AddUserToFlightGroup()
{
    StoreSendRequestResult result = await StoreRequestHelper.SendRequestAsync(
        StoreContext.GetDefault(), 8,
        "{ \"type\": \"AddToFlightGroup\", \"parameters\": \"{ \"flightGroupId\": \"your group ID\" }\" }");

    if (result.ExtendedError == null)
    {
        return true;
    }

    return false;
}
```

<span data-ttu-id="6157d-119">**SendRequestAsync** メソッドで現在利用可能な要求については、以下のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6157d-119">See the following sections for information about the requests that are currently available via the **SendRequestAsync** method.</span></span> <span data-ttu-id="6157d-120">この記事は、新しい要求のサポートが追加されると更新されます。</span><span class="sxs-lookup"><span data-stu-id="6157d-120">We will update this article when support for new requests are added.</span></span>

## <a name="requests-for-flight-group-scenarios"></a><span data-ttu-id="6157d-121">フライト グループ シナリオの要求</span><span class="sxs-lookup"><span data-stu-id="6157d-121">Requests for flight group scenarios</span></span>

> [!IMPORTANT]
> <span data-ttu-id="6157d-122">現在のところ、このセクションで説明されているフライト グループ要求はすべて、ほとんどの開発者アカウントで使用できません。</span><span class="sxs-lookup"><span data-stu-id="6157d-122">All of the flight group requests described in this section are currently not available to most developer accounts.</span></span> <span data-ttu-id="6157d-123">開発者用アカウントが Microsoft によって特にプロビジョニングされない限り、これらの要求は失敗します。</span><span class="sxs-lookup"><span data-stu-id="6157d-123">These requests will fail unless your developer account is specially provisioned by Microsoft.</span></span>

<span data-ttu-id="6157d-124">**SendRequestAsync** メソッドは、フライト グループへのユーザーまたはデバイスの追加など、フライト グループ シナリオの一連の要求をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="6157d-124">The **SendRequestAsync** method supports a set of requests for flight group scenarios, such as adding a user or device to a flight group.</span></span> <span data-ttu-id="6157d-125">これらの要求を提出するには、値 7 または 8 を *requestKind* パラメーターに渡すと同時に、関連する引数と共に提出する要求を示す *parametersAsJson* パラメーターに JSON 形式文字列を渡します。</span><span class="sxs-lookup"><span data-stu-id="6157d-125">To submit these requests, pass the value 7 or 8 to the *requestKind* parameter along with a JSON-formatted string to the *parametersAsJson* parameter that indicates the request you want to submit along with any related arguments.</span></span> <span data-ttu-id="6157d-126">これらの *requestKind* 値は、次の点で異なります。</span><span class="sxs-lookup"><span data-stu-id="6157d-126">These *requestKind* values differ in the following ways.</span></span>

|  <span data-ttu-id="6157d-127">要求の種類を表す値</span><span class="sxs-lookup"><span data-stu-id="6157d-127">Request kind value</span></span>  |  <span data-ttu-id="6157d-128">説明</span><span class="sxs-lookup"><span data-stu-id="6157d-128">Description</span></span>  |
|----------------------|---------------|
|  <span data-ttu-id="6157d-129">7</span><span class="sxs-lookup"><span data-stu-id="6157d-129">7</span></span>                   |  <span data-ttu-id="6157d-130">要求は、現在のデバイスのコンテキストで実行されます。</span><span class="sxs-lookup"><span data-stu-id="6157d-130">The requests are performed in the context of the current device.</span></span> <span data-ttu-id="6157d-131">この値は、Windows 10 バージョン 1703 以降でのみ使用できます。</span><span class="sxs-lookup"><span data-stu-id="6157d-131">This value can only be used on Windows 10, version 1703, or later.</span></span>  |
|  <span data-ttu-id="6157d-132">8</span><span class="sxs-lookup"><span data-stu-id="6157d-132">8</span></span>                   |  <span data-ttu-id="6157d-133">要求は、ストアに現在サインインしているユーザーのコンテキストで実行されます。</span><span class="sxs-lookup"><span data-stu-id="6157d-133">The requests are performed in the context of the user who is currently signed in to the Store.</span></span> <span data-ttu-id="6157d-134">この値は、Windows 10 バージョン 1607 以降で使用できます。</span><span class="sxs-lookup"><span data-stu-id="6157d-134">This value can be used on Windows 10, version 1607, or later.</span></span>  |

<span data-ttu-id="6157d-135">現在のところ、次のフライト グループ要求が実装されています。</span><span class="sxs-lookup"><span data-stu-id="6157d-135">The following flight group requests are currently implemented.</span></span>

### <a name="retrieve-remote-variables-for-the-highest-ranked-flight-group"></a><span data-ttu-id="6157d-136">最も順位の高いフライト グループのリモート変数を取得する</span><span class="sxs-lookup"><span data-stu-id="6157d-136">Retrieve remote variables for the highest-ranked flight group</span></span>

> [!IMPORTANT]
> <span data-ttu-id="6157d-137">この要求は、現在のところほとんどの開発者アカウントで使用できません。</span><span class="sxs-lookup"><span data-stu-id="6157d-137">This request is currently not available to most developer accounts.</span></span> <span data-ttu-id="6157d-138">開発者用アカウントが Microsoft によって特にプロビジョニングされない限り、この要求は失敗します。</span><span class="sxs-lookup"><span data-stu-id="6157d-138">This request will fail unless your developer account is specially provisioned by Microsoft.</span></span>

<span data-ttu-id="6157d-139">この要求は、現在のユーザーまたはデバイスの最も順位の高いフライト グループのリモート変数を取得します。</span><span class="sxs-lookup"><span data-stu-id="6157d-139">This request retrieves the remote variables for the highest-ranked flight group for the current user or device.</span></span> <span data-ttu-id="6157d-140">この要求を送信するには、次の情報を **SendRequestAsync** メソッドの *requestKind* パラメーターと *parametersAsJson* パラメーターに渡します。</span><span class="sxs-lookup"><span data-stu-id="6157d-140">To send this request, pass the following information to the *requestKind* and *parametersAsJson* parameters of the **SendRequestAsync** method.</span></span>

|  <span data-ttu-id="6157d-141">パラメーター</span><span class="sxs-lookup"><span data-stu-id="6157d-141">Parameter</span></span>  |  <span data-ttu-id="6157d-142">説明</span><span class="sxs-lookup"><span data-stu-id="6157d-142">Description</span></span>  |
|----------------------|---------------|
|  *<span data-ttu-id="6157d-143">requestKind</span><span class="sxs-lookup"><span data-stu-id="6157d-143">requestKind</span></span>*                   |  <span data-ttu-id="6157d-144">デバイスの最も順位の高いフライト グループを返すには 7 を指定し、現在のユーザーとデバイスの最も順位の高いフライト グループを返すには 8 を指定します。</span><span class="sxs-lookup"><span data-stu-id="6157d-144">Specify 7 to return the highest-ranked flight group for the device, or specify 8 to return the highest-ranked flight group for the current user and device.</span></span> <span data-ttu-id="6157d-145">*requestKind* パラメーターには値 8 を使うことをお勧めします。この値は、現在のユーザーおよびデバイスの両方のメンバーシップにおいて最も順位の高いフライト グループを返すためです。</span><span class="sxs-lookup"><span data-stu-id="6157d-145">We recommend using the value 8 for the *requestKind* parameter, because this value will return the highest-ranked flight group across the membership for both the current user and device.</span></span>  |
|  *<span data-ttu-id="6157d-146">parametersAsJson</span><span class="sxs-lookup"><span data-stu-id="6157d-146">parametersAsJson</span></span>*                   |  <span data-ttu-id="6157d-147">次の例に示すように、データを含む JSON 形式の文字列を渡します。</span><span class="sxs-lookup"><span data-stu-id="6157d-147">Pass a JSON-formatted string that contains the data shown in the example below.</span></span>  |

<span data-ttu-id="6157d-148">次の例は、JSON 形式のデータを *parametersAsJson* に渡す方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="6157d-148">The following example shows the format of the JSON data to pass to *parametersAsJson*.</span></span> <span data-ttu-id="6157d-149">*type* フィールドは、文字列 *GetRemoteVariables* に割り当てる必要があります。</span><span class="sxs-lookup"><span data-stu-id="6157d-149">The *type* field must be assigned to the string *GetRemoteVariables*.</span></span> <span data-ttu-id="6157d-150">Windows デベロッパー センター ダッシュボードでリモート変数を定義したプロジェクトの ID フィールドに *projectId* フィールドを割り当てます。</span><span class="sxs-lookup"><span data-stu-id="6157d-150">Assign the *projectId* field to the ID of the project in which you defined the remote variables in the Windows Dev Center dashboard.</span></span>

```json
{ 
    "type": "GetRemoteVariables", 
    "parameters": "{ \"projectId\": \"your project ID\" }" 
}
```

<span data-ttu-id="6157d-151">この要求を提出すると、[StoreSendRequestResult](https://docs.microsoft.com/uwp/api/windows.services.store.storesendrequestresult) の戻り値の [Response](https://docs.microsoft.com/uwp/api/windows.services.store.storesendrequestresult#Windows_Services_Store_StoreSendRequestResult_Response) プロパティには、次のフィールドを持つ JSON 形式の文字列が含められます。</span><span class="sxs-lookup"><span data-stu-id="6157d-151">After you submit this request, the [Response](https://docs.microsoft.com/uwp/api/windows.services.store.storesendrequestresult#Windows_Services_Store_StoreSendRequestResult_Response) property of the [StoreSendRequestResult](https://docs.microsoft.com/uwp/api/windows.services.store.storesendrequestresult) return value contains a JSON-formatted string with the following fields.</span></span>

|  <span data-ttu-id="6157d-152">フィールド</span><span class="sxs-lookup"><span data-stu-id="6157d-152">Field</span></span>  |  <span data-ttu-id="6157d-153">説明</span><span class="sxs-lookup"><span data-stu-id="6157d-153">Description</span></span>  |
|----------------------|---------------|
|  *<span data-ttu-id="6157d-154">anonymous</span><span class="sxs-lookup"><span data-stu-id="6157d-154">anonymous</span></span>*                   |  <span data-ttu-id="6157d-155">ブール値。**true** はユーザーまたはデバイス ID が要求に存在していなかったことを示し、**false** はユーザーまたはデバイス ID が要求に存在していたことを示します。</span><span class="sxs-lookup"><span data-stu-id="6157d-155">A Boolean value, where **true** indicates that the user or device identity was not present in the request, and **false** indicates that user or device identity was present in the request.</span></span>  |
|  *<span data-ttu-id="6157d-156">name</span><span class="sxs-lookup"><span data-stu-id="6157d-156">name</span></span>*                   |  <span data-ttu-id="6157d-157">デバイスまたはユーザーが所属する最も順位の高いフライト グループの名前を含む文字列です。</span><span class="sxs-lookup"><span data-stu-id="6157d-157">A string that contains the name of the highest-ranked flight group to which the device or user belongs.</span></span>  |
|  *<span data-ttu-id="6157d-158">settings</span><span class="sxs-lookup"><span data-stu-id="6157d-158">settings</span></span>*                   |  <span data-ttu-id="6157d-159">開発者がフライト グループに構成したリモート変数の名前を値を含むキー/値ペアのディクショナリです。</span><span class="sxs-lookup"><span data-stu-id="6157d-159">A dictionary of key/value pairs that contain the name and value of the remote variables that the developer has configured for the flight group.</span></span>  |

<span data-ttu-id="6157d-160">次の例では、この要求の戻り値を示します。</span><span class="sxs-lookup"><span data-stu-id="6157d-160">The following example demonstrates a return value for this request.</span></span>

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

### <a name="add-the-current-device-or-user-to-a-flight-group"></a><span data-ttu-id="6157d-161">フライト グループに現在のデバイスまたはユーザーを追加する</span><span class="sxs-lookup"><span data-stu-id="6157d-161">Add the current device or user to a flight group</span></span>

> [!IMPORTANT]
> <span data-ttu-id="6157d-162">この要求は、現在のところほとんどの開発者アカウントで使用できません。</span><span class="sxs-lookup"><span data-stu-id="6157d-162">This request is currently not available to most developer accounts.</span></span> <span data-ttu-id="6157d-163">開発者用アカウントが Microsoft によって特にプロビジョニングされない限り、この要求は失敗します。</span><span class="sxs-lookup"><span data-stu-id="6157d-163">This request will fail unless your developer account is specially provisioned by Microsoft.</span></span>

<span data-ttu-id="6157d-164">この要求を送信するには、次の情報を **SendRequestAsync** メソッドの *requestKind* パラメーターと *parametersAsJson* パラメーターに渡します。</span><span class="sxs-lookup"><span data-stu-id="6157d-164">To send this request, pass the following information to the *requestKind* and *parametersAsJson* parameters of the **SendRequestAsync** method.</span></span>

|  <span data-ttu-id="6157d-165">パラメーター</span><span class="sxs-lookup"><span data-stu-id="6157d-165">Parameter</span></span>  |  <span data-ttu-id="6157d-166">説明</span><span class="sxs-lookup"><span data-stu-id="6157d-166">Description</span></span>  |
|----------------------|---------------|
|  *<span data-ttu-id="6157d-167">requestKind</span><span class="sxs-lookup"><span data-stu-id="6157d-167">requestKind</span></span>*                   |  <span data-ttu-id="6157d-168">デバイスをフライト グループに追加するには 7 を指定し、現在ストアにサインインしているユーザーをフライト グループに追加するには 8 を指定します。</span><span class="sxs-lookup"><span data-stu-id="6157d-168">Specify 7 to add the device to a flight group, or specify 8 to add the user who is currently signed in to the Store to a flight group.</span></span>  |
|  *<span data-ttu-id="6157d-169">parametersAsJson</span><span class="sxs-lookup"><span data-stu-id="6157d-169">parametersAsJson</span></span>*                   |  <span data-ttu-id="6157d-170">次の例に示すように、データを含む JSON 形式の文字列を渡します。</span><span class="sxs-lookup"><span data-stu-id="6157d-170">Pass a JSON-formatted string that contains the data shown in the example below.</span></span>  |

<span data-ttu-id="6157d-171">次の例は、JSON 形式のデータを *parametersAsJson* に渡す方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="6157d-171">The following example shows the format of the JSON data to pass to *parametersAsJson*.</span></span> <span data-ttu-id="6157d-172">*type* フィールドは、文字列 *AddToFlightGroup* に割り当てる必要があります。</span><span class="sxs-lookup"><span data-stu-id="6157d-172">The *type* field must be assigned to the string *AddToFlightGroup*.</span></span> <span data-ttu-id="6157d-173">*flightGroupId* フィールドを、デバイスまたはユーザーを追加するフライト グループの ID に割り当てます。</span><span class="sxs-lookup"><span data-stu-id="6157d-173">Assign the *flightGroupId* field to the ID of the flight group to which you want to add the device or user.</span></span>

```json
{ 
    "type": "AddToFlightGroup", 
    "parameters": "{ \"flightGroupId\": \"your group ID\" }" 
}
```

<span data-ttu-id="6157d-174">要求でエラーが発生した場合、[StoreSendRequestResult](https://docs.microsoft.com/uwp/api/windows.services.store.storesendrequestresult) の戻り値の [HttpStatusCode](https://docs.microsoft.com/uwp/api/windows.services.store.storesendrequestresult#Windows_Services_Store_StoreSendRequestResult_HttpStatusCode) プロパティには応答コードが含められます。</span><span class="sxs-lookup"><span data-stu-id="6157d-174">If there is an error with the request, the [HttpStatusCode](https://docs.microsoft.com/uwp/api/windows.services.store.storesendrequestresult#Windows_Services_Store_StoreSendRequestResult_HttpStatusCode) property of the [StoreSendRequestResult](https://docs.microsoft.com/uwp/api/windows.services.store.storesendrequestresult) return value contains the response code.</span></span>

### <a name="remove-the-current-device-or-user-from-a-flight-group"></a><span data-ttu-id="6157d-175">フライト グループから現在のデバイスまたはユーザーを削除する</span><span class="sxs-lookup"><span data-stu-id="6157d-175">Remove the current device or user from a flight group</span></span>

> [!IMPORTANT]
> <span data-ttu-id="6157d-176">この要求は、現在のところほとんどの開発者アカウントで使用できません。</span><span class="sxs-lookup"><span data-stu-id="6157d-176">This request is currently not available to most developer accounts.</span></span> <span data-ttu-id="6157d-177">開発者用アカウントが Microsoft によって特にプロビジョニングされない限り、この要求は失敗します。</span><span class="sxs-lookup"><span data-stu-id="6157d-177">This request will fail unless your developer account is specially provisioned by Microsoft.</span></span>

<span data-ttu-id="6157d-178">この要求を送信するには、次の情報を **SendRequestAsync** メソッドの *requestKind* パラメーターと *parametersAsJson* パラメーターに渡します。</span><span class="sxs-lookup"><span data-stu-id="6157d-178">To send this request, pass the following information to the *requestKind* and *parametersAsJson* parameters of the **SendRequestAsync** method.</span></span>

|  <span data-ttu-id="6157d-179">パラメーター</span><span class="sxs-lookup"><span data-stu-id="6157d-179">Parameter</span></span>  |  <span data-ttu-id="6157d-180">説明</span><span class="sxs-lookup"><span data-stu-id="6157d-180">Description</span></span>  |
|----------------------|---------------|
|  *<span data-ttu-id="6157d-181">requestKind</span><span class="sxs-lookup"><span data-stu-id="6157d-181">requestKind</span></span>*                   |  <span data-ttu-id="6157d-182">デバイスをフライト グループから削除するには 7 を指定し、現在ストアにサインインしているユーザーをフライト グループから削除するには 8 を指定します。</span><span class="sxs-lookup"><span data-stu-id="6157d-182">Specify 7 to remove the device from a flight group, or specify 8 to remove the user who is currently signed in to the Store from a flight group.</span></span>  |
|  *<span data-ttu-id="6157d-183">parametersAsJson</span><span class="sxs-lookup"><span data-stu-id="6157d-183">parametersAsJson</span></span>*                   |  <span data-ttu-id="6157d-184">次の例に示すように、データを含む JSON 形式の文字列を渡します。</span><span class="sxs-lookup"><span data-stu-id="6157d-184">Pass a JSON-formatted string that contains the data shown in the example below.</span></span>  |

<span data-ttu-id="6157d-185">次の例は、JSON 形式のデータを *parametersAsJson* に渡す方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="6157d-185">The following example shows the format of the JSON data to pass to *parametersAsJson*.</span></span> <span data-ttu-id="6157d-186">*type* フィールドは、文字列 *RemoveFromFlightGroup* に割り当てる必要があります。</span><span class="sxs-lookup"><span data-stu-id="6157d-186">The *type* field must be assigned to the string *RemoveFromFlightGroup*.</span></span> <span data-ttu-id="6157d-187">*flightGroupId* フィールドを、デバイスまたはユーザーを削除するフライト グループの ID に割り当てます。</span><span class="sxs-lookup"><span data-stu-id="6157d-187">Assign the *flightGroupId* field to the ID of the flight group from which you want to remove the device or user.</span></span>

```json
{ 
    "type": "RemoveFromFlightGroup", 
    "parameters": "{ \"flightGroupId\": \"your group ID\" }" 
}
```

<span data-ttu-id="6157d-188">要求でエラーが発生した場合、[StoreSendRequestResult](https://docs.microsoft.com/uwp/api/windows.services.store.storesendrequestresult) の戻り値の [HttpStatusCode](https://docs.microsoft.com/uwp/api/windows.services.store.storesendrequestresult#Windows_Services_Store_StoreSendRequestResult_HttpStatusCode) プロパティには応答コードが含められます。</span><span class="sxs-lookup"><span data-stu-id="6157d-188">If there is an error with the request, the [HttpStatusCode](https://docs.microsoft.com/uwp/api/windows.services.store.storesendrequestresult#Windows_Services_Store_StoreSendRequestResult_HttpStatusCode) property of the [StoreSendRequestResult](https://docs.microsoft.com/uwp/api/windows.services.store.storesendrequestresult) return value contains the response code.</span></span>

## <a name="related-topics"></a><span data-ttu-id="6157d-189">関連トピック</span><span class="sxs-lookup"><span data-stu-id="6157d-189">Related topics</span></span>

* [<span data-ttu-id="6157d-190">SendRequestAsync</span><span class="sxs-lookup"><span data-stu-id="6157d-190">SendRequestAsync</span></span>](https://docs.microsoft.com/uwp/api/Windows.Services.Store.StoreRequestHelper#Windows_Services_Store_StoreRequestHelper_SendRequestAsync_Windows_Services_Store_StoreContext_System_UInt32_System_String_)
