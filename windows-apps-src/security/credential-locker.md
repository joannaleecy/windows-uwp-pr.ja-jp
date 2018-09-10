---
title: 資格情報保管ボックス
description: この記事では、ユニバーサル Windows プラットフォーム (UWP) アプリで資格情報保管ボックスを使ってユーザーの資格情報を安全に保管し、ユーザーの Microsoft アカウントを使ってデバイス間をローミングする方法について説明します。
ms.assetid: 7BCC443D-9E8A-417C-B275-3105F5DED863
author: msatranjr
ms.author: misatran
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, セキュリティ
ms.localizationpriority: medium
ms.openlocfilehash: c6412f28e60ed0401fb96098fd38128a37491c8d
ms.sourcegitcommit: f5cf806a595969ecbb018c3f7eea86c7a34940f6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/10/2018
ms.locfileid: "3822786"
---
# <a name="credential-locker"></a><span data-ttu-id="13c9d-104">資格情報保管ボックス</span><span class="sxs-lookup"><span data-stu-id="13c9d-104">Credential locker</span></span>




<span data-ttu-id="13c9d-105">この記事では、ユニバーサル Windows プラットフォーム (UWP) アプリで資格情報保管ボックスを使ってユーザーの資格情報を安全に保管し、ユーザーの Microsoft アカウントを使ってデバイス間をローミングする方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="13c9d-105">This article describes how Universal Windows Platform (UWP) apps can use the Credential Locker to securely store and retrieve user credentials, and roam them between devices with the user's Microsoft account.</span></span>

<span data-ttu-id="13c9d-106">たとえば、メディア ファイルやソーシャル ネットワークなど、保護されたリソースにアクセスするサービスに接続するアプリがあるとします。</span><span class="sxs-lookup"><span data-stu-id="13c9d-106">For example, you have an app that connects to a service to access protected resources such as media files, or social networking.</span></span> <span data-ttu-id="13c9d-107">サービスには、ユーザーごとにログイン情報を渡す必要があります。</span><span class="sxs-lookup"><span data-stu-id="13c9d-107">Your service requires login information for each user.</span></span> <span data-ttu-id="13c9d-108">そこで、ユーザーのユーザー名とパスワードを取得するための UI をアプリに組み込み、サービスへのログインに使うことにしました。</span><span class="sxs-lookup"><span data-stu-id="13c9d-108">You’ve built UI into your app that gets the username and password for the user, which is then used to log the user into the service.</span></span> <span data-ttu-id="13c9d-109">Credential Locker API を使うと、ユーザーのユーザー名とパスワードを格納し、次回のアプリの実行時に取得してデバイスを問わずユーザーを自動的にログインさせることができます。</span><span class="sxs-lookup"><span data-stu-id="13c9d-109">Using the Credential Locker API, you can store the username and password for your user and easily retrieve them and log the user in automatically the next time they open your app, regardless of what device they're on.</span></span>

<span data-ttu-id="13c9d-110">資格情報保管ボックスに格納されたユーザーの資格情報には有効期限は*ありません*。また、[**ApplicationData.RoamingStorageQuota**](https://msdn.microsoft.com/library/windows/apps/br241625) の影響を*受けず*、従来のデータのローミングのようなアイドル時間が発生しても消去*されません*。</span><span class="sxs-lookup"><span data-stu-id="13c9d-110">User credentials stored in the CredentialLocker do *not* expire, are *not* affected by the [**ApplicationData.RoamingStorageQuota**](https://msdn.microsoft.com/library/windows/apps/br241625), and will *not* be cleared out due to inactivity like traditional roaming data.</span></span> <span data-ttu-id="13c9d-111">ただし、資格情報保管ボックスに格納できる資格情報は、アプリごとに最大で 20 件までです。</span><span class="sxs-lookup"><span data-stu-id="13c9d-111">However, you can only store up to 20 credentials per app in the CredentialLocker.</span></span>

<span data-ttu-id="13c9d-112">ドメイン アカウントの場合、資格情報保管ボックスは動作が少し異なります。</span><span class="sxs-lookup"><span data-stu-id="13c9d-112">Credential locker works a little differently for domain accounts.</span></span> <span data-ttu-id="13c9d-113">Microsoft アカウントと共に格納された資格情報がある場合、そのアカウントをドメイン アカウント (職場で使うアカウントなど) に関連付けると、資格情報はドメイン アカウントにローミングされます。</span><span class="sxs-lookup"><span data-stu-id="13c9d-113">If there are credentials stored with your Microsoft account, and you associate that account with a domain account (such as the account that you use at work), your credentials will roam to that domain account.</span></span> <span data-ttu-id="13c9d-114">ただし、ドメイン アカウントでのサインオン中に追加された新しい資格情報はローミングされません。</span><span class="sxs-lookup"><span data-stu-id="13c9d-114">However, any new credentials added when signed on with the domain account won’t roam.</span></span> <span data-ttu-id="13c9d-115">これは、ドメインのプライベートな資格情報がドメイン外部に公開されないようにするためです。</span><span class="sxs-lookup"><span data-stu-id="13c9d-115">This ensures that private credentials for the domain aren’t exposed outside of the domain.</span></span>

## <a name="storing-user-credentials"></a><span data-ttu-id="13c9d-116">ユーザー資格情報の格納</span><span class="sxs-lookup"><span data-stu-id="13c9d-116">Storing user credentials</span></span>


1.  <span data-ttu-id="13c9d-117">[**Windows.Security.Credentials**](https://msdn.microsoft.com/library/windows/apps/br227089) 名前空間の [**PasswordVault**](https://msdn.microsoft.com/library/windows/apps/br227081) オブジェクトを使って、資格情報保管ボックスへの参照を取得します。</span><span class="sxs-lookup"><span data-stu-id="13c9d-117">Obtain a reference to the Credential Locker using the [**PasswordVault**](https://msdn.microsoft.com/library/windows/apps/br227081) object from the [**Windows.Security.Credentials**](https://msdn.microsoft.com/library/windows/apps/br227089) namespace.</span></span>
2.  <span data-ttu-id="13c9d-118">[**PasswordCredential**](https://msdn.microsoft.com/library/windows/apps/br227061) オブジェクトを作成し、アプリの識別子、ユーザー名、パスワードを含めます。これを [**PasswordVault.Add**](https://msdn.microsoft.com/library/windows/apps/hh701231) メソッドに渡して、資格情報を保管ボックスに追加します。</span><span class="sxs-lookup"><span data-stu-id="13c9d-118">Create a [**PasswordCredential**](https://msdn.microsoft.com/library/windows/apps/br227061) object that contains an identifier for your app, the username and the password, and pass that to the [**PasswordVault.Add**](https://msdn.microsoft.com/library/windows/apps/hh701231) method to add the credential to the locker.</span></span>

```cs
var vault = new Windows.Security.Credentials.PasswordVault();
vault.Add(new Windows.Security.Credentials.PasswordCredential(
    "My App", username, password));
```

## <a name="retrieving-user-credentials"></a><span data-ttu-id="13c9d-119">ユーザー資格情報の取得</span><span class="sxs-lookup"><span data-stu-id="13c9d-119">Retrieving user credentials</span></span>


<span data-ttu-id="13c9d-120">[**PasswordVault**](https://msdn.microsoft.com/library/windows/apps/br227081) オブジェクトへの参照を取得した後、資格情報保管ボックスからユーザー資格情報を取得するには、いくつかの方法があります。</span><span class="sxs-lookup"><span data-stu-id="13c9d-120">You have several options for retrieving user credentials from the Credential Locker after you have a reference to the [**PasswordVault**](https://msdn.microsoft.com/library/windows/apps/br227081) object.</span></span>

-   <span data-ttu-id="13c9d-121">[**PasswordVault.RetrieveAll**](https://msdn.microsoft.com/library/windows/apps/br227088) メソッドを使うと、ユーザーからアプリに提供された保管ボックス内の資格情報をすべて取得できます。</span><span class="sxs-lookup"><span data-stu-id="13c9d-121">You can retrieve all the credentials the user has supplied for your app in the locker with the [**PasswordVault.RetrieveAll**](https://msdn.microsoft.com/library/windows/apps/br227088) method.</span></span>

-   <span data-ttu-id="13c9d-122">格納されている資格情報のユーザー名がわかっている場合は、[**PasswordVault.FindAllByUserName**](https://msdn.microsoft.com/library/windows/apps/br227084) メソッドを使うことで、そのユーザー名の資格情報をすべて取得できます。</span><span class="sxs-lookup"><span data-stu-id="13c9d-122">If you know the username for the stored credentials, you can retrieve all the credentials for that username with the [**PasswordVault.FindAllByUserName**](https://msdn.microsoft.com/library/windows/apps/br227084) method.</span></span>

-   <span data-ttu-id="13c9d-123">格納されている資格情報のリソース名がわかっている場合は、[**PasswordVault.FindAllByResource**](https://msdn.microsoft.com/library/windows/apps/br227083) メソッドを使うことで、そのリソース名の資格情報をすべて取得できます。</span><span class="sxs-lookup"><span data-stu-id="13c9d-123">If you know the resource name for the stored credentials, you can retrieve all the credentials for that resource name with the [**PasswordVault.FindAllByResource**](https://msdn.microsoft.com/library/windows/apps/br227083) method.</span></span>

-   <span data-ttu-id="13c9d-124">最後に、資格情報のユーザー名とリソース名の両方がわかっている場合は、[**PasswordVault.Retrieve**](https://msdn.microsoft.com/library/windows/apps/br227087) メソッドを使うことで、該当する資格情報だけを取得できます。</span><span class="sxs-lookup"><span data-stu-id="13c9d-124">Finally, if you know both the username and the resource name for a credential, you can retrieve just that credential with the [**PasswordVault.Retrieve**](https://msdn.microsoft.com/library/windows/apps/br227087) method.</span></span>

<span data-ttu-id="13c9d-125">例を見てみましょう。次の例では、リソース名をアプリ内でグローバルに格納し、ユーザーの資格情報が見つかった場合に、そのユーザーとして自動的にログインします。</span><span class="sxs-lookup"><span data-stu-id="13c9d-125">Let’s look at an example where we have stored the resource name globally in an app and we log the user on automatically if we find a credential for them.</span></span> <span data-ttu-id="13c9d-126">同じユーザーに対して複数の資格情報がある場合は、ログオンに使う既定の資格情報をユーザーに選んでもらいます。</span><span class="sxs-lookup"><span data-stu-id="13c9d-126">If we find multiple credentials for the same user, we ask the user to select a default credential to use when logging on.</span></span>

```cs
private string resourceName = "My App";
private string defaultUserName;

private void Login()
{
    var loginCredential = GetCredentialFromLocker();

    if (loginCredential != null)
    {
        // There is a credential stored in the locker.
        // Populate the Password property of the credential
        // for automatic login.
        loginCredential.RetrievePassword();
    }
    else
    {
        // There is no credential stored in the locker.
        // Display UI to get user credentials.
        loginCredential = GetLoginCredentialUI();
    }

    // Log the user in.
    ServerLogin(loginCredential.UserName, loginCredential.Password);
}


private Windows.Security.Credentials.PasswordCredential GetCredentialFromLocker()
{
    Windows.Security.Credentials.PasswordCredential credential = null;

    var vault = new Windows.Security.Credentials.PasswordVault();
    var credentialList = vault.FindAllByResource(resourceName);
    if (credentialList.Count > 0)
    {
        if (credentialList.Count == 1)
        {
            credential = credentialList[0];
        }
        else
        {
            // When there are multiple usernames,
            // retrieve the default username. If one doesn't
            // exist, then display UI to have the user select
            // a default username.

            defaultUserName = GetDefaultUserNameUI();

            credential = vault.Retrieve(resourceName, defaultUserName);
        }
    }

    return credential;
}
```

## <a name="deleting-user-credentials"></a><span data-ttu-id="13c9d-127">ユーザー資格情報の削除</span><span class="sxs-lookup"><span data-stu-id="13c9d-127">Deleting user credentials</span></span>


<span data-ttu-id="13c9d-128">資格情報保管ボックスからのユーザー資格情報の削除も、2 段階のプロセスで簡単に行うことができます。</span><span class="sxs-lookup"><span data-stu-id="13c9d-128">Deleting user credentials in the Credential Locker is also a quick, two-step process.</span></span>

1.  <span data-ttu-id="13c9d-129">[**Windows.Security.Credentials**](https://msdn.microsoft.com/library/windows/apps/br227089) 名前空間の [**PasswordVault**](https://msdn.microsoft.com/library/windows/apps/br227081) オブジェクトを使って、資格情報保管ボックスへの参照を取得します。</span><span class="sxs-lookup"><span data-stu-id="13c9d-129">Obtain a reference to the Credential Locker using the [**PasswordVault**](https://msdn.microsoft.com/library/windows/apps/br227081) object from the [**Windows.Security.Credentials**](https://msdn.microsoft.com/library/windows/apps/br227089) namespace.</span></span>

2.  <span data-ttu-id="13c9d-130">削除する資格情報を [**PasswordVault.Remove**](https://msdn.microsoft.com/library/windows/apps/hh701242) メソッドに渡します。</span><span class="sxs-lookup"><span data-stu-id="13c9d-130">Pass the credential you want to delete to the [**PasswordVault.Remove**](https://msdn.microsoft.com/library/windows/apps/hh701242) method.</span></span>

```cs
var vault = new Windows.Security.Credentials.PasswordVault();
vault.Remove(new Windows.Security.Credentials.PasswordCredential(
    "My App", username, password));
```

## <a name="best-practices"></a><span data-ttu-id="13c9d-131">ベスト プラクティス</span><span class="sxs-lookup"><span data-stu-id="13c9d-131">Best practices</span></span>


<span data-ttu-id="13c9d-132">資格情報保管ボックスはパスワードのみに使い、大きいデータ BLOB には使わないようにします。</span><span class="sxs-lookup"><span data-stu-id="13c9d-132">Only use the credential locker for passwords and not for larger data blobs.</span></span>

<span data-ttu-id="13c9d-133">次の条件が満たされている場合にのみ、資格情報保管ボックスにパスワードを保存します。</span><span class="sxs-lookup"><span data-stu-id="13c9d-133">Save passwords in the credential locker only if the following criteria are met:</span></span>

-   <span data-ttu-id="13c9d-134">ユーザーが正常にサインインしている。</span><span class="sxs-lookup"><span data-stu-id="13c9d-134">The user has successfully signed in.</span></span>
-   <span data-ttu-id="13c9d-135">ユーザーがパスワードの保存を選んでいる。</span><span class="sxs-lookup"><span data-stu-id="13c9d-135">The user has opted to save passwords.</span></span>

<span data-ttu-id="13c9d-136">アプリ データまたはローミングの設定を使って資格情報をプレーンテキストに格納しないでください。</span><span class="sxs-lookup"><span data-stu-id="13c9d-136">Never store credentials in plain-text using app data or roaming settings.</span></span>
