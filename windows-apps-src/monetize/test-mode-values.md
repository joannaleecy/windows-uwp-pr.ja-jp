---
author: mcleanbyron
ms.assetid: 2ed21281-f996-402d-a968-d1320a4691df
description: "この記事に示されているテスト用のアプリケーション ID と広告ユニット ID の値を使って、テスト時にアプリでどのように広告がレンダリングされるかを確認します。"
title: "テスト モードの値"
translationtype: Human Translation
ms.sourcegitcommit: 2b5dbf872dd7aad48373f6a6df3dffbcbaee8090
ms.openlocfilehash: dcc83c3d654cfb290981f27ec2923fd3b37c5a8f

---

# <a name="test-mode-values"></a>テスト モードの値

[AdControl](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.adcontrol.aspx) または [InterstitialAd](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.interstitialad.aspx) を使ってアプリで広告を表示する場合、アプリケーション ID と広告ユニット ID を指定する必要があります。 アプリを開発しているときには、この記事に示されているテスト用のアプリケーション ID と広告ユニット ID の値を使って、テスト時にアプリでどのように広告がレンダリングされるかを確認します。


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


> **重要**&nbsp;&nbsp;ライブ広告のサイズは、**AdControl** の **Width** プロパティと **Height** プロパティによって定義されます。 最善の結果を得るには、コード内の **Width** プロパティと **Height** プロパティが、[バナー広告でサポートされている広告サイズ](supported-ad-sizes-for-banner-ads.md)のいずれかであることを確認します。 **Width** プロパティと **Height** プロパティは、ライブ広告のサイズに基づいて変更されません。



 

 



<!--HONumber=Dec16_HO2-->


