---
author: Karl-Bridge-Microsoft
Description: Ink tools described
title: インク コントロール
label: Inking Controls
template: detail.hbs
ms.author: kbridge
ms.date: 05/19/2017
ms.topic: article
keywords: Windows 10, UWP
ms.assetid: 97eae5f3-c16b-4aa5-b4a1-dd892cf32ead
ms.localizationpriority: medium
ms.openlocfilehash: ed358f88470dfe1ba1c48cd3daf1ed54135ed987
ms.sourcegitcommit: 753e0a7160a88830d9908b446ef0907cc71c64e7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/29/2018
ms.locfileid: "5743091"
---
# <a name="inking-controls"></a>インク コントロール



ユニバーサル Windows プラットフォーム (UWP) アプリでの手書き入力を容易にする、[InkCanvas](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inkcanvas.aspx) と [InkToolbar](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbar.aspx) という 2 つのコントロールがあります。

InkCanvas コントロールは、インク ストローク (色と太さの既定の設定を使用) か消去ストロークのいずれかとしてペン入力をレンダリングします。 このコントロールは透明なオーバーレイで、インク ストロークの既定のプロパティを変更するための組み込みの UI は含まれていません。

> [!NOTE]
> InkCanvas は、マウス入力とタッチ入力の両方に似たような機能をサポートするように構成できます。

InkCanvas コントロールにはインク ストロークの既定の設定を変更するためのサポートは含まれていないため、InkToolbar コントロールと組み合わせることができます。 InkToolbar には、関連付けられた InkCanvas のインク関連機能をアクティブ化する、カスタマイズと拡張が可能なボタンのコレクションが含まれています。

既定では、InkToolbar には、描画、消去、強調表示、ルーラー表示のボタンが含まれています。 機能に応じて、インクの色、ストロークの太さ、すべてのインクの消去など、他の設定やコマンドがポップアップに表示されます。

> [!NOTE]
> InkToolbar は、ペン入力とマウス入力をサポートしていますが、タッチ入力を認識するように構成することもできます。

<img src="images/ink-tools-invoked-toolbar.png" width="300" alt="InkToolbar palette flyout">

> **重要な API**: [InkCanvas クラス](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inkcanvas.aspx)、[InkToolbar クラス](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbar.aspx)、[InkPresenter クラス](https://msdn.microsoft.com/library/windows/apps/windows.ui.input.inking.inkpresenter.aspx)、[Windows.UI.Input.Inking](https://msdn.microsoft.com/library/windows/apps/br208524)


## <a name="is-this-the-right-control"></a>適切なコントロールの選択

ユーザーにインク設定を提供せずに、アプリで基本的な手書き入力機能を有効にする必要がある場合、InkCanvas を使います。

既定では、ストロークはペン先 (太さ 2 ピクセルの黒のボールペン) を使うときはインクとしてレンダリングされ、消しゴム ボタンを使うときは消しゴムとしてレンダリングされます。 消しゴム ボタンがない場合は、ペン先からの入力を消去ストロークとして処理するように InkCanvas を構成できます。

インク機能をアクティブ化し、ストロークのサイズ、色、ペン先の形状などの基本的なインクのプロパティを設定するための UI を提供するには、InkCanvas と InkToolbar を組み合わせます。

> [!NOTE] 
> InkCanvas でのインク ストロークのレンダリングに対する幅広いカスタマイズについては、基になる [InkPresenter](https://msdn.microsoft.com/library/windows/apps/windows.ui.input.inking.inkpresenter.aspx) オブジェクトを使ってください。

## <a name="examples"></a>例

<table>
<th align="left">XAML コントロール ギャラリー<th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックして<a href="xamlcontrolsgallery:/item/InkCanvas">アプリを開き、InkCanvas の動作を確認</a>してください。</p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics">ソース コード (GitHub) を入手する</a></li>
    </ul>
</td>
</tr>
</table>

**Microsoft Edge**

Microsoft Edge では、**Web ノート**に InkCanvas と InkToolbar を使います。  
![InkCanvas は Microsoft Edge で手書き入力するために使います。](images/ink-tools-edge.png)

**Windows Ink ワークスペース**

InkCanvas と InkToolbar は、**Windows Ink ワークスペース**の**スケッチパッド**と**画面スケッチ**の両方にも使われます。  
![Windows Ink ワークスペースの InkToolbar](images/ink-tools-ink-workspace.png)

## <a name="create-an-inkcanvas-and-inktoolbar"></a>InkCanvas と InkToolbar を作成する

アプリに InkCanvas を追加するには、次に示す 1 行のマークアップが必要です。

```xaml
<InkCanvas x:Name=“myInkCanvas”/>
```

> [!NOTE]
> InkPresenter 使った InkCanvas のカスタマイズについて詳しくは、「["UWP アプリのペン操作とスタイラス操作"](http://windowsstyleguide/input/pen-and-stylus-interactions/)」をご覧ください。

InkToolbar コントロールは、InkCanvas と組み合わせて使う必要があります。 InkToolbar (組み込みのすべてのツールが含まれています) をアプリに組み込むには、さらに次の 1 行のマークアップを追加する必要があります。

 ```xaml
<InkToolbar TargetInkCanvas=“{x:Bind myInkCanvas}”/>
 ```

これにより、次のような InkToolbar が表示されます。
<img src="images/ink-tools-uninvoked-toolbar.png" width="250" alt="Basic InkToolbar">

### <a name="built-in-buttons"></a>組み込みのボタン

InkToolbar には、次に示す組み込みのボタンが含まれています。

**ペン**

- ボールペン - 丸いペン先で単色の不透明なストロークを描画します。 ストロークのサイズは、感知された筆圧に依存します。
- 鉛筆 - 丸いペン先で、輪郭がぼやけている、テクスチャが適用された、半透明のストローク (階層化された網かけ効果に役立ちます) を描画します。 ストロークの色 (濃さ) は、感知された筆圧に依存します。
- 蛍光ペン – 四角形のペン先で半透明のストロークを描画します。

各ペンのポップアップで、カラー パレットとサイズの属性 (最小、最大、既定) の両方をカスタマイズできます。

**ツール**

- 消しゴム – タッチされたインク ストロークを削除します。 消しゴムのストロークの下にある部分だけではなく、インク ストローク全体が削除されることに注意してください。

**トグル**

- ルーラー – ルーラーの表示/非表示を切り替えます。 ルーラーの端付近で描画すると、インク ストロークがルーラーにスナップされます。  
 ![InkToolbar に関連付けられたルーラーの外観](images/inking-tools-ruler.png)

これは既定の構成ですが、お使いのアプリの InkToolbar にどの組み込みのボタンが含めるかを完全に制御できます。

### <a name="custom-buttons"></a>カスタム ボタン

InkToolbar は、次のような 2 つの異なるボタンの種類のグループで構成されます。

1. "ツール" ボタンのグループ。組み込みの描画ボタン、消去ボタン、強調表示ボタンが含まれます。 カスタム ペンとカスタム ツールはここに追加されます。
> [!NOTE]
> 機能の選択は相互に排他的です。

2. "トグル" ボタンのグループ。組み込みのルーラー ボタンが含まれます。 カスタム トグルはここに追加されます。
> [!NOTE]
> 機能は相互に排他的ではないので、他のアクティブなツールと同時に使うことができます。

お使いのアプリケーションと必要なインク機能によって異なりますが、InkToolbar には次のボタン (カスタムの手書き入力機能にバインドされます) を追加できます。

- カスタム ペン – インクのカラー パレットやペン先のプロパティ (形状、回転、サイズなど) がホスト アプリで定義されるペン。
- カスタム ツール – ホスト アプリで定義されるペン不使用ツール。
- カスタム トグル – アプリで定義された機能の状態をオンまたはオフに設定します。 オンにすると、機能はアクティブなツールと連携して動作します。

> [!NOTE]
> 組み込みのボタンの表示順序を変更することはできません。 既定の表示順序は、ボールペン、鉛筆、蛍光ペン、消しゴム、ルーラーです。 カスタム ペンは最後の既定のペンに追加され、カスタム ツール ボタンは最後のペン ボタンと消しゴム ボタンの間に追加され、カスタム トグル ボタンはルーラー ボタンの後に追加されます  (カスタム ボタンは、指定されている順序で追加されます)。

InkToolbar はトップ レベルの項目にすることもできますが、通常は "手書き入力" ボタンまたはコマンドを使って公開されます。 Segoe MLD2 アセット フォントの EE56 グリフをトップ レベルのアイコンとして使うことをお勧めします。

## <a name="inktoolbar-interaction"></a>InkToolbar の操作

組み込みのすべてのペン ボタンとツール ボタンには、インクのプロパティと、ペン先の形状とサイズを設定できるポップアップ メニューが含まれています。 ポップアップがあることを示すために、ボタンには "拡張グリフ"  ![InkToolbar グリフ](images/ink-tools-glyph.png)  が表示されます。

ポップアップは、アクティブなツールのボタンが再選択されたときに表示されます。 色やサイズが変更されると、ポップアップは自動的に閉じられ、手書き入力を再開できます。 カスタム ペンやカスタム ツールでは、既定のポップアップを使うことも、カスタム ポップアップを指定することもできます。

また、消しゴムには **[すべてのインクのデータを消去]** コマンドを提供するポップアップがあります。  
![消しゴムのポップアップが呼び出された InkToolbar](images/ink-tools-erase-all-ink.png)

 カスタマイズと拡張について詳しくは、[SimpleInk のサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/SimpleInk)をご覧ください。

## <a name="dos-and-donts"></a>推奨と非推奨

- InkCanvas と手書き入力全般は、アクティブなペンを通じて最適なエクスペリエンスを実現します。 ただし、アプリで必要な場合は、マウスとタッチ (パッシブ ペンを含む) の入力による手書き入力をサポートすることをお勧めします。
- 手書き入力の基本的な機能と設定を提供するには、InkToolbar コントロールと InkCanvas を使います。 InkCanvas と InkToolbar は共に、プログラムでカスタマイズできます。
- InkToolbar と手書き入力全般は、アクティブなペンを通じて最適なエクスペリエンスを実現します。 ただし、アプリで必要な場合は、マウスやタッチによる手書き入力をサポートできます。
- タッチ入力による手書き入力をサポートする場合、トグル ボタンに Segoe MLD2 アセット フォントの ED5F アイコンを使うと共に、"タッチによる手書き" というヒントを表示することをお勧めします。
- ストローク選択を提供する場合は、「選択ツール」ツールチップを使用して、ツール ボタンの Segoe MLD2 アセット フォントの EF20 アイコンを使用することをお勧めします。
- 複数の InkCanvas を使う場合、1 つの InkToolbar を使ってキャンバス間の手書き入力を制御することをお勧めします。
- 最高のパフォーマンスを得るには、既定のツールとカスタム ツールの両方にカスタム ポップアップを作成するのではなく、既定のポップアップを変更することをお勧めします。

## <a name="get-the-sample-code"></a>サンプル コードを入手する

- [SimpleInk のサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/SimpleInk) - InkCanvas コントロールと InkToolbar コントロールのカスタマイズ機能と拡張機能に関する 8 個のシナリオを示しています。 各シナリオでは、一般的な手書き入力の状況とコントロールの実装に関する基本的なガイダンスが提供されています。
- [ComplexInk のサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/ComplexInk) - 高度な手書き入力のシナリオを示しています。
- [XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - インタラクティブな形ですべての XAML コントロールを参照できます。

## <a name="related-articles"></a>関連記事

- [UWP アプリのペン操作とスタイラス操作](http://windowsstyleguide/input/pen-and-stylus-interactions/)
- [インク ストロークの認識](http://windowsstyleguide/input/convert-ink-to-text/)
- [インク ストロークの保存と取得](http://windowsstyleguide/input/save-and-load-ink/)
