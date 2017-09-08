---
title: "XDP での Achievements 2017"
author: KevinAsgari
description: Achievements 2017
ms.assetid: d424db04-328d-470c-81d3-5d4b82cb792f
ms.author: kevinasg
ms.date: 04-04-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One"
ms.openlocfilehash: fccd7008cb092636abc2da37761d2fde817e27bb
ms.sourcegitcommit: a9e4be98688b3a6125fd5dd126190fcfcd764f95
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/21/2017
---
# <a name="configure-achievements-2017-on-xdp"></a>XDP での Achievements 2017 の構成

Achievements 2017 システムで必要な構成は、名前、ロック/ロック解除の説明、表示イメージ、リワード情報だけです (注意: 有効な実績リワード: ゲーマースコア、アート リワード、ゲーム内リワード)。

<span id="_Enable_Simplified_Achievements" class="anchor"></span>

## <a name="enable-achievements-2017"></a>Achievements 2017 の有効化

タイトルで使用される実績システムは、製品レベルで管理されます。  

デベロッパーは、RETAIL に公開する前にいつでも、製品で簡易版実績システムとクラウド版実績システムのどちらを使うかを切り替えることができます。 いずれかの方向に実績システムを切り替えると、タイトルで構成および公開されているすべての実績 (および該当する場合はチャレンジ) が、すべてのサンドボックスから削除されます。 

タイトルのサービス構成を RETAIL に公開した後は、実績システムは永続的に設定され、変更することはできません。 **例外を設けることはできません。 これは、技術とポリシーの両方の理由で必要です。**

1.  XDP でプロダクトのページから **[Product Setup]** に移動します。
![](../images/omega/simplified-achievements-1.png)

2.  **[Product Details]** を選択します。
![](../images/omega/simplified-achievements-2.png)

1.  **[Achievements configuration system]** トグルを [*Achievements 2017*] に切り替えます。
![](../images/omega/simplified-achievements-2.png)

1.  すべてのサンドボックスでタイトルのすべての実績が削除されることを伝える警告が表示されます。 すべてのサンドボックスの既存の実績が削除されても問題ない場合は、**[Save]** をクリックします。
![](../images/omega/simplified-achievements-4.png)

## <a name="configure-an-achievement"></a>実績の構成

1.  タイトルに対して Achievements 2017 を有効にします。

2.  **[Service Configuration]** に移動して **[Achievements]** を選択します。
![](../images/omega/simplified-achievements-5.png)

1.  実績表示の詳細を入力します。

    *注意: これらの文字列は XDP UI での表示に使用されます。 ユーザーに対して表示される最終的な文字列は、[Localized Strings] サービス構成オプション (手順 5) で構成する必要があります。*<br>
![](../images/omega/simplified-achievements-6.png)

1.  実績にゲーマースコア、アートワーク、アプリ内リワードを追加するには、**[Rewards]** セクションの **[New]** をクリックします。
![](../images/omega/simplified-achievements-7.png)

1.  実績の名前と説明にローカライズされた文字列を提供する場合は、**[Localized Strings]** に移動します。

    *注意: 英語にローカライズした文字列を必ず定義してください。 そうしないと、米国以外のユーザーが英語のテキストを選択したときに正しく表示されません。*<br>
![](../images/omega/simplified-achievements-8.png)

1.  最近行った変更を、現在公開されているサービス構成データと比較するには、**[Compare Data]** に移動し、比較対象のサンドボックスを選択します。
![](../images/omega/simplified-achievements-9.png)

1.  開発サンドボックスでの公開とテストの準備ができたら、**[Service Configuration]** に戻って **[Publish]** ボタンをクリックします。
![](../images/omega/simplified-achievements-10.png)

1.  テスト対象のサンドボックスを選択します (通常は、実績のドラフトを作成したものと同じサンドボックス)。

    [Service Configuration] の *[Events, Stat Rules, Achievements…]* チェック ボックスを オンにします。

    **[Submit]** をクリックします。

![](../images/omega/simplified-achievements-11.png)