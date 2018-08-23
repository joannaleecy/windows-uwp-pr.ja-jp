---
author: mcleanbyron
ms.assetid: 4BF9EF21-E9F0-49DB-81E4-062D6E68C8B1
description: Microsoft Store 分析 API を使うと、自分または自分の組織の Windows デベロッパー センター アカウントに登録されているアプリの分析データをプログラムで取得できます。
title: ストア サービスを使った分析データへのアクセス
ms.author: mcleans
ms.date: 06/04/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, Store サービス, Microsoft Store 分析 API
ms.localizationpriority: medium
ms.openlocfilehash: f36facd8ba89fbaccb7c61ad937c2ce005922aa8
ms.sourcegitcommit: 9c79fdab9039ff592edf7984732d300a14e81d92
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/23/2018
ms.locfileid: "2810690"
---
# <a name="access-analytics-data-using-store-services"></a>ストア サービスを使った分析データへのアクセス

*Microsoft Store 分析 API* を使うと、自分または自分の組織の Windows デベロッパー センター アカウントに登録されているアプリの分析データをプログラムで取得できます。 この API では、アプリおよびアドオン (アプリ内製品または IAP とも呼ばれます) の入手数、エラー、アプリの評価とレビューに関するデータを取得できます。 この API は、Azure Active Directory (Azure AD) を使って、アプリまたはサービスからの呼び出しを認証します。

次の手順で、このプロセスについて詳しく説明しています。

1.  すべての[前提条件](#prerequisites)を完了したことを確認します。
2.  Microsoft Store 分析 API のメソッドを呼び出す前に、[Azure AD アクセス トークンを取得](#obtain-an-azure-ad-access-token)する必要があります。 トークンを取得した後、Microsoft Store 分析 API の呼び出しでこのトークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れた後は、新しいトークンを生成できます。
3.  [Microsoft Store 分析 API を呼び出します](#call-the-windows-store-analytics-api)。

<span id="prerequisites" />

## <a name="step-1-complete-prerequisites-for-using-the-microsoft-store-analytics-api"></a>手順 1: Microsoft Store 分析 API を使うための前提条件を満たす

Microsoft Store 分析 API を呼び出すコードの作成を開始する前に、次の前提条件が満たされていることを確認します。

* ユーザー (またはユーザーの組織) は、Azure AD ディレクトリと、そのディレクトリに対する[全体管理者](http://go.microsoft.com/fwlink/?LinkId=746654)のアクセス許可を持っている必要があります。 Office 365 または Microsoft の他のビジネス サービスを既に使っている場合は、既に Azure AD ディレクトリをお持ちです。 それ以外の場合は、追加料金なしで[デベロッパー センター内から新しい Azure AD を作成](../publish/associate-azure-ad-with-dev-center.md#create-a-brand-new-azure-ad-to-associate-with-your-dev-center-account)できます。

* Azure AD アプリケーションをデベロッパー センター アカウントに関連付け、アプリケーションのテナント ID とクライアント ID を取得してキーを生成する必要があります。 Azure AD アプリケーションは、Microsoft Store 分析 API の呼び出し元のアプリまたはサービスを表します。 テナント ID、クライアント ID、およびキーは、API に渡す Azure AD アクセス トークンを取得するために必要です。
    > [!NOTE]
    > この作業を行うのは一度だけです。 テナント ID、クライアント ID、キーがあれば、新しい Azure AD アクセス トークンの作成が必要になったときに、いつでもそれらを再利用できます。

Azure AD アプリケーションをデベロッパー センター アカウントに関連付け、必要な値を取得するには:

1.  デベロッパー センターで、[組織のデベロッパー センター アカウントと組織の Azure AD ディレクトリを関連付けます](../publish/associate-azure-ad-with-dev-center.md)。

2.  次に、デベロッパー センターの **[アカウント設定]** セクションの **[ユーザー]** ページで、デベロッパー センター アカウントの分析データへのアクセスに使うアプリやサービスを表す [Azure AD アプリケーションを追加](../publish/add-users-groups-and-azure-ad-applications.md#add-azure-ad-applications-to-your-dev-center-account)します。 このアプリケーションに必ず**マネージャー** ロールを割り当てます。 アプリケーションが Azure AD ディレクトリにまだ存在しない場合は、[デベロッパー センターで新しい Azure AD アプリケーションを作成](../publish/add-users-groups-and-azure-ad-applications.md#create-a-new-azure-ad-application-account-in-your-organizations-directory-and-add-it-to-your-dev-center-account)することができます。

3.  **[ユーザー]** ページに戻り、Azure AD アプリケーションの名前をクリックしてアプリケーション設定に移動し、**[テナント ID]** と **[クライアント ID]** の値を書き留めます。

4. **[新しいキーの追加]** をクリックします。 次の画面で、**[キー]** の値を書き留めます。 このページから離れると、この情報に再度アクセスすることはできません。 詳しくは、「[Azure AD アプリケーションのキーを管理する方法](../publish/add-users-groups-and-azure-ad-applications.md#manage-keys)」をご覧ください。

<span id="obtain-an-azure-ad-access-token" />

## <a name="step-2-obtain-an-azure-ad-access-token"></a>手順 2: Azure AD のアクセス トークンを取得する

Microsoft Store 分析 API のいずれかのメソッドを呼び出す前に、まず API の各メソッドの **Authorization** ヘッダーに渡す Azure AD アクセス トークンを取得する必要があります。 アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れた後は、トークンを更新してそれ以降の API 呼び出しで引き続き使用できます。

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

<span id="call-the-windows-store-analytics-api" />

## <a name="step-3-call-the-microsoft-store-analytics-api"></a>手順 3: Microsoft Store 分析 API を呼び出す

Azure AD アクセス トークンを取得したら、Microsoft Store 分析 API を呼び出すことができます。 各メソッドの **Authorization** ヘッダーにアクセス トークンを渡す必要があります。

### <a name="methods-for-uwp-apps"></a>UWP アプリ向けのメソッド

次の分析メソッドは、デベロッパー センターの UWP アプリで利用できます。

| シナリオ       | メソッド      |
|---------------|--------------------|
| 入手、コンバージョン、およびインストール |  <ul><li>[アプリの入手数の取得](get-app-acquisitions.md)</li><li>[アプリの入手に関するファネル データの取得](get-acquisition-funnel-data.md)</li><li>[チャネルごとのアプリのコンバージョンの取得](get-app-conversions-by-channel.md)</li><li>[アドオンの入手数の取得](get-in-app-acquisitions.md)</li><li>[サブスクリプション アドオンの入手数の取得](get-subscription-acquisitions.md)</li><li>[チャネルごとのアドオンのコンバージョンの取得](get-add-on-conversions-by-channel.md)</li><li>[アプリのインストール数の取得](get-app-installs.md)</li></ul> |
| アプリのエラー | <ul><li>[エラー報告データの取得](get-error-reporting-data.md)</li><li>[アプリのエラーに関する詳細情報の取得](get-details-for-an-error-in-your-app.md)</li><li>[アプリのエラーに関するスタック トレースの取得](get-the-stack-trace-for-an-error-in-your-app.md)</li><li>[アプリのエラーの CAB ファイルをダウンロードする](download-the-cab-file-for-an-error-in-your-app.md)</li></ul> |
| 分析結果 | <ul><li>[アプリのデータの分析結果を取得します。](get-insights-data-for-your-app.md)</li></ul>  |
| 評価とレビュー | <ul><li>[アプリの評価の取得](get-app-ratings.md)</li><li>[アプリのレビューの取得](get-app-reviews.md)</li></ul> |
| アプリ内広告と広告キャンペーン | <ul><li>[広告のパフォーマンス データの取得](get-ad-performance-data.md)</li><li>[広告キャンペーンのパフォーマンス データの取得](get-ad-campaign-performance-data.md)</li></ul> |

### <a name="methods-for-desktop-applications"></a>デスクトップ アプリケーション向けのメソッド

次の分析メソッドは、[Windows デスクトップ アプリケーション プログラム](https://msdn.microsoft.com/library/windows/desktop/mt826504)に参加している開発者アカウントで利用できます。

| シナリオ       | メソッド      |
|---------------|--------------------|
| インストール |  <ul><li>[デスクトップ アプリケーションのインストール数の取得](get-desktop-app-installs.md)</li></ul> |
| ブロック |  <ul><li>[デスクトップ アプリケーションのアップグレード ブロックの取得](get-desktop-block-data.md)</li><li>[デスクトップ アプリケーションのアップグレード ブロックの詳細情報の取得](get-desktop-block-data-details.md)</li></ul> |
| アプリケーション エラー |  <ul><li>[デスクトップ アプリケーションのエラー報告データの取得](get-desktop-application-error-reporting-data.md)</li><li>[デスクトップ アプリケーションのエラーに関する詳細情報の取得](get-details-for-an-error-in-your-desktop-application.md)</li><li>[デスクトップ アプリケーションのエラーに関するスタック トレースの取得](get-the-stack-trace-for-an-error-in-your-desktop-application.md)</li><li>[デスクトップ アプリケーションのエラーの CAB ファイルをダウンロードする](download-the-cab-file-for-an-error-in-your-desktop-application.md)</li></ul> |
| 分析結果 | <ul><li>[デスクトップ アプリケーションのデータの分析結果を取得します。](get-insights-data-for-your-desktop-app.md)</li></ul>  |

### <a name="methods-for-xbox-live-services"></a>Xbox Live サービス向けのメソッド

次の追加のメソッドは、[Xbox Live サービス](../xbox-live/developer-program-overview.md)を使うゲームの開発者アカウントで利用できます。

| シナリオ       | メソッド      |
|---------------|--------------------|
| 一般的な分析 |  <ul><li>[Xbox Live の分析データの取得](get-xbox-live-analytics.md)</li><li>[Xbox Live の実績データの取得](get-xbox-live-achievements-data.md)</li><li>[Xbox Live の同時使用状況データの取得](get-xbox-live-concurrent-usage-data.md)</li></ul> |
| 正常性分析 |  <ul><li>[Xbox Live の正常性データの取得](get-xbox-live-health-data.md)</li></ul> |
| コミュニティ分析 |  <ul><li>[Xbox Live ゲーム ハブのデータの取得](get-xbox-live-game-hub-data.md)</li><li>[Xbox Live クラブのデータの取得](get-xbox-live-club-data.md)</li><li>[Xbox Live のマルチプレイヤー データの取得](get-xbox-live-multiplayer-data.md)</li></ul>  |

### <a name="methods-for-xbox-one-games"></a>Xbox One ゲーム向けのメソッド

次の追加のメソッドは、Xbox デベロッパー ポータル (XDP) を通じて取り込まれ、デベロッパー センター ダッシュボードの [XDP 分析] で利用できる Xbox One ゲームの開発者アカウントで使うことができます。

| シナリオ       | メソッド      |
|---------------|--------------------|
| 入手 |  <ul><li>[Xbox One ゲームの入手数の取得](get-xbox-one-game-acquisitions.md)</li></ul> |

### <a name="methods-for-hardware-and-drivers"></a>ハードウェアとドライバー向けのメソッド

[Windows ハードウェア デベロッパー センター プログラム](https://msdn.microsoft.com/windows/hardware/drivers/dashboard/get-started-with-the-hardware-dashboard)に属している開発アカウントでは、追加のハードウェアおよびドライバーの分析などのデータを取得する方法のセットにアクセスします。 詳細については、[ダッシュ ボードのハードウェア API](https://docs.microsoft.com/windows-hardware/drivers/dashboard/dashboard-api)を参照してください。

## <a name="code-example"></a>コードの例

次のコード例は、Azure AD アクセス トークンを取得し、C# コンソール アプリから Microsoft Store 分析 API を呼び出す方法を示しています。 このコード例を使う場合は、変数 *tenantId*、*clientId*、*clientSecret*、および *appID* を自分のシナリオに合った適切な値に割り当ててください。 この例では、Microsoft Store 分析 API から返される JSON データを逆シリアル化するときに、Newtonsoft の [Json.NET パッケージ](http://www.newtonsoft.com/json)が必要になります。

> [!div class="tabbedCodeSnippets"]
[!code-cs[AnalyticsApi](./code/StoreServicesExamples_Analytics/cs/Program.cs#AnalyticsApiExample)]

## <a name="error-responses"></a>エラー応答

Microsoft Store 分析 API は、エラー コードとメッセージが含まれた JSON オブジェクトにエラー応答を返します。 次の例は、無効なパラメーターに対するエラー応答を示しています。

```json
{
    "code":"BadRequest",
    "data":[],
    "details":[],
    "innererror":{
        "code":"InvalidQueryParameters",
        "data":[
            "top parameter cannot be more than 10000"
        ],
        "details":[],
        "message":"One or More Query Parameters has invalid values.",
        "source":"AnalyticsAPI"
    },
    "message":"The calling client sent a bad request to the service.",
    "source":"AnalyticsAPI"
}
```
