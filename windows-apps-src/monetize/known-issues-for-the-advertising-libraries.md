---
author: mcleanbyron
ms.assetid: 9ca1f880-2ced-46b4-8ea7-aba43d2ff863
description: Microsoft Store Engagement and Monetization SDK の Microsoft Advertising ライブラリの現在のリリースにおける既知の問題について説明します。
title: Microsoft Advertising ライブラリに関する既知の問題
---

# Microsoft Advertising ライブラリに関する既知の問題


\[ Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください \]

このトピックでは、Microsoft Store Engagement and Monetization SDK の Microsoft Advertising ライブラリの現在のリリースにおける既知の問題について説明します。

## インストールには Visual Studio Tools for Universal Windows Apps が必要

Visual Studio 2015 と共に [Microsoft Store Engagement and Monetization SDK](http://aka.ms/store-em-sdk) をインストールするには、Visual Studio Tools for Universal Windows Apps のバージョン 1.1 以降がインストールされている必要があります。 詳しくは、Visual Studio の[リリース ノート](http://go.microsoft.com/fwlink/?LinkID=624516)をご覧ください。

## Windows Phone 8.x Silverlight プロジェクト

Windows Phone 8.x Silverlight プロジェクト用の Microsoft Advertising アセンブリを入手するには、[Microsoft Store Engagement and Monetization SDK](http://aka.ms/store-em-sdk) をインストールします。次に、プロジェクトを Visual Studio で開き、**[プロジェクト]**、**[接続済みサービスを追加します]**、**[Ad Mediator]** の順に移動して、アセンブリを自動的にダウンロードします。 その後、広告仲介を使用しない場合は、広告メディエーターの参照をプロジェクトから削除できます。 詳しくは、「[Windows Phone Silverlight の AdControl](adcontrol-in-windows-phone-silverlight.md)」をご覧ください。

## XAML での不明な AdControl インターフェイス

[AdControl](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.adcontrol.aspx) の XAML マークアップに、そのインターフェイスが不明であることを示す青い破線が表示される場合があります。 これは、x86 をターゲットとして設定している場合にのみ発生するもので、無視してかまいません。

## 以前の広告要求からの lastError

以前の広告要求の **lastError** が残っている場合、次の広告呼び出し中にこのイベントが 2 回を発生する可能性があります。 その一方で新しい広告要求が行われ、有効な広告が生成されると、この動作によって混乱が生じる可能性があります。

## スポット広告と電話のナビゲーション ボタン

ハードウェア ボタンの代わりにソフトウェアの **"戻る"**、**"スタート"**、**"検索"** ボタンがある携帯電話 (またはエミュレーター) では、ビデオ スポット広告のカウントダウン タイマー ボタンとクリックスルー ボタンが隠れる場合があります。

## 最近作成した広告がアプリに提供されない

その広告が最近 (1 日以内) 作成された広告の場合は、すぐに利用可能にならない場合があります。 編集コンテンツに関する承認が済んでいる場合、広告は、広告サーバーによって処理され、インベントリとして利用可能になった時点で提供されるようになります。

## アプリに広告が表示されない

広告が表示されない場合、ネットワーク エラーを含むさまざまな理由があります。 次の理由も考えられます。

* Windows デベロッパー センターで、アプリのコードの **AdControl** を超えるサイズまたはこれよりも小さいサイズの広告ユニットが選択されています。

* 広告ユニット ID に[テスト モードの値](test-mode-values.md)を使ってライブ アプリを実行した場合、広告は表示されません。

* 新しい広告ユニット ID の作成を行ったのがこの 30 分以内の場合、サーバーによってシステムに新しいデータが伝達されるまで、広告は表示されません。 広告が表示されていた既存の ID を使用すると、広告はすぐに表示されます。

アプリにテスト広告が表示される場合は、コードが正常に動作していて広告を表示できることを示します。 問題が発生した場合は、[製品サポート](https://go.microsoft.com/fwlink/p/?LinkId=331508)にお問い合わせください。 このページで、**[In-App 広告]** を選択してください。

[フォーラム](http://go.microsoft.com/fwlink/p/?LinkId=401266)に質問を投稿することもできます。

## ライブ広告ではなくテスト広告がアプリに表示される

ライブ広告が想定されているときでもテスト広告が表示される場合があります。 これは、次の状況で発生することがあります。

* アプリ ストアで使用されているライブ アプリケーション ID を Microsoft Advertising が確認または検出できない。 この場合、広告ユニットがユーザーによって作成されたとき、その状態は "ライブ" (非テスト) として開始されますが、最初の広告要求が行われてから 6 時間以内にテスト状態に移行します。 その状態は、10 日間テスト アプリからの要求がない場合に "ライブ" に戻ります。

* サイドローディングされたアプリやエミュレーターで実行されているアプリには、ライブ広告は表示されません。

ライブ広告ユニットによってテスト広告が提供されているとき、Windows デベロッパー センターには、広告ユニットの状態として **"Active and serving test ads"** が表示されます。 現時点で、これは、電話アプリには適用されません。

## 廃止され、現在無効となっている広告ユニット ID とアプリケーション ID のテスト値

以下の Windows Phone Silverlight アプリ用の次のテスト値は廃止され、現在無効になっています。 既存のプロジェクトでこれらのテスト値を使用している場合は、「[テスト モードの値](test-mode-values.md)」で提供されている値を使用するようにプロジェクトを更新してください。

| アプリケーション ID  |  広告ユニット ID    |
|-----------------|----------------|
| test_client     |  Image320_50   |
| test_client     |  Image300_50   |
| test_client     |  TextAd   |
| test_client     |  Image480_80   |

<span id="reference_errors"/>
## プロジェクトのターゲットを "Any CPU" に設定すると参照エラーが発生する

Microsoft Advertising ライブラリを使う場合、プロジェクトで **"Any CPU"** をターゲットにすることはできません。 プロジェクトのターゲットを **Any CPU** プラットフォームに設定した場合、次のような参照を追加した後で警告が表示される場合があります。

![referenceerror\-solutionexplorer](images/13-19629921-023c-42ec-b8f5-bc0b63d5a191.jpg)

この警告を解決するには、アーキテクチャ固有のビルド出力 (たとえば、**x86**) を使用するようにプロジェクトを更新します。 デバッグおよびリリース用の構成のプラットフォームのターゲットを設定するには、**Configuration Manager** を使用します。

![configurationmanagerwin10](images/13-87074274-c10d-4dbd-9a06-453b7184f8de.png)

(次の図に示すように) ストアに申請するアプリ パッケージを作成するときは、ターゲットのアーキテクチャを必ず指定してください。 x64 OS で x86 ビルドを実行する場合は、x64 をスキップしてもかまいません。

![projectstorecreateapppackages](images/13-a99b05a4-8917-4c53-822e-2548fadf828a.png)

![createapppackages](images/13-16280cb1-a838-42b9-9256-eac7f33f5603.png)

## JavaScript/HTML アプリでの Z オーダー

JavaScript/HTML アプリでは、z オーダーの予約済みの MAX-10 の範囲に要素を配置しないでください。 この唯一の例外として、Skype アプリの着信通知などの割り込みオーバーレイがあります。

<span id="bkmk-ui"/>
## 境界線を使わない

**AdControl** によってその親クラスから継承される境界線に関連するプロパティを設定すると、広告の配置に関して問題が発生します。

## 詳細情報


最新の既知の問題についての詳細を調べたり、Microsoft Advertising ライブラリに関連する質問を投稿したりするには、[フォーラム](http://go.microsoft.com/fwlink/p/?LinkId=401266)をご利用ください。

## サポート


Microsoft Advertising ライブラリに関する問題について製品サポートに問い合わせる場合は、[サポート ページ](https://go.microsoft.com/fwlink/p/?LinkId=331508)にアクセスし、**[In-App 広告]** を選択してください。

 

 


<!--HONumber=May16_HO2-->


