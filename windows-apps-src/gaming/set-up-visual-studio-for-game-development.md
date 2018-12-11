---
title: ゲーム プログラミング用の Visual Studio ツール
description: Visual Studio で利用できる DirectX 固有のツールの概要。
ms.assetid: 43137bfc-7876-70e0-515c-4722f68bd064
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, UWP, ゲーム, Visual Studio, ツール, DirectX
ms.localizationpriority: medium
ms.openlocfilehash: 5a3938f486d52942031944b1184a711ddbc579db
ms.sourcegitcommit: 8921a9cc0dd3e5665345ae8eca7ab7aeb83ccc6f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/10/2018
ms.locfileid: "8873773"
---
# <a name="visual-studio-tools-for-game-programming"></a><span data-ttu-id="bee68-104">ゲーム プログラミング用の Visual Studio ツール</span><span class="sxs-lookup"><span data-stu-id="bee68-104">Visual Studio tools for game programming</span></span>



**<span data-ttu-id="bee68-105">要約</span><span class="sxs-lookup"><span data-stu-id="bee68-105">Summary</span></span>**

-   [<span data-ttu-id="bee68-106">テンプレートからの DirectX ゲーム プロジェクトの作成</span><span class="sxs-lookup"><span data-stu-id="bee68-106">Create a DirectX game project from a template</span></span>](user-interface.md)
-   <span data-ttu-id="bee68-107">DirectX ゲーム プログラミング用の Visual Studio ツールの使用</span><span class="sxs-lookup"><span data-stu-id="bee68-107">Visual Studio tools for DirectX game programming</span></span>


<span data-ttu-id="bee68-108">Visual Studio Ultimate を使って、DirectX アプリを開発する場合は、画像、モデル、シェーダー リソースを作成、編集、プレビュー、エクスポートするための追加のツールを利用できます。</span><span class="sxs-lookup"><span data-stu-id="bee68-108">If you use Visual Studio Ultimate to develop DirectX apps, there are additional tools available for creating, editing, previewing, and exporting image, model, and shader resources.</span></span> <span data-ttu-id="bee68-109">また、ビルド時のリソースの変換や、DirectX グラフィックス コードのデバッグに使うことができるツールもあります。</span><span class="sxs-lookup"><span data-stu-id="bee68-109">There are also tools that you can use to convert resources at build time and debug DirectX graphics code.</span></span>

<span data-ttu-id="bee68-110">このトピックでは、こうしたグラフィックス ツールの概要について説明します。</span><span class="sxs-lookup"><span data-stu-id="bee68-110">This topic gives an overview of these graphics tools.</span></span>

## <a name="image-editor"></a><span data-ttu-id="bee68-111">イメージ エディター</span><span class="sxs-lookup"><span data-stu-id="bee68-111">Image Editor</span></span>


<span data-ttu-id="bee68-112">イメージ エディターは、DirectX で使うリッチ テクスチャと画像形式の種類を操作するのに使います。</span><span class="sxs-lookup"><span data-stu-id="bee68-112">Use the Image Editor to work with the kinds of rich texture and image formats that DirectX uses.</span></span> <span data-ttu-id="bee68-113">イメージ エディターでは、次の形式をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="bee68-113">The Image Editor supports the following formats.</span></span>

-   <span data-ttu-id="bee68-114">.png</span><span class="sxs-lookup"><span data-stu-id="bee68-114">.png</span></span>
-   <span data-ttu-id="bee68-115">.jpg、.jpeg、.jpe、.jfif</span><span class="sxs-lookup"><span data-stu-id="bee68-115">.jpg, .jpeg, .jpe, .jfif</span></span>
-   <span data-ttu-id="bee68-116">.dds</span><span class="sxs-lookup"><span data-stu-id="bee68-116">.dds</span></span>
-   <span data-ttu-id="bee68-117">.gif</span><span class="sxs-lookup"><span data-stu-id="bee68-117">.gif</span></span>
-   <span data-ttu-id="bee68-118">.bmp</span><span class="sxs-lookup"><span data-stu-id="bee68-118">.bmp</span></span>
-   <span data-ttu-id="bee68-119">.dib</span><span class="sxs-lookup"><span data-stu-id="bee68-119">.dib</span></span>
-   <span data-ttu-id="bee68-120">.tif、.tiff</span><span class="sxs-lookup"><span data-stu-id="bee68-120">.tif, .tiff</span></span>
-   <span data-ttu-id="bee68-121">.tga</span><span class="sxs-lookup"><span data-stu-id="bee68-121">.tga</span></span>

<span data-ttu-id="bee68-122">ビルド時にこれらを .dds ファイルに変換するには、[ビルド カスタマイズ ファイル](#build-customizations-for-3d-assets)を作成します。</span><span class="sxs-lookup"><span data-stu-id="bee68-122">Create [build customization files](#build-customizations-for-3d-assets) to convert these to .dds files at build time.</span></span>

<span data-ttu-id="bee68-123">詳しくは、「[テクスチャおよびイメージの使用](https://msdn.microsoft.com/library/windows/apps/hh873119.aspx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="bee68-123">For more information, see [Working with Textures and Images](https://msdn.microsoft.com/library/windows/apps/hh873119.aspx).</span></span>

> <span data-ttu-id="bee68-124">**注:** イメージ エディターは、フル機能イメージを編集アプリを置き換えるものではありませんが多くの簡単な表示や編集シナリオに適しています。</span><span class="sxs-lookup"><span data-stu-id="bee68-124">**Note**The Image Editor is not intended to be a replacement for a full feature image editing app, but is appropriate for many simple viewing and editing scenarios.</span></span>

 

## <a name="model-editor"></a><span data-ttu-id="bee68-125">モデル エディター</span><span class="sxs-lookup"><span data-stu-id="bee68-125">Model Editor</span></span>


<span data-ttu-id="bee68-126">モデル エディターを使うと、基本的な 3D モデルをゼロから作成するや、フル機能を備えた 3D モデリング ツールで作成したもっと複雑な 3D モデルの表示や変更を行うことができます。</span><span class="sxs-lookup"><span data-stu-id="bee68-126">You can use the Model Editor to create basic 3D models from scratch, or to view and modify more-complex 3D models from full-featured 3D modeling tools.</span></span> <span data-ttu-id="bee68-127">モデル エディターでは、DirectX アプリの開発で使われるいくつかの 3D モデル形式をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="bee68-127">The Model Editor supports several 3D model formats that are used in DirectX app development.</span></span> <span data-ttu-id="bee68-128">ビルド時に次のファイルを .cmo ファイルに変換する[ビルド カスタマイズ ファイル](#build-customizations-for-3d-assets)を作成できます。</span><span class="sxs-lookup"><span data-stu-id="bee68-128">You can create [build customization files](#build-customizations-for-3d-assets) to convert these to .cmo files at build time.</span></span>

-   <span data-ttu-id="bee68-129">.fbx</span><span class="sxs-lookup"><span data-stu-id="bee68-129">.fbx</span></span>
-   <span data-ttu-id="bee68-130">.dae</span><span class="sxs-lookup"><span data-stu-id="bee68-130">.dae</span></span>
-   <span data-ttu-id="bee68-131">.obj</span><span class="sxs-lookup"><span data-stu-id="bee68-131">.obj</span></span>

<span data-ttu-id="bee68-132">エディターで照明を適用したモデルのスクリーンショットを次に示します。</span><span class="sxs-lookup"><span data-stu-id="bee68-132">Here's a screenshot of a model in the editor with lighting applied.</span></span>

![ティーポット](images/modeleditor.png)

<span data-ttu-id="bee68-134">詳しくは、「[3-D モデルの操作](https://msdn.microsoft.com/library/windows/apps/hh873114.aspx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="bee68-134">For more information, see [Working with 3-D Models](https://msdn.microsoft.com/library/windows/apps/hh873114.aspx).</span></span>

> <span data-ttu-id="bee68-135">**注:** モデル エディターは、フル機能モデル編集アプリを置き換えるものではありませんが、多くの簡単な表示や編集シナリオに適しています。</span><span class="sxs-lookup"><span data-stu-id="bee68-135">**Note**The Model Editor is not intended to be a replacement for a full feature model editing app, but is appropriate for many simple viewing and editing scenarios.</span></span>

 

## <a name="shader-designer"></a><span data-ttu-id="bee68-136">シェーダー デザイナー</span><span class="sxs-lookup"><span data-stu-id="bee68-136">Shader Designer</span></span>


<span data-ttu-id="bee68-137">HLSL でのプログラミングがわからない場合でも、シェーダー デザイナーを使うと、ゲームやアプリのカスタムの視覚効果を作成できます。</span><span class="sxs-lookup"><span data-stu-id="bee68-137">Use the Shader Designer to create custom visual effects for your game or app even if you don't know HLSL programming.</span></span>

<span data-ttu-id="bee68-138">シェーダーはグラフとして視覚的に作成します。</span><span class="sxs-lookup"><span data-stu-id="bee68-138">You create a shader visually as a graph.</span></span> <span data-ttu-id="bee68-139">各ノードには、その操作までの出力のプレビューが表示されます。</span><span class="sxs-lookup"><span data-stu-id="bee68-139">Each node displays a preview of the output up to that operation.</span></span> <span data-ttu-id="bee68-140">球体のプレビューでランバート照明を適用した例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="bee68-140">Here's an example that applies Lambert lighting with a sphere preview.</span></span>

![視覚シェーダー グラフ](images/shaderdesigner.png)

<span data-ttu-id="bee68-142">シェーダー エディターは、シェーダーを設計、編集、.dgsl 形式で保存するのに使います。</span><span class="sxs-lookup"><span data-stu-id="bee68-142">Use the Shader Editor to design, edit, and save shaders in the .dgsl format.</span></span> <span data-ttu-id="bee68-143">また、次の形式をエクスポートします。</span><span class="sxs-lookup"><span data-stu-id="bee68-143">It also exports the following formats.</span></span>

-   <span data-ttu-id="bee68-144">.hlsl (ソース コード)</span><span class="sxs-lookup"><span data-stu-id="bee68-144">.hlsl (source code)</span></span>
-   <span data-ttu-id="bee68-145">.cso (バイトコード)</span><span class="sxs-lookup"><span data-stu-id="bee68-145">.cso (bytecode)</span></span>
-   <span data-ttu-id="bee68-146">.h (HLSL バイトコード配列)</span><span class="sxs-lookup"><span data-stu-id="bee68-146">.h (HLSL bytecode array)</span></span>

<span data-ttu-id="bee68-147">ビルド時にこれらの形式を .cso ファイルに変換するには、[ビルド カスタマイズ ファイル](#build-customizations-for-3d-assets)を作成します。</span><span class="sxs-lookup"><span data-stu-id="bee68-147">Create [build customization files](#build-customizations-for-3d-assets) to convert any of these formats to .cso files at build time.</span></span>

<span data-ttu-id="bee68-148">シェーダー エディターでエクスポートした HLSL コードの一部を次に示します。</span><span class="sxs-lookup"><span data-stu-id="bee68-148">Here is a portion of HLSL code that is exported by the Shader Editor.</span></span> <span data-ttu-id="bee68-149">これは、ランバート照明ノードのコードだけです。</span><span class="sxs-lookup"><span data-stu-id="bee68-149">This is only the code for the Lambert lighting node.</span></span>

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

<span data-ttu-id="bee68-150">詳しくは、「[シェーダーの操作](https://msdn.microsoft.com/library/windows/apps/hh873117.aspx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="bee68-150">For more information, see [Working with Shaders](https://msdn.microsoft.com/library/windows/apps/hh873117.aspx).</span></span>

## <a name="build-customizations-for-3d-assets"></a><span data-ttu-id="bee68-151">3D アセットのビルドのカスタマイズ</span><span class="sxs-lookup"><span data-stu-id="bee68-151">Build customizations for 3D assets</span></span>


<span data-ttu-id="bee68-152">プロジェクトにビルドのカスタマイズを追加して、リソースを Visual Studio で利用できる形式に変換できます。</span><span class="sxs-lookup"><span data-stu-id="bee68-152">You can add build customizations to your project so that Visual Studio converts resources to usable formats.</span></span> <span data-ttu-id="bee68-153">その後で、アプリにアセットを読み込み、他の DirectX アプリと同じように DirectX リソースを作成し、設定して、アセットを使うことができます。</span><span class="sxs-lookup"><span data-stu-id="bee68-153">After that, you can load the assets into your app and use them by creating and filling DirectX resources just like you would in any other DirectX app.</span></span>

<span data-ttu-id="bee68-154">ビルドのカスタマイズを追加するには、**ソリューション エクスプ ローラー**でプロジェクトを右クリックし、**ビルドのカスタマイズ]** を選択します。次の種類のビルドのカスタマイズは、プロジェクトに追加できます。</span><span class="sxs-lookup"><span data-stu-id="bee68-154">To add a build customization, you right-click on the project in the **Solution Explorer** and select **Build Customizations...**. You can add the following types of build customizations to your project.</span></span>

-   <span data-ttu-id="bee68-155">入力として画像ファイルを受け取り、DirectDraw Surface (.dds) ファイルを出力するイメージ コンテンツ パイプライン。</span><span class="sxs-lookup"><span data-stu-id="bee68-155">Image Content Pipeline takes image files as input and outputs DirectDraw Surface (.dds) files.</span></span>
-   <span data-ttu-id="bee68-156">メッシュ ファイル (.fbx など) を受け取り、.cmo メッシュ ファイルを出力するメッシュ コンテンツ パイプライン。</span><span class="sxs-lookup"><span data-stu-id="bee68-156">Mesh Content Pipeline takes mesh files (such as .fbx) and outputs .cmo mesh files.</span></span>
-   <span data-ttu-id="bee68-157">Visual Studio シェーダー エディターで作成した視覚シェーダー グラフ (.dgsl) を受け取り、コンパイル済みシェーダー出力 (.cso) ファイルを出力するシェーダー コンテンツ パイプライン。</span><span class="sxs-lookup"><span data-stu-id="bee68-157">Shader Content Pipeline takes Visual Shader Graph (.dgsl) from the Visual Studio Shader Editor and outputs a Compiled Shader Output (.cso) file.</span></span>

<span data-ttu-id="bee68-158">詳しくは、「[ゲームまたはアプリケーションでの 3-D アセットの使用](https://msdn.microsoft.com/library/windows/apps/hh972446.aspx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="bee68-158">For more information, see [Using 3-D Assets in Your Game or App](https://msdn.microsoft.com/library/windows/apps/hh972446.aspx).</span></span>

## <a name="debugging-directx-graphics"></a><span data-ttu-id="bee68-159">DirectX グラフィックスのデバッグ</span><span class="sxs-lookup"><span data-stu-id="bee68-159">Debugging DirectX graphics</span></span>


<span data-ttu-id="bee68-160">Visual Studio には、グラフィックス固有のデバッグ ツールが用意されています。</span><span class="sxs-lookup"><span data-stu-id="bee68-160">Visual Studio provides graphics-specific debugging tools.</span></span> <span data-ttu-id="bee68-161">これらのツールを使って、次のような項目をデバッグします。</span><span class="sxs-lookup"><span data-stu-id="bee68-161">Use these tools to debug things like:</span></span>

-   <span data-ttu-id="bee68-162">グラフィックス パイプライン。</span><span class="sxs-lookup"><span data-stu-id="bee68-162">The graphics pipeline.</span></span>
-   <span data-ttu-id="bee68-163">イベント呼び出し履歴。</span><span class="sxs-lookup"><span data-stu-id="bee68-163">The event call stack.</span></span>
-   <span data-ttu-id="bee68-164">オブジェクト テーブル。</span><span class="sxs-lookup"><span data-stu-id="bee68-164">The object table.</span></span>
-   <span data-ttu-id="bee68-165">デバイスの状態。</span><span class="sxs-lookup"><span data-stu-id="bee68-165">The device state.</span></span>
-   <span data-ttu-id="bee68-166">シェーダーのバグ。</span><span class="sxs-lookup"><span data-stu-id="bee68-166">Shader bugs.</span></span>
-   <span data-ttu-id="bee68-167">初期化されていないか、無効な定数バッファーとパラメーター。</span><span class="sxs-lookup"><span data-stu-id="bee68-167">Uninitialized or incorrect constant buffers and parameters.</span></span>
-   <span data-ttu-id="bee68-168">DirectX バージョンの互換性。</span><span class="sxs-lookup"><span data-stu-id="bee68-168">DirectX version compatibility.</span></span>
-   <span data-ttu-id="bee68-169">制限されている Direct2D のサポート。</span><span class="sxs-lookup"><span data-stu-id="bee68-169">Limited Direct2D support.</span></span>
-   <span data-ttu-id="bee68-170">オペレーティング システムと SDK の要件。</span><span class="sxs-lookup"><span data-stu-id="bee68-170">Operating system and SDK requirements.</span></span>

<span data-ttu-id="bee68-171">詳しくは、「[DirectX グラフィックスのデバッグ](https://msdn.microsoft.com/library/windows/apps/hh315751.aspx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="bee68-171">For more information, see [Debugging DirectX Graphics](https://msdn.microsoft.com/library/windows/apps/hh315751.aspx).</span></span>


 

 

 




