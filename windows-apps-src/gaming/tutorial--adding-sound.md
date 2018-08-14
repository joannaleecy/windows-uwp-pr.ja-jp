---
author: mtoepke
title: サウンドの追加
description: この手順では、シューティング ゲームのサンプルで XAudio2 API を使ってサウンド再生用のオブジェクトを作る方法について説明します。
ms.assetid: aa05efe2-2baa-8b9f-7418-23f5b6cd2266
ms.author: mtoepke
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, ゲーム, サウンド
ms.openlocfilehash: 11553a22274a36094a3e839e8fda648f78cfaaf8
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.locfileid: "243328"
---
# <a name="add-sound"></a><span data-ttu-id="c765e-104">サウンドの追加</span><span class="sxs-lookup"><span data-stu-id="c765e-104">Add sound</span></span>


<span data-ttu-id="c765e-105">\[Windows 10 の UWP アプリ向けに更新。</span><span class="sxs-lookup"><span data-stu-id="c765e-105">\[ Updated for UWP apps on Windows 10.</span></span> <span data-ttu-id="c765e-106">Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください。\]</span><span class="sxs-lookup"><span data-stu-id="c765e-106">For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]</span></span>

<span data-ttu-id="c765e-107">この手順では、シューティング ゲームのサンプルで [XAudio2](https://msdn.microsoft.com/library/windows/desktop/ee415813) API を使ってサウンド再生用のオブジェクトを作る方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="c765e-107">In this step, we examine how the shooting game sample creates an object for sound playback using the [XAudio2](https://msdn.microsoft.com/library/windows/desktop/ee415813) APIs.</span></span>

## <a name="objective"></a><span data-ttu-id="c765e-108">目標</span><span class="sxs-lookup"><span data-stu-id="c765e-108">Objective</span></span>


-   <span data-ttu-id="c765e-109">[XAudio2](https://msdn.microsoft.com/library/windows/desktop/ee415813) を使ってサウンド出力を追加する。</span><span class="sxs-lookup"><span data-stu-id="c765e-109">To add sound output using [XAudio2](https://msdn.microsoft.com/library/windows/desktop/ee415813).</span></span>

<span data-ttu-id="c765e-110">このゲーム サンプルでは、オーディオのオブジェクトと動作は次の 3 つのファイルに定義されています。</span><span class="sxs-lookup"><span data-stu-id="c765e-110">In the game sample, the audio objects and behaviors are defined in three files:</span></span>

-   <span data-ttu-id="c765e-111">**Audio.h/.cpp**。</span><span class="sxs-lookup"><span data-stu-id="c765e-111">**Audio.h/.cpp**.</span></span> <span data-ttu-id="c765e-112">このコード ファイルは、サウンド再生用の XAudio2 リソースが含まれている **Audio** オブジェクトを定義します。</span><span class="sxs-lookup"><span data-stu-id="c765e-112">This code file defines the **Audio** object, which contains the XAudio2 resources for sound playback.</span></span> <span data-ttu-id="c765e-113">また、ゲームが一時停止または非アクティブにされた場合にオーディオ再生を一時停止して再開するメソッドも定義します。</span><span class="sxs-lookup"><span data-stu-id="c765e-113">It also defines the method for suspending and resuming audio playback if the game is paused or deactivated.</span></span>
-   <span data-ttu-id="c765e-114">**MediaReader.h/.cpp**。</span><span class="sxs-lookup"><span data-stu-id="c765e-114">**MediaReader.h/.cpp**.</span></span> <span data-ttu-id="c765e-115">このコードは、オーディオ .wav ファイルをローカル ストレージから読み取るメソッドを定義します。</span><span class="sxs-lookup"><span data-stu-id="c765e-115">This code defines the methods for reading audio .wav files from local storage.</span></span>
-   <span data-ttu-id="c765e-116">**SoundEffect.h/.cpp**。</span><span class="sxs-lookup"><span data-stu-id="c765e-116">**SoundEffect.h/.cpp**.</span></span> <span data-ttu-id="c765e-117">このコードは、ゲーム内サウンド再生用のオブジェクトを定義します。</span><span class="sxs-lookup"><span data-stu-id="c765e-117">This code defines an object for in-game sound playback.</span></span>

## <a name="defining-the-audio-engine"></a><span data-ttu-id="c765e-118">オーディオ エンジンの定義</span><span class="sxs-lookup"><span data-stu-id="c765e-118">Defining the audio engine</span></span>


<span data-ttu-id="c765e-119">このゲーム サンプルは、開始されると、ゲームのオーディオ リソースを割り当てる **Audio** オブジェクトを作ります。</span><span class="sxs-lookup"><span data-stu-id="c765e-119">When the game sample starts, it creates an **Audio** object that allocates the audio resources for the game.</span></span> <span data-ttu-id="c765e-120">このオブジェクトを宣言するコードは次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="c765e-120">The code that declares this object looks like this:</span></span>

```cpp
public:
    Audio();

    void Initialize();
    void CreateDeviceIndependentResources();
    IXAudio2* MusicEngine();
    IXAudio2* SoundEffectEngine();
    void SuspendAudio();
    void ResumeAudio();

protected:
    bool                                m_audioAvailable;
    Microsoft::WRL::ComPtr<IXAudio2>    m_musicEngine;
    Microsoft::WRL::ComPtr<IXAudio2>    m_soundEffectEngine;
    IXAudio2MasteringVoice*             m_musicMasteringVoice;
    IXAudio2MasteringVoice*             m_soundEffectMasteringVoice;
};
```

<span data-ttu-id="c765e-121">**Audio::MusicEngine** と **Audio::SoundEffectEngine** のメソッドは、各種類のオーディオのマスターリング ボイスを定義する [**IXAudio2**](https://msdn.microsoft.com/library/windows/desktop/ee415908) オブジェクトへの参照を返します。</span><span class="sxs-lookup"><span data-stu-id="c765e-121">The **Audio::MusicEngine** and **Audio::SoundEffectEngine** methods return references to [**IXAudio2**](https://msdn.microsoft.com/library/windows/desktop/ee415908) objects that define the mastering voice for each audio type.</span></span> <span data-ttu-id="c765e-122">マスターリング ボイスは、再生に使われるオーディオ デバイスです。</span><span class="sxs-lookup"><span data-stu-id="c765e-122">A mastering voice is the audio device used for playback.</span></span> <span data-ttu-id="c765e-123">サウンド データ バッファーをマスターリング ボイスに直接送信することはできませんが、他の種類のボイスに送信されたデータは、聞くマスターリング ボイスに転送する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c765e-123">Sound data buffers cannot be submitted directly to mastering voices, but data submitted to other types of voices must be directed to a mastering voice to be heard.</span></span>

## <a name="initializing-the-audio-resources"></a><span data-ttu-id="c765e-124">オーディオ リソースの初期化</span><span class="sxs-lookup"><span data-stu-id="c765e-124">Initializing the audio resources</span></span>


<span data-ttu-id="c765e-125">このサンプルでは、[**XAudio2Create**](https://msdn.microsoft.com/library/windows/desktop/ee419212) を呼び出して、ミュージックとサウンド効果のエンジンの [**IXAudio2**](https://msdn.microsoft.com/library/windows/desktop/ee415908) オブジェクトを初期化します。</span><span class="sxs-lookup"><span data-stu-id="c765e-125">The sample initializes the [**IXAudio2**](https://msdn.microsoft.com/library/windows/desktop/ee415908) objects for the music and sound effect engines with calls to [**XAudio2Create**](https://msdn.microsoft.com/library/windows/desktop/ee419212).</span></span> <span data-ttu-id="c765e-126">これらのエンジンをインスタンス化した後、次に示すように、[**IXAudio2::CreateMasteringVoice**](https://msdn.microsoft.com/library/windows/desktop/hh405048) を呼び出して、各エンジンのマスターリング ボイスを作ります。</span><span class="sxs-lookup"><span data-stu-id="c765e-126">After the engines have been instantiated, it creates a mastering voice for each with calls to [**IXAudio2::CreateMasteringVoice**](https://msdn.microsoft.com/library/windows/desktop/hh405048), as here:</span></span>

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

<span data-ttu-id="c765e-127">ミュージックまたはサウンド効果のオーディオ ファイルが読み込まれると、このメソッドはマスターリング ボイスの [**IXAudio2::CreateSourceVoice**](https://msdn.microsoft.com/library/windows/desktop/ee418607) を呼び出し、これによって再生用のソース ボイスのインスタンスが作られます。</span><span class="sxs-lookup"><span data-stu-id="c765e-127">As a music or sound effect audio file is loaded, this method calls [**IXAudio2::CreateSourceVoice**](https://msdn.microsoft.com/library/windows/desktop/ee418607) on the mastering voice, which creates an instance of a source voice for playback.</span></span> <span data-ttu-id="c765e-128">このためのコードについては、ゲーム サンプルでオーディオ ファイルを読み込む方法を確認した後で説明します。</span><span class="sxs-lookup"><span data-stu-id="c765e-128">We look at the code for this as soon as we finish reviewing how the game sample loads audio files.</span></span>

## <a name="reading-an-audio-file"></a><span data-ttu-id="c765e-129">オーディオ ファイルの読み取り</span><span class="sxs-lookup"><span data-stu-id="c765e-129">Reading an audio file</span></span>


<span data-ttu-id="c765e-130">このゲーム サンプルでは、オーディオ形式のファイルを読み取るコードは **MediaReader.cpp** に定義されています。</span><span class="sxs-lookup"><span data-stu-id="c765e-130">In the game sample, the code for reading audio format files is defined in **MediaReader.cpp**.</span></span> <span data-ttu-id="c765e-131">エンコードされた .wav オーディオ ファイル **MediaReader::LoadMedia** を読み取るメソッドは次のようになります。</span><span class="sxs-lookup"><span data-stu-id="c765e-131">The specific method that reads in an encoded .wav audio file, **MediaReader::LoadMedia**, looks like this:</span></span>

```cpp
Platform::Array<byte>^  MediaReader::LoadMedia(_In_ Platform::String^ filename)
{
    DX::ThrowIfFailed(
        MFStartup(MF_VERSION)
        );

    ComPtr<IMFSourceReader> reader;
    DX::ThrowIfFailed(
        MFCreateSourceReaderFromURL(
            Platform::String::Concat(m_installedLocationPath, filename)->Data(),
            nullptr,
            &reader
            )
        );

    // Set the decoded output format as PCM
    // XAudio2 on Windows can process PCM and ADPCM-encoded buffers.
    // When using MediaFoundation, this sample always decodes into PCM.
    Microsoft::WRL::ComPtr<IMFMediaType> mediaType;
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
        reader->SetCurrentMediaType(MF_SOURCE_READER_FIRST_AUDIO_STREAM, 0, mediaType.Get())
        );

    // Get the complete WAVEFORMAT from the Media Type.
    Microsoft::WRL::ComPtr<IMFMediaType> outputMediaType;
    DX::ThrowIfFailed(
        reader->GetCurrentMediaType(MF_SOURCE_READER_FIRST_AUDIO_STREAM, &outputMediaType)
        );

    UINT32 size = 0;
    WAVEFORMATEX* waveFormat;
    DX::ThrowIfFailed(
        MFCreateWaveFormatExFromMFMediaType(outputMediaType.Get(), &waveFormat, &size)
        );

    CopyMemory(&m_waveFormat, waveFormat, sizeof(m_waveFormat));
    CoTaskMemFree(waveFormat);

    // Get the total length of the stream in bytes.
    PROPVARIANT propVariant;
    DX::ThrowIfFailed(
        reader->GetPresentationAttribute(MF_SOURCE_READER_MEDIASOURCE, MF_PD_DURATION, &propVariant)
        );
    LONGLONG duration = propVariant.uhVal.QuadPart;
    unsigned int maxStreamLengthInBytes;

    double durationInSeconds = (duration / static_cast<double>(10000 * 1000));
    maxStreamLengthInBytes = static_cast<unsigned int>(durationInSeconds * m_waveFormat.nAvgBytesPerSec);

    // Make the length a multiple of 4 bytes.
    maxStreamLengthInBytes = (maxStreamLengthInBytes + 3) / 4 * 4;

    Platform::Array<byte>^ fileData = ref new Platform::Array<byte>(maxStreamLengthInBytes);

    ComPtr<IMFSample> sample;
    ComPtr<IMFMediaBuffer> mediaBuffer;
    DWORD flags = 0;

    int positionInData = 0;
    bool done = false;
    while (!done)
    {
        DX::ThrowIfFailed(
            reader->ReadSample(MF_SOURCE_READER_FIRST_AUDIO_STREAM, 0, nullptr, &flags, nullptr, &sample)
            );

        if (sample != nullptr)
        {
            DX::ThrowIfFailed(
                sample->ConvertToContiguousBuffer(&mediaBuffer)
                );

            BYTE *audioData = nullptr;
            DWORD sampleBufferLength = 0;
            DX::ThrowIfFailed(
                mediaBuffer->Lock(&audioData, nullptr, &sampleBufferLength)
                );

            for (DWORD i = 0; i < sampleBufferLength; i++)
            {
                fileData[positionInData++] = audioData[i];
            }
        }
        if (flags & MF_SOURCE_READERF_ENDOFSTREAM)
        {
            done = true;
        }
    }

    // Fix up the array size on match the actual length.
    Platform::Array<byte>^ realfileData = ref new Platform::Array<byte>((positionInData + 3) / 4 * 4);
    memcpy(realfileData->Data, fileData->Data, positionInData);
    return realfileData;
}
```

<span data-ttu-id="c765e-132">このメソッドは、[メディア ファンデーション](https://msdn.microsoft.com/library/windows/desktop/ms694197) API を使って、.wav オーディオ ファイルをパルス符号変調 (PCM) バッファーとして読み取ります。</span><span class="sxs-lookup"><span data-stu-id="c765e-132">This method uses the [Media Foundation](https://msdn.microsoft.com/library/windows/desktop/ms694197) APIs to read in the .wav audio file as a Pulse Code Modulation (PCM) buffer.</span></span>

1.  <span data-ttu-id="c765e-133">[**MFCreateSourceReaderFromURL**](https://msdn.microsoft.com/library/windows/desktop/dd388110) を呼び出して、メディア ソース リーダー ([**IMFSourceReader**](https://msdn.microsoft.com/library/windows/desktop/dd374655)) オブジェクトを作ります。</span><span class="sxs-lookup"><span data-stu-id="c765e-133">Creates a media source reader ([**IMFSourceReader**](https://msdn.microsoft.com/library/windows/desktop/dd374655)) object by calling [**MFCreateSourceReaderFromURL**](https://msdn.microsoft.com/library/windows/desktop/dd388110).</span></span>
2.  <span data-ttu-id="c765e-134">[**MFCreateMediaType**](https://msdn.microsoft.com/library/windows/desktop/ms693861) を呼び出して、オーディオ ファイルのデコードのメディアの種類 ([**IMFMediaType**](https://msdn.microsoft.com/library/windows/desktop/ms704850)) を作ります。</span><span class="sxs-lookup"><span data-stu-id="c765e-134">Creates a media type ([**IMFMediaType**](https://msdn.microsoft.com/library/windows/desktop/ms704850)) for the decoding of the audio file by calling [**MFCreateMediaType**](https://msdn.microsoft.com/library/windows/desktop/ms693861).</span></span> <span data-ttu-id="c765e-135">このメソッドは、デコードされた出力の種類として PCM オーディオを指定します。これは、XAudio2 が使うことができるオーディオの種類です。</span><span class="sxs-lookup"><span data-stu-id="c765e-135">This method specifies that the decoded output is PCM audio, which is an audio type that XAudio2 can use.</span></span>
3.  <span data-ttu-id="c765e-136">[**IMFSourceReader::SetCurrentMediaType**](https://msdn.microsoft.com/library/windows/desktop/bb970432) を呼び出して、リーダー用のデコードされた出力のメディアの種類を設定します。</span><span class="sxs-lookup"><span data-stu-id="c765e-136">Sets the decoded output media type for the reader by calling [**IMFSourceReader::SetCurrentMediaType**](https://msdn.microsoft.com/library/windows/desktop/bb970432).</span></span>
4.  <span data-ttu-id="c765e-137">[**WAVEFORMATEX**](https://msdn.microsoft.com/library/windows/hardware/ff538799) バッファーを作り、[**IMFMediaType**](https://msdn.microsoft.com/library/windows/desktop/ms704850) オブジェクトの [**IMFMediaType::MFCreateWaveFormatExFromMFMediaType**](https://msdn.microsoft.com/library/windows/desktop/ms702177) を呼び出した結果をコピーします。</span><span class="sxs-lookup"><span data-stu-id="c765e-137">Creates a [**WAVEFORMATEX**](https://msdn.microsoft.com/library/windows/hardware/ff538799) buffer and copies the results of a call to [**IMFMediaType::MFCreateWaveFormatExFromMFMediaType**](https://msdn.microsoft.com/library/windows/desktop/ms702177) on the [**IMFMediaType**](https://msdn.microsoft.com/library/windows/desktop/ms704850) object.</span></span> <span data-ttu-id="c765e-138">これで、読み込んだオーディオ ファイルを保持するバッファーがフォーマットされます。</span><span class="sxs-lookup"><span data-stu-id="c765e-138">This formats the buffer that holds the audio file after it is loaded.</span></span>
5.  <span data-ttu-id="c765e-139">[**IMFSourceReader::GetPresentationAttribute**](https://msdn.microsoft.com/library/windows/desktop/dd374662) を呼び出して、オーディオ ストリームの期間を秒数で取得した後、その期間をバイト数に変換します。</span><span class="sxs-lookup"><span data-stu-id="c765e-139">Gets the duration, in seconds, of the audio stream by calling [**IMFSourceReader::GetPresentationAttribute**](https://msdn.microsoft.com/library/windows/desktop/dd374662) and then converts the duration to bytes.</span></span>
6.  <span data-ttu-id="c765e-140">[**IMFSourceReader::ReadSample**](https://msdn.microsoft.com/library/windows/desktop/dd374665) を呼び出して、オーディオ ファイルをストリームとして読み取ります。</span><span class="sxs-lookup"><span data-stu-id="c765e-140">Reads the audio file in as a stream by calling [**IMFSourceReader::ReadSample**](https://msdn.microsoft.com/library/windows/desktop/dd374665).</span></span>
7.  <span data-ttu-id="c765e-141">このメソッドで返された配列に、オーディオ サンプル バッファーのコンテンツをコピーします。</span><span class="sxs-lookup"><span data-stu-id="c765e-141">Copies the contents of the audio sample buffer into an array returned by the method.</span></span>

<span data-ttu-id="c765e-142">**SoundEffect::Initialize** で最も重要なことは、ソース ボイス オブジェクト **m\_sourceVoice** をマスターリング ボイスから作ることです。</span><span class="sxs-lookup"><span data-stu-id="c765e-142">The most important thing in **SoundEffect::Initialize** is the creation of the source voice object, **m\_sourceVoice**, from the mastering voice.</span></span> <span data-ttu-id="c765e-143">このソース ボイスは、**MediaReader::LoadMedia** から取得したサウンド データ バッファーの実際の再生に使います。</span><span class="sxs-lookup"><span data-stu-id="c765e-143">We use the source voice for the actual play back of the sound data buffer obtained from **MediaReader::LoadMedia**.</span></span>

<span data-ttu-id="c765e-144">サンプル ゲームでは、次のように、**SoundEffect** オブジェクトを初期化するときにこのメソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="c765e-144">The sample game calls this method when it initializes the **SoundEffect** object, like this:</span></span>

```cpp
void SoundEffect::Initialize(
    _In_ IXAudio2 *masteringEngine,
    _In_ WAVEFORMATEX *sourceFormat,
    _In_ Platform::Array<byte>^ soundData)
{
    m_soundData = soundData;

    if (masteringEngine == nullptr)
    {
        // Audio is not available, so return.
        m_audioAvailable = false;
        return;
    }

    // Create and reuse a single source voice for the single sound effect in this sample.
    DX::ThrowIfFailed(
        masteringEngine->CreateSourceVoice(
            &m_sourceVoice,
            sourceFormat
            )
        );
    m_audioAvailable = true;
}
```

<span data-ttu-id="c765e-145">このメソッドには、次に示すように、**Audio::SoundEffectEngine** (または **Audio::MusicEngine**) と **MediaReader::GetOutputWaveFormatEx** を呼び出した結果と、**MediaReader::LoadMedia** を呼び出して返されたバッファーが渡されます。</span><span class="sxs-lookup"><span data-stu-id="c765e-145">This method is passed the results of calls to **Audio::SoundEffectEngine** (or **Audio::MusicEngine**), **MediaReader::GetOutputWaveFormatEx**, and the buffer returned by a call to **MediaReader::LoadMedia**, as seen here.</span></span>

```cpp
MediaReader^ mediaReader = ref new MediaReader;
auto targetHitSound = mediaReader->LoadMedia("hit.wav");
```

```cpp
myTarget->HitSound(ref new SoundEffect());
myTarget->HitSound()->Initialize(
                m_audioController->SoundEffectEngine(),
                mediaReader->GetOutputWaveFormatEx(),
                targetHitSound);
```

<span data-ttu-id="c765e-146">**SoundEffect::Initialize** は、メイン ゲーム オブジェクトを初期化する **Simple3DGame:Initialize** メソッドから呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="c765e-146">**SoundEffect::Initialize** is called from the **Simple3DGame:Initialize** method that initializes the main game object.</span></span>

<span data-ttu-id="c765e-147">これで、サンプル ゲームのオーディオ ファイルがメモリに格納されたので、次は、ゲーム中にこのファイルが再生される方法を見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="c765e-147">Now that the sample game has an audio file in memory, let's see how it plays it back during game play!</span></span>

## <a name="playing-back-an-audio-file"></a><span data-ttu-id="c765e-148">オーディオ ファイルの再生</span><span class="sxs-lookup"><span data-stu-id="c765e-148">Playing back an audio file</span></span>


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

<span data-ttu-id="c765e-149">サウンドを再生する際、このメソッドは、ソース ボイス オブジェクト **m\_sourceVoice** を使って、サウンド データ バッファー **m\_soundData** の再生を開始します。</span><span class="sxs-lookup"><span data-stu-id="c765e-149">To play the sound, this method uses the source voice object **m\_sourceVoice** to start the playback of the sound data buffer **m\_soundData**.</span></span> <span data-ttu-id="c765e-150">そして、[**XAUDIO2\_BUFFER**](https://msdn.microsoft.com/library/windows/desktop/ee419228) を作り、これにサウンド データ バッファーへの参照を渡した後、[**IXAudio2SourceVoice::SubmitSourceBuffer**](https://msdn.microsoft.com/library/windows/desktop/ee418473) を呼び出してこれを送信します。</span><span class="sxs-lookup"><span data-stu-id="c765e-150">It creates an [**XAUDIO2\_BUFFER**](https://msdn.microsoft.com/library/windows/desktop/ee419228), to which it provides a reference to the sound data buffer, and then submits it with a call to [**IXAudio2SourceVoice::SubmitSourceBuffer**](https://msdn.microsoft.com/library/windows/desktop/ee418473).</span></span> <span data-ttu-id="c765e-151">サウンド データがキューに入ると、**SoundEffect::PlaySound** は、[**IXAudio2SourceVoice::Start**](https://msdn.microsoft.com/library/windows/desktop/ee418471) を呼び出して再生を開始します。</span><span class="sxs-lookup"><span data-stu-id="c765e-151">With the sound data queued up, **SoundEffect::PlaySound** starts play back by calling [**IXAudio2SourceVoice::Start**](https://msdn.microsoft.com/library/windows/desktop/ee418471).</span></span>

<span data-ttu-id="c765e-152">これで、弾が標的に当たるたびに、**SoundEffect::PlaySound** が呼び出されて音が再生されます。</span><span class="sxs-lookup"><span data-stu-id="c765e-152">Now, whenever a collision between the ammo and a target occurs, a call to **SoundEffect::PlaySound** causes a noise to play.</span></span>

## <a name="next-steps"></a><span data-ttu-id="c765e-153">次のステップ</span><span class="sxs-lookup"><span data-stu-id="c765e-153">Next steps</span></span>


<span data-ttu-id="c765e-154">これで、ユニバーサル Windows プラットフォーム (UWP) DirectX ゲーム開発のクイック ツアーは終了です。</span><span class="sxs-lookup"><span data-stu-id="c765e-154">That was a whirlwind tour of Universal Windows Platform (UWP) DirectX game development!</span></span> <span data-ttu-id="c765e-155">今までの説明から、Windows 8 用に作成するゲームで快適なエクスペリエンスを実現するためには何をする必要があるかをご理解いただけたと思います。</span><span class="sxs-lookup"><span data-stu-id="c765e-155">At this point, you have an idea of what you need to do to make your own game for Windows 8 a great experience.</span></span> <span data-ttu-id="c765e-156">作成するゲームは、さまざまな Windows 8 デバイスとプラットフォームで実行される可能性があるため、グラフィックス、コントロール、ユーザー インターフェイス、オーディオなどのコンポーネントは、できる限り幅広い構成に対応するように設計してください。</span><span class="sxs-lookup"><span data-stu-id="c765e-156">Remember, your game can be played on a wide variety of Windows 8 devices and platforms, so design your components: your graphics, your controls, your user interface, and your audio for as wide a set of configurations as you can!</span></span>

<span data-ttu-id="c765e-157">今までの説明で使ったゲーム サンプルを変更する方法について詳しくは、「[ゲーム サンプルの拡張](tutorial-resources.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c765e-157">For more info about ways to modify the game sample provided in these documents, see [Extending the game sample](tutorial-resources.md).</span></span>

## <a name="complete-sample-code-for-this-section"></a><span data-ttu-id="c765e-158">このセクションのサンプル コード一式</span><span class="sxs-lookup"><span data-stu-id="c765e-158">Complete sample code for this section</span></span>


<span data-ttu-id="c765e-159">Audio.h</span><span class="sxs-lookup"><span data-stu-id="c765e-159">Audio.h</span></span>

```cpp
//// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
//// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
//// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//// PARTICULAR PURPOSE.
////
//// Copyright (c) Microsoft Corporation. All rights reserved

#pragma once

ref class Audio
{
public:
    Audio();

    void Initialize();
    void CreateDeviceIndependentResources();
    IXAudio2* MusicEngine();
    IXAudio2* SoundEffectEngine();
    void SuspendAudio();
    void ResumeAudio();

protected:
    bool                                m_audioAvailable;
    Microsoft::WRL::ComPtr<IXAudio2>    m_musicEngine;
    Microsoft::WRL::ComPtr<IXAudio2>    m_soundEffectEngine;
    IXAudio2MasteringVoice*             m_musicMasteringVoice;
    IXAudio2MasteringVoice*             m_soundEffectMasteringVoice;
};
```

<span data-ttu-id="c765e-160">Audio.cpp</span><span class="sxs-lookup"><span data-stu-id="c765e-160">Audio.cpp</span></span>

```cpp
//// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
//// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
//// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//// PARTICULAR PURPOSE.
////
//// Copyright (c) Microsoft Corporation. All rights reserved

#include "pch.h"
#include "Audio.h"
#include "DirectXSample.h"

using namespace Microsoft::WRL;
using namespace Windows::Foundation;
using namespace Windows::UI::Core;
using namespace Windows::Graphics::Display;

Audio::Audio():
    m_audioAvailable(false)
{
}

void Audio::Initialize()
{
}

void Audio::CreateDeviceIndependentResources()
{
    UINT32 flags = 0;

    DX::ThrowIfFailed(
        XAudio2Create(&m_musicEngine, flags)
        );

#if defined(_DEBUG)
    XAUDIO2_DEBUG_CONFIGURATION debugConfiguration = {0};
    debugConfiguration.BreakMask = XAUDIO2_LOG_ERRORS;
    debugConfiguration.TraceMask = XAUDIO2_LOG_ERRORS;
    m_musicEngine->SetDebugConfiguration(&debugConfiguration);
#endif


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

#if defined(_DEBUG)
    m_soundEffectEngine->SetDebugConfiguration(&debugConfiguration);
#endif

    DX::ThrowIfFailed(
        m_soundEffectEngine->CreateMasteringVoice(&m_soundEffectMasteringVoice)
        );

    m_audioAvailable = true;
}

IXAudio2* Audio::MusicEngine()
{
    return m_musicEngine.Get();
}

IXAudio2* Audio::SoundEffectEngine()
{
    return m_soundEffectEngine.Get();
}

void Audio::SuspendAudio()
{
    if (m_audioAvailable)
    {
        m_musicEngine->StopEngine();
        m_soundEffectEngine->StopEngine();
    }
}

void Audio::ResumeAudio()
{
    if (m_audioAvailable)
    {
        DX::ThrowIfFailed(m_musicEngine->StartEngine());
        DX::ThrowIfFailed(m_soundEffectEngine->StartEngine());
    }
}
```

<span data-ttu-id="c765e-161">SoundEffect.h</span><span class="sxs-lookup"><span data-stu-id="c765e-161">SoundEffect.h</span></span>

```cpp
//// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
//// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
//// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//// PARTICULAR PURPOSE.
////
//// Copyright (c) Microsoft Corporation. All rights reserved

#pragma once

ref class SoundEffect
{
public:
    SoundEffect();

    void Initialize(
        _In_ IXAudio2*              masteringEngine,
        _In_ WAVEFORMATEX*          sourceFormat,
        _In_ Platform::Array<byte>^ soundData
        );

    void PlaySound(_In_ float volume);

protected:
    bool                    m_audioAvailable;
    IXAudio2SourceVoice*    m_sourceVoice;
    Platform::Array<byte>^  m_soundData;
};
```

<span data-ttu-id="c765e-162">SoundEffect.cpp</span><span class="sxs-lookup"><span data-stu-id="c765e-162">SoundEffect.cpp</span></span>

```cpp
//// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
//// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
//// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//// PARTICULAR PURPOSE.
////
//// Copyright (c) Microsoft Corporation. All rights reserved

#include "pch.h"
#include "SoundEffect.h"
#include "DirectXSample.h"

SoundEffect::SoundEffect():
    m_audioAvailable(false)
{
}
//----------------------------------------------------------------------
void SoundEffect::Initialize(
    _In_ IXAudio2 *masteringEngine,
    _In_ WAVEFORMATEX *sourceFormat,
    _In_ Platform::Array<byte>^ soundData)
{
    m_soundData = soundData;

    if (masteringEngine == nullptr)
    {
        // Audio is not available, so return.
        m_audioAvailable = false;
        return;
    }

    // Create and reuse a single source voice for the single sound effect in this sample.
    DX::ThrowIfFailed(
        masteringEngine->CreateSourceVoice(
            &m_sourceVoice,
            sourceFormat
            )
        );
    m_audioAvailable = true;
}
//----------------------------------------------------------------------
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

 

 




