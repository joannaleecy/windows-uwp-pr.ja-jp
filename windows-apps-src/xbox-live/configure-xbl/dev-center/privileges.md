---
title: パートナー センターで特権の構成
description: パートナー センターでの権限を構成する方法について説明します
ms.date: 04/09/2018
ms.topic: article
ms.localizationpriority: medium
keywords: Xbox Live、Xbox、ゲーム、uwp、windows 10 では、1 つ Xbox、特権、パートナー センター
ms.openlocfilehash: 2036be2a6184909799236b013c52ff4614a158aa
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57612477"
---
# <a name="configure-privileges-in-partner-center"></a>パートナー センターでの特権を構成します。

特権の構成ページには、[Mixer](https://mixer.com/) などのストリーミング サービスへのタイトルのストリーミングがゲーマーに制限されるかどうかが示されます。 既定では、どのストリーミング プラットフォームでもブロードキャストが制限されません。このページは、ブロードキャストを制限する場合のみ変更してください。 ブロードキャストは、2 つの方法で制限できます。 **[Default]** (既定値) セクションのチェック ボックスをオンにすることであらゆるプラットフォームでブロードキャストを無効にするか、**[Sandbox overrides]** (サンドボックス オーバーライド) セクションでサンドボックスを追加することでサンドボックスによるブロードキャストを制限できます。

**[Default]** (既定値) セクションのチェック ボックスをオンにすると、すべてのサービスとサンドボックスでこのタイトルのブロードキャストが制限されます。

![既定のブロードキャストの制限](../../images/dev-center/privileges/default-privileges-check.JPG)

特定のサンドボックスでのブロードキャストを制限するには、**[Sandbox overrides]** (サンドボックス オーバーライド) セクションの **[追加]** をクリックします。 ドロップダウン リストからターゲット サンドボックスを選び、下のボックスをオンにして、そのタイトルのブロードキャストを選んだサンドボックスに制限します。 サンドボックス オーバーライドをオフまたは削除すると、ブロードキャストの制限を削除できます。

![サンドボックスのブロードキャストの制限](../../images/dev-center/privileges/sandbox-privileges-check.JPG)

**[保存]** をクリックし、これらの設定の構成変更を保存します。

> [!NOTE]
> ブロードキャストを無効にするチェック ボックスをオンにすると、Xbox 本体または PC の Windows ゲームを使ったストリーミングのみ禁止されます。 このページにあるチェック ボックスをオンにしても、キャプチャ カードや他の外部のキャプチャまたはストリーミング サービスを使うことはできません。