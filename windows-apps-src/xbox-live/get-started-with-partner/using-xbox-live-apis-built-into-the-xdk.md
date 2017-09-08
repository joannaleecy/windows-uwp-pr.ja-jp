---
title: "XDK に組み込まれている Xbox Live API を使用する"
author: KevinAsgari
description: "Xbox 開発キット (XDK) プロジェクトで、組み込みの Xbox Live API を使用する方法について説明します。"
ms.assetid: 539caca3-58bc-49d9-8432-ca8e57755be2
ms.author: kevinasg
ms.date: 04-04-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One"
ms.openlocfilehash: 202f6fa25beafc569db4de6828f486db7b21bc20
ms.sourcegitcommit: 90fbdc0e25e0dff40c571d6687143dd7e16ab8a8
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/06/2017
---
# <a name="using-xbox-live-apis-built-into-the-xdk"></a>XDK に組み込まれている Xbox Live API を使用する

1. Visual Studio でプロジェクトを右クリックし、[参照] を選択します。
1. [新しい参照の追加] を選択します。
1. 左側のパネルで [Durango.<build number>]  と [拡張機能] をクリックします。
1. 中央のパネルで、次のいずれかを選択します。
- WinRT XSAPI API を使用する場合は、[Xbox Services API] を選択します。
- C++ XSAPI API を使用する場合は、[Xbox Services API Cpp] を選択します。
1. [OK] をクリックします。

注: ビルド システムが props ファイルをサポートしていない場合は、次に示すように、プリプロセッサの定義とライブラリを手動で追加する必要があります。
`%XboxOneExtensionSDKLatest%\ExtensionSDKs\Xbox.Services.API.Cpp\8.0\DesignTime\CommonConfiguration\Neutral\Xbox.Services.API.Cpp.props`
