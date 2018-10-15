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
ms.sourcegitcommit: 106aec1e59ba41aae2ac00f909b81bf7121a6ef1
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/15/2018
ms.locfileid: "4614384"
---
# <a name="authorize-xbox-live-accounts-for-testing-in-your-environment"></a><span data-ttu-id="7920f-104">環境内でテスト用の Xbox Live アカウントを承認する</span><span class="sxs-lookup"><span data-stu-id="7920f-104">Authorize Xbox Live Accounts for Testing in your environment</span></span>

<span data-ttu-id="7920f-105">このトピックでは、公開元のテスト環境で Xbox Live アカウントをセットアップするプロセスについて説明します。</span><span class="sxs-lookup"><span data-stu-id="7920f-105">This topic will go through the process of setting up an Xbox Live account with your publishers test environment</span></span>

## <a name="prerequisites"></a><span data-ttu-id="7920f-106">前提条件</span><span class="sxs-lookup"><span data-stu-id="7920f-106">Prerequisites</span></span>

<span data-ttu-id="7920f-107">Xbox Live テスト アカウントを承認するには、次のものが必要となります。</span><span class="sxs-lookup"><span data-stu-id="7920f-107">You will need the following to authorize an Xbox Live test account:</span></span>

* <span data-ttu-id="7920f-108">[Xbox Live アカウント](https://support.xbox.com/browse/my-account/manage-account/Create%20account)</span><span class="sxs-lookup"><span data-stu-id="7920f-108">An [Xbox Live account](https://support.xbox.com/browse/my-account/manage-account/Create%20account)</span></span>

## <a name="navigate-to-the-xbox-test-account-page"></a><span data-ttu-id="7920f-109">Xbox テスト アカウント ページに移動する</span><span class="sxs-lookup"><span data-stu-id="7920f-109">Navigate to the Xbox Test Account page</span></span>
<span data-ttu-id="7920f-110">これはデベロッパー センターの [アカウント設定] セクション内にあります。</span><span class="sxs-lookup"><span data-stu-id="7920f-110">This is located in the Account Settings section of Dev Center</span></span>

<span data-ttu-id="7920f-111">このセクションには、2 つの方法のいずれかでアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="7920f-111">You can arrive at this section in one of two ways</span></span>

1. <span data-ttu-id="7920f-112">デベロッパー センター ダッシュボードで設定ギア ⚙️ をクリックすると、アカウント ビューが表示されます。</span><span class="sxs-lookup"><span data-stu-id="7920f-112">From the Dev Center dashboard click the settings gear ⚙️ which will take you to the account view.</span></span> <span data-ttu-id="7920f-113">アカウント ビューの左側のナビゲーションで、**[Xbox テスト アカウント]** リンクをクリックします。</span><span class="sxs-lookup"><span data-stu-id="7920f-113">In the left navigation of the account view click the **Xbox test accounts** link</span></span>
2. <span data-ttu-id="7920f-114">Xbox Live クリエーターズの構成に関するページでテスト セクションを探し、**[Authorize Xbox Live accounts for your test environment]** (テスト環境用に Xbox Live アカウントを承認する) というタイトルのリンクをクリックします。</span><span class="sxs-lookup"><span data-stu-id="7920f-114">From your Xbox Live Creators configuration page locate the test section and click the link entitled **Authorize Xbox Live accounts for your test environment**</span></span>


## <a name="authorize-an-xbox-live-account-for-your-test-environment"></a><span data-ttu-id="7920f-115">テスト環境用の Xbox Live アカウントを承認する</span><span class="sxs-lookup"><span data-stu-id="7920f-115">Authorize an Xbox Live Account for your test environment</span></span>

* <span data-ttu-id="7920f-116">Xbox テスト アカウント ページにアクセスすると、現在承認されているすべてのアカウントの一覧が表示されます。</span><span class="sxs-lookup"><span data-stu-id="7920f-116">Once within the Xbox test accounts page you should see a list of all currently authorized accounts.</span></span> <span data-ttu-id="7920f-117">新しいアカウントを承認するには、[アカウントの追加] ボタンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="7920f-117">To authorize a new account, click the Add account button</span></span>

![Xbox Live アカウントの追加](../images/creators_udc/add_test_account.png)

* <span data-ttu-id="7920f-119">テキスト ボックスを 1 つ含むモーダルが画面に表示され、希望するアカウントのメール アドレスを入力できます。</span><span class="sxs-lookup"><span data-stu-id="7920f-119">A modal should pop into the screen with one text box where you can enter the desired account’s email address</span></span>

![モーダルでの Xbox Live アカウントの追加](../images/creators_udc/add_test_account_modal.png)

* <span data-ttu-id="7920f-121">メール アドレスが存在し、それに Xbox Live アカウントが関連付けられていることを検証するため、[追加] ボタンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="7920f-121">Click the add button to validate that the email address exists and has an associated Xbox Live Account.</span></span> <span data-ttu-id="7920f-122">検証に合格したらモーダルが閉じられて、新しいアカウントが表に表示され、正常にテスト環境用に承認されたことが示されます。</span><span class="sxs-lookup"><span data-stu-id="7920f-122">If the checks pass the modal will disappear and you will see the new account in the table indicting it is now successfully authorized for your test environment</span></span>

![Xbox Live アカウントの追加の成功](../images/creators_udc/add_test_account_success.png)

## <a name="troubleshooting"></a><span data-ttu-id="7920f-124">トラブルシューティング</span><span class="sxs-lookup"><span data-stu-id="7920f-124">Troubleshooting</span></span>

<span data-ttu-id="7920f-125">モーダルで入力したメールは検索などのいくつかの検証を受け、メールが Xbox Live アカウントに関連付けられていることが確認されます。</span><span class="sxs-lookup"><span data-stu-id="7920f-125">The email entered in the modal is run through a few checks including a lookup to ensure there is an Xbox Live account associated with it.</span></span> <span data-ttu-id="7920f-126">これらの検証のいずれかが失敗した場合、アカウントは表に追加されず、アカウントは承認されません。また、"Sorry, there was an issue adding your email address" (申し訳ございません。メール アドレスの追加で問題が発生しました) というエラーが表示される場合があります。</span><span class="sxs-lookup"><span data-stu-id="7920f-126">If any of these checks fail, the account is not added to the table and therefore not authorized and you may get a "Sorry, there was an issue adding your email address" error.</span></span>

<span data-ttu-id="7920f-127">問題が発生したかどうかを確認するには、そのアカウントで [Xbox.com](http://www.xbox.com/live/) にサインインしてください。</span><span class="sxs-lookup"><span data-stu-id="7920f-127">A good check if you are having issues is to try and sign in with the account on [Xbox.com](http://www.xbox.com/live/).</span></span> <span data-ttu-id="7920f-128">サインインできない場合、そのアカウントは Xbox Live アカウントではありません。</span><span class="sxs-lookup"><span data-stu-id="7920f-128">If you can’t sign in then the account is not an Xbox Live account.</span></span>
