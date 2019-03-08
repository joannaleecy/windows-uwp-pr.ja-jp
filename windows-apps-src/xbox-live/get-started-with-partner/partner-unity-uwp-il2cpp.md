---
title: UWP 用 Unity と IL2CPP バックエンド
description: ID@Xbox および対象パートナー向けに、IL2CPP スクリプト バックエンドを使用して、Xbox Live サポートを UWP 用 Unity に追加する
ms.assetid: 790a49ad-eff4-4916-8578-968ca8483211
ms.date: 04/04/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, Unity
ms.localizationpriority: medium
ms.openlocfilehash: ace950dec6a57a9550ea7b3fbe6c52b53855e2e0
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57622917"
---
# <a name="add-xbox-live-support-to-unity-for-uwp-with-il2cpp-scripting-backend-for-idxbox-and-managed-partners"></a>ID@Xbox および対象パートナー向けに、IL2CPP スクリプト バックエンドを使用して、Xbox Live サポートを UWP 用 Unity に追加する

## <a name="overview"></a>概要

Unity での IL2CPP 用の Windows ランタイム サポート

Unity 5.6f3 のリリースでは、エンジンに新しい機能が組み込まれました。この新機能によって、開発者は Windows ランタイム (WinRT) コンポーネントをスクリプト内で直接使用することができます。そのためには、コンポーネントをゲーム プロジェクトに直接取り込みます。 Until 5.6 を利用していた開発者は、UWP でゲーム スクリプトによってプラットフォーム機能 (Xbox Live SDK など) をサポートするために、プラグインや dll を必要としていました。 この新しいプロジェクション レイヤーによって、プラグインを使用する必要がなくなり、IL2CPP スクリプト バックエンドを選んだゲームでのみサポートされる、新しい簡略化されたワークフローが導入されました。

作業を開始する方法について詳しくは、Unity のドキュメント (https://docs.unity3d.com/Manual/IL2CPP-WindowsRuntimeSupport.html) をご覧ください。

## <a name="steps"></a>手順

**1) Unity をインストールします。**

Unity 5.6 以上をインストールし、インストール時には **[Windows Store Il2CPP scripting backend]** を必ず選択してください。

**2) WinMDs を使用するときに IntelliSense をサポートするために、Visual Studio Tools for Unity バージョン 3.1 以上をインストールします。** Visual Studio 2015 の場合、このツールは https://marketplace.visualstudio.com/items?itemName=SebastienLebreton.VisualStudio2015ToolsforUnity で入手できます。  Visual Studio 2017 の場合、Visual Studio 2017 インストーラー内でこのコンポーネントを追加することができます。

**3) 新しいまたは既存の Unity プロジェクトを開く**

**4) スイッチ Unity ビルド設定 メニューでユニバーサル Windows プラットフォームのプラットフォーム**

**5) il2cpp バック エンドのスクリプト バックエンド Unity player の設定を有効にし、.NET 4.6 に API の互換性を設定**

![](../images/unity/unity-il2cpp-1.png)

**6) 最新バージョンの Xbox Live WinRT Unity アセット パッケージをインポートします。** このパッケージは https://github.com/Microsoft/xbox-live-api/releases で入手できます。

**7) を追加し、新しい C をアタッチ\#Unity オブジェクトへのスクリプト。**

たとえば、「メイン カメラ」などの Unity オブジェクトをクリックして、"コンポーネントの追加 をクリックします。 \| "新しいスクリプト" \| C\#スクリプト\|"XboxLiveScript"名前を付けます。 ゲーム オブジェクトの種類は問いません。

**8) (VSTU) 3.1 + がインストールされた Visual Studio でスクリプトを開きます。**

2 つのプロジェクトを確認し、VSTU によって生成された "Player" プロジェクト内のゲーム スクリプト XboxLiveTest.cs を開きます。

![](../images/unity/unity-il2cpp-2.png)

このプロジェクトは UWP 用に生成された特別なプロジェクトであり、アセットに配置した winmd ファイルへの参照が含まれています。
また、"#if ENABLE_WINMD_SUPPORT" 定義が自動的に設定されるため、IntelliSense と構文の強調表示が適切に機能します。

**9) XboxLiveTest.cs ソース ファイルに次の Xbox Live のコードを追加します。**

```csharp

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class XboxLiveTest : MonoBehaviour
{
#if ENABLE_WINMD_SUPPORT
    Microsoft.Xbox.Services.System.XboxLiveUser m_user = new   Microsoft.Xbox.Services.System.XboxLiveUser();

    Microsoft.Xbox.Services.XboxLiveContext m_xboxLiveContext = null;
    Windows.UI.Core.CoreDispatcher UIDispatcher = null;
#endif
    string debugText = "";
    // Use this for initialization
    void Start()
    {
#if ENABLE_WINMD_SUPPORT
        Windows.ApplicationModel.Core.CoreApplicationView mainView = Windows.ApplicationModel.Core.CoreApplication.MainView;
        Windows.UI.Core.CoreWindow cw = mainView.CoreWindow;
        UIDispatcher = cw.Dispatcher;
        SignIn();
#endif
    }
    // Update is called once per frame
    void Update()
    {
    }
    void OnGUI()
    {
        GUI.Label(new UnityEngine.Rect(10, 10, 300, 50), debugText);
    }
#if ENABLE_WINMD_SUPPORT
    async void SignIn()
    {
        Microsoft.Xbox.Services.System.SignInResult result = await m_user.SignInAsync(UIDispatcher);
        if (result.Status == Microsoft.Xbox.Services.System.SignInStatus.Success)
        {
            m_xboxLiveContext = new Microsoft.Xbox.Services.XboxLiveContext(m_user);
            debugText += "\n User signed in: " + m_xboxLiveContext.User.Gamertag;
        }

    }
#endif
}

```

**Player の設定については、発行の設定で選択されている 'InternetClient' 機能がある 10) ことを確認します**

![](../images/unity/unity-il2cpp-3.png)

**11) で Unity プロジェクトをビルドします。**

1.  ファイルに移動して\|ビルド設定 をクリックして**ユニバーサル Windows プラットフォーム**をクリックするかどうかを確認して**スイッチ プラットフォーム**

2.  [Add Open Scenes] をクリックして、現在のシーンをビルドに追加します。

3.  [SDK] コンボ ボックスで、[Universal 10] を選択します。

4.  UWP ビルド タイプのコンボ ボックスで [D3D] を選択しますが、必要に応じて [XAML] も選択できます。

5.  Unity の [Build] をクリックして、UWP アプリケーション内に Unity ゲームをラップする UWP Visual Studio プロジェクトを生成します。 新しいファイルが多数作成されるため、場所を指定するときは、混乱を避けるために新しいフォルダーを作成します。 フォルダーの名前を "Build" にすることをお勧めします。フォルダーに名前を付けたら、そのフォルダーを選択します。

**12) Xbox Live の構成をプロジェクトに追加します。**

xboxservices.config ファイルを追加します。

![](../images/unity/unity-il2cpp-4.png)

「[新規または既存の UWP プロジェクトに Xbox Live を追加する](get-started-with-visual-studio-and-uwp.md)」というドキュメント ページの手順に従います。

> [!NOTE]
> xboxservices.config 内のすべての値で大文字と小文字が区別されます。

**13) をコンパイルし、Visual Studio から UWP アプリの実行**

これにより、通常の UWP アプリのようにアプリが起動し、動作のために UWP アプリ コンテナーが必要なときに Xbox Live 呼び出しが可能になります。

**Unity 内のあらゆるものに変更を加える場合 14) リビルド**  
Unity で変更を加えた場合、UWP プロジェクトをリビルドする必要があります。

再コンパイル時に Unity が pfx ファイルを置き換えることによって Xbox Live へのサインインが失敗することに注意してください。この問題を避けるために Unity プロジェクト内でファイルを更新する必要があります。

ファイルに移動するのには、\|ビルドの設定は、"Build Settings"でクリックして、**ユニバーサル Windows プラットフォーム**プレーヤーと PFX を置換する PFX ボタンが上から取得した 1 つのファイル をクリックします。 別の方法として、Unity 内でプロジェクトをリビルドするたびに PFX ファイルを削除することもできます。

## <a name="troubleshooting-common-issues"></a>一般的な問題のトラブルシューティング

**1)** Unity において、関連付けられたスクリプトを読み込めない場合、手順 3 を実行して WinMD を Unity のプロジェクト アセット パネルにドラッグしたことを確認してください。

**2)** 起動後すぐ、または次のコード行を実行しようとしたときにアプリがクラッシュする場合:

    Microsoft.Xbox.Services.System.XboxLiveUser m_user = new Microsoft.Xbox.Services.System.XboxLiveUser();

xboxservices.config テキスト ファイルをプロジェクトに追加して、そのプロパティで "Build Action" を "Content" に、"Copy to Output Directory" を "Copy Always" に設定したことを確認します。
また、次のような正しい JSON フォーマット (10 進形式の TitleId) がテキスト ファイルに含まれていることを確認します。

```json
{
    "TitleId" : 928643728,
    "PrimaryServiceConfigId" : "3ebd0100-ace5-4aa4-ab9c-5b733759fa90"
}
```

**3)** アプリが起動するがサインインに失敗する場合は、以下を確認してください。

a) コンピューターがデベロッパー サンドボックスに設定されていること。  これを行うには、Xbox Live SDK の \Tools フォルダーにある SwitchSandbox.cmd スクリプトを使用します。

b) デベロッパー サンドボックスにアクセスできる Xbox Live アカウントでサインインしていること。  通常のリテール Xbox Live アカウントにはそのようなアクセス権がありません。  XDP またはパートナー センターを使用して、テスト アカウントを作成することができます。

c) UWP アプリの package.appxmanfiest で正しい Identity が設定されていること。  これを手動で編集できますが、これを解決する最も簡単な方法は、Visual Studio でプロジェクトを右クリックし、"Store"を選択する\|「、ストアでアプリを関連付ける」。

d) Unity によって提供されるストックの .pfx ファイルは、適切な id を必要はありませんので、いずれか、ディスクから削除し、それを参照する .csproj に行を削除または、右が Visual Studio でプロジェクトをクリックし、"Store"を選択\|"に関連付けるアプリ ストアと"これを適切な .pfx ファイルを配置します。  その後、Unity に戻って **ユニバーサル Windows プラットフォーム** プレイヤー上で [Build Settings] をクリックし、[PFX] ボタンをクリックして、.pfx ファイルを Visual Studio での [アプリケーションを Microsoft Store と関連付ける] 操作により取得したファイルに置き換えます。
