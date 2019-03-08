---
description: クロスプラットフォーム アプリを開発するときの選択肢
title: iOS と UWP のアプリ開発方法の選択
ms.assetid: 5CDAB313-07B7-4A32-A49B-026361DCC853
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 9bf23926a1c17615db5ef838d21f9a46a8921c8c
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57655787"
---
# <a name="selecting-an-approach-to-ios-and-uwp-app-development"></a>iOS と UWP のアプリ開発方法の選択


クロスプラットフォーム アプリを開発するときの選択肢

## <a name="whats-the-best-way-to-support-both-ios-and-windows"></a>iOS と Windows の両方をサポートするための最適な方法

Windows と iOS はまったく違うものに見えるかもしれませんが、増え続けるツールと手法が、両方のプラットフォーム (Android も含めて) をサポートするアプリを作成する場合に非常に役に立ちます。 最適なソリューションは、作成するアプリの種類によって、またゼロから始めるか既存のプロジェクトを移植するかによって異なります。

## <a name="writing-a-new-app"></a>新しいアプリの作成

ゼロから始める場合、次のように自由に選べる多くのオプションがあります。

-   [Xamarin](https://go.microsoft.com/fwlink/p/?LinkID=320484)

    Xamarin を使うと、C# でアプリを作成して Windows 上で実行することができ、ネイティブの iOS アプリを作成することもできます。 Xamarin のサポートは Visual Studio に組み込まれており、適切なプロジェクトの種類を選ぶだけです。

-   [Apache Cordova](https://go.microsoft.com/fwlink/p/?LinkID=400439)

    Javascript と HTML の方がよい場合は、Apache Cordova (PhoneGap とも呼ばれる) を使うと、iOS、Windows、および Android 向けのクロスプラットフォーム アプリを容易に作成できます。 このプロジェクトの種類は、Visual Studio にも組み込まれています。

-   ゲーム エンジン

    [Unity3D](https://go.microsoft.com/fwlink/p/?LinkID=320479) や [Unreal Engine](https://go.microsoft.com/fwlink/p/?LinkID=394062) などのツールを自由に利用することで、Windows のほか、iOS など多くのプラットフォーム用に最高品質のゲームを作成することができます。 Unity は C# スクリプトをサポートし、Unreal は C++ を使います。

-   [MonoGame](https://go.microsoft.com/fwlink/p/?LinkID=320483)

    XNA の後継にあたります。 これは、オープン ソースのクロスプラットフォーム フレームワークです。つまり、物理エンジン、2D および 3D グラフィック サポートにより、多くのプラットフォーム向けに C# でアプリを作成できます。

## <a name="adapting-an-existing-app"></a>既存のアプリの適応変更

既存の iOS アプリを使う場合、オプションが少し制限されます。 ただし、何も失われません。

-   [iOS 用 Windows ブリッジ](https://go.microsoft.com/fwlink/p/?LinkId=619014)

    Project Islandwood とも呼ばれます。これはまだ開発中のツールで、Xcode プロジェクトを Visual Studio に直接インポートできます。 Objective-C コードは Visual Studio からビルドおよびデバッグできます。 プロジェクトでグラフィックス用に Cocos などのライブラリを使用している場合、これはアプリを迅速に移植するための便利な方法です。

-   C++ コードの目的変更

    主要なビジネス ロジックが、Objective-C や Swift ではなく C++ で作成されている場合、そのコードを少し変更するだけでプロジェクトで使用できます。 そして、他の Windows でアプリと同様に、XAML を使って UI を定義し、必要に応じて C++ コードを呼び出すことができます。

-   [角度を使用して、Windows での OpenGL ES の実行](https://go.microsoft.com/fwlink/p/?linkid=618387)

    OpenGL ES 2.0 プロジェクトを移植する中間の手順で ANGLE を使います。 ANGLE では、OpenGL ES API 呼び出しを DirectX 11 API 呼び出しに変換することにより、Windows で OpenGL ES コンテンツを実行することができます。

## <a name="other-cross-platform-authoring-tools"></a>その他のクロスプラットフォームの作成ツール

-   [GameSalad](https://go.microsoft.com/fwlink/p/?LinkID=320480)

    ゲーム作成環境。

-   [Construct 2]( https://go.microsoft.com/fwlink/p/?LinkID=320481)

    ゲーム作成環境。

-   [チタン Studio](https://go.microsoft.com/fwlink/p/?LinkID=320482)

    クロスプラットフォームの作成環境。

-   [Cocos2d-x](https://go.microsoft.com/fwlink/p/?LinkID=320485)

    スプライト処理と物理モデリング用のクロスプラットフォームのコード ライブラリ。

-   [Impact.js](https://go.microsoft.com/fwlink/p/?LinkID=320486)

    HTML ベースのゲーム ライブラリ。

-   [Marmalade](https://go.microsoft.com/fwlink/p/?LinkID=320487)

    クロスプラットフォーム SDK。

-   [OpenFL](https://go.microsoft.com/fwlink/p/?LinkID=320488)

    クロスプラットフォームの開発ツール。

-   [GameMaker](https://go.microsoft.com/fwlink/p/?LinkID=320490)

    特にゲーム用の作成環境。

-   [PlayCanvas](https://go.microsoft.com/fwlink/p/?LinkID=394061)

    HTML ベースのゲーム開発用ツール。

