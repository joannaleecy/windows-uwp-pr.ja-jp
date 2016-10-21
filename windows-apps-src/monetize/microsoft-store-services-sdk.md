---
author: mcleanbyron
Description: "Microsoft Store Services SDK が提供するライブラリとツールを利用すると、収益とユーザーの獲得を図る機能をアプリに追加できます。"
title: Microsoft Store Services SDK
ms.assetid: 518516DB-70A7-49C4-B3B6-CD8A98320B9C
translationtype: Human Translation
ms.sourcegitcommit: 2f0835638f330de0ac2d17dae28347686cc7ed97
ms.openlocfilehash: 98675e9cb06b05e55d49ca625818626aea5a5346

---

# Microsoft Store Services SDK

Microsoft Store Services SDK が提供するライブラリとツールを利用すると、ユニバーサル Windows プラットフォーム (UWP) アプリで収益とユーザーの獲得を向上することができます。たとえば、アプリで広告を表示したり、A/B テストを行ったりできます。 この SDK には、エンゲージメントと収益化に関する新しい機能が徐々に追加されていきます。


## SDK で利用可能な機能

Microsoft Store Services SDK は、以下の機能をサポートするライブラリとツールを提供します。

### UWP アプリの A/B テストの実行

ユニバーサル Windows プラットフォーム (UWP) アプリで A/B テストを実施して、すべてのユーザー向けに機能を公開する前に、一部のユーザーに対して機能の有効性を測定することができます。 デベロッパー センター ダッシュボードで実験を定義したら、アプリで [StoreServicesExperimentVariation](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.storeservicesexperimentvariation.aspx) クラスを使用して実験のバリエーションを取得します。次に、そのデータを使用して、テストする機能の動作を変更し、[LogForVariation](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.storeservicescustomeventlogger.logforvariation.aspx) メソッドを使って、デベロッパー センターにビュー イベントとコンバージョン イベントを送信します。 最後に、ダッシュボードで結果を表示し、実験を管理します。

詳しくは、「[A/B テストの実行](run-app-experiments-with-a-b-testing.md)」をご覧ください。

### UWP アプリのアプリ フィードバック

UWP アプリで [StoreServicesFeedbackLauncher](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.storeservicesfeedbacklauncher.aspx) クラスを使用し、Windows 10 ユーザーをフィードバック Hub に誘導して、ユーザーが問題、提案、賛成票を送信できるようにします。 次に、デベロッパー センター ダッシュボードの[フィードバック レポート](../publish/feedback-report.md)でこのフィードバックを管理します。

詳しくは、「[アプリからのフィードバック Hub の起動](launch-feedback-hub-from-your-app.md)」をご覧ください。

### アプリでの広告の表示

UWP アプリに Microsoft のバナー広告やビデオのスポット広告を表示して収益を増やします。 また、広告仲介を使用して、複数の広告ネットワーク プロバイダーから広告を表示すると、広告のフィル レートを最大限に高めることができます。

詳しくは、「[アプリでの広告の表示](display-ads-in-your-app.md)」をご覧ください。

>**注**&nbsp;&nbsp;Microsoft Store Services SDK は UWP アプリのみサポートしています。 Windows 8.1 および Windows Phone 8.x アプリで広告を表示するには、[Windows および Windows Phone 8.x 用の Microsoft Advertising SDK](http://aka.ms/store-8-sdk) を使用します。

### API リファレンス

Microsoft Store Services SDK の API に関するリファレンス ドキュメントについては、「[Microsoft Store Services SDK API リファレンス](https://msdn.microsoft.com/library/windows/apps/mt691886.aspx)」をご覧ください。

## SDK のインストール

Microsoft Store Services SDK をインストールするには

1.  Visual Studio 2013 または Visual Studio 2015 のすべてのインスタンスを閉じて、Microsoft Store Engagement and Monetization SDK、Universal Ad Client SDK、Ad Mediator 拡張機能、または Microsoft Advertising SDK の以前のバージョンをアンインストールします。
2.  [SDK](http://aka.ms/store-em-sdk) をダウンロードしてインストールします。 インストールには数分かかることがあります。 確実に処理が完了するまでお待ちください。
3.  Visual Studio を再起動します。

マイクロソフトでは定期的に、向上したパフォーマンスと新しい機能を備えた、新しいバージョンの Microsoft Store Services SDK をリリースしています。 Microsoft Store Services SDK を使っている既存のプロジェクトがあり、そのプロジェクトで最新バージョンを使う場合は、最新バージョンの SDK をダウンロードしてインストールしてください。

以前のリリースである Microsoft Store Engagement and Monetization SDK、Universal Ad Client SDK、Ad Mediator 拡張機能、Microsoft Advertising SDK の UWP アプリ用の広告機能は現在、Microsoft Store Services SDK に含まれています。 以前のリリースの広告機能を使っている既存の UWP プロジェクトがある場合は、Microsoft Store Services SDK をインストールした後も、変更を加える必要なしに、既存のプロジェクトを継続できます。

>**注**  Visual Studio 2015 の Microsoft Store Services SDK をインストールするには、Visual Studio Tools for Universal Windows Apps のバージョン 1.1 以降がインストールされている必要があります。 Visual Studio Tools for Universal Windows Apps のこの更新について詳しくは、[リリース ノート](http://go.microsoft.com/fwlink/?LinkID=624516)をご覧ください。

## SDK のフレームワーク パッケージ

Microsoft Store Services SDK の以下のライブラリは*フレームワーク パッケージ*として構成されています。

* Microsoft.Advertising.dll。 このライブラリには、[Microsoft.Advertising](https://msdn.microsoft.com/en-us/library/windows/apps/mt313187.aspx) のアドバタイズ API と [Microsoft.Advertising.WinRT.UI](https://msdn.microsoft.com/en-us/library/windows/apps/microsoft.advertising.winrt.ui.aspx) 名前空間が含まれます。
* Microsoft.Services.Store.Engagement.dll。 このライブラリには、[Microsoft.Services.Store.Engagement](https://msdn.microsoft.com/en-us/library/windows/apps/microsoft.services.store.engagement.aspx) 名前空間の API が含まれています。

つまり、SDK を開発用コンピューターにインストールした後、これらのライブラリは、修正されてパフォーマンスが向上した新しいバージョンのライブラリが公開されるたびに、Windows Update を介して自動的に更新されます。 これにより、利用できる最新バージョンのライブラリが開発用コンピューターに確実にインストールされます。

また、これらのライブラリを使用するバージョンのアプリをユーザーがインストールすると、これらのライブラリは、修正されてパフォーマンスが向上した新しいバージョンのライブラリが公開されるたびに、ユーザーのデバイスで自動的に更新されます。 つまり、開発者が更新されたバージョンのアプリをストアに公開しなくても、ユーザーは最新バージョンのライブラリを常に使用できるようになります。

ただし、これらのライブラリに新しい API や機能が導入された新しいバージョンの SDK がリリースされた場合は、これらの機能を使用するために最新バージョンの SDK をインストールする必要があります。 このシナリオでは、更新されたアプリをストアに公開する必要もあります。

## 関連トピック

* [Microsoft Store Services SDK API リファレンス](https://msdn.microsoft.com/library/windows/apps/mt691886.aspx)
* [A/B テストの実行](run-app-experiments-with-a-b-testing.md)
* [アプリからのフィードバック Hub の起動](launch-feedback-hub-from-your-app.md)
* [アプリでの広告の表示](display-ads-in-your-app.md)



<!--HONumber=Sep16_HO2-->


