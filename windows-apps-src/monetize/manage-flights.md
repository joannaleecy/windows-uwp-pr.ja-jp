---
author: Xansky
ms.assetid: 37F2C162-4910-4336-BEED-8536C88DCA65
description: Windows デベロッパー センター アカウントに登録されているアプリのパッケージ フライトを管理するには、Microsoft Store 申請 API の以下のメソッドを使います。
title: パッケージ フライトの管理
ms.author: mhopkins
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store 申請 API, フライト
ms.localizationpriority: medium
ms.openlocfilehash: 41cf0d224dfca4d11bbd1e3fde7da44c5201a601
ms.sourcegitcommit: 6cc275f2151f78db40c11ace381ee2d35f0155f9
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5556387"
---
# <a name="manage-package-flights"></a><span data-ttu-id="ee161-104">パッケージ フライトの管理</span><span class="sxs-lookup"><span data-stu-id="ee161-104">Manage package flights</span></span>

<span data-ttu-id="ee161-105">アプリのパッケージ フライトを管理するには、Microsoft Store 申請 API の以下のメソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="ee161-105">Use the following methods in the Microsoft Store submission API to manage package flights for your apps.</span></span> <span data-ttu-id="ee161-106">Microsoft Store 申請 API の概要については、「[Microsoft Store サービスを使用した申請の作成と管理](create-and-manage-submissions-using-windows-store-services.md)」をご覧ください。この API を使用するための前提条件などの情報があります。</span><span class="sxs-lookup"><span data-stu-id="ee161-106">For an introduction to the Microsoft Store submission API, including prerequisites for using the API, see [Create and manage submissions using Microsoft Store services](create-and-manage-submissions-using-windows-store-services.md).</span></span>

<span data-ttu-id="ee161-107">以下のメソッドは、パッケージ フライトの取得、作成、または削除にしか使用できません。</span><span class="sxs-lookup"><span data-stu-id="ee161-107">These methods can only be used to get, create, or delete package flights.</span></span> <span data-ttu-id="ee161-108">パッケージ フライトの申請を作成するには、「[パッケージ フライトの申請の管理](manage-flight-submissions.md)」のメソッドをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ee161-108">To create submissions for package flights, see the methods in [Manage package flight submissions](manage-flight-submissions.md).</span></span>

<table>
<colgroup>
<col width="10%" />
<col width="30%" />
<col width="60%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="ee161-109">メソッド</span><span class="sxs-lookup"><span data-stu-id="ee161-109">Method</span></span></th>
<th align="left"><span data-ttu-id="ee161-110">URI</span><span class="sxs-lookup"><span data-stu-id="ee161-110">URI</span></span></th>
<th align="left"><span data-ttu-id="ee161-111">説明</span><span class="sxs-lookup"><span data-stu-id="ee161-111">Description</span></span></th>
</tr>
</thead>
<tbody>
<tr>
<td align="left"><span data-ttu-id="ee161-112">GET</span><span class="sxs-lookup"><span data-stu-id="ee161-112">GET</span></span></td>
<td align="left">https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}</td>
<td align="left"><a href="get-a-flight.md"><span data-ttu-id="ee161-113">パッケージ フライトの取得</span><span class="sxs-lookup"><span data-stu-id="ee161-113">Get a package flight</span></span></a></td>
</tr>
<tr>
<td align="left"><span data-ttu-id="ee161-114">POST</span><span class="sxs-lookup"><span data-stu-id="ee161-114">POST</span></span></td>
<td align="left">https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights</td>
<td align="left"><a href="create-a-flight.md"><span data-ttu-id="ee161-115">パッケージ フライトの作成</span><span class="sxs-lookup"><span data-stu-id="ee161-115">Create a package flight</span></span></a></td>
</tr>
<tr>
<td align="left"><span data-ttu-id="ee161-116">DELETE</span><span class="sxs-lookup"><span data-stu-id="ee161-116">DELETE</span></span></td>
<td align="left">https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}</td>
<td align="left"><a href="delete-a-flight.md"><span data-ttu-id="ee161-117">パッケージ フライトの削除</span><span class="sxs-lookup"><span data-stu-id="ee161-117">Delete a package flight</span></span></a></td>
</tr>
</tbody>
</table>

## <a name="prerequisites"></a><span data-ttu-id="ee161-118">前提条件</span><span class="sxs-lookup"><span data-stu-id="ee161-118">Prerequisites</span></span>

<span data-ttu-id="ee161-119">Microsoft Store 申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)がまだ満たされていない場合は、ここに記載されているメソッドを使用する前に前提条件を整えてください。</span><span class="sxs-lookup"><span data-stu-id="ee161-119">If you have not done so already, complete all the [prerequisites](create-and-manage-submissions-using-windows-store-services.md#prerequisites) for the Microsoft Store submission API before trying to use any of these methods.</span></span>

## <a name="related-topics"></a><span data-ttu-id="ee161-120">関連トピック</span><span class="sxs-lookup"><span data-stu-id="ee161-120">Related topics</span></span>

* [<span data-ttu-id="ee161-121">Microsoft Store サービスを使用した申請の作成と管理</span><span class="sxs-lookup"><span data-stu-id="ee161-121">Create and manage submissions using Microsoft Store services</span></span>](create-and-manage-submissions-using-windows-store-services.md)
* [<span data-ttu-id="ee161-122">パッケージ フライトの申請の管理</span><span class="sxs-lookup"><span data-stu-id="ee161-122">Manage package flight submissions</span></span>](manage-flight-submissions.md)
