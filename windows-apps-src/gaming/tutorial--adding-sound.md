---
author: mtoepke
title: "サウンドの追加"
description: "この手順では、シューティング ゲームのサンプルで XAudio2 API を使ってサウンド再生用のオブジェクトを作る方法について説明します。"
ms.assetid: aa05efe2-2baa-8b9f-7418-23f5b6cd2266
ms.author: mtoepke
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, ゲーム, サウンド"
ms.openlocfilehash: 11553a22274a36094a3e839e8fda648f78cfaaf8
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
# <a name="add-sound"></a>サウンドの追加


\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください。\]

この手順では、シューティング ゲームのサンプルで [XAudio2](https://msdn.microsoft.com/library/windows/desktop/ee415813) API を使ってサウンド再生用のオブジェクトを作る方法について説明します。

## <a name="objective"></a>目標


-   [XAudio2](https://msdn.microsoft.com/library/windows/desktop/ee415813) を使ってサウンド出力を追加する。

このゲーム サンプルでは、オーディオのオブジェクトと動作は次の 3 つのファイルに定義されています。

-   **Audio.h/.cpp**。 このコード ファイルは、サウンド再生用の XAudio2 リソースが含まれている **Audio** オブジェクトを定義します。 また、ゲームが一時停止または非アクティブにされた場合にオーディオ再生を一時停止して再開するメソッドも定義します。
-   **MediaReader.h/.cpp**。 このコードは、オーディオ .wav ファイルをローカル ストレージから読み取るメソッドを定義します。
-   **SoundEffect.h/.cpp**。 このコードは、ゲーム内サウンド再生用のオブジェクトを定義します。

## <a name="defining-the-audio-engine"></a>オーディオ エンジンの定義


このゲーム サンプルは、開始されると、ゲームのオーディオ リソースを割り当てる **Audio** オブジェクトを作ります。 このオブジェクトを宣言するコードは次のとおりです。

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

**Audio::MusicEngine** と **Audio::SoundEffectEngine** のメソッドは、各種類のオーディオのマスターリング ボイスを定義する [**IXAudio2**](https://msdn.microsoft.com/library/windows/desktop/ee415908) オブジェクトへの参照を返します。 マスターリング ボイスは、再生に使われるオーディオ デバイスです。 サウンド データ バッファーをマスターリング ボイスに直接送信することはできませんが、他の種類のボイスに送信されたデータは、聞くマスターリング ボイスに転送する必要があります。

## <a name="initializing-the-audio-resources"></a>オーディオ リソースの初期化


このサンプルでは、[**XAudio2Create**](https://msdn.microsoft.com/library/windows/desktop/ee419212) を呼び出して、ミュージックとサウンド効果のエンジンの [**IXAudio2**](https://msdn.microsoft.com/library/windows/desktop/ee415908) オブジェクトを初期化します。 これらのエンジンをインスタンス化した後、次に示すように、[**IXAudio2::CreateMasteringVoice**](https://msdn.microsoft.com/library/windows/desktop/hh405048) を呼び出して、各エンジンのマスターリング ボイスを作ります。

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

ミュージックまたはサウンド効果のオーディオ ファイルが読み込まれると、このメソッドはマスターリング ボイスの [**IXAudio2::CreateSourceVoice**](https://msdn.microsoft.com/library/windows/desktop/ee418607) を呼び出し、これによって再生用のソース ボイスのインスタンスが作られます。 このためのコードについては、ゲーム サンプルでオーディオ ファイルを読み込む方法を確認した後で説明します。

## <a name="reading-an-audio-file"></a>オーディオ ファイルの読み取り


このゲーム サンプルでは、オーディオ形式のファイルを読み取るコードは **MediaReader.cpp** に定義されています。 エンコードされた .wav オーディオ ファイル **MediaReader::LoadMedia** を読み取るメソッドは次のようになります。

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

このメソッドは、[メディア ファンデーション](https://msdn.microsoft.com/library/windows/desktop/ms694197) API を使って、.wav オーディオ ファイルをパルス符号変調 (PCM) バッファーとして読み取ります。

1.  [**MFCreateSourceReaderFromURL**](https://msdn.microsoft.com/library/windows/desktop/dd388110) を呼び出して、メディア ソース リーダー ([**IMFSourceReader**](https://msdn.microsoft.com/library/windows/desktop/dd374655)) オブジェクトを作ります。
2.  [**MFCreateMediaType**](https://msdn.microsoft.com/library/windows/desktop/ms693861) を呼び出して、オーディオ ファイルのデコードのメディアの種類 ([**IMFMediaType**](https://msdn.microsoft.com/library/windows/desktop/ms704850)) を作ります。 このメソッドは、デコードされた出力の種類として PCM オーディオを指定します。これは、XAudio2 が使うことができるオーディオの種類です。
3.  [**IMFSourceReader::SetCurrentMediaType**](https://msdn.microsoft.com/library/windows/desktop/bb970432) を呼び出して、リーダー用のデコードされた出力のメディアの種類を設定します。
4.  [**WAVEFORMATEX**](https://msdn.microsoft.com/library/windows/hardware/ff538799) バッファーを作り、[**IMFMediaType**](https://msdn.microsoft.com/library/windows/desktop/ms704850) オブジェクトの [**IMFMediaType::MFCreateWaveFormatExFromMFMediaType**](https://msdn.microsoft.com/library/windows/desktop/ms702177) を呼び出した結果をコピーします。 これで、読み込んだオーディオ ファイルを保持するバッファーがフォーマットされます。
5.  [**IMFSourceReader::GetPresentationAttribute**](https://msdn.microsoft.com/library/windows/desktop/dd374662) を呼び出して、オーディオ ストリームの期間を秒数で取得した後、その期間をバイト数に変換します。
6.  [**IMFSourceReader::ReadSample**](https://msdn.microsoft.com/library/windows/desktop/dd374665) を呼び出して、オーディオ ファイルをストリームとして読み取ります。
7.  このメソッドで返された配列に、オーディオ サンプル バッファーのコンテンツをコピーします。

**SoundEffect::Initialize** で最も重要なことは、ソース ボイス オブジェクト **m\_sourceVoice** をマスターリング ボイスから作ることです。 このソース ボイスは、**MediaReader::LoadMedia** から取得したサウンド データ バッファーの実際の再生に使います。

サンプル ゲームでは、次のように、**SoundEffect** オブジェクトを初期化するときにこのメソッドを呼び出します。

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

このメソッドには、次に示すように、**Audio::SoundEffectEngine** (または **Audio::MusicEngine**) と **MediaReader::GetOutputWaveFormatEx** を呼び出した結果と、**MediaReader::LoadMedia** を呼び出して返されたバッファーが渡されます。

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

**SoundEffect::Initialize** は、メイン ゲーム オブジェクトを初期化する **Simple3DGame:Initialize** メソッドから呼び出されます。

これで、サンプル ゲームのオーディオ ファイルがメモリに格納されたので、次は、ゲーム中にこのファイルが再生される方法を見てみましょう。

## <a name="playing-back-an-audio-file"></a>オーディオ ファイルの再生


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

サウンドを再生する際、このメソッドは、ソース ボイス オブジェクト **m\_sourceVoice** を使って、サウンド データ バッファー **m\_soundData** の再生を開始します。 そして、[**XAUDIO2\_BUFFER**](https://msdn.microsoft.com/library/windows/desktop/ee419228) を作り、これにサウンド データ バッファーへの参照を渡した後、[**IXAudio2SourceVoice::SubmitSourceBuffer**](https://msdn.microsoft.com/library/windows/desktop/ee418473) を呼び出してこれを送信します。 サウンド データがキューに入ると、**SoundEffect::PlaySound** は、[**IXAudio2SourceVoice::Start**](https://msdn.microsoft.com/library/windows/desktop/ee418471) を呼び出して再生を開始します。

これで、弾が標的に当たるたびに、**SoundEffect::PlaySound** が呼び出されて音が再生されます。

## <a name="next-steps"></a>次のステップ


これで、ユニバーサル Windows プラットフォーム (UWP) DirectX ゲーム開発のクイック ツアーは終了です。 今までの説明から、Windows 8 用に作成するゲームで快適なエクスペリエンスを実現するためには何をする必要があるかをご理解いただけたと思います。 作成するゲームは、さまざまな Windows 8 デバイスとプラットフォームで実行される可能性があるため、グラフィックス、コントロール、ユーザー インターフェイス、オーディオなどのコンポーネントは、できる限り幅広い構成に対応するように設計してください。

今までの説明で使ったゲーム サンプルを変更する方法について詳しくは、「[ゲーム サンプルの拡張](tutorial-resources.md)」をご覧ください。

## <a name="complete-sample-code-for-this-section"></a>このセクションのサンプル コード一式


Audio.h

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

Audio.cpp

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

SoundEffect.h

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

SoundEffect.cpp

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

 

 




