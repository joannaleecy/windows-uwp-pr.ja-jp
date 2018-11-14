---
author: jnHs
Description: If your developer account has been granted the appropriate permissions, you can generate and download preinstall packages so that an OEM can include your app in their OS image.
title: OEM 向けのプレインストール パッケージの生成
ms.assetid: AC3A45E8-7BBD-44E9-B2D3-B74B7C9B2BC9
ms.author: wdg-dev-content
ms.date: 10/31/2018
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 02f7c1ad1a396464532a1c63c925bf9e19600f1b
ms.sourcegitcommit: f2c9a050a9137a473f28b613968d5782866142c6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/10/2018
ms.locfileid: "6266227"
---
# <a name="generate-preinstall-packages-for-oems"></a><span data-ttu-id="7f10d-103">OEM 向けのプレインストール パッケージの生成</span><span class="sxs-lookup"><span data-stu-id="7f10d-103">Generate preinstall packages for OEMs</span></span>

<span data-ttu-id="7f10d-104">開発者アカウントに適切なアクセス許可が付与されている場合、OEM が OS イメージにアプリを組み込めるプレインストール パッケージを生成してダウンロードできます。</span><span class="sxs-lookup"><span data-stu-id="7f10d-104">If your developer account has been granted the appropriate permissions, you can generate and download preinstall packages so that an OEM can include your app in their OS image.</span></span> <span data-ttu-id="7f10d-105">プレインストールのアクセス許可は、OEM がスポンサーである開発者アカウントでのみ有効です。</span><span class="sxs-lookup"><span data-stu-id="7f10d-105">Preinstall permissions are only enabled on developer accounts that are sponsored by OEMs.</span></span>


## <a name="important-preinstall-policy--limitations"></a><span data-ttu-id="7f10d-106">重要なプレインストールに関するポリシーと制限事項</span><span class="sxs-lookup"><span data-stu-id="7f10d-106">Important preinstall policy & limitations</span></span>

<span data-ttu-id="7f10d-107">プレインストール アプリをストアに接続し、アプリの更新プログラムを受信することができるように、最新のストア ライセンスが[パートナー センター](https://partner.microsoft.com/dashboard)を通じて認定を受ける必要があります。</span><span class="sxs-lookup"><span data-stu-id="7f10d-107">Preinstall apps must be certified through [Partner Center](https://partner.microsoft.com/dashboard) to have the latest Store license so that they are able to connect to the Store and receive app updates.</span></span>

<span data-ttu-id="7f10d-108">プレインストールされているアプリは、すべての市場で、現在も将来も無料である必要があります。</span><span class="sxs-lookup"><span data-stu-id="7f10d-108">Any app that is preinstalled must be and remain free in all markets.</span></span>


## <a name="generating-preinstall-packages"></a><span data-ttu-id="7f10d-109">プレインストール パッケージの生成</span><span class="sxs-lookup"><span data-stu-id="7f10d-109">Generating preinstall packages</span></span>

<span data-ttu-id="7f10d-110">プレインストールのアクセス許可を持つアカウントが有効になったら、次の手順を実行します。</span><span class="sxs-lookup"><span data-stu-id="7f10d-110">Once an account has been enabled with preinstall permissions, complete the following steps:</span></span>

1.  <span data-ttu-id="7f10d-111">パートナー センターで、プレインストールするアプリに移動します。</span><span class="sxs-lookup"><span data-stu-id="7f10d-111">In Partner Center, navigate to the app that is to be preinstalled.</span></span>
2.  <span data-ttu-id="7f10d-112">左側のナビゲーション メニューで、**[アプリ管理]** を展開し、**[現在のパッケージ]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="7f10d-112">In the left navigation menu, expand **App management** and select **Current packages**.</span></span>
3.  <span data-ttu-id="7f10d-113">**[OS プレインストール用パッケージの要求]** で、**[ダウンロード可能なパッケージを有効にする]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="7f10d-113">In the **Request packages for OS preinstallation** section, select **Enable downloadable packages**.</span></span>
4.  <span data-ttu-id="7f10d-114">確認のダイアログ ボックスで、**[有効化]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="7f10d-114">In the confirmation dialog will, select **Enable**.</span></span>
5.  <span data-ttu-id="7f10d-115">ダウンロードするパッケージを検索し、適切な **[Generate package] (パッケージの生成)** リンクを選びます。</span><span class="sxs-lookup"><span data-stu-id="7f10d-115">Find the package that you want to download and select the appropriate **Generate package** link.</span></span>

    > [!NOTE]
    > <span data-ttu-id="7f10d-116">プレインストール パッケージの生成時間は、選んだパッケージのサイズによって異なります。</span><span class="sxs-lookup"><span data-stu-id="7f10d-116">Generation time for preinstall packages will vary depending on the size of the package you have selected.</span></span> <span data-ttu-id="7f10d-117">パッケージの生成中は、このページから離れて後で再び戻ってくることも、このページを開いたままにしておくこともできます。</span><span class="sxs-lookup"><span data-stu-id="7f10d-117">You can leave this page and come back later, or you can leave the page open while your package is being generated.</span></span>

6.  <span data-ttu-id="7f10d-118">パッケージが生成されると、**[パッケージのダウンロード]** リンクが表示されます。</span><span class="sxs-lookup"><span data-stu-id="7f10d-118">After the package has been generated, a link to **Download package** will appear.</span></span> <span data-ttu-id="7f10d-119">このリンクを選んで .zip ファイルをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="7f10d-119">Select this link to download the .zip file.</span></span>

<span data-ttu-id="7f10d-120">この .zip ファイルを OEM に提供すると、OEM はこのファイルを OS イメージに含めることができます。</span><span class="sxs-lookup"><span data-stu-id="7f10d-120">You can then provide the .zip file to the OEM for inclusion in their OS image.</span></span>


## <a name="support"></a><span data-ttu-id="7f10d-121">サポート</span><span class="sxs-lookup"><span data-stu-id="7f10d-121">Support</span></span>

<span data-ttu-id="7f10d-122">プレインストール パッケージの生成についてさらに不明な点がある場合は、<partnerops@microsoft.com> までメールでお問い合わせください。</span><span class="sxs-lookup"><span data-stu-id="7f10d-122">If you have further questions about generating preinstall packages, please email <partnerops@microsoft.com>.</span></span>

 

 




