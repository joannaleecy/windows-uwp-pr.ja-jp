---
title: Xbox Live C Api
author: KevinAsgari
description: Xbox Live サービスとのやり取りに使用できるフラット C API モデルについて説明します。
ms.author: kevinasg
ms.date: 06/05/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: xbox live, xbox, ゲーム、uwp、windows 10, xbox one、c, xsapi
ms.localizationpriority: medium
ms.openlocfilehash: ac47d3877c44cfa9891753c49be8a5749fba9185
ms.sourcegitcommit: 63cef0a7805f1594984da4d4ff2f76894f12d942
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/05/2018
ms.locfileid: "4393140"
---
# <a name="introduction-to-the-xbox-live-c-apis"></a>Xbox Live C Api の概要

2018 年 6 月の新しいフラット C API レイヤーは、XSAPI に追加されました。 この新しい API レイヤーでは、C++ と WinRT API レイヤーで発生したいくつかの問題を解決します。

C++ API は、XSAPI のすべての機能をまだ対応していませんが、作業中は追加の機能。 すべて 3 API レイヤー、C、C++、および WinRT は引き続きサポートされているし、時間の経過と共に新しい機能を追加します。

> [!NOTE]
> C++ Api は、現在のみ動作 Xbox 開発キット (XDK) を使用するタイトルにします。 この時点で UWP ゲームはサポートしていません。

## <a name="features-covered-by-the-c-apis"></a>C++ Api で取り上げた機能

現在、C API には、次の機能とサービスがサポートしています。

- 実績
- プレゼンス
- プロファイル
- ソーシャル
- Social Manager

## <a name="benefits-of-the-c-api-for-xsapi"></a>Xsapi C API のメリット

- タイトルを XSAPI を呼び出すと、メモリ割り当てを制御できます。
- により、タイトルを XSAPI を呼び出すときの処理スレッドの完全な制御を取得します。
- 新しい HTTP ライブラリ、libHttpClient、ゲーム開発者向けに設計されたを使用します。

と共に C++ XSAPI C Api を使用することができますが、C++ Api を使った上記のメリットを獲得はありません。

### <a name="managing-memory-allocations"></a>メモリ割り当てを管理します。

新しい C++ API を使った、XSAPI がメモリを割り当てることがしようとしたときに呼び出す関数コールバックを指定できます。 関数のコールバックを指定しない場合、XSAPI は標準的なメモリ割り当てルーチンを使用します。

メモリ ルーチンを手動で指定するには、次の操作を行うことができます。

- ゲームの起動時には。
  - 呼び出す`XblMemSetFunctions(memAllocFunc, memFreeFunc)`を割り当てると、メモリを解放して割り当てコールバックを指定します。
  - 呼び出す`XblInitialize()`ライブラリのインスタンスを初期化します。  
- ゲームが実行中します。
  - 新しい C++ Api のいずれかの XSAPI でした呼び出しの割り当てまたは XSAPI に指定されたメモリ処理コールバックの呼び出しにより、メモリを解放します。  
- ゲームが終了します。
  - 呼び出す`XblCleanup()`XSAPI ライブラリに関連付けられているすべてのリソースを解放します。
  - ゲームのカスタム メモリ マネージャーをクリーンアップします。

### <a name="managing-asynchronous-threads"></a>非同期のスレッドを管理します。

C++ API には、開発者がスレッド モデルを完全に制御できるパターンを呼び出して新しい非同期スレッドが導入されています。 詳細については、[呼び出しパターン XSAPI フラット C レイヤーの非同期呼び出し](flatc-async-patterns.md)を参照してください。

## <a name="migrating-code-to-use-c-xsapi"></a>C++ XSAPI を使用するコードの移行

XSAPI C Api は、一度に 1 つの機能を移行することをお勧めしますプロジェクトでは、XSAPI の C++ Api と共に使用できます。

C++ Api と C++ Api 同様に、さまざまなエントリ ポイントの一般的なコアの単なるシン ラッパーはであるため、機能が変更する必要があります。 ただし、C Api のみを利用カスタム メモリとスレッドの管理機能ができます。

> [!IMPORTANT]
> C++ Api と XSAPI WinRT Api を混在させることはできません。

## <a name="where-to-view-the-c-apis"></a>C++ Api を表示します。

- [C++ API のヘッダー ファイル](https://github.com/Microsoft/xbox-live-api/tree/master/Include/xsapi-c)
- [新しい C++ Api を使用するサンプル コード](https://github.com/Microsoft/xbox-live-api/tree/master/InProgressSamples/Social/Xbox/C)
- [libHttpClient](https://github.com/Microsoft/libHttpClient)
