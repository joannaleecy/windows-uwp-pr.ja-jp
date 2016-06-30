---
author: mcleanbyron
ms.assetid: 2ed21281-f996-402d-a968-d1320a4691df
description: "この記事に示されているテスト用のアプリケーション ID と広告ユニット ID の値を使って、テスト時にアプリでどのように広告がレンダリングされるかを確認します。"
title: "テスト モードの値"
translationtype: Human Translation
ms.sourcegitcommit: cf695b5c20378f7bbadafb5b98cdd3327bcb0be6
ms.openlocfilehash: 93b20954ba82b613bde96db30a000902dec3b844

---

# テスト モードの値


\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]

[AdControl](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.adcontrol.aspx) または [InterstitialAd](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.interstitialad.aspx) を使ってアプリで広告を表示する場合、アプリケーション ID と広告ユニット ID を指定する必要があります。 アプリを開発しているときには、この記事に示されているテスト用のアプリケーション ID と広告ユニット ID の値を使って、テスト時にアプリでどのように広告がレンダリングされるかを確認します。

> **重要**   アプリで広告の仲介を使う (つまり、**AdMediatorControl** オブジェクトを使う) 場合は、広告ユニットを指定する必要はありません。 このシナリオでは、広告ユニットが自動的に生成されます。 詳しくは、「[AdMediatorControl と AdControl の違い](what-is-the-difference-admediatorcontrol-or-adcontrol.md)」をご覧ください。

いったん公開したアプリでテスト用の値を使うと、ライブ アプリで広告は表示されません。 公開されたアプリで広告を表示するには、Windows デベロッパー センター ダッシュ ボードで提供されたアプリケーション ID と広告ユニット ID の値を使用するように、コードを更新する必要があります。 詳しくは、「[アプリで広告ユニットをセットアップする](set-up-ad-units-in-your-app.md)」をご覧ください。
 

スポット広告ビデオやバナー広告を使用するためのテスト用の値を以下に示します。

* スポット広告ビデオの場合:

    <table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <thead>
    <tr class="header">
    <th align="left">AdUnitId</th>
    <th align="left">AppId</th>
    </tr>
    </thead>
    <tbody>
    <tr class="odd">
    <td align="left"><p>11389925</p></td>
    <td align="left"><p>d25517cb-12d4-4699-8bdc-52040c712cab</p></td>
    </tr>
    </tbody>
    </table>

     
* バナー広告の場合:

    <table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <thead>
    <tr class="header">
    <th align="left">AdUnitId</th>
    <th align="left">AppId</th>
    </tr>
    </thead>
    <tbody>
    <tr class="odd">
    <td align="left"><p>10865270</p></td>
    <td align="left"><p>3f83fe91-d6be-434d-a0ae-7351c5a997f1</p></td>
    </tr>
    </tbody>
    </table>


> **重要**   ライブ広告のサイズは、**AdControl** の **Width** プロパティと **Height** プロパティによって定義されます。 最善の結果を得るには、コード内の **Width** プロパティと **Height** プロパティが、[バナー広告でサポートされている広告サイズ](supported-ad-sizes-for-banner-ads.md)のいずれかであることを確認します。 **Width** プロパティと **Height** プロパティは、ライブ広告のサイズに基づいて変更されません。



 

 



<!--HONumber=Jun16_HO4-->


