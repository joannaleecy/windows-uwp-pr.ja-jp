---
author: Karl-Bridge-Microsoft
Description: "ユーザーがキーボードで UI 要素間を移動できるように、タブ ナビゲーションとアクセス キーを使用してキーボードのアクセスを有効にします。"
title: "アクセス キー"
ms.assetid: C2F3F3CE-737F-4652-98B7-5278A462F9D3
label: Access keys
template: detail.hbs
keywords: "アクセス キー, キーボード, アクセシビリティ, ユーザーの操作, 入力"
ms.author: kbridge
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
translationtype: Human Translation
ms.sourcegitcommit: c6b64cff1bbebc8ba69bc6e03d34b69f85e798fc
ms.openlocfilehash: e866c3afc551cf9604809cf7fec36efd7bfa439c
ms.lasthandoff: 02/07/2017

---

# <a name="access-keys"></a>アクセス キー

運動障碍を持つユーザーなど、マウスの使用が難しいユーザーは、通常、アプリ内の移動やアプリの操作にキーボードを使用します。  XAML フレームワークでは、タブ ナビゲーションとアクセス キーによって UI 要素へのキーボード アクセスを提供できます。

- タブ ナビゲーションは基本的なキーボード アクセシビリティのアフォーダンス (既定で有効) であり、ユーザーはキーボードの Tab キーと方向キーを使って UI 要素間でフォーカスを移動できます。
- アクセス キーは、キーボードの修飾キー (Alt キー) と 1 つ以上の英数字キー (通常はコマンドに関連付けられている文字) の組み合わせを使って、アプリのコマンドにすばやくアクセスするための補助的なアクセシビリティのアフォーダンス (開発者がアプリに実装する) です。 よく使うアクセス キーとして、_Alt、F_ で [ファイル] メニューを開く、_Alt、AL_ で左揃えなどがあります。  

キーボード ナビゲーションとアクセシビリティについて詳しくは、「[キーボード操作](https://msdn.microsoft.com/windows/uwp/input-and-devices/keyboard-interactions)」と「[キーボードのアクセシビリティ](https://msdn.microsoft.com/windows/uwp/accessibility/keyboard-accessibility)」をご覧ください。 この記事では、これらの記事で説明されている概念を理解していることを前提としています。

## <a name="access-key-overview"></a>アクセス キーの概要

アクセス キーによって、ユーザーはボタンを直接呼び出したり、Tab キーや方向キーを繰り返し押さなくてもキーボードでフォーカスを設定したりすることができます。 アクセス キーは簡単に見つけることができるようにすることを目的としているため、UI に直接表示する必要があります。たとえば、コントロール上にアクセス キーのフローティング バッジを表示します。

![Microsoft Word でのアクセス キーと関連付けられたキーのヒントの例](images/keyboard/accesskeys-keytips.png)

_図 1: Microsoft Word でのアクセス キーと関連付けられたキーのヒントの例。_

アクセス キーは、UI 要素に関連付けられている 1 つまたは複数の英数字です。 たとえば、Microsoft Word では、[ホーム] タブには _H_、[元に戻す] ボタンには _2_、[描画] タブには _JI_ を使用します。

**アクセス キーのスコープ**

アクセス キーは特定のスコープに属しています。 たとえば、図 1 では、_F_、_H_、_N_、_JI_ はページのスコープに属しています。  ユーザーが _H_ キーを押すと、スコープは [ホーム] タブのスコープに変更され、図 2 に示すようにアクセス キーが表示されます。 アクセス キー _V_、_FP_、_FF_、_FS_ は、[ホーム] タブのスコープに属しています。

![Microsoft Word の [ホーム] タブのスコープのアクセス キーと関連付けられたキーのヒントの例](images/keyboard/accesskeys-keytips-hometab.png)

_図 2: Microsoft Word の [ホーム] タブのスコープのアクセス キーと関連付けられたキーのヒントの例。_

2 つの要素が異なるスコープに属している場合、2 つの要素のアクセス キーが同じである場合があります。 たとえば、_2_は、ページのスコープ (図 1) では [元に戻す] のアクセス キーですが、[ホーム] タブのスコープ (図 2) では [斜体] のアクセス キーです。 すべてのアクセス キーは、別のスコープを指定しない限り、既定のスコープに属します。

**アクセス キー シーケンス**

アクセス キーの組み合わせでは、通常、複数のキーを同時に押すことではなく、一度に 1 つのキーを押すことで操作を実現します  (これには次のセクションで説明する例外があります)。操作を実現するために必要なキーボード操作のシーケンスが、_アクセス キー シーケンス_です。 ユーザーは、Alt キーを押してアクセス キー シーケンスを開始します。 アクセス キーは、ユーザーが、アクセス キー シーケンスの最後のキーを押したときに呼び出されます。 たとえば、Word で [表示] タブを開くには、_Alt、W_ アクセス キー シーケンスを押します。

ユーザーは、アクセス キー シーケンスでいくつかのアクセス キーを呼び出すことができます。 たとえば、Word 文書内で [書式のコピー/貼り付け] を開くには、Alt キーを押してシーケンスを初期化します。次に、_H_ キーを押して [ホーム] タブに移動し、アクセス キーのスコープを変更して、_F_ キー、最後に _P_ キーを押します。_H_ と _FP_ は、それぞれ、[ホーム] タブと [書式のコピー/貼り付け] ボタンのアクセス キーです。

呼び出された後に終了する要素 ([書式のコピー/貼り付け] ボタンなど) もあれば、終了しない要素 ([ホーム] タブなど) もあります。 アクセス キーを呼び出すと、コマンドの実行、フォーカスの移動、アクセス キーのスコープの変更、アクセス キーに関連付けられたその他の操作が実行されます。

## <a name="access-key-user-interaction"></a>アクセス キーのユーザー操作

アクセス キー API を理解するには、ユーザー操作モデルを理解しておく必要があります。 以下に、アクセス キーのユーザー操作モデルの概要を示します。

- ユーザーが Alt キーを押すと、フォーカスが入力コントロールにある場合でも、アクセス キー シーケンスが開始されます。 次に、ユーザーはアクセス キーを押して関連付けられた操作を呼び出すことができます。 このユーザー操作のために、Alt キーが押されたときに表示される視覚的アフォーダンス (フローティング バッジなど) を使って、UI 内に利用可能なアクセス キーを示すことが必要です。
- ユーザーが Alt キーとアクセス キーを同時に押すと、アクセス キーはすぐに呼び出されます。 これは、Alt + _アクセス キー_によってキーボード ショートカットを定義することと似ています。 この場合、アクセス キーの視覚的アフォーダンスは表示されません。 ただし、アクセス キーを呼び出すことで、アクセス キーのスコープが変更される可能性があります。 この場合、アクセス キーのシーケンスが開始され、新しいスコープの視覚的アフォーダンスが表示されます。
    > [!NOTE]
    > このユーザー操作のメリットが得られるのは、1 文字のアクセス キーのみです。 Alt + _アクセス キー_ の組み合わせは、複数の文字のアクセス キーについてはサポートされていません。    
- 複数の文字のアクセス キーのいくつかで同じ文字が使用されている場合、ユーザーが共通する文字を押すと、アクセス キーはフィルター処理されます。 たとえば、_A1_、_A2_、_C_ という 3 つのアクセス キーがあるとします。ユーザーが _A_ キーを押すと、_A1_ と _A2_ のアクセス キーのみが表示され、C の視覚的アフォー ダンスは表示されません。
- Esc キーは、1 つのレベルをフィルター処理を解除します。 たとえば、_B_、_ABC_、_ACD_、_ABD_ というアクセス キーがある場合、ユーザーが _A_ キーを押すと、_ABC_、_ACD_、_ABD_ が表示されます。 次に、ユーザーが _B_ キーを押すと、_ABC_ と _ABD_ が表示されます。 ユーザーが Esc キーを押すと、フィルター処理が 1 レベル解除され、_ABC_、_ACD_、_ABD_ のアクセス キーが表示されます。 ユーザーがもう一度 Esc キーを押すと、フィルター処理がさらに 1 レベル解除され、すべてのアクセス キー (_B_、_ABC_、_ACD_、_ABD_) が有効になり、視覚的アフォーダンスが表示されます。
- Esc キーによって、前のスコープに戻ることができます。 アクセス キーは、多くのコマンドを持つアプリ間での移動を容易にするために、複数のスコープに属することができます。 アクセス キー シーケンスは、常にメイン スコープで始まります。 すべてのアクセス キーは、スコープ所有者として特定の UI 要素を指定するものを除き、メイン スコープに属します。 ユーザーがスコープ所有者である要素のアクセス キーを呼び出すと、XAML フレームワークは自動的にスコープをその要素に移動して、内部のアクセス キー ナビゲーション スタックに追加します。 Esc キーは、アクセス キーのナビゲーション スタックに従って前に戻ります。
- アクセス キー シーケンスを閉じるには、いくつかの方法があります。
    - ユーザーは、Alt キーを押すことによって、進行中のアクセス キー シーケンスを閉じることができます。 Alt キーを押すとアクセス キー シーケンスが開始されることも覚えておいてください。
    - メイン スコープで、フィルター処理されていない場合、Esc キーを押すとアクセス キー シーケンスが閉じられます。
        > [!NOTE]
        > Esc キーの操作は UI レイヤーに渡され、UI レイヤーでも処理されます。
    - Tab キーを押すと、アクセス キー シーケンスが閉じられ、タブ ナビゲーションに戻ります。
    - Enter キーを押すと、アクセス キー シーケンスが閉じられ、フォーカスのある要素にキーボード操作が送信されます。
    - 方向キーを押すと、アクセス キー シーケンスが閉じられ、フォーカスのある要素にキーボード操作が送信されます。
    - マウスのクリックやタッチなどのポインター ダウン イベントによって、アクセス キー シーケンスが閉じられます。
    - 既定では、アクセス キーが呼び出されると、アクセス キー シーケンスは閉じられます。  ただし、この動作は、[ExitDisplayModeOnAccessKeyInvoked](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.exitdisplaymodeonaccesskeyinvoked.aspx) プロパティを **false** に設定することによってオーバーライドすることができます。
- 決定性有限オートマトンが不可能な場合、アクセス キーの競合が発生します。 アクセス キーの競合は望ましくありませんが、大量のコマンド、ローカライズの問題、アクセス キーのランタイム生成によって発生する場合があります。

 競合が発生するのは、次の 2 つの場合です。
 - 2 つの UI 要素が同じアクセス キー値を持ち、同じアクセス キーのスコープに属している場合。 たとえば、`button1` のアクセス キー _A1_ と `button2` のアクセス キー _A1_ が、既定のスコープに属している場合です。 この場合、システムは、ビジュアル ツリーに最初に追加された要素のアクセス キーを処理することによって、競合を解決します。 残りの部分は無視されます。
 - 同じアクセス キーのスコープに複数の処理の選択肢がある場合。 たとえば、_A_ と _A1_ があるとします。 ユーザーが _A_ キーを押したとき、システムには 2 つの選択肢があります。_A_ アクセス キーを呼び出すか、処理を続行して、_A1_ アクセス キーの文字 A が押されたものとして処理するかです。 この例では、システムは、オートマトンによって最初のアクセス キーの呼び出しのみを処理します。 たとえば、_A_ と _A1_ がある場合、システムは _A_ アクセス キーのみを呼び出します。
-     ユーザーが、アクセス キー シーケンスで無効なアクセス キーの値を押した場合は、何も起こりません。 アクセス キー シーケンスで有効なアクセス キーと見なされるキーには、2 つのカテゴリがあります。
 - アクセス キー シーケンスを終了する特別なキー。これには、Esc キー、Alt キー、方向キー、Enter キー、Tab キーがあります。
 - アクセス キーに割り当てられている英数字。

## <a name="access-key-apis"></a>アクセス キー API

アクセス キーのユーザーの操作をサポートするために、XAML フレームワークは、ここで説明する API を提供します。

**AccessKeyManager**

[AccessKeyManager](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.input.accesskeymanager.aspx) は、アクセス キーを表示または非表示にするときに、UI の管理に使用できるヘルパー クラスです。 [IsDisplayModeEnabledChanged](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.input.accesskeymanager.isdisplaymodeenabledchanged.aspx) イベントは、アプリがアクセス キー シーケンスを開始および終了するたびに発生します。 [IsDisplayModeEnabled](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.input.accesskeymanager.isdisplaymodeenabled.aspx) プロパティを照会することによって、視覚的アフォーダンスが表示されているか、非表示であるかを特定できます。  [ExitDisplayMode](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.input.accesskeymanager.exitdisplaymode.aspx) を呼び出して、アクセス キー シーケンスを強制的に終了することもできます。

> [!NOTE]
> アクセス キーのビジュアルについて、組み込みの実装はありません。開発者が提供する必要があります。  

**AccessKey**

[AccessKey](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.accesskey.aspx) プロパティによって、UIElement または [TextElement](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.documents.textelement.accesskey.aspx) のアクセス キーを指定できます。 2 つの要素のアクセス キーとスコープが同じである場合、ビジュアル ツリーに最初に追加された要素のみが処理されます。

XAML フレームワークで確実にアクセス キーを処理するには、ビジュアル ツリーで UI 要素を実現する必要があります。 ビジュアル ツリー内にアクセス キーを持つ要素がない場合、アクセス キー イベントは発生しません。

アクセス キー API では、2 つのキーボード操作を必要とする文字はサポートされません。 個々の文字は、特定の言語のネイティブ キーボード レイアウトのキーに対応している必要があります。  

**AccessKeyDisplayRequested/Dismissed**

[AccessKeyDisplayRequested](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.accesskeydisplayrequested.aspx) イベントと [AccessKeyDisplayDismissed](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.accesskeydisplaydismissed.aspx) イベントは、アクセス キーの視覚的アフォーダンスを表示または非表示にする必要があるときに発生します。 これらのイベントは、[Visibility](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.visibility.aspx) プロパティが **Collapsed** に設定されている要素については発生しません。 アクセス キー シーケンス中に、ユーザーがアクセス キーによって使用されている文字を押すたびに、AccessKeyDisplayRequested イベントが発生します。 たとえば、アクセス キーが _AB_ に設定されている場合、ユーザーが Alt キーを押したときにこのイベントが発生し、ユーザーが _A_ キーを押したときにもう一度発生します。ユーザーが _B_ キーを押すと、AccessKeyDisplayDismissed イベントが発生します。

**AccessKeyInvoked**

[AccessKeyInvoked](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.accesskeyinvoked.aspx) イベントは、ユーザーがアクセス キーの最後の文字を押したときに発生します。 アクセス キーは、1 文字の場合と複数の文字の場合があります。 たとえば、アクセス キー _A_ と _BC_ の場合、ユーザーが _Alt、A_ または _Alt、B、C_ を押したときに、このイベントが発生します。しかし、ユーザーが_Alt、B_ のみを押したときには発生しません。このイベントは、キーを離したときではなく、キーが押されたときに発生します。

**IsAccessKeyScope**

[IsAccessKeyScope](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.isaccesskeyscope.aspx) プロパティによって、UIElement がアクセス キーのスコープのルートであることを指定できます。 AccessKeyDisplayRequested イベントは、この要素について発生し、その子については発生しません。 ユーザーがこの要素を呼び出したときに、XAML フレームワークはスコープを自動的に変更し、その子について AccessKeyDisplayRequested イベントを発生させ、他の UI 要素 (親を含む) については AccessKeyDisplayDismissed イベントを発生させます。  スコープが変更されたときに、アクセス キー シーケンスは終了しません。

**AccessKeyScopeOwner**

要素を、ビジュアル ツリー内の親ではない別の要素 (ソース) のスコープに参加させるには、[AccessKeyScopeOwner](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.accesskeyscopeowner.aspx) プロパティを設定します。 AccessKeyScopeOwner プロパティにバインドされている要素では、IsAccessKeyScope が **true** に設定されている必要があります。 このようにしないと、例外がスローされます。

**ExitDisplayModeOnAccessKeyInvoked**

既定では、アクセス キーが呼び出され、要素がスコープの所有者ではない場合、アクセス キー シーケンスは終了し、[AccessKeyManager.IsDisplayModeEnabledChanged](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.input.accesskeymanager.isdisplaymodeenabledchanged.aspx) イベントが発生します。 [ExitDisplayModeOnAccessKeyInvoked](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.exitdisplaymodeonaccesskeyinvoked.aspx) プロパティを **false** に設定することによってこの動作をオーバーライドし、呼び出された後で、アクセス キー シーケンスが終了することを防止できます  (このプロパティは、[UIElement](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.exitdisplaymodeonaccesskeyinvoked.aspx) と [TextElement](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.documents.textelement.exitdisplaymodeonaccesskeyinvoked.aspx) の両方にあります)。

> [!NOTE]
> 要素がスコープ所有者である場合 (`IsAccessKeyScope="True"`)、アプリは、新しいアクセス キーのスコープに入り、IsDisplayModeEnabledChanged イベントは発生しません。

**ローカライズ**

アクセス キーを複数の言語にローカライズし、[ResourceLoader](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.resources.resourceloader.aspx) API を使って、実行時に読み込むことができます。

## <a name="control-patterns-used-when-an-access-key-is-invoked"></a>アクセス キーが呼び出されたときに使用されるコントロール パターン

コントロール パターンは、共通するコントロール機能を公開するインターフェイスの実装です。たとえば、ボタンは **Invoke** コントロール パターンを実装し、これによって **Click** イベントを発生させます。 アクセス キーが呼び出されると、XAML フレームワークは、呼び出された要素がコントロール パターンを実装するかどうかを検索し、実装する場合はそれを実行します。 要素が複数のコントロール パターンを持つ場合、1 つのみが呼び出され、残りは無視されます。 コントロール パターンは、次の順序で検索されます。

1.    Invoke。 たとえば、Button です。
2.    Toggle。 たとえば、Checkbox です。
3.    Selection。 たとえば、RadioButton です。
4.    Expand/Collapse。 たとえば、ComboBox です。

コントロール パターンが見つからない場合、アクセス キーの呼び出しは no-op として表示され、このような状況のデバッグに役立つ、次のようなデバッグ メッセージが記録されます。「このコンポーネントのオートメーション パターンが見つかりません。 AccessKeyInvoked のイベント ハンドラーで目的の動作を実装してください。 イベント ハンドラーで Handled を true に設定すると、このメッセージは表示されません」

> [!NOTE]
> このメッセージを表示するには、Visual Studio のデバッグの設定でデバッガーのアプリケーション プロセスの種類が _[混合 (マネージとネイティブ)]_ または _[ネイティブ]_ になっている必要があります。

アクセス キーでその既定のコントロール パターンを実行しない場合や、その要素がコントロール パターンを持たない場合は、[AccessKeyInvoked](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.accesskeyinvoked.aspx) イベントを処理して、目的の動作を実装する必要があります。
```csharp
private void OnAccessKeyInvoked(UIElement sender, AccessKeyInvokedEventArgs args)
{
    args.Handled = true;
    //Do something
}
```

コントロール パターンについて詳しくは、「[UI オートメーション コントロール パターンの概要](https://msdn.microsoft.com/library/windows/desktop/ee671194.aspx)」をご覧ください。

## <a name="access-keys-and-narrator"></a>アクセス キーとナレーター

Windows ランタイムには、Microsoft UI オートメーション要素のプロパティを公開する UI オートメーション プロバイダーがあります。 これらのプロパティによって、UI オートメーション クライアント アプリケーションで、ユーザー インターフェイスの要素に関する情報を検出できます。 [AutomationProperties.AccessKey](https://msdn.microsoft.com/library/windows/apps/hh759763) プロパティによって、ナレーターなどのクライアントで、要素に関連付けられているアクセス キーを検出できます。 要素がフォーカスを取得するたびに、ナレーターはこのプロパティを読み取ります。 AutomationProperties.AccessKey に値がない場合、XAML フレームワークは UIElement や TextElement から [AccessKey](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.accesskey.aspx) プロパティの値を返します。 AccessKey プロパティに既に値がある場合は、AutomationProperties.AccessKey を設定する必要はありません。

## <a name="example-access-key-for-button"></a>例: ボタンのアクセス キー

この例では、ボタンのアクセス キーを作成する方法を示します。 アクセス キーを含むフローティング バッジを実装する視覚的アフォーダンスとして、ヒントを使用しています。

> [!NOTE]
> 説明をわかりやすくするためにヒントを使用していますが、[Popup](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.popup.aspx) などを使用して独自のコントロールを作成することをお勧めします。

XAML フレームワークは Click イベントのハンドラーを自動的に呼び出すため、AccessKeyInvoked イベントを処理する必要はありません。 この例では、[AccessKeyDisplayRequestedEventArgs.PressedKeys](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.input.accesskeydisplayrequestedeventargs.pressedkeys.aspx) プロパティを使用して、アクセス キーを呼び出すために必要な残りの文字のみの視覚的アフォーダンスを提供します。 たとえば、_A1_、_A2_、_C_ の 3 つのアクセス キーがある場合、ユーザーが _A_ キーを押すと、_A1_ と _A2_ アクセス キーのみが残りますが、_A1_ と _A2_ の代わりに、_1_ と _2_ のように表示されます。

```xaml
<StackPanel
        VerticalAlignment="Center"
        HorizontalAlignment="Center"
        Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
        <Button Content="Press"
                AccessKey="PB"
                AccessKeyDisplayDismissed="OnAccessKeyDisplayDismissed"
                AccessKeyDisplayRequested="OnAccessKeyDisplayRequested"
                Click="DoSomething" />
        <TextBlock Text="" x:Name="textBlock" />
    </StackPanel>
```

```csharp
 public sealed partial class ButtonSample : Page
    {
        public ButtonSample()
        {
            this.InitializeComponent();
        }

        private void DoSomething(object sender, RoutedEventArgs args)
        {
            textBlock.Text = "Access Key is working!";
        }

        private void OnAccessKeyDisplayRequested(UIElement sender, AccessKeyDisplayRequestedEventArgs args)
        {
            var tooltip = ToolTipService.GetToolTip(sender) as ToolTip;

            if (tooltip == null)
            {
                tooltip = new ToolTip();
                tooltip.Background = new SolidColorBrush(Windows.UI.Colors.Black);
                tooltip.Foreground = new SolidColorBrush(Windows.UI.Colors.White);
                tooltip.Padding = new Thickness(4, 4, 4, 4);
                tooltip.VerticalOffset = -20;
                tooltip.Placement = PlacementMode.Bottom;
                ToolTipService.SetToolTip(sender, tooltip);
            }

            if (string.IsNullOrEmpty(args.PressedKeys))
            {
                tooltip.Content = sender.AccessKey;
            }
            else
            {
                tooltip.Content = sender.AccessKey.Remove(0, args.PressedKeys.Length);
            }

            tooltip.IsOpen = true;
        }
        private void OnAccessKeyDisplayDismissed(UIElement sender, AccessKeyDisplayDismissedEventArgs args)
        {
            var tooltip = ToolTipService.GetToolTip(sender) as ToolTip;
            if (tooltip != null)
            {
                tooltip.IsOpen = false;
                //Fix to avoid show tooltip with mouse
                ToolTipService.SetToolTip(sender, null);
            }
        }
    }
```

## <a name="example-scoped-access-keys"></a>例: スコープ指定されたアクセス キー

この例では、スコープ指定されたアクセス キーを作成する方法を示します。 PivotItem の IsAccessKeyScope プロパティによって、ユーザーが Alt キーを押したときに、PivotItem の子要素のアクセス キーが表示されるのを防止します。 これらのアクセス キーは、ユーザーが PivotItem を呼び出したときにのみ表示されます。XAML フレームワークによって、スコープが自動的に切り替えられるためです。 フレームワークによって、他のスコープのアクセス キーも非表示になります。

この例では、AccessKeyInvoked イベントを処理する方法についても説明します。 PivotItem はどのコントロール パターンを実装していないため、XAML フレームワークは既定ではどの操作も呼び出しません。 この実装では、アクセス キーを使って呼び出された PivotItem を選択する方法を示しています。

最後に、この例では、表示モードが変更されたときに特定の処理を実行するために使用できる IsDisplayModeChanged イベントを示します。 この例では、ユーザーが Alt キーを押すまで、Pivot コントロールは折りたたまれています。 ユーザーが Pivot の操作を終了すると、再び折りたたまれます。 IsDisplayModeEnabled を使って、アクセス キーの表示モードが有効であるか無効であるかを確認できます。

```xaml   
<Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
        <Pivot x:Name="MyPivot" VerticalAlignment="Center" HorizontalAlignment="Center" >
            <Pivot.Items>
                <PivotItem
                    x:Name="PivotItem1"
                    AccessKey="A"
                    AccessKeyInvoked="OnAccessKeyInvoked"
                    AccessKeyDisplayDismissed="OnAccessKeyDisplayDismissed"
                    AccessKeyDisplayRequested="OnAccessKeyDisplayRequested"
                    IsAccessKeyScope="True">
                    <PivotItem.Header>
                        <TextBlock Text="A Options"/>
                    </PivotItem.Header>
                    <StackPanel Orientation="Horizontal" >
                        <Button Content="ButtonAA" AccessKey="A"
                                AccessKeyDisplayDismissed="OnAccessKeyDisplayDismissed"
                                AccessKeyDisplayRequested="OnAccessKeyDisplayRequested" />
                        <Button Content="ButtonAD1" AccessKey="D1"
                                AccessKeyDisplayDismissed="OnAccessKeyDisplayDismissed"
                                AccessKeyDisplayRequested="OnAccessKeyDisplayRequested"  />
                        <Button Content="ButtonAD2" AccessKey="D2"
                                AccessKeyDisplayDismissed="OnAccessKeyDisplayDismissed"
                                AccessKeyDisplayRequested="OnAccessKeyDisplayRequested"/>
                    </StackPanel>
                </PivotItem>
                <PivotItem
                    x:Name="PivotItem2"
                    AccessKeyInvoked="OnAccessKeyInvoked"
                    AccessKeyDisplayDismissed="OnAccessKeyDisplayDismissed"
                    AccessKeyDisplayRequested="OnAccessKeyDisplayRequested"
                    AccessKey="B"
                    IsAccessKeyScope="true">
                    <PivotItem.Header>
                        <TextBlock Text="B Options"/>
                    </PivotItem.Header>
                    <StackPanel Orientation="Horizontal">
                        <Button AccessKey="B" Content="ButtonBB"
                                AccessKeyDisplayDismissed="OnAccessKeyDisplayDismissed"
                                AccessKeyDisplayRequested="OnAccessKeyDisplayRequested"  />
                        <Button AccessKey="F1" Content="ButtonBF1"
                                AccessKeyDisplayDismissed="OnAccessKeyDisplayDismissed"
                                AccessKeyDisplayRequested="OnAccessKeyDisplayRequested"  />
                        <Button AccessKey="F2" Content="ButtonBF2"  
                                AccessKeyDisplayDismissed="OnAccessKeyDisplayDismissed"
                                AccessKeyDisplayRequested="OnAccessKeyDisplayRequested"/>
                    </StackPanel>
                </PivotItem>
            </Pivot.Items>
        </Pivot>
    </Grid>
```

```csharp
public sealed partial class ScopedAccessKeys : Page
    {
        public ScopedAccessKeys()
        {
            this.InitializeComponent();
            AccessKeyManager.IsDisplayModeEnabledChanged += OnDisplayModeEnabledChanged;
            this.Loaded += OnLoaded;
        }

        void OnLoaded(object sender, object e)
        {
            //To let the framework discover the access keys, the elements should be realized
            //on the visual tree. If there are no elements in the visual
            //tree with access key, the framework won't raise the events.
            //In this sample, if you define the Pivot as collapsed on the constructor, the Pivot
            //will have a lazy loading and the access keys won't be enabled.
            //For this reason, we make it visible when creating the object
            //and we collapse it when we load the page.
            MyPivot.Visibility = Visibility.Collapsed;
        }

        void OnAccessKeyInvoked(UIElement sender, AccessKeyInvokedEventArgs args)
        {
            args.Handled = true;
            MyPivot.SelectedItem = sender as PivotItem;
        }
        void OnDisplayModeEnabledChanged(object sender, object e)
        {
            if (AccessKeyManager.IsDisplayModeEnabled)
            {
                MyPivot.Visibility = Visibility.Visible;
            }
            else
            {
                MyPivot.Visibility = Visibility.Collapsed;

            }
        }

        DependencyObject AdjustTarget(UIElement sender)
        {
            DependencyObject target = sender;
            if (sender is PivotItem)
            {
                PivotItem pivotItem = target as PivotItem;
                target = (sender as PivotItem).Header as TextBlock;
            }
            return target;
        }

        void OnAccessKeyDisplayRequested(UIElement sender, AccessKeyDisplayRequestedEventArgs args)
        {
            DependencyObject target = AdjustTarget(sender);
            var tooltip = ToolTipService.GetToolTip(target) as ToolTip;

            if (tooltip == null)
            {
                tooltip = new ToolTip();
                tooltip.Background = new SolidColorBrush(Windows.UI.Colors.Black);
                tooltip.Foreground = new SolidColorBrush(Windows.UI.Colors.White);
                tooltip.Padding = new Thickness(4, 4, 4, 4);
                tooltip.VerticalOffset = -20;
                tooltip.Placement = PlacementMode.Bottom;
                ToolTipService.SetToolTip(target, tooltip);
            }

            if (string.IsNullOrEmpty(args.PressedKeys))
            {
                tooltip.Content = sender.AccessKey;
            }
            else
            {
                tooltip.Content = sender.AccessKey.Remove(0, args.PressedKeys.Length);
            }

            tooltip.IsOpen = true;
        }
        void OnAccessKeyDisplayDismissed(UIElement sender, AccessKeyDisplayDismissedEventArgs args)
        {
            DependencyObject target = AdjustTarget(sender);

            var tooltip = ToolTipService.GetToolTip(target) as ToolTip;
            if (tooltip != null)
            {
                tooltip.IsOpen = false;
                //Fix to avoid show tooltip with mouse
                ToolTipService.SetToolTip(target, null);
            }
        }
    }
```

