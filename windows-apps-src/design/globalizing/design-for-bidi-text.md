---
author: stevewhims
Description: Design your app to provide bidirectional text support (BiDi) so that you can combine script from left-to-right (LTR) and right-to-left (RTL) writing systems, which generally contain different types of alphabets.
title: 双方向テキストに対応したアプリを設計する
template: detail.hbs
ms.author: stwhi
ms.date: 11/10/2017
ms.topic: article
keywords: Windows 10, UWP, グローバリゼーション, ローカライズの可否, ローカライズ, RTL, LTR
ms.localizationpriority: medium
ms.openlocfilehash: 24e4c5dfce4aa3e773ab8c334ca732ac5ed53030
ms.sourcegitcommit: ca96031debe1e76d4501621a7680079244ef1c60
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/31/2018
ms.locfileid: "5831036"
---
# <a name="design-your-app-for-bidirectional-text"></a>双方向テキストに対応したアプリを設計する

通常はさまざまな種類のアルファベットを含む、右から左方向 (RTL) および左から右方向 (LTR) 書記体系のスクリプトを組み合わせることができるように、双方向テキスト サポート (BiDi) を備えたアプリを設計します。

中東、中央アジアおよび南アジア、アフリカで使用される言語のように、右から左への書記体系には、独自の設計要件があります。 これらの書記体系には双方向テキスト サポート (BiDi) が必要です。 BiDi サポートは、右から左 (RTL) または左から右 (LTR) の順序のテキスト レイアウトを入力して表示する機能です。

Windows には合計 9 種類の BiDi 言語が含まれています。
- 完全にローカライズされた 2 つの言語。 アラビア語とヘブライ語。
- 新興市場向けの 7 種類の言語インターフェイス パック。 ペルシャ語、ウルドゥー語、ダリー語、中央クルド語、シンド語、パンジャーブ語 (パキスタン)、ウイグル語。

このトピックでは、Windows に関する BiDi 対応の設計哲学を紹介し、BiDi 対応の設計時の考慮事項を示すケース スタディを取り上げます。

## <a name="bidi-design-elements"></a>BiDi 対応の設計要素

4 つの要素が、Windows の BiDi に関する設計上の決定に影響を与えます。

- **ユーザー インターフェイス (UI) のミラー化**。 ユーザー インターフェイス (UI) のフローで右から左への読み取り順序のコンテンツをネイティブ レイアウトに表示できるようにします。 UI デザインが BiDi 市場に対してローカルなものになります。
- **ユーザー エクスペリエンスの一貫性**。 右から左の方向で自然に感じられるデザインを提供します。 UI 要素が、共通した一貫性のあるレイアウト方向でユーザーの期待どおりに表示されます。
- **タッチの最適化**。 ミラー化されていない UI におけるタッチ UI によく似た、簡単で自然なタッチによる対話式操作で UI 要素を操作できるようにします。
- **混在テキストのサポート**。 テキスト方向のサポートにより、混在テキストを美しく表示できます (BiDi ビルドに英語のテキストを表示、または英語ビルドに BiDi テキストを表示)。

## <a name="feature-design-overview"></a>機能設計の概要

Windows は、4 つの BiDi 対応の設計要素をサポートしています。 ここでは、Windows の主な関連機能について説明し、それらの機能がアプリに影響するしくみに関するコンテキストを取り上げます。

### <a name="navigate-in-the-direction-that-feels-natural"></a>自然な形になる方向に配置する

Windows では文字体裁グリッドの方向が右から左の順序になるように調整します。つまり、グリッド上の最初のタイルは右上隅に配置され、最後のタイルは左下隅に配置されます。 これは、本や雑誌などの刊行物の RTL パターンに一致します。読み取りパターンは常に右上隅から始まり、左に向かって進んでいくことになります。

![BiDi スタート メニュー](images/56283_BIDI_01_startscreen_resized.png)
![チャーム付き BiDi スタート メニュー](images/56283_BIDI_02_startscreen_charm_resized.png)

一貫性のある UI のフローを維持するために、タイルのコンテンツは常に右から左のレイアウトが保持されます。つまり、アプリの UI 言語に関係なく、アプリ名とロゴはタイルの右下隅に配置されます。

#### <a name="bidi-tile"></a>BiDi 対応のタイル

![BiDi 対応のタイル](images/56284_BIDI_03_tile_callouts_withKey.png)

#### <a name="english-tile"></a>英語のタイル

![英語のタイル](images/56284_BIDI_03_tile_callouts_en-us.png)

### <a name="get-tile-notifications-that-read-correctly"></a>正しく読み取ることができるタイル通知を表示する

タイルは混在テキストをサポートします。 通知領域には、通知言語に応じてテキスト配置の方向を調整できる柔軟性が組み込まれています。  アプリでアラビア語、ヘブライ語などの BiDi 言語の通知を送信する場合、テキストは右揃えに調整されます。 英語またはその他の左から右方向 (LTR) の言語の通知を受信した場合、その通知は左揃えに調整されます。

![タイル通知](images/56285_BIDI_04_bidirectional_tiles_white.png)

### <a name="a-consistent-easy-to-touch-rtl-user-experience"></a>一貫性のあるタッチしやすい RTL ユーザー エクスペリエンス

Windows UI のすべての要素は、RTL の読み取り方向に適合します。 チャームとポップアップは画面の左端に配置されているため、検索結果に重ならず、快適なタッチ操作の邪魔になることもありません。 親指で簡単に操作できます。

![BiDi のスクリーンショット](images/56286_BIDI_05_search_flyout_resized.png)
![BiDi のスクリーンショット](images/56286_BIDI_06_print_flyout_resized.png)

![BiDi のスクリーンショット](images/56286_BIDI_07_settings_flyout_resized.png)
![BiDi のスクリーンショット](images/56286_BIDI_08_app_bars_resized.png)

### <a name="text-input-in-any-direction"></a>任意の方向へのテキスト入力

Windows には、すっきり整理されたスクリーン タッチ キーボードが備わっています。 BiDi 言語の場合、テキスト方向のコントロール キーがあるため、テキスト入力の方向を必要に応じて切り替えることができます。

![BiDi 言語用のタッチ キーボード](images/56287_BIDI_09_keyboard_layout_resized.png)

### <a name="use-any-app-in-any-language"></a>任意の言語でのアプリの使用

任意の言語でお気に入りのアプリをインストールして使うことができます。 アプリは、BiDi 対応ではないバージョンの Windows の場合と同じように表示され、機能します。 アプリの要素は常に一貫性のある予測可能な位置に配置されます。

![BiDi コンテンツを表示する英語のアプリ](images/56288_BIDI_10_english_app_resized.png)

### <a name="display-parentheses-correctly"></a>かっこの正しい表示

BiDi Parenthesis Algorithm (BPA) を導入すると、言語やテキスト配置の方向に関係なく、ペアになったかっこは常に正しく表示されます。

#### <a name="incorrect-parentheses"></a>不適切なかっこ

![不適切なかっこを表示している BiDi アプリ](images/56289_BIDI_11_parentheses_resized.png)

#### <a name="correct-parentheses"></a>適切なかっこ

![適切なかっこを表示している BiDi アプリ](images/56289_BIDI_12_parentheses_fixed_resized.png)

### <a name="typography"></a>文字体裁

Windows では、Segoe UI フォントを使ってすべての BiDi 言語に対応しています。 このフォントは、Windows UI に応じた外観と大きさになっています。

![BiDi 言語用の Segoe UI フォント](images/56290_BIDI_13_start_screen_segoe.png)
![BiDi 言語用の Segoe UI フォント](images/56290_BIDI_13_start_screen_segoe_arabic.png)

## <a name="case-study-1-a-bidi-music-app"></a>ケース スタディ #1: BiDi 対応のミュージック アプリ

### <a name="overview"></a>概要

マルチメディア アプリは、非常に興味深い設計上の問題を提起します。一般にメディア コントロールは、BiDi 以外の言語の場合と同様の左から右のレイアウトであることが想定されているためです。

![メディア コントロール (左から右)](images/56291_BIDI_1415_music_player_layouts_left-withcallouts.png)

![メディア コントロール (右から左)](images/56291_BIDI_1415_music_player_layouts_right-withcallouts.png)

### <a name="establishing-ui-directionality"></a>UI の方向の設定

BiDi 市場向けの設計で一貫性を確保するためには、右から左への UI のフローを保持することが重要です。 このコンテキストで左から右へのフローの要素を追加するのは困難です。戻るボタンなどの一部のナビゲーション要素が、オーディオ コントロールの戻るボタンの方向と矛盾を生じる可能性があるからです。

![ミュージック アプリの追跡ページ](images/56292_BIDI_16_app_layout_callouts_resized.png)

このミュージック アプリでは、右から左への方向のグリッドが保持されます。 そのため、既に Windows UI でこの方向による操作を行っているユーザーにとっては、アプリで非常に自然な操作感が得られます。 主な要素を右から左の読み取り順序にするだけでなく、セクション ヘッダーでも適切な方向の配置を行うことは、UI のフローを維持するために有効です。

![ミュージック アプリのアルバム ページ](images/56292_BIDI_17_app_layout_callouts_resized.png)

### <a name="text-handling"></a>テキストの処理

上のスクリーンショットのアーティストの略歴は左揃えですが、アルバム名やトラック名などのその他のアーティスト関連テキストは右揃えが維持されています。 略歴のフィールドは非常に大きなテキスト要素であり、右揃えの場合、幅の広いテキスト ブロックを読み取るときに行を追うことが難しくなるため、読みづらくなります。 一般に、5 つ以上の語句を含む行が 3 行以上あるテキスト要素で、同様の位置揃えの例外を考慮する必要があります。この場合、テキスト ブロックの位置揃えがアプリの全体的な方向レイアウトとは逆になります。

アプリ全体の位置揃えの操作は単純そうに見えますが、多くの場合、BiDi 文字列におけるニュートラル文字の配置の点で、レンダリング エンジンの限界や制限を伴います。 たとえば、次の文字列は位置揃えによって異なって表示される場合があります。

| | 英語の文字列 (LTR) | ヘブライ語の文字列 (RTL) |
| -------------- | ------------------- | ------------------- |
| **左揃え** | Hello, World! | בוקר טוב! |
| **右揃え** | !Hello, World | !בוקר טוב |

ミュージック アプリでアーティスト情報が適切に表示されるようにするために、開発チームではテキスト レイアウトのプロパティを位置揃えから切り離しました。 つまり、アーティスト情報は多くの場合に右揃えで表示されますが、文字列レイアウトの調整は、カスタマイズされたバックグラウンド処理に基づいて設定されます。 バックグラウンド処理では、文字列の内容に応じた最適な方向レイアウト設定が判断されます。

![ミュージック アプリのアーティスト ページ](images/56292_BIDI_18_app_layout_callouts_resized.png)

たとえば、カスタムの文字列レイアウト処理を適用しない場合、アーティスト名 "The Contoso Band." は  ".The Contoso Band" と表示されます。

### <a name="specialized-string-direction-preprocessing"></a>文字列の方向の特殊な前処理

メディア メタデータの有無についてアプリがサーバーと通信する場合、アプリはユーザーへの表示前に各文字列を前処理します。 また、この前処理の際に、アプリはテキストの方向を統一するための変換を行います。 これを行うために、アプリは文字列の末尾にニュートラル文字がないかどうかを確認します。 また、文字列のテキストの方向が Windows の言語設定で設定されたアプリの方向と逆である場合は、Unicode 方向マーカーを追加 (場合によっては、先頭に追加) します。 この変換関数は、次のように表示されます。

```csharp
string NormalizeTextDirection(string data) 
{
    if (data.Length > 0) {
        var lastCharacterDirection = DetectCharacterDirection(data[data.Length - 1]);

        // If the last character has strong directionality (direction is not null), then the text direction for the string is already consistent.
        if (!lastCharacterDirection) {
            // If the last character has no directionality (neutral character, direction is null), then we may need to add a direction marker to
            // ensure that the last character doesn't inherit directionality from the outside context.
            var appTextDirection = GetAppTextDirection(); // checks the <html> element's "dir" attribute.
            var dataTextDirection = DetectStringDirection(data); // Run through the string until a non-neutral character is encountered,
                                                                 // which determines the text direction.

            if (appTextDirection != dataTextDirection) {
                // Add a direction marker only if the data text runs opposite to the directionality of the app as a whole,
                // which would cause the neutral characters at the ends to flip.
                var directionMarkerCharacter =
                    dataTextDirection == TextDirections.RightToLeft ?
                        UnicodeDirectionMarkers.RightToLeftDirectionMarker : // "\u200F"
                        UnicodeDirectionMarkers.LeftToRightDirectionMarker; // "\u200E"

                data += directionMarkerCharacter;

                // Prepend the direction marker if the data text begins with a neutral character.
                var firstCharacterDirection = DetectCharacterDirection(data[0]);
                if (!firstCharacterDirection) {
                    data = directionMarkerCharacter + data;
                }
            }
        }
    }

    return data;
}
```

追加される Unicode 文字は幅が 0 であるため、文字列の間隔に影響を与えることはありません。 文字列の方向の検出は、ニュートラル以外の文字が検出されるまで文字列全体を対象に続ける必要があるため、このコードによってパフォーマンスの低下を招く可能性があります。 また、ニュートラル文字であるかどうかの確認対象となるそれぞれの文字については、最初に複数の Unicode の範囲との照合も行われるため、これは単純なチェックではありません。

## <a name="case-study-2-a-bidi-mail-app"></a>ケース スタディ #2: BiDi 対応のメール アプリ

### <a name="overview"></a>概要

UI レイアウト要件の点では、メール クライアントは設計が非常に単純です。 Windows のメール アプリは既定でミラー化されています。 テキスト処理の観点から、メール アプリには、混在テキストのシナリオに対応するために、しっかりとしたテキスト表示機能とテキスト作成機能が必要です。

### <a name="establishing-ui-directionality"></a>UI の方向の設定

メール アプリの UI レイアウトはミラー化されています。 3 つのウィンドウが配置し直され、フォルダー ウィンドウは画面の右端に配置され、メール項目一覧ウィンドウがその左に続き、さらにその左にメール作成ウィンドウが配置されます。

![ミラー化されたメール アプリ](images/56293_BIDI_19_icon_realignment_cropped_resized.png)

その他の項目も、UI のフロー全体とタッチの最適化に適合するように配置し直されます。 その他の項目には、アプリ バーや作成、返信、削除の各アイコンがあります。

![ミラー化されたメール アプリ (アプリ バー付き)](images/56294_BIDI_20_email_orientation_email_resized.png)

### <a name="text-handling"></a>テキストの処理

#### <a name="ui"></a>UI

UI 全体のテキスト配置は、通常は右揃えです。 これには、フォルダー ウィンドウや項目ウィンドウが含まれます。 項目ウィンドウはテキスト 2 行に制限されます (アドレスとタイトル)。 このことはテキスト ブロックを導入しないで右から左の配置を維持するうえで重要です。テキスト ブロックがあると、コンテンツの方向が UI の方向フローと逆であるときに読み取りが困難になります。

#### <a name="text-editing"></a>テキストの編集

テキストを編集するには、右から左と左から右の両方の形式で記述できる機能が必要です。 さらに、方向に関する情報を保存できるリッチ テキストなどの形式を使って構成レイアウトを保持できる必要があります。

![メール アプリ (左から右)](images/56294_BIDI_21_email_orientation_LtR_resized.png)

![メール アプリ (右から左)](images/56294_BIDI_22_email_orientation_RtL_resized.png)
