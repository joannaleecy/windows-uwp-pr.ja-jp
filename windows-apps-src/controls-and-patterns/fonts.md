---
Description: フォントを選び、フォントのサイズと色を指定するときには、次のガイドラインに従ってください。
title: フォント
ms.assetid: 1B8B90AD-CDC4-4997-ACDE-871C1E94A929
label: フォント
template: detail.hbs
---

# フォントのガイドライン


\[ Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください \]


**重要な API**

-   [**FontFamily (XAML)**](https://msdn.microsoft.com/library/windows/apps/br209655)
-   [**font-family (HTML)**](https://msdn.microsoft.com/library/windows/apps/hh996845)
-   [**font-size (HTML)**](https://msdn.microsoft.com/library/windows/apps/hh996846)

フォントのサイズ、太さ、色、トラッキング、間隔を適切に設定すると、外観がきれいに整い、ユニバーサル Windows プラットフォーム (UWP) アプリが使いやすくなります。 フォントを選び、フォントのサイズと色を指定するときには、次のガイドラインに従ってください。

Segoe UI Symbol アイコンの一覧については、「[**Segoe UI Symbol アイコンのガイドライン**](segoe-ui-symbol-font.md)」をご覧ください。

## <span id="The_Windows_10_type_ramp"></span><span id="the_windows_10_type_ramp"></span><span id="THE_WINDOWS_10_TYPE_RAMP"></span>Windows 10 の書体見本


書体見本 (type ramp) は、ヘッドラインからの本文までの重要なデザインの関係を確立し、異なるレベル間の明快でわかりやすい階層を保証します。 ユーザーは、情報を見つける場所やページの解析方法をすぐに理解できます。

UWP アプリ用にお勧めする書体見本を次に示します。

| テキスト スタイル | 書体 | 太さ    | サイズ (epx) | 行間 (epx) | 単語の間隔 | トラッキング (1/1000 em) | XAML スタイル キー          |
|------------|----------|-----------|------------|--------------------|--------------|----------------------|-------------------------|
| ヘッダー     | Segoe UI | 細い     | 46         | 56                 | 100%         | 0                    | HeaderTextBlockStyle    |
| サブヘッダー  | Segoe UI | 細い     | 34         | 40                 | 100%         | 0                    | SubheaderTextBlockStyle |
| タイトル      | Segoe UI | Semilight | 24         | 28                 | 100%         | 0                    | TitleTextBlockStyle     |
| サブタイトル   | Segoe UI | 通常   | 20         | 24                 | 100%         | 0                    | SubtitleTextBlockStyle  |
| ベース       | Segoe UI | Semibold  | 15         | 20                 | 100%         | 0                    | BaseTextBlockStyle      |
| 本文       | Segoe UI | 通常   | 15         | 20                 | 100%         | 0                    | BodyTextBlockStyle      |
| 字幕    | Segoe UI | 通常   | 12         | 14                 | 100%         | 0                    | CaptionTextBlockStyle   |

 

## <span id="Recommended_fonts"></span><span id="recommended_fonts"></span><span id="RECOMMENDED_FONTS"></span>推奨フォント


すべてに対して、必ずしも Segoe UI フォントを使う必要はありません。 読み取りや英語以外の言語でのテキストの表示など、特定のシナリオでは、他のフォントを使うことができます。

ここでは、UWP アプリをサポートするすべての Windows 10 エディションで利用可能なことが保証されているフォントの一覧を示します。

**注**  この一覧に含まれていないフォントを使う場合、アプリは Microsoft サービスのフォント データの自動ダウンロードをトリガーすることができます。 これは、特にモバイル デバイスでは、パフォーマンスやその他の影響が懸念の対象となる可能性があります。 具体的には、これによりユーザーのモバイル データ プランの一部が使用されたり、モバイル データ使用コストが発生したりする可能性があります。 モバイル デバイスで利用できる UWP アプリでは、UI コンテンツにこのリスト以外のフォントを使用することはできません。

 

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
<td align="left">Arial</td>
<td align="left">通常、斜体、太字、太字斜体、黒</td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left">Calibri</td>
<td align="left">通常、斜体、太字、太字斜体、中細、中細斜体</td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left">Cambria</td>
<td align="left">通常</td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left">Cambria Math</td>
<td align="left">通常</td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left">Comic Sans MS</td>
<td align="left">通常、斜体、太字、太字斜体</td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left">Courier New</td>
<td align="left">通常、斜体、太字、太字斜体</td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left">Ebrima</td>
<td align="left">通常、太字</td>
<td align="left">アフリカのスクリプト (エチオピア文字、ンコ文字、オスマニア文字、ティフィナグ文字、ヴァイ文字) 用のユーザー インターフェイス フォント</td>
</tr>
<tr class="even">
<td align="left">Gadugi</td>
<td align="left">通常</td>
<td align="left">北アメリカ スクリプト (カナダ音節文字、チェロキー文字) 用のユーザー インターフェイス フォント</td>
</tr>
<tr class="odd">
<td align="left">Georgia</td>
<td align="left">通常、斜体、太字、太字斜体</td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left">ジャワ文字のスクリプト用のジャワ文字のテキストの標準フォールバック フォント</td>
<td align="left">通常</td>
<td align="left">ジャワ文字のスクリプト用のフォールバック フォント</td>
</tr>
<tr class="odd">
<td align="left">Leelawadee UI</td>
<td align="left">通常、Semilight、太字</td>
<td align="left">東南アジアのスクリプト (ブギス文字、ラオス文字、クメール文字、タイ文字) 用のユーザー インターフェイス フォント</td>
</tr>
<tr class="even">
<td align="left">Lucida Console</td>
<td align="left">通常</td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left">Malgun Gothic</td>
<td align="left">通常</td>
<td align="left">韓国語用のユーザー インターフェイス フォント</td>
</tr>
<tr class="even">
<td align="left">Microsoft Himalaya</td>
<td align="left">通常</td>
<td align="left">チベット文字のスクリプト用のフォールバック フォント</td>
</tr>
<tr class="odd">
<td align="left">Microsoft JhengHei</td>
<td align="left">通常</td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left">Microsoft JhengHei UI</td>
<td align="left">通常</td>
<td align="left">繁体字中国語用のユーザー インターフェイス フォント</td>
</tr>
<tr class="odd">
<td align="left">Microsoft New Tai Lue</td>
<td align="left">通常</td>
<td align="left">新タイ ロ文字のスクリプト用のフォールバック フォント</td>
</tr>
<tr class="even">
<td align="left">Microsoft PhagsPa</td>
<td align="left">通常</td>
<td align="left">パスパ文字のスクリプト用のフォールバック フォント</td>
</tr>
<tr class="odd">
<td align="left">Microsoft Tai Le</td>
<td align="left">通常</td>
<td align="left">タイ ロ文字のスクリプト用のフォールバック フォント</td>
</tr>
<tr class="even">
<td align="left">Microsoft YaHei</td>
<td align="left">通常</td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left">Microsoft YaHei UI</td>
<td align="left">通常</td>
<td align="left">簡体字中国語用のユーザー インターフェイス フォント</td>
</tr>
<tr class="even">
<td align="left">Microsoft Yi Baiti</td>
<td align="left">通常</td>
<td align="left">イ文字のスクリプト用のフォールバック フォント</td>
</tr>
<tr class="odd">
<td align="left">Mongolian Baiti</td>
<td align="left">通常</td>
<td align="left">モンゴル文字のスクリプト用のフォールバック フォント</td>
</tr>
<tr class="even">
<td align="left">MV Boli</td>
<td align="left">通常</td>
<td align="left">ターナ文字のスクリプト用のフォールバック フォント</td>
</tr>
<tr class="odd">
<td align="left">Myanmar Text</td>
<td align="left">通常</td>
<td align="left">ミャンマー文字のスクリプト用のフォールバック フォント</td>
</tr>
<tr class="even">
<td align="left">Nirmala UI</td>
<td align="left">通常、Semilight、太字</td>
<td align="left">南アジア言語のスクリプト (バングラ文字、デーバナーガリー文字、グジャラート文字、グルムキー文字、カンナダ文字、マラヤーラム文字、オディア文字、オル チキ文字、シンハラ文字、ソラング ソンペング文字、タミール文字、テルグ文字) 用のユーザー インターフェイス フォント</td>
</tr>
<tr class="odd">
<td align="left">Segoe MDL2 アセット</td>
<td align="left">通常</td>
<td align="left">アプリ アイコン用のユーザー インターフェイス フォント</td>
</tr>
<tr class="even">
<td align="left">Segoe Print</td>
<td align="left">通常</td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left">Segoe UI</td>
<td align="left">通常、斜体、太字、斜体、太字斜体、中細、Semilight、Semibold、黒</td>
<td align="left">ヨーロッパおよび中東のスクリプト (アラビア文字、アルメニア文字、キリル文字、ジョージア文字、ギリシャ文字、ヘブライ文字、ラテン文字) およびリス文字のスクリプト用のユーザー インターフェイス フォント</td>
</tr>
<tr class="even">
<td align="left">Segoe UI Emoji</td>
<td align="left">通常</td>
<td align="left">Windows Phone に付属しているバージョンでは、各絵文字の周りに白い線が示されており、どのような色の背景にでも表示されます。 Windows に付属するバージョンと測定的に互換性があります。</td>
</tr>
<tr class="odd">
<td align="left">Segoe UI Historic</td>
<td align="left">通常</td>
<td align="left">歴史上のスクリプト用のフォールバック フォント</td>
</tr>
<tr class="even">
<td align="left">Segoe UI Symbol</td>
<td align="left">通常</td>
<td align="left">記号用のフォールバック フォント</td>
</tr>
<tr class="odd">
<td align="left">SimSun</td>
<td align="left">通常</td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left">Times New Roman</td>
<td align="left">通常、斜体、太字、太字斜体</td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left">Trebuchet MS</td>
<td align="left">通常、斜体、太字、太字斜体</td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left">Verdana</td>
<td align="left">通常、斜体、太字、太字斜体</td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left">Webdings</td>
<td align="left">通常</td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left">Wingdings</td>
<td align="left">通常</td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left">Yu Gothic</td>
<td align="left">普通</td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left">Yu Gothic UI</td>
<td align="left">通常</td>
<td align="left">日本語用のユーザー インターフェイス フォント</td>
</tr>
</tbody>
</table>

 

## 関連トピック


**デザイナー向け**
* [ラベル (またはテキスト ブロック)](labels.md)
* [Segoe UI Symbol アイコン](segoe-ui-symbol-font.md)
**開発者向け (XAML)**
* [XAML テーマ リソース](https://msdn.microsoft.com/library/windows/apps/mt187274)
* [アプリのページのレイアウト](https://msdn.microsoft.com/library/windows/apps/hh872191)
* [Segoe UI Symbol アイコン](segoe-ui-symbol-font.md)
* [**TextBlock.FontFamily プロパティ**](https://msdn.microsoft.com/library/windows/apps/br209655)

**サンプル**
* [XAML テキスト表示のサンプル](http://go.microsoft.com/fwlink/p/?linkid=238578)
* [CSS スタイル: アプリのブランド設定のサンプル](http://go.microsoft.com/fwlink/p/?linkid=231641)
* [言語フォント マッピングのサンプル](http://go.microsoft.com/fwlink/p/?linkid=231603)
 

 






<!--HONumber=Mar16_HO1-->


