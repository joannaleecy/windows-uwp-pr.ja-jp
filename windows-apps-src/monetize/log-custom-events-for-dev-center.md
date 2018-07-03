---
author: mcleanbyron
Description: You can log custom events from your UWP app and review those events in the Usage report on the Windows Dev Center dashboard.
title: デベロッパー センターのカスタム イベントをログに記録する
ms.author: mcleans
ms.date: 06/01/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, Microsoft Store Services SDK, イベントをログ記録
ms.assetid: 4aa591e0-c22a-4c90-b316-0b5d0410af19
ms.localizationpriority: high
ms.openlocfilehash: 9828f948d0245ee23a3e309951b38c61765973e9
ms.sourcegitcommit: 929fa4b3273862dcdc76b083bf6c3b2c872dd590
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 06/01/2018
ms.locfileid: "1935572"
---
# <a name="log-custom-events-for-dev-center"></a>デベロッパー センターのカスタム イベントをログに記録する

Windows デベロッパー センター ダッシュボードの[利用状況レポート](https://msdn.microsoft.com/windows/uwp/publish/usage-report)では、お客様によるアプリの利用状況を確認でき、ユニバーサル Windows プラットフォーム (UWP) で定義したカスタム イベントに関する情報を取得できます。 カスタムイベントは、アプリ内のイベントやアクティビティを表す任意の文字列です。 たとえば、ゲームで *firstLevelPassed*、*secondLevelPassed* という名前のカスタム イベントを定義して、ユーザーがゲームの各レベルをクリアしたときに記録されるようにできます。

アプリからのカスタム イベントをログに記録するには、カスタム イベントの文字列を Microsoft Store Services SDK で提供されている [Log](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.storeservicescustomeventlogger.log.aspx) メソッドに渡します。 デベロッパー センター ダッシュボードにある[利用状況レポート](https://msdn.microsoft.com/windows/uwp/publish/usage-report)の**カスタム イベント**のセクションで、カスタム イベントが発生した合計回数を確認できます。

> [!NOTE]
> デベロッパー センターに記録したカスタム イベントは [Windows イベント](https://msdn.microsoft.com/library/windows/desktop/aa964766.aspx)とは無関係のため、**イベント ビューアー**には表示されません。

## <a name="prerequisites"></a>前提条件

ダッシュ ボードでアプリの**利用状況レポート**のカスタム ログ イベントを確認する前に、ストアでアプリを公開する必要があります。

## <a name="how-to-log-custom-events"></a>カスタム イベントをログに記録する方法

1. Microsoft Store Services SDK を開発用コンピューターにインストールしていない場合には、[Microsoft Store Services SDK をインストール](microsoft-store-services-sdk.md#install-the-sdk)します。

2. Visual Studio でプロジェクトを開きます。

3. ソリューション エクスプローラーで、プロジェクトの **[参照設定]** ノードを右クリックし、**[参照の追加]** をクリックします。

4. **[参照マネージャー]** で、**[ユニバーサル Windows]** を展開し、**[拡張機能]** をクリックします。

5. SDK の一覧で、**[Microsoft Engagement Framework]** の横にあるチェック ボックスをオンにして、**[OK]** をクリックします。

6. カスタム イベントを記録する各コード ファイルの先頭に、次のステートメントを追加します。
    [!code-cs[EventLogger](./code/StoreSDKSamples/cs/LogEvents.cs#EngagementNamespace)]

7. カスタム イベントのログを記録するコードの各セクションで、[StoreServicesCustomEventLogger](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.storeservicescustomeventlogger.log.aspx) オブジェクトを取得し、[Log](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.storeservicescustomeventlogger.log.aspx) メソッドを呼び出します。 カスタム イベント文字列をメソッドに渡します。
    [!code-cs[EventLogger](./code/StoreSDKSamples/cs/LogEvents.cs#Log)]

    > [!NOTE]
    > アプリで長い名前を持つ多くのカスタム イベントをログに記録する場合は、[[使用状況] レポート](https://msdn.microsoft.com/windows/uwp/publish/usage-report)の読み込みに時間がかかることもあります。 カスタム イベントには簡単な名前を使用することをお勧めします。 

## <a name="related-topics"></a>関連トピック

* [[使用状況] レポート](https://msdn.microsoft.com/windows/uwp/publish/usage-report)
* [Log メソッド](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.storeservicescustomeventlogger.log.aspx)
* [Microsoft Store Services SDK](https://msdn.microsoft.com/windows/uwp/monetize/microsoft-store-services-sdk)
