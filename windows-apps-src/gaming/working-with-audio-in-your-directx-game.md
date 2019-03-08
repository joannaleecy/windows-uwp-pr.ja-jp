---
title: ゲームのオーディオ
description: ミュージックやサウンドを開発して DirectX ゲームに組み込む方法と、オーディオ信号を処理してダイナミック サウンドやポジショナル サウンドを作成する方法について説明します。
ms.assetid: ab29297a-9588-c79b-24c5-3b94b85e74a8
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, オーディオ, DirectX
ms.localizationpriority: medium
ms.openlocfilehash: fd106e07e6359e9289074cb62cec6bf7458ac5bc
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57634577"
---
# <a name="audio-for-games"></a><span data-ttu-id="5a884-104">ゲームのオーディオ</span><span class="sxs-lookup"><span data-stu-id="5a884-104">Audio for games</span></span>



<span data-ttu-id="5a884-105">ミュージックやサウンドを開発して DirectX ゲームに組み込む方法と、オーディオ信号を処理してダイナミック サウンドやポジショナル サウンドを作成する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="5a884-105">Learn how to develop and incorporate music and sounds into your DirectX game, and how to process the audio signals to create dynamic and positional sounds.</span></span>

<span data-ttu-id="5a884-106">オーディオのプログラミングには、DirectX の XAudio2 ライブラリを使用することをお勧めします。ここでも同ライブラリを使用しています。</span><span class="sxs-lookup"><span data-stu-id="5a884-106">For audio programming, we recommend using the XAudio2 library in DirectX, and we use it here.</span></span> <span data-ttu-id="5a884-107">XAudio2 は、ゲーム開発における信号処理とオーディオ ミキシングの基礎を提供する下位レベルのオーディオ ライブラリです。多様なフォーマットがサポートされています。</span><span class="sxs-lookup"><span data-stu-id="5a884-107">XAudio2 is a low-level audio library that provides a signal processing and mixing foundation for games, and it supports a variety of formats.</span></span>

<span data-ttu-id="5a884-108">[Microsoft メディア ファンデーション](https://msdn.microsoft.com/library/windows/desktop/ms694197)を使用してシンプルなサウンドやミュージックの再生を実装することもできます。</span><span class="sxs-lookup"><span data-stu-id="5a884-108">You can also implement simple sounds and music playback with [Microsoft Media Foundation](https://msdn.microsoft.com/library/windows/desktop/ms694197).</span></span> <span data-ttu-id="5a884-109">Microsoft メディア ファンデーションは、オーディオとビデオの両方に対応したメディア ファイルやストリームの再生用として設計されていますが、ゲームに利用することもできます。特に、ゲーム中の映画的なシーンや非対話型のコンポーネントに利用できます。</span><span class="sxs-lookup"><span data-stu-id="5a884-109">Microsoft Media Foundation is designed for the playback of media files and streams, both audio and video, but can also be used in games, and is particularly useful for cinematic scenes or non-interactive components of your game.</span></span>

## <a name="concepts-at-a-glance"></a><span data-ttu-id="5a884-110">概要</span><span class="sxs-lookup"><span data-stu-id="5a884-110">Concepts at a glance</span></span>


<span data-ttu-id="5a884-111">このセクションで使用するオーディオ プログラミングの概念について以下に説明します。</span><span class="sxs-lookup"><span data-stu-id="5a884-111">Here are a few audio programming concepts we use in this section.</span></span>

-   <span data-ttu-id="5a884-112">信号は、サウンド プログラミングに使用する基本単位です。グラフィックスにおけるピクセルに相当します。</span><span class="sxs-lookup"><span data-stu-id="5a884-112">Signals are the basic unit of sound programming, analogous to pixels in graphics.</span></span> <span data-ttu-id="5a884-113">これらの信号を処理するデジタル シグナル プロセッサ (DSP) は、ゲーム オーディオのピクセル シェーダーのようなものです。</span><span class="sxs-lookup"><span data-stu-id="5a884-113">The digital signal processors (DSPs) that process them are like the pixel shaders of game audio.</span></span> <span data-ttu-id="5a884-114">信号の変換、組み合わせ、またはフィルターを行います。</span><span class="sxs-lookup"><span data-stu-id="5a884-114">They can transform signals, or combine them, or filter them.</span></span> <span data-ttu-id="5a884-115">DSP にプログラミングすることにより、ゲームのサウンド効果やミュージックをはるかに簡単な方法で加工することができます。</span><span class="sxs-lookup"><span data-stu-id="5a884-115">By programming to the DSPs, you can alter your game's sound effects and music with as little or as much complexity as you need.</span></span>
-   <span data-ttu-id="5a884-116">ボイスは、2 つ以上の信号をサブミックスしたコンポジットです。</span><span class="sxs-lookup"><span data-stu-id="5a884-116">Voices are the submixed composites of two or more signals.</span></span> <span data-ttu-id="5a884-117">XAudio2 のボイス オブジェクトには、ソース、サブミックス、マスタリングという 3 種類のボイスがあります。</span><span class="sxs-lookup"><span data-stu-id="5a884-117">There are 3 types of XAudio2 voice objects: source, submix, and mastering voices.</span></span> <span data-ttu-id="5a884-118">ソース ボイスは、クライアントから提供されたオーディオ データに適用されます。</span><span class="sxs-lookup"><span data-stu-id="5a884-118">Source voices operate on audio data provided by the client.</span></span> <span data-ttu-id="5a884-119">ソース ボイスとサブミックス ボイスは、1 つ以上のサブミックス ボイスまたはマスタリング ボイスに向けて出力を送信します。</span><span class="sxs-lookup"><span data-stu-id="5a884-119">Source and submix voices send their output to one or more submix or mastering voices.</span></span> <span data-ttu-id="5a884-120">サブミックス ボイスとマスタリング ボイスは、それぞれに送られるすべてのボイスからオーディオをミキシングし、その結果に対して作用します。</span><span class="sxs-lookup"><span data-stu-id="5a884-120">Submix and mastering voices mix the audio from all voices feeding them, and operate on the result.</span></span> <span data-ttu-id="5a884-121">マスタリング ボイスは、オーディオ デバイスにオーディオ データを書き込みます。</span><span class="sxs-lookup"><span data-stu-id="5a884-121">Mastering voices write audio data to an audio device.</span></span>
-   <span data-ttu-id="5a884-122">ミキシングは、シーンの背景で再生されるサウンド効果やバックグラウンド オーディオなど、個別のボイスを組み合わせて単一のストリームを形成するプロセスです。</span><span class="sxs-lookup"><span data-stu-id="5a884-122">Mixing is the process of combining several discrete voices, such as the sound effects and the background audio that are played back in a scene, into a single stream.</span></span> <span data-ttu-id="5a884-123">サブミキシングは、エンジン音などのコンポーネント サウンドを組み合わせて、1 つのボイスを作成するプロセスです。</span><span class="sxs-lookup"><span data-stu-id="5a884-123">Submixing is the process of combining several discrete signals, such as the component sounds of an engine noise, and creating a voice.</span></span>
-   <span data-ttu-id="5a884-124">オーディオ形式。</span><span class="sxs-lookup"><span data-stu-id="5a884-124">Audio formats.</span></span> <span data-ttu-id="5a884-125">ミュージックとサウンドの効果は、ゲームで使用する多様なデジタル形式で保存できます。</span><span class="sxs-lookup"><span data-stu-id="5a884-125">Music and sound effects can be stored in a variety of digital formats for your game.</span></span> <span data-ttu-id="5a884-126">WAV のような非圧縮型や MP3 や OGG などの圧縮型の形式があります。</span><span class="sxs-lookup"><span data-stu-id="5a884-126">There are uncompressed formats, like WAV, and compressed formats like MP3 and OGG.</span></span> <span data-ttu-id="5a884-127">サンプルの圧縮率が高くなるほど、忠実度が低下します (通常、圧縮率はビット レートで表し、ビット レートが低いほど、圧縮の損失が大きくなります)。</span><span class="sxs-lookup"><span data-stu-id="5a884-127">The more a sample is compressed -- typically designated by its bit rate, where the lower the bit rate is, the more lossy the compression -- the worse fidelity it has.</span></span> <span data-ttu-id="5a884-128">忠実度は、圧縮方式やビット レートによって変動するため、実験しながら実際のゲームに応じた最適のレベルを探る必要があります。</span><span class="sxs-lookup"><span data-stu-id="5a884-128">Fidelity can vary across compression schemes and bit rates, so experiment with them to find what works best for your game.</span></span>
-   <span data-ttu-id="5a884-129">サンプル レートと品質。</span><span class="sxs-lookup"><span data-stu-id="5a884-129">Sample rate and quality.</span></span> <span data-ttu-id="5a884-130">サウンドは、さまざまなレートでサンプリングできます。低いレートでサンプリングしたサウンドは忠実度が相当低くなります。</span><span class="sxs-lookup"><span data-stu-id="5a884-130">Sounds can be sampled at different rates, and sounds sampled at a lower rate have much poorer fidelity.</span></span> <span data-ttu-id="5a884-131">CD 品質のサンプル レートは 44.1 Khz (44100 Hz) です。</span><span class="sxs-lookup"><span data-stu-id="5a884-131">The sample rate for CD quality is 44.1 Khz (44100 Hz).</span></span> <span data-ttu-id="5a884-132">サウンドに Hi-Fi の音質が必要ない場合は、低いサンプル レートを選択できます。</span><span class="sxs-lookup"><span data-stu-id="5a884-132">If you don't need high fidelity for a sound, you can choose a lower sample rate.</span></span> <span data-ttu-id="5a884-133">プロフェッショナル向けのオーディオ アプリケーションであればサンプル レートを高く設定する必要がありますが、ゲーム中でプロ レベルの音質が求められない限り、おそらくその必要ありません。</span><span class="sxs-lookup"><span data-stu-id="5a884-133">Higher rates may be appropriate for professional audio applications, but you probably don't need them unless your game demands professional fidelity sound.</span></span>
-   <span data-ttu-id="5a884-134">サウンド エミッター (ソース)。</span><span class="sxs-lookup"><span data-stu-id="5a884-134">Sound emitters (or sources).</span></span> <span data-ttu-id="5a884-135">XAudio2 でいうサウンド エミッターとは、バックグラウンド ノズルのブリップ音であれ、ゲーム中のジュークボックスで再生する激しいロック トラックであれ、音を発する場所のことを指します。</span><span class="sxs-lookup"><span data-stu-id="5a884-135">In XAudio2, sound emitters are locations that emit a sound, be it a mere blip of a background noise or a snarling rock track played by an in-game jukebox.</span></span> <span data-ttu-id="5a884-136">エミッターは、ワールド座標で指定します。</span><span class="sxs-lookup"><span data-stu-id="5a884-136">You specify emitters by world coordinates.</span></span>
-   <span data-ttu-id="5a884-137">サウンド リスナー。</span><span class="sxs-lookup"><span data-stu-id="5a884-137">Sound listeners.</span></span> <span data-ttu-id="5a884-138">サウンド リスナーはプレーヤーであったり、高度なゲームの場合は、リスナーから受け取ったサウンドを処理する AI エンティティであったりします。</span><span class="sxs-lookup"><span data-stu-id="5a884-138">A sound listener is often the player, or perhaps an AI entity in a more advanced game, that processes the sounds received from a listener.</span></span> <span data-ttu-id="5a884-139">そのサウンドを、プレーヤーに対して再生するオーディオ ストリームにサブミックスしたり、特定のゲーム中アクション (たとえばリスナーとしてマークを付けた AI ガードを起動する) に適用したりできます。</span><span class="sxs-lookup"><span data-stu-id="5a884-139">You can submix that sound into the audio stream for playback to the player, or you can use it to take a specific in-game action, like awakening an AI guard marked as a listener.</span></span>

## <a name="design-considerations"></a><span data-ttu-id="5a884-140">設計時の考慮事項</span><span class="sxs-lookup"><span data-stu-id="5a884-140">Design considerations</span></span>


<span data-ttu-id="5a884-141">オーディオは、ゲームの設計と開発の面できわめて重要な役割を果たします。</span><span class="sxs-lookup"><span data-stu-id="5a884-141">Audio is a tremendously important part of game design and development.</span></span> <span data-ttu-id="5a884-142">凡庸なゲームであっても、記憶に残るサウンドトラックや優れたボイスワーク、サウンド ミキシング、全体に秀逸なオーディオ制作が取り入れられているという単純な理由から、こうしたゲームに伝説的な評価を与えるゲーム プレーヤーも少なくありません。</span><span class="sxs-lookup"><span data-stu-id="5a884-142">Many gamers can recall a mediocre game elevated to legendary status just because of a memorable soundtrack, or great voice work and sound mixing, or overall stellar audio production.</span></span> <span data-ttu-id="5a884-143">ミュージックとサウンドはゲームの個性を決定するだけでなく、ゲーム全体の輪郭を定義したり、他の類似したゲームからの差別化を図ったりするための主因にもなります。</span><span class="sxs-lookup"><span data-stu-id="5a884-143">Music and sound define a game's personality, and establish the main motive that defines the game and makes it stand apart from other similar games.</span></span> <span data-ttu-id="5a884-144">ゲームのオーディオ プロファイルの設計と開発に向けて投入した努力は、必ずそれなりの価値があるものです。</span><span class="sxs-lookup"><span data-stu-id="5a884-144">The effort you spend designing and developing your game's audio profile will be well worth it.</span></span>

<span data-ttu-id="5a884-145">3D ポジショナル オーディオは、3D グラフィックスがもたらす没入感に新たな次元を加えるものです。</span><span class="sxs-lookup"><span data-stu-id="5a884-145">Positional 3D audio can add a level of immersion beyond that provided by 3D graphics.</span></span> <span data-ttu-id="5a884-146">実世界のシミュレーションや映画のようなシーンの再現を目指した、複雑なゲームを開発している場合は、3D ポジショナル オーディオを利用して、プレーヤーをゲームの世界に引き込むことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="5a884-146">If you are developing a complex game that simulates a world, or which demands a cinematic style, consider using 3D positional audio techniques to really draw the player in.</span></span>

## <a name="directx-audio-development-roadmap"></a><span data-ttu-id="5a884-147">DirectX オーディオ開発のロードマップ</span><span class="sxs-lookup"><span data-stu-id="5a884-147">DirectX audio development roadmap</span></span>


### <a name="xaudio2-conceptual-resources"></a><span data-ttu-id="5a884-148">XAudio2 の概念に関するリソース</span><span class="sxs-lookup"><span data-stu-id="5a884-148">XAudio2 conceptual resources</span></span>

<span data-ttu-id="5a884-149">XAudio2 は、DirectX 用のオーディオ ミキシング ライブラリで、主に、高パフォーマンスのオーディオ エンジンをゲーム用に開発することを目的としています。</span><span class="sxs-lookup"><span data-stu-id="5a884-149">XAudio2 is the audio mixing library for DirectX, and is primarily intended for developing high performance audio engines for games.</span></span> <span data-ttu-id="5a884-150">効果音やバックグラウンド ミュージックを自分の最新のゲームに追加したいゲーム開発者にとって、XAudio2 はオーディオ グラフとミキシング エンジンを短い待機時間で提供し、ダイナミック バッファー、同期サンプルアキュレート再生、暗黙的なソース レート変換をサポートします。</span><span class="sxs-lookup"><span data-stu-id="5a884-150">For game developers who want to add sound effects and background music to their modern games, XAudio2 offers an audio graph and mixing engine with low-latency and support for dynamic buffers, synchronous sample-accurate playback, and implicit source rate conversion.</span></span>

<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="5a884-151">トピック</span><span class="sxs-lookup"><span data-stu-id="5a884-151">Topic</span></span></th>
<th align="left"><span data-ttu-id="5a884-152">説明</span><span class="sxs-lookup"><span data-stu-id="5a884-152">Description</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p><span data-ttu-id="5a884-153"><a href="https://msdn.microsoft.com/library/windows/desktop/ee415813">XAudio2 の概要</a></span><span class="sxs-lookup"><span data-stu-id="5a884-153"><a href="https://msdn.microsoft.com/library/windows/desktop/ee415813">Introduction to XAudio2</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="5a884-154">XAudio2 でサポートされるオーディオ プログラミング機能を一覧します。</span><span class="sxs-lookup"><span data-stu-id="5a884-154">The topic provides a list of the audio programming features supported by XAudio2.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="5a884-155"><a href="https://msdn.microsoft.com/library/windows/desktop/ee415762">XAudio2 の概要</a></span><span class="sxs-lookup"><span data-stu-id="5a884-155"><a href="https://msdn.microsoft.com/library/windows/desktop/ee415762">Getting Started with XAudio2</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="5a884-156">XAudio2 の概念、XAudio2 のバージョン、RIFF オーディオ形式について説明します。</span><span class="sxs-lookup"><span data-stu-id="5a884-156">This topic provides information on key XAudio2 concepts, XAudio2 versions, and the RIFF audio format.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="5a884-157"><a href="https://msdn.microsoft.com/library/windows/desktop/ee415692">一般的なオーディオ プログラミングの概念</a></span><span class="sxs-lookup"><span data-stu-id="5a884-157"><a href="https://msdn.microsoft.com/library/windows/desktop/ee415692">Common Audio Programming Concepts</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="5a884-158">オーディオ開発者が知っておくべき一般的なオーディオ概念に関する概要を説明します。</span><span class="sxs-lookup"><span data-stu-id="5a884-158">This topic provides an overview of common audio concepts with which an audio developer should be familiar.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="5a884-159"><a href="https://msdn.microsoft.com/library/windows/desktop/ee415825">XAudio2 音声</a></span><span class="sxs-lookup"><span data-stu-id="5a884-159"><a href="https://msdn.microsoft.com/library/windows/desktop/ee415825">XAudio2 Voices</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="5a884-160">XAudio2 のボイスの概要について説明します。XAudio2 のボイスは、オーディオ データをサブミックス、操作、マスタリングするときに使われます。</span><span class="sxs-lookup"><span data-stu-id="5a884-160">This topic contains an overview of XAudio2 voices, which are used to submix, operate on, and master audio data.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="5a884-161"><a href="https://msdn.microsoft.com/library/windows/desktop/ee415745">XAudio2 コールバック</a></span><span class="sxs-lookup"><span data-stu-id="5a884-161"><a href="https://msdn.microsoft.com/library/windows/desktop/ee415745">XAudio2 Callbacks</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="5a884-162">XAudio2 のコールバックについて説明します。XAudio2 のコールバックは、オーディオ再生の中断を防止するために使われます。</span><span class="sxs-lookup"><span data-stu-id="5a884-162">This topic covers the XAudio 2 callbacks, which are used to prevent breaks in the audio playback.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="5a884-163"><a href="https://msdn.microsoft.com/library/windows/desktop/ee415739">XAudio2 オーディオ グラフ</a></span><span class="sxs-lookup"><span data-stu-id="5a884-163"><a href="https://msdn.microsoft.com/library/windows/desktop/ee415739">XAudio2 Audio Graphs</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="5a884-164">XAudio2 のオーディオ処理グラフについて説明します。オーディオ処理グラフでは、クライアントから一連のオーディオ ストリームを入力として受け取り処理して、最終結果をオーディオ デバイスに配信します。</span><span class="sxs-lookup"><span data-stu-id="5a884-164">This topic covers the XAudio2 audio processing graphs, which take a set of audio streams from the client as input, process them, and deliver the final result to an audio device.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="5a884-165"><a href="https://msdn.microsoft.com/library/windows/desktop/ee415756">XAudio2 オーディオ特殊効果</a></span><span class="sxs-lookup"><span data-stu-id="5a884-165"><a href="https://msdn.microsoft.com/library/windows/desktop/ee415756">XAudio2 Audio Effects</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="5a884-166">XAudio2 のオーディオ エフェクトについて説明します。オーディオ エフェクトは、受信したオーディオ データを転送する前に何らかの処理 (リバーブ エフェクトなど) を実行します。</span><span class="sxs-lookup"><span data-stu-id="5a884-166">The topic covers XAudio2 audio effects, which take incoming audio data and perform some operation on the data (such as a reverb effect) before passing it on.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="5a884-167"><a href="https://msdn.microsoft.com/library/windows/desktop/ee415821">XAudio2 にオーディオ データをストリーミングします。</a></span><span class="sxs-lookup"><span data-stu-id="5a884-167"><a href="https://msdn.microsoft.com/library/windows/desktop/ee415821">Streaming Audio Data with XAudio2</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="5a884-168">XAudio2 を使ったオーディオ ストリーミングについて説明します。</span><span class="sxs-lookup"><span data-stu-id="5a884-168">This topic covers audio streaming with XAudio2.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="5a884-169"><a href="https://msdn.microsoft.com/library/windows/desktop/ee415714">X3DAudio</a></span><span class="sxs-lookup"><span data-stu-id="5a884-169"><a href="https://msdn.microsoft.com/library/windows/desktop/ee415714">X3DAudio</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="5a884-170">X3DAudio について説明します。X3DAudio は XAudio2 と連携して、3D 空間内の1点からサウンドが聞こえてくるような効果を生み出す API です。</span><span class="sxs-lookup"><span data-stu-id="5a884-170">this topic covers X3DAudio, an API used in conjunction with XAudio2 to create the illusion of a sound coming from a point in 3D space.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="5a884-171"><a href="https://msdn.microsoft.com/library/windows/desktop/ee415899">XAudio2 プログラミング リファレンス</a></span><span class="sxs-lookup"><span data-stu-id="5a884-171"><a href="https://msdn.microsoft.com/library/windows/desktop/ee415899">XAudio2 Programming Reference</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="5a884-172">XAudio2 API の詳しいリファレンスです。</span><span class="sxs-lookup"><span data-stu-id="5a884-172">This section contains the complete reference for the XAudio2 APIs.</span></span></p></td>
</tr>
</tbody>
</table>

 

### <a name="xaudio2-how-to-resources"></a><span data-ttu-id="5a884-173">XAudio2 の操作方法に関するリソース</span><span class="sxs-lookup"><span data-stu-id="5a884-173">XAudio2 "how to" resources</span></span>

<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="5a884-174">トピック</span><span class="sxs-lookup"><span data-stu-id="5a884-174">Topic</span></span></th>
<th align="left"><span data-ttu-id="5a884-175">説明</span><span class="sxs-lookup"><span data-stu-id="5a884-175">Description</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p><span data-ttu-id="5a884-176">「<a href="https://msdn.microsoft.com/library/windows/desktop/ee415779">XAudio2 を初期化します。</a></span><span class="sxs-lookup"><span data-stu-id="5a884-176"><a href="https://msdn.microsoft.com/library/windows/desktop/ee415779">How to: Initialize XAudio2</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="5a884-177">XAudio2 エンジンのインスタンスを作成してからマスタリング ボイスを作成して、XAudio2 をオーディオ再生用に初期化する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="5a884-177">Learn how to initialize XAudio2 for audio playback by creating an instance of the XAudio2 engine, and creating a mastering voice.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="5a884-178">「<a href="https://msdn.microsoft.com/library/windows/desktop/ee415781">XAudio2 にオーディオ データ ファイルを読み込む</a></span><span class="sxs-lookup"><span data-stu-id="5a884-178"><a href="https://msdn.microsoft.com/library/windows/desktop/ee415781">How to: Load Audio Data Files in XAudio2</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="5a884-179">XAudio2 でオーディオ データを再生するために必要な構造体を設定する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="5a884-179">Learn how to populate the structures required to play audio data in XAudio2.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="5a884-180">「<a href="https://msdn.microsoft.com/library/windows/desktop/ee415787">XAudio2 で音を鳴らす</a></span><span class="sxs-lookup"><span data-stu-id="5a884-180"><a href="https://msdn.microsoft.com/library/windows/desktop/ee415787">How to: Play a Sound with XAudio2</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="5a884-181">XAudio2 で以前読み込まれたオーディオ データを再生する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="5a884-181">Learn how to play previously-loaded audio data in XAudio2.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="5a884-182">「<a href="https://msdn.microsoft.com/library/windows/desktop/ee415794">サブミックス ボイスを使用します。</a></span><span class="sxs-lookup"><span data-stu-id="5a884-182"><a href="https://msdn.microsoft.com/library/windows/desktop/ee415794">How to: Use Submix Voices</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="5a884-183">ボイス グループを設定して、その出力を同じサブミックス ボイスに送信する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="5a884-183">Learn how to set groups of voices to send their output to the same submix voice.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="5a884-184">「<a href="https://msdn.microsoft.com/library/windows/desktop/ee415769">ソースの音声のコールバックを使用します。</a></span><span class="sxs-lookup"><span data-stu-id="5a884-184"><a href="https://msdn.microsoft.com/library/windows/desktop/ee415769">How to: Use Source Voice Callbacks</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="5a884-185">XAudio2 のソース ボイスのコールバックを使う方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="5a884-185">Learn how to use XAudio2 source voice callbacks.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="5a884-186">「<a href="https://msdn.microsoft.com/library/windows/desktop/ee415774">エンジンのコールバックを使用します。</a></span><span class="sxs-lookup"><span data-stu-id="5a884-186"><a href="https://msdn.microsoft.com/library/windows/desktop/ee415774">How to: Use Engine Callbacks</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="5a884-187">XAudio2 のエンジン コールバックを使う方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="5a884-187">Learn how to use XAudio2 engine callbacks.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="5a884-188">「<a href="https://msdn.microsoft.com/library/windows/desktop/ee415767">オーディオ処理の基本的なグラフを作成します。</a></span><span class="sxs-lookup"><span data-stu-id="5a884-188"><a href="https://msdn.microsoft.com/library/windows/desktop/ee415767">How to: Build a Basic Audio Processing Graph</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="5a884-189">単一のマスタリング ボイスと単一のソース ボイスから構築されたオーディオ処理グラフを作る方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="5a884-189">Learn how to create an audio processing graph, constructed from a single mastering voice and a single source voice.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="5a884-190">「<a href="https://msdn.microsoft.com/library/windows/desktop/ee415772">動的に追加またはオーディオのグラフからの音声を削除します。</a></span><span class="sxs-lookup"><span data-stu-id="5a884-190"><a href="https://msdn.microsoft.com/library/windows/desktop/ee415772">How to: Dynamically Add or Remove Voices From an Audio Graph</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="5a884-191">追加または」の手順に従って作成されているグラフからサブミックス音声を削除する方法について説明します<a href="https://msdn.microsoft.com/library/windows/desktop/ee415767">方法。ビルドのオーディオ処理の基本的なグラフ</a>します。</span><span class="sxs-lookup"><span data-stu-id="5a884-191">Learn how to add or remove submix voices from a graph that has been created following the steps in <a href="https://msdn.microsoft.com/library/windows/desktop/ee415767">How to: Build a Basic Audio Processing Graph</a>.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="5a884-192">「<a href="https://msdn.microsoft.com/library/windows/desktop/ee415789">効果チェーンを作成します。</a></span><span class="sxs-lookup"><span data-stu-id="5a884-192"><a href="https://msdn.microsoft.com/library/windows/desktop/ee415789">How to: Create an Effect Chain</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="5a884-193">エフェクト チェーンをボイスに適用して、そのボイスのオーディオ データに対してカスタム処理を加える方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="5a884-193">Learn how to apply an effect chain to a voice to allow custom processing of the audio data for that voice.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="5a884-194">「<a href="https://msdn.microsoft.com/library/windows/desktop/ee415730">作成、XAPO</a></span><span class="sxs-lookup"><span data-stu-id="5a884-194"><a href="https://msdn.microsoft.com/library/windows/desktop/ee415730">How to: Create an XAPO</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="5a884-195">XAudio2 オーディオ処理オブジェクト (XAPO) を作るために <a href="https://msdn.microsoft.com/library/windows/desktop/ee415893"><strong>IXAPO</strong></a> を実装する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="5a884-195">Learn how to implement <a href="https://msdn.microsoft.com/library/windows/desktop/ee415893"><strong>IXAPO</strong></a> to create an XAudio2 audio processing object (XAPO).</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="5a884-196">「<a href="https://msdn.microsoft.com/library/windows/desktop/ee415728">実行時のパラメーターのサポート、XAPO を追加します。</a></span><span class="sxs-lookup"><span data-stu-id="5a884-196"><a href="https://msdn.microsoft.com/library/windows/desktop/ee415728">How to: Add Run-time Parameter Support to an XAPO</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="5a884-197"><a href="https://msdn.microsoft.com/library/windows/desktop/ee415896">  <strong>IXAPOParameters</strong></a> インターフェイスを実装して XAPO にランタイム パラメーター サポートを追加する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="5a884-197">Learn how to add run-time parameter support to an XAPO by implementing the <a href="https://msdn.microsoft.com/library/windows/desktop/ee415896"><strong>IXAPOParameters</strong></a> interface.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="5a884-198">「<a href="https://msdn.microsoft.com/library/windows/desktop/ee415733">XAudio2 で、XAPO を使用します。</a></span><span class="sxs-lookup"><span data-stu-id="5a884-198"><a href="https://msdn.microsoft.com/library/windows/desktop/ee415733">How to: Use an XAPO in XAudio2</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="5a884-199">XAudio2 のエフェクト チェーンで XAPO を使って実装されるエフェクトを使う方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="5a884-199">Learn how to use an effect implemented as an XAPO in an XAudio2 effect chain.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="5a884-200">「<a href="https://msdn.microsoft.com/library/windows/desktop/ee415723">XAPOFX XAudio2 での使用</a></span><span class="sxs-lookup"><span data-stu-id="5a884-200"><a href="https://msdn.microsoft.com/library/windows/desktop/ee415723">How to: Use XAPOFX in XAudio2</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="5a884-201">XAudio2 のエフェクト チェーンで XAPOFX に含まれるエフェクトの 1 つを使う方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="5a884-201">Learn how to use one of the effects included in XAPOFX in an XAudio2 effect chain.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="5a884-202">「<a href="https://msdn.microsoft.com/library/windows/desktop/ee415791">ディスクからのサウンドを Stream</a></span><span class="sxs-lookup"><span data-stu-id="5a884-202"><a href="https://msdn.microsoft.com/library/windows/desktop/ee415791">How to: Stream a Sound from Disk</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="5a884-203">オーディオ バッファーの読み取り用に別のスレッドを作って XAudio2 でオーディオ データをストリームし、コールバックを使ってそのスレッドを制御する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="5a884-203">Learn how to stream audio data in XAudio2 by creating a separate thread to read an audio buffer, and to use callbacks to control that thread.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="5a884-204">「<a href="https://msdn.microsoft.com/library/windows/desktop/ee415798">XAudio2 X3DAudio と統合します。</a></span><span class="sxs-lookup"><span data-stu-id="5a884-204"><a href="https://msdn.microsoft.com/library/windows/desktop/ee415798">How to: Integrate X3DAudio with XAudio2</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="5a884-205">X3DAudio を使ってXAudio2 のボイスの音量やピッチの値、XAudio2 内蔵のリバーブ エフェクトのパラメーターを指定する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="5a884-205">Learn how to use X3DAudio to provide the volume and pitch values for XAudio2 voices as well as the parameters for the XAudio2 built-in reverb effect.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="5a884-206">「<a href="https://msdn.microsoft.com/library/windows/desktop/ee415783">操作セットとしてグループ オーディオ メソッド</a></span><span class="sxs-lookup"><span data-stu-id="5a884-206"><a href="https://msdn.microsoft.com/library/windows/desktop/ee415783">How to: Group Audio Methods as an Operation Set</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="5a884-207">XAudio2 の操作セットを使ってメソッドをグループ化し、これらのメソッドを同時に有効にする方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="5a884-207">Learn how to use XAudio2 operation sets to make a group of method calls take effect at the same time.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="5a884-208"><a href="https://msdn.microsoft.com/library/windows/desktop/ee415765">XAudio2 のオーディオの故障のデバッグ</a></span><span class="sxs-lookup"><span data-stu-id="5a884-208"><a href="https://msdn.microsoft.com/library/windows/desktop/ee415765">Debugging Audio Glitches in XAudio2</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="5a884-209">XAudio2 のデバッグ ログ レベルを設定する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="5a884-209">Learn how to set the debug logging level for XAudio2.</span></span></p></td>
</tr>
</tbody>
</table>

 

### <a name="media-foundation-resources"></a><span data-ttu-id="5a884-210">メディア ファンデーションに関するリソース</span><span class="sxs-lookup"><span data-stu-id="5a884-210">Media Foundation resources</span></span>

<span data-ttu-id="5a884-211">メディア ファンデーション (MF) は、ストリーミング オーディオやビデオの再生用のメディア プラットフォームです。</span><span class="sxs-lookup"><span data-stu-id="5a884-211">Media Foundation (MF) is a media platform for streaming audio and video playback.</span></span> <span data-ttu-id="5a884-212">メディア ファンデーション API を使って、さまざまなアルゴリズムでエンコードされ圧縮されたオーディオやビデオをストリーミングできます。</span><span class="sxs-lookup"><span data-stu-id="5a884-212">You can use the Media Foundation APIs to stream audio and video encoded and compressed with a variety of algorithms.</span></span> <span data-ttu-id="5a884-213">リアルタイムのゲームプレイ シナリオ向けには設計されていませんが、オーディオやビデオのコンポーネントのさらなるリニア キャプチャとプレゼンテーションのための、強力なツールと広範なコーデック サポートを提供します。</span><span class="sxs-lookup"><span data-stu-id="5a884-213">It is not designed for real-time gameplay scenarios; instead, it provides powerful tools and broad codec support for more linear capture and presentation of audio and video components.</span></span>

<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="5a884-214">トピック</span><span class="sxs-lookup"><span data-stu-id="5a884-214">Topic</span></span></th>
<th align="left"><span data-ttu-id="5a884-215">説明</span><span class="sxs-lookup"><span data-stu-id="5a884-215">Description</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p><span data-ttu-id="5a884-216"><a href="https://msdn.microsoft.com/library/windows/desktop/ms696274">メディア ファンデーションについて</a></span><span class="sxs-lookup"><span data-stu-id="5a884-216"><a href="https://msdn.microsoft.com/library/windows/desktop/ms696274">About Media Foundation</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="5a884-217">このセクションでは、メディア ファンデーション API とメディア ファンデーション API をサポートするために使用可能なツールに関する一般的な情報について説明します。</span><span class="sxs-lookup"><span data-stu-id="5a884-217">This section contains general information about the Media Foundation APIs, and the tools available to support them.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="5a884-218"><a href="https://msdn.microsoft.com/library/windows/desktop/ee663601">メディア ファンデーション:基本的な概念</a></span><span class="sxs-lookup"><span data-stu-id="5a884-218"><a href="https://msdn.microsoft.com/library/windows/desktop/ee663601">Media Foundation: Essential Concepts</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="5a884-219">メディア ファンデーション アプリケーションを作る前に知っておく必要がある概念をいくつか紹介します。</span><span class="sxs-lookup"><span data-stu-id="5a884-219">This topic introduces some concepts that you will need to understand before writing a Media Foundation application.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="5a884-220"><a href="https://msdn.microsoft.com/library/windows/desktop/ms696219">Media Foundation のアーキテクチャ</a></span><span class="sxs-lookup"><span data-stu-id="5a884-220"><a href="https://msdn.microsoft.com/library/windows/desktop/ms696219">Media Foundation Architecture</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="5a884-221">Microsoft メディア ファンデーションの一般的な設計と、Microsoft メディア ファンデーションで使われるメディア プリミティブと処理パイプラインについて説明します。</span><span class="sxs-lookup"><span data-stu-id="5a884-221">This section describes the general design of Microsoft Media Foundation, as well as the media primitives and processing pipeline it uses.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="5a884-222"><a href="https://msdn.microsoft.com/library/windows/desktop/dd317910">オーディオ/ビデオのキャプチャ</a></span><span class="sxs-lookup"><span data-stu-id="5a884-222"><a href="https://msdn.microsoft.com/library/windows/desktop/dd317910">Audio/Video Capture</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="5a884-223">Microsoft メディア ファンデーションを使ってオーディオやビデオのキャプチャを実行する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="5a884-223">This topic describes how to use Microsoft Media Foundation to perform audio and video capture.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="5a884-224"><a href="https://msdn.microsoft.com/library/windows/desktop/dd317914">オーディオ/ビデオの再生</a></span><span class="sxs-lookup"><span data-stu-id="5a884-224"><a href="https://msdn.microsoft.com/library/windows/desktop/dd317914">Audio/Video Playback</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="5a884-225">アプリでオーディオ/ビデオの再生を実装する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="5a884-225">This topic describes how to implement audio/video playback in your app.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="5a884-226"><a href="https://msdn.microsoft.com/library/windows/desktop/dd757927">メディア ファンデーションのメディア形式をサポート</a></span><span class="sxs-lookup"><span data-stu-id="5a884-226"><a href="https://msdn.microsoft.com/library/windows/desktop/dd757927">Supported Media Formats in Media Foundation</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="5a884-227">Microsoft メディア ファンデーションでネイティブ サポートされるメディア形式を一覧します</span><span class="sxs-lookup"><span data-stu-id="5a884-227">This topic lists the media formats that Microsoft Media Foundation supports natively.</span></span> <span data-ttu-id="5a884-228">(サード パーティによっては、カスタム プラグインを作ることによって、追加の形式をサポートできます)。</span><span class="sxs-lookup"><span data-stu-id="5a884-228">(Third parties can support additional formats by writing custom plug-ins.)</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="5a884-229"><a href="https://msdn.microsoft.com/library/windows/desktop/dd318778">エンコーディングとファイルの作成</a></span><span class="sxs-lookup"><span data-stu-id="5a884-229"><a href="https://msdn.microsoft.com/library/windows/desktop/dd318778">Encoding and File Authoring</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="5a884-230">Microsoft メディア ファンデーションを使ってオーディオやビデオのエンコード、メディア ファイルのオーサリングを実行する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="5a884-230">This topic describes how to use Microsoft Media Foundation to perform audio and video encoding, and author media files.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="5a884-231"><a href="https://msdn.microsoft.com/library/windows/desktop/ff819508">Windows Media コーデック</a></span><span class="sxs-lookup"><span data-stu-id="5a884-231"><a href="https://msdn.microsoft.com/library/windows/desktop/ff819508">Windows Media Codecs</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="5a884-232">Windows Media オーディオおよびビデオのコーデックが備えている機能を使い、圧縮されたデータ ストリームを生成、消費する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="5a884-232">This topic describes how to use the features of the Windows Media Audio and Video codecs to produce and consume compressed data streams.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="5a884-233"><a href="https://msdn.microsoft.com/library/windows/desktop/ms704847">Media Foundation のプログラミング リファレンス</a></span><span class="sxs-lookup"><span data-stu-id="5a884-233"><a href="https://msdn.microsoft.com/library/windows/desktop/ms704847">Media Foundation Programming Reference</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="5a884-234">メディア ファンデーション API のリファレンス情報です。</span><span class="sxs-lookup"><span data-stu-id="5a884-234">This section contains reference information for the Media Foundation APIs.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="5a884-235"><a href="https://msdn.microsoft.com/library/windows/desktop/aa371827">Media Foundation SDK のサンプル</a></span><span class="sxs-lookup"><span data-stu-id="5a884-235"><a href="https://msdn.microsoft.com/library/windows/desktop/aa371827">Media Foundation SDK Samples</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="5a884-236">メディア ファンデーションを使う方法について示すサンプル アプリの一覧です。</span><span class="sxs-lookup"><span data-stu-id="5a884-236">This section lists sample apps that demonstrate how to use Media Foundation.</span></span></p></td>
</tr>
</tbody>
</table>

 

### <a name="windows-runtime-xaml-media-types"></a><span data-ttu-id="5a884-237">Windows ランタイム XAML メディア タイプ</span><span class="sxs-lookup"><span data-stu-id="5a884-237">Windows Runtime XAML media types</span></span>

<span data-ttu-id="5a884-238">[DirectX と XAML の相互運用機能](https://msdn.microsoft.com/library/windows/apps/hh825871)を使っている場合は、DirectX と C++ で Windows ランタイム XAML メディア API を UWP アプリに組み込み、ゲーム シナリオを簡素化することができます。</span><span class="sxs-lookup"><span data-stu-id="5a884-238">If you are using [DirectX-XAML interop](https://msdn.microsoft.com/library/windows/apps/hh825871), you can incorporate the Windows Runtime XAML media APIs into your UWP apps using DirectX with C++ for simpler game scenarios.</span></span>

<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="5a884-239">トピック</span><span class="sxs-lookup"><span data-stu-id="5a884-239">Topic</span></span></th>
<th align="left"><span data-ttu-id="5a884-240">説明</span><span class="sxs-lookup"><span data-stu-id="5a884-240">Description</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p><span data-ttu-id="5a884-241"><a href="https://msdn.microsoft.com/library/windows/apps/br242926"><strong>Windows.UI.Xaml.Controls.MediaElement</strong></a></span><span class="sxs-lookup"><span data-stu-id="5a884-241"><a href="https://msdn.microsoft.com/library/windows/apps/br242926"><strong>Windows.UI.Xaml.Controls.MediaElement</strong></a></span></span></p></td>
<td align="left"><p><span data-ttu-id="5a884-242">オーディオ、ビデオ、またはその両方を格納するオブジェクトを表す XAML 要素です。</span><span class="sxs-lookup"><span data-stu-id="5a884-242">XAML element that represents an object that contains audio, video, or both.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="5a884-243"><a href="https://msdn.microsoft.com/library/windows/apps/mt203788">オーディオ、ビデオ、およびカメラ</a></span><span class="sxs-lookup"><span data-stu-id="5a884-243"><a href="https://msdn.microsoft.com/library/windows/apps/mt203788">Audio, video, and camera</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="5a884-244">ユニバーサル Windows プラットフォーム (UWP) アプリに基本的なオーディオやビデオを組み込む方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="5a884-244">Learn how to incorporate basic audio and video in your Universal Windows Platform (UWP) app.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="5a884-245"><a href="https://msdn.microsoft.com/library/windows/apps/mt187272">MediaElement</a></span><span class="sxs-lookup"><span data-stu-id="5a884-245"><a href="https://msdn.microsoft.com/library/windows/apps/mt187272">MediaElement</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="5a884-246">UWP アプリでローカルに保存されているメディア ファイルを再生する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="5a884-246">Learn how to play a locally-stored media file in your UWP app.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="5a884-247"><a href="https://msdn.microsoft.com/library/windows/apps/mt187272">MediaElement</a></span><span class="sxs-lookup"><span data-stu-id="5a884-247"><a href="https://msdn.microsoft.com/library/windows/apps/mt187272">MediaElement</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="5a884-248">UWP アプリにメディア ファイルを低遅延でストリーミングする方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="5a884-248">Learn how to stream a media file with low-latency in your UWP app.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="5a884-249"><a href="https://msdn.microsoft.com/library/windows/apps/mt282143">メディアのキャスト</a></span><span class="sxs-lookup"><span data-stu-id="5a884-249"><a href="https://msdn.microsoft.com/library/windows/apps/mt282143">Media casting</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="5a884-250">リモート再生コントラクトを使って、UWP アプリから別のデバイスへメディアをストリーミングする方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="5a884-250">Learn how to use the Play To contract to stream media from your UWP app to another device.</span></span></p></td>
</tr>
</tbody>
</table>

 

## <a name="reference"></a><span data-ttu-id="5a884-251">リファレンス</span><span class="sxs-lookup"><span data-stu-id="5a884-251">Reference</span></span>


-   [<span data-ttu-id="5a884-252">XAudio2 の概要</span><span class="sxs-lookup"><span data-stu-id="5a884-252">XAudio2 Introduction</span></span>](https://msdn.microsoft.com/library/windows/desktop/ee415813)
-   [<span data-ttu-id="5a884-253">XAudio2 プログラミング ガイド</span><span class="sxs-lookup"><span data-stu-id="5a884-253">XAudio2 Programming Guide</span></span>](https://msdn.microsoft.com/library/windows/desktop/ee415737)
-   [<span data-ttu-id="5a884-254">Microsoft Media Foundation の概要</span><span class="sxs-lookup"><span data-stu-id="5a884-254">Microsoft Media Foundation overview</span></span>](https://msdn.microsoft.com/library/windows/desktop/ms694197)

 

## <a name="related-topics"></a><span data-ttu-id="5a884-255">関連トピック</span><span class="sxs-lookup"><span data-stu-id="5a884-255">Related topics</span></span>


-   [<span data-ttu-id="5a884-256">XAudio2 プログラミング ガイド</span><span class="sxs-lookup"><span data-stu-id="5a884-256">XAudio2 Programming Guide</span></span>](https://msdn.microsoft.com/library/windows/desktop/ee415737)

 

 




