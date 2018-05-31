---
author: stevewhims
ms.assetid: ba2ac5f5-1e0d-4f1d-a6f8-6a65b4cff501
description: ここでは、既存のアプリをユニバーサル Windows プラットフォーム (UWP) に移行する方法について説明します。UWP で 1 つの Windows 10 アプリ パッケージを作成するだけで、ユーザーはすべての種類のデバイスにそのアプリをインストールすることができます。 アプリは、魅力的な新しいハードウェア、大きな収益を得るチャンス、最新の API セット、アダプティブ UI コントロール、およびマウス、キーボード、タッチ、音声などの幅広い入力形式を活用できます。
title: Windows 10 へのアプリの移植
ms.author: stwhi
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 8057bd4efcf1d7bfdc704f6217915fac6a019386
ms.sourcegitcommit: 91511d2d1dc8ab74b566aaeab3ef2139e7ed4945
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/30/2018
ms.locfileid: "1815577"
---
# <a name="porting-apps-to-windows-10"></a>Windows 10 へのアプリの移植


ここでは、既存のアプリをユニバーサル Windows プラットフォーム (UWP) に移行する方法について説明します。UWP で 1 つの Windows 10 アプリ パッケージを作成するだけで、ユーザーはすべての種類のデバイスにそのアプリをインストールすることができます。 アプリは、魅力的な新しいハードウェア、大きな収益を得るチャンス、最新の API セット、アダプティブ UI コントロール、およびマウス、キーボード、タッチ、音声などの幅広い入力形式を活用できます。

Windows ランタイム (WinRT) は、ユニバーサル Windows プラットフォーム (UWP) アプリを構築できるテクノロジです。 WinRT および UWP アプリの背景知識について詳しくは、「[ユニバーサル Windows プラットフォーム (UWP) アプリとは](https://msdn.microsoft.com/library/windows/apps/dn726767)」をご覧ください。

この移植ガイドでは、現在のアプリのテクノロジとユニバーサル Windows プラットフォーム (UWP) の違いについて説明します。 テクノロジ間のパスが理解できれば、デベロッパー センターの以降のリソースに進むことができます。これは、UWP アプリを開発するための包括的なリソースです。 このためには、準備ができたらまず「[ストア アプリの開発方法](https://msdn.microsoft.com/library/windows/apps/dn726537)」を参照することをお勧めします。

| トピック | 説明 |
|-------|-------------|
| [Windows Phone Silverlight から UWP への移行](wpsl-to-uwp-root.md) | Windows Phone Silverlight アプリの開発者は、Windows 10 への移行で、自身のスキル セットとソース コードを十分に活用できます。 Windows 10 では、UWP アプリを作成できます。これは、どのような種類のデバイスにでもインストールできる単一のアプリ パッケージです。 |
| [Windows ランタイム 8.x から UWP への移行](w8x-to-uwp-root.md) | ユニバーサル 8.1 アプリがある場合は、その対象が、Windows 8.1 と Windows Phone 8.1 のいずれかであるか、両方であるかにかかわらず、ソース コードとスキルがスムーズに Windows 10 に移植されることがわかるでしょう。 Windows 10 では、UWP アプリを作成できます。これは、どのような種類のデバイスにでもインストールできる単一のアプリ パッケージです。 |
| [Android と iOS 開発者向けの Windows アプリ概念マッピング](android-ios-uwp-map.md) | このリソースには、Android や iOS のスキルとコードを持つ開発者が Windows 10 とユニバーサル Windows プラットフォームに移行する場合に、それら 3 つのプラットフォーム間でプラットフォームの機能と知識を関連付けるために必要なすべての情報が含まれています。 |
| [iOS から UWP への移行](ios-to-uwp-root.md) | iOS 向けに開発したアプリを Windows 10 と UWP に移行するにはどうすればよいでしょうか。 これは思っているほど難しくはありません。 iOS デバイスと同様に Windows でも (おそらくより快適に) 動作する優れたアプリの作成に必要なツール、手法、情報が用意されています。 |
| [デスクトップから UWP への移行](desktop-to-uwp-root.md) | Win32 および .NET 4.6.1 デスクトップ アプリケーションをユニバーサル Windows プラットフォーム (UWP) アプリに変換します。 |
| [Web アプリを PWA に変換する](https://docs.microsoft.com/microsoft-edge/progressive-web-apps) | Web アプリをプログレッシブ Web アプリ (PWA) 変換できるようになりました。PWA は、UWP を含むあらゆるプラットフォームで動作します。 [PWA ビルダー ツール](https://www.pwabuilder.com)により、必要なマニフェストが自動的に生成されます。 これは、ホスト型 Web アプリ (HWA) ブリッジを置き換えるものです。 |

## <a name="related-topics"></a>関連トピック

* [WPF と Silverlight から WinRT への移行](https://msdn.microsoft.com/library/windows/apps/dn263237)
* [Android から WinRT への移行](https://msdn.microsoft.com/library/windows/apps/jj945421)
* [Web から WinRT への移行](https://msdn.microsoft.com/library/windows/apps/hh465151)
