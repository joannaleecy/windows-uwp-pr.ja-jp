---
Description: ポップアップ アニメーションを使って、ポップアップ UI やカスタム ポップアップ UI 要素の表示と非表示を切り替えます。 ポップアップ要素とは、アプリのコンテンツの上に表示されるコンテナーのことで、ユーザーがポップアップ要素の外部をタップまたはクリックすると消えます。
title: UWP アプリでのポップアップ UI のアニメーション
ms.assetid: 4E9025CE-FC90-4d4c-9DE6-EC6B6F2AD9DF
label: Motion--Pop-up animations
template: detail.hbs
ms.date: 05/19/2017
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: d79c369e14236b827bdc18aba6c74349528728b3
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57635177"
---
# <a name="pop-up-ui-animations"></a>ポップアップ UI のアニメーション



ポップアップ アニメーションを使って、ポップアップ UI やカスタム ポップアップ UI 要素の表示と非表示を切り替えます。 ポップアップ要素とは、アプリのコンテンツの上に表示されるコンテナーのことで、ユーザーがポップアップ要素の外部をタップまたはクリックすると消えます。

> **重要な Api**:[**PopInThemeAnimation クラス**](https://msdn.microsoft.com/library/windows/apps/br210383)、 [ **PopupThemeTransition クラス**](https://msdn.microsoft.com/library/windows/apps/hh969172)


## <a name="dos-and-donts"></a>推奨と非推奨


-   ポップアップ アニメーションは、アプリ ページ自体には含まれないカスタム ポップアップ UI 要素を表示したり非表示にしたりするために使います。 Windows で用意されているコモン コントロールには、既にこのアニメーションが組み込まれています。
-   ヒントやダイアログにポップアップ アニメーションを使わないでください。
-   アプリのメイン コンテンツ内の UI の表示と非表示を切り替えるためにポップアップ アニメーションを使わないでください。ポップアップ アニメーションは、メイン アプリ コンテンツの上に表示されるポップアップ コンテナーの表示と非表示を切り替えるときにのみ使います。

## <a name="related-articles"></a>関連記事

* [アニメーションの概要](https://msdn.microsoft.com/library/windows/apps/mt187350)
* [ポップアップの UI をアニメーション化](https://msdn.microsoft.com/library/windows/apps/xaml/jj649433)
* [クイック スタート:Library のアニメーションを使用して、UI をアニメーション化](https://msdn.microsoft.com/library/windows/apps/xaml/hh452703)
* [**PopInThemeAnimation クラス**](https://msdn.microsoft.com/library/windows/apps/br210383)
* [**PopOutThemeAnimation クラス**](https://msdn.microsoft.com/library/windows/apps/br210391)
* [**PopupThemeTransition クラス**](https://msdn.microsoft.com/library/windows/apps/hh969172)

 

 




