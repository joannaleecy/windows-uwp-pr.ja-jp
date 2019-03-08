---
title: XDK で Xbox Live NuGet パッケージを使用する
description: Xbox Live API NuGet パッケージを使用して XDK タイトルを開発する方法について説明します。
ms.assetid: 2c5ae514-393d-48bb-afd8-a897d35f7938
ms.date: 04/04/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, NuGet
ms.localizationpriority: medium
ms.openlocfilehash: c955ca42c09075e5125683588c335cfa47443f00
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57655037"
---
# <a name="use-the-xbox-live-api-nuget-package-to-develop-xdk-titles"></a>Xbox Live API NuGet パッケージを使用して XDK タイトルを開発する

### <a name="1--ensure-you-have-the-latest-nuget-package-manager-installed"></a>1. インストールされている最新の NuGet パッケージ マネージャーをしたことを確認します。
1.  現在のバージョンをチェックします。
    - メニュー バーで [ツール] -> [拡張機能と更新プログラム] を選択します。
    - [インストール済み] タブを探します `NuGet Package Manager`
![](../images/nuget/nuget_uwp_install_1.png)
2.  現在のバージョンを更新するには、以下を実行します。
    - メニュー バーで [ツール] -> [拡張機能と更新プログラム] を選択します。
    - 更新プログラム [Visual Studio ギャラリー] タブ -> で、選択 `Update`
![](../images/nuget/nuget_uwp_install_2.png)

### <a name="2--add-reference-to-the-project"></a>2. プロジェクトに参照を追加します
1.  プロジェクトに参照を追加します
    1.  プロジェクト ソリューションを右クリックし、[NuGet パッケージの管理] を選択します。
<br/>
![](../images/nuget/nuget_xbox_install_4.png)
1.  `Xbox Live` を探し、適切なパッケージを選択して、[`Install`] をクリックします。
  - Xbox Services API には、UWP と XDK の両方で使用できるものと、C++ で使用できるもの、WinRT で使用できるものがあります。  
  - `Microsoft.Xbox.Live.SDK.*.UWP` または `Microsoft.Xbox.Live.SDK.*.XboxOneXDK` を選択します。  `XboxOneXDK` ID@Xboxおよびマネージ開発者が Xbox One XDK を使用しています。  `UWP` PC、Xbox One または Windows Phone で実行できる UWP ゲームです。  詳細に Xbox One での UWP を実行する方法 [https://docs.microsoft.com/en-us/windows/uwp/xbox-apps/getting-started](https://docs.microsoft.com/en-us/windows/uwp/xbox-apps/getting-started)
  - `Microsoft.Xbox.Live.SDK.Cpp.*` または `Microsoft.Xbox.Live.SDK.WinRT.*` を選択します。 `Cpp` Xbox Live Api を使用して C++ ゲーム エンジンです。  `WinRT` C++ で記述されたゲーム エンジンC#、または Xbox Live Api を使用した Javascript。  C++ エンジンで WinRT を使用する場合は、ハット (^) を使う C++/CX を使用します。  `Cpp` C++ ゲーム エンジンを使用する推奨の API です。    
![](../images/nuget/nuget_xbox_install_5.png)
![](../images/nuget/nuget_uwp_install_7.png)
1. ライセンスの TOS を受け入れた後、パッケージが正常に追加されるまで待機します。  パッケージ マネージャーの出力ウィンドウに次のログが表示されます。

```
========== Finished ==========
```

### <a name="3--optionally-include-header"></a>3.必要に応じてヘッダーを含める
* `Microsoft.Xbox.Live.SDK.Cpp.*` ベースのプロジェクトの場合、プロジェクトのソースに `#include <xsapi\services.h>` を指定できます。
* `Microsoft.Xbox.Live.SDK.WinRT.*` ベースのプロジェクトの場合は、ヘッダーをインクルードする必要はありません。   
