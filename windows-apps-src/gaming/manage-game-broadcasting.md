---
author: drewbatgit
ms.assetid: ''
description: UWP アプリのゲームのブロードキャストを管理する方法を示します。
title: ゲームのブロードキャストを管理する
ms.author: drewbat
ms.date: 09/27/2017
ms.topic: article
keywords: Windows 10, ゲーム, ブロードキャスト
ms.localizationpriority: medium
ms.openlocfilehash: ae70c29927925abcf948435ed768871ba2427fd9
ms.sourcegitcommit: 70ab58b88d248de2332096b20dbd6a4643d137a4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/01/2018
ms.locfileid: "5929923"
---
# <a name="manage-game-broadcasting"></a>ゲームのブロードキャストを管理する
この記事では、UWP アプリのゲームのブロードキャストを管理する方法を示します。 ユーザーは、Windows に組み込まれているシステム UI を使用してゲームのブロードキャストを開始する必要がありますが、Windows 10 バージョン 1709 以降、アプリでシステムのブロードキャスト UI を起動でき、ブロードキャストが開始および停止されたときには通知を受信できます。

## <a name="add-the-windows-desktop-extensions-for-the-uwp-to-your-app"></a>UWP 用の Windows デスクトップ拡張機能をアプリに追加する
アプリのブロードキャストを管理するための API は、**[Windows.Media.AppBroadcasting](https://docs.microsoft.com/uwp/api/windows.media.appbroadcasting)** 名前空間にあり、ユニバーサル API コントラクトに含まれていません。 この API にアクセスするには、次の手順に従って、UWP 用の Windows デスクトップ拡張機能への参照をアプリに追加する必要があります。

1. Visual Studio の**ソリューション エクスプローラー**で、UWP プロジェクトを展開し、**[参照]** を右クリックして、**[参照の追加]** を選択します。 
2. **[ユニバーサル Windows]** ノードを展開し、**[拡張機能]** を選択します。
3. 拡張機能の一覧で、プロジェクトのターゲット ビルドに一致する **[Windows Desktop Extensions for the UWP]** エントリの横にあるチェック ボックスをオンにします。 アプリのブロードキャスト機能を使用するには、バージョンが 1709 以上である必要があります。
4. **[OK]** をクリックします。

## <a name="launch-the-system-ui-to-allow-the-user-to-initiate-broadcasting"></a>システム UI を起動して、ユーザーがブロードキャストを開始できるようにします。
現在、アプリでブロードキャストできない場合は、いくつかの原因があります。たとえば、現在のデバイスがブロードキャストのハードウェア要件を満たしていない場合や、別のアプリが現在ブロードキャストしている場合です。 システム UI を起動する前に、アプリが現在ブロードキャストできるかどうかを確認できます。 最初に、ブロードキャスト API が現在のデバイスで利用可能かどうかを確認します。 この API は、Windows 10 バージョン 1709 より前のバージョンの OS を実行しているデバイスでは利用できません。 特定の OS バージョンを確認するのではなく、**[ApiInformation.IsApiContractPresent](https://docs.microsoft.com/uwp/api/windows.foundation.metadata.apiinformation.isapicontractpresent)** メソッドで、*Windows.Media.AppBroadcasting.AppBroadcastingContract* バージョン 1.0 を照会します。 このコントラクトが存在する場合は、デバイスでブロードキャスト API を利用できます。

次に、一度に 1 人のユーザーがサインインしている PC で、ファクトリ メソッド **[GetDefault](https://docs.microsoft.com/uwp/api/windows.media.appbroadcasting.appbroadcastingui.GetDefault)** を呼び出すことによって、**[AppBroadcastingUI](https://docs.microsoft.com/uwp/api/windows.media.appbroadcasting.appbroadcastingui)** クラスのインスタンスを取得します。 複数のユーザーがログインできる XBox では、代わりに **[GetForUser](https://docs.microsoft.com/uwp/api/windows.media.appbroadcasting.appbroadcastingui.getforuser)** を呼び出します。 次に、**[GetStatus](https://docs.microsoft.com/uwp/api/windows.media.appbroadcasting.appbroadcastingui.GetStatus)** を呼び出して、アプリのブロードキャストの状態を取得します。

**AppBroadcastingStatus** クラスの **[CanStartBroadcast](https://docs.microsoft.com/uwp/api/windows.media.appbroadcasting.appbroadcastingstatus.CanStartBroadcast)** プロパティは、アプリが現在ブロードキャストを開始できるかどうかを通知します。 開始できない場合は、**[Details](https://docs.microsoft.com/uwp/api/windows.media.appbroadcasting.appbroadcastingstatus.Details)** プロパティを調べて、ブロードキャストを利用できない理由を確認できます。 理由に応じて、ユーザーに対してステータスを表示したり、ブロードキャストを有効にするための手順を示したりすることができます。

[!code-cpp[CanStartBroadcast](./code/AppBroadcast/cpp/AppBroadcastExampleApp/App.cpp#SnippetCanStartBroadcast)]

**[ShowBroadcastUI](https://docs.microsoft.com/uwp/api/windows.media.appbroadcasting.appbroadcastingui.ShowBroadcastUI)** を呼び出すことによって、アプリのブロードキャスト UI をシステムで表示することを要求します。

> [!NOTE] 
> **ShowBroadcastUI** メソッドは、システムの現在の状態に応じて、成功しない可能性がある要求を示します。 アプリでは、このメソッドを呼び出した後、ブロードキャストが開始済みであることを想定しないでください。 ブロードキャストが開始または停止するときに通知される **[IsCurrentAppBroadcastingChanged](https://docs.microsoft.com/uwp/api/windows.media.appbroadcasting.appbroadcastingmonitor.IsCurrentAppBroadcastingChanged)** イベントを使用します。

[!code-cpp[LaunchBroadcastUI](./code/AppBroadcast/cpp/AppBroadcastExampleApp/App.cpp#SnippetLaunchBroadcastUI)]

## <a name="receive-notifications-when-broadcasting-starts-and-stops"></a>ブロードキャストが開始および停止するときに通知を受信する
ユーザーがシステム UI を使用して、**[AppBroadcastingMonitor](https://docs.microsoft.com/uwp/api/windows.media.appbroadcasting.appbroadcastingmonitor)** クラスのインスタンスを初期化し、**[IsCurrentAppBroadcastingChanged](https://docs.microsoft.com/uwp/api/windows.media.appbroadcasting.appbroadcastingmonitor.IsCurrentAppBroadcastingChanged)** イベントのハンドラーを登録することによって、アプリのブロードキャストを開始または停止するときに通知を受信することを登録します。 前のセクションで説明したように、必ずある時点で **[ApiInformation.IsApiContractPresent](https://docs.microsoft.com/uwp/api/windows.foundation.metadata.apiinformation.isapicontractpresent)** を使用して、ブロードキャスト API を使用する前に、デバイスにブロードキャスト API が存在することを確認します。 

[!code-cpp[AppBroadcastingRegisterChangedHandler](./code/AppBroadcast/cpp/AppBroadcastExampleApp/App.cpp#SnippetAppBroadcastingRegisterChangedHandler)]

**IsCurrentAppBroadcastingChanged** イベントのハンドラーで、現在のブロードキャストの状態を反映するように、アプリの UI を更新することもできます。

[!code-cpp[AppBroadcastingChangedHandler](./code/AppBroadcast/cpp/AppBroadcastExampleApp/App.cpp#SnippetAppBroadcastingChangedHandler)]

## <a name="related-topics"></a>関連トピック

* [ゲーム](index.md)

 

 




