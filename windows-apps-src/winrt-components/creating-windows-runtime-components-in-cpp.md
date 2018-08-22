---
author: msatranjr
title: C++ での Windows ランタイム コンポーネントの作成
description: このトピックは、C キーを使用する方法を示しています。 +/CX コンポーネント c#、Visual Basic、c または Javascript を使用して作成されたどこからでも Windows アプリから呼び出すことができるのは、Windows ランタイム コンポーネントを作成します。
ms.assetid: F7E06AA2-DCEC-427E-BD5D-9CA2A0ED2612
ms.author: misatran
ms.date: 05/14/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: b5515d0ed5dc6e200c7c4fc9a7785c993d4cab59
ms.sourcegitcommit: f2f4820dd2026f1b47a2b1bf2bc89d7220a79c1a
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/22/2018
ms.locfileid: "2795339"
---
# <a name="creating-windows-runtime-components-in-ccx"></a>C++/CX での Windows ランタイム コンポーネントの作成
> [!NOTE]
> このトピックは、C++/CX アプリケーションの管理ができるようにすることを目的としています。 ただし、新しいアプリケーションには [C++/WinRT](../cpp-and-winrt-apis/intro-to-using-cpp-with-winrt.md) を使用することをお勧めします。 C++/WinRT は Windows ランタイム (WinRT) API の標準的な最新の C++17 言語プロジェクションで、ヘッダー ファイル ベースのライブラリとして実装され、最新の Windows API への最上位アクセス権を提供するように設計されています。 C キーを使用して Windows ランタイム コンポーネントを作成する方法については、+/WinRT を参照してください[C + でイベントを作成/WinRT](../cpp-and-winrt-apis/author-events.md)します。

このトピックは、C キーを使用する方法を示しています。 +/CX コンポーネント c#、Visual Basic、c または Javascript を使用して作成されたどこからでも Windows アプリから呼び出すことができるのは、Windows ランタイム コンポーネントを作成します。

Windows ランタイム コンポーネントを構築するためのいくつかの理由があります。
- 複雑な操作または負荷の高い操作で C++ のパフォーマンス上のメリットを得る。
- 既に作成されテストされている既存のコードを再利用する。

JavaScript プロジェクトまたは .NET プロジェクト、および Windows ランタイム コンポーネント プロジェクトを含むソリューションを構築すると、JavaScript プロジェクト ファイルとコンパイル済みの DLL が 1 つのパッケージにマージされます。これを、シミュレーターを使ってローカルでデバッグしたり、テザリングされたデバイス上でリモートでデバッグしたりすることができます。 また、拡張 SDK としてコンポーネント プロジェクトだけを配布することもできます。 詳しくは、[ソフトウェア開発キットの作成に関するページ](https://msdn.microsoft.com/library/hh768146.aspx)をご覧ください。

一般に、コーディングするとき、C + +/CX コンポーネントを使用して、通常の C ライブラリと組み込みの種類] を除く抽象バイナリ インターフェイス (ABI) の境界で別の .winmd パッケージとコードのデータを渡しています。 Windows の実行時の種類と特別な書式を使用して、C + +/を作成すると、これらの種類の操作を行う CX をサポートしています。 またで、C + +/CX コード、JavaScript、Visual Basic、C または c# では、コンポーネントから発生して処理できるイベントを実装するには、代理人とイベントなどの種類を使用します。 詳細については、C + +/CX の書式を参照してください[Visual C 言語リファレンス 』 (C + +/CX)](https://msdn.microsoft.com/library/windows/apps/xaml/hh699871.aspx)します。

## <a name="casing-and-naming-rules"></a>大文字小文字の区別と名前付け規則

### <a name="javascript"></a>JavaScript の場合
JavaScript では、大文字と小文字が区別されます。 したがって、次に示す大文字小文字の区別の規則に従う必要があります。

-   C++ の名前空間とクラスを参照する場合、C++ の側と同じ大文字小文字の区別を使います。
-   メソッドを呼び出す場合、メソッド名が C++ の側で大文字になっていても、camel 規約に従った大文字小文字の区別を使います。 たとえば、C++ のメソッド GetDate() は、JavaScript では getDate() として呼び出す必要があります。
-   アクティブ化可能なクラス名や名前空間名には、UNICODE 文字を含めることはできません。

### <a name="net"></a>.NET の場合
.NET 言語では、各言語の通常の大文字と小文字の規則が適用されます。

## <a name="instantiating-the-object"></a>オブジェクトのインスタンス化
Windows ランタイム型のみ ABI の境界を越えて渡すことができます。 コンパイラは、コンポーネントのパブリック メソッドでの戻り値の型または戻り値パラメーターが std::wstring などの型である場合、エラーを発生させます。 Visual C コンポーネントの拡張機能 (C + +/CX) 組み込み型 int、二重、およびその typedef 対応 int32 float64 などの一般的なスカラーを含めるしたりします。 詳しくは、「[型システム (C++/CX)](https://msdn.microsoft.com/library/windows/apps/hh755822.aspx)」をご覧ください。

```cpp
// ref class definition in C++
public ref class SampleRefClass sealed
{
    // Class members...

    // #include <valarray>
public:
    double LogCalc(double input)
    {
        // Use C++ standard library as usual.
        return std::log(input);
    }

};
```

```javascript
//Instantiation in JavaScript (requires "Add reference > Project reference")
var nativeObject = new CppComponent.SampleRefClass();
```

```csharp
//Call a method and display result in a XAML TextBlock
var num = nativeObject.LogCalc(21.5);
ResultText.Text = num.ToString();
```

## <a name="ccx-built-in-types-library-types-and-windows-runtime-types"></a>C + +/CX 組み込み型、ライブラリの種類、および Windows ランタイム型
アクティブ化可能なクラス (ref クラスとも呼ばれます) は、JavaScript、C#、Visual Basic などの他の言語からインスタンス化できるクラスです。 他の言語から利用できるようにするには、コンポーネントに 1 個以上のアクティブ化可能なクラスを含める必要があります。

Windows ランタイム コンポーネントには、複数のアクティブ化可能なパブリック クラスだけでなく、コンポーネント内部でのみ認識される他のクラスも含めることができます。 C + [WebHostHidden](https://msdn.microsoft.com/library/windows/apps/windows.foundation.metadata.webhosthiddenattribute.aspx)属性を適用する +/CX 型 JavaScript に表示されるものではありません。

すべてのパブリック クラスが、コンポーネントのメタデータ ファイルと同じ名前を持つ同じルート名前空間に存在する必要があります。 たとえば、A.B.C.MyClass という名前のクラスは、A.winmd、A.B.winmd、または A.B.C.winmd という名前のメタデータ ファイルで定義されている場合のみインスタンス化できます。 DLL の名前は .winmd ファイルの名前と一致する必要はありません。

クライアント コードでは、他のクラスと同様に、**new** キーワード (Visual Basic の場合は **New**) を使って、コンポーネントのインスタンスを作成します。

アクティブ化可能なクラスは **public ref class sealed** として宣言する必要があります。 **ref class** キーワードは、Windows ランタイムと互換性のある型としてクラスを作成するようにコンパイラに指示し、sealed キーワードは、クラスが継承できないことを指定します。 現在、Windows ランタイムは汎用の継承モデルをサポートしていません。限定的な継承モデルによって、カスタム XAML コントロールの作成をサポートしています。 詳しくは、「[Ref クラスと構造体 (C++/CX)](https://msdn.microsoft.com/library/windows/apps/xaml/hh699870.aspx)」をご覧ください。

C + +/数値プリミティブが既定の名前空間で定義されているすべての cx シリーズします。 [プラットフォーム](https://msdn.microsoft.com/library/windows/apps/xaml/hh710417.aspx)名前空間を含む C + +/は、Windows の実行時に固有の CX クラスがシステムを入力します。 このようなクラスには、[Platform::String](https://msdn.microsoft.com/library/windows/apps/xaml/hh755812.aspx) クラスと [Platform::Object](https://msdn.microsoft.com/library/windows/apps/xaml/hh748265.aspx) クラスがあります。 [Platform::Collections::Map](https://msdn.microsoft.com/library/windows/apps/xaml/hh441508.aspx) クラスや [Platform::Collections::Vector](https://msdn.microsoft.com/library/windows/apps/xaml/hh441570.aspx) クラスなどの具象コレクション型は、[Platform::Collections](https://msdn.microsoft.com/library/windows/apps/xaml/hh710418.aspx) 名前空間で定義されます。 これらの型によって実装されるパブリック インターフェイスは、[Windows::Foundation::Collections 名前空間 (C++/CX)](https://msdn.microsoft.com/library/windows/apps/xaml/hh441496.aspx) で定義されます。 JavaScript、C#、および Visual Basic で利用されるのは、この種類のインターフェイスです。 詳しくは、「[型システム (C++/CX)](https://msdn.microsoft.com/library/windows/apps/hh755822.aspx)」をご覧ください。

## <a name="method-that-returns-a-value-of-built-in-type"></a>組み込み型の値を返すメソッド
```cpp
    // #include <valarray>
public:
    double LogCalc(double input)
    {
        // Use C++ standard library as usual.
        return std::log(input);
    }
```

```javascript
//Call a method
var nativeObject = new CppComponent.SampleRefClass;
var num = nativeObject.logCalc(21.5);
document.getElementById('P2').innerHTML = num;
```

## <a name="method-that-returns-a-custom-value-struct"></a>カスタム値の構造体を返すメソッド
```cpp
namespace CppComponent
{
    // Custom struct
    public value struct PlayerData
    {
        Platform::String^ Name;
        int Number;
        double ScoringAverage;
    };

    public ref class Player sealed
    {
    private:
        PlayerData m_player;
    public:
        property PlayerData PlayerStats
        {
            PlayerData get(){ return m_player; }
            void set(PlayerData data) {m_player = data;}
        }
    };
}
```

ユーザー定義の値の構造体を渡す ABI にわたって、C + で定義されている値構造体と同じメンバーである JavaScript オブジェクトを定義します +/CX します。 ことができますし、そのオブジェクトを引数としてを C + +/CX メソッド オブジェクトは C + に暗黙的に変換できるように +/CX 入力します。

```javascript
// Get and set the value struct
function GetAndSetPlayerData() {
    // Create an object to pass to C++
    var myData =
        { name: "Bob Homer", number: 12, scoringAverage: .357 };
    var nativeObject = new CppComponent.Player();
    nativeObject.playerStats = myData;

    // Retrieve C++ value struct into new JavaScript object
    var myData2 = nativeObject.playerStats;
    document.getElementById('P3').innerHTML = myData.name + " , " + myData.number + " , " + myData.scoringAverage.toPrecision(3);
}
```

もう 1 つの方法は、IPropertySet を実装するクラスを定義することです (ここでは例は示されていません)。

C + で定義されている型の変数の作成した .NET の言語で +/CX コンポーネントします。

```csharp
private void GetAndSetPlayerData()
{
    // Create a ref class
    var player = new CppComponent.Player();

    // Create a variable of a value struct
    // type that is defined in C++
    CppComponent.PlayerData myPlayer;
    myPlayer.Name = "Babe Ruth";
    myPlayer.Number = 12;
    myPlayer.ScoringAverage = .398;

    // Set the property
    player.PlayerStats = myPlayer;

    // Get the property and store it in a new variable
    CppComponent.PlayerData myPlayer2 = player.PlayerStats;
    ResultText.Text += myPlayer.Name + " , " + myPlayer.Number.ToString() +
        " , " + myPlayer.ScoringAverage.ToString();
}
```

## <a name="overloaded-methods"></a>オーバー ロードされたメソッド
C + +/CX パブリック ref クラス オーバー ロードのメソッドを含めることができますが、JavaScript にオーバー ロードされたメソッドを区別する機能が制限されています。 たとえば、以下のシグネチャの相違を区別できます。

```cpp
public ref class NumberClass sealed
{
public:
    int GetNumber(int i);
    int GetNumber(int i, Platform::String^ str);
    double GetNumber(int i, MyData^ d);
};
```

ただし、以下のシグネチャの相違は区別できません。

```cpp
int GetNumber(int i);
double GetNumber(double d);
```

あいまいな場合、JavaScript で特定のオーバーロードを常に呼び出すようにすることができます。そのためには、ヘッダー ファイルのメソッド シグネチャに [Windows::Foundation::Metadata::DefaultOverload](https://msdn.microsoft.com/library/windows/apps/windows.foundation.metadata.defaultoverloadattribute.aspx) 属性を適用します。

次の JavaScript は、属性付きオーバーロードを常に呼び出します。

```javascript
var nativeObject = new CppComponent.NumberClass();
var num = nativeObject.getNumber(9);
document.getElementById('P4').innerHTML = num;
```

## <a name="net"></a>.NET
.NET 言語認識オーバー ロード C + +/.NET Framework クラスと同様に、CX ref クラスします。

## <a name="datetime"></a>DateTime
Windows ランタイムでは、[Windows::Foundation::DateTime](https://msdn.microsoft.com/library/windows/apps/windows.foundation.datetime.aspx) オブジェクトは 1601 年 1 月 1 日の前または後の時間の長さを 100 ナノ秒単位で表した単純な 64 ビットの符号付き整数です。 Windows:Foundation::DateTime オブジェクトには、メソッドはありません。 代わりに、各言語では DateTime をその言語独自の方法で算出します。JavaScript では Date オブジェクト、.NET Framework では System.DateTime 型および System.DateTimeOffset 型を利用します。

```cpp
public  ref class MyDateClass sealed
{
public:
    property Windows::Foundation::DateTime TimeStamp;
    void SetTime(Windows::Foundation::DateTime dt)
    {
        auto cal = ref new Windows::Globalization::Calendar();
        cal->SetDateTime(dt);
        TimeStamp = cal->GetDateTime(); // or TimeStamp = dt;
    }
};
```

C + から DateTime 値を通過するときに +/javascript CX、JavaScript は日付オブジェクトとして受け入れることや、長い形式の日付を文字列として既定で表示されます。

```javascript
function SetAndGetDate() {
    var nativeObject = new CppComponent.MyDateClass();

    var myDate = new Date(1956, 4, 21);
    nativeObject.setTime(myDate);

    var myDate2 = nativeObject.timeStamp;

    //prints long form date string
    document.getElementById('P5').innerHTML = myDate2;

}
```

.NET 言語が C + を System.DateTime を通過するときに +/CX コンポーネントの方法を受け入れることを Windows::Foundation::DateTime としてします。 コンポーネントが .NET Framework メソッドに Windows::Foundation::DateTime を渡すと、その .NET Framework メソッドはこの値を DateTimeOffset として受け取ります。

```csharp
private void DateTimeExample()
{
    // Pass a System.DateTime to a C++ method
    // that takes a Windows::Foundation::DateTime
    DateTime dt = DateTime.Now;
    var nativeObject = new CppComponent.MyDateClass();
    nativeObject.SetTime(dt);

    // Retrieve a Windows::Foundation::DateTime as a
    // System.DateTimeOffset
    DateTimeOffset myDate = nativeObject.TimeStamp;

    // Print the long-form date string
    ResultText.Text += myDate.ToString();
}
```

## <a name="collections-and-arrays"></a>コレクションと配列
コレクションは、常に、Windows::Foundation::Collections::IVector^ や Windows::Foundation::Collections::IMap^ などの Windows ランタイム型へのハンドルとして ABI の境界を越えて渡されます。 たとえば、Platform::Collections::Map にハンドルを返す場合、Windows::Foundation::Collections::IMap^ に暗黙的に変換されます。 コレクション インターフェイスが C + とは別の名前空間で定義されている +/CX クラス コンクリートの実装を提供します。 そのインターフェイスを JavaScript 言語と .NET 言語で利用します。 詳しくは、「[コレクション (C++/CX)](https://msdn.microsoft.com//library/windows/apps/hh700103.aspx)」と「[Array と WriteOnlyArray (C++/CX)](https://msdn.microsoft.com/library/windows/apps/hh700131.aspx)」をご覧ください。

## <a name="passing-ivector"></a>IVector を渡す場合
```cpp
// Windows::Foundation::Collections::IVector across the ABI.
//#include <algorithm>
//#include <collection.h>
Windows::Foundation::Collections::IVector<int>^ SortVector(Windows::Foundation::Collections::IVector<int>^ vec)
{
    std::sort(begin(vec), end(vec));
    return vec;
}
```

```javascript
var nativeObject = new CppComponent.CollectionExample();
// Call the method to sort an integer array
var inVector = [14, 12, 45, 89, 23];
var outVector = nativeObject.sortVector(inVector);
var result = "Sorted vector to array:";
for (var i = 0; i < outVector.length; i++)
{
    outVector[i];
    result += outVector[i].toString() + ",";
}
document.getElementById('P6').innerHTML = result;
```

.NET 言語は IVector&lt;T&gt; を IList&lt;T&gt; として認識します。

```csharp
private void SortListItems()
{
    IList<int> myList = new List<int>();
    myList.Add(5);
    myList.Add(9);
    myList.Add(17);
    myList.Add(2);

    var nativeObject = new CppComponent.CollectionExample();
    IList<int> mySortedList = nativeObject.SortVector(myList);

    foreach (var item in mySortedList)
    {
        ResultText.Text += " " + item.ToString();
    }
}
```

## <a name="passing-imap"></a>IMap を渡す場合
```cpp
// #include <map>
//#include <collection.h>
Windows::Foundation::Collections::IMap<int, Platform::String^> ^GetMap(void)
{    
    Windows::Foundation::Collections::IMap<int, Platform::String^> ^ret =
        ref new Platform::Collections::Map<int, Platform::String^>;
    ret->Insert(1, "One ");
    ret->Insert(2, "Two ");
    ret->Insert(3, "Three ");
    ret->Insert(4, "Four ");
    ret->Insert(5, "Five ");
    return ret;
}
```

```javascript
// Call the method to get the map
var outputMap = nativeObject.getMap();
var mStr = "Map result:" + outputMap.lookup(1) + outputMap.lookup(2)
    + outputMap.lookup(3) + outputMap.lookup(4) + outputMap.lookup(5);
document.getElementById('P7').innerHTML = mStr;
```

.NET 言語は IMap を IDictionary&lt;K, V&gt; として認識します。

```csharp
private void GetDictionary()
{
    var nativeObject = new CppComponent.CollectionExample();
    IDictionary<int, string> d = nativeObject.GetMap();
    ResultText.Text += d[2].ToString();
}
```

## <a name="properties"></a>プロパティ
一般向けの ref クラス C + +/CX コンポーネントの拡張機能は、パブリック データにメンバーをプロパティとしてプロパティのキーワードを使用して公開します。 この概念は .NET Framework のプロパティと同じです。 単純プロパティは機能が暗黙的であるため、データ メンバーに似ています。 非単純プロパティには、明示的な get アクセサーと set アクセサーがあり、値の "バッキング ストア" である名前付きのプライベート変数があります。 この例では、プライベート メンバー変数 \_propertyAValue は PropertyA のバッキング ストアです。 プロパティの値が変化するときにイベントを生成できます。またクライアント アプリは、そのイベントを受け取るように登録することができます。

```cpp
//Properties
public delegate void PropertyChangedHandler(Platform::Object^ sender, int arg);
public ref class PropertyExample  sealed
{
public:
    PropertyExample(){}

    // Event that is fired when PropertyA changes
    event PropertyChangedHandler^ PropertyChangedEvent;

    // Property that has custom setter/getter
    property int PropertyA
    {
        int get() { return m_propertyAValue; }
        void set(int propertyAValue)
        {
            if (propertyAValue != m_propertyAValue)
            {
                m_propertyAValue = propertyAValue;
                // Fire event. (See event example below.)
                PropertyChangedEvent(this, propertyAValue);
            }
        }
    }

    // Trivial get/set property that has a compiler-generated backing store.
    property Platform::String^ PropertyB;

private:
    // Backing store for propertyA.
    int m_propertyAValue;
};
```

```javascript
var nativeObject = new CppComponent.PropertyExample();
var propValue = nativeObject.propertyA;
document.getElementById('P8').innerHTML = propValue;

//Set the string property
nativeObject.propertyB = "What is the meaning of the universe?";
document.getElementById('P9').innerHTML += nativeObject.propertyB;
```

.NET 言語のネイティブ C + プロパティにアクセス +/CX オブジェクトだけでは、.NET Framework オブジェクトと同じようにします。

```csharp
private void GetAProperty()
{
    // Get the value of the integer property
    // Instantiate the C++ object
    var obj = new CppComponent.PropertyExample();

    // Get an integer property
    var propValue = obj.PropertyA;
    ResultText.Text += propValue.ToString();

    // Set a string property
    obj.PropertyB = " What is the meaning of the universe?";
    ResultText.Text += obj.PropertyB;

}
```

## <a name="delegates-and-events"></a>デリゲートおよびイベント
デリゲートは、関数オブジェクトを表す Windows ランタイム型です。 デリゲートは、後で実行するアクションを指定するために、イベント、コールバック、非同期メソッド呼び出しに関連して使います。 デリゲートは、関数オブジェクトのように、関数の戻り値の型とパラメーターの型を確認するためにコンパイラを有効にすることによってタイプ セーフを提供します。 デリゲートの宣言は関数のシグネチャに似ており、実装はクラス定義に、また呼び出しは関数の呼び出しに似ています。

## <a name="adding-an-event-listener"></a>イベント リスナーの追加
指定されたデリゲート型のパブリック メンバーを宣言するために event キーワードを使うことができます。 クライアント コードは、特定の言語に用意されている標準機能を使ってイベントをサブスクライブします。

```cpp
public:
    event SomeHandler^ someEvent;
```

この例では、前のプロパティに関するセクションと同じ C++ コードを使います。

```javascript
function Button_Click() {
    var nativeObj = new CppComponent.PropertyExample();
    // Define an event handler method
    var singlecasthandler = function (ev) {
        document.getElementById('P10').innerHTML = "The button was clicked and the value is " + ev;
    };

    // Subscribe to the event
    nativeObj.onpropertychangedevent = singlecasthandler;

    // Set the value of the property and fire the event
    var propValue = 21;
    nativeObj.propertyA = 2 * propValue;

}
```

.NET 言語の場合、C++ コンポーネントのイベントをサブスクライブすることは、.NET Framework クラスのイベントをサブスクライブすることと同じです。

```csharp
//Subscribe to event and call method that causes it to be fired.
private void TestMethod()
{
    var objWithEvent = new CppComponent.PropertyExample();
    objWithEvent.PropertyChangedEvent += objWithEvent_PropertyChangedEvent;

    objWithEvent.PropertyA = 42;
}

//Event handler method
private void objWithEvent_PropertyChangedEvent(object __param0, int __param1)
{
    ResultText.Text = "the event was fired and the result is " +
         __param1.ToString();
}
```

## <a name="adding-multiple-event-listeners-for-one-event"></a>1 つのイベントに複数のイベント リスナーを追加する
JavaScript には、複数のハンドラーで単一のイベントをサブスクライブできるようにする addEventListener メソッドがあります。

```cpp
public delegate void SomeHandler(Platform::String^ str);

public ref class LangSample sealed
{
public:
    event SomeHandler^ someEvent;
    property Platform::String^ PropertyA;

    // Method that fires an event
    void FireEvent(Platform::String^ str)
    {
        someEvent(Platform::String::Concat(str, PropertyA->ToString()));
    }
    //...
};
```

```javascript
// Add two event handlers
var multicast1 = function (ev) {
    document.getElementById('P11').innerHTML = "Handler 1: " + ev.target;
};
var multicast2 = function (ev) {
    document.getElementById('P12').innerHTML = "Handler 2: " + ev.target;
};

var nativeObject = new CppComponent.LangSample();
//Subscribe to the same event
nativeObject.addEventListener("someevent", multicast1);
nativeObject.addEventListener("someevent", multicast2);

nativeObject.propertyA = "42";

// This method should fire an event
nativeObject.fireEvent("The answer is ");
```

C# では、前の例で示したように += 演算子を使うことで、任意の数のイベント ハンドラーがイベントをサブスクライブできるようになります。

## <a name="enums"></a>列挙型
C + で Windows ランタイム列挙 +/CX パブリック クラス列挙; を使用して宣言標準的な C でスコープ列挙に似ています。

```cpp
public enum class Direction {North, South, East, West};

public ref class EnumExampleClass sealed
{
public:
    property Direction CurrentDirection
    {
        Direction  get(){return m_direction; }
    }

private:
    Direction m_direction;
};
```

C + 間列挙の値は、+/CX および整数として JavaScript します。 C + と同じ名前付きの値を含む JavaScript オブジェクトを宣言することができます (オプション) +/続くとして CX 列挙と使用します。

```javascript
var Direction = { 0: "North", 1: "South", 2: "East", 3: "West" };
//. . .

var nativeObject = new CppComponent.EnumExampleClass();
var curDirection = nativeObject.currentDirection;
document.getElementById('P13').innerHTML =
Direction[curDirection];
```

C# と Visual Basic のどちらの言語でも列挙型がサポートされます。 この 2 つの言語では、.NET Framework の列挙型と同様に C ++ パブリック列挙型クラスを認識します。

## <a name="asynchronous-methods"></a>非同期メソッド
他の Windows ランタイム オブジェクトによって公開される非同期メソッドを利用するには、[task クラス (同時実行ランタイム)](https://msdn.microsoft.com/library/hh750113.aspx) を使います。 詳しくは、「[タスクの並列処理 (同時実行ランタイム)](https://msdn.microsoft.com/library/dd492427.aspx)」をご覧ください。

C + 非同期メソッドを実装するために +/CX、ppltasks.h で定義されている[create\_async](https://msdn.microsoft.com/library/hh750102.aspx)関数を使用します。 詳細については、次を参照してください。 [C + での非同期の操作を作成する +/UWP アプリの CX](https://msdn.microsoft.com/library/vstudio/hh750082.aspx)します。 例については、次を参照してください。[チュートリアル: C + で基本的な Windows ランタイム コンポーネントを作成する +/CX JavaScript または c# から呼び出すと](walkthrough-creating-a-basic-windows-runtime-component-in-cpp-and-calling-it-from-javascript-or-csharp.md)します。 .NET 言語が使用 C + +/CX 非同期メソッドだけでは、.NET Framework で定義されている任意の非同期メソッドと同じようにします。

## <a name="exceptions"></a>例外
Windows ランタイムによって定義された任意の例外の型をスローできます。 Windows ランタイムのどの例外の型からもカスタム型は取得できません。 ただし、COMException をスローし、例外をキャッチするコードがアクセスできるカスタム HRESULT を提供できます。 COMException でカスタム メッセージを指定する方法はありません。

## <a name="debugging-tips"></a>デバッグのヒント
コンポーネント DLL を含む JavaScript ソリューションをデバッグするときは、コンポーネントでスクリプトのステップ実行またはネイティブ コードのステップ実行を有効にするようにデバッガーを設定できますが、この両方を同時に有効にすることはできません。 設定を変更するには、ソリューション エクスプローラーで JavaScript プロジェクト ノードを選んでから、[プロパティ]、[デバッグ]、[デバッガーの種類] の順に選びます。

パッケージ デザイナーで必ず適切な機能を選んでください。 たとえば、Windows ランタイム API を使ってユーザーの画像ライブラリにある画像ファイルを開く場合は、マニフェスト デザイナーの [機能] ウィンドウの [画像ライブラリ] チェック ボックスをオンにします。

JavaScript コードがコンポーネントのパブリック プロパティまたはパブリック メソッドを認識しないと考えられる場合は、JavaScript で camel 規約を使っていることを確認します。 LogCalc C+ たとえば、+/javascript logCalc として CX 方法を参照する必要があります。

C キーを削除する場合は、+/CX Windows ランタイム コンポーネント プロジェクト ソリューションをからは、JavaScript プロジェクトからプロジェクトへの参照も手動で削除する必要があります。 これを行わないと、後続のデバッグまたはビルド操作が妨げられます。 その後、必要に応じてアセンブリ参照を DLL に追加できます。

## <a name="related-topics"></a>関連トピック
* [チュートリアル: C++/CX での基本的な Windows ランタイム コンポーネントの作成と JavaScript または C# からの呼び出し](walkthrough-creating-a-basic-windows-runtime-component-in-cpp-and-calling-it-from-javascript-or-csharp.md)
