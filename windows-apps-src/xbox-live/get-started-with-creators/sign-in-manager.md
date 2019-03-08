---
title: Unity で SignInManager でサインイン
description: Unity プラグイン サインイン Manager の概要
ms.date: 05/08/2018
ms.topic: get-started-article
keywords: xbox live、xbox、ゲーム、uwp、windows 10、1 つ xbox、unity
ms.openlocfilehash: e6d066fe7792912f8918cb139d45ff05d105feaa
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57641727"
---
# <a name="scripting-sign-in"></a>サインイン スクリプト

GameObject にスクリプトを作成する必要がありますが、独自のカスタム ゲーム オブジェクトにサインインを追加するにはします。 系 PlayerAuthentication プレハブは、ゲームに一致しないこととする独自のサインイン パネルには、この記事で、タイトルにサインインしているロジックを追加する基本的な手順を実行するとします。

## <a name="sign-in-with-the-signinmanager"></a>SignInManager を使用してサインインする

プラグイン Xbox Live Unity にはスクリプトが含まれています、`SignInManager`ファイル パスの下**資産 >> XboxLive >> スクリプト >> SignInManager.cs**します。 呼び出すことができるフォーム任意の場所、タイトルのタイトルを参照してシングルトン クラスは、マネージャーが*インスタンス*の`SignInManager`します。 これは、*インスタンス*を初期化する必要としないことができますを使用して、it、ゲームを開始するとすぐにします。 すべてにアクセスすることができます、そのパブリック プロパティと関数を参照することで、*インスタンス*として`SignInManager.Instance`します。

`SignInManager`のタイトルの認証を管理するには、これは、サインイン、サインアウトに含まれます、どのプレーヤーとしてサインインするユーザーに関する情報の取得に必要なコードのすべてが含まれます。

### <a name="calls-and-results"></a>呼び出しと結果

`SignInManager`が 3 つの非同期共同ルーチン関数`SignInPlayer(int playerNumber)`、`SignOutPlayer(int playerNumber)`と`SwitchUser(int playerNumber)`、そのトリガー イベントの関数の呼び出しの結果を収集し、それに従って動作します。 スクリプトに対応する関数を追加して割り当てるには`SignInManager.Instance`のコールバックの一覧。 イベントの関数は`OnPlayerSignIn(int playerNumber, UnityAction<XboxLiveUser, XboxLiveAuthStatus, string> callback)`、 `OnPlayerSignOut(int playerNumber, UnityAction<XboxLiveUser, XboxLiveAuthStatus, string> callback)`、 `OnAnyPlayerSignIn(UnityAction<XboxLiveUser, XboxLiveAuthStatus, string> callback)`、および`OnAnyPlayerSignOut(UnityAction<XboxLiveUser, XboxLiveAuthStatus, string> callback)`します。 イベント関数のそれぞれには、名前に記載されているイベントをリッスンします。 マネージャーのコールバックの一覧に、独自の関数を追加するにはタイトルの`Start()`関数を次のコード。

```csharp
using Microsoft.Xbox.Services;
using Microsoft.Xbox.Services.Client;

void Start () {
    try
    {
        SignInManager.Instance.OnPlayerSignOut(this.playerNumber, this.OnPlayerSignOut);
        SignInManager.Instance.OnPlayerSignIn(this.playerNumber, this.OnPlayerSignIn);
    }
    catch (Exception ex)
    {
        Debug.LogWarning(ex.Message);
    }

}
```

このコード スニペットは、この GameObject の playerNumber に関連付けられているプレイヤーのサインインとサインアウトのリスナーを追加します。 この GameObject の`OnPlayerSignIn`ときに関数が呼び出されます、`SignInManager`サインイン試行が完了したかを検出し、その`OnPlayerSignOut`関数は、サインアウト、SignInManager を検出したときに呼び出されます。イベントの関数は、GameObject は、SignInManager によって呼び出される関数の型と一致させるには、戻り値の型とパラメーターが必要です。 両方の`OnPlayerSignIn`と`OnPlayerSignOut`void 関数が必要とする、 `XboxLiveUser`、`XboxLiveAuthStatus`とそのパラメーターとして文字列。 関数のシェルは、次のようになります可能性があります。

```csharp
using Microsoft.Xbox.Services;
using Microsoft.Xbox.Services.Client;

private void OnPlayerSignIn(XboxLiveUser xboxLiveUserParam, XboxLiveAuthStatus authStatus, string errorMessage)
{
}

private void OnPlayerSignOut(XboxLiveUser xboxLiveUserParam, XboxLiveAuthStatus authStatus, string errorMessage)
{
}
```

両方の関数では、確認、`XboxLiveAuthStatus`ことを確認する呼び出し、`SignInManager.Instance`が成功しました。 正常な呼び出しで、`XboxLiveUser`なります、`XboxLiveUser`でこの出力に署名する`SignInManager`します。 呼び出しが成功した場合、`errorMessage`文字列には、失敗の理由の詳細についてにが含まれます。

呼び出しの成功を確認するコードの数行を追加すると、次のようなコードが生成。

```csharp
using Microsoft.Xbox.Services;
using Microsoft.Xbox.Services.Client;

private void OnPlayerSignIn(XboxLiveUser xboxLiveUserParam, XboxLiveAuthStatus authStatus, string errorMessage)
{
    if(authStatus == XboxLiveAuthStatus.Succeeded)
    {
        this.xboxLiveUser = xboxLiveUserParam; //store the xboxLiveUser SignedIn
        this.signedIn = true;
    }
    else
    {
        if (XboxLiveServicesSettings.Instance.DebugLogsOn)
        {
            Debug.LogError(errorMessage); //Log the error message in case of unsuccessful call. 
        }
    }
}

private void OnPlayerSignOut(XboxLiveUser xboxLiveUserParam, XboxLiveAuthStatus authStatus, string errorMessage)
{
    if (authStatus == XboxLiveAuthStatus.Succeeded)
    {
        this.xboxLiveUser = null;
        this.signedIn = false;
    }
    else
    {
        if (XboxLiveServicesSettings.Instance.DebugLogsOn)
        {
            Debug.LogError(errorMessage);
        }
    }
}
```

サインインを呼び出すと、結果を結果として得られるイベントのキャプチャ、タイトルのサインインとサインアウトを処理できます。

## <a name="get-signed-in-player-information"></a>プレーヤーの情報でサインインします。

サービスにプレーヤーの署名に加えて、SignInManager をサインインしているすべてのユーザーの追跡を保持します。 PC でこの player で署名された、1 つに制限されています、Xbox では 16 に制限されます。 方法の結果を比較することによってがする制限に近づいてを確認できます`SignInManager.Instance.GetCurrentNumberOfPlayers()`の結果に`SignInManager.Instance.GetMaximumNumberOfPlayers()`します。 SignInManager がサインインにプレーヤーによってそのプレイヤーのインデックス作成のディクショナリ*playerNumber*します。 これを使用するにはそれに関連付けられたからアクセス可能なプレーヤーに関する基本的な情報を取得する`XboxLiveUser`します。

```csharp
if (SignInManager.Instance.GetPlayer(this.playerNumber).IsSignedIn) // If there is a player signed in for this gameObjects player number
            {
                this.displayedGamertag = SignInManager.Instance.GetPlayer(this.playerNumber).Gamertag; // Set that users gamertag to the gamertag displayed
            }
```

この少しのコードでは、この GameObject のプレーヤー数スロットにサインインして、プレーヤーがあるかどうかを確認し、し署名されている場合に表示するには、そのユーザー ゲーマータグを格納します。 中に、`XboxLiveUser`のように、サインインしているユーザー ゲーマータグ、Xbox ユーザー ID を他のサービスを呼び出す必要があります (xuid) でを含む、 `SocialManager` gamerpic やゲーマーのような情報にアクセスします。

## <a name="destroying-your-sign-in-gameobject"></a>破棄、サインインが GameObject

などのプラグインの Xbox Live マネージャーのいずれかを使用するゲーム オブジェクトを破棄するときに、`SignInManager`または`SocialManager`、通常は、マネージャーのイベント リスナーのリストに追加されたすべての関数を削除する重要な新しいシーンを読み込むときにします。 この記事のコード例では、サインインとサインアウトのイベント リスナーを追加しました関数を削除する必要があります。これらの関数から削除するところ、`SignInManager`で、 `OnDestroy()` GameObject の関数。

```csharp
private void OnDestroy()
{
    if (SignInManager.Instance != null)
    {
        SignInManager.Instance.RemoveCallbackFromPlayer(this.PlayerNumber, this.OnPlayerSignOut);
        SignInManager.Instance.RemoveCallbackFromPlayer(this.PlayerNumber, this.OnPlayerSignIn);
    }
```

このコードはこの GameObject に関連付けられているプレイヤーのサインインとサインアウトのコールバック関数を削除します。

## <a name="testing-you-code-in-visual-studio"></a>Visual Studio でコードをテストします。

加え、 [Visual Studio でゲームをビルドに必要な手順](configure-xbox-live-in-unity.md#build-and-test-the-project)に表示されている、 [for Unity、Xbox Live タイトルを構成する](configure-xbox-live-in-unity.md)に関する記事で、適切にゲームをテストするために必要な追加の手順がVisual Studio。 Package.appxmanifest.xml ファイルのプロパティを更新する必要があります。 これには、次の手順を実行します。

1. Package.appxmanifest.xml ファイルの ソリューション エクスプ ローラーを検索します。
2. ファイルを右クリックし、コードの表示
3. で、`<Properties><\/Properties>`セクションで、次の行を追加します: ' < uap:SupportedUsers > 複数 <\/uap:SupportedUsers >。
4. お使いの Xbox にゲームを Visual Studio からリモートのデバッグ ビルドを開始して展開します。 Xbox、タイトルを設定する命令を見つけることができます、 [Xbox 開発環境で、UWP 設定](../../xbox-apps/development-environment-setup.md)記事。

> [!NOTE]
> 構成の変更の一部は、マルチ プレーヤーは有効にするが、1 つのプレーヤーのシナリオで、ゲームを実行する必要がように見える場合があります。

## <a name="policies-and-limitations"></a>ポリシーと制限事項

いくつかのサインイン ポリシーと、タイトルのサインイン エクスペリエンスを開発する際に考慮が必要なの制限事項があります。

- タイトルの初回サインイン後に、サインイン済みの少なくとも 1 つのプレーヤーを保持する必要があります。 `SignInManager`はエラーをスローし、最後にサインインしているユーザーのサインアウトしようとした場合、呼び出しは失敗します。 呼び出すことはできないことに注意してください。`SignInManager.Instance.SwitchUser(int playerNumber)`の最後でサインインして player 新しいプレーヤーをサインインする前に、プレーヤーのサインアウトしようとします。

- PC は、コンソールは一度に最大 16 のプレーヤーで署名一度にのみサインインが 1 人のユーザーをできます。

- タイトルは、実際には、プレーヤーを OS からサインアウトする権限がありません、ためこのサインアウトが正常に動作しません。 SignInManager は in および out タイトルでは、ここにユーザーがサインインすることができますが、できないすべてのユーザーからサインアウトにタイトルが展開されているコンピューター。

- 複数のユーザー サインインが Xbox の 1 つのコンソールで使用できるのみです。

- ゲスト アカウントでは、Xbox Live クリエーターズ プログラムのタイトルに使用できません。