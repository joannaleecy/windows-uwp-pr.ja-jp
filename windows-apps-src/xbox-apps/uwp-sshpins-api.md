---
title: Device Portal の SSH ピン API のリファレンス
description: 信頼されているすべての SSH ピンをプログラムで削除する方法について説明します。
ms.localizationpriority: medium
ms.topic: article
ms.date: 02/08/2017
ms.openlocfilehash: 2c7dc6fab021c11c98276ee53af161bea25601a9
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57663357"
---
# <a name="ssh-pins-api-reference"></a><span data-ttu-id="2bdeb-103">SSH ピン API リファレンス</span><span class="sxs-lookup"><span data-stu-id="2bdeb-103">SSH Pins API reference</span></span>
<span data-ttu-id="2bdeb-104">この REST API を使用して、開発キットで信頼されているすべての SSH ピンを削除することができます。</span><span class="sxs-lookup"><span data-stu-id="2bdeb-104">You can remove all trusted SSH pins on your devkit using this REST API.</span></span>

## <a name="remove-trusted-ssh-pins"></a><span data-ttu-id="2bdeb-105">信頼されている SSH ピンの削除</span><span class="sxs-lookup"><span data-stu-id="2bdeb-105">Remove trusted SSH pins</span></span>

<span data-ttu-id="2bdeb-106">**要求**</span><span class="sxs-lookup"><span data-stu-id="2bdeb-106">**Request**</span></span>

<span data-ttu-id="2bdeb-107">メソッド</span><span class="sxs-lookup"><span data-stu-id="2bdeb-107">Method</span></span>      | <span data-ttu-id="2bdeb-108">要求 URI</span><span class="sxs-lookup"><span data-stu-id="2bdeb-108">Request URI</span></span>
:------     | :-----
<span data-ttu-id="2bdeb-109">DELETE</span><span class="sxs-lookup"><span data-stu-id="2bdeb-109">DELETE</span></span> | <span data-ttu-id="2bdeb-110">/ext/app/sshpins</span><span class="sxs-lookup"><span data-stu-id="2bdeb-110">/ext/app/sshpins</span></span>
<br />
<span data-ttu-id="2bdeb-111">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="2bdeb-111">**URI parameters**</span></span>

- <span data-ttu-id="2bdeb-112">なし</span><span class="sxs-lookup"><span data-stu-id="2bdeb-112">None</span></span>

<span data-ttu-id="2bdeb-113">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="2bdeb-113">**Request headers**</span></span>

- <span data-ttu-id="2bdeb-114">なし</span><span class="sxs-lookup"><span data-stu-id="2bdeb-114">None</span></span>

<span data-ttu-id="2bdeb-115">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="2bdeb-115">**Request body**</span></span>   

- <span data-ttu-id="2bdeb-116">なし</span><span class="sxs-lookup"><span data-stu-id="2bdeb-116">None</span></span>

<span data-ttu-id="2bdeb-117">**応答**</span><span class="sxs-lookup"><span data-stu-id="2bdeb-117">**Response**</span></span>   

- <span data-ttu-id="2bdeb-118">なし</span><span class="sxs-lookup"><span data-stu-id="2bdeb-118">None</span></span> 

<span data-ttu-id="2bdeb-119">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="2bdeb-119">**Status code**</span></span>

<span data-ttu-id="2bdeb-120">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="2bdeb-120">This API has the following expected status codes.</span></span>

<span data-ttu-id="2bdeb-121">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="2bdeb-121">HTTP status code</span></span>      | <span data-ttu-id="2bdeb-122">説明</span><span class="sxs-lookup"><span data-stu-id="2bdeb-122">Description</span></span>
:------     | :-----
<span data-ttu-id="2bdeb-123">204</span><span class="sxs-lookup"><span data-stu-id="2bdeb-123">204</span></span> | <span data-ttu-id="2bdeb-124">ピンをクリアする要求が成功しました。</span><span class="sxs-lookup"><span data-stu-id="2bdeb-124">The request to clear the pins was successful.</span></span>
<span data-ttu-id="2bdeb-125">4XX</span><span class="sxs-lookup"><span data-stu-id="2bdeb-125">4XX</span></span> | <span data-ttu-id="2bdeb-126">エラー コード</span><span class="sxs-lookup"><span data-stu-id="2bdeb-126">Error codes</span></span>
<span data-ttu-id="2bdeb-127">5XX</span><span class="sxs-lookup"><span data-stu-id="2bdeb-127">5XX</span></span> | <span data-ttu-id="2bdeb-128">エラー コード</span><span class="sxs-lookup"><span data-stu-id="2bdeb-128">Error codes</span></span>

<br />
<span data-ttu-id="2bdeb-129">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="2bdeb-129">**Available device families**</span></span>

* <span data-ttu-id="2bdeb-130">Windows Xbox</span><span class="sxs-lookup"><span data-stu-id="2bdeb-130">Windows Xbox</span></span>

