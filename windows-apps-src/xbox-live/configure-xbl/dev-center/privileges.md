---
title: デベロッパー センターでの特権の構成
author: aablackm
description: Windows デベロッパー センターで特権を構成する方法について説明します。
ms.author: aablackm
ms.date: 04/09/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
ms.localizationpriority: low
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, 特権, Windows デベロッパー センター
ms.openlocfilehash: 77b779bfd4ffcbff31267e93c9475948825a2b00
ms.sourcegitcommit: 91511d2d1dc8ab74b566aaeab3ef2139e7ed4945
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/30/2018
---
# <a name="configure-privileges-on-windows-development-center"></a><span data-ttu-id="cfa30-104">Windows デベロッパー センターでの特権の構成</span><span class="sxs-lookup"><span data-stu-id="cfa30-104">Configure Privileges on Windows Development Center</span></span>

<span data-ttu-id="cfa30-105">特権の構成ページには、[Mixer](https://mixer.com/) などのストリーミング サービスへのタイトルのストリーミングがゲーマーに制限されるかどうかが示されます。</span><span class="sxs-lookup"><span data-stu-id="cfa30-105">The Privileges configuration page dictates whether or not gamers will be restricted from streaming your title to streaming services like [Mixer](https://mixer.com/).</span></span> <span data-ttu-id="cfa30-106">既定では、どのストリーミング プラットフォームでもブロードキャストが制限されません。このページは、ブロードキャストを制限する場合のみ変更してください。</span><span class="sxs-lookup"><span data-stu-id="cfa30-106">By default your game will not restrict broadcasting on any streaming platform, changes to this page are only required if you would like to restrict broadcasting.</span></span> <span data-ttu-id="cfa30-107">ブロードキャストは、2 つの方法で制限できます。</span><span class="sxs-lookup"><span data-stu-id="cfa30-107">You can restrict broadcasting in two ways.</span></span> <span data-ttu-id="cfa30-108">**[Default]** (既定値) セクションのチェック ボックスをオンにすることであらゆるプラットフォームでブロードキャストを無効にするか、**[Sandbox overrides]** (サンドボックス オーバーライド) セクションでサンドボックスを追加することでサンドボックスによるブロードキャストを制限できます。</span><span class="sxs-lookup"><span data-stu-id="cfa30-108">You may either disable broadcasting everywhere by checking the box in the **Default** section, or you can restrict broadcasting by Sandbox by adding a sandbox in the **Sandbox overrides** section.</span></span>

<span data-ttu-id="cfa30-109">**[Default]** (既定値) セクションのチェック ボックスをオンにすると、すべてのサービスとサンドボックスでこのタイトルのブロードキャストが制限されます。</span><span class="sxs-lookup"><span data-stu-id="cfa30-109">Checking the box in the **Default** section restricts broadcasting for this title on all services and sandboxes.</span></span>

![既定のブロードキャストの制限](../../images/dev-center/privileges/default-privileges-check.JPG)

<span data-ttu-id="cfa30-111">特定のサンドボックスでのブロードキャストを制限するには、**[Sandbox overrides]** (サンドボックス オーバーライド) セクションの **[追加]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="cfa30-111">In order to restrict broadcasting on a particular sandbox click **Add** button in the **Sandbox overrides** section.</span></span> <span data-ttu-id="cfa30-112">ドロップダウン リストからターゲット サンドボックスを選び、下のボックスをオンにして、そのタイトルのブロードキャストを選んだサンドボックスに制限します。</span><span class="sxs-lookup"><span data-stu-id="cfa30-112">Choose the target sandbox from the dropdown list and check the box underneath to restrict broadcasting for that title on the chosen sandbox.</span></span> <span data-ttu-id="cfa30-113">サンドボックス オーバーライドをオフまたは削除すると、ブロードキャストの制限を削除できます。</span><span class="sxs-lookup"><span data-stu-id="cfa30-113">Sandbox overrides can be unchecked or deleted to remove restrictions on broadcasting.</span></span>

![サンドボックスのブロードキャストの制限](../../images/dev-center/privileges/sandbox-privileges-check.JPG)

<span data-ttu-id="cfa30-115">**[保存]** をクリックし、これらの設定の構成変更を保存します。</span><span class="sxs-lookup"><span data-stu-id="cfa30-115">Click the **Save** button to keep any configuration changes made for these settings.</span></span>

> [!NOTE]
> <span data-ttu-id="cfa30-116">ブロードキャストを無効にするチェック ボックスをオンにすると、Xbox 本体または PC の Windows ゲームを使ったストリーミングのみ禁止されます。</span><span class="sxs-lookup"><span data-stu-id="cfa30-116">Checking the box to disable broadcasting will only prohibit streaming done through Xbox consoles or the Windows game bar on PC.</span></span> <span data-ttu-id="cfa30-117">このページにあるチェック ボックスをオンにしても、キャプチャ カードや他の外部のキャプチャまたはストリーミング サービスを使うことはできません。</span><span class="sxs-lookup"><span data-stu-id="cfa30-117">Checking the box on this page does not prevent the use of capture cards or other external capture or streaming services.</span></span>