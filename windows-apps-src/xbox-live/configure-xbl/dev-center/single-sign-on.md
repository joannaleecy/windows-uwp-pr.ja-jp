---
title: デベロッパー センターでのシングル サインオンの構成
author: KevinAsgari
description: タイトルがユーザーの Xbox Live ID を使ってユーザーをサービスにサインインさせることができるように、デベロッパー センターでシングル サインオンを構成する方法について説明します。
ms.assetid: ''
ms.author: kevinasg
ms.date: 02/21/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
ms.localizationpriority: medium
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, UDC, ユニバーサル デベロッパー センター, シングル サインオン
ms.openlocfilehash: 7c23ace80f18d7d5fa7fdbf2c562436b998516f5
ms.sourcegitcommit: 1938851dc132c60348f9722daf994b86f2ead09e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/03/2018
ms.locfileid: "4267454"
---
# <a name="configure-single-sign-on-in-dev-center"></a>デベロッパー センターでのシングル サインオンの構成

シングル サインオンを使うと、タイトルを利用するプレイヤーが自分の Xbox Live サインインを使ってサービスにサインインできます。 これにより、Xbox Live にサインインしているプレイヤーが、サービスに固有の異なるアカウント資格情報を使ってもう一度ログインしなくても、サービスのアプリやゲームを実行できるようになります。

> [!NOTE]
> このトピックは、Xbox Live クリエーターズ プログラムのタイトルには適用されません。

たとえば、サービスの有効なアカウントを持っていれば、サービスがデバイスにコンテンツ (ビデオや音楽など) をストリーミングすることを可能にするアプリなどのタイトルがあります。 ユーザーが自分の Xbox Live アカウントにログインしている場合、毎回サービスにサインインしなくてもコンテンツをストリーミングできる必要があります。

また、アプリが Kinect データを外部サービスに送信する場合も、ここで構成できます。

Xbox Live とは別のアカウントを作成することをサービスがユーザーに求めている場合、ユーザーが 1 回限りの操作で自分の Xbox Live アカウントをサービスのアカウントとリンクする手段を用意してください。

シングル サインオンを構成するときは、URL と証明書利用者を指定できます。 アプリが指定された URL のいずれかを呼び出すと必ず、Xbox Live は Xbox Secure Token Service (XSTS) トークンを自動的にアタッチします。 キーを受け取るサービスは*証明書利用者*と呼ばれ、シングル サインオンを構成する前に[証明書利用者](https://developer.microsoft.com/en-US/xboxconfig/relyingparties/index)を構成する必要があります。 各証明書利用者構成では、XSTS トークンに含まれている情報と、証明書利用者が XSTS トークンのデコードに使用できる一意の暗号化キーを指定します。

次の手順に従って、構成を追加します。

1. [デベロッパー センター](https://developer.microsoft.com/dashboard/windows/overview)でタイトルを選択したら、**[サービス]** > **[Xbox Live]** に移動します。

2. **Xbox Live シングル サインオン**へのリンクをクリックします。

3. **[URL の追加]** をクリックし、新しいシングル サインオン エントリを作成します。 構成の一覧の最後に新しい行が追加されます。

4. [URL] ボックスに、完全修飾ドメイン名を使ってサービスの URL を入力します。 最下位レベルのサブドメインは、ワイルドカード文字 ('\*') に置き換えることができます。 これは、同じ上位レベルのドメインを持つあらゆる URL にマッチングします。 たとえば、"*.example.com&quot; は "bar.example.com" や "foo.bar.example.com" にマッチングします。

5. [証明書利用者] ボックスで、XSTS トークンをエンコードする方法を指定する証明書利用者構成を選択します。

6. **[保存]** をクリックして、変更を保存します。

![シングル サインオンの構成ページのスクリーンショット](../../images/dev-center/single-signon.png)
