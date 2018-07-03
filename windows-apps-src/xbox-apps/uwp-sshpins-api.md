---
author: WilliamsJason
title: Device Portal の SSH ピン API のリファレンス
description: 信頼されているすべての SSH ピンをプログラムで削除する方法について説明します。
ms.localizationpriority: medium
ms.openlocfilehash: 88ba9d3e35650c8c581b9ddb76911636fc18c72e
ms.sourcegitcommit: c104b653601d9b81cfc8bb6032ca434cff8fe9b1
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/25/2018
ms.locfileid: "1921263"
---
# <a name="ssh-pins-api-reference"></a><span data-ttu-id="f10b6-103">SSH ピン API リファレンス</span><span class="sxs-lookup"><span data-stu-id="f10b6-103">SSH Pins API reference</span></span>
<span data-ttu-id="f10b6-104">この REST API を使用して、開発キットで信頼されているすべての SSH ピンを削除することができます。</span><span class="sxs-lookup"><span data-stu-id="f10b6-104">You can remove all trusted SSH pins on your devkit using this REST API.</span></span>

## <a name="remove-trusted-ssh-pins"></a><span data-ttu-id="f10b6-105">信頼されている SSH ピンの削除</span><span class="sxs-lookup"><span data-stu-id="f10b6-105">Remove trusted SSH pins</span></span>

**<span data-ttu-id="f10b6-106">要求</span><span class="sxs-lookup"><span data-stu-id="f10b6-106">Request</span></span>**

<span data-ttu-id="f10b6-107">メソッド</span><span class="sxs-lookup"><span data-stu-id="f10b6-107">Method</span></span>      | <span data-ttu-id="f10b6-108">要求 URI</span><span class="sxs-lookup"><span data-stu-id="f10b6-108">Request URI</span></span>
:------     | :-----
<span data-ttu-id="f10b6-109">DELETE</span><span class="sxs-lookup"><span data-stu-id="f10b6-109">DELETE</span></span> | <span data-ttu-id="f10b6-110">/ext/app/sshpins</span><span class="sxs-lookup"><span data-stu-id="f10b6-110">/ext/app/sshpins</span></span>
<br />
**<span data-ttu-id="f10b6-111">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="f10b6-111">URI parameters</span></span>**

- <span data-ttu-id="f10b6-112">なし</span><span class="sxs-lookup"><span data-stu-id="f10b6-112">None</span></span>

**<span data-ttu-id="f10b6-113">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="f10b6-113">Request headers</span></span>**

- <span data-ttu-id="f10b6-114">なし</span><span class="sxs-lookup"><span data-stu-id="f10b6-114">None</span></span>

**<span data-ttu-id="f10b6-115">要求本文</span><span class="sxs-lookup"><span data-stu-id="f10b6-115">Request body</span></span>**   

- <span data-ttu-id="f10b6-116">なし</span><span class="sxs-lookup"><span data-stu-id="f10b6-116">None</span></span>

**<span data-ttu-id="f10b6-117">応答</span><span class="sxs-lookup"><span data-stu-id="f10b6-117">Response</span></span>**   

- <span data-ttu-id="f10b6-118">なし</span><span class="sxs-lookup"><span data-stu-id="f10b6-118">None</span></span> 

**<span data-ttu-id="f10b6-119">状態コード</span><span class="sxs-lookup"><span data-stu-id="f10b6-119">Status code</span></span>**

<span data-ttu-id="f10b6-120">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="f10b6-120">This API has the following expected status codes.</span></span>

<span data-ttu-id="f10b6-121">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="f10b6-121">HTTP status code</span></span>      | <span data-ttu-id="f10b6-122">説明</span><span class="sxs-lookup"><span data-stu-id="f10b6-122">Description</span></span>
:------     | :-----
<span data-ttu-id="f10b6-123">204</span><span class="sxs-lookup"><span data-stu-id="f10b6-123">204</span></span> | <span data-ttu-id="f10b6-124">ピンをクリアする要求が成功しました。</span><span class="sxs-lookup"><span data-stu-id="f10b6-124">The request to clear the pins was successful.</span></span>
<span data-ttu-id="f10b6-125">4XX</span><span class="sxs-lookup"><span data-stu-id="f10b6-125">4XX</span></span> | <span data-ttu-id="f10b6-126">エラー コード</span><span class="sxs-lookup"><span data-stu-id="f10b6-126">Error codes</span></span>
<span data-ttu-id="f10b6-127">5XX</span><span class="sxs-lookup"><span data-stu-id="f10b6-127">5XX</span></span> | <span data-ttu-id="f10b6-128">エラー コード</span><span class="sxs-lookup"><span data-stu-id="f10b6-128">Error codes</span></span>

<br />
**<span data-ttu-id="f10b6-129">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="f10b6-129">Available device families</span></span>**

* <span data-ttu-id="f10b6-130">Windows Xbox</span><span class="sxs-lookup"><span data-stu-id="f10b6-130">Windows Xbox</span></span>

