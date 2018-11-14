---
author: drewbatgit
Description: This article describes how to create a Windows Runtime component that implements the IBasicAudioEffect interface to allow you to create custom effects for audio streams.
title: カスタムのオーディオ特殊効果
ms.author: drewbat
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.assetid: 360faf3f-7e73-4db4-8324-3391f801d827
ms.localizationpriority: medium
ms.openlocfilehash: a9c62dac489be07a08acc4ad17ecb79bcc54f57a
ms.sourcegitcommit: 71e8eae5c077a7740e5606298951bb78fc42b22c
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/13/2018
ms.locfileid: "6660622"
---
# <a name="custom-audio-effects"></a>カスタムのオーディオ特殊効果

この記事では、オーディオ ストリームのカスタム効果を作成するための [**IBasicAudioEffect**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Effects.IBasicAudioEffect) インターフェイスを実装する Windows ランタイム コンポーネントを作成する方法について説明します。 カスタム効果は、デバイスのカメラへのアクセスを提供する [MediaCapture](https://msdn.microsoft.com/library/windows/apps/br241124)、メディア クリップから複雑なコンポジションを作成するための [**MediaComposition**](https://msdn.microsoft.com/library/windows/apps/dn652646)、さまざまなオーディオ入力、出力、サブミックス ノードのグラフをすばやくアセンブルできる [**AudioGraph**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Audio.AudioGraph) など、さまざまな Windows ランタイム API で使用できます。

## <a name="add-a-custom-effect-to-your-app"></a>アプリへのカスタム効果の追加


カスタムのオーディオ効果は、[**IBasicAudioEffect**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Effects.IBasicAudioEffect) インターフェイスを実装するクラスで定義します。 このクラスは、アプリのプロジェクトに直接含めることはできません。 代わりに、Windows ランタイム コンポーネントを使ってオーディオ特殊効果のクラスをホストする必要があります。

**オーディオ特殊効果用の Windows ランタイム コンポーネントの追加**

1.  Microsoft Visual Studio で、ソリューションを開き、**[ファイル]** メニューから **[追加]、[新しいプロジェクト]** の順にクリックします。
2.  プロジェクトの種類として **[Windows ランタイム コンポーネント (ユニバーサル Windows)]** を選びます。
3.  この例では、プロジェクトに *AudioEffectComponent* という名前を付けます。 この名前は後でコードで参照されます。
4.  **[OK]** をクリックします。
5.  プロジェクト テンプレートに基づいて、Class1.cs という名前のクラスが作成されます。 **ソリューション エクスプローラー**で、Class1.cs のアイコンを右クリックし、**[名前の変更]** をクリックします。
6.  ファイル名を *ExampleAudioEffect.cs* に変更します。 すべての参照を新しい名前に更新するかどうかを確認するメッセージが表示されたら、 **[はい]** をクリックします。
7.  **ExampleAudioEffect.cs** を開き、クラス定義を更新して [**IBasicAudioEffect**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Effects.IBasicAudioEffect) インターフェイスを実装します。


[!code-cs[ImplementIBasicAudioEffect](./code/AudioGraph/AudioEffectComponent/ExampleAudioEffect.cs#SnippetImplementIBasicAudioEffect)]

この記事の例で使うすべての型にアクセスできるように、効果のクラス ファイルに次の名前空間を含める必要があります。

[!code-cs[EffectUsing](./code/AudioGraph/AudioEffectComponent/ExampleAudioEffect.cs#SnippetEffectUsing)]

## <a name="implement-the-ibasicaudioeffect-interface"></a>IBasicAudioEffect インターフェイスを実装する

オーディオ特殊効果では、[**IBasicAudioEffect**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Effects.IBasicAudioEffect) インターフェイスのすべてのメソッドとプロパティを実装する必要があります。 このセクションでは、基本的なエコー効果を作成する、このインターフェイスの簡単な実装について説明します。

### <a name="supportedencodingproperties-property"></a>SupportedEncodingProperties プロパティ

[**SupportedEncodingProperties**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Effects.IBasicAudioEffect.SupportedEncodingProperties) プロパティは、効果でサポートされるエンコード プロパティを確認するためにシステムでチェックされます。 効果で指定したプロパティを使ってオーディオをエンコードできない場合、[**Close**](https://msdn.microsoft.com/library/windows/apps/dn764782) が呼び出され、効果がオーディオ パイプラインから削除されます。 この例では、[**AudioEncodingProperties**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.MediaProperties.AudioEncodingProperties) オブジェクトが作成され、44.1 kHz と 48 kHz、32 ビットの浮動小数点、モノラル エンコードをサポートする、返された一覧に追加されます。

[!code-cs[SupportedEncodingProperties](./code/AudioGraph/AudioEffectComponent/ExampleAudioEffect.cs#SnippetSupportedEncodingProperties)]

### <a name="setencodingproperties-method"></a>SetEncodingProperties メソッド

[**SetEncodingProperties**](https://msdn.microsoft.com/library/windows/apps/dn919884) は、効果の対象となるオーディオ ストリームのエンコード プロパティを示すために呼び出されます。 エコー効果を実装するため、この例では 1 秒間のオーディオ データを格納するバッファーを使用します。 このメソッドは、オーディオをエンコードするサンプル レートに基づいて、バッファーのサイズを 1 秒間のオーディオのサンプル数に初期化する機会を提供します。 遅延効果では、遅延バッファー内の現在位置を追跡する整数カウンターも使います。 オーディオ パイプラインに効果が追加されるたびに **SetEncodingProperties** 効果が呼び出されるため、これは値を 0 に初期化する良い機会です。 このメソッドに渡された **AudioEncodingProperties** オブジェクトをキャプチャして、効果の他の場所で使用することもできます。

[!code-cs[DeclareEchoBuffer](./code/AudioGraph/AudioEffectComponent/ExampleAudioEffect.cs#SnippetDeclareEchoBuffer)]
[!code-cs[SetEncodingProperties](./code/AudioGraph/AudioEffectComponent/ExampleAudioEffect.cs#SnippetSetEncodingProperties)]


### <a name="setproperties-method"></a>SetProperties メソッド

[**SetProperties**](https://msdn.microsoft.com/library/windows/apps/br240986) メソッドは、呼び出し元のアプリで効果のパラメーターを調整するために使われます。 プロパティは、プロパティ名と値の [**IPropertySet**](https://msdn.microsoft.com/library/windows/apps/br226054) マップとして渡されます。

[!code-cs[SetProperties](./code/AudioGraph/AudioEffectComponent/ExampleAudioEffect.cs#SnippetSetProperties)]

このシンプルな例では、現在のオーディオ サンプルを、**Mix** プロパティの値に従って、遅延バッファーからの値とミキシングします。 プロパティを宣言し、呼び出し元アプリで設定された値を TryGetValue で取得しています。 値が設定されていない場合は、既定値の .5 が使われます。 このプロパティは読み取り専用であることに注意してください。 プロパティの値は **SetProperties** を使って設定する必要があります。

[!code-cs[MixProperty](./code/AudioGraph/AudioEffectComponent/ExampleAudioEffect.cs#SnippetMixProperty)]

### <a name="processframe-method"></a>ProcessFrame メソッド

[**ProcessFrame**](https://msdn.microsoft.com/library/windows/apps/dn764784) メソッドは、効果によって、ストリームのオーディオ データを変更するためのメソッドです。 このメソッドはフレームごとに 1 回呼び出され、[**ProcessAudioFrameContext**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Effects.ProcessAudioFrameContext) オブジェクトが渡されます。 このオブジェクトには、処理対象の着信フレームを格納する入力 [**AudioFrame**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.AudioFrame) オブジェクトと、オーディオ パイプラインの残りの部分に渡すオーディオ データを書き込む出力 **AudioFrame** オブジェクトが含まれています。 オーディオ フレームは、オーディオ データの短いスライスを表す、オーディオ サンプル バッファーです。

**AudioFrame** のデータ バッファーにアクセスするには COM 相互運用機能が必要であるため、効果のクラス ファイルに **System.Runtime.InteropServices** 名前空間を含め、効果の名前空間内に次のコードを追加して、オーディオ バッファーにアクセスするためのインターフェイスをインポートする必要があります。

[!code-cs[ComImport](./code/AudioGraph/AudioEffectComponent/ExampleAudioEffect.cs#SnippetComImport)]

> [!NOTE]
> この手法では管理対象外のネイティブの画像バッファーにアクセスするため、アンセーフ コードを許可するようにプロジェクトを構成する必要があります。
> 1.  ソリューション エクスプローラーで、AudioEffectComponent プロジェクトを右クリックし、**[プロパティ]** を選択します。
> 2.  **[ビルド]** タブを選択します。
> 3.  **[アンセーフ コードの許可]** チェック ボックスをオンにします。

 

これで、**ProcessFrame** メソッドの実装を効果に追加できます。 最初に、入力と出力の両方のオーディオ フレームから [**AudioBuffer**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.AudioBuffer) オブジェクトを取得します。 出力フレームが書き込み用で、入力フレームが読み取り用です。 次に、[**CreateReference**](https://msdn.microsoft.com/library/windows/apps/dn949046) を呼び出して、各バッファーの [**IMemoryBufferReference**](https://msdn.microsoft.com/library/windows/apps/dn921671) を取得します。 その後、実際のデータ バッファーを取得するために、先ほど定義した COM 相互運用機能のインターフェイス (**IMemoryByteAccess**) として **IMemoryBufferReference** オブジェクトをキャストし、**GetBuffer** を呼び出します。

これで、データ バッファーが取得され、入力バッファーからの読み取りと出力バッファーへの書き込みが可能になります。 入力バッファーの各サンプルで値が取得され、1 - **Mix**が乗算されて、効果のドライ信号値が設定されます。 次にエコー バッファー内の現在の位置からサンプルが取得され、**Mix** が乗算されて、効果のウェット値が設定されます。 出力サンプルはドライとウェット値の合計に設定されます。 最後に、各入力サンプルがエコー バッファーに格納され、現在のサンプルのインデックスがインクリメントされます。

[!code-cs[ProcessFrame](./code/AudioGraph/AudioEffectComponent/ExampleAudioEffect.cs#SnippetProcessFrame)]



### <a name="close-method"></a>Close メソッド

[**Close**](https://msdn.microsoft.com/library/windows/apps/dn764782) [**Close**](https://msdn.microsoft.com/library/windows/apps/dn764782) メソッドは、クラスで効果をシャットダウンする必要があるときに呼び出されます。 このメソッドを使って、作成したすべてのリソースを破棄する必要があります。 このメソッドの [**MediaEffectClosedReason**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Effects.MediaEffectClosedReason) 引数により、効果が正常に終了されたかどうかがわかります。エラーが発生したり、必要なエンコード形式が効果でサポートされていないと、この引数で通知されます。

[!code-cs[Close](./code/AudioGraph/AudioEffectComponent/ExampleAudioEffect.cs#SnippetClose)]

### <a name="discardqueuedframes-method"></a>DiscardQueuedFrames メソッド

[**DiscardQueuedFrames**](https://msdn.microsoft.com/library/windows/apps/dn764790) メソッドは、効果をリセットする必要があるときに呼び出されます。 典型的なシナリオとしては、現在のフレームの処理で使うために前に処理したフレームを保存している場合などが挙げられます。 このメソッドが呼び出されたときは、保存した一連のフレームを破棄する必要があります。 このメソッドでは、蓄積されたオーディオ フレームだけでなく、前のフレームに関連するすべての状態をリセットできます。

[!code-cs[DiscardQueuedFrames](./code/AudioGraph/AudioEffectComponent/ExampleAudioEffect.cs#SnippetDiscardQueuedFrames)]

### <a name="timeindependent-property"></a>TimeIndependent プロパティ

TimeIndependent [**TimeIndependent**](https://msdn.microsoft.com/library/windows/apps/dn764803) プロパティは、効果のタイミングを合わせる必要がないかどうかを示します。 true に設定すると、効果のパフォーマンスを高めるために最適化を使用できるようになります。

[!code-cs[TimeIndependent](./code/AudioGraph/AudioEffectComponent/ExampleAudioEffect.cs#SnippetTimeIndependent)]

### <a name="useinputframeforoutput-property"></a>UseInputFrameForOutput プロパティ

効果がその出力を [**ProcessFrame**](https://msdn.microsoft.com/library/windows/apps/dn764784) に渡される [**ProcessAudioFrameContext**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Effects.ProcessAudioFrameContext) の [**OutputFrame**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Effects.ProcessAudioFrameContext.OutputFrame) ではなく、[**InputFrame**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Effects.ProcessAudioFrameContext.InputFrame) のオーディオ バッファーに書き込む場合には、[**UseInputFrameForOutput**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Effects.IBasicAudioEffect.UseInputFrameForOutput) プロパティを **true** に設定します。 

[!code-cs[UseInputFrameForOutput](./code/AudioGraph/AudioEffectComponent/ExampleAudioEffect.cs#SnippetUseInputFrameForOutput)]


## <a name="adding-your-custom-effect-to-your-app"></a>アプリへのカスタム効果の追加


アプリからオーディオ特殊効果を使うには、効果のプロジェクトへの参照をアプリに追加する必要があります。

1.  ソリューション エクスプローラーで、アプリのプロジェクトの下にある **[参照設定]** を右クリックし、**[参照の追加]** を選択します。
2.  **[プロジェクト]** タブを展開し、**[ソリューション]** を選択して、効果のプロジェクトの名前に対応するチェック ボックスをオンにします。 この例では、*AudioEffectComponent* という名前です。
3.  [**OK**] をクリックします。

オーディオ効果クラスが別の名前空間で宣言されている場合は、その名前空間をコード ファイルに含めるようにします。

[!code-cs[UsingAudioEffectComponent](./code/AudioGraph/cs/MainPage.xaml.cs#SnippetUsingAudioEffectComponent)]

### <a name="add-your-custom-effect-to-an-audiograph-node"></a>AudioGraph ノードにカスタム効果を追加する
オーディオ グラフの使用に関する概要については、「[オーディオ グラフ](audio-graphs.md)」をご覧ください。 次のコード スニペットは、この記事で説明したエコー効果をオーディオ グラフ ノードに追加する例を示しています。 まず、[**PropertySet**](https://msdn.microsoft.com/library/windows/apps/Windows.Foundation.Collections.PropertySet) が作成され、効果によって定義された **Mix** プロパティの値が設定されます。 次に、[**AudioEffectDefinition**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Effects.AudioEffectDefinition) コンストラクターが呼び出され、カスタム効果の種類とプロパティ セットの完全なクラス名が渡されます。 最後に、既存の [**FileInputNode**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Audio.CreateAudioFileInputNodeResult.FileInputNode) の [**EffectDefinitions**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Audio.AudioFileInputNode.EffectDefinitions)プロパティに効果の定義が追加され、カスタム効果によるオーディオの処理が行われます。 

[!code-cs[AddCustomEffect](./code/AudioGraph/cs/MainPage.xaml.cs#SnippetAddCustomEffect)]

カスタム効果がノードに追加された後では、[**DisableEffectsByDefinition**](https://msdn.microsoft.com/library/windows/apps/dn958480) を呼び出して、**AudioEffectDefinition** オブジェクトを渡すことにより無効化することができます。 アプリでのオーディオ グラフの使用について詳しくは、「[AudioGraph](audio-graphs.md)」をご覧ください。

### <a name="add-your-custom-effect-to-a-clip-in-a-mediacomposition"></a>MediaComposition のクリップへのカスタム効果の追加

次のコード スニペットは、カスタムのオーディオ効果をメディア コンポジションのビデオクリップとバック グラウンド オーディオ トラックに追加する方法を示しています。 ビデオ クリップからメディア コンポジションを作成してバックグラウンド オーディオ トラックを追加する一般的なガイダンスについては、「[メディア コンポジションと編集](media-compositions-and-editing.md)」を参照してください。

[!code-cs[AddCustomAudioEffect](./code/MediaEditing/cs/MainPage.xaml.cs#SnippetAddCustomAudioEffect)]



## <a name="related-topics"></a>関連トピック
* [シンプルなカメラ プレビューへのアクセス](simple-camera-preview-access.md)
* [メディアのコンポジションと編集](media-compositions-and-editing.md)
* [Win2D ドキュメント](http://go.microsoft.com/fwlink/p/?LinkId=519078)
* [メディア再生](media-playback.md)

 



