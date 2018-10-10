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
ms.sourcegitcommit: 8e30651fd691378455ea1a57da10b2e4f50e66a0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/10/2018
ms.locfileid: "4499237"
---
# <a name="credential-locker"></a>資格情報保管ボックス




この記事では、ユニバーサル Windows プラットフォーム (UWP) アプリで資格情報保管ボックスを使ってユーザーの資格情報を安全に保管し、ユーザーの Microsoft アカウントを使ってデバイス間をローミングする方法について説明します。

たとえば、メディア ファイルやソーシャル ネットワークなど、保護されたリソースにアクセスするサービスに接続するアプリがあるとします。 サービスには、ユーザーごとにログイン情報を渡す必要があります。 そこで、ユーザーのユーザー名とパスワードを取得するための UI をアプリに組み込み、サービスへのログインに使うことにしました。 Credential Locker API を使うと、ユーザーのユーザー名とパスワードを格納し、次回のアプリの実行時に取得してデバイスを問わずユーザーを自動的にログインさせることができます。

資格情報保管ボックスに格納されたユーザーの資格情報には有効期限は*ありません*。また、[**ApplicationData.RoamingStorageQuota**](https://msdn.microsoft.com/library/windows/apps/br241625) の影響を*受けず*、従来のデータのローミングのようなアイドル時間が発生しても消去*されません*。 ただし、資格情報保管ボックスに格納できる資格情報は、アプリごとに最大で 20 件までです。

ドメイン アカウントの場合、資格情報保管ボックスは動作が少し異なります。 Microsoft アカウントと共に格納された資格情報がある場合、そのアカウントをドメイン アカウント (職場で使うアカウントなど) に関連付けると、資格情報はドメイン アカウントにローミングされます。 ただし、ドメイン アカウントでのサインオン中に追加された新しい資格情報はローミングされません。 これは、ドメインのプライベートな資格情報がドメイン外部に公開されないようにするためです。

## <a name="storing-user-credentials"></a>ユーザー資格情報の格納


1.  [**Windows.Security.Credentials**](https://msdn.microsoft.com/library/windows/apps/br227089) 名前空間の [**PasswordVault**](https://msdn.microsoft.com/library/windows/apps/br227081) オブジェクトを使って、資格情報保管ボックスへの参照を取得します。
2.  [**PasswordCredential**](https://msdn.microsoft.com/library/windows/apps/br227061) オブジェクトを作成し、アプリの識別子、ユーザー名、パスワードを含めます。これを [**PasswordVault.Add**](https://msdn.microsoft.com/library/windows/apps/hh701231) メソッドに渡して、資格情報を保管ボックスに追加します。

```cs
var vault = new Windows.Security.Credentials.PasswordVault();
vault.Add(new Windows.Security.Credentials.PasswordCredential(
    "My App", username, password));
```

## <a name="retrieving-user-credentials"></a>ユーザー資格情報の取得


[**PasswordVault**](https://msdn.microsoft.com/library/windows/apps/br227081) オブジェクトへの参照を取得した後、資格情報保管ボックスからユーザー資格情報を取得するには、いくつかの方法があります。

-   [**PasswordVault.RetrieveAll**](https://msdn.microsoft.com/library/windows/apps/br227088) メソッドを使うと、ユーザーからアプリに提供された保管ボックス内の資格情報をすべて取得できます。

-   格納されている資格情報のユーザー名がわかっている場合は、[**PasswordVault.FindAllByUserName**](https://msdn.microsoft.com/library/windows/apps/br227084) メソッドを使うことで、そのユーザー名の資格情報をすべて取得できます。

-   格納されている資格情報のリソース名がわかっている場合は、[**PasswordVault.FindAllByResource**](https://msdn.microsoft.com/library/windows/apps/br227083) メソッドを使うことで、そのリソース名の資格情報をすべて取得できます。

-   最後に、資格情報のユーザー名とリソース名の両方がわかっている場合は、[**PasswordVault.Retrieve**](https://msdn.microsoft.com/library/windows/apps/br227087) メソッドを使うことで、該当する資格情報だけを取得できます。

例を見てみましょう。次の例では、リソース名をアプリ内でグローバルに格納し、ユーザーの資格情報が見つかった場合に、そのユーザーとして自動的にログインします。 同じユーザーに対して複数の資格情報がある場合は、ログオンに使う既定の資格情報をユーザーに選んでもらいます。

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

## <a name="deleting-user-credentials"></a>ユーザー資格情報の削除


資格情報保管ボックスからのユーザー資格情報の削除も、2 段階のプロセスで簡単に行うことができます。

1.  [**Windows.Security.Credentials**](https://msdn.microsoft.com/library/windows/apps/br227089) 名前空間の [**PasswordVault**](https://msdn.microsoft.com/library/windows/apps/br227081) オブジェクトを使って、資格情報保管ボックスへの参照を取得します。

2.  削除する資格情報を [**PasswordVault.Remove**](https://msdn.microsoft.com/library/windows/apps/hh701242) メソッドに渡します。

```cs
var vault = new Windows.Security.Credentials.PasswordVault();
vault.Remove(new Windows.Security.Credentials.PasswordCredential(
    "My App", username, password));
```

## <a name="best-practices"></a>ベスト プラクティス


資格情報保管ボックスはパスワードのみに使い、大きいデータ BLOB には使わないようにします。

次の条件が満たされている場合にのみ、資格情報保管ボックスにパスワードを保存します。

-   ユーザーが正常にサインインしている。
-   ユーザーがパスワードの保存を選んでいる。

アプリ データまたはローミングの設定を使って資格情報をプレーンテキストに格納しないでください。
