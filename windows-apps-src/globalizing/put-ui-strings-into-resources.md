---
author: DelfCo
Description: "UI の文字列リソースをリソース ファイルに格納します。 その後、これらの文字列をコードやマークアップから参照できます。"
title: "UI 文字列をリソースに格納する"
ms.assetid: E420B9BB-C0F6-4EC0-BA3A-BA2875B69722
label: Put UI strings into resources
template: detail.hbs
translationtype: Human Translation
ms.sourcegitcommit: 59e02840c72d8bccda7e318197e4bf45ed667fa4
ms.openlocfilehash: e404eceb4aad562474cff264bb992a3d71a3bed4

---

# UI 文字列をリソースに格納する





**重要な API**

-   [**ApplicationModel.Resources.ResourceLoader**](https://msdn.microsoft.com/library/windows/apps/br206014)
-   [**WinJS.Resources.processAll**](https://msdn.microsoft.com/library/windows/apps/br211864)

UI の文字列リソースをリソース ファイルに格納します。 その後、これらの文字列をコードやマークアップから参照できます。

このトピックでは、いくつかの言語の文字列リソースをユニバーサル Windows アプリに追加する手順と、簡単なテスト方法について説明します。

## <span id="put_strings_into_resource_files__instead_of_putting_them_directly_in_code_or_markup."></span><span id="PUT_STRINGS_INTO_RESOURCE_FILES__INSTEAD_OF_PUTTING_THEM_DIRECTLY_IN_CODE_OR_MARKUP."></span>文字列を、コードまたはマークアップに直接含める代わりに、リソース ファイルに格納します。


1.  Visual Studio でソリューションを開きます (または新しいソリューションを作成します)。

2.  Visual Studio で package.appxmanifest を開き、**[アプリケーション]** タブに移動して、(この例の場合) 既定の言語を "en-US" に設定します。 ソリューションに複数の package.appxmanifest ファイルがある場合、各ファイルに対してこの手順を実行します。
    <br>**注:** これにより、プロジェクトの既定の言語を指定します。 既定の言語リソースは、ユーザーが優先する言語または表示言語がアプリケーションで提供される言語リソースに一致しない場合に使われます。
3.  リソース ファイルを格納するためのフォルダーを作ります。
    1.  ソリューション エクスプローラーで、プロジェクト (ソリューションに複数のプロジェクトが含まれる場合は共有プロジェクト) を右クリックし、**[追加]** &gt; **[新しいフォルダー]** を順に選びます。
    2.  新しいフォルダーに "Strings" という名前を付けます。
    3.  ソリューション エクスプローラーに新しいフォルダーが表示されない場合は、プロジェクトが選ばれている状態で Microsoft Visual Studio のメニューの **[プロジェクト]** &gt; **[すべてのファイルを表示]** を順に選びます。

4.  英語 (米国) 用のサブフォルダーとリソース ファイルを作ります。
    1.  Strings フォルダーを右クリックし、その下に新しいフォルダーを追加します。 新しいフォルダーに "en-US" という名前を付けます。 リソース ファイルは、[BCP-47](http://go.microsoft.com/fwlink/p/?linkid=227302) 言語タグの名前を持つフォルダーに格納します。 言語修飾子の詳しい情報と共通の言語タグの一覧は、「[修飾子を使ってリソースに名前を付ける方法](https://msdn.microsoft.com/library/windows/apps/xaml/hh965324)」をご覧ください。
    2.  en-US フォルダーを右クリックし、**[追加]** &gt; **[新しい項目]** の順に選びます。
    3.  **XAML:** [リソース ファイル (.resw)] を選びます。
        <br>**HTML:** [リソース ファイル (.resjson)] を選びます。

    4.  **[追加]** をクリックします。 "Resources.resw" (**XAML** の場合) または "resources.rejson" (**HTML** の場合) という既定の名前の付いたリソース ファイルが追加されます。 この既定のファイル名を使うことをお勧めします。 アプリはリソースを他のファイルに分割できますが、そのファイルを正しく参照するように注意する必要があります (「[文字列リソースを読み込む方法](https://msdn.microsoft.com/library/windows/apps/xaml/hh965323)」をご覧ください)。
    5.  **XAML のみ:** 以前の .NET プロジェクトの文字列リソースだけを含む .resx ファイルがある場合は、**[追加]** &gt; **[既存の項目]** の順に選び、.resx ファイルを追加し、.resw に名前を変更します。
    6.  ファイルを開き、エディターを使ってこれらのリソースを追加します。

        **XAML:**

        Strings/en-US/Resources.resw ![リソースの追加 (英語)](images/addresource-en-us.png) この例では、"Greeting.Text" と "Farewell" が、表示される文字列を特定しています。 "Greeting.Width" は "Greeting" 文字列の Width プロパティを特定しています。 コメントは、文字列を他の言語にローカライズする翻訳者に特別な指示を伝えるのに便利です。

        **HTML:**

        新しいファイルには既定のコンテンツが含まれます。 このコンテンツを次のものと置き換えます (既定と類似している場合もあります)。

        Strings/en-US/resources.resjson

        ```        json
        {
                "greeting"              : "Hello",
                "_greeting.comment"     : "A welcome greeting",

                "farewell"              : "Goodbye",
                "_farewell.comment"     : "A goodbye"
        }
        ```

        これは厳密な JavaScript Object Notation (JSON) 構文で、最後のペアを除く各名前と値のペアの後にコンマが必要です。 この例では、"greeting" と "farewell" が表示される文字列を特定しています。 他方のペア ("\_greeting.comment" と "\_farewell.comment") は文字列を説明するコメントです。 コメントは、文字列を他の言語にローカライズする翻訳者に特別な指示を伝えるのに便利です。

## <span id="associate_controls_to_resources."></span><span id="ASSOCIATE_CONTROLS_TO_RESOURCES."></span>リソースにコントロールを関連付けます。


**XAML のみ:**

ローカライズされたテキストを必要とするすべてのコントロールを .resw ファイルに関連付ける必要があります。 これを行うには、次に示すように XAML 要素の **x:Uid** 属性を使います。

```XML
<TextBlock x:Uid="Greeting" Text="" />
```

リソース名には、**Uid** 属性値に加え、翻訳された言語を取得するプロパティ (この場合は Text プロパティ) を指定します。 Greeting.Width など、異なる言語の他のプロパティ/値を指定できますが、このようなレイアウト関連のプロパティを指定する際には注意が必要です。 デバイスの画面に基づいてコントロールを動的にレイアウトする必要があります。

AutomationPeer.Name などのアタッチされたプロパティは、resw ファイルでは異なる方法で処理されます。 次のように名前空間を明示的に書き出す必要があります。

```XML
MediumButton.[using:Windows.UI.Xaml.Automation]AutomationProperties.Name</code></pre></td>
```

## <span id="add_string_resource_identifiers_to_code_and_markup."></span><span id="ADD_STRING_RESOURCE_IDENTIFIERS_TO_CODE_AND_MARKUP."></span>コードとマークアップに文字列リソース識別子を追加します。


**XAML:**

コードでは、文字列を動的に参照できます。

**C#**
```CSharp
var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
var str = loader.GetString("Farewell");
```

**C++**
```cpp
auto loader = ref new Windows::ApplicationModel::Resources::ResourceLoader();
auto str = loader->GetString("Farewell");
```

**HTML:**

1.  JavaScript 用 Windows ライブラリへの参照を HTML ファイルに追加していない場合は追加します。

    **注:** 次のコードは、Visual Studio で新しい **[空のアプリケーション (ユニバーサル Windows)]** JavaScript プロジェクトを作ると生成される Windows プロジェクトの default.html ファイルの HTML を示しています。 ファイルには WinJS への参照が既に含まれていることに注意してください。

    ```    HTML
    <!-- WinJS references -->
    <link href="WinJS/css/ui-dark.css" rel="stylesheet" />
    <script src="WinJS/js/base.js"></script>
    <script src="WinJS/js/ui.js"></script>
    ```

2.  HTML ファイルに付随する JavaScript コードで、HTML が読み込まれるときに [**WinJS.Resources.processAll**](https://msdn.microsoft.com/library/windows/apps/br211864) 関数を呼び出します。

    ```    JavaScript
    WinJS.Application.onloaded = function(){
        WinJS.Resources.processAll();
    }
    ```
    
    追加の HTML が [**WinJS.UI.Pages.PageControl**](https://msdn.microsoft.com/library/windows/apps/jj126158) オブジェクトに読み込まれると、ページ コントロールの [**IPageControlMembers.ready**](https://msdn.microsoft.com/library/windows/apps/hh770590) メソッドで [**WinJS.Resources.processAll**](https://msdn.microsoft.com/library/windows/apps/br211864) (*element*) を呼び出します。ここでは、*element* は、読み込まれる HTML 要素 (およびその子要素) です。 この例は、「[アプリ リソースとローカライズのサンプル](http://go.microsoft.com/fwlink/p/?linkid=227301)」のシナリオ 6 に基づいています。

    ```    JavaScript
    var output;
    
    var page = WinJS.UI.Pages.define("/html/scenario6.html", {
        ready: function (element, options) {
            output = element.querySelector('#output');
            WinJS.Resources.processAll(output); // Refetch string resources
            WinJS.Resources.addEventListener("contextchanged", refresh, false);
        }
        unload: function () { 
            WinJS.Resources.removeEventListener("contextchanged", refresh, false); 
        } 
    });
    ```

3.  HTML でリソース識別子 ('greeting' と 'farewell') を使ってリソース ファイルから文字列リソースを参照します。
    ```    HTML
    <h2><span data-win-res="{textContent: 'greeting';}"></span></h2>
    <h2><span data-win-res="{textContent: 'farewell'}"></span></h2>
    ```

4.  属性の文字列リソースを参照します。

    ```    HTML
    <div data-win-res="{attributes: {'aria-label'; : 'String1'}}" >
    ```

    HTML の置き換えの data-win-res 属性の標準パターンは data-win-res="{*propertyname1*: '*resource ID*', *propertyname2*: '*resource ID2*'}" です。

    **注:** 文字列にマークアップが含まれていない場合は、可能な限り、リソースを innerHTML ではなく textContent プロパティにバインドします。 textContent プロパティの方が、innerHTML よりも高速で置き換えることができます。

5.  JavaScript で文字列リソースを参照します。
    <span codelanguage="JavaScript"></span>
    ```    JavaScript
    var el = element.querySelector('#header');
    var res = WinJS.Resources.getString('greeting');
    el.textContent = res.value;
    el.setAttribute('lang', res.lang);
    ```

## <span id="add_folders_and_resource_files_for_two_additional_languages."></span><span id="ADD_FOLDERS_AND_RESOURCE_FILES_FOR_TWO_ADDITIONAL_LANGUAGES."></span>他の 2 つの言語用にフォルダーとリソース ファイルを追加します。


1.  Strings フォルダーの下にドイツ語用の別のフォルダーを追加します。 フォルダーに Deutsch (Deutschland) を表す "de-DE" という名前を付けます。
2.  [de-DE] フォルダー内に別のリソース ファイルを作り、次のように追加します。

    **XAML:**

    strings/de-DE/Resources.resw

    ![リソースを追加する (ドイツ語)](images/addresource-de-de.png)

    **HTML:**

    strings/de-DE/resources.resjson

    ```    json
    {
        "greeting"              : "Hallo",
        "_greeting.comment"     : "A welcome greeting.",

        "farewell"              : "Auf Wiedersehen",
        "_farewell.comment"     : "A goodbye."
    }
    ```

3.  フォルダーをもう 1 つ作り、français (France) を表す "fr-FR" という名前を付けます。 新規のリソース ファイルを作り、次のように追加します。

    **XAML:**

    strings/fr-FR/Resources.resw![リソースを追加する (フランス語)](images/addresource-fr-fr.png)
    **HTML:**

    strings/fr-FR/resources.resjson

    ```    json
    {
        "greeting"              : "Bonjour",
        "_greeting.comment"     : "A welcome greeting.",

        "farewell"              : "Au revoir",
        "_farewell.comment"     : "A goodbye."
    }
    ```

## <span id="build_and_run_the_app."></span><span id="BUILD_AND_RUN_THE_APP."></span>アプリをビルドして実行します。


既定の表示言語に対してアプリをテストします。

1.  F5 キーを押して、アプリをビルドし、実行します。
2.  "greeting" と "farewell" が、ユーザーの優先する言語で表示されることを確かめます。
3.  アプリを終了します。

他の言語に対してアプリをテストします。

1.  デバイスで **[設定]** を表示します。
2.  **[時刻と言語]** を選択します。
3.  **[地域と言語]** (電話または電話エミュレーターでは **[言語]**) を選択します。
4.  前回アプリを実行したときに表示された言語は、一覧の中で最上位にリストされている言語 (英語、ドイツ語、またはフランス語) です。 最上位にリストされている言語がこれらのいずれでもない場合、アプリでサポートされているリスト内の次の言語にフォールバックされます。
5.  これらの 3 つの言語のいずれかがコンピューターにインストールされていない場合は、**[言語の追加]** をクリックして、言語を一覧に追加します。
6.  別の言語でアプリをテストするには、一覧で言語を選択し、**[既定に設定]** をクリックします (電話または電話エミュレーターでは、一覧で言語を長押しして、最上位に来るまで **[上へ移動]** をタップします)。 その後、アプリを実行します。

## <span id="related_topics"></span>関連トピック


* [修飾子を使ってリソースに名前を付ける方法](https://msdn.microsoft.com/library/windows/apps/xaml/hh965324)
* [文字列リソースを読み込む方法](https://msdn.microsoft.com/library/windows/apps/xaml/hh965323)
* [BCP-47 言語タグに関するページ](http://go.microsoft.com/fwlink/p/?linkid=227302)
 

 






<!--HONumber=Aug16_HO3-->


