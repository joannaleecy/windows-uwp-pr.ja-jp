---
Description: UWP アプリからカスタム イベントを記録し、パートナー センターでの使用状況レポートでこれらのイベントを確認できます。
title: パートナー センターのカスタム イベントをログに記録する
ms.date: 06/01/2018
ms.topic: article
keywords: windows 10, uwp, Microsoft Store Services SDK, イベントをログ記録
ms.assetid: 4aa591e0-c22a-4c90-b316-0b5d0410af19
ms.localizationpriority: medium
ms.openlocfilehash: d7b338fd3b34d530ad365b0377d6b6c6c65398b7
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57604237"
---
# <a name="log-custom-events-for-partner-center"></a>パートナー センターのカスタム イベントをログに記録する

[使用状況レポート](https://msdn.microsoft.com/windows/uwp/publish/usage-report)でパートナー センター、ユニバーサル Windows プラットフォーム (UWP) アプリで定義したカスタム イベントに関する情報を取得することができます。 カスタムイベントは、アプリ内のイベントやアクティビティを表す任意の文字列です。 たとえば、ゲームで *firstLevelPassed*、*secondLevelPassed* という名前のカスタム イベントを定義して、ユーザーがゲームの各レベルをクリアしたときに記録されるようにできます。

アプリからのカスタム イベントをログに記録するには、カスタム イベントの文字列を Microsoft Store Services SDK で提供されている [Log](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicescustomeventlogger.log) メソッドに渡します。 カスタム イベントの合計出現回数を確認することができます、**カスタム イベント**のセクション、[使用状況レポート](https://msdn.microsoft.com/windows/uwp/publish/usage-report)パートナー センターでします。

> [!NOTE]
> パートナー センターにログインするカスタム イベントに関連しない[Windows イベント](https://msdn.microsoft.com/library/windows/desktop/aa964766.aspx)には表示されませんし**イベント ビューアー**します。

## <a name="prerequisites"></a>前提条件

カスタム ログのイベントを確認する前に、**使用状況レポート**、パートナー センターでアプリのアプリをストアに公開する必要があります。

## <a name="how-to-log-custom-events"></a>カスタム イベントをログに記録する方法

1. Microsoft Store Services SDK を開発用コンピューターにインストールしていない場合には、[Microsoft Store Services SDK をインストール](microsoft-store-services-sdk.md#install-the-sdk)します。

2. Visual Studio でプロジェクトを開きます。

3. ソリューション エクスプローラーで、プロジェクトの **[参照設定]** ノードを右クリックし、**[参照の追加]** をクリックします。

4. **[参照マネージャー]** で、**[ユニバーサル Windows]** を展開し、**[拡張機能]** をクリックします。

5. SDK の一覧で、**[Microsoft Engagement Framework]** の横にあるチェック ボックスをオンにして、**[OK]** をクリックします。

6. カスタム イベントを記録する各コード ファイルの先頭に、次のステートメントを追加します。
    [!code-cs[EventLogger](./code/StoreSDKSamples/cs/LogEvents.cs#EngagementNamespace)]

7. カスタム イベントのログを記録するコードの各セクションで、[StoreServicesCustomEventLogger](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicescustomeventlogger.log) オブジェクトを取得し、[Log](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicescustomeventlogger.log) メソッドを呼び出します。 カスタム イベント文字列をメソッドに渡します。
    [!code-cs[EventLogger](./code/StoreSDKSamples/cs/LogEvents.cs#Log)]

    > [!NOTE]
    > アプリで長い名前を持つ多くのカスタム イベントをログに記録する場合は、[[使用状況] レポート](https://msdn.microsoft.com/windows/uwp/publish/usage-report)の読み込みに時間がかかることもあります。 カスタム イベントには簡単な名前を使用することをお勧めします。 

## <a name="related-topics"></a>関連トピック

* [利用状況レポート](https://msdn.microsoft.com/windows/uwp/publish/usage-report)
* [Log メソッド](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicescustomeventlogger.log)
* [Microsoft Store Services SDK](https://msdn.microsoft.com/windows/uwp/monetize/microsoft-store-services-sdk)
