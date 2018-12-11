---
title: サウンドの追加
description: XAudio2 Api を使用してゲームの音楽を再生し、効果音の簡単なサウンド エンジンを開発します。
ms.assetid: aa05efe2-2baa-8b9f-7418-23f5b6cd2266
ms.date: 10/24/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, サウンド
ms.localizationpriority: medium
ms.openlocfilehash: 94044e3d10df15cb1cb256d86ced798395e6af6f
ms.sourcegitcommit: 49d58bc66c1c9f2a4f81473bcb25af79e2b1088d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8923773"
---
# <a name="add-sound"></a><span data-ttu-id="41fef-104">サウンドの追加</span><span class="sxs-lookup"><span data-stu-id="41fef-104">Add sound</span></span>

<span data-ttu-id="41fef-105">このトピックでは、 [XAudio2](https://msdn.microsoft.com/library/windows/desktop/ee415813) Api を使って単純なサウンド エンジンを作成します。</span><span class="sxs-lookup"><span data-stu-id="41fef-105">In this topic, we create a simple sound engine using [XAudio2](https://msdn.microsoft.com/library/windows/desktop/ee415813) APIs.</span></span> <span data-ttu-id="41fef-106">__XAudio2__を新しい場合は、[オーディオの概念](#audio-concepts)の下の短い概要が追加されました。</span><span class="sxs-lookup"><span data-stu-id="41fef-106">If you are new to __XAudio2__, we have included a short intro under [Audio concepts](#audio-concepts).</span></span>

>[!Note]
><span data-ttu-id="41fef-107">このサンプルの最新ゲーム コードをダウンロードしていない場合は、[Direct3D ゲーム サンプルのページ](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Simple3DGameDX)に移動してください。</span><span class="sxs-lookup"><span data-stu-id="41fef-107">If you haven't downloaded the latest game code for this sample, go to [Direct3D game sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Simple3DGameDX).</span></span> <span data-ttu-id="41fef-108">このサンプルは、UWP 機能のサンプルの大規模なコレクションの一部です。</span><span class="sxs-lookup"><span data-stu-id="41fef-108">This sample is part of a large collection of UWP feature samples.</span></span> <span data-ttu-id="41fef-109">サンプルをダウンロードする手順については、「[GitHub から UWP のサンプルを取得する](https://docs.microsoft.com/windows/uwp/get-started/get-uwp-app-samples)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="41fef-109">For instructions on how to download the sample, see [Get the UWP samples from GitHub](https://docs.microsoft.com/windows/uwp/get-started/get-uwp-app-samples).</span></span>

## <a name="objective"></a><span data-ttu-id="41fef-110">目標</span><span class="sxs-lookup"><span data-stu-id="41fef-110">Objective</span></span>

<span data-ttu-id="41fef-111">[XAudio2](https://msdn.microsoft.com/library/windows/desktop/ee415813)を使って、サンプル ゲームにサウンドを追加します。</span><span class="sxs-lookup"><span data-stu-id="41fef-111">Add sounds into the sample game using [XAudio2](https://msdn.microsoft.com/library/windows/desktop/ee415813).</span></span>

## <a name="define-the-audio-engine"></a><span data-ttu-id="41fef-112">オーディオ エンジンを定義します。</span><span class="sxs-lookup"><span data-stu-id="41fef-112">Define the audio engine</span></span>

<span data-ttu-id="41fef-113">このゲーム サンプルでは、オーディオのオブジェクトと動作は次の 3 つのファイルに定義されています。</span><span class="sxs-lookup"><span data-stu-id="41fef-113">In the game sample, the audio objects and behaviors are defined in three files:</span></span>

* <span data-ttu-id="41fef-114">__[Audio.h](#audioh)/.cpp__: サウンド再生用の__XAudio2__リソースが含まれている__オーディオ__オブジェクトを定義します。</span><span class="sxs-lookup"><span data-stu-id="41fef-114">__[Audio.h](#audioh)/.cpp__: Defines the __Audio__ object, which contains the __XAudio2__ resources for sound playback.</span></span> <span data-ttu-id="41fef-115">また、ゲームが一時停止または非アクティブにされた場合にオーディオ再生を一時停止して再開するメソッドも定義します。</span><span class="sxs-lookup"><span data-stu-id="41fef-115">It also defines the method for suspending and resuming audio playback if the game is paused or deactivated.</span></span>
* <span data-ttu-id="41fef-116">__ [MediaReader.h](#mediareaderh)/.cpp__: ローカル ストレージからオーディオ .wav ファイルを読み取るメソッドを定義します。</span><span class="sxs-lookup"><span data-stu-id="41fef-116">__[MediaReader.h](#mediareaderh)/.cpp__: Defines the methods for reading audio .wav files from local storage.</span></span>
* <span data-ttu-id="41fef-117">__ [SoundEffect.h](#soundeffecth)/.cpp__: ゲーム内サウンド再生用のオブジェクトを定義します。</span><span class="sxs-lookup"><span data-stu-id="41fef-117">__[SoundEffect.h](#soundeffecth)/.cpp__: Defines an object for in-game sound playback.</span></span>

## <a name="overview"></a><span data-ttu-id="41fef-118">概要</span><span class="sxs-lookup"><span data-stu-id="41fef-118">Overview</span></span>

<span data-ttu-id="41fef-119">オーディオの再生をゲームに設定を取得するのには、次の 3 つの主要部分があります。</span><span class="sxs-lookup"><span data-stu-id="41fef-119">There are three main parts in getting set up for audio playback into your game.</span></span>

1. [<span data-ttu-id="41fef-120">作成し、オーディオ リソースの初期化</span><span class="sxs-lookup"><span data-stu-id="41fef-120">Create and initialize the audio resources</span></span>](#create-and-initialize-the-audio-resources)
2. [<span data-ttu-id="41fef-121">オーディオ ファイルの読み込み</span><span class="sxs-lookup"><span data-stu-id="41fef-121">Load audio file</span></span>](#load-audio-file)
3. [<span data-ttu-id="41fef-122">オブジェクトにサウンドを関連付ける</span><span class="sxs-lookup"><span data-stu-id="41fef-122">Associate sound to object</span></span>](#associate-sound-to-object)

<span data-ttu-id="41fef-123">すべてで定義されている[Simple3DGame::Initialize](#simple3dgameinitialize-method)メソッドです。</span><span class="sxs-lookup"><span data-stu-id="41fef-123">They are all defined in the [Simple3DGame::Initialize](#simple3dgameinitialize-method) method.</span></span> <span data-ttu-id="41fef-124">このメソッドと、について詳しく説明の各セクションで詳細を最初に見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="41fef-124">So let's first examine this method and then dive into more details in each of the sections.</span></span>

<span data-ttu-id="41fef-125">を設定した後は、再生するサウンド効果をトリガーする方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="41fef-125">After setting up, we learn how to trigger the sound effects to play.</span></span> <span data-ttu-id="41fef-126">詳しくは、[サウンドを再生](#play-the-sound)に移動します。</span><span class="sxs-lookup"><span data-stu-id="41fef-126">For more info, go to [Play the sound](#play-the-sound).</span></span>

### <a name="simple3dgameinitialize-method"></a><span data-ttu-id="41fef-127">Simple3DGame::Initialize メソッド</span><span class="sxs-lookup"><span data-stu-id="41fef-127">Simple3DGame::Initialize method</span></span>

<span data-ttu-id="41fef-128">__Simple3DGame::Initialize__、場所__m\_controller__と__m\_renderer__は初期化は、オーディオ エンジンを設定し、サウンドを再生する準備します。</span><span class="sxs-lookup"><span data-stu-id="41fef-128">In __Simple3DGame::Initialize__, where __m\_controller__ and __m\_renderer__ are also initialized, we set up the audio engine and get it ready to play sounds.</span></span>

 * <span data-ttu-id="41fef-129">[オーディオ](#audioh)クラスのインスタンスである__m\_audioController__を作成します。</span><span class="sxs-lookup"><span data-stu-id="41fef-129">Create __m\_audioController__, which is an instance of the [Audio](#audioh) class.</span></span>
 * <span data-ttu-id="41fef-130">[Audio::CreateDeviceIndependentResources](#audiocreatedeviceindependentresources-method)メソッドを使用するために必要なオーディオ リソースを作成します。</span><span class="sxs-lookup"><span data-stu-id="41fef-130">Create the audio resources needed using the [Audio::CreateDeviceIndependentResources](#audiocreatedeviceindependentresources-method) method.</span></span> <span data-ttu-id="41fef-131">ここでは、2 つの__XAudio2__オブジェクト&mdash;、音楽エンジン オブジェクトとサウンド エンジン オブジェクトでは、それぞれのマスタリング ボイスを作成します。</span><span class="sxs-lookup"><span data-stu-id="41fef-131">Here, two __XAudio2__ objects &mdash; a music engine object and a sound engine object, and a mastering voice for each of them were created.</span></span> <span data-ttu-id="41fef-132">ゲームのバック グラウンド音楽を再生する音楽エンジン オブジェクトを使用できます。</span><span class="sxs-lookup"><span data-stu-id="41fef-132">The music engine object can be used to play background music for your game.</span></span> <span data-ttu-id="41fef-133">ゲームでサウンド効果を再生するサウンドのエンジンを使用できます。</span><span class="sxs-lookup"><span data-stu-id="41fef-133">The sound engine can be used to play sound effects in your game.</span></span> <span data-ttu-id="41fef-134">詳しくは、次を参照してください。[を作成し、オーディオ リソースを初期化](#create-and-initialize-the-audio-resources)します。</span><span class="sxs-lookup"><span data-stu-id="41fef-134">For more info, see [Create and initialize the audio resources](#create-and-initialize-the-audio-resources).</span></span>
 * <span data-ttu-id="41fef-135">__MediaReader__は[MediaReader](#mediareaderh)クラスのインスタンスを作成します。</span><span class="sxs-lookup"><span data-stu-id="41fef-135">Create __mediaReader__, which is an instance of [MediaReader](#mediareaderh) class.</span></span> <span data-ttu-id="41fef-136">[MediaReader](#mediareaderh)、 [SoundEffect](#soundeffecth)クラスのヘルパー クラスでは、ファイルの場所から同期的に小さなオーディオ ファイルを読み取り、バイト配列としてサウンド データを返します。</span><span class="sxs-lookup"><span data-stu-id="41fef-136">[MediaReader](#mediareaderh), which is a helper class for the [SoundEffect](#soundeffecth) class, reads small audio files synchronously from file location and returns sound data as a byte array.</span></span>
 * <span data-ttu-id="41fef-137">[Mediareader:](#mediareaderloadmedia-method)を使用して、その場所からサウンド ファイルを読み込んで、読み込まれた .wav サウンド データを保持する__targetHitSound__変数を作成します。</span><span class="sxs-lookup"><span data-stu-id="41fef-137">Use [MediaReader::LoadMedia](#mediareaderloadmedia-method) to load sound files from its location and create a __targetHitSound__ variable to hold the loaded .wav sound data.</span></span> <span data-ttu-id="41fef-138">詳しくは、[オーディオ ファイルの読み込み](#load-audio)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="41fef-138">For more info, see [Load audio file](#load-audio).</span></span> 

<span data-ttu-id="41fef-139">サウンド効果は、ゲーム オブジェクトに関連付けられます。</span><span class="sxs-lookup"><span data-stu-id="41fef-139">Sound effects are associated with the game object.</span></span> <span data-ttu-id="41fef-140">したがって、衝突がそのゲーム オブジェクトで発生すると、再生するサウンドの効果がトリガーされます。</span><span class="sxs-lookup"><span data-stu-id="41fef-140">So when a collision occurs with that game object, it triggers the sound effect to be played.</span></span> <span data-ttu-id="41fef-141">このゲーム サンプルでは、サウンド効果 (どのようなします使用とターゲットを撮影する)、弾に使うと、ターゲットがあります。</span><span class="sxs-lookup"><span data-stu-id="41fef-141">In this game sample, we have sound effects for the ammo (what we use to shoot targets with) and for the target.</span></span> 
    
* <span data-ttu-id="41fef-142">__GameObject__クラス オブジェクトにサウンド効果を関連付けるために使用される__HitSound__プロパティがあります。</span><span class="sxs-lookup"><span data-stu-id="41fef-142">In the __GameObject__ class, there's a __HitSound__ property that is used to associate the sound effect to the object.</span></span>
* <span data-ttu-id="41fef-143">[SoundEffect](#soundeffecth)クラスの新しいインスタンスを作成し、初期化します。</span><span class="sxs-lookup"><span data-stu-id="41fef-143">Create a new instance of the [SoundEffect](#soundeffecth) class and initialize it.</span></span> <span data-ttu-id="41fef-144">初期化時に、サウンド効果のソース ボイスが作成されます。</span><span class="sxs-lookup"><span data-stu-id="41fef-144">During initialization, a source voice for the sound effect is created.</span></span> 
* <span data-ttu-id="41fef-145">このクラスは、[オーディオ](#audioh)クラスから提供されるマスタリング ボイスを使用してサウンドを再生します。</span><span class="sxs-lookup"><span data-stu-id="41fef-145">This class plays a sound using a mastering voice provided from the [Audio](#audioh) class.</span></span> <span data-ttu-id="41fef-146">サウンド データは、 [MediaReader](#mediareaderh)クラスを使ってファイルの場所から読み込まれます。</span><span class="sxs-lookup"><span data-stu-id="41fef-146">Sound data is read from file location using the [MediaReader](#mediareaderh) class.</span></span> <span data-ttu-id="41fef-147">詳しくは、[サウンドのオブジェクトを関連付ける](#associate-sound-to-object)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="41fef-147">For more info, see [Associate sound to object](#associate-sound-to-object).</span></span>

>[!Note]
><span data-ttu-id="41fef-148">サウンドを再生する実際のトリガーは、移動とこれらのゲーム オブジェクトの衝突によって決定されます。</span><span class="sxs-lookup"><span data-stu-id="41fef-148">The actual trigger to play the sound is determined by the movement and collision of these game objects.</span></span> <span data-ttu-id="41fef-149">したがって、実際にこれらのサウンドを再生する呼び出しは、 [Simple3DGame::UpdateDynamics](#simple3dgameupdatedynamics-method)メソッドで定義されます。</span><span class="sxs-lookup"><span data-stu-id="41fef-149">Hence, the call to actually play these sounds are defined in the [Simple3DGame::UpdateDynamics](#simple3dgameupdatedynamics-method) method.</span></span> <span data-ttu-id="41fef-150">詳しくは、[サウンドを再生](#play-the-sound)に移動します。</span><span class="sxs-lookup"><span data-stu-id="41fef-150">For more info, go to [Play the sound](#play-the-sound).</span></span>

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

## <a name="create-and-initialize-the-audio-resources"></a><span data-ttu-id="41fef-151">作成し、オーディオ リソースの初期化</span><span class="sxs-lookup"><span data-stu-id="41fef-151">Create and initialize the audio resources</span></span>

* <span data-ttu-id="41fef-152">ミュージックとサウンド効果のエンジンを定義する 2 つの新しい XAudio2 オブジェクトを作成するのにには、 [XAudio2Create](https://msdn.microsoft.com/library/windows/desktop/ee419212)、XAudio2 API を使用します。</span><span class="sxs-lookup"><span data-stu-id="41fef-152">Use [XAudio2Create](https://msdn.microsoft.com/library/windows/desktop/ee419212), an XAudio2 API, to create two new XAudio2 objects which define the music and sound effect engines.</span></span> <span data-ttu-id="41fef-153">このメソッドは、スレッドの処理、音声グラフでは、オーディオのすべてのオーディオ エンジンの状態を管理するオブジェクトの[IXAudio2](https://msdn.microsoft.com/library/windows/desktop/ee415908)インターフェイスへのポインターを返します。</span><span class="sxs-lookup"><span data-stu-id="41fef-153">This method returns a pointer to the object's [IXAudio2](https://msdn.microsoft.com/library/windows/desktop/ee415908) interface that manages all audio engine states, the audio processing thread, the voice graph, and more.</span></span>
* <span data-ttu-id="41fef-154">後、エンジンがインスタンス化されると、 [ixaudio 2::createmasteringvoice](https://msdn.microsoft.com/library/windows/desktop/hh405048)を使用してサウンド エンジン オブジェクトのそれぞれのマスタリング ボイスを作成します。</span><span class="sxs-lookup"><span data-stu-id="41fef-154">After the engines have been instantiated, use [IXAudio2::CreateMasteringVoice](https://msdn.microsoft.com/library/windows/desktop/hh405048) to create a mastering voice for each of the sound engine objects.</span></span>

<span data-ttu-id="41fef-155">詳しくに移動します。[方法: XAudio2 の初期化](https://msdn.microsoft.com/library/windows/desktop/ee415779.aspx)します。</span><span class="sxs-lookup"><span data-stu-id="41fef-155">For more info, go to [How to: Initialize XAudio2](https://msdn.microsoft.com/library/windows/desktop/ee415779.aspx).</span></span>

### <a name="audiocreatedeviceindependentresources-method"></a><span data-ttu-id="41fef-156">Audio::CreateDeviceIndependentResources メソッド</span><span class="sxs-lookup"><span data-stu-id="41fef-156">Audio::CreateDeviceIndependentResources method</span></span>

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

## <a name="load-audio-file"></a><span data-ttu-id="41fef-157">オーディオ ファイルの読み込み</span><span class="sxs-lookup"><span data-stu-id="41fef-157">Load audio file</span></span>

<span data-ttu-id="41fef-158">ゲームのサンプルでは、オーディオ形式のファイルを読み取るコードは[MediaReader.h](#mediareaderh)/cpp__ で定義されます。</span><span class="sxs-lookup"><span data-stu-id="41fef-158">In the game sample, the code for reading audio format files is defined in [MediaReader.h](#mediareaderh)/cpp__.</span></span>  <span data-ttu-id="41fef-159">エンコードされた .wav オーディオ ファイルを読み取り、 [mediareader:](#mediareaderloadmedia-method)、入力パラメーターとして .wav のファイル名を渡して呼び出します。</span><span class="sxs-lookup"><span data-stu-id="41fef-159">To read an encoded .wav audio file, call [MediaReader::LoadMedia](#mediareaderloadmedia-method), passing in the filename of the .wav as the input parameter.</span></span>

### <a name="mediareaderloadmedia-method"></a><span data-ttu-id="41fef-160">Mediareader: メソッド</span><span class="sxs-lookup"><span data-stu-id="41fef-160">MediaReader::LoadMedia method</span></span>

<span data-ttu-id="41fef-161">このメソッドは、[メディア ファンデーション](https://msdn.microsoft.com/library/windows/desktop/ms694197) API を使って、.wav オーディオ ファイルをパルス符号変調 (PCM) バッファーとして読み取ります。</span><span class="sxs-lookup"><span data-stu-id="41fef-161">This method uses the [Media Foundation](https://msdn.microsoft.com/library/windows/desktop/ms694197) APIs to read in the .wav audio file as a Pulse Code Modulation (PCM) buffer.</span></span>

#### <a name="set-up-the-source-reader"></a><span data-ttu-id="41fef-162">ソース リーダーをセットアップします。</span><span class="sxs-lookup"><span data-stu-id="41fef-162">Set up the Source Reader</span></span>

1. <span data-ttu-id="41fef-163">[MFCreateSourceReaderFromURL](https://msdn.microsoft.com/library/windows/desktop/dd388110)を使用して、メディア ソース リーダー ([IMFSourceReader](https://msdn.microsoft.com/library/windows/desktop/dd374655)) を作成します。</span><span class="sxs-lookup"><span data-stu-id="41fef-163">Use [MFCreateSourceReaderFromURL](https://msdn.microsoft.com/library/windows/desktop/dd388110) to create a media source reader ([IMFSourceReader](https://msdn.microsoft.com/library/windows/desktop/dd374655)).</span></span>
2. <span data-ttu-id="41fef-164">[MFCreateMediaType](https://msdn.microsoft.com/library/windows/desktop/ms693861)を使用して、メディアの種類 ([IMFMediaType](https://msdn.microsoft.com/library/windows/desktop/ms704850)) オブジェクト (_メディアの種類_) を作成します。</span><span class="sxs-lookup"><span data-stu-id="41fef-164">Use [MFCreateMediaType](https://msdn.microsoft.com/library/windows/desktop/ms693861) to create a media type ([IMFMediaType](https://msdn.microsoft.com/library/windows/desktop/ms704850)) object (_mediaType_).</span></span> <span data-ttu-id="41fef-165">メディア形式の説明を表します。</span><span class="sxs-lookup"><span data-stu-id="41fef-165">It represents a description of a media format.</span></span> 
3. <span data-ttu-id="41fef-166">_メディアの種類_のデコードされた出力が、これは、 __XAudio2__を使用するオーディオの種類として PCM オーディオを指定します。</span><span class="sxs-lookup"><span data-stu-id="41fef-166">Specify that the _mediaType_'s decoded output is PCM audio, which is an audio type that __XAudio2__ can use.</span></span>
4. <span data-ttu-id="41fef-167">セットで呼び出し元[imfsourcereader::setcurrentmediatype](https://msdn.microsoft.com/library/windows/desktop/dd374667.aspx)ソース リーダーのデコードされた出力のメディアを入力します。</span><span class="sxs-lookup"><span data-stu-id="41fef-167">Sets the decoded output media type for the source reader by calling [IMFSourceReader::SetCurrentMediaType](https://msdn.microsoft.com/library/windows/desktop/dd374667.aspx).</span></span>

<span data-ttu-id="41fef-168">ソース リーダーを使用する理由について詳しくは、[ソース リーダー](https://msdn.microsoft.com/library/windows/desktop/dd940436.aspx)に移動します。</span><span class="sxs-lookup"><span data-stu-id="41fef-168">For more info on why we use the Source Reader, go to [Source Reader](https://msdn.microsoft.com/library/windows/desktop/dd940436.aspx).</span></span>

#### <a name="describe-the-data-format-of-the-audio-stream"></a><span data-ttu-id="41fef-169">オーディオ ストリームのデータ形式を記述します。</span><span class="sxs-lookup"><span data-stu-id="41fef-169">Describe the data format of the audio stream</span></span>

1. <span data-ttu-id="41fef-170">[Imfsourcereader::getcurrentmediatype](https://msdn.microsoft.com/library/windows/desktop/dd374660)を使用して、ストリームの現在のメディアの種類を取得します。</span><span class="sxs-lookup"><span data-stu-id="41fef-170">Use [IMFSourceReader::GetCurrentMediaType](https://msdn.microsoft.com/library/windows/desktop/dd374660) to get the current media type for the stream.</span></span>
2. <span data-ttu-id="41fef-171">[IMFMediaType::MFCreateWaveFormatExFromMFMediaType](https://msdn.microsoft.com/library/windows/desktop/ms702177)を使用して、以前の操作の結果を入力として使用して、 [WAVEFORMATEX](https://msdn.microsoft.com/library/windows/hardware/ff538799)バッファーに、現在のオーディオ メディア タイプを変換します。</span><span class="sxs-lookup"><span data-stu-id="41fef-171">Use [IMFMediaType::MFCreateWaveFormatExFromMFMediaType](https://msdn.microsoft.com/library/windows/desktop/ms702177) to convert the current audio media type to a [WAVEFORMATEX](https://msdn.microsoft.com/library/windows/hardware/ff538799) buffer, using the results of the earlier operation as input.</span></span> <span data-ttu-id="41fef-172">この構造体には、オーディオが読み込まれた後に使用する基準オーディオ ストリームのデータ形式を指定します。</span><span class="sxs-lookup"><span data-stu-id="41fef-172">This structure specifies the data format of the wave audio stream that is used after audio is loaded.</span></span> 

<span data-ttu-id="41fef-173">PCM バッファーを記述する__WAVEFORMATEX__形式を使用できます。</span><span class="sxs-lookup"><span data-stu-id="41fef-173">The __WAVEFORMATEX__ format can be used to describe the PCM buffer.</span></span> <span data-ttu-id="41fef-174">[WAVEFORMATEXTENSIBLE](https://msdn.microsoft.com/library/windows/hardware/ff538802)構造体と比較したにのみ使用できますを基準のオーディオ形式のサブセットを記述します。</span><span class="sxs-lookup"><span data-stu-id="41fef-174">As compared to the [WAVEFORMATEXTENSIBLE](https://msdn.microsoft.com/library/windows/hardware/ff538802) structure, it can only be used to describe a subset of audio wave formats.</span></span> <span data-ttu-id="41fef-175">__WAVEFORMATEX__と__WAVEFORMATEXTENSIBLE__の違いについて詳しくは、 [Extensible 基準形式記述子](https://docs.microsoft.com/windows-hardware/drivers/audio/extensible-wave-format-descriptors)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="41fef-175">For more info about the differences between __WAVEFORMATEX__ and __WAVEFORMATEXTENSIBLE__, see [Extensible Wave-Format Descriptors](https://docs.microsoft.com/windows-hardware/drivers/audio/extensible-wave-format-descriptors).</span></span>

#### <a name="read-the-audio-stream"></a><span data-ttu-id="41fef-176">オーディオ ストリームを読み取り</span><span class="sxs-lookup"><span data-stu-id="41fef-176">Read the audio stream</span></span>

1.  <span data-ttu-id="41fef-177">[:Getpresentationattribute](https://msdn.microsoft.com/library/windows/desktop/dd374662)し、変換のバイトに継続時間を呼び出すことによって、オーディオ ストリームの秒単位で、継続時間を取得します。</span><span class="sxs-lookup"><span data-stu-id="41fef-177">Get the duration, in seconds, of the audio stream by calling [IMFSourceReader::GetPresentationAttribute](https://msdn.microsoft.com/library/windows/desktop/dd374662) and then converts the duration to bytes.</span></span>
2.  <span data-ttu-id="41fef-178">オーディオ ファイルをストリームとして[imfsourcereader::readsample](https://msdn.microsoft.com/library/windows/desktop/dd374665)を呼び出すことによって読み取られます。</span><span class="sxs-lookup"><span data-stu-id="41fef-178">Read the audio file in as a stream by calling [IMFSourceReader::ReadSample](https://msdn.microsoft.com/library/windows/desktop/dd374665).</span></span> <span data-ttu-id="41fef-179">__ReadSample__は、メディア ソースから、次のサンプルを読み取ります。</span><span class="sxs-lookup"><span data-stu-id="41fef-179">__ReadSample__ reads the next sample from the media source.</span></span>
3.  <span data-ttu-id="41fef-180">[IMFSample::ConvertToContiguousBuffer](https://msdn.microsoft.com/library/windows/desktop/ms698917.aspx)を使用して、配列 (_mediaBuffer_) に (_サンプル_) オーディオ サンプル バッファーの内容をコピーします。</span><span class="sxs-lookup"><span data-stu-id="41fef-180">Use [IMFSample::ConvertToContiguousBuffer](https://msdn.microsoft.com/library/windows/desktop/ms698917.aspx) to copy contents of the audio sample buffer (_sample_) into an array (_mediaBuffer_).</span></span>

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
## <a name="associate-sound-to-object"></a><span data-ttu-id="41fef-181">オブジェクトにサウンドを関連付ける</span><span class="sxs-lookup"><span data-stu-id="41fef-181">Associate sound to object</span></span>

<span data-ttu-id="41fef-182">オブジェクトにサウンドを関連付けることが行わ[Simple3DGame::Initialize](#simple3dgameinitialize-method)メソッドで、ゲームの初期化します。</span><span class="sxs-lookup"><span data-stu-id="41fef-182">Associating sounds to the object takes place when the game initializes, in the [Simple3DGame::Initialize](#simple3dgameinitialize-method) method.</span></span>

<span data-ttu-id="41fef-183">要約:</span><span class="sxs-lookup"><span data-stu-id="41fef-183">Recap:</span></span>
* <span data-ttu-id="41fef-184">__GameObject__クラス オブジェクトにサウンド効果を関連付けるために使用される__HitSound__プロパティがあります。</span><span class="sxs-lookup"><span data-stu-id="41fef-184">In the __GameObject__ class, there's a __HitSound__ property that is used to associate the sound effect to the object.</span></span>
* <span data-ttu-id="41fef-185">[SoundEffect](#soundeffecth)クラスのオブジェクトの新しいインスタンスを作成し、ゲーム オブジェクトに関連付けます。</span><span class="sxs-lookup"><span data-stu-id="41fef-185">Create a new instance of the [SoundEffect](#soundeffecth) class object and associate it with the game object.</span></span> <span data-ttu-id="41fef-186">このクラスは、 __XAudio2__ Api を使用してサウンドを再生します。</span><span class="sxs-lookup"><span data-stu-id="41fef-186">This class plays a sound using __XAudio2__ APIs.</span></span>  <span data-ttu-id="41fef-187">[オーディオ](#audioh)クラスによって提供されるマスタリング ボイスを使用します。</span><span class="sxs-lookup"><span data-stu-id="41fef-187">It uses a mastering voice provided by the [Audio](#audioh) class.</span></span> <span data-ttu-id="41fef-188">サウンド データは、 [MediaReader](#mediareaderh)クラスを使ってファイルの場所から読み取ることができます。</span><span class="sxs-lookup"><span data-stu-id="41fef-188">The sound data can be read from file location using the [MediaReader](#mediareaderh) class.</span></span>

<span data-ttu-id="41fef-189">__SoundEffect__は次の入力パラメーターのインスタンスを初期化するために使用する[SoundEffect::Initialize](#soundeffectinitialize-method) : サウンド エンジン オブジェクト (IXAudio2 オブジェクト[Audio::CreateDeviceIndependentResources](#audiocreatedeviceindependentresources-method)メソッドで作成) へのポインター形式へのポインター、.wav の__mediareader::getoutputwaveformatex__、サウンド データを使用してファイルを使って読み込まれる[mediareader:](#mediareaderloadmedia-method)メソッドです。</span><span class="sxs-lookup"><span data-stu-id="41fef-189">[SoundEffect::Initialize](#soundeffectinitialize-method) is used to initalize the __SoundEffect__ instance with the following input parameters: pointer to sound engine object (IXAudio2 objects created in the [Audio::CreateDeviceIndependentResources](#audiocreatedeviceindependentresources-method) method), pointer to format of the .wav file using __MediaReader::GetOutputWaveFormatEx__, and the sound data loaded using [MediaReader::LoadMedia](#mediareaderloadmedia-method) method.</span></span> <span data-ttu-id="41fef-190">初期化時にサウンド効果のソース ボイスが作成されます。</span><span class="sxs-lookup"><span data-stu-id="41fef-190">During initialization, the source voice for the sound effect is also created.</span></span>

### <a name="soundeffectinitialize-method"></a><span data-ttu-id="41fef-191">SoundEffect::Initialize メソッド</span><span class="sxs-lookup"><span data-stu-id="41fef-191">SoundEffect::Initialize method</span></span>

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

## <a name="play-the-sound"></a><span data-ttu-id="41fef-192">サウンドを再生します。</span><span class="sxs-lookup"><span data-stu-id="41fef-192">Play the sound</span></span>

<span data-ttu-id="41fef-193">効果音を再生するトリガーは、これでは、オブジェクトの動きを更新し、オブジェクトの間の衝突を決定するために、 [Simple3DGame::UpdateDynamics](#simple3dgameupdatedynamics-method)メソッドで定義されます。</span><span class="sxs-lookup"><span data-stu-id="41fef-193">Triggers to play sound effects are defined in [Simple3DGame::UpdateDynamics](#simple3dgameupdatedynamics-method) method because this is where movement of the objects are updated and collision between objects is determined.</span></span>

<span data-ttu-id="41fef-194">によっては、ゲーム オブジェクト間の対話式操作が大幅と異なるために、次に、ゲーム オブジェクトの dynamics などについて協議しますはしません。</span><span class="sxs-lookup"><span data-stu-id="41fef-194">Since interaction of between objects differs greatly, depending on the game, we are not going to discuss the dynamics of the game objects here.</span></span> <span data-ttu-id="41fef-195">その実装を理解する興味があるなら、 [Simple3DGame::UpdateDynamics](#simple3dgameupdatedynamics-method)メソッドに移動します。</span><span class="sxs-lookup"><span data-stu-id="41fef-195">If you're interested to understand its implementation, go to [Simple3DGame::UpdateDynamics](#simple3dgameupdatedynamics-method) method.</span></span>

<span data-ttu-id="41fef-196">基本的に、競合が発生すると、トリガーを [SoundEffect::PlaySound]((soundeffectplaysound-method) を呼び出すことによって再生するサウンド効果。</span><span class="sxs-lookup"><span data-stu-id="41fef-196">In principle, when a collision occurs, it triggers the sound effect to play by calling [SoundEffect::PlaySound]((soundeffectplaysound-method).</span></span> <span data-ttu-id="41fef-197">このメソッドは、現在再生されていると、目的のサウンド データをメモリ内のバッファーのキューにサウンド効果を停止します。</span><span class="sxs-lookup"><span data-stu-id="41fef-197">This method stops any sound effects that's currently playing and queues the in-memory buffer with the desired sound data.</span></span> <span data-ttu-id="41fef-198">ソース ボイスを使用してボリュームの設定、サウンドのデータを送信し、再生を開始します。</span><span class="sxs-lookup"><span data-stu-id="41fef-198">It uses source voice to set the volume, submit sound data, and start the playback.</span></span>

### <a name="soundeffectplaysound-method"></a><span data-ttu-id="41fef-199">Soundeffect::playsound メソッド</span><span class="sxs-lookup"><span data-stu-id="41fef-199">SoundEffect::PlaySound method</span></span>

* <span data-ttu-id="41fef-200">ソース ボイス オブジェクト**m \_sourcevoice**を使用して、サウンド データ バッファー **m \_sounddata**の再生を開始するには</span><span class="sxs-lookup"><span data-stu-id="41fef-200">Uses the source voice object **m\_sourceVoice** to start the playback of the sound data buffer **m\_soundData**</span></span>
* <span data-ttu-id="41fef-201">[XAUDIO2\_BUFFER](https://msdn.microsoft.com/library/windows/desktop/ee419228)、サウンド データ バッファーへの参照を提供し、 [ixaudio2sourcevoice::submitsourcebuffer](https://msdn.microsoft.com/library/windows/desktop/ee418473)への呼び出しに送信し、先を作成します。</span><span class="sxs-lookup"><span data-stu-id="41fef-201">Creates an [XAUDIO2\_BUFFER](https://msdn.microsoft.com/library/windows/desktop/ee419228), to which it provides a reference to the sound data buffer, and then submits it with a call to [IXAudio2SourceVoice::SubmitSourceBuffer](https://msdn.microsoft.com/library/windows/desktop/ee418473).</span></span> 
* <span data-ttu-id="41fef-202">サウンド データがキューに入ると、**SoundEffect::PlaySound** は、[IXAudio2SourceVoice::Start](https://msdn.microsoft.com/library/windows/desktop/ee418471) を呼び出して再生を開始します。</span><span class="sxs-lookup"><span data-stu-id="41fef-202">With the sound data queued up, **SoundEffect::PlaySound** starts play back by calling [IXAudio2SourceVoice::Start](https://msdn.microsoft.com/library/windows/desktop/ee418471).</span></span>

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

### <a name="simple3dgameupdatedynamics-method"></a><span data-ttu-id="41fef-203">Simple3DGame::UpdateDynamics メソッド</span><span class="sxs-lookup"><span data-stu-id="41fef-203">Simple3DGame::UpdateDynamics method</span></span>

<span data-ttu-id="41fef-204">__Simple3DGame::UpdateDynamics__メソッドは、対話式操作と衝突ゲーム オブジェクトの間に行われます。</span><span class="sxs-lookup"><span data-stu-id="41fef-204">The __Simple3DGame::UpdateDynamics__ method takes care the interaction and collision between game objects.</span></span> <span data-ttu-id="41fef-205">オブジェクトが衝突する (または交差する) 場合は、再生に関連付けられているサウンド効果がトリガーされます。</span><span class="sxs-lookup"><span data-stu-id="41fef-205">When objects collide (or intersect), it triggers the associated sound effect to play.</span></span>

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
## <a name="next-steps"></a><span data-ttu-id="41fef-206">次のステップ</span><span class="sxs-lookup"><span data-stu-id="41fef-206">Next steps</span></span>

<span data-ttu-id="41fef-207">UWP のフレームワーク、グラフィックス、コントロール、ユーザー インターフェイス、および Windows 10 ゲームのオーディオを説明します。</span><span class="sxs-lookup"><span data-stu-id="41fef-207">We have covered the UWP framework, graphics, controls, user interface, and audio of a Windows 10 game.</span></span> <span data-ttu-id="41fef-208">[ゲーム サンプルの紹介](tutorial-resources.md)を、このチュートリアルの次の部分では、ゲームを開発するときに使用できるその他のオプションについて説明します。</span><span class="sxs-lookup"><span data-stu-id="41fef-208">The next part of this tutorial, [Extending the game sample](tutorial-resources.md), explains other options that can be used when developing a game.</span></span>

## <a name="audio-concepts"></a><span data-ttu-id="41fef-209">オーディオの概念</span><span class="sxs-lookup"><span data-stu-id="41fef-209">Audio concepts</span></span>

<span data-ttu-id="41fef-210">Windows 10 のゲーム開発のためには、XAudio2 バージョン 2.9 を使用します。</span><span class="sxs-lookup"><span data-stu-id="41fef-210">For Windows 10 games development, use XAudio2 version 2.9.</span></span> <span data-ttu-id="41fef-211">このバージョンには、Windows 10 が付属しています。</span><span class="sxs-lookup"><span data-stu-id="41fef-211">This version is shipped with Windows 10.</span></span> <span data-ttu-id="41fef-212">詳しくは、 [XAudio2 のバージョン](https://msdn.microsoft.com/library/windows/desktop/ee415802.aspx)に移動します。</span><span class="sxs-lookup"><span data-stu-id="41fef-212">For more info, go to [XAudio2 Versions](https://msdn.microsoft.com/library/windows/desktop/ee415802.aspx).</span></span>

<span data-ttu-id="41fef-213">__AudioX2__では、信号処理とミキシングの基盤を提供する下位レベルの API です。</span><span class="sxs-lookup"><span data-stu-id="41fef-213">__AudioX2__ is a low-level API that provides signal processing and mixing foundation.</span></span> <span data-ttu-id="41fef-214">詳しくは、 [XAudio2 の主要な概念](https://msdn.microsoft.com/library/windows/desktop/ee415764.aspx)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="41fef-214">For more info, see [XAudio2 Key Concepts](https://msdn.microsoft.com/library/windows/desktop/ee415764.aspx).</span></span>

### <a name="xaudio2-voices"></a><span data-ttu-id="41fef-215">XAudio2 のボイス</span><span class="sxs-lookup"><span data-stu-id="41fef-215">XAudio2 voices</span></span>

<span data-ttu-id="41fef-216">XAudio2 のボイス オブジェクトの 3 種類が: ソース、サブミックス ボイス、およびマスター リング ボイスします。</span><span class="sxs-lookup"><span data-stu-id="41fef-216">There are three types of XAudio2 voice objects: source, submix, and mastering voices.</span></span> <span data-ttu-id="41fef-217">ボイスは、オブジェクトの XAudio2 を使って処理、操作、およびオーディオ データを再生します。</span><span class="sxs-lookup"><span data-stu-id="41fef-217">Voices are the objects XAudio2 use to process, to manipulate, and to play audio data.</span></span> 
* <span data-ttu-id="41fef-218">ソース ボイスは、クライアントから提供されたオーディオ データに適用されます。</span><span class="sxs-lookup"><span data-stu-id="41fef-218">Source voices operate on audio data provided by the client.</span></span> 
* <span data-ttu-id="41fef-219">ソース ボイスとサブミックス ボイスは、1 つ以上のサブミックス ボイスまたはマスタリング ボイスに向けて出力を送信します。</span><span class="sxs-lookup"><span data-stu-id="41fef-219">Source and submix voices send their output to one or more submix or mastering voices.</span></span> 
* <span data-ttu-id="41fef-220">サブミックス ボイスとマスタリング ボイスは、それぞれに送られるすべてのボイスからオーディオをミキシングし、その結果に対して作用します。</span><span class="sxs-lookup"><span data-stu-id="41fef-220">Submix and mastering voices mix the audio from all voices feeding them, and operate on the result.</span></span> 
* <span data-ttu-id="41fef-221">マスタリング ボイスは、ソース ボイスとサブミックス ボイスからデータを受信し、オーディオ ハードウェアにそのデータを送信します。</span><span class="sxs-lookup"><span data-stu-id="41fef-221">Mastering voices receive data from source voices and submix voices, and sends that data to the audio hardware.</span></span>

<span data-ttu-id="41fef-222">詳しくは、 [XAudio2 のボイス](https://msdn.microsoft.com/library/windows/desktop/ee415824.aspx)に移動します。</span><span class="sxs-lookup"><span data-stu-id="41fef-222">For more info, go to [XAudio2 voices](https://msdn.microsoft.com/library/windows/desktop/ee415824.aspx).</span></span>

### <a name="audio-graph"></a><span data-ttu-id="41fef-223">オーディオ グラフ</span><span class="sxs-lookup"><span data-stu-id="41fef-223">Audio graph</span></span>

<span data-ttu-id="41fef-224">オーディオ グラフは、 [XAudio2 のボイス](#xaudio2-voice-objects)のコレクションです。</span><span class="sxs-lookup"><span data-stu-id="41fef-224">Audio graph is a collection of [XAudio2 voices](#xaudio2-voice-objects).</span></span> <span data-ttu-id="41fef-225">オーディオは、ソース ボイスのオーディオ グラフの一方の側から開始するには、必要に応じて、1 つ以上のサブミックス ボイスを通過およびマスター リング ボイスに終了します。</span><span class="sxs-lookup"><span data-stu-id="41fef-225">Audio starts at one side of an audio graph in source voices, optionally passes through one or more submix voices, and ends at a mastering voice.</span></span> <span data-ttu-id="41fef-226">オーディオ グラフは、現在再生中、0 個以上のサブミックス ボイス、各サウンドのソース ボイスとマスタリング ボイスを 1 つに含まれます。</span><span class="sxs-lookup"><span data-stu-id="41fef-226">An audio graph will contain a source voice for each sound currently playing, zero or more submix voices, and one mastering voice.</span></span> <span data-ttu-id="41fef-227">最も簡単なのオーディオ グラフと XAudio2 での音の作成に必要な最小値は、マスター リング ボイスに直接出力する単一のソース ボイスです。</span><span class="sxs-lookup"><span data-stu-id="41fef-227">The simplest audio graph, and the minimum needed to make a noise in XAudio2, is a single source voice outputting directly to a mastering voice.</span></span> <span data-ttu-id="41fef-228">詳しくは、[オーディオ グラフ](https://msdn.microsoft.com/library/windows/desktop/ee415739.aspx)に移動します。</span><span class="sxs-lookup"><span data-stu-id="41fef-228">For more info, go to [Audio graphs](https://msdn.microsoft.com/library/windows/desktop/ee415739.aspx).</span></span>

### <a name="additional-reading"></a><span data-ttu-id="41fef-229">追加の読み取り</span><span class="sxs-lookup"><span data-stu-id="41fef-229">Additional reading</span></span>

* [<span data-ttu-id="41fef-230">方法: XAudio2 の初期化</span><span class="sxs-lookup"><span data-stu-id="41fef-230">How to: Initialize XAudio2</span></span>](https://msdn.microsoft.com/library/windows/desktop/ee415779.aspx)
* [<span data-ttu-id="41fef-231">方法: XAudio2 でのオーディオ データ ファイルの読み込み</span><span class="sxs-lookup"><span data-stu-id="41fef-231">How to: Load Audio Data Files in XAudio2</span></span>](https://msdn.microsoft.com/library/windows/desktop/ee415781(v=vs.85).aspx)
* [<span data-ttu-id="41fef-232">方法: XAudio2 でのサウンド再生</span><span class="sxs-lookup"><span data-stu-id="41fef-232">How to: Play a Sound with XAudio2</span></span>](https://msdn.microsoft.com/library/windows/desktop/ee415787.aspx)

## <a name="key-audio-h-files"></a><span data-ttu-id="41fef-233">キーのオーディオ .h ファイル</span><span class="sxs-lookup"><span data-stu-id="41fef-233">Key audio .h files</span></span>

### <a name="audioh"></a><span data-ttu-id="41fef-234">Audio.h</span><span class="sxs-lookup"><span data-stu-id="41fef-234">Audio.h</span></span>

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
### <a name="mediareaderh"></a><span data-ttu-id="41fef-235">MediaReader.h</span><span class="sxs-lookup"><span data-stu-id="41fef-235">MediaReader.h</span></span>

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
### <a name="soundeffecth"></a><span data-ttu-id="41fef-236">SoundEffect.h</span><span class="sxs-lookup"><span data-stu-id="41fef-236">SoundEffect.h</span></span>

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


