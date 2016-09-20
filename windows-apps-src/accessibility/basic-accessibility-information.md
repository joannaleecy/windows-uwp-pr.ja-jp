---
author: Xansky
Description: "基本的なアクセシビリティ情報は、多くの場合、名前、役割、値に分類されます。 このトピックでは、支援技術が必要とする基本情報をアプリで公開するのに役立つコードについて説明します。"
ms.assetid: 9641C926-68C9-4842-8B55-C38C39A9E5C5
title: "基本的なアクセシビリティ情報の開示"
label: Expose basic accessibility information
template: detail.hbs
translationtype: Human Translation
ms.sourcegitcommit: 05fa9bb674839c255d8b63da04a018e397c84490
ms.openlocfilehash: a72a49756b5d2828526a39fce50357ae90549aae

---

# 基本的なアクセシビリティ情報の開示  



基本的なアクセシビリティ情報は、多くの場合、名前、役割、値に分類されます。 このトピックでは、支援技術が必要とする基本情報をアプリで公開するのに役立つコードについて説明します。

<span id="accessible_name"/>
<span id="ACCESSIBLE_NAME"/>
## アクセシビリティ対応の名前  
アクセシビリティ対応の名前とは、スクリーン リーダーが UI 要素を読み上げるときに使う短い説明の文字列です。 コンテンツを理解したり UI を操作したりするときに重要な意味を持つ UI 要素に対して設定します。 そのような要素には、通常、イメージ、入力フィールド、ボタン、コントロール、領域が含まれます。

次の表に、さまざまな XAML UI 要素のアクセシビリティ対応の名前を定義または取得する方法を示します。

| 要素型      | 説明 |
|-------------------|-------------|
| 静的テキスト       | [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/BR209652) 要素と [**RichTextBlock**](https://msdn.microsoft.com/library/windows/apps/BR227565) 要素については、アクセシビリティ対応の名前が表示 (内部) テキストから自動的に決定されます。 この要素のテキストはすべて名前として使われます。 「[内部テキストに基づく名前](#name_from_inner_text)」をご覧ください。 |
| 画像            | XAML の [**Image**](https://msdn.microsoft.com/library/windows/apps/BR242752) 要素は、HTML の **img** の **alt** 属性やこれに類似する要素に、直接相当するものではありません。 [**AutomationProperties.Name**](https://msdn.microsoft.com/library/windows/apps/Hh759770) を使って名前を指定するか、キャプション手法を使います。 「[画像のアクセシビリティ対応の名前](#images)」をご覧ください。 |
| フォーム要素     | フォーム要素のアクセシビリティ対応の名前は、その要素に表示されるラベルと同じにする必要があります。 「[ラベルと LabeledBy](#labels)」をご覧ください。 |
| ボタンとリンク | ボタンやリンクでは、「[内部テキストに基づく名前](#name_from_inner_text)」に記載されているのと同じ規則を使って、表示テキストに基づく名前が既定でアクセシビリティ対応の名前として使われます。 画像のみが含まれるボタンの場合は、[**AutomationProperties.Name**](https://msdn.microsoft.com/library/windows/apps/Hh759770) を使って、そのボタンで想定する操作にテキストのみのボタンを指定します。 |
<br/>
パネルなどのコンテナー要素では通常、アクセシビリティ対応の名前としてコンテンツが昇格されることはありません。 これは、名前とそれに対応する役割を報告する必要があるのは項目のコンテンツであり、コンテナーではないからです。 コンテナー要素では、Microsoft UI オートメーションの表示で子が含まれるのは、支援技術のロジックが走査できる要素であると報告される場合があります。 ただし、支援技術を利用するユーザーは通常、コンテナーについて意識する必要はないため、ほとんどのコンテナーには名前が付けられません。

<span id="role_value"/>
<span id="ROLE_VALUE"/>
## 役割と値  
XAML ボキャブラリに含まれるコントロールやその他の UI 要素は、その定義の一部として役割と値を報告するために UI オートメーション サポートを実装しています。 UI オートメーション ツールを使ってコントロールの役割と値の情報を検証できます。また、各コントロールの [**AutomationPeer**](https://msdn.microsoft.com/library/windows/apps/BR209185) 実装に関する説明書を参照することもできます。 UI オートメーション フレームワークで使うことができる役割は、[**AutomationControlType**](https://msdn.microsoft.com/library/windows/apps/BR209182) 列挙体で定義されています。 支援技術などの UI オートメーション クライアントでは、コントロールの **AutomationPeer** を使用することで UI オートメーション フレームワークが公開するメソッドを呼び出すことにより、役割の情報を取得することができます。

すべてのコントロールに値があるわけではありません。 値のあるコントロールは、このコントロールでサポートされるピアとパターンを介して UI オートメーションにこの情報を報告します。 たとえば、[**TextBox**](https://msdn.microsoft.com/library/windows/apps/BR209683) フォーム要素には値があります。 支援技術は UI オートメーション クライアントである可能性もあり、値が存在することと、値が何であるかを確認することができます。 この場合、**TextBox** は [**TextBoxAutomationPeer**](https://msdn.microsoft.com/library/windows/apps/BR242550) を定義することで [**IValueProvider**](https://msdn.microsoft.com/library/windows/apps/BR242663) パターンをサポートします。

> [!NOTE]
> [**AutomationProperties.Name**](https://msdn.microsoft.com/library/windows/apps/Hh759770) またはその他の手法を使ってアクセシビリティ対応の名前を明示的に指定する場合は、アクセシビリティ対応の名前にコントロールの役割や種類の情報で使うものと同じテキストを含めないでください。 たとえば、名前に "ボタン" や "リスト" などの文字列は含めないでください。 役割と種類の情報は、UI オートメーション用の既定のコントロール サポートから提供される別の UI オートメーションのプロパティ (**LocalizedControlType**) から取得します。 多くの支援技術では、アクセシビリティ対応の名前に **LocalizedControlType** が付加されるため、アクセシビリティ対応の名前の中で役割が重複していると、語句が不必要に繰り返されることになります。 たとえば、[**Button**](https://msdn.microsoft.com/library/windows/apps/BR209265) コントロールに「ボタン」というアクセシビリティ対応の名前を付けるか、名前の最後の部分として「ボタン」を含めた場合、スクリーン リーダーはこの名前を "ボタン ボタン" と読み取る可能性があります。 ナレーターを使って、アクセシビリティ情報のこの側面をテストする必要があります。

<span id="Influencing_the_UI_Automation_tree_views"/>
<span id="influencing_the_ui_automation_tree_views"/>
<span id="INFLUENCING_THE_UI_AUTOMATION_TREE_VIEWS"/>
## UI オートメーション ツリー ビューへの影響  
UI オートメーション フレームワークには、3 つの有効なビュー (未処理、コントロール、コンテンツ) を使って、UI オートメーション クライアントが UI 内の要素の関係を取得できるツリー ビューの概念があります。 コントロール ビューは UI オートメーション クライアントによって一般的に使われるビューであり、対話型である UI 内の要素を適切に表現し、組織化します。 一般的にテスト ツールによって、ツールが要素の組織を表す場合に使うツリー ビューを決定できます。

既定では、UI オートメーション フレームワークによってユニバーサル Windows プラットフォーム (UWP) アプリのユーザー インターフェイスを表す場合に、[**Control**](https://msdn.microsoft.com/library/windows/apps/BR209390) 派生クラスとその他のいくつかの要素がコントロール ビューに表示されます。 ただし、要素の情報が重複しているか、アクセシビリティのシナリオで重要でない情報を提示している場合に、UI 合成のためにコントロール ビューに要素を表示したくない場合があります。 ツリー ビューに要素を公開する方法を変更するには、添付プロパティ [**AutomationProperties.AccessibilityView**](https://msdn.microsoft.com/library/windows/apps/Dn251788) を使います。 **Raw** ツリーに要素を配置した場合、ほとんどの支援技術は、その要素をビューの一部として報告しません。 お使いのコントロールでこの動作の例を確認するには、テキスト エディターで generic.xaml 設計参照 XAML ファイルを開いて、テンプレートで **AutomationProperties.AccessibilityView** を検索します。

<span id="name_from_inner_text"/>
<span id="NAME_FROM_INNER_TEXT"/>
## 内部テキストに基づく名前  
表示される UI に既に存在する文字列を、アクセシビリティ対応の名前の値に簡単に使うことができるように、コントロールやその他の UI 要素には通常、要素内の内部テキストに基づいて、またはコンテンツ プロパティの文字列値から、既定のアクセシビリティ対応の名前を自動的に決定するためのサポートが用意されています。

* [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/BR209652)、[**RichTextBlock**](https://msdn.microsoft.com/library/windows/apps/BR227565)、[**TextBox**](https://msdn.microsoft.com/library/windows/apps/BR209683)、**RichTextBlock** それぞれでは、既定のアクセシビリティ対応の名前として **Text** プロパティの値を昇格させます。
* いずれの [**ContentControl**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.contentcontrol.content) サブクラスも、反復的な "ToString" を使って、[**Content**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.contentcontrol.content) 値に含まれる文字列を検索し、その文字列を既定のアクセシビリティ対応の名前として昇格させます。

> [!NOTE]
> UI オートメーションで規定されているため、アクセシビリティ対応の名前の長さは 2048 文字以下でなければなりません。 アクセシビリティ対応の名前を自動的に決定するために使う文字列がこの制限を超えている場合、アクセシビリティ対応の名前は制限に収まるように切り捨てられます。

<span id="images"/>
<span id="IMAGES"/>
## 画像のアクセシビリティ対応の名前
スクリーン リーダーのサポートや、UI 中の各要素を識別するための基本情報の提供を行う際、テキスト以外の情報に対して、代替テキストを指定しなければならないことがあります。対象となるのは、装飾だけを目的とした要素や構造上の要素を除く、画像やグラフなどです。 これらの要素には内部テキストがないため、アクセシビリティ対応の名前も計算で求められた値を持ちません。 アクセシビリティ対応の名前を直接設定するには、[**AutomationProperties.Name**](https://msdn.microsoft.com/library/windows/apps/Hh759770) 添付プロパティを次の例に示すように設定します。

XAML
```xml
<Image Source="product.png"
  AutomationProperties.Name="An image of a customer using the product."/>
```

また別の方法として、表示される UI 内に存在し、ラベルに関連する画像コンテンツのアクセシビリティ情報としても機能するテキスト字幕を取り入れることもできます。 次に例を示します。

XAML
```xml
<Image HorizontalAlignment="Left" Width="480" x:Name="img_MyPix"
  Source="snoqualmie-NF.jpg"
  AutomationProperties.LabeledBy="{Binding ElementName=caption_MyPix}"/>
<TextBlock x:Name="caption_MyPix">Mount Snoqualmie Skiing</TextBlock>
```

<span id="labels"/>
<span id="LABELS"/>
## ラベルと LabeledBy  
ラベルとフォーム要素を関連付けるときによく使われるのは、まずラベルのテキストに対して **x:Name** を指定した [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/BR209652) を使い、フォーム要素上で [**AutomationProperties.LabeledBy**](https://msdn.microsoft.com/library/windows/apps/Hh759769) 添付プロパティを設定することにより、XAML 名によってラベル付けの **TextBlock** を参照するという方法です。 このパターンを使う場合は、ユーザーがラベルをクリックしたときに関連付けられているコントロールにフォーカスが移動し、支援技術でフォーム フィールドのアクセシビリティ対応の名前としてラベルのテキストを使うことができるようにする必要があります。 次の例は、この手法を示しています。

XAML
```xml
<StackPanel x:Name="LayoutRoot" Background="White">
   <StackPanel Orientation="Horizontal">
     <TextBlock Name="lbl_FirstName">First name</TextBlock>
     <TextBox
      AutomationProperties.LabeledBy="{Binding ElementName=lbl_FirstName}"
      Name="tbFirstName" Width="100"/>
   </StackPanel>
   <StackPanel Orientation="Horizontal">
     <TextBlock Name="lbl_LastName">Last name</TextBlock>
     <TextBox
      AutomationProperties.LabeledBy="{Binding ElementName=lbl_LastName}"
      Name="tbLastName" Width="100"/>
   </StackPanel>
 </StackPanel>
```

<span id="accessible_description"/>
<span id="ACCESSIBLE_DESCRIPTION"/>
## アクセシビリティ対応の説明 (省略可能)  
アクセシビリティ対応の説明は、特定の UI 要素に関する追加のアクセシビリティ情報を提供します。 アクセシビリティ対応の名前だけでは要素の目的を十分に伝えられない場合に使用されるのが一般的です。

ナレーター スクリーン リーダーは、ユーザーが CapsLock キーを押しながら F キーを押して要素に関する追加情報を要求した場合にのみ、要素のアクセシビリティ対応の説明を読み上げます。

このアクセシビリティ対応の名前は、動作を完全に表すためのものではなく、コントロールを識別するためのものです。 簡単な説明だけではコントロールの説明が不十分な場合は、[**AutomationProperties.Name**](https://msdn.microsoft.com/library/windows/apps/Hh759765) に加え、[**AutomationProperties.HelpText**](https://msdn.microsoft.com/library/windows/apps/Hh759770) 添付プロパティを設定できます。

<span id="Testing_accessibility_early_and_often"/>
<span id="testing_accessibility_early_and_often"/>
<span id="TESTING_ACCESSIBILITY_EARLY_AND_OFTEN"/>
## アクセシビリティを初期段階から何度もテストする  
スクリーン リーダーをサポートする最善の方法は、最終的に、スクリーン リーダーをアプリでテストして判断することです。 テストすることで、スクリーン リーダーの動作や、アプリから取得できないアクセシビリティの基本情報を確認することができます。 その後、その情報に基づいて、UI や UI オートメーションのプロパティの値を調整できます。 詳しくは、「[アクセシビリティ テスト](accessibility-testing.md)」をご覧ください。

アクセシビリティのテストに使用できるツールの 1 つに、**AccScope** があります。 **AccScope** ツールは特に、支援技術によりアプリがオートメーション ツリーとしてどのように表示されるかを示す UI の視覚的な表現を確認するために役立ちます。 特に、ナレーターがアプリでテキストを表示する方法、および UI での要素の整理方法を確認するナレーター モードが用意されています。 AccScope は、予備設計フェーズであってもアプリの開発サイクル全体で使用でき、有用であるように設計されています。 詳しくは、「[AccScope](https://msdn.microsoft.com/library/windows/desktop/Dn433239)」をご覧ください。

<span id="Accessible_names_from_dynamic_data"/>
<span id="accessible_names_from_dynamic_data"/>
<span id="ACCESSIBLE_NAMES_FROM_DYNAMIC_DATA"/>
## 動的データからのアクセシビリティ対応の名前  
Windows では、*データ バインディング*という機能によって、関連付けられたデータ ソースから取得される値を表示するのに使うことができる、多くのコントロールがサポートされています。 一覧にデータ項目を設定するときに、最初の一覧に入力した後で、データがバインドされた一覧項目にアクセシビリティ対応の名前を設定する必要がある場合があります。 詳しくは、[XAML アクセシビリティ サンプル](http://go.microsoft.com/fwlink/p/?linkid=238570) のシナリオ 4 をご覧ください。

<span id="Accessible_names_and_localization"/>
<span id="accessible_names_and_localization"/>
<span id="ACCESSIBLE_NAMES_AND_LOCALIZATION"/>
## アクセシビリティ対応の名前とローカライズ  
アクセシビリティ対応の名前をローカライズ対象の要素としても設定する場合は、適切な方法によってローカライズ可能な文字列をリソースとして保存し、[x:Uid ディレクティブ](https://msdn.microsoft.com/library/windows/apps/Mt204791) 値を使ってリソース接続を参照する必要があります。 アクセシビリティ対応の名前を、明示的に設定された [**AutomationProperties.Name**](https://msdn.microsoft.com/library/windows/apps/Hh759770) の使用から取得する場合は、必ずそこに含まれる文字列もローカライズ可能であることを確認します。

[**AutomationProperties**](https://msdn.microsoft.com/library/windows/apps/BR209081) プロパティなどの添付プロパティは、リソース名で特殊な修飾構文を使うので、リソースでは特定の要素に適用される添付プロパティを参照することに注意してください。 たとえば、`MediumButton` という名前の UI 要素に適用される [**AutomationProperties.Name**](https://msdn.microsoft.com/library/windows/apps/Hh759770) のリソース名は、`MediumButton.[using:Windows.UI.Xaml.Automation]AutomationProperties.Name` です。

<span id="related_topics"/>
## 関連トピック  
* [アクセシビリティ](accessibility.md)
* [**AutomationProperties.Name**](https://msdn.microsoft.com/library/windows/apps/Hh759770)
* [XAML アクセシビリティ サンプル](http://go.microsoft.com/fwlink/p/?linkid=238570)
* [アクセシビリティ テスト](accessibility-testing.md)



<!--HONumber=Aug16_HO3-->


