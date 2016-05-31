---
author: drewbatgit
ms.assetid: 09BA9250-A476-4803-910E-52F0A51704B1
description: この記事では、IMediaEncodingProperties インターフェイスを使用して、カメラのプレビュー ストリームとキャプチャした写真/ビデオの解像度およびフレーム レートを設定する方法を説明します。
title: メディア エンコード プロパティの設定
---

# メディア エンコード プロパティの設定

\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]


この記事では、[**IMediaEncodingProperties**](https://msdn.microsoft.com/library/windows/apps/hh701011) インターフェイスを使用して、カメラのプレビュー ストリームとキャプチャした写真/ビデオの解像度およびフレーム レートを設定する方法を説明します。 プレビュー ストリームの縦横比をキャプチャしたメディアの縦横比と一致させる方法についても説明します。

カメラ プロファイルは、カメラのストリーム プロパティを検出および設定するための高度な方法ですが、すべてのデバイスではサポートされていません。 詳しくは、「[カメラ プロファイル](camera-profiles.md)」をご覧ください。

この記事のコードは、[CameraResolution サンプル](http://go.microsoft.com/fwlink/p/?LinkId=624252&clcid=0x409)を基にしています。 このサンプルをダウンロードし、該当するコンテキストで使用されているコードを確認することも、サンプルを独自のアプリの開始点として使用することもできます。

**注**  
この記事の内容は、写真やビデオの基本的なキャプチャ機能を実装するための手順を紹介した「[MediaCapture を使った写真とビデオのキャプチャ](capture-photos-and-video-with-mediacapture.md)」で取り上げた概念やコードに基づいています。 そちらの記事で基本的なメディア キャプチャのパターンを把握してから、高度なキャプチャ シナリオに進むことをお勧めします。 この記事で紹介しているコードは、MediaCapture のインスタンスが既に作成され、適切に初期化されていることを前提としています。

## メディア エンコード プロパティのヘルパー クラス

[
            **IMediaEncodingProperties**](https://msdn.microsoft.com/library/windows/apps/hh701011) インターフェイスの機能をラップする単純なヘルパー クラスを作成すると、特定の条件を満たす一連のエンコード プロパティを容易に選択できます。 特に、エンコード プロパティの機能の次のような動作に対して、このヘルパー クラスが便利です。

**警告**  
[
            **VideoDeviceController.GetAvailableMediaStreamProperties**](https://msdn.microsoft.com/library/windows/apps/br211994) メソッドは、[**MediaStreamType**](https://msdn.microsoft.com/library/windows/apps/br226640) 列挙値のメンバー (**VideoRecord**、**Photo** など) を受け取り、キャプチャした写真またはビデオの解像度などのストリーム エンコード設定を表す、[**ImageEncodingProperties**](https://msdn.microsoft.com/library/windows/apps/hh700993) オブジェクトまたは [**VideoEncodingProperties**](https://msdn.microsoft.com/library/windows/apps/hh701217) オブジェクトのリストを返します。 指定された **MediaStreamType** 値に関係なく、**GetAvailableMediaStreamProperties** を呼び出した結果には、**ImageEncodingProperties** または **VideoEncodingProperties** が含まれている可能性があります。 このため、いずれかのプロパティ値にアクセスする前に、常に各戻り値の型を確認し、適切な型にキャストする必要があります。

次に示すヘルパー クラスでは、型の確認と [**ImageEncodingProperties**](https://msdn.microsoft.com/library/windows/apps/hh700993) または [**VideoEncodingProperties**](https://msdn.microsoft.com/library/windows/apps/hh701217) へのキャストを処理しています。これにより、アプリのコードでは、2 つの型を区別する必要がなくなります。 これに加えて、ヘルパー クラスは、プロパティの縦横比、フレーム レート (ビデオ エンコード プロパティの場合のみ)、アプリの UI でエンコード プロパティをわかりやすく表示するためのフレンドリ名を使用できるように、プロパティを公開します。

ヘルパー クラスのソース ファイルには、[**Windows.Media.MediaProperties**](https://msdn.microsoft.com/library/windows/apps/hh701296) 名前空間を含める必要があります。

[!code-cs[MediaEncodingPropertiesUsing](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetMediaEncodingPropertiesUsing)]

[!code-cs[StreamPropertiesHelper](./code/BasicMediaCaptureWin10/cs/StreamPropertiesHelper.cs#SnippetStreamPropertiesHelper)]

## プレビュー ストリームとキャプチャ ストリームの独立性の判断

デバイスによっては、プレビュー ストリームとキャプチャ ストリームに同じハードウェア ピンが使用されることがあります。 このようなデバイスでは、一方のエンコード プロパティを設定すると、他方も設定されます。 キャプチャとプレビューに別々のハードウェア ピンが使用されるデバイスでは、ストリームごとのプロパティを個々に設定できます。 プレビュー ストリームとキャプチャ ストリームが独立しているかどうかを判断するには、次のコードを使用します。 このテストの結果に基づいて UI を調整し、ストリームの設定を個々に有効化または無効化する必要があります。

[!code-cs[CheckIfStreamsAreIdentical](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetCheckIfStreamsAreIdentical)]

## 利用可能なストリーム プロパティのリストの取得

キャプチャ デバイスについて利用可能なストリーム プロパティのリストを取得するには、アプリの [MediaCapture](capture-photos-and-video-with-mediacapture.md) オブジェクトの [**VideoDeviceController**](https://msdn.microsoft.com/library/windows/apps/br226825) を取得し、[**GetAvailableMediaStreamProperties**](https://msdn.microsoft.com/library/windows/apps/br211994) を呼び出して、いずれか 1 つの [**MediaStreamType**](https://msdn.microsoft.com/library/windows/apps/br226640) 値 (**VideoPreview**、**VideoRecord**、**Photo**) を渡します。 この例では、**GetAvailableMediaStreamProperties** から返されたそれぞれの [**IMediaEncodingProperties**](https://msdn.microsoft.com/library/windows/apps/hh701011) 値に対し、この記事で定義した **StreamPropertiesHelper** オブジェクトのリストを Linq 構文で作成しています。 この例では、まず Linq 拡張メソッドを使用して、返されたプロパティを解像度順のフレーム レート順に並べ替えます。

アプリに、解像度またはフレーム レートに関する特定の要件がある場合は、メディア エンコード プロパティのセットをプログラムで選択できます。 一般的なカメラ アプリでは、目的の設定をユーザーが選択できるように、利用可能なプロパティのリストが UI で公開されます。 **StreamPropertiesHelper** オブジェクトのリストにある各項目に対して、**ComboBoxItem** が作成されます。 コンテンツは、ヘルパー クラスから返されたフレンドリ名に設定されています。タグは、関連付けられているエンコード プロパティを後で取得できるように、ヘルパー クラス自体に設定されています。 次に、メソッドに渡された **ComboBox** に、各 **ComboBoxItem** が追加されます。

[!code-cs[PopulateStreamPropertiesUI](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetPopulateStreamPropertiesUI)]

## 目的のストリーム プロパティを設定する

目的のエンコード プロパティを使用するようにビデオ デバイスのコントローラーに指示するには、[**SetMediaStreamPropertiesAsync**](https://msdn.microsoft.com/library/windows/apps/hh700895) を呼び出します。このとき、写真、ビデオ、プレビューのうち、どのプロパティを設定するかを示す **MediaStreamType** 値を渡します。 この例では、**PopulateStreamPropertiesUI** ヘルパー メソッドによって設定されたいずれかの **ComboBox** オブジェクトからユーザーが項目を選択すると、要求されたエンコード プロパティが設定されます。

[!code-cs[PreviewSettingsChanged](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetPreviewSettingsChanged)]

[!code-cs[PhotoSettingsChanged](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetPhotoSettingsChanged)]

[!code-cs[VideoSettingsChanged](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetVideoSettingsChanged)]

## プレビューとキャプチャ ストリームの縦横比を一致させる

一般的なカメラ アプリでは、ユーザーがビデオや写真のキャプチャ解像度を選択するための UI を提供することも、プログラムによってプレビュー解像度を設定することもあります。 アプリの最適なプレビュー ストリーム解像度を選択するための方法はいくつかあります。

-   UI フレームワークで必要なプレビューのスケーリングを実行できるように、利用可能な最高のプレビュー解像度を選択します。

-   最終的にキャプチャされたメディアに最も近い表現がプレビューに表示されるように、キャプチャ解像度に最も近いプレビュー解像度を選択します。

-   必要以上のピクセルがプレビュー ストリーム パイプラインを通過しないように、[**CaptureElement**](https://msdn.microsoft.com/library/windows/apps/br209278) のサイズに最も近いプレビュー解像度を選択します。

**重要**  
デバイスによっては、カメラのプレビュー ストリームとキャプチャ ストリームで別々の縦横比を設定することも可能です。 この不一致によってフレームのトリミングが生じた場合、プレビューで表示されなかったコンテンツがキャプチャしたメディアに存在するという結果を招く可能性があり、これは否定的なユーザー エクスペリエンスにつながります。 プレビュー ストリームとキャプチャ ストリームには、微小な公差範囲内で同一の縦横比を使用することを強くお勧めします。 縦横比がほぼ一致していれば、キャプチャとプレビューにまったく異なる解像度を有効にしても問題ありません。


写真やビデオのキャプチャ ストリームをプレビュー ストリームの縦横比に一致させるために、この例では [**VideoDeviceController.GetMediaStreamProperties**](https://msdn.microsoft.com/library/windows/apps/br211995) を呼び出し、**VideoPreview** 列挙値を渡して、プレビュー ストリームの現在のストリーム プロパティを要求しています。 次に、プレビュー ストリームとまったく同じでなくても、近似値であれば、その縦横比を許容できるように、縦横比の微小な公差範囲を定義しています。 次に、プレビュー ストリームについて定義済みの公差範囲に縦横比が含まれるような **StreamPropertiesHelper** オブジェクトだけを選択できるように、Linq 拡張メソッドが使用されています。

[!code-cs[MatchPreviewAspectRatio](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetMatchPreviewAspectRatio)]

 

 






<!--HONumber=May16_HO2-->


