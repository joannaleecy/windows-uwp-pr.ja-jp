---
author: mijacobs
Description: Use fade animations to bring items into a view or to take items out of a view. The two common fade animations are fade-in and fade-out.
title: UWP アプリでのフェード アニメーション
ms.assetid: 975E5EE3-EFBE-4159-8D10-3C94143DD07F
label: Motion--fades
template: detail.hbs
ms.author: mijacobs
ms.date: 05/19/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: d2a9745e35f19066b094b2be187620858166dbd5
ms.sourcegitcommit: 144f5f127fc4fbd852f2f6780ef26054192d68fc
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/05/2018
ms.locfileid: "5983628"
---
# <a name="fade-animations"></a>フェード アニメーション



フェード アニメーションは、項目を画面に表示したり、項目を画面から非表示にするときに使います。 一般的なフェード アニメーションは、フェード インとフェード アウトの 2 つです。

> **重要な API**: [**FadeInThemeAnimation クラス**](https://msdn.microsoft.com/library/windows/apps/br210298)、[**FadeOutThemeAnimation クラス**](https://msdn.microsoft.com/library/windows/apps/br210302)


## <a name="dos-and-donts"></a>推奨と非推奨


-   アプリで互いに関係のない要素や、テキストの多い要素を切り替えるときには、フェード アウトとフェード インを使います。 そうすることで、差し替え前のオブジェクトが完全に消えてから差し替え後のオブジェクトを表示させることができます。
-   差し替える 2 つの要素のサイズが一定であり、ユーザーに同じ項目を見ているような印象を与えたいときには、差し替え後の要素を差し替え前の要素の上にフェード インさせます。 フェード インが完了したら、差し替え前の項目は消すことができます。 これは、差し替え後の項目が差し替え前の項目を完全に覆い隠せる場合にのみ可能な方法です。
-   リストの項目を追加または削除する目的でフェード アニメーションを使うのは避けてください。 そのような場合には、専用に作成したリスト アニメーションを使います。
-   フェード アニメーションは、ページの全コンテンツを変化させるときには使わないでください。 そのような場合には、専用に作成したページ切り替えアニメーションを使います。
-   フェード アウトは要素を削除するための繊細な方法です。
## <a name="related-articles"></a>関連記事

* [アニメーションの概要](https://msdn.microsoft.com/library/windows/apps/mt187350)
* [フェードのアニメーション化](https://msdn.microsoft.com/library/windows/apps/xaml/jj649429)
* [クイック スタート: ライブラリのアニメーションを使った UI のアニメーション化](https://msdn.microsoft.com/library/windows/apps/xaml/hh452703)
* [**FadeInThemeAnimation クラス**](https://msdn.microsoft.com/library/windows/apps/br210298)
* [**FadeOutThemeAnimation クラス**](https://msdn.microsoft.com/library/windows/apps/br210302)

 

 




