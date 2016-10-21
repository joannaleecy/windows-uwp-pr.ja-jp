---
author: mcleanbyron
Description: "アプリからフィードバック Hub を起動してフィードバックを送信することをユーザーにお勧めできます。"
title: "アプリからのフィードバック Hub の起動"
ms.assetid: 070B9CA4-6D70-4116-9B18-FBF246716EF0
translationtype: Human Translation
ms.sourcegitcommit: ce0431243866125eff83569e3b9b1c75e0703358
ms.openlocfilehash: c0c55c78751a7990cc7690c2ba5975a57387989c

---

# アプリからのフィードバック Hub の起動

フィードバック Hub を起動するユニバーサル Windows プラットフォーム (UWP) アプリにコントロール (ボタンなど) を追加してフィードバックを送信することをユーザーにお勧めできます。 フィードバック Hub は、Windows およびインストール済みアプリでフィードバックを 1 か所で収集できるようにするプレインストール アプリです。 フィードバック Hub を介してアプリに送信されたすべてのユーザー フィードバックは、Windows デベロッパー センター ダッシュ ボードの[フィードバック レポート](../publish/feedback-report.md)で収集および表示されるため、ユーザーが送信した問題、提案、賛成票を 1 つのレポートで確認できます。

アプリからフィードバック Hub を起動するには、[Microsoft Store Services SDK](http://aka.ms/store-em-sdk) が提供する API を使用します。 この API を使用して、設計ガイドラインに準拠したアプリの UI 要素からフィードバック Hub を起動することをお勧めします。

>**注**&nbsp;&nbsp;フィードバック Hub は、Windows 10 バージョン 10.0.14271 以降を実行しているデバイスのみで利用できます。 フィードバック Hub がユーザーのデバイスで利用できる場合にのみ、アプリにフィードバック コントロールを表示することをお勧めします。 このトピックのコードは、これを実行する方法を示しています。

## アプリからフィードバック Hub を起動する方法

アプリからフィードバック Hub を起動するには、次の手順に従います。

1. [Microsoft Store Services SDK](http://aka.ms/store-em-sdk) をインストールします。 フィードバック Hub を起動するための API に加えて、この SDK は、アプリで A/B テストを行ったり、広告を表示したりすることなど、その他の機能のための API を提供します。 この SDK について詳しくは、「[Microsoft Store Services SDK](microsoft-store-services-sdk.md)」をご覧ください。
2. Visual Studio でプロジェクトを開きます。
3. ソリューション エクスプローラーで、プロジェクトの **[参照設定]** ノードを右クリックし、**[参照の追加]** をクリックします。
4. **[参照マネージャー]**で、**[ユニバーサル Windows]** を展開し、**[拡張機能]** をクリックします。
5. SDK の一覧で、**[Microsoft Engagement Framework]** の横にあるチェック ボックスをオンにして、**[OK]** をクリックします。
6. プロジェクトで、フィードバック Hub を起動するために、ユーザーに表示するボタンなどのコントロールを追加します。 コントロールを次のように構成することをお勧めします。
  * コントロールに表示するコンテンツのフォントを **Segoe MDL2 Assets** に設定します。
  * コントロールのテキストを 16 進数の Unicode 文字コード E939 に設定します。 これは、**Segoe MDL2 Assets** フォントで推奨されるフィードバック アイコンの文字コードです。
  * コントロールの可視性を非表示に設定します。

    > **注**&nbsp;&nbsp;フィードバック Hub は、Windows 10 バージョン 10.0.14271 以降を実行しているデバイスのみで利用できます。 フィードバック Hub がユーザーのデバイスで利用できる場合、既定でフィードバック コントロールを非表示にし、初期化コードのみにフィードバック コントロールを表示することをお勧めします。 次の手順は、この処理を実行する方法を示しています。

  次のコードは、上記のように構成されている[ボタン](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.button.aspx)の XAML 定義を示しています。

  ```xml
  <Button x:Name="feedbackButton" FontFamily="Segoe MDL2 Assets" Content="&#xE939;" HorizontalAlignment="Left" Margin="138,352,0,0" VerticalAlignment="Top" Visibility="Collapsed"  Click="feedbackButton_Click"/>
  ```
7. フィードバック コントロールをホストするアプリのページの初期化コードで、[StoreServicesFeedbackLauncher](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.storeservicesfeedbacklauncher.aspx) クラスの [IsSupported](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.storeservicesfeedbacklauncher.issupported.aspx) 静的メソッドを使用して、フィードバック Hub がユーザーのデバイスで利用できるかどうかを指定します。 このプロパティが **true** を返す場合、コントロールを表示にします。 次のコードは、[ボタン](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.button.aspx)に対してこの処理を実行する方法を示しています。

  ```CSharp
  if (Microsoft.Services.Store.Engagement.StoreServicesFeedbackLauncher.IsSupported())
  {
        this.feedbackButton.Visibility = Visibility.Visible;
  }
  ```

8. ユーザーがコントロールをクリックすると実行されるイベント ハンドラーで、[StoreServicesFeedbackLauncher](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.storeservicesfeedbacklauncher.aspx) オブジェクトを取得し、[LaunchAsync](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.storeservicesfeedbacklauncher.launchasync.aspx) の静的メソッドを呼び出して、フィードバック Hub アプリを起動します。 このメソッドには 2 つのオーバーロードがあります。1 つは、パラメーターのないオーバーロードで、もう 1 つは、フィードバックを関連付けるメタデータが含まれる、キーと値のペアのディクショナリを受け取るオーバーロードです。 次の例は、[ボタン](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.button.aspx)の [Click](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.buttonbase.click.aspx) イベント ハンドラーでフィードバック Hub を起動する方法を示しています。

  ```CSharp
  private async void feedbackButton_Click(object sender, RoutedEventArgs e)
  {
        var launcher = Microsoft.Services.Store.Engagement.StoreServicesFeedbackLauncher.GetDefault();
        await launcher.LaunchAsync();
  }
  ```

## フィードバック UI の設計に関する推奨事項

フィードバック Hub を起動するために、Segoe MDL2 Assets フォントと文字コード E939 から次の標準のフィードバック アイコンを表示する UI 要素 (ボタンなど) をアプリに追加することをお勧めします。

![]Feedback icon](images/feedback_icon.PNG)

また、アプリでフィードバック Hub にリンクするための次の配置オプションを 1 つ以上使用することをお勧めします。
* **アプリ バー内で直接**。 実装に応じて、アイコンのみを使用するか、テキストを追加できます (以下に示すように)。

  ![]Feedback icon](images/feedback_appbar_placement.png)

* **アプリの設定内**。 これは、フィードバック Hub へのアクセスを提供するより巧妙な方法です。 次の例では、フィードバック リンクがアプリの下にあるリンクとして表示されています。

  ![]Feedback icon](images/feedback_settings_placement.png)

* **イベント駆動型のポップアップ内**。 これは、Windows フィードバック Hub を起動する前に、特定の質問についてユーザーにたずねる場合に便利です。 たとえば、ユーザーがアプリで特定の機能を使用した後、その機能の満足度に関する特定の質問を表示します。 ユーザーが質問に応答した場合、アプリでフィードバック Hub が起動します。


## 関連トピック

* [フィードバック レポート](../publish/feedback-report.md)



<!--HONumber=Sep16_HO1-->


