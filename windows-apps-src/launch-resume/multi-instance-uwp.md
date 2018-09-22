---
author: TylerMSFT
title: マルチインスタンスのユニバーサル Windows アプリの作成
description: このトピックでは、マルチインスタンスをサポートする UWP アプリを記述する方法について説明します。
keywords: マルチインスタンス UWP
ms.author: twhitney
ms.date: 09/19/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
ms.localizationpriority: medium
ms.openlocfilehash: 9302ed0375739153eb95ac2b54c1ed396b14daee
ms.sourcegitcommit: a160b91a554f8352de963d9fa37f7df89f8a0e23
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/21/2018
ms.locfileid: "4126997"
---
# <a name="create-a-multi-instance-universal-windows-app"></a>マルチインスタンスのユニバーサル Windows アプリの作成

このトピックでは、マルチインスタンスのユニバーサル Windows プラットフォーム (UWP) アプリを作成する方法について説明します。

Windows 10、バージョン 1803 (10.0; からビルド 17134)、UWP アプリは複数のインスタンスをサポートするためにオプトイン以降、します。 マルチインスタンス UWP アプリのインスタンスが実行されていて、後続のライセンス認証要求が行われた場合、既存のインスタンスはアクティブ化されません。 代わりに、別のプロセスで実行される、新しいインスタンスが作成されます。

## <a name="opt-in-to-multi-instance-behavior"></a>マルチ インスタンスの動作にオプトインします。

新しいマルチインスタンス アプリケーションを作成する場合は、[Visual Studio Marketplace](https://aka.ms/E2nzbv) から入手可能な **Multi-Instance App Project Templates.VSIX** をインストールします。 テンプレートをインストールすると、**[Visual C#] > [Windows ユニバーサル]** の **[新しいプロジェクト]** ダイアログ (または **[他の言語] > [Visual C++] > [Windows ユニバーサル]**) で使用可能になります。

2 つのテンプレートがインストールされます。**Multi-Instance UWP app** は、マルチインスタンス アプリを作成するためのテンプレートを提供します。**Multi-Instance Redirection UWP app** は、新しいインスタンスを起動するか、すでに起動されているインスタンスを選択的にアクティブ化するために構築する追加ロジックを提供します。 たとえば、一度に 1 つのインスタンスのみを同じドキュメントを編集する場合は、新しいインスタンスを起動するのではなく、そのファイルを開いているインスタンスをフォアグラウンドにします。

どちらのテンプレートの追加`SupportsMultipleInstances`を`package.appxmanifest`ファイル。 名前空間のプレフィックスに注意してください`desktop4`と`iot2`: デスクトップをターゲットとする唯一のプロジェクトまたはモ ノのインターネット (IoT) プロジェクトでは、マルチ インスタンスをサポートします。

```xml
<Package
  ...
  xmlns:desktop4="http://schemas.microsoft.com/appx/manifest/desktop/windows10/4"
  xmlns:iot2="http://schemas.microsoft.com/appx/manifest/iot/windows10/2"  
  IgnorableNamespaces="uap mp desktop4 iot2">
  ...
  <Applications>
    <Application Id="App"
      ...
      desktop4:SupportsMultipleInstances="true"
      iot2:SupportsMultipleInstances="true">
      ...
    </Application>
  </Applications>
   ...
</Package>
```

## <a name="multi-instance-activation-redirection"></a>マルチインスタンスアクティブ化のリダイレクト

 UWP アプリのマルチインスタンス化のサポートは、単に複数のアプリ インスタンスを起動することを可能にするだけではありません。 アプリの新しいインスタンスを起動するか、すでに実行しているインスタンスをアクティブにするかを選択する場合に、カスタマイズできます。 たとえば、既に別のインスタンスで編集中のファイルを編集するためにアプリが起動されている場合、そのファイルを編集している別のインスタンスを開くのではなく、そのインスタンスにアクティブ化をリダイレクトすることができます。

アクションの表示は、マルチ インスタンス UWP アプリの作成に関するこのビデオをご覧ください。

> [!VIDEO https://www.youtube.com/embed/clnnf4cigd0]

**Multi-Instance Redirection UWP app** テンプレートは、上記のように `SupportsMultipleInstances` を package.appxmanifest ファイルに追加し、さらに `Main()` 関数を含むプロジェクトに **Program.cs** (または、テンプレートの C++ バージョンを使用している場合は **Program.cpp**) を追加します。 アクティブ化をリダイレクトするためのロジックは `Main` 関数にあります。 **Program.cs**用のテンプレートは、次に示します。

[AppInstance.RecommendedInstance](/uwp/api/windows.applicationmodel.appinstance.recommendedinstance)を表すこのライセンス認証要求のシェルが提供する、推奨されるインスタンスが存在する場合 (または`null`かどうかではありません)。 シェルは、基本設定を提供する場合することができることができますのアクティブ化そのインスタンスにしたり、リダイレクトを選択した場合に無視することができます。

``` csharp
public static class Program
{
    // This example code shows how you could implement the required Main method to
    // support multi-instance redirection. The minimum requirement is to call
    // Application.Start with a new App object. Beyond that, you may delete the
    // rest of the example code and replace it with your custom code if you wish.

    static void Main(string[] args)
    {
        // First, we'll get our activation event args, which are typically richer
        // than the incoming command-line args. We can use these in our app-defined
        // logic for generating the key for this instance.
        IActivatedEventArgs activatedArgs = AppInstance.GetActivatedEventArgs();

        // If the Windows shell indicates a recommended instance, then
        // the app can choose to redirect this activation to that instance instead.
        if (AppInstance.RecommendedInstance != null)
        {
            AppInstance.RecommendedInstance.RedirectActivationTo();
        }
        else
        {
            // Define a key for this instance, based on some app-specific logic.
            // If the key is always unique, then the app will never redirect.
            // If the key is always non-unique, then the app will always redirect
            // to the first instance. In practice, the app should produce a key
            // that is sometimes unique and sometimes not, depending on its own needs.
            string key = Guid.NewGuid().ToString(); // always unique.
                                                    //string key = "Some-App-Defined-Key"; // never unique.
            var instance = AppInstance.FindOrRegisterInstanceForKey(key);
            if (instance.IsCurrentInstance)
            {
                // If we successfully registered this instance, we can now just
                // go ahead and do normal XAML initialization.
                global::Windows.UI.Xaml.Application.Start((p) => new App());
            }
            else
            {
                // Some other instance has registered for this key, so we'll 
                // redirect this activation to that instance instead.
                instance.RedirectActivationTo();
            }
        }
    }
}
```

`Main()` これは実行する最初のものです。 [OnLaunched()](https://docs.microsoft.com/uwp/api/windows.ui.xaml.application#Windows_UI_Xaml_Application_OnLaunched_Windows_ApplicationModel_Activation_LaunchActivatedEventArgs_) と [OnActivated](https://docs.microsoft.com/uwp/api/windows.ui.xaml.application#Windows_UI_Xaml_Application_OnActivated_Windows_ApplicationModel_Activation_IActivatedEventArgs_) の前に実行します。 これにより、アプリの他の初期化コードが実行される前に、これをアクティブ化するか別のインスタンスをアクティブ化するかを決定できます。

上記のコードは、アプリケーションの既存のインスタンスまたは新しいインスタンスがアクティブになっているかどうかを判断します。 キーを使用して、アクティブ化する既存のインスタンスがあるかどうかを判断します。 たとえば、アプリを起動して [ファイルのアクティブ化の処理](https://docs.microsoft.com/en-us/windows/uwp/launch-resume/handle-file-activation) ができる場合は、ファイル名をキーとして使用できます。 次に、アプリのインスタンスがすでにそのキーに登録されているかどうかを確認し、新しいインスタンスを開く代わりにそれをアクティブにすることができます。 これはコード ビハインド アイデアです。 `var instance = AppInstance.FindOrRegisterInstanceForKey(key);`

キーに登録されているインスタンスが見つかった場合は、そのインスタンスがアクティブになります。 キーが見つからない場合は、現在のインスタンス (現在 `Main` を実行しているインスタンス) がそのアプリケーション オブジェクトを作成し、実行を開始します。

## <a name="background-tasks-and-multi-instancing"></a>バックグラウンド タスクとマルチインスタンス

- アウトプロセスのバックグラウンド タスクは、マルチインスタンスをサポートします。 通常、新しいトリガーはバックグラウンド タスクの新しいインスタンスを生成します (ただし、技術的には複数のバックグラウンド タスクが同じホスト プロセスで実行される可能性があります)。 それでも、バックグラウンド タスクの別のインスタンスが作成されます。
- インプロセスのバックグラウンド タスクは、マルチインスタンスをサポートしません。
- バックグラウンドのオーディオ タスクは、マルチインスタンスをサポートしません。
- アプリがバックグラウンド タスクを登録すると、通常、タスクがすでに登録されているかどうかを確認し、削除または再登録するか、既存の登録を維持するために何もしません。 これは、マルチインスタンス アプリの典型的な動作です。 しかし、マルチインスタンス アプリでは、インスタンスごとに異なるバックグラウンド タスク名を登録することを選択する場合があります。 これにより、同じトリガーに対して複数の登録が行われ、トリガーが起動すると複数のバックグラウンド タスクのインスタンスがアクティブになります。
- アプリ サービスは、すべての接続に対してアプリ サービス バックグラウンド タスクの別のインスタンスを起動します。 マルチインスタンス アプリの場合、これは変更されません。つまり、マルチインスタンス アプリの各インスタンスは、独自のアプリ サービス バックグラウンド タスクのインスタンスを取得します。 

## <a name="additional-considerations"></a>その他の考慮事項

- マルチ インスタンスは、デスクトップやモノのインターネット (IoT) プロジェクトをターゲットとする UWP アプリでサポートされています。
- 競合状態や競合の問題を避けるため、マルチインスタンス アプリは、設定、アプリ ローカル ストレージ、その他のリソース (ユーザー ファイル、データストアなど) へのアクセスをパーティション化/同期化するための手順を実行する必要があります。これらのリソースは、複数のインスタンス間で共有できます。 ミューテックス、セマフォ、イベントなどの標準的な同期メカニズムが使用可能です。
- アプリで、Package.appxmanifest ファイルに `SupportsMultipleInstances` がある場合、その拡張機能は `SupportsMultipleInstances` を宣言する必要はありません。 
- `SupportsMultipleInstances` をバックグラウンド タスクやアプリ サービス以外の拡張機能に追加し、その拡張機能をホストするアプリが Package.appxmanifest ファイルで `SupportsMultipleInstances` を宣言しない場合は、スキーマ エラーが生成されます。
- アプリは、マニフェストに [ResourceGroup](https://docs.microsoft.com/windows/uwp/launch-resume/declare-background-tasks-in-the-application-manifest) 宣言を使用して、複数のバックグラウンド タスクを同じホストにグループ化することができます。 これはマルチインスタンスと競合し、それぞれのアクティブ化は別々のホストに入ります。 したがって、アプリはマニフェストで `SupportsMultipleInstances` と `ResourceGroup` の両方を宣言することはできません。

## <a name="sample"></a>サンプル

マルチ インスタンス化のリダイレクトの例については、[マルチ インスタンスのサンプル](https://aka.ms/Kcrqst)を参照してください。

## <a name="see-also"></a>関連項目

[AppInstance.FindOrRegisterInstanceForKey](https://docs.microsoft.com/uwp/api/windows.applicationmodel.appinstance#Windows_ApplicationModel_AppInstance_FindOrRegisterInstanceForKey_System_String_)
[AppInstance.GetActivatedEventArgs](https://docs.microsoft.com/uwp/api/windows.applicationmodel.appinstance#Windows_ApplicationModel_AppInstance_GetActivatedEventArgs)
[AppInstance.RedirectActivationTo](https://docs.microsoft.com/uwp/api/windows.applicationmodel.appinstance#Windows_ApplicationModel_AppInstance_RedirectActivationTo)
[アプリのアクティブ化の処理](https://docs.microsoft.com/windows/uwp/launch-resume/activate-an-app)