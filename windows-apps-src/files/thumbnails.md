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
ms.sourcegitcommit: 4b97117d3aff38db89d560502a3c372f12bb6ed5
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/23/2018
ms.locfileid: "5438382"
---
# <a name="thumbnail-images"></a>サムネイル画像

このガイドラインでは、サムネイル画像を使って、UWP アプリでファイルを参照するときにファイルをプレビューできるようにする方法について説明します。 

> **重要な API**: [ThumbnailMode 列挙型](https://docs.microsoft.com/uwp/api/windows.storage.fileproperties.thumbnailmode)

## <a name="should-my-app-include-thumbnails"></a>アプリにサムネイルを含めるかどうか

アプリでユーザーがファイルを参照できるようにする場合、サムネイル画像を表示することで、ファイルをすばやくプレビューすることが可能になります。 

サムネイルは次の場合に使います。 
- ギャラリー コレクションに含まれる多くの項目 (ファイルやフォルダーなど) のプレビューを表示する場合。 たとえば、フォト ギャラリーでは、ユーザーが写真ファイルを参照するときにサムネイルを使って各写真が小さく表示されるようにします。

    ![ビデオ ギャラリー](images/thumbnail-gallery.png)

- リスト内にある個別の項目 (特定のファイルなど) に対するプレビューを表示する場合。 たとえば、ユーザーがファイルを開くかどうかを決める前に、より見やすい大きなサムネイルと共に、ファイルの詳しい情報を表示できます。 

    ![ビデオのプレビュー](images/thumbnail-preview.png)

## <a name="dos-and-donts"></a>推奨と非推奨
- サムネイルを取得するときに、[サムネイル モード](https://docs.microsoft.com/uwp/api/windows.storage.fileproperties.thumbnailmode) (PicturesView, VideosView, DocumentsView, MusicView, ListView, or SingleItem) を指定します。 これにより、ユーザーが確認するファイルの種類を表示するようにサムネイル画像が最適化されます。 
    - ファイルの種類に関係なく単一項目用のサムネイルを取得するには、 SingleItem モードを使います。 その他のサムネイル モードの目的は、複数ファイルのプレビューを表示することです。 

- サムネイルの読み込み中は、サムネイルの代わりに汎用のプレースホルダー画像を表示します。 プレースホルダーを使うことで、サムネイルの読み込みが終わる前にプレビューを操作できるため、アプリの体感的な応答速度を高めることができます。 

    プレースホルダー画像は次の条件を満たす必要があります。
    * 代わりとなる項目の種類に固有である。 たとえば、フォルダー、画像、動画にはすべて、それぞれ異なるプレースホルダーを用意する必要があります。 
    * 代わりとなるサムネイル画像とサイズおよび縦横比が同じである。 
    * サムネイル画像が読み込まれるまで表示される。 

- フォルダーやファイル グループを個別のファイルと区別するには、テキスト ラベル付きのプレースホルダー画像を使います。

- サムネイルを取得できない場合は、プレースホルダー画像を表示します。 

- ドキュメントや音楽ファイルのプレビューを表示するときは、追加のファイル情報も表示します。 これによってユーザーは、サムネイル画像だけでは簡単に取得できない可能性のある、ファイルに関する重要な情報を確認できます。 たとえば音楽ファイルの場合、アルバム アートのサムネイルと一緒にアーティスト名を表示できます。 

- 画像ファイルとビデオ ファイルに関する追加のファイル情報は表示しないでください。 ほとんどの場合、ユーザーが画像やビデオを参照する場合は、サムネイル画像だけで十分です。 

## <a name="additional-usage-guidelines"></a>その他の使い方のガイドライン
推奨される[サムネイル モード](https://docs.microsoft.com/uwp/api/windows.storage.fileproperties.thumbnailmode)とその特徴:

<table>
<tr>
<th> プレビューの表示対象</th>
<th> サムネイル モード </th>
<th> 取得するサムネイル画像の特徴 </th>
</tr>
<tr>
<td> 画像<br /> ビデオ </td>
<td> PicturesView <br />VideosView </td>
<td> <b>サイズ</b>: 中、190 以上を推奨 (画像サイズが 190 × 130 の場合) <br />
<b>縦横比</b>: 均一な横長の縦横比 (約 0.7) (サイズが 190 の場合は 190 × 130) <br />
プレビューの場合はトリミングされます。 <br /> 
縦横比が統一されているため、画像をグリッド内で揃えるときに便利です。  </td>
</tr>
<tr>
<td> ドキュメント<br />音楽 </td>
<td> DocumentsView <br />MusicView <br /> ListView</td>
<td> <b>サイズ</b>: 小、40 × 40 ピクセル以上を推奨 <br />
<b>縦横比</b>:  均一な正方形の縦横比  <br />
縦横比が正方形であるため、アルバム アートのプレビューに最適。 <br /> 
ドキュメントは、ファイル ピッカーのウィンドウと同じように表示されます (同じアイコンを使用)。 </td>
</tr>
</tr>
<tr>
<td> 任意の 1 つの項目 (ファイルの種類を考慮しない場合) </td>
<td> SingleItem </td>
<td> <b>サイズ</b>: 小、40 × 40 ピクセル以上を推奨 <br />
<b>縦横比</b>:  均一な正方形の縦横比  <br />
縦横比が正方形であるため、アルバム アートのプレビューに最適。 <br /> 
ドキュメントは、ファイル ピッカーのウィンドウと同じように表示されます (同じアイコンを使用)。 </td>
</tr>
</table>

以下の例は、取得したサムネイル画像が、ファイルの種類とサムネイル モードに応じてどのように異なるかを示しています。
<div class="mx-responsive-img">
<table>
<tr>
<th>項目の種類</th>
<th>取得時に使ったモード: <ul><li>PicturesView <li>VideosView</ul></th>
<th>取得時に使ったモード: <ul><li>DocumentsView <li>MusicView <li>ListView</ul></th>
<th>取得時に使ったモード: <ul><li>SingleItem</ul></th>
<tr>
<tr>
<td>画像</td>
<td>サムネイル画像には、ファイルの元の縦横比が使われます。 <br />
<img src="images/thumbnail-pic-picvidmode.png" alt="Picture thumbnail in picture or video mode"/></td>
<td>サムネイルは縦横比が正方形になるようにトリミングされています。 <br />
<img src="images/thumbnail-pic-doclistmusic-modes.png" alt="Picture thumbnail in documents, music, or list modes"/></td>
<td>サムネイル画像には、ファイルの元の縦横比が使われます。<br />
<img src="images/thumbnail-pic-single-mode.png" alt="Picture thumbnail in single mode"/> </td>
</tr>
<tr>
<td>ビデオ</td>
<td>サムネイルには、画像と区別するためのアイコンが追加されます。 <br />
<img src="images/thumbnail-vid-picvid-modes.png" alt="Video thumbnail in picture or video mode"/></td>
<td>サムネイルは縦横比が正方形になるようにトリミングされています。 <br />
<img src="images/thumbnail-vid-doclistmusic-modes.png" alt="Video thumbnail in documents, music, or list mode"/> </td>
<td>サムネイル画像には、ファイルの元の縦横比が使われます。 <br />
<img src="images/thumbnail-vid-single-mode.png" alt="Video thumbnail in single mode"/></td>
</tr>
<tr>
<td>音楽</td>
<td>サムネイルは、適切なサイズの背景に配置されたアイコンです。 背景色は、アプリのタイルの背景色によって決まります。 <br />
<img src="images/thumbnail-music-picvid-modes.png" alt="Music thumbnail in picture or video mode"/></td>
<td>ファイルにアルバム アートが含まれる場合、サムネイルはアルバム アートになります。  <br />
<img src="images/thumbnail-music-doclistmusic-modes.png" alt="Music thumbnail in documents, music, or list mode"/> <br />
それ以外の場合、サムネイルは、適切なサイズの背景に配置されたアイコンです。</td>
<td>ファイルにアルバム アートが含まれる場合、サムネイルはアルバム アートになり、ファイルの元の縦横比が使われます。  <br />
<img src="images/thumbnail-music-single-mode.png" alt="Music thumbnail in single mode"/> <br />
それ以外の場合、サムネイルはアイコンです。 </td>
</tr>
<tr>
<td>ドキュメント</td>
<td>サムネイルは、適切なサイズの背景に配置されたアイコンです。 背景色は、アプリのタイルの背景色によって決まります。 <br />
<img src="images/thumbnail-docs-picvid-modes.png" alt="Document thumbnail in picture or video mode"/></td>
<td>サムネイルは、適切なサイズの背景に配置されたアイコンです。 背景色は、アプリのタイルの背景色によって決まります。 <br />
<img src="images/thumbnail-doc-doclistmusic-modes.png" alt="Document thumbnail in documents, music, or list mode"/></td>
<td>ドキュメントのサムネイルがある場合は、そのサムネイルが表示されます。 <br />
<img src="images/thumbnail-doc1-single-mode.png" alt="Document thumbnail in single mode"/><br />
それ以外の場合、サムネイルはアイコンです。 <br />
<img src="images/thumbnail-doc2-single-mode.png" alt="Document thumbnail icon in single mode"/></td>
</tr>
<tr>
<td>フォルダー</td>
<td>フォルダーに画像ファイルが含まれる場合は、画像のサムネイルが使われます。  <br />
<img src="images/thumbnail-dir-picvid-modes.png" alt="Folder thumbnail in picture or video mode"/> <br />
それ以外の場合、サムネイルは取得されません。</td>
<td>サムネイル画像は取得されません。</td>
<td>サムネイルはフォルダー アイコンです。<br />
<img src="images/thumbnail-dir-single-mode.png" alt="Folder icon thumbnail in single mode"/></td>
</tr>
<tr>
<td>ファイル グループ</td>
<td>フォルダーに画像ファイルが含まれる場合は、画像のサムネイルが使われます。<br />
<img src="images/thumbnail-grp-picvid-modes.png" alt="File group thumbnail in picture or video mode"/> <br /> それ以外の場合、サムネイルは取得されません。 </td>
<td>グループ内のファイルにアルバム アートを含むファイルがある場合、サムネイルはアルバム アートになります。 <br />
<img src="images/thumbnail-grp-doclistmusic-modes.png" alt="File group thumbnail in documents, music or list mode"/> <br />それ以外の場合、サムネイルは取得されません。 </td>
<td>グループ内のファイルにアルバム アートを含むファイルがある場合、サムネイルはアルバム アートになり、ファイルの元の縦横比が使われます。 <br />
<img src="images/thumbnail-grp1-single-mode.png" alt="File group thumbnail in picture or video mode"/> <br />それ以外の場合、サムネイルはファイルのグループを表すアイコンです。 <br />
<img src="images/thumbnail-grp2-single-mode.png" alt="File group icon in single mode"/> 
</td>
</tr>
</table>
</div>

## <a name="related-topics"></a>関連トピック
- [ThumbnailMode 列挙型](https://docs.microsoft.com/uwp/api/windows.storage.fileproperties.thumbnailmode)
- [StorageItemThumbnail クラス](https://docs.microsoft.com/uwp/api/Windows.Storage.FileProperties.StorageItemThumbnail)
- [StorageFile クラス](https://docs.microsoft.com/uwp/api/windows.storage.storagefile)
- [ファイルとフォルダーのサムネイルのサンプル (GitHub)](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/FileThumbnails)
- [リスト ビューとグリッド ビュー](../design/controls-and-patterns/lists.md)