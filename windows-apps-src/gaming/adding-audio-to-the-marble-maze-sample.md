---
author: eliotcowley
title: Marble Maze のサンプルへのオーディオの追加
description: このドキュメントでは、オーディオを扱う際に考慮する必要のある主な手法について説明すると共に、それらが Marble Maze でどのように適用されているかを紹介します。
ms.assetid: 77c23d0a-af6d-17b5-d69e-51d9885b0d44
ms.author: elcowle
ms.date: 10/18/2017
ms.topic: article
keywords: Windows 10, UWP, オーディオ, ゲーム, サンプル
ms.localizationpriority: medium
ms.openlocfilehash: 89612e3fbc4ef2ccb855f7709820f9445d0fd77c
ms.sourcegitcommit: 6cc275f2151f78db40c11ace381ee2d35f0155f9
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/25/2018
ms.locfileid: "5546862"
---
# <a name="adding-audio-to-the-marble-maze-sample"></a><span data-ttu-id="c8403-104">Marble Maze のサンプルへのオーディオの追加</span><span class="sxs-lookup"><span data-stu-id="c8403-104">Adding audio to the Marble Maze sample</span></span>

<span data-ttu-id="c8403-105">このドキュメントでは、オーディオを扱う際に考慮する必要のある主な手法について説明すると共に、それらが Marble Maze でどのように適用されているかを紹介します。</span><span class="sxs-lookup"><span data-stu-id="c8403-105">This document describes the key practices to consider when you work with audio and shows how Marble Maze applies these practices.</span></span> <span data-ttu-id="c8403-106">Marble Maze は、[Microsoft メディア ファンデーション](https://msdn.microsoft.com/library/windows/desktop/ms694197)を使ってオーディオ リソースをファイルから読み込みます。また、オーディオのミキシングと再生、効果の適用は、[XAudio2](https://msdn.microsoft.com/library/windows/desktop/hh405049) を使って行います。</span><span class="sxs-lookup"><span data-stu-id="c8403-106">Marble Maze uses [Microsoft Media Foundation](https://msdn.microsoft.com/library/windows/desktop/ms694197) to load audio resources from files, and [XAudio2](https://msdn.microsoft.com/library/windows/desktop/hh405049) to mix and play audio and to apply effects to audio.</span></span>

<span data-ttu-id="c8403-107">Marble Maze は、バックグラウンドで再生する音楽に加え、ゲームのイベント (大理石が壁に当たったときなど) を示すゲームプレイ音を使っています。</span><span class="sxs-lookup"><span data-stu-id="c8403-107">Marble Maze plays music in the background, and also uses gameplay sounds to indicate game events, such as when the marble hits a wall.</span></span> <span data-ttu-id="c8403-108">実装で重要となる部分は、大理石がバウンドする音をシミュレートするためにリバーブ (反響) エフェクトを使っている点です。</span><span class="sxs-lookup"><span data-stu-id="c8403-108">An important part of the implementation is that Marble Maze uses a reverb, or echo, effect to simulate the sound of a marble when it bounces.</span></span> <span data-ttu-id="c8403-109">リバーブ エフェクトを実装すると、小さい空間では反響音がより早く大きい音量で聞こえ、大きい空間では反響音がより遅く小さい音量で聞こえるようになります。</span><span class="sxs-lookup"><span data-stu-id="c8403-109">The reverb effect implementation causes echoes to reach you more quickly and loudly in small rooms; echoes are quieter and reach you more slowly in larger rooms.</span></span>

> [!NOTE]
> <span data-ttu-id="c8403-110">このドキュメントに対応するサンプル コードは、[DirectX Marble Maze ゲームのサンプルに関するページ](http://go.microsoft.com/fwlink/?LinkId=624011)にあります。</span><span class="sxs-lookup"><span data-stu-id="c8403-110">The sample code that corresponds to this document is found in the [DirectX Marble Maze game sample](http://go.microsoft.com/fwlink/?LinkId=624011).</span></span>

<span data-ttu-id="c8403-111">このドキュメントでは、ゲームでオーディオを扱う際に重要となるいくつかの事柄について説明します。取り上げる内容は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="c8403-111">Here are some of the key points that this document discusses for when you work with audio in your game:</span></span>

- <span data-ttu-id="c8403-112">オーディオ アセットのデコードにはメディア ファンデーションを使い、オーディオの再生には XAudio2 を使います。</span><span class="sxs-lookup"><span data-stu-id="c8403-112">Consider using Media Foundation to decode audio assets and XAudio2 to play audio.</span></span> <span data-ttu-id="c8403-113">ただし、オーディオ アセットを読み込むための機構が既にあり、ユニバーサル Windows プラットフォーム (UWP) アプリで正常に動作する場合は、それを使ってかまいません。</span><span class="sxs-lookup"><span data-stu-id="c8403-113">However, if you have an existing audio asset-loading mechanism that works in a Universal Windows Platform (UWP) app, you can use it.</span></span>

- <span data-ttu-id="c8403-114">オーディオ グラフは、アクティブなサウンド 1 つにつき 1 つのソース ボイス、0 個以上のサブミックス ボイス、1 つのマスタリング ボイスを含んでいます。</span><span class="sxs-lookup"><span data-stu-id="c8403-114">An audio graph contains one source voice for each active sound, zero or more submix voices, and one mastering voice.</span></span> <span data-ttu-id="c8403-115">ソース ボイスは、サブミックス ボイスまたはマスタリング ボイス (あるいはその両方) に送ることができます。</span><span class="sxs-lookup"><span data-stu-id="c8403-115">Source voices can feed into submix voices and/or the mastering voice.</span></span> <span data-ttu-id="c8403-116">サブミックス ボイスは、他のサブミックス ボイスか、マスタリング ボイスに送られます。</span><span class="sxs-lookup"><span data-stu-id="c8403-116">Submix voices feed into other submix voices or the mastering voice.</span></span>

- <span data-ttu-id="c8403-117">BGM ファイルが大きい場合は、メモリの使用量を抑えるために、より小さいバッファーに音楽をストリーミングします。</span><span class="sxs-lookup"><span data-stu-id="c8403-117">If your background music files are large, consider streaming your music into smaller buffers so that less memory is used.</span></span>

- <span data-ttu-id="c8403-118">状況 (アプリがフォーカスを失った、表示されなくなった、中断されたなど) に応じてオーディオの再生を一時停止します。</span><span class="sxs-lookup"><span data-stu-id="c8403-118">If it makes sense to do so, pause audio playback when the app loses focus or visibility, or is suspended.</span></span> <span data-ttu-id="c8403-119">アプリが再びフォーカスを取得するか、表示されるか、再開されたら、再生を再開します。</span><span class="sxs-lookup"><span data-stu-id="c8403-119">Resume playback when your app regains focus, becomes visible, or is resumed.</span></span>

- <span data-ttu-id="c8403-120">オーディオのカテゴリは、各サウンドの役割を反映するように設定します。</span><span class="sxs-lookup"><span data-stu-id="c8403-120">Set audio categories to reflect the role of each sound.</span></span> <span data-ttu-id="c8403-121">たとえば、ゲームのバックグラウンド オーディオには **AudioCategory\_GameMedia** を使い、サウンド効果には **AudioCategory\_GameEffects** を使うのが一般的です。</span><span class="sxs-lookup"><span data-stu-id="c8403-121">For example, you typically use **AudioCategory\_GameMedia** for game background audio and **AudioCategory\_GameEffects** for sound effects.</span></span>

- <span data-ttu-id="c8403-122">ヘッドホンなどのデバイスの変更は、オーディオ リソースとインターフェイスをすべて解放し、再作成することによって処理します。</span><span class="sxs-lookup"><span data-stu-id="c8403-122">Handle device changes, including headphones, by releasing and recreating all audio resources and interfaces.</span></span>

- <span data-ttu-id="c8403-123">ディスク領域とストリーミングのコストを最小限に抑える必要がある場合は、オーディオ ファイルを圧縮します。</span><span class="sxs-lookup"><span data-stu-id="c8403-123">Consider whether to compress audio files when minimizing disk space and streaming costs is a requirement.</span></span> <span data-ttu-id="c8403-124">それ以外の場合は、オーディオを圧縮しない方が、読み込み速度が高くなります。</span><span class="sxs-lookup"><span data-stu-id="c8403-124">Otherwise, you can leave audio uncompressed so that it loads faster.</span></span>

## <a name="introducing-xaudio2-and-microsoft-media-foundation"></a><span data-ttu-id="c8403-125">XAudio2 と Microsoft メディア ファンデーションの概要</span><span class="sxs-lookup"><span data-stu-id="c8403-125">Introducing XAudio2 and Microsoft Media Foundation</span></span>

<span data-ttu-id="c8403-126">XAudio2 は、ゲームのオーディオ サポートに特化した Windows 向けの低水準オーディオ ライブラリです。</span><span class="sxs-lookup"><span data-stu-id="c8403-126">XAudio2 is a low-level audio library for Windows that specifically supports game audio.</span></span> <span data-ttu-id="c8403-127">ゲーム用のデジタル シグナル処理 (DSP) やオーディオ グラフ エンジンを備えています。</span><span class="sxs-lookup"><span data-stu-id="c8403-127">It provides a digital signal processing (DSP) and audio-graph engine for games.</span></span> <span data-ttu-id="c8403-128">XAudio2 は前身の DirectSound と XAudio を拡張したものであり、SIMD 浮動小数点アーキテクチャや HD オーディオなどのコンピューター トレンドをサポートします。</span><span class="sxs-lookup"><span data-stu-id="c8403-128">XAudio2 expands on its predecessors, DirectSound and XAudio, by supporting computing trends such as SIMD floating-point architectures and HD audio.</span></span> <span data-ttu-id="c8403-129">また、今日のゲームに求められる複雑なサウンド処理のニーズにも対応します。</span><span class="sxs-lookup"><span data-stu-id="c8403-129">It also supports the more complex sound processing demands of today’s games.</span></span>

<span data-ttu-id="c8403-130">ドキュメント「[XAudio2 の主要な概念](https://msdn.microsoft.com/library/windows/desktop/ee415764)」では、XAudio2 を使ううえでの重要な概念について説明しています。</span><span class="sxs-lookup"><span data-stu-id="c8403-130">The document [XAudio2 Key Concepts](https://msdn.microsoft.com/library/windows/desktop/ee415764) explains the key concepts for using XAudio2.</span></span> <span data-ttu-id="c8403-131">その要点は以下のとおりです。</span><span class="sxs-lookup"><span data-stu-id="c8403-131">In brief, the concepts are:</span></span>

- <span data-ttu-id="c8403-132">[IXAudio2](https://msdn.microsoft.com/library/windows/desktop/ee415908) エンジンのコアは IXAudio2 インターフェイス。</span><span class="sxs-lookup"><span data-stu-id="c8403-132">The [IXAudio2](https://msdn.microsoft.com/library/windows/desktop/ee415908) interface is the core of the XAudio2 engine.</span></span> <span data-ttu-id="c8403-133">Marble Maze は、このインターフェイスを使って音声を作成します。また、出力デバイスの変更時や障害発生時の通知も、このインターフェイスを使って受け取ります。</span><span class="sxs-lookup"><span data-stu-id="c8403-133">Marble Maze uses this interface to create voices and to receive notification when the output device changes or fails.</span></span>

- <span data-ttu-id="c8403-134">オーディオ データは**ボイス**によって処理、調整、再生される。</span><span class="sxs-lookup"><span data-stu-id="c8403-134">A **voice** processes, adjusts, and plays audio data.</span></span>

- <span data-ttu-id="c8403-135">**ソース ボイス**はオーディオ チャネル (モノラル、5.1 など) のコレクションであり、オーディオ データの 1 つのストリームを表す。</span><span class="sxs-lookup"><span data-stu-id="c8403-135">A **source voice** is a collection of audio channels (mono, 5.1, and so on) and represents one stream of audio data.</span></span> <span data-ttu-id="c8403-136">XAudio2 では、ソース ボイスがオーディオ処理の開始点になります。</span><span class="sxs-lookup"><span data-stu-id="c8403-136">In XAudio2, a source voice is where audio processing begins.</span></span> <span data-ttu-id="c8403-137">通常、サウンド データは、ファイルやネットワークなどの外部ソースから読み込まれて、ソース ボイスに送られます。</span><span class="sxs-lookup"><span data-stu-id="c8403-137">Typically, sound data is loaded from an external source, such as a file or a network, and is sent to a source voice.</span></span> <span data-ttu-id="c8403-138">Marble Maze は、[メディア ファンデーション](https://msdn.microsoft.com/library/windows/desktop/ms694197) を使って、サウンド データをファイルから読み込みます。</span><span class="sxs-lookup"><span data-stu-id="c8403-138">Marble Maze uses [Media Foundation](https://msdn.microsoft.com/library/windows/desktop/ms694197) to load sound data from files.</span></span> <span data-ttu-id="c8403-139">メディア ファンデーションについては、この後で説明します。</span><span class="sxs-lookup"><span data-stu-id="c8403-139">Media Foundation is introduced later in this document.</span></span>

- <span data-ttu-id="c8403-140">**サブミックス ボイス**はオーディオ データの処理を行う。</span><span class="sxs-lookup"><span data-stu-id="c8403-140">A **submix voice** processes audio data.</span></span> <span data-ttu-id="c8403-141">たとえば、オーディオ ストリームに変更を加えたり、複数のストリームを 1 つにまとめたりすることができます。</span><span class="sxs-lookup"><span data-stu-id="c8403-141">This processing can include changing the audio stream or combining multiple streams into one.</span></span> <span data-ttu-id="c8403-142">Marble Maze は、サブミックスを使ってリバーブ エフェクトを作成しています。</span><span class="sxs-lookup"><span data-stu-id="c8403-142">Marble Maze uses submixes to create the reverb effect.</span></span>

- <span data-ttu-id="c8403-143">**マスタリング ボイス**は、ソース ボイスとサブミックス ボイスのデータを結合し、そのデータをオーディオ ハードウェアに送る。</span><span class="sxs-lookup"><span data-stu-id="c8403-143">A **mastering voice** combines data from source and submix voices and sends that data to the audio hardware.</span></span>

- <span data-ttu-id="c8403-144">**オーディオ グラフ**は、アクティブなサウンド 1 つにつき 1 つのソース ボイス、0 個以上のサブミックス ボイス、1 つのマスタリング ボイスを含んでいる。</span><span class="sxs-lookup"><span data-stu-id="c8403-144">An **audio graph** contains one source voice for each active sound, zero or more submix voices, and only one mastering voice.</span></span>

- <span data-ttu-id="c8403-145">ボイスまたはエンジン オブジェクト内でイベントが発生したことは、**コールバック**によってクライアント コードに通知される。</span><span class="sxs-lookup"><span data-stu-id="c8403-145">A **callback** informs client code that some event has occurred in a voice or in an engine object.</span></span> <span data-ttu-id="c8403-146">コールバックを使うことで、XAudio2 がバッファーを残して終了した場合にメモリを再利用したり、オーディオ デバイスが変更された場合 (ヘッドホンの接続時や切断時など) に対応したりできます。</span><span class="sxs-lookup"><span data-stu-id="c8403-146">By using callbacks, you can reuse memory when XAudio2 is finished with a buffer, react when the audio device changes (for example, when you connect or disconnect headphones), and more.</span></span> <span data-ttu-id="c8403-147">Marble Maze がこの機構を使ってデバイスの変更を処理するしくみについては、このドキュメントの「[ヘッドホンとデバイスの変更の処理](#handling-headphones-and-device-changes)」で説明します。</span><span class="sxs-lookup"><span data-stu-id="c8403-147">[Handling headphones and device changes](#handling-headphones-and-device-changes) later in this document explains how Marble Maze uses this mechanism to handle device changes.</span></span>

<span data-ttu-id="c8403-148">Marble Maze は、2 つのオーディオ エンジン (つまり、2 つの [IXAudio2](https://msdn.microsoft.com/library/windows/desktop/ee415908) オブジェクト) を使ってオーディオを処理します。</span><span class="sxs-lookup"><span data-stu-id="c8403-148">Marble Maze uses two audio engines (in other words, two [IXAudio2](https://msdn.microsoft.com/library/windows/desktop/ee415908) objects) to process audio.</span></span> <span data-ttu-id="c8403-149">一方のエンジンが BGM を、もう一方のエンジンがゲームプレイ音を処理します。</span><span class="sxs-lookup"><span data-stu-id="c8403-149">One engine processes the background music, and the other engine processes gameplay sounds.</span></span>

<span data-ttu-id="c8403-150">また、各エンジンについて、マスタリング ボイスを 1 つ作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c8403-150">Marble Maze must also create one mastering voice for each engine.</span></span> <span data-ttu-id="c8403-151">既に説明したように、マスター エンジンはオーディオ ストリームを 1 つのストリームに結合し、そのストリームをオーディオ ハードウェアに送ります。</span><span class="sxs-lookup"><span data-stu-id="c8403-151">Recall that a mastering engine combines audio streams into one stream and sends that stream to the audio hardware.</span></span> <span data-ttu-id="c8403-152">BGM ストリーム (ソース ボイス) は、マスタリング ボイスと 2 つのサブミックス ボイスにデータを出力します。</span><span class="sxs-lookup"><span data-stu-id="c8403-152">The background music stream, a source voice, outputs data to a mastering voice and to two submix voices.</span></span> <span data-ttu-id="c8403-153">サブミックス ボイスはリバーブ エフェクトを実行します。</span><span class="sxs-lookup"><span data-stu-id="c8403-153">The submix voices perform the reverb effect.</span></span>

<span data-ttu-id="c8403-154">メディア ファンデーションは、さまざまなオーディオ形式とビデオ形式をサポートするマルチメディア ライブラリです。</span><span class="sxs-lookup"><span data-stu-id="c8403-154">Media Foundation is a multimedia library that supports many audio and video formats.</span></span> <span data-ttu-id="c8403-155">XAudio2 とメディア ファンデーションは相互補完的な関係にあります。</span><span class="sxs-lookup"><span data-stu-id="c8403-155">XAudio2 and Media Foundation complement each other.</span></span> <span data-ttu-id="c8403-156">Marble Maze は、メディア ファンデーションを使ってオーディオ アセットをファイルから読み込み、XAudio2 を使ってオーディオを再生しています。</span><span class="sxs-lookup"><span data-stu-id="c8403-156">Marble Maze uses Media Foundation to load audio assets from files and uses XAudio2 to play audio.</span></span> <span data-ttu-id="c8403-157">オーディオ アセットの読み込みに、必ずしもメディア ファンデーションを使う必要はありません。</span><span class="sxs-lookup"><span data-stu-id="c8403-157">You don't have to use Media Foundation to load audio assets.</span></span> <span data-ttu-id="c8403-158">オーディオ アセットを読み込むための機構が既にあり、ユニバーサル Windows プラットフォーム (UWP) アプリで正常に動作する場合は、それを使ってください。</span><span class="sxs-lookup"><span data-stu-id="c8403-158">If you have an existing audio asset loading mechanism that works in Universal Windows Platform (UWP) apps, use it.</span></span> <span data-ttu-id="c8403-159">UWP アプリでオーディオを実装するいくつかの方法については、「[オーディオ、ビデオ、およびカメラ](../audio-video-camera/index.md)」で説明します。</span><span class="sxs-lookup"><span data-stu-id="c8403-159">[Audio, video, and camera](../audio-video-camera/index.md) discusses several ways of implementing audio in a UWP app.</span></span>

<span data-ttu-id="c8403-160">XAudio2 について詳しくは、「[プログラミング ガイド](https://msdn.microsoft.com/library/windows/desktop/ee415737)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c8403-160">For more information about XAudio2, see [Programming Guide](https://msdn.microsoft.com/library/windows/desktop/ee415737).</span></span> <span data-ttu-id="c8403-161">メディア ファンデーションについて詳しくは、[Microsoft メディア ファンデーションに関するページ](https://msdn.microsoft.com/library/windows/desktop/ms694197) をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c8403-161">For more information about Media Foundation, see [Microsoft Media Foundation](https://msdn.microsoft.com/library/windows/desktop/ms694197).</span></span>

## <a name="initializing-audio-resources"></a><span data-ttu-id="c8403-162">オーディオ リソースの初期化</span><span class="sxs-lookup"><span data-stu-id="c8403-162">Initializing audio resources</span></span>

<span data-ttu-id="c8403-163">Marble Maze では、BGM に Windows Media オーディオ (.wma) ファイルが、ゲームプレイ音に WAV (.wav) ファイルが使われています。</span><span class="sxs-lookup"><span data-stu-id="c8403-163">Marble Mazes uses a Windows Media Audio (.wma) file for the background music, and WAV (.wav) files for gameplay sounds.</span></span> <span data-ttu-id="c8403-164">これらの形式は、メディア ファンデーションによってサポートされます。</span><span class="sxs-lookup"><span data-stu-id="c8403-164">These formats are supported by Media Foundation.</span></span> <span data-ttu-id="c8403-165">.wav ファイル形式は XAudio2 がネイティブにサポートしていますが、適切な XAudio2 データ構造体にデータを設定するためには、ゲーム内からファイル形式を手動で解析する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c8403-165">Although the .wav file format is natively supported by XAudio2, a game has to parse the file format manually to fill out the appropriate XAudio2 data structures.</span></span> <span data-ttu-id="c8403-166">メディア ファンデーションを使った方が簡単に .wav ファイルを扱うことができるため、Marble Maze ではメディア ファンデーションを使っています。</span><span class="sxs-lookup"><span data-stu-id="c8403-166">Marble Maze uses Media Foundation to more easily work with .wav files.</span></span> <span data-ttu-id="c8403-167">メディア ファンデーションでサポートされる全メディア形式の一覧については、「[メディア ファンデーションでサポートされるメディア形式](https://msdn.microsoft.com/library/windows/desktop/dd757927)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c8403-167">For the complete list of the media formats that are supported by Media Foundation, see [Supported Media Formats in Media Foundation](https://msdn.microsoft.com/library/windows/desktop/dd757927).</span></span> <span data-ttu-id="c8403-168">Marble Maze では、デザイン時と実行時に別々のオーディオ形式を使うことはしていません。また、XAudio2 でサポートされる ADPCM 圧縮機能は使っていません。</span><span class="sxs-lookup"><span data-stu-id="c8403-168">Marble Maze does not use separate design-time and run-time audio formats, and does not use XAudio2 ADPCM compression support.</span></span> <span data-ttu-id="c8403-169">XAudio2 の ADPCM 圧縮について詳しくは、「[ADPCM の概要](https://msdn.microsoft.com/library/windows/desktop/ee415711)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c8403-169">For more information about ADPCM compression in XAudio2, see [ADPCM Overview](https://msdn.microsoft.com/library/windows/desktop/ee415711).</span></span>

<span data-ttu-id="c8403-170">**MarbleMazeMain::LoadDeferredResources** から呼び出される **Audio::CreateResources** メソッドは、ファイルからオーディオ ストリームを読み込み、XAudio2 エンジン オブジェクトを初期化して、ソース ボイス、サブミックス ボイス、マスタリング ボイスを作成します。</span><span class="sxs-lookup"><span data-stu-id="c8403-170">The **Audio::CreateResources** method, which is called from **MarbleMazeMain::LoadDeferredResources**, loads the audio streams from the files, initializes the XAudio2 engine objects, and creates the source, submix, and mastering voices.</span></span>

### <a name="creating-the-xaudio2-engines"></a><span data-ttu-id="c8403-171">XAudio2 エンジンの作成</span><span class="sxs-lookup"><span data-stu-id="c8403-171">Creating the XAudio2 engines</span></span>

<span data-ttu-id="c8403-172">既に説明したように、Marble Maze では、オーディオ エンジンを表す [IXAudio2](https://msdn.microsoft.com/library/windows/desktop/ee415908) オブジェクト (使うオーディオ エンジンごとに 1 つ) を作成します。</span><span class="sxs-lookup"><span data-stu-id="c8403-172">Recall that Marble Maze creates one [IXAudio2](https://msdn.microsoft.com/library/windows/desktop/ee415908) object to represent each audio engine that it uses.</span></span> <span data-ttu-id="c8403-173">オーディオ エンジンを作成するには、[XAudio2Create](https://msdn.microsoft.com/library/windows/desktop/ee419212) メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="c8403-173">To create an audio engine, call the [XAudio2Create](https://msdn.microsoft.com/library/windows/desktop/ee419212) method.</span></span> <span data-ttu-id="c8403-174">BGM を処理するオーディオ エンジンの作成方法を次の例に示します。</span><span class="sxs-lookup"><span data-stu-id="c8403-174">The following example shows how Marble Maze creates the audio engine that processes background music.</span></span>

```cpp
// In Audio.h
class Audio
{
private:
    IXAudio2*                   m_musicEngine;
// ...
}

// In Audio.cpp
void Audio::CreateResources()
{
    try
    {
        // ...
        DX::ThrowIfFailed(
            XAudio2Create(&m_musicEngine)
            );
        // ...
    }
    // ...
}
```

<span data-ttu-id="c8403-175">ゲームプレイ音を再生するオーディオ エンジンについても、同様の手順で作成します。</span><span class="sxs-lookup"><span data-stu-id="c8403-175">Marble Maze performs a similar step to create the audio engine that plays gameplay sounds.</span></span>

<span data-ttu-id="c8403-176">UWP アプリでの [IXAudio2](https://msdn.microsoft.com/library/windows/desktop/ee415908) インターフェイスの扱いは、デスクトップ アプリの場合とは 2 つの点で異なります。</span><span class="sxs-lookup"><span data-stu-id="c8403-176">How to work with the [IXAudio2](https://msdn.microsoft.com/library/windows/desktop/ee415908) interface in a UWP app differs from a desktop app in two ways.</span></span> <span data-ttu-id="c8403-177">まず、[XAudio2Create](https://msdn.microsoft.com/library/windows/desktop/ee419212) を呼び出す前に、[CoInitializeEx](https://msdn.microsoft.com/library/windows/desktop/ms695279) を呼び出す必要はありません。</span><span class="sxs-lookup"><span data-stu-id="c8403-177">First, you don't have to call [CoInitializeEx](https://msdn.microsoft.com/library/windows/desktop/ms695279) before you call [XAudio2Create](https://msdn.microsoft.com/library/windows/desktop/ee419212).</span></span> <span data-ttu-id="c8403-178">また、**IXAudio2** では、デバイスの列挙がサポートされません。</span><span class="sxs-lookup"><span data-stu-id="c8403-178">In addition, **IXAudio2** no longer supports device enumeration.</span></span> <span data-ttu-id="c8403-179">オーディオ デバイスの列挙方法については、「[デバイスの列挙](https://msdn.microsoft.com/library/windows/apps/hh464977)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c8403-179">For information about how to enumerate audio devices, see [Enumerating devices](https://msdn.microsoft.com/library/windows/apps/hh464977).</span></span>

### <a name="creating-the-mastering-voices"></a><span data-ttu-id="c8403-180">マスタリング ボイスの作成</span><span class="sxs-lookup"><span data-stu-id="c8403-180">Creating the mastering voices</span></span>

<span data-ttu-id="c8403-181">以下の例では、**Audio::CreateResources** メソッドが [IXAudio2::CreateMasteringVoice](https://msdn.microsoft.com/library/windows/desktop/hh405048) メソッドを使って BGM のマスタリング ボイスを作成しています。</span><span class="sxs-lookup"><span data-stu-id="c8403-181">The following example shows how the **Audio::CreateResources** method creates the mastering voice for the background music using the [IXAudio2::CreateMasteringVoice](https://msdn.microsoft.com/library/windows/desktop/hh405048) method.</span></span> <span data-ttu-id="c8403-182">この例では、**m\_musicMasteringVoice** が [IXAudio2MasteringVoice](https://msdn.microsoft.com/library/windows/desktop/ee415912) オブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="c8403-182">In this example, **m\_musicMasteringVoice** is an [IXAudio2MasteringVoice](https://msdn.microsoft.com/library/windows/desktop/ee415912) object.</span></span> <span data-ttu-id="c8403-183">2 つの出力チャネルを指定しています。これにより、リバーブ エフェクトのロジックを単純化します。</span><span class="sxs-lookup"><span data-stu-id="c8403-183">We specify two input channels; this simplifies the logic for the reverb effect.</span></span> 

<span data-ttu-id="c8403-184">入力サンプル レートとして 48000 を指定します。</span><span class="sxs-lookup"><span data-stu-id="c8403-184">We specify 48000 as the input sample rate.</span></span> <span data-ttu-id="c8403-185">オーディオ品質と必要な CPU 処理量のバランスを考慮してこのサンプル レートを選びました。</span><span class="sxs-lookup"><span data-stu-id="c8403-185">We chose this sample rate because it represented a balance between audio quality and the amount of required CPU processing.</span></span> <span data-ttu-id="c8403-186">サンプル レートをこれより大きくしても、体感できるほどは品質が上がらず、必要な CPU 処理も増える可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c8403-186">A greater sample rate would have required more CPU processing without having a noticeable quality benefit.</span></span> 

<span data-ttu-id="c8403-187">最後に、オーディオ ストリームのカテゴリとして **AudioCategory\_GameMedia** を指定します。こうすることで、ゲームをプレイしている間、ユーザーは、異なるアプリケーションからの音楽を聴くことができます。</span><span class="sxs-lookup"><span data-stu-id="c8403-187">Finally, we specify **AudioCategory_GameMedia** as the audio stream category so that users can listen to music from a different application as they play the game.</span></span> <span data-ttu-id="c8403-188">音楽アプリの再生中、**AudioCategory\_GameMedia** オプションによって作成されたボイスはすべて Windows によってミュートされます。</span><span class="sxs-lookup"><span data-stu-id="c8403-188">When a music app is playing, Windows mutes any voices that are created by the **AudioCategory\_GameMedia** option.</span></span> <span data-ttu-id="c8403-189">その場合もゲームプレイ音は聞こえます。ゲームプレイ音は **AudioCategory\_GameEffects** オプションによって作成されているためです。</span><span class="sxs-lookup"><span data-stu-id="c8403-189">The user still hears gameplay sounds because they are created by the **AudioCategory\_GameEffects** option.</span></span> <span data-ttu-id="c8403-190">オーディオ カテゴリについて詳しくは、[AUDIO\_STREAM\_CATEGORY](https://msdn.microsoft.com/library/windows/desktop/hh404178) に関するページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c8403-190">For more info about audio categories, see [AUDIO\_STREAM\_CATEGORY](https://msdn.microsoft.com/library/windows/desktop/hh404178).</span></span>

```cpp
// This sample plays the equivalent of background music, which we tag on the  
// mastering voice as AudioCategory_GameMedia. In ordinary usage, if we were  
// playing the music track with no effects, we could route it entirely through 
// Media Foundation. Here, we are using XAudio2 to apply a reverb effect to the 
// music, so we use Media Foundation to decode the data then we feed it through 
// the XAudio2 pipeline as a separate Mastering Voice, so that we can tag it 
// as Game Media. We default the mastering voice to 2 channels to simplify  
// the reverb logic.
DX::ThrowIfFailed(
    m_musicEngine->CreateMasteringVoice(
        &m_musicMasteringVoice,
        2,
        48000,
        0,
        nullptr,
        nullptr,
        AudioCategory_GameMedia
        )
);
```

<span data-ttu-id="c8403-191">ゲームプレイ音についても、**Audio::CreateResources** メソッドを使い、同様の手順でマスタリング ボイスを作成しますが、*StreamCategory* パラメーターに **AudioCategory\_GameEffects** (既定値) が指定される点が異なります。</span><span class="sxs-lookup"><span data-stu-id="c8403-191">The **Audio::CreateResources** method performs a similar step to create the mastering voice for the gameplay sounds, except that it specifies **AudioCategory\_GameEffects** for the *StreamCategory* parameter, which is the default.</span></span>

### <a name="creating-the-reverb-effect"></a><span data-ttu-id="c8403-192">リバーブ エフェクトの作成</span><span class="sxs-lookup"><span data-stu-id="c8403-192">Creating the reverb effect</span></span>

<span data-ttu-id="c8403-193">それぞれのボイスには、オーディオを処理する一連の効果を XAudio2 を使って作成することができます。</span><span class="sxs-lookup"><span data-stu-id="c8403-193">For each voice, you can use XAudio2 to create sequences of effects that process audio.</span></span> <span data-ttu-id="c8403-194">そのような一連の効果をエフェクト チェーンと呼びます。</span><span class="sxs-lookup"><span data-stu-id="c8403-194">Such a sequence is known as an effect chain.</span></span> <span data-ttu-id="c8403-195">エフェクト チェーンは、1 つまたは複数の効果をボイスに適用するときに使います。</span><span class="sxs-lookup"><span data-stu-id="c8403-195">Use effect chains when you want to apply one or more effects to a voice.</span></span> <span data-ttu-id="c8403-196">エフェクト チェーンは破壊的に実行できます。つまり、チェーン内の各効果がオーディオ バッファーを上書きできます。</span><span class="sxs-lookup"><span data-stu-id="c8403-196">Effect chains can be destructive; that is, each effect in the chain can overwrite the audio buffer.</span></span> <span data-ttu-id="c8403-197">XAudio2 では出力バッファーが無音で初期化される保証がないため、この特性は重要です。</span><span class="sxs-lookup"><span data-stu-id="c8403-197">This property is important because XAudio2 makes no guarantee that output buffers are initialized with silence.</span></span> <span data-ttu-id="c8403-198">XAudio2 では、エフェクト オブジェクトが、XAPO (Cross-Platform Audio Processing Object) によって表されます。</span><span class="sxs-lookup"><span data-stu-id="c8403-198">Effect objects are represented in XAudio2 by cross-platform audio processing objects (XAPO).</span></span> <span data-ttu-id="c8403-199">XAPO について詳しくは、「[XAPO の概要](https://msdn.microsoft.com/library/windows/desktop/ee415735)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c8403-199">For more information about XAPO, see [XAPO Overview](https://msdn.microsoft.com/library/windows/desktop/ee415735).</span></span>

<span data-ttu-id="c8403-200">エフェクト チェーンを作成する際は、以下の手順に従います。</span><span class="sxs-lookup"><span data-stu-id="c8403-200">When you create an effect chain, follow these steps:</span></span>

1. <span data-ttu-id="c8403-201">エフェクト オブジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="c8403-201">Create the effect object.</span></span>

2. <span data-ttu-id="c8403-202">[XAUDIO2\_EFFECT\_DESCRIPTOR](https://msdn.microsoft.com/library/windows/desktop/ee419236) 構造体に効果のデータを設定します。</span><span class="sxs-lookup"><span data-stu-id="c8403-202">Populate an [XAUDIO2\_EFFECT\_DESCRIPTOR](https://msdn.microsoft.com/library/windows/desktop/ee419236) structure with effect data.</span></span>

3. <span data-ttu-id="c8403-203">[XAUDIO2\_EFFECT\_CHAIN](https://msdn.microsoft.com/library/windows/desktop/ee419235) 構造体にデータを設定します。</span><span class="sxs-lookup"><span data-stu-id="c8403-203">Populate an [XAUDIO2\_EFFECT\_CHAIN](https://msdn.microsoft.com/library/windows/desktop/ee419235) structure with data.</span></span>

4. <span data-ttu-id="c8403-204">エフェクト チェーンをボイスに適用します。</span><span class="sxs-lookup"><span data-stu-id="c8403-204">Apply the effect chain to a voice.</span></span>

5. <span data-ttu-id="c8403-205">効果のパラメーターの構造体にデータを設定し、その構造体を効果に適用します。</span><span class="sxs-lookup"><span data-stu-id="c8403-205">Populate an effect parameter structure and apply it to the effect.</span></span>

6. <span data-ttu-id="c8403-206">必要に応じて効果の無効と有効を切り替えます。</span><span class="sxs-lookup"><span data-stu-id="c8403-206">Disable or enable the effect whenever appropriate.</span></span>

<span data-ttu-id="c8403-207">**Audio** クラスは、リバーブを実装するエフェクト チェーンを作成するための **CreateReverb** メソッドを定義します。</span><span class="sxs-lookup"><span data-stu-id="c8403-207">The **Audio** class defines the **CreateReverb** method to create the effect chain that implements reverb.</span></span> <span data-ttu-id="c8403-208">このメソッドは [XAudio2CreateReverb](https://msdn.microsoft.com/library/windows/desktop/ee419213) メソッドを呼び出して、リバーブ エフェクトのサブミックス ボイスとして機能する **ComPtr&lt;IUnknown&gt;** オブジェクト **soundEffectXAPO** を作成します。</span><span class="sxs-lookup"><span data-stu-id="c8403-208">This method calls the [XAudio2CreateReverb](https://msdn.microsoft.com/library/windows/desktop/ee419213) method to create a **ComPtr&lt;IUnknown&gt;** object, **soundEffectXAPO**, which acts as the submix voice for the reverb effect.</span></span>

```cpp
Microsoft::WRL::ComPtr<IUnknown> soundEffectXAPO;

DX::ThrowIfFailed(
    XAudio2CreateReverb(&soundEffectXAPO)
    );
```

<span data-ttu-id="c8403-209">[XAUDIO2\_EFFECT\_DESCRIPTOR](https://msdn.microsoft.com/library/windows/desktop/ee419236) 構造体には、エフェクト チェーンで使う XAPO についての情報 (出力チャネルのターゲット数など) が格納されます。</span><span class="sxs-lookup"><span data-stu-id="c8403-209">The [XAUDIO2\_EFFECT\_DESCRIPTOR](https://msdn.microsoft.com/library/windows/desktop/ee419236) structure contains information about an XAPO for use in an effect chain, for example, the target number of output channels.</span></span> <span data-ttu-id="c8403-210">**Audio::CreateReverb** メソッドは、**XAUDIO2\_EFFECT\_DESCRIPTOR** オブジェクト **soundEffectdescriptor** を作成します。オブジェクトの状態は無効に、出力チャネル数は 2 つに設定され、さらに、リバーブ エフェクトの **soundEffectXAPO** オブジェクトを参照するように設定されます。</span><span class="sxs-lookup"><span data-stu-id="c8403-210">The **Audio::CreateReverb** method creates an **XAUDIO2\_EFFECT\_DESCRIPTOR** object, **soundEffectdescriptor**, that is set to the disabled state, uses two output channels, and references **soundEffectXAPO** for the reverb effect.</span></span> <span data-ttu-id="c8403-211">**soundEffectdescriptor** オブジェクトの開始状態を無効としているのは、先にパラメーターを設定してから、効果に伴うゲーム音の変更を開始する必要があるためです。</span><span class="sxs-lookup"><span data-stu-id="c8403-211">**soundEffectdescriptor** starts in the disabled state because the game must set parameters before the effect starts modifying game sounds.</span></span> <span data-ttu-id="c8403-212">Marble Maze は、2 つの出力チャネルを使ってリバーブ エフェクトのロジックを単純化します。</span><span class="sxs-lookup"><span data-stu-id="c8403-212">Marble Maze uses two output channels to simplify the logic for the reverb effect.</span></span>

```cpp
soundEffectdescriptor.InitialState = false;
soundEffectdescriptor.OutputChannels = 2;
soundEffectdescriptor.pEffect = soundEffectXAPO.Get();
```

<span data-ttu-id="c8403-213">エフェクト チェーンに複数の効果が存在する場合、各効果についてオブジェクトが必要となります。</span><span class="sxs-lookup"><span data-stu-id="c8403-213">If your effect chain has multiple effects, each effect requires an object.</span></span> <span data-ttu-id="c8403-214">[XAUDIO2\_EFFECT\_CHAIN](https://msdn.microsoft.com/library/windows/desktop/ee419235) 構造体は、効果に関与する [XAUDIO2\_EFFECT\_DESCRIPTOR](https://msdn.microsoft.com/library/windows/desktop/ee419236) オブジェクトの配列を保持します。</span><span class="sxs-lookup"><span data-stu-id="c8403-214">The [XAUDIO2\_EFFECT\_CHAIN](https://msdn.microsoft.com/library/windows/desktop/ee419235) structure holds the array of [XAUDIO2\_EFFECT\_DESCRIPTOR](https://msdn.microsoft.com/library/windows/desktop/ee419236) objects that participate in the effect.</span></span> <span data-ttu-id="c8403-215">次の例は、**Audio::CreateReverb** メソッドが 1 つの効果を指定してリバーブを実装する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="c8403-215">The following example shows how the **Audio::CreateReverb** method specifies the one effect to implement reverb.</span></span>

```cpp
XAUDIO2_EFFECT_CHAIN soundEffectChain;

// ...

soundEffectChain.EffectCount = 1;
soundEffectChain.pEffectDescriptors = &soundEffectdescriptor;
```

<span data-ttu-id="c8403-216">**Audio::CreateReverb** メソッドは、[IXAudio2::CreateSubmixVoice](https://msdn.microsoft.com/library/windows/desktop/ee418608) メソッドを呼び出して、効果のサブミックス ボイスを作成します。</span><span class="sxs-lookup"><span data-stu-id="c8403-216">The **Audio::CreateReverb** method calls the [IXAudio2::CreateSubmixVoice](https://msdn.microsoft.com/library/windows/desktop/ee418608) method to create the submix voice for the effect.</span></span> <span data-ttu-id="c8403-217">*pEffectChain* パラメーターに [XAUDIO2\_EFFECT\_CHAIN](https://msdn.microsoft.com/library/windows/desktop/ee419235) オブジェクト **soundEffectChain** を指定して、ボイスにエフェクト チェーンを関連付けます。</span><span class="sxs-lookup"><span data-stu-id="c8403-217">It specifies the [XAUDIO2\_EFFECT\_CHAIN](https://msdn.microsoft.com/library/windows/desktop/ee419235) object, **soundEffectChain**, for the *pEffectChain* parameter to associate the effect chain with the voice.</span></span> <span data-ttu-id="c8403-218">また、Marble Maze では、2 つの出力チャネルと 48 KHz のサンプル レートを指定しています。</span><span class="sxs-lookup"><span data-stu-id="c8403-218">Marble Maze also specifies two output channels and a sample rate of 48 kilohertz.</span></span>

```cpp
DX::ThrowIfFailed(
    engine->CreateSubmixVoice(newSubmix, 2, 48000, 0, 0, nullptr, &soundEffectChain)
    );
```

> [!TIP]
> <span data-ttu-id="c8403-219">既にあるサブミックス ボイスに対し、既にあるエフェクト チェーンをアタッチする場合、または、現在のエフェクト チェーンを置き換える場合は、[IXAudio2Voice::SetEffectChain](https://msdn.microsoft.com/library/windows/desktop/ee418594) メソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="c8403-219">If you want to attach an existing effect chain to an existing submix voice, or you want to replace the current effect chain, use the [IXAudio2Voice::SetEffectChain](https://msdn.microsoft.com/library/windows/desktop/ee418594) method.</span></span>

<span data-ttu-id="c8403-220">**Audio::CreateReverb** メソッドは、別途効果に関連付けるパラメーターを設定するために、[IXAudio2Voice::SetEffectParameters](https://msdn.microsoft.com/library/windows/desktop/ee418595) を呼び出しています。</span><span class="sxs-lookup"><span data-stu-id="c8403-220">The **Audio::CreateReverb** method calls [IXAudio2Voice::SetEffectParameters](https://msdn.microsoft.com/library/windows/desktop/ee418595) to set additional parameters that are associated with the effect.</span></span> <span data-ttu-id="c8403-221">このメソッドは、効果に固有のパラメーター構造体を受け取ります。</span><span class="sxs-lookup"><span data-stu-id="c8403-221">This method takes a parameter structure that is specific to the effect.</span></span> <span data-ttu-id="c8403-222">すべてのリバーブ エフェクトは同じパラメーターを共有するため、その効果のパラメーターを格納する [XAUDIO2FX\_REVERB\_PARAMETERS](https://msdn.microsoft.com/library/windows/desktop/ee419224) オブジェクト **m_reverbParametersSmall** は **Audio::Initialize** メソッドで初期化されています。</span><span class="sxs-lookup"><span data-stu-id="c8403-222">An [XAUDIO2FX\_REVERB\_PARAMETERS](https://msdn.microsoft.com/library/windows/desktop/ee419224) object, **m_reverbParametersSmall**, which contains the effect parameters for reverb, is initialized in the **Audio::Initialize** method because every reverb effect shares the same parameters.</span></span> <span data-ttu-id="c8403-223">次の例は、**Audio::Initialize** メソッドがニアフィールド リバーブのリバーブ パラメーターを初期化する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="c8403-223">The following example shows how the **Audio::Initialize** method initializes the reverb parameters for near-field reverb.</span></span>

```cpp
m_reverbParametersSmall.ReflectionsDelay = XAUDIO2FX_REVERB_DEFAULT_REFLECTIONS_DELAY;
m_reverbParametersSmall.ReverbDelay = XAUDIO2FX_REVERB_DEFAULT_REVERB_DELAY;
m_reverbParametersSmall.RearDelay = XAUDIO2FX_REVERB_DEFAULT_REAR_DELAY;
m_reverbParametersSmall.PositionLeft = XAUDIO2FX_REVERB_DEFAULT_POSITION;
m_reverbParametersSmall.PositionRight = XAUDIO2FX_REVERB_DEFAULT_POSITION;
m_reverbParametersSmall.PositionMatrixLeft = XAUDIO2FX_REVERB_DEFAULT_POSITION_MATRIX;
m_reverbParametersSmall.PositionMatrixRight = XAUDIO2FX_REVERB_DEFAULT_POSITION_MATRIX;
m_reverbParametersSmall.EarlyDiffusion = 4;
m_reverbParametersSmall.LateDiffusion = 15;
m_reverbParametersSmall.LowEQGain = XAUDIO2FX_REVERB_DEFAULT_LOW_EQ_GAIN;
m_reverbParametersSmall.LowEQCutoff = XAUDIO2FX_REVERB_DEFAULT_LOW_EQ_CUTOFF;
m_reverbParametersSmall.HighEQGain = XAUDIO2FX_REVERB_DEFAULT_HIGH_EQ_GAIN;
m_reverbParametersSmall.HighEQCutoff = XAUDIO2FX_REVERB_DEFAULT_HIGH_EQ_CUTOFF;
m_reverbParametersSmall.RoomFilterFreq = XAUDIO2FX_REVERB_DEFAULT_ROOM_FILTER_FREQ;
m_reverbParametersSmall.RoomFilterMain = XAUDIO2FX_REVERB_DEFAULT_ROOM_FILTER_MAIN;
m_reverbParametersSmall.RoomFilterHF = XAUDIO2FX_REVERB_DEFAULT_ROOM_FILTER_HF;
m_reverbParametersSmall.ReflectionsGain = XAUDIO2FX_REVERB_DEFAULT_REFLECTIONS_GAIN;
m_reverbParametersSmall.ReverbGain = XAUDIO2FX_REVERB_DEFAULT_REVERB_GAIN;
m_reverbParametersSmall.DecayTime = XAUDIO2FX_REVERB_DEFAULT_DECAY_TIME;
m_reverbParametersSmall.Density = XAUDIO2FX_REVERB_DEFAULT_DENSITY;
m_reverbParametersSmall.RoomSize = XAUDIO2FX_REVERB_DEFAULT_ROOM_SIZE;
m_reverbParametersSmall.WetDryMix = XAUDIO2FX_REVERB_DEFAULT_WET_DRY_MIX;
m_reverbParametersSmall.DisableLateField = TRUE;
```

<span data-ttu-id="c8403-224">この例では、ほとんどのリバーブ パラメーターに既定値を使っていますが、ニアフィールド リバーブを指定するために **DisableLateField** を TRUE に、平らな近くの表面をシミュレートするために **EarlyDiffusion** を 4 に、非常に散乱性が高い遠くの表面をシミュレートするために **LateDiffusion** を 15 に設定します。</span><span class="sxs-lookup"><span data-stu-id="c8403-224">This example uses the default values for most of the reverb parameters, but it sets **DisableLateField** to TRUE to specify near-field reverb, **EarlyDiffusion** to 4 to simulate flat near surfaces, and **LateDiffusion** to 15 to simulate very diffuse distant surfaces.</span></span> <span data-ttu-id="c8403-225">平らな近くの表面では反響音がより早く大きい音量で聞こえ、散乱性の高い遠くの表面では反響音がより遅く小さい音量で聞こえるようになります。</span><span class="sxs-lookup"><span data-stu-id="c8403-225">Flat near surfaces cause echoes to reach you more quickly and loudly; diffuse distant surfaces cause echoes to be quieter and reach you more slowly.</span></span> <span data-ttu-id="c8403-226">リバーブ値を調整しながらゲームに適した効果を得ることも、**ReverbConvertI3DL2ToNative** メソッドを使って業界標準の I3DL2 (Interactive 3D Audio Rendering Guidelines Level 2.0) のパラメーターを使うこともできます。</span><span class="sxs-lookup"><span data-stu-id="c8403-226">You can experiment with reverb values to get the desired effect in your game or use the **ReverbConvertI3DL2ToNative** method to use industry-standard I3DL2 (Interactive 3D Audio Rendering Guidelines Level 2.0) parameters.</span></span>

<span data-ttu-id="c8403-227">次の例は、**Audio::CreateReverb** がリバーブのパラメーターを設定する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="c8403-227">The following example shows how **Audio::CreateReverb** sets the reverb parameters.</span></span> <span data-ttu-id="c8403-228">**newSubmix** は [IXAudio2SubmixVoice](https://msdn.microsoft.com/library/windows/desktop/microsoft.directx_sdk.ixaudio2submixvoice.ixaudio2submixvoice)\*\* オブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="c8403-228">**newSubmix** is an [IXAudio2SubmixVoice](https://msdn.microsoft.com/library/windows/desktop/microsoft.directx_sdk.ixaudio2submixvoice.ixaudio2submixvoice)\*\* object.</span></span> <span data-ttu-id="c8403-229">**parameters** は [XAUDIO2FX\_REVERB\_PARAMETERS](https://msdn.microsoft.com/library/windows/desktop/ee419224)\* オブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="c8403-229">**parameters** is an [XAUDIO2FX\_REVERB\_PARAMETERS](https://msdn.microsoft.com/library/windows/desktop/ee419224)\* object.</span></span>

```cpp
DX::ThrowIfFailed(
    (*newSubmix)->SetEffectParameters(0, parameters, sizeof(m_reverbParametersSmall))
    );
```

<span data-ttu-id="c8403-230">**Audio::CreateReverb** メソッドは、**enableEffect** フラグが設定されている場合は [IXAudio2Voice::EnableEffect](https://msdn.microsoft.com/library/windows/desktop/microsoft.directx_sdk.ixaudio2voice.ixaudio2voice.enableeffect) を使用して効果を有効にし、終了します。</span><span class="sxs-lookup"><span data-stu-id="c8403-230">The **Audio::CreateReverb** method finishes by enabling the effect using [IXAudio2Voice::EnableEffect](https://msdn.microsoft.com/library/windows/desktop/microsoft.directx_sdk.ixaudio2voice.ixaudio2voice.enableeffect) if the **enableEffect** flag is set.</span></span> <span data-ttu-id="c8403-231">また、[IXAudio2Voice::SetVolume](https://msdn.microsoft.com/library/windows/desktop/microsoft.directx_sdk.ixaudio2voice.ixaudio2voice.setvolume) を使用してボリュームを設定し、[IXAudio2Voice::SetOutputMatrix](https://msdn.microsoft.com/library/windows/desktop/microsoft.directx_sdk.ixaudio2voice.ixaudio2voice.setoutputmatrix) を使用して出力マトリックスを設定します。</span><span class="sxs-lookup"><span data-stu-id="c8403-231">It also sets its volume using [IXAudio2Voice::SetVolume](https://msdn.microsoft.com/library/windows/desktop/microsoft.directx_sdk.ixaudio2voice.ixaudio2voice.setvolume) and output matrix using [IXAudio2Voice::SetOutputMatrix](https://msdn.microsoft.com/library/windows/desktop/microsoft.directx_sdk.ixaudio2voice.ixaudio2voice.setoutputmatrix).</span></span> <span data-ttu-id="c8403-232">この部分でボリュームをフル (1.0) に設定し、左右の入力スピーカーと左右の出力スピーカーの両方に対してボリューム マトリックスが無音になるように指定します。</span><span class="sxs-lookup"><span data-stu-id="c8403-232">This part sets the volume to full (1.0) and then specifies the volume matrix to be silence for both left and right inputs and left and right output speakers.</span></span> <span data-ttu-id="c8403-233">このような処理を行うのは、後から他のコードが (壁の近くから大きな空間の中への移行をシミュレートして) 2 つのリバーブ間のクロスフェードを行うか、または必要な場合は両方のリバーブをミュートするためです。</span><span class="sxs-lookup"><span data-stu-id="c8403-233">We do this because other code later cross-fades between the two reverbs (simulating the transition from being near a wall to being in a large room), or mutes both reverbs if required.</span></span> <span data-ttu-id="c8403-234">後でリバーブ パスがミュート解除されたときに、ゲームはマトリックス {1.0f, 0.0f, 0.0f, 1.0f} を設定して、左のリバーブ出力をマスタリング ボイスの左の入力に、右のリバーブ出力をマスタリング ボイスの右の入力にルーティングします。</span><span class="sxs-lookup"><span data-stu-id="c8403-234">When the reverb path is later unmuted, the game sets a matrix of {1.0f, 0.0f, 0.0f, 1.0f} to route left reverb output to the left input of the mastering voice and right reverb output to the right input of the mastering voice.</span></span>

```cpp
if (enableEffect)
{
    DX::ThrowIfFailed(
        (*newSubmix)->EnableEffect(0)
        );    
}

DX::ThrowIfFailed(
    (*newSubmix)->SetVolume (1.0f)
    );

float outputMatrix[4] = {0, 0, 0, 0};
DX::ThrowIfFailed(
    (*newSubmix)->SetOutputMatrix(masteringVoice, 2, 2, outputMatrix)
    );
```

<span data-ttu-id="c8403-235">Marble Maze は、**Audio::CreateReverb** メソッドを 4 回 (BGM のために 2 回、ゲームプレイ音のために 2 回) 呼び出します。</span><span class="sxs-lookup"><span data-stu-id="c8403-235">Marble Maze calls the **Audio::CreateReverb** method four times: two times for the background music and two times for the gameplay sounds.</span></span> <span data-ttu-id="c8403-236">次のコードは、BGM 用の **CreateReverb** メソッド呼び出しを示します。</span><span class="sxs-lookup"><span data-stu-id="c8403-236">The following shows how Marble Maze calls the **CreateReverb** method for the background music.</span></span>

```cpp
CreateReverb(
    m_musicEngine, 
    m_musicMasteringVoice, 
    &m_reverbParametersSmall, 
    &m_musicReverbVoiceSmallRoom, 
    true
    );
CreateReverb(
    m_musicEngine, 
    m_musicMasteringVoice, 
    &m_reverbParametersLarge, 
    &m_musicReverbVoiceLargeRoom, 
    true
    );
```

<span data-ttu-id="c8403-237">XAudio2 で利用できる効果のソースの一覧については、「[XAudio2 のオーディオ エフェクト](https://msdn.microsoft.com/library/windows/desktop/ee415756)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c8403-237">For a list of possible sources of effects for use with XAudio2, see [XAudio2 Audio Effects](https://msdn.microsoft.com/library/windows/desktop/ee415756).</span></span>

### <a name="loading-audio-data-from-file"></a><span data-ttu-id="c8403-238">ファイルからのオーディオ データの読み込み</span><span class="sxs-lookup"><span data-stu-id="c8403-238">Loading audio data from file</span></span>

<span data-ttu-id="c8403-239">Marble Maze に定義されている **MediaStreamer** クラスは、メディア ファンデーションを使ってオーディオ リソースをファイルから読み込みます。</span><span class="sxs-lookup"><span data-stu-id="c8403-239">Marble Maze defines the **MediaStreamer** class, which uses Media Foundation to load audio resources from files.</span></span> <span data-ttu-id="c8403-240">Marble Maze は、各オーディオ ファイルの読み込みに **MediaStreamer** オブジェクトを 1 つ使います。</span><span class="sxs-lookup"><span data-stu-id="c8403-240">Marble Maze uses one **MediaStreamer** object to load each audio file.</span></span>

<span data-ttu-id="c8403-241">各オーディオ ストリームは、**MediaStreamer::Initialize** メソッドを呼び出して初期化されます。</span><span class="sxs-lookup"><span data-stu-id="c8403-241">Marble Maze calls the **MediaStreamer::Initialize** method to initialize each audio stream.</span></span> <span data-ttu-id="c8403-242">**Audio::CreateResources** メソッドが **MediaStreamer::Initialize** を呼び出して BGM のオーディオ ストリームを初期化する方法を次に示します。</span><span class="sxs-lookup"><span data-stu-id="c8403-242">Here's how the **Audio::CreateResources** method calls **MediaStreamer::Initialize** to initialize the audio stream for the background music:</span></span>

```cpp
// Media Foundation is a convenient way to get both file I/O and format decode for 
// audio assets. You can replace the streamer in this sample with your own file I/O 
// and decode routines.
m_musicStreamer.Initialize(L"Media\\Audio\\background.wma");
```

<span data-ttu-id="c8403-243">**MediaStreamer::Initialize** メソッドは、メディア ファンデーションを初期化する [MFStartup](https://msdn.microsoft.com/library/windows/desktop/ms702238) メソッドの呼び出しによって開始されます。</span><span class="sxs-lookup"><span data-stu-id="c8403-243">The **MediaStreamer::Initialize** method starts by calling the [MFStartup](https://msdn.microsoft.com/library/windows/desktop/ms702238) method to initialize Media Foundation.</span></span> <span data-ttu-id="c8403-244">**MF_VERSION** は **mfapi.h** で定義されているマクロで、使用するメディア ファンデーションのバージョンとして指定するものです。</span><span class="sxs-lookup"><span data-stu-id="c8403-244">**MF_VERSION** is a macro defined in **mfapi.h**, and is what we specify as the version of Media Foundation to use.</span></span>

```cpp
DX::ThrowIfFailed(
    MFStartup(MF_VERSION)
    );
```

<span data-ttu-id="c8403-245">次に、**MediaStreamer::Initialize** は [MFCreateSourceReaderFromURL](https://msdn.microsoft.com/library/windows/desktop/dd388110) を呼び出して [IMFSourceReader](https://msdn.microsoft.com/library/windows/desktop/dd374655) オブジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="c8403-245">**MediaStreamer::Initialize** then calls [MFCreateSourceReaderFromURL](https://msdn.microsoft.com/library/windows/desktop/dd388110) to create an [IMFSourceReader](https://msdn.microsoft.com/library/windows/desktop/dd374655) object.</span></span> <span data-ttu-id="c8403-246">**IMFSourceReader** オブジェクト **m_reader** は、**url** で指定されたファイルからメディア データを読み取ります。</span><span class="sxs-lookup"><span data-stu-id="c8403-246">An **IMFSourceReader** object, **m_reader**, reads media data from the file that is specified by **url**.</span></span>

```cpp
DX::ThrowIfFailed(
    MFCreateSourceReaderFromURL(url, nullptr, &m_reader)
    );
```

<span data-ttu-id="c8403-247">**MediaStreamer::Initialize** メソッドはさらに、[MFCreateMediaType](https://msdn.microsoft.com/library/windows/desktop/ms693861) を使用して、オーディオ ストリームの形式を記述する [IMFMediaType](https://msdn.microsoft.com/library/windows/desktop/ms704850) オブジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="c8403-247">The **MediaStreamer::Initialize** method then creates an [IMFMediaType](https://msdn.microsoft.com/library/windows/desktop/ms704850) object using [MFCreateMediaType](https://msdn.microsoft.com/library/windows/desktop/ms693861) to describe the format of the audio stream.</span></span> <span data-ttu-id="c8403-248">オーディオ形式にはメジャー タイプとサブタイプの 2 種類があります。</span><span class="sxs-lookup"><span data-stu-id="c8403-248">An audio format has two types: a major type and a subtype.</span></span> <span data-ttu-id="c8403-249">メジャー タイプではメディア全体の形式 (ビデオ、オーディオ、スクリプトなど) を定義します。</span><span class="sxs-lookup"><span data-stu-id="c8403-249">The major type defines the overall format of the media, such as video, audio, script, and so on.</span></span> <span data-ttu-id="c8403-250">サブタイプでは PCM、ADPCM、WMA などの形式を定義します。</span><span class="sxs-lookup"><span data-stu-id="c8403-250">The subtype defines the format, such as PCM, ADPCM, or WMA.</span></span>

<span data-ttu-id="c8403-251">**MediaStreamer::Initialize** メソッドは、[IMFAttributes::SetGUID](https://msdn.microsoft.com/library/windows/desktop/bb970530) メソッドを使って、メジャー タイプ ([MF_MT_MAJOR_TYPE](https://msdn.microsoft.com/library/windows/desktop/ms702272)) にオーディオ (**MFMediaType\_Audio**) を、サブタイプ ([MF_MT_SUBTYPE](https://msdn.microsoft.com/library/windows/desktop/ms700208)) に圧縮されていない PCM オーディオ (**MFAudioFormat\_PCM**) を指定します。</span><span class="sxs-lookup"><span data-stu-id="c8403-251">The **MediaStreamer::Initialize** method uses the [IMFAttributes::SetGUID](https://msdn.microsoft.com/library/windows/desktop/bb970530) method to specify the major type ([MF_MT_MAJOR_TYPE](https://msdn.microsoft.com/library/windows/desktop/ms702272)) as audio (**MFMediaType\_Audio**) and the minor type ([MF_MT_SUBTYPE](https://msdn.microsoft.com/library/windows/desktop/ms700208)) as uncompressed PCM audio (**MFAudioFormat\_PCM**).</span></span> <span data-ttu-id="c8403-252">**MF_MT_MAJOR_TYPE** と **MF_MT_SUBTYPE** は[メディア ファンデーション属性](https://msdn.microsoft.com/library/windows/desktop/ms696989)です。</span><span class="sxs-lookup"><span data-stu-id="c8403-252">**MF_MT_MAJOR_TYPE** and **MF_MT_SUBTYPE** are [Media Foundation Attributes](https://msdn.microsoft.com/library/windows/desktop/ms696989).</span></span> <span data-ttu-id="c8403-253">**MFMediaType_Audio** と **MFAudioFormat_PCM** タイプとサブタイプの GUID です。詳細については、[オーディオ メディア タイプ](https://msdn.microsoft.com/library/windows/desktop/bb530108)に関するページを参照してください。</span><span class="sxs-lookup"><span data-stu-id="c8403-253">**MFMediaType_Audio** and **MFAudioFormat_PCM** are type and subtype GUIDs; see [Audio Media Types](https://msdn.microsoft.com/library/windows/desktop/bb530108) for more information.</span></span> <span data-ttu-id="c8403-254">[IMFSourceReader::SetCurrentMediaType](https://msdn.microsoft.com/library/windows/desktop/dd374667) メソッドは、メディア タイプをストリーム リーダーに関連付けます。</span><span class="sxs-lookup"><span data-stu-id="c8403-254">The [IMFSourceReader::SetCurrentMediaType](https://msdn.microsoft.com/library/windows/desktop/dd374667) method associates the media type with the stream reader.</span></span>

```cpp
// Set the decoded output format as PCM. 
// XAudio2 on Windows can process PCM and ADPCM-encoded buffers. 
// When this sample uses Media Foundation, it always decodes into PCM.

DX::ThrowIfFailed(
    MFCreateMediaType(&mediaType)
    );

DX::ThrowIfFailed(
    mediaType->SetGUID(MF_MT_MAJOR_TYPE, MFMediaType_Audio)
    );

DX::ThrowIfFailed(
    mediaType->SetGUID(MF_MT_SUBTYPE, MFAudioFormat_PCM)
    );

DX::ThrowIfFailed(
    m_reader->SetCurrentMediaType(MF_SOURCE_READER_FIRST_AUDIO_STREAM, 0, mediaType.Get())
    );
```

<span data-ttu-id="c8403-255">次に、**MediaStreamer::Initialize** メソッドは、[IMFSourceReader::GetCurrentMediaType](https://msdn.microsoft.com/library/windows/desktop/dd374660) を使用してメディア ファンデーションから完全な出力メディア形式を取得し、[MFCreateWaveFormatExFromMFMediaType](https://msdn.microsoft.com/library/windows/desktop/ms702177) メソッドを呼び出してメディア ファンデーションのオーディオ メディア タイプを [WAVEFORMATEX](https://msdn.microsoft.com/library/windows/hardware/ff538799) 構造体に変換します。</span><span class="sxs-lookup"><span data-stu-id="c8403-255">The **MediaStreamer::Initialize** method then obtains the complete output media format from Media Foundation using [IMFSourceReader::GetCurrentMediaType](https://msdn.microsoft.com/library/windows/desktop/dd374660) and calls the [MFCreateWaveFormatExFromMFMediaType](https://msdn.microsoft.com/library/windows/desktop/ms702177) method to convert the Media Foundation audio media type to a [WAVEFORMATEX](https://msdn.microsoft.com/library/windows/hardware/ff538799) structure.</span></span> <span data-ttu-id="c8403-256">**WAVEFORMATEX** 構造体は Waveform オーディオ データの形式を定義します。</span><span class="sxs-lookup"><span data-stu-id="c8403-256">The **WAVEFORMATEX** structure defines the format of waveform-audio data.</span></span> <span data-ttu-id="c8403-257">Marble Maze はこの構造体を使ってソース ボイスを作成し、大理石の転がる音に低域フィルターを適用します。</span><span class="sxs-lookup"><span data-stu-id="c8403-257">Marble Maze uses this structure to create the source voices and to apply the low-pass filter to the marble rolling sound.</span></span>

```cpp
// Get the complete WAVEFORMAT from the Media Type.
DX::ThrowIfFailed(
    m_reader->GetCurrentMediaType(MF_SOURCE_READER_FIRST_AUDIO_STREAM, &outputMediaType)
    );

uint32 formatSize = 0;
WAVEFORMATEX* waveFormat;
DX::ThrowIfFailed(
    MFCreateWaveFormatExFromMFMediaType(outputMediaType.Get(), &waveFormat, &formatSize)
    );
CopyMemory(&m_waveFormat, waveFormat, sizeof(m_waveFormat));
CoTaskMemFree(waveFormat);
```

> [!IMPORTANT]
> <span data-ttu-id="c8403-258">[MFCreateWaveFormatExFromMFMediaType](https://msdn.microsoft.com/library/windows/desktop/ms702177) メソッドは、**CoTaskMemAlloc** を使って [WAVEFORMATEX](https://msdn.microsoft.com/library/windows/hardware/ff538799) オブジェクトを割り当てます。</span><span class="sxs-lookup"><span data-stu-id="c8403-258">The [MFCreateWaveFormatExFromMFMediaType](https://msdn.microsoft.com/library/windows/desktop/ms702177) method uses **CoTaskMemAlloc** to allocate the [WAVEFORMATEX](https://msdn.microsoft.com/library/windows/hardware/ff538799) object.</span></span> <span data-ttu-id="c8403-259">したがって、このオブジェクトを使い終えたら必ず、**CoTaskMemFree** を呼び出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="c8403-259">Therefore, make sure that you call **CoTaskMemFree** when you are finished using this object.</span></span>

 

<span data-ttu-id="c8403-260">**MediaStreamer::Initialize** メソッドは、ストリームの長さ **m\_maxStreamLengthInBytes** (バイト単位) を計算して終了します。</span><span class="sxs-lookup"><span data-stu-id="c8403-260">The **MediaStreamer::Initialize** method finishes by computing the length of the stream, **m\_maxStreamLengthInBytes**, in bytes.</span></span> <span data-ttu-id="c8403-261">そのために、[IMFSourceReader::GetPresentationAttribute](https://msdn.microsoft.com/library/windows/desktop/dd374662) メソッドを呼び出してオーディオ ストリームの継続時間 (100 ナノ秒単位) を取得し、継続時間をセクションに変換した後、平均データ転送速度 (バイト/秒単位) を乗算します。</span><span class="sxs-lookup"><span data-stu-id="c8403-261">To do so, it calls the [IMFSourceReader::GetPresentationAttribute](https://msdn.microsoft.com/library/windows/desktop/dd374662) method to get the duration of the audio stream in 100-nanosecond units, converts the duration to sections, and then multiplies by the average data transfer rate in bytes per second.</span></span> <span data-ttu-id="c8403-262">Marble Maze は後でこの値を使って、各ゲームプレイ音を保持するバッファーを割り当てます。</span><span class="sxs-lookup"><span data-stu-id="c8403-262">Marble Maze later uses this value to allocate the buffer that holds each gameplay sound.</span></span>

```cpp
// Get the total length of the stream, in bytes.
PROPVARIANT var;
DX::ThrowIfFailed(
    m_reader->
        GetPresentationAttribute(MF_SOURCE_READER_MEDIASOURCE, MF_PD_DURATION, &var)
    );

// duration is in 100ns units; convert to seconds, and round up
// to the nearest whole byte.
ULONGLONG duration = var.uhVal.QuadPart;
m_maxStreamLengthInBytes =
    static_cast<unsigned int>(
        ((duration * static_cast<ULONGLONG>(m_waveFormat.nAvgBytesPerSec)) + 10000000)
        / 10000000
        );
```

### <a name="creating-the-source-voices"></a><span data-ttu-id="c8403-263">ソース ボイスの作成</span><span class="sxs-lookup"><span data-stu-id="c8403-263">Creating the source voices</span></span>

<span data-ttu-id="c8403-264">Marble Maze は、XAudio2 ソース ボイスを作成して、ソース ボイスに含まれるそれぞれのゲーム音と音楽を再生します。</span><span class="sxs-lookup"><span data-stu-id="c8403-264">Marble Maze creates XAudio2 source voices to play each of its game sounds and music in source voices.</span></span> <span data-ttu-id="c8403-265">**Audio** クラスには、BGM 用の [IXAudio2SourceVoice](https://msdn.microsoft.com/library/windows/desktop/ee415914) オブジェクトと、ゲームプレイ音を格納する **SoundEffectData** オブジェクトの配列が定義されます。</span><span class="sxs-lookup"><span data-stu-id="c8403-265">The **Audio** class defines an [IXAudio2SourceVoice](https://msdn.microsoft.com/library/windows/desktop/ee415914) object for the background music and an array of **SoundEffectData** objects to hold the gameplay sounds.</span></span> <span data-ttu-id="c8403-266">**SoundEffectData** 構造体は、効果の **IXAudio2SourceVoice** オブジェクトを保持するほか、効果に関連したその他のデータ (オーディオ バッファーなど) を定義します。</span><span class="sxs-lookup"><span data-stu-id="c8403-266">The **SoundEffectData** structure holds the **IXAudio2SourceVoice** object for an effect and also defines other effect-related data, such as the audio buffer.</span></span> <span data-ttu-id="c8403-267">**Audio.h** には **SoundEvent** 列挙体が定義されています。</span><span class="sxs-lookup"><span data-stu-id="c8403-267">**Audio.h** defines the **SoundEvent** enumeration.</span></span> <span data-ttu-id="c8403-268">Marble Maze は、この列挙体を使って各ゲームプレイ音を識別します。</span><span class="sxs-lookup"><span data-stu-id="c8403-268">Marble Maze uses this enumeration to identify each gameplay sound.</span></span> <span data-ttu-id="c8403-269">**Audio** クラスで、**SoundEffectData** オブジェクトの配列のインデックスとしても、この列挙体が使われます。</span><span class="sxs-lookup"><span data-stu-id="c8403-269">The **Audio** class also uses this enumeration to index the array of **SoundEffectData** objects.</span></span>

```cpp
enum SoundEvent
{
    RollingEvent        = 0,
    FallingEvent        = 1,
    CollisionEvent      = 2,
    CheckpointEvent     = 3,
    MenuChangeEvent     = 4,
    MenuSelectedEvent   = 5,
    LastSoundEvent,
};
```

<span data-ttu-id="c8403-270">次の表は、列挙体の各値と、それに関連したサウンド データが格納されているファイル、表現される音の簡単な説明を一覧にしたものです。</span><span class="sxs-lookup"><span data-stu-id="c8403-270">The following table shows the relationship between each of these values, the file that contains the associated sound data, and a brief description of what each sound represents.</span></span> <span data-ttu-id="c8403-271">オーディオ ファイルは **\\Media\\Audio** フォルダーにあります。</span><span class="sxs-lookup"><span data-stu-id="c8403-271">The audio files are located in the **\\Media\\Audio** folder.</span></span>

| <span data-ttu-id="c8403-272">SoundEvent 値</span><span class="sxs-lookup"><span data-stu-id="c8403-272">SoundEvent value</span></span>  | <span data-ttu-id="c8403-273">ファイル名</span><span class="sxs-lookup"><span data-stu-id="c8403-273">File name</span></span>      | <span data-ttu-id="c8403-274">説明</span><span class="sxs-lookup"><span data-stu-id="c8403-274">Description</span></span>                                              |
|-------------------|----------------|----------------------------------------------------------|
| <span data-ttu-id="c8403-275">RollingEvent</span><span class="sxs-lookup"><span data-stu-id="c8403-275">RollingEvent</span></span>      | <span data-ttu-id="c8403-276">MarbleRoll.wav</span><span class="sxs-lookup"><span data-stu-id="c8403-276">MarbleRoll.wav</span></span> | <span data-ttu-id="c8403-277">大理石が転がるときに再生されます。</span><span class="sxs-lookup"><span data-stu-id="c8403-277">Played as the marble rolls.</span></span>                              |
| <span data-ttu-id="c8403-278">FallingEvent</span><span class="sxs-lookup"><span data-stu-id="c8403-278">FallingEvent</span></span>      | <span data-ttu-id="c8403-279">MarbleFall.wav</span><span class="sxs-lookup"><span data-stu-id="c8403-279">MarbleFall.wav</span></span> | <span data-ttu-id="c8403-280">大理石が迷路から落ちるときに再生されます。</span><span class="sxs-lookup"><span data-stu-id="c8403-280">Played when the marble falls off the maze.</span></span>               |
| <span data-ttu-id="c8403-281">CollisionEvent</span><span class="sxs-lookup"><span data-stu-id="c8403-281">CollisionEvent</span></span>    | <span data-ttu-id="c8403-282">MarbleHit.wav</span><span class="sxs-lookup"><span data-stu-id="c8403-282">MarbleHit.wav</span></span>  | <span data-ttu-id="c8403-283">大理石が迷路にぶつかるときに再生されます。</span><span class="sxs-lookup"><span data-stu-id="c8403-283">Played when the marble collides with the maze.</span></span>           |
| <span data-ttu-id="c8403-284">CheckpointEvent</span><span class="sxs-lookup"><span data-stu-id="c8403-284">CheckpointEvent</span></span>   | <span data-ttu-id="c8403-285">Checkpoint.wav</span><span class="sxs-lookup"><span data-stu-id="c8403-285">Checkpoint.wav</span></span> | <span data-ttu-id="c8403-286">大理石がチェックポイントを通過するときに再生されます。</span><span class="sxs-lookup"><span data-stu-id="c8403-286">Played when the marble passes over a checkpoint.</span></span>         |
| <span data-ttu-id="c8403-287">MenuChangeEvent</span><span class="sxs-lookup"><span data-stu-id="c8403-287">MenuChangeEvent</span></span>   | <span data-ttu-id="c8403-288">MenuChange.wav</span><span class="sxs-lookup"><span data-stu-id="c8403-288">MenuChange.wav</span></span> | <span data-ttu-id="c8403-289">ユーザーが現在のメニュー項目を変更するときに再生されます。</span><span class="sxs-lookup"><span data-stu-id="c8403-289">Played when the user changes the current menu item.</span></span> |
| <span data-ttu-id="c8403-290">MenuSelectedEvent</span><span class="sxs-lookup"><span data-stu-id="c8403-290">MenuSelectedEvent</span></span> | <span data-ttu-id="c8403-291">MenuSelect.wav</span><span class="sxs-lookup"><span data-stu-id="c8403-291">MenuSelect.wav</span></span> | <span data-ttu-id="c8403-292">ユーザーがメニュー項目を選択するときに再生されます。</span><span class="sxs-lookup"><span data-stu-id="c8403-292">Played when the user selects a menu item.</span></span>           |

 

<span data-ttu-id="c8403-293">以下の例では、**Audio::CreateResources** メソッドを使って BGM のソース ボイスを作成しています。</span><span class="sxs-lookup"><span data-stu-id="c8403-293">The following example shows how the **Audio::CreateResources** method creates the source voice for the background music.</span></span> <span data-ttu-id="c8403-294">[XAUDIO2\_SEND\_DESCRIPTOR](https://msdn.microsoft.com/library/windows/desktop/ee419244) 構造体は、別のボイスからの送信先であるターゲット ボイスを定義し、フィルターを使うかどうかを指定します。</span><span class="sxs-lookup"><span data-stu-id="c8403-294">The [XAUDIO2\_SEND\_DESCRIPTOR](https://msdn.microsoft.com/library/windows/desktop/ee419244) structure defines the target destination voice from another voice and specifies whether a filter should be used.</span></span> <span data-ttu-id="c8403-295">Marble Maze は、**Audio::SetSoundEffectFilter** メソッドを呼び出し、フィルターを使って、転がるボールの音に変化を与えています。</span><span class="sxs-lookup"><span data-stu-id="c8403-295">Marble Maze calls the **Audio::SetSoundEffectFilter** method to use the filters to change the sound of the ball as it rolls.</span></span> <span data-ttu-id="c8403-296">[XAUDIO2\_VOICE\_SENDS](https://msdn.microsoft.com/library/windows/desktop/ee419246) 構造体は、単一の出力ボイスからデータを受け取るための一連のボイスを定義します。</span><span class="sxs-lookup"><span data-stu-id="c8403-296">The [XAUDIO2\_VOICE\_SENDS](https://msdn.microsoft.com/library/windows/desktop/ee419246) structure defines the set of voices to receive data from a single output voice.</span></span> <span data-ttu-id="c8403-297">Marble Maze は、ソース ボイスからのデータを、マスタリング ボイス (再生するサウンドのドライ、つまり変更されない部分が対象) と 2 つのサブミックス ボイス (再生するサウンドのウェット、つまりリバーブのかかった部分を実装) に送ります。</span><span class="sxs-lookup"><span data-stu-id="c8403-297">Marble Maze sends data from the source voice to the mastering voice (for the dry, or unaltered, portion of a playing sound) and to the two submix voices that implement the wet, or reverberant, portion of a playing sound.</span></span>

<span data-ttu-id="c8403-298">ソース ボイスの作成と構成は、[IXAudio2::CreateSourceVoice](https://msdn.microsoft.com/library/windows/desktop/ee418607) メソッドで行います。</span><span class="sxs-lookup"><span data-stu-id="c8403-298">The [IXAudio2::CreateSourceVoice](https://msdn.microsoft.com/library/windows/desktop/ee418607) method creates and configures a source voice.</span></span> <span data-ttu-id="c8403-299">このメソッドは、ボイスに送られるオーディオ バッファーの形式を定義する [WAVEFORMATEX](https://msdn.microsoft.com/library/windows/hardware/ff538799) 構造体を受け取ります。</span><span class="sxs-lookup"><span data-stu-id="c8403-299">It takes a [WAVEFORMATEX](https://msdn.microsoft.com/library/windows/hardware/ff538799) structure that defines the format of the audio buffers that are sent to the voice.</span></span> <span data-ttu-id="c8403-300">既に説明したように、Marble Maze では PCM 形式を使います。</span><span class="sxs-lookup"><span data-stu-id="c8403-300">As mentioned previously, Marble Maze uses the PCM format.</span></span>

```cpp
XAUDIO2_SEND_DESCRIPTOR descriptors[3];
descriptors[0].pOutputVoice = m_musicMasteringVoice;
descriptors[0].Flags = 0;
descriptors[1].pOutputVoice = m_musicReverbVoiceSmallRoom;
descriptors[1].Flags = 0;
descriptors[2].pOutputVoice = m_musicReverbVoiceLargeRoom;
descriptors[2].Flags = 0;
XAUDIO2_VOICE_SENDS sends = {0};
sends.SendCount = 3;
sends.pSends = descriptors;
WAVEFORMATEX& waveFormat = m_musicStreamer.GetOutputWaveFormatEx();

DX::ThrowIfFailed(
    m_musicEngine->CreateSourceVoice(&m_musicSourceVoice, &waveFormat, 0, 1.0f, &m_voiceContext, &sends, nullptr)
    );

DX::ThrowIfFailed(
    m_musicMasteringVoice->SetVolume(0.4f)
    );
```

## <a name="playing-background-music"></a><span data-ttu-id="c8403-301">BGM の再生</span><span class="sxs-lookup"><span data-stu-id="c8403-301">Playing background music</span></span>


<span data-ttu-id="c8403-302">ソース ボイスは停止した状態で作成されます。</span><span class="sxs-lookup"><span data-stu-id="c8403-302">A source voice is created in the stopped state.</span></span> <span data-ttu-id="c8403-303">Marble Maze はゲーム ループ内で BGM を開始します。</span><span class="sxs-lookup"><span data-stu-id="c8403-303">Marble Maze starts the background music in the game loop.</span></span> <span data-ttu-id="c8403-304">**MarbleMazeMain::Update** の最初の呼び出しで、**Audio::Start** を呼び出して BGM を開始します。</span><span class="sxs-lookup"><span data-stu-id="c8403-304">The first call to **MarbleMazeMain::Update** calls **Audio::Start** to start the background music.</span></span>

```cpp
if (!m_audio.m_isAudioStarted)
{
    m_audio.Start();
}
```

<span data-ttu-id="c8403-305">**Audio::Start** メソッドは [IXAudio2SourceVoice::Start](https://msdn.microsoft.com/library/windows/desktop/ee418471) を呼び出して、BGM のソース ボイスの処理を開始します。</span><span class="sxs-lookup"><span data-stu-id="c8403-305">The **Audio::Start** method calls [IXAudio2SourceVoice::Start](https://msdn.microsoft.com/library/windows/desktop/ee418471) to start to process the source voice for the background music.</span></span>

```cpp
void Audio::Start()
{     
    if (m_engineExperiencedCriticalError)
    {
        return;
    }

    HRESULT hr = m_musicSourceVoice->Start(0);

    if SUCCEEDED(hr) {
        m_isAudioStarted = true;
    }
    else
    {
        m_engineExperiencedCriticalError = true;
    }
}
```

<span data-ttu-id="c8403-306">ソース ボイスは、そのオーディオ データをオーディオ グラフの次のステージに渡します。</span><span class="sxs-lookup"><span data-stu-id="c8403-306">The source voice passes that audio data to the next stage of the audio graph.</span></span> <span data-ttu-id="c8403-307">Marble Maze の場合、次のステージには、オーディオにリバーブ エフェクトを適用する 2 つのサブミックス ボイスが含まれます。</span><span class="sxs-lookup"><span data-stu-id="c8403-307">In the case of Marble Maze, the next stage contains two submix voices that apply the two reverb effects to the audio.</span></span> <span data-ttu-id="c8403-308">1 つは近距離の後期フィールド リバーブを適用するもので、もう 1 つは遠距離の後期フィールド リバーブを適用するものです。</span><span class="sxs-lookup"><span data-stu-id="c8403-308">One submix voice applies a close late-field reverb; the second applies a far late-field reverb.</span></span>

<span data-ttu-id="c8403-309">最終的なミキシングに各サブミックス ボイスがどれだけ含まれるかは、空間のサイズと形状によって決定します。</span><span class="sxs-lookup"><span data-stu-id="c8403-309">The amount that each submix voice contributes to the final mix is determined by the size and shape of the room.</span></span> <span data-ttu-id="c8403-310">玉が壁の近くまたは小さな空間内にある場合はニアフィールド リバーブの占める量が多くなり、玉が大きな空間内にある場合は後期フィールド リバーブの占める量が多くなります。</span><span class="sxs-lookup"><span data-stu-id="c8403-310">The near-field reverb contributes more when the ball is near a wall or in a small room, and the late-field reverb contributes more when the ball is in a large space.</span></span> <span data-ttu-id="c8403-311">この手法により、大理石が迷路内を移動するときに、よりリアルなエコー効果が得られます。</span><span class="sxs-lookup"><span data-stu-id="c8403-311">This technique produces a more realistic echo effect as the marble moves through the maze.</span></span> <span data-ttu-id="c8403-312">Marble Maze におけるこの効果の実装について詳しくは、Marble Maze のソース コードで **Audio::SetRoomSize** と **Physics::CalculateCurrentRoomSize** をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c8403-312">To learn more about how Marble Maze implements this effect, see **Audio::SetRoomSize** and **Physics::CalculateCurrentRoomSize** in the Marble Maze source code.</span></span>

> [!NOTE]
> <span data-ttu-id="c8403-313">ほとんどの空間のサイズが同じであるゲームでは、もっと基本的なリバーブ モデルを使うことができます。</span><span class="sxs-lookup"><span data-stu-id="c8403-313">In a game in which most room sizes are relatively the same, you can use a more basic reverb model.</span></span> <span data-ttu-id="c8403-314">たとえば、すべての空間に 1 つのリバーブ設定を使ったり、定義済みのリバーブ設定を空間ごとに作成したりできます。</span><span class="sxs-lookup"><span data-stu-id="c8403-314">For example, you can use one reverb setting for all rooms or you can create a predefined reverb setting for each room.</span></span>

<span data-ttu-id="c8403-315">**Audio::CreateResources** メソッドは、メディア ファンデーションを使って BGM を読み込みます。</span><span class="sxs-lookup"><span data-stu-id="c8403-315">The **Audio::CreateResources** method uses Media Foundation to load the background music.</span></span> <span data-ttu-id="c8403-316">しかし、この時点では、処理対象のオーディオ データがソース ボイスにありません。</span><span class="sxs-lookup"><span data-stu-id="c8403-316">At this point, however, the source voice does not have audio data to work with.</span></span> <span data-ttu-id="c8403-317">さらに、BGM はループするので、データを使いソース ボイスを定期的に更新して、音楽を再生し続ける必要があります。</span><span class="sxs-lookup"><span data-stu-id="c8403-317">In addition, because the background music loops, the source voice must be regularly updated with data so that the music continues to play.</span></span>

<span data-ttu-id="c8403-318">ソース ボイスにデータが入力された状態を維持するために、ゲーム ループはフレームごとにオーディオ バッファーを更新します。</span><span class="sxs-lookup"><span data-stu-id="c8403-318">To keep the source voice filled with data, the game loop updates the audio buffers every frame.</span></span> <span data-ttu-id="c8403-319">**MarbleMazeMain::Render** メソッドは、**Audio::Render** を呼び出して BGM のオーディオ バッファーを処理します。</span><span class="sxs-lookup"><span data-stu-id="c8403-319">The **MarbleMazeMain::Render** method calls **Audio::Render** to process the background music audio buffer.</span></span> <span data-ttu-id="c8403-320">**Audio** クラスは 3 つのオーディオ バッファーの配列 **m\_audioBuffers** を定義します。</span><span class="sxs-lookup"><span data-stu-id="c8403-320">The **Audio** class defines an array of three audio buffers, **m\_audioBuffers**.</span></span> <span data-ttu-id="c8403-321">各バッファーは 64 KB (65536 バイト) のデータを保持します。</span><span class="sxs-lookup"><span data-stu-id="c8403-321">Each buffer holds 64 KB (65536 bytes) of data.</span></span> <span data-ttu-id="c8403-322">ループは、メディア ファンデーション オブジェクトからデータを読み取り、ソース ボイスのキューに 3 つのバッファーが入るまで、そのデータをソース ボイスに書き込みます。</span><span class="sxs-lookup"><span data-stu-id="c8403-322">The loop reads data from the Media Foundation object and writes that data to the source voice until the source voice has three queued buffers.</span></span>

> [!CAUTION]
> <span data-ttu-id="c8403-323">Marble Maze は 64 KB のバッファーを使って音楽データを保持しますが、より大きいバッファーまたはより小さいバッファーが必要になる場合もあります。</span><span class="sxs-lookup"><span data-stu-id="c8403-323">Although Marble Maze uses a 64 KB buffer to hold music data, you may need to use a larger or smaller buffer.</span></span> <span data-ttu-id="c8403-324">その量は、ゲームの要件によって異なります。</span><span class="sxs-lookup"><span data-stu-id="c8403-324">This amount depends on the requirements of your game.</span></span>

```cpp
// This sample processes audio buffers during the render cycle of the application.
// As long as the sample maintains a high-enough frame rate, this approach should
// not glitch audio. In game code, it is best for audio buffers to be processed
// on a separate thread that is not synced to the main render loop of the game.
void Audio::Render()
{
    if (m_engineExperiencedCriticalError)
    {
        m_engineExperiencedCriticalError = false;
        ReleaseResources();
        Initialize();
        CreateResources();
        Start();
        if (m_engineExperiencedCriticalError)
        {
            return;
        }
    }

    try
    {
        bool streamComplete;
        XAUDIO2_VOICE_STATE state;
        uint32 bufferLength;
        XAUDIO2_BUFFER buf = {0};

        // Use MediaStreamer to stream the buffers.
        m_musicSourceVoice->GetState(&state);
        while (state.BuffersQueued <= MAX_BUFFER_COUNT - 1)
        {
            streamComplete = m_musicStreamer.GetNextBuffer(
                m_audioBuffers[m_currentBuffer],
                STREAMING_BUFFER_SIZE,
                &bufferLength
                );

            if (bufferLength > 0)
            {
                buf.AudioBytes = bufferLength;
                buf.pAudioData = m_audioBuffers[m_currentBuffer];
                buf.Flags = (streamComplete) ? XAUDIO2_END_OF_STREAM : 0;
                buf.pContext = 0;
                DX::ThrowIfFailed(
                    m_musicSourceVoice->SubmitSourceBuffer(&buf)
                    );

                m_currentBuffer++;
                m_currentBuffer %= MAX_BUFFER_COUNT;
            }

            if (streamComplete)
            {
                // Loop the stream.
                m_musicStreamer.Restart();
                break;
            }

            m_musicSourceVoice->GetState(&state);
        }
    }
    catch (...)
    {
        m_engineExperiencedCriticalError = true;
    }
}
```

<span data-ttu-id="c8403-325">メディア ファンデーション オブジェクトがストリームの末尾に到達したときの処理もループで行います。</span><span class="sxs-lookup"><span data-stu-id="c8403-325">The loop also handles when the Media Foundation object reaches the end of the stream.</span></span> <span data-ttu-id="c8403-326">この場合、[IMFSourceReader::SetCurrentPosition](https://msdn.microsoft.com/library/windows/desktop/dd374668) メソッドを呼び出してオーディオ ソースの位置をリセットします。</span><span class="sxs-lookup"><span data-stu-id="c8403-326">In this case, it calls the [IMFSourceReader::SetCurrentPosition](https://msdn.microsoft.com/library/windows/desktop/dd374668) method to reset the position of the audio source.</span></span>

```cpp
void MediaStreamer::Restart()
{
    if (m_reader == nullptr)
    {
        return;
    }

    PROPVARIANT var = {0};
    var.vt = VT_I8;

    DX::ThrowIfFailed(
        m_reader->SetCurrentPosition(GUID_NULL, var)
        );
}
```

<span data-ttu-id="c8403-327">単一バッファー (またはメモリに完全に読み込まれるサウンド全体) 用のオーディオ ループを実装するには、サウンドの初期化時に [XAUDIO2_BUFFER](https://msdn.microsoft.com/library/windows/desktop/microsoft.directx_sdk.xaudio2.xaudio2_buffer)::LoopCount フィールドを **XAUDIO2\_LOOP\_INFINITE** に設定します。</span><span class="sxs-lookup"><span data-stu-id="c8403-327">To implement audio looping for a single buffer (or for an entire sound that is fully loaded into memory), you can set the [XAUDIO2_BUFFER](https://msdn.microsoft.com/library/windows/desktop/microsoft.directx_sdk.xaudio2.xaudio2_buffer)::LoopCount field to **XAUDIO2\_LOOP\_INFINITE** when you initialize the sound.</span></span> <span data-ttu-id="c8403-328">Marble Maze は、この手法を使って大理石の転がる音を再生します。</span><span class="sxs-lookup"><span data-stu-id="c8403-328">Marble Maze uses this technique to play the rolling sound for the marble.</span></span>

```cpp
if (sound == RollingEvent)
{
    m_soundEffects[sound].m_audioBuffer.LoopCount = XAUDIO2_LOOP_INFINITE;
}
```

<span data-ttu-id="c8403-329">ただし、BGM に関しては、Marble Maze は、メモリの使用量を細かく制御できるようにバッファーを直接管理します。</span><span class="sxs-lookup"><span data-stu-id="c8403-329">However, for the background music, Marble Maze manages the buffers directly so that it can better control the amount of memory that is used.</span></span> <span data-ttu-id="c8403-330">音楽ファイルが大きい場合は、小さいバッファーに音楽データをストリームできます。</span><span class="sxs-lookup"><span data-stu-id="c8403-330">When your music files are large, you can stream the music data into smaller buffers.</span></span> <span data-ttu-id="c8403-331">そうすることで、ゲームがオーディオ データを処理してストリームできる頻度と、メモリ サイズとのバランスを取ることができます。</span><span class="sxs-lookup"><span data-stu-id="c8403-331">Doing so can help balance memory size with the frequency of the game’s ability to process and stream audio data.</span></span>

> [!TIP]
> <span data-ttu-id="c8403-332">フレーム レートが低いまたは変動するゲームでは、メイン スレッドでのオーディオの処理中に、オーディオ内で予期しない一時停止またはポップが発生する可能性があります。これは、オーディオ エンジンに処理対象のオーディオ データが十分にバッファーされていないためです。</span><span class="sxs-lookup"><span data-stu-id="c8403-332">If your game has a low or varying frame rate, processing audio on the main thread can produce unexpected pauses or pops in the audio because the audio engine has insufficient buffered audio data to work with.</span></span> <span data-ttu-id="c8403-333">ゲームでこの問題が発生しやすい場合は、レンダリングを実行しない別のスレッドでオーディオを処理することを検討してください。</span><span class="sxs-lookup"><span data-stu-id="c8403-333">If your game is sensitive to this issue, consider processing audio on a separate thread that does not perform rendering.</span></span> <span data-ttu-id="c8403-334">この方法は、ゲームがアイドル状態のプロセッサを使うことができるため、複数のプロセッサを搭載したコンピューターで特に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="c8403-334">This approach is especially useful on computers that have multiple processors because your game can use idle processors.</span></span>

## <a name="reacting-to-game-events"></a><span data-ttu-id="c8403-335">ゲームのイベントへの対応</span><span class="sxs-lookup"><span data-stu-id="c8403-335">Reacting to game events</span></span>

<span data-ttu-id="c8403-336">ゲームでサウンドの再生と停止のタイミングを制御し、ボリュームやピッチなどのサウンド プロパティを制御するために、**Audio** クラスには **PlaySoundEffect**、**IsSoundEffectStarted**、**StopSoundEffect**、**SetSoundEffectVolume**、**SetSoundEffectPitch**、**SetSoundEffectFilter** などのメソッドが用意されています。</span><span class="sxs-lookup"><span data-stu-id="c8403-336">The **Audio** class provides methods such as **PlaySoundEffect**, **IsSoundEffectStarted**, **StopSoundEffect**, **SetSoundEffectVolume**, **SetSoundEffectPitch**, and **SetSoundEffectFilter** to enable the game to control when sounds play and stop, and to control sound properties such as volume and pitch.</span></span> <span data-ttu-id="c8403-337">たとえば、大理石が迷路から落ちた場合、**MarbleMazeMain::Update** メソッドが **Audio::PlaySoundEffect** メソッドを呼び出して **FallingEvent** サウンドを再生します。</span><span class="sxs-lookup"><span data-stu-id="c8403-337">For example, if the marble falls off the maze, **MarbleMazeMain::Update** calls the **Audio::PlaySoundEffect** method to play the **FallingEvent** sound.</span></span>

```cpp
m_audio.PlaySoundEffect(FallingEvent);
```

<span data-ttu-id="c8403-338">**Audio::PlaySoundEffect** メソッドは [IXAudio2SourceVoice::Start](https://msdn.microsoft.com/library/windows/desktop/ee418471) メソッドを呼び出してサウンドの再生を開始します。</span><span class="sxs-lookup"><span data-stu-id="c8403-338">The **Audio::PlaySoundEffect** method calls the [IXAudio2SourceVoice::Start](https://msdn.microsoft.com/library/windows/desktop/ee418471) method to begin playback of the sound.</span></span> <span data-ttu-id="c8403-339">**IXAudio2SourceVoice::Start** メソッドが既に呼び出されている場合は、もう開始されません。</span><span class="sxs-lookup"><span data-stu-id="c8403-339">If the **IXAudio2SourceVoice::Start** method has already been called, it is not started again.</span></span> <span data-ttu-id="c8403-340">**Audio::PlaySoundEffect** は、続いて特定のサウンドのカスタム ロジックを実行します。</span><span class="sxs-lookup"><span data-stu-id="c8403-340">**Audio::PlaySoundEffect** then performs custom logic for certain sounds.</span></span>

```cpp
void Audio::PlaySoundEffect(SoundEvent sound)
{
    XAUDIO2_BUFFER buf = {0};
    XAUDIO2_VOICE_STATE state = {0};

    if (m_engineExperiencedCriticalError)
    {
        // If there's an error, then we'll recreate the engine on the next
        // render pass.
        return;
    }

    SoundEffectData* soundEffect = &m_soundEffects[sound];
    HRESULT hr = soundEffect->m_soundEffectSourceVoice->Start();

    if FAILED(hr)
    {
        m_engineExperiencedCriticalError = true;
        return;
    }

    // For one-off voices, submit a new buffer if there's none queued up,
    // and allow up to two collisions to be queued up. 
    if (sound != RollingEvent)
    {
        XAUDIO2_VOICE_STATE state = {0};

        soundEffect->m_soundEffectSourceVoice->
            GetState(&state, XAUDIO2_VOICE_NOSAMPLESPLAYED);

        if (state.BuffersQueued == 0)
        {
            soundEffect->m_soundEffectSourceVoice->
                SubmitSourceBuffer(&soundEffect->m_audioBuffer);
        }
        else if (state.BuffersQueued < 2 && sound == CollisionEvent)
        {
            soundEffect->m_soundEffectSourceVoice->
                SubmitSourceBuffer(&soundEffect->m_audioBuffer);
        }

        // For the menu clicks, we want to stop the voice and replay the click
        // right away.
        // Note that stopping and then flushing could cause a glitch due to the
        // waveform not being at a zero-crossing, but due to the nature of the 
        // sound (fast and 'clicky'), we don't mind.
        if (state.BuffersQueued > 0 && sound == MenuChangeEvent)
        {
            soundEffect->m_soundEffectSourceVoice->Stop();
            soundEffect->m_soundEffectSourceVoice->FlushSourceBuffers();

            soundEffect->m_soundEffectSourceVoice->
                SubmitSourceBuffer(&soundEffect->m_audioBuffer);

            soundEffect->m_soundEffectSourceVoice->Start();
        }
    }

    m_soundEffects[sound].m_soundEffectStarted = true;
}
```

<span data-ttu-id="c8403-341">転がる以外の音に関しては、**Audio::PlaySoundEffect** メソッドは [IXAudio2SourceVoice::GetState](https://msdn.microsoft.com/library/windows/desktop/hh405047) を呼び出して、ソース ボイスが再生しているバッファーの数を調べます。</span><span class="sxs-lookup"><span data-stu-id="c8403-341">For sounds other than rolling, the **Audio::PlaySoundEffect** method calls [IXAudio2SourceVoice::GetState](https://msdn.microsoft.com/library/windows/desktop/hh405047) to determine the number of buffers that the source voice is playing.</span></span> <span data-ttu-id="c8403-342">アクティブなバッファーがない場合、[IXAudio2SourceVoice::SubmitSourceBuffer](https://msdn.microsoft.com/library/windows/desktop/ee418473) を呼び出して、サウンドのオーディオ データをボイスの入力キューに追加します。</span><span class="sxs-lookup"><span data-stu-id="c8403-342">It calls [IXAudio2SourceVoice::SubmitSourceBuffer](https://msdn.microsoft.com/library/windows/desktop/ee418473) to add the audio data for the sound to the voice’s input queue if no buffers are active.</span></span> <span data-ttu-id="c8403-343">また、**Audio::PlaySoundEffect** メソッドは、ぶつかる音を 2 回連続して再生できるようにします。</span><span class="sxs-lookup"><span data-stu-id="c8403-343">The **Audio::PlaySoundEffect** method also enables the collision sound to be played two times in sequence.</span></span> <span data-ttu-id="c8403-344">これはたとえば、大理石が迷路の角にぶつかったときに発生します。</span><span class="sxs-lookup"><span data-stu-id="c8403-344">This occurs, for example, when the marble collides with a corner of the maze.</span></span>

<span data-ttu-id="c8403-345">既に説明したように、Audio クラスでは、転がるイベントのサウンドを初期化する際に **XAUDIO2\_LOOP\_INFINITE** フラグが使われています。</span><span class="sxs-lookup"><span data-stu-id="c8403-345">As already described, the Audio class uses the **XAUDIO2\_LOOP\_INFINITE** flag when it initializes the sound for the rolling event.</span></span> <span data-ttu-id="c8403-346">このイベントに対して最初に **Audio::PlaySoundEffect** が呼び出されたときに、サウンドはループ再生を開始します。</span><span class="sxs-lookup"><span data-stu-id="c8403-346">The sound starts looped playback the first time that **Audio::PlaySoundEffect** is called for this event.</span></span> <span data-ttu-id="c8403-347">転がる音の再生のロジックを単純化するために、Marble Maze ではサウンドを停止するのではなくミュートします。</span><span class="sxs-lookup"><span data-stu-id="c8403-347">To simplify the playback logic for the rolling sound, Marble Maze mutes the sound instead of stopping it.</span></span> <span data-ttu-id="c8403-348">Marble Maze は、よりリアルな効果を実現するために、大理石の速度の変化に合わせてサウンドのピッチとボリュームを変化させます。</span><span class="sxs-lookup"><span data-stu-id="c8403-348">As the marble changes velocity, Marble Maze changes the pitch and volume of the sound to give it a more realistic effect.</span></span> <span data-ttu-id="c8403-349">**MarbleMazeMain::Update** メソッドが速度の変化に合わせて大理石のピッチとボリュームを更新し、大理石が停止したときにボリュームを 0 に設定してサウンドをミュートする方法を次に示します。</span><span class="sxs-lookup"><span data-stu-id="c8403-349">The following shows how the **MarbleMazeMain::Update** method updates the pitch and volume of the marble as its velocity changes and how it mutes the sound by setting its volume to zero when the marble stops.</span></span>

```cpp
// Play the roll sound only if the marble is actually rolling.
if (ci.isRollingOnFloor && volume > 0)
{
    if (!m_audio.IsSoundEffectStarted(RollingEvent))
    {
        m_audio.PlaySoundEffect(RollingEvent);
    }

    // Update the volume and pitch by the velocity.
    m_audio.SetSoundEffectVolume(RollingEvent, volume);
    m_audio.SetSoundEffectPitch(RollingEvent, pitch);

    // The rolling sound has at most 8000Hz sounds, so we linearly
    // ramp up the low-pass filter the faster we go.
    // We also reduce the Q-value of the filter, starting with a
    // relatively broad cutoff and get progressively tighter.
    m_audio.SetSoundEffectFilter(
        RollingEvent,
        600.0f + 8000.0f * volume,
        XAUDIO2_MAX_FILTER_ONEOVERQ - volume*volume
        );
}
else
{
    m_audio.SetSoundEffectVolume(RollingEvent, 0);
}
```

## <a name="reacting-to-suspend-and-resume-events"></a><span data-ttu-id="c8403-350">イベントの中断と再開への対応</span><span class="sxs-lookup"><span data-stu-id="c8403-350">Reacting to suspend and resume events</span></span>

<span data-ttu-id="c8403-351">ドキュメント「[Marble Maze のアプリケーション構造](marble-maze-application-structure.md)」では、Marble Maze が中断と再開をどのようにサポートするかを説明しています。</span><span class="sxs-lookup"><span data-stu-id="c8403-351">[Marble Maze application structure](marble-maze-application-structure.md) describes how Marble Maze supports suspend and resume.</span></span> <span data-ttu-id="c8403-352">ゲームが中断されると、オーディオが一時停止されます。</span><span class="sxs-lookup"><span data-stu-id="c8403-352">When the game is suspended, the game pauses the audio.</span></span> <span data-ttu-id="c8403-353">ゲームが再開されると、オーディオが中断した箇所から再開されます。</span><span class="sxs-lookup"><span data-stu-id="c8403-353">When the game resumes, the game resumes the audio where it left off.</span></span> <span data-ttu-id="c8403-354">このような処理を行うのは、不要な場合はリソースを使わないというベスト プラクティスに従うためです。</span><span class="sxs-lookup"><span data-stu-id="c8403-354">We do so to follow the best practice of not using resources when you know they’re not needed.</span></span>

<span data-ttu-id="c8403-355">ゲームが中断されると、**Audio::SuspendAudio** メソッドが呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="c8403-355">The **Audio::SuspendAudio** method is called when the game is suspended.</span></span> <span data-ttu-id="c8403-356">このメソッドは [IXAudio2::StopEngine](https://msdn.microsoft.com/library/windows/desktop/ee418628) メソッドを呼び出して、すべてのオーディオを停止します。</span><span class="sxs-lookup"><span data-stu-id="c8403-356">This method calls the [IXAudio2::StopEngine](https://msdn.microsoft.com/library/windows/desktop/ee418628) method to stop all audio.</span></span> <span data-ttu-id="c8403-357">**IXAudio2::StopEngine** はすべてのオーディオ出力を直ちに停止しますが、オーディオ グラフとその効果のパラメーター (たとえば大理石がバウンドするときに適用されるリバーブ エフェクト) は保持します。</span><span class="sxs-lookup"><span data-stu-id="c8403-357">Although **IXAudio2::StopEngine** stops all audio output immediately, it preserves the audio graph and its effect parameters (for example, the reverb effect that’s applied when the marble bounces).</span></span>

```cpp
// Uses the IXAudio2::StopEngine method to stop all audio immediately.  
// It leaves the audio graph untouched, which preserves all effect parameters   
// and effect histories (like reverb effects) voice states, pending buffers,  
// cursor positions and so on. 
// When the engines are restarted, the resulting audio will sound as if it had  
// never been stopped except for the period of silence. 
void Audio::SuspendAudio()
{
    if (m_engineExperiencedCriticalError)
    {
        return;
    }

    if (m_isAudioStarted)
    {
        m_musicEngine->StopEngine();
        m_soundEffectEngine->StopEngine();
    }

    m_isAudioStarted = false;
}
```

<span data-ttu-id="c8403-358">ゲームが再開されると、**Audio::ResumeAudio** メソッドが呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="c8403-358">The **Audio::ResumeAudio** method is called when the game is resumed.</span></span> <span data-ttu-id="c8403-359">このメソッドは、[IXAudio2::StartEngine](https://msdn.microsoft.com/library/windows/desktop/ee418626) メソッドを使ってオーディオを再開します。</span><span class="sxs-lookup"><span data-stu-id="c8403-359">This method uses the [IXAudio2::StartEngine](https://msdn.microsoft.com/library/windows/desktop/ee418626) method to restart the audio.</span></span> <span data-ttu-id="c8403-360">[IXAudio2::StopEngine](https://msdn.microsoft.com/library/windows/desktop/ee418628) の呼び出しでオーディオ グラフとその効果のパラメーターが保持されているため、オーディオ出力は中断した箇所から再開されます。</span><span class="sxs-lookup"><span data-stu-id="c8403-360">Because the call to [IXAudio2::StopEngine](https://msdn.microsoft.com/library/windows/desktop/ee418628) preserves the audio graph and its effect parameters, the audio output resumes where it left off.</span></span>

```cpp
// Restarts the audio streams. A call to this method must match a previous call
// to SuspendAudio. This method causes audio to continue where it left off.
// If there is a problem with the restart, the m_engineExperiencedCriticalError
// flag is set. The next call to Render will recreate all the resources and
// reset the audio pipeline.
void Audio::ResumeAudio()
{
    if (m_engineExperiencedCriticalError)
    {
        return;
    }

    HRESULT hr = m_musicEngine->StartEngine();
    HRESULT hr2 = m_soundEffectEngine->StartEngine();

    if (FAILED(hr) || FAILED(hr2))
    {
        m_engineExperiencedCriticalError = true;
    }
}
```

## <a name="handling-headphones-and-device-changes"></a><span data-ttu-id="c8403-361">ヘッドホンとデバイスの変更の処理</span><span class="sxs-lookup"><span data-stu-id="c8403-361">Handling headphones and device changes</span></span>

<span data-ttu-id="c8403-362">Marble Maze は、オーディオ デバイスの変更時など、XAudio2 エンジンのエラーをコールバックを使って処理します。</span><span class="sxs-lookup"><span data-stu-id="c8403-362">Marble Maze uses engine callbacks to handle XAudio2 engine failures, such as when the audio device changes.</span></span> <span data-ttu-id="c8403-363">デバイスの変更の一般的な原因は、ユーザーによるヘッドホンの接続と切断です。</span><span class="sxs-lookup"><span data-stu-id="c8403-363">A likely cause of a device change is when the game user connects or disconnects the headphones.</span></span> <span data-ttu-id="c8403-364">デバイスの変更を処理するエンジン コールバックを実装することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="c8403-364">We recommend that you implement the engine callback that handles device changes.</span></span> <span data-ttu-id="c8403-365">これを行わないと、ユーザーがヘッドホンの接続または切断を行ったときに、ゲームが再開されるまでサウンドの再生が停止します。</span><span class="sxs-lookup"><span data-stu-id="c8403-365">Otherwise, your game will stop playing sound when the user plugs in or removes headphones, until the game is restarted.</span></span>

<span data-ttu-id="c8403-366">**Audio.h** は **AudioEngineCallbacks** クラスを定義します。</span><span class="sxs-lookup"><span data-stu-id="c8403-366">**Audio.h** defines the **AudioEngineCallbacks** class.</span></span> <span data-ttu-id="c8403-367">このクラスは、[IXAudio2EngineCallback](https://msdn.microsoft.com/library/windows/desktop/ee415910) インターフェイスを実装します。</span><span class="sxs-lookup"><span data-stu-id="c8403-367">This class implements the [IXAudio2EngineCallback](https://msdn.microsoft.com/library/windows/desktop/ee415910) interface.</span></span>

```cpp
class AudioEngineCallbacks: public IXAudio2EngineCallback
{
private:
    Audio* m_audio;

public :
    AudioEngineCallbacks(){};
    void Initialize(Audio* audio);

    // Called by XAudio2 just before an audio processing pass begins.
    void _stdcall OnProcessingPassStart(){};

    // Called just after an audio processing pass ends.
    void  _stdcall OnProcessingPassEnd(){};

    // Called when a critical system error causes XAudio2
    // to be closed and restarted. The error code is given in Error.
    void  _stdcall OnCriticalError(HRESULT Error);
};
```

<span data-ttu-id="c8403-368">[IXAudio2EngineCallback](https://msdn.microsoft.com/library/windows/desktop/ee415910) インターフェイスは、オーディオ処理イベントが発生したときや、エンジンで重大なエラーが発生したときにコードに通知されるようにします。</span><span class="sxs-lookup"><span data-stu-id="c8403-368">The [IXAudio2EngineCallback](https://msdn.microsoft.com/library/windows/desktop/ee415910) interface enables your code to be notified when audio processing events occur and when the engine encounters a critical error.</span></span> <span data-ttu-id="c8403-369">コールバックを登録するために、Marble Maze は、音楽エンジン用の [IXAudio2](https://msdn.microsoft.com/library/windows/desktop/ee415908) オブジェクトを作成した後に **Audio::CreateResources** で [IXAudio2::RegisterForCallbacks](https://msdn.microsoft.com/library/windows/desktop/ee418620) メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="c8403-369">To register for callbacks, Marble Maze calls the [IXAudio2::RegisterForCallbacks](https://msdn.microsoft.com/library/windows/desktop/ee418620) method in **Audio::CreateResources**, after it creates the [IXAudio2](https://msdn.microsoft.com/library/windows/desktop/ee415908) object for the music engine.</span></span>

```cpp
m_musicEngineCallback.Initialize(this);
m_musicEngine->RegisterForCallbacks(&m_musicEngineCallback);
```

<span data-ttu-id="c8403-370">Marble Maze では、オーディオ処理の開始または終了時の通知は必要ありません。</span><span class="sxs-lookup"><span data-stu-id="c8403-370">Marble Maze does not require notification when audio processing starts or ends.</span></span> <span data-ttu-id="c8403-371">したがって、何も処理を行わない [IXAudio2EngineCallback::OnProcessingPassStart](https://msdn.microsoft.com/library/windows/desktop/ee418463) メソッドと [IXAudio2EngineCallback::OnProcessingPassEnd](https://msdn.microsoft.com/library/windows/desktop/ee418462) メソッドを実装します。</span><span class="sxs-lookup"><span data-stu-id="c8403-371">Therefore, it implements the [IXAudio2EngineCallback::OnProcessingPassStart](https://msdn.microsoft.com/library/windows/desktop/ee418463) and [IXAudio2EngineCallback::OnProcessingPassEnd](https://msdn.microsoft.com/library/windows/desktop/ee418462) methods to do nothing.</span></span> <span data-ttu-id="c8403-372">[IXAudio2EngineCallback::OnCriticalError](https://msdn.microsoft.com/library/windows/desktop/ee418461) メソッドに関しては、**m\_engineExperiencedCriticalError** フラグを設定する **SetEngineExperiencedCriticalError** メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="c8403-372">For the [IXAudio2EngineCallback::OnCriticalError](https://msdn.microsoft.com/library/windows/desktop/ee418461) method, Marble Maze calls the **SetEngineExperiencedCriticalError** method, which sets the **m\_engineExperiencedCriticalError** flag.</span></span>

```cpp
// Audio.cpp

// Called when a critical system error causes XAudio2 
// to be closed and restarted. The error code is given in Error. 
void  _stdcall AudioEngineCallbacks::OnCriticalError(HRESULT Error)
{
    m_audio->SetEngineExperiencedCriticalError();
}
```

```cpp
// Audio.h (Audio class)

// This flag can be used to tell when the audio system 
// is experiencing critial errors.
// XAudio2 gives a critical error when the user unplugs
// the headphones and a new speaker configuration is generated.
void SetEngineExperiencedCriticalError()
{
    m_engineExperiencedCriticalError = true;
}
```

<span data-ttu-id="c8403-373">重大なエラーが発生した場合、オーディオ処理は停止し、それ以降の XAudio2 への呼び出しはすべて失敗します。</span><span class="sxs-lookup"><span data-stu-id="c8403-373">When a critical error occurs, audio processing stops and all additional calls to XAudio2 fail.</span></span> <span data-ttu-id="c8403-374">この状況から回復するには、XAudio2 インスタンスを解放して新しく作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c8403-374">To recover from this situation, you must release the XAudio2 instance and create a new one.</span></span> <span data-ttu-id="c8403-375">ゲーム ループからフレームごとに呼び出される **Audio::Render** メソッドは、最初に **m\_engineExperiencedCriticalError** フラグをチェックします。</span><span class="sxs-lookup"><span data-stu-id="c8403-375">The **Audio::Render** method, which is called from the game loop every frame, first checks the **m\_engineExperiencedCriticalError** flag.</span></span> <span data-ttu-id="c8403-376">このフラグが設定されている場合、フラグをクリアし、現在の XAudio2 インスタンスを解放してリソースを初期化した後、BGM を開始します。</span><span class="sxs-lookup"><span data-stu-id="c8403-376">If this flag is set, it clears the flag, releases the current XAudio2 instance, initializes resources, and then starts the background music.</span></span>

```cpp
if (m_engineExperiencedCriticalError)
{
    m_engineExperiencedCriticalError = false;
    ReleaseResources();
    Initialize();
    CreateResources();
    Start();
    if (m_engineExperiencedCriticalError)
    {
        return;
    }
}
```

<span data-ttu-id="c8403-377">Marble Maze は、利用できるデバイスがない場合に XAudio2 への呼び出しを防ぐ目的でも **m\_engineExperiencedCriticalError** フラグを使います。</span><span class="sxs-lookup"><span data-stu-id="c8403-377">Marble Maze also uses the **m\_engineExperiencedCriticalError** flag to guard against calling into XAudio2 when no audio device is available.</span></span> <span data-ttu-id="c8403-378">たとえば、**MarbleMazeMain::Update** メソッドは、このフラグが設定されているときは転がるイベントまたは衝突するイベントのオーディオを処理しません。</span><span class="sxs-lookup"><span data-stu-id="c8403-378">For example, the **MarbleMazeMain::Update** method does not process audio for rolling or collision events when this flag is set.</span></span> <span data-ttu-id="c8403-379">アプリは必要に応じてフレームごとにオーディオ エンジンの修復を試みますが、コンピューターにオーディオ デバイスがない場合やヘッドホンが外されていて他に利用できるオーディオ デバイスがない場合は、**m\_engineExperiencedCriticalError** フラグが常に設定されます。</span><span class="sxs-lookup"><span data-stu-id="c8403-379">The app attempts to repair the audio engine every frame if it is required; however, the **m\_engineExperiencedCriticalError** flag might always be set if the computer does not have an audio device or the headphones are unplugged and there is no other available audio device.</span></span>

> [!CAUTION]
> <span data-ttu-id="c8403-380">原則として、エンジン コールバックの本体でブロック操作を実行しないでください。</span><span class="sxs-lookup"><span data-stu-id="c8403-380">As a rule, do not perform blocking operations in the body of an engine callback.</span></span> <span data-ttu-id="c8403-381">これを行うと、パフォーマンスの問題が発生することがあります。</span><span class="sxs-lookup"><span data-stu-id="c8403-381">Doing so can cause performance issues.</span></span> <span data-ttu-id="c8403-382">Marble Maze は **OnCriticalError** コールバック内でフラグを設定し、後で通常のオーディオ処理フェーズ中にエラーを処理します。</span><span class="sxs-lookup"><span data-stu-id="c8403-382">Marble Maze sets a flag in the **OnCriticalError** callback and later handles the error during the regular audio processing phase.</span></span> <span data-ttu-id="c8403-383">XAudio2 のコールバックについて詳しくは、「[XAudio2 のコールバック](https://msdn.microsoft.com/library/windows/desktop/ee415745)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c8403-383">For more information about XAudio2 callbacks, see [XAudio2 Callbacks](https://msdn.microsoft.com/library/windows/desktop/ee415745).</span></span>

## <a name="conclusion"></a><span data-ttu-id="c8403-384">まとめ</span><span class="sxs-lookup"><span data-stu-id="c8403-384">Conclusion</span></span>

<span data-ttu-id="c8403-385">ここでは、Marble Maze ゲーム サンプルについてまとめてみます。</span><span class="sxs-lookup"><span data-stu-id="c8403-385">That wraps up the Marble Maze game sample!</span></span> <span data-ttu-id="c8403-386">このゲームは、比較的単純なゲームですが、すべての UWP DirectX ゲームに重要な部分の多くが含まれており、独自のゲームを作成するときに役立つ適切な例になっています。</span><span class="sxs-lookup"><span data-stu-id="c8403-386">Though it is a relatively simple game, it contains many of the important parts that go into any UWP DirectX game, and is a good example to follow when making your own game.</span></span>

<span data-ttu-id="c8403-387">これでチュートリアルは終了です。ソース コードをいろいろ手を加えて、どのような結果になるか確認してみてください。</span><span class="sxs-lookup"><span data-stu-id="c8403-387">Now that you've finished following along, try tinkering around with the source code and seeing what happens.</span></span> <span data-ttu-id="c8403-388">または、「[DirectX によるシンプルな UWP ゲームの作成](tutorial--create-your-first-uwp-directx-game.md)」で別の UWP DirectX ゲームのサンプルを参照してください。</span><span class="sxs-lookup"><span data-stu-id="c8403-388">Or check out [Create a simple UWP game with DirectX](tutorial--create-your-first-uwp-directx-game.md), another UWP DirectX game sample.</span></span>

<span data-ttu-id="c8403-389">DirectX を使いこなす準備ができたら、</span><span class="sxs-lookup"><span data-stu-id="c8403-389">Ready to go further with DirectX?</span></span> <span data-ttu-id="c8403-390">「[DirectX プログラミング](directx-programming.md)」でさまざまなガイドを確認してください。</span><span class="sxs-lookup"><span data-stu-id="c8403-390">Then check out our guides at [DirectX programming](directx-programming.md).</span></span>

<span data-ttu-id="c8403-391">UWP でのゲーム開発全般に関心がある場合は、「[ゲーム プログラミング](index.md)」のドキュメントを参照してください。</span><span class="sxs-lookup"><span data-stu-id="c8403-391">If you're interested in game development on UWP in general, see the documentation at [Game programming](index.md).</span></span>

## <a name="related-topics"></a><span data-ttu-id="c8403-392">関連トピック</span><span class="sxs-lookup"><span data-stu-id="c8403-392">Related topics</span></span>

* [<span data-ttu-id="c8403-393">Marble Maze サンプルへの入力と対話機能の追加</span><span class="sxs-lookup"><span data-stu-id="c8403-393">Adding input and interactivity to the Marble Maze sample</span></span>](adding-input-and-interactivity-to-the-marble-maze-sample.md)
* [<span data-ttu-id="c8403-394">Marble Maze、C++ と DirectX での UWP ゲームの開発</span><span class="sxs-lookup"><span data-stu-id="c8403-394">Developing Marble Maze, a UWP game in C++ and DirectX</span></span>](developing-marble-maze-a-windows-store-game-in-cpp-and-directx.md)