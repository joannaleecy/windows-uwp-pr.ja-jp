---
ms.assetid: 0A360481-B649-4E90-9BC4-4449BA7445EF
description: デバイスにインストールされているオーディオとビデオのエンコーダーとデコーダーを照会します。
title: インストールされているコーデックの照会
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, コーデック, エンコーダー, デコーダー, クエリ
ms.localizationpriority: medium
ms.openlocfilehash: 4241aad5a01617d6a002c6f5d6da0a4bb1455616
ms.sourcegitcommit: b5c9c18e70625ab770946b8243f3465ee1013184
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/28/2018
ms.locfileid: "7975534"
---
# <a name="query-for-codecs-installed-on-a-device"></a><span data-ttu-id="28f5f-104">デバイスにインストールされているコーデックの照会</span><span class="sxs-lookup"><span data-stu-id="28f5f-104">Query for codecs installed on a device</span></span>
<span data-ttu-id="28f5f-105">**[CodecQuery](https://docs.microsoft.com/uwp/api/windows.media.core.codecquery)** クラスによって、現在のデバイスにインストールされているコーデックを照会できます。</span><span class="sxs-lookup"><span data-stu-id="28f5f-105">The **[CodecQuery](https://docs.microsoft.com/uwp/api/windows.media.core.codecquery)** class allows you to query for codecs installed on the current device.</span></span> <span data-ttu-id="28f5f-106">Windows 10 に含まれているさまざまなデバイス ファミリのコーデックの一覧については、「[サポートされるコーデック](supported-codecs.md)」の記事に示されています。ただし、ユーザーやアプリはデバイスに追加のコーデックをインストールできるため、現在のデバイスでどのようなコーデックが利用可能かを特定するために、実行時にコーデックのサポートを照会することができます。</span><span class="sxs-lookup"><span data-stu-id="28f5f-106">The list of codecs that are included with Windows 10 for different device families are listed in the article [Supported codecs](supported-codecs.md), but since users and apps can install additional codecs on a device, you may want to query for codec support at runtime to determine what codecs are available on the current device.</span></span>

<span data-ttu-id="28f5f-107">CodecQuery API は、**[Windows.Media.Core](https://docs.microsoft.com/uwp/api/windows.media.core)** 名前空間のメンバーであるため、この名前空間をアプリに含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="28f5f-107">The CodecQuery API is a member of the **[Windows.Media.Core](https://docs.microsoft.com/uwp/api/windows.media.core)** namespace, so you will need to include this namespace in your app.</span></span>

<span data-ttu-id="28f5f-108">CodecQuery API は、**[Windows.Media.Core](https://docs.microsoft.com/uwp/api/windows.media.core)** 名前空間のメンバーであるため、この名前空間をアプリに含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="28f5f-108">The CodecQuery API is a member of the **[Windows.Media.Core](https://docs.microsoft.com/uwp/api/windows.media.core)** namespace, so you will need to include this namespace in your app.</span></span>

[!code-cs[CodecQueryUsing](./code/TranscodeWin10/cs/MainPage.xaml.cs#SnippetCodecQueryUsing)]

<span data-ttu-id="28f5f-109">コンストラクターを呼び出すことによって、**CodecQuery** クラスの新しいインスタンスを初期化します。</span><span class="sxs-lookup"><span data-stu-id="28f5f-109">Initialize a new instance of the **CodecQuery** class by calling the constructor.</span></span>

[!code-cs[NewCodecQuery](./code/TranscodeWin10/cs/MainPage.xaml.cs#SnippetNewCodecQuery)]

<span data-ttu-id="28f5f-110">**[FindAllAsync](https://docs.microsoft.com/uwp/api/windows.media.core.codecquery.findallasync)** メソッドは、指定されたパラメーターに一致するインストール済みのすべてのコーデックを返します。</span><span class="sxs-lookup"><span data-stu-id="28f5f-110">The **[FindAllAsync](https://docs.microsoft.com/uwp/api/windows.media.core.codecquery.findallasync)** method returns all installed codecs that match the supplied parameters.</span></span> <span data-ttu-id="28f5f-111">これらのパラメーターには、オーディオ、ビデオ、またはその両方のどれを照会するかを指定する **[CodecKind](https://docs.microsoft.com/uwp/api/windows.media.core.codeckind)** 値、エンコーダーとデコーダーのどちらを照会するかを指定する **[CodecCategory](https://docs.microsoft.com/uwp/api/windows.media.core.codeccategory)** 値、照会するメディア エンコード サブタイプを表す文字列 (H.264 ビデオや MP3 オーディオなど) が含まれます。</span><span class="sxs-lookup"><span data-stu-id="28f5f-111">These parameters include a **[CodecKind](https://docs.microsoft.com/uwp/api/windows.media.core.codeckind)** value specifying whether you are querying for audio or video codecs or both, a **[CodecCategory](https://docs.microsoft.com/uwp/api/windows.media.core.codeccategory)** value specifying whether you are querying for encoders or decoders, and a string that represents the media encoding subtype for which you are querying, such as H.264 video or MP3 audio.</span></span>

<span data-ttu-id="28f5f-112">すべてサブタイプのコーデックを返すには、サブタイプ値として空の文字列または null を指定します。</span><span class="sxs-lookup"><span data-stu-id="28f5f-112">Specify empty string or null for the subtype value to return codecs for all subtypes.</span></span> <span data-ttu-id="28f5f-113">次の例では、デバイスにインストールされているすべてのビデオ エンコーダーの一覧が取得されます。</span><span class="sxs-lookup"><span data-stu-id="28f5f-113">The following example lists all of the video encoders installed on the device.</span></span>

[!code-cs[FindAllEncoders](./code/TranscodeWin10/cs/MainPage.xaml.cs#SnippetFindAllEncoders)]

<span data-ttu-id="28f5f-114">**FindAllAsync** に渡すサブタイプ文字列には、システムで定義されているサブタイプ GUID の文字列表現またはサブタイプの FOURCC コードを指定できます。</span><span class="sxs-lookup"><span data-stu-id="28f5f-114">The subtype string you pass into **FindAllAsync** can either be a string representation of the subtype GUID which is defined by the system or a FOURCC code for the subtype.</span></span> <span data-ttu-id="28f5f-115">一連のサポートされるメディア サブタイプの GUID は、「[オーディオ サブタイプの GUID](https://msdn.microsoft.com/library/windows/desktop/aa372553(v=vs.85).aspx)」と「[ビデオ サブタイプの GUID](https://msdn.microsoft.com/library/windows/desktop/aa370819(v=vs.85).aspx)」の記事に示されていますが、**[CodecSubtypes](https://docs.microsoft.com/uwp/api/windows.media.core.codecsubtypes)** クラスには、サポートされている各サブタイプの GUID 値を返すプロパティが用意されています。</span><span class="sxs-lookup"><span data-stu-id="28f5f-115">The set of supported media subtype GUIDs are listed in the articles [Audio Subtype GUIDs](https://msdn.microsoft.com/library/windows/desktop/aa372553(v=vs.85).aspx) and [Video Subtype GUIDs](https://msdn.microsoft.com/library/windows/desktop/aa370819(v=vs.85).aspx), but the **[CodecSubtypes](https://docs.microsoft.com/uwp/api/windows.media.core.codecsubtypes)** class provides properties that return the GUID values for each supported subtype.</span></span> <span data-ttu-id="28f5f-116">FOURCC コードの詳細については、[FOURCC コードに関する記事](https://msdn.microsoft.com/library/windows/desktop/dd375802(v=vs.85).aspx)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="28f5f-116">For more information on FOURCC codes, see [FOURCC Codes](https://msdn.microsoft.com/library/windows/desktop/dd375802(v=vs.85).aspx)</span></span> 

<span data-ttu-id="28f5f-117">次の例では、デバイスに H.264 ビデオ デコーダーがインストールされているかどうかを確認するために、FOURCC コード "H264" を指定しています。</span><span class="sxs-lookup"><span data-stu-id="28f5f-117">The following example specifies the FOURCC code "H264" to determine if there is an H.264 video decoder installed on the device.</span></span> <span data-ttu-id="28f5f-118">H.264 ビデオ コンテンツを再生する前に、このクエリを実行できます。</span><span class="sxs-lookup"><span data-stu-id="28f5f-118">You could perform this query before attempting to play back H.264 video content.</span></span> <span data-ttu-id="28f5f-119">また、再生時にサポートされていないコーデックを処理することもできます。</span><span class="sxs-lookup"><span data-stu-id="28f5f-119">You can also handle unsupported codecs at playback time.</span></span> <span data-ttu-id="28f5f-120">詳しくは、「[メディア項目を開く際にサポートされていないコーデックと不明なエラーを処理する](https://docs.microsoft.com/windows/uwp/audio-video-camera/media-playback-with-mediasource#handle-unsupported-codecs-and-unknown-errors-when-opening-media-items)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="28f5f-120">For more information, see [Handle unsupported codecs and unknown errors when opening media items](https://docs.microsoft.com/windows/uwp/audio-video-camera/media-playback-with-mediasource#handle-unsupported-codecs-and-unknown-errors-when-opening-media-items).</span></span>

[!code-cs[IsH264Supported](./code/TranscodeWin10/cs/MainPage.xaml.cs#SnippetIsH264Supported)]

<span data-ttu-id="28f5f-121">次の例では、現在のデバイスに FLAC オーディオ エンコーダーがインストールされているかどうかを照会して確認し、インストールされている場合は、オーディオをファイルにキャプチャしたり、オーディオを別の形式から FLAC オーディオ ファイルにトランスコードしたりするために使用できる **[MediaEncodingProfile](https://docs.microsoft.com/uwp/api/Windows.Media.MediaProperties.MediaEncodingProfile)** がこのサブタイプ用に作成されます。</span><span class="sxs-lookup"><span data-stu-id="28f5f-121">The following example queries to determine if a FLAC audio encoder is installed on the current device and, if so, a **[MediaEncodingProfile](https://docs.microsoft.com/uwp/api/Windows.Media.MediaProperties.MediaEncodingProfile)** is created for the subtype which could be used for capturing audio to a file or transcoding audio from another format to a FLAC audio file.</span></span>

[!code-cs[IsFLACSupported](./code/TranscodeWin10/cs/MainPage.xaml.cs#SnippetIsFLACSupported)]

## <a name="related-topics"></a><span data-ttu-id="28f5f-122">関連トピック</span><span class="sxs-lookup"><span data-stu-id="28f5f-122">Related topics</span></span>

* [<span data-ttu-id="28f5f-123">メディア再生</span><span class="sxs-lookup"><span data-stu-id="28f5f-123">Media playback</span></span>](media-playback.md)
* [<span data-ttu-id="28f5f-124">MediaCapture を使った基本的な写真、ビデオ、およびオーディオのキャプチャ</span><span class="sxs-lookup"><span data-stu-id="28f5f-124">Basic photo, video, and audio capture with MediaCapture</span></span>](basic-photo-video-and-audio-capture-with-MediaCapture.md)
* [<span data-ttu-id="28f5f-125">メディア ファイルのトランスコード</span><span class="sxs-lookup"><span data-stu-id="28f5f-125">Transcode media files</span></span>](transcode-media-files.md)
* [<span data-ttu-id="28f5f-126">サポートされているコーデック</span><span class="sxs-lookup"><span data-stu-id="28f5f-126">Supported codecs</span></span>](supported-codecs.md)
 

 




