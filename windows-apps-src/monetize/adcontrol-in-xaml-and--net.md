---
author: mcleanbyron
ms.assetid: 4e7c2388-b94e-4828-a104-14fa33f6eb2d
description: "Windows 10 (UWP) 用、Windows 8.1 用、Windows Phone 8.1 用の XAML アプリで AdControl クラスを使ってバナー広告を表示する方法について説明します。"
title: "XAML および .NET の AdControl"
ms.author: mcleans
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10、UWP、広告、宣伝、AdControl、XAML、.net、チュートリアル"
ms.openlocfilehash: 9db232709d3aa4ca1b7a6c6672cb2d1c1dea5049
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
# <a name="adcontrol-in-xaml-and-net"></a>XAML および .NET の AdControl


このチュートリアルでは、Windows 10 (UWP) 用、Windows 8.1 用、Windows Phone 8.1 用の XAML アプリで [AdControl](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.adcontrol.aspx) クラスを使ってバナー広告を表示する方法について説明します。 このチュートリアルでは **AdMediatorControl** (広告仲介) は使いません。

C# と C++ を使って XAML アプリにバナー広告を追加する方法を示す完全なサンプル プロジェクトについては、「[GitHub の広告サンプル](http://aka.ms/githubads)」をご覧ください。

## <a name="prerequisites"></a>前提条件

* UWP アプリ: Visual Studio 2015 と共に [Microsoft Store Services SDK](http://aka.ms/store-em-sdk) をインストールします。
* Windows 8.1 アプリまたは Windows Phone 8.1 アプリ: Visual Studio 2015 または Visual Studio 2013 と共に [Windows および Windows Phone 8.x 用の Microsoft Advertising SDK](http://aka.ms/store-8-sdk) をインストールします。

## <a name="code-development"></a>コード開発

1. Visual Studio でプロジェクトを開くか、新しいプロジェクトを作ります。

2. プロジェクトのターゲットが **[Any CPU]** (任意の CPU) になっている場合は、アーキテクチャ固有のビルド出力 (たとえば、**[x86]**) を使うようにプロジェクトを更新します。 プロジェクトのターゲットが **[Any CPU]** (任意の CPU) になっていると、次の手順で Microsoft Advertising ライブラリへの参照を正常に追加できません。 詳しくは、「[プロジェクトのターゲットを "Any CPU" に設定すると参照エラーが発生する](known-issues-for-the-advertising-libraries.md#reference_errors)」をご覧ください。

1.  **ソリューション エクスプローラー**のウィンドウで、**[参照設定]** を右クリックし、**[参照の追加]** を選択します。

2.  **[参照マネージャー]** で、プロジェクトの種類に応じて次のいずれかの参照を選択します。

    -   ユニバーサル Windows プラットフォーム (UWP) プロジェクトの場合: **[ユニバーサル Windows]** を展開し、**[拡張機能]** をクリックします。次に、**[Microsoft Advertising SDK for XAML]** (Version 10.0) の横のチェック ボックスをオンにします。

    -   Windows 8.1 プロジェクトの場合: **[Windows 8.1]** を展開し、**[拡張機能]** をクリックします。次に、**[Ad Mediator SDK for Windows 8.1 XAML]** の横のチェック ボックスをオンにします。 この場合、Microsoft Advertising ライブラリと広告メディエーター ライブラリの両方がプロジェクトに追加されますが、広告メディエーター ライブラリは無視してかまいません。

    -   Windows Phone 8.1 プロジェクトの場合: **[Windows Phone 8.1]** を展開し、**[拡張機能]** をクリックします。次に、**[Ad Mediator SDK for Windows Phone 8.1 XAML]** の横のチェック ボックスをオンにします。 この場合、Microsoft Advertising ライブラリと広告メディエーター ライブラリの両方がプロジェクトに追加されますが、広告メディエーター ライブラリは無視してかまいません。

  ![addreferences](images/13-a84c026e-b283-44f2-8816-f950a1ef89aa.png)

    > **注**&nbsp;&nbsp;この画像は、Windows 10 用 UWP プロジェクトを構築している Visual Studio 2015 の画像です。 Windows 8.1 または Windows Phone 8.1 のアプリを構築している場合や、Visual Studio 2013 を使っている場合は、画面が異なります。

3.  **[参照マネージャー]** で、[OK] をクリックします。
4.  広告を埋め込むページの XAML を変更して、**Microsoft.Advertising.WinRT.UI** 名前空間を追加します。 たとえば、Visual Studio によって生成される既定のサンプル アプリ (この例では MyAdFundedWindows10AppXAML という名前) では、**MainPage.XAML** という XAML ページに追加します。

  Visual Studio によって生成される MainPage.xaml ファイルの **Page** セクションには、次のようなコードが含まれています。

  > [!div class="tabbedCodeSnippets"]
  ``` xml
  <Page
      x:Class="MyAdFundedWindows10AppXAML.MainPage"
      xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
      xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
      xmlns:local="using:MyAdFundedWindows10AppXAML"
      xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
      xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
      mc:Ignorable="d">
      <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
      </Grid>
  </Page>
  ```

  **Microsoft.Advertising.WinRT.UI** 名前空間の参照を追加すると、MainPage.xaml ファイルの **Page** セクションのコードが次のようになります。

  > [!div class="tabbedCodeSnippets"]
  ``` xml
  <Page
      x:Class="MyAdFundedWindows10AppXAML.MainPage"
      xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
      xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
      xmlns:local="using:MyAdFundedWindows10AppXAML"
      xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
      xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
      xmlns:UI="using:Microsoft.Advertising.WinRT.UI"
      mc:Ignorable="d">
      <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
      </Grid>
  </Page>
  ```

5. **Grid** タグに、**AdControl** のコードを追加します。 **Page** の [ApplicationId](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.adcontrol.applicationid.aspx) プロパティと [AdUnitId](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.adcontrol.adunitid.aspx) プロパティに、「[Test mode values (テスト モードの値)](test-mode-values.md)」に示されているテスト値を割り当てます。 また、コントロールの高さと幅を、[バナー広告でサポートされている広告サイズ](supported-ad-sizes-for-banner-ads.md)のいずれかに合わせて調整します。

  > **注**&nbsp;&nbsp;アプリケーション ID と広告ユニット ID のテスト値は、アプリを申請のために提出する前に実際の値に置き換えます。

  完成した **Grid** タグのコードは、次のようになります。

  > [!div class="tabbedCodeSnippets"]
  ``` xml
  <Grid Background="{StaticResource ApplicationPageBackgroundThemeBrush}">
      <UI:AdControl ApplicationId="3f83fe91-d6be-434d-a0ae-7351c5a997f1"
            AdUnitId="10865270"
            HorizontalAlignment="Left"
            Height="250"
            VerticalAlignment="Top"
            Width="300"/>
  </Grid>
  ```

  MainPage.xaml ファイルの完全なコードは、次のようになります。

  > [!div class="tabbedCodeSnippets"]
  ``` xml
  <Page
      x:Class="MyAdFundedWindows10AppXAML.MainPage"
      xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
      xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
      xmlns:local="using:MyAdFundedWindows10AppXAML"
      xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
      xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
      xmlns:UI="using:Microsoft.Advertising.WinRT.UI"
      mc:Ignorable="d">
      <Grid Background="{StaticResource ApplicationPageBackgroundThemeBrush}">
            <UI:AdControl ApplicationId="3f83fe91-d6be-434d-a0ae-7351c5a997f1"
                  AdUnitId="10865270"
                  HorizontalAlignment="Left"
                  Height="250"
                  VerticalAlignment="Top"
                  Width="300"/>
        </Grid>
    </Page>
    ```

6.  アプリをコンパイルして実行し、広告が表示されることを確認します。

## <a name="release-your-app-with-live-ads-using-windows-dev-center"></a>Windows デベロッパー センターを使用して、ライブ広告を表示するアプリをリリースする

1.  デベロッパー センターのダッシュボードで、アプリの **[収益化]** &gt; **[広告で収入を増やす]** ページに移動し、[スタンドアロン Microsoft Advertising ユニットを作成](../publish/monetize-with-ads.md)します。 広告ユニットの種類として、**[バナー]** を指定します。 広告ユニット ID とアプリケーション ID の両方をメモしておきます。

2.  コードで、広告ユニットのテスト値 (**ApplicationId** と **AdUnitId**) を、デベロッパー センターで生成した実際の値に置き換えます。

3.  デベロッパー センター ダッシュボードを使用して、ストアに[アプリを申請](../publish/app-submissions.md)します。

4.  デベロッパー センター ダッシュボードで[広告パフォーマンス レポート](../publish/advertising-performance-report.md)を確認します。

## <a name="notes"></a>コメント

* C#: **AdControl** イベントにイベント ハンドラーを割り当てる例については、「[XAML プロパティの例](xaml-properties-example.md)」をご覧ください。 C# で書かれたイベント ハンドラーのサンプル コードについては、「[C# の AdControl イベント](adcontrol-events-in-c.md)」をご覧ください。

* C++: Microsoft Advertising ライブラリの現在のリリースは C++ をサポートしています。 **AdControl** クラスは、ネイティブ C++ で実装されており、.NET CLR を読み込みません。 C++ で **AdControl** を使用する方法を示すコード例については、[GitHub の広告サンプル](http://aka.ms/githubads)をご覧ください。

* Visual Basic: **AdControl** イベントにイベント ハンドラーを割り当てる例については、「[XAML プロパティの例](xaml-properties-example.md)」をご覧ください。

* エラー処理: エラー処理の方法については、「[AdControl エラーの処理](adcontrol-error-handling.md)」をご覧ください。

## <a name="related-topics"></a>関連トピック

* [GitHub の広告サンプル](http://aka.ms/githubads)

 
