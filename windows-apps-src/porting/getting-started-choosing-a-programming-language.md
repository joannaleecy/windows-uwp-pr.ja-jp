---
title: プログラミング言語の選択
ms.assetid: 6CA46432-BF03-4B20-9187-565B3503B497
description: プログラミング言語の選択
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: a9544c1eecc4c1a86552d053694872743a17142c
ms.sourcegitcommit: 231065c899d0de285584d41e6335251e0c2c4048
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/10/2018
ms.locfileid: "8828261"
---
# <a name="getting-started-choosing-a-programming-language"></a><span data-ttu-id="f42c0-104">はじめに: プログラミング言語の選択</span><span class="sxs-lookup"><span data-stu-id="f42c0-104">Getting started: Choosing a programming language</span></span>


## <a name="choosing-a-programming-language"></a><span data-ttu-id="f42c0-105">プログラミング言語の選択</span><span class="sxs-lookup"><span data-stu-id="f42c0-105">Choosing a programming language</span></span>

<span data-ttu-id="f42c0-106">先へ進む前に、ユニバーサル Windows プラットフォーム (UWP) アプリを開発するときに選択できるプログラミング言語について理解している必要があります。</span><span class="sxs-lookup"><span data-stu-id="f42c0-106">Before we go any further, you should know about the programming languages that you can choose from when you develop Universal Windows Platform (UWP) apps.</span></span> <span data-ttu-id="f42c0-107">この記事のチュートリアルでは C# が使われていますが、UWP アプリは複数のプログラミング言語を使って開発できます (「[言語、ツール、フレームワーク](https://msdn.microsoft.com/library/windows/apps/dn465799)」をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="f42c0-107">Although the walkthroughs in this article use C#, you can develop UWP apps using one or more programming languages (see [Languages, tools and frameworks](https://msdn.microsoft.com/library/windows/apps/dn465799)).</span></span>

<span data-ttu-id="f42c0-108">C++、C#、Microsoft Visual Basic、JavaScript を使って開発できます。</span><span class="sxs-lookup"><span data-stu-id="f42c0-108">You can develop using C++, C#, Microsoft Visual Basic, and JavaScript.</span></span> <span data-ttu-id="f42c0-109">JavaScript では UI のレイアウトに HTML5 マークアップを使い、他の言語では *XAML (Extensible Application Markup Language)* と呼ばれるマークアップ言語を使って UI を記述します。</span><span class="sxs-lookup"><span data-stu-id="f42c0-109">JavaScript uses HTML5 markup for UI layout, and the other languages use a markup language called *Extensible Application Markup Language (XAML)* to describe their UI.</span></span>

<span data-ttu-id="f42c0-110">この記事では C# を中心に扱いますが、独自の利点がある他の言語についても検討することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="f42c0-110">Although we're focusing on C# in this article, the other languages offer unique benefits, which you may want to explore.</span></span> <span data-ttu-id="f42c0-111">たとえば、特にグラフィックスを多用した際のアプリのパフォーマンスが最も重要視される場合は、C++ が適切です。</span><span class="sxs-lookup"><span data-stu-id="f42c0-111">For example, if your app's performance is a primary concern, especially for intensive graphics, then C++ might be the right choice.</span></span> <span data-ttu-id="f42c0-112">Visual Basic アプリの開発者にとっては、Microsoft .NET バージョンの Visual Basic が適切です。</span><span class="sxs-lookup"><span data-stu-id="f42c0-112">The Microsoft .NET version of Visual Basic is great for Visual Basic app developers.</span></span> <span data-ttu-id="f42c0-113">JavaScript と HTML5 の組み合わせは、Web 開発の経歴がある開発者向けです。</span><span class="sxs-lookup"><span data-stu-id="f42c0-113">JavaScript with HTML5 is great for those coming from a web development background.</span></span> <span data-ttu-id="f42c0-114">詳しくは、次のいずれかのトピックをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f42c0-114">For more info, see one of the following:</span></span>

-   [<span data-ttu-id="f42c0-115">C++ を使った初めての UWP アプリを作成します。</span><span class="sxs-lookup"><span data-stu-id="f42c0-115">Create your first UWP app using C++</span></span>](../get-started/create-a-basic-windows-10-app-in-cpp.md)
-   [<span data-ttu-id="f42c0-116">C# または Visual Basic を使った初めての UWP アプリを作成します。</span><span class="sxs-lookup"><span data-stu-id="f42c0-116">Create your first UWP app using C# or Visual Basic</span></span>](../get-started/create-a-hello-world-app-xaml-universal.md)
-   [<span data-ttu-id="f42c0-117">JavaScript を使った初めての UWP アプリを作成します。</span><span class="sxs-lookup"><span data-stu-id="f42c0-117">Create your first UWP app using JavaScript</span></span>](../get-started/create-a-hello-world-app-js-uwp.md)

<span data-ttu-id="f42c0-118">**注:** 3D グラフィックスを使用するアプリの場合、OpenGL 規格と OpenGL ES 規格は UWP アプリのネイティブで利用できません。</span><span class="sxs-lookup"><span data-stu-id="f42c0-118">**Note**For apps that use 3D graphics, the OpenGL and OpenGL ES standards are not natively available for UWP apps.</span></span> <span data-ttu-id="f42c0-119">OpenGL ES のコードを Microsoft DirectX に書き換えない場合は、**Angle** に関心を持つかもしれません。</span><span class="sxs-lookup"><span data-stu-id="f42c0-119">If you would rather not rewrite your OpenGL ES code into Microsoft DirectX, you may be interested to know about **Angle**.</span></span> <span data-ttu-id="f42c0-120">Angle は OpenGL API 呼び出しを DirectX API 呼び出しに翻訳することにより、OpenGL を DirectX に変換するように設計された進行中のプロジェクトです。</span><span class="sxs-lookup"><span data-stu-id="f42c0-120">Angle is an on-going project designed to convert OpenGL to DirectX by translating OpenGL API calls into DirectX API calls.</span></span> <span data-ttu-id="f42c0-121">詳しくは、次のトピックをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f42c0-121">To learn more, see the following:</span></span>
-   [<span data-ttu-id="f42c0-122">Angle</span><span class="sxs-lookup"><span data-stu-id="f42c0-122">Angle</span></span>](https://code.google.com/p/angleproject/)
-   [<span data-ttu-id="f42c0-123">DirectX を使った初めての UWP アプリを作成します。</span><span class="sxs-lookup"><span data-stu-id="f42c0-123">Create your first UWP app using DirectX</span></span>](https://msdn.microsoft.com/library/windows/apps/br229580)
-   [<span data-ttu-id="f42c0-124">DirectX を使った UWP アプリのサンプル</span><span class="sxs-lookup"><span data-stu-id="f42c0-124">UWP app samples that use DirectX</span></span>](http://go.microsoft.com/fwlink/p/?LinkId=263603)
-   [<span data-ttu-id="f42c0-125">DirectX SDK の場所</span><span class="sxs-lookup"><span data-stu-id="f42c0-125">Where is the DirectX SDK?</span></span>](https://msdn.microsoft.com/library/windows/desktop/ee663275)

## <a name="giving-c-a-go"></a><span data-ttu-id="f42c0-126">C# を試してみる</span><span class="sxs-lookup"><span data-stu-id="f42c0-126">Giving C# a go</span></span>

<span data-ttu-id="f42c0-127">iOS 開発者は、Objective-C と Swift を日常的に使っています。</span><span class="sxs-lookup"><span data-stu-id="f42c0-127">As an iOS developer, you're accustomed to Objective-C and Swift.</span></span> <span data-ttu-id="f42c0-128">両方に最も近い Microsoft プログラミング言語は C# です。</span><span class="sxs-lookup"><span data-stu-id="f42c0-128">The closest Microsoft programming language to both is C#.</span></span> <span data-ttu-id="f42c0-129">ほとんどの開発者とほとんどのアプリにおいて、最も簡単かつ短期間に学習して使用できる言語は C# と考えられます。そこで、この記事の情報とチュートリアルでは、この言語を中心に取り上げています。</span><span class="sxs-lookup"><span data-stu-id="f42c0-129">For most developers and most apps, we think C# is the easiest and fastest language to learn and use, so this article's info and walkthroughs focus on that language.</span></span> <span data-ttu-id="f42c0-130">C# について詳しくは、次のトピックをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f42c0-130">To learn more about C#, see the following:</span></span>

-   [<span data-ttu-id="f42c0-131">C# または Visual Basic を使った初めての UWP アプリを作成します。</span><span class="sxs-lookup"><span data-stu-id="f42c0-131">Create your first UWP app using C# or Visual Basic</span></span>](../get-started/create-a-hello-world-app-xaml-universal.md)
-   [<span data-ttu-id="f42c0-132">C# を使用する UWP アプリのサンプル</span><span class="sxs-lookup"><span data-stu-id="f42c0-132">UWP app samples that use C#</span></span>](http://go.microsoft.com/fwlink/p/?LinkId=263453)
-   [<span data-ttu-id="f42c0-133">Visual C#]</span><span class="sxs-lookup"><span data-stu-id="f42c0-133">Visual C#</span></span>](http://go.microsoft.com/fwlink/p/?LinkId=263450)

<span data-ttu-id="f42c0-134">次に示すのは、Objective-C と C# で書かれたクラスです。</span><span class="sxs-lookup"><span data-stu-id="f42c0-134">Following is a class written in Objective-C and C#.</span></span> <span data-ttu-id="f42c0-135">最初に Objective-C バージョンを示し、その後に C# バージョンを示します。</span><span class="sxs-lookup"><span data-stu-id="f42c0-135">The Objective-C version is shown first, followed by the C# version.</span></span>

```obj-c
// Objective-C header: SampleClass.h.

#import <Foundation/Foundation.h>

@interface SampleClass : NSObject {
    BOOL localVariable;
}

@property (nonatomic) BOOL localVariable;

-(int) addThis: (int) firstNumber andThis: (int) secondNumber;

@end
```

```obj-c
// Objective-C implementation.

#import "SampleClass.h"

@implementation SampleClass

@synthesize localVariable = _localVariable;

- (id)init {
    self = [super init];
    if (self) {
        localVariable = true;
    }
    return self;
}

-(int) addThis: (int) firstNumber andThis: (int) secondNumber {
    return firstNumber + secondNumber;
}

@end
```

```obj-c
// Objective-C usage.

SampleClass *mySampleClass = [[SampleClass alloc] init];
mySampleClass.localVariable = false;
int result = [mySampleClass addThis:1 andThis:2];
```

<span data-ttu-id="f42c0-136">次は C# のバージョンです。</span><span class="sxs-lookup"><span data-stu-id="f42c0-136">Now, for the C# version.</span></span> <span data-ttu-id="f42c0-137">Swift のように、ヘッダーと実装が別個のファイルに分離されていないことがわかります。</span><span class="sxs-lookup"><span data-stu-id="f42c0-137">You'll see that like Swift, the header and the implementation are not in separate files.</span></span>

```csharp
// C# header and implementation.

using System;

namespace MyApp  // Defines this code' s scope.
{
    class SampleClass
    {
        private bool localVariable;

        public SampleClass() // Constructor.
        {
            localVariable = true;
        }

        public bool myLocalVariable // Property.
        {
            get
            {
                return localVariable;
            }
            set
            {
                localVariable = value; 
            }
        }

        public int AddTwoNumbers(int numberOne, int numberTwo)
        {
            return numberOne + numberTwo;
        }        
    }
}
```

```csharp
// C# usage.

SampleClass mySampleClass = new SampleClass();
mySampleClass.myLocalVariable = false;
int result = mySampleClass.AddTwoNumbers(1, 2);
```

<span data-ttu-id="f42c0-138">C# は習得が容易な言語であり、.NET を構成する多くのサポート クラスとフレームワークが付属しています。</span><span class="sxs-lookup"><span data-stu-id="f42c0-138">C# is an easy language to pick up, and comes with the many support classes and frameworks that make up .NET.</span></span> <span data-ttu-id="f42c0-139">すぐに、角かっこなしでコードをうまく記述することができるようになります。</span><span class="sxs-lookup"><span data-stu-id="f42c0-139">In no time, you'll be happily writing your code without a square bracket in sight!</span></span>

## <a name="next-step"></a><span data-ttu-id="f42c0-140">次のステップ</span><span class="sxs-lookup"><span data-stu-id="f42c0-140">Next step</span></span>

[<span data-ttu-id="f42c0-141">はじめに: Visual Studio の操作方法</span><span class="sxs-lookup"><span data-stu-id="f42c0-141">Getting started: Getting around in Visual Studio</span></span>](getting-started-getting-around-in-visual-studio.md)
