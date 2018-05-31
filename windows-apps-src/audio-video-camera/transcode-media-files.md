---
author: drewbatgit
ms.assetid: A1A0D99A-DCBF-4A14-80B9-7106BEF045EC
description: Windows.Media.Transcoding API を使うと、ビデオ ファイルをある形式から別の形式にトランスコードできます。
title: メディア ファイルのトランスコード
ms.author: drewbat
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 20c13471d67033790c01a07e53af667c2a078894
ms.sourcegitcommit: ab92c3e0dd294a36e7f65cf82522ec621699db87
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/03/2018
ms.locfileid: "1831976"
---
# <a name="transcode-media-files"></a><span data-ttu-id="ab42d-104">メディア ファイルのトランスコード</span><span class="sxs-lookup"><span data-stu-id="ab42d-104">Transcode media files</span></span>



<span data-ttu-id="ab42d-105">[**Windows.Media.Transcoding**](https://msdn.microsoft.com/library/windows/apps/br207105) API を使って、ビデオ ファイルをある形式から別の形式にコード変換できます。</span><span class="sxs-lookup"><span data-stu-id="ab42d-105">You can use the [**Windows.Media.Transcoding**](https://msdn.microsoft.com/library/windows/apps/br207105) APIs to transcode video files from one format to another.</span></span>

<span data-ttu-id="ab42d-106">*コード変換*とは、デジタル メディア ファイル (ビデオ ファイルやオーディオ ファイル) の形式を別の形式に変換することです。</span><span class="sxs-lookup"><span data-stu-id="ab42d-106">*Transcoding* is the conversion of a digital media file, such as a video or audio file, from one format to another.</span></span> <span data-ttu-id="ab42d-107">通常は、ファイルをデコードしてエンコードし直すことで行います。</span><span class="sxs-lookup"><span data-stu-id="ab42d-107">This is usually done by decoding and then re-encoding the file.</span></span> <span data-ttu-id="ab42d-108">たとえば、MP4 形式をサポートするポータブル デバイスで再生できるように、Windows Media ファイルを MP4 に変換できます。</span><span class="sxs-lookup"><span data-stu-id="ab42d-108">For example, you might convert a Windows Media file to MP4 so that it can be played on a portable device that supports MP4 format.</span></span> <span data-ttu-id="ab42d-109">また、高解像度のビデオ ファイルの解像度を下げることもできます。</span><span class="sxs-lookup"><span data-stu-id="ab42d-109">Or, you might convert a high-definition video file to a lower resolution.</span></span> <span data-ttu-id="ab42d-110">この場合、再エンコードしたファイルは元のファイルと同じコーデックを使うことがありますが、エンコード プロファイルは異なります。</span><span class="sxs-lookup"><span data-stu-id="ab42d-110">In that case, the re-encoded file might use the same codec as the original file, but it would have a different encoding profile.</span></span>

## <a name="set-up-your-project-for-transcoding"></a><span data-ttu-id="ab42d-111">プロジェクトをコード変換用にセットアップする</span><span class="sxs-lookup"><span data-stu-id="ab42d-111">Set up your project for transcoding</span></span>

<span data-ttu-id="ab42d-112">この記事のコードを使ってメディア ファイルのコード変換を行うには、既定のプロジェクト テンプレートによって参照される名前空間に加えて、これらの名前空間を参照する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ab42d-112">In addition to the namespaces referenced by the default project template, you will need to reference these namespaces in order to transcode media files using the code in this article.</span></span>

[!code-cs[Using](./code/TranscodeWin10/cs/MainPage.xaml.cs#SnippetUsing)]

## <a name="select-source-and-destination-files"></a><span data-ttu-id="ab42d-113">変換元ファイルと変換先ファイルを選択する</span><span class="sxs-lookup"><span data-stu-id="ab42d-113">Select source and destination files</span></span>

<span data-ttu-id="ab42d-114">アプリでコード変換の変換元ファイルと変換先ファイルを判別する方法は、実装によって異なります。</span><span class="sxs-lookup"><span data-stu-id="ab42d-114">The way that your app determines the source and destination files for transcoding depends on your implementation.</span></span> <span data-ttu-id="ab42d-115">この例では、[**FileOpenPicker**](https://msdn.microsoft.com/library/windows/apps/br207847) と [**FileSavePicker**](https://msdn.microsoft.com/library/windows/apps/br207871) を使って、ユーザーが変換元ファイルと変換先ファイルを選べるようにします。</span><span class="sxs-lookup"><span data-stu-id="ab42d-115">This example uses a [**FileOpenPicker**](https://msdn.microsoft.com/library/windows/apps/br207847) and a [**FileSavePicker**](https://msdn.microsoft.com/library/windows/apps/br207871) to allow the user to pick a source and a destination file.</span></span>

[!code-cs[TranscodeGetFile](./code/TranscodeWin10/cs/MainPage.xaml.cs#SnippetTranscodeGetFile)]

## <a name="create-a-media-encoding-profile"></a><span data-ttu-id="ab42d-116">メディア エンコード プロファイルを作成する</span><span class="sxs-lookup"><span data-stu-id="ab42d-116">Create a media encoding profile</span></span>

<span data-ttu-id="ab42d-117">エンコード プロファイルには、変換先ファイルのエンコード方法を決めるための設定が含まれています。</span><span class="sxs-lookup"><span data-stu-id="ab42d-117">The encoding profile contains the settings that determine how the destination file will be encoded.</span></span> <span data-ttu-id="ab42d-118">ファイルをコード変換するときのオプションが最も多いのは、このエンコード プロファイルです。</span><span class="sxs-lookup"><span data-stu-id="ab42d-118">This is where you have the greatest number of options when you transcode a file.</span></span>

<span data-ttu-id="ab42d-119">[**MediaEncodingProfile**](https://msdn.microsoft.com/library/windows/apps/hh701026) クラスには、あらかじめ定義されたエンコード プロファイルを作るための静的メソッドが用意されています。</span><span class="sxs-lookup"><span data-stu-id="ab42d-119">The [**MediaEncodingProfile**](https://msdn.microsoft.com/library/windows/apps/hh701026) class provides static methods for creating predefined encoding profiles:</span></span>

### <a name="methods-for-creating-audio-only-encoding-profiles"></a><span data-ttu-id="ab42d-120">オーディオ専用のエンコード プロファイルを作成するメソッド</span><span class="sxs-lookup"><span data-stu-id="ab42d-120">Methods for creating Audio-only encoding profiles</span></span>

<span data-ttu-id="ab42d-121">メソッド</span><span class="sxs-lookup"><span data-stu-id="ab42d-121">Method</span></span>  |<span data-ttu-id="ab42d-122">プロファイル</span><span class="sxs-lookup"><span data-stu-id="ab42d-122">Profile</span></span>  |
---------|---------|
[**<span data-ttu-id="ab42d-123">CreateAlac</span><span class="sxs-lookup"><span data-stu-id="ab42d-123">CreateAlac</span></span>**](https://docs.microsoft.com/uwp/api/windows.media.mediaproperties.mediaencodingprofile.createalac)     |<span data-ttu-id="ab42d-124">Apple Lossless Audio Codec (ALAC) オーディオ</span><span class="sxs-lookup"><span data-stu-id="ab42d-124">Apple Lossless Audio Codec (ALAC) audio</span></span>         |
[**<span data-ttu-id="ab42d-125">CreateFlac</span><span class="sxs-lookup"><span data-stu-id="ab42d-125">CreateFlac</span></span>**](https://docs.microsoft.com/uwp/api/windows.media.mediaproperties.mediaencodingprofile.createflac)     |<span data-ttu-id="ab42d-126">Free Lossless Audio Codec (FLAC) オーディオ</span><span class="sxs-lookup"><span data-stu-id="ab42d-126">Free Lossless Audio Codec (FLAC) audio.</span></span>         |
[**<span data-ttu-id="ab42d-127">CreateM4a</span><span class="sxs-lookup"><span data-stu-id="ab42d-127">CreateM4a</span></span>**](https://docs.microsoft.com/uwp/api/windows.media.mediaproperties.mediaencodingprofile.createm4a)     |<span data-ttu-id="ab42d-128">AAC オーディオ (M4A)</span><span class="sxs-lookup"><span data-stu-id="ab42d-128">AAC audio (M4A)</span></span>         |
[**<span data-ttu-id="ab42d-129">CreateMp3</span><span class="sxs-lookup"><span data-stu-id="ab42d-129">CreateMp3</span></span>**](https://docs.microsoft.com/uwp/api/windows.media.mediaproperties.mediaencodingprofile.createmp3)     |<span data-ttu-id="ab42d-130">MP3 オーディオ</span><span class="sxs-lookup"><span data-stu-id="ab42d-130">MP3 audio</span></span>         |
[**<span data-ttu-id="ab42d-131">CreateWav</span><span class="sxs-lookup"><span data-stu-id="ab42d-131">CreateWav</span></span>**](https://docs.microsoft.com/uwp/api/windows.media.mediaproperties.mediaencodingprofile.createwav)     |<span data-ttu-id="ab42d-132">WAV オーディオ</span><span class="sxs-lookup"><span data-stu-id="ab42d-132">WAV audio</span></span>         |
[**<span data-ttu-id="ab42d-133">CreateWmv</span><span class="sxs-lookup"><span data-stu-id="ab42d-133">CreateWmv</span></span>**](https://docs.microsoft.com/uwp/api/windows.media.mediaproperties.mediaencodingprofile.createwmv)     |<span data-ttu-id="ab42d-134">Windows Media Audio (WMA)</span><span class="sxs-lookup"><span data-stu-id="ab42d-134">Windows Media Audio (WMA)</span></span>         |

### <a name="methods-for-creating-audio--video-encoding-profiles"></a><span data-ttu-id="ab42d-135">オーディオ/ビデオのエンコード プロファイルを作成するメソッド</span><span class="sxs-lookup"><span data-stu-id="ab42d-135">Methods for creating audio / video encoding profiles</span></span>

<span data-ttu-id="ab42d-136">メソッド</span><span class="sxs-lookup"><span data-stu-id="ab42d-136">Method</span></span>  |<span data-ttu-id="ab42d-137">プロファイル</span><span class="sxs-lookup"><span data-stu-id="ab42d-137">Profile</span></span>  |
---------|---------|
[**<span data-ttu-id="ab42d-138">CreateAvi</span><span class="sxs-lookup"><span data-stu-id="ab42d-138">CreateAvi</span></span>**](https://docs.microsoft.com/uwp/api/windows.media.mediaproperties.mediaencodingprofile.createavi) |<span data-ttu-id="ab42d-139">AVI</span><span class="sxs-lookup"><span data-stu-id="ab42d-139">AVI</span></span> |
[**<span data-ttu-id="ab42d-140">CreateHevc</span><span class="sxs-lookup"><span data-stu-id="ab42d-140">CreateHevc</span></span>**](https://docs.microsoft.com/uwp/api/windows.media.mediaproperties.mediaencodingprofile.createhevc) |<span data-ttu-id="ab42d-141">High Efficiency Video Coding (HEVC) ビデオ、H.265 ビデオとも呼ばれます</span><span class="sxs-lookup"><span data-stu-id="ab42d-141">High Efficiency Video Coding (HEVC) video, also known as H.265 video</span></span> |
[**<span data-ttu-id="ab42d-142">CreateMp4</span><span class="sxs-lookup"><span data-stu-id="ab42d-142">CreateMp4</span></span>**](https://docs.microsoft.com/uwp/api/windows.media.mediaproperties.mediaencodingprofile.createmp4) |<span data-ttu-id="ab42d-143">MP4 ビデオ (H.264 ビデオと AAC オーディオ)</span><span class="sxs-lookup"><span data-stu-id="ab42d-143">MP4 video (H.264 video plus AAC audio)</span></span> |
[**<span data-ttu-id="ab42d-144">CreateWmv</span><span class="sxs-lookup"><span data-stu-id="ab42d-144">CreateWmv</span></span>**](https://docs.microsoft.com/uwp/api/windows.media.mediaproperties.mediaencodingprofile.createwmv) |<span data-ttu-id="ab42d-145">Windows Media Video (WMV)</span><span class="sxs-lookup"><span data-stu-id="ab42d-145">Windows Media Video (WMV)</span></span> |


<span data-ttu-id="ab42d-146">次のコードでは、MP4 ビデオ用のプロファイルが作成されます。</span><span class="sxs-lookup"><span data-stu-id="ab42d-146">The following code creates a profile for MP4 video.</span></span>

[!code-cs[TranscodeMediaProfile](./code/TranscodeWin10/cs/MainPage.xaml.cs#SnippetTranscodeMediaProfile)]

<span data-ttu-id="ab42d-147">静的 [**CreateMp4**](https://docs.microsoft.com/uwp/api/windows.media.mediaproperties.mediaencodingprofile.createmp4) メソッドは、MP4 エンコード プロファイルを作ります。</span><span class="sxs-lookup"><span data-stu-id="ab42d-147">The static [**CreateMp4**](https://docs.microsoft.com/uwp/api/windows.media.mediaproperties.mediaencodingprofile.createmp4) method creates an MP4 encoding profile.</span></span> <span data-ttu-id="ab42d-148">このメソッドのパラメーターで、ビデオのターゲット解像度を指定します。</span><span class="sxs-lookup"><span data-stu-id="ab42d-148">The parameter for this method gives the target resolution for the video.</span></span> <span data-ttu-id="ab42d-149">この場合の [**VideoEncodingQuality.hd720p**](https://msdn.microsoft.com/library/windows/apps/hh701290) は、1280 x 720 ピクセルで 1 秒あたり 30 フレームであることを意味します </span><span class="sxs-lookup"><span data-stu-id="ab42d-149">In this case, [**VideoEncodingQuality.hd720p**](https://msdn.microsoft.com/library/windows/apps/hh701290) means 1280 x 720 pixels at 30 frames per second.</span></span> <span data-ttu-id="ab42d-150">("720p" は、プログレッシブ スキャン方式で 1 フレームあたり 720 本を処理することを表します)。あらかじめ定義されたプロファイルを作るその他のメソッドは、すべてこのパターンに従います。</span><span class="sxs-lookup"><span data-stu-id="ab42d-150">("720p" stands for 720 progressive scan lines per frame.) The other methods for creating predefined profiles all follow this pattern.</span></span>

<span data-ttu-id="ab42d-151">別の方法として、[**MediaEncodingProfile.CreateFromFileAsync**](https://msdn.microsoft.com/library/windows/apps/hh701047) メソッドを使って現在のメディア ファイルに一致するプロファイルを作成することもできます。</span><span class="sxs-lookup"><span data-stu-id="ab42d-151">Alternatively, you can create a profile that matches an existing media file by using the [**MediaEncodingProfile.CreateFromFileAsync**](https://msdn.microsoft.com/library/windows/apps/hh701047) method.</span></span> <span data-ttu-id="ab42d-152">または、必要なエンコード設定が正確にわかれば、新しい [**MediaEncodingProfile**](https://msdn.microsoft.com/library/windows/apps/hh701026) オブジェクトを作成してプロファイルの詳細を入力できます。</span><span class="sxs-lookup"><span data-stu-id="ab42d-152">Or, if you know the exact encoding settings that you want, you can create a new [**MediaEncodingProfile**](https://msdn.microsoft.com/library/windows/apps/hh701026) object and fill in the profile details.</span></span>

## <a name="transcode-the-file"></a><span data-ttu-id="ab42d-153">ファイルのコード変換を行う</span><span class="sxs-lookup"><span data-stu-id="ab42d-153">Transcode the file</span></span>

<span data-ttu-id="ab42d-154">ファイルのコード変換を行うには、新しい [**MediaTranscoder**](https://msdn.microsoft.com/library/windows/apps/br207080) オブジェクトを作成し、[**MediaTranscoder.PrepareFileTranscodeAsync**](https://msdn.microsoft.com/library/windows/apps/hh700936) メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="ab42d-154">To transcode the file, create a new [**MediaTranscoder**](https://msdn.microsoft.com/library/windows/apps/br207080) object and call the [**MediaTranscoder.PrepareFileTranscodeAsync**](https://msdn.microsoft.com/library/windows/apps/hh700936) method.</span></span> <span data-ttu-id="ab42d-155">ソース ファイル、出力先ファイル、エンコード プロファイルを渡します。</span><span class="sxs-lookup"><span data-stu-id="ab42d-155">Pass in the source file, the destination file, and the encoding profile.</span></span> <span data-ttu-id="ab42d-156">次に、非同期コード変換操作から返された [**PrepareTranscodeResult**](https://msdn.microsoft.com/library/windows/apps/hh700941) オブジェクト上の [**TranscodeAsync**](https://msdn.microsoft.com/library/windows/apps/hh700946) メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="ab42d-156">Then call the [**TranscodeAsync**](https://msdn.microsoft.com/library/windows/apps/hh700946) method on the [**PrepareTranscodeResult**](https://msdn.microsoft.com/library/windows/apps/hh700941) object that was returned from the async transcode operation.</span></span>

[!code-cs[TranscodeTranscodeFile](./code/TranscodeWin10/cs/MainPage.xaml.cs#SnippetTranscodeTranscodeFile)]

## <a name="respond-to-transcoding-progress"></a><span data-ttu-id="ab42d-157">コード変換の進行状況に対して応答する</span><span class="sxs-lookup"><span data-stu-id="ab42d-157">Respond to transcoding progress</span></span>

<span data-ttu-id="ab42d-158">非同期の [**TranscodeAsync**](https://msdn.microsoft.com/library/windows/apps/hh700946) の進行状況が変化したときに応答するイベントを登録できます。</span><span class="sxs-lookup"><span data-stu-id="ab42d-158">You can register events to respond when the progress of the asynchronous [**TranscodeAsync**](https://msdn.microsoft.com/library/windows/apps/hh700946) changes.</span></span> <span data-ttu-id="ab42d-159">これらのイベントは、ユニバーサル Windows プラットフォーム (UWP) アプリの非同期プログラミング フレームワークの一部であり、コード変換 API に固有のものではありません。</span><span class="sxs-lookup"><span data-stu-id="ab42d-159">These events are part of the async programming framework for Universal Windows Platform (UWP) apps and are not specific to the transcoding API.</span></span>

[!code-cs[TranscodeCallbacks](./code/TranscodeWin10/cs/MainPage.xaml.cs#SnippetTranscodeCallbacks)]


## <a name="encode-a-metadata-stream"></a><span data-ttu-id="ab42d-160">メタデータ ストリームをエンコードする</span><span class="sxs-lookup"><span data-stu-id="ab42d-160">Encode a metadata stream</span></span>


 

 




