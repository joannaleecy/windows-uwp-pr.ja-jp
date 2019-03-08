---
Description: 3D Manufacturing Format (3MF) のファイルの種類の構造について説明し、その作成方法と Windows.Graphics.Printing3D API による操作について説明します。
MS-HAID: dev\_devices\_sensors.generate\_3mf
MSHAttr: PreferredLib:/library/windows/apps
Search.Product: eADQiWindows 10XVcnh
title: 3MF パッケージの生成
ms.assetid: 968d918e-ec02-42b5-b50f-7c175cc7921b
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: a3615dac98c5bc8469c8c8ebc47ef718c0131844
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57653397"
---
# <a name="generate-a-3mf-package"></a><span data-ttu-id="b31bd-104">3MF パッケージの生成</span><span class="sxs-lookup"><span data-stu-id="b31bd-104">Generate a 3MF package</span></span>

<span data-ttu-id="b31bd-105">**重要な API**</span><span class="sxs-lookup"><span data-stu-id="b31bd-105">**Important APIs**</span></span>

-   [<span data-ttu-id="b31bd-106">**Windows.Graphics.Printing3D**</span><span class="sxs-lookup"><span data-stu-id="b31bd-106">**Windows.Graphics.Printing3D**</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.graphics.printing3d.aspx)

<span data-ttu-id="b31bd-107">このガイドでは、3D Manufacturing Format (3MF) ドキュメントの構造について説明し、その作成方法と [**Windows.Graphics.Printing3D**](https://msdn.microsoft.com/library/windows/apps/windows.graphics.printing3d.aspx) API による操作について説明します。</span><span class="sxs-lookup"><span data-stu-id="b31bd-107">This guide describes the structure of the 3D Manufacturing Format document and how it can be created and manipulated with the [**Windows.Graphics.Printing3D**](https://msdn.microsoft.com/library/windows/apps/windows.graphics.printing3d.aspx) API.</span></span>

## <a name="what-is-3mf"></a><span data-ttu-id="b31bd-108">3MF の概要</span><span class="sxs-lookup"><span data-stu-id="b31bd-108">What is 3MF?</span></span>

<span data-ttu-id="b31bd-109">3D Manufacturing Format (3MF) は、製造 (3D 印刷) 目的のために、XML を使って 3D モデルの外観と構造を記述するための規則のセットです。</span><span class="sxs-lookup"><span data-stu-id="b31bd-109">The 3D Manufacturing Format is a set of conventions for using XML to describe the appearance and structure of 3D models for the purpose of manufacturing (3D printing).</span></span> <span data-ttu-id="b31bd-110">3MF ではパーツ (必須なパーツとオプションのパーツがあります) のセットとそのリレーションシップを定義しています。そのねらいは 3D 製造デバイスのために必要なすべての情報を提供することです。</span><span class="sxs-lookup"><span data-stu-id="b31bd-110">It defines a set of parts (some required and some optional) and their relationships, with the goal of providing all necessary information to a 3D manufacturing device.</span></span> <span data-ttu-id="b31bd-111">3MF に準拠したデータセットは .3mf 拡張子を持つファイルとして保存できます。</span><span class="sxs-lookup"><span data-stu-id="b31bd-111">A data set that adheres to the 3D Manufacturing Format can be saved as a file with the .3mf extension.</span></span>

<span data-ttu-id="b31bd-112">Windows 10 で、 [ **Printing3D3MFPackage** ](https://msdn.microsoft.com/library/windows/apps/windows.graphics.printing3d.printing3d3mfpackage.aspx)クラス、 **Windows.Graphics.Printing3D**名前空間は、1 つ .3mf ファイルとする他のクラスのマップに似ています、ファイルの XML 要素を特定します。</span><span class="sxs-lookup"><span data-stu-id="b31bd-112">In Windows 10, the [**Printing3D3MFPackage**](https://msdn.microsoft.com/library/windows/apps/windows.graphics.printing3d.printing3d3mfpackage.aspx) class in the **Windows.Graphics.Printing3D** namespace is analogous to a single .3mf file, and other classes map to the particular XML elements in the file.</span></span> <span data-ttu-id="b31bd-113">このガイドでは、3MF ドキュメントの主なパーツのそれぞれの作成方法とプログラムによる設定方法、3MF の素材の拡張の利用方法、**Printing3D3MFPackage** オブジェクトを変換して .3mf ファイルとして保存する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="b31bd-113">This guide describes how each of the main parts of a 3MF document can be created and set programmatically, how the 3MF Materials Extension can be utilized, and how a **Printing3D3MFPackage** object can be converted and saved as a .3mf file.</span></span> <span data-ttu-id="b31bd-114">3MF および 3MF 素材の拡張の標準について詳しくは、「[3MF の仕様](https://3mf.io/what-is-3mf/3mf-specification/)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b31bd-114">For more information on the standards of 3MF or the 3MF Materials Extension, see the [3MF Specification](https://3mf.io/what-is-3mf/3mf-specification/).</span></span>

<!-- >**Note** This guide describes how to construct a 3MF document from scratch. If you wish to make changes to an already existing 3MF document provided in the form of a .3mf file, you simply need to convert it to a **Printing3D3MFPackage** and alter the contained classes/properties in the same way (see [link]) below). -->


## <a name="core-classes-in-the-3mf-structure"></a><span data-ttu-id="b31bd-115">3MF 構造体の主なクラス</span><span class="sxs-lookup"><span data-stu-id="b31bd-115">Core classes in the 3MF structure</span></span>

<span data-ttu-id="b31bd-116">**Printing3D3MFPackage** クラスは完全な 3MF ドキュメントを表します。3MF ドキュメントの中心となるのは、[**Printing3DModel**](https://msdn.microsoft.com/library/windows/apps/windows.graphics.printing3d.printing3dmodel.aspx) クラスで表される、モデル パーツです。</span><span class="sxs-lookup"><span data-stu-id="b31bd-116">The **Printing3D3MFPackage** class represents a complete 3MF document, and at the core of a 3MF document is its model part, represented by the [**Printing3DModel**](https://msdn.microsoft.com/library/windows/apps/windows.graphics.printing3d.printing3dmodel.aspx) class.</span></span> <span data-ttu-id="b31bd-117">3D モデルを指定する情報のほとんどは **Printing3DModel** クラスのプロパティおよびその基になるクラスのプロパティを設定して保存されます。</span><span class="sxs-lookup"><span data-stu-id="b31bd-117">Most of the information we wish to specify about a 3D model will be stored by setting the properties of the **Printing3DModel** class and the properties of their underlying classes.</span></span>

[!code-cs[InitClasses](./code/3dprinthowto/cs/Generate3MFMethods.cs#SnippetInitClasses)]

<!-- >**Note** We do not yet associate the **Printing3D3MFPackage** with its corresponding **Printing3DModel** object. Only after fleshing out the **Printing3DModel** with all of the information we wish to specify will we make that association (see [link]). -->

## <a name="metadata"></a><span data-ttu-id="b31bd-118">メタデータ</span><span class="sxs-lookup"><span data-stu-id="b31bd-118">Metadata</span></span>

<span data-ttu-id="b31bd-119">3MF ドキュメントのモデル パーツは、**Metadata** プロパティに保存される文字列のキー/値ペアの形式でメタデータを保持できます。</span><span class="sxs-lookup"><span data-stu-id="b31bd-119">The model part of a 3MF document can hold metadata in the form of key/value pairs of strings stored in the **Metadata** property.</span></span> <span data-ttu-id="b31bd-120">さまざまな定義済みの名前のメタデータがありますが、他のペアをパーツの拡張として追加することも可能です (詳しくは、「[3MF の仕様](https://3mf.io/what-is-3mf/3mf-specification/)」に記載されています)。</span><span class="sxs-lookup"><span data-stu-id="b31bd-120">There are a number of predefined names of metadata, but other pairs can be added as part of an extension (described in more detail in the [3MF specification](https://3mf.io/what-is-3mf/3mf-specification/)).</span></span> <span data-ttu-id="b31bd-121">メタデータの処理方法の決定はパッケージの受信者 (3D 製造デバイス) に依存しますが、できるだけ多くの基本情報を 3MF パッケージに含めることが望ましい方法です。</span><span class="sxs-lookup"><span data-stu-id="b31bd-121">It is up to the receiver of the package (a 3D manufacturing device) to determine whether and how to handle metadata, but it is good practice to include as much basic info as possible in the 3MF package:</span></span>

[!code-cs[Metadata](./code/3dprinthowto/cs/Generate3MFMethods.cs#SnippetMetadata)]

## <a name="mesh-data"></a><span data-ttu-id="b31bd-122">メッシュ データ</span><span class="sxs-lookup"><span data-stu-id="b31bd-122">Mesh data</span></span>

<span data-ttu-id="b31bd-123">このガイドにおいては、メッシュとは、頂点のセットから作成される 3 次元形状のボディを意味します (必ずしも 1 つの立体として見えるとは限りません)。</span><span class="sxs-lookup"><span data-stu-id="b31bd-123">In the context of this guide, a mesh is a body of 3-dimensional geometry constructed from a single set of vertices (though it does not have to appear as a single solid).</span></span> <span data-ttu-id="b31bd-124">メッシュ パーツは [**Printing3DMesh**](https://msdn.microsoft.com/library/windows/apps/windows.graphics.printing3d.printing3dmesh.aspx) クラスで表されます。</span><span class="sxs-lookup"><span data-stu-id="b31bd-124">A mesh part is represented by the [**Printing3DMesh**](https://msdn.microsoft.com/library/windows/apps/windows.graphics.printing3d.printing3dmesh.aspx) class.</span></span> <span data-ttu-id="b31bd-125">有効なメッシュ オブジェクトは、すべての頂点の位置、およびいくつかの頂点のセットの間に存在する三角形の表面についての情報を含む必要があります。</span><span class="sxs-lookup"><span data-stu-id="b31bd-125">A valid mesh object must contain information about the location of all of its vertices as well as all the triangle faces that exist between certain sets of vertices.</span></span>

<span data-ttu-id="b31bd-126">次のメソッドは、メッシュに頂点を追加して、3D 空間での位置を与えます。</span><span class="sxs-lookup"><span data-stu-id="b31bd-126">The following method adds vertices to a mesh and then gives them locations in 3D space:</span></span>

[!code-cs[Vertices](./code/3dprinthowto/cs/Generate3MFMethods.cs#SnippetVertices)]

<span data-ttu-id="b31bd-127">次のメソッドは、頂点間で描画されるすべての三角形を定義します。</span><span class="sxs-lookup"><span data-stu-id="b31bd-127">The next method defines all of the triangles to be drawn across these vertices:</span></span>

[!code-cs[TriangleIndices](./code/3dprinthowto/cs/Generate3MFMethods.cs#SnippetTriangleIndices)]

> [!NOTE]
> <span data-ttu-id="b31bd-128">すべての三角形では、(三角形をメッシュ オブジェクトの外側から見て) 反時計回りでインデックスを定義する必要があります。これにより、表面の法線ベクトルが外側に向きます。</span><span class="sxs-lookup"><span data-stu-id="b31bd-128">All triangles must have their indices defined in counter-clockwise order (when viewing the triangle from outside of the mesh object), so that their face-normal vectors point outward.</span></span>

<span data-ttu-id="b31bd-129">Printing3DMesh オブジェクトが頂点と三角形の有効なセットを含む場合、それはモデルの **Meshes** プロパティに追加される必要があります。</span><span class="sxs-lookup"><span data-stu-id="b31bd-129">When a Printing3DMesh object contains valid sets of vertices and triangles, it should then be added to the model's **Meshes** property.</span></span> <span data-ttu-id="b31bd-130">パッケージに含まれるすべての **Printing3DMesh** オブジェクトは、**Printing3DModel** クラスの **Meshes** プロパティの下に保存される必要があります。</span><span class="sxs-lookup"><span data-stu-id="b31bd-130">All **Printing3DMesh** objects in a package must be stored under the **Meshes** property of the **Printing3DModel** class.</span></span>

[!code-cs[MeshAdd](./code/3dprinthowto/cs/Generate3MFMethods.cs#SnippetMeshAdd)]


## <a name="create-materials"></a><span data-ttu-id="b31bd-131">素材の作成</span><span class="sxs-lookup"><span data-stu-id="b31bd-131">Create materials</span></span>


<span data-ttu-id="b31bd-132">3D モデルは複数の素材のデータを保持できます。</span><span class="sxs-lookup"><span data-stu-id="b31bd-132">A 3D model can hold data for multiple materials.</span></span> <span data-ttu-id="b31bd-133">この規則は、1 回の印刷ジョブで複数の素材を使用できる 3D 製造デバイスを活用するためのものです。</span><span class="sxs-lookup"><span data-stu-id="b31bd-133">This convention is intended to take advantage of 3D manufacturing devices that can use multiple materials on a single print job.</span></span> <span data-ttu-id="b31bd-134">また複数の*種類*の素材グループがあり、それぞれがさまざまな個々の素材をサポートできます。</span><span class="sxs-lookup"><span data-stu-id="b31bd-134">There are also multiple *types* of material gropus, each one capable of supporting a number of different individual materals.</span></span> <span data-ttu-id="b31bd-135">各素材グループは一意の参照 ID 番号を持つ必要があります。グループ内の各素材も一意の ID を持つ必要があります。</span><span class="sxs-lookup"><span data-stu-id="b31bd-135">Each material group must have a unique reference id number, and each material within that group must also have a unique id.</span></span>

<span data-ttu-id="b31bd-136">これにより、モデル内の別のメッシュ オブジェクトがこれらの素材を参照できます。</span><span class="sxs-lookup"><span data-stu-id="b31bd-136">The different mesh objects within a model can then reference these materials.</span></span> <span data-ttu-id="b31bd-137">さらに、各メッシュの個々の三角形は、別の素材を指定できます。</span><span class="sxs-lookup"><span data-stu-id="b31bd-137">Furthermore, individual triangles on each mesh can specify different materials.</span></span> <span data-ttu-id="b31bd-138">また、1 つの三角形内で別の素材が表され、三角形の各頂点が別の素材に割り当てられて、表面の素材はそれらのグラデーションとして計算されることさえも可能です。</span><span class="sxs-lookup"><span data-stu-id="b31bd-138">Further still, different materials can even be represented within a single triangle, with each triangle vertex having a different material assigned to it and the face material calculated as the gradient between them.</span></span>

<span data-ttu-id="b31bd-139">このガイドではまず、異なる種類の素材をそれぞれの素材グループ内に作成して、それをモデル オブジェクトのリソースとして保存する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="b31bd-139">This guide will first show how to create different kinds of materials within their respective material groups and store them as resources on the model object.</span></span> <span data-ttu-id="b31bd-140">次に、個々のメッシュと個々の三角形に別の素材を割り当てます。</span><span class="sxs-lookup"><span data-stu-id="b31bd-140">Then, we will go about assigning different materials to individual meshes and individual triangles.</span></span>

### <a name="base-materials"></a><span data-ttu-id="b31bd-141">Base materials</span><span class="sxs-lookup"><span data-stu-id="b31bd-141">Base materials</span></span>

<span data-ttu-id="b31bd-142">既定の素材の種類は **Base Material** です。これは **Color Material** 値 (下記を参照) と名前属性を持ちます。これは使用する素材の*種類*を指定するために使用します。</span><span class="sxs-lookup"><span data-stu-id="b31bd-142">The default material type is **Base Material**, which has both a **Color Material** value (described below) and a name attribute that is intended to specify the *type* of material to use.</span></span>

[!code-cs[BaseMaterialGroup](./code/3dprinthowto/cs/Generate3MFMethods.cs#SnippetBaseMaterialGroup)]

> [!NOTE]
><span data-ttu-id="b31bd-143"> 3D の製造デバイスでは、仮想の数量単価型の要素が、3MF に保存されている、使用可能な物理マテリアルのマップを決定します。</span><span class="sxs-lookup"><span data-stu-id="b31bd-143"> The 3D manufacturing device will determine which available physical materials map to which virtual material elements stored in the 3MF.</span></span> <span data-ttu-id="b31bd-144">素材のマッピングは 1:1 とは限りません。3D プリンターが 1 つの素材のみを使用できる場合、オブジェクトや表面が別の素材に割り当てられている場合でも、全モデルをその素材で印刷します。</span><span class="sxs-lookup"><span data-stu-id="b31bd-144">Material mapping doesn't have to be 1:1: if a 3D printer only uses one material, it will print the whole model in that material, regardless of which objects or faces were assigned different materials.</span></span>

### <a name="color-materials"></a><span data-ttu-id="b31bd-145">Color Materials</span><span class="sxs-lookup"><span data-stu-id="b31bd-145">Color materials</span></span>

<span data-ttu-id="b31bd-146">**Color Materials** は **Base Materials** に似ていますが、名前は含まれません。</span><span class="sxs-lookup"><span data-stu-id="b31bd-146">**Color Materials** are similar to **Base Materials**, but they do not contain a name.</span></span> <span data-ttu-id="b31bd-147">そのため、マシンが使用する素材の種類を指定できません。</span><span class="sxs-lookup"><span data-stu-id="b31bd-147">Thus, they give no instructions as to what type of material should be used by the machine.</span></span> <span data-ttu-id="b31bd-148">色のデータのみを保持し、マシンが素材の種類を選択します (マシンがユーザーに選択を求める場合もあります)。</span><span class="sxs-lookup"><span data-stu-id="b31bd-148">They hold only color data, and let the machine choose the material type (and the machine may then prompt the user to choose).</span></span> <span data-ttu-id="b31bd-149">次のコードでは、以前のメソッドからの `colrMat` オブジェクトが使用されています。</span><span class="sxs-lookup"><span data-stu-id="b31bd-149">In the code below, the `colrMat` objects from the previous method are used on their own.</span></span>

[!code-cs[ColorMaterialGroup](./code/3dprinthowto/cs/Generate3MFMethods.cs#SnippetColorMaterialGroup)]

### <a name="composite-materials"></a><span data-ttu-id="b31bd-150">複合素材</span><span class="sxs-lookup"><span data-stu-id="b31bd-150">Composite materials</span></span>

<span data-ttu-id="b31bd-151">**Composite Materials** は製造デバイスに、さまざまな **Base Materials** を一定の組み合わせで使用するように指示します。</span><span class="sxs-lookup"><span data-stu-id="b31bd-151">**Composite Materials** simply instruct the manufacturing device to use a uniform mixture of different **Base Materials**.</span></span> <span data-ttu-id="b31bd-152">各 **Composite Material Group** は材料を使う 1 つの **Base Material Group** のみを参照する必要があります。</span><span class="sxs-lookup"><span data-stu-id="b31bd-152">Each **Composite Material Group** must reference exactly one **Base Material Group** from which to draw ingredients.</span></span> <span data-ttu-id="b31bd-153">さらに、このグループ内で利用できる **Base Materials** は **Material Indices** の一覧にリストされている必要があります。これは比率を指定する際に各 **Composite Material** によって参照されます (すべての **Composite Material** は単に **Base Materials** の比率です)。</span><span class="sxs-lookup"><span data-stu-id="b31bd-153">Additonally, the **Base Materials** within this group that are to be made available must be listed out in a **Material Indices** list, which each **Composite Material** will then reference when specifying the ratios (every **Composite Material** is simply a ratio of **Base Materials**).</span></span>

[!code-cs[CompositeMaterialGroup](./code/3dprinthowto/cs/Generate3MFMethods.cs#SnippetCompositeMaterialGroup)]

### <a name="texture-coordinate-materials"></a><span data-ttu-id="b31bd-154">テクスチャ座標の素材</span><span class="sxs-lookup"><span data-stu-id="b31bd-154">Texture coordinate materials</span></span>

<span data-ttu-id="b31bd-155">3MF は 2D 画像を使って 3D モデルの表面に色を付けることをサポートします。</span><span class="sxs-lookup"><span data-stu-id="b31bd-155">3MF supports the use of 2D images to color the surfaces of 3D models.</span></span> <span data-ttu-id="b31bd-156">これによりモデルは、三角形の表面ごとに、より多くの色データを伝えることができます (三角形の頂点ごとに 1 つの色の値を持つ場合と比べて)。</span><span class="sxs-lookup"><span data-stu-id="b31bd-156">This way, the model can convey much more color data per triangle face (as opposed to having just one color value per triangle vertex).</span></span> <span data-ttu-id="b31bd-157">**Color Materials** と同様に、テクスチャ座標の素材は色データのみを伝えます。</span><span class="sxs-lookup"><span data-stu-id="b31bd-157">Like **Color Materials**, texture coordinate materials only convery color data.</span></span> <span data-ttu-id="b31bd-158">2D テクスチャを使うには、まずテクスチャ リソースを宣言する必要があります。</span><span class="sxs-lookup"><span data-stu-id="b31bd-158">To use a 2D texture, a texture resource must first be declared:</span></span>

[!code-cs[TextureResource](./code/3dprinthowto/cs/Generate3MFMethods.cs#SnippetTextureResource)]

> [!NOTE]
> <span data-ttu-id="b31bd-159">テクスチャ データは、パッケージ内のモデル パーツでなく、3MF パッケージ自体に属しています。</span><span class="sxs-lookup"><span data-stu-id="b31bd-159">Texture data belongs to the 3MF Package itself, not to the model part within the package.</span></span>

<span data-ttu-id="b31bd-160">次に **Texture3Coord Materials** を記入する必要があります。</span><span class="sxs-lookup"><span data-stu-id="b31bd-160">Next, we must fill out **Texture3Coord Materials**.</span></span> <span data-ttu-id="b31bd-161">これらはそれぞれテクスチャ リソースを参照し、画像の特定の点を (UV 座標で) 指定します。</span><span class="sxs-lookup"><span data-stu-id="b31bd-161">Each of these references a texture resource and specifies a particular point on the image (in UV coordinates).</span></span>

[!code-cs[Texture2CoordMaterialGroup](./code/3dprinthowto/cs/Generate3MFMethods.cs#SnippetTexture2CoordMaterialGroup)]

## <a name="map-materials-to-faces"></a><span data-ttu-id="b31bd-162">素材を表面にマップ</span><span class="sxs-lookup"><span data-stu-id="b31bd-162">Map materials to faces</span></span>

<span data-ttu-id="b31bd-163">素材と各三角形の頂点のマッピングを指定するには、モデルのメッシュ オブジェクトにさらに処理を行う必要があります (モデルに複数のメッシュが含まれる場合、それぞれに素材が割り当てられる必要があります)。</span><span class="sxs-lookup"><span data-stu-id="b31bd-163">In order to dictate which materials are mapped to which vertices on each triangle, we must do some more work on the mesh object of our model (if a model contains multiple meshes, they must each have their materials assigned separately).</span></span> <span data-ttu-id="b31bd-164">既に説明したように、素材は頂点ごと、三角形ごとに割り当てられます。</span><span class="sxs-lookup"><span data-stu-id="b31bd-164">As mentioned above, materials are assigned per-vertex, per-triangle.</span></span> <span data-ttu-id="b31bd-165">次のコードを参照して、この情報の入力と解釈の方法を確認します。</span><span class="sxs-lookup"><span data-stu-id="b31bd-165">Refer to the code below to see how this information is entered and interpreted.</span></span>

[!code-cs[MaterialIndices](./code/3dprinthowto/cs/Generate3MFMethods.cs#SnippetMaterialIndices)]

## <a name="components-and-build"></a><span data-ttu-id="b31bd-166">Component とビルド</span><span class="sxs-lookup"><span data-stu-id="b31bd-166">Components and build</span></span>

<span data-ttu-id="b31bd-167">Component 構造体により、ユーザーは印刷可能な 3D モデルに複数のメッシュ オブジェクトを配置できます。</span><span class="sxs-lookup"><span data-stu-id="b31bd-167">The component structure allows the user to place more than one mesh object in a printable 3D model.</span></span> <span data-ttu-id="b31bd-168">[  **Printing3DComponent**](https://msdn.microsoft.com/library/windows/apps/windows.graphics.printing3d.printing3dcomponent.aspx) オブジェクトには、1 つのメッシュと他のコンポーネントへの参照のリストが含まれています。</span><span class="sxs-lookup"><span data-stu-id="b31bd-168">A [**Printing3DComponent**](https://msdn.microsoft.com/library/windows/apps/windows.graphics.printing3d.printing3dcomponent.aspx) object contains a single mesh and a list of references to other components.</span></span> <span data-ttu-id="b31bd-169">これは実際には、[**Printing3DComponentWithMatrix**](https://msdn.microsoft.com/library/windows/apps/windows.graphics.printing3d.printing3dcomponentwithmatrix.aspx) オブジェクトのリストです。</span><span class="sxs-lookup"><span data-stu-id="b31bd-169">This is actually a list of [**Printing3DComponentWithMatrix**](https://msdn.microsoft.com/library/windows/apps/windows.graphics.printing3d.printing3dcomponentwithmatrix.aspx) objects.</span></span> <span data-ttu-id="b31bd-170">各 **Printing3DComponentWithMatrix** オブジェクトには **Printing3DComponent** が含まれ、また重要なことに、メッシュと **Printing3DComponent** に含まれるコンポーネントに適用される変換マトリックスが含まれます。</span><span class="sxs-lookup"><span data-stu-id="b31bd-170">**Printing3DComponentWithMatrix** objects each contain a **Printing3DComponent** and, importantly, a transform matrix that applies to the mesh and contained components of said **Printing3DComponent**.</span></span>

<span data-ttu-id="b31bd-171">たとえば、自動車のモデルは、車のボディのメッシュを保持する、1 つの "ボディ" **Printing3DComponent** から構成されることができます。</span><span class="sxs-lookup"><span data-stu-id="b31bd-171">For example, a model of a car might consist of a "Body" **Printing3DComponent** that holds the mesh for the car's body.</span></span> <span data-ttu-id="b31bd-172">この場合、"ボディ" コンポーネントには、4 つの異なる **Printing3DComponentWithMatrix** オブジェクトへの参照が含まれ、そのすべてが、"車輪" メッシュを持つ、同じ **Printing3DComponent** を参照し、4 つの異なる変換マトリックスを含みます (これにより、車輪を車のボディの 4 つの異なる位置にマッピングします)。</span><span class="sxs-lookup"><span data-stu-id="b31bd-172">The "Body" component may then contain references to four different **Printing3DComponentWithMatrix** objects, which all reference the same **Printing3DComponent** with the "Wheel" mesh and contain four different transform matrices (mapping the wheels to four different positions on the car's body).</span></span> <span data-ttu-id="b31bd-173">このシナリオでは、最終製品には合計 5 つのメッシュが含まれる場合でも、"ボディ" メッシュと "車輪" メッシュはそれぞれ 1 度だけ保存される必要があります。</span><span class="sxs-lookup"><span data-stu-id="b31bd-173">In this scenario, the "Body" mesh and "Wheel" mesh would each only need to be stored once, even though the final product would feature five meshes in total.</span></span>

<span data-ttu-id="b31bd-174">すべての **Printing3DComponent** オブジェクトはモデルの **Components** プロパティで直接参照される必要があります。</span><span class="sxs-lookup"><span data-stu-id="b31bd-174">All **Printing3DComponent** objects must be directly referenced in the model's **Components** property.</span></span> <span data-ttu-id="b31bd-175">印刷ジョブで使用される 1 つの特定のコンポーネントは **Build** プロパティに保存されています。</span><span class="sxs-lookup"><span data-stu-id="b31bd-175">The one particular component that is to be used in the printing job is stored in the **Build** Property.</span></span>

[!code-cs[Components](./code/3dprinthowto/cs/Generate3MFMethods.cs#SnippetComponents)]

## <a name="save-package"></a><span data-ttu-id="b31bd-176">パッケージの保存</span><span class="sxs-lookup"><span data-stu-id="b31bd-176">Save package</span></span>
<span data-ttu-id="b31bd-177">素材とコンポーネントを定義したモデルが完成したので、それをパッケージに保存します。</span><span class="sxs-lookup"><span data-stu-id="b31bd-177">Now that we have a model, with defined materials and components, we can save it to the package.</span></span>

[!code-cs[SavePackage](./code/3dprinthowto/cs/Generate3MFMethods.cs#SnippetSavePackage)]

<span data-ttu-id="b31bd-178">ここでは、アプリ内から印刷ジョブを開始するか (「[アプリからの 3D 印刷](https://msdn.microsoft.com/library/windows/apps/mt204541.aspx)」をご覧ください)、またはこの **Printing3D3MFPackage** を .3mf ファイルとして保存します。</span><span class="sxs-lookup"><span data-stu-id="b31bd-178">From here, we can either initiate a print job within the app (see [3D printing from your app](https://msdn.microsoft.com/library/windows/apps/mt204541.aspx)), or save this **Printing3D3MFPackage** as a .3mf file.</span></span>

<span data-ttu-id="b31bd-179">次のメソッドは、完成した **Printing3D3MFPackage** を取得して、そのデータを .3mf ファイルに保存します。</span><span class="sxs-lookup"><span data-stu-id="b31bd-179">The following method takes a finished **Printing3D3MFPackage** and saves its data to a .3mf file.</span></span>

[!code-cs[SaveTo3mf](./code/3dprinthowto/cs/Generate3MFMethods.cs#SnippetSaveTo3mf)]

## <a name="related-topics"></a><span data-ttu-id="b31bd-180">関連トピック</span><span class="sxs-lookup"><span data-stu-id="b31bd-180">Related topics</span></span>

[<span data-ttu-id="b31bd-181">アプリの 3D 印刷</span><span class="sxs-lookup"><span data-stu-id="b31bd-181">3D printing from your app</span></span>](https://msdn.microsoft.com/windows/uwp/devices-sensors/3d-print-from-app)  
[<span data-ttu-id="b31bd-182">3D 印刷 UWP サンプル</span><span class="sxs-lookup"><span data-stu-id="b31bd-182">3D printing UWP sample</span></span>](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/3DPrinting)
 

 

 
