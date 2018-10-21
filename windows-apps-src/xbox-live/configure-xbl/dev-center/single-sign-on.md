---
title: デベロッパー センターでのシングル サインオンの構成
author: KevinAsgari
description: タイトルがユーザーの Xbox Live ID を使ってユーザーをサービスにサインインさせることができるように、デベロッパー センターでシングル サインオンを構成する方法について説明します。
ms.assetid: ''
ms.author: kevinasg
ms.date: 02/21/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
ms.localizationpriority: medium
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, UDC, ユニバーサル デベロッパー センター, シングル サインオン
ms.openlocfilehash: 7c23ace80f18d7d5fa7fdbf2c562436b998516f5
ms.sourcegitcommit: 72835733ec429a5deb6a11da4112336746e5e9cf
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/21/2018
ms.locfileid: "5158549"
---
# <a name="configure-single-sign-on-in-dev-center"></a><span data-ttu-id="12691-104">デベロッパー センターでのシングル サインオンの構成</span><span class="sxs-lookup"><span data-stu-id="12691-104">Configure single sign-on in Dev center</span></span>

<span data-ttu-id="12691-105">シングル サインオンを使うと、タイトルを利用するプレイヤーが自分の Xbox Live サインインを使ってサービスにサインインできます。</span><span class="sxs-lookup"><span data-stu-id="12691-105">Single sign-on allows a player using your title to sign into your services by using their Xbox Live sign-in.</span></span> <span data-ttu-id="12691-106">これにより、Xbox Live にサインインしているプレイヤーが、サービスに固有の異なるアカウント資格情報を使ってもう一度ログインしなくても、サービスのアプリやゲームを実行できるようになります。</span><span class="sxs-lookup"><span data-stu-id="12691-106">This lets a player that is signed into Xbox Live run an app or game for your service without having to log in a second time using a different account credential specific to your service.</span></span>

> [!NOTE]
> <span data-ttu-id="12691-107">このトピックは、Xbox Live クリエーターズ プログラムのタイトルには適用されません。</span><span class="sxs-lookup"><span data-stu-id="12691-107">This topic does not apply to titles in the Xbox Live Creators Program.</span></span>

<span data-ttu-id="12691-108">たとえば、サービスの有効なアカウントを持っていれば、サービスがデバイスにコンテンツ (ビデオや音楽など) をストリーミングすることを可能にするアプリなどのタイトルがあります。</span><span class="sxs-lookup"><span data-stu-id="12691-108">For example, your title might be an app that enables your service to stream content (videos, music, etc.) to their device, as long as they have a valid account with your service.</span></span> <span data-ttu-id="12691-109">ユーザーが自分の Xbox Live アカウントにログインしている場合、毎回サービスにサインインしなくてもコンテンツをストリーミングできる必要があります。</span><span class="sxs-lookup"><span data-stu-id="12691-109">If the user is logged into their Xbox Live account, they should be able to stream content without having to sign in to your service each time.</span></span>

<span data-ttu-id="12691-110">また、アプリが Kinect データを外部サービスに送信する場合も、ここで構成できます。</span><span class="sxs-lookup"><span data-stu-id="12691-110">Also, if your app sends Kinect data to an external service, you can configure that here.</span></span>

<span data-ttu-id="12691-111">Xbox Live とは別のアカウントを作成することをサービスがユーザーに求めている場合、ユーザーが 1 回限りの操作で自分の Xbox Live アカウントをサービスのアカウントとリンクする手段を用意してください。</span><span class="sxs-lookup"><span data-stu-id="12691-111">If your service requires that the user creates an account separate from Xbox Live, you should provide a way for the user to link their Xbox Live account with their account on your service as a one time action.</span></span>

<span data-ttu-id="12691-112">シングル サインオンを構成するときは、URL と証明書利用者を指定できます。</span><span class="sxs-lookup"><span data-stu-id="12691-112">When you configure single sign-on, you can specify URLs and their relying party.</span></span> <span data-ttu-id="12691-113">アプリが指定された URL のいずれかを呼び出すと必ず、Xbox Live は Xbox Secure Token Service (XSTS) トークンを自動的にアタッチします。</span><span class="sxs-lookup"><span data-stu-id="12691-113">Any time that your app calls any of the URLs specified, Xbox Live will automatically attach an Xbox Secure Token Service (XSTS) token.</span></span> <span data-ttu-id="12691-114">キーを受け取るサービスは*証明書利用者*と呼ばれ、シングル サインオンを構成する前に[証明書利用者](https://developer.microsoft.com/en-US/xboxconfig/relyingparties/index)を構成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="12691-114">The service that receives the key is known as a *relying party*, and you must configure [relying parties](https://developer.microsoft.com/en-US/xboxconfig/relyingparties/index) before you can configure single sign-on.</span></span> <span data-ttu-id="12691-115">各証明書利用者構成では、XSTS トークンに含まれている情報と、証明書利用者が XSTS トークンのデコードに使用できる一意の暗号化キーを指定します。</span><span class="sxs-lookup"><span data-stu-id="12691-115">Each relying party configuration specifies what information is contained in the XSTS token, as well as a unique encryption key that the relying party can use to decode the XSTS token.</span></span>

<span data-ttu-id="12691-116">次の手順に従って、構成を追加します。</span><span class="sxs-lookup"><span data-stu-id="12691-116">Add configuration by doing the following:</span></span>

1. <span data-ttu-id="12691-117">[デベロッパー センター](https://developer.microsoft.com/dashboard/windows/overview)でタイトルを選択したら、**[サービス]** > **[Xbox Live]** に移動します。</span><span class="sxs-lookup"><span data-stu-id="12691-117">After selecting your title in [Dev Center](https://developer.microsoft.com/dashboard/windows/overview), navigate to **Services** > **Xbox Live**.</span></span>

2. <span data-ttu-id="12691-118">**Xbox Live シングル サインオン**へのリンクをクリックします。</span><span class="sxs-lookup"><span data-stu-id="12691-118">Click on the link to **Xbox Live single sign-on**.</span></span>

3. <span data-ttu-id="12691-119">**[URL の追加]** をクリックし、新しいシングル サインオン エントリを作成します。</span><span class="sxs-lookup"><span data-stu-id="12691-119">Click on the **Add URL** button to create a new single sign-on entry.</span></span> <span data-ttu-id="12691-120">構成の一覧の最後に新しい行が追加されます。</span><span class="sxs-lookup"><span data-stu-id="12691-120">This will add a new row to the bottom of the list of configurations.</span></span>

4. <span data-ttu-id="12691-121">[URL] ボックスに、完全修飾ドメイン名を使ってサービスの URL を入力します。</span><span class="sxs-lookup"><span data-stu-id="12691-121">In the URL box, enter the URL for your service using a fully qualified domain name.</span></span> <span data-ttu-id="12691-122">最下位レベルのサブドメインは、ワイルドカード文字 ('\*') に置き換えることができます。</span><span class="sxs-lookup"><span data-stu-id="12691-122">You may replace the lowest-level subdomain with a wildcard character ('\*').</span></span> <span data-ttu-id="12691-123">これは、同じ上位レベルのドメインを持つあらゆる URL にマッチングします。</span><span class="sxs-lookup"><span data-stu-id="12691-123">This will match any URL that has the same upper-level domains.</span></span> <span data-ttu-id="12691-124">たとえば、"\*.example.com&quot; は "bar.example.com" や "foo.bar.example.com" にマッチングします。</span><span class="sxs-lookup"><span data-stu-id="12691-124">For example, "\*.example.com&quot; will match "bar.example.com" or "foo.bar.example.com".</span></span>

5. <span data-ttu-id="12691-125">[証明書利用者] ボックスで、XSTS トークンをエンコードする方法を指定する証明書利用者構成を選択します。</span><span class="sxs-lookup"><span data-stu-id="12691-125">In the Relying party box, select the relying party configuration that specifies how the XSTS token is encoded.</span></span>

6. <span data-ttu-id="12691-126">**[保存]** をクリックして、変更を保存します。</span><span class="sxs-lookup"><span data-stu-id="12691-126">Click on the **Save** button to save your changes.</span></span>

![シングル サインオンの構成ページのスクリーンショット](../../images/dev-center/single-signon.png)
