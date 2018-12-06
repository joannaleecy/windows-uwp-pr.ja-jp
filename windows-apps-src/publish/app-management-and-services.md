---
Description: Manage and view details related to each of your apps in Partner Center, and configure services such as A/B testing and maps.
title: アプリの管理とサービス
ms.assetid: 99DA2BC1-9B5D-4746-8BC0-EC723D516EEF
ms.date: 10/31/2018
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 6a8f75fae686763f3d79cea2f02c3208993cb723
ms.sourcegitcommit: d7613c791107f74b6a3dc12a372d9de916c0454b
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/05/2018
ms.locfileid: "8748444"
---
# <a name="app-management-and-services"></a>アプリの管理とサービス

管理および各アプリに関連する詳細を表示する [パートナー センターでは、通知などのサービスを構成 B は、テスト、およびマップします。

パートナー センターでアプリを使用する場合の**サービス**と**アプリの管理**セクションでは、左側のナビゲーション メニューが表示されます。 これらのセクションを展開すると、次の機能にアクセスできます。

## <a name="services"></a>サービス

**[サービス]** セクションでは、アプリのいくつかの異なるサービスを管理できます。

## <a name="xbox-live"></a>Xbox Live

ゲームを公開する場合は、このページで、 [Xbox Live クリエーターズ プログラム](http://xbox.com/developers/creators-program)を有効にすることができます。 これにより、構成すると、テスト、Xbox Live 機能を起動し、最終的に、Xbox Live クリエーターズ プログラム ゲームを公開することができます。

詳しくは、 [Xbox Live クリエーターズ プログラムの概要](../xbox-live/get-started-with-creators/get-started-with-xbox-live-creators.md)と、[新しい Xbox Live クリエーターズ プログラム タイトルを作成しテスト環境に公開する](../xbox-live/get-started-with-creators/create-and-test-a-new-creators-title.md)を参照してください。

## <a name="experimentation"></a>Experimentation

**[Experimentation]** ページを使うと、ユニバーサル Windows プラットフォーム (UWP) アプリの試験的機能を作成し、A/B テストを実行できます。 アプリの機能の変更をすべてのユーザー向けに有効にする前に、一部のユーザーに対して変更 (またはバリエーション) の有効性を A/B テストで測定します。

詳しくは、「[A/B テストを使用してアプリの試験的機能を実行する](../monetize/run-app-experiments-with-a-b-testing.md)」をご覧ください。

## <a name="maps"></a>マップ

Windows 10 または Windows 8.x を対象としたアプリでマップ サービスを使うには、[Bing 地図デベロッパー センター](http://go.microsoft.com/fwlink/p/?LinkId=614880)にアクセスしてください。 Bing Maps Developer Center から、マップ認証キーを要求し、アプリに追加する方法について詳しくは、詳しくは[、マップ認証キーの要求](../maps-and-location/authentication-key.md)を参照してください。 

Windows Phone 8.1 と以前公開したアプリのみで、**マップ**のページを使用します。 これらのアプリでマップ サービスを使用するには、アプリのコードに含めるマップ サービス アプリケーション ID とトークンを要求する必要があります。 **トークンを取得する**] をクリックすると、マップ サービス アプリケーション ID (**ApplicationID**) を生成し、アプリの認証トークン (**AuthenticationToken**) サービスをマップしますがします。 必ずをパッケージ化する前に、コードにこれらの値を追加し、アプリを提出してください。 詳細については、「[Windows Phone 8 でマップ コントロールをページに追加する方法](http://go.microsoft.com/fwlink/p/?LinkId=614882)」を参照してください。

## <a name="product-collections-and-purchases"></a>製品のコレクションと購入

Microsoft Store コレクション API と、Microsoft Store 購入 API を使用すると、アプリとアドオンの所有権情報にアクセスして、関連付けられているを入力する必要があります。 ここでの Azure AD クライアント Id。 これらの変更が有効になるまで最大で 16 時間かかることに注意してください。

詳しくは、「[サービスから製品の権利を管理する](../monetize/view-and-grant-products-from-a-service.md)」をご覧ください。

## <a name="administrator-consent"></a>管理者の承認

Azure AD と統合し、管理者の承認を必要とする[アプリケーションのアクセス権やアクセス許可を委任](https://developer.microsoft.com/graph/docs/concepts/permissions_reference)を要求する Api を呼び出して、製品の f では、次に、Azure AD クライアント ID を入力します。 これにより、管理者が組織付与同意を得て、テナントのすべてのユーザーの代理として行為する製品のためにアプリを入手できます。

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
> UWP アプリでは、パートナー センターで**通知**機能の使用をお勧めします。 この機能では、すべてのアプリのユーザーに通知を送信できます。 または、[顧客セグメント](create-customer-segments.md)で定義した条件を満たす Windows 10 の顧客の対象となるサブセットにします。 詳しくは、「[アプリのユーザーに通知を送信する](send-push-notifications-to-your-apps-customers.md)」をご覧ください。

アプリのパッケージの種類とその具体的な要件に応じて、次のオプションのいずれかを使用することも。 

-   **Windows プッシュ通知サービス (WNS)** を使うと、独自のクラウド サービスからトースト更新、タイル更新、バッジ更新、直接更新を送ることができます。 詳しくは、「[Windows プッシュ通知サービス (WNS) の概要](../design/shell/tiles-and-notifications/windows-push-notification-services--wns--overview.md)」をご覧ください。

-   **Microsoft Azure Mobile Apps** を使うと、プッシュ通知の送信や、アプリ ユーザーの認証や管理、クラウドでのアプリ データの保存をすることができます。 詳しくは、[モバイル アプリに関するドキュメント](http://go.microsoft.com/fwlink/p/?LinkId=221116)をご覧ください。

-   **Microsoft プッシュ通知サービス (MPNS)** は、Windows Phone 向けに公開した .xap パッケージで使用できます。 ここで構成を行わなくても、認証されていない通知を限られた数送信することができますが、制限が減らないように認証済みの通知を使うことをお勧めします。 MPNS を使用している場合は、 **WNS/MPNS** ] ページで提供されるフィールドに証明書をアップロードする必要があります。 詳しくは、「[Windows Phone 8 のプッシュ通知を送信するように認証済み Web サービスを設定する](http://go.microsoft.com/fwlink/p/?LinkId=528736)」をご覧ください。
 

 
