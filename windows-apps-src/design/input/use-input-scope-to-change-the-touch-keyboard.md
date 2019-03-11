---
Description: ユーザーがタッチ キーボード、つまりソフト入力パネル (SIP) でデータを入力できるように、ユーザーが入力すると予想されるデータの種類に合わせてテキスト コントロールの入力値の種類を設定できます。
MS-HAID: dev\_ctrl\_layout\_txt.use\_input\_scope\_to\_change\_the\_touch\_keyboard
MSHAttr: PreferredLib:/library/windows/apps
Search.Product: eADQiWindows 10XVcnh
title: 入力値の種類を使ったタッチ キーボードの変更
ms.assetid: 6E5F55D7-24D6-47CC-B457-B6231EDE2A71
template: detail.hbs
keywords: キーボード, アクセシビリティ, ナビゲーション, フォーカス, テキスト, 入力, ユーザーの操作
ms.date: 02/08/2017
ms.topic: article
ms.openlocfilehash: 1350c6e0eae057386fb721a358f71acb19c4efc1
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57591767"
---
# <a name="use-input-scope-to-change-the-touch-keyboard"></a>入力値の種類を使ったタッチ キーボードの変更

ユーザーがタッチ キーボード、つまりソフト入力パネル (SIP) でデータを入力できるように、ユーザーが入力すると予想されるデータの種類に合わせてテキスト コントロールの入力値の種類を設定できます。

### <a name="important-apis"></a>重要な API
- [InputScope](https://msdn.microsoft.com/library/windows/apps/hh702632)
- [inputScopeNameValue](https://msdn.microsoft.com/library/windows/apps/hh702028)


タッチ キーボードは、アプリがタッチ スクリーン付きのデバイスで実行されているときにテキスト入力に使うことができます。 タッチ キーボードは、**[TextBox](https://msdn.microsoft.com/library/windows/apps/br209683)** または **[RichEditBox](https://msdn.microsoft.com/library/windows/apps/br227548)** などの編集可能な入力フィールドをユーザーがタップしたときに呼び出されます。 ユーザーが入力すると予想されるデータの種類と一致するようにテキスト コントロールの*入力値の種類*を設定することで、ユーザーはより速く簡単にアプリでデータを入力できるようになります。 入力値の種類は、システムに対してコントロールが予期しているテキスト入力の種類のヒントとなるため、システムはその入力の種類用の特殊なタッチ キーボード レイアウトを提供できます。

たとえば、テキスト ボックスが 4 桁の PIN の入力専用である場合は、[**InputScope**](https://msdn.microsoft.com/library/windows/apps/hh702632) プロパティを **Number** に設定します。 これにより、システムに数字キーパッド レイアウトの表示が指示されるため、ユーザーは簡単に PIN を入力できます。

> [!IMPORTANT]
> - この情報は、SIP にのみ適用されます。 ハードウェア キーボードにも、Windows の簡単操作オプションで使用できるスクリーン キーボードにも適用されません。
> - 入力スコープの設定によって、入力の検証が実行されるわけではありません。また、ユーザーが、ハードウェア キーボードやその他の入力デバイスから入力できなくなることもありません。 必要に応じて、コードで入力を検証する必要があります。

## <a name="changing-the-input-scope-of-a-text-control"></a>テキスト コントロールの入力値の種類を変更する

アプリで使用可能な入力値の種類は、**[InputScopeNameValue](https://msdn.microsoft.com/library/windows/apps/hh702028)** 列挙体のメンバーです。  **[TextBox](https://msdn.microsoft.com/library/windows/apps/br209683)** または **[RichEditBox](https://msdn.microsoft.com/library/windows/apps/br227548)** の **InputScope** プロパティを、これらの値のいずれかに設定できます。

> [!IMPORTANT]
> **[InputScope](https://msdn.microsoft.com/library/windows/apps/dn996570)** プロパティ**[PasswordBox](https://msdn.microsoft.com/library/windows/apps/br227519)** のみをサポート、**パスワード**と**NumericPin**値。 それ以外の値はすべて無視されます。

ここでは、各テキスト ボックスで予期されるデータと一致するように、いくつかのテキスト ボックスの入力値の種類を変更します。

**入力 XAML にスコープを変更するには**

1.  ページの XAML ファイルで、変更するテキスト コントロールのタグを見つけます。
2.  [  **InputScope**](https://msdn.microsoft.com/library/windows/apps/hh702632) 属性をタグに追加し、予期される入力に一致する [**InputScopeNameValue**](https://msdn.microsoft.com/library/windows/apps/hh702028) 値を指定します。

    次に示すのは、一般的な顧客の連絡先フォームに表示されるテキスト ボックスです。 [  **InputScope**](https://msdn.microsoft.com/library/windows/apps/hh702632) を設定すると、各テキスト ボックスに、データに適切なレイアウトのタッチ キーボードが表示されます。

    ```xaml
    <StackPanel Width="300">
        <TextBox Header="Name" InputScope="Default"/>
        <TextBox Header="Email Address" InputScope="EmailSmtpAddress"/>
        <TextBox Header="Telephone Number" InputScope="TelephoneNumber"/>
        <TextBox Header="Web site" InputScope="Url"/>
    </StackPanel>
    ```

**コードの入力スコープを変更するには**

1.  ページの XAML ファイルで、変更するテキスト コントロールのタグを見つけます。 設定されていない場合は、[x: Name 属性](https://msdn.microsoft.com/library/windows/apps/mt204788) を設定します。これで、コード内でコントロールを参照できます。

    ```csharp
    <TextBox Header="Telephone Number" x:Name="phoneNumberTextBox"/>
    ```

2.  新しい [**InputScope**](https://msdn.microsoft.com/library/windows/apps/hh702025) オブジェクトをインスタンス化します。

    ```csharp
    InputScope scope = new InputScope();
    ```

3.  新しい [**InputScopeName**](https://msdn.microsoft.com/library/windows/apps/hh702027) オブジェクトをインスタンス化します。
    
    ```csharp
    InputScopeName scopeName = new InputScopeName();
    ```

4.  [  **InputScopeName**](https://msdn.microsoft.com/library/windows/apps/hh702027) オブジェクトの [**NameValue**](https://msdn.microsoft.com/library/windows/apps/hh702032) プロパティを [**InputScopeNameValue**](https://msdn.microsoft.com/library/windows/apps/hh702028) 列挙体の値に設定します。

    ```csharp
    scopeName.NameValue = InputScopeNameValue.TelephoneNumber;
    ```

5.  [  **InputScope**](https://msdn.microsoft.com/library/windows/apps/hh702025) オブジェクトの [**Names**](https://msdn.microsoft.com/library/windows/apps/hh702034) コレクションに [**InputScopeName**](https://msdn.microsoft.com/library/windows/apps/hh702027) オブジェクトを追加します。

    ```csharp
    scope.Names.Add(scopeName);
    ```

6.  [  **InputScope**](https://msdn.microsoft.com/library/windows/apps/hh702025) オブジェクトを、テキスト コントロールの [**InputScope**](https://msdn.microsoft.com/library/windows/apps/hh702632) プロパティの値として設定します。

    ```csharp
    phoneNumberTextBox.InputScope = scope;
    ```

コード全体を次に示します。

```CSharp
InputScope scope = new InputScope();
InputScopeName scopeName = new InputScopeName();
scopeName.NameValue = InputScopeNameValue.TelephoneNumber;
scope.Names.Add(scopeName);
phoneNumberTextBox.InputScope = scope;
```

同じ手順を、次の短縮形のコードにまとめることもできます。

```CSharp
phoneNumberTextBox.InputScope = new InputScope() 
{
    Names = {new InputScopeName(InputScopeNameValue.TelephoneNumber)}
};
```

## <a name="text-prediction-spell-checking-and-auto-correction"></a>予測入力、スペル チェック、および自動修正

[  **TextBox**](https://msdn.microsoft.com/library/windows/apps/br209683) コントロールと [**RichEditBox**](https://msdn.microsoft.com/library/windows/apps/br227548) コントロールには、SIP の動作に影響を与えるプロパティがいくつかあります。 ユーザーに最適なエクスペリエンスを提供するには、これらのプロパティが、タッチ操作を使用したテキスト入力に与える影響を理解しておく必要があります。

-   [**IsSpellCheckEnabled**](https://msdn.microsoft.com/library/windows/apps/br209688): コントロールが、認識されない語をマークする、システムのスペル チェック エンジンと対話とき、テキスト コントロールでスペル チェックを有効にします。 単語をタップすると、修正候補の一覧を表示できます。 スペル チェック オプションは既定で有効になっています。

    入力値の種類が **Default** である場合、このプロパティを使用すると、文字列を入力するときに、文の最初の単語に対する大文字の自動設定および単語の自動修正が有効になります。 これらの自動修正機能は、他の入力値の種類では無効である場合があります。 詳しくは、このトピックの後半にある表をご覧ください。

-   [**IsTextPredictionEnabled**](https://msdn.microsoft.com/library/windows/apps/br209690)-システムが単語入力を開始する可能性があることの一覧を表示するテキスト コントロールのテキストの予測を有効にします。 一覧から選択できるため、単語全体を入力しなくても済みます。 予測入力は既定で有効になっています。

    入力値の種類が **Default** 以外のとき、[**IsTextPredictionEnabled**](https://msdn.microsoft.com/library/windows/apps/br209690) プロパティが **true** であっても、予測入力が無効になる場合があります。 詳しくは、このトピックの後半にある表をご覧ください。

-   [**PreventKeyboardDisplayOnProgrammaticFocus**](https://msdn.microsoft.com/library/windows/apps/dn299273): このプロパティが**true**が原因でシステムのテキスト コントロールにフォーカスをプログラムで設定すると、SIP を表示します。 代わりに、ユーザーがコントロールで操作するときにだけ、キーボードが表示されます。

## <a name="touch-keyboard-index-for-windows"></a>Windows のタッチ キーボードのインデックス

これらのテーブルでは、一般的な入力スコープの値を Windows のソフト入力パネル (SIP) のレイアウトを表示します。 **IsSpellCheckEnabled** プロパティや **IsTextPredictionEnabled** プロパティによって有効になっている機能に対する入力値の種類の影響が、入力値の種類ごとに説明されています。 これは、利用できる入力値の種類をすべて示したものではありません。

> [!Tip] 
> キーを押して、アルファベットのレイアウトと数字と記号のレイアウトの間のほとんどのタッチ キーボードを切り替えることができます、 **123 &** に数字と記号のレイアウトとキーを押して変更をキー、 **abcd**キーアルファベット順のレイアウトに変更します。

### <a name="default"></a>Default

`<TextBox InputScope="Default"/>`

既定の Windows はタッチ キーボードです。

![既定の Windows タッチ キーボード](images/input-scopes/default.png)
- スペル チェック: **IsSpellCheckEnabled** = **true** の場合は有効、**IsSpellCheckEnabled** = **false** の場合は無効
- 自動修正: **IsSpellCheckEnabled** = **true** の場合は有効、**IsSpellCheckEnabled** = **false** の場合は無効
- 大文字の自動設定: **IsSpellCheckEnabled** = **true** の場合は有効、**IsSpellCheckEnabled** = **false** の場合は無効
- 予測入力: **IsTextPredictionEnabled** = **true** の場合は有効、**IsTextPredictionEnabled** = **false** の場合は無効

### <a name="currencyamountandsymbol"></a>CurrencyAmountAndSymbol

`<TextBox InputScope="CurrencyAmountAndSymbol"/>`

既定の数字と記号のキーボード レイアウト。

![通貨用 Windows タッチ キーボード](images/input-scopes/currencyamountandsymbol.png)

- 複数のシンボルを表示するページの左/右キーが含まれています
- スペル チェック: 既定では有効だが、無効にすることも可能
- 自動修正: 既定では有効だが、無効にすることも可能
- 大文字の自動設定: 常に無効
- 予測入力: 既定では有効だが、無効にすることも可能
 
### <a name="url"></a>Url

`<TextBox InputScope="Url"/>`

![URL 用 Windows タッチ キーボード](images/input-scopes/url.png)

- **.com** キーと ![Go キー](images/input-scopes/kbdgokey.png) (Go) キーがあります。 長押しし、 **.com**追加のオプションを表示するキー (**.org**、 **.net**、およびリージョン固有のサフィックスを)
- 含まれています、 **:**、 **-**、および**/** キー
- スペル チェック: 既定では無効だが、有効にすることも可能
- 自動修正: 既定では無効だが、有効にすることも可能
- 大文字の自動設定: 既定では無効だが、有効にすることも可能
- 予測入力: 既定では無効だが、有効にすることも可能


### <a name="emailsmtpaddress"></a>EmailSmtpAddress

`<TextBox InputScope="EmailSmtpAddress"/>`

![メール アドレス用の Windows タッチ キーボード](images/input-scopes/emailsmtpaddress.png)
- **@**  キーと **.com** キーがあります。 長押しし、 **.com**追加のオプションを表示するキー (**.org**、 **.net**、およびリージョン固有のサフィックスを)
- 含まれています、 **_** と**-** キー
- スペル チェック: 既定では無効だが、有効にすることも可能
- 自動修正: 既定では無効だが、有効にすることも可能
- 大文字の自動設定: 既定では無効だが、有効にすることも可能
- 予測入力: 既定では無効だが、有効にすることも可能


### <a name="number"></a>数値

`<TextBox InputScope="Number"/>`

![電話番号用 Windows タッチ キーボード](images/input-scopes/number.png)
- スペル チェック: 既定では有効だが、無効にすることも可能
- 自動修正: 既定では有効だが、無効にすることも可能
- 大文字の自動設定: 常に無効
- 予測入力: 既定では有効だが、無効にすることも可能

### <a name="telephonenumber"></a>TelephoneNumber

`<TextBox InputScope="TelephoneNumber"/>`

![電話番号用 Windows タッチ キーボード](images/input-scopes/telephonenumber.png)
- スペル チェック: 既定では有効だが、無効にすることも可能
- 自動修正: 既定では有効だが、無効にすることも可能
- 大文字の自動設定: 常に無効
- 予測入力: 既定では有効だが、無効にすることも可能

### <a name="search"></a>検索

`<TextBox InputScope="Search"/>`

![検索用 Windows タッチ キーボード](images/input-scopes/search.png)
- 含まれています、**検索**キーの代わりに、 **Enter**キー
- スペル チェック: 既定では有効だが、無効にすることも可能
- 自動修正: 既定では有効だが、無効にすることも可能
- 大文字の自動設定: 常に無効
- 予測入力: 既定では有効だが、無効にすることも可能

### <a name="searchincremental"></a>SearchIncremental

`<TextBox InputScope="SearchIncremental"/>`

![インクリメンタル検索を Windows タッチ キーボード](images/input-scopes/searchincremental.png)
- 同じレイアウト**既定**
- スペル チェック: 既定では無効だが、有効にすることも可能
- 自動修正: 常に無効
- 大文字の自動設定: 常に無効
- 予測入力: 常に無効

### <a name="formula"></a>Formula

`<TextBox InputScope="Formula"/>`

![式の Windows のタッチ キーボード](images/input-scopes/formula.png)
- 含まれています、 **=** キー
- 含まれています、 **%**、 **$**、および**+** キー
- スペル チェック: 既定では有効だが、無効にすることも可能
- 自動修正: 既定では有効だが、無効にすることも可能
- 大文字の自動設定: 常に無効
- 予測入力: 既定では有効だが、無効にすることも可能

### <a name="chat"></a>Chat

`<TextBox InputScope="Chat"/>`

![既定の Windows タッチ キーボード](images/input-scopes/default.png)
- 同じレイアウト**既定**
- スペル チェック: 既定では有効だが、無効にすることも可能
- 自動修正: 既定では有効だが、無効にすることも可能
- 大文字の自動設定: 既定では有効だが、無効にすることも可能
- 予測入力: 既定では有効だが、無効にすることも可能

### <a name="nameorphonenumber"></a>NameOrPhoneNumber

`<TextBox InputScope="NameOrPhoneNumber"/>`

![既定の Windows タッチ キーボード](images/input-scopes/default.png)
- 同じレイアウト**既定**
- スペル チェック: 既定では無効だが、有効にすることも可能
- 自動修正: 既定では無効だが、有効にすることも可能
- 大文字の自動: オフ、既定で有効にできます (各単語の最初の文字が大文字で入力)
- 予測入力: 既定では無効だが、有効にすることも可能
