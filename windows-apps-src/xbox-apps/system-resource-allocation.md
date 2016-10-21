---
author: Mtoepke
title: "Xbox One 上の UWP アプリとゲームのシステム リソース"
description: "Xbox 上の UWP のシステム リソース"
translationtype: Human Translation
ms.sourcegitcommit: 9187e39e1be8b98ad8315487633dfebd068491e6
ms.openlocfilehash: c3ca70936e30ce67b19971e5ccbb01fa89253f35

---

# Xbox One 上の UWP アプリとゲームのシステム リソース

Xbox One で実行されている UWP アプリとゲームは、システムやその他のアプリとリソースを共有します。 そのため、UWP アプリやゲームは次のリソースにアクセスできます。

* フォアグラウンドで実行されているアプリに利用可能なメモリは最大 1 GB です。
    * バックグラウンドで実行されているアプリに利用可能なメモリは最大 128 MB です。
    * これらのメモリ要件を超えているアプリでは、メモリの割り当てエラーが発生します。 メモリ使用量の監視について詳しくは、[MemoryManager クラス](https://msdn.microsoft.com/library/windows/apps/windows.system.memorymanager.aspx)のリファレンスをご覧ください。
    
    > [!NOTE]
    > アプリケーションやゲームを Visual Studio デバッガーから実行している場合、これらのメモリ制限は適用されません。 この制限は、デバッグ モードで実行されていないときにのみ適用されます。

* システムで実行されているアプリとゲームの数に応じて、2 ～ 4 個の CPU コアを共有します。

* システムで実行されているアプリとゲームの数に応じて、GPU の 45% を共有します。

* Xbox One の UWP は、DirectX 11 の機能レベル 10 をサポートしています。 現時点では DirectX 12 はサポートされていません。 

**アプリケーション開発**の場合、標準的な PC と比較して、利用可能なリソースが制限される可能性があることに留意する必要があります。

**ゲーム開発**の場合、Xbox One は、他のゲーム コンソールと同様に、その潜在的な機能を最大限に利用するために特定のハードウェア ベースの開発キットを必要とする、特殊なハードウェアであることに留意する必要があります。 Xbox One のハードウェアの機能を最大限に利用する必要があるゲームを開発している場合、[ID@XBOX](http://www.xbox.com/Developers/id) プログラムに登録することで、DirectX 12 のサポートを含む Xbox One 開発キットにアクセスできます。

## 関連項目
- [Xbox One の UWP](index.md)



<!--HONumber=Aug16_HO3-->


