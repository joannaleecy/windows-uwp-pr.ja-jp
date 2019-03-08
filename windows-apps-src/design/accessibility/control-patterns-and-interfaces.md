---
Description: Microsoft UI オートメーションのコントロール パターン、それらにアクセスするためにクライアントが使うクラス、それらを実装するためにプロバイダーが使うインターフェイスを紹介します。
ms.assetid: 2091883C-5D0C-44ED-936A-709022926A42
title: コントロール パターンとインターフェイス
label: Control patterns and interfaces
template: detail.hbs
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 87afe086ca28e27a39f5508a2bea5ea9fcb1c6a5
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57597237"
---
# <a name="control-patterns-and-interfaces"></a>コントロール パターンとインターフェイス  



Microsoft UI オートメーションのコントロール パターン、それらにアクセスするためにクライアントが使うクラス、それらを実装するためにプロバイダーが使うインターフェイスを紹介します。

このトピックの表は、Microsoft UI オートメーションのコントロール パターン、 それらにアクセスするために UI オートメーション クライアントが使うクラス、それらを実装するために UI オートメーション プロバイダーが使うインターフェイスを示しています。 **Control pattern** 列には、[**Control Pattern Availability Property Identifiers**](https://msdn.microsoft.com/library/windows/desktop/Ee671199) に一覧表示される定数値として、UI オートメーション クライアントから見たパターン名が表示されます。 UI オートメーション プロバイダーの側から見ると、これらのパターンは [**PatternInterface**](https://msdn.microsoft.com/library/windows/apps/BR242496) の定数名です。 **"クラス プロバイダー インターフェイス"** 列には、カスタム XAML コントロールにこのパターンを提供するためにプロバイダーが実装するインターフェイスの名前が表示されます。

コントロール パターンを公開してインターフェイスを実装するカスタム オートメーション ピアの実装方法について詳しくは、「[カスタム オートメーション ピア](custom-automation-peers.md)」をご覧ください。

コントロール パターンを実装する場合は、実装のために使う UI フレームワークにかかわらず、コントロール パターンに対するクライアントの想定について UI オートメーション プロバイダーのドキュメントもご覧ください。 一般的な UI オートメーション プロバイダーのドキュメントには、ピアの実装方法およびそのパターンを正しくサポートする方法に関連する情報が含まれます。 実装するパターンについては、「[UI オートメーション コントロール パターンの実装](https://msdn.microsoft.com/library/windows/desktop/Ee671292)」をご覧ください。

| コントロール パターン | クラス プロバイダー インターフェイス | 説明 |
|-----------------|--------------------------|-------------|
| **注釈** | [**IAnnotationProvider**](https://msdn.microsoft.com/library/windows/apps/Hh738493) | ドキュメント内の注釈のプロパティを公開するために使われます。 |
| **ドッキング ステーション** | [**IDockProvider**](https://msdn.microsoft.com/library/windows/apps/BR242565) | ドッキング コンテナーにドッキングできるコントロールに使われます  (ツール バー、ツール パレットなど)。 |
| **ドラッグ** | [**IDragProvider**](https://msdn.microsoft.com/library/windows/apps/Hh750322) | ドラッグ可能なコントロール、またはドラッグ可能な項目を含むコントロールをサポートするために使われます。 |
| **DropTarget** | [**IDropTargetProvider**](https://msdn.microsoft.com/library/windows/apps/Hh750327) | ドラッグ アンド ドロップ操作のターゲットにできるコントロールをサポートするために使われます。 |
| **ExpandCollapse** | [**IExpandCollapseProvider**](https://msdn.microsoft.com/library/windows/apps/BR242568) | コンテンツの表示拡大のために展開し、コンテンツの非表示のために折りたたむコントロールをサポートするために使われます。 |
| **グリッド** | [**IGridProvider**](https://msdn.microsoft.com/library/windows/apps/BR242578) | サイズ指定、指定したセルへの移動などのグリッド機能をサポートするコントロールに使われます。 グリッドはレイアウトを提供しますがコントロールではないため、グリッド自体はこのパターンを実装しません。 |
| **GridItem** | [**IGridItemProvider**](https://msdn.microsoft.com/library/windows/apps/BR242572) | グリッド内のセルを持つコントロールに使われます。 |
| **呼び出す** | [**IInvokeProvider**](https://msdn.microsoft.com/library/windows/apps/BR242582) | 呼び出すことができるコントロールに使われます ([**Button**](https://msdn.microsoft.com/library/windows/apps/BR209265) など)。 |
| **ItemContainer** | [**IItemContainerProvider**](https://msdn.microsoft.com/library/windows/apps/BR242583) | 仮想化されたリストなどのコンテナー内の要素をアプリが見つけられるようにします。 |
| **MultipleView** | [**IMultipleViewProvider**](https://msdn.microsoft.com/library/windows/apps/BR242585) | 同じ情報、データ、または子のセットの複数の表現を切り替えることができるコントロールに使われます。 |
| **Objectmodel です。** | [**IObjectModelProvider**](https://msdn.microsoft.com/library/windows/apps/Dn251815) | ドキュメントの基になるオブジェクト モデルにポインターを公開するために使われます。 |
| **RangeValue** | [**IRangeValueProvider**](https://msdn.microsoft.com/library/windows/apps/BR242590) | 適用できる値の範囲を持つコントロールに使われます。 たとえば、年を含むスピン ボックス コントロールの値の範囲は 1900 年から現在の年までになり、月を提示するスピン ボックス コントロールの値の範囲は 1 ～ 12 になります。 |
| **スクロール** | [**IScrollProvider**](https://msdn.microsoft.com/library/windows/apps/BR242601) | スクロールできるコントロールに使われます  (表示可能領域に表示しきれない情報がある場合にアクティブになるスクロール バーを持つコントロールなど)。 |
| **ScrollItem** | [**IScrollItemProvider**](https://msdn.microsoft.com/library/windows/apps/BR242599) | スクロールするリストの個々の項目を持つコントロールに使われます  (コンボ ボックス コントロールなどのスクロール リストの個々の項目を持つリスト コントロールなど)。 |
| **選択** | [**ISelectionProvider**](https://msdn.microsoft.com/library/windows/apps/BR242616) | 選択コンテナー コントロールに使われます  ([**ListBox**](https://msdn.microsoft.com/library/windows/apps/BR242868)、[**ComboBox**](https://msdn.microsoft.com/library/windows/apps/BR209348) など)。 |
| **SelectionItem** | [**ISelectionItemProvider**](https://msdn.microsoft.com/library/windows/apps/BR242610) | リスト ボックス、コンボ ボックスなどの選択コンテナー コントロールの個々の項目に使われます。 |
| **スプレッドシート** | [**ISpreadsheetProvider**](https://msdn.microsoft.com/library/windows/apps/Dn251821) | スプレッドシートまたは他のグリッド ベースのドキュメントのコンテンツを公開するために使われます。 |
| **SpreadsheetItem** | [**ISpreadsheetItemProvider**](https://msdn.microsoft.com/library/windows/apps/Dn251817) | スプレッドシートまたは他のグリッド ベースのドキュメントでセルのプロパティを公開するために使われます。 |
| **スタイル** | [**IStylesProvider**](https://msdn.microsoft.com/library/windows/apps/Dn251823) | 特定のスタイル、塗りつぶしの色、塗りつぶしパターン、または図形を含む UI 要素を記述するために使われます。 |
| **SynchronizedInput** | [**ISynchronizedInputProvider**](https://msdn.microsoft.com/library/windows/apps/Dn279198) | UI オートメーション クライアント アプリでマウスまたはキーボード入力を特定の UI 要素に転送することを可能にします。 |
| **テーブル** | [**ITableProvider**](https://msdn.microsoft.com/library/windows/apps/BR242623) | グリッドとヘッダー情報を持つコントロールに使われます  (表形式のカレンダー コントロールなど)。 |
| **TableItem** | [**ITableItemProvider**](https://msdn.microsoft.com/library/windows/apps/BR242620) | 表の項目に使われます。 |
| **テキスト** | [**ITextProvider**](https://msdn.microsoft.com/library/windows/apps/BR242627) | 編集コントロールやテキスト情報を表示するドキュメントに使われます。 また、「[**ITextRangeProvider**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.provider.itextrangeprovider)」および「[**ITextProvider2**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.provider.itextprovider2)」もご覧ください。 |
| **TextChild** | [**ITextChildProvider**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.provider.itextchildprovider) | **Text** コントロール パターンをサポートする、要素に最も近い祖先にアクセスするために使われます。 |
| **TextEdit** | 使用できるマネージ クラスがありません | テキストを変更するコントロール (たとえば、自動修正の実行、入力方式エディター (IME) を通じた入力合成の有効化を行うコントロールなど) へのアクセスを提供します。 |
| **TextRange** | [**ITextRangeProvider**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.provider.itextrangeprovider) | [  **ITextProvider**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.provider.itextprovider) を実装するテキスト コンテナー内の一続きのテキストへのアクセスを提供します。 [  **ITextRangeProvider2**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.provider.itextrangeprovider2) もご覧ください。 |
| **トグル** | [**IToggleProvider**](https://msdn.microsoft.com/library/windows/apps/BR242653) | 状態を切り替えることができるコントロールに使われます  ([**CheckBox**](https://msdn.microsoft.com/library/windows/apps/BR209316)、オン/オフを切り替えることのできるメニュー項目など)。 |
| **変換** | [**ITransformProvider**](https://msdn.microsoft.com/library/windows/apps/BR242656) | サイズ変更、移動、回転が可能なコントロールに使われます。 デザイナー、フォーム、グラフィカル エディター、描画アプリなどでよく使われます。 |
| **値** | [**IValueProvider**](https://msdn.microsoft.com/library/windows/apps/BR242663) | 値の範囲をサポートしないコントロールの値をクライアントが取得または設定できるようにします。 |
| **VirtualizedItem** | [**IVirtualizedItemProvider**](https://msdn.microsoft.com/library/windows/apps/BR242668) | 仮想化されていて、UI オートメーション要素として完全にアクセスできるようにする必要があるコンテナー内の項目を公開します。 |
| **ウィンドウ** | [**IWindowProvider**](https://msdn.microsoft.com/library/windows/apps/BR242670) | Windows に固有の情報の基本概念、Microsoft Windows オペレーティング システムを公開します。 たとえば、子ウィンドウ、ダイアログなどのコントロールはウィンドウです。 |

> [!NOTE]
> 既存の XAML コントロールで、必ずしもこれらすべてのパターンの実装が見られるわけではありません。 一部のパターンでは、パターンの一般的な UI オートメーション フレームワーク定義との等価性を維持し、そのパターンをサポートするための純粋なカスタム実装を必要とするオートメーション ピア シナリオに対応することだけを目的としてインターフェイスが使用されている場合があります。

> [!NOTE]
> Windows Phone ストア アプリでは、ここに示されているすべての UI オートメーションのコントロール パターンがサポートされているわけではありません。 **Annotation**、**Dock**、**Drag**、**DropTarget**、**ObjectModel** がサポートされていないパターンの例です。

<span id="related_topics"/>

## <a name="related-topics"></a>関連トピック  
* [カスタム オートメーション ピア](custom-automation-peers.md)
* [アクセシビリティ](accessibility.md) 
