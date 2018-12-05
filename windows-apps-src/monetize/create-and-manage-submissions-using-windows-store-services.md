---
ms.assetid: 7CC11888-8DC6-4FEE-ACED-9FA476B2125E
description: プログラムで作成し、パートナー センター アカウントに登録されているアプリの申請を管理するには、Microsoft Store 申請 API を使用します。
title: 申請の作成と管理
ms.date: 06/04/2018
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store 申請 API
ms.localizationpriority: medium
ms.openlocfilehash: 2122c259e78ce96c4553dd676c0c1ed78e4e7123
ms.sourcegitcommit: d7613c791107f74b6a3dc12a372d9de916c0454b
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/05/2018
ms.locfileid: "8738237"
---
# <a name="create-and-manage-submissions"></a>申請の作成と管理


プログラムで照会したり、アプリ、アドオン、および、自分または自分の組織のパートナー センター アカウントのパッケージ フライトの申請を作成するには、 *Microsoft Store 申請 API*を使用します。 この API は、アカウントで多数のアプリやアドオンを管理しており、こうしたアセットの申請プロセスを自動化および最適化する場合に便利です。 この API は、Azure Active Directory (Azure AD) を使って、アプリまたはサービスからの呼び出しを認証します。

この手順では、Microsoft Store 申請 API を使う場合のプロセスについて詳しく説明します。

1.  すべての[前提条件](#prerequisites)を完了したことを確認します。
3.  Microsoft Store 申請 API のメソッドを呼び出す前に、[Azure AD アクセス トークンを取得](#obtain-an-azure-ad-access-token)する必要があります。 トークンを取得した後、Microsoft Store 申請 API の呼び出しでこのトークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れた後は、新しいトークンを生成できます。
4.  [Microsoft Store 申請 API を呼び出します](#call-the-windows-store-submission-api)。

<span id="not_supported" />

> [!IMPORTANT]
> この API を使用してアプリ、パッケージ フライトの場合、またはアドオンの申請を作成する場合は、パートナー センターではなく、API を使用してのみ、申請をさらを変更することを確認します。 パートナー センターを使用して、API を使用して最初に作成した申請を変更する場合は、変更または API を使用して、その申請をコミットすることはできなくなります。 場合によっては、申請がエラー状態のままになり、申請プロセスを進めることができなくなります。 この問題が発生した場合は、申請を削除して、新しい申請を作成する必要があります。

> [!IMPORTANT]
> この API を使って、[ビジネス向け Microsoft Store や教育機関向け Microsoft Store でのボリューム購入](../publish/organizational-licensing.md)の申請を公開したり、[LOB アプリ](../publish/distribute-lob-apps-to-enterprises.md)の申請を直接企業に発行したりすることはできません。 使用する必要がありますの両方のシナリオには、パートナー センターで、申請を公開します。

> [!NOTE]
> この API は、アプリの必須更新プログラムや Store で管理されるコンシューマブルなアドオンを使うアプリまたはアドオンでは使用できません。 このような機能のいずれかを使用するアプリまたはアドオンで Microsoft Store 申請 API を使うと、API から 409 エラー コードが返されます。 この例では、アプリやアドオンの申請を管理するのにパートナー センターを使用する必要があります。

<span id="prerequisites" />

## <a name="step-1-complete-prerequisites-for-using-the-microsoft-store-submission-api"></a>手順 1. Microsoft Store 申請 API を使うための前提条件を満たす

Microsoft Store 申請 API を呼び出すコードの作成を開始する前に、次の前提条件が満たされていることを確認します。

* ユーザー (またはユーザーの組織) は、Azure AD ディレクトリと、そのディレクトリに対する[全体管理者](http://go.microsoft.com/fwlink/?LinkId=746654)のアクセス許可を持っている必要があります。 Office 365 または Microsoft の他のビジネス サービスを既に使っている場合は、既に Azure AD ディレクトリをお持ちです。 それ以外の場合、追加料金なしの[パートナー センターで新しい Azure AD を作成](../publish/associate-azure-ad-with-partner-center.md#create-a-brand-new-azure-ad-to-associate-with-your-partner-center-account)できます。

* [Azure AD アプリケーションをパートナー センター アカウントに関連付ける](#associate-an-azure-ad-application-with-your-windows-partner-center-account)必要があり、ID、クライアント ID、キー、テナントを取得します。 これらの値は、Microsoft Store 申請 API の呼び出しで使用する Azure AD アクセス トークンを取得するために必要です。

* Microsoft Store 申請 API で使うアプリを準備します。

  * パートナー センターでも、アプリがまだ存在しない場合は[パートナー センターでその名前を予約してアプリを作成](https://msdn.microsoft.com/windows/uwp/publish/create-your-app-by-reserving-a-name)する必要があります。 パートナー センターにアプリを作成するのには、Microsoft Store 申請 API を使うことはできません。作成して、パートナー センターで作業する必要し、し、その後できる API を使用するアプリへのアクセスをプログラムでの申請を作成します。 ただし、API を使うと、アプリの申請を作成する前に、アドオンとパッケージ フライトをプログラムで作成できます。

  * この API を使用して、特定のアプリの申請を作成する前にまず[パートナー センターで、アプリの 1 つの申請の作成](https://msdn.microsoft.com/windows/uwp/publish/app-submissions)を含む、[年齢区分](https://msdn.microsoft.com/windows/uwp/publish/age-ratings)のアンケートへの回答する必要があります。 この操作の実行後、API を使ってこのアプリの新しい申請をプログラムで作成できるようになります。 アドオンの申請またはパッケージ フライトの申請を作成しなくても、このような申請に API を使うことができます。

  * アプリの申請を作成または更新するときにアプリ パッケージを追加する必要がある場合は、[アプリ パッケージを準備](https://msdn.microsoft.com/windows/uwp/publish/app-package-requirements)します。

  * アプリの申請を作成または更新するときにストア登録情報用のスクリーンショットまたは画像を含める必要がある場合は、[アプリのスクリーンショットと画像を準備](https://msdn.microsoft.com/windows/uwp/publish/app-screenshots-and-images)します。

  * アドオンの申請を作成または更新するときにアイコンを含める必要がある場合は、[アイコンを準備](https://msdn.microsoft.com/windows/uwp/publish/create-iap-descriptions#icon)します。

<span id="associate-an-azure-ad-application-with-your-windows-partner-center-account" />

### <a name="how-to-associate-an-azure-ad-application-with-your-partner-center-account"></a>Azure AD アプリケーションをパートナー センター アカウントに関連付ける方法

Microsoft Store 申請 API を使用する前に、Azure AD アプリケーションをパートナー センター アカウントに関連付けしてテナント ID とアプリケーションのクライアント ID を取得してキーを生成する必要があります。 Azure AD アプリケーションは、Microsoft Store 申請 API の呼び出し元のアプリまたはサービスを表します。 テナント ID、クライアント ID、およびキーは、API に渡す Azure AD アクセス トークンを取得するために必要です。

> [!NOTE]
> この作業を行うのは一度だけです。 テナント ID、クライアント ID、キーがあれば、新しい Azure AD アクセス トークンの作成が必要になったときに、いつでもそれらを再利用できます。

1.  パートナー センターで、[組織のパートナー センターのアカウントを組織の Azure AD ディレクトリを関連付けます](../publish/associate-azure-ad-with-partner-center.md)。

2.  次に、パートナー センター、 [Azure AD アプリケーションの追加](../publish/add-users-groups-and-azure-ad-applications.md#add-azure-ad-applications-to-your-partner-center-account)を表す、アプリまたはサービスのパートナー センターのアカウントの申請へのアクセスを使用する**アカウント設定**] セクションで、**ユーザー**ページから。 このアプリケーションに必ず**マネージャー** ロールを割り当てます。 アプリケーションが存在しない場合、Azure AD ディレクトリで実行できます[新しいパートナー センターで Azure AD アプリケーション](../publish/add-users-groups-and-azure-ad-applications.md#create-a-new-azure-ad-application-account-in-your-organizations-directory-and-add-it-to-your-partner-center-account)します。  

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

POST URI と*client \_id*と*client \_secret*パラメーターで、 *tenant\_id*値のテナント ID、クライアント ID および前のセクションで、パートナー センターから取得したアプリケーションのキーを指定します。 *resource* パラメーターには、```https://manage.devcenter.microsoft.com``` を指定します。

アクセス トークンの有効期限が切れた後は、[この](https://azure.microsoft.com/documentation/articles/active-directory-protocols-oauth-code/#refreshing-the-access-tokens)手順に従って更新できます。

C#、Java、または Python コードを使ってアクセス トークンを取得する方法を示す例については、Microsoft Store 申請 API の[コード例](#code-examples)をご覧ください。

<span id="call-the-windows-store-submission-api">

## <a name="step-3-use-the-microsoft-store-submission-api"></a>手順 3. Microsoft Store 申請 API を使用する

Azure AD アクセス トークンを取得したら、Microsoft Store 申請 API のメソッドを呼び出すことができます。 この API には、アプリ、アドオン、パッケージ フライトのシナリオにグループ化される多くのメソッドが含まれています。 申請を作成または更新するには、通常、Microsoft Store 申請 API の複数のメソッドを特定の順序で呼び出します。 各シナリオと各メソッドの構文について詳しくは、次の表の記事をご覧ください。

> [!NOTE]
> アクセス トークンを取得した後、Microsoft Store 申請 API のメソッドを呼び出すことができるのは、その有効期限が切れるまでの 60 分間です。

| シナリオ       | 説明                                                                 |
|---------------|----------------------------------------------------------------------|
| アプリ |  パートナー センター アカウントに登録され、アプリの申請を作成するすべてのアプリのデータを取得します。 これらのメソッドについて詳しくは、次の記事をご覧ください。 <ul><li>[アプリ データの取得](get-app-data.md)</li><li>[アプリの申請の管理](manage-app-submissions.md)</li></ul> |
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
* マイクロソフトの[サポート ページ](https://developer.microsoft.com/windows/support)を参照してください。 し、パートナー センターのサポート オプションのいずれかを要求します。 問題の種類とカテゴリを選択するよう求められた場合は、**[App submission and certification]** (アプリの申請と認定) と **[Submitting an app]** (アプリの申請) をそれぞれ選択します。  

## <a name="related-topics"></a>関連トピック

* [アプリ データの取得](get-app-data.md)
* [アプリの申請の管理](manage-app-submissions.md)
* [アドオンの管理](manage-add-ons.md)
* [アドオンの申請の管理](manage-add-on-submissions.md)
* [パッケージ フライトの管理](manage-flights.md)
* [パッケージ フライトの申請の管理](manage-flight-submissions.md)
