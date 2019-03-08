---
title: C# および Visual Basic での Windows ランタイム コンポーネントの作成
description: .NET Framework 4.5 以降では、マネージ コードを使って独自の Windows ランタイム型を作成し、Windows ランタイム コンポーネントにパッケージ化することができます。
ms.assetid: A5672966-74DF-40AB-B01E-01E3FCD0AD7A
ms.date: 12/04/2018
ms.topic: article
dev_langs:
- csharp
- vb
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 5a7f2d2db5670b0102f589fcd6d764a239d3bb3f
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57619967"
---
# <a name="creating-windows-runtime-components-in-c-and-visual-basic"></a>C# および Visual Basic での Windows ランタイム コンポーネントの作成
以降、.NET Framework 4.5 では、マネージ コードを使用して、独自の Windows ランタイム型を作成し、Windows ランタイム コンポーネントにパッケージ化します。 C++、JavaScript、Visual Basic で記述されているユニバーサル Windows プラットフォーム (UWP) アプリで、コンポーネントを使用するか、C#します。 このトピックでは、コンポーネントを作成するための規則について説明し、Windows ランタイム用 .NET Framework のサポートの一部の側面について説明します。 このサポートは、通常、.NET Framework のプログラマが意識しなくても利用できるように設計されています。 ただし、JavaScript や C++ で使うコンポーネントを作成する場合は、これらの言語が Windows ランタイムをサポートする方法の違いに注意する必要があります。

Visual Basic で記述された UWP アプリでのみ使用するコンポーネントを作成する場合またはC#、UWP のコントロール、onsider を使用して、コンポーネントが含まれていない、**クラス ライブラリ**テンプレートの代わりに、 **Windowsランタイム コンポーネント**Microsoft Visual Studio でプロジェクト テンプレート。 単純なクラス ライブラリでは、制限は少なくなります。

## <a name="declaring-types-in-windows-runtime-components"></a>Windows ランタイム コンポーネントでの型の宣言

内部的には、コンポーネントでは Windows ランタイム型では、UWP アプリで許可されている .NET Framework の機能を使用できます。 詳細については、次を参照してください。 [UWP アプリ用 .NET](https://msdn.microsoft.com/library/windows/apps/mt185501)します。

外部で、型のメンバーは、そのパラメーターの Windows ランタイム型のみを公開および戻り値。 次の一覧では、Windows ランタイム コンポーネントから公開されている .NET Framework 型の制限事項について説明します。

- コンポーネント内にあるすべてのパブリック型とメンバーのフィールド、パラメーター、戻り値は、Windows ランタイム型である必要があります。 この制限には、Windows ランタイム型と Windows ランタイム自体によって提供される型を作成するが含まれます。 また、さまざまな .NET Framework 型も対象となります。 これらの型を含めることは、一部のサポートは、.NET Framework は、マネージ コードで、Windows ランタイムの自然な使用を有効にする&mdash;基になる Windows ランタイム型ではなく、使い慣れた .NET Framework の型を使用するユーザー コードが表示されます。 たとえば、.NET Framework のプリミティブ型をなどに使用できます**Int32**と**二重**などの特定の基本型**DateTimeOffset**と**Uri**、よく使用されるジェネリック インターフェイスの種類など**IEnumerable&lt;T&gt;**  (Visual Basic では IEnumerable (Of T)) と**IDictionary&lt;TKey, TValue&gt;** します。 これらのジェネリック型の型引数は Windows ランタイム型である必要がありますに注意してください。 これについてのセクションでは説明[マネージ コードに渡すことの Windows ランタイム型](#passing-windows-runtime-types-to-managed-code)と[マネージ型の Windows ランタイムへの引き渡し](#passing-managed-types-to-the-windows-runtime)、このトピックで後述します。

- パブリック クラスとインターフェイスには、メソッド、プロパティ、イベントを含めることができます。 イベントのデリゲートを宣言したり、使用して、 **EventHandler&lt;T&gt;** を委任します。 パブリック クラスまたはインターフェイスは使用できません。
    - ジェネリックにする。
    - インターフェイスは、Windows ランタイム インターフェイスを実装する (ただし、独自の Windows ランタイム インターフェイスを作成およびそれらを実装できます)。
    - など、Windows ランタイムでない型から派生する**System.Exception**と**System.EventArgs**します。

- すべてのパブリック型にはアセンブリ名に一致するルート名前空間が必要になります。ただし、アセンブリ名の先頭には "Windows" を付けることはできません。

    > **ヒント:** します。 既定では、Visual Studio プロジェクトは、アセンブリ名に一致する名前空間の名前があります。 Visual Basic では、この既定の名前空間の Namespace ステートメントはコードに表示されません。

- パブリック構造体はパブリック フィールド以外のメンバーを持つことができません。また、それらのフィールドは値型または文字列であることが必要です。
- パブリック クラスは **sealed** (Visual Basic では **NotInheritable**) であることが必要です。 プログラミング モデルがポリモーフィズムを必要とできますインターフェイスは、パブリック インターフェイスを作成し、ポリモーフィックをする必要があるクラスにそのインターフェイスを実装します。

## <a name="debugging-your-component"></a>コンポーネントのデバッグ

UWP アプリとコンポーネントの両方がマネージ コードに組み込まれている場合、それらをデバッグできます両方同時に。

C++ を使った UWP アプリの一部としてコンポーネントをテストする際に、同時にマネージ コードとネイティブ コードをデバッグできます。 既定では、ネイティブ コードのみになります。

## <a name="to-debug-both-native-c-code-and-managed-code"></a>ネイティブ C++ コードとマネージ コードの両方をデバッグするには
1.  Visual C++ プロジェクトのショートカット メニューを開き、**[プロパティ]** をクリックします。
2.  プロパティ ページの **[構成プロパティ]** で、**[デバッグ]** を選びます。
3.  **[デバッガーの種類]** を選び、ドロップダウン リスト ボックスで、**[ネイティブのみ]** を **[混合 (マネージとネイティブ)]** に変更します。 **[OK]** をクリックします。
4.  ネイティブ コードとマネージ コードのブレークポイントを設定します。

JavaScript を使用して UWP アプリの一部としてコンポーネントをテストするときに既定では、ソリューションは JavaScript デバッグ モード。 Visual Studio では、JavaScript とマネージ コードを同時にデバッグすることはできません。

## <a name="to-debug-managed-code-instead-of-javascript"></a>JavaScript ではなくマネージ コードをデバッグするには
1.  JavaScript プロジェクトのショートカット メニューを開き、**[プロパティ]** を選びます。
2.  プロパティ ページの **[構成プロパティ]** で、**[デバッグ]** を選びます。
3.  **[デバッガーの種類]** を選び、ドロップダウン リスト ボックスで、**[スクリプトのみ]** を **[マネージのみ]** に変更します。 **[OK]** をクリックします。
4.  マネージ コードのブレークポイントを設定し、通常どおりにデバッグします。

## <a name="passing-windows-runtime-types-to-managed-code"></a>マネージ コードへの Windows ランタイム型の引き渡し
セクションで説明したよう[Windows ランタイム コンポーネントの宣言型](#declaring-types-in-windows-runtime-components)、特定の .NET Framework の型がパブリック クラスのメンバーのシグネチャに表示できます。 これは、マネージ コードで Windows ランタイムを通常どおりに使うことができるようにするために、.NET Framework が提供するサポートの一部です。 これには、プリミティブ型と一部のクラスやインターフェイスが含まれます。 、JavaScript または C++ コードからコンポーネントを使用する場合は、呼び出し元に、.NET Framework の型がどのように表示されるかを知る必要があります。 参照してください[チュートリアル。単純なコンポーネントを作成するC#または Visual Basic、および JavaScript による呼び出し](walkthrough-creating-a-simple-windows-runtime-component-and-calling-it-from-javascript.md)の JavaScript の例。 このセクションでは、よく使われる型について説明します。

.NET Framework のプリミティブ型など、 **Int32**構造がある多くの便利なプロパティおよびメソッドなど、 **TryParse**メソッド。 これに対して、Windows ランタイムのプリミティブ型と構造体は、フィールドしか保持していません。 これらの型をマネージ コードに渡すと、.NET Framework 型のように表示され、通常どおりに .NET Framework のプロパティとメソッドを使うことができます。 IDE で自動的に行われる置き換えの概要を次に示します。

-   Windows ランタイムのプリミティブの**Int32**、 **Int64**、**単一**、**二重**、**ブール**、 **文字列**(変更できないコレクションの Unicode 文字)、 **Enum**、 **UInt32**、 **UInt64**、および**Guid**、System 名前空間で同じ名前の型を使用します。
-   **UInt8**を使用して、 **System.Byte**します。
-   **Char16**を使用して、 **System.Char**します。
-   **IInspectable**インターフェイスを使用して**System.Object**します。

場合C#または Visual Basic がこれらの種類のいずれかの言語のキーワードを提供し、代わりに、言語キーワードを使用することができます。

プリミティブ型に加えて、よく使用される基本的な Windows ランタイム型が、同等の .NET Framework 型としてマネージ コードに表示されます。 たとえば、JavaScript のコードで使用して、 **Windows.Foundation.Uri**クラスしたい場合に渡す、C#または Visual Basic のメソッド。 マネージ コードの等価の型は .NET Framework **System.Uri**クラス、メソッド パラメーターに使用する型です。 マネージ コードを記述するとき、Visual Studio の IntelliSense によって Windows ランタイム型が表示されなくなり、同等の .NET Framework 型が示されるため、Windows ランタイム型が .NET Framework 型として表示されていることがわかります  (通常、2 つの型の名前は同じです。 ただし、注意、 **Windows.Foundation.DateTime**としてマネージ コードの構造が表示されます**System.DateTimeOffset**ではなく**System.DateTime**。)。

よく使われるコレクション型の一部では、Windows ランタイム型によって実装されるインターフェイスと、対応する .NET Framework 型によって実装されるインターフェイスと間で対応付けが行われます。 上で説明した型と同じように、.NET Framework 型を使ってパラメーターの型を宣言する必要があります。 これにより、型の間にある相違点を意識せずに、.NET Framework コードを通常どおりに記述することができます。

次の表は、最も一般的なジェネリック インターフェイスの型、および他の一般的なクラスやインターフェイスに関する対応付けを示しています。 .NET Framework がマップされる Windows ランタイム型の完全な一覧を参照してください。 [Windows ランタイム型の .NET Framework のマッピング](net-framework-mappings-of-windows-runtime-types.md)します。

| Windows ランタイム                                  | .NET Framework                                    |
|-|-|
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

型によって複数のインターフェイスが実装される場合、メンバーのパラメーターの型または戻り値の型として実装されるインターフェイスをすべて使うことができます。 たとえば、渡すか返す、**ディクショナリ&lt;int、文字列&gt;** (**Dictionary (Of Integer, String)** Visual Basic で) として**IDictionary&lt;int、文字列&gt;**、 **IReadOnlyDictionary&lt;int、文字列&gt;**、または**IEnumerable&lt;System.Collections.Generic.KeyValuePair&lt;TKey, TValue&gt;&gt;** します。

> [!IMPORTANT]
> JavaScript では、マネージ型を実装するインターフェイスの一覧の先頭に表示されるインターフェイスを使用します。 たとえば、値を返す場合**ディクショナリ&lt;int、文字列&gt;** として表示される JavaScript コードに**IDictionary&lt;int、文字列&gt;** 関係なく戻り値の型として指定するインターフェイスです。 つまり、後のインターフェイスにメンバーが最初のインターフェイスに含まれていない場合、そのメンバーは JavaScript では認識されません。

Windows ランタイムで**IMap&lt;K, V&gt;** と**IMapView&lt;K, V&gt;**  IKeyValuePair を使用して反復されます。 として表示されるときに、マネージ コードに渡す、 **IDictionary&lt;TKey, TValue&gt;** と**IReadOnlyDictionary&lt;TKey, TValue&gt;** ので、使用する自然**System.Collections.Generic.KeyValuePair&lt;TKey, TValue&gt;** それらを列挙します。

インターフェイスがマネージ コード内に表示される方法によって、これらのインターフェイスを実装する型の表示方法が決まります。 たとえば、 **PropertySet**クラスが実装する**IMap&lt;K, V&gt;**、としてマネージ コードに表示される**IDictionary&lt;TKey、TValue&gt;**. **PropertySet**が実装された場合のように見える**IDictionary&lt;TKey, TValue&gt;** の代わりに**IMap&lt;K, V&gt;** 管理で、コードが表示されます、**追加**メソッドのような動作、**追加**メソッド .NET Framework のディクショナリ。 ないように見えます、**挿入**メソッド。 この例では、トピックを確認できます[チュートリアル。単純なコンポーネントを作成するC#または Visual Basic、および JavaScript による呼び出し](walkthrough-creating-a-simple-windows-runtime-component-and-calling-it-from-javascript.md)します。

## <a name="passing-managed-types-to-the-windows-runtime"></a>Windows ランタイムへのマネージ型の引き渡し

前のセクションで説明したように、一部の Windows ランタイム型は、コンポーネントのメンバーのシグニチャ内、または IDE で使う場合は Windows ランタイム メンバーのシグニチャ内で、.NET Framework 型として表示される場合があります。 .NET Framework 型をこれらのメンバーに渡すか、またはコンポーネントのメンバーの戻り値として使うと、対応する Windows ランタイム型として Windows ランタイム側のコードに表示されます。 コンポーネントが JavaScript から呼び出されたときにこのことがあります、効果の例については、マネージ型を返すコンポーネントから"のセクションで[チュートリアル。単純なコンポーネントを作成するC#または Visual Basic、および JavaScript による呼び出し](walkthrough-creating-a-simple-windows-runtime-component-and-calling-it-from-javascript.md)します。

## <a name="overloaded-methods"></a>オーバー ロードされたメソッド

Windows ランタイムでは、メソッドはオーバーロードできます。 ただし場合に、同じ数のパラメーターを持つ複数のオーバー ロードを宣言すると、適用、 [ **Windows.Foundation.Metadata.DefaultOverloadAttribute** ](/uwp/api/windows.foundation.metadata.defaultoverloadattribute)属性をこれらのオーバー ロードの 1 つだけです。 この属性が適用されるオーバーロードが、JavaScript から呼び出すことができる唯一のオーバーロードになります。 たとえば、次のコードでは、**int** (Visual Basic では **Integer**) を受け取るオーバーロードが既定のオーバーロードです。

```csharp
public string OverloadExample(string s)
{
    return s;
}

[Windows.Foundation.Metadata.DefaultOverload()]
public int OverloadExample(int x)
{
    return x;
}
```

```vb
Public Function OverloadExample(ByVal s As String) As String
    Return s
End Function

<Windows.Foundation.Metadata.DefaultOverload> _
Public Function OverloadExample(ByVal x As Integer) As Integer
    Return x
End Function
```

> [重要]JavaScript を使用すると、任意の値を渡す**OverloadExample**、および値パラメーターで必要な型を強制します。 呼び出すことができます**OverloadExample**を"forty-two"、「42」、または 42.3、ですが、すべての値が既定のオーバー ロードに渡されます。 前の例では既定のオーバー ロードは、0、42、および 42 をそれぞれ返します。

適用することはできません、 **DefaultOverloadAttribut**e 属性コンス トラクターにします。 クラスのすべてのコンストラクターは、異なる数のパラメーターを持つ必要があります。

## <a name="implementing-istringable"></a>IStringable の実装

Windows 8.1 以降、Windows ランタイムが含まれています、 **IStringable**インターフェイスの 1 つのメソッドを持つ**IStringable.ToString**、によって提供されるのと同等の基本的な書式設定サポートを提供します。**Object.ToString**します。 実装することを選択する場合**IStringable**で Windows ランタイム コンポーネントでエクスポートしたパブリック マネージ型を次の制限が適用されます。

-   定義することができます、 **IStringable**インターフェイスでは、次のコードなどの「クラスが実装する」関係でしかC#:

    ```cs
    public class NewClass : IStringable
    ```

    Visual Basic では、次のようになります。

    ```vb
    Public Class NewClass : Implements IStringable
    ```

-   実装することはできません**IStringable**インターフェイス。
-   型パラメーターを宣言することはできません**IStringable**します。
-   **IStringable**メソッド、プロパティ、またはフィールドの戻り値の型にすることはできません。
-   非表示にすることはできません、 **IStringable**次などのメソッド定義を使用して基底クラスから実装します。

    ```cs
    public class NewClass : IStringable
    {
       public new string ToString()
       {
          return "New ToString in NewClass";
       }
    }
    ```

    代わりに、 **IStringable.ToString**実装は、基本クラスの実装を常にオーバーライドする必要があります。 非表示にすることができます、 **ToString**厳密に型指定されたクラスのインスタンスで呼び出すによってのみ実装します。

> [!NOTE]
> さまざまな条件、ネイティブ コードから呼び出すを実装するマネージ型に**IStringable**の表示と非その**ToString**実装は、予期しない動作を引き起こすことができます。

## <a name="asynchronous-operations"></a>非同期操作

コンポーネントでは、非同期メソッドを実装するには、メソッド名の末尾に"Async"を追加し、非同期アクションまたは非同期操作を表す Windows ランタイム インターフェイスのいずれかを返します。**IAsyncAction**、 **IAsyncActionWithProgress&lt;TProgress&gt;**、 **IAsyncOperation&lt;TResult&gt;**、または**IAsyncOperationWithProgress&lt;TResult, TProgress&gt;** します。

.NET Framework のタスクを使用することができます (、 [**タスク**](/dotnet/api/system.threading.tasks.task)クラスとジェネリック[**タスク&lt;TResult&gt;**  ](/dotnet/api/system.threading.tasks.task-1)クラス) に非同期メソッドを実装します。 記述された非同期のメソッドから返されたタスクなどの実行中の操作を表すタスクを返す必要がありますC#または Visual Basic、またはタスクから返される、 [ **Task.Run** ](/dotnet/api/system.threading.tasks.task.run)メソッド。 コンストラクターを使ってタスクを作成する場合、その [Task.Start](/dotnet/api/system.threading.tasks.task.start) メソッドを呼び出してから戻す必要があります。

使用するメソッド`await`(`Await` Visual Basic で) 必要があります、`async`キーワード (`Async` Visual Basic で)。 Windows ランタイム コンポーネントからこれらのメソッドを公開する場合は、適用、`async`キーワードをデリゲートに渡す、**実行**メソッド。

取り消しや進行状況の報告をサポートしない非同期アクションと非同期操作では、タスクを適切なインターフェイスにラップするために、[WindowsRuntimeSystemExtensions.AsAsyncAction](https://msdn.microsoft.com/library/system.windowsruntimesystemextensions.asasyncaction.aspx) または [AsAsyncOperation&lt;TResult&gt;](https://msdn.microsoft.com/library/hh779745.aspx) の拡張メソッドを使うことができます。 使用して、次のコードが非同期メソッドを実装するなど、 **Task.Run&lt;TResult&gt;** タスクを開始するメソッド。 **AsAsyncOperation&lt;TResult&gt;** 拡張メソッドは、Windows ランタイムの非同期操作としてタスクを返します。

```csharp
public static IAsyncOperation<IList<string>> DownloadAsStringsAsync(string id)
{
    return Task.Run<IList<string>>(async () =>
    {
        var data = await DownloadDataAsync(id);
        return ExtractStrings(data);
    }).AsAsyncOperation();
}
```

```vb
Public Shared Function DownloadAsStringsAsync(ByVal id As String) _
     As IAsyncOperation(Of IList(Of String))

    Return Task.Run(Of IList(Of String))(
        Async Function()
            Dim data = Await DownloadDataAsync(id)
            Return ExtractStrings(data)
        End Function).AsAsyncOperation()
End Function
```

次の JavaScript コードを使用して、メソッドを呼び出す方法を示しています、 [ **WinJS.Promise** ](https://msdn.microsoft.com/library/windows/apps/br211867.aspx)オブジェクト。 then メソッドに渡される関数は、非同期呼び出しが完了したときに実行されます。 StringList パラメーターにはによって返される文字列のリストが含まれています、 **DownloadAsStringAsync**メソッド、および関数は、すべての処理が必要です。

```javascript
function asyncExample(id) {

    var result = SampleComponent.Example.downloadAsStringAsync(id).then(
        function (stringList) {
            // Place code that uses the returned list of strings here.
        });
}
```

非同期アクションおよび操作のキャンセルをサポートまたは進行状況レポートを使用、 [ **AsyncInfo** ](/dotnet/api/system.runtime.interopservices.windowsruntime)開始されたタスクの生成とフック、キャンセルして、進行状況レポートをクラスタスクのキャンセルと進行状況レポート機能を適切な Windows ランタイム インターフェイスの機能です。 キャンセルと進行状況レポートの両方をサポートする例について、次を参照してください。[チュートリアル。単純なコンポーネントを作成するC#または Visual Basic、および JavaScript による呼び出し](walkthrough-creating-a-simple-windows-runtime-component-and-calling-it-from-javascript.md)します。

メソッドを使用することに注意してください、 **AsyncInfo**クラスの場合でも、非同期メソッドがキャンセルをサポートまたは進行状況レポートしません。 Visual Basic のラムダ関数を使用する場合またはC#匿名メソッドは、トークンのパラメーターを指定しないと[ **IProgress&lt;T&gt;**  ](https://msdn.microsoft.com/library/hh138298.aspx)インターフェイス。 C# のラムダ関数を使う場合は、トークンのパラメーターを指定しますが、無視されます。 前の例で使用、AsAsyncOperation&lt;TResult&gt;メソッドでは、次のようを使用する場合、 [ **AsyncInfo.Run&lt;TResult&gt;(Func&lt;CancellationToken, Task&lt;TResult&gt;&gt;**](https://msdn.microsoft.com/library/hh779740.aspx)) メソッド オーバー ロードを代用します。

```csharp
public static IAsyncOperation<IList<string>> DownloadAsStringsAsync(string id)
{
    return AsyncInfo.Run<IList<string>>(async (token) =>
    {
        var data = await DownloadDataAsync(id);
        return ExtractStrings(data);
    });
}
```

```vb
Public Shared Function DownloadAsStringsAsync(ByVal id As String) _
    As IAsyncOperation(Of IList(Of String))

    Return AsyncInfo.Run(Of IList(Of String))(
        Async Function()
            Dim data = Await DownloadDataAsync(id)
            Return ExtractStrings(data)
        End Function)
End Function
```

必要に応じてキャンセルまたは進行状況レポートをサポートする非同期メソッドを作成する場合は、キャンセル トークンのパラメーターがないオーバー ロードを追加することを検討してくださいまたは**IProgress&lt;T&gt;** インターフェイスです。

## <a name="throwing-exceptions"></a>例外のスロー

Windows アプリ用 .NET に含まれている例外の型は、どれでもスローすることができます。 Windows ランタイム コンポーネントで独自のパブリック型の例外を宣言することはできませんが、非パブリック型を宣言し、スローすることはできます。

コンポーネントが例外を処理しない場合は、コンポーネントを呼び出したコードで対応する例外が発生します。 例外が呼び出し元に表示される方法は、呼び出し元の言語が Windows ランタイムをサポートする方法によって異なります。

-   JavaScript では、例外はオブジェクトとして表示され、例外メッセージがスタック トレースで置き換えられています。 Visual Studio でアプリをデバッグするとき、デバッガーの例外ダイアログ ボックスに、"WinRT 情報" として元のメッセージ テキストが表示されます。 JavaScript コードから元のメッセージ テキストにアクセスすることはできません。

    > **ヒント:** します。 現時点では、スタック トレースには、マネージ例外の種類が含まれていますが、例外の種類を識別するためにトレースを解析はお勧めしません。 このセクションの後半で説明するように、代わりに HRESULT 値を使ってください。

-   C++ では、例外はプラットフォーム例外として表示されます。 マネージ例外の HResult プロパティは、特定のプラットフォーム例外の HRESULT にマップできる場合、は、特定の例外が使用されます。それ以外の場合、 [ **platform::comexception** ](https://msdn.microsoft.com/library/windows/apps/xaml/hh710414.aspx)例外がスローされます。 マネージ例外のメッセージ テキストは、C++ コードでは利用できません。 特定のプラットフォーム例外がスローされた場合、その例外の型に関する既定のメッセージ テキストが表示されます。それ以外の場合は、メッセージ テキストは表示されません。 「[例外 (C++/CX)](https://msdn.microsoft.com/library/windows/apps/xaml/hh699896.aspx)」をご覧ください。
-   C# または Visual Basic では、例外は通常のマネージ例外です。

コンポーネントから例外をスローする場合、コンポーネントに固有の HResult プロパティ値を持つ非パブリック型の例外をスローすることにより、JavaScript や C++ の呼び出し元で例外を簡単に処理できるようになります。 HRESULT は JavaScript の呼び出し元は例外オブジェクトの数値プロパティを使用して、C++ の呼び出し元で使用可能な[ **comexception::hresult** ](https://msdn.microsoft.com/library/windows/apps/xaml/hh710415.aspx)プロパティ。

> [!NOTE]
> 負の値を HRESULT を使用します。 正の値は成功と解釈されるので、JavaScript や C++ の呼び出し元で例外がスローされなくなります。

## <a name="declaring-and-raising-events"></a>イベントの宣言と発生

イベントのデータを保持する型を宣言する場合、EventArgs は Windows ランタイム型ではないので、EventArgs の代わりに Object から派生させます。 使用して、 [ **EventHandler&lt;TEventArgs&gt;**  ](https://msdn.microsoft.com/library/db0etb8x.aspx)イベント、および使用してジェネリック型引数としてイベント引数の型の型として。 イベントは .NET Framework アプリケーションの場合と同様に発生させます。

Windows ランタイム コンポーネントが JavaScript や C++ で使われる場合、イベントはそれらの言語で想定されている Windows ランタイムのイベント パターンに従います。 C# や Visual Basic でコンポーネントを使う場合、イベントは通常の .NET Framework のイベントとして表示されます。 例が提供される[チュートリアル。単純なコンポーネントを作成するC#または Visual Basic、および JavaScript による呼び出し](/windows/uwp/winrt-components/walkthrough-creating-a-simple-windows-runtime-component-and-calling-it-from-javascript)します。

カスタム イベント アクセサーを実装する場合 (Visual Basic では **Custom** キーワードでイベントを宣言する場合) は、実装で Windows ランタイムのイベント パターンに従う必要があります。 「[Windows ランタイム コンポーネントのカスタム イベントおよびイベント アクセサー](custom-events-and-event-accessors-in-windows-runtime-components.md)」をご覧ください。 C# や Visual Basic コードでイベントを処理する場合でも、通常の .NET Framework のイベントとして表示されます。

## <a name="next-steps"></a>次のステップ

ユーザーが独自に使う Windows ランタイム コンポーネントを作成した後で、そのコンポーネントにカプセル化されている機能が他の開発者の役に立つ場合があります。 他の開発者に配布するためにコンポーネントをパッケージ化する方法は 2 つあります。 「[マネージ Windows ランタイム コンポーネントの配布](https://msdn.microsoft.com/library/jj614475.aspx)」をご覧ください。

Visual Basic と C# の言語の機能、および Windows ランタイムに関する .NET Framework のサポートについて詳しくは、「[Visual Basic および C# 言語リファレンス](https://msdn.microsoft.com/library/windows/apps/xaml/br212458.aspx)」をご覧ください。

## <a name="related-topics"></a>関連トピック
* [UWP アプリ用 .NET](https://msdn.microsoft.com/library/windows/apps/mt185501)
* [チュートリアル: 単純な Windows ランタイム コンポーネントの作成および JavaScript による呼び出し](walkthrough-creating-a-simple-windows-runtime-component-and-calling-it-from-javascript.md)
