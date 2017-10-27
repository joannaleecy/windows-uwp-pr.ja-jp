---
author: mcleanbyron
ms.assetid: F37C2CEC-9ED1-4F9E-883D-9FBB082504D4
description: "ユーザーのサブスクリプションの請求状態を変更するには、Windows ストア購入 API でこのメソッドを使います。"
title: "ユーザーのサブスクリプションに関する請求の状態を変更する"
ms.author: mcleans
ms.date: 04/11/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, uwp, Windows ストア購入 API, サブスクリプション"
ms.openlocfilehash: 920184a312b086cbf44db1e271e75893a9e24e01
ms.sourcegitcommit: 6c6f3c265498d7651fcc4081c04c41fafcbaa5e7
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/09/2017
---
# <a name="change-the-billing-state-of-a-subscription-for-a-user"></a><span data-ttu-id="0b786-104">ユーザーのサブスクリプションに関する請求の状態を変更する</span><span class="sxs-lookup"><span data-stu-id="0b786-104">Change the billing state of a subscription for a user</span></span>

<span data-ttu-id="0b786-105">特定のユーザーのサブスクリプション アドオンの請求状態を変更するには、Windows ストア購入 API でこのメソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="0b786-105">Use this method in the Windows Store purchase API to change the billing state of a subscription add-on for a given user.</span></span> <span data-ttu-id="0b786-106">サブスクリプションのキャンセル、延長、払い戻し、または自動更新の無効化を行えます。</span><span class="sxs-lookup"><span data-stu-id="0b786-106">You can cancel, extend, refund, or disable automatic renewal for a subscription.</span></span>

> [!NOTE]
> <span data-ttu-id="0b786-107">このメソッドは、ユニバーサル Windows プラットフォーム (UWP) アプリ用のサブスクリプション アドオンを作成できるように Microsoft がプロビジョニングした開発者アカウントでのみ使うことができます。</span><span class="sxs-lookup"><span data-stu-id="0b786-107">This method can only be used by developer accounts that have been provisioned by Microsoft to be able to create subscription add-ons for Universal Windows Platform (UWP) apps.</span></span> <span data-ttu-id="0b786-108">現在のところ、サブスクリプション アドオンはほとんどの開発者アカウントで使うことができません。</span><span class="sxs-lookup"><span data-stu-id="0b786-108">Subscription add-ons are currently not available to most developer accounts.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="0b786-109">前提条件</span><span class="sxs-lookup"><span data-stu-id="0b786-109">Prerequisites</span></span>

<span data-ttu-id="0b786-110">このメソッドを使用するための要件:</span><span class="sxs-lookup"><span data-stu-id="0b786-110">To use this method, you will need:</span></span>

* <span data-ttu-id="0b786-111">`https://onestore.microsoft.com` 対象ユーザー URI を使用して作成した Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="0b786-111">An Azure AD access token that was created with the `https://onestore.microsoft.com` audience URI.</span></span>
* <span data-ttu-id="0b786-112">変更するサブスクリプションの権利を持っているユーザーの ID を表す Windows ストア ID キー。</span><span class="sxs-lookup"><span data-stu-id="0b786-112">A Windows Store ID key that represents the identity of the user who has an entitlement to the subscription you want to change.</span></span>

<span data-ttu-id="0b786-113">詳しくは、「[サービスから製品の権利を管理する](view-and-grant-products-from-a-service.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0b786-113">For more information, see [Manage product entitlements from a service](view-and-grant-products-from-a-service.md).</span></span>

## <a name="request"></a><span data-ttu-id="0b786-114">要求</span><span class="sxs-lookup"><span data-stu-id="0b786-114">Request</span></span>


### <a name="request-syntax"></a><span data-ttu-id="0b786-115">要求の構文</span><span class="sxs-lookup"><span data-stu-id="0b786-115">Request syntax</span></span>

| <span data-ttu-id="0b786-116">メソッド</span><span class="sxs-lookup"><span data-stu-id="0b786-116">Method</span></span> | <span data-ttu-id="0b786-117">要求 URI</span><span class="sxs-lookup"><span data-stu-id="0b786-117">Request URI</span></span>                                            |
|--------|--------------------------------------------------------|
| <span data-ttu-id="0b786-118">POST</span><span class="sxs-lookup"><span data-stu-id="0b786-118">POST</span></span>   | ```https://purchase.mp.microsoft.com/v8.0/b2b/recurrences/{recurrenceId}/change``` |

<span/> 

### <a name="request-header"></a><span data-ttu-id="0b786-119">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0b786-119">Request header</span></span>

| <span data-ttu-id="0b786-120">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0b786-120">Header</span></span>         | <span data-ttu-id="0b786-121">型</span><span class="sxs-lookup"><span data-stu-id="0b786-121">Type</span></span>   | <span data-ttu-id="0b786-122">説明</span><span class="sxs-lookup"><span data-stu-id="0b786-122">Description</span></span>   |
|----------------|--------|-------------|
| <span data-ttu-id="0b786-123">Authorization</span><span class="sxs-lookup"><span data-stu-id="0b786-123">Authorization</span></span>  | <span data-ttu-id="0b786-124">string</span><span class="sxs-lookup"><span data-stu-id="0b786-124">string</span></span> | <span data-ttu-id="0b786-125">必須。</span><span class="sxs-lookup"><span data-stu-id="0b786-125">Required.</span></span> <span data-ttu-id="0b786-126">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="0b786-126">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span>                           |
| <span data-ttu-id="0b786-127">Host</span><span class="sxs-lookup"><span data-stu-id="0b786-127">Host</span></span>           | <span data-ttu-id="0b786-128">string</span><span class="sxs-lookup"><span data-stu-id="0b786-128">string</span></span> | <span data-ttu-id="0b786-129">値 **purchase.mp.microsoft.com** に設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0b786-129">Must be set to the value **purchase.mp.microsoft.com**.</span></span>                                            |
| <span data-ttu-id="0b786-130">Content-Length</span><span class="sxs-lookup"><span data-stu-id="0b786-130">Content-Length</span></span> | <span data-ttu-id="0b786-131">number</span><span class="sxs-lookup"><span data-stu-id="0b786-131">number</span></span> | <span data-ttu-id="0b786-132">要求の本文の長さ。</span><span class="sxs-lookup"><span data-stu-id="0b786-132">The length of the request body.</span></span>                                                                       |
| <span data-ttu-id="0b786-133">Content-Type</span><span class="sxs-lookup"><span data-stu-id="0b786-133">Content-Type</span></span>   | <span data-ttu-id="0b786-134">string</span><span class="sxs-lookup"><span data-stu-id="0b786-134">string</span></span> | <span data-ttu-id="0b786-135">要求と応答の種類を指定します。</span><span class="sxs-lookup"><span data-stu-id="0b786-135">Specifies the request and response type.</span></span> <span data-ttu-id="0b786-136">現時点では、サポートされている唯一の値は **application/json** です。</span><span class="sxs-lookup"><span data-stu-id="0b786-136">Currently, the only supported value is **application/json**.</span></span> |

<span/>

### <a name="request-parameters"></a><span data-ttu-id="0b786-137">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="0b786-137">Request parameters</span></span>

| <span data-ttu-id="0b786-138">名前</span><span class="sxs-lookup"><span data-stu-id="0b786-138">Name</span></span>         | <span data-ttu-id="0b786-139">種類</span><span class="sxs-lookup"><span data-stu-id="0b786-139">Type</span></span>  | <span data-ttu-id="0b786-140">説明</span><span class="sxs-lookup"><span data-stu-id="0b786-140">Description</span></span>   |  <span data-ttu-id="0b786-141">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="0b786-141">Required</span></span>  |
|----------------|--------|-------------|-----------|
| <span data-ttu-id="0b786-142">recurrenceId</span><span class="sxs-lookup"><span data-stu-id="0b786-142">recurrenceId</span></span> | <span data-ttu-id="0b786-143">string</span><span class="sxs-lookup"><span data-stu-id="0b786-143">string</span></span> | <span data-ttu-id="0b786-144">変更するサブスクリプションの ID。</span><span class="sxs-lookup"><span data-stu-id="0b786-144">The ID of the subscription you want to change.</span></span> <span data-ttu-id="0b786-145">この ID を取得するには、[ユーザーのサブスクリプションの取得](get-subscriptions-for-a-user.md)メソッドを呼び出して、変更するサブスクリプション アドオンを表す応答本文エントリを識別し、エントリの **Id** フィールドの値を使います。</span><span class="sxs-lookup"><span data-stu-id="0b786-145">To get this ID, call the [get subscriptions for a user](get-subscriptions-for-a-user.md) method, identify the response body entry that represents the subscription add-on you want to change, and use the value of the **Id** field for the entry.</span></span>     | <span data-ttu-id="0b786-146">必須</span><span class="sxs-lookup"><span data-stu-id="0b786-146">Yes</span></span>      |

<span/>

### <a name="request-body"></a><span data-ttu-id="0b786-147">要求本文</span><span class="sxs-lookup"><span data-stu-id="0b786-147">Request body</span></span>

| <span data-ttu-id="0b786-148">フィールド</span><span class="sxs-lookup"><span data-stu-id="0b786-148">Field</span></span>      | <span data-ttu-id="0b786-149">型</span><span class="sxs-lookup"><span data-stu-id="0b786-149">Type</span></span>   | <span data-ttu-id="0b786-150">説明</span><span class="sxs-lookup"><span data-stu-id="0b786-150">Description</span></span>   | <span data-ttu-id="0b786-151">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="0b786-151">Required</span></span> |
|----------------|--------|---------------|----------|
| <span data-ttu-id="0b786-152">b2bKey</span><span class="sxs-lookup"><span data-stu-id="0b786-152">b2bKey</span></span>         | <span data-ttu-id="0b786-153">string</span><span class="sxs-lookup"><span data-stu-id="0b786-153">string</span></span> | <span data-ttu-id="0b786-154">変更対象のサブスクリプションを所有するユーザーの ID を表す [Windows ストア ID キー](view-and-grant-products-from-a-service.md#step-4)。</span><span class="sxs-lookup"><span data-stu-id="0b786-154">The [Windows Store ID key](view-and-grant-products-from-a-service.md#step-4) that represents the identity of the user whose subscription you want to change.</span></span>     | <span data-ttu-id="0b786-155">必須</span><span class="sxs-lookup"><span data-stu-id="0b786-155">Yes</span></span>      |
| <span data-ttu-id="0b786-156">changeType</span><span class="sxs-lookup"><span data-stu-id="0b786-156">changeType</span></span>     | <span data-ttu-id="0b786-157">string</span><span class="sxs-lookup"><span data-stu-id="0b786-157">string</span></span> |  <span data-ttu-id="0b786-158">加える変更の種類を識別する次のいずれかの文字列です。</span><span class="sxs-lookup"><span data-stu-id="0b786-158">One of the following strings that identifies the type of change you want to make:</span></span><ul><li><span data-ttu-id="0b786-159">**Cancel**: サブスクリプションをキャンセルします。</span><span class="sxs-lookup"><span data-stu-id="0b786-159">**Cancel**: Cancels the subscription.</span></span></li><li><span data-ttu-id="0b786-160">**Extend**: サブスクリプションを延長します。</span><span class="sxs-lookup"><span data-stu-id="0b786-160">**Extend**: Extends the subscription.</span></span> <span data-ttu-id="0b786-161">この値を指定する場合、*extensionTimeInDays* パラメーターも含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="0b786-161">If you specify this value, you must also include the *extensionTimeInDays* parameter.</span></span></li><li><span data-ttu-id="0b786-162">**Refund**: サブスクリプションを顧客に払い戻します。</span><span class="sxs-lookup"><span data-stu-id="0b786-162">**Refund**: Refunds the subscription to the customer.</span></span></li><li><span data-ttu-id="0b786-163">**ToggleAutoRenew**: サブスクリプションの自動更新を無効にします。</span><span class="sxs-lookup"><span data-stu-id="0b786-163">**ToggleAutoRenew**: Disables automatic renewal for the subscription.</span></span> <span data-ttu-id="0b786-164">サブスクリプションの自動更新が現在無効になっている場合、この値は何も行いません。</span><span class="sxs-lookup"><span data-stu-id="0b786-164">If automatic renewal is currently disabled for the subscription, this value does nothing.</span></span></li></ul>   | <span data-ttu-id="0b786-165">必須</span><span class="sxs-lookup"><span data-stu-id="0b786-165">Yes</span></span>      |
| <span data-ttu-id="0b786-166">extensionTimeInDays</span><span class="sxs-lookup"><span data-stu-id="0b786-166">extensionTimeInDays</span></span>  | <span data-ttu-id="0b786-167">string</span><span class="sxs-lookup"><span data-stu-id="0b786-167">string</span></span>  | <span data-ttu-id="0b786-168">*changeType* パラメーターの値が **Extend** の場合、このパラメーターはサブスクリプションを延長する日数を指定します。</span><span class="sxs-lookup"><span data-stu-id="0b786-168">If the *changeType* parameter has the value **Extend**, this parameter specifies the number of days to extend the subscription.</span></span> |  <span data-ttu-id="0b786-169">*changeType* の値が **Extend** の場合は必須、それ以外の場合は必須ではありません。</span><span class="sxs-lookup"><span data-stu-id="0b786-169">Yes, if *changeType* has the value **Extend**; otherwise, no.</span></span>  ||

<span/>

### <a name="request-example"></a><span data-ttu-id="0b786-170">要求の例</span><span class="sxs-lookup"><span data-stu-id="0b786-170">Request example</span></span>

<span data-ttu-id="0b786-171">次の例は、このメソッドを使ってサブスクリプション期間を 5 日延長する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="0b786-171">The following example demonstrates how to use this method to extend the subscription period by 5 days.</span></span> <span data-ttu-id="0b786-172">*b2bKey* 値は、変更対象のサブスクリプションを持つユーザーの ID を表す [Windows ストア ID キー](view-and-grant-products-from-a-service.md#step-4)に置き換えます。</span><span class="sxs-lookup"><span data-stu-id="0b786-172">Replace the *b2bKey* value with the [Windows Store ID key](view-and-grant-products-from-a-service.md#step-4) that represents the identity of the user whose subscription you want to change.</span></span>

```json
POST https://purchase.mp.microsoft.com/v8.0/b2b/recurrences/query HTTP/1.1
Authorization: Bearer <your access token>
Content-Type: application/json
Host: https://purchase.mp.microsoft.com

{
  "b2bKey":  "eyJ0eXAiOiJ...",
  "changeType": "Extend",
  "extensionTimeInDays": "5"
}
```


## <a name="response"></a><span data-ttu-id="0b786-173">応答</span><span class="sxs-lookup"><span data-stu-id="0b786-173">Response</span></span>

<span data-ttu-id="0b786-174">このメソッドは、変更されたすべてのフィールドを含む、変更されたサブスクリプション アドオンに関する情報を含む JSON 応答本文を返します。</span><span class="sxs-lookup"><span data-stu-id="0b786-174">This method returns a JSON response body that contains information about the subscription add-on that was modified, including any fields that were modified.</span></span> <span data-ttu-id="0b786-175">このメソッドの応答本文を次の例に示します。</span><span class="sxs-lookup"><span data-stu-id="0b786-175">The following example demonstrates a response body for this method.</span></span>

```json
{
  "items": [
    {
      "autoRenew":true,
      "beneficiary":"pub:gFVuEBiZHPXonkYvtdOi+tLE2h4g2Ss0ZId0RQOwzDg=",
      "expirationTime":"2017-06-16T03:07:49.2552941+00:00",
      "id":"mdr:0:bc0cb6960acd4515a0e1d638192d77b7:77d5ebee-0310-4d23-b204-83e8613baaac",
      "lastModified":"2017-01-10T21:08:13.1459644+00:00",
      "market":"US",
      "productId":"9NBLGGH52Q8X",
      "skuId":"0024",
      "startTime":"2017-01-10T21:07:49.2552941+00:00",
      "recurrenceState":"Active"
    }
  ]
}
```


### <a name="response-body"></a><span data-ttu-id="0b786-176">応答本文</span><span class="sxs-lookup"><span data-stu-id="0b786-176">Response body</span></span>

<span data-ttu-id="0b786-177">応答本文には、次のデータが含まれています。</span><span class="sxs-lookup"><span data-stu-id="0b786-177">The response body contains the following data.</span></span>

| <span data-ttu-id="0b786-178">値</span><span class="sxs-lookup"><span data-stu-id="0b786-178">Value</span></span>        | <span data-ttu-id="0b786-179">型</span><span class="sxs-lookup"><span data-stu-id="0b786-179">Type</span></span>   | <span data-ttu-id="0b786-180">説明</span><span class="sxs-lookup"><span data-stu-id="0b786-180">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------|
| <span data-ttu-id="0b786-181">autoRenew</span><span class="sxs-lookup"><span data-stu-id="0b786-181">autoRenew</span></span> | <span data-ttu-id="0b786-182">ブール値</span><span class="sxs-lookup"><span data-stu-id="0b786-182">Boolean</span></span> |  <span data-ttu-id="0b786-183">現在のサブスクリプション期間の終了時にサブスクリプションが自動的に更新されるように構成されているかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="0b786-183">Indicates whether the subscription is configured to automatically renew at the end of the current subscription period.</span></span>   |
| <span data-ttu-id="0b786-184">beneficiary</span><span class="sxs-lookup"><span data-stu-id="0b786-184">beneficiary</span></span> | <span data-ttu-id="0b786-185">string</span><span class="sxs-lookup"><span data-stu-id="0b786-185">string</span></span> |  <span data-ttu-id="0b786-186">このサブスクリプションに関連付けられている権利の受益者 ID。</span><span class="sxs-lookup"><span data-stu-id="0b786-186">The ID of the beneficiary of the entitlement that is associated with this subscription.</span></span>   |
| <span data-ttu-id="0b786-187">expirationTime</span><span class="sxs-lookup"><span data-stu-id="0b786-187">expirationTime</span></span> | <span data-ttu-id="0b786-188">string</span><span class="sxs-lookup"><span data-stu-id="0b786-188">string</span></span> | <span data-ttu-id="0b786-189">サブスクリプションの有効期限が切れる日時 (ISO 8601形式)。</span><span class="sxs-lookup"><span data-stu-id="0b786-189">The date and time the subscription will expire, in ISO 8601 format.</span></span> <span data-ttu-id="0b786-190">このフィールドは、サブスクリプションが特定の状態のときのみ利用可能です。</span><span class="sxs-lookup"><span data-stu-id="0b786-190">This field is only available when the subscription is in certain states.</span></span> <span data-ttu-id="0b786-191">有効期限は通常、現在の状態の有効期限がいつ切れるかを示します。</span><span class="sxs-lookup"><span data-stu-id="0b786-191">The expiration time usually indicates when the current state expires.</span></span> <span data-ttu-id="0b786-192">たとえば、アクティブなサブスクリプションの場合、有効期限日は次の自動更新がいつ行われるかを示します。</span><span class="sxs-lookup"><span data-stu-id="0b786-192">For example, for an active subscription, the expiration date indicates when the next automatic renewal will occur.</span></span>    |
| <span data-ttu-id="0b786-193">id</span><span class="sxs-lookup"><span data-stu-id="0b786-193">id</span></span> | <span data-ttu-id="0b786-194">string</span><span class="sxs-lookup"><span data-stu-id="0b786-194">string</span></span> |  <span data-ttu-id="0b786-195">サブスクリプションの ID。</span><span class="sxs-lookup"><span data-stu-id="0b786-195">The ID of the subscription.</span></span> <span data-ttu-id="0b786-196">[ユーザーのサブスクリプションの請求状態を変更する](change-the-billing-state-of-a-subscription-for-a-user.md)メソッドを呼び出すときに変更するサブスクリプションを指定するには、この値を使います。</span><span class="sxs-lookup"><span data-stu-id="0b786-196">Use this value to indicate which subscription you want to modify when you call the [change the billing state of a subscription for a user](change-the-billing-state-of-a-subscription-for-a-user.md) method.</span></span>    |
| <span data-ttu-id="0b786-197">isTrial</span><span class="sxs-lookup"><span data-stu-id="0b786-197">isTrial</span></span> | <span data-ttu-id="0b786-198">ブール値</span><span class="sxs-lookup"><span data-stu-id="0b786-198">Boolean</span></span> |  <span data-ttu-id="0b786-199">サブスクリプションが試用版であるかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="0b786-199">Indicates whether the subscription is a trial.</span></span>     |
| <span data-ttu-id="0b786-200">lastModified</span><span class="sxs-lookup"><span data-stu-id="0b786-200">lastModified</span></span> | <span data-ttu-id="0b786-201">string</span><span class="sxs-lookup"><span data-stu-id="0b786-201">string</span></span> |  <span data-ttu-id="0b786-202">サブスクリプションが前回変更された日時 (ISO 8601形式)。</span><span class="sxs-lookup"><span data-stu-id="0b786-202">The date and time the subscription was last modified, in ISO 8601 format.</span></span>      |
| <span data-ttu-id="0b786-203">market</span><span class="sxs-lookup"><span data-stu-id="0b786-203">market</span></span> | <span data-ttu-id="0b786-204">string</span><span class="sxs-lookup"><span data-stu-id="0b786-204">string</span></span> | <span data-ttu-id="0b786-205">ユーザーがサブスクリプションを取得した国コード (2 文字の ISO 3166-1 alpha-2 形式)。</span><span class="sxs-lookup"><span data-stu-id="0b786-205">The country code (in two-letter ISO 3166-1 alpha-2 format) in which the user acquired the subscription.</span></span>      |
| <span data-ttu-id="0b786-206">productId</span><span class="sxs-lookup"><span data-stu-id="0b786-206">productId</span></span> | <span data-ttu-id="0b786-207">string</span><span class="sxs-lookup"><span data-stu-id="0b786-207">string</span></span> | <span data-ttu-id="0b786-208">Windows ストア カタログでのサブスクリプション アドオンを表す[製品](in-app-purchases-and-trials.md#products-skus-and-availabilities)の[ストア ID](in-app-purchases-and-trials.md#store-ids) です。</span><span class="sxs-lookup"><span data-stu-id="0b786-208">The [Store ID](in-app-purchases-and-trials.md#store-ids) for the [product](in-app-purchases-and-trials.md#products-skus-and-availabilities) that represents the subscription add-on in the Windows Store catalog.</span></span> <span data-ttu-id="0b786-209">製品のストア ID の例は、9NBLGGH42CFD です。</span><span class="sxs-lookup"><span data-stu-id="0b786-209">An example Store ID for a product is 9NBLGGH42CFD.</span></span>     |
| <span data-ttu-id="0b786-210">skuId</span><span class="sxs-lookup"><span data-stu-id="0b786-210">skuId</span></span> | <span data-ttu-id="0b786-211">string</span><span class="sxs-lookup"><span data-stu-id="0b786-211">string</span></span> |  <span data-ttu-id="0b786-212">Windows ストア カタログでのサブスクリプション アドオンを表す [SKU](in-app-purchases-and-trials.md#products-skus-and-availabilities) の[ストア ID](in-app-purchases-and-trials.md#store-ids) です。</span><span class="sxs-lookup"><span data-stu-id="0b786-212">The [Store ID](in-app-purchases-and-trials.md#store-ids) for the [SKU](in-app-purchases-and-trials.md#products-skus-and-availabilities) that represents the subscription add-on the Windows Store catalog.</span></span> <span data-ttu-id="0b786-213">SKU のストア ID の例は、0010 です。</span><span class="sxs-lookup"><span data-stu-id="0b786-213">An example Store ID for a SKU is 0010.</span></span>    |
| <span data-ttu-id="0b786-214">startTime</span><span class="sxs-lookup"><span data-stu-id="0b786-214">startTime</span></span> | <span data-ttu-id="0b786-215">string</span><span class="sxs-lookup"><span data-stu-id="0b786-215">string</span></span> |  <span data-ttu-id="0b786-216">サブスクリプションの開始日時 (ISO 8601 形式)。</span><span class="sxs-lookup"><span data-stu-id="0b786-216">The start date and time for the subscription, in ISO 8601 format.</span></span>     |
| <span data-ttu-id="0b786-217">recurrenceState</span><span class="sxs-lookup"><span data-stu-id="0b786-217">recurrenceState</span></span> | <span data-ttu-id="0b786-218">string</span><span class="sxs-lookup"><span data-stu-id="0b786-218">string</span></span>  |  <span data-ttu-id="0b786-219">次のいずれかの値です。</span><span class="sxs-lookup"><span data-stu-id="0b786-219">One of the following values:</span></span><ul><li><span data-ttu-id="0b786-220">**None**:&nbsp;&nbsp;永続サブスクリプションを示す。</span><span class="sxs-lookup"><span data-stu-id="0b786-220">**None**:&nbsp;&nbsp;This indicates a perpetual subscription.</span></span></li><li><span data-ttu-id="0b786-221">**Active**:&nbsp;&nbsp;サブスクリプションがアクティブであり、ユーザーがサービスを使う権利を持っている。</span><span class="sxs-lookup"><span data-stu-id="0b786-221">**Active**:&nbsp;&nbsp;The subscription is active and the user is entitled to use the services.</span></span></li><li><span data-ttu-id="0b786-222">**Inactive**:&nbsp;&nbsp;サブスクリプションの有効期限が過去の日付であり、ユーザーがサブスクリプションの自動更新オプションをオフにした。</span><span class="sxs-lookup"><span data-stu-id="0b786-222">**Inactive**:&nbsp;&nbsp;The subscription is past the expiration date, and the user turned off the automatic renew option for the subscription.</span></span></li><li><span data-ttu-id="0b786-223">**Canceled**:&nbsp;&nbsp;サブスクリプションが、有効期限前に意図的に終了された (払い戻しあり、またはなし)。</span><span class="sxs-lookup"><span data-stu-id="0b786-223">**Canceled**:&nbsp;&nbsp;The subscription has been purposefully terminated before the expiration date, with or without a refund.</span></span></li><li><span data-ttu-id="0b786-224">**InDunning**:&nbsp;&nbsp;サブスクリプションが*催促中*である (つまり、サブスクリプションの有効期限が近づいているため、Microsoft がサブスクリプションを自動更新する資金を得ようとしている)。</span><span class="sxs-lookup"><span data-stu-id="0b786-224">**InDunning**:&nbsp;&nbsp;The subscription is in *dunning* (that is, the subscription is nearing expiration, and Microsoft is trying to acquire funds to automatically renew the subscription).</span></span></li><li><span data-ttu-id="0b786-225">**Failed**:&nbsp;&nbsp;催促期間が終了し、何回か試行された後サブスクリプションの更新に失敗した。</span><span class="sxs-lookup"><span data-stu-id="0b786-225">**Failed**:&nbsp;&nbsp;The dunning period is over and the subscription failed to renew after several attempts.</span></span></li></ul><p>**<span data-ttu-id="0b786-226">注:</span><span class="sxs-lookup"><span data-stu-id="0b786-226">Note:</span></span>**</p><ul><li><span data-ttu-id="0b786-227">**Inactive**/**Canceled**/**Failed** は終了状態です。</span><span class="sxs-lookup"><span data-stu-id="0b786-227">**Inactive**/**Canceled**/**Failed** are terminal states.</span></span> <span data-ttu-id="0b786-228">サブスクリプションがこれらのいずれかの状態になると、ユーザーはサブスクリプションを再購入してもう一度アクティブ化する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0b786-228">When a subscription enters one of these states, the user must repurchase the subscription to activate it again.</span></span> <span data-ttu-id="0b786-229">ユーザーは、これらの状態でサービスを使うことはできません。</span><span class="sxs-lookup"><span data-stu-id="0b786-229">The user is not entitled to use the services in these states.</span></span></li><li><span data-ttu-id="0b786-230">サブスクリプションが **Canceled** になると、キャンセルの日時によって expirationTime が更新されます。</span><span class="sxs-lookup"><span data-stu-id="0b786-230">When a subscription is **Canceled**, the expirationTime will be updated with the date and time of the cancellation.</span></span></li><li><span data-ttu-id="0b786-231">サブスクリプションの ID は、有効期限が終了するまで同じままです。</span><span class="sxs-lookup"><span data-stu-id="0b786-231">The ID of the subscription will remain the same during its entire lifetime.</span></span> <span data-ttu-id="0b786-232">自動更新オプションがオンでもオフでも変更されません。</span><span class="sxs-lookup"><span data-stu-id="0b786-232">It will not change if the auto-renew option is turned on or off.</span></span> <span data-ttu-id="0b786-233">終了状態に達した後ユーザーがサブスクリプションを再購入した場合、新しいサブスクリプション ID が作成されます。</span><span class="sxs-lookup"><span data-stu-id="0b786-233">If a user repurchases a subscription after reaching a terminal state, a new subscription ID will be created.</span></span></li><li><span data-ttu-id="0b786-234">サブスクリプションの ID は、個々のサブスクリプションで任意の操作を実行するために使ってください。</span><span class="sxs-lookup"><span data-stu-id="0b786-234">The ID of a subscription should be used to execute any operation on an individual subscription.</span></span></li><li><span data-ttu-id="0b786-235">ユーザーがサブスクリプションをキャンセルまたは中止した後に再購入した場合、ユーザーの結果を照会すると、終了状態の古いサブスクリプション ID を含むエントリとアクティブ状態の新しいサブスクリプション ID を含むエントリの 2 つが返されます。</span><span class="sxs-lookup"><span data-stu-id="0b786-235">When a user repurchases a subscription after cancelling or discontinuing it, if you query the results for the user you will get two entries: one with the old subscription ID in a terminal state, and one with the new subscription ID in an active state.</span></span></li><li><span data-ttu-id="0b786-236">必ず、recurrenceState と expirationTime の両方を確認することをお勧めします。recurrenceState の更新は数分 (場合によって数時間) 遅れることがあるためです。</span><span class="sxs-lookup"><span data-stu-id="0b786-236">It's always a good practice to check both recurrenceState and expirationTime, since updates to recurrenceState can potentially be delayed by a few minutes (or occasionally hours).</span></span>       |
| <span data-ttu-id="0b786-237">cancellationDate</span><span class="sxs-lookup"><span data-stu-id="0b786-237">cancellationDate</span></span> | <span data-ttu-id="0b786-238">string</span><span class="sxs-lookup"><span data-stu-id="0b786-238">string</span></span>   |  <span data-ttu-id="0b786-239">ユーザーのサブスクリプションがキャンセルされた日時 (ISO 8601 形式)。</span><span class="sxs-lookup"><span data-stu-id="0b786-239">The date and time the user's subscription was cancelled, in ISO 8601 format.</span></span>     |



## <a name="related-topics"></a><span data-ttu-id="0b786-240">関連トピック</span><span class="sxs-lookup"><span data-stu-id="0b786-240">Related topics</span></span>


* [<span data-ttu-id="0b786-241">サービスから製品の権利を管理する</span><span class="sxs-lookup"><span data-stu-id="0b786-241">Manage product entitlements from a service</span></span>](view-and-grant-products-from-a-service.md)
* [<span data-ttu-id="0b786-242">ユーザーのサブスクリプションを取得する</span><span class="sxs-lookup"><span data-stu-id="0b786-242">Get subscriptions for a user</span></span>](get-subscriptions-for-a-user.md)
* [<span data-ttu-id="0b786-243">製品の照会</span><span class="sxs-lookup"><span data-stu-id="0b786-243">Query for products</span></span>](query-for-products.md)
* [<span data-ttu-id="0b786-244">コンシューマブルな製品をフルフィルメント完了として報告する</span><span class="sxs-lookup"><span data-stu-id="0b786-244">Report consumable products as fulfilled</span></span>](report-consumable-products-as-fulfilled.md)
* [<span data-ttu-id="0b786-245">Windows ストア ID キーの更新</span><span class="sxs-lookup"><span data-stu-id="0b786-245">Renew a Windows Store ID key</span></span>](renew-a-windows-store-id-key.md)