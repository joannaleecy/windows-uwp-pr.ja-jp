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
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3882212"
---
# <a name="verifystringresult-json"></a><span data-ttu-id="533bb-104">VerifyStringResult (JSON)</span><span class="sxs-lookup"><span data-stu-id="533bb-104">VerifyStringResult (JSON)</span></span>
<span data-ttu-id="533bb-105">各文字列に[/system/strings/validate](../uri/stringserver/uri-systemstringsvalidate.md)提出に対応する結果コード。</span><span class="sxs-lookup"><span data-stu-id="533bb-105">Result codes corresponding to each string submitted to [/system/strings/validate](../uri/stringserver/uri-systemstringsvalidate.md).</span></span>
<a id="ID4ER"></a>


## <a name="verifystringresult"></a><span data-ttu-id="533bb-106">VerifyStringResult</span><span class="sxs-lookup"><span data-stu-id="533bb-106">VerifyStringResult</span></span>

<span data-ttu-id="533bb-107">VerifyStringResult オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="533bb-107">The VerifyStringResult object has the following specification.</span></span>

| <span data-ttu-id="533bb-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="533bb-108">Member</span></span>| <span data-ttu-id="533bb-109">種類</span><span class="sxs-lookup"><span data-stu-id="533bb-109">Type</span></span>| <span data-ttu-id="533bb-110">説明</span><span class="sxs-lookup"><span data-stu-id="533bb-110">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="533bb-111">resultCode</span><span class="sxs-lookup"><span data-stu-id="533bb-111">resultCode</span></span>| <span data-ttu-id="533bb-112">32 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="533bb-112">32-bit unsigned integer</span></span>| <span data-ttu-id="533bb-113">必須。</span><span class="sxs-lookup"><span data-stu-id="533bb-113">Required.</span></span> <span data-ttu-id="533bb-114">HResult コードに対応する文字列を送信します。</span><span class="sxs-lookup"><span data-stu-id="533bb-114">HResult code corresponding to submitted string.</span></span>|
| <span data-ttu-id="533bb-115">offendingString</span><span class="sxs-lookup"><span data-stu-id="533bb-115">offendingString</span></span>| <span data-ttu-id="533bb-116">string</span><span class="sxs-lookup"><span data-stu-id="533bb-116">string</span></span>| <span data-ttu-id="533bb-117">必須。</span><span class="sxs-lookup"><span data-stu-id="533bb-117">Required.</span></span> <span data-ttu-id="533bb-118">拒否する文字列の原因となった文字列値。</span><span class="sxs-lookup"><span data-stu-id="533bb-118">String value that caused a string to be rejected.</span></span>|

<a id="ID4EXB"></a>


## <a name="sample-json-syntax"></a><span data-ttu-id="533bb-119">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="533bb-119">Sample JSON syntax</span></span>


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


#### <a name="common-hresult-values"></a><span data-ttu-id="533bb-120">一般的な HResult 値</span><span class="sxs-lookup"><span data-stu-id="533bb-120">Common HResult Values</span></span>

| <span data-ttu-id="533bb-121">値</span><span class="sxs-lookup"><span data-stu-id="533bb-121">Value</span></span>| <span data-ttu-id="533bb-122">エラーの名前</span><span class="sxs-lookup"><span data-stu-id="533bb-122">Error Name</span></span>|
| --- | --- | --- | --- | --- |
| <span data-ttu-id="533bb-123">0</span><span class="sxs-lookup"><span data-stu-id="533bb-123">0</span></span>| <span data-ttu-id="533bb-124">成功</span><span class="sxs-lookup"><span data-stu-id="533bb-124">Success</span></span>|
| <span data-ttu-id="533bb-125">1</span><span class="sxs-lookup"><span data-stu-id="533bb-125">1</span></span>| <span data-ttu-id="533bb-126">不快感を与える文字列</span><span class="sxs-lookup"><span data-stu-id="533bb-126">Offensive string</span></span>|
| <span data-ttu-id="533bb-127">2</span><span class="sxs-lookup"><span data-stu-id="533bb-127">2</span></span>| <span data-ttu-id="533bb-128">長い文字列</span><span class="sxs-lookup"><span data-stu-id="533bb-128">String too long</span></span>|
| <span data-ttu-id="533bb-129">3</span><span class="sxs-lookup"><span data-stu-id="533bb-129">3</span></span>| <span data-ttu-id="533bb-130">不明なエラー</span><span class="sxs-lookup"><span data-stu-id="533bb-130">Unknown error</span></span>|

<a id="ID4ELD"></a>


## <a name="see-also"></a><span data-ttu-id="533bb-131">関連項目</span><span class="sxs-lookup"><span data-stu-id="533bb-131">See also</span></span>

<a id="ID4END"></a>


##### <a name="parent"></a><span data-ttu-id="533bb-132">Parent</span><span class="sxs-lookup"><span data-stu-id="533bb-132">Parent</span></span>

[<span data-ttu-id="533bb-133">JavaScript オブジェクト Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="533bb-133">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)


<a id="ID4EXD"></a>


##### <a name="reference"></a><span data-ttu-id="533bb-134">リファレンス</span><span class="sxs-lookup"><span data-stu-id="533bb-134">Reference</span></span>

[<span data-ttu-id="533bb-135">POST (/システム/文字列/検証)</span><span class="sxs-lookup"><span data-stu-id="533bb-135">POST (/system/strings/validate)</span></span>](../uri/stringserver/uri-systemstringsvalidatepost.md)
