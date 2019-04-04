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
# <a name="add-sound"></a>サウンドの追加

このトピックでは単純なサウンド エンジンを使用して作成します[XAudio2](https://msdn.microsoft.com/library/windows/desktop/ee415813) Api。 慣れていない場合__XAudio2__、下の短い概要を含めています[オーディオ概念](#audio-concepts)します。

>[!Note]
>このサンプルの最新ゲーム コードをダウンロードしていない場合は、[Direct3D ゲーム サンプルのページ](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Simple3DGameDX)に移動してください。 このサンプルは、UWP 機能のサンプルの大規模なコレクションの一部です。 サンプルをダウンロードする手順については、「[GitHub から UWP のサンプルを取得する](https://docs.microsoft.com/windows/uwp/get-started/get-uwp-app-samples)」をご覧ください。

## <a name="objective"></a>目標

サンプル ゲームの使用にサウンドを追加[XAudio2](/windows/desktop/xaudio2/xaudio2-introduction)します。

## <a name="define-the-audio-engine"></a>オーディオ エンジンを定義します。

このゲーム サンプルでは、オーディオのオブジェクトと動作は次の 3 つのファイルに定義されています。

* __[Audio.h](#audioh)/.cpp__:定義、__オーディオ__を格納するオブジェクト、 __XAudio2__サウンドの再生用のリソース。 また、ゲームが一時停止または非アクティブにされた場合にオーディオ再生を一時停止して再開するメソッドも定義します。
* __[MediaReader.h](#mediareaderh)/.cpp__:ローカル ストレージからオーディオ .wav ファイルを読み取るためのメソッドを定義します。
* __[SoundEffect.h](#soundeffecth)/.cpp__:ゲームでサウンドの再生用のオブジェクトを定義します。

## <a name="overview"></a>概要

オーディオの再生をゲームに設定する際に、次の 3 つの主要な部分があります。

1. [作成し、オーディオのリソースの初期化](#create-and-initialize-the-audio-resources)
2. [オーディオ ファイルの読み込み](#load-audio-file)
3. [オブジェクトにサウンドを関連付ける](#associate-sound-to-object)

すべてで定義されて、 [Simple3DGame::Initialize](#simple3dgameinitialize-method)メソッド。 このメソッドとの各セクションではさらに、情報を最初に見てみましょう。

設定後、再生するサウンド効果をトリガーする方法を学習します。 詳細についてを参照してください[サウンドを再生](#play-the-sound)します。

### <a name="simple3dgameinitialize-method"></a>Simple3DGame::Initialize メソッド

__Simple3DGame::Initialize__ここで、 __m\_コント ローラー__と__m\_レンダラー__は初期化も、オーディオ エンジンを設定し、取得サウンドを再生する準備ができました。

 * 作成__m\_audioController__のインスタンスである、[オーディオ](#audioh)クラス。
 * 使用して必要なオーディオ リソースを作成、 [Audio::CreateDeviceIndependentResources](#audiocreatedeviceindependentresources-method)メソッド。 ここでは、2 つ__XAudio2__オブジェクト&mdash;音楽のエンジン オブジェクトと、サウンド エンジン オブジェクトとそれぞれのマスターの音声が作成されました。 ゲームのバック グラウンド音楽を再生する音楽のエンジン オブジェクトを使用できます。 ゲームでサウンドを再生するサウンド エンジンを使用できます。 詳細については、[作成オーディオのリソースの初期化と](#create-and-initialize-the-audio-resources)を参照してください。
 * 作成__mediaReader__のインスタンスである[MediaReader](#mediareaderh)クラス。 [MediaReader](#mediareaderh)、用のヘルパー クラスは、 [SoundEffect](#soundeffecth)クラス、読み取り小規模なオーディオ ファイルの場所からファイルを同期的に、サウンドのデータをバイト配列として返します。
 * 使用[MediaReader::LoadMedia](#mediareaderloadmedia-method)をその場所からサウンド ファイルを読み込み、作成、 __targetHitSound__読み込む .wav サウンド データを保持する変数。 詳細については、[オーディオ ファイルの読み込み](#load-audio-file)を参照してください。 

サウンド効果は、ゲーム オブジェクトに関連付けられます。 したがってそのゲーム オブジェクトと、競合が発生したときに、再生するサウンド効果をトリガーします。 このゲームのサンプルでは、(使用して問題を持つターゲットを作り出してしまう) 弾薬とターゲットのサウンド効果があります。 
    
* __GameObject__クラスを__HitSound__オブジェクトへのサウンド効果を関連付けるために使用するプロパティ。
* 新しいインスタンスを作成、 [SoundEffect](#soundeffecth)クラスを初期化します。 初期化中に、サウンド効果のソースの音声が作成されます。 
* このクラスから提供されるマスタリング音声を使用してサウンドの再生、[オーディオ](#audioh)クラス。 使用してファイルの場所からサウンドのデータを読み取る、 [MediaReader](#mediareaderh)クラス。 詳細については、[オブジェクトにサウンドを関連付ける](#associate-sound-to-object)を参照してください。

>[!Note]
>サウンドを再生する実際のトリガーは、移動やこれらのゲーム オブジェクトの競合によって決定されます。 そのため、実際にこれらのサウンドを再生する呼び出しで定義されて、 [Simple3DGame::UpdateDynamics](#simple3dgameupdatedynamics-method)メソッド。 詳細についてを参照してください[サウンドを再生](#play-the-sound)します。

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

## <a name="create-and-initialize-the-audio-resources"></a>作成し、オーディオのリソースの初期化

* 使用[XAudio2Create](https://msdn.microsoft.com/library/windows/desktop/ee419212)、XAudio2 API、音楽とサウンド効果エンジンを定義する 2 つの新しい XAudio2 オブジェクトを作成します。 このメソッドは、オブジェクトのポインターを返します[IXAudio2](https://msdn.microsoft.com/library/windows/desktop/ee415908)すべてのオーディオ エンジンを管理するインターフェイスの状態、オーディオのスレッドや音声のグラフを処理します。
* エンジンがインスタンス化された後に使用して、 [IXAudio2::CreateMasteringVoice](https://msdn.microsoft.com/library/windows/desktop/hh405048)サウンド エンジン オブジェクトの各マスタリング音声を作成します。

詳細についてを参照してください[方法。初期化 XAudio2](https://msdn.microsoft.com/library/windows/desktop/ee415779.aspx)します。

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

ゲームのサンプルでは、オーディオ形式ファイルの読み取りにコードが定義されている[MediaReader.h](#mediareaderh)/cpp__ します。  エンコードされた .wav オーディオ ファイルを読み取り、呼び出し[MediaReader::LoadMedia](#mediareaderloadmedia-method)、入力パラメーターとして .wav のファイル名に渡します。

### <a name="mediareaderloadmedia-method"></a>MediaReader::LoadMedia メソッド

このメソッドは、[メディア ファンデーション](https://msdn.microsoft.com/library/windows/desktop/ms694197) API を使って、.wav オーディオ ファイルをパルス符号変調 (PCM) バッファーとして読み取ります。

#### <a name="set-up-the-source-reader"></a>ソース リーダーを設定します。

1. 使用[MFCreateSourceReaderFromURL](https://msdn.microsoft.com/library/windows/desktop/dd388110)ソース リーダー、メディアを作成する ([IMFSourceReader](https://msdn.microsoft.com/library/windows/desktop/dd374655))。
2. 使用[MFCreateMediaType](https://msdn.microsoft.com/library/windows/desktop/ms693861)メディアの種類を作成する ([IMFMediaType](https://msdn.microsoft.com/library/windows/desktop/ms704850)) オブジェクト (_mediaType_)。 メディア形式の説明を表します。 
3. 指定、 _mediaType_出力をデコードはオーディオは、PCM のオーディオ入力を__XAudio2__を使用できます。
4. デコード済み出力メディアを呼び出すことによってソース リーダーの入力セット[IMFSourceReader::SetCurrentMediaType](https://msdn.microsoft.com/library/windows/desktop/dd374667.aspx)します。

ソース リーダーを使用する理由の詳細についてを参照してください[ソース リーダー](https://msdn.microsoft.com/library/windows/desktop/dd940436.aspx)します。

#### <a name="describe-the-data-format-of-the-audio-stream"></a>オーディオ ストリームのデータ形式について説明します

1. 使用[IMFSourceReader::GetCurrentMediaType](https://msdn.microsoft.com/library/windows/desktop/dd374660)ストリームの現在のメディアの種類を取得します。
2. 使用[IMFMediaType::MFCreateWaveFormatExFromMFMediaType](https://msdn.microsoft.com/library/windows/desktop/ms702177)に現在のオーディオ メディアの種類に変換する、 [WAVEFORMATEX](https://msdn.microsoft.com/library/windows/hardware/ff538799)バッファー、以前の操作の結果を入力として使用します。 この構造体には、オーディオが読み込まれた後に使用される wave オーディオ ストリームのデータ形式を指定します。 

__WAVEFORMATEX__ PCM バッファーを記述する形式を使用できます。 比較、 [WAVEFORMATEXTENSIBLE](https://msdn.microsoft.com/library/windows/hardware/ff538802)構造、wave オーディオ形式のサブセットの記述にのみ使用できます。 詳細の相違点について__WAVEFORMATEX__と__WAVEFORMATEXTENSIBLE__を参照してください[Wave 形式の拡張可能な記述子](https://docs.microsoft.com/windows-hardware/drivers/audio/extensible-wave-format-descriptors)します。

#### <a name="read-the-audio-stream"></a>オーディオ ストリームを読み取り

1.  取得、期間 (秒) を呼び出すことによって、オーディオ ストリームの[IMFSourceReader::GetPresentationAttribute](https://msdn.microsoft.com/library/windows/desktop/dd374662)バイトに期間を変換します。
2.  ストリームとして呼び出してでオーディオ ファイルを読み取る[IMFSourceReader::ReadSample](https://msdn.microsoft.com/library/windows/desktop/dd374665)します。 __ReadSample__メディア ソースから次のサンプルを読み取ります。
3.  使用[IMFSample::ConvertToContiguousBuffer](https://msdn.microsoft.com/library/windows/desktop/ms698917.aspx)オーディオ サンプル バッファーの内容をコピーする (_サンプル_) 配列に (_mediaBuffer_)。

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

オブジェクトにサウンドを関連付けることが行われるときに、ゲームを初期化します、 [Simple3DGame::Initialize](#simple3dgameinitialize-method)メソッド。

要約:
* __GameObject__クラスを__HitSound__オブジェクトへのサウンド効果を関連付けるために使用するプロパティ。
* 新しいインスタンスを作成、 [SoundEffect](#soundeffecth)オブジェクトのクラスし、ゲーム オブジェクトに関連付けます。 このクラスを再生するサウンドを使用して__XAudio2__ Api。  によって提供されるマスタリング音声を使用して、[オーディオ](#audioh)クラス。 使用してファイルの場所からサウンドのデータを読み取ることができます、 [MediaReader](#mediareaderh)クラス。

[SoundEffect::Initialize](#soundeffectinitialize-method)を初期化するために使用、 __SoundEffect__次の入力パラメーターを持つインスタンス: サウンド エンジン オブジェクトへのポインター (で作成された IXAudio2 オブジェクト、[オーディオ。CreateDeviceIndependentResources](#audiocreatedeviceindependentresources-method)メソッド)、書式設定へのポインターを使用して .wav ファイル__MediaReader::GetOutputWaveFormatEx__を使用してサウンドのデータが読み込まれると[MediaReader::LoadMedia](#mediareaderloadmedia-method)メソッド。 初期化中に、サウンド効果のソース音声も作成されます。

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

サウンドを再生するトリガーが定義されている[Simple3DGame::UpdateDynamics](#simple3dgameupdatedynamics-method)メソッドがこれが、オブジェクトの移動を更新し、オブジェクト間の競合が決まります。

オブジェクト間の相互作用が、ゲームによって、大幅に異なりますのでゲーム オブジェクトには、ここの dynamics を説明することはできません。 その実装の理解を知りたい場合に移動[Simple3DGame::UpdateDynamics](#simple3dgameupdatedynamics-method)メソッド。

原則として、競合が発生したときにトリガーを呼び出してを再生するサウンド効果**SoundEffect::PlaySound**します。 このメソッドは、任意のサウンド効果が現在再生中し、目的のサウンドのデータをメモリ内のバッファーにキューを停止します。 ボリュームの設定、サウンドのデータを送信し、再生を開始するソースの音声を使用します。

### <a name="soundeffectplaysound-method"></a>SoundEffect::PlaySound メソッド

* ソースの音声オブジェクトを使用して**m\_sourceVoice**サウンド データ バッファーの再生を開始する**m\_soundData**
* 作成、 [XAUDIO2\_バッファー](https://msdn.microsoft.com/library/windows/desktop/ee419228)するサウンド データ バッファーへの参照を提供およびへの呼び出しに送信します、 [IXAudio2SourceVoice::SubmitSourceBuffer](https://msdn.microsoft.com/library/windows/desktop/ee418473)します。 
* サウンドのデータをキューに入れ、 **SoundEffect::PlaySound**開始を呼び出すことによって再生[IXAudio2SourceVoice::Start](https://msdn.microsoft.com/library/windows/desktop/ee418471)します。

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

__Simple3DGame::UpdateDynamics__相互作用とゲーム オブジェクト間の競合メソッドを行います。 オブジェクトが競合 (または intersect) ときに再生する場合は、関連付けられているサウンド効果をトリガーします。

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

UWP のフレームワーク、グラフィックス、コントロール、ユーザー インターフェイス、および Windows 10 ゲームのオーディオを説明します。 このチュートリアルの次の部分[ゲームのサンプルを拡張する](tutorial-resources.md)ゲームを開発する際に使用できるその他のオプションについて説明します。

## <a name="audio-concepts"></a>オーディオの概念

Windows 10 ゲームの開発、XAudio2 バージョン 2.9 を使用します。 このバージョンには、Windows 10 が同梱されています。 詳細についてを参照してください[XAudio2 バージョン](https://msdn.microsoft.com/library/windows/desktop/ee415802.aspx)します。

__AudioX2__は信号処理や基盤を提供する低レベルの API です。 詳細については、[XAudio2 Key Concepts](https://msdn.microsoft.com/library/windows/desktop/ee415764.aspx)を参照してください。

### <a name="xaudio2-voices"></a>XAudio2 音声

XAudio2 音声オブジェクトの 3 種類があります: ソースをおよび音声を習得します。 音声は、XAudio2 オブジェクトを使用して、処理、操作、およびオーディオ データを再生します。 
* ソース ボイスは、クライアントから提供されたオーディオ データに適用されます。 
* ソース ボイスとサブミックス ボイスは、1 つ以上のサブミックス ボイスまたはマスタリング ボイスに向けて出力を送信します。 
* サブミックス ボイスとマスタリング ボイスは、それぞれに送られるすべてのボイスからオーディオをミキシングし、その結果に対して作用します。 
* マスタリング音声では、ソース ボイスとサブミックス音声からデータを受信し、オーディオ ハードウェアにそのデータを送信します。

詳細についてを参照してください[XAudio2 音声](/windows/desktop/xaudio2/xaudio2-voices)します。

### <a name="audio-graph"></a>オーディオのグラフ

オーディオのグラフのコレクションである[XAudio2 音声](/windows/desktop/xaudio2/xaudio2-voices)します。 オーディオ音源のオーディオのグラフの一方の側から開始するには、必要に応じて、1 つまたは複数のサブミックス音声を通過およびマスタリング音声で終了します。 オーディオのグラフは、それぞれのサウンドを再生中に 0 個以上のサブミックス音声用ソース音声と 1 つのマスタリング音声が格納されます。 最も簡単なオーディオ グラフと、XAudio2 で音を鳴らす必要な最小値は、マスタリング音声に直接出力する 1 つのソース音声です。 詳細についてを参照してください[オーディオ グラフ](https://msdn.microsoft.com/library/windows/desktop/ee415739.aspx)します。

### <a name="additional-reading"></a>その他の情報

* 「[XAudio2 を初期化します。](https://msdn.microsoft.com/library/windows/desktop/ee415779.aspx)
* 「[XAudio2 にオーディオ データ ファイルを読み込む](https://msdn.microsoft.com/library/windows/desktop/ee415781(v=vs.85).aspx)
* 「[XAudio2 で音を鳴らす](https://msdn.microsoft.com/library/windows/desktop/ee415787.aspx)

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


