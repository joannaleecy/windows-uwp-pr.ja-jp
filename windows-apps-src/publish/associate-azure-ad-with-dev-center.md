---
author: jnHs
Description: In order to add and manage account users, you must first associate your Dev Center account with your organization's Azure Active Directory.
title: Azure Active Directory とデベロッパー センター アカウントとの関連付け
ms.author: wdg-dev-content
ms.date: 02/22/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, azure ad, azure テナント, aad テナント, azure ad テナント, テナント管理, テナント
ms.localizationpriority: high
ms.openlocfilehash: c430bb279d0b9da6126212a8af7400df8cd1693e
ms.sourcegitcommit: ef5a1e1807313a2caa9c9b35ea20b129ff7155d0
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/08/2018
---
# <a name="associate-azure-active-directory-with-your-dev-center-account"></a><span data-ttu-id="79917-103">Azure Active Directory とデベロッパー センター アカウントとの関連付け</span><span class="sxs-lookup"><span data-stu-id="79917-103">Associate Azure Active Directory with your Dev Center account</span></span>

<span data-ttu-id="79917-104">[アカウント ユーザーを追加および管理](add-users-groups-and-azure-ad-applications.md)するには、まずデベロッパー センター アカウントを組織の Azure Active Directory に関連付けます。</span><span class="sxs-lookup"><span data-stu-id="79917-104">In order to [add and manage account users](add-users-groups-and-azure-ad-applications.md), you must first associate your Dev Center account with your organization's Azure Active Directory.</span></span> 

<span data-ttu-id="79917-105">Windows デベロッパー センターでは、複数のユーザー アカウントのアクセスと管理に Azure AD を利用します。</span><span class="sxs-lookup"><span data-stu-id="79917-105">Windows Dev Center leverages Azure AD for multi-user account access and management.</span></span> <span data-ttu-id="79917-106">組織で Office 365 または Microsoft の他のビジネス サービスが既に使用されている場合は、既に Azure AD をお持ちです。</span><span class="sxs-lookup"><span data-stu-id="79917-106">If your organization already uses Office 365 or other business services from Microsoft, you already have Azure AD.</span></span> <span data-ttu-id="79917-107">それ以外の場合は、デベロッパー センター内から新しい Azure AD テナントを追加料金なしで作成できます。</span><span class="sxs-lookup"><span data-stu-id="79917-107">Otherwise, you can create a new Azure AD tenant from within Dev Center at no additional charge.</span></span>

> [!TIP]
> <span data-ttu-id="79917-108">このトピックは Windows アプリ開発者プログラムに固有の内容ですが、テナントの関連付けとユーザーの管理は Windows デスクトップ アプリケーション プログラム (詳しくは「[Windows デスクトップ アプリケーション プログラム](https://msdn.microsoft.com/library/windows/desktop/mt826504#users)」を参照) のアカウントでも Windows ハードウェア開発者プログラム (**マネージャー** ロールという記述は、**管理者**ロールのハードウェア アカウントにも適用されます。詳しくは「[ダッシュボードの管理](https://docs.microsoft.com/windows-hardware/drivers/dashboard/dashboard-administration)」を参照) のアカウントでも同様に機能します。</span><span class="sxs-lookup"><span data-stu-id="79917-108">This topic is specific to the Windows apps developer program, but associating a tenant and managing users works similarly for accounts in the Windows Desktop Application Program (see [Windows Desktop Application Program](https://msdn.microsoft.com/library/windows/desktop/mt826504#users) for more info) and in the Windows Hardware Developer Program (where references to the **Manager** role would also apply to Hardware accounts with the **Administrator** role; see [Dashboard Administration](https://docs.microsoft.com/windows-hardware/drivers/dashboard/dashboard-administration) for more info).</span></span>

<span data-ttu-id="79917-109">1 つの Azure AD テナントを複数のデベロッパー センター アカウントに関連付けることもできます。</span><span class="sxs-lookup"><span data-stu-id="79917-109">A single Azure AD tenant can be associated with multiple Dev Center accounts.</span></span> <span data-ttu-id="79917-110">複数のアカウント ユーザーを追加には 1 つの Azure AD テナントをデベロッパー センター アカウントに関連付けるだけでかまいませんが、複数の Azure AD テナントを 1 つのデベロッパー センター アカウントに追加することもできます。</span><span class="sxs-lookup"><span data-stu-id="79917-110">You only need to have one Azure AD tenant associated with your Dev Center account in order to add multiple account users, but you also have the option to add multiple Azure AD tenants to a single Dev Center account.</span></span> <span data-ttu-id="79917-111">デベロッパー センター アカウントで**マネージャー** ロールを持つすべてのユーザーは、Azure AD テナントの追加と削除を行うことができます。</span><span class="sxs-lookup"><span data-stu-id="79917-111">Any user with the **Manager** role in the Dev Center account will have the option to add and remove Azure AD tenants.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="79917-112">デベロッパー センター アカウントを Azure AD テナントと関連付けた後、そのテナントでアカウント ユーザーを追加および管理するには、**マネージャー** ロールを持つ同じテナントのユーザーとしてデベロッパー センターにサインインする必要があります。</span><span class="sxs-lookup"><span data-stu-id="79917-112">After you associate your Dev Center account with your Azure AD tenant, in order to add and manage account users in that tenant, you’ll need to sign in to Dev Center as a user in the same tenant who has the **Manager** role.</span></span>


## <a name="associate-your-dev-center-account-with-your-organizations-existing-azure-ad-tenant"></a><span data-ttu-id="79917-113">デベロッパー センター アカウントと組織の既存の Azure AD テナントを関連付ける</span><span class="sxs-lookup"><span data-stu-id="79917-113">Associate your Dev Center account with your organization’s existing Azure AD tenant</span></span>

<span data-ttu-id="79917-114">組織で既に Azure AD が使用されている場合は、次の手順に従ってデベロッパー センター アカウントをリンクします。</span><span class="sxs-lookup"><span data-stu-id="79917-114">If your organization already uses Azure AD, follow these steps to link your Dev Center account.</span></span>

1.  <span data-ttu-id="79917-115">**[アカウント設定]** に移動して、**[テナント]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="79917-115">Go to your **Account settings** and click **Tenants**.</span></span>
2.  <span data-ttu-id="79917-116">**[Azure AD と デベロッパー センター アカウントの関連付け]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="79917-116">Select **Associate Azure AD with your Dev Center account**.</span></span>
3.  <span data-ttu-id="79917-117">関連付けるテナントの Azure AD 資格情報を入力します。</span><span class="sxs-lookup"><span data-stu-id="79917-117">Enter your Azure AD credentials for the tenant that you want to associate.</span></span>
4.  <span data-ttu-id="79917-118">Azure AD テナントの組織とドメイン名を確認します。</span><span class="sxs-lookup"><span data-stu-id="79917-118">Review the organization and domain name for your Azure AD tenant.</span></span> <span data-ttu-id="79917-119">関連付けを完了するには、**[確認]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="79917-119">To complete the association, select **Confirm**.</span></span>
5.  <span data-ttu-id="79917-120">関連付けができたら、デベロッパー センターの **[ユーザー]** ページで、いつでもアカウント ユーザーを追加して管理することができます。</span><span class="sxs-lookup"><span data-stu-id="79917-120">If the association is successful, you will then be ready to add and manage account users in the **Users** section in Dev Center.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="79917-121">新しいユーザーを作成したり、Azure AD に他の変更を加えたりするには、[グローバル管理者のアクセス許可](http://go.microsoft.com/fwlink/?LinkId=746654)を持つアカウントを使ってその Azure AD にサインインする必要があります。</span><span class="sxs-lookup"><span data-stu-id="79917-121">In order to create new users, or make other changes to your Azure AD, you’ll need to sign in to that Azure AD tenant using an account which has [global administrator permission](http://go.microsoft.com/fwlink/?LinkId=746654) for that tenant.</span></span> <span data-ttu-id="79917-122">ただし、テナントを関連付けたり、そのテナントに既に存在しているユーザーをデベロッパー センター アカウントに追加したりする場合、グローバル管理者のアクセス許可は必要ありません。</span><span class="sxs-lookup"><span data-stu-id="79917-122">However, you don’t need global administrator permission in order to associate the tenant, or to add users who already exist in that tenant to your Dev Center account.</span></span>


## <a name="create-a-brand-new-azure-ad-to-associate-with-your-dev-center-account"></a><span data-ttu-id="79917-123">デベロッパー センター アカウントに関連付ける新しい Azure AD を作成する</span><span class="sxs-lookup"><span data-stu-id="79917-123">Create a brand new Azure AD to associate with your Dev Center account</span></span>

<span data-ttu-id="79917-124">デベロッパー センター アカウントをリンクする Azure AD を準備する必要がある場合は、次の手順に従います。</span><span class="sxs-lookup"><span data-stu-id="79917-124">If you need to set up a new Azure AD to link with your Dev Center account, follow these steps.</span></span>

1.  <span data-ttu-id="79917-125">**[アカウント設定]** に移動して、**[テナント]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="79917-125">Go to your **Account settings** and click **Tenants**.</span></span>
2.  <span data-ttu-id="79917-126">**[新しい Azure AD の作成]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="79917-126">Select **Create new Azure AD**.</span></span>
3.  <span data-ttu-id="79917-127">新しい Azure AD のディレクトリ情報を入力します。</span><span class="sxs-lookup"><span data-stu-id="79917-127">Enter the directory information for your new Azure AD:</span></span>
 - <span data-ttu-id="79917-128">**[ドメイン名]**: ".onmicrosoft.com" との組み合わせで Azure AD ドメインを示す一意の名前。</span><span class="sxs-lookup"><span data-stu-id="79917-128">**Domain name**: The unique name that we’ll use for your Azure AD domain, along with “.onmicrosoft.com”.</span></span> <span data-ttu-id="79917-129">たとえば、「example」と入力した場合、Azure AD ドメインは "example.onmicrosoft.com" になります。</span><span class="sxs-lookup"><span data-stu-id="79917-129">For example, if you entered “example”, your Azure AD domain would be “example.onmicrosoft.com”.</span></span>
 - <span data-ttu-id="79917-130">**[連絡先の電子メール]**: アカウントに関して連絡が必要になったときに連絡可能なメール アドレス。</span><span class="sxs-lookup"><span data-stu-id="79917-130">**Contact email**: An email address where we can contact you about your account if necessary.</span></span>
 - <span data-ttu-id="79917-131">**[全体管理者のユーザー アカウント]**: 新しい全体管理者アカウントに使用する名、姓、ユーザー名、およびパスワード。</span><span class="sxs-lookup"><span data-stu-id="79917-131">**Global administrator user account info**: The first name, last name, username, and password that you want to use for the new global administrator account.</span></span>
4.  <span data-ttu-id="79917-132">**[作成]** をクリックして、新しいドメインとアカウントの情報を確定します。</span><span class="sxs-lookup"><span data-stu-id="79917-132">Click **Create** to confirm the new domain and account info.</span></span>
5.  <span data-ttu-id="79917-133">新しい Azure AD 全体管理者のユーザー名とパスワードでサインインすると、[追加のアカウント ユーザーを追加および管理](add-users-groups-and-azure-ad-applications.md)を開始できます。</span><span class="sxs-lookup"><span data-stu-id="79917-133">Sign in with your new Azure AD global administrator username and password to begin [adding and managing additional account users](add-users-groups-and-azure-ad-applications.md).</span></span>


## <a name="manage-azure-ad-tenant-associations"></a><span data-ttu-id="79917-134">Azure AD テナントの関連付けの管理</span><span class="sxs-lookup"><span data-stu-id="79917-134">Manage Azure AD tenant associations</span></span>

<span data-ttu-id="79917-135">Azure AD テナントをデベロッパー センター アカウントに関連付けると、新しいテナントを追加したり、**[テナント]** ページから既存のテナントを削除したりすることができます。</span><span class="sxs-lookup"><span data-stu-id="79917-135">After you have associated an Azure AD tenant with your Dev Center account, you can add new tenants or remove existing tenants from the **Tenants** page.</span></span>


### <a name="add-multiple-azure-ad-tenants-to-your-dev-center-account"></a><span data-ttu-id="79917-136">デベロッパー センター アカウントへの複数の Azure AD テナントの追加</span><span class="sxs-lookup"><span data-stu-id="79917-136">Add multiple Azure AD tenants to your Dev Center account</span></span>

<span data-ttu-id="79917-137">デベロッパー センター アカウントの**マネージャー** ロールを持つユーザーは、Azure AD テナントをアカウントに関連付けることができます。</span><span class="sxs-lookup"><span data-stu-id="79917-137">Any user who has the **Manager** role for a Dev Center account can associate Azure AD tenants with the account.</span></span>

<span data-ttu-id="79917-138">新しいテナントを関連付けるには、**[別の Azure AD テナントの関連付け]** を選び、上記の手順に従います。</span><span class="sxs-lookup"><span data-stu-id="79917-138">To associate a new tenant, select **Associate another Azure AD tenant**, then follow the steps indicated above.</span></span> <span data-ttu-id="79917-139">関連付ける Azure AD テナントの資格情報が求められる点に注意してください。</span><span class="sxs-lookup"><span data-stu-id="79917-139">Note that you will be prompted for your credentials in the Azure AD tenant that you want to associate.</span></span>


### <a name="remove-an-azure-ad-tenant-from-your-dev-center-account"></a><span data-ttu-id="79917-140">デベロッパー センター アカウントからの Azure AD テナントの削除</span><span class="sxs-lookup"><span data-stu-id="79917-140">Remove an Azure AD tenant from your Dev Center account</span></span>

<span data-ttu-id="79917-141">デベロッパー センター アカウントの**マネージャー** ロールを持つユーザーは、Azure AD テナントをアカウントから削除することができます。</span><span class="sxs-lookup"><span data-stu-id="79917-141">Any user who has the **Manager** role for a Dev Center account can remove Azure AD tenants from the account.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="79917-142">テナントを削除すると、そのテナントからデベロッパー センター アカウントに追加されたすべてのユーザーはアカウントにサインインできなくなります。</span><span class="sxs-lookup"><span data-stu-id="79917-142">When you remove a tenant, all users that were added to the Dev Center account from that tenant will no longer be able to sign in to the account.</span></span> 

<span data-ttu-id="79917-143">テナントを削除するには、**[テナント]** ページでその名前を検索し、**[削除]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="79917-143">To remove a tenant, find its name on the **Tenants** page, then select **Remove**.</span></span> <span data-ttu-id="79917-144">テナントの削除を確認するメッセージが表示されます。</span><span class="sxs-lookup"><span data-stu-id="79917-144">You’ll be prompted to confirm that you want to remove the tenant.</span></span> <span data-ttu-id="79917-145">これを行うと、そのテナント内のどのデベロッパー センター ユーザーもデベロッパー センター アカウントにログインできなくなり、それらのユーザー用に構成したすべてのアクセス許可が削除されます。</span><span class="sxs-lookup"><span data-stu-id="79917-145">Once you do so, no Dev Center users in that tenant will be able to sign into the Dev Center account, and any permissions you have configured for those users will be removed.</span></span>

> [!TIP]
> <span data-ttu-id="79917-146">現在、同じテナントのアカウントを使ってデベロッパー センターにサインインしている場合、テナントを削除することはできません。</span><span class="sxs-lookup"><span data-stu-id="79917-146">You can’t remove a tenant if you are currently signed into Dev Center using an account in the same tenant.</span></span> <span data-ttu-id="79917-147">テナントを削除するには、アカウントに関連付けられた別のテナントの**マネージャー**としてデベロッパー センターにサインインする必要があります。</span><span class="sxs-lookup"><span data-stu-id="79917-147">To remove a tenant, you must sign in to Dev Center as an **Manager** for another tenant that is associated with the account.</span></span> <span data-ttu-id="79917-148">アカウントにテナントが 1 つだけ関連付けられている場合、アカウントを開いた Microsoft アカウントを使ってサインインした後のみそのテナントを削除できます。</span><span class="sxs-lookup"><span data-stu-id="79917-148">If there is only one tenant associated with the account, that tenant can only be removed after signing in with the Microsoft account that opened the account.</span></span>


