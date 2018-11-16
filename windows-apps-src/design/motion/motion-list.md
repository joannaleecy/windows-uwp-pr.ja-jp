---
author: mijacobs
Description: List animations let you insert or remove single or multiple items from a collection, such as a photo album or a list of search results.
title: UWP アプリでの追加と削除のアニメーション
ms.assetid: A85006AE-4992-457a-B514-500B8BEF5DC8
label: Motion--add and delete animations
template: detail.hbs
ms.author: mijacobs
ms.date: 05/19/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 9f1c2fa6a30047cb447b597213692085f4656bd2
ms.sourcegitcommit: e2fca6c79f31e521ba76f7ecf343cf8f278e6a15
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/15/2018
ms.locfileid: "6986976"
---
# <a name="add-and-delete-animations"></a>追加と削除のアニメーション



リスト アニメーションを使うと、写真のアルバムや検索結果の一覧などのコレクションに対して任意の数の項目を挿入または削除できます。

> **重要な API**: [**AddDeleteThemeTransition クラス**](https://msdn.microsoft.com/library/windows/apps/br243048)


## <a name="dos-and-donts"></a>推奨と非推奨


-   リスト アニメーションは、既にある一連の項目に新しい項目を 1 つ追加するときに使います。 たとえば、新しい電子メールを受け取ったときや、既にあるセットに新しい写真をインポートするときに使います。
-   リスト アニメーションは、一連の項目に対して複数の項目を一度に追加するときに使います。 たとえば、一連の新しい写真を既にあるコレクションにインポートするときに使います。 複数項目の追加と削除は、個々のオブジェクトの処理に間が生じることなく同時に実行されます。
-   追加と削除のリスト アニメーションは、ペアで使います。 一方のアニメーションを使った場合は、逆の操作として対応するもう一方のアニメーションを使うようにしてください。
-   リスト アニメーションは、要素または要素のグループを一度に追加または削除できる項目リストに使います。
-   コンテナーを表示したり非表示にしたりする目的でリスト アニメーションを使うのは避けてください。 リスト アニメーションは、既に表示されているコレクションまたはセットのメンバーに対して使います。 アプリ サーフェス上に一時的なコンテナーを表示したり非表示にしたりするには、ポップアップ アニメーションを使います。 アプリ サーフェスの一部となっているコンテナーを表示したり置き換えたりするには、コンテンツ切り替えアニメーションを使います。
-   項目のセット全体に対してリスト アニメーションを使うのは避けてください。 コンテナー内のコレクション全体を追加したり削除したりするには、コンテンツ切り替えアニメーションを使います。



## <a name="related-articles"></a>関連記事

* [アニメーションの概要](https://msdn.microsoft.com/library/windows/apps/mt187350)
* [リストの追加と削除のアニメーション化](https://msdn.microsoft.com/library/windows/apps/xaml/jj649430)
* [クイック スタート: ライブラリのアニメーションを使った UI のアニメーション化](https://msdn.microsoft.com/library/windows/apps/xaml/hh452703)
* [**AddDeleteThemeTransition クラス**](https://msdn.microsoft.com/library/windows/apps/br243048)

 

 




