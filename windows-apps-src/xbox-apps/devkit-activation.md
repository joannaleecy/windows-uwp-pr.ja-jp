---
author: Mtoepke
title: Xbox One 開発者モードのアクティブ化
description: 開発者モードをアクティブ化して、リテール モードと開発者モードを切り替えることができるようにする方法を説明します。
ms.author: scotmi
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.assetid: ade80769-17ae-46e9-9c2f-bf08ae5a51ee
ms.localizationpriority: medium
ms.openlocfilehash: bf9bbc2962bc0d11f9969bf41840be515c9c0881
ms.sourcegitcommit: cbe7cf620622a5e4df7414f9e38dfecec1cfca99
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/21/2018
ms.locfileid: "7432478"
---
# <a name="xbox-one-developer-mode-activation"></a><span data-ttu-id="461c0-104">Xbox One 開発者モードのアクティブ化</span><span class="sxs-lookup"><span data-stu-id="461c0-104">Xbox One Developer Mode activation</span></span>

## <a name="how-developer-mode-works"></a><span data-ttu-id="461c0-105">開発者モードの動作</span><span class="sxs-lookup"><span data-stu-id="461c0-105">How Developer Mode works</span></span>
<span data-ttu-id="461c0-106">Xbox One には、*リテール* モード (**1**) と*開発者*モード (**2**) の 2 つのモードがあります。</span><span class="sxs-lookup"><span data-stu-id="461c0-106">Xbox One has two modes, *Retail* Mode (**1**) and *Developer* Mode (**2**).</span></span> <span data-ttu-id="461c0-107">リテール モードは、Xbox One 本体のユーザーが本体を使うときのモードです。ユーザーとしてゲームをプレイしたり、アプリを実行したりできます。</span><span class="sxs-lookup"><span data-stu-id="461c0-107">In Retail Mode, the console is in the state that any customer or user of an Xbox One console would use: you can play games and run apps as a user.</span></span> <span data-ttu-id="461c0-108">開発者モードでは、本体用のソフトウェアを開発することができますが、製品版のゲームをプレイしたり、製品版のアプリを実行したりすることはできません。</span><span class="sxs-lookup"><span data-stu-id="461c0-108">In Developer Mode, you can develop software for the console, but you cannot play retail games or run retail apps.</span></span>

<span data-ttu-id="461c0-109">開発者モードは、製品版のすべての Xbox One 本体で有効にできます。</span><span class="sxs-lookup"><span data-stu-id="461c0-109">Developer Mode can be enabled on any retail Xbox One console.</span></span> <span data-ttu-id="461c0-110">開発者モードを有効にした後は、リテール モード (**2a**) と開発者モード (**2b**) を相互に切り替えることができます。</span><span class="sxs-lookup"><span data-stu-id="461c0-110">After Developer Mode is enabled, you can switch back and forth between Retail (**2a**) and Developer Modes (**2b**).</span></span>

![Xbox One のモード](images/dev-mode-flow.png)

## <a name="activate-developer-mode-on-your-retail-xbox-one-console"></a><span data-ttu-id="461c0-112">製品版の Xbox One 本体で開発者モードをアクティブにする</span><span class="sxs-lookup"><span data-stu-id="461c0-112">Activate Developer Mode on your retail Xbox One console</span></span>

1.  <span data-ttu-id="461c0-113">Xbox One 本体を起動します。</span><span class="sxs-lookup"><span data-stu-id="461c0-113">Start your Xbox One console.</span></span>

2.  <span data-ttu-id="461c0-114">Xbox One Store から、**開発者モードのアクティブ化**用アプリを検索してインストールします。</span><span class="sxs-lookup"><span data-stu-id="461c0-114">Search for and install the **Dev Mode Activation** app from the Xbox One store.</span></span>

    ![開発者モードのアクティブ化用アプリのインストール](images/devkit-activation-1.png)

3.  <span data-ttu-id="461c0-116">Microsoft Store ページからアプリを起動します。</span><span class="sxs-lookup"><span data-stu-id="461c0-116">Launch the app from the Store page.</span></span>

    ![開発者モードのアクティブ化用アプリ](images/devkit-activation-2.png)

4.  <span data-ttu-id="461c0-118">開発者モードのアクティブ化用アプリに表示されたコードを書き留めます。</span><span class="sxs-lookup"><span data-stu-id="461c0-118">Note the code displayed in the Dev Mode Activation app.</span></span>

    ![アクティブ化手順 5](images/activation-step-5.png)  
    
5.  <span data-ttu-id="461c0-120">[Partner.microsoft.com/xboxactivate](https://partner.microsoft.com/xboxactivate)に移動します。</span><span class="sxs-lookup"><span data-stu-id="461c0-120">Go to [partner.microsoft.com/xboxactivate](https://partner.microsoft.com/xboxactivate).</span></span>

6.  <span data-ttu-id="461c0-121">アカウントの資格情報を[パートナー センター](https://partner.microsoft.com/dashboard)にサインインします。</span><span class="sxs-lookup"><span data-stu-id="461c0-121">Sign in to [Partner Center](https://partner.microsoft.com/dashboard) with your account credentials.</span></span>

7.  <span data-ttu-id="461c0-122">開発者モードのアクティブ化用アプリに表示されたアクティブ化コードを入力します。</span><span class="sxs-lookup"><span data-stu-id="461c0-122">Enter the activation code displayed in the Dev Mode Activation app.</span></span> <span data-ttu-id="461c0-123">アカウントに関連付けられているアクティブ化の数には制限があります。</span><span class="sxs-lookup"><span data-stu-id="461c0-123">You have a limited number of activations associated with your account.</span></span> <span data-ttu-id="461c0-124">開発者モードをアクティブ化後、パートナー センターは、アカウントに関連付けられているライセンス認証のいずれかを使用したを示します。</span><span class="sxs-lookup"><span data-stu-id="461c0-124">After Developer Mode has been activated, Partner Center will indicate you have used one of the activations associated with your account.</span></span>

    ![アクティブ化手順 8](images/activation-step-8-rs2.png)    
    
8.  <span data-ttu-id="461c0-126">**[Agree and activate]** (同意してアクティブ化) をクリックします。</span><span class="sxs-lookup"><span data-stu-id="461c0-126">Click **Agree and activate**.</span></span> <span data-ttu-id="461c0-127">ページの再読み込みが行われ、デバイスが表に追加されます。</span><span class="sxs-lookup"><span data-stu-id="461c0-127">This will cause the page to reload, and you will see your device populate in the table.</span></span> <span data-ttu-id="461c0-128">Xbox One 開発者モードのライセンス認証プログラム契約は、[Xbox One開発者モードのライセンス認証プログラム](http://go.microsoft.com/fwlink/p/?LinkId=760399) にあります。</span><span class="sxs-lookup"><span data-stu-id="461c0-128">Terms for the Xbox One Developer Mode Activation Program agreement can be found at [Xbox One Developer Mode Activation Program](http://go.microsoft.com/fwlink/p/?LinkId=760399).</span></span>

9.  <span data-ttu-id="461c0-129">アクティブ化コードを入力すると、アクティブ化プロセスの進行状況が表示されます。</span><span class="sxs-lookup"><span data-stu-id="461c0-129">After you’ve entered your activation code, your console will display a progress screen for the activation process.</span></span>  
    
10. <span data-ttu-id="461c0-130">アクティブ化の完了後、開発者モードのアクティブ化用アプリを開き、**[Switch and restart]** (切り替えて再起動) をクリックして、開発者モードに移行します。</span><span class="sxs-lookup"><span data-stu-id="461c0-130">After activation has completed, open the Dev Mode Activation app and click **Switch and restart** to go to Developer Mode.</span></span> <span data-ttu-id="461c0-131">これは通常の再起動よりも時間がかかります。</span><span class="sxs-lookup"><span data-stu-id="461c0-131">Note that this will take longer than usual.</span></span>

    ![アクティブ化手順 12](images/activation-step-12.png)   

## <a name="switch-between-retail-and-developer-mode"></a><span data-ttu-id="461c0-133">リテール モードと開発者モードを切り替える</span><span class="sxs-lookup"><span data-stu-id="461c0-133">Switch between Retail and Developer Mode</span></span>
<span data-ttu-id="461c0-134">本体で開発者モードを有効にした後、リテール モードと開発者モードを切り替えるには、**Dev Home** を使います。</span><span class="sxs-lookup"><span data-stu-id="461c0-134">After Developer Mode has been enabled on your console, use **Dev Home** to switch between Retail Mode and Developer Mode.</span></span> <span data-ttu-id="461c0-135">Dev Home の起動と使用の詳細については、「[Xbox One ツールの概要](introduction-to-xbox-tools.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="461c0-135">To learn more about starting and using Dev Home, see [Introduction to Xbox One tools](introduction-to-xbox-tools.md).</span></span>

* <span data-ttu-id="461c0-136">リテール モードに切り替えるには、**Dev Home** を開きます。</span><span class="sxs-lookup"><span data-stu-id="461c0-136">To switch to Retail Mode, open **Dev Home**.</span></span> <span data-ttu-id="461c0-137">**[クイック アクション]** で、**[開発者モードの終了]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="461c0-137">Under **Quick Actions**, select **Leave Dev Mode**.</span></span> <span data-ttu-id="461c0-138">コンソールがリテール モードで再起動します。</span><span class="sxs-lookup"><span data-stu-id="461c0-138">This will restart your console in Retail Mode.</span></span>    

  ![アクティブ化手順 13](images/activation-step-13-rs4.png)  
  
* <span data-ttu-id="461c0-140">開発者モードに切り替えるには、開発者モードのアクティブ化用アプリを使います。</span><span class="sxs-lookup"><span data-stu-id="461c0-140">To switch to Developer Mode, use the Dev Mode Activation app.</span></span> <span data-ttu-id="461c0-141">アプリを開き、**[Switch and restart]** (切り替えて再起動) を選びます。</span><span class="sxs-lookup"><span data-stu-id="461c0-141">Open the app and select **Switch and restart**.</span></span> <span data-ttu-id="461c0-142">これにより、本体が開発者モードで再起動します。</span><span class="sxs-lookup"><span data-stu-id="461c0-142">This will restart your console in Developer Mode.</span></span>  

  ![アクティブ化手順 14](images/activation-step-12.png)  

## <a name="see-also"></a><span data-ttu-id="461c0-144">参照</span><span class="sxs-lookup"><span data-stu-id="461c0-144">See also</span></span>
- [<span data-ttu-id="461c0-145">Xbox One 開発者モードの非アクティブ化</span><span class="sxs-lookup"><span data-stu-id="461c0-145">Xbox One Developer Mode deactivation</span></span>](devkit-deactivation.md)
- [<span data-ttu-id="461c0-146">Xbox One の UWP</span><span class="sxs-lookup"><span data-stu-id="461c0-146">UWP on Xbox One</span></span>](index.md)
