---
author: TylerMSFT
ms.assetid: 23FE28F1-89C5-4A17-A732-A722648F9C5E
title: 非同期プログラミング
description: このトピックでは、ユニバーサル Windows プラットフォーム (UWP) での非同期プログラミングと、C#、Microsoft Visual Basic .NET、Visual C\+\+ コンポーネント拡張機能 (C\+\+/CX)、および JavaScript における非同期プログラミングの表現について説明します。
---
# 非同期プログラミング

\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132) をご覧ください\]


このトピックでは、ユニバーサル Windows プラットフォーム (UWP) での非同期プログラミングと、C#、Microsoft Visual Basic .NET、Visual C++ コンポーネント拡張機能 (C++/CX)、および JavaScript における非同期プログラミングの表現について説明します。

非同期プログラミングを使うと、アプリが時間のかかる可能性がある操作を実行しているときでも、アプリの応答性を保つことができます。 たとえば、インターネットからコンテンツをダウンロードするアプリは、コンテンツが到着するまで数秒待機する可能性があります。 UI スレッドで同期メソッドを使ってコンテンツを取得すると、アプリはメソッドから制御が返されるまでブロックされます。 アプリが操作に応答せず、応答していないと思ったユーザーが苛立ちを感じる可能性があります。 これよりもはるかに優れた方法は非同期プログラミングを使うことです。非同期プログラミングでは、アプリは実行を続けて、操作が完了するまで待機している間も UI に応答します。

処理の完了までに時間がかかるメソッドの場合、UWP で非同期プログラミングを使うのは標準で、例外ではありません。 JavaScript、C#、Visual Basic、C++/CX の各言語では、非同期メソッド用の言語サポートが提供されます。

## UWP での非同期プログラミング

[
            **MediaCapture**](https://msdn.microsoft.com/library/windows/apps/BR241124) API や [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/BR227171) API など、UWP 機能の多くは非同期 API として公開されます。 慣例により、非同期 API 関数の名前は、API が呼び出された後に関数の実行部が実行される可能性があることを示す "Async" で終わります。

ユニバーサル Windows プラットフォーム (UWP) アプリで非同期 API を使う場合、コードは一貫した方法で非ブロック呼び出しを行います。 これらの非同期パターンを独自の API 定義に実装すると、呼び出し元はコードを理解し、予測可能な方法で使うことができます。

次に、非同期 UWP API を呼び出す必要がある一般的なタスクをいくつか示します。

-   メッセージ ダイアログの表示

-   ファイル システムの操作 (ファイル ピッカーの表示)

-   インターネットを介したデータの送受信。

-   ソケット、ストリーム、接続の使用

-   予定、連絡先、カレンダーの操作

-   ファイルの種類の操作 (Portable Document Format (PDF) ファイルを開く、画像やメディア形式のデコードなど)。

-   デバイスやサービスの操作

UWP の非同期パターンを利用すると、スレッドの明示的な管理を完全に回避できる場合があります。 各プログラミング言語では、次に示すように独自の方法で UWP の非同期パターンがサポートされます。

| プログラミング言語 | 非同期表現           |
|----------------------|---------------------------------------|
| C#                  | **async** キーワード、**await** 演算子 |
| Visual Basic         | **Async** キーワード、**Await** 演算子 |
| C++/CX               | **task** クラス、**.then** メソッド      |
| JavaScript           | promise オブジェクト、**then** 関数     |

 

## C# と Visual Basic を使った UWP での非同期パターン


C# または Visual Basic で書かれたコードのセグメントは、通常は同期して実行されます。つまり、ある行が実行されるときには、その行は次の行が実行される前に完了します。 以前は非同期実行の Microsoft .NET プログラミング モデルがありましたが、作成されたコードでは、コードで実行しようとしているタスクではなく、非同期コードを実行するしくみに重点が置かれる傾向があります。 UWP、.NET framework、C# と Visual Basic のコンパイラでは、コードから非同期のしくみを取り出す機能が追加されました。 これにより、.NET や UWP を使う場合、いつどのように達成するかではなく何を達成するかに重点を置いた非同期コードを記述できます。 記述される非同期コードは、同期コードに類似しています。 詳しくは、「[C# または Visual Basic での非同期 API の呼び出し](call-asynchronous-apis-in-csharp-or-visual-basic.md)」をご覧ください。

## C++ を使った UWP での非同期パターン


C++/CX では、非同期プログラミングは [**task クラス**](https://msdn.microsoft.com/en-us/library/windows/apps/xaml/hh750113.aspx) とその [**then メソッド**](https://msdn.microsoft.com/en-us/library/windows/apps/xaml/hh750044.aspx) に基づいています。 構文は JavaScript の promise の構文に似ています。 **task クラス**とそれに関連する型は、スレッド コンテキストの取り消しと管理に使われる機能を提供します。 詳しくは、「[C++ での非同期プログラミング](asynchronous-programming-in-cpp-universal-windows-platform-apps.md)」をご覧ください。

[
            **create\_async 関数**](https://msdn.microsoft.com/en-us/library/windows/apps/xaml/hh750102.aspx) は、JavaScript または UWP をサポートする任意の言語から利用できる非同期 API の生成をサポートします。 詳しくは、「[C++ で非同期操作を作成](https://msdn.microsoft.com/en-us/library/windows/apps/xaml/hh750082.aspx)」をご覧ください。

## JavaScript を使った UWP での非同期パターン

JavaScript の非同期プログラミングでは、[Common JS Promises/A](http://wiki.commonjs.org/wiki/Promises/A) 提唱の標準に従って、非同期メソッドで promise オブジェクトを返します。 Promise は、UWP と JavaScript 用 Windows ライブラリの両方で使われます。

promise オブジェクトは、将来取得されたときに値を表します。 UWP では、promise オブジェクトをファクトリ関数から取得します。ファクトリ関数には、慣例により "Async" で終わる名前が付いています。

多くの場合、非同期関数の呼び出しは従来の関数の呼び出しと同じくらい簡単です。 違いは、結果またはエラーに対するハンドラーの割り当てと操作の開始に [**then**](https://msdn.microsoft.com/library/windows/apps/BR229728) メソッドまたは [**done**](https://msdn.microsoft.com/library/windows/apps/Hh701079) メソッドを使うことです。

## 関連トピック

* [C# または Visual Basic での非同期 API の呼び出し](call-asynchronous-apis-in-csharp-or-visual-basic.md)
* [Async と Await を使用した非同期プログラミング (C# と Visual Basic)](http://msdn.microsoft.com/library/hh191443(vs.110).aspx)
* [リバーシの機能のシナリオ: 非同期コード](https://msdn.microsoft.com/en-us/library/windows/apps/xaml/jj712233.aspx#async)



<!--HONumber=May16_HO2-->


