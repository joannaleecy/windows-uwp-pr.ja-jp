---
Description: エッジに基づく UI アニメーションでは、画面の端を起点とする UI の表示と非表示を切り替えられます。
title: UWP アプリでのエッジに基づく UI アニメーション
ms.assetid: 5A8F73B1-F4F6-424b-9EDF-A9766C5DEAE8
label: Motion--edge-based UI
template: detail.hbs
ms.date: 05/19/2017
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: e07ac565fe2e223b2fb33573ad083edfdfbc888a
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57610207"
---
# <a name="edge-based-ui-animations"></a>エッジに基づく UI アニメーション





エッジに基づく UI アニメーションでは、画面の端を起点とする UI の表示と非表示を切り替えられます。 この表示と非表示のアクションは、ユーザーが開始することも、アプリから開始することもできます。 UI は、アプリの手前に表示するか、メイン アプリ サーフェスの一部として表示することができます。 UI をアプリ サーフェスの一部として表示する場合は、UI を表示できるようにアプリの残りの部分のサイズを調整する必要があります。

> **重要な API**:[**EdgeUIThemeTransition クラス**](https://msdn.microsoft.com/library/windows/apps/hh702324)


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
* [Edge ベースの UI をアニメーション化](https://msdn.microsoft.com/library/windows/apps/xaml/jj649428)
* [クイック スタート:Library のアニメーションを使用して、UI をアニメーション化](https://msdn.microsoft.com/library/windows/apps/xaml/hh452703)
* [**EdgeUIThemeTransition クラス**](https://msdn.microsoft.com/library/windows/apps/hh702324)
* [**PaneThemeTransition クラス**](https://msdn.microsoft.com/library/windows/apps/hh969160)
* [フェード アニメーション化](https://msdn.microsoft.com/library/windows/apps/xaml/jj649429)
* [位置を変更をアニメーション化](https://msdn.microsoft.com/library/windows/apps/xaml/jj649434)

 

 




