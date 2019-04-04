---
title: サウンドの追加
description: ゲームの再生中の音楽とサウンド効果を XAudio2 Api を使用した単純なサウンド エンジンを開発します。
ms.assetid: aa05efe2-2baa-8b9f-7418-23f5b6cd2266
ms.date: 10/24/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, サウンド
ms.localizationpriority: medium
ms.openlocfilehash: 8d5a976ef65bee5efc3329afc98bf198d094b037
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57589937"
---
# <a name="add-sound"></a><span data-ttu-id="16ce1-104">サウンドの追加</span><span class="sxs-lookup"><span data-stu-id="16ce1-104">Add sound</span></span>

<span data-ttu-id="16ce1-105">このトピックでは単純なサウンド エンジンを使用して作成します[XAudio2](https://msdn.microsoft.com/library/windows/desktop/ee415813) Api。</span><span class="sxs-lookup"><span data-stu-id="16ce1-105">In this topic, we create a simple sound engine using [XAudio2](https://msdn.microsoft.com/library/windows/desktop/ee415813) APIs.</span></span> <span data-ttu-id="16ce1-106">慣れていない場合__XAudio2__、下の短い概要を含めています[オーディオ概念](#audio-concepts)します。</span><span class="sxs-lookup"><span data-stu-id="16ce1-106">If you are new to __XAudio2__, we have included a short intro under [Audio concepts](#audio-concepts).</span></span>

>[!Note]
><span data-ttu-id="16ce1-107">このサンプルの最新ゲーム コードをダウンロードしていない場合は、[Direct3D ゲーム サンプルのページ](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Simple3DGameDX)に移動してください。</span><span class="sxs-lookup"><span data-stu-id="16ce1-107">If you haven't downloaded the latest game code for this sample, go to [Direct3D game sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Simple3DGameDX).</span></span> <span data-ttu-id="16ce1-108">このサンプルは、UWP 機能のサンプルの大規模なコレクションの一部です。</span><span class="sxs-lookup"><span data-stu-id="16ce1-108">This sample is part of a large collection of UWP feature samples.</span></span> <span data-ttu-id="16ce1-109">サンプルをダウンロードする手順については、「[GitHub から UWP のサンプルを取得する](https://docs.microsoft.com/windows/uwp/get-started/get-uwp-app-samples)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="16ce1-109">For instructions on how to download the sample, see [Get the UWP samples from GitHub](https://docs.microsoft.com/windows/uwp/get-started/get-uwp-app-samples).</span></span>

## <a name="objective"></a><span data-ttu-id="16ce1-110">目標</span><span class="sxs-lookup"><span data-stu-id="16ce1-110">Objective</span></span>

<span data-ttu-id="16ce1-111">サンプル ゲームの使用にサウンドを追加[XAudio2](/windows/desktop/xaudio2/xaudio2-introduction)します。</span><span class="sxs-lookup"><span data-stu-id="16ce1-111">Add sounds into the sample game using [XAudio2](/windows/desktop/xaudio2/xaudio2-introduction).</span></span>

## <a name="define-the-audio-engine"></a><span data-ttu-id="16ce1-112">オーディオ エンジンを定義します。</span><span class="sxs-lookup"><span data-stu-id="16ce1-112">Define the audio engine</span></span>

<span data-ttu-id="16ce1-113">このゲーム サンプルでは、オーディオのオブジェクトと動作は次の 3 つのファイルに定義されています。</span><span class="sxs-lookup"><span data-stu-id="16ce1-113">In the game sample, the audio objects and behaviors are defined in three files:</span></span>

* <span data-ttu-id="16ce1-114">__[Audio.h](#audioh)/.cpp__:定義、__オーディオ__を格納するオブジェクト、 __XAudio2__サウンドの再生用のリソース。</span><span class="sxs-lookup"><span data-stu-id="16ce1-114">__[Audio.h](#audioh)/.cpp__: Defines the __Audio__ object, which contains the __XAudio2__ resources for sound playback.</span></span> <span data-ttu-id="16ce1-115">また、ゲームが一時停止または非アクティブにされた場合にオーディオ再生を一時停止して再開するメソッドも定義します。</span><span class="sxs-lookup"><span data-stu-id="16ce1-115">It also defines the method for suspending and resuming audio playback if the game is paused or deactivated.</span></span>
* <span data-ttu-id="16ce1-116">__[MediaReader.h](#mediareaderh)/.cpp__:ローカル ストレージからオーディオ .wav ファイルを読み取るためのメソッドを定義します。</span><span class="sxs-lookup"><span data-stu-id="16ce1-116">__[MediaReader.h](#mediareaderh)/.cpp__: Defines the methods for reading audio .wav files from local storage.</span></span>
* <span data-ttu-id="16ce1-117">__[SoundEffect.h](#soundeffecth)/.cpp__:ゲームでサウンドの再生用のオブジェクトを定義します。</span><span class="sxs-lookup"><span data-stu-id="16ce1-117">__[SoundEffect.h](#soundeffecth)/.cpp__: Defines an object for in-game sound playback.</span></span>

## <a name="overview"></a><span data-ttu-id="16ce1-118">概要</span><span class="sxs-lookup"><span data-stu-id="16ce1-118">Overview</span></span>

<span data-ttu-id="16ce1-119">オーディオの再生をゲームに設定する際に、次の 3 つの主要な部分があります。</span><span class="sxs-lookup"><span data-stu-id="16ce1-119">There are three main parts in getting set up for audio playback into your game.</span></span>

1. [<span data-ttu-id="16ce1-120">作成し、オーディオのリソースの初期化</span><span class="sxs-lookup"><span data-stu-id="16ce1-120">Create and initialize the audio resources</span></span>](#create-and-initialize-the-audio-resources)
2. [<span data-ttu-id="16ce1-121">オーディオ ファイルの読み込み</span><span class="sxs-lookup"><span data-stu-id="16ce1-121">Load audio file</span></span>](#load-audio-file)
3. [<span data-ttu-id="16ce1-122">オブジェクトにサウンドを関連付ける</span><span class="sxs-lookup"><span data-stu-id="16ce1-122">Associate sound to object</span></span>](#associate-sound-to-object)

<span data-ttu-id="16ce1-123">すべてで定義されて、 [Simple3DGame::Initialize](#simple3dgameinitialize-method)メソッド。</span><span class="sxs-lookup"><span data-stu-id="16ce1-123">They are all defined in the [Simple3DGame::Initialize](#simple3dgameinitialize-method) method.</span></span> <span data-ttu-id="16ce1-124">このメソッドとの各セクションではさらに、情報を最初に見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="16ce1-124">So let's first examine this method and then dive into more details in each of the sections.</span></span>

<span data-ttu-id="16ce1-125">設定後、再生するサウンド効果をトリガーする方法を学習します。</span><span class="sxs-lookup"><span data-stu-id="16ce1-125">After setting up, we learn how to trigger the sound effects to play.</span></span> <span data-ttu-id="16ce1-126">詳細についてを参照してください[サウンドを再生](#play-the-sound)します。</span><span class="sxs-lookup"><span data-stu-id="16ce1-126">For more info, go to [Play the sound](#play-the-sound).</span></span>

### <a name="simple3dgameinitialize-method"></a><span data-ttu-id="16ce1-127">Simple3DGame::Initialize メソッド</span><span class="sxs-lookup"><span data-stu-id="16ce1-127">Simple3DGame::Initialize method</span></span>

<span data-ttu-id="16ce1-128">__Simple3DGame::Initialize__ここで、 __m\_コント ローラー__と__m\_レンダラー__は初期化も、オーディオ エンジンを設定し、取得サウンドを再生する準備ができました。</span><span class="sxs-lookup"><span data-stu-id="16ce1-128">In __Simple3DGame::Initialize__, where __m\_controller__ and __m\_renderer__ are also initialized, we set up the audio engine and get it ready to play sounds.</span></span>

 * <span data-ttu-id="16ce1-129">作成__m\_audioController__のインスタンスである、[オーディオ](#audioh)クラス。</span><span class="sxs-lookup"><span data-stu-id="16ce1-129">Create __m\_audioController__, which is an instance of the [Audio](#audioh) class.</span></span>
 * <span data-ttu-id="16ce1-130">使用して必要なオーディオ リソースを作成、 [Audio::CreateDeviceIndependentResources](#audiocreatedeviceindependentresources-method)メソッド。</span><span class="sxs-lookup"><span data-stu-id="16ce1-130">Create the audio resources needed using the [Audio::CreateDeviceIndependentResources](#audiocreatedeviceindependentresources-method) method.</span></span> <span data-ttu-id="16ce1-131">ここでは、2 つ__XAudio2__オブジェクト&mdash;音楽のエンジン オブジェクトと、サウンド エンジン オブジェクトとそれぞれのマスターの音声が作成されました。</span><span class="sxs-lookup"><span data-stu-id="16ce1-131">Here, two __XAudio2__ objects &mdash; a music engine object and a sound engine object, and a mastering voice for each of them were created.</span></span> <span data-ttu-id="16ce1-132">ゲームのバック グラウンド音楽を再生する音楽のエンジン オブジェクトを使用できます。</span><span class="sxs-lookup"><span data-stu-id="16ce1-132">The music engine object can be used to play background music for your game.</span></span> <span data-ttu-id="16ce1-133">ゲームでサウンドを再生するサウンド エンジンを使用できます。</span><span class="sxs-lookup"><span data-stu-id="16ce1-133">The sound engine can be used to play sound effects in your game.</span></span> <span data-ttu-id="16ce1-134">詳細については、[作成オーディオのリソースの初期化と](#create-and-initialize-the-audio-resources)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="16ce1-134">For more info, see [Create and initialize the audio resources](#create-and-initialize-the-audio-resources).</span></span>
 * <span data-ttu-id="16ce1-135">作成__mediaReader__のインスタンスである[MediaReader](#mediareaderh)クラス。</span><span class="sxs-lookup"><span data-stu-id="16ce1-135">Create __mediaReader__, which is an instance of [MediaReader](#mediareaderh) class.</span></span> <span data-ttu-id="16ce1-136">[MediaReader](#mediareaderh)、用のヘルパー クラスは、 [SoundEffect](#soundeffecth)クラス、読み取り小規模なオーディオ ファイルの場所からファイルを同期的に、サウンドのデータをバイト配列として返します。</span><span class="sxs-lookup"><span data-stu-id="16ce1-136">[MediaReader](#mediareaderh), which is a helper class for the [SoundEffect](#soundeffecth) class, reads small audio files synchronously from file location and returns sound data as a byte array.</span></span>
 * <span data-ttu-id="16ce1-137">使用[MediaReader::LoadMedia](#mediareaderloadmedia-method)をその場所からサウンド ファイルを読み込み、作成、 __targetHitSound__読み込む .wav サウンド データを保持する変数。</span><span class="sxs-lookup"><span data-stu-id="16ce1-137">Use [MediaReader::LoadMedia](#mediareaderloadmedia-method) to load sound files from its location and create a __targetHitSound__ variable to hold the loaded .wav sound data.</span></span> <span data-ttu-id="16ce1-138">詳細については、[オーディオ ファイルの読み込み](#load-audio-file)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="16ce1-138">For more info, see [Load audio file](#load-audio-file).</span></span> 

<span data-ttu-id="16ce1-139">サウンド効果は、ゲーム オブジェクトに関連付けられます。</span><span class="sxs-lookup"><span data-stu-id="16ce1-139">Sound effects are associated with the game object.</span></span> <span data-ttu-id="16ce1-140">したがってそのゲーム オブジェクトと、競合が発生したときに、再生するサウンド効果をトリガーします。</span><span class="sxs-lookup"><span data-stu-id="16ce1-140">So when a collision occurs with that game object, it triggers the sound effect to be played.</span></span> <span data-ttu-id="16ce1-141">このゲームのサンプルでは、(使用して問題を持つターゲットを作り出してしまう) 弾薬とターゲットのサウンド効果があります。</span><span class="sxs-lookup"><span data-stu-id="16ce1-141">In this game sample, we have sound effects for the ammo (what we use to shoot targets with) and for the target.</span></span> 
    
* <span data-ttu-id="16ce1-142">__GameObject__クラスを__HitSound__オブジェクトへのサウンド効果を関連付けるために使用するプロパティ。</span><span class="sxs-lookup"><span data-stu-id="16ce1-142">In the __GameObject__ class, there's a __HitSound__ property that is used to associate the sound effect to the object.</span></span>
* <span data-ttu-id="16ce1-143">新しいインスタンスを作成、 [SoundEffect](#soundeffecth)クラスを初期化します。</span><span class="sxs-lookup"><span data-stu-id="16ce1-143">Create a new instance of the [SoundEffect](#soundeffecth) class and initialize it.</span></span> <span data-ttu-id="16ce1-144">初期化中に、サウンド効果のソースの音声が作成されます。</span><span class="sxs-lookup"><span data-stu-id="16ce1-144">During initialization, a source voice for the sound effect is created.</span></span> 
* <span data-ttu-id="16ce1-145">このクラスから提供されるマスタリング音声を使用してサウンドの再生、[オーディオ](#audioh)クラス。</span><span class="sxs-lookup"><span data-stu-id="16ce1-145">This class plays a sound using a mastering voice provided from the [Audio](#audioh) class.</span></span> <span data-ttu-id="16ce1-146">使用してファイルの場所からサウンドのデータを読み取る、 [MediaReader](#mediareaderh)クラス。</span><span class="sxs-lookup"><span data-stu-id="16ce1-146">Sound data is read from file location using the [MediaReader](#mediareaderh) class.</span></span> <span data-ttu-id="16ce1-147">詳細については、[オブジェクトにサウンドを関連付ける](#associate-sound-to-object)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="16ce1-147">For more info, see [Associate sound to object](#associate-sound-to-object).</span></span>

>[!Note]
><span data-ttu-id="16ce1-148">サウンドを再生する実際のトリガーは、移動やこれらのゲーム オブジェクトの競合によって決定されます。</span><span class="sxs-lookup"><span data-stu-id="16ce1-148">The actual trigger to play the sound is determined by the movement and collision of these game objects.</span></span> <span data-ttu-id="16ce1-149">そのため、実際にこれらのサウンドを再生する呼び出しで定義されて、 [Simple3DGame::UpdateDynamics](#simple3dgameupdatedynamics-method)メソッド。</span><span class="sxs-lookup"><span data-stu-id="16ce1-149">Hence, the call to actually play these sounds are defined in the [Simple3DGame::UpdateDynamics](#simple3dgameupdatedynamics-method) method.</span></span> <span data-ttu-id="16ce1-150">詳細についてを参照してください[サウンドを再生](#play-the-sound)します。</span><span class="sxs-lookup"><span data-stu-id="16ce1-150">For more info, go to [Play the sound](#play-the-sound).</span></span>

```cpp
void Simple3DGame::Initialize(
    _In_ MoveLookController^ controller,
    _In_ GameRenderer^ renderer
    )
{
    // ...
    // Create a new Audio class object.
    m_audioController = ref new Audio;

    // Create the audio resources needed.
    // Two XAudio2 objects are created - one for music engine,
    // the other for sound engine. A mastering voice is also
    // created for each of the objects.
    m_audioController->CreateDeviceIndependentResources();

    m_ammo = std::vector<Sphere^>(GameConstants::MaxAmmo);

    // ..
    // Create a media reader which is used to read audio files from its file location.
    MediaReader^ mediaReader = ref new MediaReader;
    auto targetHitSound = mediaReader->LoadMedia("Assets\\hit.wav");

    // Instantiate the targets for use in the game.
    // Each target has a different initial position, size, and orientation.
    // But share a common set of material properties.
    for (int a = 1; a < GameConstants::MaxTargets; a++)
    {
        // ...
        // Create a new sound effect object and associate it
        // with the game object's (target) HitSound property.
        target->HitSound(ref new SoundEffect());

        // Initialize the sound effect object with
        // the sound effect engine, format of the audio wave, and audio data
        // During initialization, source voice of this sound effect is also created.
        target->HitSound()->Initialize(
            m_audioController->SoundEffectEngine(),
            mediaReader->GetOutputWaveFormatEx(),
            targetHitSound
            );
        // ...
    }

    // Instantiate a set of spheres to be used as ammunition for the game
    // and set the material properties of the spheres.
    auto ammoHitSound = mediaReader->LoadMedia("Assets\\bounce.wav");

    for (int a = 0; a < GameConstants::MaxAmmo; a++)
    {
        m_ammo[a] = ref new Sphere;
        m_ammo[a]->Radius(GameConstants::AmmoRadius);
        m_ammo[a]->HitSound(ref new SoundEffect());
        m_ammo[a]->HitSound()->Initialize(
            m_audioController->SoundEffectEngine(),
            mediaReader->GetOutputWaveFormatEx(),
            ammoHitSound
            );
        m_ammo[a]->Active(false);
        m_renderObjects.push_back(m_ammo[a]);
    }
    // ...
}
```

## <a name="create-and-initialize-the-audio-resources"></a><span data-ttu-id="16ce1-151">作成し、オーディオのリソースの初期化</span><span class="sxs-lookup"><span data-stu-id="16ce1-151">Create and initialize the audio resources</span></span>

* <span data-ttu-id="16ce1-152">使用[XAudio2Create](https://msdn.microsoft.com/library/windows/desktop/ee419212)、XAudio2 API、音楽とサウンド効果エンジンを定義する 2 つの新しい XAudio2 オブジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="16ce1-152">Use [XAudio2Create](https://msdn.microsoft.com/library/windows/desktop/ee419212), an XAudio2 API, to create two new XAudio2 objects which define the music and sound effect engines.</span></span> <span data-ttu-id="16ce1-153">このメソッドは、オブジェクトのポインターを返します[IXAudio2](https://msdn.microsoft.com/library/windows/desktop/ee415908)すべてのオーディオ エンジンを管理するインターフェイスの状態、オーディオのスレッドや音声のグラフを処理します。</span><span class="sxs-lookup"><span data-stu-id="16ce1-153">This method returns a pointer to the object's [IXAudio2](https://msdn.microsoft.com/library/windows/desktop/ee415908) interface that manages all audio engine states, the audio processing thread, the voice graph, and more.</span></span>
* <span data-ttu-id="16ce1-154">エンジンがインスタンス化された後に使用して、 [IXAudio2::CreateMasteringVoice](https://msdn.microsoft.com/library/windows/desktop/hh405048)サウンド エンジン オブジェクトの各マスタリング音声を作成します。</span><span class="sxs-lookup"><span data-stu-id="16ce1-154">After the engines have been instantiated, use [IXAudio2::CreateMasteringVoice](https://msdn.microsoft.com/library/windows/desktop/hh405048) to create a mastering voice for each of the sound engine objects.</span></span>

<span data-ttu-id="16ce1-155">詳細についてを参照してください[方法。初期化 XAudio2](https://msdn.microsoft.com/library/windows/desktop/ee415779.aspx)します。</span><span class="sxs-lookup"><span data-stu-id="16ce1-155">For more info, go to [How to: Initialize XAudio2](https://msdn.microsoft.com/library/windows/desktop/ee415779.aspx).</span></span>

### <a name="audiocreatedeviceindependentresources-method"></a><span data-ttu-id="16ce1-156">Audio::CreateDeviceIndependentResources メソッド</span><span class="sxs-lookup"><span data-stu-id="16ce1-156">Audio::CreateDeviceIndependentResources method</span></span>

```cpp

void Audio::CreateDeviceIndependentResources()
{
    UINT32 flags = 0;

    DX::ThrowIfFailed(
        XAudio2Create(&m_musicEngine, flags)
        );

    HRESULT hr = m_musicEngine->CreateMasteringVoice(&m_musicMasteringVoice);
    if (FAILED(hr))
    {
        // Unable to create an audio device
        m_audioAvailable = false;
        return;
    }

    DX::ThrowIfFailed(
        XAudio2Create(&m_soundEffectEngine, flags)
        );

    DX::ThrowIfFailed(
        m_soundEffectEngine->CreateMasteringVoice(&m_soundEffectMasteringVoice)
        );

    m_audioAvailable = true;
}
```

## <a name="load-audio-file"></a><span data-ttu-id="16ce1-157">オーディオ ファイルの読み込み</span><span class="sxs-lookup"><span data-stu-id="16ce1-157">Load audio file</span></span>

<span data-ttu-id="16ce1-158">ゲームのサンプルでは、オーディオ形式ファイルの読み取りにコードが定義されている[MediaReader.h](#mediareaderh)/cpp__ します。</span><span class="sxs-lookup"><span data-stu-id="16ce1-158">In the game sample, the code for reading audio format files is defined in [MediaReader.h](#mediareaderh)/cpp__.</span></span>  <span data-ttu-id="16ce1-159">エンコードされた .wav オーディオ ファイルを読み取り、呼び出し[MediaReader::LoadMedia](#mediareaderloadmedia-method)、入力パラメーターとして .wav のファイル名に渡します。</span><span class="sxs-lookup"><span data-stu-id="16ce1-159">To read an encoded .wav audio file, call [MediaReader::LoadMedia](#mediareaderloadmedia-method), passing in the filename of the .wav as the input parameter.</span></span>

### <a name="mediareaderloadmedia-method"></a><span data-ttu-id="16ce1-160">MediaReader::LoadMedia メソッド</span><span class="sxs-lookup"><span data-stu-id="16ce1-160">MediaReader::LoadMedia method</span></span>

<span data-ttu-id="16ce1-161">このメソッドは、[メディア ファンデーション](https://msdn.microsoft.com/library/windows/desktop/ms694197) API を使って、.wav オーディオ ファイルをパルス符号変調 (PCM) バッファーとして読み取ります。</span><span class="sxs-lookup"><span data-stu-id="16ce1-161">This method uses the [Media Foundation](https://msdn.microsoft.com/library/windows/desktop/ms694197) APIs to read in the .wav audio file as a Pulse Code Modulation (PCM) buffer.</span></span>

#### <a name="set-up-the-source-reader"></a><span data-ttu-id="16ce1-162">ソース リーダーを設定します。</span><span class="sxs-lookup"><span data-stu-id="16ce1-162">Set up the Source Reader</span></span>

1. <span data-ttu-id="16ce1-163">使用[MFCreateSourceReaderFromURL](https://msdn.microsoft.com/library/windows/desktop/dd388110)ソース リーダー、メディアを作成する ([IMFSourceReader](https://msdn.microsoft.com/library/windows/desktop/dd374655))。</span><span class="sxs-lookup"><span data-stu-id="16ce1-163">Use [MFCreateSourceReaderFromURL](https://msdn.microsoft.com/library/windows/desktop/dd388110) to create a media source reader ([IMFSourceReader](https://msdn.microsoft.com/library/windows/desktop/dd374655)).</span></span>
2. <span data-ttu-id="16ce1-164">使用[MFCreateMediaType](https://msdn.microsoft.com/library/windows/desktop/ms693861)メディアの種類を作成する ([IMFMediaType](https://msdn.microsoft.com/library/windows/desktop/ms704850)) オブジェクト (_mediaType_)。</span><span class="sxs-lookup"><span data-stu-id="16ce1-164">Use [MFCreateMediaType](https://msdn.microsoft.com/library/windows/desktop/ms693861) to create a media type ([IMFMediaType](https://msdn.microsoft.com/library/windows/desktop/ms704850)) object (_mediaType_).</span></span> <span data-ttu-id="16ce1-165">メディア形式の説明を表します。</span><span class="sxs-lookup"><span data-stu-id="16ce1-165">It represents a description of a media format.</span></span> 
3. <span data-ttu-id="16ce1-166">指定、 _mediaType_出力をデコードはオーディオは、PCM のオーディオ入力を__XAudio2__を使用できます。</span><span class="sxs-lookup"><span data-stu-id="16ce1-166">Specify that the _mediaType_'s decoded output is PCM audio, which is an audio type that __XAudio2__ can use.</span></span>
4. <span data-ttu-id="16ce1-167">デコード済み出力メディアを呼び出すことによってソース リーダーの入力セット[IMFSourceReader::SetCurrentMediaType](https://msdn.microsoft.com/library/windows/desktop/dd374667.aspx)します。</span><span class="sxs-lookup"><span data-stu-id="16ce1-167">Sets the decoded output media type for the source reader by calling [IMFSourceReader::SetCurrentMediaType](https://msdn.microsoft.com/library/windows/desktop/dd374667.aspx).</span></span>

<span data-ttu-id="16ce1-168">ソース リーダーを使用する理由の詳細についてを参照してください[ソース リーダー](https://msdn.microsoft.com/library/windows/desktop/dd940436.aspx)します。</span><span class="sxs-lookup"><span data-stu-id="16ce1-168">For more info on why we use the Source Reader, go to [Source Reader](https://msdn.microsoft.com/library/windows/desktop/dd940436.aspx).</span></span>

#### <a name="describe-the-data-format-of-the-audio-stream"></a><span data-ttu-id="16ce1-169">オーディオ ストリームのデータ形式について説明します</span><span class="sxs-lookup"><span data-stu-id="16ce1-169">Describe the data format of the audio stream</span></span>

1. <span data-ttu-id="16ce1-170">使用[IMFSourceReader::GetCurrentMediaType](https://msdn.microsoft.com/library/windows/desktop/dd374660)ストリームの現在のメディアの種類を取得します。</span><span class="sxs-lookup"><span data-stu-id="16ce1-170">Use [IMFSourceReader::GetCurrentMediaType](https://msdn.microsoft.com/library/windows/desktop/dd374660) to get the current media type for the stream.</span></span>
2. <span data-ttu-id="16ce1-171">使用[IMFMediaType::MFCreateWaveFormatExFromMFMediaType](https://msdn.microsoft.com/library/windows/desktop/ms702177)に現在のオーディオ メディアの種類に変換する、 [WAVEFORMATEX](https://msdn.microsoft.com/library/windows/hardware/ff538799)バッファー、以前の操作の結果を入力として使用します。</span><span class="sxs-lookup"><span data-stu-id="16ce1-171">Use [IMFMediaType::MFCreateWaveFormatExFromMFMediaType](https://msdn.microsoft.com/library/windows/desktop/ms702177) to convert the current audio media type to a [WAVEFORMATEX](https://msdn.microsoft.com/library/windows/hardware/ff538799) buffer, using the results of the earlier operation as input.</span></span> <span data-ttu-id="16ce1-172">この構造体には、オーディオが読み込まれた後に使用される wave オーディオ ストリームのデータ形式を指定します。</span><span class="sxs-lookup"><span data-stu-id="16ce1-172">This structure specifies the data format of the wave audio stream that is used after audio is loaded.</span></span> 

<span data-ttu-id="16ce1-173">__WAVEFORMATEX__ PCM バッファーを記述する形式を使用できます。</span><span class="sxs-lookup"><span data-stu-id="16ce1-173">The __WAVEFORMATEX__ format can be used to describe the PCM buffer.</span></span> <span data-ttu-id="16ce1-174">比較、 [WAVEFORMATEXTENSIBLE](https://msdn.microsoft.com/library/windows/hardware/ff538802)構造、wave オーディオ形式のサブセットの記述にのみ使用できます。</span><span class="sxs-lookup"><span data-stu-id="16ce1-174">As compared to the [WAVEFORMATEXTENSIBLE](https://msdn.microsoft.com/library/windows/hardware/ff538802) structure, it can only be used to describe a subset of audio wave formats.</span></span> <span data-ttu-id="16ce1-175">詳細の相違点について__WAVEFORMATEX__と__WAVEFORMATEXTENSIBLE__を参照してください[Wave 形式の拡張可能な記述子](https://docs.microsoft.com/windows-hardware/drivers/audio/extensible-wave-format-descriptors)します。</span><span class="sxs-lookup"><span data-stu-id="16ce1-175">For more info about the differences between __WAVEFORMATEX__ and __WAVEFORMATEXTENSIBLE__, see [Extensible Wave-Format Descriptors](https://docs.microsoft.com/windows-hardware/drivers/audio/extensible-wave-format-descriptors).</span></span>

#### <a name="read-the-audio-stream"></a><span data-ttu-id="16ce1-176">オーディオ ストリームを読み取り</span><span class="sxs-lookup"><span data-stu-id="16ce1-176">Read the audio stream</span></span>

1.  <span data-ttu-id="16ce1-177">取得、期間 (秒) を呼び出すことによって、オーディオ ストリームの[IMFSourceReader::GetPresentationAttribute](https://msdn.microsoft.com/library/windows/desktop/dd374662)バイトに期間を変換します。</span><span class="sxs-lookup"><span data-stu-id="16ce1-177">Get the duration, in seconds, of the audio stream by calling [IMFSourceReader::GetPresentationAttribute](https://msdn.microsoft.com/library/windows/desktop/dd374662) and then converts the duration to bytes.</span></span>
2.  <span data-ttu-id="16ce1-178">ストリームとして呼び出してでオーディオ ファイルを読み取る[IMFSourceReader::ReadSample](https://msdn.microsoft.com/library/windows/desktop/dd374665)します。</span><span class="sxs-lookup"><span data-stu-id="16ce1-178">Read the audio file in as a stream by calling [IMFSourceReader::ReadSample](https://msdn.microsoft.com/library/windows/desktop/dd374665).</span></span> <span data-ttu-id="16ce1-179">__ReadSample__メディア ソースから次のサンプルを読み取ります。</span><span class="sxs-lookup"><span data-stu-id="16ce1-179">__ReadSample__ reads the next sample from the media source.</span></span>
3.  <span data-ttu-id="16ce1-180">使用[IMFSample::ConvertToContiguousBuffer](https://msdn.microsoft.com/library/windows/desktop/ms698917.aspx)オーディオ サンプル バッファーの内容をコピーする (_サンプル_) 配列に (_mediaBuffer_)。</span><span class="sxs-lookup"><span data-stu-id="16ce1-180">Use [IMFSample::ConvertToContiguousBuffer](https://msdn.microsoft.com/library/windows/desktop/ms698917.aspx) to copy contents of the audio sample buffer (_sample_) into an array (_mediaBuffer_).</span></span>

```cpp
Platform::Array<byte>^ MediaReader::LoadMedia(_In_ Platform::String^ filename)
{
    DX::ThrowIfFailed(
        MFStartup(MF_VERSION)
        );

    // Creates a media source reader.
    ComPtr<IMFSourceReader> reader;
    DX::ThrowIfFailed(
        MFCreateSourceReaderFromURL(
            Platform::String::Concat(m_installedLocationPath, filename)->Data(),
            nullptr,
            &reader
            )
        );

    // Set the decoded output format as PCM.
    // XAudio2 on Windows can process PCM and ADPCM-encoded buffers.
    // When using MediaFoundation, this sample always decodes into PCM.
    Microsoft::WRL::ComPtr<IMFMediaType> mediaType;
    DX::ThrowIfFailed(
        MFCreateMediaType(&mediaType)
        );

    // Define the major category of the media as audio. For more info about major media types,
    // go to: https://msdn.microsoft.com/library/windows/desktop/aa367377.aspx
    DX::ThrowIfFailed(
        mediaType->SetGUID(MF_MT_MAJOR_TYPE, MFMediaType_Audio)
        );

    // Define the sub-type of the media as uncompressed PCM audio. For more info about audio sub-types,
    // go to: https://msdn.microsoft.com/library/windows/desktop/aa372553.aspx
    DX::ThrowIfFailed(
        mediaType->SetGUID(MF_MT_SUBTYPE, MFAudioFormat_PCM)
        );
    
    // Sets the media type for a stream. This media type defines that format that the Source Reader 
    // produces as output. It can differ from the native format provided by the media source.
    // For more info, go to https://msdn.microsoft.com/library/windows/desktop/dd374667.aspx
    DX::ThrowIfFailed(
        reader->SetCurrentMediaType(static_cast<uint32>(MF_SOURCE_READER_FIRST_AUDIO_STREAM), 0, mediaType.Get())
        );

    // Get the current media type for the stream.
    // For more info, go to:
    // https://msdn.microsoft.com/library/windows/desktop/dd374660.aspx
        Microsoft::WRL::ComPtr<IMFMediaType> outputMediaType;
    DX::ThrowIfFailed(
        reader->GetCurrentMediaType(static_cast<uint32>(MF_SOURCE_READER_FIRST_AUDIO_STREAM), &outputMediaType)
        );

    // Converts the current media type into the WaveFormatEx buffer structure.
    UINT32 size = 0;
    WAVEFORMATEX* waveFormat;
    DX::ThrowIfFailed(
        MFCreateWaveFormatExFromMFMediaType(outputMediaType.Get(), &waveFormat, &size)
        );

    // Copies the waveFormat's block of memory to the starting address of the m_waveFormat variable in MediaReader.
    // Then free the waveFormat memory block.
    // For more info, go to https://msdn.microsoft.com/library/windows/desktop/aa366535.aspx and
    // https://msdn.microsoft.com/library/windows/desktop/ms680722.aspx
    CopyMemory(&m_waveFormat, waveFormat, sizeof(m_waveFormat));
    CoTaskMemFree(waveFormat);

    PROPVARIANT propVariant;
    DX::ThrowIfFailed(
        reader->GetPresentationAttribute(static_cast<uint32>(MF_SOURCE_READER_MEDIASOURCE), MF_PD_DURATION, &propVariant)
        );

    // 'duration' is in 100ns units; convert to seconds, and round up
    // to the nearest whole byte.
    LONGLONG duration = propVariant.uhVal.QuadPart;
    unsigned int maxStreamLengthInBytes =
        static_cast<unsigned int>(
            ((duration * static_cast<ULONGLONG>(m_waveFormat.nAvgBytesPerSec)) + 10000000) /
            10000000
            );

    Platform::Array<byte>^ fileData = ref new Platform::Array<byte>(maxStreamLengthInBytes);

    ComPtr<IMFSample> sample;
    ComPtr<IMFMediaBuffer> mediaBuffer;
    DWORD flags = 0;

    int positionInData = 0;
    bool done = false;
    while (!done)
    {
        //...
        // Read audio data.
    }

    return fileData;
}
```
## <a name="associate-sound-to-object"></a><span data-ttu-id="16ce1-181">オブジェクトにサウンドを関連付ける</span><span class="sxs-lookup"><span data-stu-id="16ce1-181">Associate sound to object</span></span>

<span data-ttu-id="16ce1-182">オブジェクトにサウンドを関連付けることが行われるときに、ゲームを初期化します、 [Simple3DGame::Initialize](#simple3dgameinitialize-method)メソッド。</span><span class="sxs-lookup"><span data-stu-id="16ce1-182">Associating sounds to the object takes place when the game initializes, in the [Simple3DGame::Initialize](#simple3dgameinitialize-method) method.</span></span>

<span data-ttu-id="16ce1-183">要約:</span><span class="sxs-lookup"><span data-stu-id="16ce1-183">Recap:</span></span>
* <span data-ttu-id="16ce1-184">__GameObject__クラスを__HitSound__オブジェクトへのサウンド効果を関連付けるために使用するプロパティ。</span><span class="sxs-lookup"><span data-stu-id="16ce1-184">In the __GameObject__ class, there's a __HitSound__ property that is used to associate the sound effect to the object.</span></span>
* <span data-ttu-id="16ce1-185">新しいインスタンスを作成、 [SoundEffect](#soundeffecth)オブジェクトのクラスし、ゲーム オブジェクトに関連付けます。</span><span class="sxs-lookup"><span data-stu-id="16ce1-185">Create a new instance of the [SoundEffect](#soundeffecth) class object and associate it with the game object.</span></span> <span data-ttu-id="16ce1-186">このクラスを再生するサウンドを使用して__XAudio2__ Api。</span><span class="sxs-lookup"><span data-stu-id="16ce1-186">This class plays a sound using __XAudio2__ APIs.</span></span>  <span data-ttu-id="16ce1-187">によって提供されるマスタリング音声を使用して、[オーディオ](#audioh)クラス。</span><span class="sxs-lookup"><span data-stu-id="16ce1-187">It uses a mastering voice provided by the [Audio](#audioh) class.</span></span> <span data-ttu-id="16ce1-188">使用してファイルの場所からサウンドのデータを読み取ることができます、 [MediaReader](#mediareaderh)クラス。</span><span class="sxs-lookup"><span data-stu-id="16ce1-188">The sound data can be read from file location using the [MediaReader](#mediareaderh) class.</span></span>

<span data-ttu-id="16ce1-189">[SoundEffect::Initialize](#soundeffectinitialize-method)を初期化するために使用、 __SoundEffect__次の入力パラメーターを持つインスタンス: サウンド エンジン オブジェクトへのポインター (で作成された IXAudio2 オブジェクト、[オーディオ。CreateDeviceIndependentResources](#audiocreatedeviceindependentresources-method)メソッド)、書式設定へのポインターを使用して .wav ファイル__MediaReader::GetOutputWaveFormatEx__を使用してサウンドのデータが読み込まれると[MediaReader::LoadMedia](#mediareaderloadmedia-method)メソッド。</span><span class="sxs-lookup"><span data-stu-id="16ce1-189">[SoundEffect::Initialize](#soundeffectinitialize-method) is used to initalize the __SoundEffect__ instance with the following input parameters: pointer to sound engine object (IXAudio2 objects created in the [Audio::CreateDeviceIndependentResources](#audiocreatedeviceindependentresources-method) method), pointer to format of the .wav file using __MediaReader::GetOutputWaveFormatEx__, and the sound data loaded using [MediaReader::LoadMedia](#mediareaderloadmedia-method) method.</span></span> <span data-ttu-id="16ce1-190">初期化中に、サウンド効果のソース音声も作成されます。</span><span class="sxs-lookup"><span data-stu-id="16ce1-190">During initialization, the source voice for the sound effect is also created.</span></span>

### <a name="soundeffectinitialize-method"></a><span data-ttu-id="16ce1-191">SoundEffect::Initialize メソッド</span><span class="sxs-lookup"><span data-stu-id="16ce1-191">SoundEffect::Initialize method</span></span>

```cpp
void SoundEffect::Initialize(
    _In_ IXAudio2 *masteringEngine,
    _In_ WAVEFORMATEX *sourceFormat,
    _In_ Platform::Array<byte>^ soundData)
{
    m_soundData = soundData;

    if (masteringEngine == nullptr)
    {
        // Audio is not available so just return.
        m_audioAvailable = false;
        return;
    }

    // Create a source voice for this sound effect.
    DX::ThrowIfFailed(
        masteringEngine->CreateSourceVoice(
            &m_sourceVoice,
            sourceFormat
            )
        );
    m_audioAvailable = true;
}
```

## <a name="play-the-sound"></a><span data-ttu-id="16ce1-192">サウンドを再生します。</span><span class="sxs-lookup"><span data-stu-id="16ce1-192">Play the sound</span></span>

<span data-ttu-id="16ce1-193">サウンドを再生するトリガーが定義されている[Simple3DGame::UpdateDynamics](#simple3dgameupdatedynamics-method)メソッドがこれが、オブジェクトの移動を更新し、オブジェクト間の競合が決まります。</span><span class="sxs-lookup"><span data-stu-id="16ce1-193">Triggers to play sound effects are defined in [Simple3DGame::UpdateDynamics](#simple3dgameupdatedynamics-method) method because this is where movement of the objects are updated and collision between objects is determined.</span></span>

<span data-ttu-id="16ce1-194">オブジェクト間の相互作用が、ゲームによって、大幅に異なりますのでゲーム オブジェクトには、ここの dynamics を説明することはできません。</span><span class="sxs-lookup"><span data-stu-id="16ce1-194">Since interaction of between objects differs greatly, depending on the game, we are not going to discuss the dynamics of the game objects here.</span></span> <span data-ttu-id="16ce1-195">その実装の理解を知りたい場合に移動[Simple3DGame::UpdateDynamics](#simple3dgameupdatedynamics-method)メソッド。</span><span class="sxs-lookup"><span data-stu-id="16ce1-195">If you're interested to understand its implementation, go to [Simple3DGame::UpdateDynamics](#simple3dgameupdatedynamics-method) method.</span></span>

<span data-ttu-id="16ce1-196">原則として、競合が発生したときにトリガーを呼び出してを再生するサウンド効果**SoundEffect::PlaySound**します。</span><span class="sxs-lookup"><span data-stu-id="16ce1-196">In principle, when a collision occurs, it triggers the sound effect to play by calling **SoundEffect::PlaySound**.</span></span> <span data-ttu-id="16ce1-197">このメソッドは、任意のサウンド効果が現在再生中し、目的のサウンドのデータをメモリ内のバッファーにキューを停止します。</span><span class="sxs-lookup"><span data-stu-id="16ce1-197">This method stops any sound effects that's currently playing and queues the in-memory buffer with the desired sound data.</span></span> <span data-ttu-id="16ce1-198">ボリュームの設定、サウンドのデータを送信し、再生を開始するソースの音声を使用します。</span><span class="sxs-lookup"><span data-stu-id="16ce1-198">It uses source voice to set the volume, submit sound data, and start the playback.</span></span>

### <a name="soundeffectplaysound-method"></a><span data-ttu-id="16ce1-199">SoundEffect::PlaySound メソッド</span><span class="sxs-lookup"><span data-stu-id="16ce1-199">SoundEffect::PlaySound method</span></span>

* <span data-ttu-id="16ce1-200">ソースの音声オブジェクトを使用して**m\_sourceVoice**サウンド データ バッファーの再生を開始する**m\_soundData**</span><span class="sxs-lookup"><span data-stu-id="16ce1-200">Uses the source voice object **m\_sourceVoice** to start the playback of the sound data buffer **m\_soundData**</span></span>
* <span data-ttu-id="16ce1-201">作成、 [XAUDIO2\_バッファー](https://msdn.microsoft.com/library/windows/desktop/ee419228)するサウンド データ バッファーへの参照を提供およびへの呼び出しに送信します、 [IXAudio2SourceVoice::SubmitSourceBuffer](https://msdn.microsoft.com/library/windows/desktop/ee418473)します。</span><span class="sxs-lookup"><span data-stu-id="16ce1-201">Creates an [XAUDIO2\_BUFFER](https://msdn.microsoft.com/library/windows/desktop/ee419228), to which it provides a reference to the sound data buffer, and then submits it with a call to [IXAudio2SourceVoice::SubmitSourceBuffer](https://msdn.microsoft.com/library/windows/desktop/ee418473).</span></span> 
* <span data-ttu-id="16ce1-202">サウンドのデータをキューに入れ、 **SoundEffect::PlaySound**開始を呼び出すことによって再生[IXAudio2SourceVoice::Start](https://msdn.microsoft.com/library/windows/desktop/ee418471)します。</span><span class="sxs-lookup"><span data-stu-id="16ce1-202">With the sound data queued up, **SoundEffect::PlaySound** starts play back by calling [IXAudio2SourceVoice::Start](https://msdn.microsoft.com/library/windows/desktop/ee418471).</span></span>

```cpp
void SoundEffect::PlaySound(_In_ float volume)
{
    XAUDIO2_BUFFER buffer = {0};
    XAUDIO2_VOICE_STATE state = {0};

    if (!m_audioAvailable)
    {
        // Audio is not available, so just return.
        return;
    }

    // Interrupt sound effect if currently playing.
    DX::ThrowIfFailed(
        m_sourceVoice->Stop()
        );
    DX::ThrowIfFailed(
        m_sourceVoice->FlushSourceBuffers()
        );

    // Queue in-memory buffer for playback and start the voice.
    buffer.AudioBytes = m_soundData->Length;
    buffer.pAudioData = m_soundData->Data;
    buffer.Flags = XAUDIO2_END_OF_STREAM;

    m_sourceVoice->SetVolume(volume);
    DX::ThrowIfFailed(
        m_sourceVoice->SubmitSourceBuffer(&buffer)
        );
    DX::ThrowIfFailed(
        m_sourceVoice->Start()
        );
}
```

### <a name="simple3dgameupdatedynamics-method"></a><span data-ttu-id="16ce1-203">Simple3DGame::UpdateDynamics メソッド</span><span class="sxs-lookup"><span data-stu-id="16ce1-203">Simple3DGame::UpdateDynamics method</span></span>

<span data-ttu-id="16ce1-204">__Simple3DGame::UpdateDynamics__相互作用とゲーム オブジェクト間の競合メソッドを行います。</span><span class="sxs-lookup"><span data-stu-id="16ce1-204">The __Simple3DGame::UpdateDynamics__ method takes care the interaction and collision between game objects.</span></span> <span data-ttu-id="16ce1-205">オブジェクトが競合 (または intersect) ときに再生する場合は、関連付けられているサウンド効果をトリガーします。</span><span class="sxs-lookup"><span data-stu-id="16ce1-205">When objects collide (or intersect), it triggers the associated sound effect to play.</span></span>

```cpp
void Simple3DGame::UpdateDynamics()
{
    // ...
    // Check for collisions between ammo.
#pragma region inter-ammo collision detection
    if (m_ammoCount > 1)
    {
       // ...
       // Check collision between instances One and Two.
       // ...
       if (distanceSquared < (GameConstants::AmmoSize * GameConstants::AmmoSize))
       {
           // The two ammo are intersecting.
           // ...
           // Start playing the sounds for the impact between the two balls.
              m_ammo[one]->PlaySound(impact, m_player->Position());
              m_ammo[two]->PlaySound(impact, m_player->Position());

       }
    }
#pragma endregion

#pragma region Ammo-Object intersections
    // Check for intersections between the ammo and the other objects in the scene.
    // ...
    // Ball is in contact with Object.
    // ...

    // Make sure that the ball is actually headed towards the object. At grazing angles there
    // could appear to be an impact when the ball is actually already hit and moving away.
    if (impact > 0.0f)
    {
        // ...
        // Play the sound associated with the Ammo hitting something.
           m_ammo[one]->PlaySound(impact, m_player->Position());

        if (m_objects[i]->Target() && !m_objects[i]->Hit())
        {
            // The object is a target and isn't currently hit, so mark it as hit and
            // play the sound associated with the impact.
             m_objects[i]->Hit(true);
             m_objects[i]->HitTime(timeTotal);
             m_totalHits++;

             m_objects[i]->PlaySound(impact, m_player->Position());
        }
        // ...
    }
#pragma endregion

#pragma region Apply Gravity and world intersection
    // Apply gravity and check for collision against enclosing volume.
    // ...
    if (position.z < limit)
    {
        // The ammo instance hit the a wall in the min Z direction.
        // Align the ammo instance to the wall, invert the Z component of the velocity and
        // play the impact sound.
           position.z = limit;
           m_ammo[i]->PlaySound(-velocity.z, m_player->Position());
           velocity.z = -velocity.z * GameConstants::Physics::GroundRestitution;
    }
    // ...
#pragma endregion
}
```
## <a name="next-steps"></a><span data-ttu-id="16ce1-206">次のステップ</span><span class="sxs-lookup"><span data-stu-id="16ce1-206">Next steps</span></span>

<span data-ttu-id="16ce1-207">UWP のフレームワーク、グラフィックス、コントロール、ユーザー インターフェイス、および Windows 10 ゲームのオーディオを説明します。</span><span class="sxs-lookup"><span data-stu-id="16ce1-207">We have covered the UWP framework, graphics, controls, user interface, and audio of a Windows 10 game.</span></span> <span data-ttu-id="16ce1-208">このチュートリアルの次の部分[ゲームのサンプルを拡張する](tutorial-resources.md)ゲームを開発する際に使用できるその他のオプションについて説明します。</span><span class="sxs-lookup"><span data-stu-id="16ce1-208">The next part of this tutorial, [Extending the game sample](tutorial-resources.md), explains other options that can be used when developing a game.</span></span>

## <a name="audio-concepts"></a><span data-ttu-id="16ce1-209">オーディオの概念</span><span class="sxs-lookup"><span data-stu-id="16ce1-209">Audio concepts</span></span>

<span data-ttu-id="16ce1-210">Windows 10 ゲームの開発、XAudio2 バージョン 2.9 を使用します。</span><span class="sxs-lookup"><span data-stu-id="16ce1-210">For Windows 10 games development, use XAudio2 version 2.9.</span></span> <span data-ttu-id="16ce1-211">このバージョンには、Windows 10 が同梱されています。</span><span class="sxs-lookup"><span data-stu-id="16ce1-211">This version is shipped with Windows 10.</span></span> <span data-ttu-id="16ce1-212">詳細についてを参照してください[XAudio2 バージョン](https://msdn.microsoft.com/library/windows/desktop/ee415802.aspx)します。</span><span class="sxs-lookup"><span data-stu-id="16ce1-212">For more info, go to [XAudio2 Versions](https://msdn.microsoft.com/library/windows/desktop/ee415802.aspx).</span></span>

<span data-ttu-id="16ce1-213">__AudioX2__は信号処理や基盤を提供する低レベルの API です。</span><span class="sxs-lookup"><span data-stu-id="16ce1-213">__AudioX2__ is a low-level API that provides signal processing and mixing foundation.</span></span> <span data-ttu-id="16ce1-214">詳細については、[XAudio2 Key Concepts](https://msdn.microsoft.com/library/windows/desktop/ee415764.aspx)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="16ce1-214">For more info, see [XAudio2 Key Concepts](https://msdn.microsoft.com/library/windows/desktop/ee415764.aspx).</span></span>

### <a name="xaudio2-voices"></a><span data-ttu-id="16ce1-215">XAudio2 音声</span><span class="sxs-lookup"><span data-stu-id="16ce1-215">XAudio2 voices</span></span>

<span data-ttu-id="16ce1-216">XAudio2 音声オブジェクトの 3 種類があります: ソースをおよび音声を習得します。</span><span class="sxs-lookup"><span data-stu-id="16ce1-216">There are three types of XAudio2 voice objects: source, submix, and mastering voices.</span></span> <span data-ttu-id="16ce1-217">音声は、XAudio2 オブジェクトを使用して、処理、操作、およびオーディオ データを再生します。</span><span class="sxs-lookup"><span data-stu-id="16ce1-217">Voices are the objects XAudio2 use to process, to manipulate, and to play audio data.</span></span> 
* <span data-ttu-id="16ce1-218">ソース ボイスは、クライアントから提供されたオーディオ データに適用されます。</span><span class="sxs-lookup"><span data-stu-id="16ce1-218">Source voices operate on audio data provided by the client.</span></span> 
* <span data-ttu-id="16ce1-219">ソース ボイスとサブミックス ボイスは、1 つ以上のサブミックス ボイスまたはマスタリング ボイスに向けて出力を送信します。</span><span class="sxs-lookup"><span data-stu-id="16ce1-219">Source and submix voices send their output to one or more submix or mastering voices.</span></span> 
* <span data-ttu-id="16ce1-220">サブミックス ボイスとマスタリング ボイスは、それぞれに送られるすべてのボイスからオーディオをミキシングし、その結果に対して作用します。</span><span class="sxs-lookup"><span data-stu-id="16ce1-220">Submix and mastering voices mix the audio from all voices feeding them, and operate on the result.</span></span> 
* <span data-ttu-id="16ce1-221">マスタリング音声では、ソース ボイスとサブミックス音声からデータを受信し、オーディオ ハードウェアにそのデータを送信します。</span><span class="sxs-lookup"><span data-stu-id="16ce1-221">Mastering voices receive data from source voices and submix voices, and sends that data to the audio hardware.</span></span>

<span data-ttu-id="16ce1-222">詳細についてを参照してください[XAudio2 音声](/windows/desktop/xaudio2/xaudio2-voices)します。</span><span class="sxs-lookup"><span data-stu-id="16ce1-222">For more info, go to [XAudio2 voices](/windows/desktop/xaudio2/xaudio2-voices).</span></span>

### <a name="audio-graph"></a><span data-ttu-id="16ce1-223">オーディオのグラフ</span><span class="sxs-lookup"><span data-stu-id="16ce1-223">Audio graph</span></span>

<span data-ttu-id="16ce1-224">オーディオのグラフのコレクションである[XAudio2 音声](/windows/desktop/xaudio2/xaudio2-voices)します。</span><span class="sxs-lookup"><span data-stu-id="16ce1-224">Audio graph is a collection of [XAudio2 voices](/windows/desktop/xaudio2/xaudio2-voices).</span></span> <span data-ttu-id="16ce1-225">オーディオ音源のオーディオのグラフの一方の側から開始するには、必要に応じて、1 つまたは複数のサブミックス音声を通過およびマスタリング音声で終了します。</span><span class="sxs-lookup"><span data-stu-id="16ce1-225">Audio starts at one side of an audio graph in source voices, optionally passes through one or more submix voices, and ends at a mastering voice.</span></span> <span data-ttu-id="16ce1-226">オーディオのグラフは、それぞれのサウンドを再生中に 0 個以上のサブミックス音声用ソース音声と 1 つのマスタリング音声が格納されます。</span><span class="sxs-lookup"><span data-stu-id="16ce1-226">An audio graph will contain a source voice for each sound currently playing, zero or more submix voices, and one mastering voice.</span></span> <span data-ttu-id="16ce1-227">最も簡単なオーディオ グラフと、XAudio2 で音を鳴らす必要な最小値は、マスタリング音声に直接出力する 1 つのソース音声です。</span><span class="sxs-lookup"><span data-stu-id="16ce1-227">The simplest audio graph, and the minimum needed to make a noise in XAudio2, is a single source voice outputting directly to a mastering voice.</span></span> <span data-ttu-id="16ce1-228">詳細についてを参照してください[オーディオ グラフ](https://msdn.microsoft.com/library/windows/desktop/ee415739.aspx)します。</span><span class="sxs-lookup"><span data-stu-id="16ce1-228">For more info, go to [Audio graphs](https://msdn.microsoft.com/library/windows/desktop/ee415739.aspx).</span></span>

### <a name="additional-reading"></a><span data-ttu-id="16ce1-229">その他の情報</span><span class="sxs-lookup"><span data-stu-id="16ce1-229">Additional reading</span></span>

* <span data-ttu-id="16ce1-230">「[XAudio2 を初期化します。](https://msdn.microsoft.com/library/windows/desktop/ee415779.aspx)</span><span class="sxs-lookup"><span data-stu-id="16ce1-230">[How to: Initialize XAudio2](https://msdn.microsoft.com/library/windows/desktop/ee415779.aspx)</span></span>
* <span data-ttu-id="16ce1-231">「[XAudio2 にオーディオ データ ファイルを読み込む](https://msdn.microsoft.com/library/windows/desktop/ee415781(v=vs.85).aspx)</span><span class="sxs-lookup"><span data-stu-id="16ce1-231">[How to: Load Audio Data Files in XAudio2](https://msdn.microsoft.com/library/windows/desktop/ee415781(v=vs.85).aspx)</span></span>
* <span data-ttu-id="16ce1-232">「[XAudio2 で音を鳴らす](https://msdn.microsoft.com/library/windows/desktop/ee415787.aspx)</span><span class="sxs-lookup"><span data-stu-id="16ce1-232">[How to: Play a Sound with XAudio2](https://msdn.microsoft.com/library/windows/desktop/ee415787.aspx)</span></span>

## <a name="key-audio-h-files"></a><span data-ttu-id="16ce1-233">キーのオーディオ .h ファイル</span><span class="sxs-lookup"><span data-stu-id="16ce1-233">Key audio .h files</span></span>

### <a name="audioh"></a><span data-ttu-id="16ce1-234">Audio.h</span><span class="sxs-lookup"><span data-stu-id="16ce1-234">Audio.h</span></span>

```cpp
// Audio:
// This class uses XAudio2 to provide sound output.  It creates two
// engines - one for music and the other for sound effects - each as
// a separate mastering voice.
// The SuspendAudio and ResumeAudio methods can be used to stop
// and start all audio playback.
public:
    Audio();

    void Initialize();
    void CreateDeviceIndependentResources();
    IXAudio2* MusicEngine();
    IXAudio2* SoundEffectEngine();
    void SuspendAudio();
    void ResumeAudio();

protected:
    // ...
};
```
### <a name="mediareaderh"></a><span data-ttu-id="16ce1-235">MediaReader.h</span><span class="sxs-lookup"><span data-stu-id="16ce1-235">MediaReader.h</span></span>

```cpp
// MediaReader:
// This is a helper class for the SoundEffect class.  It reads small audio files
// synchronously from the package installed folder and returns sound data as a
// byte array.

ref class MediaReader
{
internal:
    MediaReader();

    Platform::Array<byte>^          LoadMedia(_In_ Platform::String^ filename);
    WAVEFORMATEX*                   GetOutputWaveFormatEx();

protected private:
    Windows::Storage::StorageFolder^ m_installedLocation;
    Platform::String^               m_installedLocationPath;
    WAVEFORMATEX                    m_waveFormat;
};
```
### <a name="soundeffecth"></a><span data-ttu-id="16ce1-236">SoundEffect.h</span><span class="sxs-lookup"><span data-stu-id="16ce1-236">SoundEffect.h</span></span>

```cpp
// SoundEffect:
// This class plays a sound using XAudio2.  It uses a mastering voice provided
// from the Audio class.  The sound data can be read from disk using the MediaReader
// class.

ref class SoundEffect
{
internal:
    SoundEffect();

    void Initialize(
        _In_ IXAudio2*              masteringEngine,
        _In_ WAVEFORMATEX*          sourceFormat,
        _In_ Platform::Array<byte>^ soundData
        );

    void PlaySound(_In_ float volume);

protected private:
    //...

};
```


