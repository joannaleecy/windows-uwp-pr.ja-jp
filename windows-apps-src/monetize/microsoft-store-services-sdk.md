---
Description: Microsoft Store Services SDK が提供するライブラリとツールを利用すると、収益とユーザーの獲得を図る機能をアプリに追加できます。
title: Microsoft Store Services SDK を使ってユーザーとの関係を深める
ms.assetid: 518516DB-70A7-49C4-B3B6-CD8A98320B9C
ms.date: 08/21/2017
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store Services SDK
ms.localizationpriority: medium
ms.openlocfilehash: 24ec2013735597efae73aee31bb4aee1a8e1413e
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57594987"
---
# <a name="engage-customers-with-the-microsoft-store-services-sdk"></a>Microsoft Store Services SDK を使ってユーザーとの関係を深める

Microsoft Store Services SDK の提供する際に役立つ機能など、アプリを対象となる通知を送信して、A を実行して、ユニバーサル Windows プラットフォーム (UWP) アプリでの顧客とかかわります/、B はアプリで実験します。 この SDK は、Visual Studio 2015 とそれ以降のバージョンの Visual Studio 用の拡張です。

> [!NOTE]
> UWP アプリで広告を表示するには、Microsoft Store Services SDK ではなく [Microsoft Advertising SDK](https://aka.ms/ads-sdk-uwp) を使います。 Advertising ライブラリは、Microsoft Store Services SDK から Microsoft Advertising SDK に移動されました。 詳しくは、「[アプリでの広告の表示](display-ads-in-your-app.md)」をご覧ください。



## <a name="scenarios-supported-by-the-microsoft-store-services-sdk"></a>Microsoft Store Services SDK によりサポートされるシナリオ

この Microsoft Store Services SDK では現在、UWP アプリ向けに次のシナリオがサポートされています。 API リファレンス ドキュメントについては、「[Microsoft Store Services SDK API リファレンス](https://docs.microsoft.com/uwp/api/overview/engagement)」をご覧ください。

|  シナリオ  |  説明   |
|------------|----------------|
|  [実験を実行すると、UWP アプリ B のテスト](run-app-experiments-with-a-b-testing.md)    |  ユニバーサル Windows プラットフォーム (UWP) アプリで A/B テストを実施して、すべてのユーザー向けに機能を公開する前に、一部のユーザーに対して機能の有効性を測定することができます。 使用して、パートナー センターで実験を定義した後、 [StoreServicesExperimentVariation](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicesexperimentvariation)アプリでは、実験では、このデータを使用するテストは、機能の動作を変更するは、バリエーションを取得するクラスを使用して、[LogForVariation](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicescustomeventlogger.logforvariation)パートナー センターにイベントを表示し、変換イベントを送信する方法。 最後に、パートナー センターを使用して、結果を表示したり、実験を管理します。  |
|  [UWP アプリからのフィードバック ハブを起動します。](launch-feedback-hub-from-your-app.md)    |  UWP アプリで [StoreServicesFeedbackLauncher](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicesfeedbacklauncher) クラスを使用し、Windows 10 ユーザーをフィードバック Hub に誘導して、ユーザーが問題、提案、賛成票を送信できるようにします。 次に、このフィードバックを管理、[フィードバック レポート](../publish/feedback-report.md)パートナー センターでします。 |
|  [パートナー センターのプッシュ通知を受信する UWP アプリを構成します。](configure-your-app-to-receive-dev-center-notifications.md)    |  使用して、 [StoreServicesEngagementManager](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicesengagementmanager)パートナー センターを使用してお客様に送信するターゲットを絞ったプッシュ通知を受信するアプリを登録する UWP アプリでのクラス。  |
|   [パートナー センターでの使用状況レポートの UWP アプリでカスタム イベントを記録します。](log-custom-events-for-dev-center.md)   |  使用して、 [StoreServicesCustomEventLogger](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicescustomeventlogger.log)パートナー センターでアプリに関連付けられているカスタム イベントを記録する UWP アプリでのクラス。 その後、カスタム イベントの合計出現回数を確認、**カスタム イベント**のセクション、[使用状況レポート](https://msdn.microsoft.com/windows/uwp/publish/usage-report)パートナー センターでします。  |

<span id="prerequisites" />

## <a name="prerequisites"></a>前提条件

Microsoft Store Services SDK には以下が必要となります。

* Visual Studio 2015 またはそれ以降のバージョン。
* Visual Studio と共にインストールされている ユニバーサル Windows アプリ用 Visual Studio Tools

<span id="install" />

## <a name="install-the-sdk"></a>SDK のインストール

開発用コンピューターに Microsoft Store Services SDK をインストールするには、次の 2 つのオプションがあります。

* **MSI インストーラー**&nbsp;&nbsp;[ここ](https://aka.ms/store-em-sdk)から利用できる MSI インストーラーを使って SDK をインストールできます。
* **NuGet パッケージ**&nbsp;&nbsp;NuGet パッケージとして、SDK をインストールすることができます。

マイクロソフトでは定期的に、向上したパフォーマンスと新しい機能を備えた、新しいバージョンの Microsoft Store Services SDK をリリースしています。 開発用コンピューターに Microsoft Store Services SDK を使っている既存のプロジェクトがあり、そのプロジェクトで最新バージョンを使う場合は、最新バージョンの SDK をダウンロードしてインストールしてください。

<span id="install-msi" />

### <a name="install-via-msi"></a>MSI によるインストール

MSI インストーラーを使って Microsoft Store Services SDK をインストールするには

1.  Visual Studio のすべてのインスタンスを閉じます。

2. Microsoft Store Engagement and Monetization SDK、Universal Ad Client SDK、または Ad Mediator 拡張機能を以前にインストールしていた場合は、それらの SDK をアンインストールします。 必要に応じて、**コマンド プロンプト** ウィンドウを開き、次のコマンドを実行して、Visual Studio と共にインストールされている可能性があり、コンピューター上のインストールされているプログラムの一覧には表示されない可能性がある、古い SDK のバージョンをすべて削除します。
    ```
    MsiExec.exe /x{5C87A4DB-31C7-465E-9356-71B485B69EC8}
    MsiExec.exe /x{6AB13C21-C3EC-46E1-8009-6FD5EBEE515B}
    MsiExec.exe /x{6AC81125-8485-463D-9352-3F35A2508C11}
    ```

3.  [Microsoft Store Services SDK](https://aka.ms/store-em-sdk) をダウンロードしてインストールします。 インストールには数分かかることがあります。 確実に処理が完了するまでお待ちください。

4.  Visual Studio を再起動します。

5.  以前のバージョンの Microsoft Store Services SDK、Microsoft Advertising SDK、Universal Ad Client SDK、Microsoft Store Engagement and Monetization SDK のライブラリを参照する既存のプロジェクトがある場合には、Visual Studio でプロジェクトを開き、プロジェクトをクリーンしてリビルドすることをお勧めします (**ソリューション エクスプ ローラー**でプロジェクト ノードを右クリックして、**[クリーン]** を選択し、次にもう一度プロジェクト ノードを右クリックして、**[リビルド]** を選択します)。

  または、プロジェクトで初めて SDK を使う場合には、[アセンブリ参照をプロジェクトを追加する](#references)ことができます。

<span id="install-nuget" />

### <a name="install-via-nuget"></a>NuGet によるインストール

NuGet を使って Microsoft Store Services SDK をインストールするには

1.  Visual Studio のすべてのインスタンスを閉じます。

2. Microsoft Store Engagement and Monetization SDK、Universal Ad Client SDK、または Ad Mediator 拡張機能を以前にインストールしていた場合は、それらの SDK をアンインストールします。 必要に応じて、**コマンド プロンプト** ウィンドウを開き、次のコマンドを実行して、Visual Studio と共にインストールされている可能性があり、コンピューター上のインストールされているプログラムの一覧には表示されない可能性がある、古い SDK のバージョンをすべて削除します。
    ```
    MsiExec.exe /x{5C87A4DB-31C7-465E-9356-71B485B69EC8}
    MsiExec.exe /x{6AB13C21-C3EC-46E1-8009-6FD5EBEE515B}
    MsiExec.exe /x{6AC81125-8485-463D-9352-3F35A2508C11}
    ```

3.  Visual Studio を起動し、Microsoft Store Services SDK を使用するプロジェクトを開きます。
    > [!NOTE]
    > プロジェクトに SDK の以前の MSI インストールからのライブラリの参照が既に含まれている場合は、これらの参照をプロジェクトから削除します。 これらの参照は、参照先のライブラリが前の手順で削除されたため、その隣に警告アイコンが表示されます。

4. Visual Studio で、**[プロジェクト]** と **[NuGet パッケージの管理]** をクリックします。

5. 検索ボックスに「**Microsoft.Services.Store.Engagement**」と入力し、Microsoft.Services.Store.Engagement パッケージをインストールします。 パッケージのインストールが完了したら、ソリューションを保存します。
    > [!NOTE]
    > **[出力]** ウィンドウに、指定されたパスが長すぎることを示す*インストール パッケージ* エラーが表示されたとき、場合によっては、NuGet を構成して、既定の場所よりも短いパスで示される別の場所にパッケージを展開する必要があります。 これを行うには、```repositoryPath``` 値をコンピューターの nuget.config ファイルに追加し、それを短いフォルダーのパスに割り当て、そこに NuGet パッケージが展開されるようにします。 詳しくは、NuGet ドキュメントの[この記事](https://docs.nuget.org/ndocs/consume-packages/configuring-nuget-behavior)をご覧ください。 または、Visual Studio プロジェクトを短いパスを持つ別のフォルダーに移動してみることができます。 問題が、グローバル パッケージ パスが長すぎるによっても原因。 この場合、追加、 ```globalPackagesFolder``` nuget.config ファイルに値。

6. プロジェクトが含まれている Visual Studio ソリューションを閉じ、そのソリューションを再度開きます。

7.  プロジェクトが NuGet によりインストールされた以前のバージョンの Microsoft Store Services SDK のライブラリを既に参照している場合で、プロジェクトを SDK の新しいリリースに更新する場合には、プロジェクトをクリーンしてリビルドすることをお勧めします (**ソリューション エクスプローラー**でプロジェクト ノードを右クリックして、**[クリーン]** を選択し、次にもう一度プロジェクト ノードを右クリックして、**[リビルド]** を選択します)。

  または、プロジェクトで初めて SDK を使う場合には、[アセンブリ参照をプロジェクトを追加する](#references)ことができます。

<span id="references" />

## <a name="add-the-assembly-reference-to-your-project"></a>アセンブリ参照をプロジェクトを追加する

+MSI インストーラーまたは NuGet により Microsoft Store Services SDK をインストールしたら、次の手順に従って UWP プロジェクトで SDK アセンブリを参照します。

1. Visual Studio でプロジェクトを開きます。
    > [!NOTE]
    > プロジェクトが JavaScript アプリで、ターゲットが **[任意の CPU]** になっている場合は、アーキテクチャ固有のビルド出力 (たとえば **[x86]**) を使うようにプロジェクトを更新します。

2. **ソリューション エクスプローラー**で、**[参照設定]** を右クリックし、**[参照の追加]** を選択します。

3. **[参照マネージャー]** で **[ユニバーサル Windows]** を展開し、**[拡張機能]** をクリックして、**[Microsoft Engagement Framework]** の横のチェック ボックスをオンにします。 これにより、[Microsoft.Services.Store.Engagement](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement) 名前空間の API を使用できます。

3. **[OK]** をクリックします。

> [!NOTE]
> NuGet から SDK ライブラリをインストールした場合、プロジェクトには **Microsoft.Services.Store.Engagement** 参照が含められます。 **Microsoft.Services.Store.Engagement** の参照は (その中のライブラリではなく) NuGet パッケージを表し、これは無視することができます。

<span id="framework" />

## <a name="understanding-framework-packages-in-the-sdk"></a>SDK のフレームワーク パッケージを理解する

Microsoft Store Services SDK の Microsoft.Services.Store.Engagement.dll ライブラリは、*フレームワーク パッケージ*として構成されています。 このライブラリには、[Microsoft.Services.Store.Engagement](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement) 名前空間の API が含まれています。

このライブラリはフレームワーク パッケージであるため、このライブラリを使用するバージョンのアプリをユーザーがインストールすると、このライブラリは、修正されてパフォーマンスが向上した新しいバージョンのライブラリが公開されるたびに、ユーザーのデバイスで Windows Update によって自動的に更新されます。 これにより、利用できる最新バージョンのライブラリがユーザーのデバイスに確実にインストールされます。

このライブラリに新しい API や機能が導入された新しいバージョンの SDK がリリースされた場合は、これらの機能を使用するために最新バージョンの SDK をインストールする必要があります。 このシナリオでは、更新されたアプリをストアに公開する必要もあります。

## <a name="related-topics"></a>関連トピック

* [Microsoft Store Services SDK の API リファレンス](https://docs.microsoft.com/uwp/api/overview/engagement)
* [A/B テストによる実験の実行](run-app-experiments-with-a-b-testing.md)
* [アプリからのフィードバック Hub の起動](launch-feedback-hub-from-your-app.md)
* [パートナー センターのプッシュ通知を受信するアプリを構成します。](configure-your-app-to-receive-dev-center-notifications.md)
* [パートナー センターのカスタム イベントのログ](log-custom-events-for-dev-center.md)
