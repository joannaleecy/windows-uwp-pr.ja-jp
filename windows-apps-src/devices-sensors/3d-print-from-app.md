---
author: PatrickFarley
title: "アプリからの 3D 印刷"
description: "ユニバーサル Windows アプリに 3D 印刷機能を追加する方法について説明します。 このトピックでは、3D モデルが印刷可能であり、正しい形式になっていることを確認した後で 3D 印刷ダイアログを起動する方法について説明します。"
ms.assetid: D78C4867-4B44-4B58-A82F-EDA59822119C
translationtype: Human Translation
ms.sourcegitcommit: e2b88b0eb88d0a3d8d1a5fb944bd4d00a50012e0
ms.openlocfilehash: b9bfc51e9abb0ba15e5873a5693d5b24f4b6dbf7

---

# アプリからの 3D 印刷


\[ Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132) をご覧ください \]


**重要な API**

-   [**Windows.Graphics.Printing3D**](https://msdn.microsoft.com/library/windows/apps/dn998169)

ユニバーサル Windows アプリに 3D 印刷機能を追加する方法について説明します。 このトピックでは、アプリに 3D 形状データを読み込んだ後、その 3D モデルが印刷可能であり、正しい形式になっていることを確認してから 3D 印刷ダイアログを起動する方法について説明します。 以下の手順の動作については、[3D 印刷の UWP サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/3DPrinting)をご覧ください。

> [!NOTE]
> このガイドのサンプル コードでは、簡単にするためにエラー レポートと処理が大幅に簡略化されています。

## クラス セットアップ


3D 印刷機能を搭載するクラスで、[**Windows.Graphics.Printing3D**](https://msdn.microsoft.com/library/windows/apps/dn998169) 名前空間を追加します。

[!code-cs[3DPrintNamespace](./code/3dprinthowto/cs/MainPage.xaml.cs#Snippet3DPrintNamespace)]

このガイドでは、次の追加の名前空間を使います。

[!code-cs[OtherNamespaces](./code/3dprinthowto/cs/MainPage.xaml.cs#SnippetOtherNamespaces)]

次に、有用なメンバー フィールドをクラスにいくつか追加します。 プリンター ドライバーに渡す印刷タスクへの参照として使うために、[**Print3DTask**](https://msdn.microsoft.com/library/windows/apps/dn998044) オブジェクトを宣言します。 アプリに読み込む元の 3D データ ファイルを保持するために、[**StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171) オブジェクトを宣言します。 必要なすべてのメタデータが含まれた、印刷準備が完了した 3D モデルを表す [**Printing3D3MFPackage**](https://msdn.microsoft.com/library/windows/apps/dn998063) オブジェクトを宣言します。

[!code-cs[DeclareVars](./code/3dprinthowto/cs/MainPage.xaml.cs#SnippetDeclareVars)]

## シンプルな UI の作成

このサンプルでは、プログラム メモリにファイルを読み込む読み込みボタン、必要に応じてファイルを変更する修正ボタン、印刷ジョブを開始する印刷ボタンの 3 つのユーザー コントロールを使います。 次のコードで、これらのボタン (クリック イベント ハンドラー付き) をクラスの XAML ファイルに作成します。

[!code-xml[ボタン](./code/3dprinthowto/cs/MainPage.xaml#SnippetButtons)]

UI フィードバック用に **TextBlock** を追加します。

[!code-xml[OutputText](./code/3dprinthowto/cs/MainPage.xaml#SnippetOutputText)]



## 3D データの取得


アプリでは、さまざまな方法で、3D 形状データを取得することができます。 たとえば、3D スキャンからデータを取得したり、Web リソースからのモデル データをダウンロードしたり、数式やユーザー入力を使ってプログラムによって 3D メッシュを生成したりできます。 ここでは簡単にするために、3D データ ファイル (一般的なファイルの種類のいずれか) をデバイスのストレージからプログラム メモリに読み込む方法を示します。 [3D Builder モデル ライブラリ](https://developer.microsoft.com/windows/hardware/3d-builder-model-library)には幅広いモデルが用意されており、デバイスに簡単にダウンロードできます。

`OnLoadClick` メソッドで、[**FileOpenPicker**](https://msdn.microsoft.com/library/windows/apps/br207847) クラスを使って、1 つのファイルをアプリのメモリに読み込みます。

[!code-cs[FileLoad](./code/3dprinthowto/cs/MainPage.xaml.cs#SnippetFileLoad)]

## 3D Builder による 3D Manufacturing Format (.3mf) への変換

これで、3D データ ファイルをアプリのメモリに読み込むことができます。 ただし、3D 形状データには、さまざまな形式がありますが、すべてが 3D 印刷に効率的であるわけではありません。 Windows 10 では、すべての 3D 印刷タスクについて 3D Manufacturing Format (.3mf) というファイル形式を使います。

> [!NOTE]  
> 
.3mf ファイル形式には、このチュートリアルでは扱っていない多くの機能が用意されています。 3MF と 3D 製品のプロデューサーおよびコンシューマー向けに用意されたその機能について詳しくは、[3MF の仕様](http://3mf.io/what-is-3mf/3mf-specification/)をご覧ください。 Windows 10 API を使ってこれらの機能を利用する方法については、「[3MF パッケージの生成](https://msdn.microsoft.com/windows/uwp/devices-sensors/generate-3mf)」チュートリアルをご覧ください。

幸いなことに、[3D Builder](https://www.microsoft.com/store/apps/3d-builder/9wzdncrfj3t6) アプリでは、一般的なほとんどの 3D 形式のファイルを開くことができ、それらを .3mf ファイル形式で保存することができます。 この例では、ファイルの種類が異なる場合に、簡単な解決策として、3D Builder を開き、インポートしたデータを .3mf ファイルとして保存し再度読み込むようユーザーに求めます。

> [!NOTE]  
> 
3D Builder には、ファイル形式の変換以外にも、モデルを編集したり色データを追加したりといった、印刷に固有の操作を行うための簡単なツールが用意されているため、多くの場合、3D 印刷を処理するアプリに統合するだけの価値があります。

[!code-cs[FileCheck](./code/3dprinthowto/cs/MainPage.xaml.cs#SnippetFileCheck)]

## 3D 印刷可能なモデル データへの修復

.3mf 形式であっても、すべての 3D モデル データが印刷可能なわけではありません。 どこを埋めて何を空洞のままにするかをプリンターに正しく判断させるには、印刷する (各) モデルが 1 つのシームレスなメッシュであること、モデルの面の法線が外側を向いていること、またモデルがマニホールド形状であることが必要条件となります。 これらの問題は、さまざまな形で現れることがあり、図形が複雑な場合は、見つけるのが難しいことがあります。 幸いなことに、最新のソフトウェア ソリューションは、多くの場合、元データの形状を印刷可能な 3D 図形に変換するのに十分な機能を備えています。 これはモデルの*修復*と呼ばれ、`OnFixClick` メソッドで行われます。

[**IRandomAccessStream**](https://msdn.microsoft.com/library/windows/apps/br241731) を実装し、[**Printing3DModel**](https://msdn.microsoft.com/library/windows/apps/mt203679) オブジェクトを生成します。これを行うには、3D データ ファイルを変換する必要があります。

[!code-cs[RepairModel](./code/3dprinthowto/cs/MainPage.xaml.cs#SnippetRepairModel)]

これで、**Printing3DModel** オブジェクトを印刷できる状態に修復できました。 [**SaveModelToPackageAsync**](https://msdn.microsoft.com/library/windows/apps/windows.graphics.printing3d.printing3d3mfpackage.savemodeltopackageasync) を使って、クラスを作成したときに宣言した **Printing3D3MFPackage** オブジェクトにモデルを割り当てます。

[!code-cs[SaveModel](./code/3dprinthowto/cs/MainPage.xaml.cs#SnippetSaveModel)]

## 印刷タスクの実行: TaskRequested ハンドラーの作成


3D 印刷ダイアログをユーザーに表示してユーザーが印刷を開始したときに、アプリが目的のパラメーターを 3D 印刷パイプラインに渡す必要があります。 3D 印刷 API によって、**TaskRequested** イベントが発生します。 このイベントを適切に処理するメソッドを記述する必要があります。 通常どおり、ハンドラー メソッドはイベントと同じ型である必要があります。**TaskRequested** イベントには、パラメーター [**Print3DManager**](https://msdn.microsoft.com/library/windows/apps/dn998029) (センダー オブジェクトへの参照) と [**Print3DTaskRequestedEventArgs**](https://msdn.microsoft.com/library/windows/apps/dn998051) オブジェクト (ほとんどの関連情報を保持するオブジェクト) があります。 戻り値の型は **void** です。

[!code-cs[MyTaskTitle](./code/3dprinthowto/cs/MainPage.xaml.cs#SnippetMyTaskTitle)]

このメソッドの主な目的は、*args* パラメーターを使って、**Printing3D3MFPackage** をパイプラインに送信することです。 **Print3DTaskRequestedEventArgs** 型には、[**Request**](https://msdn.microsoft.com/library/windows/apps/windows.graphics.printing3d.print3dtaskrequestedeventargs.request.aspx) という 1 つのプロパティがあります。 その型は [**Print3DTaskRequest**](https://msdn.microsoft.com/library/windows/apps/dn998050) で、1 つの印刷ジョブ要求を表します。 そのメソッドである [**CreateTask**](https://msdn.microsoft.com/library/windows/apps/windows.graphics.printing3d.print3dtaskrequest.createtask.aspx) を使って、プログラムは印刷ジョブに関する適切な情報を送信します。このメソッドは、3D 印刷パイプラインに送信された **Print3DTask** オブジェクトへの参照を返します。

**CreateTask** には、印刷ジョブ名を表す **string**、使うプリンターの ID を表す **string**、および [**Print3DTaskSourceRequestedHandler**](https://msdn.microsoft.com/library/windows/apps/windows.graphics.printing3d.print3dtasksourcerequestedhandler.aspx) デリゲートという入力パラメーターがあります。 このデリゲートは、**3DTaskSourceRequested** イベントが発生したときに自動的に呼び出されます (これは API によって行われます)。 重要なのは、印刷ジョブが開始されたときにこのデリゲートが呼び出され、適切な 3D 印刷パッケージを提供する役割を果たすということです。

**Print3DTaskSourceRequestedHandler** は、送信するデータを提供する [**Print3DTaskSourceRequestedArgs**](https://msdn.microsoft.com/library/windows/apps/dn998056) オブジェクトという 1 つのパラメーターを取ります。 このクラスの 1 つのパブリック メソッドである [**SetSource**](https://msdn.microsoft.com/library/windows/apps/windows.graphics.printing3d.print3dtasksourcerequestedargs.setsource.aspx) が、印刷するパッケージを受け取ります。 次のように、**Print3DTaskSourceRequestedHandler** デリゲートを実装します。

[!code-cs[SourceHandler](./code/3dprinthowto/cs/MainPage.xaml.cs#SnippetSourceHandler)]

次に、新しく定義したデリゲート `sourceHandler` を使って、**CreateTask** を呼び出します。

[!code-cs[CreateTask](./code/3dprinthowto/cs/MainPage.xaml.cs#SnippetCreateTask)]

返された **Print3DTask** が、最初に宣言したクラス変数に割り当てられます。 これで、必要に応じてこの参照を使い、タスクによってスローされた特定のイベントを処理できるようになりました。

[!code-cs[省略可能](./code/3dprinthowto/cs/MainPage.xaml.cs#SnippetOptional)]

> [!NOTE]  
> これらのイベントに `Task_Submitting` および `Task_Completed` メソッドを登録するには、それらを実装する必要があります。

## 印刷タスクの実行: 3D 印刷ダイアログを開く


最後に 3D 印刷ダイアログを起動する短いコードが必要になります。 従来の印刷ダイアログ ウィンドウと同じように、3D 印刷ダイアログでも、最後に使った印刷オプションがいくつか表示され、ユーザーは使うプリンターを (USB かネットワーク接続かに関係なく) 選択することができます。

`MyTaskRequested` メソッドを **TaskRequested** イベントに登録します。

[!code-cs[RegisterMyTaskRequested](./code/3dprinthowto/cs/MainPage.xaml.cs#SnippetRegisterMyTaskRequested)]

**TaskRequested** イベント ハンドラーを登録したら、メソッド [**ShowPrintUIAsync**](https://msdn.microsoft.com/library/windows/apps/windows.graphics.printing3d.print3dmanager.showprintuiasync.aspx) を呼び出して、現在のアプリケーション ウィンドウに 3D 印刷ダイアログを表示することができます。

[!code-cs[ShowDialog](./code/3dprinthowto/cs/MainPage.xaml.cs#SnippetShowDialog)]

最後に、アプリにコントロールが戻ったら、イベント ハンドラーの登録を解除することをお勧めします。  

[!code-cs[DeregisterMyTaskRequested](./code/3dprinthowto/cs/MainPage.xaml.cs#SnippetDeregisterMyTaskRequested)]

## 関連トピック

[3MF パッケージの生成](https://msdn.microsoft.com/windows/uwp/devices-sensors/generate-3mf)  
[3D 印刷の UWP サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/3DPrinting)
 

 







<!--HONumber=Aug16_HO5-->


