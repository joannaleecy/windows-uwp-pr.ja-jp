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
ms.sourcegitcommit: e38b334edb82bf2b1474ba686990f4299b8f59c7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/14/2018
ms.locfileid: "6837430"
---
# <a name="image-metadata"></a><span data-ttu-id="8f99e-104">画像のメタデータ</span><span class="sxs-lookup"><span data-stu-id="8f99e-104">Image Metadata</span></span>



<span data-ttu-id="8f99e-105">この記事では、画像のメタデータ プロパティを読み取ったり書き込んだりする方法のほか、[**GeotagHelper**](https://msdn.microsoft.com/library/windows/apps/dn903683) ユーティリティ クラスを使ってファイルに位置情報タグを設定する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="8f99e-105">This article shows how to read and write image metadata properties and how to geotag files using the [**GeotagHelper**](https://msdn.microsoft.com/library/windows/apps/dn903683) utility class.</span></span>

## <a name="image-properties"></a><span data-ttu-id="8f99e-106">画像のプロパティ</span><span class="sxs-lookup"><span data-stu-id="8f99e-106">Image properties</span></span>

<span data-ttu-id="8f99e-107">ファイルの内容に関連した情報には、[**StorageFile.Properties**](https://msdn.microsoft.com/library/windows/apps/br227225) プロパティから返される [**StorageItemContentProperties**](https://msdn.microsoft.com/library/windows/apps/hh770642) オブジェクトを使ってアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="8f99e-107">The [**StorageFile.Properties**](https://msdn.microsoft.com/library/windows/apps/br227225) property returns a [**StorageItemContentProperties**](https://msdn.microsoft.com/library/windows/apps/hh770642) object that provides access to content-related information about the file.</span></span> <span data-ttu-id="8f99e-108">画像に固有のプロパティを取得するには、[**GetImagePropertiesAsync**](https://msdn.microsoft.com/library/windows/apps/hh770646) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="8f99e-108">Get the image-specific properties by calling [**GetImagePropertiesAsync**](https://msdn.microsoft.com/library/windows/apps/hh770646).</span></span> <span data-ttu-id="8f99e-109">それによって返される [**ImageProperties**](https://msdn.microsoft.com/library/windows/apps/br207718) オブジェクトは、画像のタイトルやキャプチャの日付など、基本的な画像メタデータのフィールドを含んだメンバーを公開します。</span><span class="sxs-lookup"><span data-stu-id="8f99e-109">The returned [**ImageProperties**](https://msdn.microsoft.com/library/windows/apps/br207718) object exposes members that contain basic image metadata fields, like the title of the image and the capture date.</span></span>

[!code-cs[GetImageProperties](./code/ImagingWin10/cs/MainPage.xaml.cs#SnippetGetImageProperties)]

<span data-ttu-id="8f99e-110">さらに広範なファイル メタデータにアクセスするには、一意の文字列識別子で取得できるファイル メタデータ プロパティが集約された Windows プロパティ システムを使います。</span><span class="sxs-lookup"><span data-stu-id="8f99e-110">To access a larger set of file metadata, use the Windows Property System, a set of file metadata properties that can be retrieved with a unique string identifier.</span></span> <span data-ttu-id="8f99e-111">文字列のリストを作成し、取得する必要のある各プロパティの識別子を追加してください。</span><span class="sxs-lookup"><span data-stu-id="8f99e-111">Create a list of strings and add the identifier for each property you want to retrieve.</span></span> <span data-ttu-id="8f99e-112">[**ImageProperties.RetrievePropertiesAsync**](https://msdn.microsoft.com/library/windows/apps/br207732) メソッドは、この文字列のリストを引数として受け取ってキー/値ペアのディクショナリを返します。このディクショナリのキーがプロパティ識別子で、ディクショナリの値がそのプロパティの値になります。</span><span class="sxs-lookup"><span data-stu-id="8f99e-112">The [**ImageProperties.RetrievePropertiesAsync**](https://msdn.microsoft.com/library/windows/apps/br207732) method takes this list of strings and returns a dictionary of key/value pairs where the key is the property identifier and the value is the property value.</span></span>

[!code-cs[GetWindowsProperties](./code/ImagingWin10/cs/MainPage.xaml.cs#SnippetGetWindowsProperties)]

-   <span data-ttu-id="8f99e-113">Windows のプロパティの完全な一覧 (プロパティごとの識別子と型を含む) については、「[Windows プロパティ](https://msdn.microsoft.com/library/windows/desktop/dd561977)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="8f99e-113">For a complete list of Windows Properties, including the identifiers and type for each property, see [Windows Properties](https://msdn.microsoft.com/library/windows/desktop/dd561977).</span></span>

-   <span data-ttu-id="8f99e-114">一部のプロパティは、特定のファイル コンテナーや特定の画像コーデックでのみサポートされます。</span><span class="sxs-lookup"><span data-stu-id="8f99e-114">Some properties are only supported for certain file containers and image codecs.</span></span> <span data-ttu-id="8f99e-115">画像の種類ごとのサポートされるメタデータについては、「[フォト メタデータ ポリシー](https://msdn.microsoft.com/library/windows/desktop/ee872003)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="8f99e-115">For a listing of the image metadata supported for each image type, see [Photo Metadata Policies](https://msdn.microsoft.com/library/windows/desktop/ee872003).</span></span>

-   <span data-ttu-id="8f99e-116">サポート対象外のプロパティを取得しようとすると null 値が返される場合があります。返されたメタデータの値を使う前に必ず、null のチェックを行ってください。</span><span class="sxs-lookup"><span data-stu-id="8f99e-116">Because properties that are unsupported may return a null value when retrieved, always check for null before using a returned metadata value.</span></span>

## <a name="geotag-helper"></a><span data-ttu-id="8f99e-117">位置情報タグ ヘルパー</span><span class="sxs-lookup"><span data-stu-id="8f99e-117">Geotag helper</span></span>

<span data-ttu-id="8f99e-118">GeotagHelper は、地理データを含んだ画像へのタグ付けを支援するユーティリティ クラスです。[**Windows.Devices.Geolocation**](https://msdn.microsoft.com/library/windows/apps/br225603) API を直接使って簡単にタグを設定することができます。メタデータの形式を手動で解析したり構築したりする必要はありません。</span><span class="sxs-lookup"><span data-stu-id="8f99e-118">GeotagHelper is a utility class that makes it easy to tag images with geographic data using the [**Windows.Devices.Geolocation**](https://msdn.microsoft.com/library/windows/apps/br225603) APIs directly, without having to manually parse or construct the metadata format.</span></span>

<span data-ttu-id="8f99e-119">地理位置情報 API の使用後など、タグの設定対象となる画像の位置情報を表す [**Geopoint**](https://msdn.microsoft.com/library/windows/apps/dn263675) オブジェクトが取得済みで、そのオブジェクトが既に存在する場合は、[**GeotagHelper.SetGeotagAsync**](https://msdn.microsoft.com/library/windows/apps/dn903685) に [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171) と **Geopoint** を渡して呼び出すことで位置情報タグ データを設定できます。</span><span class="sxs-lookup"><span data-stu-id="8f99e-119">If you already have a [**Geopoint**](https://msdn.microsoft.com/library/windows/apps/dn263675) object representing the location you want to tag in the image, either from a previous use of the geolocation APIs or some other source, you can set the geotag data by calling [**GeotagHelper.SetGeotagAsync**](https://msdn.microsoft.com/library/windows/apps/dn903685) and passing in a [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171) and the **Geopoint**.</span></span>

[!code-cs[SetGeoDataFromPoint](./code/ImagingWin10/cs/MainPage.xaml.cs#SnippetSetGeoDataFromPoint)]

<span data-ttu-id="8f99e-120">デバイスの現在位置を使って位置情報タグ データを設定するには、[**Geolocator**](https://msdn.microsoft.com/library/windows/apps/br225534) オブジェクトを新たに作成し、[**GeotagHelper.SetGeotagFromGeolocatorAsync**](https://msdn.microsoft.com/library/windows/apps/dn903686) に **Geolocator** とタグの設定対象となるファイルを渡して呼び出します。</span><span class="sxs-lookup"><span data-stu-id="8f99e-120">To set the geotag data using the device's current location, create a new [**Geolocator**](https://msdn.microsoft.com/library/windows/apps/br225534) object and call [**GeotagHelper.SetGeotagFromGeolocatorAsync**](https://msdn.microsoft.com/library/windows/apps/dn903686) passing in the **Geolocator** and the file to be tagged.</span></span>

[!code-cs[SetGeoDataFromGeolocator](./code/ImagingWin10/cs/MainPage.xaml.cs#SnippetSetGeoDataFromGeolocator)]

-   <span data-ttu-id="8f99e-121">[**SetGeotagFromGeolocatorAsync**](https://msdn.microsoft.com/library/windows/apps/dn903686) API を使うには、アプリ マニフェストに**位置情報**デバイス機能を追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8f99e-121">You must include the **location** device capability in your app manifest in order to use the [**SetGeotagFromGeolocatorAsync**](https://msdn.microsoft.com/library/windows/apps/dn903686) API.</span></span>

-   <span data-ttu-id="8f99e-122">[**SetGeotagFromGeolocatorAsync**](https://msdn.microsoft.com/library/windows/apps/dn903686) を呼び出す前に [**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/dn859152) を呼び出し、ユーザーの位置情報をアプリで使うための許可を得ておく必要があります。</span><span class="sxs-lookup"><span data-stu-id="8f99e-122">You must call [**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/dn859152) before calling [**SetGeotagFromGeolocatorAsync**](https://msdn.microsoft.com/library/windows/apps/dn903686) to ensure the user has granted your app permission to use their location.</span></span>

-   <span data-ttu-id="8f99e-123">地理位置情報 API について詳しくは、「[マップと位置情報](https://msdn.microsoft.com/library/windows/apps/mt219699)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="8f99e-123">For more information on the geolocation APIs, see [Maps and location](https://msdn.microsoft.com/library/windows/apps/mt219699).</span></span>

<span data-ttu-id="8f99e-124">位置情報タグで示された画像ファイルの地理的位置を表す GeoPoint を取得するには、[**GetGeotagAsync**](https://msdn.microsoft.com/library/windows/apps/dn903684) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="8f99e-124">To get a GeoPoint representing the geotagged location of an image file, call [**GetGeotagAsync**](https://msdn.microsoft.com/library/windows/apps/dn903684).</span></span>

[!code-cs[GetGeoData](./code/ImagingWin10/cs/MainPage.xaml.cs#SnippetGetGeoData)]

## <a name="decode-and-encode-image-metadata"></a><span data-ttu-id="8f99e-125">画像メタデータのデコードとエンコード</span><span class="sxs-lookup"><span data-stu-id="8f99e-125">Decode and encode image metadata</span></span>

<span data-ttu-id="8f99e-126">画像データを操作する最も高度な方法は、[**BitmapDecoder**](https://msdn.microsoft.com/library/windows/apps/br226176) または [BitmapEncoder](bitmapencoder-options-reference.md) を使って、プロパティの読み取りと書き込みをストリーム レベルで行うことです。</span><span class="sxs-lookup"><span data-stu-id="8f99e-126">The most advanced way of working with image data is to read and write the properties on the stream level using a [**BitmapDecoder**](https://msdn.microsoft.com/library/windows/apps/br226176) or a [BitmapEncoder](bitmapencoder-options-reference.md).</span></span> <span data-ttu-id="8f99e-127">これらの操作では、読み取りまたは書き込みの対象データを Windows プロパティを使って指定できるほか、要求するプロパティのパスを Windows Imaging Component (WIC) のメタデータ クエリ言語を使って指定することもできます。</span><span class="sxs-lookup"><span data-stu-id="8f99e-127">For these operations you can use Windows Properties to specify the data you are reading or writing, but you can also use the metadata query language provided by the Windows Imaging Component (WIC) to specify the path to a requested property.</span></span>

<span data-ttu-id="8f99e-128">この方法で画像のメタデータを読み取るには、ソース画像ファイル ストリームを使って作成された [**BitmapDecoder**](https://msdn.microsoft.com/library/windows/apps/br226176) が必要です。</span><span class="sxs-lookup"><span data-stu-id="8f99e-128">Reading image metadata using this technique requires you to have a [**BitmapDecoder**](https://msdn.microsoft.com/library/windows/apps/br226176) that was created with the source image file stream.</span></span> <span data-ttu-id="8f99e-129">この方法については、「[イメージング](imaging.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="8f99e-129">For information on how to do this, see [Imaging](imaging.md).</span></span>

<span data-ttu-id="8f99e-130">デコーダーを取得したら、文字列のリストを作成し、Windows プロパティの識別子文字列または WIC メタデータ クエリを使って、取得する各メタデータ プロパティの新しいエントリを追加します。</span><span class="sxs-lookup"><span data-stu-id="8f99e-130">Once you have the decoder, create a list of strings and add a new entry for each metadata property you want to retrieve, using either the Windows Property identifier string or a WIC metadata query.</span></span> <span data-ttu-id="8f99e-131">特定のプロパティを要求するには、デコーダーの [**BitmapProperties**](https://msdn.microsoft.com/library/windows/apps/br226248) メンバーの [**BitmapPropertiesView.GetPropertiesAsync**](https://msdn.microsoft.com/library/windows/apps/br226250) メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="8f99e-131">Call the [**BitmapPropertiesView.GetPropertiesAsync**](https://msdn.microsoft.com/library/windows/apps/br226250) method on the decoder's [**BitmapProperties**](https://msdn.microsoft.com/library/windows/apps/br226248) member to request the specified properties.</span></span> <span data-ttu-id="8f99e-132">要求したプロパティが、プロパティ名 (またはパス) とプロパティ値を含んだキー/値ペアのディクショナリとして返されます。</span><span class="sxs-lookup"><span data-stu-id="8f99e-132">The properties are returned in a dictionary of key/value pairs containing the property name or path and the property value.</span></span>

[!code-cs[ReadImageMetadata](./code/ImagingWin10/cs/MainPage.xaml.cs#SnippetReadImageMetadata)]

-   <span data-ttu-id="8f99e-133">WIC メタデータ クエリ言語とサポートされるプロパティについては、「[WIC ネイティブ イメージ形式メタデータのクエリ](https://msdn.microsoft.com/library/windows/desktop/ee719904)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="8f99e-133">For information on the WIC metadata query language and the properties supported, see [WIC image format native metadata queries](https://msdn.microsoft.com/library/windows/desktop/ee719904).</span></span>

-   <span data-ttu-id="8f99e-134">メタデータのプロパティの多くは、サポートされる画像の種類に限りがあります。</span><span class="sxs-lookup"><span data-stu-id="8f99e-134">Many metadata properties are only supported by a subset of image types.</span></span> <span data-ttu-id="8f99e-135">デコーダーに関連付けられている画像が、要求したプロパティのいずれかをサポートしていない場合、[**GetPropertiesAsync**](https://msdn.microsoft.com/library/windows/apps/br226250) はエラー コード 0x88982F41 で失敗します。画像がどのメタデータもサポートしていない場合は、0x88982F81 で失敗します。</span><span class="sxs-lookup"><span data-stu-id="8f99e-135">[**GetPropertiesAsync**](https://msdn.microsoft.com/library/windows/apps/br226250) will fail with the error code 0x88982F41 if one of the requested properties is not supported by the image associated with the decoder and 0x88982F81 if the image does not support metadata at all.</span></span> <span data-ttu-id="8f99e-136">この 2 つのエラー コードに関連付けられている定数はそれぞれ WINCODEC\_ERR\_PROPERTYNOTSUPPORTED と WINCODEC\_ERR\_UNSUPPORTEDOPERATION で、winerror.h ヘッダー ファイルに定義されています。</span><span class="sxs-lookup"><span data-stu-id="8f99e-136">The constants associated with these error codes are WINCODEC\_ERR\_PROPERTYNOTSUPPORTED and WINCODEC\_ERR\_UNSUPPORTEDOPERATION and are defined in the winerror.h header file.</span></span>
-   <span data-ttu-id="8f99e-137">特定のプロパティの値が画像に存在するかどうかはわからないので、**IDictionary.ContainsKey** を使って、結果にプロパティが存在するかどうかを確かめたうえでアクセスしてください。</span><span class="sxs-lookup"><span data-stu-id="8f99e-137">Because an image may or may not contain a value for a particular property, use the **IDictionary.ContainsKey** to verify that a property is present in the results before attempting to access it.</span></span>

<span data-ttu-id="8f99e-138">画像のメタデータをストリームに書き込むには、画像の出力ファイルに関連付けられている **BitmapEncoder** が必要です。</span><span class="sxs-lookup"><span data-stu-id="8f99e-138">Writing image metadata to the stream requires a **BitmapEncoder** associated with the image output file.</span></span>

<span data-ttu-id="8f99e-139">設定対象プロパティの値を保持する [**BitmapPropertySet**](https://msdn.microsoft.com/library/windows/apps/hh974338) オブジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="8f99e-139">Create a [**BitmapPropertySet**](https://msdn.microsoft.com/library/windows/apps/hh974338) object to contain the property values you want set.</span></span> <span data-ttu-id="8f99e-140">プロパティの値を表す [**BitmapTypedValue**](https://msdn.microsoft.com/library/windows/apps/hh700687) オブジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="8f99e-140">Create a [**BitmapTypedValue**](https://msdn.microsoft.com/library/windows/apps/hh700687) object to represent the property value.</span></span> <span data-ttu-id="8f99e-141">このオブジェクトでは、値の型を定義する [**PropertyType**](https://msdn.microsoft.com/library/windows/apps/br225871) 列挙型の値およびメンバーとして **object** を使います。</span><span class="sxs-lookup"><span data-stu-id="8f99e-141">This object uses an **object** as the value and member of the [**PropertyType**](https://msdn.microsoft.com/library/windows/apps/br225871) enumeration that defines the type of the value.</span></span> <span data-ttu-id="8f99e-142">**BitmapTypedValue** を **BitmapPropertySet** に追加したうえで、[**BitmapProperties.SetPropertiesAsync**](https://msdn.microsoft.com/library/windows/apps/br226252) を呼び出すと、エンコーダーがプロパティをストリームに書き込みます。</span><span class="sxs-lookup"><span data-stu-id="8f99e-142">Add the **BitmapTypedValue** to the **BitmapPropertySet** and then call [**BitmapProperties.SetPropertiesAsync**](https://msdn.microsoft.com/library/windows/apps/br226252) to cause the encoder to write the properties to the stream.</span></span>

[!code-cs[WriteImageMetadata](./code/ImagingWin10/cs/MainPage.xaml.cs#SnippetWriteImageMetadata)]

-   <span data-ttu-id="8f99e-143">画像ファイルの種類ごとのサポート対象プロパティについて詳しくは、「[Windows プロパティ](https://msdn.microsoft.com/library/windows/desktop/dd561977)」、「[フォト メタデータ ポリシー](https://msdn.microsoft.com/library/windows/desktop/ee872003)」、「[WIC ネイティブ イメージ形式メタデータのクエリ](https://msdn.microsoft.com/library/windows/desktop/ee719904)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="8f99e-143">For details on which properties are supported for which image file types, see [Windows Properties](https://msdn.microsoft.com/library/windows/desktop/dd561977), [Photo Metadata Policies](https://msdn.microsoft.com/library/windows/desktop/ee872003), and [WIC image format native metadata queries](https://msdn.microsoft.com/library/windows/desktop/ee719904).</span></span>

-   <span data-ttu-id="8f99e-144">エンコーダーに関連付けられている画像が、要求したプロパティのいずれかをサポートしていない場合、[**SetPropertiesAsync**](https://msdn.microsoft.com/library/windows/apps/br226252) はエラー コード 0x88982F41 で失敗します。</span><span class="sxs-lookup"><span data-stu-id="8f99e-144">[**SetPropertiesAsync**](https://msdn.microsoft.com/library/windows/apps/br226252) will fail with the error code 0x88982F41 if one of the requested properties is not supported by the image associated with the encoder.</span></span>

## <a name="related-topics"></a><span data-ttu-id="8f99e-145">関連トピック</span><span class="sxs-lookup"><span data-stu-id="8f99e-145">Related topics</span></span>

* [<span data-ttu-id="8f99e-146">イメージング</span><span class="sxs-lookup"><span data-stu-id="8f99e-146">Imaging</span></span>](imaging.md)
 

 




