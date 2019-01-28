---
description: この記事では、ユニバーサル Windows プラットフォーム (UWP) アプリで、共有コントラクトをサポートする方法について説明します。
title: データの共有
ms.assetid: 32287F5E-EB86-4B98-97FF-8F6228D06782
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: c1c9b75599efe4566bc1783f68ff9752510d1d99
ms.sourcegitcommit: 9448348d7bc6590849db3a41e988dff9470ec111
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 01/28/2019
ms.locfileid: "9031378"
---
# <a name="share-data"></a>データの共有


この記事では、ユニバーサル Windows プラットフォーム (UWP) アプリで、共有コントラクトをサポートする方法について説明します。 共有コントラクトは、テキスト、リンク、写真、ビデオなどのデータをアプリ間ですばやく共有するための簡単な方法です。 たとえば、ユーザーがソーシャル ネットワーキング アプリを使って友人と Web ページを共有する場合や、後で参照するためにリンクをメモ帳アプリで保存する場合があります。

## <a name="set-up-an-event-handler"></a>イベント ハンドラーのセットアップ

ユーザーが共有を呼び出したときに呼び出される [**DataRequested**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.DataTransferManager.DataRequested) イベント ハンドラーを追加します。 このイベントは、ユーザーがアプリ内のコントロール (ボタンやアプリ バー コマンドなど) をタップした場合に発生します。ユーザーがあるレベルをクリアしてハイ スコアを獲得した場合など、特定のシナリオで自動的に発生することもあります。

[!code-cs[Main](./code/share_data/cs/MainPage.xaml.cs#SnippetPrepareToShare)]

[**DataRequested**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.DataTransferManager.DataRequested) イベントが発生すると、アプリは [**DataRequest**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.DataRequest) オブジェクトを受け取ります。 このオブジェクトに含まれている [**DataPackage**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.DataPackage) を使って、ユーザーが共有するコンテンツを提供することができます。 共有するデータとタイトルを指定する必要があります。 説明は省略することもできますが、指定することをお勧めします。

[!code-cs[Main](./code/share_data/cs/MainPage.xaml.cs#SnippetCreateRequest)]

## <a name="choose-data"></a>データの選択

次のようなさまざまな種類のデータを共有することができます。

-   プレーンテキスト
-   Uniform Resource Identifier (URI)
-   HTML
-   書式付きテキスト
-   ビットマップ
-   ファイル
-   開発者が定義したカスタム データ

[**DataPackage**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.DataPackage) オブジェクトには、これらの 1 つ以上の形式を任意に組み合わせて格納することができます。 次の例は、テキストの共有を示しています。

[!code-cs[Main](./code/share_data/cs/MainPage.xaml.cs#SnippetSetContent)]

## <a name="set-properties"></a>プロパティの設定

共有用にデータをパッケージ化するときに、共有されるコンテンツの情報を追加で提供するさまざまなプロパティを指定できます。 これらのプロパティは、ターゲット アプリでのユーザー エクスペリエンスを高めるために役立ちます。 たとえば、ユーザーが複数のアプリでコンテンツを共有している場合に、説明があると便利です。 画像や Web ページへのリンクを共有する場合にサムネイルを追加すると、ユーザーが視覚的に確認できます。 詳しくは、「[**DataPackagePropertySet**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.DataPackagePropertySet)」を参照してください。

タイトルを除くすべてのプロパティは任意です。 タイトルのプロパティは必須です。必ず設定してください。

[!code-cs[Main](./code/share_data/cs/MainPage.xaml.cs#SnippetSetProperties)]

## <a name="launch-the-share-ui"></a>共有 UI の起動

共有用の UI は、システムによって提供されます。 起動するには、[**ShowShareUI**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.DataTransferManager.ShowShareUI) メソッドを呼び出します。

[!code-cs[Main](./code/share_data/cs/MainPage.xaml.cs#SnippetShowUI)]

## <a name="handle-errors"></a>エラーの処理

ほとんどの場合、コンテンツの共有は難しいプロセスではありません。 しかし、どのような場合であっても、予期しない問題が発生することは必ずあります。 たとえば、共有するコンテンツをユーザーが選ぶ必要がある状況で、ユーザーが選んでいない場合などです。 このような状況を処理するには、[**FailWithDisplayText**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.DataRequest.FailWithDisplayText(System.String)) メソッドを使います。このメソッドでは、問題が発生すると、ユーザーにメッセージが表示されます。

## <a name="delay-share-with-delegates"></a>デリゲートによる共有の遅延

場合によっては、ユーザーが共有するデータをすぐに準備しても効果的でないことがあります。 たとえば、複数の異なる形式の大きな画像ファイルの送信をサポートしているアプリの場合、ユーザーが選択する前にこれらの画像をすべて作成することは非効率的です。

この問題を解決するために、[**DataPackage**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.DataPackage) にはデリゲートも格納できます。デリゲートとは、受け取る側のアプリでデータを要求するときに呼び出される関数です。 リソースを大量に消費するデータを共有する場合はデリゲートを使うことをお勧めします。

<!-- For some reason, this snippet was inline in the WDCML topic. Suggest moving to VS project with rest of snippets. -->
```cs
async void OnDeferredImageRequestedHandler(DataProviderRequest request)
{
    // Provide updated bitmap data using delayed rendering
    if (this.imageStream != null)
    {
        DataProviderDeferral deferral = request.GetDeferral();
        InMemoryRandomAccessStream inMemoryStream = new InMemoryRandomAccessStream();

        // Decode the image.
        BitmapDecoder imageDecoder = await BitmapDecoder.CreateAsync(this.imageStream);

        // Re-encode the image at 50% width and height.
        BitmapEncoder imageEncoder = await BitmapEncoder.CreateForTranscodingAsync(inMemoryStream, imageDecoder);
        imageEncoder.BitmapTransform.ScaledWidth = (uint)(imageDecoder.OrientedPixelWidth * 0.5);
        imageEncoder.BitmapTransform.ScaledHeight = (uint)(imageDecoder.OrientedPixelHeight * 0.5);
        await imageEncoder.FlushAsync();

        request.SetData(RandomAccessStreamReference.CreateFromStream(inMemoryStream));
        deferral.Complete();
    }
}
```

## <a name="see-also"></a>関連項目 

* [アプリ間通信](index.md)
* [データの受信](receive-data.md)
* [DataPackage](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.datatransfer.datapackage.aspx)
* [DataPackagePropertySet](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.datatransfer.datapackagepropertyset.aspx)
* [DataRequest](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.datatransfer.datarequest.aspx)
* [DataRequested](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.datatransfer.datatransfermanager.datarequested.aspx)
* [FailWithDisplayText](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.datatransfer.datarequest.failwithdisplaytext.aspx)
* [ShowShareUi](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.datatransfer.datatransfermanager.showshareui.aspx)
 

