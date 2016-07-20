---
author: mtoepke
title: "Windows 10 ゲーム開発ガイド"
description: "ユニバーサル Windows プラットフォーム (UWP) ゲーム開発のためのリソースや情報を網羅したガイドです。"
ms.assetid: 6061F498-96A8-44EF-9711-68AE5A1218C9
translationtype: Human Translation
ms.sourcegitcommit: a9beb420ac13eb74c0109b30508e49d5305bc67c
ms.openlocfilehash: 30f8408e6d125423e69615a3f9341e8f7d886fc8

---

# Windows 10 ゲーム開発ガイド


\[ Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください \]

Windows 10 ゲーム開発ガイドへようこそ。

このガイドでは、ユニバーサル Windows プラットフォーム (UWP) ゲームの開発に必要なリソースと情報を網羅したコレクションを提供します。

## ユニバーサル Windows プラットフォーム (UWP) 用ゲーム開発の概要


Windows 10 ゲームを作成すると、スマートフォンから PC、Xbox One にいたる数百万人のプレイヤーにゲームを提供するチャンスを得られます。 Windows の Xbox、Xbox Live、クロス デバイス マルチプレイヤー、すばらしいゲーム コミュニティ、ユニバーサル Windows プラットフォーム (UWP) や DirectX 12 などの強力な新機能により、Windows 10 ゲームは、あらゆる世代やジャンルのプレイヤーを楽しませるでしょう。 新しいユニバーサル Windows プラットフォーム (UWP) は、スマートフォン、PC、Xbox One 用の共通 API と、各デバイスのエクスペリエンスに合わせてゲームをカスタマイズするツールやオプションによって、Windows 10 デバイスでのゲームの互換性を実現します。

このガイドでは、ゲームの開発に役立つさまざまなリソースや情報を網羅して提供します。 必要なときに情報を検索する場所がわかるように、各セクションはゲームの開発の各段階に従って編成されています。

最初に、「[ゲーム開発に関するリソース](#resources)」セクションでは、ゲームの作成時に役立つドキュメント、プログラム、その他のリソースの大まかな概要を示します。

このガイドは、Windows 10 ゲーム開発に関する新しいリソースや資料が利用可能になると更新されます。

## ゲーム開発に関するリソース

ドキュメントから、開発者向けのプログラム、フォーラム、ブログ、サンプルまで、ゲーム開発に役立つ多くのリソースが用意されています。 ここでは、Windows 10 ゲームの開発を始めるにあたって役立つリソースをまとめています。

> 
              **注**   Xbox One の開発と高度な Windows 10 のゲーム機能 (Xbox Live サービスなど) は、ID@Xbox や Microsoft Studios などのプログラムによって管理されます。 このガイドでは幅広いリソースを取り上げているため、参加しているプログラムや特定の開発の役割によっては、一部のリソースにアクセスできない場合があります。 developer.xboxlive.com、forums.xboxlive.com、xdi.xboxlive.com、Game Developer Network (GDN) に解決されるリンクなどです。 Microsoft との提携について詳しくは、「[開発者プログラム](#programs)」をご覧ください。

### ゲーム開発に関するドキュメント

このガイド全体を通して、タスク、テクノロジ、ゲームの開発の段階ごとに整理された、関連ドキュメントへのディープ リンクを示しています。 利用可能なドキュメントのさまざまなビューを提供するために、Windows 10 ゲーム開発用の主要なドキュメント ポータルを次に示します。

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td>Windows デベロッパー センターのメイン ポータル</td>
        <td>[Windows デベロッパー センター](https://dev.windows.com)</td>
    </tr>
    <tr>
        <td>Windows アプリの開発</td>
        <td>[Windows アプリの開発](https://dev.windows.com/develop)</td>
    </tr>
    <tr>
        <td>ユニバーサル Windows プラットフォーム アプリの開発</td>
        <td>[Windows 10 アプリに関するハウツー ガイド](https://msdn.microsoft.com/library/windows/apps/mt244352)</td>
    </tr>
    <tr>
        <td>UWP ゲームに関する使い方ガイド</td>
        <td>[ゲームと DirectX](index.md) </td>
    </tr>
    <tr>
        <td>DirectX のリファレンスと概要</td>
        <td>[DirectX のグラフィックスとゲーミング](https://msdn.microsoft.com/library/windows/desktop/ee663274)</td>
    </tr>
    <tr>
        <td>Xbox Live に関するドキュメント</td>
        <td>[Xbox Live SDK](http://aka.ms/xsapi2)</td>
    </tr>
    <tr>
        <td>Xbox One 開発者向けドキュメント (GDN)</td>
        <td>[Xbox One XDK ドキュメント](https://developer.xboxlive.com/platform/development/documentation/Pages/home.aspx)</td>
    </tr>
    <tr>
        <td>Xbox One 開発者向けホワイト ペーパー (GDN)</td>
        <td>[ホワイト ペーパー](https://developer.xboxlive.com/platform/development/education/Pages/WhitePapers.aspx)</td>
    </tr>     
</table>

### 開発者プログラム

Microsoft では、Windows ゲームの開発と公開に役立ついくつかの開発者向けプログラムを提供しています。 Windows ストアでゲームを公開するには、Windows デベロッパー センターで開発者アカウントを作成する必要があります。 開発するゲームや制作スタジオのニーズによっては、他のプログラムも関心を集めており、Xbox One の開発や Xbox Live の統合などの機会を創造できます。

### Windows デベロッパー センター

Windows ゲームの公開に向けての最初の一歩は、Windows デベロッパー センターで開発者アカウントを登録することです。 開発者アカウントでは、ゲームの名前を予約することや、すべての Windows デバイスに対応する無料ゲームと有料ゲームを Windows ストアに提出することができます。 開発者アカウントを使って、ゲームとゲーム内製品を管理し、詳細な分析を取得したり、世界中のユーザーに優れたエクスペリエンスをサービスで実現することができます。

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td>開発者アカウントの登録</td>
        <td>[サインアップの準備はできましたか。](https://msdn.microsoft.com/library/windows/apps/bg124287)</td>
    </tr> 
</table>  


### ID@Xbox

ID@Xbox プログラムでは、認定されたゲーム開発者が Windows と Xbox One 向けに自分でゲームを公開するためのサポートを行います。 Xbox One 向けの開発を行ったり、ゲーマースコア、達成度、ランキングなどの Xbox Live 機能を自分の Windows 10 ゲームでも実現したいと検討されているなら、ID@Xbox にサインアップしてください。 ID@Xbox 開発者になると、創造性を解き放ち、成功の可能性を最大限に引き出すためのツールやサポートを利用できます。 ID@Xbox への登録を申し込む前に、Windows デベロッパー センターで開発者アカウントを登録してください。

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td>ID@Xbox 開発者プログラム</td>
        <td>[Xbox One 向けの独立した開発者プログラム](http://go.microsoft.com/fwlink/p/?LinkID=526271)</td>
    </tr>
    <tr>
        <td>ID@Xbox コンシューマー向けサイト</td>
        <td>[ID@Xbox](http://www.idatxbox.com/)</td>
    </tr>
</table>


### DirectX 早期アクセス プログラム

プロのゲーム開発者が、Direct3D 12 API の変更点を初期段階からプレビューする場合や、フォーラムでフィードバックを提供する場合は、DirectX 早期アクセス プログラムにご参加ください。

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td>DirectX 12 早期アクセス プログラムに登録する</td>
        <td>[DirectX 早期アクセス プログラム](http://1drv.ms/1dgelm6)</td>
    </tr>
</table>


### Xbox のツールとミドルウェア

Xbox のツールおよびミドルウェア プログラムは、ゲームのツールやミドルウェア専門の開発者に Xbox 開発キットのライセンスを付与します。 プログラムに受け入れられた開発者は、Xbox XDK テクノロジを共有し、ライセンスを持つ他の Xbox 開発者に配布することができます。

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td>ツールおよびミドルウェア プログラムについて問い合わせる</td>
        <td><xboxtlsm@microsoft.com></td>
    </tr>
</table>


### ゲームのサンプル

Windows 10 のゲーム機能を理解してゲーム開発をすぐに始めることができるように、Windows 10 のゲームとアプリのサンプルが数多く用意されています。 サンプルは次々と開発され、定期的に公開されるため、ときどきサンプル ポータルをチェックして、新機能を確認することを忘れないでください。 GitHub のリポジトリを[監視](https://help.github.com/articles/watching-repositories/)して、変更や追加についての通知を受け取ることもできます。

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td>ユニバーサル Windows プラットフォーム アプリのサンプル</td>
        <td>[Windows-universal-samples](https://github.com/Microsoft/Windows-universal-samples)</td>
    </tr>
    <tr>
        <td>Direct3D 12 グラフィックスのサンプル</td>
        <td>[DirectX グラフィックスのサンプル](https://github.com/Microsoft/DirectX-Graphics-Samples)</td>
    </tr>
    <tr>
        <td>Direct3D 11 主観視点のゲームのサンプル</td>
        <td>[DirectX によるシンプルな UWP ゲームの作成](tutorial--create-your-first-metro-style-directx-game.md)</td>
    </tr>
    <tr>
        <td>Direct2D カスタム画像効果のサンプル</td>
        <td>[D2DCustomEffects](http://go.microsoft.com/fwlink/p/?LinkId=620531)</td>
    </tr>
    <tr>
        <td>Direct2D グラデーション メッシュのサンプル</td>
        <td>[D2DGradientMesh](http://go.microsoft.com/fwlink/p/?LinkId=620532)</td>
    </tr>
    <tr>
        <td>Direct2D 写真調整のサンプル</td>
        <td>[D2DPhotoAdjustment](http://go.microsoft.com/fwlink/p/?LinkId=620533)</td>
    </tr>
    <tr>
        <td>Xbox One ゲームのサンプル (GDN)</td>
        <td>[サンプル](https://developer.xboxlive.com/platform/development/education/Pages/Samples.aspx)</td>
    </tr>
    <tr>
        <td>Windows 8 ゲームのサンプル (MSDN コード ギャラリー)</td>
        <td>[Windows ストア ゲームのサンプル](https://code.msdn.microsoft.com/windowsapps/site/search?f%5B0%5D.Type=SearchText&f%5B0%5D.Value=game&f%5B1%5D.Type=Contributors&f%5B1%5D.Value=Microsoft&f%5B1%5D.Text=Microsoft)</td>
    </tr>
    <tr>
        <td>JavaScript と HTML5 のゲームのサンプル</td>
        <td>[JavaScript と HTML5 のタッチ ゲームのサンプル](https://code.msdn.microsoft.com/windowsapps/JavaScript-and-HTML5-touch-d96f6031)</td>
    </tr>      
</table>


### 開発者フォーラム

開発者フォーラムは、ゲームの開発に関する質疑応答を行ったり、ゲーム開発コミュニティで交流を深めたりするのに適した場所です。 フォーラムは、他の開発者が過去に直面し、解決した困難な問題に対する既存の回答を見つけることができる、優れたリソースでもあります。

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td>Windows アプリ開発者フォーラム</td>
        <td>[Windows ストアとアプリ フォーラム](https://social.msdn.microsoft.com/Forums/home?category=windowsapps)</td>
    </tr>
    <tr>
        <td>UWP アプリ開発者フォーラム</td>
        <td>[ユニバーサル Windows プラットフォーム アプリの開発](https://social.msdn.microsoft.com/Forums/home?forum=wpdevelop)</td>
    </tr>

    <tr>
        <td>デスクトップ アプリケーション開発者フォーラム</td>
        <td>[Windows デスクトップ アプリケーション フォーラム](https://social.msdn.microsoft.com/Forums/home?category=windowsdesktopdev)</td>
    </tr>
    <tr>
        <td>DirectX Windows ストア ゲーム (アーカイブ済みのフォーラムの投稿)</td>
        <td>[DirectX を使った Windows ストア ゲームの構築 (アーカイブ済み)](https://social.msdn.microsoft.com/Forums/vstudio/home?forum=wingameswithdirectx)</td>
    </tr>
    <tr>
        <td>Windows 10 対象パートナー開発者フォーラム</td>
        <td>[XBOX 開発者フォーラム: Windows 10](http://aka.ms/win10devforums)</td>
    </tr>
    <tr>
        <td>DirectX 早期アクセス プログラムのフォーラム</td>
        <td>[DirectX 12 フォーラム](http://directx12forum.azurewebsites.net/index.php)</td>
    </tr>
</table>


### 開発者ブログ

開発者ブログは、ゲームの開発に関する最新情報が提供されるもう 1 つの優れたリソースです。 新機能、実装の詳細、ベスト プラクティス、アーキテクチャの背景などに関する投稿を見つけることができます。

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td>Windows 用アプリ開発ブログ</td>
        <td>[Windows 用アプリ開発](http://blogs.windows.com/buildingapps/)</td>
    </tr>
    <tr>
        <td>Windows 10 (ブログの投稿)</td>
        <td>[Windows 10 に関する投稿](http://blogs.windows.com/blog/tag/windows-10/)</td>
    </tr>
    <tr>
        <td>Visual Studio エンジニアリング チームのブログ</td>
        <td>[The Visual Studio Blog](http://blogs.msdn.com/b/visualstudio/)</td>
    </tr>
    <tr>
        <td>Visual Studio 開発者ツールに関するブログ</td>
        <td>[Developer Tools Blogs](http://blogs.msdn.com/b/developer-tools/)</td>
    </tr>
    <tr>
        <td>Somasegar の開発者ツールに関するブログ</td>
        <td>[Somasegar’s blog](http://blogs.msdn.com/b/somasegar/)</td>
    </tr>
    <tr>
        <td>DirectX 開発者ブログ</td>
        <td>[DirectX Developer blog](http://blogs.msdn.com/b/directx)</td>
    </tr>
    <tr>
        <td>DirectX 12 の概要 (ブログの投稿)</td>
        <td>[DirectX 12](http://blogs.msdn.com/b/directx/archive/2014/03/20/directx-12.aspx)</td>
    </tr>
    <tr>
        <td>Visual C++ ツール チームのブログ</td>
        <td>[Visual C++ team blog](http://blogs.msdn.com/b/vcblog/)</td>
    </tr>
    <tr>
        <td>ID@Xbox 開発者ブログ</td>
        <td>[ID@XBOX Developer Blog](http://www.idatxbox.com/category/developer-blog/)</td>
    </tr>
</table>
 

## 概念と計画


概念と計画の段階では、ゲームの全体像とそれを実現するために使用するテクノロジやツールを決定します。

### ゲーム開発テクノロジの概要

UWP のゲームの開発を開始するとき、グラフィックス、入力、オーディオ、ネットワーク、ユーティリティ、ライブラリについて、利用可能なオプションは複数あります。

ゲームで使うすべてのテクノロジが既に決定している場合は問題ありません。 まだ決まっていない場合、[UWP アプリのゲーム テクノロジ](game-development-platform-guide.md) ガイドに利用可能な多くのテクノロジの概要がまとめられています。このガイドに目を通して、さまざまなオプションとそれらを組み合わせる方法を理解しておくことを強くお勧めします。

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td>UWP のゲーム テクノロジの概要</td>
        <td>[UWP アプリのゲーム テクノロジ](game-development-platform-guide.md)</td>
    </tr>
</table>
 

次の 3 つの GDC 2015 のビデオは、Windows 10 のゲーム開発と Windows 10 のゲーム エクスペリエンスの概要を示しています。

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td>Windows 10 のゲーム開発の概要 (ビデオ)</td>
        <td>[Windows 10 のゲームの開発](http://channel9.msdn.com/Events/GDC/GDC-2015/Developing-Games-for-Windows-10)</td>
    </tr>
    <tr>
        <td>Windows 10 のゲーム エクスペリエンス (ビデオ)</td>
        <td>[Windows 10 でのゲームのユーザー エクスペリエンス](http://channel9.msdn.com/Events/GDC/GDC-2015/Gaming-Consumer-Experience-on-Windows-10)</td>
    </tr>
    <tr>
        <td>Microsoft エコシステム全体でのゲーム (ビデオ)</td>
        <td>[Microsoft エコシステム全体でのゲームの未来](http://channel9.msdn.com/Events/GDC/GDC-2015/The-Future-of-Gaming-Across-the-Microsoft-Ecosystem)</td>
    </tr>
</table>

### ゲームの計画

これらは、いくつかの高レベルの概念と、ゲームを計画するときに考慮する計画のトピックです。

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td>ゲームをアクセシビリティ対応にする</td>
        <td>[ゲームのアクセシビリティ](https://msdn.microsoft.com/windows/uwp/gaming/accessibility-for-games)</td>
    </tr>
    <tr>
        <td>ゲーム用のクラウドの使用</td>
        <td>[ゲーム用のクラウド](https://msdn.microsoft.com/windows/uwp/gaming/cloud-for-games)</td>
    </tr>
</table>



### グラフィックス テクノロジとプログラミング言語の選択

Windows 10 ゲームでは、複数のプログラミング言語やグラフィックス テクノロジを使うことができます。 どれを選ぶかは、開発しているゲームの種類、開発スタジオの経験や好み、ゲームの具体的な機能要件によって決まります。 C#、C++、JavaScript のどれを使うか、 DirectX、XAML、HTML5 のどれを使うかなどです。

#### DirectX

Microsoft DirectX を使うと、最高のパフォーマンスの 2D および 3D グラフィックスとマルチメディアを生み出すことができます。 

Windows 10 で新たに導入された Direct3D 12 は、コンソールに似た API の性能を備え、これまで以上に高速で効率的になりました。 開発するゲームで、最新のグラフィックス ハードウェアを十分に活用して、より多くのオブジェクト、より豊かなシーン、より印象的な効果を実現できます。 Direct3D 12 は、Windows 10 PC と Xbox One 向けに最適化されたグラフィックスを提供します。 Direct3D 11 の使い慣れたグラフィックス パイプラインを使う場合でも、Direct3D 11.3 に追加された新しいレンダリングおよび最適化機能を活かすことができます。 さらに、Win32 をルーツとする実証済みのデスクトップ Windows API の開発者は、Windows 10 でもそのオプションを選ぶことができます。

DirectX のさまざまな機能と緊密なプラットフォーム統合により、要求の多いほとんどのゲームに必要とされる性能とパフォーマンスを実現できます。

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td>DirectX ゲームに関する使い方ガイド</td>
        <td>[ゲームと DirectX](index.md)</td>
    </tr>
    <tr>
        <td>DirectX の概要とリファレンス</td>
        <td>[DirectX のグラフィックスとゲーミング](https://msdn.microsoft.com/library/windows/desktop/ee663274)</td>
    </tr>
    <tr>
        <td>Direct3D 12 プログラミング ガイドとリファレンス</td>
        <td>[Direct3D 12 グラフィックス](https://msdn.microsoft.com/library/windows/desktop/dn903821)</td>
    </tr>
    <tr>
        <td>グラフィックスおよび DirectX 12 開発に関するビデオ (YouTube チャンネル)</td>
        <td>[Microsoft DirectX 12 とグラフィックスに関する教育](https://www.youtube.com/channel/UCiaX2B8XiXR70jaN7NK-FpA)</td>
    </tr>
</table>
 

#### XAML

XAML は、アニメーション、ストーリーボード、データ バインディング、拡張性の高いベクター ベース グラフィックス、動的なサイズ変更、シーン グラフなどの便利な機能を備える、使いやすい宣言型 UI 言語です。 また、XAML はゲーム UI、メニュー、スプライト、2D グラフィックスに最適です。 UI レイアウトを簡単にするため、XAML には、Expression Blend や Microsoft Visual Studio などの設計および開発ツールとの互換性があります。 XAML はよく C# と同時に使用されますが、希望する言語が C++ の場合や、ゲームが多くの CPU を必要とする場合は、C++ も適しています。

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td>XAML プラットフォームの概要</td>
        <td>[XAML プラットフォーム](https://msdn.microsoft.com/library/windows/apps/mt228259)</td>
    </tr>
    <tr>
        <td>XAML UI とコントロール</td>
        <td>[コントロール、レイアウト、テキスト](https://msdn.microsoft.com/library/windows/apps/mt228348)</td>
    </tr>
</table>
 

#### HTML 5

ハイパーテキスト マークアップ言語 (HTML) は、Web ページ、アプリ、リッチ クライアントに使用される一般的な UI マークアップ言語です。 Windows ゲームでは、HTML の使い慣れた機能、ユニバーサル Windows プラットフォーム、AppCache、Web ワーカー、キャンバス、ドラッグ アンド ドロップ、非同期プログラミング、SVG などの最新の Web 機能のサポートを備えた、全機能装備のプレゼンテーション層として HTML5 を使うことができます。 HTML レンダリングの内部では、DirectX ハードウェア アクセラレータの機能が活用されるため、追加のコードを記述しなくても DirectX のパフォーマンスの恩恵を受けることができます。 Web 開発に熟練している場合、Web ゲームを移植する場合、または他の選択肢よりアプローチしやすい言語およびグラフィックス層を使う場合は、HTML5 が最適です。 HTML5 は JavaScript と同時に使用されますが、C# や C++/CX で作成されたコンポーネントを呼び出すこともできます。

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td>HTML5 とドキュメント オブジェクト モデルに関する情報</td>
        <td>[HTML と DOM のリファレンス](https://msdn.microsoft.com/library/windows/apps/br212882.aspx)</td>
    </tr>
    <tr>
        <td>HTML5 W3C 勧告</td>
        <td>[HTML5](http://go.microsoft.com/fwlink/p/?linkid=221374)</td>
    </tr>
</table>
 

#### プレゼンテーション テクノロジの組み合わせ

Microsoft DirectX Graphic Infrastructure (DXGI) には、複数のグラフィックス テクノロジにおける相互運用性と互換性が備わっています。 高パフォーマンスのグラフィックスを実現するため、メニューや他のシンプルな UI には XAML を使い、複雑な 2D および 3D シーンのレンダリングには DirectX を使うことで、XAML と DirectX を組み合わせることができます。 DXGI には、Direct2D、Direct3D、DirectWrite、DirectCompute、Microsoft メディア ファンデーション間の互換性も備わっています。

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td>DirectX Graphics Infrastructure のプログラミング ガイドとリファレンス</td>
        <td>[DXGI](https://msdn.microsoft.com/library/windows/desktop/hh404534)</td>
    </tr>
    <tr>
        <td>DirectX と XAML の組み合わせ</td>
        <td>[DirectX と XAML の相互運用機能](directx-and-xaml-interop.md)</td>
    </tr>
</table>
 

#### C++

C++/CX はオーバーヘッドの低い高パフォーマンスな言語であり、速度、互換性、プラットフォーム アクセスがうまく組み合わせられています。 C++/CX により、DirectX や Xbox Live など、Windows 10 のすばらしいゲーム機能すべてが使いやすくなります。 既にある C++ コードとライブラリを再利用することもできます。 C++/CX を使うと、ガベージ コレクションのオーバーヘッドを生じさせない高速なネイティブ コードが作成されるため、ゲームのパフォーマンスが向上し、電力消費が低くなり、結果としてバッテリ寿命が延びます。 C++/CX を DirectX または XAML と同時に使うか、両方の組み合わせを使って、ゲームを作成することができます。

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td>C++/CX のリファレンスと概要</td>
        <td>[Visual C++ 言語のリファレンス (C++/CX)](https://msdn.microsoft.com/library/windows/apps/hh699871.aspx)</td>
    </tr>
    <tr>
        <td>Visual C++ のプログラミング ガイドとリファレンス</td>
        <td>[Visual Studio 2015 の Visual C++](https://msdn.microsoft.com/library/60k1461a.aspx)</td>
    </tr>
</table>
 

#### C#

C# ("シー シャープ" と発音) は、タイプ セーフかつオブジェクト指向のシンプルで強力な最新の革新的言語です。 C# を使うと、C スタイル言語の親しみやすさと表現力を維持しながら短期間で開発できます。 C# は使いやすい言語ですが、ポリモーフィズム、デリゲート、ラムダ、クロージャ、反復子メソッド、共変性、統合言語クエリ (LINQ) 式など、多くの高度な言語機能が備わっています。 XAML をターゲットとする場合、ゲームの開発をすぐに始めたい場合、C# を既に使ったことがある場合、C# が最適です。 C# は主に XAML と同時に使われるめ、DirectX を使う場合は、代わりに C++ を選ぶか、ゲームの一部を DirectX とやり取りする C++ コンポーネントとして記述します。 または、C# と C++ 用の即時モード Direct2D グラフィックス ライブラリである [Win2D](https://github.com/Microsoft/Win2D) を使うことを検討します。

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td>C# のプログラミング ガイドとリファレンス</td>
        <td>[C# 言語のリファレンス](https://msdn.microsoft.com/library/kx37x362.aspx)</td>
    </tr>
</table>
 

#### JavaScript

JavaScript は、最新の Web アプリケーションやリッチ クライアント アプリケーションに広く使用されている動的なスクリプト言語です。

Windows JavaScript アプリは、ユニバーサル Windows プラットフォームの強力な機能に簡単かつ直感的な方法でアクセスできます (オブジェクト指向 JavaScript クラスのメソッドとプロパティとして)。 JavaScript は、Web 開発環境を使っていた場合、JavaScript に既に慣れている場合、HTML5、CSS、WinJS、または JavaScript ライブラリを使用する場合のゲーム開発に最適です。 DirectX や XAML をターゲットとする場合は、代わりに C# または C++/CX を選択してください。

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td>JavaScript と Windows ランタイムのリファレンス</td>
        <td>[JavaScript のリファレンス](https://msdn.microsoft.com/library/windows/apps/jj613794)</td>
    </tr>
</table>


#### Windows ランタイム コンポーネントを使って言語を組み合わせる

ユニバーサル Windows プラットフォームでは、異なる言語で記述されたコンポーネントを簡単に組み合わせることができます。 C++、C#、Visual Basic で Windows ランタイム コンポーネントを作成した後、JavaScript、C#、C++、Visual Basic から呼び出すことができます。 これは、好みの言語でゲームの一部をプログラミングする場合に最適な方法です。 コンポーネントにより、特定の言語でのみ使用可能な外部ライブラリや、既に記述しているレガシ コードを使うこともできるようになります。

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td>Windows ランタイム コンポーネントを作成する方法</td>
        <td>[Windows ランタイム コンポーネントの作成](https://msdn.microsoft.com/library/windows/apps/hh441572.aspx)</td>
    </tr>
</table>


### ゲームで使う Microsoft DirectX のバージョン

ゲームで DirectX を使うことを選んだ場合、使うバージョン (Microsoft Direct3D 12 または Microsoft Direct3D 11) を決定する必要があります。

Windows 10 で新たに導入された Direct3D 12 は、コンソールに似た API の性能を備え、これまで以上に高速で効率的になりました。 開発するゲームで、最新のグラフィックス ハードウェアを十分に活用して、より多くのオブジェクト、より豊かなシーン、より印象的な効果を実現できます。 Direct3D 12 は、Windows 10 PC と Xbox One 向けに最適化されたグラフィックスを提供します。 Direct3D 12 は非常に低いレベルで動作するため、専門的なグラフィックス開発チームや経験豊富な DirectX 11 開発チームは、グラフィックスの最適化を十分に活かすために必要となるすべてのコントロールを利用することができます。

Direct3D 11.3 は低レベル グラフィック API です。よく利用される Direct3D プログラミング モデルが使われており、GPU レンダリングに関連する多くの複雑な処理を扱うことができます。 また、Windows 10 と Xbox One でもサポートされています。 Direct3D 11 で作成されたエンジンを既にお持ちで、Direct3D 12 への切り替えの準備がまだ整っていない場合は、Direct3D 11 on 12 を使うことによって、ある程度のパフォーマンスの向上を実現することができます。 バージョン 11.3 以降には、Direct3D 12 でも利用可能な新しいレンダリングと最適化の機能が含まれています。

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td>Direct3D 12 または Direct3D 11 の選択</td>
        <td>[Direct3D 12 の概要](https://msdn.microsoft.com/library/windows/desktop/dn899228)</td>
    </tr>
    <tr>
        <td>Direct3D 11 の概要</td>
        <td>[Direct3D 11 グラフィックス](https://msdn.microsoft.com/library/windows/desktop/ff476080)</td>
    </tr>
    <tr>
        <td>Direct3D 11 on 12 の概要</td>
        <td>[Direct3D 11 on 12](https://msdn.microsoft.com/library/windows/desktop/dn913195)</td>
    </tr>
</table>


### ブリッジ、ゲーム エンジン、ミドルウェア

ゲームのニーズに応じて、ブリッジ、ゲーム エンジン、ミドルウェアを使うことにより、開発やテストに費やす時間やリソースを節約できます。 ここでは、ゲームの開発に適しているかどうかを判断できるように、ブリッジ、ゲーム エンジン、ミドルウェアの概要とリソースを示します。

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td>Windows 10 のブリッジとゲーム エンジン (ブログの投稿)</td>
        <td>[急成長する Windows 10 ストアにコードを移植するためのさまざまな方法](http://blogs.windows.com/buildingapps/2015/09/17/more-ways-to-bring-your-code-to-fast-growing-windows-10-store/)</td>
    </tr>
    <tr>
        <td>ミドルウェアを使ったゲーム開発 (ビデオ)</td>
        <td>[ミドルウェアによる Windows ストア ゲーム開発のスピードアップ](https://channel9.msdn.com/Events/Build/2013/3-187)</td>
    </tr>
    <tr>
        <td>Visual Studio と Unity、Unreal、Cocos2d (ブログの投稿)</td>
        <td>[ゲーム開発のための Visual Studio: Unity、Unreal Engine、Cocos2d との新しいパートナーシップ](http://blogs.msdn.com/b/somasegar/archive/2015/04/17/visual-studio-for-game-development-new-partnerships-with-unity-unreal-engine-and-cocos2d.aspx)</td>
    </tr>
    <tr>
        <td>ゲームのミドルウェアの概要 (ブログの投稿)</td>
        <td>[ゲーム開発ミドルウェア: 概要と 必要性](http://blogs.msdn.com/b/wsdevsol/archive/2014/05/02/game-development-middleware-what-is-it-do-i-need-it.aspx)</td>
    </tr>
</table>
 

#### ユニバーサル Windows プラットフォーム ブリッジ

ユニバーサル Windows プラットフォーム ブリッジは、既にあるアプリやゲームを UWP に移植するためのテクノロジです。 ブリッジは、すぐに UWP のゲーム開発の始めるときに最適な方法です。

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td>UWP ブリッジ</td>
        <td>[Windows にコードを移植する](https://dev.windows.com/bridges/)</td>
    </tr>
    <tr>
        <td>iOS 用 Windows ブリッジ</td>
        <td>[iOS アプリを Windows に移植する](https://dev.windows.com/bridges/ios)</td>
    </tr>
    <tr>
        <td>.NET および Win32 用 Windows ブリッジ ("Project Centennial") のプレビュー</td>
        <td>[Windows Developer Preview Programs](http://go.microsoft.com/fwlink/p/?LinkID=624543)</td>
    </tr>
</table>
 

#### Unity

Unity 5 は、2D および 3D ゲームと対話型エクスペリエンスを作成するための受賞歴のある次世代開発プラットフォームです。 Unity 5 により、新しい芸術性、高度なグラフィックス機能、高い効率性を手に入れることができます。

[Unity のロードマップ](https://unity3d.com/unity/roadmap)では、Unity の将来のバージョンで DirectX 12 のサポートが予定されています。

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td>Unity ゲーム エンジン</td>
        <td>[Unity - ゲーム エンジン](http://unity3d.com/)</td>
    </tr>
    <tr>
        <td>Unity 5 を入手する</td>
        <td>[Unity を入手する](http://unity3d.com/get-unity)</td>
    </tr>
    <tr>
        <td>Unity 5.2 でのユニバーサル Windows プラットフォーム アプリのサポート (ブログの投稿)</td>
        <td>[Unity 5.2 での Windows 10 ユニバーサル プラットフォーム アプリ](http://blogs.unity3d.com/2015/09/09/windows-10-universal-apps-in-unity-5-2/)</td>
    </tr>
    <tr>
        <td>Windows 向けの Unity に関するドキュメント</td>
        <td>[Unity マニュアル / Windows](http://docs.unity3d.com/Manual/Windows.mdl)</td>
    </tr>
    <tr>
        <td>ユニバーサル Windows プラットフォーム アプリとして Unity ゲームを公開する (ビデオ)</td>
        <td>[UWP アプリとして Unity ゲームを公開する方法](https://channel9.msdn.com/Blogs/One-Dev-Minute/How-to-publish-your-Unity-game-as-a-UWP-app)</td>
    </tr>
    <tr>
        <td>Unity を使って Windows 向けゲームとアプリを作成する (ビデオ)</td>
        <td>[Unity を使った Windows 向けゲームとアプリの作成](https://channel9.msdn.com/Blogs/One-Dev-Minute/Making-games-and-apps-with-Unity)</td>
    </tr>
    <tr>
        <td>Visual Studio を使った Unity ゲームの開発 (ビデオ シリーズ)</td>
        <td>[Visual Studio 2015 での Unity の使用](http://go.microsoft.com/fwlink/?LinkId=722359)</td>
    </tr>
</table>
 

#### Havok

Havok のモジュール化された一連のツールとテクノロジによって、ゲーム クリエーターは新しいレベルの対話式操作と没入感を提供できます。 Havok により、非常にリアルな物理的効果、対話型のシミュレーション、魅力的な映像を実現できます。

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td>Havok の Web サイト</td>
        <td>[Havok](http://www.havok.com/)</td>
    </tr>
    <tr>
        <td>Havok ツール スイート</td>
        <td>[Havok 製品の概要](http://www.havok.com/products/)</td>
    </tr>
    <tr>
        <td>Havok サポート フォーラム</td>
        <td>[Havok](https://software.intel.com/forums/havok/)</td>
    </tr>
</table>
 

#### Cocos2d

Cocos2d-X は、オープン ソース、クロス プラットフォームのゲーム開発エンジンおよびツール スイートで、UWP ゲームの構築をサポートしています。 バージョン 3 以降、3 D 機能も追加されています。

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td>Cocos2d-x</td>
        <td>[Cocos2d-X とは](http://www.cocos2d-x.org/)</td>
    </tr>
    <tr>
        <td>Cocos2d-x プログラマ ガイド</td>
        <td>[Cocos2d-x プログラマ ガイド v3.8](http://www.cocos2d-x.org/programmersguide/)</td>
    </tr>
    <tr>
        <td>Windows 10 での Cocos2d-x (ブログの投稿)</td>
        <td>[Windows 10 での Cocos2d-x の実行](https://blogs.windows.com/buildingapps/2015/06/15/running-cocos2d-x-on-windows-10/)</td>
    </tr>
    <tr>
        <td>Cocos2d-x Windows ストア ゲーム (ビデオ)</td>
        <td>[Cocos2d-x を使った Windows デバイス用ゲームの構築](http://www.microsoftvirtualacademy.com/training-courses/build-a-game-with-cocos2d-x-for-windows-devices)</td>
    </tr>
</table>


#### Unreal Engine

Unreal Engine 4 は、あらゆる種類のゲームや開発者に適したゲーム開発ツールがすべて揃ったスイートです。 最も要求の厳しいコンソールおよび PC ゲームにおいて、Unreal Engine は世界中のゲーム開発者により使用されています。 
              Unreal Engine 4 を購読している [DirectX 12 早期アクセス プログラム](#dxeap) メンバーは、DirectX をサポートする Unreal Engine 4.4 開発プロジェクトにアクセスできます。

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td>Unreal Engine の概要</td>
        <td>[Unreal Engine 4 とは](https://www.unrealengine.com/what-is-unreal-engine-4)</td>
    </tr>
</table>
 

### ミドルウェアとパートナー

ほかにも数多くのミドルウェアとエンジンのパートナーが、ゲーム開発のニーズに応じてソリューションを提供しています。

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td>Windows デベロッパー センターのゲーム分野のパートナー</td>
        <td>[デベロッパー センターのパートナー (ゲーム)](https://devcenterpartners.windows.com/directory#filter=gaming)</td>
    </tr>
    <tr>
        <td>Windows デベロッパー センターのパートナー</td>
        <td>[デベロッパー センターのパートナー](https://devcenterpartners.windows.com/directory)</td>
    </tr>
</table>
 

### ゲームの移植

既にゲームがある場合は、ゲームを短期間で UWP に移植するのに役立つ多くのリソースやガイドがあります。 移植作業をすぐに開始する場合は、[ユニバーサル Windows プラットフォーム ブリッジ](#uwp_bridges)を使うことも検討してください。

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td>Windows 8 アプリをユニバーサル Windows プラットフォーム アプリに移植する (ビデオ)</td>
        <td>[Windows ランタイム 8.x から UWP への移行](https://msdn.microsoft.com/library/windows/apps/mt238322)</td>
    </tr>
    <tr>
        <td>Windows 8 アプリをユニバーサル Windows プラットフォーム アプリに移植する (ビデオ)</td>
        <td>[8.1 アプリの Windows 10 への移植](https://channel9.msdn.com/Series/A-Developers-Guide-to-Windows-10/21)</td>
    </tr>
    <tr>
        <td>iOS アプリをユニバーサル Windows プラットフォーム アプリに移植する</td>
        <td>[iOS から UWP への移行](https://msdn.microsoft.com/library/windows/apps/mt238320)</td>
    </tr>
    <tr>
        <td>Silverlight アプリをユニバーサル Windows プラットフォーム アプリに移植する</td>
        <td>[Windows Phone Silverlight から UWP への移行](https://msdn.microsoft.com/library/windows/apps/mt238323)</td>
    </tr>
    <tr>
        <td>XAML または Silverlight からユニバーサル Windows プラットフォーム アプリに移植する (ビデオ)</td>
        <td>[XAML または Silverlight から Windows 10 へのアプリの移植](https://channel9.msdn.com/Events/Build/2015/3-741)</td>
    </tr>
    <tr>
        <td>Xbox ゲームをユニバーサル Windows プラットフォーム アプリに移植する</td>
        <td>[Xbox One から Windows 10 UWP への移植](https://developer.xboxlive.com/platform/development/education/Documents/Porting%20from%20Xbox%20One%20to%20Windows%2010.aspx)</td>
    </tr>
    <tr>
        <td>DirectX 9 から DirectX 11 に移植する</td>
        <td>[DirectX 9 からユニバーサル Windows プラットフォーム (UWP) への移植](porting-your-directx-9-game-to-windows-store.md)</td>
    </tr>
    <tr>
        <td>Direct3D 11 から Direct3D 12 に移植する</td>
        <td>[Direct3D 11 から Direct3D 12 に移植する](https://msdn.microsoft.com/library/windows/desktop/mt431709)</td>
    </tr>
    <tr>
        <td>OpenGL ES から Direct3D 11 に移植する</td>
        <td>[OpenGL ES 2.0 から Direct3D 11 への移植](port-from-opengl-es-2-0-to-directx-11-1.md)</td>
    </tr>
    <tr>
        <td>ANGLE を使って OpenGL ES から Direct3D 11 に移行する</td>
        <td>[ANGLE](http://go.microsoft.com/fwlink/p/?linkid=618387)</td>
    </tr>
    <tr>
        <td>UWP で従来の Windows API に相当する要素</td>
        <td>[ユニバーサル Windows プラットフォーム (UWP) アプリでの Windows API の代替](https://msdn.microsoft.com/library/windows/apps/hh464945)</td>
    </tr>
</table>


## プロトタイプとデザイン


作成するゲームの種類と、ゲームの構築に使うツールとグラフィックス テクノロジが決まったら、すぐにデザインとプロトタイプを開始できます。 ゲームのコアはユニバーサル Windows プラットフォーム アプリであるため、そこから作業を開始します。

### ユニバーサル Windows プラットフォーム (UWP) の概要

Windows 10 ではユニバーサル Windows プラットフォーム (UWP) が導入され、Windows 10 デバイス間で共通の API プラットフォームが提供されます。 UWP は、Windows ランタイム モデルを発展させて拡張したもので、まとまりのある統一されたコアとなっています。 UWP を対象とするゲームでは、すべてのデバイスに共通する WinRT API を呼び出すことができます。 UWP により保証されたコア API 層が提供されるため、あらゆる Windows 10 デバイスにインストールできる 1 つのアプリ パッケージを作成することもできます。 また、必要に応じて、ゲームが実行されるデバイスに固有の API (Win32 や .NET の従来の Windows API など) を、ゲームで呼び出すこともできます。

UWP の目的は、次のようなことを実現することです。

-   1 つのコア オペレーティング システム
-   1 つのアプリケーション プラットフォーム
-   1 つのゲーム ソーシャル ネットワーク
-   1 つのストア
-   1 つのインジェスト パス

次に示すガイドは、ユニバーサル Windows プラットフォーム アプリについて詳しく説明している優れたガイドであり、このプラットフォームを理解するために一読することをお勧めします。

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td>ユニバーサル Windows プラットフォーム アプリの概要</td>
        <td>[ユニバーサル Windows プラットフォーム アプリとは](https://msdn.microsoft.com/library/windows/apps/dn726767)</td>
    </tr>
    <tr>
        <td>UWP の概要</td>
        <td>[UWP アプリ ガイド](https://msdn.microsoft.com/library/windows/apps/dn894631)</td>
    </tr>
</table>
 

### UWP 開発の概要

ユニバーサル Windows プラットフォーム アプリを開発するための準備は非常に簡単です。 以下のガイドでは、プロセスの詳しい手順を説明しています。

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td>UWP 開発の概要</td>
        <td>[Windows アプリの概要](https://dev.windows.com/getstarted)</td>
    </tr>
    <tr>
        <td>UWP 開発の準備</td>
        <td>[準備](https://msdn.microsoft.com/library/windows/apps/dn726766)</td>
    </tr>
</table>

UWP プログラミングについて "文字どおりの初心者" である場合や、ゲームで XAML の使用を検討している場合 (「[グラフィックス テクノロジとプログラミング言語の選択](#choosing_technology)」を参照) は、最初に[文字どおりの初心者のための Windows 10 の開発](https://channel9.msdn.com/Series/Windows-10-development-for-absolute-beginners)に関するビデオ シリーズをご覧になることをお勧めします。

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td>XAML を使った Windows 10 の開発の初心者向けガイド (ビデオ シリーズ)</td>
        <td>[文字どおりの初心者のための Windows 10 の開発](https://channel9.msdn.com/Series/Windows-10-development-for-absolute-beginners)</td>
    </tr>
    <tr>
        <td>XAML を使う Windows 10 の初心者向けシリーズの発表 (ブログの投稿)</td>
        <td>[文字どおりの初心者のための Windows 10 の開発](http://blogs.windows.com/buildingapps/2015/09/30/windows-10-development-for-absolute-beginners/)</td>
    </tr>
</table>

### UWP 開発の概念

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td>ユニバーサル Windows プラットフォーム アプリの開発の概要</td>
        <td>[Windows アプリの開発](https://dev.windows.com/develop)</td>
    </tr>
    <tr>
        <td>UWP のネットワーク プログラミングの概要</td>
        <td>[ネットワークと Web サービス](https://msdn.microsoft.com/library/windows/apps/mt280378)</td>
    </tr>
    <tr>
        <td>ゲームでの Windows.Web.HTTP と Windows.Networking.Sockets の使用</td>
        <td>[ゲームのネットワーク](work-with-networking-in-your-directx-game.md)</td>
    </tr>
    <tr>
        <td>UWP での非同期プログラミングの概念</td>
        <td>[非同期プログラミング](https://msdn.microsoft.com/library/windows/apps/mt187335)</td>
    </tr>
</table>
 

### プロセス ライフタイム管理

プロセス ライフタイム管理、つまりアプリのライフ サイクルは、ユニバーサル Windows プラットフォーム アプリが取り得るさまざまなアクティブ化状態を表します。 ゲームは、アクティブ化、中断、再開、または終了することができ、さまざまな方法でこれらの状態を移行できます。

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td>アプリのライフ サイクルの移行の処理</td>
        <td>[アプリのライフサイクル](https://msdn.microsoft.com/library/windows/apps/mt243287)</td>
    </tr>
    <tr>
        <td>Microsoft Visual Studio を使ったアプリの移行のトリガー</td>
        <td>[Visual Studio で Windows ストア アプリの一時停止イベント、再開イベント、バックグラウンド イベントをトリガーする方法](https://msdn.microsoft.com/library/hh974425.aspx)</td>
    </tr>
</table>
 

### ゲーム UX の設計

優れたゲームはすばらしいデザインから始まります。

ゲームは、共通のユーザー インターフェイス要素とデザイン原則をアプリと共有していますが、ユーザー エクスペリエンスの外観、機能、設計目標が独特であることがよくあります。 テストされた UX をゲームで使用すべきなのはいつか、斬新で革新的な UX を使用すべきなのはいつか、という両方の側面に、よく考えられたデザインを当てはめるときにゲームは成功します。 ゲームに選択したプレゼンテーション テクノロジ (DirectX、XAML、HTML5、または 3 つの組み合わせ) は、実装の細部に影響を与える可能性がありますが、適用するデザイン原則はその選択とはほとんど関係がありません。

UX デザインとは別に、レベルのデザイン、ペース配分、世界のデザインなどのゲームプレイのデザインには独自の様式があり、開発者や開発チームによって決定されるため、この開発ガイドに記載していません。

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td>UWP の設計の基本とガイドライン</td>
        <td>[UWP アプリの設計](https://dev.windows.com/design)</td>
    </tr>
    <tr>
        <td>アプリのライフサイクルの状態の設計</td>
        <td>[起動、中断、再開の UX ガイドライン](https://msdn.microsoft.com/library/windows/apps/dn611862)</td>
    </tr>
    <tr>
        <td>複数のデバイスのフォーム ファクターをターゲットに設定する (ビデオ)</td>
        <td>[Windows コアの世界向けのゲームの設計](http://channel9.msdn.com/Events/GDC/GDC-2015/Designing-Games-for-a-Windows-Core-World)</td>
    </tr>
</table>
 

#### 色のガイドラインとパレット

ゲームで一貫した色のガイドラインに従うと、美しさやナビゲーションの操作性が向上し、メニューや HUD の機能がプレイヤーに伝わりやすくなります。 警告、ダメージ、XP、成績などのゲーム要素の色が一貫していると、UI がわかりやすくなるため、ラベルによって説明する必要性が減ります。

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td>色のガイド</td>
        <td>[ベストプラクティス: 色](https://assets.windowsphone.com/499cd2be-64ed-4b05-a4f5-cd0c9ad3f6a3/101_BestPractices_Color_InvariantCulture_Default.zip)</td>
    </tr>
</table>
 

#### 文字体裁

文字体裁を適切に使うと、UI のレイアウト、ナビゲーション、読みやすさ、雰囲気、ブランド、プレイヤーの熱中度など、多くの側面が向上します。

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td>文字体裁のガイド</td>
        <td>[ベスト プラクティス: 文字体裁](http://go.microsoft.com/fwlink/?LinkId=535007)</td>
    </tr>
</table>
 

#### UI マップ

UI マップとは、ゲーム ナビゲーションのレイアウトとフローチャートで表されるメニューのことです。 UI マップを使うと、すべての関係者が、ゲームのインターフェイスとナビゲーション パスを理解しやすくなり、開発サイクルの初期段階で潜在的な障害や行き詰まりが明らかになります。

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td>UI マップ ガイド</td>
        <td>[ベスト プラクティス: UI マップ](http://go.microsoft.com/fwlink/?LinkId=535008)</td>
    </tr>
</table>
 

### DirectX 開発

DirectX ゲーム開発用のガイドと参照情報を紹介します。

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td>UWP での DirectX ゲームの開発</td>
        <td>[ゲームと DirectX](index.md)</td>
    </tr>
    <tr>
        <td>UWP アプリ モデルによる DirectX の操作</td>
        <td>[アプリ オブジェクトと DirectX](about-the-metro-style-user-interface-and-directx.md)</td>
    </tr>
    <tr>
        <td>グラフィックスおよび DirectX 12 開発に関するビデオ (YouTube チャンネル)</td>
        <td>[Microsoft DirectX 12 とグラフィックスに関する教育](https://www.youtube.com/channel/UCiaX2B8XiXR70jaN7NK-FpA)</td>
    </tr>
    <tr>
        <td>DirectX の概要とリファレンス</td>
        <td>[DirectX のグラフィックスとゲーミング](https://msdn.microsoft.com/library/windows/desktop/ee663274)</td>
    </tr>
    <tr>
        <td>Direct3D 12 プログラミング ガイドとリファレンス</td>
        <td>[Direct3D 12 グラフィックス](https://msdn.microsoft.com/library/windows/desktop/dn903821)</td>
    </tr>
    <tr>
        <td>DirectX 12 の基本事項 (ビデオ)</td>
        <td>[強化されたパワーとパフォーマンスの向上: DirectX 12 でのゲーム](http://channel9.msdn.com/Events/GDC/GDC-2015/Better-Power-Better-Performance-Your-Game-on-DirectX12)</td>
    </tr>
</table>

#### Direct3D 12 について

Direct3D 12 での変更点、および Direct3D 12 を使ってプログラミングを開始する方法について説明します。 

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td>プログラミング環境のセットアップ</td>
        <td>[Direct3D 12 プログラミング環境のセットアップ](https://msdn.microsoft.com/library/windows/desktop/dn899120.aspx)</td>
    </tr>
    <tr>
        <td>基本的なコンポーネントを作成する方法</td>
        <td>[Direct3D 12 の基本的なコンポーネントの作成](https://msdn.microsoft.com/library/windows/desktop/dn859356.aspx)</td>
    </tr>
    <tr>
        <td>Direct3D 12 での変更点</td>
        <td>[Direct3D 11 から Direct3D 12 に移行された重要な変更点](https://msdn.microsoft.com/library/windows/desktop/dn899194.aspx)</td>
    </tr>
    <tr>
        <td>Direct3D 11 から Direct3D 12 に移植する方法</td>
        <td>[Direct3D 11 から Direct3D 12 に移植する](https://msdn.microsoft.com/library/windows/desktop/mt431709.aspx)</td>
    </tr>
    <tr>
        <td>リソース バインディングの概念 (対象となる記述子、記述子テーブル、記述子ヒープ、およびルート署名) </td>
        <td>[Direct3D 12 でのリソース バインディング](https://msdn.microsoft.com/library/windows/desktop/dn899206.aspx)</td>
    </tr>
    <tr>
        <td>メモリ管理</td>
        <td>[Direct3D 12 でのメモリ管理](https://msdn.microsoft.com/library/windows/desktop/dn899198.aspx)</td>
    </tr>
</table>
 
#### DirectX ツール キットとライブラリ

DirectX ツール キット、DirectX テクスチャ処理ライブラリ、DirectXMesh ジオメトリ処理ライブラリ、UVAtlas ライブラリ、DirectXMath ライブラリは、DirectX 開発用のテクスチャ、メッシュ、スプライト、その他のユーティリティ機能とヘルパー クラスを提供します。 これらのライブラリは、開発にかかる時間と労力を減らすのに役立ちます。

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td>DirectX 11 用 DirectX ツール キットを入手する</td>
        <td>[DirectXTK](http://go.microsoft.com/fwlink/?LinkId=248929)</td>
    </tr>
    <tr>
        <td>DirectX 12 用 DirectX ツール キットを入手する</td>
        <td>[DirectXTK 12](http://go.microsoft.com/fwlink/?LinkID=615561)</td>
    </tr>
    <tr>
        <td>DirectX テクスチャ処理ライブラリを入手する</td>
        <td>[DirectXTex](http://go.microsoft.com/fwlink/?LinkId=248926)</td>
    </tr>
    <tr>
        <td>DirectXMesh ジオメトリ処理ライブラリを入手する</td>
        <td>[DirectXMesh](http://go.microsoft.com/fwlink/?LinkID=324981)</td>
    </tr>
    <tr>
        <td>isochart テクスチャ アトラスを作成してパッケージ化するための UVAtlas を入手する</td>
        <td>[UVAtlas](http://go.microsoft.com/fwlink/?LinkID=512686)</td>
    </tr>
    <tr>
        <td>DirectXMath のライブラリを入手する</td>
        <td>[DirectXMath](http://go.microsoft.com/fwlink/?LinkID=615560)</td>
    </tr>
    <tr>
        <td>DirectXTK での Direct3D 12 のサポート (ブログの投稿)</td>
        <td>[DirectX 12 のサポート](https://github.com/Microsoft/DirectXTK/issues/2)</td>
    </tr>
</table>

#### パートナーからの DirectX リソース

これらは、外部のパートナーによって作成された補足の DirectX ドキュメントです。

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td>Nvidia: DX12 での推奨と非推奨 (ブログ投稿) </td>
        <td>[Nvidia GPU での DirectX 12](https://developer.nvidia.com/dx12-dos-and-donts-updated)</td>
    </tr>
    <tr>
        <td>Intel: DirectX 12 を使った効率的なレンダリング</td>
        <td>[Intel グラフィックスでの DirectX 12 のレンダリング](https://software.intel.com/sites/default/files/managed/4a/38/Efficient-Rendering-with-DirectX-12-on-Intel-Graphics.pdf)</td>
    </tr>
    <tr>
        <td>Intel: DirectX 12 でのマルチ アダプターのサポート</td>
        <td>[DirectX 12 を使った明示的なマルチ アダプターアプリケーションを実装する方法](https://software.intel.com/articles/multi-adapter-support-in-directx-12)</td>
    </tr>
    <tr>
        <td>Intel: DirectX 12 のチュートリアル</td>
        <td>[Intel、Suzhou Snail、Microsoft によって共同制作されたホワイト ペーパー](https://software.intel.com/articles/tutorial-migrating-your-apps-to-directx-12-part-1)</td>
    </tr>
</table>


## 制作


制作スタジオの準備が整ったら、チーム全体に作業を分散して制作サイクルに移行します。 プロトタイプの調整、リファクタリング、拡張によって、ゲームの完成品に仕上げていきます。

### 通知とライブ タイル

タイルとは、[スタート] メニュー上でゲームを表すものです。 タイルや通知によって、ゲームをプレイしていない場合でも、プレイヤーに興味を持たせることができます。

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td>タイルとバッジの開発</td>
        <td>[タイル、バッジ、通知](https://msdn.microsoft.com/library/windows/apps/mt185606)</td>
    </tr>
    <tr>
        <td>ライブ タイルと通知を示すサンプル</td>
        <td>[通知のサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Notifications)</td>
    </tr>
    <tr>
        <td>アダプティブ タイル テンプレート (ブログの投稿)</td>
        <td>[アダプティブ タイル テンプレート - スキーマとドキュメント](http://blogs.msdn.com/b/tiles_and_toasts/archive/2015/06/30/adaptive-tile-templates-schema-and-documentation.aspx)</td>
    </tr>
    <tr>
        <td>タイルとバッジの設計</td>
        <td>[タイルとバッジのガイドライン](https://msdn.microsoft.com/library/windows/apps/hh465403)</td>
    </tr>
    <tr>
        <td>ライブ タイル テンプレートを対話形式で開発するための Windows 10 アプリ</td>
        <td>[Notifications Visualizer](https://www.microsoft.com/store/apps/9nblggh5xsl1)</td>
    </tr>
    <tr>
        <td>Visual Studio 用の UWP Tile Generator 拡張機能</td>
        <td>[1 つの画像を使用して必要なすべてのタイルを作成するためのツール](https://visualstudiogallery.msdn.microsoft.com/09611e90-f3e8-44b7-9c83-18dba8275bb2)</td>
    </tr>
    <tr>
        <td>Visual Studio 用の UWP Tile Generator 拡張機能 (ブログの投稿)</td>
        <td>[UWP Tile Generator ツールの使用に関するヒント](https://blogs.windows.com/buildingapps/2016/02/15/uwp-tile-generator-extension-for-visual-studio/)</td>
    </tr>
</table>
 

### アプリ内製品 (IAP) 購入の有効化

IAP (アプリ内製品) は、プレイヤーがゲーム内で購入できる補助アイテムです。 IAP には、新しいアドオン、ゲームのレベル、項目、その他のプレーヤーを楽しませるものが含まれます。 適切に使用すると、IAP はゲームのエクスペリエンスを向上させると共に、収益の増加につながります。 ゲームの IAP は Windows デベロッパー センター ダッシュボードで定義して公開します。また、ゲームのコードでアプリ内購入を有効にします。

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td>永続的なアプリ内製品</td>
        <td>[アプリ内製品購入の有効化](https://msdn.microsoft.com/library/windows/apps/mt219684)</td>
    </tr>
    <tr>
        <td>コンシューマブルなアプリ内製品</td>
        <td>[コンシューマブルなアプリ内製品購入の有効化](https://msdn.microsoft.com/library/windows/apps/mt219683)</td>
    </tr>
    <tr>
        <td>アプリ内製品の詳細と申請</td>
        <td>[IAP の申請](https://msdn.microsoft.com/library/windows/apps/mt148551)</td>
    </tr>
    <tr>
        <td>IAP 売り上げとゲームの人口統計の監視</td>
        <td>[IAP 取得レポート](https://msdn.microsoft.com/library/windows/apps/mt148538)</td>
    </tr>
</table>
 
### デバッグとパフォーマンス監視ツール

Windows Performance Toolkit (WPT) は、Windows オペレーティング システムやアプリケーションの詳しいパフォーマンス プロファイルを生成するための一連のパフォーマンス監視ツールです。 これは、メモリ使用量を監視し、ゲームのパフォーマンスを向上させるために特に便利です。 Windows Performance Toolkit は、Windows 10 SDK と Windows ADK に含まれています。 このツールキットは、2 つの独立したツールで構成されています。Windows Performance Recorder (WPR) と Windows Performance Analyzer (WPA) です。 ゲームのクラッシュを調査するためのダンプ ファイルを生成するもう 1 つの便利なツールは、[Windows Sysinternals](https://technet.microsoft.com/sysinternals/default) に含まれる ProcDump です

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td>Windows 10 SDK から Windows Performance Toolkit (WPT) を入手する</td>
        <td>[Windows 10 SDK](https://developer.microsoft.com/windows/downloads/windows-10-sdk)</td>
    </tr>
    <tr>
        <td>Windows ADK から Windows Performance Toolkit (WPT) を入手する</td>
        <td>[Windows ADK](https://msdn.microsoft.com/windows/hardware/dn913721.aspx)</td>
    </tr>
    <tr>
        <td>Windows Performance Analyzer を使って応答しない UI のトラブルシューティングを行う (ビデオ)</td>
        <td>[WPA を使ったクリティカル パスの分析](https://channel9.msdn.com/Shows/Defrag-Tools/Defrag-Tools-156-Critical-Path-Analysis-with-Windows-Performance-Analyzer)</td>
    </tr>
    <tr>
        <td>Windows Performance Recorder を使ってメモリ使用量とメモリ リークを診断する (ビデオ)</td>
        <td>[メモリ使用量とリーク](https://channel9.msdn.com/Shows/Defrag-Tools/Defrag-Tools-154-Memory-Footprint-and-Leaks)</td>
    </tr>
    <tr>
        <td>ProcDump を取得する</td>
        <td>[ProcDump](https://technet.microsoft.com/sysinternals/dd996900)</td>
    </tr>
    <tr>
        <td>ProcDump の使い方 (ビデオ)</td>
        <td>[ダンプ ファイルを作成するために ProcDump を構成する](https://channel9.msdn.com/Shows/Defrag-Tools/Defrag-Tools-131-Windows-10-SDK)</td>
    </tr>
</table>

### 高度な DirectX の手法と概念

DirectX の開発には微妙で複雑な部分があります。 運用環境で、DirectX エンジンの詳細を掘り下げる必要がある場合や、難しいパフォーマンスの問題をデバッグする場合は、このセクションで紹介するリソースや情報が役立ちます。

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td>グラフィックスとパフォーマンスの最適化 (ビデオ)</td>
        <td>[高度な DirectX 12 グラフィックスとパフォーマンス](http://channel9.msdn.com/Events/GDC/GDC-2015/Advanced-DirectX12-Graphics-and-Performance)</td>
    </tr>
    <tr>
        <td>DirectX グラフィックスのデバッグ (ビデオ)</td>
        <td>[DirectX ツールを使用した、ゲームでのグラフィックスの困難な問題の解決](http://channel9.msdn.com/Events/GDC/GDC-2015/Solve-the-Tough-Graphics-Problems-with-your-Game-Using-DirectX-Tools)</td>
    </tr>
    <tr>
        <td>DirectX 12 をデバッグするための Visual Studio 2015 のツール (ビデオ)</td>
        <td>[Visual Studio 2015 の Windows 10 用 DirectX ツール](https://channel9.msdn.com/Series/ConnectOn-Demand/212)</td>
    </tr>
    <tr>
        <td>Direct3D 12 プログラミング ガイド</td>
        <td>[Direct3D 12 プログラミング ガイド](https://msdn.microsoft.com/library/windows/desktop/dn903821)</td>
    </tr>
    <tr>
        <td>DirectX と XAML の組み合わせ</td>
        <td>[DirectX と XAML の相互運用機能](directx-and-xaml-interop.md)</td>
    </tr>
</table>

### グローバリゼーションとローカライズ

Windows プラットフォーム用の多言語対応ゲームを開発し、Microsoft の有力製品に組み込まれている地域と言語の機能について説明します。

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td>世界市場向けのゲームの準備</td>
        <td>[世界中のユーザーに対応する開発のガイドライン](https://msdn.microsoft.com/library/windows/apps/xaml/mt186453.aspx)</td>
    </tr>
    <tr>
        <td>言語、文化、およびテクノロジの橋渡し</td>
        <td>[言語の規則および Microsoft の標準的な用語のオンライン リソース](http://www.microsoft.com/Language/Default.aspx)</td>
    </tr>
</table>


## ゲームの申請と公開


次のガイドと情報は、公開と申請のプロセスをできるだけスムーズに進めるのに役立ちます。

### パッケージ化とアップロード

新しい統合 Windows デベロッパー センター ダッシュボードを使って、すべてのゲーム パッケージを公開し管理することができます。

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td>Windows デベロッパー センターでのアプリの公開</td>
        <td>[Windows アプリの公開](https://dev.windows.com/publish)</td>
    </tr>
    <tr>
        <td>ゲームの評価 (ブログの投稿)</td>
        <td>[IARC システムを使って年齢区分を割り当てるための単一のワークフロー](https://blogs.windows.com/buildingapps/2016/01/06/now-available-single-age-rating-system-to-simplify-app-submissions/)</td>
    </tr>
    <tr>
        <td>ゲームのパッケージ化</td>
        <td>[UWPDirectX ゲームのパッケージ化](package-your-windows-store-directx-game.md)</td>
    </tr>
    <tr>
        <td>サード パーティ開発者としてのゲームのパッケージ化 (ブログ投稿)</td>
        <td>[発行元のストア アカウントにアクセスせずにアップロード可能なパッケージの作成](https://blogs.windows.com/buildingapps/2015/12/15/building-an-app-for-a-3rd-party-how-to-package-their-store-app/)</td>
    </tr>
    <tr>
        <td>MakeAppx を使用したアプリ パッケージとアプリ パッケージ バンドルの作成</td>
        <td>[アプリ パッケージ ツール MakeAppx.exe を使用したパッケージの作成](https://msdn.microsoft.com/library/windows/desktop/hh446767)</td>
    </tr>
    <tr>
        <td>SignTool を使用したファイルへのデジタル署名</td>
        <td>[SignTool を使用した、ファイルへの署名とファイルの署名の確認](https://msdn.microsoft.com/library/windows/desktop/aa387764)</td>
    </tr>      
    <tr>
        <td>ゲームのアップロードとバージョン管理</td>
        <td>[アプリ パッケージのアップロード](https://msdn.microsoft.com/library/windows/apps/mt148542)</td>
    </tr>
</table>
 

### ポリシーと認定

認定に関する問題によってゲームのリリースを延期しないでください。 ここでは、ポリシーと注意が必要な一般的な認定の問題を示します。

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td>Windows ストア アプリ開発者契約書</td>
        <td>[アプリ開発者契約書](https://msdn.microsoft.com/library/windows/apps/hh694058)</td>
    </tr>
    <tr>
        <td>Windows ストアでアプリを公開するためのポリシー</td>
        <td>[Windows ストア ポリシー](https://msdn.microsoft.com/library/windows/apps/dn764944)</td>
    </tr>
    <tr>
        <td>一般的なアプリの認定の問題を回避する方法</td>
        <td>[一般的な認定エラーの回避](https://msdn.microsoft.com/library/windows/apps/jj657968)</td>
    </tr>
</table>
 

### ストア マニフェスト (StoreManifest.xml)

ストア マニフェスト (StoreManifest.xml) は、必要に応じてアプリ パッケージに含めることのできる構成ファイルです。 ストア マニフェストには、AppxManifest.xml ファイルに含まれていないその他の機能が用意されています。 たとえば、ターゲット デバイスが指定された DirectX の最小機能レベルまたは指定された最小システム メモリの条件を満たしていない場合に、ストア マニフェストを使ってゲームのインストールをブロックできます。

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td>ストア マニフェストのスキーマ</td>
        <td>[StoreManifest のスキーマ (Windows 10)](https://msdn.microsoft.com/library/windows/apps/mt617335)</td>
    </tr>
</table>
 

## ゲームのライフサイクル管理


開発が終了し、ゲームを出荷しても、"ゲーム オーバー" というわけではありません。 バージョン 1 の開発は終了ですが、市場でのゲームの旅は始まったばかりです。 使用状況やエラー レポートの監視、ユーザーからのフィードバックへの対応、ゲームの更新プログラムの公開という作業が必要になります。

### Windows デベロッパー センターの分析と販売促進

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td>デベロッパー センター アプリ</td>
        <td>[公開済みアプリのパフォーマンスを表示するデベロッパー センター Windows 10 アプリ](https://www.microsoft.com/store/apps/dev-center/9nblggh4r5ws)</td>
    </tr>  
    <tr>
        <td>Windows デベロッパー センターの分析</td>
        <td>[分析](https://msdn.microsoft.com/library/windows/apps/mt148522)</td>
    </tr>
    <tr>
        <td>顧客のレビューへの返信</td>
        <td>[顧客のレビューに返信する](https://msdn.microsoft.com/library/windows/apps/mt148546)</td>
    </tr>
    <tr>
        <td>ゲームの販売を促進する方法</td>
        <td>[アプリの販売促進](https://dev.windows.com/store-promotion)</td>
    </tr>
</table>
 

### Visual Studio Application Insights

Visual Studio Application Insights は、公開されたゲームのパフォーマンス、利用統計情報、および使用状況の分析を提供します。 Application Insights は、リリース後のゲームの問題の検出と解決、使用状況の継続的な監視と向上、プレイヤーがゲームを操作する方法の把握に役立ちます。 Application Insights は、アプリに SDK を追加することで機能し、[Azure ポータル](http://portal.azure.com/)に利用統計情報を送信します。

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td>アプリケーションのパフォーマンスと使用状況の分析</td>
        <td>[Visual Studio Application Insights](https://azure.microsoft.com/documentation/articles/app-insights-get-started/)</td>
    </tr>
    <tr>
        <td>Windows アプリでの Application Insights の有効化</td>
        <td>[Windows Phone およびストア アプリ向けの Application Insights](https://azure.microsoft.com/documentation/articles/app-insights-windows-get-started/)</td>
    </tr>
</table>
 

### コンテンツの更新プログラムの作成と管理

公開されたゲームを更新するには、大きいバージョン番号を持つ新しいアプリ パッケージを申請します。 このパッケージの申請と認定が終了すると、自動的にユーザーに更新プログラムとして公開されます。

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td>ゲームの更新とバージョン管理</td>
        <td>[パッケージ バージョンの番号付け](https://msdn.microsoft.com/library/windows/apps/mt188602)</td>
    </tr>
    <tr>
        <td>ゲームのパッケージ管理のガイダンス</td>
        <td>[アプリ パッケージ管理のガイダンス](https://msdn.microsoft.com/library/windows/apps/mt188602)</td>
    </tr>
</table>


## ゲームへの Xbox Live の追加


> 
              **注**   Xbox Live の開発は ID@Xbox や Microsoft Studios などのプログラムで管理されます。 このガイドでは幅広いリソースを取り上げているため、プログラムへの参加や特定の開発の役割によっては、一部のリソースにアクセスできない場合があります。 developer.xboxlive.com、forums.xboxlive.com、xdi.xboxlive.com、Game Developer Network (GDN) に解決されるリンクなどです。 Microsoft との提携について詳しくは、「[開発者プログラム](#programs)」をご覧ください。

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td>最新の Xbox Live SDK のダウンロード</td>
        <td>[Xbox Live SDK](http://aka.ms/xsapi2)</td>
    </tr>
    <tr>
        <td>ユニバーサル Windows プラットフォーム アプリへの Xbox Live の追加</td>
        <td>[Xbox Live SDK をユニバーサル Windows プラットフォーム (UWP) アプリに追加する方法](http://aka.ms/xsapi2uwp)</td>
    </tr>
    <tr>
        <td>Xbox Live を使うためのゲームの要件</td>
        <td>[Xbox Live on Windows 10 の Xbox の要件](http://go.microsoft.com/fwlink/?LinkId=533217)</td>
    </tr>
    <tr>
        <td>Xbox Live のゲーム開発の概要 (ビデオ)</td>
        <td>[Windows 10 用の Xbox Live を使った開発](http://channel9.msdn.com/Events/GDC/GDC-2015/Developing-with-Xbox-Live-for-Windows-10)</td>
    </tr>
    <tr>
        <td>クロス プラットフォーム マッチメイキング (ビデオ)</td>
        <td>[Xbox Live マルチプレイヤー: クロス プラットフォーム マッチメイキングとゲームプレイのサービスの紹介](http://channel9.msdn.com/Events/GDC/GDC-2015/Xbox-Live-Multiplayer-Introducing-services-for-cross-platform-matchmaking-and-gameplay)</td>
    </tr>
    <tr>
        <td>Fable Legends でのクロス デバイスのゲームプレイ (ビデオ)</td>
        <td>[Fable Legends: Xbox Live によるクロス デバイス ゲームプレイ](http://channel9.msdn.com/Events/GDC/GDC-2015/Fable-Legends-Cross-device-Gameplay-with-Xbox-Live)</td>
    </tr>
    <tr>
        <td>Xbox Live の統計情報や達成度 (ビデオ)</td>
        <td>[クラウド ベースのユーザーの統計情報と Xbox Live での達成度の活用のベスト プラクティス](http://channel9.msdn.com/Events/GDC/GDC-2015/Best-Practices-for-Leveraging-Cloud-Based-User-Stats-and-Achievements-in-Xbox-Live)</td>
    </tr>
</table>
 

## その他のリソース

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td>インディーズ ゲーム開発 (ビデオ)</td>
        <td>[個人開発者のための新しい機会](http://channel9.msdn.com/Events/GDC/GDC-2015/New-Opportunities-for-Independent-Developers)</td>
    </tr>
    <tr>
        <td>マルチコア モバイル デバイスに関する考慮事項 (ビデオ)</td>
        <td>[マルチコア モバイル デバイスでのゲームのパフォーマンスの維持](http://channel9.msdn.com/Events/GDC/GDC-2015/Sustained-gaming-performance-in-multi-core-mobile-devices)</td>
    </tr>
    <tr>
        <td>Windows 10 デスクトップ ゲームの開発 (ビデオ)</td>
        <td>[Windows 10 向け PC ゲーム](http://channel9.msdn.com/Events/GDC/GDC-2015/PC-Games-for-Windows-10)</td>
    </tr>
</table>



 

 

 



<!--HONumber=Jul16_HO2-->


