---
Description: パートナー センター アカウントにユーザーを追加し、特定のアクセス許可を持つロールを割り当てます。
title: アカウント ユーザーの管理
ms.assetid: 9245F0D0-7D8F-4741-AFB4-FBA5601D0A9B
ms.date: 10/31/2018
ms.topic: article
keywords: windows 10、uwp、アカウントのユーザー、ユーザー、azure ad でマルチ ユーザー、複数のユーザーを管理します。
ms.localizationpriority: medium
ms.openlocfilehash: 282b1eb087fa081b621437206f338ed4b6d3569b
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57659747"
---
# <a name="manage-account-users"></a><span data-ttu-id="7006b-104">アカウント ユーザーの管理</span><span class="sxs-lookup"><span data-stu-id="7006b-104">Manage account users</span></span>

<span data-ttu-id="7006b-105">Azure Active Directory を使用して追加および追加のユーザーを管理することができます、[パートナー センター](https://partner.microsoft.com/dashboard)アカウント。</span><span class="sxs-lookup"><span data-stu-id="7006b-105">You can use Azure Active Directory to add and manage additional users in your [Partner Center](https://partner.microsoft.com/dashboard)  account.</span></span> <span data-ttu-id="7006b-106">各ユーザーに必要なロールまたはカスタムのアクセス許可を定義できます。</span><span class="sxs-lookup"><span data-stu-id="7006b-106">You can define the role or custom permissions that each user should have.</span></span> <span data-ttu-id="7006b-107">ユーザーのグループや Azure AD アプリケーションに役割を割り当てることもできます。</span><span class="sxs-lookup"><span data-stu-id="7006b-107">You can also assign a role to a group of users, or to an Azure AD application.</span></span>

<span data-ttu-id="7006b-108">追加し、アカウントのユーザーを管理するために、組織の Azure Active Directory で最初に、パートナー センター アカウントを関連付ける必要があります。</span><span class="sxs-lookup"><span data-stu-id="7006b-108">In order to add and manage account users, you must first associate your Partner Center account with your organization's Azure Active Directory.</span></span> 

<span data-ttu-id="7006b-109">このセクションでは、次の操作手順について説明します。</span><span class="sxs-lookup"><span data-stu-id="7006b-109">This section describes how to do the following:</span></span>

-   [<span data-ttu-id="7006b-110">Azure Active Directory をパートナー センター アカウントに関連付ける</span><span class="sxs-lookup"><span data-stu-id="7006b-110">Associate Azure Active Directory with your Partner Center account</span></span>](associate-azure-ad-with-dev-center.md)
-   [<span data-ttu-id="7006b-111">ユーザー、グループ、およびパートナー センター アカウントに Azure AD アプリケーションを追加します。</span><span class="sxs-lookup"><span data-stu-id="7006b-111">Add users, groups, and Azure AD applications to your Partner Center account</span></span>](add-users-groups-and-azure-ad-applications.md)
-   [<span data-ttu-id="7006b-112">ロールとアカウントのユーザーのカスタム アクセス許可を設定します。</span><span class="sxs-lookup"><span data-stu-id="7006b-112">Set roles and custom permissions for account users</span></span>](set-custom-permissions-for-account-users.md)

> [!TIP]
> <span data-ttu-id="7006b-113">これらのトピックはパートナー センターでは、Windows アプリ開発者プログラムのですが、Windows ハードウェア開発者プログラムにアカウントのテナントに関連付けると、ユーザーの管理は同様に (を参照してください[ダッシュ ボード管理](https://docs.microsoft.com/windows-hardware/drivers/dashboard/dashboard-administration)詳細については) または Windows デスクトップ アプリケーションのプログラムで (を参照してください[Windows デスクトップ アプリケーション プログラム](https://docs.microsoft.com/windows/desktop/appxpkg/windows-desktop-application-program#add-and-manage-account-users)の詳細)。</span><span class="sxs-lookup"><span data-stu-id="7006b-113">These topics are specific to the Windows apps developer program in Partner Center, but associating a tenant and managing users works similarly for accounts in the Windows Hardware Developer Program (see [Dashboard Administration](https://docs.microsoft.com/windows-hardware/drivers/dashboard/dashboard-administration) for more info) or in the Windows Desktop Application Program (see [Windows Desktop Application Program](https://docs.microsoft.com/windows/desktop/appxpkg/windows-desktop-application-program#add-and-manage-account-users) for more info).</span></span>
