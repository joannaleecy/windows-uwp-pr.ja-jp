---
author: mcleanbyron
Description: "Microsoft Store Engagement and Monetization SDK が提供するライブラリとツールを利用すると、収益とユーザーの獲得を図る機能をアプリに追加できます。"
title: Microsoft Store Engagement and Monetization SDK
ms.assetid: 518516DB-70A7-49C4-B3B6-CD8A98320B9C
ms.sourcegitcommit: de85956c7c1d2a0ba509d61ee8928b412f057f8a
ms.openlocfilehash: 481cf2aab806a1f9ce368256a9df8930cbc756c1

---

# Microsoft Store Engagement and Monetization SDK

Microsoft Store Engagement and Monetization SDK が提供するライブラリとツールを利用すると、収益とユーザーの獲得を向上することができます。たとえば、アプリで広告を表示したり、A/B テストを行ったりできます。 この SDK は Microsoft Universal Ad Client SDK の後継であり、エンゲージメントと収益化に関する新しい機能が徐々に追加されます。


## SDK で利用可能な機能

Microsoft Store Engagement and Monetization SDK は、以下の機能をサポートするライブラリとツールを提供します。

### UWP アプリの A/B テストの実行

ユニバーサル Windows プラットフォーム (UWP) アプリで A/B テストを実施して、すべてのユーザー向けに機能を公開する前に、一部のユーザーに対して機能の有効性を測定することができます。 デベロッパー センター ダッシュボードで実験を定義したら、アプリで [ExperimentClient](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.experimentclient.aspx) クラスを使用して実験のバリエーションを取得し、そのデータを使って、テストする機能の動作を変更し、[Log](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.storeservicescustomevents.log.aspx) メソッドを使って、デベロッパー センターにビュー イベントとコンバージョン イベントを送信します。 最後に、ダッシュボードで結果を表示し、実験を管理します。

詳しくは、「[A/B テストの実行](run-app-experiments-with-a-b-testing.md)」をご覧ください。

### UWP アプリのアプリ フィードバック

UWP アプリで [Feedback](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.feedback.aspx) クラスを使用して、Windows 10 ユーザーをフィードバック Hub に誘導して、ユーザーが問題、提案、賛成票を送信できるようにします。 次に、デベロッパー センター ダッシュボードの[フィードバック レポート](../publish/feedback-report.md)でこのフィードバックを管理します。

詳しくは、「[アプリからのフィードバック Hub の起動](launch-feedback-hub-from-your-app.md)」をご覧ください。

>
            **注** **フィードバック** レポートは、現在、[デベロッパー センター Insider Program](../publish/dev-center-insider-program.md) に参加している開発者アカウントのみが利用できます。

### アプリでの広告の表示

UWP アプリに加えて、Windows 8.1 アプリや Windows Phone 8.x アプリで、Microsoft からのバナー広告およびスポット広告ビデオを表示し、収益を増やします。 また、広告仲介を使用して、複数の広告ネットワーク プロバイダーから広告を表示すると、広告のフィル レートを最大限に高めることができます。

詳しくは、「[アプリでの広告の表示](display-ads-in-your-app.md)」をご覧ください。

>
            **注** 以前のリリースである Universal Ad Client SDK、Ad Mediator 拡張機能、Microsoft Advertising SDK の広告機能は現在、Microsoft Store Monetization and Engagement SDK に含まれています。

### API リファレンス

SDK の API に関するリファレンス ドキュメントについては、「[Microsoft Store Engagement and Monetization SDK API リファレンス](https://msdn.microsoft.com/library/windows/apps/mt691886.aspx)」をご覧ください。

## SDK のインストール

Microsoft Store Monetization and Engagement SDK をインストールするには、次の手順を実行します。

1.  Visual Studio 2013 または Visual Studio 2015 のすべてのインスタンスを閉じて、Universal Ad Client SDK、Ad Mediator 拡張機能、または Microsoft Advertising SDK の以前のバージョンをアンインストールします。
2.  [SDK](http://aka.ms/store-em-sdk) をダウンロードしてインストールします。 インストールには数分かかることがあります。 確実に処理が完了するまでお待ちください。
3.  Visual Studio を再起動します。

マイクロソフトでは定期的に、向上したパフォーマンスと新しい機能を備えた、新しいバージョンの Microsoft Store Monetization and Engagement SDK をリリースしています。 Microsoft Store Monetization and Engagement SDK を使っている既存のプロジェクトがあり、そのプロジェクトで最新バージョンを使う場合は、最新バージョンの SDK をダウンロードしてインストールしてください。

以前のリリースである Universal Ad Client SDK、Ad Mediator 拡張機能、Microsoft Advertising SDK の広告機能は現在、Microsoft Store Monetization and Engagement SDK に含まれています。 以前のリリースの広告機能を使っている既存の Visual Studio 2015 または Visual Studio 2013 プロジェクトがある場合は、Microsoft Store Monetization and Engagement SDK をインストールした後も、変更を加える必要なしに、既存のプロジェクトを継続できます。

>
            **注**  Visual Studio 2015 の Microsoft Store Engagement and Monetization SDK をインストールするには、Visual Studio Tools for Universal Windows Apps のバージョン 1.1 以降がインストールされている必要があります。 Visual Studio Tools for Universal Windows Apps のこの更新について詳しくは、[リリース ノート](http://go.microsoft.com/fwlink/?LinkID=624516)をご覧ください。

## SDK のフレームワーク パッケージ

Microsoft Store Monetization and Engagement SDK に含まれる次のライブラリは、*フレームワーク パッケージ*として構成されます。

* Microsoft.Advertising.dll (UWP アプリ プロジェクトに対してのみ)。 このライブラリには、**Microsoft.Advertising** のアドバタイズ API と **Microsoft.Advertising.WinRT.UI** 名前空間が含まれます。

つまり、SDK を開発用コンピューターにインストールした後、このライブラリは、修正されてパフォーマンスが向上した新しいバージョンのライブラリが公開されるたびに、Windows Update を介して自動的に更新されます。 これにより、利用できる最新バージョンのライブラリが開発用コンピューターに確実にインストールされます。

また、このライブラリを使用するバージョンのアプリをユーザーがインストールすると、このライブラリは、修正されてパフォーマンスが向上した新しいバージョンのライブラリが公開されるたびに、ユーザーのデバイスで自動的に更新されます。 つまり、開発者が更新されたバージョンのアプリをストアに公開しなくても、ユーザーは最新バージョンのライブラリを常に使用できるようになります。

ただし、このライブラリに新しい API や機能が導入された新しいバージョンの SDK がリリースされた場合は、これらの機能を使用するために最新バージョンの SDK をインストールする必要があります。 このシナリオでは、更新されたアプリをストアに公開する必要もあります。

他のプラットフォームを対象にした Microsoft.Advertising.dll や広告仲介用のライブラリなど、SDK のその他のライブラリは現在、フレームワーク ライブラリとして構成されていません。

## 関連トピック

* [A/B テストの実行](run-app-experiments-with-a-b-testing.md)
* [Microsoft Store Engagement and Monetization SDK API リファレンス](https://msdn.microsoft.com/library/windows/apps/mt691886.aspx)
* [アプリからのフィードバック Hub の起動](launch-feedback-hub-from-your-app.md)



<!--HONumber=Jun16_HO4-->


