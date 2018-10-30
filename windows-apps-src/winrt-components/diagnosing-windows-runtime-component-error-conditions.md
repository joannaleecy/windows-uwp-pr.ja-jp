---
author: msatranjr
title: Windows ランタイム コンポーネントでのエラー状態の診断
description: この記事では、マネージ コードで記述された Windows ランタイム コンポーネントでの制限に関する追加情報について説明します。
ms.assetid: CD0D0E11-E68A-411D-B92E-E9DECFDC9599
ms.author: misatran
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10、UWP
ms.localizationpriority: medium
ms.openlocfilehash: 833dd0a6447e9d0bb49c21a18d17bd7b0dc3455d
ms.sourcegitcommit: 753e0a7160a88830d9908b446ef0907cc71c64e7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/30/2018
ms.locfileid: "5762228"
---
# <a name="diagnosing-windows-runtime-component-error-conditions"></a>Windows ランタイム コンポーネントでのエラー状態の診断




この記事では、マネージ コードで記述された Windows ランタイム コンポーネントでの制限に関する追加情報について説明します。 ここでは、[Winmdexp.exe (Windows ランタイム メタデータ エクスポート ツール)](https://msdn.microsoft.com/library/hh925576.aspx) からのエラー メッセージに示されている情報についても説明します。また、「[C# および Visual Basic での Windows ランタイム コンポーネントの作成](creating-windows-runtime-components-in-csharp-and-visual-basic.md)」に記載されている制限事項の情報について補足説明します。

この記事では、すべてのエラーが説明されているわけではありません。 ここで説明するエラーは一般的なカテゴリにまとめられており、各カテゴリには、関連するエラー メッセージの表が示されています。 この表を利用するには、メッセージ テキストで検索するか (プレース ホルダーの特定の値は省略してください)、メッセージ番号で検索してください。 必要な情報が見つからない場合は、この記事の最後にあるフィードバック ボタンをご利用ください。ドキュメントの内容を充実させるためにご協力をお願いします。 フィードバックを送る際には、エラー メッセージを含めてください。 また、Microsoft Connect の Web サイトで問題点をご連絡していただくこともできます。

## <a name="error-message-for-implementing-async-interface-provides-incorrect-type"></a>非同期インターフェイスの実装に関するエラー メッセージで示される型が正しくない


マネージ型の Windows ランタイム コンポーネントは、非同期処理や非同期操作を表すユニバーサル Windows プラットフォーム (UWP) インターフェイス ([IAsyncAction](https://msdn.microsoft.com/library/br205781.aspx)、[IAsyncActionWithProgress&lt;TProgress&gt;](https://msdn.microsoft.com/library/br205784.aspx)、[IAsyncOperation&lt;TResult&gt;](https://msdn.microsoft.com/library/windows/apps/br206598.aspx)、[IAsyncOperationWithProgress&lt;TResult, TProgress&gt;](https://msdn.microsoft.com/library/windows/apps/br206594.aspx)) を実装することはできません。 代わりに、.NET Framework には、Windows ランタイム コンポーネントの非同期操作を生成するための [AsyncInfo](https://msdn.microsoft.com/library/system.runtime.interopservices.windowsruntime.asyncinfo.aspx) クラスが用意されています。 非同期インターフェイスを実装しようとしたときに Winmdexp.exe により表示されるエラー メッセージでは、このクラスが誤って以前の名前の AsyncInfoFactory として示されます。 .NET Framework では、AsyncInfoFactory クラスが使われなくなりました。

| エラー番号 | メッセージ テキスト|       
|--------------|-------------|
| WME1084      | 型 '{0}'Windows ランタイムの非同期インターフェイスを実装'{1}' です。 Windows ランタイム型は、非同期インターフェイスを実装できません。 System.Runtime.InteropServices.WindowsRuntime.AsyncInfoFactory クラスを使用して、Windows ランタイムへのエクスポート用に非同期操作を生成してください。 |

> **注:** Windows ランタイムを参照するエラー メッセージは、以前の用語を使用します。 現在では、Windows ランタイムはユニバーサル Windows プラットフォーム (UWP) と呼ばれます。 たとえば、Windows ランタイム型は UWP 型と呼ばれています。

 

## <a name="missing-references-to-mscorlibdll-or-systemruntimedll"></a>mscorlib.dll または System.Runtime.dll への参照が指定されていない


この問題は、コマンド ラインから Winmdexp.exe を使う場合にのみ発生します。 .NET Framework のコア参照アセンブリから mscorlib.dll と System.Runtime.dll の両方への参照を含めるには、/reference オプションを使うことをお勧めします。コア参照アセンブリは、"%ProgramFiles(x86)%\\Reference Assemblies\\Microsoft\\Framework\\.NETCore\\v4.5" (32 ビット コンピューターの場合は、"%ProgramFiles%\\...") にあります。

| エラー番号 | メッセージ テキスト                                                                                                                                     |
|--------------|--------------------------------------------------------------------------------------------------------------------------------------------------|
| WME1009      | mscorlib.dll は参照されませんでした。 正しくエクスポートするには、このメタデータ ファイルへの参照が必要です。                               |
| WME1090      | コア参照アセンブリを確認できませんでした。 /reference スイッチを使用して mscorlib.dll および System.Runtime.dll が参照されていることを確認してください。 |

 

## <a name="operator-overloading-is-not-allowed"></a>演算子のオーバーロードが許可されていない


マネージ コードで記述された Windows ランタイム コンポーネントでは、パブリック型のオーバーロードされた演算子を公開することはできません。

> **注:**、エラー メッセージでは、演算子は op\_Addition、op \_multiply、op\_ExclusiveOr、op \_implicit (暗黙の変換) など、そのメタデータ名によって識別されます。

 

| エラー番号 | メッセージ テキスト                                                                                          |
|--------------|-------------------------------------------------------------------------------------------------------|
| WME1087      | '{0}' は演算子オーバー ロードです。 マネージ型は、Windows ランタイムで演算子オーバーロードを公開できません。 |

 

## <a name="constructors-on-a-class-have-the-same-number-of-parameters"></a>クラスのコンストラクターに同じ数のパラメーターがある


UWP のクラスは、指定された数のパラメーターを持つコンストラクターを 1 つしか保持できません。たとえば、**String** 型の 1 つのパラメーターを持つコンストラクターと **int** 型 (Visual Basic の **Integer**) の 1 つのパラメーターを持つコンストラクターを両方保持することはできません。 唯一の回避策は、各コンストラクターで異なる数のパラメーターを使うことです。

| エラー番号 | メッセージ テキスト                                                                                                                                            |
|--------------|---------------------------------------------------------------------------------------------------------------------------------------------------------|
| WME1099      | 型 '{0}'の複数のコンス トラクターを持って'{1}' 個です。 Windows ランタイム型には、同じ数の引数を持つ複数のコンストラクターがありません。 |

 

## <a name="must-specify-a-default-for-overloads-that-have-the-same-number-of-parameters"></a>同じ数のパラメーターを持つオーバーロードには既定値を指定する必要がある


UWP では、オーバーロードされたメソッドの 1 つが既定のオーバーロードとして指定されている場合にのみ、同じ数のパラメーターを持つことができます。 「[C# および Visual Basic での Windows ランタイム コンポーネントの作成](creating-windows-runtime-components-in-csharp-and-visual-basic.md)」の「オーバーロードされたメソッド」をご覧ください。

| エラー番号 | メッセージ テキスト                                                                                                                                                                      |
|--------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| WME1059      | 複数{0}-のオーバー ロード パラメーター '{1}します。{2}' Windows.Foundation.Metadata.DefaultOverloadAttribute で修飾されます。                                                            |
| WME1085      | {0}-パラメーターがのオーバー ロード{1}します。{2} Windows.Foundation.Metadata.DefaultOverloadAttribute で修飾することによって、既定のオーバー ロードとして指定されている 1 つの方法が必要です。 |

 

## <a name="namespace-errors-and-invalid-names-for-the-output-file"></a>出力ファイルの名前空間のエラーと無効な名前


ユニバーサル Windows プラットフォームでは、Windows メタデータ (.winmd) ファイルに含まれるすべてのパブリック型は、.winmd ファイルの名前を共有する名前空間、またはそのファイル名のサブ名前空間に含まれている必要があります。 たとえば、Visual Studio プロジェクトの名前が A.B (つまり、Windows ランタイム コンポーネントが A.B.winmd) の場合、パブリック クラス A.B.Class1 と A.B.C.Class2 を含めることができますが、A.Class3 (WME0006) または D.Class4 (WME1044) を含めることはできません。

> **注:** これらの制限は、実装で使われるプライベート型がパブリック型だけを適用します。

 

A.Class3 の場合、Class3 を別の名前空間に移動するか、Windows ランタイム コンポーネントの名前を A.winmd に変更することができます。 WME0006 は警告ですが、エラーとして扱う必要があります。 前の例では、A.B.winmd を呼び出すコードは A.Class3 を特定することはできません。

D.Class4 の場合、ファイル名には D.Class4 と A.B 名前空間内のクラスの両方を含めることはできないため、Windows ランタイム コンポーネントの名前を変更することはできません。 D.Class4 を別の名前空間に移動するか、別の Windows ランタイム コンポーネントに配置できます。

ファイル システムは大文字と小文字を区別できないため、同じ名前で大文字と小文字だけが異なる名前空間は許可されません (WME1067)。

コンポーネントには、少なくとも 1 つの **public sealed** 型 (Visual Basic の **Public NotInheritable**) を含める必要があります。 含めない場合、コンポーネントにプライベート型が含まれるかどうかに応じて、WME1042 または WME1043 を受け取ります。

Windows ランタイム コンポーネントの型には、名前空間と同じ名前を付けることはできません (WME1068)。

> **注意:** Winmdexp.exe を直接呼び出すして、Windows ランタイム コンポーネントの名前を指定する、/アウト オプションを使用しない場合、Winmdexp.exe しようとすると、コンポーネント内のすべての名前空間を含む名を生成します。 名前空間の名前を変更すると、コンポーネントの名前も変更される場合があります。

 

| エラー番号 | メッセージ テキスト                                                                                                                                                                                                                                                                                                                                             |
|--------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| WME0006      | '{0}' このアセンブリの有効な winmd ファイル名ではありません。 Windows メタデータ ファイル内のすべての型は、ファイル名で指定される名前空間のサブ名前空間に存在する必要があります。 このようなサブ名前空間に存在しない型は、ランタイムに見つかりません。 このアセンブリでは、ファイル名として使用される最小の一般的な名前空間は '{1}' です。 |
| WME1042      | 入力モジュールには、名前空間内にある少なくとも 1 つのパブリック型を含める必要があります。                                                                                                                                                                                                                                                                   |
| WME1043      | 入力モジュールには、名前空間内にある少なくとも 1 つのパブリック型を含める必要があります。 名前空間内で検出された型はプライベートのみです。                                                                                                                                                                                                               |
| WME1044      | パブリック型には、名前空間 ('{1}') をプレフィックスを共有しません一般的なその他の名前空間を持つ ('{0}')。 Windows メタデータ ファイル内のすべての型は、ファイル名で指定される名前空間のサブ名前空間に存在する必要があります。                                                                                                                              |
| WME1067      | ケースのみを Namespace の名前が異なることはできません。 '{0}'、'{1}' です。                                                                                                                                                                                                                                                                                                |
| WME1068      | 型 '{0}'名前空間と同じ名前を持つことはできません'{1}' です。                                                                                                                                                                                                                                                                                                 |

 

## <a name="exporting-types-that-arent-valid-universal-windows-platform-types"></a>無効なユニバーサル Windows プラットフォーム型である型をエクスポートする


コンポーネントのパブリック インターフェイスは UWP 型のみを公開する必要があります。 ただし、.NET Framework には、.NET Framework や UWP とはわずかに異なる多数の一般的な型に対応したマッピングが用意されています。 これにより、.NET Framework の開発者は、新しい型を習得せずに、使い慣れた型を使うことができます。 マップされた .NET Framework 型は、コンポーネントのパブリック インターフェイスで使うことができます。 [「C# および Visual Basic での Windows ランタイム コンポーネントの作成」](creating-windows-runtime-components-in-csharp-and-visual-basic.md)の「Windows ランタイム コンポーネントの宣言型」と「ユニバーサル Windows プラットフォーム型のマネージ コードへの引き渡し」、および「 [.NET Framework での Windows ランタイム型の対応付け](net-framework-mappings-of-windows-runtime-types.md)」をご覧ください。

これらのマッピングの多くはインターフェイスです。 たとえば、[IList&lt;T&gt;](https://msdn.microsoft.com/library/5y536ey6.aspx) は、UWP インターフェイス [IVector&lt;T&gt;](https://msdn.microsoft.com/library/windows/apps/br206631.aspx) にマップされます。 パラメーター型として IList&lt;string&gt; の代わりに List&lt;string&gt; (Visual Basic の `List(Of String)`) を使うと、Winmdexp.exe によって代替のインターフェイスのリストが提供されます。このリストには、List&lt;T&gt; によって実装されたマップ済みのインターフェイスがすべて含まれています。 List&lt;Dictionary&lt;int, string&gt;&gt; (Visual Basic の List(Of Dictionary(Of Integer, String))) など、入れ子になったジェネリック型を使う場合、Winmdexp.exe によって入れ子のレベルごとに選択肢のリストが提供されます。 これらのリストはかなり長くなる場合があります。

一般に、最適なのは型に最も近いインターフェイスです。 たとえば、Dictionary&lt;int, string&gt; の場合、IDictionary&lt;int, string&gt; が最適と考えられます。

> **重要な**JavaScript は、マネージ型が実装されるインターフェイスの一覧で最初に表示されるインターフェイスを使用します。 たとえば、Dictionary&lt;int, string&gt; を JavaScript コードに返した場合、戻り値の型としてどのインターフェイスを指定しても、IDictionary&lt;int, string&gt; として表示されます。 これは、後のインターフェイスで表示されるメンバーが最初のインターフェイスに含まれていない場合、そのメンバーは JavaScript に認識されないことを意味します。

> **注意:** コンポーネントが JavaScript によって使用する場合は、非ジェネリック[IList](https://msdn.microsoft.com/library/system.collections.ilist.aspx)および[IEnumerable](https://msdn.microsoft.com/library/system.collections.ienumerable.aspx)インターフェイスを使用してください。 これらのインターフェイスは、それぞれ [IBindableVector](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.interop.ibindablevector.aspx) と [IBindableIterator](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.interop.ibindableiterator.aspx) にマップされます。 これらは、XAML コントロールのバインドをサポートし、JavaScript には参照されません。 JavaScript では、実行時エラー ("関数 'X' に無効なシグネチャがあるため、呼び出せません") が発生します。

 

<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left">エラー番号</th>
<th align="left">メッセージ テキスト</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left">WME1033</td>
<td align="left">メソッド '{0}'のパラメーターが'{1}型' の'{2}' です。 '{2}' は有効な Windows ランタイム パラメーター型はありません。</td>
</tr>
<tr class="even">
<td align="left">WME1038</td>
<td align="left">メソッド '{0}'型のパラメーターが'{1}' そのシグネチャにします。 この型は有効な Windows ランタイム型ではありませんが、有効な Windows ランタイム型であるインターフェイスを実装しています。 代わりに、次の種類のいずれかを使用するメソッド シグネチャを変更することを検討してください: '{2}' です。</td>
</tr>
<tr class="odd">
<td align="left">WME1039</td>
<td align="left"><p>メソッド '{0}'型のパラメーターが'{1}' そのシグネチャにします。 このジェネリック型は有効な Windows ランタイム型ではありませんが、この型またはそのジェネリック パラメーターは、有効な Windows ランタイム型であるインターフェイスを実装します。 {2}</p>
> **注:** の{2}、Winmdexp.exe によって代替の一覧が次のように"の種類の変更の考慮事項 ''system.collections.generic.list&lt;T&gt;' 代わりに、次のいずれかのメソッド シグネチャで型: '&lt;T&gt;、System.Collections.Generic.IReadOnlyList&lt;T&gt;、System.Collections.Generic.IEnumerable&lt;T&gt;'."
</td>
</tr>
<tr class="even">
<td align="left">WME1040</td>
<td align="left">メソッド '{0}'型のパラメーターが'{1}' そのシグネチャにします。 管理されているタスク型を使用するのではなく、Windows.Foundation.IAsyncAction、Windows.Foundation.IAsyncOperation、またはその他の Windows ランタイムの非同期インターフェイスのいずれかを使用してください。 標準の .NET await パターンもこれらのインターフェイスに適用されます。 管理されているタスク オブジェクトを Windows ランタイムの非同期インターフェイスに変換する方法の詳細については、System.Runtime.InteropServices.WindowsRuntime.AsyncInfo を参照してください。</td>
</tr>
</tbody>
</table>

 

## <a name="structures-that-contain-fields-of-disallowed-types"></a>使うことができない型のフィールドを含む構造体


UWP では、構造体にはフィールドのみを含めることができ、フィールドは構造体にのみ含めることができます。 これらのフィールドはパブリック型である必要があります。 有効なフィールド型には、列挙体、構造体、およびプリミティブ型があります。

| エラー番号 | メッセージ テキスト                                                                                                                                                                                                                                                            |
|--------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| WME1060      | 構造体 '{0}"フィールドが"{1}型' の'{2}' です。 '{2}' は有効な Windows ランタイム フィールド型はありません。 Windows ランタイムの構造体に含まれる各フィールドに指定できるのは、UInt8、Int16、UInt16、Int32、UInt32、Int64、UInt64、Single、Double、Boolean、String、Enum、または構造体自体のみです。 |

 

## <a name="restrictions-on-arrays-in-member-signatures"></a>メンバーのシグネチャ内における配列の制限


UWP では、メンバーのシグネチャ内の配列は 1 次元で、下限を 0 (ゼロ) に指定する必要があります。 `myArray[][]` (Visual Basic の `myArray()()`) など、入れ子になった配列型を使うことはできません。

> **注:**、実装で内部的に使う配列にこの制限は適用されません。

 

| エラー番号 | メッセージ テキスト                                                                                                                                                     |
|--------------|--------------------|
| WME1034      | メソッド '{0}'型の配列が'{1}' そのシグネチャに下限を 0 以外のします。 Windows ランタイム メソッドのシグネチャ内の配列では、下限を 0 に指定する必要があります。 |
| WME1035      | メソッド '{0}'型の多次元配列には'{1}' そのシグネチャにします。 Windows ランタイム メソッドのシグネチャ内の配列は 1 次元配列にする必要があります。                  |
| WME1036      | メソッド '{0}'が、入れ子になった配列型の'{1}' そのシグネチャにします。 Windows ランタイム メソッドのシグネチャ内の配列を入れ子にすることはできません。                                    |

 

## <a name="array-parameters-must-specify-whether-array-contents-are-readable-or-writable"></a>配列パラメーターでは、配列の内容が読み取り可能であるか書き込み可能であるかどうかを指定する必要がある


UWP では、パラメーターは読み取り専用または書き込み専用に指定する必要があります。 パラメーターは、**ref** (Visual Basic では [OutAttribute](https://msdn.microsoft.com/library/system.runtime.interopservices.outattribute.aspx) 属性のない **ByRef**) とマークすることはできません。 これは配列の内容に適用されるため、配列パラメーターは配列の内容が読み取り専用または書き込み専用であるかどうかを示す必要があります。 **out** パラメーター (Visual Basic では OutAttribute 属性のある **ByRef** パラメーター) の方向は明確ですが、値によって渡される配列パラメーター (Visual Basic の ByVal) はマークする必要があります。 [「Windows ランタイム コンポーネントに配列を渡す方法」](passing-arrays-to-a-windows-runtime-component.md)をご覧ください。

| エラー番号 | メッセージ テキスト         |
|--------------|----------------------|
| WME1101      | メソッド '{0}'のパラメーターが'{1}' は配列、および両方を含み{2}と{3}します。 Windows ランタイムでは、配列パラメーターの内容は、読み取り可能または書き込み可能である必要があります。 属性の 1 つを削除してください"{1}' です。                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     |
| WME1102      | メソッド '{0}'が出力パラメーター'{1}' は配列では、ですが{2}します。 Windows ランタイムでは、出力配列の内容は書き込み可能です。 属性を削除してください"{1}' です。                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       |
| WME1103      | メソッド '{0}'のパラメーターが'{1}' は配列、および、System.Runtime.InteropServices.InAttribute または System.Runtime.InteropServices.OutAttribute のいずれかがあります。 ランタイムでは、Windows、配列パラメーターが必要か{2}または{3}します。 これらの属性を削除するか、必要に応じて、適切な Windows ランタイム属性と置き換えてください。                                                                                                                                                                                                                                                                                                                                                                                          |
| WME1104      | メソッド '{0}'のパラメーターが'{1}' は配列ではなく、いずれかが、{2}または{3}します。 Windows ランタイムは非配列パラメーターにマークすることをサポートしていません{2}または{3}します。                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        |
| WME1105      | メソッド '{0}'のパラメーターが'{1}'、System.Runtime.InteropServices.InAttribute または System.Runtime.InteropServices.OutAttribute します。 Windows ランタイムでは、System.Runtime.InteropServices.InAttribute または System.Runtime.InteropServices.OutAttribute でパラメーターをマークすることはサポートされていません。 System.Runtime.InteropServices.InAttribute を削除して、System.Runtime.InteropServices.OutAttribute を 'out' 修飾子と置き換えることを検討してください。 メソッド '{0}'のパラメーターが'{1}'、System.Runtime.InteropServices.InAttribute または System.Runtime.InteropServices.OutAttribute します。 Windows ランタイムでは、System.Runtime.InteropServices.OutAttribute で ByRef パラメーターをマークすることのみサポートされており、これらの属性の他の使用方法はサポートされていません。 |
| WME1106      | メソッド '{0}'のパラメーターが'{1}' は配列です。 Windows ランタイムでは、配列パラメーターの内容が読み取り可能または書き込み可能である必要があります。 いずれかにご登録ください{2}または{3}に '{1}' です。                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         |


## <a name="member-with-a-parameter-named-value"></a>"value" という名前のパラメーターを持つメンバー


UWP では、戻り値は出力パラメーターであると見なされ、パラメーターの名前は一意である必要があります。 既定では、Winmdexp.exe は戻り値に "value" という名前を設定します。 メソッドに "value" という名前のパラメーターがあると、エラー WME1092 が発生します。 これを修正するには 2 つの方法があります。

-   パラメーターに "value" 以外の名前を付けます (プロパティ アクセサーの場合は "returnValue" 以外の名前)。
-   次に示すように、ReturnValueNameAttribute 属性を使って戻り値の名前を変更します。

    > [!div class="tabbedCodeSnippets"]
    > ```cs
    > using System.Runtime.InteropServices;
    > using System.Runtime.InteropServices.WindowsRuntime;
    >
    > [return: ReturnValueName("average")]
    > public int GetAverage(out int lowValue, out int highValue)
    > ```
    > ```vb
    > Imports System.Runtime.InteropServices
    > Imports System.Runtime.InteropServices.WindowsRuntime
    >
    > Public Function GetAverage(<Out> ByRef lowValue As Integer, _
    > <Out> ByRef highValue As Integer) As <ReturnValueName("average")> String
    > ```

> **注:** 場合は、戻り値の名前を変更して、新しい名前が別のパラメーターの名前が、エラー WME1091 が発生します。

JavaScript コードは、戻り値も含め、メソッドの出力パラメーターに名前でアクセスできます。 例については、[ReturnValueNameAttribute](https://msdn.microsoft.com/library/windows/apps/system.runtime.interopservices.windowsruntime.returnvaluenameattribute.aspx) 属性に関するトピックをご覧ください。

| エラー番号 | メッセージ テキスト |
|--------------|--------------|
| WME1091 | メソッド '\{0}' という名前の戻り値が '\{1}' は、パラメーター名と同じです。 Windows ランタイム メソッドのパラメーターと戻り値には一意の名前を指定する必要があります。 |
| WME1092 | メソッド '\{0}' という名前のパラメーターには '\{1}' は、既定値と同じの戻り値の名前。 このパラメーターに別の名前を使用するか、System.Runtime.InteropServices.WindowsRuntime.ReturnValueNameAttribute を使用して、戻り値の名前を明示的に指定してください。 |

**注:** 既定の名前は、他のすべてのメソッドには、"value"と"returnValue"プロパティのアクセサーに対してします。


## <a name="related-topics"></a>関連トピック

* [C# および Visual Basic での Windows ランタイム コンポーネントの作成](creating-windows-runtime-components-in-csharp-and-visual-basic.md)
* [Winmdexp.exe (Windows ランタイム メタデータ エクスポート ツール)](https://msdn.microsoft.com/library/hh925576.aspx)
