---
title: Marble Maze サンプルの基礎
description: このドキュメントには、Marble Maze プロジェクトの基本的な特性について説明します。たとえば、Windows ランタイム環境で Visual C を使用する方法を作成する方法と、構造化し、組み込まれている方法です。
ms.assetid: 73329b29-62e3-1b36-01db-b7744ee5b4c3
ms.date: 08/22/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, サンプル, DirectX, 基礎
ms.localizationpriority: medium
ms.openlocfilehash: 94dd22a6f6b1ace5589104574a695b236c1ebd39
ms.sourcegitcommit: 8921a9cc0dd3e5665345ae8eca7ab7aeb83ccc6f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8896645"
---
# <a name="marble-maze-sample-fundamentals"></a>Marble Maze サンプルの基礎




このトピックでは、Marble Maze プロジェクトの基本的な特性について説明します。たとえば、Windows ランタイム環境で Visual C++ をどのように使うか、どのように作られ、構成され、ビルドされるかなどです。 また、コードで使われるいくつかの規則についても説明します。

> [!NOTE]
> このドキュメントに対応するサンプル コードは、[DirectX Marble Maze ゲームのサンプルに関するページ](http://go.microsoft.com/fwlink/?LinkId=624011)にあります。

このドキュメントでは、ユニバーサル Windows プラットフォーム (UWP) ゲームの計画と開発の際に重要となるいくつかの事柄について説明します。取り上げる内容は次のとおりです。

-   DirectX UWP ゲームを作るために、Visual Studio で **DirectX 11 アプリ (ユニバーサル Windows) **Visual C++ テンプレートを使います。
-   より新しい、オブジェクト指向に沿った方法で UWP アプリを開発できるようなクラスとインターフェイスが、Windows ランタイムには用意されています。
-   Windows ランタイム変数の有効期間を管理するにはハット (^) 記号を付けたオブジェクト参照、COM オブジェクトの有効期間を管理するには [Microsoft::WRL::ComPtr](https://docs.microsoft.com/cpp/windows/comptr-class)、その他のすべてのヒープ割り当て C++ オブジェクトの有効期間を管理するには [std::shared\_ptr](https://docs.microsoft.com/cpp/standard-library/shared-ptr-class) または [std::unique\_ptr](https://docs.microsoft.com/cpp/standard-library/unique-ptr-class) を使います。
-   ほとんどの場合、予期しないエラーを処理するには、結果コードではなく例外処理を使います。
-   コード分析ツールと共に[SAL 注釈](https://docs.microsoft.com/visualstudio/code-quality/using-sal-annotations-to-reduce-c-cpp-code-defects)を使用して、アプリでのエラーを検出できるようにします。

## <a name="creating-the-visual-studio-project"></a>Visual Studio プロジェクトの作成


ダウンロードしたサンプルを抽出して場合、 **MarbleMaze_VS2017.sln**フォルダーにファイル ( **C++** ) は、Visual Studio で開くことができ、コードがあります。

Marble Maze の Visual Studio プロジェクトを作ったときには、既にあるプロジェクトを利用しました。 しかし、DirectX UWP ゲームで必要となる基本的な機能を持つプロジェクトがまだない場合は、Visual Studio **DirectX 11 アプリ (ユニバーサル Windows)** テンプレートに基づくプロジェクトを作ることをお勧めします。このテンプレートには、基本的な機能を備えた 3D アプリケーションが用意されているためです。 これを行うには、次の手順に従います。

1. Visual Studio 2017 で選択**ファイル > 新規 > プロジェクト]**

2. **新しいプロジェクト**] ウィンドウの左側のサイドバーで選択**インストール済み > テンプレート > Visual C**します。

3. 中央のリストでは、 **DirectX 11 アプリ (ユニバーサル Windows)** を選択します。 必要なコンポーネントをインストールする必要がありますしない場合、このオプションが表示されない、&mdash;その他のコンポーネントをインストールする方法についての情報の[追加または削除のワークロードとコンポーネントの Visual Studio 2017 の変更](https://docs.microsoft.com/visualstudio/install/modify-visual-studio)を参照してください。

4. **名前**、格納するファイルの**場所**および**ソリューション名**では、プロジェクトを提供し、 **[ok]** をクリックします。

![新しいプロジェクト](images/marble-maze-sample-fundamentals-1.png)

**DirectX 11 アプリ (ユニバーサル Windows)** テンプレートで重要なプロジェクト設定の 1 つは、プログラムが Windows ランタイム言語拡張機能を使えるようにする **/ZW** オプションです。 Visual Studio テンプレートを使う場合、このオプションは既定で有効になっています。 Visual Studio でコンパイラ オプションを設定する方法について詳しくは、「[コンパイラ オプションの設定](https://docs.microsoft.com/cpp/build/reference/setting-compiler-options)」をご覧ください。

> **注意:**  **/ZW**オプションは **/clr**などのオプションと互換性がありません。 **/clr** の場合は、同じ Visual C++ プロジェクトで .NET Framework と Windows ランタイムの両方をターゲットにすることはできないことを意味します。

 

Microsoft Store から取得したすべての UWP アプリは、アプリ パッケージの形式で提供されます。 アプリ パッケージには、アプリについての情報が記載されたパッケージ マニフェストが含まれています。 たとえば、アプリの機能 (つまり、保護されたシステム リソースやユーザー データへの必要なアクセス) を指定できます。 アプリで特定の機能が必須であると決めた場合は、パッケージ マニフェストを使って、必要な機能を宣言します。 マニフェストでは、サポートされているデバイスの回転、タイル画像、スプラッシュ画面など、プロジェクト プロパティを指定することもできます。 プロジェクトで **Package.appxmanifest** を開いて、マニフェストを編集することができます。 アプリ パッケージについて詳しくは、「[アプリのパッケージ化](https://msdn.microsoft.com/library/windows/apps/mt270969)」をご覧ください。

##  <a name="building-deploying-and-running-the-game"></a>ゲームのビルド、展開、実行

Visual Studio の上部の、緑色の再生ボタンの左のドロップダウン リストで、展開構成を選択します。 デバイスのアーキテクチャ (32 ビットでは **x86**、64 ビットでは **x64**) による **ローカル コンピューター** をターゲットとする**デバッグ**として設定することをお勧めします。 **リモート コンピューター**でテストすることも、または USB で接続された**デバイス**を対象とすることも、可能です。 次に、緑色の再生ボタンをクリックして、デバイスへビルドと展開を行います。

![デバッグ、x64、ローカル コンピューター](images/marble-maze-sample-fundamentals-2.png)

###  <a name="controlling-the-game"></a>ゲームの制御

タッチ、加速度計、Xbox One コント ローラーで、またはマウスを Marble Maze の制御を使用することができます。

-   アクティブなメニュー項目を変更するには、コントローラーの方向パッドを使います。
-   タッチ、A またはスタート画面を使用して、コント ローラーまたはマウスをメニュー項目を選択する] ボタンをします。
-   迷路を傾けるには、タッチ、加速度計、左スティック、マウスを使います。
-   タッチ、A またはスタート画面を使用して、コント ローラーまたはマウスを高などのメニューを閉じるボタン スコア表。
-   一時停止または再開ゲーム コント ローラーまたはキーボードの P キーで、[スタート] ボタンを使用します。
-   ゲームを再開始するには、コントローラーの [戻る] ボタンやキーボードの Home キーを使います。
-   ハイ スコア表が表示されている場合は、すべてのスコアをクリアする、コント ローラーまたはキーボードの Home キーで、戻るボタンを使用します。

##  <a name="code-conventions"></a>コードの規則


Windows ランタイムは、特別なアプリケーション環境だけで実行される UWP アプリの作成に使うプログラミング インターフェイスです。 このようなアプリでは、認定された関数、データ型、およびデバイスを使用し、Microsoft Store から配布されます。 Windows ランタイムの最も基本となる部分を構成しているのは、アプリケーション バイナリ インターフェイス (ABI) です。 ABI は、JavaScript、.NET 言語、Visual C++ など、複数のプログラミング言語から Windows ランタイム API にアクセスできるようにするための基礎となるバイナリ コントラクトです。

Windows ランタイム API を JavaScript や .NET から呼び出すには、各言語環境に固有のプロジェクションが必要となります。 Windows ランタイム API を JavaScript または .NET から呼び出すとき、実際にはプロジェクションを呼び出し、そこからさらに、基になる ABI 関数を呼び出すことになります。 ABI 関数は C++ から直接呼び出すことができますが、Microsoft は、C++ 用のプロジェクションも併せて提供しています。そのようにすることで、Windows ランタイム API の扱いがシンプルになると共に、高いパフォーマンスを維持できるためです。 また、実際に Windows ランタイムのプロジェクションをサポートする、Visual C++ の言語拡張機能も Microsoft から提供されています。 こうした言語拡張機能の多くは、C++/CLI 言語の構文と似ています。 ただし、ネイティブ アプリはこの構文を使って、共通言語ランタイム (CLR) をターゲットにするのではなく、Windows ランタイムをターゲットにします。 オブジェクト参照、またはハット (^) 修飾子は、この新しい構文の重要な要素です。これによって、参照カウントに基づくランタイム オブジェクトの自動削除が可能になるためです。 Windows ランタイム オブジェクトの有効期間を管理するために [AddRef](https://msdn.microsoft.com/library/windows/desktop/ms691379) や [Release](https://msdn.microsoft.com/library/windows/desktop/ms682317) などのメソッドを呼び出さなくても、他のコンポーネントがオブジェクトを参照していないときに (たとえばオブジェクトのスコープが終わったり、すべての参照が **nullptr** に設定されたりしたときに)、ランタイムがオブジェクトを削除します。 Visual C++ を使った UWP アプリの作成に関して、もう 1 つの重要な要素は **ref new** キーワードです。 参照カウントで管理される Windows ランタイム オブジェクトを作成するには、**new** ではなく **ref new** を使います。 詳しくは、「[型システム (C++/CX)](https://msdn.microsoft.com/library/windows/apps/hh755822)」をご覧ください。

> [!IMPORTANT]
> **^** と **ref new** は、Windows ランタイム オブジェクトを作成するときと Windows ランタイム コンポーネントを作成するとき以外は使わないでください。 Windows ランタイムを使わないコア アプリケーション コードを作成する際は、標準の C++ 構文を使うことができます。

Marble Maze は、ヒープに割り当てられたオブジェクトを **^** と **Microsoft::WRL::ComPtr** を使って管理し、メモリ リークを最小限に抑えます。 使用することをお勧めします ^ 有効期間を管理、Windows ランタイム変数の**ComPtr** (など、使用する場合 DirectX)、COM 変数と**std::shared\_ptr**または他のすべての有効期間を管理する**std::unique\_ptr**の有効期間を管理するにはヒープ割り当て C++ オブジェクト。

 

C++ UWP アプリで使える言語拡張機能について詳しくは、「[Visual C++ 言語のリファレンス (C++/CX)](https://msdn.microsoft.com/library/windows/apps/hh699871)」をご覧ください。

###  <a name="error-handling"></a>エラー処理

Marble Maze では、予期しないエラーに対応する主な方法として例外処理を使います。 ゲーム コードでは従来、エラーを示すためにログやエラー コード (**HRESULT** 値など) を使ってきましたが、例外処理には 2 つの主な利点があります。 1 つ目は、コードが読みやすく、保守しやすいことです。 コードの観点からは、例外処理はエラー処理ルーティンに効率よくエラーを伝達することができます。 エラー コードを使った場合は通常、個々の関数で明示的にエラーを伝達する必要があります。 2 つ目の利点は、例外が発生したところで中断するように Visual Studio デバッガーを構成すれば、エラーが発生したときに、その位置やコンテキストですぐに止めることができることです。 例外処理は、Windows ランタイムでも広く使われています。 したがって、自分のコード内で例外処理を使うことにより、あらゆるエラー処理を 1 つのモデルに統合することができます。

エラー処理モデルでは、次の規則を使うことをお勧めします。

-   例外は、予期しないエラーを知らせるために使います。
-   コードのフローを制御するためには、例外を使わないでください。
-   キャッチする例外は安全に処理、回復できるものだけにしてください。 それ以外の例外はキャッチせず、アプリを強制終了させます。
-   **HRESULT** を返す DirectX ルーチンを呼び出す場合は、**DX::ThrowIfFailed** 関数を使います。 この関数は、 [DirectXHelper.h](https://github.com/Microsoft/Windows-appsample-marble-maze/blob/master/C%2B%2B/Shared/DirectXHelper.h)で定義されます。 **ThrowIfFailed**提供されている**HRESULT**エラー コードは、例外がスローされます。 たとえば、**E\_POINTER** では **ThrowIfFailed** が [Platform::NullReferenceException](https://msdn.microsoft.com/library/windows/apps/hh755823.aspx) をスローします。

    **ThrowIfFailed** を使うときは、次の例に示すように DirectX 呼び出しを別の行に記述して、コードが読みやすくなるようにします。

    ```cpp
    // Identify the physical adapter (GPU or card) this device is running on.
    ComPtr<IDXGIAdapter> dxgiAdapter;
    DX::ThrowIfFailed(
        dxgiDevice->GetAdapter(&dxgiAdapter)
        );
    ```

-   予期しないエラーの**HRESULT**の使用を避けることをお勧めしますが、コードのフローを制御する例外処理の使用を回避するためにさらに重要ながします。 そのため、コードのフローを制御するために必要な場合は、**HRESULT** 戻り値を使う方が適切です。

###  <a name="sal-annotations"></a>SAL 注釈

アプリのエラーの発見に役立てるために、コード分析ツールと共に SAL 注釈を使います。

Microsoft Source-code Annotation Language (SAL) を使うと、関数がパラメーターをどのように使うかを説明する注を付けることができます。 SAL 注釈は、戻り値についても説明します。 SAL 注釈を C/C++ コード分析ツールと共に使うと、C や C++ ソース コードの潜在的な不具合を検出できます。 ツールによって報告される一般的なコーディング エラーは、バッファー オーバーラン、初期化されていないメモリ、null ポインターの逆参照、メモリとリソースのリークなどです。

[BasicLoader.h](https://github.com/Microsoft/Windows-appsample-marble-maze/blob/e62d68a85499e208d591d2caefbd9df62af86809/C%2B%2B/Shared/BasicLoader.h)で宣言されている**basicloader::loadmesh**メソッドを検討してください。 このメソッドを使用して`_In_`*ファイル名*には、入力パラメーターを指定する (およびそのためからのみ読み取られます)、 `_Out_` *筆者*と*indexBuffer*は、出力パラメーターを指定する (とそのためのみに書き込まれます)`_Out_opt_` *vertexCount*と*indexCount*は省略可能なことを指定する出力パラメーター (とに書き込まれる可能性があります)。 *vertexCount* と *indexCount* は省略可能な出力パラメーターであるため、**nullptr** にすることができます。 C/C++ コード分析ツールは、このメソッドの呼び出しを調べて、渡されるパラメーターが条件を満たしていることを確認します。

```cpp
void LoadMesh(
    _In_ Platform::String^ filename,
    _Out_ ID3D11Buffer** vertexBuffer,
    _Out_ ID3D11Buffer** indexBuffer,
    _Out_opt_ uint32* vertexCount,
    _Out_opt_ uint32* indexCount
    );
```

メニュー バーで、アプリのコード分析を実行するには選択**ビルド > ソリューションでコード分析を実行**します。 コード分析について詳しくは、「[コード分析による C/C++ コード品質の分析](https://docs.microsoft.com/visualstudio/code-quality/analyzing-c-cpp-code-quality-by-using-code-analysis)」をご覧ください。

利用できる注釈の完全なリストは、sal.h で定義されています。 詳しくは、「[SAL 注釈](https://docs.microsoft.com/cpp/c-runtime-library/sal-annotations)」をご覧ください。

## <a name="next-steps"></a>次の手順


Marble Maze アプリケーション コードの構造と、DirectX UWP アプリの構造と従来のデスクトップ アプリケーションの構造の違いについての情報を、「[Marble Maze のアプリケーション構造](marble-maze-application-structure.md)」で読みます。

## <a name="related-topics"></a>関連トピック


* [Marble Maze のアプリケーション構造](marble-maze-application-structure.md)
* [Marble Maze、C++ と DirectX での UWP ゲームの開発](developing-marble-maze-a-windows-store-game-in-cpp-and-directx.md)

 

 




