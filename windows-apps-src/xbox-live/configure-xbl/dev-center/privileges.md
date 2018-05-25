---
title: デベロッパー センターでの特権の構成
author: aablackm
description: Windows デベロッパー センターで特権を構成する方法について説明します。
ms.author: aablackm
ms.date: 04/09/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
ms.localizationpriority: low
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, 特権, Windows デベロッパー センター
ms.openlocfilehash: 77b779bfd4ffcbff31267e93c9475948825a2b00
ms.sourcegitcommit: 91511d2d1dc8ab74b566aaeab3ef2139e7ed4945
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/30/2018
---
# <a name="configure-privileges-on-windows-development-center"></a>Windows デベロッパー センターでの特権の構成

特権の構成ページには、[Mixer](https://mixer.com/) などのストリーミング サービスへのタイトルのストリーミングがゲーマーに制限されるかどうかが示されます。 既定では、どのストリーミング プラットフォームでもブロードキャストが制限されません。このページは、ブロードキャストを制限する場合のみ変更してください。 ブロードキャストは、2 つの方法で制限できます。 **[Default]** (既定値) セクションのチェック ボックスをオンにすることであらゆるプラットフォームでブロードキャストを無効にするか、**[Sandbox overrides]** (サンドボックス オーバーライド) セクションでサンドボックスを追加することでサンドボックスによるブロードキャストを制限できます。

**[Default]** (既定値) セクションのチェック ボックスをオンにすると、すべてのサービスとサンドボックスでこのタイトルのブロードキャストが制限されます。

![既定のブロードキャストの制限](../../images/dev-center/privileges/default-privileges-check.JPG)

特定のサンドボックスでのブロードキャストを制限するには、**[Sandbox overrides]** (サンドボックス オーバーライド) セクションの **[追加]** をクリックします。 ドロップダウン リストからターゲット サンドボックスを選び、下のボックスをオンにして、そのタイトルのブロードキャストを選んだサンドボックスに制限します。 サンドボックス オーバーライドをオフまたは削除すると、ブロードキャストの制限を削除できます。

![サンドボックスのブロードキャストの制限](../../images/dev-center/privileges/sandbox-privileges-check.JPG)

**[保存]** をクリックし、これらの設定の構成変更を保存します。

> [!NOTE]
> ブロードキャストを無効にするチェック ボックスをオンにすると、Xbox 本体または PC の Windows ゲームを使ったストリーミングのみ禁止されます。 このページにあるチェック ボックスをオンにしても、キャプチャ カードや他の外部のキャプチャまたはストリーミング サービスを使うことはできません。