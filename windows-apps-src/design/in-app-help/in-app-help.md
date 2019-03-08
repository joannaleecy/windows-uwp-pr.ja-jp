---
Description: Design effective help to be displayed reactively inside your app.
title: アプリ内ヘルプの設計のためのガイドライン。
label: In-app help
template: detail.hbs
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp
ms.assetid: 6208b71b-37a7-40f5-91b0-19b665e7458a
ms.localizationpriority: medium
ms.openlocfilehash: 4783d28e4da6c06df0d0676f4a7d28ef3995481a
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57610057"
---
# <a name="in-app-help-pages"></a>アプリ内ヘルプのページ

多くの場合、ヘルプはアプリケーション内でユーザーがヘルプの表示を選択したときに表示されることが望ましい方法です。

## <a name="when-to-use-in-app-help-pages"></a>アプリ内ヘルプのページを使用する状況

アプリ内ヘルプは、ユーザーにヘルプを表示する既定の方法として使用します。 これはすべてのヘルプで使用し、シンプルで単純にして、ユーザーに未知のコンテンツを表示しないようにします。 使用方法、アドバイス、ヒントやコツなどはすべて、アプリ内ヘルプに適しています。

複雑な使用方法やチュートリアルはすばやい参照には適しておらず、また大量の領域を占有します。 そのため、それらはアプリ自体には組み込まず、外部で提供するようにします。

Users should not have to seek out help for basic instructions or to discover new features. ユーザーのためになる情報を提供する場合には、説明 UI を使用します。

## <a name="types-of-in-app-help"></a>アプリ内ヘルプの種類

アプリ内ヘルプにはいくつかの形式がありますが、それらはすべて同じ設計と操作性の原則に従っています。

#### <a name="help-pages"></a>ヘルプ ページ

アプリ内に別のヘルプ ページを作成することは、役に立つ使用方法を表示するための、すばやく手軽な方法です。

-   **簡潔になります。** ヘルプ トピックの大規模なライブラリとは、扱いにくいとアプリ内のヘルプの unsuited です。
-   **一貫性のあるになります。** ユーザーに到達できること、ヘルプ ページ、アプリの任意の部分から同じ方法を確認します。 ユーザーがヘルプを探し回る必要がないようにします。
-   **ユーザーをスキャンする、読み取ることができません。** 他のヘルプ トピックと同じページには、ユーザーが探してヘルプ可能性があります、ために注目する必要がある、1 つに簡単に通知できることを確認します。


#### <a name="popups"></a>ポップアップ

ポップアップを使うと、高度なコンテキスト ヘルプを実現でき、ユーザーが実行している具体的なタスクに直接役立つ手順やアドバイスを表示できます。

-   **1 つの問題に集中します。** 領域は、ヘルプ ページよりもポップアップより制限されます。 ヘルプ ポップアップを効果的にするには、1 つの具体的なタスクのみに関して説明するようにします。
-   **可視性が重要です。** ヘルプ ポップアップは、1 つの場所からのみ参照できます、ため obstructive でなくて、ユーザーに明確に表示される、いることを確認します。 If the user misses it, they might move away from the popup in search of a help page.
-   **多くのリソースを使用しないでください。** ヘルプ、ラグべきではないまたはがの読み込みが遅い。 Using videos or audio files or high resolution images in popups is more likely to frustrate the user than it is to help them.

#### <a name="descriptions"></a>説明

Sometimes, it can be useful to provide more information about a feature when a user inspects it. 説明は、説明 UI に似ていますが、説明 UI はユーザーが知らない機能についてユーザーに教えようとするものであり、詳細な説明はユーザーが既に関心を持っているアプリの機能についてのユーザーの理解を深めるためのものであることが、主な相違点です。

-   **基本は得られません。** ユーザーが記述されている項目を使用する方法の基礎を既に知っていることを想定しています。 Clarifying or offering further information is useful. Telling them what they already know is not.
-   **興味深い相互作用をについて説明します。** について既に理解している機能のやり取りの方法でユーザーを教育する説明については最適な使用方法の 1 つです。 This helps users learn more about things they already like to use.
-   **邪魔を維持します。** UI の説明のように説明が、アプリのユーザーの本を邪魔しないようにする必要があります。

## <a name="related-articles"></a>関連記事

* [アプリのヘルプに関するガイドライン](guidelines-for-app-help.md)
