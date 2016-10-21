---
author: mcleblanc
ms.assetid: 5A47301A-2291-4FC8-8BA7-55DB2A5C653F
title: "SQLite データベース"
description: "SQLite は、サーバーを使わない埋め込みデータベース エンジンです。 この記事では、SDK に付属している SQLite ライブラリを使って、独自の SQLite ライブラリをユニバーサル Windows アプリにパッケージ化する方法、およびソースから SQLite ライブラリを構築する方法について説明します。"
translationtype: Human Translation
ms.sourcegitcommit: 6530fa257ea3735453a97eb5d916524e750e62fc
ms.openlocfilehash: 33148e8cfe301c6016d3f8a16bbcc904ca403d0e

---
# SQLite データベース

\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]


SQLite は、サーバーを使わない埋め込みデータベース エンジンです。 この記事では、SDK に付属している SQLite ライブラリを使って、独自の SQLite ライブラリをユニバーサル Windows アプリにパッケージ化する方法、およびソースから SQLite ライブラリを構築する方法について説明します。

## SQLite についての説明と SQLite を使う状況

SQLite は、オープン ソースの埋め込みデータベース エンジンで、サーバーを使いません。 SQLite は、長い年月をかけて、さまざまなプラットフォームやデバイスでデータを保管するために使われる、デバイス側の主要なテクノロジとして登場しました。 ユニバーサル Windows プラットフォーム (UWP) では、すべての Windows 10 デバイス ファミリで、ローカル記憶域用に SQLite をサポートしており、その利用を推奨しています。

SQLite は、電話アプリや、Windows 10 IoT Core (IoT Core) 用埋め込みアプリケーションに最適です。また、企業向けのリレーショナル データベース サーバー (RDBS) のデータ用キャッシュとしても適しています。 ほとんどのローカル データ アクセスのニーズを満たします。条件として、高負荷の同時実行の書き込みを伴わない (ビッグ データ規模のシナリオでない) ことが挙げられますが、この条件はほとんどのアプリで発生する可能性が低いと考えられます。

メディア再生アプリケーションやゲーム アプリケーションでは、SQLite を、ストア カタログや他のアセット (ゲームのレベルなど) を保存するためのファイル形式として使うことができます。この形式で保存したデータは、Web サーバーから手を加えない状態でダウンロードすることができます。

## UWP アプリ プロジェクトへの SQLite の追加

SQLite を UWP プロジェクトに追加するには、次の 3 つの方法があります。

1.  [SDK の SQLite を使う](#using-the-sdk-sqlite)
2.  [SQLite をアプリ パッケージに含める](#including-sqlite-in-the-app-package)
3.  [Visual Studio でソースから SQLite を構築する](#building-sqlite-from-source-in-visual-studio)

### SDK の SQLite を使う

UWP SDK に含まれている SQLite ライブラリを使って、アプリケーション パッケージのサイズを小さくし、プラットフォームに依存してライブラリを定期的に更新することができます。 SDK の SQLite を利用すると、パフォーマンスが向上する場合もあります。たとえば、システム コンポーネントで利用される際に SQLite ライブラリが既にメモリに読み込まれていれば、起動時間が短縮される可能性があります。

SDK の SQLite を参照するには、次のヘッダーをプロジェクトに追加します。 ヘッダーには、プラットフォームでサポートされている SQLite のバージョンも含まれています。

`#include <winsqlite/winsqlite3.h>`

winsqlite3.lib にリンクするようにプロジェクトを構成します。 **ソリューション エクスプ ローラー**でプロジェクトを右クリックし、**[プロパティ]** &gt; **[リンカー]** &gt; **[入力]** の順に選択して、winsqlite3.lib を **[追加の依存関係]** に追加します。

### 2. SQLite をアプリ パッケージに含める

場合によっては、SDK バージョンを使うのではなく、独自のライブラリをパッケージ化することができます。たとえば、クロスプラットフォーム クライアントで特定のバージョンの SQLite を使うとき、SDK に含まれている SQLite のバージョンとは異なる場合があります。

SQLite.org から、または [拡張機能と更新プログラム] ツールを使って、利用可能なユニバーサル Windows プラットフォームの Visual Studio の拡張機能に SQLite ライブラリをインストールします。

![[拡張機能と更新プログラム] 画面](./images/extensions-and-updates.png)

拡張機能をインストールしたら、コードで次のヘッダー ファイルを参照します。

`#include <sqlite3.h>`

### 3. Visual Studio でソースから SQLite を構築する

場合によっては、[さまざまなコンパイラ オプション](http://www.sqlite.org/compile.html) を使って独自の SQLite バイナリをコンパイルし、ファイル サイズを小さくしたり、ライブラリのパフォーマンスを調整したり、アプリケーションに合わせて機能セットを調整したりすることができます。 SQLite には、プラットフォーム構成向けのオプションが用意されており、既定のパラメーター値の設定、サイズ制限の設定、動作特性の制御、通常は無効になっている機能の有効化、通常は有効になっている機能の無効化、機能の省略、分析とデバッグの有効化、および Windows でのメモリ割り当て動作の管理などを行うことができます。

*ソースを Visual Studio プロジェクトに追加する*

SQLite のソース コードは、[SQLite.org のダウンロード ページ](https://www.sqlite.org/download.html)でダウンロードできます。 このファイルを、SQLite を使うアプリケーションの Visual Studio プロジェクトに追加します。

*プリプロセッサを構成する*

他の[コンパイル時のオプション](http://www.sqlite.org/compile.html)に加えて、常に SQLITE\_OS\_WINRT と SQLITE\_API=\_\_declspec(dllexport) を使います。

![[SQLite プロパティ ページ] 画面](./images/property-pages.png)

## SQLite データベースの管理

SQLite データベースは、SQLite C API を使って、作成、更新、削除することができます。 SQLite C API について詳しくは、SQLite.org の「[SQLite C/C++ インターフェイスの概要](http://www.sqlite.org/cintro.html)」のページをご覧ください。

SQLite のしくみを正しく理解するには、SQL データベースの主なタスクである SQL ステートメントの評価からさかのぼって作業を行います。 そのためには、2 つのオブジェクトを把握しておいてください。

-   [データベース接続ハンドル](https://www.sqlite.org/c3ref/sqlite3.html)
-   [prepared ステートメント オブジェクト](https://www.sqlite.org/c3ref/stmt.html)

これらのオブジェクトでデータベース操作を実行するために、次の 6 つのインターフェイスがあります。

-   [sqlite3\_open()](https://web.archive.org/web/20141228070025/http:/www.sqlite.org/c3ref/open.html)
-   [sqlite3\_prepare()](https://web.archive.org/web/20141228070025/http:/www.sqlite.org/c3ref/prepare.html)
-   [sqlite3\_step()](https://web.archive.org/web/20141228070025/http:/www.sqlite.org/c3ref/step.html)
-   [sqlite3\_column()](https://web.archive.org/web/20141228070025/http:/www.sqlite.org/c3ref/column_blob.html)
-   [sqlite3\_finalize()](https://web.archive.org/web/20141228070025/http:/www.sqlite.org/c3ref/finalize.html)
-   [sqlite3\_close()](https://web.archive.org/web/20141228070025/http:/www.sqlite.org/c3ref/close.html)

 

 







<!--HONumber=Aug16_HO3-->


