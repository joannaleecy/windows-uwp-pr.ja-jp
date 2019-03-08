---
ms.assetid: 37F2C162-4910-4336-BEED-8536C88DCA65
description: Microsoft Store 送信 API でこれらのメソッドを使用すると、パートナー センター アカウントに登録されているアプリのパッケージのフライトを管理できます。
title: パッケージ フライトの管理
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store 申請 API, フライト
ms.localizationpriority: medium
ms.openlocfilehash: 8678ee4d73f13e241a2c72d6dac532289af13ced
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57601247"
---
# <a name="manage-package-flights"></a><span data-ttu-id="3e920-104">パッケージ フライトの管理</span><span class="sxs-lookup"><span data-stu-id="3e920-104">Manage package flights</span></span>

<span data-ttu-id="3e920-105">アプリのパッケージ フライトを管理するには、Microsoft Store 申請 API の以下のメソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="3e920-105">Use the following methods in the Microsoft Store submission API to manage package flights for your apps.</span></span> <span data-ttu-id="3e920-106">Microsoft Store 申請 API の概要については、「[Microsoft Store サービスを使用した申請の作成と管理](create-and-manage-submissions-using-windows-store-services.md)」をご覧ください。この API を使用するための前提条件などの情報があります。</span><span class="sxs-lookup"><span data-stu-id="3e920-106">For an introduction to the Microsoft Store submission API, including prerequisites for using the API, see [Create and manage submissions using Microsoft Store services](create-and-manage-submissions-using-windows-store-services.md).</span></span>

<span data-ttu-id="3e920-107">以下のメソッドは、パッケージ フライトの取得、作成、または削除にしか使用できません。</span><span class="sxs-lookup"><span data-stu-id="3e920-107">These methods can only be used to get, create, or delete package flights.</span></span> <span data-ttu-id="3e920-108">パッケージ フライトの申請を作成するには、「[パッケージ フライトの申請の管理](manage-flight-submissions.md)」のメソッドをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3e920-108">To create submissions for package flights, see the methods in [Manage package flight submissions](manage-flight-submissions.md).</span></span>

<table>
<colgroup>
<col width="10%" />
<col width="30%" />
<col width="60%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="3e920-109">メソッド</span><span class="sxs-lookup"><span data-stu-id="3e920-109">Method</span></span></th>
<th align="left"><span data-ttu-id="3e920-110">URI</span><span class="sxs-lookup"><span data-stu-id="3e920-110">URI</span></span></th>
<th align="left"><span data-ttu-id="3e920-111">説明</span><span class="sxs-lookup"><span data-stu-id="3e920-111">Description</span></span></th>
</tr>
</thead>
<tbody>
<tr>
<td align="left"><span data-ttu-id="3e920-112">GET</span><span class="sxs-lookup"><span data-stu-id="3e920-112">GET</span></span></td>
<td align="left">https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}</td>
<td align="left"><span data-ttu-id="3e920-113"><a href="get-a-flight.md">パッケージのフライトを取得します。</a></span><span class="sxs-lookup"><span data-stu-id="3e920-113"><a href="get-a-flight.md">Get a package flight</a></span></span></td>
</tr>
<tr>
<td align="left"><span data-ttu-id="3e920-114">POST</span><span class="sxs-lookup"><span data-stu-id="3e920-114">POST</span></span></td>
<td align="left">https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights</td>
<td align="left"><span data-ttu-id="3e920-115"><a href="create-a-flight.md">パッケージをフライトします。</a></span><span class="sxs-lookup"><span data-stu-id="3e920-115"><a href="create-a-flight.md">Create a package flight</a></span></span></td>
</tr>
<tr>
<td align="left"><span data-ttu-id="3e920-116">DELETE</span><span class="sxs-lookup"><span data-stu-id="3e920-116">DELETE</span></span></td>
<td align="left">https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}</td>
<td align="left"><span data-ttu-id="3e920-117"><a href="delete-a-flight.md">パッケージのフライトを削除します。</a></span><span class="sxs-lookup"><span data-stu-id="3e920-117"><a href="delete-a-flight.md">Delete a package flight</a></span></span></td>
</tr>
</tbody>
</table>

## <a name="prerequisites"></a><span data-ttu-id="3e920-118">前提条件</span><span class="sxs-lookup"><span data-stu-id="3e920-118">Prerequisites</span></span>

<span data-ttu-id="3e920-119">Microsoft Store 申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)がまだ満たされていない場合は、ここに記載されているメソッドを使用する前に前提条件を整えてください。</span><span class="sxs-lookup"><span data-stu-id="3e920-119">If you have not done so already, complete all the [prerequisites](create-and-manage-submissions-using-windows-store-services.md#prerequisites) for the Microsoft Store submission API before trying to use any of these methods.</span></span>

## <a name="related-topics"></a><span data-ttu-id="3e920-120">関連トピック</span><span class="sxs-lookup"><span data-stu-id="3e920-120">Related topics</span></span>

* [<span data-ttu-id="3e920-121">作成し、Microsoft Store サービスを使用して送信の管理</span><span class="sxs-lookup"><span data-stu-id="3e920-121">Create and manage submissions using Microsoft Store services</span></span>](create-and-manage-submissions-using-windows-store-services.md)
* [<span data-ttu-id="3e920-122">パッケージのフライトの送信を管理します。</span><span class="sxs-lookup"><span data-stu-id="3e920-122">Manage package flight submissions</span></span>](manage-flight-submissions.md)
