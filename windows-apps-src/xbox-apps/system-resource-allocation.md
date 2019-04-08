---
title: Xbox One 上の UWP アプリとゲームのシステム リソース
description: Xbox 上の UWP のシステム リソース
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp
ms.assetid: 12e87019-4315-424e-b73c-426d565deef9
ms.localizationpriority: medium
ms.openlocfilehash: 0869f5cfc2499a00577f0196cd9f9f84987c0321
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57647327"
---
# <a name="system-resources-for-uwp-apps-and-games-on-xbox-one"></a>Xbox One 上の UWP アプリとゲームのシステム リソース

Xbox One で実行されている UWP アプリは、システムやその他のアプリとリソースを共有します。 Xbox One アプリの UWP で利用可能なリソースは、アプリとして提出するか、Xbox Live クリエーターズ プログラム ゲームとして提出するかによって異なります。

* フォアグラウンドで実行されているときに利用可能な最大メモリ
    * アプリ:1 GB
    * ゲーム:5 GB

バックグラウンドで実行されているアプリに利用可能なメモリは最大 128 MB です。 バックグラウンド モードは、バックグラウンド ミュージック プレーヤーなどの同時アプリケーションにのみ適用されます。  ゲームはバックグラウンドで一時停止および終了されます。

これらの制限を超えると、メモリ割り当てエラーが発生します。 メモリ使用量の監視について詳しくは、[MemoryManager クラス](https://msdn.microsoft.com/library/windows/apps/windows.system.memorymanager.aspx)のリファレンスをご覧ください。
    
    > [!NOTE]
    > When running your app or game from the Visual Studio debugger, these memory constraints do not apply. This limit is only applicable when not running in debugging mode.

* CPU
    * アプリ: システムで実行されているアプリとゲームの数に応じて、2 ～ 4 個の CPU コアを共有します。
    * ゲーム:排他的と 2 つの 4 CPU コアを共有します。

* GPU
    * アプリ: システムで実行されているアプリとゲームの数に応じて、GPU の 45% を共有します。
    * ゲーム: 利用可能な GPU サイクルへのフル アクセス。

* DirectX のサポート
    * アプリ:DirectX 11 の機能レベル 10 です。
    * ゲーム:DirectX 12、DirectX 11 の機能レベル 10.

* アプリおよびゲームを Xbox 向けに開発または Microsoft Store に提出するには、必ず x64 アーキテクチャをターゲットにする必要があります。  

**アプリケーション開発**の場合、利用可能なリソースは標準 PC と比べて限られることがあり、システムで実行されているアプリやゲームの数によって異なる場合があります。

**ゲーム開発**の場合、Xbox One は、他のゲーム コンソールと同様に、その潜在的な機能を最大限に利用するために特定のハードウェア ベースの開発キットを必要とする、特殊なハードウェアです。 Xbox One のハードウェアの機能を最大限に利用する必要があるゲームを開発している場合、[ID@Xbox](https://www.xbox.com/Developers/id) プログラムに登録して Xbox One 開発キットにアクセスすることを検討してください。


Xbox One での UWP アプリのシステム リソースについて詳しくは、次のビデオの最初の部分をご覧ください。
</br>
</br>
<iframe src="https://mva.microsoft.com/en-US/training-courses-embed/developing-xbox-one-applications-16860/Video-What-s-Unique--vk0fOPf9C_2006218965" width="636" height="480" allowFullScreen frameBorder="0"></iframe>

## <a name="see-also"></a>関連項目
- [Xbox One の UWP](index.md)
- [Xbox Live クリエーターズ プログラムを概要します。](../xbox-live/get-started-with-creators/get-started-with-xbox-live-creators.md)
- [DirectX および Xbox One での UWP](https://blogs.msdn.microsoft.com/chuckw/2017/12/15/directx-and-uwp-on-xbox-one/)

