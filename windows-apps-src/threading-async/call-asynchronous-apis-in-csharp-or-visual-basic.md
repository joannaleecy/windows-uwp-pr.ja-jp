---
ms.assetid: 066711E0-D5C4-467E-8683-3CC64EDBCC83
title: C# または Visual Basic での非同期 API の呼び出し
description: ユニバーサル Windows プラットフォーム (UWP) には、時間がかかる可能性がある操作を実行しているときでも、アプリの応答性を保つために、さまざまな非同期 API が用意されています。
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10、UWP、C#、Visual Basic、非同期
ms.localizationpriority: medium
ms.openlocfilehash: 899af2ffd26419d4c8906d703d6708d202f8c150
ms.sourcegitcommit: a3dc929858415b933943bba5aa7487ffa721899f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/07/2018
ms.locfileid: "8790090"
---
# <a name="call-asynchronous-apis-in-c-or-visual-basic"></a>C# または Visual Basic での非同期 API の呼び出し



ユニバーサル Windows プラットフォーム (UWP) には、時間がかかる可能性がある操作を実行しているときでも、アプリの応答性を保つために、さまざまな非同期 API が用意されています。 このトピックでは、C# または Microsoft Visual Basic で UWP の非同期メソッドを使う方法について説明します。

非同期 API を使うと、アプリは、大量の操作が完了するのを待たずに実行を継続できます。 たとえば、インターネットから情報をダウンロードするアプリは、情報が到着するまで数秒待機する可能性があります。 同期メソッドを使って情報を取得すると、アプリはメソッドから制御が返されるまでブロックされます。 アプリが操作に応答せず、応答していないと思ったユーザーが苛立ちを感じる可能性があります。 非同期 API を提供することによって、時間のかかる操作の実行時に、UWP でアプリの応答性を保つことができます。

ユニバーサル Windows プラットフォーム (UWP) のほとんどの非同期 API には、対応する同期 API がありません。そのため、UWP アプリで C# または Visual Basic を使って非同期 API を利用する方法を理解しておく必要があります。 次に、UWP の非同期 API を呼び出す方法を示します。

## <a name="using-asynchronous-apis"></a>非同期 API の使用


非同期メソッドには、表記の規則により "Async" で終わる名前が付いています。 通常、非同期 API は、ユーザーがボタンをクリックしたときなど、ユーザーの操作に応じて呼び出します。 イベント ハンドラーでの非同期メソッドの呼び出しは、最も簡単な非同期 API の使用方法の 1 つです。 ここでは、例として **await** 演算子を使います。

たとえば、ブログ記事の特定の場所にあるタイトルを一覧表示するアプリがあるとします。 このアプリには、タイトルを取得する際にユーザーがクリックする [**Button**](https://msdn.microsoft.com/library/windows/apps/BR209265) があります。 タイトルは [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/BR209652) に表示します。 ユーザーがボタンをクリックし、ブログの Web サイトからの情報を待っている間、アプリの応答性を保つことが重要です。 この応答性を保つために、UWP では、フィードをダウンロードするための非同期メソッド [**SyndicationClient.RetrieveFeedAsync**](https://msdn.microsoft.com/library/windows/apps/BR243460) を提供しています。

この例では、非同期メソッド [**SyndicationClient.RetrieveFeedAsync**](https://msdn.microsoft.com/library/windows/apps/BR243460) を呼び出して、その結果を待機し、ブログから記事の一覧を取得します。

> [!div class="tabbedCodeSnippets" data-resources="OutlookServices.Calendar"]
[!code-csharp[Main](./AsyncSnippets/csharp/MainPage.xaml.cs#SnippetDownloadRSS)]
[!code-vb[Main](./AsyncSnippets/vbnet/MainPage.xaml.vb#SnippetDownloadRSS)]

この例には、いくつかの重要なポイントがあります。 まず、`SyndicationFeed feed = await client.RetrieveFeedAsync(feedUri)` の行では、非同期メソッド [**RetrieveFeedAsync**](https://msdn.microsoft.com/library/windows/apps/BR243460) を呼び出す際に、**await** 演算子が使われています。 **await** 演算子は、非同期メソッドを呼び出していることをコンパイラに伝えていると考えることができます。これにより、コンパイラが追加作業を行うようになります。 もう 1 つは、イベント ハンドラーの宣言に **async** というキーワードが含まれている点です。 **await** 演算子を使うメソッドのメソッド宣言には、このキーワードを含める必要があります。

このトピックでは、コンパイラでの **await** 演算子の処理方法については詳しく取り上げませんが、非同期で応答性を保つためにアプリが何を行っているか説明していきます。 同期コードを使った場合はどうなるか考えてみましょう。 たとえば、同期の `SyndicationClient.RetrieveFeed` というメソッドがあるとします  (このようなメソッドは存在しませんが、ここではあると仮定します)。アプリに `SyndicationFeed feed = await client.RetrieveFeedAsync(feedUri)` という行ではなく `SyndicationFeed feed = client.RetrieveFeed(feedUri)` という行が含まれている場合は、`RetrieveFeed` の戻り値が使用可能になるまで、アプリの実行が停止します。 アプリは、このメソッドが完了するのを待機している間、他のイベント (別の [**Click**](https://msdn.microsoft.com/library/windows/apps/BR227737) イベントなど) には応答できません。 つまり、`RetrieveFeed` が戻るまで、アプリはブロックされます。

しかし、`client.RetrieveFeedAsync` メソッドは、呼び出されると、取得を開始して直ちに戻ります。 [**RetrieveFeedAsync**](https://msdn.microsoft.com/library/windows/apps/BR243460) と一緒に **await** を使うと、アプリが一時的にイベント ハンドラーを終了します。 このとき、**RetrieveFeedAsync** を非同期で実行しながら、他のイベントを処理することができます。 これにより、アプリの応答性が維持されます。 **RetrieveFeedAsync** が完了し、[**SyndicationFeed**](https://msdn.microsoft.com/library/windows/apps/BR243485) が使用可能になると、アプリは、実質的に中断したイベント ハンドラーに戻り、`SyndicationFeed feed = await client.RetrieveFeedAsync(feedUri)` の後の残りのメソッドを完了します。

**await** 演算子を使うメリットは、架空の `RetrieveFeed` メソッドを使った場合のコードとそれほど違いがないという点です。 C# または Visual Basic で **await** 演算子を使わずに非同期コードを記述する方法もありますが、このようなコードでは、非同期で実行するしくみに重点が置かれる傾向があります。 これにより、非同期コードが記述しづらく、わかりにくく、保守しにくいものになります。 **await** 演算子を使うことによって、コードが複雑になることなく、非同期アプリのメリットを享受できます。

## <a name="return-types-and-results-of-asynchronous-apis"></a>戻り値の型と非同期 API の結果


[**RetrieveFeedAsync**](https://msdn.microsoft.com/library/windows/apps/BR243460) へのリンクをたどると、**RetrieveFeedAsync** の戻り値の型が [**SyndicationFeed**](https://msdn.microsoft.com/library/windows/apps/BR243485) ではないことがわかると思います。 戻り値の型は、`IAsyncOperationWithProgress<SyndicationFeed, RetrievalProgress>` になります。 構文そのものを見ると、非同期 API は結果を含むオブジェクトを返します。 非同期メソッドが待機可能であると考えることは一般的であり、有用な場合もありますが、**await** 演算子は、実際にはメソッドではなくメソッドの戻り値を制御します。 **await** 演算子を適用すると、メソッドによって返されるオブジェクトの **GetResult** を呼び出した結果が取得されます。 この例では、**SyndicationFeed** は **RetrieveFeedAsync.GetResult()** の結果です。

非同期メソッドを使うと、シグネチャを調べて、メソッドから返される値を待機した後でどのようなデータを取得したかを確認することができます。 UWP の各非同期 API は、次のいずれかの型を返します。

-   [**IAsyncOperation&lt;TResult&gt;**](https://msdn.microsoft.com/library/windows/apps/BR206598)
-   [**IAsyncOperationWithProgress&lt;TResult, TProgress&gt;**](https://msdn.microsoft.com/library/windows/apps/BR206594)
-   [**IAsyncAction**](https://msdn.microsoft.com/library/windows/apps/windows.foundation.iasyncaction.aspx)
-   [**IAsyncActionWithProgress&lt;TProgress&gt;**](https://msdn.microsoft.com/library/windows/apps/br206581.aspx)

非同期メソッドの結果の型は、`      TResult` 型パラメーターと同じです。 `TResult` のない型には結果がありません。 その場合の結果は **void** と見なすことができます。 Visual Basic の [Sub](https://msdn.microsoft.com/library/windows/apps/xaml/831f9wka.aspx) プロシージャは、戻り値の型が **void** のメソッドと同じです。

次の表に、非同期メソッドの例と、それぞれの戻り値と結果の型を示します。

| 非同期メソッド                                                                           | 戻り値の型                                                                                                                                        | 結果の型                                       |
|-----------------------------------------------------------------------------------------------|----------------------------------------------------------------------------------------------------------------------------------------------------|---------------------------------------------------|
| [**SyndicationClient.RetrieveFeedAsync**](https://msdn.microsoft.com/library/windows/apps/BR243460)     | [**IAsyncOperationWithProgress&lt;SyndicationFeed, RetrievalProgress&gt;**](https://msdn.microsoft.com/library/windows/apps/BR206594)                                 | [**SyndicationFeed**](https://msdn.microsoft.com/library/windows/apps/BR243485) |
| [**FileOpenPicker.PickSingleFileAsync**](https://msdn.microsoft.com/library/windows/apps/JJ635275) | [**IAsyncOperation&lt;StorageFile&gt;**](https://msdn.microsoft.com/library/windows/apps/BR206598)                                                                                | [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/BR227171)          |
| [**XmlDocument.SaveToFileAsync**](https://msdn.microsoft.com/library/windows/apps/BR206284)                 | [**IAsyncAction**](https://msdn.microsoft.com/library/windows/apps/windows.foundation.iasyncaction.aspx)                                                                                                           | **void**                                          |
| [**InkStrokeContainer.LoadAsync**](https://msdn.microsoft.com/library/windows/apps/Hh701757)               | [**IAsyncActionWithProgress&lt;UInt64&gt;**](https://msdn.microsoft.com/library/windows/apps/br206581.aspx)                                                                   | **void**                                          |
| [**DataReader.LoadAsync**](https://msdn.microsoft.com/library/windows/apps/BR208135)                            | [**DataReaderLoadOperation**](https://msdn.microsoft.com/library/windows/apps/BR208120)、**IAsyncOperation&lt;UInt32&gt;** を実装するカスタムの結果クラス | [**UInt32**](https://msdn.microsoft.com/library/windows/apps/br206598.aspx)                     |

 

「[**UWP アプリの .NET**](https://msdn.microsoft.com/library/windows/apps/xaml/br230232.aspx)」で定義されている非同期メソッドの戻り値の型は [**Task**](https://msdn.microsoft.com/library/windows/apps/xaml/system.threading.tasks.task.aspx) または [**Task&lt;TResult&gt;**](https://msdn.microsoft.com/library/windows/apps/xaml/dd321424.aspx) です。 **Task** を返すメソッドは、[**IAsyncAction**](https://msdn.microsoft.com/library/windows/apps/windows.foundation.iasyncaction.aspx) を返す UWP の非同期メソッドに似ています。 どちらの場合も、非同期メソッドの結果は **void** です。 戻り値の型 **Task&lt;TResult&gt;** は、タスク実行時の非同期メソッドの結果が `TResult` 型パラメーターと同じ型であるという点で、[**IAsyncOperation&lt;TResult&gt;**](https://msdn.microsoft.com/library/windows/apps/BR206598) に似ています。 **UWP アプリ用 .NET** とタスクの使い方について詳しくは、「[Windows ランタイム アプリ用 .NET の概要](https://msdn.microsoft.com/library/windows/apps/xaml/br230302.aspx)」をご覧ください。

## <a name="handling-errors"></a>エラーの処理


**await** 演算子を使って非同期メソッドから結果を取得する場合は、同期メソッドの場合と同じように、**try/catch** ブロックを使って非同期メソッドで発生するエラーを処理できます。 前の例では、**RetrieveFeedAsync** メソッドと **await** 操作が **try/catch** ブロックでラップされて、例外がスローされたときにエラーを処理するようになっています。

非同期メソッドが他の非同期メソッドを呼び出している場合は、例外が発生した非同期メソッドが外側のメソッドに伝達されます。 つまり、最も外側のメソッドで **try/catch** ブロックを使うと、入れ子になっている非同期メソッドのエラーをキャッチできます。 これも、同期メソッドで例外をキャッチする方法と同様です。 ただし、**catch** ブロックで **await** を使うことはできません。

**ヒント:** 以降では、Microsoft Visual Studio2005 c# では、 **await**で使える**catch**ブロックします。

## <a name="summary-and-next-steps"></a>要約と次のステップ

ここで説明した非同期メソッドの呼び出しのパターンは、イベント ハンドラーで非同期 API を呼び出す場合に使う最も簡単な方法です。 このパターンは、**void** または **Sub** (Visual Basic) を返すオーバーライドされたメソッドで非同期メソッドを呼び出す場合にも使うことができます。

UWP で非同期メソッドを使う場合は、次の点を忘れないでください。

-   非同期メソッドには、表記の規則により "Async" で終わる名前が付いています。
-   **await** 演算子を使うメソッドには、**async** キーワードでマークされた宣言が必要です。
-   アプリは、**await** 演算子を見つけると、非同期メソッドの実行中もユーザー操作への応答性を保ちます。
-   非同期メソッドによって返される値を待機しているときに、結果を含むオブジェクトが返されます。 一般的には、戻り値に含まれている結果は有用なデータであり、戻り値そのものではありません。 結果に含まれている値の型は、非同期メソッドの戻り値の型を調べればわかります。
-   非同期 API と **async** パターンを使うことにより、多くの場合、アプリの応答性が向上します。

このトピックの例では、次のようなテキストが出力されます。

``` syntax
Windows Experience Blog
PC Snapshot: Sony VAIO Y, 8/9/2011 10:26:56 AM -07:00
Tech Tuesday Live Twitter #Chat: Too Much Tech #win7tech, 8/8/2011 12:48:26 PM -07:00
Windows 7 themes: what’s new and what’s popular!, 8/4/2011 11:56:28 AM -07:00
PC Snapshot: Toshiba Satellite A665 3D, 8/2/2011 8:59:15 AM -07:00
Time for new school supplies? Find back-to-school deals on Windows 7 PCs and Office 2010, 8/1/2011 2:14:40 PM -07:00
Best PCs for blogging (or working) on the go, 8/1/2011 10:08:14 AM -07:00
Tech Tuesday – Blogging Tips and Tricks–#win7tech, 8/1/2011 9:35:54 AM -07:00
PC Snapshot: Lenovo IdeaPad U460, 7/29/2011 9:23:05 AM -07:00
GIVEAWAY: Survive BlogHer with a Sony VAIO SA and a Samsung Focus, 7/28/2011 7:27:14 AM -07:00
3 Ways to Stay Cool This Summer, 7/26/2011 4:58:23 PM -07:00
Getting RAW support in Photo Gallery & Windows 7 (…and a contest!), 7/26/2011 10:40:51 AM -07:00
Tech Tuesdays Live Twitter Chats: Photography Tips, Tricks and Essentials, 7/25/2011 12:33:06 PM -07:00
3 Tips to Go Green With Your PC, 7/22/2011 9:19:43 AM -07:00
How to: Buy a Green PC, 7/22/2011 9:13:22 AM -07:00
Windows 7 themes: the distinctive artwork of Cheng Ling, 7/20/2011 9:53:07 AM -07:00
```
