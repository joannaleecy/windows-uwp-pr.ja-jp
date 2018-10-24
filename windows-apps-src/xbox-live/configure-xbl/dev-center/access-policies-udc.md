---
title: デベロッパー センターへのアクセス ポリシーを構成します。
author: KevinAsgari
description: その他のアプリ、ゲーム、およびサービスが Xbox Live の設定にアクセスできるようにするデベロッパー センターでアクセス ポリシーを構成する方法について説明します。
ms.assetid: ''
ms.author: kevinasg
ms.date: 02/21/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
ms.localizationpriority: medium
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, UDC, ユニバーサル デベロッパー センター
ms.openlocfilehash: 8a19c6e116cb6c2f3cd8e2f2d8541516ebf89de9
ms.sourcegitcommit: 4b97117d3aff38db89d560502a3c372f12bb6ed5
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/24/2018
ms.locfileid: "5433307"
---
# <a name="configure-access-policies-on-dev-center"></a>デベロッパー センターでアクセス ポリシーを構成します。

[Windows デベロッパー センター](https://developer.microsoft.com/dashboard/windows/overview)を使うと、他のサービス、ゲーム、アプリがタイトルの Xbox Live 設定とデータにアクセスすることを許可できます。 たとえば、Web サイトでのランキングを Web サービスに表示したり、ゲームのタイトル ストレージにアクセスしてセーブされたゲーム データを表示または変更できる比較アプリを作成したりすることができます。

既定では、タイトル自体のみが Xbox Live サービスに保存された設定とデータにアクセスできます。 デベロッパー センターでアクセス ポリシーを構成することによって、これを変更することができます。

> [!NOTE]
> このトピックは、Xbox Live クリエーターズ プログラムのタイトルには適用されません。

次の手順に従って、構成を追加します。

1. [デベロッパー センター](https://developer.microsoft.com/dashboard/windows/overview)でタイトルを選択したら、**[サービス]** > **[Xbox Live]** に移動します。

2. **アクセス ポリシー**へのリンクをクリックします。

3. アクセスを許可する設定をクリックし、アプリ/サービスの追加ボタンをクリックします。 その設定にアクセスできるように構成されたアプリ/サービスの一覧の下に新しい行が追加されます。

4. ドロップダウン ボックスでアプリまたはサービスの種類を選択し、詳細ボックスに入力して、データにアクセスするアプリやサービスのアプリ、タイトル ID、サービス ID を指定します。

5. アプリまたはサービスがデータを読み取るだけなのか、データにフル アクセスするのかを選択します。

6. 設定ごと、およびそれらの設定へのアクセスが必要なアプリやサービスごとに繰り返します。 **[削除]** をクリックすると配列を削除できます。

7. 作業が完了したら、**[保存]** ボタンをクリックして変更を保存します。

![アクセス ポリシーの追加のアプリまたはサービスの画面](../../images/dev-center/data-sharing-2.png)
