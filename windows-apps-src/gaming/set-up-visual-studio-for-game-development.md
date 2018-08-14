---
author: mtoepke
title: ゲーム プログラミング用の Visual Studio ツール
description: Visual Studio で利用できる DirectX 固有のツールの概要。
ms.assetid: 43137bfc-7876-70e0-515c-4722f68bd064
ms.author: mtoepke
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, UWP, ゲーム, Visual Studio, ツール, DirectX
ms.openlocfilehash: 5f5c1ef45dd476565d302ef10f8d47ab2b819993
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.locfileid: "243208"
---
# <a name="visual-studio-tools-for-game-programming"></a><span data-ttu-id="3fce0-104">ゲーム プログラミング用の Visual Studio ツール</span><span class="sxs-lookup"><span data-stu-id="3fce0-104">Visual Studio tools for game programming</span></span>


<span data-ttu-id="3fce0-105">\[Windows 10 の UWP アプリ向けに更新。</span><span class="sxs-lookup"><span data-stu-id="3fce0-105">\[ Updated for UWP apps on Windows 10.</span></span> <span data-ttu-id="3fce0-106">Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]</span><span class="sxs-lookup"><span data-stu-id="3fce0-106">For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]</span></span>

**<span data-ttu-id="3fce0-107">要約</span><span class="sxs-lookup"><span data-stu-id="3fce0-107">Summary</span></span>**

-   [<span data-ttu-id="3fce0-108">テンプレートからの DirectX ゲーム プロジェクトの作成</span><span class="sxs-lookup"><span data-stu-id="3fce0-108">Create a DirectX game project from a template</span></span>](user-interface.md)
-   <span data-ttu-id="3fce0-109">DirectX ゲーム プログラミング用の Visual Studio ツールの使用</span><span class="sxs-lookup"><span data-stu-id="3fce0-109">Visual Studio tools for DirectX game programming</span></span>


<span data-ttu-id="3fce0-110">Visual Studio Ultimate を使って、DirectX アプリを開発する場合は、画像、モデル、シェーダー リソースを作成、編集、プレビュー、エクスポートするための追加のツールを利用できます。</span><span class="sxs-lookup"><span data-stu-id="3fce0-110">If you use Visual Studio Ultimate to develop DirectX apps, there are additional tools available for creating, editing, previewing, and exporting image, model, and shader resources.</span></span> <span data-ttu-id="3fce0-111">また、ビルド時のリソースの変換や、DirectX グラフィックス コードのデバッグに使うことができるツールもあります。</span><span class="sxs-lookup"><span data-stu-id="3fce0-111">There are also tools that you can use to convert resources at build time and debug DirectX graphics code.</span></span>

<span data-ttu-id="3fce0-112">このトピックでは、こうしたグラフィックス ツールの概要について説明します。</span><span class="sxs-lookup"><span data-stu-id="3fce0-112">This topic gives an overview of these graphics tools.</span></span>

## <a name="image-editor"></a><span data-ttu-id="3fce0-113">イメージ エディター</span><span class="sxs-lookup"><span data-stu-id="3fce0-113">Image Editor</span></span>


<span data-ttu-id="3fce0-114">イメージ エディターは、DirectX で使うリッチ テクスチャと画像形式の種類を操作するのに使います。</span><span class="sxs-lookup"><span data-stu-id="3fce0-114">Use the Image Editor to work with the kinds of rich texture and image formats that DirectX uses.</span></span> <span data-ttu-id="3fce0-115">イメージ エディターでは、次の形式をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="3fce0-115">The Image Editor supports the following formats.</span></span>

-   <span data-ttu-id="3fce0-116">.png</span><span class="sxs-lookup"><span data-stu-id="3fce0-116">.png</span></span>
-   <span data-ttu-id="3fce0-117">.jpg、.jpeg、.jpe、.jfif</span><span class="sxs-lookup"><span data-stu-id="3fce0-117">.jpg, .jpeg, .jpe, .jfif</span></span>
-   <span data-ttu-id="3fce0-118">.dds</span><span class="sxs-lookup"><span data-stu-id="3fce0-118">.dds</span></span>
-   <span data-ttu-id="3fce0-119">.gif</span><span class="sxs-lookup"><span data-stu-id="3fce0-119">.gif</span></span>
-   <span data-ttu-id="3fce0-120">.bmp</span><span class="sxs-lookup"><span data-stu-id="3fce0-120">.bmp</span></span>
-   <span data-ttu-id="3fce0-121">.dib</span><span class="sxs-lookup"><span data-stu-id="3fce0-121">.dib</span></span>
-   <span data-ttu-id="3fce0-122">.tif、.tiff</span><span class="sxs-lookup"><span data-stu-id="3fce0-122">.tif, .tiff</span></span>
-   <span data-ttu-id="3fce0-123">.tga</span><span class="sxs-lookup"><span data-stu-id="3fce0-123">.tga</span></span>

<span data-ttu-id="3fce0-124">ビルド時にこれらを .dds ファイルに変換するには、[ビルド カスタマイズ ファイル](#build-customizations-for-3d-assets)を作成します。</span><span class="sxs-lookup"><span data-stu-id="3fce0-124">Create [build customization files](#build-customizations-for-3d-assets) to convert these to .dds files at build time.</span></span>

<span data-ttu-id="3fce0-125">詳しくは、「[テクスチャおよびイメージの使用](https://msdn.microsoft.com/library/windows/apps/hh873119.aspx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3fce0-125">For more information, see [Working with Textures and Images](https://msdn.microsoft.com/library/windows/apps/hh873119.aspx).</span></span>

> <span data-ttu-id="3fce0-126">**注**  イメージ エディターは、フル機能を備えた画像編集アプリを置き換えるものではありませんが、簡単な表示や編集シナリオの多くに適しています。</span><span class="sxs-lookup"><span data-stu-id="3fce0-126">**Note**  The Image Editor is not intended to be a replacement for a full feature image editing app, but is appropriate for many simple viewing and editing scenarios.</span></span>

 

## <a name="model-editor"></a><span data-ttu-id="3fce0-127">モデル エディター</span><span class="sxs-lookup"><span data-stu-id="3fce0-127">Model Editor</span></span>


<span data-ttu-id="3fce0-128">モデル エディターを使うと、基本的な 3D モデルをゼロから作成するや、フル機能を備えた 3D モデリング ツールで作成したもっと複雑な 3D モデルの表示や変更を行うことができます。</span><span class="sxs-lookup"><span data-stu-id="3fce0-128">You can use the Model Editor to create basic 3D models from scratch, or to view and modify more-complex 3D models from full-featured 3D modeling tools.</span></span> <span data-ttu-id="3fce0-129">モデル エディターでは、DirectX アプリの開発で使われるいくつかの 3D モデル形式をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="3fce0-129">The Model Editor supports several 3D model formats that are used in DirectX app development.</span></span> <span data-ttu-id="3fce0-130">ビルド時に次のファイルを .cmo ファイルに変換する[ビルド カスタマイズ ファイル](#build-customizations-for-3d-assets)を作成できます。</span><span class="sxs-lookup"><span data-stu-id="3fce0-130">You can create [build customization files](#build-customizations-for-3d-assets) to convert these to .cmo files at build time.</span></span>

-   <span data-ttu-id="3fce0-131">.fbx</span><span class="sxs-lookup"><span data-stu-id="3fce0-131">.fbx</span></span>
-   <span data-ttu-id="3fce0-132">.dae</span><span class="sxs-lookup"><span data-stu-id="3fce0-132">.dae</span></span>
-   <span data-ttu-id="3fce0-133">.obj</span><span class="sxs-lookup"><span data-stu-id="3fce0-133">.obj</span></span>

<span data-ttu-id="3fce0-134">エディターで照明を適用したモデルのスクリーンショットを次に示します。</span><span class="sxs-lookup"><span data-stu-id="3fce0-134">Here's a screenshot of a model in the editor with lighting applied.</span></span>

![ティーポット](images/modeleditor.png)

<span data-ttu-id="3fce0-136">詳しくは、「[3-D モデルの操作](https://msdn.microsoft.com/library/windows/apps/hh873114.aspx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3fce0-136">For more information, see [Working with 3-D Models](https://msdn.microsoft.com/library/windows/apps/hh873114.aspx).</span></span>

> <span data-ttu-id="3fce0-137">**注**  モデル エディターは、フル機能を備えたモデル編集アプリを置き換えるものではありませんが、簡単な表示や編集シナリオの多くに適しています。</span><span class="sxs-lookup"><span data-stu-id="3fce0-137">**Note**  The Model Editor is not intended to be a replacement for a full feature model editing app, but is appropriate for many simple viewing and editing scenarios.</span></span>

 

## <a name="shader-designer"></a><span data-ttu-id="3fce0-138">シェーダー デザイナー</span><span class="sxs-lookup"><span data-stu-id="3fce0-138">Shader Designer</span></span>


<span data-ttu-id="3fce0-139">HLSL でのプログラミングがわからない場合でも、シェーダー デザイナーを使うと、ゲームやアプリのカスタムの視覚効果を作成できます。</span><span class="sxs-lookup"><span data-stu-id="3fce0-139">Use the Shader Designer to create custom visual effects for your game or app even if you don't know HLSL programming.</span></span>

<span data-ttu-id="3fce0-140">シェーダーはグラフとして視覚的に作成します。</span><span class="sxs-lookup"><span data-stu-id="3fce0-140">You create a shader visually as a graph.</span></span> <span data-ttu-id="3fce0-141">各ノードには、その操作までの出力のプレビューが表示されます。</span><span class="sxs-lookup"><span data-stu-id="3fce0-141">Each node displays a preview of the output up to that operation.</span></span> <span data-ttu-id="3fce0-142">球体のプレビューでランバート照明を適用した例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="3fce0-142">Here's an example that applies Lambert lighting with a sphere preview.</span></span>

![視覚シェーダー グラフ](images/shaderdesigner.png)

<span data-ttu-id="3fce0-144">シェーダー エディターは、シェーダーを設計、編集、.dgsl 形式で保存するのに使います。</span><span class="sxs-lookup"><span data-stu-id="3fce0-144">Use the Shader Editor to design, edit, and save shaders in the .dgsl format.</span></span> <span data-ttu-id="3fce0-145">また、次の形式をエクスポートします。</span><span class="sxs-lookup"><span data-stu-id="3fce0-145">It also exports the following formats.</span></span>

-   <span data-ttu-id="3fce0-146">.hlsl (ソース コード)</span><span class="sxs-lookup"><span data-stu-id="3fce0-146">.hlsl (source code)</span></span>
-   <span data-ttu-id="3fce0-147">.cso (バイトコード)</span><span class="sxs-lookup"><span data-stu-id="3fce0-147">.cso (bytecode)</span></span>
-   <span data-ttu-id="3fce0-148">.h (HLSL バイトコード配列)</span><span class="sxs-lookup"><span data-stu-id="3fce0-148">.h (HLSL bytecode array)</span></span>

<span data-ttu-id="3fce0-149">ビルド時にこれらの形式を .cso ファイルに変換するには、[ビルド カスタマイズ ファイル](#build-customizations-for-3d-assets)を作成します。</span><span class="sxs-lookup"><span data-stu-id="3fce0-149">Create [build customization files](#build-customizations-for-3d-assets) to convert any of these formats to .cso files at build time.</span></span>

<span data-ttu-id="3fce0-150">シェーダー エディターでエクスポートした HLSL コードの一部を次に示します。</span><span class="sxs-lookup"><span data-stu-id="3fce0-150">Here is a portion of HLSL code that is exported by the Shader Editor.</span></span> <span data-ttu-id="3fce0-151">これは、ランバート照明ノードのコードだけです。</span><span class="sxs-lookup"><span data-stu-id="3fce0-151">This is only the code for the Lambert lighting node.</span></span>

```hlsl
//
// Lambert lighting function
//
float3 LambertLighting(
    float3 lightNormal,
    float3 surfaceNormal,
    float3 materialAmbient,
    float3 lightAmbient,
    float3 lightColor,
    float3 pixelColor
    )
{
    // Compute the amount of contribution per light.
    float diffuseAmount = saturate(dot(lightNormal, surfaceNormal));
    float3 diffuse = diffuseAmount * lightColor * pixelColor;

    // Combine ambient with diffuse.
    return saturate((materialAmbient * lightAmbient) + diffuse);
}
```

<span data-ttu-id="3fce0-152">詳しくは、「[シェーダーの操作](https://msdn.microsoft.com/library/windows/apps/hh873117.aspx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3fce0-152">For more information, see [Working with Shaders](https://msdn.microsoft.com/library/windows/apps/hh873117.aspx).</span></span>

## <a name="build-customizations-for-3d-assets"></a><span data-ttu-id="3fce0-153">3D アセットのビルドのカスタマイズ</span><span class="sxs-lookup"><span data-stu-id="3fce0-153">Build customizations for 3D assets</span></span>


<span data-ttu-id="3fce0-154">プロジェクトにビルドのカスタマイズを追加して、リソースを Visual Studio で利用できる形式に変換できます。</span><span class="sxs-lookup"><span data-stu-id="3fce0-154">You can add build customizations to your project so that Visual Studio converts resources to usable formats.</span></span> <span data-ttu-id="3fce0-155">その後で、アプリにアセットを読み込み、他の DirectX アプリと同じように DirectX リソースを作成し、設定して、アセットを使うことができます。</span><span class="sxs-lookup"><span data-stu-id="3fce0-155">After that, you can load the assets into your app and use them by creating and filling DirectX resources just like you would in any other DirectX app.</span></span>

<span data-ttu-id="3fce0-156">ビルド カスタマイズを追加するには、**ソリューション エクスプローラー**でプロジェクトを右クリックし、**[ビルドのカスタマイズ]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="3fce0-156">To add a build customization, you right-click on the project in the **Solution Explorer** and select **Build Customizations...**.</span></span> <span data-ttu-id="3fce0-157">プロジェクトには次の種類のビルドのカスタマイズを追加できます。</span><span class="sxs-lookup"><span data-stu-id="3fce0-157">You can add the following types of build customizations to your project.</span></span>

-   <span data-ttu-id="3fce0-158">入力として画像ファイルを受け取り、DirectDraw Surface (.dds) ファイルを出力するイメージ コンテンツ パイプライン。</span><span class="sxs-lookup"><span data-stu-id="3fce0-158">Image Content Pipeline takes image files as input and outputs DirectDraw Surface (.dds) files.</span></span>
-   <span data-ttu-id="3fce0-159">メッシュ ファイル (.fbx など) を受け取り、.cmo メッシュ ファイルを出力するメッシュ コンテンツ パイプライン。</span><span class="sxs-lookup"><span data-stu-id="3fce0-159">Mesh Content Pipeline takes mesh files (such as .fbx) and outputs .cmo mesh files.</span></span>
-   <span data-ttu-id="3fce0-160">Visual Studio シェーダー エディターで作成した視覚シェーダー グラフ (.dgsl) を受け取り、コンパイル済みシェーダー出力 (.cso) ファイルを出力するシェーダー コンテンツ パイプライン。</span><span class="sxs-lookup"><span data-stu-id="3fce0-160">Shader Content Pipeline takes Visual Shader Graph (.dgsl) from the Visual Studio Shader Editor and outputs a Compiled Shader Output (.cso) file.</span></span>

<span data-ttu-id="3fce0-161">詳しくは、「[ゲームまたはアプリケーションでの 3-D アセットの使用](https://msdn.microsoft.com/library/windows/apps/hh972446.aspx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3fce0-161">For more information, see [Using 3-D Assets in Your Game or App](https://msdn.microsoft.com/library/windows/apps/hh972446.aspx).</span></span>

## <a name="debugging-directx-graphics"></a><span data-ttu-id="3fce0-162">DirectX グラフィックスのデバッグ</span><span class="sxs-lookup"><span data-stu-id="3fce0-162">Debugging DirectX graphics</span></span>


<span data-ttu-id="3fce0-163">Visual Studio には、グラフィックス固有のデバッグ ツールが用意されています。</span><span class="sxs-lookup"><span data-stu-id="3fce0-163">Visual Studio provides graphics-specific debugging tools.</span></span> <span data-ttu-id="3fce0-164">これらのツールを使って、次のような項目をデバッグします。</span><span class="sxs-lookup"><span data-stu-id="3fce0-164">Use these tools to debug things like:</span></span>

-   <span data-ttu-id="3fce0-165">グラフィックス パイプライン。</span><span class="sxs-lookup"><span data-stu-id="3fce0-165">The graphics pipeline.</span></span>
-   <span data-ttu-id="3fce0-166">イベント呼び出し履歴。</span><span class="sxs-lookup"><span data-stu-id="3fce0-166">The event call stack.</span></span>
-   <span data-ttu-id="3fce0-167">オブジェクト テーブル。</span><span class="sxs-lookup"><span data-stu-id="3fce0-167">The object table.</span></span>
-   <span data-ttu-id="3fce0-168">デバイスの状態。</span><span class="sxs-lookup"><span data-stu-id="3fce0-168">The device state.</span></span>
-   <span data-ttu-id="3fce0-169">シェーダーのバグ。</span><span class="sxs-lookup"><span data-stu-id="3fce0-169">Shader bugs.</span></span>
-   <span data-ttu-id="3fce0-170">初期化されていないか、無効な定数バッファーとパラメーター。</span><span class="sxs-lookup"><span data-stu-id="3fce0-170">Uninitialized or incorrect constant buffers and parameters.</span></span>
-   <span data-ttu-id="3fce0-171">DirectX バージョンの互換性。</span><span class="sxs-lookup"><span data-stu-id="3fce0-171">DirectX version compatibility.</span></span>
-   <span data-ttu-id="3fce0-172">制限されている Direct2D のサポート。</span><span class="sxs-lookup"><span data-stu-id="3fce0-172">Limited Direct2D support.</span></span>
-   <span data-ttu-id="3fce0-173">オペレーティング システムと SDK の要件。</span><span class="sxs-lookup"><span data-stu-id="3fce0-173">Operating system and SDK requirements.</span></span>

<span data-ttu-id="3fce0-174">詳しくは、「[DirectX グラフィックスのデバッグ](https://msdn.microsoft.com/library/windows/apps/hh315751.aspx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3fce0-174">For more information, see [Debugging DirectX Graphics](https://msdn.microsoft.com/library/windows/apps/hh315751.aspx).</span></span>

> <span data-ttu-id="3fce0-175">**注**  この記事は、ユニバーサル Windows プラットフォーム (UWP) アプリを作成する Windows 10 開発者を対象としています。</span><span class="sxs-lookup"><span data-stu-id="3fce0-175">**Note**  This article is for Windows 10 developers writing Universal Windows Platform (UWP) apps.</span></span> <span data-ttu-id="3fce0-176">Windows 8.x 用または Windows Phone 8.x 用の開発を行っている場合は、[アーカイブされているドキュメント](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3fce0-176">If you’re developing for Windows 8.x or Windows Phone 8.x, see the [archived documentation](http://go.microsoft.com/fwlink/p/?linkid=619132).</span></span>

 

 

 




