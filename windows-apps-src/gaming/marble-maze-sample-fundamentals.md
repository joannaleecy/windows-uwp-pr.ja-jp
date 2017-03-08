---
author: mtoepke
title: "Marble Maze サンプルの基礎"
description: "このドキュメントでは、Marble Maze プロジェクトの基本的な特性について説明します。たとえば、Windows ランタイム環境で Visual C++ をどのように使うか、どのように作られ、構成され、ビルドされるかなどです。"
ms.assetid: 73329b29-62e3-1b36-01db-b7744ee5b4c3
ms.author: mtoepke
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, ゲーム, サンプル, DirectX, 基礎"
translationtype: Human Translation
ms.sourcegitcommit: c6b64cff1bbebc8ba69bc6e03d34b69f85e798fc
ms.openlocfilehash: cc155d7a454cabe5c0d820f5d74313dfeaf01830
ms.lasthandoff: 02/07/2017

---

# <a name="marble-maze-sample-fundamentals"></a>Marble Maze サンプルの基礎


\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください \]


このドキュメントでは、Marble Maze プロジェクトの基本的な特性について説明します。たとえば、Windows ランタイム環境で Visual C++ をどのように使うか、どのように作られ、構成され、ビルドされるかなどです。 また、コードで使われるいくつかの規則についても説明します。

> **注**   このドキュメントに対応するサンプル コードは、[DirectX Marble Maze ゲームのサンプルに関するページ](http://go.microsoft.com/fwlink/?LinkId=624011)にあります。

 
## 
このドキュメントでは、ユニバーサル Windows プラットフォーム (UWP) ゲームの計画と開発の際に重要となるいくつかの事柄について説明します。取り上げる内容は次のとおりです。

-   DirectX UWP ゲームを作るために、C++ アプリケーションで **DirectX 11 アプリ (ユニバーサル Windows)** テンプレートを使います。 一般的なプロジェクトをビルドするときのように、UWP アプリ プロジェクトをビルドするために Visual Studio を使います。
-   より新しい、オブジェクト指向に沿った方法で UWP アプリを開発できるようなクラスとインターフェイスが、Windows ランタイムには用意されています。
-   Windows ランタイム変数の有効期間を管理するにはハット (^) 記号を付けたオブジェクト参照、COM オブジェクトの有効期間を管理するには [**Microsoft::WRL::ComPtr**](https://msdn.microsoft.com/library/windows/apps/br244983.aspx)、その他のすべてのヒープ割り当て C++ オブジェクトの有効期間を管理するには [**std::shared\_ptr**](https://msdn.microsoft.com/library/windows/apps/bb982026.aspx) または [**std::unique\_ptr**](https://msdn.microsoft.com/library/windows/apps/ee410601.aspx) を使います。
-   ほとんどの場合、予期しないエラーを処理するには、結果コードではなく例外処理を使います。
-   アプリのエラーの発見に役立てるために、コード分析ツールと共に SAL 注釈を使います。

## <a name="creating-the-visual-studio-project"></a>Visual Studio プロジェクトの作成


サンプルをダウンロードおよび展開してある場合は、Visual Studio で MarbleMaze.sln ソリューション ファイルを開くと、コードが表示されます。 また、MSDN サンプル ギャラリーの [DirectX Marble Maze ゲームのサンプルに関するページ](http://go.microsoft.com/fwlink/?LinkId=624011)で、**[コードの参照]** タブを選択してソースを表示することもできます。

Marble Maze の Visual Studio プロジェクトを作ったときには、既にあるプロジェクトを利用しました。 しかし、DirectX UWP ゲームで必要となる基本的な機能を持つプロジェクトがまだない場合は、Visual Studio **DirectX 11 アプリ (ユニバーサル Windows)** テンプレートに基づくプロジェクトを作ることをお勧めします。このテンプレートには、基本的な機能を備えた 3-D アプリケーションが用意されているためです。

**DirectX 11 アプリ (ユニバーサル Windows)** テンプレートで重要なプロジェクト設定の 1 つは、プログラムが Windows ランタイム言語拡張機能を使えるようにする **/ZW** オプションです。 Visual Studio テンプレートを使う場合、このオプションは既定で有効になっています。

> **注意**   **/ZW** オプションは、**/clr** などのオプションとの互換性がありません。**/clr** の場合は、同じ Visual C++ プロジェクトで .NET Framework と Windows ランタイムの両方をターゲットにすることはできないことを意味します。

 

Windows ストアで入手するすべての UWP アプリは、アプリ パッケージの形式で提供されます。 アプリ パッケージには、アプリについての情報が記載されたパッケージ マニフェストが含まれています。 たとえば、アプリの機能 (つまり、保護されたシステム リソースやユーザー データへの必要なアクセス) を指定できます。 アプリで特定の機能が必須であると決めた場合は、パッケージ マニフェストを使って、必要な機能を宣言します。 マニフェストでは、サポートされているデバイスの回転、タイル画像、スプラッシュ画面など、プロジェクト プロパティを指定することもできます。 アプリ パッケージについて詳しくは、「[アプリのパッケージ化](https://msdn.microsoft.com/library/windows/apps/mt270969)」をご覧ください。

##  <a name="building-deploying-and-running-the-game"></a>ゲームのビルド、展開、実行


UWP アプリ プロジェクトのビルド方法は、一般的なプロジェクトのビルド方法と同じです。 メニュー バーで、**[ビルド]、[ソリューションのビルド]** の順にクリックします。ビルド手順によってコードがコンパイルされ、UWP アプリとして使えるようにパッケージ化されます。

プロジェクトをビルドしたら、それを展開する必要があります。メニュー バーで、**[ビルド]、[ソリューションの配置]** の順にクリックします。デバッガーからゲームを実行すると、Visual Studio でもプロジェクトを展開できます。

プロジェクトを展開したら、Marble Maze タイルを選んでゲームを実行します。 または、Visual Studio のメニュー バーで、**[デバッグ]**、[デバッグの開始] の順にクリックします。

###  <a name="controlling-the-game"></a>ゲームの制御

Marble Maze の制御には、タッチ、加速度計、Xbox 360 コントローラー、マウスを使えます。

-   アクティブなメニュー項目を変更するには、コントローラーの方向パッドを使います。
-   メニュー項目を選択するには、タッチ、A ボタン、[スタート] ボタン、マウスを使います。
-   迷路を傾けるには、タッチ、加速度計、左スティック、マウスを使います。
-   ハイ スコア表などのメニューを閉じるには、タッチ、A ボタン、[スタート] ボタン、マウスを使います。
-   ゲームを一時停止または再開するには、[スタート] ボタンまたは P キーを使います。
-   ゲームを再開始するには、コントローラーの [戻る] ボタンやキーボードの Home キーを使います。
-   ハイ スコア表が表示されている場合に、すべてのスコアをクリアするには、[戻る] ボタンか Home キーを使います。

##  <a name="code-conventions"></a>コードの規則


Windows ランタイムは、特別なアプリケーション環境だけで実行される UWP アプリの作成に使うプログラミング インターフェイスです。 このようなアプリは、認定された関数、データ型、デバイスを使い、Windows ストアから配布されます。 Windows ランタイムの最も基本となる部分を構成しているのは、アプリケーション バイナリ インターフェイス (ABI) です。 ABI は、JavaScript、.NET 言語、Visual C++ など、複数のプログラミング言語から Windows ランタイム API にアクセスできるようにするための基礎となるバイナリ コントラクトです。

Windows ランタイム API を JavaScript や .NET から呼び出すには、各言語環境に固有のプロジェクションが必要となります。 Windows ランタイム API を JavaScript または .NET から呼び出すとき、実際にはプロジェクションを呼び出し、そこからさらに、基になる ABI 関数を呼び出すことになります。 ABI 関数は C++ から直接呼び出すことができますが、Microsoft は、C++ 用のプロジェクションも併せて提供しています。そのようにすることで、Windows ランタイム API の扱いがシンプルになると共に、高いパフォーマンスを維持できるためです。 また、実際に Windows ランタイムのプロジェクションをサポートする、Visual C++ の言語拡張機能も Microsoft から提供されています。 こうした言語拡張機能の多くは、C++/CLI 言語の構文と似ています。 ただし、ネイティブ アプリはこの構文を使って、共通言語ランタイム (CLR) をターゲットにするのではなく、Windows ランタイムをターゲットにします。 オブジェクト参照、またはハット (^) 修飾子は、この新しい構文の重要な要素です。これによって、参照カウントに基づくランタイム オブジェクトの自動削除が可能になるためです。 Windows ランタイム オブジェクトの有効期間を管理するために **AddRef** や **Release** などのメソッドを呼び出さなくても、他のコンポーネントがオブジェクトを参照していないときに (たとえばオブジェクトのスコープが終わったり、すべての参照が **nullptr** に設定されたりしたときに)、ランタイムがオブジェクトを削除します。 Visual C++ を使った UWP アプリの作成に関して、もう 1 つの重要な要素は **ref new** キーワードです。 参照カウントで管理される Windows ランタイム オブジェクトを作成するには、**new** ではなく **ref new** を使います。 詳しくは、「[型システム (C++/CX)](https://msdn.microsoft.com/library/windows/apps/hh755822)」をご覧ください。

> **重要**  
**^** と **ref new** は、Windows ランタイム オブジェクトを作成するときと Windows ランタイム コンポーネントを作成するとき以外は使わないでください。 Windows ランタイムを使わないコア アプリケーション コードを作成する際は、標準の C++ 構文を使うことができます。

Marble Maze は、ヒープに割り当てられたオブジェクトを **^** と [**Microsoft::WRL::ComPtr**](https://msdn.microsoft.com/library/windows/apps/br244983.aspx) を使って管理し、メモリ リークを最小限に抑えます。 Windows ランタイム変数の有効期間を管理するときは ^ を、COM 変数の有効期間を管理するとき (DirectX 使用時など) は **ComPtr** を使うようにお勧めします。ヒープに割り当てられるその他すべての C++ オブジェクトは、[**std::shared\_ptrr**](https://msdn.microsoft.com/library/windows/apps/bb982026) または [**std::unique\_ptr**](https://msdn.microsoft.com/library/windows/apps/ee410601) を使って管理するようにします。

 

C++ UWP アプリで使える言語拡張機能について詳しくは、「[Visual C++ 言語のリファレンス (C++/CX)](https://msdn.microsoft.com/library/windows/apps/hh699871)」をご覧ください。

###  <a name="error-handling"></a>エラー処理

Marble Maze では、予期しないエラーに対応する主な方法として例外処理を使います。 ゲーム コードでは従来、エラーを示すためにログやエラー コード (**HRESULT** 値など) を使ってきましたが、例外処理には 2 つの主な利点があります。 1 つ目は、コードが読みやすく、保守しやすいことです。 コードの観点からは、例外処理はエラー処理ルーティンに効率よくエラーを伝達することができます。 エラー コードを使った場合は通常、個々の関数で明示的にエラーを伝達する必要があります。 2 つ目の利点は、例外が発生したところで中断するように Visual Studio デバッガーを構成すれば、エラーが発生したときに、その位置やコンテキストですぐに止めることができることです。 例外処理は、Windows ランタイムでも広く使われています。 したがって、自分のコード内で例外処理を使うことにより、あらゆるエラー処理を 1 つのモデルに統合することができます。

エラー処理モデルでは、次の規則を使うことをお勧めします。

-   例外は、予期しないエラーを知らせるために使います。
-   コードのフローを制御するためには、例外を使わないでください。
-   キャッチする例外は安全に処理、回復できるものだけにしてください。 それ以外の例外はキャッチせず、アプリを強制終了させます。
-   **HRESULT** を返す DirectX ルーチンを呼び出す場合は、**DX::ThrowIfFailed** 関数を使います。 この関数は、DirectXSample.h 内で定義されています。**ThrowIfFailed** は、渡された **HRESULT** がエラー コードであれば、例外をスローします。 たとえば、**E\_POINTER** では **ThrowIfFailed** が [**Platform::NullReferenceException**](https://msdn.microsoft.com/library/windows/apps/hh755823.aspx) をスローします。

    **ThrowIfFailed** を使うときは、次の例に示すように DirectX 呼び出しを別の行に記述して、コードが読みやすくなるようにします。

    ```cpp
    // Identify the physical adapter (GPU or card) this device is running on.
    ComPtr<IDXGIAdapter> dxgiAdapter;
    DX::ThrowIfFailed(
        dxgiDevice->GetAdapter(&dxgiAdapter)
        );
    ```

-   予期しないエラーのために **HRESULT** を使うことは避けるようにお勧めしますが、より重要なのは、コードのフローを制御するために例外処理を使わないようにすることです。 そのため、コードのフローを制御するために必要な場合は、**HRESULT** 戻り値を使う方が適切です。

###  <a name="sal-annotations"></a>SAL 注釈

アプリのエラーの発見に役立てるために、コード分析ツールと共に SAL 注釈を使います。

Microsoft Source-code Annotation Language (SAL) を使うと、関数がパラメーターをどのように使うかを説明する注を付けることができます。 SAL 注釈は、戻り値についても説明します。 SAL 注釈を C/C++ コード分析ツールと共に使うと、C や C++ ソース コードの潜在的な不具合を検出できます。 ツールによって報告される一般的なコーディング エラーは、バッファー オーバーラン、初期化されていないメモリ、null ポインターの逆参照、メモリとリソースのリークなどです。

BasicLoader.h で宣言されている **BasicLoader::LoadMesh** メソッドを検討します。 このメソッドは、\_In\_ を使って *filename* が入力パラメーターである (つまり、読み取られるだけである) ことを指定します。また、\_Out\_ を使って *vertexBuffer* と *indexBuffer* が出力パラメーターである (つまり、書き込まれるだけである) ことを指定します。さらに、\_Out\_opt\_ を使って *vertexCount* と *indexCount* が省略可能な出力パラメーターである (書き込まれる場合がある) ことを指定します。 *vertexCount* と *indexCount* は省略可能な出力パラメーターであるため、**nullptr** にすることができます。 C/C++ コード分析ツールは、このメソッドの呼び出しを調べて、渡されるパラメーターが条件を満たしていることを確認します。

```cpp
void LoadMesh(
    _In_ Platform::String^ filename,
    _Out_ ID3D11Buffer** vertexBuffer,
    _Out_ ID3D11Buffer** indexBuffer,
    _Out_opt_ uint32* vertexCount,
    _Out_opt_ uint32* indexCount
    );
```

アプリのコード分析を行うには、メニュー バーで **[ビルド]**、[ソリューションでコード分析を実行] の順に選択します。 コード分析について詳しくは、「[コード分析による C/C++ コード品質の分析](https://msdn.microsoft.com/library/windows/apps/ms182025.aspx)」をご覧ください。

利用できる注釈の完全なリストは、sal.h で定義されています。 詳しくは、「[SAL 注釈](https://msdn.microsoft.com/library/windows/apps/ms235402.aspx)」をご覧ください。

## <a name="next-steps"></a>次の手順


Marble Maze アプリケーション コードの構造と、DirectX UWP アプリの構造と従来のデスクトップ アプリケーションの構造の違いについての情報を、「[Marble Maze のアプリケーション構造](marble-maze-application-structure.md)」で読みます。

## <a name="related-topics"></a>関連トピック


* [Marble Maze のアプリケーション構造](marble-maze-application-structure.md)
* [Marble Maze、C++ と DirectX での UWP ゲームの開発](developing-marble-maze-a-windows-store-game-in-cpp-and-directx.md)

 

 





