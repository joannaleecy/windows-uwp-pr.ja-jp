---
author: mijacobs
Description: Edge-based animations show or hide UI that originates from the edge of the screen.
title: UWP アプリでのエッジに基づく UI アニメーション
ms.assetid: 5A8F73B1-F4F6-424b-9EDF-A9766C5DEAE8
label: Motion--edge-based UI
template: detail.hbs
ms.author: mijacobs
ms.date: 05/19/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 0a1cb6cee78d7c7d1e59e64dd151539ce6b3e5d7
ms.sourcegitcommit: ca96031debe1e76d4501621a7680079244ef1c60
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/30/2018
ms.locfileid: "5825056"
---
# <a name="edge-based-ui-animations"></a>エッジに基づく UI アニメーション





エッジに基づく UI アニメーションでは、画面の端を起点とする UI の表示と非表示を切り替えられます。 この表示と非表示のアクションは、ユーザーが開始することも、アプリから開始することもできます。 UI は、アプリの手前に表示するか、メイン アプリ サーフェスの一部として表示することができます。 UI をアプリ サーフェスの一部として表示する場合は、UI を表示できるようにアプリの残りの部分のサイズを調整する必要があります。

> **重要な API**: [**EdgeUIThemeTransition クラス**](https://msdn.microsoft.com/library/windows/apps/hh702324)


## <a name="dos-and-donts"></a>推奨と非推奨


-   画面領域をあまり占有しないカスタム メッセージ バーやエラー バーを表示または非表示にするには、エッジ (端) UI アニメーションを使います。
-   作業ウィンドウやカスタム ソフト キーボードなど、画面内側にスライドして領域を大きく確保する UI を表示するには、パネル アニメーションを使います。
-   UI を開くには、それが関連付けられている端から画面内側にスライドします。
-   UI を閉じるには、画面内側から、開いたときと同じ端に向かってスライドします。
-   UI のスライド操作に応じてアプリのコンテンツ サイズを変更する必要がある場合は、フェード アニメーションを使ってサイズを変更します。
    -   UI を画面内側に向かってスライドする場合は、エッジ (端) UI アニメーションまたはパネル アニメーションの後にフェード アニメーションを使います。
    -   UI を画面外側に向かってスライドする場合は、エッジ (端) UI アニメーションまたはパネル アニメーションと同時にフェード アニメーションを使います。
-   通知には、このアニメーションを適用しないでください。 エッジに基づく UI に通知を格納することはお勧めしません。
-   画面のエッジ (端) にない UI コンテナーやコントロールには、エッジ (端) UI アニメーションとパネル アニメーションを適用しないでください。 このアニメーションは、画面のエッジ (端) にある UI の開閉とサイズ変更にのみ使います。 他のタイプの UI を移動するには、位置変更アニメーションを使います。

    ![エッジ (端) UI アニメーションまたはパネル アニメーションを使うケースと位置変更を使うケースの図](images/edgevsreposition.png)

## <a name="related-articles"></a>関連記事


**開発者向け**
* [アニメーションの概要](https://msdn.microsoft.com/library/windows/apps/mt187350)
* [エッジに基づく UI のアニメーション化](https://msdn.microsoft.com/library/windows/apps/xaml/jj649428)
* [クイック スタート: ライブラリのアニメーションを使った UI のアニメーション化](https://msdn.microsoft.com/library/windows/apps/xaml/hh452703)
* [**EdgeUIThemeTransition クラス**](https://msdn.microsoft.com/library/windows/apps/hh702324)
* [**PaneThemeTransition クラス**](https://msdn.microsoft.com/library/windows/apps/hh969160)
* [フェードのアニメーション化](https://msdn.microsoft.com/library/windows/apps/xaml/jj649429)
* [位置変更のアニメーション化](https://msdn.microsoft.com/library/windows/apps/xaml/jj649434)

 

 




