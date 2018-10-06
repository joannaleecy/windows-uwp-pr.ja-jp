---
title: Xbox Live API のバイナリを UWP プロジェクトに追加する
author: KevinAsgari
description: NuGet を使用して Xbox Live API のバイナリ パッケージを UWP プロジェクトに追加する方法について説明します。
ms.assetid: 1e77ce9f-8a0e-402c-9f46-e37f9cda90ed
ms.author: kevinasg
ms.date: 11/28/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, NuGet
ms.localizationpriority: medium
ms.openlocfilehash: 84d3ce8b56e5d1bf921eef48499d54b1d3fc4c22
ms.sourcegitcommit: 63cef0a7805f1594984da4d4ff2f76894f12d942
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/05/2018
ms.locfileid: "4391752"
---
# <a name="add-xbox-live-apis-binary-package-to-your-uwp-project"></a>Xbox Live API のバイナリ パッケージを UWP プロジェクトに追加する

## <a name="requirements"></a>要件

2. **[Windows 10](https://microsoft.com/windows)**。
3. **[Visual Studio](https://www.visualstudio.com/)**。 Visual Studio 2015 Update 3 以降、UWP アプリを構築できます。 開発者とセキュリティ更新プログラムの最新リリースの Visual Studio を使用することをお勧めします。
4. **[Windows 10 SDK](https://developer.microsoft.com/windows/downloads/windows-10-sdk) v10.0.10586.0** 以降。

## <a name="add-the-binary-package-via-nuget"></a>NuGet を使ったバイナリ パッケージの追加

プロジェクトから Xbox Live API を使用するには、NuGet パッケージを使うか API ソースを追加してバイナリへの参照を追加します。 NuGet パッケージを追加するとコンパイルが高速になりますが、ソースを追加するとデバッグが簡単になります。 この記事では、NuGet パッケージを使う方法について説明します。 ソースを使用する場合は、「[UWP プロジェクトでの Xbox Live API ソースのコンパイル](add-xbox-live-apis-source-to-a-uwp-project.md)」をご覧ください。

Xbox Services API には、UWP と XDK の両方で使用できるものと、C++ で使用できるもの、WinRT で使用できるものがあり名前空間の構造は **Microsoft.Xbox.Live.SDK.*.UWP** と **Microsoft.Xbox.Live.SDK.*.XboxOneXDK** です。

1. **UWP** は、PC、Xbox One、Windows Phone で実行できる UWP ゲームをビルドしている開発者向けのものです。
2. **XboxOneXDK** は、ID@Xbox 用のものであり、Xbox One XDK を使用している管理対象の開発者が利用します。
3. C++ SDK は C++ ゲーム エンジンに使用できます。 WinRT SDK は、C++、C#、JavaScript を使って記述されたゲーム エンジン用です。
4. C++ エンジンで WinRT を使用する場合は、ハット (^) を使う C++/CX を使用してください。 C++ は、C++ ゲーム エンジンで使用する際に推奨される API です。  

> [!TIP]
> Xbox One での UWP の実行について詳しくは、「[Xbox One の UWP アプリ開発の概要](https://docs.microsoft.com/windows/uwp/xbox-apps/getting-started)」をご覧ください。

Xbox Live SDK NuGet パッケージは次の方法で追加できます。

1. Visual Studio では、**[ツール]** > **[NuGet パッケージ マネージャー]** > **[ソリューションの NuGet パッケージの管理...]** の順に移動します。
2. NuGet パッケージ マネージャーで、**[参照]** をクリックして検索ボックスに「**Xbox.Live.SDK**」と入力します。
3. 左側の一覧から使う Xbox Live SDK のバージョンを選びます。
3. ウィンドウの右側にある、プロジェクトの横にあるチェック ボックスをオンにして **[インストール]** をクリックします。

> [!NOTE]
> Xbox Live クリエーターズ プログラムの開発者は、XDK がサポートされていないため、UWP バージョンの Xbox Live SDK を使用する必要があります。

![NuGet による XBL の追加](../images/getting_started/vs-add-nuget-xbl.gif)

> [!IMPORTANT]
> `Microsoft.Xbox.Live.SDK.Cpp.*` ベースのプロジェクトの場合、必ずプロジェクトのソースにヘッダー `#include <xsapi\services.h>` を含めてください。
