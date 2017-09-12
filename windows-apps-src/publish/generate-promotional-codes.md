---
author: jnHs
Description: "Windows ストアに公開したアプリまたはアドオンのプロモーション コードを生成できます。"
title: "プロモーション コードを生成する"
ms.assetid: 9B632266-64EC-4D62-A4C4-55B6643D8750
ms.author: wdg-dev-content
ms.date: 06/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: 97d0cb79a00140a7255923131f78c2b3fecff1d9
ms.sourcegitcommit: fadde8afee46238443ec1cb71846d36c91db9fb9
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 06/21/2017
---
# <a name="generate-promotional-codes"></a><span data-ttu-id="9a933-104">プロモーション コードを生成する</span><span class="sxs-lookup"><span data-stu-id="9a933-104">Generate promotional codes</span></span>


<span data-ttu-id="9a933-105">Windows ストアに公開したアプリまたはアドオンのプロモーション コードを生成できます。</span><span class="sxs-lookup"><span data-stu-id="9a933-105">You can generate promotional codes for an app or add-on that you have published in the Windows Store.</span></span> <span data-ttu-id="9a933-106">プロモーション コードは、影響力を持つユーザーにアプリまたはアドオンへの無料アクセスを提供する簡単な方法です。</span><span class="sxs-lookup"><span data-stu-id="9a933-106">Promotional codes are an easy way to give influential users free access to your app or add-on.</span></span> <span data-ttu-id="9a933-107">また、アプリやアドオンへの無料アクセスをユーザーに提供する顧客サービスのシナリオに対応するため、または Windows 10 の[ベータ テスト](beta-testing-and-targeted-distribution.md)のために、プロモーション コードを使うこともできます。</span><span class="sxs-lookup"><span data-stu-id="9a933-107">You might also use promotional codes to address customer service scenarios by giving users free access to your app or add-on, or for [beta testing](beta-testing-and-targeted-distribution.md) with Windows 10.</span></span>

<span data-ttu-id="9a933-108">各プロモーション コードには、シングル ユーザーまたはユーザーのグループに配布可能な引き換え用の一意の URL が含まれています。</span><span class="sxs-lookup"><span data-stu-id="9a933-108">Each promotional code has a corresponding unique redeemable URL that you can distribute to a single user or to a group of users.</span></span> <span data-ttu-id="9a933-109">ユーザーはこの URL をクリックするだけで、プロモーション コードを使ってアプリまたはアドオンを Windows ストアからインストールできます。</span><span class="sxs-lookup"><span data-stu-id="9a933-109">The user can simply click the URL to redeem the code and install your app or add-on from the Windows Store.</span></span>

> [!TIP] 
> <span data-ttu-id="9a933-110">[ターゲット プッシュ通知](send-push-notifications-to-your-apps-customers.md)を使うと、特定のユーザーのセグメントにプロモーション コードを配布できます。</span><span class="sxs-lookup"><span data-stu-id="9a933-110">You can use [targeted push notifications](send-push-notifications-to-your-apps-customers.md) to distribute a promotional code to a segment of your customers.</span></span> <span data-ttu-id="9a933-111">この場合は、複数のユーザーに同じコードの使用が許可されるプロモーション コードを用意してください。</span><span class="sxs-lookup"><span data-stu-id="9a933-111">When doing so, be sure to use a promotional code that allows multiple customers to use the same code.</span></span>

<span data-ttu-id="9a933-112">Windows デベロッパー センター ダッシュボードでは、次の操作を実行できます。</span><span class="sxs-lookup"><span data-stu-id="9a933-112">In the Windows Dev Center dashboard, you can:</span></span>

-   <span data-ttu-id="9a933-113">アプリまたはアドオンのプロモーション コードのセットを注文する。</span><span class="sxs-lookup"><span data-stu-id="9a933-113">Order a set of promotional codes for your app or add-on.</span></span>
-   <span data-ttu-id="9a933-114">処理されたプロモーション コードの注文書をダウンロードする。</span><span class="sxs-lookup"><span data-stu-id="9a933-114">Download a fulfilled promotional codes order.</span></span>
-   <span data-ttu-id="9a933-115">プロモーション コードの使用状況を確認する。</span><span class="sxs-lookup"><span data-stu-id="9a933-115">Review promotional code usage.</span></span>

> [!NOTE]
> <span data-ttu-id="9a933-116">プロモーション コードは、[[表示]](set-app-pricing-and-availability.md#visibility) のオプションとして **[購入の停止: 直接リンクを知っているユーザーは製品のストア登録情報を表示できます。ただし、製品をダウンロードできるのは、以前にその製品を所有していたか、またはプロモーション コードを持っている場合で、かつ Windows 10 デバイスを使用している場合のみです。]** を選択している場合でも生成できます。</span><span class="sxs-lookup"><span data-stu-id="9a933-116">You can generate promotional codes even if you have selected the [Visibility](set-app-pricing-and-availability.md#visibility) option **Stop acquisition: Any customer with a direct link can see the product’s Store listing, but they can only download it if they owned the product before, or have a promotional code and are using a Windows 10 device.**</span></span>

<span data-ttu-id="9a933-117">ユーザーがプロモーション コードを利用してアプリをインストールするには、アプリが[アプリの認定プロセス](the-app-certification-process.md)の最終的な公開フェーズに合格する必要があります。</span><span class="sxs-lookup"><span data-stu-id="9a933-117">Note that your app must pass the final publishing phase of the [app certification process](the-app-certification-process.md) before customers can redeem a promotional code to install it.</span></span>

## <a name="promotional-code-policies"></a><span data-ttu-id="9a933-118">プロモーション コードのポリシー</span><span class="sxs-lookup"><span data-stu-id="9a933-118">Promotional code policies</span></span>


<span data-ttu-id="9a933-119">プロモーション コードの次のポリシーに注意してください。</span><span class="sxs-lookup"><span data-stu-id="9a933-119">Be aware of the following policies for promotional codes:</span></span>

-   <span data-ttu-id="9a933-120">プロモーション コードは、Windows ストアに公開したどのアプリまたはアドオンに対しても生成できます。</span><span class="sxs-lookup"><span data-stu-id="9a933-120">You can generate promotional codes for any app or add-on that you published to the Windows Store.</span></span> <span data-ttu-id="9a933-121">ユーザーは、アプリまたはアドオンがサポートしている任意のバージョンの Windows でコードを利用できます。</span><span class="sxs-lookup"><span data-stu-id="9a933-121">Customers can redeem the codes on any versions of Windows that are supported by your app or add-on.</span></span>
-   <span data-ttu-id="9a933-122">プロモーション コードは、(それより前の有効期限日を選択しなければ) 注文した日の 6 か月後に期限切れになります。</span><span class="sxs-lookup"><span data-stu-id="9a933-122">Promotional codes expire 6 months after the date you order them (unless you choose an earlier expiration date).</span></span>
-   <span data-ttu-id="9a933-123">各アプリまたはアドオンについて、6 か月ごとに最大 1,600 回の引き換えを許可するプロモーション コードを生成できます。</span><span class="sxs-lookup"><span data-stu-id="9a933-123">For each of your apps or add-ons, you can generate codes that allow up to 1600 redemptions every 6 months.</span></span> <span data-ttu-id="9a933-124">6 か月という期間は、最初のプロモーション コードの注文が提出された時点から開始され、それより前の有効期限日を選択した場合でも変わりません。</span><span class="sxs-lookup"><span data-stu-id="9a933-124">The 6 month period begins when the first promotional code order is submitted, even if you choose an earlier expiration date.</span></span> <span data-ttu-id="9a933-125">製品あたりの引き換え回数が合計 1,600 回までという条件は、一度限りのコードと複数回使用できるコードの両方に適用されます。</span><span class="sxs-lookup"><span data-stu-id="9a933-125">The total of 1600 redemptions per product applies to both single-use codes and codes that can be used multiple times.</span></span>
-   <span data-ttu-id="9a933-126">「[アプリ開発者契約](https://msdn.microsoft.com/library/windows/apps/hh694058)」で規定されている要件に従う必要があります (セクション 3k「**プロモーション コード**」を含む)。</span><span class="sxs-lookup"><span data-stu-id="9a933-126">You must follow the requirements defined in the [App Developer Agreement](https://msdn.microsoft.com/library/windows/apps/hh694058), including section **3k. Promotional Codes**.</span></span>

## <a name="order-promotional-codes"></a><span data-ttu-id="9a933-127">プロモーション コードの注文</span><span class="sxs-lookup"><span data-stu-id="9a933-127">Order promotional codes</span></span>


<span data-ttu-id="9a933-128">Windows ストアに公開したアプリまたはアドオンのプロモーション コードを注文するには、次の手順を実行します。</span><span class="sxs-lookup"><span data-stu-id="9a933-128">To order promotional codes for an app or add-on that you published to the Windows Store:</span></span>

1.  <span data-ttu-id="9a933-129">Windows デベロッパー センター ダッシュボードの左側のナビゲーション メニューで、**[ユーザーへのアピール]** を展開して、**[プロモーション コード]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="9a933-129">In the left navigation menu of the Windows Dev Center dashboard, expand **Attract** and then select **Promo codes.**</span></span>

2.   <span data-ttu-id="9a933-130">**[プロモーション コード]** ページで、**[注文コード]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="9a933-130">On the **Promotional codes** page, click **Order codes**.</span></span>

3.  <span data-ttu-id="9a933-131">**[新しいプロモーション コードの注文]** ページで、次を入力します。</span><span class="sxs-lookup"><span data-stu-id="9a933-131">On the **New promotional codes order** page, enter the following:</span></span>
    -   <span data-ttu-id="9a933-132">コードを生成するアプリまたはアドオンを選びます。</span><span class="sxs-lookup"><span data-stu-id="9a933-132">Select the app or add-on for which you want to generate codes.</span></span>
    -   <span data-ttu-id="9a933-133">注文の名前を指定します。</span><span class="sxs-lookup"><span data-stu-id="9a933-133">Specify a name for the order.</span></span> <span data-ttu-id="9a933-134">この名前は、プロモーション コードの利用状況データを確認するときに、異なるコードの注文を区別するために使うことができます。</span><span class="sxs-lookup"><span data-stu-id="9a933-134">You can use this name to differentiate between different orders of codes when reviewing your promotional code usage data.</span></span>
    -   <span data-ttu-id="9a933-135">注文の種類を選択します。</span><span class="sxs-lookup"><span data-stu-id="9a933-135">Select the order type.</span></span> <span data-ttu-id="9a933-136">それぞれ 1 回ずつ使用できるプロモーション コードのセットを生成することも、複数回使用できる 1 つのプロモーション コードを生成することもできます。</span><span class="sxs-lookup"><span data-stu-id="9a933-136">You can choose to generate a set of promo codes that can each be used once, or you can choose to generate one promo code that can be used multiple times.</span></span> 
    -   <span data-ttu-id="9a933-137">注文するコードの数を指定するか (コードのセットを生成する場合)、コードを引き換えることができる回数を指定します (複数回使用できる 1 つのコードを生成する場合)。</span><span class="sxs-lookup"><span data-stu-id="9a933-137">Specify the number of codes to order (if generating a set of codes) or the number of times the code can be redeemed (if generating one code to be used multiple times).</span></span>
    -   <span data-ttu-id="9a933-138">プロモーション コードがアクティブになる時期を指定します。</span><span class="sxs-lookup"><span data-stu-id="9a933-138">Specify when the promotional codes should become active.</span></span> <span data-ttu-id="9a933-139">特定の開始日時を選ぶには、**[コードは直ちにアクティブになります]** チェック ボックスをオフにします。</span><span class="sxs-lookup"><span data-stu-id="9a933-139">To choose a specific start date and time, clear the **Codes are active immediately** check box.</span></span> <span data-ttu-id="9a933-140">それ以外の場合、コードはすぐにアクティブになります。</span><span class="sxs-lookup"><span data-stu-id="9a933-140">Otherwise, the codes will be active immediately.</span></span>
    -   <span data-ttu-id="9a933-141">プロモーション コードの期限が切れる時期を指定します。</span><span class="sxs-lookup"><span data-stu-id="9a933-141">Specify when the promotional codes should expire.</span></span> <span data-ttu-id="9a933-142">有効期限として 6 か月より前の特定の日時を選ぶには、**[コードの期限が 6 か月後に切れます]** チェック ボックスをオフにします。</span><span class="sxs-lookup"><span data-stu-id="9a933-142">To choose a specific expire date and time earlier than 6 months, clear the **Codes expire after 6 months** check box.</span></span>

4.  <span data-ttu-id="9a933-143">**[注文コード]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="9a933-143">Click **Order codes**.</span></span> <span data-ttu-id="9a933-144">**[プロモーション コード]** ページに戻ります。そのアプリ用のプロモーション コードをまとめた表に、新しい注文が表示されます。</span><span class="sxs-lookup"><span data-stu-id="9a933-144">You'll then be returned to the **Promotional codes** page, where you'll be able to see your new order in the summary table of promotional code orders for that app.</span></span>


## <a name="download-and-distribute-promotional-codes"></a><span data-ttu-id="9a933-145">プロモーション コードのダウンロードと配布</span><span class="sxs-lookup"><span data-stu-id="9a933-145">Download and distribute promotional codes</span></span>

<span data-ttu-id="9a933-146">処理されたプロモーション コードの注文書をダウンロードし、ユーザーにコードを配布するには、次の手順を実行します。</span><span class="sxs-lookup"><span data-stu-id="9a933-146">To download a fulfilled promotional code order and distribute the codes to customers:</span></span>

1.  <span data-ttu-id="9a933-147">Windows デベロッパー センター ダッシュボードの左側のナビゲーション メニューで、**[ユーザーへのアピール]** を展開して、**[プロモーション コード]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="9a933-147">In the left navigation menu of the Windows Dev Center dashboard, expand **Attract** and then select **Promo codes.**</span></span>
2.  <span data-ttu-id="9a933-148">プロモーション コードの注文の **[ダウンロード]** リンクをクリックし、生成されたファイルをコンピューターに保存します。</span><span class="sxs-lookup"><span data-stu-id="9a933-148">Click the **Download** link for the promotional code order, then save the generated file to your computer.</span></span> <span data-ttu-id="9a933-149">このファイルには、プロモーション コードの注文に関する情報がタブ区切り値 (.tsv) の形式で含まれています。</span><span class="sxs-lookup"><span data-stu-id="9a933-149">This file contains information about your promotional codes order in tab-separated value (.tsv) format.</span></span>
3.  <span data-ttu-id="9a933-150">.tsv ファイルを好みのエディターで開きます。</span><span class="sxs-lookup"><span data-stu-id="9a933-150">Open the .tsv file in the editor of your choice.</span></span> <span data-ttu-id="9a933-151">最適な操作性のためには、Microsoft Excel など、表形式でデータを表示できるアプリケーションで .tsv ファイルを開くことをお勧めしますが、</span><span class="sxs-lookup"><span data-stu-id="9a933-151">For the best experience, open the .tsv file in an application that can display the data in a tabular structure, such as Microsoft Excel.</span></span> <span data-ttu-id="9a933-152">任意のテキスト エディターでファイルを開くこともできます。</span><span class="sxs-lookup"><span data-stu-id="9a933-152">However, you can open the file in any text editor.</span></span>

    <span data-ttu-id="9a933-153">ファイルには、コードごとに次の列から成るデータが含まれています。</span><span class="sxs-lookup"><span data-stu-id="9a933-153">The file contains the following columns of data for each code:</span></span>

    -   <span data-ttu-id="9a933-154">**製品名**: このコードが関連付けられているアプリまたはアドオンの名前。</span><span class="sxs-lookup"><span data-stu-id="9a933-154">**Product name**: The name of the app or add-on that the code is associated with.</span></span>
    -   <span data-ttu-id="9a933-155">**注文名**: コードが生成された注文の名前。</span><span class="sxs-lookup"><span data-stu-id="9a933-155">**Order name**: The name of the order in which this code was generated.</span></span>
    -   <span data-ttu-id="9a933-156">**プロモーション コード**: コードそのもの。</span><span class="sxs-lookup"><span data-stu-id="9a933-156">**Promotional code**: The code itself.</span></span> <span data-ttu-id="9a933-157">ハイフンで区切られた英数字の 5 x 5 の文字列です。</span><span class="sxs-lookup"><span data-stu-id="9a933-157">This is a 5x5 string of alphanumeric characters separated by hyphens.</span></span> <span data-ttu-id="9a933-158">たとえば、DM3GY-M2GYM-6YMW6-4QHHT-23W2Z のようになります。</span><span class="sxs-lookup"><span data-stu-id="9a933-158">For example: DM3GY-M2GYM-6YMW6-4QHHT-23W2Z</span></span>
    -   <span data-ttu-id="9a933-159">**購入 URL**: ユーザーがコードを引き換えてアプリまたはアドオンをインストールするために使う URL。</span><span class="sxs-lookup"><span data-stu-id="9a933-159">**Redeemable URL**: The URL that a customer can use to redeem the code and install your app or add-on.</span></span> <span data-ttu-id="9a933-160">この URL は http://go.microsoft.com/fwlink/?LinkId=532540&mstoken=&lt;プロモーション コード> という形式になります。</span><span class="sxs-lookup"><span data-stu-id="9a933-160">The URL has the following format: http://go.microsoft.com/fwlink/?LinkId=532540&mstoken=&lt;promotional_code></span></span>
    -   <span data-ttu-id="9a933-161">**開始日**: このコードがアクティブになる日付。</span><span class="sxs-lookup"><span data-stu-id="9a933-161">**Start date**: The date this code became active.</span></span>
    -   <span data-ttu-id="9a933-162">**有効期限**: このコードの有効期限が切れる日付。</span><span class="sxs-lookup"><span data-stu-id="9a933-162">**Expire date**: The date this code expires.</span></span>
    -   <span data-ttu-id="9a933-163">**コード ID**: このコードの一意の ID。</span><span class="sxs-lookup"><span data-stu-id="9a933-163">**Code ID**: A unique ID for this code.</span></span>
    -   <span data-ttu-id="9a933-164">**注文 ID**: このコードが生成された注文の一意の ID。</span><span class="sxs-lookup"><span data-stu-id="9a933-164">**Order ID**: A unique ID for the order in which this code was generated.</span></span>
    -   <span data-ttu-id="9a933-165">**指定**: コードの提供先のユーザーを追跡するために使用できる空のフィールド。</span><span class="sxs-lookup"><span data-stu-id="9a933-165">**Given to**: An empty field that you can use to keep track of which customer you gave the code to.</span></span>
    -   <span data-ttu-id="9a933-166">**利用可能**: (ファイルが生成された時点での) コードを引き換えることができる回数。</span><span class="sxs-lookup"><span data-stu-id="9a933-166">**Available**: The number of times the code is still available to redeem (at the time the file was generated).</span></span>
    -   <span data-ttu-id="9a933-167">**引き換え済み**: (ファイルが生成された時点での) コードが引き換えられた回数。</span><span class="sxs-lookup"><span data-stu-id="9a933-167">**Redeemed**: The number of times that the code has been redeemed (at the time the file was generated).</span></span>

4.  <span data-ttu-id="9a933-168">引き換え用の URL を任意の通信手段でユーザーに配布します (ターゲット通知、メール、SMS メッセージ、印刷されたカードなど)。</span><span class="sxs-lookup"><span data-stu-id="9a933-168">Distribute the redeemable URLs to your customers via any communication format you prefer (for example targeted notifications, email, SMS messages, or printed cards).</span></span> <span data-ttu-id="9a933-169">次の情報を伝えることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="9a933-169">We recommend that your communication includes the following:</span></span>
    -   <span data-ttu-id="9a933-170">どのアプリまたはアドオン用のプロモーション コードであるかについての説明と、必要に応じて、このコードがユーザーに送られた理由についての説明。</span><span class="sxs-lookup"><span data-stu-id="9a933-170">An explanation of which app or add-on the promotional code is for, and optionally a description of why the customer is receiving the code.</span></span>
    -   <span data-ttu-id="9a933-171">コードの引き換え用 URL。</span><span class="sxs-lookup"><span data-stu-id="9a933-171">The redeemable URL for the code.</span></span>
    -   <span data-ttu-id="9a933-172">ユーザーが引き換え用 URL にアクセスし、Microsoft アカウントでログインし、アプリをダウンロードしてインストールするための操作方法。</span><span class="sxs-lookup"><span data-stu-id="9a933-172">Instructions that guide the customer to visit the redeemable URL, log in using their Microsoft account, and follow the instructions to download and install your app.</span></span>

## <a name="code-redemption-user-experience"></a><span data-ttu-id="9a933-173">コード利用のユーザー エクスペリエンス</span><span class="sxs-lookup"><span data-stu-id="9a933-173">Code redemption user experience</span></span>

<span data-ttu-id="9a933-174">プロモーション コード (またはその引き換え用 URL) をユーザーに配布した後、ユーザーはその URL 使って無料で製品を入手できます。</span><span class="sxs-lookup"><span data-stu-id="9a933-174">After you distribute a promotional code (or its redeemable URL) to a customer, they can use that URL to get the product for free.</span></span> <span data-ttu-id="9a933-175">引き換え用 URL をクリックすると、認証された **[コードの適用]** ページ (<https://account.microsoft.com/billing/redeem>) が開きます。</span><span class="sxs-lookup"><span data-stu-id="9a933-175">Clicking the redeemable URL will launch an authenticated **Redeem your code** page at <https://account.microsoft.com/billing/redeem>.</span></span> <span data-ttu-id="9a933-176">このページには、ユーザーが引き換えようとしているアプリの説明が表示されます。</span><span class="sxs-lookup"><span data-stu-id="9a933-176">This page includes a description of the app the user is about to redeem.</span></span> <span data-ttu-id="9a933-177">ユーザーが Microsoft アカウントでログインしていない場合は、ログインするように求められることがあります。</span><span class="sxs-lookup"><span data-stu-id="9a933-177">If the customer is not logged in with their Microsoft account, they may be prompted to do so.</span></span> <span data-ttu-id="9a933-178">ユーザーが <https://account.microsoft.com/billing/redeem> にアクセスして、コードを直接入力することもできます。</span><span class="sxs-lookup"><span data-stu-id="9a933-178">Your customer can also visit <https://account.microsoft.com/billing/redeem> and enter the code directly.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="9a933-179">プロモーション コードをユーザーに配布するのは、(**[この製品をストアで提供しますが、検索はできないようにします]** を選択した場合でも) 製品の公開プロセスが完了した後にすることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="9a933-179">We recommend that you don't distribute promotional codes to your customers until your product has completed the publishing process (even if you have selected **Make this product available but not discoverable in the Store**).</span></span> <span data-ttu-id="9a933-180">まだ公開されていない製品のプロモーション コードをユーザーが使おうとすると、エラーが表示されます。</span><span class="sxs-lookup"><span data-stu-id="9a933-180">Customers will see an error if they try to use a promotional code for a product which hasn't been published yet.</span></span>

<span data-ttu-id="9a933-181">ユーザーが **[使用]** をクリックすると、Windows ストアでアプリの概要ページが開きます (Windows 10 または Windows 8.1 デバイスを使っている場合)。ここで **[インストール]** をクリックすると、アプリを無料でダウンロードしてインストールできます。</span><span class="sxs-lookup"><span data-stu-id="9a933-181">After the customer clicks **Redeem**, the Windows Store will open to the overview page for the app (if they are on a Windows 10 or Windows 8.1 device), where they can click **Install** to download and install the app for free.</span></span> <span data-ttu-id="9a933-182">ユーザーが Windows ストアがインストールされていないコンピューターまたはデバイスを使っている場合は、リンクから Windows ストアのアプリ用の Web ページが開きます。</span><span class="sxs-lookup"><span data-stu-id="9a933-182">If the customer is on a computer or device that does not have the Windows Store installed, the link will launch the Windows Store web page for the app.</span></span> <span data-ttu-id="9a933-183">コードはユーザーの Microsoft アカウントに適用されるため、後で Windows デバイス (同じ Microsoft アカウントに関連付けられているもの) を使って無料でアプリをダウンロードできます。</span><span class="sxs-lookup"><span data-stu-id="9a933-183">The code will be applied to the customer's Microsoft account, so they can later download the app on a Windows device (that is associated with the same Microsoft account) for free.</span></span>

> [!NOTE]
> <span data-ttu-id="9a933-184">場合によっては、プロモーション コードが正しくアプリに引き換えられたにもかかわらず、ユーザーに **[インストール]** ボタンではなく **[購入]** ボタンが表示されることがあります。</span><span class="sxs-lookup"><span data-stu-id="9a933-184">In some cases the customer may see a **Buy** button instead of **Install**, even though the app was successfully redeemed via the promotional code.</span></span> <span data-ttu-id="9a933-185">ユーザーは **[購入]** をクリックして、無料でアプリをインストールできます。</span><span class="sxs-lookup"><span data-stu-id="9a933-185">The customer can click **Buy** to install the app for no charge.</span></span>


## <a name="review-your-promotional-codes"></a><span data-ttu-id="9a933-186">プロモーション コードの確認</span><span class="sxs-lookup"><span data-stu-id="9a933-186">Review your promotional codes</span></span>

<span data-ttu-id="9a933-187">アプリとそのアドオンのプロモーション コードの注文について詳しい要約を確認するには、そのアプリの **[プロモーション コード]** ページに移動します (**[収益化]** を展開し、**[プロモーション コード]** をクリックします)。</span><span class="sxs-lookup"><span data-stu-id="9a933-187">To review a detailed summary of promotional code orders for an app and its add-ons, navigate to the **Promotional codes** page for the app (expand **Monetization** and click **Promotional codes**).</span></span> <span data-ttu-id="9a933-188">アプリのすべての有効および非アクティブなプロモーション コードについて、次の詳しい情報を確認できます。</span><span class="sxs-lookup"><span data-stu-id="9a933-188">You can review the following details for all current and inactive promotional codes for the app:</span></span>
    -   <span data-ttu-id="9a933-189">注文名</span><span class="sxs-lookup"><span data-stu-id="9a933-189">Order name</span></span>
    -   <span data-ttu-id="9a933-190">アプリまたはアドオン</span><span class="sxs-lookup"><span data-stu-id="9a933-190">App or add-on</span></span>
    -   <span data-ttu-id="9a933-191">開始日</span><span class="sxs-lookup"><span data-stu-id="9a933-191">Start date</span></span>
    -   <span data-ttu-id="9a933-192">有効期限</span><span class="sxs-lookup"><span data-stu-id="9a933-192">Expire date</span></span>
    -   <span data-ttu-id="9a933-193">利用可能</span><span class="sxs-lookup"><span data-stu-id="9a933-193">Available</span></span>
    -   <span data-ttu-id="9a933-194">引き換え済み</span><span class="sxs-lookup"><span data-stu-id="9a933-194">Redeemed</span></span>

<span data-ttu-id="9a933-195">前述のとおり、この表からアクティブな注文をダウンロードすることもできます。</span><span class="sxs-lookup"><span data-stu-id="9a933-195">You can also download an order from this table, as described above.</span></span> 

 




