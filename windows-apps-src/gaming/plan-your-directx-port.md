---
title: DirectX の移植の計画
description: DirectX 9 から DirectX 11 とユニバーサル Windows プラットフォーム (UWP) へのゲーム移植プロジェクトを計画してください。グラフィックス コードのアップグレードと、Windows ランタイム環境へのゲームの配置が必要です。
ms.assetid: 3c0c33ca-5d15-ae12-33f8-9b5d8da08155
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, DirectX, 移植
ms.localizationpriority: medium
ms.openlocfilehash: 6779fd95d4fd1964a8ca19aa4a7a9f9c29a6179b
ms.sourcegitcommit: bf600a1fb5f7799961914f638061986d55f6ab12
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 02/04/2019
ms.locfileid: "9044383"
---
# <a name="plan-your-directx-port"></a>DirectX の移植の計画



**要約**

-   DirectX の移植の計画
-   [Direct3D 9 と Direct3D 11 の間の重要な変更点](understand-direct3d-11-1-concepts.md)
-   [機能のマッピング](feature-mapping.md)


DirectX 9 から DirectX 11 とユニバーサル Windows プラットフォーム (UWP) へのゲーム移植プロジェクトを計画してください。グラフィックス コードのアップグレードと、Windows ランタイム環境へのゲームの配置が必要です。

## <a name="plan-to-port-graphics-code"></a>グラフィックス コードの移植の計画


UWP へのゲームの移植を開始する前に、ゲームに Direct3D 8 の要素が残っていない状態にすることが重要です。 ゲームに固定関数パイプラインが残っていないことを確かめてください。 固定パイプライン機能など、推奨されなくなった機能の全一覧については、「[推奨されなくなった機能](https://msdn.microsoft.com/library/windows/desktop/cc308047)」をご覧ください。

Direct3D 9 から Direct3D 11 へのアップグレードは、変更箇所を探して置き換える作業にとどまりません。 Direct3D デバイス、デバイス コンテキスト、グラフィックス インフラストラクチャの違いを把握し、Direct3D 9 以降のその他の重要な変更について理解する必要があります。 このセクションの他のトピックを読むことで、このプロセスを開始できます。

D3DX と DXUT のヘルパー ライブラリは、独自のヘルパー ライブラリか、コミュニティ ツールに置き換える必要があります。 詳しくは、「[DirectX 11 API への DirectX 9 の機能のマッピング](feature-mapping.md)」をご覧ください。

> **注:**  [DirectX ツール キット](https://go.microsoft.com/fwlink/p/?LinkID=248929)または[DirectXTex](https://go.microsoft.com/fwlink/p/?LinkID=248926)を使用して一部の機能と、D3DX と DXUT で提供された以前の置換することができます。

 

アセンブリ言語で記述されたシェーダーは、シェーダー モデル 4 レベル 9\_1 または 9\_3 の機能を使って HLSL にアップグレードする必要があります。また、Effects ライブラリ向けに記述されたシェーダーは、より新しいバージョンの HLSL 構文に更新する必要があります。 詳しくは、「[DirectX 11 API への DirectX 9 の機能のマッピング](feature-mapping.md)」をご覧ください。

さまざまな [Direct3D 機能レベル](https://msdn.microsoft.com/library/windows/desktop/ff476876)について確かめてください。 機能レベルは、既知の機能のセットを定義することで、幅広いビデオ ハードウェアを分類するものです。 各セットは 9.1 ～ 11.2 のバージョンの Direct3D にほぼ対応しています。 すべての機能レベルで DirectX 11 API を使います。

## <a name="plan-to-port-win32-ui-code-to-corewindow"></a>CoreWindow への Win32 UI コードの移植の計画


UWP アプリは、[**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) と呼ばれる、アプリ コンテナーに対して作成されるウィンドウで実行されます。 ゲームでは、デスクトップのウィンドウよりも必要な実装の詳細が少ない [**IFrameworkView**](https://msdn.microsoft.com/library/windows/apps/hh700478) からの継承によってウィンドウを制御します。 ゲームのメイン ループは [**IFrameworkView::Run**](https://msdn.microsoft.com/library/windows/apps/hh700505) メソッドにあります。

UWP アプリのライフサイクルはデスクトップ アプリとは大きく異なります。 ゲームの保存は頻繁に行う必要があります。中断イベントが発生したときに、アプリで実行中のコードを停止できる時間が限られているうえ、アプリの再開時には、プレーヤーが中断時の状態からすぐにゲームを再開できるようにする必要があるためです。 ゲームの保存は、再開時に連続したゲームプレイ エクスペリエンスを維持できるだけの頻度で行う必要があります。ただし、フレームレートに影響したり、ゲームに引っかかりをもたらしたりしない程度にしてください。 ゲームは、ゲームが終了状態から再開されたときに、必要に応じてゲームの状態を読み込む必要があります。

[DirectXMath](https://msdn.microsoft.com/library/windows/desktop/ee415571) は、D3DXMath と XNAMath の代わりになり、数学演算ライブラリが必要になったときに役立ちます。 DirectXMath には、高速かつ移植可能なデータ型と、シェーダーで利用できるように整列およびパッキングされた型があります。

[インタロック API](https://msdn.microsoft.com/library/windows/desktop/dd405529) などのネイティブ ライブラリは、ARM の組み込みメソッドをサポートするために拡張されました。 ゲームでインタロック API を使う場合は、DirectX 11 と UWP でも使い続けることができます。

Microsoft のテンプレートとコード サンプルでは新しい C++ 機能が使われており、馴染みがない可能性があります。 たとえば、UI スレッドをブロックすることなく Direct3D リソースを読み込むために、非同期メソッドが[**ラムダ式**](https://msdn.microsoft.com/library/windows/apps/dd293608.aspx)と共に使われます。

頻繁に使う 2 つの概念があります。

-   マネージ リファレンス ([**^ 演算子**](https://msdn.microsoft.com/library/windows/apps/yk97tc08.aspx)) と [**マネージ クラス**](https://msdn.microsoft.com/library/windows/apps/6w96b5h7.aspx) (ref クラス) は、Windows ランタイムの基本となる部分です。 Windows ランタイム コンポーネントとのインターフェイスとして機能するマネージ ref クラスを使う必要があります。具体的には、[**IFrameworkView**](https://msdn.microsoft.com/library/windows/apps/hh700478) などです。詳しくはチュートリアルをご覧ください。
-   Direct3D 11 の COM インターフェイスを操作する場合は、[**Microsoft::WRL::ComPtr**](https://msdn.microsoft.com/library/windows/apps/br244983.aspx) テンプレート型を使うと COM ポインターが使いやすくなります。

 

 




