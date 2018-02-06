---
author: jnHs
Description: Add users to your Dev Center account and assign them roles with specific permissions.
title: "アカウント ユーザーの管理"
ms.assetid: 9245F0D0-7D8F-4741-AFB4-FBA5601D0A9B
ms.author: wdg-dev-content
ms.date: 01/10/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "windows 10, uwp, アカウント ユーザー, ユーザーの管理, azure ad, マルチ ユーザー"
ms.localizationpriority: high
ms.openlocfilehash: e9a08225f0eac5018b3634df3bfb055d38ccb895
ms.sourcegitcommit: 446fe2861651f51a129baa80791f565f81b4f317
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 01/12/2018
---
# <a name="manage-account-users"></a><span data-ttu-id="e2988-103">アカウント ユーザーの管理</span><span class="sxs-lookup"><span data-stu-id="e2988-103">Manage account users</span></span>

<span data-ttu-id="e2988-104">Azure Active Directory を使って、追加のユーザーをデベロッパー センター アカウントに追加し、管理できます。</span><span class="sxs-lookup"><span data-stu-id="e2988-104">You can use Azure Active Directory to add and manage additional users in your Dev Center account.</span></span> <span data-ttu-id="e2988-105">各ユーザーに必要な役割またはカスタムのアクセス許可を定義できます。</span><span class="sxs-lookup"><span data-stu-id="e2988-105">You can define the role or custom permissions that each user should have.</span></span> <span data-ttu-id="e2988-106">ユーザーのグループや Azure AD アプリケーションに役割を割り当てることもできます。</span><span class="sxs-lookup"><span data-stu-id="e2988-106">You can also assign a role to a group of users, or to an Azure AD application.</span></span>

<span data-ttu-id="e2988-107">アカウント ユーザーを追加および管理するには、まずデベロッパー センター アカウントを組織の Azure Active Directory に関連付けます。</span><span class="sxs-lookup"><span data-stu-id="e2988-107">In order to add and manage account users, you must first associate your Dev Center account with your organization's Azure Active Directory.</span></span> 

<span data-ttu-id="e2988-108">このセクションでは、次の操作手順について説明します。</span><span class="sxs-lookup"><span data-stu-id="e2988-108">This section describes how to do the following:</span></span>

-   [<span data-ttu-id="e2988-109">Azure Active Directory とデベロッパー センター アカウントとの関連付け</span><span class="sxs-lookup"><span data-stu-id="e2988-109">Associate Azure Active Directory with your Dev Center account</span></span>](associate-azure-ad-with-dev-center.md)
-   [<span data-ttu-id="e2988-110">デベロッパー センター アカウントへのユーザー、グループ、Azure AD アプリケーションの追加</span><span class="sxs-lookup"><span data-stu-id="e2988-110">Add users, groups, and Azure AD applications to your Dev Center account</span></span>](add-users-groups-and-azure-ad-applications.md)
-   [<span data-ttu-id="e2988-111">アカウント ユーザーの役割とカスタムのアクセス許可の設定</span><span class="sxs-lookup"><span data-stu-id="e2988-111">Set roles and custom permissions for account users</span></span>](set-custom-permissions-for-account-users.md)

> [!TIP]
> <span data-ttu-id="e2988-112">このセクションは、Windows アプリ開発者プログラムに固有の内容ですが、テナントの関連付けとユーザーの管理は Windows ハードウェア開発者プログラムのアカウントでも同様に機能します。</span><span class="sxs-lookup"><span data-stu-id="e2988-112">This section is specific to the Windows apps developer program, but associating a tenant and managing users works similarly for accounts in the Windows Hardware Developer Program.</span></span> <span data-ttu-id="e2988-113">ハードウェア開発者プログラムでのユーザー管理について詳しくは、「[ダッシュボードの管理](https://docs.microsoft.com/windows-hardware/drivers/dashboard/dashboard-administration)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e2988-113">For more about user management in the Hardware Developer Program, see [Dashboard Administration](https://docs.microsoft.com/windows-hardware/drivers/dashboard/dashboard-administration).</span></span>
