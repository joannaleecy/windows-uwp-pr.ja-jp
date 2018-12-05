---
title: プログラミング言語の選択
ms.assetid: 6CA46432-BF03-4B20-9187-565B3503B497
description: プログラミング言語の選択
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: a9544c1eecc4c1a86552d053694872743a17142c
ms.sourcegitcommit: d7613c791107f74b6a3dc12a372d9de916c0454b
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/05/2018
ms.locfileid: "8734598"
---
# <a name="getting-started-choosing-a-programming-language"></a>はじめに: プログラミング言語の選択


## <a name="choosing-a-programming-language"></a>プログラミング言語の選択

先へ進む前に、ユニバーサル Windows プラットフォーム (UWP) アプリを開発するときに選択できるプログラミング言語について理解している必要があります。 この記事のチュートリアルでは C# が使われていますが、UWP アプリは複数のプログラミング言語を使って開発できます (「[言語、ツール、フレームワーク](https://msdn.microsoft.com/library/windows/apps/dn465799)」をご覧ください)。

C++、C#、Microsoft Visual Basic、JavaScript を使って開発できます。 JavaScript では UI のレイアウトに HTML5 マークアップを使い、他の言語では *XAML (Extensible Application Markup Language)* と呼ばれるマークアップ言語を使って UI を記述します。

この記事では C# を中心に扱いますが、独自の利点がある他の言語についても検討することをお勧めします。 たとえば、特にグラフィックスを多用した際のアプリのパフォーマンスが最も重要視される場合は、C++ が適切です。 Visual Basic アプリの開発者にとっては、Microsoft .NET バージョンの Visual Basic が適切です。 JavaScript と HTML5 の組み合わせは、Web 開発の経歴がある開発者向けです。 詳しくは、次のいずれかのトピックをご覧ください。

-   [C++ を使った初めての UWP アプリを作成します。](../get-started/create-a-basic-windows-10-app-in-cpp.md)
-   [C# または Visual Basic を使った初めての UWP アプリを作成します。](../get-started/create-a-hello-world-app-xaml-universal.md)
-   [JavaScript を使った初めての UWP アプリを作成します。](../get-started/create-a-hello-world-app-js-uwp.md)

**注:** 3D グラフィックスを使用するアプリの場合、OpenGL 規格と OpenGL ES 規格は UWP アプリのネイティブで利用できません。 OpenGL ES のコードを Microsoft DirectX に書き換えない場合は、**Angle** に関心を持つかもしれません。 Angle は OpenGL API 呼び出しを DirectX API 呼び出しに翻訳することにより、OpenGL を DirectX に変換するように設計された進行中のプロジェクトです。 詳しくは、次のトピックをご覧ください。
-   [Angle](https://code.google.com/p/angleproject/)
-   [DirectX を使った初めての UWP アプリを作成します。](https://msdn.microsoft.com/library/windows/apps/br229580)
-   [DirectX を使った UWP アプリのサンプル](http://go.microsoft.com/fwlink/p/?LinkId=263603)
-   [DirectX SDK の場所](https://msdn.microsoft.com/library/windows/desktop/ee663275)

## <a name="giving-c-a-go"></a>C# を試してみる

iOS 開発者は、Objective-C と Swift を日常的に使っています。 両方に最も近い Microsoft プログラミング言語は C# です。 ほとんどの開発者とほとんどのアプリにおいて、最も簡単かつ短期間に学習して使用できる言語は C# と考えられます。そこで、この記事の情報とチュートリアルでは、この言語を中心に取り上げています。 C# について詳しくは、次のトピックをご覧ください。

-   [C# または Visual Basic を使った初めての UWP アプリを作成します。](../get-started/create-a-hello-world-app-xaml-universal.md)
-   [C# を使用する UWP アプリのサンプル](http://go.microsoft.com/fwlink/p/?LinkId=263453)
-   [Visual C#]](http://go.microsoft.com/fwlink/p/?LinkId=263450)

次に示すのは、Objective-C と C# で書かれたクラスです。 最初に Objective-C バージョンを示し、その後に C# バージョンを示します。

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

次は C# のバージョンです。 Swift のように、ヘッダーと実装が別個のファイルに分離されていないことがわかります。

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

C# は習得が容易な言語であり、.NET を構成する多くのサポート クラスとフレームワークが付属しています。 すぐに、角かっこなしでコードをうまく記述することができるようになります。

## <a name="next-step"></a>次のステップ

[はじめに: Visual Studio の操作方法](getting-started-getting-around-in-visual-studio.md)
