---
author: jwmsft
description: XBind マークアップ拡張は、マークアップで使用する機能を許可します。
title: x:Bind の関数
ms.author: jimwalk
ms.date: 04/26/2018
ms.topic: article
keywords: windows 10, uwp, xBind
ms.localizationpriority: medium
ms.openlocfilehash: 7e00762f389791fb3972b6f224759d35bf547e38
ms.sourcegitcommit: cbe7cf620622a5e4df7414f9e38dfecec1cfca99
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/20/2018
ms.locfileid: "7426664"
---
# <a name="functions-in-xbind"></a><span data-ttu-id="a7957-104">x:Bind の関数</span><span class="sxs-lookup"><span data-stu-id="a7957-104">Functions in x:Bind</span></span>

<span data-ttu-id="a7957-105">**注:** データの使用についての一般的な情報は、 **{** x:bind} (および **{X:bind}** と **{Binding}** の間の全体的な比較)、アプリでのバインディングは、[データ バインディング](https://msdn.microsoft.com/library/windows/apps/mt210946)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="a7957-105">**Note**For general info about using data binding in your app with **{x:Bind}** (and for an all-up comparison between **{x:Bind}** and **{Binding}**), see [Data binding in depth](https://msdn.microsoft.com/library/windows/apps/mt210946).</span></span>

<span data-ttu-id="a7957-106">Windows 10 バージョン 1607 以降、**{x:Bind}** はバインド パスのリーフ ステップとしての関数の使用をサポートします。</span><span class="sxs-lookup"><span data-stu-id="a7957-106">Starting in Windows 10, version 1607, **{x:Bind}** supports using a function as the leaf step of the binding path.</span></span> <span data-ttu-id="a7957-107">これにより。</span><span class="sxs-lookup"><span data-stu-id="a7957-107">This enables:</span></span>

- <span data-ttu-id="a7957-108">値の変換を実現するためのより簡単な方法</span><span class="sxs-lookup"><span data-stu-id="a7957-108">A simpler way to achieve value conversion</span></span>
- <span data-ttu-id="a7957-109">複数のパラメーターに依存するようにバインディングする方法</span><span class="sxs-lookup"><span data-stu-id="a7957-109">A way for bindings to depend on more than one parameter</span></span>

> [!NOTE]
> <span data-ttu-id="a7957-110">**{x:Bind}** で関数を使うには、アプリの対象が SDK バージョン 14393 以降である必要があります。</span><span class="sxs-lookup"><span data-stu-id="a7957-110">To use functions with **{x:Bind}**, your app's minimum target SDK version must be 14393 or later.</span></span> <span data-ttu-id="a7957-111">アプリがそれよりも前のバージョンの Windows 10 を対象としている場合は、関数を使えません。</span><span class="sxs-lookup"><span data-stu-id="a7957-111">You can't use functions when your app targets earlier versions of Windows 10.</span></span> <span data-ttu-id="a7957-112">ターゲット バージョンについて詳しくは、「[バージョン アダプティブ コード](https://msdn.microsoft.com/windows/uwp/debug-test-perf/version-adaptive-code)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a7957-112">For more info about target versions, see [Version adaptive code](https://msdn.microsoft.com/windows/uwp/debug-test-perf/version-adaptive-code).</span></span>

<span data-ttu-id="a7957-113">次の例では、項目の背景と前景が、Color パラメーターに基づいて変換を行うために関数にバインドされています。</span><span class="sxs-lookup"><span data-stu-id="a7957-113">In the following example, the background and foreground of the item are bound to functions to do conversion based on the color parameter</span></span>

```xaml
<DataTemplate x:DataType="local:ColorEntry">
    <Grid Background="{x:Bind local:ColorEntry.Brushify(Color), Mode=OneWay}" Width="240">
        <TextBlock Text="{x:Bind ColorName}" Foreground="{x:Bind TextColor(Color)}" Margin="10,5" />
    </Grid>
</DataTemplate>
```

```csharp
class ColorEntry
{
    public string ColorName { get; set; }
    public Color Color { get; set; }

    public static SolidColorBrush Brushify(Color c)
    {
        return new SolidColorBrush(c);
    }

    public SolidColorBrush TextColor(Color c)
    {
        return new SolidColorBrush(((c.R * 0.299 + c.G * 0.587 + c.B * 0.114) > 150) ? Colors.Black : Colors.White);
    }
}
```

## <a name="xaml-attribute-usage"></a><span data-ttu-id="a7957-114">XAML 属性の使用方法</span><span class="sxs-lookup"><span data-stu-id="a7957-114">XAML attribute usage</span></span>

``` syntax
<object property="{x:Bind pathToFunction.FunctionName(functionParameter1, functionParameter2, ...), bindingProperties}" ... />
```

## <a name="path-to-the-function"></a><span data-ttu-id="a7957-115">関数へのパス</span><span class="sxs-lookup"><span data-stu-id="a7957-115">Path to the function</span></span>

<span data-ttu-id="a7957-116">関数へのパスは、他のプロパティ パスと同じように指定され、関数を見つけるためにドット (.)、インデクサー、またはキャストを含めることができます。</span><span class="sxs-lookup"><span data-stu-id="a7957-116">The path to the function is specified like other property paths and can include dots (.), indexers or casts to locate the function.</span></span>

<span data-ttu-id="a7957-117">静的関数は、XMLNamespace:ClassName.MethodName 構文を使って指定できます。</span><span class="sxs-lookup"><span data-stu-id="a7957-117">Static functions can be specified using XMLNamespace:ClassName.MethodName syntax.</span></span> <span data-ttu-id="a7957-118">たとえば、使用して、以下のコード ビハインドで静的関数にバインドするための構文です。</span><span class="sxs-lookup"><span data-stu-id="a7957-118">For example, use the below syntax for binding to static functions in code-behind.</span></span>

```xaml
<Page 
     xmlns:local="using:MyPage">
     ...
     <Grid x:Name="myGrid" Background="Black" >
        <TextBlock Foreground="{x:Bind local:GenerateAppropriateForeground(myGrid.Background)}" Text="Hello World!" />
    </Grid>
</Page>
```
```csharp
public class MyPage : Page
{
    public static GenerateAppropriateForeground(SolidColorBrush background)
    {
        //Implement static function
        ...
    }
}
```

<span data-ttu-id="a7957-119">たとえば日付の書式設定、テキストの書式設定、テキストの連結などの単純なシナリオを実現するのにマークアップで直接システム機能を使用することもできます。</span><span class="sxs-lookup"><span data-stu-id="a7957-119">You can also use system functions directly in markup to accomplish simple scenarios like date formatting, text formatting, text concatenations, etc., For example:</span></span>
```xaml
<Page 
     xmlns:sys="using:System"
     xmlns:local="using:MyPage">
     ...
     <CalendarDatePicker Date="{x:Bind sys:DateTime.Parse(TextBlock1.Text)}" />
     <TextBlock Text="{x:Bind sys:String.Format('{0} is now available in {1}', local:MyPage.personName, local:MyPage.location)}" />
</Page>
```

<span data-ttu-id="a7957-120">モードが OneWay/TwoWay である場合、関数のパスでは変更の検出が実行され、それらのオブジェクトに変更があるとバインディングが再評価されます。</span><span class="sxs-lookup"><span data-stu-id="a7957-120">If the mode is OneWay/TwoWay, then the function path will have change detection performed on it, and the binding will be re-evaluated if there are changes to those objects.</span></span>

<span data-ttu-id="a7957-121">バインディングされる関数には以下のことが要求されます。</span><span class="sxs-lookup"><span data-stu-id="a7957-121">The function being bound to needs to:</span></span>

- <span data-ttu-id="a7957-122">コードとメタデータにアクセスできる必要があります。したがって、C# では internal/private を使用できますが、C++/CX ではメソッドをパブリック WinRT メソッドにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="a7957-122">Be accessible to the code and metadata – so internal / private work in C#, but C++/CX will need methods to be public WinRT methods</span></span>
- <span data-ttu-id="a7957-123">オーバーロードは引数の型ではなく数に基づき、同じ数の引数を持つ最初のオーバーロードとの一致が試みられます。</span><span class="sxs-lookup"><span data-stu-id="a7957-123">Overloading is based on the number of arguments, not type, and it will try to match to the first overload with that many arguments</span></span>
- <span data-ttu-id="a7957-124">引数の型は渡されるデータと一致する必要があります。縮小変換は行われません。</span><span class="sxs-lookup"><span data-stu-id="a7957-124">The argument types need to match the data being passed in – we don’t do narrowing conversions</span></span>
- <span data-ttu-id="a7957-125">関数の戻り値の型は、バインディングを使用しているプロパティの型と一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="a7957-125">The return type of the function needs to match the type of the property that is using the binding</span></span>

<span data-ttu-id="a7957-126">次回のメジャー アップデートを Windows 10 以降、バインド エンジンは、関数の名前で発生したプロパティ変更通知に対応し、必要に応じて、バインディングが再評価します。</span><span class="sxs-lookup"><span data-stu-id="a7957-126">Starting with the next major update to Windows 10, the binding engine will react to property change notifications fired with the function name and re-evaluate bindings as necessary.</span></span> <span data-ttu-id="a7957-127">例:</span><span class="sxs-lookup"><span data-stu-id="a7957-127">For example:</span></span> 

```XAML
<DataTemplate x:DataType="local:Person">
   <StackPanel>
      <TextBlock Text="{x:Bind FullName}" />
      <Image Source="{x:Bind IconToBitmap(Icon, CancellationToken), Mode=OneWay}" />
   </StackPanel>
</DataTemplate>
```
```csharp
public class Person:INotifyPropertyChanged
{
    //Implementation for an Icon property and a CancellationToken property with PropertyChanged notifications
    ...

    //IconToBitmap function is essentially a multi binding converter between several options.
    public Uri IconToBitmap (Uri icon, Uri cancellationToken)
    {
        Uri foo = new Uri(...);        
        if (isCancelled)
        {
            foo = cancellationToken;
        }
        else 
        {
            if (this.fullName.Contains("Sr"))
            {
               //pass a different Uri back
               foo = new Uri(...);
            }
            else
            {
                foo = icon;
            }
        }
        return foo;
    }

    //Ensure FullName property handles change notification on itself as well as IconToBitmap since the function uses it
    public string FullName
    {
        get { return this.fullName; }
        set 
        {
            this.fullName = value;
            this.OnPropertyChanged ();
            this.OnPropertyChanged ("IconToBitmap"); 
            //this ensures Image.Source binding re-evaluates when FullName changes in addition to Icon and CancellationToken
        }
    }
}
```

> [!TIP]
> <span data-ttu-id="a7957-128">コンバーターと wpf MultiBinding によってサポートされたものと同じシナリオを実現するために、X:bind で関数を使用できます。</span><span class="sxs-lookup"><span data-stu-id="a7957-128">You can use functions in x:Bind to achieve the same scenarios as what was supported through Converters and MultiBinding in WPF.</span></span>

## <a name="function-arguments"></a><span data-ttu-id="a7957-129">関数の引数</span><span class="sxs-lookup"><span data-stu-id="a7957-129">Function arguments</span></span>

<span data-ttu-id="a7957-130">複数の関数引数をコンマ (,) で区切って指定できます。</span><span class="sxs-lookup"><span data-stu-id="a7957-130">Multiple function arguments can be specified, separated by comma's (,)</span></span>

- <span data-ttu-id="a7957-131">バインディング パス – そのオブジェクトにバインドする場合と同じ構文です。</span><span class="sxs-lookup"><span data-stu-id="a7957-131">Binding Path – Same syntax as if you were binding directly to that object.</span></span>
  - <span data-ttu-id="a7957-132">モードが OneWay/TwoWay の場合は、変更検出が実行されて、オブジェクトが変化するとバインディングが再評価されます。</span><span class="sxs-lookup"><span data-stu-id="a7957-132">If the mode is OneWay/TwoWay then change detection will be performed and the binding re-evaluated upon object changes</span></span>
- <span data-ttu-id="a7957-133">引用符で囲まれた定数文字列 – 文字列として指定するには引用符が必要です。</span><span class="sxs-lookup"><span data-stu-id="a7957-133">Constant string enclosed in quotes – quotes are needed to designate it as a string.</span></span> <span data-ttu-id="a7957-134">文字列で引用符をエスケープするにはハット (^) を使用できます</span><span class="sxs-lookup"><span data-stu-id="a7957-134">Hat (^) can be used to escape quotes in strings</span></span>
- <span data-ttu-id="a7957-135">定数 - たとえば -123.456</span><span class="sxs-lookup"><span data-stu-id="a7957-135">Constant Number - for example -123.456</span></span>
- <span data-ttu-id="a7957-136">ブール値 – "x:True" または "x:False" と指定します</span><span class="sxs-lookup"><span data-stu-id="a7957-136">Boolean – specified as "x:True" or "x:False"</span></span>

### <a name="two-way-function-bindings"></a><span data-ttu-id="a7957-137">双方向の関数バインド</span><span class="sxs-lookup"><span data-stu-id="a7957-137">Two way function bindings</span></span>

<span data-ttu-id="a7957-138">双方向のバインディング シナリオでは、逆方向のバインドのために第 2 の関数を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="a7957-138">In a two-way binding scenario, a second function must be specified for the reverse direction of the binding.</span></span> <span data-ttu-id="a7957-139">これを行う**BindBack**バインド プロパティを使用します。</span><span class="sxs-lookup"><span data-stu-id="a7957-139">This is done using the **BindBack** binding property.</span></span> <span data-ttu-id="a7957-140">次の例では、関数が、モデルにプッシュ バックする必要がある値が 1 つの引数を受け取る必要があります。</span><span class="sxs-lookup"><span data-stu-id="a7957-140">In the below example, the function should take one argument which is the value that needs to be pushed back to the model.</span></span>
```xaml
<TextBlock Text="{x:Bind a.MyFunc(b), BindBack=a.MyFunc2, Mode=TwoWay}" />
```
