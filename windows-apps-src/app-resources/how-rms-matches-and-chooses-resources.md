---
author: stevewhims
Description: When a resource is requested, there may be several candidates that match the current resource context to some degree. The Resource Management System will analyze all of the candidates and determine the best candidate to return. This topic describes that process in detail and gives examples.
title: リソース管理システムでのリソースの照合と選択の仕組み
template: detail.hbs
ms.author: stwhi
ms.date: 10/23/2017
ms.topic: article
keywords: Windows 10, UWP, リソース, 画像, アセット, MRT, 修飾子
ms.localizationpriority: medium
ms.openlocfilehash: d31c9fd3a6f8f57f3e78d88d3ad754d4848a9cad
ms.sourcegitcommit: 086001cffaf436e6e4324761d59bcc5e598c15ea
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5694148"
---
# <a name="how-the-resource-management-system-matches-and-chooses-resources"></a>リソース管理システムでのリソースの照合と選択の仕組み
リソースを要求すると、現在のリソース コンテキストにある程度一致するリソース候補がいくつか存在する場合があります。 リソース管理システムはすべての候補を分析して、返すのに最もよい候補を決定します。 これはすべての修飾子を考慮して、すべての候補をランク付けすることで実行されます。

このランク付けプロセスでは、修飾子が異なれば優先順位も異なります。言語は全体のランキングに最大の影響を及ぼし、コントラスト、スケールなどが続きます。 修飾子ごとに、候補の修飾子がコンテキスト修飾子の値と比較され、一致度が決定されます。 どのように比較がなされるかは、修飾子に左右されます。

言語タグの照合のしくみの詳細については、「[リソース管理システムでの言語タグの照合の仕組み](how-rms-matches-lang-tags.md)」を参照してください。

スケールやコントラストのような修飾子の場合、常に最低限の一致が存在します。 たとえば、修飾された候補は"scale-100「で修飾された候補といないです小さな程度"scale-400"のコンテキストに一致」200% スケール「または (完全一致の)」scale-400"します。

しかし、言語や住んでいる地域のような修飾子の場合、比較してもまったく一致しないことがあります (ある程度の一致の他に)。 たとえば、言語が "en-US" で修飾された候補は、"en-GB" というコンテキストに対して部分的に一致しますが、"fr" で修飾された候補はまったく一致しません。 同様に、住んでいる地域が "155" (西欧) で修飾された候補は、住んでいる地域の設定が "FR" のユーザーのコンテキストにある程度一致しますが、"US" で修飾された候補はまったく一致しません。

候補を評価するとき、比較してもまったく一致しない修飾子がある場合、その候補は全体としてのランキングが非一致となり、選ばれることはありません。 このようにして、最適な一致を選ぶときに優先順位の高い修飾子に最大の重みが与えられますが、優先順位が低い修飾子の場合でも、非一致によって候補から除外されることはあります。

ある修飾子でまったくマークされていない場合、候補はその修飾子に関しては中立です。 どの修飾子でも、中立の候補は常にコンテキスト修飾子の値に一致しますが、その修飾子でマークされ、ある程度の一致 (厳密または部分) の候補よりも一致度は低くなります。 たとえば、"en-US"、"en"、"fr" で修飾された候補があり、言語中立のリソースもある場合、言語修飾子の値が "en-GB" のコンテキストでは、各候補は、"en"、"en-US"、中立、"fr" の順にランク付けされます。 この場合、"fr" はまったく一致しませんが、他の候補はある程度一致しています。

全体的なランク付けプロセスは、優先順位の最も高い修飾子である言語に関する候補の評価から始まります。 非一致は除外されます。 残りの候補は、言語の一致度に応じてランク付けされます。 ランクが同じ場合、次に優先順位の高い修飾子であるコントラストが検討され、コントラストの一致度を使って、ランクの同じ候補が区別されます。 コントラストの後は、スケールの修飾子が残りの区別に使われます。同様にして、ランキングの順位が確定するまで、必要なだけ修飾子が比較されます。

修飾子がコンテキストに一致しないためすべての候補が検討対象から除外された場合、リソース ローダーは、2 番目のパスに移行して、表示する既定の候補を検索します。 既定の候補は、PRI ファイルの作成時に決定され、どのランタイム コンテキストでも選択候補が常に残るようにするために必要です。 候補が持ついずれかの修飾子が一致せず、既定値でない場合、そのリソース候補は完全に検討対象から除外されます。

検討対象として残っているすべてのリソース候補に対し、リソース ローダーは優先順位が最も高いコンテキスト修飾子の値に基づき、最も一致するものまたは既定のスコアが最も一致するものを選びます。 実際に一致する値は、既定のスコアよりも優先されます。

一致度が同じ場合、次に優先順位が高いコンテキスト修飾子の値が調べられます。最も一致するものが見つかるまで、この操作が続けられます。

## <a name="example-of-choosing-a-resource-candidate"></a>リソース候補を選択する例
次のようなファイルがあるとします。

```
en/images/logo.scale-400.jpg
en/images/logo.scale-200.jpg
en/images/logo.scale-100.jpg  
fr/images/logo.scale-100.jpg
fr/images/contrast-high/logo.scale-400.jpg
fr/images/contrast-high/logo.scale-100.jpg
de/images/logo.jpg
```

また、現在のコンテキストの設定は次のようになっているとします。

```
Application language: en-US; fr-FR;
Scale: 400
Contrast: Standard
```

ハイ コントラストとドイツ語はこの設定に定義されているコンテキストに一致しないため、リソース管理システムによって 3 つのファイルが除外されます。 これによって、次の候補が残ります。

```
en/images/logo.scale-400.jpg
en/images/logo.scale-200.jpg
en/images/logo.scale-100.jpg  
fr/images/logo.scale-100.jpg
```

これらの残りの候補について、リソース管理システムは、優先度が最も高いコンテキスト修飾子である言語を使用します。 設定で英語がフランス語よりも先にリストされているため、英語のリソースはフランス語のリソースよりも一致率が高くなります。

```
en/images/logo.scale-400.jpg
en/images/logo.scale-200.jpg
en/images/logo.scale-100.jpg  
```

次に、リソース管理システムでは、次に優先順位の高いコンテキスト修飾子であるスケールを使用します。 このため、次のリソースが返されます。

```
en/images/logo.scale-400.jpg
```

高度な [**NamedResource.ResolveAll**](/uwp/api/windows.applicationmodel.resources.core.namedresource.resolveall?branch=live) メソッドを使うと、コンテキスト設定に一致する順にすべての候補を取得できます。 前述の例では、**ResolveAll** は次の順序で候補を返します。

```
en/images/logo.scale-400.jpg
en/images/logo.scale-200.jpg
en/images/logo.scale-100.jpg  
fr/images/logo.scale-100.jpg
```

## <a name="example-of-producing-a-fallback-choice"></a>フォールバック選択肢を生成する例
次のようなファイルがあるとします。

```
en/images/logo.scale-400.jpg
en/images/logo.scale-200.jpg
en/images/logo.scale-100.jpg  
fr/images/contrast-standard/logo.scale-400.jpg
fr/images/contrast-standard/logo.scale-100.jpg
de/images/contrast-standard/logo.jpg
```

また、現在のコンテキストの設定は次のようになっているとします。

```
User language: de-DE;
Scale: 400
Contrast: High
```

すべてのファイルがコンテキストに一致しないため、除外されます。 そこで、既定のパスが使われます。PRI ファイルの作成時の既定値は次のようになっていました (「[MakePri.exe を使用して手動でリソースをコンパイルする](compile-resources-manually-with-makepri.md)」をご覧ください)。

```
Language: fr-FR;
Scale: 400
Contrast: Standard
```

これにより、現在のユーザーまたは既定値に一致するすべてのリソースが候補となります。

```
fr/images/contrast-standard/logo.scale-400.jpg
fr/images/contrast-standard/logo.scale-100.jpg
de/images/contrast-standard/logo.jpg
```

リソース管理システムは、優先順位が最も高いコンテキスト修飾子である言語を使って、スコアが最も高い名前付きリソースを返します。

```
de/images/contrast-standard/logo.jpg
```

## <a name="important-apis"></a>重要な API
* [NamedResource.ResolveAll](/uwp/api/windows.applicationmodel.resources.core.namedresource.resolveall?branch=live)

## <a name="related-topics"></a>関連トピック
* [MakePri.exe を使用して手動でリソースをコンパイルする](compile-resources-manually-with-makepri.md)