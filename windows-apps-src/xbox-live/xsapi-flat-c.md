---
title: Xbox Live の C Api
description: Xbox Live サービスとの対話に使用できるフラット C API モデルについて説明します。
ms.date: 06/05/2018
ms.topic: article
keywords: xbox live、xbox、ゲーム、uwp、windows 10、1 つ xbox、c、xsapi
ms.localizationpriority: medium
ms.openlocfilehash: a1c73661b561d586f9e28957c7caa6a1b1f9cb03
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57597527"
---
# <a name="introduction-to-the-xbox-live-c-apis"></a>Xbox Live の C Api の概要

2018 年 6 月では、新しいフラット C API レイヤーは XSAPI に追加されました。 この新しい API レイヤーは、C++ と WinRT API レイヤーで発生したいくつかの問題を解決します。

C API が XSAPI のすべての機能をまだ扱っていないが、その他の機能が取り組んでいます。 すべて 3 API レイヤー、C、C++、および WinRT は引き続きサポートし、時間の経過と共に追加の機能を追加します。

> [!NOTE]
> C Api 現在でのみ使用 Xbox Developer Kit (XDK) を使用するタイトル。 この時点でゲームを UWP はサポートしていません。

## <a name="features-covered-by-the-c-apis"></a>C Api で説明されている機能

現在、C API は、次の機能とサービスをサポートします。

- 成績
- プレゼンス
- Profile
- ソーシャル
- Social Manager

## <a name="benefits-of-the-c-api-for-xsapi"></a>XSAPI の C API の利点

- XSAPI を呼び出すときに、メモリの割り当てを制御するタイトルを使用できます。
- スレッド処理 XSAPI を呼び出すときに完全に制御するタイトルを使用できます。
- 新しい HTTP ライブラリを libHttpClient、ゲーム開発者向けに設計を使用します。

C++ の XSAPI と共に C Api を使用できますが、C++ Api を使用した上記の利点を利用できません。

### <a name="managing-memory-allocations"></a>メモリ割り当ての管理

新しい C API を使用して、メモリを割り当てるときに呼び出す XSAPI 関数コールバックを指定できます。 関数コールバックを指定しない場合、XSAPI は標準的なメモリ割り当てルーチンを使用します。

ルーチンは、メモリを手動で指定するには、次の操作を行うことができます。

- ゲームの先頭には。
  - 呼び出す`XblMemSetFunctions(memAllocFunc, memFreeFunc)`割り当てと解放をメモリの割り当てのコールバックを指定します。
  - 呼び出す`XblInitialize()`ライブラリのインスタンスを初期化します。  
- ゲームの実行: 中
  - 呼び出す新しい C Api のいずれかで XSAPI を割り当てるまたは XSAPI を指定されたメモリ処理のコールバックを呼び出すと、メモリを解放します。  
- ゲームが終了します。
  - 呼び出す`XblCleanup()`XSAPI ライブラリに関連付けられているすべてのリソースを解放します。
  - ゲームのカスタム メモリ マネージャーをクリーンアップします。

### <a name="managing-asynchronous-threads"></a>非同期のスレッドを管理します。

C API には、開発者がスレッド処理モデルを完全に制御できるパターンを呼び出して新しい非同期のスレッドが導入されています。 詳細については、次を参照してください。 [XSAPI の呼び出しパターンは、C レイヤーの非同期呼び出しをフラット](flatc-async-patterns.md)します。

## <a name="migrating-code-to-use-c-xsapi"></a>C XSAPI を使用するコードの移行

一度に 1 つの機能を移行することをお勧めします。 プロジェクトでは、XSAPI C++ Api と共に XSAPI C Api を使用できます。

C Api および C++ Api 機能は変更されませんのでだけ異なるエントリ ポイントでの common core の実際にはシン ラッパーであります。 ただし、C Api のみ利用できますカスタム メモリとスレッドの管理機能。

> [!IMPORTANT]
> C Api を使用した XSAPI WinRT Api を混在させることはできません。

## <a name="where-to-view-the-c-apis"></a>C Api を表示します。

- [C API ヘッダー ファイル](https://github.com/Microsoft/xbox-live-api/tree/master/Include/xsapi-c)
- [新しい C Api を使用してサンプル コード](https://github.com/Microsoft/xbox-live-api/tree/master/InProgressSamples/Social/Xbox/C)
- [libHttpClient](https://github.com/Microsoft/libHttpClient)
