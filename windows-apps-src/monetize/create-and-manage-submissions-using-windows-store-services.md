---
ms.assetid: 7CC11888-8DC6-4FEE-ACED-9FA476B2125E
description: プログラムで作成して、パートナー センター アカウントに登録されているアプリの提出を管理するには、Microsoft Store 送信 API を使用します。
title: 申請の作成と管理
ms.date: 06/04/2018
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store 申請 API
ms.localizationpriority: medium
ms.openlocfilehash: 82e5ba10b8f0480f4d996840df26817e324111d8
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57613117"
---
# <a name="create-and-manage-submissions"></a>申請の作成と管理


使用して、 *Microsoft Store 送信 API*または組織のパートナー センター アカウントのフライトをプログラムによってクエリを実行し、アプリ、アドオン、およびパッケージのサブミッションを作成します。 この API は、アカウントで多数のアプリやアドオンを管理していて、それらのアセットの申請プロセスを自動化して最適化する必要がある場合に役立ちます。 この API は、Azure Active Directory (Azure AD) を使って、アプリまたはサービスからの呼び出しを認証します。

この手順では、Microsoft Store 申請 API を使う場合のプロセスについて詳しく説明します。

1.  すべての[前提条件](#prerequisites)を完了したことを確認します。
3.  Microsoft Store 申請 API のメソッドを呼び出す前に、[Azure AD アクセス トークンを取得](#obtain-an-azure-ad-access-token)する必要があります。 トークンを取得した後、Microsoft Store 申請 API の呼び出しでこのトークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れた後は、新しいトークンを生成できます。
4.  [Microsoft Store 申請 API を呼び出します](#call-the-windows-store-submission-api)。

<span id="not_supported" />

> [!IMPORTANT]
> この API を使用して、アプリの提出を作成すると、パッケージ、転送中、またはアドオンのパートナー センターではなく、API の使用によってのみ、送信をこれ以上を変更することを確認してがあります。 パートナー センターを使用して API を使用して作成した元の送信を変更する場合は、変更、または API を使用して送信をコミットすることはできなくなります。 場合によっては、申請がエラー状態のままになり、申請プロセスを進めることができなくなります。 この場合、申請を削除して新しい申請を作成する必要があります。

> [!IMPORTANT]
> この API を使って、[ビジネス向け Microsoft Store や教育機関向け Microsoft Store でのボリューム購入](../publish/organizational-licensing.md)の申請を公開したり、[LOB アプリ](../publish/distribute-lob-apps-to-enterprises.md)の申請を直接企業に発行したりすることはできません。 使用する必要がありますの両方のシナリオには、パートナー センターで、送信を発行します。

> [!NOTE]
> この API は、アプリの必須更新プログラムや Store で管理されるコンシューマブルなアドオンを使うアプリまたはアドオンでは使用できません。 このような機能のいずれかを使用するアプリまたはアドオンで Microsoft Store 申請 API を使うと、API から 409 エラー コードが返されます。 この場合は、パートナー センターを使用して、アプリまたはアドオンの送信を管理する必要があります。

<span id="prerequisites" />

## <a name="step-1-complete-prerequisites-for-using-the-microsoft-store-submission-api"></a>手順 1:Microsoft Store 送信 API を使用するための前提条件

Microsoft Store 申請 API を呼び出すコードの作成を開始する前に、次の前提条件が満たされていることを確認します。

* ユーザー (またはユーザーの組織) は、Azure AD ディレクトリと、そのディレクトリに対する[全体管理者](https://go.microsoft.com/fwlink/?LinkId=746654)のアクセス許可を持っている必要があります。 Office 365 または Microsoft の他のビジネス サービスを既に使っている場合は、既に Azure AD ディレクトリをお持ちです。 それ以外の場合は、追加料金なしに[パートナー センターで新しい Azure AD を作成](../publish/associate-azure-ad-with-partner-center.md#create-a-brand-new-azure-ad-to-associate-with-your-partner-center-account)できます。

* 必要があります[をパートナー センター アカウントを Azure AD アプリケーションに関連付ける](#associate-an-azure-ad-application-with-your-windows-partner-center-account)し、ID、クライアント ID とキー、テナントを取得します。 これらの値は、Microsoft Store 申請 API の呼び出しで使用する Azure AD アクセス トークンを取得するために必要です。

* Microsoft Store 申請 API で使うアプリを準備します。

  * パートナー センターでも、アプリがまだ存在しない場合は、まず[パートナー センターで名前を予約して、アプリを作成する](https://msdn.microsoft.com/windows/uwp/publish/create-your-app-by-reserving-a-name)します。 Microsoft Store 送信 API を使用して、パートナー センターでアプリを作成することはできません。作成して、パートナー センターで作業する必要がありますし、その後することができます、API を使用してアプリにアクセスし、その申請をプログラムで作成します。 ただし、API を使うと、アプリの申請を作成する前に、アドオンとパッケージ フライトをプログラムで作成できます。

  * この API を使用して、特定のアプリの提出を作成する前にする必要があります[パートナー センターでアプリの 1 つのサブミッションを作成する](https://msdn.microsoft.com/windows/uwp/publish/app-submissions)、応答を含む、[評価期間を表す](https://msdn.microsoft.com/windows/uwp/publish/age-ratings)アンケートです。 この操作の実行後、API を使ってこのアプリの新しい申請をプログラムで作成できるようになります。 アドオンの申請またはパッケージ フライトの申請を作成しなくても、このような申請に API を使うことができます。

  * アプリの申請を作成または更新するときにアプリ パッケージを追加する必要がある場合は、[アプリ パッケージを準備](https://msdn.microsoft.com/windows/uwp/publish/app-package-requirements)します。

  * アプリの申請を作成または更新するときにストア登録情報用のスクリーンショットまたは画像を含める必要がある場合は、[アプリのスクリーンショットと画像を準備](https://msdn.microsoft.com/windows/uwp/publish/app-screenshots-and-images)します。

  * アドオンの申請を作成または更新するときにアイコンを含める必要がある場合は、[アイコンを準備](https://msdn.microsoft.com/windows/uwp/publish/create-iap-descriptions#icon)します。

<span id="associate-an-azure-ad-application-with-your-windows-partner-center-account" />

### <a name="how-to-associate-an-azure-ad-application-with-your-partner-center-account"></a>Azure AD アプリケーションをパートナー センター アカウントに関連付ける方法

Microsoft Store 送信 API を使用する前に、Azure AD アプリケーションをパートナー センター アカウントに関連付けるテナント ID と、アプリケーションのクライアント ID を取得、キーを生成してください。 Azure AD アプリケーションは、Microsoft Store 申請 API の呼び出し元のアプリまたはサービスを表します。 テナント ID、クライアント ID、およびキーは、API に渡す Azure AD アクセス トークンを取得するために必要です。

> [!NOTE]
> この作業を行うのは一度だけです。 テナント ID、クライアント ID、キーがあれば、新しい Azure AD アクセス トークンの作成が必要になったときに、いつでもそれらを再利用できます。

1.  パートナー センターの[、組織の Azure AD ディレクトリと、組織のパートナー センター アカウントを関連付ける](../publish/associate-azure-ad-with-partner-center.md)します。

2.  [次へ]、**ユーザー**ページで、**アカウント設定**パートナー センターの「[して Azure AD アプリケーションを追加](../publish/add-users-groups-and-azure-ad-applications.md#add-azure-ad-applications-to-your-partner-center-account)アプリを使用してサービスを表すパートナー センター アカウント用のサブミッションにアクセスします。 このアプリケーションに必ず**マネージャー** ロールを割り当てます。 アプリケーションが存在しない場合、Azure AD ディレクトリで実行できます[を新規作成パートナー センターで Azure AD アプリケーション](../publish/add-users-groups-and-azure-ad-applications.md#create-a-new-azure-ad-application-account-in-your-organizations-directory-and-add-it-to-your-partner-center-account)します。  

3.  **[ユーザー]** ページに戻り、Azure AD アプリケーションの名前をクリックしてアプリケーション設定に移動し、**[テナント ID]** と **[クライアント ID]** の値を書き留めます。

4. **[新しいキーの追加]** をクリックします。 次の画面で、**[キー]** の値を書き留めます。 このページから離れると、この情報に再度アクセスすることはできません。 詳しくは、「[Azure AD アプリケーションのキーを管理する方法](../publish/add-users-groups-and-azure-ad-applications.md#manage-keys)」をご覧ください。

<span id="obtain-an-azure-ad-access-token" />

## <a name="step-2-obtain-an-azure-ad-access-token"></a>手順 2:Azure AD アクセス トークンの取得

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

*テナント\_id* POST URI の値と*クライアント\_id*と*クライアント\_シークレット*パラメーター、テナントの指定ID、クライアント ID、前のセクションで、パートナー センターから取得したアプリケーションのキー。 *resource* パラメーターには、```https://manage.devcenter.microsoft.com``` を指定します。

アクセス トークンの有効期限が切れた後は、[この](https://azure.microsoft.com/documentation/articles/active-directory-protocols-oauth-code/#refreshing-the-access-tokens)手順に従って更新できます。

C#、Java、または Python コードを使ってアクセス トークンを取得する方法を示す例については、Microsoft Store 申請 API の[コード例](#code-examples)をご覧ください。

<span id="call-the-windows-store-submission-api">

## <a name="step-3-use-the-microsoft-store-submission-api"></a>手順 3:Microsoft Store 送信 API を使用して、

Azure AD アクセス トークンを取得したら、Microsoft Store 申請 API のメソッドを呼び出すことができます。 この API には、アプリ、アドオン、パッケージ フライトのシナリオにグループ化される多くのメソッドが含まれています。 申請を作成または更新するには、通常、Microsoft Store 申請 API の複数のメソッドを特定の順序で呼び出します。 各シナリオと各メソッドの構文について詳しくは、次の表の記事をご覧ください。

> [!NOTE]
> アクセス トークンを取得した後、Microsoft Store 申請 API のメソッドを呼び出すことができるのは、その有効期限が切れるまでの 60 分間です。

| シナリオ       | 説明                                                                 |
|---------------|----------------------------------------------------------------------|
| アプリ |  パートナー センター アカウントに登録され、アプリ用のサブミッションを作成するすべてのアプリのデータを取得します。 これらのメソッドについて詳しくは、次の記事をご覧ください。 <ul><li>[アプリ データを取得します。](get-app-data.md)</li><li>[管理アプリを送信します。](manage-app-submissions.md)</li></ul> |
| アドオン | アプリのアドオンを取得、作成、または削除した後、そのアドオンの申請を取得、作成、または削除します。 これらのメソッドについて詳しくは、次の記事をご覧ください。 <ul><li>[アドオンを管理します。](manage-add-ons.md)</li><li>[アドオンの送信を管理します。](manage-add-on-submissions.md)</li></ul> |
| パッケージ フライト | アプリのパッケージ フライトを取得、作成、または削除した後、パッケージ フライトの申請を取得、作成、または削除します。 これらのメソッドについて詳しくは、次の記事をご覧ください。 <ul><li>[パッケージのフライトを管理します。](manage-flights.md)</li><li>[パッケージのフライトの送信を管理します。](manage-flight-submissions.md)</li></ul> |

<span id="code-samples"/>

## <a name="code-examples"></a>コード例

次の記事では、さまざまなプログラミング言語で Microsoft Store 申請 API を使用する方法を示す詳しいコード例を紹介します。

* [C#サンプル: アプリ、アドオン、および便の送信](csharp-code-examples-for-the-windows-store-submission-api.md)
* [C#サンプル: ゲーム オプションとトレーラーでアプリの提出](csharp-code-examples-for-submissions-game-options-and-trailers.md)
* [Java サンプル: アプリ、アドオン、および便の送信](java-code-examples-for-the-windows-store-submission-api.md)
* [Java サンプル: ゲーム オプションとトレーラーでアプリの提出](java-code-examples-for-submissions-game-options-and-trailers.md)
* [Python のサンプル: アプリ、アドオン、および便の送信](python-code-examples-for-the-windows-store-submission-api.md)
* [Python のサンプル: ゲーム オプションとトレーラーでアプリの提出](python-code-examples-for-submissions-game-options-and-trailers.md)

## <a name="storebroker-powershell-module"></a>StoreBroker PowerShell モジュール

Microsoft Store 申請 API を直接呼び出す代わりに、API の上にコマンド ライン インターフェイスを実装するオープンソースの PowerShell モジュールも用意されています。 このモジュールは、[StoreBroker](https://aka.ms/storebroker) と呼ばれています。 このモジュールを使うと、Microsoft Store 申請 API を直接呼び出さずに、コマンド ラインからアプリ、フライト、アドオンの申請を管理できます。また、ソースを参照して、この API を呼び出す方法の例を確認することもできます。 StoreBroker モジュールは、多くのファースト パーティ アプリケーションをストアに申請する主要な方法として Microsoft 内で積極的に使っています。

詳しくは、[GitHub の StoreBroker に関するページ](https://aka.ms/storebroker)をご覧ください。

## <a name="troubleshooting"></a>トラブルシューティング

| 問題      | 解決方法                                          |
|---------------|---------------------------------------------|
| PowerShell から Microsoft Store 申請 API を呼び出した後、[ConvertFrom-Json](https://technet.microsoft.com/library/hh849898.aspx) コマンドレットを使って API の応答データを JSON 形式から PowerShell オブジェクトに変換し、[ConvertTo-Json](https://technet.microsoft.com/library/hh849922.aspx) コマンドレットを使ってもう一度 JSON 形式に変換すると、応答データが破損します。 |  既定では、[ConvertTo-Json](https://technet.microsoft.com/library/hh849922.aspx) コマンドレットの *-Depth* パラメーターは、2 レベルのオブジェクトに設定されます。これは、Microsoft Store 申請 API から返される JSON オブジェクトの大半にとって浅すぎます。 [ConvertTo-Json](https://technet.microsoft.com/library/hh849922.aspx) コマンドレットを呼び出すときは、*-Depth* パラメーターを大きい値 (たとえば 20) に設定します。 |

## <a name="additional-help"></a>追加のヘルプ

Microsoft Store 申請 API について質問がある場合や、この API を使った申請の管理に関してサポートが必要な場合は、次のリソースを使ってください。

* Microsoft の[フォーラム](https://social.msdn.microsoft.com/Forums/windowsapps/home?forum=wpsubmit)で質問します。
* 参照してください、[サポート ページ](https://developer.microsoft.com/windows/support)とパートナー センターのサポート オプションのいずれかを要求します。 問題の種類とカテゴリを選択するよう求められた場合は、**[App submission and certification]** (アプリの申請と認定) と **[Submitting an app]** (アプリの申請) をそれぞれ選択します。  

## <a name="related-topics"></a>関連トピック

* [アプリ データを取得します。](get-app-data.md)
* [管理アプリを送信します。](manage-app-submissions.md)
* [アドオンを管理します。](manage-add-ons.md)
* [アドオンの送信を管理します。](manage-add-on-submissions.md)
* [パッケージのフライトを管理します。](manage-flights.md)
* [パッケージのフライトの送信を管理します。](manage-flight-submissions.md)
