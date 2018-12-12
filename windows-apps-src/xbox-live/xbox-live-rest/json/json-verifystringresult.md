---
title: VerifyStringResult (JSON)
assetID: 272c688e-179e-c7e9-086b-e76d0d4bcb57
permalink: en-us/docs/xboxlive/rest/json-verifystringresult.html
description: " VerifyStringResult (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: b01793222be80efccdca1f24f5226a2e9ff78064
ms.sourcegitcommit: 49d58bc66c1c9f2a4f81473bcb25af79e2b1088d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8927424"
---
# <a name="verifystringresult-json"></a><span data-ttu-id="7babf-104">VerifyStringResult (JSON)</span><span class="sxs-lookup"><span data-stu-id="7babf-104">VerifyStringResult (JSON)</span></span>
<span data-ttu-id="7babf-105">[/System/strings/validate](../uri/stringserver/uri-systemstringsvalidate.md)に送信された各文字列に対応する結果コード。</span><span class="sxs-lookup"><span data-stu-id="7babf-105">Result codes corresponding to each string submitted to [/system/strings/validate](../uri/stringserver/uri-systemstringsvalidate.md).</span></span>
<a id="ID4ER"></a>


## <a name="verifystringresult"></a><span data-ttu-id="7babf-106">VerifyStringResult</span><span class="sxs-lookup"><span data-stu-id="7babf-106">VerifyStringResult</span></span>

<span data-ttu-id="7babf-107">VerifyStringResult オブジェクトには、次仕様があります。</span><span class="sxs-lookup"><span data-stu-id="7babf-107">The VerifyStringResult object has the following specification.</span></span>

| <span data-ttu-id="7babf-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="7babf-108">Member</span></span>| <span data-ttu-id="7babf-109">種類</span><span class="sxs-lookup"><span data-stu-id="7babf-109">Type</span></span>| <span data-ttu-id="7babf-110">説明</span><span class="sxs-lookup"><span data-stu-id="7babf-110">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="7babf-111">resultCode</span><span class="sxs-lookup"><span data-stu-id="7babf-111">resultCode</span></span>| <span data-ttu-id="7babf-112">32 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="7babf-112">32-bit unsigned integer</span></span>| <span data-ttu-id="7babf-113">必須。</span><span class="sxs-lookup"><span data-stu-id="7babf-113">Required.</span></span> <span data-ttu-id="7babf-114">HResult コードに対応する文字列を送信します。</span><span class="sxs-lookup"><span data-stu-id="7babf-114">HResult code corresponding to submitted string.</span></span>|
| <span data-ttu-id="7babf-115">offendingString</span><span class="sxs-lookup"><span data-stu-id="7babf-115">offendingString</span></span>| <span data-ttu-id="7babf-116">string</span><span class="sxs-lookup"><span data-stu-id="7babf-116">string</span></span>| <span data-ttu-id="7babf-117">必須。</span><span class="sxs-lookup"><span data-stu-id="7babf-117">Required.</span></span> <span data-ttu-id="7babf-118">拒否する文字列の原因となった文字列値。</span><span class="sxs-lookup"><span data-stu-id="7babf-118">String value that caused a string to be rejected.</span></span>|

<a id="ID4EXB"></a>


## <a name="sample-json-syntax"></a><span data-ttu-id="7babf-119">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="7babf-119">Sample JSON syntax</span></span>


```json
{
    "verifyStringResult":
    [
        {"resultCode": "1", "offendingString": "badword"},
        {"resultCode": "0", "offendingString": ""},
        {"resultCode": "0", "offendingString": ""},
        {"resultCode": "0", "offendingString": ""},
    ]
}

```


#### <a name="common-hresult-values"></a><span data-ttu-id="7babf-120">一般的な HResult 値</span><span class="sxs-lookup"><span data-stu-id="7babf-120">Common HResult Values</span></span>

| <span data-ttu-id="7babf-121">値</span><span class="sxs-lookup"><span data-stu-id="7babf-121">Value</span></span>| <span data-ttu-id="7babf-122">エラーの名前</span><span class="sxs-lookup"><span data-stu-id="7babf-122">Error Name</span></span>|
| --- | --- | --- | --- | --- |
| <span data-ttu-id="7babf-123">0</span><span class="sxs-lookup"><span data-stu-id="7babf-123">0</span></span>| <span data-ttu-id="7babf-124">成功</span><span class="sxs-lookup"><span data-stu-id="7babf-124">Success</span></span>|
| <span data-ttu-id="7babf-125">1</span><span class="sxs-lookup"><span data-stu-id="7babf-125">1</span></span>| <span data-ttu-id="7babf-126">不快感を与える文字列</span><span class="sxs-lookup"><span data-stu-id="7babf-126">Offensive string</span></span>|
| <span data-ttu-id="7babf-127">2</span><span class="sxs-lookup"><span data-stu-id="7babf-127">2</span></span>| <span data-ttu-id="7babf-128">文字列が長すぎます</span><span class="sxs-lookup"><span data-stu-id="7babf-128">String too long</span></span>|
| <span data-ttu-id="7babf-129">3</span><span class="sxs-lookup"><span data-stu-id="7babf-129">3</span></span>| <span data-ttu-id="7babf-130">不明なエラー</span><span class="sxs-lookup"><span data-stu-id="7babf-130">Unknown error</span></span>|

<a id="ID4ELD"></a>


## <a name="see-also"></a><span data-ttu-id="7babf-131">関連項目</span><span class="sxs-lookup"><span data-stu-id="7babf-131">See also</span></span>

<a id="ID4END"></a>


##### <a name="parent"></a><span data-ttu-id="7babf-132">Parent</span><span class="sxs-lookup"><span data-stu-id="7babf-132">Parent</span></span>

[<span data-ttu-id="7babf-133">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="7babf-133">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)


<a id="ID4EXD"></a>


##### <a name="reference"></a><span data-ttu-id="7babf-134">リファレンス</span><span class="sxs-lookup"><span data-stu-id="7babf-134">Reference</span></span>

[<span data-ttu-id="7babf-135">POST (/system/strings/validate)</span><span class="sxs-lookup"><span data-stu-id="7babf-135">POST (/system/strings/validate)</span></span>](../uri/stringserver/uri-systemstringsvalidatepost.md)
