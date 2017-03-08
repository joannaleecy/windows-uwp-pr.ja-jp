---
author: mcleanbyron
ms.assetid: bb105fbe-bbbd-4d78-899b-345af2757720
description: "アプリをストアに提出する前に、Windows デベロッパー センター ダッシュ ボードからアプリケーション ID と広告ユニット ID の値をアプリに追加する方法について説明します。"
title: "アプリの広告ユニットをセットアップする"
ms.author: mcleans
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, 広告, Advertising, 広告ユニット"
translationtype: Human Translation
ms.sourcegitcommit: c6b64cff1bbebc8ba69bc6e03d34b69f85e798fc
ms.openlocfilehash: 32a934f1d113d561c72ab3ac48a8ef3d0820c176
ms.lasthandoff: 02/07/2017

---

# <a name="set-up-ad-units-in-your-app"></a>アプリの広告ユニットをセットアップする




[AdControl](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.adcontrol.aspx) または [InterstitialAd](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.interstitialad.aspx) を使ってアプリで広告を表示する場合、アプリケーション ID と広告ユニット ID を指定する必要があります。 アプリを開発しているときには、適切な[テスト用のアプリケーション ID と広告ユニット ID の値](test-mode-values.md)を使って、テスト時にアプリでどのように広告がレンダリングされるかを確認します。

アプリのテストが終了し、Windows デベロッパー センターに提出する準備ができたら、[Windows デベロッパー センター ダッシュ ボード](https://msdn.microsoft.com/library/windows/apps/mt170658.aspx)から取得したアプリケーション ID と広告ユニット ID の値を使用するように、アプリのコードを更新する必要があります。 ライブ アプリでテスト用の値を使うと、アプリでライブ広告は表示されません。

ライブ アプリのアプリケーション ID と広告ユニットをセットアップするには

1.  Windows デベロッパー センター ダッシュボードで、アプリを選択し、**[収益化]、[広告で収入を増やす]** の順にクリックします。
2.  このページの **[Microsoft Advertising 広告ユニット]** セクションで広告ユニットを作成します。 広告ユニットの種類として、**AdControl** を使っている場合は **[バナー]** を、**InterstitialAd** を使っている場合は **[ビデオ (スポット)]** を選びます。 このページについて詳しくは、「[広告で収入を増やす](../publish/monetize-with-ads.md)」をご覧ください。

3.  生成された広告ユニットごとに、**アプリケーション ID** と**広告ユニット ID** がこのページに表示されます。 アプリに広告を表示するには、アプリのコードでこれらの値を使う必要があります。

    * アプリにバナー広告を表示する場合は、これらの値を **AdControl** オブジェクトの **ApplicationId** プロパティと **AdUnitId** プロパティに割り当てる必要があります。

    * アプリでスポット広告ビデオを表示する場合は、**InterstitialAd** オブジェクトの **RequestAd** メソッドにこれらの値を渡します。

 

## <a name="related-topics"></a>関連トピック

[テスト モードの値](test-mode-values.md)


 

 

