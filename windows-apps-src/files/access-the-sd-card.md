---
author: normesta
ms.assetid: CAC6A7C7-3348-4EC4-8327-D47EB6E0C238
title: "SD カードへのアクセス"
description: "オプションの microSD カードに重要度の低いデータを保存したり、これらのデータにアクセスしたりすることができます (特に内部ストレージに制限がある低コストのモバイル デバイスの場合)。"
translationtype: Human Translation
ms.sourcegitcommit: de0b23cfd8f6323d3618c3424a27a7d0ce5e1374
ms.openlocfilehash: c3ce9103f78a78e95214239e41a302ccd0e59796

---
# SD カードへのアクセス

\[ Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132) をご覧ください \]


オプションの microSD カード上にある重要度の低いデータに保存およびアクセスできます (特に内部ストレージに制限がある低コストのモバイル デバイス)。

ほとんどの場合、アプリで SD カード上のファイルの保存とアクセスを行うには、アプリ マニフェスト ファイルで **removableStorage** 機能を指定する必要があります。 通常、アプリから保存したりアクセスしたりするファイルの種類を処理対象として登録することも必要です。

次の方法を使って、オプションの SD カードに対してファイルの保存とアクセスを行うことができます。

- ファイル ピッカー

- [**Windows.Storage**](https://msdn.microsoft.com/library/windows/apps/br227346) API

## SD カードでアクセスできるデータとアクセスできないデータ

### アクセスできるデータ

- アプリでファイルの読み取りと書き込みを実行するには、そのファイルの種類が処理対象となるように、アプリでアプリ マニフェスト ファイルに登録する必要があります。

- アプリでは、フォルダーの作成と管理も実行できます。

### アクセスできないデータ

- アプリでは、システム フォルダーとそのフォルダー内のファイルを参照したり、アクセスしたりすることはできません。

- 隠し属性でマークされたファイルを参照することはできません。 通常、隠し属性は、データを誤って削除するというリスクを減らすために使われます。

- [**KnownFolders.DocumentsLibrary**](https://msdn.microsoft.com/library/windows/apps/br227152) を使ってドキュメント ライブラリを参照したり、ドキュメント ライブラリにアクセスしたりすることはできません。 ただしファイル システムを走査することによって、SD カード上のドキュメント ライブラリにアクセスすることはできます。

## セキュリティとプライバシーに関する考慮事項

アプリが SD カードのグローバルな場所にファイルを保存する場合、それらのファイルは暗号化されないため、通常は他のアプリからアクセスすることができます。

- SD カードがデバイスに挿入されている間、SD カード上のファイルは、同じファイルの種類を処理対象として登録している他のアプリからアクセスすることができます。

- SD カードをデバイスから取り外し、PC で開くと、ファイルはエクスプローラーに表示されるため、他のアプリからアクセスすることができます。

アプリを SD カードにインストールし、ファイルを SD カードの [**LocalFolder**](https://msdn.microsoft.com/library/windows/apps/br241621) に保存する場合、それらのファイルは暗号化されるため、他のアプリからアクセスすることはできません。

## SD カード上のファイルへアクセスするための要件

SD カードのファイルにアクセスするには通常、次のことを指定する必要があります。

1.  アプリ マニフェスト ファイルで **removableStorage** 機能を指定する必要があります。
2.  また、アクセスするメディアの種類に関連付けられたファイル拡張子を処理対象として登録する必要があります。

**KnownFolders.MusicLibrary** などの既知のフォルダーを参照せずに SD カード上のメディア ファイルにアクセスしたり、メディア ライブラリ フォルダーの外部に格納されているメディア ファイルにアクセスしたりするに場合にも、上記の方法を使います。

ミュージック、写真、ビデオなどのメディア ライブラリに格納されているメディア ファイルに既知のフォルダーを使ってアクセスする場合は、関連付けられている機能 (**musicLibrary**、**picturesLibrary**、**videoLibrary**) をアプリ マニフェスト ファイルで指定するだけで十分です。 **removableStorage** 機能を指定する必要はありません。 詳しくは、「[ミュージック、画像、およびビデオ ライブラリのファイルとフォルダー](quickstart-managing-folders-in-the-music-pictures-and-videos-libraries.md)」をご覧ください。

## SD カード上のファイルへのアクセス

### SD カードへの参照の取得

[**KnownFolders.RemovableDevices**](https://msdn.microsoft.com/library/windows/apps/br227158) フォルダーは、デバイスに現在接続されている一連のリムーバブル デバイスに対する論理ルートである [**StorageFolder**](https://msdn.microsoft.com/library/windows/apps/br227230) です。 SD カードが取り付けられている場合は、**KnownFolders.RemovableDevices** フォルダーの下にある、最初の (唯一の) **StorageFolder** が SD カードを表します。

次のようなコードを使って、SD カードが存在するかどうかを判断し、SD カードへの参照を [**StorageFolder**](https://msdn.microsoft.com/library/windows/apps/br227230) として取得します。

```csharp
using Windows.Storage;

...

            // Get the logical root folder for all external storage devices.
            StorageFolder externalDevices = Windows.Storage.KnownFolders.RemovableDevices;

            // Get the first child folder, which represents the SD card.
            StorageFolder sdCard = (await externalDevices.GetFoldersAsync()).FirstOrDefault();

            if (sdCard != null)
            {
                // An SD card is present and the sdCard variable now contains a reference to it.
            }
            else
            {
                // No SD card is present.
            }
```

### SD カードのコンテンツの照会

SD カードには、既知のフォルダーとして認識されないさまざまなフォルダーやファイルを含めることができますが、[**KnownFolders**](https://msdn.microsoft.com/library/windows/apps/br227151) の場所の情報を使って照会することはできません。 ファイルを検索するには、アプリでファイル システムを再帰的に走査して、SD カードのコンテンツを列挙する必要があります。 SD カードのコンテンツを効率的に取得するには、[**GetFilesAsync (CommonFileQuery.DefaultQuery)**](https://msdn.microsoft.com/library/windows/apps/br227274) と [**GetFoldersAsync (CommonFolderQuery.DefaultQuery)**](https://msdn.microsoft.com/library/windows/apps/br227281) を使います。

SD カードを走査するにはバックグラウンド スレッドを使うことをお勧めします。 SD カードには、かなりのギガバイト数のデータを格納できる場合があります。

また、アプリでは、ユーザーに対してフォルダー ピッカーを使って特定のフォルダーを選ぶように要求することもできます。

[**KnownFolders.RemovableDevices**](https://msdn.microsoft.com/library/windows/apps/br227158) から取得したパスを使って SD カード上のファイル システムにアクセスした場合のメソッドの動作を次に示します。

-   [**GetFilesAsync**](https://msdn.microsoft.com/library/windows/apps/br227273) メソッドは、処理対象として登録したファイル拡張子と、指定したメディア ライブラリ機能に関連付けられているファイル拡張子との和集合を返します。

-   アクセスしようとするファイルの拡張子を処理対象として登録しなかった場合、[**GetFileFromPathAsync**](https://msdn.microsoft.com/library/windows/apps/br227206) メソッドは失敗します。

## 個々の SD カードの識別

SD カードが最初にマウントされると、オペレーティング システムによって、そのカードの一意の識別子が生成されます。 この ID は、カードのルートにある WPSystem フォルダー内のファイルに格納されます。 アプリはこの ID を使って、カードを認識できるかどうかを判断することができます。 カードがアプリによって認識されると、アプリでは、既に完了している特定の操作を後で実行できる場合があります。 ただし、アプリが前回カードにアクセスした以降、カードのコンテンツが変更されている可能性があります。

たとえば、電子ブックにインデックスを付けるアプリについて考えてみましょう。 アプリが以前に SD カード全体を走査して電子ブックのファイルを探し、電子ブックのインデックスを作成した場合、カードをもう一度挿入し、アプリがカードを認識すると、直ちにインデックスの一覧を表示できます。 これとは別に、新しい電子ブックを検索する優先度の低いバックグラウンド スレッドを開始することもできます。 また、削除された電子ブックへアクセスしようとしたとき、以前に存在していた電子ブックが見つからなかった場合のエラーを処理することもできます。

この ID を含むプロパティの名前は、**WindowsPhone.ExternalStorageId** です。

```csharp
using Windows.Storage;

...

            // Get the logical root folder for all external storage devices.
            StorageFolder externalDevices = Windows.Storage.KnownFolders.RemovableDevices;

            // Get the first child folder, which represents the SD card.
            StorageFolder sdCard = (await externalDevices.GetFoldersAsync()).FirstOrDefault();

            if (sdCard != null)
            {
                var allProperties = sdCard.Properties;
                IEnumerable<string> propertiesToRetrieve = new List<string> { "WindowsPhone.ExternalStorageId" };

                var storageIdProperties = await allProperties.RetrievePropertiesAsync(propertiesToRetrieve);

                string cardId = (string)storageIdProperties["WindowsPhone.ExternalStorageId"];

                if (...) // If cardID matches the cached ID of a recognized card.
                {
                    // Card is recognized. Index contents opportunistically.
                }
                else
                {
                    // Card is not recognized. Index contents immediately.
                }
            }
```

 

 



<!--HONumber=Aug16_HO3-->


