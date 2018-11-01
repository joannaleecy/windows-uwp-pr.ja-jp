---
author: muhsinking
Description: This tutorial walks through how to create a basic application user interface. It explains and demonstrates the use of Grid and StackPanel, two of the most common XAML elements.
title: Grid と StackPanel を使った単純な天気予報アプリの作成。
template: detail.hbs
ms.author: mukin
ms.date: 05/19/2017
ms.topic: article
keywords: windows 10、UWP
ms.assetid: 9794a04d-e67f-472c-8ba8-8ebe442f6ef2
ms.localizationpriority: medium
ms.openlocfilehash: 0327437c809455cf191dcfc572e4a5145b73eb49
ms.sourcegitcommit: cd00bb829306871e5103db481cf224ea7fb613f0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/31/2018
ms.locfileid: "5871039"
---
# <a name="tutorial-use-grid-and-stackpanel-to-create-a-simple-weather-app"></a>チュートリアル: Grid と StackPanel を使った単純な天気予報アプリの作成

ここでは、XAML の **Grid** 要素と **StackPanel** 要素を使って単純な天気予報アプリのレイアウトを作成します。 これらのツールを使用すると、Windows 10 が実行されたすべてのデバイスで動作する魅力ある外観のアプリを作成できます。 このチュートリアルの所要時間は 10 ～ 20 分です。

> **重要な API**:[ Grid クラス](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.grid)、[StackPanel クラス](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.stackpanel)

## <a name="prerequisites"></a>前提条件
- Windows 10 と Microsoft Visual Studio 2015 以降。 (最新の Visual Studio 推奨される現在の開発とセキュリティ更新プログラム)[ここをクリックすると、Visual Studio での設定を取得する方法について説明します](../../get-started/get-set-up.md)して。
- XAML と C# を使って基本的な "Hello World" アプリを作成する方法に関する知識。 必要に応じて[ここをクリックし、"Hello World" アプリの作成方法を学習してください](https://msdn.microsoft.com/windows/uwp/get-started/create-a-hello-world-app-xaml-universal)。

## <a name="step-1-create-a-blank-app"></a>手順 1: 空のアプリを作成する
1. Visual Studio のメニューで、**[ファイル]** > **[新しいプロジェクト]** を選択します。
2. **[新しいプロジェクト]** ダイアログ ボックスの左側のウィンドウで、**[Visual C#]** > **[Windows]** > **[ユニバーサル]** を選択するか、**[Visual C++]** > **[Windows]** > **[ユニバーサル]** を選択します。
3. 中央のウィンドウで、**[空のアプリケーション]** を選択します。
4. **[名前]** ボックスに「**WeatherPanel**」と入力し、**[OK]** を選択します。
5. プログラムを実行するには、メニューで **[デバッグ]** > **[デバッグの開始]** を選択するか、F5 を選択します。

## <a name="step-2-define-a-grid"></a>手順 2: Grid を定義する
XAML において、**Grid** は一連の行と列で構成されます。 **Grid** で要素の行と列を指定することで、ユーザー インターフェイス内に要素を配置し、他の要素との間の余白を設定できます。 行と列は、**RowDefinition** 要素と**ColumnDefinition** 要素で定義します。

レイアウトの作成を開始するには、**ソリューション エクスプローラー**を使って **MainPage.xaml** を開き、自動的に生成される **Grid** 要素を以下のコードに置き換えます。

```xml
<Grid>
    <Grid.ColumnDefinitions>
        <ColumnDefinition Width="3*"/>
        <ColumnDefinition Width="5*"/>
    </Grid.ColumnDefinitions>
    <Grid.RowDefinitions>
        <RowDefinition Height="2*"/>
        <RowDefinition Height="*"/>
    </Grid.RowDefinitions>
</Grid>
```

この新しい **Grid** によって 2 行 x 2 列のセットが作成され、このアプリ インターフェイスのレイアウトが定義されます。 2 つの列は、1 列目の **Width** が "3\*" で、2 列目が "5\*" です。したがって、水平方向の領域は、これら 2 つの列の間で 3:5 の比率で分割されます。 同様に、2 つの行はそれぞれの **Height** が "2\*" と "\*" です。したがって、この **Grid** では、1 行目に対し、2 行目の 2 倍の領域が割り当てられます ("\*" は "1\*" と同じです)。 これらの比率は、ウィンドウのサイズを変更したり、異なるデバイスを使ったりしても変わりません。

行や列のサイズを指定するその他の方法については、「[XAML を使ったページ レイアウトの定義](https://msdn.microsoft.com/windows/uwp/layout/layouts-with-xaml#layout-properties)」をご覧ください。

この時点では、**Grid** 領域にコンテンツがまったく含まれていないため、アプリケーションを実行しても空白のページが表示されるだけです。 そこで **Grid** を表示するために、色を付けることにします。

## <a name="step-3-color-the-grid"></a>手順 3: Grid に色を付ける
**Grid** に色を付けるために、ここでは異なる背景色を持つ 3 つの **Border** 要素を追加します。 また **Grid.Row** 属性と **Grid.Column** 属性を使って、各要素を親 **Grid** の行と列に割り当てます。 これらの属性は既定値が 0 であるため、最初の **Border** には属性値を割り当てる必要がありません。 **Grid** 要素の行と列の定義の後に、次のコードを追加します。

```xml
<Border Background="#2f5cb6"/>
<Border Grid.Column ="1" Background="#1f3d7a"/>
<Border Grid.Row="1" Grid.ColumnSpan="2" Background="#152951"/>
```

3 番目の **Border** で、**Grid.ColumnSpan** という追加の属性が使われていることに注意してください。これにより、この **Border** が下側の行の両方の列にスパンします。 同様の方法で **Grid.RowSpan** を使うことができ、これらの属性によって、任意の数の行や列に要素をスパンすることができます。 このようなスパンの左上隅は、常に、要素の属性で指定した **Grid.Column** と **Grid.Row** です。

ここでアプリを実行すると、結果が次のように表示されます。

![グリッドの色を付ける](images/grid-weather-1.png)

## <a name="step-4-organize-content-by-using-stackpanel-elements"></a>手順 4: StackPanel 要素を使ってコンテンツを配置する
この天気予報アプリの作成で使用する 2 番目の要素は、**StackPanel** です。 **StackPanel** は多くの基本的なアプリのレイアウトで使われている要素であり、複数の要素を上下または左右にスタックすることができます。

次のコードでは、2 つの **StackPanel** 要素を作成し、それぞれに 3 つの**TextBlocks** を設定しています。 これらの **StackPanel** 要素を、**Grid** の手順 3 で作成した **Border** 要素の下に追加します。 これにより、先ほど作成した色付きの **Grid** の上にこれらの **TextBlock** 要素が表示されます。

```xml
<StackPanel Grid.Column="1" Margin="40,0,0,0" VerticalAlignment="Center">
    <TextBlock Foreground="White" FontSize="25" Text="Today - 64° F"/>
    <TextBlock Foreground="White" FontSize="25" Text="Partially Cloudy"/>
    <TextBlock Foreground="White" FontSize="25" Text="Precipitation: 25%"/>
</StackPanel>
<StackPanel Grid.Row="1" Grid.ColumnSpan="2" Orientation="Horizontal"
            HorizontalAlignment="Center" VerticalAlignment="Center">
    <TextBlock Foreground="White" FontSize="25" Text="High: 66°" Margin="0,0,20,0"/>
    <TextBlock Foreground="White" FontSize="25" Text="Low: 43°" Margin="0,0,20,0"/>
    <TextBlock Foreground="White" FontSize="25" Text="Feels like: 63°"/>
</StackPanel>
```

最初の **Stackpanel** では、各 **TextBlock** が上から順に上下にスタックされます。 これは StackPanel の既定の動作であるため、**Orientation** 属性を設定する必要はありません。 2 番目の StackPanel では、子要素を左から右へ左右にスタックするために、**Orientation** 属性を "Horizontal" に設定しています。 またテキストを下側の **Border** 全体にわたって中央揃えで配置するためには、**Grid.ColumnSpan** 属性を "2" に設定する必要があります。

ここでアプリを実行すると、次のように表示されます。

![StackPanels を追加する](images/grid-weather-2.png)

## <a name="step-5-add-an-image-icon"></a>手順 5: 画像アイコンを追加する

最後にこの **Grid** の空のセクションに、今日の天気である "partially cloudy (晴れ時々曇り)" を表す画像を配置します。

次の画像をダウンロードし、"partially-cloudy" という名前の PNG ファイルとして保存します。

![Partially cloudy](images/partially-cloudy.PNG)

**ソリューション エクスプローラー**で **Assets** フォルダーを右クリックし、**[追加]** -> **[既存の項目...]** を選択します。ポップアップ表示されるブラウザーで partially-cloudy.png を見つけ、選択して **[追加]** を選択します。

次に **MainPage.xaml** で、手順 4 で指定した StackPanel の下に次の **Image** 要素を追加します。

```xml
<Image Margin="20" Source="Assets/partially-cloudy.png"/>
```

この画像は最初の行と列に配置されるため、**Grid.Row** 属性や **Grid.Column** 属性を設定する必要がなく、既定値の "0" をそのまま使うことができます。

以上で作業は終了です。 単純な天気予報アプリケーションのレイアウトが作成されました。 **F5** キーを押してアプリケーションを実行すると、次のように表示されます。

![天気予報ウィンドウのサンプル](images/grid-weather-3.PNG)

さらに理解を深めたい場合は、上のレイアウトを自由に変更して、天気データをさまざまな方法で表示してみてください。

## <a name="related-articles"></a>関連記事
UWP アプリのレイアウト設計の概要については、「[UWP アプリ設計の概要](https://msdn.microsoft.com/windows/uwp/layout/design-and-ui-intro)」をご覧ください。

さまざまな画面サイズに適応できるレスポンシブ レイアウトの作成については、「[XAML を使ったページ レイアウトの定義](https://msdn.microsoft.com/windows/uwp/layout/layouts-with-xaml)」をご覧ください。
