---
author: Mtoepke
title: "マルチ ユーザー アプリケーションの概要"
description: "Xbox のマルチ ユーザー モデルの簡単な概要です。"
ms.author: mtoepke
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.assetid: 2dde6ed3-7f53-48a6-aebe-2605230decb8
translationtype: Human Translation
ms.sourcegitcommit: 5645eee3dc2ef67b5263b08800b0f96eb8a0a7da
ms.openlocfilehash: 31866c400683c61b432c3fe620487f93a9187771
ms.lasthandoff: 02/08/2017

---

# <a name="introduction-to-multi-user-applications"></a>マルチ ユーザー アプリケーションの概要

このトピックは、Xbox のマルチ ユーザー モデルの簡単な概要となるものです。

> [!NOTE]
> マルチ ユーザー アプリケーションは現在有効になっていません。 

Xbox One ユーザー モデルは、複数のユーザーが単一のデバイスで互いに協力しながらゲームをプレイできるゲーム機本体の要件に合わせて調整されています。 それぞれが自分のコントローラーを持つ複数のユーザーがサインインして、同時に 1 つの対話型セッションでコンソールを使用できます。 これは、他の Windows デバイスとは異なります。 次に例を示します。
* **Windows のデスクトップ PC** では、同じデバイスを使用する複数のユーザーが許可されますが、各ユーザーに独自の対話型セッションがあり、各セッションはデバイス上の他のセッションから完全に独立しています。
* **Windows Phone** では、デバイスを使用するシングル ユーザーのみを許可します。 OOBE (Out-Of-Box Experience) 中にそのシングル ユーザーが決定され、ユーザーはサインイン後にサインアウトできません。 事実上、別のユーザーがデバイスを使用するにはデバイスをリセットする必要があります。 
* **Xbox One** では、複数のユーザーがサインインして、単一の対話型セッションで同時にデバイスを使用できます。

Xbox One ユーザー モデル内の各ユーザーには、対応するローカル ユーザー アカウントがあります。 このローカル ユーザー アカウントは、Xbox Live アカウント (と Microsoft アカウント) に関連付けられています。 これは、Xbox のユーザー アカウントには Xbox Live アカウントおよび Microsoft アカウントとの厳密な 1 対 1 のマッピングがあることを意味します。

## <a name="single-user-applications"></a>シングル ユーザー アプリケーション
既定では、ユニバーサル Windows プラットフォーム (UWP) アプリは、アプリケーションを起動したユーザーのコンテキストで実行されます。 これらの*シングル ユーザー アプリケーション* (SUA) は、その 1 人のユーザーのみを認識し、他の Windows デバイス上のユーザー モデルと互換性があるモードで実行されます。 この Xbox ユーザー モデルでは、アプリに関連付けられているユーザーが管理され、アプリの起動時にユーザーがサインインすることが保証されます。 このモデルでは、UWP アプリやゲームの作成者が Xbox 上で実行するために特別な操作をする必要はありません。 

## <a name="multi-user-applications"></a>マルチ ユーザー アプリケーション
UWP ゲームでは、Xbox One のマルチ ユーザー モデルを選択できます。 これらの*マルチ ユーザー アプリケーション* (MUA) はシステム アカウント (既定のアカウントと呼ばれます) のコンテキストで実行され、Xbox One ユーザー モデルのパワーと柔軟性を最大限に活用できます。 この Xbox ユーザー モデルでは、ゲームに関連付けられているユーザーは管理されず、ユーザーがゲームを実行するためにサインインする必要もありません。 これは、ユーザー要件を明示的に認識および管理するように作成する必要があることを意味します (サインインしたユーザーが必要かどうか、現在のユーザーの概念を実装するかどうか、複数のユーザーからの入力を同時に許可するかどうかなど)。
   
マルチ ユーザー モデルを選ぶには:   
1. Visual Studio でプロジェクトを開きます。   
2. package.appxmanifest.xml ファイルを選びます。   
3. 右クリックして、**[コードの表示]** を選びます。   
4. 次の行を `<Properties></Properties>` セクションに追加します。

```
<uap:SupportedUsers>multiple</uap:SupportedUsers>
```

### <a name="identifying-users-and-inputs"></a>ユーザーおよび入力の識別
開発者は、KeyUp および KeyDown ルーティング イベントで使用される KeyRoutedEventArgs.DeviceId を使用して、さまざまな入力によって生成されるイベントを区別できます。
Windows.System.UserDeviceAssociation.FindUserFromDeviceId メソッドを使用すると、特定の入力に関連付けられたユーザーを特定することができます。

詳しくは、[KeyRoutedEventArgs.DeviceId](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.input.keyroutedeventargs.deviceid) のトピックをご覧ください。


## <a name="guidance-on-which-model-to-choose"></a>モデルの選択に関するガイダンス
すべての UWP アプリと、シングル ユーザーのゲームの大多数は、SUA として作成できます。 協力型のマルチ プレーヤー ゲームについてのみ、Xbox One のマルチ ユーザー モデルを選ぶことを検討するようお勧めします。

## <a name="see-also"></a>参照
- [Xbox One の UWP](index.md)

