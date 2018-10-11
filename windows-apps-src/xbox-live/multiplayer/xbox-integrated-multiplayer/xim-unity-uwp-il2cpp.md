---
title: XIM (Unity と IL2CPP) の使用
author: KevinAsgari
description: UWP 用の Unity と IL2CPP スクリプト バックエンドと共に Xbox Integrated Multiplayer を使用する
ms.author: kevinasg
ms.date: 04/03/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, Unity, Xbox Integrated Multiplayer
ms.localizationpriority: medium
ms.openlocfilehash: 4a52501761f75b5d57aa73d919b7c83f3988685c
ms.sourcegitcommit: 933e71a31989f8063b020746fdd16e9da94a44c4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/11/2018
ms.locfileid: "4534508"
---
# <a name="use-xim-unity-with-il2cpp"></a>XIM (Unity と IL2CPP) の使用

## <a name="overview"></a>概要

Unity での IL2CPP 用の Windows ランタイム サポート

Unity 5.6f3 のリリースでは、エンジンに新しい機能が組み込まれました。この新機能によって、開発者は Windows ランタイム (WinRT) コンポーネントをスクリプト内で直接使用することができます。そのためには、コンポーネントをゲーム プロジェクトに直接取り込みます。 5.6 まで、開発者は、UWP のゲーム スクリプトでプラットフォーム機能 (Xbox Integrated Multiplayer など) をサポートするために、プラグインや dll を必要としていました。 この新しいプロジェクション レイヤーによって、プラグインを使用する必要がなくなり、IL2CPP スクリプト バックエンドを選んだゲームでのみサポートされる、新しい簡略化されたワークフローが導入されました。

- WinRT と Unity を使用して作業を開始する方法について詳しくは、[Unity のドキュメント](https://docs.unity3d.com/Manual/IL2CPP-WindowsRuntimeSupport.html)をご覧ください。
- IL2CPP を使用して Unity に Xbox Live のサポートを追加する方法の詳細については、それに関する [Xbox Live のドキュメント](https://docs.microsoft.com/windows/uwp/xbox-live/get-started-with-partner/partner-add-xbox-live-to-unity-uwp)を参照してください。

## <a name="using-the-xim-unity-asset-package"></a>XIM Unity アセット パッケージの使用

### <a name="1-install-unity"></a>1. Unity をインストールします。

Unity 5.6 以上をインストールし、インストール時には **[Windows Store Il2CPP scripting backend]** を必ず選択してください。

### <a name="2-install-visual-studio-tools-for-unity-version-31-and-above-for-intellisense-support-when-using-winmds"></a>2. WinMDs を使用するときに IntelliSense をサポートするために、Visual Studio Tools for Unity バージョン 3.1 以上をインストールします。

Visual Studio 2015 の場合、このツールは [Visual Studio Marketplace](https://marketplace.visualstudio.com/items?itemName=SebastienLebreton.VisualStudio2015ToolsforUnity) で入手できます。 Visual Studio 2017 の場合、Visual Studio 2017 インストーラー内でこのコンポーネントを追加することができます。

### <a name="3-open-a-new-or-existing-unity-project"></a>3. 新規または既存の Unity プロジェクトを開きます。

### <a name="4-switch-the-platform-to-universal-windows-platform-in-the-unity-build-settings-menu"></a>4. Unity の [Build Settings] メニューで、プラットフォームをユニバーサル Windows プラットフォームに切り替えます。

![Unity の [Build Settings] メニューでユニバーサル Windows プラットフォームのビルド設定を選択した状態](../../images/xboxintegratedmultiplayer/xim-unity-build.png)

### <a name="5-enable-il2cpp-scripting-backend-in-the-unity-player-settings-and-set-api-compatibility-to-net-46"></a>5. Unity のプレイヤーの設定で IL2CPP スクリプト バックエンドを有効にして、API の互換性を .NET 4.6 に設定します。

![Unity の [Player Settings] メニューの [Configuration] セクションで、[Api Compatibility] を [.NET 4.6] に設定した状態](../../images/unity/unity-il2cpp-1.png)

### <a name="6-import-the-latest-version-of-the-xbox-integrated-multiplayer-winrt-unity-asset-package"></a>6. 最新バージョンの Xbox Integrated Multiplayer WinRT Unity アセット パッケージをインポートします。

このパッケージは https://github.com/Microsoft/xbox-integrated-multiplayer-unity-plugin/releases で入手できます。

### <a name="7-you-can-now-use-xim-in-your-scripts"></a>7. スクリプトで XIM を使用できるようになりました。

C# で XIM を使用する方法の詳細なガイダンスについては、「[XIM の使用 (C#)](using-xim-cs.md)」を参照してください。

次のスニペットでは、コードで XIM を統合する方法を示しています。

```cs

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if ENABLE_WINMD_SUPPORT
using Microsoft.Xbox.Services.XboxIntegratedMultiplayer;
#endif

public class XimScript
{
    public void Start()
    {
#if ENABLE_WINMD_SUPPORT
        XboxIntegratedMultiplayer.TitleId = XboxLiveAppConfiguration.SingletonInstance.TitleId;
        XboxIntegratedMultiplayer.ServiceConfigurationId = XboxLiveAppConfiguration.SingletonInstance.ServiceConfigurationId;
#endif
    }

    public void Update()
    {
#if ENABLE_WINMD_SUPPORT
        using (var stateChanges = XboxIntegratedMultiplayer.GetStateChanges())
        {
            foreach (var stateChange in stateChanges)
            {
                switch (stateChange.Type)
                {
                    case XimStateChangeType.PlayerJoined:
                        HandlePlayerJoined((XimPlayerJoinedStateChange)stateChange);
                        break;

                    case XimStateChangeType.PlayerLeft:
                        HandlePlayerLeft((XimPlayerLeftStateChange)stateChange);
                        break;
                    [...]
                }
            }
        }
#endif
    }
}
```

`ENABLE_WINMD_SUPPORT` の #define ディレクティブの詳細については、[Windows ランタイムのサポート](https://docs.unity3d.com/Manual/IL2CPP-WindowsRuntimeSupport.html)に関する Unity のドキュメントを参照してください。

### <a name="8-required-capability-content"></a>8. 必要な機能の内容

本質的に XIM を使用するアプリケーションでは、インターネット経由とローカル ネットワーク経由の両方でネットワーク リソースに接続し、ネットワーク リソースからの接続を受け入れる必要があります。 また、ボイス チャットをサポートするマイク デバイスへのアクセスも必要です。 そのため、アプリのプレイヤー設定にある公開設定では、"InternetClientServer" 機能、"PrivateNetworkClientServer" 機能、"Microphone" デバイス機能を宣言する必要があります。

![Unity の [Capabilities] メニューで "InternetClientServer"、"PrivateNetworkClientServer"、"Microphone" 機能が選択された状態](../../images/xboxintegratedmultiplayer/xim-unity-capability.png)

### <a name="9-build-the-project-in-unity"></a>9. Unity でプロジェクトを ビルドします。

1. [File]、[Build Settings] の順に移動し、**[ユニバーサル Windows プラットフォーム]** をクリックして、**[Switch Platform]** をクリックします。

2. [Add Open Scenes] をクリックして、現在のシーンをビルドに追加します。

3. [SDK] コンボ ボックスで、[Universal 10] を選択します。

4. UWP ビルド タイプのコンボ ボックスで [D3D] を選択しますが、必要に応じて [XAML] も選択できます。

5. Unity の [Build] をクリックして、UWP アプリケーション内に Unity ゲームをラップする UWP Visual Studio プロジェクトを生成します。

    新しいファイルが多数作成されるため、場所を指定するときは、混乱を避けるために新しいフォルダーを作成します。 フォルダーの名前を "Build" にすることをお勧めします。フォルダーに名前を付けたら、そのフォルダーを選択します。

6. XIM のネットワーク マニフェストをプロジェクトに追加します。

    networkmanifest.xml ファイルを追加します。

    ![Visual Studio の networkmanifest.xml のプロパティ](../../images/xboxintegratedmultiplayer/xim-unity-networkmanifest.png)

    ネットワーク マニフェストとその内容の詳細については、「[XIM プロジェクト構成](xim-manifest.md)」を参照してください。

7. Visual Studio から UWP アプリをコンパイルして実行します。

これにより、通常の UWP アプリのようにアプリが起動し、動作のために UWP アプリ コンテナーが必要なときに Xbox Live 呼び出しが可能になります。

### <a name="10-rebuild-if-you-make-changes-to-anything-in-unity"></a>10. Unity で変更を加えた場合はリビルドします。

Unity で変更を加えた場合、UWP プロジェクトをリビルドする必要があります。
