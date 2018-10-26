---
author: msatranjr
title: C# および Visual Basic での Windows ランタイム コンポーネントの作成
description: .NET Framework 4.5 以降では、マネージ コードを使って独自の Windows ランタイム型を作成し、Windows ランタイム コンポーネントにパッケージ化することができます。
ms.assetid: A5672966-74DF-40AB-B01E-01E3FCD0AD7A
ms.author: misatran
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 4e3b9ed2d256fb9ea8d38690a703baf7fbd3e7f0
ms.sourcegitcommit: 6cc275f2151f78db40c11ace381ee2d35f0155f9
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5572661"
---
# <a name="creating-windows-runtime-components-in-c-and-visual-basic"></a>C# および Visual Basic での Windows ランタイム コンポーネントの作成
.NET Framework 4.5 以降では、マネージ コードを使って独自の Windows ランタイム型を作成し、Windows ランタイム コンポーネントにパッケージ化することができます。 また、C++、JavaScript、Visual Basic、C# を利用することで、ユニバーサル Windows プラットフォーム (UWP) アプリでコンポーネントを使うことができます。 このトピックでは、コンポーネントを作成するための規則について説明し、Windows ランタイムの .NET Framework のサポートの一部の側面を説明します。 このサポートは、通常、.NET Framework のプログラマが意識しなくても利用できるように設計されています。 ただし、JavaScript や C++ で使うコンポーネントを作成する場合は、これらの言語が Windows ランタイムをサポートする方法の違いに注意する必要があります。

Visual Basic または C# を利用して UWP アプリでのみ使うコンポーネントを作成し、そのコンポーネントには UWP コントロールを含めない場合は、**Windows ランタイム コンポーネント** テンプレートではなく、**クラス ライブラリ**  テンプレートを使うことを検討してください。 単純なクラス ライブラリでは、制限は少なくなります。

このトピックには、次のセクションが含まれています。

## <a name="declaring-types-in-windows-runtime-components"></a>Windows ランタイム コンポーネントでの型の宣言
内部的には、コンポーネントの Windows ランタイム型は、ユニバーサル Windows アプリで許可されている .NET Framework の機能をすべて使うことができます  (詳しくは、「[UWP アプリの .NET](https://msdn.microsoft.com/library/windows/apps/xaml/mt185501.aspx)」の概要をご覧ください。外部的には、型のメンバーはパラメーターと戻り値の Windows ランタイム型だけを公開できます。 Windows ランタイム コンポーネントから公開される .NET Framework 型の制限事項を次に示します。

-   コンポーネント内にあるすべてのパブリック型とメンバーのフィールド、パラメーター、戻り値は、Windows ランタイム型である必要があります。

    この制限は、作成した Windows ランタイム型、および Windows ランタイム自体で提供される型を対象としています。 また、さまざまな .NET Framework 型も対象となります。 これらの型の追加は、マネージ コードで Windows ランタイムを通常どおりに使うことができるようにするために、.NET Framework が提供するサポートの一部です。コードでは、基になる Windows ランタイム型ではなく、よく利用する .NET Framework 型が使われているように表示されます。 たとえば、Int32 や Double などの .NET Framework のプリミティブ型、DateTimeOffset や Uri などの特定の基本型、および IEnumerable&lt;T&gt; (Visual Basic では IEnumerable(Of T)) や IDictionary&lt;TKey,TValue&gt; などの一般的に利用されるジェネリック インターフェイス型を使うことができます  (注: これらのジェネリック型の型引数は Windows ランタイム型である必要があります。)これについては説明のセクションでは、Windows ランタイム型の引き渡しをマネージ コードとマネージの引き渡しこのトピックで後で、Windows ランタイムへの種類。

-   パブリック クラスとインターフェイスには、メソッド、プロパティ、イベントを含めることができます。 イベントのデリゲートを宣言したり、EventHandler&lt;T&gt; デリゲートを使ったりすることができます。 パブリック クラスやインターフェイスでは、次のことが許可されていません。

    -   ジェネリックにする。
    -   Windows ランタイム インターフェイスではないインターフェイスを実装する  (ただし、独自の Windows ランタイム インターフェイスを作成し、それを実装することはできます)。
    -   Windows ランタイムにない型 (System.Exception や System.EventArgs など) から派生させる。
-   すべてのパブリック型にはアセンブリ名に一致するルート名前空間が必要になります。ただし、アセンブリ名の先頭には "Windows" を付けることはできません。

    > **ヒント:** 既定では、Visual Studio のプロジェクトがあるアセンブリ名に一致する名前空間の名前。 Visual Basic では、この既定の名前空間の Namespace ステートメントはコードに表示されません。

-   パブリック構造体はパブリック フィールド以外のメンバーを持つことができません。また、それらのフィールドは値型または文字列であることが必要です。
-   パブリック クラスは **sealed** (Visual Basic では **NotInheritable**) であることが必要です。 プログラミング モデルでポリモーフィズムが必要となる場合は、パブリック インターフェイスを作成し、ポリモーフィックにする必要があるクラスにそのインターフェイスを実装できます。

## <a name="debugging-your-component"></a>コンポーネントのデバッグ
ユニバーサル Windows アプリとコンポーネントの両方がマネージ コードで作成されている場合、それらを同時にデバッグできます。

C++ を使ってユニバーサル Windows アプリの一部としてコンポーネントをテストしている場合、マネージ コードとネイティブ コードを同時にデバッグできます。 既定では、ネイティブ コードのみになります。

## **<a name="to-debug-both-native-c-code-and-managed-code"></a>ネイティブ C++ コードとマネージ コードの両方をデバッグするには**
1.  Visual C++ プロジェクトのショートカット メニューを開き、**[プロパティ]** をクリックします。
2.  プロパティ ページの **[構成プロパティ]** で、**[デバッグ]** を選びます。
3.  **[デバッガーの種類]** を選び、ドロップダウン リスト ボックスで、**[ネイティブのみ]** を **[混合 (マネージとネイティブ)]** に変更します。 **[OK]** をクリックします。
4.  ネイティブ コードとマネージ コードのブレークポイントを設定します。

JavaScript を使ってユニバーサル Windows アプリの一部としてコンポーネントをテストしている場合、既定では、ソリューションは JavaScript デバッグ モードになります。 Visual Studio では、JavaScript とマネージ コードを同時にデバッグすることはできません。

## **<a name="to-debug-managed-code-instead-of-javascript"></a>JavaScript ではなくマネージ コードをデバッグするには**
1.  JavaScript プロジェクトのショートカット メニューを開き、**[プロパティ]** を選びます。
2.  プロパティ ページの **[構成プロパティ]** で、**[デバッグ]** を選びます。
3.  **[デバッガーの種類]** を選び、ドロップダウン リスト ボックスで、**[スクリプトのみ]** を **[マネージのみ]** に変更します。 **[OK]** をクリックします。
4.  マネージ コードのブレークポイントを設定し、通常どおりにデバッグします。

## <a name="passing-windows-runtime-types-to-managed-code"></a>マネージ コードへの Windows ランタイム型の引き渡し
「Windows ランタイム コンポーネントでの型の宣言」セクションで既に説明したように、特定の .NET Framework 型はパブリック クラスのメンバーのシグネチャに示される場合があります。 これは、マネージ コードで Windows ランタイムを通常どおりに使うことができるようにするために、.NET Framework が提供するサポートの一部です。 これには、プリミティブ型と一部のクラスやインターフェイスが含まれます。 コンポーネントが JavaScript または C++ コードから使われる場合は、.NET Framework 型が呼び出し元に対してどのように表示されるかを理解することが重要です。 JavaScript を使った例については、「[チュートリアル: C# または Visual Basic での単純なコンポーネントの作成と JavaScript からの呼び出し](walkthrough-creating-a-simple-windows-runtime-component-and-calling-it-from-javascript.md)」をご覧ください。 このセクションでは、よく使われる型について説明します。

.NET Framework では、Int32 構造体などのプリミティブ型は、TryParse メソッドなどの便利なプロパティやメソッドを多数保持しています。 これに対して、Windows ランタイムのプリミティブ型と構造体は、フィールドしか保持していません。 これらの型をマネージ コードに渡すと、.NET Framework 型のように表示され、通常どおりに .NET Framework のプロパティとメソッドを使うことができます。 IDE で自動的に行われる置き換えの概要を次に示します。

-   Windows ランタイムのプリミティブ型 Int32、Int64、Single、Double、Boolean、String (Unicode 文字の変更できないコレクション)、Enum、UInt32、UInt64、および Guid に対しては、System 名前空間に含まれる同じ名前の型が使われます。
-   UInt8 に対しては、System.Byte が使われます。
-   Char16 に対しては、System.Char が使われます。
-   IInspectable インターフェイスに対しては、System.Object が使われます。

C# や Visual Basic で、これらの型に対して言語キーワードが指定されている場合は、代わりに言語キーワードを使うことができます。

プリミティブ型に加えて、よく使用される基本的な Windows ランタイム型が、同等の .NET Framework 型としてマネージ コードに表示されます。 たとえば、JavaScript コードで Windows.Foundation.Uri クラスを使っており、それを C# または Visual Basic のメソッドに渡すとします。 マネージ コードには、対応する型として .NET Framework の System.Uri クラスが示され、この型がメソッド パラメーター用に使われます。 マネージ コードを記述するとき、Visual Studio の IntelliSense によって Windows ランタイム型が表示されなくなり、同等の .NET Framework 型が示されるため、Windows ランタイム型が .NET Framework 型として表示されていることがわかります  (通常、2 つの型の名前は同じです。 ただし、Windows.Foundation.DateTime 構造体は、System.DateTime ではなく、System.DateTimeOffset としてマネージ コードに表示される点に注意してください)。

よく使われるコレクション型の一部では、Windows ランタイム型によって実装されるインターフェイスと、対応する .NET Framework 型によって実装されるインターフェイスと間で対応付けが行われます。 上で説明した型と同じように、.NET Framework 型を使ってパラメーターの型を宣言する必要があります。 これにより、型の間にある相違点を意識せずに、.NET Framework コードを通常どおりに記述することができます。 次の表は、最も一般的なジェネリック インターフェイスの型、および他の一般的なクラスやインターフェイスに関する対応付けを示しています。 .NET Framework が対応する Windows ランタイム型の詳しい一覧については、「.NET Framework での Windows ランタイム型の対応付け」をご覧ください。

| Windows ランタイム                                  | .NET Framework                                    |
|--------------------------------------------------|---------------------------------------------------|
| IIterable&lt;T&gt;                               | IEnumerable&lt;T&gt;                              |
| IVector&lt;T&gt;                                 | IList&lt;T&gt;                                    |
| IVectorView&lt;T&gt;                             | IReadOnlyList&lt;T&gt;                            |
| IMap&lt;K, V&gt;                                 | IDictionary&lt;TKey, TValue&gt;                   |
| IMapView&lt;K, V&gt;                             | IReadOnlyDictionary&lt;TKey, TValue&gt;           |
| IKeyValuePair&lt;K, V&gt;                        | KeyValuePair&lt;TKey, TValue&gt;                  |
| IBindableIterable                                | IEnumerable                                       |
| IBindableVector                                  | IList                                             |
| Windows.UI.Xaml.Data.INotifyPropertyChanged      | System.ComponentModel.INotifyPropertyChanged      |
| Windows.UI.Xaml.Data.PropertyChangedEventHandler | System.ComponentModel.PropertyChangedEventHandler |
| Windows.UI.Xaml.Data.PropertyChangedEventArgs    | System.ComponentModel.PropertyChangedEventArgs    |

型によって複数のインターフェイスが実装される場合、メンバーのパラメーターの型または戻り値の型として実装されるインターフェイスをすべて使うことができます。 たとえば、合格または辞書を返します&lt;int, string&gt; (Dictionary (Of Integer, String) Visual Basic で) IDictionary として&lt;int, string&gt;、IReadOnlyDictionary&lt;int, string&gt;、または IEnumerable&lt;System.Collections.Generic.KeyValuePair&lt;TKey, TValue&gt;&gt;します。

**重要な**JavaScript は、マネージ型が実装されるインターフェイスの一覧で最初に表示されるインターフェイスを使用します。 たとえば、Dictionary&lt;int, string&gt; を JavaScript コードに返した場合、戻り値の型としてどのインターフェイスを指定しても、IDictionary&lt;int, string&gt; として表示されます。 これは、後のインターフェイスで表示されるメンバーが最初のインターフェイスに含まれていない場合、そのメンバーは JavaScript に認識されないことを意味します。

Windows ランタイムでは、IMap&lt;K, V&gt; と IMapView&lt;K, V&gt; は IKeyValuePair を使って反復処理されます。 これらをマネージ コードに渡すと、IDictionary&lt;TKey, TValue&gt; および IReadOnlyDictionary&lt;TKey, TValue&gt; として表示されるため、これらを列挙するには必然的に System.Collections.Generic.KeyValuePair&lt;TKey, TValue&gt; を使います。

インターフェイスがマネージ コード内に表示される方法によって、これらのインターフェイスを実装する型の表示方法が決まります。 たとえば、PropertySet クラスは IMap&lt;K, V&gt; を実装しますが、これはマネージ コードでは IDictionary&lt;TKey, TValue&gt; として表示されます。 PropertySet は、IMap&lt;K, V&gt; ではなく IDictionary&lt;TKey, TValue&gt; を実装したように示されるため、マネージ コードでは、PropertySet は .NET Framework ディクショナリの Add メソッドと同様な動作をする Add メソッドを保持しているように表示されます。 この場合、Insert メソッドは保持していないように表示されます。 この例では、トピックを確認できます[チュートリアル: c# または Visual Basic での単純なコンポーネントの作成と JavaScript からの呼び出し](walkthrough-creating-a-simple-windows-runtime-component-and-calling-it-from-javascript.md)します。

## <a name="passing-managed-types-to-the-windows-runtime"></a>Windows ランタイムへのマネージ型の引き渡し
前のセクションで説明したように、一部の Windows ランタイム型は、コンポーネントのメンバーのシグニチャ内、または IDE で使う場合は Windows ランタイム メンバーのシグニチャ内で、.NET Framework 型として表示される場合があります。 .NET Framework 型をこれらのメンバーに渡すか、またはコンポーネントのメンバーの戻り値として使うと、対応する Windows ランタイム型として Windows ランタイム側のコードに表示されます。 コンポーネントが JavaScript から呼び出されたときの影響に関する例については、[「チュートリアル: C# または Visual Basic での単純なコンポーネントの作成と JavaScript からの呼び出し」](walkthrough-creating-a-simple-windows-runtime-component-and-calling-it-from-javascript.md)の「コンポーネントからマネージ型を返す」セクションをご覧ください。

## <a name="overloaded-methods"></a>オーバー ロードされたメソッド
Windows ランタイムでは、メソッドはオーバーロードできます。 ただし、同じ数のパラメーターを持つ複数のオーバーロードを宣言した場合、これらのオーバーロードのうち 1 つのみに [Windows.Foundation.Metadata.DefaultOverloadAttribute](https://msdn.microsoft.com/library/windows/apps/windows.foundation.metadata.defaultoverloadattribute.aspx) 属性を適用する必要があります。 この属性が適用されるオーバーロードが、JavaScript から呼び出すことができる唯一のオーバーロードになります。 たとえば、次のコードでは、**int** (Visual Basic では **Integer**) を受け取るオーバーロードが既定のオーバーロードです。

> [!div class="tabbedCodeSnippets"]
> ```csharp
> public string OverloadExample(string s)
> {
>     return s;
> }
> [Windows.Foundation.Metadata.DefaultOverload()]
> public int OverloadExample(int x)
> {
>     return x;
> }
> ```
> ```vb
> Public Function OverloadExample(ByVal s As String) As String
>     Return s
> End Function
> <Windows.Foundation.Metadata.DefaultOverload> _
> Public Function OverloadExample(ByVal x As Integer) As Integer
>     Return x
> End Function
> ```

 **注意:** JavaScript と任意の値を OverloadExample に渡す、できますが、値をパラメーターで必要な型に変換します。 OverloadExample を "forty-two"、"42"、または 42.3 を使って呼び出すことができますが、それらの値はすべて既定のオーバーロードに渡されます。 前の例の既定のオーバーロードは、0、42、および 42 をそれぞれ返します。

コンストラクターに DefaultOverloadAttribute 属性を適用することはできません。 クラスのすべてのコンストラクターは、異なる数のパラメーターを持つ必要があります。

## <a name="implementing-istringable"></a>IStringable の実装
Windows 8.1 以降では、Windows ランタイムに IStringable インターフェイスが用意されています。そのメソッドは IStringable.ToString の 1 つだけで、Object.ToString で提供されるサポートに相当する基本的な書式設定のサポートを提供します。 Windows ランタイム コンポーネントでエクスポートしたパブリック マネージ型に IStringable を実装する場合は、次の制限があります。

-   IStringable インターフェイスは、次のコードのように、"クラスが実装する" 関係でのみ定義することができます。C# では、次のようになります。

    ```cs
    public class NewClass : IStringable
    ```

    Visual Basic では、次のようになります。

    ```vb
    Public Class NewClass : Implements IStringable
    ```

-   インターフェイスで IStringable を実装することはできません。
-   パラメーターの型を IStringable として宣言することはできません。
-   IStringable をメソッド、プロパティ、またはフィールドの戻り値の型にすることはできません。
-   次のようなメソッド定義を使って IStringable の実装を基底クラスから隠すことはできません。 

    ```cs
    public class NewClass : IStringable
    {
       public new string ToString()
       {
          return "New ToString in NewClass";
       }
    }
    ```

    代わりに、IStringable.ToString の実装で基底クラスの実装を常にオーバーライドする必要があります。 ToString の実装を隠すことができるのは、厳密に型指定されたクラス インスタンスで呼び出す場合だけです。

IStringable を実装するマネージ型やその ToString の実装を隠すマネージ型をネイティブ コードから呼び出すと、さまざまな状況で予期しない動作を引き起こす可能性があります。

## <a name="asynchronous-operations"></a>非同期操作
コンポーネントで非同期メソッドを実装するには、メソッド名の最後に "Async" を追加し、非同期アクションまたは非同期操作を表す、次の Windows ランタイム インターフェイスのいずれかを返します。IAsyncAction、IAsyncActionWithProgress&lt;TProgress&gt;、IAsyncOperation&lt;TResult&gt;、IAsyncOperationWithProgress&lt;TResult, TProgress&gt;。

.NET Framework タスク ([Task](https://msdn.microsoft.com/library/system.threading.tasks.task.aspx) クラスとジェネリック [Task&lt;TResult&gt;](https://msdn.microsoft.com/library/dd321424.aspx) クラス) を使って、非同期メソッドを実装できます。 C# または Visual Basic で記述された非同期メソッドから返されるタスクや、[Task.Run](https://msdn.microsoft.com/library/system.threading.tasks.task.run.aspx) メソッドから返されたタスクなど、進行中の操作を表すタスクを返す必要があります。 コンストラクターを使ってタスクを作成する場合、その [Task.Start](https://msdn.microsoft.com/library/system.threading.tasks.task.start.aspx) メソッドを呼び出してから戻す必要があります。

await (Visual Basic では Await) を使うメソッドでは、**async** キーワード (Visual Basic では **Async**) が必要です。 Windows ランタイム コンポーネントからそのようなメソッドを公開する場合、Run メソッドに渡すデリゲートに **async** キーワードを適用します。

取り消しや進行状況の報告をサポートしない非同期アクションと非同期操作では、タスクを適切なインターフェイスにラップするために、[WindowsRuntimeSystemExtensions.AsAsyncAction](https://msdn.microsoft.com/library/system.windowsruntimesystemextensions.asasyncaction.aspx) または [AsAsyncOperation&lt;TResult&gt;](https://msdn.microsoft.com/library/hh779745.aspx) の拡張メソッドを使うことができます。 たとえば、次のコードでは、タスクを開始するために Task.Run&lt;TResult&gt; メソッドを使って、非同期メソッドを実装します。 AsAsyncOperation&lt;TResult&gt; 拡張メソッドは、タスクを Windows ランタイムの非同期操作として返します。

> [!div class="tabbedCodeSnippets"]
> ```csharp
> public static IAsyncOperation<IList<string>> DownloadAsStringsAsync(string id)
> {
>     return Task.Run<IList<string>>(async () =>
>     {
>         var data = await DownloadDataAsync(id);
>         return ExtractStrings(data);
>     }).AsAsyncOperation();
> }
> ```
> ```vb
> Public Shared Function DownloadAsStringsAsync(ByVal id As String) _
>      As IAsyncOperation(Of IList(Of String))
>
>     Return Task.Run(Of IList(Of String))(
>         Async Function()
>             Dim data = Await DownloadDataAsync(id)
>             Return ExtractStrings(data)
>         End Function).AsAsyncOperation()
> End Function
> ```

次の JavaScript コードは、[WinJS.Promise](https://msdn.microsoft.com/library/windows/apps/br211867.aspx) オブジェクトを使ってメソッドを呼び出す方法を示しています。 then メソッドに渡される関数は、非同期呼び出しが完了したときに実行されます。 stringList パラメーターには DownloadAsStringAsync メソッドによって返される文字列のリストが含まれ、関数は必要な処理を実行します。

```javascript
function asyncExample(id) {

    var result = SampleComponent.Example.downloadAsStringAsync(id).then(
        function (stringList) {
            // Place code that uses the returned list of strings here.
        });
}
```

取り消しや進行状況の報告をサポートする非同期アクションと非同期操作では、開始されたタスクを生成して、適切な Windows ランタイム インターフェイスの取り消し機能と進行状況の報告機能を持つタスクの取り消し機能と進行状況の報告機能をフックするために、[AsyncInfo](https://msdn.microsoft.com/library/system.runtime.interopservices.windowsruntime.asyncinfo.aspx) クラスを使います。 取り消しおよび進行状況の報告の両方をサポートする例については、「[チュートリアル: C# または Visual Basic での単純なコンポーネントの作成と JavaScript からの呼び出し](walkthrough-creating-a-simple-windows-runtime-component-and-calling-it-from-javascript.md)」をご覧ください。

非同期メソッドが取り消しや進行状況の報告をサポートしていない場合でも、AsyncInfo クラスのメソッドを使うことはできます。 Visual Basic のラムダ関数または C# の匿名メソッドを使う場合は、トークンと [IProgress&lt;T&gt;](https://msdn.microsoft.com/library/hh138298.aspx) インターフェイスのパラメーターを指定しないでください。 C# のラムダ関数を使う場合は、トークンのパラメーターを指定しますが、無視されます。 前の例は、使用 AsAsyncOperation&lt;TResult&gt;メソッドでは、次のようなを使用する場合、 [AsyncInfo.Run&lt;TResult&gt;(Func&lt;CancellationToken, Task&lt;TResult&gt;](https://msdn.microsoft.com/library/hh779740.aspx)) メソッド代わりにオーバー ロードします。

> [!div class="tabbedCodeSnippets"]
> ```csharp
> public static IAsyncOperation<IList<string>> DownloadAsStringsAsync(string id)
> {
>     return AsyncInfo.Run<IList<string>>(async (token) =>
>     {
>         var data = await DownloadDataAsync(id);
>         return ExtractStrings(data);
>     });
> }
> ```
> ```vb
> Public Shared Function DownloadAsStringsAsync(ByVal id As String) _
>     As IAsyncOperation(Of IList(Of String))
>
>     Return AsyncInfo.Run(Of IList(Of String))(
>         Async Function()
>             Dim data = Await DownloadDataAsync(id)
>             Return ExtractStrings(data)
>         End Function)
> End Function
> ```

取り消しや進行状況の報告をオプションでサポートする非同期メソッドを作成する場合は、キャンセル トークンや IProgress&lt;T&gt; インターフェイスのパラメーターを持たないオーバーロードを追加することを検討してください。

## <a name="throwing-exceptions"></a>例外のスロー
Windows アプリ用 .NET に含まれている例外の型は、どれでもスローすることができます。 Windows ランタイム コンポーネントで独自のパブリック型の例外を宣言することはできませんが、非パブリック型を宣言し、スローすることはできます。

コンポーネントが例外を処理しない場合は、コンポーネントを呼び出したコードで対応する例外が発生します。 例外が呼び出し元に表示される方法は、呼び出し元の言語が Windows ランタイムをサポートする方法によって異なります。

-   JavaScript では、例外はオブジェクトとして表示され、例外メッセージがスタック トレースで置き換えられています。 Visual Studio でアプリをデバッグするとき、デバッガーの例外ダイアログ ボックスに、"WinRT 情報" として元のメッセージ テキストが表示されます。 JavaScript コードから元のメッセージ テキストにアクセスすることはできません。

    > **ヒント:** 現時点では、スタック トレースには、マネージ例外の型が含まれていますが、例外の種類を識別するトレースを解析お勧めしません。 このセクションの後半で説明するように、代わりに HRESULT 値を使ってください。

-   C++ では、例外はプラットフォーム例外として表示されます。 マネージ例外の HResult プロパティを特定のプラットフォーム例外の HRESULT にマップできる場合は、そのプラットフォーム例外が使われます。それ以外の場合は、[Platform::COMException](https://msdn.microsoft.com/library/windows/apps/xaml/hh710414.aspx) 例外がスローされます。 マネージ例外のメッセージ テキストは、C++ コードでは利用できません。 特定のプラットフォーム例外がスローされた場合、その例外の型に関する既定のメッセージ テキストが表示されます。それ以外の場合は、メッセージ テキストは表示されません。 「[例外 (C++/CX)](https://msdn.microsoft.com/library/windows/apps/xaml/hh699896.aspx)」をご覧ください。
-   C# または Visual Basic では、例外は通常のマネージ例外です。

コンポーネントから例外をスローする場合、コンポーネントに固有の HResult プロパティ値を持つ非パブリック型の例外をスローすることにより、JavaScript や C++ の呼び出し元で例外を簡単に処理できるようになります。 HRESULT は、JavaScript の呼び出し元では例外オブジェクトの number プロパティから利用でき、C++ の呼び出し元では [COMException::HResult](https://msdn.microsoft.com/library/windows/apps/xaml/hh710415.aspx) プロパティから利用できます。

> **注:**、HRESULT の負の値を使用します。 正の値は成功と解釈されるので、JavaScript や C++ の呼び出し元で例外がスローされなくなります。

## <a name="declaring-and-raising-events"></a>イベントの宣言と発生
イベントのデータを保持する型を宣言する場合、EventArgs は Windows ランタイム型ではないので、EventArgs の代わりに Object から派生させます。 [EventHandler&lt;TEventArgs&gt;](https://msdn.microsoft.com/library/db0etb8x.aspx) をイベントの型として使い、イベント引数の型をジェネリック型引数として使います。 イベントは .NET Framework アプリケーションの場合と同様に発生させます。

Windows ランタイム コンポーネントが JavaScript や C++ で使われる場合、イベントはそれらの言語で想定されている Windows ランタイムのイベント パターンに従います。 C# や Visual Basic でコンポーネントを使う場合、イベントは通常の .NET Framework のイベントとして表示されます。 例については、「[チュートリアル: C# または Visual Basic での単純なコンポーネントの作成と JavaScript からの呼び出し]()」をご覧ください。

カスタム イベント アクセサーを実装する場合 (Visual Basic では **Custom** キーワードでイベントを宣言する場合) は、実装で Windows ランタイムのイベント パターンに従う必要があります。 「[Windows ランタイム コンポーネントのカスタム イベントおよびイベント アクセサー](custom-events-and-event-accessors-in-windows-runtime-components.md)」をご覧ください。 C# や Visual Basic コードでイベントを処理する場合でも、通常の .NET Framework のイベントとして表示されます。

## <a name="next-steps"></a>次の手順
ユーザーが独自に使う Windows ランタイム コンポーネントを作成した後で、そのコンポーネントにカプセル化されている機能が他の開発者の役に立つ場合があります。 他の開発者に配布するためにコンポーネントをパッケージ化する方法は 2 つあります。 「[マネージ Windows ランタイム コンポーネントの配布](https://msdn.microsoft.com/library/jj614475.aspx)」をご覧ください。

Visual Basic と C# の言語の機能、および Windows ランタイムに関する .NET Framework のサポートについて詳しくは、「[Visual Basic および C# 言語リファレンス](https://msdn.microsoft.com/library/windows/apps/xaml/br212458.aspx)」をご覧ください。

## <a name="related-topics"></a>関連トピック
* [UWP アプリの概要の .NET](https://msdn.microsoft.com/library/windows/apps/xaml/br230302.aspx)
* [UWP アプリの .NET](https://msdn.microsoft.com/library/windows/apps/xaml/mt185501.aspx)
* [チュートリアル: 単純な Windows ランタイム コンポーネントの作成と JavaScript からの呼び出し](walkthrough-creating-a-simple-windows-runtime-component-and-calling-it-from-javascript.md)
