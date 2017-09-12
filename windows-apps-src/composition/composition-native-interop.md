---
author: jwmsft
ms.assetid: 16ad97eb-23f1-0264-23a9-a1791b4a5b95
title: "コンポジションのネイティブ相互運用"
description: "Windows.UI.Composition API には、コンテンツをコンポジターに直接移行できるようにするネイティブの相互運用インターフェイスが用意されています。"
ms.author: jimwalk
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: 96af2b92ec301a93cbae9eb14422af9e1ec8554c
ms.sourcegitcommit: b42d14c775efbf449a544ddb881abd1c65c1ee86
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/20/2017
---
# <a name="composition-native-interoperation-with-directx-and-direct2d"></a><span data-ttu-id="e0ef6-104">コンポジションでの DirectX と Direct2D のネイティブ相互運用</span><span class="sxs-lookup"><span data-stu-id="e0ef6-104">Composition native interoperation with DirectX and Direct2D</span></span>

<span data-ttu-id="e0ef6-105">Windows.UI.Composition API には、コンテンツをコンポジターに直接移行できるようにするネイティブの相互運用インターフェイス、[**ICompositorInterop**](https://msdn.microsoft.com/library/windows/apps/Mt620068)、[**ICompositionDrawingSurfaceInterop**](https://msdn.microsoft.com/library/windows/apps/Mt620058)、[**ICompositionGraphicsDeviceInterop**](https://msdn.microsoft.com/library/windows/apps/Mt620065) が用意されています。</span><span class="sxs-lookup"><span data-stu-id="e0ef6-105">The Windows.UI.Composition API provides the [**ICompositorInterop**](https://msdn.microsoft.com/library/windows/apps/Mt620068), [**ICompositionDrawingSurfaceInterop**](https://msdn.microsoft.com/library/windows/apps/Mt620058), and [**ICompositionGraphicsDeviceInterop**](https://msdn.microsoft.com/library/windows/apps/Mt620065) native interoperation interfaces allowing content to be moved directly into the compositor.</span></span>

<span data-ttu-id="e0ef6-106">ネイティブ相互運用は、DirectX テクスチャに対応するサーフェス オブジェクトを中心に構成されています。</span><span class="sxs-lookup"><span data-stu-id="e0ef6-106">Native interoperation is structured around surface objects that are backed by DirectX textures.</span></span> <span data-ttu-id="e0ef6-107">サーフェスは [**CompositionGraphicsDevice**](https://msdn.microsoft.com/library/windows/apps/Dn706749) というファクトリ オブジェクトから作成されます。</span><span class="sxs-lookup"><span data-stu-id="e0ef6-107">The surfaces are created from a factory object called [**CompositionGraphicsDevice**](https://msdn.microsoft.com/library/windows/apps/Dn706749).</span></span> <span data-ttu-id="e0ef6-108">このオブジェクトは、サーフェスへのビデオ メモリの割り当てに使う Direct2D または Direct3D デバイス オブジェクトに対応します。</span><span class="sxs-lookup"><span data-stu-id="e0ef6-108">This object is backed by an underlying Direct2D or Direct3D device object, which it uses to allocate video memory for surfaces.</span></span> <span data-ttu-id="e0ef6-109">コンポジション API により DirectX デバイスが作成されることはありません。</span><span class="sxs-lookup"><span data-stu-id="e0ef6-109">The composition API never creates the underlying DirectX device.</span></span> <span data-ttu-id="e0ef6-110">このオブジェクトを作成して **CompositionGraphicsDevice** オブジェクトに渡すのは、アプリケーションの担当です。</span><span class="sxs-lookup"><span data-stu-id="e0ef6-110">It is the responsibility of the application to create one and pass it to the **CompositionGraphicsDevice** object.</span></span> <span data-ttu-id="e0ef6-111">アプリケーションは一度に複数の **CompositionGraphicsDevice** オブジェクトを作成できます。複数の **CompositionGraphicsDevice** オブジェクトにレンダリング デバイスと同じ DirectX デバイスを使ってもかまいません。</span><span class="sxs-lookup"><span data-stu-id="e0ef6-111">An application may create more than one **CompositionGraphicsDevice** object at a time, and it may use the same DirectX device as the rendering device for multiple **CompositionGraphicsDevice** objects.</span></span>

## <a name="creating-a-surface"></a><span data-ttu-id="e0ef6-112">サーフェスの作成</span><span class="sxs-lookup"><span data-stu-id="e0ef6-112">Creating a surface</span></span>

<span data-ttu-id="e0ef6-113">各 [**CompositionGraphicsDevice**](https://msdn.microsoft.com/library/windows/apps/Dn706749) はサーフェスのファクトリとして機能します。</span><span class="sxs-lookup"><span data-stu-id="e0ef6-113">Each [**CompositionGraphicsDevice**](https://msdn.microsoft.com/library/windows/apps/Dn706749) serves as a surface factory.</span></span> <span data-ttu-id="e0ef6-114">各サーフェスは初期サイズ (0,0 の場合もあり) で作成されますが、有効ピクセル数はありません。</span><span class="sxs-lookup"><span data-stu-id="e0ef6-114">Each surface is created with an initial size (which may be 0,0), but no valid pixels.</span></span> <span data-ttu-id="e0ef6-115">その初期状態のサーフェスはすぐに、ビジュアル オブジェクト ツリーで、たとえば [**CompositionSurfaceBrush**](https://msdn.microsoft.com/library/windows/apps/Mt589415) と [**SpriteVisual**](https://msdn.microsoft.com/library/windows/apps/Mt589433) によって使えますが、その初期状態のサーフェスは画面出力に影響を与えません。</span><span class="sxs-lookup"><span data-stu-id="e0ef6-115">A surface in its initial state may be immediately consumed in a visual tree, for example, via a [**CompositionSurfaceBrush**](https://msdn.microsoft.com/library/windows/apps/Mt589415) and a [**SpriteVisual**](https://msdn.microsoft.com/library/windows/apps/Mt589433), but in its initial state the surface has no effect on screen output.</span></span> <span data-ttu-id="e0ef6-116">このサーフェスは、指定したアルファ モードが "不透明" であったとしても、すべての用途で完全に透明です。</span><span class="sxs-lookup"><span data-stu-id="e0ef6-116">It is, for all purposes, entirely transparent, even if the specified alpha mode is “opaque”.</span></span>

<span data-ttu-id="e0ef6-117">場合によっては、DirectX デバイスが使えなくなっています。</span><span class="sxs-lookup"><span data-stu-id="e0ef6-117">Occasionally, DirectX devices may be rendered unusable.</span></span> <span data-ttu-id="e0ef6-118">この状態になるのは、特に、アプリケーションから特定の DirectX API に無効な引数が渡された場合、グラフィック アダプターがシステムによってリセットされた場合、またはドライバーが更新された場合です。</span><span class="sxs-lookup"><span data-stu-id="e0ef6-118">This may happen, amongst other reasons, if the application passes invalid arguments to certain DirectX APIs, or if the graphics adapter is reset by the system, or if the driver is updated.</span></span> <span data-ttu-id="e0ef6-119">Direct3D には、非同期的にデバイスが何らかの理由で失われているかどうかの検出に、アプリケーションが使える API があります。</span><span class="sxs-lookup"><span data-stu-id="e0ef6-119">Direct3D has an API that an application may use to discover, asynchronously, if the device is lost for any reason.</span></span> <span data-ttu-id="e0ef6-120">DirectX デバイスが失われている場合、アプリケーションはそのデバイスを破棄した後、新しいデバイスを作成し、問題のある DirectX デバイスに関連付けられていた [**CompositionGraphicsDevice**](https://msdn.microsoft.com/library/windows/apps/Dn706749) オブジェクトすべてに渡す必要があります。</span><span class="sxs-lookup"><span data-stu-id="e0ef6-120">When a DirectX device is lost, the application must discard it, create a new one, and pass it to any [**CompositionGraphicsDevice**](https://msdn.microsoft.com/library/windows/apps/Dn706749) objects previously associated with the bad DirectX device.</span></span>

## <a name="loading-pixels-into-a-surface"></a><span data-ttu-id="e0ef6-121">サーフェスへのピクセルの読み込み</span><span class="sxs-lookup"><span data-stu-id="e0ef6-121">Loading pixels into a surface</span></span>

<span data-ttu-id="e0ef6-122">サーフェスにピクセルを読み込むために、アプリケーションは [**BeginDraw**](https://msdn.microsoft.com/library/windows/apps/mt620059.aspx) メソッドを呼び出す必要があります。このメソッドが、アプリケーションの要求に応じて、テクスチャや Direct2D のコンテキストを表す DirectX インターフェイスを返します。</span><span class="sxs-lookup"><span data-stu-id="e0ef6-122">To load pixels into the surface, the application must call the [**BeginDraw**](https://msdn.microsoft.com/library/windows/apps/mt620059.aspx) method, which returns a DirectX interface representing a texture or Direct2D context, depending on what the application requests.</span></span> <span data-ttu-id="e0ef6-123">アプリケーションはそのテクスチャにピクセルをレンダリングまたはアップロードする必要があります。</span><span class="sxs-lookup"><span data-stu-id="e0ef6-123">The application must then render or upload pixels into that texture.</span></span> <span data-ttu-id="e0ef6-124">その操作が終了したら、アプリケーションは [**EndDraw**](https://msdn.microsoft.com/library/windows/apps/mt620060) メソッドを呼び出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="e0ef6-124">When the application is done, it must call the [**EndDraw**](https://msdn.microsoft.com/library/windows/apps/mt620060) method.</span></span> <span data-ttu-id="e0ef6-125">その時点でのみ新しいピクセルはコンポジションに使えますが、次にビジュアル オブジェクト ツリーへのすべての変更がコミットされるまで、まだ画面には表示されません。</span><span class="sxs-lookup"><span data-stu-id="e0ef6-125">Only at that point are the new pixels available for composition, but they still don't show up on screen until the next time all changes to the visual tree are committed.</span></span> <span data-ttu-id="e0ef6-126">**EndDraw** が呼び出される前に、ビジュアル オブジェクト ツリーがコミットされた場合、進行中の更新は画面に表示されず、サーフェスには引き続き **BeginDraw** の前の内容が表示されます。</span><span class="sxs-lookup"><span data-stu-id="e0ef6-126">If the visual tree is committed before **EndDraw** is called, then the update that is in progress is not visible on screen and the surface continues to display the contents it had prior to **BeginDraw**.</span></span> <span data-ttu-id="e0ef6-127">**EndDraw** が呼び出されると、BeginDraw によって返されたテクスチャや Direct2D コンテキスト ポインターは無効化されます。</span><span class="sxs-lookup"><span data-stu-id="e0ef6-127">When **EndDraw** is called, the texture or Direct2D context pointer returned by BeginDraw is invalidated.</span></span> <span data-ttu-id="e0ef6-128">アプリケーションは **EndDraw** の呼び出し後にそのポインターをキャッシュすることはありません。</span><span class="sxs-lookup"><span data-stu-id="e0ef6-128">An application should never cache that pointer beyond the **EndDraw** call.</span></span>

<span data-ttu-id="e0ef6-129">アプリケーションは、どの [**CompositionGraphicsDevice**](https://msdn.microsoft.com/library/windows/apps/Dn706749) に対しても、一度に 1 つのサーフェスでのみ BeginDraw を呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="e0ef6-129">The application may only call BeginDraw on one surface at a time, for any given [**CompositionGraphicsDevice**](https://msdn.microsoft.com/library/windows/apps/Dn706749).</span></span> <span data-ttu-id="e0ef6-130">[**BeginDraw**](https://msdn.microsoft.com/library/windows/apps/mt620059.aspx) を呼び出した後、アプリケーションはそのサーフェスで [**EndDraw**](https://msdn.microsoft.com/library/windows/apps/mt620060) を呼び出してから、別のサーフェスで **BeginDraw** を呼び出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="e0ef6-130">After calling [**BeginDraw**](https://msdn.microsoft.com/library/windows/apps/mt620059.aspx), the application must call [**EndDraw**](https://msdn.microsoft.com/library/windows/apps/mt620060) on that surface before calling **BeginDraw** on another.</span></span> <span data-ttu-id="e0ef6-131">API がアジャイルであるため、アプリケーションは、複数のワーカー スレッドからレンダリングを実行する場合、これらの呼び出しの同期を担当します。</span><span class="sxs-lookup"><span data-stu-id="e0ef6-131">As the API is agile, the application is responsible for synchronizing these calls if it wishes to perform rendering from multiple worker threads.</span></span> <span data-ttu-id="e0ef6-132">アプリケーションが一時的にあるサーフェスのレンダリングを中断し、別のサーフェスに切り替える場合、アプリケーションは [**SuspendDraw**](https://msdn.microsoft.com/library/windows/apps/mt620064.aspx) メソッドを使えます。</span><span class="sxs-lookup"><span data-stu-id="e0ef6-132">If an application wants to interrupt rendering one surface and switch to another temporarily, the application may use the [**SuspendDraw**](https://msdn.microsoft.com/library/windows/apps/mt620064.aspx) method.</span></span> <span data-ttu-id="e0ef6-133">これにより、別の **BeginDraw** は成功しますが、画面上のコンポジションに対する最初のサーフェスの更新はできなくなります。</span><span class="sxs-lookup"><span data-stu-id="e0ef6-133">This allows another **BeginDraw** to succeed, but does not make the first surface update available for on-screen composition.</span></span> <span data-ttu-id="e0ef6-134">これにより、アプリケーションはトランザクション方式で複数の更新を行えます。</span><span class="sxs-lookup"><span data-stu-id="e0ef6-134">This allows the application to perform multiple updates in a transactional manner.</span></span> <span data-ttu-id="e0ef6-135">サーフェスが中断されたら、アプリケーションは [**ResumeDraw**](https://msdn.microsoft.com/library/windows/apps/mt620062) メソッドを呼び出して更新を続けるか、**EndDraw** を呼び出して更新の終了を宣言できます。</span><span class="sxs-lookup"><span data-stu-id="e0ef6-135">Once a surface is suspended, the application may continue the update by calling the [**ResumeDraw**](https://msdn.microsoft.com/library/windows/apps/mt620062) method, or it may declare that the update is done by calling **EndDraw**.</span></span> <span data-ttu-id="e0ef6-136">つまり、どの **CompositionGraphicsDevice** に対しても、一度に 1 つのサーフェスのみをアクティブに更新できます。</span><span class="sxs-lookup"><span data-stu-id="e0ef6-136">This means only one surface can be actively updated at a time for any given **CompositionGraphicsDevice**.</span></span> <span data-ttu-id="e0ef6-137">各グラフィックス デバイスはそれぞれ独立してこの状態を保つため、2 つのサーフェスが異なるグラフィックス デバイスに属していれば、アプリケーションはそれらのサーフェスに同時にレンダリングできます。</span><span class="sxs-lookup"><span data-stu-id="e0ef6-137">Each graphics device keeps this state independently of the others, so an application may render to two surfaces simultaneously if they belong to different graphics devices.</span></span> <span data-ttu-id="e0ef6-138">ただしその結果、これらの 2 つのサーフェス用のビデオ メモリが一緒にプールされなくなるため、メモリの使用効率は下がります。</span><span class="sxs-lookup"><span data-stu-id="e0ef6-138">However, this precludes the video memory for those two surfaces from being pooled together and, as such, is less memory efficient.</span></span>

<span data-ttu-id="e0ef6-139">アプリケーションが間違った操作を実行した場合、[**BeginDraw**](https://msdn.microsoft.com/library/windows/apps/mt620059.aspx)、[**SuspendDraw**](https://msdn.microsoft.com/library/windows/apps/mt620064.aspx)、[**ResumeDraw**](https://msdn.microsoft.com/library/windows/apps/mt620062)、[**EndDraw**](https://msdn.microsoft.com/library/windows/apps/mt620060) の各メソッドはエラーを返します (無効な引数を渡した場合や、あるサーフェスで **EndDraw** を呼び出す前に、別のサーフェスで **BeginDraw** を呼び出した場合など)。</span><span class="sxs-lookup"><span data-stu-id="e0ef6-139">The [**BeginDraw**](https://msdn.microsoft.com/library/windows/apps/mt620059.aspx), [**SuspendDraw**](https://msdn.microsoft.com/library/windows/apps/mt620064.aspx), [**ResumeDraw**](https://msdn.microsoft.com/library/windows/apps/mt620062) and [**EndDraw**](https://msdn.microsoft.com/library/windows/apps/mt620060) methods return failures if the application performs an incorrect operation (such as passing invalid arguments, or calling **BeginDraw** on a surface before calling **EndDraw** on another).</span></span> <span data-ttu-id="e0ef6-140">この種のエラーはアプリケーションのバグを表します。たとえば "fail fast" を使って処理される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="e0ef6-140">These types of failures represent application bugs and, as such, the expectation is that they are handled with a fail fast.</span></span> <span data-ttu-id="e0ef6-141">DirectX デバイスが失われた場合も、**BeginDraw** はエラーを返すことがあります。</span><span class="sxs-lookup"><span data-stu-id="e0ef6-141">**BeginDraw** may also return a failure if the underlying DirectX device is lost.</span></span> <span data-ttu-id="e0ef6-142">アプリケーションが DirectX デバイスを再作成して再試行できるため、このエラーは致命的ではありません。</span><span class="sxs-lookup"><span data-stu-id="e0ef6-142">This failure is not fatal as the application can recreate its DirectX device and try again.</span></span> <span data-ttu-id="e0ef6-143">このように、アプリケーションでは単にレンダリングをスキップすることで、デバイスが失われた場合に対処する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e0ef6-143">As such, the application is expected to handle device loss by simply skipping rendering.</span></span> <span data-ttu-id="e0ef6-144">**BeginDraw** が失敗した場合、それがどのような理由であっても、アプリケーションが **EndDraw** を呼び出さないようにしてください。最初の時点で失敗した描画開始が成功することはないためです。</span><span class="sxs-lookup"><span data-stu-id="e0ef6-144">If **BeginDraw** fails for any reason, the application should also not call **EndDraw**, as the begin never succeeded in the first place.</span></span>

## <a name="scrolling"></a><span data-ttu-id="e0ef6-145">スクロール</span><span class="sxs-lookup"><span data-stu-id="e0ef6-145">Scrolling</span></span>

<span data-ttu-id="e0ef6-146">パフォーマンス上の理由から、アプリケーションが [**BeginDraw**](https://msdn.microsoft.com/library/windows/apps/mt620059.aspx) を呼び出すとき、返されるテクスチャの内容がサーフェスの前の内容であるとは限りません。</span><span class="sxs-lookup"><span data-stu-id="e0ef6-146">For performance reasons, when an application calls [**BeginDraw**](https://msdn.microsoft.com/library/windows/apps/mt620059.aspx) the contents of the returned texture are not guaranteed to be the previous contents of the surface.</span></span> <span data-ttu-id="e0ef6-147">アプリケーションでは、内容がランダムであることを想定して、確実にすべてのピクセルがタッチされるようにする必要があります。そのためには、レンダリング前にサーフェスをクリアするか、更新された四角形全体を十分に埋められる不透明なコンテンツを描画します。</span><span class="sxs-lookup"><span data-stu-id="e0ef6-147">The application must assume that the contents are random and, as such, the application must ensure that all pixels are touched, either by clearing the surface before rendering or by drawing enough opaque contents to cover the entire updated rectangle.</span></span> <span data-ttu-id="e0ef6-148">また、テクスチャ ポインターが **BeginDraw** と [**EndDraw**](https://msdn.microsoft.com/library/windows/apps/mt620060) の呼び出し間でのみ有効であることも相まって、アプリケーションはサーフェスから前の内容をコピーできません。</span><span class="sxs-lookup"><span data-stu-id="e0ef6-148">This, combined with the fact that the texture pointer is only valid between **BeginDraw** and [**EndDraw**](https://msdn.microsoft.com/library/windows/apps/mt620060) calls, makes it impossible for the application to copy previous contents out of the surface.</span></span> <span data-ttu-id="e0ef6-149">この理由から、[**Scroll**](https://msdn.microsoft.com/library/windows/apps/mt620063) メソッドが用意されています。このメソッドを使うと、アプリケーションは同じサーフェスでピクセルをコピーできるようになります。</span><span class="sxs-lookup"><span data-stu-id="e0ef6-149">For this reason, we offer a [**Scroll**](https://msdn.microsoft.com/library/windows/apps/mt620063) method, which allows the application to perform a same-surface pixel copy.</span></span>

## <a name="usage-example"></a><span data-ttu-id="e0ef6-150">使用例</span><span class="sxs-lookup"><span data-stu-id="e0ef6-150">Usage Example</span></span>

<span data-ttu-id="e0ef6-151">次のサンプルでは、アプリケーションが描画サーフェスを作成する簡単なシナリオを示しており、[**BeginDraw**](https://msdn.microsoft.com/library/windows/apps/mt620059.aspx) と [**EndDraw**](https://msdn.microsoft.com/library/windows/apps/mt620060) を使ってサーフェスにテキストを読み込みます。</span><span class="sxs-lookup"><span data-stu-id="e0ef6-151">The following sample illustrates a very simple scenario where an application creates drawing surfaces, and uses [**BeginDraw**](https://msdn.microsoft.com/library/windows/apps/mt620059.aspx) and [**EndDraw**](https://msdn.microsoft.com/library/windows/apps/mt620060) to populate the surfaces with text.</span></span> <span data-ttu-id="e0ef6-152">アプリケーションは次のように、テキストを DirectWrite を使ってレイアウトし、Direct2D を使ってレンダリングします。</span><span class="sxs-lookup"><span data-stu-id="e0ef6-152">The application uses DirectWrite to layout the text (details not shown) and then uses Direct2D to render it.</span></span> <span data-ttu-id="e0ef6-153">コンポジション グラフィックス デバイスは初期化時に直接 Direct2D デバイスを受け取ります。</span><span class="sxs-lookup"><span data-stu-id="e0ef6-153">The composition graphics device accepts the Direct2D device directly at initialization time.</span></span> <span data-ttu-id="e0ef6-154">これにより、**BeginDraw** は ID2D1DeviceContext インターフェイス ポインターを返すことができます。この方法は、アプリケーションが Direct2D コンテキストを作成して、返される ID3D11Texture2D インターフェイスを各描画操作でラップするよりも、かなり効率的です。</span><span class="sxs-lookup"><span data-stu-id="e0ef6-154">This allows **BeginDraw** to return an ID2D1DeviceContext interface pointer, which is considerably more efficient than having the application create a Direct2D context to wrap a returned ID3D11Texture2D interface at each drawing operation.</span></span>

```cpp
//------------------------------------------------------------------------------
//
// Copyright (C) Microsoft. All rights reserved.
//
//------------------------------------------------------------------------------

#include "stdafx.h"

using namespace Microsoft::WRL;
using namespace Windows::Foundation;
using namespace Windows::Graphics::DirectX;
using namespace Windows::UI::Composition;

// This is an app-provided helper to render lines of text
class SampleText
{
private:
    // The text to draw
    ComPtr<IDWriteTextLayout> _text;

    // The composition surface that we use in the visual tree
    ComPtr<ICompositionDrawingSurfaceInterop> _drawingSurfaceInterop;

    // The device that owns the surface
    ComPtr<ICompositionGraphicsDevice> _compositionGraphicsDevice;

    // For managing our event notifier
    EventRegistrationToken _deviceReplacedEventToken;

public:
    SampleText(IDWriteTextLayout* text, ICompositionGraphicsDevice* compositionGraphicsDevice) :
        _text(text),
        _compositionGraphicsDevice(compositionGraphicsDevice)
    {
        // Create the surface just big enough to hold the formatted text block.
        DWRITE_TEXT_METRICS metrics;
        FailFastOnFailure(text->GetMetrics(&metrics));
        Windows::Foundation::Size surfaceSize = { metrics.width, metrics.height };
        ComPtr<ICompositionDrawingSurface> drawingSurface;
        FailFastOnFailure(_compositionGraphicsDevice->CreateDrawingSurface(
            surfaceSize,
            DirectXPixelFormat::DirectXPixelFormat_B8G8R8A8UIntNormalized,
            DirectXAlphaMode::DirectXAlphaMode_Ignore,
            &drawingSurface));

        // Cache the interop pointer, since that's what we always use.
        FailFastOnFailure(drawingSurface.As(&_drawingSurfaceInterop));

        // Draw the text
        DrawText();

        // If the rendering device is lost, the application will recreate and replace it. We then
        // own redrawing our pixels.
        FailFastOnFailure(_compositionGraphicsDevice->add_RenderingDeviceReplaced(
            Callback<RenderingDeviceReplacedEventHandler>([this](
                ICompositionGraphicsDevice* source, IRenderingDeviceReplacedEventArgs* args)
                -> HRESULT
            {
                // Draw the text again
                DrawText();
                return S_OK;
            }).Get(),
            &_deviceReplacedEventToken));
    }

    ~SampleText()
    {
        FailFastOnFailure(_compositionGraphicsDevice->remove_RenderingDeviceReplaced(
            _deviceReplacedEventToken));
    }

    // Return the underlying surface to the caller
    ComPtr<ICompositionSurface> get_Surface()
    {
        // To the caller, the fact that we have a drawing surface is an implementation detail.
        // Return the base interface instead
        ComPtr<ICompositionSurface> surface;
        FailFastOnFailure(_drawingSurfaceInterop.As(&surface));
        return surface;
    }

private:
    // We may detect device loss on BeginDraw calls. This helper handles this condition or other
    // errors.
    bool CheckForDeviceRemoved(HRESULT hr)
    {
        if (SUCCEEDED(hr))
        {
            // Everything is fine -- go ahead and draw
            return true;
        }
        else if (hr == DXGI_ERROR_DEVICE_REMOVED)
        {
            // We can't draw at this time, but this failure is recoverable. Just skip drawing for
            // now. We will be asked to draw again once the Direct3D device is recreated
            return false;
        }
        else
        {
            // Any other error is unexpected and, therefore, fatal
            FailFast();
        }
    }

    // Renders the text into our composition surface
    void DrawText()
    {
        // Begin our update of the surface pixels. If this is our first update, we are required
        // to specify the entire surface, which nullptr is shorthand for (but, as it works out,
        // any time we make an update we touch the entire surface, so we always pass nullptr).
        ComPtr<ID2D1DeviceContext> d2dDeviceContext;
        POINT offset;
        if (CheckForDeviceRemoved(_drawingSurfaceInterop->BeginDraw(nullptr,
            __uuidof(ID2D1DeviceContext), &d2dDeviceContext, &offset)))
        {
            // Create a solid color brush for the text. A more sophisticated application might want
            // to cache and reuse a brush across all text elements instead, taking care to recreate
            // it in the event of device removed.
            ComPtr<ID2D1SolidColorBrush> brush;
            FailFastOnFailure(d2dDeviceContext->CreateSolidColorBrush(
                D2D1::ColorF(D2D1::ColorF::Black, 1.0f), &brush));

            // Draw the line of text at the specified offset, which corresponds to the top-left
            // corner of our drawing surface. Notice we don't call BeginDraw on the D2D device
            // context; this has already been done for us by the composition API.
            d2dDeviceContext->DrawTextLayout(D2D1::Point2F(offset.x, offset.y), _text.Get(),
                brush.Get());

            // Our update is done. EndDraw never indicates rendering device removed, so any
            // failure here is unexpected and, therefore, fatal.
            FailFastOnFailure(_drawingSurfaceInterop->EndDraw());
        }
    }
};

class SampleApp
{
    ComPtr<ICompositor> _compositor;
    ComPtr<ID2D1Device> _d2dDevice;
    ComPtr<ICompositionGraphicsDevice> _compositionGraphicsDevice;
    std::vector<ComPtr<SampleText>> _textSurfaces;

public:
    // Run once when the application starts up
    void Initialize(ICompositor* compositor)
    {
        // Cache the compositor (created outside of this method)
        _compositor = compositor;

        // Create a Direct2D device (helper implementation not shown here)
        FailFastOnFailure(CreateDirect2DDevice(&_d2dDevice));

        // To create a composition graphics device, we need to QI for another interface
        ComPtr<ICompositorInterop> compositorInterop;
        FailFastOnFailure(_compositor.As(&compositorInterop));

        // Create a graphics device backed by our D3D device
        FailFastOnFailure(compositorInterop->CreateGraphicsDevice(
            _d2dDevice.Get(),
            &_compositionGraphicsDevice));
    }

    // Called when Direct3D signals the device lost event
    void OnDirect3DDeviceLost()
    {
        // Create a new device
        FailFastOnFailure(CreateDirect2DDevice(_d2dDevice.ReleaseAndGetAddressOf()));

        // Restore our composition graphics device to good health
        ComPtr<ICompositionGraphicsDeviceInterop> compositionGraphicsDeviceInterop;
        FailFastOnFailure(_compositionGraphicsDevice.As(&compositionGraphicsDeviceInterop));
        FailFastOnFailure(compositionGraphicsDeviceInterop->SetRenderingDevice(_d2dDevice.Get()));
    }

    // Create a surface that is asynchronously filled with an image
    ComPtr<ICompositionSurface> CreateSurfaceFromTextLayout(IDWriteTextLayout* text)
    {
        // Create our wrapper object that will handle downloading and decoding the image (assume
        // throwing new here)
        SampleText* textSurface = new SampleText(text, _compositionGraphicsDevice.Get());

        // Keep our image alive
        _textSurfaces.push_back(textSurface);

        // The caller is only interested in the underlying surface
        return textSurface->get_Surface();
    }

    // Create a visual that holds an image
    ComPtr<IVisual> CreateVisualFromTextLayout(IDWriteTextLayout* text)
    {
        // Create a sprite visual
        ComPtr<ISpriteVisual> spriteVisual;
        FailFastOnFailure(_compositor->CreateSpriteVisual(&spriteVisual));

        // The sprite visual needs a brush to hold the image
        ComPtr<ICompositionSurfaceBrush> surfaceBrush;
        FailFastOnFailure(_compositor->CreateSurfaceBrushWithSurface(
            CreateSurfaceFromTextLayout(text).Get(),
            &surfaceBrush));

        // Associate the brush with the visual
        ComPtr<ICompositionBrush> brush;
        FailFastOnFailure(surfaceBrush.As(&brush));
        FailFastOnFailure(spriteVisual->put_Brush(brush.Get()));

        // Return the visual to the caller as the base class
        ComPtr<IVisual> visual;
        FailFastOnFailure(spriteVisual.As(&visual));

        return visual;
    }

private:
    // This helper (implementation not shown here) creates a Direct2D device and registers
    // for a device loss notification on the underlying Direct3D device. When that notification is
    // raised, assume the OnDirect3DDeviceLost method is called.
    HRESULT CreateDirect2DDevice(ID2D1Device** ppDevice);
};
```

 

 




