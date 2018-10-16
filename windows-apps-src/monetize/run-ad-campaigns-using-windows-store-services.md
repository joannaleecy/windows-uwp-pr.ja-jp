---
author: Xansky
ms.assetid: 8e6c3d3d-0120-40f4-9f90-0b0518188a1a
description: Microsoft Store プロモーション API を使うと、自分または自分の組織の Windows デベロッパー センター アカウントに登録されているアプリのプロモーション用の広告キャンペーンをプログラムで管理できます。
title: ストア サービスを使用した広告キャンペーンの実行
ms.author: mhopkins
ms.date: 06/04/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, Microsoft Store プロモーション API, 広告キャンペーン
ms.localizationpriority: medium
ms.openlocfilehash: 6a1f08dbd70904284179c90fa00d2abd9acf4b97
ms.sourcegitcommit: 9354909f9351b9635bee9bb2dc62db60d2d70107
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/16/2018
ms.locfileid: "4690865"
---
# <a name="run-ad-campaigns-using-store-services"></a>ストア サービスを使用した広告キャンペーンの実行

*Microsoft Store プロモーション API* を使うと、自分または自分の組織の Windows デベロッパー センター アカウントに登録されているアプリのプロモーション用の広告キャンペーンをプログラムで管理できます。 この API を使用して、広告キャンペーンや、ターゲット設定、クリエイティブなど、その他の関連アセットを作成、更新、および監視できます。 この API は、大量のキャンペーンを作成する開発者や、Windows デベロッパー センター ダッシュボードを使用せずにキャンペーンを作成する必要がある開発者に特に便利です。 この API は、Azure Active Directory (Azure AD) を使って、アプリまたはサービスからの呼び出しを認証します。

次の手順で、このプロセスについて詳しく説明しています。

1.  すべての[前提条件](#prerequisites)を完了したことを確認します。
2.  Microsoft Store プロモーション API のメソッドを呼び出す前に、[Azure AD アクセス トークンを取得](#obtain-an-azure-ad-access-token)する必要があります。 トークンを取得した後、Microsoft Store プロモーション API の呼び出しでこのトークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れた後は、新しいトークンを生成できます。
3.  [Microsoft Store プロモーション API を呼び出します](#call-the-windows-store-promotions-api)。

または、Windows デベロッパー センター ダッシュボードを使って広告キャンペーンの作成と管理を行うこともできます。Microsoft Store プロモーション API を使ってプログラムで作成した広告キャンペーンはすべて、ダッシュボードからもアクセスできます。 ダッシュボードでの広告キャンペーンの管理について詳しくは、「[アプリ向けの広告キャンペーンの作成](../publish/create-an-ad-campaign-for-your-app.md)」をご覧ください。

> [!NOTE]
> Windows デベロッパー センター アカウントをお持ちの開発者の方はどなたでも、Microsoft Store プロモーション API を使用してアプリの広告キャンペーンを管理できます。 メディア エージェンシーもこの API へのアクセスを要求して、広告主の代わりに広告キャンペーンを実行できます。 お客様がメディア エージェンシーで、この API について詳しい情報を希望される場合、またはこの API へのアクセスを要求される場合は、storepromotionsapi@microsoft.com までリクエストをお送りください。

<span id="prerequisites" />

## <a name="step-1-complete-prerequisites-for-using-the-microsoft-store-promotions-api"></a>手順 1: Microsoft Store プロモーション API を使うための前提条件を満たす

Microsoft Store プロモーション API を呼び出すコードの作成を開始する前に、次の前提条件が満たされていることを確認します。

* この API を使用して広告キャンペーンを正しく作成し開始するには、事前に、[デベロッパー センター ダッシュボードの **[アプリの宣伝]** ページを使用して、有料の広告キャンペーンを 1 つ作成する](../publish/create-an-ad-campaign-for-your-app.md)必要があります。また、このページで支払い方法を少なくとも 1 つ追加する必要があります。 これを行うと、この API を使用して、広告キャンペーンの請求可能な配信ラインを正しく作成することができます。 この API を使用して作成した広告キャンペーンの配信ラインでは、ダッシュ ボードの **[アプリの宣伝]** ページで選んだ既定の支払い方法に対して自動的に請求が行われます。

* ユーザー (またはユーザーの組織) は、Azure AD ディレクトリと、そのディレクトリに対する[全体管理者](http://go.microsoft.com/fwlink/?LinkId=746654)のアクセス許可を持っている必要があります。 Office 365 または Microsoft の他のビジネス サービスを既に使っている場合は、既に Azure AD ディレクトリをお持ちです。 それ以外の場合は、追加料金なしで[デベロッパー センター内から新しい Azure AD を作成](../publish/associate-azure-ad-with-dev-center.md#create-a-brand-new-azure-ad-to-associate-with-your-dev-center-account)できます。

* Azure AD アプリケーションをデベロッパー センター アカウントに関連付け、アプリケーションのテナント ID とクライアント ID を取得してキーを生成する必要があります。 Azure AD アプリケーションは、Microsoft Store プロモーション API の呼び出し元のアプリまたはサービスを表します。 テナント ID、クライアント ID、およびキーは、API に渡す Azure AD アクセス トークンを取得するために必要です。
    > [!NOTE]
    > この作業を行うのは一度だけです。 テナント ID、クライアント ID、キーがあれば、新しい Azure AD アクセス トークンの作成が必要になったときに、いつでもそれらを再利用できます。

Azure AD アプリケーションをデベロッパー センター アカウントに関連付け、必要な値を取得するには:

1.  デベロッパー センターで、[組織のデベロッパー センター アカウントと組織の Azure AD ディレクトリを関連付けます](../publish/associate-azure-ad-with-dev-center.md)。

2.  次に、デベロッパー センターの **[アカウント設定]** セクションの **[ユーザー]** ページから、デベロッパー センター アカウントのプロモーション キャンペーンを管理するために使用するアプリやサービスを表す [Azure AD アプリケーションを追加](../publish/add-users-groups-and-azure-ad-applications.md#add-azure-ad-applications-to-your-dev-center-account)します。 このアプリケーションに必ず**マネージャー** ロールを割り当てます。 アプリケーションが Azure AD ディレクトリにまだ存在しない場合は、[デベロッパー センターで新しい Azure AD アプリケーションを作成](../publish/add-users-groups-and-azure-ad-applications.md#create-a-new-azure-ad-application-account-in-your-organizations-directory-and-add-it-to-your-dev-center-account)することができます。 

3.  **[ユーザー]** ページに戻り、Azure AD アプリケーションの名前をクリックしてアプリケーション設定に移動し、**[テナント ID]** と **[クライアント ID]** の値を書き留めます。

4. **[新しいキーの追加]** をクリックします。 次の画面で、**[キー]** の値を書き留めます。 このページから離れると、この情報に再度アクセスすることはできません。 詳しくは、「[Azure AD アプリケーションのキーを管理する方法](../publish/add-users-groups-and-azure-ad-applications.md#manage-keys)」をご覧ください。

<span id="obtain-an-azure-ad-access-token" />

## <a name="step-2-obtain-an-azure-ad-access-token"></a>手順 2: Azure AD のアクセス トークンを取得する

Microsoft Store プロモーション API のいずれかのメソッドを呼び出す前に、まず API の各メソッドの **Authorization** ヘッダーに渡す Azure AD アクセス トークンを取得する必要があります。 アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れた後は、トークンを更新してそれ以降の API 呼び出しで引き続き使用できます。

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

POST URI の *tenant\_id* の値と *client \_id* および *client \_secret* のパラメーターには、前のセクションでデベロッパー センターから取得したテナント ID、クライアント ID、キーを指定します。 *resource* パラメーターには、```https://manage.devcenter.microsoft.com``` を指定します。

アクセス トークンの有効期限が切れた後は、[この](https://azure.microsoft.com/documentation/articles/active-directory-protocols-oauth-code/#refreshing-the-access-tokens)手順に従って更新できます。

<span id="call-the-windows-store-promotions-api" />

## <a name="step-3-call-the-microsoft-store-promotions-api"></a>手順 3: Microsoft Store プロモーション API を呼び出す

Azure AD アクセス トークンを取得したら、Microsoft Store プロモーション API を呼び出すことができます。 各メソッドの **Authorization** ヘッダーにアクセス トークンを渡す必要があります。

Microsoft Store プロモーション API では、キャンペーンについての概要情報を保持する*キャンペーン* オブジェクトと、広告キャンペーンの*配信ライン*、*ターゲット プロファイル*、および*クリエイティブ*を表すその他のオブジェクトで構成されるものを広告キャンペーンとします。 この API には、これらのオブジェクトの種類ごとにグループ化されたメソッドのセットが含まれます。 キャンペーンを作成するには、通常、これらのオブジェクトごとに別の POST メソッドを呼び出します。 この API には、任意のオブジェクトの取得に使用できる GET メソッドと、キャンペーン、配信ライン、および対象プロファイル オブジェクトの編集に使用できる PUT メソッドも用意されています。

これらオブジェクトと関連するメソッドについての詳細は、以下の表を参照してください。


| オブジェクト       | 説明   |
|---------------|-----------------|
| キャンペーン |  このオブジェクトは広告キャンペーンを表し、広告キャンペーンのオブジェクト モデル階層の最上位に置かれます。 このオブジェクトは、実行するキャンペーンの種類 (有料、自社、またはコミュニティ)、キャンペーン目標、広告キャンペーンの配信ライン、その他の詳細情報を示します。 1 つのキャンペーンに関連づけることができるのは、1 つのアプリのみです。<br/><br/>このオブジェクトについて詳しくは、「[広告キャンペーンの管理](manage-ad-campaigns.md)」をご覧ください。<br/><br/>**注**&nbsp;&nbsp;広告キャンペーンの作成後は、[Microsoft Store 分析 API](access-analytics-data-using-windows-store-services.md) の[広告キャンペーンのパフォーマンス データの取得](get-ad-campaign-performance-data.md)メソッドを使って、キャンペーンのパフォーマンス データを取得できます。  |
| 配信ライン | キャンペーンごとに、インベントリの購入と広告の配信に使用する配信ラインが 1 つ以上あります。 配信ラインごとに、ターゲットと入札額を設定できます。また、予算と使用したいクリエイティブへのリンクを設定することで、支払い額を決定できます。<br/><br/>このオブジェクトについて詳しくは、「[広告キャンペーンの配信ラインの管理](manage-delivery-lines-for-ad-campaigns.md)」をご覧ください。 |
| 対象プロファイル | 配信ラインごとに、1 つの対象プロファイルを用意します。対象プロファイルでは、対象にするユーザー、地域、およびインベントリの種類を指定します。 対象プロファイルは、テンプレートとして作成し、複数の配信ライン間で共有できます。<br/><br/>このオブジェクトについて詳しくは、「[広告キャンペーンの対象プロファイルの管理](manage-targeting-profiles-for-ad-campaigns.md)」をご覧ください。 |
| クリエイティブ | 配信ラインごとに、キャンペーンの一環でお客様に表示される広告を表すクリエイティブが 1 つ以上あります。 クリエイティブは、常に同じアプリを表す場合は、同一の広告キャンペーンでなくても、1 つ以上の配信ラインに関連付けることができます。<br/><br/>このオブジェクトについて詳しくは、「[広告キャンペーンのクリエイティブの管理](manage-creatives-for-ad-campaigns.md)」をご覧ください。 |


次の図は、キャンペーン、配信ライン、対象プロファイル、クリエイティブ間の関係を表しています。

![広告キャンペーンの階層](images/ad-campaign-hierarchy.png)

## <a name="code-example"></a>コードの例

次のコード例は、Azure AD アクセス トークンを取得し、C# コンソール アプリから Microsoft Store プロモーション API を呼び出す方法を示しています。 このコード例を使う場合は、変数 *tenantId*、*clientId*、*clientSecret*、および *appID* を自分のシナリオに合った適切な値に割り当ててください。 この例では、Microsoft Store プロモーション API から返される JSON データを逆シリアル化するときに、Newtonsoft の [Json.NET パッケージ](http://www.newtonsoft.com/json)が必要になります。

[!code-cs[PromotionsApi](./code/StoreServicesExamples_Promotions/cs/Program.cs#PromotionsApiExample)]

## <a name="related-topics"></a>関連トピック

* [広告キャンペーンの管理](manage-ad-campaigns.md)
* [広告キャンペーンの配信ラインの管理](manage-delivery-lines-for-ad-campaigns.md)
* [広告キャンペーンの対象プロファイルの管理](manage-targeting-profiles-for-ad-campaigns.md)
* [広告キャンペーンのクリエイティブの管理](manage-creatives-for-ad-campaigns.md)
* [広告キャンペーンのパフォーマンス データの取得](get-ad-campaign-performance-data.md)


 
