---
author: mcleanbyron
Description: "UWP アプリからカスタム イベントをログに記録し、Windows デベロッパー センター ダッシュボードの利用状況レポートでそのイベントを確認できます。"
title: "デベロッパー センターのカスタム イベントをログに記録する"
translationtype: Human Translation
ms.sourcegitcommit: ffda100344b1264c18b93f096d8061570dd8edee
ms.openlocfilehash: e0012d586d9b79db77bdeded6f0e1d2ce848bbea

---

# <a name="log-custom-events-for-dev-center"></a>デベロッパー センターのカスタム イベントをログに記録する

Windows デベロッパー センター ダッシュボードの[利用状況レポート](https://msdn.microsoft.com/windows/uwp/publish/usage-report)では、お客様によるアプリの利用状況を確認でき、ユニバーサル Windows プラットフォーム (UWP) で定義したカスタム イベントに関する情報を取得できます。 カスタムイベントは、アプリ内のイベントやアクティビティを表す任意の文字列です。 たとえば、ゲームで *firstLevelPassed*、*secondLevelPassed* という名前のカスタム イベントを定義して、ユーザーがゲームの各レベルをクリアしたときに記録されるようにできます。

アプリからのカスタム イベントをログに記録するには、カスタム イベントの文字列を Microsoft Store Services SDK で提供されている [Log](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.storeservicescustomeventlogger.log.aspx) メソッドに渡します。 デベロッパー センター ダッシュボードの[利用状況レポート](https://msdn.microsoft.com/windows/uwp/publish/usage-report)の**カスタム イベント**のセクションで、カスタム イベントの合計回数を確認できます。

## <a name="prerequisites"></a>前提条件

ダッシュ ボードでアプリの**利用状況レポート**のカスタム ログ イベントを確認する前に、ストアでアプリを公開する必要があります。

## <a name="how-to-log-custom-events"></a>カスタム イベントをログに記録する方法

1. Microsoft Store Services SDK を開発用コンピューターにインストールしていない場合には、[Microsoft Store Services SDK をインストール](microsoft-store-services-sdk.md#install-the-sdk)します。 カスタム イベントをログに記録するための API に加えて、この SDK は、アプリで A/B テストを行ったり、広告を表示したりすることなど、その他の機能のための API を提供します。
2. Visual Studio でプロジェクトを開きます。
3. ソリューション エクスプローラーで、プロジェクトの **[参照設定]** ノードを右クリックし、**[参照の追加]** をクリックします。
4. **[参照マネージャー]**で、**[ユニバーサル Windows]** を展開し、**[拡張機能]** をクリックします。
5. SDK の一覧で、**[Microsoft Engagement Framework]** の横にあるチェック ボックスをオンにして、**[OK]** をクリックします。
7. カスタム イベントを記録する各コード ファイルの先頭に、次のステートメントを追加します。

  > [!div class="tabbedCodeSnippets"]
  [!code-cs[EventLogger](./code/StoreSDKSamples/cs/LogEvents.cs#EngagementNamespace)]

8. カスタム イベントのログを記録するコードの各セクションで、[StoreServicesCustomEventLogger](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.storeservicescustomeventlogger.log.aspx) オブジェクトを取得し、[Log](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.storeservicescustomeventlogger.log.aspx) メソッドを呼び出します。 カスタム イベント文字列をメソッドに渡します。

  > [!div class="tabbedCodeSnippets"]
  [!code-cs[EventLogger](./code/StoreSDKSamples/cs/LogEvents.cs#Log)]

## <a name="related-topics"></a>関連トピック

* [利用状況レポート](https://msdn.microsoft.com/windows/uwp/publish/usage-report)
* [Log メソッド](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.storeservicescustomeventlogger.log.aspx)
* [Microsoft Store Services SDK](https://msdn.microsoft.com/windows/uwp/monetize/microsoft-store-services-sdk)



<!--HONumber=Dec16_HO1-->


