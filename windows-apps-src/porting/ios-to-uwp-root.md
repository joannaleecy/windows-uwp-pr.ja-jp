---
author: stevewhims
description: iOS から UWP への移行
Search.SourceType: Video
title: iOS から UWP への移行
ms.assetid: 7a05751d-02df-4240-9ba5-d95f65a7a9c5
ms.author: stwhi
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: c769876b13eede84a776676aed69274d34e4bbbf
ms.sourcegitcommit: 3257416aebb5a7b1515e107866806f8bd57845a8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/17/2018
ms.locfileid: "7151094"
---
# <a name="move-from-ios-to-uwp"></a>iOS から UWP への移行

ユーザー ベースを Windows 10 とユニバーサル Windows プラットフォーム (UWP) にまで拡大する方法に悩んでいる iOS 開発者向けに、便利なツールが提供されています。そしてその数は日々増え続けています。 どの方法を使うかは、対象のアプリの種類 (ゲーム、ライフ スタイル、エンタープライズなど) と、開発プロセスにどれだけ関与できるかに応じて異なります。 たとえば、OpenGL または Cocos2D に大きく依存している完成済みのゲームまたはほぼ完成しているゲームの場合は、[iOS 用 Windows ブリッジ](https://dev.windows.com/bridges/ios)が有力な候補になります。また、スモール ビジネス用のクロスプラットフォーム アプリを計画している場合は、[Xamarin.Forms](https://www.xamarin.com/forms) の使用を検討する必要があります。 Unity などのクロスプラットフォーム ツールでアプリを記述している場合は、[Windows に公開](http://blogs.unity3d.com/2015/09/09/windows-10-universal-apps-in-unity-5-2/)するのが簡単です。

## <a name="why-windows"></a>Windows を選ぶ理由

今日は、Windows は膨大な数のデバイスで実行されています。 UWP は、デスクトップ コンピューター、ゲーム コンソール、ホログラフィック ディスプレイなどのさまざまなデバイス間で美しく応答性に優れたユーザー インターフェイスを作るように設計された最新の API のセットを開発者に提供します。 1 つの Visual Studio ソリューションと、複数のプラットフォームに自動的に最適化されるスマートなユーザー インターフェイス コントロールにより、より少ないコードで記述したアプリをより多くのハードウェア上で実行できます。

> [!VIDEO https://channel9.msdn.com/Blogs/One-Dev-Minute/How-to-Convert-your-iOS-app-to-Windows/player]

| トピック | 説明 |
|-------|-------------|
| [iOS と UWP のアプリ開発方法の選択](selecting-an-approach-to-ios-and-uwp-app-development.md) | クロスプラットフォーム アプリを開発するときの選択肢 |
| [iOS 開発者のための UWP の概要](getting-started-with-uwp-for-ios-developers.md) | この記事は、Windows 10 用の開発を検討している iOS 開発者向けに用意されています。 |
| [Windows 10 を使用するための Mac のセットアップ](setting-up-your-mac-with-windows-10.md) | 現在の Mac コンピューターを使用して、Windows 用アプリを開発します。 |

## <a name="related-topics"></a>関連トピック

**設計者と開発者向け**
* [すべての Windows デバイスを対象としたユニバーサル Windows アプリの構築](http://go.microsoft.com/fwlink/p/?LinkID=397871)
* [UWP アプリの設計アセットのダウンロード](https://msdn.microsoft.com/library/windows/apps/xaml/bg125377.aspx)
