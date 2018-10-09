---
title: C++ API のエラー処理
author: KevinAsgari
description: C++ API を使って Xbox Live サービス呼び出しを行ったときのエラーを処理する方法について説明します。
ms.assetid: 10b47e68-8b1f-4023-96a4-404f3f6a9850
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: xbox live, xbox, ゲーム, uwp, windows 10, xbox one, エラー処理
ms.localizationpriority: medium
ms.openlocfilehash: 9863ac224e04d48265a05fe56ed484db5dcc3cd8
ms.sourcegitcommit: 49aab071aa2bd88f1c165438ee7e5c854b3e4f61
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/09/2018
ms.locfileid: "4469513"
---
# <a name="c-api-error-handling"></a><span data-ttu-id="fda1c-104">C++ API のエラー処理</span><span class="sxs-lookup"><span data-stu-id="fda1c-104">C++ API error handling</span></span>

<span data-ttu-id="fda1c-105">C++ API のほとんどの呼び出しは、例外をスローするのではなく、必要に応じて xbox_live_result<payload_type> を返します。</span><span class="sxs-lookup"><span data-stu-id="fda1c-105">In the C++ API, rather than throwing exceptions, most calls will return xbox_live_result<payload_type> as appropriate.</span></span>

## <a name="xboxliveresult-structure"></a><span data-ttu-id="fda1c-106">xbox_live_result structure</span><span class="sxs-lookup"><span data-stu-id="fda1c-106">xbox_live_result structure</span></span>
<span data-ttu-id="fda1c-107">xbox_live_result には 3 つの項目があります。</span><span class="sxs-lookup"><span data-stu-id="fda1c-107">xbox_live_result has 3 items:</span></span>
1. <span data-ttu-id="fda1c-108">操作によって返されるエラー</span><span class="sxs-lookup"><span data-stu-id="fda1c-108">The error returned by the operation,</span></span>
2. <span data-ttu-id="fda1c-109">デバッグに使用する具体的なエラー メッセージ</span><span class="sxs-lookup"><span data-stu-id="fda1c-109">Specific error message used for debugging purposes and</span></span>
3. <span data-ttu-id="fda1c-110">結果のペイロード (エラーがあった場合、空の可能性があります)</span><span class="sxs-lookup"><span data-stu-id="fda1c-110">The payload of the result (can be empty if there was an error)"</span></span>

<span data-ttu-id="fda1c-111">xbox_live_result およびエラー コードの詳細については、Xbox Live のドキュメントを参照してください。</span><span class="sxs-lookup"><span data-stu-id="fda1c-111">You can get more information on xbox_live_result as well as what the error codes are in Xbox Live documentation.</span></span>

<span data-ttu-id="fda1c-112">その構造は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="fda1c-112">The structure is as follows:</span></span>

```cpp
template<typename T>
class xbox_live_result
{
    const std::error_code& err();
    const std::string& err_message();
    T& payload();
};
```

<span data-ttu-id="fda1c-113">**err** - エラーを返します。</span><span class="sxs-lookup"><span data-stu-id="fda1c-113">**err** - Returns the error.</span></span>  <span data-ttu-id="fda1c-114">エラーがない場合は NULL 参照です。</span><span class="sxs-lookup"><span data-stu-id="fda1c-114">Will be a NULL reference with no error.</span></span>  <span data-ttu-id="fda1c-115">これは C++ STL エラーと同様に動作し、value() を呼び出すことによってプリミティブ値を取得できます。</span><span class="sxs-lookup"><span data-stu-id="fda1c-115">This behaves as the C++ STL error does in that you can get the primitive value by calling value().</span></span>  <span data-ttu-id="fda1c-116">message() を呼び出すと文字列表現を取得できます。</span><span class="sxs-lookup"><span data-stu-id="fda1c-116">Calling message() will get you a string representation.</span></span>  <span data-ttu-id="fda1c-117">したがって、エラー コードが "Invalid Argument" という意味の場合、```err().message()``` は "Invalid Argument" というテキストになります。</span><span class="sxs-lookup"><span data-stu-id="fda1c-117">So if the error code means "Invalid Argument", then ```err().message()``` would be the text "Invalid Argument".</span></span>

<span data-ttu-id="fda1c-118">**err_message** - エラーの詳細です。</span><span class="sxs-lookup"><span data-stu-id="fda1c-118">**err_message** - Elaborates on the error.</span></span>  <span data-ttu-id="fda1c-119">たとえば、**err** が "Invalid Argument" の場合、**err_message** では無効な引数が詳しく示されます。</span><span class="sxs-lookup"><span data-stu-id="fda1c-119">For example if **err** is "Invalid Argument", then **err_message** would elaborate on which argument is invalid.</span></span>

<span data-ttu-id="fda1c-120">**payload** - 対象の項目を返します。</span><span class="sxs-lookup"><span data-stu-id="fda1c-120">**payload** - Return the item of interest.</span></span>  <span data-ttu-id="fda1c-121">たとえば、get_achievement の呼び出しから取得する ```xbox_live_result<achievement>``` について考えます。</span><span class="sxs-lookup"><span data-stu-id="fda1c-121">For example consider ```xbox_live_result<achievement>``` which you might get from calling get_achievement.</span></span>  <span data-ttu-id="fda1c-122">この例では、ペイロードは実績自体になります (エラーがない場合)。</span><span class="sxs-lookup"><span data-stu-id="fda1c-122">In this example, the payload would be the achievement itself (if no error is present).</span></span>

## <a name="example"></a><span data-ttu-id="fda1c-123">例</span><span class="sxs-lookup"><span data-stu-id="fda1c-123">Example</span></span>

```cpp
// Function which returns an xbox_live_result
xbox_live_result<std::shared_ptr<title_presence_change_subscription>> presenceChangeSubscriptionResult =
xbox::services::presence::subscribe_to_title_presence_change(
    xboxUserId,
    titleId
    );

printf("Error value %d, string %s", achievementResult.err().value(), achievementResult.err().message());

// Would output:
// "0 Success" if successful
// "401 Unauthorized" if auth issue

if (!achievementResult.err())
{
  // Do things on success.  Payload will be populated if applicable.
  std::shared_ptr<title_presence_change_subscription> presenceChangeSubscription = presenceChangeSubscriptionResult->payload();

  // ...
}
else if (achievement.err() == xboxlive_error_code::http_status_403_forbidden)
{
  // Special handling for 403 errors
}
else if (achievementResult.err() == xbox_live_error_condition::auth)
{
  // Handle broad auth failures.  See below section for more info on xbox_live_error_condition
}

```

## <a name="using-xboxliveerrorcondition-to-test-against-broad-error-categories"></a><span data-ttu-id="fda1c-124">広範なエラー カテゴリーテストするための xbox_live_error_condition の使用</span><span class="sxs-lookup"><span data-stu-id="fda1c-124">Using xbox_live_error_condition to test against broad error categories</span></span>
<span data-ttu-id="fda1c-125">上の例では、403 エラーおよび ```xbox_live_error_condition::auth``` などについてのエラー コードをテストしています。</span><span class="sxs-lookup"><span data-stu-id="fda1c-125">In the above example, we test the error code against 403 errors, as well as something called ```xbox_live_error_condition::auth```.</span></span>

 <span data-ttu-id="fda1c-126">xbox_live_result err() 関数を使用すると、エラー コードを個別にテストできます。</span><span class="sxs-lookup"><span data-stu-id="fda1c-126">When using xbox_live_result err() function, one can test against error codes individually.</span></span>  <span data-ttu-id="fda1c-127">たとえば、400 クラスのエラーの場合、以下に対する個別のテストと制御フローがあります。</span><span class="sxs-lookup"><span data-stu-id="fda1c-127">For example, for 400 class errors you could have individual testing and control flow for:</span></span>

* <span data-ttu-id="fda1c-128">xbox_live_error_code::http_status_400_bad_request</span><span class="sxs-lookup"><span data-stu-id="fda1c-128">xbox_live_error_code::http_status_400_bad_request</span></span>
* <span data-ttu-id="fda1c-129">xbox_live_error_code::http_status_401_unauthorized</span><span class="sxs-lookup"><span data-stu-id="fda1c-129">xbox_live_error_code::http_status_401_unauthorized</span></span>
* <span data-ttu-id="fda1c-130">xbox_live_error_code::http_status_403_forbidden</span><span class="sxs-lookup"><span data-stu-id="fda1c-130">xbox_live_error_code::http_status_403_forbidden</span></span>
* <span data-ttu-id="fda1c-131">など</span><span class="sxs-lookup"><span data-stu-id="fda1c-131">etc</span></span>

<span data-ttu-id="fda1c-132">ただし、このような方法ではなく、エラーのクラス全体に対してテストする方が効率的です。</span><span class="sxs-lookup"><span data-stu-id="fda1c-132">But typically this is not what you want to do and you want to test against a class of errors as one.</span></span>  <span data-ttu-id="fda1c-133">そこで、```xbox_live_error_condition``` クラスで使用できる列挙値を使用してエラーのクラスに対してテストします。</span><span class="sxs-lookup"><span data-stu-id="fda1c-133">So you can test against a class of errors using the enums available in the ```xbox_live_error_condition``` class.</span></span>  <span data-ttu-id="fda1c-134">多数のエラー コードに対するテストを自動化する等値演算子のオーバーロードが実装されています。</span><span class="sxs-lookup"><span data-stu-id="fda1c-134">We implement an overload for the equality operator which will automate testing against many error codes.</span></span>  <span data-ttu-id="fda1c-135">```auth``` に加えて、```rta``` and ```http``` などのカテゴリーがあります。</span><span class="sxs-lookup"><span data-stu-id="fda1c-135">In addition to ```auth```, there are categories like ```rta``` and ```http```.</span></span>  <span data-ttu-id="fda1c-136">完全なリストは、*errors.h* または *xblsdk_cpp.chm* で確認できます。</span><span class="sxs-lookup"><span data-stu-id="fda1c-136">The full list can be found in *errors.h* or in *xblsdk_cpp.chm*.</span></span>

<span data-ttu-id="fda1c-137">これに関して説明している動画、および C++ Xbox Service API のその他の機能については、[Xfest 2015 のビデオ](https://developer.xboxlive.com/en-us/platform/documentlibrary/events/Pages/Xfest2015.aspx)の「*XSAPI:C++, No Exceptions!*」にある Xfest の講演をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="fda1c-137">For a video that covers this, and some other features of the C++ Xbox Service API, please check out our XFest talk in [Xfest 2015 Videos](https://developer.xboxlive.com/en-us/platform/documentlibrary/events/Pages/Xfest2015.aspx) under *XSAPI: C++, No Exceptions!*</span></span>
