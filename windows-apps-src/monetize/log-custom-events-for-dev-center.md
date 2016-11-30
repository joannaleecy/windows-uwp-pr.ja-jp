---
author: mcleanbyron
Description: "UWP アプリからカスタム イベントをログに記録し、Windows デベロッパー センター ダッシュボードの利用状況レポートでそのイベントを確認できます。"
title: "デベロッパー センターのカスタム イベントをログに記録する"
translationtype: Human Translation
ms.sourcegitcommit: 126fee708d82f64fd2a49b844306c53bb3d4cc86
ms.openlocfilehash: 61874c700ecd31c7246effef5b05ffbf1153dfd5

---

# デベロッパー センターのカスタム イベントをログに記録する

Windows デベロッパー センター ダッシュボードの[利用状況レポート](https://msdn.microsoft.com/windows/uwp/publish/usage-report)では、お客様によるアプリの利用状況を確認でき、ユニバーサル Windows プラットフォーム (UWP) で定義したカスタム イベントに関する情報を取得できます。 カスタムイベントは、アプリ内のイベントやアクティビティを表す任意の文字列です。 たとえば、ゲームで *firstLevelPassed*、*secondLevelPassed* という名前のカスタム イベントを定義して、ユーザーがゲームの各レベルをクリアしたときに記録されるようにできます。

アプリからのカスタム イベントをログに記録するには、カスタム イベントの文字列を Microsoft Store Services SDK で提供されている [Log](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.storeservicescustomeventlogger.log.aspx) メソッドに渡します。 デベロッパー センター ダッシュボードの[利用状況レポート](https://msdn.microsoft.com/windows/uwp/publish/usage-report)の**カスタム イベント**のセクションで、カスタム イベントの合計回数を確認できます。

## 前提条件

ダッシュ ボードでアプリの**利用状況レポート**のカスタム ログ イベントを確認する前に、ストアでアプリを公開する必要があります。

## カスタム イベントをログに記録する方法

1. Microsoft Store Services SDK を開発用コンピューターにインストールしていない場合には、[Microsoft Store Services SDK をインストール](microsoft-store-services-sdk.md#install-the-sdk)します。 カスタム イベントをログに記録するための API に加えて、この SDK は、アプリで A/B テストを行ったり、広告を表示したりすることなど、その他の機能のための API を提供します。 
2. Visual Studio でプロジェクトを開きます。
3. ソリューション エクスプローラーで、プロジェクトの **[参照設定]** ノードを右クリックし、**[参照の追加]** をクリックします。
4. **[参照マネージャー]**で、**[ユニバーサル Windows]** を展開し、**[拡張機能]** をクリックします。
5. SDK の一覧で、**[Microsoft Engagement Framework]** の横にあるチェック ボックスをオンにして、**[OK]** をクリックします。
7. カスタム イベントを記録する各コード ファイルの先頭に、次のステートメントを追加します。

  ```csharp
  using Microsoft.Services.Store.Engagement;
  ```
8. カスタム イベントのログを記録するコードの各セクションで、[StoreServicesCustomEventLogger](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.storeservicescustomeventlogger.log.aspx) オブジェクトを取得し、[Log](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.storeservicescustomeventlogger.log.aspx) メソッドを呼び出します。 カスタム イベント文字列をメソッドに渡します。

  ```csharp
  StoreServicesCustomEventLogger logger = StoreServicesCustomEventLogger.GetDefault();
  logger.Log("myCustomEvent");
  ```

## 関連トピック

* [利用状況レポート](https://msdn.microsoft.com/windows/uwp/publish/usage-report)
* [Log メソッド](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.storeservicescustomeventlogger.log.aspx)
* [Microsoft Store Services SDK](https://msdn.microsoft.com/windows/uwp/monetize/microsoft-store-services-sdk)



<!--HONumber=Nov16_HO1-->


