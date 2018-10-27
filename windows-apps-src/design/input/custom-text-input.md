---
author: Karl-Bridge-Microsoft
Description: The core text APIs in the Windows.UI.Text.Core namespace enable a Universal Windows Platform (UWP) app to receive text input from any text service supported on Windows devices.
title: カスタム テキスト入力の概要
ms.assetid: 58F5F7AC-6A4B-45FC-8C2A-942730FD7B74
label: Custom text input
template: detail.hbs
keywords: キーボード, テキスト, 基本的なテキスト, カスタム テキスト, テキスト サービス フレームワーク, 入力, ユーザー操作
ms.author: kbridge
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 14a2811f59b8de33db51b255aee8892abf553198
ms.sourcegitcommit: 086001cffaf436e6e4324761d59bcc5e598c15ea
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/27/2018
ms.locfileid: "5689740"
---
# <a name="custom-text-input"></a>カスタム テキスト入力



[**Windows.UI.Text.Core**](https://msdn.microsoft.com/library/windows/apps/dn958238) 名前空間の基本的なテキスト API によって、ユニバーサル Windows プラットフォーム (UWP) アプリは、Windows デバイスでサポートされている任意のテキスト サービスからテキスト入力を受け取ることができます。 この API は、アプリがテキスト サービスの詳細を認識している必要がないという点で、[テキスト サービス フレームワーク](https://msdn.microsoft.com/library/windows/desktop/ms629032) API に似ています。 これにより、アプリは、キーボード、音声、ペンなどのすべての種類の入力から、テキストを任意の言語で受け取ることができます。

> **重要な API**: [**Windows.UI.Text.Core**](https://msdn.microsoft.com/library/windows/apps/dn958238)、[**CoreTextEditContext**](https://msdn.microsoft.com/library/windows/apps/dn958158)

## <a name="why-use-core-text-apis"></a>基本的なテキスト API を使う理由


多くのアプリでは、テキストの入力や編集には XAML や HTML のテキスト ボックス コントロールで十分です。 ただし、ワード プロセッシング アプリなど、アプリでテキストの複雑なシナリオを処理する場合は、柔軟なカスタム テキスト編集コントロールが必要になる可能性があります。 [**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) キーボード API を使ってテキスト編集コントロールを作成できますが、これらは、東アジアの言語をサポートするために必要なコンポジション ベースのテキスト入力を受け取る方法を提供しません。

カスタム テキスト編集コントロールを作成する必要がある場合は、代わりに [**Windows.UI.Text.Core**](https://msdn.microsoft.com/library/windows/apps/dn958238) API を使います。 これらの API は、任意の言語でのテキスト入力の処理において高い柔軟性を実現するように設計されており、アプリに最適なテキスト エクスペリエンスを提供できます。 基本的なテキスト API に組み込まれているテキスト入力および編集コントロールは、Windows デバイスでの既存のすべてのテキスト入力方式からテキスト入力を受け取ることができます。これには、[テキスト サービス フレームワーク](https://msdn.microsoft.com/library/windows/desktop/ms629032) ベースの入力方式エディター (IME) や PC での手書き入力、モバイル デバイスでの WordFlow キーボード (自動修正、予測入力、ディクテーションを提供する) が含まれます。

## <a name="architecture"></a>アーキテクチャ


テキスト入力システムの単純な例を次に示します。

-   "アプリケーション" は、基本的なテキスト API を使って構築されたカスタム編集コントロールをホストする UWP アプリを表します。
-   [**Windows.UI.Text.Core**](https://msdn.microsoft.com/library/windows/apps/dn958238) API は、Windows 経由でのテキスト サービスとの通信を容易にします。 テキスト編集コントロールとテキスト サービス間の通信は、主に [**CoreTextEditContext**](https://msdn.microsoft.com/library/windows/apps/dn958158) オブジェクトによって処理されます。このオブジェクトが通信を容易にするメソッドとイベントを提供します。

![基本的なテキストのアーキテクチャ図](images/coretext/architecture.png)

## <a name="text-ranges-and-selection"></a>テキスト範囲と選択範囲


編集コントロールはテキスト入力用の領域を提供し、ユーザーはこの領域の任意の場所でテキストを編集できることを期待しています。 ここでは、基本的なテキスト API で使用されるテキスト配置システムについて説明します。また、範囲と選択範囲がこのシステムでどのように表現されるかについても説明します。

### <a name="application-caret-position"></a>アプリケーションのカーソル位置

基本的なテキスト API で使用されるテキスト範囲は、カーソル位置の観点で表されます。 "アプリケーション カーソル位置 (ACP)" は、次に示すように、カーソルの直前にあるテキスト ストリームの先頭からの文字数を示す 0 から始まる数値です。

![テキスト ストリームの例の図](images/coretext/stream-1.png)
### <a name="text-ranges-and-selection"></a>テキスト範囲と選択範囲

テキスト範囲と選択範囲は、次の 2 つのフィールドが含まれる [**CoreTextRange**](https://msdn.microsoft.com/library/windows/apps/dn958201) 構造体で表されます。

| フィールド                  | データ型                                                                 | 説明                                                                      |
|------------------------|---------------------------------------------------------------------------|----------------------------------------------------------------------------------|
| **StartCaretPosition** | **Number** \[JavaScript\] | **System.Int32** \[.NET\] | **int32** \[C++\] | 範囲の開始位置は、最初の文字の直前の ACP です。 |
| **EndCaretPosition**   | **Number** \[JavaScript\] | **System.Int32** \[.NET\] | **int32** \[C++\] | 範囲の終了位置は、最後の文字の直後の ACP です。     |

 

たとえば、前に示したテキスト範囲で、範囲 \[0, 5\] は "Hello" という単語を指します。 **StartCaretPosition** は、常に **EndCaretPosition** 以下である必要があります。 範囲 \[5, 0\] は無効です。

### <a name="insertion-point"></a>挿入ポイント

現在のカーソル位置は挿入ポイントとも呼ばれ、**StartCaretPosition** を **EndCaretPosition** と等しくなるように設定することによって表されます。

### <a name="noncontiguous-selection"></a>連続しない選択範囲

一部の編集コントロールでは、連続しない選択範囲がサポートされます。 たとえば、Microsoft Office アプリでは任意の複数の選択範囲がサポートされ、多くのソース コード エディターでは列の選択がサポートされています。 ただし、基本的なテキスト API では連続しない選択範囲はサポートされません。 編集コントロールは、1 つ連続した選択範囲のみをレポートする必要があります。これは通常、連続しない選択範囲のアクティブな下位範囲です。

たとえば、次のようなテキスト ストリームがあるとします。

![テキスト ストリームの例の図](images/coretext/stream-2.png) \[0, 1\] と \[6, 11\] の 2 つの選択範囲があります。 編集コントロールは、\[0, 1\] と \[6, 11\] のいずれか一方のみをレポートする必要があります。

## <a name="working-with-text"></a>テキストの操作


[**CoreTextEditContext**](https://msdn.microsoft.com/library/windows/apps/dn958158) クラスの [**TextUpdating**](https://msdn.microsoft.com/library/windows/apps/dn958176) イベント、[**TextRequested**](https://msdn.microsoft.com/library/windows/apps/dn958175) イベント、[**NotifyTextChanged**](https://msdn.microsoft.com/library/windows/apps/dn958172) メソッドによって、Windows と編集コントロールとの間でのテキスト フローを実現できます。

編集コントロールは、ユーザーがキーボード、音声、IME などのテキスト入力方式を操作したときに生成される [**TextUpdating**](https://msdn.microsoft.com/library/windows/apps/dn958176) イベントによってテキストを受け取ります。

テキストをコントロールに貼り付けるなどの方法で、編集コントロールでテキストを変更する場合、[**NotifyTextChanged**](https://msdn.microsoft.com/library/windows/apps/dn958172) を呼び出して Windows に通知する必要があります。

テキスト サービスが新しいテキストを必要とする場合、[**TextRequested**](https://msdn.microsoft.com/library/windows/apps/dn958175) イベントが発生します。 **TextRequested** イベント ハンドラーで、新しいテキストを提供する必要があります。

### <a name="accepting-text-updates"></a>テキストの更新の受け付け

編集コントロールでは、通常、テキストの更新要求を受け付ける必要があります。これらは、ユーザーが入力するテキストを表しているためです。 [**TextUpdating**](https://msdn.microsoft.com/library/windows/apps/dn958176) イベント ハンドラーでは、編集コントロールの次の操作が想定されています。

1.  [**CoreTextTextUpdatingEventArgs.Text**](https://msdn.microsoft.com/library/windows/apps/dn958236) で指定されたテキストを、[**CoreTextTextUpdatingEventArgs.Range**](https://msdn.microsoft.com/library/windows/apps/dn958234) で指定された位置に挿入します。
2.  [**CoreTextTextUpdatingEventArgs.NewSelection**](https://msdn.microsoft.com/library/windows/apps/dn958233) で指定された位置に選択範囲を配置します。
3.  [**CoreTextTextUpdatingEventArgs.Result**](https://msdn.microsoft.com/library/windows/apps/dn958235) を [**CoreTextTextUpdatingResult.Succeeded**](https://msdn.microsoft.com/library/windows/apps/dn958237) に設定することによって、更新が成功したことをシステムに通知します。

たとえば、これは、ユーザーが "d" を入力する前の編集コントロールの状態です。 挿入ポイントは \[10, 10\] にあります。

![テキスト ストリームの例の図](images/coretext/stream-3.png) ユーザーが "d" を入力すると、次の [**CoreTextTextUpdatingEventArgs**](https://msdn.microsoft.com/library/windows/apps/dn958229) データを使って、[**TextUpdating**](https://msdn.microsoft.com/library/windows/apps/dn958176) イベントが発生します。

-   [**Range**](https://msdn.microsoft.com/library/windows/apps/dn958234) = \[10, 10\]
-   [**Text**](https://msdn.microsoft.com/library/windows/apps/dn958236) = "d"
-   [**NewSelection**](https://msdn.microsoft.com/library/windows/apps/dn958233) = \[11, 11\]

編集コントロールで、指定された変更を適用し、[**Result**](https://msdn.microsoft.com/library/windows/apps/dn958235) を **Succeeded** に設定します。 変更が適用された後のコントロールの状態は、次のようになります。

![テキスト ストリームの例の図](images/coretext/stream-4.png)
### <a name="rejecting-text-updates"></a>テキストの更新の拒否

要求された範囲が編集コントロールの変更してはいけない領域にある場合、テキストの更新を適用できないことがあります。 この場合、変更を適用しないでください。 代わりに、[**CoreTextTextUpdatingEventArgs.Result**](https://msdn.microsoft.com/library/windows/apps/dn958235) を [**CoreTextTextUpdatingResult.Failed**](https://msdn.microsoft.com/library/windows/apps/dn958237) に設定することによって、更新が失敗したことをシステムに通知します。

たとえば、電子メール アドレスのみを受け付ける編集コントロールがあるとします。 電子メール アドレスにスペースを含めることはできないため、スペースは拒否する必要があります。そのため、Space キーについて [**TextUpdating**](https://msdn.microsoft.com/library/windows/apps/dn958176) イベントが発生した場合は、編集コントロールで単に [**Result**](https://msdn.microsoft.com/library/windows/apps/dn958235) を **Failed** に設定する必要があります。

### <a name="notifying-text-changes"></a>テキストの変更の通知

テキストの貼り付けや自動修正などが行われた場合に、編集コントロールのテキストが変更されることがあります。 このような場合、[**NotifyTextChanged**](https://msdn.microsoft.com/library/windows/apps/dn958172) を呼び出すことによって、これらの変更をテキスト サービスに通知する必要があります。

たとえば、これは、ユーザーが "World" を貼り付ける前の編集コントロールの状態です。 挿入ポイントは \[6, 6\] にあります。

![テキスト ストリームの例の図](images/coretext/stream-5.png) ユーザーが貼り付け操作を実行すると、編集コントロールのテキストは次のようになります。

![テキスト ストリームの例の図](images/coretext/stream-4.png) この場合、次の引数を使って、[**NotifyTextChanged**](https://msdn.microsoft.com/library/windows/apps/dn958172) を呼び出す必要があります。

-   *modifiedRange* = \[6, 6\]
-   *newLength* = 5
-   *newSelection* = \[11, 11\]

1 つまたは複数の [**TextRequested**](https://msdn.microsoft.com/library/windows/apps/dn958175) イベントが発生し、これを処理することによって、テキスト サービスが操作しているテキストを更新します。

### <a name="overriding-text-updates"></a>テキストの更新の上書き

編集コントロールで、自動修正機能を提供するために、テキストの更新を上書きすることが必要になる場合があります。

たとえば、短縮形を正式なつづりにする修正機能を提供する編集コントロールがあるとします。 ユーザーが Space キーを押して修正機能をトリガーする前の編集コントロールの状態は、次のようになっています。 挿入ポイントは \[3, 3\] にあります。

![テキスト ストリームの例の図](images/coretext/stream-6.png) ユーザーが Space キーを押すと、対応する [**TextUpdating**](https://msdn.microsoft.com/library/windows/apps/dn958176) イベントが発生します。 編集コントロールは、テキストの更新を受け付けます。 修正が完了する直前の編集コントロールの状態は、次のようになります。 挿入ポイントは \[4, 4\] にあります。

![テキスト ストリームの例の図](images/coretext/stream-7.png) [**TextUpdating**](https://msdn.microsoft.com/library/windows/apps/dn958176) イベント ハンドラーの外部で、編集コントロールは次の修正を実行します。 修正が完了した後の編集コントロールの状態は、次のようになります。 挿入ポイントは \[5, 5\] にあります。

![テキスト ストリームの例の図](images/coretext/stream-8.png) この場合、次の引数を使って、[**NotifyTextChanged**](https://msdn.microsoft.com/library/windows/apps/dn958172) を呼び出す必要があります。

-   *modifiedRange* = \[1, 2\]
-   *newLength* = 2
-   *newSelection* = \[5, 5\]

1 つまたは複数の [**TextRequested**](https://msdn.microsoft.com/library/windows/apps/dn958175) イベントが発生し、これを処理することによって、テキスト サービスが操作しているテキストを更新します。

### <a name="providing-requested-text"></a>要求されたテキストの提供

テキスト サービスでは、自動修正や予測入力などの機能を提供する場合、正しいテキストがあることが重要です。特に、ドキュメントの読み込みなどから編集コントロールに既に存在しているテキストや、前のセクションで説明したように編集コントロールによって挿入されたテキストについて重要です。 そのため、[**TextRequested**](https://msdn.microsoft.com/library/windows/apps/dn958175) イベントが発生するたびに、現在編集コントロール内にあり、指定された範囲のテキストを提供する必要があります。

[**CoreTextTextRequest**](https://msdn.microsoft.com/library/windows/apps/dn958221) 内の [**Range**](https://msdn.microsoft.com/library/windows/apps/dn958227) が、編集コントロールでそのまま格納できない範囲を指定する場合があります。 たとえば、[**TextRequested**](https://msdn.microsoft.com/library/windows/apps/dn958175) イベントの発生時に **Range** が編集コントロールのサイズよりも大きい場合や、**Range** の最後が範囲外である場合です。 このような場合は、何か適切な範囲を返す必要があります。通常、これは要求された範囲のサブセットです。

## <a name="related-articles"></a>関連記事

**サンプル**
* [カスタム編集コントロールのサンプル](https://go.microsoft.com/fwlink/?linkid=831024)
**サンプルのアーカイブ**
* [XAML テキスト編集のサンプルに関するページ](http://go.microsoft.com/fwlink/p/?LinkID=251417)


