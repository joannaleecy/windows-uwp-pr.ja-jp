---
author: mcleanbyron
ms.assetid: 8e6c3d3d-0120-40f4-9f90-0b0518188a1a
description: "Windows ストア プロモーション API を使って、自分または自分の組織の Windows デベロッパー センター アカウントに登録されたアプリのプロモーション用の広告キャンペーンをプログラムで管理することができます。"
title: "Windows ストア サービスを使用した広告キャンペーンの実行"
ms.author: mcleans
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, Windows ストア プロモーション API, 広告キャンペーン"
translationtype: Human Translation
ms.sourcegitcommit: 5645eee3dc2ef67b5263b08800b0f96eb8a0a7da
ms.openlocfilehash: ec245f07098a662c80517de49ba5637a69b30f35
ms.lasthandoff: 02/08/2017

---

# <a name="run-ad-campaigns-using-windows-store-services"></a>Windows ストア サービスを使用した広告キャンペーンの実行

*Windows ストア プロモーション API* を使って、自分または自分の組織の Windows デベロッパー センター アカウントに登録されたアプリのプロモーション用の広告キャンペーンをプログラムで管理することができます。 この API を使用して、広告キャンペーンや、ターゲット設定、クリエイティブなど、その他の関連アセットを作成、更新、および監視できます。 この API は、大量のキャンペーンを作成する開発者や、Windows デベロッパー センター ダッシュボードを使用せずにキャンペーンを作成する必要がある開発者に特に便利です。 この API は、Azure Active Directory (Azure AD) を使って、アプリまたはサービスからの呼び出しを認証します。

次の手順で、このプロセスについて詳しく説明しています。

1.  すべての[前提条件](#prerequisites)を完了したことを確認します。
2.  Windows ストア プロモーション API でメソッドを呼び出す前に、[Azure AD アクセス トークンを取得](#obtain-an-azure-ad-access-token)する必要があります。 トークンを取得した後、Windows ストア プロモーション API への呼び出しでこのトークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れた後は、新しいトークンを生成できます。
3.  [Windows ストア プロモーション API を呼び出します](#call-the-windows-store-promotions-api)。

または、Windows デベロッパー センター ダッシュボードを使用して広告キャンペーンを作成し、管理することもできます。Windows ストア プロモーション API を使用してプログラムにより作成したどの広告キャンペーンも、ダッシュボードからアクセスできます。 ダッシュボードでの広告キャンペーンの管理について詳しくは、「[アプリ向けの広告キャンペーンの作成](../publish/create-an-ad-campaign-for-your-app.md)」をご覧ください。

>**注**&nbsp;&nbsp;Windows デベロッパー センター アカウントをお持ちの開発者の方はどなたでも、Windows ストア プロモーション API を使用してアプリの広告キャンペーンを管理できます。 メディア エージェンシーもこの API へのアクセスを要求して、広告主の代わりに広告キャンペーンを実行できます。 メディア エージェンシーの方で、この API について詳しい情報を希望される場合、またはこの API へのアクセスを要求される場合は、storepromotionsapi@microsoft.com までリクエストをお送りください。

<span id="prerequisites" />
## <a name="step-1-complete-prerequisites-for-using-the-windows-store-promotions-api"></a>手順 1. Windows ストア プロモーション API を使うための前提条件を完了する

Windows ストア プロモーション API を呼び出すコードの作成を開始する前に、次の前提条件が完了していることを確認します。

* ユーザー (またはユーザーの組織) は、Azure AD ディレクトリと、そのディレクトリに対する[全体管理者](http://go.microsoft.com/fwlink/?LinkId=746654)のアクセス許可を持っている必要があります。 Office 365 または Microsoft の他のビジネス サービスを既に使っている場合は、既に Azure AD ディレクトリをお持ちです。 それ以外の場合は、追加料金なしで[デベロッパー センター内から新しい Azure AD を作成](https://msdn.microsoft.com/windows/uwp/publish/manage-account-users)できます。

* Azure AD アプリケーションをデベロッパー センター アカウントに関連付け、アプリケーションのテナント ID とクライアント ID を取得してキーを生成する必要があります。 Azure AD アプリケーションは、Windows ストア プロモーション API の呼び出し元のアプリまたはサービスを表します。 テナント ID、クライアント ID、およびキーは、API に渡す Azure AD アクセス トークンを取得するために必要です。

  >**注:**&nbsp;&nbsp;この作業を行うのは一度だけです。 テナント ID、クライアント ID、キーがあれば、新しい Azure AD アクセス トークンの作成が必要になったときに、いつでもそれらを再利用できます。

Azure AD アプリケーションをデベロッパー センター アカウントに関連付け、必要な値を取得するには:

1.  デベロッパー センターで、**[アカウント設定]** に移動して **[ユーザーの管理]** をクリックし、組織のデベロッパー センター アカウントを組織の Azure AD ディレクトリに関連付けます。 詳しい手順については、「[アカウント ユーザーの管理](https://msdn.microsoft.com/windows/uwp/publish/manage-account-users)」をご覧ください。

2.  **[ユーザーの管理]** ページで、**[Azure AD アプリケーションの追加]** をクリックして、デベロッパー センター アカウントのプロモーション キャンペーンの管理に使うアプリやサービスを表す Azure AD アプリケーションを追加し、**マネージャー** ロールを割り当てます。 このアプリケーションが既に Azure AD ディレクトリに存在する場合、**[Azure AD アプリケーションの追加]** ページで選んでデベロッパー センター アカウントに追加できます。 それ以外の場合、**[Azure AD アプリケーションの追加]** ページで新しい Azure AD アプリケーションを作成できます。 詳しくは、「[Azure AD アプリケーションを追加して管理する](https://msdn.microsoft.com/windows/uwp/publish/manage-account-users#add-and-manage-azure-ad-applications)」をご覧ください。

3.  **[ユーザーの管理]** ページに戻り、Azure AD アプリケーションの名前をクリックしてアプリケーション設定に移動し、**[テナント ID]** と **[クライアント ID]** の値を書き留めます。

4. **[新しいキーの追加]** をクリックします。 次の画面で、**[キー]** の値を書き留めます。 このページから離れると、この情報に再度アクセスすることはできません。 詳しくは、「[Azure AD アプリケーションを追加して管理する](https://msdn.microsoft.com/windows/uwp/publish/manage-account-users#add-and-manage-azure-ad-applications)」でキーの管理に関する情報をご覧ください。

<span id="obtain-an-azure-ad-access-token" />
## <a name="step-2-obtain-an-azure-ad-access-token"></a>手順 2: Azure AD のアクセス トークンを取得する

Windows ストア プロモーション API で任意のメソッドを呼び出す前に、API 内の各メソッドの **Authorization** ヘッダーに渡す Azure AD アクセス トークンをまず取得する必要があります アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れた後は、トークンを更新してそれ以降の API 呼び出しで引き続き使用できます。

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
## <a name="step-3-call-the-windows-store-promotions-api"></a>手順 3: Windows ストア プロモーション API を呼び出す

Azure AD アクセス トークンを取得したら、Windows ストア プロモーション API を呼び出すことができます。 各メソッドの **Authorization** ヘッダーにアクセス トークンを渡す必要があります。

Windows ストア プロモーション API では、キャンペーンについての概要情報を保持する*キャンペーン* オブジェクトと、広告キャンペーンの*配信ライン*、*対象プロファイル*、および*クリエイティブ*を表すその他のオブジェクトで構成されるものを広告キャンペーンとします。 この API には、これらのオブジェクトの種類ごとにグループ化されたメソッドのセットが含まれます。 キャンペーンを作成するには、通常、これらのオブジェクトごとに別の POST メソッドを呼び出します。 この API には、任意のオブジェクトの取得に使用できる GET メソッドと、キャンペーン、配信ライン、および対象プロファイル オブジェクトの編集に使用できる PUT メソッドも用意されています。

これらオブジェクトと関連するメソッドについての詳細は、以下の表を参照してください。


| オブジェクト       | 説明   |
|---------------|-----------------|
| キャンペーン |  このオブジェクトは広告キャンペーンを表し、広告キャンペーンのオブジェクト モデル階層の最上位に置かれます。 このオブジェクトは、実行するキャンペーンの種類 (有料、自社、またはコミュニティ)、キャンペーン目標、広告キャンペーンの配信ライン、その他の詳細情報を示します。 1 つのキャンペーンに関連づけることができるのは、1 つのアプリのみです。<br/><br/>このオブジェクトについて詳しくは、「[広告キャンペーンの管理](manage-ad-campaigns.md)」をご覧ください。<br/><br/>**注**&nbsp;&nbsp;広告キャンペーンを作成すると、[Windows ストア分析 API](access-analytics-data-using-windows-store-services.md)の[広告キャンペーンのパフォーマンス データの取得](get-ad-campaign-performance-data.md) メソッドを使用して、キャンペーンのパフォーマンス データを取得できます。  |
| 配信ライン | キャンペーンごとに、インベントリの購入と広告の配信に使用する配信ラインが 1 つ以上あります。 配信ラインごとに、ターゲットと入札額を設定できます。また、予算と使用したいクリエイティブへのリンクを設定することで、支払い額を決定できます。<br/><br/>このオブジェクトについて詳しくは、「[広告キャンペーンの配信ラインの管理](manage-delivery-lines-for-ad-campaigns.md)」をご覧ください。 |
| 対象プロファイル | 配信ラインごとに、1 つの対象プロファイルを用意します。対象プロファイルでは、対象にするユーザー、地域、およびインベントリの種類を指定します。 対象プロファイルは、テンプレートとして作成し、複数の配信ライン間で共有できます。<br/><br/>このオブジェクトについて詳しくは、「[広告キャンペーンの対象プロファイルの管理](manage-targeting-profiles-for-ad-campaigns.md)」をご覧ください。 |
| クリエイティブ | 配信ラインごとに、キャンペーンの一環でお客様に表示される広告を表すクリエイティブが 1 つ以上あります。 クリエイティブは、常に同じアプリを表す場合は、同一の広告キャンペーンでなくても、1 つ以上の配信ラインに関連付けることができます。<br/><br/>このオブジェクトについて詳しくは、「[広告キャンペーンのクリエイティブの管理](manage-creatives-for-ad-campaigns.md)」をご覧ください。 |


次の図は、キャンペーン、配信ライン、対象プロファイル、クリエイティブ間の関係を表しています。

![広告キャンペーンの階層](images/ad-campaign-hierarchy.png)

## <a name="code-example"></a>コードの例

次のコード例は、Azure AD アクセス トークンを取得し、C# コンソール アプリから Windows ストア プロモーション API を呼び出す方法を示しています。 このコード例を使う場合は、変数 *tenantId*、*clientId*、*clientSecret*、および *appID* を自分のシナリオに合った適切な値に割り当ててください。 この例では、Windows ストア プロモーション API から返される JSON データを逆シリアル化するときに、Newtonsoft から提供されている [Json.NET パッケージ](http://www.newtonsoft.com/json)が必要になります。

> [!div class="tabbedCodeSnippets"]
[!code-cs[PromotionsApi](./code/StoreServicesExamples_Promotions/cs/Program.cs#PromotionsApiExample)]

## <a name="related-topics"></a>関連トピック

* [広告キャンペーンの管理](manage-ad-campaigns.md)
* [広告キャンペーンの配信ラインの管理](manage-delivery-lines-for-ad-campaigns.md)
* [広告キャンペーンの対象プロファイルの管理](manage-targeting-profiles-for-ad-campaigns.md)
* [広告キャンペーンのクリエイティブの管理](manage-creatives-for-ad-campaigns.md)
* [広告キャンペーンのパフォーマンス データの取得](get-ad-campaign-performance-data.md)


 

