---
author: Mtoepke
title: "Xbox One 上の UWP アプリとゲームのシステム リソース"
description: "Xbox 上の UWP のシステム リソース"
ms.author: mtoepke
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.assetid: 12e87019-4315-424e-b73c-426d565deef9
ms.openlocfilehash: 76c9d372cdfd98ef86f123862c35d238b24fe2ed
ms.sourcegitcommit: de6bc8acec2cd5ebc36bb21b2ce1a9980c3e78b2
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/17/2017
---
# <a name="system-resources-for-uwp-apps-and-games-on-xbox-one"></a>Xbox One 上の UWP アプリとゲームのシステム リソース

Xbox One で実行されている UWP アプリとゲームは、システムやその他のアプリとリソースを共有します。 そのため、UWP アプリやゲームは次のリソースにアクセスできます。

* フォアグラウンドで実行されているアプリに利用可能なメモリは最大 1 GB です。
    * バックグラウンドで実行されているアプリに利用可能なメモリは最大 128 MB です。
    * これらのメモリ要件を超えているアプリでは、メモリの割り当てエラーが発生します。 メモリ使用量の監視について詳しくは、[MemoryManager クラス](https://msdn.microsoft.com/library/windows/apps/windows.system.memorymanager.aspx)のリファレンスをご覧ください。
    
    > [!NOTE]
    > アプリケーションやゲームを Visual Studio デバッガーから実行している場合、これらのメモリ制限は適用されません。 この制限は、デバッグ モードで実行されていないときにのみ適用されます。

* システムで実行されているアプリとゲームの数に応じて、2 ～ 4 個の CPU コアを共有します。

* システムで実行されているアプリとゲームの数に応じて、GPU の 45% を共有します。

* Xbox One の UWP は、DirectX 11 の機能レベル 10 をサポートしています。 現時点では DirectX 12 はサポートされていません。

* アプリを Xbox 向けに開発またはストアに提出するには、必ず x64 アーキテクチャをターゲットにする必要があります。  

**アプリケーション開発**の場合、標準的な PC と比較して、利用可能なリソースが制限される可能性があることに留意する必要があります。

**ゲーム開発**の場合、Xbox One は、他のゲーム コンソールと同様に、その潜在的な機能を最大限に利用するために特定のハードウェア ベースの開発キットを必要とする、特殊なハードウェアであることに留意する必要があります。 Xbox One のハードウェアの機能を最大限に利用する必要があるゲームを開発している場合、[ID@Xbox](http://www.xbox.com/Developers/id) プログラムに登録することで、DirectX 12 のサポートを含む Xbox One 開発キットにアクセスできます。


Xbox One での UWP アプリのシステム リソースについてもう少し詳しく知りたい場合は、次のビデオの最初の部分をチェックしてください。
</br>
</br>
<iframe src="https://mva.microsoft.com/en-US/training-courses-embed/developing-xbox-one-applications-16860/Video-What-s-Unique--vk0fOPf9C_2006218965" width="636" height="480" allowFullScreen frameBorder="0"></iframe>

## <a name="see-also"></a>関連項目
- [Xbox One の UWP](index.md)
