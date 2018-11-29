---
ms.assetid: 37F2C162-4910-4336-BEED-8536C88DCA65
description: パートナー センター アカウントに登録されているアプリのパッケージ フライトを管理するのに、Microsoft Store 申請 API でこれらのメソッドを使用します。
title: パッケージ フライトの管理
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store 申請 API, フライト
ms.localizationpriority: medium
ms.openlocfilehash: 8678ee4d73f13e241a2c72d6dac532289af13ced
ms.sourcegitcommit: 89ff8ff88ef58f4fe6d3b1368fe94f62e59118ad
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/29/2018
ms.locfileid: "8209467"
---
# <a name="manage-package-flights"></a><span data-ttu-id="ed01f-104">パッケージ フライトの管理</span><span class="sxs-lookup"><span data-stu-id="ed01f-104">Manage package flights</span></span>

<span data-ttu-id="ed01f-105">アプリのパッケージ フライトを管理するには、Microsoft Store 申請 API の以下のメソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="ed01f-105">Use the following methods in the Microsoft Store submission API to manage package flights for your apps.</span></span> <span data-ttu-id="ed01f-106">Microsoft Store 申請 API の概要については、「[Microsoft Store サービスを使用した申請の作成と管理](create-and-manage-submissions-using-windows-store-services.md)」をご覧ください。この API を使用するための前提条件などの情報があります。</span><span class="sxs-lookup"><span data-stu-id="ed01f-106">For an introduction to the Microsoft Store submission API, including prerequisites for using the API, see [Create and manage submissions using Microsoft Store services](create-and-manage-submissions-using-windows-store-services.md).</span></span>

<span data-ttu-id="ed01f-107">以下のメソッドは、パッケージ フライトの取得、作成、または削除にしか使用できません。</span><span class="sxs-lookup"><span data-stu-id="ed01f-107">These methods can only be used to get, create, or delete package flights.</span></span> <span data-ttu-id="ed01f-108">パッケージ フライトの申請を作成するには、「[パッケージ フライトの申請の管理](manage-flight-submissions.md)」のメソッドをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ed01f-108">To create submissions for package flights, see the methods in [Manage package flight submissions](manage-flight-submissions.md).</span></span>

<table>
<colgroup>
<col width="10%" />
<col width="30%" />
<col width="60%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="ed01f-109">メソッド</span><span class="sxs-lookup"><span data-stu-id="ed01f-109">Method</span></span></th>
<th align="left"><span data-ttu-id="ed01f-110">URI</span><span class="sxs-lookup"><span data-stu-id="ed01f-110">URI</span></span></th>
<th align="left"><span data-ttu-id="ed01f-111">説明</span><span class="sxs-lookup"><span data-stu-id="ed01f-111">Description</span></span></th>
</tr>
</thead>
<tbody>
<tr>
<td align="left"><span data-ttu-id="ed01f-112">GET</span><span class="sxs-lookup"><span data-stu-id="ed01f-112">GET</span></span></td>
<td align="left">https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}</td>
<td align="left"><a href="get-a-flight.md"><span data-ttu-id="ed01f-113">パッケージ フライトの取得</span><span class="sxs-lookup"><span data-stu-id="ed01f-113">Get a package flight</span></span></a></td>
</tr>
<tr>
<td align="left"><span data-ttu-id="ed01f-114">POST</span><span class="sxs-lookup"><span data-stu-id="ed01f-114">POST</span></span></td>
<td align="left">https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights</td>
<td align="left"><a href="create-a-flight.md"><span data-ttu-id="ed01f-115">パッケージ フライトの作成</span><span class="sxs-lookup"><span data-stu-id="ed01f-115">Create a package flight</span></span></a></td>
</tr>
<tr>
<td align="left"><span data-ttu-id="ed01f-116">DELETE</span><span class="sxs-lookup"><span data-stu-id="ed01f-116">DELETE</span></span></td>
<td align="left">https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}</td>
<td align="left"><a href="delete-a-flight.md"><span data-ttu-id="ed01f-117">パッケージ フライトの削除</span><span class="sxs-lookup"><span data-stu-id="ed01f-117">Delete a package flight</span></span></a></td>
</tr>
</tbody>
</table>

## <a name="prerequisites"></a><span data-ttu-id="ed01f-118">前提条件</span><span class="sxs-lookup"><span data-stu-id="ed01f-118">Prerequisites</span></span>

<span data-ttu-id="ed01f-119">Microsoft Store 申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)がまだ満たされていない場合は、ここに記載されているメソッドを使用する前に前提条件を整えてください。</span><span class="sxs-lookup"><span data-stu-id="ed01f-119">If you have not done so already, complete all the [prerequisites](create-and-manage-submissions-using-windows-store-services.md#prerequisites) for the Microsoft Store submission API before trying to use any of these methods.</span></span>

## <a name="related-topics"></a><span data-ttu-id="ed01f-120">関連トピック</span><span class="sxs-lookup"><span data-stu-id="ed01f-120">Related topics</span></span>

* [<span data-ttu-id="ed01f-121">Microsoft Store サービスを使用した申請の作成と管理</span><span class="sxs-lookup"><span data-stu-id="ed01f-121">Create and manage submissions using Microsoft Store services</span></span>](create-and-manage-submissions-using-windows-store-services.md)
* [<span data-ttu-id="ed01f-122">パッケージ フライトの申請の管理</span><span class="sxs-lookup"><span data-stu-id="ed01f-122">Manage package flight submissions</span></span>](manage-flight-submissions.md)
