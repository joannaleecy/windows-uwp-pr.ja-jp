---
author: drewbatgit
ms.assetid: 42A06423-670F-4CCC-88B7-3DCEEDDEBA57
description: この記事では、カメラ プロファイルを使ってさまざまなビデオ キャプチャ デバイスの機能を検出および管理する方法について説明します。 これには、特定の解像度やフレーム レートをサポートするプロファイル、複数のカメラへの同時アクセスをサポートするプロファイル、HDR をサポートするプロファイルを選ぶなどのタスクが含まれます。
title: カメラ プロファイルを使用したカメラ機能の検出と選択
ms.author: drewbat
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 1af7453e8bfea973a67dc878438050accc01fb4c
ms.sourcegitcommit: b7e3d222e229cdbf04e837fcb94fb7d84a93de09
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5617966"
---
# <a name="discover-and-select-camera-capabilities-with-camera-profiles"></a>カメラ プロファイルを使用したカメラ機能の検出と選択



この記事では、カメラ プロファイルを使ってさまざまなビデオ キャプチャ デバイスの機能を検出および管理する方法について説明します。 これには、特定の解像度やフレーム レートをサポートするプロファイル、複数のカメラへの同時アクセスをサポートするプロファイル、HDR をサポートするプロファイルを選ぶなどのタスクが含まれます。

> [!NOTE] 
> この記事の内容は、写真やビデオの基本的なキャプチャ機能を実装するための手順を紹介した「[MediaCapture を使った基本的な写真、ビデオ、およびオーディオのキャプチャ](basic-photo-video-and-audio-capture-with-MediaCapture.md)」で取り上げた概念やコードに基づいています。 そちらの記事で基本的なメディア キャプチャのパターンを把握してから、高度なキャプチャ シナリオに進むことをお勧めします。 この記事で紹介しているコードは、MediaCapture のインスタンスが既に作成され、適切に初期化されていることを前提としています。

 

## <a name="about-camera-profiles"></a>カメラ プロファイルについて

カメラが搭載されているデバイスによって、キャプチャ解像度、ビデオ キャプチャのフレーム レート、HDR または可変フレーム レート キャプチャなど、サポートされている機能も異なります。 ユニバーサル Windows プラットフォーム (UWP) メディア キャプチャ フレームワークでは、この機能セットが [**MediaCaptureVideoProfileMediaDescription**](https://msdn.microsoft.com/library/windows/apps/dn926695) に格納されます。 [**MediaCaptureVideoProfile**](https://msdn.microsoft.com/library/windows/apps/dn926694) オブジェクトで表されるカメラ プロファイルには、メディア記述のコレクションが 3 つ含まれています。1 つは写真のキャプチャ用、1 つはビデオ キャプチャ用、もう 1 つはビデオ プレビュー用です。

[MediaCapture](capture-photos-and-video-with-mediacapture.md) オブジェクトを初期化する前に、現在のデバイスのキャプチャ デバイスを照会して、サポートされているプロファイルを確認することができます。 サポートされているプロファイルを選択すると、機能、プロファイルのメディア記述に含まれているすべての機能がすべてキャプチャ デバイスでサポートされることがわかります。 これにより、特定のデバイスでどのような組み合わせの機能がサポートされているか確認するために試行錯誤する必要がなくなります。

[!code-cs[BasicInitExample](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetBasicInitExample)]

この記事のコード例では、最小限の初期化が、さまざまな機能をサポートするカメラ プロファイルの検出に置き換わっています。検出されたプロファイルは、メディア キャプチャ デバイスの初期化に使用されます。

## <a name="find-a-video-device-that-supports-camera-profiles"></a>カメラ プロファイルをサポートするビデオ デバイスを検出する

サポートされているカメラ プロファイルを検索する前に、カメラ プロファイルの使用がサポートされるキャプチャ デバイスを検出する必要があります。 次の例で定義されている **GetVideoProfileSupportedDeviceIdAsync** ヘルパー メソッドでは、[**DeviceInformaion.FindAllAsync**](https://msdn.microsoft.com/library/windows/apps/br225432) メソッドを使って、すべての利用可能なビデオ キャプチャ デバイスの一覧を取得しています。 個々のデバイスについて静的メソッド [**IsVideoProfileSupported**](https://msdn.microsoft.com/library/windows/apps/dn926714) を呼び出し、ビデオ プロファイルがサポートされるかどうかを確認する処理が、一覧内のすべてのデバイスに対してループで実行されます。 また、各デバイスの [**EnclosureLocation.Panel**](https://msdn.microsoft.com/library/windows/apps/br229906) プロパティで、使用するカメラがデバイスの前面にあるか背面にあるかを指定することができます。

指定された面に、カメラ プロファイルをサポートするデバイスが見つかった場合は、デバイスの ID 文字列が含まれている [**Id**](https://msdn.microsoft.com/library/windows/apps/br225437) 値が返されます。

[!code-cs[GetVideoProfileSupportedDeviceIdAsync](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetGetVideoProfileSupportedDeviceIdAsync)]

**GetVideoProfileSupportedDeviceIdAsync** ヘルパー メソッドから返されたデバイス ID が null または空の文字列であれば、指定された面にはカメラ プロファイルをサポートするデバイスがありません。 この場合は、プロファイルを使用せずにメディア キャプチャ デバイスを初期化する必要があります。

[!code-cs[GetDeviceWithProfileSupport](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetGetDeviceWithProfileSupport)]

## <a name="select-a-profile-based-on-supported-resolution-and-frame-rate"></a>サポートされている解像度とフレーム レートに基づいてプロファイルを選択する

特定の解像度やフレーム レートを確保できるなど、特定の機能が含まれたプロファイルを選択するには、先ほど定義したヘルパー メソッドをまず呼び出して、カメラ プロファイルの使用をサポートするキャプチャ デバイスの ID を取得する必要があります。

選択されたデバイス ID を渡して、新しい [**MediaCaptureInitializationSettings**](https://msdn.microsoft.com/library/windows/apps/br226573) オブジェクトを作成します。 次に、静的メソッド [**MediaCapture.FindAllVideoProfiles**](https://msdn.microsoft.com/library/windows/apps/dn926708) を呼び出して、デバイスでサポートされているすべてのカメラ プロファイルの一覧を取得します。

この例では、**System.Linq** 名前空間に含まれている Linq クエリの手法を使用して、[**Width**](https://msdn.microsoft.com/library/windows/apps/dn926700)、[**Height**](https://msdn.microsoft.com/library/windows/apps/dn926697)、[**FrameRate**](https://msdn.microsoft.com/library/windows/apps/dn926696) の各プロパティが要求値に一致する [**SupportedRecordMediaDescription**](https://msdn.microsoft.com/library/windows/apps/dn926705) オブジェクトが含まれたプロパティを選択しています。 一致が見つかった場合、**MediaCaptureInitializationSettings** の [**VideoProfile**](https://msdn.microsoft.com/library/windows/apps/dn926679) と [**RecordMediaDescription**](https://msdn.microsoft.com/library/windows/apps/dn926678) が、Linq クエリから返された匿名型の値に設定されます。 一致が見つからなかった場合は、既定のプロパティが使われます。

[!code-cs[FindWVGA30FPSProfile](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetFindWVGA30FPSProfile)]

目的のカメラ プロファイルを **MediaCaptureInitializationSettings** に設定した後、メディア キャプチャ オブジェクトで [**InitializeAsync**](https://msdn.microsoft.com/library/windows/apps/br226598) を呼び出して、目的のプロファイルに構成します。

[!code-cs[InitCaptureWithProfile](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetInitCaptureWithProfile)]

## <a name="use-media-frame-source-groups-to-get-profiles"></a>メディア フレーム ソース グループを使用してプロファイルを取得する

Windows 10、バージョン 1803 以降では、[**MediaFrameSourceGroup**](https://docs.microsoft.com/uwp/api/windows.media.capture.frames.mediaframesourcegroup) クラスを使用して、特定の機能を備えたカメラ プロファイルを取得した後に、**MediaCapture** オブジェクトを初期化できます。 デバイス メーカーは、フレーム ソース グループを使用して、一連のセンサー機能やキャプチャ機能を 1 つの仮想デバイスとして表すことができます。 これにより、深度とカラー カメラを組み合わせるなどのコンピュテーショナル フォトグラフィー (計算写真学) のシナリオが可能になるだけでなく、単純なキャプチャのシナリオでカメラ プロファイルを選択するためにも使用できます。 **MediaFrameSourceGroup** の使用方法について詳しくは、「[MediaFrameReader を使ったメディア フレームの処理](process-media-frames-with-mediaframereader.md)」をご覧ください。

次のサンプル メソッドでは、**MediaFrameSourceGroup** オブジェクトを使用して、既知のビデオ プロファイルをサポートしているカメラ プロファイル (HDR や可変の写真シーケンスをサポートするカメラ プロファイルなど) を検索する方法を示しています。 まず、[**MediaFrameSourceGroup.FindAllAsync**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.Frames.MediaFrameSourceGroup.FindAllAsync) を呼び出して、現在のデバイス上で利用可能なすべてのメディア フレーム ソース グループの一覧を取得します。 ループ処理によって各ソース グループで [**MediaCapture.FindKnownVideoProfiles**](https://docs.microsoft.com/uwp/api/windows.media.capture.mediacapture.findknownvideoprofiles) を呼び出し、現在のソース グループについて、指定したプロファイル (この例では HDR/WCG 写真) をサポートしているすべてのビデオ プロファイルの一覧を取得します。 条件に適合するプロファイルが見つかった場合、新しい **MediaCaptureInitializationSettings** オブジェクトが作成され、**VideoProfile** が選択したプロファイルに設定されると共に、**VideoDeviceId** が現在のメディア フレーム ソース グループの **Id** プロパティに設定されます。 これにより、たとえば **KnownVideoProfile.HdrWithWcgVideo** をこのメソッドに渡すと、HDR ビデオをサポートしているメディア キャプチャ設定を取得できます。 また **KnownVideoProfile.VariablePhotoSequence** を渡すと、加変の写真シーケンスをサポートしている設定を取得できます。

 [!code-cs[FindKnownVideoProfile](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetFindKnownVideoProfile)]

## <a name="use-known-profiles-to-find-a-profile-that-supports-hdr-video-legacy-technique"></a>既知のプロファイルを使用して HDR ビデオをサポートするプロファイルを検出する (従来の手法)

> [!NOTE] 
> このセクションで説明されている API は、Windows 10、バージョン 1803 以降では非推奨です。 上記の「**メディア フレーム ソース グループを使用してプロファイルを取得する**」をご覧ください。

HDR をサポートするプロファイルの選択も、他のシナリオと同じように始まります。 キャプチャ デバイス ID を保持するために、 **MediaCaptureInitializationSettings**と文字列を作成します。 HDR ビデオがサポートされているかどうかを追跡するためのブール変数を追加します。

[!code-cs[GetHdrProfileSetup](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetGetHdrProfileSetup)]

上で定義した **GetVideoProfileSupportedDeviceIdAsync** ヘルパー メソッドを使って、カメラ プロファイルをサポートしているキャプチャ デバイスのデバイス ID を取得します。

[!code-cs[FindDeviceHDR](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetFindDeviceHDR)]

静的メソッド [**MediaCapture.FindKnownVideoProfiles**](https://msdn.microsoft.com/library/windows/apps/dn926710) により、指定の [**KnownVideoProfile**](https://msdn.microsoft.com/library/windows/apps/dn948843) 値で分類された指定のデバイスでサポートされるカメラ プロファイルが返されます。 このシナリオでは、ビデオ録画をサポートするカメラ プロファイルのみが返されるように、**VideoRecording** 値が指定されています。

返されたカメラ プロファイルの一覧をループ処理します。 各カメラ プロファイルで、プロファイル内の各 [**VideoProfileMediaDescription**](https://msdn.microsoft.com/library/windows/apps/dn926695) をループ処理して、[**IsHdrVideoSupported**](https://msdn.microsoft.com/library/windows/apps/dn926698) プロパティの値が true かどうかをチェックします。 適切なメディア記述が見つかったら、ループを抜けて、プロファイルと記述のオブジェクトを **MediaCaptureInitializationSettings** オブジェクトに割り当てます。

[!code-cs[FindHDRProfile](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetFindHDRProfile)]

## <a name="determine-if-a-device-supports-simultaneous-photo-and-video-capture"></a>写真とビデオの同時キャプチャがデバイスでサポートされているかどうかを確認する

多くのデバイスでは、写真とビデオの同時キャプチャがサポートされます。 キャプチャ デバイスでこの動作がサポートされているかどうかを確認するには、[**MediaCapture.FindAllVideoProfiles**](https://msdn.microsoft.com/library/windows/apps/dn926708) を呼び出して、デバイスでサポートされているすべてのカメラ プロファイルを取得します。 Linq クエリを使って、[**SupportedPhotoMediaDescription**](https://msdn.microsoft.com/library/windows/apps/dn926703) と [**SupportedRecordMediaDescription**](https://msdn.microsoft.com/library/windows/apps/dn926705) に 1 つ以上のエントリがある (プロファイルで同時キャプチャがサポートされていることを意味する) プロファイルを検出します。

[!code-cs[GetPhotoAndVideoSupport](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetGetPhotoAndVideoSupport)]

このクエリを調整して、同時ビデオ録画以外にも、特定の解像度やその他の機能をサポートするプロファイルを検出することもできます。 また、[**MediaCapture.FindKnownVideoProfiles**](https://msdn.microsoft.com/library/windows/apps/dn926710) を使って [**BalancedVideoAndPhoto**](https://msdn.microsoft.com/library/windows/apps/dn948843) 値を指定し、同時キャプチャをサポートするプロファイルを取得することもできますが、すべてのプロファイルを照会する方が完全な結果を得ることができます。

## <a name="related-topics"></a>関連トピック

* [カメラ](camera.md)
* [MediaCapture を使った基本的な写真、ビデオ、およびオーディオのキャプチャ](basic-photo-video-and-audio-capture-with-MediaCapture.md)
 

 




