---
author: jnHs
Description: The Insights report in the Windows Dev Center dashboard
title: 分析レポート
ms.author: wdg-dev-content
ms.date: 06/01/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10、uwp、見解、傾向を示す、異常、異常、データの変更
ms.localizationpriority: medium
ms.openlocfilehash: be70dccbb7a12b65b9e7bbd07f27ae7ea3a578ff
ms.sourcegitcommit: 753dfcd0f9fdfc963579dd0b217b445c4b110a18
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/27/2018
ms.locfileid: "2861981"
---
# <a name="insights-report"></a><span data-ttu-id="38ed3-103">分析レポート</span><span class="sxs-lookup"><span data-stu-id="38ed3-103">Insights report</span></span>


<span data-ttu-id="38ed3-104">Windows デベロッパー センターのダッシュ ボードでの**分析**レポートでは、大きく変更 (増減特定メートル法)、買収、性、または利用状況のデータの最後の 30 日間に検出して強調表示します。</span><span class="sxs-lookup"><span data-stu-id="38ed3-104">The **Insights** report in the Windows Dev Center dashboard highlights significant changes (increases or decreases in a specific metric) that we detected over the last 30 days in your acquisitions, health, and/or usage data.</span></span> <span data-ttu-id="38ed3-105">これらのレポートのすべてのグラフを表示することがなく可能性のある重要な変更の概要を取得できます。</span><span class="sxs-lookup"><span data-stu-id="38ed3-105">This lets you get a quick look at potentially important changes without having to view all of the charts in each of these reports.</span></span>

> [!NOTE]
> <span data-ttu-id="38ed3-106">このレポートのデータでは、過去 30 日間について説明します。</span><span class="sxs-lookup"><span data-stu-id="38ed3-106">Data in this report covers the last 30 days.</span></span> <span data-ttu-id="38ed3-107">このレポートの別の期間を選択することはできません。</span><span class="sxs-lookup"><span data-stu-id="38ed3-107">You can't select a different time period for this report.</span></span>

<span data-ttu-id="38ed3-108">レポートには、3 つのタブにデータが並べ替えられます。**買収**、**正常性**を**使用**します。</span><span class="sxs-lookup"><span data-stu-id="38ed3-108">The report sorts data into three tabs: **Acquisitions**, **Health**, and **Usage**.</span></span> <span data-ttu-id="38ed3-109">これらの領域のいずれかの分析結果を表示するには、そのタブを選択します。</span><span class="sxs-lookup"><span data-stu-id="38ed3-109">To see insights for one of these areas, select its tab.</span></span>

<span data-ttu-id="38ed3-110">重要な変更を検出、データのときに、分析結果が表示されます。</span><span class="sxs-lookup"><span data-stu-id="38ed3-110">Insights are shown when we detect a significant change in your data.</span></span> <span data-ttu-id="38ed3-111">各洞察には、次の操作を説明します。</span><span class="sxs-lookup"><span data-stu-id="38ed3-111">For each insight, we'll show the following:</span></span>
- <span data-ttu-id="38ed3-112">**情報の種類**: で情報を得ることが検出された領域です。</span><span class="sxs-lookup"><span data-stu-id="38ed3-112">**Insight type**: The area in which the insight was detected.</span></span>
- <span data-ttu-id="38ed3-113">**値**: 特定のメトリックが大幅に変更する (または**すべて**全体の**情報の種類**に変更を適用する場合)。</span><span class="sxs-lookup"><span data-stu-id="38ed3-113">**Value**: The specific metric which changed significantly (or **All** if the change applies to the entire **Insight type**).</span></span>
- <span data-ttu-id="38ed3-114">**日時**: 日付変更わかりましたします。</span><span class="sxs-lookup"><span data-stu-id="38ed3-114">**Date**: The date on which we identified the change.</span></span> <span data-ttu-id="38ed3-115">この日付は、大幅に増加または減少前に、その曜日と比較してを検出して週の最後を表します。</span><span class="sxs-lookup"><span data-stu-id="38ed3-115">This date represents the end of the week in which we detected a significant increase or decrease compared to the week before that.</span></span>
- <span data-ttu-id="38ed3-116">**全体に影響を及ぼす**: 値が増加または減少、全体の顧客ベースの間でが割合します。</span><span class="sxs-lookup"><span data-stu-id="38ed3-116">**Overall impact**: The percentage that the value increased or decreased across your entire customer base.</span></span> <span data-ttu-id="38ed3-117">これにより、広範な方法を特定の変更の影響場合があります、特にに表示されるパーセンテージ情報と比較することを理解する**重要な投稿者**。</span><span class="sxs-lookup"><span data-stu-id="38ed3-117">This helps you understand how widespread the impact of a particular change may be, especially when comparing it to percentage info shown in **Top contributors.**</span></span>
- <span data-ttu-id="38ed3-118">**主要関係者**: 必要に応じて、特定のセグメント、パッケージ、または顧客を理解するのに役立つ識別するもう 1 つの変更に関連します。</span><span class="sxs-lookup"><span data-stu-id="38ed3-118">**Top contributors**: If applicable, the specific segment, package, or other identifying factor to help understand which customers the change is related to.</span></span> <span data-ttu-id="38ed3-119">たとえば、変更は、主に次の特定の市場から、または特定の種類のデバイスで検出があります。</span><span class="sxs-lookup"><span data-stu-id="38ed3-119">For example, a change may be detected primarily with customers from a specific market or on a certain device type.</span></span> <span data-ttu-id="38ed3-120">**正常性**データでは、特定のエラー ハッシュまたはパッケージのバージョンがあります。</span><span class="sxs-lookup"><span data-stu-id="38ed3-120">For **Health** data, this may include specific failure hashes or package versions.</span></span> <span data-ttu-id="38ed3-121">可能であれば、についても学習割合の値が増加または減少率のことです。</span><span class="sxs-lookup"><span data-stu-id="38ed3-121">Where applicable, we'll also show the percentage that the value increased or decreased for that factor.</span></span>
- <span data-ttu-id="38ed3-122">**操作**:</span><span class="sxs-lookup"><span data-stu-id="38ed3-122">**Action**:</span></span>
   - <span data-ttu-id="38ed3-123">全体 14 日間に把握までに、メートル法を変更する方法を示すグラフを表示する**14 日間の傾向を表示する**] を選びます。</span><span class="sxs-lookup"><span data-stu-id="38ed3-123">Select **Show 14-day trend** to view a chart showing how the metric changed over the entire 14 days leading up to the insight date.</span></span>
   - <span data-ttu-id="38ed3-124">フィードバックを提供してご登録している分析結果と正確に**正確なかどうかは、ご意見/** を選択します。</span><span class="sxs-lookup"><span data-stu-id="38ed3-124">Select **Tell us if this is accurate** to give us your feedback and let us know if the insights we've provided seem accurate.</span></span> <span data-ttu-id="38ed3-125">このご意見はここで説明するデータを向上させるために引き続き協力します。</span><span class="sxs-lookup"><span data-stu-id="38ed3-125">This feedback will help us to continue to improve the data we provide here.</span></span> 

