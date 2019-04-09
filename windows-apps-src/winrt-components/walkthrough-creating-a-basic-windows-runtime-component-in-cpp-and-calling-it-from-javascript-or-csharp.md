---
title: C++/CX での Windows ランタイム コンポーネントの作成と JavaScript または C# からの呼び出し
description: このチュートリアルでは、JavaScript、C#、または Visual Basic から呼び出すことができる基本的な Windows ランタイム コンポーネント DLL を作成する方法について説明します。
ms.assetid: 764CD9C6-3565-4DFF-88D7-D92185C7E452
ms.date: 05/14/2018
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: f1f147d98b8d88e912cc9fec40d5e29c34748167
ms.sourcegitcommit: 82edc63a5b3623abce1d5e70d8e200a58dec673c
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/20/2019
ms.locfileid: "58291900"
---
# <a name="walkthrough-creating-a-windows-runtime-component-in-ccx-and-calling-it-from-javascript-or-c"></a>チュートリアル: C++/CX での Windows ランタイム コンポーネントの作成と JavaScript または C# からの呼び出し
> [!NOTE]
> このトピックは、C++/CX アプリケーションの管理ができるようにすることを目的としています。 ただし、新しいアプリケーションには [C++/WinRT](../cpp-and-winrt-apis/intro-to-using-cpp-with-winrt.md) を使用することをお勧めします。 C++/WinRT は Windows ランタイム (WinRT) API の標準的な最新の C++17 言語プロジェクションで、ヘッダー ファイル ベースのライブラリとして実装され、最新の Windows API への最上位アクセス権を提供するように設計されています。 C + を使用して、Windows ランタイム コンポーネントを作成する方法について/cli WinRT を参照してください[C + でのイベントを作成/cli WinRT](../cpp-and-winrt-apis/author-events.md)します。

このチュートリアルでは、JavaScript、C#、または Visual Basic から呼び出すことができる基本的な Windows ランタイム コンポーネント DLL を作成する方法について説明します。 このチュートリアルを開始する前に、抽象バイナリ インターフェイス (ABI)、ref クラス、Visual C++ コンポーネント拡張などの概念を必ず理解しておいてください。ref クラスの操作が容易になります。 詳しくは、「[C++ での Windows ランタイム コンポーネントの作成](creating-windows-runtime-components-in-cpp.md)」および「[Visual C++ の言語リファレンス (C++/CX)](https://msdn.microsoft.com/library/windows/apps/xaml/hh699871.aspx)」をご覧ください。

## <a name="creating-the-c-component-dll"></a>C++ コンポーネント DLL の作成
この例では、最初にコンポーネント プロジェクトを作成しますが、JavaScript プロジェクトを最初に作成しても構いません。 順序は重要ではありません。

コンポーネントのメイン クラスには、プロパティとメソッドの定義およびイベント宣言の例が含まれています。 これらは方法を示すことだけを目的に用意されており、 必須ではありません。この例では、生成されたコードはすべて独自のコードに置き換えます。

### <a name="to-create-the-c-component-project"></a>**C++ コンポーネント プロジェクトを作成するには**
1. Visual Studio のメニュー バーで、**[ファイル]、[新規作成]、[プロジェクト]** の順にクリックします。

2. **[新しいプロジェクト]** ダイアログ ボックスの左ペインで、**[Visual C++]** を展開し、ユニバーサル Windows アプリのノードを選択します。

3. 中央のウィンドウで次のように選択します。 **Windows ランタイム コンポーネント**し名前をプロジェクト WinRT\_CPP します。

4. **[OK]** ボタンをクリックします。

## <a name="to-add-an-activatable-class-to-the-component"></a>**コンポーネントに、アクティブ化可能なクラスを追加するには**
アクティブ化可能なクラスとは、クライアント コードで **new** 式 (Visual Basic では **New**、C++ では **ref new**) を使って作成できるクラスのことです。 コンポーネントでは、**public ref class sealed** として宣言します。 実際には、Class1.h ファイルと .cpp ファイルに ref クラスが既に含まれています。 名前を変更することはできますが、この例では既定の名前 (Class1) を使います。 必要に応じて、コンポーネント内で追加の ref クラスまたは regular クラスを定義できます。 ref クラスについて詳しくは、「[型システム (C++/CX)](https://msdn.microsoft.com/library/windows/apps/hh755822.aspx)」をご覧ください。

次の追加\#ディレクティブを Class1.h に。

```cpp
#include <collection.h>
#include <ppl.h>
#include <amp.h>
#include <amp_math.h>
```

collection.h は、Windows ランタイムによって定義されている言語に依存しないインターフェイスを実装する C++ の具象クラス (Platform::Collections::Vector クラスや Platform::Collections::Map クラスなど) のヘッダー ファイルです。 amp ヘッダーは、GPU で計算を実行する際に使用されます。 Windows ランタイムには amp ヘッダーに相当するものはありませんが、これらはプライベートであるため、問題はありません。 一般に、パフォーマンス上の理由から、コンポーネント内部では ISO C++ コードと標準ライブラリを使います。Windows ランタイム型で表現する必要があるのは、Windows ランタイム インターフェイスだけです。

## <a name="to-add-a-delegate-at-namespace-scope"></a>名前空間スコープでデリゲートを追加するには
デリゲートとは、メソッドのパラメーターと戻り値の型を定義するコンストラクトです。 イベントは特定のデリゲート型のインスタンスであり、イベントにサブスクライブするイベント ハンドラー メソッドには、デリゲートで指定されているシグネチャが必要です。 次のコードでは、int を受け取り、void を返すデリゲート型を定義します。 次に、このコードでこの型のパブリック イベントを宣言します。これにより、クライアント コードはイベントが発生したときに呼び出されるメソッドを提供できるようになります。

Class1.h で、Class1 宣言の直前に名前空間スコープで次のデリゲート宣言を追加します。

```cpp
public delegate void PrimeFoundHandler(int result);
```

Visual Studio に貼り付けたときにコードが整列されていない場合は、Ctrl + K + D キーを押すと、ファイル全体のインデントが修正されます。

## <a name="to-add-the-public-members"></a>パブリック メンバーを追加するには
クラスで 3 つのパブリック メソッドと 1 つのパブリック イベントを公開します。 最初のメソッドは常に高速で実行されるので、同期メソッドです。 他の 2 つのメソッドは時間がかかる場合があるので、UI スレッドをブロックしないように非同期にします。 これらのメソッドは、IAsyncOperationWithProgress と IAsyncActionWithProgress を返します。 前者は結果を返す非同期メソッドを定義し、後者は void を返す非同期メソッドを定義します。 また、これらのインターフェイスにより、クライアント コードは操作の進行状況の更新を受け取ることができます。

```cpp
public:

        // Synchronous method.
        Windows::Foundation::Collections::IVector<double>^  ComputeResult(double input);

        // Asynchronous methods
        Windows::Foundation::IAsyncOperationWithProgress<Windows::Foundation::Collections::IVector<int>^, double>^
            GetPrimesOrdered(int first, int last);
        Windows::Foundation::IAsyncActionWithProgress<double>^ GetPrimesUnordered(int first, int last);

        // Event whose type is a delegate "class"
        event PrimeFoundHandler^ primeFoundEvent;

```
## <a name="to-add-the-private-members"></a>プライベート メンバーを追加するには
クラスには 3 つのプライベート メンバーが含まれています。数値計算用の 2 つのヘルパー メソッドと、ワーカー スレッドから UI スレッドにイベント呼び出しをマーシャリングするために使われる CoreDispatcher オブジェクトです。

```cpp
private:
        bool is_prime(int n);
        Windows::UI::Core::CoreDispatcher^ m_dispatcher;
```

### <a name="to-add-the-header-and-namespace-directives"></a>ヘッダーと名前空間のディレクティブを追加するには
1. Class1.cpp で、次の #include ディレクティブを追加します。

```cpp
#include <ppltasks.h>
#include <concurrent_vector.h>
```

2. 次の using ステートメントを追加して必要な名前空間を追加します。

```cpp
using namespace concurrency;
using namespace Platform::Collections;
using namespace Windows::Foundation::Collections;
using namespace Windows::Foundation;
using namespace Windows::UI::Core;
```

## <a name="to-add-the-implementation-for-computeresult"></a>ComputeResult の実装を追加するには
Class1.cpp で、次のメソッド実装を追加します。 このメソッドは呼び出しスレッドで同期的に実行されますが、C++ AMP を使って GPU での計算を並列化するため、非常に高速です。 詳しくは、「C++ AMP の概要」をご覧ください。 結果は Platform::Collections::Vector<T> 具象型に追加されます。この型は、返されるときに Windows::Foundation::Collections::IVector<T> に暗黙的に変換されます。

```cpp
//Public API
IVector<double>^ Class1::ComputeResult(double input)
{
    // Implement your function in ISO C++ or
    // call into your C++ lib or DLL here. This example uses AMP.
    float numbers[] = { 1.0, 10.0, 60.0, 100.0, 600.0, 10000.0 };
    array_view<float, 1> logs(6, numbers);

    // See http://msdn.microsoft.com/en-us/library/hh305254.aspx
    parallel_for_each(
        logs.extent,
        [=] (index<1> idx) restrict(amp)
    {
        logs[idx] = concurrency::fast_math::log10(logs[idx]);
    }
    );

    // Return a Windows Runtime-compatible type across the ABI
    auto res = ref new Vector<double>();
    int len = safe_cast<int>(logs.extent.size());
    for(int i = 0; i < len; i++)
    {      
        res->Append(logs[i]);
    }

    // res is implicitly cast to IVector<double>
    return res;
}
```
## <a name="to-add-the-implementation-for-getprimesordered-and-its-helper-method"></a>GetPrimesOrdered とそのヘルパー メソッドの実装を追加するには
Class1.cpp で、GetPrimesOrdered と is_prime ヘルパー メソッドの実装を追加します。 GetPrimesOrdered は、concurrent_vector クラスと parallel_for 関数ループを使って作業を分割し、プログラムが実行されているコンピューターのリソースを最大限に使って結果を生成します。 結果の計算、保存、並べ替えが終わると、結果は Platform::Collections::Vector<T> に追加され、Windows::Foundation::Collections::IVector<T> としてクライアント コードに返されます。

進行状況レポーターのコードに注意してください。このコードにより、クライアントは操作の予想される所要時間をユーザーに示す進行状況バーまたは他の UI をフックできます。 進行状況レポートにはコストがかかります。 イベントはコンポーネント側で発生させ、UI スレッドで処理する必要があります。また、イテレーションごとに進行状況値を保存する必要があります。 コストを最小限に抑える 1 つの方法として、進行状況イベントの発生頻度を制限します。 それでもコストがかかりすぎる場合や、操作の所要時間を推定できない場合は、完了までの残り時間は示さず、操作が進行中であることだけを示すプログレス リングを使うことを検討してください。

```cpp
// Determines whether the input value is prime.
bool Class1::is_prime(int n)
{
    if (n < 2)
        return false;
    for (int i = 2; i < n; ++i)
    {
        if ((n % i) == 0)
            return false;
    }
    return true;
}

// This method computes all primes, orders them, then returns the ordered results.
IAsyncOperationWithProgress<IVector<int>^, double>^ Class1::GetPrimesOrdered(int first, int last)
{
    return create_async([this, first, last]
    (progress_reporter<double> reporter) -> IVector<int>^ {
        // Ensure that the input values are in range.
        if (first < 0 || last < 0) {
            throw ref new InvalidArgumentException();
        }
        // Perform the computation in parallel.
        concurrent_vector<int> primes;
        long operation = 0;
        long range = last - first + 1;
        double lastPercent = 0.0;

        parallel_for(first, last + 1, [this, &primes, &operation,
            range, &lastPercent, reporter](int n) {

                // Increment and store the number of times the parallel
                // loop has been called on all threads combined. There
                // is a performance cost to maintaining a count, and
                // passing the delegate back to the UI thread, but it's
                // necessary if we want to display a determinate progress
                // bar that goes from 0 to 100%. We can avoid the cost by
                // setting the ProgressBar IsDeterminate property to false
                // or by using a ProgressRing.
                if(InterlockedIncrement(&operation) % 100 == 0)
                {
                    reporter.report(100.0 * operation / range);
                }

                // If the value is prime, add it to the local vector.
                if (is_prime(n)) {
                    primes.push_back(n);
                }
        });

        // Sort the results.
        std::sort(begin(primes), end(primes), std::less<int>());        
        reporter.report(100.0);

        // Copy the results to a Vector object, which is
        // implicitly converted to the IVector return type. IVector
        // makes collections of data available to other
        // Windows Runtime components.
        return ref new Vector<int>(primes.begin(), primes.end());
    });
}
```

## <a name="to-add-the-implementation-for-getprimesunordered"></a>GetPrimesUnordered の実装を追加するには
C++ コンポーネントを作成する最後の手順として、Class1.cpp で GetPrimesUnordered の実装を追加します。 このメソッドは、すべての結果が見つかるまで待たずに、結果が見つかるたびに各結果を返します。 各結果はイベント ハンドラー内で返され、UI にリアルタイムで表示されます。 ここでも進行状況レポーターが使われていることに注意してください。 このメソッドも、is_prime ヘルパー メソッドを使います。

```cpp
// This method returns no value. Instead, it fires an event each time a
// prime is found, and passes the prime through the event.
// It also passes progress info.
IAsyncActionWithProgress<double>^ Class1::GetPrimesUnordered(int first, int last)
{

    auto window = Windows::UI::Core::CoreWindow::GetForCurrentThread();
    m_dispatcher = window->Dispatcher;


    return create_async([this, first, last](progress_reporter<double> reporter) {

        // Ensure that the input values are in range.
        if (first < 0 || last < 0) {
            throw ref new InvalidArgumentException();
        }

        // In this particular example, we don't actually use this to store
        // results since we pass results one at a time directly back to
        // UI as they are found. However, we have to provide this variable
        // as a parameter to parallel_for.
        concurrent_vector<int> primes;
        long operation = 0;
        long range = last - first + 1;
        double lastPercent = 0.0;

        // Perform the computation in parallel.
        parallel_for(first, last + 1,
            [this, &primes, &operation, range, &lastPercent, reporter](int n)
        {
            // Store the number of times the parallel loop has been called  
            // on all threads combined. See comment in previous method.
            if(InterlockedIncrement(&operation) % 100 == 0)
            {
                reporter.report(100.0 * operation / range);
            }

            // If the value is prime, pass it immediately to the UI thread.
            if (is_prime(n))
            {                
                // Since this code is probably running on a worker
                // thread, and we are passing the data back to the
                // UI thread, we have to use a CoreDispatcher object.
                m_dispatcher->RunAsync( CoreDispatcherPriority::Normal,
                    ref new DispatchedHandler([this, n, operation, range]()
                {
                    this->primeFoundEvent(n);

                }, Platform::CallbackContext::Any));

            }
        });
        reporter.report(100.0);
    });
}
```

## <a name="creating-a-javascript-client-app"></a>JavaScript クライアント アプリケーションの作成
C# クライアントだけを作成する場合は、このセクションをスキップして構いません。

### <a name="to-create-a-javascript-project"></a>JavaScript プロジェクトを作成するには
1. ソリューション エクスプローラーで、[ソリューション] ノードのショートカット メニューを開き、**[追加]、[新しいプロジェクト]** の順にクリックします。

2. [JavaScript] (**[他の言語]** の下に入れ子になっていることがあります) を展開し、**[空白のアプリ (ユニバーサル Windows)]** を選択します。

3. **[OK]** をクリックして、既定の名前 (App1) を受け入れます。

4. App1 プロジェクト ノードのショートカット メニューを開き、**[スタートアップ プロジェクトに設定]** をクリックします。

5. WinRT_CPP へのプロジェクト参照を追加します。

6. [参照] ノードのショートカット メニューを開き、**[参照の追加]** をクリックします。

7. [参照マネージャー] ダイアログ ボックスの左ペインで、**[プロジェクト]** をクリックし、**[ソリューション]** をクリックします。

8. 中央ペインで [WinRT_CPP] を選択し、**[OK]** をクリックします。

## <a name="to-add-the-html-that-invokes-the-javascript-event-handlers"></a>JavaScript イベント ハンドラーを呼び出す HTML を追加するには
default.html ページの <body> ノードに、次の HTML を貼り付けます。

```HTML
<div id="LogButtonDiv">
     <button id="logButton">Logarithms using AMP</button>
 </div>
 <div id="LogResultDiv">
     <p id="logResult"></p>
 </div>
 <div id="OrderedPrimeButtonDiv">
     <button id="orderedPrimeButton">Primes using parallel_for with sort</button>
 </div>
 <div id="OrderedPrimeProgress">
     <progress id="OrderedPrimesProgressBar" value="0" max="100"></progress>
 </div>
 <div id="OrderedPrimeResultDiv">
     <p id="orderedPrimes">
         Primes found (ordered):
     </p>
 </div>
 <div id="UnorderedPrimeButtonDiv">
     <button id="ButtonUnordered">Primes returned as they are produced.</button>
 </div>
 <div id="UnorderedPrimeDiv">
     <progress id="UnorderedPrimesProgressBar" value="0" max="100"></progress>
 </div>
 <div id="UnorderedPrime">
     <p id="unorderedPrimes">
         Primes found (unordered):
     </p>
 </div>
 <div id="ClearDiv">
     <button id="Button_Clear">Clear</button>
 </div>
```

## <a name="to-add-styles"></a>スタイルを追加するには
default.css で body スタイルを削除し、次のスタイルを追加します。

```css
#LogButtonDiv {
border: orange solid 1px;
-ms-grid-row: 1; /* default is 1 */
-ms-grid-column: 1; /* default is 1 */
}
#LogResultDiv {
background: black;
border: red solid 1px;
-ms-grid-row: 1;
-ms-grid-column: 2;
}
#UnorderedPrimeButtonDiv, #OrderedPrimeButtonDiv {
border: orange solid 1px;
-ms-grid-row: 2;   
-ms-grid-column:1;
}
#UnorderedPrimeProgress, #OrderedPrimeProgress {
border: red solid 1px;
-ms-grid-column-span: 2;
height: 40px;
}
#UnorderedPrimeResult, #OrderedPrimeResult {
border: red solid 1px;
font-size:smaller;
-ms-grid-row: 2;
-ms-grid-column: 3;
-ms-overflow-style:scrollbar;
}
```

## <a name="to-add-the-javascript-event-handlers-that-call-into-the-component-dll"></a>コンポーネント DLL を呼び出す JavaScript イベント ハンドラーを追加するには
default.js ファイルの末尾に次の関数を追加します。 これらの関数は、メイン ページのボタンが選択されたときに呼び出されます。 JavaScript が C++ クラスをアクティブにして、そのメソッドを呼び出し、戻り値を使って HTML ラベルを設定する手順に注目してください。

```JavaScript
var nativeObject = new WinRT_CPP.Class1();

function LogButton_Click() {

    var val = nativeObject.computeResult(0);
    var result = "";

    for (i = 0; i < val.length; i++) {
        result += val[i] + "<br/>";
    }

    document.getElementById('logResult').innerHTML = result;
}

function ButtonOrdered_Click() {
    document.getElementById('orderedPrimes').innerHTML = "Primes found (ordered): ";

    nativeObject.getPrimesOrdered(2, 10000).then(
        function (v) {
            for (var i = 0; i < v.length; i++)
                document.getElementById('orderedPrimes').innerHTML += v[i] + " ";
        },
        function (error) {
            document.getElementById('orderedPrimes').innerHTML += " " + error.description;
        },
        function (p) {
            var progressBar = document.getElementById("OrderedPrimesProgressBar");
            progressBar.value = p;
        });
}

function ButtonUnordered_Click() {
    document.getElementById('unorderedPrimes').innerHTML = "Primes found (unordered): ";
    nativeObject.onprimefoundevent = handler_unordered;

    nativeObject.getPrimesUnordered(2, 10000).then(
        function () { },
        function (error) {
            document.getElementById("unorderedPrimes").innerHTML += " " + error.description;
        },
        function (p) {
            var progressBar = document.getElementById("UnorderedPrimesProgressBar");
            progressBar.value = p;
        });
}

var handler_unordered = function (n) {
    document.getElementById('unorderedPrimes').innerHTML += n.target.toString() + " ";
};

function ButtonClear_Click() {

    document.getElementById('logResult').innerHTML = "";
    document.getElementById("unorderedPrimes").innerHTML = "";
    document.getElementById('orderedPrimes').innerHTML = "";
    document.getElementById("UnorderedPrimesProgressBar").value = 0;
    document.getElementById("OrderedPrimesProgressBar").value = 0;
}
```

default.js 内の app.onactivated での WinJS.UI.processAll の既存の呼び出しを、then ブロックでイベント登録を実装する次のコードに置き換えて、イベント リスナーを追加するコードを追加します。 これの詳細については、次を参照してください。 ["Hello, World"アプリ (JS) 作成](/windows/uwp/get-started/create-a-hello-world-app-js-uwp)です。

```JavaScript
args.setPromise(WinJS.UI.processAll().then( function completed() {
    var logButton = document.getElementById("logButton");
    logButton.addEventListener("click", LogButton_Click, false);
    var orderedPrimeButton = document.getElementById("orderedPrimeButton");
    orderedPrimeButton.addEventListener("click", ButtonOrdered_Click, false);
    var buttonUnordered = document.getElementById("ButtonUnordered");
    buttonUnordered.addEventListener("click", ButtonUnordered_Click, false);
    var buttonClear = document.getElementById("Button_Clear");
    buttonClear.addEventListener("click", ButtonClear_Click, false);
}));
```

F5 キーを押してアプリを実行します。

## <a name="creating-a-c-client-app"></a>C# クライアント アプリケーションの作成

### <a name="to-create-a-c-project"></a>C# プロジェクトを作成するには
1. ソリューション エクスプローラーで、[ソリューション] ノードのショートカット メニューを開き、**[追加]、[新しいプロジェクト]** の順にクリックします。

2. [Visual C#] (**[他の言語]** の下に入れ子になっていることがあります) を展開し、**[Windows]** をクリックします。左ペインで **[ユニバーサル]** をクリックし、中央ペインで **[空のアプリケーション]** を選択します。

3. このアプリケーションに CS_Client という名前を付け、**[OK]** をクリックします。

4. CS_Client プロジェクト ノードのショートカット メニューを開き、**[スタートアップ プロジェクトに設定]** をクリックします。

5. WinRT_CPP へのプロジェクト参照を追加します。

   - **[参照]** ノードのショートカット メニューを開き、**[参照の追加]** をクリックします。

   - **[参照マネージャー]** ダイアログ ボックスの左ペインで、**[プロジェクト]** をクリックし、**[ソリューション]** をクリックします。

   - 中央ペインで [WinRT_CPP] を選択し、**[OK]** をクリックします。

## <a name="to-add-the-xaml-that-defines-the-user-interface"></a>ユーザー インターフェイスを定義する XAML を追加するには
MainPage.xaml 内の Grid 要素に次のコードをコピーします。

```xaml
<ScrollViewer>
            <StackPanel Width="1400">

                <Button x:Name="Button1" Width="340" Height="50"  Margin="0,20,20,20" Content="Synchronous Logarithm Calculation" FontSize="16" Click="Button1_Click_1"/>
                <TextBlock x:Name="Result1" Height="100" FontSize="14"></TextBlock>
            <Button x:Name="PrimesOrderedButton" Content="Prime Numbers Ordered" FontSize="16" Width="340" Height="50" Margin="0,20,20,20" Click="PrimesOrderedButton_Click_1"></Button>
            <ProgressBar x:Name="PrimesOrderedProgress" IsIndeterminate="false" Height="40"></ProgressBar>
                <TextBlock x:Name="PrimesOrderedResult" MinHeight="100" FontSize="10" TextWrapping="Wrap"></TextBlock>
            <Button x:Name="PrimesUnOrderedButton" Width="340" Height="50" Margin="0,20,20,20" Click="PrimesUnOrderedButton_Click_1" Content="Prime Numbers Unordered" FontSize="16"></Button>
            <ProgressBar x:Name="PrimesUnOrderedProgress" IsIndeterminate="false" Height="40" ></ProgressBar>
            <TextBlock x:Name="PrimesUnOrderedResult" MinHeight="100" FontSize="10" TextWrapping="Wrap"></TextBlock>

            <Button x:Name="Clear_Button" Content="Clear" HorizontalAlignment="Left" Margin="0,20,20,20" VerticalAlignment="Top" Width="341" Click="Clear_Button_Click" FontSize="16"/>
        </StackPanel>
</ScrollViewer>
```

## <a name="to-add-the-event-handlers-for-the-buttons"></a>ボタンのイベント ハンドラーを追加するには
ソリューション エクスプローラーで、MainPage.xaml.cs を開きます  (ファイルは MainPage.xaml の下で入れ子に可能性があります)。使用して、追加、System.Text のディレクティブを MainPage クラスで、対数の計算のイベント ハンドラーを追加します。

```csharp
private void Button1_Click_1(object sender, RoutedEventArgs e)
{
    // Create the object
    var nativeObject = new WinRT_CPP.Class1();

    // Call the synchronous method. val is an IList that
    // contains the results.
    var val = nativeObject.ComputeResult(0);
    StringBuilder result = new StringBuilder();
    foreach (var v in val)
    {
        result.Append(v).Append(System.Environment.NewLine);
    }
    this.Result1.Text = result.ToString();
}
```

順序付けされた結果のイベント ハンドラーを追加します。

```csharp
async private void PrimesOrderedButton_Click_1(object sender, RoutedEventArgs e)
{
    var nativeObject = new WinRT_CPP.Class1();

    StringBuilder sb = new StringBuilder();
    sb.Append("Primes found (ordered): ");

    PrimesOrderedResult.Text = sb.ToString();

    // Call the asynchronous method
    var asyncOp = nativeObject.GetPrimesOrdered(2, 100000);

    // Before awaiting, provide a lambda or named method
    // to handle the Progress event that is fired at regular
    // intervals by the asyncOp object. This handler updates
    // the progress bar in the UI.
    asyncOp.Progress = (asyncInfo, progress) =>
        {
            PrimesOrderedProgress.Value = progress;
        };

    // Wait for the operation to complete
    var asyncResult = await asyncOp;

    // Convert the results to strings
    foreach (var result in asyncResult)
    {
        sb.Append(result).Append(" ");
    }

    // Display the results
    PrimesOrderedResult.Text = sb.ToString();
}
```

順序付けされていない結果のイベント ハンドラーと、コードを再度実行できるように結果をクリアするボタンのイベント ハンドラーを追加します。

```csharp
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

## <a name="running-the-app"></a>アプリの実行
ソリューション エクスプローラーでプロジェクト ノードのショートカット メニューを開き、**[スタートアップ プロジェクトに設定]** を選んで、C# プロジェクトまたは JavaScript プロジェクトをスタートアップ プロジェクトとして選びます。 デバッグして実行する場合は、F5 キーを押します。デバッグせずに実行する場合は、Ctrl キーを押しながら F5 キーを押します。

## <a name="inspecting-your-component-in-object-browser-optional"></a>オブジェクト ブラウザーでのコンポーネントの検査 (省略可能)
オブジェクト ブラウザーで、.winmd ファイルで定義されているすべての Windows ランタイム型を検査できます。 これには、Platform 名前空間と既定の名前空間の型が含まれます。 ただし、Platform::Collections 名前空間の型は、winmd ファイルではなく、collections.h ヘッダー ファイルで定義されているため、オブジェクト ブラウザーでは表示されません。

### <a name="to-inspect-a-component"></a>**コンポーネントを検査するには**
1. メニュー バーで、**[表示]、[オブジェクト ブラウザー]** の順にクリックします (または、Ctrl + Alt + J キーを押します)。

2. オブジェクト ブラウザーの左側のウィンドウで、展開、WinRT\_CPP ノード、コンポーネントで定義されているメソッドや型を表示します。

## <a name="debugging-tips"></a>デバッグのヒント
デバッグ操作を向上させるには、パブリックな Microsoft シンボル サーバーからデバッグ シンボルをダウンロードします。

### <a name="to-download-debugging-symbols"></a>**デバッグ シンボルをダウンロードするには**
1. メニュー バーで、**[ツール]、[オプション]** の順にクリックします。

2. **[オプション]** ダイアログ ボックスで、**[デバッグ]** を展開し、**[シンボル]** をクリックします。

3. **[Microsoft シンボル サーバー]** を選択し、**[OK]** をクリックします。

シンボルを初めてダウンロードするときは時間がかかる場合があります。 次回 F5 キーを押したときのパフォーマンスを向上させるには、シンボルをキャッシュするローカル ディレクトリを指定します。

コンポーネント DLL を含む JavaScript ソリューションをデバッグするときは、コンポーネントでスクリプトのステップ実行またはネイティブ コードのステップ実行を有効にするようにデバッガーを設定できますが、この両方を同時に有効にすることはできません。 設定を変更するには、ソリューション エクスプローラーで JavaScript プロジェクト ノードのショートカット メニューを開き、**[プロパティ]、[デバッグ]、[デバッガーの種類]** の順にクリックします。

パッケージ デザイナーで必ず適切な機能を選んでください。 パッケージ デザイナーを開くには、Package.appxmanifest ファイルを開きます。 たとえば、プログラムを使ってピクチャ フォルダーのファイルにアクセスする場合は、パッケージ デザイナーの **[機能]** ペインで **[画像ライブラリ]** チェック ボックスをオンにしてください。

JavaScript コードがコンポーネントのパブリック プロパティまたはパブリック メソッドを認識しない場合は、JavaScript で camel 規約を使っていることを確認します。 たとえば、`ComputeResult` C++ メソッドは、JavaScript で `computeResult` として参照する必要があります。

C++ Windows ランタイム コンポーネント プロジェクトをソリューションから削除する場合、JavaScript プロジェクトからプロジェクト参照も手動で削除する必要があります。 これを行わないと、後続のデバッグまたはビルド操作が妨げられます。 その後、必要に応じてアセンブリ参照を DLL に追加できます。

## <a name="related-topics"></a>関連トピック
* [Windows ランタイム コンポーネントを作成する c++/cli CX](creating-windows-runtime-components-in-cpp.md)
