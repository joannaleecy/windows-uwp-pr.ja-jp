---
author: mijacobs
Description: "ポインター アニメーションを使って、ユーザーが項目をタップまたはクリックしたときに視覚的なフィードバックをユーザーに提供します。"
title: "UWP アプリでのポインター クリックのアニメーション"
ms.assetid: EEB10A2C-629A-4705-8468-4D019D74DDFF
label: Motion--Pointer animations
template: detail.hbs
ms.sourcegitcommit: a4e9a90edd2aae9d2fd5d7bead948422d43dad59
ms.openlocfilehash: 24175bb7c822ceb53af5e1ec70bf83f701fd1cce

---

# ポインター クリックのアニメーション

ポインター アニメーションを使って、ユーザーが項目をタップまたはクリックしたときに視覚的なフィードバックをユーザーに提供します。 ポインター ダウン アニメーション (押された項目を若干縮小して傾ける) は、項目が最初にタップされたときに再生されます。 ポインター アップ アニメーション (項目を元の位置に復元する) は、ユーザーがポインターから指を離したときに再生されます。




**重要な API**

-   [**PointerUpThemeAnimation クラス**](https://msdn.microsoft.com/library/windows/apps/hh969168)
-   [**PointerDownThemeAnimation クラス**](https://msdn.microsoft.com/library/windows/apps/hh969164)



## 推奨と非推奨


-   ポインター アップ アニメーションを使うときには、ユーザーが指を離した直後にアニメーションを開始するようにします。 これにより、タップによってトリガーされたアクション (新しいページへの移動など) の応答が遅れたとしても、ユーザーの操作が認識されたというフィードバックを即座に返すことができます。

## 関連記事

**開発者向け (XAML)**
* [アニメーションの概要](https://msdn.microsoft.com/library/windows/apps/mt187350)
* [ポインター クリックのアニメーション化](https://msdn.microsoft.com/library/windows/apps/xaml/jj649432)
* [クイック スタート: ライブラリのアニメーションを使った UI のアニメーション化](https://msdn.microsoft.com/library/windows/apps/xaml/hh452703)
* [**PointerUpThemeAnimation クラス**](https://msdn.microsoft.com/library/windows/apps/hh969168)
* [**PointerDownThemeAnimation クラス**](https://msdn.microsoft.com/library/windows/apps/hh969164)

 

 







<!--HONumber=Jun16_HO4-->


