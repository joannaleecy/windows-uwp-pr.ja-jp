---
author: drewbatgit
ms.assetid: C4DB495D-1F91-40EF-A55C-5CABBF3269A2
description: Windows.Media.Editing 名前空間の API を使うと、オーディオやビデオのソース ファイルからメディア コンポジションを作成するアプリを簡単に開発できます。
title: メディアのコンポジションと編集
ms.author: drewbat
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: f32d63bf03a469d8282262c358153140587d9033
ms.sourcegitcommit: e814a13978f33654d8e995584f4b047cb53e0aef
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/05/2018
ms.locfileid: "6025764"
---
# <a name="media-compositions-and-editing"></a>メディアのコンポジションと編集



この記事では、[**Windows.Media.Editing**](https://msdn.microsoft.com/library/windows/apps/dn640565) 名前空間の API を使って、オーディオとビデオのソース ファイルからメディア コンポジションを作成するアプリを開発する方法について説明します。 このフレームワークには、複数のビデオ クリップをまとめて追加したり、ビデオや画像のオーバーレイを追加したり、バックグラウンド オーディオを追加したり、オーディオとビデオの効果を追加したりする作業をプログラムから実行できる機能が備わっています。 作成したメディア コンポジションは、フラットなメディア ファイルにレンダリングして再生したり共有したりできるほか、コンポジションをディスクにシリアル化したりディスクから逆シリアル化したりすることもできるので、過去に作成されたコンポジションを読み込んで変更を加えるような機能をユーザーに提供することができます。 その機能はいずれも、使いやすい Windows ランタイムのインターフェイスとして用意されているため、低レベルの [Microsoft メディア ファンデーション](https://msdn.microsoft.com/library/windows/desktop/ms694197) API と比べて、これらの作業を実行するために必要なコードの量や複雑さは大幅に軽減されます。

## <a name="create-a-new-media-composition"></a>新しいメディア コンポジションを作成する

[**MediaComposition**](https://msdn.microsoft.com/library/windows/apps/dn652646) クラスは、コンポジションの構成要素となるすべてのメディア クリップのコンテナーで、最終的なコンポジションのレンダリングや、ディスクからの読み込みとディスクへの保存、UI に表示するプレビュー ストリームの提供などの機能を担います。 **MediaComposition** をアプリで使うには、[**Windows.Media.Editing**](https://msdn.microsoft.com/library/windows/apps/dn640565) 名前空間に加え、関連する必要な API を含んだ [**Windows.Media.Core**](https://msdn.microsoft.com/library/windows/apps/dn278962) 名前空間を追加する必要があります。

[!code-cs[Namespace1](./code/MediaEditing/cs/MainPage.xaml.cs#SnippetNamespace1)]


**MediaComposition** オブジェクトには、コードのいたるところからアクセスすることになるため、それを格納するためのメンバー変数を宣言するのが一般的です。

[!code-cs[DeclareMediaComposition](./code/MediaEditing/cs/MainPage.xaml.cs#SnippetDeclareMediaComposition)]

**MediaComposition** のコンストラクターに引数はありません。

[!code-cs[MediaCompositionConstructor](./code/MediaEditing/cs/MainPage.xaml.cs#SnippetMediaCompositionConstructor)]

## <a name="add-media-clips-to-a-composition"></a>コンポジションにメディア クリップを追加する

メディア コンポジションは通常、ビデオ クリップを含んでいます。 ビデオ ファイルをユーザーに選択してもらうには、[**FileOpenPicker**](https://msdn.microsoft.com/library/windows/apps/hh738369) を使います。 ファイルが選択されたら、[**MediaClip.CreateFromFileAsync**](https://msdn.microsoft.com/library/windows/apps/dn652607) を呼び出し、そのビデオ クリップを格納するための新しい [**MediaClip**](https://msdn.microsoft.com/library/windows/apps/dn652596) オブジェクトを作成します。 そのクリップを **MediaComposition** オブジェクトの [**Clips**](https://msdn.microsoft.com/library/windows/apps/dn652648) リストに追加します。

[!code-cs[PickFileAndAddClip](./code/MediaEditing/cs/MainPage.xaml.cs#SnippetPickFileAndAddClip)]

-   **MediaComposition** には、[**Clips**](https://msdn.microsoft.com/library/windows/apps/dn652648) リストと同じ順序でメディア クリップが出現します。

-   **MediaClip** をコンポジションに追加できるのは 1 回だけです。 既にコンポジションで使われている **MediaClip** を追加しようとすると、エラーが発生します。 コンポジションの中でビデオ クリップを複数回にわたって再利用するには、[**Clone**](https://msdn.microsoft.com/library/windows/apps/dn652599) を呼び出して新しい **MediaClip** オブジェクトを作成し、それをコンポジションに追加してください。

-   ユニバーサル Windows アプリには、ファイル システム全体にアクセスする権限がありません。 [**StorageApplicationPermissions**](https://msdn.microsoft.com/library/windows/apps/br207456) クラスの [**FutureAccessList**](https://msdn.microsoft.com/library/windows/apps/br207457) プロパティを使うと、ユーザーによって選択されたファイルの記録をアプリで保存し、ファイルにアクセスするための権限を維持することができます。 **FutureAccessList** の最大エントリ数は 1,000 件です。リストがあふれないようアプリ側で管理する必要があります。 過去に作成されたコンポジションの読み込みと変更をサポートする場合は、この点が特に重要となります。

-   **MediaComposition** は、MP4 形式のビデオ クリップをサポートしています。

-   ビデオ ファイルに複数のオーディオ トラックが埋め込まれている場合、コンポジションに使うオーディオ トラックを [**SelectedEmbeddedAudioTrackIndex**](https://msdn.microsoft.com/library/windows/apps/dn652627) プロパティで選ぶことができます。

-   フレーム全体を単色で塗りつぶした **MediaClip** を作成するには、単一色とクリップの再生時間を指定して [**CreateFromColor**](https://msdn.microsoft.com/library/windows/apps/dn652605) を呼び出します。

-   **MediaClip** を画像ファイルから作成するには、画像ファイルとクリップの再生時間を指定して [**CreateFromImageFileAsync**](https://msdn.microsoft.com/library/windows/apps/dn652610) を呼び出します。

-   **MediaClip** を [**IDirect3DSurface**](https://msdn.microsoft.com/library/windows/apps/dn965505) から作成するには、サーフェスとクリップの再生時間を指定して [**CreateFromSurface**](https://msdn.microsoft.com/library/dn764774) を呼び出します。

## <a name="preview-the-composition-in-a-mediaelement"></a>コンポジションを MediaElement でプレビューする

メディア コンポジションをユーザーが表示できるようにするには、UI を定義する XAML ファイルに [**MediaPlayerElement**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.MediaPlayerElement) を追加します。

[!code-xml[MediaElement](./code/MediaEditing/cs/MainPage.xaml#SnippetMediaElement)]

[**MediaStreamSource**](https://msdn.microsoft.com/library/windows/apps/dn282716) 型のメンバー変数を宣言します。


[!code-cs[DeclareMediaStreamSource](./code/MediaEditing/cs/MainPage.xaml.cs#SnippetDeclareMediaStreamSource)]

**MediaComposition** オブジェクトの [**GeneratePreviewMediaStreamSource**](https://msdn.microsoft.com/library/windows/apps/dn652674) メソッドを呼び出して、コンポジションの **MediaStreamSource** を作成します。 ファクトリ メソッド [**CreateFromMediaStreamSource**](https://msdn.microsoft.com/library/windows/apps/dn930907) を呼び出して、[**MediaSource**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Core.MediaSource) オブジェクトを作成し、それを **MediaPlayerElement** の [**Source**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.MediaPlayerElement.Source) プロパティに割り当てます。 これでコンポジションを UI に表示することができます。


[!code-cs[UpdateMediaElementSource](./code/MediaEditing/cs/MainPage.xaml.cs#SnippetUpdateMediaElementSource)]

-   [**GeneratePreviewMediaStreamSource**](https://msdn.microsoft.com/library/windows/apps/dn652674) は、**MediaComposition** にメディア クリップが少なくとも 1 つは存在している状態で呼び出す必要があります。まったく存在しない場合、返されるオブジェクトは null になります。

-   コンポジションの変更を反映するために **MediaElement** のタイムラインが自動的に更新されることはありません。 コンポジションに一連の変更を行って UI の更新が必要になるたびに、**GeneratePreviewMediaStreamSource** を呼び出し、**MediaPlayerElement**、**Source** プロパティを設定することをお勧めします。

ユーザーがページから離れたときは、**MediaPlayerElement** の [**Source**](https://msdn.microsoft.com/library/windows/apps/br227419) プロパティと **MediaStreamSource** オブジェクトを null に設定して、関連付けられているリソースを解放することをお勧めします。

[!code-cs[OnNavigatedFrom](./code/MediaEditing/cs/MainPage.xaml.cs#SnippetOnNavigatedFrom)]

## <a name="render-the-composition-to-a-video-file"></a>コンポジションをビデオ ファイルにレンダリングする

メディア コンポジションをフラット ビデオ ファイルにレンダリングして他のデバイスで共有したり表示したりするには、[**Windows.Media.Transcoding**](https://msdn.microsoft.com/library/windows/apps/br207105) 名前空間の API が必要となります。 また、非同期操作の進行状況に応じて UI を更新するには、[**Windows.UI.Core**](https://msdn.microsoft.com/library/windows/apps/br208383) 名前空間の API が必要となります。

[!code-cs[Namespace2](./code/MediaEditing/cs/MainPage.xaml.cs#SnippetNamespace2)]

[**FileSavePicker**](https://msdn.microsoft.com/library/windows/apps/br207871) でユーザーが出力ファイルを選べるようにしたら、**MediaComposition** オブジェクトの [**RenderToFileAsync**](https://msdn.microsoft.com/library/windows/apps/dn652690) を呼び出し、選択されたファイルにコンポジションをレンダリングします。 以下のコード例の残りの部分は、[**AsyncOperationWithProgress**](https://msdn.microsoft.com/library/windows/desktop/br205807) の処理パターンを踏襲しているだけです。

[!code-cs[RenderCompositionToFile](./code/MediaEditing/cs/MainPage.xaml.cs#SnippetRenderCompositionToFile)]

-   トランスコード処理の速度を優先させるか、隣接するメディア クリップのトリミング精度を優先させるかは、[**MediaTrimmingPreference**](https://msdn.microsoft.com/library/windows/apps/dn640561) で設定することができます。 **Fast** を選んだ場合は、トランスコード処理の速度が上がってトリミングの精度が低下します。一方、**Precise** を選んだ場合は、トランスコード処理の速度が下がってトリミングの精度が向上します。

## <a name="trim-a-video-clip"></a>ビデオ クリップをトリミングする

コンポジションにおけるビデオ クリップの再生時間をトリミングするには、[**MediaClip**](https://msdn.microsoft.com/library/windows/apps/dn652596) オブジェクトの [**TrimTimeFromStart**](https://msdn.microsoft.com/library/windows/apps/dn652637) プロパティまたは [**TrimTimeFromEnd**](https://msdn.microsoft.com/library/windows/apps/dn652634) プロパティ、あるいはその両方を設定します。

[!code-cs[TrimClipBeforeCurrentPosition](./code/MediaEditing/cs/MainPage.xaml.cs#SnippetTrimClipBeforeCurrentPosition)]

-   任意の UI を使って、トリミングの開始と終了の値をユーザーに指定してもらうことができます。 上の例では、**MediaPlayerElement** に関連付けられた [**MediaPlaybackSession**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlaybackSession) の [**Position**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlaybackSession.Position) プロパティを使い、[**StartTimeInComposition**](https://msdn.microsoft.com/library/windows/apps/dn652629) と [**EndTimeInComposition**](https://msdn.microsoft.com/library/windows/apps/dn652618) を確認することによって、コンポジションの現在位置で再生されている **MediaClip** を調べています。 次に、**Position** プロパティと **StartTimeInComposition** プロパティをもう一度使って、クリップの先頭からトリミングする時間を計算します。 **FirstOrDefault** メソッドは、**System.Linq** 名前空間の拡張メソッドです。リストから項目を選択するコードが、このメソッドによって単純化されます。
-   クリッピングが一切適用されていない状態のメディア クリップの再生時間は、**MediaClip** オブジェクトの [**OriginalDuration**](https://msdn.microsoft.com/library/windows/apps/dn652625) プロパティで確認できます。
-   トリミングを適用した後のメディア クリップの再生時間は、[**TrimmedDuration**](https://msdn.microsoft.com/library/windows/apps/dn652631) プロパティを使って確認できます。
-   クリップの元の再生時間を超えるトリミング値を指定してもエラーはスローされません。 ただし、コンポジションに含まれているクリップが 1 つだけであるときに、大きなトリミング値を指定したことによって長さがゼロにまでトリミングされた場合、それ以降の [**GeneratePreviewMediaStreamSource**](https://msdn.microsoft.com/library/windows/apps/dn652674) の呼び出しからは、一見コンポジションにクリップが存在しないかのように null が返されます。

## <a name="add-a-background-audio-track-to-a-composition"></a>コンポジションにバックグラウンド オーディオ トラックを追加する

コンポジションにバックグラウンド トラックを追加するには、オーディオ ファイルを読み込んだ後、ファクトリ メソッド [**BackgroundAudioTrack.CreateFromFileAsync**](https://msdn.microsoft.com/library/windows/apps/dn652561) を呼び出して [**BackgroundAudioTrack**](https://msdn.microsoft.com/library/windows/apps/dn652544) オブジェクトを作成します。 次に、**BackgroundAudioTrack** をコンポジションの [**BackgroundAudioTracks**](https://msdn.microsoft.com/library/windows/apps/dn652647) プロパティに追加します。

[!code-cs[AddBackgroundAudioTrack](./code/MediaEditing/cs/MainPage.xaml.cs#SnippetAddBackgroundAudioTrack)]

-   **MediaComposition** では、MP3、WAV、FLAC の各形式のバックグラウンド オーディオ トラックがサポートされます。

-   バックグラウンド オーディオ トラック。

-   ビデオ ファイルの場合と同様、[**StorageApplicationPermissions**](https://msdn.microsoft.com/library/windows/apps/br207456) クラスを使ってコンポジション内のファイルにアクセスする権限を維持することをお勧めします。

-   **MediaClip** の場合と同様、**BackgroundAudioTrack** をコンポジションに追加できるのは 1 回だけです。 既にコンポジションで使われている **BackgroundAudioTrack** を追加しようとすると、エラーが発生します。 コンポジションの中でオーディオ トラックを複数回にわたって再利用するには、[**Clone**](https://msdn.microsoft.com/library/windows/apps/dn652599) を呼び出して新しい **MediaClip** オブジェクトを作成し、それをコンポジションに追加してください。

-   既定では、コンポジションの開始時にバックグラウンド オーディオ トラックが再生されます。 複数のバックグラウンド トラックが存在する場合、コンポジションの開始時にすべてのトラックの再生が開始されます。 バックグラウンド オーディオ トラックの再生を他のタイミングで開始するには、[**Delay**](https://msdn.microsoft.com/library/windows/apps/dn652563) プロパティに、目的のタイム オフセットを設定してください。

## <a name="add-an-overlay-to-a-composition"></a>コンポジションにオーバーレイを追加する

オーバーレイを使うと、コンポジションの複数のビデオ レイヤーを重ね合わせることができます。 コンポジションには、複数のオーバーレイ レイヤーを含めることができ、それぞれのオーバーレイ レイヤーには複数のオーバーレイを追加することができます。 [**MediaOverlay**](https://msdn.microsoft.com/library/windows/apps/dn764793) オブジェクトは、そのコンストラクターに **MediaClip** を渡すことによって作成します。 オーバーレイの位置と不透明度を設定したら、新しい [**MediaOverlayLayer**](https://msdn.microsoft.com/library/windows/apps/dn764795) を作成し、その [**Overlays**](https://msdn.microsoft.com/library/windows/desktop/dn280411) リストに **MediaOverlay** を追加します。 最後に、その **MediaOverlayLayer** をコンポジションの [**OverlayLayers**](https://msdn.microsoft.com/library/windows/apps/dn764791) リストに追加します。

[!code-cs[AddOverlay](./code/MediaEditing/cs/MainPage.xaml.cs#SnippetAddOverlay)]

-   レイヤーにおけるオーバーレイの Z オーダーは、そのオーバーレイを含んでいるレイヤーの **Overlays** リストにおける順序に基づいて決まります。 リストにおけるインデックスが大きいほど、手前にレンダリングされます。 コンポジションにおけるオーバーレイ レイヤーにも同じことが当てはまります。 コンポジションの **OverlayLayers** リストにおけるインデックスが大きいレイヤーほど、手前にレンダリングされます。

-   オーバーレイは、順に再生されるのではなく上に積み重ねられるため、既定ではコンポジションの開始と共にすべてのオーバーレイが再生されます。 オーバーレイの再生を他のタイミングで開始するには、[**Delay**](https://msdn.microsoft.com/library/windows/apps/dn764810) プロパティに、目的のタイム オフセットを設定してください。

## <a name="add-effects-to-a-media-clip"></a>メディア クリップに効果を追加する

コンポジションに含まれる各 **MediaClip** には、オーディオ効果とビデオ効果のリストがあって、そのリストに複数の効果を追加することができます。 これらの効果にはそれぞれ [**IAudioEffectDefinition**](https://msdn.microsoft.com/library/windows/apps/dn608044) または [**IVideoEffectDefinition**](https://msdn.microsoft.com/library/windows/apps/dn608047) が実装されている必要があります。 次の例は、現在の **MediaPlayerElement** 位置を使って表示されている **MediaClip** を選び、[**VideoStabilizationEffectDefinition**](https://msdn.microsoft.com/library/windows/apps/dn926762) の新しいインスタンスを作成して、メディア クリップの [**VideoEffectDefinitions**](https://msdn.microsoft.com/library/windows/apps/dn652643) リストに追加しています。

[!code-cs[AddVideoEffect](./code/MediaEditing/cs/MainPage.xaml.cs#SnippetAddVideoEffect)]

## <a name="save-a-composition-to-a-file"></a>コンポジションをファイルに保存する

メディア コンポジションは、後で変更を加えることができるようにファイルにシリアル化することができます。 出力ファイルを選んだ後、[**MediaComposition**](https://msdn.microsoft.com/library/windows/apps/dn652646) の [**SaveAsync**](https://msdn.microsoft.com/library/windows/apps/dn640554) メソッドを呼び出してコンポジションを保存します。

[!code-cs[SaveComposition](./code/MediaEditing/cs/MainPage.xaml.cs#SnippetSaveComposition)]

## <a name="load-a-composition-from-a-file"></a>コンポジションをファイルから読み込む

メディア コンポジションをファイルから逆シリアル化することによって、コンポジションを表示したり変更を加えたりする機能をユーザーに提供することができます。 コンポジション ファイルを選んだ後、[**MediaComposition**](https://msdn.microsoft.com/library/windows/apps/dn652646) の [**LoadAsync**](https://msdn.microsoft.com/library/windows/apps/dn652684) メソッドを呼び出してコンポジションを読み込みます。

[!code-cs[OpenComposition](./code/MediaEditing/cs/MainPage.xaml.cs#SnippetOpenComposition)]

-   コンポジション内のメディア ファイルが、アプリがアクセスできる場所になく、アプリの [**StorageApplicationPermissions**](https://msdn.microsoft.com/library/windows/apps/br207456) クラスの [**FutureAccessList**](https://msdn.microsoft.com/library/windows/apps/br207457) プロパティに存在しない場合、コンポジションの読み込み時にエラーがスローされます。

 

 




