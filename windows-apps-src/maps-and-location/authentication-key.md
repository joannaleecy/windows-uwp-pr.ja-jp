---
author: normesta
title: マップ認証キーの要求
description: MapControl や Windows.Services.Maps 名前空間のマップ サービスをユニバーサル Windows アプリで使うには、そのアプリを認証する必要があります。
ms.assetid: 13B400D7-E13F-4F07-ACC3-9C34087F0F73
ms.author: normesta
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10、UWP、マップ認証キー、マップ コントロール
ms.openlocfilehash: 7b964c19933db460b8f6b0cc7791165ad86adb6c
ms.sourcegitcommit: 378382419f1fda4e4df76ffa9c8cea753d271e6a
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 06/08/2017
ms.locfileid: "665596"
---
# <a name="request-a-maps-authentication-key"></a><span data-ttu-id="57d1b-104">マップ認証キーの要求</span><span class="sxs-lookup"><span data-stu-id="57d1b-104">Request a maps authentication key</span></span>


<span data-ttu-id="57d1b-105">\[Windows 10 の UWP アプリ向けに更新。</span><span class="sxs-lookup"><span data-stu-id="57d1b-105">\[ Updated for UWP apps on Windows 10.</span></span> <span data-ttu-id="57d1b-106">Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132) をご覧ください\]</span><span class="sxs-lookup"><span data-stu-id="57d1b-106">For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]</span></span>


<span data-ttu-id="57d1b-107">[**MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004) や [**Windows.Services.Maps**](https://msdn.microsoft.com/library/windows/apps/dn636979) 名前空間のマップ サービスを [ユニバーサル Windows アプリ](https://msdn.microsoft.com/library/windows/apps/dn894631) で使うには、そのアプリを認証する必要があります。</span><span class="sxs-lookup"><span data-stu-id="57d1b-107">Your [Universal Windows app](https://msdn.microsoft.com/library/windows/apps/dn894631) must be authenticated before it can use the [**MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004) and map services in the [**Windows.Services.Maps**](https://msdn.microsoft.com/library/windows/apps/dn636979) namespace.</span></span> <span data-ttu-id="57d1b-108">アプリを認証するには、マップ認証キーを指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="57d1b-108">To authenticate your app, you must specify a maps authentication key.</span></span> <span data-ttu-id="57d1b-109">このトピックでは、[Bing Maps Developer Center](https://www.bingmapsportal.com/) にマップ認証キーを要求し、アプリに追加する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="57d1b-109">This topic describes how to request a maps authentication key from the [Bing Maps Developer Center](https://www.bingmapsportal.com/) and add it to your app.</span></span>

<span data-ttu-id="57d1b-110">**ヒント** アプリで地図を使う方法について詳しくは、GitHub の [2Windows-universal-samples リポジトリ](http://go.microsoft.com/fwlink/p/?LinkId=619979) から次のサンプルをダウンロードしてください。</span><span class="sxs-lookup"><span data-stu-id="57d1b-110">**Tip** To learn more about using maps in your app, download the following sample from the [Windows-universal-samples repo](http://go.microsoft.com/fwlink/p/?LinkId=619979) on GitHub:</span></span>

-   [<span data-ttu-id="57d1b-111">ユニバーサル Windows プラットフォーム (UWP) の地図サンプル</span><span class="sxs-lookup"><span data-stu-id="57d1b-111">Universal Windows Platform (UWP) map sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkId=619977)

## <a name="get-a-key"></a><span data-ttu-id="57d1b-112">キーの取得</span><span class="sxs-lookup"><span data-stu-id="57d1b-112">Get a key</span></span>


<span data-ttu-id="57d1b-113">[Bing Maps Developer Center](https://www.bingmapsportal.com/) を使って、ユニバーサル Windows アプリ用のマップ認証キーを作成し管理します。</span><span class="sxs-lookup"><span data-stu-id="57d1b-113">Create and manage map authentication keys for your Universal Windows apps using the [Bing Maps Developer Center](https://www.bingmapsportal.com/).</span></span>

<span data-ttu-id="57d1b-114">新しいキーを作成するには</span><span class="sxs-lookup"><span data-stu-id="57d1b-114">To create a new key</span></span>

1.  <span data-ttu-id="57d1b-115">ブラウザーで、Bing Maps Developer Center ([https://www.bingmapsportal.com](https://www.bingmapsportal.com/)) にアクセスします。</span><span class="sxs-lookup"><span data-stu-id="57d1b-115">In your browser, navigate to the Bing Maps Developer Center ([https://www.bingmapsportal.com](https://www.bingmapsportal.com/)).</span></span>

2.  <span data-ttu-id="57d1b-116">サインインを求められた場合は、Microsoft アカウントを入力して、**[Sign in] (サインイン)** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="57d1b-116">If you are asked to sign in, enter your Microsoft account and click **Sign in**.</span></span>

3.  <span data-ttu-id="57d1b-117">Bing Maps アカウントに関連付けるアカウントを選びます。</span><span class="sxs-lookup"><span data-stu-id="57d1b-117">Choose the account to associate with your Bing Maps account.</span></span> <span data-ttu-id="57d1b-118">Microsoft アカウントを使う場合は、**[Yes] (はい)** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="57d1b-118">If you want to use your Microsoft account, click **Yes**.</span></span> <span data-ttu-id="57d1b-119">それ以外の場合は、**[Sign in with another account] (別のアカウントでサインイン)** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="57d1b-119">Otherwise, click **Sign in with another account**.</span></span>

4.  <span data-ttu-id="57d1b-120">Bing Maps アカウントを持っていない場合は、ここで新しく作成します。</span><span class="sxs-lookup"><span data-stu-id="57d1b-120">If you don't already have a Bing Maps account, create a new Bing Maps account.</span></span> <span data-ttu-id="57d1b-121">**[Account Name] (アカウント名)**、**[Contact Name] (連絡先名)**、**[Company Name] (会社名)**、**[Email Address] (メール アドレス)**、**[Phone Number] (電話番号)** を入力します。</span><span class="sxs-lookup"><span data-stu-id="57d1b-121">Enter the **Account Name**, **Contact Name**, **Company Name**, **Email Address**, and **Phone Number**.</span></span> <span data-ttu-id="57d1b-122">使用条件に同意してから、**[Create] (作成)** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="57d1b-122">After accepting the terms of use, click **Create**.</span></span>

5.  <span data-ttu-id="57d1b-123">**[My account] (アカウント) **メニューで、**[My Keys] (マイ キー)** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="57d1b-123">Under the **My account** menu, click **My Keys**.</span></span>

6.  <span data-ttu-id="57d1b-124">以前にキーを作成していた場合は、新しいキーを作成するためのリンクをクリックします。</span><span class="sxs-lookup"><span data-stu-id="57d1b-124">If you have previously created a key, click on the link to create a new key.</span></span> <span data-ttu-id="57d1b-125">それ以外の場合は、[Create Key] (キーの作成) フォームに進みます。</span><span class="sxs-lookup"><span data-stu-id="57d1b-125">Otherwise proceed to the Create Key form.</span></span>

7.  <span data-ttu-id="57d1b-126">**[Create Key] (キーの作成)** フォームの入力が完了したら、**[Create] (作成)** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="57d1b-126">Complete the **Create Key** form and then click **Create**.</span></span>

    -   <span data-ttu-id="57d1b-127">**[Application name] (アプリケーション名):** アプリケーションの名前です。</span><span class="sxs-lookup"><span data-stu-id="57d1b-127">**Application name:** The name of your application.</span></span>
    -   <span data-ttu-id="57d1b-128">**[Application URL] (オプション):** アプリケーションの URL です。</span><span class="sxs-lookup"><span data-stu-id="57d1b-128">**Application URL (optional):** The URL of your application.</span></span>
    -   <span data-ttu-id="57d1b-129">**[Key type]:** **[Basic]** または **[Enterprise]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="57d1b-129">**Key type:** Select **Basic** or **Enterprise**.</span></span>
    -   <span data-ttu-id="57d1b-130">**[Application type]:** ユニバーサル Windows アプリで使うには、**[Universal Windows App]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="57d1b-130">**Application type:** Select **Universal Windows App** for use in your Universal Windows app.</span></span>

    <span data-ttu-id="57d1b-131">次に示すのは、フォームの例です。</span><span class="sxs-lookup"><span data-stu-id="57d1b-131">This is an example of what the form looks like.</span></span>

    ![[Create key] (キーの作成) フォームの例。](images/createkeydialog.png)

8.  <span data-ttu-id="57d1b-133">**[Create] (作成)** をクリックすると、新しいキーが **[Create Key] (キーの作成)** フォームの下に表示されます。</span><span class="sxs-lookup"><span data-stu-id="57d1b-133">After you click **Create**, the new key appears below the **Create Key** form.</span></span> <span data-ttu-id="57d1b-134">このキーを安全な場所にコピーするか、次の手順で説明するように、キーをすぐにアプリに追加します。</span><span class="sxs-lookup"><span data-stu-id="57d1b-134">Copy it to a safe place or immediately add it to your app, as described in the next step.</span></span>

## <a name="add-the-key-to-your-app"></a><span data-ttu-id="57d1b-135">アプリへのキーの追加</span><span class="sxs-lookup"><span data-stu-id="57d1b-135">Add the key to your app</span></span>


<span data-ttu-id="57d1b-136">ユニバーサル Windows アプリで [**MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004) やマップ サービス ([**Windows.Services.Maps**](https://msdn.microsoft.com/library/windows/apps/dn636979)) を使うには、マップ認証キーが必要になります。</span><span class="sxs-lookup"><span data-stu-id="57d1b-136">The map authentication key is required to use the [**MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004) and map services ([**Windows.Services.Maps**](https://msdn.microsoft.com/library/windows/apps/dn636979)) in your Universal Windows app.</span></span> <span data-ttu-id="57d1b-137">必要に応じて、マップ コントロールやマップ サービスのオブジェクトにキーを追加します。</span><span class="sxs-lookup"><span data-stu-id="57d1b-137">Add it to the map control and map service objects, as applicable.</span></span>

### <a name="to-add-the-key-to-a-map-control"></a><span data-ttu-id="57d1b-138">マップ コントロールにキーを追加するには</span><span class="sxs-lookup"><span data-stu-id="57d1b-138">To add the key to a map control</span></span>

<span data-ttu-id="57d1b-139">[**MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004) を認証するには、[**MapServiceToken**](https://msdn.microsoft.com/library/windows/apps/dn637036) プロパティを認証キー値に設定します。</span><span class="sxs-lookup"><span data-stu-id="57d1b-139">To authenticate the [**MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004), set the [**MapServiceToken**](https://msdn.microsoft.com/library/windows/apps/dn637036) property to the authentication key value.</span></span> <span data-ttu-id="57d1b-140">このプロパティは、必要に応じて、コードまたは XAML マークアップで設定できます。</span><span class="sxs-lookup"><span data-stu-id="57d1b-140">You can set this property in code or in XAML markup, depending on your preferences.</span></span> <span data-ttu-id="57d1b-141">**MapControl** の使用について詳しくは、「[2D、3D、Streetside ビューでの地図の表示](display-maps.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="57d1b-141">For more info about using the **MapControl**, see [Display maps with 2D, 3D, and Streetside views](display-maps.md).</span></span>

-   <span data-ttu-id="57d1b-142">この例では、コードで **MapServiceToken** を認証キー値に設定しています。</span><span class="sxs-lookup"><span data-stu-id="57d1b-142">This example sets the **MapServiceToken** to the value of the authentication key in code.</span></span>

    ```cs
    MapControl1.MapServiceToken = "abcdef-abcdefghijklmno";
    ```

-   <span data-ttu-id="57d1b-143">この例では、XAML マークアップで **MapServiceToken** を認証キー値に設定しています。</span><span class="sxs-lookup"><span data-stu-id="57d1b-143">This example sets the **MapServiceToken** to the value of the authentication key in XAML markup.</span></span>

    ```xml
    <Maps:MapControl x:Name="MapControl1" MapServiceToken="abcdef-abcdefghijklmno"/>
    ```

### <a name="to-add-the-key-to-map-services"></a><span data-ttu-id="57d1b-144">マップ サービスにキーを追加するには</span><span class="sxs-lookup"><span data-stu-id="57d1b-144">To add the key to map services</span></span>

<span data-ttu-id="57d1b-145">[**Windows.Services.Maps**](https://msdn.microsoft.com/library/windows/apps/dn636979) 名前空間のサービスを使うには、[**ServiceToken**](https://msdn.microsoft.com/library/windows/apps/dn636977) プロパティを認証キー値に設定します。</span><span class="sxs-lookup"><span data-stu-id="57d1b-145">To use services in the [**Windows.Services.Maps**](https://msdn.microsoft.com/library/windows/apps/dn636979) namespace, set the [**ServiceToken**](https://msdn.microsoft.com/library/windows/apps/dn636977) property to the authentication key value.</span></span> <span data-ttu-id="57d1b-146">マップ サービスを使用する方法について詳しくは、「[ルートとルート案内の表示](routes-and-directions.md)」と「[ジオコーディングと逆ジオコーディングの実行](geocoding.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="57d1b-146">For more info about using map services, see [Display routes and directions](routes-and-directions.md) and [Perform geocoding and reverse geocoding](geocoding.md).</span></span>

-   <span data-ttu-id="57d1b-147">この例では、コードで **ServiceToken** を認証キー値に設定しています。</span><span class="sxs-lookup"><span data-stu-id="57d1b-147">This example sets the **ServiceToken** to the value of the authentication key in code.</span></span>

    ```cs
    MapService.ServiceToken = "abcdef-abcdefghijklmno";
    ```

## <a name="related-topics"></a><span data-ttu-id="57d1b-148">関連トピック</span><span class="sxs-lookup"><span data-stu-id="57d1b-148">Related topics</span></span>

* [<span data-ttu-id="57d1b-149">Bing Maps Developer Center</span><span class="sxs-lookup"><span data-stu-id="57d1b-149">Bing Maps Developer Center</span></span>](https://www.bingmapsportal.com/)
* [<span data-ttu-id="57d1b-150">UWP の地図サンプル</span><span class="sxs-lookup"><span data-stu-id="57d1b-150">UWP map sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkId=619977)
* [<span data-ttu-id="57d1b-151">地図の設計ガイドライン</span><span class="sxs-lookup"><span data-stu-id="57d1b-151">Design guidelines for maps</span></span>](https://msdn.microsoft.com/library/windows/apps/dn596102)
* [<span data-ttu-id="57d1b-152">Build 2015 のビデオ: Windows アプリでの電話、タブレット、PC で使用できるマップと位置情報の活用</span><span class="sxs-lookup"><span data-stu-id="57d1b-152">Build 2015 video: Leveraging Maps and Location Across Phone, Tablet, and PC in Your Windows Apps</span></span>](https://channel9.msdn.com/Events/Build/2015/2-757)
* [<span data-ttu-id="57d1b-153">UWP の交通情報アプリのサンプル</span><span class="sxs-lookup"><span data-stu-id="57d1b-153">UWP traffic app sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkId=619982)
