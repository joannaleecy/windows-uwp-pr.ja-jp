---
Description: Content transition animations let you change the content of an area of the screen while keeping the container or background constant. New content fades in. If there is existing content to be replaced, that content fades out.
title: コンテンツ切り替えアニメーションのガイドライン
ms.assetid: 0188FDB4-E183-466f-8A03-EE3FF5C474B1
template: detail.hbs
ms.date: 05/19/2017
ms.topic: article
keywords: Windows 10, UWP
pm-contact: stmoy
design-contact: conrwi
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: 096cc0aaa9b0580eb6b45328a3243ba75d82f202
ms.sourcegitcommit: 8921a9cc0dd3e5665345ae8eca7ab7aeb83ccc6f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/10/2018
ms.locfileid: "8872220"
---
# <a name="content-transition-animations"></a>コンテンツ切り替えアニメーション



コンテンツ切り替えアニメーションを使うと、コンテナーや背景はそのままに、画面のある領域のコンテンツを変更できます。 新しいコンテンツはフェード インします。 既にあるコンテンツを差し替える場合、そのコンテンツはフェード アウトします。

> **重要な API**: [**ContentThemeTransition クラス (XAML)**](https://msdn.microsoft.com/library/windows/apps/br243104)

## <a name="dos-and-donts"></a>推奨と非推奨


-   開始アニメーションは、空のコンテナーに一連の新しい項目を流し込むときに使います。 たとえば、アプリの初期読み込みの直後は、アプリのコンテンツの一部が表示に間に合わない場合があります。 このような場合、コンテンツを表示する準備が整った段階で、コンテンツ切り替えアニメーションを使い、遅れてコンテンツが表示されるようにします。
-   あるコンテンツの組み合わせを、画面内の同じコンテナー内に既に存在する別のコンテンツの組み合わせに置き換えるときに、コンテンツ切り替えを使います。
-   新しいコンテンツを画面に表示するときには、一般的なページのフロー (読む方向) とは逆にコンテンツを上に (下から上に) スライドさせます。
-   新しいコンテンツは論理的な流れで配置します。たとえば、最も重要なコンテンツを最後にします。
-   更新対象のコンテンツを含んだコンテナーが複数存在する場合、切り替え効果アニメーションは、間を置かずにすべて同時にトリガーします。
-   コンテンツ切り替えアニメーションは、ページの全体が変化する場合には使わないでください。 この場合には、ページ切り替えアニメーションを使います。
-   コンテンツの更新のみであれば、コンテンツ切り替えアニメーションは使わないでください。 コンテンツ切り替えアニメーションは、動きを表現するために使います。 更新には、フェード アニメーションを使ってください。



## <a name="related-articles"></a>関連記事

**開発者向け (XAML)**
* [アニメーションの概要](https://msdn.microsoft.com/library/windows/apps/mt187350)
* [コンテンツ切り替えのアニメーション化](https://msdn.microsoft.com/library/windows/apps/xaml/jj649426)
* [クイック スタート: ライブラリのアニメーションを使った UI のアニメーション化](https://msdn.microsoft.com/library/windows/apps/xaml/hh452703)
* [**ContentThemeTransition クラス**](https://msdn.microsoft.com/library/windows/apps/br243104)

 

 




