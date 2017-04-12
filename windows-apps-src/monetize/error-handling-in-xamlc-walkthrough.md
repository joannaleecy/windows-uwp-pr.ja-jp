---
author: mcleanbyron
ms.assetid: cf0d2709-21a1-4d56-9341-d4897e405f5d
description: "アプリで AdControl エラーをキャッチする方法について説明します。"
title: "XAML/C# ウォークスルーでのエラー処理"
ms.author: mcleans
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, 広告, 宣伝, エラー処理, XAML, C#"
ms.openlocfilehash: d6c048397a5f7fd6c9a6cd625a7ff5ce0b6c29bf
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
# <a name="error-handling-in-xamlc-walkthrough"></a>XAML/C# ウォークスルーでのエラー処理

このトピックでは、アプリで [AdControl](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.adcontrol.aspx) エラーをキャッチする方法について説明します。

これらの例は、**AdControl** を含む XAML/C# アプリがあることを前提としています。 アプリに **AdControl** を追加する方法を示す具体的な手順については、「[XAML および .NET の AdControl](adcontrol-in-xaml-and--net.md)」をご覧ください。 C# と C++ を使って XAML アプリにバナー広告を追加する方法を示す完全なサンプル プロジェクトについては、「[GitHub の広告サンプル](http://aka.ms/githubads)」をご覧ください。

1.  MainPage.xaml ファイルで、**AdControl** の定義を見つけます。 コードは次のようになります。

  > [!div class="tabbedCodeSnippets"]
  ``` xml
  <UI:AdControl
      ApplicationId="3f83fe91-d6be-434d-a0ae-7351c5a997f1"
      AdUnitId="10865270"
      HorizontalAlignment="Left"
      Height="250"
      Margin="10,10,0,0"
      VerticalAlignment="Top"
      Width="300" />
  ```

2.   **Width** プロパティの後、終了タグの前で、エラー イベント ハンドラーの名前を [ErrorOccurred](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.adcontrol.erroroccurred.aspx) イベントに割り当てます。 このウォークスルーでは、エラー イベント ハンドラーの名前は **OnAdError** です。

  > [!div class="tabbedCodeSnippets"]
  ``` xml
  <UI:AdControl
      ApplicationId="3f83fe91-d6be-434d-a0ae-7351c5a997f1"
      AdUnitId="10865270"
      HorizontalAlignment="Left"
      Height="250"
      Margin="10,10,0,0"
      VerticalAlignment="Top"
      Width="300"
      ErrorOccurred="OnAdError"/>
  ```

2.  実行時にエラーを生成するために、2 つ目の **AdControl** を異なるアプリケーション ID を使って作成します。 アプリ内のすべての **AdControl** オブジェクトは同じアプリケーション ID を使う必要があるため、追加の **AdControl** を異なるアプリケーション ID を使って作成するとエラーがスローされます。

    MainPage.xaml で、最初の **AdControl** の直後に 2 つ目の **AdControl** を定義し、[ApplicationId](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.adcontrol.applicationid.aspx) プロパティをゼロ (“0”) に設定します。

    > [!div class="tabbedCodeSnippets"]
    ``` xml
    <UI:AdControl
        ApplicationId="0"
        AdUnitId="10865270"
        HorizontalAlignment="Left"
        Height="250"
        Margin="10,265,0,0"
        VerticalAlignment="Top"
        Width="300"
        ErrorOccurred="OnAdError" />
    ```

3.  MainPage.xaml.cs で、次の **OnAdError** イベント ハンドラーを **MainPage** クラスに追加します。 このイベント ハンドラーは、Visual Studio の **[出力]** ウィンドウに情報を書き込みます。

  > [!div class="tabbedCodeSnippets"]
  ``` csharp
  private void OnAdError(object sender, AdErrorEventArgs e)
  {
      System.Diagnostics.Debug.WriteLine("AdControl error (" + ((AdControl)sender).Name +
          "): " + e.ErrorMessage + " ErrorCode: " + e.ErrorCode.ToString());
  }
  ```

4.  プロジェクトをビルドして実行します。 アプリの実行後に、次のようなメッセージが Visual Studio の **[出力]** ウィンドウに表示されます。

  > [!div class="tabbedCodeSnippets"]
  ``` syntax
  AdControl error (): MicrosoftAdvertising.Shared.AdException: all ad requests must use the same application ID within a single application (0, d25517cb-12d4-4699-8bdc-52040c712cab) ErrorCode: ClientConfiguration
  ```

## <a name="related-topics"></a>関連トピック

* [GitHub の広告サンプル](http://aka.ms/githubads)

 
