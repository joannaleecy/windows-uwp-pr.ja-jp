---
author: QuinnRadich
Description: How to use thumbnail images to help users preview files in UWP apps.
title: UWP アプリでのサムネイル画像のガイドライン
label: Thumbnail images
template: detail.hbs
ms.author: quradic
ms.date: 01/08/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: df1eec58d936ba4f03e1eadae534abf0620b1a39
ms.sourcegitcommit: 7aa1933e6970f878faf50d59e1f799b90afd7cc7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/05/2018
ms.locfileid: "3373696"
---
# <a name="thumbnail-images"></a><span data-ttu-id="ca9b7-103">サムネイル画像</span><span class="sxs-lookup"><span data-stu-id="ca9b7-103">Thumbnail images</span></span>

<span data-ttu-id="ca9b7-104">このガイドラインでは、サムネイル画像を使って、UWP アプリでファイルを参照するときにファイルをプレビューできるようにする方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="ca9b7-104">These guidelines describe how to use thumbnail images to help users preview files as they browse in your UWP app.</span></span> 

> <span data-ttu-id="ca9b7-105">**重要な API**: [ThumbnailMode 列挙型](https://docs.microsoft.com/uwp/api/windows.storage.fileproperties.thumbnailmode)</span><span class="sxs-lookup"><span data-stu-id="ca9b7-105">**Important APIs**: [ThumbnailMode enum](https://docs.microsoft.com/uwp/api/windows.storage.fileproperties.thumbnailmode)</span></span>

## <a name="should-my-app-include-thumbnails"></a><span data-ttu-id="ca9b7-106">アプリにサムネイルを含めるかどうか</span><span class="sxs-lookup"><span data-stu-id="ca9b7-106">Should my app include thumbnails?</span></span>

<span data-ttu-id="ca9b7-107">アプリでユーザーがファイルを参照できるようにする場合、サムネイル画像を表示することで、ファイルをすばやくプレビューすることが可能になります。</span><span class="sxs-lookup"><span data-stu-id="ca9b7-107">If your app allows users to browse files, you can display thumbnail images to help users quickly preview those files.</span></span> 

<span data-ttu-id="ca9b7-108">サムネイルは次の場合に使います。</span><span class="sxs-lookup"><span data-stu-id="ca9b7-108">Use thumbnails when:</span></span> 
- <span data-ttu-id="ca9b7-109">ギャラリー コレクションに含まれる多くの項目 (ファイルやフォルダーなど) のプレビューを表示する場合。</span><span class="sxs-lookup"><span data-stu-id="ca9b7-109">Displaying previews for many items in a gallery collection (like files and folders).</span></span> <span data-ttu-id="ca9b7-110">たとえば、フォト ギャラリーでは、ユーザーが写真ファイルを参照するときにサムネイルを使って各写真が小さく表示されるようにします。</span><span class="sxs-lookup"><span data-stu-id="ca9b7-110">For example, a photo gallery should use thumbnails to give users a small view of each picture as they browse through their photo files.</span></span>

    ![ビデオ ギャラリー](images/thumbnail-gallery.png)

- <span data-ttu-id="ca9b7-112">リスト内にある個別の項目 (特定のファイルなど) に対するプレビューを表示する場合。</span><span class="sxs-lookup"><span data-stu-id="ca9b7-112">Displaying a preview for an individual item in a list (like a specific file).</span></span> <span data-ttu-id="ca9b7-113">たとえば、ユーザーがファイルを開くかどうかを決める前に、より見やすい大きなサムネイルと共に、ファイルの詳しい情報を表示できます。</span><span class="sxs-lookup"><span data-stu-id="ca9b7-113">For example, the user may want to see more information about a file, including a larger thumbnail for a better preview, before deciding whether to open the file.</span></span> 

    ![ビデオのプレビュー](images/thumbnail-preview.png)

## <a name="dos-and-donts"></a><span data-ttu-id="ca9b7-115">推奨と非推奨</span><span class="sxs-lookup"><span data-stu-id="ca9b7-115">Dos and don'ts</span></span>
- <span data-ttu-id="ca9b7-116">サムネイルを取得するときに、[サムネイル モード](https://docs.microsoft.com/uwp/api/windows.storage.fileproperties.thumbnailmode) (PicturesView, VideosView, DocumentsView, MusicView, ListView, or SingleItem) を指定します。</span><span class="sxs-lookup"><span data-stu-id="ca9b7-116">Specify the [thumbnail mode](https://docs.microsoft.com/uwp/api/windows.storage.fileproperties.thumbnailmode) (PicturesView, VideosView, DocumentsView, MusicView, ListView, or SingleItem) when you retrieve thumbnails.</span></span> <span data-ttu-id="ca9b7-117">これにより、ユーザーが確認するファイルの種類を表示するようにサムネイル画像が最適化されます。</span><span class="sxs-lookup"><span data-stu-id="ca9b7-117">This ensures that thumbnail images are optimized to display the type of files users want to see.</span></span> 
    - <span data-ttu-id="ca9b7-118">ファイルの種類に関係なく単一項目用のサムネイルを取得するには、 SingleItem モードを使います。</span><span class="sxs-lookup"><span data-stu-id="ca9b7-118">Use the SingleItem mode to retrieve a thumbnail for a single item, regardless of file type.</span></span> <span data-ttu-id="ca9b7-119">その他のサムネイル モードの目的は、複数ファイルのプレビューを表示することです。</span><span class="sxs-lookup"><span data-stu-id="ca9b7-119">The other thumbnail modes are meant to display previews of multiple files.</span></span> 

- <span data-ttu-id="ca9b7-120">サムネイルの読み込み中は、サムネイルの代わりに汎用のプレースホルダー画像を表示します。</span><span class="sxs-lookup"><span data-stu-id="ca9b7-120">Display generic placeholder images in place of thumbnails while thumbnails load.</span></span> <span data-ttu-id="ca9b7-121">プレースホルダーを使うことで、サムネイルの読み込みが終わる前にプレビューを操作できるため、アプリの体感的な応答速度を高めることができます。</span><span class="sxs-lookup"><span data-stu-id="ca9b7-121">Using placeholders helps your app seem more responsive because users can interact with previews before the thumbnail load.</span></span> 

    <span data-ttu-id="ca9b7-122">プレースホルダー画像は次の条件を満たす必要があります。</span><span class="sxs-lookup"><span data-stu-id="ca9b7-122">Placeholder images should be:</span></span>
    * <span data-ttu-id="ca9b7-123">代わりとなる項目の種類に固有である。</span><span class="sxs-lookup"><span data-stu-id="ca9b7-123">Specific to the kind of item that it stands in for.</span></span> <span data-ttu-id="ca9b7-124">たとえば、フォルダー、画像、動画にはすべて、それぞれ異なるプレースホルダーを用意する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ca9b7-124">For example, folders, pictures, and videos should all have their own specialized placeholders.</span></span> 
    * <span data-ttu-id="ca9b7-125">代わりとなるサムネイル画像とサイズおよび縦横比が同じである。</span><span class="sxs-lookup"><span data-stu-id="ca9b7-125">The same size and aspect ratio as the thumbnail image it stands in for.</span></span> 
    * <span data-ttu-id="ca9b7-126">サムネイル画像が読み込まれるまで表示される。</span><span class="sxs-lookup"><span data-stu-id="ca9b7-126">Displayed until the thumbnail image is loaded.</span></span> 

- <span data-ttu-id="ca9b7-127">フォルダーやファイル グループを個別のファイルと区別するには、テキスト ラベル付きのプレースホルダー画像を使います。</span><span class="sxs-lookup"><span data-stu-id="ca9b7-127">Use placeholder images with text labels to represent folders and file groups to differentiate from individual files.</span></span>

- <span data-ttu-id="ca9b7-128">サムネイルを取得できない場合は、プレースホルダー画像を表示します。</span><span class="sxs-lookup"><span data-stu-id="ca9b7-128">If you can't retrieve a thumbnail, display a placeholder image.</span></span> 

- <span data-ttu-id="ca9b7-129">ドキュメントや音楽ファイルのプレビューを表示するときは、追加のファイル情報も表示します。</span><span class="sxs-lookup"><span data-stu-id="ca9b7-129">Display additional file information when providing previews for document and music files.</span></span> <span data-ttu-id="ca9b7-130">これによってユーザーは、サムネイル画像だけでは簡単に取得できない可能性のある、ファイルに関する重要な情報を確認できます。</span><span class="sxs-lookup"><span data-stu-id="ca9b7-130">Users can then identify key information about a file that might not be readily available from a thumbnail image alone.</span></span> <span data-ttu-id="ca9b7-131">たとえば音楽ファイルの場合、アルバム アートのサムネイルと一緒にアーティスト名を表示できます。</span><span class="sxs-lookup"><span data-stu-id="ca9b7-131">For example, for a music file, you might display the name of the artist along with the thumbnail of the album art.</span></span> 

- <span data-ttu-id="ca9b7-132">画像ファイルとビデオ ファイルに関する追加のファイル情報は表示しないでください。</span><span class="sxs-lookup"><span data-stu-id="ca9b7-132">Don't display additional file info for picture and video files.</span></span> <span data-ttu-id="ca9b7-133">ほとんどの場合、ユーザーが画像やビデオを参照する場合は、サムネイル画像だけで十分です。</span><span class="sxs-lookup"><span data-stu-id="ca9b7-133">In most cases, a thumbnail image is sufficient for users browsing through pictures and videos.</span></span> 

## <a name="additional-usage-guidelines"></a><span data-ttu-id="ca9b7-134">その他の使い方のガイドライン</span><span class="sxs-lookup"><span data-stu-id="ca9b7-134">Additional usage guidelines</span></span>
<span data-ttu-id="ca9b7-135">推奨される[サムネイル モード](https://docs.microsoft.com/uwp/api/windows.storage.fileproperties.thumbnailmode)とその特徴:</span><span class="sxs-lookup"><span data-stu-id="ca9b7-135">Recommended [thumbnail modes](https://docs.microsoft.com/uwp/api/windows.storage.fileproperties.thumbnailmode) and their features:</span></span>

<table>
<tr>
<th> <span data-ttu-id="ca9b7-136">プレビューの表示対象</span><span class="sxs-lookup"><span data-stu-id="ca9b7-136">Display previews for</span></span></th>
<th> <span data-ttu-id="ca9b7-137">サムネイル モード</span><span class="sxs-lookup"><span data-stu-id="ca9b7-137">Thumbnail modes</span></span> </th>
<th> <span data-ttu-id="ca9b7-138">取得するサムネイル画像の特徴</span><span class="sxs-lookup"><span data-stu-id="ca9b7-138">Features of the retrieved thumbnail images</span></span> </th>
</tr>
<tr>
<td> <span data-ttu-id="ca9b7-139">画像</span><span class="sxs-lookup"><span data-stu-id="ca9b7-139">Pictures</span></span><br /> <span data-ttu-id="ca9b7-140">ビデオ</span><span class="sxs-lookup"><span data-stu-id="ca9b7-140">Videos</span></span> </td>
<td> <span data-ttu-id="ca9b7-141">PicturesView</span><span class="sxs-lookup"><span data-stu-id="ca9b7-141">PicturesView</span></span> <br /><span data-ttu-id="ca9b7-142">VideosView</span><span class="sxs-lookup"><span data-stu-id="ca9b7-142">VideosView</span></span> </td>
<td> <span data-ttu-id="ca9b7-143"><b>サイズ</b>: 中、190 以上を推奨 (画像サイズが 190 × 130 の場合)</span><span class="sxs-lookup"><span data-stu-id="ca9b7-143"><b>Size</b>: Medium, preferably at least 190 (if the image size is 190x130)</span></span> <br /><span data-ttu-id="ca9b7-144">
<b>縦横比</b>: 均一な横長の縦横比 (約 0.7) (サイズが 190 の場合は 190 × 130)</span><span class="sxs-lookup"><span data-stu-id="ca9b7-144">
<b>Aspect ratio</b>: Uniform, wide aspect ratio of about .7 (190x130 if the size is 190)</span></span> <br />
<span data-ttu-id="ca9b7-145">プレビューの場合はトリミングされます。</span><span class="sxs-lookup"><span data-stu-id="ca9b7-145">Cropped for previews.</span></span> <br /> 
<span data-ttu-id="ca9b7-146">縦横比が統一されているため、画像をグリッド内で揃えるときに便利です。</span><span class="sxs-lookup"><span data-stu-id="ca9b7-146">Good for aligning images in a grid because of uniform aspect ratio.</span></span>  </td>
</tr>
<tr>
<td> <span data-ttu-id="ca9b7-147">ドキュメント</span><span class="sxs-lookup"><span data-stu-id="ca9b7-147">Documents</span></span><br /><span data-ttu-id="ca9b7-148">音楽</span><span class="sxs-lookup"><span data-stu-id="ca9b7-148">Music</span></span> </td>
<td> <span data-ttu-id="ca9b7-149">DocumentsView</span><span class="sxs-lookup"><span data-stu-id="ca9b7-149">DocumentsView</span></span> <br /><span data-ttu-id="ca9b7-150">MusicView</span><span class="sxs-lookup"><span data-stu-id="ca9b7-150">MusicView</span></span> <br /> <span data-ttu-id="ca9b7-151">ListView</span><span class="sxs-lookup"><span data-stu-id="ca9b7-151">ListView</span></span></td>
<td> <span data-ttu-id="ca9b7-152"><b>サイズ</b>: 小、40 × 40 ピクセル以上を推奨</span><span class="sxs-lookup"><span data-stu-id="ca9b7-152"><b>Size</b>: Small, preferably at least 40 x 40 pixels</span></span> <br /><span data-ttu-id="ca9b7-153">
<b>縦横比</b>:  均一な正方形の縦横比</span><span class="sxs-lookup"><span data-stu-id="ca9b7-153">
<b>Aspect ratio</b>:  Uniform, square aspect ratio</span></span>  <br />
<span data-ttu-id="ca9b7-154">縦横比が正方形であるため、アルバム アートのプレビューに最適。</span><span class="sxs-lookup"><span data-stu-id="ca9b7-154">Good for previewing album art because of the square aspect ratio.</span></span> <br /> 
<span data-ttu-id="ca9b7-155">ドキュメントは、ファイル ピッカーのウィンドウと同じように表示されます (同じアイコンを使用)。</span><span class="sxs-lookup"><span data-stu-id="ca9b7-155">Documents look the same as they look in a file picker window (it uses the same icons).</span></span> </td>
</tr>
</tr>
<tr>
<td> <span data-ttu-id="ca9b7-156">任意の 1 つの項目 (ファイルの種類を考慮しない場合)</span><span class="sxs-lookup"><span data-stu-id="ca9b7-156">Any single item (regardless of file type)</span></span> </td>
<td> <span data-ttu-id="ca9b7-157">SingleItem</span><span class="sxs-lookup"><span data-stu-id="ca9b7-157">SingleItem</span></span> </td>
<td> <span data-ttu-id="ca9b7-158"><b>サイズ</b>: 小、40 × 40 ピクセル以上を推奨</span><span class="sxs-lookup"><span data-stu-id="ca9b7-158"><b>Size</b>: Small, preferably at least 40 x 40 pixels</span></span> <br /><span data-ttu-id="ca9b7-159">
<b>縦横比</b>:  均一な正方形の縦横比</span><span class="sxs-lookup"><span data-stu-id="ca9b7-159">
<b>Aspect ratio</b>:  Uniform, square aspect ratio</span></span>  <br />
<span data-ttu-id="ca9b7-160">縦横比が正方形であるため、アルバム アートのプレビューに最適。</span><span class="sxs-lookup"><span data-stu-id="ca9b7-160">Good for previewing album art because of the square aspect ratio.</span></span> <br /> 
<span data-ttu-id="ca9b7-161">ドキュメントは、ファイル ピッカーのウィンドウと同じように表示されます (同じアイコンを使用)。</span><span class="sxs-lookup"><span data-stu-id="ca9b7-161">Documents look the same as they look in a file picker window (it uses the same icons).</span></span> </td>
</tr>
</table>

<span data-ttu-id="ca9b7-162">以下の例は、取得したサムネイル画像が、ファイルの種類とサムネイル モードに応じてどのように異なるかを示しています。</span><span class="sxs-lookup"><span data-stu-id="ca9b7-162">Here are examples showing how retrieved thumbnail images differ depending on file type and thumbnail mode:</span></span>
<div class="mx-responsive-img">
<table>
<tr>
<th><span data-ttu-id="ca9b7-163">項目の種類</span><span class="sxs-lookup"><span data-stu-id="ca9b7-163">Item type</span></span></th>
<th><span data-ttu-id="ca9b7-164">取得時に使ったモード:</span><span class="sxs-lookup"><span data-stu-id="ca9b7-164">When retrieved using:</span></span> <ul><li><span data-ttu-id="ca9b7-165">PicturesView</span><span class="sxs-lookup"><span data-stu-id="ca9b7-165">PicturesView</span></span> <li><span data-ttu-id="ca9b7-166">VideosView</span><span class="sxs-lookup"><span data-stu-id="ca9b7-166">VideosView</span></span></ul></th>
<th><span data-ttu-id="ca9b7-167">取得時に使ったモード:</span><span class="sxs-lookup"><span data-stu-id="ca9b7-167">When retrieved using:</span></span> <ul><li><span data-ttu-id="ca9b7-168">DocumentsView</span><span class="sxs-lookup"><span data-stu-id="ca9b7-168">DocumentsView</span></span> <li><span data-ttu-id="ca9b7-169">MusicView</span><span class="sxs-lookup"><span data-stu-id="ca9b7-169">MusicView</span></span> <li><span data-ttu-id="ca9b7-170">ListView</span><span class="sxs-lookup"><span data-stu-id="ca9b7-170">ListView</span></span></ul></th>
<th><span data-ttu-id="ca9b7-171">取得時に使ったモード:</span><span class="sxs-lookup"><span data-stu-id="ca9b7-171">When retrieved using:</span></span> <ul><li><span data-ttu-id="ca9b7-172">SingleItem</span><span class="sxs-lookup"><span data-stu-id="ca9b7-172">SingleItem</span></span></ul></th>
<tr>
<tr>
<td><span data-ttu-id="ca9b7-173">画像</span><span class="sxs-lookup"><span data-stu-id="ca9b7-173">Picture</span></span></td>
<td><span data-ttu-id="ca9b7-174">サムネイル画像には、ファイルの元の縦横比が使われます。</span><span class="sxs-lookup"><span data-stu-id="ca9b7-174">The thumbnail image uses the original aspect ratio of the file.</span></span> <br />
<img src="images/thumbnail-pic-picvidmode.png" alt="Picture thumbnail in picture or video mode"/></td>
<td><span data-ttu-id="ca9b7-175">サムネイルは縦横比が正方形になるようにトリミングされています。</span><span class="sxs-lookup"><span data-stu-id="ca9b7-175">The thumbnail is cropped to a square aspect ratio.</span></span> <br />
<img src="images/thumbnail-pic-doclistmusic-modes.png" alt="Picture thumbnail in documents, music, or list modes"/></td>
<td><span data-ttu-id="ca9b7-176">サムネイル画像には、ファイルの元の縦横比が使われます。</span><span class="sxs-lookup"><span data-stu-id="ca9b7-176">The thumbnail image uses the original aspect ratio of the file.</span></span><br />
<img src="images/thumbnail-pic-single-mode.png" alt="Picture thumbnail in single mode"/> </td>
</tr>
<tr>
<td><span data-ttu-id="ca9b7-177">ビデオ</span><span class="sxs-lookup"><span data-stu-id="ca9b7-177">Video</span></span></td>
<td><span data-ttu-id="ca9b7-178">サムネイルには、画像と区別するためのアイコンが追加されます。</span><span class="sxs-lookup"><span data-stu-id="ca9b7-178">The thumbnail has an icon that differentiates it from pictures.</span></span> <br />
<img src="images/thumbnail-vid-picvid-modes.png" alt="Video thumbnail in picture or video mode"/></td>
<td><span data-ttu-id="ca9b7-179">サムネイルは縦横比が正方形になるようにトリミングされています。</span><span class="sxs-lookup"><span data-stu-id="ca9b7-179">The thumbnail is cropped to a square aspect ratio.</span></span> <br />
<img src="images/thumbnail-vid-doclistmusic-modes.png" alt="Video thumbnail in documents, music, or list mode"/> </td>
<td><span data-ttu-id="ca9b7-180">サムネイル画像には、ファイルの元の縦横比が使われます。</span><span class="sxs-lookup"><span data-stu-id="ca9b7-180">The thumbnail image uses the original aspect ratio of the file.</span></span> <br />
<img src="images/thumbnail-vid-single-mode.png" alt="Video thumbnail in single mode"/></td>
</tr>
<tr>
<td><span data-ttu-id="ca9b7-181">音楽</span><span class="sxs-lookup"><span data-stu-id="ca9b7-181">Music</span></span></td>
<td><span data-ttu-id="ca9b7-182">サムネイルは、適切なサイズの背景に配置されたアイコンです。</span><span class="sxs-lookup"><span data-stu-id="ca9b7-182">The thumbnail is an icon on a background of appropriate size.</span></span> <span data-ttu-id="ca9b7-183">背景色は、アプリのタイルの背景色によって決まります。</span><span class="sxs-lookup"><span data-stu-id="ca9b7-183">The background color is determined by the app's tile background color.</span></span> <br />
<img src="images/thumbnail-music-picvid-modes.png" alt="Music thumbnail in picture or video mode"/></td>
<td><span data-ttu-id="ca9b7-184">ファイルにアルバム アートが含まれる場合、サムネイルはアルバム アートになります。</span><span class="sxs-lookup"><span data-stu-id="ca9b7-184">If the file has album art, then the thumbnail is the album art.</span></span>  <br />
<img src="images/thumbnail-music-doclistmusic-modes.png" alt="Music thumbnail in documents, music, or list mode"/> <br />
<span data-ttu-id="ca9b7-185">それ以外の場合、サムネイルは、適切なサイズの背景に配置されたアイコンです。</span><span class="sxs-lookup"><span data-stu-id="ca9b7-185">Otherwise, the thumbnail is an icon on a background of appropriate size.</span></span></td>
<td><span data-ttu-id="ca9b7-186">ファイルにアルバム アートが含まれる場合、サムネイルはアルバム アートになり、ファイルの元の縦横比が使われます。</span><span class="sxs-lookup"><span data-stu-id="ca9b7-186">If the file has album art, then the thumbnail is the album art with the original aspect ratio of the file.</span></span>  <br />
<img src="images/thumbnail-music-single-mode.png" alt="Music thumbnail in single mode"/> <br />
<span data-ttu-id="ca9b7-187">それ以外の場合、サムネイルはアイコンです。</span><span class="sxs-lookup"><span data-stu-id="ca9b7-187">Otherwise, the thumbnail is an icon.</span></span> </td>
</tr>
<tr>
<td><span data-ttu-id="ca9b7-188">ドキュメント</span><span class="sxs-lookup"><span data-stu-id="ca9b7-188">Document</span></span></td>
<td><span data-ttu-id="ca9b7-189">サムネイルは、適切なサイズの背景に配置されたアイコンです。</span><span class="sxs-lookup"><span data-stu-id="ca9b7-189">The thumbnail is an icon on a background of appropriate size.</span></span> <span data-ttu-id="ca9b7-190">背景色は、アプリのタイルの背景色によって決まります。</span><span class="sxs-lookup"><span data-stu-id="ca9b7-190">The background color is determined by the app's tile background color.</span></span> <br />
<img src="images/thumbnail-docs-picvid-modes.png" alt="Document thumbnail in picture or video mode"/></td>
<td><span data-ttu-id="ca9b7-191">サムネイルは、適切なサイズの背景に配置されたアイコンです。</span><span class="sxs-lookup"><span data-stu-id="ca9b7-191">The thumbnail is an icon on a background of appropriate size.</span></span> <span data-ttu-id="ca9b7-192">背景色は、アプリのタイルの背景色によって決まります。</span><span class="sxs-lookup"><span data-stu-id="ca9b7-192">The background color is determined by the app's tile background color.</span></span> <br />
<img src="images/thumbnail-doc-doclistmusic-modes.png" alt="Document thumbnail in documents, music, or list mode"/></td>
<td><span data-ttu-id="ca9b7-193">ドキュメントのサムネイルがある場合は、そのサムネイルが表示されます。</span><span class="sxs-lookup"><span data-stu-id="ca9b7-193">The document thumbnail, if one exists.</span></span> <br />
<img src="images/thumbnail-doc1-single-mode.png" alt="Document thumbnail in single mode"/><br />
<span data-ttu-id="ca9b7-194">それ以外の場合、サムネイルはアイコンです。</span><span class="sxs-lookup"><span data-stu-id="ca9b7-194">Otherwise, the thumbnail is an icon.</span></span> <br />
<img src="images/thumbnail-doc2-single-mode.png" alt="Document thumbnail icon in single mode"/></td>
</tr>
<tr>
<td><span data-ttu-id="ca9b7-195">フォルダー</span><span class="sxs-lookup"><span data-stu-id="ca9b7-195">Folder</span></span></td>
<td><span data-ttu-id="ca9b7-196">フォルダーに画像ファイルが含まれる場合は、画像のサムネイルが使われます。</span><span class="sxs-lookup"><span data-stu-id="ca9b7-196">If there is a picture file in the folder, then the picture thumbnail is used.</span></span>  <br />
<img src="images/thumbnail-dir-picvid-modes.png" alt="Folder thumbnail in picture or video mode"/> <br />
<span data-ttu-id="ca9b7-197">それ以外の場合、サムネイルは取得されません。</span><span class="sxs-lookup"><span data-stu-id="ca9b7-197">Otherwise, no thumbnail is retrieved.</span></span></td>
<td><span data-ttu-id="ca9b7-198">サムネイル画像は取得されません。</span><span class="sxs-lookup"><span data-stu-id="ca9b7-198">No thumbnail image is retrieved.</span></span></td>
<td><span data-ttu-id="ca9b7-199">サムネイルはフォルダー アイコンです。</span><span class="sxs-lookup"><span data-stu-id="ca9b7-199">The thumbnail is the folder icon.</span></span><br />
<img src="images/thumbnail-dir-single-mode.png" alt="Folder icon thumbnail in single mode"/></td>
</tr>
<tr>
<td><span data-ttu-id="ca9b7-200">ファイル グループ</span><span class="sxs-lookup"><span data-stu-id="ca9b7-200">File group</span></span></td>
<td><span data-ttu-id="ca9b7-201">フォルダーに画像ファイルが含まれる場合は、画像のサムネイルが使われます。</span><span class="sxs-lookup"><span data-stu-id="ca9b7-201">If there is a picture file in the folder, then the picture thumbnail is used.</span></span><br />
<img src="images/thumbnail-grp-picvid-modes.png" alt="File group thumbnail in picture or video mode"/> <br /> <span data-ttu-id="ca9b7-202">それ以外の場合、サムネイルは取得されません。</span><span class="sxs-lookup"><span data-stu-id="ca9b7-202">Otherwise, no thumbnail is retrieved.</span></span> </td>
<td><span data-ttu-id="ca9b7-203">グループ内のファイルにアルバム アートを含むファイルがある場合、サムネイルはアルバム アートになります。</span><span class="sxs-lookup"><span data-stu-id="ca9b7-203">If there is a file that has album art among the files in the group, the thumbnail is the album art.</span></span> <br />
<img src="images/thumbnail-grp-doclistmusic-modes.png" alt="File group thumbnail in documents, music or list mode"/> <br /><span data-ttu-id="ca9b7-204">それ以外の場合、サムネイルは取得されません。</span><span class="sxs-lookup"><span data-stu-id="ca9b7-204">Otherwise, no thumbnail is retrieved.</span></span> </td>
<td><span data-ttu-id="ca9b7-205">グループ内のファイルにアルバム アートを含むファイルがある場合、サムネイルはアルバム アートになり、ファイルの元の縦横比が使われます。</span><span class="sxs-lookup"><span data-stu-id="ca9b7-205">If there is a file that has album art among the files in the group, the thumbnail is the album art and uses the original aspect ratio of the file.</span></span> <br />
<img src="images/thumbnail-grp1-single-mode.png" alt="File group thumbnail in picture or video mode"/> <br /><span data-ttu-id="ca9b7-206">それ以外の場合、サムネイルはファイルのグループを表すアイコンです。</span><span class="sxs-lookup"><span data-stu-id="ca9b7-206">Otherwise, the thumbnail is an icon that represents a group of files.</span></span> <br />
<img src="images/thumbnail-grp2-single-mode.png" alt="File group icon in single mode"/> 
</td>
</tr>
</table>
</div>

## <a name="related-topics"></a><span data-ttu-id="ca9b7-207">関連トピック</span><span class="sxs-lookup"><span data-stu-id="ca9b7-207">Related topics</span></span>
- [<span data-ttu-id="ca9b7-208">ThumbnailMode 列挙型</span><span class="sxs-lookup"><span data-stu-id="ca9b7-208">ThumbnailMode enum</span></span>](https://docs.microsoft.com/uwp/api/windows.storage.fileproperties.thumbnailmode)
- [<span data-ttu-id="ca9b7-209">StorageItemThumbnail クラス</span><span class="sxs-lookup"><span data-stu-id="ca9b7-209">StorageItemThumbnail class</span></span>](https://docs.microsoft.com/uwp/api/Windows.Storage.FileProperties.StorageItemThumbnail)
- [<span data-ttu-id="ca9b7-210">StorageFile クラス</span><span class="sxs-lookup"><span data-stu-id="ca9b7-210">StorageFile class</span></span>](https://docs.microsoft.com/uwp/api/windows.storage.storagefile)
- [<span data-ttu-id="ca9b7-211">ファイルとフォルダーのサムネイルのサンプル (GitHub)</span><span class="sxs-lookup"><span data-stu-id="ca9b7-211">File and folder thumbnail sample (GitHub)</span></span>](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/FileThumbnails)
- [<span data-ttu-id="ca9b7-212">リスト ビューとグリッド ビュー</span><span class="sxs-lookup"><span data-stu-id="ca9b7-212">List and grid view</span></span>](../design/controls-and-patterns/lists.md)