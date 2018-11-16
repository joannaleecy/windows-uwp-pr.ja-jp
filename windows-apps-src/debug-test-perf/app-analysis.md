---
author: jwmsft
title: アプリの分析
description: アプリを分析してパフォーマンスの問題を調べます。
ms.author: jimwalk
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 346e6790c6578bf861ba1dda937eae6d4d50f00f
ms.sourcegitcommit: e38b334edb82bf2b1474ba686990f4299b8f59c7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/15/2018
ms.locfileid: "6843305"
---
# <a name="app-analysis-overview"></a>アプリの分析の概要

App Analysis は、パフォーマンスの問題を開発者に通知するツールです。 このツールでは、アプリのコードが実行され、一連のパフォーマンス ガイドラインとベスト プラクティスへの準拠が確認されます。

App Analysis は、アプリで発生する一般的なパフォーマンスの問題から成る規則セットに基づいて問題を特定します。 また必要に応じて、調査の助けとなる Visual Studio のタイムライン ツール、ソース情報、ドキュメントを示します。

App Analysis の規則とは、それに基づいてアプリがチェックされるガイドラインやベスト プラクティスを意味します。

## <a name="decoded-image-size-larger-than-render-size"></a>デコードされた画像サイズがレンダリング後のサイズよりも大きい

画像を非常に高い解像度でキャプチャすると、アプリで画像データをデコードする際の CPU 負荷が大きくなり、ディスクから画像を読み込んだときに大容量のメモリが使用されます。 ただし、画像を元のサイズよりも小さいサイズでのみ表示する場合、高解像度の画像をデコードしてメモリに保存するのは無意味です。 この場合、DecodePixelWidth プロパティと DecodePixelHeight プロパティを使って、画面上に描画される正確なサイズのバージョンの画像を作成することができます。

### <a name="impact"></a>影響

ネイティブでないサイズでの画像表示は、CPU 時間 (適正なサイズへのデコーディングとダウンロードに時間がかかるため) とメモリの両方に悪影響を及ぼします。

### <a name="causes-and-solutions"></a>原因と解決策

#### <a name="image-is-not-being-set-asynchronously"></a>画像が非同期に設定されていない

アプリで、SetSourceAsync() ではなく SetSource() が使用されています。 画像を非同期にデコードするようにストリームを設定する場合は、[**SetSource**](https://msdn.microsoft.com/library/windows/apps/BR243255) ではなく [**SetSourceAsync**](https://msdn.microsoft.com/library/windows/apps/JJ191522) を使います。 

#### <a name="image-is-being-called-when-the-imagesource-is-not-in-the-live-tree"></a>ImageSource がライブ ツリーに存在しないときに画像を呼び出している

BitmapImage は、SetSourceAsync または UriSource によってコンテンツを設定した後、ライブ XAML ツリーに接続されます。 必ずソースを設定する前に、[**BitmapImage**](https://msdn.microsoft.com/library/windows/apps/BR243235) をライブ ツリーに接続する必要があります。 マークアップで画像要素またはブラシが指定されているときは、常にこのことが当てはまります。 次に例を示します。 

**ライブ ツリーの例**

例 1 (良い例): Uniform Resource Identifier (URI) をマークアップで指定。

```xml
<Image x:Name="myImage" UriSource="Assets/cool-image.png"/>
```

例 2 マークアップ: 分離コードで指定された URI。

```xml
<Image x:Name="myImage"/>
```

例 2 分離コード (良い例): UriSource を設定する前に、ツリーに BitmapImage を接続する。

```vb
var bitmapImage = new BitmapImage();
myImage.Source = bitmapImage;
bitmapImage.UriSource = new URI("ms-appx:///Assets/cool-image.png", UriKind.RelativeOrAbsolute);
```

例 2 分離コード (悪い例): ツリーに接続する前に、BitmapImage の UriSource を設定します。

```vb
var bitmapImage = new BitmapImage();
bitmapImage.UriSource = new URI("ms-appx:///Assets/cool-image.png", UriKind.RelativeOrAbsolute);
myImage.Source = bitmapImage;
```

#### <a name="image-brush-is-non-rectangular"></a>イメージ ブラシが四角形でない 

画像が四角形以外のブラシに使用されている場合、画像の拡大縮小が行われない、ソフトウェア ラスタライズ パスが使用されます。 また、ソフトウェアとハードウェアの両方のメモリに画像のコピーを保存する必要があります。 たとえば、画像が楕円形のブラシとして使われる場合、大きい可能性がある画像全体は内部で 2 回保存されます。 四角形以外のブラシを使用する場合は、アプリで画像を事前に拡大縮小し、レンダリング時のおよそのサイズにしておく必要があります。

代わりに、[**DecodePixelWidth**](https://msdn.microsoft.com/library/windows/apps/BR243243) プロパティと [**DecodePixelHeight**](https://msdn.microsoft.com/library/windows/apps/BR243241) プロパティを使って、明示的にデコード サイズを設定することで、画面上に描画される正確なサイズのバージョンの画像を作成できます。

```xml
<Image>
    <Image.Source>
    <BitmapImage UriSource="ms-appx:///Assets/highresCar.jpg" 
                 DecodePixelWidth="300" DecodePixelHeight="200"/>
    </Image.Source>
</Image>
```

[**DecodePixelWidth**](https://msdn.microsoft.com/library/windows/apps/BR243243) と [**DecodePixelHeight**](https://msdn.microsoft.com/library/windows/apps/BR243241) の単位は、既定では物理ピクセルです。 [**DecodePixelType**](https://msdn.microsoft.com/library/windows/apps/Dn298545) プロパティを使って、この動作を変更できます。**DecodePixelType** を **Logical** に設定すると、他の XAML コンテンツと同様に、デコード サイズで自動的に現在の倍率が考慮されます。 したがって、一般的には、**DecodePixelType** を **Logical** に設定することをお勧めします。たとえば、**DecodePixelWidth** と **DecodePixelHeight** を、画像が表示される Image コントロールの Height プロパティと Width プロパティと一致させるような場合です。 物理ピクセルを使用する既定の動作では、システムの現在の倍率を自分で考慮する必要があります。また、ユーザーが表示設定を変更する場合に備えて、スケール変更通知をリッスンする必要があります。

事前に適切なデコード サイズを特定できない場合には、明示的な DecodePixelWidth/DecodePixelHeight が指定されていないときに、適切なサイズでの画像のデコードをベスト エフォート形式で試行する、XAML の適切なサイズの自動デコードを遅延させる必要があります。

事前に画像コンテンツのサイズがわかっている場合は、明示的にデコード サイズを設定する必要があります。 指定したデコード サイズが他の XAML 要素のサイズを基準としている場合は、併せて [**DecodePixelType**](https://msdn.microsoft.com/library/windows/apps/Dn298545) を **Logical** に設定することも必要です。 たとえば、Image.Width と Image.Height を使ってコンテンツのサイズを明示的に設定する場合、DecodePixelType を DecodePixelType.Logical に設定して Image コントロールと同じ論理ピクセル サイズを使用し、明示的に BitmapImage.DecodePixelWidth や BitmapImage.DecodePixelHeight を使って画像のサイズを制御することによって、大量のメモリ消費を抑えることができる可能性があります。

デコードされたコンテンツのサイズを決定するときに、Image.Stretch を考慮する必要があることに注意してください。

#### <a name="images-used-inside-of-bitmapicons-fall-back-to-decoding-to-natural-size"></a>BitmapIcons 内で使用されている画像が、自然なサイズのデコードにフォール バックしている 

[**DecodePixelWidth**](https://msdn.microsoft.com/library/windows/apps/BR243243) プロパティと [**DecodePixelHeight**](https://msdn.microsoft.com/library/windows/apps/BR243241) プロパティを使って、明示的にデコード サイズを設定することで、画面上に描画される正確なサイズのバージョンの画像を作成できます。

#### <a name="images-that-appear-extremely-large-on-screen-fall-back-to-decoding-to-natural-size"></a>画面上で極端に大きく表示されるイメージが、自然なサイズのデコードにフォールバックしている 

画面上で極端に大きく表示されるイメージは、自然なサイズのデコードにフォールバックします。 [**DecodePixelWidth**](https://msdn.microsoft.com/library/windows/apps/BR243243) プロパティと [**DecodePixelHeight**](https://msdn.microsoft.com/library/windows/apps/BR243241) プロパティを使って、明示的にデコード サイズを設定することで、画面上に描画される正確なサイズのバージョンの画像を作成できます。

#### <a name="image-is-hidden"></a>画像が非表示になっている

ホスト画像要素、ブラシ、親要素のいずれかで、Opacity が 0 に設定されているか、Visibility が Collapsed に設定されているために、画像が非表示になっています。 クリッピングまたは透明度の設定のために画面に表示されない画像は、自然なサイズのデコードにフォールバックする可能性があります。 

#### <a name="image-is-using-ninegrid-property"></a>イメージで NineGrid プロパティが使用されている

画像が [**NineGrid**](https://msdn.microsoft.com/library/windows/apps/BR242756) 用に使用されている場合、画像の拡大縮小が行われない、ソフトウェア ラスタライズ パスが使用されます。 また、ソフトウェアとハードウェアの両方のメモリに画像のコピーを保存する必要があります。 **NineGrid** を使用する場合は、アプリで画像を事前に拡大縮小し、レンダリング時のおよそのサイズにしておく必要があります。

NineGrid プロパティを使用しているイメージは、自然なサイズのデコードにフォールバックします。 元のイメージに ninegrid 効果を追加することを検討してください。

#### <a name="decodepixelwidth-or-decodepixelheight-are-set-to-a-size-thats-larger-than-the-image-will-appear-on-screen"></a>DecodePixelWidth や DecodePixelHeight が画面上での画像の表示サイズよりも大きく設定されている 

DecodePixelWidth/Height が画面に表示される画像よりも大きいサイズに明示的に設定されている場合、アプリは不必要に余分なメモリ (1 ピクセルあたり最大 4 バイト) を使用するため、大きい画像では負荷が急速に増大します。 また、画像はバイリニア スケーリングを使って縮小されるため、倍率が大きくなるとぼやけて見える原因となる可能性があります。

#### <a name="image-is-decoded-as-part-of-producing-a-drag-and-drop-image"></a>画像がドラッグ アンド ドロップ画像を生成する一部としてデコードされている

[**DecodePixelWidth**](https://msdn.microsoft.com/library/windows/apps/BR243243) プロパティと [**DecodePixelHeight**](https://msdn.microsoft.com/library/windows/apps/BR243241) プロパティを使って、明示的にデコード サイズを設定することで、画面上に描画される正確なサイズのバージョンの画像を作成できます。

## <a name="collapsed-elements-at-load-time"></a>要素が読み込み時に折りたたまれている

アプリは、最初 UI 要素を非表示にし、後でそれらを表示するのが一般的なパターンです。 ほとんどの場合、読み込み時に要素を作成するコストを回避するために、x:Load または x:DeferLoadStrategy を使用してこれらの要素の読み込みを延期する必要があります。

これにはブール値と Visibility 値のコンバーターを使って、後で表示するときまで項目を非表示にする場合が含まれます。

### <a name="impact"></a>影響

折りたたまれた要素が他の要素と一緒に読み込まれると、読み込み時間が増加します。

### <a name="cause"></a>原因

この規則がトリガーされるのは、読み込み時に要素が折りたたまれているためです。 要素を折りたたんだり、不透明度を 0 に設定したりしても、要素の作成は回避されません。 この規則は、既定値が false に設定された、ブール値と Visibility 値のコンバーターを使うアプリによって発生する可能性があります。

### <a name="solution"></a>解決策

[x:Load 属性](../xaml-platform/x-load-attribute.md)または [x:DeferLoadStrategy](https://msdn.microsoft.com/library/windows/apps/Mt204785) を使って、UI の要素の読み込みを遅らせて、必要に応じて読み込むことができます。 最初のフレームで表示しない UI について処理を延期する場合は、この方法をお勧めします。 要素は必要に応じてその都度読み込むか、後で実行する一連のロジックの一部として読み込むことができます。 読み込みをトリガーするには、読み込む要素に対して findName を呼び出します。 x:Load は x:DeferLoadStrategy の機能を拡張して、要素をアンロードできるようにしたり、読み込み状態を x:Bind によって制御できるようにしたりします。

場合によっては、findName を使って UI 要素を表示する方法では問題を解決できないことがあります。 たとえば、クリックによって多くの UI をきわめて短い遅延時間で表示する場合などです。 この場合、追加メモリのコストのために高速な UI 待機時間を妥協することもできます。そうするには、x:DeferLoadStrategy を使用し、実現する要素の Visibility を Collapsed に設定する必要があります。 これにより、ページが読み込まれ、UI スレッドが解放された後、必要に応じて findName を呼び出して要素を読み込むことができます。 要素は、その要素の Visibility を Visible に設定するまでユーザーには表示されません。

## <a name="listview-is-not-virtualized"></a>ListView が仮想化されていない

UI の仮想化は、コレクションのパフォーマンスを向上させることができる最も重要な機能です。 これは、項目を表す UI 要素がオンデマンドで作成されることを意味します。 1,000 項目のコレクションにバインドされている項目コントロールでは、すべての項目の UI を同時に作成しても、同時に全部を表示することはできないため、リソースを無駄に使うことになります。 UI の仮想化は、ListView と GridView (およびその他の ItemsControl から派生した標準コントロール) によって実行されます。 数ページ先にある項目がスクロールされて表示されそうになると、フレームワークがその項目用の UI を生成してキャッシュします。 項目がもう一度表示される可能性が低い場合、フレームワークはメモリを解放します。

UI の仮想化は、コレクションのパフォーマンスを向上させる重要な複数の要因の 1 つに過ぎません。 コレクションのパフォーマンス向上には、この他に、コレクション項目の複雑さの軽減とデータ仮想化の 2 つの重要な側面があります。 ListView と GridView 内のコレクションのパフォーマンスを向上させる方法について詳しくは、「[ListView と GridView の UI の最適化](https://msdn.microsoft.com/windows/uwp/debug-test-perf/optimize-gridview-and-listview)」と「[ListView と GridView のデータ仮想化](https://msdn.microsoft.com/windows/uwp/debug-test-perf/listview-and-gridview-data-optimization)」に関する記事をご覧ください。

### <a name="impact"></a>影響

仮想化されていない ItemsControl は、必要のない子項目まで読み込むため、読み込み時間とリソース使用量が増大します。

### <a name="cause"></a>原因

表示される可能性のある要素の作成はフレームワークが行う必要があるため、ビューポートの概念は UI の仮想化にとって非常に重要です。 一般的に、ItemsControl のビューポートは論理コントロールの範囲を指します。 たとえば、ListView のビューポートは ListView 要素の幅と高さです。 一部のパネルでは子要素に制限のない空間を与えることができます。たとえば ScrollViewer や Grid では、行または列のサイズが自動的に調整されます。 このようなパネルに仮想化された ItemsControl を配置すると、すべての項目を表示できるスペースが用意され、仮想化の意味がなくなります。 

### <a name="solution"></a>解決策

仮想化を復元するには、使用する ItemsControl に幅と高さを設定します。

## <a name="ui-thread-blocked-or-idle-during-load"></a>UI スレッドがブロックされているか、読み込み中にアイドル状態になっている

UI スレッドのブロックとは、オフスレッドで実行されて UI スレッドをブロックする関数への同期呼び出しを指します。  

アプリ起動時のパフォーマンスを向上させるためのすべてのベスト プラクティスについては、「[アプリ起動時のパフォーマンスのベスト プラクティス](https://msdn.microsoft.com/windows/uwp/debug-test-perf/best-practices-for-your-app-s-startup-performance)」と」[UI スレッドの応答性の確保](https://msdn.microsoft.com/windows/uwp/debug-test-perf/keep-the-ui-thread-responsive)」をご覧ください。

### <a name="impact"></a>影響

読み込み時に UI スレッドがブロックされるかアイドル状態になると、レイアウトやその他の UI 操作が実行できないため、起動に時間がかかります。

### <a name="cause"></a>原因

UI のプラットフォーム コードと UI 用のアプリのコードはすべて、同じ UI スレッドで実行されます。 このスレッドでは一度に 1 つの命令しか実行できないため、アプリのコードの実行に長い時間がかかるとイベントを処理できず、フレームワークはレイアウトを実行したりユーザー操作を表す新しいイベントを生成したりできません。 アプリの応答性は、作業の処理に UI スレッドを使えるかどうかに関係します。

### <a name="solution"></a>解決策

アプリが部分的に機能していない場合でも、アプリで操作を受け付けることができます。 たとえば、アプリが表示するデータの取得に時間がかかっている場合に、データを非同期で取得することによって、そのコードをアプリの起動コードとは別に実行できます。 データが利用できる状態であれば、アプリのユーザー インターフェイスにデータを表示することができます。 アプリの高い応答性を維持するため、このプラットフォームの API の大部分に非同期バージョンが用意されています。 非同期 API を使うと、アクティブな実行スレッドが長時間ブロックされた状態になるのを防ぐことができます。 UI スレッドから API を呼び出す場合、提供されている限りは非同期バージョンを使ってください。

## <a name="binding-is-being-used-instead-of-xbind"></a>{x:Bind} の代わりに {Binding} が使用されている

この規則はアプリで {binding} ステートメントが使われているときにトリガーされます。 アプリのパフォーマンスを向上させるには、アプリで {x:Bind} 使用することを検討してください。

### <a name="impact"></a>影響

{Binding} は、{x:Bind} よりも実行に時間がかかり、多くのメモリ量を消費します。

### <a name="cause"></a>原因

アプリで、{x:Bind} の代わりに {Binding} が使用されています。 {Binding} を使うと、多大なワーキング セットと CPU オーバーヘッドが生じます。 {Binding} を作成すると一連の割り当てが行われるほか、バインディング ターゲットの更新がリフレクションやボックス化の原因となる可能性があります。

### <a name="solution"></a>解決策

{x:Bind} マークアップ拡張を使用してビルド時にバインディングをコンパイルします。 {x:Bind} バインディング (多くの場合、コンパイル済みバインドと呼ばれます) はパフォーマンスが高く、コンパイル時にバインド式を検証したり、ページの部分クラスとして生成されたコード ファイル内にブレークポイントを設定し、デバッグを行ったりできます。 

x:Bind は、適切でない場合もあることに注意してください (遅延バインディングのシナリオなど)。 {x:Bind} で対応できない場合の完全な一覧については、{x:Bind} のドキュメントをご覧ください。

## <a name="xname-is-being-used-instead-of-xkey"></a>x:Key の代わりに x:Name が使われている

ResourceDictionaries は通常、ある程度グローバル レベルでリソースを格納する場合に使用されます。つまり、アプリの複数の場所で参照する必要があるリソース (スタイル、ブラシ、テンプレートなど) の格納に使われます。 一般的に、要求されない限り、リソースがインスタンス化されないようにするために ResourceDictionaries を最適化します。 少し注意を払う必要がある場合がいくつかあります。

### <a name="impact"></a>影響

x:Name が設定されたリソースは、ResourceDictionary が作成されるとすぐにインスタンス化されます。 これは、x: Name がプラットフォームに対し、アプリがこのリソースへのフィールド アクセスを必要としており、プラットフォームは参照を作成するものを何か作成する必要があると指示するからです。

### <a name="cause"></a>原因

アプリで、リソースに対して x:Name が設定されています。

### <a name="solution"></a>解決策

分離コードのリソースを参照しない場合、x: Name ではなく X:key を使用します。

## <a name="collections-control-is-using-a-non-virtualizing-panel"></a>コレクション コントロールが非仮想化パネルを使っている

カスタム項目パネル テンプレート (ItemsPanel をご覧ください) を用意する場合は、ItemsWrapGrid や ItemsStackPanel などの仮想パネルを必ず使用してください。 VariableSizedWrapGrid、WrapGrid、または StackPanel を使用した場合、仮想化は得られません。 また、ChoosingGroupHeaderContainer、ChoosingItemContainer、ContainerContentChanging の各 ListView イベントは、ItemsWrapGrid または ItemsStackPanel を使用したときにのみ発生します。

UI の仮想化は、コレクションのパフォーマンスを向上させることができる最も重要な機能です。 これは、項目を表す UI 要素がオンデマンドで作成されることを意味します。 1,000 項目のコレクションにバインドされている項目コントロールでは、すべての項目の UI を同時に作成しても、同時に全部を表示することはできないため、リソースを無駄に使うことになります。 UI の仮想化は、ListView と GridView (およびその他の ItemsControl から派生した標準コントロール) によって実行されます。 数ページ先にある項目がスクロールされて表示されそうになると、フレームワークがその項目用の UI を生成してキャッシュします。 項目がもう一度表示される可能性が低い場合、フレームワークはメモリを解放します。

UI の仮想化は、コレクションのパフォーマンスを向上させる重要な複数の要因の 1 つに過ぎません。 コレクションのパフォーマンス向上には、この他に、コレクション項目の複雑さの軽減とデータ仮想化の 2 つの重要な側面があります。 ListView と GridView 内のコレクションのパフォーマンスを向上させる方法について詳しくは、「[ListView と GridView の UI の最適化](https://msdn.microsoft.com/windows/uwp/debug-test-perf/optimize-gridview-and-listview)」と「[ListView と GridView のデータ仮想化](https://msdn.microsoft.com/windows/uwp/debug-test-perf/listview-and-gridview-data-optimization)」に関する記事をご覧ください。

### <a name="impact"></a>影響

仮想化されていない ItemsControl は、必要のない子項目まで読み込むため、読み込み時間とリソース使用量が増大します。

### <a name="cause"></a>原因

仮想化をサポートしていないパネルが使われています。

### <a name="solution"></a>解決策

ItemsWrapGrid や ItemsStackPanel などの仮想化パネルを使います。

## <a name="accessibility-uia-elements-with-no-name"></a>アクセシビリティ: 名前のない UIA 要素

XAML では、AutomationProperties.Name を設定することで名前を指定できます。 多くのオートメーション ピアでは、AutomationProperties.Name を設定していない場合、UIA に既定の名前が指定されます。 

### <a name="impact"></a>影響

表示された要素に名前がなければ、それが何に関連する要素なのかをユーザーが理解することは困難です。 

### <a name="cause"></a>原因

要素の UIA 名が null または空です。 この規則では、AutomationProperties.Name の値ではなく、UIA に指定された名前がチェックされます。

### <a name="solution"></a>解決策

コントロールの XAML 内の AutomationProperties.Name プロパティに、ローカライズされた適切な文字列を設定します。

アプリケーションによっては、名前を指定するのではなく、Raw ツリー以外のすべてのツリーから UIA 要素を削除して修正する方法が適切である場合があります。 これには、XAML で AutomationProperties.AccessibilityView = “Raw” と設定します。

## <a name="accessibility-uia-elements-with-the-same-controltype-should-not-have-the-same-name"></a>アクセシビリティ: 同じ Controltype の UIA 要素は同じ名前を持つことはできない

同じ UIA の親を持つ 2 つの UIA 要素に、同じ Name と ControlType を設定してはなりません。 2 つのコントロールの ControlTypes が異なる場合は、同じ Name を指定することができます。 

この規則は、異なる親を持つ複数の要素で名前が重複している場合をチェックしません。 しかし、ほとんどの場合、親が違っていてもウィンドウ全体で Name と ControlType が重複しないように指定する必要があります。 ただし同一の項目が含まれている 2 つの一覧を使う場合は、1 つのウィンドウ内で重複する名前を使うことができます。 この場合、一覧に含まれる各項目には同じ Name と ControlTypes が指定されている必要があります。

### <a name="impact"></a>影響

同じ UIA の親を持つ 2 つの要素に、同じ Name と ControlType が設定されている場合、それらの要素を提示されたユーザーが要素の違いを区別できない可能性があります。

### <a name="cause"></a>原因

同じ UIA の親を持つ複数の UIA 要素に、同じ Name と ControlType が指定されています。

### <a name="solution"></a>解決策

XAML で AutomationProperties.Name を使用して名前を設定します。 一覧でこの問題が頻繁に発生する場合は、バインディングを使って AutomationProperties.Name の値をデータ ソースにバインドします。


