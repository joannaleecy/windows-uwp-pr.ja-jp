---
author: msatranjr
title: .NET Framework での Windows ランタイム型の対応付け
description: 次の表は、.NET Framework での、ユニバーサル Windows プラットフォーム (UWP) 型と .NET Framework 型の間の対応付けを示しています。
ms.assetid: 5317D771-808D-4B97-8063-63492B23292F
ms.author: misatran
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: f1869038ad98b8b4103b9706534a2d456f17e734
ms.sourcegitcommit: 753e0a7160a88830d9908b446ef0907cc71c64e7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/29/2018
ms.locfileid: "5747701"
---
# <a name="net-framework-mappings-of-windows-runtime-types"></a>.NET Framework での Windows ランタイム型の対応付け



次の表は、.NET Framework での、ユニバーサル Windows プラットフォーム (UWP) 型と .NET Framework 型の間の対応付けを示しています。 マネージ コードで記述されたユニバーサル Windows アプリでは、IntelliSense は UWP 型ではなく .NET Framework 型を表示します。 たとえば、Windows ランタイム メソッドが IVector&lt;string&gt; 型のパラメーターを受け取る場合、IntelliSense は IList&lt;string&gt; 型のパラメーターを表示します。 同様に、マネージ コードで記述された Windows ランタイム コンポーネントでは、.NET Framework 型をメンバーのシグネチャ内で使います。 [Windows ランタイム メタデータ エクスポート ツール (Winmdexp.exe)](https://msdn.microsoft.com/library/hh925576.aspx) で Windows ランタイム コンポーネントを生成すると、.NET Framework 型は、対応する UWP 型になります。

## <a name="mapping-tables"></a>対応表


UWP と .NET Framework の両方で同じ名前空間名と型名を持つ型の大部分は、構造体です (または列挙体など、構造体に関連付けられている型)。 UWP では、構造体にはフィールド以外にメンバーがなく、.NET Framework では非表示になるヘルパー型が必要です。 これらの構造体の .NET Framework バージョンには、非表示のヘルパー型の機能を提供するプロパティとメソッドがあります。

表 1: UWP 型と .NET Framework 型の対応 (異なる型名と名前空間名を持つ型)

| UWP 型/名前空間                                            | .NET Framework 型/名前空間                                          | .NET Framework アセンブリ                           |
|---------------------------------------------------------------|------------------------------------------------------------------------|---------------------------------------------------|
| AttributeUsageAttribute (Windows.Foundation.Metadata)         | AttributeUsageAttribute (System)                                       | System.Runtime.dll                                |
| AttributeTargets (Windows.Foundation.Metadata)                | AttributeTargets (System)                                              | System.Runtime.dll                                |
| DateTime (Windows.Foundation)                                 | DateTimeOffset (System)                                                | System.Runtime.dll                                |
| EventHandler&lt;T&gt; (Windows.Foundation)                    | EventHandler&lt;T&gt; (System)                                         | System.Runtime.dll                                |
| EventRegistrationToken (Windows.Foundation)                   | EventRegistrationToken (System.Runtime.InteropServices.WindowsRuntime) | System.Runtime.InteropServices.WindowsRuntime.dll |
| HResult (Windows.Foundation)                                  | Exception (System)                                                     | System.Runtime.dll                                |
| IReference&lt;T&gt; (Windows.Foundation)                      | Nullable&lt;T&gt; (System)                                             | System.Runtime.dll                                |
| TimeSpan (Windows.Foundation)                                 | TimeSpan (System)                                                      | System.Runtime.dll                                |
| Uri (Windows.Foundation)                                      | Uri (System)                                                           | System.Runtime.dll                                |
| IClosable (Windows.Foundation)                                | IDisposable (System)                                                   | System.Runtime.dll                                |
| IIterable&lt;T&gt; (Windows.Foundation.Collections)           | IEnumerable&lt;T&gt; (System.Collections.Generic)                      | System.Runtime.dll                                |
| IVector&lt;T&gt; (Windows.Foundation.Collections)             | IList&lt;T&gt; (System.Collections.Generic)                            | System.Runtime.dll                                |
| IVectorView&lt;T&gt; (Windows.Foundation.Collections)         | IReadOnlyList&lt;T&gt; (System.Collections.Generic)                    | System.Runtime.dll                                |
| IMap&lt;K,V&gt; (Windows.Foundation.Collections)              | IDictionary&lt;TKey,TValue&gt; (System.Collections.Generic)            | System.Runtime.dll                                |
| IMapView&lt;K,V&gt; (Windows.Foundation.Collections)          | IReadOnlyDictionary&lt;TKey,TValue&gt; (System.Collections.Generic)    | System.Runtime.dll                                |
| IKeyValuePair&lt;K,V&gt; (Windows.Foundation.Collections)     | KeyValuePair&lt;TKey,TValue&gt; (System.Collections.Generic)           | System.Runtime.dll                                |
| IBindableIterable (Windows.UI.Xaml.Interop)                   | IEnumerable (System.Collections)                                       | System.Runtime.dll                                |
| IBindableVector (Windows.UI.Xaml.Interop)                     | IList (System.Collections)                                             | System.Runtime.dll                                |
| INotifyCollectionChanged (Windows.UI.Xaml.Interop)            | INotifyCollectionChanged (System.Collections.Specialized)              | System.ObjectModel.dll                            |
| NotifyCollectionChangedEventHandler (Windows.UI.Xaml.Interop) | NotifyCollectionChangedEventHandler (System.Collections.Specialized)   | System.ObjectModel.dll                            |
| NotifyCollectionChangedEventArgs (Windows.UI.Xaml.Interop)    | NotifyCollectionChangedEventArgs (System.Collections.Specialized)      | System.ObjectModel.dll                            |
| NotifyCollectionChangedAction (Windows.UI.Xaml.Interop)       | NotifyCollectionChangedAction (System.Collections.Specialized)         | System.ObjectModel.dll                            |
| INotifyPropertyChanged (Windows.UI.Xaml.Data)                 | INotifyPropertyChanged (System.ComponentModel)                         | System.ObjectModel.dll                            |
| PropertyChangedEventHandler (Windows.UI.Xaml.Data)            | PropertyChangedEventHandler (System.ComponentModel)                    | System.ObjectModel.dll                            |
| PropertyChangedEventArgs (Windows.UI.Xaml.Data)               | PropertyChangedEventArgs (System.ComponentModel)                       | System.ObjectModel.dll                            |
| TypeName (Windows.UI.Xaml.Interop)                            | Type (System)                                                          | System.Runtime.dll                                |

 

表 2: UWP 型と .NET Framework 型の対応 (同じ型名と名前空間名を持つ型)

| 名前空間                           | 型               | .NET Framework アセンブリ                   |
|-------------------------------------|--------------------|-------------------------------------------|
| Windows.UI                          | Color              | System.Runtime.WindowsRuntime.dll         |
| Windows.Foundation                  | Point              | System.Runtime.WindowsRuntime.dll         |
| Windows.Foundation                  | Rect               | System.Runtime.WindowsRuntime.dll         |
| Windows.Foundation                  | Size               | System.Runtime.WindowsRuntime.dll         |
| Windows.UI.Xaml.Input               | ICommand           | System.ObjectModel.dll                    |
| Windows.UI.Xaml                     | CornerRadius       | System.Runtime.WindowsRuntime.UI.Xaml.dll |
| Windows.UI.Xaml                     | Duration           | System.Runtime.WindowsRuntime.UI.Xaml.dll |
| Windows.UI.Xaml                     | DurationType       | System.Runtime.WindowsRuntime.UI.Xaml.dll |
| Windows.UI.Xaml                     | GridLength         | System.Runtime.WindowsRuntime.UI.Xaml.dll |
| Windows.UI.Xaml                     | GridUnitType       | System.Runtime.WindowsRuntime.UI.Xaml.dll |
| Windows.UI.Xaml                     | Thickness          | System.Runtime.WindowsRuntime.UI.Xaml.dll |
| Windows.UI.Xaml.Controls.Primitives | GeneratorPosition  | System.Runtime.WindowsRuntime.UI.Xaml.dll |
| Windows.UI.Xaml.Media               | Matrix             | System.Runtime.WindowsRuntime.UI.Xaml.dll |
| Windows.UI.Xaml.Media.Animation     | KeyTime            | System.Runtime.WindowsRuntime.UI.Xaml.dll |
| Windows.UI.Xaml.Media.Animation     | RepeatBehavior     | System.Runtime.WindowsRuntime.UI.Xaml.dll |
| Windows.UI.Xaml.Media.Animation     | RepeatBehaviorType | System.Runtime.WindowsRuntime.UI.Xaml.dll |
| Windows.UI.Xaml.Media.Media3D       | Matrix3D           | System.Runtime.WindowsRuntime.UI.Xaml.dll |

 

## <a name="related-topics"></a>関連トピック

* [C# および Visual Basic での Windows ランタイム コンポーネントの作成](creating-windows-runtime-components-in-csharp-and-visual-basic.md)
