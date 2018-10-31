---
author: drewbatgit
ms.assetid: 9347AD7C-3A90-4073-BFF4-9E8237398343
description: この記事では、UWP アプリ用のオーディオとビデオのコーデックおよび形式のサポートを示します。
title: サポートされているコーデック
ms.author: drewbat
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 57a604b1b3996019bcf6e39bc88c9a59a74cb51c
ms.sourcegitcommit: cd00bb829306871e5103db481cf224ea7fb613f0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/31/2018
ms.locfileid: "5868116"
---
# <a name="supported-codecs"></a><span data-ttu-id="05225-104">サポートされているコーデック</span><span class="sxs-lookup"><span data-stu-id="05225-104">Supported codecs</span></span>

<span data-ttu-id="05225-105">この記事では、各デバイス ファミリの既定で、UWP アプリで利用可能なオーディオ、ビデオ、イメージのコーデックと形式を示します。</span><span class="sxs-lookup"><span data-stu-id="05225-105">This article lists the audio, video, and image codec and format availability for UWP apps by default for each device family.</span></span> <span data-ttu-id="05225-106">これらの表では、指定のデバイス ファミリの Windows 10 のインストールに含まれているコーデックを示していることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="05225-106">Note that these tables list the codecs that are included with the Windows 10 installation for the specified device family.</span></span> <span data-ttu-id="05225-107">ユーザーやアプリが、利用可能な追加のコーデックをインストールする場合があります。</span><span class="sxs-lookup"><span data-stu-id="05225-107">Users and apps can install additional codecs that may be available to use.</span></span> <span data-ttu-id="05225-108">実行時に、特定のデバイスで現在利用可能なコーデックのセットを照会できます。</span><span class="sxs-lookup"><span data-stu-id="05225-108">You can query at runtime for the set of codecs that are currently available for a specific device.</span></span> <span data-ttu-id="05225-109">詳しくは、「[デバイスにインストールされているコーデックの照会](codec-query.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="05225-109">For more information, see [Query for codecs installed on a device](codec-query.md).</span></span>

<span data-ttu-id="05225-110">以下の表では、"D" はデコーダーのサポートを示し、"E" はエンコーダーのサポートを示します。</span><span class="sxs-lookup"><span data-stu-id="05225-110">In the tables below "D" indicates decoder support and "E" indicates encoder support.</span></span>

## <a name="audio-codec--format-support"></a><span data-ttu-id="05225-111">オーディオのコーデックおよび形式のサポート</span><span class="sxs-lookup"><span data-stu-id="05225-111">Audio codec & format support</span></span>

<span data-ttu-id="05225-112">次の表は、各デバイス ファミリのオーディオのコーデックと形式のサポートを示しています。</span><span class="sxs-lookup"><span data-stu-id="05225-112">The following tables show the audio codec and format support for each device family.</span></span>

> [!NOTE] 
> <span data-ttu-id="05225-113">AMR-NB のサポートが示されている場合、Server SKU ではこのコーデックがサポートされません。</span><span class="sxs-lookup"><span data-stu-id="05225-113">Where AMR-NB support is indicated, this codec is not supported on Server SKUs.</span></span>

 

### <a name="desktop"></a><span data-ttu-id="05225-114">デスクトップ</span><span class="sxs-lookup"><span data-stu-id="05225-114">Desktop</span></span>

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
<th align="left"><span data-ttu-id="05225-115">コーデック/コンテナー</span><span class="sxs-lookup"><span data-stu-id="05225-115">Codec/Container</span></span></th>
<th align="left"><span data-ttu-id="05225-116">MPEG-4</span><span class="sxs-lookup"><span data-stu-id="05225-116">MPEG-4</span></span></th>
<th align="left"><span data-ttu-id="05225-117">MPEG-3</span><span class="sxs-lookup"><span data-stu-id="05225-117">MPEG-3</span></span></th>
<th align="left"><span data-ttu-id="05225-118">MPEG-2</span><span class="sxs-lookup"><span data-stu-id="05225-118">MPEG-2</span></span></th>
<th align="left"><span data-ttu-id="05225-119">ADTS</span><span class="sxs-lookup"><span data-stu-id="05225-119">ADTS</span></span></th>
<th align="left"><span data-ttu-id="05225-120">ASF</span><span class="sxs-lookup"><span data-stu-id="05225-120">ASF</span></span></th>
<th align="left"><span data-ttu-id="05225-121">RIFF</span><span class="sxs-lookup"><span data-stu-id="05225-121">RIFF</span></span></th>
<th align="left"><span data-ttu-id="05225-122">AVI</span><span class="sxs-lookup"><span data-stu-id="05225-122">AVI</span></span></th>
<th align="left"><span data-ttu-id="05225-123">AC-3</span><span class="sxs-lookup"><span data-stu-id="05225-123">AC-3</span></span></th>
<th align="left"><span data-ttu-id="05225-124">AMR</span><span class="sxs-lookup"><span data-stu-id="05225-124">AMR</span></span></th>
<th align="left"><span data-ttu-id="05225-125">3GP</span><span class="sxs-lookup"><span data-stu-id="05225-125">3GP</span></span></th>
<th align="left"><span data-ttu-id="05225-126">FLAC</span><span class="sxs-lookup"><span data-stu-id="05225-126">FLAC</span></span></th>
<th align="left"><span data-ttu-id="05225-127">WAV</span><span class="sxs-lookup"><span data-stu-id="05225-127">WAV</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="05225-128">HE-AAC v1/AAC+</span><span class="sxs-lookup"><span data-stu-id="05225-128">HE-AAC v1 / AAC+</span></span></td>
<td align="left"><span data-ttu-id="05225-129">D</span><span class="sxs-lookup"><span data-stu-id="05225-129">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-130">D</span><span class="sxs-lookup"><span data-stu-id="05225-130">D</span></span></td>
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
<td align="left"><span data-ttu-id="05225-131">HE-AAC v2/eAAC+</span><span class="sxs-lookup"><span data-stu-id="05225-131">HE-AAC v2 / eAAC+</span></span></td>
<td align="left"><span data-ttu-id="05225-132">D</span><span class="sxs-lookup"><span data-stu-id="05225-132">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-133">D</span><span class="sxs-lookup"><span data-stu-id="05225-133">D</span></span></td>
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
<td align="left"><span data-ttu-id="05225-134">AAC-LC</span><span class="sxs-lookup"><span data-stu-id="05225-134">AAC-LC</span></span></td>
<td align="left"><span data-ttu-id="05225-135">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-135">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-136">D</span><span class="sxs-lookup"><span data-stu-id="05225-136">D</span></span></td>
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
<td align="left"><span data-ttu-id="05225-137">AC3</span><span class="sxs-lookup"><span data-stu-id="05225-137">AC3</span></span></td>
<td align="left"><span data-ttu-id="05225-138">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-138">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-139">D</span><span class="sxs-lookup"><span data-stu-id="05225-139">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-140">D</span><span class="sxs-lookup"><span data-stu-id="05225-140">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="05225-141">EAC3/EC3</span><span class="sxs-lookup"><span data-stu-id="05225-141">EAC3 / EC3</span></span></td>
<td align="left"><span data-ttu-id="05225-142">D</span><span class="sxs-lookup"><span data-stu-id="05225-142">D</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-143">D</span><span class="sxs-lookup"><span data-stu-id="05225-143">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-144">D</span><span class="sxs-lookup"><span data-stu-id="05225-144">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="05225-145">ALAC</span><span class="sxs-lookup"><span data-stu-id="05225-145">ALAC</span></span></td>
<td align="left"><span data-ttu-id="05225-146">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-146">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="05225-147">AMR-NB</span><span class="sxs-lookup"><span data-stu-id="05225-147">AMR-NB</span></span></td>
<td align="left"><span data-ttu-id="05225-148">D</span><span class="sxs-lookup"><span data-stu-id="05225-148">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-149">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-149">D/E</span></span></td>
<td align="left"><span data-ttu-id="05225-150">D</span><span class="sxs-lookup"><span data-stu-id="05225-150">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="05225-151">FLAC</span><span class="sxs-lookup"><span data-stu-id="05225-151">FLAC</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-152">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-152">D/E</span></span></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="05225-153">G.711 (A-Law、µ-law)</span><span class="sxs-lookup"><span data-stu-id="05225-153">G.711 (A-Law, µ-law)</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-154">D</span><span class="sxs-lookup"><span data-stu-id="05225-154">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="05225-155">GSM 6.10</span><span class="sxs-lookup"><span data-stu-id="05225-155">GSM 6.10</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-156">D</span><span class="sxs-lookup"><span data-stu-id="05225-156">D</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="05225-157">IMA ADPCM</span><span class="sxs-lookup"><span data-stu-id="05225-157">IMA ADPCM</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-158">D</span><span class="sxs-lookup"><span data-stu-id="05225-158">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="05225-159">LPCM</span><span class="sxs-lookup"><span data-stu-id="05225-159">LPCM</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-160">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-160">D/E</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="05225-161">MP3</span><span class="sxs-lookup"><span data-stu-id="05225-161">MP3</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-162">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-162">D/E</span></span></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="05225-163">MPEG-1/2</span><span class="sxs-lookup"><span data-stu-id="05225-163">MPEG-1/2</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-164">D</span><span class="sxs-lookup"><span data-stu-id="05225-164">D</span></span></td>
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
<td align="left"><span data-ttu-id="05225-165">MS ADPCM</span><span class="sxs-lookup"><span data-stu-id="05225-165">MS ADPCM</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-166">D</span><span class="sxs-lookup"><span data-stu-id="05225-166">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="05225-167">WMA 1/2/3</span><span class="sxs-lookup"><span data-stu-id="05225-167">WMA 1/2/3</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-168">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-168">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="05225-169">WMA Pro</span><span class="sxs-lookup"><span data-stu-id="05225-169">WMA Pro</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-170">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-170">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="05225-171">WMA Voice</span><span class="sxs-lookup"><span data-stu-id="05225-171">WMA Voice</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-172">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-172">D/E</span></span></td>
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

 

### <a name="mobile"></a><span data-ttu-id="05225-173">モバイル</span><span class="sxs-lookup"><span data-stu-id="05225-173">Mobile</span></span>

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
<th align="left"><span data-ttu-id="05225-174">コーデック/コンテナー</span><span class="sxs-lookup"><span data-stu-id="05225-174">Codec/Container</span></span></th>
<th align="left"><span data-ttu-id="05225-175">MPEG-4</span><span class="sxs-lookup"><span data-stu-id="05225-175">MPEG-4</span></span></th>
<th align="left"><span data-ttu-id="05225-176">MPEG-3</span><span class="sxs-lookup"><span data-stu-id="05225-176">MPEG-3</span></span></th>
<th align="left"><span data-ttu-id="05225-177">MPEG-2</span><span class="sxs-lookup"><span data-stu-id="05225-177">MPEG-2</span></span></th>
<th align="left"><span data-ttu-id="05225-178">ADTS</span><span class="sxs-lookup"><span data-stu-id="05225-178">ADTS</span></span></th>
<th align="left"><span data-ttu-id="05225-179">ASF</span><span class="sxs-lookup"><span data-stu-id="05225-179">ASF</span></span></th>
<th align="left"><span data-ttu-id="05225-180">RIFF</span><span class="sxs-lookup"><span data-stu-id="05225-180">RIFF</span></span></th>
<th align="left"><span data-ttu-id="05225-181">AVI</span><span class="sxs-lookup"><span data-stu-id="05225-181">AVI</span></span></th>
<th align="left"><span data-ttu-id="05225-182">AC-3</span><span class="sxs-lookup"><span data-stu-id="05225-182">AC-3</span></span></th>
<th align="left"><span data-ttu-id="05225-183">AMR</span><span class="sxs-lookup"><span data-stu-id="05225-183">AMR</span></span></th>
<th align="left"><span data-ttu-id="05225-184">3GP</span><span class="sxs-lookup"><span data-stu-id="05225-184">3GP</span></span></th>
<th align="left"><span data-ttu-id="05225-185">FLAC</span><span class="sxs-lookup"><span data-stu-id="05225-185">FLAC</span></span></th>
<th align="left"><span data-ttu-id="05225-186">WAV</span><span class="sxs-lookup"><span data-stu-id="05225-186">WAV</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="05225-187">HE-AAC v1/AAC+</span><span class="sxs-lookup"><span data-stu-id="05225-187">HE-AAC v1 / AAC+</span></span></td>
<td align="left"><span data-ttu-id="05225-188">D</span><span class="sxs-lookup"><span data-stu-id="05225-188">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-189">D</span><span class="sxs-lookup"><span data-stu-id="05225-189">D</span></span></td>
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
<td align="left"><span data-ttu-id="05225-190">HE-AAC v2/eAAC+</span><span class="sxs-lookup"><span data-stu-id="05225-190">HE-AAC v2 / eAAC+</span></span></td>
<td align="left"><span data-ttu-id="05225-191">D</span><span class="sxs-lookup"><span data-stu-id="05225-191">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-192">D</span><span class="sxs-lookup"><span data-stu-id="05225-192">D</span></span></td>
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
<td align="left"><span data-ttu-id="05225-193">AAC-LC</span><span class="sxs-lookup"><span data-stu-id="05225-193">AAC-LC</span></span></td>
<td align="left"><span data-ttu-id="05225-194">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-194">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-195">D</span><span class="sxs-lookup"><span data-stu-id="05225-195">D</span></span></td>
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
<td align="left"><span data-ttu-id="05225-196">AC3</span><span class="sxs-lookup"><span data-stu-id="05225-196">AC3</span></span></td>
<td align="left"><span data-ttu-id="05225-197">D (Lumia Icon、830、930、1520 のみ)</span><span class="sxs-lookup"><span data-stu-id="05225-197">D, Only on Lumia Icon, 830, 930, 1520</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-198">D (Lumia Icon、830、930、1520 のみ)</span><span class="sxs-lookup"><span data-stu-id="05225-198">D, Only on Lumia Icon, 830, 930, 1520</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-199">D (Lumia Icon、830、930、1520 のみ)</span><span class="sxs-lookup"><span data-stu-id="05225-199">D, Only on Lumia Icon, 830, 930, 1520</span></span></td>
<td align="left"><span data-ttu-id="05225-200">D (Lumia Icon、830、930、1520 のみ)</span><span class="sxs-lookup"><span data-stu-id="05225-200">D, Only on Lumia Icon, 830, 930, 1520</span></span></td>
<td align="left"><span data-ttu-id="05225-201">D (Lumia Icon、830、930、1520 のみ)</span><span class="sxs-lookup"><span data-stu-id="05225-201">D, Only on Lumia Icon, 830, 930, 1520</span></span></td>
<td align="left"><span data-ttu-id="05225-202">D (Lumia Icon、830、930、1520 のみ)</span><span class="sxs-lookup"><span data-stu-id="05225-202">D, Only on Lumia Icon, 830, 930, 1520</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="05225-203">EAC3/EC3</span><span class="sxs-lookup"><span data-stu-id="05225-203">EAC3 / EC3</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="05225-204">ALAC</span><span class="sxs-lookup"><span data-stu-id="05225-204">ALAC</span></span></td>
<td align="left"><span data-ttu-id="05225-205">D</span><span class="sxs-lookup"><span data-stu-id="05225-205">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="05225-206">AMR-NB</span><span class="sxs-lookup"><span data-stu-id="05225-206">AMR-NB</span></span></td>
<td align="left"><span data-ttu-id="05225-207">D</span><span class="sxs-lookup"><span data-stu-id="05225-207">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-208">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-208">D/E</span></span></td>
<td align="left"><span data-ttu-id="05225-209">D</span><span class="sxs-lookup"><span data-stu-id="05225-209">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="05225-210">FLAC</span><span class="sxs-lookup"><span data-stu-id="05225-210">FLAC</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-211">D</span><span class="sxs-lookup"><span data-stu-id="05225-211">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="05225-212">G.711 (A-Law、µ-law)</span><span class="sxs-lookup"><span data-stu-id="05225-212">G.711 (A-Law, µ-law)</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-213">D</span><span class="sxs-lookup"><span data-stu-id="05225-213">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="05225-214">GSM 6.10</span><span class="sxs-lookup"><span data-stu-id="05225-214">GSM 6.10</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-215">D</span><span class="sxs-lookup"><span data-stu-id="05225-215">D</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="05225-216">IMA ADPCM</span><span class="sxs-lookup"><span data-stu-id="05225-216">IMA ADPCM</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-217">D</span><span class="sxs-lookup"><span data-stu-id="05225-217">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="05225-218">LPCM</span><span class="sxs-lookup"><span data-stu-id="05225-218">LPCM</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-219">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-219">D/E</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="05225-220">MP3</span><span class="sxs-lookup"><span data-stu-id="05225-220">MP3</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-221">D</span><span class="sxs-lookup"><span data-stu-id="05225-221">D</span></span></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="05225-222">MPEG-1/2</span><span class="sxs-lookup"><span data-stu-id="05225-222">MPEG-1/2</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="05225-223">MS ADPCM</span><span class="sxs-lookup"><span data-stu-id="05225-223">MS ADPCM</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-224">D</span><span class="sxs-lookup"><span data-stu-id="05225-224">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="05225-225">WMA 1/2/3</span><span class="sxs-lookup"><span data-stu-id="05225-225">WMA 1/2/3</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-226">D</span><span class="sxs-lookup"><span data-stu-id="05225-226">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="05225-227">WMA Pro</span><span class="sxs-lookup"><span data-stu-id="05225-227">WMA Pro</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-228">D</span><span class="sxs-lookup"><span data-stu-id="05225-228">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="05225-229">WMA Voice</span><span class="sxs-lookup"><span data-stu-id="05225-229">WMA Voice</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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

 

### <a name="iot-core-x86"></a><span data-ttu-id="05225-230">IoT Core (x86)</span><span class="sxs-lookup"><span data-stu-id="05225-230">IoT Core (x86)</span></span>

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
<th align="left"><span data-ttu-id="05225-231">コーデック/コンテナー</span><span class="sxs-lookup"><span data-stu-id="05225-231">Codec/Container</span></span></th>
<th align="left"><span data-ttu-id="05225-232">MPEG-4</span><span class="sxs-lookup"><span data-stu-id="05225-232">MPEG-4</span></span></th>
<th align="left"><span data-ttu-id="05225-233">MPEG-3</span><span class="sxs-lookup"><span data-stu-id="05225-233">MPEG-3</span></span></th>
<th align="left"><span data-ttu-id="05225-234">MPEG-2</span><span class="sxs-lookup"><span data-stu-id="05225-234">MPEG-2</span></span></th>
<th align="left"><span data-ttu-id="05225-235">ADTS</span><span class="sxs-lookup"><span data-stu-id="05225-235">ADTS</span></span></th>
<th align="left"><span data-ttu-id="05225-236">ASF</span><span class="sxs-lookup"><span data-stu-id="05225-236">ASF</span></span></th>
<th align="left"><span data-ttu-id="05225-237">RIFF</span><span class="sxs-lookup"><span data-stu-id="05225-237">RIFF</span></span></th>
<th align="left"><span data-ttu-id="05225-238">AVI</span><span class="sxs-lookup"><span data-stu-id="05225-238">AVI</span></span></th>
<th align="left"><span data-ttu-id="05225-239">AC-3</span><span class="sxs-lookup"><span data-stu-id="05225-239">AC-3</span></span></th>
<th align="left"><span data-ttu-id="05225-240">AMR</span><span class="sxs-lookup"><span data-stu-id="05225-240">AMR</span></span></th>
<th align="left"><span data-ttu-id="05225-241">3GP</span><span class="sxs-lookup"><span data-stu-id="05225-241">3GP</span></span></th>
<th align="left"><span data-ttu-id="05225-242">FLAC</span><span class="sxs-lookup"><span data-stu-id="05225-242">FLAC</span></span></th>
<th align="left"><span data-ttu-id="05225-243">WAV</span><span class="sxs-lookup"><span data-stu-id="05225-243">WAV</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="05225-244">HE-AAC v1/AAC+</span><span class="sxs-lookup"><span data-stu-id="05225-244">HE-AAC v1 / AAC+</span></span></td>
<td align="left"><span data-ttu-id="05225-245">D</span><span class="sxs-lookup"><span data-stu-id="05225-245">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-246">D</span><span class="sxs-lookup"><span data-stu-id="05225-246">D</span></span></td>
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
<td align="left"><span data-ttu-id="05225-247">HE-AAC v2/eAAC+</span><span class="sxs-lookup"><span data-stu-id="05225-247">HE-AAC v2 / eAAC+</span></span></td>
<td align="left"><span data-ttu-id="05225-248">D</span><span class="sxs-lookup"><span data-stu-id="05225-248">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-249">D</span><span class="sxs-lookup"><span data-stu-id="05225-249">D</span></span></td>
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
<td align="left"><span data-ttu-id="05225-250">AAC-LC</span><span class="sxs-lookup"><span data-stu-id="05225-250">AAC-LC</span></span></td>
<td align="left"><span data-ttu-id="05225-251">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-251">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-252">D</span><span class="sxs-lookup"><span data-stu-id="05225-252">D</span></span></td>
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
<td align="left"><span data-ttu-id="05225-253">AC3</span><span class="sxs-lookup"><span data-stu-id="05225-253">AC3</span></span></td>
<td align="left"><span data-ttu-id="05225-254">D</span><span class="sxs-lookup"><span data-stu-id="05225-254">D</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-255">D</span><span class="sxs-lookup"><span data-stu-id="05225-255">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-256">D</span><span class="sxs-lookup"><span data-stu-id="05225-256">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="05225-257">EAC3/EC3</span><span class="sxs-lookup"><span data-stu-id="05225-257">EAC3 / EC3</span></span></td>
<td align="left"><span data-ttu-id="05225-258">D</span><span class="sxs-lookup"><span data-stu-id="05225-258">D</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-259">D</span><span class="sxs-lookup"><span data-stu-id="05225-259">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-260">D</span><span class="sxs-lookup"><span data-stu-id="05225-260">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="05225-261">ALAC</span><span class="sxs-lookup"><span data-stu-id="05225-261">ALAC</span></span></td>
<td align="left"><span data-ttu-id="05225-262">D</span><span class="sxs-lookup"><span data-stu-id="05225-262">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="05225-263">AMR-NB</span><span class="sxs-lookup"><span data-stu-id="05225-263">AMR-NB</span></span></td>
<td align="left"><span data-ttu-id="05225-264">D</span><span class="sxs-lookup"><span data-stu-id="05225-264">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-265">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-265">D/E</span></span></td>
<td align="left"><span data-ttu-id="05225-266">D</span><span class="sxs-lookup"><span data-stu-id="05225-266">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="05225-267">FLAC</span><span class="sxs-lookup"><span data-stu-id="05225-267">FLAC</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-268">D</span><span class="sxs-lookup"><span data-stu-id="05225-268">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="05225-269">G.711 (A-Law、µ-law)</span><span class="sxs-lookup"><span data-stu-id="05225-269">G.711 (A-Law, µ-law)</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-270">D</span><span class="sxs-lookup"><span data-stu-id="05225-270">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="05225-271">GSM 6.10</span><span class="sxs-lookup"><span data-stu-id="05225-271">GSM 6.10</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-272">D</span><span class="sxs-lookup"><span data-stu-id="05225-272">D</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="05225-273">IMA ADPCM</span><span class="sxs-lookup"><span data-stu-id="05225-273">IMA ADPCM</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-274">D</span><span class="sxs-lookup"><span data-stu-id="05225-274">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="05225-275">LPCM</span><span class="sxs-lookup"><span data-stu-id="05225-275">LPCM</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-276">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-276">D/E</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="05225-277">MP3</span><span class="sxs-lookup"><span data-stu-id="05225-277">MP3</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-278">D</span><span class="sxs-lookup"><span data-stu-id="05225-278">D</span></span></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="05225-279">MPEG-1/2</span><span class="sxs-lookup"><span data-stu-id="05225-279">MPEG-1/2</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-280">D</span><span class="sxs-lookup"><span data-stu-id="05225-280">D</span></span></td>
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
<td align="left"><span data-ttu-id="05225-281">MS ADPCM</span><span class="sxs-lookup"><span data-stu-id="05225-281">MS ADPCM</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-282">D</span><span class="sxs-lookup"><span data-stu-id="05225-282">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="05225-283">WMA 1/2/3</span><span class="sxs-lookup"><span data-stu-id="05225-283">WMA 1/2/3</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-284">D</span><span class="sxs-lookup"><span data-stu-id="05225-284">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="05225-285">WMA Pro</span><span class="sxs-lookup"><span data-stu-id="05225-285">WMA Pro</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-286">D</span><span class="sxs-lookup"><span data-stu-id="05225-286">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="05225-287">WMA Voice</span><span class="sxs-lookup"><span data-stu-id="05225-287">WMA Voice</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-288">D</span><span class="sxs-lookup"><span data-stu-id="05225-288">D</span></span></td>
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

 

### <a name="iot-core-arm"></a><span data-ttu-id="05225-289">IoT Core (ARM)</span><span class="sxs-lookup"><span data-stu-id="05225-289">IoT Core (ARM)</span></span>

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
<th align="left"><span data-ttu-id="05225-290">コーデック/コンテナー</span><span class="sxs-lookup"><span data-stu-id="05225-290">Codec/Container</span></span></th>
<th align="left"><span data-ttu-id="05225-291">MPEG-4</span><span class="sxs-lookup"><span data-stu-id="05225-291">MPEG-4</span></span></th>
<th align="left"><span data-ttu-id="05225-292">MPEG-3</span><span class="sxs-lookup"><span data-stu-id="05225-292">MPEG-3</span></span></th>
<th align="left"><span data-ttu-id="05225-293">MPEG-2</span><span class="sxs-lookup"><span data-stu-id="05225-293">MPEG-2</span></span></th>
<th align="left"><span data-ttu-id="05225-294">ADTS</span><span class="sxs-lookup"><span data-stu-id="05225-294">ADTS</span></span></th>
<th align="left"><span data-ttu-id="05225-295">ASF</span><span class="sxs-lookup"><span data-stu-id="05225-295">ASF</span></span></th>
<th align="left"><span data-ttu-id="05225-296">RIFF</span><span class="sxs-lookup"><span data-stu-id="05225-296">RIFF</span></span></th>
<th align="left"><span data-ttu-id="05225-297">AVI</span><span class="sxs-lookup"><span data-stu-id="05225-297">AVI</span></span></th>
<th align="left"><span data-ttu-id="05225-298">AC-3</span><span class="sxs-lookup"><span data-stu-id="05225-298">AC-3</span></span></th>
<th align="left"><span data-ttu-id="05225-299">AMR</span><span class="sxs-lookup"><span data-stu-id="05225-299">AMR</span></span></th>
<th align="left"><span data-ttu-id="05225-300">3GP</span><span class="sxs-lookup"><span data-stu-id="05225-300">3GP</span></span></th>
<th align="left"><span data-ttu-id="05225-301">FLAC</span><span class="sxs-lookup"><span data-stu-id="05225-301">FLAC</span></span></th>
<th align="left"><span data-ttu-id="05225-302">WAV</span><span class="sxs-lookup"><span data-stu-id="05225-302">WAV</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="05225-303">HE-AAC v1/AAC+</span><span class="sxs-lookup"><span data-stu-id="05225-303">HE-AAC v1 / AAC+</span></span></td>
<td align="left"><span data-ttu-id="05225-304">D</span><span class="sxs-lookup"><span data-stu-id="05225-304">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-305">D</span><span class="sxs-lookup"><span data-stu-id="05225-305">D</span></span></td>
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
<td align="left"><span data-ttu-id="05225-306">HE-AAC v2/eAAC+</span><span class="sxs-lookup"><span data-stu-id="05225-306">HE-AAC v2 / eAAC+</span></span></td>
<td align="left"><span data-ttu-id="05225-307">D</span><span class="sxs-lookup"><span data-stu-id="05225-307">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-308">D</span><span class="sxs-lookup"><span data-stu-id="05225-308">D</span></span></td>
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
<td align="left"><span data-ttu-id="05225-309">AAC-LC</span><span class="sxs-lookup"><span data-stu-id="05225-309">AAC-LC</span></span></td>
<td align="left"><span data-ttu-id="05225-310">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-310">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-311">D</span><span class="sxs-lookup"><span data-stu-id="05225-311">D</span></span></td>
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
<td align="left"><span data-ttu-id="05225-312">AC3</span><span class="sxs-lookup"><span data-stu-id="05225-312">AC3</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="05225-313">EAC3/EC3</span><span class="sxs-lookup"><span data-stu-id="05225-313">EAC3 / EC3</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="05225-314">ALAC</span><span class="sxs-lookup"><span data-stu-id="05225-314">ALAC</span></span></td>
<td align="left"><span data-ttu-id="05225-315">D</span><span class="sxs-lookup"><span data-stu-id="05225-315">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="05225-316">AMR-NB</span><span class="sxs-lookup"><span data-stu-id="05225-316">AMR-NB</span></span></td>
<td align="left"><span data-ttu-id="05225-317">D</span><span class="sxs-lookup"><span data-stu-id="05225-317">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-318">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-318">D/E</span></span></td>
<td align="left"><span data-ttu-id="05225-319">D</span><span class="sxs-lookup"><span data-stu-id="05225-319">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="05225-320">FLAC</span><span class="sxs-lookup"><span data-stu-id="05225-320">FLAC</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-321">D</span><span class="sxs-lookup"><span data-stu-id="05225-321">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="05225-322">G.711 (A-Law、µ-law)</span><span class="sxs-lookup"><span data-stu-id="05225-322">G.711 (A-Law, µ-law)</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-323">D</span><span class="sxs-lookup"><span data-stu-id="05225-323">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="05225-324">GSM 6.10</span><span class="sxs-lookup"><span data-stu-id="05225-324">GSM 6.10</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-325">D</span><span class="sxs-lookup"><span data-stu-id="05225-325">D</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="05225-326">IMA ADPCM</span><span class="sxs-lookup"><span data-stu-id="05225-326">IMA ADPCM</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-327">D</span><span class="sxs-lookup"><span data-stu-id="05225-327">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="05225-328">LPCM</span><span class="sxs-lookup"><span data-stu-id="05225-328">LPCM</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-329">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-329">D/E</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="05225-330">MP3</span><span class="sxs-lookup"><span data-stu-id="05225-330">MP3</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-331">D</span><span class="sxs-lookup"><span data-stu-id="05225-331">D</span></span></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="05225-332">MPEG-1/2</span><span class="sxs-lookup"><span data-stu-id="05225-332">MPEG-1/2</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-333">D</span><span class="sxs-lookup"><span data-stu-id="05225-333">D</span></span></td>
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
<td align="left"><span data-ttu-id="05225-334">MS ADPCM</span><span class="sxs-lookup"><span data-stu-id="05225-334">MS ADPCM</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-335">D</span><span class="sxs-lookup"><span data-stu-id="05225-335">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="05225-336">WMA 1/2/3</span><span class="sxs-lookup"><span data-stu-id="05225-336">WMA 1/2/3</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-337">D</span><span class="sxs-lookup"><span data-stu-id="05225-337">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="05225-338">WMA Pro</span><span class="sxs-lookup"><span data-stu-id="05225-338">WMA Pro</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-339">D</span><span class="sxs-lookup"><span data-stu-id="05225-339">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="05225-340">WMA Voice</span><span class="sxs-lookup"><span data-stu-id="05225-340">WMA Voice</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-341">D</span><span class="sxs-lookup"><span data-stu-id="05225-341">D</span></span></td>
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

 

### <a name="xbox"></a><span data-ttu-id="05225-342">Xbox</span><span class="sxs-lookup"><span data-stu-id="05225-342">XBox</span></span>

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
<th align="left"><span data-ttu-id="05225-343">コーデック/コンテナー</span><span class="sxs-lookup"><span data-stu-id="05225-343">Codec/Container</span></span></th>
<th align="left"><span data-ttu-id="05225-344">MPEG-4</span><span class="sxs-lookup"><span data-stu-id="05225-344">MPEG-4</span></span></th>
<th align="left"><span data-ttu-id="05225-345">MPEG-3</span><span class="sxs-lookup"><span data-stu-id="05225-345">MPEG-3</span></span></th>
<th align="left"><span data-ttu-id="05225-346">MPEG-2</span><span class="sxs-lookup"><span data-stu-id="05225-346">MPEG-2</span></span></th>
<th align="left"><span data-ttu-id="05225-347">ADTS</span><span class="sxs-lookup"><span data-stu-id="05225-347">ADTS</span></span></th>
<th align="left"><span data-ttu-id="05225-348">ASF</span><span class="sxs-lookup"><span data-stu-id="05225-348">ASF</span></span></th>
<th align="left"><span data-ttu-id="05225-349">RIFF</span><span class="sxs-lookup"><span data-stu-id="05225-349">RIFF</span></span></th>
<th align="left"><span data-ttu-id="05225-350">AVI</span><span class="sxs-lookup"><span data-stu-id="05225-350">AVI</span></span></th>
<th align="left"><span data-ttu-id="05225-351">AC-3</span><span class="sxs-lookup"><span data-stu-id="05225-351">AC-3</span></span></th>
<th align="left"><span data-ttu-id="05225-352">AMR</span><span class="sxs-lookup"><span data-stu-id="05225-352">AMR</span></span></th>
<th align="left"><span data-ttu-id="05225-353">3GP</span><span class="sxs-lookup"><span data-stu-id="05225-353">3GP</span></span></th>
<th align="left"><span data-ttu-id="05225-354">FLAC</span><span class="sxs-lookup"><span data-stu-id="05225-354">FLAC</span></span></th>
<th align="left"><span data-ttu-id="05225-355">WAV</span><span class="sxs-lookup"><span data-stu-id="05225-355">WAV</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="05225-356">HE-AAC v1/AAC+</span><span class="sxs-lookup"><span data-stu-id="05225-356">HE-AAC v1 / AAC+</span></span></td>
<td align="left"><span data-ttu-id="05225-357">D</span><span class="sxs-lookup"><span data-stu-id="05225-357">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-358">D</span><span class="sxs-lookup"><span data-stu-id="05225-358">D</span></span></td>
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
<td align="left"><span data-ttu-id="05225-359">HE-AAC v2/eAAC+</span><span class="sxs-lookup"><span data-stu-id="05225-359">HE-AAC v2 / eAAC+</span></span></td>
<td align="left"><span data-ttu-id="05225-360">D</span><span class="sxs-lookup"><span data-stu-id="05225-360">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-361">D</span><span class="sxs-lookup"><span data-stu-id="05225-361">D</span></span></td>
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
<td align="left"><span data-ttu-id="05225-362">AAC-LC</span><span class="sxs-lookup"><span data-stu-id="05225-362">AAC-LC</span></span></td>
<td align="left"><span data-ttu-id="05225-363">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-363">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-364">D</span><span class="sxs-lookup"><span data-stu-id="05225-364">D</span></span></td>
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
<td align="left"><span data-ttu-id="05225-365">AC3</span><span class="sxs-lookup"><span data-stu-id="05225-365">AC3</span></span></td>
<td align="left"><span data-ttu-id="05225-366">D</span><span class="sxs-lookup"><span data-stu-id="05225-366">D</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-367">D</span><span class="sxs-lookup"><span data-stu-id="05225-367">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-368">D</span><span class="sxs-lookup"><span data-stu-id="05225-368">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="05225-369">EAC3/EC3</span><span class="sxs-lookup"><span data-stu-id="05225-369">EAC3 / EC3</span></span></td>
<td align="left"><span data-ttu-id="05225-370">D</span><span class="sxs-lookup"><span data-stu-id="05225-370">D</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-371">D</span><span class="sxs-lookup"><span data-stu-id="05225-371">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-372">D</span><span class="sxs-lookup"><span data-stu-id="05225-372">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="05225-373">ALAC</span><span class="sxs-lookup"><span data-stu-id="05225-373">ALAC</span></span></td>
<td align="left"><span data-ttu-id="05225-374">D</span><span class="sxs-lookup"><span data-stu-id="05225-374">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="05225-375">AMR-NB</span><span class="sxs-lookup"><span data-stu-id="05225-375">AMR-NB</span></span></td>
<td align="left"><span data-ttu-id="05225-376">D</span><span class="sxs-lookup"><span data-stu-id="05225-376">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-377">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-377">D/E</span></span></td>
<td align="left"><span data-ttu-id="05225-378">D</span><span class="sxs-lookup"><span data-stu-id="05225-378">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="05225-379">FLAC</span><span class="sxs-lookup"><span data-stu-id="05225-379">FLAC</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-380">D</span><span class="sxs-lookup"><span data-stu-id="05225-380">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="05225-381">G.711 (A-Law、µ-law)</span><span class="sxs-lookup"><span data-stu-id="05225-381">G.711 (A-Law, µ-law)</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-382">D</span><span class="sxs-lookup"><span data-stu-id="05225-382">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="05225-383">GSM 6.10</span><span class="sxs-lookup"><span data-stu-id="05225-383">GSM 6.10</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-384">D</span><span class="sxs-lookup"><span data-stu-id="05225-384">D</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="05225-385">IMA ADPCM</span><span class="sxs-lookup"><span data-stu-id="05225-385">IMA ADPCM</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-386">D</span><span class="sxs-lookup"><span data-stu-id="05225-386">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="05225-387">LPCM</span><span class="sxs-lookup"><span data-stu-id="05225-387">LPCM</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-388">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-388">D/E</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="05225-389">MP3</span><span class="sxs-lookup"><span data-stu-id="05225-389">MP3</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-390">D</span><span class="sxs-lookup"><span data-stu-id="05225-390">D</span></span></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="05225-391">MPEG-1/2</span><span class="sxs-lookup"><span data-stu-id="05225-391">MPEG-1/2</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-392">D</span><span class="sxs-lookup"><span data-stu-id="05225-392">D</span></span></td>
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
<td align="left"><span data-ttu-id="05225-393">MS ADPCM</span><span class="sxs-lookup"><span data-stu-id="05225-393">MS ADPCM</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-394">D</span><span class="sxs-lookup"><span data-stu-id="05225-394">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="05225-395">WMA 1/2/3</span><span class="sxs-lookup"><span data-stu-id="05225-395">WMA 1/2/3</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-396">D</span><span class="sxs-lookup"><span data-stu-id="05225-396">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="05225-397">WMA Pro</span><span class="sxs-lookup"><span data-stu-id="05225-397">WMA Pro</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-398">D</span><span class="sxs-lookup"><span data-stu-id="05225-398">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="05225-399">WMA Voice</span><span class="sxs-lookup"><span data-stu-id="05225-399">WMA Voice</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-400">D</span><span class="sxs-lookup"><span data-stu-id="05225-400">D</span></span></td>
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

 

## <a name="video-codec--format-support"></a><span data-ttu-id="05225-401">ビデオのコーデックおよび形式のサポート</span><span class="sxs-lookup"><span data-stu-id="05225-401">Video codec & format support</span></span>

<span data-ttu-id="05225-402">次の表は、各デバイス ファミリのビデオのコーデックと形式のサポートを示しています。</span><span class="sxs-lookup"><span data-stu-id="05225-402">The following tables show the video codec and format support for each device family.</span></span>

> [!NOTE] 
> <span data-ttu-id="05225-403">H.265 のサポートが示されている場合、必ずしもデバイス ファミリ内のすべてのデバイスでサポートされるわけではありません。</span><span class="sxs-lookup"><span data-stu-id="05225-403">Where H.265 support is indicated, it is not necessarily supported by all devices within the device family.</span></span>
> <span data-ttu-id="05225-404">MPEG-2/MPEG-1 のサポートが示されている場合、オプションの Microsoft DVD ユニバーサル Windows アプリのインストールでのみサポートされます。</span><span class="sxs-lookup"><span data-stu-id="05225-404">Where MPEG-2/MPEG-1 support is indicated, it is only supported with the installation of the optional Microsoft DVD Universal Windows app.</span></span>

 

### <a name="desktop"></a><span data-ttu-id="05225-405">デスクトップ</span><span class="sxs-lookup"><span data-stu-id="05225-405">Desktop</span></span>

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
<th align="left"><span data-ttu-id="05225-406">コーデック/コンテナー</span><span class="sxs-lookup"><span data-stu-id="05225-406">Codec/Container</span></span></th>
<th align="left"><span data-ttu-id="05225-407">FOURCC</span><span class="sxs-lookup"><span data-stu-id="05225-407">FOURCC</span></span></th>
<th align="left"><span data-ttu-id="05225-408">fMP4</span><span class="sxs-lookup"><span data-stu-id="05225-408">fMP4</span></span></th>
<th align="left"><span data-ttu-id="05225-409">MPEG-4</span><span class="sxs-lookup"><span data-stu-id="05225-409">MPEG-4</span></span></th>
<th align="left"><span data-ttu-id="05225-410">MPEG-2 PS</span><span class="sxs-lookup"><span data-stu-id="05225-410">MPEG-2 PS</span></span></th>
<th align="left"><span data-ttu-id="05225-411">MPEG-2 TS</span><span class="sxs-lookup"><span data-stu-id="05225-411">MPEG-2 TS</span></span></th>
<th align="left"><span data-ttu-id="05225-412">MPEG-1</span><span class="sxs-lookup"><span data-stu-id="05225-412">MPEG-1</span></span></th>
<th align="left"><span data-ttu-id="05225-413">3GPP</span><span class="sxs-lookup"><span data-stu-id="05225-413">3GPP</span></span></th>
<th align="left"><span data-ttu-id="05225-414">3GPP2</span><span class="sxs-lookup"><span data-stu-id="05225-414">3GPP2</span></span></th>
<th align="left"><span data-ttu-id="05225-415">AVCHD</span><span class="sxs-lookup"><span data-stu-id="05225-415">AVCHD</span></span></th>
<th align="left"><span data-ttu-id="05225-416">ASF</span><span class="sxs-lookup"><span data-stu-id="05225-416">ASF</span></span></th>
<th align="left"><span data-ttu-id="05225-417">AVI</span><span class="sxs-lookup"><span data-stu-id="05225-417">AVI</span></span></th>
<th align="left"><span data-ttu-id="05225-418">MKV</span><span class="sxs-lookup"><span data-stu-id="05225-418">MKV</span></span></th>
<th align="left"><span data-ttu-id="05225-419">DV</span><span class="sxs-lookup"><span data-stu-id="05225-419">DV</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="05225-420">MPEG-1</span><span class="sxs-lookup"><span data-stu-id="05225-420">MPEG-1</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-421">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-421">D/E</span></span></td>
<td align="left"><span data-ttu-id="05225-422">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-422">D/E</span></span></td>
<td align="left"><span data-ttu-id="05225-423">D</span><span class="sxs-lookup"><span data-stu-id="05225-423">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-424">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-424">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-425">D</span><span class="sxs-lookup"><span data-stu-id="05225-425">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="05225-426">MPEG-2</span><span class="sxs-lookup"><span data-stu-id="05225-426">MPEG-2</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-427">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-427">D/E</span></span></td>
<td align="left"><span data-ttu-id="05225-428">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-428">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-429">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-429">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-430">D</span><span class="sxs-lookup"><span data-stu-id="05225-430">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="05225-431">MPEG-4 (Part 2)</span><span class="sxs-lookup"><span data-stu-id="05225-431">MPEG-4 (Part 2)</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-432">D</span><span class="sxs-lookup"><span data-stu-id="05225-432">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-433">D</span><span class="sxs-lookup"><span data-stu-id="05225-433">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-434">D</span><span class="sxs-lookup"><span data-stu-id="05225-434">D</span></span></td>
<td align="left"><span data-ttu-id="05225-435">D</span><span class="sxs-lookup"><span data-stu-id="05225-435">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="05225-436">H.265</span><span class="sxs-lookup"><span data-stu-id="05225-436">H.265</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-437">D</span><span class="sxs-lookup"><span data-stu-id="05225-437">D</span></span></td>
<td align="left"><span data-ttu-id="05225-438">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-438">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-439">D</span><span class="sxs-lookup"><span data-stu-id="05225-439">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="05225-440">H.264</span><span class="sxs-lookup"><span data-stu-id="05225-440">H.264</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-441">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-441">D/E</span></span></td>
<td align="left"><span data-ttu-id="05225-442">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-442">D/E</span></span></td>
<td align="left"><span data-ttu-id="05225-443">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-443">D/E</span></span></td>
<td align="left"><span data-ttu-id="05225-444">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-444">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-445">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-445">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-446">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-446">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-447">D</span><span class="sxs-lookup"><span data-stu-id="05225-447">D</span></span></td>
<td align="left"><span data-ttu-id="05225-448">D</span><span class="sxs-lookup"><span data-stu-id="05225-448">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="05225-449">H.263</span><span class="sxs-lookup"><span data-stu-id="05225-449">H.263</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-450">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-450">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-451">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-451">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-452">D</span><span class="sxs-lookup"><span data-stu-id="05225-452">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="05225-453">VC-1</span><span class="sxs-lookup"><span data-stu-id="05225-453">VC-1</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-454">D</span><span class="sxs-lookup"><span data-stu-id="05225-454">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-455">D</span><span class="sxs-lookup"><span data-stu-id="05225-455">D</span></span></td>
<td align="left"><span data-ttu-id="05225-456">D</span><span class="sxs-lookup"><span data-stu-id="05225-456">D</span></span></td>
<td align="left"><span data-ttu-id="05225-457">D</span><span class="sxs-lookup"><span data-stu-id="05225-457">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="05225-458">WMV7/8/9</span><span class="sxs-lookup"><span data-stu-id="05225-458">WMV7/8/9</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-459">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-459">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-460">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-460">D/E</span></span></td>
<td align="left"><span data-ttu-id="05225-461">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-461">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="05225-462">WMV9 Screen</span><span class="sxs-lookup"><span data-stu-id="05225-462">WMV9 Screen</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-463">D</span><span class="sxs-lookup"><span data-stu-id="05225-463">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-464">D</span><span class="sxs-lookup"><span data-stu-id="05225-464">D</span></span></td>
<td align="left"><span data-ttu-id="05225-465">D</span><span class="sxs-lookup"><span data-stu-id="05225-465">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="05225-466">DV</span><span class="sxs-lookup"><span data-stu-id="05225-466">DV</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-467">D</span><span class="sxs-lookup"><span data-stu-id="05225-467">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-468">D</span><span class="sxs-lookup"><span data-stu-id="05225-468">D</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-469">D</span><span class="sxs-lookup"><span data-stu-id="05225-469">D</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="05225-470">モーション JPEG</span><span class="sxs-lookup"><span data-stu-id="05225-470">Motion JPEG</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-471">D</span><span class="sxs-lookup"><span data-stu-id="05225-471">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-472">D</span><span class="sxs-lookup"><span data-stu-id="05225-472">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
</tbody>
</table>

 

### <a name="mobile"></a><span data-ttu-id="05225-473">モバイル</span><span class="sxs-lookup"><span data-stu-id="05225-473">Mobile</span></span>

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
<th align="left"><span data-ttu-id="05225-474">コーデック/コンテナー</span><span class="sxs-lookup"><span data-stu-id="05225-474">Codec/Container</span></span></th>
<th align="left"><span data-ttu-id="05225-475">FOURCC</span><span class="sxs-lookup"><span data-stu-id="05225-475">FOURCC</span></span></th>
<th align="left"><span data-ttu-id="05225-476">fMP4</span><span class="sxs-lookup"><span data-stu-id="05225-476">fMP4</span></span></th>
<th align="left"><span data-ttu-id="05225-477">MPEG-4</span><span class="sxs-lookup"><span data-stu-id="05225-477">MPEG-4</span></span></th>
<th align="left"><span data-ttu-id="05225-478">MPEG-2 PS</span><span class="sxs-lookup"><span data-stu-id="05225-478">MPEG-2 PS</span></span></th>
<th align="left"><span data-ttu-id="05225-479">MPEG-2 TS</span><span class="sxs-lookup"><span data-stu-id="05225-479">MPEG-2 TS</span></span></th>
<th align="left"><span data-ttu-id="05225-480">MPEG-1</span><span class="sxs-lookup"><span data-stu-id="05225-480">MPEG-1</span></span></th>
<th align="left"><span data-ttu-id="05225-481">3GPP</span><span class="sxs-lookup"><span data-stu-id="05225-481">3GPP</span></span></th>
<th align="left"><span data-ttu-id="05225-482">3GPP2</span><span class="sxs-lookup"><span data-stu-id="05225-482">3GPP2</span></span></th>
<th align="left"><span data-ttu-id="05225-483">AVCHD</span><span class="sxs-lookup"><span data-stu-id="05225-483">AVCHD</span></span></th>
<th align="left"><span data-ttu-id="05225-484">ASF</span><span class="sxs-lookup"><span data-stu-id="05225-484">ASF</span></span></th>
<th align="left"><span data-ttu-id="05225-485">AVI</span><span class="sxs-lookup"><span data-stu-id="05225-485">AVI</span></span></th>
<th align="left"><span data-ttu-id="05225-486">MKV</span><span class="sxs-lookup"><span data-stu-id="05225-486">MKV</span></span></th>
<th align="left"><span data-ttu-id="05225-487">DV</span><span class="sxs-lookup"><span data-stu-id="05225-487">DV</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="05225-488">MPEG-1</span><span class="sxs-lookup"><span data-stu-id="05225-488">MPEG-1</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="05225-489">MPEG-2</span><span class="sxs-lookup"><span data-stu-id="05225-489">MPEG-2</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="05225-490">MPEG-4 (Part 2)</span><span class="sxs-lookup"><span data-stu-id="05225-490">MPEG-4 (Part 2)</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-491">D</span><span class="sxs-lookup"><span data-stu-id="05225-491">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-492">D</span><span class="sxs-lookup"><span data-stu-id="05225-492">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-493">D</span><span class="sxs-lookup"><span data-stu-id="05225-493">D</span></span></td>
<td align="left"><span data-ttu-id="05225-494">D</span><span class="sxs-lookup"><span data-stu-id="05225-494">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="05225-495">H.265</span><span class="sxs-lookup"><span data-stu-id="05225-495">H.265</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-496">D</span><span class="sxs-lookup"><span data-stu-id="05225-496">D</span></span></td>
<td align="left"><span data-ttu-id="05225-497">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-497">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-498">D</span><span class="sxs-lookup"><span data-stu-id="05225-498">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="05225-499">H.264</span><span class="sxs-lookup"><span data-stu-id="05225-499">H.264</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-500">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-500">D/E</span></span></td>
<td align="left"><span data-ttu-id="05225-501">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-501">D/E</span></span></td>
<td align="left"><span data-ttu-id="05225-502">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-502">D/E</span></span></td>
<td align="left"><span data-ttu-id="05225-503">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-503">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-504">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-504">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-505">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-505">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-506">D</span><span class="sxs-lookup"><span data-stu-id="05225-506">D</span></span></td>
<td align="left"><span data-ttu-id="05225-507">D</span><span class="sxs-lookup"><span data-stu-id="05225-507">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="05225-508">H.263</span><span class="sxs-lookup"><span data-stu-id="05225-508">H.263</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-509">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-509">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-510">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-510">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-511">D</span><span class="sxs-lookup"><span data-stu-id="05225-511">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="05225-512">VC-1</span><span class="sxs-lookup"><span data-stu-id="05225-512">VC-1</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-513">D</span><span class="sxs-lookup"><span data-stu-id="05225-513">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-514">D</span><span class="sxs-lookup"><span data-stu-id="05225-514">D</span></span></td>
<td align="left"><span data-ttu-id="05225-515">D</span><span class="sxs-lookup"><span data-stu-id="05225-515">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="05225-516">WMV7/8/9</span><span class="sxs-lookup"><span data-stu-id="05225-516">WMV7/8/9</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="05225-517">WMV9 Screen</span><span class="sxs-lookup"><span data-stu-id="05225-517">WMV9 Screen</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="05225-518">DV</span><span class="sxs-lookup"><span data-stu-id="05225-518">DV</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="05225-519">モーション JPEG</span><span class="sxs-lookup"><span data-stu-id="05225-519">Motion JPEG</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-520">D</span><span class="sxs-lookup"><span data-stu-id="05225-520">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-521">D</span><span class="sxs-lookup"><span data-stu-id="05225-521">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
</tbody>
</table>

 

### <a name="iot-core-x86"></a><span data-ttu-id="05225-522">IoT Core (x86)</span><span class="sxs-lookup"><span data-stu-id="05225-522">IoT Core (x86)</span></span>

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
<th align="left"><span data-ttu-id="05225-523">コーデック/コンテナー</span><span class="sxs-lookup"><span data-stu-id="05225-523">Codec/Container</span></span></th>
<th align="left"><span data-ttu-id="05225-524">FOURCC</span><span class="sxs-lookup"><span data-stu-id="05225-524">FOURCC</span></span></th>
<th align="left"><span data-ttu-id="05225-525">fMP4</span><span class="sxs-lookup"><span data-stu-id="05225-525">fMP4</span></span></th>
<th align="left"><span data-ttu-id="05225-526">MPEG-4</span><span class="sxs-lookup"><span data-stu-id="05225-526">MPEG-4</span></span></th>
<th align="left"><span data-ttu-id="05225-527">MPEG-2 PS</span><span class="sxs-lookup"><span data-stu-id="05225-527">MPEG-2 PS</span></span></th>
<th align="left"><span data-ttu-id="05225-528">MPEG-2 TS</span><span class="sxs-lookup"><span data-stu-id="05225-528">MPEG-2 TS</span></span></th>
<th align="left"><span data-ttu-id="05225-529">MPEG-1</span><span class="sxs-lookup"><span data-stu-id="05225-529">MPEG-1</span></span></th>
<th align="left"><span data-ttu-id="05225-530">3GPP</span><span class="sxs-lookup"><span data-stu-id="05225-530">3GPP</span></span></th>
<th align="left"><span data-ttu-id="05225-531">3GPP2</span><span class="sxs-lookup"><span data-stu-id="05225-531">3GPP2</span></span></th>
<th align="left"><span data-ttu-id="05225-532">AVCHD</span><span class="sxs-lookup"><span data-stu-id="05225-532">AVCHD</span></span></th>
<th align="left"><span data-ttu-id="05225-533">ASF</span><span class="sxs-lookup"><span data-stu-id="05225-533">ASF</span></span></th>
<th align="left"><span data-ttu-id="05225-534">AVI</span><span class="sxs-lookup"><span data-stu-id="05225-534">AVI</span></span></th>
<th align="left"><span data-ttu-id="05225-535">MKV</span><span class="sxs-lookup"><span data-stu-id="05225-535">MKV</span></span></th>
<th align="left"><span data-ttu-id="05225-536">DV</span><span class="sxs-lookup"><span data-stu-id="05225-536">DV</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="05225-537">MPEG-1</span><span class="sxs-lookup"><span data-stu-id="05225-537">MPEG-1</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="05225-538">MPEG-2</span><span class="sxs-lookup"><span data-stu-id="05225-538">MPEG-2</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="05225-539">MPEG-4 (Part 2)</span><span class="sxs-lookup"><span data-stu-id="05225-539">MPEG-4 (Part 2)</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-540">D</span><span class="sxs-lookup"><span data-stu-id="05225-540">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-541">D</span><span class="sxs-lookup"><span data-stu-id="05225-541">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-542">D</span><span class="sxs-lookup"><span data-stu-id="05225-542">D</span></span></td>
<td align="left"><span data-ttu-id="05225-543">D</span><span class="sxs-lookup"><span data-stu-id="05225-543">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="05225-544">H.265</span><span class="sxs-lookup"><span data-stu-id="05225-544">H.265</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-545">D</span><span class="sxs-lookup"><span data-stu-id="05225-545">D</span></span></td>
<td align="left"><span data-ttu-id="05225-546">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-546">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-547">D</span><span class="sxs-lookup"><span data-stu-id="05225-547">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="05225-548">H.264</span><span class="sxs-lookup"><span data-stu-id="05225-548">H.264</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-549">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-549">D/E</span></span></td>
<td align="left"><span data-ttu-id="05225-550">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-550">D/E</span></span></td>
<td align="left"><span data-ttu-id="05225-551">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-551">D/E</span></span></td>
<td align="left"><span data-ttu-id="05225-552">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-552">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-553">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-553">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-554">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-554">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-555">D</span><span class="sxs-lookup"><span data-stu-id="05225-555">D</span></span></td>
<td align="left"><span data-ttu-id="05225-556">D</span><span class="sxs-lookup"><span data-stu-id="05225-556">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="05225-557">H.263</span><span class="sxs-lookup"><span data-stu-id="05225-557">H.263</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-558">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-558">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-559">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-559">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-560">D</span><span class="sxs-lookup"><span data-stu-id="05225-560">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="05225-561">VC-1</span><span class="sxs-lookup"><span data-stu-id="05225-561">VC-1</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-562">D</span><span class="sxs-lookup"><span data-stu-id="05225-562">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-563">D</span><span class="sxs-lookup"><span data-stu-id="05225-563">D</span></span></td>
<td align="left"><span data-ttu-id="05225-564">D</span><span class="sxs-lookup"><span data-stu-id="05225-564">D</span></span></td>
<td align="left"><span data-ttu-id="05225-565">D</span><span class="sxs-lookup"><span data-stu-id="05225-565">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="05225-566">WMV7/8/9</span><span class="sxs-lookup"><span data-stu-id="05225-566">WMV7/8/9</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-567">D</span><span class="sxs-lookup"><span data-stu-id="05225-567">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-568">D</span><span class="sxs-lookup"><span data-stu-id="05225-568">D</span></span></td>
<td align="left"><span data-ttu-id="05225-569">D</span><span class="sxs-lookup"><span data-stu-id="05225-569">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="05225-570">WMV9 Screen</span><span class="sxs-lookup"><span data-stu-id="05225-570">WMV9 Screen</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-571">D</span><span class="sxs-lookup"><span data-stu-id="05225-571">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-572">D</span><span class="sxs-lookup"><span data-stu-id="05225-572">D</span></span></td>
<td align="left"><span data-ttu-id="05225-573">D</span><span class="sxs-lookup"><span data-stu-id="05225-573">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="05225-574">DV</span><span class="sxs-lookup"><span data-stu-id="05225-574">DV</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="05225-575">モーション JPEG</span><span class="sxs-lookup"><span data-stu-id="05225-575">Motion JPEG</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-576">D</span><span class="sxs-lookup"><span data-stu-id="05225-576">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-577">D</span><span class="sxs-lookup"><span data-stu-id="05225-577">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
</tbody>
</table>

 

### <a name="iot-arm"></a><span data-ttu-id="05225-578">IoT (ARM)</span><span class="sxs-lookup"><span data-stu-id="05225-578">IoT (ARM)</span></span>

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
<th align="left"><span data-ttu-id="05225-579">コーデック/コンテナー</span><span class="sxs-lookup"><span data-stu-id="05225-579">Codec/Container</span></span></th>
<th align="left"><span data-ttu-id="05225-580">FOURCC</span><span class="sxs-lookup"><span data-stu-id="05225-580">FOURCC</span></span></th>
<th align="left"><span data-ttu-id="05225-581">fMP4</span><span class="sxs-lookup"><span data-stu-id="05225-581">fMP4</span></span></th>
<th align="left"><span data-ttu-id="05225-582">MPEG-4</span><span class="sxs-lookup"><span data-stu-id="05225-582">MPEG-4</span></span></th>
<th align="left"><span data-ttu-id="05225-583">MPEG-2 PS</span><span class="sxs-lookup"><span data-stu-id="05225-583">MPEG-2 PS</span></span></th>
<th align="left"><span data-ttu-id="05225-584">MPEG-2 TS</span><span class="sxs-lookup"><span data-stu-id="05225-584">MPEG-2 TS</span></span></th>
<th align="left"><span data-ttu-id="05225-585">MPEG-1</span><span class="sxs-lookup"><span data-stu-id="05225-585">MPEG-1</span></span></th>
<th align="left"><span data-ttu-id="05225-586">3GPP</span><span class="sxs-lookup"><span data-stu-id="05225-586">3GPP</span></span></th>
<th align="left"><span data-ttu-id="05225-587">3GPP2</span><span class="sxs-lookup"><span data-stu-id="05225-587">3GPP2</span></span></th>
<th align="left"><span data-ttu-id="05225-588">AVCHD</span><span class="sxs-lookup"><span data-stu-id="05225-588">AVCHD</span></span></th>
<th align="left"><span data-ttu-id="05225-589">ASF</span><span class="sxs-lookup"><span data-stu-id="05225-589">ASF</span></span></th>
<th align="left"><span data-ttu-id="05225-590">AVI</span><span class="sxs-lookup"><span data-stu-id="05225-590">AVI</span></span></th>
<th align="left"><span data-ttu-id="05225-591">MKV</span><span class="sxs-lookup"><span data-stu-id="05225-591">MKV</span></span></th>
<th align="left"><span data-ttu-id="05225-592">DV</span><span class="sxs-lookup"><span data-stu-id="05225-592">DV</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="05225-593">MPEG-1</span><span class="sxs-lookup"><span data-stu-id="05225-593">MPEG-1</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="05225-594">MPEG-2</span><span class="sxs-lookup"><span data-stu-id="05225-594">MPEG-2</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="05225-595">MPEG-4 (Part 2)</span><span class="sxs-lookup"><span data-stu-id="05225-595">MPEG-4 (Part 2)</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="05225-596">H.265</span><span class="sxs-lookup"><span data-stu-id="05225-596">H.265</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-597">D</span><span class="sxs-lookup"><span data-stu-id="05225-597">D</span></span></td>
<td align="left"><span data-ttu-id="05225-598">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-598">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-599">D</span><span class="sxs-lookup"><span data-stu-id="05225-599">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="05225-600">H.264</span><span class="sxs-lookup"><span data-stu-id="05225-600">H.264</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-601">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-601">D/E</span></span></td>
<td align="left"><span data-ttu-id="05225-602">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-602">D/E</span></span></td>
<td align="left"><span data-ttu-id="05225-603">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-603">D/E</span></span></td>
<td align="left"><span data-ttu-id="05225-604">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-604">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-605">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-605">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-606">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-606">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-607">D</span><span class="sxs-lookup"><span data-stu-id="05225-607">D</span></span></td>
<td align="left"><span data-ttu-id="05225-608">D</span><span class="sxs-lookup"><span data-stu-id="05225-608">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="05225-609">H.263</span><span class="sxs-lookup"><span data-stu-id="05225-609">H.263</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="05225-610">VC-1</span><span class="sxs-lookup"><span data-stu-id="05225-610">VC-1</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-611">D</span><span class="sxs-lookup"><span data-stu-id="05225-611">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-612">D</span><span class="sxs-lookup"><span data-stu-id="05225-612">D</span></span></td>
<td align="left"><span data-ttu-id="05225-613">D</span><span class="sxs-lookup"><span data-stu-id="05225-613">D</span></span></td>
<td align="left"><span data-ttu-id="05225-614">D</span><span class="sxs-lookup"><span data-stu-id="05225-614">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="05225-615">WMV7/8/9</span><span class="sxs-lookup"><span data-stu-id="05225-615">WMV7/8/9</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-616">D</span><span class="sxs-lookup"><span data-stu-id="05225-616">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-617">D</span><span class="sxs-lookup"><span data-stu-id="05225-617">D</span></span></td>
<td align="left"><span data-ttu-id="05225-618">D</span><span class="sxs-lookup"><span data-stu-id="05225-618">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="05225-619">WMV9 Screen</span><span class="sxs-lookup"><span data-stu-id="05225-619">WMV9 Screen</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="05225-620">DV</span><span class="sxs-lookup"><span data-stu-id="05225-620">DV</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="05225-621">モーション JPEG</span><span class="sxs-lookup"><span data-stu-id="05225-621">Motion JPEG</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-622">D</span><span class="sxs-lookup"><span data-stu-id="05225-622">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-623">D</span><span class="sxs-lookup"><span data-stu-id="05225-623">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
</tbody>
</table>

 

### <a name="xbox"></a><span data-ttu-id="05225-624">Xbox</span><span class="sxs-lookup"><span data-stu-id="05225-624">XBox</span></span>

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
<th align="left"><span data-ttu-id="05225-625">コーデック/コンテナー</span><span class="sxs-lookup"><span data-stu-id="05225-625">Codec/Container</span></span></th>
<th align="left"><span data-ttu-id="05225-626">FOURCC</span><span class="sxs-lookup"><span data-stu-id="05225-626">FOURCC</span></span></th>
<th align="left"><span data-ttu-id="05225-627">fMP4</span><span class="sxs-lookup"><span data-stu-id="05225-627">fMP4</span></span></th>
<th align="left"><span data-ttu-id="05225-628">MPEG-4</span><span class="sxs-lookup"><span data-stu-id="05225-628">MPEG-4</span></span></th>
<th align="left"><span data-ttu-id="05225-629">MPEG-2 PS</span><span class="sxs-lookup"><span data-stu-id="05225-629">MPEG-2 PS</span></span></th>
<th align="left"><span data-ttu-id="05225-630">MPEG-2 TS</span><span class="sxs-lookup"><span data-stu-id="05225-630">MPEG-2 TS</span></span></th>
<th align="left"><span data-ttu-id="05225-631">MPEG-1</span><span class="sxs-lookup"><span data-stu-id="05225-631">MPEG-1</span></span></th>
<th align="left"><span data-ttu-id="05225-632">3GPP</span><span class="sxs-lookup"><span data-stu-id="05225-632">3GPP</span></span></th>
<th align="left"><span data-ttu-id="05225-633">3GPP2</span><span class="sxs-lookup"><span data-stu-id="05225-633">3GPP2</span></span></th>
<th align="left"><span data-ttu-id="05225-634">AVCHD</span><span class="sxs-lookup"><span data-stu-id="05225-634">AVCHD</span></span></th>
<th align="left"><span data-ttu-id="05225-635">ASF</span><span class="sxs-lookup"><span data-stu-id="05225-635">ASF</span></span></th>
<th align="left"><span data-ttu-id="05225-636">AVI</span><span class="sxs-lookup"><span data-stu-id="05225-636">AVI</span></span></th>
<th align="left"><span data-ttu-id="05225-637">MKV</span><span class="sxs-lookup"><span data-stu-id="05225-637">MKV</span></span></th>
<th align="left"><span data-ttu-id="05225-638">DV</span><span class="sxs-lookup"><span data-stu-id="05225-638">DV</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="05225-639">MPEG-1</span><span class="sxs-lookup"><span data-stu-id="05225-639">MPEG-1</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-640">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-640">D/E</span></span></td>
<td align="left"><span data-ttu-id="05225-641">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-641">D/E</span></span></td>
<td align="left"><span data-ttu-id="05225-642">D</span><span class="sxs-lookup"><span data-stu-id="05225-642">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-643">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-643">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-644">D</span><span class="sxs-lookup"><span data-stu-id="05225-644">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="05225-645">MPEG-2</span><span class="sxs-lookup"><span data-stu-id="05225-645">MPEG-2</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-646">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-646">D/E</span></span></td>
<td align="left"><span data-ttu-id="05225-647">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-647">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-648">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-648">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-649">D</span><span class="sxs-lookup"><span data-stu-id="05225-649">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="05225-650">MPEG-4 (Part 2)</span><span class="sxs-lookup"><span data-stu-id="05225-650">MPEG-4 (Part 2)</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-651">D</span><span class="sxs-lookup"><span data-stu-id="05225-651">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-652">D</span><span class="sxs-lookup"><span data-stu-id="05225-652">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-653">D</span><span class="sxs-lookup"><span data-stu-id="05225-653">D</span></span></td>
<td align="left"><span data-ttu-id="05225-654">D</span><span class="sxs-lookup"><span data-stu-id="05225-654">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="05225-655">H.265</span><span class="sxs-lookup"><span data-stu-id="05225-655">H.265</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-656">D</span><span class="sxs-lookup"><span data-stu-id="05225-656">D</span></span></td>
<td align="left"><span data-ttu-id="05225-657">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-657">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-658">D</span><span class="sxs-lookup"><span data-stu-id="05225-658">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="05225-659">H.264</span><span class="sxs-lookup"><span data-stu-id="05225-659">H.264</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-660">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-660">D/E</span></span></td>
<td align="left"><span data-ttu-id="05225-661">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-661">D/E</span></span></td>
<td align="left"><span data-ttu-id="05225-662">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-662">D/E</span></span></td>
<td align="left"><span data-ttu-id="05225-663">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-663">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-664">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-664">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-665">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-665">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-666">D</span><span class="sxs-lookup"><span data-stu-id="05225-666">D</span></span></td>
<td align="left"><span data-ttu-id="05225-667">D</span><span class="sxs-lookup"><span data-stu-id="05225-667">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="05225-668">H.263</span><span class="sxs-lookup"><span data-stu-id="05225-668">H.263</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-669">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-669">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-670">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-670">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-671">D</span><span class="sxs-lookup"><span data-stu-id="05225-671">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="05225-672">VC-1</span><span class="sxs-lookup"><span data-stu-id="05225-672">VC-1</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-673">D</span><span class="sxs-lookup"><span data-stu-id="05225-673">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-674">D</span><span class="sxs-lookup"><span data-stu-id="05225-674">D</span></span></td>
<td align="left"><span data-ttu-id="05225-675">D</span><span class="sxs-lookup"><span data-stu-id="05225-675">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="05225-676">WMV7/8/9</span><span class="sxs-lookup"><span data-stu-id="05225-676">WMV7/8/9</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="05225-677">WMV9 Screen</span><span class="sxs-lookup"><span data-stu-id="05225-677">WMV9 Screen</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="05225-678">DV</span><span class="sxs-lookup"><span data-stu-id="05225-678">DV</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="05225-679">モーション JPEG</span><span class="sxs-lookup"><span data-stu-id="05225-679">Motion JPEG</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-680">D</span><span class="sxs-lookup"><span data-stu-id="05225-680">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="05225-681">D</span><span class="sxs-lookup"><span data-stu-id="05225-681">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
</tbody>
</table>

## <a name="image-codec--format-support"></a><span data-ttu-id="05225-682">イメージのコーデックおよび形式のサポート</span><span class="sxs-lookup"><span data-stu-id="05225-682">Image codec & format support</span></span> 

<table>
<colgroup>
<col width="7%" />
<col width="7%" />
<col width="7%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="05225-683">コーデック</span><span class="sxs-lookup"><span data-stu-id="05225-683">Codec</span></span></th>
<th align="left"><span data-ttu-id="05225-684">デスクトップ</span><span class="sxs-lookup"><span data-stu-id="05225-684">Desktop</span></span></th>
<th align="left"><span data-ttu-id="05225-685">他のデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="05225-685">Other device families</span></span></th>
</tr>
</thead>
<tr class="odd">
<td align="left"><span data-ttu-id="05225-686">BMP</span><span class="sxs-lookup"><span data-stu-id="05225-686">BMP</span></span></td>
<td align="left"><span data-ttu-id="05225-687">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-687">D/E</span></span></td>
<td align="left"><span data-ttu-id="05225-688">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-688">D/E</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="05225-689">DDS</span><span class="sxs-lookup"><span data-stu-id="05225-689">DDS</span></span></td>
<td align="left"><span data-ttu-id="05225-690">D/E<sup>1</sup></span><span class="sxs-lookup"><span data-stu-id="05225-690">D/E<sup>1</sup></span></span></td>
<td align="left"><span data-ttu-id="05225-691">D/E<sup>1</sup></span><span class="sxs-lookup"><span data-stu-id="05225-691">D/E<sup>1</sup></span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="05225-692">DNG</span><span class="sxs-lookup"><span data-stu-id="05225-692">DNG</span></span></td>
<td align="left"><span data-ttu-id="05225-693">D<sup>2</sup></span><span class="sxs-lookup"><span data-stu-id="05225-693">D<sup>2</sup></span></span></td>
<td align="left"><span data-ttu-id="05225-694">D<sup>2</sup></span><span class="sxs-lookup"><span data-stu-id="05225-694">D<sup>2</sup></span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="05225-695">GIF</span><span class="sxs-lookup"><span data-stu-id="05225-695">GIF</span></span></td>
<td align="left"><span data-ttu-id="05225-696">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-696">D/E</span></span></td>
<td align="left"><span data-ttu-id="05225-697">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-697">D/E</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="05225-698">ICO</span><span class="sxs-lookup"><span data-stu-id="05225-698">ICO</span></span></td>
<td align="left"><span data-ttu-id="05225-699">D</span><span class="sxs-lookup"><span data-stu-id="05225-699">D</span></span></td>
<td align="left"><span data-ttu-id="05225-700">D</span><span class="sxs-lookup"><span data-stu-id="05225-700">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="05225-701">JPEG</span><span class="sxs-lookup"><span data-stu-id="05225-701">JPEG</span></span></td>
<td align="left"><span data-ttu-id="05225-702">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-702">D/E</span></span></td>
<td align="left"><span data-ttu-id="05225-703">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-703">D/E</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="05225-704">JPEG-XR</span><span class="sxs-lookup"><span data-stu-id="05225-704">JPEG-XR</span></span></td>
<td align="left"><span data-ttu-id="05225-705">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-705">D/E</span></span></td>
<td align="left"><span data-ttu-id="05225-706">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-706">D/E</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="05225-707">PNG</span><span class="sxs-lookup"><span data-stu-id="05225-707">PNG</span></span></td>
<td align="left"><span data-ttu-id="05225-708">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-708">D/E</span></span></td>
<td align="left"><span data-ttu-id="05225-709">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-709">D/E</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="05225-710">TIFF</span><span class="sxs-lookup"><span data-stu-id="05225-710">TIFF</span></span></td>
<td align="left"><span data-ttu-id="05225-711">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-711">D/E</span></span></td>
<td align="left"><span data-ttu-id="05225-712">D/E</span><span class="sxs-lookup"><span data-stu-id="05225-712">D/E</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="05225-713">RAW 形式のカメラ</span><span class="sxs-lookup"><span data-stu-id="05225-713">Camera RAW</span></span></td>
<td align="left"><span data-ttu-id="05225-714">D<sup>3</sup></span><span class="sxs-lookup"><span data-stu-id="05225-714">D<sup>3</sup></span></span></td>
<td align="left"><span data-ttu-id="05225-715">なし</span><span class="sxs-lookup"><span data-stu-id="05225-715">No</span></span></td>
</tr>
</table>

<span data-ttu-id="05225-716"><sup>1</sup> BC5 圧縮による BC1 を使用した DDS イメージがサポートされています。</span><span class="sxs-lookup"><span data-stu-id="05225-716"><sup>1</sup> DDS images using BC1 through BC5 compression are supported.</span></span>  
<span data-ttu-id="05225-717"><sup>2</sup> 非 RAW 形式の埋め込みプレビューを含む DNG イメージがサポートされています。</span><span class="sxs-lookup"><span data-stu-id="05225-717"><sup>2</sup> DNG images with a non-RAW embedded preview are supported.</span></span>  
<span data-ttu-id="05225-718"><sup>3</sup> 特定のカメラの RAW 形式のみがサポートされています。</span><span class="sxs-lookup"><span data-stu-id="05225-718"><sup>3</sup> Only certain camera RAW formats are supported.</span></span>  

<span data-ttu-id="05225-719">イメージ コーデックの詳細については、「[ネイティブ WIC コーデック](https://msdn.microsoft.com/library/windows/desktop/gg430027.aspx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="05225-719">For more information on image codecs, see [Native WIC Codecs](https://msdn.microsoft.com/library/windows/desktop/gg430027.aspx).</span></span>