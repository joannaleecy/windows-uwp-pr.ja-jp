---
ms.assetid: 9347AD7C-3A90-4073-BFF4-9E8237398343
description: この記事では、UWP アプリ用のオーディオとビデオのコーデックおよび形式のサポートを示します。
title: サポートされているコーデック
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 02d8c67c92a070fbeaaab81ef6c5145dec90e411
ms.sourcegitcommit: b4c502d69a13340f6e3c887aa3c26ef2aeee9cee
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/03/2018
ms.locfileid: "8476778"
---
# <a name="supported-codecs"></a><span data-ttu-id="0f47e-104">サポートされているコーデック</span><span class="sxs-lookup"><span data-stu-id="0f47e-104">Supported codecs</span></span>

<span data-ttu-id="0f47e-105">この記事では、各デバイス ファミリの既定で、UWP アプリで利用可能なオーディオ、ビデオ、イメージのコーデックと形式を示します。</span><span class="sxs-lookup"><span data-stu-id="0f47e-105">This article lists the audio, video, and image codec and format availability for UWP apps by default for each device family.</span></span> <span data-ttu-id="0f47e-106">これらの表では、指定のデバイス ファミリの Windows 10 のインストールに含まれているコーデックを示していることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="0f47e-106">Note that these tables list the codecs that are included with the Windows 10 installation for the specified device family.</span></span> <span data-ttu-id="0f47e-107">ユーザーやアプリが、利用可能な追加のコーデックをインストールする場合があります。</span><span class="sxs-lookup"><span data-stu-id="0f47e-107">Users and apps can install additional codecs that may be available to use.</span></span> <span data-ttu-id="0f47e-108">実行時に、特定のデバイスで現在利用可能なコーデックのセットを照会できます。</span><span class="sxs-lookup"><span data-stu-id="0f47e-108">You can query at runtime for the set of codecs that are currently available for a specific device.</span></span> <span data-ttu-id="0f47e-109">詳しくは、「[デバイスにインストールされているコーデックの照会](codec-query.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0f47e-109">For more information, see [Query for codecs installed on a device](codec-query.md).</span></span>

<span data-ttu-id="0f47e-110">以下の表では、"D" はデコーダーのサポートを示し、"E" はエンコーダーのサポートを示します。</span><span class="sxs-lookup"><span data-stu-id="0f47e-110">In the tables below "D" indicates decoder support and "E" indicates encoder support.</span></span>

## <a name="audio-codec--format-support"></a><span data-ttu-id="0f47e-111">オーディオのコーデックおよび形式のサポート</span><span class="sxs-lookup"><span data-stu-id="0f47e-111">Audio codec & format support</span></span>

<span data-ttu-id="0f47e-112">次の表は、各デバイス ファミリのオーディオのコーデックと形式のサポートを示しています。</span><span class="sxs-lookup"><span data-stu-id="0f47e-112">The following tables show the audio codec and format support for each device family.</span></span>

> [!NOTE] 
> <span data-ttu-id="0f47e-113">AMR-NB のサポートが示されている場合、Server SKU ではこのコーデックがサポートされません。</span><span class="sxs-lookup"><span data-stu-id="0f47e-113">Where AMR-NB support is indicated, this codec is not supported on Server SKUs.</span></span>

 

### <a name="desktop"></a><span data-ttu-id="0f47e-114">デスクトップ</span><span class="sxs-lookup"><span data-stu-id="0f47e-114">Desktop</span></span>

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
<th align="left"><span data-ttu-id="0f47e-115">コーデック/コンテナー</span><span class="sxs-lookup"><span data-stu-id="0f47e-115">Codec/Container</span></span></th>
<th align="left"><span data-ttu-id="0f47e-116">MPEG-4</span><span class="sxs-lookup"><span data-stu-id="0f47e-116">MPEG-4</span></span></th>
<th align="left"><span data-ttu-id="0f47e-117">MPEG-3</span><span class="sxs-lookup"><span data-stu-id="0f47e-117">MPEG-3</span></span></th>
<th align="left"><span data-ttu-id="0f47e-118">MPEG-2</span><span class="sxs-lookup"><span data-stu-id="0f47e-118">MPEG-2</span></span></th>
<th align="left"><span data-ttu-id="0f47e-119">ADTS</span><span class="sxs-lookup"><span data-stu-id="0f47e-119">ADTS</span></span></th>
<th align="left"><span data-ttu-id="0f47e-120">ASF</span><span class="sxs-lookup"><span data-stu-id="0f47e-120">ASF</span></span></th>
<th align="left"><span data-ttu-id="0f47e-121">RIFF</span><span class="sxs-lookup"><span data-stu-id="0f47e-121">RIFF</span></span></th>
<th align="left"><span data-ttu-id="0f47e-122">AVI</span><span class="sxs-lookup"><span data-stu-id="0f47e-122">AVI</span></span></th>
<th align="left"><span data-ttu-id="0f47e-123">AC-3</span><span class="sxs-lookup"><span data-stu-id="0f47e-123">AC-3</span></span></th>
<th align="left"><span data-ttu-id="0f47e-124">AMR</span><span class="sxs-lookup"><span data-stu-id="0f47e-124">AMR</span></span></th>
<th align="left"><span data-ttu-id="0f47e-125">3GP</span><span class="sxs-lookup"><span data-stu-id="0f47e-125">3GP</span></span></th>
<th align="left"><span data-ttu-id="0f47e-126">FLAC</span><span class="sxs-lookup"><span data-stu-id="0f47e-126">FLAC</span></span></th>
<th align="left"><span data-ttu-id="0f47e-127">WAV</span><span class="sxs-lookup"><span data-stu-id="0f47e-127">WAV</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="0f47e-128">HE-AAC v1/AAC+</span><span class="sxs-lookup"><span data-stu-id="0f47e-128">HE-AAC v1 / AAC+</span></span></td>
<td align="left"><span data-ttu-id="0f47e-129">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-129">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-130">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-130">D</span></span></td>
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
<td align="left"><span data-ttu-id="0f47e-131">HE-AAC v2/eAAC+</span><span class="sxs-lookup"><span data-stu-id="0f47e-131">HE-AAC v2 / eAAC+</span></span></td>
<td align="left"><span data-ttu-id="0f47e-132">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-132">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-133">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-133">D</span></span></td>
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
<td align="left"><span data-ttu-id="0f47e-134">AAC-LC</span><span class="sxs-lookup"><span data-stu-id="0f47e-134">AAC-LC</span></span></td>
<td align="left"><span data-ttu-id="0f47e-135">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-135">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-136">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-136">D</span></span></td>
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
<td align="left"><span data-ttu-id="0f47e-137">AC3</span><span class="sxs-lookup"><span data-stu-id="0f47e-137">AC3</span></span></td>
<td align="left"><span data-ttu-id="0f47e-138">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-138">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-139">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-139">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-140">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-140">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0f47e-141">EAC3/EC3</span><span class="sxs-lookup"><span data-stu-id="0f47e-141">EAC3 / EC3</span></span></td>
<td align="left"><span data-ttu-id="0f47e-142">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-142">D</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-143">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-143">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-144">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-144">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0f47e-145">ALAC</span><span class="sxs-lookup"><span data-stu-id="0f47e-145">ALAC</span></span></td>
<td align="left"><span data-ttu-id="0f47e-146">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-146">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="0f47e-147">AMR-NB</span><span class="sxs-lookup"><span data-stu-id="0f47e-147">AMR-NB</span></span></td>
<td align="left"><span data-ttu-id="0f47e-148">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-148">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-149">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-149">D/E</span></span></td>
<td align="left"><span data-ttu-id="0f47e-150">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-150">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0f47e-151">FLAC</span><span class="sxs-lookup"><span data-stu-id="0f47e-151">FLAC</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-152">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-152">D/E</span></span></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0f47e-153">G.711 (A-Law、µ-law)</span><span class="sxs-lookup"><span data-stu-id="0f47e-153">G.711 (A-Law, µ-law)</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-154">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-154">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0f47e-155">GSM 6.10</span><span class="sxs-lookup"><span data-stu-id="0f47e-155">GSM 6.10</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-156">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-156">D</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0f47e-157">IMA ADPCM</span><span class="sxs-lookup"><span data-stu-id="0f47e-157">IMA ADPCM</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-158">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-158">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0f47e-159">LPCM</span><span class="sxs-lookup"><span data-stu-id="0f47e-159">LPCM</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-160">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-160">D/E</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0f47e-161">MP3</span><span class="sxs-lookup"><span data-stu-id="0f47e-161">MP3</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-162">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-162">D/E</span></span></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="0f47e-163">MPEG-1/2</span><span class="sxs-lookup"><span data-stu-id="0f47e-163">MPEG-1/2</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-164">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-164">D</span></span></td>
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
<td align="left"><span data-ttu-id="0f47e-165">MS ADPCM</span><span class="sxs-lookup"><span data-stu-id="0f47e-165">MS ADPCM</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-166">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-166">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0f47e-167">WMA 1/2/3</span><span class="sxs-lookup"><span data-stu-id="0f47e-167">WMA 1/2/3</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-168">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-168">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0f47e-169">WMA Pro</span><span class="sxs-lookup"><span data-stu-id="0f47e-169">WMA Pro</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-170">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-170">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0f47e-171">WMA Voice</span><span class="sxs-lookup"><span data-stu-id="0f47e-171">WMA Voice</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-172">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-172">D/E</span></span></td>
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

 

### <a name="mobile"></a><span data-ttu-id="0f47e-173">モバイル</span><span class="sxs-lookup"><span data-stu-id="0f47e-173">Mobile</span></span>

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
<th align="left"><span data-ttu-id="0f47e-174">コーデック/コンテナー</span><span class="sxs-lookup"><span data-stu-id="0f47e-174">Codec/Container</span></span></th>
<th align="left"><span data-ttu-id="0f47e-175">MPEG-4</span><span class="sxs-lookup"><span data-stu-id="0f47e-175">MPEG-4</span></span></th>
<th align="left"><span data-ttu-id="0f47e-176">MPEG-3</span><span class="sxs-lookup"><span data-stu-id="0f47e-176">MPEG-3</span></span></th>
<th align="left"><span data-ttu-id="0f47e-177">MPEG-2</span><span class="sxs-lookup"><span data-stu-id="0f47e-177">MPEG-2</span></span></th>
<th align="left"><span data-ttu-id="0f47e-178">ADTS</span><span class="sxs-lookup"><span data-stu-id="0f47e-178">ADTS</span></span></th>
<th align="left"><span data-ttu-id="0f47e-179">ASF</span><span class="sxs-lookup"><span data-stu-id="0f47e-179">ASF</span></span></th>
<th align="left"><span data-ttu-id="0f47e-180">RIFF</span><span class="sxs-lookup"><span data-stu-id="0f47e-180">RIFF</span></span></th>
<th align="left"><span data-ttu-id="0f47e-181">AVI</span><span class="sxs-lookup"><span data-stu-id="0f47e-181">AVI</span></span></th>
<th align="left"><span data-ttu-id="0f47e-182">AC-3</span><span class="sxs-lookup"><span data-stu-id="0f47e-182">AC-3</span></span></th>
<th align="left"><span data-ttu-id="0f47e-183">AMR</span><span class="sxs-lookup"><span data-stu-id="0f47e-183">AMR</span></span></th>
<th align="left"><span data-ttu-id="0f47e-184">3GP</span><span class="sxs-lookup"><span data-stu-id="0f47e-184">3GP</span></span></th>
<th align="left"><span data-ttu-id="0f47e-185">FLAC</span><span class="sxs-lookup"><span data-stu-id="0f47e-185">FLAC</span></span></th>
<th align="left"><span data-ttu-id="0f47e-186">WAV</span><span class="sxs-lookup"><span data-stu-id="0f47e-186">WAV</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="0f47e-187">HE-AAC v1/AAC+</span><span class="sxs-lookup"><span data-stu-id="0f47e-187">HE-AAC v1 / AAC+</span></span></td>
<td align="left"><span data-ttu-id="0f47e-188">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-188">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-189">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-189">D</span></span></td>
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
<td align="left"><span data-ttu-id="0f47e-190">HE-AAC v2/eAAC+</span><span class="sxs-lookup"><span data-stu-id="0f47e-190">HE-AAC v2 / eAAC+</span></span></td>
<td align="left"><span data-ttu-id="0f47e-191">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-191">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-192">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-192">D</span></span></td>
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
<td align="left"><span data-ttu-id="0f47e-193">AAC-LC</span><span class="sxs-lookup"><span data-stu-id="0f47e-193">AAC-LC</span></span></td>
<td align="left"><span data-ttu-id="0f47e-194">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-194">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-195">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-195">D</span></span></td>
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
<td align="left"><span data-ttu-id="0f47e-196">AC3</span><span class="sxs-lookup"><span data-stu-id="0f47e-196">AC3</span></span></td>
<td align="left"><span data-ttu-id="0f47e-197">D (Lumia Icon、830、930、1520 のみ)</span><span class="sxs-lookup"><span data-stu-id="0f47e-197">D, Only on Lumia Icon, 830, 930, 1520</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-198">D (Lumia Icon、830、930、1520 のみ)</span><span class="sxs-lookup"><span data-stu-id="0f47e-198">D, Only on Lumia Icon, 830, 930, 1520</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-199">D (Lumia Icon、830、930、1520 のみ)</span><span class="sxs-lookup"><span data-stu-id="0f47e-199">D, Only on Lumia Icon, 830, 930, 1520</span></span></td>
<td align="left"><span data-ttu-id="0f47e-200">D (Lumia Icon、830、930、1520 のみ)</span><span class="sxs-lookup"><span data-stu-id="0f47e-200">D, Only on Lumia Icon, 830, 930, 1520</span></span></td>
<td align="left"><span data-ttu-id="0f47e-201">D (Lumia Icon、830、930、1520 のみ)</span><span class="sxs-lookup"><span data-stu-id="0f47e-201">D, Only on Lumia Icon, 830, 930, 1520</span></span></td>
<td align="left"><span data-ttu-id="0f47e-202">D (Lumia Icon、830、930、1520 のみ)</span><span class="sxs-lookup"><span data-stu-id="0f47e-202">D, Only on Lumia Icon, 830, 930, 1520</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0f47e-203">EAC3/EC3</span><span class="sxs-lookup"><span data-stu-id="0f47e-203">EAC3 / EC3</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="0f47e-204">ALAC</span><span class="sxs-lookup"><span data-stu-id="0f47e-204">ALAC</span></span></td>
<td align="left"><span data-ttu-id="0f47e-205">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-205">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="0f47e-206">AMR-NB</span><span class="sxs-lookup"><span data-stu-id="0f47e-206">AMR-NB</span></span></td>
<td align="left"><span data-ttu-id="0f47e-207">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-207">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-208">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-208">D/E</span></span></td>
<td align="left"><span data-ttu-id="0f47e-209">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-209">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0f47e-210">FLAC</span><span class="sxs-lookup"><span data-stu-id="0f47e-210">FLAC</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-211">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-211">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0f47e-212">G.711 (A-Law、µ-law)</span><span class="sxs-lookup"><span data-stu-id="0f47e-212">G.711 (A-Law, µ-law)</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-213">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-213">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0f47e-214">GSM 6.10</span><span class="sxs-lookup"><span data-stu-id="0f47e-214">GSM 6.10</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-215">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-215">D</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0f47e-216">IMA ADPCM</span><span class="sxs-lookup"><span data-stu-id="0f47e-216">IMA ADPCM</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-217">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-217">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0f47e-218">LPCM</span><span class="sxs-lookup"><span data-stu-id="0f47e-218">LPCM</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-219">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-219">D/E</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0f47e-220">MP3</span><span class="sxs-lookup"><span data-stu-id="0f47e-220">MP3</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-221">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-221">D</span></span></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="0f47e-222">MPEG-1/2</span><span class="sxs-lookup"><span data-stu-id="0f47e-222">MPEG-1/2</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="0f47e-223">MS ADPCM</span><span class="sxs-lookup"><span data-stu-id="0f47e-223">MS ADPCM</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-224">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-224">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0f47e-225">WMA 1/2/3</span><span class="sxs-lookup"><span data-stu-id="0f47e-225">WMA 1/2/3</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-226">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-226">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0f47e-227">WMA Pro</span><span class="sxs-lookup"><span data-stu-id="0f47e-227">WMA Pro</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-228">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-228">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0f47e-229">WMA Voice</span><span class="sxs-lookup"><span data-stu-id="0f47e-229">WMA Voice</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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

 

### <a name="iot-core-x86"></a><span data-ttu-id="0f47e-230">IoT Core (x86)</span><span class="sxs-lookup"><span data-stu-id="0f47e-230">IoT Core (x86)</span></span>

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
<th align="left"><span data-ttu-id="0f47e-231">コーデック/コンテナー</span><span class="sxs-lookup"><span data-stu-id="0f47e-231">Codec/Container</span></span></th>
<th align="left"><span data-ttu-id="0f47e-232">MPEG-4</span><span class="sxs-lookup"><span data-stu-id="0f47e-232">MPEG-4</span></span></th>
<th align="left"><span data-ttu-id="0f47e-233">MPEG-3</span><span class="sxs-lookup"><span data-stu-id="0f47e-233">MPEG-3</span></span></th>
<th align="left"><span data-ttu-id="0f47e-234">MPEG-2</span><span class="sxs-lookup"><span data-stu-id="0f47e-234">MPEG-2</span></span></th>
<th align="left"><span data-ttu-id="0f47e-235">ADTS</span><span class="sxs-lookup"><span data-stu-id="0f47e-235">ADTS</span></span></th>
<th align="left"><span data-ttu-id="0f47e-236">ASF</span><span class="sxs-lookup"><span data-stu-id="0f47e-236">ASF</span></span></th>
<th align="left"><span data-ttu-id="0f47e-237">RIFF</span><span class="sxs-lookup"><span data-stu-id="0f47e-237">RIFF</span></span></th>
<th align="left"><span data-ttu-id="0f47e-238">AVI</span><span class="sxs-lookup"><span data-stu-id="0f47e-238">AVI</span></span></th>
<th align="left"><span data-ttu-id="0f47e-239">AC-3</span><span class="sxs-lookup"><span data-stu-id="0f47e-239">AC-3</span></span></th>
<th align="left"><span data-ttu-id="0f47e-240">AMR</span><span class="sxs-lookup"><span data-stu-id="0f47e-240">AMR</span></span></th>
<th align="left"><span data-ttu-id="0f47e-241">3GP</span><span class="sxs-lookup"><span data-stu-id="0f47e-241">3GP</span></span></th>
<th align="left"><span data-ttu-id="0f47e-242">FLAC</span><span class="sxs-lookup"><span data-stu-id="0f47e-242">FLAC</span></span></th>
<th align="left"><span data-ttu-id="0f47e-243">WAV</span><span class="sxs-lookup"><span data-stu-id="0f47e-243">WAV</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="0f47e-244">HE-AAC v1/AAC+</span><span class="sxs-lookup"><span data-stu-id="0f47e-244">HE-AAC v1 / AAC+</span></span></td>
<td align="left"><span data-ttu-id="0f47e-245">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-245">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-246">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-246">D</span></span></td>
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
<td align="left"><span data-ttu-id="0f47e-247">HE-AAC v2/eAAC+</span><span class="sxs-lookup"><span data-stu-id="0f47e-247">HE-AAC v2 / eAAC+</span></span></td>
<td align="left"><span data-ttu-id="0f47e-248">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-248">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-249">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-249">D</span></span></td>
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
<td align="left"><span data-ttu-id="0f47e-250">AAC-LC</span><span class="sxs-lookup"><span data-stu-id="0f47e-250">AAC-LC</span></span></td>
<td align="left"><span data-ttu-id="0f47e-251">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-251">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-252">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-252">D</span></span></td>
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
<td align="left"><span data-ttu-id="0f47e-253">AC3</span><span class="sxs-lookup"><span data-stu-id="0f47e-253">AC3</span></span></td>
<td align="left"><span data-ttu-id="0f47e-254">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-254">D</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-255">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-255">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-256">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-256">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0f47e-257">EAC3/EC3</span><span class="sxs-lookup"><span data-stu-id="0f47e-257">EAC3 / EC3</span></span></td>
<td align="left"><span data-ttu-id="0f47e-258">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-258">D</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-259">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-259">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-260">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-260">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0f47e-261">ALAC</span><span class="sxs-lookup"><span data-stu-id="0f47e-261">ALAC</span></span></td>
<td align="left"><span data-ttu-id="0f47e-262">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-262">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="0f47e-263">AMR-NB</span><span class="sxs-lookup"><span data-stu-id="0f47e-263">AMR-NB</span></span></td>
<td align="left"><span data-ttu-id="0f47e-264">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-264">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-265">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-265">D/E</span></span></td>
<td align="left"><span data-ttu-id="0f47e-266">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-266">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0f47e-267">FLAC</span><span class="sxs-lookup"><span data-stu-id="0f47e-267">FLAC</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-268">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-268">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0f47e-269">G.711 (A-Law、µ-law)</span><span class="sxs-lookup"><span data-stu-id="0f47e-269">G.711 (A-Law, µ-law)</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-270">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-270">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0f47e-271">GSM 6.10</span><span class="sxs-lookup"><span data-stu-id="0f47e-271">GSM 6.10</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-272">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-272">D</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0f47e-273">IMA ADPCM</span><span class="sxs-lookup"><span data-stu-id="0f47e-273">IMA ADPCM</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-274">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-274">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0f47e-275">LPCM</span><span class="sxs-lookup"><span data-stu-id="0f47e-275">LPCM</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-276">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-276">D/E</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0f47e-277">MP3</span><span class="sxs-lookup"><span data-stu-id="0f47e-277">MP3</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-278">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-278">D</span></span></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="0f47e-279">MPEG-1/2</span><span class="sxs-lookup"><span data-stu-id="0f47e-279">MPEG-1/2</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-280">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-280">D</span></span></td>
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
<td align="left"><span data-ttu-id="0f47e-281">MS ADPCM</span><span class="sxs-lookup"><span data-stu-id="0f47e-281">MS ADPCM</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-282">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-282">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0f47e-283">WMA 1/2/3</span><span class="sxs-lookup"><span data-stu-id="0f47e-283">WMA 1/2/3</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-284">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-284">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0f47e-285">WMA Pro</span><span class="sxs-lookup"><span data-stu-id="0f47e-285">WMA Pro</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-286">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-286">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0f47e-287">WMA Voice</span><span class="sxs-lookup"><span data-stu-id="0f47e-287">WMA Voice</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-288">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-288">D</span></span></td>
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

 

### <a name="iot-core-arm"></a><span data-ttu-id="0f47e-289">IoT Core (ARM)</span><span class="sxs-lookup"><span data-stu-id="0f47e-289">IoT Core (ARM)</span></span>

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
<th align="left"><span data-ttu-id="0f47e-290">コーデック/コンテナー</span><span class="sxs-lookup"><span data-stu-id="0f47e-290">Codec/Container</span></span></th>
<th align="left"><span data-ttu-id="0f47e-291">MPEG-4</span><span class="sxs-lookup"><span data-stu-id="0f47e-291">MPEG-4</span></span></th>
<th align="left"><span data-ttu-id="0f47e-292">MPEG-3</span><span class="sxs-lookup"><span data-stu-id="0f47e-292">MPEG-3</span></span></th>
<th align="left"><span data-ttu-id="0f47e-293">MPEG-2</span><span class="sxs-lookup"><span data-stu-id="0f47e-293">MPEG-2</span></span></th>
<th align="left"><span data-ttu-id="0f47e-294">ADTS</span><span class="sxs-lookup"><span data-stu-id="0f47e-294">ADTS</span></span></th>
<th align="left"><span data-ttu-id="0f47e-295">ASF</span><span class="sxs-lookup"><span data-stu-id="0f47e-295">ASF</span></span></th>
<th align="left"><span data-ttu-id="0f47e-296">RIFF</span><span class="sxs-lookup"><span data-stu-id="0f47e-296">RIFF</span></span></th>
<th align="left"><span data-ttu-id="0f47e-297">AVI</span><span class="sxs-lookup"><span data-stu-id="0f47e-297">AVI</span></span></th>
<th align="left"><span data-ttu-id="0f47e-298">AC-3</span><span class="sxs-lookup"><span data-stu-id="0f47e-298">AC-3</span></span></th>
<th align="left"><span data-ttu-id="0f47e-299">AMR</span><span class="sxs-lookup"><span data-stu-id="0f47e-299">AMR</span></span></th>
<th align="left"><span data-ttu-id="0f47e-300">3GP</span><span class="sxs-lookup"><span data-stu-id="0f47e-300">3GP</span></span></th>
<th align="left"><span data-ttu-id="0f47e-301">FLAC</span><span class="sxs-lookup"><span data-stu-id="0f47e-301">FLAC</span></span></th>
<th align="left"><span data-ttu-id="0f47e-302">WAV</span><span class="sxs-lookup"><span data-stu-id="0f47e-302">WAV</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="0f47e-303">HE-AAC v1/AAC+</span><span class="sxs-lookup"><span data-stu-id="0f47e-303">HE-AAC v1 / AAC+</span></span></td>
<td align="left"><span data-ttu-id="0f47e-304">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-304">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-305">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-305">D</span></span></td>
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
<td align="left"><span data-ttu-id="0f47e-306">HE-AAC v2/eAAC+</span><span class="sxs-lookup"><span data-stu-id="0f47e-306">HE-AAC v2 / eAAC+</span></span></td>
<td align="left"><span data-ttu-id="0f47e-307">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-307">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-308">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-308">D</span></span></td>
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
<td align="left"><span data-ttu-id="0f47e-309">AAC-LC</span><span class="sxs-lookup"><span data-stu-id="0f47e-309">AAC-LC</span></span></td>
<td align="left"><span data-ttu-id="0f47e-310">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-310">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-311">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-311">D</span></span></td>
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
<td align="left"><span data-ttu-id="0f47e-312">AC3</span><span class="sxs-lookup"><span data-stu-id="0f47e-312">AC3</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="0f47e-313">EAC3/EC3</span><span class="sxs-lookup"><span data-stu-id="0f47e-313">EAC3 / EC3</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="0f47e-314">ALAC</span><span class="sxs-lookup"><span data-stu-id="0f47e-314">ALAC</span></span></td>
<td align="left"><span data-ttu-id="0f47e-315">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-315">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="0f47e-316">AMR-NB</span><span class="sxs-lookup"><span data-stu-id="0f47e-316">AMR-NB</span></span></td>
<td align="left"><span data-ttu-id="0f47e-317">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-317">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-318">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-318">D/E</span></span></td>
<td align="left"><span data-ttu-id="0f47e-319">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-319">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0f47e-320">FLAC</span><span class="sxs-lookup"><span data-stu-id="0f47e-320">FLAC</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-321">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-321">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0f47e-322">G.711 (A-Law、µ-law)</span><span class="sxs-lookup"><span data-stu-id="0f47e-322">G.711 (A-Law, µ-law)</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-323">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-323">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0f47e-324">GSM 6.10</span><span class="sxs-lookup"><span data-stu-id="0f47e-324">GSM 6.10</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-325">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-325">D</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0f47e-326">IMA ADPCM</span><span class="sxs-lookup"><span data-stu-id="0f47e-326">IMA ADPCM</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-327">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-327">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0f47e-328">LPCM</span><span class="sxs-lookup"><span data-stu-id="0f47e-328">LPCM</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-329">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-329">D/E</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0f47e-330">MP3</span><span class="sxs-lookup"><span data-stu-id="0f47e-330">MP3</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-331">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-331">D</span></span></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="0f47e-332">MPEG-1/2</span><span class="sxs-lookup"><span data-stu-id="0f47e-332">MPEG-1/2</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-333">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-333">D</span></span></td>
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
<td align="left"><span data-ttu-id="0f47e-334">MS ADPCM</span><span class="sxs-lookup"><span data-stu-id="0f47e-334">MS ADPCM</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-335">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-335">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0f47e-336">WMA 1/2/3</span><span class="sxs-lookup"><span data-stu-id="0f47e-336">WMA 1/2/3</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-337">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-337">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0f47e-338">WMA Pro</span><span class="sxs-lookup"><span data-stu-id="0f47e-338">WMA Pro</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-339">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-339">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0f47e-340">WMA Voice</span><span class="sxs-lookup"><span data-stu-id="0f47e-340">WMA Voice</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-341">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-341">D</span></span></td>
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

 

### <a name="xbox"></a><span data-ttu-id="0f47e-342">Xbox</span><span class="sxs-lookup"><span data-stu-id="0f47e-342">XBox</span></span>

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
<th align="left"><span data-ttu-id="0f47e-343">コーデック/コンテナー</span><span class="sxs-lookup"><span data-stu-id="0f47e-343">Codec/Container</span></span></th>
<th align="left"><span data-ttu-id="0f47e-344">MPEG-4</span><span class="sxs-lookup"><span data-stu-id="0f47e-344">MPEG-4</span></span></th>
<th align="left"><span data-ttu-id="0f47e-345">MPEG-3</span><span class="sxs-lookup"><span data-stu-id="0f47e-345">MPEG-3</span></span></th>
<th align="left"><span data-ttu-id="0f47e-346">MPEG-2</span><span class="sxs-lookup"><span data-stu-id="0f47e-346">MPEG-2</span></span></th>
<th align="left"><span data-ttu-id="0f47e-347">ADTS</span><span class="sxs-lookup"><span data-stu-id="0f47e-347">ADTS</span></span></th>
<th align="left"><span data-ttu-id="0f47e-348">ASF</span><span class="sxs-lookup"><span data-stu-id="0f47e-348">ASF</span></span></th>
<th align="left"><span data-ttu-id="0f47e-349">RIFF</span><span class="sxs-lookup"><span data-stu-id="0f47e-349">RIFF</span></span></th>
<th align="left"><span data-ttu-id="0f47e-350">AVI</span><span class="sxs-lookup"><span data-stu-id="0f47e-350">AVI</span></span></th>
<th align="left"><span data-ttu-id="0f47e-351">AC-3</span><span class="sxs-lookup"><span data-stu-id="0f47e-351">AC-3</span></span></th>
<th align="left"><span data-ttu-id="0f47e-352">AMR</span><span class="sxs-lookup"><span data-stu-id="0f47e-352">AMR</span></span></th>
<th align="left"><span data-ttu-id="0f47e-353">3GP</span><span class="sxs-lookup"><span data-stu-id="0f47e-353">3GP</span></span></th>
<th align="left"><span data-ttu-id="0f47e-354">FLAC</span><span class="sxs-lookup"><span data-stu-id="0f47e-354">FLAC</span></span></th>
<th align="left"><span data-ttu-id="0f47e-355">WAV</span><span class="sxs-lookup"><span data-stu-id="0f47e-355">WAV</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="0f47e-356">HE-AAC v1/AAC+</span><span class="sxs-lookup"><span data-stu-id="0f47e-356">HE-AAC v1 / AAC+</span></span></td>
<td align="left"><span data-ttu-id="0f47e-357">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-357">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-358">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-358">D</span></span></td>
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
<td align="left"><span data-ttu-id="0f47e-359">HE-AAC v2/eAAC+</span><span class="sxs-lookup"><span data-stu-id="0f47e-359">HE-AAC v2 / eAAC+</span></span></td>
<td align="left"><span data-ttu-id="0f47e-360">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-360">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-361">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-361">D</span></span></td>
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
<td align="left"><span data-ttu-id="0f47e-362">AAC-LC</span><span class="sxs-lookup"><span data-stu-id="0f47e-362">AAC-LC</span></span></td>
<td align="left"><span data-ttu-id="0f47e-363">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-363">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-364">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-364">D</span></span></td>
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
<td align="left"><span data-ttu-id="0f47e-365">AC3</span><span class="sxs-lookup"><span data-stu-id="0f47e-365">AC3</span></span></td>
<td align="left"><span data-ttu-id="0f47e-366">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-366">D</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-367">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-367">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-368">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-368">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0f47e-369">EAC3/EC3</span><span class="sxs-lookup"><span data-stu-id="0f47e-369">EAC3 / EC3</span></span></td>
<td align="left"><span data-ttu-id="0f47e-370">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-370">D</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-371">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-371">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-372">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-372">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0f47e-373">ALAC</span><span class="sxs-lookup"><span data-stu-id="0f47e-373">ALAC</span></span></td>
<td align="left"><span data-ttu-id="0f47e-374">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-374">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="0f47e-375">AMR-NB</span><span class="sxs-lookup"><span data-stu-id="0f47e-375">AMR-NB</span></span></td>
<td align="left"><span data-ttu-id="0f47e-376">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-376">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-377">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-377">D/E</span></span></td>
<td align="left"><span data-ttu-id="0f47e-378">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-378">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0f47e-379">FLAC</span><span class="sxs-lookup"><span data-stu-id="0f47e-379">FLAC</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-380">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-380">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0f47e-381">G.711 (A-Law、µ-law)</span><span class="sxs-lookup"><span data-stu-id="0f47e-381">G.711 (A-Law, µ-law)</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-382">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-382">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0f47e-383">GSM 6.10</span><span class="sxs-lookup"><span data-stu-id="0f47e-383">GSM 6.10</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-384">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-384">D</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0f47e-385">IMA ADPCM</span><span class="sxs-lookup"><span data-stu-id="0f47e-385">IMA ADPCM</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-386">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-386">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0f47e-387">LPCM</span><span class="sxs-lookup"><span data-stu-id="0f47e-387">LPCM</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-388">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-388">D/E</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0f47e-389">MP3</span><span class="sxs-lookup"><span data-stu-id="0f47e-389">MP3</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-390">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-390">D</span></span></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="0f47e-391">MPEG-1/2</span><span class="sxs-lookup"><span data-stu-id="0f47e-391">MPEG-1/2</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-392">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-392">D</span></span></td>
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
<td align="left"><span data-ttu-id="0f47e-393">MS ADPCM</span><span class="sxs-lookup"><span data-stu-id="0f47e-393">MS ADPCM</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-394">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-394">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0f47e-395">WMA 1/2/3</span><span class="sxs-lookup"><span data-stu-id="0f47e-395">WMA 1/2/3</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-396">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-396">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0f47e-397">WMA Pro</span><span class="sxs-lookup"><span data-stu-id="0f47e-397">WMA Pro</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-398">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-398">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0f47e-399">WMA Voice</span><span class="sxs-lookup"><span data-stu-id="0f47e-399">WMA Voice</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-400">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-400">D</span></span></td>
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

 

## <a name="video-codec--format-support"></a><span data-ttu-id="0f47e-401">ビデオのコーデックおよび形式のサポート</span><span class="sxs-lookup"><span data-stu-id="0f47e-401">Video codec & format support</span></span>

<span data-ttu-id="0f47e-402">次の表は、各デバイス ファミリのビデオのコーデックと形式のサポートを示しています。</span><span class="sxs-lookup"><span data-stu-id="0f47e-402">The following tables show the video codec and format support for each device family.</span></span>

> [!NOTE] 
> <span data-ttu-id="0f47e-403">H.265 のサポートが示されている場合、必ずしもデバイス ファミリ内のすべてのデバイスでサポートされるわけではありません。</span><span class="sxs-lookup"><span data-stu-id="0f47e-403">Where H.265 support is indicated, it is not necessarily supported by all devices within the device family.</span></span>
> <span data-ttu-id="0f47e-404">MPEG-2/MPEG-1 のサポートが示されている場合、オプションの Microsoft DVD ユニバーサル Windows アプリのインストールでのみサポートされます。</span><span class="sxs-lookup"><span data-stu-id="0f47e-404">Where MPEG-2/MPEG-1 support is indicated, it is only supported with the installation of the optional Microsoft DVD Universal Windows app.</span></span>

 

### <a name="desktop"></a><span data-ttu-id="0f47e-405">デスクトップ</span><span class="sxs-lookup"><span data-stu-id="0f47e-405">Desktop</span></span>

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
<th align="left"><span data-ttu-id="0f47e-406">コーデック/コンテナー</span><span class="sxs-lookup"><span data-stu-id="0f47e-406">Codec/Container</span></span></th>
<th align="left"><span data-ttu-id="0f47e-407">FOURCC</span><span class="sxs-lookup"><span data-stu-id="0f47e-407">FOURCC</span></span></th>
<th align="left"><span data-ttu-id="0f47e-408">fMP4</span><span class="sxs-lookup"><span data-stu-id="0f47e-408">fMP4</span></span></th>
<th align="left"><span data-ttu-id="0f47e-409">MPEG-4</span><span class="sxs-lookup"><span data-stu-id="0f47e-409">MPEG-4</span></span></th>
<th align="left"><span data-ttu-id="0f47e-410">MPEG-2 PS</span><span class="sxs-lookup"><span data-stu-id="0f47e-410">MPEG-2 PS</span></span></th>
<th align="left"><span data-ttu-id="0f47e-411">MPEG-2 TS</span><span class="sxs-lookup"><span data-stu-id="0f47e-411">MPEG-2 TS</span></span></th>
<th align="left"><span data-ttu-id="0f47e-412">MPEG-1</span><span class="sxs-lookup"><span data-stu-id="0f47e-412">MPEG-1</span></span></th>
<th align="left"><span data-ttu-id="0f47e-413">3GPP</span><span class="sxs-lookup"><span data-stu-id="0f47e-413">3GPP</span></span></th>
<th align="left"><span data-ttu-id="0f47e-414">3GPP2</span><span class="sxs-lookup"><span data-stu-id="0f47e-414">3GPP2</span></span></th>
<th align="left"><span data-ttu-id="0f47e-415">AVCHD</span><span class="sxs-lookup"><span data-stu-id="0f47e-415">AVCHD</span></span></th>
<th align="left"><span data-ttu-id="0f47e-416">ASF</span><span class="sxs-lookup"><span data-stu-id="0f47e-416">ASF</span></span></th>
<th align="left"><span data-ttu-id="0f47e-417">AVI</span><span class="sxs-lookup"><span data-stu-id="0f47e-417">AVI</span></span></th>
<th align="left"><span data-ttu-id="0f47e-418">MKV</span><span class="sxs-lookup"><span data-stu-id="0f47e-418">MKV</span></span></th>
<th align="left"><span data-ttu-id="0f47e-419">DV</span><span class="sxs-lookup"><span data-stu-id="0f47e-419">DV</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="0f47e-420">MPEG-1</span><span class="sxs-lookup"><span data-stu-id="0f47e-420">MPEG-1</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-421">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-421">D/E</span></span></td>
<td align="left"><span data-ttu-id="0f47e-422">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-422">D/E</span></span></td>
<td align="left"><span data-ttu-id="0f47e-423">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-423">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-424">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-424">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-425">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-425">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0f47e-426">MPEG-2</span><span class="sxs-lookup"><span data-stu-id="0f47e-426">MPEG-2</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-427">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-427">D/E</span></span></td>
<td align="left"><span data-ttu-id="0f47e-428">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-428">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-429">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-429">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-430">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-430">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0f47e-431">MPEG-4 (Part 2)</span><span class="sxs-lookup"><span data-stu-id="0f47e-431">MPEG-4 (Part 2)</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-432">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-432">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-433">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-433">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-434">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-434">D</span></span></td>
<td align="left"><span data-ttu-id="0f47e-435">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-435">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0f47e-436">H.265</span><span class="sxs-lookup"><span data-stu-id="0f47e-436">H.265</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-437">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-437">D</span></span></td>
<td align="left"><span data-ttu-id="0f47e-438">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-438">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-439">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-439">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0f47e-440">H.264</span><span class="sxs-lookup"><span data-stu-id="0f47e-440">H.264</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-441">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-441">D/E</span></span></td>
<td align="left"><span data-ttu-id="0f47e-442">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-442">D/E</span></span></td>
<td align="left"><span data-ttu-id="0f47e-443">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-443">D/E</span></span></td>
<td align="left"><span data-ttu-id="0f47e-444">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-444">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-445">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-445">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-446">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-446">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-447">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-447">D</span></span></td>
<td align="left"><span data-ttu-id="0f47e-448">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-448">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0f47e-449">H.263</span><span class="sxs-lookup"><span data-stu-id="0f47e-449">H.263</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-450">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-450">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-451">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-451">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-452">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-452">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0f47e-453">VC-1</span><span class="sxs-lookup"><span data-stu-id="0f47e-453">VC-1</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-454">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-454">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-455">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-455">D</span></span></td>
<td align="left"><span data-ttu-id="0f47e-456">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-456">D</span></span></td>
<td align="left"><span data-ttu-id="0f47e-457">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-457">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0f47e-458">WMV7/8/9</span><span class="sxs-lookup"><span data-stu-id="0f47e-458">WMV7/8/9</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-459">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-459">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-460">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-460">D/E</span></span></td>
<td align="left"><span data-ttu-id="0f47e-461">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-461">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0f47e-462">WMV9 Screen</span><span class="sxs-lookup"><span data-stu-id="0f47e-462">WMV9 Screen</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-463">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-463">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-464">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-464">D</span></span></td>
<td align="left"><span data-ttu-id="0f47e-465">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-465">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0f47e-466">DV</span><span class="sxs-lookup"><span data-stu-id="0f47e-466">DV</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-467">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-467">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-468">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-468">D</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-469">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-469">D</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0f47e-470">モーション JPEG</span><span class="sxs-lookup"><span data-stu-id="0f47e-470">Motion JPEG</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-471">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-471">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-472">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-472">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
</tbody>
</table>

 

### <a name="mobile"></a><span data-ttu-id="0f47e-473">モバイル</span><span class="sxs-lookup"><span data-stu-id="0f47e-473">Mobile</span></span>

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
<th align="left"><span data-ttu-id="0f47e-474">コーデック/コンテナー</span><span class="sxs-lookup"><span data-stu-id="0f47e-474">Codec/Container</span></span></th>
<th align="left"><span data-ttu-id="0f47e-475">FOURCC</span><span class="sxs-lookup"><span data-stu-id="0f47e-475">FOURCC</span></span></th>
<th align="left"><span data-ttu-id="0f47e-476">fMP4</span><span class="sxs-lookup"><span data-stu-id="0f47e-476">fMP4</span></span></th>
<th align="left"><span data-ttu-id="0f47e-477">MPEG-4</span><span class="sxs-lookup"><span data-stu-id="0f47e-477">MPEG-4</span></span></th>
<th align="left"><span data-ttu-id="0f47e-478">MPEG-2 PS</span><span class="sxs-lookup"><span data-stu-id="0f47e-478">MPEG-2 PS</span></span></th>
<th align="left"><span data-ttu-id="0f47e-479">MPEG-2 TS</span><span class="sxs-lookup"><span data-stu-id="0f47e-479">MPEG-2 TS</span></span></th>
<th align="left"><span data-ttu-id="0f47e-480">MPEG-1</span><span class="sxs-lookup"><span data-stu-id="0f47e-480">MPEG-1</span></span></th>
<th align="left"><span data-ttu-id="0f47e-481">3GPP</span><span class="sxs-lookup"><span data-stu-id="0f47e-481">3GPP</span></span></th>
<th align="left"><span data-ttu-id="0f47e-482">3GPP2</span><span class="sxs-lookup"><span data-stu-id="0f47e-482">3GPP2</span></span></th>
<th align="left"><span data-ttu-id="0f47e-483">AVCHD</span><span class="sxs-lookup"><span data-stu-id="0f47e-483">AVCHD</span></span></th>
<th align="left"><span data-ttu-id="0f47e-484">ASF</span><span class="sxs-lookup"><span data-stu-id="0f47e-484">ASF</span></span></th>
<th align="left"><span data-ttu-id="0f47e-485">AVI</span><span class="sxs-lookup"><span data-stu-id="0f47e-485">AVI</span></span></th>
<th align="left"><span data-ttu-id="0f47e-486">MKV</span><span class="sxs-lookup"><span data-stu-id="0f47e-486">MKV</span></span></th>
<th align="left"><span data-ttu-id="0f47e-487">DV</span><span class="sxs-lookup"><span data-stu-id="0f47e-487">DV</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="0f47e-488">MPEG-1</span><span class="sxs-lookup"><span data-stu-id="0f47e-488">MPEG-1</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="0f47e-489">MPEG-2</span><span class="sxs-lookup"><span data-stu-id="0f47e-489">MPEG-2</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="0f47e-490">MPEG-4 (Part 2)</span><span class="sxs-lookup"><span data-stu-id="0f47e-490">MPEG-4 (Part 2)</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-491">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-491">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-492">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-492">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-493">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-493">D</span></span></td>
<td align="left"><span data-ttu-id="0f47e-494">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-494">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0f47e-495">H.265</span><span class="sxs-lookup"><span data-stu-id="0f47e-495">H.265</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-496">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-496">D</span></span></td>
<td align="left"><span data-ttu-id="0f47e-497">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-497">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-498">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-498">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0f47e-499">H.264</span><span class="sxs-lookup"><span data-stu-id="0f47e-499">H.264</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-500">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-500">D/E</span></span></td>
<td align="left"><span data-ttu-id="0f47e-501">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-501">D/E</span></span></td>
<td align="left"><span data-ttu-id="0f47e-502">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-502">D/E</span></span></td>
<td align="left"><span data-ttu-id="0f47e-503">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-503">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-504">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-504">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-505">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-505">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-506">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-506">D</span></span></td>
<td align="left"><span data-ttu-id="0f47e-507">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-507">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0f47e-508">H.263</span><span class="sxs-lookup"><span data-stu-id="0f47e-508">H.263</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-509">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-509">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-510">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-510">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-511">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-511">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0f47e-512">VC-1</span><span class="sxs-lookup"><span data-stu-id="0f47e-512">VC-1</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-513">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-513">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-514">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-514">D</span></span></td>
<td align="left"><span data-ttu-id="0f47e-515">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-515">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0f47e-516">WMV7/8/9</span><span class="sxs-lookup"><span data-stu-id="0f47e-516">WMV7/8/9</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="0f47e-517">WMV9 Screen</span><span class="sxs-lookup"><span data-stu-id="0f47e-517">WMV9 Screen</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="0f47e-518">DV</span><span class="sxs-lookup"><span data-stu-id="0f47e-518">DV</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="0f47e-519">モーション JPEG</span><span class="sxs-lookup"><span data-stu-id="0f47e-519">Motion JPEG</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-520">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-520">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-521">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-521">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
</tbody>
</table>

 

### <a name="iot-core-x86"></a><span data-ttu-id="0f47e-522">IoT Core (x86)</span><span class="sxs-lookup"><span data-stu-id="0f47e-522">IoT Core (x86)</span></span>

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
<th align="left"><span data-ttu-id="0f47e-523">コーデック/コンテナー</span><span class="sxs-lookup"><span data-stu-id="0f47e-523">Codec/Container</span></span></th>
<th align="left"><span data-ttu-id="0f47e-524">FOURCC</span><span class="sxs-lookup"><span data-stu-id="0f47e-524">FOURCC</span></span></th>
<th align="left"><span data-ttu-id="0f47e-525">fMP4</span><span class="sxs-lookup"><span data-stu-id="0f47e-525">fMP4</span></span></th>
<th align="left"><span data-ttu-id="0f47e-526">MPEG-4</span><span class="sxs-lookup"><span data-stu-id="0f47e-526">MPEG-4</span></span></th>
<th align="left"><span data-ttu-id="0f47e-527">MPEG-2 PS</span><span class="sxs-lookup"><span data-stu-id="0f47e-527">MPEG-2 PS</span></span></th>
<th align="left"><span data-ttu-id="0f47e-528">MPEG-2 TS</span><span class="sxs-lookup"><span data-stu-id="0f47e-528">MPEG-2 TS</span></span></th>
<th align="left"><span data-ttu-id="0f47e-529">MPEG-1</span><span class="sxs-lookup"><span data-stu-id="0f47e-529">MPEG-1</span></span></th>
<th align="left"><span data-ttu-id="0f47e-530">3GPP</span><span class="sxs-lookup"><span data-stu-id="0f47e-530">3GPP</span></span></th>
<th align="left"><span data-ttu-id="0f47e-531">3GPP2</span><span class="sxs-lookup"><span data-stu-id="0f47e-531">3GPP2</span></span></th>
<th align="left"><span data-ttu-id="0f47e-532">AVCHD</span><span class="sxs-lookup"><span data-stu-id="0f47e-532">AVCHD</span></span></th>
<th align="left"><span data-ttu-id="0f47e-533">ASF</span><span class="sxs-lookup"><span data-stu-id="0f47e-533">ASF</span></span></th>
<th align="left"><span data-ttu-id="0f47e-534">AVI</span><span class="sxs-lookup"><span data-stu-id="0f47e-534">AVI</span></span></th>
<th align="left"><span data-ttu-id="0f47e-535">MKV</span><span class="sxs-lookup"><span data-stu-id="0f47e-535">MKV</span></span></th>
<th align="left"><span data-ttu-id="0f47e-536">DV</span><span class="sxs-lookup"><span data-stu-id="0f47e-536">DV</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="0f47e-537">MPEG-1</span><span class="sxs-lookup"><span data-stu-id="0f47e-537">MPEG-1</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="0f47e-538">MPEG-2</span><span class="sxs-lookup"><span data-stu-id="0f47e-538">MPEG-2</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="0f47e-539">MPEG-4 (Part 2)</span><span class="sxs-lookup"><span data-stu-id="0f47e-539">MPEG-4 (Part 2)</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-540">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-540">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-541">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-541">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-542">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-542">D</span></span></td>
<td align="left"><span data-ttu-id="0f47e-543">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-543">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0f47e-544">H.265</span><span class="sxs-lookup"><span data-stu-id="0f47e-544">H.265</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-545">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-545">D</span></span></td>
<td align="left"><span data-ttu-id="0f47e-546">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-546">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-547">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-547">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0f47e-548">H.264</span><span class="sxs-lookup"><span data-stu-id="0f47e-548">H.264</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-549">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-549">D/E</span></span></td>
<td align="left"><span data-ttu-id="0f47e-550">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-550">D/E</span></span></td>
<td align="left"><span data-ttu-id="0f47e-551">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-551">D/E</span></span></td>
<td align="left"><span data-ttu-id="0f47e-552">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-552">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-553">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-553">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-554">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-554">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-555">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-555">D</span></span></td>
<td align="left"><span data-ttu-id="0f47e-556">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-556">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0f47e-557">H.263</span><span class="sxs-lookup"><span data-stu-id="0f47e-557">H.263</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-558">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-558">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-559">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-559">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-560">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-560">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0f47e-561">VC-1</span><span class="sxs-lookup"><span data-stu-id="0f47e-561">VC-1</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-562">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-562">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-563">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-563">D</span></span></td>
<td align="left"><span data-ttu-id="0f47e-564">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-564">D</span></span></td>
<td align="left"><span data-ttu-id="0f47e-565">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-565">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0f47e-566">WMV7/8/9</span><span class="sxs-lookup"><span data-stu-id="0f47e-566">WMV7/8/9</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-567">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-567">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-568">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-568">D</span></span></td>
<td align="left"><span data-ttu-id="0f47e-569">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-569">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0f47e-570">WMV9 Screen</span><span class="sxs-lookup"><span data-stu-id="0f47e-570">WMV9 Screen</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-571">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-571">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-572">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-572">D</span></span></td>
<td align="left"><span data-ttu-id="0f47e-573">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-573">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0f47e-574">DV</span><span class="sxs-lookup"><span data-stu-id="0f47e-574">DV</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="0f47e-575">モーション JPEG</span><span class="sxs-lookup"><span data-stu-id="0f47e-575">Motion JPEG</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-576">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-576">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-577">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-577">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
</tbody>
</table>

 

### <a name="iot-arm"></a><span data-ttu-id="0f47e-578">IoT (ARM)</span><span class="sxs-lookup"><span data-stu-id="0f47e-578">IoT (ARM)</span></span>

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
<th align="left"><span data-ttu-id="0f47e-579">コーデック/コンテナー</span><span class="sxs-lookup"><span data-stu-id="0f47e-579">Codec/Container</span></span></th>
<th align="left"><span data-ttu-id="0f47e-580">FOURCC</span><span class="sxs-lookup"><span data-stu-id="0f47e-580">FOURCC</span></span></th>
<th align="left"><span data-ttu-id="0f47e-581">fMP4</span><span class="sxs-lookup"><span data-stu-id="0f47e-581">fMP4</span></span></th>
<th align="left"><span data-ttu-id="0f47e-582">MPEG-4</span><span class="sxs-lookup"><span data-stu-id="0f47e-582">MPEG-4</span></span></th>
<th align="left"><span data-ttu-id="0f47e-583">MPEG-2 PS</span><span class="sxs-lookup"><span data-stu-id="0f47e-583">MPEG-2 PS</span></span></th>
<th align="left"><span data-ttu-id="0f47e-584">MPEG-2 TS</span><span class="sxs-lookup"><span data-stu-id="0f47e-584">MPEG-2 TS</span></span></th>
<th align="left"><span data-ttu-id="0f47e-585">MPEG-1</span><span class="sxs-lookup"><span data-stu-id="0f47e-585">MPEG-1</span></span></th>
<th align="left"><span data-ttu-id="0f47e-586">3GPP</span><span class="sxs-lookup"><span data-stu-id="0f47e-586">3GPP</span></span></th>
<th align="left"><span data-ttu-id="0f47e-587">3GPP2</span><span class="sxs-lookup"><span data-stu-id="0f47e-587">3GPP2</span></span></th>
<th align="left"><span data-ttu-id="0f47e-588">AVCHD</span><span class="sxs-lookup"><span data-stu-id="0f47e-588">AVCHD</span></span></th>
<th align="left"><span data-ttu-id="0f47e-589">ASF</span><span class="sxs-lookup"><span data-stu-id="0f47e-589">ASF</span></span></th>
<th align="left"><span data-ttu-id="0f47e-590">AVI</span><span class="sxs-lookup"><span data-stu-id="0f47e-590">AVI</span></span></th>
<th align="left"><span data-ttu-id="0f47e-591">MKV</span><span class="sxs-lookup"><span data-stu-id="0f47e-591">MKV</span></span></th>
<th align="left"><span data-ttu-id="0f47e-592">DV</span><span class="sxs-lookup"><span data-stu-id="0f47e-592">DV</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="0f47e-593">MPEG-1</span><span class="sxs-lookup"><span data-stu-id="0f47e-593">MPEG-1</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="0f47e-594">MPEG-2</span><span class="sxs-lookup"><span data-stu-id="0f47e-594">MPEG-2</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="0f47e-595">MPEG-4 (Part 2)</span><span class="sxs-lookup"><span data-stu-id="0f47e-595">MPEG-4 (Part 2)</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="0f47e-596">H.265</span><span class="sxs-lookup"><span data-stu-id="0f47e-596">H.265</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-597">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-597">D</span></span></td>
<td align="left"><span data-ttu-id="0f47e-598">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-598">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-599">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-599">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0f47e-600">H.264</span><span class="sxs-lookup"><span data-stu-id="0f47e-600">H.264</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-601">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-601">D/E</span></span></td>
<td align="left"><span data-ttu-id="0f47e-602">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-602">D/E</span></span></td>
<td align="left"><span data-ttu-id="0f47e-603">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-603">D/E</span></span></td>
<td align="left"><span data-ttu-id="0f47e-604">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-604">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-605">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-605">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-606">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-606">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-607">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-607">D</span></span></td>
<td align="left"><span data-ttu-id="0f47e-608">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-608">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0f47e-609">H.263</span><span class="sxs-lookup"><span data-stu-id="0f47e-609">H.263</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="0f47e-610">VC-1</span><span class="sxs-lookup"><span data-stu-id="0f47e-610">VC-1</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-611">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-611">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-612">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-612">D</span></span></td>
<td align="left"><span data-ttu-id="0f47e-613">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-613">D</span></span></td>
<td align="left"><span data-ttu-id="0f47e-614">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-614">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0f47e-615">WMV7/8/9</span><span class="sxs-lookup"><span data-stu-id="0f47e-615">WMV7/8/9</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-616">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-616">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-617">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-617">D</span></span></td>
<td align="left"><span data-ttu-id="0f47e-618">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-618">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0f47e-619">WMV9 Screen</span><span class="sxs-lookup"><span data-stu-id="0f47e-619">WMV9 Screen</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="0f47e-620">DV</span><span class="sxs-lookup"><span data-stu-id="0f47e-620">DV</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="0f47e-621">モーション JPEG</span><span class="sxs-lookup"><span data-stu-id="0f47e-621">Motion JPEG</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-622">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-622">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-623">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-623">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
</tbody>
</table>

 

### <a name="xbox"></a><span data-ttu-id="0f47e-624">Xbox</span><span class="sxs-lookup"><span data-stu-id="0f47e-624">XBox</span></span>

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
<th align="left"><span data-ttu-id="0f47e-625">コーデック/コンテナー</span><span class="sxs-lookup"><span data-stu-id="0f47e-625">Codec/Container</span></span></th>
<th align="left"><span data-ttu-id="0f47e-626">FOURCC</span><span class="sxs-lookup"><span data-stu-id="0f47e-626">FOURCC</span></span></th>
<th align="left"><span data-ttu-id="0f47e-627">fMP4</span><span class="sxs-lookup"><span data-stu-id="0f47e-627">fMP4</span></span></th>
<th align="left"><span data-ttu-id="0f47e-628">MPEG-4</span><span class="sxs-lookup"><span data-stu-id="0f47e-628">MPEG-4</span></span></th>
<th align="left"><span data-ttu-id="0f47e-629">MPEG-2 PS</span><span class="sxs-lookup"><span data-stu-id="0f47e-629">MPEG-2 PS</span></span></th>
<th align="left"><span data-ttu-id="0f47e-630">MPEG-2 TS</span><span class="sxs-lookup"><span data-stu-id="0f47e-630">MPEG-2 TS</span></span></th>
<th align="left"><span data-ttu-id="0f47e-631">MPEG-1</span><span class="sxs-lookup"><span data-stu-id="0f47e-631">MPEG-1</span></span></th>
<th align="left"><span data-ttu-id="0f47e-632">3GPP</span><span class="sxs-lookup"><span data-stu-id="0f47e-632">3GPP</span></span></th>
<th align="left"><span data-ttu-id="0f47e-633">3GPP2</span><span class="sxs-lookup"><span data-stu-id="0f47e-633">3GPP2</span></span></th>
<th align="left"><span data-ttu-id="0f47e-634">AVCHD</span><span class="sxs-lookup"><span data-stu-id="0f47e-634">AVCHD</span></span></th>
<th align="left"><span data-ttu-id="0f47e-635">ASF</span><span class="sxs-lookup"><span data-stu-id="0f47e-635">ASF</span></span></th>
<th align="left"><span data-ttu-id="0f47e-636">AVI</span><span class="sxs-lookup"><span data-stu-id="0f47e-636">AVI</span></span></th>
<th align="left"><span data-ttu-id="0f47e-637">MKV</span><span class="sxs-lookup"><span data-stu-id="0f47e-637">MKV</span></span></th>
<th align="left"><span data-ttu-id="0f47e-638">DV</span><span class="sxs-lookup"><span data-stu-id="0f47e-638">DV</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="0f47e-639">MPEG-1</span><span class="sxs-lookup"><span data-stu-id="0f47e-639">MPEG-1</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-640">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-640">D/E</span></span></td>
<td align="left"><span data-ttu-id="0f47e-641">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-641">D/E</span></span></td>
<td align="left"><span data-ttu-id="0f47e-642">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-642">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-643">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-643">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-644">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-644">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0f47e-645">MPEG-2</span><span class="sxs-lookup"><span data-stu-id="0f47e-645">MPEG-2</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-646">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-646">D/E</span></span></td>
<td align="left"><span data-ttu-id="0f47e-647">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-647">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-648">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-648">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-649">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-649">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0f47e-650">MPEG-4 (Part 2)</span><span class="sxs-lookup"><span data-stu-id="0f47e-650">MPEG-4 (Part 2)</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-651">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-651">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-652">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-652">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-653">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-653">D</span></span></td>
<td align="left"><span data-ttu-id="0f47e-654">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-654">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0f47e-655">H.265</span><span class="sxs-lookup"><span data-stu-id="0f47e-655">H.265</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-656">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-656">D</span></span></td>
<td align="left"><span data-ttu-id="0f47e-657">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-657">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-658">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-658">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0f47e-659">H.264</span><span class="sxs-lookup"><span data-stu-id="0f47e-659">H.264</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-660">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-660">D/E</span></span></td>
<td align="left"><span data-ttu-id="0f47e-661">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-661">D/E</span></span></td>
<td align="left"><span data-ttu-id="0f47e-662">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-662">D/E</span></span></td>
<td align="left"><span data-ttu-id="0f47e-663">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-663">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-664">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-664">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-665">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-665">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-666">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-666">D</span></span></td>
<td align="left"><span data-ttu-id="0f47e-667">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-667">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0f47e-668">H.263</span><span class="sxs-lookup"><span data-stu-id="0f47e-668">H.263</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-669">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-669">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-670">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-670">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-671">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-671">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0f47e-672">VC-1</span><span class="sxs-lookup"><span data-stu-id="0f47e-672">VC-1</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-673">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-673">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-674">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-674">D</span></span></td>
<td align="left"><span data-ttu-id="0f47e-675">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-675">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0f47e-676">WMV7/8/9</span><span class="sxs-lookup"><span data-stu-id="0f47e-676">WMV7/8/9</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="0f47e-677">WMV9 Screen</span><span class="sxs-lookup"><span data-stu-id="0f47e-677">WMV9 Screen</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="0f47e-678">DV</span><span class="sxs-lookup"><span data-stu-id="0f47e-678">DV</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="0f47e-679">モーション JPEG</span><span class="sxs-lookup"><span data-stu-id="0f47e-679">Motion JPEG</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-680">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-680">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="0f47e-681">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-681">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
</tbody>
</table>

## <a name="image-codec--format-support"></a><span data-ttu-id="0f47e-682">イメージのコーデックおよび形式のサポート</span><span class="sxs-lookup"><span data-stu-id="0f47e-682">Image codec & format support</span></span> 

<table>
<colgroup>
<col width="7%" />
<col width="7%" />
<col width="7%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="0f47e-683">コーデック</span><span class="sxs-lookup"><span data-stu-id="0f47e-683">Codec</span></span></th>
<th align="left"><span data-ttu-id="0f47e-684">デスクトップ</span><span class="sxs-lookup"><span data-stu-id="0f47e-684">Desktop</span></span></th>
<th align="left"><span data-ttu-id="0f47e-685">他のデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="0f47e-685">Other device families</span></span></th>
</tr>
</thead>
<tr class="odd">
<td align="left"><span data-ttu-id="0f47e-686">BMP</span><span class="sxs-lookup"><span data-stu-id="0f47e-686">BMP</span></span></td>
<td align="left"><span data-ttu-id="0f47e-687">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-687">D/E</span></span></td>
<td align="left"><span data-ttu-id="0f47e-688">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-688">D/E</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0f47e-689">DDS</span><span class="sxs-lookup"><span data-stu-id="0f47e-689">DDS</span></span></td>
<td align="left"><span data-ttu-id="0f47e-690">D/E<sup>1</sup></span><span class="sxs-lookup"><span data-stu-id="0f47e-690">D/E<sup>1</sup></span></span></td>
<td align="left"><span data-ttu-id="0f47e-691">D/E<sup>1</sup></span><span class="sxs-lookup"><span data-stu-id="0f47e-691">D/E<sup>1</sup></span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0f47e-692">DNG</span><span class="sxs-lookup"><span data-stu-id="0f47e-692">DNG</span></span></td>
<td align="left"><span data-ttu-id="0f47e-693">D<sup>2</sup></span><span class="sxs-lookup"><span data-stu-id="0f47e-693">D<sup>2</sup></span></span></td>
<td align="left"><span data-ttu-id="0f47e-694">D<sup>2</sup></span><span class="sxs-lookup"><span data-stu-id="0f47e-694">D<sup>2</sup></span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0f47e-695">GIF</span><span class="sxs-lookup"><span data-stu-id="0f47e-695">GIF</span></span></td>
<td align="left"><span data-ttu-id="0f47e-696">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-696">D/E</span></span></td>
<td align="left"><span data-ttu-id="0f47e-697">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-697">D/E</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0f47e-698">ICO</span><span class="sxs-lookup"><span data-stu-id="0f47e-698">ICO</span></span></td>
<td align="left"><span data-ttu-id="0f47e-699">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-699">D</span></span></td>
<td align="left"><span data-ttu-id="0f47e-700">D</span><span class="sxs-lookup"><span data-stu-id="0f47e-700">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0f47e-701">JPEG</span><span class="sxs-lookup"><span data-stu-id="0f47e-701">JPEG</span></span></td>
<td align="left"><span data-ttu-id="0f47e-702">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-702">D/E</span></span></td>
<td align="left"><span data-ttu-id="0f47e-703">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-703">D/E</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0f47e-704">JPEG-XR</span><span class="sxs-lookup"><span data-stu-id="0f47e-704">JPEG-XR</span></span></td>
<td align="left"><span data-ttu-id="0f47e-705">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-705">D/E</span></span></td>
<td align="left"><span data-ttu-id="0f47e-706">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-706">D/E</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0f47e-707">PNG</span><span class="sxs-lookup"><span data-stu-id="0f47e-707">PNG</span></span></td>
<td align="left"><span data-ttu-id="0f47e-708">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-708">D/E</span></span></td>
<td align="left"><span data-ttu-id="0f47e-709">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-709">D/E</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0f47e-710">TIFF</span><span class="sxs-lookup"><span data-stu-id="0f47e-710">TIFF</span></span></td>
<td align="left"><span data-ttu-id="0f47e-711">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-711">D/E</span></span></td>
<td align="left"><span data-ttu-id="0f47e-712">D/E</span><span class="sxs-lookup"><span data-stu-id="0f47e-712">D/E</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0f47e-713">RAW 形式のカメラ</span><span class="sxs-lookup"><span data-stu-id="0f47e-713">Camera RAW</span></span></td>
<td align="left"><span data-ttu-id="0f47e-714">D<sup>3</sup></span><span class="sxs-lookup"><span data-stu-id="0f47e-714">D<sup>3</sup></span></span></td>
<td align="left"><span data-ttu-id="0f47e-715">なし</span><span class="sxs-lookup"><span data-stu-id="0f47e-715">No</span></span></td>
</tr>
</table>

<span data-ttu-id="0f47e-716"><sup>1</sup> BC5 圧縮による BC1 を使用した DDS イメージがサポートされています。</span><span class="sxs-lookup"><span data-stu-id="0f47e-716"><sup>1</sup> DDS images using BC1 through BC5 compression are supported.</span></span>  
<span data-ttu-id="0f47e-717"><sup>2</sup> 非 RAW 形式の埋め込みプレビューを含む DNG イメージがサポートされています。</span><span class="sxs-lookup"><span data-stu-id="0f47e-717"><sup>2</sup> DNG images with a non-RAW embedded preview are supported.</span></span>  
<span data-ttu-id="0f47e-718"><sup>3</sup> 特定のカメラの RAW 形式のみがサポートされています。</span><span class="sxs-lookup"><span data-stu-id="0f47e-718"><sup>3</sup> Only certain camera RAW formats are supported.</span></span>  

<span data-ttu-id="0f47e-719">イメージ コーデックの詳細については、「[ネイティブ WIC コーデック](https://msdn.microsoft.com/library/windows/desktop/gg430027.aspx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0f47e-719">For more information on image codecs, see [Native WIC Codecs](https://msdn.microsoft.com/library/windows/desktop/gg430027.aspx).</span></span>