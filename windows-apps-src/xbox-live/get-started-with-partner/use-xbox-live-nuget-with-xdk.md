---
title: XDK で Xbox Live NuGet パッケージを使用する
author: KevinAsgari
description: Xbox Live API NuGet パッケージを使用して XDK タイトルを開発する方法について説明します。
ms.assetid: 2c5ae514-393d-48bb-afd8-a897d35f7938
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, NuGet
ms.localizationpriority: medium
ms.openlocfilehash: b8b12201c0511339c4dd38824e17f7586e03708e
ms.sourcegitcommit: e4f3e1b2d08a02b9920e78e802234e5b674e7223
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/26/2018
ms.locfileid: "4208731"
---
# <a name="use-the-xbox-live-api-nuget-package-to-develop-xdk-titles"></a>Xbox Live API NuGet パッケージを使用して XDK タイトルを開発する

### <a name="1--ensure-you-have-the-latest-nuget-package-manager-installed"></a>1. 最新の NuGet パッケージ マネージャーがインストールされていることを確認する
1.  現在のバージョンをチェックします。
    - メニュー バーで [ツール] -> [拡張機能と更新プログラム] を選択します。
    - [インストール済み] タブで、次を探します:  `NuGet Package Manager`
![](../images/nuget/nuget_uwp_install_1.png)
2.  現在のバージョンを更新するには、以下を実行します。
    - メニュー バーで [ツール] -> [拡張機能と更新プログラム] を選択します。
    - [更新プログラム] -> [Visual Studio ギャラリー] タブで、次を選択します:  `Update`
![](../images/nuget/nuget_uwp_install_2.png)

### <a name="2--add-reference-to-the-project"></a>2. プロジェクトに参照を追加する
1.  プロジェクトに参照を追加します
    1.  プロジェクト ソリューションを右クリックし、[NuGet パッケージの管理] を選択します。
<br/>
![](../images/nuget/nuget_xbox_install_4.png)
1.  `Xbox Live` を探し、適切なパッケージを選択して、[`Install`] をクリックします。
  - Xbox Services API には、UWP と XDK の両方で使用できるものと、C++ で使用できるもの、WinRT で使用できるものがあります。  
  - `Microsoft.Xbox.Live.SDK.*.UWP` または `Microsoft.Xbox.Live.SDK.*.XboxOneXDK` を選択します。  `XboxOneXDK` は、ID@Xbox 用のものであり、Xbox One XDK を使用している管理対象の開発者が利用します。  `UWP` は、PC、Xbox One、Windows Phone で実行できる UWP ゲーム用のものです。  詳しくは Xbox One で UWP の実行について[https://docs.microsoft.com/en-us/windows/uwp/xbox-apps/getting-started](https://docs.microsoft.com/en-us/windows/uwp/xbox-apps/getting-started)
  - `Microsoft.Xbox.Live.SDK.Cpp.*` または `Microsoft.Xbox.Live.SDK.WinRT.*` を選択します。 `Cpp` は、Xbox Live API を使用している C++ ゲーム エンジン用のものです。  `WinRT` は、Xbox Live API を使用し、C++、C#、または Javascript で記述されたゲーム エンジン用のものです。  C++ エンジンで WinRT を使用する場合は、ハット (^) を使う C++/CX を使用します。  `Cpp` は、C++ ゲーム エンジンで使用する際に推奨される API です。    
![](../images/nuget/nuget_xbox_install_5.png)
![](../images/nuget/nuget_uwp_install_7.png)
1. ライセンスの TOS を受け入れた後、パッケージが正常に追加されるまで待機します。  パッケージ マネージャーの出力ウィンドウに次のログが表示されます。

```
========== Finished ==========
```

### <a name="3--optionally-include-header"></a>3. オプションでインクルードするヘッダー
* `Microsoft.Xbox.Live.SDK.Cpp.*` ベースのプロジェクトの場合、プロジェクトのソースに `#include <xsapi\services.h>` を指定できます。
* `Microsoft.Xbox.Live.SDK.WinRT.*` ベースのプロジェクトの場合は、ヘッダーをインクルードする必要はありません。   
