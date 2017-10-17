---
title: Unity for XDK with IL2CPP backend
author: KevinAsgari
description: Add Xbox Live support to Unity for XDK with IL2CPP scripting backend for ID@Xbox and managed partners
ms.assetid: 790a49ad-eff4-4916-8578-968ca8483211
ms.author: kevinasg
ms.date: 04-04-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: xbox live, xbox, games, uwp, windows 10, xbox one, Unity
ms.openlocfilehash: 33cb39f20bb8b45495a384d8b0206bf07ba43aae
ms.sourcegitcommit: 1eb0a87dd723f47c6dba292bcc716df363ace72c
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/08/2017
---
# <a name="add-xbox-live-support-to-unity-for-xdk-with-il2cpp-scripting-backend-for-idxbox-and-managed-partners"></a>Add Xbox Live support to Unity for XDK with IL2CPP scripting backend for ID@Xbox and managed partners

## <a name="overview"></a>Overview

Windows Runtime Support for IL2CPP in Unity

With the release of Unity 5.6f3 the engine has included a new feature that enables developers to use Windows Runtime (WinRT) components directly in script by including them in the game project directly. Until 5.6 developers have needed a plugin, or dll to support any platform feature (including Xbox Live SDK) from game script. This new projection layer removes the plugin requirement, and introduces a new and simplified workflow supported only with games that choose the IL2CPP scripting backend.

For more information on how to get started, see the Unity documentation: https://docs.unity3d.com/Manual/IL2CPP-WindowsRuntimeSupport.html

## <a name="steps"></a>Steps

**1) Install Unity**

Install Unity 5.6 or higher, and ensure you have the Xbox One editor extension installed.

**2) Install Visual Studio Tools for Unity version 3.1 and above for IntelliSense support when using WinMDs** For Visual Studio 2015, this can be found at https://marketplace.visualstudio.com/items?itemName=SebastienLebreton.VisualStudio2015ToolsforUnity.  For Visual Studio 2017, the component can be added inside the Visual Studio 2017 installer.

**3) Open a new or existing Unity project**

**4) Switch the platform to Xbox One in the Unity Build Settings menu**

**5) Enable IL2CPP scripting backend in the Unity player settings, and set API compatibility to .NET 4.6**

![](../images/unity/unity-il2cpp-1.png)

**6) スクリプト コンパイラを Roslyn に切り替えます。**

**7) Xbox One の該当するシステム ライブラリがすべて自動的にプロジェクトに追加されます。プラットフォーム バイナリを取り込むための追加の手順は必要ありません。**

**8) 新しい C\# スクリプトを Unity オブジェクトに追加およびアタッチします。**

For example, click on a Unity object such as the "Main Camera", and click "Add Component" \| "New Script" \| C\# Script \| and name it "XboxLiveScript". ゲーム オブジェクトの種類は問いません。

**9) Visual Studio (VSTU 3.1+ がインストールされていること) でスクリプトを開きます。**

2 つのプロジェクトを確認し、VSTU によって生成された "Player" プロジェクト内のゲーム スクリプト XboxLiveTest.cs を開きます。

![](../images/unity/unity-il2cpp-2.png)

This is a special project generated for XDK, and includes references for the winmd files you have placed in your assets.
また、"#if ENABLE_WINMD_SUPPORT" 定義が自動的に設定されるため、IntelliSense と構文の強調表示が適切に機能します。

**10) 次の Xbox Live コードを XboxLiveTest.cs ソース ファイルに追加します。**

```cpp

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
