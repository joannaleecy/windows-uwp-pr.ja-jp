---
author: jnHs
Description: Add users to your Dev Center account and assign them roles with specific permissions.
title: アカウント ユーザーの管理
ms.assetid: 9245F0D0-7D8F-4741-AFB4-FBA5601D0A9B
ms.author: wdg-dev-content
ms.date: 07/11/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: 10、uwp、ダイアログ ボックスの windows アカウントのユーザー、ユーザー、azure の広告、マルチ ユーザー、複数のユーザーを管理します。
ms.localizationpriority: medium
ms.openlocfilehash: bef703958f8f04cd55d887dfa8840d1ed3fbeba5
ms.sourcegitcommit: 3727445c1d6374401b867c78e4ff8b07d92b7adc
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/29/2018
ms.locfileid: "2918953"
---
# <a name="manage-account-users"></a><span data-ttu-id="e0f93-103">アカウント ユーザーの管理</span><span class="sxs-lookup"><span data-stu-id="e0f93-103">Manage account users</span></span>

<span data-ttu-id="e0f93-104">Azure Active Directory を使って、追加のユーザーをデベロッパー センター アカウントに追加し、管理できます。</span><span class="sxs-lookup"><span data-stu-id="e0f93-104">You can use Azure Active Directory to add and manage additional users in your Dev Center account.</span></span> <span data-ttu-id="e0f93-105">各ユーザーに必要なロールまたはカスタムのアクセス許可を定義できます。</span><span class="sxs-lookup"><span data-stu-id="e0f93-105">You can define the role or custom permissions that each user should have.</span></span> <span data-ttu-id="e0f93-106">ユーザーのグループや Azure AD アプリケーションにロールを割り当てることもできます。</span><span class="sxs-lookup"><span data-stu-id="e0f93-106">You can also assign a role to a group of users, or to an Azure AD application.</span></span>

<span data-ttu-id="e0f93-107">アカウント ユーザーを追加および管理するには、まずデベロッパー センター アカウントを組織の Azure Active Directory に関連付けます。</span><span class="sxs-lookup"><span data-stu-id="e0f93-107">In order to add and manage account users, you must first associate your Dev Center account with your organization's Azure Active Directory.</span></span> 

<span data-ttu-id="e0f93-108">このセクションでは、次の操作手順について説明します。</span><span class="sxs-lookup"><span data-stu-id="e0f93-108">This section describes how to do the following:</span></span>

-   [<span data-ttu-id="e0f93-109">Azure Active Directory とデベロッパー センター アカウントとの関連付け</span><span class="sxs-lookup"><span data-stu-id="e0f93-109">Associate Azure Active Directory with your Dev Center account</span></span>](associate-azure-ad-with-dev-center.md)
-   [<span data-ttu-id="e0f93-110">デベロッパー センター アカウントへのユーザー、グループ、Azure AD アプリケーションの追加</span><span class="sxs-lookup"><span data-stu-id="e0f93-110">Add users, groups, and Azure AD applications to your Dev Center account</span></span>](add-users-groups-and-azure-ad-applications.md)
-   [<span data-ttu-id="e0f93-111">アカウント ユーザーのロールとカスタムのアクセス許可の設定</span><span class="sxs-lookup"><span data-stu-id="e0f93-111">Set roles and custom permissions for account users</span></span>](set-custom-permissions-for-account-users.md)

> [!TIP]
> <span data-ttu-id="e0f93-112">このセクションは Windows アプリ開発者プログラムに固有の内容ですが、テナントの関連付けとユーザーの管理は Windows ハードウェア開発者プログラム (詳しくは「[ダッシュボードの管理](https://docs.microsoft.com/windows-hardware/drivers/dashboard/dashboard-administration)」を参照) のアカウントでも Windows デスクトップ アプリケーション プログラム (詳しくは「[Windows デスクトップ アプリケーション プログラム](https://docs.microsoft.com/windows/desktop/appxpkg/windows-desktop-application-program#add-and-manage-account-users)」を参照) のアカウントでも同様に機能します。</span><span class="sxs-lookup"><span data-stu-id="e0f93-112">This section is specific to the Windows apps developer program, but associating a tenant and managing users works similarly for accounts in the Windows Hardware Developer Program (see [Dashboard Administration](https://docs.microsoft.com/windows-hardware/drivers/dashboard/dashboard-administration) for more info) or in the Windows Desktop Application Program (see [Windows Desktop Application Program](https://docs.microsoft.com/windows/desktop/appxpkg/windows-desktop-application-program#add-and-manage-account-users) for more info).</span></span>
