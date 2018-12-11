---
Description: You can encourage your customers to leave feedback by launching Feedback Hub from your app.
title: アプリからのフィードバック Hub の起動
ms.assetid: 070B9CA4-6D70-4116-9B18-FBF246716EF0
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, フィードバック Hub, 起動
ms.localizationpriority: medium
ms.openlocfilehash: b4e11b8dfffd7e749a31f052545bfbdfc4449126
ms.sourcegitcommit: 49d58bc66c1c9f2a4f81473bcb25af79e2b1088d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8947874"
---
# <a name="launch-feedback-hub-from-your-app"></a>アプリからのフィードバック Hub の起動

フィードバック Hub を起動するユニバーサル Windows プラットフォーム (UWP) アプリにコントロール (ボタンなど) を追加してフィードバックを送信することをユーザーにお勧めできます。 フィードバック Hub は、Windows およびインストール済みアプリでフィードバックを 1 か所で収集できるようにするプレインストール アプリです。 フィードバック Hub を介してアプリ用に送信されるすべてのユーザーのフィードバックが収集され、問題、提案、賛成票を 1 つのレポートで、ユーザーが送信したを確認できるように、パートナー センターで、[フィードバック] レポート](../publish/feedback-report.md)でユーザーに表示されます。

アプリからフィードバック Hub を起動するには、[Microsoft Store Services SDK](http://aka.ms/store-em-sdk) が提供する API を使用します。 この API を使用して、設計ガイドラインに準拠したアプリの UI 要素からフィードバック Hub を起動することをお勧めします。

> [!NOTE]
> フィードバック Hub は、デスクトップとモバイルの[デバイス ファミリ](https://msdn.microsoft.com/windows/uwp/get-started/universal-application-platform-guide#device-families)に基づく Windows 10 OS の バージョン 10.0.14271 またはそれ以降を実行しているデバイスのみで利用できます。 フィードバック Hub がユーザーのデバイスで利用できる場合にのみ、アプリにフィードバック コントロールを表示することをお勧めします。 このトピックのコードは、これを実行する方法を示しています。

## <a name="how-to-launch-feedback-hub-from-your-app"></a>アプリからフィードバック Hub を起動する方法

アプリからフィードバック Hub を起動するには、次の手順に従います。

1. [Microsoft Store Services SDK](microsoft-store-services-sdk.md#install-the-sdk) をインストールします。
2. Visual Studio でプロジェクトを開きます。
3. ソリューション エクスプローラーで、プロジェクトの **[参照設定]** ノードを右クリックし、**[参照の追加]** をクリックします。
4. **[参照マネージャー]** で、**[ユニバーサル Windows]** を展開し、**[拡張機能]** をクリックします。
5. SDK の一覧で、**[Microsoft Engagement Framework]** の横にあるチェック ボックスをオンにして、**[OK]** をクリックします。
6. プロジェクトで、フィードバック Hub を起動するために、ユーザーに表示するボタンなどのコントロールを追加します。 コントロールを次のように構成することをお勧めします。
  * コントロールに表示するコンテンツのフォントを **Segoe MDL2 Assets** に設定します。
  * コントロールのテキストを 16 進数の Unicode 文字コード E939 に設定します。 これは、**Segoe MDL2 アセット** フォントで推奨されるフィードバック アイコンの文字コードです。
  * コントロールの可視性を非表示に設定します。
    > [!NOTE]
    > フィードバック Hub がユーザーのデバイスで利用できる場合、既定でフィードバック コントロールを非表示にし、初期化コードのみにフィードバック コントロールを表示することをお勧めします。 次の手順は、この処理を実行する方法を示しています。

    次のコードは、上記のように構成されている[ボタン](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Button)の XAML 定義を示しています。

    ```XML
    <Button x:Name="feedbackButton" FontFamily="Segoe MDL2 Assets" Content="&#xE939;" HorizontalAlignment="Left" Margin="138,352,0,0" VerticalAlignment="Top" Visibility="Collapsed"  Click="feedbackButton_Click"/>
    ```

7. フィードバック コントロールをホストするアプリのページの初期化コードで、[StoreServicesFeedbackLauncher](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicesfeedbacklauncher) クラスの [IsSupported](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicesfeedbacklauncher.issupported) 静的メソッドを使用して、フィードバック Hub がユーザーのデバイスで利用できるかどうかを指定します。 フィードバック Hub は、デスクトップとモバイルの[デバイス ファミリ](https://msdn.microsoft.com/windows/uwp/get-started/universal-application-platform-guide#device-families)に基づく Windows 10 OS の バージョン 10.0.14271 またはそれ以降を実行しているデバイスのみで利用できます。

    このプロパティが **true** を返す場合、コントロールを表示にします。 次のコードは、[Button](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.button.aspx) に対してこの処理を実行する方法を示しています。

    [!code-cs[LaunchFeedback](./code/StoreSDKSamples/cs/FeedbackPage.xaml.cs#ToggleFeedbackVisibility)]
      > [!NOTE]
      > フィードバック Hub は現時点では Xbox デバイスではサポートされていませんが、Windows 10 のバージョン 10.0.14271 およびそれ以降を実行している Xbox デバイスでは **IsSupported** プロパティは現在 **true** を返します。 これは既知の問題で、Microsoft Store Services SDK の今後のリリースで修正される予定です。  

8. ユーザーがコントロールをクリックすると実行されるイベント ハンドラーで、[StoreServicesFeedbackLauncher](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicesfeedbacklauncher) オブジェクトを取得し、[LaunchAsync](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicesfeedbacklauncher.launchasync) の静的メソッドを呼び出して、フィードバック Hub アプリを起動します。 このメソッドには 2 つのオーバーロードがあります。1 つは、パラメーターのないオーバーロードで、もう 1 つは、フィードバックを関連付けるメタデータが含まれる、キーと値のペアのディクショナリを受け取るオーバーロードです。 次の例は、[ボタン](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Button)の [Click](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.primitives.buttonbase.click) イベント ハンドラーでフィードバック Hub を起動する方法を示しています。

    [!code-cs[LaunchFeedback](./code/StoreSDKSamples/cs/FeedbackPage.xaml.cs#FeedbackButtonClick)]

## <a name="design-recommendations-for-your-feedback-ui"></a>フィードバック UI の設計に関する推奨事項

フィードバック Hub を起動するために、Segoe MDL2 Assets フォントと文字コード E939 から次の標準のフィードバック アイコンを表示する UI 要素 (ボタンなど) をアプリに追加することをお勧めします。

![フィードバック アイコン](images/feedback_icon.PNG)

また、アプリでフィードバック Hub にリンクするための次の配置オプションを 1 つ以上使用することをお勧めします。
* **アプリ バー内で直接**。 実装に応じて、アイコンのみを使用するか、テキストを追加できます (以下に示すように)。

  ![フィードバック アイコン](images/feedback_appbar_placement.png)

* **アプリの設定内**。 これは、フィードバック Hub へのアクセスを提供するより巧妙な方法です。 次の例では、フィードバック リンクがアプリの下にあるリンクとして表示されています。

  ![フィードバック アイコン](images/feedback_settings_placement.png)

* **イベント駆動型のポップアップ内**。 これは、Windows フィードバック Hub を起動する前に、特定の質問についてユーザーにたずねる場合に便利です。 たとえば、ユーザーがアプリで特定の機能を使用した後、その機能の満足度に関する特定の質問を表示します。 ユーザーが質問に応答した場合、アプリでフィードバック Hub が起動します。


## <a name="related-topics"></a>関連トピック

* [フィードバック レポート](../publish/feedback-report.md)
