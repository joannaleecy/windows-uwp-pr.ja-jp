---
author: Xansky
Description: ハイ コントラスト テーマがアクティブになっているときにユニバーサル Windows プラットフォーム (UWP) アプリを使用できることを確かめるために必要な手順について説明します。
ms.assetid: FD7CA6F6-A8F1-47D8-AA6C-3F2EC3168C45
title: ハイ コントラスト テーマ
label: High-contrast themes
template: detail.hbs
---

# ハイ コントラスト テーマ  



ハイ コントラスト テーマがアクティブになっているときにユニバーサル Windows プラットフォーム (UWP) アプリを使用できることを確かめるために必要な手順について説明します。

UWP アプリは、ハイ コントラスト テーマを既定でサポートします。 ユーザーが、システム設定またはアクセシビリティ ツールでハイ コントラスト テーマが使われるように指定すると、色とスタイルの設定が自動的に変わって、UI のコントロールとコンポーネントにハイ コントラスト レイアウトおよびハイ コントラスト レンダリングが使われます。

この既定のサポートでは、既定のテーマとテンプレートを使います。 これらのテーマとテンプレートではシステム カラーをリソース定義として参照し、システムがハイ コントラスト モードに移行するとリソース ソースが自動的に変更されます。 ただし、コントロールにカスタムのテンプレート、テーマ、スタイルを使う場合は、ハイ コントラストに対して組み込まれているサポートを無効にしないよう注意してください。 スタイル指定に Microsoft Visual Studio 用のいずれかの XAML デザイナーを使っている場合は、既定のテンプレートと大幅に異なるテンプレートを定義するたびに、プライマリ テーマと共に、別のハイ コントラスト テーマが生成されます。 この別のテーマのディクショナリは、[**ResourceDictionary**](https://msdn.microsoft.com/library/windows/apps/BR208794) 要素の専用プロパティである [**ThemeDictionaries**](https://msdn.microsoft.com/library/windows/apps/BR208807) コレクションに入れられます。

テーマとコントロール テンプレートについて詳しくは、「[クイック スタート: コントロール テンプレート](https://msdn.microsoft.com/library/windows/apps/xaml/Hh465374)」をご覧ください。 特定のコントロールの XAML リソース ディクショナリとテーマや、これらのテーマの構築方法、可能な各ハイ コントラスト設定に対して類似していても異なるリソースを、これらのテーマでどのように参照するかということを確認すると参考になります。

<span id="Detecting_when_a_high-contrast_theme_is_enabled"/>
<span id="detecting_when_a_high-contrast_theme_is_enabled"/>
<span id="DETECTING_WHEN_A_HIGH-CONTRAST_THEME_IS_ENABLED"/>
## 有効にされたハイ コントラスト テーマの検出  
UWP アプリでは、[**AccessibilitySettings**](https://msdn.microsoft.com/library/windows/apps/BR242237) クラスのメンバーを使って、ハイ コントラスト テーマの現在の設定を検出できます。 [
            **HighContrast**](https://msdn.microsoft.com/library/windows/apps/BR242237_highcontrast) プロパティによって、ハイ コントラスト テーマが現在選ばれているかどうかを判断します。 **HighContrast** が **true** の場合は、次に、[**HighContrastScheme**](https://msdn.microsoft.com/library/windows/apps/BR242237_highcontrastscheme) プロパティの値を確認し、使われているハイ コントラスト テーマの名前を取得します。 コードの応答が必要な **HighContrastScheme** の一般的な値は、"High Contrast White" と "High Contrast Black" です。 XAML で定義された [**ResourceDictionary**](https://msdn.microsoft.com/library/windows/apps/BR208794) キーにはスペースを含めることはできないため、リソース ディクショナリ内のこれらのテーマのキーは通常、それぞれ "HighContrastWhite" と "HighContrastBlack" になります。 値が別の文字列の場合に備えて、既定のハイ コントラスト テーマ用のフォールバック ロジックも必要です。 このロジックは、[XAML ハイ コントラスト サンプル](http://go.microsoft.com/fwlink/p/?linkid=254993)についてのページで紹介されています。

> [!NOTE] 注 アプリが初期化され、既にコンテンツが表示されているスコープから [**AccessibilitySettings**](https://msdn.microsoft.com/library/windows/apps/BR242237) コンストラクターを呼び出すようにします。

実行中にハイ コントラスト リソース値を使うようにアプリを切り替えることができます。 この動作は、リソースがスタイルまたはテンプレート XAML で [{ThemeResource} マークアップ拡張](https://msdn.microsoft.com/library/windows/apps/Mt185591)を使って要求されている限り有効です。 既定のテーマ (generic.xaml) ではすべてこの {ThemeResource} マークアップ拡張手法が使われているため、既定のコントロール テーマを使う場合はこの動作が得られます。 また、カスタム テンプレートとスタイルでこの {ThemeResource} マークアップ拡張リソース手法を使っている場合は、カスタム コントロールまたはカスタム コントロールのスタイル設定でこれを実行できます。

<span id="related_topics"/>
## 関連トピック  
* [Accessibility (ユーザー補助機能)](accessibility.md)
* [UI コントラストと設定のサンプル](http://go.microsoft.com/fwlink/p/?linkid=231539)
* [XAML アクセシビリティ サンプル](http://go.microsoft.com/fwlink/p/?linkid=238570)
* [XAML ハイ コントラスト サンプル](http://go.microsoft.com/fwlink/p/?linkid=254993)
* [**AccessibilitySettings**](https://msdn.microsoft.com/library/windows/apps/BR242237)


<!--HONumber=May16_HO2-->


