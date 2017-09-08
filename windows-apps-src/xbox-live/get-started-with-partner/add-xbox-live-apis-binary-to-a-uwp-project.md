---
title: "Xbox Live API のバイナリを UWP プロジェクトに追加する"
author: KevinAsgari
description: "NuGet を使用して Xbox Live API のバイナリ パッケージを UWP プロジェクトに追加する方法について説明します。"
ms.assetid: 1e77ce9f-8a0e-402c-9f46-e37f9cda90ed
ms.author: kevinasg
ms.date: 04-04-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, NuGet"
ms.openlocfilehash: f861b4b53dd4f1e89eb32c1cc1d9428e6576dcd1
ms.sourcegitcommit: 90fbdc0e25e0dff40c571d6687143dd7e16ab8a8
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/06/2017
---
# <a name="add-xbox-live-apis-binary-package-to-your-uwp-project"></a>Xbox Live API のバイナリ パッケージを UWP プロジェクトに追加する

次の手順を実行すると、NuGet を使用して最新の Xbox Live API をゲームにインポートできます。

### <a name="1-ensure-you-have-the-windows-10-rtm-and-visual-studio-2015-or-later-installed"></a>1. Windows 10 RTM および Visual Studio 2015 以降がインストールされていることを確認する

- Visual Studio 2015。  [https://www.visualstudio.com/en-us/downloads/visual-studio-2015-downloads-vs.aspx](https://www.visualstudio.com/en-us/downloads/visual-studio-2015-downloads-vs.aspx) をご覧ください
- Windows 10 SDK v10.0.14393.0 以降 [https://developer.microsoft.com/ja-JP/windows/downloads/windows-10-sdk](https://developer.microsoft.com/en-US/windows/downloads/windows-10-sdk)

### <a name="2--ensure-you-have-the-latest-nuget-package-manager-installed"></a>2. 最新の NuGet パッケージ マネージャーがインストールされていることを確認する

1.  現在のバージョンをチェックします。
    - メニュー バーで [ツール] -> [拡張機能と更新プログラム] を選択します。
    - [インストール済み] タブで、次を探します:  `NuGet Package Manager`
![](../images/nuget/nuget_uwp_install_1.png)
2.  現在のバージョンを更新するには、以下を実行します。
    - メニュー バーで [ツール] -> [拡張機能と更新プログラム] を選択します。
    - [更新プログラム] -> [Visual Studio ギャラリー] タブで、次を選択します:  `Update`
![](../images/nuget/nuget_uwp_install_2.png)

### <a name="3--add-reference-to-the-project"></a>3. プロジェクトに参照を追加する
1.  プロジェクト ソリューションを右クリックし、次を選択します:  `Manage NuGet Packages`
![](../images/nuget/nuget_uwp_install_6.png)
1.  `Xbox Live` を探し、適切なパッケージを選択して、[`Install`] をクリックします。
  - Xbox Services API には、UWP と XDK の両方で使用できるものと、C++ で使用できるもの、WinRT で使用できるものがあります。  
  - `Microsoft.Xbox.Live.SDK.*.UWP` または `Microsoft.Xbox.Live.SDK.*.XboxOneXDK` を選択します。  `XboxOneXDK` は、ID@Xbox 用のものであり、Xbox One XDK を使用している管理対象の開発者が利用します。  `UWP` は、PC、Xbox One、Windows Phone で実行できる UWP ゲーム用のものです。  Xbox One での UWP の実行について詳しくは、[https://docs.microsoft.com/ja-jp/windows/uwp/xbox-apps/getting-started](https://docs.microsoft.com/en-us/windows/uwp/xbox-apps/getting-started) をご覧ください。
  - `Microsoft.Xbox.Live.SDK.Cpp.*` または `Microsoft.Xbox.Live.SDK.WinRT.*` を選択します。 `Cpp` は、Xbox Live API を使用している C++ ゲーム エンジン用のものです。  `WinRT` は、Xbox Live API を使用し、C++、C#、または Javascript で記述されたゲーム用のものです。  C++ エンジンで WinRT を使用する場合は、ハット (^) を使う C++/CX を使用します。  `Cpp` は、C++ ゲーム エンジンで使用する際に推奨される API です。    
  -  Xbox Live クリエーターズ プログラムに参加している場合は、次のオプションのいずれも使うことができます: 1) Microsoft.Xbox.Live.SDK.Cpp.UWP (C++ の UWP ゲーム エンジン用)、2) Microsoft.Xbox.Live.SDK.WinRT.UWP (C# または JavaScript の UWP ゲーム エンジン用)。 C++ エンジンで WinRT を使用する場合は、ハット (^) を使う C++/CX を使用できます。  Microsoft.Xbox.Live.SDK.Cpp.UWP は、C++ ゲーム エンジンで使用する際に推奨される API です。 3) Unity。  詳しくは、「[Unity を使用してクリエーターズ タイトルを開発する](../get-started-with-creators/develop-creators-title-with-unity.md)」の記事をご覧ください。
![](../images/nuget/nuget_uwp_install_7.png)
1. ライセンスの TOS を受け入れた後、パッケージが正常に追加されるまで待機します。  パッケージ マネージャーの出力ウィンドウに次のログが表示されます。

```
========== Finished ==========
```

### <a name="4--optionally-include-header"></a>4. オプションでインクルードするヘッダー
* `Microsoft.Xbox.Live.SDK.Cpp.*` ベースのプロジェクトの場合、プロジェクトのソースに `#include <xsapi\services.h>` を指定できます。
* `Microsoft.Xbox.Live.SDK.WinRT.*` ベースのプロジェクトの場合は、ヘッダーをインクルードする必要はありません。   
