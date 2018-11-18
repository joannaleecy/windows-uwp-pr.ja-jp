---
title: XDK に組み込まれている Xbox Live API を使用する
author: KevinAsgari
description: Xbox 開発キット (XDK) プロジェクトで、組み込みの Xbox Live API を使用する方法について説明します。
ms.assetid: 539caca3-58bc-49d9-8432-ca8e57755be2
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: e127dd2adb53e8fdf5fb0469ce9deae5759eb899
ms.sourcegitcommit: 3257416aebb5a7b1515e107866806f8bd57845a8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/17/2018
ms.locfileid: "7153222"
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
