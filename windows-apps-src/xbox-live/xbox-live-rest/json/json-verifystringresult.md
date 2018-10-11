---
title: VerifyStringResult (JSON)
assetID: 272c688e-179e-c7e9-086b-e76d0d4bcb57
permalink: en-us/docs/xboxlive/rest/json-verifystringresult.html
author: KevinAsgari
description: " VerifyStringResult (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: f774f603d89e29f5233fb0866303bab4577ca3d2
ms.sourcegitcommit: 933e71a31989f8063b020746fdd16e9da94a44c4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/11/2018
ms.locfileid: "4531442"
---
# <a name="verifystringresult-json"></a><span data-ttu-id="33b17-104">VerifyStringResult (JSON)</span><span class="sxs-lookup"><span data-stu-id="33b17-104">VerifyStringResult (JSON)</span></span>
<span data-ttu-id="33b17-105">[/System/strings/validate](../uri/stringserver/uri-systemstringsvalidate.md)に送信された各文字列に対応する結果コード。</span><span class="sxs-lookup"><span data-stu-id="33b17-105">Result codes corresponding to each string submitted to [/system/strings/validate](../uri/stringserver/uri-systemstringsvalidate.md).</span></span>
<a id="ID4ER"></a>


## <a name="verifystringresult"></a><span data-ttu-id="33b17-106">VerifyStringResult</span><span class="sxs-lookup"><span data-stu-id="33b17-106">VerifyStringResult</span></span>

<span data-ttu-id="33b17-107">VerifyStringResult オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="33b17-107">The VerifyStringResult object has the following specification.</span></span>

| <span data-ttu-id="33b17-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="33b17-108">Member</span></span>| <span data-ttu-id="33b17-109">種類</span><span class="sxs-lookup"><span data-stu-id="33b17-109">Type</span></span>| <span data-ttu-id="33b17-110">説明</span><span class="sxs-lookup"><span data-stu-id="33b17-110">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="33b17-111">resultCode</span><span class="sxs-lookup"><span data-stu-id="33b17-111">resultCode</span></span>| <span data-ttu-id="33b17-112">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="33b17-112">32-bit unsigned integer</span></span>| <span data-ttu-id="33b17-113">必須。</span><span class="sxs-lookup"><span data-stu-id="33b17-113">Required.</span></span> <span data-ttu-id="33b17-114">HResult コードに対応する文字列を送信します。</span><span class="sxs-lookup"><span data-stu-id="33b17-114">HResult code corresponding to submitted string.</span></span>|
| <span data-ttu-id="33b17-115">offendingString</span><span class="sxs-lookup"><span data-stu-id="33b17-115">offendingString</span></span>| <span data-ttu-id="33b17-116">string</span><span class="sxs-lookup"><span data-stu-id="33b17-116">string</span></span>| <span data-ttu-id="33b17-117">必須。</span><span class="sxs-lookup"><span data-stu-id="33b17-117">Required.</span></span> <span data-ttu-id="33b17-118">拒否される文字列の原因となった文字列値。</span><span class="sxs-lookup"><span data-stu-id="33b17-118">String value that caused a string to be rejected.</span></span>|

<a id="ID4EXB"></a>


## <a name="sample-json-syntax"></a><span data-ttu-id="33b17-119">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="33b17-119">Sample JSON syntax</span></span>


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


#### <a name="common-hresult-values"></a><span data-ttu-id="33b17-120">一般的な HResult 値</span><span class="sxs-lookup"><span data-stu-id="33b17-120">Common HResult Values</span></span>

| <span data-ttu-id="33b17-121">値</span><span class="sxs-lookup"><span data-stu-id="33b17-121">Value</span></span>| <span data-ttu-id="33b17-122">エラーの名前</span><span class="sxs-lookup"><span data-stu-id="33b17-122">Error Name</span></span>|
| --- | --- | --- | --- | --- |
| <span data-ttu-id="33b17-123">0</span><span class="sxs-lookup"><span data-stu-id="33b17-123">0</span></span>| <span data-ttu-id="33b17-124">成功</span><span class="sxs-lookup"><span data-stu-id="33b17-124">Success</span></span>|
| <span data-ttu-id="33b17-125">1</span><span class="sxs-lookup"><span data-stu-id="33b17-125">1</span></span>| <span data-ttu-id="33b17-126">不快感を与える文字列</span><span class="sxs-lookup"><span data-stu-id="33b17-126">Offensive string</span></span>|
| <span data-ttu-id="33b17-127">2</span><span class="sxs-lookup"><span data-stu-id="33b17-127">2</span></span>| <span data-ttu-id="33b17-128">文字列が長すぎます</span><span class="sxs-lookup"><span data-stu-id="33b17-128">String too long</span></span>|
| <span data-ttu-id="33b17-129">3</span><span class="sxs-lookup"><span data-stu-id="33b17-129">3</span></span>| <span data-ttu-id="33b17-130">不明なエラー</span><span class="sxs-lookup"><span data-stu-id="33b17-130">Unknown error</span></span>|

<a id="ID4ELD"></a>


## <a name="see-also"></a><span data-ttu-id="33b17-131">関連項目</span><span class="sxs-lookup"><span data-stu-id="33b17-131">See also</span></span>

<a id="ID4END"></a>


##### <a name="parent"></a><span data-ttu-id="33b17-132">Parent</span><span class="sxs-lookup"><span data-stu-id="33b17-132">Parent</span></span>

[<span data-ttu-id="33b17-133">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="33b17-133">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)


<a id="ID4EXD"></a>


##### <a name="reference"></a><span data-ttu-id="33b17-134">リファレンス</span><span class="sxs-lookup"><span data-stu-id="33b17-134">Reference</span></span>

[<span data-ttu-id="33b17-135">POST (/system/strings/validate)</span><span class="sxs-lookup"><span data-stu-id="33b17-135">POST (/system/strings/validate)</span></span>](../uri/stringserver/uri-systemstringsvalidatepost.md)
