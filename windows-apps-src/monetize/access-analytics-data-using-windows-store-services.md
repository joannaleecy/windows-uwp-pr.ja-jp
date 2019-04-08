---
ms.assetid: 4BF9EF21-E9F0-49DB-81E4-062D6E68C8B1
description: Microsoft Store analytics API を使用してプログラムで、または組織に登録されているアプリの分析データを取得する ' s パートナー センターの Windows アカウント。
title: ストア サービスを使った分析データへのアクセス
ms.date: 06/04/2018
ms.topic: article
keywords: Windows 10, UWP, Store サービス, Microsoft Store 分析 API
ms.localizationpriority: medium
ms.custom: RS5
ms.openlocfilehash: 72e0941bb42a2a507af652758432ce51212c1042
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57592657"
---
# <a name="access-analytics-data-using-store-services"></a>ストア サービスを使った分析データへのアクセス

使用して、 *Microsoft Store analytics API*をプログラムによって、または組織のパートナー センターの Windows アカウントに登録されているアプリの分析データを取得します。 この API では、アプリおよびアドオン (アプリ内製品または IAP とも呼ばれます) の入手数、エラー、アプリの評価とレビューに関するデータを取得できます。 この API は、Azure Active Directory (Azure AD) を使って、アプリまたはサービスからの呼び出しを認証します。

次の手順で、このプロセスについて詳しく説明しています。

1.  すべての[前提条件](#prerequisites)を完了したことを確認します。
2.  Microsoft Store 分析 API のメソッドを呼び出す前に、[Azure AD アクセス トークンを取得](#obtain-an-azure-ad-access-token)する必要があります。 トークンを取得した後、Microsoft Store 分析 API の呼び出しでこのトークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れた後は、新しいトークンを生成できます。
3.  [Microsoft Store 分析 API を呼び出します](#call-the-windows-store-analytics-api)。

<span id="prerequisites" />

## <a name="step-1-complete-prerequisites-for-using-the-microsoft-store-analytics-api"></a>手順 1:Microsoft Store analytics API を使用するための前提条件

Microsoft Store 分析 API を呼び出すコードの作成を開始する前に、次の前提条件が満たされていることを確認します。

* ユーザー (またはユーザーの組織) は、Azure AD ディレクトリと、そのディレクトリに対する[全体管理者](https://go.microsoft.com/fwlink/?LinkId=746654)のアクセス許可を持っている必要があります。 Office 365 または Microsoft の他のビジネス サービスを既に使っている場合は、既に Azure AD ディレクトリをお持ちです。 それ以外の場合は、追加料金なしに[パートナー センターで新しい Azure AD を作成](../publish/associate-azure-ad-with-partner-center.md#create-a-brand-new-azure-ad-to-associate-with-your-partner-center-account)できます。

* Azure AD アプリケーションをパートナー センター アカウントに関連付ける、テナント ID と、アプリケーションのクライアント ID を取得、およびキーを生成する必要があります。 Azure AD アプリケーションは、Microsoft Store 分析 API の呼び出し元のアプリまたはサービスを表します。 テナント ID、クライアント ID、およびキーは、API に渡す Azure AD アクセス トークンを取得するために必要です。
    > [!NOTE]
    > この作業を行うのは一度だけです。 テナント ID、クライアント ID、キーがあれば、新しい Azure AD アクセス トークンの作成が必要になったときに、いつでもそれらを再利用できます。

Azure AD アプリケーションをパートナー センター アカウントに関連付けるし、必要な値を取得します。

1.  パートナー センターの[、組織の Azure AD ディレクトリと、組織のパートナー センター アカウントを関連付ける](../publish/associate-azure-ad-with-partner-center.md)します。

2.  [次へ]、**ユーザー**ページで、**アカウント設定**パートナー センターの「[して Azure AD アプリケーションを追加](../publish/add-users-groups-and-azure-ad-applications.md#add-azure-ad-applications-to-your-partner-center-account)アプリを使用してサービスを表す分析データをパートナー センター アカウントにアクセスします。 このアプリケーションに必ず**マネージャー** ロールを割り当てます。 アプリケーションが存在しない場合、Azure AD ディレクトリで実行できます[を新規作成パートナー センターで Azure AD アプリケーション](../publish/add-users-groups-and-azure-ad-applications.md#create-a-new-azure-ad-application-account-in-your-organizations-directory-and-add-it-to-your-partner-center-account)します。

3.  **[ユーザー]** ページに戻り、Azure AD アプリケーションの名前をクリックしてアプリケーション設定に移動し、**[テナント ID]** と **[クライアント ID]** の値を書き留めます。

4. **[新しいキーの追加]** をクリックします。 次の画面で、**[キー]** の値を書き留めます。 このページから離れると、この情報に再度アクセスすることはできません。 詳しくは、「[Azure AD アプリケーションのキーを管理する方法](../publish/add-users-groups-and-azure-ad-applications.md#manage-keys)」をご覧ください。

<span id="obtain-an-azure-ad-access-token" />

## <a name="step-2-obtain-an-azure-ad-access-token"></a>手順 2:Azure AD アクセス トークンの取得

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

*テナント\_id* POST URI の値と*クライアント\_id*と*クライアント\_シークレット*パラメーター、テナントの指定ID、クライアント ID、前のセクションで、パートナー センターから取得したアプリケーションのキー。 *resource* パラメーターには、```https://manage.devcenter.microsoft.com``` を指定します。

アクセス トークンの有効期限が切れた後は、[この](https://azure.microsoft.com/documentation/articles/active-directory-protocols-oauth-code/#refreshing-the-access-tokens)手順に従って更新できます。

<span id="call-the-windows-store-analytics-api" />

## <a name="step-3-call-the-microsoft-store-analytics-api"></a>手順 3:Microsoft Store analytics API を呼び出す

Azure AD アクセス トークンを取得したら、Microsoft Store 分析 API を呼び出すことができます。 各メソッドの **Authorization** ヘッダーにアクセス トークンを渡す必要があります。

### <a name="methods-for-uwp-apps"></a>UWP アプリ向けのメソッド

次の analytics メソッドは、パートナー センターでの UWP アプリで利用できます。

| シナリオ       | メソッド      |
|---------------|--------------------|
| 取得、変換、インストール、および使用状況 |  <ul><li>[アプリの取得数を取得します。](get-app-acquisitions.md)</li><li>[アプリの取得のじょうごグラフのデータを取得します。](get-acquisition-funnel-data.md)</li><li>[チャネルによってアプリの変換を取得します。](get-app-conversions-by-channel.md)</li><li>[アドオンの取得数を取得します。](get-in-app-acquisitions.md)</li><li>[サブスクリプションを取得するには、アドオンの取得します。](get-subscription-acquisitions.md)</li><li>[チャネルによってアドオンの変換を取得します。](get-add-on-conversions-by-channel.md)</li><li>[アプリのインストールを取得します。](get-app-installs.md)</li><li>[毎日のアプリ使用状況を取得します。](get-app-usage-daily.md)</li><li>[アプリの使用状況の月単位の取得します。](get-app-usage-monthly.md)</li></ul> |
| アプリのエラー | <ul><li>[エラー報告データを取得します。](get-error-reporting-data.md)</li><li>[アプリでエラーの詳細を取得します。](get-details-for-an-error-in-your-app.md)</li><li>[アプリでエラーのスタック トレースを取得します。](get-the-stack-trace-for-an-error-in-your-app.md)</li><li>[アプリでエラー用の CAB ファイルをダウンロードします。](download-the-cab-file-for-an-error-in-your-app.md)</li></ul> |
| Insights | <ul><li>[アプリの insights のデータを取得します。](get-insights-data-for-your-app.md)</li></ul>  |
| 評価とレビュー | <ul><li>[アプリのレーティングを取得します。](get-app-ratings.md)</li><li>[アプリのレビューを取得します。](get-app-reviews.md)</li></ul> |
| アプリ内広告と広告キャンペーン | <ul><li>[Ad のパフォーマンス データを取得します。](get-ad-performance-data.md)</li><li>[広告キャンペーンのパフォーマンス データを取得します。](get-ad-campaign-performance-data.md)</li></ul> |

### <a name="methods-for-desktop-applications"></a>デスクトップ アプリケーション向けのメソッド

次の分析メソッドは、[Windows デスクトップ アプリケーション プログラム](https://msdn.microsoft.com/library/windows/desktop/mt826504)に参加している開発者アカウントで利用できます。

| シナリオ       | メソッド      |
|---------------|--------------------|
| インストール |  <ul><li>[デスクトップ アプリケーションのインストールを取得します。](get-desktop-app-installs.md)</li></ul> |
| ブロック |  <ul><li>[お客様のデスクトップ アプリケーションのアップグレードのブロックを取得します。](get-desktop-block-data.md)</li><li>[お客様のデスクトップ アプリケーションのアップグレードはブロックの詳細を取得します。](get-desktop-block-data-details.md)</li></ul> |
| アプリケーション エラー |  <ul><li>[エラー報告、デスクトップ アプリケーションのデータを取得します。](get-desktop-application-error-reporting-data.md)</li><li>[お客様のデスクトップ アプリケーションでエラーの詳細を取得します。](get-details-for-an-error-in-your-desktop-application.md)</li><li>[お客様のデスクトップ アプリケーションでエラーのスタック トレースを取得します。](get-the-stack-trace-for-an-error-in-your-desktop-application.md)</li><li>[お客様のデスクトップ アプリケーションでエラー用の CAB ファイルをダウンロードします。](download-the-cab-file-for-an-error-in-your-desktop-application.md)</li></ul> |
| Insights | <ul><li>[お客様のデスクトップ アプリケーションの insights データを取得します。](get-insights-data-for-your-desktop-app.md)</li></ul>  |

### <a name="methods-for-xbox-live-services"></a>Xbox Live サービス向けのメソッド

次の追加のメソッドは、[Xbox Live サービス](../xbox-live/developer-program-overview.md)を使うゲームの開発者アカウントで利用できます。

| シナリオ       | メソッド      |
|---------------|--------------------|
| 一般的な分析 |  <ul><li>[Xbox Live analytics データを取得します。](get-xbox-live-analytics.md)</li><li>[Xbox Live 成績データを取得します。](get-xbox-live-achievements-data.md)</li><li>[Xbox Live の同時使用状況データを取得します。](get-xbox-live-concurrent-usage-data.md)</li></ul> |
| 正常性分析 |  <ul><li>[Xbox Live の正常性データを取得します。](get-xbox-live-health-data.md)</li></ul> |
| コミュニティ分析 |  <ul><li>[Xbox Live Game ハブのデータを取得します。](get-xbox-live-game-hub-data.md)</li><li>[Xbox Live クラブ活動用のデータを取得します。](get-xbox-live-club-data.md)</li><li>[Xbox Live のマルチ プレーヤー データを取得します。](get-xbox-live-multiplayer-data.md)</li></ul>  |

### <a name="methods-for-xbox-one-games"></a>Xbox One ゲーム向けのメソッド

次の追加のメソッドには、Xbox 開発者ポータル (XDP) を通じてが取り込まれた Xbox One のゲーム開発者アカウントで使用可能と XDP Analytics ダッシュ ボードに表示です。

| シナリオ       | メソッド      |
|---------------|--------------------|
| 取得 |  <ul><li>[Xbox One ゲーム企業買収を取得します。](get-xbox-one-game-acquisitions.md)</li><li>[Xbox One のアドオン買収を取得します。](get-xbox-one-add-on-acquisitions.md)</li></ul> |
| エラー |  <ul><li>[レポート データを Xbox One のエラーが発生するゲーム](get-error-reporting-data-for-your-xbox-one-game.md)</li><li>[ゲーム、Xbox One でエラーの詳細を取得します。](get-details-for-an-error-in-your-xbox-one-game.md)</li><li>[ゲーム、Xbox One でエラーのスタック トレースを取得します。](get-the-stack-trace-for-an-error-in-your-xbox-one-game.md)</li><li>[Xbox One、ゲームでエラー用の CAB ファイルをダウンロードします。](download-the-cab-file-for-an-error-in-your-xbox-one-game.md)</li></ul> |

### <a name="methods-for-hardware-and-drivers"></a>ハードウェアとドライバー向けのメソッド

開発者アカウントに属している、 [Windows ハードウェア ダッシュ ボード プログラム](https://msdn.microsoft.com/windows/hardware/drivers/dashboard/get-started-with-the-hardware-dashboard)追加ハードウェアとドライバーの分析データを取得するためのメソッドのセットにアクセスします。 詳細については、次を参照してください。[ハードウェア ダッシュ ボード API](https://docs.microsoft.com/windows-hardware/drivers/dashboard/dashboard-api)します。

## <a name="code-example"></a>コードの例

次のコード例は、Azure AD アクセス トークンを取得し、C# コンソール アプリから Microsoft Store 分析 API を呼び出す方法を示しています。 このコード例を使う場合は、変数 *tenantId*、*clientId*、*clientSecret*、および *appID* を自分のシナリオに合った適切な値に割り当ててください。 この例では、Microsoft Store 分析 API から返される JSON データを逆シリアル化するときに、Newtonsoft の [Json.NET パッケージ](https://www.newtonsoft.com/json)が必要になります。

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
