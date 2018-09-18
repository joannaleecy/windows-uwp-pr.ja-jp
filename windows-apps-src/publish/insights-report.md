---
author: jnHs
Description: The Insights report in the Windows Dev Center dashboard
title: インサイト レポート
ms.author: wdg-dev-content
ms.date: 06/01/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10、uwp、インサイト、トレンド、異常、異常、データの変更
ms.localizationpriority: medium
ms.openlocfilehash: be70dccbb7a12b65b9e7bbd07f27ae7ea3a578ff
ms.sourcegitcommit: f5321b525034e2b3af202709e9b942ad5557e193
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/18/2018
ms.locfileid: "4016084"
---
# <a name="insights-report"></a><span data-ttu-id="19c42-103">インサイト レポート</span><span class="sxs-lookup"><span data-stu-id="19c42-103">Insights report</span></span>


<span data-ttu-id="19c42-104">Windows デベロッパー センター ダッシュ ボードで**インサイト**レポートでは、大幅な変更 (増加または特定のメトリックの増減)、取得、正常性, や使用状況データの過去 30 日間経由で検出されましたが強調表示されます。</span><span class="sxs-lookup"><span data-stu-id="19c42-104">The **Insights** report in the Windows Dev Center dashboard highlights significant changes (increases or decreases in a specific metric) that we detected over the last 30 days in your acquisitions, health, and/or usage data.</span></span> <span data-ttu-id="19c42-105">これらのレポートのそれぞれですべてのグラフを表示することがなく可能性のある重要な変更について簡単に説明を取得できます。</span><span class="sxs-lookup"><span data-stu-id="19c42-105">This lets you get a quick look at potentially important changes without having to view all of the charts in each of these reports.</span></span>

> [!NOTE]
> <span data-ttu-id="19c42-106">このレポートのデータには、過去 30 日間について説明します。</span><span class="sxs-lookup"><span data-stu-id="19c42-106">Data in this report covers the last 30 days.</span></span> <span data-ttu-id="19c42-107">このレポートの別の期間を選択することはできません。</span><span class="sxs-lookup"><span data-stu-id="19c42-107">You can't select a different time period for this report.</span></span>

<span data-ttu-id="19c42-108">レポートは、次の 3 つのタブにデータを並べ替えます:**取得**、**正常性**、および**使用量**。</span><span class="sxs-lookup"><span data-stu-id="19c42-108">The report sorts data into three tabs: **Acquisitions**, **Health**, and **Usage**.</span></span> <span data-ttu-id="19c42-109">これらの領域のいずれかの情報を確認するには、そのタブを選択します。</span><span class="sxs-lookup"><span data-stu-id="19c42-109">To see insights for one of these areas, select its tab.</span></span>

<span data-ttu-id="19c42-110">データの大幅な変更が検出されると、情報が表示されます。</span><span class="sxs-lookup"><span data-stu-id="19c42-110">Insights are shown when we detect a significant change in your data.</span></span> <span data-ttu-id="19c42-111">各力は、次の操作を説明します。</span><span class="sxs-lookup"><span data-stu-id="19c42-111">For each insight, we'll show the following:</span></span>
- <span data-ttu-id="19c42-112">**インサイトの種類**: 領域の情報を得ることが検出されました。</span><span class="sxs-lookup"><span data-stu-id="19c42-112">**Insight type**: The area in which the insight was detected.</span></span>
- <span data-ttu-id="19c42-113">**値**: 特定のメトリックが大幅に変更する (または**すべて** **Insight 種類**全体に変更が適用される場合)。</span><span class="sxs-lookup"><span data-stu-id="19c42-113">**Value**: The specific metric which changed significantly (or **All** if the change applies to the entire **Insight type**).</span></span>
- <span data-ttu-id="19c42-114">**日付**: 日の変更を識別します。</span><span class="sxs-lookup"><span data-stu-id="19c42-114">**Date**: The date on which we identified the change.</span></span> <span data-ttu-id="19c42-115">この日付が大幅に増加または減少それより前に、の週との比較を検出しました週の終わりを表します。</span><span class="sxs-lookup"><span data-stu-id="19c42-115">This date represents the end of the week in which we detected a significant increase or decrease compared to the week before that.</span></span>
- <span data-ttu-id="19c42-116">**全体的な影響を与える**: する値が増加または減少して、全顧客ベースの間での割合を示します。</span><span class="sxs-lookup"><span data-stu-id="19c42-116">**Overall impact**: The percentage that the value increased or decreased across your entire customer base.</span></span> <span data-ttu-id="19c42-117">これは、方法広範囲にわたる特定の変更の影響することが、パーセンテージ情報に表示されることと比較するときに特にを理解するのに役立ちます**上の作成者**。</span><span class="sxs-lookup"><span data-stu-id="19c42-117">This helps you understand how widespread the impact of a particular change may be, especially when comparing it to percentage info shown in **Top contributors.**</span></span>
- <span data-ttu-id="19c42-118">**最上位の作成者**: 特定のセグメント、パッケージ、またはユーザーの理解に役立つその他の識別要素に、変更に関連する、該当する場合。</span><span class="sxs-lookup"><span data-stu-id="19c42-118">**Top contributors**: If applicable, the specific segment, package, or other identifying factor to help understand which customers the change is related to.</span></span> <span data-ttu-id="19c42-119">たとえば、変更は、主に、特定の市場から、または特定の種類のデバイスでのユーザーと検出があります。</span><span class="sxs-lookup"><span data-stu-id="19c42-119">For example, a change may be detected primarily with customers from a specific market or on a certain device type.</span></span> <span data-ttu-id="19c42-120">**正常性**データは、特定の障害ハッシュまたはパッケージのバージョンがあります。</span><span class="sxs-lookup"><span data-stu-id="19c42-120">For **Health** data, this may include specific failure hashes or package versions.</span></span> <span data-ttu-id="19c42-121">該当する場合、値が増加または、その要素の減少が割合も表示されます。</span><span class="sxs-lookup"><span data-stu-id="19c42-121">Where applicable, we'll also show the percentage that the value increased or decreased for that factor.</span></span>
- <span data-ttu-id="19c42-122">**アクション**:</span><span class="sxs-lookup"><span data-stu-id="19c42-122">**Action**:</span></span>
   - <span data-ttu-id="19c42-123">インサイトの日付に至るまで全体の 14 日間のメトリックの変更を示すグラフを表示する**表示 14 日の傾向**を選択します。</span><span class="sxs-lookup"><span data-stu-id="19c42-123">Select **Show 14-day trend** to view a chart showing how the metric changed over the entire 14 days leading up to the insight date.</span></span>
   - <span data-ttu-id="19c42-124">フィードバックをお知らせが用意されていますインサイトと正確に**聞かせかどうかは、正確**に選択します。</span><span class="sxs-lookup"><span data-stu-id="19c42-124">Select **Tell us if this is accurate** to give us your feedback and let us know if the insights we've provided seem accurate.</span></span> <span data-ttu-id="19c42-125">このフィードバックはここに入力データを向上させるために続行することに役立ちます。</span><span class="sxs-lookup"><span data-stu-id="19c42-125">This feedback will help us to continue to improve the data we provide here.</span></span> 

