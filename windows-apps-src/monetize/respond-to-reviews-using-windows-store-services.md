---
ms.assetid: c92c0ea8-f742-4fc1-a3d7-e90aac11953e
description: Store のアプリのレビューにプログラムで返信を送るには、Microsoft Store レビュー API を使います。
title: ストアのサービスを使用してレビューに返信する
ms.date: 06/04/2018
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store レビュー API, レビューに返信
ms.localizationpriority: medium
ms.openlocfilehash: 677108e692bbc702778cad3c42a45b4f5408b8cd
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57653167"
---
# <a name="respond-to-reviews-using-store-services"></a>ストアのサービスを使用してレビューに返信する

Store のアプリのレビューにプログラムで返信するには、*Microsoft Store レビュー API* を使います。 この API は、パートナー センターを使用せず、一括を希望する開発者が多数のレビューに応答に特に便利です。 この API は、Azure Active Directory (Azure AD) を使って、アプリまたはサービスからの呼び出しを認証します。

次の手順で、このプロセスについて詳しく説明しています。

1.  すべての[前提条件](#prerequisites)を完了したことを確認します。
2.  Microsoft Store レビュー API のメソッドを呼び出す前に、[Azure AD アクセス トークンを取得](#obtain-an-azure-ad-access-token)する必要があります。 トークンを取得した後、Microsoft Store レビュー API の呼び出しでこのトークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れた後は、新しいトークンを生成できます。
3.  [Microsoft Store レビュー API を呼び出します](#call-the-windows-store-reviews-api)。

> [!NOTE]
> Microsoft Store を使用するだけでなく、プログラムで別の方法として、レビューに応答することができます、レビューに応答する API をレビュー[パートナー センターを使用して](../publish/respond-to-customer-reviews.md)します。

<span id="prerequisites" />

## <a name="step-1-complete-prerequisites-for-using-the-microsoft-store-reviews-api"></a>手順 1:Microsoft Store を使用するための前提条件の完全な API をレビューします。

Microsoft Store レビュー API を呼び出すコードの作成を開始する前に、次の前提条件が満たされていることを確認します。

* ユーザー (またはユーザーの組織) は、Azure AD ディレクトリと、そのディレクトリに対する[全体管理者](https://go.microsoft.com/fwlink/?LinkId=746654)のアクセス許可を持っている必要があります。 Office 365 または Microsoft の他のビジネス サービスを既に使っている場合は、既に Azure AD ディレクトリをお持ちです。 それ以外の場合は、追加料金なしに[パートナー センターで新しい Azure AD を作成](../publish/associate-azure-ad-with-partner-center.md#create-a-brand-new-azure-ad-to-associate-with-your-partner-center-account)できます。

* Azure AD アプリケーションをパートナー センター アカウントに関連付ける、テナント ID と、アプリケーションのクライアント ID を取得、およびキーを生成する必要があります。 Azure AD アプリケーションは、Microsoft Store レビュー API の呼び出し元のアプリまたはサービスを表します。 テナント ID、クライアント ID、およびキーは、API に渡す Azure AD アクセス トークンを取得するために必要です。
    > [!NOTE]
    > この作業を行うのは一度だけです。 テナント ID、クライアント ID、キーがあれば、新しい Azure AD アクセス トークンの作成が必要になったときに、いつでもそれらを再利用できます。

Azure AD アプリケーションをパートナー センター アカウントに関連付けるし、必要な値を取得します。

1.  パートナー センターの[、組織の Azure AD ディレクトリと、組織のパートナー センター アカウントを関連付ける](../publish/associate-azure-ad-with-partner-center.md)します。

2.  [次へ]、**ユーザー**ページで、**アカウント設定**パートナー センターの「[して Azure AD アプリケーションを追加](../publish/add-users-groups-and-azure-ad-applications.md#add-azure-ad-applications-to-your-partner-center-account)アプリを使用してサービスを表すレビューに応答します。 このアプリケーションに必ず**マネージャー** ロールを割り当てます。 アプリケーションが存在しない場合、Azure AD ディレクトリで実行できます[を新規作成パートナー センターで Azure AD アプリケーション](../publish/add-users-groups-and-azure-ad-applications.md#create-a-new-azure-ad-application-account-in-your-organizations-directory-and-add-it-to-your-partner-center-account)します。 

3.  **[ユーザー]** ページに戻り、Azure AD アプリケーションの名前をクリックしてアプリケーション設定に移動し、**[テナント ID]** と **[クライアント ID]** の値を書き留めます。

4. **[新しいキーの追加]** をクリックします。 次の画面で、**[キー]** の値を書き留めます。 このページから離れると、この情報に再度アクセスすることはできません。 詳しくは、「[Azure AD アプリケーションのキーを管理する方法](../publish/add-users-groups-and-azure-ad-applications.md#manage-keys)」をご覧ください。

<span id="obtain-an-azure-ad-access-token" />

## <a name="step-2-obtain-an-azure-ad-access-token"></a>手順 2:Azure AD アクセス トークンの取得

Microsoft Store レビュー API のいずれかのメソッドを呼び出す前に、まず API の各メソッドの **Authorization** ヘッダーに渡す Azure AD アクセス トークンを取得する必要があります。 アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れた後は、トークンを更新してそれ以降の API 呼び出しで引き続き使用できます。

アクセス トークンを取得するには、「[クライアント資格情報を使用したサービス間の呼び出し](https://azure.microsoft.com/documentation/articles/active-directory-protocols-oauth-service-to-service/)」の手順に従って、HTTP POST を ```https://login.microsoftonline.com/<tenant_id>/oauth2/token``` エンドポイントに送信します。 要求の例を次に示します。

```syntax
POST https://login.microsoftonline.com/<tenant_id>/oauth2/token HTTP/1.1
Host: login.microsoftonline.com
Content-Type: application/x-www-form-urlencoded; charset=utf-8

grant_type=client_credentials
&client_id=<your_client_id>
&client_secret=<your_client_secret>
&resource=https://manage.devcenter.microsoft.com
```

*テナント\_id* POST URI の値と*クライアント\_id*と*クライアント\_シークレット*パラメーター、テナントの指定ID、クライアント ID、前のセクションで、パートナー センターから取得したアプリケーションのキー。 *resource* パラメーターには、```https://manage.devcenter.microsoft.com``` を指定します。

アクセス トークンの有効期限が切れた後は、[この](https://azure.microsoft.com/documentation/articles/active-directory-protocols-oauth-code/#refreshing-the-access-tokens)手順に従って更新できます。

<span id="call-the-windows-store-reviews-api" />

## <a name="step-3-call-the-microsoft-store-reviews-api"></a>手順 3:Microsoft Store のレビュー API を呼び出す

Azure AD アクセス トークンを取得したら、Microsoft Store レビュー API を呼び出すことができます。 各メソッドの **Authorization** ヘッダーにアクセス トークンを渡す必要があります。

Microsoft Store レビュー API には、特定のレビューに返信できるかどうかや、1 つ以上のレビューに返信を提出できるかどうかの判断に使えるメソッドがいくつか含まれています。 この API を使用するには次のプロセスに従います。

1. 返信するレビューの ID を取得します。 レビュー ID は、Microsoft Store 分析 API の[アプリのレビューの取得](get-app-reviews.md)メソッドの応答データ、および[レビュー レポート](../publish/reviews-report.md)の[オフライン ダウンロード](../publish/download-analytic-reports.md)で取得できます。
2. レビューに返信できるかどうかを判断するには、[アプリのレビューへの返信情報の取得](get-response-info-for-app-reviews.md)メソッドを呼び出します。 顧客はレビューを送信するときに、レビューへの返信を受け取らないことを選択できます。 レビューの返信を受け取らないことを選択している顧客が送信したレビューに返信することはできません。
3. プラグラムでレビューに返信するには、[アプリ レビューへの返信の提出](submit-responses-to-app-reviews.md)メソッドを呼び出します。


## <a name="related-topics"></a>関連トピック

* [アプリのレビューを取得します。](get-app-reviews.md)
* [アプリのレビューの応答情報を取得します。](get-response-info-for-app-reviews.md)
* [アプリのレビューに応答を送信します。](submit-responses-to-app-reviews.md)

 
