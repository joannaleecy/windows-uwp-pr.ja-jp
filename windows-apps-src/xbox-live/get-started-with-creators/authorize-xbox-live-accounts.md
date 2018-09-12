---
title: テスト環境で Xbox Live アカウントを承認する
author: KevinAsgari
description: 開発環境でのテストに使用するパブリックな Xbox Live アカウントを承認する方法について説明します。
ms.assetid: 9772b8f1-81db-4c57-a54d-4e9ca9142111
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, アカウント, テスト アカウント
ms.localizationpriority: medium
ms.openlocfilehash: 69c184d4cf3069b26cdce4cab35a225b6913fd2b
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3881495"
---
# <a name="authorize-xbox-live-accounts-for-testing-in-your-environment"></a>環境内でテスト用の Xbox Live アカウントを承認する

このトピックでは、公開元のテスト環境で Xbox Live アカウントをセットアップするプロセスについて説明します。

## <a name="prerequisites"></a>前提条件

Xbox Live テスト アカウントを承認するには、次のものが必要となります。

* [Xbox Live アカウント](https://support.xbox.com/browse/my-account/manage-account/Create%20account)

## <a name="navigate-to-the-xbox-test-account-page"></a>Xbox テスト アカウント ページに移動する
これはデベロッパー センターの [アカウント設定] セクション内にあります。

このセクションには、2 つの方法のいずれかでアクセスできます。

1. デベロッパー センター ダッシュボードで設定ギア ⚙️ をクリックすると、アカウント ビューが表示されます。 アカウント ビューの左側のナビゲーションで、**[Xbox テスト アカウント]** リンクをクリックします。
2. Xbox Live クリエーターズの構成に関するページでテスト セクションを探し、**[Authorize Xbox Live accounts for your test environment]** (テスト環境用に Xbox Live アカウントを承認する) というタイトルのリンクをクリックします。


## <a name="authorize-an-xbox-live-account-for-your-test-environment"></a>テスト環境用の Xbox Live アカウントを承認する

* Xbox テスト アカウント ページにアクセスすると、現在承認されているすべてのアカウントの一覧が表示されます。 新しいアカウントを承認するには、[アカウントの追加] ボタンをクリックします。

![Xbox Live アカウントの追加](../images/creators_udc/add_test_account.png)

* テキスト ボックスを 1 つ含むモーダルが画面に表示され、希望するアカウントのメール アドレスを入力できます。

![モーダルでの Xbox Live アカウントの追加](../images/creators_udc/add_test_account_modal.png)

* メール アドレスが存在し、それに Xbox Live アカウントが関連付けられていることを検証するため、[追加] ボタンをクリックします。 検証に合格したらモーダルが閉じられて、新しいアカウントが表に表示され、正常にテスト環境用に承認されたことが示されます。

![Xbox Live アカウントの追加の成功](../images/creators_udc/add_test_account_success.png)

## <a name="troubleshooting"></a>トラブルシューティング

モーダルで入力したメールは検索などのいくつかの検証を受け、メールが Xbox Live アカウントに関連付けられていることが確認されます。 これらの検証のいずれかが失敗した場合、アカウントは表に追加されず、アカウントは承認されません。また、"Sorry, there was an issue adding your email address" (申し訳ございません。メール アドレスの追加で問題が発生しました) というエラーが表示される場合があります。

問題が発生したかどうかを確認するには、そのアカウントで [Xbox.com](http://www.xbox.com/live/) にサインインしてください。 サインインできない場合、そのアカウントは Xbox Live アカウントではありません。
