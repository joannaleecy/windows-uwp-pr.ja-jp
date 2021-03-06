---
ms.assetid: D06AA3F5-CED6-446E-94E8-713D98B13CAA
title: デバイス セレクターのビルド
description: デバイス セレクターを作成すると、デバイスを列挙するときに、検索するデバイスを絞り込むことができるようになります。
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 01a4bfc2ec4c1d442058dbb6009065541f93cc7f
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57652497"
---
# <a name="build-a-device-selector"></a>デバイス セレクターのビルド



**重要な API**

- [**Windows.Devices.Enumeration**](https://docs.microsoft.com/en-us/uwp/api/Windows.Devices.Enumeration)

デバイス セレクターを作成すると、デバイスを列挙するときに、検索するデバイスを絞り込むことができるようになります。 これにより、関連する結果のみを取得することができ、システムのパフォーマンスも向上します。 多くのシナリオでは、デバイス スタックからデバイス セレクターを取得します。 たとえば、USB 経由で検出したデバイスに [**GetDeviceSelector**](https://msdn.microsoft.com/library/windows/apps/Dn264015) を使うとします。 これらのデバイス セレクターは高度なクエリ構文 (AQS) 文字列を返します。 AQS 形式を初めて使う場合は、「[プログラムでの高度なクエリ構文の使用](https://msdn.microsoft.com/library/windows/desktop/Bb266512)」をご覧ください。

## <a name="building-the-filter-string"></a>フィルター文字列の作成

デバイスを列挙する必要があるにもかかわらず、提供されたデバイス セレクターを目的のシナリオで利用できないことがあります。 デバイス セレクターは、次の情報が含まれる AQS フィルター文字列です。 フィルター文字列を作成する前に、列挙するデバイスに関して、いくつかの重要な情報を知っておく必要があります。

-   目的のデバイスの [**DeviceInformationKind**](https://msdn.microsoft.com/library/windows/apps/Dn948991)。 デバイスの列挙への **DeviceInformationKind** の影響について詳しくは、「[デバイスの列挙](enumerate-devices.md)」をご覧ください。
-   このトピックで説明されている、AQS フィルター文字列を作成する方法。
-   目的のプロパティ。 使用可能なプロパティは [**DeviceInformationKind**](https://msdn.microsoft.com/library/windows/apps/Dn948991) によって異なります。 詳しくは、「[デバイス情報プロパティ](device-information-properties.md)」をご覧ください。
-   照会で経由するプロトコル。 ワイヤレスまたはワイヤード ネットワーク経由でデバイスを検索する場合にのみ必要です。 そのための方法について詳しくは、「[ネットワーク経由でデバイスを列挙する](enumerate-devices-over-a-network.md)」をご覧ください。

[  **Windows.Devices.Enumeration**](https://msdn.microsoft.com/library/windows/apps/BR225459) API を使うときは、多くの場合、デバイス セレクターを目的のデバイスの種類と組み合わせます。 利用可能なデバイスの種類の一覧は、[**DeviceInformationKind**](https://msdn.microsoft.com/library/windows/apps/Dn948991) 列挙値で定義されています。 この組み合わせは、利用可能なデバイスを目的のデバイスの種類に限定するために役立ちます。 **DeviceInformationKind** を指定しない場合、つまり、使うメソッドに **DeviceInformationKind** パラメーターを渡さない場合、既定の種類は **DeviceInterface** です。

[  **Windows.Devices.Enumeration**](https://msdn.microsoft.com/library/windows/apps/BR225459) API では、AQS の標準的な構文が使われますが、一部の演算子はサポートされていません。 フィルター文字列の作成に使えるプロパティの一覧については、「[デバイス情報プロパティ](device-information-properties.md)」をご覧ください。

**注意**  カスタム プロパティを使用して定義されている、 `{GUID} PID` AQS フィルター文字列を構築するときに、形式は使用できません。 これは、プロパティの型が一般的な既知のプロパティ名から派生しているためです。

 

次の表は、AQS 演算子とそれがサポートするパラメーターの型の一覧です。

| 演算子                       | サポートされる型                                                             |
|--------------------------------|-----------------------------------------------------------------------------|
| **COP\_と等しい**                 | 文字列、ブール値、GUID、UInt16、UInt32                                       |
| **COP\_NOTEQUAL**              | 文字列、ブール値、GUID、UInt16、UInt32                                       |
| **COP\_LESSTHAN**              | UInt16、UInt32                                                              |
| **COP\_GREATERTHAN**           | UInt16、UInt32                                                              |
| **COP\_LESSTHANOREQUAL**       | UInt16、UInt32                                                              |
| **COP\_GREATERTHANOREQUAL**    | UInt16、UInt32                                                              |
| **COP\_値\_CONTAINS**       | 文字列、文字列配列、ブール値配列、GUID 配列、UInt16 配列、UInt32 配列 |
| **COP\_値\_NOTCONTAINS**    | 文字列、文字列配列、ブール値配列、GUID 配列、UInt16 配列、UInt32 配列 |
| **COP\_値\_STARTSWITH**     | String                                                                      |
| **COP\_値\_ENDSWITH**       | String                                                                      |
| **COP\_DOSWILDCARDS**          | サポートされていません                                                               |
| **COP\_WORD\_と等しい**           | サポートされていません                                                               |
| **COP\_WORD\_STARTSWITH**      | サポートされていません                                                               |
| **COP\_アプリケーション\_特定** | サポートされていません                                                               |


> **ヒント:**  を指定できます**NULL**の**COP\_等しい**または**COP\_NOTEQUAL**します。 これは空のプロパティに変換されます。つまり、値は存在しません。 AQS で指定する**NULL**空のかっこを使用して\[\]します。

> **重要な**  を使用する場合、 **COP\_値\_CONTAINS**と**COP\_値\_NOTCONTAINS**演算子文字列および文字列配列で動作が異なります。 文字列の場合、大文字と小文字を区別する検索が実行され、デバイスに部分文字列として指定された文字列が含まれているかどうかを確認します。 文字列配列の場合、部分文字列は検索されません。 文字列配列を使って、配列を検索し、指定された文字列全体が含まれているかどうかを確認します。 配列内の要素に部分文字列が含まれているかどうかを確認するために、文字列配列を検索することはできません。

1 つの AQS フィルター文字列により結果を適切に絞り込むことができない場合は、受け取った結果をさらにフィルター処理できます。 ただしその場合は、最初の AQS フィルター文字列によりできる限り結果を絞り込んでから、[**Windows.Devices.Enumeration**](https://msdn.microsoft.com/library/windows/apps/BR225459) API に渡すことをお勧めします。 これにより、アプリのパフォーマンスを向上させることができます。

## <a name="aqs-string-examples"></a>AQS 文字列の例

ここで示している例では、AQS 構文を使って、列挙するデバイスを制限する方法を説明しています。 以下のフィルター文字列はすべて、[**DeviceInformationKind**](https://msdn.microsoft.com/library/windows/apps/Dn948991) とペアリングされており、完全なフィルターを作成できます。 どの種類も指定しない場合、既定の種類は **DeviceInterface** になります。

このフィルターを **DeviceInterface** の [**DeviceInformationKind**](https://msdn.microsoft.com/library/windows/apps/Dn948991) とペアリングすると、オーディオ キャプチャ インターフェイス クラスを含むオブジェクトと、現在有効なオブジェクトがすべて列挙されます。 **=** 変換されます**COP\_EQUALS**します。

``` syntax
System.Devices.InterfaceClassGuid:="{2eef81be-33fa-4800-9670-1cd474972c3f}" AND
System.Devices.InterfaceEnabled:=System.StructuredQueryType.Boolean#True
```

このフィルターを **Device** の [**DeviceInformationKind**](https://msdn.microsoft.com/library/windows/apps/Dn948991) とペアリングすると、GenCdRom のハードウェア ID を 1 つ以上持つオブジェクトがすべて列挙されます。 **~~** 変換されます**COP\_値\_CONTAINS**します。

``` syntax
System.Devices.HardwareIds:~~"GenCdRom"
```

このフィルターを **DeviceContainer** の [**DeviceInformationKind**](https://msdn.microsoft.com/library/windows/apps/Dn948991) とペアリングすると、部分文字列として Microsoft を含むモデル名を持つオブジェクトがすべて列挙されます。 **~~** 変換されます**COP\_値\_CONTAINS**します。

``` syntax
System.Devices.ModelName:~~"Microsoft"
```

このフィルターを **DeviceInterface** の [**DeviceInformationKind**](https://msdn.microsoft.com/library/windows/apps/Dn948991) とペアリングすると、部分文字列の Microsoft から始まる名前を持つオブジェクトがすべて列挙されます。 **~&lt;** 変換されます**COP\_STARTSWITH**します。

``` syntax
System.ItemNameDisplay:~<"Microsoft"
```

このフィルターを **Device** の [**DeviceInformationKind**](https://msdn.microsoft.com/library/windows/apps/Dn948991) とペアリングすると、**System.Devices.IpAddress** プロパティ セットを持つオブジェクトがすべて列挙されます。 **&lt;&gt;\[\]** 変換されます**COP\_NOTEQUALS**と組み合わせて、 **NULL**値。

``` syntax
System.Devices.IpAddress:<>[]
```

このフィルターを **Device** の [**DeviceInformationKind**](https://msdn.microsoft.com/library/windows/apps/Dn948991) とペアリングすると、**System.Devices.IpAddress** プロパティ セットを持たないオブジェクトがすべて列挙されます。 **=\[\]** 変換されます**COP\_EQUALS**と組み合わせて、 **NULL**値。

``` syntax
System.Devices.IpAddress:=[]
```

 

 
