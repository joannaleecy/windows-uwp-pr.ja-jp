---
author: drewbatgit
ms.assetid: 42A06423-670F-4CCC-88B7-3DCEEDDEBA57
description: "この記事では、カメラ プロファイルを使ってさまざまなビデオ キャプチャ デバイスの機能を検出および管理する方法について説明します。 これには、特定の解像度やフレーム レートをサポートするプロファイル、複数のカメラへの同時アクセスをサポートするプロファイル、HDR をサポートするプロファイルを選ぶなどのタスクが含まれます。"
title: "カメラ プロファイルを使用したカメラ機能の検出と選択"
translationtype: Human Translation
ms.sourcegitcommit: 625cf715a88837cb920433fa34e47a1e1828a4c8
ms.openlocfilehash: 09cb41f834de52d541addee4e44715c52f5e99dc

---

# カメラ プロファイルを使用したカメラ機能の検出と選択

\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]


この記事では、カメラ プロファイルを使ってさまざまなビデオ キャプチャ デバイスの機能を検出および管理する方法について説明します。 これには、特定の解像度やフレーム レートをサポートするプロファイル、複数のカメラへの同時アクセスをサポートするプロファイル、HDR をサポートするプロファイルを選ぶなどのタスクが含まれます。

> [!NOTE] 
> この記事の内容は、写真やビデオの基本的なキャプチャ機能を実装するための手順を紹介した「[MediaCapture を使った基本的な写真、ビデオ、およびオーディオのキャプチャ](basic-photo-video-and-audio-capture-with-MediaCapture.md)」で取り上げた概念やコードに基づいています。 そちらの記事で基本的なメディア キャプチャのパターンを把握してから、高度なキャプチャ シナリオに進むことをお勧めします。 この記事で紹介しているコードは、MediaCapture のインスタンスが既に作成され、適切に初期化されていることを前提としています。

 

## カメラ プロファイルについて

カメラが搭載されているデバイスによって、キャプチャ解像度、ビデオ キャプチャのフレーム レート、HDR または可変フレーム レート キャプチャなど、サポートされている機能も異なります。 ユニバーサル Windows プラットフォーム (UWP) メディア キャプチャ フレームワークでは、この機能セットが [**MediaCaptureVideoProfileMediaDescription**](https://msdn.microsoft.com/library/windows/apps/dn926695) に格納されます。 [**MediaCaptureVideoProfile**](https://msdn.microsoft.com/library/windows/apps/dn926694) オブジェクトで表されるカメラ プロファイルには、メディア記述のコレクションが 3 つ含まれています。1 つは写真のキャプチャ用、1 つはビデオ キャプチャ用、もう 1 つはビデオ プレビュー用です。

[MediaCapture](capture-photos-and-video-with-mediacapture.md) オブジェクトを初期化する前に、現在のデバイスのキャプチャ デバイスを照会して、サポートされているプロファイルを確認することができます。 サポートされているプロファイルを選択すると、機能、プロファイルのメディア記述に含まれているすべての機能がすべてキャプチャ デバイスでサポートされることがわかります。 これにより、特定のデバイスでどのような組み合わせの機能がサポートされているか確認するために試行錯誤する必要がなくなります。

[!code-cs[BasicInitExample](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetBasicInitExample)]

この記事のコード例では、最小限の初期化が、さまざまな機能をサポートするカメラ プロファイルの検出に置き換わっています。検出されたプロファイルは、メディア キャプチャ デバイスの初期化に使用されます。

## カメラ プロファイルをサポートするビデオ デバイスを検出する

サポートされているカメラ プロファイルを検索する前に、カメラ プロファイルの使用がサポートされるキャプチャ デバイスを検出する必要があります。 次の例で定義されている **GetVideoProfileSupportedDeviceIdAsync** ヘルパー メソッドでは、[**DeviceInformaion.FindAllAsync**](https://msdn.microsoft.com/library/windows/apps/br225432) メソッドを使って、すべての利用可能なビデオ キャプチャ デバイスの一覧を取得しています。 個々のデバイスについて静的メソッド [**IsVideoProfileSupported**](https://msdn.microsoft.com/library/windows/apps/dn926714) を呼び出し、ビデオ プロファイルがサポートされるかどうかを確認する処理が、一覧内のすべてのデバイスに対してループで実行されます。 また、各デバイスの [**EnclosureLocation.Panel**](https://msdn.microsoft.com/library/windows/apps/br229906) プロパティで、使用するカメラがデバイスの前面にあるか背面にあるかを指定することができます。

指定された面に、カメラ プロファイルをサポートするデバイスが見つかった場合は、デバイスの ID 文字列が含まれている [**Id**](https://msdn.microsoft.com/library/windows/apps/br225437) 値が返されます。

[!code-cs[GetVideoProfileSupportedDeviceIdAsync](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetGetVideoProfileSupportedDeviceIdAsync)]

**GetVideoProfileSupportedDeviceIdAsync** ヘルパー メソッドから返されたデバイス ID が null または空の文字列であれば、指定された面にはカメラ プロファイルをサポートするデバイスがありません。 この場合は、プロファイルを使用せずにメディア キャプチャ デバイスを初期化する必要があります。

[!code-cs[GetDeviceWithProfileSupport](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetGetDeviceWithProfileSupport)]

## サポートされている解像度とフレーム レートに基づいてプロファイルを選択する

特定の解像度やフレーム レートを確保できるなど、特定の機能が含まれたプロファイルを選択するには、先ほど定義したヘルパー メソッドをまず呼び出して、カメラ プロファイルの使用をサポートするキャプチャ デバイスの ID を取得する必要があります。

選択されたデバイス ID を渡して、新しい [**MediaCaptureInitializationSettings**](https://msdn.microsoft.com/library/windows/apps/br226573) オブジェクトを作成します。 次に、静的メソッド [**MediaCapture.FindAllVideoProfiles**](https://msdn.microsoft.com/library/windows/apps/dn926708) を呼び出して、デバイスでサポートされているすべてのカメラ プロファイルの一覧を取得します。

この例では、**System.Linq** 名前空間に含まれている Linq クエリの手法を使用して、[**Width**](https://msdn.microsoft.com/library/windows/apps/dn926700)、[**Height**](https://msdn.microsoft.com/library/windows/apps/dn926697)、[**FrameRate**](https://msdn.microsoft.com/library/windows/apps/dn926696) の各プロパティが要求値に一致する [**SupportedRecordMediaDescription**](https://msdn.microsoft.com/library/windows/apps/dn926705) オブジェクトが含まれたプロパティを選択しています。 一致が見つかった場合、**MediaCaptureInitializationSettings** の [**VideoProfile**](https://msdn.microsoft.com/library/windows/apps/dn926679) と [**RecordMediaDescription**](https://msdn.microsoft.com/library/windows/apps/dn926678) が、Linq クエリから返された匿名型の値に設定されます。 一致が見つからなかった場合は、既定のプロパティが使われます。

[!code-cs[FindWVGA30FPSProfile](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetFindWVGA30FPSProfile)]

目的のカメラ プロファイルを **MediaCaptureInitializationSettings** に設定した後、メディア キャプチャ オブジェクトで [**InitializeAsync**](https://msdn.microsoft.com/library/windows/apps/br226598) を呼び出して、目的のプロファイルに構成します。

[!code-cs[InitCaptureWithProfile](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetInitCaptureWithProfile)]

## 同時実行をサポートするプロファイルを選択する

カメラ プロファイルを使うと、デバイスで複数カメラからのビデオ キャプチャが同時にサポートされるかどうかを確認できます。 このシナリオでは、前面カメラ用と背面カメラ用に、2 セットのキャプチャ オブジェクトを作成する必要があります。 各カメラについて、**MediaCapture** と **MediaCaptureInitializationSettings** を作成し、キャプチャ デバイス ID を保持するための文字列を作成します。 また、同時実行がサポートされているかどうかを追跡するためのブール変数を追加します。

[!code-cs[ConcurrencySetup](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetConcurrencySetup)]

静的メソッド [**MediaCapture.FindConcurrentProfiles**](https://msdn.microsoft.com/library/windows/apps/dn926709) により、指定された (同時実行もサポート可能な) キャプチャ デバイスでサポートされているカメラ プロファイルの一覧が返されます。 Linq クエリを使って、同時実行をサポートし、前面カメラ用と背面カメラの両方でサポートされているプロファイルを検出します。 これらの要件を満たしているプロファイルが見つかった場合は、このプロファイルを各 **MediaCaptureInitializationSettings** オブジェクトに設定し、同時実行を追跡するブール変数を true に設定します。

[!code-cs[FindConcurrencyDevices](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetFindConcurrencyDevices)]

アプリのシナリオのプライマリ カメラ用に **MediaCapture.InitializeAsync** を呼び出します。 同時実行がサポートされている場合は、2 台目のカメラも初期化します。

[!code-cs[InitConcurrentMediaCaptures](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetInitConcurrentMediaCaptures)]

## 既知のプロファイルを使用して HDR ビデオをサポートするプロファイルを検出する

HDR をサポートするプロファイルの選択も、他のシナリオと同じように始まります。 **MediaCaptureInitializationSettings** を作成し、キャプチャ デバイス ID を保持する文字列を作成します。 HDR ビデオがサポートされているかどうかを追跡するためのブール変数を追加します。

[!code-cs[GetHdrProfileSetup](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetGetHdrProfileSetup)]

上で定義した **GetVideoProfileSupportedDeviceIdAsync** ヘルパー メソッドを使って、カメラ プロファイルをサポートしているキャプチャ デバイスのデバイス ID を取得します。

[!code-cs[FindDeviceHDR](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetFindDeviceHDR)]

静的メソッド [**MediaCapture.FindKnownVideoProfiles**](https://msdn.microsoft.com/library/windows/apps/dn926710) により、指定の [**KnownVideoProfile**](https://msdn.microsoft.com/library/windows/apps/dn948843) 値で分類された指定のデバイスでサポートされるカメラ プロファイルが返されます。 このシナリオでは、ビデオ録画をサポートするカメラ プロファイルのみが返されるように、**VideoRecording** 値が指定されています。

返されたカメラ プロファイルの一覧をループ処理します。 各カメラ プロファイルで、プロファイル内の各 [**VideoProfileMediaDescription**](https://msdn.microsoft.com/library/windows/apps/dn926695) をループ処理して、[**IsHdrVideoSupported**](https://msdn.microsoft.com/library/windows/apps/dn926698) プロパティの値が true かどうかをチェックします。 適切なメディア記述が見つかったら、ループを抜けて、プロファイルと記述のオブジェクトを **MediaCaptureInitializationSettings** オブジェクトに割り当てます。

[!code-cs[FindHDRProfile](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetFindHDRProfile)]

## 写真とビデオの同時キャプチャがデバイスでサポートされているかどうかを確認する

多くのデバイスでは、写真とビデオの同時キャプチャがサポートされます。 キャプチャ デバイスでこの動作がサポートされているかどうかを確認するには、[**MediaCapture.FindAllVideoProfiles**](https://msdn.microsoft.com/library/windows/apps/dn926708) を呼び出して、デバイスでサポートされているすべてのカメラ プロファイルを取得します。 Linq クエリを使って、[**SupportedPhotoMediaDescription**](https://msdn.microsoft.com/library/windows/apps/dn926703) と [**SupportedRecordMediaDescription**](https://msdn.microsoft.com/library/windows/apps/dn926705) に 1 つ以上のエントリがある (プロファイルで同時キャプチャがサポートされていることを意味する) プロファイルを検出します。

[!code-cs[GetPhotoAndVideoSupport](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetGetPhotoAndVideoSupport)]

このクエリを調整して、同時ビデオ録画以外にも、特定の解像度やその他の機能をサポートするプロファイルを検出することもできます。 また、[**MediaCapture.FindKnownVideoProfiles**](https://msdn.microsoft.com/library/windows/apps/dn926710) を使って [**BalancedVideoAndPhoto**](https://msdn.microsoft.com/library/windows/apps/dn948843) 値を指定し、同時キャプチャをサポートするプロファイルを取得することもできますが、すべてのプロファイルを照会する方が完全な結果を得ることができます。

## 関連トピック

* [カメラ](camera.md)
* [MediaCapture を使った基本的な写真、ビデオ、およびオーディオのキャプチャ](basic-photo-video-and-audio-capture-with-MediaCapture.md)
 

 







<!--HONumber=Aug16_HO3-->


