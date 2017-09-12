---
author: jnHs
Description: "ユーザー、グループ、Azure AD アプリケーションをデベロッパー センター アカウントに追加できます。"
title: "デベロッパー センター アカウントへのユーザー、グループ、Azure AD アプリケーションの追加"
ms.author: wdg-dev-content
ms.date: 07/17/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp
ms.openlocfilehash: 32f62d6022d075e71ce6bcc15e1603a2e11a68a5
ms.sourcegitcommit: 23cda44f10059bcaef38ae73fd1d7c8b8330c95e
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/19/2017
---
# <a name="add-users-groups-and-azure-ad-applications-to-your-dev-center-account"></a><span data-ttu-id="4d7b1-104">デベロッパー センター アカウントへのユーザー、グループ、Azure AD アプリケーションの追加</span><span class="sxs-lookup"><span data-stu-id="4d7b1-104">Add users, groups, and Azure AD applications to your Dev Center account</span></span>

<span data-ttu-id="4d7b1-105">デベロッパー センターの [[ユーザーの管理]](manage-account-users.md) セクションで、Azure Active Directory を使用して、ユーザーをデベロッパー センター アカウントに追加できます。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-105">The [Manage users](manage-account-users.md) section of Dev Center lets you use Azure Active Directory to add users to your Dev Center account.</span></span> <span data-ttu-id="4d7b1-106">各ユーザーには、アカウントへのアクセスを定義する役割 (またはカスタムのアクセス許可のセット) が割り当てられます。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-106">Each user is assigned a role (or set of custom permissions) that defines their access to the account.</span></span> <span data-ttu-id="4d7b1-107">また、[ユーザーのグループ](#groups)や [Azure AD アプリケーション](#azure-ad-applications)を追加して、デベロッパー センターへのアクセスを許可することもできます。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-107">You can also add [groups of users](#groups) and [Azure AD applications](#azure-ad-applications) to grant them access to your Dev Center account.</span></span>

<span data-ttu-id="4d7b1-108">ユーザーをアカウントに追加したら、[アカウントの詳細の編集](#edit)、[役割やアクセス許可](set-custom-permissions-for-account-users.md)の変更、[ユーザーの削除](#remove)を行うことができます。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-108">After users have been added to the account, you can [edit account details](#edit), change [roles and permissions](set-custom-permissions-for-account-users.md), or [remove users](#remove).</span></span>

> [!IMPORTANT]
> <span data-ttu-id="4d7b1-109">アカウントにユーザーを追加するには、まず[デベロッパー センター アカウントを組織の Azure Active Directory テナントに関連付ける](associate-azure-ad-with-dev-center.md)必要があります。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-109">In order to add users to your account, you must first [associate your Dev Center account with your organization's Azure Active Directory tenant](associate-azure-ad-with-dev-center.md).</span></span> 

<span data-ttu-id="4d7b1-110">ユーザーを追加するときは、次の考慮事項に注意してください。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-110">When adding users, keep the following considerations in mind.</span></span> <span data-ttu-id="4d7b1-111">(これらは、個々のユーザーだけでなく、グループや Azure AD アプリケーションにも当てはまります。)</span><span class="sxs-lookup"><span data-stu-id="4d7b1-111">(These apply to groups and Azure AD applications as well as individual users.)</span></span>

-   <span data-ttu-id="4d7b1-112">すべてのデベロッパー センター ユーザーに、組織のディレクトリのアクティブなアカウントが必要です。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-112">All Dev Center users must have an active account in your organization's directory.</span></span> <span data-ttu-id="4d7b1-113">新しいユーザーまたはグループをデベロッパー センターに作成すると、組織の Azure AD テナントにもそのユーザーのアカウントが作成されます。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-113">Creating a new user in Dev Center will also create an account for that user in your organization's Azure AD tenant.</span></span>
-   <span data-ttu-id="4d7b1-114">デベロッパー センターでユーザー名を[変更](#edit)すると、組織の Azure AD テナントも同様に変更されます。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-114">[Making changes](#edit) to a user's name in Dev Center will make the same changes in your organization's Azure AD tenant.</span></span>
-   <span data-ttu-id="4d7b1-115">ユーザーを追加するときは、ユーザーに[役割またはカスタムのアクセス許可のセット](set-custom-permissions-for-account-users.md)を割り当てて、デベロッパー センターへのアクセスを指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-115">When adding users, you will need to specify their access to Dev Center account by assigning them a [role or set of custom permissions](set-custom-permissions-for-account-users.md).</span></span> 

> [!NOTE]
> <span data-ttu-id="4d7b1-116">組織で[ディレクトリ統合](http://go.microsoft.com/fwlink/p/?LinkID=724033)を使って組織内のディレクトリ サービスを Azure AD と同期している場合、デベロッパー センターで新しいユーザー、グループ、Azure AD アプリケーションを作成できなくなります。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-116">If your organization uses [directory integration](http://go.microsoft.com/fwlink/p/?LinkID=724033) to sync the on-premises directory service with your Azure AD, you won't be able to create new users, groups, or Azure AD applications in Dev Center.</span></span> <span data-ttu-id="4d7b1-117">デベロッパー センターで表示および追加するには、組織内のディレクトリ管理者が組織内のディレクトリで直接作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-117">You (or another admin in your on-premises directory) will need to create them directly in the on-premises directory before you'll be able to see and add them in Dev Center.</span></span>


<span id="users" />
## <a name="add-users-to-your-dev-center-account"></a><span data-ttu-id="4d7b1-118">デベロッパー センター アカウントへのユーザーの追加</span><span class="sxs-lookup"><span data-stu-id="4d7b1-118">Add users to your Dev Center account</span></span>

<span data-ttu-id="4d7b1-119">個々のユーザーをデベロッパー センター アカウントに追加するには、次のいずれかの方法を使用します。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-119">You can add individual users to your Dev Center account in any of the following ways:</span></span>
-   <span data-ttu-id="4d7b1-120">既に組織のディレクトリに存在するユーザーを追加する</span><span class="sxs-lookup"><span data-stu-id="4d7b1-120">Add users who already exist in your organization's directory</span></span>
-   <span data-ttu-id="4d7b1-121">組織のディレクトリとデベロッパー センター アカウントの両方に新しいユーザーを作成して追加する</span><span class="sxs-lookup"><span data-stu-id="4d7b1-121">Create a new user to add to both your organization's directory and your Dev Center account</span></span>
-   <span data-ttu-id="4d7b1-122">現在組織のディレクトリに登録されていない既存のユーザーを追加する</span><span class="sxs-lookup"><span data-stu-id="4d7b1-122">Add existing users who are not currently in your organization's directory</span></span>


<span id="from-directory" />
### <a name="add-users-from-your-organizations-directory"></a><span data-ttu-id="4d7b1-123">組織のディレクトリからユーザーを追加する</span><span class="sxs-lookup"><span data-stu-id="4d7b1-123">Add users from your organization's directory</span></span>

1.  <span data-ttu-id="4d7b1-124">**[ユーザーの管理]** ページで、**[ユーザーを追加する]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-124">From the **Manage users** page, click **Add users**.</span></span>
2.  <span data-ttu-id="4d7b1-125">表示された一覧から 1 人以上のユーザーを選びます。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-125">Select one or more users from the list that appears.</span></span> <span data-ttu-id="4d7b1-126">検索ボックスを使うと、特定のユーザーを検索できます。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-126">You can use the search box to search for specific users.</span></span>
    > [!TIP]
    > <span data-ttu-id="4d7b1-127">デベロッパー センターに追加するユーザーを複数選んだ場合は、それらのユーザーに同じ役割またはカスタムのアクセス許可のセットを割り当てなければなりません。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-127">If you select more than one user to add to your Dev Center account, you must assign them the same role or set of custom permissions.</span></span> <span data-ttu-id="4d7b1-128">複数のユーザーを追加し、それぞれ異なる役割まはたアクセス許可を割り当てる場合は、役割またはカスタムのアクセス許可のセットごとに次の手順を繰り返します。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-128">To add multiple users with different roles/permissions, repeat the steps below for each role or set of custom permissions.</span></span>

3.  <span data-ttu-id="4d7b1-129">ユーザーを選んだら、**[選択内容の追加]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-129">When you are finished selecting users, click **Add selected**.</span></span>
4.  <span data-ttu-id="4d7b1-130">**[役割]** セクションで、選んだユーザーに対して[役割またはカスタムのアクセス許可](set-custom-permissions-for-account-users.md)を指定します。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-130">In the **Roles** section, specify the [role(s) or customized permissions](set-custom-permissions-for-account-users.md) for the selected user(s).</span></span>
5.  <span data-ttu-id="4d7b1-131">**[保存]**をクリックします。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-131">Click **Save**.</span></span>


<span id="new-user" />
### <a name="create-a-new-user-account-in-your-organizations-directory-and-add-them-to-your-dev-center-account"></a><span data-ttu-id="4d7b1-132">組織のディレクトリに新しいユーザー アカウントを作成し、デベロッパー センター アカウントに追加する</span><span class="sxs-lookup"><span data-stu-id="4d7b1-132">Create a new user account in your organization's directory and add them to your Dev Center account</span></span>

<span data-ttu-id="4d7b1-133">Azure AD テナントに新しいアカウントを用意してデベロッパー センターへのアクセスを付与する場合は、**[ユーザーの管理]** セクションで **[新しいユーザー]** をクリックしてアカウントを作成できます。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-133">If you want to grant Dev Center access to a brand new account in your Azure AD tenant, you can create one in the **Manage users** section by clicking **New user**.</span></span> 

> [!IMPORTANT]
> <span data-ttu-id="4d7b1-134">ディレクトリに新しいユーザーを追加するには、全体管理者アカウントを使って Azure AD テナントにサインインする必要があります。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-134">You must be signed in with a global administrator account in your Azure AD tenant in order to add new users to the directory.</span></span>

<span data-ttu-id="4d7b1-135">新しいユーザーを組織のディレクトリの[全体管理者アカウント](http://go.microsoft.com/fwlink/p/?LinkId=746654)にする場合には、**[このユーザーを、すべてのディレクトリ リソースに対してフル コントロールを保持する Azure AD の全体管理者として指定します]** チェック ボックスをオンにします。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-135">If you want the new user to have a [global administrator account](http://go.microsoft.com/fwlink/p/?LinkId=746654) in your organization's directory, check the box labeled **Make this user a Global administrator in your Azure AD, with full control over all directory resources**.</span></span> <span data-ttu-id="4d7b1-136">これにより、ユーザーは会社の Azure AD のすべての管理機能に完全にアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-136">This will give the user full access to all administrative features in your company's Azure AD.</span></span> <span data-ttu-id="4d7b1-137">組織のディレクトリにユーザーを追加して管理できるようになります (ただし、デベロッパー センターでは、アカウントに適切な[役割とアクセス許可](set-custom-permissions-for-account-users.md)を付与しない場合にはそれはできません)。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-137">They'll be able to add and manage users in your organization's directory (though not in Dev Center, unless you grant the account the appropriate [role/permissions](set-custom-permissions-for-account-users.md)).</span></span> <span data-ttu-id="4d7b1-138">このチェック ボックスがオンの場合、ユーザーの **[パスワードの回復メール]** を入力する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-138">If you check this box, you'll need to provide a **Password recovery email** for the user.</span></span>

1.  <span data-ttu-id="4d7b1-139">**[ユーザーの管理]** ページで、**[ユーザーを追加する]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-139">From the **Manage users** page, click **Add users**.</span></span>
2.  <span data-ttu-id="4d7b1-140">次のページで、**[新しいユーザー]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-140">On the next page, click **New user**.</span></span>
3.  <span data-ttu-id="4d7b1-141">組織のディレクトリに新しいアカウントを作成し、そのユーザーをデベロッパー センターのアカウントに追加するには、**[Azure AD に追加]** が選択されていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-141">Ensure that the **Add to Azure AD** radio button is selected to create a new account in your organization's directory and add that user to your Dev Center account.</span></span> 
4.  <span data-ttu-id="4d7b1-142">新しいユーザーの姓、名、およびユーザー名を入力します。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-142">Enter the first name, last name, and username for the new user.</span></span>
5.  <span data-ttu-id="4d7b1-143">ユーザーが自分のパスワードを回復する必要がある場合に使用するメール アドレスを入力します。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-143">Enter an email that the user can use if they need to recover their password.</span></span> <span data-ttu-id="4d7b1-144">これは、**[このユーザーを、すべてのディレクトリ リソースに対してフル コントロールを保持する Azure AD の全体管理者として指定します]** チェック ボックスをオンにした場合のみ必須です。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-144">This is only required if you checked the box to **Make this user a Global administrator in your Azure AD**.</span></span>
6.  <span data-ttu-id="4d7b1-145">**[グループ メンバーシップ]** セクションで、新しいユーザーを追加するグループを選びます。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-145">In the **Group membership** section, select any groups to which you want the new user to belong.</span></span>
7.  <span data-ttu-id="4d7b1-146">**[役割]** セクションで、このユーザーの[役割またはカスタムのアクセス許可](set-custom-permissions-for-account-users.md)を指定します。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-146">In the **Roles** section, specify the [role(s) or customized permissions](set-custom-permissions-for-account-users.md) for the user.</span></span>
8.  <span data-ttu-id="4d7b1-147">**[保存]**をクリックします。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-147">Click **Save**.</span></span>
9.  <span data-ttu-id="4d7b1-148">確認ページに、一時的なパスワードなどの新しいユーザーのログイン情報が表示されます。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-148">On the confirmation page, you'll see login info for the new user, including a temporary password.</span></span> <span data-ttu-id="4d7b1-149">必ずこの情報をメモして、新しいユーザーに提供してください。このページを閉じると、一時的なパスワードにはアクセスできなくなります。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-149">Be sure to note this info and provide it to the new user, as you won't be able to access the temporary password after you leave this page.</span></span>


<span id="email" />
### <a name="add-a-user-from-outside-of-your-azure-ad-tenant-to-your-dev-center-account-and-your-directory"></a><span data-ttu-id="4d7b1-150">Azure AD テナント外からユーザーをデベロッパー センター アカウントとディレクトリに追加する</span><span class="sxs-lookup"><span data-stu-id="4d7b1-150">Add a user from outside of your Azure AD tenant to your Dev Center account and your directory</span></span>

<span data-ttu-id="4d7b1-151">現在、Azure AD テナントに追加されていないユーザーをアカウントに招待するには、次の手順を実行してください。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-151">To invite users who aren't currently part of your Azure AD tenant to your account, follow the steps below.</span></span> <span data-ttu-id="4d7b1-152">ユーザーにはアカウントへの参加を求める招待メールが送られ、ユーザー用に新しい[ゲスト ユーザー](https://docs.microsoft.com/azure/active-directory/active-directory-b2b-what-is-azure-ad-b2b) アカウントが Azure AD テナント内に作成されます。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-152">The users will get an email invitation to join their account, and a new [guest user](https://docs.microsoft.com/azure/active-directory/active-directory-b2b-what-is-azure-ad-b2b) account will be created for them in your Azure AD tenant.</span></span> 

1.  <span data-ttu-id="4d7b1-153">**[ユーザーの管理]** ページで、**[ユーザーを追加する]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-153">From the **Manage users** page, click **Add users**.</span></span>
2.  <span data-ttu-id="4d7b1-154">次のページで、**[新しいユーザー]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-154">On the next page, click **New user**.</span></span>
3.  <span data-ttu-id="4d7b1-155">**[メールによるユーザーの招待]** のラジオ ボタンを選択します。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-155">Select the **Invite users by email** radio button.</span></span>
3.  <span data-ttu-id="4d7b1-156">1 つ以上のメール アドレス (最大 10 個) を、コンマまたはセミコロンで区切って入力します。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-156">Enter one or more email addresses (up to ten), separated by commas or semicolons.</span></span>
4.  <span data-ttu-id="4d7b1-157">**[役割]** セクションで、このユーザーの[役割またはカスタムのアクセス許可](set-custom-permissions-for-account-users.md)を指定します。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-157">In the **Roles** section, specify the [role(s) or customized permissions](set-custom-permissions-for-account-users.md) for the user.</span></span>
6.  <span data-ttu-id="4d7b1-158">**[保存]**をクリックします。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-158">Click **Save**.</span></span>

<span data-ttu-id="4d7b1-159">招待されたユーザーには、デベロッパー センター アカウントにアクセスするための招待が記載されたメールが届きます。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-159">The users you've invited will get an email with an invitation to access your Dev Center account.</span></span> <span data-ttu-id="4d7b1-160">各ユーザーは、自分のアカウントにアクセスするには、招待を承諾する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-160">Each user will need to accept their invitation before they can access your account.</span></span>

<span data-ttu-id="4d7b1-161">招待を再送信する必要がある場合は、**[ユーザーの管理]** ページでユーザーを見つけ、メール アドレス (または **[承認待ちの招待]** というテキスト) を選んで、アカウントを編集します。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-161">If you need to resend an invitation, find the user on your **Manage users** page and select their email address (or the text that says **Invitation pending**) to edit the account.</span></span> <span data-ttu-id="4d7b1-162">次に、ページの下部の **[招待状の再送信]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-162">Then, at the bottom of the page, click **Resend invitation**.</span></span>


### <a name="changing-a-users-directory-password"></a><span data-ttu-id="4d7b1-163">ユーザーのディレクトリ パスワードを変更する</span><span class="sxs-lookup"><span data-stu-id="4d7b1-163">Changing a user's directory password</span></span>

<span data-ttu-id="4d7b1-164">デベロッパー センター アカウントに追加したユーザー アカウントのパスワードを変更する必要がある場合、その変更は **[ユーザーの管理]** セクションで行います。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-164">If you need to change a password for a user account that you've added to your Dev Center account, you can do so in the **Manage users** section.</span></span> <span data-ttu-id="4d7b1-165">これにより、ユーザーがデベロッパー センターのアクセスに使うパスワードだけでなく、Azure AD テナントのユーザーのパスワードも変更されることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-165">Note that this will change the user's password in your Azure AD tenant, along with the password they use to access Dev Center.</span></span> 

<span data-ttu-id="4d7b1-166">ユーザー アカウントの作成時に **[パスワードの回復メール]** を入力した場合、ユーザーは自分のパスワードをリセットすることができます。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-166">If you've provided a **Password recovery email** when creating the user account, they will be able to reset their own password.</span></span> <span data-ttu-id="4d7b1-167">次の手順に従って、ユーザーのパスワードを更新することもできます。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-167">You can also update a user's password by following the steps below.</span></span>

1.  <span data-ttu-id="4d7b1-168">**[ユーザーの管理]** ページで、編集するユーザー アカウントの名前をクリックします。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-168">From the **Manage users** page, click the name of the user account that you want to edit.</span></span>
2.  <span data-ttu-id="4d7b1-169">ページの下部にある **[パスワードのリセット]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-169">Click the **Reset password** button at the bottom of the page.</span></span>
3.  <span data-ttu-id="4d7b1-170">確認ページが表示され、一時的なパスワードなどのユーザーのログイン情報が通知されます。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-170">A confirmation page will appear showing the login info for the user, including a temporary password.</span></span>
    > [!IMPORTANT]
    >  <span data-ttu-id="4d7b1-171">必ずこの情報を印刷またはコピーして、ユーザーに提供してください。このページを閉じると、一時的なパスワードにはアクセスできなくなります。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-171">Be sure to print or copy this info and provide it to the user, as you won't be able to access the temporary password after you leave this page.</span></span>

<span id="groups" />
## <a name="add-groups-to-your-dev-center-account"></a><span data-ttu-id="4d7b1-172">デベロッパー センター アカウントへのグループの追加</span><span class="sxs-lookup"><span data-stu-id="4d7b1-172">Add groups to your Dev Center account</span></span>

<span data-ttu-id="4d7b1-173">組織のディレクトリからグループをデベロッパー センター アカウントに追加できます。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-173">You can add a group from your organization's directory to your Dev Center account.</span></span> <span data-ttu-id="4d7b1-174">その場合、グループのメンバーであるユーザー全員が、グループに割り当てられた役割に関連付けられているアクセス許可で、デベロッパー センター アカウントにアクセスできるようになります。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-174">When you do so, every user who is a member of that group will be able to access it, with the permissions associated with the group's assigned role.</span></span>

### <a name="add-groups-from-your-organizations-directory"></a><span data-ttu-id="4d7b1-175">組織のディレクトリからグループを追加する</span><span class="sxs-lookup"><span data-stu-id="4d7b1-175">Add groups from your organization's directory</span></span>

1.  <span data-ttu-id="4d7b1-176">**[ユーザーの管理]** ページで、**[グループの追加]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-176">From the **Manage users** page, click **Add groups**.</span></span>
2.  <span data-ttu-id="4d7b1-177">表示された一覧から 1 つ以上のグループを選びます。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-177">Select one or more groups from the list that appears.</span></span> <span data-ttu-id="4d7b1-178">検索ボックスを使うと、特定のグループを検索できます。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-178">You can use the search box to search for specific groups.</span></span>
    > [!TIP]
    > <span data-ttu-id="4d7b1-179">デベロッパー センターに追加するグループを複数選んだ場合は、それらのグループに同じ役割またはカスタムのアクセス許可のセットを割り当てなければなりません。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-179">If you select more than one group to add to your Dev Center account, you must assign them the same role or set of custom permissions.</span></span> <span data-ttu-id="4d7b1-180">複数のグループを追加し、それぞれ異なる役割まはたアクセス許可を割り当てる場合は、役割またはカスタムのアクセス許可のセットごとに次の手順を繰り返します。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-180">To add multiple groups with different roles/permissions, repeat the steps below for each role or set of custom permissions.</span></span>

3.  <span data-ttu-id="4d7b1-181">グループを選んだら、**[選択内容の追加]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-181">When you are finished selecting groups, click **Add selected**.</span></span>
4.  <span data-ttu-id="4d7b1-182">**[役割]** セクションで、選んだグループの[役割またはカスタムのアクセス許可](set-custom-permissions-for-account-users.md)を指定します。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-182">In the **Roles** section, specify the [role(s) or customized permissions](set-custom-permissions-for-account-users.md) for the selected group(s).</span></span> <span data-ttu-id="4d7b1-183">グループのメンバー全員が、各自のアカウントに関連付けられている役割やアクセス許可とは関係なく、グループに適用されているアクセス許可で、デベロッパー センター アカウントにアクセスできるようになります。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-183">All members of the group will be able to access your Dev Center account with the permissions you apply to the group, regardless of the roles/permissions associated with their individual account.</span></span>
5.  <span data-ttu-id="4d7b1-184">**[保存]**をクリックします。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-184">Click **Save**.</span></span>


### <a name="create-a-new-group-account-in-your-organizations-directory-and-add-it-to-your-dev-center-account"></a><span data-ttu-id="4d7b1-185">組織のディレクトリに新しいグループ アカウントを作成し、デベロッパー センター アカウントに追加する</span><span class="sxs-lookup"><span data-stu-id="4d7b1-185">Create a new group account in your organization's directory and add it to your Dev Center account</span></span>

<span data-ttu-id="4d7b1-186">デベロッパー センター アクセスを新しいグループに付与する必要がある場合は、**[ユーザーの管理]** セクションで新しいグループを作成します。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-186">If you want to grant Dev Center access to a brand new group, you can create a new group in the **Manage users** section.</span></span> <span data-ttu-id="4d7b1-187">新しいグループは、デベロッパー センター アカウントだけでなく、組織のディレクトリにも作成されることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-187">Note that the new group will be created in your organization's directory, not just in your Dev Center account.</span></span>

1.  <span data-ttu-id="4d7b1-188">**[ユーザーの管理]** ページで、**[グループの追加]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-188">From the **Manage users** page, click **Add groups**.</span></span>
2.  <span data-ttu-id="4d7b1-189">次のページで、**[新しいグループ]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-189">On the next page, click **New group**.</span></span>
3.  <span data-ttu-id="4d7b1-190">新しいグループの表示名を入力します。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-190">Enter the display name for the new group.</span></span>
4.  <span data-ttu-id="4d7b1-191">グループの[役割またはカスタムのアクセス許可](set-custom-permissions-for-account-users.md)を指定します。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-191">Specify the [role(s) or customized permissions](set-custom-permissions-for-account-users.md) for the group.</span></span> <span data-ttu-id="4d7b1-192">グループのメンバー全員が、各自のアカウントに関連付けられている役割やアクセス許可とは関係なく、グループに適用されているアクセス許可で、デベロッパー センター アカウントにアクセスできるようになります。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-192">All members of the group will be able to access your Dev Center account with the permissions you apply to the group, regardless of the roles/permissions associated with their individual account.</span></span>
5.  <span data-ttu-id="4d7b1-193">表示された一覧から、新しいグループに割り当てるユーザーを選びます。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-193">Select the user(s) to assign to the new group from the list that appears.</span></span> <span data-ttu-id="4d7b1-194">検索ボックスを使うと、特定のユーザーを検索できます。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-194">You can use the search box to search for specific users.</span></span>
6.  <span data-ttu-id="4d7b1-195">ユーザーを選んだら **[選択内容の追加]** をクリックします。選んだユーザーが新しいグループに追加されます。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-195">When you are finished selecting users, click **Add selected** to add them to the new group.</span></span>
7.  <span data-ttu-id="4d7b1-196">**[保存]**をクリックします。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-196">Click **Save**.</span></span>


<span id="azure-ad-applications" />
## <a name="add-azure-ad-applications-to-your-dev-center-account"></a><span data-ttu-id="4d7b1-197">デベロッパー センター アカウントへの Azure AD アプリケーションの追加</span><span class="sxs-lookup"><span data-stu-id="4d7b1-197">Add Azure AD applications to your Dev Center account</span></span>

<span data-ttu-id="4d7b1-198">組織の Azure AD に含まれているアプリケーションやサービスがデベロッパー センター アカウントにアクセスできるようにすることができます。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-198">You can allow applications or services that are part of your organization's Azure AD to access your Dev Center account.</span></span>

### <a name="add-azure-ad-applications-from-your-organizations-directory"></a><span data-ttu-id="4d7b1-199">組織のディレクトリから Azure AD アプリケーションを追加する</span><span class="sxs-lookup"><span data-stu-id="4d7b1-199">Add Azure AD applications from your organization's directory</span></span>

1.  <span data-ttu-id="4d7b1-200">**[ユーザーの管理]** ページで、**[Azure AD アプリケーションの追加]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-200">From the **Manage users** page, click **Add Azure AD applications**.</span></span>
2.  <span data-ttu-id="4d7b1-201">表示された一覧から 1 つ以上の Azure AD アプリケーションを選びます。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-201">Select one or more Azure AD applications from the list that appears.</span></span> <span data-ttu-id="4d7b1-202">検索ボックスを使うと、特定の Azure AD アプリケーションを検索できます。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-202">You can use the search box to search for specific Azure AD applications.</span></span>
    > [!TIP]
    > <span data-ttu-id="4d7b1-203">デベロッパー センターに追加する Azure AD アプリケーションを複数選んだ場合は、それらのアプリケーションに同じ役割またはカスタムのアクセス許可のセットを割り当てなければなりません。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-203">If you select more than one Azure AD application to add to your Dev Center account, you must assign them the same role or set of custom permissions.</span></span> <span data-ttu-id="4d7b1-204">複数の Azure AD アプリケーションを追加し、それぞれ異なる役割まはたアクセス許可を割り当てる場合は、役割またはカスタムのアクセス許可のセットごとに次の手順を繰り返します。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-204">To add multiple Azure AD applications with different roles/permissions, repeat the steps below for each role or set of custom permissions.</span></span>

3.  <span data-ttu-id="4d7b1-205">Azure AD アプリケーションを選んだら、**[選択内容の追加]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-205">When you are finished selecting Azure AD applications, click **Add selected**.</span></span>
4.  <span data-ttu-id="4d7b1-206">**[役割]** セクションで、選んだ Azure AD アプリケーションの[役割またはカスタムのアクセス許可](set-custom-permissions-for-account-users.md)を指定します。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-206">In the **Roles** section, specify the [role(s) or customized permissions](set-custom-permissions-for-account-users.md) for the selected Azure AD application(s).</span></span>
5.  <span data-ttu-id="4d7b1-207">**[保存]**をクリックします。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-207">Click **Save**.</span></span>


### <a name="create-a-new-azure-ad-application-account-in-your-organizations-directory-and-add-it-to-your-dev-center-account"></a><span data-ttu-id="4d7b1-208">組織のディレクトリに新しい Azure AD アプリケーション アカウントを作成し、デベロッパー センター アカウントに追加する</span><span class="sxs-lookup"><span data-stu-id="4d7b1-208">Create a new Azure AD application account in your organization's directory and add it to your Dev Center account</span></span>

<span data-ttu-id="4d7b1-209">デベロッパー センターへのアクセスを新しい Azure AD アプリケーション アカウントに許可する必要がある場合は、**[ユーザーの管理]** セクションでそのアカウントを作成します。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-209">If you want to grant Dev Center access to a brand new Azure AD application account, you can create one in the **Manage users** section.</span></span> <span data-ttu-id="4d7b1-210">これにより、デベロッパー センター アカウントだけでなく、組織のディレクトリにも新しいアカウントが作成されることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-210">Note that this will create a new account in your organization's directory, not just in your Dev Center account.</span></span>

> [!TIP]
> <span data-ttu-id="4d7b1-211">デベロッパー センターの認証には基本的にこの Azure AD アプリケーションを使用し、このアプリにユーザーが直接アクセスする必要がない場合、ディレクトリ内の他の Azure AD アプリケーションによって使用されていない有効なアドレスを **[応答 URL]** と **[アプリ ID URI]** に入力できます。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-211">If you are primarily using this Azure AD application for Dev Center authentication, and don't need users to access it directly, you can enter any valid address for the **Reply URL** and **App ID URI**, as long as those values are not used by any other Azure AD application in your directory.</span></span>

1.  <span data-ttu-id="4d7b1-212">**[ユーザーの管理]** ページで、**[Azure AD アプリケーションの追加]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-212">From the **Manage users** page, click **Add Azure AD applications**.</span></span>
2.  <span data-ttu-id="4d7b1-213">次のページで、**[新しい Azure AD アプリケーション]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-213">On the next page, click **New Azure AD application**.</span></span>
3.  <span data-ttu-id="4d7b1-214">新しい Azure AD アプリケーションの **[応答 URL]** を入力します。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-214">Enter the **Reply URL** for the new Azure AD application.</span></span> <span data-ttu-id="4d7b1-215">これは、ユーザーがサインインして、Azure AD アプリケーションを使うことができるようになる URL です ("アプリ URL" や "サインオン URL" と呼ばれる場合もあります)。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-215">This is the URL where users can sign in and use your Azure AD application (sometimes also known as the App URL or Sign-On URL).</span></span> <span data-ttu-id="4d7b1-216">**[応答 URL]** は、256 文字までにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-216">The **Reply URL** can't be longer than 256 characters.</span></span>
4.  <span data-ttu-id="4d7b1-217">新しい Azure AD アプリケーションの **[アプリ ID URI]** を入力します。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-217">Enter the **App ID URI** for the new Azure AD application.</span></span> <span data-ttu-id="4d7b1-218">これは、Azure AD アプリケーションの論理識別子であり、シングル サインオン要求を Azure AD に送るときに提供されます。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-218">This is a logical identifier for the Azure AD application that is presented when it sends a single sign-on request to Azure AD.</span></span> <span data-ttu-id="4d7b1-219">**[アプリ ID URI]** は、ディレクトリ内の各 Azure AD アプリケーションで一意の値する必要があります。またこの URI は、256 文字までにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-219">Note that the **App ID URI** must be unique for each Azure AD application in your directory, and it can't be longer than 256 characters.</span></span>
5.  <span data-ttu-id="4d7b1-220">**[役割]** セクションで、Azure AD アプリケーションの[役割またはカスタムのアクセス許可](set-custom-permissions-for-account-users.md)を指定します。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-220">In the **Roles** section, specify the [role(s) or customized permissions](set-custom-permissions-for-account-users.md) for the Azure AD application.</span></span>
6.  <span data-ttu-id="4d7b1-221">**[保存]**をクリックします。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-221">Click **Save**.</span></span>

<span data-ttu-id="4d7b1-222">Azure AD アプリケーションを追加または作成したら、**[ユーザーの管理]** セクションに戻り、アプリケーションの名前をクリックすると、テナント ID、クライアント ID、応答 URL、アプリ ID URI など、アプリケーションの設定を確認することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-222">After you add or create an Azure AD application, you can return to the **Manage users** section and click the application name to review settings for the application, including the Tenant ID, Client ID, Reply URL, and App ID URI.</span></span>

> [!NOTE]
> <span data-ttu-id="4d7b1-223">[Windows ストア サービス](../monetize/using-windows-store-services.md)が提供する REST API を使用する場合は、サービスへの呼び出しの認証に使用する Azure AD アクセス トークンを取得するために、このページに表示されているテナント ID とクライアント ID の値が必要になります。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-223">If you intend to use the REST APIs provided by the [Windows Store services](../monetize/using-windows-store-services.md), you will need the Tenant ID and Client ID values shown on this page to obtain an Azure AD access token that you can use to authenticate the calls to services.</span></span>   

<span id="manage-keys" />
### <a name="manage-keys-for-an-azure-ad-application"></a><span data-ttu-id="4d7b1-224">Azure AD アプリケーションのキーを管理する</span><span class="sxs-lookup"><span data-stu-id="4d7b1-224">Manage keys for an Azure AD application</span></span>

<span data-ttu-id="4d7b1-225">Azure AD アプリケーションが Microsoft Azure AD でデータの読み取りや書き込みを行う場合は、キーが必要になります。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-225">If your Azure AD application reads and writes data in Microsoft Azure AD, it will need a key.</span></span> <span data-ttu-id="4d7b1-226">Azure AD アプリケーションのキーを作成するには、デベロッパー センターで Azure AD アプリケーションの情報を編集します。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-226">You can create keys for an Azure AD application by editing its info in Dev Center.</span></span> <span data-ttu-id="4d7b1-227">また、不要になったキーを削除することもできます。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-227">You can also remove keys that are no longer needed.</span></span>

1.  <span data-ttu-id="4d7b1-228">**[ユーザーの管理]** ページで、Azure AD アプリケーションの名前をクリックします。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-228">From the **Manage users** page, click the name of the Azure AD application.</span></span>
    > [!TIP]
    > <span data-ttu-id="4d7b1-229">Azure AD アプリケーションの名前をクリックすると、その Azure AD アプリケーションのアクティブ キーがすべて表示されます。また、キーが作成された日付やキーの有効期限が切れる日付も表示されます。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-229">When you click the name of the Azure AD application, you'll see all of the active keys for the Azure AD application, including the date on which the key was created and when it will expire.</span></span> <span data-ttu-id="4d7b1-230">不要になったキーを削除するには、**[削除]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-230">To remove a key that is no longer needed, click **Remove**.</span></span>

2.  <span data-ttu-id="4d7b1-231">新しいキーを追加するには、**[新しいキーの追加]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-231">To add a new key, click **Add new key**.</span></span>
3.  <span data-ttu-id="4d7b1-232">**[クライアント ID]** と **[キー]** の値を示す画面が表示されます。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-232">You will see a screen showing the **Client ID** and **Key** values.</span></span>
    > [!IMPORTANT]
    > <span data-ttu-id="4d7b1-233">必ずこの情報を印刷またはコピーしてください。このページを閉じると、この情報にはアクセスできなくなります。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-233">Be sure to print or copy this info, as you won't be able to access it again after you leave this page.</span></span>

4.  <span data-ttu-id="4d7b1-234">追加のキーを作成する場合は、**[別のキーの追加]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-234">If you want to create more keys, click **Add another key**.</span></span>

<span id="edit" />
## <a name="edit-a-user-group-or-azure-ad-application"></a><span data-ttu-id="4d7b1-235">ユーザー、グループ、または Azure AD アプリケーションの編集</span><span class="sxs-lookup"><span data-stu-id="4d7b1-235">Edit a user, group, or Azure AD application</span></span>

<span data-ttu-id="4d7b1-236">ユーザー、グループ、Azure AD アプリケーションをデベロッパー センター アカウントに追加した後で、アカウント情報を変更できます。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-236">After you've added users, groups, and/or Azure AD applications to your Dev Center account, you can make changes to their account info.</span></span> 

> [!IMPORTANT]
> <span data-ttu-id="4d7b1-237">役割やアクセス許可に対する変更は、デベロッパー センターのアクセスにのみ影響します。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-237">Changes made to roles or permissions will only affect Dev Center access.</span></span> <span data-ttu-id="4d7b1-238">その他の変更 (ユーザー名やグループのメンバーシップの変更、Azure AD アプリケーションの応答 URL やアプリケーション ID URIの変更) は、組織の Azure AD テナントにも、デベロッパー センター アカウントにも反映されません。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-238">All other changes (such as changing a user's name or group membership, or the Reply URL and App ID URI for an Azure AD application) will be reflected in your organization's Azure AD tenant as well as in your Dev Center account.</span></span> 

1.  <span data-ttu-id="4d7b1-239">**[ユーザーの管理]** ページで、編集するユーザー、グループ、または Azure AD アプリケーション アカウントの名前をクリックします。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-239">From the **Manage users** page, click the name of the user, group, or Azure AD application account that you want to edit.</span></span>
2.  <span data-ttu-id="4d7b1-240">必要な変更を行います。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-240">Make your desired changes.</span></span> <span data-ttu-id="4d7b1-241">編集できる項目は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-241">The items you can edit are as follows:</span></span>
    -   <span data-ttu-id="4d7b1-242">**ユーザー**の場合は、ユーザーの姓、名、またはユーザー名を編集できます。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-242">For a **user**, you can edit the user's first name, last name, or username.</span></span> <span data-ttu-id="4d7b1-243">また、**[グループ メンバーシップ]** セクションで、グループを選ぶまたは選択を解除して、ユーザーのグループ メンバーシップを更新することもできます。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-243">You can also select or deselect groups in the **Group membership** section to update their group membership.</span></span>
    -   <span data-ttu-id="4d7b1-244">**グループ**の場合は、グループの名前を編集できます。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-244">For a **group**, you can edit the name of the group.</span></span> <span data-ttu-id="4d7b1-245">(グループ メンバーシップを更新するには、グループに追加またはグループから削除するユーザーを編集し、**[グループ メンバーシップ]** セクションを変更します。)</span><span class="sxs-lookup"><span data-stu-id="4d7b1-245">(To update group membership, edit the users you want to add or remove from the group and make changes to the **Group membership** section.)</span></span>
    -   <span data-ttu-id="4d7b1-246">**Azure AD アプリケーション**の場合は、**[応答 URL]** または **[アプリケーション ID/URI]** に新しい値を入力できます。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-246">For an **Azure AD application**, you can enter new values for the **Reply URL** or **App ID URI**.</span></span>
    <span data-ttu-id="4d7b1-247">これらの変更は、デベロッパー センター アカウントのほか、組織のディレクトリでも行われることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-247">Remember that these changes will be made in your organization's directory as well as in your Dev Center account.</span></span>
3.  <span data-ttu-id="4d7b1-248">デベロッパー センターへのアクセスに関する変更の場合は、変更を適用する役割を選ぶか選択を解除して、**[アクセス許可のカスタマイズ]** を選び、必要な変更を行います。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-248">For changes related to Dev Center access, select or deselect the role(s) that you want to apply, or select **Customize permissions** and make the desired changes.</span></span> <span data-ttu-id="4d7b1-249">これらの変更は、デベロッパー センターへのアクセスにのみ適用され、組織の Azure AD テナント内のアクセス許可が変更されることはありません。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-249">These changes only impact Dev Center access and will not change any permissions within your organization's Azure AD tenant.</span></span>
3.  <span data-ttu-id="4d7b1-250">**[保存]**をクリックします。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-250">Click **Save**.</span></span>


## <a name="view-history-for-account-users"></a><span data-ttu-id="4d7b1-251">アカウント ユーザーの履歴の表示</span><span class="sxs-lookup"><span data-stu-id="4d7b1-251">View history for account users</span></span>

<span data-ttu-id="4d7b1-252">アカウント所有者は、所有者がアカウントに追加した任意のユーザーに関する詳細な閲覧履歴を参照できます。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-252">As an account owner, you can view the detailed browsing history for any additional users you’ve added to the account.</span></span>

<span data-ttu-id="4d7b1-253">**[ユーザーの管理]** ページで、閲覧の履歴を確認する対象ユーザーの **[最後のアクティビティ]** の下に表示されるリンクをクリックします。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-253">On the **Manage users** page, click the link shown under **Last activity** for the user whose browsing history you’d like to review.</span></span> <span data-ttu-id="4d7b1-254">ユーザーが過去 30 日間にアクセスしたすべてのページの URL を参照できます。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-254">You'll be able to view the URLs for all pages that the user visited in the last 30 days.</span></span>

<span id="remove" />
## <a name="remove-users-groups-and-azure-ad-applications"></a><span data-ttu-id="4d7b1-255">ユーザー、グループ、および Azure AD アプリケーションの削除</span><span class="sxs-lookup"><span data-stu-id="4d7b1-255">Remove users, groups, and Azure AD applications</span></span>

<span data-ttu-id="4d7b1-256">ユーザー、グループ、または Azure AD アプリケーションをデベロッパー センター アカウントから削除するには、**[ユーザーの管理]** ページで、削除するユーザー、グループ、または Azure AD アプリケーションの名前の横に表示される **[削除]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-256">To remove a user, group, or Azure AD application from your Dev Center account, click the **Remove** link that appears by their name on the **Manage users** page.</span></span> <span data-ttu-id="4d7b1-257">削除を確認した後は、そのユーザー、グループ、または Azure AD アプリケーションは、デベロッパー センター アカウントにアクセスできなくなります (後で追加する場合を除く)。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-257">After confirming that you want to remove it, that user, group, or Azure AD application will no longer be able to access to your Dev Center account (unless you add it again later).</span></span>

> [!IMPORTANT] 
> <span data-ttu-id="4d7b1-258">削除したユーザー、グループ、または Azure AD アプリケーションは、デベロッパー センター アカウントにアクセスできなくなります。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-258">Removing a user, group, or Azure AD application means that it will no longer have access to your Dev Center account.</span></span> <span data-ttu-id="4d7b1-259">この操作により、組織のディレクトリからユーザー、グループ、または Azure AD アプリケーションが削除されることは**ありません**。</span><span class="sxs-lookup"><span data-stu-id="4d7b1-259">It does **not** delete the user, group, or Azure AD application from your organization's directory.</span></span>

 

