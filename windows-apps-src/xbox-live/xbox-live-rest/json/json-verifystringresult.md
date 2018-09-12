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
ms.sourcegitcommit: 2a63ee6770413bc35ace09b14f56b60007be7433
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3935614"
---
# <a name="verifystringresult-json"></a><span data-ttu-id="d196b-104">VerifyStringResult (JSON)</span><span class="sxs-lookup"><span data-stu-id="d196b-104">VerifyStringResult (JSON)</span></span>
<span data-ttu-id="d196b-105">[/System/strings/validate](../uri/stringserver/uri-systemstringsvalidate.md)に送信された各文字列に対応する結果コード。</span><span class="sxs-lookup"><span data-stu-id="d196b-105">Result codes corresponding to each string submitted to [/system/strings/validate](../uri/stringserver/uri-systemstringsvalidate.md).</span></span>
<a id="ID4ER"></a>


## <a name="verifystringresult"></a><span data-ttu-id="d196b-106">VerifyStringResult</span><span class="sxs-lookup"><span data-stu-id="d196b-106">VerifyStringResult</span></span>

<span data-ttu-id="d196b-107">VerifyStringResult オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="d196b-107">The VerifyStringResult object has the following specification.</span></span>

| <span data-ttu-id="d196b-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="d196b-108">Member</span></span>| <span data-ttu-id="d196b-109">種類</span><span class="sxs-lookup"><span data-stu-id="d196b-109">Type</span></span>| <span data-ttu-id="d196b-110">説明</span><span class="sxs-lookup"><span data-stu-id="d196b-110">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="d196b-111">resultCode</span><span class="sxs-lookup"><span data-stu-id="d196b-111">resultCode</span></span>| <span data-ttu-id="d196b-112">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="d196b-112">32-bit unsigned integer</span></span>| <span data-ttu-id="d196b-113">必須。</span><span class="sxs-lookup"><span data-stu-id="d196b-113">Required.</span></span> <span data-ttu-id="d196b-114">HResult コードに対応する文字列を送信します。</span><span class="sxs-lookup"><span data-stu-id="d196b-114">HResult code corresponding to submitted string.</span></span>|
| <span data-ttu-id="d196b-115">offendingString</span><span class="sxs-lookup"><span data-stu-id="d196b-115">offendingString</span></span>| <span data-ttu-id="d196b-116">string</span><span class="sxs-lookup"><span data-stu-id="d196b-116">string</span></span>| <span data-ttu-id="d196b-117">必須。</span><span class="sxs-lookup"><span data-stu-id="d196b-117">Required.</span></span> <span data-ttu-id="d196b-118">拒否する文字列の原因となった文字列値。</span><span class="sxs-lookup"><span data-stu-id="d196b-118">String value that caused a string to be rejected.</span></span>|

<a id="ID4EXB"></a>


## <a name="sample-json-syntax"></a><span data-ttu-id="d196b-119">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="d196b-119">Sample JSON syntax</span></span>


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


#### <a name="common-hresult-values"></a><span data-ttu-id="d196b-120">一般的な HResult 値</span><span class="sxs-lookup"><span data-stu-id="d196b-120">Common HResult Values</span></span>

| <span data-ttu-id="d196b-121">値</span><span class="sxs-lookup"><span data-stu-id="d196b-121">Value</span></span>| <span data-ttu-id="d196b-122">エラーの名前</span><span class="sxs-lookup"><span data-stu-id="d196b-122">Error Name</span></span>|
| --- | --- | --- | --- | --- |
| <span data-ttu-id="d196b-123">0</span><span class="sxs-lookup"><span data-stu-id="d196b-123">0</span></span>| <span data-ttu-id="d196b-124">成功</span><span class="sxs-lookup"><span data-stu-id="d196b-124">Success</span></span>|
| <span data-ttu-id="d196b-125">1</span><span class="sxs-lookup"><span data-stu-id="d196b-125">1</span></span>| <span data-ttu-id="d196b-126">不快感を与える文字列</span><span class="sxs-lookup"><span data-stu-id="d196b-126">Offensive string</span></span>|
| <span data-ttu-id="d196b-127">2</span><span class="sxs-lookup"><span data-stu-id="d196b-127">2</span></span>| <span data-ttu-id="d196b-128">文字列が長すぎます</span><span class="sxs-lookup"><span data-stu-id="d196b-128">String too long</span></span>|
| <span data-ttu-id="d196b-129">3</span><span class="sxs-lookup"><span data-stu-id="d196b-129">3</span></span>| <span data-ttu-id="d196b-130">不明なエラー</span><span class="sxs-lookup"><span data-stu-id="d196b-130">Unknown error</span></span>|

<a id="ID4ELD"></a>


## <a name="see-also"></a><span data-ttu-id="d196b-131">関連項目</span><span class="sxs-lookup"><span data-stu-id="d196b-131">See also</span></span>

<a id="ID4END"></a>


##### <a name="parent"></a><span data-ttu-id="d196b-132">Parent</span><span class="sxs-lookup"><span data-stu-id="d196b-132">Parent</span></span>

[<span data-ttu-id="d196b-133">JavaScript オブジェクト Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="d196b-133">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)


<a id="ID4EXD"></a>


##### <a name="reference"></a><span data-ttu-id="d196b-134">リファレンス</span><span class="sxs-lookup"><span data-stu-id="d196b-134">Reference</span></span>

[<span data-ttu-id="d196b-135">POST (/システム/文字列/検証)</span><span class="sxs-lookup"><span data-stu-id="d196b-135">POST (/system/strings/validate)</span></span>](../uri/stringserver/uri-systemstringsvalidatepost.md)
