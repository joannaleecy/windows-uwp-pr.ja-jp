---
author: mcleanbyron
ms.assetid: bb105fbe-bbbd-4d78-899b-345af2757720
description: アプリをストアに提出する前に、Windows デベロッパー センター ダッシュ ボードからアプリケーション ID と広告ユニット ID の値をアプリに追加する方法について説明します。
title: アプリの広告ユニットをセットアップする

---

# アプリの広告ユニットをセットアップする


\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]

[AdControl](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.adcontrol.aspx) または [InterstitialAd](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.interstitialad.aspx) を使ってアプリで広告を表示する場合、アプリケーション ID と広告ユニット ID を指定する必要があります。 アプリを開発しているときには、適切な[テスト用のアプリケーション ID と広告ユニット ID の値](test-mode-values.md)を使って、テスト時にアプリでどのように広告がレンダリングされるかを確認します。

アプリのテストが終了し、Windows デベロッパー センターに提出する準備ができたら、[Windows デベロッパー センター ダッシュ ボード](https://msdn.microsoft.com/library/windows/apps/mt170658.aspx)から取得したアプリケーション ID と広告ユニット ID の値を使用するように、アプリのコードを更新する必要があります。 ライブ アプリでテスト用の値を使うと、アプリでライブ広告は表示されません。

ライブ アプリのアプリケーション ID と広告ユニットをセットアップするには

1.  Windows デベロッパー センター ダッシュボードで、アプリを選択し、**[収益化]、[広告で収入を増やす]** の順にクリックします。
2.  このページの **[Microsoft Advertising 広告ユニット]** セクションで広告ユニットを作成します。 広告ユニットの種類として、**AdControl** を使っている場合は **[バナー]** を、**InterstitialAd** を使っている場合は **[ビデオ (スポット)]** を選びます。 このページについて詳しくは、「[広告で収入を増やす](../publish/monetize-with-ads.md)」をご覧ください。

3.  生成された広告ユニットごとに、**アプリケーション ID** と**広告ユニット ID** がこのページに表示されます。 アプリに広告を表示するには、アプリのコードでこれらの値を使う必要があります。

    * アプリにバナー広告を表示する場合は、これらの値を **AdControl** オブジェクトの **ApplicationId** プロパティと **AdUnitId** プロパティに割り当てる必要があります。

    * アプリでスポット広告ビデオを表示する場合は、**InterstitialAd** オブジェクトの **RequestAd** メソッドにこれらの値を渡します。

> **重要**   アプリで広告の仲介を使って Microsoft からバナー広告を表示する (つまり、**AdMediatorControl** オブジェクトを使う) 場合は、広告ユニットを要求する必要はありません。 このシナリオでは、広告ユニットが自動的に生成されます。 詳しくは、「[AdMediatorControl と AdControl の違い](what-is-the-difference-admediatorcontrol-or-adcontrol.md)」をご覧ください。

 

## 関連トピック

[テスト モードの値](test-mode-values.md)


 

 


<!--HONumber=May16_HO2-->


