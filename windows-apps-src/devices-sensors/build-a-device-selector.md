---
author: DBirtolo
ms.assetid: D06AA3F5-CED6-446E-94E8-713D98B13CAA
title: デバイス セレクターのビルド
description: デバイス セレクターを作成すると、デバイスを列挙するときに、検索するデバイスを絞り込むことができるようになります。
---
# デバイス セレクターのビルド

\[ Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\ ]


** 重要な API **

-   [**Windows.Devices.Enumeration**](https://msdn.microsoft.com/library/windows/apps/BR225459)

デバイス セレクターを作成すると、デバイスを列挙するときに、検索するデバイスを絞り込むことができるようになります。 これにより、関連する結果のみを取得することができ、システムのパフォーマンスも向上します。 多くのシナリオでは、デバイス スタックからデバイス セレクターを取得します。 たとえば、USB 経由で検出したデバイスに [**GetDeviceSelector**](https://msdn.microsoft.com/library/windows/apps/Dn264015) を使うとします。 これらのデバイス セレクターは高度なクエリ構文 (AQS) 文字列を返します。 AQS 形式を初めて使う場合は、「[プログラムでの高度なクエリ構文の使用](https://msdn.microsoft.com/library/windows/desktop/Bb266512)」をご覧ください。

## フィルター文字列の作成

デバイスを列挙する必要があるにもかかわらず、提供されたデバイス セレクターを目的のシナリオで利用できないことがあります。 デバイス セレクターは、次の情報が含まれる AQS フィルター文字列です。 フィルター文字列を作成する前に、列挙するデバイスに関して、いくつかの重要な情報を知っておく必要があります。

-   目的のデバイスの [**DeviceInformationKind**](https://msdn.microsoft.com/library/windows/apps/Dn948991)。 デバイスの列挙への **DeviceInformationKind** の影響について詳しくは、「[デバイスの列挙](enumerate-devices.md)」をご覧ください。
-   このトピックで説明されている、AQS フィルター文字列を作成する方法。
-   目的のプロパティ。 使用可能なプロパティは [**DeviceInformationKind**](https://msdn.microsoft.com/library/windows/apps/Dn948991) によって異なります。 詳しくは、「[デバイス情報プロパティ](device-information-properties.md)」をご覧ください。
-   照会で経由するプロトコル。 ワイヤレスまたはワイヤード ネットワーク経由でデバイスを検索する場合にのみ必要です。 そのための方法について詳しくは、「[ネットワーク経由でデバイスを列挙する](enumerate-devices-over-a-network.md)」をご覧ください。

[
            **Windows.Devices.Enumeration**](https://msdn.microsoft.com/library/windows/apps/BR225459) API を使うときは、多くの場合、デバイス セレクターを目的のデバイスの種類と組み合わせます。 利用可能なデバイスの種類の一覧は、[**DeviceInformationKind**](https://msdn.microsoft.com/library/windows/apps/Dn948991) 列挙値で定義されています。 この組み合わせは、利用可能なデバイスを目的のデバイスの種類に限定するために役立ちます。 **DeviceInformationKind** を指定しない場合、つまり、使うメソッドに **DeviceInformationKind** パラメーターを渡さない場合、既定の種類は **DeviceInterface** です。

[
            **Windows.Devices.Enumeration**](https://msdn.microsoft.com/library/windows/apps/BR225459) API では、AQS の標準的な構文が使われますが、一部の演算子はサポートされていません。 フィルター文字列の作成に使えるプロパティの一覧については、「[デバイス情報プロパティ](device-information-properties.md)」をご覧ください。

**注意:** `{GUID} PID` 形式を使って定義したカスタム プロパティは AQS フィルター文字列の作成に使えません。 これは、プロパティの型が一般的な既知のプロパティ名から派生しているためです。

 

次の表は、AQS 演算子とそれがサポートするパラメーターの型の一覧です。

| 演算子                       | サポートされる型                                                             |
|--------------------------------|-----------------------------------------------------------------------------|
| **COP\_EQUAL**                 | 文字列、ブール値、GUID、UInt16、UInt32                                       |
| **COP\_NOTEQUAL**              | 文字列、ブール値、GUID、UInt16、UInt32                                       |
| **COP\_LESSTHAN**              | UInt16、UInt32                                                              |
| **COP\_GREATERTHAN**           | UInt16、UInt32                                                              |
| **COP\_LESSTHANOREQUAL**       | UInt16、UInt32                                                              |
| **COP\_GREATERTHANOREQUAL**    | UInt16、UInt32                                                              |
| **COP\_VALUE\_CONTAINS**       | 文字列、文字列配列、ブール値配列、GUID 配列、UInt16 配列、UInt32 配列 |
| **COP\_VALUE\_NOTCONTAINS**    | 文字列、文字列配列、ブール値配列、GUID 配列、UInt16 配列、UInt32 配列 |
| **COP\_VALUE\_STARTSWITH**     | 文字列                                                                      |
| **COP\_VALUE\_ENDSWITH**       | 文字列                                                                      |
| **COP\_DOSWILDCARDS**          | サポートされていません                                                               |
| **COP\_WORD\_EQUAL**           | サポートされていません                                                               |
| **COP\_WORD\_STARTSWITH**      | サポートされていません                                                               |
| **COP\_APPLICATION\_SPECIFIC** | サポートされていません                                                               |


> **ヒント:** **COP\_EQUAL** または **COP\_NOTEQUAL** に **NULL** を指定できます。 これは空のプロパティに変換されます。つまり、値は存在しません。 AQS では、空のかっこ \[\] を使って **NULL** を指定できます。

> **重要:** **COP\_VALUE\_CONTAINS** および **COP\_VALUE\_NOTCONTAINS** の演算子を使うと、文字列と文字列配列で異なる動作をします。 文字列の場合、大文字と小文字を区別する検索が実行され、デバイスに部分文字列として指定された文字列が含まれているかどうかを確認します。 文字列配列の場合、部分文字列は検索されません。 文字列配列を使って、配列を検索し、指定された文字列全体が含まれているかどうかを確認します。 配列内の要素に部分文字列が含まれているかどうかを確認するために、文字列配列を検索することはできません。

1 つの AQS フィルター文字列により結果を適切に絞り込むことができない場合は、受け取った結果をさらにフィルター処理できます。 ただしその場合は、最初の AQS フィルター文字列によりできる限り結果を絞り込んでから、[**Windows.Devices.Enumeration**](https://msdn.microsoft.com/library/windows/apps/BR225459) API に渡すことをお勧めします。 これにより、アプリのパフォーマンスを向上させることができます。

## AQS 文字列の例

ここで示している例では、AQS 構文を使って、列挙するデバイスを制限する方法を説明しています。 以下のフィルター文字列はすべて、[**DeviceInformationKind**](https://msdn.microsoft.com/library/windows/apps/Dn948991) とペアリングされており、完全なフィルターを作成できます。 どの種類も指定しない場合、既定の種類は **DeviceInterface** になります。

このフィルターを **DeviceInterface** の [**DeviceInformationKind**](https://msdn.microsoft.com/library/windows/apps/Dn948991) とペアリングすると、オーディオ キャプチャ インターフェイス クラスを含むオブジェクトと、現在有効なオブジェクトがすべて列挙されます。 **
              =
            ** は **COP\_EQUALS** に変換されます。

``` syntax
System.Devices.InterfaceClassGuid:="{2eef81be-33fa-4800-9670-1cd474972c3f}" AND 
System.Devices.InterfaceEnabled:=System.StructuredQueryType.Boolean#True
```

このフィルターを **Device** の [**DeviceInformationKind**](https://msdn.microsoft.com/library/windows/apps/Dn948991) とペアリングすると、GenCdRom のハードウェア ID を 1 つ以上持つオブジェクトがすべて列挙されます。 **
              ~~
            ** は **COP\_VALUE\_CONTAINS** に変換されます。

``` syntax
System.Devices.HardwareIds:~~"GenCdRom"
```

このフィルターを **DeviceContainer** の [**DeviceInformationKind**](https://msdn.microsoft.com/library/windows/apps/Dn948991) とペアリングすると、部分文字列として Microsoft を含むモデル名を持つオブジェクトがすべて列挙されます。 **
              ~~
            ** は **COP\_VALUE\_CONTAINS** に変換されます。

``` syntax
System.Devices.ModelName:~~"Microsoft"
```

このフィルターを **DeviceInterface** の [**DeviceInformationKind**](https://msdn.microsoft.com/library/windows/apps/Dn948991) とペアリングすると、部分文字列の Microsoft から始まる名前を持つオブジェクトがすべて列挙されます。 **
              ~&lt;
            ** は **COP\_STARTSWITH** に変換されます。

``` syntax
System.ItemNameDisplay:~<"Microsoft"
```

このフィルターを **Device** の [**DeviceInformationKind**](https://msdn.microsoft.com/library/windows/apps/Dn948991) とペアリングすると、**System.Devices.IpAddress** プロパティ セットを持つオブジェクトがすべて列挙されます。 **
              &lt;&gt;\[\]** は、**NULL** 値を組み合わせた **COP\_NOTEQUALS** に変換されます。

``` syntax
System.Devices.IpAddress:<>[]
```

このフィルターを **Device** の [**DeviceInformationKind**](https://msdn.microsoft.com/library/windows/apps/Dn948991) とペアリングすると、**System.Devices.IpAddress** プロパティ セットを持たないオブジェクトがすべて列挙されます。 **=\[\]** は、**NULL** 値を組み合わせた **COP\_EQUALS** に変換されます。

``` syntax
System.Devices.IpAddress:=[]
```

 

 






<!--HONumber=May16_HO2-->


