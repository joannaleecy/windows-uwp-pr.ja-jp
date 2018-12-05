---
Description: In order to add and manage account users, you must first associate your Partner Center account with your organization's Azure Active Directory.
title: パートナー センターのアカウントを Azure Active Directory を関連付ける
ms.date: 10/31/2018
ms.topic: article
keywords: windows 10, uwp, azure ad, azure テナント, aad テナント, azure ad テナント, テナント管理, テナント
ms.localizationpriority: medium
ms.openlocfilehash: 9f807799740d7e832da2f6a6fa3ea63e00deaee4
ms.sourcegitcommit: c01c29cd97f1cbf050950526e18e15823b6a12a0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/05/2018
ms.locfileid: "8706608"
---
# <a name="associate-azure-active-directory-with-your-partner-center-account"></a><span data-ttu-id="226d4-103">パートナー センターのアカウントを Azure Active Directory を関連付ける</span><span class="sxs-lookup"><span data-stu-id="226d4-103">Associate Azure Active Directory with your Partner Center account</span></span>

<span data-ttu-id="226d4-104">アカウント ユーザーを[追加および管理](add-users-groups-and-azure-ad-applications.md)の順序で、組織の Azure Active Directory とパートナー センターのアカウントを最初に関連付ける必要があります。</span><span class="sxs-lookup"><span data-stu-id="226d4-104">In order to [add and manage account users](add-users-groups-and-azure-ad-applications.md), you must first associate your Partner Center account with your organization's Azure Active Directory.</span></span> 

<span data-ttu-id="226d4-105">[パートナー センター](https://partner.microsoft.com/dashboard)では、複数のユーザー アカウントのアクセスや管理に Azure AD を活用します。</span><span class="sxs-lookup"><span data-stu-id="226d4-105">[Partner Center](https://partner.microsoft.com/dashboard) leverages Azure AD for multi-user account access and management.</span></span> <span data-ttu-id="226d4-106">組織で Office 365 または Microsoft の他のビジネス サービスが既に使用されている場合は、既に Azure AD をお持ちです。</span><span class="sxs-lookup"><span data-stu-id="226d4-106">If your organization already uses Office 365 or other business services from Microsoft, you already have Azure AD.</span></span> <span data-ttu-id="226d4-107">それ以外の場合、作成、新しい Azure AD テナントからパートナー センター内で追加料金なし。</span><span class="sxs-lookup"><span data-stu-id="226d4-107">Otherwise, you can create a new Azure AD tenant from within Partner Center at no additional charge.</span></span>

> [!TIP]
> <span data-ttu-id="226d4-108">このトピックでは、[パートナー センター](https://partner.microsoft.com/dashboard)では、Windows アプリ開発者プログラムに固有ですが、Windows デスクトップ アプリケーション プログラムでのアカウントのテナントの関連付けとユーザーの管理機能同様に ( [Windows デスクトップ アプリケーション プログラム](https://docs.microsoft.com/windows/desktop/appxpkg/windows-desktop-application-program#add-and-manage-account-users)を参照してください。詳しくは) と Windows ハードウェア開発者プログラム (**マネージャー**の役割への参照も**管理者**ロールを持つハードウェア アカウントに適用されます。 詳しくは、[ダッシュ ボードの管理](https://docs.microsoft.com/windows-hardware/drivers/dashboard/dashboard-administration)を参照してください)。</span><span class="sxs-lookup"><span data-stu-id="226d4-108">This topic is specific to the Windows apps developer program in [Partner Center](https://partner.microsoft.com/dashboard), but associating a tenant and managing users works similarly for accounts in the Windows Desktop Application Program (see [Windows Desktop Application Program](https://docs.microsoft.com/windows/desktop/appxpkg/windows-desktop-application-program#add-and-manage-account-users) for more info) and in the Windows Hardware Developer Program (where references to the **Manager** role would also apply to Hardware accounts with the **Administrator** role; see [Dashboard Administration](https://docs.microsoft.com/windows-hardware/drivers/dashboard/dashboard-administration) for more info).</span></span>

<span data-ttu-id="226d4-109">1 つの Azure AD テナントを複数のパートナー センター アカウントに関連付けることができます。</span><span class="sxs-lookup"><span data-stu-id="226d4-109">A single Azure AD tenant can be associated with multiple Partner Center accounts.</span></span> <span data-ttu-id="226d4-110">複数のアカウント ユーザーを追加するために、パートナー センター アカウントに関連付けられている 1 つの Azure AD テナントにのみ必要がありますが、複数の Azure AD テナントを 1 つのパートナー センター アカウントに追加するオプションもあります。</span><span class="sxs-lookup"><span data-stu-id="226d4-110">You only need to have one Azure AD tenant associated with your Partner Center account in order to add multiple account users, but you also have the option to add multiple Azure AD tenants to a single Partner Center account.</span></span> <span data-ttu-id="226d4-111">パートナー センター アカウントに**マネージャー**の役割を持つすべてのユーザーを追加し、アカウントから Azure AD テナントを削除するオプションとなります。</span><span class="sxs-lookup"><span data-stu-id="226d4-111">Any user with the **Manager** role in the Partner Center account will have the option to add and remove Azure AD tenants from the account.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="226d4-112">パートナー センターのアカウントを Azure AD テナントに関連付けることを追加し、そのテナントでアカウント ユーザーを管理するためにする必要があります**マネージャー**の役割を持つ同じテナントのユーザーとしてパートナー センターにサインインします。</span><span class="sxs-lookup"><span data-stu-id="226d4-112">After you associate your Partner Center account with your Azure AD tenant, in order to add and manage account users in that tenant, you’ll need to sign in to Partner Center as a user in the same tenant who has the **Manager** role.</span></span>


## <a name="associate-your-partner-center-account-with-your-organizations-existing-azure-ad-tenant"></a><span data-ttu-id="226d4-113">パートナー センター アカウントと組織の既存の Azure AD テナントを関連付ける</span><span class="sxs-lookup"><span data-stu-id="226d4-113">Associate your Partner Center account with your organization’s existing Azure AD tenant</span></span>

<span data-ttu-id="226d4-114">組織に既に Azure AD を使用した場合は、パートナー センター アカウントにリンクする次の手順に従います。</span><span class="sxs-lookup"><span data-stu-id="226d4-114">If your organization already uses Azure AD, follow these steps to link your Partner Center account.</span></span>

1.  <span data-ttu-id="226d4-115">[パートナー センター](https://partner.microsoft.com/dashboard)では、(ダッシュ ボードの上部の右下隅) 近くにある歯車アイコンを選択し、**開発者向け設定**] を選択します。</span><span class="sxs-lookup"><span data-stu-id="226d4-115">From [Partner Center](https://partner.microsoft.com/dashboard) , select the gear icon (near the upper right corner of the dashboard) and then select **Developer settings**.</span></span> <span data-ttu-id="226d4-116">**設定**メニューで、**テナント**を選択します。</span><span class="sxs-lookup"><span data-stu-id="226d4-116">In the **Settings** menu, select **Tenants**.</span></span>
2.  <span data-ttu-id="226d4-117">**Azure AD をパートナー センター アカウントの関連付け**を選択します。</span><span class="sxs-lookup"><span data-stu-id="226d4-117">Select **Associate Azure AD with your Partner Center account**.</span></span>
3.  <span data-ttu-id="226d4-118">関連付けるテナントの Azure AD 資格情報を入力します。</span><span class="sxs-lookup"><span data-stu-id="226d4-118">Enter your Azure AD credentials for the tenant that you want to associate.</span></span>
4.  <span data-ttu-id="226d4-119">Azure AD テナントの組織とドメイン名を確認します。</span><span class="sxs-lookup"><span data-stu-id="226d4-119">Review the organization and domain name for your Azure AD tenant.</span></span> <span data-ttu-id="226d4-120">関連付けを完了するには、**[確認]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="226d4-120">To complete the association, select **Confirm**.</span></span>
5.  <span data-ttu-id="226d4-121">関連付けが成功した場合は、ことができます追加し、パートナー センターで**ユーザー**のセクションでアカウント ユーザーの管理を準備します。</span><span class="sxs-lookup"><span data-stu-id="226d4-121">If the association is successful, you will then be ready to add and manage account users in the **Users** section in Partner Center.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="226d4-122">新しいユーザーを作成したり、Azure AD に他の変更を加えたりするには、[グローバル管理者のアクセス許可](https://docs.microsoft.com/azure/active-directory/users-groups-roles/directory-assign-admin-roles)を持つアカウントを使ってその Azure AD にサインインする必要があります。</span><span class="sxs-lookup"><span data-stu-id="226d4-122">In order to create new users, or make other changes to your Azure AD, you’ll need to sign in to that Azure AD tenant using an account which has [global administrator permission](https://docs.microsoft.com/azure/active-directory/users-groups-roles/directory-assign-admin-roles) for that tenant.</span></span> <span data-ttu-id="226d4-123">ただし、パートナー センター アカウントにテナントに既に存在しているユーザーを追加するか、テナントを関連付けたり、グローバル管理者のアクセス許可を必要はありません。</span><span class="sxs-lookup"><span data-stu-id="226d4-123">However, you don’t need global administrator permission in order to associate the tenant, or to add users who already exist in that tenant to your Partner Center account.</span></span>


## <a name="create-a-brand-new-azure-ad-to-associate-with-your-partner-center-account"></a><span data-ttu-id="226d4-124">パートナー センター アカウントに関連付ける新しい Azure AD を作成します。</span><span class="sxs-lookup"><span data-stu-id="226d4-124">Create a brand new Azure AD to associate with your Partner Center account</span></span>

<span data-ttu-id="226d4-125">パートナー センター アカウントをリンクする、新しい Azure AD を設定する必要がある場合は次の手順に従います。</span><span class="sxs-lookup"><span data-stu-id="226d4-125">If you need to set up a new Azure AD to link with your Partner Center account, follow these steps.</span></span>

1.  <span data-ttu-id="226d4-126">[パートナー センター](https://partner.microsoft.com/dashboard)では、(ダッシュ ボードの上部の右下隅) 近くにある歯車アイコンを選択し、**開発者向け設定**] を選択します。</span><span class="sxs-lookup"><span data-stu-id="226d4-126">From [Partner Center](https://partner.microsoft.com/dashboard), select the gear icon (near the upper right corner of the dashboard) and then select **Developer settings**.</span></span> <span data-ttu-id="226d4-127">**設定**メニューで、**テナント**を選択します。</span><span class="sxs-lookup"><span data-stu-id="226d4-127">In the **Settings** menu, select **Tenants**.</span></span>
2.  <span data-ttu-id="226d4-128">**[新しい Azure AD の作成]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="226d4-128">Select **Create new Azure AD**.</span></span>
3.  <span data-ttu-id="226d4-129">新しい Azure AD のディレクトリ情報を入力します。</span><span class="sxs-lookup"><span data-stu-id="226d4-129">Enter the directory information for your new Azure AD:</span></span>
    - <span data-ttu-id="226d4-130">**[ドメイン名]**: ".onmicrosoft.com" との組み合わせで Azure AD ドメインを示す一意の名前。</span><span class="sxs-lookup"><span data-stu-id="226d4-130">**Domain name**: The unique name that we’ll use for your Azure AD domain, along with “.onmicrosoft.com”.</span></span> <span data-ttu-id="226d4-131">たとえば、「example」と入力した場合、Azure AD ドメインは "example.onmicrosoft.com" になります。</span><span class="sxs-lookup"><span data-stu-id="226d4-131">For example, if you entered “example”, your Azure AD domain would be “example.onmicrosoft.com”.</span></span>
    - <span data-ttu-id="226d4-132">**[連絡先の電子メール]**: アカウントに関して連絡が必要になったときに連絡可能なメール アドレス。</span><span class="sxs-lookup"><span data-stu-id="226d4-132">**Contact email**: An email address where we can contact you about your account if necessary.</span></span>
    - <span data-ttu-id="226d4-133">**[全体管理者のユーザー アカウント]**: 新しい全体管理者アカウントに使用する名、姓、ユーザー名、およびパスワード。</span><span class="sxs-lookup"><span data-stu-id="226d4-133">**Global administrator user account info**: The first name, last name, username, and password that you want to use for the new global administrator account.</span></span>
4.  <span data-ttu-id="226d4-134">**[作成]** をクリックして、新しいドメインとアカウントの情報を確定します。</span><span class="sxs-lookup"><span data-stu-id="226d4-134">Click **Create** to confirm the new domain and account info.</span></span>
5.  <span data-ttu-id="226d4-135">新しい Azure AD 全体管理者のユーザー名とパスワードでサインインすると、[追加のアカウント ユーザーを追加および管理](add-users-groups-and-azure-ad-applications.md)を開始できます。</span><span class="sxs-lookup"><span data-stu-id="226d4-135">Sign in with your new Azure AD global administrator username and password to begin [adding and managing additional account users](add-users-groups-and-azure-ad-applications.md).</span></span>


## <a name="manage-azure-ad-tenant-associations"></a><span data-ttu-id="226d4-136">Azure AD テナントの関連付けの管理</span><span class="sxs-lookup"><span data-stu-id="226d4-136">Manage Azure AD tenant associations</span></span>

<span data-ttu-id="226d4-137">Azure AD テナントは、パートナー センター アカウントに関連付けられているが後、は、新しいテナントを追加または**テナント**ページから既存のテナントを削除できます。</span><span class="sxs-lookup"><span data-stu-id="226d4-137">After you have associated an Azure AD tenant with your Partner Center account, you can add new tenants or remove existing tenants from the **Tenants** page.</span></span>


### <a name="add-multiple-azure-ad-tenants-to-your-partner-center-account"></a><span data-ttu-id="226d4-138">パートナー センター アカウントに複数の Azure AD テナントを追加します。</span><span class="sxs-lookup"><span data-stu-id="226d4-138">Add multiple Azure AD tenants to your Partner Center account</span></span>

<span data-ttu-id="226d4-139">パートナー センターのアカウント**マネージャー**の役割を持つユーザーは、アカウントでの Azure AD テナントを関連付けることができます。</span><span class="sxs-lookup"><span data-stu-id="226d4-139">Any user who has the **Manager** role for a Partner Center account can associate Azure AD tenants with the account.</span></span>

<span data-ttu-id="226d4-140">新しいテナントを関連付けるには、**[別の Azure AD テナントの関連付け]** を選び、上記の手順に従います。</span><span class="sxs-lookup"><span data-stu-id="226d4-140">To associate a new tenant, select **Associate another Azure AD tenant**, then follow the steps indicated above.</span></span> <span data-ttu-id="226d4-141">関連付ける Azure AD テナントの資格情報が求められる点に注意してください。</span><span class="sxs-lookup"><span data-stu-id="226d4-141">Note that you will be prompted for your credentials in the Azure AD tenant that you want to associate.</span></span>


### <a name="remove-an-azure-ad-tenant-from-your-partner-center-account"></a><span data-ttu-id="226d4-142">パートナー センター アカウントから Azure AD テナントを削除します。</span><span class="sxs-lookup"><span data-stu-id="226d4-142">Remove an Azure AD tenant from your Partner Center account</span></span>

<span data-ttu-id="226d4-143">パートナー センターのアカウント**マネージャー**の役割を持つユーザーは、アカウントから Azure AD テナントを削除することができます。</span><span class="sxs-lookup"><span data-stu-id="226d4-143">Any user who has the **Manager** role for a Partner Center account can remove Azure AD tenants from the account.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="226d4-144">テナントを削除すると、そのテナントからパートナー センター アカウントに追加されたすべてのユーザーしなくなるアカウントにサインインすることです。</span><span class="sxs-lookup"><span data-stu-id="226d4-144">When you remove a tenant, all users that were added to the Partner Center account from that tenant will no longer be able to sign in to the account.</span></span> 

<span data-ttu-id="226d4-145">テナントを削除するには、**テナント**] ページ (**アカウントの設定**) でその名前を検索し、**削除**を選択します。</span><span class="sxs-lookup"><span data-stu-id="226d4-145">To remove a tenant, find its name on the **Tenants** page (in **Account settings**), then select **Remove**.</span></span> <span data-ttu-id="226d4-146">テナントの削除を確認するメッセージが表示されます。</span><span class="sxs-lookup"><span data-stu-id="226d4-146">You’ll be prompted to confirm that you want to remove the tenant.</span></span> <span data-ttu-id="226d4-147">これを行うと、そのテナント内のユーザーは、パートナー センター アカウントにサインインできなくし、それらのユーザー用に構成したすべてのアクセス許可は削除されます。</span><span class="sxs-lookup"><span data-stu-id="226d4-147">Once you do so, no users in that tenant will be able to sign into the Partner Center account, and any permissions you have configured for those users will be removed.</span></span>

> [!TIP]
> <span data-ttu-id="226d4-148">現在サインインしているパートナー センターに同じテナントのアカウントを使っている場合は、テナントを削除することはできません。</span><span class="sxs-lookup"><span data-stu-id="226d4-148">You can’t remove a tenant if you are currently signed into Partner Center using an account in the same tenant.</span></span> <span data-ttu-id="226d4-149">テナントを削除するには、必要がありますにサインインするパートナー センター**マネージャー**として別のテナントのアカウントに関連付けられています。</span><span class="sxs-lookup"><span data-stu-id="226d4-149">To remove a tenant, you must sign in to Partner Center as an **Manager** for another tenant that is associated with the account.</span></span> <span data-ttu-id="226d4-150">アカウントにテナントが 1 つだけ関連付けられている場合、アカウントを開いた Microsoft アカウントを使ってサインインした後のみそのテナントを削除できます。</span><span class="sxs-lookup"><span data-stu-id="226d4-150">If there is only one tenant associated with the account, that tenant can only be removed after signing in with the Microsoft account that opened the account.</span></span>


