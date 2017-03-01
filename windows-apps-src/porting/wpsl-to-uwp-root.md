---
author: mcleblanc
description: "Windows Phone Silverlight アプリの開発者は、Windows 10 への移行で、自身のスキル セットとソース コードを十分に活用できます。"
title: "Windows Phone Silverlight から UWP への移行"
ms.assetid: 9E0C0315-6097-488B-A3AF-7120CCED651A
ms.author: markl
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
translationtype: Human Translation
ms.sourcegitcommit: c6b64cff1bbebc8ba69bc6e03d34b69f85e798fc
ms.openlocfilehash: 06409936f37368351f6c8ad47e50a7d980d522f4
ms.lasthandoff: 02/07/2017

---

#  <a name="move-from-windows-phone-silverlight-to-uwp"></a>Windows Phone Silverlight から UWP への移行

\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]

Windows Phone Silverlight アプリの開発者は、Windows 10 への移行で、自身のスキル セットとソース コードを十分に活用できます。 Windows 10 では、ユニバーサル Windows プラットフォーム (UWP) を作成できます。これは、どのような種類のデバイスにでもインストールできる単一のアプリ パッケージです。 Windows 10、UWP アプリ、およびこの移植ガイドで説明されているアダプティブ コードとアダプティブ UI の概念の詳しい背景については、「[ユニバーサル Windows プラットフォーム (UWP) アプリのガイド](https://msdn.microsoft.com/library/windows/apps/dn894631)」をご覧ください。

Windows Phone Silverlight アプリを Windows 10 アプリに移植するときには、[Windows Phone 8.1 で導入された](https://msdn.microsoft.com/library/windows/apps/dn632424)モバイル機能を引き続き利用できるだけでなく、アプリ モデルや UI フレームワークがすべての Windows 10 デバイスでユニバーサルなユニバーサル Windows プラットフォーム (UWP) も利用できます。 これにより、1 つのコード ベースから、1 つのアプリ パッケージで、PC、タブレット、電話、その他の多くの種類のデバイスをサポートできます。 また、これによりアプリの潜在顧客が増加し、共有データ、購入コンシューマブルなどの可能性が高まります。 新機能について詳しくは、「[Windows 10 の開発者向け新着情報](https://dev.windows.com/getstarted/whats-new-windows-10)」をご覧ください。

選択する場合、アプリの Windows Phone Silverlight バージョンとその Windows 10 バージョンの両方を同時に顧客に提供できます。

**注:** このガイドの目的は、Windows Phone Silverlight アプリを Windows 10 に手動で移植できるようにすることです。 このガイドの情報を使って、アプリを移植できるだけではありません。移植プロセス自動化支援用に提供された **Mobilize.NET の Silverlight Bridge** の開発者プレビューを試すこともできます。 このツールは、アプリのソース コードを解析し、Windows Phone Silverlight のコントロールと API への参照を UWP の相当要素に変換します。 このツールは、まだ開発者プレビューの段階にあるため、すべての変換シナリオを扱えるとは限りません。 ただし、ほとんどの開発者はこのツールを使い始めることで、時間と労力をいくらかは節約できます。 開発者プレビューを試すには、[Mobilize.NET の Web サイト](http://go.microsoft.com/fwlink/p/?LinkId=624546)をご覧ください。

## <a name="xaml-and-net-or-html"></a>XAML と .NET、または HTML

Windows Phone Silverlight は、Silverlight 4.0 に基づく XAML UI フレームワークを持ち、.NET Framework バージョンおよび UWP API の小さなサブセットに対してプログラミングします。 Windows Phone Silverlight アプリでは Extensible Application Markup Language (XAML) を使っていたため、使う多くのソース コードとソフトウェア パターンと同様に、知識とエクスペリエンスの大半も活用できるため、Windows 10 バージョンでは XAML が選択肢となる可能性が高くなります。 UI のマークアップと設計であっても容易に移植できます。 マネージ API、XAML マークアップ、UI フレームワーク、ツールはすべて使い慣れたものであり、UWP アプリでは、XAML と共に C++、C#、Visual Basic を使うことができます。 若干の課題が発生するとしても、そのプロセスの相対的な容易さに驚くはずです。

「[C# または Visual Basic を使ったユニバーサル Windows プラットフォーム (UWP) アプリのためのロードマップ](https://msdn.microsoft.com/library/windows/apps/br229583)」をご覧ください。

**注**  Windows 10 では、Windows Phone ストア アプリと比べて、より多くの .NET Framework の要素がサポートされます。 たとえば、Windows 10 には、複数の System.ServiceModel.\* 名前空間、System.Net、System.Net.NetworkInformation、System.Net.Sockets があります。 したがって、Windows Phone Silverlight を移植し、.NET コードをコンパイルするだけで新しいプラットフォームで動作させるには絶好の機会です。 「[名前空間とクラス マッピング](wpsl-to-uwp-namespace-and-class-mappings.md)」をご覧ください。
既にある .NET ソース コードを Windows 10 アプリに再コンパイルするもう 1 つの大きな理由は、.NET ネイティブのメリットを活かすことができる点です。これは、MSIL をネイティブに実行可能なマシン コードに変換する事前コンパイル テクノロジです。 .NET ネイティブ アプリは、MSIL アプリに比べて、すばやく起動し、メモリ使用量やバッテリ使用量は少なくなります。

この移植ガイドでは XAML に重点を置いていますが、JavaScript 用 Windows ライブラリと共に、JavaScript、カスケード スタイル シート (CSS)、HTML5 を使って、同じ UWP API の多くを呼び出す機能的に同等のアプリを構築できます。 XAML と HTML の Windows ランタイム UI フレームワークは相互に異なりますが、いずれを選んでも一連のさまざまな Windows デバイスで汎用的に動作します。

## <a name="targeting-the-universal-or-the-mobile-device-family"></a>ターゲットとしてのユニバーサル デバイス ファミリまたはモバイル デバイス ファミリの設定

選択肢の 1 つは、ユニバーサル デバイス ファミリをターゲットとするアプリにアプリを移植することです。 この場合、アプリは多様なデバイスにインストールできます。 アプリがモバイル デバイス ファミリにのみ実装されている API を呼び出す場合は、これらの呼び出しをアダプティブ コードで保護できます。 また、モバイル デバイス ファミリをターゲットとするアプリにアプリを移植することができ、この場合、アダプティブ コードを記述する必要はありません。

## <a name="adapting-your-app-to-multiple-form-factors"></a>複数のフォーム ファクターへのアプリの対応

前のセクションで選択した選択肢によって、アプリが実行されるデバイスの種類が決まります。これは、非常に多種多様なデバイスである場合もあります。 アプリをモバイル デバイス ファミリに制限した場合でも、さまざまな画面サイズをサポートする必要があります。 以前はサポートしていなかったフォーム ファクターでアプリが実行されるため、これらのフォーム ファクターで UI をテストし、必要なすべての変更を加えて、UI が各フォーム ファクターに適切に対応するようにします。 これは、移植後のタスクまたは移植の拡張目標と考えることができます。これについての実践的な例が「[Bookstore2](wpsl-to-uwp-case-study-bookstore2.md)」のケース スタディに紹介されています。

## <a name="approaching-porting-layer-by-layer"></a>レイヤーごとの移植アプローチ

-   **ビュー**。 ビューは (ビュー モデルと共に)、アプリの UI を構成します。 理想的にはビューは、ビュー モデルの監視可能なプロパティに対するマークアップ バインドから成ります。 直接 UI 要素を操作するためにコード ビハインド ファイル内のコード用に別のパターンが不可欠です (一般的でありまた便利ですが、短期間に限定されます)。 いずれのケースでも、UI マークアップと設計の多く、そして UI 要素を操作するために不可欠なコードについても、簡単に移植できます。
-   **ビュー モデルとデータ モデル**。 形式的な懸念事項分離パターン (MVVM など) を取り入れていなくても、ビュー モデルおよびデータ モデルの関数を実行するコードがアプリ内に必然的に存在します。 ビュー モデル コードでは、UI フレームワークの名前空間内の型を使います。 また、ビュー モデルおよびデータ モデル コードは共に、非視覚的なオペレーティング システム API および .NET API を使います (データ アクセス用の API を含みます)。 このようなコードの大半が [UWP アプリで利用可能であり](https://msdn.microsoft.com/library/windows/apps/br211369)、したがって変更なくコードの大半を移植できると考えられます。 ただし、ビュー モデルは、ビューのモデルまたは*アブストラクション*であることに注意してください。 ビュー モデルは UI の状態と動作を提供するのに対して、ビューそれ自体は視覚効果を提供します。 このような理由から、UWP で実行可能な異なるフォーム ファクターに適合するどのような UI でも、おそらく対応するビュー モデルの変更が必要になります。 ネットワークとクラウド サービスの呼び出しについては、通常、.NET API と UWP API のいずれを使うかを選択できます。 この決定に関連する要因については、「[クラウド サービス、ネットワーク、データベース](wpsl-to-uwp-business-and-data.md)」をご覧ください。
-   **クラウド サービス**。 アプリのいくつか (おそらく、その多く) が、サービスの形式でクラウド内で実行されます。 クライアント デバイス上で実行する一部のアプリは、こうしたアプリに接続します。 これは、クライアント部分の移植時に、変化しない可能性が最も高い分散アプリの部分です。 クラウド サービスをまだ利用していない場合は、UWP アプリに適したクラウド サービス オプションとして [Microsoft Azure Mobile Services](http://azure.microsoft.com/services/mobile-services/) があります。これは、ライブ タイル更新のための簡単な通知から、サーバー ファームが提供する高負荷のスケーラビリティに至るまで、さまざまなサービスのためにユニバーサル Windows アプリから呼び出すことができる強力なバックエンド コンポーネントを提供します。

移植前または移植中に、同様の目的を持つコードがレイヤー内に集められ、随意に散在しないように、アプリがリファクタリングによって向上するかどうかを考慮します。 前述したように、UWP アプリをレイヤーにファクタリングすることで、アプリの適合性、テスト、以降の読み取りと維持が容易になります。 Model-View-ViewModel ([MVVM](http://msdn.microsoft.com/magazine/dd419663.aspx)) パターンに従うことにより、機能の再利用性を高め、プラットフォーム間の UI API の相違によるいくつかの問題を回避できます。 このパターンにより、アプリのデータ部、ビジネス部、UI 部の相互の分離性が維持されます。 UI 内であっても、状態と動作を別個に維持し、視覚効果から個別にテスト可能にすることができます。 MVVM により、データおよびビジネス ロジックを 1 回記述すれば、UI に関係なく、それをすべてのデバイスで使うことができます。 各デバイスで、ビュー モデルとビュー部品の多くを再利用できる可能性があります。

## <a name="one-or-two-exceptions-to-the-rule"></a>いくつかの例外

この移植ガイドでは、「[名前空間とクラス マッピング](wpsl-to-uwp-namespace-and-class-mappings.md)」も随時ご覧ください。 非常に簡単なマッピングが一般的な規則ですが、名前空間とクラス マッピング表にすべての例外が示されています。

機能レベルでは、さいわいなことに、UWP でサポートされないものは非常にわずかです。 この移植ガイドの以降の部分では、自身のスキル セットとソース コードの大半を UWP アプリで有効に活用できます。 ただし、次に示すように、Windows Phone Silverlight で使われている可能性があっても UWP に相当要素がない機能がいくつかあります。

| UWP に相当要素がない機能 | 機能に関する Windows Phone Silverlight ドキュメント |
|----------------------------------------------|---------------------------------------------------------|
| Microsoft XNA。 一般に、C++ を使った [Microsoft DirectX](https://msdn.microsoft.com/library/windows/desktop/ee663274) に置き換えられます。 「[ゲームの開発](https://msdn.microsoft.com/library/windows/apps/hh452744)」と「[DirectX と XAML の相互運用機能](https://msdn.microsoft.com/library/windows/apps/hh825871)」をご覧ください。 | [XNA Framework クラス ライブラリ](http://msdn.microsoft.com/library/bb203940.aspx) | 
|レンズ アプリ | [Windows Phone 8 のレンズ](http://msdn.microsoft.com/library/windows/apps/jj206990.aspx) |

&nbsp;

| トピック| 説明|
|------|------------| 
| [名前空間とクラス マッピング](wpsl-to-uwp-namespace-and-class-mappings.md) | このトピックでは、Windows Phone Silverlight API から UWP の相当する API への包括的なマッピングを示します。 |
| [プロジェクトの移植](wpsl-to-uwp-porting-to-a-uwp-project.md) | Visual Studio で新しい Windows 10 プロジェクトを作成し、そのプロジェクトにファイルをコピーすることにより、移植プロセスを開始します。 |
| [トラブルシューティング](wpsl-to-uwp-troubleshooting.md) | この移植ガイドは最後まで読むことを強くお勧めしますが、早く先へ進んで、プロジェクトのビルドと実行の段階まで到達したいと思われるのも無理のないことです。 このために、重要でないコードに対してコメント アウトやスタブの挿入を行って一時的に先に進み、後でその部分に戻って対応することもできます。 このトピックには、トラブルシューティングの現象とその対処法を示す表が記載されており、以降のいくつかのトピックに示されている情報に代わるものではありませんが、この段階での作業に役立ちます。 以降のトピックを読み進む中で、いつでもこの表に戻って参考にすることができます。 |
| [XAML と UI の移植](wpsl-to-uwp-porting-xaml-and-ui.md) | 宣言型 XAML マークアップ形式での UI の定義は、Windows Phone Silverlight から UWP アプリに非常に適切に変換されます。 システムのリソース キーの参照の更新、いくつかの要素型名の変更、"clr-namespace" から "using" への変更を行うことによって、大きなマークアップ セクションで互換性が得られることがわかります。 |
| [入出力、デバイス、アプリ モデルの移植](wpsl-to-uwp-input-and-sensors.md) | デバイス自体とそのセンサーに統合するコードには、ユーザーに対する入力と出力が含まれます。 また、データ処理を含むこともあります。 ただしこのコードは一般には、UI レイヤーまたはデータ レイヤーのいずれにも見なされません。 このコードには、振動コントローラー、加速度計、ジャイロスコープ、マイクとスピーカー (音声認識と音声合成で使います)、地理位置情報、およびタッチ、マウス、キーボード、ペンなどの入力モダリティとの統合が含まれます。 |
| [ビジネス レイヤーとデータ レイヤーの移植](wpsl-to-uwp-business-and-data.md) | UI の背後には、ビジネス レイヤーとデータ レイヤーがあります。 こうしたレイヤーのコードでは、オペレーティング システムと .NET Framework API (たとえば、バックグラウンド処理、場所、カメラ、ファイル システム、ネットワーク、その他のデータ アクセスなど) を呼び出します。 このようなコードの大半が [UWP アプリで利用可能であり](https://msdn.microsoft.com/library/windows/apps/br211369)、したがって変更なくコードの大半を移植できると考えられます。 |
| [フォーム ファクターと UX の移植](wpsl-to-uwp-form-factors-and-ux.md) | Windows アプリは、PC、モバイル デバイス、その他の多くの種類のデバイスで同じ外観を共有します。 ユーザー インターフェイス、入力パターン、操作パターンは非常に類似しており、デバイス間を移行するユーザーには使い慣れたエクスペリエンスは歓迎されるはずです。|
|[ケース スタディ: Bookstore1](wpsl-to-uwp-case-study-bookstore1.md) | このトピックでは、Windows 10 UWP アプリに、非常にシンプルな Windows Phone Silverlight アプリを移植するケース スタディについて説明します。 Windows 10 では、さまざまなデバイスにユーザーがインストールできる単一のアプリ パッケージを作成できます。このようなアプリ パッケージの作成を、このケース スタディで取り上げます。 |
| [ケース スタディ: Bookstore2](wpsl-to-uwp-case-study-bookstore2.md) | このケース スタディは、「[Bookstore1](wpsl-to-uwp-case-study-bookstore1.md)」で説明されている情報に基づいて作成されています。ここでは、最初に、グループ化されたデータを **LongListSelector** に表示する Windows Phone Silverlight アプリについて取り上げます。 ビュー モデルでは、**Author** クラスの各インスタンスは、該当する著者によって書かれた書籍のグループを表します。**LongListSelector** では、著者ごとにグループ化された書籍の一覧を表示したり、縮小して著者のジャンプ リストを表示したりすることができます。 |

## <a name="related-topics"></a>関連トピック

**ドキュメント**
* [Windows 10 の開発者向け新着情報](https://dev.windows.com/getstarted/whats-new-windows-10)
* [ユニバーサル Windows プラットフォーム (UWP) アプリのガイド](https://msdn.microsoft.com/library/windows/apps/dn894631)
* [C# または Visual Basic を使ったユニバーサル Windows プラットフォーム (UWP) アプリのためのロードマップ](https://msdn.microsoft.com/library/windows/apps/br229583)
* [Windows Phone 8 開発者にとっての選択肢](https://msdn.microsoft.com/library/windows/apps/xaml/dn655121.aspx)

**MSDN マガジンの記事**
* [Visual Studio Magazine の「Windows Phone 8.1 における集約への大きな前進」に関する記事](http://go.microsoft.com/fwlink/p/?LinkID=398541)

**プレゼンテーション**
* [Nokia Music での Windows Phone から Windows 8 への移行に関するページ](http://go.microsoft.com/fwlink/p/?LinkId=321521)
 


