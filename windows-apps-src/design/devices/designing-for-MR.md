---
Description: Design your app so that it looks good and functions well in Mixed Reality.
title: Mixed Reality 向けの設計
ms.assetid: ''
label: Designing for Mixed Reality
template: detail.hbs
isNew: true
keywords: Mixed Reality、Hololens、拡張現実、視線、音声、コントローラー
ms.date: 2/5/2018
ms.topic: article
pm-contact: chigy
design-contact: jeffarn
dev-contact: ''
doc-status: ''
ms.localizationpriority: medium
ms.openlocfilehash: e6aebac45dc32933f55d917c0b1153cba952d819
ms.sourcegitcommit: 8921a9cc0dd3e5665345ae8eca7ab7aeb83ccc6f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/10/2018
ms.locfileid: "8874351"
---
# <a name="designing-for-mixed-reality"></a>Mixed Reality 向けの設計

Mixed Reality で適切に表示されるようにアプリを設計し、新しい入力方法を活用します。

## <a name="overview"></a>概要

[Mixed Reality](https://developer.microsoft.com/windows/mixed-reality/mixed_reality) は現実世界とデジタル世界を組み合わせたものです。 Mixed Reality のさまざまなエクスペリエンスには、HoloLens (コンピューターで生成されたコンテンツと現実世界を組み合わせるデバイス) など、1 つの優れたデバイスによるものと、他の Virtual Reality の完全なイマーシブ ビュー (Windows Mixed Reality ヘッドセットに表示される) によるものが含まれます。 さまざまなエクスペリエンスの例については、「[Mixed Reality アプリの種類](https://developer.microsoft.com/en-us/windows/mixed-reality/types_of_mixed_reality_apps)」をご覧ください。

このトピックのいくつかのガイダンスを実行してユーザー エクスペリエンスを改善しますが、既存のほぼすべての UWP アプリは、変更しなくても Mixed Reality 環境で 2D アプリとして実行されます。

![Mixed Reality ビュー](images/MR-01.png)

HoloLens と Windows Mixed Reality ヘッドセットの両方が UWP プラットフォーム上で実行されるアプリケーションをサポートし、両方とも 2 つの異なる種類のエクスペリエンスをサポートしています。 

### <a name="2d-vs-immersive-experience"></a>2D とイマーシブ エクスペリエンス

イマーシブ アプリはユーザーに表示される画面全体を制御し、アプリによって作成されるビューの中央にユーザーが配置されます。 たとえば、イマーシブなゲームでは、エイリアンの惑星の地表にユーザーが配置されたり、ツアー ガイド アプリでは、南米の村にユーザーが配置されることもあります。 イマーシブ アプリを作成するには、3 D グラフィックスまたはキャプチャした立体映像が必要です。 多くの場合、Unity や DirectX など、サード パーティのゲーム エンジンを使用してイマーシブ アプリを開発します。

イマーシブ アプリを作成する場合、詳細については、[Windows Mixed Reality デベロッパー センター](https://developer.microsoft.com/windows/mixed-reality) を参照してください。

2D アプリは、ユーザーのビュー内で従来のフラット ウィンドウとして実行します。 HoloLens では、ユーザー独自の現実世界でリビング ルームやオフィスの空間内にある壁またはポイントに固定されたビューを指します。 Windows Mixed Reality ヘッドセットで、アプリは [Mixed Reality ホーム](https://docs.microsoft.com/windows/mixed-reality/enthusiast-guide/your-mixed-reality-home) (*クリフ ハウス*とも呼ばれる) の壁に固定されます。

![Mixed Reality で実行される複数のアプリ](images/MR-multiple.png)


これらの 2D アプリはビュー全体を制御するのではなく、ビュー内に配置されます。 環境内には一度に複数の 2D アプリが存在することができます。

このトピックの残りの部分では、2D エクスペリエンスの設計に関する考慮事項について説明します。

## <a name="launching-2d-apps"></a>2D アプリの起動

![Mixed Reality の [スタート] メニュー](images/MR-start-options.png)

すべてのアプリは [スタート] メニューから起動しますが、アプリの起動ツールとして動作する 3D オブジェクトを作成することもできます。 詳しくは、[このビデオ](https://www.youtube.com/watch?v=TxIslHsEXno) をご覧ください。

## <a name="the-2d-app-input-overview"></a>2D アプリの入力概要

HoloLens と Mixed Reality の両方のプラットフォームでは、キーボードおよびマウスがサポートされています。 Bluetooth を介してキーボードおよびマウスを HoloLens と直接ペアリングすることができます。 Mixed Reality アプリは、ホスト コンピューターに接続されたマウスとキーボードをサポートします。 両方とも微調整が必要な場合に役立ちます。

また、他の一般的な入力方法もサポートされています。ユーザーがオフィスにいない場合や微調整が必要な場合などに特に役立ちます。

ハードウェアまたはコーディングを追加しなくても、2D アプリの使用時のマウス ポインターとして、視線、つまりユーザーが見ているベクトルを使用します。 仮想シーン内のものにマウス ポインターを合わせているかのように実装されます。

一般的な操作では、ユーザーがアプリのコントロールを見ると、このコントロールは強調されます。 ユーザーは、ジェスチャ (HoloLens 上) またはコントローラーや音声コマンドを使用して動作をトリガーするタイミングを指定します。 ユーザーがテキスト入力フィールドを選択すると、ソフトウェア キーボードが表示されます。 


![Mixed Reality のポップアップ キーボード](images/MR-keyboard.png)

重要なことは、UWP プラットフォーム上で実行することで、自分でコーディングを追加しなくても、これらすべての操作が自動的に行われる点です。 HoloLens と Mixed Reality ヘッドセットからの入力は、タッチ入力として 2D アプリに表示されます。 つまり、既定では、多くの UWP アプリを実行し、Mixed Reality で使用することができます。 

ただし、作業を少し追加すると、エクスペリエンスを大幅に向上できます。 たとえば、[音声コントロール](https://developer.microsoft.com/windows/mixed-reality/voice_design)は特に有効です。 HoloLens と Mixed Reality の両方の環境でアプリの起動と操作の音声コマンドがサポートされており、音声サポートなどはこの方法の一般的な拡張機能として表示されます。 音声サポートを UWP アプリに追加する際の詳細については、「[音声操作]( https://docs.microsoft.com/windows/uwp/design/input/speech-interactions)」をご覧ください。 


### <a name="selecting-the-right-controller"></a>適切なコントローラーの選択

![Mixed Reality モーション コントローラー](images/MR-controllers.png)

Mixed Reality 専用のいくつかの新しい入力方法が設計されました。

* [ハンド ジェスチャ](https://developer.microsoft.com/windows/mixed-reality/gestures) (HoloLens のみ、2D アプリの起動専用)
* [ゲームパッド サポート](https://developer.microsoft.com/windows/mixed-reality/hardware_accessories) (両方の環境)
* [クリッカー デバイス](https://developer.microsoft.com/windows/mixed-reality/hardware_accessories) (HoloLens のみ)
* [モーション コントローラー](https://developer.microsoft.com/windows/mixed-reality/motion_controllers) (Mixed Reality デバイスのみ、上述のとおり)

これらのコントローラーにより、仮想オブジェクトの操作が自然かつ正確になります。 いくつかの操作は無料で利用できます。 たとえば、HoloLens の選択ジェスチャまたはモーション コント ローラーの Windows キーやトリガーをクリックするとは、予想される、ここでも、ユーザー側でコーディングしなくて入力応答が生成されます。

それ以外の場合は、追加情報と利用可能な入力情報を活用するコードを追加します。 たとえば、位置とボタン操作を考慮するコードを作成する場合、モーション コントローラーを使用すると、オブジェクトを細かく操作できます。

> [!NOTE]
> 要約: 基本理念では、常にできるだけ自然でスムーズな入力方法をユーザーに提供するようにしています。


## <a name="2d-app-design-considerations-functionality"></a>2D アプリ設計の考慮事項: 機能

Mixed Reality プラットフォームで使用する可能性がある UWP アプリを作成する場合は、次の点に注意してください。

* モーション コントローラー、ゲームパッド、またはジェスチャを使用すると、ドラッグ アンド ドロップが適切に動作しない場合があります。 ドラッグ アンド ドロップを頻繁に使用するアプリケーションの場合は、オブジェクトを新しい場所に移動するかどうかを確認するダイアログを表示するなど、この操作をサポートする代替方法を提供する必要があります。

* 音の変化に注意してください。 アプリでサウンド エフェクトを生成する場合、音源はアプリの仮想世界で固定された場所に表示されます。 ユーザーがアプリから離れると、音が消えます。 詳しくは、「[立体音響](https://developer.microsoft.com/windows/mixed-reality/spatial_sound)」をご覧ください。

* 視野を考慮して、アフォーダンスを用意します。 すべてのデバイスでコンピューター モニターと同じ大きさの視野が用意されるわけではありません。 詳しくは、「[ホログラフィック フレーム](https://developer.microsoft.com/windows/mixed-reality/holographic_frame)」をご覧ください。 さらに、ユーザーが実行中のアプリから離れている場合があります。 つまり、アプリが現実世界または仮想世界の異なる場所にある壁に固定されている場合があります。 ユーザーの注意を引く必要があったり、ビューが常に表示されていないことを考慮する必要があります。 トースト通知は使用できますが、音または[音声](https://github.com/Microsoft/Windows-universal-samples/blob/master/Samples/SpeechRecognitionAndSynthesis/cs/Scenario_SynthesizeText.xaml.cs) アラートを使用してユーザーの注意を引く別の方法もあります。

* 2D アプリには[アプリ バー](https://developer.microsoft.com/windows/mixed-reality/app_bar_and_bounding_box) が自動的に用意されるため、ユーザーは仮想環境で移動および拡大縮小を行うことができます。 ビューは、垂直方向にサイズ変更したり、同じ縦横比を維持するようにサイズ変更できます。


## <a name="2d-app-design-considerations-uiux"></a>2D アプリ設計の考慮事項: UI/UX

* [ナビゲーション ビュー](https://docs.microsoft.com/windows/uwp/design/controls-and-patterns/navigationview) などの[Fluent Design System](https://docs.microsoft.com/windows/uwp/design/fluent-design-system/) を実装する XAML コントロールと [アクリル](https://docs.microsoft.com/windows/uwp/design/style/acrylic) などのエフェクトはすべて、2D Mixed Reality アプリに特化して適切に動作します。

* Mixed Reality デバイス、または少なくとも Mixed Reality シミュレーターでアプリのテキストとウィンドウのサイズをテストします。 アプリの既定のウィンドウ サイズは 853 x 480 有効ピクセルです。 フォント サイズを大きくし (推奨ポイント サイズは約 32)、「[Hololens 用の既存のユニバーサル アプリを更新する](https://developer.microsoft.com/windows/mixed-reality/updating_your_existing_universal_app_for_hololens)」を確認します。 記事「[文字体裁](https://developer.microsoft.com/windows/mixed-reality/typography)」では、このトピックの詳細について説明しています。 Visual Studio で作業する場合は、57 インチ HoloLens 2D アプリ用に設定された XAML 設計エディターがあるため、正しいスケールと寸法のビューが表示されます。 

![Mixed Reality アプリに表示されるテキストは大きくなります。](images/MR-text.png)

* [視線がマウスになります](https://developer.microsoft.com/windows/mixed-reality/gaze_targeting)。 ユーザーが何かを見ると、**タッチ ホバー** イベントとして動作するため、オブジェクトを見るだけで、不要なホップアップが表示されたり、他の不要な操作が実行される場合があります。 アプリが Mixed Reality で現在実行されているかどうかを検出し、この動作の変更が必要になる場合があります。 下記の「**ランタイム サポート**」のご覧ください。 

* ユーザーがモーション コントローラーを使用してどこかの方向やポイントを見ると、**タッチ ホバー** イベントが発生します。 これは [**PointerPoint**] で構成されます。この場合、[**PointerType**] は [**Touch**]、[**IsInContact**] は [**false**] です。 何かが確定すると (たとえば、ゲームパッドの A ボタンが押された場合、クリッカー デバイスが押された場合、モーション コントローラーのトリガーが押された場合、または音声認識で [選択] を選んだ場合)、[**PointerPoint**] の [**IsInContact**] が [**true**] となり、**タッチ プレス**が発生します。 入力イベントの詳細については、「[タッチ操作](https://docs.microsoft.com/windows/uwp/design/input/touch-interactions)」をご覧ください。

* 視線はマウス ポインターほど正確でありません。 マウス ターゲットまたはボタンが小さくなるほど、ユーザーには不便になるため、コントロールのサイズを適切に変更します。 タッチ操作用に設計した場合は、Mixed Reality で動作しますが、実行時にいくつかのボタンを大きくすることもあります。 「[Hololens 用の既存のユニバーサル アプリを更新する](https://developer.microsoft.com/windows/mixed-reality/updating_your_existing_universal_app_for_hololens)」をご覧ください。

* HoloLens では、光の有無を黒色で定義します。 これはレンダリングされないだけでなく、「現実世界」では透けて見えます。 このことが混乱を招く場合は、アプリケーションで黒色を使用しないでください。 Mixed Reality ヘッドセットでは、黒色は黒色を指します。

* HoloLens はアプリのカラー テーマをサポートしていないため、ユーザーに最適なエクスペリエンスを実現できるように既定値は青色に設定されています。 色の選択の詳細については、[このトピック](https://developer.microsoft.com/windows/mixed-reality/color,_light_and_materials) を参照してください。ここでは、Mixed Reality 設計での色とマテリアルの使用方法について説明しています。


## <a name="other-points-to-consider"></a>他に考慮する点

* [デスクトップ ブリッジ](https://docs.microsoft.com/windows/uwp/porting/desktop-to-uwp-root) により、既存の (Win32) デスクトップ アプリを Windows 10 および Microsoft Store に移植できますが、現時点で HoloLens または Mixed Reality で実行できるアプリを作成することはできません。




## <a name="runtime-support"></a>ランタイム サポート

実行時に Mixed Reality デバイスで実行するかどうかを判断したり、コントロールのサイズを変更し、ヘッドセットで使用するアプリを他の方法で最適化する機会としてこのアプリを使用したりできます。

次に、アプリを Mixed Reality デバイスで使用している場合にのみ、XAML の TextBlock コントロール内のテキストのサイズを変更するコードを示します。

```csharp

bool isViewingInMR = Windows.ApplicationModel.Preview.Holographic.HolographicApplicationPreview.IsCurrentViewPresentedOnHolographicDisplay();

            if (isViewingInMR)
            {
                // Running on headset, resize the XAML text
                textBlock.Text = "I'm running in Mixed Reality!";
                textBlock.FontSize = 32;
            }
            else
            {
                // Running on desktop
                textBlock.Text = "I'm running on the desktop.";
                textBlock.FontSize = 16;
            }

```





## <a name="related-articles"></a>関連記事


* [シェルから API を使用するアプリの現在の制限事項](https://developer.microsoft.com/windows/mixed-reality/current_limitations_for_apps_using_apis_from_the_shell)
* [2D アプリのビルド](https://developer.microsoft.com/windows/mixed-reality/building_2d_apps)
* [HoloLens: Microsoft HoloLens 用の UWP 2D アプリのビルド](https://channel9.msdn.com/Events/Build/2016/B854)
* [条件付き XAML](https://docs.microsoft.com/en-us/windows/uwp/debug-test-perf/conditional-xaml)


