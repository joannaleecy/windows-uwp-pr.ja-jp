---
Description: 管理および各パートナー センターのアプリに関連する詳細を表示するなどのサービスの構成/B がテストされ、マップされます。
title: アプリの管理とサービス
ms.assetid: 99DA2BC1-9B5D-4746-8BC0-EC723D516EEF
ms.date: 10/31/2018
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: d6261a7cce86c82b4865d7ca1d68c082cba9ccca
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57610007"
---
# <a name="app-management-and-services"></a>アプリの管理とサービス

各でアプリに関連する詳細を管理および表示できます[パートナー センター](https://partner.microsoft.com/dashboard/)通知などのサービスを構成および B は、テスト、およびマップ/。

パートナー センターでのアプリを使用する場合は、左側のナビゲーション メニューのセクションを確認します**サービス**と**アプリ管理**します。 これらのセクションを展開すると、次の機能にアクセスできます。

## <a name="services"></a>サービス

**[サービス]** セクションでは、アプリのいくつかの異なるサービスを管理できます。

## <a name="xbox-live"></a>Xbox Live

有効にできますが、ゲームを公開する場合、 [Xbox Live クリエーターズ プログラム](https://xbox.com/developers/creators-program)このページでします。 これにより、構成とテスト、Xbox Live 機能を起動し、最終的に、Xbox Live クリエーターズ プログラム ゲームを発行することができます。

詳細については、[Xbox Live クリエーターズ プログラムの概要](../xbox-live/get-started-with-creators/get-started-with-xbox-live-creators.md)と[新しい Xbox Live クリエーターズ プログラムのタイトルを作成し、テスト環境に公開](../xbox-live/get-started-with-creators/create-and-test-a-new-creators-title.md)を参照してください。

## <a name="experimentation"></a>Experimentation

**[Experimentation]** ページを使うと、ユニバーサル Windows プラットフォーム (UWP) アプリの試験的機能を作成し、A/B テストを実行できます。 アプリの機能の変更をすべてのユーザー向けに有効にする前に、一部のユーザーに対して変更 (またはバリエーション) の有効性を A/B テストで測定します。

詳しくは、「[A/B テストを使用してアプリの試験的機能を実行する](../monetize/run-app-experiments-with-a-b-testing.md)」をご覧ください。

## <a name="maps"></a>マップ

Windows 10 または Windows 8.x を対象としたアプリでマップ サービスを使うには、[Bing 地図デベロッパー センター](https://go.microsoft.com/fwlink/p/?LinkId=614880)にアクセスしてください。 Bing マップ デベロッパー センターからマップの認証キーを要求し、アプリに追加する方法については、次を参照してください。[マップ認証キーを要求](../maps-and-location/authentication-key.md)の詳細。 

使用して、**マップ**ページ Windows Phone 8.1 以前発行されたアプリに対してのみです。 これらのアプリでマップのサービスを使用するには、アプリのコードに含めるには、マップ サービスのアプリケーション ID とトークンを要求する必要があります。 クリックすると**トークンを取得する**、マップ サービス アプリケーション ID を生成します (**ApplicationID**) とマップ サービスの認証トークン (**AuthenticationToken**) アプリの。 パッケージ化したりする前に、コードをこれらの値を追加し、アプリを送信してください。 詳細については、「[Windows Phone 8 でマップ コントロールをページに追加する方法](https://go.microsoft.com/fwlink/p/?LinkId=614882)」を参照してください。

## <a name="product-collections-and-purchases"></a>製品のコレクションと購入

Microsoft Store コレクション API と Microsoft Store 購入 API を使用して、アプリケーションとアドオンの所有権情報にアクセスする、関連付けられている入力する必要があります。 ここでの Azure AD クライアント Id。 これらの変更が有効になるまで最大で 16 時間かかることに注意してください。

詳しくは、「[サービスから製品の権利を管理する](../monetize/view-and-grant-products-from-a-service.md)」をご覧ください。

## <a name="administrator-consent"></a>管理者の同意

お使いの製品が Azure AD と連携し、いずれかを要求する Api を呼び出すかどうか[アプリケーションのアクセス許可または委任されたアクセス許可](https://developer.microsoft.com/graph/docs/concepts/permissions_reference)を管理者の同意が必要です、ここで、Azure AD のクライアント ID を入力します。 これにより、管理者がテナント内のすべてのユーザーの代理として機能するのには、製品の組織 grant 同意用アプリを取得します。

詳細については、[テナント全体の同意を要求する](https://docs.microsoft.com/en-us/azure/active-directory/develop/active-directory-v2-scopes#requesting-consent-for-an-entire-tenant)を参照してください。

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

## <a name="wnsmpns"></a>WNS または MPNS

**WNS/MPNS**セクションを作成して、アプリの顧客に通知を送信するオプションを提供します。 

> [!TIP]
> UWP アプリの使用を推奨、**通知**パートナー センターで機能します。 この機能では、すべてのアプリの顧客に通知を送信できます。 または、対象となる条件を満たす、Windows 10 の顧客のサブセットには、で定義した、[顧客セグメント](create-customer-segments.md)します。 詳しくは、「[アプリのユーザーに通知を送信する](send-push-notifications-to-your-apps-customers.md)」をご覧ください。

アプリのパッケージの種類、その特定の要件に応じて、次のオプションのいずれかを使用することができますも。 

-   **Windows プッシュ通知サービス (WNS)** を使うと、独自のクラウド サービスからトースト更新、タイル更新、バッジ更新、直接更新を送ることができます。 詳しくは、「[Windows プッシュ通知サービスの概要](../design/shell/tiles-and-notifications/windows-push-notification-services--wns--overview.md)」をご覧ください。

-   **Microsoft Azure Mobile Apps** を使うと、プッシュ通知の送信や、アプリ ユーザーの認証や管理、クラウドでのアプリ データの保存をすることができます。 詳しくは、[モバイル アプリに関するドキュメント](https://go.microsoft.com/fwlink/p/?LinkId=221116)をご覧ください。

-   **Microsoft プッシュ通知サービス (MPNS)** Windows Phone の前に発行された .xap パッケージで使用できます。 ここで構成を行わなくても、認証されていない通知を限られた数送信することができますが、制限が減らないように認証済みの通知を使うことをお勧めします。 MPNS を使用している場合に表示されたフィールドに証明書をアップロードする必要があります、 **WNS/MPNS**ページ。 詳しくは、「[Windows Phone 8 のプッシュ通知を送信するように認証済み Web サービスを設定する](https://go.microsoft.com/fwlink/p/?LinkId=528736)」をご覧ください。
 

 
