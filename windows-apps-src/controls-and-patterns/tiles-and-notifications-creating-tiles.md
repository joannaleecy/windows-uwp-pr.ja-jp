---
author: mijacobs
Description: "タイルとは、[スタート] メニュー上でアプリを表すものです。 すべてのアプリにはタイルがあります。 Microsoft Visual Studio で作成した新しいユニバーサル Windows プラットフォーム (UWP) アプリ プロジェクトには、アプリの名前とロゴを表示する既定のタイルが含まれます。"
title: "タイル"
ms.assetid: 09C7E1B1-F78D-4659-8086-2E428E797653
label: Tiles
template: detail.hbs
translationtype: Human Translation
ms.sourcegitcommit: eb6744968a4bf06a3766c45b73b428ad690edc06
ms.openlocfilehash: 37de1a413ac9b5e74c905c140899ec7577a6fae5

---
# UWP アプリのタイル

<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css"> 

*タイル*とは、[スタート] メニュー上でアプリを表すものです。 すべてのアプリにはタイルがあります。 Microsoft Visual Studio で作成した新しいユニバーサル Windows プラットフォーム (UWP) アプリ プロジェクトには、アプリの名前とロゴを表示する既定のタイルが含まれます。 このタイルは、アプリを初めてインストールしたときに Windows に表示されます。 アプリをインストールしたら、新しい情報 (ニュース ヘッドライン、最新の未読メッセージの件名など) をユーザーに伝えるようにタイルを変更するなど、通知を通じてタイルの内容を変更できます。

## 既定のタイルを構成する


Visual Studio で新しいプロジェクトを作成すると、アプリの名前とロゴを表示する単純な既定のタイルが作成されます。

```XML
  <Applications>
    <Application Id="App"
      Executable="$targetnametoken$.exe"
      EntryPoint="ExampleApp.App">
      <uap:VisualElements
        DisplayName="ExampleApp"
        Square150x150Logo="Assets\Logo.png"
        Square44x44Logo="Assets\SmallLogo.png"
        Description="ExampleApp"
        BackgroundColor="#464646">
        <uap:SplashScreen Image="Assets\SplashScreen.png" />
      </uap:VisualElements>
    </Application>
  </Applications>
```

いくつか更新する必要がある項目があります。

-   DisplayName: この値はタイルに表示する名前に置き換えます。
-   ShortName: タイル上の表示名を収めるスペースには限りがあるため、アプリの名前が切り詰められないような名前を指定することをお勧めします。
-   ロゴ イメージ:

    ここに挙げた画像を、自分で用意したものに置き換えます。 さまざまな倍率に応じて複数の画像を指定することができますが、必ずしもすべて指定する必要はありません。 多種多様なデバイスでアプリを適切に表示するために、各画像の複数のスケール バージョン (100%、200%、400%) を用意することをお勧めします。

    拡大/縮小された画像の名前付け規則は次のとおりです: テスト
    
    *&lt;画像名&gt;*.scale-*&lt;倍率&gt;*.*&lt;画像ファイルの拡張子&gt;* 

    例: SmallLogo.scale-100.png

    画像を参照するときには、*&lt;画像名&gt;*.*&lt;画像ファイルの拡張子&gt;* という形式で参照します (この例では "SmallLogo.png")。 指定した画像からデバイスに合わせて拡大/縮小された画像が自動的に選択されます。

-   強制ではありませんが、幅広で大きいタイル サイズに合ったロゴを用意して、ユーザーの側でアプリのタイルをそのサイズに変更できるようにすることを強くお勧めします。 追加の画像を指定するには、`DefaultTile` 要素を作成し、`Wide310x150Logo` および `Square310x310Logo` 属性を使って、その画像を指定します。
```    XML
  <Applications>
        <Application Id="App"
          Executable="$targetnametoken$.exe"
          EntryPoint="ExampleApp.App">
          <uap:VisualElements
            DisplayName="ExampleApp"
            Square150x150Logo="Assets\Logo.png"
            Square44x44Logo="Assets\SmallLogo.png"
            Description="ExampleApp"
            BackgroundColor="#464646">
            <uap:DefaultTile
              Wide310x150Logo="Assets\WideLogo.png"
              Square310x310Logo="Assets\LargeLogo.png">
            </uap:DefaultTile>
            <uap:SplashScreen Image="Assets\SplashScreen.png" />
          </uap:VisualElements>
        </Application>
      </Applications>
```

## 通知を使ってタイルをカスタマイズする


アプリをインストールした後は、通知を使ってタイルをカスタマイズできます。 これは、アプリを初めてを起動したときや、プッシュ通知など、イベントへの応答として実行できます。

1.  タイルについて説明する XML ペイロード ([**Windows.Data.Xml.Dom.XmlDocument**](https://msdn.microsoft.com/library/windows/apps/br206173) の形式) を作成します。

    -   Windows 10 で新たにアダプティブ タイルのスキーマを使用できるようになりました。 手順については、「[アダプティブ タイル](tiles-and-notifications-create-adaptive-tiles.md)」をご覧ください。 スキーマについて詳しくは、「[アダプティブ タイルのスキーマ](tiles-and-notifications-adaptive-tiles-schema.md)」をご覧ください。 

    -   タイルの定義には、Windows 8.1 タイル テンプレートを使用できます。 詳しくは、「[タイルとバッジの作成 (Windows 8.1)](https://msdn.microsoft.com/library/windows/apps/xaml/hh868260)」をご覧ください。

2.  タイル通知オブジェクトを作成し、作成した [**XmlDocument**](https://msdn.microsoft.com/library/windows/apps/br206173) に渡します。 通知オブジェクトには、次のようなものがあります。
    -   タイルをすぐに更新するための [**Windows.UI.NotificationsTileNotification**](https://msdn.microsoft.com/library/windows/apps/br208616) オブジェクト。
    -   タイルを後の任意の時点で更新するための [**Windows.UI.Notifications.ScheduledTileNotification**](https://msdn.microsoft.com/library/windows/apps/hh701637) オブジェクト。

3.  [**Windows.UI.Notifications.TileUpdateManager.CreateTileUpdaterForApplication**](https://msdn.microsoft.com/library/windows/apps/br208623) を使って [**TileUpdater**](https://msdn.microsoft.com/library/windows/apps/br208628) オブジェクトを作成します。
4.  [**TileUpdater.Update**](https://msdn.microsoft.com/library/windows/apps/br208632) メソッドを呼び出して、手順 2. で作成したタイル通知オブジェクトに渡します。

 

 







<!--HONumber=Aug16_HO3-->


