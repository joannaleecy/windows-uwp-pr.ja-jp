---
Description: 追加し、アカウントのユーザーを管理するために、組織の Azure Active Directory で最初に、パートナー センター アカウントを関連付ける必要があります。
title: Azure Active Directory をパートナー センター アカウントに関連付ける
ms.date: 10/31/2018
ms.topic: article
keywords: windows 10, uwp, azure ad, azure テナント, aad テナント, azure ad テナント, テナント管理, テナント
ms.localizationpriority: medium
ms.openlocfilehash: aacfdb0044fa9b9368ecbd032629ed5e572ece99
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57605317"
---
# <a name="associate-azure-active-directory-with-your-partner-center-account"></a><span data-ttu-id="a8550-104">Azure Active Directory をパートナー センター アカウントに関連付ける</span><span class="sxs-lookup"><span data-stu-id="a8550-104">Associate Azure Active Directory with your Partner Center account</span></span>

<span data-ttu-id="a8550-105">[を追加し、アカウントのユーザーを管理する](add-users-groups-and-azure-ad-applications.md)、最初に、組織の Azure Active Directory で、パートナー センター アカウントを関連付ける必要があります。</span><span class="sxs-lookup"><span data-stu-id="a8550-105">In order to [add and manage account users](add-users-groups-and-azure-ad-applications.md), you must first associate your Partner Center account with your organization's Azure Active Directory.</span></span> 

<span data-ttu-id="a8550-106">[パートナー センター](https://partner.microsoft.com/dashboard)マルチ ユーザー アカウントのアクセスと管理のために Azure AD を活用します。</span><span class="sxs-lookup"><span data-stu-id="a8550-106">[Partner Center](https://partner.microsoft.com/dashboard) leverages Azure AD for multi-user account access and management.</span></span> <span data-ttu-id="a8550-107">組織で Office 365 または Microsoft の他のビジネス サービスが既に使用されている場合は、既に Azure AD をお持ちです。</span><span class="sxs-lookup"><span data-stu-id="a8550-107">If your organization already uses Office 365 or other business services from Microsoft, you already have Azure AD.</span></span> <span data-ttu-id="a8550-108">それ以外の場合、作成、新しい Azure AD テナントからパートナー センター内で無料になります。</span><span class="sxs-lookup"><span data-stu-id="a8550-108">Otherwise, you can create a new Azure AD tenant from within Partner Center at no additional charge.</span></span>

> [!TIP]
> <span data-ttu-id="a8550-109">このトピックでは、Windows アプリ開発者プログラムに特定されて[パートナー センター](https://partner.microsoft.com/dashboard)、Windows デスクトップ アプリケーションにアカウントのテナントに関連付けると、ユーザーの管理は同様に (を参照してください[Windowsデスクトップ アプリケーション プログラム](https://docs.microsoft.com/windows/desktop/appxpkg/windows-desktop-application-program#add-and-manage-account-users)詳細については) と、Windows ハードウェア開発者プログラム (場所への参照、 **Manager**ロールとハードウェアのアカウントにも適用、**管理者**ロール; を参照してください[ダッシュ ボード管理](https://docs.microsoft.com/windows-hardware/drivers/dashboard/dashboard-administration)の詳細)。</span><span class="sxs-lookup"><span data-stu-id="a8550-109">This topic is specific to the Windows apps developer program in [Partner Center](https://partner.microsoft.com/dashboard), but associating a tenant and managing users works similarly for accounts in the Windows Desktop Application Program (see [Windows Desktop Application Program](https://docs.microsoft.com/windows/desktop/appxpkg/windows-desktop-application-program#add-and-manage-account-users) for more info) and in the Windows Hardware Developer Program (where references to the **Manager** role would also apply to Hardware accounts with the **Administrator** role; see [Dashboard Administration](https://docs.microsoft.com/windows-hardware/drivers/dashboard/dashboard-administration) for more info).</span></span>

<span data-ttu-id="a8550-110">1 つの Azure AD テナントが複数のパートナー センター アカウントに関連付けることができます。</span><span class="sxs-lookup"><span data-stu-id="a8550-110">A single Azure AD tenant can be associated with multiple Partner Center accounts.</span></span> <span data-ttu-id="a8550-111">複数のアカウント ユーザーを追加するには、パートナー センター アカウントに関連付けられている 1 つの Azure AD テナントを設定するだけで済みますが、1 つのパートナー センター アカウントに複数の Azure AD テナントを追加するオプションもあります。</span><span class="sxs-lookup"><span data-stu-id="a8550-111">You only need to have one Azure AD tenant associated with your Partner Center account in order to add multiple account users, but you also have the option to add multiple Azure AD tenants to a single Partner Center account.</span></span> <span data-ttu-id="a8550-112">すべてのユーザーが、 **Manager**ロール、パートナー センター アカウントには追加し、アカウントから Azure AD テナントを削除することが可能です。</span><span class="sxs-lookup"><span data-stu-id="a8550-112">Any user with the **Manager** role in the Partner Center account will have the option to add and remove Azure AD tenants from the account.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="a8550-113">パートナー センター アカウントを関連付けるには、Azure AD テナントと、追加し、そのテナント内のアカウント ユーザーを管理するためにする必要があります、同じテナントを持つユーザーとして、パートナー センターにサインインする、 **Manager**ロール。</span><span class="sxs-lookup"><span data-stu-id="a8550-113">After you associate your Partner Center account with your Azure AD tenant, in order to add and manage account users in that tenant, you’ll need to sign in to Partner Center as a user in the same tenant who has the **Manager** role.</span></span>


## <a name="associate-your-partner-center-account-with-your-organizations-existing-azure-ad-tenant"></a><span data-ttu-id="a8550-114">パートナー センター アカウントを組織の既存の Azure AD テナントに関連付ける</span><span class="sxs-lookup"><span data-stu-id="a8550-114">Associate your Partner Center account with your organization’s existing Azure AD tenant</span></span>

<span data-ttu-id="a8550-115">組織が既に Azure AD を使用する場合は、パートナー センター アカウントをリンクする次の手順に従います。</span><span class="sxs-lookup"><span data-stu-id="a8550-115">If your organization already uses Azure AD, follow these steps to link your Partner Center account.</span></span>

1.  <span data-ttu-id="a8550-116">[パートナー センター](https://partner.microsoft.com/dashboard)、ダッシュ ボードの上部の右下隅) の近くの歯車アイコンを選択し、[**開発者設定が**します。</span><span class="sxs-lookup"><span data-stu-id="a8550-116">From [Partner Center](https://partner.microsoft.com/dashboard), select the gear icon (near the upper right corner of the dashboard) and then select **Developer settings**.</span></span> <span data-ttu-id="a8550-117">**設定**メニューの **テナント**します。</span><span class="sxs-lookup"><span data-stu-id="a8550-117">In the **Settings** menu, select **Tenants**.</span></span>
2.  <span data-ttu-id="a8550-118">選択**Azure AD に関連付けられた、パートナー センター アカウント**します。</span><span class="sxs-lookup"><span data-stu-id="a8550-118">Select **Associate Azure AD with your Partner Center account**.</span></span>
3.  <span data-ttu-id="a8550-119">関連付けるテナントの Azure AD 資格情報を入力します。</span><span class="sxs-lookup"><span data-stu-id="a8550-119">Enter your Azure AD credentials for the tenant that you want to associate.</span></span>
4.  <span data-ttu-id="a8550-120">Azure AD テナントの組織とドメイン名を確認します。</span><span class="sxs-lookup"><span data-stu-id="a8550-120">Review the organization and domain name for your Azure AD tenant.</span></span> <span data-ttu-id="a8550-121">関連付けを完了するには、**[確認]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="a8550-121">To complete the association, select **Confirm**.</span></span>
5.  <span data-ttu-id="a8550-122">追加し、アカウントのユーザーを管理する準備ができます、アソシエーションが成功した場合、**ユーザー**パートナー センターの「します。</span><span class="sxs-lookup"><span data-stu-id="a8550-122">If the association is successful, you will then be ready to add and manage account users in the **Users** section in Partner Center.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="a8550-123">新しいユーザーを作成したり、Azure AD に他の変更を加えたりするには、[グローバル管理者のアクセス許可](https://docs.microsoft.com/azure/active-directory/users-groups-roles/directory-assign-admin-roles)を持つアカウントを使ってその Azure AD にサインインする必要があります。</span><span class="sxs-lookup"><span data-stu-id="a8550-123">In order to create new users, or make other changes to your Azure AD, you’ll need to sign in to that Azure AD tenant using an account which has [global administrator permission](https://docs.microsoft.com/azure/active-directory/users-groups-roles/directory-assign-admin-roles) for that tenant.</span></span> <span data-ttu-id="a8550-124">ただし、またはそのテナントで、パートナー センター アカウントに既に存在するユーザーを追加する、テナントを関連付けるためには、グローバル管理者のアクセス許可を必要はありません。</span><span class="sxs-lookup"><span data-stu-id="a8550-124">However, you don’t need global administrator permission in order to associate the tenant, or to add users who already exist in that tenant to your Partner Center account.</span></span>


## <a name="create-a-brand-new-azure-ad-to-associate-with-your-partner-center-account"></a><span data-ttu-id="a8550-125">パートナー センター アカウントに関連付ける新しい Azure AD を作成します。</span><span class="sxs-lookup"><span data-stu-id="a8550-125">Create a brand new Azure AD to associate with your Partner Center account</span></span>

<span data-ttu-id="a8550-126">パートナー センター アカウントとリンクする新しい Azure AD を設定する必要がある場合は次の手順に従います。</span><span class="sxs-lookup"><span data-stu-id="a8550-126">If you need to set up a new Azure AD to link with your Partner Center account, follow these steps.</span></span>

1.  <span data-ttu-id="a8550-127">[パートナー センター](https://partner.microsoft.com/dashboard)、ダッシュ ボードの上部の右下隅) の近くの歯車アイコンを選択し、[**開発者設定が**します。</span><span class="sxs-lookup"><span data-stu-id="a8550-127">From [Partner Center](https://partner.microsoft.com/dashboard), select the gear icon (near the upper right corner of the dashboard) and then select **Developer settings**.</span></span> <span data-ttu-id="a8550-128">**設定**メニューの **テナント**します。</span><span class="sxs-lookup"><span data-stu-id="a8550-128">In the **Settings** menu, select **Tenants**.</span></span>
2.  <span data-ttu-id="a8550-129">**[新しい Azure AD の作成]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="a8550-129">Select **Create new Azure AD**.</span></span>
3.  <span data-ttu-id="a8550-130">新しい Azure AD のディレクトリ情報を入力します。</span><span class="sxs-lookup"><span data-stu-id="a8550-130">Enter the directory information for your new Azure AD:</span></span>
    - <span data-ttu-id="a8550-131">**ドメイン名**:と共に、Azure AD ドメインを使用する一意の名前". onmicrosoft.com"。</span><span class="sxs-lookup"><span data-stu-id="a8550-131">**Domain name**: The unique name that we’ll use for your Azure AD domain, along with “.onmicrosoft.com”.</span></span> <span data-ttu-id="a8550-132">たとえば、「example」と入力した場合、Azure AD ドメインは "example.onmicrosoft.com" になります。</span><span class="sxs-lookup"><span data-stu-id="a8550-132">For example, if you entered “example”, your Azure AD domain would be “example.onmicrosoft.com”.</span></span>
    - <span data-ttu-id="a8550-133">**連絡先の電子メール**:電子メール アドレスをお送りするため、アカウントに関する必要な場合。</span><span class="sxs-lookup"><span data-stu-id="a8550-133">**Contact email**: An email address where we can contact you about your account if necessary.</span></span>
    - <span data-ttu-id="a8550-134">**グローバル管理者ユーザー アカウント情報**:名、姓、ユーザー名、および新しいのグローバル管理者アカウントを使用するパスワード。</span><span class="sxs-lookup"><span data-stu-id="a8550-134">**Global administrator user account info**: The first name, last name, username, and password that you want to use for the new global administrator account.</span></span>
4.  <span data-ttu-id="a8550-135">**[作成]** をクリックして、新しいドメインとアカウントの情報を確定します。</span><span class="sxs-lookup"><span data-stu-id="a8550-135">Click **Create** to confirm the new domain and account info.</span></span>
5.  <span data-ttu-id="a8550-136">新しい Azure AD 全体管理者のユーザー名とパスワードでサインインすると、[追加のアカウント ユーザーを追加および管理](add-users-groups-and-azure-ad-applications.md)を開始できます。</span><span class="sxs-lookup"><span data-stu-id="a8550-136">Sign in with your new Azure AD global administrator username and password to begin [adding and managing additional account users](add-users-groups-and-azure-ad-applications.md).</span></span>


## <a name="manage-azure-ad-tenant-associations"></a><span data-ttu-id="a8550-137">Azure AD テナントの関連付けの管理</span><span class="sxs-lookup"><span data-stu-id="a8550-137">Manage Azure AD tenant associations</span></span>

<span data-ttu-id="a8550-138">パートナー センター アカウントと Azure AD テナントを関連付けた後は、新しいテナントを追加または既存のテナントからの削除、**テナント**ページ。</span><span class="sxs-lookup"><span data-stu-id="a8550-138">After you have associated an Azure AD tenant with your Partner Center account, you can add new tenants or remove existing tenants from the **Tenants** page.</span></span>


### <a name="add-multiple-azure-ad-tenants-to-your-partner-center-account"></a><span data-ttu-id="a8550-139">パートナー センター アカウントに複数の Azure AD テナントを追加します。</span><span class="sxs-lookup"><span data-stu-id="a8550-139">Add multiple Azure AD tenants to your Partner Center account</span></span>

<span data-ttu-id="a8550-140">あるユーザーに対して、 **Manager**パートナー センター アカウントのロールは、アカウントを使用して Azure AD テナントを関連付けることができます。</span><span class="sxs-lookup"><span data-stu-id="a8550-140">Any user who has the **Manager** role for a Partner Center account can associate Azure AD tenants with the account.</span></span>

<span data-ttu-id="a8550-141">新しいテナントを関連付けるには、**[別の Azure AD テナントの関連付け]** を選び、上記の手順に従います。</span><span class="sxs-lookup"><span data-stu-id="a8550-141">To associate a new tenant, select **Associate another Azure AD tenant**, then follow the steps indicated above.</span></span> <span data-ttu-id="a8550-142">関連付ける Azure AD テナントの資格情報が求められる点に注意してください。</span><span class="sxs-lookup"><span data-stu-id="a8550-142">Note that you will be prompted for your credentials in the Azure AD tenant that you want to associate.</span></span>


### <a name="remove-an-azure-ad-tenant-from-your-partner-center-account"></a><span data-ttu-id="a8550-143">パートナー センター アカウントから Azure AD テナントを削除します。</span><span class="sxs-lookup"><span data-stu-id="a8550-143">Remove an Azure AD tenant from your Partner Center account</span></span>

<span data-ttu-id="a8550-144">あるユーザーに対して、 **Manager**パートナー センター アカウントのロールは、アカウントからの Azure AD テナントを削除することができます。</span><span class="sxs-lookup"><span data-stu-id="a8550-144">Any user who has the **Manager** role for a Partner Center account can remove Azure AD tenants from the account.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="a8550-145">テナントを削除すると、パートナー センター アカウントにそのテナントから追加されたすべてのユーザーは、アカウントにサインインすることできなきます。</span><span class="sxs-lookup"><span data-stu-id="a8550-145">When you remove a tenant, all users that were added to the Partner Center account from that tenant will no longer be able to sign in to the account.</span></span> 

<span data-ttu-id="a8550-146">テナントを削除するには、上の名前を検索、**テナント**ページ (で**アカウント設定**) を選択し、**削除**します。</span><span class="sxs-lookup"><span data-stu-id="a8550-146">To remove a tenant, find its name on the **Tenants** page (in **Account settings**), then select **Remove**.</span></span> <span data-ttu-id="a8550-147">テナントの削除を確認するメッセージが表示されます。</span><span class="sxs-lookup"><span data-stu-id="a8550-147">You’ll be prompted to confirm that you want to remove the tenant.</span></span> <span data-ttu-id="a8550-148">そうと、パートナー センター アカウントにサインインすることはそのテナント内のユーザーはありませんし、それらのユーザー用に構成したすべてのアクセス許可は削除されます。</span><span class="sxs-lookup"><span data-stu-id="a8550-148">Once you do so, no users in that tenant will be able to sign into the Partner Center account, and any permissions you have configured for those users will be removed.</span></span>

> [!TIP]
> <span data-ttu-id="a8550-149">現在にサインインするパートナー センター アカウントを使用して、同じテナント内の場合は、テナントを削除できません。</span><span class="sxs-lookup"><span data-stu-id="a8550-149">You can’t remove a tenant if you are currently signed into Partner Center using an account in the same tenant.</span></span> <span data-ttu-id="a8550-150">テナントを削除するにはパートナー センターにサインインする必要があります、 **Manager**アカウントに関連付けられている別のテナント。</span><span class="sxs-lookup"><span data-stu-id="a8550-150">To remove a tenant, you must sign in to Partner Center as an **Manager** for another tenant that is associated with the account.</span></span> <span data-ttu-id="a8550-151">アカウントにテナントが 1 つだけ関連付けられている場合、アカウントを開いた Microsoft アカウントを使ってサインインした後のみそのテナントを削除できます。</span><span class="sxs-lookup"><span data-stu-id="a8550-151">If there is only one tenant associated with the account, that tenant can only be removed after signing in with the Microsoft account that opened the account.</span></span>


