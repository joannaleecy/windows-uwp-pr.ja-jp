---
author: joannaleecy
title: サウンドの追加
description: XAudio2 Api を使用してゲームの音楽を再生し、効果音の簡単なサウンド エンジンを開発します。
ms.assetid: aa05efe2-2baa-8b9f-7418-23f5b6cd2266
ms.author: joanlee
ms.date: 10/24/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, サウンド
ms.localizationpriority: medium
ms.openlocfilehash: 3d1c95fe883cf2517855a3b6f1c4dfc6c9b6dd9a
ms.sourcegitcommit: 3257416aebb5a7b1515e107866806f8bd57845a8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/17/2018
ms.locfileid: "7151247"
---
# <a name="add-sound"></a>サウンドの追加

このトピックでは、 [XAudio2](https://msdn.microsoft.com/library/windows/desktop/ee415813) Api を使用してシンプルなサウンド エンジンを作成します。 __XAudio2__を新しい場合は、[オーディオの概念](#audio-concepts)の下の短い概要が追加されました。

>[!Note]
>このサンプルの最新ゲーム コードをダウンロードしていない場合は、[Direct3D ゲーム サンプルのページ](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Simple3DGameDX)に移動してください。 このサンプルは、UWP 機能のサンプルの大規模なコレクションの一部です。 サンプルをダウンロードする手順については、「[GitHub から UWP のサンプルを取得する](https://docs.microsoft.com/windows/uwp/get-started/get-uwp-app-samples)」をご覧ください。

## <a name="objective"></a>目標

[XAudio2](https://msdn.microsoft.com/library/windows/desktop/ee415813)を使って、サンプル ゲームにサウンドを追加します。

## <a name="define-the-audio-engine"></a>オーディオ エンジンを定義します。

このゲーム サンプルでは、オーディオのオブジェクトと動作は次の 3 つのファイルに定義されています。

* __[Audio.h](#audioh)/.cpp__: サウンド再生用の__XAudio2__リソースが含まれている__オーディオ__オブジェクトを定義します。 また、ゲームが一時停止または非アクティブにされた場合にオーディオ再生を一時停止して再開するメソッドも定義します。
* __ [MediaReader.h](#mediareaderh)/.cpp__: オーディオ .wav ファイルをローカル ストレージから読み取るためのメソッドを定義します。
* __ [SoundEffect.h](#soundeffecth)/.cpp__: ゲーム内サウンド再生用のオブジェクトを定義します。

## <a name="overview"></a>概要

ゲームにオーディオ再生の設定を取得するのには、次の 3 つの主要部分があります。

1. [作成し、オーディオ リソースの初期化](#create-and-initialize-the-audio-resources)
2. [オーディオ ファイルの読み込み](#load-audio-file)
3. [オブジェクトにサウンドを関連付ける](#associate-sound-to-object)

すべてで定義されている[Simple3DGame::Initialize](#simple3dgameinitialize-method)メソッドです。 このメソッドと、について詳しく説明の各セクションで詳細を最初に見てみましょう。

を設定した後は、再生するサウンド エフェクトをトリガーする方法について説明します。 詳しくは、[サウンドを再生](#play-the-sound)に移動します。

### <a name="simple3dgameinitialize-method"></a>Simple3DGame::Initialize メソッド

__Simple3DGame::Initialize__、場所__m\_controller__と__m\_renderer__は初期化は、オーディオ エンジンをセットアップし、サウンドを再生する準備を取得します。

 * [オーディオ](#audioh)クラスのインスタンスである__m\_audioController__を作成します。
 * [Audio::CreateDeviceIndependentResources](#audiocreatedeviceindependentresources-method)メソッドを使用するために必要なオーディオ リソースを作成します。 ここでは、2 つの__XAudio2__オブジェクト&mdash;音楽エンジン オブジェクトとサウンド エンジン オブジェクトでは、それぞれのマスタリング ボイスを作成します。 ゲームのバック グラウンド音楽を再生する音楽エンジン オブジェクトを使用できます。 ゲームでサウンド効果を再生するサウンドのエンジンを使用できます。 詳しくは、次を参照してください。[を作成し、オーディオ リソースを初期化](#create-and-initialize-the-audio-resources)します。
 * [MediaReader](#mediareaderh)クラスのインスタンスである__mediaReader__を作成します。 [MediaReader](#mediareaderh)、ある[SoundEffect](#soundeffecth)クラスのヘルパー クラスでは、ファイルの場所から小さなオーディオ ファイルを同期的に読み取りし、バイト配列としてサウンド データを返します。
 * その場所からサウンド ファイルを読み込んで、読み込まれた .wav サウンド データを保持する__targetHitSound__変数を作成するには、 [mediareader:](#mediareaderloadmedia-method)を使用します。 詳しくは、[オーディオ ファイルの読み込み](#load-audio)を参照してください。 

サウンド効果は、ゲーム オブジェクトに関連付けられます。 したがって、衝突がそのゲーム オブジェクトで発生すると、再生されるサウンド効果がトリガーされます。 このゲーム サンプルでは、サウンド効果 (何お使用とターゲットを撮影する)、弾に使うと、ターゲットがあります。 
    
* __GameObject__クラス オブジェクトにサウンド効果を関連付けるために使用される__HitSound__プロパティがあります。
* [SoundEffect](#soundeffecth)クラスの新しいインスタンスを作成し、それを初期化します。 初期化時にサウンド効果のソース ボイスが作成されます。 
* このクラスは、[オーディオ](#audioh)クラスから提供されるマスタリング ボイスを使用してサウンドを再生します。 サウンド データは、 [MediaReader](#mediareaderh)クラスを使ってファイルの場所から読み込まれます。 詳しくは、[サウンドのオブジェクトを関連付ける](#associate-sound-to-object)を参照してください。

>[!Note]
>サウンドを再生する実際のトリガーは、移動とこれらのゲーム オブジェクトの衝突によって決定されます。 したがって、実際にこれらのサウンドを再生する呼び出しは、 [Simple3DGame::UpdateDynamics](#simple3dgameupdatedynamics-method)メソッドで定義されます。 詳しくは、[サウンドを再生](#play-the-sound)に移動します。

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

## <a name="create-and-initialize-the-audio-resources"></a>作成し、オーディオ リソースの初期化

* ミュージックとサウンド効果のエンジンを定義する 2 つの新しい XAudio2 オブジェクトを作成するのにには、 [XAudio2Create](https://msdn.microsoft.com/library/windows/desktop/ee419212)、XAudio2 API を使用します。 このメソッドは、スレッドの処理、音声グラフでは、オーディオのすべてのオーディオ エンジンの状態を管理するオブジェクトの[IXAudio2](https://msdn.microsoft.com/library/windows/desktop/ee415908)インターフェイスへのポインターを返します。
* エンジン後インスタンス化された、 [ixaudio 2::createmasteringvoice](https://msdn.microsoft.com/library/windows/desktop/hh405048)を使用してサウンド エンジン オブジェクトのそれぞれのマスタリング ボイスを作成します。

詳しくに移動します。[方法: XAudio2 の初期化](https://msdn.microsoft.com/library/windows/desktop/ee415779.aspx)します。

### <a name="audiocreatedeviceindependentresources-method"></a>Audio::CreateDeviceIndependentResources メソッド

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

## <a name="load-audio-file"></a>オーディオ ファイルの読み込み

ゲームのサンプルでは、オーディオ形式のファイルを読み取るコードは[MediaReader.h](#mediareaderh)/cpp__ で定義されます。  エンコードされた .wav オーディオ ファイルを読み取り、 [mediareader:](#mediareaderloadmedia-method)、入力パラメーターとして .wav のファイル名に渡して呼び出します。

### <a name="mediareaderloadmedia-method"></a>Mediareader: メソッド

このメソッドは、[メディア ファンデーション](https://msdn.microsoft.com/library/windows/desktop/ms694197) API を使って、.wav オーディオ ファイルをパルス符号変調 (PCM) バッファーとして読み取ります。

#### <a name="set-up-the-source-reader"></a>ソース リーダーをセットアップします。

1. [MFCreateSourceReaderFromURL](https://msdn.microsoft.com/library/windows/desktop/dd388110)を使用して、メディア ソース リーダー ([IMFSourceReader](https://msdn.microsoft.com/library/windows/desktop/dd374655)) を作成します。
2. [MFCreateMediaType](https://msdn.microsoft.com/library/windows/desktop/ms693861)を使用して、メディアの種類 ([IMFMediaType](https://msdn.microsoft.com/library/windows/desktop/ms704850)) オブジェクト (_mediaType_) を作成します。 メディア形式の説明を表します。 
3. _メディアの種類_のデコードされた出力が PCM オーディオは、 __XAudio2__を使用するオーディオの種類を指定します。
4. 呼び出し元[imfsourcereader::setcurrentmediatype](https://msdn.microsoft.com/library/windows/desktop/dd374667.aspx)によってソース リーダー用デコードされた出力メディアの種類を設定します。

ソース リーダーを使用する理由について詳しくは、[ソース リーダー](https://msdn.microsoft.com/library/windows/desktop/dd940436.aspx)に移動します。

#### <a name="describe-the-data-format-of-the-audio-stream"></a>オーディオ ストリームのデータ形式を記述します。

1. [Imfsourcereader::getcurrentmediatype](https://msdn.microsoft.com/library/windows/desktop/dd374660)を使用して、ストリームの現在のメディアの種類を取得します。
2. [IMFMediaType::MFCreateWaveFormatExFromMFMediaType](https://msdn.microsoft.com/library/windows/desktop/ms702177)を使用して、以前の操作の結果を入力として使用して、 [WAVEFORMATEX](https://msdn.microsoft.com/library/windows/hardware/ff538799)バッファーに、現在のオーディオ メディア タイプを変換します。 この構造体は、オーディオが読み込まれた後に使用される基準オーディオ ストリームのデータ形式を指定します。 

PCM バッファーを記述する__WAVEFORMATEX__形式を使用できます。 [WAVEFORMATEXTENSIBLE](https://msdn.microsoft.com/library/windows/hardware/ff538802)構造体と比較したにのみ使用できますを基準のオーディオ形式のサブセットを記述します。 __WAVEFORMATEX__と__WAVEFORMATEXTENSIBLE__の違いについて詳しくは、 [Extensible 基準形式記述子](https://docs.microsoft.com/windows-hardware/drivers/audio/extensible-wave-format-descriptors)を参照してください。

#### <a name="read-the-audio-stream"></a>オーディオ ストリームを読み取り

1.  [:Getpresentationattribute](https://msdn.microsoft.com/library/windows/desktop/dd374662)し、変換のバイトに継続時間を呼び出すことによって、オーディオ ストリームの秒単位での期間を取得します。
2.  オーディオ ファイルをストリームとして[imfsourcereader::readsample](https://msdn.microsoft.com/library/windows/desktop/dd374665)を呼び出すことによって読み取られます。 __ReadSample__は、メディア ソースから、次のサンプルを読み取ります。
3.  [IMFSample::ConvertToContiguousBuffer](https://msdn.microsoft.com/library/windows/desktop/ms698917.aspx)を使用して、配列 (_mediaBuffer_) に、オーディオ サンプル バッファー (_サンプル_) の内容をコピーします。

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
## <a name="associate-sound-to-object"></a>オブジェクトにサウンドを関連付ける

オブジェクトにサウンドを関連付けることが行わ[Simple3DGame::Initialize](#simple3dgameinitialize-method)メソッドで、ゲームの初期化します。

要約:
* __GameObject__クラス オブジェクトにサウンド効果を関連付けるために使用される__HitSound__プロパティがあります。
* [SoundEffect](#soundeffecth)クラスのオブジェクトの新しいインスタンスを作成し、ゲーム オブジェクトに関連付けます。 このクラスは、 __XAudio2__ Api を使用してサウンドを再生します。  [オーディオ](#audioh)クラスによって提供されるマスタリング ボイスを使用します。 サウンド データは、 [MediaReader](#mediareaderh)クラスを使ってファイルの場所から読み取ることができます。

__SoundEffect__は次の入力パラメーターのインスタンスを初期化するために使用する[SoundEffect::Initialize](#soundeffectinitialize-method) : サウンド エンジン オブジェクト (IXAudio2 オブジェクト[Audio::CreateDeviceIndependentResources](#audiocreatedeviceindependentresources-method)メソッドで作成) へのポインター形式へのポインター、.wav の__mediareader::getoutputwaveformatex__、サウンド データを使用してファイルを使って読み込まれる[mediareader:](#mediareaderloadmedia-method)メソッドです。 初期化時にサウンド効果のソース ボイスが作成されます。

### <a name="soundeffectinitialize-method"></a>SoundEffect::Initialize メソッド

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

## <a name="play-the-sound"></a>サウンドを再生します。

効果音を再生するトリガーは、これでは、オブジェクトの動きを更新し、オブジェクトの間の衝突を決定するために、 [Simple3DGame::UpdateDynamics](#simple3dgameupdatedynamics-method)メソッドで定義されます。

によっては、ゲーム オブジェクトの間の対話式操作が大幅と異なるため、ゲーム オブジェクトをここでのダイナミクスをについて説明しますがしません。 目的の実装を理解する場合は、 [Simple3DGame::UpdateDynamics](#simple3dgameupdatedynamics-method)メソッドに移動します。

基本的に、競合が発生すると、トリガーを [SoundEffect::PlaySound]((soundeffectplaysound-method) を呼び出すことによって再生するサウンド効果。 このメソッドは、現在再生されていると、目的のサウンド データをメモリ内のバッファーのキューにサウンド効果を停止します。 ソース ボイスを使用してボリュームを設定、サウンドのデータを送信し、再生を開始します。

### <a name="soundeffectplaysound-method"></a>Soundeffect::playsound メソッド

* ソース ボイス オブジェクト**m \_sourcevoice**を使用して、サウンド データ バッファー **m \_sounddata**の再生を開始するには
* [XAUDIO2\_BUFFER](https://msdn.microsoft.com/library/windows/desktop/ee419228)、これをサウンド データ バッファーへの参照を提供し、 [ixaudio2sourcevoice::submitsourcebuffer](https://msdn.microsoft.com/library/windows/desktop/ee418473)への呼び出しに送信を作成します。 
* サウンド データがキューに入ると、**SoundEffect::PlaySound** は、[IXAudio2SourceVoice::Start](https://msdn.microsoft.com/library/windows/desktop/ee418471) を呼び出して再生を開始します。

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

### <a name="simple3dgameupdatedynamics-method"></a>Simple3DGame::UpdateDynamics メソッド

__Simple3DGame::UpdateDynamics__メソッドは、対話式操作と衝突ゲーム オブジェクトの間で行われます。 オブジェクトが衝突する (または交差する) ときに、関連付けられているサウンド効果を再生するをトリガーします。

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
## <a name="next-steps"></a>次のステップ

UWP のフレームワーク、グラフィックス、コントロール、ユーザー インターフェイス、および Windows 10 ゲームのオーディオを説明します。 [ゲーム サンプルの紹介](tutorial-resources.md)を、このチュートリアルの次の部分では、ゲームを開発するときに使用できるその他のオプションについて説明します。

## <a name="audio-concepts"></a>オーディオの概念

Windows 10 ゲーム開発のためには、XAudio2 バージョン 2.9 を使用します。 このバージョンには、Windows 10 が付属しています。 詳しくは、 [XAudio2 のバージョン](https://msdn.microsoft.com/library/windows/desktop/ee415802.aspx)に移動します。

__AudioX2__では、信号処理とミキシングの基盤を提供する下位レベルの API です。 詳しくは、 [XAudio2 の主要な概念](https://msdn.microsoft.com/library/windows/desktop/ee415764.aspx)を参照してください。

### <a name="xaudio2-voices"></a>XAudio2 のボイス

XAudio2 のボイス オブジェクトの 3 種類が: ソース、サブミックス、マスタリング ボイスします。 ボイスは、オブジェクトの XAudio2 を使って処理、操作、およびオーディオ データを再生します。 
* ソース ボイスは、クライアントから提供されたオーディオ データに適用されます。 
* ソース ボイスとサブミックス ボイスは、1 つ以上のサブミックス ボイスまたはマスタリング ボイスに向けて出力を送信します。 
* サブミックス ボイスとマスタリング ボイスは、それぞれに送られるすべてのボイスからオーディオをミキシングし、その結果に対して作用します。 
* マスタリング ボイスは、ソース ボイスとサブミックス ボイスからデータを受信し、そのデータをオーディオ ハードウェアに送信します。

詳しくは、 [XAudio2 のボイス](https://msdn.microsoft.com/library/windows/desktop/ee415824.aspx)に移動します。

### <a name="audio-graph"></a>オーディオ グラフ

オーディオ グラフは、 [XAudio2 のボイス](#xaudio2-voice-objects)のコレクションです。 オーディオは、ソース ボイスのオーディオ グラフの一方の側から開始、必要に応じて通過する 1 つ以上のサブミックス ボイス、マスタリング ボイスで終わります。 オーディオ グラフは、現在再生中、0 個以上のサブミックス ボイス、各サウンドのソース ボイスとマスタリング ボイスを 1 つに含まれます。 最も単純なオーディオ グラフと XAudio2 での音の作成に必要な最小値は、マスター リング ボイスに直接出力する単一のソース ボイスです。 詳しくは、[オーディオ グラフ](https://msdn.microsoft.com/library/windows/desktop/ee415739.aspx)に移動します。

### <a name="additional-reading"></a>追加の読み取り

* [方法: XAudio2 の初期化](https://msdn.microsoft.com/library/windows/desktop/ee415779.aspx)
* [方法: XAudio2 でのオーディオ データ ファイルの読み込み](https://msdn.microsoft.com/library/windows/desktop/ee415781(v=vs.85).aspx)
* [方法: XAudio2 でのサウンド再生](https://msdn.microsoft.com/library/windows/desktop/ee415787.aspx)

## <a name="key-audio-h-files"></a>キーのオーディオ .h ファイル

### <a name="audioh"></a>Audio.h

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
### <a name="mediareaderh"></a>MediaReader.h

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
### <a name="soundeffecth"></a>SoundEffect.h

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


