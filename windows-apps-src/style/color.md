---
Description: 色により、アプリのさまざまな情報レベルで直感的に移動先を見つけることができます。また、色は操作モデルを強化するための重要なツールとして機能します。
title: 色
ms.assetid: 3ba7176f-ac47-498c-80ed-4448edade8ad
label: Color
template: detail.hbs
extraBodyClass: style-color
brief: Color provides intuitive wayfinding through an app's various levels of information and serves as a crucial tool for reinforcing the interaction model.<br /><br />In Windows, color is also personal. Users can choose a color and a light or dark theme to be reflected throughout their experience.
---

# UWP アプリの色
色により、アプリのさまざまな情報レベルで直感的に移動先を見つけることができます。また、色は操作モデルを強化するための重要なツールとして機能します。

## アクセント カラー

ユーザーは、アクセントと呼ばれる 1 つの色を選ぶことができます。 選別された 48 色の見本から選びます。


<!-- Alternate version for the dev center. Need to add hex values. -->
<figure>
![Accent colors](images/accentcolorswatch.png)
<figcaption>一般に、元のアクセント カラーを背景として使用する場合は、必ず白色のテキストをその上に配置します。</figcaption>
</figure>

ユーザーがアクセント カラーを選ぶと、その色がシステムのテーマの一部として表示されます。 アクセント カラーが適用される領域は、スタート画面、タスク バー、ウィンドウ クロム、選択した操作の状態、および[共通コントロール](https://dev.windows.com/design/controls-patterns)内のハイパーリンクです。 また、各アプリの文字体裁、背景、および操作にアクセント カラーを組み込んだり、アクセント カラーを無視してアプリ固有のブランドを維持したりできます。

## 色の選択

アクセント カラーを選ぶと、色の明度の HCL 値に基づいて明るい色調と暗い色調のアクセント カラーが作成されます。 アプリはこの色調のバリエーションを使用して視覚的な階層を作成し、操作を示します。

![1 つのアクセント カラーとその 6 つの色調](images/shades.png)

<aside class="aside-dev">
    <div class="aside-dev-title">
    </div>
    <div class="aside-dev-content">
            In XAML, the accent color is exposed as a [theme resource](https://msdn.microsoft.com/en-us/library/windows/apps/Mt187274.aspx) named `SystemAccentColor`. It's also available programmatically from [UISettings.GetColorValue](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.viewmanagement.uisettings.getcolorvalue.aspx). You can programmatically access the different shades from [UISettings.GetColorValue](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.viewmanagement.uisettings.getcolorvalue.aspx), see the [UIColorType](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.viewmanagement.uicolortype.aspx) enum.
    </div>
</aside>

## 色のテーマ

ユーザーはシステムの淡色テーマまたは濃色テーマを選ぶこともできます (携帯電話の場合。タブレットとデスクトップにはこのオプションが用意されていません。タブレットとデスクトップではアプリ内の設定を使用できます)。 一部のアプリでは、ユーザーの設定を基にテーマを変更し、その他のテーマを使用しないように選択できます。

淡色テーマを使用するアプリは、生産性アプリが関係するシナリオに適しています。 Microsoft Office で利用可能なアプリ スイートがその例です。 淡色テーマを使用すると、長時間のタスクの際に長いテキストが読みやすくなります。

濃色テーマを使用すると、メディアを中心とするアプリまたは多数のビデオや画像がユーザーに対して表示されるシナリオにおいて、コンテンツのコントラストをはっきりさせることができます。 このようなシナリオでは、映画を視聴する場合や、低光量の周囲条件下であっても、読むことが必ずしも第一の目標というわけではありません。

前述のどちらかの説明に該当しないアプリの場合は、ユーザーが最適なテーマを決められるように、次のシステム テーマの使用を検討してください。

テーマを設計しやすくするために、Windows では、テーマに合わせて自動的に追加のカラー パレットが表示されます。


<!-- OP version -->
### 淡色テーマ
#### 基本
![淡色テーマ (基本)](images/themes-light-base.png)
#### 代替
![淡色テーマ (代替)](images/themes-light-alt.png)
#### リスト
![淡色テーマ (リスト)](images/themes-light-list.png)
#### クロム
![淡色テーマ (クロム)](images/themes-light-chrome.png)
### 濃色テーマ
#### 基本
![濃色テーマ (基本)](images/themes-dark-base.png)
#### 代替
![濃色テーマ (代替)](images/themes-dark-alt.png)
#### リスト
![濃色テーマ (リスト)](images/themes-dark-list.png)
#### クロム
![濃色テーマ (クロム)](images/themes-dark-chrome.png)


<aside class="aside-dev">
    <div class="aside-dev-title">
    </div>
    <div class="aside-dev-content">
            Each color is available as a XAML [theme resource](https://msdn.microsoft.com/en-us/library/windows/apps/Mt187274.aspx#the_xaml_color_ramp_and_theme-dependent_brushes) that follows the `System*Color` naming convention (ex: `SystemChromeHighColor`). You can control your app's theme through either [Application.RequestedTheme](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.application.requestedtheme.aspx) or [FrameworkElement.RequestedTheme](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.frameworkelement.requestedtheme.aspx).
    </div>
</aside>

## アクセシビリティ

画面を使用するためにパレットが最適化されています。 読みやすさをできる限り高めるため、テキストのコントラスト比を 4.5:1 以上にすることをお勧めします。


<!--HONumber=Mar16_HO5-->


