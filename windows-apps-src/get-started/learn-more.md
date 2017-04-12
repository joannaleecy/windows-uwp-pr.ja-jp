---
author: GrantMeStrength
ms.assetid: 4288E511-581C-49DC-A2F2-1CB832C4A676
title: "次の手順"
description: "初めてのアプリの作成が終わったので、デベロッパー センターの他の部分を見てみましょう。 ここでは、デベロッパー センターの他の部分に含まれるさまざまなセクションについて説明します。"
keywords: "デベロッパー センター, デベロッパー センターの説明, 概要"
ms.author: jken
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
ms.openlocfilehash: 0c21257db05a058c2d92f32218b73d920cc7156c
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css">

# <a name="whats-next"></a>次の手順

アプリを作成して Windows ストアに公開するには、どこから手を着ければよいのでしょうか。 UWP プラットフォームでの開発が初めての場合は、<a href="https://channel9.msdn.com/">Channel 9</a> のビデオと <a href="https://mva.microsoft.com">Microsoft Virtual Academy</a> や [LinkedIn Learning](https://www.linkedin.com/topic/windows-programming) のコースをお試しください。 既に Windows での開発に関する知識がある場合は、以下のトピックを参照するか、直接[サンプルをダウンロード](https://msdn.microsoft.com/windows/uwp/get-started/get-uwp-app-samples)してください。

アプリの作成では、数多くの便利なツールやフレームワークを利用することができ、それらの多くがクロスプラットフォーム開発をサポートします。 たとえば、2D ゲームを作成する場合は、<a href="http://www.monogame.net">Monogame</a> の使用を検討してください。または、多くの [JavaScript/HTML フレームワーク](https://html5gameengine.com/)の中から一部を使うこともできます。 3D ゲームの開発用には <a href="http://www.unity3d.com">Unity</a> があり、モバイル デバイスが中心の場合は <a href="http://www.xamarin.com">Xamarin</a> が便利です。

ゲーム以外のアプリを初めて開発する場合は、まず、UWP 関連のトピックを通読して、UWP プラットフォームがどのようなものかを理解されることをお勧めします。そのうえで、XAML コントロールを使用し、さらにカスタマイズして、ユーザー インターフェイスを作成する方法をお調べください。 アプリのデザインには XAML を使います (使用方法について詳しくは、[このチュートリアル](../layout/grid-tutorial.md)をご覧ください)。しかし、XAML の真価は*データ バインディング*使用することです。データ バインディングは、アプリに表示する情報とコントロールを関連付けることができます。Windows プラットフォームでの開発が初めての場合、この概念を理解することが重要です。 
<table class="wdg-noborder">
<tr>
 <td width=60><img src="images/icon3.png" alt="Bullet point" width=64></td>
    <td><h2>UWP と UWP アプリのライフサイクル</h2><p>アプリが起動するしくみや、別のアプリを起動したときの処理はどのようになっているのでしょうか。 以下のトピックでは、それについて説明しています。</p> <ul>
    <li><a href="https://msdn.microsoft.com/windows/uwp/get-started/universal-application-platform-guide">ユニバーサル Windows プラットフォーム (UWP) アプリのガイド</a></li>
    <li><a href="https://msdn.microsoft.com/windows/uwp/launch-resume/app-lifecycle">UWP アプリのライフサイクル</a></li>
    <li><a href="https://developer.microsoft.com/windows/windows-10-for-developers">Windows 10 の優れた機能</a></ul></td>  
</tr>
<tr>
 <td width=60><img src="images/icon7.png" alt="Bullet point" width=64></td>
    <td><h2>UX と UI</h2><p>自由に使うことができるコントロールとその使い方を知りたい場合は、 以下のトピックをご覧ください。コントロールとコードが連携するしくみや、アプリの外観に合わせてコントロールをカスタマイズする方法を説明しています。</p> <ul>
    <li><a href="https://developer.microsoft.com/windows/design">設計と UI</a></li>
    <li><a href="https://msdn.microsoft.com/windows/uwp/layout/layouts-with-xaml">XAML を使ったページ レイアウトの定義</a></li>
    <li><a href="https://msdn.microsoft.com/windows/uwp/controls-and-patterns/controls-by-function">機能別コントロール</a></li>
      <li><a href="https://msdn.microsoft.com/windows/uwp/controls-and-patterns/controls-and-events-intro">コントロールとパターンの概要</a></li>
     <li><a href="https://msdn.microsoft.com/windows/uwp/controls-and-patterns/styling-controls">コントロールのスタイル</a></li>
      <li><a href="https://msdn.microsoft.com/windows/uwp/layout/screen-sizes-and-breakpoints-for-responsive-design">画面のサイズとレスポンシブ デザインのブレークポイント</a></li>
      <li><a href="https://developer.microsoft.com/windows/projects/campaigns/welcome-toolbox">事前に作成されたコントロールとパターンの選択に UWP コミュニティ ツールキットを使用する</a></li>
    </ul></td>  
</tr>
<tr>
 <td width=60><img src="images/icon6.png" alt="Bullet point" width=64></td>
    <td><h2>データとサービス</h2><p>コードによって自動的にリストやグリッドを設定できるデータ バインドについて説明します。 外部リソースにリンクして、データをアプリに取り込む方法を知ることができます。</p> <ul>
    <li><a href="https://msdn.microsoft.com/windows/uwp/data-binding/index">データ バインディング</a></li>
    <li><a href="https://msdn.microsoft.com/windows/uwp/controls-and-patterns/listview-and-gridview">ListViews、GridViews、およびデータ バインディング</a></li>
     <li><a href="https://msdn.microsoft.com/windows/uwp/data-access/index">データ アクセス</a></li>
    </ul></td>  
</tr>
<tr>
 <td width=60><img src="images/icon4.png" alt="Bullet point" width=64></td>
    <td><h2>公開</h2><p>作成したアプリを公開して、収益を得ましょう。 アプリがストアで公開されるようになるまでのプロセスを詳しく説明します。</p> <ul>
    <li><a href="https://msdn.microsoft.com/windows/uwp/publish/index">Windows アプリの公開</a></li>
    <li><a href="https://msdn.microsoft.com/windows/uwp/packaging/index">アプリのパッケージ化</a></li>
    </ul></td>  
</tr>
<tr>
 <td width=60><img src="images/icon2.png" alt="Bullet point" width=64></td>
    <td><h2>その他のリソース</h2><p>サンプル、チュートリアル、ビデオ、その他のツール、SDK を利用して、 アプリをレベル アップしましょう。</p>
    <ul>
    <li><a href="https://developer.microsoft.com/windows/develop">ハウツー記事</a></li>
    <li><a href="https://developer.microsoft.com/windows/samples">コード サンプル</a></li>
    <li><a href="https://msdn.microsoft.com/library/618ayhy6(VS.110).aspx">C# リファレンス</a></li>
    <li><a href="https://msdn.microsoft.com/library/windows/apps/bg124285.aspx">API リファレンス</a></li>
     <li><a href="https://msdn.microsoft.com/windows/uwp/xbox-apps/index">Xbox One 用アプリの作成</a></li>
     <li><a href="https://www.microsoft.com/microsoft-hololens/developers">HoloLens 向け開発</a></li>
     <li><a href="https://msdn.microsoft.com/windows/uwp/porting/index">Windows 10 へのアプリの移植</a></li>
      <li><a href="https://msdn.microsoft.com/windows/uwp/enterprise/index">エンタープライズ向けアプリの作成</a></li>
      <li><a href="https://blogs.windows.com/buildingapps/2016/08/17/introducing-the-uwp-community-toolkit/#D1IfVxCZMQGZqlc7.97">UWP コミュニティ ツールキット</a></li>
    </ul>
    </td>  
</tr>
</table>

<hr>

## <a name="windows-developer-blog"></a>Windows 開発者向けブログ

[Windows 開発者ブログ](https://blogs.windows.com/buildingapps)では、コーディング手法や、プロジェクトのアイデア、ツールに関する最新情報が定期的に投稿されています。 以下に、Windows 開発に関するお勧めの記事をいくつかご紹介します。

* [Animations with the Visual layer (ビジュアル レイヤーを使ったアニメーション)](https://blogs.windows.com/buildingapps/2016/09/16/animations-with-the-visual-layer/#JM2XkQcL7MRSXe3X.97)
* [Interop between XAML and the Visual layer (XAML とビジュアル レイヤー間の相互運用)](https://blogs.windows.com/buildingapps/2016/08/26/interop-between-xaml-and-the-visual-layer/#ue6O7MWpqrVFE81K.97)
* [Creating beautiful effects for UWP (UWP 向けの美しい効果の作成)](https://blogs.windows.com/buildingapps/2016/09/12/creating-beautiful-effects-for-uwp/#85jsfw6PFXX825rR.97)
* [Beautiful apps made possible and easy with Windows.UI (Windows UI で美しいアプリを簡単に作成)](https://blogs.windows.com/buildingapps/2016/08/23/beautiful-apps-made-possible-and-easy-with-windows-ui/#GBREkRSBwsRvi2uL.97)
* [Polishing your app with animation and audio cues (アニメーションとオーディオ キューを活用して洗練されたアプリを実現)](https://blogs.windows.com/buildingapps/2016/08/09/polishing-your-app-with-animations-and-audio-cues/#hziKxt2xPwUE1oqU.97) 
* [Adding color to your design (色を考慮したデザイン)](https://blogs.windows.com/buildingapps/2016/07/28/adding-color-to-your-design/#HcPqMlfPsuKETOIo.97)

<hr>

## <a name="finding-help-in-the-dev-center"></a>デベロッパー センターでのヘルプの検索

[docs.microsoft.com](http://docs.microsoft.com) サイトには、さまざまなツール、フレームワーク、およびプラットフォームについて大量のドキュメントがあります。 トピックやサンプルを参照するときは、UWP 関連のコンテンツを閲覧していることを確認してください。 UWP のリファレンスは [Windows デベロッパー センター](https://developer.microsoft.com/windows/apps)に用意されています。必要な API のリファレンスについては、[UWP アプリの開発に関するページ](https://docs.microsoft.com/uwp/api/)をご覧ください。
UWP に関するコンテンツを表示している場合、URL パスには **uwp** が含まれており、ページの上部にも次のようにパスが表示されます。

![UWP 関連のドキュメントの検索](images/UWP-docs.png)

検索エンジンを使う場合は、"Windows アプリ開発" を検索文字列に追加すると、UWP コンテンツが検索される可能性がかなり高くなります。


<hr>


## <a name="important-dev-center-topics"></a>重要なデベロッパー センターのトピック

以下は、デベロッパー センターのコンテンツの重要なセクションです。 


<table style="width:100%">
<colgroup>
<col width="20%" />
<col width="80%" />
</colgroup>


<tbody>

<tr class="even" style="background-color: #f2f2f2">
<td align="left"><strong>設計</strong></td>
<td align="left"><a href="http://go.microsoft.com/fwlink/p/?LinkId=533896">UWP アプリの設計ガイドライン</a></td>
</tr>


<tr class="odd" style="background-color: #ffffff">
<td align="left"><strong>開発</strong></td>
<td align="left"><a href="http://go.microsoft.com/fwlink/p/?LinkId=529575">アプリで使用できるさまざまな機能について詳しい情報とサンプル コードを提供しています。</a></td>
</tr>
<tr class="even" style="background-color: #f2f2f2">
<td align="left"><strong>言語リファレンス</strong></td>
<td align="left"><a href="https://msdn.microsoft.com/library/windows/apps/bg124285.aspx">UWP 開発に利用できるプログラミング言語のリファレンスを提供しています。</a></td>
</tr>
<tr class="odd" style="background-color: #ffffff">
<td align="left"><strong>ゲーム</strong></td>
<td align="left"><a href="http://go.microsoft.com/fwlink/p/?LinkId=534184">DirectX を使ったゲームの開発についての情報を提供しています。</a></td>
</tr>
<tr class="even" style="background-color: #f2f2f2">
<td align="left"><strong>モノのインターネット (Internet of Things: IoT)</strong></td>
<td align="left"><a href="http://go.microsoft.com/fwlink/p/?LinkId=534186">独自のコネクテッド デバイスを作成しましょう。</a></td>
</tr>
<tr class="odd" style="background-color: #ffffff">
<td align="left"><strong>移植</strong></td>
<td align="left"><a href="https://msdn.microsoft.com/library/windows/apps/Mt238321">Android と iOS のスキルを利用して UWP アプリをすばやく作成できます。</a></td>
</tr>
<tr class="even" style="background-color: #f2f2f2">
<td align="left"><strong>Windows ブリッジ</strong></td>
<td align="left"><a href="https://developer.microsoft.com/windows/bridges">以前のアプリや iOS アプリを更新して UWP アプリにするためのツールです。</a></td>
</tr>
<tr class="odd" style="background-color: #ffffff">
<td align="left"><strong>Xamarin</strong></td>
<td align="left"><a href="https://www.xamarin.com">C# を使って、iOS、Android、および Windows 10 用のアプリを作成できます。</a></td>
</tr>
<tr class="even" style="background-color: #f2f2f2">
<td align="left"><strong>タスクのスニペット</strong></td>
<td align="left"><a href="https://github.com/Microsoft/Windows-task-snippets">細かくても便利なタスクを実行できる、すぐに使用できるコードを提供しています。</a></td>
</tr>
<tr class="odd" style="background-color: #ffffff">
<td align="left"><strong>使い方に関するトピック</strong></td>
<td align="left"><a href="https://developer.microsoft.com/windows/develop">特定の UWP 機能についてのサンプル コードを提供しています。</a></td>
</tr>
<tr class="even" style="background-color: #f2f2f2">
<td align="left"><strong>ハードウェア</strong></td>
<td align="left"><a href="https://www.microsoftstore.com/store/msusa/en_US/cat/Developer/categoryID.69418300?icid=en_US_Store_UH_BusEd_Dev">Microsoft ストアの開発者向けハードウェア。</a></td>
</tr>
</table>






