---
author: PatrickFarley
ms.assetid: bf0a8b01-79f1-4944-9d78-9741e235dbe9
title: Xbox 用 Device Portal
description: Xbox One 向けの Device Portal を有効にする方法について説明します。
ms.author: pafarley
ms.date: 02/12/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, デバイス ポータル
ms.localizationpriority: medium
ms.openlocfilehash: 404db3963d2f9508d7c81053abf96b0e742103f7
ms.sourcegitcommit: 3727445c1d6374401b867c78e4ff8b07d92b7adc
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/29/2018
ms.locfileid: "2910313"
---
# <a name="device-portal-for-xbox"></a><span data-ttu-id="26136-104">Xbox 用 Device Portal</span><span class="sxs-lookup"><span data-stu-id="26136-104">Device Portal for Xbox</span></span>

## <a name="set-up-device-portal-on-xbox"></a><span data-ttu-id="26136-105">Xbox で Device Portal をセットアップする</span><span class="sxs-lookup"><span data-stu-id="26136-105">Set up Device Portal on Xbox</span></span>

<span data-ttu-id="26136-106">以下の手順では、開発用 Xbox へのリモート アクセスを提供する Xbox Device Portal を有効にする方法を示します。</span><span class="sxs-lookup"><span data-stu-id="26136-106">The following steps show how to enable the Xbox Device Portal, which gives you remote access to your development Xbox.</span></span>

1. <span data-ttu-id="26136-107">Dev Home を開きます。</span><span class="sxs-lookup"><span data-stu-id="26136-107">Open Dev Home.</span></span> <span data-ttu-id="26136-108">これは開発用 Xbox の起動時に既定で開きますが、ホーム画面からも開くこともできます。</span><span class="sxs-lookup"><span data-stu-id="26136-108">This should open by default when you boot up your development Xbox, but you can also open it from the home screen.</span></span>

    ![Device Portal の DevHome](images/device-portal-xbox-1.png)

2. <span data-ttu-id="26136-110">Dev Home 内で、**[ホーム]** タブの **[リモート アクセス]** の下で、**[リモート アクセス設定]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="26136-110">Within Dev Home, on the **Home** tab, under **Remote Access**, select **Remote Access Settings**.</span></span>

    ![Device Portal の RemoteManagement ツール](images/device-portal-xbox-15.png)

3. <span data-ttu-id="26136-112">**[Enable Xbox Device Portal]** (Xbox Device Portal を有効にする) 設定をオンにします。</span><span class="sxs-lookup"><span data-stu-id="26136-112">Check the **Enable Xbox Device Portal** setting.</span></span>

4. <span data-ttu-id="26136-113">**[認証]** で **[Set username and password]** (ユーザー名とパスワードの設定) を選択します。</span><span class="sxs-lookup"><span data-stu-id="26136-113">Under **Authentication**, select **Set username and password**.</span></span> <span data-ttu-id="26136-114">ブラウザーから dev kit へのアクセスを認証するために使う **[ユーザー名]** と **[パスワード]** を入力し、**[保存]** します。</span><span class="sxs-lookup"><span data-stu-id="26136-114">Enter a **User name** and **Password** to use to authenticate access to your dev kit from a browser, and **Save** them.</span></span>

5. <span data-ttu-id="26136-115">**[リモート アクセス]** ページの **[閉じる]** を選択し、**[ホーム]** タブの **[リモート アクセス]** の下に表示される URL を書き留めます。</span><span class="sxs-lookup"><span data-stu-id="26136-115">**Close** the **Remote Access** page and note the URL listed under **Remote Access** on the **Home** tab.</span></span>

6. <span data-ttu-id="26136-116">その URL をブラウザーに入力し、構成した資格情報でサインインします。</span><span class="sxs-lookup"><span data-stu-id="26136-116">Enter the URL in your browser, and then sign in with the credentials you configured.</span></span>

7. <span data-ttu-id="26136-117">提供された証明書に関して、次の図のような警告が表示されます。</span><span class="sxs-lookup"><span data-stu-id="26136-117">You will receive a warning about the certificate that was provided, similar to that pictured below.</span></span> <span data-ttu-id="26136-118">Edge で **[詳細]** をクリックし、**[Go on to the webpage]** (Web ページにアクセス) をクリックして、Xbox Device Portal にアクセスします。</span><span class="sxs-lookup"><span data-stu-id="26136-118">In Edge, click on **Details** and then **Go on to the webpage** to access the Xbox Device Portal.</span></span> <span data-ttu-id="26136-119">表示されるダイアログで、前に Xbox に入力したユーザー名とパスワードを入力します。</span><span class="sxs-lookup"><span data-stu-id="26136-119">In the dialog that pops up, enter the username and password that you entered previously on your Xbox.</span></span>

    ![Device Portal の証明書エラー](images/device-portal-xbox-3.png)

## <a name="device-portal-pages"></a><span data-ttu-id="26136-121">Device Portal のページ</span><span class="sxs-lookup"><span data-stu-id="26136-121">Device Portal pages</span></span>

<span data-ttu-id="26136-122">Xbox Device Portal では、Windows Device Portal で入手可能なものと同様の一連の標準的なページと共に、いくつかの固有のページが提供されます。</span><span class="sxs-lookup"><span data-stu-id="26136-122">The Xbox Device Portal provides a set of standard pages similar to what's available on the Windows Device Portal, as well as several pages that are unique.</span></span> <span data-ttu-id="26136-123">標準的なページについて詳しくは、「[Windows Device Portal の概要](device-portal.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="26136-123">For detailed descriptions of the former, see [Windows Device Portal overview](device-portal.md).</span></span> <span data-ttu-id="26136-124">以下のセクションでは、Xbox Device Portal に固有のページについて説明します。</span><span class="sxs-lookup"><span data-stu-id="26136-124">The following sections describe the pages that are unique to the Xbox Device Portal.</span></span>

### <a name="home"></a><span data-ttu-id="26136-125">ホーム</span><span class="sxs-lookup"><span data-stu-id="26136-125">Home</span></span>

<span data-ttu-id="26136-126">Windows Device Portal の **[アプリ マネージャー]** ページと同様に、Xbox Device Portal の **[ホーム]** ページでは、**[マイ コレクション]** の下にインストールされているゲームとアプリの一覧が表示されます。</span><span class="sxs-lookup"><span data-stu-id="26136-126">Similar to the Windows Device Portal's **Apps manager** page, the Xbox Device Portal's **Home** page displays a list of installed games and apps under **My games & apps**.</span></span> <span data-ttu-id="26136-127">ゲームまたはアプリの名前をクリックして、その詳細を表示できます (**[パッケージ ファミリ名]** など)。</span><span class="sxs-lookup"><span data-stu-id="26136-127">You can click on the name of a game or app to see more details about it, such as the **Package family name**.</span></span> <span data-ttu-id="26136-128">**[操作]** ドロップダウンで、ゲームまたはアプリに対して **[起動]** などの操作を行うことができます。</span><span class="sxs-lookup"><span data-stu-id="26136-128">In the **Actions** drop down, you can take action on the game or app, such as **Launch** it.</span></span>

<span data-ttu-id="26136-129">**[Xbox Live テスト アカウント]** で、お使いの Xbox に関連付けられているアカウントを管理することができます。</span><span class="sxs-lookup"><span data-stu-id="26136-129">Under **Xbox Live test accounts**, you can manage the accounts associated with your Xbox.</span></span> <span data-ttu-id="26136-130">ユーザーとゲスト アカウントの追加、新しいユーザーの作成、ユーザーのサインインとサインアウト、アカウントの削除を行うことができます。</span><span class="sxs-lookup"><span data-stu-id="26136-130">You can add users and guest accounts, create new users, sign users in and out, and remove accounts.</span></span>

![ホーム](images/device-portal-xbox-16.png)

### <a name="xbox-live-game-saves"></a><span data-ttu-id="26136-132">Xbox Live (セーブ データ)</span><span class="sxs-lookup"><span data-stu-id="26136-132">Xbox Live (Game saves)</span></span>

<span data-ttu-id="26136-133">Windows Device Portal と Xbox Device Portal のいずれにも **[Xbox Live]** ページがあります。</span><span class="sxs-lookup"><span data-stu-id="26136-133">Both the Windows Device Portal and the Xbox Device Portal have an **Xbox Live** page.</span></span> <span data-ttu-id="26136-134">ただし、Xbox Device Portal には独自のセクション、**[Xbox Live セーブ データ]** があります。このセクションで、Xbox にインストールされているゲームのデータを保存することができます。</span><span class="sxs-lookup"><span data-stu-id="26136-134">However, the Xbox Device Portal has a unique section, **Xbox Live game saves**, where you can save data for games installed on your Xbox.</span></span> <span data-ttu-id="26136-135">タイトルとセーブ データに関連付けられた **[サービス構成 ID (SCID)]** (詳しくは、「[Xbox Live サービス構成](../xbox-live/xbox-live-service-configuration.md#get-your-ids)」を参照)、**[メンバー名 (MSA)]**、および **[パッケージ ファミリ名 (PFN)]** を入力し、**[入力ファイル (.json または .xml)]** を参照して、セーブ データを操作するためにいずれかのボタン (**[リセット]**、**[インポート]**、**[エクスポート]**、**[削除]**) を選択します。</span><span class="sxs-lookup"><span data-stu-id="26136-135">Enter the **Service Configuration ID (SCID)** (see [Xbox Live service configuration](../xbox-live/xbox-live-service-configuration.md#get-your-ids) for more information), **Membername (MSA)**, and **Package Family Name (PFN)** associated with the title and game save, browse for the **Input File (.json or .xml)**, and then select one of the buttons (**Reset**, **Import**, **Export**, and **Delete**) to manipulate the save data.</span></span>

<span data-ttu-id="26136-136">**[生成]** セクションで、ダミー データを生成し、指定した入力ファイルに保存できます。</span><span class="sxs-lookup"><span data-stu-id="26136-136">In the **Generate** section, you can generate dummy data and save to the specified input file.</span></span> <span data-ttu-id="26136-137">**[コンテナー (既定値は 2)]**、**[BLOB (既定値は 3)]**、および **[BLOB サイズ (既定値は 1024)]** を入力し、**[生成]** を選択するだけです。</span><span class="sxs-lookup"><span data-stu-id="26136-137">Simply enter the **Containers (default 2)**, **Blobs (default 3)**, and **Blob Size (default 1024)**, and select **Generate**.</span></span>

![Xbox Live](images/device-portal-xbox-17.png)

### <a name="http-monitor"></a><span data-ttu-id="26136-139">HTTP モニター</span><span class="sxs-lookup"><span data-stu-id="26136-139">HTTP monitor</span></span>

<span data-ttu-id="26136-140">HTTP モニターを使うと、アプリやゲームが Xbox One で実行されているときに、それらからの暗号化が解除された HTTP および HTTPS トラフィックを表示することができます。</span><span class="sxs-lookup"><span data-stu-id="26136-140">The HTTP Monitor allows you to view decrypted HTTP and HTTPS traffic from your app or game when it's running on your Xbox One.</span></span>

![HTTP モニター](images/device-portal-xbox-18.png)

<span data-ttu-id="26136-142">有効にするには、Xbox One で Dev Home を開き、**[設定]** タブに移動して、**[HTTP Monitor Settings]** (HTTP モニターの設定) で **[Enable HTTP Monitor]** (HTTP モニターを有効にする) をオンにします。</span><span class="sxs-lookup"><span data-stu-id="26136-142">To enable it, open Dev Home on your Xbox One, go to the **Settings** tab, and in the **HTTP Monitor Settings** box, check **Enable HTTP Monitor**.</span></span>

![Dev Home: ネットワーキング](images/device-portal-xbox-14.png)

<span data-ttu-id="26136-144">有効にすると、Xbox Device Portal でそれぞれのボタンを選択することで、HTTP および HTTPS トラフィックを **[停止]**、**[クリア]**、および **[ファイルに保存]** することができます。</span><span class="sxs-lookup"><span data-stu-id="26136-144">Once enabled, in the Xbox Device Portal, you can **Stop**, **Clear**, and **Save to file** HTTP and HTTPS traffic by selecting the respective buttons.</span></span>

### <a name="network-fiddler-tracing"></a><span data-ttu-id="26136-145">ネットワーク (Fiddler のトレース)</span><span class="sxs-lookup"><span data-stu-id="26136-145">Network (Fiddler tracing)</span></span>

<span data-ttu-id="26136-146">Xbox Device Portal の **[ネットワーク]** ページは Windows Device Portal の **[ネットワーク]** ページとほぼ同じですが、**[Fiddler のトレース]** は例外で、Xbox Device Portal に固有のものです。</span><span class="sxs-lookup"><span data-stu-id="26136-146">The **Network** page in the Xbox Device Portal is almost identical to the **Networking** page in the Windows Device Portal, with the exception of **Fiddler tracing**, which is unique to the Xbox Device Portal.</span></span> <span data-ttu-id="26136-147">これにより、PC で Fiddler を実行して、Xbox One とインターネットの間の HTTP および HTTPS トラフィックログに記録し、検査することができます。</span><span class="sxs-lookup"><span data-stu-id="26136-147">This allows you to run Fiddler on your PC to log and inspect HTTP and HTTPS traffic between your Xbox One and the internet.</span></span> <span data-ttu-id="26136-148">詳しくは、「[UWP を開発するときに、Xbox One で Fiddler を使用する方法](../xbox-apps/uwp-fiddler.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="26136-148">See [How to use Fiddler with Xbox One when developing for UWP](../xbox-apps/uwp-fiddler.md) for more information.</span></span>

![ネットワーク](images/device-portal-xbox-19.png)

### <a name="media-capture"></a><span data-ttu-id="26136-150">メディアのキャプチャ</span><span class="sxs-lookup"><span data-stu-id="26136-150">Media capture</span></span>

<span data-ttu-id="26136-151">**[メディアのキャプチャ]** ページで、**[スクリーンショットをキャプチャする]** を選択して Xbox One のスクリーン ショットを撮ることができます。</span><span class="sxs-lookup"><span data-stu-id="26136-151">On the **Media capture** page, you can select **Capture Screenshot** to take a screenshot of your Xbox One.</span></span> <span data-ttu-id="26136-152">撮影すると、ファイルをダウンロードするよう求められます。</span><span class="sxs-lookup"><span data-stu-id="26136-152">Once you do, your browser will prompt you to download the file.</span></span> <span data-ttu-id="26136-153">HDR でスクリーン ショットを撮る場合は (本体でサポートされている場合)、**[Prefer HDR]** (HDR 優先) をオンにできます。</span><span class="sxs-lookup"><span data-stu-id="26136-153">You can check **Prefer HDR** if you want to take the screenshot in HDR (if the console supports it).</span></span>

![メディアのキャプチャ](images/device-portal-xbox-12.png)

### <a name="settings"></a><span data-ttu-id="26136-155">設定</span><span class="sxs-lookup"><span data-stu-id="26136-155">Settings</span></span>

<span data-ttu-id="26136-156">**[設定]** ページで、Xbox One のいくつかの設定を表示および編集することができます。</span><span class="sxs-lookup"><span data-stu-id="26136-156">On the **Settings** page, you can view and edit several settings for your Xbox One.</span></span> <span data-ttu-id="26136-157">上部で、**[インポート]** を選択してファイルから設定をインポートし、**[エクスポート]** を選択して現在の設定を .txt ファイルにエクスポートすることができます。</span><span class="sxs-lookup"><span data-stu-id="26136-157">At the top, you can select **Import** to import settings from a file and **Export** to export the current settings to a .txt file.</span></span> <span data-ttu-id="26136-158">設定をインポートすると、一括編集が簡単になり、特に複数の本体を構成するときに役に立ちます。</span><span class="sxs-lookup"><span data-stu-id="26136-158">Importing settings can make bulk editing easier, especially when configuring multiple consoles.</span></span> <span data-ttu-id="26136-159">インポートする設定ファイルを作成するには、必要に応じて設定を変更してから、設定をエクスポートします。</span><span class="sxs-lookup"><span data-stu-id="26136-159">To create a settings file to import, change the settings to how you want them to be, and then export the settings.</span></span> <span data-ttu-id="26136-160">その後、このファイルを使用して、他の本体用に設定を迅速かつ簡単にインポートすることができます。</span><span class="sxs-lookup"><span data-stu-id="26136-160">Then you can use this file to import settings quickly and easily for other consoles.</span></span>

<span data-ttu-id="26136-161">さまざまな設定があり、表示/編集するためのセクションがいくつかあります。これらについて以下で説明します。</span><span class="sxs-lookup"><span data-stu-id="26136-161">There are several sections with different settings to view and/or edit, which are explained below.</span></span>

![設定](images/device-portal-xbox-20.png)

![設定](images/device-portal-xbox-21.png)

#### <a name="device-information"></a><span data-ttu-id="26136-164">デバイス情報</span><span class="sxs-lookup"><span data-stu-id="26136-164">Device Information</span></span>

* <span data-ttu-id="26136-165">**デバイス名**: デバイスの名前。</span><span class="sxs-lookup"><span data-stu-id="26136-165">**Device name**: The name of the device.</span></span> <span data-ttu-id="26136-166">編集するには、ボックス内で名前を変更し、**[保存]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="26136-166">To edit, change the name in the box and select **Save**.</span></span>

* <span data-ttu-id="26136-167">**OS バージョン**: 読み取り専用。</span><span class="sxs-lookup"><span data-stu-id="26136-167">**OS version**: Read-only.</span></span> <span data-ttu-id="26136-168">オペレーティング システムのバージョン番号。</span><span class="sxs-lookup"><span data-stu-id="26136-168">The version number of the operating system.</span></span>

* <span data-ttu-id="26136-169">**OS エディション**: 読み取り専用。</span><span class="sxs-lookup"><span data-stu-id="26136-169">**OS edition**: Read-only.</span></span> <span data-ttu-id="26136-170">オペレーティング システムのメジャー リリースの名前。</span><span class="sxs-lookup"><span data-stu-id="26136-170">The name of the major release of the operating system.</span></span>

* <span data-ttu-id="26136-171">**Xbox Live デバイス ID**: 読み取り専用。</span><span class="sxs-lookup"><span data-stu-id="26136-171">**Xbox Live device ID**: Read-only.</span></span>

* <span data-ttu-id="26136-172">**本体の ID**: 読み取り専用。</span><span class="sxs-lookup"><span data-stu-id="26136-172">**Console ID**: Read-only.</span></span>

* <span data-ttu-id="26136-173">**シリアル番号**: 読み取り専用。</span><span class="sxs-lookup"><span data-stu-id="26136-173">**Serial number**: Read-only.</span></span>

* <span data-ttu-id="26136-174">**本体の種類**: 読み取り専用。</span><span class="sxs-lookup"><span data-stu-id="26136-174">**Console Type**: Read-only.</span></span> <span data-ttu-id="26136-175">Xbox One デバイスの種類 (Xbox One、Xbox One S、または Xbox One X)。</span><span class="sxs-lookup"><span data-stu-id="26136-175">The type of Xbox One device (Xbox One, Xbox One S, or Xbox One X).</span></span>

* <span data-ttu-id="26136-176">**開発モード**: 読み取り専用。</span><span class="sxs-lookup"><span data-stu-id="26136-176">**Dev Mode**: Read-only.</span></span> <span data-ttu-id="26136-177">デバイスに適用されている開発者モード。</span><span class="sxs-lookup"><span data-stu-id="26136-177">The developer mode that the device is in.</span></span>

#### <a name="audio-settings"></a><span data-ttu-id="26136-178">オーディオ設定</span><span class="sxs-lookup"><span data-stu-id="26136-178">Audio Settings</span></span>

* <span data-ttu-id="26136-179">**オーディオ ビットストリーム形式**: オーディオ データの形式。</span><span class="sxs-lookup"><span data-stu-id="26136-179">**Audio bitstream format**: The format of the audio data.</span></span>

* <span data-ttu-id="26136-180">**HDMI オーディオ**: HDMI ポートを経由するオーディオの種類。</span><span class="sxs-lookup"><span data-stu-id="26136-180">**HDMI audio**: The type of audio through the HDMI port.</span></span>

* <span data-ttu-id="26136-181">**ヘッドセット形式**: ヘッドフォンを経由するオーディオの形式。</span><span class="sxs-lookup"><span data-stu-id="26136-181">**Headset format**: The format of the audio that comes through headphones.</span></span>

* <span data-ttu-id="26136-182">**光デジタル オーディオ**: 光ポートを経由するオーディオの種類。</span><span class="sxs-lookup"><span data-stu-id="26136-182">**Optical audio**: The type of audio through the optical port.</span></span>

* <span data-ttu-id="26136-183">**Use HDMI or optical audio headset** (HDMI または光デジタル オーディオ ヘッドセットを使用する): HDMI 経由または光経由で接続されたヘッドセットを使用している場合、このボックスをオンにします。</span><span class="sxs-lookup"><span data-stu-id="26136-183">**Use HDMI or optical audio headset**: Check this box if you are using a headset connected via HDMI or optical.</span></span>

#### <a name="display-settings"></a><span data-ttu-id="26136-184">ディスプレイの設定</span><span class="sxs-lookup"><span data-stu-id="26136-184">Display Settings</span></span>

* <span data-ttu-id="26136-185">**色深度**: 単一ピクセルの各カラー成分で使用されるビット数。</span><span class="sxs-lookup"><span data-stu-id="26136-185">**Color depth**: The number of bits used for each color component of a single pixel.</span></span>

* <span data-ttu-id="26136-186">**色空間**: ディスプレイで使用可能な色域。</span><span class="sxs-lookup"><span data-stu-id="26136-186">**Color space**: The color gamut available to the display.</span></span>

* <span data-ttu-id="26136-187">**ディスプレイの解像度**: ディスプレイの解像度。</span><span class="sxs-lookup"><span data-stu-id="26136-187">**Display resolution**: The resolution of the display.</span></span>

* <span data-ttu-id="26136-188">**Display connection** (ディスプレイの接続): ディスプレイへの接続の種類。</span><span class="sxs-lookup"><span data-stu-id="26136-188">**Display connection**: The type of connection to the display.</span></span>

* <span data-ttu-id="26136-189">**Allow high dynamic range (HDR)** (ハイ ダイナミック レンジ (HDR) を使用する): ディスプレイで HDR を有効にします。</span><span class="sxs-lookup"><span data-stu-id="26136-189">**Allow high dynamic range (HDR)**: Enables HDR on the display.</span></span> <span data-ttu-id="26136-190">互換性のあるディスプレイでのみ使用できます。</span><span class="sxs-lookup"><span data-stu-id="26136-190">Only available to compatible displays.</span></span>

* <span data-ttu-id="26136-191">**4K を許可**: ディスプレイで 4K 解像度を有効にします。</span><span class="sxs-lookup"><span data-stu-id="26136-191">**Allow 4K**: Enables 4K resolution on the display.</span></span> <span data-ttu-id="26136-192">互換性のあるディスプレイでのみ使用できます。</span><span class="sxs-lookup"><span data-stu-id="26136-192">Only available to compatible displays.</span></span>

* <span data-ttu-id="26136-193">**Allow Variable Refresh Rate (VRR)** (可変リフレッシュ レート (VRR) を許可する): ディスプレイで VRR を有効にします。</span><span class="sxs-lookup"><span data-stu-id="26136-193">**Allow Variable Refresh Rate (VRR)**: Enable VRR on the display.</span></span> <span data-ttu-id="26136-194">互換性のあるディスプレイでのみ使用できます。</span><span class="sxs-lookup"><span data-stu-id="26136-194">Only available to compatible displays.</span></span>

#### <a name="kinect-settings"></a><span data-ttu-id="26136-195">Kinect の管理</span><span class="sxs-lookup"><span data-stu-id="26136-195">Kinect Settings</span></span>

<span data-ttu-id="26136-196">これらの設定を変更するために、Kinect センサーは本体に接続されている必要があります。</span><span class="sxs-lookup"><span data-stu-id="26136-196">A Kinect sensor must be connected to the console in order to change these settings.</span></span>

* <span data-ttu-id="26136-197">**Enable Kinect** (Kinect を有効にする): 接続されている Kinect センサーを有効にします。</span><span class="sxs-lookup"><span data-stu-id="26136-197">**Enable Kinect**: Enable the attached Kinect sensor.</span></span>

* <span data-ttu-id="26136-198">**Force Kinect reload on app change** (アプリの変更時に Kinect の再読み込みを強制する): 別のアプリやゲームが実行されるたびに、接続されている Kinect センサーを再読み込みします。</span><span class="sxs-lookup"><span data-stu-id="26136-198">**Force Kinect reload on app change**: Reload the attached Kinect sensor whenever a different app or game is run.</span></span>

#### <a name="localization-settings"></a><span data-ttu-id="26136-199">ローカライズ設定</span><span class="sxs-lookup"><span data-stu-id="26136-199">Localization Settings</span></span>

* <span data-ttu-id="26136-200">**Geographic region** (地理的領域): デバイスに設定されている地域。</span><span class="sxs-lookup"><span data-stu-id="26136-200">**Geographic region**: The geographic region that the device is set to.</span></span> <span data-ttu-id="26136-201">特定の 2 文字の国コードである必要があります (たとえば、米国の場合は **US**)。</span><span class="sxs-lookup"><span data-stu-id="26136-201">Must be the specific 2-character country code (for example, **US** for United States).</span></span>

* <span data-ttu-id="26136-202">**優先言語**: デバイスに設定されている言語。</span><span class="sxs-lookup"><span data-stu-id="26136-202">**Preferred language(s)**: The language that the device is set to.</span></span>

* <span data-ttu-id="26136-203">**タイム ゾーン**: デバイスに設定されているタイム ゾーン。</span><span class="sxs-lookup"><span data-stu-id="26136-203">**Time zone**: The time zone that the device is set to.</span></span>

#### <a name="network-settings"></a><span data-ttu-id="26136-204">ネットワーク設定</span><span class="sxs-lookup"><span data-stu-id="26136-204">Network Settings</span></span>

* <span data-ttu-id="26136-205">**Wireless radio settings** (ワイヤレス無線の設定): デバイスのワイヤレス設定 (ワイヤレス LAN などの特定の要素はオンかオフか)。</span><span class="sxs-lookup"><span data-stu-id="26136-205">**Wireless radio settings**: The wireless settings of the device (whether certain aspects such as wireless LAN are on or off).</span></span>

#### <a name="power-settings"></a><span data-ttu-id="26136-206">電源設定</span><span class="sxs-lookup"><span data-stu-id="26136-206">Power Settings</span></span>

* <span data-ttu-id="26136-207">**When idle, dim screen after (minutes)** (アイドル時、次の時間 (分) が経過後に画面を暗くする): アイドル状態でこの時間が経過後、画面が暗くなります。</span><span class="sxs-lookup"><span data-stu-id="26136-207">**When idle, dim screen after (minutes)**: The screen will dim after the device has been idle for this amount of time.</span></span> <span data-ttu-id="26136-208">画面を暗くしない場合は、**0** に設定します。</span><span class="sxs-lookup"><span data-stu-id="26136-208">Set to **0** to never dim the screen.</span></span>

* <span data-ttu-id="26136-209">**When idle, turn off after** (アイドル時、次の時間が経過後に電源を切る): アイドル状態でこの時間が経過後、デバイスをシャット ダウンします。</span><span class="sxs-lookup"><span data-stu-id="26136-209">**When idle, turn off after**: The device will shut down after it has been idle for this amount of time.</span></span>

* <span data-ttu-id="26136-210">**電源モード**: デバイスの電源モード。</span><span class="sxs-lookup"><span data-stu-id="26136-210">**Power mode**: The power mode of the device.</span></span> <span data-ttu-id="26136-211">詳しくは、「[省電力モードとクイック起動電源モードについて](http://support.xbox.com/xbox-one/console/learn-about-power-modes)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="26136-211">See [About energy-saving and instant-on power modes](http://support.xbox.com/xbox-one/console/learn-about-power-modes) for more information.</span></span>

* <span data-ttu-id="26136-212">**Automatically boot console when connected to power** (電源に接続されたときに本体を自動的に起動): 電源に接続されると、デバイスが自動的にオンになります。</span><span class="sxs-lookup"><span data-stu-id="26136-212">**Automatically boot console when connected to power**: The device will automatically turn on when it is connected to a power source.</span></span>

#### <a name="preference-settings"></a><span data-ttu-id="26136-213">基本設定</span><span class="sxs-lookup"><span data-stu-id="26136-213">Preference Settings</span></span>

* <span data-ttu-id="26136-214">**既定のホーム エクスペリエンス**: デバイスがオンになったときに表示されるホーム画面を設定します。</span><span class="sxs-lookup"><span data-stu-id="26136-214">**Default home experience**: Sets which home screen appears when the device is turned on.</span></span>

* <span data-ttu-id="26136-215">**Xbox アプリからの接続を許可**: Windows 10 PC など、別のデバイス上の Xbox アプリがこの本体に接続できます。</span><span class="sxs-lookup"><span data-stu-id="26136-215">**Allow connections from the Xbox app**: The Xbox app on another device (such as a Windows 10 PC) can connect to this console.</span></span>

* <span data-ttu-id="26136-216">**Treat UWP apps as games by default** (既定で UWP アプリをゲームとして扱う): ゲームやアプリが、Xbox で割り当てられたさまざまなリソースを取得します。</span><span class="sxs-lookup"><span data-stu-id="26136-216">**Treat UWP apps as games by default**: Games and apps get different resources allocated to them on Xbox.</span></span> <span data-ttu-id="26136-217">このボックスをオンにすると、すべての UWP パッケージはゲームとして識別され、より多くのリソースを取得します。</span><span class="sxs-lookup"><span data-stu-id="26136-217">If you check this box, all UWP packages will be identified as games and thus will get more resources.</span></span>

#### <a name="user-settings"></a><span data-ttu-id="26136-218">ユーザー設定</span><span class="sxs-lookup"><span data-stu-id="26136-218">User Settings</span></span>

* <span data-ttu-id="26136-219">**Auto sign in user** (自動サインイン ユーザー): デバイスがオンになったとき、選択されたユーザーに自動的にサインインします。</span><span class="sxs-lookup"><span data-stu-id="26136-219">**Auto sign in user**: Automatically signs in the selected user when the device is turned on.</span></span>

* <span data-ttu-id="26136-220">**Auto sign in user controller** (自動サインイン ユーザー コントローラー): 特定のコントローラーの種類を、自動的に特定のユーザーと関連付けます。</span><span class="sxs-lookup"><span data-stu-id="26136-220">**Auto sign in user controller**: Automatically associates a particular controller type with a particular user.</span></span>

#### <a name="xbox-live-sandbox"></a><span data-ttu-id="26136-221">Xbox Live のサンドボックス</span><span class="sxs-lookup"><span data-stu-id="26136-221">Xbox Live Sandbox</span></span>

<span data-ttu-id="26136-222">ここで、デバイスに適用する Xbox Live サンド ボックスを変更できます。</span><span class="sxs-lookup"><span data-stu-id="26136-222">Here you can change the Xbox Live sandbox that the device is in.</span></span> <span data-ttu-id="26136-223">ボックスにサンドボックスの名前を入力し、**[変更]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="26136-223">Enter the name of the sandbox in the box, and select **Change**.</span></span>

### <a name="scratch"></a><span data-ttu-id="26136-224">スクラッチ</span><span class="sxs-lookup"><span data-stu-id="26136-224">Scratch</span></span>

<span data-ttu-id="26136-225">これは空のワークスペースで、自由にカスタマイズすることができます。</span><span class="sxs-lookup"><span data-stu-id="26136-225">This is a blank workspace, which you can customize to your liking.</span></span> <span data-ttu-id="26136-226">メニューを使用して (左上にあるメニュー ボタンをクリックします)、ツールを追加することができます (**[Add tools to workspace]** (ワークスペースにツールを追加する) を選択して、追加するツールを選択し、**[追加]** を選択します)。</span><span class="sxs-lookup"><span data-stu-id="26136-226">You can use the menu (click the menu button at the top left) to add tools (select **Add tools to workspace**, then the tools that you want to add, then **Add**).</span></span> <span data-ttu-id="26136-227">このメニューを使用すると、任意のワークスペースにツールを追加すると共に、ワークスペース自体を管理することもできます。</span><span class="sxs-lookup"><span data-stu-id="26136-227">Note that you can use this menu to add tools to any workspace, as well as manage the workspaces themselves.</span></span>

![ワークスペースにツールを追加する](images/device-portal-xbox-13.png)

### <a name="game-event-data"></a><span data-ttu-id="26136-229">ゲーム イベント データ</span><span class="sxs-lookup"><span data-stu-id="26136-229">Game event data</span></span>

<span data-ttu-id="26136-230">**ゲーム イベントのデータ**ページで、できますグラフを表示するリアルタイムそのストリームでは現在、Xbox One で記録されているイベント Windows トレーシング (ETW) ゲームのイベントの数。</span><span class="sxs-lookup"><span data-stu-id="26136-230">On the **Game event data** page, you can view a realtime graph that streams in the number of Event Tracing for Windows (ETW) game events currently recorded on your Xbox One.</span></span> <span data-ttu-id="26136-231">(イベント名、イベントの発生、およびゲーム タイトル) の詳細を表示できますも、システムで記録されているゲームのイベントがある場合は、データ グラフの下のデータ テーブル内の各イベントを説明します。</span><span class="sxs-lookup"><span data-stu-id="26136-231">If there are game events recorded on the system, you can also view details (event name, event occurrence, and the game title) describing each event in a data table below the data graph.</span></span> <span data-ttu-id="26136-232">テーブルには、記録されたイベントがある場合は、できるだけです。</span><span class="sxs-lookup"><span data-stu-id="26136-232">The table is only available if there are events recorded.</span></span>

![ゲーム イベント データ](images/device-portal-xbox-22.PNG)

## <a name="see-also"></a><span data-ttu-id="26136-234">関連項目</span><span class="sxs-lookup"><span data-stu-id="26136-234">See also</span></span>

* [<span data-ttu-id="26136-235">Windows Device Portal の概要</span><span class="sxs-lookup"><span data-stu-id="26136-235">Windows Device Portal overview</span></span>](device-portal.md)
* [<span data-ttu-id="26136-236">デバイス ポータル コア API リファレンス</span><span class="sxs-lookup"><span data-stu-id="26136-236">Device Portal core API reference</span></span>](https://docs.microsoft.com/windows/uwp/debug-test-perf/device-portal-api-core)