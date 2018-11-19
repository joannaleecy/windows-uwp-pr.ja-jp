---
author: stevewhims
ms.assetid: ba2ac5f5-1e0d-4f1d-a6f8-6a65b4cff501
description: このセクションでは、既存のすべての種類のデバイスにインストールできる 1 つの windows 10 アプリ パッケージを作成するユニバーサル Windows プラットフォーム (UWP) にアプリを移植する方法について説明します。 アプリは、魅力的な新しいハードウェア、大きな収益を得るチャンス、最新の API セット、アダプティブ UI コントロール、およびマウス、キーボード、タッチ、音声などの幅広い入力形式を活用できます。
title: Windows 10 にアプリを移植
ms.author: stwhi
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: bb5c6ae373e4e35e640223fe08a5a49f2e7a5dd3
ms.sourcegitcommit: ed0304b8a214c03b8aab74b8ef12c9f82b8e3c5f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/19/2018
ms.locfileid: "7280946"
---
# <a name="porting-apps-to-windows10"></a>Windows 10 にアプリを移植


このセクションでは、既存のすべての種類のデバイスにインストールできる 1 つの windows 10 アプリ パッケージを作成するユニバーサル Windows プラットフォーム (UWP) にアプリを移植する方法について説明します。 アプリは、魅力的な新しいハードウェア、大きな収益を得るチャンス、最新の API セット、アダプティブ UI コントロール、およびマウス、キーボード、タッチ、音声などの幅広い入力形式を活用できます。

Windows ランタイム (WinRT) は、ユニバーサル Windows プラットフォーム (UWP) アプリを構築できるテクノロジです。 WinRT および UWP アプリの背景知識について詳しくは、「[ユニバーサル Windows プラットフォーム (UWP) アプリとは](https://msdn.microsoft.com/library/windows/apps/dn726767)」をご覧ください。

この移植ガイドでは、現在のアプリのテクノロジとユニバーサル Windows プラットフォーム (UWP) の違いについて説明します。 テクノロジ間のパスが理解できれば、デベロッパー センターの以降のリソースに進むことができます。これは、UWP アプリを開発するための包括的なリソースです。 このためには、準備ができたらまず「[ストア アプリの開発方法](https://msdn.microsoft.com/library/windows/apps/dn726537)」を参照することをお勧めします。

| トピック | 説明 |
|-------|-------------|
| [Windows Phone Silverlight から UWP への移行](wpsl-to-uwp-root.md) | Windows Phone Silverlight アプリの開発者は、Windows 10 への移行で、自身のスキル セットとソース コードを十分に活用できます。 Windows 10 では、UWP アプリを作成できます。これは、どのような種類のデバイスにでもインストールできる単一のアプリ パッケージです。 |
| [Windows ランタイム 8.x から UWP への移行](w8x-to-uwp-root.md) | ユニバーサル 8.1 アプリがある場合は、そのターゲットが Windows 8.1 と Windows Phone 8.1 のどちらかであっても、両方であっても、ソース コードとスキルをスムーズに Windows 10 に移植することができます。 Windows 10 では、UWP アプリを作成できます。これは、どのような種類のデバイスにでもインストールできる単一のアプリ パッケージです。 |
| [Android と iOS 開発者向けの Windows アプリ概念マッピング](android-ios-uwp-map.md) | このリソースには、Android や iOS のスキルとコードを持つ開発者が Windows 10 とユニバーサル Windows プラットフォームに移行する場合に、それら 3 つのプラットフォーム間でプラットフォームの機能と知識を関連付けるために必要なすべての情報が含まれています。 |
| [iOS から UWP への移行](ios-to-uwp-root.md) | iOS 向けに開発したアプリを Windows 10 と UWP に移行するにはどうすればよいでしょうか。 これは思っているほど難しくはありません。 iOS デバイスと同様に Windows でも (おそらくより快適に) 動作する優れたアプリの作成に必要なツール、手法、情報が用意されています。 |
| [デスクトップから UWP への移行](desktop-to-uwp-root.md) | Win32 および .NET 4.6.1 デスクトップ アプリケーションをユニバーサル Windows プラットフォーム (UWP) アプリに変換します。 |
| [Web アプリを PWA に変換する](https://docs.microsoft.com/microsoft-edge/progressive-web-apps) | Web アプリをプログレッシブ Web アプリ (PWA) 変換できるようになりました。PWA は、UWP を含むあらゆるプラットフォームで動作します。 [PWA ビルダー ツール](https://www.pwabuilder.com)により、必要なマニフェストが自動的に生成されます。 これは、ホスト型 Web アプリ (HWA) ブリッジを置き換えるものです。 |

## <a name="related-topics"></a>関連トピック

* [WPF と Silverlight から WinRT への移行](https://msdn.microsoft.com/library/windows/apps/dn263237)
* [Android から WinRT への移行](https://msdn.microsoft.com/library/windows/apps/jj945421)
* [Web から WinRT への移行](https://msdn.microsoft.com/library/windows/apps/hh465151)
