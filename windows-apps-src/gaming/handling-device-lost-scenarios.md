---
title: Direct3D 11 でのデバイス削除シナリオの処理
description: このトピックでは、グラフィックス アダプターが削除または再初期化されたときに Direct3D と DXGI デバイス インターフェイス チェーンを再作成する方法について説明します。
ms.assetid: 8f905acd-08f3-ff6f-85a5-aaa99acb389a
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, DirectX 11, デバイス喪失
ms.localizationpriority: medium
ms.openlocfilehash: c11bbf7657644fbf616590f50d75d93f62ed993e
ms.sourcegitcommit: 8921a9cc0dd3e5665345ae8eca7ab7aeb83ccc6f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8886676"
---
# <a name="span-iddevgaminghandlingdevice-lostscenariosspanhandle-device-removed-scenarios-in-direct3d-11"></a><span id="dev_gaming.handling_device-lost_scenarios"></span>Direct3D 11 でのデバイス削除シナリオの処理



このトピックでは、グラフィックス アダプターが削除または再初期化されたときに Direct3D と DXGI デバイス インターフェイス チェーンを再作成する方法について説明します。

DirectX 9 では、D3D デバイスが非動作状態になったときに、アプリケーションが "[デバイス喪失](https://msdn.microsoft.com/library/windows/desktop/bb174714)" 状態に見舞われることがあります。 たとえば、全画面 Direct3D 9 アプリケーションがフォーカスを失うと、Direct3D デバイスは "喪失" 状態になります。喪失したデバイスを使って描画しようとしても、エラー表示なしで失敗します。 Direct3D 11 では、仮想グラフィックス デバイス インターフェイスを使って、複数のプログラムが同一の物理グラフィックス デバイスを共有することができるため、アプリが Direct3D デバイスをコントロールできなくなることはなくなっています。 ただし、それでもグラフィックス アダプターが使用できなくなったり、逆に使用できるようになったりすることはありえます。 次に例を示します。

-   グラフィックス ドライバーがアップグレードされた場合。
-   システムのグラフィックス アダプターが省電力モードから性能重視モードに変わった場合。
-   グラフィックス デバイスが応答を停止してリセットされた場合。
-   グラフィックス アダプターが物理的に接続された場合、または取り外された場合。

このような状況になると、DXGI はエラー コードを返して、Direct3D デバイスの再起動とデバイス リソースの再作成が必要であることを知らせます。 このチュートリアルでは、グラフィックス アダプターのリセット、削除、変更という事態が生じた場合に、Direct3D 11 アプリとゲームがそれを検出して対応できるようにする方法について説明します。 Microsoft Visual Studio2015 付属の DirectX 11 アプリ (ユニバーサル Windows) テンプレートからのコード例を示します。

## <a name="instructions"></a>手順

### <a name="spanspanstep-1"></a><span></span>手順 1: 

レンダリング ループにデバイス削除エラーのチェックを加えます。 [**IDXGISwapChain::Present**](https://msdn.microsoft.com/library/windows/desktop/bb174576) (または [**Present1**](https://msdn.microsoft.com/library/windows/desktop/hh446797) など) を呼び出して、フレームを表示します。 次に、[**DXGI\_ERROR\_DEVICE\_REMOVED**](https://msdn.microsoft.com/library/windows/desktop/bb509553) または **DXGI\_ERROR\_DEVICE\_RESET** が返されたかどうかをチェックします。

まず、テンプレートは DXGI スワップ チェーンから返された HRESULT を保存します。

```cpp
HRESULT hr = m_swapChain->Present(1, 0);
```

その他のフレーム表示作業の面倒をすべてみた後、テンプレートはデバイス削除エラーをチェックします。 必要な場合は、デバイス削除状態を処理するメソッドを呼び出します。

```cpp
// If the device was removed either by a disconnection or a driver upgrade, we
// must recreate all device resources.
if (hr == DXGI_ERROR_DEVICE_REMOVED || hr == DXGI_ERROR_DEVICE_RESET)
{
    HandleDeviceLost();
}
else
{
    DX::ThrowIfFailed(hr);
}
```

### <a name="step-2"></a>手順 2:

また、ウィンドウ サイズの変更に対応する箇所にも、デバイス削除エラーのチェックを加えます。 これは、いくつかの理由から [**DXGI\_ERROR\_DEVICE\_REMOVED**](https://msdn.microsoft.com/library/windows/desktop/bb509553) または **DXGI\_ERROR\_DEVICE\_RESET** のチェックに適した場所です。

-   スワップ チェーンのサイズを変更するには、土台となる DXGI アダプターを呼び出す必要があり、その際にデバイス削除エラーが返される可能性があります。
-   異なるグラフィックス デバイスに接続されたモニターにアプリが移動された可能性があります。
-   グラフィックス デバイスが削除またはリセットされると、多くの場合、デスクトップの解像度が変わり、その結果ウィンドウ サイズが変わります。

テンプレートは、[**ResizeBuffers**](https://msdn.microsoft.com/library/windows/desktop/bb174577) から返された HRESULT を確認します。

```cpp
// If the swap chain already exists, resize it.
HRESULT hr = m_swapChain->ResizeBuffers(
    2, // Double-buffered swap chain.
    static_cast<UINT>(m_d3dRenderTargetSize.Width),
    static_cast<UINT>(m_d3dRenderTargetSize.Height),
    DXGI_FORMAT_B8G8R8A8_UNORM,
    0
    );

if (hr == DXGI_ERROR_DEVICE_REMOVED || hr == DXGI_ERROR_DEVICE_RESET)
{
    // If the device was removed for any reason, a new device and swap chain will need to be created.
    HandleDeviceLost();

    // Everything is set up now. Do not continue execution of this method. HandleDeviceLost will reenter this method 
    // and correctly set up the new device.
    return;
}
else
{
    DX::ThrowIfFailed(hr);
}
```

### <a name="step-3"></a>手順 3:

[**DXGI\_ERROR\_DEVICE\_REMOVED**](https://msdn.microsoft.com/library/windows/desktop/bb509553) エラーを受け取ったアプリは、常に Direct3D デバイスを再作成し、デバイス依存リソースを再初期化する必要があります。 以前の Direct3D デバイスを使って作成したグラフィックス デバイス リソースに対する参照はすべて解放します。このようなリソースは無効になっているため、スワップ チェーンに対する参照はすべて、新しいスワップ チェーンを作成する前に解放する必要があります。

HandleDeviceLost メソッドは、スワップ チェーンを解放し、アプリ コンポーネントに対してデバイス リソースを解放するよう通知します。

```cpp
m_swapChain = nullptr;

if (m_deviceNotify != nullptr)
{
    // Notify the renderers that device resources need to be released.
    // This ensures all references to the existing swap chain are released so that a new one can be created.
    m_deviceNotify->OnDeviceLost();
}
```

続いて、新しいスワップ チェーンを作成し、デバイス管理クラスによって制御されるデバイス依存リソースを再初期化します。

```cpp
// Create the new device and swap chain.
CreateDeviceResources();
m_d2dContext->SetDpi(m_dpi, m_dpi);
CreateWindowSizeDependentResources();
```

デバイスとスワップ チェーンが再確立された後、アプリ コンポーネントに対してデバイス依存リソースを再初期化するよう通知します。

```cpp
// Create the new device and swap chain.
CreateDeviceResources();
m_d2dContext->SetDpi(m_dpi, m_dpi);
CreateWindowSizeDependentResources();

if (m_deviceNotify != nullptr)
{
    // Notify the renderers that resources can now be created again.
    m_deviceNotify->OnDeviceRestored();
}
```

HandleDeviceLost メソッドが終了すると、制御はレンダリング ループに戻り、処理が続行されて次のフレームが描画されます。

## <a name="remarks"></a>注釈


### <a name="investigating-the-cause-of-device-removed-errors"></a>デバイス削除エラーの原因の調査

DXGI デバイス削除エラーが繰り返し発生する場合は、アプリケーションのグラフィックス コードが描画ルーチン内で無効な状態を作り出している可能性があります。 また、ハードウェア障害やグラフィックス ドライバーのバグが原因の可能性もあります。 デバイス削除エラーの原因を調査するには、Direct3D デバイスを解放する前に [**ID3D11Device::GetDeviceRemovedReason**](https://msdn.microsoft.com/library/windows/desktop/ff476526) を呼び出します。 このメソッドは、デバイス削除エラーの理由を示す 6 種類の DXGI エラー コードの 1 つを返します。

-   **DXGI\_ERROR\_DEVICE\_HUNG**: アプリが送信したグラフィックス コマンドの組み合わせが無効であったため、グラフィックス ドライバーが応答を停止しました。 このエラーが繰り返し発生する場合は、デバイスがハングする原因はアプリにあり、デバッグの必要があることを示している可能性が高くなります。
-   **DXGI\_ERROR\_DEVICE\_REMOVED**: グラフィックス デバイスが物理的に取り外されたか、電源が切られたか、ドライバーのアップグレードが発生しました。 このエラーはときどき起こることであり、異常ではありません。アプリまたはゲームは、このトピックで説明しているようにデバイス リソースを再作成する必要があります。
-   **DXGI\_ERROR\_DEVICE\_RESET**: コマンドの形式が無効であるためにグラフィックス デバイスが失敗しました。 このエラーが繰り返し発生する場合は、コードが無効な描画コマンドを送っている可能性があります。
-   **DXGI\_ERROR\_DRIVER\_INTERNAL\_ERROR**: グラフィックス ドライバーでエラーが発生して、デバイスをリセットしました。
-   **DXGI\_ERROR\_INVALID\_CALL**: アプリケーションが無効なパラメーター データを指定しました。 このエラーが 1 回でも発生する場合は、デバイス削除状態の原因がアプリのコードにあり、デバッグの必要があることを意味しています。
-   **S\_OK**: 現在のグラフィックス デバイスを無効にすることなく、グラフィックス デバイスの使用が許可または禁止されたり、リセットされたりしたときに返されます。 たとえば、このエラー コードは、アプリが [Windows Advanced Rasterization Platform (WARP)](https://msdn.microsoft.com/library/windows/desktop/gg615082) を使っていて、ハードウェア アダプターが利用可能になった場合に返されます。

次のコードは、[**DXGI\_ERROR\_DEVICE\_REMOVED**](https://msdn.microsoft.com/library/windows/desktop/bb509553) エラー コードを取得して、それをデバッグ コンソールに出力します。 次のコードを HandleDeviceLost メソッドの先頭に挿入します。

```cpp
    HRESULT reason = m_d3dDevice->GetDeviceRemovedReason();

#if defined(_DEBUG)
    wchar_t outString[100];
    size_t size = 100;
    swprintf_s(outString, size, L"Device removed! DXGI_ERROR code: 0x%X\n", reason);
    OutputDebugStringW(outString);
#endif
```

詳しくは、「[**GetDeviceRemovedReason**](https://msdn.microsoft.com/library/windows/desktop/ff476526)」および「[**DXGI\_ERROR**](https://msdn.microsoft.com/library/windows/desktop/bb509553)」をご覧ください。

### <a name="testing-device-removed-handling"></a>デバイスの削除完了処理のテスト

Visual Studio の開発者コマンド プロンプトでは、Visual Studio グラフィックス診断に関連する Direct3D イベントのキャプチャと再生を行うコマンド ライン ツール "dxcap" がサポートされます。 アプリの実行中はコマンド ライン オプション "-forcetdr" を使って、GPU タイムアウトの検出と回復イベントを強制できるため、DXGI\_ERROR\_DEVICE\_REMOVED がトリガーされ、エラー処理コードをテストできます。

> **注** DXCap とそのサポート DLL は、Windows 10 向けグラフィックス ツール (Windows SDK では配布されなくなりました) の一部として system32/syswow64 にインストールされます。 代わりに、オプションの OS コンポーネントであるオンデマンドのグラフィックス ツール機能を通じて提供され、Windows 10 でグラフィックス ツールを有効にして使うにはこれをインストールする必要があります。 Windows 10 向けグラフィックス ツールをインストールする方法について詳しくはここにあります。 <https://msdn.microsoft.com/library/mt125501.aspx#InstallGraphicsTools>
