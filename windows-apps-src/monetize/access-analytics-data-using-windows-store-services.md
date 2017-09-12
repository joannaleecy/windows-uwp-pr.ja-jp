---
author: mcleanbyron
ms.assetid: 4BF9EF21-E9F0-49DB-81E4-062D6E68C8B1
description: "Windows ストア分析 API を使って、自分または自分の組織の Windows デベロッパー センター アカウントに登録されたアプリの分析データをプログラムで取得することができます。"
title: "ストア サービスを使った分析データへのアクセス"
ms.author: mcleans
ms.date: 08/03/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, ストア サービス, Windows ストア分析 API"
ms.openlocfilehash: f739676d02ae5af4c3960fdde6461779c1533885
ms.sourcegitcommit: 2b436dc5e5681b8884e0531ee303f851a3e3ccf2
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/18/2017
---
# <a name="access-analytics-data-using-store-services"></a>ストア サービスを使った分析データへのアクセス

*Windows ストア分析 API* を使って、自分または自分の組織の Windows デベロッパー センター アカウントに登録されたアプリの分析データをプログラムで取得することができます。 この API では、アプリおよびアドオン (アプリ内製品または IAP とも呼ばれます) の入手数、エラー、アプリの評価とレビューに関するデータを取得できます。 この API は、Azure Active Directory (Azure AD) を使って、アプリまたはサービスからの呼び出しを認証します。

次の手順で、このプロセスについて詳しく説明しています。

1.  すべての[前提条件](#prerequisites)を完了したことを確認します。
2.  Windows ストア分析 API でメソッドを呼び出す前に、[Azure AD アクセス トークンを取得](#obtain-an-azure-ad-access-token)する必要があります。 トークンを取得した後、Windows ストア分析 API への呼び出しでこのトークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れた後は、新しいトークンを生成できます。
3.  [Windows ストア分析 API を呼び出します](#call-the-windows-store-analytics-api)。

<span id="prerequisites" />
## <a name="step-1-complete-prerequisites-for-using-the-windows-store-analytics-api"></a>手順 1: Windows ストア分析 API を使うための前提条件を完了する

Windows ストア分析 API を呼び出すコードの作成を開始する前に、次の前提条件が完了していることを確認します。

* ユーザー (またはユーザーの組織) は、Azure AD ディレクトリと、そのディレクトリに対する[全体管理者](http://go.microsoft.com/fwlink/?LinkId=746654)のアクセス許可を持っている必要があります。 Office 365 または Microsoft の他のビジネス サービスを既に使っている場合は、既に Azure AD ディレクトリをお持ちです。 それ以外の場合は、追加料金なしで[デベロッパー センター内から新しい Azure AD を作成](../publish/associate-azure-ad-with-dev-center.md#create-a-brand-new-azure-ad-to-associate-with-your-dev-center-account)できます。

* Azure AD アプリケーションをデベロッパー センター アカウントに関連付け、アプリケーションのテナント ID とクライアント ID を取得してキーを生成する必要があります。 Azure AD アプリケーションは、Windows ストア分析 API の呼び出し元のアプリまたはサービスを表します。 テナント ID、クライアント ID、およびキーは、API に渡す Azure AD アクセス トークンを取得するために必要です。
    > [!NOTE]
    > この作業を行うのは一度だけです。 テナント ID、クライアント ID、キーがあれば、新しい Azure AD アクセス トークンの作成が必要になったときに、いつでもそれらを再利用できます。

Azure AD アプリケーションをデベロッパー センター アカウントに関連付け、必要な値を取得するには:

1.  デベロッパー センターで、**[アカウント設定]** に移動して **[ユーザーの管理]** をクリックし、[組織のデベロッパー センター アカウントを組織の Azure AD ディレクトリに関連付けます](../publish/associate-azure-ad-with-dev-center.md)。

2.  **[ユーザーの管理]** ページで、**[Azure AD アプリケーションの追加]** をクリックして、デベロッパー センター アカウントの分析データへのアクセスに使うアプリやサービスを表す Azure AD アプリケーションを追加し、**マネージャー** ロールを割り当てます。 このアプリケーションが既に Azure AD ディレクトリに存在する場合、**[Azure AD アプリケーションの追加]** ページで選んでデベロッパー センター アカウントに追加できます。 それ以外の場合、**[Azure AD アプリケーションの追加]** ページで新しい Azure AD アプリケーションを作成できます。 詳しくは、[Azure AD アプリケーションをデベロッパー センター アカウントに追加する方法](../publish/add-users-groups-and-azure-ad-applications.md#azure-ad-applications)をご覧ください。

3.  **[ユーザーの管理]** ページに戻り、Azure AD アプリケーションの名前をクリックしてアプリケーション設定に移動し、**[テナント ID]** と **[クライアント ID]** の値を書き留めます。

4. **[新しいキーの追加]** をクリックします。 次の画面で、**[キー]** の値を書き留めます。 このページから離れると、この情報に再度アクセスすることはできません。 詳しくは、[Azure AD アプリケーションのキーを管理する方法](../publish/add-users-groups-and-azure-ad-applications.md#manage-keys)をご覧ください。

<span id="obtain-an-azure-ad-access-token" />
## <a name="step-2-obtain-an-azure-ad-access-token"></a>手順 2: Azure AD のアクセス トークンを取得する

Windows ストア分析 API で任意のメソッドを呼び出す前に、API 内の各メソッドの **Authorization** ヘッダーに渡す Azure AD アクセス トークンをまず取得する必要があります。 アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れた後は、トークンを更新してそれ以降の API 呼び出しで引き続き使用できます。

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
## <a name="step-3-call-the-windows-store-analytics-api"></a>手順 3: Windows ストア分析 API を呼び出す

Azure AD アクセス トークンを取得したら、Windows ストア分析 API を呼び出すことができます。 各メソッドの構文については、次の記事をご覧ください。 各メソッドの **Authorization** ヘッダーにアクセス トークンを渡す必要があります。

| シナリオ       | メソッド      |
|---------------|--------------------|
| 入手、コンバージョン、およびインストール |  <ul><li>[アプリの入手数の取得](get-app-acquisitions.md)</li><li>[アプリの入手に関するファネル データの取得](get-acquisition-funnel-data.md)</li><li>[チャネルごとのアプリのコンバージョンの取得](get-app-conversions-by-channel.md)</li><li>[アドオンの入手数の取得](get-in-app-acquisitions.md)</li><li>[チャネルごとのアドオンのコンバージョンの取得](get-add-on-conversions-by-channel.md)</li><li>[アプリのインストール数の取得](get-app-installs.md)</li></ul> |
| アプリのエラー | <ul><li>[エラー報告データの取得](get-error-reporting-data.md)</li><li>[アプリのエラーに関する詳細情報の取得](get-details-for-an-error-in-your-app.md)</li><li>[アプリのエラーに関するスタック トレースの取得](get-the-stack-trace-for-an-error-in-your-app.md)</li></ul> |
| 評価とレビュー | <ul><li>[アプリの評価の取得](get-app-ratings.md)</li><li>[アプリのレビューの取得](get-app-reviews.md)</li></ul> |
| アプリ内広告と広告キャンペーン | <ul><li>[広告のパフォーマンス データの取得](get-ad-performance-data.md)</li><li>[広告キャンペーンのパフォーマンス データの取得](get-ad-campaign-performance-data.md)</li></ul> |

次の追加のメソッドは、[Windows ハードウェア デベロッパー センター プログラム](https://msdn.microsoft.com/windows/hardware/drivers/dashboard/get-started-with-the-hardware-dashboard)に参加している開発者アカウントで利用できます。

| シナリオ       | メソッド      |
|---------------|--------------------|
| Windows 10 ドライバーのエラー (IHV 向け) |  <ul><li>[Windows 10 のドライバーに関するエラー報告データを取得する](get-error-reporting-data-for-windows-10-drivers.md)</li><li>[Windows 10 のドライバー エラーに関する詳細を取得する](get-details-for-a-windows-10-driver-error.md)</li><li>[Windows 10 のドライバー エラーに関する CAB ファイルをダウンロードする](download-the-cab-file-for-a-windows-10-driver-error.md)</li></ul> |
| Windows 7/Windows 8.x ドライバーのエラー (IHV 向け) |  <ul><li>[Windows 7 や Windows 8.x のドライバーに関するエラー報告データを取得する](get-error-reporting-data-for-windows-7-and-windows-8.x-drivers.md)</li><li>[Windows 7 や Windows 8.x のドライバー エラーに関する詳細を取得する](get-details-for-a-windows-7-or-windows-8.x-driver-error.md)</li><li>[Windows 7 や Windows 8.x のドライバー エラーに関する CAB ファイルをダウンロードする](download-the-cab-file-for-a-windows-7-or-windows-8.x-driver-error.md)</li></ul> |
| ハードウェア エラー (OEM 向け) |  <ul><li>[OEM ハードウェア エラー報告データを取得する](get-oem-hardware-error-reporting-data.md)</li><li>[OEM ハードウェア エラーの詳細を取得する](get-details-for-an-oem-hardware-error.md)</li><li>[OEM ハードウェア エラーの CAB ファイルをダウンロードする](download-the-cab-file-for-an-oem-hardware-error.md)</li></ul> |

## <a name="code-example"></a>コードの例

次のコード例は、Azure AD アクセス トークンを取得し、C# コンソール アプリから Windows ストア分析 API を呼び出す方法を示しています。 このコード例を使う場合は、変数 *tenantId*、*clientId*、*clientSecret*、および *appID* を自分のシナリオに合った適切な値に割り当ててください。 この例では、Windows ストア分析 API から返される JSON データを逆シリアル化するときに、Newtonsoft から提供されている [Json.NET パッケージ](http://www.newtonsoft.com/json) が必要になります。

> [!div class="tabbedCodeSnippets"]
[!code-cs[AnalyticsApi](./code/StoreServicesExamples_Analytics/cs/Program.cs#AnalyticsApiExample)]

## <a name="error-responses"></a>エラー応答

Windows ストア分析 API は、エラー コードとメッセージが含まれた JSON オブジェクトにエラー応答を返します。 次の例は、無効なパラメーターに対するエラー応答を示しています。

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
