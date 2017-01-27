---
author: Jwmsft
Description: "UWP アプリのフォントを選び、フォントのサイズと色を指定するときには、次のガイドラインに従ってください。"
title: "UWP アプリ用のフォント"
ms.assetid: 1B8B90AD-CDC4-4997-ACDE-871C1E94A929
label: Fonts
template: detail.hbs
translationtype: Human Translation
ms.sourcegitcommit: a3924fef520d7ba70873d6838f8e194e5fc96c62
ms.openlocfilehash: 0b25dc91a5ec82a83ae24a41854e9eeab8990128

---


# <a name="fonts-for-uwp-apps"></a>UWP アプリ用のフォント

<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css"> 

この記事では、UWP アプリの推奨フォントを示します。 これらのフォントは、UWP アプリをサポートするすべての Windows 10 エディションで利用可能なことが保証されています。

<div class="important-apis" >
<b>重要な API</b><br/>
<ul>
<li>[**FontFamily プロパティ**](https://msdn.microsoft.com/library/windows/apps/br209655)</li>
</ul>
</div>

[UWP 文字体裁ガイド](typography.md)ではアプリに Segoe UI フォントを使用するようお勧めしています。Segoe UI はほとんどのアプリに適した選択ですが、すべての場合にこれを使用しなければならないわけではありません。 読み物や英語以外の特定の言語でのテキストの表示など、シナリオによっては、他のフォントを使うことができます。 
 
## <a name="sans-serif-fonts"></a>サンセリフ フォント

サンセリフ フォントは、ヘッダーと UI 要素に適しています。 

<table>
<colgroup>
<col width="33%" />
<col width="33%" />
<col width="33%" />
</colgroup>
<thead>
<tr class="header">
<th align="left">フォント ファミリー</th>
<th align="left">スタイル</th>
<th align="left">コメント</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left" style="font-family: Arial;">Arial</td>
<td align="left">標準、斜体、太字、太字斜体、黒</td>
<td align="left">ヨーロッパおよび中東のスクリプト (ラテン文字、ギリシャ文字、キリル文字、アラビア文字、アルメニア文字、ヘブライ文字) をサポートしています。極太の太さがサポートされているのはヨーロッパのスクリプトだけです。</td>
</tr>
<tr class="even">
<td align="left" style="font-family: Calibri;">Calibri</td>
<td align="left">標準、斜体、太字、太字斜体、細字、細字斜体</td>
<td align="left">ヨーロッパおよび中東のスクリプト (ラテン文字、ギリシャ文字、キリル文字、アラビア語、ヘブライ語) をサポートしています。 アラビア語は縦書きでのみ利用できます。</td>
</tr>
<td style="font-family: Consolas;">Consolas</td>
<td>標準、斜体、太字、太字斜体</td>
<td>ヨーロッパのスクリプト (ラテン文字、ギリシャ文字、キリル文字) をサポートする等幅フォント。</td>
</tr>

<tr>
<td style="font-family: Segoe UI;">Segoe UI</td>
<td>標準、斜体、細字斜体、極太斜体、太字、太字斜体、細字、中細、中太、極太</td>
<td>ヨーロッパおよび中東のスクリプト (アラビア文字、アルメニア文字、キリル文字、ジョージア文字、ギリシャ文字、ヘブライ文字、ラテン文字) およびリス文字のスクリプト用のユーザー インターフェイス フォント。</td>
</tr>

<tr class="odd">
<td>Segoe UI Historic</td>
<td align="left">標準</td>
<td align="left">歴史上のスクリプト用のフォールバック フォント</td>
</tr>

<tr class="even">
<td style="font-family: Selawik;">Selawik</td>
<td align="left">標準、中細、細字、太字、中太</td>
<td align="left">他のプラットフォーム上で動作する Segoe UI をバンドルしないアプリ向けの、Segoe UI と測定上の互換性があるオープン ソース フォント。 [Selawik は、GitHub で入手できます。](https://github.com/Microsoft/Selawik)</td>
</tr>

<tr class="even">
<td style="font-family: Verdana;">Verdana</td>
<td align="left">標準、斜体、太字、太字斜体</td>
<td align="left">ヨーロッパのスクリプト (ラテン文字、ギリシャ文字、キリル文字、アルメニア文字) をサポートしています。</td>
</tr>

</tbody>
</table>


## <a name="serif-fonts"></a>セリフ フォント

セリフ フォントは、大量のテキストを表示するのに適しています。 

<table>
<thead>
<tr class="header">
<th align="left">フォント ファミリー</th>
<th align="left">スタイル</th>
<th align="left">コメント</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td style="font-family: Cambria;">Cambria</td>
<td align="left">標準</td>
<td align="left">ヨーロッパのスクリプト (ラテン文字、ギリシャ文字、キリル文字) をサポートするセリフ フォント。</td>
</tr>
<tr class="even">
<td style="font-family: Courier New;">Courier New</td>
<td align="left">標準、斜体、太字、太字斜体</td>
<td align="left">セリフ等幅フォントは、ヨーロッパおよび中東のスクリプト (ラテン文字、ギリシャ文字、キリル文字、アラビア文字、アルメニア文字、ヘブライ文字) をサポートしています。</td>
</tr>
<tr class="odd">
<td style="font-family: Georgia;">Georgia</td>
<td align="left">標準、斜体、太字、太字斜体</td>
<td align="left">ヨーロッパのスクリプト (ラテン文字、ギリシャ文字、キリル文字) をサポートしています。</td>
</tr>


<tr class="even">
<td style="font-family: Times New Roman;">Times New Roman</td>
<td align="left">標準、斜体、太字、太字斜体</td>
<td align="left">ヨーロッパのスクリプト (ラテン文字、ギリシャ文字、キリル文字、アラビア文字、アルメニア文字、ヘブライ文字) をサポートしている従来のフォント。</td>
</tr>

</tbody>
</table>

## <a name="symbols-and-icons"></a>シンボルとアイコン


<table>
<thead>
<tr class="header">
<th align="left">フォント ファミリー</th>
<th align="left">スタイル</th>
<th align="left">コメント</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left">Segoe MDL2 アセット</td>
<td align="left">標準</td>
<td align="left">アプリ アイコン用のユーザー インターフェイス フォント。 詳しくは、[Segoe MDL2 アセットの記事](segoe-ui-symbol-font.md)をご覧ください。</td>
</tr>
<tr class="even">
<td align="left">Segoe UI Emoji</td>
<td align="left">標準</td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left">Segoe UI Symbol</td>
<td align="left">標準</td>
<td align="left">記号用のフォールバック フォント</td>
</tr>
</tbody>
</table>



## <a name="fonts-for-non-latin-languages"></a>ラテン語以外の言語用のフォント

ただし、これらのフォントの多くでは、ラテン文字が提供されています。

<table>
<thead>
<tr class="header">
<th align="left">フォント ファミリー</th>
<th align="left">スタイル</th>
<th align="left">コメント</th>
</tr>
</thead>
<tbody>

<tr class="odd">
<td style="font-family: Embrima;">Ebrima</td>
<td align="left">標準、太字</td>
<td align="left">アフリカのスクリプト (エチオピア文字、ンコ文字、オスマニア文字、ティフィナグ文字、ヴァイ文字) 用のユーザー インターフェイス フォント。</td>
</tr>
<tr class="even">
<td style="font-family: Gadugi;">Gadugi</td>
<td align="left">標準、太字</td>
<td align="left">北アメリカ スクリプト (カナダ音節文字、チェロキー文字) 用のユーザー インターフェイス フォント。</td>
</tr>
<tr class="even">
<td align="left">ジャワ文字のスクリプト用のジャワ文字のテキストの標準フォールバック フォント</td>
<td align="left">標準</td>
<td align="left">ジャワ文字のスクリプト用のフォールバック フォント</td>
</tr>
<tr class="odd">
<td align="left" style="font-family: Leelawadee UI;">Leelawadee UI</td>
<td align="left">通常、Semilight、太字</td>
<td align="left">東南アジアのスクリプト (ブギス文字、ラオス文字、クメール文字、タイ文字) 用のユーザー インターフェイス フォント。</td>
</tr>

<tr class="odd">
<td align="left" style="font-family: Malgun Gothic;">Malgun Gothic</td>
<td align="left">標準</td>
<td align="left">韓国語用のユーザー インターフェイス フォント。</td>
</tr>
<tr class="even">
<td align="left" style="font-family: Microsoft Himalaya;">Microsoft Himalaya</td>
<td align="left">標準</td>
<td align="left">チベット文字のスクリプト用のフォールバック フォント。</td>
</tr>
<!--
<tr class="odd">
<td align="left" style="font-family: Microsoft JhengHei;">Microsoft JhengHei</td>
<td align="left">Regular</td>
<td align="left"></td>
</tr>
-->
<tr class="even">
<td align="left" style="font-family: Microsoft JhengHei UI;">Microsoft JhengHei UI</td>
<td align="left">標準、太字、細字</td>
<td align="left">繁体字中国語用のユーザー インターフェイス フォント。</td>
</tr>
<tr class="odd">
<td align="left" style="font-family: Microsoft New Tai Lue;">Microsoft New Tai Lue</td>
<td align="left">標準</td>
<td align="left">新タイ ロ文字のスクリプト用のフォールバック フォント。</td>
</tr>
<tr class="even">
<td align="left" style="font-family: Microsoft PhagsPa;">Microsoft PhagsPa</td>
<td align="left">標準</td>
<td align="left">パスパ文字のスクリプト用のフォールバック フォント。</td>
</tr>
<tr class="odd">
<td align="left" style="font-family: Microsoft Tai Le;">Microsoft Tai Le</td>
<td align="left">標準</td>
<td align="left">タイ ロ文字のスクリプト用のフォールバック フォント。</td>
</tr>
<!--
<tr class="even">
<td align="left" style="font-family: Microsoft YaHei;">Microsoft YaHei</td>
<td align="left">Regular</td>
<td align="left"></td>
</tr>
-->
<tr class="odd">
<td align="left" style="font-family: Microsoft YaHei UI;">Microsoft YaHei UI</td>
<td align="left">標準、太字、細字</td>
<td align="left">簡体字中国語用のユーザー インターフェイス フォント。</td>
</tr>
<tr class="even">
<td align="left" style="font-family: Microsoft Yi Baiti;">Microsoft Yi Baiti</td>
<td align="left">標準</td>
<td align="left">イ文字のスクリプト用のフォールバック フォント。</td>
</tr>
<tr class="odd">
<td align="left" style="font-family: Mongolian Baiti;">Mongolian Baiti</td>
<td align="left">標準</td>
<td align="left">モンゴル文字のスクリプト用のフォールバック フォント。</td>
</tr>
<tr class="even">
<td align="left" style="font-family: MV Boli;">MV Boli</td>
<td align="left">標準</td>
<td align="left">ターナ文字のスクリプト用のフォールバック フォント。</td>
</tr>
<tr class="odd">
<td align="left" style="font-family: Myanmar Text;">Myanmar Text</td>
<td align="left">標準</td>
<td align="left">ミャンマー文字のスクリプト用のフォールバック フォント。</td>
</tr>
<tr class="even">
<td align="left" style="font-family: Nirmala UI;">Nirmala UI</td>
<td align="left">標準、中細、太字</td>
<td align="left">南アジア言語のスクリプト (バングラ文字、デーバナーガリー文字、グジャラート文字、グルムキー文字、カンナダ文字、マラヤーラム文字、オディア文字、オル チキ文字、シンハラ文字、ソラング ソンペング文字、タミール文字、テルグ文字) 用のユーザー インターフェイス フォント</td>
</tr>

<tr class="odd">
<td align="left" style="font-family: SimSun;">SimSun</td>
<td align="left">標準</td>
<td align="left">中国語繁体字の UI フォント。 </td>
</tr>
<tr class="odd">
<td align="left" style="font-family: Yu Gothic;">Yu Gothic</td>
<td align="left">中</td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left" style="font-family: Yu Gothic UI;">Yu Gothic UI</td>
<td align="left">標準</td>
<td align="left">日本語用のユーザー インターフェイス フォント。</td>
</tr>
</tbody>
</table>


## <a name="globalizinglocalizing-fonts"></a>フォントのグローバリゼーション/ローカライズ
特定言語の推奨フォント ファミリー、サイズ、太さ、スタイルにプログラムを使ってアクセスする場合は、[LanguageFont フォント マッピング API](https://msdn.microsoft.com/library/windows/apps/br206864) を使ってください。 LanguageFont オブジェクトを使うと、コンテンツのさまざまなカテゴリ (UI ヘッダー、通知、本文のテキスト、ユーザー自身で編集できるドキュメント本文のフォントなど) の正しいフォント情報にアクセスできます。 詳しくは、「[レイアウトとグローバリゼーションをサポートするフォントの調整](https://msdn.microsoft.com/windows/uwp/globalizing/adjust-layout-and-fonts--and-support-rtl)」をご覧ください。


## <a name="get-the-samples"></a>サンプルの入手

* [ダウンロード可能なフォントのサンプル](https://github.com/Microsoft/Windows-universal-samples/blob/master/Samples/XamlCloudFontIntegration)
* [UI の基本のサンプル](https://github.com/Microsoft/Windows-universal-samples/blob/master/Samples/XamlUIBasics)
* [DirectWrite を使用した行間のサンプル](https://github.com/Microsoft/Windows-universal-samples/blob/master/Samples/DWriteLineSpacingModes) 

## <a name="related-articles"></a>関連記事

* [レイアウトとグローバリゼーションをサポートするフォントの調整](https://msdn.microsoft.com/windows/uwp/globalizing/adjust-layout-and-fonts--and-support-rtl)
* [Segoe MDL2](segoe-ui-symbol-font.md)
* [テキスト コントロール](../controls-and-patterns/text-controls.md)
* [XAML テーマ リソース](https://msdn.microsoft.com/library/windows/apps/mt187274)

 

 







<!--HONumber=Dec16_HO2-->


