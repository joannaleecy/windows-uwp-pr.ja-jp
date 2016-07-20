---
author: TylerMSFT
title: "URI に応じた既定のアプリの起動"
description: "URI (Uniform Resource Identifier) に応じて既定のアプリを起動する方法について説明します。 URI を使うと、別のアプリを起動して特定の作業を実行できます。 また、Windows に組み込まれている多くの URI スキームの概要についても説明します。"
ms.assetid: 7B0D0AF5-D89E-4DB0-9B79-90201D79974F
translationtype: Human Translation
ms.sourcegitcommit: 3de603aec1dd4d4e716acbbb3daa52a306dfa403
ms.openlocfilehash: 053746735cb9f11bcdeb2244f33b589e4670974b

---

# URI に応じた既定のアプリの起動


\[ Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください \]


**重要な API**

-   [**LaunchUriAsync**](https://msdn.microsoft.com/library/windows/apps/hh701476)
-   [**PreferredApplicationPackageFamilyName**](https://msdn.microsoft.com/library/windows/apps/hh965482)
-   [**DesiredRemainingView**](https://msdn.microsoft.com/library/windows/apps/dn298314)

URI (Uniform Resource Identifier) に応じて既定のアプリを起動する方法について説明します。 URI を使うと、別のアプリを起動して特定の作業を実行できます。 また、Windows に組み込まれている多くの URI スキームの概要についても説明します。 カスタム URI も起動することができます。 カスタム URI スキームを登録する方法と URI のアクティブ化を処理する方法について詳しくは、「[URI のアクティブ化の処理](handle-uri-activation.md)」をご覧ください。

## URI を起動する方法


URI スキームでは、ハイパーリンクをクリックしてアプリを開くことができます。 **mailto:** を使って新しいメールの作成を開始できるのと同様に、**http:** を使って既定の Web ブラウザーを開くことができます。 このトピックでは、Windows に組み込まれている URI スキームの一部について説明します。

-   [ms-settings: URI スキーム](#settings)は、Windows 設定アプリを起動します。
-   [ms-store: URI スキーム](#store)は、Windows ストア アプリを起動します。
-   [http: URI スキーム](#browser)は、既定の Web ブラウザーを起動します。
-   [mailto: URI スキーム](#email)は、既定の電子メール アプリを起動します。
-   [bingmaps:、ms-drive-to:、ms-walk-to: URI スキーム](#maps)は、Windows マップ アプリを起動します。

たとえば、次の URI は既定のブラウザーを開き、Bing の Web サイトを表示します。

`http://bing.com`

カスタム URI スキームを起動することもできます。 その URI を処理するアプリがインストールされていない場合は、ユーザーにインストールするアプリを推奨することができます。 詳しくは、「[アプリの推奨](#recommend)」をご覧ください。

一般的に、起動するアプリをアプリが選ぶことはできません。 どのアプリを起動するかはユーザーが決めます。 同じ URI スキームを処理するために、複数のアプリを登録できます。 この例外として、予約済みの URI スキームがあります。 予約済みの URI スキームの登録は無視されます。 予約済みの URI スキームの一覧については、「[URI のアクティブ化の処理](handle-uri-activation.md)」をご覧ください。 複数のアプリが同じ URI スキームを登録している可能性がある場合は、アプリで特定のアプリを起動することを推奨できます。 詳しくは、「[アプリの推奨](#recommend)」をご覧ください。

### LaunchUriAsync の呼び出し

URI を起動するには、[**LaunchUriAsync**](https://msdn.microsoft.com/library/windows/apps/hh701476) メソッドを使います。 このメソッドを呼び出すとき、アプリはユーザーに表示されるフォアグラウンド アプリである必要があります。 この要件は、ユーザーが制御を維持するのに役立ちます。 この要件を満たすために、すべての URI 起動がアプリの UI に直接結び付けられていることを確認します。 URI 起動を開始するには、常にユーザーがなんらかの操作を行う必要があります。 URI を起動しようとしたときにアプリがフォアグラウンドにない場合、起動は失敗し、エラー コールバックが呼び出されます。

最初に URI を表す [**System.Uri**](https://msdn.microsoft.com/library/windows/apps/system.uri.aspx) オブジェクトを作成し、それを [**LaunchUriAsync**](https://msdn.microsoft.com/library/windows/apps/hh701476) メソッドに渡します。 次の例のように、返される結果を使って呼び出しが成功したかどうかを確認します。

```cs
private async void launchURI_Click(object sender, RoutedEventArgs e)
{
   // The URI to launch
   var uriBing = new Uri(@"http://www.bing.com");

   // Launch the URI
   var success = await Windows.System.Launcher.LaunchUriAsync(uriBing);

   if (success)
   {
      // URI launched
   }
   else
   {
      // URI launch failed
   }
}
```

場合によって、ユーザーが実際にアプリを切り替えようとしているかどうかを確認するダイアログがオペレーティング システムにより表示されます。

![灰色で表示されたアプリの背景にオーバーレイで表示された警告ダイアログ。 アプリを切り替えるかどうかをたずねるメッセージと、右下隅に [はい] と [いいえ] のボタンが表示されます。 [いいえ] ボタンが強調表示されています。](images/warningdialog.png)

この確認ダイアログを常に表示する場合は、[**Windows.System.LauncherOptions.TreatAsUntrusted**](https://msdn.microsoft.com/library/windows/apps/hh701442) プロパティを使って、オペレーティング システムが警告を表示することを指定します。

```cs
// The URI to launch
var uriBing = new Uri(@"http://www.bing.com");

// Set the option to show a warning
var promptOptions = new Windows.System.LauncherOptions();
promptOptions.TreatAsUntrusted = true;

// Launch the URI
var success = await Windows.System.Launcher.LaunchUriAsync(uriBing, promptOptions);
```

### アプリの推奨

場合によっては、起動中の URI を処理するアプリがインストールされていないこともあります。 既定では、オペレーティング システムによってストア上の適切なアプリを検索するリンクが表示されて、これらのケースは対処されます。 このシナリオで入手する必要のあるアプリに関する特定の推奨事項を示す場合は、起動中の URI と共に推奨事項を渡すことができます。

推奨事項は、URI スキームを処理するアプリが複数登録されているときにも役立ちます。 特定のアプリを推奨すると、そのアプリが既にインストールされている場合、Windows はそのアプリを開きます。

アプリを推奨するには、[**LauncherOptions.preferredApplicationPackageFamilyName**](https://msdn.microsoft.com/library/windows/apps/hh965482) を推奨するストア内のアプリのパッケージ ファミリ名に設定して、[**Windows.System.Launcher.LaunchUriAsync(Uri, LauncherOptions)**](https://msdn.microsoft.com/library/windows/apps/hh701484) メソッドを呼び出します。 オペレーティング システムではこの情報を使って、ストア内のアプリを検索する一般的なオプションを、ストアから推奨アプリを入手する固有のオプションに置き換えます。

```cs
// Set the recommended app
var options = new Windows.System.LauncherOptions();
options.PreferredApplicationPackageFamilyName = "Contoso.URIApp_8wknc82po1e";
options.PreferredApplicationDisplayName = "Contoso URI Ap";

// Launch the URI and pass in the recommended app
// in case the user has no apps installed to handle the URI
var success = await Windows.System.Launcher.LaunchUriAsync(uriContoso, options);
```

### 残りの表示の基本設定

[**LaunchUriAsync**](https://msdn.microsoft.com/library/windows/apps/hh701476) を呼び出すソース アプリは、URI の起動後も画面上に留まることを要求できます。 既定では、利用可能なスペース全体がソース アプリと URI を処理するターゲット アプリとで均等に共有されます。 ソース アプリでは、[**DesiredRemainingView**](https://msdn.microsoft.com/library/windows/apps/dn298314) プロパティを使って、利用可能なスペースをソース アプリのウィンドウがどの程度占めるかをオペレーティング システムに指示できます。 
              この **DesiredRemainingView** では、URI の起動後にソース アプリが画面上に留まる必要がなく、ターゲット アプリに完全に置き換わっても良いことも示せます。 このプロパティは呼び出し元アプリの優先ウィンドウのサイズだけを指定します。 画面に同時に表示されている可能性のある他のアプリの動作は指定しません。


              **注**  ソース アプリの最終的なウィンドウ サイズは、複数の異なる要素が考慮されて決定されます。たとえば、ソース アプリの設定、画面上のアプリの数、画面の向きなどです。 [**DesiredRemainingView**](https://msdn.microsoft.com/library/windows/apps/dn298314) を設定しても、ソース アプリの特定のウィンドウ動作が保証されるわけではありません。

 

```cs
// Set the desired remaining view.
var options = new Windows.System.LauncherOptions();
options.DesiredRemainingView = Windows.UI.ViewManagement.ViewSizePreference.UseLess;

// Launch the URI
var success = await Windows.System.Launcher.LaunchUriAsync(uriContoso, options);
```

## Windows マップ アプリの URI スキーム


アプリで **bingmaps:**、**ms-drive-to:**、**ms-walk-to:** の各 URI スキームを使って、[Windows マップ アプリを起動し](launch-maps-app.md)、特定の地図、ルート案内、検索結果を表示できます。 たとえば、次の URI は、Windows マップ アプリを開き、ニューヨークを中心とした地図を表示します。

`bingmaps:?cp=40.726966~-74.006076`

![Windows マップ アプリの例。](images/mapnyc.png)

詳しくは、「[Windows マップ アプリの起動](launch-maps-app.md)」をご覧ください。 独自のアプリでマップ コントロールを使うには、「[2D、3D、Streetside ビューでの地図の表示](https://msdn.microsoft.com/library/windows/apps/mt219695)」をご覧ください。

## Windows 設定アプリの URI スキーム


アプリで **ms-settings:** URI スキームを使って、[Windows 設定アプリを起動](launch-settings-app.md)できます。 設定アプリの起動は、個人データにアクセスするアプリの開発の重要な部分です。 アプリが機密性の高いリソースにアクセスできない場合、そのリソースのプライバシー設定への便利なリンクをユーザーに提供することをお勧めします。 たとえば、次の URI は設定アプリを開き、カメラのプライバシー設定を表示します。

`ms-settings:privacy-webcam`

![カメラのプライバシー設定。](images/privacyawarenesssettingsapp.png)

詳しくは、「[Windows 設定アプリの起動](launch-settings-app.md)」と「[個人データにアクセスするアプリのガイドライン](https://msdn.microsoft.com/library/windows/apps/hh768223)」をご覧ください。

## Windows ストア アプリの URI スキーム


アプリで **ms-windows-store:** URI スキームを使って、[Windows ストア アプリを起動](launch-store-app.md)できます。 製品の詳細ページ、製品のレビュー ページ、検索ページなどを開きます。たとえば、次の URI は、Windows ストア アプリを開き、ストアのホーム ページを起動します。

`ms-windows-store://home/`

詳しくは、「[Windows ストア アプリの起動](launch-store-app.md)」をご覧ください。

## 通話アプリの URI スキーム


アプリで **ms-call:** URI スキームを使って、通話アプリを起動できます。

| URI スキーム       | 結果                               |
|------------------|---------------------------------------|
| ms-call:settings | 通話アプリの設定ページを起動します。 |

 

## チャット アプリの URI スキーム


アプリで **ms-chat:** URI スキームを使って、メッセージング アプリを起動できます。

| URI スキーム                               | 結果                                                                                                                                                                                |
|------------------------------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| ms-chat:                                 | メッセージング アプリを起動します。                                                                                                                                                            |
| ms-chat:?ContactID={contacted}           | 特定の連絡先の情報を使ってメッセージング アプリケーションを起動することを許可します。                                                                                               |
| ms-chat:?Body={body}                     | メッセージの内容として使用する文字列を使ってメッセージング アプリケーションを起動することを許可します。                                                                                    |
| ms-chat:?Addresses={address}&Body={body} | 特定のアドレスの情報とメッセージの内容として使用する文字列を使って、メッセージング アプリケーションを起動することを許可します。 注: アドレスは連結することができます。 |
| ms-chat:?TransportId={transportId}       | 特定のトランスポート ID を使ってメッセージング アプリケーションを起動することを許可します。                                                                                                        |

 

## メールの URI スキーム


アプリで **mailto:** URI スキームを使って、既定のメール アプリを起動できます。

| URI スキーム               | 結果                                                                                                                                                     |
|--------------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------|
| mailto:                  | 既定のメール アプリを起動します。                                                                                                                             |
| mailto:\[email address\] | メール アプリを起動し、宛先行で指定されているメール アドレスを使用して新しいメッセージを作成します。 メールは、ユーザーが [送信] をタップするまで送信されません。 |

 

## HTTP の URI スキーム


アプリで **http:** URI スキームを使って、既定の Web ブラウザーを起動できます。

| URI スキーム | 結果                           |
|------------|-----------------------------------|
| http:      | 既定の Web ブラウザーを起動します。 |

 

## 近隣の施設検索アプリの URI スキーム


アプリで **ms-yellowpage:** URI スキームを使って、近隣の施設検索アプリを起動できます。

| URI スキーム                                            | 結果                                                                               |
|-------------------------------------------------------|---------------------------------------------------------------------------------------|
| ms-yellowpage:?input=\[keyword\]&method=\[String|T9\] | この新しい URI をサポートしているインストール済みの関心のあるポイント (POI) 検索アプリを起動します。 |

 

## People アプリの URI スキーム


アプリで **ms-people:** URI スキームを使って、People アプリを起動できます。

詳しくは、「[People アプリの起動](launch-people-apps.md)」をご覧ください。

 

 



<!--HONumber=Jul16_HO2-->


