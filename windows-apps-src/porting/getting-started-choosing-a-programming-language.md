---
xxxxx: Xxxxxxxx x xxxxxxxxxxx xxxxxxxx
xx.xxxxxxx: YXXYYYYY-XXYY-YXYY-YYYY-YYYXYYYYXYYY
xxxxxxxxxxx: Xxxxxxxx x xxxxxxxxxxx xxxxxxxx
---

# Xxxxxxx xxxxxxx: Xxxxxxxx x xxxxxxxxxxx xxxxxxxx

\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

## Xxxxxxxx x xxxxxxxxxxx xxxxxxxx

Xxxxxx xx xx xxx xxxxxxx, xxx xxxxxx xxxx xxxxx xxx xxxxxxxxxxx xxxxxxxxx xxxx xxx xxx xxxxxx xxxx xxxx xxx xxxxxxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxx. Xxxxxxxx xxx xxxxxxxxxxxx xx xxxx xxxxxxx xxx X#, xxx xxx xxxxxxx XXX xxxx xxxxx xxx xx xxxx xxxxxxxxxxx xxxxxxxxx (xxx [Xxxxxxxxx, xxxxx xxx xxxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/dn465799)).

Xxx xxx xxxxxxx xxxxx X++, X#, Xxxxxxxxx Xxxxxx Xxxxx, xxx XxxxXxxxxx. XxxxXxxxxx xxxx XXXXY xxxxxx xxx XX xxxxxx, xxx xxx xxxxx xxxxxxxxx xxx x xxxxxx xxxxxxxx xxxxxx *Xxxxxxxxxx Xxxxxxxxxxx Xxxxxx Xxxxxxxx (XXXX)* xx xxxxxxxx xxxxx XX.

Xxxxxxxx xx'xx xxxxxxxx xx X# xx xxxx xxxxxxx, xxx xxxxx xxxxxxxxx xxxxx xxxxxx xxxxxxxx, xxxxx xxx xxx xxxx xx xxxxxxx. Xxx xxxxxxx, xx xxxx xxx'x xxxxxxxxxxx xx x xxxxxxx xxxxxxx, xxxxxxxxxx xxx xxxxxxxxx xxxxxxxx, xxxx X++ xxxxx xx xxx xxxxx xxxxxx. Xxx Xxxxxxxxx .XXX xxxxxxx xx Xxxxxx Xxxxx xx xxxxx xxx Xxxxxx Xxxxx xxx xxxxxxxxxx. XxxxXxxxxx xxxx XXXXY xx xxxxx xxx xxxxx xxxxxx xxxx x xxx xxxxxxxxxxx xxxxxxxxxx. Xxx xxxx xxxx, xxx xxx xx xxx xxxxxxxxx:

-   [Xxxxxx xxxx xxxxx Xxxxxxx Xxxxx xxx xxxxx X++](https://msdn.microsoft.com/library/windows/apps/hh974580)
-   [Xxxxxx xxxx xxxxx Xxxxxxx Xxxxx xxx xxxxx X# xx Xxxxxx Xxxxx](https://msdn.microsoft.com/library/windows/apps/hh974581)
-   [Xxxxxx xxxx xxxxx Xxxxxxx Xxxxx xxx xxxxx XxxxXxxxxx](https://msdn.microsoft.com/library/windows/apps/br211385)
-   [Xxxxxx xxxx xxxxx Xxxxxxx Xxxxx Xxxxx xxx xxxxx X# xx Xxxxxx Xxxxx](http://go.microsoft.com/fwlink/p/?LinkID=397877)
-   [XxxXX xx Xxxxxxx Xxxxx Y.Y](http://go.microsoft.com/fwlink/p/?LinkID=397879)

**Xxxx**  Xxx xxxx xxxx xxx YX xxxxxxxx, xxx XxxxXX xxx XxxxXX XX xxxxxxxxx xxx xxx xxxxxxxx xxxxxxxxx xxx XXX xxxx. Xx xxx xxxxx xxxxxx xxx xxxxxxx xxxx XxxxXX XX xxxx xxxx Xxxxxxxxx XxxxxxX, xxx xxx xx xxxxxxxxxx xx xxxx xxxxx **Xxxxx**. Xxxxx xx xx xx-xxxxx xxxxxxx xxxxxxxx xx xxxxxxx XxxxXX xx XxxxxxX xx xxxxxxxxxxx XxxxXX XXX xxxxx xxxx XxxxxxX XXX xxxxx. Xx xxxxx xxxx, xxx xxx xxxxxxxxx:
-   [Xxxxx](https://code.google.com/p/angleproject/)
-   [Xxxxxx xxxx xxxxx Xxxxxxx Xxxxx xxx xxxxx XxxxxxX](https://msdn.microsoft.com/library/windows/apps/br229580)
-   [Xxxxxxx Xxxxx xxx xxxxxxx xxxx xxx XxxxxxX](http://go.microsoft.com/fwlink/p/?LinkId=263603)
-   [Xxxxx xx xxx XxxxxxX XXX?](https://msdn.microsoft.com/library/windows/desktop/ee663275)

## Xxxxxx X# x xx

Xx xx xXX xxxxxxxxx, xxx'xx xxxxxxxxxx xx Xxxxxxxxx-X xxx Xxxxx. Xxx xxxxxxx Xxxxxxxxx xxxxxxxxxxx xxxxxxxx xx xxxx xx X#. Xxx xxxx xxxxxxxxxx xxx xxxx xxxx, xx xxxxx X# xx xxx xxxxxxx xxx xxxxxxx xxxxxxxx xx xxxxx xxx xxx, xx xxxx xxxxxxx'x xxxx xxx xxxxxxxxxxxx xxxxx xx xxxx xxxxxxxx. Xx xxxxx xxxx xxxxx X#, xxx xxx xxxxxxxxx:

-   [Xxxxxx xxxx xxxxx Xxxxxxx Xxxxx xxx xxxxx X# xx Xxxxxx Xxxxx](https://msdn.microsoft.com/library/windows/apps/hh974581)
-   [Xxxxxxx Xxxxx xxx xxxxxxx xxxx xxx X#](http://go.microsoft.com/fwlink/p/?LinkId=263453)
-   [Xxxxxx X#](http://go.microsoft.com/fwlink/p/?LinkId=263450)

Xxxxxxxxx xx x xxxxx xxxxxxx xx Xxxxxxxxx-X xxx X#. Xxx Xxxxxxxxx-X xxxxxxx xx xxxxx xxxxx, xxxxxxxx xx xxx X# xxxxxxx.

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

Xxx, xxx xxx X# xxxxxxx. Xxx'xx xxx xxxx xxxx Xxxxx, xxx xxxxxx xxx xxx xxxxxxxxxxxxxx xxx xxx xx xxxxxxxx xxxxx.

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

X# xx xx xxxx xxxxxxxx xx xxxx xx, xxx xxxxx xxxx xxx xxxx xxxxxxx xxxxxxx xxx xxxxxxxxxx xxxx xxxx xx .XXX. Xx xx xxxx, xxx'xx xx xxxxxxx xxxxxxx xxxx xxxx xxxxxxx x xxxxxx xxxxxxx xx xxxxx!

## Xxxx xxxx

[Xxxxxxx xxxxxxx: Xxxxxxx xxxxxx xx Xxxxxx Xxxxxx](getting-started-getting-around-in-visual-studio.md)
<!--HONumber=Mar16_HO1-->
