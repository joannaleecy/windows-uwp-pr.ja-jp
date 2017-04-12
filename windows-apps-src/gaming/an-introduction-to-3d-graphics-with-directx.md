---
author: mtoepke
title: "DirectX ゲームの基本的な 3D グラフィックス"
description: "DirectX プログラミングを使って、3D グラフィックスの基本的な概念を実装する方法について説明します。"
ms.assetid: 2989c91f-7b45-7377-4e83-9daa0325e92e
ms.author: mtoepke
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, ゲーム, DirectX, グラフィックス"
ms.openlocfilehash: 2ac11ce220bc1c62c81df12fbf9c2a41fda1d940
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
# <a name="basic-3d-graphics-for-directx-games"></a>DirectX ゲームの基本的な 3D グラフィックス


\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132) をご覧ください \]

DirectX プログラミングを使って、3D グラフィックスの基本的な概念を実装する方法について説明します。

**目標:** 3D グラフィックス アプリのプログラミング方法を身に付ける。

## <a name="prerequisites"></a>前提条件


C++ に習熟していることを前提としています。 また、グラフィックス プログラミングの概念に対する基礎的な知識も必要となります。

**完了までの合計時間:** 30 分。

## <a name="where-to-go-from-here"></a>次の段階


ここでは、DirectX と C++\\Cx を使って 3D グラフィックスを開発する方法について説明します。 この 5 つのパートから成るチュートリアルでは、[Direct3D](https://msdn.microsoft.com/library/windows/desktop/hh309466) API と、その他の DirectX サンプルの多くでも使われる概念やコードを紹介しています。 各パートでは、UWP の C++ アプリ向けに DirectX を構成することから始まって、プリミティブのテクスチャリングや効果の追加まで、段階的に構築していきます。

> **注**  このチュートリアルでは、右手による座標系と列のベクターを使います。 多くの DirectX サンプルと DirectX アプリでは、左手による座標系と行のベクターを使います。 より完全なグラフィックス数式ソリューションと、左手による座標系と行のベクターをサポートするグラフィックス数式ソリューションが必要な場合は、[DirectXMath](https://msdn.microsoft.com/library/windows/desktop/hh437833) を使うことを検討してください。 詳しくは、「[Direct3D との DirectXMath の使用](https://msdn.microsoft.com/library/windows/desktop/ff729728#Use_DXMath_with_D3D)」をご覧ください。

 

次の方法について説明します。

-   Windows ランタイムを使っての [Direct3D](https://msdn.microsoft.com/library/windows/desktop/hh309466) インターフェイスの初期化
-   頂点ごとのシェーダー操作の適用
-   ジオメトリの設定
-   シーンのラスタライズ (3D シーンを 2D プロジェクションにフラット化)
-   隠面のカリング

> **注**  
この記事は、ユニバーサル Windows プラットフォーム (UWP) アプリを作成する Windows 10 開発者を対象としています。 Windows 8.x 用または Windows Phone 8.x 用の開発を行っている場合は、[アーカイブされているドキュメント](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください。

 

次に、Direct3D デバイス、スワップ チェーン、レンダー ターゲット ビューを作成し、レンダリングされた画像をディスプレイに表示します。

[クイック スタート: DirectX リソースの設定と画像の表示](setting-up-directx-resources.md)

## <a name="related-topics"></a>関連トピック


* [Direct3D 11 グラフィックス](https://msdn.microsoft.com/library/windows/desktop/ff476080)
* [DXGI](https://msdn.microsoft.com/library/windows/desktop/hh404534)
* [HLSL](https://msdn.microsoft.com/library/windows/desktop/bb509561)

 

 




