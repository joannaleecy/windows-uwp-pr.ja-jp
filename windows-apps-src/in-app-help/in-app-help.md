---
author: QuinnRadich
Description: "アプリ内で事後対応的に表示される効果的なヘルプを設計します。"
title: "アプリ内ヘルプの設計のためのガイドライン。"
label: In-app help
template: detail.hbs
ms.author: quradic
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.assetid: 6208b71b-37a7-40f5-91b0-19b665e7458a
ms.openlocfilehash: 659a2871e540398d34b93c288d34fb80699c36c9
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
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

-   **簡潔にする:** 大規模なライブラリのヘルプ トピックは扱いにくく、アプリ内ヘルプに適しません。
-   **一貫性を持たせる:** アプリ内のどこからでも、同じ方法でヘルプ ページを表示できるようにします。 ユーザーがヘルプを探し回る必要がないようにします。
-   **ユーザーはざっと読むが、熟読はしない:** ユーザーが求めている情報がページ上にある場合でも、他の情報と紛れてしまう場合があります。ユーザーが必要な情報を、容易に見つけられるようにします。


#### <a name="popups"></a>ポップアップ

ポップアップを使うと、高度なコンテキスト ヘルプを実現でき、ユーザーが実行している具体的なタスクに直接役立つ手順やアドバイスを表示できます。

-   **1 つの問題に集中する:** ポップアップではヘルプ ページよりも、スペースがさらに制限されます。 ヘルプ ポップアップを効果的にするには、1 つの具体的なタスクのみに関して説明するようにします。
-   **可視性が重要:** ヘルプ ポップアップは 1 つの場所からのみ表示できるため、妨げになることなく、ユーザーに明確に見えるようにします。 If the user misses it, they might move away from the popup in search of a help page.
-   **多くのリソースを使用しない:** ヘルプが遅延を生じたり、読み込みに時間がかからないようにします。 Using videos or audio files or high resolution images in popups is more likely to frustrate the user than it is to help them.

#### <a name="descriptions"></a>説明

Sometimes, it can be useful to provide more information about a feature when a user inspects it. 説明は、説明 UI に似ていますが、説明 UI はユーザーが知らない機能についてユーザーに教えようとするものであり、詳細な説明はユーザーが既に関心を持っているアプリの機能についてのユーザーの理解を深めるためのものであることが、主な相違点です。

-   **ユーザーに基本事項を教えない:** ユーザーは、説明されている項目の基本的な使い方についてはわかっていることを前提にします。 Clarifying or offering further information is useful. Telling them what they already know is not.
-   **興味を引く操作について説明する:** 説明の最適な使用方法の 1 つは、ユーザーが既に知っている機能の操作の方法を説明することです。 This helps users learn more about things they already like to use.
-   **ユーザーを妨げない:** 説明 UI の場合と同様に、説明はユーザーのアプリの使用を妨げないようにします。

## <a name="related-articles"></a>関連記事

* [Guidelines for app help](guidelines-for-app-help.md)
