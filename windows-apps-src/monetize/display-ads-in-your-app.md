---
author: mcleanbyron
ms.assetid: 63A9EDCF-A418-476C-8677-D8770B45D1D7
description: "Microsoft Store Services SDK は、アプリに広告を表示して収益を得るためのいくつかの方法を提供します。"
title: "アプリでの広告の表示"
translationtype: Human Translation
ms.sourcegitcommit: 2f0835638f330de0ac2d17dae28347686cc7ed97
ms.openlocfilehash: 35dfe2864958a15cf01133d6017b7dd03f382e4a

---

# アプリでの広告の表示


ユニバーサル Windows プラットフォーム (UWP) と Windows ストアは、アプリに広告を表示して収益を得るためのいくつかの方法を提供します。

## Microsoft Advertising ライブラリを使用したバナーおよびビデオのスポット広告の表示

UWP アプリと Windows 8.1 および Windows Phone 8.x 用のアプリに、バナーやビデオのスポット広告を含めることにより、収益を増やすことができます。 広告は、PC、タブレット、電話用の Windows アプリに表示されます。 Windows デベロッパー センターのダッシュボードの [広告パフォーマンス レポート](../publish/advertising-performance-report.md) を使って、広告のパフォーマンスをリアルタイムで監視できます。

アプリにこれらの広告を含めるには、[Microsoft Store Services SDK](http://aka.ms/store-em-sdk) (UWP アプリ 用) と [Windows および Windows Phone 8.x 用の Microsoft Advertising SDK](http://aka.ms/store-8-sdk) (Windows 8.1とWindows Phone 8.x アプリ用) で配布されている、Advertising ライブラリの **AdControl** と** InterstitialAd** コントロールを使用します。


次のトピックでは、Windows Advertising ライブラリに関連する一般的なタスクに関する情報を提供します。

|  タスク    | トピック |               
|----------|-------|
| Microsoft Advertising ライブラリのインストールを行い、使用を開始します。     | 「[Microsoft Advertising ライブラリの概要](get-started-with-microsoft-advertising-libraries.md)」をご覧ください。        |
| XAML/C# アプリでバナー広告を表示します。     | 「[XAML および .NET の AdControl](adcontrol-in-xaml-and--net.md)」をご覧ください。        |
| HTML/JavaScript アプリでバナー広告を表示します。     | 「[HTML 5 および Javascript の AdControl](adcontrol-in-html-5-and-javascript.md)」をご覧ください。        |
| Windows Phone Silverlight 8.x アプリにバナー広告を表示します。     | 「[Windows Phone Silverlight の AdControl](adcontrol-in-windows-phone-silverlight.md)」をご覧ください。        |
| アプリにビデオのスポット広告を表示します。     | 「[スポット広告](interstitial-ads.md)」をご覧ください。       |
| JavaScript と HTML を使って記述されたユニバーサル Windows プラットフォーム (UWP) アプリで、ビデオ コンテンツに広告を追加します。   |  「[HTML 5 および JavaScript によるビデオ コンテンツへの広告の追加](add-advertisements-to-video-content.md)」をご覧ください。  |
| バナーやスポット広告をアプリに追加する方法を説明するサンプル プロジェクトをダウンロードします。     |「[GitHub の広告サンプル](http://aka.ms/githubads)」をご覧ください。       |
| アプリの [AdControl](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.adcontrol.aspx) エラーに対処します。     | 「[エラー処理](error-handling-with-advertising-libraries.md)」および「[AdControl エラー処理](adcontrol-error-handling.md)」のウォークスルーをご覧ください。       |
| Microsoft Advertising ライブラリのバグを報告します。     | [サポート ページ](https://go.microsoft.com/fwlink/p/?LinkId=331508)をご覧ください。        |
| コミュニティ サポートを受けます。     | [フォーラム](http://go.microsoft.com/fwlink/p/?LinkId=401266)をご覧ください。       |

                            

## バナー広告での広告仲介の使用 (Windows 8.1 と Windows Phone 8.x)

Windows 8.1 および Windows Phone 8.x 用アプリで **AdMediatorControl** クラスを使うことで、複数の広告ネットワークからバナー広告を表示して広告の収益を最適化できます。 このコントロールをアプリに追加した後に、Windows デベロッパー センター ダッシュボードで広告仲介の設定を構成すると、選択した広告ネットワークからのバナー広告要求の仲介が行われます。 詳しくは、「[広告仲介を追加して広告収益を最大限に高める](https://msdn.microsoft.com/library/windows/apps/xaml/dn864359.aspx)」をご覧ください。

>**注**&nbsp;&nbsp;**AdMediatorControl** クラスを使用した広告の仲介は、Windows 10 用の UWP アプリでは現在サポートされていません。 * サーバー側の広告仲介は、UWP アプリ で間もなく利用可能になる予定です。この場合、バナー広告 (**AdControl**) とビデオ スポット広告 (**InterstitialAd**) には同じ API が使用されます。 UWP アプリ での **AdMediatorControl** から **AdControl** への移行に関するガイダンスについては、「[UWP アプリでAdControlにAdMediatorControlから移行](migrate-from-admediatorcontrol-to-adcontrol.md)」をご覧ください。

<span id="silverlight_support"/>
## Windows Phone 8.x Silverlight プロジェクト用の広告のサポート

Windows Phone 8.x Silverlight プロジェクトでのいくつかの開発者シナリオは、サポートされません。 詳しくは、次の表をご覧ください。

|  プラットフォームのバージョン  |  既存のプロジェクト    |   新しいプロジェクト  |
|-----------------|----------------|--------------|
| Windows Phone 8.0 Silverlight     |  Microsoft ユニバーサル広告クライアント SDK または Microsoft Advertising SDK の以前のリリースの **AdControl** または **AdMediatorControl** を使用している既存の Windows Phone 8.0 Silverlight プロジェクトがあり、アプリが既に Windows ストアで公開されている場合、プロジェクトの変更とリビルドを行い、デバイスで変更のデバッグまたはテストを行うことができます。 エミュレーターでのプロジェクトのデバッグまたはテストはサポートされません。  |  サポートされません。  |
| Windows Phone 8.1 Silverlight    |  以前の SDK の **AdControl** または **AdMediatorControl** を使用している既存の Windows Phone 8.1 Silverlight プロジェクトがある場合、プロジェクトの変更とリビルドを行うことができます。 ただし、アプリをテストまたはデバッグするには、エミュレーターでアプリを実行し、アプリケーション ID と広告ユニット ID に[テスト モードの値](test-mode-values.md)を使用する必要があります。 デバイス上でのアプリのデバッグやテストはサポートされません。  |   新しい Windows Phone 8.1 Silverlight プロジェクトに **AdControl** または **AdMediatorControl** を追加することができます。 ただし、アプリをテストまたはデバッグするには、エミュレーターでアプリを実行し、アプリケーション ID と広告ユニット ID に[テスト モードの値](test-mode-values.md)を使用する必要があります。 デバイス上でのアプリのデバッグやテストはサポートされません。 |

## 関連トピック

* [Microsoft Store Services SDK](microsoft-store-services-sdk.md)
* [広告によるアプリの収益の獲得](http://go.microsoft.com/fwlink/p/?LinkId=699559)
* [広告パフォーマンス レポート](../publish/advertising-performance-report.md)



<!--HONumber=Sep16_HO2-->


