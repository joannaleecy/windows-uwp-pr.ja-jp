---
ms.assetid: 9347AD7C-3A90-4073-BFF4-9E8237398343
description: この記事では、UWP アプリ用のオーディオとビデオのコーデックおよび形式のサポートを示します。
title: サポートされているコーデック
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 02d8c67c92a070fbeaaab81ef6c5145dec90e411
ms.sourcegitcommit: 89ff8ff88ef58f4fe6d3b1368fe94f62e59118ad
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/30/2018
ms.locfileid: "8212744"
---
# <a name="supported-codecs"></a><span data-ttu-id="e53a2-104">サポートされているコーデック</span><span class="sxs-lookup"><span data-stu-id="e53a2-104">Supported codecs</span></span>

<span data-ttu-id="e53a2-105">この記事では、各デバイス ファミリの既定で、UWP アプリで利用可能なオーディオ、ビデオ、イメージのコーデックと形式を示します。</span><span class="sxs-lookup"><span data-stu-id="e53a2-105">This article lists the audio, video, and image codec and format availability for UWP apps by default for each device family.</span></span> <span data-ttu-id="e53a2-106">これらの表では、指定のデバイス ファミリの Windows 10 のインストールに含まれているコーデックを示していることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="e53a2-106">Note that these tables list the codecs that are included with the Windows 10 installation for the specified device family.</span></span> <span data-ttu-id="e53a2-107">ユーザーやアプリが、利用可能な追加のコーデックをインストールする場合があります。</span><span class="sxs-lookup"><span data-stu-id="e53a2-107">Users and apps can install additional codecs that may be available to use.</span></span> <span data-ttu-id="e53a2-108">実行時に、特定のデバイスで現在利用可能なコーデックのセットを照会できます。</span><span class="sxs-lookup"><span data-stu-id="e53a2-108">You can query at runtime for the set of codecs that are currently available for a specific device.</span></span> <span data-ttu-id="e53a2-109">詳しくは、「[デバイスにインストールされているコーデックの照会](codec-query.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e53a2-109">For more information, see [Query for codecs installed on a device](codec-query.md).</span></span>

<span data-ttu-id="e53a2-110">以下の表では、"D" はデコーダーのサポートを示し、"E" はエンコーダーのサポートを示します。</span><span class="sxs-lookup"><span data-stu-id="e53a2-110">In the tables below "D" indicates decoder support and "E" indicates encoder support.</span></span>

## <a name="audio-codec--format-support"></a><span data-ttu-id="e53a2-111">オーディオのコーデックおよび形式のサポート</span><span class="sxs-lookup"><span data-stu-id="e53a2-111">Audio codec & format support</span></span>

<span data-ttu-id="e53a2-112">次の表は、各デバイス ファミリのオーディオのコーデックと形式のサポートを示しています。</span><span class="sxs-lookup"><span data-stu-id="e53a2-112">The following tables show the audio codec and format support for each device family.</span></span>

> [!NOTE] 
> <span data-ttu-id="e53a2-113">AMR-NB のサポートが示されている場合、Server SKU ではこのコーデックがサポートされません。</span><span class="sxs-lookup"><span data-stu-id="e53a2-113">Where AMR-NB support is indicated, this codec is not supported on Server SKUs.</span></span>

 

### <a name="desktop"></a><span data-ttu-id="e53a2-114">デスクトップ</span><span class="sxs-lookup"><span data-stu-id="e53a2-114">Desktop</span></span>

<table>
<colgroup>
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="e53a2-115">コーデック/コンテナー</span><span class="sxs-lookup"><span data-stu-id="e53a2-115">Codec/Container</span></span></th>
<th align="left"><span data-ttu-id="e53a2-116">MPEG-4</span><span class="sxs-lookup"><span data-stu-id="e53a2-116">MPEG-4</span></span></th>
<th align="left"><span data-ttu-id="e53a2-117">MPEG-3</span><span class="sxs-lookup"><span data-stu-id="e53a2-117">MPEG-3</span></span></th>
<th align="left"><span data-ttu-id="e53a2-118">MPEG-2</span><span class="sxs-lookup"><span data-stu-id="e53a2-118">MPEG-2</span></span></th>
<th align="left"><span data-ttu-id="e53a2-119">ADTS</span><span class="sxs-lookup"><span data-stu-id="e53a2-119">ADTS</span></span></th>
<th align="left"><span data-ttu-id="e53a2-120">ASF</span><span class="sxs-lookup"><span data-stu-id="e53a2-120">ASF</span></span></th>
<th align="left"><span data-ttu-id="e53a2-121">RIFF</span><span class="sxs-lookup"><span data-stu-id="e53a2-121">RIFF</span></span></th>
<th align="left"><span data-ttu-id="e53a2-122">AVI</span><span class="sxs-lookup"><span data-stu-id="e53a2-122">AVI</span></span></th>
<th align="left"><span data-ttu-id="e53a2-123">AC-3</span><span class="sxs-lookup"><span data-stu-id="e53a2-123">AC-3</span></span></th>
<th align="left"><span data-ttu-id="e53a2-124">AMR</span><span class="sxs-lookup"><span data-stu-id="e53a2-124">AMR</span></span></th>
<th align="left"><span data-ttu-id="e53a2-125">3GP</span><span class="sxs-lookup"><span data-stu-id="e53a2-125">3GP</span></span></th>
<th align="left"><span data-ttu-id="e53a2-126">FLAC</span><span class="sxs-lookup"><span data-stu-id="e53a2-126">FLAC</span></span></th>
<th align="left"><span data-ttu-id="e53a2-127">WAV</span><span class="sxs-lookup"><span data-stu-id="e53a2-127">WAV</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="e53a2-128">HE-AAC v1/AAC+</span><span class="sxs-lookup"><span data-stu-id="e53a2-128">HE-AAC v1 / AAC+</span></span></td>
<td align="left"><span data-ttu-id="e53a2-129">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-129">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-130">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-130">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="e53a2-131">HE-AAC v2/eAAC+</span><span class="sxs-lookup"><span data-stu-id="e53a2-131">HE-AAC v2 / eAAC+</span></span></td>
<td align="left"><span data-ttu-id="e53a2-132">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-132">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-133">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-133">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="e53a2-134">AAC-LC</span><span class="sxs-lookup"><span data-stu-id="e53a2-134">AAC-LC</span></span></td>
<td align="left"><span data-ttu-id="e53a2-135">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-135">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-136">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-136">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="e53a2-137">AC3</span><span class="sxs-lookup"><span data-stu-id="e53a2-137">AC3</span></span></td>
<td align="left"><span data-ttu-id="e53a2-138">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-138">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-139">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-139">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-140">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-140">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="e53a2-141">EAC3/EC3</span><span class="sxs-lookup"><span data-stu-id="e53a2-141">EAC3 / EC3</span></span></td>
<td align="left"><span data-ttu-id="e53a2-142">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-142">D</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-143">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-143">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-144">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-144">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="e53a2-145">ALAC</span><span class="sxs-lookup"><span data-stu-id="e53a2-145">ALAC</span></span></td>
<td align="left"><span data-ttu-id="e53a2-146">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-146">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="e53a2-147">AMR-NB</span><span class="sxs-lookup"><span data-stu-id="e53a2-147">AMR-NB</span></span></td>
<td align="left"><span data-ttu-id="e53a2-148">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-148">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-149">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-149">D/E</span></span></td>
<td align="left"><span data-ttu-id="e53a2-150">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-150">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="e53a2-151">FLAC</span><span class="sxs-lookup"><span data-stu-id="e53a2-151">FLAC</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-152">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-152">D/E</span></span></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="e53a2-153">G.711 (A-Law、µ-law)</span><span class="sxs-lookup"><span data-stu-id="e53a2-153">G.711 (A-Law, µ-law)</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-154">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-154">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="e53a2-155">GSM 6.10</span><span class="sxs-lookup"><span data-stu-id="e53a2-155">GSM 6.10</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-156">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-156">D</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="e53a2-157">IMA ADPCM</span><span class="sxs-lookup"><span data-stu-id="e53a2-157">IMA ADPCM</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-158">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-158">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="e53a2-159">LPCM</span><span class="sxs-lookup"><span data-stu-id="e53a2-159">LPCM</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-160">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-160">D/E</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="e53a2-161">MP3</span><span class="sxs-lookup"><span data-stu-id="e53a2-161">MP3</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-162">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-162">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="e53a2-163">MPEG-1/2</span><span class="sxs-lookup"><span data-stu-id="e53a2-163">MPEG-1/2</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-164">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-164">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="e53a2-165">MS ADPCM</span><span class="sxs-lookup"><span data-stu-id="e53a2-165">MS ADPCM</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-166">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-166">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="e53a2-167">WMA 1/2/3</span><span class="sxs-lookup"><span data-stu-id="e53a2-167">WMA 1/2/3</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-168">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-168">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="e53a2-169">WMA Pro</span><span class="sxs-lookup"><span data-stu-id="e53a2-169">WMA Pro</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-170">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-170">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="e53a2-171">WMA Voice</span><span class="sxs-lookup"><span data-stu-id="e53a2-171">WMA Voice</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-172">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-172">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
</tbody>
</table>

 

### <a name="mobile"></a><span data-ttu-id="e53a2-173">モバイル</span><span class="sxs-lookup"><span data-stu-id="e53a2-173">Mobile</span></span>

<table>
<colgroup>
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="e53a2-174">コーデック/コンテナー</span><span class="sxs-lookup"><span data-stu-id="e53a2-174">Codec/Container</span></span></th>
<th align="left"><span data-ttu-id="e53a2-175">MPEG-4</span><span class="sxs-lookup"><span data-stu-id="e53a2-175">MPEG-4</span></span></th>
<th align="left"><span data-ttu-id="e53a2-176">MPEG-3</span><span class="sxs-lookup"><span data-stu-id="e53a2-176">MPEG-3</span></span></th>
<th align="left"><span data-ttu-id="e53a2-177">MPEG-2</span><span class="sxs-lookup"><span data-stu-id="e53a2-177">MPEG-2</span></span></th>
<th align="left"><span data-ttu-id="e53a2-178">ADTS</span><span class="sxs-lookup"><span data-stu-id="e53a2-178">ADTS</span></span></th>
<th align="left"><span data-ttu-id="e53a2-179">ASF</span><span class="sxs-lookup"><span data-stu-id="e53a2-179">ASF</span></span></th>
<th align="left"><span data-ttu-id="e53a2-180">RIFF</span><span class="sxs-lookup"><span data-stu-id="e53a2-180">RIFF</span></span></th>
<th align="left"><span data-ttu-id="e53a2-181">AVI</span><span class="sxs-lookup"><span data-stu-id="e53a2-181">AVI</span></span></th>
<th align="left"><span data-ttu-id="e53a2-182">AC-3</span><span class="sxs-lookup"><span data-stu-id="e53a2-182">AC-3</span></span></th>
<th align="left"><span data-ttu-id="e53a2-183">AMR</span><span class="sxs-lookup"><span data-stu-id="e53a2-183">AMR</span></span></th>
<th align="left"><span data-ttu-id="e53a2-184">3GP</span><span class="sxs-lookup"><span data-stu-id="e53a2-184">3GP</span></span></th>
<th align="left"><span data-ttu-id="e53a2-185">FLAC</span><span class="sxs-lookup"><span data-stu-id="e53a2-185">FLAC</span></span></th>
<th align="left"><span data-ttu-id="e53a2-186">WAV</span><span class="sxs-lookup"><span data-stu-id="e53a2-186">WAV</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="e53a2-187">HE-AAC v1/AAC+</span><span class="sxs-lookup"><span data-stu-id="e53a2-187">HE-AAC v1 / AAC+</span></span></td>
<td align="left"><span data-ttu-id="e53a2-188">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-188">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-189">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-189">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="e53a2-190">HE-AAC v2/eAAC+</span><span class="sxs-lookup"><span data-stu-id="e53a2-190">HE-AAC v2 / eAAC+</span></span></td>
<td align="left"><span data-ttu-id="e53a2-191">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-191">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-192">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-192">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="e53a2-193">AAC-LC</span><span class="sxs-lookup"><span data-stu-id="e53a2-193">AAC-LC</span></span></td>
<td align="left"><span data-ttu-id="e53a2-194">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-194">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-195">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-195">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="e53a2-196">AC3</span><span class="sxs-lookup"><span data-stu-id="e53a2-196">AC3</span></span></td>
<td align="left"><span data-ttu-id="e53a2-197">D (Lumia Icon、830、930、1520 のみ)</span><span class="sxs-lookup"><span data-stu-id="e53a2-197">D, Only on Lumia Icon, 830, 930, 1520</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-198">D (Lumia Icon、830、930、1520 のみ)</span><span class="sxs-lookup"><span data-stu-id="e53a2-198">D, Only on Lumia Icon, 830, 930, 1520</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-199">D (Lumia Icon、830、930、1520 のみ)</span><span class="sxs-lookup"><span data-stu-id="e53a2-199">D, Only on Lumia Icon, 830, 930, 1520</span></span></td>
<td align="left"><span data-ttu-id="e53a2-200">D (Lumia Icon、830、930、1520 のみ)</span><span class="sxs-lookup"><span data-stu-id="e53a2-200">D, Only on Lumia Icon, 830, 930, 1520</span></span></td>
<td align="left"><span data-ttu-id="e53a2-201">D (Lumia Icon、830、930、1520 のみ)</span><span class="sxs-lookup"><span data-stu-id="e53a2-201">D, Only on Lumia Icon, 830, 930, 1520</span></span></td>
<td align="left"><span data-ttu-id="e53a2-202">D (Lumia Icon、830、930、1520 のみ)</span><span class="sxs-lookup"><span data-stu-id="e53a2-202">D, Only on Lumia Icon, 830, 930, 1520</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="e53a2-203">EAC3/EC3</span><span class="sxs-lookup"><span data-stu-id="e53a2-203">EAC3 / EC3</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="e53a2-204">ALAC</span><span class="sxs-lookup"><span data-stu-id="e53a2-204">ALAC</span></span></td>
<td align="left"><span data-ttu-id="e53a2-205">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-205">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="e53a2-206">AMR-NB</span><span class="sxs-lookup"><span data-stu-id="e53a2-206">AMR-NB</span></span></td>
<td align="left"><span data-ttu-id="e53a2-207">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-207">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-208">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-208">D/E</span></span></td>
<td align="left"><span data-ttu-id="e53a2-209">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-209">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="e53a2-210">FLAC</span><span class="sxs-lookup"><span data-stu-id="e53a2-210">FLAC</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-211">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-211">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="e53a2-212">G.711 (A-Law、µ-law)</span><span class="sxs-lookup"><span data-stu-id="e53a2-212">G.711 (A-Law, µ-law)</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-213">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-213">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="e53a2-214">GSM 6.10</span><span class="sxs-lookup"><span data-stu-id="e53a2-214">GSM 6.10</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-215">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-215">D</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="e53a2-216">IMA ADPCM</span><span class="sxs-lookup"><span data-stu-id="e53a2-216">IMA ADPCM</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-217">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-217">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="e53a2-218">LPCM</span><span class="sxs-lookup"><span data-stu-id="e53a2-218">LPCM</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-219">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-219">D/E</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="e53a2-220">MP3</span><span class="sxs-lookup"><span data-stu-id="e53a2-220">MP3</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-221">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-221">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="e53a2-222">MPEG-1/2</span><span class="sxs-lookup"><span data-stu-id="e53a2-222">MPEG-1/2</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="e53a2-223">MS ADPCM</span><span class="sxs-lookup"><span data-stu-id="e53a2-223">MS ADPCM</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-224">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-224">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="e53a2-225">WMA 1/2/3</span><span class="sxs-lookup"><span data-stu-id="e53a2-225">WMA 1/2/3</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-226">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-226">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="e53a2-227">WMA Pro</span><span class="sxs-lookup"><span data-stu-id="e53a2-227">WMA Pro</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-228">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-228">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="e53a2-229">WMA Voice</span><span class="sxs-lookup"><span data-stu-id="e53a2-229">WMA Voice</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
</tbody>
</table>

 

### <a name="iot-core-x86"></a><span data-ttu-id="e53a2-230">IoT Core (x86)</span><span class="sxs-lookup"><span data-stu-id="e53a2-230">IoT Core (x86)</span></span>

<table>
<colgroup>
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="e53a2-231">コーデック/コンテナー</span><span class="sxs-lookup"><span data-stu-id="e53a2-231">Codec/Container</span></span></th>
<th align="left"><span data-ttu-id="e53a2-232">MPEG-4</span><span class="sxs-lookup"><span data-stu-id="e53a2-232">MPEG-4</span></span></th>
<th align="left"><span data-ttu-id="e53a2-233">MPEG-3</span><span class="sxs-lookup"><span data-stu-id="e53a2-233">MPEG-3</span></span></th>
<th align="left"><span data-ttu-id="e53a2-234">MPEG-2</span><span class="sxs-lookup"><span data-stu-id="e53a2-234">MPEG-2</span></span></th>
<th align="left"><span data-ttu-id="e53a2-235">ADTS</span><span class="sxs-lookup"><span data-stu-id="e53a2-235">ADTS</span></span></th>
<th align="left"><span data-ttu-id="e53a2-236">ASF</span><span class="sxs-lookup"><span data-stu-id="e53a2-236">ASF</span></span></th>
<th align="left"><span data-ttu-id="e53a2-237">RIFF</span><span class="sxs-lookup"><span data-stu-id="e53a2-237">RIFF</span></span></th>
<th align="left"><span data-ttu-id="e53a2-238">AVI</span><span class="sxs-lookup"><span data-stu-id="e53a2-238">AVI</span></span></th>
<th align="left"><span data-ttu-id="e53a2-239">AC-3</span><span class="sxs-lookup"><span data-stu-id="e53a2-239">AC-3</span></span></th>
<th align="left"><span data-ttu-id="e53a2-240">AMR</span><span class="sxs-lookup"><span data-stu-id="e53a2-240">AMR</span></span></th>
<th align="left"><span data-ttu-id="e53a2-241">3GP</span><span class="sxs-lookup"><span data-stu-id="e53a2-241">3GP</span></span></th>
<th align="left"><span data-ttu-id="e53a2-242">FLAC</span><span class="sxs-lookup"><span data-stu-id="e53a2-242">FLAC</span></span></th>
<th align="left"><span data-ttu-id="e53a2-243">WAV</span><span class="sxs-lookup"><span data-stu-id="e53a2-243">WAV</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="e53a2-244">HE-AAC v1/AAC+</span><span class="sxs-lookup"><span data-stu-id="e53a2-244">HE-AAC v1 / AAC+</span></span></td>
<td align="left"><span data-ttu-id="e53a2-245">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-245">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-246">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-246">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="e53a2-247">HE-AAC v2/eAAC+</span><span class="sxs-lookup"><span data-stu-id="e53a2-247">HE-AAC v2 / eAAC+</span></span></td>
<td align="left"><span data-ttu-id="e53a2-248">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-248">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-249">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-249">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="e53a2-250">AAC-LC</span><span class="sxs-lookup"><span data-stu-id="e53a2-250">AAC-LC</span></span></td>
<td align="left"><span data-ttu-id="e53a2-251">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-251">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-252">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-252">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="e53a2-253">AC3</span><span class="sxs-lookup"><span data-stu-id="e53a2-253">AC3</span></span></td>
<td align="left"><span data-ttu-id="e53a2-254">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-254">D</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-255">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-255">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-256">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-256">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="e53a2-257">EAC3/EC3</span><span class="sxs-lookup"><span data-stu-id="e53a2-257">EAC3 / EC3</span></span></td>
<td align="left"><span data-ttu-id="e53a2-258">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-258">D</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-259">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-259">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-260">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-260">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="e53a2-261">ALAC</span><span class="sxs-lookup"><span data-stu-id="e53a2-261">ALAC</span></span></td>
<td align="left"><span data-ttu-id="e53a2-262">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-262">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="e53a2-263">AMR-NB</span><span class="sxs-lookup"><span data-stu-id="e53a2-263">AMR-NB</span></span></td>
<td align="left"><span data-ttu-id="e53a2-264">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-264">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-265">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-265">D/E</span></span></td>
<td align="left"><span data-ttu-id="e53a2-266">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-266">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="e53a2-267">FLAC</span><span class="sxs-lookup"><span data-stu-id="e53a2-267">FLAC</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-268">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-268">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="e53a2-269">G.711 (A-Law、µ-law)</span><span class="sxs-lookup"><span data-stu-id="e53a2-269">G.711 (A-Law, µ-law)</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-270">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-270">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="e53a2-271">GSM 6.10</span><span class="sxs-lookup"><span data-stu-id="e53a2-271">GSM 6.10</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-272">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-272">D</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="e53a2-273">IMA ADPCM</span><span class="sxs-lookup"><span data-stu-id="e53a2-273">IMA ADPCM</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-274">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-274">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="e53a2-275">LPCM</span><span class="sxs-lookup"><span data-stu-id="e53a2-275">LPCM</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-276">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-276">D/E</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="e53a2-277">MP3</span><span class="sxs-lookup"><span data-stu-id="e53a2-277">MP3</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-278">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-278">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="e53a2-279">MPEG-1/2</span><span class="sxs-lookup"><span data-stu-id="e53a2-279">MPEG-1/2</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-280">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-280">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="e53a2-281">MS ADPCM</span><span class="sxs-lookup"><span data-stu-id="e53a2-281">MS ADPCM</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-282">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-282">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="e53a2-283">WMA 1/2/3</span><span class="sxs-lookup"><span data-stu-id="e53a2-283">WMA 1/2/3</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-284">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-284">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="e53a2-285">WMA Pro</span><span class="sxs-lookup"><span data-stu-id="e53a2-285">WMA Pro</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-286">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-286">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="e53a2-287">WMA Voice</span><span class="sxs-lookup"><span data-stu-id="e53a2-287">WMA Voice</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-288">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-288">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
</tbody>
</table>

 

### <a name="iot-core-arm"></a><span data-ttu-id="e53a2-289">IoT Core (ARM)</span><span class="sxs-lookup"><span data-stu-id="e53a2-289">IoT Core (ARM)</span></span>

<table>
<colgroup>
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="e53a2-290">コーデック/コンテナー</span><span class="sxs-lookup"><span data-stu-id="e53a2-290">Codec/Container</span></span></th>
<th align="left"><span data-ttu-id="e53a2-291">MPEG-4</span><span class="sxs-lookup"><span data-stu-id="e53a2-291">MPEG-4</span></span></th>
<th align="left"><span data-ttu-id="e53a2-292">MPEG-3</span><span class="sxs-lookup"><span data-stu-id="e53a2-292">MPEG-3</span></span></th>
<th align="left"><span data-ttu-id="e53a2-293">MPEG-2</span><span class="sxs-lookup"><span data-stu-id="e53a2-293">MPEG-2</span></span></th>
<th align="left"><span data-ttu-id="e53a2-294">ADTS</span><span class="sxs-lookup"><span data-stu-id="e53a2-294">ADTS</span></span></th>
<th align="left"><span data-ttu-id="e53a2-295">ASF</span><span class="sxs-lookup"><span data-stu-id="e53a2-295">ASF</span></span></th>
<th align="left"><span data-ttu-id="e53a2-296">RIFF</span><span class="sxs-lookup"><span data-stu-id="e53a2-296">RIFF</span></span></th>
<th align="left"><span data-ttu-id="e53a2-297">AVI</span><span class="sxs-lookup"><span data-stu-id="e53a2-297">AVI</span></span></th>
<th align="left"><span data-ttu-id="e53a2-298">AC-3</span><span class="sxs-lookup"><span data-stu-id="e53a2-298">AC-3</span></span></th>
<th align="left"><span data-ttu-id="e53a2-299">AMR</span><span class="sxs-lookup"><span data-stu-id="e53a2-299">AMR</span></span></th>
<th align="left"><span data-ttu-id="e53a2-300">3GP</span><span class="sxs-lookup"><span data-stu-id="e53a2-300">3GP</span></span></th>
<th align="left"><span data-ttu-id="e53a2-301">FLAC</span><span class="sxs-lookup"><span data-stu-id="e53a2-301">FLAC</span></span></th>
<th align="left"><span data-ttu-id="e53a2-302">WAV</span><span class="sxs-lookup"><span data-stu-id="e53a2-302">WAV</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="e53a2-303">HE-AAC v1/AAC+</span><span class="sxs-lookup"><span data-stu-id="e53a2-303">HE-AAC v1 / AAC+</span></span></td>
<td align="left"><span data-ttu-id="e53a2-304">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-304">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-305">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-305">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="e53a2-306">HE-AAC v2/eAAC+</span><span class="sxs-lookup"><span data-stu-id="e53a2-306">HE-AAC v2 / eAAC+</span></span></td>
<td align="left"><span data-ttu-id="e53a2-307">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-307">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-308">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-308">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="e53a2-309">AAC-LC</span><span class="sxs-lookup"><span data-stu-id="e53a2-309">AAC-LC</span></span></td>
<td align="left"><span data-ttu-id="e53a2-310">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-310">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-311">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-311">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="e53a2-312">AC3</span><span class="sxs-lookup"><span data-stu-id="e53a2-312">AC3</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="e53a2-313">EAC3/EC3</span><span class="sxs-lookup"><span data-stu-id="e53a2-313">EAC3 / EC3</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="e53a2-314">ALAC</span><span class="sxs-lookup"><span data-stu-id="e53a2-314">ALAC</span></span></td>
<td align="left"><span data-ttu-id="e53a2-315">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-315">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="e53a2-316">AMR-NB</span><span class="sxs-lookup"><span data-stu-id="e53a2-316">AMR-NB</span></span></td>
<td align="left"><span data-ttu-id="e53a2-317">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-317">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-318">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-318">D/E</span></span></td>
<td align="left"><span data-ttu-id="e53a2-319">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-319">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="e53a2-320">FLAC</span><span class="sxs-lookup"><span data-stu-id="e53a2-320">FLAC</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-321">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-321">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="e53a2-322">G.711 (A-Law、µ-law)</span><span class="sxs-lookup"><span data-stu-id="e53a2-322">G.711 (A-Law, µ-law)</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-323">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-323">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="e53a2-324">GSM 6.10</span><span class="sxs-lookup"><span data-stu-id="e53a2-324">GSM 6.10</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-325">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-325">D</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="e53a2-326">IMA ADPCM</span><span class="sxs-lookup"><span data-stu-id="e53a2-326">IMA ADPCM</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-327">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-327">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="e53a2-328">LPCM</span><span class="sxs-lookup"><span data-stu-id="e53a2-328">LPCM</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-329">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-329">D/E</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="e53a2-330">MP3</span><span class="sxs-lookup"><span data-stu-id="e53a2-330">MP3</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-331">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-331">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="e53a2-332">MPEG-1/2</span><span class="sxs-lookup"><span data-stu-id="e53a2-332">MPEG-1/2</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-333">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-333">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="e53a2-334">MS ADPCM</span><span class="sxs-lookup"><span data-stu-id="e53a2-334">MS ADPCM</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-335">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-335">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="e53a2-336">WMA 1/2/3</span><span class="sxs-lookup"><span data-stu-id="e53a2-336">WMA 1/2/3</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-337">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-337">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="e53a2-338">WMA Pro</span><span class="sxs-lookup"><span data-stu-id="e53a2-338">WMA Pro</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-339">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-339">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="e53a2-340">WMA Voice</span><span class="sxs-lookup"><span data-stu-id="e53a2-340">WMA Voice</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-341">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-341">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
</tbody>
</table>

 

### <a name="xbox"></a><span data-ttu-id="e53a2-342">Xbox</span><span class="sxs-lookup"><span data-stu-id="e53a2-342">XBox</span></span>

<table>
<colgroup>
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="e53a2-343">コーデック/コンテナー</span><span class="sxs-lookup"><span data-stu-id="e53a2-343">Codec/Container</span></span></th>
<th align="left"><span data-ttu-id="e53a2-344">MPEG-4</span><span class="sxs-lookup"><span data-stu-id="e53a2-344">MPEG-4</span></span></th>
<th align="left"><span data-ttu-id="e53a2-345">MPEG-3</span><span class="sxs-lookup"><span data-stu-id="e53a2-345">MPEG-3</span></span></th>
<th align="left"><span data-ttu-id="e53a2-346">MPEG-2</span><span class="sxs-lookup"><span data-stu-id="e53a2-346">MPEG-2</span></span></th>
<th align="left"><span data-ttu-id="e53a2-347">ADTS</span><span class="sxs-lookup"><span data-stu-id="e53a2-347">ADTS</span></span></th>
<th align="left"><span data-ttu-id="e53a2-348">ASF</span><span class="sxs-lookup"><span data-stu-id="e53a2-348">ASF</span></span></th>
<th align="left"><span data-ttu-id="e53a2-349">RIFF</span><span class="sxs-lookup"><span data-stu-id="e53a2-349">RIFF</span></span></th>
<th align="left"><span data-ttu-id="e53a2-350">AVI</span><span class="sxs-lookup"><span data-stu-id="e53a2-350">AVI</span></span></th>
<th align="left"><span data-ttu-id="e53a2-351">AC-3</span><span class="sxs-lookup"><span data-stu-id="e53a2-351">AC-3</span></span></th>
<th align="left"><span data-ttu-id="e53a2-352">AMR</span><span class="sxs-lookup"><span data-stu-id="e53a2-352">AMR</span></span></th>
<th align="left"><span data-ttu-id="e53a2-353">3GP</span><span class="sxs-lookup"><span data-stu-id="e53a2-353">3GP</span></span></th>
<th align="left"><span data-ttu-id="e53a2-354">FLAC</span><span class="sxs-lookup"><span data-stu-id="e53a2-354">FLAC</span></span></th>
<th align="left"><span data-ttu-id="e53a2-355">WAV</span><span class="sxs-lookup"><span data-stu-id="e53a2-355">WAV</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="e53a2-356">HE-AAC v1/AAC+</span><span class="sxs-lookup"><span data-stu-id="e53a2-356">HE-AAC v1 / AAC+</span></span></td>
<td align="left"><span data-ttu-id="e53a2-357">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-357">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-358">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-358">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="e53a2-359">HE-AAC v2/eAAC+</span><span class="sxs-lookup"><span data-stu-id="e53a2-359">HE-AAC v2 / eAAC+</span></span></td>
<td align="left"><span data-ttu-id="e53a2-360">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-360">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-361">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-361">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="e53a2-362">AAC-LC</span><span class="sxs-lookup"><span data-stu-id="e53a2-362">AAC-LC</span></span></td>
<td align="left"><span data-ttu-id="e53a2-363">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-363">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-364">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-364">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="e53a2-365">AC3</span><span class="sxs-lookup"><span data-stu-id="e53a2-365">AC3</span></span></td>
<td align="left"><span data-ttu-id="e53a2-366">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-366">D</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-367">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-367">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-368">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-368">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="e53a2-369">EAC3/EC3</span><span class="sxs-lookup"><span data-stu-id="e53a2-369">EAC3 / EC3</span></span></td>
<td align="left"><span data-ttu-id="e53a2-370">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-370">D</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-371">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-371">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-372">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-372">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="e53a2-373">ALAC</span><span class="sxs-lookup"><span data-stu-id="e53a2-373">ALAC</span></span></td>
<td align="left"><span data-ttu-id="e53a2-374">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-374">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="e53a2-375">AMR-NB</span><span class="sxs-lookup"><span data-stu-id="e53a2-375">AMR-NB</span></span></td>
<td align="left"><span data-ttu-id="e53a2-376">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-376">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-377">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-377">D/E</span></span></td>
<td align="left"><span data-ttu-id="e53a2-378">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-378">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="e53a2-379">FLAC</span><span class="sxs-lookup"><span data-stu-id="e53a2-379">FLAC</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-380">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-380">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="e53a2-381">G.711 (A-Law、µ-law)</span><span class="sxs-lookup"><span data-stu-id="e53a2-381">G.711 (A-Law, µ-law)</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-382">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-382">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="e53a2-383">GSM 6.10</span><span class="sxs-lookup"><span data-stu-id="e53a2-383">GSM 6.10</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-384">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-384">D</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="e53a2-385">IMA ADPCM</span><span class="sxs-lookup"><span data-stu-id="e53a2-385">IMA ADPCM</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-386">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-386">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="e53a2-387">LPCM</span><span class="sxs-lookup"><span data-stu-id="e53a2-387">LPCM</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-388">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-388">D/E</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="e53a2-389">MP3</span><span class="sxs-lookup"><span data-stu-id="e53a2-389">MP3</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-390">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-390">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="e53a2-391">MPEG-1/2</span><span class="sxs-lookup"><span data-stu-id="e53a2-391">MPEG-1/2</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-392">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-392">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="e53a2-393">MS ADPCM</span><span class="sxs-lookup"><span data-stu-id="e53a2-393">MS ADPCM</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-394">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-394">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="e53a2-395">WMA 1/2/3</span><span class="sxs-lookup"><span data-stu-id="e53a2-395">WMA 1/2/3</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-396">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-396">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="e53a2-397">WMA Pro</span><span class="sxs-lookup"><span data-stu-id="e53a2-397">WMA Pro</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-398">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-398">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="e53a2-399">WMA Voice</span><span class="sxs-lookup"><span data-stu-id="e53a2-399">WMA Voice</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-400">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-400">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
</tbody>
</table>

 

## <a name="video-codec--format-support"></a><span data-ttu-id="e53a2-401">ビデオのコーデックおよび形式のサポート</span><span class="sxs-lookup"><span data-stu-id="e53a2-401">Video codec & format support</span></span>

<span data-ttu-id="e53a2-402">次の表は、各デバイス ファミリのビデオのコーデックと形式のサポートを示しています。</span><span class="sxs-lookup"><span data-stu-id="e53a2-402">The following tables show the video codec and format support for each device family.</span></span>

> [!NOTE] 
> <span data-ttu-id="e53a2-403">H.265 のサポートが示されている場合、必ずしもデバイス ファミリ内のすべてのデバイスでサポートされるわけではありません。</span><span class="sxs-lookup"><span data-stu-id="e53a2-403">Where H.265 support is indicated, it is not necessarily supported by all devices within the device family.</span></span>
> <span data-ttu-id="e53a2-404">MPEG-2/MPEG-1 のサポートが示されている場合、オプションの Microsoft DVD ユニバーサル Windows アプリのインストールでのみサポートされます。</span><span class="sxs-lookup"><span data-stu-id="e53a2-404">Where MPEG-2/MPEG-1 support is indicated, it is only supported with the installation of the optional Microsoft DVD Universal Windows app.</span></span>

 

### <a name="desktop"></a><span data-ttu-id="e53a2-405">デスクトップ</span><span class="sxs-lookup"><span data-stu-id="e53a2-405">Desktop</span></span>

<table>
<colgroup>
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="e53a2-406">コーデック/コンテナー</span><span class="sxs-lookup"><span data-stu-id="e53a2-406">Codec/Container</span></span></th>
<th align="left"><span data-ttu-id="e53a2-407">FOURCC</span><span class="sxs-lookup"><span data-stu-id="e53a2-407">FOURCC</span></span></th>
<th align="left"><span data-ttu-id="e53a2-408">fMP4</span><span class="sxs-lookup"><span data-stu-id="e53a2-408">fMP4</span></span></th>
<th align="left"><span data-ttu-id="e53a2-409">MPEG-4</span><span class="sxs-lookup"><span data-stu-id="e53a2-409">MPEG-4</span></span></th>
<th align="left"><span data-ttu-id="e53a2-410">MPEG-2 PS</span><span class="sxs-lookup"><span data-stu-id="e53a2-410">MPEG-2 PS</span></span></th>
<th align="left"><span data-ttu-id="e53a2-411">MPEG-2 TS</span><span class="sxs-lookup"><span data-stu-id="e53a2-411">MPEG-2 TS</span></span></th>
<th align="left"><span data-ttu-id="e53a2-412">MPEG-1</span><span class="sxs-lookup"><span data-stu-id="e53a2-412">MPEG-1</span></span></th>
<th align="left"><span data-ttu-id="e53a2-413">3GPP</span><span class="sxs-lookup"><span data-stu-id="e53a2-413">3GPP</span></span></th>
<th align="left"><span data-ttu-id="e53a2-414">3GPP2</span><span class="sxs-lookup"><span data-stu-id="e53a2-414">3GPP2</span></span></th>
<th align="left"><span data-ttu-id="e53a2-415">AVCHD</span><span class="sxs-lookup"><span data-stu-id="e53a2-415">AVCHD</span></span></th>
<th align="left"><span data-ttu-id="e53a2-416">ASF</span><span class="sxs-lookup"><span data-stu-id="e53a2-416">ASF</span></span></th>
<th align="left"><span data-ttu-id="e53a2-417">AVI</span><span class="sxs-lookup"><span data-stu-id="e53a2-417">AVI</span></span></th>
<th align="left"><span data-ttu-id="e53a2-418">MKV</span><span class="sxs-lookup"><span data-stu-id="e53a2-418">MKV</span></span></th>
<th align="left"><span data-ttu-id="e53a2-419">DV</span><span class="sxs-lookup"><span data-stu-id="e53a2-419">DV</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="e53a2-420">MPEG-1</span><span class="sxs-lookup"><span data-stu-id="e53a2-420">MPEG-1</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-421">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-421">D/E</span></span></td>
<td align="left"><span data-ttu-id="e53a2-422">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-422">D/E</span></span></td>
<td align="left"><span data-ttu-id="e53a2-423">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-423">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-424">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-424">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-425">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-425">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="e53a2-426">MPEG-2</span><span class="sxs-lookup"><span data-stu-id="e53a2-426">MPEG-2</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-427">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-427">D/E</span></span></td>
<td align="left"><span data-ttu-id="e53a2-428">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-428">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-429">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-429">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-430">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-430">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="e53a2-431">MPEG-4 (Part 2)</span><span class="sxs-lookup"><span data-stu-id="e53a2-431">MPEG-4 (Part 2)</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-432">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-432">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-433">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-433">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-434">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-434">D</span></span></td>
<td align="left"><span data-ttu-id="e53a2-435">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-435">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="e53a2-436">H.265</span><span class="sxs-lookup"><span data-stu-id="e53a2-436">H.265</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-437">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-437">D</span></span></td>
<td align="left"><span data-ttu-id="e53a2-438">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-438">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-439">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-439">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="e53a2-440">H.264</span><span class="sxs-lookup"><span data-stu-id="e53a2-440">H.264</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-441">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-441">D/E</span></span></td>
<td align="left"><span data-ttu-id="e53a2-442">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-442">D/E</span></span></td>
<td align="left"><span data-ttu-id="e53a2-443">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-443">D/E</span></span></td>
<td align="left"><span data-ttu-id="e53a2-444">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-444">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-445">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-445">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-446">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-446">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-447">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-447">D</span></span></td>
<td align="left"><span data-ttu-id="e53a2-448">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-448">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="e53a2-449">H.263</span><span class="sxs-lookup"><span data-stu-id="e53a2-449">H.263</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-450">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-450">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-451">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-451">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-452">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-452">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="e53a2-453">VC-1</span><span class="sxs-lookup"><span data-stu-id="e53a2-453">VC-1</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-454">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-454">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-455">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-455">D</span></span></td>
<td align="left"><span data-ttu-id="e53a2-456">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-456">D</span></span></td>
<td align="left"><span data-ttu-id="e53a2-457">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-457">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="e53a2-458">WMV7/8/9</span><span class="sxs-lookup"><span data-stu-id="e53a2-458">WMV7/8/9</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-459">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-459">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-460">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-460">D/E</span></span></td>
<td align="left"><span data-ttu-id="e53a2-461">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-461">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="e53a2-462">WMV9 Screen</span><span class="sxs-lookup"><span data-stu-id="e53a2-462">WMV9 Screen</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-463">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-463">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-464">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-464">D</span></span></td>
<td align="left"><span data-ttu-id="e53a2-465">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-465">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="e53a2-466">DV</span><span class="sxs-lookup"><span data-stu-id="e53a2-466">DV</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-467">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-467">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-468">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-468">D</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-469">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-469">D</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="e53a2-470">モーション JPEG</span><span class="sxs-lookup"><span data-stu-id="e53a2-470">Motion JPEG</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-471">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-471">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-472">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-472">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
</tbody>
</table>

 

### <a name="mobile"></a><span data-ttu-id="e53a2-473">モバイル</span><span class="sxs-lookup"><span data-stu-id="e53a2-473">Mobile</span></span>

<table>
<colgroup>
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="e53a2-474">コーデック/コンテナー</span><span class="sxs-lookup"><span data-stu-id="e53a2-474">Codec/Container</span></span></th>
<th align="left"><span data-ttu-id="e53a2-475">FOURCC</span><span class="sxs-lookup"><span data-stu-id="e53a2-475">FOURCC</span></span></th>
<th align="left"><span data-ttu-id="e53a2-476">fMP4</span><span class="sxs-lookup"><span data-stu-id="e53a2-476">fMP4</span></span></th>
<th align="left"><span data-ttu-id="e53a2-477">MPEG-4</span><span class="sxs-lookup"><span data-stu-id="e53a2-477">MPEG-4</span></span></th>
<th align="left"><span data-ttu-id="e53a2-478">MPEG-2 PS</span><span class="sxs-lookup"><span data-stu-id="e53a2-478">MPEG-2 PS</span></span></th>
<th align="left"><span data-ttu-id="e53a2-479">MPEG-2 TS</span><span class="sxs-lookup"><span data-stu-id="e53a2-479">MPEG-2 TS</span></span></th>
<th align="left"><span data-ttu-id="e53a2-480">MPEG-1</span><span class="sxs-lookup"><span data-stu-id="e53a2-480">MPEG-1</span></span></th>
<th align="left"><span data-ttu-id="e53a2-481">3GPP</span><span class="sxs-lookup"><span data-stu-id="e53a2-481">3GPP</span></span></th>
<th align="left"><span data-ttu-id="e53a2-482">3GPP2</span><span class="sxs-lookup"><span data-stu-id="e53a2-482">3GPP2</span></span></th>
<th align="left"><span data-ttu-id="e53a2-483">AVCHD</span><span class="sxs-lookup"><span data-stu-id="e53a2-483">AVCHD</span></span></th>
<th align="left"><span data-ttu-id="e53a2-484">ASF</span><span class="sxs-lookup"><span data-stu-id="e53a2-484">ASF</span></span></th>
<th align="left"><span data-ttu-id="e53a2-485">AVI</span><span class="sxs-lookup"><span data-stu-id="e53a2-485">AVI</span></span></th>
<th align="left"><span data-ttu-id="e53a2-486">MKV</span><span class="sxs-lookup"><span data-stu-id="e53a2-486">MKV</span></span></th>
<th align="left"><span data-ttu-id="e53a2-487">DV</span><span class="sxs-lookup"><span data-stu-id="e53a2-487">DV</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="e53a2-488">MPEG-1</span><span class="sxs-lookup"><span data-stu-id="e53a2-488">MPEG-1</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="e53a2-489">MPEG-2</span><span class="sxs-lookup"><span data-stu-id="e53a2-489">MPEG-2</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="e53a2-490">MPEG-4 (Part 2)</span><span class="sxs-lookup"><span data-stu-id="e53a2-490">MPEG-4 (Part 2)</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-491">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-491">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-492">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-492">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-493">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-493">D</span></span></td>
<td align="left"><span data-ttu-id="e53a2-494">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-494">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="e53a2-495">H.265</span><span class="sxs-lookup"><span data-stu-id="e53a2-495">H.265</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-496">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-496">D</span></span></td>
<td align="left"><span data-ttu-id="e53a2-497">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-497">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-498">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-498">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="e53a2-499">H.264</span><span class="sxs-lookup"><span data-stu-id="e53a2-499">H.264</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-500">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-500">D/E</span></span></td>
<td align="left"><span data-ttu-id="e53a2-501">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-501">D/E</span></span></td>
<td align="left"><span data-ttu-id="e53a2-502">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-502">D/E</span></span></td>
<td align="left"><span data-ttu-id="e53a2-503">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-503">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-504">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-504">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-505">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-505">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-506">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-506">D</span></span></td>
<td align="left"><span data-ttu-id="e53a2-507">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-507">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="e53a2-508">H.263</span><span class="sxs-lookup"><span data-stu-id="e53a2-508">H.263</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-509">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-509">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-510">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-510">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-511">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-511">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="e53a2-512">VC-1</span><span class="sxs-lookup"><span data-stu-id="e53a2-512">VC-1</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-513">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-513">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-514">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-514">D</span></span></td>
<td align="left"><span data-ttu-id="e53a2-515">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-515">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="e53a2-516">WMV7/8/9</span><span class="sxs-lookup"><span data-stu-id="e53a2-516">WMV7/8/9</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="e53a2-517">WMV9 Screen</span><span class="sxs-lookup"><span data-stu-id="e53a2-517">WMV9 Screen</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="e53a2-518">DV</span><span class="sxs-lookup"><span data-stu-id="e53a2-518">DV</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="e53a2-519">モーション JPEG</span><span class="sxs-lookup"><span data-stu-id="e53a2-519">Motion JPEG</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-520">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-520">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-521">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-521">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
</tbody>
</table>

 

### <a name="iot-core-x86"></a><span data-ttu-id="e53a2-522">IoT Core (x86)</span><span class="sxs-lookup"><span data-stu-id="e53a2-522">IoT Core (x86)</span></span>

<table>
<colgroup>
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="e53a2-523">コーデック/コンテナー</span><span class="sxs-lookup"><span data-stu-id="e53a2-523">Codec/Container</span></span></th>
<th align="left"><span data-ttu-id="e53a2-524">FOURCC</span><span class="sxs-lookup"><span data-stu-id="e53a2-524">FOURCC</span></span></th>
<th align="left"><span data-ttu-id="e53a2-525">fMP4</span><span class="sxs-lookup"><span data-stu-id="e53a2-525">fMP4</span></span></th>
<th align="left"><span data-ttu-id="e53a2-526">MPEG-4</span><span class="sxs-lookup"><span data-stu-id="e53a2-526">MPEG-4</span></span></th>
<th align="left"><span data-ttu-id="e53a2-527">MPEG-2 PS</span><span class="sxs-lookup"><span data-stu-id="e53a2-527">MPEG-2 PS</span></span></th>
<th align="left"><span data-ttu-id="e53a2-528">MPEG-2 TS</span><span class="sxs-lookup"><span data-stu-id="e53a2-528">MPEG-2 TS</span></span></th>
<th align="left"><span data-ttu-id="e53a2-529">MPEG-1</span><span class="sxs-lookup"><span data-stu-id="e53a2-529">MPEG-1</span></span></th>
<th align="left"><span data-ttu-id="e53a2-530">3GPP</span><span class="sxs-lookup"><span data-stu-id="e53a2-530">3GPP</span></span></th>
<th align="left"><span data-ttu-id="e53a2-531">3GPP2</span><span class="sxs-lookup"><span data-stu-id="e53a2-531">3GPP2</span></span></th>
<th align="left"><span data-ttu-id="e53a2-532">AVCHD</span><span class="sxs-lookup"><span data-stu-id="e53a2-532">AVCHD</span></span></th>
<th align="left"><span data-ttu-id="e53a2-533">ASF</span><span class="sxs-lookup"><span data-stu-id="e53a2-533">ASF</span></span></th>
<th align="left"><span data-ttu-id="e53a2-534">AVI</span><span class="sxs-lookup"><span data-stu-id="e53a2-534">AVI</span></span></th>
<th align="left"><span data-ttu-id="e53a2-535">MKV</span><span class="sxs-lookup"><span data-stu-id="e53a2-535">MKV</span></span></th>
<th align="left"><span data-ttu-id="e53a2-536">DV</span><span class="sxs-lookup"><span data-stu-id="e53a2-536">DV</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="e53a2-537">MPEG-1</span><span class="sxs-lookup"><span data-stu-id="e53a2-537">MPEG-1</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="e53a2-538">MPEG-2</span><span class="sxs-lookup"><span data-stu-id="e53a2-538">MPEG-2</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="e53a2-539">MPEG-4 (Part 2)</span><span class="sxs-lookup"><span data-stu-id="e53a2-539">MPEG-4 (Part 2)</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-540">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-540">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-541">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-541">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-542">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-542">D</span></span></td>
<td align="left"><span data-ttu-id="e53a2-543">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-543">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="e53a2-544">H.265</span><span class="sxs-lookup"><span data-stu-id="e53a2-544">H.265</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-545">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-545">D</span></span></td>
<td align="left"><span data-ttu-id="e53a2-546">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-546">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-547">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-547">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="e53a2-548">H.264</span><span class="sxs-lookup"><span data-stu-id="e53a2-548">H.264</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-549">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-549">D/E</span></span></td>
<td align="left"><span data-ttu-id="e53a2-550">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-550">D/E</span></span></td>
<td align="left"><span data-ttu-id="e53a2-551">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-551">D/E</span></span></td>
<td align="left"><span data-ttu-id="e53a2-552">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-552">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-553">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-553">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-554">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-554">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-555">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-555">D</span></span></td>
<td align="left"><span data-ttu-id="e53a2-556">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-556">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="e53a2-557">H.263</span><span class="sxs-lookup"><span data-stu-id="e53a2-557">H.263</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-558">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-558">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-559">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-559">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-560">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-560">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="e53a2-561">VC-1</span><span class="sxs-lookup"><span data-stu-id="e53a2-561">VC-1</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-562">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-562">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-563">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-563">D</span></span></td>
<td align="left"><span data-ttu-id="e53a2-564">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-564">D</span></span></td>
<td align="left"><span data-ttu-id="e53a2-565">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-565">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="e53a2-566">WMV7/8/9</span><span class="sxs-lookup"><span data-stu-id="e53a2-566">WMV7/8/9</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-567">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-567">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-568">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-568">D</span></span></td>
<td align="left"><span data-ttu-id="e53a2-569">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-569">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="e53a2-570">WMV9 Screen</span><span class="sxs-lookup"><span data-stu-id="e53a2-570">WMV9 Screen</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-571">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-571">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-572">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-572">D</span></span></td>
<td align="left"><span data-ttu-id="e53a2-573">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-573">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="e53a2-574">DV</span><span class="sxs-lookup"><span data-stu-id="e53a2-574">DV</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="e53a2-575">モーション JPEG</span><span class="sxs-lookup"><span data-stu-id="e53a2-575">Motion JPEG</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-576">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-576">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-577">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-577">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
</tbody>
</table>

 

### <a name="iot-arm"></a><span data-ttu-id="e53a2-578">IoT (ARM)</span><span class="sxs-lookup"><span data-stu-id="e53a2-578">IoT (ARM)</span></span>

<table>
<colgroup>
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="e53a2-579">コーデック/コンテナー</span><span class="sxs-lookup"><span data-stu-id="e53a2-579">Codec/Container</span></span></th>
<th align="left"><span data-ttu-id="e53a2-580">FOURCC</span><span class="sxs-lookup"><span data-stu-id="e53a2-580">FOURCC</span></span></th>
<th align="left"><span data-ttu-id="e53a2-581">fMP4</span><span class="sxs-lookup"><span data-stu-id="e53a2-581">fMP4</span></span></th>
<th align="left"><span data-ttu-id="e53a2-582">MPEG-4</span><span class="sxs-lookup"><span data-stu-id="e53a2-582">MPEG-4</span></span></th>
<th align="left"><span data-ttu-id="e53a2-583">MPEG-2 PS</span><span class="sxs-lookup"><span data-stu-id="e53a2-583">MPEG-2 PS</span></span></th>
<th align="left"><span data-ttu-id="e53a2-584">MPEG-2 TS</span><span class="sxs-lookup"><span data-stu-id="e53a2-584">MPEG-2 TS</span></span></th>
<th align="left"><span data-ttu-id="e53a2-585">MPEG-1</span><span class="sxs-lookup"><span data-stu-id="e53a2-585">MPEG-1</span></span></th>
<th align="left"><span data-ttu-id="e53a2-586">3GPP</span><span class="sxs-lookup"><span data-stu-id="e53a2-586">3GPP</span></span></th>
<th align="left"><span data-ttu-id="e53a2-587">3GPP2</span><span class="sxs-lookup"><span data-stu-id="e53a2-587">3GPP2</span></span></th>
<th align="left"><span data-ttu-id="e53a2-588">AVCHD</span><span class="sxs-lookup"><span data-stu-id="e53a2-588">AVCHD</span></span></th>
<th align="left"><span data-ttu-id="e53a2-589">ASF</span><span class="sxs-lookup"><span data-stu-id="e53a2-589">ASF</span></span></th>
<th align="left"><span data-ttu-id="e53a2-590">AVI</span><span class="sxs-lookup"><span data-stu-id="e53a2-590">AVI</span></span></th>
<th align="left"><span data-ttu-id="e53a2-591">MKV</span><span class="sxs-lookup"><span data-stu-id="e53a2-591">MKV</span></span></th>
<th align="left"><span data-ttu-id="e53a2-592">DV</span><span class="sxs-lookup"><span data-stu-id="e53a2-592">DV</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="e53a2-593">MPEG-1</span><span class="sxs-lookup"><span data-stu-id="e53a2-593">MPEG-1</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="e53a2-594">MPEG-2</span><span class="sxs-lookup"><span data-stu-id="e53a2-594">MPEG-2</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="e53a2-595">MPEG-4 (Part 2)</span><span class="sxs-lookup"><span data-stu-id="e53a2-595">MPEG-4 (Part 2)</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="e53a2-596">H.265</span><span class="sxs-lookup"><span data-stu-id="e53a2-596">H.265</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-597">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-597">D</span></span></td>
<td align="left"><span data-ttu-id="e53a2-598">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-598">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-599">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-599">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="e53a2-600">H.264</span><span class="sxs-lookup"><span data-stu-id="e53a2-600">H.264</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-601">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-601">D/E</span></span></td>
<td align="left"><span data-ttu-id="e53a2-602">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-602">D/E</span></span></td>
<td align="left"><span data-ttu-id="e53a2-603">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-603">D/E</span></span></td>
<td align="left"><span data-ttu-id="e53a2-604">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-604">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-605">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-605">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-606">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-606">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-607">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-607">D</span></span></td>
<td align="left"><span data-ttu-id="e53a2-608">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-608">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="e53a2-609">H.263</span><span class="sxs-lookup"><span data-stu-id="e53a2-609">H.263</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="e53a2-610">VC-1</span><span class="sxs-lookup"><span data-stu-id="e53a2-610">VC-1</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-611">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-611">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-612">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-612">D</span></span></td>
<td align="left"><span data-ttu-id="e53a2-613">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-613">D</span></span></td>
<td align="left"><span data-ttu-id="e53a2-614">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-614">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="e53a2-615">WMV7/8/9</span><span class="sxs-lookup"><span data-stu-id="e53a2-615">WMV7/8/9</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-616">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-616">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-617">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-617">D</span></span></td>
<td align="left"><span data-ttu-id="e53a2-618">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-618">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="e53a2-619">WMV9 Screen</span><span class="sxs-lookup"><span data-stu-id="e53a2-619">WMV9 Screen</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="e53a2-620">DV</span><span class="sxs-lookup"><span data-stu-id="e53a2-620">DV</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="e53a2-621">モーション JPEG</span><span class="sxs-lookup"><span data-stu-id="e53a2-621">Motion JPEG</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-622">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-622">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-623">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-623">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
</tbody>
</table>

 

### <a name="xbox"></a><span data-ttu-id="e53a2-624">Xbox</span><span class="sxs-lookup"><span data-stu-id="e53a2-624">XBox</span></span>

<table>
<colgroup>
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
<col width="7%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="e53a2-625">コーデック/コンテナー</span><span class="sxs-lookup"><span data-stu-id="e53a2-625">Codec/Container</span></span></th>
<th align="left"><span data-ttu-id="e53a2-626">FOURCC</span><span class="sxs-lookup"><span data-stu-id="e53a2-626">FOURCC</span></span></th>
<th align="left"><span data-ttu-id="e53a2-627">fMP4</span><span class="sxs-lookup"><span data-stu-id="e53a2-627">fMP4</span></span></th>
<th align="left"><span data-ttu-id="e53a2-628">MPEG-4</span><span class="sxs-lookup"><span data-stu-id="e53a2-628">MPEG-4</span></span></th>
<th align="left"><span data-ttu-id="e53a2-629">MPEG-2 PS</span><span class="sxs-lookup"><span data-stu-id="e53a2-629">MPEG-2 PS</span></span></th>
<th align="left"><span data-ttu-id="e53a2-630">MPEG-2 TS</span><span class="sxs-lookup"><span data-stu-id="e53a2-630">MPEG-2 TS</span></span></th>
<th align="left"><span data-ttu-id="e53a2-631">MPEG-1</span><span class="sxs-lookup"><span data-stu-id="e53a2-631">MPEG-1</span></span></th>
<th align="left"><span data-ttu-id="e53a2-632">3GPP</span><span class="sxs-lookup"><span data-stu-id="e53a2-632">3GPP</span></span></th>
<th align="left"><span data-ttu-id="e53a2-633">3GPP2</span><span class="sxs-lookup"><span data-stu-id="e53a2-633">3GPP2</span></span></th>
<th align="left"><span data-ttu-id="e53a2-634">AVCHD</span><span class="sxs-lookup"><span data-stu-id="e53a2-634">AVCHD</span></span></th>
<th align="left"><span data-ttu-id="e53a2-635">ASF</span><span class="sxs-lookup"><span data-stu-id="e53a2-635">ASF</span></span></th>
<th align="left"><span data-ttu-id="e53a2-636">AVI</span><span class="sxs-lookup"><span data-stu-id="e53a2-636">AVI</span></span></th>
<th align="left"><span data-ttu-id="e53a2-637">MKV</span><span class="sxs-lookup"><span data-stu-id="e53a2-637">MKV</span></span></th>
<th align="left"><span data-ttu-id="e53a2-638">DV</span><span class="sxs-lookup"><span data-stu-id="e53a2-638">DV</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="e53a2-639">MPEG-1</span><span class="sxs-lookup"><span data-stu-id="e53a2-639">MPEG-1</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-640">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-640">D/E</span></span></td>
<td align="left"><span data-ttu-id="e53a2-641">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-641">D/E</span></span></td>
<td align="left"><span data-ttu-id="e53a2-642">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-642">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-643">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-643">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-644">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-644">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="e53a2-645">MPEG-2</span><span class="sxs-lookup"><span data-stu-id="e53a2-645">MPEG-2</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-646">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-646">D/E</span></span></td>
<td align="left"><span data-ttu-id="e53a2-647">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-647">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-648">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-648">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-649">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-649">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="e53a2-650">MPEG-4 (Part 2)</span><span class="sxs-lookup"><span data-stu-id="e53a2-650">MPEG-4 (Part 2)</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-651">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-651">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-652">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-652">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-653">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-653">D</span></span></td>
<td align="left"><span data-ttu-id="e53a2-654">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-654">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="e53a2-655">H.265</span><span class="sxs-lookup"><span data-stu-id="e53a2-655">H.265</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-656">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-656">D</span></span></td>
<td align="left"><span data-ttu-id="e53a2-657">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-657">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-658">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-658">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="e53a2-659">H.264</span><span class="sxs-lookup"><span data-stu-id="e53a2-659">H.264</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-660">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-660">D/E</span></span></td>
<td align="left"><span data-ttu-id="e53a2-661">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-661">D/E</span></span></td>
<td align="left"><span data-ttu-id="e53a2-662">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-662">D/E</span></span></td>
<td align="left"><span data-ttu-id="e53a2-663">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-663">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-664">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-664">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-665">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-665">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-666">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-666">D</span></span></td>
<td align="left"><span data-ttu-id="e53a2-667">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-667">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="e53a2-668">H.263</span><span class="sxs-lookup"><span data-stu-id="e53a2-668">H.263</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-669">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-669">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-670">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-670">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-671">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-671">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="e53a2-672">VC-1</span><span class="sxs-lookup"><span data-stu-id="e53a2-672">VC-1</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-673">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-673">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-674">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-674">D</span></span></td>
<td align="left"><span data-ttu-id="e53a2-675">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-675">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="e53a2-676">WMV7/8/9</span><span class="sxs-lookup"><span data-stu-id="e53a2-676">WMV7/8/9</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="e53a2-677">WMV9 Screen</span><span class="sxs-lookup"><span data-stu-id="e53a2-677">WMV9 Screen</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="e53a2-678">DV</span><span class="sxs-lookup"><span data-stu-id="e53a2-678">DV</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="e53a2-679">モーション JPEG</span><span class="sxs-lookup"><span data-stu-id="e53a2-679">Motion JPEG</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-680">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-680">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="e53a2-681">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-681">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
</tbody>
</table>

## <a name="image-codec--format-support"></a><span data-ttu-id="e53a2-682">イメージのコーデックおよび形式のサポート</span><span class="sxs-lookup"><span data-stu-id="e53a2-682">Image codec & format support</span></span> 

<table>
<colgroup>
<col width="7%" />
<col width="7%" />
<col width="7%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="e53a2-683">コーデック</span><span class="sxs-lookup"><span data-stu-id="e53a2-683">Codec</span></span></th>
<th align="left"><span data-ttu-id="e53a2-684">デスクトップ</span><span class="sxs-lookup"><span data-stu-id="e53a2-684">Desktop</span></span></th>
<th align="left"><span data-ttu-id="e53a2-685">他のデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="e53a2-685">Other device families</span></span></th>
</tr>
</thead>
<tr class="odd">
<td align="left"><span data-ttu-id="e53a2-686">BMP</span><span class="sxs-lookup"><span data-stu-id="e53a2-686">BMP</span></span></td>
<td align="left"><span data-ttu-id="e53a2-687">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-687">D/E</span></span></td>
<td align="left"><span data-ttu-id="e53a2-688">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-688">D/E</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="e53a2-689">DDS</span><span class="sxs-lookup"><span data-stu-id="e53a2-689">DDS</span></span></td>
<td align="left"><span data-ttu-id="e53a2-690">D/E<sup>1</sup></span><span class="sxs-lookup"><span data-stu-id="e53a2-690">D/E<sup>1</sup></span></span></td>
<td align="left"><span data-ttu-id="e53a2-691">D/E<sup>1</sup></span><span class="sxs-lookup"><span data-stu-id="e53a2-691">D/E<sup>1</sup></span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="e53a2-692">DNG</span><span class="sxs-lookup"><span data-stu-id="e53a2-692">DNG</span></span></td>
<td align="left"><span data-ttu-id="e53a2-693">D<sup>2</sup></span><span class="sxs-lookup"><span data-stu-id="e53a2-693">D<sup>2</sup></span></span></td>
<td align="left"><span data-ttu-id="e53a2-694">D<sup>2</sup></span><span class="sxs-lookup"><span data-stu-id="e53a2-694">D<sup>2</sup></span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="e53a2-695">GIF</span><span class="sxs-lookup"><span data-stu-id="e53a2-695">GIF</span></span></td>
<td align="left"><span data-ttu-id="e53a2-696">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-696">D/E</span></span></td>
<td align="left"><span data-ttu-id="e53a2-697">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-697">D/E</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="e53a2-698">ICO</span><span class="sxs-lookup"><span data-stu-id="e53a2-698">ICO</span></span></td>
<td align="left"><span data-ttu-id="e53a2-699">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-699">D</span></span></td>
<td align="left"><span data-ttu-id="e53a2-700">D</span><span class="sxs-lookup"><span data-stu-id="e53a2-700">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="e53a2-701">JPEG</span><span class="sxs-lookup"><span data-stu-id="e53a2-701">JPEG</span></span></td>
<td align="left"><span data-ttu-id="e53a2-702">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-702">D/E</span></span></td>
<td align="left"><span data-ttu-id="e53a2-703">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-703">D/E</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="e53a2-704">JPEG-XR</span><span class="sxs-lookup"><span data-stu-id="e53a2-704">JPEG-XR</span></span></td>
<td align="left"><span data-ttu-id="e53a2-705">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-705">D/E</span></span></td>
<td align="left"><span data-ttu-id="e53a2-706">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-706">D/E</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="e53a2-707">PNG</span><span class="sxs-lookup"><span data-stu-id="e53a2-707">PNG</span></span></td>
<td align="left"><span data-ttu-id="e53a2-708">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-708">D/E</span></span></td>
<td align="left"><span data-ttu-id="e53a2-709">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-709">D/E</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="e53a2-710">TIFF</span><span class="sxs-lookup"><span data-stu-id="e53a2-710">TIFF</span></span></td>
<td align="left"><span data-ttu-id="e53a2-711">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-711">D/E</span></span></td>
<td align="left"><span data-ttu-id="e53a2-712">D/E</span><span class="sxs-lookup"><span data-stu-id="e53a2-712">D/E</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="e53a2-713">RAW 形式のカメラ</span><span class="sxs-lookup"><span data-stu-id="e53a2-713">Camera RAW</span></span></td>
<td align="left"><span data-ttu-id="e53a2-714">D<sup>3</sup></span><span class="sxs-lookup"><span data-stu-id="e53a2-714">D<sup>3</sup></span></span></td>
<td align="left"><span data-ttu-id="e53a2-715">なし</span><span class="sxs-lookup"><span data-stu-id="e53a2-715">No</span></span></td>
</tr>
</table>

<span data-ttu-id="e53a2-716"><sup>1</sup> BC5 圧縮による BC1 を使用した DDS イメージがサポートされています。</span><span class="sxs-lookup"><span data-stu-id="e53a2-716"><sup>1</sup> DDS images using BC1 through BC5 compression are supported.</span></span>  
<span data-ttu-id="e53a2-717"><sup>2</sup> 非 RAW 形式の埋め込みプレビューを含む DNG イメージがサポートされています。</span><span class="sxs-lookup"><span data-stu-id="e53a2-717"><sup>2</sup> DNG images with a non-RAW embedded preview are supported.</span></span>  
<span data-ttu-id="e53a2-718"><sup>3</sup> 特定のカメラの RAW 形式のみがサポートされています。</span><span class="sxs-lookup"><span data-stu-id="e53a2-718"><sup>3</sup> Only certain camera RAW formats are supported.</span></span>  

<span data-ttu-id="e53a2-719">イメージ コーデックの詳細については、「[ネイティブ WIC コーデック](https://msdn.microsoft.com/library/windows/desktop/gg430027.aspx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e53a2-719">For more information on image codecs, see [Native WIC Codecs](https://msdn.microsoft.com/library/windows/desktop/gg430027.aspx).</span></span>