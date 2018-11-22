---
author: jwmsft
ms.assetid: A37ADD4A-2187-4767-9C7D-EDE8A90AA215
title: パフォーマンスの計画
description: ユーザーは、高い応答性と自然な使用感、そしてバッテリーが消耗しないことをアプリに期待しています。
ms.author: jimwalk
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: e62e724cceb458ba922143e61058dffa8d16a0b8
ms.sourcegitcommit: 93c0a60cf531c7d9fe7b00e7cf78df86906f9d6e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/21/2018
ms.locfileid: "7563509"
---
# <a name="planning-for-performance"></a>パフォーマンスの計画



ユーザーは、高い応答性と自然な使用感、そしてバッテリーが消耗しないことをアプリに期待しています。 技術的には、パフォーマンスは機能要件ではありませんが、パフォーマンスを機能として扱うことで、ユーザーの期待に沿うことができます。 鍵となる要因は、目標の明確化と測定の実施です。 パフォーマンスが重要なシナリオを決定し、優れたパフォーマンスとは何を意味するかを定義します。 次に、プロジェクトの初期とライフサイクル全体で十分な回数の測定を行って、目標を達成できることを確認します。

## <a name="specifying-goals"></a>目標を明確にする

ユーザー エクスペリエンスは、優れたパフォーマンスを定義する基本的な方法です。 アプリの起動時間は、アプリのパフォーマンスに対するユーザーの認識に影響を与える可能性があります。 ユーザーは、アプリの起動時間が 1 秒未満は優秀、5 秒未満は良好、5 秒を超えると貧弱であると考えることがあります。

その他のメトリック (メモリなど) がユーザー エクスペリエンスに与える影響はそれほど明確ではありません。 アプリが使うメモリの量が増えると、中断しているか非アクティブになっているアプリが終了する可能性が高くなります。 一般に、メモリの使用量が高くなるとシステム上のすべてのアプリのエクスペリエンスが低下するため、メモリの消費量に関する目標を設定することは妥当なことです。 ユーザーが認識するアプリの大まかなサイズ (大、中、小) を考慮します。 パフォーマンスに関する期待は、この認識と関連性があります。 たとえば、たくさんのメディアは使わない小さいアプリであれば、消費するメモリが 100 MB を超えないようにします。

初期目標を設定して後で修正するほうが、目標をまったく持たないことよりもましです。 アプリのパフォーマンス目標は具体的かつ測定可能である必要があり、ユーザーまたはアプリがタスクを完了させるまでにかかる時間 (時間)、ユーザーの操作に応えてアプリが自身を再描画する割合と継続性 (滑らかな動作)、アプリがバッテリー電源を含むシステム リソースを節約する度合い (効率性) という 3 つのカテゴリに分類する必要があります。

## <a name="time"></a>時間

ユーザーがアプリでタスクを完了するためにかかる経過時間の容認できる範囲 (*インタラクション クラス*) を考えます。 各インタラクション クラスに対して、ラベル、認識されるユーザーの感情、理想時間、および最大時間を割り当てます。 いくつかの提案を次に示します。

| インタラクション クラスのラベル | ユーザーの体感                 | 理想時間            | 最大時間          | 例                                                                     |
|-------------------------|---------------------------------|------------------|------------------|------------------------------------------------------------------------------|
| Fast (高速)                    | ほとんど遅延を感じない      | 100 ミリ秒 | 200 ミリ秒 | アプリ バーを起動する、ボタンを押す (最初の応答)                        |
| Typical (標準)                 | 速いが、高速ではない             | 300 ミリ秒 | 500 ミリ秒 | サイズ変更、セマンティック ズーム                                                        |
| Responsive (応答)              | 速くはないが、反応はよい | 500 ミリ秒 | 1 秒         | 別のページに移動する、中断状態からアプリを再開する          |
| Launch (起動)                  | 操作に干渉する          | 1 秒         | 3 秒        | アプリを初めて起動する、アプリを終了後にもう一度起動する |
| Continuous (継続)              | 反応がよいと感じない      | 500 ミリ秒 | 5 秒        | インターネットからファイルをダウンロードする                                            |
| Captive (占有)                 | 遅い、ユーザーが切り替えを検討する可能性がある    | 500 ミリ秒 | 10 秒       | ストアから複数のアプリをインストールする                                         |

 

これで、インタラクション クラスをアプリのパフォーマンスのシナリオに割り当てることができます。 各シナリオに、アプリを参照した時点、ユーザー エクスペリエンスの一部、およびインタラクション クラスを割り当てることができます。 次に示すのは、サンプルのレシピ紹介アプリのための提案です。


<!-- DHALE: used HTML table here b/c WDCML src used rowspans -->
<table>
<tr><th>シナリオ</th><th>時点</th><th>ユーザー エクスペリエンス</th><th>インタラクション クラス</th></tr>
<tr><td rowspan="3">レシピ ページに移動する </td><td>最初の応答</td><td>ページの切り替えアニメーションが始まった</td><td>Fast (高速) (100 から 200 ミリ秒)</td></tr>
<tr><td>応答中</td><td>材料のリストが読み込まれた、画像は表示されていない</td><td>Responsive (応答) (500 ミリ秒から 1 秒)</td></tr>
<tr><td>ページが表示された</td><td>すべてのコンテンツが読み込まれた、画像が表示された</td><td>Continuous (継続) (500 ミリ秒から 5 秒)</td></tr>
<tr><td rowspan="2">レシピを検索する</td><td>最初の応答</td><td>検索ボタンをクリックした</td><td>Fast (高速) (100 から 200 ミリ秒)</td></tr>
<tr><td>ページが表示された</td><td>ローカル レシピのタイトル一覧が表示された</td><td>Typical (標準) (300 から 500 ミリ秒)</td></tr>
</table>

ライブ コンテンツを表示する場合は、コンテンツの更新目標も考慮します。 目標は、コンテンツを数秒ごとに更新することですか。 それとも、数分ごと、数時間ごと、1 日に 1 回の更新で、ユーザー エクスペリエンスは許容できる範囲ですか。

目標を明確にすることで、アプリのテスト、分析、最適化を実行しやすくなります。

## <a name="fluidity"></a>滑らかな動作

アプリの具体的で測定可能な滑らかな動作の目標には、以下が含まれます。

-   画面の再描画で中断 (エラー) が発生しない。
-   アニメーションは 1 秒あたり 60 フレームでレンダリングする (FPS)。
-   ユーザーがパンまたはスクロールしたとき、アプリは 1 秒あたり 3 ～ 6 ページ分のコンテンツを表示する。

## <a name="efficiency"></a>効率性

アプリの具体的で測定可能な効率性の目標には、以下が含まれます。

-   アプリのプロセスで、常に CPU の割合が *N* 以下であり、メモリ使用量 (MB 単位) が *M* 以下である。
-   アプリがアクティブでないとき、*N* と *M* は、アプリのプロセスでは 0 である。
-   アプリはバッテリー電源で *X* 時間アクティブに使用でき、アプリがアクティブでないとき、デバイスは充電状態を *Y* 時間保持する。

## <a name="design-your-app-for-performance"></a>アプリのパフォーマンスを設計する

パフォーマンスの目標を使って、アプリの設計に役立てることができます。 サンプルのレシピ紹介アプリで、ユーザーがレシピ ページに移動した後、レシピの名前が最初に表示され、少し遅れて材料が表示され、さらに遅れて画像が表示されるように、[項目を徐々に更新](optimize-gridview-and-listview.md#update-items-incrementally)します。 これで、パンまたはスクロール中の応答と滑らかな UI が保たれ、操作のペースが落ちて UI スレッドが追い付けるようになった後で完全なレンダリングを実行できます。 他にも次の局面を検討します。

**UI**

-   [XAML マークアップを最適化](optimize-xaml-loading.md)することで、アプリの UI の各ページ (特に最初のページ) の解析と読み込みの時間とメモリの効率を最大化します。 簡単に言うと、必要になるまで UI とコードの読み込みを遅らせます。
-   [**ListView**](https://msdn.microsoft.com/library/windows/apps/BR242878) と [**GridView**](https://msdn.microsoft.com/library/windows/apps/BR242705) では、すべての項目を同じサイズにし、できるだけ多くの [ListView と GridView の最適化手法](optimize-gridview-and-listview.md)を使います。
-   UI は、コード内で命令を使って構築するのではなく、フレームワークが読み込んでチャンクで再利用できるマークアップ形式で宣言します。
-   ユーザーが必要とするまで UI 要素の作成を遅らせます。 [**x:Load**](../xaml-platform/x-load-attribute.md) 属性をご覧ください。
-   ストーリーボードに設定されたアニメーションよりテーマ切り替えやテーマ アニメーションを優先的に使います。 詳しくは、「[アニメーションの概要](https://msdn.microsoft.com/library/windows/apps/Mt187350)」をご覧ください。 ストーリーボードに設定されたアニメーションでは、画面を定期的に更新して CPU とグラフィックス パイプラインを常にアクティブにしておく必要があることを忘れないようにします。 バッテリーを節約するために、ユーザーがアプリを操作していない場合はアニメーションを実行しないようにします。
-   読み込む画像は、[**GetThumbnailAsync**](https://msdn.microsoft.com/library/windows/apps/BR227210) メソッドを使って、そのときのビューに適したサイズで読み込む必要があります。

**CPU、メモリ、電源**

-   優先度の低い作業は、優先度の低いスレッドやコアで実行するようにスケジュールを設定します。 [非同期プログラミング](https://msdn.microsoft.com/library/windows/apps/Mt187335)、[**Dispatcher**](https://msdn.microsoft.com/library/windows/apps/BR209054) プロパティ、[**CoreDispatcher**](https://msdn.microsoft.com/library/windows/apps/BR208211) クラスをご覧ください。
-   一時停止中のメモリ使用量の多いリソース (メディアなど) を解放することで、アプリのメモリ使用量を最小限に抑えます。
-   コードのワーキング セットを最小限に抑えます。
-   イベント ハンドラーを登録解除し、UI 要素を逆参照して、できるだけメモリ リークを避けます。
-   バッテリーを節約するために、データをポーリングする頻度、センサーを照会する頻度、またはアイドル状態の CPU に作業をスケジュールする頻度を控えめにします。

**データ アクセス**

-   可能であれば、コンテンツをプリフェッチします。 自動的プリフェッチについては、[**ContentPrefetcher**](https://msdn.microsoft.com/library/windows/apps/Dn279042) クラスをご覧ください。 手動プリフェッチについては、[**Windows.ApplicationModel.Background**](https://msdn.microsoft.com/library/windows/apps/BR224847) 名前空間と [**MaintenanceTrigger**](https://msdn.microsoft.com/library/windows/apps/Hh700517) クラスをご覧ください。
-   可能であれば、アクセスするときに負荷がかかるコンテンツはキャッシュしておきます。 [**LocalFolder**](https://msdn.microsoft.com/library/windows/apps/BR241621) プロパティと [**LocalSettings**](https://msdn.microsoft.com/library/windows/apps/BR241622) プロパティをご覧ください。
-   キャッシュが失われた場合は、できるだけ早くプレース ホルダー UI を表示して、アプリがコンテンツを読み込み中であることを示します。 ユーザーに不快感を与えないような方法で、プレースホルダーからライブ コンテンツに切り替えます。 たとえば、アプリがライブ コンテンツを読み込む際に、ユーザーの指またはマウス ポインターの下にあるコンテンツの位置を変更しないようにします。

**アプリの起動と再開**

-   アプリのスプラッシュ画面の表示を遅らせ、必要ない場合は拡張しません。 詳しくは、「[高速で滑らかな起動エクスペリエンスを作り上げる](http://go.microsoft.com/fwlink/p/?LinkId=317595)」と「[スプラッシュ画面の表示時間の延長](https://msdn.microsoft.com/library/windows/apps/Mt187309)」をご覧ください。
-   スプラッシュ画面が消えた直後に発生するアニメーションは無効にします。アプリの起動が遅くなるように感じられるためです。

**アダプティブ UI と向き**

-   [**VisualStateManager**](https://msdn.microsoft.com/library/windows/apps/BR209021) クラスを使います。
-   必要な処理だけをすぐに完了し、負荷の大きなアプリの作業は後回しにします。処理を完了し、アプリの UI がトリミングされた状態で表示されるまでに 200 ～ 800 ミリ秒かかります。

パフォーマンス関連の設計が整ったら、アプリのコーディングを始めることができます。

## <a name="instrument-for-performance"></a>パフォーマンスを計測する

アプリをコーディングする際に、アプリの実行中のある時点におけるメッセージやイベントをログに記録するコードを追加します。 アプリを後でテストする際に、Windows Performance Recorder や Windows Performance Analyzer (どちらも [Windows Performance Toolkit](https://msdn.microsoft.com/library/windows/apps/xaml/hh162945.aspx) に含まれています) などのプロファイリング ツールを使って、アプリのパフォーマンスに関するレポートを作成して閲覧できます。 このレポートでメッセージやイベントを確認して、レポートの結果を簡単に解析できます。

ユニバーサル Windows プラットフォーム (UWP) には、[Windows イベント トレーシング (ETW)](https://msdn.microsoft.com/library/windows/desktop/Bb968803) と連動するログ記録 API が用意されており、イベント ログの記録とトレースを行う高機能なソリューションを提供します。 これらの API は [**Windows.Foundation.Diagnostics**](https://msdn.microsoft.com/library/windows/apps/BR206677) 名前空間の一部であり、[**FileLoggingSession**](https://msdn.microsoft.com/library/windows/apps/Dn264138) クラス、[**LoggingActivity**](https://msdn.microsoft.com/library/windows/apps/Dn264195) クラス、[**LoggingChannel**](https://msdn.microsoft.com/library/windows/apps/Dn264202) クラス、および [**LoggingSession**](https://msdn.microsoft.com/library/windows/apps/Dn264217) クラスが含まれます。

アプリ実行中の特定の時点でレポートにメッセージを記録するには、**LoggingChannel** オブジェクトを作成し、オブジェクトの [**LogMessage**](https://msdn.microsoft.com/library/windows/apps/windows.foundation.diagnostics.loggingchannel.logmessage.aspx) メソッドを、次のように呼び出します。

```csharp
// using Windows.Foundation.Diagnostics;
// ...

LoggingChannel myLoggingChannel = new LoggingChannel("MyLoggingChannel");

myLoggingChannel.LogMessage(LoggingLevel.Information, "Here' s my logged message.");

// ...
```

アプリ実行中の特定の期間にわたってレポートに開始イベントと停止イベントを記録するには、**LoggingActivity** オブジェクトを作成し、オブジェクトの [**LoggingActivity**](https://msdn.microsoft.com/library/windows/apps/windows.foundation.diagnostics.loggingactivity.loggingactivity.aspx) コンストラクターを次のように呼び出します。

```csharp
// using Windows.Foundation.Diagnostics;
// ...

LoggingActivity myLoggingActivity;

// myLoggingChannel is defined and initialized in the previous code example.
using (myLoggingActivity = new LoggingActivity("MyLoggingActivity"), myLoggingChannel))
{   // After this logging activity starts, a start event is logged.
    
    // Add code here to do something of interest.
    
}   // After this logging activity ends, an end event is logged.

// ...
```

「[ログの例](http://go.microsoft.com/fwlink/p/?LinkId=529576)」もご覧ください。

アプリをインストルメント化したら、アプリのパフォーマンスのテストと測定を実行できます。

## <a name="test-and-measure-against-performance-goals"></a>アプリをテストしてパフォーマンスの目標と照らし合わせる

パフォーマンスの計画の一部として、開発のどの時点でパフォーマンスを測定するかを定義することがあります。 測定の目的は、それを実行する時点 (プロトタイプ中、開発中、展開中) に応じて変化します。 プロトタイプの初期段階でのパフォーマンスの測定は非常に有益である可能性があるため、意味のある作業を実行するコードができたら、すぐに測定することをお勧めします。 早いうちに測定しておくと、アプリのどの部分のコストが重要かがわかり、設計の決定事項に関する情報も得られます。 その結果、拡張しやすい高パフォーマンスのアプリを作成できます。 一般に、設計の変更が後になればなるほど、より多くのコストがかかります。 製品サイクルの後半でパフォーマンスを測定すると、十分な対応ができず、高いパフォーマンスが得られない可能性があります。

次の手法とツールを使ってアプリのパフォーマンスをテストして、元のパフォーマンスの目標と比較します。

-   さまざまなハードウェア構成 (オールインワン PC、デスクトップ PC、ノート PC、タブレット) でテストを行います。
-   さまざまな画面サイズでテストを行います。 画面サイズが大きいとより多くのコンテンツを表示できますが、すべてのコンテンツを表示するとパフォーマンスに悪影響が出る可能性があります。
-   テストに影響する可変状態をできるだけ取り除きます。
    -   テスト デバイスのバックグラウンド アプリを停止します。 これを行うには、Windows で、[スタート] メニューの **[設定]**、**[個人設定]**、**[ロック画面]** の順に選択します。 アクティブなアプリを選択し、**[なし]** を選択します。
    -   テスト デバイスに展開する前に、リリース構成でビルドすることで、アプリをネイティブ コードにコンパイルします。
    -   自動メンテナンスがテスト デバイスのパフォーマンスに影響しないようにするため、メンテナンスを手動でトリガーして完了するまで待ちます。 Windows の [スタート] メニューで、**[セキュリティとメンテナンス]** を検索します。 **[メンテナンス]** 領域の **[自動メンテナンス]** で、**[メンテナンスの開始]** を選択し、状態が **[メンテナンスは進行中です]** から別の状態に変化するまで待ちます。
    -   一貫性のある測定結果が得られるように、アプリを複数回実行して、テストのランダム要素を排除します。
-   低電力での利用可能性をテストします。 ユーザーのデバイスは、開発用のコンピューターに比べ、大幅に低電力である可能性があります。 Windows は、モバイル デバイスなどの低電力デバイスでの動作を考慮して設計されています。 プラットフォームで動作するアプリが、これらのデバイスでも高いパフォーマンスを発揮できるようにする必要があります。 経験則として、低電力デバイスでの実行速度はデスクトップ コンピューターの約 1/4 であると考えられるため、これに応じて目標を設定します。
-   アプリのパフォーマンスを測定するには、Microsoft Visual Studio や Windows Performance Analyzer のようなツールを組み合わせて使います。 Visual Studio は、ソース コードのリンク設定など、アプリに焦点を当てた分析を行うように設計されています。 Windows Performance Analyzer は、システム情報、タッチ操作イベントに関する情報、ディスクの入出力 (I/O) に関する情報、グラフィックス処理ユニット (GPU) のコストに関する情報の提供など、システムに焦点を当てた分析を行うように設計されています。 どちらのツールでも、トレースをキャプチャしてエクスポートし、共有トレースと事後検証トレースを再開することができます。
-   認定のストアにアプリを提出する前に、 [Windows アプリ認定キットのテスト](windows-app-certification-kit-tests.md)の「パフォーマンス テスト」セクションで説明されて、パフォーマンスに関連するテスト_ケースをテスト プランに組み込むことを確認して、"パフォーマンスと[UWP アプリのテスト_ケース](https://msdn.microsoft.com/library/windows/apps/Dn275879)の安定性」セクションです。

詳しくは、次のリソースとプロファイリング ツールをご覧ください。

-   [Windows Performance Analyzer](https://msdn.microsoft.com/library/windows/apps/xaml/hh448170.aspx)
-   [Windows Performance Toolkit](https://msdn.microsoft.com/library/windows/apps/xaml/hh162945.aspx)
-   [Visual Studio 診断ツールを使用してパフォーマンスを分析する](https://msdn.microsoft.com/library/windows/apps/xaml/hh696636.aspx)
-   //build/ セッション「[XAML Performance (XAML のパフォーマンス)](https://channel9.msdn.com/Events/Build/2015/3-698)」
-   //build/ セッション「[New XAML Tools in Visual Studio 2015 (Visual Studio 2015 の新しい XAML ツール)](https://channel9.msdn.com/Events/Build/2015/2-697)」

## <a name="respond-to-the-performance-test-results"></a>パフォーマンス テストの結果に対応する

アプリのパフォーマンス テストの結果を分析したら、次のような変更が必要かどうかを判断します。

-   現在の設計の決定事項のいずれかを変更する必要があるか。またはコードを最適化する必要があるか。
-   コードに対してインストルメンテーションを追加、削除、または変更する必要があるか。
-   パフォーマンス目標のいずれかを変更する必要があるか。

変更が必要な場合は、変更を行った後でインストルメント化に戻り、テストを繰り返します。

## <a name="optimizing"></a>最適化

アプリのパフォーマンスが重要なコード パスのみ最適化します。この場所に最も多くの時間を費やします。 プロファイリングによって、どの場所がこれに該当するかがわかります。 多くの場合、優れた設計のソフトウェアを作成することと、最高レベルの最適化を実現したコードを記述することは、両立しません。 一般的に、パフォーマンスがそれほど重視されない領域では、開発者の生産性や優れたソフトウェア設計を優先することが適切です。