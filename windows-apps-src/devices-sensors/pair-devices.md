---
author: muhsinking
ms.assetid: F8A741B4-7A6A-4160-8C5D-6B92E267E6EA
title: デバイスのペアリング
description: 一部のデバイスは、使う前にペアリングする必要があります。 Windows.Devices.Enumeration 名前空間では、デバイスをペアリングするための 3 つの異なる方法がサポートされています。
ms.author: mukin
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 64f4756df37cbfaf041e432b7e4a890123f52d2f
ms.sourcegitcommit: 3257416aebb5a7b1515e107866806f8bd57845a8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/16/2018
ms.locfileid: "7147948"
---
# <a name="pair-devices"></a>デバイスのペアリング



**重要な API**

- [**Windows.Devices.Enumeration**](https://docs.microsoft.com/en-us/uwp/api/Windows.Devices.Enumeration)

一部のデバイスは、使う前にペアリングする必要があります。 [**Windows.Devices.Enumeration**](https://msdn.microsoft.com/library/windows/apps/BR225459) 名前空間では、デバイスをペアリングするための 3 つの異なる方法がサポートされています。

-   自動ペアリング
-   基本ペアリング
-   カスタム ペアリング

**ヒント:** 一部のデバイスを使用するためにペアリングする必要はありません。 これについては、自動ペアリングに関するセクションで説明します。

 

## <a name="automatic-pairing"></a>自動ペアリング


アプリケーションでデバイスを使いたいが、デバイスがペアリングされているかどうかは重要でない場合があります。 単に、デバイスに関連付けられている機能を使用できるようにする場合です。 たとえば、アプリで Web カメラからイメージをキャプチャするだけの場合、必ずしもデバイス自体ではなく、イメージのキャプチャだけが重要となります。 対象のデバイスで使用できるデバイス API がある場合は、自動ペアリングが該当します。

この場合は、単にデバイスに関連付けられている API を使い、必要に応じて呼び出しを行い、必要になる可能性のあるペアリングをシステムが処理することを信頼します。 機能を使うためにペアリングする必要がないデバイスもあります。 デバイスをペアリングする必要がない場合、デバイス API はバックグラウンドでペアリング アクションを処理するため、アプリにその機能を統合する必要はありません。 アプリには、特定のデバイスがペアリングされているかや、ペアリングする必要があるかどうかに関する情報がありませんが、それでもデバイスにアクセスし、その機能を使うことができます。

## <a name="basic-pairing"></a>基本ペアリング


基本ペアリングは、アプリケーションがデバイスのペアリングを試行するために [**Windows.Devices.Enumeration**](https://msdn.microsoft.com/library/windows/apps/BR225459) API を使うときに行われます。 このシナリオでは、Windows にペアリングの試行とその処理を許可します。 ユーザーの操作が必要な場合は、Windows によって処理されます。 また、デバイスのペアリングが必要な場合や、自動ペアリングを試行する、関連するデバイス API がない場合も、基本ペアリングを使用します。 単に、デバイスを使用できるようにする場合でも、最初にペアリングする必要があります。

基本ペアリングを試行するためには、対象のデバイス用の [**DeviceInformation**](https://msdn.microsoft.com/library/windows/apps/BR225393) オブジェクトを最初に入手する必要があります。 オブジェクトを入手したら、[**DeviceInformation.Pairing**](https://msdn.microsoft.com/library/windows/apps/windows.devices.enumeration.deviceinformation.pairing.aspx) プロパティを操作します。これは、[**DeviceInformationPairing**](https://msdn.microsoft.com/library/windows/apps/windows.devices.enumeration.deviceinformation.pairing.aspx) オブジェクトです。 ペアリングを試みるには、[**DeviceInformationPairing.PairAsync**](https://msdn.microsoft.com/library/windows/apps/mt608800) を呼び出します。 ペアリング アクションの完了を試みる時間をアプリに与えるために、結果を **await** する必要があります。 ペアリング アクションの結果が返され、エラーが返されない限り、デバイスはペアリングされます。

基本ペアリングを使っている場合は、デバイスのペアリング状態に関する追加情報にもアクセスできます。 たとえば、ペアリング状態 ([**IsPaired**](https://docs.microsoft.com/en-us/uwp/api/Windows.Devices.Enumeration.DeviceInformationPairing.IsPaired)) と、デバイスがペアリングできるかどうか ([**CanPair**](https://docs.microsoft.com/en-us/uwp/api/Windows.Devices.Enumeration.DeviceInformationPairing.CanPair)) がわかります。 これらはどちらも [**DeviceInformationPairing**](https://msdn.microsoft.com/library/windows/apps/windows.devices.enumeration.deviceinformation.pairing.aspx) オブジェクトのプロパティです。 自動ペアリングを使っている場合、該当する [**DeviceInformation**](https://msdn.microsoft.com/library/windows/apps/BR225393) オブジェクトを入手しない限り、この情報にアクセスできない可能性があります。

## <a name="custom-pairing"></a>カスタム ペアリング


カスタム ペアリングでは、アプリでペアリング プロセスを処理できます。 これにより、アプリはペアリング プロセス用にサポートされている [**DevicePairingKinds**](https://msdn.microsoft.com/library/windows/apps/Mt608808) を指定できます。 必要に応じて、ユーザーと対話する独自のユーザー インターフェイスも作成します。 ペアリング プロセスの進行に対するアプリの影響を少し高めたり、独自のペアリング ユーザー インターフェイスを表示するときに、カスタム ペアリングを使います。

カスタム ペアリングを実装するためには、基本ペアリングと同じように、対象のデバイス用の [**DeviceInformation**](https://msdn.microsoft.com/library/windows/apps/BR225393) オブジェクトを入手する必要があります。 ただし、重要な特定のプロパティは [**DeviceInformation.Pairing.Custom**](https://msdn.microsoft.com/library/windows/apps/windows.devices.enumeration.deviceinformationpairing.custom.aspx) になります。 これにより、[**DeviceInformationCustomPairing**](https://msdn.microsoft.com/library/windows/apps/windows.devices.enumeration.deviceinformationcustompairing.aspx) オブジェクトを取得できます。 すべての [**DeviceInformationCustomPairing.PairAsync**](https://msdn.microsoft.com/library/windows/apps/windows.devices.enumeration.deviceinformationcustompairing.pairasync.aspx) メソッドでは、[**DevicePairingKinds**](https://msdn.microsoft.com/library/windows/apps/Mt608808) パラメーターを含める必要があります。 これは、デバイスのペアリングを試みるためにユーザーが必要とするアクションを示します。 ユーザーが実行する必要があるアクションとその種類について詳しくは、**DevicePairingKinds** のリファレンス ページをご覧ください。 基本ペアリングと同様に、ペアリング アクションの完了を試みる時間をアプリに与えるために、結果を **await** する必要があります。 ペアリング アクションの結果が返され、エラーが返されない限り、デバイスはペアリングされます。

カスタム ペアリングをサポートするため、[**PairingRequested**](https://msdn.microsoft.com/library/windows/apps/windows.devices.enumeration.deviceinformationcustompairing.pairingrequested.aspx) イベントのハンドラーを作成する必要があります。 このハンドラーでは、カスタム ペアリング シナリオで使われる可能性のあるすべての異なる [**DevicePairingKinds**](https://msdn.microsoft.com/library/windows/apps/Mt608808) を必ず考慮する必要があります。 実行する適切なアクションは、イベント引数の一部として提供される **DevicePairingKinds** によって異なります。

カスタム ペアリングは常にシステム レベルの操作であることを認識することが重要です。 このため、デスクトップまたは Windows Phone を操作している場合、ペアリングが発生するときに、システム ダイアログが常にユーザーに表示されます。 これは、これらの両方のプラットフォームが、ユーザーの同意を必要とするユーザー エクスペリエンスを発生させるためです。 このダイアログは自動的に生成されるため、これらのプラットフォームを使用中に **ConfirmOnly** の [**DevicePairingKinds**](https://msdn.microsoft.com/library/windows/apps/Mt608808) を選ぶ場合に、独自のダイアログを作る必要はありません。 他の **DevicePairingKinds** については、特定の **DevicePairingKinds** 値に応じて、いくつかの特別な処理を実行する必要があります。 さまざまな **DevicePairingKinds** の値のカスタム ペアリングを処理する方法の例については、サンプルをご覧ください。

## <a name="unpairing"></a>ペアリング解除


デバイスのペアリング解除が該当するのは、上記で説明した基本ペアリングまたはカスタム ペアリングのシナリオのみです。 自動ペアリングを使っている場合、アプリはデバイスのペアリング状態を記憶しないため、ペアリング解除する必要はありません。 それでもデバイスをペアリング解除する場合のプロセスは、実装するのが基本ペアリングまたはカスタム ペアリングかにかかわらず同じです。 これは、追加情報を提供したり、ペアリング解除プロセスにかかわったりする必要がないためです。

デバイスをペアリング解除する最初の手順は、ペアリング解除するデバイスの [**DeviceInformation**](https://msdn.microsoft.com/library/windows/apps/BR225393) オブジェクトを入手することです。 次に、[**DeviceInformation.Pairing**](https://msdn.microsoft.com/library/windows/apps/windows.devices.enumeration.deviceinformation.pairing.aspx) プロパティを取得し、[**DeviceInformationPairing.UnpairAsync**](https://msdn.microsoft.com/library/windows/apps/windows.devices.enumeration.deviceinformationpairing.unpairasync) を呼び出す必要があります。 ペアリングと同様に、結果を **await** します。 ペアリング解除アクションの結果が返され、エラーが返されない限り、デバイスはペアリング解除されます。

## <a name="sample"></a>サンプル


[**Windows.Devices.Enumeration**](https://msdn.microsoft.com/library/windows/apps/BR225459) API の使い方を示すサンプルをダウンロードするには、[ここ](http://go.microsoft.com/fwlink/?LinkID=620536)をクリックしてください。

 

 
