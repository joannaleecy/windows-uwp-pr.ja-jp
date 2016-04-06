---
description: iOS から UWP への移行
Search.SourceType: ビデオ
title: iOS から UWP への移行
ms.assetid: 7a05751d-02df-4240-9ba5-d95f65a7a9c5
---

# iOS から UWP への移行

\[ Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください \]

**iOS 用 Windows ブリッジによる Objective-C コードの再利用**

-   このガイドの目的は、Windows 10 に iOS アプリを手動で移植できるようにすることです。 アプリ全体が Objective-C で作成されている場合は、iOS 用 Windows ブリッジを使うと、既存のコードの大半を再利用しながら、アプリを Windows 10 にすばやく移行できます。 iOS 用 Windows ブリッジにより、Objective-C のコードと iOS の API ライブラリを使って、Visual Studio 2015 でユニバーサル Windows プラットフォーム (UWP) アプリをビルドできます。 また、Cortana やライブ タイルなどの Windows 10 独自の機能を使って、Objective-C コードを拡張することもできます。
-   [iOS 用 Windows ブリッジについて詳しく知る](https://dev.windows.com/bridges/ios)

## Windows を選ぶ理由

iOS 向けに開発したアプリを Windows 10 と UWP に移行するにはどうすればよいでしょうか。 これは思っているほど難しくはありません。 iOS デバイスと同様に Windows でも (おそらくより快適に) 動作する優れたアプリの作成に必要なツール、手法、情報が用意されています。<iframe src="https://hubs-video.ssl.catalog.video.msn.com/embed/019d3337-80cf-4817-b50a-58f9463a4d27/IA?csid=ux-en-us&MsnPlayerLeadsWith=html&PlaybackMode=Inline&MsnPlayerDisplayShareBar=false&MsnPlayerDisplayInfoButton=false&iframe=true&QualityOverride=HD" width="720" height="405" allowFullScreen="true" frameBorder="0" scrolling="no">Windows と Windows Phone への Android アプリまたは iOS アプリの移植</iframe>

アプリの移行や、Windows 10 用の新しいアプリの開発を検討している場合は、役立つものがあります。 このセクションでは、iOS 開発者にとって有益な、Visual Studio とサンプル コードの使い方について紹介します。 Windows 10 用アプリの作成を楽しんでください。必ずできます。

コードを一度作成すると、デスクトップ、ノート PC、電話、ゲーム コンソール、埋め込みデバイス、ホログラフィック ディスプレイ上でも実行される世界を思い浮かべてみてください。 Windows 10 と UWP へようこそ。

![知られざる一面を訪れる](images/ios-to-uwp/mixedup.png)

既に Windows をご存知で、iOS も理解しようとするのであれば、Microsoft Visual Studio 2015 を見てみましょう。 Xamarin に基づいたモバイル アプリケーションの開発の統合サポートで、ペアリング済みの Mac コンピューターを使ってコードをコンパイルして実行し、Visual Studio 内から iOS デバイス向けのアプリを作成できるようになりました。 Visual Studio は、Windows、Android、iOS の間でコードと開発ツールを共有しながら、モバイル開発の世界の中心になることができます。
 

| トピック | 説明 |
|-------|-------------|
| [iOS と UWP のアプリ開発方法の選択](selecting-an-approach-to-ios-and-uwp-app-development.md) | クロスプラットフォーム アプリを開発するときの選択肢 |
| [iOS 開発者のための UWP の概要](getting-started-with-uwp-for-ios-developers.md) | この記事は、Windows 10 用の開発を検討している iOS 開発者向けに用意されています。 |
| [Windows 10 を使用するための Mac のセットアップ](setting-up-your-mac-with-windows-10.md) | 現在の Mac コンピューターを使用して、Windows 用アプリを開発します。 |

## 関連トピック

**設計者と開発者向け**
* [すべての Windows デバイスを対象としたユニバーサル Windows アプリの構築](http://go.microsoft.com/fwlink/p/?LinkID=397871)
* [Windows ストア アプリ設計のアセットのダウンロード](https://msdn.microsoft.com/library/windows/apps/xaml/bg125377.aspx)
 



<!--HONumber=Mar16_HO1-->


