---
xxxxx: Xxx xxxxx
xxxxxxxxxxx: Xx xxxx xxxx, xx xxxxxxx xxx xxx xxxxxxxx xxxx xxxxxx xxxxxxx xx xxxxxx xxx xxxxx xxxxxxxx xxxxx xxx XXxxxxY XXXx.
xx.xxxxxxx: xxYYxxxY-Yxxx-YxYx-YYYY-YYxYxYxxYYYY
---

# Xxx xxxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

Xx xxxx xxxx, xx xxxxxxx xxx xxx xxxxxxxx xxxx xxxxxx xxxxxxx xx xxxxxx xxx xxxxx xxxxxxxx xxxxx xxx [XXxxxxY](https://msdn.microsoft.com/library/windows/desktop/ee415813) XXXx.

## Xxxxxxxxx


-   Xx xxx xxxxx xxxxxx xxxxx [XXxxxxY](https://msdn.microsoft.com/library/windows/desktop/ee415813).

Xx xxx xxxx xxxxxx, xxx xxxxx xxxxxxx xxx xxxxxxxxx xxx xxxxxxx xx xxxxx xxxxx:

-   **Xxxxx.x/.xxx**. Xxxx xxxx xxxx xxxxxxx xxx **Xxxxx** xxxxxx, xxxxx xxxxxxxx xxx XXxxxxY xxxxxxxxx xxx xxxxx xxxxxxxx. Xx xxxx xxxxxxx xxx xxxxxx xxx xxxxxxxxxx xxx xxxxxxxx xxxxx xxxxxxxx xx xxx xxxx xx xxxxxx xx xxxxxxxxxxx.
-   **XxxxxXxxxxx.x/.xxx**. Xxxx xxxx xxxxxxx xxx xxxxxxx xxx xxxxxxx xxxxx .xxx xxxxx xxxx xxxxx xxxxxxx.
-   **XxxxxXxxxxx.x/.xxx**. Xxxx xxxx xxxxxxx xx xxxxxx xxx xx-xxxx xxxxx xxxxxxxx.

## Xxxxxxxx xxx xxxxx xxxxxx


Xxxx xxx xxxx xxxxxx xxxxxx, xx xxxxxxx xx **Xxxxx** xxxxxx xxxx xxxxxxxxx xxx xxxxx xxxxxxxxx xxx xxx xxxx. Xxx xxxx xxxx xxxxxxxx xxxx xxxxxx xxxxx xxxx xxxx:

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

Xxx **Xxxxx::XxxxxXxxxxx** xxx **Xxxxx::XxxxxXxxxxxXxxxxx** xxxxxxx xxxxxx xxxxxxxxxx xx [**XXXxxxxY**](https://msdn.microsoft.com/library/windows/desktop/ee415908) xxxxxxx xxxx xxxxxx xxx xxxxxxxxx xxxxx xxx xxxx xxxxx xxxx. X xxxxxxxxx xxxxx xx xxx xxxxx xxxxxx xxxx xxx xxxxxxxx. Xxxxx xxxx xxxxxxx xxxxxx xx xxxxxxxxx xxxxxxxx xx xxxxxxxxx xxxxxx, xxx xxxx xxxxxxxxx xx xxxxx xxxxx xx xxxxxx xxxx xx xxxxxxxx xx x xxxxxxxxx xxxxx xx xx xxxxx.

## Xxxxxxxxxxxx xxx xxxxx xxxxxxxxx


Xxx xxxxxx xxxxxxxxxxx xxx [**XXXxxxxY**](https://msdn.microsoft.com/library/windows/desktop/ee415908) xxxxxxx xxx xxx xxxxx xxx xxxxx xxxxxx xxxxxxx xxxx xxxxx xx [**XXxxxxYXxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ee419212). Xxxxx xxx xxxxxxx xxxx xxxx xxxxxxxxxxxx, xx xxxxxxx x xxxxxxxxx xxxxx xxx xxxx xxxx xxxxx xx [**XXXxxxxY::XxxxxxXxxxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/desktop/hh405048), xx xxxx:

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

Xx x xxxxx xx xxxxx xxxxxx xxxxx xxxx xx xxxxxx, xxxx xxxxxx xxxxx [**XXXxxxxY::XxxxxxXxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/desktop/ee418607) xx xxx xxxxxxxxx xxxxx, xxxxx xxxxxxx xx xxxxxxxx xx x xxxxxx xxxxx xxx xxxxxxxx. Xx xxxx xx xxx xxxx xxx xxxx xx xxxx xx xx xxxxxx xxxxxxxxx xxx xxx xxxx xxxxxx xxxxx xxxxx xxxxx.

## Xxxxxxx xx xxxxx xxxx


Xx xxx xxxx xxxxxx, xxx xxxx xxx xxxxxxx xxxxx xxxxxx xxxxx xx xxxxxxx xx **XxxxxXxxxxx.xxx**. Xxx xxxxxxxx xxxxxx xxxx xxxxx xx xx xxxxxxx .xxx xxxxx xxxx, **XxxxxXxxxxx::XxxxXxxxx**, xxxxx xxxx xxxx:

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

Xxxx xxxxxx xxxx xxx [Xxxxx Xxxxxxxxxx](https://msdn.microsoft.com/library/windows/desktop/ms694197) XXXx xx xxxx xx xxx .xxx xxxxx xxxx xx x Xxxxx Xxxx Xxxxxxxxxx (XXX) xxxxxx.

1.  Xxxxxxx x xxxxx xxxxxx xxxxxx ([**XXXXxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/desktop/dd374655)) xxxxxx xx xxxxxxx [**XXXxxxxxXxxxxxXxxxxxXxxxXXX**](https://msdn.microsoft.com/library/windows/desktop/dd388110).
2.  Xxxxxxx x xxxxx xxxx ([**XXXXxxxxXxxx**](https://msdn.microsoft.com/library/windows/desktop/ms704850)) xxx xxx xxxxxxxx xx xxx xxxxx xxxx xx xxxxxxx [**XXXxxxxxXxxxxXxxx**](https://msdn.microsoft.com/library/windows/desktop/ms693861). Xxxx xxxxxx xxxxxxxxx xxxx xxx xxxxxxx xxxxxx xx XXX xxxxx, xxxxx xx xx xxxxx xxxx xxxx XXxxxxY xxx xxx.
3.  Xxxx xxx xxxxxxx xxxxxx xxxxx xxxx xxx xxx xxxxxx xx xxxxxxx [**XXXXxxxxxXxxxxx::XxxXxxxxxxXxxxxXxxx**](https://msdn.microsoft.com/library/windows/desktop/bb970432).
4.  Xxxxxxx x [**XXXXXXXXXXXX**](https://msdn.microsoft.com/library/windows/hardware/ff538799) xxxxxx xxx xxxxxx xxx xxxxxxx xx x xxxx xx [**XXXXxxxxXxxx::XXXxxxxxXxxxXxxxxxXxXxxxXXXxxxxXxxx**](https://msdn.microsoft.com/library/windows/desktop/ms702177) xx xxx [**XXXXxxxxXxxx**](https://msdn.microsoft.com/library/windows/desktop/ms704850) xxxxxx. Xxxx xxxxxxx xxx xxxxxx xxxx xxxxx xxx xxxxx xxxx xxxxx xx xx xxxxxx.
5.  Xxxx xxx xxxxxxxx, xx xxxxxxx, xx xxx xxxxx xxxxxx xx xxxxxxx [**XXXXxxxxxXxxxxx::XxxXxxxxxxxxxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/desktop/dd374662) xxx xxxx xxxxxxxx xxx xxxxxxxx xx xxxxx.
6.  Xxxxx xxx xxxxx xxxx xx xx x xxxxxx xx xxxxxxx [**XXXXxxxxxXxxxxx::XxxxXxxxxx**](https://msdn.microsoft.com/library/windows/desktop/dd374665).
7.  Xxxxxx xxx xxxxxxxx xx xxx xxxxx xxxxxx xxxxxx xxxx xx xxxxx xxxxxxxx xx xxx xxxxxx.

Xxx xxxx xxxxxxxxx xxxxx xx **XxxxxXxxxxx::Xxxxxxxxxx** xx xxx xxxxxxxx xx xxx xxxxxx xxxxx xxxxxx, **x\_xxxxxxXxxxx**, xxxx xxx xxxxxxxxx xxxxx. Xx xxx xxx xxxxxx xxxxx xxx xxx xxxxxx xxxx xxxx xx xxx xxxxx xxxx xxxxxx xxxxxxxx xxxx **XxxxxXxxxxx::XxxxXxxxx**.

Xxx xxxxxx xxxx xxxxx xxxx xxxxxx xxxx xx xxxxxxxxxxx xxx **XxxxxXxxxxx** xxxxxx, xxxx xxxx:

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

Xxxx xxxxxx xx xxxxxx xxx xxxxxxx xx xxxxx xx **Xxxxx::XxxxxXxxxxxXxxxxx** (xx **Xxxxx::XxxxxXxxxxx**), **XxxxxXxxxxx::XxxXxxxxxXxxxXxxxxxXx**, xxx xxx xxxxxx xxxxxxxx xx x xxxx xx **XxxxxXxxxxx::XxxxXxxxx**, xx xxxx xxxx.

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

**XxxxxXxxxxx::Xxxxxxxxxx** xx xxxxxx xxxx xxx **XxxxxxYXXxxx:Xxxxxxxxxx** xxxxxx xxxx xxxxxxxxxxx xxx xxxx xxxx xxxxxx.

Xxx xxxx xxx xxxxxx xxxx xxx xx xxxxx xxxx xx xxxxxx, xxx'x xxx xxx xx xxxxx xx xxxx xxxxxx xxxx xxxx!

## Xxxxxxx xxxx xx xxxxx xxxx


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

Xx xxxx xxx xxxxx, xxxx xxxxxx xxxx xxx xxxxxx xxxxx xxxxxx **x\_xxxxxxXxxxx** xx xxxxx xxx xxxxxxxx xx xxx xxxxx xxxx xxxxxx **x\_xxxxxXxxx**. Xx xxxxxxx xx [**XXXXXXY\_XXXXXX**](https://msdn.microsoft.com/library/windows/desktop/ee419228), xx xxxxx xx xxxxxxxx x xxxxxxxxx xx xxx xxxxx xxxx xxxxxx, xxx xxxx xxxxxxx xx xxxx x xxxx xx [**XXXxxxxYXxxxxxXxxxx::XxxxxxXxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ee418473). Xxxx xxx xxxxx xxxx xxxxxx xx, **XxxxxXxxxxx::XxxxXxxxx** xxxxxx xxxx xxxx xx xxxxxxx [**XXXxxxxYXxxxxxXxxxx::Xxxxx**](https://msdn.microsoft.com/library/windows/desktop/ee418471).

Xxx, xxxxxxxx x xxxxxxxxx xxxxxxx xxx xxxx xxx x xxxxxx xxxxxx, x xxxx xx **XxxxxXxxxxx::XxxxXxxxx** xxxxxx x xxxxx xx xxxx.

## Xxxx xxxxx


Xxxx xxx x xxxxxxxxx xxxx xx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) XxxxxxX xxxx xxxxxxxxxxx! Xx xxxx xxxxx, xxx xxxx xx xxxx xx xxxx xxx xxxx xx xx xx xxxx xxxx xxx xxxx xxx Xxxxxxx Y x xxxxx xxxxxxxxxx. Xxxxxxxx, xxxx xxxx xxx xx xxxxxx xx x xxxx xxxxxxx xx Xxxxxxx Y xxxxxxx xxx xxxxxxxxx, xx xxxxxx xxxx xxxxxxxxxx: xxxx xxxxxxxx, xxxx xxxxxxxx, xxxx xxxx xxxxxxxxx, xxx xxxx xxxxx xxx xx xxxx x xxx xx xxxxxxxxxxxxxx xx xxx xxx!

Xxx xxxx xxxx xxxxx xxxx xx xxxxxx xxx xxxx xxxxxx xxxxxxxx xx xxxxx xxxxxxxxx, xxx [Xxxxxxxxx xxx xxxx xxxxxx](tutorial-resources.md).

## Xxxxxxxx xxxxxx xxxx xxx xxxx xxxxxxx


Xxxxx.x

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

Xxxxx.xxx

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

XxxxxXxxxxx.x

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

XxxxxXxxxxx.xxx

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

 

 




<!--HONumber=Mar16_HO1-->
