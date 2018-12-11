---
title: C# および Visual Basic での Windows ランタイム コンポーネントの作成
description: .NET Framework 4.5 以降では、マネージ コードを使って独自の Windows ランタイム型を作成し、Windows ランタイム コンポーネントにパッケージ化することができます。
ms.assetid: A5672966-74DF-40AB-B01E-01E3FCD0AD7A
ms.date: 12/04/2018
ms.topic: article
dev_langs:
- csharp
- vb
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: b4f5a2de5c3fa5564b4e4389cfc0806fd5d2844f
ms.sourcegitcommit: 231065c899d0de285584d41e6335251e0c2c4048
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/10/2018
ms.locfileid: "8827137"
---
# <a name="creating-windows-runtime-components-in-c-and-visual-basic"></a>C# および Visual Basic での Windows ランタイム コンポーネントの作成
.NET Framework 4.5 以降、マネージ コードを使用して、独自の Windows ランタイム型を作成し、Windows ランタイム コンポーネントにパッケージ化します。 コンポーネントは、C++、JavaScript、Visual Basic または c# で記述されたユニバーサル Windows プラットフォーム (UWP) アプリで使用できます。 このトピックでは、コンポーネントを作成するための規則について説明し、Windows ランタイムの .NET Framework のサポートの一部の側面を説明します。 このサポートは、通常、.NET Framework のプログラマが意識しなくても利用できるように設計されています。 ただし、JavaScript や C++ で使うコンポーネントを作成する場合は、これらの言語が Windows ランタイムをサポートする方法の違いに注意する必要があります。

Visual Basic または c# で記述されている UWP アプリでのみ使うコンポーネントを作成して、コンポーネントが UWP のコントロールでは、 **Windows ランタイム コンポーネント**プロジェクト テンプレートではなく、**クラス ライブラリ**テンプレートを使用して onsider し、含まれていない場合Microsoft Visual Studio でできます。 単純なクラス ライブラリでは、制限は少なくなります。

## <a name="declaring-types-in-windows-runtime-components"></a>Windows ランタイム コンポーネントでの型の宣言

内部では、コンポーネントでの Windows ランタイム型では、UWP アプリで許可されている .NET Framework の機能を使用できます。 詳しくは、 [UWP アプリ用 .NET](https://msdn.microsoft.com/library/windows/apps/mt185501)を参照してください。

外部では、型のメンバーは、パラメーターの Windows ランタイム型だけを公開し、値を返すできます。 次の一覧では、Windows ランタイム コンポーネントから公開される .NET Framework 型の制限事項について説明します。

- コンポーネント内にあるすべてのパブリック型とメンバーのフィールド、パラメーター、戻り値は、Windows ランタイム型である必要があります。 この制限には、および Windows ランタイム自体で提供される型を作成した Windows ランタイム型が含まれています。 また、さまざまな .NET Framework 型も対象となります。 これらの型の一部は、マネージ コードで Windows ランタイムの自然な使い方を有効にする .NET Framework が提供するサポートの&mdash;、基になる Windows ランタイム型の代わりに、使い慣れた .NET Framework 型を使用するコードが表示されます。 たとえば、.NET Framework のプリミティブ型**Int32**や**Double**、 **DateTimeOffset**や**Uri**などの特定の基本型などを使用して、 **IEnumerable などのジェネリック インターフェイス型をよく使われるいくつか&lt;T&gt; ** (Visual Basic では IEnumerable (Of T)) と**IDictionary&lt;TKey, TValue&gt;** します。 これらのジェネリック型の型引数は Windows ランタイム型である必要がありますに注意してください。 これは、セクションでは、 [Windows ランタイム型の引き渡しをマネージ コード](#passing-windows-runtime-types-to-managed-code)と[マネージ Windows ランタイム型の引き渡し](#passing-managed-types-to-the-windows-runtime)には、このトピックの後半で説明します。

- パブリック クラスとインターフェイスには、メソッド、プロパティ、イベントを含めることができます。 イベントのデリゲートを宣言するか、使用、 **EventHandler&lt;T&gt;** を委任します。 パブリック クラスやインターフェイスは使用できません。
    - ジェネリックにする。
    - Windows ランタイム インターフェイスではないインターフェイスを実装 (ただし、独自の Windows ランタイム インターフェイスを作成してそれらを実装できます)。
    - **System.Exception**や**System.EventArgs**など、Windows ランタイムではなく型から派生します。

- すべてのパブリック型にはアセンブリ名に一致するルート名前空間が必要になります。ただし、アセンブリ名の先頭には "Windows" を付けることはできません。

    > **ヒント**をします。 既定では、Visual Studio プロジェクトはアセンブリ名に一致する名前空間名があります。 Visual Basic では、この既定の名前空間の Namespace ステートメントはコードに表示されません。

- パブリック構造体はパブリック フィールド以外のメンバーを持つことができません。また、それらのフィールドは値型または文字列であることが必要です。
- パブリック クラスは **sealed** (Visual Basic では **NotInheritable**) であることが必要です。 プログラミング モデルには、ポリモーフィズムが必要とする場合はパブリック インターフェイスを作成し、ポリモーフィックにする必要のあるクラスにそのインターフェイスを実装します。

## <a name="debugging-your-component"></a>コンポーネントのデバッグ

If both your UWP app and your component are built with managed code, then you can debug them both at the same time.

C++ を使った UWP アプリの一部としてコンポーネントをテストしている場合は、同時にマネージとネイティブ コードをデバッグできます。 既定では、ネイティブ コードのみになります。

## <a name="to-debug-both-native-c-code-and-managed-code"></a>ネイティブ C++ コードとマネージ コードの両方をデバッグするには
1.  Visual C++ プロジェクトのショートカット メニューを開き、**[プロパティ]** をクリックします。
2.  プロパティ ページの **[構成プロパティ]** で、**[デバッグ]** を選びます。
3.  **[デバッガーの種類]** を選び、ドロップダウン リスト ボックスで、**[ネイティブのみ]** を **[混合 (マネージとネイティブ)]** に変更します。 **[OK]** をクリックします。
4.  ネイティブ コードとマネージ コードのブレークポイントを設定します。

JavaScript を使って UWP アプリの一部としてコンポーネントをテストしているとき既定では、ソリューションは JavaScript デバッグ モード。 Visual Studio では、JavaScript とマネージ コードを同時にデバッグすることはできません。

## <a name="to-debug-managed-code-instead-of-javascript"></a>JavaScript ではなくマネージ コードをデバッグするには
1.  JavaScript プロジェクトのショートカット メニューを開き、**[プロパティ]** を選びます。
2.  プロパティ ページの **[構成プロパティ]** で、**[デバッグ]** を選びます。
3.  **[デバッガーの種類]** を選び、ドロップダウン リスト ボックスで、**[スクリプトのみ]** を **[マネージのみ]** に変更します。 **[OK]** をクリックします。
4.  マネージ コードのブレークポイントを設定し、通常どおりにデバッグします。

## <a name="passing-windows-runtime-types-to-managed-code"></a>マネージ コードへの Windows ランタイム型の引き渡し
[Windows ランタイム コンポーネントの宣言型](#declaring-types-in-windows-runtime-components)セクションで既に説明した、特定の .NET Framework 型はパブリック クラスのメンバーのシグネチャに表示されます。 これは、マネージ コードで Windows ランタイムを通常どおりに使うことができるようにするために、.NET Framework が提供するサポートの一部です。 これには、プリミティブ型と一部のクラスやインターフェイスが含まれます。 JavaScript または C++ コードからコンポーネントを使用する場合は、呼び出し元に、.NET Framework 型がどのように表示されるかを知る必要があります。 JavaScript を使った例については、「[チュートリアル: C# または Visual Basic での単純なコンポーネントの作成と JavaScript からの呼び出し](walkthrough-creating-a-simple-windows-runtime-component-and-calling-it-from-javascript.md)」をご覧ください。 このセクションでは、よく使われる型について説明します。

.NET framework では、多くの便利なプロパティやメソッドは、 **TryParse**メソッドなど、 **Int32**構造体などのプリミティブ型があります。 これに対して、Windows ランタイムのプリミティブ型と構造体は、フィールドしか保持していません。 これらの型をマネージ コードに渡すと、.NET Framework 型のように表示され、通常どおりに .NET Framework のプロパティとメソッドを使うことができます。 IDE で自動的に行われる置き換えの概要を次に示します。

-   Windows ランタイムのプリミティブ**Int32**、 **Int64**、 **1 つ**、 **Double**、 **Boolean**、 **String** (Unicode 文字の変更できないコレクション)、**列挙型**、 **UInt32**、 **UInt64**、および**Guid**、System 名前空間で同じ名前の型を使用します。
-   **UInt8**、 **System.Byte**を使用します。
-   ** **Char16**、に対して system.char キーを押します。**
-   **IInspectable**インターフェイスでは、 **System.Object**を使用します。

C# または Visual Basic のこれら型に対して言語キーワードを提供する場合、できます言語キーワード代わりに使うことです。

プリミティブ型に加えて、よく使用される基本的な Windows ランタイム型が、同等の .NET Framework 型としてマネージ コードに表示されます。 たとえば、JavaScript コードで**Windows.Foundation.Uri**クラスを使用し、それを c# または Visual Basic のメソッドに渡すとします。 マネージ コードでの同等の型は、.NET Framework の**System.Uri**クラスとメソッドのパラメーターを使用する型がします。 マネージ コードを記述するとき、Visual Studio の IntelliSense によって Windows ランタイム型が表示されなくなり、同等の .NET Framework 型が示されるため、Windows ランタイム型が .NET Framework 型として表示されていることがわかります  (通常、2 つの型の名前は同じです。 ただし、 **Windows.Foundation.DateTime**構造体は、 **System.DateTime**ではなく、 **System.DateTimeOffset**としてマネージ コードでが表示されます。)

よく使われるコレクション型の一部では、Windows ランタイム型によって実装されるインターフェイスと、対応する .NET Framework 型によって実装されるインターフェイスと間で対応付けが行われます。 上で説明した型と同じように、.NET Framework 型を使ってパラメーターの型を宣言する必要があります。 これにより、型の間にある相違点を意識せずに、.NET Framework コードを通常どおりに記述することができます。

次の表は、最も一般的なジェネリック インターフェイスの型、および他の一般的なクラスやインターフェイスに関する対応付けを示しています。 .NET Framework にマップする Windows ランタイム型の一覧は、 [Windows ランタイム型の .NET Framework での対応付け](net-framework-mappings-of-windows-runtime-types.md)を参照してください。

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

型によって複数のインターフェイスが実装される場合、メンバーのパラメーターの型または戻り値の型として実装されるインターフェイスをすべて使うことができます。 たとえば、渡すや、戻り値、**ディクショナリ&lt;int, string&gt; ** (Visual Basic では**Dictionary (Of Integer, String)** ) として**IDictionary&lt;int, string&gt;**、 **IReadOnlyDictionary&lt;int, string&gt; **、または**IEnumerable&lt;的に System.Collections.Generic.KeyValuePair&lt;TKey, TValue&gt;** します。

> [!IMPORTANT]
> JavaScript では、マネージ型によって実装されるインターフェイスの一覧で最初に表示されるインターフェイスを使用します。 たとえば、返すこと**ディクショナリ&lt;int, string&gt;** として表示、JavaScript コードに**IDictionary&lt;int, string&gt;** 戻り値の型としてどのインターフェイスに関係なくを指定します。 これは、後のインターフェイスで表示されるメンバーが最初のインターフェイスに含まれていない場合、そのメンバーは JavaScript に認識されないことを意味します。

Windows ランタイムで**IMap&lt;K, V&gt;** と**IMapView&lt;K, V&gt; ** IKeyValuePair を使用して、補間されます。 として表示されるときに、マネージ コードに渡す、 **IDictionary&lt;TKey, TValue&gt;** と**IReadOnlyDictionary&lt;TKey, TValue&gt;** 必然的に System.Collections.Generic.KeyValuePair**を使用して、&lt;TKey、TValue&gt;** それらを列挙します。

インターフェイスがマネージ コード内に表示される方法によって、これらのインターフェイスを実装する型の表示方法が決まります。 たとえば、 **PropertySet**クラスを実装する**IMap&lt;K, V&gt;**、としてマネージ コードで表示される**IDictionary&lt;TKey, TValue&gt;** します。 **PropertySet**は、実装される場合とが表示される**IDictionary&lt;TKey, TValue&gt;** の代わりに**IMap&lt;K, V&gt;** ので、マネージ コードで**Add**メソッド、 **Add**メソッドと同様な動作を持つことが表示されます。.NET Framework ディクショナリです。 それがないように見える、 **Insert**メソッドです。 この例では、トピックを確認できます[チュートリアル: c# または Visual Basic での単純なコンポーネントの作成と JavaScript からの呼び出し](walkthrough-creating-a-simple-windows-runtime-component-and-calling-it-from-javascript.md)します。

## <a name="passing-managed-types-to-the-windows-runtime"></a>Windows ランタイムへのマネージ型の引き渡し

前のセクションで説明したように、一部の Windows ランタイム型は、コンポーネントのメンバーのシグニチャ内、または IDE で使う場合は Windows ランタイム メンバーのシグニチャ内で、.NET Framework 型として表示される場合があります。 .NET Framework 型をこれらのメンバーに渡すか、またはコンポーネントのメンバーの戻り値として使うと、対応する Windows ランタイム型として Windows ランタイム側のコードに表示されます。 コンポーネントが JavaScript から呼び出されたときの影響に関する例については、[「チュートリアル: C# または Visual Basic での単純なコンポーネントの作成と JavaScript からの呼び出し」](walkthrough-creating-a-simple-windows-runtime-component-and-calling-it-from-javascript.md)の「コンポーネントからマネージ型を返す」セクションをご覧ください。

## <a name="overloaded-methods"></a>オーバー ロードされたメソッド

Windows ランタイムでは、メソッドはオーバーロードできます。 ただし、同じ数のパラメーターを持つ複数のオーバー ロードを宣言している場合は、それらのオーバー ロードのいずれかのみに[**Windows.Foundation.Metadata.DefaultOverloadAttribute**](/uwp/api/windows.foundation.metadata.defaultoverloadattribute)属性を適用する必要があります。 この属性が適用されるオーバーロードが、JavaScript から呼び出すことができる唯一のオーバーロードになります。 たとえば、次のコードでは、**int** (Visual Basic では **Integer**) を受け取るオーバーロードが既定のオーバーロードです。

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

> [重要]JavaScript では、任意の値を**OverloadExample**に渡すことができるし、値をパラメーターで必要な型に変換します。 **OverloadExample**を"forty-two"、「42」、または 42.3 を呼び出すことができますが、それらのすべての値が既定のオーバー ロードに渡されます。 既定のオーバー ロードを前の例では、0、42、および 42 をそれぞれ返します。

コンス トラクターを**DefaultOverloadAttribut**e 属性を適用することはできません。 クラスのすべてのコンストラクターは、異なる数のパラメーターを持つ必要があります。

## <a name="implementing-istringable"></a>IStringable の実装

Windows 8.1 以降、Windows ランタイムが 1 つのメソッド、 **IStringable.ToString**、 **Object.ToString**で提供されると同等の基本的な書式設定サポートを提供する**IStringable**インターフェイスが含まれています。 Windows ランタイム コンポーネントでエクスポートしたパブリック マネージ型に**IStringable**を実装する場合は、次の制限が適用されます。

-   C# では、次のコードなどの「クラスが実装する」関係でのみ**IStringable**インターフェイスを定義することができます。

    ```cs
    public class NewClass : IStringable
    ```

    Visual Basic では、次のようになります。

    ```vb
    Public Class NewClass : Implements IStringable
    ```

-   インターフェイスで**IStringable**を実装することはできません。
-   パラメーターの型を**istringable として**宣言することはできません。
-   **IStringable**は、メソッド、プロパティ、またはフィールドの戻り値の型にすることはできません。
-   など、次のメソッドの定義を使用して、基底クラスから**IStringable**の実装を非表示にすることはできません。

    ```cs
    public class NewClass : IStringable
    {
       public new string ToString()
       {
          return "New ToString in NewClass";
       }
    }
    ```

    代わりに、 **IStringable.ToString**の実装は、基底クラスの実装を常にオーバーライドする必要があります。 厳密に型指定されたクラスのインスタンスで呼び出すことでのみ**ToString**の実装を非表示にすることができます。

> [!NOTE]
> さまざまな条件、 **IStringable**を実装やその**ToString**の実装を隠ぺいするマネージ型をネイティブ コードからの呼び出しで予期しない動作を生成できます。

## <a name="asynchronous-operations"></a>非同期操作

コンポーネントで非同期メソッドを実装するメソッド名の末尾に"Async"を追加し、処理や非同期操作を表す Windows ランタイム インターフェイスのいずれかを返します**IAsyncAction**、IAsyncActionWithProgress **&lt; 。TProgress&gt;**、 **IAsyncOperation&lt;TResult&gt;**、または**IAsyncOperationWithProgress&lt;TResult, TProgress&gt;** します。

.NET Framework タスクを使用することができます ( [**Task**](/dotnet/api/system.threading.tasks.task)クラスとジェネリック[**タスク&lt;TResult&gt;**](/dotnet/api/system.threading.tasks.task-1)クラス)、非同期メソッドを実装します。 C# または Visual Basic で記述された非同期メソッドから返されるタスクや[**Task.Run**](/dotnet/api/system.threading.tasks.task.run)メソッドから返されたタスクなどの進行中の操作を表すタスクを返す必要があります。 コンストラクターを使ってタスクを作成する場合、その [Task.Start](/dotnet/api/system.threading.tasks.task.start) メソッドを呼び出してから戻す必要があります。

使用するメソッド`await`(`Await` Visual Basic で) 必要があります、`async`キーワード (`Async` Visual Basic で)。 Windows ランタイム コンポーネントからこれらのメソッドを公開する場合は、適用、 `async` **Run**メソッドに渡すデリゲートにキーワードです。

取り消しや進行状況の報告をサポートしない非同期アクションと非同期操作では、タスクを適切なインターフェイスにラップするために、[WindowsRuntimeSystemExtensions.AsAsyncAction](https://msdn.microsoft.com/library/system.windowsruntimesystemextensions.asasyncaction.aspx) または [AsAsyncOperation&lt;TResult&gt;](https://msdn.microsoft.com/library/hh779745.aspx) の拡張メソッドを使うことができます。 たとえば、次のコードが非同期メソッドを実装を使用して、 **Task.Run&lt;TResult&gt;** タスクを開始するメソッドです。 **AsAsyncOperation&lt;TResult&gt;** 拡張メソッドは、Windows ランタイムの非同期操作としてタスクを返します。

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

次の JavaScript コードは、 [**WinJS.Promise**](https://msdn.microsoft.com/library/windows/apps/br211867.aspx)オブジェクトを使用して、どのようにメソッドを呼び出すことができますを示しています。 then メソッドに渡される関数は、非同期呼び出しが完了したときに実行されます。 StringList パラメーターには**DownloadAsStringAsync**メソッドによって返される文字列の一覧が含まれています、関数は、すべての処理が必要です。

```javascript
function asyncExample(id) {

    var result = SampleComponent.Example.downloadAsStringAsync(id).then(
        function (stringList) {
            // Place code that uses the returned list of strings here.
        });
}
```

非同期アクションと取り消しや進行状況の報告をサポートする操作は、 [**AsyncInfo**](/dotnet/api/system.runtime.interopservices.windowsruntime)クラスを使って開始タスクの生成を取り消しや進行状況レポート タスクの取り消しや進行状況の機能をフック適切な Windows ランタイム インターフェイスの機能を報告します。 取り消しおよび進行状況の報告の両方をサポートする例については、「[チュートリアル: C# または Visual Basic での単純なコンポーネントの作成と JavaScript からの呼び出し](walkthrough-creating-a-simple-windows-runtime-component-and-calling-it-from-javascript.md)」をご覧ください。

非同期メソッドが取り消しをサポートしないや進行状況の報告場合でも、 **AsyncInfo**クラスのメソッドを使用することができることに注意してください。 Visual Basic のラムダ関数または c# の匿名メソッドを使用する場合は、トークンのパラメーターを指定しないでくださいと[**IProgress&lt;T&gt;**](https://msdn.microsoft.com/library/hh138298.aspx)インターフェイスです。 C# のラムダ関数を使う場合は、トークンのパラメーターを指定しますが、無視されます。 前の例は、使用 AsAsyncOperation&lt;TResult&gt;メソッドでは、次のようなを使用する場合、 [**AsyncInfo.Run&lt;TResult&gt;(Func&lt;CancellationToken, Task&lt;TResult&gt;**](https://msdn.microsoft.com/library/hh779740.aspx)) メソッド代わりにオーバー ロードされます。

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

必要に応じて取り消しや進行状況の報告をサポートする非同期メソッドを作成する場合は、キャンセル トークンのパラメーターを持たないオーバー ロードを追加することを検討してくださいまたは**IProgress&lt;T&gt;** インターフェイスです。

## <a name="throwing-exceptions"></a>例外のスロー

Windows アプリ用 .NET に含まれている例外の型は、どれでもスローすることができます。 Windows ランタイム コンポーネントで独自のパブリック型の例外を宣言することはできませんが、非パブリック型を宣言し、スローすることはできます。

コンポーネントが例外を処理しない場合は、コンポーネントを呼び出したコードで対応する例外が発生します。 例外が呼び出し元に表示される方法は、呼び出し元の言語が Windows ランタイムをサポートする方法によって異なります。

-   JavaScript では、例外はオブジェクトとして表示され、例外メッセージがスタック トレースで置き換えられています。 Visual Studio でアプリをデバッグするとき、デバッガーの例外ダイアログ ボックスに、"WinRT 情報" として元のメッセージ テキストが表示されます。 JavaScript コードから元のメッセージ テキストにアクセスすることはできません。

    > **ヒント**をします。現時点では、スタック トレースには、マネージ例外の型が含まれていますが、例外の種類を識別するトレースを解析お勧めしません。 このセクションの後半で説明するように、代わりに HRESULT 値を使ってください。

-   C++ では、例外はプラットフォーム例外として表示されます。 マネージ例外の HResult プロパティは、特定のプラットフォーム例外の HRESULT にマップできる場合、は、特定の例外が使われます。それ以外の場合、 [**Platform::COMException**](https://msdn.microsoft.com/library/windows/apps/xaml/hh710414.aspx)例外がスローされます。 マネージ例外のメッセージ テキストは、C++ コードでは利用できません。 特定のプラットフォーム例外がスローされた場合、その例外の型に関する既定のメッセージ テキストが表示されます。それ以外の場合は、メッセージ テキストは表示されません。 「[例外 (C++/CX)](https://msdn.microsoft.com/library/windows/apps/xaml/hh699896.aspx)」をご覧ください。
-   C# または Visual Basic では、例外は通常のマネージ例外です。

コンポーネントから例外をスローする場合、コンポーネントに固有の HResult プロパティ値を持つ非パブリック型の例外をスローすることにより、JavaScript や C++ の呼び出し元で例外を簡単に処理できるようになります。 HRESULT は、JavaScript の呼び出し元で例外オブジェクトの number プロパティと、C++ の呼び出し元[**:hresult**](https://msdn.microsoft.com/library/windows/apps/xaml/hh710415.aspx)プロパティで使用できます。

> [!NOTE]
> HRESULT の負の値を使用します。 正の値は成功と解釈されるので、JavaScript や C++ の呼び出し元で例外がスローされなくなります。

## <a name="declaring-and-raising-events"></a>イベントの宣言と発生

イベントのデータを保持する型を宣言する場合、EventArgs は Windows ランタイム型ではないので、EventArgs の代わりに Object から派生させます。 使用して[**EventHandler&lt;TEventArgs&gt;**](https://msdn.microsoft.com/library/db0etb8x.aspx)としての種類のイベントと、イベント引数の型をジェネリック型引数として使います。 イベントは .NET Framework アプリケーションの場合と同様に発生させます。

Windows ランタイム コンポーネントが JavaScript や C++ で使われる場合、イベントはそれらの言語で想定されている Windows ランタイムのイベント パターンに従います。 C# や Visual Basic でコンポーネントを使う場合、イベントは通常の .NET Framework のイベントとして表示されます。 例については、「[チュートリアル: C# または Visual Basic での単純なコンポーネントの作成と JavaScript からの呼び出し]()」をご覧ください。

カスタム イベント アクセサーを実装する場合 (Visual Basic では **Custom** キーワードでイベントを宣言する場合) は、実装で Windows ランタイムのイベント パターンに従う必要があります。 「[Windows ランタイム コンポーネントのカスタム イベントおよびイベント アクセサー](custom-events-and-event-accessors-in-windows-runtime-components.md)」をご覧ください。 C# や Visual Basic コードでイベントを処理する場合でも、通常の .NET Framework のイベントとして表示されます。

## <a name="next-steps"></a>次の手順

ユーザーが独自に使う Windows ランタイム コンポーネントを作成した後で、そのコンポーネントにカプセル化されている機能が他の開発者の役に立つ場合があります。 他の開発者に配布するためにコンポーネントをパッケージ化する方法は 2 つあります。 「[マネージ Windows ランタイム コンポーネントの配布](https://msdn.microsoft.com/library/jj614475.aspx)」をご覧ください。

Visual Basic と C# の言語の機能、および Windows ランタイムに関する .NET Framework のサポートについて詳しくは、「[Visual Basic および C# 言語リファレンス](https://msdn.microsoft.com/library/windows/apps/xaml/br212458.aspx)」をご覧ください。

## <a name="related-topics"></a>関連トピック
* [UWP アプリの .NET](https://msdn.microsoft.com/library/windows/apps/mt185501)
* [チュートリアル: 単純な Windows ランタイム コンポーネントの作成と JavaScript からの呼び出し](walkthrough-creating-a-simple-windows-runtime-component-and-calling-it-from-javascript.md)
