---
author: PatrickFarley
ms.assetid: bf0a8b01-79f1-4944-9d78-9741e235dbe9
title: "Xbox 用 Device Portal"
description: "Xbox One 向けの Device Portal を有効にする方法について説明します。"
ms.author: pafarley
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: 67416e2b190d3a52eac2a395c0e5bc1b3e7fdf24
ms.sourcegitcommit: e8cc657d85566768a6efb7cd972ebf64c25e0628
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 06/26/2017
---
# <a name="device-portal-for-xbox"></a><span data-ttu-id="0da86-104">Xbox 用 Device Portal</span><span class="sxs-lookup"><span data-stu-id="0da86-104">Device Portal for Xbox</span></span>


## <a name="set-up-device-portal-on-xbox"></a><span data-ttu-id="0da86-105">Xbox で Device Portal をセットアップする</span><span class="sxs-lookup"><span data-stu-id="0da86-105">Set up Device Portal on Xbox</span></span>

### <a name="enable-device-portal"></a><span data-ttu-id="0da86-106">Device Portal を有効にする</span><span class="sxs-lookup"><span data-stu-id="0da86-106">Enable Device Portal</span></span>

**<span data-ttu-id="0da86-107">Device Portal を有効にするには</span><span class="sxs-lookup"><span data-stu-id="0da86-107">To enable Device Portal</span></span>**

1. <span data-ttu-id="0da86-108">ホーム画面で [Dev Home] タイルを選択します (画像を参照)。</span><span class="sxs-lookup"><span data-stu-id="0da86-108">Select the Dev Home tile on the home screen (see image)</span></span>  
![Device Portal の DevHome](images/device-portal/xbox-dev-home-tile.png)
2. <span data-ttu-id="0da86-110">[Dev Home] 内の **[Remote Management]** ツールに移動します ![Device Portal RemoteManagement ツール</span><span class="sxs-lookup"><span data-stu-id="0da86-110">Within Dev Home, navigate to the **Remote Management** tool ![Device Portal RemoteManagement Tool</span></span>](images/device-portal/xbox-remote-management-tool.png)
3. <span data-ttu-id="0da86-111">**[Manage Windows Device Portal** (Windows Device Portal の管理]) を選択し、**[A]** を押します。</span><span class="sxs-lookup"><span data-stu-id="0da86-111">Select **Manage Windows Device Portal** and press **A**</span></span>
4. <span data-ttu-id="0da86-112">**[Enable Windows Device Portal]** (Windows Device Portal を有効にする) 設定をオンにします。</span><span class="sxs-lookup"><span data-stu-id="0da86-112">Check the **Enable Windows Device Portal** setting</span></span>
5. <span data-ttu-id="0da86-113">ブラウザーから devkit へのアクセスを認証するために使うユーザー名とパスワードを入力し、保存します。</span><span class="sxs-lookup"><span data-stu-id="0da86-113">Enter a Username and Password to use to authenticate access to your devkit from a browser, and save them.</span></span>
6. <span data-ttu-id="0da86-114">設定ページを閉じ、[Remote Management] (リモート管理) ツールに表示された URL を記録します。</span><span class="sxs-lookup"><span data-stu-id="0da86-114">Close the settings page and note the URL listed on the Remote Management tool to connect.</span></span>
7. <span data-ttu-id="0da86-115">URL をブラウザーに入力し、構成した資格情報でサインインします。</span><span class="sxs-lookup"><span data-stu-id="0da86-115">Enter the URL in your browser, and then sign in with the credentials you configured.</span></span>
8. <span data-ttu-id="0da86-116">提供された証明書に関して、次の図のような警告が表示されます。</span><span class="sxs-lookup"><span data-stu-id="0da86-116">You will receive a warning about the Certificate that was provided, similar to that pictured below.</span></span> <span data-ttu-id="0da86-117">プレビューで Windows Device Portal にアクセスするには、**[このサイトの閲覧を続行する]** をクリックする必要があります。</span><span class="sxs-lookup"><span data-stu-id="0da86-117">You should click on **Continue to this website** to access Windows Device Portal in the preview.</span></span>
![Device Portal の証明書エラー](images/device-portal/xbox-certificate-error.png)

## <a name="device-portal-pages"></a><span data-ttu-id="0da86-119">Device Portal のページ</span><span class="sxs-lookup"><span data-stu-id="0da86-119">Device Portal pages</span></span>

<span data-ttu-id="0da86-120">Xbox の Device Portal では、一連の標準ページが提供されます。</span><span class="sxs-lookup"><span data-stu-id="0da86-120">Device Portal on Xbox provides a set of standard pages.</span></span> <span data-ttu-id="0da86-121">詳しい説明については、「[Windows Device Portal の概要](device-portal.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0da86-121">For detailed descriptions, see [Windows Device Portal overview](device-portal.md).</span></span>

- <span data-ttu-id="0da86-122">アプリ</span><span class="sxs-lookup"><span data-stu-id="0da86-122">Apps</span></span>
- <span data-ttu-id="0da86-123">パフォーマンス</span><span class="sxs-lookup"><span data-stu-id="0da86-123">Performance</span></span>
- <span data-ttu-id="0da86-124">ネットワーク</span><span class="sxs-lookup"><span data-stu-id="0da86-124">Networking</span></span>
