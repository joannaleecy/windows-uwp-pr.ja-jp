---
author: drewbatgit
ms.assetid: 
description: "この記事では、モバイル デバイス上にのみある特殊カメラの UI 機能を活用する方法を示します。"
title: "モバイル デバイスのカメラ UI の機能"
translationtype: Human Translation
ms.sourcegitcommit: 77d1709cd42253c229b01df21ae3416e57c1c2ab
ms.openlocfilehash: ec437d7111b1490f52bfc53b3ad2cd06f0c66ef3

---

#モバイル デバイスのカメラ UI の機能

この記事では、モバイル デバイス上にのみある特殊カメラの UI 機能を活用する方法を示します。 

## モバイル拡張をプロジェクトに追加する 

これらの機能を使用するには、ユニバーサル アプリ プラットフォーム用 Microsoft Mobile Extension SDK への参照をプロジェクトに追加する必要があります。

**ハードウェア カメラ ボタンのサポート用にモバイル拡張 SDK への参照を追加するには**

1.  **ソリューション エクスプローラー**で、**[参照設定]** を右クリックし、**[参照の追加]** を選びます。

2.  **[Windows ユニバーサル]** ノードを展開し、**[拡張機能]** を選びます。

3.  **[Microsoft Mobile Extension SDK for Universal App Platform]**(ユニバーサル アプリ プラットフォーム用 Microsoft Mobile Extension SDK) チェック ボックスをオンにします。

## ステータス バーを非表示にする

モバイル デバイスには、デバイスに関する状態情報をユーザーに通知する [**StatusBar**](https://msdn.microsoft.com/library/windows/apps/dn633864) コントロールがあります。 このコントロールが表示される領域は、画面上でメディア キャプチャ UI の表示に干渉する可能性があります。 [**HideAsync**](https://msdn.microsoft.com/library/windows/apps/dn610339) を呼び出すことでステータス バーを非表示にできますが、呼び出しは、この API が利用可能かどうかを [**ApiInformation.IsTypePresent**](https://msdn.microsoft.com/library/windows/apps/dn949016) メソッドで確認する条件ブロック内で行う必要があります。 このメソッドは、ステータス バーをサポートするモバイル デバイスでのみ true を返します。 アプリの起動時や、またはカメラからプレビューを開始するときには、ステータス バーを非表示にする必要があります。

[!code-cs[HideStatusBar](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetHideStatusBar)]

アプリをシャットダウンするときや、ユーザーがアプリのメディア キャプチャ ページから移動するときは、コントロールを再び表示できます。

[!code-cs[ShowStatusBar](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetShowStatusBar)]

## ハードウェア カメラ ボタンを使う

一部のモバイル デバイスには、専用のハードウェア カメラ ボタンが用意されていることがあります。この仕様は、ユーザーによっては画面上のコントロールより好まれます。 このハードウェア カメラ ボタンが押されたときに通知を受け取るには、[**HardwareButtons.CameraPressed**](https://msdn.microsoft.com/library/windows/apps/dn653805) イベントのハンドラーを登録します。 この API を利用できるのはモバイル デバイスのみであるため、この場合も **IsTypePresent** を使用して、この API が現在のデバイスでサポートされているかどうかをアクセス前に確認する必要があります。

[!code-cs[PhoneUsing](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetPhoneUsing)]

[!code-cs[RegisterCameraButtonHandler](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetRegisterCameraButtonHandler)]

**CameraPressed** イベントのハンドラーで、写真のキャプチャを開始できます。

[!code-cs[CameraPressed](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetCameraPressed)]

アプリをシャットダウンするときや、ユーザーがアプリのメディア キャプチャ ページから移動するときは、ハードウェア ボタンのハンドラーを登録解除します。

[!code-cs[UnregisterCameraButtonHandler](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetUnregisterCameraButtonHandler)]

> [!NOTE]
> この記事は、ユニバーサル Windows プラットフォーム (UWP) アプリを作成する Windows 10 開発者を対象としています。 Windows 8.x 用または Windows Phone 8.x 用の開発を行っている場合は、[アーカイブ ドキュメント](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください。                                                                                   |

## 関連トピック

* [カメラ](camera.md)
* [MediaCapture を使った基本的な写真、ビデオ、およびオーディオのキャプチャ](basic-photo-video-and-audio-capture-with-MediaCapture.md)








<!--HONumber=Aug16_HO3-->


