---
Description: サムネイル画像を使用して UWP アプリでファイルをプレビューするユーザーを支援する方法。
title: UWP アプリでのサムネイル画像のガイドライン
label: Thumbnail images
template: detail.hbs
ms.date: 12/19/2018
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 15984e00b036bf44d6e4a7f60cb6435ea1add291
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57642007"
---
# <a name="thumbnail-images"></a><span data-ttu-id="24307-104">サムネイル画像</span><span class="sxs-lookup"><span data-stu-id="24307-104">Thumbnail images</span></span>

<span data-ttu-id="24307-105">このガイドラインでは、サムネイル画像を使って、UWP アプリでファイルを参照するときにファイルをプレビューできるようにする方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="24307-105">These guidelines describe how to use thumbnail images to help users preview files as they browse in your UWP app.</span></span> 

<span data-ttu-id="24307-106">**重要な API**</span><span class="sxs-lookup"><span data-stu-id="24307-106">**Important APIs**</span></span>

-   [<span data-ttu-id="24307-107">**ThumbnailMode**</span><span class="sxs-lookup"><span data-stu-id="24307-107">**ThumbnailMode**</span></span>](https://docs.microsoft.com/uwp/api/windows.storage.fileproperties.thumbnailmode)

## <a name="should-my-app-include-thumbnails"></a><span data-ttu-id="24307-108">アプリにサムネイルを含めるかどうか</span><span class="sxs-lookup"><span data-stu-id="24307-108">Should my app include thumbnails?</span></span>

<span data-ttu-id="24307-109">アプリでユーザーがファイルを参照できるようにする場合、サムネイル画像を表示することで、ファイルをすばやくプレビューすることが可能になります。</span><span class="sxs-lookup"><span data-stu-id="24307-109">If your app allows users to browse files, you can display thumbnail images to help users quickly preview those files.</span></span> 

<span data-ttu-id="24307-110">サムネイルは次の場合に使います。</span><span class="sxs-lookup"><span data-stu-id="24307-110">Use thumbnails when:</span></span> 
- <span data-ttu-id="24307-111">ギャラリー コレクションに含まれる多くの項目 (ファイルやフォルダーなど) のプレビューを表示する場合。</span><span class="sxs-lookup"><span data-stu-id="24307-111">Displaying previews for many items in a gallery collection (like files and folders).</span></span> <span data-ttu-id="24307-112">たとえば、フォト ギャラリーでは、ユーザーが写真ファイルを参照するときにサムネイルを使って各写真が小さく表示されるようにします。</span><span class="sxs-lookup"><span data-stu-id="24307-112">For example, a photo gallery should use thumbnails to give users a small view of each picture as they browse through their photo files.</span></span>

    ![ビデオ ギャラリー](images/thumbnail-gallery.png)

- <span data-ttu-id="24307-114">リスト内にある個別の項目 (特定のファイルなど) に対するプレビューを表示する場合。</span><span class="sxs-lookup"><span data-stu-id="24307-114">Displaying a preview for an individual item in a list (like a specific file).</span></span> <span data-ttu-id="24307-115">たとえば、ユーザーがファイルを開くかどうかを決める前に、より見やすい大きなサムネイルと共に、ファイルの詳しい情報を表示できます。</span><span class="sxs-lookup"><span data-stu-id="24307-115">For example, the user may want to see more information about a file, including a larger thumbnail for a better preview, before deciding whether to open the file.</span></span> 

    ![ビデオのプレビュー](images/thumbnail-preview.png)

## <a name="dos-and-donts"></a><span data-ttu-id="24307-117">推奨と非推奨</span><span class="sxs-lookup"><span data-stu-id="24307-117">Dos and don'ts</span></span>
- <span data-ttu-id="24307-118">サムネイルを取得するときに、[サムネイル モード](https://docs.microsoft.com/uwp/api/windows.storage.fileproperties.thumbnailmode) (PicturesView, VideosView, DocumentsView, MusicView, ListView, or SingleItem) を指定します。</span><span class="sxs-lookup"><span data-stu-id="24307-118">Specify the [thumbnail mode](https://docs.microsoft.com/uwp/api/windows.storage.fileproperties.thumbnailmode) (PicturesView, VideosView, DocumentsView, MusicView, ListView, or SingleItem) when you retrieve thumbnails.</span></span> <span data-ttu-id="24307-119">これにより、ユーザーが確認するファイルの種類を表示するようにサムネイル画像が最適化されます。</span><span class="sxs-lookup"><span data-stu-id="24307-119">This ensures that thumbnail images are optimized to display the type of files users want to see.</span></span> 
    - <span data-ttu-id="24307-120">ファイルの種類に関係なく単一項目用のサムネイルを取得するには、 SingleItem モードを使います。</span><span class="sxs-lookup"><span data-stu-id="24307-120">Use the SingleItem mode to retrieve a thumbnail for a single item, regardless of file type.</span></span> <span data-ttu-id="24307-121">その他のサムネイル モードの目的は、複数ファイルのプレビューを表示することです。</span><span class="sxs-lookup"><span data-stu-id="24307-121">The other thumbnail modes are meant to display previews of multiple files.</span></span> 

- <span data-ttu-id="24307-122">サムネイルの読み込み中は、サムネイルの代わりに汎用のプレースホルダー画像を表示します。</span><span class="sxs-lookup"><span data-stu-id="24307-122">Display generic placeholder images in place of thumbnails while thumbnails load.</span></span> <span data-ttu-id="24307-123">プレースホルダーを使うことで、サムネイルの読み込みが終わる前にプレビューを操作できるため、アプリの体感的な応答速度を高めることができます。</span><span class="sxs-lookup"><span data-stu-id="24307-123">Using placeholders helps your app seem more responsive because users can interact with previews before the thumbnail load.</span></span> 

    <span data-ttu-id="24307-124">プレースホルダー画像は次の条件を満たす必要があります。</span><span class="sxs-lookup"><span data-stu-id="24307-124">Placeholder images should be:</span></span>
    * <span data-ttu-id="24307-125">代わりとなる項目の種類に固有である。</span><span class="sxs-lookup"><span data-stu-id="24307-125">Specific to the kind of item that it stands in for.</span></span> <span data-ttu-id="24307-126">たとえば、フォルダー、画像、動画にはすべて、それぞれ異なるプレースホルダーを用意する必要があります。</span><span class="sxs-lookup"><span data-stu-id="24307-126">For example, folders, pictures, and videos should all have their own specialized placeholders.</span></span> 
    * <span data-ttu-id="24307-127">代わりとなるサムネイル画像とサイズおよび縦横比が同じである。</span><span class="sxs-lookup"><span data-stu-id="24307-127">The same size and aspect ratio as the thumbnail image it stands in for.</span></span> 
    * <span data-ttu-id="24307-128">サムネイル画像が読み込まれるまで表示される。</span><span class="sxs-lookup"><span data-stu-id="24307-128">Displayed until the thumbnail image is loaded.</span></span> 

- <span data-ttu-id="24307-129">フォルダーやファイル グループを個別のファイルと区別するには、テキスト ラベル付きのプレースホルダー画像を使います。</span><span class="sxs-lookup"><span data-stu-id="24307-129">Use placeholder images with text labels to represent folders and file groups to differentiate from individual files.</span></span>

- <span data-ttu-id="24307-130">サムネイルを取得できない場合は、プレースホルダー画像を表示します。</span><span class="sxs-lookup"><span data-stu-id="24307-130">If you can't retrieve a thumbnail, display a placeholder image.</span></span> 

- <span data-ttu-id="24307-131">ドキュメントや音楽ファイルのプレビューを表示するときは、追加のファイル情報も表示します。</span><span class="sxs-lookup"><span data-stu-id="24307-131">Display additional file information when providing previews for document and music files.</span></span> <span data-ttu-id="24307-132">これによってユーザーは、サムネイル画像だけでは簡単に取得できない可能性のある、ファイルに関する重要な情報を確認できます。</span><span class="sxs-lookup"><span data-stu-id="24307-132">Users can then identify key information about a file that might not be readily available from a thumbnail image alone.</span></span> <span data-ttu-id="24307-133">たとえば音楽ファイルの場合、アルバム アートのサムネイルと一緒にアーティスト名を表示できます。</span><span class="sxs-lookup"><span data-stu-id="24307-133">For example, for a music file, you might display the name of the artist along with the thumbnail of the album art.</span></span> 

- <span data-ttu-id="24307-134">画像ファイルとビデオ ファイルに関する追加のファイル情報は表示しないでください。</span><span class="sxs-lookup"><span data-stu-id="24307-134">Don't display additional file info for picture and video files.</span></span> <span data-ttu-id="24307-135">ほとんどの場合、ユーザーが画像やビデオを参照する場合は、サムネイル画像だけで十分です。</span><span class="sxs-lookup"><span data-stu-id="24307-135">In most cases, a thumbnail image is sufficient for users browsing through pictures and videos.</span></span> 

## <a name="additional-usage-guidelines"></a><span data-ttu-id="24307-136">その他の使い方のガイドライン</span><span class="sxs-lookup"><span data-stu-id="24307-136">Additional usage guidelines</span></span>
<span data-ttu-id="24307-137">推奨される[サムネイル モード](https://docs.microsoft.com/uwp/api/windows.storage.fileproperties.thumbnailmode)とその特徴:</span><span class="sxs-lookup"><span data-stu-id="24307-137">Recommended [thumbnail modes](https://docs.microsoft.com/uwp/api/windows.storage.fileproperties.thumbnailmode) and their features:</span></span>

<table>
<tr>
<th> <span data-ttu-id="24307-138">プレビューの表示対象</span><span class="sxs-lookup"><span data-stu-id="24307-138">Display previews for</span></span></th>
<th> <span data-ttu-id="24307-139">サムネイル モード</span><span class="sxs-lookup"><span data-stu-id="24307-139">Thumbnail modes</span></span> </th>
<th> <span data-ttu-id="24307-140">取得するサムネイル画像の特徴</span><span class="sxs-lookup"><span data-stu-id="24307-140">Features of the retrieved thumbnail images</span></span> </th>
</tr>
<tr>
<td> <span data-ttu-id="24307-141">画像</span><span class="sxs-lookup"><span data-stu-id="24307-141">Pictures</span></span><br /> <span data-ttu-id="24307-142">ビデオ</span><span class="sxs-lookup"><span data-stu-id="24307-142">Videos</span></span> </td>
<td> <span data-ttu-id="24307-143">PicturesView</span><span class="sxs-lookup"><span data-stu-id="24307-143">PicturesView</span></span> <br /><span data-ttu-id="24307-144">VideosView</span><span class="sxs-lookup"><span data-stu-id="24307-144">VideosView</span></span> </td>
<td> <span data-ttu-id="24307-145"><b>［サイズ］</b>: 可能であれば少なくとも 190 (イメージのサイズが 190 x 130 の場合)、中</span><span class="sxs-lookup"><span data-stu-id="24307-145"><b>Size</b>: Medium, preferably at least 190 (if the image size is 190x130)</span></span> <br /><span data-ttu-id="24307-146">
<b>縦横比</b>: 約.7 (190 x 130 サイズが 190 の場合) の縦横比を統一された、ワイド</span><span class="sxs-lookup"><span data-stu-id="24307-146">
<b>Aspect ratio</b>: Uniform, wide aspect ratio of about .7 (190x130 if the size is 190)</span></span> <br />
<span data-ttu-id="24307-147">プレビューの場合はトリミングされます。</span><span class="sxs-lookup"><span data-stu-id="24307-147">Cropped for previews.</span></span> <br /> 
<span data-ttu-id="24307-148">縦横比が統一されているため、画像をグリッド内で揃えるときに便利です。</span><span class="sxs-lookup"><span data-stu-id="24307-148">Good for aligning images in a grid because of uniform aspect ratio.</span></span>  </td>
</tr>
<tr>
<td> <span data-ttu-id="24307-149">ドキュメント</span><span class="sxs-lookup"><span data-stu-id="24307-149">Documents</span></span><br /><span data-ttu-id="24307-150">音楽</span><span class="sxs-lookup"><span data-stu-id="24307-150">Music</span></span> </td>
<td> <span data-ttu-id="24307-151">DocumentsView</span><span class="sxs-lookup"><span data-stu-id="24307-151">DocumentsView</span></span> <br /><span data-ttu-id="24307-152">MusicView</span><span class="sxs-lookup"><span data-stu-id="24307-152">MusicView</span></span> <br /> <span data-ttu-id="24307-153">ListView</span><span class="sxs-lookup"><span data-stu-id="24307-153">ListView</span></span></td>
<td> <span data-ttu-id="24307-154"><b>［サイズ］</b>: 小規模、可能であれば少なくとも 40 x 40 ピクセル</span><span class="sxs-lookup"><span data-stu-id="24307-154"><b>Size</b>: Small, preferably at least 40 x 40 pixels</span></span> <br /><span data-ttu-id="24307-155">
<b>縦横比</b>:  Uniform、正方形の縦横比</span><span class="sxs-lookup"><span data-stu-id="24307-155">
<b>Aspect ratio</b>:  Uniform, square aspect ratio</span></span>  <br />
<span data-ttu-id="24307-156">縦横比が正方形であるため、アルバム アートのプレビューに最適。</span><span class="sxs-lookup"><span data-stu-id="24307-156">Good for previewing album art because of the square aspect ratio.</span></span> <br /> 
<span data-ttu-id="24307-157">ドキュメントは、ファイル ピッカーのウィンドウと同じように表示されます (同じアイコンを使用)。</span><span class="sxs-lookup"><span data-stu-id="24307-157">Documents look the same as they look in a file picker window (it uses the same icons).</span></span> </td>
</tr>
</tr>
<tr>
<td> <span data-ttu-id="24307-158">任意の 1 つの項目 (ファイルの種類を考慮しない場合)</span><span class="sxs-lookup"><span data-stu-id="24307-158">Any single item (regardless of file type)</span></span> </td>
<td> <span data-ttu-id="24307-159">SingleItem</span><span class="sxs-lookup"><span data-stu-id="24307-159">SingleItem</span></span> </td>
<td> <span data-ttu-id="24307-160"><b>［サイズ］</b>: 小規模、可能であれば少なくとも 40 x 40 ピクセル</span><span class="sxs-lookup"><span data-stu-id="24307-160"><b>Size</b>: Small, preferably at least 40 x 40 pixels</span></span> <br /><span data-ttu-id="24307-161">
<b>縦横比</b>:  Uniform、正方形の縦横比</span><span class="sxs-lookup"><span data-stu-id="24307-161">
<b>Aspect ratio</b>:  Uniform, square aspect ratio</span></span>  <br />
<span data-ttu-id="24307-162">縦横比が正方形であるため、アルバム アートのプレビューに最適。</span><span class="sxs-lookup"><span data-stu-id="24307-162">Good for previewing album art because of the square aspect ratio.</span></span> <br /> 
<span data-ttu-id="24307-163">ドキュメントは、ファイル ピッカーのウィンドウと同じように表示されます (同じアイコンを使用)。</span><span class="sxs-lookup"><span data-stu-id="24307-163">Documents look the same as they look in a file picker window (it uses the same icons).</span></span> </td>
</tr>
</table>

<span data-ttu-id="24307-164">以下の例は、取得したサムネイル画像が、ファイルの種類とサムネイル モードに応じてどのように異なるかを示しています。</span><span class="sxs-lookup"><span data-stu-id="24307-164">Here are examples showing how retrieved thumbnail images differ depending on file type and thumbnail mode:</span></span>
<div class="mx-responsive-img">
<table>
<tr>
<th><span data-ttu-id="24307-165">項目の種類</span><span class="sxs-lookup"><span data-stu-id="24307-165">Item type</span></span></th>
<th><span data-ttu-id="24307-166">取得時に使ったモード:</span><span class="sxs-lookup"><span data-stu-id="24307-166">When retrieved using:</span></span> <ul><li><span data-ttu-id="24307-167">PicturesView</span><span class="sxs-lookup"><span data-stu-id="24307-167">PicturesView</span></span> <li><span data-ttu-id="24307-168">VideosView</span><span class="sxs-lookup"><span data-stu-id="24307-168">VideosView</span></span></ul></th>
<th><span data-ttu-id="24307-169">取得時に使ったモード:</span><span class="sxs-lookup"><span data-stu-id="24307-169">When retrieved using:</span></span> <ul><li><span data-ttu-id="24307-170">DocumentsView</span><span class="sxs-lookup"><span data-stu-id="24307-170">DocumentsView</span></span> <li><span data-ttu-id="24307-171">MusicView</span><span class="sxs-lookup"><span data-stu-id="24307-171">MusicView</span></span> <li><span data-ttu-id="24307-172">ListView</span><span class="sxs-lookup"><span data-stu-id="24307-172">ListView</span></span></ul></th>
<th><span data-ttu-id="24307-173">取得時に使ったモード:</span><span class="sxs-lookup"><span data-stu-id="24307-173">When retrieved using:</span></span> <ul><li><span data-ttu-id="24307-174">SingleItem</span><span class="sxs-lookup"><span data-stu-id="24307-174">SingleItem</span></span></ul></th>
<tr>
<tr>
<td><span data-ttu-id="24307-175">画像</span><span class="sxs-lookup"><span data-stu-id="24307-175">Picture</span></span></td>
<td><span data-ttu-id="24307-176">サムネイル画像には、ファイルの元の縦横比が使われます。</span><span class="sxs-lookup"><span data-stu-id="24307-176">The thumbnail image uses the original aspect ratio of the file.</span></span> <br />
<img src="images/thumbnail-pic-picvidmode.png" alt="Picture thumbnail in picture or video mode"/></td>
<td><span data-ttu-id="24307-177">サムネイルは縦横比が正方形になるようにトリミングされています。</span><span class="sxs-lookup"><span data-stu-id="24307-177">The thumbnail is cropped to a square aspect ratio.</span></span> <br />
<img src="images/thumbnail-pic-doclistmusic-modes.png" alt="Picture thumbnail in documents, music, or list modes"/></td>
<td><span data-ttu-id="24307-178">サムネイル画像には、ファイルの元の縦横比が使われます。</span><span class="sxs-lookup"><span data-stu-id="24307-178">The thumbnail image uses the original aspect ratio of the file.</span></span><br />
<img src="images/thumbnail-pic-single-mode.png" alt="Picture thumbnail in single mode"/> </td>
</tr>
<tr>
<td><span data-ttu-id="24307-179">Video</span><span class="sxs-lookup"><span data-stu-id="24307-179">Video</span></span></td>
<td><span data-ttu-id="24307-180">サムネイルには、画像と区別するためのアイコンが追加されます。</span><span class="sxs-lookup"><span data-stu-id="24307-180">The thumbnail has an icon that differentiates it from pictures.</span></span> <br />
<img src="images/thumbnail-vid-picvid-modes.png" alt="Video thumbnail in picture or video mode"/></td>
<td><span data-ttu-id="24307-181">サムネイルは縦横比が正方形になるようにトリミングされています。</span><span class="sxs-lookup"><span data-stu-id="24307-181">The thumbnail is cropped to a square aspect ratio.</span></span> <br />
<img src="images/thumbnail-vid-doclistmusic-modes.png" alt="Video thumbnail in documents, music, or list mode"/> </td>
<td><span data-ttu-id="24307-182">サムネイル画像には、ファイルの元の縦横比が使われます。</span><span class="sxs-lookup"><span data-stu-id="24307-182">The thumbnail image uses the original aspect ratio of the file.</span></span> <br />
<img src="images/thumbnail-vid-single-mode.png" alt="Video thumbnail in single mode"/></td>
</tr>
<tr>
<td><span data-ttu-id="24307-183">音楽</span><span class="sxs-lookup"><span data-stu-id="24307-183">Music</span></span></td>
<td><span data-ttu-id="24307-184">サムネイルは、適切なサイズの背景に配置されたアイコンです。</span><span class="sxs-lookup"><span data-stu-id="24307-184">The thumbnail is an icon on a background of appropriate size.</span></span> <span data-ttu-id="24307-185">背景色は、アプリのタイルの背景色によって決まります。</span><span class="sxs-lookup"><span data-stu-id="24307-185">The background color is determined by the app's tile background color.</span></span> <br />
<img src="images/thumbnail-music-picvid-modes.png" alt="Music thumbnail in picture or video mode"/></td>
<td><span data-ttu-id="24307-186">ファイルにアルバム アートが含まれる場合、サムネイルはアルバム アートになります。</span><span class="sxs-lookup"><span data-stu-id="24307-186">If the file has album art, then the thumbnail is the album art.</span></span>  <br />
<img src="images/thumbnail-music-doclistmusic-modes.png" alt="Music thumbnail in documents, music, or list mode"/> <br />
<span data-ttu-id="24307-187">それ以外の場合、サムネイルは、適切なサイズの背景に配置されたアイコンです。</span><span class="sxs-lookup"><span data-stu-id="24307-187">Otherwise, the thumbnail is an icon on a background of appropriate size.</span></span></td>
<td><span data-ttu-id="24307-188">ファイルにアルバム アートが含まれる場合、サムネイルはアルバム アートになり、ファイルの元の縦横比が使われます。</span><span class="sxs-lookup"><span data-stu-id="24307-188">If the file has album art, then the thumbnail is the album art with the original aspect ratio of the file.</span></span>  <br />
<img src="images/thumbnail-music-single-mode.png" alt="Music thumbnail in single mode"/> <br />
<span data-ttu-id="24307-189">それ以外の場合、サムネイルはアイコンです。</span><span class="sxs-lookup"><span data-stu-id="24307-189">Otherwise, the thumbnail is an icon.</span></span> </td>
</tr>
<tr>
<td><span data-ttu-id="24307-190">ドキュメント</span><span class="sxs-lookup"><span data-stu-id="24307-190">Document</span></span></td>
<td><span data-ttu-id="24307-191">サムネイルは、適切なサイズの背景に配置されたアイコンです。</span><span class="sxs-lookup"><span data-stu-id="24307-191">The thumbnail is an icon on a background of appropriate size.</span></span> <span data-ttu-id="24307-192">背景色は、アプリのタイルの背景色によって決まります。</span><span class="sxs-lookup"><span data-stu-id="24307-192">The background color is determined by the app's tile background color.</span></span> <br />
<img src="images/thumbnail-docs-picvid-modes.png" alt="Document thumbnail in picture or video mode"/></td>
<td><span data-ttu-id="24307-193">サムネイルは、適切なサイズの背景に配置されたアイコンです。</span><span class="sxs-lookup"><span data-stu-id="24307-193">The thumbnail is an icon on a background of appropriate size.</span></span> <span data-ttu-id="24307-194">背景色は、アプリのタイルの背景色によって決まります。</span><span class="sxs-lookup"><span data-stu-id="24307-194">The background color is determined by the app's tile background color.</span></span> <br />
<img src="images/thumbnail-doc-doclistmusic-modes.png" alt="Document thumbnail in documents, music, or list mode"/></td>
<td><span data-ttu-id="24307-195">ドキュメントのサムネイルがある場合は、そのサムネイルが表示されます。</span><span class="sxs-lookup"><span data-stu-id="24307-195">The document thumbnail, if one exists.</span></span> <br />
<img src="images/thumbnail-doc1-single-mode.png" alt="Document thumbnail in single mode"/><br />
<span data-ttu-id="24307-196">それ以外の場合、サムネイルはアイコンです。</span><span class="sxs-lookup"><span data-stu-id="24307-196">Otherwise, the thumbnail is an icon.</span></span> <br />
<img src="images/thumbnail-doc2-single-mode.png" alt="Document thumbnail icon in single mode"/></td>
</tr>
<tr>
<td><span data-ttu-id="24307-197">Folder</span><span class="sxs-lookup"><span data-stu-id="24307-197">Folder</span></span></td>
<td><span data-ttu-id="24307-198">フォルダーに画像ファイルが含まれる場合は、画像のサムネイルが使われます。</span><span class="sxs-lookup"><span data-stu-id="24307-198">If there is a picture file in the folder, then the picture thumbnail is used.</span></span>  <br />
<img src="images/thumbnail-dir-picvid-modes.png" alt="Folder thumbnail in picture or video mode"/> <br />
<span data-ttu-id="24307-199">それ以外の場合、サムネイルは取得されません。</span><span class="sxs-lookup"><span data-stu-id="24307-199">Otherwise, no thumbnail is retrieved.</span></span></td>
<td><span data-ttu-id="24307-200">サムネイル画像は取得されません。</span><span class="sxs-lookup"><span data-stu-id="24307-200">No thumbnail image is retrieved.</span></span></td>
<td><span data-ttu-id="24307-201">サムネイルはフォルダー アイコンです。</span><span class="sxs-lookup"><span data-stu-id="24307-201">The thumbnail is the folder icon.</span></span><br />
<img src="images/thumbnail-dir-single-mode.png" alt="Folder icon thumbnail in single mode"/></td>
</tr>
<tr>
<td><span data-ttu-id="24307-202">ファイル グループ</span><span class="sxs-lookup"><span data-stu-id="24307-202">File group</span></span></td>
<td><span data-ttu-id="24307-203">フォルダーに画像ファイルが含まれる場合は、画像のサムネイルが使われます。</span><span class="sxs-lookup"><span data-stu-id="24307-203">If there is a picture file in the folder, then the picture thumbnail is used.</span></span><br />
<img src="images/thumbnail-grp-picvid-modes.png" alt="File group thumbnail in picture or video mode"/> <br /> <span data-ttu-id="24307-204">それ以外の場合、サムネイルは取得されません。</span><span class="sxs-lookup"><span data-stu-id="24307-204">Otherwise, no thumbnail is retrieved.</span></span> </td>
<td><span data-ttu-id="24307-205">グループ内のファイルにアルバム アートを含むファイルがある場合、サムネイルはアルバム アートになります。</span><span class="sxs-lookup"><span data-stu-id="24307-205">If there is a file that has album art among the files in the group, the thumbnail is the album art.</span></span> <br />
<img src="images/thumbnail-grp-doclistmusic-modes.png" alt="File group thumbnail in documents, music or list mode"/> <br /><span data-ttu-id="24307-206">それ以外の場合、サムネイルは取得されません。</span><span class="sxs-lookup"><span data-stu-id="24307-206">Otherwise, no thumbnail is retrieved.</span></span> </td>
<td><span data-ttu-id="24307-207">グループ内のファイルにアルバム アートを含むファイルがある場合、サムネイルはアルバム アートになり、ファイルの元の縦横比が使われます。</span><span class="sxs-lookup"><span data-stu-id="24307-207">If there is a file that has album art among the files in the group, the thumbnail is the album art and uses the original aspect ratio of the file.</span></span> <br />
<img src="images/thumbnail-grp1-single-mode.png" alt="File group thumbnail in picture or video mode"/> <br /><span data-ttu-id="24307-208">それ以外の場合、サムネイルはファイルのグループを表すアイコンです。</span><span class="sxs-lookup"><span data-stu-id="24307-208">Otherwise, the thumbnail is an icon that represents a group of files.</span></span> <br />
<img src="images/thumbnail-grp2-single-mode.png" alt="File group icon in single mode"/> 
</td>
</tr>
</table>
</div>

## <a name="related-topics"></a><span data-ttu-id="24307-209">関連トピック</span><span class="sxs-lookup"><span data-stu-id="24307-209">Related topics</span></span>
- [<span data-ttu-id="24307-210">ThumbnailMode 列挙型</span><span class="sxs-lookup"><span data-stu-id="24307-210">ThumbnailMode enum</span></span>](https://docs.microsoft.com/uwp/api/windows.storage.fileproperties.thumbnailmode)
- [<span data-ttu-id="24307-211">StorageItemThumbnail クラス</span><span class="sxs-lookup"><span data-stu-id="24307-211">StorageItemThumbnail class</span></span>](https://docs.microsoft.com/uwp/api/Windows.Storage.FileProperties.StorageItemThumbnail)
- [<span data-ttu-id="24307-212">StorageFile クラス</span><span class="sxs-lookup"><span data-stu-id="24307-212">StorageFile class</span></span>](https://docs.microsoft.com/uwp/api/windows.storage.storagefile)
- [<span data-ttu-id="24307-213">ファイルとフォルダーのサムネイル サンプル (GitHub)</span><span class="sxs-lookup"><span data-stu-id="24307-213">File and folder thumbnail sample (GitHub)</span></span>](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/FileThumbnails)
- [<span data-ttu-id="24307-214">リストとグリッド ビュー</span><span class="sxs-lookup"><span data-stu-id="24307-214">List and grid view</span></span>](../design/controls-and-patterns/lists.md)