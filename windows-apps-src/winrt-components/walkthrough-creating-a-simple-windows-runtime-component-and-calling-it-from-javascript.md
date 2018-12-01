---
title: 単純な Windows ランタイム コンポーネントの作成と JavaScript からの呼び出し
description: このチュートリアルでは、Visual Basic または C# で .NET Framework を使って、Windows ランタイム コンポーネントにパッケージ化される独自の Windows ランタイム型を作成する方法と、JavaScript を使って Windows 用にビルドされたユニバーサル Windows アプリからコンポーネントを呼び出す方法について説明します。
ms.assetid: 1565D86C-BF89-4EF3-81FE-35367DB8D671
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: b177a7741cae0fe786d095c26a6be08ec598bcbb
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/30/2018
ms.locfileid: "8342100"
---
# <a name="walkthrough-creating-a-simple-windows-runtime-component-and-calling-it-from-javascript"></a><span data-ttu-id="f3b2c-104">チュートリアル: 単純な Windows ランタイム コンポーネントの作成と JavaScript からの呼び出し</span><span class="sxs-lookup"><span data-stu-id="f3b2c-104">Walkthrough: Creating a Simple Windows Runtime component and calling it from JavaScript</span></span>




<span data-ttu-id="f3b2c-105">このチュートリアルでは、Visual Basic または C# で .NET Framework を使って、Windows ランタイム コンポーネントにパッケージ化される独自の Windows ランタイム型を作成する方法と、JavaScript を使って Windows 用にビルドされたユニバーサル Windows アプリからコンポーネントを呼び出す方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-105">This walkthrough shows how you can use the .NET Framework with Visual Basic or C# to create your own Windows Runtime types, packaged in a Windows Runtime component, and how to call the component from your Universal Windows app built for Windows using JavaScript.</span></span>

<span data-ttu-id="f3b2c-106">Visual Studio では、C# または Visual Basic で作成された Windows ランタイム コンポーネントをアプリに簡単に追加し、JavaScript から呼び出すことのできる Windows ランタイム型を簡単に作成できます。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-106">Visual Studio makes it easy to add a Windows Runtime component written with C# or Visual Basic to your app, and to create Windows Runtime types that you can call from JavaScript.</span></span> <span data-ttu-id="f3b2c-107">内部では、Windows ランタイム型は、ユニバーサル Windows アプリで許可されている .NET Framework の機能をすべて使用できます </span><span class="sxs-lookup"><span data-stu-id="f3b2c-107">Internally, your Windows Runtime types can use any .NET Framework functionality that's allowed in a Universal Windows app.</span></span> <span data-ttu-id="f3b2c-108">(詳しくは、参照[は、c# および Visual Basic での Windows ランタイム コンポーネントの作成](creating-windows-runtime-components-in-csharp-and-visual-basic.md)と[UWP アプリの概要の .NET](https://msdn.microsoft.com/library/windows/apps/xaml/mt185501.aspx))。外部では、型のメンバーは、パラメーターの Windows ランタイム型だけを公開し、値を返すできます。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-108">(For more information, see [Creating Windows Runtime Components in C# and Visual Basic](creating-windows-runtime-components-in-csharp-and-visual-basic.md) and [.NET for UWP apps overview](https://msdn.microsoft.com/library/windows/apps/xaml/mt185501.aspx).) Externally, the members of your type can expose only Windows Runtime types for their parameters and return values.</span></span> <span data-ttu-id="f3b2c-109">ソリューションをビルドすると、Visual Studio は .NET Framework の Windows ランタイム コンポーネント プロジェクトをビルドし、Windows メタデータ (.winmd) ファイルを作成するビルド ステップを実行します。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-109">When you build your solution, Visual Studio builds your .NET Framework Windows Runtime Component project and then executes a build step that creates a Windows metadata (.winmd) file.</span></span> <span data-ttu-id="f3b2c-110">これが、Visual Studio がアプリに含める Windows ランタイム コンポーネントです。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-110">This is your Windows Runtime component, which Visual Studio includes in your app.</span></span>

> <span data-ttu-id="f3b2c-111">**注:**.NET Framework は、プリミティブ データ型やコレクション型など、よく使われるいくつか .NET Framework 型を対応する Windows ランタイム型に自動的にマップします。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-111">**Note**The .NET Framework automatically maps some commonly used .NET Framework types, such as primitive data types and collection types, to their Windows Runtime equivalents.</span></span> <span data-ttu-id="f3b2c-112">.NET Framework のこれら型は、Windows ランタイム コンポーネントのパブリック インターフェイスで使用でき、対応する Windows ランタイム型としてコンポーネントのユーザーに表示されます。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-112">These .NET Framework types can be used in the public interface of a Windows Runtime component, and will appear to users of the component as the corresponding Windows Runtime types.</span></span> <span data-ttu-id="f3b2c-113">「[C# および Visual Basic での Windows ランタイム コンポーネントの作成](creating-windows-runtime-components-in-csharp-and-visual-basic.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-113">See [Creating Windows Runtime Components in C# and Visual Basic](creating-windows-runtime-components-in-csharp-and-visual-basic.md).</span></span>

<span data-ttu-id="f3b2c-114">このチュートリアルでは、次のタスクについて説明します。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-114">This walkthrough illustrates the following tasks.</span></span> <span data-ttu-id="f3b2c-115">JavaScript で Windows アプリを設定する最初のセクションを完了したら、任意の順序で残りのセクションに進むことができます。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-115">After you've completed the first section, which sets up the Windows app with JavaScript, you can complete the remaining sections in any order.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="f3b2c-116">前提条件:</span><span class="sxs-lookup"><span data-stu-id="f3b2c-116">Prerequisites:</span></span>

-   <span data-ttu-id="f3b2c-117">Windows10</span><span class="sxs-lookup"><span data-stu-id="f3b2c-117">Windows10</span></span>
-   <span data-ttu-id="f3b2c-118">Microsoft Visual Studio2015 または Microsoft Visual Studio Community2015</span><span class="sxs-lookup"><span data-stu-id="f3b2c-118">Microsoft Visual Studio2015 or Microsoft Visual Studio Community2015</span></span>

## <a name="creating-a-simple-windows-runtime-class"></a><span data-ttu-id="f3b2c-119">単純な Windows ランタイム クラスの作成</span><span class="sxs-lookup"><span data-stu-id="f3b2c-119">Creating a simple Windows Runtime class</span></span>


<span data-ttu-id="f3b2c-120">このセクションでは、JavaScript を使って Windows 用にビルドされるユニバーサル Windows アプリを作成し、Visual Basic または C# の Windows ランタイム コンポーネント プロジェクトを追加します。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-120">This section creates a Universal Windows app built for Windows using JavaScript, and adds a Visual Basic or C# Windows Runtime Component project.</span></span> <span data-ttu-id="f3b2c-121">マネージ Windows ランタイム型を定義し、JavaScript からその型のインスタンスを作成して、静的メンバーとインスタンス メンバーを呼び出す方法を示します。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-121">It shows how to define a managed Windows Runtime type, create an instance of the type from JavaScript, and call static and instance members.</span></span> <span data-ttu-id="f3b2c-122">コンポーネントに重点を置くために、サンプル アプリの外観は意図的にぼかしています。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-122">The visual display of the example app is deliberately dull to keep the focus on the component.</span></span> <span data-ttu-id="f3b2c-123">外観は自由に改良してください。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-123">Feel free to make it prettier.</span></span>

1.  <span data-ttu-id="f3b2c-124">Visual Studio で新しい JavaScript プロジェクトを作成します。メニュー バーで、**[ファイル]、[新規作成]、[プロジェクト]** の順にクリックします。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-124">In Visual Studio, create a new JavaScript project: On the menu bar, choose **File, New, Project**.</span></span> <span data-ttu-id="f3b2c-125">**[新しいプロジェクト]** ダイアログ ボックスの **[インストールされたテンプレート]** セクションで **[JavaScript]** を選択し、**[Windows]**、**[ユニバーサル]** の順に選択します </span><span class="sxs-lookup"><span data-stu-id="f3b2c-125">In the **Installed Templates** section of the **New Project** dialog box, choose **JavaScript**, and then choose **Windows**, and then **Universal**.</span></span> <span data-ttu-id="f3b2c-126">([Windows] が利用できない場合は、Windows 8 以降を使っていることを確認してください)。**[新しいアプリケーション]** テンプレートを選び、プロジェクト名として「SampleApp」と入力します。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-126">(If Windows is not available, make sure you're using Windows 8 or later.) Choose the **Blank Application** template and enter SampleApp for the project name.</span></span>
2.  <span data-ttu-id="f3b2c-127">コンポーネント プロジェクトを作成します。ソリューション エクスプローラーで、SampleApp ソリューションのショートカット メニューを開き、**[追加]**、**[新しいプロジェクト]** の順にクリックして、新しい C# プロジェクトまたは Visual Basic プロジェクトをソリューションに追加します。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-127">Create the component project: In Solution Explorer, open the shortcut menu for the SampleApp solution and choose **Add**, and then choose **New Project** to add a new C# or Visual Basic project to the solution.</span></span> <span data-ttu-id="f3b2c-128">**[新しいプロジェクトの追加]** ダイアログ ボックスの **[インストールされたテンプレート]** セクションで、**[Visual Basic]** または **[Visual C#]** を選択し、**[Windows]**、**[ユニバーサル]** の順に選択します。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-128">In the **Installed Templates** section of the **Add New Project** dialog box, choose **Visual Basic** or **Visual C#**, and then choose **Windows**, and then **Universal**.</span></span> <span data-ttu-id="f3b2c-129">**[Windows ランタイム コンポーネント]** テンプレートを選択し、プロジェクト名として「**SampleComponent**」と入力します。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-129">Choose the **Windows Runtime Component** template and enter **SampleComponent** for the project name.</span></span>
3.  <span data-ttu-id="f3b2c-130">クラス名を「**Example**」に変更します。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-130">Change the name of the class to **Example**.</span></span> <span data-ttu-id="f3b2c-131">既定では、クラスは **public sealed** (Visual Basic では **Public NotInheritable**) としてマークされていることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-131">Notice that by default, the class is marked **public sealed** (**Public NotInheritable** in Visual Basic).</span></span> <span data-ttu-id="f3b2c-132">コンポーネントから公開するすべての Windows ランタイム クラスをシールする必要があります。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-132">All the Windows Runtime classes you expose from your component must be sealed.</span></span>
4.  <span data-ttu-id="f3b2c-133">**static** メソッド (Visual Basic では **Shared** メソッド) とインスタンス プロパティの 2 つの単純なメンバーをクラスに追加します。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-133">Add two simple members to the class, a **static** method (**Shared** method in Visual Basic) and an instance property:</span></span>

    > [!div class="tabbedCodeSnippets"]
    > ```csharp
    > namespace SampleComponent
    > {
    >     public sealed class Example
    >     {
    >         public static string GetAnswer()
    >         {
    >             return "The answer is 42.";
    >         }
    >
    >         public int SampleProperty { get; set; }
    >     }
    > }
    > ```
    > ```vb
    > Public NotInheritable Class Example
    >     Public Shared Function GetAnswer() As String
    >         Return "The answer is 42."
    >     End Function
    >
    >     Public Property SampleProperty As Integer
    > End Class
    > ```

5.  <span data-ttu-id="f3b2c-134">省略可能: 新しく追加したメンバーで IntelliSense を有効にするには、ソリューション エクスプローラーで SampleComponent プロジェクトのショートカット メニューを開き、**[ビルド]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-134">Optional: To enable IntelliSense for the newly added members, in Solution Explorer, open the shortcut menu for the SampleComponent project, and then choose **Build**.</span></span>
6.  <span data-ttu-id="f3b2c-135">ソリューション エクスプローラーの JavaScript プロジェクトで、**[参照]** のショートカット メニューを開き、**[参照の追加]** をクリックして **[参照マネージャー]** を開きます。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-135">In Solution Explorer, in the JavaScript project, open the shortcut menu for **References**, and then choose **Add Reference** to open the **Reference Manager**.</span></span> <span data-ttu-id="f3b2c-136">**[プロジェクト]** をクリックし、**[ソリューション]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-136">Choose **Projects**, and then choose **Solution**.</span></span> <span data-ttu-id="f3b2c-137">SampleComponent プロジェクトのチェック ボックスをオンにし、**[OK]** をクリックして参照を追加します。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-137">Select the check box for the SampleComponent project and choose **OK** to add a reference.</span></span>

## <a name="call-the-component-from-javascript"></a><span data-ttu-id="f3b2c-138">JavaScript からコンポーネントを呼び出す</span><span class="sxs-lookup"><span data-stu-id="f3b2c-138">Call the component from JavaScript</span></span>


<span data-ttu-id="f3b2c-139">JavaScript から Windows ランタイム型を使うには、(プロジェクトの js フォルダーにある) default.js ファイルで、Visual Studio テンプレートで提供される匿名関数に次のコードを追加します。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-139">To use the Windows Runtime type from JavaScript, add the following code in the anonymous function in the default.js file (in the js folder of the project) that is provided by the Visual Studio template.</span></span> <span data-ttu-id="f3b2c-140">匿名関数は、app.oncheckpoint イベント ハンドラーの後の app.start 呼び出しの前にあります。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-140">It should go after the app.oncheckpoint event handler and before the call to app.start.</span></span>

```javascript
var ex;

function basics1() {
   document.getElementById('output').innerHTML =
        SampleComponent.Example.getAnswer();

    ex = new SampleComponent.Example();

   document.getElementById('output').innerHTML += "<br/>" +
       ex.sampleProperty;

}

function basics2() {
    ex.sampleProperty += 1;
    document.getElementById('output').innerHTML += "<br/>" +
        ex.sampleProperty;
}
```

<span data-ttu-id="f3b2c-141">各メンバー名の最初の文字が大文字から小文字に変更されていることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-141">Notice that the first letter of each member name is changed from uppercase to lowercase.</span></span> <span data-ttu-id="f3b2c-142">この変換は、Windows ランタイムの自然な使い方を可能にするために JavaScript が提供するサポートの一部です。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-142">This transformation is part of the support that JavaScript provides to enable the natural use of the Windows Runtime.</span></span> <span data-ttu-id="f3b2c-143">名前空間とクラス名は pascal 規約に従って大文字小文字が使い分けられます。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-143">Namespaces and class names are Pascal-cased.</span></span> <span data-ttu-id="f3b2c-144">すべて小文字のイベント名を除き、メンバー名は camel 規約に従っています。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-144">Member names are camel-cased except for event names, which are all lowercase.</span></span> <span data-ttu-id="f3b2c-145">「[JavaScript での Windows ランタイムの使用](https://msdn.microsoft.com/library/hh710230.aspx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-145">See [Using the Windows Runtime in JavaScript](https://msdn.microsoft.com/library/hh710230.aspx).</span></span> <span data-ttu-id="f3b2c-146">camel 規約の規則はわかりにくい場合があります。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-146">The rules for camel casing can be confusing.</span></span> <span data-ttu-id="f3b2c-147">通常、一連の先頭の大文字は小文字で表示されますが、3 つの大文字の後に小文字が続く場合は、最初の 2 つの文字だけが小文字で表示されます。たとえば、IDStringKind という名前のメンバーは idStringKind と表示されます。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-147">A series of initial uppercase letters normally appears as lowercase, but if three uppercase letters are followed by a lowercase letter, only the first two letters appear in lowercase: for example, a member named IDStringKind appears as idStringKind.</span></span> <span data-ttu-id="f3b2c-148">Visual Studio では、Windows ランタイム コンポーネント プロジェクトをビルドし、JavaScript プロジェクトで IntelliSense を使って正しい大文字小文字の区別を確認できます。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-148">In Visual Studio, you can build your Windows Runtime component project and then use IntelliSense in your JavaScript project to see the correct casing.</span></span>

<span data-ttu-id="f3b2c-149">同様に、.NET Framework は、マネージ コードでの Windows ランタイムの自然な使い方を可能にするためのサポートを提供します。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-149">In similar fashion, the .NET Framework provides support to enable the natural use of the Windows Runtime in managed code.</span></span> <span data-ttu-id="f3b2c-150">これは、記事では、 [c# および Visual Basic での Windows ランタイム コンポーネントの作成](creating-windows-runtime-components-in-csharp-and-visual-basic.md)および[UWP アプリと Windows ランタイムの .NET Framework のサポート](https://msdn.microsoft.com/library/hh694558.aspx)と、この記事の以降のセクションで説明します。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-150">This is discussed in subsequent sections of this article, and in the articles [Creating Windows Runtime Components in C# and Visual Basic](creating-windows-runtime-components-in-csharp-and-visual-basic.md) and [.NET Framework Support for UWP apps and Windows Runtime](https://msdn.microsoft.com/library/hh694558.aspx).</span></span>

## <a name="create-a-simple-user-interface"></a><span data-ttu-id="f3b2c-151">単純なユーザー インターフェイスを作成する</span><span class="sxs-lookup"><span data-stu-id="f3b2c-151">Create a simple user interface</span></span>


<span data-ttu-id="f3b2c-152">JavaScript プロジェクトで、default.html ファイルを開き、次のコードに示すように本文を更新します。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-152">In your JavaScript project, open the default.html file and update the body as shown in the following code.</span></span> <span data-ttu-id="f3b2c-153">このコードには、サンプル アプリのコントロールの完全なセットが含まれています。また、クリック イベントの関数名も指定されています。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-153">This code includes the complete set of controls for the example app and specifies the function names for the click events.</span></span>

> <span data-ttu-id="f3b2c-154">**注:** Basics1 と Basics2 ボタンだけがサポートされているアプリを初めて実行するとします。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-154">**Note**When you first run the app, only the Basics1 and Basics2 button are supported.</span></span>

```html
<body>
            <div id="buttons">
            <button id="button1" >Basics 1</button>
            <button id="button2" >Basics 2</button>

            <button id="runtimeButton1">Runtime 1</button>
            <button id="runtimeButton2">Runtime 2</button>

            <button id="returnsButton1">Returns 1</button>
            <button id="returnsButton2">Returns 2</button>

            <button id="events1Button">Events 1</button>

            <button id="btnAsync">Async</button>
            <button id="btnCancel" disabled="disabled">Cancel Async</button>
            <progress id="primeProg" value="25" max="100" style="color: yellow;"></progress>
        </div>
        <div id="output">
        </div>
</body>
```

<span data-ttu-id="f3b2c-155">JavaScript プロジェクトで、css フォルダーの default.css を開きます。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-155">In your JavaScript project, in the css folder, open default.css.</span></span> <span data-ttu-id="f3b2c-156">body セクションを次のように変更し、ボタンのレイアウトと出力テキストの配置を制御するスタイルを追加します。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-156">Modify the body section as shown, and add styles to control the layout of buttons and the placement of output text.</span></span>

```css
body
{
    -ms-grid-columns: 1fr;
    -ms-grid-rows: 1fr 14fr;
    display: -ms-grid;
}

#buttons {
    -ms-grid-rows: 1fr;
    -ms-grid-columns: auto;
    -ms-grid-row-align: start;
}
#output {
    -ms-grid-row: 2;
    -ms-grid-column: 1;
}
```

<span data-ttu-id="f3b2c-157">次に、default.js で app.onactivated 内の processAll 呼び出しに then 句を追加して、イベント リスナーの登録コードを追加します。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-157">Now add the event listener registration code by adding a then clause to the processAll call in app.onactivated in default.js.</span></span> <span data-ttu-id="f3b2c-158">setPromise を呼び出す既存のコード行を置き換え、次のコードに変更します。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-158">Replace the existing line of code that calls setPromise and change it to the following code:</span></span>

```javascript
args.setPromise(WinJS.UI.processAll().then(function () {
    var button1 = document.getElementById("button1");
    button1.addEventListener("click", basics1, false);
    var button2 = document.getElementById("button2");
    button2.addEventListener("click", basics2, false);
}));
```

<span data-ttu-id="f3b2c-159">HTML コントロールにイベントを追加するときは、HTML でクリック イベント ハンドラーを直接追加するのではなく、この方法をお勧めします。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-159">This is a better way to add events to HTML controls than adding a click event handler directly in HTML.</span></span> <span data-ttu-id="f3b2c-160">「["Hello, world" アプリを作成する (JS)](https://msdn.microsoft.com/library/windows/apps/mt280216)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-160">See [Create a "Hello World" app (JS)](https://msdn.microsoft.com/library/windows/apps/mt280216).</span></span>

## <a name="build-and-run-the-app"></a><span data-ttu-id="f3b2c-161">アプリをビルドして実行する</span><span class="sxs-lookup"><span data-stu-id="f3b2c-161">Build and run the app</span></span>


<span data-ttu-id="f3b2c-162">ビルドする前に、お使いのコンピューターに応じて、すべてのプロジェクトのターゲット プラットフォームを ARM、x64、または x86 に変更します。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-162">Before you build, change the target platform for all projects to ARM, x64, or x86, as appropriate for your computer.</span></span>

<span data-ttu-id="f3b2c-163">ソリューションをビルドして実行するには、F5 キーを押します </span><span class="sxs-lookup"><span data-stu-id="f3b2c-163">To build and run the solution, choose the F5 key.</span></span> <span data-ttu-id="f3b2c-164">(SampleComponent が未定義であることを示す実行時エラー メッセージが表示された場合は、クラス ライブラリ プロジェクトへの参照がありません)。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-164">(If you get a run-time error message stating that SampleComponent is undefined, the reference to the class library project is missing.)</span></span>

<span data-ttu-id="f3b2c-165">Visual Studio では、まずクラス ライブラリをコンパイルし、[Winmdexp.exe (Windows ランタイム メタデータ エクスポート ツール)](https://msdn.microsoft.com/library/hh925576.aspx) を実行する MSBuild タスクを実行して、Windows ランタイム コンポーネントを作成します。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-165">Visual Studio first compiles the class library, and then executes an MSBuild task that runs [Winmdexp.exe (Windows Runtime Metadata Export Tool)](https://msdn.microsoft.com/library/hh925576.aspx) to create your Windows Runtime component.</span></span> <span data-ttu-id="f3b2c-166">コンポーネントは、マネージ コードと、コードを説明する Windows メタデータの両方を含む .winmd ファイルに含まれています。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-166">The component is included in a .winmd file that contains both the managed code and the Windows metadata that describes the code.</span></span> <span data-ttu-id="f3b2c-167">Windows ランタイム コンポーネントで無効なコードを作成した場合、WinMdExp.exe によってビルド エラー メッセージが生成され、Visual Studio IDE に表示されます。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-167">WinMdExp.exe generates build error messages when you write code that's invalid in a Windows Runtime component, and the error messages are displayed in the Visual Studio IDE.</span></span> <span data-ttu-id="f3b2c-168">コンポーネントはユニバーサル Windows アプリのアプリ パッケージ (.appx ファイル) に追加され、適切なマニフェストが生成されます。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-168">Visual Studio adds your component to the app package (.appx file) for your Universal Windows app, and generates the appropriate manifest.</span></span>

<span data-ttu-id="f3b2c-169">[Basics 1] ボタンをクリックして GetAnswer 静的メソッドからの戻り値を出力領域に割り当て、Example クラスのインスタンスを作成し、SampleProperty プロパティの値を出力領域に表示します。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-169">Choose the Basics 1 button to assign the return value from the static GetAnswer method to the output area, create an instance of the Example class, and display the value of its SampleProperty property in the output area.</span></span> <span data-ttu-id="f3b2c-170">出力は次のように表示されます。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-170">The output is shown here:</span></span>

``` syntax
"The answer is 42."
0
```

<span data-ttu-id="f3b2c-171">[Basics 2] ボタンをクリックして SampleProperty プロパティの値を増やし、新しい値を出力領域に表示します。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-171">Choose the Basics 2 button to increment the value of the SampleProperty property and to display the new value in the output area.</span></span> <span data-ttu-id="f3b2c-172">文字列や数値などのプリミティブ型は、パラメーターの型や戻り値の型として使用でき、マネージ コードと JavaScript の間で渡すことができます。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-172">Primitive types such as strings and numbers can be used as parameter types and return types, and can be passed between managed code and JavaScript.</span></span> <span data-ttu-id="f3b2c-173">JavaScript の数値は倍精度浮動小数点形式で保存されるため、.NET Framework の数値型に変換されます。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-173">Because numbers in JavaScript are stored in double-precision floating-point format, they are converted to .NET Framework numeric types.</span></span>

> <span data-ttu-id="f3b2c-174">**注:** 既定では、JavaScript コードでのみブレークポイントを設定することができます。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-174">**Note**By default, you can set breakpoints only in your JavaScript code.</span></span> <span data-ttu-id="f3b2c-175">Visual Basic または C# のコードをデバッグするときは、「C# および Visual Basic での Windows ランタイム コンポーネントの作成」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-175">To debug your Visual Basic or C# code, see Creating Windows Runtime Components in C# and Visual Basic.</span></span>

 

<span data-ttu-id="f3b2c-176">デバッグを停止してアプリを閉じるには、アプリから Visual Studio に切り替え、Shift キーを押しながら F5 キーを押します。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-176">To stop debugging and close your app, switch from the app to Visual Studio, and choose Shift+F5.</span></span>

## <a name="using-the-windows-runtime-from-javascript-and-managed-code"></a><span data-ttu-id="f3b2c-177">JavaScript とマネージ コードからの Windows ランタイムの使用</span><span class="sxs-lookup"><span data-stu-id="f3b2c-177">Using the Windows Runtime from JavaScript and managed code</span></span>


<span data-ttu-id="f3b2c-178">Windows ランタイムは、JavaScript またはマネージ コードから呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-178">The Windows Runtime can be called from either JavaScript or managed code.</span></span> <span data-ttu-id="f3b2c-179">Windows ランタイム オブジェクトはこの 2 つの間で受け渡すことができ、イベントはどちらの側からでも処理できます。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-179">Windows Runtime objects can be passed back and forth between the two, and events can be handled from either side.</span></span> <span data-ttu-id="f3b2c-180">ただし、JavaScript と .NET Framework では Windows ランタイムをサポートする方法が異なるため、この 2 つの環境での Windows ランタイム型の使用方法は細部が異なります。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-180">However, the ways you use Windows Runtime types in the two environments differ in some details, because JavaScript and the .NET Framework support the Windows Runtime differently.</span></span> <span data-ttu-id="f3b2c-181">次の例では、[Windows.Foundation.Collections.PropertySet](https://msdn.microsoft.com/library/windows/apps/windows.foundation.collections.propertyset.aspx) クラスを使用して、これらの違いを示します。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-181">The following example demonstrates these differences, using the [Windows.Foundation.Collections.PropertySet](https://msdn.microsoft.com/library/windows/apps/windows.foundation.collections.propertyset.aspx) class.</span></span> <span data-ttu-id="f3b2c-182">この例では、マネージ コードで PropertySet コレクションのインスタンスを作成し、コレクションの変更を追跡するイベント ハンドラーを登録します。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-182">In this example, you create an instance of the PropertySet collection in managed code and register an event handler to track changes in the collection.</span></span> <span data-ttu-id="f3b2c-183">次に、コレクションを取得し、独自のイベント ハンドラーを登録して、コレクションを使用する JavaScript コードを追加します。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-183">Then you add JavaScript code that gets the collection, registers its own event handler, and uses the collection.</span></span> <span data-ttu-id="f3b2c-184">最後に、マネージ コードからコレクションに変更を加え、マネージ例外を処理する JavaScript を示すメソッドを追加します。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-184">Finally, you add a method that makes changes to the collection from managed code and shows JavaScript handling a managed exception.</span></span>

> <span data-ttu-id="f3b2c-185">**重要な**、この例では、UI スレッドでイベントを発生させますです。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-185">**Important**In this example, the event is being fired on the UI thread.</span></span> <span data-ttu-id="f3b2c-186">非同期呼び出しなどでバックグラウンド スレッドからイベントを発生させる場合は、JavaScript がそのイベントを処理できるように、追加の作業が必要になります。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-186">If you fire the event from a background thread, for example in an async call, you will need to do some extra work in order for JavaScript to handle the event.</span></span> <span data-ttu-id="f3b2c-187">詳しくは、「[Windows ランタイム コンポーネントでのイベントの発生](raising-events-in-windows-runtime-components.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-187">For more information, see [Raising Events in Windows Runtime Components](raising-events-in-windows-runtime-components.md).</span></span>

 

<span data-ttu-id="f3b2c-188">SampleComponent プロジェクトで、PropertySetStats という名前の新しい **public sealed** クラス (Visual Basic では **Public NotInheritable** クラス) を追加します。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-188">In the SampleComponent project, add a new **public sealed** class (**Public NotInheritable** class in Visual Basic) named PropertySetStats.</span></span> <span data-ttu-id="f3b2c-189">このクラスは、PropertySet コレクションをラップし、MapChanged イベントを処理します。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-189">The class wraps a PropertySet collection and handles its MapChanged event.</span></span> <span data-ttu-id="f3b2c-190">イベント ハンドラーは発生した各種変更の数を追跡し、DisplayStats メソッドは HTML 形式のレポートを生成します。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-190">The event handler tracks the number of changes of each kind that occur, and the DisplayStats method produces a report that is formatted in HTML.</span></span> <span data-ttu-id="f3b2c-191">追加の **using** ステートメント (Visual Basic では **Imports** ステートメント) に注意してください。このステートメントで既存の **using** ステートメントを上書きするのではなく、このステートメントを既存の using ステートメントに追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-191">Notice the additional **using** statement (**Imports** statement in Visual Basic); be careful to add this to the existing **using** statements rather than overwriting them.</span></span>

> [!div class="tabbedCodeSnippets"]
> ```csharp
> using Windows.Foundation.Collections;
>
> namespace SampleComponent
> {
>     public sealed class PropertySetStats
>     {
>         private PropertySet _ps;
>         public PropertySetStats()
>         {
>             _ps = new PropertySet();
>             _ps.MapChanged += this.MapChangedHandler;
>         }
>
>         public PropertySet PropertySet { get { return _ps; } }
>
>         int[] counts = { 0, 0, 0, 0 };
>         private void MapChangedHandler(IObservableMap<string, object> sender,
>             IMapChangedEventArgs<string> args)
>         {
>             counts[(int)args.CollectionChange] += 1;
>         }
>
>         public string DisplayStats()
>         {
>             StringBuilder report = new StringBuilder("<br/>Number of changes:<ul>");
>             for (int i = 0; i < counts.Length; i++)
>             {
>                 report.Append("<li>" + (CollectionChange)i + ": " + counts[i] + "</li>");
>             }
>             return report.ToString() + "</ul>";
>         }
>     }
> }
> ```
> ```vb
> Imports System.Text
>
> Public NotInheritable Class PropertySetStats
>     Private _ps As PropertySet
>     Public Sub New()
>         _ps = New PropertySet()
>         AddHandler _ps.MapChanged, AddressOf Me.MapChangedHandler
>     End Sub
>
>     Public ReadOnly Property PropertySet As PropertySet
>         Get
>             Return _ps
>         End Get
>     End Property
>
>     Dim counts() As Integer = {0, 0, 0, 0}
>     Private Sub MapChangedHandler(ByVal sender As IObservableMap(Of String, Object),
>         ByVal args As IMapChangedEventArgs(Of String))
>
>         counts(CInt(args.CollectionChange)) += 1
>     End Sub
>
>     Public Function DisplayStats() As String
>         Dim report As New StringBuilder("<br/>Number of changes:<ul>")
>         For i As Integer = 0 To counts.Length - 1
>             report.Append("<li>" & CType(i, CollectionChange).ToString() &
>                           ": " & counts(i) & "</li>")
>         Next
>         Return report.ToString() & "</ul>"
>     End Function
> End Class
> ```

<span data-ttu-id="f3b2c-192">イベント ハンドラー (この場合は、PropertySet オブジェクト) のイベントのセンダーは、IObservableMap にキャストされる点を除けば、使い慣れた .NET Framework のイベントのパターンに依存して&lt;オブジェクト、文字列&gt;インターフェイス (IObservableMap (文字列のオブジェクト) でVisual Basic)、これは、Windows ランタイム インターフェイスのインスタンス化[IObservableMap&lt;K, V&gt;](https://msdn.microsoft.com/library/windows/apps/br226050.aspx)します。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-192">The event handler follows the familiar .NET Framework event pattern, except that the sender of the event (in this case, the PropertySet object) is cast to the IObservableMap&lt;string, object&gt; interface (IObservableMap(Of String, Object) in Visual Basic), which is an instantiation of the Windows Runtime interface [IObservableMap&lt;K, V&gt;](https://msdn.microsoft.com/library/windows/apps/br226050.aspx).</span></span> <span data-ttu-id="f3b2c-193">(必要に応じてその型に送信者をキャストにできます。)また、イベント引数は、オブジェクトではなくインターフェイスとして表示されます。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-193">(You can cast the sender to its type if necessary.) Also, the event arguments are presented as an interface rather than as an object.</span></span>

<span data-ttu-id="f3b2c-194">default.js ファイルで、次のように runtime1 関数を追加します。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-194">In the default.js file, add the Runtime1 function as shown.</span></span> <span data-ttu-id="f3b2c-195">このコードでは、PropertySetStats オブジェクトを作成し、PropertySet コレクションを取得します。また、独自のイベント ハンドラーである onMapChanged 関数を追加して、MapChanged イベントを処理します。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-195">This code creates a PropertySetStats object, gets its PropertySet collection, and adds its own event handler, the onMapChanged function, to handle the MapChanged event.</span></span> <span data-ttu-id="f3b2c-196">コレクションの変更後、runtime1 は DisplayStats メソッドを呼び出して、変更の種類の概要を表示します。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-196">After making changes to the collection, runtime1 calls the DisplayStats method to show a summary of change types.</span></span>

```javascript
var propertysetstats;

function runtime1() {
    document.getElementById('output').innerHTML = "";

    propertysetstats = new SampleComponent.PropertySetStats();
    var propertyset = propertysetstats.propertySet;

    propertyset.addEventListener("mapchanged", onMapChanged);

    propertyset.insert("FirstProperty", "First property value");
    propertyset.insert("SuperfluousProperty", "Unnecessary property value");
    propertyset.insert("AnotherProperty", "A property value");

    propertyset.insert("SuperfluousProperty", "Altered property value")
    propertyset.remove("SuperfluousProperty");

    document.getElementById('output').innerHTML +=
        propertysetstats.displayStats();
}

function onMapChanged(change) {
    var result
    switch (change.collectionChange) {
        case Windows.Foundation.Collections.CollectionChange.reset:
            result = "All properties cleared";
            break;
        case Windows.Foundation.Collections.CollectionChange.itemInserted:
            result = "Inserted " + change.key + ": '" +
                change.target.lookup(change.key) + "'";
            break;
        case Windows.Foundation.Collections.CollectionChange.itemRemoved:
            result = "Removed " + change.key;
            break;
        case Windows.Foundation.Collections.CollectionChange.itemChanged:
            result = "Changed " + change.key + " to '" +
                change.target.lookup(change.key) + "'";
            break;
        default:
            break;
     }

     document.getElementById('output').innerHTML +=
         "<br/>" + result;
}
```

<span data-ttu-id="f3b2c-197">JavaScript で Windows ランタイム イベントを処理する方法は、.NET Framework コードで処理する方法とは大きく異なります。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-197">The way you handle Windows Runtime events in JavaScript is very different from the way you handle them in .NET Framework code.</span></span> <span data-ttu-id="f3b2c-198">JavaScript イベント ハンドラーは引数を 1 つだけ受け取ります。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-198">The JavaScript event handler takes only one argument.</span></span> <span data-ttu-id="f3b2c-199">Visual Studio デバッガーでこのオブジェクトを表示した場合、最初のプロパティが送信元です。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-199">When you view this object in the Visual Studio debugger, the first property is the sender.</span></span> <span data-ttu-id="f3b2c-200">イベント引数インターフェイスのメンバーも、このオブジェクトに直接表示されます。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-200">The members of the event argument interface also appear directly on this object.</span></span>

<span data-ttu-id="f3b2c-201">アプリを実行するには、F5 キーを押します。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-201">To run the app, choose the F5 key.</span></span> <span data-ttu-id="f3b2c-202">クラスがシールされていない場合、"Exporting unsealed type 'SampleComponent.Example' is not currently supported.</span><span class="sxs-lookup"><span data-stu-id="f3b2c-202">If the class is not sealed, you get the error message, "Exporting unsealed type 'SampleComponent.Example' is not currently supported.</span></span> <span data-ttu-id="f3b2c-203">Please mark it as sealed." (unsealed 型 'SampleComponent.Example' のエクスポートは現在サポートされていません。sealed としてマークしてください。) というエラー メッセージが表示されます。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-203">Please mark it as sealed."</span></span>

<span data-ttu-id="f3b2c-204">**[Runtime 1]** ボタンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-204">Choose the **Runtime 1** button.</span></span> <span data-ttu-id="f3b2c-205">要素が追加または変更されると、イベント ハンドラーが変更を表示し、最後に DisplayStats メソッドが呼び出されて変更の数の概要が生成されます。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-205">The event handler displays changes as elements are added or changed, and at the end the DisplayStats method is called to produce a summary of counts.</span></span> <span data-ttu-id="f3b2c-206">デバッグを停止してアプリを閉じるには、Visual Studio に戻り、Shift キーを押しながら F5 キーを押します。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-206">To stop debugging and close the app, switch back to Visual Studio and choose Shift+F5.</span></span>

<span data-ttu-id="f3b2c-207">マネージ コードから PropertySet コレクションにさらに 2 つの項目を追加するには、次のコードを PropertySetStats クラスに追加します。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-207">To add two more items to the PropertySet collection from managed code, add the following code to the PropertySetStats class:</span></span>

> [!div class="tabbedCodeSnippets"]
> ```csharp
> public void AddMore()
> {
>     _ps.Add("NewProperty", "New property value");
>     _ps.Add("AnotherProperty", "A property value");
> }
> ```
> ```vb
> Public Sub AddMore()
>     _ps.Add("NewProperty", "New property value")
>     _ps.Add("AnotherProperty", "A property value")
> End Sub
> ```

<span data-ttu-id="f3b2c-208">このコードは、2 つの環境での Windows ランタイム型の使用方法のもう 1 つの違いを示しています。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-208">This code highlights another difference in the way you use Windows Runtime types in the two environments.</span></span> <span data-ttu-id="f3b2c-209">このコードを自分で入力すると、IntelliSense が JavaScript コードで使用した insert メソッドを表示しないことがわかります。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-209">If you type this code yourself, you'll notice that IntelliSense doesn't show the insert method you used in the JavaScript code.</span></span> <span data-ttu-id="f3b2c-210">代わりに、.NET Framework のコレクションで一般的に見られる Add メソッドが表示されます。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-210">Instead, it shows the Add method commonly seen on collections in the .NET Framework.</span></span> <span data-ttu-id="f3b2c-211">これは、一般的に使われる一部のコレクション インターフェイスは、Windows ランタイムと .NET Framework で名前が異なりますが、機能はほぼ同じであるためです。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-211">This is because some commonly used collection interfaces have different names but similar functionality in the Windows Runtime and the .NET Framework.</span></span> <span data-ttu-id="f3b2c-212">マネージ コードでこれらのインターフェイスを使用すると、.NET Framework の対応するインターフェイスとして表示されます。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-212">When you use these interfaces in managed code, they appear as their .NET Framework equivalents.</span></span> <span data-ttu-id="f3b2c-213">この点については、「[C# および Visual Basic での Windows ランタイム コンポーネントの作成](creating-windows-runtime-components-in-csharp-and-visual-basic.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-213">This is discussed in [Creating Windows Runtime Components in C# and Visual Basic](creating-windows-runtime-components-in-csharp-and-visual-basic.md).</span></span> <span data-ttu-id="f3b2c-214">JavaScript で同じインターフェイスを使用した場合、Windows ランタイムからの変更点は、メンバー名の先頭の大文字が小文字になることだけです。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-214">When you use the same interfaces in JavaScript, the only change from the Windows Runtime is that uppercase letters at the beginning of member names become lowercase.</span></span>

<span data-ttu-id="f3b2c-215">最後に、例外処理で AddMore メソッドを呼び出すには、runtime2 関数を default.js に追加します。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-215">Finally, to call the AddMore method with exception handling, add the runtime2 function to default.js.</span></span>

```javascript
function runtime2() {
   try {
      propertysetstats.addMore();
    }
   catch(ex) {
       document.getElementById('output').innerHTML +=
          "<br/><b>" + ex + "<br/>";
   }

   document.getElementById('output').innerHTML +=
       propertysetstats.displayStats();
}
```

<span data-ttu-id="f3b2c-216">前と同様に、イベント ハンドラーの登録コードを追加します。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-216">Add the event handler registration code the same way you did previously.</span></span>

```javascript
var runtimeButton1 = document.getElementById("runtimeButton1");
runtimeButton1.addEventListener("click", runtime1, false);
var runtimeButton2 = document.getElementById("runtimeButton2");
runtimeButton2.addEventListener("click", runtime2, false);
```

<span data-ttu-id="f3b2c-217">アプリを実行するには、F5 キーを押します。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-217">To run the app, choose the F5 key.</span></span> <span data-ttu-id="f3b2c-218">**[Runtime 1]**、**[Runtime 2]** の順にクリックします。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-218">Choose **Runtime 1** and then **Runtime 2**.</span></span> <span data-ttu-id="f3b2c-219">JavaScript イベント ハンドラーはコレクションの最初の変更を報告します。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-219">The JavaScript event handler reports the first change to the collection.</span></span> <span data-ttu-id="f3b2c-220">ただし、2 番目の変更には重複するキーがあります。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-220">The second change, however, has a duplicate key.</span></span> <span data-ttu-id="f3b2c-221">.NET Framework ディクショナリのユーザーは、Add メソッドが例外をスローすることを想定しており、実際にそのとおりになります。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-221">Users of .NET Framework dictionaries expect the Add method to throw an exception, and that is what happens.</span></span> <span data-ttu-id="f3b2c-222">JavaScript が .NET Framework の例外を処理します。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-222">JavaScript handles the .NET Framework exception.</span></span>

> <span data-ttu-id="f3b2c-223">**注:** JavaScript コードからの例外のメッセージを表示することはできません。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-223">**Note**You can't display the exception's message from JavaScript code.</span></span> <span data-ttu-id="f3b2c-224">メッセージ テキストはスタック トレースに置き換えられます。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-224">The message text is replaced by a stack trace.</span></span> <span data-ttu-id="f3b2c-225">詳しくは、「C# および Visual Basic での Windows ランタイム コンポーネントの作成」の「例外のスロー」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-225">For more information, see "Throwing exceptions" in Creating Windows Runtime Components in C# and Visual Basic.</span></span>

<span data-ttu-id="f3b2c-226">一方、JavaScript が重複するキーで insert メソッドを呼び出したときには、項目の値が変更されました。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-226">By contrast, when JavaScript called the insert method with a duplicate key, the value of the item was changed.</span></span> <span data-ttu-id="f3b2c-227">「[C# および Visual Basic での Windows ランタイム コンポーネントの作成](creating-windows-runtime-components-in-csharp-and-visual-basic.md)」に記載されているように、動作のこの違いは、JavaScript と .NET Framework で Windows ランタイムをサポートする方法が異なることに起因しています。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-227">This difference in behavior is due to the different ways that JavaScript and the .NET Framework support the Windows Runtime, as explained in [Creating Windows Runtime Components in C# and Visual Basic](creating-windows-runtime-components-in-csharp-and-visual-basic.md).</span></span>

## <a name="returning-managed-types-from-your-component"></a><span data-ttu-id="f3b2c-228">コンポーネントからマネージ型を返す</span><span class="sxs-lookup"><span data-stu-id="f3b2c-228">Returning managed types from your component</span></span>


<span data-ttu-id="f3b2c-229">前述のように、JavaScript コードと C# または Visual Basic のコード間で、ネイティブの Windows ランタイム型を自由に受け渡すことができます。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-229">As discussed previously, you can pass native Windows Runtime types back and forth freely between your JavaScript code and your C# or Visual Basic code.</span></span> <span data-ttu-id="f3b2c-230">ほとんどの場合、型名とメンバー名はどちらの場合も同じになります (JavaScript ではメンバー名が小文字で始まる点を除きます)。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-230">Most of the time, the type names and member names will be the same in both cases (except that the member names start with lowercase letters in JavaScript).</span></span> <span data-ttu-id="f3b2c-231">ただし、前のセクションでは、マネージ コードで PropertySet クラスのメンバーが異なっていました </span><span class="sxs-lookup"><span data-stu-id="f3b2c-231">However, in the preceding section, the PropertySet class appeared to have different members in managed code.</span></span> <span data-ttu-id="f3b2c-232">(たとえば、JavaScript では insert メソッドを呼び出し、.NET Framework コードでは Add メソッドを呼び出しました)。このセクションでは、これらの違いが JavaScript に渡される .NET Framework の型に与える影響について説明します。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-232">(For example, in JavaScript you called the insert method, and in the .NET Framework code you called the Add method.) This section explores the way those differences affect .NET Framework types passed to JavaScript.</span></span>

<span data-ttu-id="f3b2c-233">コンポーネントで作成した Windows ランタイム型または JavaScript からコンポーネントに渡された Windows ランタイム型を返すだけでなく、マネージ コードで作成されたマネージ型を、対応する Windows ランタイム型と同様に JavaScript に返すこともできます。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-233">In addition to returning Windows Runtime types that you created in your component or passed to your component from JavaScript, you can return a managed type, created in managed code, to JavaScript as if it were the corresponding Windows Runtime type.</span></span> <span data-ttu-id="f3b2c-234">ランタイム クラスの最初の簡単な例でも、メンバーのパラメーターと戻り値の型は、Visual Basic または C# のプリミティブ型 (.NET Framework の型) でした。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-234">Even in the first, simple example of a runtime class, the parameters and return types of the members were Visual Basic or C# primitive types, which are .NET Framework types.</span></span> <span data-ttu-id="f3b2c-235">コレクションでこれを示すために、Example クラスに次のコードを追加して、整数でインデックス付けされた文字列のジェネリック ディクショナリを返すメソッドを作成します。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-235">To demonstrate this for collections, add the following code to the Example class, to create a method that returns a generic dictionary of strings, indexed by integers:</span></span>

> [!div class="tabbedCodeSnippets"]
> ```csharp
> public static IDictionary<int, string> GetMapOfNames()
> {
>     Dictionary<int, string> retval = new Dictionary<int, string>();
>     retval.Add(1, "one");
>     retval.Add(2, "two");
>     retval.Add(3, "three");
>     retval.Add(42, "forty-two");
>     retval.Add(100, "one hundred");
>     return retval;
> }
> ```
> ```vb
> Public Shared Function GetMapOfNames() As IDictionary(Of Integer, String)
>     Dim retval As New Dictionary(Of Integer, String)
>     retval.Add(1, "one")
>     retval.Add(2, "two")
>     retval.Add(3, "three")
>     retval.Add(42, "forty-two")
>     retval.Add(100, "one hundred")
>     Return retval
> End Function
> ```

<span data-ttu-id="f3b2c-236">ディクショナリは、[Dictionary&lt;TKey, TValue&gt;](https://msdn.microsoft.com/library/xfhwa508.aspx) によって実装され、Windows ランタイム インターフェイスにマップされるインターフェイスとして返される必要があることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-236">Notice that the dictionary must be returned as an interface that is implemented by [Dictionary&lt;TKey, TValue&gt;](https://msdn.microsoft.com/library/xfhwa508.aspx), and that maps to a Windows Runtime interface.</span></span> <span data-ttu-id="f3b2c-237">この例では、インターフェイスは IDictionary&lt;int, string&gt; (Visual Basic では IDictionary(Of Integer, String)) です。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-237">In this case, the interface is IDictionary&lt;int, string&gt; (IDictionary(Of Integer, String) in Visual Basic).</span></span> <span data-ttu-id="f3b2c-238">Windows ランタイム型の IMap&lt;int, string&gt; がマネージ コードに渡されると、IDictionary&lt;int, string&gt; として表示され、マネージ型が JavaScript に渡されると、この逆になります。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-238">When the Windows Runtime type IMap&lt;int, string&gt; is passed to managed code, it appears as IDictionary&lt;int, string&gt;, and the reverse is true when the managed type is passed to JavaScript.</span></span>

<span data-ttu-id="f3b2c-239">**重要な**マネージ型が複数のインターフェイスを実装する場合は、JavaScript はリストの最初に表示されるインターフェイスです。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-239">**Important**When a managed type implements multiple interfaces, JavaScript uses the interface that appears first in the list.</span></span> <span data-ttu-id="f3b2c-240">たとえば、Dictionary&lt;int, string&gt; を JavaScript コードに返した場合、戻り値の型としてどのインターフェイスを指定しても、IDictionary&lt;int, string&gt; として表示されます。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-240">For example, if you return Dictionary&lt;int, string&gt; to JavaScript code, it appears as IDictionary&lt;int, string&gt; no matter which interface you specify as the return type.</span></span> <span data-ttu-id="f3b2c-241">これは、後のインターフェイスで表示されるメンバーが最初のインターフェイスに含まれていない場合、そのメンバーは JavaScript に認識されないことを意味します。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-241">This means that if the first interface doesn't include a member that appears on later interfaces, that member isn't visible to JavaScript.</span></span>

 

<span data-ttu-id="f3b2c-242">新しいメソッドをテストしてディクショナリを使用するには、returns1 関数と returns2 関数を default.js に追加します。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-242">To test the new method and use the dictionary, add the returns1 and returns2 functions to default.js:</span></span>

```javascript
var names;

function returns1() {
    names = SampleComponent.Example.getMapOfNames();
    document.getElementById('output').innerHTML = showMap(names);
}

var ct = 7;

function returns2() {
    if (!names.hasKey(17)) {
        names.insert(43, "forty-three");
        names.insert(17, "seventeen");
    }
    else {
        var err = names.insert("7", ct++);
        names.insert("forty", "forty");
    }
    document.getElementById('output').innerHTML = showMap(names);
}

function showMap(map) {
    var item = map.first();
    var retval = "<ul>";

    for (var i = 0, len = map.size; i < len; i++) {
        retval += "<li>" + item.current.key + ": " + item.current.value + "</li>";
        item.moveNext();
    }
    return retval + "</ul>";
}
```

<span data-ttu-id="f3b2c-243">イベント登録コードを、他のイベント登録コードと同じ then ブロックに追加します。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-243">Add the event registration code to the same then block as the other event registration code:</span></span>

```javascript
var returnsButton1 = document.getElementById("returnsButton1");
returnsButton1.addEventListener("click", returns1, false);
var returnsButton2 = document.getElementById("returnsButton2");
returnsButton2.addEventListener("click", returns2, false);
```

<span data-ttu-id="f3b2c-244">この JavaScript コードには、注目すべき点がいくつかあります。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-244">There are a few interesting things to observe about this JavaScript code.</span></span> <span data-ttu-id="f3b2c-245">まず、ディクショナリの内容を HTML で表示する showMap 関数が含まれています。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-245">First of all, it includes a showMap function to display the contents of the dictionary in HTML.</span></span> <span data-ttu-id="f3b2c-246">showMap のコードのイテレーション パターンに注目してください。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-246">In the code for showMap, notice the iteration pattern.</span></span> <span data-ttu-id="f3b2c-247">.NET Framework では、ジェネリック IDictionary インターフェイスに First メソッドはありません。また、サイズは Size メソッドではなく Count プロパティによって返されます。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-247">In the .NET Framework, there's no First method on the generic IDictionary interface, and the size is returned by a Count property rather than by a Size method.</span></span> <span data-ttu-id="f3b2c-248">JavaScript に対して、IDictionary&lt;int, string&gt; は Windows ランタイム型の IMap&lt;int, string&gt; として表示されます </span><span class="sxs-lookup"><span data-stu-id="f3b2c-248">To JavaScript, IDictionary&lt;int, string&gt; appears to be the Windows Runtime type IMap&lt;int, string&gt;.</span></span> <span data-ttu-id="f3b2c-249">([IMap&lt;K,V&gt;](https://msdn.microsoft.com/library/windows/apps/br226042.aspx) インターフェイスをご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-249">(See the [IMap&lt;K,V&gt;](https://msdn.microsoft.com/library/windows/apps/br226042.aspx) interface.)</span></span>

<span data-ttu-id="f3b2c-250">前の例のように、returns2 関数では、JavaScript が Insert メソッド (JavaScript では insert) を呼び出して項目をディクショナリに追加します。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-250">In the returns2 function, as in earlier examples, JavaScript calls the Insert method (insert in JavaScript) to add items to the dictionary.</span></span>

<span data-ttu-id="f3b2c-251">アプリを実行するには、F5 キーを押します。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-251">To run the app, choose the F5 key.</span></span> <span data-ttu-id="f3b2c-252">ディクショナリの初期内容を作成して表示するには、**[Returns 1]** ボタンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-252">To create and display the initial contents of the dictionary, choose the **Returns 1** button.</span></span> <span data-ttu-id="f3b2c-253">ディクショナリにさらに 2 つのエントリを追加するには、**[Returns 2]** ボタンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-253">To add two more entries to the dictionary, choose the **Returns 2** button.</span></span> <span data-ttu-id="f3b2c-254">Dictionary&lt;TKey, TValue&gt; から想定されるように、エントリは挿入順に表示されます。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-254">Notice that the entries are displayed in order of insertion, as you would expect from Dictionary&lt;TKey, TValue&gt;.</span></span> <span data-ttu-id="f3b2c-255">エントリを並べ替える場合は、GetMapOfNames から SortedDictionary&lt;int, string&gt; を返すことができます </span><span class="sxs-lookup"><span data-stu-id="f3b2c-255">If you want them sorted, you can return a SortedDictionary&lt;int, string&gt; from GetMapOfNames.</span></span> <span data-ttu-id="f3b2c-256">(前の例で使われている PropertySet クラスの内部構成は、Dictionary&lt;TKey, TValue&gt; とは異なります)。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-256">(The PropertySet class used in earlier examples has a different internal organization from Dictionary&lt;TKey, TValue&gt;.)</span></span>

<span data-ttu-id="f3b2c-257">JavaScript は厳密に型指定された言語ではないため、厳密に型指定されたジェネリック コレクションを使うと、予期しない結果になる場合があります。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-257">Of course, JavaScript is not a strongly typed language, so using strongly typed generic collections can lead to some surprising results.</span></span> <span data-ttu-id="f3b2c-258">**[Returns 2]** ボタンをもう一度クリックします。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-258">Choose the **Returns 2** button again.</span></span> <span data-ttu-id="f3b2c-259">JavaScript は "7" を数値 7 に強制的に変換し、ct に格納された数値 7 を文字列に変換します。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-259">JavaScript obligingly coerces the "7" to a numeric 7, and the numeric 7 that's stored in ct to a string.</span></span> <span data-ttu-id="f3b2c-260">さらに、この文字列 "forty" を強制的にゼロに変換します。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-260">And it coerces the string "forty" to zero.</span></span> <span data-ttu-id="f3b2c-261">しかし、これは始まりにすぎません。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-261">But that's only the beginning.</span></span> <span data-ttu-id="f3b2c-262">**[Returns 2]** ボタンをさらに数回クリックします。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-262">Choose the **Returns 2** button a few more times.</span></span> <span data-ttu-id="f3b2c-263">マネージ コードでは、値が正しい型にキャストされていても、Add メソッドは重複キーの例外を生成します。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-263">In managed code, the Add method would generate duplicate key exceptions, even if the values were cast to the correct types.</span></span> <span data-ttu-id="f3b2c-264">これに対して、Insert メソッドは既存のキーに関連付けられている値を更新し、新しいキーがディクショナリに追加されたかどうかを示すブール値を返します。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-264">In contrast, the Insert method updates the value associated with an existing key and returns a Boolean value that indicates whether a new key was added to the dictionary.</span></span> <span data-ttu-id="f3b2c-265">キー 7 に関連付けられている値が変わり続けるのはこのためです。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-265">This is why the value associated with the key 7 keeps changing.</span></span>

<span data-ttu-id="f3b2c-266">予期しない動作がもう 1 つあります。未割り当ての JavaScript 変数を文字列引数として渡すと、"undefined" という文字列が返されます。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-266">Another unexpected behavior: If you pass an unassigned JavaScript variable as a string argument, what you get is the string "undefined".</span></span> <span data-ttu-id="f3b2c-267">つまり、.NET Framework のコレクション型を JavaScript コードに渡すときには注意が必要です。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-267">In short, be careful when you pass .NET Framework collection types to your JavaScript code.</span></span>

> <span data-ttu-id="f3b2c-268">**注:** 大量のテキストを連結する場合は、ためより効率的に、コードを .NET Framework メソッドに移動し、StringBuilder クラスを使って、showMap 関数に示すようにします。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-268">**Note**If you have large quantities of text to concatenate, you can do it more efficiently by moving the code into a .NET Framework method and using the StringBuilder class, as shown in the showMap function.</span></span>

<span data-ttu-id="f3b2c-269">Windows ランタイム コンポーネントから独自のジェネリック型を公開することはできませんが、次のようなコードを使って Windows ランタイム クラスの .NET Framework ジェネリック コレクションを返すことができます。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-269">Although you can't expose your own generic types from a Windows Runtime component, you can return .NET Framework generic collections for Windows Runtime classes by using code such as the following:</span></span>

> [!div class="tabbedCodeSnippets"]
> ```csharp
> public static object GetListOfThis(object obj)
> {
>     Type target = obj.GetType();
>     return Activator.CreateInstance(typeof(List<>).MakeGenericType(target));
> }
> ```
> ```vb
> Public Shared Function GetListOfThis(obj As Object) As Object
>     Dim target As Type = obj.GetType()
>     Return Activator.CreateInstance(GetType(List(Of )).MakeGenericType(target))
> End Function
> ```

<span data-ttu-id="f3b2c-270">List&lt;T&gt; は IList&lt;T&gt; を実装しており、JavaScript では Windows ランタイム型の IVector&lt;T&gt; として表示されます。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-270">List&lt;T&gt; implements IList&lt;T&gt;, which appears as the Windows Runtime type IVector&lt;T&gt; in JavaScript.</span></span>

## <a name="declaring-events"></a><span data-ttu-id="f3b2c-271">イベントの宣言</span><span class="sxs-lookup"><span data-stu-id="f3b2c-271">Declaring events</span></span>


<span data-ttu-id="f3b2c-272">イベントを宣言するには、.NET Framework の標準のイベント パターン、または Windows ランタイムで使用される他のパターンを使うことができます。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-272">You can declare events by using the standard .NET Framework event pattern or other patterns used by the Windows Runtime.</span></span> <span data-ttu-id="f3b2c-273">.NET Framework は、System.EventHandler&lt;TEventArgs&gt; デリゲートと Windows ランタイムの EventHandler&lt;T&gt; デリゲート間の等価性をサポートするので、.NET Framework の標準パターンを実装するときは、EventHandler&lt;TEventArgs&gt; を使うと便利です。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-273">The .NET Framework supports equivalence between the System.EventHandler&lt;TEventArgs&gt; delegate and the Windows Runtime EventHandler&lt;T&gt; delegate, so using EventHandler&lt;TEventArgs&gt; is a good way to implement the standard .NET Framework pattern.</span></span> <span data-ttu-id="f3b2c-274">この動作を確認するために、SampleComponent プロジェクトにクラスの次の組み合わせを追加します。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-274">To see how this works, add the following pair of classes to the SampleComponent project:</span></span>

> [!div class="tabbedCodeSnippets"]
> ```csharp
> namespace SampleComponent
> {
>     public sealed class Eventful
>     {
>         public event EventHandler<TestEventArgs> Test;
>         public void OnTest(string msg, long number)
>         {
>             EventHandler<TestEventArgs> temp = Test;
>             if (temp != null)
>             {
>                 temp(this, new TestEventArgs()
>                 {
>                     Value1 = msg,
>                     Value2 = number
>                 });
>             }
>         }
>     }
>
>     public sealed class TestEventArgs
>     {
>         public string Value1 { get; set; }
>         public long Value2 { get; set; }
>     }
> }
> ```
> ```vb
> Public NotInheritable Class Eventful
>     Public Event Test As EventHandler(Of TestEventArgs)
>     Public Sub OnTest(ByVal msg As String, ByVal number As Long)
>         RaiseEvent Test(Me, New TestEventArgs() With {
>                             .Value1 = msg,
>                             .Value2 = number
>                             })
>     End Sub
> End Class
>
> Public NotInheritable Class TestEventArgs
>     Public Property Value1 As String
>     Public Property Value2 As Long
> End Class
> ```

<span data-ttu-id="f3b2c-275">Windows ランタイムでイベントを公開すると、イベント引数クラスは System.Object から継承します。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-275">When you expose an event in the Windows Runtime, the event argument class inherits from System.Object.</span></span> <span data-ttu-id="f3b2c-276">EventArgs は Windows ランタイム型ではないため、.NET Framework の場合と同様に、System.EventArgs からは継承しません。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-276">It doesn't inherit from System.EventArgs, as it would in the .NET Framework, because EventArgs is not a Windows Runtime type.</span></span>

<span data-ttu-id="f3b2c-277">イベントのカスタム イベント アクセサー (Visual Basic では **Custom** キーワード) を宣言する場合は、Windows ランタイムのイベント パターンを使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-277">If you declare custom event accessors for your event (**Custom** keyword in Visual Basic), you must use the Windows Runtime event pattern.</span></span> <span data-ttu-id="f3b2c-278">「[Windows ランタイム コンポーネントのカスタム イベントおよびイベント アクセサー](custom-events-and-event-accessors-in-windows-runtime-components.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-278">See [Custom events and event accessors in Windows Runtime Components](custom-events-and-event-accessors-in-windows-runtime-components.md).</span></span>

<span data-ttu-id="f3b2c-279">Test イベントを処理するには、events1 関数を default.js に追加します。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-279">To handle the Test event, add the events1 function to default.js.</span></span> <span data-ttu-id="f3b2c-280">events1 関数は Test イベントのイベント ハンドラー関数を作成し、OnTest メソッドを即座に呼び出してイベントを発生させます。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-280">The events1 function creates an event handler function for the Test event, and immediately invokes the OnTest method to raise the event.</span></span> <span data-ttu-id="f3b2c-281">イベント ハンドラーの本体にブレークポイントを配置すると、単一のパラメーターに渡されるオブジェクトにソース オブジェクトと TestEventArgs の両方のメンバーが含まれていることを確認できます。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-281">If you place a breakpoint in the body of the event handler, you can see that the object passed to the single parameter includes the source object and both members of TestEventArgs.</span></span>

```javascript
var ev;

function events1() {
   ev = new SampleComponent.Eventful();
   ev.addEventListener("test", function (e) {
       document.getElementById('output').innerHTML = e.value1;
       document.getElementById('output').innerHTML += "<br/>" + e.value2;
   });
   ev.onTest("Number of feet in a mile:", 5280);
}
```

<span data-ttu-id="f3b2c-282">イベント登録コードを、他のイベント登録コードと同じ then ブロックに追加します。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-282">Add the event registration code to the same then block as the other event registration code:</span></span>

```javascript
var events1Button = document.getElementById("events1Button");
events1Button.addEventListener("click", events1, false);
```

## <a name="exposing-asynchronous-operations"></a><span data-ttu-id="f3b2c-283">非同期操作の公開</span><span class="sxs-lookup"><span data-stu-id="f3b2c-283">Exposing asynchronous operations</span></span>


<span data-ttu-id="f3b2c-284">.NET Framework には、Task クラスとジェネリック [Task&lt;TResult&gt;](https://msdn.microsoft.com/library/dd321424.aspx) クラスに基づく、非同期処理と並列処理のための豊富なツール セットがあります。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-284">The .NET Framework has a rich set of tools for asynchronous processing and parallel processing, based on the Task and generic [Task&lt;TResult&gt;](https://msdn.microsoft.com/library/dd321424.aspx) classes.</span></span> <span data-ttu-id="f3b2c-285">Windows ランタイム コンポーネントでタスク ベースの非同期処理を公開するには、[IAsyncAction](https://msdn.microsoft.com/library/br205781.aspx)、[IAsyncActionWithProgress&lt;TProgress&gt;](https://msdn.microsoft.com/library/br205784.aspx)、[IAsyncOperation&lt;TResult&gt;](https://msdn.microsoft.com/library/br205802.aspx)、[IAsyncOperationWithProgress&lt;TResult, TProgress&gt;](https://msdn.microsoft.com/library/br205807.aspx) の各 Windows ランタイム インターフェイスを使います </span><span class="sxs-lookup"><span data-stu-id="f3b2c-285">To expose task-based asynchronous processing in a Windows Runtime component, use the Windows Runtime interfaces [IAsyncAction](https://msdn.microsoft.com/library/br205781.aspx), [IAsyncActionWithProgress&lt;TProgress&gt;](https://msdn.microsoft.com/library/br205784.aspx), [IAsyncOperation&lt;TResult&gt;](https://msdn.microsoft.com/library/br205802.aspx), and [IAsyncOperationWithProgress&lt;TResult, TProgress&gt;](https://msdn.microsoft.com/library/br205807.aspx).</span></span> <span data-ttu-id="f3b2c-286">(Windows ランタイムでは、操作は結果を返しますが、アクションは結果を返しません)。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-286">(In the Windows Runtime, operations return results, but actions do not.)</span></span>

<span data-ttu-id="f3b2c-287">このセクションでは、進行状況を報告し、結果を返す取り消し可能な非同期操作を示します。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-287">This section demonstrates a cancelable asynchronous operation that reports progress and returns results.</span></span> <span data-ttu-id="f3b2c-288">GetPrimesInRangeAsync メソッドは、[AsyncInfo](https://msdn.microsoft.com/library/system.runtime.interopservices.windowsruntime.asyncinfo.aspx) クラスを使用してタスクを生成し、取り消し機能と進行状況レポート機能を WinJS.Promise オブジェクトに関連付けます。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-288">The GetPrimesInRangeAsync method uses the [AsyncInfo](https://msdn.microsoft.com/library/system.runtime.interopservices.windowsruntime.asyncinfo.aspx) class to generate a task and to connect its cancellation and progress-reporting features to a WinJS.Promise object.</span></span> <span data-ttu-id="f3b2c-289">まず、GetPrimesInRangeAsync メソッドをサンプル クラスに追加します。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-289">Begin by adding the GetPrimesInRangeAsync method to the example class:</span></span>

> [!div class="tabbedCodeSnippets"]
> ```csharp
> using System.Runtime.InteropServices.WindowsRuntime;
> using Windows.Foundation;
>
> public static IAsyncOperationWithProgress<IList<long>, double>
> GetPrimesInRangeAsync(long start, long count)
> {
>     if (start < 2 || count < 1) throw new ArgumentException();
>
>     return AsyncInfo.Run<IList<long>, double>((token, progress) =>
>
>         Task.Run<IList<long>>(() =>
>         {
>             List<long> primes = new List<long>();
>             double onePercent = count / 100;
>             long ctProgress = 0;
>             double nextProgress = onePercent;
>
>             for (long candidate = start; candidate < start + count; candidate++)
>             {
>                 ctProgress += 1;
>                 if (ctProgress >= nextProgress)
>                 {
>                     progress.Report(ctProgress / onePercent);
>                     nextProgress += onePercent;
>                 }
>                 bool isPrime = true;
>                 for (long i = 2, limit = (long)Math.Sqrt(candidate); i <= limit; i++)
>                 {
>                     if (candidate % i == 0)
>                     {
>                         isPrime = false;
>                         break;
>                     }
>                 }
>                 if (isPrime) primes.Add(candidate);
>
>                 token.ThrowIfCancellationRequested();
>             }
>             progress.Report(100.0);
>             return primes;
>         }, token)
>     );
> }
> ```
> ```vb
> Imports System.Runtime.InteropServices.WindowsRuntime
>
> Public Shared Function GetPrimesInRangeAsync(ByVal start As Long, ByVal count As Long)
> As IAsyncOperationWithProgress(Of IList(Of Long), Double)
>
>     If (start < 2 Or count < 1) Then Throw New ArgumentException()
>
>     Return AsyncInfo.Run(Of IList(Of Long), Double)( _
>         Function(token, prog)
>             Return Task.Run(Of IList(Of Long))( _
>                 Function()
>                     Dim primes As New List(Of Long)
>                     Dim onePercent As Long = count / 100
>                     Dim ctProgress As Long = 0
>                     Dim nextProgress As Long = onePercent
>
>                     For candidate As Long = start To start + count - 1
>                         ctProgress += 1
>
>                         If ctProgress >= nextProgress Then
>                             prog.Report(ctProgress / onePercent)
>                             nextProgress += onePercent
>                         End If
>
>                         Dim isPrime As Boolean = True
>                         For i As Long = 2 To CLng(Math.Sqrt(candidate))
>                             If (candidate Mod i) = 0 Then
>                                 isPrime = False
>                                 Exit For
>                             End If
>                         Next
>
>                         If isPrime Then primes.Add(candidate)
>
>                         token.ThrowIfCancellationRequested()
>                     Next
>                     prog.Report(100.0)
>                     Return primes
>                 End Function, token)
>         End Function)
> End Function
> ```

<span data-ttu-id="f3b2c-290">GetPrimesInRangeAsync は非常にシンプルな素数ファインダーであり、これは仕様です。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-290">GetPrimesInRangeAsync is a very simple prime number finder, and that's by design.</span></span> <span data-ttu-id="f3b2c-291">ここでは非同期操作の実装に重点を置いているので、シンプルであることが重要であり、キャンセルを示すときに低速の実装が利点となります。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-291">The focus here is on implementing an asynchronous operation, so simplicity is important, and a slow implementation is an advantage when we're demonstrating cancellation.</span></span> <span data-ttu-id="f3b2c-292">GetPrimesInRangeAsync はブルート フォース方式で素数を見つけます。つまり、素数だけを使うのではなく、候補をその平方根以下のすべての整数で除算します。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-292">GetPrimesInRangeAsync finds primes by brute force: It divides a candidate by all the integers that are less than or equal to its square root, rather than using only the prime numbers.</span></span> <span data-ttu-id="f3b2c-293">このコードのステップ実行は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-293">Stepping through this code:</span></span>

-   <span data-ttu-id="f3b2c-294">非同期操作を開始する前に、パラメーターの検証や無効な入力に対する例外のスローなどのハウスキーピング アクティビティを実行します。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-294">Before starting an asynchronous operation, perform housekeeping activities such as validating parameters and throwing exceptions for invalid input.</span></span>
-   <span data-ttu-id="f3b2c-295">この実装で重要になるのは、[AsyncInfo.Run&lt;TResult, TProgress&gt;(Func&lt;CancellationToken, IProgress&lt;TProgress&gt;, Task&lt;TResult&gt;](https://msdn.microsoft.com/library/hh779740.aspx)&gt;) メソッドと、このメソッドの唯一のパラメーターであるデリゲートです。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-295">The key to this implementation is the [AsyncInfo.Run&lt;TResult, TProgress&gt;(Func&lt;CancellationToken, IProgress&lt;TProgress&gt;, Task&lt;TResult&gt;](https://msdn.microsoft.com/library/hh779740.aspx)&gt;) method, and the delegate that is the method's only parameter.</span></span> <span data-ttu-id="f3b2c-296">デリゲートはキャンセル トークンと進行状況を報告するためのインターフェイスを受け取り、それらのパラメーターを使う開始タスクを返す必要があります。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-296">The delegate must accept a cancellation token and an interface for reporting progress, and must return a started task that uses those parameters.</span></span> <span data-ttu-id="f3b2c-297">JavaScript が GetPrimesInRangeAsync メソッドを呼び出すと、次の手順が発生します (ここで示す順序とは限りません)。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-297">When JavaScript calls the GetPrimesInRangeAsync method, the following steps occur (not necessarily in the order given here):</span></span>

    -   <span data-ttu-id="f3b2c-298">[WinJS.Promise](https://msdn.microsoft.com/library/windows/apps/br211867.aspx) オブジェクトは、返された結果の処理、キャンセルへの対応、進行状況レポートの処理を行う関数を提供します。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-298">The [WinJS.Promise](https://msdn.microsoft.com/library/windows/apps/br211867.aspx) object supplies functions to process the returned results, react to cancellation, and handle progress reports.</span></span>
    -   <span data-ttu-id="f3b2c-299">AsyncInfo.Run メソッドは、キャンセル ソースと、IProgress&lt;T&gt; インターフェイスを実装するオブジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-299">The AsyncInfo.Run method creates a cancellation source and an object that implements the IProgress&lt;T&gt; interface.</span></span> <span data-ttu-id="f3b2c-300">デリゲートに対して、キャンセル ソースからの [CancellationToken](https://msdn.microsoft.com/library/system.threading.cancellationtoken.aspx) トークンと、[IProgress&lt;T&gt;](https://msdn.microsoft.com/library/hh138298.aspx) インターフェイスの両方を渡します。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-300">To the delegate, it passes both a [CancellationToken](https://msdn.microsoft.com/library/system.threading.cancellationtoken.aspx) token from the cancellation source, and the [IProgress&lt;T&gt;](https://msdn.microsoft.com/library/hh138298.aspx) interface.</span></span>

        > <span data-ttu-id="f3b2c-301">**注:** Promise オブジェクトが取り消しに対応する関数を提供しないかどうか、AsyncInfo.Run は引き続き、取り消し可能なトークンを渡しおよび取り消しが発生します。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-301">**Note**If the Promise object doesn't supply a function to react to cancellation, AsyncInfo.Run still passes a cancelable token, and cancellation can still occur.</span></span> <span data-ttu-id="f3b2c-302">Promise オブジェクトが進行状況の更新を処理する関数を提供しない場合、AsyncInfo.Run は IProgress&lt;T&gt; を実装するオブジェクトを引き続き提供しますが、レポートは無視されます。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-302">If the Promise object doesn't supply a function to handle progress updates, AsyncInfo.Run still supplies an object that implements IProgress&lt;T&gt;, but its reports are ignored.</span></span>

    -   <span data-ttu-id="f3b2c-303">デリゲートは [Task.Run&lt;TResult&gt;(Func&lt;TResult&gt;, CancellationToken](https://msdn.microsoft.com/library/hh160376.aspx)) メソッドを使って、トークンと進行状況インターフェイスを使う開始タスクを作成します。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-303">The delegate uses the [Task.Run&lt;TResult&gt;(Func&lt;TResult&gt;, CancellationToken](https://msdn.microsoft.com/library/hh160376.aspx)) method to create a started task that uses the token and the progress interface.</span></span> <span data-ttu-id="f3b2c-304">開始タスクのデリゲートは、目的の結果を計算するラムダ関数によって提供されます。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-304">The delegate for the started task is provided by a lambda function that computes the desired result.</span></span> <span data-ttu-id="f3b2c-305">この詳細については後述します。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-305">More about that in a moment.</span></span>
    -   <span data-ttu-id="f3b2c-306">AsyncInfo.Run メソッドは、[IAsyncOperationWithProgress&lt;TResult, TProgress&gt;](https://msdn.microsoft.com/library/windows/apps/br206594.aspx) インターフェイスを実装するオブジェクトを作成し、Windows ランタイムのキャンセル メカニズムをトークン ソースに関連付け、Promise オブジェクトの進行状況レポート関数を IProgress&lt;T&gt; インターフェイスに関連付けます。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-306">The AsyncInfo.Run method creates an object that implements the [IAsyncOperationWithProgress&lt;TResult, TProgress&gt;](https://msdn.microsoft.com/library/windows/apps/br206594.aspx) interface, connects the Windows Runtime cancellation mechanism with the token source, and connects the Promise object's progress-reporting function with the IProgress&lt;T&gt; interface.</span></span>
    -   <span data-ttu-id="f3b2c-307">IAsyncOperationWithProgress&lt;TResult, TProgress&gt; インターフェイスが JavaScript に返されます。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-307">The IAsyncOperationWithProgress&lt;TResult, TProgress&gt; interface is returned to JavaScript.</span></span>

-   <span data-ttu-id="f3b2c-308">開始タスクで表されるラムダ関数は引数を受け取りません。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-308">The lambda function that is represented by the started task doesn't take any arguments.</span></span> <span data-ttu-id="f3b2c-309">ラムダ関数であるため、トークンと IProgress インターフェイスにアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-309">Because it's a lambda function, it has access to the token and the IProgress interface.</span></span> <span data-ttu-id="f3b2c-310">候補の数値が評価されるたびに、ラムダ関数は以下を実行します。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-310">Each time a candidate number is evaluated, the lambda function:</span></span>

    -   <span data-ttu-id="f3b2c-311">進行状況の次のパーセント ポイントに到達したかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-311">Checks to see whether the next percentage point of progress has been reached.</span></span> <span data-ttu-id="f3b2c-312">到達した場合、ラムダ関数は IProgress&lt;T&gt;.Report メソッドを呼び出し、Promise オブジェクトが進行状況を報告するために指定した関数にパーセンテージが渡されます。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-312">If it has, the lambda function calls the IProgress&lt;T&gt;.Report method, and the percentage is passed through to the function that the Promise object specified for reporting progress.</span></span>
    -   <span data-ttu-id="f3b2c-313">操作が取り消された場合は、キャンセル トークンを使って例外をスローします。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-313">Uses the cancellation token to throw an exception if the operation has been canceled.</span></span> <span data-ttu-id="f3b2c-314">[IAsyncInfo.Cancel](https://msdn.microsoft.com/library/windows/apps/windows.foundation.iasyncinfo.cancel.aspx) メソッド (IAsyncOperationWithProgress&lt;TResult, TProgress&gt; インターフェイスが継承するメソッド) が呼び出された場合、AsyncInfo.Run メソッドが設定した関連付けにより、キャンセル トークンに確実に通知されます。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-314">If the [IAsyncInfo.Cancel](https://msdn.microsoft.com/library/windows/apps/windows.foundation.iasyncinfo.cancel.aspx) method (which the IAsyncOperationWithProgress&lt;TResult, TProgress&gt; interface inherits) has been called, the connection that the AsyncInfo.Run method set up ensures that the cancellation token is notified.</span></span>
-   <span data-ttu-id="f3b2c-315">ラムダ関数が素数のリストを返すと、WinJS.Promise オブジェクトが結果を処理するために指定した関数にこのリストが渡されます。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-315">When the lambda function returns the list of prime numbers, the list is passed to the function that the WinJS.Promise object specified for processing the results.</span></span>

<span data-ttu-id="f3b2c-316">JavaScript Promise を作成し、キャンセル メカニズムを設定するには、asyncRun 関数と asyncCancel 関数を default.js に追加します。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-316">To create the JavaScript promise and set up the cancellation mechanism, add the asyncRun and asyncCancel functions to default.js.</span></span>

```javascript
var resultAsync;
function asyncRun() {
    document.getElementById('output').innerHTML = "Retrieving prime numbers.";
    btnAsync.disabled = "disabled";
    btnCancel.disabled = "";

    resultAsync = SampleComponent.Example.getPrimesInRangeAsync(10000000000001, 2500).then(
        function (primes) {
            for (i = 0; i < primes.length; i++)
                document.getElementById('output').innerHTML += " " + primes[i];

            btnCancel.disabled = "disabled";
            btnAsync.disabled = "";
        },
        function () {
            document.getElementById('output').innerHTML += " -- getPrimesInRangeAsync was canceled. -- ";

            btnCancel.disabled = "disabled";
            btnAsync.disabled = "";
        },
        function (prog) {
            document.getElementById('primeProg').value = prog;
        }
    );
}

function asyncCancel() {    
    resultAsync.cancel();
}
```

<span data-ttu-id="f3b2c-317">これまでと同様に、イベント登録コードを忘れないでください。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-317">Don't forget the event registration code the same as you did previously.</span></span>

```javascript
var btnAsync = document.getElementById("btnAsync");
btnAsync.addEventListener("click", asyncRun, false);
var btnCancel = document.getElementById("btnCancel");
btnCancel.addEventListener("click", asyncCancel, false);
```

<span data-ttu-id="f3b2c-318">非同期の GetPrimesInRangeAsync メソッドを呼び出すことで、asyncRun 関数は WinJS.Promise オブジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-318">By calling the asynchronous GetPrimesInRangeAsync method, the asyncRun function creates a WinJS.Promise object.</span></span> <span data-ttu-id="f3b2c-319">このオブジェクトの then メソッドは、返される結果の処理、エラーへの対応 (キャンセルを含む)、進行状況レポートの処理を行う 3 つの関数を受け取ります。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-319">The object's then method takes three functions that process the returned results, react to errors (including cancellation), and handle progress reports.</span></span> <span data-ttu-id="f3b2c-320">この例では、返された結果が出力領域に表示されます。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-320">In this example, the returned results are printed in the output area.</span></span> <span data-ttu-id="f3b2c-321">キャンセルまたは完了により、操作を開始するボタンと操作を取り消すボタンがリセットされます。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-321">Cancellation or completion resets the buttons that launch and cancel the operation.</span></span> <span data-ttu-id="f3b2c-322">進行状況レポートにより、プログレス コントロールが更新されます。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-322">Progress reporting updates the progress control.</span></span>

<span data-ttu-id="f3b2c-323">asyncCancel 関数は、WinJS.Promise オブジェクトの cancel メソッドを呼び出すだけです。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-323">The asyncCancel function just calls the cancel method of the WinJS.Promise object.</span></span>

<span data-ttu-id="f3b2c-324">アプリを実行するには、F5 キーを押します。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-324">To run the app, choose the F5 key.</span></span> <span data-ttu-id="f3b2c-325">非同期操作を開始するには、**[Async]** ボタンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-325">To start the asynchronous operation, choose the **Async** button.</span></span> <span data-ttu-id="f3b2c-326">次に行われる処理は、コンピューターの速度によって異なります。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-326">What happens next depends on how fast your computer is.</span></span> <span data-ttu-id="f3b2c-327">点滅時間になる前に進行状況バーが完了まで進む場合は、10 個の中の 1 つ以上の要素によって GetPrimesInRangeAsync に渡される開始番号を大きくします。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-327">If the progress bar zips to completion before you have time to blink, increase the size of the starting number that is passed to GetPrimesInRangeAsync by one or more factors of ten.</span></span> <span data-ttu-id="f3b2c-328">テストする数値の数の増減によって操作の時間を調整できますが、開始番号の途中にゼロを追加すると影響が大きくなります。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-328">You can fine-tune the duration of the operation by increasing or decreasing the count of numbers to test, but adding zeros in the middle of the starting number will have a bigger impact.</span></span> <span data-ttu-id="f3b2c-329">操作を取り消すには、**[Cancel Async]** ボタンを選びます。</span><span class="sxs-lookup"><span data-stu-id="f3b2c-329">To cancel the operation, choose the **Cancel Async** button.</span></span>

## <a name="related-topics"></a><span data-ttu-id="f3b2c-330">関連トピック</span><span class="sxs-lookup"><span data-stu-id="f3b2c-330">Related topics</span></span>

* [<span data-ttu-id="f3b2c-331">UWP アプリの概要の .NET</span><span class="sxs-lookup"><span data-stu-id="f3b2c-331">.NET for UWP apps Overview</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/br230302.aspx)
* [<span data-ttu-id="f3b2c-332">UWP アプリの .NET</span><span class="sxs-lookup"><span data-stu-id="f3b2c-332">.NET for UWP apps</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/mt185501.aspx)
* [<span data-ttu-id="f3b2c-333">チュートリアル: 単純な Windows ランタイム コンポーネントの作成と JavaScript からの呼び出し</span><span class="sxs-lookup"><span data-stu-id="f3b2c-333">Walkthrough: Creating a Simple Windows Runtime Component and calling it from JavaScript</span></span>](walkthrough-creating-a-simple-windows-runtime-component-and-calling-it-from-javascript.md)
