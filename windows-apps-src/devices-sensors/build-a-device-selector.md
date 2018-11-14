---
author: muhsinking
ms.assetid: D06AA3F5-CED6-446E-94E8-713D98B13CAA
title: デバイス セレクターのビルド
description: デバイス セレクターを作成すると、デバイスを列挙するときに、検索するデバイスを絞り込むことができるようになります。
ms.author: mukin
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 036ea8b7d9797112dca9b6594e9bc1e33e923588
ms.sourcegitcommit: bdc40b08cbcd46fc379feeda3c63204290e055af
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/08/2018
ms.locfileid: "6161804"
---
# <a name="build-a-device-selector"></a><span data-ttu-id="85195-104">デバイス セレクターのビルド</span><span class="sxs-lookup"><span data-stu-id="85195-104">Build a device selector</span></span>



**<span data-ttu-id="85195-105">重要な API</span><span class="sxs-lookup"><span data-stu-id="85195-105">Important APIs</span></span>**

- [**<span data-ttu-id="85195-106">Windows.Devices.Enumeration</span><span class="sxs-lookup"><span data-stu-id="85195-106">Windows.Devices.Enumeration</span></span>**](https://docs.microsoft.com/en-us/uwp/api/Windows.Devices.Enumeration)

<span data-ttu-id="85195-107">デバイス セレクターを作成すると、デバイスを列挙するときに、検索するデバイスを絞り込むことができるようになります。</span><span class="sxs-lookup"><span data-stu-id="85195-107">Building a device selector will enable you to limit the devices you are searching through when enumerating devices.</span></span> <span data-ttu-id="85195-108">これにより、関連する結果のみを取得することができ、システムのパフォーマンスも向上します。</span><span class="sxs-lookup"><span data-stu-id="85195-108">This will enable you to only get relevant results and will also improve the performance of the system.</span></span> <span data-ttu-id="85195-109">多くのシナリオでは、デバイス スタックからデバイス セレクターを取得します。</span><span class="sxs-lookup"><span data-stu-id="85195-109">In most scenarios you get a device selector from a device stack.</span></span> <span data-ttu-id="85195-110">たとえば、USB 経由で検出したデバイスに [**GetDeviceSelector**](https://msdn.microsoft.com/library/windows/apps/Dn264015) を使うとします。</span><span class="sxs-lookup"><span data-stu-id="85195-110">For example, you might use [**GetDeviceSelector**](https://msdn.microsoft.com/library/windows/apps/Dn264015) for devices discovered over USB.</span></span> <span data-ttu-id="85195-111">これらのデバイス セレクターは高度なクエリ構文 (AQS) 文字列を返します。</span><span class="sxs-lookup"><span data-stu-id="85195-111">These device selectors return an Advanced Query Syntax (AQS) string.</span></span> <span data-ttu-id="85195-112">AQS 形式を初めて使う場合は、「[プログラムでの高度なクエリ構文の使用](https://msdn.microsoft.com/library/windows/desktop/Bb266512)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="85195-112">If you are not familiar with the AQS format, you can read more at [Using Advanced Query Syntax Programmatically](https://msdn.microsoft.com/library/windows/desktop/Bb266512).</span></span>

## <a name="building-the-filter-string"></a><span data-ttu-id="85195-113">フィルター文字列の作成</span><span class="sxs-lookup"><span data-stu-id="85195-113">Building the filter string</span></span>

<span data-ttu-id="85195-114">デバイスを列挙する必要があるにもかかわらず、提供されたデバイス セレクターを目的のシナリオで利用できないことがあります。</span><span class="sxs-lookup"><span data-stu-id="85195-114">There are some cases where you need to enumerate devices and a provided device selector is not available for your scenario.</span></span> <span data-ttu-id="85195-115">デバイス セレクターは、次の情報が含まれる AQS フィルター文字列です。</span><span class="sxs-lookup"><span data-stu-id="85195-115">A device selector is an AQS filter string that contains the following information.</span></span> <span data-ttu-id="85195-116">フィルター文字列を作成する前に、列挙するデバイスに関して、いくつかの重要な情報を知っておく必要があります。</span><span class="sxs-lookup"><span data-stu-id="85195-116">Before creating a filter string, you need to know some key pieces of information about the devices you want to enumerate.</span></span>

-   <span data-ttu-id="85195-117">目的のデバイスの [**DeviceInformationKind**](https://msdn.microsoft.com/library/windows/apps/Dn948991)。</span><span class="sxs-lookup"><span data-stu-id="85195-117">The [**DeviceInformationKind**](https://msdn.microsoft.com/library/windows/apps/Dn948991) of the devices you are interested in.</span></span> <span data-ttu-id="85195-118">デバイスの列挙への **DeviceInformationKind** の影響について詳しくは、「[デバイスの列挙](enumerate-devices.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="85195-118">For more information about how **DeviceInformationKind** impacts enumerating devices, see [Enumerate devices](enumerate-devices.md).</span></span>
-   <span data-ttu-id="85195-119">このトピックで説明されている、AQS フィルター文字列を作成する方法。</span><span class="sxs-lookup"><span data-stu-id="85195-119">How to build an AQS filter string, which is explained in this topic.</span></span>
-   <span data-ttu-id="85195-120">目的のプロパティ。</span><span class="sxs-lookup"><span data-stu-id="85195-120">The properties you are interested in.</span></span> <span data-ttu-id="85195-121">使用可能なプロパティは [**DeviceInformationKind**](https://msdn.microsoft.com/library/windows/apps/Dn948991) によって異なります。</span><span class="sxs-lookup"><span data-stu-id="85195-121">The available properties will depend upon the [**DeviceInformationKind**](https://msdn.microsoft.com/library/windows/apps/Dn948991).</span></span> <span data-ttu-id="85195-122">詳しくは、「[デバイス情報プロパティ](device-information-properties.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="85195-122">See [Device information properties](device-information-properties.md) for more information.</span></span>
-   <span data-ttu-id="85195-123">照会で経由するプロトコル。</span><span class="sxs-lookup"><span data-stu-id="85195-123">The protocols you are querying over.</span></span> <span data-ttu-id="85195-124">ワイヤレスまたはワイヤード ネットワーク経由でデバイスを検索する場合にのみ必要です。</span><span class="sxs-lookup"><span data-stu-id="85195-124">This is only needed if you are searching for devices over a wireless or wired network.</span></span> <span data-ttu-id="85195-125">そのための方法について詳しくは、「[ネットワーク経由でデバイスを列挙する](enumerate-devices-over-a-network.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="85195-125">For more information about doing this, see [Enumerate devices over a network](enumerate-devices-over-a-network.md).</span></span>

<span data-ttu-id="85195-126">[**Windows.Devices.Enumeration**](https://msdn.microsoft.com/library/windows/apps/BR225459) API を使うときは、多くの場合、デバイス セレクターを目的のデバイスの種類と組み合わせます。</span><span class="sxs-lookup"><span data-stu-id="85195-126">When using the [**Windows.Devices.Enumeration**](https://msdn.microsoft.com/library/windows/apps/BR225459) APIs, you frequently combine the device selector with the device kind that you are interested in.</span></span> <span data-ttu-id="85195-127">利用可能なデバイスの種類の一覧は、[**DeviceInformationKind**](https://msdn.microsoft.com/library/windows/apps/Dn948991) 列挙値で定義されています。</span><span class="sxs-lookup"><span data-stu-id="85195-127">The available list of device kinds is defined by the [**DeviceInformationKind**](https://msdn.microsoft.com/library/windows/apps/Dn948991) enumeration.</span></span> <span data-ttu-id="85195-128">この組み合わせは、利用可能なデバイスを目的のデバイスの種類に限定するために役立ちます。</span><span class="sxs-lookup"><span data-stu-id="85195-128">This combination of factors helps you to limit the devices that are available to the ones that you are interested in.</span></span> <span data-ttu-id="85195-129">**DeviceInformationKind** を指定しない場合、つまり、使うメソッドに **DeviceInformationKind** パラメーターを渡さない場合、既定の種類は **DeviceInterface** です。</span><span class="sxs-lookup"><span data-stu-id="85195-129">If you do not specify the **DeviceInformationKind**, or the method you are using does not provide a **DeviceInformationKind** parameter, the default kind is **DeviceInterface**.</span></span>

<span data-ttu-id="85195-130">[**Windows.Devices.Enumeration**](https://msdn.microsoft.com/library/windows/apps/BR225459) API では、AQS の標準的な構文が使われますが、一部の演算子はサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="85195-130">The [**Windows.Devices.Enumeration**](https://msdn.microsoft.com/library/windows/apps/BR225459) APIs use canonical AQS syntax, but not all of the operators are supported.</span></span> <span data-ttu-id="85195-131">フィルター文字列の作成に使えるプロパティの一覧については、「[デバイス情報プロパティ](device-information-properties.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="85195-131">For a list of properties that are available when you are constructing your filter string, see [Device information properties](device-information-properties.md).</span></span>

<span data-ttu-id="85195-132">**注意:** カスタム プロパティを使用して定義されている、 `{GUID} PID` 、AQS フィルター文字列を構築するときは、形式を使用することはできません。</span><span class="sxs-lookup"><span data-stu-id="85195-132">**Caution**Custom properties that are defined using the `{GUID} PID` format cannot be used when constructing your AQS filter string.</span></span> <span data-ttu-id="85195-133">これは、プロパティの型が一般的な既知のプロパティ名から派生しているためです。</span><span class="sxs-lookup"><span data-stu-id="85195-133">This is because the property type is derived from the well-known property name.</span></span>

 

<span data-ttu-id="85195-134">次の表は、AQS 演算子とそれがサポートするパラメーターの型の一覧です。</span><span class="sxs-lookup"><span data-stu-id="85195-134">The following table lists the AQS operators and what types of parameters they support.</span></span>

| <span data-ttu-id="85195-135">演算子</span><span class="sxs-lookup"><span data-stu-id="85195-135">Operator</span></span>                       | <span data-ttu-id="85195-136">サポートされる型</span><span class="sxs-lookup"><span data-stu-id="85195-136">Supported types</span></span>                                                             |
|--------------------------------|-----------------------------------------------------------------------------|
| **<span data-ttu-id="85195-137">COP\_EQUAL</span><span class="sxs-lookup"><span data-stu-id="85195-137">COP\_EQUAL</span></span>**                 | <span data-ttu-id="85195-138">文字列、ブール値、GUID、UInt16、UInt32</span><span class="sxs-lookup"><span data-stu-id="85195-138">String, boolean, GUID, UInt16, UInt32</span></span>                                       |
| **<span data-ttu-id="85195-139">COP\_NOTEQUAL</span><span class="sxs-lookup"><span data-stu-id="85195-139">COP\_NOTEQUAL</span></span>**              | <span data-ttu-id="85195-140">文字列、ブール値、GUID、UInt16、UInt32</span><span class="sxs-lookup"><span data-stu-id="85195-140">String, boolean, GUID, UInt16, UInt32</span></span>                                       |
| **<span data-ttu-id="85195-141">COP\_LESSTHAN</span><span class="sxs-lookup"><span data-stu-id="85195-141">COP\_LESSTHAN</span></span>**              | <span data-ttu-id="85195-142">UInt16、UInt32</span><span class="sxs-lookup"><span data-stu-id="85195-142">UInt16, UInt32</span></span>                                                              |
| **<span data-ttu-id="85195-143">COP\_GREATERTHAN</span><span class="sxs-lookup"><span data-stu-id="85195-143">COP\_GREATERTHAN</span></span>**           | <span data-ttu-id="85195-144">UInt16、UInt32</span><span class="sxs-lookup"><span data-stu-id="85195-144">UInt16, UInt32</span></span>                                                              |
| **<span data-ttu-id="85195-145">COP\_LESSTHANOREQUAL</span><span class="sxs-lookup"><span data-stu-id="85195-145">COP\_LESSTHANOREQUAL</span></span>**       | <span data-ttu-id="85195-146">UInt16、UInt32</span><span class="sxs-lookup"><span data-stu-id="85195-146">UInt16, UInt32</span></span>                                                              |
| **<span data-ttu-id="85195-147">COP\_GREATERTHANOREQUAL</span><span class="sxs-lookup"><span data-stu-id="85195-147">COP\_GREATERTHANOREQUAL</span></span>**    | <span data-ttu-id="85195-148">UInt16、UInt32</span><span class="sxs-lookup"><span data-stu-id="85195-148">UInt16, UInt32</span></span>                                                              |
| **<span data-ttu-id="85195-149">COP\_VALUE\_CONTAINS</span><span class="sxs-lookup"><span data-stu-id="85195-149">COP\_VALUE\_CONTAINS</span></span>**       | <span data-ttu-id="85195-150">文字列、文字列配列、ブール値配列、GUID 配列、UInt16 配列、UInt32 配列</span><span class="sxs-lookup"><span data-stu-id="85195-150">String, string array, boolean array, GUID array, UInt16 array, UInt32 array</span></span> |
| **<span data-ttu-id="85195-151">COP\_VALUE\_NOTCONTAINS</span><span class="sxs-lookup"><span data-stu-id="85195-151">COP\_VALUE\_NOTCONTAINS</span></span>**    | <span data-ttu-id="85195-152">文字列、文字列配列、ブール値配列、GUID 配列、UInt16 配列、UInt32 配列</span><span class="sxs-lookup"><span data-stu-id="85195-152">String, string array, boolean array, GUID array, UInt16 array, UInt32 array</span></span> |
| **<span data-ttu-id="85195-153">COP\_VALUE\_STARTSWITH</span><span class="sxs-lookup"><span data-stu-id="85195-153">COP\_VALUE\_STARTSWITH</span></span>**     | <span data-ttu-id="85195-154">文字列</span><span class="sxs-lookup"><span data-stu-id="85195-154">String</span></span>                                                                      |
| **<span data-ttu-id="85195-155">COP\_VALUE\_ENDSWITH</span><span class="sxs-lookup"><span data-stu-id="85195-155">COP\_VALUE\_ENDSWITH</span></span>**       | <span data-ttu-id="85195-156">文字列</span><span class="sxs-lookup"><span data-stu-id="85195-156">String</span></span>                                                                      |
| **<span data-ttu-id="85195-157">COP\_DOSWILDCARDS</span><span class="sxs-lookup"><span data-stu-id="85195-157">COP\_DOSWILDCARDS</span></span>**          | <span data-ttu-id="85195-158">サポートされていません</span><span class="sxs-lookup"><span data-stu-id="85195-158">Not supported</span></span>                                                               |
| **<span data-ttu-id="85195-159">COP\_WORD\_EQUAL</span><span class="sxs-lookup"><span data-stu-id="85195-159">COP\_WORD\_EQUAL</span></span>**           | <span data-ttu-id="85195-160">サポートされていません</span><span class="sxs-lookup"><span data-stu-id="85195-160">Not supported</span></span>                                                               |
| **<span data-ttu-id="85195-161">COP\_WORD\_STARTSWITH</span><span class="sxs-lookup"><span data-stu-id="85195-161">COP\_WORD\_STARTSWITH</span></span>**      | <span data-ttu-id="85195-162">サポートされていません</span><span class="sxs-lookup"><span data-stu-id="85195-162">Not supported</span></span>                                                               |
| **<span data-ttu-id="85195-163">COP\_APPLICATION\_SPECIFIC</span><span class="sxs-lookup"><span data-stu-id="85195-163">COP\_APPLICATION\_SPECIFIC</span></span>** | <span data-ttu-id="85195-164">サポートされていません</span><span class="sxs-lookup"><span data-stu-id="85195-164">Not supported</span></span>                                                               |


> <span data-ttu-id="85195-165">**ヒント:** **cop \_notequal**または**COP\_NOTEQUAL** **NULL**を指定することができます。</span><span class="sxs-lookup"><span data-stu-id="85195-165">**Tip**You can specify **NULL** for **COP\_EQUAL** or **COP\_NOTEQUAL**.</span></span> <span data-ttu-id="85195-166">これは空のプロパティに変換されます。つまり、値は存在しません。</span><span class="sxs-lookup"><span data-stu-id="85195-166">This translates to a property with no value, or that the value does not exist.</span></span> <span data-ttu-id="85195-167">AQS では、空のかっこ \[\] を使って **NULL** を指定できます。</span><span class="sxs-lookup"><span data-stu-id="85195-167">In AQS, you specify **NULL** by using empty brackets \[\].</span></span>

> <span data-ttu-id="85195-168">**重要な**文字列と文字列の配列で異なる動作を**cop \_value\_contains**と**\_value\_notcontains**演算子を使用する場合。</span><span class="sxs-lookup"><span data-stu-id="85195-168">**Important**When using the **COP\_VALUE\_CONTAINS** and **COP\_VALUE\_NOTCONTAINS** operators, they behave differently with strings and string arrays.</span></span> <span data-ttu-id="85195-169">文字列の場合、大文字と小文字を区別する検索が実行され、デバイスに部分文字列として指定された文字列が含まれているかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="85195-169">In the case of a string, the system will perform a case-insensitive search to see if the device contains the indicated string as a substring.</span></span> <span data-ttu-id="85195-170">文字列配列の場合、部分文字列は検索されません。</span><span class="sxs-lookup"><span data-stu-id="85195-170">In the case of a string array, substrings are not searched.</span></span> <span data-ttu-id="85195-171">文字列配列を使って、配列を検索し、指定された文字列全体が含まれているかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="85195-171">With the string array, the array is searched to see if it contains the entire specified string.</span></span> <span data-ttu-id="85195-172">配列内の要素に部分文字列が含まれているかどうかを確認するために、文字列配列を検索することはできません。</span><span class="sxs-lookup"><span data-stu-id="85195-172">It is not possible to search a string array to see if the elements in the array contain a substring.</span></span>

<span data-ttu-id="85195-173">1 つの AQS フィルター文字列により結果を適切に絞り込むことができない場合は、受け取った結果をさらにフィルター処理できます。</span><span class="sxs-lookup"><span data-stu-id="85195-173">If you cannot create a single AQS filter string that will scope your results appropriately, you can filter your results after you receive them.</span></span> <span data-ttu-id="85195-174">ただしその場合は、最初の AQS フィルター文字列によりできる限り結果を絞り込んでから、[**Windows.Devices.Enumeration**](https://msdn.microsoft.com/library/windows/apps/BR225459) API に渡すことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="85195-174">However, if you choose to do this, we recommend limiting the results from your initial AQS filter string as much as possible when you provide it to the [**Windows.Devices.Enumeration**](https://msdn.microsoft.com/library/windows/apps/BR225459) APIs.</span></span> <span data-ttu-id="85195-175">これにより、アプリのパフォーマンスを向上させることができます。</span><span class="sxs-lookup"><span data-stu-id="85195-175">This will help improve the performance of your application.</span></span>

## <a name="aqs-string-examples"></a><span data-ttu-id="85195-176">AQS 文字列の例</span><span class="sxs-lookup"><span data-stu-id="85195-176">AQS string examples</span></span>

<span data-ttu-id="85195-177">ここで示している例では、AQS 構文を使って、列挙するデバイスを制限する方法を説明しています。</span><span class="sxs-lookup"><span data-stu-id="85195-177">The following examples demonstrate how the AQS syntax can be used to limit the devices you want to enumerate.</span></span> <span data-ttu-id="85195-178">以下のフィルター文字列はすべて、[**DeviceInformationKind**](https://msdn.microsoft.com/library/windows/apps/Dn948991) とペアリングされており、完全なフィルターを作成できます。</span><span class="sxs-lookup"><span data-stu-id="85195-178">All of these filter strings are paired up with a [**DeviceInformationKind**](https://msdn.microsoft.com/library/windows/apps/Dn948991) to create a complete filter.</span></span> <span data-ttu-id="85195-179">どの種類も指定しない場合、既定の種類は **DeviceInterface** になります。</span><span class="sxs-lookup"><span data-stu-id="85195-179">If no kind is specified, remember that the default kind is **DeviceInterface**.</span></span>

<span data-ttu-id="85195-180">このフィルターを **DeviceInterface** の [**DeviceInformationKind**](https://msdn.microsoft.com/library/windows/apps/Dn948991) とペアリングすると、オーディオ キャプチャ インターフェイス クラスを含むオブジェクトと、現在有効なオブジェクトがすべて列挙されます。</span><span class="sxs-lookup"><span data-stu-id="85195-180">When this filter is paired with a [**DeviceInformationKind**](https://msdn.microsoft.com/library/windows/apps/Dn948991) of **DeviceInterface**, it enumerates all objects that contain the Audio Capture interface class and that are currently enabled.</span></span> <span data-ttu-id="85195-181">\*\*=
              \*\* は **COP\_EQUALS** に変換されます。</span><span class="sxs-lookup"><span data-stu-id="85195-181">**=** translates to **COP\_EQUALS**.</span></span>

``` syntax
System.Devices.InterfaceClassGuid:="{2eef81be-33fa-4800-9670-1cd474972c3f}" AND
System.Devices.InterfaceEnabled:=System.StructuredQueryType.Boolean#True
```

<span data-ttu-id="85195-182">このフィルターを **Device** の [**DeviceInformationKind**](https://msdn.microsoft.com/library/windows/apps/Dn948991) とペアリングすると、GenCdRom のハードウェア ID を 1 つ以上持つオブジェクトがすべて列挙されます。</span><span class="sxs-lookup"><span data-stu-id="85195-182">When this filter is paired with a [**DeviceInformationKind**](https://msdn.microsoft.com/library/windows/apps/Dn948991) of **Device**, it enumerates all objects that have at least one hardware id of GenCdRom.</span></span> <span data-ttu-id="85195-183">\*\*~~
              \*\* は **COP\_VALUE\_CONTAINS** に変換されます。</span><span class="sxs-lookup"><span data-stu-id="85195-183">**~~** translates to **COP\_VALUE\_CONTAINS**.</span></span>

``` syntax
System.Devices.HardwareIds:~~"GenCdRom"
```

<span data-ttu-id="85195-184">このフィルターを **DeviceContainer** の [**DeviceInformationKind**](https://msdn.microsoft.com/library/windows/apps/Dn948991) とペアリングすると、部分文字列として Microsoft を含むモデル名を持つオブジェクトがすべて列挙されます。</span><span class="sxs-lookup"><span data-stu-id="85195-184">When this filter is paired with a [**DeviceInformationKind**](https://msdn.microsoft.com/library/windows/apps/Dn948991) of **DeviceContainer**, it enumerates all objects that have a model name containing the substring Microsoft.</span></span> <span data-ttu-id="85195-185">\*\*~~
              \*\* は **COP\_VALUE\_CONTAINS** に変換されます。</span><span class="sxs-lookup"><span data-stu-id="85195-185">**~~** translates to **COP\_VALUE\_CONTAINS**.</span></span>

``` syntax
System.Devices.ModelName:~~"Microsoft"
```

<span data-ttu-id="85195-186">このフィルターを **DeviceInterface** の [**DeviceInformationKind**](https://msdn.microsoft.com/library/windows/apps/Dn948991) とペアリングすると、部分文字列の Microsoft から始まる名前を持つオブジェクトがすべて列挙されます。</span><span class="sxs-lookup"><span data-stu-id="85195-186">When this filter is paired with a [**DeviceInformationKind**](https://msdn.microsoft.com/library/windows/apps/Dn948991) of **DeviceInterface**, it enumerates all objects that have a name starting with the substring Microsoft.</span></span> <span data-ttu-id="85195-187">\*\*~&lt;
              \*\* は **COP\_STARTSWITH** に変換されます。</span><span class="sxs-lookup"><span data-stu-id="85195-187">**~&lt;** translates to **COP\_STARTSWITH**.</span></span>

``` syntax
System.ItemNameDisplay:~<"Microsoft"
```

<span data-ttu-id="85195-188">このフィルターを **Device** の [**DeviceInformationKind**](https://msdn.microsoft.com/library/windows/apps/Dn948991) とペアリングすると、**System.Devices.IpAddress** プロパティ セットを持つオブジェクトがすべて列挙されます。</span><span class="sxs-lookup"><span data-stu-id="85195-188">When this filter is paired with a [**DeviceInformationKind**](https://msdn.microsoft.com/library/windows/apps/Dn948991) of **Device**, it enumerates all objects that have a **System.Devices.IpAddress** property set.</span></span> <span data-ttu-id="85195-189">**&lt;&gt;\[\]** は、**NULL** 値を組み合わせた **COP\_NOTEQUALS** に変換されます。</span><span class="sxs-lookup"><span data-stu-id="85195-189">**&lt;&gt;\[\]** translates to **COP\_NOTEQUALS** combined with a **NULL** value.</span></span>

``` syntax
System.Devices.IpAddress:<>[]
```

<span data-ttu-id="85195-190">このフィルターを **Device** の [**DeviceInformationKind**](https://msdn.microsoft.com/library/windows/apps/Dn948991) とペアリングすると、**System.Devices.IpAddress** プロパティ セットを持たないオブジェクトがすべて列挙されます。</span><span class="sxs-lookup"><span data-stu-id="85195-190">When this filter is paired with a [**DeviceInformationKind**](https://msdn.microsoft.com/library/windows/apps/Dn948991) of **Device**, it enumerates all objects that do not have a **System.Devices.IpAddress** property set.</span></span> <span data-ttu-id="85195-191">**=\[\]** は、**NULL** 値を組み合わせた **COP\_EQUALS** に変換されます。</span><span class="sxs-lookup"><span data-stu-id="85195-191">**=\[\]** translates to **COP\_EQUALS** combined with a **NULL** value.</span></span>

``` syntax
System.Devices.IpAddress:=[]
```

 

 
