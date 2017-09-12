---
author: DelfCo
Description: "UI の文字列リソースをリソース ファイルに格納します。 その後、これらの文字列をコードやマークアップから参照できます。"
title: "UI 文字列をリソースに格納する"
ms.assetid: E420B9BB-C0F6-4EC0-BA3A-BA2875B69722
label: Put UI strings into resources
template: detail.hbs
ms.author: bobdel
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: a3e224fc51245a5f91c29da2d745a3740029cda9
ms.sourcegitcommit: 11664964e548a2af30d6e176c515cdbf330934ac
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/28/2017
---
# <a name="put-ui-strings-into-resources"></a>UI 文字列をリソースに格納する
<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css">

UI の文字列リソースをリソース ファイルに格納します。 その後、これらの文字列をコードやマークアップから参照できます。

<div class="important-apis" >
<b>重要な API</b><br/>
<ul>
<li>[**ApplicationModel.Resources.ResourceLoader**](https://msdn.microsoft.com/library/windows/apps/br206014)</li>
<li>[**WinJS.Resources.processAll**](https://msdn.microsoft.com/library/windows/apps/br211864)</li>
</ul>
</div>


このトピックでは、いくつかの言語の文字列リソースをユニバーサル Windows アプリに追加する手順と、簡単なテスト方法について説明します。

## <a name="put-strings-into-resource-files-instead-of-putting-them-directly-in-code-or-markup"></a>文字列を、コードまたはマークアップに直接含める代わりに、リソース ファイルに格納します。


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
    3.  [リソース ファイル (.resw)] を選びます。

    4.  **[追加]**をクリックします。 "Resources.resw" という既定の名前の付いたリソース ファイルが追加されます。 この既定のファイル名を使うことをお勧めします。 アプリはリソースを他のファイルに分割できますが、そのファイルを正しく参照するように注意する必要があります (「[文字列リソースを読み込む方法](https://msdn.microsoft.com/library/windows/apps/xaml/hh965323)」をご覧ください)。
    5.  以前の .NET プロジェクトの文字列リソースだけを含む .resx ファイルがある場合は、**[追加]**、**[既存の項目]** の順に選び、.resx ファイルを追加し、.resw に名前を変更します。
    6.  ファイルを開き、エディターを使ってこれらのリソースを追加します。


        Strings/en-US/Resources.resw ![リソースの追加 (英語)](images/addresource-en-us.png) この例では、"Greeting.Text" と "Farewell" が、表示される文字列を特定しています。 "Greeting.Width" は "Greeting" 文字列の Width プロパティを特定しています。 コメントは、文字列を他の言語にローカライズする翻訳者に特別な指示を伝えるのに便利です。

## <a name="associate-controls-to-resources"></a>リソースにコントロールを関連付けます。

ローカライズされたテキストを必要とするすべてのコントロールを .resw ファイルに関連付ける必要があります。 これを行うには、次に示すように XAML 要素の **x:Uid** 属性を使います。

```XML
<TextBlock x:Uid="Greeting" Text="" />
```

リソース名には、**Uid** 属性値に加え、翻訳された言語を取得するプロパティ (この場合は Text プロパティ) を指定します。 Greeting.Width など、異なる言語の他のプロパティ/値を指定できますが、このようなレイアウト関連のプロパティを指定する際には注意が必要です。 デバイスの画面に基づいてコントロールを動的にレイアウトする必要があります。

AutomationProperties.Name などのアタッチされたプロパティは、resw ファイルでは異なる方法で処理されます。 次のように名前空間を明示的に書き出す必要があります。

```XML
MediumButton.[using:Windows.UI.Xaml.Automation]AutomationProperties.Name
```

## <a name="add-string-resource-identifiers-to-code-and-markup"></a>コードとマークアップに文字列リソース識別子を追加します。

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


## <a name="add-folders-and-resource-files-for-two-additional-languages"></a>他の 2 つの言語用にフォルダーとリソース ファイルを追加します。


1.  Strings フォルダーの下にドイツ語用の別のフォルダーを追加します。 フォルダーに Deutsch (Deutschland) を表す "de-DE" という名前を付けます。
2.  [de-DE] フォルダー内に別のリソース ファイルを作り、次のように追加します。

    strings/de-DE/Resources.resw

    ![リソースを追加する (ドイツ語)](images/addresource-de-de.png)


3.  フォルダーをもう 1 つ作り、français (France) を表す "fr-FR" という名前を付けます。 新規のリソース ファイルを作り、次のように追加します。

    strings/fr-FR/Resources.resw
    
    ![リソースを追加する (フランス語)](images/addresource-fr-fr.png)

## <a name="build-and-run-the-app"></a>アプリをビルドして実行します。


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

## <a name="related-topics"></a>関連トピック


* [修飾子を使ってリソースに名前を付ける方法](https://msdn.microsoft.com/library/windows/apps/xaml/hh965324)
* [文字列リソースを読み込む方法](https://msdn.microsoft.com/library/windows/apps/xaml/hh965323)
* [BCP-47 言語タグに関するページ](http://go.microsoft.com/fwlink/p/?linkid=227302)
 

 



