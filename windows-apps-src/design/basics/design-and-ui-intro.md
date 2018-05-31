---
author: serenaz
Description: An overview of the universal design features that are included in every UWP app to help you build apps that scale beautifully across a range of devices.
title: ユニバーサル Windows プラットフォーム (UWP) アプリ設計の概要 (Windows アプリ)
ms.assetid: 50A5605E-3A91-41DB-800A-9180717C1E86
ms.author: sezhen
ms.date: 12/13/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: d0527866777c7b5dbbc10697bb313d664f4555fa
ms.sourcegitcommit: 91511d2d1dc8ab74b566aaeab3ef2139e7ed4945
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/30/2018
ms.locfileid: "1817280"
---
#  <a name="introduction-to-uwp-app-design"></a>UWP アプリ設計の概要

ユニバーサル Windows プラットフォーム (UWP) の設計ガイダンスは、美しく洗練されたアプリを設計および構築するのに役立つリソースです。

これは規範的な規則の一覧ではなく、進化する [Fluent Design System](../fluent-design-system/index.md)、およびアプリ構築コミュニティのニーズに適応するように設計された生きたドキュメントです。

この記事では、あらゆる UWP アプリに含まれているユニバーサル デザイン機能の概要を説明します。これらの機能により、さまざまなデバイス間で美しくスケーリングされるユーザー インターフェイス (UI) を構築できます。

## <a name="video-summary"></a>ビデオの概要

> [!VIDEO https://channel9.msdn.com/Blogs/One-Dev-Minute/Designing-Universal-Windows-Platform-apps/player]

## <a name="effective-pixels-and-scaling"></a>有効ピクセルとスケーリング

UWP アプリは、[UWP アプリをサポートするすべてのデバイス](../devices/index.md)で読みやすく、操作しやすいように、コントロール、フォント、およびその他の UI 要素のサイズを自動的に調整します。

デバイスでアプリを実行するとき、システムでは、UI 要素を画面に表示する方法を正規化するアルゴリズムを使います。 このスケーリング アルゴリズムでは、視聴距離と画面の密度 (ピクセル/インチ) を考慮して、体感的なサイズを最適化します (物理的なサイズではありません)。 スケーリング アルゴリズムによって、10 フィート離れた Surface Hub における 24 ピクセルのフォントが、数インチ離れた 5 インチ サイズの電話における 24 ピクセルのフォントと同じようにユーザーに読みやすい状態で表示されます。

![さまざまなデバイスの視聴距離](images/1910808-hig-uap-toolkit-03.png)

スケーリング システムのしくみのため、UWP アプリをデザインするときには、実際の物理ピクセルではなく、有効ピクセルでデザインすることになります。 有効ピクセル (epx) は仮想的な測定単位で、画面の密度とは無関係にレイアウトのサイズと間隔を表すために使用されます。 (ガイドラインでは、epx、ep、および px を区別しないで使用しています。)

設計時には、ピクセル密度と実際の画面解像度を無視できます。 その代わり、サイズ クラスの有効な解像度 (有効ピクセル単位の解像度) が向上するように設計します (詳しくは、「[画面のサイズとブレークポイント](../layout/screen-sizes-and-breakpoints-for-responsive-design.md)」をご覧ください)。

> [!TIP]
> イメージ編集プログラムで画面のモックアップを作成するときは、DPI を 72 に設定し、画像サイズを、対象のサイズ クラスで有効な解像度に設定します サイズ クラスと有効な解像度の一覧については、「[画面のサイズとブレークポイント](../layout/screen-sizes-and-breakpoints-for-responsive-design.md)」をご覧ください。


## <a name="layout"></a>レイアウト

### <a name="margins-spacing-and-positioning"></a>余白、間隔、および配置 
![グリッド](images/4epx.png)

システムによるアプリの UI のスケーリングは、4 の倍数単位で行われます。

そのため、UI 要素のサイズ、余白、および位置は、**必ず 4 epx の倍数になります**。 結果として、ピクセル全体で調整することにより最適なレンダリングが得られます。 UI 要素に鮮明で鋭いエッジがあることも保証されます。 

この要件はテキストには必要ありません。テキストのサイズと位置に制限はありません。 テキストを他の UI 要素と揃える方法のガイダンスについては、「[UWP 文字体裁ガイド](../style/typography.md)」をご覧ください。

![グリッドでのスケーリング](images/epx-4pixelgood.png)

### <a name="layout-patterns"></a>レイアウト パターン

![一般的なレイアウト パターン](images/page-components.png)

ユーザー インターフェイスは、次の 3 種類の要素で構成されます。 
1. **ナビゲーション要素**は、表示するコンテンツをユーザーが選択できるようにします。 「[ナビゲーションの基本](navigation-basics.md)」をご覧ください。
2. **コマンド要素**は、操作、保存、コンテンツの共有などの操作を開始します。 「[コマンドの基本](commanding-basics.md)」をご覧ください。
3. **コンテンツ要素**は、アプリのコンテンツを表示します。 「[コンテンツの基本](content-basics.md)」をご覧ください。

### <a name="adaptive-behavior"></a>アダプティブ動作
![電話とデスクトップのアダプティブ動作](../controls-and-patterns/images/patterns_masterdetail.png)

アプリの UI はすべての Windows デバイスで読みやすく使用可能ですが、特定のデバイスや画面サイズ向けにアプリの UI をカスタマイズすることもできます。 詳しいガイダンスについては、「[画面のサイズとブレークポイント](../layout/screen-sizes-and-breakpoints-for-responsive-design.md)」と「[レスポンシブ デザイン テクニック](../layout/responsive-design.md)」をご覧ください。

## <a name="type"></a>書体

既定では、UWP アプリは **Segoe UI** フォントを使用します。UWP 書体見本には、すべての表示サイズで最も効率的なアプローチが得られるように、7 つのクラスの文字体裁が含まれています。 

![書体見本](images/type-ramp.png)

書体見本について詳しくは、「[UWP 文字体裁ガイド](../style/typography.md)」をご覧ください。 アプリでさまざまなレベルの UWP 書体見本を使用する方法については、「[テーマ リソース](../controls-and-patterns/xaml-theme-resources.md#the-xaml-type-ramp)」をご覧ください。

## <a name="color"></a>色

色を使うことで、ユーザーに直感的に情報を伝えることができます。 対話的に通知したり、ユーザーの操作にフィードバックを返したり、状態情報を伝えたり、インターフェイスに連続感を与えたりするために色を使用できます。 

Windows 10 では、シェルと UWP アプリ全体に適用される、48 色の共有ユニバーサル カラー パレットが提供されます。 

![ユニバーサル windows カラー パレット](images/colors.png)

システムは、システムのアクセント カラーを使用して UWP アプリに自動的に色を適用します。 ユーザーが [設定] でカラー パレットからアクセント カラーを選択すると、その色がシステム テーマの一部として表示されます。 ユーザーの基本設定によっては、スタート画面、スタート タイル、タスク バー、およびタイトル バーにもシステムのアクセント カラーを表示できます。 

![設定でアクセント カラーを選択](images/selectcolor.png)

UWP アプリ内では、コモン コントロール内のハイパーリンクと選択した状態にシステムのアクセント カラーが反映されます。

![コントロールでのシステムのアクセント カラー](images/accentcolor.png)

UWP アプリでは、[軽量なスタイル設定](../controls-and-patterns/xaml-styles.md#lightweight-styling)を使用するか、[カスタム コントロール](../controls-and-patterns/control-templates.md)を作成することで、コントロールでの表示からシステムのアクセント カラーを上書きできます。

UWP アプリでの色の使用に関するその他のガイダンスについては、[色](../style/color.md)の記事をご覧ください。

### <a name="themes"></a>テーマ

ユーザーは、淡色テーマ、濃色テーマ、またはハイ コントラストのテーマから選択できます。 ユーザーのテーマの優先順位に基づいてアプリの外観を変更するか、無効にするかを選択できます。

淡色テーマは、生産性向上が必要なタスクや読み取り作業に最適です。

濃色テーマを使用すると、メディアを中心とするアプリや多数のビデオや画像が含まれるシナリオで、コンテンツのコントラストを上げることができます。 これらのシナリオでは、主な作業は読み取りより映画の視聴であり、低光量の周囲条件下で行われると考えられます。

![淡色テーマと濃色テーマで表示された電卓](images/light-dark.png)

ハイ コントラスト テーマは、少ない数のコントラスト カラーで構成されるパレットを使い、インターフェイスを見やすくします。
![淡色テーマと黒のハイ コントラスト テーマで表示された電卓。](../accessibility/images/high-contrast-calculators.png)


アプリでのテーマと UWP 色見本の使用について詳しくは、「[テーマ リソース](../controls-and-patterns/xaml-theme-resources.md)」をご覧ください。

## <a name="icons"></a>アイコン
![アイコン](images/icons.png)

アイコンは日常生活で染み込んだ視覚言語です。 アイコンを使うと、視覚的に説得力のある方法で概念や操作を表すことができ、画面領域を節約できます。アイコンは、デジタル ライフのナビゲーターとして機能します。 

すべての UWP アプリは、[Segoe MDL2 フォント](../style/segoe-ui-symbol-font.md)でアイコンにアクセスできます。 これらのアイコンは定着した形を使用しており、一般的で誰にでも簡単に識別しやすいものですが、片手で描いたように感じられる現代的な形に更新されています。

独自のアイコンを作成する方法については、「[UWP アプリのアイコン](../style/icons.md)」をご覧ください。

## <a name="tiles"></a>タイル
![スタート メニューのタイル](images/tiles.png)

タイルは [スタート] メニューに表示され、アプリで何が行われるのかを簡単に示します。 タイルのパワーは、背後にあるコンテンツ、および提供するインテリジェンスと技術によるものです。 

UWP アプリには 4 つのタイル サイズ (小、中、横長、大) があり、アプリのアイコンと ID でカスタマイズできます。 UWP アプリのタイルのデザインに関するガイダンスについては、「[タイルとアイコン アセットのガイドライン](../shell/tiles-and-notifications/app-assets.md)」をご覧ください。

## <a name="controls"></a>コントロール
![ボタン コントロール](images/1910808-hig-uap-toolkit-01.png)

UWP には、すべての Windows デバイスで適切に動作することが保証されている一連のコモン コントロールが用意されています。 これらのコントロールには、ボタンやテキスト要素などの単純なコントロールから、一連のデータとテンプレートからリストを生成する高度なコントロールまで、すべてのものが含まれます。

UWP コントロールは、システム テーマとアクセント カラーを自動的に反映し、すべての入力の種類に対応し、すべてのデバイスに合わせて拡大縮小されます。 また、これらは高度にカスタマイズでき、コントロールの前景色を変更することも、外観を完全にカスタマイズすることもできます。 

UWP コントロールとコントロールに基づいて作成できるパターンの全一覧については、「[コントロールとパターン](../controls-and-patterns/index.md)」セクションをご覧ください。

## <a name="input"></a>入力
![入力](../input/images/input-interactions/icons-inputdevices03.png)

UWP アプリではスマート操作が使用されます。 クリックの発生元がマウスか、スタイラスか、指によるタップかを認識または定義しなくても、クリック操作に対応したデザインを行うことができます。 ただし、[特定の入力モードやデバイス](../input/input-primer.md)向けにアプリを設計することもできます。

## <a name="accessibility"></a>アクセシビリティ
![包括的な設計の担当者](images/inclusive.png)

最後に重要な点として、アクセシビリティの目的は、アプリのエクスペリエンスをすべてのユーザーに開かれたものにすることです。 障碍のある人だけでなく、すべての人に関係します。 すべての人が、本当に包括的なユーザー エクスペリエンスの恩恵を受けます。すべてのユーザーに対してアプリを使いやすくする方法については、「[UWP アプリの操作性](../usability/index.md)」をご覧ください。 視覚障碍、聴覚障碍、運動障碍を持つユーザーに関して、「[アクセシビリティ機能](../accessibility/accessibility-overview.md)」も検討してください。 

アクセシビリティが最初から設計に組み込まれている場合は、[アプリをアクセシビリティ対応にする](../accessibility/accessibility-in-the-store.md)ことにほとんど時間と労力がかかりません。

## <a name="tools-and-design-toolkits"></a>ツールと設計ツールキット
基本的な設計機能がわかったので、UWP アプリの設計を開始しましょう。

設計プロセスで役立つさまざまなツールが用意されています。

* [設計ツールキットのページ](../downloads/index.md)をご覧ください。XD、Illustrator、Photoshop、Framer、Sketch の各ツールキット、および追加の設計ツールやフォントのダウンロードが提供されています。 

* コンピューターを設定して UWP アプリのコードを記述できるようにするには、「[作業の開始と準備](../../get-started/get-set-up.md)」の記事をご覧ください。 

* UWP の UI を実装する方法については、エンド ツー エンドの「[サンプル UWP アプリ](https://developer.microsoft.com/windows/samples)」をご覧ください。

## <a name="next-fluent-design-system"></a>次: Fluent Design System
Fluent Design (Microsoft のデザイン システム) の背後にある原則や、UWP アプリに組み込むことができる多くの機能について確認する場合は、引き続き「[Fluent Design System](../fluent-design-system/index.md)」をご覧ください。