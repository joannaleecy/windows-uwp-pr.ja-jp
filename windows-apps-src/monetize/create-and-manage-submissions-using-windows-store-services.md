---
author: Xansky
ms.assetid: 7CC11888-8DC6-4FEE-ACED-9FA476B2125E
description: Windows デベロッパー センター アカウントに登録されているアプリの申請をプログラムで作成および管理するには、Microsoft Store 申請 API を使います。
title: 申請の作成と管理
ms.author: mhopkins
ms.date: 06/04/2018
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store 申請 API
ms.localizationpriority: medium
ms.openlocfilehash: 9e62e2e2b3da4bc8e26f944ca446d11cf55c2c84
ms.sourcegitcommit: ca96031debe1e76d4501621a7680079244ef1c60
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/31/2018
ms.locfileid: "5827382"
---
# <a name="create-and-manage-submissions"></a>申請の作成と管理


*Microsoft Store 申請 API* を使うと、自分または自分の組織の Windows デベロッパー センター アカウントに対して、アプリ、アドオン、パッケージ フライトの申請をプログラムで照会したり作成したりできます。 この API は、アカウントで多数のアプリやアドオンを管理しており、こうしたアセットの申請プロセスを自動化および最適化する場合に便利です。 この API は、Azure Active Directory (Azure AD) を使って、アプリまたはサービスからの呼び出しを認証します。

この手順では、Microsoft Store 申請 API を使う場合のプロセスについて詳しく説明します。

1.  すべての[前提条件](#prerequisites)を完了したことを確認します。
3.  Microsoft Store 申請 API のメソッドを呼び出す前に、[Azure AD アクセス トークンを取得](#obtain-an-azure-ad-access-token)する必要があります。 トークンを取得した後、Microsoft Store 申請 API の呼び出しでこのトークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れた後は、新しいトークンを生成できます。
4.  [Microsoft Store 申請 API を呼び出します](#call-the-windows-store-submission-api)。

<span id="not_supported" />

> [!IMPORTANT]
> この API を使用してアプリ、パッケージ フライト、アドオンの申請を作成する場合は、申請をさらに変更するには、デベロッパー センターのダッシュボードではなく、API のみを使用して行ってください。 最初に API を使って作成した申請を、ダッシュボードを使って変更した場合、API を使ってその申請を変更またはコミットすることができなくなります。 場合によっては、申請がエラー状態のままになり、申請プロセスを進めることができなくなります。 この問題が発生した場合は、申請を削除して、新しい申請を作成する必要があります。

> [!IMPORTANT]
> この API を使って、[ビジネス向け Microsoft Store や教育機関向け Microsoft Store でのボリューム購入](../publish/organizational-licensing.md)の申請を公開したり、[LOB アプリ](../publish/distribute-lob-apps-to-enterprises.md)の申請を直接企業に発行したりすることはできません。 このようなシナリオでは、どちらの場合も Windows デベロッパー センター ダッシュボードを使って申請を公開する必要があります。

> [!NOTE]
> この API は、アプリの必須更新プログラムや Store で管理されるコンシューマブルなアドオンを使うアプリまたはアドオンでは使用できません。 このような機能のいずれかを使用するアプリまたはアドオンで Microsoft Store 申請 API を使うと、API から 409 エラー コードが返されます。 この場合は、ダッシュボードを使ってアドオンまたはアプリの申請を管理する必要があります。

<span id="prerequisites" />

## <a name="step-1-complete-prerequisites-for-using-the-microsoft-store-submission-api"></a>手順 1. Microsoft Store 申請 API を使うための前提条件を満たす

Microsoft Store 申請 API を呼び出すコードの作成を開始する前に、次の前提条件が満たされていることを確認します。

* ユーザー (またはユーザーの組織) は、Azure AD ディレクトリと、そのディレクトリに対する[全体管理者](http://go.microsoft.com/fwlink/?LinkId=746654)のアクセス許可を持っている必要があります。 Office 365 または Microsoft の他のビジネス サービスを既に使っている場合は、既に Azure AD ディレクトリをお持ちです。 それ以外の場合は、追加料金なしで[デベロッパー センター内から新しい Azure AD を作成](../publish/associate-azure-ad-with-dev-center.md#create-a-brand-new-azure-ad-to-associate-with-your-partner-center-account)できます。

* [Azure AD アプリケーションを Windows デベロッパー センター アカウントに関連付け](#associate-an-azure-ad-application-with-your-windows-dev-center-account)、テナント ID、クライアント ID、キーを取得する必要があります。 これらの値は、Microsoft Store 申請 API の呼び出しで使用する Azure AD アクセス トークンを取得するために必要です。

* Microsoft Store 申請 API で使うアプリを準備します。

  * アプリがデベロッパー センターにまだ存在しない場合は、[デベロッパー センター ダッシュボードでアプリを作成](https://msdn.microsoft.com/windows/uwp/publish/create-your-app-by-reserving-a-name)します。 Microsoft Store 申請 API を使ってデベロッパー センターにアプリを作成することはできません。つまり、ダッシュボードを使ってアプリを作成する必要があります。その後、API を使ってアプリにアクセスし、プログラムでアプリの申請を作成できます。 ただし、API を使うと、アプリの申請を作成する前に、アドオンとパッケージ フライトをプログラムで作成できます。

  * この API を使って特定のアプリの申請を作成する前に、[年齢区分](https://msdn.microsoft.com/windows/uwp/publish/age-ratings)に関する質問への回答など、最初に[デベロッパー センター ダッシュボードでアプリの申請を 1 つ作成する](https://msdn.microsoft.com/windows/uwp/publish/app-submissions)必要があります。 この操作の実行後、API を使ってこのアプリの新しい申請をプログラムで作成できるようになります。 アドオンの申請またはパッケージ フライトの申請を作成しなくても、このような申請に API を使うことができます。

  * アプリの申請を作成または更新するときにアプリ パッケージを追加する必要がある場合は、[アプリ パッケージを準備](https://msdn.microsoft.com/windows/uwp/publish/app-package-requirements)します。

  * アプリの申請を作成または更新するときにストア登録情報用のスクリーンショットまたは画像を含める必要がある場合は、[アプリのスクリーンショットと画像を準備](https://msdn.microsoft.com/windows/uwp/publish/app-screenshots-and-images)します。

  * アドオンの申請を作成または更新するときにアイコンを含める必要がある場合は、[アイコンを準備](https://msdn.microsoft.com/windows/uwp/publish/create-iap-descriptions#icon)します。

<span id="associate-an-azure-ad-application-with-your-windows-dev-center-account" />

### <a name="how-to-associate-an-azure-ad-application-with-your-windows-dev-center-account"></a>Azure AD アプリケーションを Windows デベロッパー センター アカウントに関連付ける方法

Microsoft Store 申請 API を使うには、事前に Azure AD アプリケーションをデベロッパー センター アカウントに関連付け、アプリケーションのテナント ID とクライアント ID を取得して、キーを生成しておく必要があります。 Azure AD アプリケーションは、Microsoft Store 申請 API の呼び出し元のアプリまたはサービスを表します。 テナント ID、クライアント ID、およびキーは、API に渡す Azure AD アクセス トークンを取得するために必要です。

> [!NOTE]
> この作業を行うのは一度だけです。 テナント ID、クライアント ID、キーがあれば、新しい Azure AD アクセス トークンの作成が必要になったときに、いつでもそれらを再利用できます。

1.  デベロッパー センターで、[組織のデベロッパー センター アカウントと組織の Azure AD ディレクトリを関連付けます](../publish/associate-azure-ad-with-dev-center.md)。

2.  次に、デベロッパー センターの **[アカウント設定]** セクションの **[ユーザー]** ページから、デベロッパー センター アカウントの申請へのアクセスに使うアプリやサービスを表す [Azure AD アプリケーションを追加](../publish/add-users-groups-and-azure-ad-applications.md#add-azure-ad-applications-to-your-partner-center-account)します。 このアプリケーションに必ず**マネージャー** ロールを割り当てます。 アプリケーションが Azure AD ディレクトリにまだ存在しない場合は、[デベロッパー センターで新しい Azure AD アプリケーションを作成](../publish/add-users-groups-and-azure-ad-applications.md#create-a-new-azure-ad-application-account-in-your-organizations-directory-and-add-it-to-your-partner-center-account)することができます。  

3.  **[ユーザー]** ページに戻り、Azure AD アプリケーションの名前をクリックしてアプリケーション設定に移動し、**[テナント ID]** と **[クライアント ID]** の値を書き留めます。

4. **[新しいキーの追加]** をクリックします。 次の画面で、**[キー]** の値を書き留めます。 このページから離れると、この情報に再度アクセスすることはできません。 詳しくは、「[Azure AD アプリケーションのキーを管理する方法](../publish/add-users-groups-and-azure-ad-applications.md#manage-keys)」をご覧ください。

<span id="obtain-an-azure-ad-access-token" />

## <a name="step-2-obtain-an-azure-ad-access-token"></a>手順 2: Azure AD のアクセス トークンを取得する

Microsoft Store 申請 API のいずれかのメソッドを呼び出す前に、まず API の各メソッドの **Authorization** ヘッダーに渡す Azure AD アクセス トークンを取得する必要があります。 アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れた後は、トークンを更新してそれ以降の API 呼び出しで引き続き使用できます。

アクセス トークンを取得するには、「[クライアント資格情報を使用したサービス間の呼び出し](https://azure.microsoft.com/documentation/articles/active-directory-protocols-oauth-service-to-service/)」の手順に従って、HTTP POST を ```https://login.microsoftonline.com/<tenant_id>/oauth2/token``` エンドポイントに送信します。 要求の例を次に示します。

```
POST https://login.microsoftonline.com/<tenant_id>/oauth2/token HTTP/1.1
Host: login.microsoftonline.com
Content-Type: application/x-www-form-urlencoded; charset=utf-8

grant_type=client_credentials
&client_id=<your_client_id>
&client_secret=<your_client_secret>
&resource=https://manage.devcenter.microsoft.com
```

POST URI の *tenant\_id* の値と *client \_id* および *client \_secret* のパラメーターには、前のセクションでデベロッパー センターから取得したテナント ID、クライアント ID、キーを指定します。 *resource* パラメーターには、```https://manage.devcenter.microsoft.com``` を指定します。

アクセス トークンの有効期限が切れた後は、[この](https://azure.microsoft.com/documentation/articles/active-directory-protocols-oauth-code/#refreshing-the-access-tokens)手順に従って更新できます。

C#、Java、または Python コードを使ってアクセス トークンを取得する方法を示す例については、Microsoft Store 申請 API の[コード例](#code-examples)をご覧ください。

<span id="call-the-windows-store-submission-api">

## <a name="step-3-use-the-microsoft-store-submission-api"></a>手順 3. Microsoft Store 申請 API を使用する

Azure AD アクセス トークンを取得したら、Microsoft Store 申請 API のメソッドを呼び出すことができます。 この API には、アプリ、アドオン、パッケージ フライトのシナリオにグループ化される多くのメソッドが含まれています。 申請を作成または更新するには、通常、Microsoft Store 申請 API の複数のメソッドを特定の順序で呼び出します。 各シナリオと各メソッドの構文について詳しくは、次の表の記事をご覧ください。

> [!NOTE]
> アクセス トークンを取得した後、Microsoft Store 申請 API のメソッドを呼び出すことができるのは、その有効期限が切れるまでの 60 分間です。

| シナリオ       | 説明                                                                 |
|---------------|----------------------------------------------------------------------|
| アプリ |  Windows デベロッパー センター アカウントに登録されているすべてのアプリのデータを取得し、アプリの申請を作成します。 これらのメソッドについて詳しくは、次の記事をご覧ください。 <ul><li>[アプリ データの取得](get-app-data.md)</li><li>[アプリの申請の管理](manage-app-submissions.md)</li></ul> |
| アドオン | アプリのアドオンを取得、作成、または削除した後、そのアドオンの申請を取得、作成、または削除します。 これらのメソッドについて詳しくは、次の記事をご覧ください。 <ul><li>[アドオンの管理](manage-add-ons.md)</li><li>[アドオンの申請の管理](manage-add-on-submissions.md)</li></ul> |
| パッケージ フライト | アプリのパッケージ フライトを取得、作成、または削除した後、パッケージ フライトの申請を取得、作成、または削除します。 これらのメソッドについて詳しくは、次の記事をご覧ください。 <ul><li>[パッケージ フライトの管理](manage-flights.md)</li><li>[パッケージ フライトの申請の管理](manage-flight-submissions.md)</li></ul> |

<span id="code-samples"/>

## <a name="code-examples"></a>コード例

次の記事では、さまざまなプログラミング言語で Microsoft Store 申請 API を使用する方法を示す詳しいコード例を紹介します。

* [C# のコード例: アプリ、アドオン、およびフライトの申請](csharp-code-examples-for-the-windows-store-submission-api.md)
* [C# のコード例: ゲーム オプションおよびトレーラーを含むアプリの申請](csharp-code-examples-for-submissions-game-options-and-trailers.md)
* [Java のコード例: アプリ、アドオン、およびフライトの申請](java-code-examples-for-the-windows-store-submission-api.md)
* [Java のコード例: ゲーム オプションおよびトレーラーを含むアプリの申請](java-code-examples-for-submissions-game-options-and-trailers.md)
* [Python のコード例: アプリ、アドオン、およびフライトの申請](python-code-examples-for-the-windows-store-submission-api.md)
* [Python のコード例: ゲーム オプションおよびトレーラーを含むアプリの申請](python-code-examples-for-submissions-game-options-and-trailers.md)

## <a name="storebroker-powershell-module"></a>StoreBroker PowerShell モジュール

Microsoft Store 申請 API を直接呼び出す代わりに、API の上にコマンド ライン インターフェイスを実装するオープンソースの PowerShell モジュールも用意されています。 このモジュールは、[StoreBroker](https://aka.ms/storebroker) と呼ばれています。 このモジュールを使うと、Microsoft Store 申請 API を直接呼び出さずに、コマンド ラインからアプリ、フライト、アドオンの申請を管理できます。また、ソースを参照して、この API を呼び出す方法の例を確認することもできます。 StoreBroker モジュールは、多くのファースト パーティ アプリケーションをストアに申請する主要な方法として Microsoft 内で積極的に使っています。

詳しくは、[GitHub の StoreBroker のページ](https://aka.ms/storebroker)をご覧ください。

## <a name="troubleshooting"></a>トラブルシューティング

| 問題      | 解決方法                                          |
|---------------|---------------------------------------------|
| PowerShell から Microsoft Store 申請 API を呼び出した後、[ConvertFrom-Json](https://technet.microsoft.com/library/hh849898.aspx) コマンドレットを使って API の応答データを JSON 形式から PowerShell オブジェクトに変換し、[ConvertTo-Json](https://technet.microsoft.com/library/hh849922.aspx) コマンドレットを使ってもう一度 JSON 形式に変換すると、応答データが破損します。 |  既定では、[ConvertTo-Json](https://technet.microsoft.com/library/hh849922.aspx) コマンドレットの *-Depth* パラメーターは、2 レベルのオブジェクトに設定されます。これは、Microsoft Store 申請 API から返される JSON オブジェクトの大半にとって浅すぎます。 [ConvertTo-Json](https://technet.microsoft.com/library/hh849922.aspx) コマンドレットを呼び出すときは、*-Depth* パラメーターを大きい値 (たとえば 20) に設定します。 |

## <a name="additional-help"></a>追加のヘルプ

Microsoft Store 申請 API について質問がある場合や、この API を使った申請の管理に関してサポートが必要な場合は、次のリソースを使ってください。

* Microsoft の[フォーラム](https://social.msdn.microsoft.com/Forums/windowsapps/home?forum=wpsubmit)で質問します。
* Microsoft の[サポート ページ](https://developer.microsoft.com/windows/support)にアクセスし、デベロッパー センター ダッシュボードのサポート オプションのいずれかを要求します。 問題の種類とカテゴリを選択するよう求められた場合は、**[App submission and certification]** (アプリの申請と認定) と **[Submitting an app]** (アプリの申請) をそれぞれ選択します。  

## <a name="related-topics"></a>関連トピック

* [アプリ データの取得](get-app-data.md)
* [アプリの申請の管理](manage-app-submissions.md)
* [アドオンの管理](manage-add-ons.md)
* [アドオンの申請の管理](manage-add-on-submissions.md)
* [パッケージ フライトの管理](manage-flights.md)
* [パッケージ フライトの申請の管理](manage-flight-submissions.md)
