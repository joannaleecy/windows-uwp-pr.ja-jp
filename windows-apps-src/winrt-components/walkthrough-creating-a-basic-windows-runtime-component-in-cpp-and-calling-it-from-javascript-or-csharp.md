---
title: C++ での基本的な Windows ランタイム コンポーネントの作成と JavaScript または C# からの呼び出し#
description: このチュートリアルでは、JavaScript、C#、または Visual Basic から呼び出すことができる基本的な Windows ランタイム コンポーネント DLL を作成する方法について説明します。
ms.assetid: 764CD9C6-3565-4DFF-88D7-D92185C7E452
---

# チュートリアル: C++ での基本的な Windows ランタイム コンポーネントの作成と JavaScript または C# からの呼び出し#


\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]


\[一部の情報はリリース前の製品に関することであり、正式版がリリースされるまでに大幅に変更される可能性があります。 ここに記載された情報について、Microsoft は明示または黙示を問わずいかなる保証をするものでもありません。\]

このチュートリアルでは、JavaScript、C#、または Visual Basic から呼び出すことができる基本的な Windows ランタイム コンポーネント DLL を作成する方法について説明します。 このチュートリアルを開始する前に、抽象バイナリ インターフェイス (ABI)、ref クラス、Visual C++ コンポーネント拡張などの概念を必ず理解しておいてください。ref クラスの操作が容易になります。 詳しくは、「[C++ での Windows ランタイム コンポーネントの作成](creating-windows-runtime-components-in-cpp.md)」および「[Visual C++ の言語リファレンス (C++/CX)](https://msdn.microsoft.com/library/windows/apps/xaml/hh699871.aspx)」をご覧ください。

## C++ コンポーネント DLL の作成


この例では、最初にコンポーネント プロジェクトを作成しますが、JavaScript プロジェクトを最初に作成しても構いません。 順序は重要ではありません。

コンポーネントのメイン クラスには、プロパティとメソッドの定義およびイベント宣言の例が含まれています。 これらは方法を示すことだけを目的に用意されており、 必須ではありません。この例では、生成されたコードはすべて独自のコードに置き換えます。

## **C++ コンポーネント プロジェクトを作成するには**

1.  Visual Studio のメニュー バーで、**[ファイル]、[新規作成]、[プロジェクト]** の順にクリックします。
2.  **[新しいプロジェクト]** ダイアログ ボックスの左ペインで、**[Visual C++]** を展開し、ユニバーサル Windows アプリのノードを選択します。
3.  中央ペインで **[Windows ランタイム コンポーネント]** を選び、プロジェクトに WinRT\_CPP という名前を付けます。
4.  **[OK]** をクリックします。

## **コンポーネントにアクティブ化可能なクラスを追加するには**

1.  アクティブ化可能なクラスとは、クライアント コードで **new** 式 (Visual Basic では **New**、C++ では **ref new**) を使って作成できるクラスのことです。 コンポーネントでは、**public ref class sealed** として宣言します。 実際には、Class1.h ファイルと .cpp ファイルに ref クラスが既に含まれています。 名前を変更することはできますが、この例では既定の名前 (Class1) を使います。 必要に応じて、コンポーネント内で追加の ref クラスまたは regular クラスを定義できます。 ref クラスについて詳しくは、「[型システム (C++/CX)](https://msdn.microsoft.com/library/windows/apps/hh755822.aspx)」をご覧ください。

2.  次の \#include ディレクティブを Class1.h に追加します。

    ```cpp
             private void PrimesUnOrderedButton_Click_1(object sender, RoutedEventArgs e)
            {
                var nativeObject = new WinRT_CPP.Class1();

                StringBuilder sb = new StringBuilder();
                sb.Append("Primes found (unordered): ");
                PrimesUnOrderedResult.Text = sb.ToString();

                // primeFoundEvent is a user-defined event in nativeObject
                // It passes the results back to this thread as they are produced
                // and the event handler that we define here immediately displays them.
                nativeObject.primeFoundEvent += (n) =>
                {
                    sb.Append(n.ToString()).Append(" ");
                    PrimesUnOrderedResult.Text = sb.ToString();
                };

                // Call the async method.
                var asyncResult = nativeObject.GetPrimesUnordered(2, 100000);

                // Provide a handler for the Progress event that the asyncResult
                // object fires at regular intervals. This handler updates the progress bar.
                asyncResult.Progress += (asyncInfo, progress) =>
                    {
                        PrimesUnOrderedProgress.Value = progress;
                    };
            }

            private void Clear_Button_Click(object sender, RoutedEventArgs e)
            {
                PrimesOrderedProgress.Value = 0;
                PrimesUnOrderedProgress.Value = 0;
                PrimesUnOrderedResult.Text = "";
                PrimesOrderedResult.Text = "";
                Result1.Text = "";
            }
    ```

## アプリの実行


ソリューション エクスプローラーでプロジェクト ノードのショートカット メニューを開き、**[スタートアップ プロジェクトに設定]** を選んで、C# プロジェクトまたは JavaScript プロジェクトをスタートアップ プロジェクトとして選びます。 デバッグして実行する場合は、F5 キーを押します。デバッグせずに実行する場合は、Ctrl キーを押しながら F5 キーを押します。

## オブジェクト ブラウザーでのコンポーネントの検査 (省略可能)


オブジェクト ブラウザーで、.winmd ファイルで定義されているすべての Windows ランタイム型を検査できます。 これには、Platform 名前空間と既定の名前空間の型が含まれます。 ただし、Platform::Collections 名前空間の型は、winmd ファイルではなく、collections.h ヘッダー ファイルで定義されているため、オブジェクト ブラウザーでは表示されません。

## **コンポーネントを検査するには**

1.  メニュー バーで、**[表示]、[オブジェクト ブラウザー]** の順にクリックします (または、Ctrl + Alt + J キーを押します)。
2.  オブジェクト ブラウザーの左ペインで、[WinRT\_CPP] ノードを展開して、コンポーネントで定義されている型とメソッドを表示します。

## デバッグのヒント


デバッグ操作を向上させるには、パブリックな Microsoft シンボル サーバーからデバッグ シンボルをダウンロードします。

## **デバッグ シンボルをダウンロードするには**

1.  メニュー バーで、**[ツール]、[オプション]** の順にクリックします。
2.  **[オプション]** ダイアログ ボックスで、**[デバッグ]** を展開し、**[シンボル]** をクリックします。
3.  **[Microsoft シンボル サーバー]** を選択し、**[OK]** をクリックします。

シンボルを初めてダウンロードするときは時間がかかる場合があります。 次回 F5 キーを押したときのパフォーマンスを向上させるには、シンボルをキャッシュするローカル ディレクトリを指定します。

コンポーネント DLL を含む JavaScript ソリューションをデバッグするときは、コンポーネントでスクリプトのステップ実行またはネイティブ コードのステップ実行を有効にするようにデバッガーを設定できますが、この両方を同時に有効にすることはできません。 設定を変更するには、ソリューション エクスプローラーで JavaScript プロジェクト ノードのショートカット メニューを開き、**[プロパティ]、[デバッグ]、[デバッガーの種類]** の順にクリックします。

パッケージ デザイナーで必ず適切な機能を選択してください。 パッケージ デザイナーを開くには、Package.appxmanifest ファイルを開きます。 たとえば、プログラムを使ってピクチャ フォルダーのファイルにアクセスする場合は、パッケージ デザイナーの **[機能]** ペインで **[画像ライブラリ]** チェック ボックスをオンにしてください。

JavaScript コードがコンポーネントのパブリック プロパティまたはパブリック メソッドを認識しない場合は、JavaScript で camel 規約を使っていることを確認します。 たとえば、`ComputeResult` C++ メソッドは、JavaScript で `computeResult` として参照する必要があります。

C++ Windows ランタイム コンポーネント プロジェクトをソリューションから削除する場合、JavaScript プロジェクトからプロジェクト参照も手動で削除する必要があります。 これを行わないと、後続のデバッグまたはビルド操作が妨げられます。 その後、必要に応じてアセンブリ参照を DLL に追加できます。

## 関連トピック

* [C++ での Windows ランタイム コンポーネントの作成](creating-windows-runtime-components-in-cpp.md)



<!--HONumber=Mar16_HO1-->


