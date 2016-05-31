---
author: Karl-Bridge-Microsoft
Description: ユーザーがタッチ キーボード、つまりソフト入力パネル (SIP) でデータを入力できるように、ユーザーが入力すると予想されるデータの種類に合わせてテキスト コントロールの入力値の種類を設定できます。
MS-HAID: 'dev\_ctrl\_layout\_txt.use\_input\_scope\_to\_change\_the\_touch\_keyboard'
MSHAttr: 'PreferredLib:/library/windows/apps'
Search.Product: eADQiWindows 10XVcnh
title: 入力値の種類を使ったタッチ キーボードの変更
ms.assetid: 6E5F55D7-24D6-47CC-B457-B6231EDE2A71
template: detail.hbs
---

# 入力値の種類を使ったタッチ キーボードの変更

ユーザーがタッチ キーボード、つまりソフト入力パネル (SIP) でデータを入力できるように、ユーザーが入力すると予想されるデータの種類に合わせてテキスト コントロールの入力スコープを設定できます。

**重要な API**

-   [**InputScope**](https://msdn.microsoft.com/library/windows/apps/hh702632)
-   [**InputScopeNameValue**](https://msdn.microsoft.com/library/windows/apps/hh702028)



タッチ キーボードは、アプリがタッチ スクリーン付きのデバイスで実行されているときにテキスト入力に使うことができます。 タッチ キーボードは、[**TextBox**](https://msdn.microsoft.com/library/windows/apps/br209683) または [**RichEditBox**](https://msdn.microsoft.com/library/windows/apps/br227548) などの編集可能な入力フィールドをユーザーがタップしたときに呼び出されます。 ユーザーが入力すると予想されるデータの種類と一致するようにテキスト コントロールの*入力値の種類*を設定することで、ユーザーはより速く簡単にアプリでデータを入力できるようになります。 入力値の種類は、システムに対してコントロールが予期しているテキスト入力の種類のヒントとなるため、システムはその入力の種類用の特殊なタッチ キーボード レイアウトを提供できます。

たとえば、テキスト ボックスが 4 桁の PIN の入力専用である場合は、[**InputScope**](https://msdn.microsoft.com/library/windows/apps/hh702632) プロパティを **Number** に設定します。 これにより、システムに数字キーパッド レイアウトの表示が指示されるため、ユーザーは簡単に PIN を入力できます。

> **重要**&nbsp;&nbsp;
- この情報は、SIP にのみ適用されます。 ハードウェア キーボードにも、Windows の簡単操作オプションで使用できるスクリーン キーボードにも適用されません。
- 入力値の種類の設定によって、入力の検証が実行されるわけではありません。また、ユーザーが、ハードウェア キーボードやその他の入力デバイスから入力できなくなることもありません。 必要に応じて、コードで入力を検証する必要があります。

## テキスト コントロールの入力値の種類を変更する

アプリで使用可能な入力値の種類は、[**InputScopeNameValue**](https://msdn.microsoft.com/library/windows/apps/hh702028) 列挙体のメンバーです。 [
            **TextBox**](https://msdn.microsoft.com/library/windows/apps/br209683) または [**RichEditBox**](https://msdn.microsoft.com/library/windows/apps/br227548) の **InputScope** プロパティを、これらの値のいずれかに設定できます。

> **重要**
            &nbsp;&nbsp;[**PasswordBox**](https://msdn.microsoft.com/library/windows/apps/br227519) の [**InputScope**](https://msdn.microsoft.com/library/windows/apps/dn996570) プロパティは、**Password** 値と **NumericPin** 値のみをサポートします。 それ以外の値はすべて無視されます。

ここでは、各テキスト ボックスで予期されるデータと一致するように、いくつかのテキスト ボックスの入力値の種類を変更します。

**XAML の入力値の種類を変更するには**

1.  ページの XAML ファイルで、変更するテキスト コントロールのタグを見つけます。
2.  [
            **InputScope**](https://msdn.microsoft.com/library/windows/apps/hh702632) 属性をタグに追加し、予期される入力に一致する [**InputScopeNameValue**](https://msdn.microsoft.com/library/windows/apps/hh702028) 値を指定します。

    次に示すのは、一般的な顧客の連絡先フォームに表示されるテキスト ボックスです。 [
            **InputScope**](https://msdn.microsoft.com/library/windows/apps/hh702632) を設定すると、各テキスト ボックスに、データに適切なレイアウトのタッチ キーボードが表示されます。

    ```xaml
    <StackPanel Width="300">
        <TextBox Header="Name" InputScope="Default"/>
        <TextBox Header="Email Address" InputScope="EmailSmtpAddress"/>
        <TextBox Header="Telephone Number" InputScope="TelephoneNumber"/>
        <TextBox Header="Web site" InputScope="Url"/>
    </StackPanel>
    ```

**コードの入力値の種類を変更するには**

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

4.  [
            **InputScopeName**](https://msdn.microsoft.com/library/windows/apps/hh702027) オブジェクトの [**NameValue**](https://msdn.microsoft.com/library/windows/apps/hh702032) プロパティを [**InputScopeNameValue**](https://msdn.microsoft.com/library/windows/apps/hh702028) 列挙体の値に設定します。

    ```csharp
    scopeName.NameValue = InputScopeNameValue.TelephoneNumber;
    ```

5.  [
            **InputScope**](https://msdn.microsoft.com/library/windows/apps/hh702025) オブジェクトの [**Names**](https://msdn.microsoft.com/library/windows/apps/hh702034) コレクションに [**InputScopeName**](https://msdn.microsoft.com/library/windows/apps/hh702027) オブジェクトを追加します。

    ```csharp
    scope.Names.Add(scopeName);
    ```

6.  [
            **InputScope**](https://msdn.microsoft.com/library/windows/apps/hh702025) オブジェクトを、テキスト コントロールの [**InputScope**](https://msdn.microsoft.com/library/windows/apps/hh702632) プロパティの値として設定します。

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

## 予測入力、スペル チェック、および自動修正

[
            **TextBox**](https://msdn.microsoft.com/library/windows/apps/br209683) コントロールと [**RichEditBox**](https://msdn.microsoft.com/library/windows/apps/br227548) コントロールには、SIP の動作に影響を与えるプロパティがいくつかあります。 ユーザーに最適なエクスペリエンスを提供するには、これらのプロパティが、タッチ操作を使用したテキスト入力に与える影響を理解しておく必要があります。

-   [
              **IsSpellCheckEnabled**
            ](https://msdn.microsoft.com/library/windows/apps/br209688): テキスト コントロールでスペル チェックが有効である場合、コントロールは、システムのスペル チェック エンジンと連携して、認識されない単語をマークします。 単語をタップすると、修正候補の一覧を表示できます。 スペル チェック オプションは既定で有効になっています。

    入力値の種類が **Default** である場合、このプロパティを使用すると、文字列を入力するときに、文の最初の単語に対する大文字の自動設定および単語の自動修正が有効になります。 これらの自動修正機能は、他の入力値の種類では無効である場合があります。 詳しくは、このトピックの後半にある表をご覧ください。

-   [
              **IsTextPredictionEnabled**
            ](https://msdn.microsoft.com/library/windows/apps/br209690): テキスト コントロールで予測入力が有効である場合は、入力開始時に予測される単語の一覧が表示されます。 一覧から選択できるため、単語全体を入力しなくても済みます。 予測入力は既定で有効になっています。

    入力値の種類が **Default** 以外のとき、[**IsTextPredictionEnabled**](https://msdn.microsoft.com/library/windows/apps/br209690) プロパティが **true** であっても、予測入力が無効になる場合があります。 詳しくは、このトピックの後半にある表をご覧ください。

    **注**
            &nbsp;&nbsp;モバイル デバイス ファミリでは、予測入力やスペル修正の候補が SIP のキーボードの上の領域に表示されます。 [
            **IsTextPredictionEnabled**](https://msdn.microsoft.com/library/windows/apps/br209690) が **false** に設定されている場合は、[**IsSpellCheckEnabled**](https://msdn.microsoft.com/library/windows/apps/br209688) が **true** であっても、SIP のこの部分は表示されず、自動修正が無効になります。

-   [
              **PreventKeyboardDisplayOnProgrammaticFocus**
            ](https://msdn.microsoft.com/library/windows/apps/dn299273): このプロパティが **true** の場合は、プログラムによりフォーカスがテキスト コントロールに設定されていると、SIP が表示されなくなります。 代わりに、ユーザーがコントロールで操作するときにだけ、キーボードが表示されます。

## Windows と Windows Phone のタッチ キーボード インデックス

次の各表は、一般的な入力値の種類について、デスクトップおよびモバイル デバイスのソフト入力パネル (SIP) レイアウトを示しています。 **IsSpellCheckEnabled** プロパティや **IsTextPredictionEnabled** プロパティによって有効になっている機能に対する入力値の種類の影響が、入力値の種類ごとに説明されています。 これは、利用できる入力値の種類をすべて示したものではありません。

> **注**
            &nbsp;&nbsp;モバイル デバイスの SIP はサイズが小さいため、正しい入力値の種類を設定することは、モバイル アプリで特に重要になります。 ここで示すように、Windows Phone には、さまざまな種類の特殊なキーボード レイアウトがあります。 Windows ストア アプリで入力値の種類を設定する必要のないテキスト フィールドであっても、Windows Phone ストア アプリでは、入力値の種類を設定することにより、便利になる場合があります。

> **ヒント**
            &nbsp;&nbsp;ほとんどのタッチ キーボードでは、アルファベットのレイアウトと、数字と記号のレイアウトを切り替えることができます。 Windows では、**&123** キーを切り替えます。 Windows Phone では、**&123** キーを押して、数字と記号のレイアウトに切り替え、**abcd** キーを押して、アルファベットのレイアウトに切り替えます。

### Default

`<TextBox InputScope="Default"/>`

既定のキーボード。

| Windows                                                    | Windows Phone                                                    |
|------------------------------------------------------------|------------------------------------------------------------------|
| ![既定の Windows タッチ キーボード](images/input-scopes/kbdpcdefault.png) | ![既定の Windows Phone タッチ キーボード](images/input-scopes/kbdwpdefault.png) |

機能の可用性:

-   スペル チェック: **IsSpellCheckEnabled** = **true** の場合は有効、**IsSpellCheckEnabled** = **false** の場合は無効
-   自動修正: **IsSpellCheckEnabled** = **true** の場合は有効、**IsSpellCheckEnabled** = **false** の場合は無効
-   大文字の自動設定: **IsSpellCheckEnabled** = **true** の場合は有効、**IsSpellCheckEnabled** = **false** の場合は無効
-   予測入力: **IsTextPredictionEnabled** = **true** の場合は有効、**IsTextPredictionEnabled** = **false** の場合は無効

### CurrencyAmountAndSymbol

`<TextBox InputScope="CurrencyAmountAndSymbol"/>`

既定の数字と記号のキーボード レイアウト。

| Windows                                                    | Windows Phone                                                    |
|------------------------------------------------------------|------------------------------------------------------------------|
| ![通貨用 Windows タッチ キーボード](images/input-scopes/kbdpccurrencyamountandsymbol.png)<br>その他の記号を表示するためのページの左/右キーもあります。| ![通貨用 Windows Phone タッチ キーボード](images/input-scopes/kbdwpcurrencyamountandsymbol.png) |
|機能の可用性:<ul><li>スペル チェック: 既定では有効だが、無効にすることも可能</li><li>自動修正: 常に無効</li><li>大文字の自動設定: 常に無効</li><li>予測入力: 常に無効</li></ul>**Number** および **TelephoneNumber** と同じ。 | 機能の可用性:<ul><li>スペル チェック: 既定では有効だが、無効にすることも可能</li><li>自動修正: 既定では有効だが、無効にすることも可能</li><li>大文字の自動設定: 常に無効</li><li>予測入力: 既定では有効だが、無効にすることも可能</li>| 

### Url

`<TextBox InputScope="Url"/>`

**.com** キーと ![Go キー](images/input-scopes/kbdgokey.png) (Go) キーがあります。 **.com** キーを長押しすると、追加オプション (**.org**、**.net**、地域固有のサフィックス) が表示されます。

| Windows                                                    | Windows Phone                                                    |
|------------------------------------------------------------|------------------------------------------------------------------|
| ![URL 用 Windows タッチ キーボード](images/input-scopes/kbdpcurl.png)<br>**:** キー、**-** キー、**/** キーもあります。| ![URL 用 Windows Phone タッチ キーボード](images/input-scopes/kbdwpurl.png)<br>ピリオド キーを長押しすると、追加オプション ( - + &quot; / &amp; : , ) が表示されます。 |
|機能の可用性:<ul><li>スペル チェック: 既定では有効だが、無効にすることも可能</li><li>自動修正: 既定では有効だが、無効にすることも可能</li><li>大文字の自動設定: 常に無効</li><li>予測入力: 常に無効</li></ul> | 機能の可用性:<ul><li>スペル チェック: 既定では無効だが、有効にすることも可能</li><li>自動修正: 既定では無効だが、有効にすることも可能</li><li>大文字の自動設定: 既定では無効だが、有効にすることも可能</li><li>予測入力: 既定では無効だが、有効にすることも可能</li></ul> |

### EmailSmtpAddress

`<TextBox InputScope="EmailSmtpAddress"/>`

**
            @
            ** キーと **.com** キーがあります。 **.com** キーを長押しすると、追加オプション (**.org**、**.net**、地域固有のサフィックス) が表示されます。

| Windows                                                    | Windows Phone                                                    |
|------------------------------------------------------------|------------------------------------------------------------------|
| ![メール アドレス用の Windows タッチ キーボード](images/input-scopes/kbdpcemailsmtpaddress.png)<br>**_** キーと **-** キーもあります。| ![メール アドレス用の Windows Phone タッチ キーボード](images/input-scopes/kbdwpemailsmtpaddress.png)<br>ピリオド キーを長押しすると、追加オプション ( - _ , ; ) が表示されます。 |
|機能の可用性:<ul><li>スペル チェック: 既定では有効だが、無効にすることも可能</li><li>自動修正: 既定では有効だが、無効にすることも可能</li><li>大文字の自動設定: 常に無効</li><li>予測入力: 常に無効</li></ul> | 機能の可用性:<ul><li>スペル チェック: 既定では無効だが、有効にすることも可能</li><li>自動修正: 既定では無効だが、有効にすることも可能</li><li>大文字の自動設定: 既定では無効だが、有効にすることも可能</li><li>予測入力: 既定では無効だが、有効にすることも可能</li></ul> |

### Number

`<TextBox InputScope="Number"/>`

| Windows                                                    | Windows Phone                                                    |
|------------------------------------------------------------|------------------------------------------------------------------|
| ![電話番号用 Windows タッチ キーボード](images/input-scopes/kbdpccurrencyamountandsymbol.png)| ![電話番号用 Windows Phone タッチ キーボード](images/input-scopes/kbdwpnumber.png)<br>キーボードには、数字と小数点が含まれます。 小数点キーを長押しすると、追加オプション ( , - ) が表示されます。 |
|**CurrencyAmountAndSymbol** および **TelephoneNumber** と同じ。 | 機能の可用性:<ul><li>スペル チェック: 常に無効</li><li>自動修正: 常に無効</li><li>大文字の自動設定: 常に無効</li><li>予測入力: 常に無効</li></ul> |

### TelephoneNumber

`<TextBox InputScope="TelephoneNumber"/>`

| Windows                                                    | Windows Phone                                                    |
|------------------------------------------------------------|------------------------------------------------------------------|
| ![電話番号用 Windows タッチ キーボード](images/input-scopes/kbdpccurrencyamountandsymbol.png)| ![電話番号用 Windows Phone タッチ キーボード](images/input-scopes/kbdwptelephonenumber.png)<br>キーボードは、電話のキーパッドに似ています。 ピリオド キーを長押しすると、追加オプション ( , ( ) X . ) が表示されます。 + を入力するには、0 キーを長押しします。 |
|**CurrencyAmountAndSymbol** および **TelephoneNumber** と同じ。 | 機能の可用性:<ul><li>スペル チェック: 常に無効</li><li>自動修正: 常に無効</li><li>大文字の自動設定: 常に無効</li><li>予測入力: 常に無効</li></ul> |

### Search

`<TextBox InputScope="Search"/>`

**Enter** キーの代わりに **Search** キーが含まれます。

| Windows                                                    | Windows Phone                                                    |
|------------------------------------------------------------|------------------------------------------------------------------|
| ![検索用 Windows タッチ キーボード](images/input-scopes/kbdpcsearch.png)| ![検索用 Windows Phone タッチ キーボード](images/input-scopes/kbdwpsearch.png)|
|機能の可用性:<ul><li>スペル チェック: 既定では有効だが、無効にすることも可能</li><li>自動修正: 常に無効</li><li>大文字の自動設定: 常に無効</li><li>予測入力: 既定では有効だが、無効にすることも可能</li></ul> | 機能の可用性:<ul><li>スペル チェック: 既定では有効だが、無効にすることも可能</li><li>自動修正: 既定では有効だが、無効にすることも可能</li><li>大文字の自動設定: 常に無効</li><li>予測入力: 既定では有効だが、無効にすることも可能</li></ul> |

### SearchIncremental

`<TextBox InputScope="SearchIncremental"/>`

| Windows                                                    | Windows Phone                                                    |
|------------------------------------------------------------|------------------------------------------------------------------|
| ![既定の Windows タッチ キーボード](images/input-scopes/kbdpcdefault.png)<br>**Default** と同じレイアウト。| ![既定の Windows Phone タッチ キーボード](images/input-scopes/kbdwpdefault.png)|
|機能の可用性:<ul><li>スペル チェック: 既定では無効だが、有効にすることも可能</li><li>自動修正: 常に無効</li><li>大文字の自動設定: 常に無効</li><li>予測入力: 常に無効</li></ul> | **Default** と同じ。 |

### Formula

`<TextBox InputScope="Formula"/>`

**
            =
            ** キーがあります。

| Windows                                                    | Windows Phone                                                    |
|------------------------------------------------------------|------------------------------------------------------------------|
| ![数式用 Windows タッチ キーボード](images/input-scopes/kbdpcformula.png)<br>**
            %
            ** キー、**$** キー、**+** キーもあります。| ![数式用 Windows Phone タッチ キーボード](images/input-scopes/kbdwpformula.png)<br>ピリオド キーを長押しすると、追加オプション ( - ! ? , ) が表示されます。 **
            =
            ** キーを長押しすると、追加オプション ( ( ) : &lt; &gt; ) が表示されます。 |
|機能の可用性:<ul><li>スペル チェック: 既定では無効だが、有効にすることも可能</li><li>自動修正: 常に無効</li><li>大文字の自動設定: 常に無効</li><li>予測入力: 常に無効</li></ul> | 機能の可用性:<ul><li>スペル チェック: 既定では有効だが、無効にすることも可能</li><li>自動修正: 既定では有効だが、無効にすることも可能</li><li>大文字の自動設定: 常に無効</li><li>予測入力: 既定では有効だが、無効にすることも可能</li></ul> |

### Chat

`<TextBox InputScope="Chat"/>`

| Windows                                                    | Windows Phone                                                    |
|------------------------------------------------------------|------------------------------------------------------------------|
| ![既定の Windows タッチ キーボード](images/input-scopes/kbdpcdefault.png)<br>**Default** と同じレイアウト。| ![既定の Windows Phone タッチ キーボード](images/input-scopes/kbdwpdefault.png)<br>**Default** と同じレイアウト。|
|機能の可用性:<ul><li>スペル チェック: 既定では無効だが、有効にすることも可能</li><li>自動修正: 常に無効</li><li>大文字の自動設定: 常に無効</li><li>予測入力: 常に無効</li></ul> | 機能の可用性:<ul><li>スペル チェック: 既定では有効だが、無効にすることも可能</li><li>自動修正: 既定では有効だが、無効にすることも可能</li><li>大文字の自動設定: 既定では有効だが、無効にすることも可能</li><li>予測入力: 既定では有効だが、無効にすることも可能</li></ul> |

### NameOrPhoneNumber

`<TextBox InputScope="NameOrPhoneNumber"/>`

| Windows                                                    | Windows Phone                                                    |
|------------------------------------------------------------|------------------------------------------------------------------|
| ![既定の Windows タッチ キーボード](images/input-scopes/kbdpcdefault.png)<br>**Default** と同じレイアウト。| ![名前または電話番号用 Windows Phone タッチ キーボード](images/input-scopes/kbdwpnameorphonenumber.png)<br>**;** キーと **@** キーがあります。 **
            &amp;123** キーの代わりに **123** キーがあり、これで電話のキーパッドが表示されます (**TelephoneNumber** を参照してください)。|
|機能の可用性:<ul><li>スペル チェック: 既定では有効だが、無効にすることも可能</li><li>自動修正: 常に無効</li><li>大文字の自動設定: 常に有効</li><li>予測入力: 常に無効</li></ul> | 機能の可用性:<ul><li>スペル チェック: 既定では無効だが、有効にすることも可能</li><li>自動修正: 既定では無効だが、有効にすることも可能</li><li>大文字の自動設定: 既定では無効だが、有効にすることも可能。 各単語の最初の文字を大文字にする。</li><li>予測入力: 既定では無効だが、有効にすることも可能</li></ul> |


<!--HONumber=May16_HO2-->


