---
ms.assetid: 9347AD7C-3A90-4073-BFF4-9E8237398343
description: この記事では、UWP アプリ用のオーディオとビデオのコーデックおよび形式のサポートを示します。
title: サポートされるコーデック
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 02d8c67c92a070fbeaaab81ef6c5145dec90e411
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57631357"
---
# <a name="supported-codecs"></a><span data-ttu-id="c5aed-104">サポートされるコーデック</span><span class="sxs-lookup"><span data-stu-id="c5aed-104">Supported codecs</span></span>

<span data-ttu-id="c5aed-105">この記事では、各デバイス ファミリの既定で、UWP アプリで利用可能なオーディオ、ビデオ、イメージのコーデックと形式を示します。</span><span class="sxs-lookup"><span data-stu-id="c5aed-105">This article lists the audio, video, and image codec and format availability for UWP apps by default for each device family.</span></span> <span data-ttu-id="c5aed-106">これらの表では、指定のデバイス ファミリの Windows 10 のインストールに含まれているコーデックを示していることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="c5aed-106">Note that these tables list the codecs that are included with the Windows 10 installation for the specified device family.</span></span> <span data-ttu-id="c5aed-107">ユーザーやアプリが、利用可能な追加のコーデックをインストールする場合があります。</span><span class="sxs-lookup"><span data-stu-id="c5aed-107">Users and apps can install additional codecs that may be available to use.</span></span> <span data-ttu-id="c5aed-108">実行時に、特定のデバイスで現在利用可能なコーデックのセットを照会できます。</span><span class="sxs-lookup"><span data-stu-id="c5aed-108">You can query at runtime for the set of codecs that are currently available for a specific device.</span></span> <span data-ttu-id="c5aed-109">詳しくは、「[デバイスにインストールされているコーデックの照会](codec-query.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c5aed-109">For more information, see [Query for codecs installed on a device](codec-query.md).</span></span>

<span data-ttu-id="c5aed-110">以下の表では、"D" はデコーダーのサポートを示し、"E" はエンコーダーのサポートを示します。</span><span class="sxs-lookup"><span data-stu-id="c5aed-110">In the tables below "D" indicates decoder support and "E" indicates encoder support.</span></span>

## <a name="audio-codec--format-support"></a><span data-ttu-id="c5aed-111">オーディオのコーデックおよび形式のサポート</span><span class="sxs-lookup"><span data-stu-id="c5aed-111">Audio codec & format support</span></span>

<span data-ttu-id="c5aed-112">次の表は、各デバイス ファミリのオーディオのコーデックと形式のサポートを示しています。</span><span class="sxs-lookup"><span data-stu-id="c5aed-112">The following tables show the audio codec and format support for each device family.</span></span>

> [!NOTE] 
> <span data-ttu-id="c5aed-113">AMR-NB のサポートが示されている場合、Server SKU ではこのコーデックがサポートされません。</span><span class="sxs-lookup"><span data-stu-id="c5aed-113">Where AMR-NB support is indicated, this codec is not supported on Server SKUs.</span></span>

 

### <a name="desktop"></a><span data-ttu-id="c5aed-114">Desktop</span><span class="sxs-lookup"><span data-stu-id="c5aed-114">Desktop</span></span>

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
<th align="left"><span data-ttu-id="c5aed-115">コーデック/コンテナー</span><span class="sxs-lookup"><span data-stu-id="c5aed-115">Codec/Container</span></span></th>
<th align="left"><span data-ttu-id="c5aed-116">MPEG-4</span><span class="sxs-lookup"><span data-stu-id="c5aed-116">MPEG-4</span></span></th>
<th align="left"><span data-ttu-id="c5aed-117">MPEG-3</span><span class="sxs-lookup"><span data-stu-id="c5aed-117">MPEG-3</span></span></th>
<th align="left"><span data-ttu-id="c5aed-118">MPEG-2</span><span class="sxs-lookup"><span data-stu-id="c5aed-118">MPEG-2</span></span></th>
<th align="left"><span data-ttu-id="c5aed-119">ADTS</span><span class="sxs-lookup"><span data-stu-id="c5aed-119">ADTS</span></span></th>
<th align="left"><span data-ttu-id="c5aed-120">ASF</span><span class="sxs-lookup"><span data-stu-id="c5aed-120">ASF</span></span></th>
<th align="left"><span data-ttu-id="c5aed-121">RIFF</span><span class="sxs-lookup"><span data-stu-id="c5aed-121">RIFF</span></span></th>
<th align="left"><span data-ttu-id="c5aed-122">AVI</span><span class="sxs-lookup"><span data-stu-id="c5aed-122">AVI</span></span></th>
<th align="left"><span data-ttu-id="c5aed-123">AC-3</span><span class="sxs-lookup"><span data-stu-id="c5aed-123">AC-3</span></span></th>
<th align="left"><span data-ttu-id="c5aed-124">AMR</span><span class="sxs-lookup"><span data-stu-id="c5aed-124">AMR</span></span></th>
<th align="left"><span data-ttu-id="c5aed-125">3GP</span><span class="sxs-lookup"><span data-stu-id="c5aed-125">3GP</span></span></th>
<th align="left"><span data-ttu-id="c5aed-126">FLAC</span><span class="sxs-lookup"><span data-stu-id="c5aed-126">FLAC</span></span></th>
<th align="left"><span data-ttu-id="c5aed-127">WAV</span><span class="sxs-lookup"><span data-stu-id="c5aed-127">WAV</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="c5aed-128">HE-AAC v1/AAC+</span><span class="sxs-lookup"><span data-stu-id="c5aed-128">HE-AAC v1 / AAC+</span></span></td>
<td align="left"><span data-ttu-id="c5aed-129">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-129">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-130">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-130">D</span></span></td>
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
<td align="left"><span data-ttu-id="c5aed-131">HE-AAC v2/eAAC+</span><span class="sxs-lookup"><span data-stu-id="c5aed-131">HE-AAC v2 / eAAC+</span></span></td>
<td align="left"><span data-ttu-id="c5aed-132">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-132">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-133">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-133">D</span></span></td>
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
<td align="left"><span data-ttu-id="c5aed-134">AAC-LC</span><span class="sxs-lookup"><span data-stu-id="c5aed-134">AAC-LC</span></span></td>
<td align="left"><span data-ttu-id="c5aed-135">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-135">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-136">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-136">D</span></span></td>
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
<td align="left"><span data-ttu-id="c5aed-137">AC3</span><span class="sxs-lookup"><span data-stu-id="c5aed-137">AC3</span></span></td>
<td align="left"><span data-ttu-id="c5aed-138">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-138">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-139">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-139">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-140">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-140">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="c5aed-141">EAC3/EC3</span><span class="sxs-lookup"><span data-stu-id="c5aed-141">EAC3 / EC3</span></span></td>
<td align="left"><span data-ttu-id="c5aed-142">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-142">D</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-143">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-143">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-144">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-144">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="c5aed-145">ALAC</span><span class="sxs-lookup"><span data-stu-id="c5aed-145">ALAC</span></span></td>
<td align="left"><span data-ttu-id="c5aed-146">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-146">D/E</span></span></td>
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
<td align="left"><span data-ttu-id="c5aed-147">AMR-NB</span><span class="sxs-lookup"><span data-stu-id="c5aed-147">AMR-NB</span></span></td>
<td align="left"><span data-ttu-id="c5aed-148">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-148">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-149">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-149">D/E</span></span></td>
<td align="left"><span data-ttu-id="c5aed-150">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-150">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="c5aed-151">FLAC</span><span class="sxs-lookup"><span data-stu-id="c5aed-151">FLAC</span></span></td>
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
<td align="left"><span data-ttu-id="c5aed-152">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-152">D/E</span></span></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="c5aed-153">G.711 (A-Law、µ-law)</span><span class="sxs-lookup"><span data-stu-id="c5aed-153">G.711 (A-Law, µ-law)</span></span></td>
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
<td align="left"><span data-ttu-id="c5aed-154">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-154">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="c5aed-155">GSM 6.10</span><span class="sxs-lookup"><span data-stu-id="c5aed-155">GSM 6.10</span></span></td>
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
<td align="left"><span data-ttu-id="c5aed-156">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-156">D</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="c5aed-157">IMA ADPCM</span><span class="sxs-lookup"><span data-stu-id="c5aed-157">IMA ADPCM</span></span></td>
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
<td align="left"><span data-ttu-id="c5aed-158">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-158">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="c5aed-159">LPCM</span><span class="sxs-lookup"><span data-stu-id="c5aed-159">LPCM</span></span></td>
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
<td align="left"><span data-ttu-id="c5aed-160">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-160">D/E</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="c5aed-161">MP3</span><span class="sxs-lookup"><span data-stu-id="c5aed-161">MP3</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-162">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-162">D/E</span></span></td>
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
<td align="left"><span data-ttu-id="c5aed-163">MPEG-1/2</span><span class="sxs-lookup"><span data-stu-id="c5aed-163">MPEG-1/2</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-164">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-164">D</span></span></td>
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
<td align="left"><span data-ttu-id="c5aed-165">MS ADPCM</span><span class="sxs-lookup"><span data-stu-id="c5aed-165">MS ADPCM</span></span></td>
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
<td align="left"><span data-ttu-id="c5aed-166">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-166">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="c5aed-167">WMA 1/2/3</span><span class="sxs-lookup"><span data-stu-id="c5aed-167">WMA 1/2/3</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-168">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-168">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="c5aed-169">WMA Pro</span><span class="sxs-lookup"><span data-stu-id="c5aed-169">WMA Pro</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-170">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-170">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="c5aed-171">WMA Voice</span><span class="sxs-lookup"><span data-stu-id="c5aed-171">WMA Voice</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-172">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-172">D/E</span></span></td>
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

 

### <a name="mobile"></a><span data-ttu-id="c5aed-173">モバイル</span><span class="sxs-lookup"><span data-stu-id="c5aed-173">Mobile</span></span>

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
<th align="left"><span data-ttu-id="c5aed-174">コーデック/コンテナー</span><span class="sxs-lookup"><span data-stu-id="c5aed-174">Codec/Container</span></span></th>
<th align="left"><span data-ttu-id="c5aed-175">MPEG-4</span><span class="sxs-lookup"><span data-stu-id="c5aed-175">MPEG-4</span></span></th>
<th align="left"><span data-ttu-id="c5aed-176">MPEG-3</span><span class="sxs-lookup"><span data-stu-id="c5aed-176">MPEG-3</span></span></th>
<th align="left"><span data-ttu-id="c5aed-177">MPEG-2</span><span class="sxs-lookup"><span data-stu-id="c5aed-177">MPEG-2</span></span></th>
<th align="left"><span data-ttu-id="c5aed-178">ADTS</span><span class="sxs-lookup"><span data-stu-id="c5aed-178">ADTS</span></span></th>
<th align="left"><span data-ttu-id="c5aed-179">ASF</span><span class="sxs-lookup"><span data-stu-id="c5aed-179">ASF</span></span></th>
<th align="left"><span data-ttu-id="c5aed-180">RIFF</span><span class="sxs-lookup"><span data-stu-id="c5aed-180">RIFF</span></span></th>
<th align="left"><span data-ttu-id="c5aed-181">AVI</span><span class="sxs-lookup"><span data-stu-id="c5aed-181">AVI</span></span></th>
<th align="left"><span data-ttu-id="c5aed-182">AC-3</span><span class="sxs-lookup"><span data-stu-id="c5aed-182">AC-3</span></span></th>
<th align="left"><span data-ttu-id="c5aed-183">AMR</span><span class="sxs-lookup"><span data-stu-id="c5aed-183">AMR</span></span></th>
<th align="left"><span data-ttu-id="c5aed-184">3GP</span><span class="sxs-lookup"><span data-stu-id="c5aed-184">3GP</span></span></th>
<th align="left"><span data-ttu-id="c5aed-185">FLAC</span><span class="sxs-lookup"><span data-stu-id="c5aed-185">FLAC</span></span></th>
<th align="left"><span data-ttu-id="c5aed-186">WAV</span><span class="sxs-lookup"><span data-stu-id="c5aed-186">WAV</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="c5aed-187">HE-AAC v1/AAC+</span><span class="sxs-lookup"><span data-stu-id="c5aed-187">HE-AAC v1 / AAC+</span></span></td>
<td align="left"><span data-ttu-id="c5aed-188">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-188">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-189">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-189">D</span></span></td>
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
<td align="left"><span data-ttu-id="c5aed-190">HE-AAC v2/eAAC+</span><span class="sxs-lookup"><span data-stu-id="c5aed-190">HE-AAC v2 / eAAC+</span></span></td>
<td align="left"><span data-ttu-id="c5aed-191">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-191">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-192">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-192">D</span></span></td>
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
<td align="left"><span data-ttu-id="c5aed-193">AAC-LC</span><span class="sxs-lookup"><span data-stu-id="c5aed-193">AAC-LC</span></span></td>
<td align="left"><span data-ttu-id="c5aed-194">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-194">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-195">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-195">D</span></span></td>
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
<td align="left"><span data-ttu-id="c5aed-196">AC3</span><span class="sxs-lookup"><span data-stu-id="c5aed-196">AC3</span></span></td>
<td align="left"><span data-ttu-id="c5aed-197">D (Lumia Icon、830、930、1520 のみ)</span><span class="sxs-lookup"><span data-stu-id="c5aed-197">D, Only on Lumia Icon, 830, 930, 1520</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-198">D (Lumia Icon、830、930、1520 のみ)</span><span class="sxs-lookup"><span data-stu-id="c5aed-198">D, Only on Lumia Icon, 830, 930, 1520</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-199">D (Lumia Icon、830、930、1520 のみ)</span><span class="sxs-lookup"><span data-stu-id="c5aed-199">D, Only on Lumia Icon, 830, 930, 1520</span></span></td>
<td align="left"><span data-ttu-id="c5aed-200">D (Lumia Icon、830、930、1520 のみ)</span><span class="sxs-lookup"><span data-stu-id="c5aed-200">D, Only on Lumia Icon, 830, 930, 1520</span></span></td>
<td align="left"><span data-ttu-id="c5aed-201">D (Lumia Icon、830、930、1520 のみ)</span><span class="sxs-lookup"><span data-stu-id="c5aed-201">D, Only on Lumia Icon, 830, 930, 1520</span></span></td>
<td align="left"><span data-ttu-id="c5aed-202">D (Lumia Icon、830、930、1520 のみ)</span><span class="sxs-lookup"><span data-stu-id="c5aed-202">D, Only on Lumia Icon, 830, 930, 1520</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="c5aed-203">EAC3/EC3</span><span class="sxs-lookup"><span data-stu-id="c5aed-203">EAC3 / EC3</span></span></td>
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
<td align="left"><span data-ttu-id="c5aed-204">ALAC</span><span class="sxs-lookup"><span data-stu-id="c5aed-204">ALAC</span></span></td>
<td align="left"><span data-ttu-id="c5aed-205">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-205">D</span></span></td>
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
<td align="left"><span data-ttu-id="c5aed-206">AMR-NB</span><span class="sxs-lookup"><span data-stu-id="c5aed-206">AMR-NB</span></span></td>
<td align="left"><span data-ttu-id="c5aed-207">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-207">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-208">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-208">D/E</span></span></td>
<td align="left"><span data-ttu-id="c5aed-209">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-209">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="c5aed-210">FLAC</span><span class="sxs-lookup"><span data-stu-id="c5aed-210">FLAC</span></span></td>
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
<td align="left"><span data-ttu-id="c5aed-211">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-211">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="c5aed-212">G.711 (A-Law、µ-law)</span><span class="sxs-lookup"><span data-stu-id="c5aed-212">G.711 (A-Law, µ-law)</span></span></td>
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
<td align="left"><span data-ttu-id="c5aed-213">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-213">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="c5aed-214">GSM 6.10</span><span class="sxs-lookup"><span data-stu-id="c5aed-214">GSM 6.10</span></span></td>
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
<td align="left"><span data-ttu-id="c5aed-215">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-215">D</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="c5aed-216">IMA ADPCM</span><span class="sxs-lookup"><span data-stu-id="c5aed-216">IMA ADPCM</span></span></td>
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
<td align="left"><span data-ttu-id="c5aed-217">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-217">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="c5aed-218">LPCM</span><span class="sxs-lookup"><span data-stu-id="c5aed-218">LPCM</span></span></td>
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
<td align="left"><span data-ttu-id="c5aed-219">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-219">D/E</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="c5aed-220">MP3</span><span class="sxs-lookup"><span data-stu-id="c5aed-220">MP3</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-221">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-221">D</span></span></td>
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
<td align="left"><span data-ttu-id="c5aed-222">MPEG-1/2</span><span class="sxs-lookup"><span data-stu-id="c5aed-222">MPEG-1/2</span></span></td>
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
<td align="left"><span data-ttu-id="c5aed-223">MS ADPCM</span><span class="sxs-lookup"><span data-stu-id="c5aed-223">MS ADPCM</span></span></td>
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
<td align="left"><span data-ttu-id="c5aed-224">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-224">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="c5aed-225">WMA 1/2/3</span><span class="sxs-lookup"><span data-stu-id="c5aed-225">WMA 1/2/3</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-226">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-226">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="c5aed-227">WMA Pro</span><span class="sxs-lookup"><span data-stu-id="c5aed-227">WMA Pro</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-228">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-228">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="c5aed-229">WMA Voice</span><span class="sxs-lookup"><span data-stu-id="c5aed-229">WMA Voice</span></span></td>
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

 

### <a name="iot-core-x86"></a><span data-ttu-id="c5aed-230">IoT Core (x86)</span><span class="sxs-lookup"><span data-stu-id="c5aed-230">IoT Core (x86)</span></span>

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
<th align="left"><span data-ttu-id="c5aed-231">コーデック/コンテナー</span><span class="sxs-lookup"><span data-stu-id="c5aed-231">Codec/Container</span></span></th>
<th align="left"><span data-ttu-id="c5aed-232">MPEG-4</span><span class="sxs-lookup"><span data-stu-id="c5aed-232">MPEG-4</span></span></th>
<th align="left"><span data-ttu-id="c5aed-233">MPEG-3</span><span class="sxs-lookup"><span data-stu-id="c5aed-233">MPEG-3</span></span></th>
<th align="left"><span data-ttu-id="c5aed-234">MPEG-2</span><span class="sxs-lookup"><span data-stu-id="c5aed-234">MPEG-2</span></span></th>
<th align="left"><span data-ttu-id="c5aed-235">ADTS</span><span class="sxs-lookup"><span data-stu-id="c5aed-235">ADTS</span></span></th>
<th align="left"><span data-ttu-id="c5aed-236">ASF</span><span class="sxs-lookup"><span data-stu-id="c5aed-236">ASF</span></span></th>
<th align="left"><span data-ttu-id="c5aed-237">RIFF</span><span class="sxs-lookup"><span data-stu-id="c5aed-237">RIFF</span></span></th>
<th align="left"><span data-ttu-id="c5aed-238">AVI</span><span class="sxs-lookup"><span data-stu-id="c5aed-238">AVI</span></span></th>
<th align="left"><span data-ttu-id="c5aed-239">AC-3</span><span class="sxs-lookup"><span data-stu-id="c5aed-239">AC-3</span></span></th>
<th align="left"><span data-ttu-id="c5aed-240">AMR</span><span class="sxs-lookup"><span data-stu-id="c5aed-240">AMR</span></span></th>
<th align="left"><span data-ttu-id="c5aed-241">3GP</span><span class="sxs-lookup"><span data-stu-id="c5aed-241">3GP</span></span></th>
<th align="left"><span data-ttu-id="c5aed-242">FLAC</span><span class="sxs-lookup"><span data-stu-id="c5aed-242">FLAC</span></span></th>
<th align="left"><span data-ttu-id="c5aed-243">WAV</span><span class="sxs-lookup"><span data-stu-id="c5aed-243">WAV</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="c5aed-244">HE-AAC v1/AAC+</span><span class="sxs-lookup"><span data-stu-id="c5aed-244">HE-AAC v1 / AAC+</span></span></td>
<td align="left"><span data-ttu-id="c5aed-245">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-245">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-246">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-246">D</span></span></td>
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
<td align="left"><span data-ttu-id="c5aed-247">HE-AAC v2/eAAC+</span><span class="sxs-lookup"><span data-stu-id="c5aed-247">HE-AAC v2 / eAAC+</span></span></td>
<td align="left"><span data-ttu-id="c5aed-248">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-248">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-249">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-249">D</span></span></td>
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
<td align="left"><span data-ttu-id="c5aed-250">AAC-LC</span><span class="sxs-lookup"><span data-stu-id="c5aed-250">AAC-LC</span></span></td>
<td align="left"><span data-ttu-id="c5aed-251">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-251">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-252">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-252">D</span></span></td>
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
<td align="left"><span data-ttu-id="c5aed-253">AC3</span><span class="sxs-lookup"><span data-stu-id="c5aed-253">AC3</span></span></td>
<td align="left"><span data-ttu-id="c5aed-254">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-254">D</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-255">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-255">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-256">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-256">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="c5aed-257">EAC3/EC3</span><span class="sxs-lookup"><span data-stu-id="c5aed-257">EAC3 / EC3</span></span></td>
<td align="left"><span data-ttu-id="c5aed-258">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-258">D</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-259">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-259">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-260">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-260">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="c5aed-261">ALAC</span><span class="sxs-lookup"><span data-stu-id="c5aed-261">ALAC</span></span></td>
<td align="left"><span data-ttu-id="c5aed-262">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-262">D</span></span></td>
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
<td align="left"><span data-ttu-id="c5aed-263">AMR-NB</span><span class="sxs-lookup"><span data-stu-id="c5aed-263">AMR-NB</span></span></td>
<td align="left"><span data-ttu-id="c5aed-264">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-264">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-265">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-265">D/E</span></span></td>
<td align="left"><span data-ttu-id="c5aed-266">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-266">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="c5aed-267">FLAC</span><span class="sxs-lookup"><span data-stu-id="c5aed-267">FLAC</span></span></td>
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
<td align="left"><span data-ttu-id="c5aed-268">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-268">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="c5aed-269">G.711 (A-Law、µ-law)</span><span class="sxs-lookup"><span data-stu-id="c5aed-269">G.711 (A-Law, µ-law)</span></span></td>
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
<td align="left"><span data-ttu-id="c5aed-270">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-270">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="c5aed-271">GSM 6.10</span><span class="sxs-lookup"><span data-stu-id="c5aed-271">GSM 6.10</span></span></td>
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
<td align="left"><span data-ttu-id="c5aed-272">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-272">D</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="c5aed-273">IMA ADPCM</span><span class="sxs-lookup"><span data-stu-id="c5aed-273">IMA ADPCM</span></span></td>
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
<td align="left"><span data-ttu-id="c5aed-274">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-274">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="c5aed-275">LPCM</span><span class="sxs-lookup"><span data-stu-id="c5aed-275">LPCM</span></span></td>
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
<td align="left"><span data-ttu-id="c5aed-276">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-276">D/E</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="c5aed-277">MP3</span><span class="sxs-lookup"><span data-stu-id="c5aed-277">MP3</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-278">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-278">D</span></span></td>
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
<td align="left"><span data-ttu-id="c5aed-279">MPEG-1/2</span><span class="sxs-lookup"><span data-stu-id="c5aed-279">MPEG-1/2</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-280">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-280">D</span></span></td>
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
<td align="left"><span data-ttu-id="c5aed-281">MS ADPCM</span><span class="sxs-lookup"><span data-stu-id="c5aed-281">MS ADPCM</span></span></td>
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
<td align="left"><span data-ttu-id="c5aed-282">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-282">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="c5aed-283">WMA 1/2/3</span><span class="sxs-lookup"><span data-stu-id="c5aed-283">WMA 1/2/3</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-284">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-284">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="c5aed-285">WMA Pro</span><span class="sxs-lookup"><span data-stu-id="c5aed-285">WMA Pro</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-286">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-286">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="c5aed-287">WMA Voice</span><span class="sxs-lookup"><span data-stu-id="c5aed-287">WMA Voice</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-288">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-288">D</span></span></td>
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

 

### <a name="iot-core-arm"></a><span data-ttu-id="c5aed-289">IoT Core (ARM)</span><span class="sxs-lookup"><span data-stu-id="c5aed-289">IoT Core (ARM)</span></span>

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
<th align="left"><span data-ttu-id="c5aed-290">コーデック/コンテナー</span><span class="sxs-lookup"><span data-stu-id="c5aed-290">Codec/Container</span></span></th>
<th align="left"><span data-ttu-id="c5aed-291">MPEG-4</span><span class="sxs-lookup"><span data-stu-id="c5aed-291">MPEG-4</span></span></th>
<th align="left"><span data-ttu-id="c5aed-292">MPEG-3</span><span class="sxs-lookup"><span data-stu-id="c5aed-292">MPEG-3</span></span></th>
<th align="left"><span data-ttu-id="c5aed-293">MPEG-2</span><span class="sxs-lookup"><span data-stu-id="c5aed-293">MPEG-2</span></span></th>
<th align="left"><span data-ttu-id="c5aed-294">ADTS</span><span class="sxs-lookup"><span data-stu-id="c5aed-294">ADTS</span></span></th>
<th align="left"><span data-ttu-id="c5aed-295">ASF</span><span class="sxs-lookup"><span data-stu-id="c5aed-295">ASF</span></span></th>
<th align="left"><span data-ttu-id="c5aed-296">RIFF</span><span class="sxs-lookup"><span data-stu-id="c5aed-296">RIFF</span></span></th>
<th align="left"><span data-ttu-id="c5aed-297">AVI</span><span class="sxs-lookup"><span data-stu-id="c5aed-297">AVI</span></span></th>
<th align="left"><span data-ttu-id="c5aed-298">AC-3</span><span class="sxs-lookup"><span data-stu-id="c5aed-298">AC-3</span></span></th>
<th align="left"><span data-ttu-id="c5aed-299">AMR</span><span class="sxs-lookup"><span data-stu-id="c5aed-299">AMR</span></span></th>
<th align="left"><span data-ttu-id="c5aed-300">3GP</span><span class="sxs-lookup"><span data-stu-id="c5aed-300">3GP</span></span></th>
<th align="left"><span data-ttu-id="c5aed-301">FLAC</span><span class="sxs-lookup"><span data-stu-id="c5aed-301">FLAC</span></span></th>
<th align="left"><span data-ttu-id="c5aed-302">WAV</span><span class="sxs-lookup"><span data-stu-id="c5aed-302">WAV</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="c5aed-303">HE-AAC v1/AAC+</span><span class="sxs-lookup"><span data-stu-id="c5aed-303">HE-AAC v1 / AAC+</span></span></td>
<td align="left"><span data-ttu-id="c5aed-304">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-304">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-305">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-305">D</span></span></td>
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
<td align="left"><span data-ttu-id="c5aed-306">HE-AAC v2/eAAC+</span><span class="sxs-lookup"><span data-stu-id="c5aed-306">HE-AAC v2 / eAAC+</span></span></td>
<td align="left"><span data-ttu-id="c5aed-307">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-307">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-308">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-308">D</span></span></td>
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
<td align="left"><span data-ttu-id="c5aed-309">AAC-LC</span><span class="sxs-lookup"><span data-stu-id="c5aed-309">AAC-LC</span></span></td>
<td align="left"><span data-ttu-id="c5aed-310">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-310">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-311">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-311">D</span></span></td>
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
<td align="left"><span data-ttu-id="c5aed-312">AC3</span><span class="sxs-lookup"><span data-stu-id="c5aed-312">AC3</span></span></td>
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
<td align="left"><span data-ttu-id="c5aed-313">EAC3/EC3</span><span class="sxs-lookup"><span data-stu-id="c5aed-313">EAC3 / EC3</span></span></td>
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
<td align="left"><span data-ttu-id="c5aed-314">ALAC</span><span class="sxs-lookup"><span data-stu-id="c5aed-314">ALAC</span></span></td>
<td align="left"><span data-ttu-id="c5aed-315">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-315">D</span></span></td>
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
<td align="left"><span data-ttu-id="c5aed-316">AMR-NB</span><span class="sxs-lookup"><span data-stu-id="c5aed-316">AMR-NB</span></span></td>
<td align="left"><span data-ttu-id="c5aed-317">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-317">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-318">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-318">D/E</span></span></td>
<td align="left"><span data-ttu-id="c5aed-319">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-319">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="c5aed-320">FLAC</span><span class="sxs-lookup"><span data-stu-id="c5aed-320">FLAC</span></span></td>
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
<td align="left"><span data-ttu-id="c5aed-321">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-321">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="c5aed-322">G.711 (A-Law、µ-law)</span><span class="sxs-lookup"><span data-stu-id="c5aed-322">G.711 (A-Law, µ-law)</span></span></td>
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
<td align="left"><span data-ttu-id="c5aed-323">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-323">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="c5aed-324">GSM 6.10</span><span class="sxs-lookup"><span data-stu-id="c5aed-324">GSM 6.10</span></span></td>
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
<td align="left"><span data-ttu-id="c5aed-325">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-325">D</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="c5aed-326">IMA ADPCM</span><span class="sxs-lookup"><span data-stu-id="c5aed-326">IMA ADPCM</span></span></td>
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
<td align="left"><span data-ttu-id="c5aed-327">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-327">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="c5aed-328">LPCM</span><span class="sxs-lookup"><span data-stu-id="c5aed-328">LPCM</span></span></td>
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
<td align="left"><span data-ttu-id="c5aed-329">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-329">D/E</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="c5aed-330">MP3</span><span class="sxs-lookup"><span data-stu-id="c5aed-330">MP3</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-331">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-331">D</span></span></td>
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
<td align="left"><span data-ttu-id="c5aed-332">MPEG-1/2</span><span class="sxs-lookup"><span data-stu-id="c5aed-332">MPEG-1/2</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-333">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-333">D</span></span></td>
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
<td align="left"><span data-ttu-id="c5aed-334">MS ADPCM</span><span class="sxs-lookup"><span data-stu-id="c5aed-334">MS ADPCM</span></span></td>
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
<td align="left"><span data-ttu-id="c5aed-335">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-335">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="c5aed-336">WMA 1/2/3</span><span class="sxs-lookup"><span data-stu-id="c5aed-336">WMA 1/2/3</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-337">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-337">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="c5aed-338">WMA Pro</span><span class="sxs-lookup"><span data-stu-id="c5aed-338">WMA Pro</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-339">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-339">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="c5aed-340">WMA Voice</span><span class="sxs-lookup"><span data-stu-id="c5aed-340">WMA Voice</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-341">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-341">D</span></span></td>
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

 

### <a name="xbox"></a><span data-ttu-id="c5aed-342">Xbox</span><span class="sxs-lookup"><span data-stu-id="c5aed-342">XBox</span></span>

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
<th align="left"><span data-ttu-id="c5aed-343">コーデック/コンテナー</span><span class="sxs-lookup"><span data-stu-id="c5aed-343">Codec/Container</span></span></th>
<th align="left"><span data-ttu-id="c5aed-344">MPEG-4</span><span class="sxs-lookup"><span data-stu-id="c5aed-344">MPEG-4</span></span></th>
<th align="left"><span data-ttu-id="c5aed-345">MPEG-3</span><span class="sxs-lookup"><span data-stu-id="c5aed-345">MPEG-3</span></span></th>
<th align="left"><span data-ttu-id="c5aed-346">MPEG-2</span><span class="sxs-lookup"><span data-stu-id="c5aed-346">MPEG-2</span></span></th>
<th align="left"><span data-ttu-id="c5aed-347">ADTS</span><span class="sxs-lookup"><span data-stu-id="c5aed-347">ADTS</span></span></th>
<th align="left"><span data-ttu-id="c5aed-348">ASF</span><span class="sxs-lookup"><span data-stu-id="c5aed-348">ASF</span></span></th>
<th align="left"><span data-ttu-id="c5aed-349">RIFF</span><span class="sxs-lookup"><span data-stu-id="c5aed-349">RIFF</span></span></th>
<th align="left"><span data-ttu-id="c5aed-350">AVI</span><span class="sxs-lookup"><span data-stu-id="c5aed-350">AVI</span></span></th>
<th align="left"><span data-ttu-id="c5aed-351">AC-3</span><span class="sxs-lookup"><span data-stu-id="c5aed-351">AC-3</span></span></th>
<th align="left"><span data-ttu-id="c5aed-352">AMR</span><span class="sxs-lookup"><span data-stu-id="c5aed-352">AMR</span></span></th>
<th align="left"><span data-ttu-id="c5aed-353">3GP</span><span class="sxs-lookup"><span data-stu-id="c5aed-353">3GP</span></span></th>
<th align="left"><span data-ttu-id="c5aed-354">FLAC</span><span class="sxs-lookup"><span data-stu-id="c5aed-354">FLAC</span></span></th>
<th align="left"><span data-ttu-id="c5aed-355">WAV</span><span class="sxs-lookup"><span data-stu-id="c5aed-355">WAV</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="c5aed-356">HE-AAC v1/AAC+</span><span class="sxs-lookup"><span data-stu-id="c5aed-356">HE-AAC v1 / AAC+</span></span></td>
<td align="left"><span data-ttu-id="c5aed-357">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-357">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-358">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-358">D</span></span></td>
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
<td align="left"><span data-ttu-id="c5aed-359">HE-AAC v2/eAAC+</span><span class="sxs-lookup"><span data-stu-id="c5aed-359">HE-AAC v2 / eAAC+</span></span></td>
<td align="left"><span data-ttu-id="c5aed-360">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-360">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-361">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-361">D</span></span></td>
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
<td align="left"><span data-ttu-id="c5aed-362">AAC-LC</span><span class="sxs-lookup"><span data-stu-id="c5aed-362">AAC-LC</span></span></td>
<td align="left"><span data-ttu-id="c5aed-363">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-363">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-364">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-364">D</span></span></td>
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
<td align="left"><span data-ttu-id="c5aed-365">AC3</span><span class="sxs-lookup"><span data-stu-id="c5aed-365">AC3</span></span></td>
<td align="left"><span data-ttu-id="c5aed-366">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-366">D</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-367">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-367">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-368">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-368">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="c5aed-369">EAC3/EC3</span><span class="sxs-lookup"><span data-stu-id="c5aed-369">EAC3 / EC3</span></span></td>
<td align="left"><span data-ttu-id="c5aed-370">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-370">D</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-371">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-371">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-372">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-372">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="c5aed-373">ALAC</span><span class="sxs-lookup"><span data-stu-id="c5aed-373">ALAC</span></span></td>
<td align="left"><span data-ttu-id="c5aed-374">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-374">D</span></span></td>
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
<td align="left"><span data-ttu-id="c5aed-375">AMR-NB</span><span class="sxs-lookup"><span data-stu-id="c5aed-375">AMR-NB</span></span></td>
<td align="left"><span data-ttu-id="c5aed-376">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-376">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-377">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-377">D/E</span></span></td>
<td align="left"><span data-ttu-id="c5aed-378">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-378">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="c5aed-379">FLAC</span><span class="sxs-lookup"><span data-stu-id="c5aed-379">FLAC</span></span></td>
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
<td align="left"><span data-ttu-id="c5aed-380">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-380">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="c5aed-381">G.711 (A-Law、µ-law)</span><span class="sxs-lookup"><span data-stu-id="c5aed-381">G.711 (A-Law, µ-law)</span></span></td>
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
<td align="left"><span data-ttu-id="c5aed-382">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-382">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="c5aed-383">GSM 6.10</span><span class="sxs-lookup"><span data-stu-id="c5aed-383">GSM 6.10</span></span></td>
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
<td align="left"><span data-ttu-id="c5aed-384">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-384">D</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="c5aed-385">IMA ADPCM</span><span class="sxs-lookup"><span data-stu-id="c5aed-385">IMA ADPCM</span></span></td>
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
<td align="left"><span data-ttu-id="c5aed-386">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-386">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="c5aed-387">LPCM</span><span class="sxs-lookup"><span data-stu-id="c5aed-387">LPCM</span></span></td>
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
<td align="left"><span data-ttu-id="c5aed-388">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-388">D/E</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="c5aed-389">MP3</span><span class="sxs-lookup"><span data-stu-id="c5aed-389">MP3</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-390">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-390">D</span></span></td>
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
<td align="left"><span data-ttu-id="c5aed-391">MPEG-1/2</span><span class="sxs-lookup"><span data-stu-id="c5aed-391">MPEG-1/2</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-392">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-392">D</span></span></td>
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
<td align="left"><span data-ttu-id="c5aed-393">MS ADPCM</span><span class="sxs-lookup"><span data-stu-id="c5aed-393">MS ADPCM</span></span></td>
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
<td align="left"><span data-ttu-id="c5aed-394">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-394">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="c5aed-395">WMA 1/2/3</span><span class="sxs-lookup"><span data-stu-id="c5aed-395">WMA 1/2/3</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-396">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-396">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="c5aed-397">WMA Pro</span><span class="sxs-lookup"><span data-stu-id="c5aed-397">WMA Pro</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-398">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-398">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="c5aed-399">WMA Voice</span><span class="sxs-lookup"><span data-stu-id="c5aed-399">WMA Voice</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-400">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-400">D</span></span></td>
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

 

## <a name="video-codec--format-support"></a><span data-ttu-id="c5aed-401">ビデオのコーデックおよび形式のサポート</span><span class="sxs-lookup"><span data-stu-id="c5aed-401">Video codec & format support</span></span>

<span data-ttu-id="c5aed-402">次の表は、各デバイス ファミリのビデオのコーデックと形式のサポートを示しています。</span><span class="sxs-lookup"><span data-stu-id="c5aed-402">The following tables show the video codec and format support for each device family.</span></span>

> [!NOTE] 
> <span data-ttu-id="c5aed-403">H.265 のサポートが示されている場合、必ずしもデバイス ファミリ内のすべてのデバイスでサポートされるわけではありません。</span><span class="sxs-lookup"><span data-stu-id="c5aed-403">Where H.265 support is indicated, it is not necessarily supported by all devices within the device family.</span></span>
> <span data-ttu-id="c5aed-404">MPEG-2/MPEG-1 のサポートが示されている場合、オプションの Microsoft DVD ユニバーサル Windows アプリのインストールでのみサポートされます。</span><span class="sxs-lookup"><span data-stu-id="c5aed-404">Where MPEG-2/MPEG-1 support is indicated, it is only supported with the installation of the optional Microsoft DVD Universal Windows app.</span></span>

 

### <a name="desktop"></a><span data-ttu-id="c5aed-405">Desktop</span><span class="sxs-lookup"><span data-stu-id="c5aed-405">Desktop</span></span>

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
<th align="left"><span data-ttu-id="c5aed-406">コーデック/コンテナー</span><span class="sxs-lookup"><span data-stu-id="c5aed-406">Codec/Container</span></span></th>
<th align="left"><span data-ttu-id="c5aed-407">FOURCC</span><span class="sxs-lookup"><span data-stu-id="c5aed-407">FOURCC</span></span></th>
<th align="left"><span data-ttu-id="c5aed-408">fMP4</span><span class="sxs-lookup"><span data-stu-id="c5aed-408">fMP4</span></span></th>
<th align="left"><span data-ttu-id="c5aed-409">MPEG-4</span><span class="sxs-lookup"><span data-stu-id="c5aed-409">MPEG-4</span></span></th>
<th align="left"><span data-ttu-id="c5aed-410">MPEG-2 PS</span><span class="sxs-lookup"><span data-stu-id="c5aed-410">MPEG-2 PS</span></span></th>
<th align="left"><span data-ttu-id="c5aed-411">MPEG-2 TS</span><span class="sxs-lookup"><span data-stu-id="c5aed-411">MPEG-2 TS</span></span></th>
<th align="left"><span data-ttu-id="c5aed-412">MPEG-1</span><span class="sxs-lookup"><span data-stu-id="c5aed-412">MPEG-1</span></span></th>
<th align="left"><span data-ttu-id="c5aed-413">3GPP</span><span class="sxs-lookup"><span data-stu-id="c5aed-413">3GPP</span></span></th>
<th align="left"><span data-ttu-id="c5aed-414">3GPP2</span><span class="sxs-lookup"><span data-stu-id="c5aed-414">3GPP2</span></span></th>
<th align="left"><span data-ttu-id="c5aed-415">AVCHD</span><span class="sxs-lookup"><span data-stu-id="c5aed-415">AVCHD</span></span></th>
<th align="left"><span data-ttu-id="c5aed-416">ASF</span><span class="sxs-lookup"><span data-stu-id="c5aed-416">ASF</span></span></th>
<th align="left"><span data-ttu-id="c5aed-417">AVI</span><span class="sxs-lookup"><span data-stu-id="c5aed-417">AVI</span></span></th>
<th align="left"><span data-ttu-id="c5aed-418">MKV</span><span class="sxs-lookup"><span data-stu-id="c5aed-418">MKV</span></span></th>
<th align="left"><span data-ttu-id="c5aed-419">DV</span><span class="sxs-lookup"><span data-stu-id="c5aed-419">DV</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="c5aed-420">MPEG-1</span><span class="sxs-lookup"><span data-stu-id="c5aed-420">MPEG-1</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-421">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-421">D/E</span></span></td>
<td align="left"><span data-ttu-id="c5aed-422">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-422">D/E</span></span></td>
<td align="left"><span data-ttu-id="c5aed-423">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-423">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-424">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-424">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-425">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-425">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="c5aed-426">MPEG-2</span><span class="sxs-lookup"><span data-stu-id="c5aed-426">MPEG-2</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-427">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-427">D/E</span></span></td>
<td align="left"><span data-ttu-id="c5aed-428">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-428">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-429">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-429">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-430">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-430">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="c5aed-431">MPEG-4 (Part 2)</span><span class="sxs-lookup"><span data-stu-id="c5aed-431">MPEG-4 (Part 2)</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-432">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-432">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-433">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-433">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-434">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-434">D</span></span></td>
<td align="left"><span data-ttu-id="c5aed-435">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-435">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="c5aed-436">H.265</span><span class="sxs-lookup"><span data-stu-id="c5aed-436">H.265</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-437">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-437">D</span></span></td>
<td align="left"><span data-ttu-id="c5aed-438">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-438">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-439">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-439">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="c5aed-440">H.264</span><span class="sxs-lookup"><span data-stu-id="c5aed-440">H.264</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-441">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-441">D/E</span></span></td>
<td align="left"><span data-ttu-id="c5aed-442">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-442">D/E</span></span></td>
<td align="left"><span data-ttu-id="c5aed-443">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-443">D/E</span></span></td>
<td align="left"><span data-ttu-id="c5aed-444">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-444">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-445">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-445">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-446">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-446">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-447">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-447">D</span></span></td>
<td align="left"><span data-ttu-id="c5aed-448">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-448">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="c5aed-449">H.263</span><span class="sxs-lookup"><span data-stu-id="c5aed-449">H.263</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-450">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-450">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-451">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-451">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-452">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-452">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="c5aed-453">VC-1</span><span class="sxs-lookup"><span data-stu-id="c5aed-453">VC-1</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-454">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-454">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-455">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-455">D</span></span></td>
<td align="left"><span data-ttu-id="c5aed-456">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-456">D</span></span></td>
<td align="left"><span data-ttu-id="c5aed-457">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-457">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="c5aed-458">WMV7/8/9</span><span class="sxs-lookup"><span data-stu-id="c5aed-458">WMV7/8/9</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-459">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-459">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-460">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-460">D/E</span></span></td>
<td align="left"><span data-ttu-id="c5aed-461">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-461">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="c5aed-462">WMV9 Screen</span><span class="sxs-lookup"><span data-stu-id="c5aed-462">WMV9 Screen</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-463">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-463">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-464">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-464">D</span></span></td>
<td align="left"><span data-ttu-id="c5aed-465">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-465">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="c5aed-466">DV</span><span class="sxs-lookup"><span data-stu-id="c5aed-466">DV</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-467">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-467">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-468">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-468">D</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-469">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-469">D</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="c5aed-470">モーション JPEG</span><span class="sxs-lookup"><span data-stu-id="c5aed-470">Motion JPEG</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-471">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-471">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-472">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-472">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
</tbody>
</table>

 

### <a name="mobile"></a><span data-ttu-id="c5aed-473">モバイル</span><span class="sxs-lookup"><span data-stu-id="c5aed-473">Mobile</span></span>

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
<th align="left"><span data-ttu-id="c5aed-474">コーデック/コンテナー</span><span class="sxs-lookup"><span data-stu-id="c5aed-474">Codec/Container</span></span></th>
<th align="left"><span data-ttu-id="c5aed-475">FOURCC</span><span class="sxs-lookup"><span data-stu-id="c5aed-475">FOURCC</span></span></th>
<th align="left"><span data-ttu-id="c5aed-476">fMP4</span><span class="sxs-lookup"><span data-stu-id="c5aed-476">fMP4</span></span></th>
<th align="left"><span data-ttu-id="c5aed-477">MPEG-4</span><span class="sxs-lookup"><span data-stu-id="c5aed-477">MPEG-4</span></span></th>
<th align="left"><span data-ttu-id="c5aed-478">MPEG-2 PS</span><span class="sxs-lookup"><span data-stu-id="c5aed-478">MPEG-2 PS</span></span></th>
<th align="left"><span data-ttu-id="c5aed-479">MPEG-2 TS</span><span class="sxs-lookup"><span data-stu-id="c5aed-479">MPEG-2 TS</span></span></th>
<th align="left"><span data-ttu-id="c5aed-480">MPEG-1</span><span class="sxs-lookup"><span data-stu-id="c5aed-480">MPEG-1</span></span></th>
<th align="left"><span data-ttu-id="c5aed-481">3GPP</span><span class="sxs-lookup"><span data-stu-id="c5aed-481">3GPP</span></span></th>
<th align="left"><span data-ttu-id="c5aed-482">3GPP2</span><span class="sxs-lookup"><span data-stu-id="c5aed-482">3GPP2</span></span></th>
<th align="left"><span data-ttu-id="c5aed-483">AVCHD</span><span class="sxs-lookup"><span data-stu-id="c5aed-483">AVCHD</span></span></th>
<th align="left"><span data-ttu-id="c5aed-484">ASF</span><span class="sxs-lookup"><span data-stu-id="c5aed-484">ASF</span></span></th>
<th align="left"><span data-ttu-id="c5aed-485">AVI</span><span class="sxs-lookup"><span data-stu-id="c5aed-485">AVI</span></span></th>
<th align="left"><span data-ttu-id="c5aed-486">MKV</span><span class="sxs-lookup"><span data-stu-id="c5aed-486">MKV</span></span></th>
<th align="left"><span data-ttu-id="c5aed-487">DV</span><span class="sxs-lookup"><span data-stu-id="c5aed-487">DV</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="c5aed-488">MPEG-1</span><span class="sxs-lookup"><span data-stu-id="c5aed-488">MPEG-1</span></span></td>
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
<td align="left"><span data-ttu-id="c5aed-489">MPEG-2</span><span class="sxs-lookup"><span data-stu-id="c5aed-489">MPEG-2</span></span></td>
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
<td align="left"><span data-ttu-id="c5aed-490">MPEG-4 (Part 2)</span><span class="sxs-lookup"><span data-stu-id="c5aed-490">MPEG-4 (Part 2)</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-491">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-491">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-492">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-492">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-493">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-493">D</span></span></td>
<td align="left"><span data-ttu-id="c5aed-494">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-494">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="c5aed-495">H.265</span><span class="sxs-lookup"><span data-stu-id="c5aed-495">H.265</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-496">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-496">D</span></span></td>
<td align="left"><span data-ttu-id="c5aed-497">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-497">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-498">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-498">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="c5aed-499">H.264</span><span class="sxs-lookup"><span data-stu-id="c5aed-499">H.264</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-500">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-500">D/E</span></span></td>
<td align="left"><span data-ttu-id="c5aed-501">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-501">D/E</span></span></td>
<td align="left"><span data-ttu-id="c5aed-502">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-502">D/E</span></span></td>
<td align="left"><span data-ttu-id="c5aed-503">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-503">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-504">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-504">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-505">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-505">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-506">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-506">D</span></span></td>
<td align="left"><span data-ttu-id="c5aed-507">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-507">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="c5aed-508">H.263</span><span class="sxs-lookup"><span data-stu-id="c5aed-508">H.263</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-509">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-509">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-510">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-510">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-511">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-511">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="c5aed-512">VC-1</span><span class="sxs-lookup"><span data-stu-id="c5aed-512">VC-1</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-513">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-513">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-514">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-514">D</span></span></td>
<td align="left"><span data-ttu-id="c5aed-515">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-515">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="c5aed-516">WMV7/8/9</span><span class="sxs-lookup"><span data-stu-id="c5aed-516">WMV7/8/9</span></span></td>
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
<td align="left"><span data-ttu-id="c5aed-517">WMV9 Screen</span><span class="sxs-lookup"><span data-stu-id="c5aed-517">WMV9 Screen</span></span></td>
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
<td align="left"><span data-ttu-id="c5aed-518">DV</span><span class="sxs-lookup"><span data-stu-id="c5aed-518">DV</span></span></td>
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
<td align="left"><span data-ttu-id="c5aed-519">モーション JPEG</span><span class="sxs-lookup"><span data-stu-id="c5aed-519">Motion JPEG</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-520">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-520">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-521">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-521">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
</tbody>
</table>

 

### <a name="iot-core-x86"></a><span data-ttu-id="c5aed-522">IoT Core (x86)</span><span class="sxs-lookup"><span data-stu-id="c5aed-522">IoT Core (x86)</span></span>

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
<th align="left"><span data-ttu-id="c5aed-523">コーデック/コンテナー</span><span class="sxs-lookup"><span data-stu-id="c5aed-523">Codec/Container</span></span></th>
<th align="left"><span data-ttu-id="c5aed-524">FOURCC</span><span class="sxs-lookup"><span data-stu-id="c5aed-524">FOURCC</span></span></th>
<th align="left"><span data-ttu-id="c5aed-525">fMP4</span><span class="sxs-lookup"><span data-stu-id="c5aed-525">fMP4</span></span></th>
<th align="left"><span data-ttu-id="c5aed-526">MPEG-4</span><span class="sxs-lookup"><span data-stu-id="c5aed-526">MPEG-4</span></span></th>
<th align="left"><span data-ttu-id="c5aed-527">MPEG-2 PS</span><span class="sxs-lookup"><span data-stu-id="c5aed-527">MPEG-2 PS</span></span></th>
<th align="left"><span data-ttu-id="c5aed-528">MPEG-2 TS</span><span class="sxs-lookup"><span data-stu-id="c5aed-528">MPEG-2 TS</span></span></th>
<th align="left"><span data-ttu-id="c5aed-529">MPEG-1</span><span class="sxs-lookup"><span data-stu-id="c5aed-529">MPEG-1</span></span></th>
<th align="left"><span data-ttu-id="c5aed-530">3GPP</span><span class="sxs-lookup"><span data-stu-id="c5aed-530">3GPP</span></span></th>
<th align="left"><span data-ttu-id="c5aed-531">3GPP2</span><span class="sxs-lookup"><span data-stu-id="c5aed-531">3GPP2</span></span></th>
<th align="left"><span data-ttu-id="c5aed-532">AVCHD</span><span class="sxs-lookup"><span data-stu-id="c5aed-532">AVCHD</span></span></th>
<th align="left"><span data-ttu-id="c5aed-533">ASF</span><span class="sxs-lookup"><span data-stu-id="c5aed-533">ASF</span></span></th>
<th align="left"><span data-ttu-id="c5aed-534">AVI</span><span class="sxs-lookup"><span data-stu-id="c5aed-534">AVI</span></span></th>
<th align="left"><span data-ttu-id="c5aed-535">MKV</span><span class="sxs-lookup"><span data-stu-id="c5aed-535">MKV</span></span></th>
<th align="left"><span data-ttu-id="c5aed-536">DV</span><span class="sxs-lookup"><span data-stu-id="c5aed-536">DV</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="c5aed-537">MPEG-1</span><span class="sxs-lookup"><span data-stu-id="c5aed-537">MPEG-1</span></span></td>
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
<td align="left"><span data-ttu-id="c5aed-538">MPEG-2</span><span class="sxs-lookup"><span data-stu-id="c5aed-538">MPEG-2</span></span></td>
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
<td align="left"><span data-ttu-id="c5aed-539">MPEG-4 (Part 2)</span><span class="sxs-lookup"><span data-stu-id="c5aed-539">MPEG-4 (Part 2)</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-540">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-540">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-541">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-541">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-542">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-542">D</span></span></td>
<td align="left"><span data-ttu-id="c5aed-543">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-543">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="c5aed-544">H.265</span><span class="sxs-lookup"><span data-stu-id="c5aed-544">H.265</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-545">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-545">D</span></span></td>
<td align="left"><span data-ttu-id="c5aed-546">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-546">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-547">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-547">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="c5aed-548">H.264</span><span class="sxs-lookup"><span data-stu-id="c5aed-548">H.264</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-549">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-549">D/E</span></span></td>
<td align="left"><span data-ttu-id="c5aed-550">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-550">D/E</span></span></td>
<td align="left"><span data-ttu-id="c5aed-551">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-551">D/E</span></span></td>
<td align="left"><span data-ttu-id="c5aed-552">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-552">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-553">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-553">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-554">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-554">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-555">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-555">D</span></span></td>
<td align="left"><span data-ttu-id="c5aed-556">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-556">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="c5aed-557">H.263</span><span class="sxs-lookup"><span data-stu-id="c5aed-557">H.263</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-558">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-558">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-559">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-559">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-560">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-560">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="c5aed-561">VC-1</span><span class="sxs-lookup"><span data-stu-id="c5aed-561">VC-1</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-562">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-562">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-563">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-563">D</span></span></td>
<td align="left"><span data-ttu-id="c5aed-564">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-564">D</span></span></td>
<td align="left"><span data-ttu-id="c5aed-565">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-565">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="c5aed-566">WMV7/8/9</span><span class="sxs-lookup"><span data-stu-id="c5aed-566">WMV7/8/9</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-567">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-567">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-568">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-568">D</span></span></td>
<td align="left"><span data-ttu-id="c5aed-569">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-569">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="c5aed-570">WMV9 Screen</span><span class="sxs-lookup"><span data-stu-id="c5aed-570">WMV9 Screen</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-571">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-571">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-572">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-572">D</span></span></td>
<td align="left"><span data-ttu-id="c5aed-573">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-573">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="c5aed-574">DV</span><span class="sxs-lookup"><span data-stu-id="c5aed-574">DV</span></span></td>
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
<td align="left"><span data-ttu-id="c5aed-575">モーション JPEG</span><span class="sxs-lookup"><span data-stu-id="c5aed-575">Motion JPEG</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-576">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-576">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-577">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-577">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
</tbody>
</table>

 

### <a name="iot-arm"></a><span data-ttu-id="c5aed-578">IoT (ARM)</span><span class="sxs-lookup"><span data-stu-id="c5aed-578">IoT (ARM)</span></span>

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
<th align="left"><span data-ttu-id="c5aed-579">コーデック/コンテナー</span><span class="sxs-lookup"><span data-stu-id="c5aed-579">Codec/Container</span></span></th>
<th align="left"><span data-ttu-id="c5aed-580">FOURCC</span><span class="sxs-lookup"><span data-stu-id="c5aed-580">FOURCC</span></span></th>
<th align="left"><span data-ttu-id="c5aed-581">fMP4</span><span class="sxs-lookup"><span data-stu-id="c5aed-581">fMP4</span></span></th>
<th align="left"><span data-ttu-id="c5aed-582">MPEG-4</span><span class="sxs-lookup"><span data-stu-id="c5aed-582">MPEG-4</span></span></th>
<th align="left"><span data-ttu-id="c5aed-583">MPEG-2 PS</span><span class="sxs-lookup"><span data-stu-id="c5aed-583">MPEG-2 PS</span></span></th>
<th align="left"><span data-ttu-id="c5aed-584">MPEG-2 TS</span><span class="sxs-lookup"><span data-stu-id="c5aed-584">MPEG-2 TS</span></span></th>
<th align="left"><span data-ttu-id="c5aed-585">MPEG-1</span><span class="sxs-lookup"><span data-stu-id="c5aed-585">MPEG-1</span></span></th>
<th align="left"><span data-ttu-id="c5aed-586">3GPP</span><span class="sxs-lookup"><span data-stu-id="c5aed-586">3GPP</span></span></th>
<th align="left"><span data-ttu-id="c5aed-587">3GPP2</span><span class="sxs-lookup"><span data-stu-id="c5aed-587">3GPP2</span></span></th>
<th align="left"><span data-ttu-id="c5aed-588">AVCHD</span><span class="sxs-lookup"><span data-stu-id="c5aed-588">AVCHD</span></span></th>
<th align="left"><span data-ttu-id="c5aed-589">ASF</span><span class="sxs-lookup"><span data-stu-id="c5aed-589">ASF</span></span></th>
<th align="left"><span data-ttu-id="c5aed-590">AVI</span><span class="sxs-lookup"><span data-stu-id="c5aed-590">AVI</span></span></th>
<th align="left"><span data-ttu-id="c5aed-591">MKV</span><span class="sxs-lookup"><span data-stu-id="c5aed-591">MKV</span></span></th>
<th align="left"><span data-ttu-id="c5aed-592">DV</span><span class="sxs-lookup"><span data-stu-id="c5aed-592">DV</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="c5aed-593">MPEG-1</span><span class="sxs-lookup"><span data-stu-id="c5aed-593">MPEG-1</span></span></td>
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
<td align="left"><span data-ttu-id="c5aed-594">MPEG-2</span><span class="sxs-lookup"><span data-stu-id="c5aed-594">MPEG-2</span></span></td>
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
<td align="left"><span data-ttu-id="c5aed-595">MPEG-4 (Part 2)</span><span class="sxs-lookup"><span data-stu-id="c5aed-595">MPEG-4 (Part 2)</span></span></td>
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
<td align="left"><span data-ttu-id="c5aed-596">H.265</span><span class="sxs-lookup"><span data-stu-id="c5aed-596">H.265</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-597">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-597">D</span></span></td>
<td align="left"><span data-ttu-id="c5aed-598">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-598">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-599">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-599">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="c5aed-600">H.264</span><span class="sxs-lookup"><span data-stu-id="c5aed-600">H.264</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-601">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-601">D/E</span></span></td>
<td align="left"><span data-ttu-id="c5aed-602">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-602">D/E</span></span></td>
<td align="left"><span data-ttu-id="c5aed-603">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-603">D/E</span></span></td>
<td align="left"><span data-ttu-id="c5aed-604">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-604">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-605">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-605">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-606">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-606">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-607">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-607">D</span></span></td>
<td align="left"><span data-ttu-id="c5aed-608">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-608">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="c5aed-609">H.263</span><span class="sxs-lookup"><span data-stu-id="c5aed-609">H.263</span></span></td>
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
<td align="left"><span data-ttu-id="c5aed-610">VC-1</span><span class="sxs-lookup"><span data-stu-id="c5aed-610">VC-1</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-611">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-611">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-612">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-612">D</span></span></td>
<td align="left"><span data-ttu-id="c5aed-613">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-613">D</span></span></td>
<td align="left"><span data-ttu-id="c5aed-614">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-614">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="c5aed-615">WMV7/8/9</span><span class="sxs-lookup"><span data-stu-id="c5aed-615">WMV7/8/9</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-616">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-616">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-617">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-617">D</span></span></td>
<td align="left"><span data-ttu-id="c5aed-618">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-618">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="c5aed-619">WMV9 Screen</span><span class="sxs-lookup"><span data-stu-id="c5aed-619">WMV9 Screen</span></span></td>
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
<td align="left"><span data-ttu-id="c5aed-620">DV</span><span class="sxs-lookup"><span data-stu-id="c5aed-620">DV</span></span></td>
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
<td align="left"><span data-ttu-id="c5aed-621">モーション JPEG</span><span class="sxs-lookup"><span data-stu-id="c5aed-621">Motion JPEG</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-622">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-622">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-623">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-623">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
</tbody>
</table>

 

### <a name="xbox"></a><span data-ttu-id="c5aed-624">Xbox</span><span class="sxs-lookup"><span data-stu-id="c5aed-624">XBox</span></span>

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
<th align="left"><span data-ttu-id="c5aed-625">コーデック/コンテナー</span><span class="sxs-lookup"><span data-stu-id="c5aed-625">Codec/Container</span></span></th>
<th align="left"><span data-ttu-id="c5aed-626">FOURCC</span><span class="sxs-lookup"><span data-stu-id="c5aed-626">FOURCC</span></span></th>
<th align="left"><span data-ttu-id="c5aed-627">fMP4</span><span class="sxs-lookup"><span data-stu-id="c5aed-627">fMP4</span></span></th>
<th align="left"><span data-ttu-id="c5aed-628">MPEG-4</span><span class="sxs-lookup"><span data-stu-id="c5aed-628">MPEG-4</span></span></th>
<th align="left"><span data-ttu-id="c5aed-629">MPEG-2 PS</span><span class="sxs-lookup"><span data-stu-id="c5aed-629">MPEG-2 PS</span></span></th>
<th align="left"><span data-ttu-id="c5aed-630">MPEG-2 TS</span><span class="sxs-lookup"><span data-stu-id="c5aed-630">MPEG-2 TS</span></span></th>
<th align="left"><span data-ttu-id="c5aed-631">MPEG-1</span><span class="sxs-lookup"><span data-stu-id="c5aed-631">MPEG-1</span></span></th>
<th align="left"><span data-ttu-id="c5aed-632">3GPP</span><span class="sxs-lookup"><span data-stu-id="c5aed-632">3GPP</span></span></th>
<th align="left"><span data-ttu-id="c5aed-633">3GPP2</span><span class="sxs-lookup"><span data-stu-id="c5aed-633">3GPP2</span></span></th>
<th align="left"><span data-ttu-id="c5aed-634">AVCHD</span><span class="sxs-lookup"><span data-stu-id="c5aed-634">AVCHD</span></span></th>
<th align="left"><span data-ttu-id="c5aed-635">ASF</span><span class="sxs-lookup"><span data-stu-id="c5aed-635">ASF</span></span></th>
<th align="left"><span data-ttu-id="c5aed-636">AVI</span><span class="sxs-lookup"><span data-stu-id="c5aed-636">AVI</span></span></th>
<th align="left"><span data-ttu-id="c5aed-637">MKV</span><span class="sxs-lookup"><span data-stu-id="c5aed-637">MKV</span></span></th>
<th align="left"><span data-ttu-id="c5aed-638">DV</span><span class="sxs-lookup"><span data-stu-id="c5aed-638">DV</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="c5aed-639">MPEG-1</span><span class="sxs-lookup"><span data-stu-id="c5aed-639">MPEG-1</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-640">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-640">D/E</span></span></td>
<td align="left"><span data-ttu-id="c5aed-641">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-641">D/E</span></span></td>
<td align="left"><span data-ttu-id="c5aed-642">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-642">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-643">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-643">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-644">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-644">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="c5aed-645">MPEG-2</span><span class="sxs-lookup"><span data-stu-id="c5aed-645">MPEG-2</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-646">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-646">D/E</span></span></td>
<td align="left"><span data-ttu-id="c5aed-647">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-647">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-648">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-648">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-649">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-649">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="c5aed-650">MPEG-4 (Part 2)</span><span class="sxs-lookup"><span data-stu-id="c5aed-650">MPEG-4 (Part 2)</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-651">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-651">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-652">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-652">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-653">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-653">D</span></span></td>
<td align="left"><span data-ttu-id="c5aed-654">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-654">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="c5aed-655">H.265</span><span class="sxs-lookup"><span data-stu-id="c5aed-655">H.265</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-656">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-656">D</span></span></td>
<td align="left"><span data-ttu-id="c5aed-657">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-657">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-658">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-658">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="c5aed-659">H.264</span><span class="sxs-lookup"><span data-stu-id="c5aed-659">H.264</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-660">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-660">D/E</span></span></td>
<td align="left"><span data-ttu-id="c5aed-661">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-661">D/E</span></span></td>
<td align="left"><span data-ttu-id="c5aed-662">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-662">D/E</span></span></td>
<td align="left"><span data-ttu-id="c5aed-663">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-663">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-664">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-664">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-665">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-665">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-666">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-666">D</span></span></td>
<td align="left"><span data-ttu-id="c5aed-667">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-667">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="c5aed-668">H.263</span><span class="sxs-lookup"><span data-stu-id="c5aed-668">H.263</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-669">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-669">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-670">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-670">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-671">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-671">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="c5aed-672">VC-1</span><span class="sxs-lookup"><span data-stu-id="c5aed-672">VC-1</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-673">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-673">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-674">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-674">D</span></span></td>
<td align="left"><span data-ttu-id="c5aed-675">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-675">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="c5aed-676">WMV7/8/9</span><span class="sxs-lookup"><span data-stu-id="c5aed-676">WMV7/8/9</span></span></td>
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
<td align="left"><span data-ttu-id="c5aed-677">WMV9 Screen</span><span class="sxs-lookup"><span data-stu-id="c5aed-677">WMV9 Screen</span></span></td>
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
<td align="left"><span data-ttu-id="c5aed-678">DV</span><span class="sxs-lookup"><span data-stu-id="c5aed-678">DV</span></span></td>
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
<td align="left"><span data-ttu-id="c5aed-679">モーション JPEG</span><span class="sxs-lookup"><span data-stu-id="c5aed-679">Motion JPEG</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-680">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-680">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="c5aed-681">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-681">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
</tbody>
</table>

## <a name="image-codec--format-support"></a><span data-ttu-id="c5aed-682">イメージのコーデックおよび形式のサポート</span><span class="sxs-lookup"><span data-stu-id="c5aed-682">Image codec & format support</span></span> 

<table>
<colgroup>
<col width="7%" />
<col width="7%" />
<col width="7%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="c5aed-683">コーデック</span><span class="sxs-lookup"><span data-stu-id="c5aed-683">Codec</span></span></th>
<th align="left"><span data-ttu-id="c5aed-684">Desktop</span><span class="sxs-lookup"><span data-stu-id="c5aed-684">Desktop</span></span></th>
<th align="left"><span data-ttu-id="c5aed-685">他のデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="c5aed-685">Other device families</span></span></th>
</tr>
</thead>
<tr class="odd">
<td align="left"><span data-ttu-id="c5aed-686">BMP</span><span class="sxs-lookup"><span data-stu-id="c5aed-686">BMP</span></span></td>
<td align="left"><span data-ttu-id="c5aed-687">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-687">D/E</span></span></td>
<td align="left"><span data-ttu-id="c5aed-688">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-688">D/E</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="c5aed-689">DDS</span><span class="sxs-lookup"><span data-stu-id="c5aed-689">DDS</span></span></td>
<td align="left"><span data-ttu-id="c5aed-690">D/E<sup>1</sup></span><span class="sxs-lookup"><span data-stu-id="c5aed-690">D/E<sup>1</sup></span></span></td>
<td align="left"><span data-ttu-id="c5aed-691">D/E<sup>1</sup></span><span class="sxs-lookup"><span data-stu-id="c5aed-691">D/E<sup>1</sup></span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="c5aed-692">DNG</span><span class="sxs-lookup"><span data-stu-id="c5aed-692">DNG</span></span></td>
<td align="left"><span data-ttu-id="c5aed-693">D<sup>2</sup></span><span class="sxs-lookup"><span data-stu-id="c5aed-693">D<sup>2</sup></span></span></td>
<td align="left"><span data-ttu-id="c5aed-694">D<sup>2</sup></span><span class="sxs-lookup"><span data-stu-id="c5aed-694">D<sup>2</sup></span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="c5aed-695">GIF</span><span class="sxs-lookup"><span data-stu-id="c5aed-695">GIF</span></span></td>
<td align="left"><span data-ttu-id="c5aed-696">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-696">D/E</span></span></td>
<td align="left"><span data-ttu-id="c5aed-697">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-697">D/E</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="c5aed-698">ICO</span><span class="sxs-lookup"><span data-stu-id="c5aed-698">ICO</span></span></td>
<td align="left"><span data-ttu-id="c5aed-699">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-699">D</span></span></td>
<td align="left"><span data-ttu-id="c5aed-700">D</span><span class="sxs-lookup"><span data-stu-id="c5aed-700">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="c5aed-701">JPEG</span><span class="sxs-lookup"><span data-stu-id="c5aed-701">JPEG</span></span></td>
<td align="left"><span data-ttu-id="c5aed-702">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-702">D/E</span></span></td>
<td align="left"><span data-ttu-id="c5aed-703">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-703">D/E</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="c5aed-704">JPEG-XR</span><span class="sxs-lookup"><span data-stu-id="c5aed-704">JPEG-XR</span></span></td>
<td align="left"><span data-ttu-id="c5aed-705">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-705">D/E</span></span></td>
<td align="left"><span data-ttu-id="c5aed-706">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-706">D/E</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="c5aed-707">PNG</span><span class="sxs-lookup"><span data-stu-id="c5aed-707">PNG</span></span></td>
<td align="left"><span data-ttu-id="c5aed-708">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-708">D/E</span></span></td>
<td align="left"><span data-ttu-id="c5aed-709">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-709">D/E</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="c5aed-710">TIFF</span><span class="sxs-lookup"><span data-stu-id="c5aed-710">TIFF</span></span></td>
<td align="left"><span data-ttu-id="c5aed-711">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-711">D/E</span></span></td>
<td align="left"><span data-ttu-id="c5aed-712">D/E</span><span class="sxs-lookup"><span data-stu-id="c5aed-712">D/E</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="c5aed-713">RAW 形式のカメラ</span><span class="sxs-lookup"><span data-stu-id="c5aed-713">Camera RAW</span></span></td>
<td align="left"><span data-ttu-id="c5aed-714">D<sup>3</sup></span><span class="sxs-lookup"><span data-stu-id="c5aed-714">D<sup>3</sup></span></span></td>
<td align="left"><span data-ttu-id="c5aed-715">X</span><span class="sxs-lookup"><span data-stu-id="c5aed-715">No</span></span></td>
</tr>
</table>

<span data-ttu-id="c5aed-716"><sup>1</sup> BC5 圧縮による BC1 を使用した DDS イメージがサポートされています。</span><span class="sxs-lookup"><span data-stu-id="c5aed-716"><sup>1</sup> DDS images using BC1 through BC5 compression are supported.</span></span>  
<span data-ttu-id="c5aed-717"><sup>2</sup> 非 RAW 形式の埋め込みプレビューを含む DNG イメージがサポートされています。</span><span class="sxs-lookup"><span data-stu-id="c5aed-717"><sup>2</sup> DNG images with a non-RAW embedded preview are supported.</span></span>  
<span data-ttu-id="c5aed-718"><sup>3</sup> 特定のカメラの RAW 形式のみがサポートされています。</span><span class="sxs-lookup"><span data-stu-id="c5aed-718"><sup>3</sup> Only certain camera RAW formats are supported.</span></span>  

<span data-ttu-id="c5aed-719">イメージ コーデックの詳細については、「[ネイティブ WIC コーデック](https://msdn.microsoft.com/library/windows/desktop/gg430027.aspx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c5aed-719">For more information on image codecs, see [Native WIC Codecs](https://msdn.microsoft.com/library/windows/desktop/gg430027.aspx).</span></span>