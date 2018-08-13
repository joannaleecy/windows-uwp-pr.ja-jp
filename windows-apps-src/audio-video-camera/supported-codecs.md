---
author: drewbatgit
ms.assetid: 9347AD7C-3A90-4073-BFF4-9E8237398343
description: この記事では、UWP アプリ用のオーディオとビデオのコーデックおよび形式のサポートを示します。
title: サポートされているコーデック
ms.author: drewbat
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 50d520437f9be9d2e2bc6fe8243c3d34b17ef2d9
ms.sourcegitcommit: 897a111e8fc5d38d483800288ad01c523e924ef4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/13/2018
ms.locfileid: "303676"
---
# <a name="supported-codecs"></a><span data-ttu-id="a1217-104">サポートされているコーデック</span><span class="sxs-lookup"><span data-stu-id="a1217-104">Supported codecs</span></span>

<span data-ttu-id="a1217-105">この記事では、各デバイス ファミリの既定で、UWP アプリで利用可能なオーディオ、ビデオ、イメージのコーデックと形式を示します。</span><span class="sxs-lookup"><span data-stu-id="a1217-105">This article lists the audio, video, and image codec and format availability for UWP apps by default for each device family.</span></span> <span data-ttu-id="a1217-106">これらの表では、指定のデバイス ファミリの Windows 10 のインストールに含まれているコーデックを示していることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="a1217-106">Note that these tables list the codecs that are included with the Windows 10 installation for the specified device family.</span></span> <span data-ttu-id="a1217-107">ユーザーやアプリが、利用可能な追加のコーデックをインストールする場合があります。</span><span class="sxs-lookup"><span data-stu-id="a1217-107">Users and apps can install additional codecs that may be available to use.</span></span> <span data-ttu-id="a1217-108">実行時に、特定のデバイスで現在利用可能なコーデックのセットを照会できます。</span><span class="sxs-lookup"><span data-stu-id="a1217-108">You can query at runtime for the set of codecs that are currently available for a specific device.</span></span> <span data-ttu-id="a1217-109">詳しくは、「[デバイスにインストールされているコーデックの照会](codec-query.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a1217-109">For more information, see [Query for codecs installed on a device](codec-query.md).</span></span>

<span data-ttu-id="a1217-110">以下の表では、"D" はデコーダーのサポートを示し、"E" はエンコーダーのサポートを示します。</span><span class="sxs-lookup"><span data-stu-id="a1217-110">In the tables below "D" indicates decoder support and "E" indicates encoder support.</span></span>

## <a name="audio-codec--format-support"></a><span data-ttu-id="a1217-111">オーディオのコーデックおよび形式のサポート</span><span class="sxs-lookup"><span data-stu-id="a1217-111">Audio codec & format support</span></span>

<span data-ttu-id="a1217-112">次の表は、各デバイス ファミリのオーディオのコーデックと形式のサポートを示しています。</span><span class="sxs-lookup"><span data-stu-id="a1217-112">The following tables show the audio codec and format support for each device family.</span></span>

> [!NOTE] 
> <span data-ttu-id="a1217-113">AMR-NB のサポートが示されている場合、Server SKU ではこのコーデックがサポートされません。</span><span class="sxs-lookup"><span data-stu-id="a1217-113">Where AMR-NB support is indicated, this codec is not supported on Server SKUs.</span></span>

 

### <a name="desktop"></a><span data-ttu-id="a1217-114">デスクトップ</span><span class="sxs-lookup"><span data-stu-id="a1217-114">Desktop</span></span>

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
<th align="left"><span data-ttu-id="a1217-115">コーデック/コンテナー</span><span class="sxs-lookup"><span data-stu-id="a1217-115">Codec/Container</span></span></th>
<th align="left"><span data-ttu-id="a1217-116">MPEG-4</span><span class="sxs-lookup"><span data-stu-id="a1217-116">MPEG-4</span></span></th>
<th align="left"><span data-ttu-id="a1217-117">MPEG-3</span><span class="sxs-lookup"><span data-stu-id="a1217-117">MPEG-3</span></span></th>
<th align="left"><span data-ttu-id="a1217-118">MPEG-2</span><span class="sxs-lookup"><span data-stu-id="a1217-118">MPEG-2</span></span></th>
<th align="left"><span data-ttu-id="a1217-119">ADTS</span><span class="sxs-lookup"><span data-stu-id="a1217-119">ADTS</span></span></th>
<th align="left"><span data-ttu-id="a1217-120">ASF</span><span class="sxs-lookup"><span data-stu-id="a1217-120">ASF</span></span></th>
<th align="left"><span data-ttu-id="a1217-121">RIFF</span><span class="sxs-lookup"><span data-stu-id="a1217-121">RIFF</span></span></th>
<th align="left"><span data-ttu-id="a1217-122">AVI</span><span class="sxs-lookup"><span data-stu-id="a1217-122">AVI</span></span></th>
<th align="left"><span data-ttu-id="a1217-123">AC-3</span><span class="sxs-lookup"><span data-stu-id="a1217-123">AC-3</span></span></th>
<th align="left"><span data-ttu-id="a1217-124">AMR</span><span class="sxs-lookup"><span data-stu-id="a1217-124">AMR</span></span></th>
<th align="left"><span data-ttu-id="a1217-125">3GP</span><span class="sxs-lookup"><span data-stu-id="a1217-125">3GP</span></span></th>
<th align="left"><span data-ttu-id="a1217-126">FLAC</span><span class="sxs-lookup"><span data-stu-id="a1217-126">FLAC</span></span></th>
<th align="left"><span data-ttu-id="a1217-127">WAV</span><span class="sxs-lookup"><span data-stu-id="a1217-127">WAV</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="a1217-128">HE-AAC v1/AAC+</span><span class="sxs-lookup"><span data-stu-id="a1217-128">HE-AAC v1 / AAC+</span></span></td>
<td align="left"><span data-ttu-id="a1217-129">D</span><span class="sxs-lookup"><span data-stu-id="a1217-129">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-130">D</span><span class="sxs-lookup"><span data-stu-id="a1217-130">D</span></span></td>
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
<td align="left"><span data-ttu-id="a1217-131">HE-AAC v2/eAAC+</span><span class="sxs-lookup"><span data-stu-id="a1217-131">HE-AAC v2 / eAAC+</span></span></td>
<td align="left"><span data-ttu-id="a1217-132">D</span><span class="sxs-lookup"><span data-stu-id="a1217-132">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-133">D</span><span class="sxs-lookup"><span data-stu-id="a1217-133">D</span></span></td>
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
<td align="left"><span data-ttu-id="a1217-134">AAC-LC</span><span class="sxs-lookup"><span data-stu-id="a1217-134">AAC-LC</span></span></td>
<td align="left"><span data-ttu-id="a1217-135">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-135">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-136">D</span><span class="sxs-lookup"><span data-stu-id="a1217-136">D</span></span></td>
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
<td align="left"><span data-ttu-id="a1217-137">AC3</span><span class="sxs-lookup"><span data-stu-id="a1217-137">AC3</span></span></td>
<td align="left"><span data-ttu-id="a1217-138">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-138">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-139">D</span><span class="sxs-lookup"><span data-stu-id="a1217-139">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-140">D</span><span class="sxs-lookup"><span data-stu-id="a1217-140">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="a1217-141">EAC3/EC3</span><span class="sxs-lookup"><span data-stu-id="a1217-141">EAC3 / EC3</span></span></td>
<td align="left"><span data-ttu-id="a1217-142">D</span><span class="sxs-lookup"><span data-stu-id="a1217-142">D</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-143">D</span><span class="sxs-lookup"><span data-stu-id="a1217-143">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-144">D</span><span class="sxs-lookup"><span data-stu-id="a1217-144">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="a1217-145">ALAC</span><span class="sxs-lookup"><span data-stu-id="a1217-145">ALAC</span></span></td>
<td align="left"><span data-ttu-id="a1217-146">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-146">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="a1217-147">AMR-NB</span><span class="sxs-lookup"><span data-stu-id="a1217-147">AMR-NB</span></span></td>
<td align="left"><span data-ttu-id="a1217-148">D</span><span class="sxs-lookup"><span data-stu-id="a1217-148">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-149">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-149">D/E</span></span></td>
<td align="left"><span data-ttu-id="a1217-150">D</span><span class="sxs-lookup"><span data-stu-id="a1217-150">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="a1217-151">FLAC</span><span class="sxs-lookup"><span data-stu-id="a1217-151">FLAC</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-152">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-152">D/E</span></span></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="a1217-153">G.711 (A-Law、µ-law)</span><span class="sxs-lookup"><span data-stu-id="a1217-153">G.711 (A-Law, µ-law)</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-154">D</span><span class="sxs-lookup"><span data-stu-id="a1217-154">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="a1217-155">GSM 6.10</span><span class="sxs-lookup"><span data-stu-id="a1217-155">GSM 6.10</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-156">D</span><span class="sxs-lookup"><span data-stu-id="a1217-156">D</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="a1217-157">IMA ADPCM</span><span class="sxs-lookup"><span data-stu-id="a1217-157">IMA ADPCM</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-158">D</span><span class="sxs-lookup"><span data-stu-id="a1217-158">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="a1217-159">LPCM</span><span class="sxs-lookup"><span data-stu-id="a1217-159">LPCM</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-160">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-160">D/E</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="a1217-161">MP3</span><span class="sxs-lookup"><span data-stu-id="a1217-161">MP3</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-162">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-162">D/E</span></span></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="a1217-163">MPEG-1/2</span><span class="sxs-lookup"><span data-stu-id="a1217-163">MPEG-1/2</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-164">D</span><span class="sxs-lookup"><span data-stu-id="a1217-164">D</span></span></td>
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
<td align="left"><span data-ttu-id="a1217-165">MS ADPCM</span><span class="sxs-lookup"><span data-stu-id="a1217-165">MS ADPCM</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-166">D</span><span class="sxs-lookup"><span data-stu-id="a1217-166">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="a1217-167">WMA 1/2/3</span><span class="sxs-lookup"><span data-stu-id="a1217-167">WMA 1/2/3</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-168">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-168">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="a1217-169">WMA Pro</span><span class="sxs-lookup"><span data-stu-id="a1217-169">WMA Pro</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-170">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-170">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="a1217-171">WMA Voice</span><span class="sxs-lookup"><span data-stu-id="a1217-171">WMA Voice</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-172">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-172">D/E</span></span></td>
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

 

### <a name="mobile"></a><span data-ttu-id="a1217-173">モバイル</span><span class="sxs-lookup"><span data-stu-id="a1217-173">Mobile</span></span>

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
<th align="left"><span data-ttu-id="a1217-174">コーデック/コンテナー</span><span class="sxs-lookup"><span data-stu-id="a1217-174">Codec/Container</span></span></th>
<th align="left"><span data-ttu-id="a1217-175">MPEG-4</span><span class="sxs-lookup"><span data-stu-id="a1217-175">MPEG-4</span></span></th>
<th align="left"><span data-ttu-id="a1217-176">MPEG-3</span><span class="sxs-lookup"><span data-stu-id="a1217-176">MPEG-3</span></span></th>
<th align="left"><span data-ttu-id="a1217-177">MPEG-2</span><span class="sxs-lookup"><span data-stu-id="a1217-177">MPEG-2</span></span></th>
<th align="left"><span data-ttu-id="a1217-178">ADTS</span><span class="sxs-lookup"><span data-stu-id="a1217-178">ADTS</span></span></th>
<th align="left"><span data-ttu-id="a1217-179">ASF</span><span class="sxs-lookup"><span data-stu-id="a1217-179">ASF</span></span></th>
<th align="left"><span data-ttu-id="a1217-180">RIFF</span><span class="sxs-lookup"><span data-stu-id="a1217-180">RIFF</span></span></th>
<th align="left"><span data-ttu-id="a1217-181">AVI</span><span class="sxs-lookup"><span data-stu-id="a1217-181">AVI</span></span></th>
<th align="left"><span data-ttu-id="a1217-182">AC-3</span><span class="sxs-lookup"><span data-stu-id="a1217-182">AC-3</span></span></th>
<th align="left"><span data-ttu-id="a1217-183">AMR</span><span class="sxs-lookup"><span data-stu-id="a1217-183">AMR</span></span></th>
<th align="left"><span data-ttu-id="a1217-184">3GP</span><span class="sxs-lookup"><span data-stu-id="a1217-184">3GP</span></span></th>
<th align="left"><span data-ttu-id="a1217-185">FLAC</span><span class="sxs-lookup"><span data-stu-id="a1217-185">FLAC</span></span></th>
<th align="left"><span data-ttu-id="a1217-186">WAV</span><span class="sxs-lookup"><span data-stu-id="a1217-186">WAV</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="a1217-187">HE-AAC v1/AAC+</span><span class="sxs-lookup"><span data-stu-id="a1217-187">HE-AAC v1 / AAC+</span></span></td>
<td align="left"><span data-ttu-id="a1217-188">D</span><span class="sxs-lookup"><span data-stu-id="a1217-188">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-189">D</span><span class="sxs-lookup"><span data-stu-id="a1217-189">D</span></span></td>
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
<td align="left"><span data-ttu-id="a1217-190">HE-AAC v2/eAAC+</span><span class="sxs-lookup"><span data-stu-id="a1217-190">HE-AAC v2 / eAAC+</span></span></td>
<td align="left"><span data-ttu-id="a1217-191">D</span><span class="sxs-lookup"><span data-stu-id="a1217-191">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-192">D</span><span class="sxs-lookup"><span data-stu-id="a1217-192">D</span></span></td>
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
<td align="left"><span data-ttu-id="a1217-193">AAC-LC</span><span class="sxs-lookup"><span data-stu-id="a1217-193">AAC-LC</span></span></td>
<td align="left"><span data-ttu-id="a1217-194">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-194">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-195">D</span><span class="sxs-lookup"><span data-stu-id="a1217-195">D</span></span></td>
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
<td align="left"><span data-ttu-id="a1217-196">AC3</span><span class="sxs-lookup"><span data-stu-id="a1217-196">AC3</span></span></td>
<td align="left"><span data-ttu-id="a1217-197">D (Lumia Icon、830、930、1520 のみ)</span><span class="sxs-lookup"><span data-stu-id="a1217-197">D, Only on Lumia Icon, 830, 930, 1520</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-198">D (Lumia Icon、830、930、1520 のみ)</span><span class="sxs-lookup"><span data-stu-id="a1217-198">D, Only on Lumia Icon, 830, 930, 1520</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-199">D (Lumia Icon、830、930、1520 のみ)</span><span class="sxs-lookup"><span data-stu-id="a1217-199">D, Only on Lumia Icon, 830, 930, 1520</span></span></td>
<td align="left"><span data-ttu-id="a1217-200">D (Lumia Icon、830、930、1520 のみ)</span><span class="sxs-lookup"><span data-stu-id="a1217-200">D, Only on Lumia Icon, 830, 930, 1520</span></span></td>
<td align="left"><span data-ttu-id="a1217-201">D (Lumia Icon、830、930、1520 のみ)</span><span class="sxs-lookup"><span data-stu-id="a1217-201">D, Only on Lumia Icon, 830, 930, 1520</span></span></td>
<td align="left"><span data-ttu-id="a1217-202">D (Lumia Icon、830、930、1520 のみ)</span><span class="sxs-lookup"><span data-stu-id="a1217-202">D, Only on Lumia Icon, 830, 930, 1520</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="a1217-203">EAC3/EC3</span><span class="sxs-lookup"><span data-stu-id="a1217-203">EAC3 / EC3</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="a1217-204">ALAC</span><span class="sxs-lookup"><span data-stu-id="a1217-204">ALAC</span></span></td>
<td align="left"><span data-ttu-id="a1217-205">D</span><span class="sxs-lookup"><span data-stu-id="a1217-205">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="a1217-206">AMR-NB</span><span class="sxs-lookup"><span data-stu-id="a1217-206">AMR-NB</span></span></td>
<td align="left"><span data-ttu-id="a1217-207">D</span><span class="sxs-lookup"><span data-stu-id="a1217-207">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-208">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-208">D/E</span></span></td>
<td align="left"><span data-ttu-id="a1217-209">D</span><span class="sxs-lookup"><span data-stu-id="a1217-209">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="a1217-210">FLAC</span><span class="sxs-lookup"><span data-stu-id="a1217-210">FLAC</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-211">D</span><span class="sxs-lookup"><span data-stu-id="a1217-211">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="a1217-212">G.711 (A-Law、µ-law)</span><span class="sxs-lookup"><span data-stu-id="a1217-212">G.711 (A-Law, µ-law)</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-213">D</span><span class="sxs-lookup"><span data-stu-id="a1217-213">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="a1217-214">GSM 6.10</span><span class="sxs-lookup"><span data-stu-id="a1217-214">GSM 6.10</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-215">D</span><span class="sxs-lookup"><span data-stu-id="a1217-215">D</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="a1217-216">IMA ADPCM</span><span class="sxs-lookup"><span data-stu-id="a1217-216">IMA ADPCM</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-217">D</span><span class="sxs-lookup"><span data-stu-id="a1217-217">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="a1217-218">LPCM</span><span class="sxs-lookup"><span data-stu-id="a1217-218">LPCM</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-219">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-219">D/E</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="a1217-220">MP3</span><span class="sxs-lookup"><span data-stu-id="a1217-220">MP3</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-221">D</span><span class="sxs-lookup"><span data-stu-id="a1217-221">D</span></span></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="a1217-222">MPEG-1/2</span><span class="sxs-lookup"><span data-stu-id="a1217-222">MPEG-1/2</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="a1217-223">MS ADPCM</span><span class="sxs-lookup"><span data-stu-id="a1217-223">MS ADPCM</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-224">D</span><span class="sxs-lookup"><span data-stu-id="a1217-224">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="a1217-225">WMA 1/2/3</span><span class="sxs-lookup"><span data-stu-id="a1217-225">WMA 1/2/3</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-226">D</span><span class="sxs-lookup"><span data-stu-id="a1217-226">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="a1217-227">WMA Pro</span><span class="sxs-lookup"><span data-stu-id="a1217-227">WMA Pro</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-228">D</span><span class="sxs-lookup"><span data-stu-id="a1217-228">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="a1217-229">WMA Voice</span><span class="sxs-lookup"><span data-stu-id="a1217-229">WMA Voice</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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

 

### <a name="iot-core-x86"></a><span data-ttu-id="a1217-230">IoT Core (x86)</span><span class="sxs-lookup"><span data-stu-id="a1217-230">IoT Core (x86)</span></span>

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
<th align="left"><span data-ttu-id="a1217-231">コーデック/コンテナー</span><span class="sxs-lookup"><span data-stu-id="a1217-231">Codec/Container</span></span></th>
<th align="left"><span data-ttu-id="a1217-232">MPEG-4</span><span class="sxs-lookup"><span data-stu-id="a1217-232">MPEG-4</span></span></th>
<th align="left"><span data-ttu-id="a1217-233">MPEG-3</span><span class="sxs-lookup"><span data-stu-id="a1217-233">MPEG-3</span></span></th>
<th align="left"><span data-ttu-id="a1217-234">MPEG-2</span><span class="sxs-lookup"><span data-stu-id="a1217-234">MPEG-2</span></span></th>
<th align="left"><span data-ttu-id="a1217-235">ADTS</span><span class="sxs-lookup"><span data-stu-id="a1217-235">ADTS</span></span></th>
<th align="left"><span data-ttu-id="a1217-236">ASF</span><span class="sxs-lookup"><span data-stu-id="a1217-236">ASF</span></span></th>
<th align="left"><span data-ttu-id="a1217-237">RIFF</span><span class="sxs-lookup"><span data-stu-id="a1217-237">RIFF</span></span></th>
<th align="left"><span data-ttu-id="a1217-238">AVI</span><span class="sxs-lookup"><span data-stu-id="a1217-238">AVI</span></span></th>
<th align="left"><span data-ttu-id="a1217-239">AC-3</span><span class="sxs-lookup"><span data-stu-id="a1217-239">AC-3</span></span></th>
<th align="left"><span data-ttu-id="a1217-240">AMR</span><span class="sxs-lookup"><span data-stu-id="a1217-240">AMR</span></span></th>
<th align="left"><span data-ttu-id="a1217-241">3GP</span><span class="sxs-lookup"><span data-stu-id="a1217-241">3GP</span></span></th>
<th align="left"><span data-ttu-id="a1217-242">FLAC</span><span class="sxs-lookup"><span data-stu-id="a1217-242">FLAC</span></span></th>
<th align="left"><span data-ttu-id="a1217-243">WAV</span><span class="sxs-lookup"><span data-stu-id="a1217-243">WAV</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="a1217-244">HE-AAC v1/AAC+</span><span class="sxs-lookup"><span data-stu-id="a1217-244">HE-AAC v1 / AAC+</span></span></td>
<td align="left"><span data-ttu-id="a1217-245">D</span><span class="sxs-lookup"><span data-stu-id="a1217-245">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-246">D</span><span class="sxs-lookup"><span data-stu-id="a1217-246">D</span></span></td>
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
<td align="left"><span data-ttu-id="a1217-247">HE-AAC v2/eAAC+</span><span class="sxs-lookup"><span data-stu-id="a1217-247">HE-AAC v2 / eAAC+</span></span></td>
<td align="left"><span data-ttu-id="a1217-248">D</span><span class="sxs-lookup"><span data-stu-id="a1217-248">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-249">D</span><span class="sxs-lookup"><span data-stu-id="a1217-249">D</span></span></td>
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
<td align="left"><span data-ttu-id="a1217-250">AAC-LC</span><span class="sxs-lookup"><span data-stu-id="a1217-250">AAC-LC</span></span></td>
<td align="left"><span data-ttu-id="a1217-251">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-251">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-252">D</span><span class="sxs-lookup"><span data-stu-id="a1217-252">D</span></span></td>
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
<td align="left"><span data-ttu-id="a1217-253">AC3</span><span class="sxs-lookup"><span data-stu-id="a1217-253">AC3</span></span></td>
<td align="left"><span data-ttu-id="a1217-254">D</span><span class="sxs-lookup"><span data-stu-id="a1217-254">D</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-255">D</span><span class="sxs-lookup"><span data-stu-id="a1217-255">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-256">D</span><span class="sxs-lookup"><span data-stu-id="a1217-256">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="a1217-257">EAC3/EC3</span><span class="sxs-lookup"><span data-stu-id="a1217-257">EAC3 / EC3</span></span></td>
<td align="left"><span data-ttu-id="a1217-258">D</span><span class="sxs-lookup"><span data-stu-id="a1217-258">D</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-259">D</span><span class="sxs-lookup"><span data-stu-id="a1217-259">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-260">D</span><span class="sxs-lookup"><span data-stu-id="a1217-260">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="a1217-261">ALAC</span><span class="sxs-lookup"><span data-stu-id="a1217-261">ALAC</span></span></td>
<td align="left"><span data-ttu-id="a1217-262">D</span><span class="sxs-lookup"><span data-stu-id="a1217-262">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="a1217-263">AMR-NB</span><span class="sxs-lookup"><span data-stu-id="a1217-263">AMR-NB</span></span></td>
<td align="left"><span data-ttu-id="a1217-264">D</span><span class="sxs-lookup"><span data-stu-id="a1217-264">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-265">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-265">D/E</span></span></td>
<td align="left"><span data-ttu-id="a1217-266">D</span><span class="sxs-lookup"><span data-stu-id="a1217-266">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="a1217-267">FLAC</span><span class="sxs-lookup"><span data-stu-id="a1217-267">FLAC</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-268">D</span><span class="sxs-lookup"><span data-stu-id="a1217-268">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="a1217-269">G.711 (A-Law、µ-law)</span><span class="sxs-lookup"><span data-stu-id="a1217-269">G.711 (A-Law, µ-law)</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-270">D</span><span class="sxs-lookup"><span data-stu-id="a1217-270">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="a1217-271">GSM 6.10</span><span class="sxs-lookup"><span data-stu-id="a1217-271">GSM 6.10</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-272">D</span><span class="sxs-lookup"><span data-stu-id="a1217-272">D</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="a1217-273">IMA ADPCM</span><span class="sxs-lookup"><span data-stu-id="a1217-273">IMA ADPCM</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-274">D</span><span class="sxs-lookup"><span data-stu-id="a1217-274">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="a1217-275">LPCM</span><span class="sxs-lookup"><span data-stu-id="a1217-275">LPCM</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-276">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-276">D/E</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="a1217-277">MP3</span><span class="sxs-lookup"><span data-stu-id="a1217-277">MP3</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-278">D</span><span class="sxs-lookup"><span data-stu-id="a1217-278">D</span></span></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="a1217-279">MPEG-1/2</span><span class="sxs-lookup"><span data-stu-id="a1217-279">MPEG-1/2</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-280">D</span><span class="sxs-lookup"><span data-stu-id="a1217-280">D</span></span></td>
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
<td align="left"><span data-ttu-id="a1217-281">MS ADPCM</span><span class="sxs-lookup"><span data-stu-id="a1217-281">MS ADPCM</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-282">D</span><span class="sxs-lookup"><span data-stu-id="a1217-282">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="a1217-283">WMA 1/2/3</span><span class="sxs-lookup"><span data-stu-id="a1217-283">WMA 1/2/3</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-284">D</span><span class="sxs-lookup"><span data-stu-id="a1217-284">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="a1217-285">WMA Pro</span><span class="sxs-lookup"><span data-stu-id="a1217-285">WMA Pro</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-286">D</span><span class="sxs-lookup"><span data-stu-id="a1217-286">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="a1217-287">WMA Voice</span><span class="sxs-lookup"><span data-stu-id="a1217-287">WMA Voice</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-288">D</span><span class="sxs-lookup"><span data-stu-id="a1217-288">D</span></span></td>
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

 

### <a name="iot-core-arm"></a><span data-ttu-id="a1217-289">IoT Core (ARM)</span><span class="sxs-lookup"><span data-stu-id="a1217-289">IoT Core (ARM)</span></span>

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
<th align="left"><span data-ttu-id="a1217-290">コーデック/コンテナー</span><span class="sxs-lookup"><span data-stu-id="a1217-290">Codec/Container</span></span></th>
<th align="left"><span data-ttu-id="a1217-291">MPEG-4</span><span class="sxs-lookup"><span data-stu-id="a1217-291">MPEG-4</span></span></th>
<th align="left"><span data-ttu-id="a1217-292">MPEG-3</span><span class="sxs-lookup"><span data-stu-id="a1217-292">MPEG-3</span></span></th>
<th align="left"><span data-ttu-id="a1217-293">MPEG-2</span><span class="sxs-lookup"><span data-stu-id="a1217-293">MPEG-2</span></span></th>
<th align="left"><span data-ttu-id="a1217-294">ADTS</span><span class="sxs-lookup"><span data-stu-id="a1217-294">ADTS</span></span></th>
<th align="left"><span data-ttu-id="a1217-295">ASF</span><span class="sxs-lookup"><span data-stu-id="a1217-295">ASF</span></span></th>
<th align="left"><span data-ttu-id="a1217-296">RIFF</span><span class="sxs-lookup"><span data-stu-id="a1217-296">RIFF</span></span></th>
<th align="left"><span data-ttu-id="a1217-297">AVI</span><span class="sxs-lookup"><span data-stu-id="a1217-297">AVI</span></span></th>
<th align="left"><span data-ttu-id="a1217-298">AC-3</span><span class="sxs-lookup"><span data-stu-id="a1217-298">AC-3</span></span></th>
<th align="left"><span data-ttu-id="a1217-299">AMR</span><span class="sxs-lookup"><span data-stu-id="a1217-299">AMR</span></span></th>
<th align="left"><span data-ttu-id="a1217-300">3GP</span><span class="sxs-lookup"><span data-stu-id="a1217-300">3GP</span></span></th>
<th align="left"><span data-ttu-id="a1217-301">FLAC</span><span class="sxs-lookup"><span data-stu-id="a1217-301">FLAC</span></span></th>
<th align="left"><span data-ttu-id="a1217-302">WAV</span><span class="sxs-lookup"><span data-stu-id="a1217-302">WAV</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="a1217-303">HE-AAC v1/AAC+</span><span class="sxs-lookup"><span data-stu-id="a1217-303">HE-AAC v1 / AAC+</span></span></td>
<td align="left"><span data-ttu-id="a1217-304">D</span><span class="sxs-lookup"><span data-stu-id="a1217-304">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-305">D</span><span class="sxs-lookup"><span data-stu-id="a1217-305">D</span></span></td>
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
<td align="left"><span data-ttu-id="a1217-306">HE-AAC v2/eAAC+</span><span class="sxs-lookup"><span data-stu-id="a1217-306">HE-AAC v2 / eAAC+</span></span></td>
<td align="left"><span data-ttu-id="a1217-307">D</span><span class="sxs-lookup"><span data-stu-id="a1217-307">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-308">D</span><span class="sxs-lookup"><span data-stu-id="a1217-308">D</span></span></td>
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
<td align="left"><span data-ttu-id="a1217-309">AAC-LC</span><span class="sxs-lookup"><span data-stu-id="a1217-309">AAC-LC</span></span></td>
<td align="left"><span data-ttu-id="a1217-310">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-310">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-311">D</span><span class="sxs-lookup"><span data-stu-id="a1217-311">D</span></span></td>
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
<td align="left"><span data-ttu-id="a1217-312">AC3</span><span class="sxs-lookup"><span data-stu-id="a1217-312">AC3</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="a1217-313">EAC3/EC3</span><span class="sxs-lookup"><span data-stu-id="a1217-313">EAC3 / EC3</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="a1217-314">ALAC</span><span class="sxs-lookup"><span data-stu-id="a1217-314">ALAC</span></span></td>
<td align="left"><span data-ttu-id="a1217-315">D</span><span class="sxs-lookup"><span data-stu-id="a1217-315">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="a1217-316">AMR-NB</span><span class="sxs-lookup"><span data-stu-id="a1217-316">AMR-NB</span></span></td>
<td align="left"><span data-ttu-id="a1217-317">D</span><span class="sxs-lookup"><span data-stu-id="a1217-317">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-318">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-318">D/E</span></span></td>
<td align="left"><span data-ttu-id="a1217-319">D</span><span class="sxs-lookup"><span data-stu-id="a1217-319">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="a1217-320">FLAC</span><span class="sxs-lookup"><span data-stu-id="a1217-320">FLAC</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-321">D</span><span class="sxs-lookup"><span data-stu-id="a1217-321">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="a1217-322">G.711 (A-Law、µ-law)</span><span class="sxs-lookup"><span data-stu-id="a1217-322">G.711 (A-Law, µ-law)</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-323">D</span><span class="sxs-lookup"><span data-stu-id="a1217-323">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="a1217-324">GSM 6.10</span><span class="sxs-lookup"><span data-stu-id="a1217-324">GSM 6.10</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-325">D</span><span class="sxs-lookup"><span data-stu-id="a1217-325">D</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="a1217-326">IMA ADPCM</span><span class="sxs-lookup"><span data-stu-id="a1217-326">IMA ADPCM</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-327">D</span><span class="sxs-lookup"><span data-stu-id="a1217-327">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="a1217-328">LPCM</span><span class="sxs-lookup"><span data-stu-id="a1217-328">LPCM</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-329">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-329">D/E</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="a1217-330">MP3</span><span class="sxs-lookup"><span data-stu-id="a1217-330">MP3</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-331">D</span><span class="sxs-lookup"><span data-stu-id="a1217-331">D</span></span></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="a1217-332">MPEG-1/2</span><span class="sxs-lookup"><span data-stu-id="a1217-332">MPEG-1/2</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-333">D</span><span class="sxs-lookup"><span data-stu-id="a1217-333">D</span></span></td>
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
<td align="left"><span data-ttu-id="a1217-334">MS ADPCM</span><span class="sxs-lookup"><span data-stu-id="a1217-334">MS ADPCM</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-335">D</span><span class="sxs-lookup"><span data-stu-id="a1217-335">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="a1217-336">WMA 1/2/3</span><span class="sxs-lookup"><span data-stu-id="a1217-336">WMA 1/2/3</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-337">D</span><span class="sxs-lookup"><span data-stu-id="a1217-337">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="a1217-338">WMA Pro</span><span class="sxs-lookup"><span data-stu-id="a1217-338">WMA Pro</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-339">D</span><span class="sxs-lookup"><span data-stu-id="a1217-339">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="a1217-340">WMA Voice</span><span class="sxs-lookup"><span data-stu-id="a1217-340">WMA Voice</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-341">D</span><span class="sxs-lookup"><span data-stu-id="a1217-341">D</span></span></td>
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

 

### <a name="xbox"></a><span data-ttu-id="a1217-342">Xbox</span><span class="sxs-lookup"><span data-stu-id="a1217-342">XBox</span></span>

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
<th align="left"><span data-ttu-id="a1217-343">コーデック/コンテナー</span><span class="sxs-lookup"><span data-stu-id="a1217-343">Codec/Container</span></span></th>
<th align="left"><span data-ttu-id="a1217-344">MPEG-4</span><span class="sxs-lookup"><span data-stu-id="a1217-344">MPEG-4</span></span></th>
<th align="left"><span data-ttu-id="a1217-345">MPEG-3</span><span class="sxs-lookup"><span data-stu-id="a1217-345">MPEG-3</span></span></th>
<th align="left"><span data-ttu-id="a1217-346">MPEG-2</span><span class="sxs-lookup"><span data-stu-id="a1217-346">MPEG-2</span></span></th>
<th align="left"><span data-ttu-id="a1217-347">ADTS</span><span class="sxs-lookup"><span data-stu-id="a1217-347">ADTS</span></span></th>
<th align="left"><span data-ttu-id="a1217-348">ASF</span><span class="sxs-lookup"><span data-stu-id="a1217-348">ASF</span></span></th>
<th align="left"><span data-ttu-id="a1217-349">RIFF</span><span class="sxs-lookup"><span data-stu-id="a1217-349">RIFF</span></span></th>
<th align="left"><span data-ttu-id="a1217-350">AVI</span><span class="sxs-lookup"><span data-stu-id="a1217-350">AVI</span></span></th>
<th align="left"><span data-ttu-id="a1217-351">AC-3</span><span class="sxs-lookup"><span data-stu-id="a1217-351">AC-3</span></span></th>
<th align="left"><span data-ttu-id="a1217-352">AMR</span><span class="sxs-lookup"><span data-stu-id="a1217-352">AMR</span></span></th>
<th align="left"><span data-ttu-id="a1217-353">3GP</span><span class="sxs-lookup"><span data-stu-id="a1217-353">3GP</span></span></th>
<th align="left"><span data-ttu-id="a1217-354">FLAC</span><span class="sxs-lookup"><span data-stu-id="a1217-354">FLAC</span></span></th>
<th align="left"><span data-ttu-id="a1217-355">WAV</span><span class="sxs-lookup"><span data-stu-id="a1217-355">WAV</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="a1217-356">HE-AAC v1/AAC+</span><span class="sxs-lookup"><span data-stu-id="a1217-356">HE-AAC v1 / AAC+</span></span></td>
<td align="left"><span data-ttu-id="a1217-357">D</span><span class="sxs-lookup"><span data-stu-id="a1217-357">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-358">D</span><span class="sxs-lookup"><span data-stu-id="a1217-358">D</span></span></td>
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
<td align="left"><span data-ttu-id="a1217-359">HE-AAC v2/eAAC+</span><span class="sxs-lookup"><span data-stu-id="a1217-359">HE-AAC v2 / eAAC+</span></span></td>
<td align="left"><span data-ttu-id="a1217-360">D</span><span class="sxs-lookup"><span data-stu-id="a1217-360">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-361">D</span><span class="sxs-lookup"><span data-stu-id="a1217-361">D</span></span></td>
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
<td align="left"><span data-ttu-id="a1217-362">AAC-LC</span><span class="sxs-lookup"><span data-stu-id="a1217-362">AAC-LC</span></span></td>
<td align="left"><span data-ttu-id="a1217-363">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-363">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-364">D</span><span class="sxs-lookup"><span data-stu-id="a1217-364">D</span></span></td>
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
<td align="left"><span data-ttu-id="a1217-365">AC3</span><span class="sxs-lookup"><span data-stu-id="a1217-365">AC3</span></span></td>
<td align="left"><span data-ttu-id="a1217-366">D</span><span class="sxs-lookup"><span data-stu-id="a1217-366">D</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-367">D</span><span class="sxs-lookup"><span data-stu-id="a1217-367">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-368">D</span><span class="sxs-lookup"><span data-stu-id="a1217-368">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="a1217-369">EAC3/EC3</span><span class="sxs-lookup"><span data-stu-id="a1217-369">EAC3 / EC3</span></span></td>
<td align="left"><span data-ttu-id="a1217-370">D</span><span class="sxs-lookup"><span data-stu-id="a1217-370">D</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-371">D</span><span class="sxs-lookup"><span data-stu-id="a1217-371">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-372">D</span><span class="sxs-lookup"><span data-stu-id="a1217-372">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="a1217-373">ALAC</span><span class="sxs-lookup"><span data-stu-id="a1217-373">ALAC</span></span></td>
<td align="left"><span data-ttu-id="a1217-374">D</span><span class="sxs-lookup"><span data-stu-id="a1217-374">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="a1217-375">AMR-NB</span><span class="sxs-lookup"><span data-stu-id="a1217-375">AMR-NB</span></span></td>
<td align="left"><span data-ttu-id="a1217-376">D</span><span class="sxs-lookup"><span data-stu-id="a1217-376">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-377">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-377">D/E</span></span></td>
<td align="left"><span data-ttu-id="a1217-378">D</span><span class="sxs-lookup"><span data-stu-id="a1217-378">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="a1217-379">FLAC</span><span class="sxs-lookup"><span data-stu-id="a1217-379">FLAC</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-380">D</span><span class="sxs-lookup"><span data-stu-id="a1217-380">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="a1217-381">G.711 (A-Law、µ-law)</span><span class="sxs-lookup"><span data-stu-id="a1217-381">G.711 (A-Law, µ-law)</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-382">D</span><span class="sxs-lookup"><span data-stu-id="a1217-382">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="a1217-383">GSM 6.10</span><span class="sxs-lookup"><span data-stu-id="a1217-383">GSM 6.10</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-384">D</span><span class="sxs-lookup"><span data-stu-id="a1217-384">D</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="a1217-385">IMA ADPCM</span><span class="sxs-lookup"><span data-stu-id="a1217-385">IMA ADPCM</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-386">D</span><span class="sxs-lookup"><span data-stu-id="a1217-386">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="a1217-387">LPCM</span><span class="sxs-lookup"><span data-stu-id="a1217-387">LPCM</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-388">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-388">D/E</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="a1217-389">MP3</span><span class="sxs-lookup"><span data-stu-id="a1217-389">MP3</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-390">D</span><span class="sxs-lookup"><span data-stu-id="a1217-390">D</span></span></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="a1217-391">MPEG-1/2</span><span class="sxs-lookup"><span data-stu-id="a1217-391">MPEG-1/2</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-392">D</span><span class="sxs-lookup"><span data-stu-id="a1217-392">D</span></span></td>
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
<td align="left"><span data-ttu-id="a1217-393">MS ADPCM</span><span class="sxs-lookup"><span data-stu-id="a1217-393">MS ADPCM</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-394">D</span><span class="sxs-lookup"><span data-stu-id="a1217-394">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="a1217-395">WMA 1/2/3</span><span class="sxs-lookup"><span data-stu-id="a1217-395">WMA 1/2/3</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-396">D</span><span class="sxs-lookup"><span data-stu-id="a1217-396">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="a1217-397">WMA Pro</span><span class="sxs-lookup"><span data-stu-id="a1217-397">WMA Pro</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-398">D</span><span class="sxs-lookup"><span data-stu-id="a1217-398">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="a1217-399">WMA Voice</span><span class="sxs-lookup"><span data-stu-id="a1217-399">WMA Voice</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-400">D</span><span class="sxs-lookup"><span data-stu-id="a1217-400">D</span></span></td>
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

 

## <a name="video-codec--format-support"></a><span data-ttu-id="a1217-401">ビデオのコーデックおよび形式のサポート</span><span class="sxs-lookup"><span data-stu-id="a1217-401">Video codec & format support</span></span>

<span data-ttu-id="a1217-402">次の表は、各デバイス ファミリのビデオのコーデックと形式のサポートを示しています。</span><span class="sxs-lookup"><span data-stu-id="a1217-402">The following tables show the video codec and format support for each device family.</span></span>

> [!NOTE] 
> <span data-ttu-id="a1217-403">H.265 のサポートが示されている場合、必ずしもデバイス ファミリ内のすべてのデバイスでサポートされるわけではありません。</span><span class="sxs-lookup"><span data-stu-id="a1217-403">Where H.265 support is indicated, it is not necessarily supported by all devices within the device family.</span></span>
> <span data-ttu-id="a1217-404">MPEG-2/MPEG-1 のサポートが示されている場合、オプションの Microsoft DVD ユニバーサル Windows アプリのインストールでのみサポートされます。</span><span class="sxs-lookup"><span data-stu-id="a1217-404">Where MPEG-2/MPEG-1 support is indicated, it is only supported with the installation of the optional Microsoft DVD Universal Windows app.</span></span>

 

### <a name="desktop"></a><span data-ttu-id="a1217-405">デスクトップ</span><span class="sxs-lookup"><span data-stu-id="a1217-405">Desktop</span></span>

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
<th align="left"><span data-ttu-id="a1217-406">コーデック/コンテナー</span><span class="sxs-lookup"><span data-stu-id="a1217-406">Codec/Container</span></span></th>
<th align="left"><span data-ttu-id="a1217-407">FOURCC</span><span class="sxs-lookup"><span data-stu-id="a1217-407">FOURCC</span></span></th>
<th align="left"><span data-ttu-id="a1217-408">fMP4</span><span class="sxs-lookup"><span data-stu-id="a1217-408">fMP4</span></span></th>
<th align="left"><span data-ttu-id="a1217-409">MPEG-4</span><span class="sxs-lookup"><span data-stu-id="a1217-409">MPEG-4</span></span></th>
<th align="left"><span data-ttu-id="a1217-410">MPEG-2 PS</span><span class="sxs-lookup"><span data-stu-id="a1217-410">MPEG-2 PS</span></span></th>
<th align="left"><span data-ttu-id="a1217-411">MPEG-2 TS</span><span class="sxs-lookup"><span data-stu-id="a1217-411">MPEG-2 TS</span></span></th>
<th align="left"><span data-ttu-id="a1217-412">MPEG-1</span><span class="sxs-lookup"><span data-stu-id="a1217-412">MPEG-1</span></span></th>
<th align="left"><span data-ttu-id="a1217-413">3GPP</span><span class="sxs-lookup"><span data-stu-id="a1217-413">3GPP</span></span></th>
<th align="left"><span data-ttu-id="a1217-414">3GPP2</span><span class="sxs-lookup"><span data-stu-id="a1217-414">3GPP2</span></span></th>
<th align="left"><span data-ttu-id="a1217-415">AVCHD</span><span class="sxs-lookup"><span data-stu-id="a1217-415">AVCHD</span></span></th>
<th align="left"><span data-ttu-id="a1217-416">ASF</span><span class="sxs-lookup"><span data-stu-id="a1217-416">ASF</span></span></th>
<th align="left"><span data-ttu-id="a1217-417">AVI</span><span class="sxs-lookup"><span data-stu-id="a1217-417">AVI</span></span></th>
<th align="left"><span data-ttu-id="a1217-418">MKV</span><span class="sxs-lookup"><span data-stu-id="a1217-418">MKV</span></span></th>
<th align="left"><span data-ttu-id="a1217-419">DV</span><span class="sxs-lookup"><span data-stu-id="a1217-419">DV</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="a1217-420">MPEG-1</span><span class="sxs-lookup"><span data-stu-id="a1217-420">MPEG-1</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-421">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-421">D/E</span></span></td>
<td align="left"><span data-ttu-id="a1217-422">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-422">D/E</span></span></td>
<td align="left"><span data-ttu-id="a1217-423">D</span><span class="sxs-lookup"><span data-stu-id="a1217-423">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-424">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-424">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-425">D</span><span class="sxs-lookup"><span data-stu-id="a1217-425">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="a1217-426">MPEG-2</span><span class="sxs-lookup"><span data-stu-id="a1217-426">MPEG-2</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-427">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-427">D/E</span></span></td>
<td align="left"><span data-ttu-id="a1217-428">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-428">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-429">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-429">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-430">D</span><span class="sxs-lookup"><span data-stu-id="a1217-430">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="a1217-431">MPEG-4 (Part 2)</span><span class="sxs-lookup"><span data-stu-id="a1217-431">MPEG-4 (Part 2)</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-432">D</span><span class="sxs-lookup"><span data-stu-id="a1217-432">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-433">D</span><span class="sxs-lookup"><span data-stu-id="a1217-433">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-434">D</span><span class="sxs-lookup"><span data-stu-id="a1217-434">D</span></span></td>
<td align="left"><span data-ttu-id="a1217-435">D</span><span class="sxs-lookup"><span data-stu-id="a1217-435">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="a1217-436">H.265</span><span class="sxs-lookup"><span data-stu-id="a1217-436">H.265</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-437">D</span><span class="sxs-lookup"><span data-stu-id="a1217-437">D</span></span></td>
<td align="left"><span data-ttu-id="a1217-438">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-438">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-439">D</span><span class="sxs-lookup"><span data-stu-id="a1217-439">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="a1217-440">H.264</span><span class="sxs-lookup"><span data-stu-id="a1217-440">H.264</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-441">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-441">D/E</span></span></td>
<td align="left"><span data-ttu-id="a1217-442">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-442">D/E</span></span></td>
<td align="left"><span data-ttu-id="a1217-443">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-443">D/E</span></span></td>
<td align="left"><span data-ttu-id="a1217-444">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-444">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-445">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-445">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-446">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-446">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-447">D</span><span class="sxs-lookup"><span data-stu-id="a1217-447">D</span></span></td>
<td align="left"><span data-ttu-id="a1217-448">D</span><span class="sxs-lookup"><span data-stu-id="a1217-448">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="a1217-449">H.263</span><span class="sxs-lookup"><span data-stu-id="a1217-449">H.263</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-450">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-450">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-451">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-451">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-452">D</span><span class="sxs-lookup"><span data-stu-id="a1217-452">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="a1217-453">VC-1</span><span class="sxs-lookup"><span data-stu-id="a1217-453">VC-1</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-454">D</span><span class="sxs-lookup"><span data-stu-id="a1217-454">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-455">D</span><span class="sxs-lookup"><span data-stu-id="a1217-455">D</span></span></td>
<td align="left"><span data-ttu-id="a1217-456">D</span><span class="sxs-lookup"><span data-stu-id="a1217-456">D</span></span></td>
<td align="left"><span data-ttu-id="a1217-457">D</span><span class="sxs-lookup"><span data-stu-id="a1217-457">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="a1217-458">WMV7/8/9</span><span class="sxs-lookup"><span data-stu-id="a1217-458">WMV7/8/9</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-459">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-459">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-460">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-460">D/E</span></span></td>
<td align="left"><span data-ttu-id="a1217-461">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-461">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="a1217-462">WMV9 Screen</span><span class="sxs-lookup"><span data-stu-id="a1217-462">WMV9 Screen</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-463">D</span><span class="sxs-lookup"><span data-stu-id="a1217-463">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-464">D</span><span class="sxs-lookup"><span data-stu-id="a1217-464">D</span></span></td>
<td align="left"><span data-ttu-id="a1217-465">D</span><span class="sxs-lookup"><span data-stu-id="a1217-465">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="a1217-466">DV</span><span class="sxs-lookup"><span data-stu-id="a1217-466">DV</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-467">D</span><span class="sxs-lookup"><span data-stu-id="a1217-467">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-468">D</span><span class="sxs-lookup"><span data-stu-id="a1217-468">D</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-469">D</span><span class="sxs-lookup"><span data-stu-id="a1217-469">D</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="a1217-470">モーション JPEG</span><span class="sxs-lookup"><span data-stu-id="a1217-470">Motion JPEG</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-471">D</span><span class="sxs-lookup"><span data-stu-id="a1217-471">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-472">D</span><span class="sxs-lookup"><span data-stu-id="a1217-472">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
</tbody>
</table>

 

### <a name="mobile"></a><span data-ttu-id="a1217-473">モバイル</span><span class="sxs-lookup"><span data-stu-id="a1217-473">Mobile</span></span>

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
<th align="left"><span data-ttu-id="a1217-474">コーデック/コンテナー</span><span class="sxs-lookup"><span data-stu-id="a1217-474">Codec/Container</span></span></th>
<th align="left"><span data-ttu-id="a1217-475">FOURCC</span><span class="sxs-lookup"><span data-stu-id="a1217-475">FOURCC</span></span></th>
<th align="left"><span data-ttu-id="a1217-476">fMP4</span><span class="sxs-lookup"><span data-stu-id="a1217-476">fMP4</span></span></th>
<th align="left"><span data-ttu-id="a1217-477">MPEG-4</span><span class="sxs-lookup"><span data-stu-id="a1217-477">MPEG-4</span></span></th>
<th align="left"><span data-ttu-id="a1217-478">MPEG-2 PS</span><span class="sxs-lookup"><span data-stu-id="a1217-478">MPEG-2 PS</span></span></th>
<th align="left"><span data-ttu-id="a1217-479">MPEG-2 TS</span><span class="sxs-lookup"><span data-stu-id="a1217-479">MPEG-2 TS</span></span></th>
<th align="left"><span data-ttu-id="a1217-480">MPEG-1</span><span class="sxs-lookup"><span data-stu-id="a1217-480">MPEG-1</span></span></th>
<th align="left"><span data-ttu-id="a1217-481">3GPP</span><span class="sxs-lookup"><span data-stu-id="a1217-481">3GPP</span></span></th>
<th align="left"><span data-ttu-id="a1217-482">3GPP2</span><span class="sxs-lookup"><span data-stu-id="a1217-482">3GPP2</span></span></th>
<th align="left"><span data-ttu-id="a1217-483">AVCHD</span><span class="sxs-lookup"><span data-stu-id="a1217-483">AVCHD</span></span></th>
<th align="left"><span data-ttu-id="a1217-484">ASF</span><span class="sxs-lookup"><span data-stu-id="a1217-484">ASF</span></span></th>
<th align="left"><span data-ttu-id="a1217-485">AVI</span><span class="sxs-lookup"><span data-stu-id="a1217-485">AVI</span></span></th>
<th align="left"><span data-ttu-id="a1217-486">MKV</span><span class="sxs-lookup"><span data-stu-id="a1217-486">MKV</span></span></th>
<th align="left"><span data-ttu-id="a1217-487">DV</span><span class="sxs-lookup"><span data-stu-id="a1217-487">DV</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="a1217-488">MPEG-1</span><span class="sxs-lookup"><span data-stu-id="a1217-488">MPEG-1</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="a1217-489">MPEG-2</span><span class="sxs-lookup"><span data-stu-id="a1217-489">MPEG-2</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="a1217-490">MPEG-4 (Part 2)</span><span class="sxs-lookup"><span data-stu-id="a1217-490">MPEG-4 (Part 2)</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-491">D</span><span class="sxs-lookup"><span data-stu-id="a1217-491">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-492">D</span><span class="sxs-lookup"><span data-stu-id="a1217-492">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-493">D</span><span class="sxs-lookup"><span data-stu-id="a1217-493">D</span></span></td>
<td align="left"><span data-ttu-id="a1217-494">D</span><span class="sxs-lookup"><span data-stu-id="a1217-494">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="a1217-495">H.265</span><span class="sxs-lookup"><span data-stu-id="a1217-495">H.265</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-496">D</span><span class="sxs-lookup"><span data-stu-id="a1217-496">D</span></span></td>
<td align="left"><span data-ttu-id="a1217-497">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-497">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-498">D</span><span class="sxs-lookup"><span data-stu-id="a1217-498">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="a1217-499">H.264</span><span class="sxs-lookup"><span data-stu-id="a1217-499">H.264</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-500">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-500">D/E</span></span></td>
<td align="left"><span data-ttu-id="a1217-501">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-501">D/E</span></span></td>
<td align="left"><span data-ttu-id="a1217-502">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-502">D/E</span></span></td>
<td align="left"><span data-ttu-id="a1217-503">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-503">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-504">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-504">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-505">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-505">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-506">D</span><span class="sxs-lookup"><span data-stu-id="a1217-506">D</span></span></td>
<td align="left"><span data-ttu-id="a1217-507">D</span><span class="sxs-lookup"><span data-stu-id="a1217-507">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="a1217-508">H.263</span><span class="sxs-lookup"><span data-stu-id="a1217-508">H.263</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-509">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-509">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-510">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-510">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-511">D</span><span class="sxs-lookup"><span data-stu-id="a1217-511">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="a1217-512">VC-1</span><span class="sxs-lookup"><span data-stu-id="a1217-512">VC-1</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-513">D</span><span class="sxs-lookup"><span data-stu-id="a1217-513">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-514">D</span><span class="sxs-lookup"><span data-stu-id="a1217-514">D</span></span></td>
<td align="left"><span data-ttu-id="a1217-515">D</span><span class="sxs-lookup"><span data-stu-id="a1217-515">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="a1217-516">WMV7/8/9</span><span class="sxs-lookup"><span data-stu-id="a1217-516">WMV7/8/9</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="a1217-517">WMV9 Screen</span><span class="sxs-lookup"><span data-stu-id="a1217-517">WMV9 Screen</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="a1217-518">DV</span><span class="sxs-lookup"><span data-stu-id="a1217-518">DV</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="a1217-519">モーション JPEG</span><span class="sxs-lookup"><span data-stu-id="a1217-519">Motion JPEG</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-520">D</span><span class="sxs-lookup"><span data-stu-id="a1217-520">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-521">D</span><span class="sxs-lookup"><span data-stu-id="a1217-521">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
</tbody>
</table>

 

### <a name="iot-core-x86"></a><span data-ttu-id="a1217-522">IoT Core (x86)</span><span class="sxs-lookup"><span data-stu-id="a1217-522">IoT Core (x86)</span></span>

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
<th align="left"><span data-ttu-id="a1217-523">コーデック/コンテナー</span><span class="sxs-lookup"><span data-stu-id="a1217-523">Codec/Container</span></span></th>
<th align="left"><span data-ttu-id="a1217-524">FOURCC</span><span class="sxs-lookup"><span data-stu-id="a1217-524">FOURCC</span></span></th>
<th align="left"><span data-ttu-id="a1217-525">fMP4</span><span class="sxs-lookup"><span data-stu-id="a1217-525">fMP4</span></span></th>
<th align="left"><span data-ttu-id="a1217-526">MPEG-4</span><span class="sxs-lookup"><span data-stu-id="a1217-526">MPEG-4</span></span></th>
<th align="left"><span data-ttu-id="a1217-527">MPEG-2 PS</span><span class="sxs-lookup"><span data-stu-id="a1217-527">MPEG-2 PS</span></span></th>
<th align="left"><span data-ttu-id="a1217-528">MPEG-2 TS</span><span class="sxs-lookup"><span data-stu-id="a1217-528">MPEG-2 TS</span></span></th>
<th align="left"><span data-ttu-id="a1217-529">MPEG-1</span><span class="sxs-lookup"><span data-stu-id="a1217-529">MPEG-1</span></span></th>
<th align="left"><span data-ttu-id="a1217-530">3GPP</span><span class="sxs-lookup"><span data-stu-id="a1217-530">3GPP</span></span></th>
<th align="left"><span data-ttu-id="a1217-531">3GPP2</span><span class="sxs-lookup"><span data-stu-id="a1217-531">3GPP2</span></span></th>
<th align="left"><span data-ttu-id="a1217-532">AVCHD</span><span class="sxs-lookup"><span data-stu-id="a1217-532">AVCHD</span></span></th>
<th align="left"><span data-ttu-id="a1217-533">ASF</span><span class="sxs-lookup"><span data-stu-id="a1217-533">ASF</span></span></th>
<th align="left"><span data-ttu-id="a1217-534">AVI</span><span class="sxs-lookup"><span data-stu-id="a1217-534">AVI</span></span></th>
<th align="left"><span data-ttu-id="a1217-535">MKV</span><span class="sxs-lookup"><span data-stu-id="a1217-535">MKV</span></span></th>
<th align="left"><span data-ttu-id="a1217-536">DV</span><span class="sxs-lookup"><span data-stu-id="a1217-536">DV</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="a1217-537">MPEG-1</span><span class="sxs-lookup"><span data-stu-id="a1217-537">MPEG-1</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="a1217-538">MPEG-2</span><span class="sxs-lookup"><span data-stu-id="a1217-538">MPEG-2</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="a1217-539">MPEG-4 (Part 2)</span><span class="sxs-lookup"><span data-stu-id="a1217-539">MPEG-4 (Part 2)</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-540">D</span><span class="sxs-lookup"><span data-stu-id="a1217-540">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-541">D</span><span class="sxs-lookup"><span data-stu-id="a1217-541">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-542">D</span><span class="sxs-lookup"><span data-stu-id="a1217-542">D</span></span></td>
<td align="left"><span data-ttu-id="a1217-543">D</span><span class="sxs-lookup"><span data-stu-id="a1217-543">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="a1217-544">H.265</span><span class="sxs-lookup"><span data-stu-id="a1217-544">H.265</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-545">D</span><span class="sxs-lookup"><span data-stu-id="a1217-545">D</span></span></td>
<td align="left"><span data-ttu-id="a1217-546">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-546">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-547">D</span><span class="sxs-lookup"><span data-stu-id="a1217-547">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="a1217-548">H.264</span><span class="sxs-lookup"><span data-stu-id="a1217-548">H.264</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-549">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-549">D/E</span></span></td>
<td align="left"><span data-ttu-id="a1217-550">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-550">D/E</span></span></td>
<td align="left"><span data-ttu-id="a1217-551">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-551">D/E</span></span></td>
<td align="left"><span data-ttu-id="a1217-552">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-552">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-553">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-553">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-554">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-554">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-555">D</span><span class="sxs-lookup"><span data-stu-id="a1217-555">D</span></span></td>
<td align="left"><span data-ttu-id="a1217-556">D</span><span class="sxs-lookup"><span data-stu-id="a1217-556">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="a1217-557">H.263</span><span class="sxs-lookup"><span data-stu-id="a1217-557">H.263</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-558">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-558">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-559">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-559">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-560">D</span><span class="sxs-lookup"><span data-stu-id="a1217-560">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="a1217-561">VC-1</span><span class="sxs-lookup"><span data-stu-id="a1217-561">VC-1</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-562">D</span><span class="sxs-lookup"><span data-stu-id="a1217-562">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-563">D</span><span class="sxs-lookup"><span data-stu-id="a1217-563">D</span></span></td>
<td align="left"><span data-ttu-id="a1217-564">D</span><span class="sxs-lookup"><span data-stu-id="a1217-564">D</span></span></td>
<td align="left"><span data-ttu-id="a1217-565">D</span><span class="sxs-lookup"><span data-stu-id="a1217-565">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="a1217-566">WMV7/8/9</span><span class="sxs-lookup"><span data-stu-id="a1217-566">WMV7/8/9</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-567">D</span><span class="sxs-lookup"><span data-stu-id="a1217-567">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-568">D</span><span class="sxs-lookup"><span data-stu-id="a1217-568">D</span></span></td>
<td align="left"><span data-ttu-id="a1217-569">D</span><span class="sxs-lookup"><span data-stu-id="a1217-569">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="a1217-570">WMV9 Screen</span><span class="sxs-lookup"><span data-stu-id="a1217-570">WMV9 Screen</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-571">D</span><span class="sxs-lookup"><span data-stu-id="a1217-571">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-572">D</span><span class="sxs-lookup"><span data-stu-id="a1217-572">D</span></span></td>
<td align="left"><span data-ttu-id="a1217-573">D</span><span class="sxs-lookup"><span data-stu-id="a1217-573">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="a1217-574">DV</span><span class="sxs-lookup"><span data-stu-id="a1217-574">DV</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="a1217-575">モーション JPEG</span><span class="sxs-lookup"><span data-stu-id="a1217-575">Motion JPEG</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-576">D</span><span class="sxs-lookup"><span data-stu-id="a1217-576">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-577">D</span><span class="sxs-lookup"><span data-stu-id="a1217-577">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
</tbody>
</table>

 

### <a name="iot-arm"></a><span data-ttu-id="a1217-578">IoT (ARM)</span><span class="sxs-lookup"><span data-stu-id="a1217-578">IoT (ARM)</span></span>

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
<th align="left"><span data-ttu-id="a1217-579">コーデック/コンテナー</span><span class="sxs-lookup"><span data-stu-id="a1217-579">Codec/Container</span></span></th>
<th align="left"><span data-ttu-id="a1217-580">FOURCC</span><span class="sxs-lookup"><span data-stu-id="a1217-580">FOURCC</span></span></th>
<th align="left"><span data-ttu-id="a1217-581">fMP4</span><span class="sxs-lookup"><span data-stu-id="a1217-581">fMP4</span></span></th>
<th align="left"><span data-ttu-id="a1217-582">MPEG-4</span><span class="sxs-lookup"><span data-stu-id="a1217-582">MPEG-4</span></span></th>
<th align="left"><span data-ttu-id="a1217-583">MPEG-2 PS</span><span class="sxs-lookup"><span data-stu-id="a1217-583">MPEG-2 PS</span></span></th>
<th align="left"><span data-ttu-id="a1217-584">MPEG-2 TS</span><span class="sxs-lookup"><span data-stu-id="a1217-584">MPEG-2 TS</span></span></th>
<th align="left"><span data-ttu-id="a1217-585">MPEG-1</span><span class="sxs-lookup"><span data-stu-id="a1217-585">MPEG-1</span></span></th>
<th align="left"><span data-ttu-id="a1217-586">3GPP</span><span class="sxs-lookup"><span data-stu-id="a1217-586">3GPP</span></span></th>
<th align="left"><span data-ttu-id="a1217-587">3GPP2</span><span class="sxs-lookup"><span data-stu-id="a1217-587">3GPP2</span></span></th>
<th align="left"><span data-ttu-id="a1217-588">AVCHD</span><span class="sxs-lookup"><span data-stu-id="a1217-588">AVCHD</span></span></th>
<th align="left"><span data-ttu-id="a1217-589">ASF</span><span class="sxs-lookup"><span data-stu-id="a1217-589">ASF</span></span></th>
<th align="left"><span data-ttu-id="a1217-590">AVI</span><span class="sxs-lookup"><span data-stu-id="a1217-590">AVI</span></span></th>
<th align="left"><span data-ttu-id="a1217-591">MKV</span><span class="sxs-lookup"><span data-stu-id="a1217-591">MKV</span></span></th>
<th align="left"><span data-ttu-id="a1217-592">DV</span><span class="sxs-lookup"><span data-stu-id="a1217-592">DV</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="a1217-593">MPEG-1</span><span class="sxs-lookup"><span data-stu-id="a1217-593">MPEG-1</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="a1217-594">MPEG-2</span><span class="sxs-lookup"><span data-stu-id="a1217-594">MPEG-2</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="a1217-595">MPEG-4 (Part 2)</span><span class="sxs-lookup"><span data-stu-id="a1217-595">MPEG-4 (Part 2)</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="a1217-596">H.265</span><span class="sxs-lookup"><span data-stu-id="a1217-596">H.265</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-597">D</span><span class="sxs-lookup"><span data-stu-id="a1217-597">D</span></span></td>
<td align="left"><span data-ttu-id="a1217-598">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-598">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-599">D</span><span class="sxs-lookup"><span data-stu-id="a1217-599">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="a1217-600">H.264</span><span class="sxs-lookup"><span data-stu-id="a1217-600">H.264</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-601">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-601">D/E</span></span></td>
<td align="left"><span data-ttu-id="a1217-602">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-602">D/E</span></span></td>
<td align="left"><span data-ttu-id="a1217-603">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-603">D/E</span></span></td>
<td align="left"><span data-ttu-id="a1217-604">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-604">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-605">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-605">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-606">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-606">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-607">D</span><span class="sxs-lookup"><span data-stu-id="a1217-607">D</span></span></td>
<td align="left"><span data-ttu-id="a1217-608">D</span><span class="sxs-lookup"><span data-stu-id="a1217-608">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="a1217-609">H.263</span><span class="sxs-lookup"><span data-stu-id="a1217-609">H.263</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="a1217-610">VC-1</span><span class="sxs-lookup"><span data-stu-id="a1217-610">VC-1</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-611">D</span><span class="sxs-lookup"><span data-stu-id="a1217-611">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-612">D</span><span class="sxs-lookup"><span data-stu-id="a1217-612">D</span></span></td>
<td align="left"><span data-ttu-id="a1217-613">D</span><span class="sxs-lookup"><span data-stu-id="a1217-613">D</span></span></td>
<td align="left"><span data-ttu-id="a1217-614">D</span><span class="sxs-lookup"><span data-stu-id="a1217-614">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="a1217-615">WMV7/8/9</span><span class="sxs-lookup"><span data-stu-id="a1217-615">WMV7/8/9</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-616">D</span><span class="sxs-lookup"><span data-stu-id="a1217-616">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-617">D</span><span class="sxs-lookup"><span data-stu-id="a1217-617">D</span></span></td>
<td align="left"><span data-ttu-id="a1217-618">D</span><span class="sxs-lookup"><span data-stu-id="a1217-618">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="a1217-619">WMV9 Screen</span><span class="sxs-lookup"><span data-stu-id="a1217-619">WMV9 Screen</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="a1217-620">DV</span><span class="sxs-lookup"><span data-stu-id="a1217-620">DV</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="a1217-621">モーション JPEG</span><span class="sxs-lookup"><span data-stu-id="a1217-621">Motion JPEG</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-622">D</span><span class="sxs-lookup"><span data-stu-id="a1217-622">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-623">D</span><span class="sxs-lookup"><span data-stu-id="a1217-623">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
</tbody>
</table>

 

### <a name="xbox"></a><span data-ttu-id="a1217-624">Xbox</span><span class="sxs-lookup"><span data-stu-id="a1217-624">XBox</span></span>

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
<th align="left"><span data-ttu-id="a1217-625">コーデック/コンテナー</span><span class="sxs-lookup"><span data-stu-id="a1217-625">Codec/Container</span></span></th>
<th align="left"><span data-ttu-id="a1217-626">FOURCC</span><span class="sxs-lookup"><span data-stu-id="a1217-626">FOURCC</span></span></th>
<th align="left"><span data-ttu-id="a1217-627">fMP4</span><span class="sxs-lookup"><span data-stu-id="a1217-627">fMP4</span></span></th>
<th align="left"><span data-ttu-id="a1217-628">MPEG-4</span><span class="sxs-lookup"><span data-stu-id="a1217-628">MPEG-4</span></span></th>
<th align="left"><span data-ttu-id="a1217-629">MPEG-2 PS</span><span class="sxs-lookup"><span data-stu-id="a1217-629">MPEG-2 PS</span></span></th>
<th align="left"><span data-ttu-id="a1217-630">MPEG-2 TS</span><span class="sxs-lookup"><span data-stu-id="a1217-630">MPEG-2 TS</span></span></th>
<th align="left"><span data-ttu-id="a1217-631">MPEG-1</span><span class="sxs-lookup"><span data-stu-id="a1217-631">MPEG-1</span></span></th>
<th align="left"><span data-ttu-id="a1217-632">3GPP</span><span class="sxs-lookup"><span data-stu-id="a1217-632">3GPP</span></span></th>
<th align="left"><span data-ttu-id="a1217-633">3GPP2</span><span class="sxs-lookup"><span data-stu-id="a1217-633">3GPP2</span></span></th>
<th align="left"><span data-ttu-id="a1217-634">AVCHD</span><span class="sxs-lookup"><span data-stu-id="a1217-634">AVCHD</span></span></th>
<th align="left"><span data-ttu-id="a1217-635">ASF</span><span class="sxs-lookup"><span data-stu-id="a1217-635">ASF</span></span></th>
<th align="left"><span data-ttu-id="a1217-636">AVI</span><span class="sxs-lookup"><span data-stu-id="a1217-636">AVI</span></span></th>
<th align="left"><span data-ttu-id="a1217-637">MKV</span><span class="sxs-lookup"><span data-stu-id="a1217-637">MKV</span></span></th>
<th align="left"><span data-ttu-id="a1217-638">DV</span><span class="sxs-lookup"><span data-stu-id="a1217-638">DV</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="a1217-639">MPEG-1</span><span class="sxs-lookup"><span data-stu-id="a1217-639">MPEG-1</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-640">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-640">D/E</span></span></td>
<td align="left"><span data-ttu-id="a1217-641">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-641">D/E</span></span></td>
<td align="left"><span data-ttu-id="a1217-642">D</span><span class="sxs-lookup"><span data-stu-id="a1217-642">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-643">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-643">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-644">D</span><span class="sxs-lookup"><span data-stu-id="a1217-644">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="a1217-645">MPEG-2</span><span class="sxs-lookup"><span data-stu-id="a1217-645">MPEG-2</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-646">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-646">D/E</span></span></td>
<td align="left"><span data-ttu-id="a1217-647">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-647">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-648">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-648">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-649">D</span><span class="sxs-lookup"><span data-stu-id="a1217-649">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="a1217-650">MPEG-4 (Part 2)</span><span class="sxs-lookup"><span data-stu-id="a1217-650">MPEG-4 (Part 2)</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-651">D</span><span class="sxs-lookup"><span data-stu-id="a1217-651">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-652">D</span><span class="sxs-lookup"><span data-stu-id="a1217-652">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-653">D</span><span class="sxs-lookup"><span data-stu-id="a1217-653">D</span></span></td>
<td align="left"><span data-ttu-id="a1217-654">D</span><span class="sxs-lookup"><span data-stu-id="a1217-654">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="a1217-655">H.265</span><span class="sxs-lookup"><span data-stu-id="a1217-655">H.265</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-656">D</span><span class="sxs-lookup"><span data-stu-id="a1217-656">D</span></span></td>
<td align="left"><span data-ttu-id="a1217-657">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-657">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-658">D</span><span class="sxs-lookup"><span data-stu-id="a1217-658">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="a1217-659">H.264</span><span class="sxs-lookup"><span data-stu-id="a1217-659">H.264</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-660">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-660">D/E</span></span></td>
<td align="left"><span data-ttu-id="a1217-661">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-661">D/E</span></span></td>
<td align="left"><span data-ttu-id="a1217-662">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-662">D/E</span></span></td>
<td align="left"><span data-ttu-id="a1217-663">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-663">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-664">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-664">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-665">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-665">D/E</span></span></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-666">D</span><span class="sxs-lookup"><span data-stu-id="a1217-666">D</span></span></td>
<td align="left"><span data-ttu-id="a1217-667">D</span><span class="sxs-lookup"><span data-stu-id="a1217-667">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="a1217-668">H.263</span><span class="sxs-lookup"><span data-stu-id="a1217-668">H.263</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-669">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-669">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-670">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-670">D/E</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-671">D</span><span class="sxs-lookup"><span data-stu-id="a1217-671">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="a1217-672">VC-1</span><span class="sxs-lookup"><span data-stu-id="a1217-672">VC-1</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-673">D</span><span class="sxs-lookup"><span data-stu-id="a1217-673">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-674">D</span><span class="sxs-lookup"><span data-stu-id="a1217-674">D</span></span></td>
<td align="left"><span data-ttu-id="a1217-675">D</span><span class="sxs-lookup"><span data-stu-id="a1217-675">D</span></span></td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="a1217-676">WMV7/8/9</span><span class="sxs-lookup"><span data-stu-id="a1217-676">WMV7/8/9</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="a1217-677">WMV9 Screen</span><span class="sxs-lookup"><span data-stu-id="a1217-677">WMV9 Screen</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="a1217-678">DV</span><span class="sxs-lookup"><span data-stu-id="a1217-678">DV</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
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
<td align="left"><span data-ttu-id="a1217-679">モーション JPEG</span><span class="sxs-lookup"><span data-stu-id="a1217-679">Motion JPEG</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-680">D</span><span class="sxs-lookup"><span data-stu-id="a1217-680">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"></td>
<td align="left"><span data-ttu-id="a1217-681">D</span><span class="sxs-lookup"><span data-stu-id="a1217-681">D</span></span></td>
<td align="left"></td>
<td align="left"></td>
</tr>
</tbody>
</table>

## <a name="image-codec--format-support"></a><span data-ttu-id="a1217-682">イメージのコーデックおよび形式のサポート</span><span class="sxs-lookup"><span data-stu-id="a1217-682">Image codec & format support</span></span> 

<table>
<colgroup>
<col width="7%" />
<col width="7%" />
<col width="7%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="a1217-683">コーデック</span><span class="sxs-lookup"><span data-stu-id="a1217-683">Codec</span></span></th>
<th align="left"><span data-ttu-id="a1217-684">デスクトップ</span><span class="sxs-lookup"><span data-stu-id="a1217-684">Desktop</span></span></th>
<th align="left"><span data-ttu-id="a1217-685">他のデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="a1217-685">Other device families</span></span></th>
</tr>
</thead>
<tr class="odd">
<td align="left"><span data-ttu-id="a1217-686">BMP</span><span class="sxs-lookup"><span data-stu-id="a1217-686">BMP</span></span></td>
<td align="left"><span data-ttu-id="a1217-687">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-687">D/E</span></span></td>
<td align="left"><span data-ttu-id="a1217-688">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-688">D/E</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="a1217-689">DDS</span><span class="sxs-lookup"><span data-stu-id="a1217-689">DDS</span></span></td>
<td align="left"><span data-ttu-id="a1217-690">D/E<sup>1</sup></span><span class="sxs-lookup"><span data-stu-id="a1217-690">D/E<sup>1</sup></span></span></td>
<td align="left"><span data-ttu-id="a1217-691">D/E<sup>1</sup></span><span class="sxs-lookup"><span data-stu-id="a1217-691">D/E<sup>1</sup></span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="a1217-692">DNG</span><span class="sxs-lookup"><span data-stu-id="a1217-692">DNG</span></span></td>
<td align="left"><span data-ttu-id="a1217-693">D<sup>2</sup></span><span class="sxs-lookup"><span data-stu-id="a1217-693">D<sup>2</sup></span></span></td>
<td align="left"><span data-ttu-id="a1217-694">D<sup>2</sup></span><span class="sxs-lookup"><span data-stu-id="a1217-694">D<sup>2</sup></span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="a1217-695">GIF</span><span class="sxs-lookup"><span data-stu-id="a1217-695">GIF</span></span></td>
<td align="left"><span data-ttu-id="a1217-696">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-696">D/E</span></span></td>
<td align="left"><span data-ttu-id="a1217-697">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-697">D/E</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="a1217-698">ICO</span><span class="sxs-lookup"><span data-stu-id="a1217-698">ICO</span></span></td>
<td align="left"><span data-ttu-id="a1217-699">D</span><span class="sxs-lookup"><span data-stu-id="a1217-699">D</span></span></td>
<td align="left"><span data-ttu-id="a1217-700">D</span><span class="sxs-lookup"><span data-stu-id="a1217-700">D</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="a1217-701">JPEG</span><span class="sxs-lookup"><span data-stu-id="a1217-701">JPEG</span></span></td>
<td align="left"><span data-ttu-id="a1217-702">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-702">D/E</span></span></td>
<td align="left"><span data-ttu-id="a1217-703">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-703">D/E</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="a1217-704">JPEG-XR</span><span class="sxs-lookup"><span data-stu-id="a1217-704">JPEG-XR</span></span></td>
<td align="left"><span data-ttu-id="a1217-705">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-705">D/E</span></span></td>
<td align="left"><span data-ttu-id="a1217-706">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-706">D/E</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="a1217-707">PNG</span><span class="sxs-lookup"><span data-stu-id="a1217-707">PNG</span></span></td>
<td align="left"><span data-ttu-id="a1217-708">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-708">D/E</span></span></td>
<td align="left"><span data-ttu-id="a1217-709">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-709">D/E</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="a1217-710">TIFF</span><span class="sxs-lookup"><span data-stu-id="a1217-710">TIFF</span></span></td>
<td align="left"><span data-ttu-id="a1217-711">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-711">D/E</span></span></td>
<td align="left"><span data-ttu-id="a1217-712">D/E</span><span class="sxs-lookup"><span data-stu-id="a1217-712">D/E</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="a1217-713">RAW 形式のカメラ</span><span class="sxs-lookup"><span data-stu-id="a1217-713">Camera RAW</span></span></td>
<td align="left"><span data-ttu-id="a1217-714">D<sup>3</sup></span><span class="sxs-lookup"><span data-stu-id="a1217-714">D<sup>3</sup></span></span></td>
<td align="left"><span data-ttu-id="a1217-715">なし</span><span class="sxs-lookup"><span data-stu-id="a1217-715">No</span></span></td>
</tr>
</table>

<span data-ttu-id="a1217-716"><sup>1</sup> BC5 圧縮による BC1 を使用した DDS イメージがサポートされています。</span><span class="sxs-lookup"><span data-stu-id="a1217-716"><sup>1</sup> DDS images using BC1 through BC5 compression are supported.</span></span>  
<span data-ttu-id="a1217-717"><sup>2</sup> 非 RAW 形式の埋め込みプレビューを含む DNG イメージがサポートされています。</span><span class="sxs-lookup"><span data-stu-id="a1217-717"><sup>2</sup> DNG images with a non-RAW embedded preview are supported.</span></span>  
<span data-ttu-id="a1217-718"><sup>3</sup> 特定のカメラの RAW 形式のみがサポートされています。</span><span class="sxs-lookup"><span data-stu-id="a1217-718"><sup>3</sup> Only certain camera RAW formats are supported.</span></span>  

<span data-ttu-id="a1217-719">イメージ コーデックの詳細については、「[ネイティブ WIC コーデック](https://msdn.microsoft.com/library/windows/desktop/gg430027.aspx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a1217-719">For more information on image codecs, see [Native WIC Codecs](https://msdn.microsoft.com/library/windows/desktop/gg430027.aspx).</span></span>