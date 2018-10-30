---
author: laurenhughes
ms.assetid: D5D98044-7221-4C2A-9724-56E59F341AB0
description: この記事では、画像のメタデータ プロパティを読み取ったり書き込んだりする方法のほか、GeotagHelper ユーティリティ クラスを使ってファイルに位置情報タグを設定する方法について説明します。
title: 画像のメタデータ
ms.author: lahugh
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: a3e2f10174412b49ce60f3da6a4bb73b2efc4411
ms.sourcegitcommit: 753e0a7160a88830d9908b446ef0907cc71c64e7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/30/2018
ms.locfileid: "5765848"
---
# <a name="image-metadata"></a>画像のメタデータ



この記事では、画像のメタデータ プロパティを読み取ったり書き込んだりする方法のほか、[**GeotagHelper**](https://msdn.microsoft.com/library/windows/apps/dn903683) ユーティリティ クラスを使ってファイルに位置情報タグを設定する方法について説明します。

## <a name="image-properties"></a>画像のプロパティ

ファイルの内容に関連した情報には、[**StorageFile.Properties**](https://msdn.microsoft.com/library/windows/apps/br227225) プロパティから返される [**StorageItemContentProperties**](https://msdn.microsoft.com/library/windows/apps/hh770642) オブジェクトを使ってアクセスできます。 画像に固有のプロパティを取得するには、[**GetImagePropertiesAsync**](https://msdn.microsoft.com/library/windows/apps/hh770646) を呼び出します。 それによって返される [**ImageProperties**](https://msdn.microsoft.com/library/windows/apps/br207718) オブジェクトは、画像のタイトルやキャプチャの日付など、基本的な画像メタデータのフィールドを含んだメンバーを公開します。

[!code-cs[GetImageProperties](./code/ImagingWin10/cs/MainPage.xaml.cs#SnippetGetImageProperties)]

さらに広範なファイル メタデータにアクセスするには、一意の文字列識別子で取得できるファイル メタデータ プロパティが集約された Windows プロパティ システムを使います。 文字列のリストを作成し、取得する必要のある各プロパティの識別子を追加してください。 [**ImageProperties.RetrievePropertiesAsync**](https://msdn.microsoft.com/library/windows/apps/br207732) メソッドは、この文字列のリストを引数として受け取ってキー/値ペアのディクショナリを返します。このディクショナリのキーがプロパティ識別子で、ディクショナリの値がそのプロパティの値になります。

[!code-cs[GetWindowsProperties](./code/ImagingWin10/cs/MainPage.xaml.cs#SnippetGetWindowsProperties)]

-   Windows のプロパティの完全な一覧 (プロパティごとの識別子と型を含む) については、「[Windows プロパティ](https://msdn.microsoft.com/library/windows/desktop/dd561977)」をご覧ください。

-   一部のプロパティは、特定のファイル コンテナーや特定の画像コーデックでのみサポートされます。 画像の種類ごとのサポートされるメタデータについては、「[フォト メタデータ ポリシー](https://msdn.microsoft.com/library/windows/desktop/ee872003)」をご覧ください。

-   サポート対象外のプロパティを取得しようとすると null 値が返される場合があります。返されたメタデータの値を使う前に必ず、null のチェックを行ってください。

## <a name="geotag-helper"></a>位置情報タグ ヘルパー

GeotagHelper は、地理データを含んだ画像へのタグ付けを支援するユーティリティ クラスです。[**Windows.Devices.Geolocation**](https://msdn.microsoft.com/library/windows/apps/br225603) API を直接使って簡単にタグを設定することができます。メタデータの形式を手動で解析したり構築したりする必要はありません。

地理位置情報 API の使用後など、タグの設定対象となる画像の位置情報を表す [**Geopoint**](https://msdn.microsoft.com/library/windows/apps/dn263675) オブジェクトが取得済みで、そのオブジェクトが既に存在する場合は、[**GeotagHelper.SetGeotagAsync**](https://msdn.microsoft.com/library/windows/apps/dn903685) に [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171) と **Geopoint** を渡して呼び出すことで位置情報タグ データを設定できます。

[!code-cs[SetGeoDataFromPoint](./code/ImagingWin10/cs/MainPage.xaml.cs#SnippetSetGeoDataFromPoint)]

デバイスの現在位置を使って位置情報タグ データを設定するには、[**Geolocator**](https://msdn.microsoft.com/library/windows/apps/br225534) オブジェクトを新たに作成し、[**GeotagHelper.SetGeotagFromGeolocatorAsync**](https://msdn.microsoft.com/library/windows/apps/dn903686) に **Geolocator** とタグの設定対象となるファイルを渡して呼び出します。

[!code-cs[SetGeoDataFromGeolocator](./code/ImagingWin10/cs/MainPage.xaml.cs#SnippetSetGeoDataFromGeolocator)]

-   [**SetGeotagFromGeolocatorAsync**](https://msdn.microsoft.com/library/windows/apps/dn903686) API を使うには、アプリ マニフェストに**位置情報**デバイス機能を追加する必要があります。

-   [**SetGeotagFromGeolocatorAsync**](https://msdn.microsoft.com/library/windows/apps/dn903686) を呼び出す前に [**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/dn859152) を呼び出し、ユーザーの位置情報をアプリで使うための許可を得ておく必要があります。

-   地理位置情報 API について詳しくは、「[マップと位置情報](https://msdn.microsoft.com/library/windows/apps/mt219699)」をご覧ください。

位置情報タグで示された画像ファイルの地理的位置を表す GeoPoint を取得するには、[**GetGeotagAsync**](https://msdn.microsoft.com/library/windows/apps/dn903684) を呼び出します。

[!code-cs[GetGeoData](./code/ImagingWin10/cs/MainPage.xaml.cs#SnippetGetGeoData)]

## <a name="decode-and-encode-image-metadata"></a>画像メタデータのデコードとエンコード

画像データを操作する最も高度な方法は、[**BitmapDecoder**](https://msdn.microsoft.com/library/windows/apps/br226176) または [BitmapEncoder](bitmapencoder-options-reference.md) を使って、プロパティの読み取りと書き込みをストリーム レベルで行うことです。 これらの操作では、読み取りまたは書き込みの対象データを Windows プロパティを使って指定できるほか、要求するプロパティのパスを Windows Imaging Component (WIC) のメタデータ クエリ言語を使って指定することもできます。

この方法で画像のメタデータを読み取るには、ソース画像ファイル ストリームを使って作成された [**BitmapDecoder**](https://msdn.microsoft.com/library/windows/apps/br226176) が必要です。 この方法については、「[イメージング](imaging.md)」をご覧ください。

デコーダーを取得したら、文字列のリストを作成し、Windows プロパティの識別子文字列または WIC メタデータ クエリを使って、取得する各メタデータ プロパティの新しいエントリを追加します。 特定のプロパティを要求するには、デコーダーの [**BitmapProperties**](https://msdn.microsoft.com/library/windows/apps/br226248) メンバーの [**BitmapPropertiesView.GetPropertiesAsync**](https://msdn.microsoft.com/library/windows/apps/br226250) メソッドを呼び出します。 要求したプロパティが、プロパティ名 (またはパス) とプロパティ値を含んだキー/値ペアのディクショナリとして返されます。

[!code-cs[ReadImageMetadata](./code/ImagingWin10/cs/MainPage.xaml.cs#SnippetReadImageMetadata)]

-   WIC メタデータ クエリ言語とサポートされるプロパティについては、「[WIC ネイティブ イメージ形式メタデータのクエリ](https://msdn.microsoft.com/library/windows/desktop/ee719904)」をご覧ください。

-   メタデータのプロパティの多くは、サポートされる画像の種類に限りがあります。 デコーダーに関連付けられている画像が、要求したプロパティのいずれかをサポートしていない場合、[**GetPropertiesAsync**](https://msdn.microsoft.com/library/windows/apps/br226250) はエラー コード 0x88982F41 で失敗します。画像がどのメタデータもサポートしていない場合は、0x88982F81 で失敗します。 この 2 つのエラー コードに関連付けられている定数はそれぞれ WINCODEC\_ERR\_PROPERTYNOTSUPPORTED と WINCODEC\_ERR\_UNSUPPORTEDOPERATION で、winerror.h ヘッダー ファイルに定義されています。
-   特定のプロパティの値が画像に存在するかどうかはわからないので、**IDictionary.ContainsKey** を使って、結果にプロパティが存在するかどうかを確かめたうえでアクセスしてください。

画像のメタデータをストリームに書き込むには、画像の出力ファイルに関連付けられている **BitmapEncoder** が必要です。

設定対象プロパティの値を保持する [**BitmapPropertySet**](https://msdn.microsoft.com/library/windows/apps/hh974338) オブジェクトを作成します。 プロパティの値を表す [**BitmapTypedValue**](https://msdn.microsoft.com/library/windows/apps/hh700687) オブジェクトを作成します。 このオブジェクトでは、値の型を定義する [**PropertyType**](https://msdn.microsoft.com/library/windows/apps/br225871) 列挙型の値およびメンバーとして **object** を使います。 **BitmapTypedValue** を **BitmapPropertySet** に追加したうえで、[**BitmapProperties.SetPropertiesAsync**](https://msdn.microsoft.com/library/windows/apps/br226252) を呼び出すと、エンコーダーがプロパティをストリームに書き込みます。

[!code-cs[WriteImageMetadata](./code/ImagingWin10/cs/MainPage.xaml.cs#SnippetWriteImageMetadata)]

-   画像ファイルの種類ごとのサポート対象プロパティについて詳しくは、「[Windows プロパティ](https://msdn.microsoft.com/library/windows/desktop/dd561977)」、「[フォト メタデータ ポリシー](https://msdn.microsoft.com/library/windows/desktop/ee872003)」、「[WIC ネイティブ イメージ形式メタデータのクエリ](https://msdn.microsoft.com/library/windows/desktop/ee719904)」をご覧ください。

-   エンコーダーに関連付けられている画像が、要求したプロパティのいずれかをサポートしていない場合、[**SetPropertiesAsync**](https://msdn.microsoft.com/library/windows/apps/br226252) はエラー コード 0x88982F41 で失敗します。

## <a name="related-topics"></a>関連トピック

* [イメージング](imaging.md)
 

 




