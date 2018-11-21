---
author: mtoepke
title: チュートリアル -- Direct3D 9 の DirectX 11 および UWP への移植
description: この移植作業では、Direct3D 9 から Direct3D 11 とユニバーサル Windows プラットフォーム (UWP) に簡単なレンダリング フレームワークを移植する方法について説明します。
ms.assetid: d4467e1f-929b-a4b8-b233-e142a8714c96
ms.author: mtoepke
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, DirectX, 移植, Direct3D 9, Direct3D 11
ms.localizationpriority: medium
ms.openlocfilehash: bd0a8c07be58d670e60aa3a23504d3f5119e6b50
ms.sourcegitcommit: cbe7cf620622a5e4df7414f9e38dfecec1cfca99
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/21/2018
ms.locfileid: "7439104"
---
# <a name="walkthrough-port-a-simple-direct3d-9-app-to-directx-11-and-universal-windows-platform-uwp"></a><span data-ttu-id="9c14e-104">チュートリアル: DirectX 11 とユニバーサル Windows プラットフォーム (UWP) への簡単な Direct3D 9 アプリの移植</span><span class="sxs-lookup"><span data-stu-id="9c14e-104">Walkthrough: Port a simple Direct3D 9 app to DirectX 11 and Universal Windows Platform (UWP)</span></span>



<span data-ttu-id="9c14e-105">この移植作業では、Direct3D 9 から Direct3D 11 とユニバーサル Windows プラットフォーム (UWP) に簡単なレンダリング フレームワークを移植する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="9c14e-105">This porting exercise shows how to bring a simple rendering framework from Direct3D 9 to Direct3D 11 and Universal Windows Platform (UWP).</span></span>
## 
<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="9c14e-106">トピック</span><span class="sxs-lookup"><span data-stu-id="9c14e-106">Topic</span></span></th>
<th align="left"><span data-ttu-id="9c14e-107">説明</span><span class="sxs-lookup"><span data-stu-id="9c14e-107">Description</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p><a href="simple-port-from-direct3d-9-to-11-1-part-1--initializing-direct3d.md"><span data-ttu-id="9c14e-108">Direct3D 11 の初期化</span><span class="sxs-lookup"><span data-stu-id="9c14e-108">Initialize Direct3D 11</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="9c14e-109">Direct3D デバイスとデバイス コンテキストへのハンドルを取得する方法や、DXGI を使ってスワップ チェーンを設定する方法など、Direct3D 9 の初期化コードを Direct3D 11 に変換する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="9c14e-109">Shows how to convert Direct3D 9 initialization code to Direct3D 11, including how to get handles to the Direct3D device and the device context and how to use DXGI to set up a swap chain.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="simple-port-from-direct3d-9-to-11-1-part-2--rendering.md"><span data-ttu-id="9c14e-110">レンダリング フレームワークの変換</span><span class="sxs-lookup"><span data-stu-id="9c14e-110">Convert the rendering framework</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="9c14e-111">ジオメトリ バッファーを移植する方法、HLSL シェーダー プログラムをコンパイルして読み込む方法、Direct3D 11 のレンダリング チェーンを実装する方法など、Direct3D 9 の簡単なレンダリング フレームワークを Direct3D 11 に変換する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="9c14e-111">Shows how to convert a simple rendering framework from Direct3D 9 to Direct3D 11, including how to port geometry buffers, how to compile and load HLSL shader programs, and how to implement the rendering chain in Direct3D 11.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="simple-port-from-direct3d-9-to-11-1-part-3--viewport-and-game-loop.md"><span data-ttu-id="9c14e-112">ゲーム ループの移植</span><span class="sxs-lookup"><span data-stu-id="9c14e-112">Port the game loop</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="9c14e-113"><a href="https://msdn.microsoft.com/library/windows/apps/hh700478"><strong>IFrameworkView</strong></a> を作成して、全画面表示の <a href="https://msdn.microsoft.com/library/windows/apps/br208225"><strong>CoreWindow</strong></a> を制御する方法など、UWP ゲームのウィンドウを実装する方法とゲーム ループを移植する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="9c14e-113">Shows how to implement a window for a UWP game and how to bring over the game loop, including how to build an <a href="https://msdn.microsoft.com/library/windows/apps/hh700478"><strong>IFrameworkView</strong></a> to control a full-screen <a href="https://msdn.microsoft.com/library/windows/apps/br208225"><strong>CoreWindow</strong></a>.</span></span></p></td>
</tr>
</tbody>
</table>

 

<span data-ttu-id="9c14e-114">このトピックでは、頂点シェーディングされた回転する立方体を表示する同じ基本的なグラフィックス タスクを実行する 2 つのコード パスについて説明します。</span><span class="sxs-lookup"><span data-stu-id="9c14e-114">This topic walks through two code paths that perform the same basic graphics task: display a rotating vertex-shaded cube.</span></span> <span data-ttu-id="9c14e-115">いずれの場合でも、コードは次のプロセスに対応しています。</span><span class="sxs-lookup"><span data-stu-id="9c14e-115">In both cases, the code covers the following process:</span></span>

1.  <span data-ttu-id="9c14e-116">Direct3D デバイスとスワップ チェーンを作成する。</span><span class="sxs-lookup"><span data-stu-id="9c14e-116">Creating a Direct3D device and a swap chain.</span></span>
2.  <span data-ttu-id="9c14e-117">カラフルな立方体のメッシュを表す頂点バッファーとインデックス バッファーを作成する。</span><span class="sxs-lookup"><span data-stu-id="9c14e-117">Creating a vertex buffer, and an index buffer, to represent a colorful cube mesh.</span></span>
3.  <span data-ttu-id="9c14e-118">頂点を画面領域に変換する頂点シェーダーと、色値をブレンドするピクセル シェーダーを作成し、シェーダーをコンパイルして、シェーダーを Direct3D リソースとして読み込む。</span><span class="sxs-lookup"><span data-stu-id="9c14e-118">Creating a vertex shader that transforms vertices to screen space, a pixel shader that blends color values, compiling the shaders, and loading the shaders as Direct3D resources.</span></span>
4.  <span data-ttu-id="9c14e-119">レンダリング チェーンを実装し、描画された立方体を画面に表示する。</span><span class="sxs-lookup"><span data-stu-id="9c14e-119">Implementing the rendering chain and presenting the drawn cube to the screen.</span></span>
5.  <span data-ttu-id="9c14e-120">ウィンドウを作成し、メイン ループを開始して、ウィンドウ メッセージの処理に対応する。</span><span class="sxs-lookup"><span data-stu-id="9c14e-120">Creating a window, starting a main loop, and taking care of window message processing.</span></span>

<span data-ttu-id="9c14e-121">このチュートリアルを終了すると、Direct3D 9 と Direct3D 11 の次の基本的な違いを理解できます。</span><span class="sxs-lookup"><span data-stu-id="9c14e-121">Upon completing this walkthrough, you should be familiar with the following basic differences between Direct3D 9 and Direct3D 11:</span></span>

-   <span data-ttu-id="9c14e-122">デバイス、デバイス コンテキスト、グラフィックス インフラストラクチャの分離。</span><span class="sxs-lookup"><span data-stu-id="9c14e-122">The separation of device, device context, and graphics infrastructure.</span></span>
-   <span data-ttu-id="9c14e-123">シェーダーをコンパイルし、実行時にシェーダーのバイトコードを読み込むプロセス。</span><span class="sxs-lookup"><span data-stu-id="9c14e-123">The process of compiling shaders, and loading shader bytecode at runtime.</span></span>
-   <span data-ttu-id="9c14e-124">入力アセンブラー (IA) ステージの頂点ごとのデータを構成する方法。</span><span class="sxs-lookup"><span data-stu-id="9c14e-124">How to configure per-vertex data for the Input Assembler (IA) stage.</span></span>
-   <span data-ttu-id="9c14e-125">[**IFrameworkView**](https://msdn.microsoft.com/library/windows/apps/hh700478) を使って CoreWindow ビューを作成する方法。</span><span class="sxs-lookup"><span data-stu-id="9c14e-125">How to use an [**IFrameworkView**](https://msdn.microsoft.com/library/windows/apps/hh700478) to create a CoreWindow view.</span></span>

<span data-ttu-id="9c14e-126">このチュートリアルでは、簡素化のため [**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) を使用しており、XAML の相互運用には対応しない点に注意してください。</span><span class="sxs-lookup"><span data-stu-id="9c14e-126">Note that this walkthrough uses [**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) for simplicity, and does not cover XAML interop.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="9c14e-127">前提条件</span><span class="sxs-lookup"><span data-stu-id="9c14e-127">Prerequisites</span></span>


<span data-ttu-id="9c14e-128">[UWP DirectX ゲームの開発環境を準備する](prepare-your-dev-environment-for-windows-store-directx-game-development.md)必要があります。</span><span class="sxs-lookup"><span data-stu-id="9c14e-128">You should [Prepare your dev environment for UWP DirectX game development](prepare-your-dev-environment-for-windows-store-directx-game-development.md).</span></span> <span data-ttu-id="9c14e-129">テンプレートはまだ必要ありませんが、このチュートリアルのコード サンプルを読み込むに Microsoft Visual Studio2015 必要があります。</span><span class="sxs-lookup"><span data-stu-id="9c14e-129">You don't need a template yet, but you'll need Microsoft Visual Studio2015 to load the code samples for this walkthrough.</span></span>

<span data-ttu-id="9c14e-130">このチュートリアルで説明する DirectX 11 と UWP のプログラミングの概念について詳しくは、「[DirectX 9 からの DirectX 11 と Windows ストアへの移行](porting-considerations.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="9c14e-130">Visit [Porting concepts and considerations](porting-considerations.md) to gain a better understanding of the DirectX 11 and UWP programming concepts shown in this walkthrough.</span></span>

## <a name="related-topics"></a><span data-ttu-id="9c14e-131">関連トピック</span><span class="sxs-lookup"><span data-stu-id="9c14e-131">Related topics</span></span>

**<span data-ttu-id="9c14e-132">Direct3D</span><span class="sxs-lookup"><span data-stu-id="9c14e-132">Direct3D</span></span>**

* [<span data-ttu-id="9c14e-133">Direct3D 9 での HLSL シェーダーの記述</span><span class="sxs-lookup"><span data-stu-id="9c14e-133">Writing HLSL Shaders in Direct3D 9</span></span>](https://msdn.microsoft.com/library/windows/desktop/bb944006)
* [<span data-ttu-id="9c14e-134">DirectX ゲーム プロジェクト テンプレート</span><span class="sxs-lookup"><span data-stu-id="9c14e-134">DirectX game project templates</span></span>](user-interface.md)

**<span data-ttu-id="9c14e-135">Microsoft Store</span><span class="sxs-lookup"><span data-stu-id="9c14e-135">Microsoft Store</span></span>**

* [**<span data-ttu-id="9c14e-136">Microsoft::WRL::ComPtr</span><span class="sxs-lookup"><span data-stu-id="9c14e-136">Microsoft::WRL::ComPtr</span></span>**](https://msdn.microsoft.com/library/windows/apps/br244983.aspx)
* [**<span data-ttu-id="9c14e-137">オブジェクトへのハンドル演算子 (^)</span><span class="sxs-lookup"><span data-stu-id="9c14e-137">Handle to Object Operator (^)</span></span>**](https://msdn.microsoft.com/library/windows/apps/yk97tc08.aspx)

