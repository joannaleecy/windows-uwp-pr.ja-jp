---
author: joannaleecy
title: "市販デモ エクスペリエンス (RDX) アプリを作成する"
description: "単一のアプリで市販デモ モードと通常モードの両方を起動できる市販デモ エクスペリエンス (RDX) アプリの作成"
ms.assetid: f83f950f-7fdd-4f18-8127-b92a8f400061
translationtype: Human Translation
ms.sourcegitcommit: ccc7cfea885cc9c8803cfc70d2e043192a7fee84
ms.openlocfilehash: ca9e27944cc4504400191ef1620949b1e8b64ff2

---
#  <a name="create-a-retail-demo-experience-rdx-app"></a>市販デモ エクスペリエンス (RDX) アプリを作成する

小売店や小売拠点を訪れるお客様は、展示されている最新の PC や携帯電話を見るためにご来店になります。展示されているこれらのデバイスは、市販デモ デバイスと呼ばれます。 お客様の多くはかなりの時間をこれらのデバイスの試用に費やすため、このような市販デモ デバイスやそれらにインストールされているコンテンツは、店舗におけるお客様のエクスペリエンスに大きな影響を与えます。

小売店でこれらの PC や携帯電話にインストールするアプリには、市販デモ エクスペリエンス (RDX) アプリを使う必要があります。 この記事では、小売店で PC や携帯電話のデモ デバイスにインストールする市販デモ バージョンのアプリを設計および開発する方法について概要を説明します。

市販デモ エクスペリエンス アプリは、単一のビルドで _通常_モードと_市販_モードの 2 つの異なるモードで起動できます。 お客様は 2 つのモードが存在することをご存じないため、2 つのバージョンを区別できるように、市販モードで実行されるアプリにはタイトル バーなどの適切な場所に "市販" とわかりやすく表示することをお勧めします。

RDX アプリは、ご来店のお客様に常に肯定的なエクスペリエンスを提供できるように、アプリのストア要件に加え、市販デモ デバイスの設定、クリーンアップ、システム更新に完全に対応している必要があります。

## <a name="design-principles"></a>設計原則

### <a name="show-your-best"></a>最大のメリットを提示

市販デモ モードは、アプリケーションのメリットを伝えるために使ってください。  多くの場合、これはお客様がこのアプリケーションに触れる最初の機会です。最も魅力的な部分をアピールしましょう。
    
### <a name="show-it-fast"></a>スピーディな伝達

お客様に見ていただける時間は限られています。アプリの真価がすぐに実感できるように構成してください。 
    
### <a name="keep-the-story-simple"></a>シンプルなストーリー
    
市販デモ モードは、ごく限られた時間でアプリの真価を伝えるチャンスであることを常に意識してください。
    
### <a name="focus-on-the-experience"></a>エクスペリエンスを重視

お客様がコンテンツを理解する時間を設けましょう。  魅力的な部分をすばやく伝えることは重要ですが、適切な空白時間を設けることでエクスペリエンスがさらに向上します。

## <a name="technical-requirements"></a>技術的要件

市販デモ エクスペリエンス アプリは、ご来店のお客様にアプリの真価をご理解いただくことを目的としているため、次の技術的要件を満たすと共に、すべての市販デモ エクスペリエンス アプリに関してストアが定めるプライバシー規則に従うことが重要です。
以下はチェックリストとして利用して、検証プロセスの準備や、テスト プロセスの明確化に役立てることもできます。 これらの要件は、検証プロセスだけでなく、アプリが市販デモ デバイスで実行される限り、市販デモ エクスペリエンス アプリのライフタイム全体にわたって満たす必要があります。

### <a name="critical-level-requirements"></a>必須レベルの要件
   
これらの必須要件を満たしていない RDX アプリは、可能な限り速やかにすべての市販デモ デバイスから削除されます。

* 個人を特定できる情報 (PII) を尋ねない

    アプリは、お客様個人を特定できる情報を尋ねてはなりません。  これにはすべての Microsoft アカウント情報や詳細な連絡先などが含まれます。
    
* エラーのないエクスペリエンス

    アプリは、エラーなしで動作する必要があります。 また市販デモ デバイスを使うお客様に、エラー ポップアップやエラー通知を表示してはなりません。 デモではお客様に製品の魅力をアピールすることが重要であり、エラーがないことはその絶対条件です。 
    またエラーによって、アプリ自体、アプリの開発者のブランド、アプリが動作するデバイス、デバイスの製造者、Microsoft のイメージが損なわれます。
    
* 試用モード (有料アプリの場合)

    市販デモ デバイスにアプリをインストールするには、アプリが無料アプリであるか、正式な試用モードを持つ必要があります。  お客様は小売店での試用に料金を支払うことは想定していません。 詳しくは、「[試用版での機能の除外または制限](https://msdn.microsoft.com/windows/uwp/monetize/exclude-or-limit-features-in-a-trial-version-of-your-app)」をご覧ください。

### <a name="high-priority-requirements"></a>優先度の高い要件
    
これらの優先度の高い要件を満たしていない RDX アプリは、直ちに調査して修正する必要があります。 直ちに修正されない場合、このアプリをすべての市販デモ デバイスから削除することがあります。

* 優れたオフライン エクスペリエンス

    小売拠点に展示されているデバイスの約 50% がオフラインであるため、市販デモ エクスペリエンス アプリは優れたオフライン エクスペリエンスを提供する必要があります。 この要件は、お客様がオフラインでアプリを操作する場合でも、意味のある肯定的なエクスペリエンスを保証することを目的としています。
    
* 更新済みのコンテンツ エクスペリエンス

    優れたエクスペリエンスを提供するためには、アプリがオンラインの場合に、お客様にアプリケーションの更新を求めるメッセージが表示されないように、アプリを常に最新の状態に保つ必要があります。
        
* 匿名通信の禁止

    市販デモ デバイスを使うお客様は匿名ユーザーであるため、デバイスからのメッセージ送信やコンテンツの共有を抑制する必要があります。
    
* クリーンアップ処理を利用した一貫したエクスペリエンスの提供

    市販デモ デバイスは、使用開始にあたってすべてのお客様に同じエクスペリエンスを提供する必要があります。 前のお客様の操作結果が次のお客様に表示されないように、使用が終了するたびにアプリで[クリーンアップ処理](#clean-up-process)を利用して、同じ既定の状態に戻す必要があります。  これには、スコアボード、達成度、ロック解除が含まれます。
    
* 年齢に応じた適切なコンテンツ

    すべての市販デモ エクスペリエンス アプリのコンテンツは、ティーン以下の年齢区分向けでなければなりません。 詳しくは、[アプリの評価に関する IARC のページ](https://www.globalratings.com/for-developers.aspx)および「[ESRB 評価に関するページ](https://www.esrb.org/ratings/ratings_guide.aspx)をご覧ください。
    
### <a name="medium-priority-requirements"></a>中程度の優先度の要件

Windows リテール ストア チームは、これらの問題の修正方法について、直接開発者に連絡して話し合いの場を設けることがあります。

* 多様なデバイスで正常に動作する能力

    市販デモ エクスペリエンス アプリは、ローエンド仕様のデバイスを含む、すべてのデバイスで適切に動作する必要があります。 そのアプリで要求される最小限の仕様を満たさないデバイスに市販デモ エクスペリエンス アプリをインストールする場合は、そのことをアプリで明確に表示する必要があります。 アプリが常に高いパフォーマンスで動作できるように、最小のデバイス要件を明らかにする必要があります。
     
* 小売店用アプリ サイズ要件への適合
    
    アプリのサイズは、800 MB 未満である必要があります。 市販デモ エクスペリエンス アプリがこのサイズ要件を満たしていない場合は、Windows リテール ストア チームに直接お問い合わせください。

## <a name="preparing-codebase-for-retail-demo-mode-development"></a>市販デモ モード開発用のコードベースの準備

アプリケーションを_通常_モードと_市販_モードのいずれのコード パスで実行するかを指定するブール インジケーターには、Windows 10 SDK の [Windows.System.Profile](https://msdn.microsoft.com/library/windows/apps/windows.system.profile.aspx) 名前空間に含まれる [**RetailInfo**](https://msdn.microsoft.com/library/windows/apps/windows.system.profile.retailinfo.aspx) ユーティリティ クラスの [**IsDemoModeEnabled**](https://msdn.microsoft.com/library/windows/apps/windows.system.profile.retailinfo.isdemomodeenabled.aspx) プロパティを使用します。 

[**RetailInfo.IsDemoModeEnabled**](https://msdn.microsoft.com/library/windows/apps/windows.system.profile.retailinfo.isdemomodeenabled.aspx) が true なったときに、[**RetailInfo.Properties**](https://msdn.microsoft.com/library/windows/apps/windows.system.profile.retailinfo.properties.aspx) を使ってデバイスに関する一連のプロパティを照会することで、さらにカスタマイズした市販デモ エクスペリエンスを構築できます。 これらのプロパティには、[**ManufacturerName**](https://msdn.microsoft.com/library/windows/apps/windows.system.profile.knownretailinfoproperties.manufacturername.aspx)、[**Screensize**](https://msdn.microsoft.com/library/windows/apps/windows.system.profile.knownretailinfoproperties.screensize.aspx)、[**Memory**](https://msdn.microsoft.com/library/windows/apps/windows.system.profile.knownretailinfoproperties.memory.aspx) などが含まれます。 


## <a name="clean-up-process"></a>クリーンアップ処理

一定時間デバイスの操作がない場合は、クリーンアップ処理を使って市販デモ デバイスを元の既定の設定に自動的にリセットします。 この処理により、小売店でお客様がデバイスの試用を開始するとき、デバイスを操作するすべてのお客様に対して、既定のエクスペリエンスが適切に提供されます。 市販デモ エクスペリエンス アプリの開発にあたっては、クリーンアップ処理を開始するタイミングと方法に加え、既定のクリーンアップ処理で行う動作を理解することが重要です。また目的の市販デモ エクスペリエンスの要件に応じて、このクリーンアップ処理をカスタマイズする方法を把握する必要があります。

### <a name="when-does-clean-up-begin"></a>クリーンアップ処理を開始するタイミング

クリーンアップ シーケンスは、デバイスのアイドル時間が一定の長さに達した後に開始します。 アイドル時間は、タッチ、マウス、デバイス上のキーボード入力がない場合に、カウントを開始します。

#### <a name="desktoppc"></a>デスクトップ/PC

120 秒のアイドル時間の後、アイドル状態を予告するアプリ ビデオがデバイス上で再生を開始します。 5 秒後、クリーンアップ処理が開始します。

#### <a name="phone"></a>携帯電話

60 秒のアイドル時間の後、アイドル状態を予告するアプリ ビデオがデバイス上で再生を開始し、即座にクリーンアップ処理が開始します。

### <a name="what-happens-during-a-default-clean-up-process"></a>既定のクリーンアップ処理の動作

#### <a name="step-1-clean-up"></a>手順 1: クリーンアップ
* すべての Win32 アプリとストア アプリが終了します
* __ピクチャ__、__ビデオ__、__ミュージック__、__ドキュメント__、__保存済みの写真__、__カメラロール__、__デスクトップ__、__ダウンロード__フォルダーなどのすべての既知のフォルダーが削除されます
* 構造化されていないローミング状態と構造化されたローミング状態が削除されます
* 構造化されたローカル状態が削除されます

#### <a name="step-2-set-up"></a>手順2: 設定 
* オフライン デバイスの場合: フォルダーは空のままです
* オンライン デバイスの場合: Windows ストアから市販デモ アセットがデバイスにプッシュされます

### <a name="how-to-store-data-across-user-sessions"></a>ユーザー セッション間でデータを保存する方法

ユーザー セッション間でデータを保存する場合は、情報を __ApplicationData.Current.TemporaryFolder__ に格納します。このフォルダーのデータは、既定のクリーンアップ処理によって自動的に削除されません。 *LocalState* を使って保存した情報は、クリーンアップ処理中に削除されることに注意してください。 

### <a name="how-to-customize-the-clean-up-process"></a>クリーンアップ処理をカスタマイズする方法

クリーンアップ処理をカスタマイズする場合は、`Microsoft-RetailDemo-Cleanup` アプリ サービスをアプリに実装する必要があります。 

カスタムのクリーンアップ ロジックが必要なシナリオには、負荷の高いセットアップの実行、データのダウンロードとキャッシュ、*LocalState* データを削除したくない場合などがあります。

手順 1: アプリケーション マニフェストで _Microsoft-RetailDemo-Cleanup_ サービスを宣言します。
``` CSharp
  <Applications>
      <Extensions>
        <uap:Extension Category="windows.appService" EntryPoint="MyCompany.MyApp.RDXCustomCleanupTask">
          <uap:AppService Name="Microsoft-RetailDemo-Cleanup" />
        </uap:Extension>
      </Extensions>
   </Application>
  </Applications>

``` 

手順 2: 下のサンプル テンプレートを使って、_AppdataCleanup_ ケース関数の下に、カスタムのクリーンアップ ロジックを実装します。
``` CSharp
using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Threading;
using System.Threading.Tasks;
using Windows.ApplicationModel.AppService;
using Windows.ApplicationModel.Background;
using Windows.Foundation.Collections;
using Windows.Storage;

namespace MyCompany.MyApp
{
    public sealed class RDXCustomCleanupTask : IBackgroundTask
    {
        BackgroundTaskCancellationReason _cancelReason = BackgroundTaskCancellationReason.Abort;
        BackgroundTaskDeferral _deferral = null;
        IBackgroundTaskInstance _taskInstance = null;
        AppServiceConnection _appServiceConnection = null;

        const string MessageCommand = "Command";

        public void Run(IBackgroundTaskInstance taskInstance)
        {
            // Get the deferral object from the task instance, and take a reference to the taskInstance;
            _deferral = taskInstance.GetDeferral();
            _taskInstance = taskInstance;
            _taskInstance.Canceled += new BackgroundTaskCanceledEventHandler(OnCanceled);

            AppServiceTriggerDetails appService = _taskInstance.TriggerDetails as AppServiceTriggerDetails;
            if ((appService != null) && (appService.Name == "Microsoft-RetailDemo-Cleanup"))
            {
                _appServiceConnection = appService.AppServiceConnection;
                _appServiceConnection.RequestReceived += _appServiceConnection_RequestReceived;
                _appServiceConnection.ServiceClosed += _appServiceConnection_ServiceClosed;
            }
            else
            {
                _deferral.Complete();
            }
        }

        void _appServiceConnection_ServiceClosed(AppServiceConnection sender, AppServiceClosedEventArgs args)
        {
        }

        async void _appServiceConnection_RequestReceived(AppServiceConnection sender, AppServiceRequestReceivedEventArgs args)
        {
            //Get a deferral because we will be calling async code 
            AppServiceDeferral requestDeferral = args.GetDeferral();
            string command = null;
            var returnData = new ValueSet();

            try
            {
                ValueSet message = args.Request.Message;
                if (message.ContainsKey(MessageCommand))
                {
                    command = message[MessageCommand] as string;
                }

                if (command != null)
                {
                    switch (command)
                    {
                        case "AppdataCleanup":
                            {
                                // Do custom clean up logic here
                                break;
                            }
                    }
                }
            }
            catch (Exception e)
            {
            }
            finally
            {
                requestDeferral.Complete();
                // Also release the task deferral since we only process one request per instance.
                _deferral.Complete();
            }
        }

        private void OnCanceled(IBackgroundTaskInstance sender, BackgroundTaskCancellationReason reason)
        {
            _cancelReason = reason;
        }
    }
}
```

## <a name="related-links"></a>関連リンク

* [アプリ データの保存と取得](https://msdn.microsoft.com/windows/uwp/app-settings/store-and-retrieve-app-data)
* [アプリ サービスの作成と利用の方法](https://msdn.microsoft.com/windows/uwp/launch-resume/how-to-create-and-consume-an-app-service)
* [グローバリゼーションとローカライズ](https://msdn.microsoft.com/windows/uwp/globalizing/globalizing-portal)


 

 



<!--HONumber=Dec16_HO3-->


