---
author: jnHs
Description: "アカウント ユーザーを追加および管理するには、まずデベロッパー センター アカウントを組織の Azure Active Directory に関連付けます。"
title: "Azure Active Directory とデベロッパー センター アカウントとの関連付け"
ms.author: wdg-dev-content
ms.date: 07/17/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp
ms.openlocfilehash: ace9470cc707206461baa8c3dd72828ea68a8eb4
ms.sourcegitcommit: eaacc472317eef343b764d17e57ef24389dd1cc3
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/17/2017
---
# <a name="associate-azure-active-directory-with-your-dev-center-account"></a><span data-ttu-id="4b861-104">Azure Active Directory とデベロッパー センター アカウントとの関連付け</span><span class="sxs-lookup"><span data-stu-id="4b861-104">Associate Azure Active Directory with your Dev Center account</span></span>

<span data-ttu-id="4b861-105">[アカウント ユーザーを追加および管理](add-users-groups-and-azure-ad-applications.md)するには、まずデベロッパー センター アカウントを組織の Azure Active Directory に関連付けます。</span><span class="sxs-lookup"><span data-stu-id="4b861-105">In order to [add and manage account users](add-users-groups-and-azure-ad-applications.md), you must first associate your Dev Center account with your organization's Azure Active Directory.</span></span> 

<span data-ttu-id="4b861-106">Windows デベロッパー センターでは、複数のユーザーの管理と役割の割り当てに Azure AD を利用します。</span><span class="sxs-lookup"><span data-stu-id="4b861-106">Windows Dev Center leverages Azure AD for multi-user management and roles assignment.</span></span> <span data-ttu-id="4b861-107">組織で Office 365 または Microsoft の他のビジネス サービスが既に使用されている場合は、既に Azure AD をお持ちです。</span><span class="sxs-lookup"><span data-stu-id="4b861-107">If your organization already uses Office 365 or other business services from Microsoft, you already have Azure AD.</span></span> <span data-ttu-id="4b861-108">それ以外の場合は、デベロッパー センター内から新しい Azure AD テナントを追加料金なしで作成できます。</span><span class="sxs-lookup"><span data-stu-id="4b861-108">Otherwise, you can create a new Azure AD tenant from within Dev Center at no additional charge.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="4b861-109">Azure AD とデベロッパー センター アカウントを関連付けるには、Azure AD テナントに[全体管理者](http://go.microsoft.com/fwlink/?LinkId=746654)アカウントでサインインする必要があります。</span><span class="sxs-lookup"><span data-stu-id="4b861-109">To associate Azure AD with your Dev Center account, you will need to sign in to your Azure AD tenant with a [global administrator](http://go.microsoft.com/fwlink/?LinkId=746654) account.</span></span>
> 
> <span data-ttu-id="4b861-110">アカウント ユーザーを追加および管理するには、デベロッパー センター アカウントを Azure AD に関連付けた後、必ず Azure AD グローバル管理者アカウント (個人の Microsoft アカウントではありません) を使ってデベロッパー センターにサインインする必要があります。</span><span class="sxs-lookup"><span data-stu-id="4b861-110">After you associate your Dev Center account with Azure AD, you’ll always need sign in to Dev Center using the Azure AD global administrator account (and not a personal Microsoft account) in order to add and manage account users.</span></span>

<span data-ttu-id="4b861-111">Azure AD テナントに関連付けることができるデベロッパー センター アカウントは 1 つのみであることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="4b861-111">Note that only one Dev Center account can be associated with an Azure AD tenant.</span></span> <span data-ttu-id="4b861-112">同様に、デベロッパー センター アカウントに関連付けることができる Azure AD テナントは 1 つのみです。</span><span class="sxs-lookup"><span data-stu-id="4b861-112">Similarly, only one Azure AD tenant can be associated with a Dev Center account.</span></span> <span data-ttu-id="4b861-113">一度関連付けを確立すると、関連付けを解除するには、必ずサポートへの問い合わせが必要になります。</span><span class="sxs-lookup"><span data-stu-id="4b861-113">Once you establish the association, you won't be able to remove it without contacting support.</span></span>


## <a name="associate-your-dev-center-account-with-your-organizations-existing-azure-ad-tenant"></a><span data-ttu-id="4b861-114">デベロッパー センター アカウントと組織の既存の Azure AD テナントを関連付ける</span><span class="sxs-lookup"><span data-stu-id="4b861-114">Associate your Dev Center account with your organization’s existing Azure AD tenant</span></span>

<span data-ttu-id="4b861-115">組織で既に Azure AD が使用されている場合は、次の手順に従ってデベロッパー センター アカウントをリンクします。</span><span class="sxs-lookup"><span data-stu-id="4b861-115">If your organization already uses Azure AD, follow these steps to link your Dev Center account.</span></span>

1.  <span data-ttu-id="4b861-116">**[アカウント設定]** に移動して、**[ユーザーの管理]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="4b861-116">Go to your **Account settings** and click **Manage users**.</span></span>
2.  <span data-ttu-id="4b861-117">**[Azure AD をデベロッパー センター アカウントに関連付ける]** ボタンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="4b861-117">Click the **Associate Azure AD with your Dev Center account** button.</span></span>
3.  <span data-ttu-id="4b861-118">Azure AD アカウントにサインインします。</span><span class="sxs-lookup"><span data-stu-id="4b861-118">Sign in to your Azure AD account.</span></span> <span data-ttu-id="4b861-119">関連付けを設定するには、このアカウントに[全体管理者](http://go.microsoft.com/fwlink/?LinkId=746654)のアクセス許可が割り当てらレ低流必要があります。</span><span class="sxs-lookup"><span data-stu-id="4b861-119">This account must have [global administrator](http://go.microsoft.com/fwlink/?LinkId=746654) permission in order to set up the association.</span></span>
4.  <span data-ttu-id="4b861-120">Azure AD テナントの組織とドメイン名を確認します。</span><span class="sxs-lookup"><span data-stu-id="4b861-120">Review the organization and domain name for your Azure AD tenant.</span></span> <span data-ttu-id="4b861-121">関連付けを完了するには、**[確認]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="4b861-121">To complete the association, click **Confirm**.</span></span>
5.  <span data-ttu-id="4b861-122">関連付けができたら、デベロッパー センターの **[ユーザーの管理]** ページで、いつでもアカウント ユーザーを追加して管理することができます。</span><span class="sxs-lookup"><span data-stu-id="4b861-122">If the association is successful, you will then be ready to add and manage account users in the **Manage users** section in Dev Center.</span></span>


## <a name="create-a-brand-new-azure-ad-to-associate-with-your-dev-center-account"></a><span data-ttu-id="4b861-123">デベロッパー センター アカウントに関連付ける新しい Azure AD を作成する</span><span class="sxs-lookup"><span data-stu-id="4b861-123">Create a brand new Azure AD to associate with your Dev Center account</span></span>

<span data-ttu-id="4b861-124">デベロッパー センター アカウントをリンクする Azure AD を準備する必要がある場合は、次の手順に従います。</span><span class="sxs-lookup"><span data-stu-id="4b861-124">If you need to set up a new Azure AD to link with your Dev Center account, follow these steps.</span></span>

1.  <span data-ttu-id="4b861-125">**[アカウント設定]** に移動して、**[ユーザーの管理]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="4b861-125">Go to your **Account settings** and click **Manage users**.</span></span>
2.  <span data-ttu-id="4b861-126">**[新しい Azure AD の作成]** ボタンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="4b861-126">Click the **Create new Azure AD** button.</span></span>
3.  <span data-ttu-id="4b861-127">新しい Azure AD のディレクトリ情報を入力します。</span><span class="sxs-lookup"><span data-stu-id="4b861-127">Enter the directory information for your new Azure AD:</span></span>
 - <span data-ttu-id="4b861-128">**[ドメイン名]**: ".onmicrosoft.com" との組み合わせで Azure AD ドメインを示す一意の名前。</span><span class="sxs-lookup"><span data-stu-id="4b861-128">**Domain name**: The unique name that we’ll use for your Azure AD domain, along with “.onmicrosoft.com”.</span></span> <span data-ttu-id="4b861-129">たとえば、「example」と入力した場合、Azure AD ドメインは "example.onmicrosoft.com" になります。</span><span class="sxs-lookup"><span data-stu-id="4b861-129">For example, if you entered “example”, your Azure AD domain would be “example.onmicrosoft.com”.</span></span>
 - <span data-ttu-id="4b861-130">**[連絡先の電子メール]**: アカウントに関して連絡が必要になったときに連絡可能なメール アドレス。</span><span class="sxs-lookup"><span data-stu-id="4b861-130">**Contact email**: An email address where we can contact you about your account if necessary.</span></span>
 - <span data-ttu-id="4b861-131">**[全体管理者のユーザー アカウント]**: 新しい全体管理者アカウントに使用する名、姓、ユーザー名、およびパスワード。</span><span class="sxs-lookup"><span data-stu-id="4b861-131">**Global administrator user account info**: The first name, last name, username, and password that you want to use for the new global administrator account.</span></span>
4.  <span data-ttu-id="4b861-132">**[作成]** をクリックして、新しいドメインとアカウントの情報を確定します。</span><span class="sxs-lookup"><span data-stu-id="4b861-132">Click **Create** to confirm the new domain and account info.</span></span>
5.  <span data-ttu-id="4b861-133">新しい Azure AD 全体管理者のユーザー名とパスワードでサインインすると、[追加のアカウント ユーザーを追加および管理](add-users-groups-and-azure-ad-applications.md)を開始できます。</span><span class="sxs-lookup"><span data-stu-id="4b861-133">Sign in with your new Azure AD global administrator username and password to begin [adding and managing additional account users](add-users-groups-and-azure-ad-applications.md).</span></span>



