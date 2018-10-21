---
title: Xbox Live SDK の新規事項 - August 2015
author: KevinAsgari
description: Xbox Live SDK の新規事項 - August 2015
ms.assetid: a034867b-7cc0-4b97-89d5-3486e95a80b4
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: xbox live, xbox, ゲーム, uwp, windows 10, xbox one
ms.localizationpriority: medium
ms.openlocfilehash: a8dedfe2111621215f0cc0741f7209c37f816bd3
ms.sourcegitcommit: 72835733ec429a5deb6a11da4112336746e5e9cf
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/21/2018
ms.locfileid: "5163216"
---
# <a name="whats-new-for-the-xbox-live-sdk---august-2015"></a>Xbox Live SDK の新規事項 - August 2015

June 2015 リリースで追加された内容については、「[新規事項 - June 2015](1506-whats-new.md)」を参照してください。

Xbox Live SDK の August リリースには以下の更新が含まれます。

## <a name="os-and-tool-support"></a>OS とツールのサポート
Xbox Live SDK で、Windows 10 RTM [バージョン 10.0.10240] と Visual Studio 2015 RTM [バージョン 14.0.23107.0] がサポートされるようになりました。

## <a name="multiplayer-manager-winrt-apis"></a>Multiplayer Manager WinRT API
Multiplayer Manager (experimental 名前空間内) は、WinRT API を (C++ API に加えて) サポートするようになりました

## <a name="submit-batch-feedback-from-a-title"></a>タイトルからバッチ フィードバックを送信する
タイトルから多数のフィードバック項目を一度に送信します。

## <a name="newupdated-documentation"></a>新しい/更新されたドキュメント
Xbox Live SDK パッケージに "Docs" フォルダーが追加されました。このフォルダーには、更新された API リファレンスと新しい「Xbox Live プログラミング ガイド」が含まれています。

バグ修正:

* リアルタイム アクティビティ サービスでサブスクリプションを削除するときにクラッシュする
* ゲスト アカウントでのログイン時にクラッシュする
* ネットワーク ケーブルを取り外したときのアクセス違反
* トンネル障害により C++ API でエラー コードが生成されるようになった
* TitleStorageService::DownloadBlobAsync による ETag の問題
* サンプル アプリのさまざまなバグ修正
