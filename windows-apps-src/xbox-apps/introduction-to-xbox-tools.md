---
author: eliotcowley
title: Xbox One ツールの概要
description: Windows デバイス ポータルを使った、Xbox One 固有のツールである Dev Home
ms.author: elcowle
ms.date: 10/04/2017
ms.topic: article
keywords: windows 10, uwp, xbox one, ツール
ms.assetid: 6eaf376f-0d7c-49de-ad78-38e689b43658
ms.localizationpriority: medium
ms.openlocfilehash: 71fd9f3ad1c3fcf02420502692518310b896f52a
ms.sourcegitcommit: 70ab58b88d248de2332096b20dbd6a4643d137a4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/01/2018
ms.locfileid: "5923454"
---
# <a name="introduction-to-xbox-one-tools"></a><span data-ttu-id="0ad2f-104">Xbox One ツールの概要</span><span class="sxs-lookup"><span data-stu-id="0ad2f-104">Introduction to Xbox One tools</span></span>

<span data-ttu-id="0ad2f-105">このセクションでは、Dev Home アプリを介して Xbox Device Portal にアクセスする方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="0ad2f-105">This section covers how to access the Xbox Device Portal through the Dev Home app.</span></span>

## <a name="dev-home"></a><span data-ttu-id="0ad2f-106">Dev Home</span><span class="sxs-lookup"><span data-stu-id="0ad2f-106">Dev Home</span></span>

<span data-ttu-id="0ad2f-107">Dev Home は、Xbox One 開発キットに含まれ、開発者の生産性をサポートするための 1 つのツール エクスペリエンスです。</span><span class="sxs-lookup"><span data-stu-id="0ad2f-107">Dev Home is a tools experience on the Xbox One Development Kit designed to aid developer productivity.</span></span> <span data-ttu-id="0ad2f-108">Dev Home は、開発キットの管理と構成の機能を提供します。</span><span class="sxs-lookup"><span data-stu-id="0ad2f-108">Dev Home offers functionality to manage and configure your dev kit.</span></span>

<span data-ttu-id="0ad2f-109">Dev Home は、開発者モードで本体が起動するときに開かれる既定のアプリです。</span><span class="sxs-lookup"><span data-stu-id="0ad2f-109">Dev Home is the default app that is opened when your console in Developer Mode boots up.</span></span> <span data-ttu-id="0ad2f-110">Dev Home は、ホーム画面の **[Dev Home]** タイルを選択して開くこともできます。</span><span class="sxs-lookup"><span data-stu-id="0ad2f-110">You can also open Dev Home by selecting the **Dev Home** tile on the home screen.</span></span> <span data-ttu-id="0ad2f-111">タイルが表示されていない場合は、本体が開発者モードに設定されていません。</span><span class="sxs-lookup"><span data-stu-id="0ad2f-111">If there is no tile present, the console is not in Developer Mode.</span></span>

<span data-ttu-id="0ad2f-112">Dev Home について詳しくは、「[コンソール (Dev Home) における開発者ホーム](dev-home.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0ad2f-112">For more information about Dev Home, see [Developer Home on the Console (Dev Home)](dev-home.md).</span></span>

## <a name="xbox-device-portal"></a><span data-ttu-id="0ad2f-113">Xbox Device Portal</span><span class="sxs-lookup"><span data-stu-id="0ad2f-113">Xbox Device Portal</span></span>
<span data-ttu-id="0ad2f-114">Xbox Device Portal は、ブラウザー ベースのデバイス管理ツールであり、ゲームやアプリの追加、Xbox Live テスト アカウントの追加、サンドボックスの変更などを行うことができます。</span><span class="sxs-lookup"><span data-stu-id="0ad2f-114">The Xbox Device Portal is a browser-based device management tool that allows you to add games and apps, add Xbox Live test accounts, change sandboxes, and much more.</span></span>

<span data-ttu-id="0ad2f-115">Xbox One 本体で Xbox Device Portal を有効にするには、次のようにします。</span><span class="sxs-lookup"><span data-stu-id="0ad2f-115">To enable the Xbox Device Portal on your Xbox One console:</span></span>

1. <span data-ttu-id="0ad2f-116">ホーム画面で、**Dev Home** タイルを選びます。</span><span class="sxs-lookup"><span data-stu-id="0ad2f-116">Select the **Dev Home** tile on the home screen.</span></span>

  ![Dev Home タイルの選択](images/introduction-to-xbox-one-tools-1.png)

2. <span data-ttu-id="0ad2f-118">Dev Home 内で、**[ホーム]** タブに移動し、**[リモート アクセス]** セクションで、**[リモート アクセス設定]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="0ad2f-118">Within Dev Home, navigate to the **Home** tab, and in the **Remote Access** section, select **Remote Access Settings**.</span></span>

  ![リモート管理ツール](images/introduction-to-xbox-one-tools-2.png)

3. <span data-ttu-id="0ad2f-120">**[Enable Xbox Device Portal]** (Xbox Device Portal を有効にする) チェックボックスをオンにします。</span><span class="sxs-lookup"><span data-stu-id="0ad2f-120">Select the **Enable Xbox Device Portal** checkbox.</span></span>

4. <span data-ttu-id="0ad2f-121">**[Authentication]** (認証) で、**[Require authentication to remotely access this console from the web or PC tools]** (Web または PC ツールからこの本体にリモートでアクセスするときに認証を求める)チェック ボックスをオンにします。</span><span class="sxs-lookup"><span data-stu-id="0ad2f-121">Under **Authentication**, select the **Require authentication to remotely access this console from the web or PC tools** checkbox.</span></span>

5. <span data-ttu-id="0ad2f-122">**[ユーザー名]** と __[パスワード]__ を入力して、**[保存]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="0ad2f-122">Enter a **User name** and __Password__, and select **Save**.</span></span> <span data-ttu-id="0ad2f-123">この認証情報はブラウザーから開発キットへのアクセスの認証に使用されます。</span><span class="sxs-lookup"><span data-stu-id="0ad2f-123">These credentials are used to authenticate access to your dev kit from a browser.</span></span>

6. <span data-ttu-id="0ad2f-124">**[閉じる]** を選択し、**[ホーム]** タブの **[リモート アクセス]** ツールに表示される URL を書き留めます。</span><span class="sxs-lookup"><span data-stu-id="0ad2f-124">Select **Close**, and on the **Home** tab, note the URL listed in the **Remote Access** tool.</span></span>

7. <span data-ttu-id="0ad2f-125">ブラウザーに URL を入力します。</span><span class="sxs-lookup"><span data-stu-id="0ad2f-125">Enter the URL in your browser.</span></span> <span data-ttu-id="0ad2f-126">提供された証明書についての、次のスクリーン ショットのような警告が表示されます。これは、Xbox One 本体によって署名されたセキュリティ証明書が、既知の信頼された発行元とは見なされないためです。</span><span class="sxs-lookup"><span data-stu-id="0ad2f-126">You will receive a warning about the certificate that was provided, similar to the following screenshot, because the security certificate signed by your Xbox One console is not considered a well-known, trusted publisher.</span></span> <span data-ttu-id="0ad2f-127">Edge で **[詳細]** をクリックし、**[Go on to the webpage]** (Web ページにアクセス) をクリックして、Xbox Device Portal にアクセスします。</span><span class="sxs-lookup"><span data-stu-id="0ad2f-127">On Edge, click **Details** and then **Go on to the webpage** to access the Xbox Device Portal.</span></span>

    ![セキュリティ証明書の警告](images/introduction-to-xbox-one-tools-3.png)

8. <span data-ttu-id="0ad2f-129">構成した資格情報でサインインします。</span><span class="sxs-lookup"><span data-stu-id="0ad2f-129">Sign in with the credentials you configured.</span></span>

## <a name="xbox-dev-mode-companion"></a><span data-ttu-id="0ad2f-130">Xbox 開発者モード コンパニオン</span><span class="sxs-lookup"><span data-stu-id="0ad2f-130">Xbox Dev Mode Companion</span></span>
<span data-ttu-id="0ad2f-131">Xbox 開発者モード コンパニオンは、PC から離れずに本体を操作できるツールです。</span><span class="sxs-lookup"><span data-stu-id="0ad2f-131">Xbox Dev Mode Companion is a tool that allows you to work on your console without leaving your PC.</span></span> <span data-ttu-id="0ad2f-132">このアプリを使うと、本体の画面を表示し、入力を本体に送ることができます。</span><span class="sxs-lookup"><span data-stu-id="0ad2f-132">The app allows you to view the console screen and send input to it.</span></span> <span data-ttu-id="0ad2f-133">詳しくは、「[Xbox 開発者モード コンパニオン](xbox-dev-mode-companion.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0ad2f-133">For more information, see [Xbox Dev Mode Companion](xbox-dev-mode-companion.md).</span></span>

## <a name="see-also"></a><span data-ttu-id="0ad2f-134">関連項目</span><span class="sxs-lookup"><span data-stu-id="0ad2f-134">See also</span></span>
- [<span data-ttu-id="0ad2f-135">UWP を開発するときに、Xbox One で Fiddler を使用する方法</span><span class="sxs-lookup"><span data-stu-id="0ad2f-135">How to use Fiddler with Xbox One when developing for UWP</span></span>](uwp-fiddler.md)
- [<span data-ttu-id="0ad2f-136">Windows Device Portal の概要</span><span class="sxs-lookup"><span data-stu-id="0ad2f-136">Windows Device Portal overview</span></span>](../debug-test-perf/device-portal.md)
- [<span data-ttu-id="0ad2f-137">Xbox One の UWP</span><span class="sxs-lookup"><span data-stu-id="0ad2f-137">UWP on Xbox One</span></span>](index.md)