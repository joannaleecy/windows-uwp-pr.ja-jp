---
title: Web サービス
description: アプリの Web サービスを作成する方法について説明します
ms.assetid: ''
ms.date: 06-04-2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: xbox live、xbox、ゲーム、uwp、windows 10、1 つ xbox、web サービス
ms.openlocfilehash: 66668336e3575201b305e6ecf09b4f277d2fc7b3
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57600017"
---
# <a name="set-up-web-services-in-udc"></a><span data-ttu-id="3ca27-104">UDC で Web サービスを設定します。</span><span class="sxs-lookup"><span data-stu-id="3ca27-104">Set up Web Services in UDC</span></span>

> [!WARNING]
> <span data-ttu-id="3ca27-105">次の記事は、ID@Xboxおよび管理されたパートナーの開発者向け Web サービスの構成制限によるもののみです。</span><span class="sxs-lookup"><span data-stu-id="3ca27-105">The following article is for ID@Xbox and Managed Partner developers only due to restrictions placed on Web Service configuration.</span></span> <span data-ttu-id="3ca27-106">Web サービスの構成は、証明書利用者アカウント レベル権限が付与では開発者が利用できるのみ。</span><span class="sxs-lookup"><span data-stu-id="3ca27-106">Web Services configuration is only available to developers with the Relying Parties account level permission granted.</span></span> <span data-ttu-id="3ca27-107">アカウント レベルのアクセス許可の制御がない場合は、開発アカウント マネージャー (ダム) に問い合わせてしてください。</span><span class="sxs-lookup"><span data-stu-id="3ca27-107">If you do not have control of your account level permissions contact your Development Account Manager (DAM) for assistance.</span></span>

<span data-ttu-id="3ca27-108">発行元は、アプリ/タイトルが Xbox Live サービスと対話する方法をカスタマイズする場合は、Web サービスを作成できます。</span><span class="sxs-lookup"><span data-stu-id="3ca27-108">Publishers can create Web Services if they want to customize the way their apps/titles interact with Xbox Live services.</span></span> <span data-ttu-id="3ca27-109">Web サービスは、パブリッシャー レベルの構成し、任意のタイトルでシングル サインオンを構成して、発行者が所有するサンド ボックス内で呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="3ca27-109">Web Services are publisher-level configurations and can be called by any title within a sandbox owned by the publisher by configuring single sign-on.</span></span>

<span data-ttu-id="3ca27-110">Web サービスを定義する理由があります。</span><span class="sxs-lookup"><span data-stu-id="3ca27-110">Reasons to define Web Services:</span></span>

1. <span data-ttu-id="3ca27-111">ユーザーの Xbox Live、Xbox Live のユーザーにシングル サインオンを提供する web サービスの順序でのシングル サインオンを提供すること、Xbox Live の証明書利用者として構成が必要です。</span><span class="sxs-lookup"><span data-stu-id="3ca27-111">Providing single sign-on to Xbox Live users - In order for your web service to provide single-sign-on to Xbox Live users, it needs to be configured as a relying party of Xbox Live.</span></span> <span data-ttu-id="3ca27-112">その方法を構成すると Xbox Live に認証されたユーザーは自動的に認証されます、サービスに異なる一連の資格情報を再入力しなくても。</span><span class="sxs-lookup"><span data-stu-id="3ca27-112">When configured that way, users who are authenticated to Xbox Live will automatically be authenticated to your service without having to re-enter a different set of credentials.</span></span>
2. <span data-ttu-id="3ca27-113">製品は、Xbox Live サービスを呼び出すことに、web サービスのいずれかを使用する場合は、Xbox Live サービス - サービスからサービス間呼び出しを実行すること、直接、または個々 のユーザーに代わって必要があります、ビジネス パートナーの証明書。</span><span class="sxs-lookup"><span data-stu-id="3ca27-113">Making service to service calls from your service to Xbox Live services - If your product will use one of your web services to make calls to an Xbox Live service, either directly or on behalf of individual users, you'll need a business partner certificate.</span></span>

1. ## <a name="create-a-web-service"></a><span data-ttu-id="3ca27-114">Web サービスを作成します。</span><span class="sxs-lookup"><span data-stu-id="3ca27-114">Create a Web Service</span></span>

1. <span data-ttu-id="3ca27-115">移動して、[パートナー センター ダッシュ ボード](https://partner.microsoft.com/dashboard/windows/overview)</span><span class="sxs-lookup"><span data-stu-id="3ca27-115">Go to the [Partner Center Dashboard](https://partner.microsoft.com/dashboard/windows/overview)</span></span>  
2. <span data-ttu-id="3ca27-116">アクセスするページの右上隅にある歯車の形のアイコンをクリックして、**設定**ドロップダウンします。</span><span class="sxs-lookup"><span data-stu-id="3ca27-116">Click on the gear shaped icon at the top right corner of the page to access the **Settings** dropdown.</span></span>
3. <span data-ttu-id="3ca27-117">ドロップダウン リストで選択**開発者設定が**します。</span><span class="sxs-lookup"><span data-stu-id="3ca27-117">Within the dropdown, select **Developer Settings**.</span></span>
4. <span data-ttu-id="3ca27-118">左側のナビゲーション バーで、オプションを展開**Xbox Live**選択と**Web Services**します。</span><span class="sxs-lookup"><span data-stu-id="3ca27-118">On the left-side navigation bar, expand the option **Xbox Live** and select **Web Services**.</span></span>

![<span data-ttu-id="3ca27-119">web サービスの gif</span><span class="sxs-lookup"><span data-stu-id="3ca27-119">web services gif</span></span> ](../../images/dev-center/web-services/web-services.gif)

5. <span data-ttu-id="3ca27-120">Web サービス ページで、クリックして**新しい Web サービス**します。</span><span class="sxs-lookup"><span data-stu-id="3ca27-120">In the Web Services page, click on **New Web Service**.</span></span>
6. <span data-ttu-id="3ca27-121">Web サービスの名前を入力し、必要に応じてアクセスの種類を選択します。</span><span class="sxs-lookup"><span data-stu-id="3ca27-121">Enter the Web Service Name and choose the access type as required.</span></span>  
    * <span data-ttu-id="3ca27-122">テレメトリへのアクセスにより、ゲームのいずれかのゲームのテレメトリ データを取得するサービスです。</span><span class="sxs-lookup"><span data-stu-id="3ca27-122">Telemetry access enables your service to retrieve game telemetry data for any of your games.</span></span>
    * <span data-ttu-id="3ca27-123">アプリケーション チャネル アクセスは、プログラムで oneguide などひねりをコンソールでの利用のチャネルのアプリを発行する機関のサービスを所有しているメディアのプロバイダーを使用します。</span><span class="sxs-lookup"><span data-stu-id="3ca27-123">App Channel access gives the media provider owning the service the authority to programmatically publish app channels for consumption on console through the OneGuide twist.</span></span>
7. <span data-ttu-id="3ca27-124">**[保存]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="3ca27-124">Click **Save**</span></span>

<span data-ttu-id="3ca27-125">この時点では、サービスを定義して、Xbox Live は、サービスの存在を認識します。</span><span class="sxs-lookup"><span data-stu-id="3ca27-125">At this point, you have defined the service and Xbox Live is aware of the existence of the service.</span></span> <span data-ttu-id="3ca27-126">Web サービスを作成するための理由から、によっては、証明書利用者 Parties(Single Sing-On) またはビジネス パートナー Certificates(Service-to-service calls) 構成が要求します。</span><span class="sxs-lookup"><span data-stu-id="3ca27-126">Depending on the reasons for creating the web service, you will be required to configure Relying Parties(Single Sing-On) or Business Partner Certificates(Service-to-service calls).</span></span>  

## <a name="configure-relying-party"></a><span data-ttu-id="3ca27-127">証明書利用者を構成します。</span><span class="sxs-lookup"><span data-stu-id="3ca27-127">Configure Relying Party</span></span>

<span data-ttu-id="3ca27-128">Web サービスは、Xbox の証明書利用者が Xbox Live のユーザーにシングル サインオン エクスペリエンスを提供するためにライブ – Xbox Live に認証されたユーザーは自動的に認証を web サービスを再入力しなくても同様に構成する必要があります、異なる資格情報セット。</span><span class="sxs-lookup"><span data-stu-id="3ca27-128">A web service needs to be configured as a relying party of Xbox live in order to provide the Single Sign-On experience to Xbox Live users – users who are authenticated to Xbox Live will be automatically authenticated to the web service without having to re-enter a different set of credentials.</span></span> <span data-ttu-id="3ca27-129">そのため、Xbox のサービスと web サービス間で信頼を確立する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3ca27-129">To facilitate this, trust must be established between Xbox services and the web service.</span></span> <span data-ttu-id="3ca27-130">一連の (ゲーマータグ、デバイスの種類、タイトル ID) などの要求は、この信頼を強制する証明書利用者のパーティの構成の一部として使用されます。</span><span class="sxs-lookup"><span data-stu-id="3ca27-130">A set of claims (such as gamertag, device type, title ID) are used as part of relying party configurations to enforce this trust.</span></span> <span data-ttu-id="3ca27-131">これは、Xbox Live や web サービスを自動的にユーザーを認証の間で交換される情報です。</span><span class="sxs-lookup"><span data-stu-id="3ca27-131">This is the information exchanged between Xbox Live and the web service to help automatically authenticate users.</span></span>

### <a name="create-a-relying-party"></a><span data-ttu-id="3ca27-132">証明書利用者のパーティを作成します</span><span class="sxs-lookup"><span data-stu-id="3ca27-132">Create a Relying Party</span></span>

1. <span data-ttu-id="3ca27-133">パートナー センター ダッシュ ボードに移動します。</span><span class="sxs-lookup"><span data-stu-id="3ca27-133">Go to the Partner Center Dashboard</span></span>  
2. <span data-ttu-id="3ca27-134">アクセスするページの右上隅にある歯車の形のアイコンをクリックして、**設定**ドロップダウンします。</span><span class="sxs-lookup"><span data-stu-id="3ca27-134">Click on the gear shaped icon at the top right corner of the page to access the **Settings** dropdown.</span></span>
3. <span data-ttu-id="3ca27-135">ドロップダウン リストで選択**開発者設定が**します。</span><span class="sxs-lookup"><span data-stu-id="3ca27-135">Within the dropdown, select **Developer Settings**.</span></span>
4. <span data-ttu-id="3ca27-136">左側のナビゲーション バーで、オプションを展開**Xbox Live**選択**証明書利用者**します。</span><span class="sxs-lookup"><span data-stu-id="3ca27-136">On the left-side navigation bar, expand the option **Xbox Live** and select **Relying Parties**.</span></span>
5. <span data-ttu-id="3ca27-137">証明書利用者 ページで、クリックして**新しい証明書利用者のパーティ**します。</span><span class="sxs-lookup"><span data-stu-id="3ca27-137">On the Relying Parties page, click on **New Relying Party**.</span></span>
6. <span data-ttu-id="3ca27-138">この形式で証明書利用者の URI を入力: *example.com*します。</span><span class="sxs-lookup"><span data-stu-id="3ca27-138">Enter a URI for the relying party in this format: *example.com*.</span></span>
7. <span data-ttu-id="3ca27-139">証明書利用者のパーティのサービスのセキュリティを確保するために使用する暗号化の種類を選択します。</span><span class="sxs-lookup"><span data-stu-id="3ca27-139">Select the encryption type to be used to ensure security of the relying party service.</span></span>
8. <span data-ttu-id="3ca27-140">前の手順で共有キーを持つ対称暗号化を選択した場合はクリックして**新しいキーの生成**新しい共有キーを取得します。</span><span class="sxs-lookup"><span data-stu-id="3ca27-140">If you selected Symmetric Encryption with shared keys in the previous step, click on **Generate new key** to get a new shared key.</span></span> <span data-ttu-id="3ca27-141">キーを安全に保存する画面の指示に従います。</span><span class="sxs-lookup"><span data-stu-id="3ca27-141">Follow the instructions on the screen to securely save the key.</span></span>
9. <span data-ttu-id="3ca27-142">入力、**トークン有効期間**時間。</span><span class="sxs-lookup"><span data-stu-id="3ca27-142">Enter the **Token Life Time** in hours.</span></span>
10. <span data-ttu-id="3ca27-143">**クレーム**、ドロップダウン リストが証明書利用者のパーティのサービスを認証するために使用できるクレームの一覧を提供します。</span><span class="sxs-lookup"><span data-stu-id="3ca27-143">Under **Claims**, the dropdown offers a list of claims that your relying party service can use for the purpose of authentication.</span></span> <span data-ttu-id="3ca27-144">使用するすべての要求を選択します。</span><span class="sxs-lookup"><span data-stu-id="3ca27-144">Select all the claims that you want to use.</span></span> <span data-ttu-id="3ca27-145">選択した要求は、ドロップダウン リストの下に表示されます。</span><span class="sxs-lookup"><span data-stu-id="3ca27-145">The selected claims will appear below the dropdown.</span></span> <span data-ttu-id="3ca27-146">一部の標準的な要求は既定でその領域に追加されます。</span><span class="sxs-lookup"><span data-stu-id="3ca27-146">Some standard claims will be populated in that space by default.</span></span>
11. <span data-ttu-id="3ca27-147">クリックして**保存**完了したら。</span><span class="sxs-lookup"><span data-stu-id="3ca27-147">Click **Save** when you're done.</span></span>  

## <a name="configure-a-business-partner-certificate"></a><span data-ttu-id="3ca27-148">ビジネス パートナーの証明書を構成します。</span><span class="sxs-lookup"><span data-stu-id="3ca27-148">Configure a Business Partner Certificate</span></span>

<span data-ttu-id="3ca27-149">直接、または個々 のユーザーの代わりに、Xbox Live サービスへの呼び出しを実行する web サービスのいずれかの製品を使用して、ビジネス パートナーの証明書が必要があります。</span><span class="sxs-lookup"><span data-stu-id="3ca27-149">If your product will use one of your web services to make calls to an Xbox Live service, either directly or on behalf of individual users, you'll need a business partner certificate.</span></span>

### <a name="generate-a-business-partner-certificate"></a><span data-ttu-id="3ca27-150">ビジネス パートナーの証明書を生成します。</span><span class="sxs-lookup"><span data-stu-id="3ca27-150">Generate a Business Partner Certificate</span></span>

<span data-ttu-id="3ca27-151">Web サービスを正常に作成した後、次の手順に進みます。</span><span class="sxs-lookup"><span data-stu-id="3ca27-151">Proceed with the steps below after successfully creating a Web Service.</span></span>  

1. <span data-ttu-id="3ca27-152">Web サービス ページで、web サービスでのビジネス パートナーの証明書を関連付けるを検索します。</span><span class="sxs-lookup"><span data-stu-id="3ca27-152">On the Web Services page, find the web service that you want to associate a Business Partner Certificate with.</span></span>
2. <span data-ttu-id="3ca27-153">選択、**証明書の生成**選択した web サービスに対するリンク。</span><span class="sxs-lookup"><span data-stu-id="3ca27-153">Select the **Generate Certificate** link against the chosen web service.</span></span>
3. <span data-ttu-id="3ca27-154">をクリックして**オプションを表示**新しい証明書の生成の横にあります。</span><span class="sxs-lookup"><span data-stu-id="3ca27-154">Click on **Show Options** next to Generating a New Certificate.</span></span> <span data-ttu-id="3ca27-155">これにより、管理者特権で PowerShell から実行するコマンドが表示されます。</span><span class="sxs-lookup"><span data-stu-id="3ca27-155">This will display commands that should be run from PowerShell with Administrator privileges.</span></span>
4. <span data-ttu-id="3ca27-156">Blob をエンコードする Base64 を正常に付ける必要があります、その他の後に、1 つのすべてのコマンドを実行します。</span><span class="sxs-lookup"><span data-stu-id="3ca27-156">Running all the commands one after the other should successfully give a Base64 encoded blob.</span></span> <span data-ttu-id="3ca27-157">これは、公開キーです。</span><span class="sxs-lookup"><span data-stu-id="3ca27-157">This is the public key.</span></span> <span data-ttu-id="3ca27-158">PowerShell から公開キーをコピーし、CSP の Blob のプレース ホルダーに貼り付けます。</span><span class="sxs-lookup"><span data-stu-id="3ca27-158">Copy the public key from PowerShell and paste it in the placeholder for the CSP Blob.</span></span>
5. <span data-ttu-id="3ca27-159">クリックして**ダウンロード**証明書をバインドするためのページに、指示に従います。</span><span class="sxs-lookup"><span data-stu-id="3ca27-159">Click **Download** and follow the instructions on the page for Binding the certificates.</span></span>
    1. <span data-ttu-id="3ca27-160">公開キーを生成するために使用する同じコンピューターを使用します。</span><span class="sxs-lookup"><span data-stu-id="3ca27-160">Use the same computer you used to generate the public key.</span></span>
    2. <span data-ttu-id="3ca27-161">PowerShell でこのコマンドを実行します*mmc.exe。*</span><span class="sxs-lookup"><span data-stu-id="3ca27-161">Run this command in PowerShell: *mmc.exe*</span></span>
    3. <span data-ttu-id="3ca27-162">ファイルを選択し、スナップインの追加/削除を選択します。</span><span class="sxs-lookup"><span data-stu-id="3ca27-162">Select File and select Add/Remove Snap In.</span></span>
    4. <span data-ttu-id="3ca27-163">証明書を選択し、[追加] を選択します。</span><span class="sxs-lookup"><span data-stu-id="3ca27-163">Select Certificates and select Add.</span></span> <span data-ttu-id="3ca27-164">確認に証明書スナップインのコンピューター アカウントを選択します。 [完了] と [ok] をクリックします。</span><span class="sxs-lookup"><span data-stu-id="3ca27-164">Make sure to select Computer Account for the certificate snap-in and then click Finish and click OK.</span></span>
    5. <span data-ttu-id="3ca27-165">Personal\Certificate ストアを開きます。</span><span class="sxs-lookup"><span data-stu-id="3ca27-165">Open the Personal\Certificate store.</span></span>
    6. <span data-ttu-id="3ca27-166">証明書を右クリックし、すべてのタスクを選択し、インポートを選択します。</span><span class="sxs-lookup"><span data-stu-id="3ca27-166">Right click on Certificates and select All Tasks and select Import.</span></span>
    7. <span data-ttu-id="3ca27-167">UDC からダウンロードした証明書を選択します。</span><span class="sxs-lookup"><span data-stu-id="3ca27-167">Select the certificate you downloaded from UDC.</span></span>
    8. <span data-ttu-id="3ca27-168">インポートした後、UI で証明書を右クリックし、すべてのタスクを選択し、エクスポートを選択します。</span><span class="sxs-lookup"><span data-stu-id="3ca27-168">Right click on the certificate in the UI after it was imported and select All Tasks and select Export.</span></span>
    9. <span data-ttu-id="3ca27-169">エクスポート ウィザードの指示に従ってしを選択して、証明書に秘密キーをエクスポートすることがあります。</span><span class="sxs-lookup"><span data-stu-id="3ca27-169">Follow the Export wizard and be sure to select to export the private key with the certificate.</span></span>
    10. <span data-ttu-id="3ca27-170">エクスポート ウィザードを完了します。</span><span class="sxs-lookup"><span data-stu-id="3ca27-170">Finish the Export wizard.</span></span>