---
description: マークアップ要素の一意の識別子を提供します。 ユニバーサル Windows プラットフォーム (UWP) XAML では、.resw リソース ファイルのリソースを使うときなど、XAML のローカライズのプロセスとツールでこの一意の識別子が使われます。
title: xUid ディレクティブ
ms.assetid: 9FD6B62E-D345-44C6-B739-17ED1A187D69
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 03cf647fdb243fd18212ca894f7682e913378907
ms.sourcegitcommit: 681c70f964210ab49ac5d06357ae96505bb78741
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/26/2018
ms.locfileid: "7694277"
---
# <a name="xuid-directive"></a>x:Uid ディレクティブ


マークアップ要素の一意の識別子を提供します。 ユニバーサル Windows プラットフォーム (UWP) XAML では、.resw リソース ファイルのリソースを使うときなど、XAML のローカライズのプロセスとツールでこの一意の識別子が使われます。

## <a name="xaml-attribute-usage"></a>XAML 属性の使用方法

``` syntax
<object x:Uid="stringID".../>
```

## <a name="xaml-values"></a>XAML 値

| 用語 | 説明 |
|------|-------------|
| stringID | アプリ内の XAML 要素を一意に識別し、リソース ファイルのリソース パスの一部となる文字列です。 注釈をご覧ください。| 

## <a name="remarks"></a>注釈

XAML でオブジェクト要素を識別するには **x:Uid** を使います。 このオブジェクト要素は通常、コントロール クラスか、UI に表示される要素のインスタンスです。 **x:Uid** で使う文字列とリソース ファイルで使う文字列の関係として、リソース ファイルの文字列は **x:Uid** の後にドット (.)、その次にローカライズ対象要素の特定のプロパティの名前が続きます。 次に例を示します。

``` syntax
<Button x:Uid="GoButton" Content="Go"/>
```

**Go** という表示テキストを置き換えるコンテンツを指定するには、リソース ファイルの新しいリソースを指定する必要があります。 リソース ファイルには "GoButton.Content" という名前のリソースのエントリを含める必要があります。 この場合、[**Content**](/uwp/api/windows.ui.xaml.controls.contentcontrol.content) が [**Button**](/uwp/api/windows.ui.xaml.controls.button) クラスに継承される特定のプロパティです。 "GoButton.FlowDirection" にリソースに基づく値を指定するなど、このボタンの他のプロパティにローカライズ値を指定することがあります。 **x:Uid** とリソース ファイルを一緒に使用する方法の詳細については、「[UI とアプリ パッケージ マニフェスト内の文字列をローカライズする](../app-resources/localize-strings-ui-manifest.md)」を参照してください。

**x:Uid** 値に使用可能な文字列の正当性は、リソース ファイル内の識別子やリソース パスとして正当な文字列はどれかという実質的な意味合いにおいて制御されます。

規定された XAML のローカライズ シナリオにより、**x:Uid** は **x:Name** から分離されています。したがって、ローカライズで使われる識別子は、プログラミング モデルの関連において **x:Name** への依存関係はありません。 また、**x:Name** は XAML 名前スコープの概念で管理されるのに対して、**x:Uid** の一意性はパッケージ リソース インデックス (PRI) システムによって制御されます。 詳しくは、「[リソース管理システム](../app-resources/resource-management-system.md)」をご覧ください。

UWP XAML での **x:Uid** の一意性の規則は、以前使われていた XAML を利用したテクノロジと比べると、いくらか異なります。 UWP XAML では、複数の XAML 要素上で同一の **x:Uid** ID 値がディレクティブとして存在することは正当とされています。 ただし、そうした各要素は、リソース ファイル内のリソースを解決するときに、同じ解決ロジックを共有する必要があります。 また、プロジェクト内のすべての XAML ファイルも、**x:Uid** 解決の目的で、1 つのリソース範囲を共有します。個々の XAML ファイルに合わせた **x:Uid** 範囲の概念は存在しません。

場合によっては、パッケージ リソース インデックスの (PRI) システムの組み込みの機能ではなく、リソース パスを使います。 **x:Uid** 値として使われる文字列はいずれも、ms-resource:///Resources/ で始まり **x:Uid** 文字列を含むリソース パスを定義します。 パスは、リソース ファイルで指定するプロパティ名か、ターゲットに設定するプロパティ名で終わります。

Windows ランタイム XAML では、プロパティ要素に **x:Uid** を含めることはできません。

