---
title: XDK 用 Unity と IL2CPP バックエンド
author: KevinAsgari
description: ID@Xbox および対象パートナー向けに、IL2CPP スクリプト バックエンドを使用して、Xbox Live サポートを XDK 用 Unity に追加する
ms.assetid: 790a49ad-eff4-4916-8578-968ca8483211
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, Unity
ms.localizationpriority: medium
ms.openlocfilehash: 58c10ba1a74b3b2cd99c1171d8305b55f68212fe
ms.sourcegitcommit: 1c6325aa572868b789fcdd2efc9203f67a83872a
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/17/2018
ms.locfileid: "4744004"
---
# <a name="add-xbox-live-support-to-unity-for-xdk-with-il2cpp-scripting-backend-for-idxbox-and-managed-partners"></a>ID@Xbox および対象パートナー向けに、IL2CPP スクリプト バックエンドを使用して、Xbox Live サポートを XDK 用 Unity に追加する

## <a name="overview"></a>概要

Unity での IL2CPP 用の Windows ランタイム サポート

Unity 5.6f3 のリリースでは、エンジンに新しい機能が組み込まれました。この新機能によって、開発者は Windows ランタイム (WinRT) コンポーネントをスクリプト内で直接使用することができます。そのためには、コンポーネントをゲーム プロジェクトに直接取り込みます。 Until 5.6 を利用していた開発者は、ゲーム スクリプトでプラットフォーム機能 (Xbox Live SDK など) をサポートするために、プラグインや dll を必要としていました。 この新しいプロジェクション レイヤーによって、プラグインを使用する必要がなくなり、IL2CPP スクリプト バックエンドを選んだゲームでのみサポートされる、新しい簡略化されたワークフローが導入されました。

作業を開始する方法について詳しくは、Unity のドキュメント (https://docs.unity3d.com/Manual/IL2CPP-WindowsRuntimeSupport.html) をご覧ください。

## <a name="steps"></a>手順

**1) Unity をインストールします。**

Unity 5.6 以上をインストールし、Xbox One エディター拡張機能がインストールされていることを確認します。

**2) WinMDs を使用するときに IntelliSense をサポートするために、Visual Studio Tools for Unity バージョン 3.1 以上をインストールします。** Visual Studio 2015 の場合、このツールは https://marketplace.visualstudio.com/items?itemName=SebastienLebreton.VisualStudio2015ToolsforUnity で入手できます。  Visual Studio 2017 の場合、Visual Studio 2017 インストーラー内でこのコンポーネントを追加することができます。

**3) 新規または既存の Unity プロジェクトを開きます。**

**4) Unity の [Build Settings] メニューで、プラットフォームを Xbox One に切り替えます。**

**5) Unity のプレイヤーの設定で IL2CPP スクリプト バックエンドを有効にして、API の互換性を .NET 4.6 に設定します。**

![](../images/unity/unity-il2cpp-1.png)

**6) スクリプト コンパイラを Roslyn に切り替えます。**

**7) Xbox One の該当するシステム ライブラリがすべて自動的にプロジェクトに追加されます。プラットフォーム バイナリを取り込むための追加の手順は必要ありません。**

**8) 新しい C\# スクリプトを Unity オブジェクトに追加およびアタッチします。**

たとえば、"Main Camera" などの Unity オブジェクトをクリックし、[Add Component]、[New Script]、[C\# Script] の順にクリックして、"XboxLiveScript" という名前を付けます。 ゲーム オブジェクトの種類は問いません。

**9) Visual Studio (VSTU 3.1+ がインストールされていること) でスクリプトを開きます。**

2 つのプロジェクトを確認し、VSTU によって生成された "Player" プロジェクト内のゲーム スクリプト XboxLiveTest.cs を開きます。

![](../images/unity/unity-il2cpp-2.png)

このプロジェクトは XDK 用に生成された特別なプロジェクトであり、アセットに配置した winmd ファイルへの参照が含まれています。
また、"#if ENABLE_WINMD_SUPPORT" 定義が自動的に設定されるため、IntelliSense と構文の強調表示が適切に機能します。

**10) 次の Xbox Live コードを XboxLiveTest.cs ソース ファイルに追加します。**

```csharp

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class XboxLiveTest : MonoBehaviour
{
#if ENABLE_WINMD_SUPPORT
    Windows.Xbox.System.User mCurrentUser = null;
    XboxLiveContext mContext = null;
#endif

    // Use this for initialization
    void Start()
    {
#if ENABLE_WINMD_SUPPORT
        mCurrentUser = Windows.Xbox.ApplicationModel.Core.CoreApplicationContext.CurrentUser;
        mContext = new XboxLiveContext(mCurrentUser);
#endif
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnGUI()
    {
        if(mContext != null) Gui.TextArea(new Rect(10,10,50,200), mContext.XboxUserId);
    }
}

```

**11) プレイヤーの設定内にある公開の設定で、"InternetClient" 機能が選択されていることを確認します。**

![](../images/unity/unity-il2cpp-3.png)

**12) Unity でプロジェクトをビルドします。**
