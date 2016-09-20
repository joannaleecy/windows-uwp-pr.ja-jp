---
author: mcleanbyron
ms.assetid: 3C03FDD8-FA61-4E7B-BDCA-3C29DFEA20E4
description: "Microsoft Store Engagement and Monetization SDK をインストールした後、このトピックの手順に従って、アプリで広告メディエーター コントロールを使います。"
title: "広告メディエーター コントロールの追加と使用"
ms.sourcegitcommit: 8c3f1997427a7c3d4f4b4b7acc876a2a091e4553
ms.openlocfilehash: a0d73b50207d251c079714265845a816f4ac23da

---

# 広告メディエーター コントロールの追加と使用


\[ Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください \]


[Microsoft Store Engagement and Monetization SDK をインストール](http://aka.ms/store-em-sdk)した後、このトピックの手順に従って、アプリで広告メディエーター コントロールを使います。 広告仲介で現在サポートされている広告ネットワークとプロジェクトの種類の一覧については、「[広告ネットワークの選択と管理](select-and-manage-your-ad-networks.md)」をご覧ください。

## プロジェクトに広告メディエーター コントロールを追加する


プロジェクトに広告メディエーター コントロールを追加するには:

1.  Visual Studio で、プロジェクトを開きます。
2.  広告の仲介によってサポートされているいずれかの [広告ネットワーク](select-and-manage-your-ad-networks.md) で既に収益を得ているアプリに広告の仲介を追加する場合は、事前に既存の広告の実装とそのすべての参照を削除してください。
3.  **ソリューション エクスプローラー**で、広告を表示するページを見つけ、ダブルクリックして、デザイナーで開きます。
4.  **[ツールボックス]** から新しい **AdMediatorControl** をデザイナーにドラッグします (必ず XAML コードではなくデザイナーにコントロールをドラッグしてください)。 広告を表示する場所にコントロールを配置します。 アプリの複数の領域に広告を表示する場合は、複数のコントロールを追加できます。

    **AdMediatorControl** は、**ツールボックス**の次の場所にあります。

    -   ユニバーサル Windows プラットフォーム (UWP) プロジェクトでは、**[AdMediator Universal]** セクションの **[AdMediatorControl]** を使います。
    -   C# または Visual Basic と XAML を使った Windows8.1 または Windows Phone 8.1 プロジェクトでは、**[AdMediator]** セクションの **[AdMediatorControl]** を使います。
    -   Windows Phone Silverlight プロジェクトでは、**[すべての Windows Phone コントロール]** セクションの **[AdMediatorControl]** を使います。

    > 
            **注**  C# または Visual Basic と XAML を使った UWP、Windows 8.1、または Windows Phone 8.1 プロジェクトで、最初に **AdMediatorControl** コントロールをデザイナーにドラッグしたときに、Visual Studio によって、必要な広告メディエーター アセンブリ参照がプロジェクトに追加されますが、コントロールはまだデザイナーに追加されていません。 コントロールを追加するには、Visual Studio によって表示されるメッセージで [OK] をクリックし、デザイナーが更新されるまで数秒待ちます。その後、もう一度コントロールをデザイナーにドラッグします。 それでもコントロールをデザイナーに正常に追加できない場合は、プロジェクトのターゲットが **[Any CPU]** (任意の CPU) ではなく、アプリに該当するプロセッサ アーキテクチャ (たとえば、**[x86]**) であることを確認します。 プロジェクトのビルド プラットフォームのターゲットを **[Any CPU]** (任意の CPU) にしている場合、このコントロールをデザイナーに追加できません。

5.  Visual Studio で、プロジェクトに広告メディエーター アセンブリ参照を追加し、現在のページに広告メディエーター コントロールの XAML (コントロールの一意の ID と名前など) を挿入します。 アセンブリ参照と XAML はターゲット プラットフォームによって異なります。 たとえば、ユニバーサル Windows プラットフォーム (UWP) アプリの場合、アセンブリ名は **Microsoft.AdMediator.Universal** であり、生成される XAML は次の例のようになります。

    ```xml
    // Code that gets added to the XAML page header
    xmlns:Universal="using:Microsoft.AdMediator.Universal"

    // Code that gets added for the ad mediator control
    <Universal:AdMediatorControl x:Name="AdMediator_3D4884"
      Grid.ColumnSpan="2" HorizontalAlignment="Left" Height="250"
      Id="AdMediator-Id-D1FDFDA7-EABB-474C-940C-ECA7FBCFF143" Margin="121,175,0,0"
      VerticalAlignment="Top" Width="300"/>
    ```

    **Name** 要素は、広告の仲介を構成するときにアプリ内の特定のコントロールを識別するのに便利です。 これは任意の名前に変更できますが、**Id** 要素は決して変更または複製しないでください。 この **Id** は、アプリ内のコントロールごとに一意である必要があります。

6.  必要に応じてコントロールのサイズと位置を調整します。 詳しくは、「[サイズと位置の調整](#adjust-size-and-position)」をご覧ください。

## 広告ネットワークを構成する

必要なすべてのコントロールを追加した後、接続済みサービスから広告ネットワークを構成できます。

> 
            **重要**  後で別の AdMediatorControl を追加した場合は、接続済みサービスからもう一度構成する必要があります。 そうしないと、新しいコントロールで広告の仲介を使用できません。

広告ネットワークを構成するには、次のように操作します。

1.  ソリューション エクスプローラーでプロジェクトの名前を右クリックし、**[追加]**、**[接続済みサービス]** の順にクリックして、 **[接続済みサービスの追加]** ウィンドウ (Visual Studio 2015) または **[サービス マネージャー]** ウィンドウ (Visual Studio 2013) を起動します。
2.  Visual Studio 2015 を使っている場合は、**[広告メディエーター]** をクリックし、**[構成]** をクリックして **[広告メディエーター]** ウィンドウを開きます。 Visual Studio 2013 を使っている場合は、**[サービス マネージャー]** の左側のウィンドウで、**[広告メディエーター]** をクリックします。

    AdMediator.config ファイルがプロジェクトに追加されます。 このファイルは、最初の広告ネットワーク構成の設定がプロジェクトでローカルに保存される場所です。

3.  **[広告メディエーター]** ウィンドウ (Visual Studio 2015) または **[サービス マネージャー]** ウィンドウ (Visual Studio 2013) で、**[広告ネットワークの選択]** を選び、使用する広告ネットワークを選んで、**[広告ネットワークの選択]** ウィンドウで **[OK]** をクリックします。

    > 
            **ヒント**  アプリですぐにすべてのネットワークを使う予定がない場合でも、アカウントがあるすべてのネットワークを追加することをお勧めします。 アプリ公開後は、コードを変更してアプリを再申請しなくても、デベロッパー センターで各広告ネットワークの利用頻度を構成 (または、使ったことがない広告ネットワークの使用を開始) できます。

    Visual Studio により、選択されている広告ネットワークに必要なアセンブリが取得され、それらのアセンブリ参照がプロジェクトに追加されます。 このプロセスが完了したら、**[フェッチの状態]** ダイアログ ボックスの **[OK]** をクリックします。

4.  **[広告メディエーター]** ウィンドウ (Visual Studio 2015) または **[サービス マネージャー]** ウィンドウ (Visual Studio 2013) で、オプションで各ネットワークを選び、**[構成]** をクリックして、アプリのテスト中に使う各ネットワークの構成情報を入力します。 この情報は、プロジェクトの AdMediator.config ファイルに保存されます。 この情報は、Windows デベロッパー センター ダッシュボードで広告ネットワークの動作を構成するときに変更できます。 詳しくは、「[アプリの提出と広告の仲介の構成](submit-your-app-and-configure-ad-mediation.md)」をご覧ください。
    > 
            **注**  この手順で構成情報を入力しなかった場合、開発用のコンピューター上 (UWP および Windows8.1 XAML アプリ) またはエミュレーターやデバイス上 (Windows Phone アプリ) でアプリを実行すると、自動的にテスト用の構成値が使われます。

5.  **[広告メディエーター]** (Visual Studio 2015) または **[サービス マネージャー]** (Visual Studio 2013) ウィンドウで、選択した各広告ネットワークが **[フェッチ: 完了]** と表示されていることを確認します。 **[OK]** をクリックして、プロジェクトへの変更内容を送信します。

> 
            **注**   後で Microsoft Store Engagement and Monetization SDK の新しいバージョンにアップグレードする場合は、**[接続済みサービス]** を再起動する必要があります。それにより、自動的に取得された広告ネットワークの DLL がすべて正しく更新されます。

### 必要な機能を宣言する

各広告ネットワークには、特定のアプリ機能が必要な場合があります。 そのような機能は各プロバイダーによって **[広告メディエーター]** (Visual Studio 2015 用) または **[サービス マネージャー]** (Visual Studio 2013 用) ウィンドウに表示されます。 広告を適切に表示できるように、必要なすべての機能をアプリのマニフェストで宣言してください。

次のスクリーンショットは、Windows8.1 または Windows Phone 8.1 XAML アプリの複数の広告ネットワークに必要な機能を示しています。

![すべての参照が取得済みと表示されているサービス マネージャー](images/ad-med-8.jpg)

次のスクリーンショットは、Windows Phone 8.1 Silverlight アプリの複数の広告ネットワークに必要な機能を示しています。

![すべての参照が取得済みと表示されているサービス マネージャー](images/ad-med-6.jpg)
### 広告ネットワークの DLL を手動で取得する

場合によっては、特定の DLL が取得されなかったことが示される可能性があります。 この場合、それらを手動で追加する必要があります。 個別のアセンブリをダウンロードするリンクを確認するには、「[広告ネットワークの選択と管理](select-and-manage-your-ad-networks.md)」をご覧ください。

> 
            **注**  DLL を手動で追加するときに、"より新しいバージョンのアセンブリまたは互換性のないアセンブリへの参照は、プロジェクトに追加できません" というエラー メッセージが表示される場合があります。 このエラーを解決するには、エクスプローラーで DLL を右クリックし、**[プロパティ]** をクリックします。 [セキュリティ] セクションで、**[ブロックの解除]** をクリックします。

![エラー メッセージを解決するための [ブロックの解除] ボタン](images/ad-med-4.png)
## サイズと位置を調整する

デザイナーまたは XAML コードでは、広告メディエーター コントロールのサイズと位置を構成できます。 このサイズが、広告ネットワークから表示するすべての広告を表示できる十分な大きさであることを確認してください。 キャンバス サイズが広告全体を表示できる十分な大きさでないことが検出されると、一部の広告ネットワークから広告が表示されない可能性があります。 広告ユニットのいずれかが既定のサイズより大きくなる場合は、最大の大きさの広告に合わせてキャンバスのサイズを調整できます。

コントロールをデザイナーにドラッグした場合の既定のコントロールのサイズは次のとおりです。

-   UWP および Windows 8.1 XAML: 幅 300 x 高さ 250
-   Windows Phone 8.1 XAML: 幅 400 x 高さ 67
-   Windows Phone 8 および Windows Phone 8.1 Silverlight: 幅 480 x 高さ 80

次に示すように、オプションの **Width** パラメーターと **Height** パラメーターを使って既定の広告サイズを上書きできます。

```CSharp
myAdMediatorControl.AdSdkOptionalParameters[AdSdkNames.Smaato]["Width"] = 400;
myAdMediatorControl.AdSdkOptionalParameters[AdSdkNames.Smaato]["Height"] = 80;
```

アプリのニーズに応じてさまざまなサイズと配置に対応できるように、各コントロールを配置する方法を指定することもできます。 一部の広告ネットワークについては、オプションのパラメーターを使って調整できます。 Microsoft advertising の広告を左下に配置する例を次に示します。

```CSharp
myAdMediatorControl.AdSdkOptionalParameters[AdSdkNames.MicrosoftAdvertising]["HorizontalAlignment"] = HorizontalAlignment.Left;
myAdMediatorControl.AdSdkOptionalParameters[AdSdkNames.MicrosoftAdvertising]["VerticalAlignment"] = VerticalAlignment.Bottom;
```

### Microsoft advertising 用にサポートされる広告サイズ

Microsoft advertising は、次のプラットフォームで実行されるアプリについて、Interactive Advertising Bureau (IAB) が推奨する次の標準サイズの広告のみをサポートします。

-   Windows 10 と Windows 8.1:
    -   160 x 600
    -   300 x 250
    -   300 x 600
    -   728 x 90
-   Windows10 Mobile、Windows Phone 8.1、WindowsPhone8:
    -   300 x 50
    -   320 x 50
    -   480 x 80 (このサイズは、Windows Phone Silverlight でのみサポートされます)
    -   640 x 100

指定したい広告メディエーター コントロールのサイズが、Microsoft advertising がサポートする広告サイズのいずれにも該当しない場合があります (たとえば、異なるサイズの方がアプリの UI により適している場合や、上記以外の広告サイズをサポートする他の広告ネットワークをターゲットにしている場合などに、こうした状況が発生します)。 他のサイズを指定するには、希望する正確なコントロール サイズをデザイナーまたは XAML コードに指定し、Microsoft advertising のオプション パラメーター **Width** および **Height** に対してコントロールの境界内に収まる、サポート対象の最も近いサイズを割り当てます。 コントロールはデザイナーで指定した正確なサイズで表示されますが、Microsoft advertising はオプション パラメーター **Width** および **Height** を使って指定したサイズに適合する広告を提供します。

たとえば、UWP アプリがあり、広告メディエーター コントロールを 300 x 300 サイズで表示する場合、デザイナーまたは XAML コードでコントロールを 300 x 300 に設定します。 その後、次のコードに示すように、Microsoft advertising のオプション パラメーター **Width** に 300、**Height** に 250 を割り当てます。

```CSharp
myAdMediatorControl.AdSdkOptionalParameters[AdSdkNames.MicrosoftAdvertising]["Width"] = 300;
myAdMediatorControl.AdSdkOptionalParameters[AdSdkNames.MicrosoftAdvertising]["Height"] = 250;
```

サイズ設定が Microsoft Advertising と互換性があることを検証するには、[広告の仲介の実装をテスト](test-your-ad-mediation-implementation.md)して、Microsoft Advertising のテスト広告が表示されることを確認します。

## 広告の仲介の一時停止、再開、無効化

アプリの実行中に、指定した任意の時間だけ広告の仲介を一時停止するには、AdMediatorControl.Pause() メソッドを使います。 その場合、AdMediatorControl.Resume() メソッドを呼び出して仲介を再開するまで、最新の広告が継続して表示されることに注意してください。

広告メディエーターを完全に無効にするには、AdMediatorControl.Disable() メソッドを使います。 このメソッドを使うと、表示されているすべての広告が削除され、メディエーターのメモリ使用量を最小限に抑えることができます。 AdMediatorControl.Resume() を呼び出して仲介を再開できますが、仲介を無効にしていた後では起動時間が通常より遅くなることに注意してください。

## タイムアウトを設定する

広告の仲介から広告ネットワークに広告を要求した後、その要求を破棄して別のネットワークへの要求を実行するまでの待機時間を秒数 (2 ～ 60) で指定できます。 既定では、すべての広告ネットワークのタイムアウトは 15 秒間です。

次のコードは、Microsoft Advertising のタイムアウト時間を指定する方法を示しています。 必要に応じてタイムアウト時間とネットワークを変更できます。

```CSharp
myAdMediatorControl.AdSdkTimeouts[AdSdkNames.MicrosoftAdvertising] = TimeSpan.FromSeconds(10);
```

> 
            **注**  代わりに、デベロッパー センター ダッシュボードの **[広告で収入を増やす]** ページでもタイムアウト値を設定できます。 コードとダッシュボードでタイムアウトを設定している場合は、コードで設定したその値がダッシュボードの値よりも優先されます。

## イベント処理

イベントをログに記録して広告の仲介のエラーをキャプチャするコードを追加すると、トラブルシューティングに役立ちます。 次のコード例は、コントロールから特定のイベントのイベント ハンドラーを追加します。

```CSharp
// add this during initialization of your app

    AdMediator_Bottom.AdSdkError += AdMediator_Bottom_AdError;
    AdMediator_Bottom.AdMediatorFilled += AdMediator_Bottom_AdFilled;
    AdMediator_Bottom.AdMediatorError += AdMediator_Bottom_AdMediatorError;
    AdMediator_Bottom.AdSdkEvent += AdMediator_Bottom_AdSdkEvent;

// and then add these functions

void AdMediator_Bottom_AdSdkEvent(object sender, Microsoft.AdMediator.Core.Events.AdSdkEventArgs e)
{
    Debug.WriteLine("AdSdk event {0} by {1}", e.EventName, e.Name);}

void AdMediator_Bottom_AdMediatorError(object sender, Microsoft.AdMediator.Core.Events.AdMediatorFailedEventArgs e)
{
    Debug.WriteLine("AdMediatorError:" + e.Error + " " + e.ErrorCode );
    // if (e.ErrorCode == AdMediatorErrorCode.NoAdAvailable)
    // AdMediator will not show an ad for this mediation cycle
}

void AdMediator_Bottom_AdFilled(object sender, Microsoft.AdMediator.Core.Events.AdSdkEventArgs e)
{
    Debug.WriteLine("AdFilled:" + e.Name);
}

void AdMediator_Bottom_AdError(object sender, Microsoft.AdMediator.Core.Events.AdFailedEventArgs e)
{
    Debug.WriteLine("AdSdkError by {0} ErrorCode: {1} ErrorDescription: {2} Error: {3}", e.Name, e.ErrorCode, e.ErrorDescription, e.Error);
}
```

## 広告ネットワークのハンドルされない例外を処理する

> 
            **注**  テストの過程で、特定の広告ネットワークでのハンドルされない例外が多数特定されました。これらの例外に関連してアプリのクラッシュが起きないように、アプリ内でこれらの例外を処理する必要があります。 以下のコード例をコピーして App.xaml.cs ファイルに貼り付けることをお勧めします。

C# および XAML を使っている UWP、Windows 8.1 または Windows Phone アプリ用に使うコード

```CSharp
// In App.xaml.cs file, register with the UnhandledException event handler.
UnhandledException += App_UnhandledException;

void App_UnhandledException(object sender, UnhandledExceptionEventArgs e)
   {
      if (e != null)
      {
         Exception exception = e.Exception;
         if (exception is NullReferenceException && exception.ToString().ToUpper().Contains("SOMA"))
         {
            Debug.WriteLine("Handled Smaato null reference exception {0}", exception);
            e.Handled = true;
            return;
         }
      }
// APP SPECIFIC HANDLING HERE

   if (Debugger.IsAttached)
      {
         // An unhandled exception has occurred; break into the debugger
         Debugger.Break();
      }
   }
```

Windows Phone Silverlight アプリ用に使うコード

```CSharp
// In App.xaml.cs file, register with the UnhandledException event handler.
UnhandledException += Application_UnhandledException;

// Code to execute on unhandled exceptions
private void Application_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
{
    if (e != null)
   {
       Exception exception = e.ExceptionObject;
       if ((exception is XmlException || exception is NullReferenceException) && exception.ToString().ToUpper().Contains("INNERACTIVE"))
       {
           Debug.WriteLine("Handled Inneractive exception {0}", exception);
           e.Handled = true;
           return;
       }
       else if (exception is NullReferenceException && exception.ToString().ToUpper().Contains("SOMA"))
       {
           Debug.WriteLine("Handled Smaato null reference exception {0}", exception);
           e.Handled = true;
           return;
       }
       else if ((exception is System.IO.IOException || exception is NullReferenceException) && exception.ToString().ToUpper().Contains("GOOGLE"))
      {
          Debug.WriteLine("Handled Google exception {0}", exception);
          e.Handled = true;
          return;
       }
       else if ((exception is NullReferenceException || exception is XamlParseException) && exception.ToString().ToUpper().Contains("MICROSOFT.ADVERTISING"))
       {
           Debug.WriteLine("Handled Microsoft.Advertising exception {0}", exception);
           e.Handled = true;
           return;
       }

   }
// APP SPECIFIC HANDLING HERE

if (Debugger.IsAttached)
   {
       // An unhandled exception has occurred; break into the debugger
       Debugger.Break();
   }
   //e.Handled = true;
}
```

## 関連トピック

* [広告ネットワークの選択と管理](select-and-manage-your-ad-networks.md)
* [広告の仲介の実装のテスト](test-your-ad-mediation-implementation.md)
* [アプリの提出と広告の仲介の構成](submit-your-app-and-configure-ad-mediation.md)
* [広告の仲介のトラブルシューティング](troubleshoot-ad-mediation.md)
 

 



<!--HONumber=Jun16_HO4-->


