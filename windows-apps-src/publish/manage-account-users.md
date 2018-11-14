---
author: jnHs
Description: Add users to your Partner Center account and assign them roles with specific permissions.
title: アカウント ユーザーの管理
ms.assetid: 9245F0D0-7D8F-4741-AFB4-FBA5601D0A9B
ms.author: wdg-dev-content
ms.date: 10/31/2018
ms.topic: article
keywords: windows 10, uwp, アカウント ユーザー, ユーザー、azure ad, マルチ ユーザー、複数のユーザーを管理します。
ms.localizationpriority: medium
ms.openlocfilehash: 01517ebd2cc4b86fa1ac440446a5cc59172014b3
ms.sourcegitcommit: 38f06f1714334273d865935d9afb80efffe97a17
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/09/2018
ms.locfileid: "6190512"
---
# <a name="manage-account-users"></a><span data-ttu-id="7a20d-103">アカウント ユーザーの管理</span><span class="sxs-lookup"><span data-stu-id="7a20d-103">Manage account users</span></span>

<span data-ttu-id="7a20d-104">Azure Active Directory を使用して、追加して、[パートナー センター](https://partner.microsoft.com/dashboard)アカウントでその他のユーザーを管理することができます。</span><span class="sxs-lookup"><span data-stu-id="7a20d-104">You can use Azure Active Directory to add and manage additional users in your [Partner Center](https://partner.microsoft.com/dashboard)  account.</span></span> <span data-ttu-id="7a20d-105">各ユーザーに必要なロールまたはカスタムのアクセス許可を定義できます。</span><span class="sxs-lookup"><span data-stu-id="7a20d-105">You can define the role or custom permissions that each user should have.</span></span> <span data-ttu-id="7a20d-106">ユーザーのグループや Azure AD アプリケーションに役割を割り当てることもできます。</span><span class="sxs-lookup"><span data-stu-id="7a20d-106">You can also assign a role to a group of users, or to an Azure AD application.</span></span>

<span data-ttu-id="7a20d-107">追加し、アカウント ユーザーを管理するために、組織の Azure Active Directory と最初に、パートナー センター アカウントを関連付ける必要があります。</span><span class="sxs-lookup"><span data-stu-id="7a20d-107">In order to add and manage account users, you must first associate your Partner Center account with your organization's Azure Active Directory.</span></span> 

<span data-ttu-id="7a20d-108">このセクションでは、次の操作手順について説明します。</span><span class="sxs-lookup"><span data-stu-id="7a20d-108">This section describes how to do the following:</span></span>

-   [<span data-ttu-id="7a20d-109">パートナー センターのアカウントを Azure Active Directory を関連付ける</span><span class="sxs-lookup"><span data-stu-id="7a20d-109">Associate Azure Active Directory with your Partner Center account</span></span>](associate-azure-ad-with-dev-center.md)
-   [<span data-ttu-id="7a20d-110">ユーザー、グループ、および Azure AD アプリケーションをパートナー センター アカウントを追加します。</span><span class="sxs-lookup"><span data-stu-id="7a20d-110">Add users, groups, and Azure AD applications to your Partner Center account</span></span>](add-users-groups-and-azure-ad-applications.md)
-   [<span data-ttu-id="7a20d-111">アカウント ユーザーのロールとカスタムのアクセス許可の設定</span><span class="sxs-lookup"><span data-stu-id="7a20d-111">Set roles and custom permissions for account users</span></span>](set-custom-permissions-for-account-users.md)

> [!TIP]
> <span data-ttu-id="7a20d-112">これらのトピックでは、パートナー センターで、Windows アプリ開発者プログラムに固有ですが、Windows ハードウェア開発者プログラムでのアカウントのテナントの関連付けとユーザーの管理機能同様に (詳しくは、[ダッシュ ボードの管理](https://docs.microsoft.com/windows-hardware/drivers/dashboard/dashboard-administration)をご覧ください) か、Windows デスクトップ アプリケーション プログラム (詳しくは、 [Windows デスクトップ アプリケーション プログラム](https://docs.microsoft.com/windows/desktop/appxpkg/windows-desktop-application-program#add-and-manage-account-users)をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="7a20d-112">These topics are specific to the Windows apps developer program in Partner Center, but associating a tenant and managing users works similarly for accounts in the Windows Hardware Developer Program (see [Dashboard Administration](https://docs.microsoft.com/windows-hardware/drivers/dashboard/dashboard-administration) for more info) or in the Windows Desktop Application Program (see [Windows Desktop Application Program](https://docs.microsoft.com/windows/desktop/appxpkg/windows-desktop-application-program#add-and-manage-account-users) for more info).</span></span>
