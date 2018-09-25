---
title: XDK に組み込まれている Xbox Live API を使用する
author: KevinAsgari
description: Xbox 開発キット (XDK) プロジェクトで、組み込みの Xbox Live API を使用する方法について説明します。
ms.assetid: 539caca3-58bc-49d9-8432-ca8e57755be2
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 527a62af7ca31a401da47eb10e59c1593f62e433
ms.sourcegitcommit: 232543fba1fb30bb1489b053310ed6bd4b8f15d5
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/25/2018
ms.locfileid: "4174502"
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
