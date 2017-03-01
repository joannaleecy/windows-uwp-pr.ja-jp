---
author: mcleanbyron
ms.assetid: 7CC11888-8DC6-4FEE-ACED-9FA476B2125E
description: "Windows ストア申請 API を使用して、Windows デベロッパー センター アカウントに登録されているアプリの申請をプログラムで作成および管理します。"
title: "Windows ストア サービスを使用した申請の作成と管理"
ms.author: mcleans
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10、UWP、Windows ストア申請 API"
translationtype: Human Translation
ms.sourcegitcommit: c6b64cff1bbebc8ba69bc6e03d34b69f85e798fc
ms.openlocfilehash: f73470c456bf59544bc702b137da64f57c6a6943
ms.lasthandoff: 02/07/2017

---

# <a name="create-and-manage-submissions-using-windows-store-services"></a>Windows ストア サービスを使用した申請の作成と管理


*Windows ストア申請 API* を使用し、自分または自分の組織の Windows デベロッパー センター アカウントに対して、アプリ、アドオン (アプリ内製品または IAP とも呼ばれます)、パッケージ フライトの申請をプログラムによって照会して、作成します。 この API は、アカウントで多数のアプリやアドオンを管理しており、こうしたアセットの申請プロセスを自動化および最適化する場合に便利です。 この API は、Azure Active Directory (Azure AD) を使って、アプリまたはサービスからの呼び出しを認証します。

この手順では、Windows ストア申請 API を使用した場合のプロセスについて詳しく説明します。

1.  すべての[前提条件](#prerequisites)を完了したことを確認します。
3.  Windows ストア申請 API でメソッドを呼び出す前に、[Azure AD アクセス トークンを取得](#obtain-an-azure-ad-access-token)する必要があります。 トークンを取得した後、Windows ストア申請 API への呼び出しでこのトークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れた後は、新しいトークンを生成できます。
4.  [Windows ストア申請 API を呼び出します](#call-the-windows-store-submission-api)。


<span id="not_supported" />
>**重要な注意**

> * この API は、API を使用するアクセス許可が付与された Windows デベロッパー センター アカウントにのみ使用できます。 このアクセス許可は、開発者アカウントに対して段階的に有効になります。現時点では、すべてのアカウントでこのアクセス許可が有効になっているわけではありません。 以前のアクセス権を要求するには、デベロッパー センター ダッシュボードにログオンし、ダッシュ ボードの下部にある **[フィードバック]** をクリックします。その後、フィードバック領域で **[申請 API]** を選択し、要求を提出します。 自分のアカウントでこのアクセス許可が有効になると、メールが届きます。
<br/><br/>
>* この API を使用してアプリ、パッケージ フライト、アドオンの申請を作成する場合は、申請をさらに変更するには、デベロッパー センターのダッシュボードではなく、API のみを使用して行ってください。 最初に API を使用して作成した申請をダッシュボードを使用して変更した場合、その申請を API を使用して変更またはコミットすることはできなくなります。 場合によっては、申請がエラー状態のままとなり、申請プロセスを進行できないことがあります。 この問題が発生した場合は、申請を削除して、新しい申請を作成する必要があります。
<br/><br/>
> * この API は、2016 年 8 月にデベロッパー センター ダッシュボードに導入された特定の機能を使用するアプリまたはアドオンで使用できません。これには、必須のアプリの更新プログラムとストアで管理されるコンシューマブルなアドオンが含まれますが、これらに限定されません。 このような機能のいずれかを使用するアプリまたはアドオンで Windows ストア申請 API を使うと、API から 409 エラー コードが返されます。 この場合は、ダッシュボードを使ってアドオンまたはアプリの申請を管理する必要があります。


<span id="prerequisites" />
## <a name="step-1-complete-prerequisites-for-using-the-windows-store-submission-api"></a>手順 1. Windows ストア申請 API を使うための前提条件を完了する

Windows ストア申請 API を呼び出すコードの作成を開始する前に、次の前提条件が完了していることを確認します。

* ユーザー (またはユーザーの組織) は、Azure AD ディレクトリと、そのディレクトリに対する[全体管理者](http://go.microsoft.com/fwlink/?LinkId=746654)のアクセス許可を持っている必要があります。 Office 365 または Microsoft の他のビジネス サービスを既に使っている場合は、既に Azure AD ディレクトリをお持ちです。 それ以外の場合は、追加料金なしで[デベロッパー センター内から新しい Azure AD を作成](https://msdn.microsoft.com/windows/uwp/publish/manage-account-users)できます。

* [Azure AD アプリケーションを Windows デベロッパー センター アカウントに関連付け](#associate-an-azure-ad-application-with-your-windows-dev-center-account)、テナント ID、クライアント ID、キーを取得する必要があります。 これらの値は、Windows ストア申請 API の呼び出しで使用する Azure AD アクセス トークンを取得するために必要です。

* Windows ストア申請 API で使うアプリを準備します。

  * アプリがデベロッパー センターにまだ存在しない場合は、[デベロッパー センター ダッシュボードでアプリを作成](https://msdn.microsoft.com/windows/uwp/publish/create-your-app-by-reserving-a-name)します。 Windows ストア申請 API を使ってデベロッパー センターにアプリを作成することはできません。つまり、ダッシュボードを使ってアプリを作成する必要があります。その後、API を使ってアプリにアクセスし、プログラムでアプリの申請を作成できます。 ただし、API を使うと、アプリの申請を作成する前に、アドオンとパッケージ フライトをプログラムで作成できます。

  * この API を使って特定のアプリの申請を作成する前に、[年齢区分](https://msdn.microsoft.com/windows/uwp/publish/age-ratings)に関する質問への回答など、最初に[デベロッパー センター ダッシュボードでアプリの申請を 1 つ作成する](https://msdn.microsoft.com/windows/uwp/publish/app-submissions)必要があります。 この操作の実行後、API を使ってこのアプリの新しい申請をプログラムで作成できるようになります。 アドオンの申請またはパッケージ フライトの申請を作成しなくても、このような申請に API を使うことができます。

  * アプリの申請を作成または更新するときにアプリ パッケージを追加する必要がある場合は、[アプリ パッケージを準備](https://msdn.microsoft.com/windows/uwp/publish/app-package-requirements)します。

  * アプリの申請を作成または更新するときにストア登録情報用のスクリーンショットまたは画像を含める必要がある場合は、[アプリのスクリーンショットと画像を準備](https://msdn.microsoft.com/windows/uwp/publish/app-screenshots-and-images)します。

  * アドオンの申請を作成または更新するときにアイコンを含める必要がある場合は、[アイコンを準備](https://msdn.microsoft.com/windows/uwp/publish/create-iap-descriptions#icon)します。

<span id="associate-an-azure-ad-application-with-your-windows-dev-center-account" />
### <a name="how-to-associate-an-azure-ad-application-with-your-windows-dev-center-account"></a>Azure AD アプリケーションを Windows デベロッパー センター アカウントに関連付ける方法

Windows ストア申請 API を使うには、事前に Azure AD アプリケーションをデベロッパー センター アカウントに関連付け、アプリケーションのテナント ID とクライアント ID を取得して、キーを生成しておく必要があります。 Azure AD アプリケーションは、Windows ストア申請 API の呼び出し元のアプリまたはサービスを表します。 テナント ID、クライアント ID、およびキーは、API に渡す Azure AD アクセス トークンを取得するために必要です。

>**注:**&nbsp;&nbsp;この作業を行うのは一度だけです。 テナント ID、クライアント ID、キーがあれば、新しい Azure AD アクセス トークンの作成が必要になったときに、いつでもそれらを再利用できます。

1.  デベロッパー センターで、**[アカウント設定]** に移動して **[ユーザーの管理]** をクリックし、組織のデベロッパー センター アカウントを組織の Azure AD ディレクトリに関連付けます。 詳しい手順については、「[アカウント ユーザーの管理](https://msdn.microsoft.com/windows/uwp/publish/manage-account-users)」をご覧ください。

2.  **[ユーザーの管理]** ページで、**[Azure AD アプリケーションの追加]** をクリックして、デベロッパー センター アカウントの申請へのアクセスに使うアプリやサービスを表す Azure AD アプリケーションを追加し、**マネージャー** ロールを割り当てます。 このアプリケーションが既に Azure AD ディレクトリに存在する場合、**[Azure AD アプリケーションの追加]** ページで選んでデベロッパー センター アカウントに追加できます。 それ以外の場合、**[Azure AD アプリケーションの追加]** ページで新しい Azure AD アプリケーションを作成できます。 詳しくは、「[Azure AD アプリケーションを追加して管理する](https://msdn.microsoft.com/windows/uwp/publish/manage-account-users#add-and-manage-azure-ad-applications)」をご覧ください。

3.  **[ユーザーの管理]** ページに戻り、Azure AD アプリケーションの名前をクリックしてアプリケーション設定に移動し、**[テナント ID]** と **[クライアント ID]** の値を書き留めます。

4. **[新しいキーの追加]** をクリックします。 次の画面で、**[キー]** の値を書き留めます。 このページから離れると、この情報に再度アクセスすることはできません。 詳しくは、「[Azure AD アプリケーションを追加して管理する](https://msdn.microsoft.com/windows/uwp/publish/manage-account-users#add-and-manage-azure-ad-applications)」でキーの管理に関する情報をご覧ください。

<span id="obtain-an-azure-ad-access-token" />
## <a name="step-2-obtain-an-azure-ad-access-token"></a>手順 2. Azure AD のアクセス トークンを取得する

Windows ストア申請 API で任意のメソッドを呼び出す前に、API 内の各メソッドの **Authorization** ヘッダーに渡す Azure AD アクセス トークンをまず取得する必要があります アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れた後は、トークンを更新してそれ以降の API 呼び出しで引き続き使用できます。

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

C#、Java、または Python コードを使用してアクセス トークンを取得する方法を示す例については、Windows ストア申請 API の[コード例](#code-examples)をご覧ください。

<span id="call-the-windows-store-submission-api">
## <a name="step-3-use-the-windows-store-submission-api"></a>手順 3. Windows ストア申請 API を使用する

Azure AD アクセス トークンを取得したら、Windows ストア申請 API のメソッドを呼び出すことができます。 この API には、アプリ、アドオン、パッケージ フライトのシナリオにグループ化される多くのメソッドが含まれています。 申請を作成または更新するには、通常、Windows ストア申請 API 内の複数のメソッドを特定の順序で呼び出します。 各シナリオと各メソッドの構文について詳しくは、次の表の記事をご覧ください。

>**注:**&nbsp;&nbsp;アクセス トークンを取得した後、Windows ストア申請 API 内のメソッドを呼び出すことができるのは、その有効期限が切れるまでの 60 分間です。

| シナリオ       | 説明                                                                 |
|---------------|----------------------------------------------------------------------|
| アプリ |  Windows デベロッパー センター アカウントに登録されているすべてのアプリのデータを取得し、アプリの申請を作成します。 これらのメソッドについて詳しくは、次の記事をご覧ください。 <ul><li>[アプリ データの入手](get-app-data.md)</li><li>[アプリの申請の管理](manage-app-submissions.md)</li></ul> |
| アドオン | アプリのアドオンを取得、作成、または削除した後、そのアドオンの申請を取得、作成、または削除します。 これらのメソッドについて詳しくは、次の記事をご覧ください。 <ul><li>[アドオンの管理](manage-add-ons.md)</li><li>[アドオンの申請の管理](manage-add-on-submissions.md)</li></ul> |
| パッケージ フライト | アプリのパッケージ フライトを取得、作成、または削除した後、パッケージ フライトの申請を取得、作成、または削除します。 これらのメソッドについて詳しくは、次の記事をご覧ください。 <ul><li>[パッケージ フライトの管理](manage-flights.md)</li><li>[パッケージ フライトの申請の管理](manage-flight-submissions.md)</li></ul> |

<span id="code-samples"/>
## <a name="code-examples"></a>コード例

次の記事では、さまざまなプログラミング言語で Windows ストア申請 API を使用する方法を説明する詳しいコード例を紹介します。

* [C# のコード例](csharp-code-examples-for-the-windows-store-submission-api.md)
* [Java のコード例](java-code-examples-for-the-windows-store-submission-api.md)
* [Python のコード例](python-code-examples-for-the-windows-store-submission-api.md)

>**注:**&nbsp;&nbsp;上記のコード例に加えて、Windows ストア申請 API 上にコマンドライン インターフェイスを実装するオープン ソースの PowerShell モジュールも提供されています。 このモジュールは [StoreBroker](https://aka.ms/storebroker) を呼び出します。 このモジュールを使用すると、Windows ストア申請 API を直接呼び出すのではなく、コマンドラインからアプリ、フライト、アドオンの申請を管理できます。またこのソースを参照して、この API を呼び出す方法の例を参照することもできます。 StoreBroker モジュールは、Microsoft 社内でも、多くのファースト パーティ アプリケーションをストアに申請する主要な方法として積極的に使用されています。 詳しくは、[GitHub の StoreBroker のページ](https://aka.ms/storebroker)をご覧ください。

## <a name="troubleshooting"></a>トラブルシューティング

| 問題      | 解決方法                                          |
|---------------|---------------------------------------------|
| Windows ストア申請 API を PowerShell から呼び出した後、[ConvertFrom-Json](https://technet.microsoft.com/library/hh849898.aspx) コマンドレットを使って API の応答データを JSON 形式から PowerShell オブジェクトに変換し、[ConvertTo-Json](https://technet.microsoft.com/library/hh849922.aspx) コマンドレットを使ってもう一度 JSON 形式に変換すると、応答データが破損します。 |  既定では、[ConvertTo-Json](https://technet.microsoft.com/library/hh849922.aspx) コマンドレットの *-Depth* パラメーターは、2 レベルのオブジェクトに設定されます。これは、Windows ストア申請 API から返される JSON オブジェクトの大半にとって浅すぎます。 [ConvertTo-Json](https://technet.microsoft.com/library/hh849922.aspx) コマンドレットを呼び出すときは、*-Depth* パラメーターを大きな値 (たとえば 20) に設定します。 |

## <a name="additional-help"></a>追加のヘルプ

Windows ストア申請 API に関する質問がある場合やこの API を使った申請の管理にサポートが必要な場合は、次のリソースを使ってください。

* Microsoft の[フォーラム](https://social.msdn.microsoft.com/Forums/windowsapps/home?forum=wpsubmit)で質問します。
* Microsoft の[サポート ページ](https://developer.microsoft.com/windows/support)にアクセスし、デベロッパー センター ダッシュボードのサポート オプションのいずれかを要求します。 問題の種類とカテゴリを選択するよう求められた場合は、**[App submission and certification]** (アプリの申請と認定) と **[Submitting an app]** (アプリの申請) をそれぞれ選択します。  

## <a name="related-topics"></a>関連トピック

* [アプリ データの入手](get-app-data.md)
* [アプリの申請の管理](manage-app-submissions.md)
* [アドオンの管理](manage-add-ons.md)
* [アドオンの申請の管理](manage-add-on-submissions.md)
* [パッケージ フライトの管理](manage-flights.md)
* [パッケージ フライトの申請の管理](manage-flight-submissions.md)
 

