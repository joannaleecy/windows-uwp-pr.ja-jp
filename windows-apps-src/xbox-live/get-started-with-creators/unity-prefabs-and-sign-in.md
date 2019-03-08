---
title: Unity のプレハブとサインインの XBL
description: ソーシャル プレハブと Xbox Live のソーシャル サービスのスクリプトの例について説明します
ms.date: 01/24/2018
ms.topic: get-started-article
keywords: xbox live、xbox、ゲーム、uwp、windows 10、1 つ xbox、unity
ms.openlocfilehash: a893858dac11fa848c2601df2c1bd6292b72ac6d
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57660037"
---
# <a name="unity-prefabs-and-scripted-sign-in"></a>Unity のプレハブとスクリプト化されたサインイン

この記事では、Unity プロジェクトを Xbox Live サインインの追加を説明します。 ダウンロードした場合、サインインを実現する 2 つの方法がある、 [Xbox Live の Unity プラグイン](https://github.com/Microsoft/xbox-live-unity-plugin)します。 プラグイン内に含まれるプレハブを使用するか、スクリプトと含まれるライブラリを使用して、独自のカスタムの Gameobject に Xbox Live サインイン スクリプト可能性があります。

> [!IMPORTANT]
> この記事では、更新が (1804 のリリース) を 2018 年の月に行われる前に、プラグインのバージョンに適用されます。 その後は、Xbox Live プラグインをインストールするか、またはまだダウンロードしない場合は、サインインが実行方法に大きな違いのある新しいバージョンがあります。 これだけでなくこのプラグインのスクリーン ショットが一致しないこと、この最新リリースのものが表示されます。 代わりを参照してください、[に関する記事を更新されたサインイン プレハブ](playerauthentication-prefab-sign-in.md)だけでなく[サインイン スクリプトを実行して更新されたメソッドの詳細を示す記事](sign-in-manager.md)します。

## <a name="before-you-begin"></a>始める前に

Unity ゲームを Xbox Live のソーシャル サービスの追加を開始する前に、いくつかの手順進む前に完了する必要があります。 まず、ダウンロードし、統合されていることを確認してください、 [Xbox Live の Unity プラグイン](https://github.com/Microsoft/xbox-live-unity-plugin)します。 タイトルを予約し、経由で公開したい 2 つ目は、 [Microsoft 開発センター](https://developer.microsoft.com/en-us/games/uwp)します。 読み取り[新しい Xbox Live クリエーターズ プログラムのタイトルを作成する](../get-started-with-creators/create-and-test-a-new-creators-title.md)手順については、タイトルを公開する方法。
最後に、読み取る[構成 Xbox Live で Unity](../get-started-with-creators/configure-xbox-live-in-unity.md) Unity の環境を正しく設定して、Xbox Live サービスを使用するタイトルを構成します。 時間、Xbox Live の有効なタイトルに使用できるツールと Xbox Live を実装 Unity で 2 つの主な方法の詳細については、Unity プロジェクトを正しく設定する、: プレハブとスクリプト。

## <a name="prefabs"></a>プレハブ

Unity では、コンポーネントとプロパティを持つ完全な GameObject を格納できるアセットのプレハブ型があります。 プレハブは、Unity シーンに新しいオブジェクトのインスタンスを作成するテンプレートとして機能します。
[詳細については、Unity の web サイトからプレハブは](https://unity3d.com/learn/tutorials/topics/interface-essentials/prefabs-concept-usage)します。

Xbox Live の Unity プラグインを利用するプロジェクトで使用できるいくつかのプレハブは、Xbox Live 機能。 この記事で説明されているプレハブは、サインインすることにより[マルチ ユーザー サポートを追加](../get-started-with-creators/add-multi-user-support.md)タイトル、または表示の Xbox Live で署名されたフレンド リストをプロファイルします。 これらおよびその他のプレハブの下に見つけることができます、**プロジェクト**タブで、次のパス。**資産 > Xbox Live > プレハブ**します。

### <a name="the-userprofile-prefab"></a>UserProfile プレハブ

最初、最も重要なソーシャル プレハブは、 **UserProfile** prefab します。 **UserProfile**プレハブは、Xbox Live にサインインを許可するために必要なすべてのものです。 これは、する必要があります、サインイン ユーザー Xbox Live サービスを使用する前に、非常に重要です。 プレハブには、サインイン ボタンとゲーマータグ、Gamerpic、ゲーマー、player で、ログインしている表現の GameObject の両方が含まれます。

> [!NOTE]
> 含める必要があります、その他の Xbox Live のプレハブを使用するために、 **UserProfile** prefab または手動でサインインしている API を呼び出します。

![資産と階層のユーザー プロファイルのプレハブ](../images/unity/unity-userprofile-views.png)

展開する場合、 **UserProfile**のプレハブ、**プロジェクト**パネルまたは、**階層**シーンに追加された後に表示されている、 **UserProfile**プレハブは、その内部に 2 つの Gameobject を含まれています。 最初のオブジェクトが、 **SignInPanel**サインイン ボタンのエクスペリエンスが含まれています。 2 番目のオブジェクトは、 **ProfileInfo**にサインインした後、ユーザーに関する情報を格納します。 **UserProfile**プレハブは、サインイン済みのローカルで、タイトルに Xbox Live ユーザーの情報を表す何を使用します。

### <a name="the-xboxliveuser-prefab"></a>XboxLiveUser プレハブ

**UserProfile**プレハブと呼ばれる、コード内の 2 つ目のソーシャル プレハブを使用して、 **XboxLiveUser**します。 コードでインスタンス化するだけですが、シーンの階層構造に追加する必要はありませんので、このプレハブの使用はすぐに明らかではありません。 **XboxLiveUser**ビジュアル表現がない Xbox Live ユーザーに関連する詳細が含まれます。 インスタンスが必要、 **XboxLiveUser**のすべてのインスタンス、 **UserProfile**します。 これは重要な場合に[マルチ ユーザー サポートを追加する](../get-started-with-creators/add-multi-user-support.md)をタイトルにします。 サインイン後に、ユーザーに関する情報を保持するだけでなくこのプレハブは、Xbox Live ユーザーをサインインに使用したコードのラッパーではもします。

## <a name="sign-in-with-the-userprofile-prefab"></a>UserProfile プレハブを使用してサインイン

Xbox Live の Unity プラグインのプレハブは、特定の開発タスクをはるかに簡単にするために存在します。 Xbox Live にサインインを使用する必要があります単に、Unity プロジェクト用に有効にする、 **UserProfile**と**XboxLiveServices** Unity と共にプレハブ**EventSystem**します。

最初にドラッグして、 **UserProfile**シーンのプレハブします。 理想的には、 **UserProfile**プロジェクトの最初のメニュー画面に配置する必要があります。

![ユーザー プロファイルを階層にドラッグします。](../images/unity/drag-userprofile.gif)

加え、 **UserProfile**プレハブのことを確認する必要がありますも、 **XboxLiveServices**プレハブは、プロジェクトの最初のシーンには少なくとも内に存在します。
**XboxLiveServices**プレハブは、特定のプレハブにデバッグするための情報をログに実行されたかどうかを切り替えることができます。 これはプレハブの動作を確認するために役立ちます。

![xboxliveservices プレハブの確認します。](../images/unity/check-for-xboxliveservices.gif)

最後に、 **UserProfile**も必要です、 **EventSystem**正常に実行します。 これにはサインイン シーンを右クリックし をクリックして追加できます**GameObject に UI が--> EventSystem-->** します。

![イベント システムを追加します。](../images/unity/add_event_system.gif)

再生モードを入力すると、サービスが自動的にユーザーにサインインします。 Unity は、Xbox Live SDK は、Xbox Live サービスへの呼び出しをシミュレートし、使用するための戻る仮のデータを送信します。 ライブ データを表示するのには、UWP アプリケーションとしてプロジェクトをビルドし、Visual Studio から実行する必要があります。 詳しくは、「[Unity で Xbox Live を構成する](../get-started-with-creators/configure-xbox-live-in-unity.md)」をご覧ください。 入力すると、Unity で再生モード、プレハブはゲーマータグ、Gamerpic プレイヤーのゲーマーなどの情報をシミュレートする仮のデータで設定されます。 これは、情報を表示する必要があります、 **UserProfile** prefab します。

成功したサインインの次のようになります:![成功したユーザー プロファイルの再生](../images/unity/correct-user-profile-play.gif)

Xbox Live への接続に、プロジェクトを構成していない場合は、正しく再生モードを入力すると、サインイン ボタンを無効にして、エラー メッセージを表示します。

次は、無効な Xbox Live アプリ構成により失敗したサインインの例です。
![ユーザー プロファイルの再生に失敗しました](../images/unity/flawed-user-profile-play.gif)

## <a name="scripting-sign-in"></a>サインイン スクリプト

使用する方法がわかったら、 **UserProfile** prefab しまうが最適にプレハブの機能を制御する基になるスクリプトを見ています。 確認する場合、 **UserProfile**で、**インスペクター**があると表示されます、 **UserProfile.cs**スクリプトがアタッチされてです。 このスクリプトにはすべてのサインインを表示するには、プロファイル情報を読み込み、ユーザーがサインインする必要があります。 ただし、(時間の経過と共に更新される可能性があります) を全体のプレハブを調べる代わりここ、Xbox Live ユーザーをサインインに必要なものを理解するためのコードのいくつかのサンプル行を確認します。

### <a name="the-xboxliveuser-class"></a>XboxLiveUser クラス

ユーザーをサインインに必要な呼び出しがラップされる、`XboxLiveUserInfo`クラス。 **UserProfile.cs**スクリプトのインスタンスがあることが表示されます、`XboxLiveUserInfo`と呼ばれるクラス`XboxLiveUser`します。 私たちは、サンプル コードで同じ変数名を使用します。 `XboxLiveUserInfo`クラスにはインスタンスが含まれています、`XboxLiveUser`と呼ばれるクラス`User`としてメンバー変数のいずれか。 `XboxLiveUser`クラスには、サインインに必要なサインイン機能が含まれています、`XboxLiveUser`します。 インスタンスを使用、`XboxLiveUser`クラス`User`サインインのゲーマータグ、Gamerpic、およびゲーマーなどのユーザーもそれらを説明する情報を取得したりします。 これには、インスタンスを初期化する必要があります、`XboxLiveUserInfo`クラスし、その結果を使用して、`XboxLiveUserInfo.User`に呼び出し、サインインします。

### <a name="initialize-the-xboxliveuser"></a>XboxLiveUser を初期化します。

実際にそれらを Xbox Live にサインインする前に、最初の手順は、Xbox Live ユーザーを初期化します。 これは、コードの中で非常に単純を使用して、`XboxLiveUserInfo.Initialize()`関数。
サンプル コードで使用して、`XboxLiveUser`としてメンバー変数、`XboxLiveUserInfo`をインスタンス化と初期化のサインインを使用するようにします。

```csharp
    void ButtonClickTask()
    {
        this.StartCoroutine(this.InitializeXboxLiveUser());
    }

    public IEnumerator InitializeXboxLiveUserAndCallSignIn()
    {
        // Disable the sign-in button
        SignInButton.interactable = false;

        this.XboxLiveUser.Initialize();

        //Wait until the Xbox User has been initialized to call SignInAsync()
        yield return new WaitUntil(() => this.XboxLiveUser != null && this.XboxLiveUser.User != null);
        this.StartCoroutine(this.SignInAsync());
    }
```

このサンプル コードで検索とするが表示されます、`XboxLiveUserInfo.Initialize()`ボタン クリックに応答する関数が呼び出されます。 完全な**UserProfile.cs** prefab スクリプトに自動サインインを可能にするコードがあります、`XboxLiveUserInfo.Initialize()`操作が呼び出されます。
`XboxLiveUserInfo.Initialize()`新しい関数が作成されます`XboxLiveUserInfo.User`に含まれているサインイン関数を呼び出すことができます、`XboxLiveUserInfo.User`クラス。

### <a name="call-sign-in"></a>呼び出しのサインイン

XboxLiveUser が初期化された後を呼び出し、サインイン時間が。 **UserProfile.cs**でというサインイン、 `SignInAsync()` UserProfile.cs の関数。 前の例では待つだけで、`XboxLiveUser`を呼び出す前に初期化、`SignInAsync()`関数。

> [!NOTE]
> 待機する必要がある、`XboxLiveUser`ため、サインインを呼び出す前に初期化される、`XboxLiveUser`が含まれています、`XboxLiveUser.User`に呼び出し、サインインに使用されるプロパティ。

**UserProfile.cs** 、`SignInAsync()`関数には、ユーザーがサインインするために使用する 2 つのサインイン機能が含まれています。 `XboxLiveUser.User.SignInSilentlyAsync()` `XboxLiveUser.User.SignInAsync()`これらは、ユーザーをサインインする関数。 `SignInAsync()`関数は、これらの関数を適切に使用する方法の良い例です。 次のコード サンプルでは、2 つのサインインに関数を呼び出すための 1 つの適切なメソッドを示します。

```csharp
SignInStatus signInStatus;
TaskYieldInstruction<SignInResult> signInSilentlyTask = this.XboxLiveUser.User.SignInSilentlyAsync().AsCoroutine();
yield return signInSilentlyTask;

signInStatus = signInSilentlyTask.Result.Status;
if (signInSilentlyTask.Result.Status != SignInStatus.Success)
{
    TaskYieldInstruction<SignInResult> signInTask = this.XboxLiveUser.User.SignInAsync().AsCoroutine();
    yield return signInTask;

    signInStatus = signInTask.Result.Status;
}
```

この例では、サインインの呼び出しの結果は、変数に格納されます`signInStatus`します。 これにより、またはサインインが成功したかどうかを確認し、それに従って動作することができます。 関数は、まずしようとサインインにサイレント モードでは、この例ではサイレント サインインが失敗すると、関数を呼び出して通常サインオン関数。 ユーザー サインインがサインインしている関数のいずれかに成功した呼び出しを作成したら。 使用できるように、`XboxLiveUser.User`を取得し、サインインしているユーザーに関する詳細を表示します。 見て、`LoadProfileInfo()`関数**UserProfile.cs**を使用する方法の例については、`XboxLiveUser.User`サインインしているユーザーに関する情報を表示します。

## <a name="build-and-test-sign-in"></a>ビルドし、テストにサインイン

エディターでタイトルを実行しているとき、Xbox Live の機能を使おうとすると仮のデータが表示されます。 で実際のプロファイルを使用してサインインして、タイトルで Xbox Live の機能をテストするには、UWP ソリューションを構築し、Visual Studio で実行する必要があります。  次の手順では、Unity での UWP プロジェクトをビルドできます。

1. 開く、 **Build Settings**ウィンドウを選択して**ファイル** > **Build Settings**します。
2. すべての下で、ビルドに含めるシーンを追加、 **Scenes In Build**セクション。
3. 切り替えて、**ユニバーサル Windows プラットフォーム**を選択して**ユニバーサル Windows プラットフォーム****[プラットフォーム]** をクリック**スイッチ プラットフォーム**.
4. 設定**SDK**に**10.0.15063.0**以上。
5. スクリプトのデバッグ チェックを有効にする**UnityC#プロジェクト**します。
6. クリックして**ビルド**し、プロジェクトの場所を指定します。

ビルドが完了すると、Unity には、Visual Studio での実行に必要になる新しい UWP ソリューション ファイルが生成が。

1. 指定したフォルダーを開きます **&lt;ProjectName&gt;.sln** Visual Studio でします。
2. 上部にあるツールバーで選択**x64**を展開し、**ローカル マシン**します。

有効にした場合**スクリプトのデバッグ**Unity から UWP ソリューションを構築したときに、スクリプトに置かれます、**アセンブリ CSharp (ユニバーサル Windows)** プロジェクト。

> [!NOTE]
> Visual Studio のビルドを使用して、実際のデータを使用して、ゲームをテストする、前に以下の[このチェックリスト](test-visual-studio-build.md)タイトルが Xbox Live サービスにアクセスできるようにします。

## <a name="troubleshooting"></a>トラブルシューティング

発生した場合、Xbox Live へのサインインの問題では、読み取りを再試行してください[トラブルシューティング Xbox Live サインイン](../using-xbox-live/troubleshooting/troubleshooting-sign-in.md)します。
