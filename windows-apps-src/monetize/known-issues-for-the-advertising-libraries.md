---
author: mcleanbyron
ms.assetid: 9ca1f880-2ced-46b4-8ea7-aba43d2ff863
description: Microsoft Advertising SDK の現在のリリースにおける既知の問題について説明します。
title: アプリ内広告の既知の問題とトラブルシューティング
ms.author: mcleans
ms.date: 04/16/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, 広告, Advertising, 既知の問題, トラブルシューティング
ms.localizationpriority: medium
ms.openlocfilehash: aaf2db68df9de3f397a0cbc677e18f4ed544cf4b
ms.sourcegitcommit: 91511d2d1dc8ab74b566aaeab3ef2139e7ed4945
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/30/2018
ms.locfileid: "1817533"
---
# <a name="known-issues-and-troubleshooting-for-ads-in-apps"></a>アプリ内広告の既知の問題とトラブルシューティング

このトピックでは、Microsoft Advertising SDK の現在のリリースにおける既知の問題を示します。 トラブルシューティングのガイダンスについては、以下のトピックを参照してください。

* [HTML と JavaScript のトラブルシューティング ガイド](html-and-javascript-troubleshooting-guide.md)
* [XAML と C# のトラブルシューティング ガイド](xaml-and-c-troubleshooting-guide.md)

## <a name="adcontrol-interface-unknown-in-xaml"></a>XAML での不明な AdControl インターフェイス

[AdControl](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.adcontrol.aspx) の XAML マークアップに、そのインターフェイスが不明であることを示す青い破線が表示される場合があります。 これは、x86 をターゲットとして設定している場合にのみ発生するもので、無視してかまいません。

## <a name="lasterror-from-previous-ad-request"></a>以前の広告要求からの lastError

以前の広告要求の **lastError** が残っている場合、次の広告呼び出し中にこのイベントが 2 回を発生する可能性があります。 その一方で新しい広告要求が行われ、有効な広告が生成されると、この動作によって混乱が生じる可能性があります。

## <a name="interstitial-ads-and-navigation-buttons-on-phones"></a>スポット広告と電話のナビゲーション ボタン

ハードウェア ボタンの代わりにソフトウェア ボタンの **"戻る"**、**"スタート"**、**"検索"** を備えた電話 (またはエミュレーター) では、スポット広告用のカウントダウン タイマー ボタンとクリックスルー ボタンが隠れる場合があります。

## <a name="recently-created-ads-are-not-being-served-to-your-app"></a>最近作成した広告がアプリに提供されない

その広告が最近 (1 日以内) 作成された広告の場合は、すぐに利用可能にならない場合があります。 編集コンテンツに関する承認が済んでいる場合、広告は、広告サーバーによって処理され、インベントリとして利用可能になった時点で提供されるようになります。

## <a name="no-ads-are-shown-in-your-app"></a>アプリに広告が表示されない

広告が表示されない場合、ネットワーク エラーを含むさまざまな理由があります。 次の理由も考えられます。

* Windows デベロッパー センターで、アプリのコードの **AdControl** を超えるサイズまたはこれよりも小さいサイズの広告ユニットが選択されています。

* 広告ユニット ID に[テスト モードの値](set-up-ad-units-in-your-app.md#test-ad-units)を使ってライブ アプリを実行した場合、広告は表示されません。

* 新しい広告ユニット ID の作成を行ったのがこの 30 分以内の場合、サーバーによってシステムに新しいデータが伝達されるまで、広告は表示されません。 広告が表示されていた既存の ID を使用すると、広告はすぐに表示されます。

アプリにテスト広告が表示される場合は、コードが正常に動作していて広告を表示できることを示します。 問題が発生した場合は、[製品サポート](https://developer.microsoft.com/en-us/windows/support)にお問い合わせください。 このページで、**[アプリ内広告]** を選択してください。

[フォーラム](http://go.microsoft.com/fwlink/p/?LinkId=401266)に質問を投稿することもできます。

## <a name="test-ads-are-showing-in-your-app-instead-of-live-ads"></a>ライブ広告ではなくテスト広告がアプリに表示される

ライブ広告が想定されているときでもテスト広告が表示される場合があります。 これは、次の状況で発生することがあります。

* ストアで使用されているライブ アプリケーション ID を広告プラットフォームが確認または検出できない。 この場合、広告ユニットがユーザーによって作成されたとき、その状態は "ライブ" (非テスト) として開始されますが、最初の広告要求が行われてから 6 時間以内にテスト状態に移行します。 その状態は、10 日間テスト アプリからの要求がない場合に "ライブ" に戻ります。

* サイドローディングされたアプリやエミュレーターで実行されているアプリには、ライブ広告は表示されません。

ライブ広告ユニットによってテスト広告が提供されているとき、Windows デベロッパー センターには、広告ユニットの状態として **"Active and serving test ads"** が表示されます。 現時点で、これは、電話アプリには適用されません。


<span id="reference_errors"/>

## <a name="reference-errors-caused-by-targeting-any-cpu-in-your-project"></a>プロジェクトのターゲットを "任意の CPU" に設定すると参照エラーが発生する

Microsoft Advertising SDK を使う場合、プロジェクトで**任意の CPU** をターゲットにすることはできません。 プロジェクトのターゲットを**任意の CPU** プラットフォームに設定した場合、次のような参照を追加した後で警告が表示される場合があります。

![referenceerror\-solutionexplorer](images/13-19629921-023c-42ec-b8f5-bc0b63d5a191.jpg)

この警告を解決するには、アーキテクチャ固有のビルド出力 (たとえば、**x86**) を使用するようにプロジェクトを更新します。 デバッグおよびリリース用の構成のプラットフォームのターゲットを設定するには、**Configuration Manager** を使用します。

![configurationmanagerwin10](images/13-87074274-c10d-4dbd-9a06-453b7184f8de.png)

(次の図に示すように) ストアに申請するアプリ パッケージを作成するときは、ターゲットのアーキテクチャを必ず指定してください。 x64 OS で x86 ビルドを実行する場合は、x64 をスキップしてもかまいません。

![projectstorecreateapppackages](images/13-a99b05a4-8917-4c53-822e-2548fadf828a.png)

![createapppackages](images/13-16280cb1-a838-42b9-9256-eac7f33f5603.png)

## <a name="z-order-in-javascripthtml-apps"></a>JavaScript/HTML アプリでの Z オーダー

JavaScript/HTML アプリでは、z オーダーの予約済みの MAX-10 の範囲に要素を配置しないでください。 この唯一の例外として、Skype アプリの着信通知などの割り込みオーバーレイがあります。

<span id="bkmk-ui"/>

## <a name="do-not-use-borders"></a>境界線を使わない

**AdControl** によってその親クラスから継承される境界線に関連するプロパティを設定すると、広告の配置に関して問題が発生します。

## <a name="more-information"></a>詳細情報

最新の既知の問題についての詳細を調べたり、Microsoft Advertising SDK に関連する質問を投稿したりするには、[フォーラム](http://go.microsoft.com/fwlink/p/?LinkId=401266)をご利用ください。

 

 
