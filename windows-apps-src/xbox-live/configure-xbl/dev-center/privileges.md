---
title: デベロッパー センターでの特権の構成
author: aablackm
description: Windows デベロッパー センターで特権を構成する方法について説明します。
ms.author: aablackm
ms.date: 04/09/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
ms.localizationpriority: medium
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, 特権, Windows デベロッパー センター
ms.openlocfilehash: f9ca72d54a539ab7fac684646019e2923572c297
ms.sourcegitcommit: e4f3e1b2d08a02b9920e78e802234e5b674e7223
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/26/2018
ms.locfileid: "4211477"
---
# <a name="configure-privileges-on-windows-dev-center"></a><span data-ttu-id="b598b-104">Windows デベロッパー センターでの特権を構成します。</span><span class="sxs-lookup"><span data-stu-id="b598b-104">Configure Privileges on Windows Dev Center</span></span>

<span data-ttu-id="b598b-105">特権の構成ページには、[Mixer](https://mixer.com/) などのストリーミング サービスへのタイトルのストリーミングがゲーマーに制限されるかどうかが示されます。</span><span class="sxs-lookup"><span data-stu-id="b598b-105">The Privileges configuration page dictates whether or not gamers will be restricted from streaming your title to streaming services like [Mixer](https://mixer.com/).</span></span> <span data-ttu-id="b598b-106">既定では、どのストリーミング プラットフォームでもブロードキャストが制限されません。このページは、ブロードキャストを制限する場合のみ変更してください。</span><span class="sxs-lookup"><span data-stu-id="b598b-106">By default your game will not restrict broadcasting on any streaming platform, changes to this page are only required if you would like to restrict broadcasting.</span></span> <span data-ttu-id="b598b-107">ブロードキャストは、2 つの方法で制限できます。</span><span class="sxs-lookup"><span data-stu-id="b598b-107">You can restrict broadcasting in two ways.</span></span> <span data-ttu-id="b598b-108">**[Default]** (既定値) セクションのチェック ボックスをオンにすることであらゆるプラットフォームでブロードキャストを無効にするか、**[Sandbox overrides]** (サンドボックス オーバーライド) セクションでサンドボックスを追加することでサンドボックスによるブロードキャストを制限できます。</span><span class="sxs-lookup"><span data-stu-id="b598b-108">You may either disable broadcasting everywhere by checking the box in the **Default** section, or you can restrict broadcasting by Sandbox by adding a sandbox in the **Sandbox overrides** section.</span></span>

<span data-ttu-id="b598b-109">**[Default]** (既定値) セクションのチェック ボックスをオンにすると、すべてのサービスとサンドボックスでこのタイトルのブロードキャストが制限されます。</span><span class="sxs-lookup"><span data-stu-id="b598b-109">Checking the box in the **Default** section restricts broadcasting for this title on all services and sandboxes.</span></span>

![既定のブロードキャストの制限](../../images/dev-center/privileges/default-privileges-check.JPG)

<span data-ttu-id="b598b-111">特定のサンドボックスでのブロードキャストを制限するには、**[Sandbox overrides]** (サンドボックス オーバーライド) セクションの **[追加]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="b598b-111">In order to restrict broadcasting on a particular sandbox click **Add** button in the **Sandbox overrides** section.</span></span> <span data-ttu-id="b598b-112">ドロップダウン リストからターゲット サンドボックスを選び、下のボックスをオンにして、そのタイトルのブロードキャストを選んだサンドボックスに制限します。</span><span class="sxs-lookup"><span data-stu-id="b598b-112">Choose the target sandbox from the dropdown list and check the box underneath to restrict broadcasting for that title on the chosen sandbox.</span></span> <span data-ttu-id="b598b-113">サンドボックス オーバーライドをオフまたは削除すると、ブロードキャストの制限を削除できます。</span><span class="sxs-lookup"><span data-stu-id="b598b-113">Sandbox overrides can be unchecked or deleted to remove restrictions on broadcasting.</span></span>

![サンドボックスのブロードキャストの制限](../../images/dev-center/privileges/sandbox-privileges-check.JPG)

<span data-ttu-id="b598b-115">**[保存]** をクリックし、これらの設定の構成変更を保存します。</span><span class="sxs-lookup"><span data-stu-id="b598b-115">Click the **Save** button to keep any configuration changes made for these settings.</span></span>

> [!NOTE]
> <span data-ttu-id="b598b-116">ブロードキャストを無効にするチェック ボックスをオンにすると、Xbox 本体または PC の Windows ゲームを使ったストリーミングのみ禁止されます。</span><span class="sxs-lookup"><span data-stu-id="b598b-116">Checking the box to disable broadcasting will only prohibit streaming done through Xbox consoles or the Windows game bar on PC.</span></span> <span data-ttu-id="b598b-117">このページにあるチェック ボックスをオンにしても、キャプチャ カードや他の外部のキャプチャまたはストリーミング サービスを使うことはできません。</span><span class="sxs-lookup"><span data-stu-id="b598b-117">Checking the box on this page does not prevent the use of capture cards or other external capture or streaming services.</span></span>