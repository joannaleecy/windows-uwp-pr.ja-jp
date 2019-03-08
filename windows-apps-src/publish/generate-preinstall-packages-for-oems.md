---
Description: 開発者アカウントに適切なアクセス許可が付与されている場合、OEM が OS イメージにアプリを組み込めるプレインストール パッケージを生成してダウンロードできます。
title: OEM 向けのプレインストール パッケージの生成
ms.assetid: AC3A45E8-7BBD-44E9-B2D3-B74B7C9B2BC9
ms.date: 10/31/2018
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 1ab17adc80a643c04ac7793945486c3ff975fde5
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57643137"
---
# <a name="generate-preinstall-packages-for-oems"></a><span data-ttu-id="6c8d8-104">OEM 向けのプレインストール パッケージの生成</span><span class="sxs-lookup"><span data-stu-id="6c8d8-104">Generate preinstall packages for OEMs</span></span>

<span data-ttu-id="6c8d8-105">開発者アカウントに適切なアクセス許可が付与されている場合、OEM が OS イメージにアプリを組み込めるプレインストール パッケージを生成してダウンロードできます。</span><span class="sxs-lookup"><span data-stu-id="6c8d8-105">If your developer account has been granted the appropriate permissions, you can generate and download preinstall packages so that an OEM can include your app in their OS image.</span></span> <span data-ttu-id="6c8d8-106">プレインストールのアクセス許可は、OEM がスポンサーである開発者アカウントでのみ有効です。</span><span class="sxs-lookup"><span data-stu-id="6c8d8-106">Preinstall permissions are only enabled on developer accounts that are sponsored by OEMs.</span></span>


## <a name="important-preinstall-policy--limitations"></a><span data-ttu-id="6c8d8-107">重要なプレインストールに関するポリシーと制限事項</span><span class="sxs-lookup"><span data-stu-id="6c8d8-107">Important preinstall policy & limitations</span></span>

<span data-ttu-id="6c8d8-108">を通じてプレインストール アプリの認定を受ける必要があります[パートナー センター](https://partner.microsoft.com/dashboard)をストアに接続し、アプリの更新プログラムを受け取ることができるように、最新のストア ライセンスを持っています。</span><span class="sxs-lookup"><span data-stu-id="6c8d8-108">Preinstall apps must be certified through [Partner Center](https://partner.microsoft.com/dashboard) to have the latest Store license so that they are able to connect to the Store and receive app updates.</span></span>

<span data-ttu-id="6c8d8-109">プレインストールされているアプリは、すべての市場で、現在も将来も無料である必要があります。</span><span class="sxs-lookup"><span data-stu-id="6c8d8-109">Any app that is preinstalled must be and remain free in all markets.</span></span>


## <a name="generating-preinstall-packages"></a><span data-ttu-id="6c8d8-110">プレインストール パッケージの生成</span><span class="sxs-lookup"><span data-stu-id="6c8d8-110">Generating preinstall packages</span></span>

<span data-ttu-id="6c8d8-111">プレインストールのアクセス許可を持つアカウントが有効になったら、次の手順を実行します。</span><span class="sxs-lookup"><span data-stu-id="6c8d8-111">Once an account has been enabled with preinstall permissions, complete the following steps:</span></span>

1.  <span data-ttu-id="6c8d8-112">パートナー センターでは、プレインストールされるアプリに移動します。</span><span class="sxs-lookup"><span data-stu-id="6c8d8-112">In Partner Center, navigate to the app that is to be preinstalled.</span></span>
2.  <span data-ttu-id="6c8d8-113">左側のナビゲーション メニューで、**[アプリ管理]** を展開し、**[現在のパッケージ]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="6c8d8-113">In the left navigation menu, expand **App management** and select **Current packages**.</span></span>
3.  <span data-ttu-id="6c8d8-114">**[OS プレインストール用パッケージの要求]** で、**[ダウンロード可能なパッケージを有効にする]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="6c8d8-114">In the **Request packages for OS preinstallation** section, select **Enable downloadable packages**.</span></span>
4.  <span data-ttu-id="6c8d8-115">確認のダイアログ ボックスで、**[有効化]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="6c8d8-115">In the confirmation dialog will, select **Enable**.</span></span>
5.  <span data-ttu-id="6c8d8-116">ダウンロードするパッケージを検索し、適切な **[Generate package] (パッケージの生成)** リンクを選びます。</span><span class="sxs-lookup"><span data-stu-id="6c8d8-116">Find the package that you want to download and select the appropriate **Generate package** link.</span></span>

    > [!NOTE]
    > <span data-ttu-id="6c8d8-117">プレインストール パッケージの生成時間は、選んだパッケージのサイズによって異なります。</span><span class="sxs-lookup"><span data-stu-id="6c8d8-117">Generation time for preinstall packages will vary depending on the size of the package you have selected.</span></span> <span data-ttu-id="6c8d8-118">パッケージの生成中は、このページから離れて後で再び戻ってくることも、このページを開いたままにしておくこともできます。</span><span class="sxs-lookup"><span data-stu-id="6c8d8-118">You can leave this page and come back later, or you can leave the page open while your package is being generated.</span></span>

6.  <span data-ttu-id="6c8d8-119">パッケージが生成されると、**[パッケージのダウンロード]** リンクが表示されます。</span><span class="sxs-lookup"><span data-stu-id="6c8d8-119">After the package has been generated, a link to **Download package** will appear.</span></span> <span data-ttu-id="6c8d8-120">このリンクを選んで .zip ファイルをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="6c8d8-120">Select this link to download the .zip file.</span></span>

<span data-ttu-id="6c8d8-121">この .zip ファイルを OEM に提供すると、OEM はこのファイルを OS イメージに含めることができます。</span><span class="sxs-lookup"><span data-stu-id="6c8d8-121">You can then provide the .zip file to the OEM for inclusion in their OS image.</span></span>


## <a name="support"></a><span data-ttu-id="6c8d8-122">サポート</span><span class="sxs-lookup"><span data-stu-id="6c8d8-122">Support</span></span>

<span data-ttu-id="6c8d8-123">プレインストールのパッケージの生成について質問があるさらに場合、電子メール<partnerops@microsoft.com>します。</span><span class="sxs-lookup"><span data-stu-id="6c8d8-123">If you have further questions about generating preinstall packages, please email <partnerops@microsoft.com>.</span></span>

 

 




