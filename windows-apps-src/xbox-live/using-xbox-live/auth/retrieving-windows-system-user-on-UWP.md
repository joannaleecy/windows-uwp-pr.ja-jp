---
title: UWP での Windows システム ユーザーの取得
author: KevinAsgari
description: ユニバーサル Windows プラットフォーム (UWP) ゲームで Windows システム ユーザーを取得する方法について説明します。
ms.author: kevinasg
ms.date: 06/07/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: xbox live, xbox, ゲーム, uwp, windows 10, システム ユーザー
ms.localizationpriority: medium
ms.openlocfilehash: 0533e9f63453ee2a7a8a7cb77f6f253e2d9c0e23
ms.sourcegitcommit: e4f3e1b2d08a02b9920e78e802234e5b674e7223
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/26/2018
ms.locfileid: "4209149"
---
# <a name="retrieving-the-windows-system-user-in-a-universal-windows-platform-uwp-title"></a>ユニバーサル Windows プラットフォーム (UWP) での Windows システム ユーザーの取得

## <a name="windowssystemuser"></a>Windows.System.User

[Windows.System.User](https://docs.microsoft.com/en-us/uwp/api/windows.system.user) オブジェクトはローカル Windows ユーザーを表します。 Xbox コンソールでは、1 つの対話型セッションで複数の Windows ユーザーを同時に記録できます。アプリがマルチ ユーザー アプリケーションの場合、Windows.System.User オブジェクトはライブ サービスにアクセスするために XboxLiveUser を構築する必要があります。 PC やスマートフォンなどの他の Windows プラットフォームでは、1 台のデバイスまたは 1 つの対話型セッションで 1 人の Windows ユーザーのみが許可されます。Windows.System.User を渡して XboxLiveUser を構築する必要はありません。

## <a name="ways-to-retrieve-windows-system-user"></a>Windows システム ユーザーの取得方法

* **[Windows.System.User](https://docs.microsoft.com/en-us/uwp/api/windows.system.user) クラスの静的メソッドを使う。**

  [Windows.System.User](https://docs.microsoft.com/en-us/uwp/api/windows.system.user) クラスには、Windows.System.User オブジェクトを取得するための一連の静的メソッドが用意されています。 たとえば、FindAllAsync を呼び出してアクティブな Windows ユーザーをすべて取得できます。

* **[UserPicker](https://docs.microsoft.com/en-us/uwp/api/windows.system.userpicker)**

  [Windows.System.UserPicker](https://docs.microsoft.com/en-us/uwp/api/windows.system.userpicker) クラスには、ユーザー ピッカー UI を起動し、複数のユーザー シナリオで Windows システム ユーザーを選択するメソッドが用意されています。

* **[IGameController](https://docs.microsoft.com/en-us/uwp/api/windows.gaming.input.igamecontroller)**

  [Windows.Gaming.Input.IGameController](https://docs.microsoft.com/en-us/uwp/api/windows.gaming.input.igamecontroller) は、すべてのコントローラー デバイス (ゲームパッド、レーシング ハンドル、フライト スティックなど) のコア インターフェイスです。 User プロパティを呼び出すことによって、ゲーム コントローラーに関連付けられている Windows.System.User オブジェクトを取得することができます。  

  Windows により実装されているゲーム コントローラーには、[ArcadeStick](https://docs.microsoft.com/en-us/uwp/api/windows.gaming.input.arcadestick)、[FlightStick](https://docs.microsoft.com/en-us/uwp/api/windows.gaming.input.flightstick)、[Gamepad](https://docs.microsoft.com/en-us/uwp/api/windows.gaming.input.gamepad), [RacingWheel](https://docs.microsoft.com/en-us/uwp/api/windows.gaming.input.racingwheel) などがあります。

* **[UserDeviceAssociation](https://docs.microsoft.com/en-us/uwp/api/windows.system.userdeviceassociation)**

  静的メソッド FindUserFromDeviceId を呼び出して、関連するユーザーとデバイス ID を検索することができます。デバイス ID は通常、[Windows.UI.Xaml.Input.KeyRoutedEventArgs](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.Input.KeyRoutedEventArgs)、[Windows.UI.Core.KeyEventArgs](https://docs.microsoft.com/en-us/uwp/api/windows.ui.core.keyeventargs) などの Windows 入力イベントから取得できます。
