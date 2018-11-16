---
author: mijacobs
Description: A tile is an app's representation on the Start menu. Every app has a tile. When you create a new Universal Windows Platform (UWP) app project in Microsoft Visual Studio, it includes a default tile that displays your app's name and logo.
title: タイル
ms.assetid: 09C7E1B1-F78D-4659-8086-2E428E797653
label: Tiles
template: detail.hbs
ms.author: mijacobs
ms.date: 05/19/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: f4388b67335bce497987ab22e3b281cf86e029af
ms.sourcegitcommit: e38b334edb82bf2b1474ba686990f4299b8f59c7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/15/2018
ms.locfileid: "6855746"
---
# <a name="tiles-for-uwp-apps"></a>UWP アプリのタイル

 

*タイル*とは、[スタート] メニュー上でアプリを表すものです。 すべてのアプリにはタイルがあります。 Microsoft Visual Studio で作成した新しいユニバーサル Windows プラットフォーム (UWP) アプリ プロジェクトには、アプリの名前とロゴを表示する既定のタイルが含まれます。このタイルは、アプリを初めてインストールしたときに Windows に表示されます。 アプリをインストールしたら、新しい情報 (ニュース ヘッドライン、最新の未読メッセージの件名など) をユーザーに伝えるようにタイルを変更するなど、通知を通じてタイルの内容を変更できます。

## <a name="configure-the-default-tile"></a>既定のタイルを構成する


Visual Studio で新しいプロジェクトを作成すると、アプリの名前とロゴを表示する単純な既定のタイルが作成されます。

タイルを編集するには、メインの UWP プロジェクトの **Package.appxmanifest** ファイルをダブル クリックし、デザイナーを開きます (またはファイルを右クリックして、[コードの表示] を選びます)。

```XML
  <Applications>
    <Application Id="App"
      Executable="$targetnametoken$.exe"
      EntryPoint="ExampleApp.App">
      <uap:VisualElements
        DisplayName="ExampleApp"
        Square150x150Logo="Assets\Square150x150Logo.png"
        Square44x44Logo="Assets\Square44x44Logo.png"
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

    ここに挙げた画像を、自分で用意したものに置き換えます。 さまざまな倍率に応じて複数の画像を指定することができますが、必ずしもすべて指定する必要はありません。 多種多様なデバイスでアプリを適切に表示するために、各画像の複数のスケール バージョン (100%、200%、400%) を用意することをお勧めします。 これらのアセットの生成について詳しくは、「[タイルとアイコン アセット](app-assets.md)」をご覧ください。

    拡大/縮小された画像の名前付け規則は次のとおりです。
    
    *&lt;画像名&gt;*.scale-*&lt;倍率&gt;*.*&lt;画像ファイルの拡張子&gt;* 

    例: SplashScreen.scale-100.png

    画像を参照するときには、*&lt;画像名&gt;*.*&lt;画像ファイルの拡張子&gt;* という形式で参照します (この例では "SplashScreen.png")。 指定した画像からデバイスに合わせて拡大/縮小された画像が自動的に選択されます。

-   強制ではありませんが、幅広で大きいタイル サイズに合ったロゴを用意して、ユーザーの側でアプリのタイルをそのサイズに変更できるようにすることを強くお勧めします。 追加の画像を指定するには、**DefaultTile** 要素を作成し、**Wide310x150Logo** および **Square310x310Logo** 属性を使って、その画像を指定します。
```    XML
  <Applications>
        <Application Id="App"
          Executable="$targetnametoken$.exe"
          EntryPoint="ExampleApp.App">
          <uap:VisualElements
            DisplayName="ExampleApp"
            Square150x150Logo="Assets\Square150x150Logo.png"
            Square44x44Logo="Assets\Square44x44Logo.png"
            Description="ExampleApp"
            BackgroundColor="#464646">
            <uap:DefaultTile
              Wide310x150Logo="Assets\Wide310x150Logo.png"
              Square310x310Logo="Assets\Square310x310Logo.png">
            </uap:DefaultTile>
            <uap:SplashScreen Image="Assets\SplashScreen.png" />
          </uap:VisualElements>
        </Application>
      </Applications>
```

## <a name="use-notifications-to-customize-your-tile"></a>通知を使ってタイルをカスタマイズする


アプリをインストールした後は、通知を使ってタイルをカスタマイズできます。 これは、アプリを初めてを起動したときや、プッシュ通知など、イベントへの応答として実行できます。

タイル通知を送信する方法については、「[ローカル タイル通知の送信](sending-a-local-tile-notification.md)」をご覧ください。
