---
author: jnHs
Description: Manage and view details related to each of your apps in the Windows Dev Center dashboard, and configure services such as A/B testing and maps.
title: アプリの管理とサービス
ms.assetid: 99DA2BC1-9B5D-4746-8BC0-EC723D516EEF
ms.author: wdg-dev-content
ms.date: 07/18/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: d0e4be450aa972ad8561f27a8d4749050458520a
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/11/2018
ms.locfileid: "3849856"
---
# <a name="app-management-and-services"></a>アプリの管理とサービス

Windows デベロッパー センター ダッシュボードで各アプリに関連する詳細を管理および表示し、通知、A/B テスト、マップなどのサービスを構成できます。

ダッシュボードでアプリを操作するとき、左側のナビゲーション メニューに **[サービス]** と **[アプリ管理]** のセクションが表示されます。 これらのセクションを展開すると、次の機能にアクセスできます。

## <a name="services"></a>サービス

**[サービス]** セクションでは、アプリのいくつかの異なるサービスを管理できます。

## <a name="xbox-live"></a>Xbox Live

ゲームを公開する場合は、このページで、 [Xbox Live クリエーターズ プログラム](http://xbox.com/developers/creators-program)を有効にすることができます。 これにより、構成すると、テスト、Xbox Live 機能を起動し、最終的に、Xbox Live クリエーターズ プログラム ゲームを公開することができます。

詳しくは、 [Xbox Live クリエーターズ プログラムの概要](../xbox-live/get-started-with-creators/get-started-with-xbox-live-creators.md)と、[新しい Xbox Live クリエーターズ プログラム タイトルを作成しテスト環境に公開](../xbox-live/get-started-with-creators/create-and-test-a-new-creators-title.md)をご覧ください。

## <a name="experimentation"></a>Experimentation

**[Experimentation]** ページを使うと、ユニバーサル Windows プラットフォーム (UWP) アプリの試験的機能を作成し、A/B テストを実行できます。 アプリの機能の変更をすべてのユーザー向けに有効にする前に、一部のユーザーに対して変更 (またはバリエーション) の有効性を A/B テストで測定します。

詳しくは、「[A/B テストを使用してアプリの試験的機能を実行する](../monetize/run-app-experiments-with-a-b-testing.md)」をご覧ください。

## <a name="maps"></a>マップ

Windows Phone 8.1 以前を対象としたアプリでマップ サービスを使うには、アプリのコードに含めるマップ サービス アプリケーション ID とトークンが必要です。 **[マップ]** ページの **[サービス]** セクションでこのトークンを取得できます。

> [!NOTE]
> Windows 10 または Windows 8.x を対象としたアプリでマップ サービスを使うには、[Bing 地図デベロッパー センター](http://go.microsoft.com/fwlink/p/?LinkId=614880)にアクセスしてください。 詳しくは、「[マップ認証キーの要求](https://docs.microsoft.com/windows/uwp/maps-and-location/authentication-key)」をご覧ください。

詳しくは、「[マップ サービスの使用](use-map-services.md)」をご覧ください。

## <a name="product-collections-and-purchases"></a>製品のコレクションと購入

Microsoft Store コレクション API と、Microsoft Store 購入 API を使用すると、アプリとアドオンの所有権情報にアクセスして、関連付けられているを入力する必要があります。 ここでの Azure AD クライアント Id。 これらの変更が有効になるまで最大で 16 時間かかることに注意してください。

詳しくは、「[サービスから製品の権利を管理する](../monetize/view-and-grant-products-from-a-service.md)」をご覧ください。

## <a name="administrator-consent"></a>管理者の承認

Azure AD と統合し、管理者の同意を必要とする[アプリケーションのアクセス権やアクセス許可を委任](https://developer.microsoft.com/graph/docs/concepts/permissions_reference)を要求している Api を呼び出す、製品の f では、ここでは、Azure AD クライアント ID を入力します。 これにより、組織付与同意を得て、テナントのすべてのユーザーの代理として行為する製品のためにアプリを取得した管理者です。

詳しくは、[全体のテナントの同意を要求する](https://docs.microsoft.com/en-us/azure/active-directory/develop/active-directory-v2-scopes#requesting-consent-for-an-entire-tenant)を参照してください。

## <a name="app-management"></a>アプリ管理

**[アプリ管理]** セクションでは、ID とパッケージの詳細を確認したり、アプリの名前を管理したりできます。

## <a name="app-identity"></a>アプリ ID

このページには、アプリの内容へのリンクの URL など、ストア内のアプリの一意の ID に関連する詳細情報が表示されます。

詳しくは、「[アプリ ID の詳細の表示](view-app-identity-details.md)」をご覧ください。

## <a name="manage-app-names"></a>アプリ名の管理

ここでは、アプリのために予約したすべての名前を確認できます。 追加の名前の予約や、使わなくなったの名前の削除は、ここで行うことができます。

詳しくは、「[アプリ名の管理](manage-app-names.md)」をご覧ください。

## <a name="current-packages"></a>現在のパッケージ

このページでは、公開されたすべてのパッケージに関連する詳しい情報を確認することができます。

> [!NOTE]
> ここには、アプリが公開されるまで、情報は表示されません。

各パッケージの名前、バージョン、およびアーキテクチャが表示されます。 **[詳細]** をクリックすると、サポートされる言語、アプリの機能、ファイル サイズなどの詳しい情報が表示されます。 パッケージごとに表示される情報は、対象となるオペレーティング システムとその他の要因によって異なることがあります。 

OEM アクセス許可を持つ開発者は、**[現在のパッケージ]** ページから [プレインストール パッケージを生成](generate-preinstall-packages-for-oems.md) することもできます。

## <a name="wnsmpns"></a>WNS/MPNS

**WNS/MPNS** ] セクションでは、作成し、アプリのユーザーに通知を送信するためのオプションが提供されます。 

> [!TIP]
> UWP アプリの場合は、ダッシュ ボードで、**通知**のオプションを使用してお勧めします。 この機能では、すべてのアプリのユーザーに通知を送信できます。 または、[顧客セグメント](create-customer-segments.md)で定義した条件を満たす Windows 10 ユーザーのターゲットのサブセットにします。 詳しくは、「[アプリのユーザーに通知を送信する](send-push-notifications-to-your-apps-customers.md)」をご覧ください。

アプリのパッケージの種類とその具体的な要件に応じて、次のオプションのいずれかを使用することができますも。 

-   **Windows プッシュ通知サービス (WNS)** を使うと、独自のクラウド サービスからトースト更新、タイル更新、バッジ更新、直接更新を送ることができます。 詳しくは、「[Windows プッシュ通知サービス (WNS) の概要](../design/shell/tiles-and-notifications/windows-push-notification-services--wns--overview.md)」をご覧ください。

-   **Microsoft Azure Mobile Apps** を使うと、プッシュ通知の送信や、アプリ ユーザーの認証や管理、クラウドでのアプリ データの保存をすることができます。 詳しくは、[モバイル アプリに関するドキュメント](http://go.microsoft.com/fwlink/p/?LinkId=221116)をご覧ください。

-   **Microsoft プッシュ通知サービス (MPNS)** は、Windows Phone の .xap パッケージと一緒に使うことができます。 ここで構成を行わなくても、認証されていない通知を限られた数送信することができますが、制限が減らないように認証済みの通知を使うことをお勧めします。 MPNS を使用している場合は、[ **WNS/MPNS** ] ページで提供されるフィールドに証明書をアップロードする必要があります。 詳しくは、「[Windows Phone 8 のプッシュ通知を送信するように認証済み Web サービスを設定する](http://go.microsoft.com/fwlink/p/?LinkId=528736)」をご覧ください。
 

 
