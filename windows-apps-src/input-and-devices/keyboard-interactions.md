---
author: Karl-Bridge-Microsoft
Description: "アプリでハードウェア キーボードやソフトウェア キーボードからのキーボード操作に応答するには、キーボード イベント ハンドラーとクラス イベント ハンドラーの両方を使います。"
title: "キーボード操作"
ms.assetid: FF819BAC-67C0-4EC9-8921-F087BE188138
label: Keyboard interactions
template: detail.hbs
translationtype: Human Translation
ms.sourcegitcommit: 667228e10456ffbc64b7d0782d5a8bdc02f2f203
ms.openlocfilehash: 5ab84def6e73329f59d8ae6ef8be335d66ef4334

---

# キーボード操作


キーボード入力は、アプリのユーザー操作エクスペリエンスの中でも重要な部分です。 キーボードは、特定の障碍のあるユーザーや、キーボードを使った方がアプリを効率よく操作できると考えるユーザーにとって欠かせません。 たとえば、Tab キーと方向キーを使ってアプリ内を移動し、Space キーと Enter キーを使って UI 要素をアクティブ化し、キーボード ショートカットを使ってコマンドにアクセスできるようにする必要があります。  

![キーボードのヒーロー画像](images/input-patterns/input-keyboard-small.jpg)

**重要な API**

-   [**KeyDown**](https://msdn.microsoft.com/library/windows/apps/br208941)
-   [**KeyUp**](https://msdn.microsoft.com/library/windows/apps/br208942)
-   [**KeyRoutedEventArgs**](https://msdn.microsoft.com/library/windows/apps/hh943072)


適切に設計されたキーボード UI はソフトウェアのアクセシビリティの重要な要素であり、 視覚に障碍のあるユーザーや特定の運動障碍のあるユーザーによるアプリ内の移動や、その機能の操作を実現します。 このようなユーザーはマウスを操作できない場合があるため、代わりにさまざまな支援技術 (キーボード強化ツール、スクリーン キーボード、スクリーン拡大機能、スクリーン リーダー、音声入力ユーティリティなど) が不可欠になる可能性があります。

ユーザーはハードウェア キーボードと 2 つのソフトウェア キーボード (スクリーン キーボード (OSK) およびタッチ キーボード) を通じて、ユニバーサル アプリを操作できます。

スクリーン キーボード  
スクリーン キーボードは、物理的なキーボードの代わりに使うことができる視覚的なソフトウェア キーボードです。タッチ、マウス、ペン/スタイラス、またはその他のポインティング デバイスを通じてデータを入力します (タッチ スクリーンは必須ではありません)。 スクリーン キーボードは、物理的なキーボードが存在しないシステムや、運動障碍により一般的な物理入力デバイスを使うことができないユーザーのために用意されています。 スクリーン キーボードは、ハードウェア キーボードの機能のすべて、または少なくともほとんどをエミュレートします。

スクリーン キーボードは、[設定] &gt; [簡単操作] の [キーボード] ページから有効にすることができます。

**注**  スクリーン キーボードはタッチ キーボードよりも優先され、スクリーン キーボードが表示されている場合はタッチ キーボードは表示されません。

 

![スクリーン キーボード](images/input-patterns/osk.png)

<sup>スクリーン キーボード</sup>

タッチ キーボード  
タッチ キーボードは、タッチ入力でのテキスト入力に使われる、視覚的なソフトウェア キーボードです。 タッチ キーボードはテキスト入力専用であり (ハードウェア キーボードをエミュレートしません)、スクリーン キーボードに代わるものではありません。

デバイスに応じて、タッチ キーボードは、テキスト フィールドやその他の編集可能なテキスト コントロールがフォーカスを取得したとき、またはユーザーが**通知センター**で手動でタッチ キーボードを有効にしたときに表示されます。

![通知センターでのタッチ キーボードのアイコン](images/input-patterns/touch-keyboard-notificationcenter.png)

**注**  ユーザーは [設定] &gt; [システム] の **[タブレット モード]** 画面に移動して、[デバイスをタブレットとして使用すると、Windows のタッチ機能がより使いやすくなります] をオンにして、タッチ キーボードの自動表示を有効にすることができます。

 

テキスト入力コントロールへのフォーカスをプログラムで設定するアプリの場合、タッチ キーボードは呼び出されません。 これにより、ユーザーの直接的な操作による予期しない動作を回避できます。 ただし、プログラムによってキーボードがテキスト入力コントロール以外に移動されると、キーボードが自動的に非表示になります。

通常、ユーザーがフォームでコントロール間を移動している間は、タッチ キーボードは表示されたままです。 この動作は、フォーム内の他のコントロールの種類に基づいて異なります。

タッチ キーボードを使用するテキスト入力セッション中に、キーボードを閉じずにフォーカスを受け取ることができる非編集コントロールの一覧を次に示します。 ユーザーがこれらのコントロールとタッチ キーボードによるテキスト入力との間で何度も行き来することが考えられるため、UI の表示を不必要に切り替えてユーザーを混乱させることのないよう、タッチ キーボードは表示されたままになります。

-   チェック ボックス
-   コンボ ボックス
-   ラジオ ボタン
-   スクロール バー
-   ツリー
-   ツリー項目
-   メニュー
-   メニュー バー
-   メニュー項目
-   ツール バー
-   一覧
-   一覧項目

次に、タッチ キーボードのさまざまなモードの例を示します。 最初の画像は既定のレイアウトであり、2 つ目の画像は親指レイアウトです (一部の言語では利用できません)。

次に、タッチ キーボードのさまざまなモードの例を示します。 最初の画像は既定のレイアウトであり、2 つ目の画像は親指レイアウトです (一部の言語では利用できません)。
<table>
<tr>
    <td>**既定のレイアウト モードのタッチ キーボード:  **</td>
    <td>![既定のレイアウト モードのタッチ キーボード](images/touchkeyboard-standard.png)</td>
</tr>
<tr>
    <td>**拡張レイアウト モードのタッチ キーボード:  **</td>
    <td>![拡張レイアウト モードのタッチ キーボード](images/touchkeyboard-expanded.png)</td>
</tr>
<tr>
    <td>**既定の親指レイアウト モードのタッチ キーボード:  **</td>
    <td>![親指レイアウト モードのタッチ キーボード](images/touchkeyboard-thumb.png)</td>
</tr>
<tr>
    <td>**数字親指レイアウト モードのタッチ キーボード:  **</td>
    <td>![数字親指レイアウト モードのタッチ キーボード](images/touchkeyboard-numeric-thumb.png)</td>
</tr>
</table>


キーボード操作に成功すると、ユーザーはキーボードのみを使って基本のアプリ シナリオを実行できます。つまり、ユーザーはすべての対話型要素にアクセスし、既定の機能をアクティブにすることができます。 成功の度合いには、キーボード ナビゲーション、アクセシビリティ対応のアクセス キー、上級ユーザー用のアクセラレータ (ショートカット) キーなど、さまざまな要因が影響します。

**注**  タッチ キーボードでは、トグルや、ほとんどのシステム コマンドがサポートされません (「[パターン](#keyboard_command_patterns)」をご覧ください)。

## ナビゲーション


キーボードでコントロール (ナビゲーション要素を含む) を操作するには、そのコントロールがフォーカスを取得する必要があります。 コントロールにキーボード フォーカスを受け取る方法の 1 つは、そのコントロールにタブ ナビゲーションでアクセスできるようにすることです。 適切にデザインされたキーボード ナビゲーション モデルでは、ユーザーが迅速かつ効率的にアプリを移動して使用するための予測可能な論理タブ オーダーを提供します。

すべての対話的なコントロールには (グループ内のコントロールでなければ) タブ ストップがあり、ラベルなど非対話型のコントロールにはありません。

一連の関連するコントロールをコントロール グループとしてまとめ、1 つのタブ ストップを割り当てることもできます。 コントロール グループは、ラジオ ボタンなどのように、1 つのコントロールとして動作するコントロールのセットに使用されます。 コントロール数が多すぎて、Tab キーだけでは効率的に移動できない場合にも使用できます。 方向キー、Home、End、PageUp、PageDown を使うと、グループ内のコントロール間で入力フォーカスを移動できます (これらのキーを使用してコントロール グループの外に移動することはできません)。

最初のキーボード フォーカスは、アプリの起動時にユーザーが最初に直感的に操作する (または、その可能性が最も高い) 要素に設定する必要があります。 多くの場合、これはアプリのメイン コンテンツ ビューです。ユーザーはすぐに方向キーを使ってアプリ コンテンツのスクロールを開始できます。

最初のキーボード フォーカスは、ネガティブ (または破滅的) な結果を招く可能性のある要素に設定しないでください。 これにより、データの消失またはシステム アクセスの喪失を回避します。

コマンド、コントロール、コンテンツを順序付けし、最も重要なものをタブ オーダーと表示順序 (または視覚的な階層) の両方で最初に提示するようにしてください。 ただし実際の表示位置は、親レイアウト コンテナーと、レイアウトに影響する子要素の特定のプロパティに左右されることがあります。 特に、グリッド形式または表形式を使用しているレイアウトでは、読み取り順序がタブ オーダーとまったく異なる場合があります。 このことは必ずしも問題ではありませんが、タッチ可能な UI とキーボードからアクセス可能な UI の両方についてアプリの機能をテストする必要があります。

タブ オーダーは、可能な限り読み取り順序に従う必要があります。 これにより混乱を軽減できる可能性があります (ロケールと言語に依存します)。

キーボード ボタンを、アプリの適切な UI ("戻る" ボタンと "進む" ボタン) に関連付けてください。

アプリのスタート画面に戻る場合と重要なコンテンツ間を移動する場合に、できるだけ単純かつ容易に移動できるようにします。

コンポジット要素の子要素間で正しい内部ナビゲーションを実行するために、キーボード ショートカットとして方向キーを使います。 ツリー ビュー ノードに、展開折りたたみとノードのアクティブ化を処理するための別の子要素がある場合は、左右の方向キーを使って、キーボードの展開折りたたみ機能を提供します。 この動作は、プラットフォーム コントロールと一致します。

タッチ キーボードによって画面の大部分が見えなくなるため、ユニバーサル Windows プラットフォーム (UWP) では、ユーザーがフォームのコントロール間を移動するときに、フォーカスのある入力フィールドが見えるようにスクロールします。これには、現在ビューに表示されていないコントロールも含まれます。 カスタム コントロールでも、この動作をエミュレートする必要があります。

![タッチ キーボードが表示または非表示になっているフォーム](images/input-patterns/touch-keyboard-pan1.png)

場合によっては、画面にずっと表示されたままであることが必要な UI 要素もあります。 フォーム コントロールがパン領域に含まれ、重要な UI 要素が静的であるように UI を設計します。 次に例を示します。

![常に表示されている必要がある領域を含むフォーム](images/input-patterns/touch-keyboard-pan2.png)
## アクティブ化


コントロールは、現在フォーカスがあるかどうかにかかわらず、さまざまな方法でアクティブ化できます。

Space キー、Enter キー、Esc キー  
Space キーは、入力フォーカスのあるコントロールをアクティブ化します。 Enter キーは、既定のコントロールや入力フォーカスのあるコントロールをアクティブ化します。 既定のコントロールとは、初期フォーカスのあるコントロールまたは Enter キーにのみ応答するコントロール (通常は、入力フォーカスと共に変化します) を指します。 Esc キーは、メニューやダイアログなどの一時的な UI を終了します。

次に示す電卓アプリでは、Space キーを使用してフォーカスのあるボタンをアクティブ化し、Enter キーを "=" ボタンにロックして、Esc キーを "C" ボタンにロックします。

![電卓アプリ](images/input-patterns/calculator.png)

キーボード修飾子  
キーボード修飾子は、次のカテゴリに分類されます。


| カテゴリ | 説明 |
|----------|-------------|
| ショートカット キー | UI を使わずに、一般的な操作を実行します (**[保存]** に対応する "Ctrl + S" など)。 アプリの主な機能にキーボード ショートカットを実装します。 すべてのコマンドにショートカットがあるわけではありません。また、すべてのコマンドでショートカットが必要になるわけではありません。 |   
| アクセス キー/ホット キー | 表示される最上位のコントロールすべてに割り当てられます (**[ファイル]** メニューに対応する "Alt + F" など)。 アクセス キーでは、コマンドの呼び出しやコマンドのアクティブ化は行われません。 |
| アクセラレータ キー | 既定のシステム コマンドやアプリで定義されたコマンドを実行します (画面の取り込みに対応した "Alt + PrtScrn"、アプリの切り替えに対応した "Alt + Tab"、ヘルプに対応した "F1" など)。 アクセラレータ キーに関連付けるコマンドには、メニュー項目でなくてもかまいません。 |
| アプリケーション キー/メニュー キー | コンテキスト メニューを表示します。 |
| Windows キー/コマンド キー | **システム メニュー**、**ロック画面**、**デスクトップの表示** などのシステム コマンドをアクティブ化します。 |

アクセス キーとアクセラレータ キーは、Tab キーによるナビゲーションの代わりに、コントロールの直接操作をサポートします。
> コントロールには、固有ラベルがあるもの (コマンド ボタン、チェック ボックス、ラジオ ボタンなど) と、外部ラベルのあるもの (リスト ビューなど) があります。 外部ラベルのあるコントロールの場合、アクセス キーはラベルに割り当てられ、呼び出されると、対応コントロール内の要素または値にフォーカスを設定します。


次の例では、**Word** の **[ページ レイアウト]** タブのアクセス キーを示しています。

![Word の [ページ レイアウト] タブのアクセス キー](images/input-patterns/accesskeys-show.png)

ここで、[インデント] の [左] ボックスに対応するラベルに示されたアクセス キーを入力すると、このテキスト ボックスの値が強調表示されます。

![[インデント] の [左] ボックスに対応するラベルに示されたアクセス キーを入力すると、このテキスト フィールドの値が強調表示される](images/input-patterns/accesskeys-entered.png)

## ユーザビリティとアクセシビリティ


適切に設計されたキーボードの操作エクスペリエンスは、ソフトウェア アクセシビリティの重要な要素であり、 視覚に障碍のあるユーザーや特定の運動障碍のあるユーザーによるアプリ内の移動や、その機能の操作を実現します。 このようなユーザーにはマウス操作が困難な場合があり、キーボード強化ツールやスクリーン キーボードなどさまざまな支援技術をスクリーン拡大機能、スクリーン リーダー、音声入力ユーティリティなどと組み合わせて使用することが必要になります。 このようなユーザーにとっては、一貫性より包括性の方が重要です。

多くの経験豊富なユーザーには、キーボードの使用の方がはるかに好まれます。キーボード ベースのコマンドであれば、すばやく入力することができ、キーボードから手を離す必要がないためです。 このようなユーザーにとっては、効率性と一貫性が重要です。包括性が重要になるのは、特に頻繁に使用するコマンドに対してのみです。

ユーザビリティとアクセシビリティの設計には、わずかな相違があります。キーボード アクセスにおいて 2 つの異なるメカニズムがサポートされているのはこのためです。

アクセス キーには、次の特徴があります。

-   アクセス キーは、アプリ内の UI 要素へのショートカットです。
-   Alt キーを押しながら英数字キーを押します。
-   主な目的はアクセシビリティです。
-   すべてのメニューと大部分のダイアログ ボックス コントロールに割り当てます。
-   アクセス キーは覚えて使うことを意図していないため、UI に直接示されています (コントロールのラベルに含まれる対応する文字に下線)。
-   アクセス キーは、対応するメニュー項目やコントロールへの移動に使用します。効力は現在のウィンドウ内に限られます。
-   常に一貫して割り当てることはできないため、割り当てに一貫性はありません。 ただし、使用頻度の高いコマンド (特にコミット ボタン) については、アクセス キーの割り当てに一貫性が必要です。
-   アクセス キーはローカライズされます。

アクセス キーは覚えて使うことを意図していないため、キーワードがラベルの後半にある場合も、見つけやすいようにラベルの最初の方に出現する文字に割り当てます。

これに対し、ショートカット キーには次の特徴があります。

-   ショートカット キーは、アプリ コマンドへのショートカットです。
-   主に Ctrl キーとファンクション キーのシーケンスを使用します (Windows のシステム ショートカット キーには、Alt キーと英数字以外のキーの組み合わせと Windows ロゴ キーが使用されています)。
-   ショートカット キーの主な目的は、上級ユーザーによる使用の効率です。
-   特に使用頻度の高いコマンドにのみ割り当てます。
-   覚えて使うことを意図しており、メニュー、ツールヒント、ヘルプ内にのみ示されています。
-   効力はプログラム全体に及びますが、該当しない場合には効力がありません。
-   覚えて使うことを意図しており、直接示されないため、割り当てに一貫性が必要です。
-   ローカライズされません。

ショートカット キーは覚えて使うことを意図しているため、特に使用頻度の高いショートカット キーには、コマンド キーワードに含まれる先頭の文字または最も記憶しやすい文字を使用するのが理想的です。たとえば、コピー (Copy) に Ctrl + C を、要求 (Request) に Ctrl + Q を割り当てます。

ユーザーが、アプリでサポートされているすべてのタスクをハードウェア キーボードまたはスクリーン キーボードだけで実行できるようにしてください。

スクリーン リーダーやその他の支援技術を使うユーザーがアプリのショートカット キーを簡単に見つけられるようにする必要があります。 ヒント、アクセシビリティ対応の名前、アクセシビリティ対応の説明、またはその他の画面上の伝達形式を使ってショートカット キーが確認できるようにします。 少なくとも、アプリのヘルプ コンテンツにはアクセス キーとショートカット キーについて十分な説明を用意しておく必要があります。

よく知られているショートカット キーや標準のショートカット キーを他の機能に割り当てないでください。 たとえば、Ctrl + F は通常、検索に使用されます。

密度の高い UI に含まれるすべての対話型コントロールにアクセス キーを割り当てる必要はありません。 ただし、特に重要なコントロールと特に使用頻度の高いコントロールにアクセス キーを必ず割り当てるか、コントロール グループを作成して、そのコントロール グループのラベルにアクセス キーを割り当ててください。

キーボードの修飾キーを使うコマンドは変更しないでください。 変更すると、検出できなくなり、混乱を招きます。

入力フォーカスがあるコントロールを無効にしないでください。 キーボード入力の妨げになる可能性があります。

キーボード操作のエクスペリエンスを確実なものにするには、キーボードのみを使ってアプリを徹底的にテストすることが重要です。

## テキスト入力


キーボード入力に依存している場合は、常にデバイスの機能を確認するようにします。 一部のデバイス (電話など) では、ハードウェア キーボードにあるようなアクセラレータやコマンド キー (Alt キー、ファンクション キー、Windows ロゴ キーなど) の多くがタッチ キーボードに備わっていないため、タッチ キーボードの用途がテキスト入力に限定されます。

ユーザーがタッチ キーボードを使ってアプリ内を移動しないようにしてください。 フォーカスを取得するコントロールによっては、タッチ キーボードが閉じられることがあります。

フォームに対する操作が行われている間は終始キーボードを表示しておくようにしてください。 これにより、フォームまたはテキスト入力フローの途中で UI 表示が切り替わることでユーザーを混乱させるような状況を回避します。

入力しているフィールドをユーザーが常に見られるようにします。 タッチ キーボードによって画面の半分が見えなくなるため、ユーザーがフォーム内を移動するときに、フォーカスのある入力フィールドが見えるようにスクロールします。

標準的なハードウェア キーボードや OSK は、7 種類のキーで構成されており、各キーは異なる機能をサポートしています。

-   文字キー: 表示どおりの文字を入力フォーカスのあるウィンドウに送ります。
-   修飾キー: Ctrl キー、Alt キー、Shift キー、Windows ロゴ キーなど。プライマリ キーと組み合わせて使用し、そのキーの意味を変えます。
-   ナビゲーション キー: Tab キー、Home キー、End キー、PageUp キー、PageDown キー、方向キーなど。入力フォーカス (テキスト入力の場所) を移動します。
-   編集キー: Shift キー、Tab キー、Enter キー、Ins キー、BackSpace キー、Del キーなど。テキストを操作します。
-   ファンクション キー: F1 から F12 までのキー。特殊な機能の実行に使います。
-   切り替えキー: CapsLock キー、ScrollLock キー、NumLock キーなど。システムを特定のモードに切り替えます。
-   コマンド キー: Space キー、Enter キー、Esc キー、Pause/Break キー、PrintScreen キーなど。システム タスクまたはコマンドのアクティブ化を実行します。

これらのカテゴリに加え、セカンダリ クラスのキー (およびキーの組み合わせ) が存在します。これらは、アプリ機能のショートカットとして使用できます。

-   アクセス キー: Alt キーと文字キーを押すことでコントロールまたはメニュー項目を操作します。アクセス キーに使用する文字キーは、メニュー内では下線のある文字として示されます。オーバーレイに表示することもできます。
-   ショートカット キー: ファンクション キーを押すか、Ctrl キーと文字キーを押すことでアプリ コマンドを操作します。 アプリにはコマンドに対応する UI がある場合とない場合があります。

Secure Attention Sequence (SAS) と呼ばれる別のキーの組み合わせのクラスは、アプリでインターセプトできません。 これは、ログイン時にユーザーのシステムを保護するためのセキュリティ機能であり、Ctrl + Alt + Del や Win + L が含まれます。

次の図では、メモ帳アプリで展開された [ファイル] メニューに、アクセス キーとショートカット キーの両方が含まれています。

![メモ帳アプリで展開された [ファイル] メニューに、アクセス キーとショートカット キーの両方が含まれている。](images/input-patterns/notepad.png)

## キーボード コマンド


キーボード入力をサポートするさまざまなデバイスで提供されるキーボード操作の一覧を次に示します。 一部のデバイスやプラットフォームではキー入力や操作が異なる場合がありますが、これらも記載されています。

カスタムのコントロールや操作を設計する場合は、このキーボード言語を統一して使用してください。これにより、アプリの信頼性と学びやすさが向上し、なじみのある使用感が実現します。

既定のキーボード ショートカット定義を変更しないでください。

次の表に、よく使われるキーボード コマンドを示します。 キーボード コマンドの一覧については、[Windows のキーボード ショートカット キーに関するページ](http://go.microsoft.com/fwlink/p/?linkid=325424)をご覧ください。

**ナビゲーション コマンド**

| 操作                               | キー コマンド                                      |
|--------------------------------------|--------------------------------------------------|
| 戻る                                 | Alt + ←、または特殊キーボードの戻るボタン |
| 進む                              | Alt + →                                        |
| 上へ                                   | Alt + ↑                                           |
| キャンセルまたは現在のモードの終了   | Esc                                              |
| 一覧の項目間の移動         | 方向キー (←、→、↑、↓)                |
| 次の項目一覧にジャンプ           | Ctrl + ←                                        |
| セマンティック ズーム                        | Ctrl + 正符号 (+) または Ctrl + マイナス記号 (-)                                 |
| コレクション内の名前付き項目にジャンプ | 項目の名前を入力します                           |
| 次のページ                            | PageUp、PageDown、または Space                   |
| 次のタブ                             | Ctrl + Tab                                         |
| 前のタブ                         | Ctrl + Shift + Tab                                   |
| アプリ バーを開く                         | Windows+Z                                        |
| アクティブ化、または項目を開く    | Enter                                            |
| 選択                               | Space                                         |
| 連続して選択                  | Shift + 方向キー                                  |
| すべて選択                           | Ctrl + A                                           |

 

**一般的なコマンド**

| 操作                                                 | キー コマンド     |
|--------------------------------------------------------|-----------------|
| 項目をピン留めする                                            | Ctrl + Shift + 数字 1    |
| 保存                                                   | Ctrl + S          |
| 検索                                                   | Ctrl + F          |
| 印刷                                                  | Ctrl + P          |
| コピー                                                   | Ctrl + C          |
| 切り取り                                                    | Ctrl + X          |
| 新規項目                                               | Ctrl + N          |
| 貼り付け                                                  | Ctrl + V          |
| 開く                                                   | Ctrl + O          |
| アドレスを開く (たとえば、Internet Explorer で URL を開く) | Ctrl + L または Alt + D |

 

**メディア ナビゲーション コマンド**

| 操作       | キー コマンド |
|--------------|-------------|
| 再生/一時停止   | Ctrl + P      |
| 次の項目    | Ctrl + F      |
| 前の項目 | Ctrl + B      |

 

注: メディア ナビゲーションの "再生または一時停止" のキー コマンドは "印刷" のキー コマンドと同じであり、"次の項目" のキー コマンドは "検索" のキー コマンドと同じです。 メディア ナビゲーションのコマンドよりも、一般的なコマンドの方が優先されます。 たとえば、再生メディアと印刷の両方をサポートするアプリの場合、Ctrl + P キーを押すと印刷が実行されます。
## 視覚的なフィードバック


キーボード操作でのみフォーカス用の四角形を使います。 ユーザーがタッチ操作を始めたら、キーボードの UI を徐々にフェード アウトします。 これにより、UI の簡潔さが保たれます。

静的テキストなど、要素で対話式操作がサポートされていない場合は、視覚的なフィードバックを返さないでください。 これにより、UI の簡潔さが保たれます。

同じ入力対象を表すすべての要素に対して視覚的なフィードバックを同時に表示するようにしてください。

パン、回転、ズームなど、タッチ ベースの操作をエミュレートするためのヒントとして画面ボタン (+、- など) を提供するようにしてください。

視覚的なフィードバックに関する一般的なガイダンスについては、「[視覚的なフィードバックのガイドライン](guidelines-for-visualfeedback.md)」をご覧ください。


## キーボード イベントとフォーカス


次のキーボード イベントは、ハードウェア キーボードとタッチ キーボードの両方で発生します。

| イベント                                      | 説明                    |
|--------------------------------------------|--------------------------------|
| [**KeyDown**](https://msdn.microsoft.com/library/windows/apps/br208941) | キーが押されると発生します。  |
| [**KeyUp**](https://msdn.microsoft.com/library/windows/apps/br208942)     | キーが離されると発生します。 |


**重要**  
一部の Windows ランタイム コントロールでは、入力イベントが内部で処理されます。 このような場合は、イベント リスナーに関連付けられているハンドラーが呼び出されないため、入力イベントが発生しないように見えることがあります。 通常、これらのキーのサブセットはクラス ハンドラーで処理され、基本的なキーボード アクセシビリティのビルトイン サポートが提供されます。 たとえば、[**Button**](https://msdn.microsoft.com/library/windows/apps/br209265) クラスでは、Space キーと Enter キーの [**OnKeyDown**](https://msdn.microsoft.com/library/windows/apps/hh967982) イベント (および [**OnPointerPressed**](https://msdn.microsoft.com/library/windows/apps/hh967989)) がオーバーライドされ、コントロールの [**Click**](https://msdn.microsoft.com/library/windows/apps/br227737) イベントにルーティングされます。 キーの押下がコントロール クラスで処理された場合、[**KeyDown**](https://msdn.microsoft.com/library/windows/apps/br208941) イベントと [**KeyUp**](https://msdn.microsoft.com/library/windows/apps/br208942) イベントは発生しません。

これで、ボタンの実行に対応するキーボード操作が組み込まれ、ボタンを指でタップした場合やマウスでクリックした場合と同様の動作がサポートされます。 Space キーと Enter キー以外のキーについては、通常どおり [**KeyDown**](https://msdn.microsoft.com/library/windows/apps/br208941) と [**KeyUp**](https://msdn.microsoft.com/library/windows/apps/br208942) イベントが発生します。 クラス ベースのイベント処理の動作について詳しくは、「[イベントとルーティング イベントの概要](https://msdn.microsoft.com/library/windows/apps/mt185584)」(特に「コントロールの入力イベント ハンドラー」セクション) をご覧ください。


UI のコントロールに入力フォーカスがあるときにだけ、キーボード イベントが生成されます。 個々のコントロールは、ユーザーがレイアウト上でコントロールを直接クリックまたはタップするか、Tab キーを使ってコンテンツ領域内のタブ順に入ると、フォーカスを取得します。

コントロールの [**Focus**](https://msdn.microsoft.com/library/windows/apps/hh702161) メソッドを呼び出して、フォーカスを適用することもできます。 これは、UI が読み込まれたときに既定ではキーボード フォーカスが設定されないため、ショートカット キーを実装する場合に必要です。 詳しくは、このトピックの「[ショートカット キーの例](#shortcut_keys_example)」をご覧ください。

コントロールが入力フォーカスを受け取るには、コントロールが有効にされ、表示されている必要があります。また、[**IsTabStop**](https://msdn.microsoft.com/library/windows/apps/br209422) プロパティ値と [**HitTestVisible**](https://msdn.microsoft.com/library/windows/apps/br208933) プロパティ値が **true** に設定されている必要もあります。 これは、ほとんどのコントロールの既定の状態です。 コントロールに入力フォーカスがあると、このトピックで後ほど説明するように、キーボード入力イベントを発生させ、応答することもできます。 また、[**GotFocus**](https://msdn.microsoft.com/library/windows/apps/br208927) イベントと [**LostFocus**](https://msdn.microsoft.com/library/windows/apps/br208943) イベントを処理して、フォーカスを受け取るコントロールやフォーカスを失うコントロールに応答することもできます。

既定では、コントロールのタブ順は、Extensible Application Markup Language (XAML) 内の出現順になっています。 ただし、[**TabIndex**](https://msdn.microsoft.com/library/windows/apps/br209461) プロパティを使って、この順序を変更できます。 詳しくは、「[キーボード アクセシビリティの実装](https://msdn.microsoft.com/library/windows/apps/hh868161)」をご覧ください。

## キーボード イベント ハンドラー


入力イベント ハンドラーは、次の情報を提供するデリゲートを実装します。

-   イベントのセンダー。 センダーは、イベント ハンドラーがアタッチされているオブジェクトを報告します。
-   イベント データ。 キーボード イベントの場合、イベント データは [**KeyRoutedEventArgs**](https://msdn.microsoft.com/library/windows/apps/hh943072) のインスタンスです。 ハンドラーのデリゲートは [**KeyEventHandler**](https://msdn.microsoft.com/library/windows/apps/br227904) です。 ハンドラーに関するほとんどのシナリオで、最もよく使われる **KeyRoutedEventArgs** のプロパティは、[**Key**](https://msdn.microsoft.com/library/windows/apps/hh943074) です。場合によっては、[**KeyStatus**](https://msdn.microsoft.com/library/windows/apps/hh943075) も使われます。
-   [**OriginalSource**](https://msdn.microsoft.com/library/windows/apps/br208810)。 キーボード イベントはルーティング イベントであるため、イベント データには **OriginalSource** があります。 イベントがオブジェクト ツリーをバブルアップするように意図的に設定した場合、**OriginalSource** がセンダーではなく対象のオブジェクトとなる場合があります。 ただし、この動作は設計によって異なります。 センダーではなく **OriginalSource** を使う方法について詳しくは、このトピックの「キーボード ルーティング イベント」または「[イベントとルーティング イベントの概要](https://msdn.microsoft.com/library/windows/apps/mt185584)」をご覧ください。

### キーボード イベント ハンドラーのアタッチ

イベントがメンバーとして含まれているオブジェクトに対して、キーボード イベント ハンドラー関数をアタッチできます。 [**UIElement**](https://msdn.microsoft.com/library/windows/apps/br208911) 派生クラスにもアタッチできます。 XAML で [**Grid**](https://msdn.microsoft.com/library/windows/apps/br242704) の [**KeyUp**](https://msdn.microsoft.com/library/windows/apps/br208942) イベントのハンドラーをアタッチする方法を次の例に示します。

```xaml
<Grid KeyUp="Grid_KeyUp">
  ...
</Grid>
```

コードを使ってイベント ハンドラーをアタッチすることもできます。 詳しくは、「[イベントとルーティング イベントの概要](https://msdn.microsoft.com/library/windows/apps/mt185584)」をご覧ください。

### キーボード イベント ハンドラーの定義

次の例は、前の例でアタッチした [**KeyUp**](https://msdn.microsoft.com/library/windows/apps/br208942) イベント ハンドラーの定義の一部です。

```csharp
void Grid_KeyUp(object sender, KeyRoutedEventArgs e)
{
    //handling code here
}
```

```vb
Private Sub Grid_KeyUp(ByVal sender As Object, ByVal e As KeyRoutedEventArgs)
    ' handling code here
End Sub
```

```c++
void MyProject::MainPage::Grid_KeyUp(
  Platform::Object^ sender,
  Windows::UI::Xaml::Input::KeyRoutedEventArgs^ e)
  {
      //handling code here
  }
```

### KeyRoutedEventArgs の使用

キーボード イベントはいずれもイベント データに [**KeyRoutedEventArgs**](https://msdn.microsoft.com/library/windows/apps/hh943072) を使います。**KeyRoutedEventArgs** には次のプロパティがあります。

-   [**Key**](https://msdn.microsoft.com/library/windows/apps/hh943074)
-   [**KeyStatus**](https://msdn.microsoft.com/library/windows/apps/hh943075)
-   [**Handled**](https://msdn.microsoft.com/library/windows/apps/hh943073)
-   [**OriginalSource**](https://msdn.microsoft.com/library/windows/apps/br208810) ([**RoutedEventArgs**](https://msdn.microsoft.com/library/windows/apps/br208809) から継承)

### キー

キーが押されると、[**KeyDown**](https://msdn.microsoft.com/library/windows/apps/br208941) イベントが発生します。 同様に、キーが離されると、[**KeyUp**](https://msdn.microsoft.com/library/windows/apps/br208942) イベントが発生します。 通常、特定のキー値を処理するにはイベントをリッスンします。 押されたキーまたは離されたキーを特定するには、イベント データの [**Key**](https://msdn.microsoft.com/library/windows/apps/hh943074) 値を調べます。 **Key** は [**VirtualKey**](https://msdn.microsoft.com/library/windows/apps/br241812) 値を返します。 **VirtualKey** 列挙体には、サポートされているすべてのキーが含まれています。

### 修飾キー

修飾キーは、Ctrl、Shift など、一般的に他のキーと組み合わせて押されるキーです。 アプリでは、これらのキーの組み合わせをキーボード ショートカットとして使って、アプリ コマンドを呼び出すことができます。

ショートカット キーの組み合わせを検出するには、[**KeyDown**](https://msdn.microsoft.com/library/windows/apps/br208941) イベント ハンドラーや [**KeyUp**](https://msdn.microsoft.com/library/windows/apps/br208942) イベント ハンドラーでコードを使います。 目的とする修飾キーが押された状態を追跡することができます。 修飾キー以外のキーのキーボード イベントが発生した場合は、同時に修飾キーが押された状態になっていないかどうかを調べることができます。

> [!NOTE]
> Alt キーは **VirtualKey.Menu** 値で表されます。

 

### ショートカット キーの例


ショートカット キーを実装する方法を次の例で示します。 この例では、ユーザーは [Play]、[Pause]、[Stop] の各ボタンまたは Ctrl + P、Ctrl + A、Ctrl + S の各キーボード ショートカットを使って、メディアの再生を制御できます。 ボタンの XAML では、ボタン ラベルのヒントや [**AutomationProperties**](https://msdn.microsoft.com/library/windows/apps/br209081) プロパティを使って、ショートカット キーを示します。 このアプリ内の説明は、アプリの操作性とアクセシビリティを向上させるために重要です。 詳しくは、「[キーボードのアクセシビリティ](https://msdn.microsoft.com/library/windows/apps/mt244347)」をご覧ください。

ページが読み込まれるときに、入力フォーカスをページそのものに設定していることにも注目してください。 この手順を実行しなければ、最初の入力フォーカスがどのコントロールにも設定されず、ユーザーが手動で入力フォーカスを設定する (Tab キーを使ってコントロールを選ぶ、コントロールをクリックするなど) までアプリで入力イベントが発生しません。

```xaml
<Grid KeyDown="Grid_KeyDown">

  <Grid.RowDefinitions>
    <RowDefinition Height="Auto" />
    <RowDefinition Height="Auto" />
  </Grid.RowDefinitions>

  <MediaElement x:Name="DemoMovie" Source="xbox.wmv"
    Width="500" Height="500" Margin="20" HorizontalAlignment="Center" />

  <StackPanel Grid.Row="1" Margin="10"
    Orientation="Horizontal" HorizontalAlignment="Center">

    <Button x:Name="PlayButton" Click="MediaButton_Click"
      ToolTipService.ToolTip="Shortcut key: Ctrl+P"
      AutomationProperties.AcceleratorKey="Control P">
      <TextBlock>Play</TextBlock>
    </Button>

    <Button x:Name="PauseButton" Click="MediaButton_Click"
      ToolTipService.ToolTip="Shortcut key: Ctrl+A"
      AutomationProperties.AcceleratorKey="Control A">
      <TextBlock>Pause</TextBlock>
    </Button>

    <Button x:Name="StopButton" Click="MediaButton_Click"
      ToolTipService.ToolTip="Shortcut key: Ctrl+S"
      AutomationProperties.AcceleratorKey="Control S">
      <TextBlock>Stop</TextBlock>
    </Button>

  </StackPanel>

</Grid>
```

```c++
//showing implementations but not header definitions
void MainPage::OnNavigatedTo(NavigationEventArgs^ e)
{
    (void) e;    // Unused parameter
    this->Loaded+=ref new RoutedEventHandler(this,&amp;MainPage::ProgrammaticFocus);
}
void MainPage::ProgrammaticFocus(Object^ sender, RoutedEventArgs^ e) {
    this->Focus(Windows::UI::Xaml::FocusState::Programmatic);
}

void KeyboardSupport::MainPage::MediaButton_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e)
{
    FrameworkElement^ fe = safe_cast<FrameworkElement^>(sender);
    if (fe->Name == "PlayButton") {DemoMovie->Play();}
    if (fe->Name == "PauseButton") {DemoMovie->Pause();}
    if (fe->Name == "StopButton") {DemoMovie->Stop();}
}


void KeyboardSupport::MainPage::Grid_KeyDown(Platform::Object^ sender, Windows::UI::Xaml::Input::KeyRoutedEventArgs^ e)
{
    if (e->Key == VirtualKey::Control) isCtrlKeyPressed = true;
}


void KeyboardSupport::MainPage::Grid_KeyUp(Platform::Object^ sender, Windows::UI::Xaml::Input::KeyRoutedEventArgs^ e)
{
    if (e->Key == VirtualKey::Control) isCtrlKeyPressed = false;
    else if (isCtrlKeyPressed) {
        if (e->Key==VirtualKey::P) {
            DemoMovie->Play();
        }
        if (e->Key==VirtualKey::A) {DemoMovie->Pause();}
        if (e->Key==VirtualKey::S) {DemoMovie->Stop();}
    }
}
```

```csharp
protected override void OnNavigatedTo(NavigationEventArgs e)
{
    // Set the input focus to ensure that keyboard events are raised.
    this.Loaded += delegate { this.Focus(FocusState.Programmatic); };
}

private void MediaButton_Click(object sender, RoutedEventArgs e)
{
    switch ((sender as Button).Name)
    {
        case "PlayButton": DemoMovie.Play(); break;
        case "PauseButton": DemoMovie.Pause(); break;
        case "StopButton": DemoMovie.Stop(); break;
    }
}

private void Grid_KeyUp(object sender, KeyRoutedEventArgs e)
{
    if (e.Key == VirtualKey.Control) isCtrlKeyPressed = false;
}

private void Grid_KeyDown(object sender, KeyRoutedEventArgs e)
{
    if (e.Key == VirtualKey.Control) isCtrlKeyPressed = true;
    else if (isCtrlKeyPressed)
    {
        switch (e.Key)
        {
            case VirtualKey.P: DemoMovie.Play(); break;
            case VirtualKey.A: DemoMovie.Pause(); break;
            case VirtualKey.S: DemoMovie.Stop(); break;
        }
    }
}
```

```VisualBasic
Private isCtrlKeyPressed As Boolean
Protected Overrides Sub OnNavigatedTo(e As Navigation.NavigationEventArgs)

End Sub

Private Sub Grid_KeyUp(sender As Object, e As KeyRoutedEventArgs)
    If e.Key = Windows.System.VirtualKey.Control Then
        isCtrlKeyPressed = False
    End If
End Sub

Private Sub Grid_KeyDown(sender As Object, e As KeyRoutedEventArgs)
    If e.Key = Windows.System.VirtualKey.Control Then isCtrlKeyPressed = True
    If isCtrlKeyPressed Then
        Select Case e.Key
            Case Windows.System.VirtualKey.P
                DemoMovie.Play()
            Case Windows.System.VirtualKey.A
                DemoMovie.Pause()
            Case Windows.System.VirtualKey.S
                DemoMovie.Stop()
        End Select
    End If
End Sub

Private Sub MediaButton_Click(sender As Object, e As RoutedEventArgs)
    Dim fe As FrameworkElement = CType(sender, FrameworkElement)
    Select Case fe.Name
        Case "PlayButton"
            DemoMovie.Play()
        Case "PauseButton"
            DemoMovie.Pause()
        Case "StopButton"
            DemoMovie.Stop()
    End Select
End Sub
```

> [!NOTE]
> XAML で [**AutomationProperties.AcceleratorKey**](https://msdn.microsoft.com/library/windows/apps/hh759762) または [**AutomationProperties.AccessKey**](https://msdn.microsoft.com/library/windows/apps/hh759763) を設定すると、(その特定の操作を呼び出すためのショートカット キーを説明する) 文字列情報が提供されます。 この情報は、ナレーターなどの Microsoft UI オートメーション クライアントによってキャプチャされ、通常は、直接ユーザーに提供されます。
>
> **AutomationProperties.AcceleratorKey** または **AutomationProperties.AccessKey** を設定しても、それだけでは操作は実行されません。 実際にアプリにキーボード ショートカットの動作を実装するには、[**KeyDown**](https://msdn.microsoft.com/library/windows/apps/br208941) イベントまたは [**KeyUp**](https://msdn.microsoft.com/library/windows/apps/br208942) イベントのハンドラーをアタッチする必要があります。 また、アクセス キーの下線も自動的には追加されません。 UI で下線付きのテキストを表示する場合は、インラインの [**Underline**](https://msdn.microsoft.com/library/windows/apps/br209982) 書式設定として、ニーモニックの特定のキーのテキストに明示的に下線を表示する必要があります。

 

## キーボード ルーティング イベント


[**KeyDown**](https://msdn.microsoft.com/library/windows/apps/br208941) や、[**KeyUp**](https://msdn.microsoft.com/library/windows/apps/br208942) などの特定のイベントがルーティング イベントです。 ルーティング イベントでは、バブル ルーティング方式が採用されています。 バブル ルーティング方式では、子オブジェクトで発生したイベントが、オブジェクト ツリー内で上位にある親オブジェクトに順にルーティング (バブルアップ) されます。 つまり、同じイベントを処理し、同じイベント データを操作する機会が増えることを意味します。

次の XAML の例では、1 つの [**Canvas**](https://msdn.microsoft.com/library/windows/apps/br209267) と 2 つの [**Button**](https://msdn.microsoft.com/library/windows/apps/br209265) オブジェクトについて、[**KeyUp**](https://msdn.microsoft.com/library/windows/apps/br208942) イベントを処理します。 この場合、どちらかの **Button** オブジェクトにフォーカスがある間にキーを離すと、**KeyUp** イベントが発生します。 イベントはその後、親 **Canvas** までバブルアップされます。

```xaml
<StackPanel KeyUp="StackPanel_KeyUp">
  <Button Name="ButtonA" Content="Button A"/>
  <Button Name="ButtonB" Content="Button B"/>
  <TextBlock Name="statusTextBlock"/>
</StackPanel>
```

次の例は、前に示した XAML コンテンツに対応する [**KeyUp**](https://msdn.microsoft.com/library/windows/apps/br208942) イベント ハンドラーの実装方法を示しています。

```csharp
void StackPanel_KeyUp(object sender, KeyRoutedEventArgs e)
{
    statusTextBlock.Text = String.Format(
        "The key {0} was pressed while focus was on {1}",
        e.Key.ToString(), (e.OriginalSource as FrameworkElement).Name);
}
```

このハンドラーで [**OriginalSource**](https://msdn.microsoft.com/library/windows/apps/br208810) プロパティが使われていることに注意してください。 この例では、**OriginalSource** がイベントの発生元のオブジェクトを報告します。 **StackPanel** はコントロールではなく、フォーカスを受け取ることもできないため、[**StackPanel**](https://msdn.microsoft.com/library/windows/apps/br209635) がこのオブジェクトになることはありません。 **StackPanel** 内の 2 つのボタンのどちらか 1 つのみがイベントの発生元である可能性がありますが、発生元を調べるにはどうすればよいでしょうか。 親オブジェクトのイベントを処理する場合は、**OriginalSource** を使って、実際のイベント ソース オブジェクトを判別します。

### イベント データ内の Handled プロパティ

イベント処理の方針によっては、1 つのイベント ハンドラーだけがバブル イベントに応答するようにした方がよい場合もあります。 たとえば、[**Button**](https://msdn.microsoft.com/library/windows/apps/br209265) コントロールの 1 つに、特定の [**KeyUp**](https://msdn.microsoft.com/library/windows/apps/br208942) ハンドラーをアタッチすると、最初にそのイベントを処理するのは、このハンドラーがアタッチされたコントロールになります。 このとき、親パネルではイベントが処理されないようにします。 このようなシナリオでは、イベント データ内の [**Handled**](https://msdn.microsoft.com/library/windows/apps/hh943073) プロパティを使います。

ルーティング イベント データ クラスの [**Handled**](https://msdn.microsoft.com/library/windows/apps/hh943073) プロパティは、イベント ルート上で先に登録された別のハンドラーが既に処理を実行したことを示すためのプロパティで、 ルーティング イベント システムの動作に影響します。 イベント ハンドラー内で **Handled** を **true** に設定すると、そのイベントのルーティングはそこで終了し、上位の親要素にイベントは送信されません。

### AddHandler イベントと処理済みキーボード イベント

特殊な方法を利用して、既に処理済みとしてマークされているイベントに対して処理を実行できるハンドラーをアタッチすることができます。 この方法では、XAML 属性や、ハンドラーを追加するための言語固有の構文 (C# の場合は +=) を使わずに、[**AddHandler**](https://msdn.microsoft.com/library/windows/apps/hh702399) メソッドを使ってハンドラーを登録します。 

一般的に、この方法には、**AddHandler** API が [**RoutedEvent**](https://msdn.microsoft.com/library/windows/apps/br208808) 型のパラメーターを受け取るという制限があります。このパラメーターで対象のルーティング イベントを識別します。 一部のルーティング イベントには **RoutedEvent** 識別子がないため、[**Handled**](https://msdn.microsoft.com/library/windows/apps/hh943073) の状態でも処理できるルーティング イベントを識別する場合に考慮する必要があります。 [**UIElement**](https://msdn.microsoft.com/library/windows/apps/br208911) の [**KeyDown**](https://msdn.microsoft.com/library/windows/apps/br208941) イベントと [**KeyUp**](https://msdn.microsoft.com/library/windows/apps/br208942) イベントには、ルーティング イベント識別子 ([**KeyDownEvent**](https://msdn.microsoft.com/library/windows/apps/hh702416) と [**KeyUpEvent**](https://msdn.microsoft.com/library/windows/apps/hh702418)) があります。 これに対し、[**TextBox.TextChanged**](https://msdn.microsoft.com/library/windows/apps/br209706) などのイベントにはルーティング イベント識別子がないため、**AddHandler** を使う手法には利用できません。

### キーボード イベントと動作のオーバーライド

特定のコントロールのキー イベント (たとえば [**GridView**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.GridView) など) をオーバーライドして、キーボードとゲームパッドを含むさまざまな入力デバイスに一貫したフォーカス ナビゲーションを提供できます。

次の例では、コントロールをサブクラス化して KeyDown 動作をオーバーライドし、矢印キーが押されたときにフォーカスを GridView のコンテンツに移動します。

```csharp
public class CustomGridView : GridView
  {
    protected override void OnKeyDown(KeyRoutedEventArgs e)
    {
      // Override arrow key behaviors.
      if (e.Key != Windows.System.VirtualKey.Left && e.Key !=
        Windows.System.VirtualKey.Right && e.Key != 
          Windows.System.VirtualKey.Down && e.Key != 
            Windows.System.VirtualKey.Up)
              base.OnKeyDown(e);
      else
        FocusManager.TryMoveFocus(FocusNavigationDirection.Down);
    }
  }
```

> [!NOTE]
> GridView がレイアウトのみに使用されている場合には、[**ItemsControl**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.ItemsControl) と [**ItemsWrapGrid**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.ItemsWrapGrid) などの、他のコントロールの使用を検討します。

## コマンド実行

ごく一部の UI 要素では、コマンド実行が組み込みでサポートされています。 コマンド実行の基になる実装では、入力に関連するルーティング イベントを使います。 この方法では、1 つのコマンド ハンドラーを呼び出して、特定のポインター操作、特定のショートカット キーなどの関連する UI 入力を処理できます。

UI 要素でコマンド実行を使うことができる場合は、個々の入力イベントではなく、コマンド実行 API を使うことを検討してください。 詳しくは、「[**ButtonBase.Command**](https://msdn.microsoft.com/library/windows/apps/br227740)」をご覧ください。

[**ICommand**](https://msdn.microsoft.com/library/windows/apps/br227885) を実装して、通常のイベント ハンドラーから呼び出すコマンド機能をカプセル化することもできます。 この方法では、**Command** プロパティを利用できない場合でも、コマンド実行を使うことができます。

## テキスト入力とコントロール

キーボード イベントに固有の処理で対応するコントロールもあります。 たとえば、[**TextBox**](https://msdn.microsoft.com/library/windows/apps/br209683) は、キーボードを使って入力されたテキストをキャプチャし、表示するためのコントロールです。 このコントロールでは、キーボード操作をキャプチャするために、固有のロジックで [**KeyUp**](https://msdn.microsoft.com/library/windows/apps/br208942) と [**KeyDown**](https://msdn.microsoft.com/library/windows/apps/br208941) が使われます。また、テキストが実際に変化した場合には、固有の [**TextChanged**](https://msdn.microsoft.com/library/windows/apps/br209706) イベントを発生させます。

また、[**TextBox**](https://msdn.microsoft.com/library/windows/apps/br209683) などのテキスト入力の処理を目的としたコントロールに、[**KeyUp**](https://msdn.microsoft.com/library/windows/apps/br208942) や [**KeyDown**](https://msdn.microsoft.com/library/windows/apps/br208941) のハンドラーを追加することも通常どおりできます。 ただし、コントロールは、その設計上、キー イベントを通じて伝達されたすべてのキー値に応答するわけではありません。 動作はコントロールによって異なります。

たとえば、[**ButtonBase**](https://msdn.microsoft.com/library/windows/apps/br227736) ([**Button**](https://msdn.microsoft.com/library/windows/apps/br209265) の基底クラス) では、Space キーや Enter キーの操作を確認するために [**KeyUp**](https://msdn.microsoft.com/library/windows/apps/br208942) が処理されます。 **ButtonBase** では **KeyUp** を、[**Click**](https://msdn.microsoft.com/library/windows/apps/br227737) イベントを発生させるマウスの左ボタンを押す操作と同等と見なします。 このイベント処理は、**ButtonBase** が仮想メソッド [**OnKeyUp**](https://msdn.microsoft.com/library/windows/apps/hh967983) をオーバーライドする際に実現されます。 この実装では、[**Handled**](https://msdn.microsoft.com/library/windows/apps/hh943073) が **true** に設定されます。 このため、あるボタンの親がキー イベント (たとえば Space バー) をリッスンしていても、既に処理されたイベントをハンドラーで受け取ることはありません。

別の例としては、[**TextBox**](https://msdn.microsoft.com/library/windows/apps/br209683) があります。 方向キーなどの一部のキーは **TextBox** ではテキストと見なされず、コントロール UI 動作に固有のキーと見なされます。 **TextBox** は、これらのイベント ケースを処理済みとしてマークします。

カスタム コントロールで [**OnKeyDown**](https://msdn.microsoft.com/library/windows/apps/hh967982) / [**OnKeyUp**](https://msdn.microsoft.com/library/windows/apps/hh967983) をオーバーライドすると、キー イベントに対する同様のオーバーライド動作を独自に実装できます。 カスタム コントロールで特定のショートカット キーを処理する場合、または [**TextBox**](https://msdn.microsoft.com/library/windows/apps/br209683) の説明で示したシナリオのようなコントロールの動作またはフォーカスの動作を使う場合、**OnKeyDown** / **OnKeyUp** のオーバーライドにこのロジックを組み込む必要があります。

## タッチ キーボード

テキスト入力コントロールでは、タッチ キーボードが自動的にサポートされます。 ユーザーがタッチ入力を使って、テキスト コントロールに入力フォーカスを設定すると、タッチ キーボードが自動的に表示されます。 入力フォーカスがテキスト コントロールにないときには、タッチ キーボードが表示されません。

タッチ キーボードが表示されると、フォーカスがある要素をユーザーが見ることができるように、UI が自動的に再配置されます。 この場合、他の重要な UI 領域が画面の表示領域外に移動することがあります。 ただし、タッチ キーボードが表示されたときの既定の動作を無効にして、独自に UI を調整することができます。 詳しくは、[スクリーン キーボードを表示したときの対応のサンプルのページ](http://go.microsoft.com/fwlink/p/?linkid=231633)をご覧ください。

テキスト入力を必要とするカスタム コントロールを、標準のテキスト入力コントロールからの派生コントロールとして作成しない場合は、適切な UI オートメーション コントロール パターンを実装してタッチ キーボードを追加し、サポートできます。 詳しくは、「[タッチ キーボードの表示への応答](respond-to-the-presence-of-the-touch-keyboard.md)」と[タッチ キーボードのサンプルに関するページ](http://go.microsoft.com/fwlink/p/?linkid=246019)をご覧ください。

タッチ キーボードのキーが押されると、ハードウェア キーボードのキーが押されたとき同様に、[**KeyDown**](https://msdn.microsoft.com/library/windows/apps/br208941) イベントと [**KeyUp**](https://msdn.microsoft.com/library/windows/apps/br208942) イベントが発生します。 ただし、タッチ キーボードでは、Ctrl + A、Ctrl + Z、Ctrl + X、Ctrl + C、Ctrl + V に対応する入力イベントは発生しません。これらは、入力コントロールでテキストを操作するために予約されています。

ユーザーが入力すると予想されるデータの種類と一致するようにテキスト コントロールの入力値の種類を設定することで、ユーザーがより速く簡単にアプリにデータを入力できるようになります。 入力値の種類は、コントロールが予期しているテキスト入力の種類のヒントとなるため、システムが、その入力の種類用の特殊なタッチ キーボード レイアウトを提供できます。 たとえば、テキスト ボックスが 4 桁の PIN の入力専用の場合は、[**InputScope**](https://msdn.microsoft.com/library/windows/apps/hh702632) プロパティを [**Number**](https://msdn.microsoft.com/library/windows/apps/hh702028) に設定します。 これにより、システムに数字キーパッド レイアウトの表示が指示されるため、ユーザーは簡単に PIN を入力できます。 詳しくは、「[入力値の種類を使ったタッチ キーボードの変更](https://msdn.microsoft.com/library/windows/apps/mt280229)」をご覧ください。


## このセクションの他の記事

<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left">トピック</th>
<th align="left">説明</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p>[タッチ キーボードの表示への応答](respond-to-the-presence-of-the-touch-keyboard.md)</p></td>
<td align="left"><p>タッチ キーボードを表示または非表示にするときにアプリの UI を調整する方法について説明します。</p></td>
</tr>
</tbody>
</table>

## 関連記事

**開発者向け**
* [入力デバイスの識別](identify-input-devices.md)
* [タッチ キーボードの表示への応答](respond-to-the-presence-of-the-touch-keyboard.md)

**デザイナー向け**
* [キーボードの設計ガイドライン](https://msdn.microsoft.com/library/windows/apps/hh972345)

**サンプル**
* [基本的な入力のサンプル](http://go.microsoft.com/fwlink/p/?LinkID=620302)
* [待機時間が短い入力のサンプル](http://go.microsoft.com/fwlink/p/?LinkID=620304)
* [フォーカスの視覚効果のサンプル](http://go.microsoft.com/fwlink/p/?LinkID=619895)

**サンプルのアーカイブ**
* [入力サンプル](http://go.microsoft.com/fwlink/p/?linkid=226855)
* [入力: デバイス機能のサンプルに関するページ](http://go.microsoft.com/fwlink/p/?linkid=231530)
* [入力: タッチ キーボードのサンプルに関するページ](http://go.microsoft.com/fwlink/p/?linkid=246019)
* [スクリーン キーボードを表示したときの対応のサンプルのページ](http://go.microsoft.com/fwlink/p/?linkid=231633)
* [XAML テキスト編集のサンプルに関するページ](http://go.microsoft.com/fwlink/p/?LinkID=251417)
 

 



<!--HONumber=Nov16_HO1-->


