---
author: laurenhughes
ms.assetid: 1901c4c2-5161-435d-bc7b-f40c69cdb138
title: ファイル、フォルダー、およびライブラリ
description: アプリの設定の読み取りと書き込み、ファイルやフォルダーのピッカー、ビデオ ライブラリやミュージック ライブラリなどのセキュリティで保護された特別なサンドボックス化された場所について説明します。
ms.author: lahugh
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 80c6292c12568d7f1017ca67707689ce9539c804
ms.sourcegitcommit: 4d88adfaf544a3dab05f4660e2f59bbe60311c00
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/12/2018
ms.locfileid: "6448347"
---
 # <a name="files-folders-and-libraries"></a>ファイル、フォルダー、およびライブラリ


[Windows.Storage](https://msdn.microsoft.com/library/windows/apps/br227346)、[Windows.Storage.Streams](https://msdn.microsoft.com/library/windows/apps/br241791)、[Windows.Storage.Pickers](https://msdn.microsoft.com/library/windows/apps/br207928) の各名前空間の API を使い、ファイル内にあるテキストやその他のデータ形式の読み取りと書き込み、およびファイルやフォルダーの管理を行います。 このセクションでは、アプリの設定の読み取りと書き込み、ファイルやフォルダーのピッカー、およびビデオ ライブラリやミュージック ライブラリなどのセキュリティで保護された特別な場所についても説明します。

| トピック | 説明  |
|-------|--------------|
| [ファイルとフォルダーの列挙と照会](quickstart-listing-files-and-folders.md) | フォルダー、ライブラリ、デバイス、またはネットワークの場所にあるファイルやフォルダーにアクセスします。 ファイルやフォルダーのクエリを作成することで、任意の場所にあるファイルやフォルダーを照会することもできます。 |
| [ファイルの作成、書き込み、および読み取り](quickstart-reading-and-writing-files.md) | [StorageFile](https://msdn.microsoft.com/library/windows/apps/br227171) オブジェクトを使ってファイルの読み取りと書き込みを行います。 |
| [ファイルのプロパティの取得](quickstart-getting-file-properties.md) | [StorageFile](https://msdn.microsoft.com/library/windows/apps/br227171) オブジェクトで表されるファイルのプロパティ (最上位、基本、拡張) を取得します。 |
| [ピッカーでファイルやフォルダーを開く](quickstart-using-file-and-folder-pickers.md) | ユーザーがピッカーを操作してファイルやフォルダーにアクセスできるようにします。 フォルダーへのアクセスには [FolderPicker](https://msdn.microsoft.com/library/windows/apps/br207881) を使います。 |
| [ピッカーによるファイルの保存](quickstart-save-a-file-with-a-picker.md) | [FileSavePicker](https://msdn.microsoft.com/library/windows/apps/br207871) を使って、アプリで保存するファイルの名前とその保存場所をユーザーが指定できるようにします。 |
| [ホームグループ コンテンツへのアクセス](quickstart-accessing-homegroup-content.md) | ユーザーのホームグループ フォルダーに格納されているコンテンツ (画像、音楽、ビデオなど) にアクセスします。 |
| [Microsoft OneDrive ファイルが利用可能かどうかの確認](quickstart-determining-availability-of-microsoft-onedrive-files.md) | [StorageFile.IsAvailable](https://msdn.microsoft.com/library/windows/apps/windows.storage.storagefile.isavailable.aspx) プロパティを使って、Microsoft OneDrive ファイルが利用可能かどうかを確認します。 |
| [ミュージック、画像、およびビデオ ライブラリのファイルとフォルダー](quickstart-managing-folders-in-the-music-pictures-and-videos-libraries.md) | 音楽、画像、またはビデオの既存のフォルダーを対応するライブラリに追加できます。 ライブラリからフォルダーを削除したり、ライブラリ内のフォルダーの一覧を取得したり、保存した写真、音楽、ビデオにアクセスしたりすることもできます。 |
| [最近使ったファイルやフォルダーの追跡](how-to-track-recently-used-files-and-folders.md) | ユーザーが頻繁にアクセスするファイルを追跡するには、そのファイルを最近使ったアプリの一覧 (MRU) に追加します。 MRU はプラットフォームが管理し、最後にアクセスした日時に基づいて項目を並べ替えたり、一覧の上限である 25 項目に達したら最も古い項目を削除したりします。 すべてのアプリにはそれぞれに専用の MRU があります。 |
| [SD カードへのアクセス](access-the-sd-card.md) | オプションの microSD カードに重要度の低いデータを保存したり、これらのデータにアクセスしたりすることができます (特に内部ストレージに制限がある低コストのモバイル デバイスの場合)。 |
| [ファイル アクセス許可](file-access-permissions.md) | アプリは既定でファイル システムの特定の場所にアクセスできます。 また、ファイル ピッカーの使用や機能の宣言によって、その他の場所にアクセスすることもできます。 |
| [UWP でファイルのプロパティにすばやくアクセスする](fast-file-properties.md) | UWP アプリで使用するために、ライブラリからファイルとそのプロパティの一覧を効率的に収集します。 |

## <a name="related-samples"></a>関連するサンプル
[フォルダーの列挙のサンプル](http://go.microsoft.com/fwlink/p/?linkid=619993)

[ファイル アクセスのサンプル](http://go.microsoft.com/fwlink/p/?linkid=619995)

[ファイル ピッカーのサンプル](http://go.microsoft.com/fwlink/p/?linkid=619994)
 

 
