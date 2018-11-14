---
title: ブロック圧縮
description: ブロック圧縮は、テクスチャ サイズとメモリ フットプリントを減らしてパフォーマンスを向上させる、不可逆のテクスチャ圧縮技術です。 ブロック圧縮テクスチャは、1 色あたり 32 ビットのテクスチャより小さくすることができます。
ms.assetid: 2FAD6BE8-C6E4-4112-AF97-419CD27F7C73
keywords:
- ブロック圧縮
author: hickeys
ms.author: hickeys
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 8ff4c88a46c1e89df96b48d82da333432790e461
ms.sourcegitcommit: 4d88adfaf544a3dab05f4660e2f59bbe60311c00
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/13/2018
ms.locfileid: "6461879"
---
# <a name="block-compression"></a><span data-ttu-id="c3ce8-105">ブロック圧縮</span><span class="sxs-lookup"><span data-stu-id="c3ce8-105">Block compression</span></span>

<span data-ttu-id="c3ce8-106">ブロック圧縮は、テクスチャ サイズとメモリ フットプリントを減らしてパフォーマンスを向上させる、不可逆のテクスチャ圧縮技術です。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-106">Block compression is a lossy texture-compression technique for reducing texture size and memory footprint, giving a performance increase.</span></span> <span data-ttu-id="c3ce8-107">ブロック圧縮テクスチャは、1 色あたり 32 ビットのテクスチャより小さくすることができます。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-107">A block-compressed texture can be smaller than a texture with 32-bits per color.</span></span>

<span data-ttu-id="c3ce8-108">ブロック圧縮とは、テクスチャ サイズを減少させるテクスチャの圧縮方法です。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-108">Block compression is a texture compression technique for reducing texture size.</span></span> <span data-ttu-id="c3ce8-109">各色 32 ビットのテクスチャと比較すると、ブロック圧縮されたテクスチャは最大 75% 縮小できます。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-109">When compared to a texture with 32-bits per color, a block-compressed texture can be up to 75 percent smaller.</span></span> <span data-ttu-id="c3ce8-110">ブロック圧縮を使用すると、メモリ フットプリントが小さくなり、アプリケーションでは通常、パフォーマンスが向上します。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-110">Applications usually see a performance increase when using block compression because of the smaller memory footprint.</span></span>

<span data-ttu-id="c3ce8-111">ブロック圧縮は不可逆圧縮ですが、効果的であり、パイプラインで変換およびフィルターされたすべてのテクスチャに推奨されます。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-111">While lossy, block compression works well and is recommended for all textures that get transformed and filtered by the pipeline.</span></span> <span data-ttu-id="c3ce8-112">画面に直接マッピングされるテクスチャ (アイコンやテキストのような UI 要素) は、処理結果が比較的目立つので、圧縮にはあまり適していません。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-112">Textures that are directly mapped to the screen (UI elements like icons and text) are not good choices for compression because artifacts are more noticeable.</span></span>

<span data-ttu-id="c3ce8-113">ブロック圧縮されたテクスチャは、すべての次元で 4 の倍数のサイズで作成する必要があります。またパイプラインの出力として使用することはできません。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-113">A block-compressed texture must be created as a multiple of size 4 in all dimensions and cannot be used as an output of the pipeline.</span></span>

## <a name="span-idbasicsspanspan-idbasicsspanspan-idbasicsspanhow-block-compression-works"></a><span data-ttu-id="c3ce8-114"><span id="Basics"></span><span id="basics"></span><span id="BASICS"></span>ブロック圧縮のしくみ</span><span class="sxs-lookup"><span data-stu-id="c3ce8-114"><span id="Basics"></span><span id="basics"></span><span id="BASICS"></span>How block compression works</span></span>

<span data-ttu-id="c3ce8-115">ブロック圧縮は、カラー データの保存に必要なメモリの量を減少させるための方法です。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-115">Block compression is a technique for reducing the amount of memory required to store color data.</span></span> <span data-ttu-id="c3ce8-116">ある色を元のサイズで保存し、他の色をエンコード スキームを使用して保存することにより、その画像の保存に必要なメモリの量を大幅に減少させることができます。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-116">By storing some colors in their original size, and other colors using an encoding scheme, you can dramatically reduce the amount of memory required to store the image.</span></span> <span data-ttu-id="c3ce8-117">圧縮されたデータはハードウェアが自動的にデコードするので、圧縮されたテクスチャを使用しても、パフォーマンスの損失は発生しません。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-117">Since the hardware automatically decodes compressed data, there is no performance penalty for using compressed textures.</span></span>

<span data-ttu-id="c3ce8-118">圧縮がどのように行われるかについては、以下の 2 つの例を参照してください。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-118">To see how compression works, look at the following two examples.</span></span> <span data-ttu-id="c3ce8-119">最初の例では、圧縮されないデータを保存する際に使用されるメモリの量について説明します。2 番目の例では、圧縮されたデータを保存する際に使用されるメモリの量について説明します。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-119">The first example describes the amount of memory used when storing uncompressed data; the second example describes the amount of memory used when storing compressed data.</span></span>

- [<span data-ttu-id="c3ce8-120">圧縮されないデータの保存</span><span class="sxs-lookup"><span data-stu-id="c3ce8-120">Storing uncompressed data</span></span>](#storing-uncompressed-data)
- [<span data-ttu-id="c3ce8-121">圧縮されたデータの保存</span><span class="sxs-lookup"><span data-stu-id="c3ce8-121">Storing compressed data</span></span>](#storing-compressed-data)

### <a name="span-idstoringuncompresseddataspanspan-idstoringuncompresseddataspanspan-idstoringuncompresseddataspanspan-idstoring-uncompressed-dataspanstoring-uncompressed-data"></a><span data-ttu-id="c3ce8-122"><span id="Storing_Uncompressed_Data"></span><span id="storing_uncompressed_data"></span><span id="STORING_UNCOMPRESSED_DATA"></span><span id="storing-uncompressed-data"></span>圧縮されないデータの保存</span><span class="sxs-lookup"><span data-stu-id="c3ce8-122"><span id="Storing_Uncompressed_Data"></span><span id="storing_uncompressed_data"></span><span id="STORING_UNCOMPRESSED_DATA"></span><span id="storing-uncompressed-data"></span>Storing uncompressed data</span></span>

<span data-ttu-id="c3ce8-123">以下のイメージは、圧縮されていない 4x4 のテクスチャを表しています。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-123">The following illustration represents an uncompressed 4×4 texture.</span></span> <span data-ttu-id="c3ce8-124">各色には、単一のカラー成分 (たとえば赤) が含まれ、1 バイトのメモリに保存されているとします。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-124">Assume that each color contains a single color component (red for instance) and is stored in one byte of memory.</span></span>

![圧縮されていない 4 x 4 のテクスチャ](images/d3d10-block-compress-1.png)

<span data-ttu-id="c3ce8-126">圧縮されていないデータはメモリに順次レイアウトされ、以下のイメージに示すように、16 バイト必要となります。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-126">The uncompressed data is laid out in memory sequentially and requires 16 bytes, as shown in the following illustration.</span></span>

![シーケンシャル メモリ内の圧縮されていないデータ](images/d3d10-block-compress-2.png)

### <a name="span-idstoringcompresseddataspanspan-idstoringcompresseddataspanspan-idstoringcompresseddataspanspan-idstoring-compressed-dataspanstoring-compressed-data"></a><span data-ttu-id="c3ce8-128"><span id="Storing_Compressed_Data"></span><span id="storing_compressed_data"></span><span id="STORING_COMPRESSED_DATA"></span><span id="storing-compressed-data"></span>圧縮されたデータの保存</span><span class="sxs-lookup"><span data-stu-id="c3ce8-128"><span id="Storing_Compressed_Data"></span><span id="storing_compressed_data"></span><span id="STORING_COMPRESSED_DATA"></span><span id="storing-compressed-data"></span>Storing compressed data</span></span>

<span data-ttu-id="c3ce8-129">圧縮されていないイメージがどれぐらいの量のメモリを使用するかを理解したところで、圧縮されたイメージがどれだけ多くのメモリを使わずに済むかを説明します。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-129">Now that you've seen how much memory an uncompressed image uses, take a look at how much memory a compressed image saves.</span></span> <span data-ttu-id="c3ce8-130">[BC1](#bc1)圧縮形式では、2 つの色 (各 1 バイト) と、テクスチャ内の元の色の補間に使用される 16 個の 3 ビット インデックス (48 ビット、または 6 バイト) を保存します。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-130">The [BC1](#bc1) compression format stores 2 colors (1 byte each) and 16 3-bit indices (48 bits, or 6 bytes) that are used to interpolate the original colors in the texture, as shown in the following illustration.</span></span>

![BC1 圧縮形式](images/d3d10-block-compress-3.png)

<span data-ttu-id="c3ce8-132">圧縮されたデータを保存するのに必要な領域の合計は 8 バイトで、圧縮されていない例に比べて 50% のメモリを使用せずに済んでいます。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-132">The total space required to store the compressed data is 8 bytes which is a 50-percent memory savings over the uncompressed example.</span></span> <span data-ttu-id="c3ce8-133">1 つ以上のカラー成分を使用する場合、使用せずに済む量はさらに多くなります。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-133">The savings are even larger when more than one color component is used.</span></span>

<span data-ttu-id="c3ce8-134">ブロック圧縮によってかなりの量のメモリを使用せずに済むことで、パフォーマンスの向上につなげることができます。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-134">The substantial memory savings provided by block compression can lead to an increase in performance.</span></span> <span data-ttu-id="c3ce8-135">このパフォーマンスは、イメージの画質の代償として得られるものですが (色の補間による)、多くの場合、画質の低下は顕著ではありません。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-135">This performance comes at the cost of image quality (due to color interpolation); however, the lower quality is often not noticeable.</span></span>

<span data-ttu-id="c3ce8-136">次のセクションでは、Direct3D を使用して、アプリケーションでブロック圧縮を簡単に使用する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-136">The next section shows how Direct3D enables using block compression in an application.</span></span>

## <a name="span-idusingblockcompressionspanspan-idusingblockcompressionspanspan-idusingblockcompressionspanusing-block-compression"></a><span data-ttu-id="c3ce8-137"><span id="Using_Block_Compression"></span><span id="using_block_compression"></span><span id="USING_BLOCK_COMPRESSION"></span>ブロック圧縮の使用</span><span class="sxs-lookup"><span data-stu-id="c3ce8-137"><span id="Using_Block_Compression"></span><span id="using_block_compression"></span><span id="USING_BLOCK_COMPRESSION"></span>Using block compression</span></span>

<span data-ttu-id="c3ce8-138">ブロック圧縮形式を指定すること以外は、圧縮されないテクスチャと同様に、ブロック圧縮テクスチャを作成します。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-138">Create a block-compressed texture just like an uncompressed texture except that you specify a block-compressed format.</span></span>

<span data-ttu-id="c3ce8-139">次に、ビューを作成して、テクスチャをパイプラインにバインドします。ブロック圧縮されたテクスチャはシェーダー ステージへの入力としてのみ使用できるので、シェーダー リソース ビューを作成します。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-139">Next, create a view to bind the texture to the pipeline Since a block-compressed texture can be used only as an input to a shader-stage, you want to create a shader-resource view.</span></span>

<span data-ttu-id="c3ce8-140">ブロック圧縮されたテクスチャを、圧縮されていないテクスチャを使用する場合と同様に使用します。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-140">Use a block compressed texture the same way you would use an uncompressed texture.</span></span> <span data-ttu-id="c3ce8-141">アプリケーションがブロック圧縮データへのメモリ ポインターを取得する場合は、ミップマップのメモリ パディングを考慮する必要があります。このメモリ パディングは、宣言されたサイズが実際のサイズと異なる原因となります。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-141">If your application will get a memory pointer to block-compressed data, you need to account for the memory padding in a mipmap that causes the declared size to differ from the actual size.</span></span>

- [<span data-ttu-id="c3ce8-142">仮想サイズ対物理サイズ</span><span class="sxs-lookup"><span data-stu-id="c3ce8-142">Virtual size versus physical size</span></span>](#virtual-size-versus-physical-size)

### <a name="span-idvirtualsizespanspan-idvirtualsizespanspan-idvirtualsizespanspan-idvirtual-size-versus-physical-sizespanvirtual-size-versus-physical-size"></a><span data-ttu-id="c3ce8-143"><span id="Virtual_Size"></span><span id="virtual_size"></span><span id="VIRTUAL_SIZE"></span><span id="virtual-size-versus-physical-size"></span>仮想サイズ対物理サイズ</span><span class="sxs-lookup"><span data-stu-id="c3ce8-143"><span id="Virtual_Size"></span><span id="virtual_size"></span><span id="VIRTUAL_SIZE"></span><span id="virtual-size-versus-physical-size"></span>Virtual size versus physical size</span></span>

<span data-ttu-id="c3ce8-144">メモリ ポインターを使用して、ブロック圧縮されたテクスチャのメモリを扱うアプリケーション コードがある場合、アプリケーション コードの変更が必要となる可能性がある重要な考慮事項が 1 つあります。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-144">If you have application code that uses a memory pointer to walk the memory of a block compressed texture, there is one important consideration that may require a modification in your application code.</span></span> <span data-ttu-id="c3ce8-145">ブロック圧縮アルゴリズムは 4 x 4 のテクセル ブロックで処理するため、ブロック圧縮されたテクスチャはすべての次元で 4 の倍数である必要があります。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-145">A block-compressed texture must be a multiple of 4 in all dimensions because the block-compression algorithms operate on 4x4 texel blocks.</span></span> <span data-ttu-id="c3ce8-146">これは、最初の次元が 4 で割り切れるが、さらに分割すると 4 で割り切れなくなるミップマップでは問題となります。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-146">This will be a problem for a mipmap whose initial dimensions are divisible by 4, but subdivided levels are not.</span></span> <span data-ttu-id="c3ce8-147">以下の図は、各ミップマップ レベルの仮想サイズ (宣言されたサイズ) と物理サイズ (実際のサイズ) の間の領域の違いを示しています。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-147">The following diagram shows the difference in area between the virtual (declared) size and the physical (actual) size of each mipmap level.</span></span>

![圧縮されていないミップマップ レベル対圧縮されたミップマップ レベル](images/d3d10-block-compress-pad.png)

<span data-ttu-id="c3ce8-149">図の左側は、圧縮されていない 60 x 40 のテクスチャに対して生成されるミップマップ レベル サイズを示しています。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-149">The left side of the diagram shows the mipmap level sizes that are generated for an uncompressed 60×40 texture.</span></span> <span data-ttu-id="c3ce8-150">最上位レベルのサイズは、テクスチャを生成する API 呼び出しから取得されます。後続の各レベルは、前のレベルのサイズの半分になります。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-150">The top level size is taken from the API call that generates the texture; each subsequent level is half the size of the previous level.</span></span> <span data-ttu-id="c3ce8-151">圧縮されていないテクスチャでは、仮想サイズ (宣言されたサイズ) と物理サイズ (実際のサイズ) との間で差はありません。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-151">For an uncompressed texture, there is no difference between the virtual (declared) size and the physical (actual) size.</span></span>

<span data-ttu-id="c3ce8-152">図の右側は、圧縮された 60 x 40 のテクスチャに対して生成されるミップマップ レベル サイズを示しています。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-152">The right side of the diagram shows the mipmap level sizes that are generated for the same 60×40 texture with compression.</span></span> <span data-ttu-id="c3ce8-153">2 番目と 3 番目のレベルにはどちらも、各レベルのサイズが 4 で割り切れるように、メモリ パディングが追加されていることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-153">Notice that both the second and third levels have memory padding to make the sizes factors of 4 on every level.</span></span> <span data-ttu-id="c3ce8-154">これは、アルゴリズムが 4 x 4 のテクセル ブロックで処理できるようにするために必要です。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-154">This is necessary so that the algorithms can operate on 4×4 texel blocks.</span></span> <span data-ttu-id="c3ce8-155">4 x 4 よりも小さいミップマップ レベルを考慮する場合、これは特に明白です。これらの非常に小さいミップマップ レベルのサイズは、テクスチャ メモリが割り当てられる際、4 を因数とする最も近い数に切り上げられます。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-155">This is expecially evident if you consider mipmap levels that are smaller than 4×4; the size of these very small mipmap levels will be rounded up to the nearest factor of 4 when texture memory is allocated.</span></span>

<span data-ttu-id="c3ce8-156">サンプリング ハードウェアは仮想サイズを使用します。テクスチャがサンプリングされる際、メモリ パディングは無視されます。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-156">Sampling hardware uses the virtual size; when the texture is sampled, the memory padding is ignored.</span></span> <span data-ttu-id="c3ce8-157">4 x 4 よりも小さいミップマップ レベルでは、最初の 4 つのテクセルのみが 2 x 2 のマップに使用され、最初のテクセルのみが 1 x 1 のブロックで使用されます。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-157">For mipmap levels that are smaller than 4×4, only the first four texels will be used for a 2×2 map, and only the first texel will be used by a 1×1 block.</span></span> <span data-ttu-id="c3ce8-158">ただし、物理サイズ (メモリ パディングを含む) を明らかにする API 構造はありません。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-158">However, there is no API structure that exposes the physical size (including the memory padding).</span></span>

<span data-ttu-id="c3ce8-159">つまり、ブロック圧縮したデータを含む領域をコピーする際は、アライメントされたメモリ ブロックは注意して使用してください。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-159">In summary, be careful to use aligned memory blocks when copying regions that contain block-compressed data.</span></span> <span data-ttu-id="c3ce8-160">メモリ ポインターを取得するアプリケーションでこれを実行するには、必ずそのポインターがサーフェス ピッチを使用して物理メモリ サイズを明らかにするようにします。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-160">To do this in an application that gets a memory pointer, make sure that the pointer uses the surface pitch to account for the physical memory size.</span></span>

## <a name="span-idcompressionalgorithmsspanspan-idcompressionalgorithmsspanspan-idcompressionalgorithmsspancompression-algorithms"></a><span data-ttu-id="c3ce8-161"><span id="Compression_Algorithms"></span><span id="compression_algorithms"></span><span id="COMPRESSION_ALGORITHMS"></span>圧縮アルゴリズム</span><span class="sxs-lookup"><span data-stu-id="c3ce8-161"><span id="Compression_Algorithms"></span><span id="compression_algorithms"></span><span id="COMPRESSION_ALGORITHMS"></span>Compression algorithms</span></span>

<span data-ttu-id="c3ce8-162">Direct3D のブロック圧縮方法では、圧縮されていないテクスチャ データを 4 x 4 のブロックに分割し、各ブロックを圧縮してから、そのデータを保存します。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-162">Block compression techniques in Direct3D break up uncompressed texture data into 4×4 blocks, compress each block, and then store the data.</span></span> <span data-ttu-id="c3ce8-163">このため、圧縮されるテクスチャは、テクスチャの次元が 4 の倍数である必要があります。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-163">For this reason, textures are expected to be compressed must have texture dimensions that are multiples of 4.</span></span>

![ブロック圧縮](images/d3d10-compression-1.png)

<span data-ttu-id="c3ce8-165">上の図は、テクセル ブロックに分割されたテクスチャを示しています。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-165">The preceding diagram shows a texture partitioned into texel blocks.</span></span> <span data-ttu-id="c3ce8-166">最初のブロックは、a ～ p のラベルがついた 16 のテクセルのレイアウトを示していますが、各ブロックには同じ構造のデータがあります。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-166">The first block shows the layout of the 16 texels labeled a-p, but every block has the same organization of data.</span></span>

<span data-ttu-id="c3ce8-167">Direct3D は圧縮スキームをいくつか実装しています。それぞれ、保存される成分数、成分ごとのビット数、および消費されるメモリ量の間で異なるトレードオフが存在します。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-167">Direct3D implements several compression schemes, each implements a different tradeoff between number of components stored, the number of bits per component, and the amount of memory consumed.</span></span> <span data-ttu-id="c3ce8-168">この表を使用すると、アプリケーションに最適なデータの種類とデータ解像度で、最も効果的に機能する形式を選択するのに役立ちます。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-168">Use this table to help choose the format that works best with the type of data and the data resolution that best fits your application.</span></span>

| <span data-ttu-id="c3ce8-169">ソース データ</span><span class="sxs-lookup"><span data-stu-id="c3ce8-169">Source Data</span></span>                     | <span data-ttu-id="c3ce8-170">データ圧縮解像度 (ビット)</span><span class="sxs-lookup"><span data-stu-id="c3ce8-170">Data Compression Resolution (in bits)</span></span> | <span data-ttu-id="c3ce8-171">選択する圧縮形式</span><span class="sxs-lookup"><span data-stu-id="c3ce8-171">Choose this compression format</span></span> |
|---------------------------------|---------------------------------------|--------------------------------|
| <span data-ttu-id="c3ce8-172">成分が 3 つの色およびアルファ</span><span class="sxs-lookup"><span data-stu-id="c3ce8-172">Three-component color and alpha</span></span> | <span data-ttu-id="c3ce8-173">カラー (5:6:5)、アルファ (1) またはアルファなし</span><span class="sxs-lookup"><span data-stu-id="c3ce8-173">Color (5:6:5), Alpha (1) or no alpha</span></span>  | [<span data-ttu-id="c3ce8-174">BC1</span><span class="sxs-lookup"><span data-stu-id="c3ce8-174">BC1</span></span>](#bc1)                    |
| <span data-ttu-id="c3ce8-175">成分が 3 つの色およびアルファ</span><span class="sxs-lookup"><span data-stu-id="c3ce8-175">Three-component color and alpha</span></span> | <span data-ttu-id="c3ce8-176">カラー (5:6:5)、アルファ (4)</span><span class="sxs-lookup"><span data-stu-id="c3ce8-176">Color (5:6:5), Alpha (4)</span></span>              | [<span data-ttu-id="c3ce8-177">BC2</span><span class="sxs-lookup"><span data-stu-id="c3ce8-177">BC2</span></span>](#bc2)                    |
| <span data-ttu-id="c3ce8-178">成分が 3 つの色およびアルファ</span><span class="sxs-lookup"><span data-stu-id="c3ce8-178">Three-component color and alpha</span></span> | <span data-ttu-id="c3ce8-179">カラー (5:6:5)、アルファ (8)</span><span class="sxs-lookup"><span data-stu-id="c3ce8-179">Color (5:6:5), Alpha (8)</span></span>              | [<span data-ttu-id="c3ce8-180">BC3</span><span class="sxs-lookup"><span data-stu-id="c3ce8-180">BC3</span></span>](#bc3)                    |
| <span data-ttu-id="c3ce8-181">成分が 1 つの色</span><span class="sxs-lookup"><span data-stu-id="c3ce8-181">One-component color</span></span>             | <span data-ttu-id="c3ce8-182">1 つの成分 (8)</span><span class="sxs-lookup"><span data-stu-id="c3ce8-182">One component (8)</span></span>                     | [<span data-ttu-id="c3ce8-183">BC4</span><span class="sxs-lookup"><span data-stu-id="c3ce8-183">BC4</span></span>](#bc4)                    |
| <span data-ttu-id="c3ce8-184">成分が 2 つの色</span><span class="sxs-lookup"><span data-stu-id="c3ce8-184">Two-component color</span></span>             | <span data-ttu-id="c3ce8-185">2 つの成分 (8:8)</span><span class="sxs-lookup"><span data-stu-id="c3ce8-185">Two components (8:8)</span></span>                  | [<span data-ttu-id="c3ce8-186">BC5</span><span class="sxs-lookup"><span data-stu-id="c3ce8-186">BC5</span></span>](#bc5)                    |

- [<span data-ttu-id="c3ce8-187">BC1</span><span class="sxs-lookup"><span data-stu-id="c3ce8-187">BC1</span></span>](#bc1)
- [<span data-ttu-id="c3ce8-188">BC2</span><span class="sxs-lookup"><span data-stu-id="c3ce8-188">BC2</span></span>](#bc2)
- [<span data-ttu-id="c3ce8-189">BC3</span><span class="sxs-lookup"><span data-stu-id="c3ce8-189">BC3</span></span>](#bc3)
- [<span data-ttu-id="c3ce8-190">BC4</span><span class="sxs-lookup"><span data-stu-id="c3ce8-190">BC4</span></span>](#bc4)
- [<span data-ttu-id="c3ce8-191">BC5</span><span class="sxs-lookup"><span data-stu-id="c3ce8-191">BC5</span></span>](#bc5)

### <a name="span-idbc1spanspan-idbc1spanbc1"></a><span data-ttu-id="c3ce8-192"><span id="BC1"></span><span id="bc1"></span>BC1</span><span class="sxs-lookup"><span data-stu-id="c3ce8-192"><span id="BC1"></span><span id="bc1"></span>BC1</span></span>

<span data-ttu-id="c3ce8-193">5:6:5 の色 (赤が 5 ビット、緑が 6 ビット、青が 5 ビット) を使用する 3 つの成分のカラー データを保存するには、最初のブロック圧縮形式 (BC1) (DXGI\_FORMAT\_BC1\_TYPELESS、DXGI\_FORMAT\_BC1\_UNORM、または DXGI\_BC1\_UNORM\_SRGB のいずれか) を使用します。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-193">Use the first block compression format (BC1) (either DXGI\_FORMAT\_BC1\_TYPELESS, DXGI\_FORMAT\_BC1\_UNORM, or DXGI\_BC1\_UNORM\_SRGB) to store three-component color data using a 5:6:5 color (5 bits red, 6 bits green, 5 bits blue).</span></span> <span data-ttu-id="c3ce8-194">データに 1 ビットのアルファが含まれている場合も、これが当てはまります。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-194">This is true even if the data also contains 1-bit alpha.</span></span> <span data-ttu-id="c3ce8-195">4 x 4 のテクスチャが、可能な限り最も大きなデータ形式を使用することを想定すると、BC1 形式では必要なメモリが 48 バイト (16 色× 3 成分/色× 1 バイト/成分) から 8 バイトに減少します。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-195">Assuming a 4×4 texture using the largest data format possible, the BC1 format reduces the memory required from 48 bytes (16 colors × 3 components/color × 1 byte/component) to 8 bytes of memory.</span></span>

<span data-ttu-id="c3ce8-196">このアルゴリズムは、4 x 4 ブロックのテクセルで機能します。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-196">The algorithm works on 4×4 blocks of texels.</span></span> <span data-ttu-id="c3ce8-197">16 色を保存する代わりに、このアルゴリズムでは、2 つの参照カラー (color\_0 および color\_1) と 16 個の 2 ビット カラー インデックス (a ～ p のブロック) を保存します。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-197">Instead of storing 16 colors, the algorithm saves 2 reference colors (color\_0 and color\_1) and 16 2-bit color indices (blocks a–p), as shown in the following diagram.</span></span>

![BC1 の圧縮レイアウト](images/d3d10-compression-bc1.png)

<span data-ttu-id="c3ce8-199">カラー インデックス (a ～ p) は、カラー テーブルから元の色を検索するために使用します。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-199">The color indices (a–p) are used to look up the original colors from a color table.</span></span> <span data-ttu-id="c3ce8-200">カラー テーブルには 4 つの色が含まれます。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-200">The color table contains 4 colors.</span></span> <span data-ttu-id="c3ce8-201">最初の 2 色、color\_0 および color\_1 は、最小および最大の色です。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-201">The first two colors—color\_0 and color\_1—are the minimum and maximum colors.</span></span> <span data-ttu-id="c3ce8-202">その他の 2 色、color\_2 および color\_3 は、線形補間で計算された中間色です。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-202">The other two colors, color\_2 and color\_3, are intermediate colors calculated with linear interpolation.</span></span>

```cpp
color_2 = 2/3*color_0 + 1/3*color_1
color_3 = 1/3*color_0 + 2/3*color_1
```

<span data-ttu-id="c3ce8-203">4 つの色は、a ～ p のブロックに保存される 2 ビットのインデックス値を割り当てられます。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-203">The four colors are assigned 2-bit index values that will be saved in blocks a–p.</span></span>

```cpp
color_0 = 00
color_1 = 01
color_2 = 10
color_3 = 11
```

<span data-ttu-id="c3ce8-204">最後に、a ～ p のブロックの各色がカラー テーブルの 4 つの色と比較され、最も近い色のインデックスが 2 ビット ブロックに保存されます。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-204">Finally, each of the colors in blocks a–p are compared with the four colors in the color table, and the index for the closest color is stored in the 2-bit blocks.</span></span>

<span data-ttu-id="c3ce8-205">このアルゴリズムは、1 ビットのアルファが含まれているデータにも適しています。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-205">This algorithm lends itself to data that contains 1-bit alpha also.</span></span> <span data-ttu-id="c3ce8-206">違いは、color\_3 が 0 (透明色を表します) に設定されることと、color\_2 が color\_0 と color\_1 の線形ブレンドであることのみです。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-206">The only difference is that color\_3 is set to 0 (which represents a transparent color) and color\_2 is a linear blend of color\_0 and color\_1.</span></span>

```cpp
color_2 = 1/2*color_0 + 1/2*color_1;
color_3 = 0;
```

### <a name="span-idbc2spanspan-idbc2spanbc2"></a><span data-ttu-id="c3ce8-207"><span id="BC2"></span><span id="bc2"></span>BC2</span><span class="sxs-lookup"><span data-stu-id="c3ce8-207"><span id="BC2"></span><span id="bc2"></span>BC2</span></span>

<span data-ttu-id="c3ce8-208">整合性が低いカラー データおよびアルファ データが含まれているデータを保存するには、BC2 形式 (DXGI\_FORMAT\_BC2\_TYPELESS、DXGI\_FORMAT\_BC2\_UNORM、または DXGI\_BC2\_UNORM\_SRGB のいずれか) を使用します (整合性が高いアルファ データには [BC3](#bc3) を使用します)。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-208">Use the BC2 format (either DXGI\_FORMAT\_BC2\_TYPELESS, DXGI\_FORMAT\_BC2\_UNORM, or DXGI\_BC2\_UNORM\_SRGB) to store data that contains color and alpha data with low coherency (use [BC3](#bc3) for highly-coherent alpha data).</span></span> <span data-ttu-id="c3ce8-209">BC2 形式は、RGB データを 5:6:5 の色 (赤が 5 ビット、緑が 6 ビット、青が 5 ビット) で、アルファを独立した 4 ビットの値で保存します。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-209">The BC2 format stores RGB data as a 5:6:5 color (5 bits red, 6 bits green, 5 bits blue) and alpha as a separate 4-bit value.</span></span> <span data-ttu-id="c3ce8-210">4 x 4 のテクスチャが、可能な限り最も大きなデータ形式を使用すると想定すると、この圧縮方法では必要なメモリが 64 バイト (16 色 x 4 成分/色 x 1 バイト/成分) から 16 バイトに減少します。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-210">Assuming a 4×4 texture using the largest data format possible, this compression technique reduces the memory required from 64 bytes (16 colors × 4 components/color × 1 byte/component) to 16 bytes of memory.</span></span>

<span data-ttu-id="c3ce8-211">BC2 形式では、[BC1](#bc1) 形式と同じビット数およびデータ レイアウトで色を保存しますが、BC2 ではアルファ データを保存するためにさらに 64 ビットのメモリが必要です。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-211">The BC2 format stores colors with the same number of bits and data layout as the [BC1](#bc1) format; however, BC2 requires an additional 64-bits of memory to store the alpha data, as shown in the following diagram.</span></span>

![BC2 の圧縮レイアウト](images/d3d10-compression-bc2.png)

### <a name="span-idbc3spanspan-idbc3spanbc3"></a><span data-ttu-id="c3ce8-213"><span id="BC3"></span><span id="bc3"></span>BC3</span><span class="sxs-lookup"><span data-stu-id="c3ce8-213"><span id="BC3"></span><span id="bc3"></span>BC3</span></span>

<span data-ttu-id="c3ce8-214">整合性の高いカラー データを保存するには、BC3 形式 (DXGI\_FORMAT\_BC3\_TYPELESS、DXGI\_FORMAT\_BC3\_UNORM、または DXGI\_BC3\_UNORM\_SRGB のいずれか) を使用します (整合性の低いアルファ データには [BC2](#bc2) を使用します)。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-214">Use the BC3 format (either DXGI\_FORMAT\_BC3\_TYPELESS, DXGI\_FORMAT\_BC3\_UNORM, or DXGI\_BC3\_UNORM\_SRGB) to store highly coherent color data (use [BC2](#bc2) with less coherent alpha data).</span></span> <span data-ttu-id="c3ce8-215">BC3 形式では、5:6:5 の色 (赤が 5 ビット、緑が 6 ビット、青が 5 ビット) を使用してカラー データを、1 バイトを使用してアルファ データを保存します。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-215">The BC3 format stores color data using 5:6:5 color (5 bits red, 6 bits green, 5 bits blue) and alpha data using one byte.</span></span> <span data-ttu-id="c3ce8-216">4 x 4 のテクスチャが、可能な限り最も大きなデータ形式を使用すると想定すると、この圧縮方法では必要なメモリが 64 バイト (16 色 x 4 成分/色 x 1 バイト/成分) から 16 バイトに減少します。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-216">Assuming a 4×4 texture using the largest data format possible, this compression technique reduces the memory required from 64 bytes (16 colors × 4 components/color × 1 byte/component) to 16 bytes of memory.</span></span>

<span data-ttu-id="c3ce8-217">BC3 形式では、[BC1](#bc1) 形式と同じビット数およびデータ レイアウトで色を保存しますが、BC3 ではアルファ データを保存するためにさらに 64 ビットのメモリが必要です。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-217">The BC3 format stores colors with the same number of bits and data layout as the [BC1](#bc1) format; however, BC3 requires an additional 64-bits of memory to store the alpha data.</span></span> <span data-ttu-id="c3ce8-218">BC3 形式では、2 つの参照値を保存し、その 2 つの間を補間することによってアルファを処理します (BC1 で RGB カラーを保存する方法と類似しています)。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-218">The BC3 format handles alpha by storing two reference values and interpolating between them (similarly to how BC1 stores RGB color).</span></span>

<span data-ttu-id="c3ce8-219">このアルゴリズムは、4 x 4 ブロックのテクセルで機能します。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-219">The algorithm works on 4×4 blocks of texels.</span></span> <span data-ttu-id="c3ce8-220">16 個のアルファ値を保存する代わりに、このアルゴリズムでは、2 つの参照アルファ (alpha\_0 および alpha\_1) と 16 個の 3 ビット カラー インデックス (a ～ p のアルファ) を保存します。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-220">Instead of storing 16 alpha values, the algorithm stores 2 reference alphas (alpha\_0 and alpha\_1) and 16 3-bit color indices (alpha a through p), as shown in the following diagram.</span></span>

![BC3 の圧縮レイアウト](images/d3d10-compression-bc3.png)

<span data-ttu-id="c3ce8-222">BC3 形式では、アルファ インデックス (a ～ p) を使用して、8 つの値が含まれるルックアップ テーブルから元の色を検索します。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-222">The BC3 format uses the alpha indices (a–p) to look up the original colors from a lookup table that contains 8 values.</span></span> <span data-ttu-id="c3ce8-223">最初の 2 つの値である alpha\_0 および alpha\_1 は、最小値と最大値です。その他の 6 つの中間値は、線形補間を使用して計算されます。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-223">The first two values—alpha\_0 and alpha\_1—are the minimum and maximum values; the other six intermediate values are calculated using linear interpolation.</span></span>

<span data-ttu-id="c3ce8-224">このアルゴリズムでは、2 つの参照アルファ値を調べることで、補間アルファ値の数を決定します。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-224">The algorithm determines the number of interpolated alpha values by examining the two reference alpha values.</span></span> <span data-ttu-id="c3ce8-225">alpha\_0 が alpha\_1 より大きい場合、BC3 では 6 つのアルファ値を補間します。それ以外の場合は、4 つの値を補間します。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-225">If alpha\_0 is greater than alpha\_1, then BC3 interpolates 6 alpha values; otherwise, it interpolates 4.</span></span> <span data-ttu-id="c3ce8-226">BC3 でアルファ値を 4 つのみ補間するときは、追加のアルファ値 (0 は完全に透明、255 は完全に不透明) を 2 つ設定します。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-226">When BC3 interpolates only 4 alpha values, it sets two additional alpha values (0 for fully transparent and 255 for fully opaque).</span></span> <span data-ttu-id="c3ce8-227">BC3 では、指定されたテクセルの元のアルファに最も近い補間アルファ値に対応するビット コードを保存することにより、4 x 4 のテクセル領域にアルファ値を圧縮します。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-227">BC3 compresses the alpha values in the 4×4 texel area by storing the bit code corresponding to the interpolated alpha values which most closely matches the original alpha for a given texel.</span></span>

```cpp
if( alpha_0 > alpha_1 )
{
  // 6 interpolated alpha values.
  alpha_2 = 6/7*alpha_0 + 1/7*alpha_1; // bit code 010
  alpha_3 = 5/7*alpha_0 + 2/7*alpha_1; // bit code 011
  alpha_4 = 4/7*alpha_0 + 3/7*alpha_1; // bit code 100
  alpha_5 = 3/7*alpha_0 + 4/7*alpha_1; // bit code 101
  alpha_6 = 2/7*alpha_0 + 5/7*alpha_1; // bit code 110
  alpha_7 = 1/7*alpha_0 + 6/7*alpha_1; // bit code 111
}
else
{
  // 4 interpolated alpha values.
  alpha_2 = 4/5*alpha_0 + 1/5*alpha_1; // bit code 010
  alpha_3 = 3/5*alpha_0 + 2/5*alpha_1; // bit code 011
  alpha_4 = 2/5*alpha_0 + 3/5*alpha_1; // bit code 100
  alpha_5 = 1/5*alpha_0 + 4/5*alpha_1; // bit code 101
  alpha_6 = 0;                         // bit code 110
  alpha_7 = 255;                       // bit code 111
}
```

### <a name="span-idbc4spanspan-idbc4spanbc4"></a><span data-ttu-id="c3ce8-228"><span id="BC4"></span><span id="bc4"></span>BC4</span><span class="sxs-lookup"><span data-stu-id="c3ce8-228"><span id="BC4"></span><span id="bc4"></span>BC4</span></span>

<span data-ttu-id="c3ce8-229">成分が 1 つのカラー データを、各色に 8 ビット使用して保存するには、BC4 形式を使用します。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-229">Use the BC4 format to store one-component color data using 8 bits for each color.</span></span> <span data-ttu-id="c3ce8-230">精度が向上する結果 ([BC1](#bc1) との比較)、BC4 は、[0 ～ 1] の範囲では DXGI\_FORMAT\_BC4\_UNORM 形式を使用し、[-1 ～ +1] の範囲では DXGI\_FORMAT\_BC4\_SNORM 形式を使用して、浮動小数点データを保存するのに最適です。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-230">As a result of the increased accuracy (compared to [BC1](#bc1)), BC4 is ideal for storing floating-point data in the range of \[0 to 1\] using the DXGI\_FORMAT\_BC4\_UNORM format and \[-1 to +1\] using the DXGI\_FORMAT\_BC4\_SNORM format.</span></span> <span data-ttu-id="c3ce8-231">4 x 4 のテクスチャが、可能な限り最も大きなデータ形式を使用すると想定すると、この圧縮方法では必要なメモリが 16 バイト (16 色 x 1 成分/色 x 1 バイト/成分) から 8 バイトに減少します。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-231">Assuming a 4×4 texture using the largest data format possible, this compression technique reduces the memory required from 16 bytes (16 colors × 1 components/color × 1 byte/component) to 8 bytes.</span></span>

<span data-ttu-id="c3ce8-232">このアルゴリズムは、4 x 4 ブロックのテクセルで機能します。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-232">The algorithm works on 4×4 blocks of texels.</span></span> <span data-ttu-id="c3ce8-233">16 色を保存する代わりに、このアルゴリズムでは、次の図で示すように、2 つの参照カラー (red\_0 および red\_1) と 16 個の 3 ビット カラー インデックス (red a ～ red p) を保存します。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-233">Instead of storing 16 colors, the algorithm stores 2 reference colors (red\_0 and red\_1) and 16 3-bit color indices (red a through red p), as shown in the following diagram.</span></span>

![BC4 の圧縮レイアウト](images/d3d10-compression-bc4.png)

<span data-ttu-id="c3ce8-235">このアルゴリズムでは、3 ビットのインデックスを使用して、8 色が含まれるカラー テーブルから色を検索します。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-235">The algorithm uses the 3-bit indices to look up colors from a color table that contains 8 colors.</span></span> <span data-ttu-id="c3ce8-236">最初の 2 色、red\_0 および red\_1 は、最小および最大の色です。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-236">The first two colors—red\_0 and red\_1—are the minimum and maximum colors.</span></span> <span data-ttu-id="c3ce8-237">このアルゴリズムでは、線形補間を使用して残りの色を計算します。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-237">The algorithm calculates the remaining colors using linear interpolation.</span></span>

<span data-ttu-id="c3ce8-238">このアルゴリズムでは、2 つの参照値を調べることで、補間されるカラー値の数を決定します。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-238">The algorithm determines the number of interpolated color values by examining the two reference values.</span></span> <span data-ttu-id="c3ce8-239">red\_0 が red\_1 より大きい場合、BC4 では 6 つのカラー値を補間します。それ以外の場合は、4 つの値を補間します。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-239">If red\_0 is greater than red\_1, then BC4 interpolates 6 color values; otherwise, it interpolates 4.</span></span> <span data-ttu-id="c3ce8-240">BC4 でカラー値を 4 つのみ補間するときは、追加のカラー値 (0.0f は完全に透明、1.0f は完全に不透明) を 2 つ設定します。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-240">When BC4 interpolates only 4 color values, it sets two additional color values (0.0f for fully transparent and 1.0f for fully opaque).</span></span> <span data-ttu-id="c3ce8-241">BC4 では、指定されたテクセルの元のアルファに最も近い補間アルファ値に対応するビット コードを保存することにより、4 x 4 のテクセル領域にアルファ値を圧縮します。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-241">BC4 compresses the alpha values in the 4×4 texel area by storing the bit code corresponding to the interpolated alpha values that most closely matches the original alpha for a given texel.</span></span>

- [<span data-ttu-id="c3ce8-242">BC4\_UNORM</span><span class="sxs-lookup"><span data-stu-id="c3ce8-242">BC4\_UNORM</span></span>](#bc4-unorm)
- [<span data-ttu-id="c3ce8-243">BC4\_SNORM</span><span class="sxs-lookup"><span data-stu-id="c3ce8-243">BC4\_SNORM</span></span>](#bc4-snorm)

### <a name="span-idbc4unormspanspan-idbc4unormspanspan-idbc4-unormspanbc4unorm"></a><span data-ttu-id="c3ce8-244"><span id="BC4_UNORM"></span><span id="bc4_unorm"></span><span id="bc4-unorm"></span>BC4\_UNORM</span><span class="sxs-lookup"><span data-stu-id="c3ce8-244"><span id="BC4_UNORM"></span><span id="bc4_unorm"></span><span id="bc4-unorm"></span>BC4\_UNORM</span></span>

<span data-ttu-id="c3ce8-245">単一成分データの補間は、以下のコード サンプルのように行われます。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-245">The interpolation of the single-component data is done as in the following code sample.</span></span>

```cpp
unsigned word red_0, red_1;

if( red_0 > red_1 )
{
  // 6 interpolated color values
  red_2 = (6*red_0 + 1*red_1)/7.0f; // bit code 010
  red_3 = (5*red_0 + 2*red_1)/7.0f; // bit code 011
  red_4 = (4*red_0 + 3*red_1)/7.0f; // bit code 100
  red_5 = (3*red_0 + 4*red_1)/7.0f; // bit code 101
  red_6 = (2*red_0 + 5*red_1)/7.0f; // bit code 110
  red_7 = (1*red_0 + 6*red_1)/7.0f; // bit code 111
}
else
{
  // 4 interpolated color values
  red_2 = (4*red_0 + 1*red_1)/5.0f; // bit code 010
  red_3 = (3*red_0 + 2*red_1)/5.0f; // bit code 011
  red_4 = (2*red_0 + 3*red_1)/5.0f; // bit code 100
  red_5 = (1*red_0 + 4*red_1)/5.0f; // bit code 101
  red_6 = 0.0f;                     // bit code 110
  red_7 = 1.0f;                     // bit code 111
}
```

<span data-ttu-id="c3ce8-246">参照カラーは 3 ビットのインデックス (8 つの値があるので 000 ～ 111) を割り当てられます。このインデックスは、圧縮時に red a ～ red p のブロックに保存されます。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-246">The reference colors are assigned 3-bit indices (000–111 since there are 8 values), which will be saved in blocks red a through red p during compression.</span></span>

### <a name="span-idbc4snormspanspan-idbc4snormspanspan-idbc4-snormspanbc4snorm"></a><span data-ttu-id="c3ce8-247"><span id="BC4_SNORM"></span><span id="bc4_snorm"></span><span id="bc4-snorm"></span>BC4\_SNORM</span><span class="sxs-lookup"><span data-stu-id="c3ce8-247"><span id="BC4_SNORM"></span><span id="bc4_snorm"></span><span id="bc4-snorm"></span>BC4\_SNORM</span></span>

<span data-ttu-id="c3ce8-248">DXGI\_FORMAT\_BC4\_SNORM は、SNORM 範囲でデータがエンコードされることと、4 つのカラー値が補間される場合を除いて、まったく同じです。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-248">The DXGI\_FORMAT\_BC4\_SNORM is exactly the same, except that the data is encoded in SNORM range and when 4 color values are interpolated.</span></span> <span data-ttu-id="c3ce8-249">単一成分データの補間は、以下のコード サンプルのように行われます。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-249">The interpolation of the single-component data is done as in the following code sample.</span></span>

```cpp
signed word red_0, red_1;

if( red_0 > red_1 )
{
  // 6 interpolated color values
  red_2 = (6*red_0 + 1*red_1)/7.0f; // bit code 010
  red_3 = (5*red_0 + 2*red_1)/7.0f; // bit code 011
  red_4 = (4*red_0 + 3*red_1)/7.0f; // bit code 100
  red_5 = (3*red_0 + 4*red_1)/7.0f; // bit code 101
  red_6 = (2*red_0 + 5*red_1)/7.0f; // bit code 110
  red_7 = (1*red_0 + 6*red_1)/7.0f; // bit code 111
}
else
{
  // 4 interpolated color values
  red_2 = (4*red_0 + 1*red_1)/5.0f; // bit code 010
  red_3 = (3*red_0 + 2*red_1)/5.0f; // bit code 011
  red_4 = (2*red_0 + 3*red_1)/5.0f; // bit code 100
  red_5 = (1*red_0 + 4*red_1)/5.0f; // bit code 101
  red_6 = -1.0f;                    // bit code 110
  red_7 =  1.0f;                    // bit code 111
}
```

<span data-ttu-id="c3ce8-250">参照カラーは 3 ビットのインデックス (8 つの値があるので 000 ～ 111) を割り当てられます。このインデックスは、圧縮時に red a ～ red p のブロックに保存されます。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-250">The reference colors are assigned 3-bit indices (000–111 since there are 8 values), which will be saved in blocks red a through red p during compression.</span></span>

### <a name="span-idbc5spanspan-idbc5spanbc5"></a><span data-ttu-id="c3ce8-251"><span id="BC5"></span><span id="bc5"></span>BC5</span><span class="sxs-lookup"><span data-stu-id="c3ce8-251"><span id="BC5"></span><span id="bc5"></span>BC5</span></span>

<span data-ttu-id="c3ce8-252">成分が 2 つのカラー データを、各色に 8 ビット使用して保存するには、BC5 形式を使用します。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-252">Use the BC5 format to store two-component color data using 8 bits for each color.</span></span> <span data-ttu-id="c3ce8-253">精度が向上する結果 ([BC1](#bc1) との比較)、BC5 は、[0 ～ 1] の範囲では DXGI\_FORMAT\_BC5\_UNORM 形式を使用し、[-1 ～ +1] の範囲では DXGI\_FORMAT\_BC5\_SNORM 形式を使用して、浮動小数点データを保存するのに最適です。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-253">As a result of the increased accuracy (compared to [BC1](#bc1)), BC5 is ideal for storing floating-point data in the range of \[0 to 1\] using the DXGI\_FORMAT\_BC5\_UNORM format and \[-1 to +1\] using the DXGI\_FORMAT\_BC5\_SNORM format.</span></span> <span data-ttu-id="c3ce8-254">4 x 4 のテクスチャが、可能な限り最も大きなデータ形式を使用すると想定すると、この圧縮方法では必要なメモリが 32 バイト (16 色 x 2 成分/色 x 1 バイト/成分) から 16 バイトに減少します。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-254">Assuming a 4×4 texture using the largest data format possible, this compression technique reduces the memory required from 32 bytes (16 colors × 2 components/color × 1 byte/component) to 16 bytes.</span></span>

- [<span data-ttu-id="c3ce8-255">BC5\_UNORM</span><span class="sxs-lookup"><span data-stu-id="c3ce8-255">BC5\_UNORM</span></span>](#bc5-unorm)
- [<span data-ttu-id="c3ce8-256">BC5\_SNORM</span><span class="sxs-lookup"><span data-stu-id="c3ce8-256">BC5\_SNORM</span></span>](#bc5-snorm)

<span data-ttu-id="c3ce8-257">このアルゴリズムは、4 x 4 ブロックのテクセルで機能します。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-257">The algorithm works on 4×4 blocks of texels.</span></span> <span data-ttu-id="c3ce8-258">2 つの成分でそれぞれ 16 色を保存する代わりに、このアルゴリズムでは各成分で 2 つの参照カラー (red\_0、red\_1、green\_0、および green\_1) と、各成分で 16 個の 3 ビット カラー インデックス (red a ～ red p および green a ～ green p) を保存します。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-258">Instead of storing 16 colors for both components, the algorithm stores 2 reference colors for each component (red\_0, red\_1, green\_0, and green\_1) and 16 3-bit color indices for each component (red a through red p and green a through green p), as shown in the following diagram.</span></span>

![BC5 の圧縮レイアウト](images/d3d10-compression-bc5.png)

<span data-ttu-id="c3ce8-260">このアルゴリズムでは、3 ビットのインデックスを使用して、8 色が含まれるカラー テーブルから色を検索します。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-260">The algorithm uses the 3-bit indices to look up colors from a color table that contains 8 colors.</span></span> <span data-ttu-id="c3ce8-261">最初の 2 色、red\_0 および red\_1 (または green\_0 および green\_1) は、最小および最大の色です。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-261">The first two colors—red\_0 and red\_1 (or green\_0 and green\_1)—are the minimum and maximum colors.</span></span> <span data-ttu-id="c3ce8-262">このアルゴリズムでは、線形補間を使用して残りの色を計算します。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-262">The algorithm calculates the remaining colors using linear interpolation.</span></span>

<span data-ttu-id="c3ce8-263">このアルゴリズムでは、2 つの参照値を調べることで、補間されるカラー値の数を決定します。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-263">The algorithm determines the number of interpolated color values by examining the two reference values.</span></span> <span data-ttu-id="c3ce8-264">red\_0 が red\_1 より大きい場合、BC5 では 6 つのカラー値を補間します。それ以外の場合は、4 つの値を補間します。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-264">If red\_0 is greater than red\_1, then BC5 interpolates 6 color values; otherwise, it interpolates 4.</span></span> <span data-ttu-id="c3ce8-265">BC5 でカラー値を 4 つのみ補間するときは、残りの 2 つのカラー値を 0.0f と 1.0f に設定します。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-265">When BC5 interpolates only 4 color values, it sets the remaining two color values at 0.0f and 1.0f.</span></span>

### <a name="span-idbc5unormspanspan-idbc5unormspanspan-idbc5-unormspanbc5unorm"></a><span data-ttu-id="c3ce8-266"><span id="BC5_UNORM"></span><span id="bc5_unorm"></span><span id="bc5-unorm"></span>BC5\_UNORM</span><span class="sxs-lookup"><span data-stu-id="c3ce8-266"><span id="BC5_UNORM"></span><span id="bc5_unorm"></span><span id="bc5-unorm"></span>BC5\_UNORM</span></span>

<span data-ttu-id="c3ce8-267">単一成分データの補間は、以下のコード サンプルのように行われます。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-267">The interpolation of the single-component data is done as in the following code sample.</span></span> <span data-ttu-id="c3ce8-268">green の成分の計算も同様です。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-268">The calculations for the green components are similar.</span></span>

```cpp
unsigned word red_0, red_1;

if( red_0 > red_1 )
{
  // 6 interpolated color values
  red_2 = (6*red_0 + 1*red_1)/7.0f; // bit code 010
  red_3 = (5*red_0 + 2*red_1)/7.0f; // bit code 011
  red_4 = (4*red_0 + 3*red_1)/7.0f; // bit code 100
  red_5 = (3*red_0 + 4*red_1)/7.0f; // bit code 101
  red_6 = (2*red_0 + 5*red_1)/7.0f; // bit code 110
  red_7 = (1*red_0 + 6*red_1)/7.0f; // bit code 111
}
else
{
  // 4 interpolated color values
  red_2 = (4*red_0 + 1*red_1)/5.0f; // bit code 010
  red_3 = (3*red_0 + 2*red_1)/5.0f; // bit code 011
  red_4 = (2*red_0 + 3*red_1)/5.0f; // bit code 100
  red_5 = (1*red_0 + 4*red_1)/5.0f; // bit code 101
  red_6 = 0.0f;                     // bit code 110
  red_7 = 1.0f;                     // bit code 111
}
```

<span data-ttu-id="c3ce8-269">参照カラーは 3 ビットのインデックス (8 つの値があるので 000 ～ 111) を割り当てられます。このインデックスは、圧縮時に red a ～ red p のブロックに保存されます。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-269">The reference colors are assigned 3-bit indices (000–111 since there are 8 values), which will be saved in blocks red a through red p during compression.</span></span>

### <a name="span-idbc5snormspanspan-idbc5snormspanspan-idbc5-snormspanbc5snorm"></a><span data-ttu-id="c3ce8-270"><span id="BC5_SNORM"></span><span id="bc5_snorm"></span><span id="bc5-snorm"></span>BC5\_SNORM</span><span class="sxs-lookup"><span data-stu-id="c3ce8-270"><span id="BC5_SNORM"></span><span id="bc5_snorm"></span><span id="bc5-snorm"></span>BC5\_SNORM</span></span>

<span data-ttu-id="c3ce8-271">DXGI\_FORMAT\_BC5\_SNORM は、SNORM 範囲でデータがエンコードされることと、4 つのデータ値が補間され、-1.0f と 1.0f の 2 つの値が追加される場合を除いて、まったく同じです。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-271">The DXGI\_FORMAT\_BC5\_SNORM is exactly the same, except that the data is encoded in SNORM range and when 4 data values are interpolated, the two additional values are -1.0f and 1.0f.</span></span> <span data-ttu-id="c3ce8-272">単一成分データの補間は、以下のコード サンプルのように行われます。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-272">The interpolation of the single-component data is done as in the following code sample.</span></span> <span data-ttu-id="c3ce8-273">green の成分の計算も同様です。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-273">The calculations for the green components are similar.</span></span>

```cpp
signed word red_0, red_1;

if( red_0 > red_1 )
{
  // 6 interpolated color values
  red_2 = (6*red_0 + 1*red_1)/7.0f; // bit code 010
  red_3 = (5*red_0 + 2*red_1)/7.0f; // bit code 011
  red_4 = (4*red_0 + 3*red_1)/7.0f; // bit code 100
  red_5 = (3*red_0 + 4*red_1)/7.0f; // bit code 101
  red_6 = (2*red_0 + 5*red_1)/7.0f; // bit code 110
  red_7 = (1*red_0 + 6*red_1)/7.0f; // bit code 111
}
else
{
  // 4 interpolated color values
  red_2 = (4*red_0 + 1*red_1)/5.0f; // bit code 010
  red_3 = (3*red_0 + 2*red_1)/5.0f; // bit code 011
  red_4 = (2*red_0 + 3*red_1)/5.0f; // bit code 100
  red_5 = (1*red_0 + 4*red_1)/5.0f; // bit code 101
  red_6 = -1.0f;                    // bit code 110
  red_7 =  1.0f;                    // bit code 111
}
```

<span data-ttu-id="c3ce8-274">参照カラーは 3 ビットのインデックス (8 つの値があるので 000 ～ 111) を割り当てられます。このインデックスは、圧縮時に red a ～ red p のブロックに保存されます。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-274">The reference colors are assigned 3-bit indices (000–111 since there are 8 values), which will be saved in blocks red a through red p during compression.</span></span>

## <a name="span-iddifferencesspanspan-iddifferencesspanspan-iddifferencesspanformat-conversion"></a><span data-ttu-id="c3ce8-275"><span id="Differences"></span><span id="differences"></span><span id="DIFFERENCES"></span>形式の変換</span><span class="sxs-lookup"><span data-stu-id="c3ce8-275"><span id="Differences"></span><span id="differences"></span><span id="DIFFERENCES"></span>Format conversion</span></span>

<span data-ttu-id="c3ce8-276">Direct3D を使用すると、ビット幅が同じであれば、事前に構造化されたタイプのテクスチャとブロック圧縮されたテクスチャとの間のコピーが可能になります。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-276">Direct3D enables copies between prestructured-typed textures and block-compressed textures of the same bit widths.</span></span>

<span data-ttu-id="c3ce8-277">いくつかの種類の形式間でリソースをコピーできます。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-277">You can copy resources between a few format types.</span></span> <span data-ttu-id="c3ce8-278">このようなコピー操作では、そのリソース データを異なる形式として再解釈する、一種の形式変換を実行します。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-278">This type of copy operation performs a type of format conversion that reinterprets resource data as a different format type.</span></span> <span data-ttu-id="c3ce8-279">より一般的な変換の動作と、データの再解釈との違いを示す、この例をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-279">Consider this example that shows the difference between reinterpreting data with the way a more typical type of conversion behaves:</span></span>

```cpp
FLOAT32 f = 1.0f;
UINT32 u;
```

<span data-ttu-id="c3ce8-280">'f' を 'u' のタイプとして再解釈するため、[memcpy](http://msdn.microsoft.com/library/dswaw1wk.aspx) を使います。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-280">To reinterpret 'f' as the type of 'u', use [memcpy](http://msdn.microsoft.com/library/dswaw1wk.aspx):</span></span>

```cpp
memcpy( &u, &f, sizeof( f ) ); // 'u' becomes equal to 0x3F800000.
```

<span data-ttu-id="c3ce8-281">上の再解釈では、基になるデータの値は変更されません。[memcpy](http://msdn.microsoft.com/library/dswaw1wk.aspx) は浮動小数点数を符号なし整数として再解釈します。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-281">In the preceding reinterpretation, the underlying value of the data doesn’t change; [memcpy](http://msdn.microsoft.com/library/dswaw1wk.aspx) reinterprets the float as an unsigned integer.</span></span>

<span data-ttu-id="c3ce8-282">より一般的な変換を実行するには、割り当てを使用します。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-282">To perform the more typical type of conversion, use assignment:</span></span>

```cpp
u = f; // 'u' becomes 1.
```

<span data-ttu-id="c3ce8-283">上の変換では、基になるデータの値が変更されます。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-283">In the preceding conversion, the underlying value of the data changes.</span></span>

<span data-ttu-id="c3ce8-284">次の表は、このような再解釈による形式変換に使用できる、変換元と変換先の形式を示しています。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-284">The following table lists the allowable source and destination formats that you can use in this reinterpretation type of format conversion.</span></span> <span data-ttu-id="c3ce8-285">再解釈が期待どおりに動作するためには、値を適切にエンコードする必要があります。</span><span class="sxs-lookup"><span data-stu-id="c3ce8-285">You must encode the values properly for the reinterpretation to work as expected.</span></span>

<table>
<colgroup>
<col width="33%" />
<col width="33%" />
<col width="33%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="c3ce8-286">ビット幅</span><span class="sxs-lookup"><span data-stu-id="c3ce8-286">Bit Width</span></span></th>
<th align="left"><span data-ttu-id="c3ce8-287">圧縮されていないリソース</span><span class="sxs-lookup"><span data-stu-id="c3ce8-287">Uncompressed Resource</span></span></th>
<th align="left"><span data-ttu-id="c3ce8-288">ブロック圧縮されたリソース</span><span class="sxs-lookup"><span data-stu-id="c3ce8-288">Block-Compressed Resource</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="c3ce8-289">32</span><span class="sxs-lookup"><span data-stu-id="c3ce8-289">32</span></span></td>
<td align="left"><p><span data-ttu-id="c3ce8-290">DXGI_FORMAT_R32_UINT</span><span class="sxs-lookup"><span data-stu-id="c3ce8-290">DXGI_FORMAT_R32_UINT</span></span></p>
<p><span data-ttu-id="c3ce8-291">DXGI_FORMAT_R32_SINT</span><span class="sxs-lookup"><span data-stu-id="c3ce8-291">DXGI_FORMAT_R32_SINT</span></span></p></td>
<td align="left"><span data-ttu-id="c3ce8-292">DXGI_FORMAT_R9G9B9E5_SHAREDEXP</span><span class="sxs-lookup"><span data-stu-id="c3ce8-292">DXGI_FORMAT_R9G9B9E5_SHAREDEXP</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="c3ce8-293">64</span><span class="sxs-lookup"><span data-stu-id="c3ce8-293">64</span></span></td>
<td align="left"><p><span data-ttu-id="c3ce8-294">DXGI_FORMAT_R16G16B16A16_UINT</span><span class="sxs-lookup"><span data-stu-id="c3ce8-294">DXGI_FORMAT_R16G16B16A16_UINT</span></span></p>
<p><span data-ttu-id="c3ce8-295">DXGI_FORMAT_R16G16B16A16_SINT</span><span class="sxs-lookup"><span data-stu-id="c3ce8-295">DXGI_FORMAT_R16G16B16A16_SINT</span></span></p>
<p><span data-ttu-id="c3ce8-296">DXGI_FORMAT_R32G32_UINT</span><span class="sxs-lookup"><span data-stu-id="c3ce8-296">DXGI_FORMAT_R32G32_UINT</span></span></p>
<p><span data-ttu-id="c3ce8-297">DXGI_FORMAT_R32G32_SINT</span><span class="sxs-lookup"><span data-stu-id="c3ce8-297">DXGI_FORMAT_R32G32_SINT</span></span></p></td>
<td align="left"><p><span data-ttu-id="c3ce8-298">DXGI_FORMAT_BC1_UNORM[_SRGB]</span><span class="sxs-lookup"><span data-stu-id="c3ce8-298">DXGI_FORMAT_BC1_UNORM[_SRGB]</span></span></p>
<p><span data-ttu-id="c3ce8-299">DXGI_FORMAT_BC4_UNORM</span><span class="sxs-lookup"><span data-stu-id="c3ce8-299">DXGI_FORMAT_BC4_UNORM</span></span></p>
<p><span data-ttu-id="c3ce8-300">DXGI_FORMAT_BC4_SNORM</span><span class="sxs-lookup"><span data-stu-id="c3ce8-300">DXGI_FORMAT_BC4_SNORM</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="c3ce8-301">128</span><span class="sxs-lookup"><span data-stu-id="c3ce8-301">128</span></span></td>
<td align="left"><p><span data-ttu-id="c3ce8-302">DXGI_FORMAT_R32G32B32A32_UINT</span><span class="sxs-lookup"><span data-stu-id="c3ce8-302">DXGI_FORMAT_R32G32B32A32_UINT</span></span></p>
<p><span data-ttu-id="c3ce8-303">DXGI_FORMAT_R32G32B32A32_SINT</span><span class="sxs-lookup"><span data-stu-id="c3ce8-303">DXGI_FORMAT_R32G32B32A32_SINT</span></span></p></td>
<td align="left"><p><span data-ttu-id="c3ce8-304">DXGI_FORMAT_BC2_UNORM[_SRGB]</span><span class="sxs-lookup"><span data-stu-id="c3ce8-304">DXGI_FORMAT_BC2_UNORM[_SRGB]</span></span></p>
<p><span data-ttu-id="c3ce8-305">DXGI_FORMAT_BC3_UNORM[_SRGB]</span><span class="sxs-lookup"><span data-stu-id="c3ce8-305">DXGI_FORMAT_BC3_UNORM[_SRGB]</span></span></p>
<p><span data-ttu-id="c3ce8-306">DXGI_FORMAT_BC5_UNORM</span><span class="sxs-lookup"><span data-stu-id="c3ce8-306">DXGI_FORMAT_BC5_UNORM</span></span></p>
<p><span data-ttu-id="c3ce8-307">DXGI_FORMAT_BC5_SNORM</span><span class="sxs-lookup"><span data-stu-id="c3ce8-307">DXGI_FORMAT_BC5_SNORM</span></span></p></td>
</tr>
</tbody>
</table>

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="c3ce8-308"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="c3ce8-308"><span id="related-topics"></span>Related topics</span></span>

[<span data-ttu-id="c3ce8-309">圧縮テクスチャ リソース</span><span class="sxs-lookup"><span data-stu-id="c3ce8-309">Compressed texture resources</span></span>](compressed-texture-resources.md)
