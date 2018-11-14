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
ms.sourcegitcommit: 4d88adfaf544a3dab05f4660e2f59bbe60311c00
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/12/2018
ms.locfileid: "6450851"
---
# <a name="supported-codecs"></a><span data-ttu-id="0a5dc-104">サポートされているコーデック</span><span class="sxs-lookup"><span data-stu-id="0a5dc-104">Supported codecs</span></span>

<span data-ttu-id="0a5dc-105">この記事では、各デバイス ファミリの既定で、UWP アプリで利用可能なオーディオ、ビデオ、イメージのコーデックと形式を示します。</span><span class="sxs-lookup"><span data-stu-id="0a5dc-105">This article lists the audio, video, and image codec and format availability for UWP apps by default for each device family.</span></span> <span data-ttu-id="0a5dc-106">これらの表では、指定のデバイス ファミリの Windows 10 のインストールに含まれているコーデックを示していることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="0a5dc-106">Note that these tables list the codecs that are included with the Windows 10 installation for the specified device family.</span></span> <span data-ttu-id="0a5dc-107">ユーザーやアプリが、利用可能な追加のコーデックをインストールする場合があります。</span><span class="sxs-lookup"><span data-stu-id="0a5dc-107">Users and apps can install additional codecs that may be available to use.</span></span> <span data-ttu-id="0a5dc-108">実行時に、特定のデバイスで現在利用可能なコーデックのセットを照会できます。</span><span class="sxs-lookup"><span data-stu-id="0a5dc-108">You can query at runtime for the set of codecs that are currently available for a specific device.</span></span> <span data-ttu-id="0a5dc-109">詳しくは、「[デバイスにインストールされているコーデックの照会](codec-query.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0a5dc-109">For more information, see [Query for codecs installed on a device](codec-query.md).</span></span>

<span data-ttu-id="0a5dc-110">以下の表では、"D" はデコーダーのサポートを示し、"E" はエンコーダーのサポートを示します。</span><span class="sxs-lookup"><span data-stu-id="0a5dc-110">In the tables below "D" indicates decoder support and "E" indicates encoder support.</span></span>

## <a name="audio-codec--format-support"></a><span data-ttu-id="0a5dc-111">オーディオのコーデックおよび形式のサポート</span><span class="sxs-lookup"><span data-stu-id="0a5dc-111">Audio codec & format support</span></span>

<span data-ttu-id="0a5dc-112">次の表は、各デバイス ファミリのオーディオのコーデックと形式のサポートを示しています。</span><span class="sxs-lookup"><span data-stu-id="0a5dc-112">The following tables show the audio codec and format support for each device family.</span></span>

> [!NOTE] 
> <span data-ttu-id="0a5dc-113">AMR-NB のサポートが示されている場合、Server SKU ではこのコーデックがサポートされません。</span><span class="sxs-lookup"><span data-stu-id="0a5dc-113">Where AMR-NB support is indicated, this codec is not supported on Server SKUs.</span></span>

 

### <a name="desktop"></a><span data-ttu-id="0a5dc-114">デスクトップ</span><span class="sxs-lookup"><span data-stu-id="0a5dc-114">Desktop</span></span>

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
<th align="left"><span data-ttu-id="0a5dc-115">コーデック/コンテナー</span><span class="sxs-lookup"><span data-stu-id="0a5dc-115">Codec/Container</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-116">MPEG-4</span><span class="sxs-lookup"><span data-stu-id="0a5dc-116">MPEG-4</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-117">MPEG-3</span><span class="sxs-lookup"><span data-stu-id="0a5dc-117">MPEG-3</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-118">MPEG-2</span><span class="sxs-lookup"><span data-stu-id="0a5dc-118">MPEG-2</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-119">ADTS</span><span class="sxs-lookup"><span data-stu-id="0a5dc-119">ADTS</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-120">ASF</span><span class="sxs-lookup"><span data-stu-id="0a5dc-120">ASF</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-121">RIFF</span><span class="sxs-lookup"><span data-stu-id="0a5dc-121">RIFF</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-122">AVI</span><span class="sxs-lookup"><span data-stu-id="0a5dc-122">AVI</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-123">AC-3</span><span class="sxs-lookup"><span data-stu-id="0a5dc-123">AC-3</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-124">AMR</span><span class="sxs-lookup"><span data-stu-id="0a5dc-124">AMR</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-125">3GP</span><span class="sxs-lookup"><span data-stu-id="0a5dc-125">3GP</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-126">FLAC</span><span class="sxs-lookup"><span data-stu-id="0a5dc-126">FLAC</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-127">WAV</span><span class="sxs-lookup"><span data-stu-id="0a5dc-127">WAV</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="0a5dc-128">HE-AAC v1/AAC+</span><span class="sxs-lookup"><span data-stu-id="0a5dc-128">HE-AAC v1 / AAC+</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-129">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-129">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-130">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-130">D</span></span></td>
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
<td align="left"><span data-ttu-id="0a5dc-131">HE-AAC v2/eAAC+</span><span class="sxs-lookup"><span data-stu-id="0a5dc-131">HE-AAC v2 / eAAC+</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-132">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-132">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-133">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-133">D</span></span></td>
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
<td align="left"><span data-ttu-id="0a5dc-134">AAC-LC</span><span class="sxs-lookup"><span data-stu-id="0a5dc-134">AAC-LC</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-135">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-135">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-136">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-136">D</span></span></td>
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
<td align="left"><span data-ttu-id="0a5dc-137">AC3</span><span class="sxs-lookup"><span data-stu-id="0a5dc-137">AC3</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-138">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-138">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-139">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-139">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-140">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-140">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0a5dc-141">EAC3/EC3</span><span class="sxs-lookup"><span data-stu-id="0a5dc-141">EAC3 / EC3</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-142">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-142">D</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-143">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-143">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-144">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-144">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0a5dc-145">ALAC</span><span class="sxs-lookup"><span data-stu-id="0a5dc-145">ALAC</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-146">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-146">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="0a5dc-147">AMR-NB</span><span class="sxs-lookup"><span data-stu-id="0a5dc-147">AMR-NB</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-148">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-148">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-149">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-149">D/E</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-150">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-150">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0a5dc-151">FLAC</span><span class="sxs-lookup"><span data-stu-id="0a5dc-151">FLAC</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-152">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-152">D/E</span></span></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0a5dc-153">G.711 (A-Law、µ-law)</span><span class="sxs-lookup"><span data-stu-id="0a5dc-153">G.711 (A-Law, µ-law)</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-154">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-154">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0a5dc-155">GSM 6.10</span><span class="sxs-lookup"><span data-stu-id="0a5dc-155">GSM 6.10</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-156">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-156">D</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0a5dc-157">IMA ADPCM</span><span class="sxs-lookup"><span data-stu-id="0a5dc-157">IMA ADPCM</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-158">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-158">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0a5dc-159">LPCM</span><span class="sxs-lookup"><span data-stu-id="0a5dc-159">LPCM</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-160">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-160">D/E</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0a5dc-161">MP3</span><span class="sxs-lookup"><span data-stu-id="0a5dc-161">MP3</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-162">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-162">D/E</span></span></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="0a5dc-163">MPEG-1/2</span><span class="sxs-lookup"><span data-stu-id="0a5dc-163">MPEG-1/2</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-164">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-164">D</span></span></td>
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
<td align="left"><span data-ttu-id="0a5dc-165">MS ADPCM</span><span class="sxs-lookup"><span data-stu-id="0a5dc-165">MS ADPCM</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-166">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-166">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0a5dc-167">WMA 1/2/3</span><span class="sxs-lookup"><span data-stu-id="0a5dc-167">WMA 1/2/3</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-168">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-168">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0a5dc-169">WMA Pro</span><span class="sxs-lookup"><span data-stu-id="0a5dc-169">WMA Pro</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-170">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-170">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0a5dc-171">WMA Voice</span><span class="sxs-lookup"><span data-stu-id="0a5dc-171">WMA Voice</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-172">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-172">D/E</span></span></td>
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

 

### <a name="mobile"></a><span data-ttu-id="0a5dc-173">モバイル</span><span class="sxs-lookup"><span data-stu-id="0a5dc-173">Mobile</span></span>

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
<th align="left"><span data-ttu-id="0a5dc-174">コーデック/コンテナー</span><span class="sxs-lookup"><span data-stu-id="0a5dc-174">Codec/Container</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-175">MPEG-4</span><span class="sxs-lookup"><span data-stu-id="0a5dc-175">MPEG-4</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-176">MPEG-3</span><span class="sxs-lookup"><span data-stu-id="0a5dc-176">MPEG-3</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-177">MPEG-2</span><span class="sxs-lookup"><span data-stu-id="0a5dc-177">MPEG-2</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-178">ADTS</span><span class="sxs-lookup"><span data-stu-id="0a5dc-178">ADTS</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-179">ASF</span><span class="sxs-lookup"><span data-stu-id="0a5dc-179">ASF</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-180">RIFF</span><span class="sxs-lookup"><span data-stu-id="0a5dc-180">RIFF</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-181">AVI</span><span class="sxs-lookup"><span data-stu-id="0a5dc-181">AVI</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-182">AC-3</span><span class="sxs-lookup"><span data-stu-id="0a5dc-182">AC-3</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-183">AMR</span><span class="sxs-lookup"><span data-stu-id="0a5dc-183">AMR</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-184">3GP</span><span class="sxs-lookup"><span data-stu-id="0a5dc-184">3GP</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-185">FLAC</span><span class="sxs-lookup"><span data-stu-id="0a5dc-185">FLAC</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-186">WAV</span><span class="sxs-lookup"><span data-stu-id="0a5dc-186">WAV</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="0a5dc-187">HE-AAC v1/AAC+</span><span class="sxs-lookup"><span data-stu-id="0a5dc-187">HE-AAC v1 / AAC+</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-188">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-188">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-189">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-189">D</span></span></td>
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
<td align="left"><span data-ttu-id="0a5dc-190">HE-AAC v2/eAAC+</span><span class="sxs-lookup"><span data-stu-id="0a5dc-190">HE-AAC v2 / eAAC+</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-191">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-191">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-192">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-192">D</span></span></td>
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
<td align="left"><span data-ttu-id="0a5dc-193">AAC-LC</span><span class="sxs-lookup"><span data-stu-id="0a5dc-193">AAC-LC</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-194">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-194">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-195">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-195">D</span></span></td>
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
<td align="left"><span data-ttu-id="0a5dc-196">AC3</span><span class="sxs-lookup"><span data-stu-id="0a5dc-196">AC3</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-197">D (Lumia Icon、830、930、1520 のみ)</span><span class="sxs-lookup"><span data-stu-id="0a5dc-197">D, Only on Lumia Icon, 830, 930, 1520</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-198">D (Lumia Icon、830、930、1520 のみ)</span><span class="sxs-lookup"><span data-stu-id="0a5dc-198">D, Only on Lumia Icon, 830, 930, 1520</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-199">D (Lumia Icon、830、930、1520 のみ)</span><span class="sxs-lookup"><span data-stu-id="0a5dc-199">D, Only on Lumia Icon, 830, 930, 1520</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-200">D (Lumia Icon、830、930、1520 のみ)</span><span class="sxs-lookup"><span data-stu-id="0a5dc-200">D, Only on Lumia Icon, 830, 930, 1520</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-201">D (Lumia Icon、830、930、1520 のみ)</span><span class="sxs-lookup"><span data-stu-id="0a5dc-201">D, Only on Lumia Icon, 830, 930, 1520</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-202">D (Lumia Icon、830、930、1520 のみ)</span><span class="sxs-lookup"><span data-stu-id="0a5dc-202">D, Only on Lumia Icon, 830, 930, 1520</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0a5dc-203">EAC3/EC3</span><span class="sxs-lookup"><span data-stu-id="0a5dc-203">EAC3 / EC3</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="0a5dc-204">ALAC</span><span class="sxs-lookup"><span data-stu-id="0a5dc-204">ALAC</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-205">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-205">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="0a5dc-206">AMR-NB</span><span class="sxs-lookup"><span data-stu-id="0a5dc-206">AMR-NB</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-207">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-207">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-208">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-208">D/E</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-209">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-209">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0a5dc-210">FLAC</span><span class="sxs-lookup"><span data-stu-id="0a5dc-210">FLAC</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-211">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-211">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0a5dc-212">G.711 (A-Law、µ-law)</span><span class="sxs-lookup"><span data-stu-id="0a5dc-212">G.711 (A-Law, µ-law)</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-213">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-213">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0a5dc-214">GSM 6.10</span><span class="sxs-lookup"><span data-stu-id="0a5dc-214">GSM 6.10</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-215">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-215">D</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0a5dc-216">IMA ADPCM</span><span class="sxs-lookup"><span data-stu-id="0a5dc-216">IMA ADPCM</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-217">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-217">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0a5dc-218">LPCM</span><span class="sxs-lookup"><span data-stu-id="0a5dc-218">LPCM</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-219">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-219">D/E</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0a5dc-220">MP3</span><span class="sxs-lookup"><span data-stu-id="0a5dc-220">MP3</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-221">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-221">D</span></span></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="0a5dc-222">MPEG-1/2</span><span class="sxs-lookup"><span data-stu-id="0a5dc-222">MPEG-1/2</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="0a5dc-223">MS ADPCM</span><span class="sxs-lookup"><span data-stu-id="0a5dc-223">MS ADPCM</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-224">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-224">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0a5dc-225">WMA 1/2/3</span><span class="sxs-lookup"><span data-stu-id="0a5dc-225">WMA 1/2/3</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-226">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-226">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0a5dc-227">WMA Pro</span><span class="sxs-lookup"><span data-stu-id="0a5dc-227">WMA Pro</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-228">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-228">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0a5dc-229">WMA Voice</span><span class="sxs-lookup"><span data-stu-id="0a5dc-229">WMA Voice</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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

 

### <a name="iot-core-x86"></a><span data-ttu-id="0a5dc-230">IoT Core (x86)</span><span class="sxs-lookup"><span data-stu-id="0a5dc-230">IoT Core (x86)</span></span>

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
<th align="left"><span data-ttu-id="0a5dc-231">コーデック/コンテナー</span><span class="sxs-lookup"><span data-stu-id="0a5dc-231">Codec/Container</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-232">MPEG-4</span><span class="sxs-lookup"><span data-stu-id="0a5dc-232">MPEG-4</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-233">MPEG-3</span><span class="sxs-lookup"><span data-stu-id="0a5dc-233">MPEG-3</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-234">MPEG-2</span><span class="sxs-lookup"><span data-stu-id="0a5dc-234">MPEG-2</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-235">ADTS</span><span class="sxs-lookup"><span data-stu-id="0a5dc-235">ADTS</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-236">ASF</span><span class="sxs-lookup"><span data-stu-id="0a5dc-236">ASF</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-237">RIFF</span><span class="sxs-lookup"><span data-stu-id="0a5dc-237">RIFF</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-238">AVI</span><span class="sxs-lookup"><span data-stu-id="0a5dc-238">AVI</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-239">AC-3</span><span class="sxs-lookup"><span data-stu-id="0a5dc-239">AC-3</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-240">AMR</span><span class="sxs-lookup"><span data-stu-id="0a5dc-240">AMR</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-241">3GP</span><span class="sxs-lookup"><span data-stu-id="0a5dc-241">3GP</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-242">FLAC</span><span class="sxs-lookup"><span data-stu-id="0a5dc-242">FLAC</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-243">WAV</span><span class="sxs-lookup"><span data-stu-id="0a5dc-243">WAV</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="0a5dc-244">HE-AAC v1/AAC+</span><span class="sxs-lookup"><span data-stu-id="0a5dc-244">HE-AAC v1 / AAC+</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-245">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-245">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-246">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-246">D</span></span></td>
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
<td align="left"><span data-ttu-id="0a5dc-247">HE-AAC v2/eAAC+</span><span class="sxs-lookup"><span data-stu-id="0a5dc-247">HE-AAC v2 / eAAC+</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-248">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-248">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-249">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-249">D</span></span></td>
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
<td align="left"><span data-ttu-id="0a5dc-250">AAC-LC</span><span class="sxs-lookup"><span data-stu-id="0a5dc-250">AAC-LC</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-251">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-251">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-252">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-252">D</span></span></td>
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
<td align="left"><span data-ttu-id="0a5dc-253">AC3</span><span class="sxs-lookup"><span data-stu-id="0a5dc-253">AC3</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-254">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-254">D</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-255">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-255">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-256">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-256">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0a5dc-257">EAC3/EC3</span><span class="sxs-lookup"><span data-stu-id="0a5dc-257">EAC3 / EC3</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-258">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-258">D</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-259">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-259">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-260">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-260">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0a5dc-261">ALAC</span><span class="sxs-lookup"><span data-stu-id="0a5dc-261">ALAC</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-262">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-262">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="0a5dc-263">AMR-NB</span><span class="sxs-lookup"><span data-stu-id="0a5dc-263">AMR-NB</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-264">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-264">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-265">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-265">D/E</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-266">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-266">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0a5dc-267">FLAC</span><span class="sxs-lookup"><span data-stu-id="0a5dc-267">FLAC</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-268">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-268">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0a5dc-269">G.711 (A-Law、µ-law)</span><span class="sxs-lookup"><span data-stu-id="0a5dc-269">G.711 (A-Law, µ-law)</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-270">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-270">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0a5dc-271">GSM 6.10</span><span class="sxs-lookup"><span data-stu-id="0a5dc-271">GSM 6.10</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-272">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-272">D</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0a5dc-273">IMA ADPCM</span><span class="sxs-lookup"><span data-stu-id="0a5dc-273">IMA ADPCM</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-274">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-274">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0a5dc-275">LPCM</span><span class="sxs-lookup"><span data-stu-id="0a5dc-275">LPCM</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-276">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-276">D/E</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0a5dc-277">MP3</span><span class="sxs-lookup"><span data-stu-id="0a5dc-277">MP3</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-278">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-278">D</span></span></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="0a5dc-279">MPEG-1/2</span><span class="sxs-lookup"><span data-stu-id="0a5dc-279">MPEG-1/2</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-280">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-280">D</span></span></td>
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
<td align="left"><span data-ttu-id="0a5dc-281">MS ADPCM</span><span class="sxs-lookup"><span data-stu-id="0a5dc-281">MS ADPCM</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-282">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-282">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0a5dc-283">WMA 1/2/3</span><span class="sxs-lookup"><span data-stu-id="0a5dc-283">WMA 1/2/3</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-284">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-284">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0a5dc-285">WMA Pro</span><span class="sxs-lookup"><span data-stu-id="0a5dc-285">WMA Pro</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-286">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-286">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0a5dc-287">WMA Voice</span><span class="sxs-lookup"><span data-stu-id="0a5dc-287">WMA Voice</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-288">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-288">D</span></span></td>
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

 

### <a name="iot-core-arm"></a><span data-ttu-id="0a5dc-289">IoT Core (ARM)</span><span class="sxs-lookup"><span data-stu-id="0a5dc-289">IoT Core (ARM)</span></span>

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
<th align="left"><span data-ttu-id="0a5dc-290">コーデック/コンテナー</span><span class="sxs-lookup"><span data-stu-id="0a5dc-290">Codec/Container</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-291">MPEG-4</span><span class="sxs-lookup"><span data-stu-id="0a5dc-291">MPEG-4</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-292">MPEG-3</span><span class="sxs-lookup"><span data-stu-id="0a5dc-292">MPEG-3</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-293">MPEG-2</span><span class="sxs-lookup"><span data-stu-id="0a5dc-293">MPEG-2</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-294">ADTS</span><span class="sxs-lookup"><span data-stu-id="0a5dc-294">ADTS</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-295">ASF</span><span class="sxs-lookup"><span data-stu-id="0a5dc-295">ASF</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-296">RIFF</span><span class="sxs-lookup"><span data-stu-id="0a5dc-296">RIFF</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-297">AVI</span><span class="sxs-lookup"><span data-stu-id="0a5dc-297">AVI</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-298">AC-3</span><span class="sxs-lookup"><span data-stu-id="0a5dc-298">AC-3</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-299">AMR</span><span class="sxs-lookup"><span data-stu-id="0a5dc-299">AMR</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-300">3GP</span><span class="sxs-lookup"><span data-stu-id="0a5dc-300">3GP</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-301">FLAC</span><span class="sxs-lookup"><span data-stu-id="0a5dc-301">FLAC</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-302">WAV</span><span class="sxs-lookup"><span data-stu-id="0a5dc-302">WAV</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="0a5dc-303">HE-AAC v1/AAC+</span><span class="sxs-lookup"><span data-stu-id="0a5dc-303">HE-AAC v1 / AAC+</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-304">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-304">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-305">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-305">D</span></span></td>
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
<td align="left"><span data-ttu-id="0a5dc-306">HE-AAC v2/eAAC+</span><span class="sxs-lookup"><span data-stu-id="0a5dc-306">HE-AAC v2 / eAAC+</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-307">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-307">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-308">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-308">D</span></span></td>
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
<td align="left"><span data-ttu-id="0a5dc-309">AAC-LC</span><span class="sxs-lookup"><span data-stu-id="0a5dc-309">AAC-LC</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-310">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-310">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-311">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-311">D</span></span></td>
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
<td align="left"><span data-ttu-id="0a5dc-312">AC3</span><span class="sxs-lookup"><span data-stu-id="0a5dc-312">AC3</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="0a5dc-313">EAC3/EC3</span><span class="sxs-lookup"><span data-stu-id="0a5dc-313">EAC3 / EC3</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="0a5dc-314">ALAC</span><span class="sxs-lookup"><span data-stu-id="0a5dc-314">ALAC</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-315">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-315">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="0a5dc-316">AMR-NB</span><span class="sxs-lookup"><span data-stu-id="0a5dc-316">AMR-NB</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-317">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-317">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-318">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-318">D/E</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-319">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-319">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0a5dc-320">FLAC</span><span class="sxs-lookup"><span data-stu-id="0a5dc-320">FLAC</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-321">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-321">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0a5dc-322">G.711 (A-Law、µ-law)</span><span class="sxs-lookup"><span data-stu-id="0a5dc-322">G.711 (A-Law, µ-law)</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-323">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-323">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0a5dc-324">GSM 6.10</span><span class="sxs-lookup"><span data-stu-id="0a5dc-324">GSM 6.10</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-325">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-325">D</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0a5dc-326">IMA ADPCM</span><span class="sxs-lookup"><span data-stu-id="0a5dc-326">IMA ADPCM</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-327">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-327">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0a5dc-328">LPCM</span><span class="sxs-lookup"><span data-stu-id="0a5dc-328">LPCM</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-329">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-329">D/E</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0a5dc-330">MP3</span><span class="sxs-lookup"><span data-stu-id="0a5dc-330">MP3</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-331">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-331">D</span></span></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="0a5dc-332">MPEG-1/2</span><span class="sxs-lookup"><span data-stu-id="0a5dc-332">MPEG-1/2</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-333">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-333">D</span></span></td>
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
<td align="left"><span data-ttu-id="0a5dc-334">MS ADPCM</span><span class="sxs-lookup"><span data-stu-id="0a5dc-334">MS ADPCM</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-335">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-335">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0a5dc-336">WMA 1/2/3</span><span class="sxs-lookup"><span data-stu-id="0a5dc-336">WMA 1/2/3</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-337">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-337">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0a5dc-338">WMA Pro</span><span class="sxs-lookup"><span data-stu-id="0a5dc-338">WMA Pro</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-339">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-339">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0a5dc-340">WMA Voice</span><span class="sxs-lookup"><span data-stu-id="0a5dc-340">WMA Voice</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-341">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-341">D</span></span></td>
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

 

### <a name="xbox"></a><span data-ttu-id="0a5dc-342">Xbox</span><span class="sxs-lookup"><span data-stu-id="0a5dc-342">XBox</span></span>

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
<th align="left"><span data-ttu-id="0a5dc-343">コーデック/コンテナー</span><span class="sxs-lookup"><span data-stu-id="0a5dc-343">Codec/Container</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-344">MPEG-4</span><span class="sxs-lookup"><span data-stu-id="0a5dc-344">MPEG-4</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-345">MPEG-3</span><span class="sxs-lookup"><span data-stu-id="0a5dc-345">MPEG-3</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-346">MPEG-2</span><span class="sxs-lookup"><span data-stu-id="0a5dc-346">MPEG-2</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-347">ADTS</span><span class="sxs-lookup"><span data-stu-id="0a5dc-347">ADTS</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-348">ASF</span><span class="sxs-lookup"><span data-stu-id="0a5dc-348">ASF</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-349">RIFF</span><span class="sxs-lookup"><span data-stu-id="0a5dc-349">RIFF</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-350">AVI</span><span class="sxs-lookup"><span data-stu-id="0a5dc-350">AVI</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-351">AC-3</span><span class="sxs-lookup"><span data-stu-id="0a5dc-351">AC-3</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-352">AMR</span><span class="sxs-lookup"><span data-stu-id="0a5dc-352">AMR</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-353">3GP</span><span class="sxs-lookup"><span data-stu-id="0a5dc-353">3GP</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-354">FLAC</span><span class="sxs-lookup"><span data-stu-id="0a5dc-354">FLAC</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-355">WAV</span><span class="sxs-lookup"><span data-stu-id="0a5dc-355">WAV</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="0a5dc-356">HE-AAC v1/AAC+</span><span class="sxs-lookup"><span data-stu-id="0a5dc-356">HE-AAC v1 / AAC+</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-357">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-357">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-358">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-358">D</span></span></td>
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
<td align="left"><span data-ttu-id="0a5dc-359">HE-AAC v2/eAAC+</span><span class="sxs-lookup"><span data-stu-id="0a5dc-359">HE-AAC v2 / eAAC+</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-360">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-360">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-361">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-361">D</span></span></td>
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
<td align="left"><span data-ttu-id="0a5dc-362">AAC-LC</span><span class="sxs-lookup"><span data-stu-id="0a5dc-362">AAC-LC</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-363">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-363">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-364">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-364">D</span></span></td>
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
<td align="left"><span data-ttu-id="0a5dc-365">AC3</span><span class="sxs-lookup"><span data-stu-id="0a5dc-365">AC3</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-366">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-366">D</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-367">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-367">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-368">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-368">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0a5dc-369">EAC3/EC3</span><span class="sxs-lookup"><span data-stu-id="0a5dc-369">EAC3 / EC3</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-370">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-370">D</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-371">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-371">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-372">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-372">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0a5dc-373">ALAC</span><span class="sxs-lookup"><span data-stu-id="0a5dc-373">ALAC</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-374">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-374">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="0a5dc-375">AMR-NB</span><span class="sxs-lookup"><span data-stu-id="0a5dc-375">AMR-NB</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-376">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-376">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-377">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-377">D/E</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-378">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-378">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0a5dc-379">FLAC</span><span class="sxs-lookup"><span data-stu-id="0a5dc-379">FLAC</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-380">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-380">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0a5dc-381">G.711 (A-Law、µ-law)</span><span class="sxs-lookup"><span data-stu-id="0a5dc-381">G.711 (A-Law, µ-law)</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-382">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-382">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0a5dc-383">GSM 6.10</span><span class="sxs-lookup"><span data-stu-id="0a5dc-383">GSM 6.10</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-384">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-384">D</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0a5dc-385">IMA ADPCM</span><span class="sxs-lookup"><span data-stu-id="0a5dc-385">IMA ADPCM</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-386">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-386">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0a5dc-387">LPCM</span><span class="sxs-lookup"><span data-stu-id="0a5dc-387">LPCM</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-388">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-388">D/E</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0a5dc-389">MP3</span><span class="sxs-lookup"><span data-stu-id="0a5dc-389">MP3</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-390">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-390">D</span></span></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="0a5dc-391">MPEG-1/2</span><span class="sxs-lookup"><span data-stu-id="0a5dc-391">MPEG-1/2</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-392">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-392">D</span></span></td>
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
<td align="left"><span data-ttu-id="0a5dc-393">MS ADPCM</span><span class="sxs-lookup"><span data-stu-id="0a5dc-393">MS ADPCM</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-394">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-394">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0a5dc-395">WMA 1/2/3</span><span class="sxs-lookup"><span data-stu-id="0a5dc-395">WMA 1/2/3</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-396">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-396">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0a5dc-397">WMA Pro</span><span class="sxs-lookup"><span data-stu-id="0a5dc-397">WMA Pro</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-398">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-398">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0a5dc-399">WMA Voice</span><span class="sxs-lookup"><span data-stu-id="0a5dc-399">WMA Voice</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-400">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-400">D</span></span></td>
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

 

## <a name="video-codec--format-support"></a><span data-ttu-id="0a5dc-401">ビデオのコーデックおよび形式のサポート</span><span class="sxs-lookup"><span data-stu-id="0a5dc-401">Video codec & format support</span></span>

<span data-ttu-id="0a5dc-402">次の表は、各デバイス ファミリのビデオのコーデックと形式のサポートを示しています。</span><span class="sxs-lookup"><span data-stu-id="0a5dc-402">The following tables show the video codec and format support for each device family.</span></span>

> [!NOTE] 
> <span data-ttu-id="0a5dc-403">H.265 のサポートが示されている場合、必ずしもデバイス ファミリ内のすべてのデバイスでサポートされるわけではありません。</span><span class="sxs-lookup"><span data-stu-id="0a5dc-403">Where H.265 support is indicated, it is not necessarily supported by all devices within the device family.</span></span>
> <span data-ttu-id="0a5dc-404">MPEG-2/MPEG-1 のサポートが示されている場合、オプションの Microsoft DVD ユニバーサル Windows アプリのインストールでのみサポートされます。</span><span class="sxs-lookup"><span data-stu-id="0a5dc-404">Where MPEG-2/MPEG-1 support is indicated, it is only supported with the installation of the optional Microsoft DVD Universal Windows app.</span></span>

 

### <a name="desktop"></a><span data-ttu-id="0a5dc-405">デスクトップ</span><span class="sxs-lookup"><span data-stu-id="0a5dc-405">Desktop</span></span>

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
<th align="left"><span data-ttu-id="0a5dc-406">コーデック/コンテナー</span><span class="sxs-lookup"><span data-stu-id="0a5dc-406">Codec/Container</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-407">FOURCC</span><span class="sxs-lookup"><span data-stu-id="0a5dc-407">FOURCC</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-408">fMP4</span><span class="sxs-lookup"><span data-stu-id="0a5dc-408">fMP4</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-409">MPEG-4</span><span class="sxs-lookup"><span data-stu-id="0a5dc-409">MPEG-4</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-410">MPEG-2 PS</span><span class="sxs-lookup"><span data-stu-id="0a5dc-410">MPEG-2 PS</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-411">MPEG-2 TS</span><span class="sxs-lookup"><span data-stu-id="0a5dc-411">MPEG-2 TS</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-412">MPEG-1</span><span class="sxs-lookup"><span data-stu-id="0a5dc-412">MPEG-1</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-413">3GPP</span><span class="sxs-lookup"><span data-stu-id="0a5dc-413">3GPP</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-414">3GPP2</span><span class="sxs-lookup"><span data-stu-id="0a5dc-414">3GPP2</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-415">AVCHD</span><span class="sxs-lookup"><span data-stu-id="0a5dc-415">AVCHD</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-416">ASF</span><span class="sxs-lookup"><span data-stu-id="0a5dc-416">ASF</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-417">AVI</span><span class="sxs-lookup"><span data-stu-id="0a5dc-417">AVI</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-418">MKV</span><span class="sxs-lookup"><span data-stu-id="0a5dc-418">MKV</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-419">DV</span><span class="sxs-lookup"><span data-stu-id="0a5dc-419">DV</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="0a5dc-420">MPEG-1</span><span class="sxs-lookup"><span data-stu-id="0a5dc-420">MPEG-1</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-421">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-421">D/E</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-422">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-422">D/E</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-423">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-423">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-424">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-424">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-425">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-425">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0a5dc-426">MPEG-2</span><span class="sxs-lookup"><span data-stu-id="0a5dc-426">MPEG-2</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-427">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-427">D/E</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-428">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-428">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-429">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-429">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-430">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-430">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0a5dc-431">MPEG-4 (Part 2)</span><span class="sxs-lookup"><span data-stu-id="0a5dc-431">MPEG-4 (Part 2)</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-432">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-432">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-433">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-433">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-434">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-434">D</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-435">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-435">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0a5dc-436">H.265</span><span class="sxs-lookup"><span data-stu-id="0a5dc-436">H.265</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-437">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-437">D</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-438">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-438">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-439">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-439">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0a5dc-440">H.264</span><span class="sxs-lookup"><span data-stu-id="0a5dc-440">H.264</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-441">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-441">D/E</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-442">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-442">D/E</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-443">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-443">D/E</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-444">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-444">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-445">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-445">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-446">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-446">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-447">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-447">D</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-448">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-448">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0a5dc-449">H.263</span><span class="sxs-lookup"><span data-stu-id="0a5dc-449">H.263</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-450">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-450">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-451">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-451">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-452">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-452">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0a5dc-453">VC-1</span><span class="sxs-lookup"><span data-stu-id="0a5dc-453">VC-1</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-454">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-454">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-455">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-455">D</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-456">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-456">D</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-457">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-457">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0a5dc-458">WMV7/8/9</span><span class="sxs-lookup"><span data-stu-id="0a5dc-458">WMV7/8/9</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-459">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-459">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-460">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-460">D/E</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-461">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-461">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0a5dc-462">WMV9 Screen</span><span class="sxs-lookup"><span data-stu-id="0a5dc-462">WMV9 Screen</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-463">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-463">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-464">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-464">D</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-465">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-465">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0a5dc-466">DV</span><span class="sxs-lookup"><span data-stu-id="0a5dc-466">DV</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-467">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-467">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-468">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-468">D</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-469">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-469">D</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0a5dc-470">モーション JPEG</span><span class="sxs-lookup"><span data-stu-id="0a5dc-470">Motion JPEG</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-471">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-471">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-472">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-472">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
</tbody>
</table>

 

### <a name="mobile"></a><span data-ttu-id="0a5dc-473">モバイル</span><span class="sxs-lookup"><span data-stu-id="0a5dc-473">Mobile</span></span>

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
<th align="left"><span data-ttu-id="0a5dc-474">コーデック/コンテナー</span><span class="sxs-lookup"><span data-stu-id="0a5dc-474">Codec/Container</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-475">FOURCC</span><span class="sxs-lookup"><span data-stu-id="0a5dc-475">FOURCC</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-476">fMP4</span><span class="sxs-lookup"><span data-stu-id="0a5dc-476">fMP4</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-477">MPEG-4</span><span class="sxs-lookup"><span data-stu-id="0a5dc-477">MPEG-4</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-478">MPEG-2 PS</span><span class="sxs-lookup"><span data-stu-id="0a5dc-478">MPEG-2 PS</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-479">MPEG-2 TS</span><span class="sxs-lookup"><span data-stu-id="0a5dc-479">MPEG-2 TS</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-480">MPEG-1</span><span class="sxs-lookup"><span data-stu-id="0a5dc-480">MPEG-1</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-481">3GPP</span><span class="sxs-lookup"><span data-stu-id="0a5dc-481">3GPP</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-482">3GPP2</span><span class="sxs-lookup"><span data-stu-id="0a5dc-482">3GPP2</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-483">AVCHD</span><span class="sxs-lookup"><span data-stu-id="0a5dc-483">AVCHD</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-484">ASF</span><span class="sxs-lookup"><span data-stu-id="0a5dc-484">ASF</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-485">AVI</span><span class="sxs-lookup"><span data-stu-id="0a5dc-485">AVI</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-486">MKV</span><span class="sxs-lookup"><span data-stu-id="0a5dc-486">MKV</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-487">DV</span><span class="sxs-lookup"><span data-stu-id="0a5dc-487">DV</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="0a5dc-488">MPEG-1</span><span class="sxs-lookup"><span data-stu-id="0a5dc-488">MPEG-1</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="0a5dc-489">MPEG-2</span><span class="sxs-lookup"><span data-stu-id="0a5dc-489">MPEG-2</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="0a5dc-490">MPEG-4 (Part 2)</span><span class="sxs-lookup"><span data-stu-id="0a5dc-490">MPEG-4 (Part 2)</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-491">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-491">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-492">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-492">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-493">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-493">D</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-494">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-494">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0a5dc-495">H.265</span><span class="sxs-lookup"><span data-stu-id="0a5dc-495">H.265</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-496">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-496">D</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-497">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-497">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-498">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-498">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0a5dc-499">H.264</span><span class="sxs-lookup"><span data-stu-id="0a5dc-499">H.264</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-500">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-500">D/E</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-501">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-501">D/E</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-502">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-502">D/E</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-503">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-503">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-504">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-504">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-505">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-505">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-506">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-506">D</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-507">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-507">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0a5dc-508">H.263</span><span class="sxs-lookup"><span data-stu-id="0a5dc-508">H.263</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-509">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-509">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-510">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-510">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-511">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-511">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0a5dc-512">VC-1</span><span class="sxs-lookup"><span data-stu-id="0a5dc-512">VC-1</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-513">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-513">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-514">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-514">D</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-515">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-515">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0a5dc-516">WMV7/8/9</span><span class="sxs-lookup"><span data-stu-id="0a5dc-516">WMV7/8/9</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="0a5dc-517">WMV9 Screen</span><span class="sxs-lookup"><span data-stu-id="0a5dc-517">WMV9 Screen</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="0a5dc-518">DV</span><span class="sxs-lookup"><span data-stu-id="0a5dc-518">DV</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="0a5dc-519">モーション JPEG</span><span class="sxs-lookup"><span data-stu-id="0a5dc-519">Motion JPEG</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-520">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-520">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-521">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-521">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
</tbody>
</table>

 

### <a name="iot-core-x86"></a><span data-ttu-id="0a5dc-522">IoT Core (x86)</span><span class="sxs-lookup"><span data-stu-id="0a5dc-522">IoT Core (x86)</span></span>

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
<th align="left"><span data-ttu-id="0a5dc-523">コーデック/コンテナー</span><span class="sxs-lookup"><span data-stu-id="0a5dc-523">Codec/Container</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-524">FOURCC</span><span class="sxs-lookup"><span data-stu-id="0a5dc-524">FOURCC</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-525">fMP4</span><span class="sxs-lookup"><span data-stu-id="0a5dc-525">fMP4</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-526">MPEG-4</span><span class="sxs-lookup"><span data-stu-id="0a5dc-526">MPEG-4</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-527">MPEG-2 PS</span><span class="sxs-lookup"><span data-stu-id="0a5dc-527">MPEG-2 PS</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-528">MPEG-2 TS</span><span class="sxs-lookup"><span data-stu-id="0a5dc-528">MPEG-2 TS</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-529">MPEG-1</span><span class="sxs-lookup"><span data-stu-id="0a5dc-529">MPEG-1</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-530">3GPP</span><span class="sxs-lookup"><span data-stu-id="0a5dc-530">3GPP</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-531">3GPP2</span><span class="sxs-lookup"><span data-stu-id="0a5dc-531">3GPP2</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-532">AVCHD</span><span class="sxs-lookup"><span data-stu-id="0a5dc-532">AVCHD</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-533">ASF</span><span class="sxs-lookup"><span data-stu-id="0a5dc-533">ASF</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-534">AVI</span><span class="sxs-lookup"><span data-stu-id="0a5dc-534">AVI</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-535">MKV</span><span class="sxs-lookup"><span data-stu-id="0a5dc-535">MKV</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-536">DV</span><span class="sxs-lookup"><span data-stu-id="0a5dc-536">DV</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="0a5dc-537">MPEG-1</span><span class="sxs-lookup"><span data-stu-id="0a5dc-537">MPEG-1</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="0a5dc-538">MPEG-2</span><span class="sxs-lookup"><span data-stu-id="0a5dc-538">MPEG-2</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="0a5dc-539">MPEG-4 (Part 2)</span><span class="sxs-lookup"><span data-stu-id="0a5dc-539">MPEG-4 (Part 2)</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-540">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-540">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-541">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-541">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-542">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-542">D</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-543">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-543">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0a5dc-544">H.265</span><span class="sxs-lookup"><span data-stu-id="0a5dc-544">H.265</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-545">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-545">D</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-546">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-546">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-547">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-547">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0a5dc-548">H.264</span><span class="sxs-lookup"><span data-stu-id="0a5dc-548">H.264</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-549">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-549">D/E</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-550">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-550">D/E</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-551">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-551">D/E</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-552">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-552">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-553">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-553">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-554">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-554">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-555">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-555">D</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-556">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-556">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0a5dc-557">H.263</span><span class="sxs-lookup"><span data-stu-id="0a5dc-557">H.263</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-558">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-558">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-559">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-559">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-560">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-560">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0a5dc-561">VC-1</span><span class="sxs-lookup"><span data-stu-id="0a5dc-561">VC-1</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-562">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-562">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-563">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-563">D</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-564">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-564">D</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-565">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-565">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0a5dc-566">WMV7/8/9</span><span class="sxs-lookup"><span data-stu-id="0a5dc-566">WMV7/8/9</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-567">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-567">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-568">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-568">D</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-569">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-569">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0a5dc-570">WMV9 Screen</span><span class="sxs-lookup"><span data-stu-id="0a5dc-570">WMV9 Screen</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-571">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-571">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-572">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-572">D</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-573">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-573">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0a5dc-574">DV</span><span class="sxs-lookup"><span data-stu-id="0a5dc-574">DV</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="0a5dc-575">モーション JPEG</span><span class="sxs-lookup"><span data-stu-id="0a5dc-575">Motion JPEG</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-576">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-576">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-577">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-577">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
</tbody>
</table>

 

### <a name="iot-arm"></a><span data-ttu-id="0a5dc-578">IoT (ARM)</span><span class="sxs-lookup"><span data-stu-id="0a5dc-578">IoT (ARM)</span></span>

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
<th align="left"><span data-ttu-id="0a5dc-579">コーデック/コンテナー</span><span class="sxs-lookup"><span data-stu-id="0a5dc-579">Codec/Container</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-580">FOURCC</span><span class="sxs-lookup"><span data-stu-id="0a5dc-580">FOURCC</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-581">fMP4</span><span class="sxs-lookup"><span data-stu-id="0a5dc-581">fMP4</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-582">MPEG-4</span><span class="sxs-lookup"><span data-stu-id="0a5dc-582">MPEG-4</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-583">MPEG-2 PS</span><span class="sxs-lookup"><span data-stu-id="0a5dc-583">MPEG-2 PS</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-584">MPEG-2 TS</span><span class="sxs-lookup"><span data-stu-id="0a5dc-584">MPEG-2 TS</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-585">MPEG-1</span><span class="sxs-lookup"><span data-stu-id="0a5dc-585">MPEG-1</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-586">3GPP</span><span class="sxs-lookup"><span data-stu-id="0a5dc-586">3GPP</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-587">3GPP2</span><span class="sxs-lookup"><span data-stu-id="0a5dc-587">3GPP2</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-588">AVCHD</span><span class="sxs-lookup"><span data-stu-id="0a5dc-588">AVCHD</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-589">ASF</span><span class="sxs-lookup"><span data-stu-id="0a5dc-589">ASF</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-590">AVI</span><span class="sxs-lookup"><span data-stu-id="0a5dc-590">AVI</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-591">MKV</span><span class="sxs-lookup"><span data-stu-id="0a5dc-591">MKV</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-592">DV</span><span class="sxs-lookup"><span data-stu-id="0a5dc-592">DV</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="0a5dc-593">MPEG-1</span><span class="sxs-lookup"><span data-stu-id="0a5dc-593">MPEG-1</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="0a5dc-594">MPEG-2</span><span class="sxs-lookup"><span data-stu-id="0a5dc-594">MPEG-2</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="0a5dc-595">MPEG-4 (Part 2)</span><span class="sxs-lookup"><span data-stu-id="0a5dc-595">MPEG-4 (Part 2)</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="0a5dc-596">H.265</span><span class="sxs-lookup"><span data-stu-id="0a5dc-596">H.265</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-597">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-597">D</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-598">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-598">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-599">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-599">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0a5dc-600">H.264</span><span class="sxs-lookup"><span data-stu-id="0a5dc-600">H.264</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-601">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-601">D/E</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-602">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-602">D/E</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-603">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-603">D/E</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-604">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-604">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-605">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-605">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-606">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-606">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-607">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-607">D</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-608">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-608">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0a5dc-609">H.263</span><span class="sxs-lookup"><span data-stu-id="0a5dc-609">H.263</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="0a5dc-610">VC-1</span><span class="sxs-lookup"><span data-stu-id="0a5dc-610">VC-1</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-611">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-611">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-612">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-612">D</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-613">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-613">D</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-614">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-614">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0a5dc-615">WMV7/8/9</span><span class="sxs-lookup"><span data-stu-id="0a5dc-615">WMV7/8/9</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-616">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-616">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-617">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-617">D</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-618">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-618">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0a5dc-619">WMV9 Screen</span><span class="sxs-lookup"><span data-stu-id="0a5dc-619">WMV9 Screen</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="0a5dc-620">DV</span><span class="sxs-lookup"><span data-stu-id="0a5dc-620">DV</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="0a5dc-621">モーション JPEG</span><span class="sxs-lookup"><span data-stu-id="0a5dc-621">Motion JPEG</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-622">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-622">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-623">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-623">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
</tbody>
</table>

 

### <a name="xbox"></a><span data-ttu-id="0a5dc-624">Xbox</span><span class="sxs-lookup"><span data-stu-id="0a5dc-624">XBox</span></span>

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
<th align="left"><span data-ttu-id="0a5dc-625">コーデック/コンテナー</span><span class="sxs-lookup"><span data-stu-id="0a5dc-625">Codec/Container</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-626">FOURCC</span><span class="sxs-lookup"><span data-stu-id="0a5dc-626">FOURCC</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-627">fMP4</span><span class="sxs-lookup"><span data-stu-id="0a5dc-627">fMP4</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-628">MPEG-4</span><span class="sxs-lookup"><span data-stu-id="0a5dc-628">MPEG-4</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-629">MPEG-2 PS</span><span class="sxs-lookup"><span data-stu-id="0a5dc-629">MPEG-2 PS</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-630">MPEG-2 TS</span><span class="sxs-lookup"><span data-stu-id="0a5dc-630">MPEG-2 TS</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-631">MPEG-1</span><span class="sxs-lookup"><span data-stu-id="0a5dc-631">MPEG-1</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-632">3GPP</span><span class="sxs-lookup"><span data-stu-id="0a5dc-632">3GPP</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-633">3GPP2</span><span class="sxs-lookup"><span data-stu-id="0a5dc-633">3GPP2</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-634">AVCHD</span><span class="sxs-lookup"><span data-stu-id="0a5dc-634">AVCHD</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-635">ASF</span><span class="sxs-lookup"><span data-stu-id="0a5dc-635">ASF</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-636">AVI</span><span class="sxs-lookup"><span data-stu-id="0a5dc-636">AVI</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-637">MKV</span><span class="sxs-lookup"><span data-stu-id="0a5dc-637">MKV</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-638">DV</span><span class="sxs-lookup"><span data-stu-id="0a5dc-638">DV</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="0a5dc-639">MPEG-1</span><span class="sxs-lookup"><span data-stu-id="0a5dc-639">MPEG-1</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-640">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-640">D/E</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-641">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-641">D/E</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-642">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-642">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-643">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-643">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-644">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-644">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0a5dc-645">MPEG-2</span><span class="sxs-lookup"><span data-stu-id="0a5dc-645">MPEG-2</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-646">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-646">D/E</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-647">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-647">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-648">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-648">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-649">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-649">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0a5dc-650">MPEG-4 (Part 2)</span><span class="sxs-lookup"><span data-stu-id="0a5dc-650">MPEG-4 (Part 2)</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-651">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-651">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-652">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-652">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-653">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-653">D</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-654">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-654">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0a5dc-655">H.265</span><span class="sxs-lookup"><span data-stu-id="0a5dc-655">H.265</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-656">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-656">D</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-657">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-657">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-658">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-658">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0a5dc-659">H.264</span><span class="sxs-lookup"><span data-stu-id="0a5dc-659">H.264</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-660">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-660">D/E</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-661">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-661">D/E</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-662">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-662">D/E</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-663">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-663">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-664">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-664">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-665">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-665">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-666">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-666">D</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-667">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-667">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0a5dc-668">H.263</span><span class="sxs-lookup"><span data-stu-id="0a5dc-668">H.263</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-669">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-669">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-670">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-670">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-671">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-671">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0a5dc-672">VC-1</span><span class="sxs-lookup"><span data-stu-id="0a5dc-672">VC-1</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-673">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-673">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-674">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-674">D</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-675">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-675">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0a5dc-676">WMV7/8/9</span><span class="sxs-lookup"><span data-stu-id="0a5dc-676">WMV7/8/9</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="0a5dc-677">WMV9 Screen</span><span class="sxs-lookup"><span data-stu-id="0a5dc-677">WMV9 Screen</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="0a5dc-678">DV</span><span class="sxs-lookup"><span data-stu-id="0a5dc-678">DV</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="0a5dc-679">モーション JPEG</span><span class="sxs-lookup"><span data-stu-id="0a5dc-679">Motion JPEG</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-680">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-680">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0a5dc-681">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-681">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
</tbody>
</table>

## <a name="image-codec--format-support"></a><span data-ttu-id="0a5dc-682">イメージのコーデックおよび形式のサポート</span><span class="sxs-lookup"><span data-stu-id="0a5dc-682">Image codec & format support</span></span> 

<table>
<colgroup>
<col width="7%" />
<col width="7%" />
<col width="7%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="0a5dc-683">コーデック</span><span class="sxs-lookup"><span data-stu-id="0a5dc-683">Codec</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-684">デスクトップ</span><span class="sxs-lookup"><span data-stu-id="0a5dc-684">Desktop</span></span></th>
<th align="left"><span data-ttu-id="0a5dc-685">他のデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="0a5dc-685">Other device families</span></span></th>
</tr>
</thead>
<tr class="odd">
<td align="left"><span data-ttu-id="0a5dc-686">BMP</span><span class="sxs-lookup"><span data-stu-id="0a5dc-686">BMP</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-687">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-687">D/E</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-688">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-688">D/E</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0a5dc-689">DDS</span><span class="sxs-lookup"><span data-stu-id="0a5dc-689">DDS</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-690">D/E<sup>1</sup></span><span class="sxs-lookup"><span data-stu-id="0a5dc-690">D/E<sup>1</sup></span></span></td>
<td align="left"><span data-ttu-id="0a5dc-691">D/E<sup>1</sup></span><span class="sxs-lookup"><span data-stu-id="0a5dc-691">D/E<sup>1</sup></span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0a5dc-692">DNG</span><span class="sxs-lookup"><span data-stu-id="0a5dc-692">DNG</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-693">D<sup>2</sup></span><span class="sxs-lookup"><span data-stu-id="0a5dc-693">D<sup>2</sup></span></span></td>
<td align="left"><span data-ttu-id="0a5dc-694">D<sup>2</sup></span><span class="sxs-lookup"><span data-stu-id="0a5dc-694">D<sup>2</sup></span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0a5dc-695">GIF</span><span class="sxs-lookup"><span data-stu-id="0a5dc-695">GIF</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-696">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-696">D/E</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-697">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-697">D/E</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0a5dc-698">ICO</span><span class="sxs-lookup"><span data-stu-id="0a5dc-698">ICO</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-699">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-699">D</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-700">D</span><span class="sxs-lookup"><span data-stu-id="0a5dc-700">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0a5dc-701">JPEG</span><span class="sxs-lookup"><span data-stu-id="0a5dc-701">JPEG</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-702">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-702">D/E</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-703">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-703">D/E</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0a5dc-704">JPEG-XR</span><span class="sxs-lookup"><span data-stu-id="0a5dc-704">JPEG-XR</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-705">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-705">D/E</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-706">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-706">D/E</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0a5dc-707">PNG</span><span class="sxs-lookup"><span data-stu-id="0a5dc-707">PNG</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-708">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-708">D/E</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-709">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-709">D/E</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0a5dc-710">TIFF</span><span class="sxs-lookup"><span data-stu-id="0a5dc-710">TIFF</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-711">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-711">D/E</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-712">D/E</span><span class="sxs-lookup"><span data-stu-id="0a5dc-712">D/E</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0a5dc-713">RAW 形式のカメラ</span><span class="sxs-lookup"><span data-stu-id="0a5dc-713">Camera RAW</span></span></td>
<td align="left"><span data-ttu-id="0a5dc-714">D<sup>3</sup></span><span class="sxs-lookup"><span data-stu-id="0a5dc-714">D<sup>3</sup></span></span></td>
<td align="left"><span data-ttu-id="0a5dc-715">なし</span><span class="sxs-lookup"><span data-stu-id="0a5dc-715">No</span></span></td>
</tr>
</table>

<span data-ttu-id="0a5dc-716"><sup>1</sup> BC5 圧縮による BC1 を使用した DDS イメージがサポートされています。</span><span class="sxs-lookup"><span data-stu-id="0a5dc-716"><sup>1</sup> DDS images using BC1 through BC5 compression are supported.</span></span>  
<span data-ttu-id="0a5dc-717"><sup>2</sup> 非 RAW 形式の埋め込みプレビューを含む DNG イメージがサポートされています。</span><span class="sxs-lookup"><span data-stu-id="0a5dc-717"><sup>2</sup> DNG images with a non-RAW embedded preview are supported.</span></span>  
<span data-ttu-id="0a5dc-718"><sup>3</sup> 特定のカメラの RAW 形式のみがサポートされています。</span><span class="sxs-lookup"><span data-stu-id="0a5dc-718"><sup>3</sup> Only certain camera RAW formats are supported.</span></span>  

<span data-ttu-id="0a5dc-719">イメージ コーデックの詳細については、「[ネイティブ WIC コーデック](https://msdn.microsoft.com/library/windows/desktop/gg430027.aspx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0a5dc-719">For more information on image codecs, see [Native WIC Codecs](https://msdn.microsoft.com/library/windows/desktop/gg430027.aspx).</span></span>