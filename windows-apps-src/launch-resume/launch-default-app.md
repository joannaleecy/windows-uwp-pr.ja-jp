---
title: URI に応じた既定のアプリの起動
description: URI (Uniform Resource Identifier) に応じて既定のアプリを起動する方法について説明します。 URI を使うと、別のアプリを起動して特定の作業を実行できます。 また、Windows に組み込まれている多くの URI スキームの概要についても説明します。
ms.assetid: 7B0D0AF5-D89E-4DB0-9B79-90201D79974F
ms.date: 06/26/2017
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 6c5c8b99ec3646d1eebbb922557f97c9e9304ed4
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57658367"
---
# <a name="launch-the-default-app-for-a-uri"></a>URI に応じた既定のアプリの起動


**重要な API**

- [**LaunchUriAsync**](https://msdn.microsoft.com/library/windows/apps/hh701476)
- [**PreferredApplicationPackageFamilyName**](https://msdn.microsoft.com/library/windows/apps/hh965482)
- [**DesiredRemainingView**](https://msdn.microsoft.com/library/windows/apps/dn298314)

URI (Uniform Resource Identifier) に応じて既定のアプリを起動する方法について説明します。 URI を使うと、別のアプリを起動して特定の作業を実行できます。 また、Windows に組み込まれている多くの URI スキームの概要についても説明します。 カスタム URI も起動することができます。 カスタム URI スキームを登録する方法と URI のアクティブ化を処理する方法について詳しくは、「[URI のアクティブ化の処理](handle-uri-activation.md)」をご覧ください。

URI スキームでは、ハイパーリンクをクリックしてアプリを開くことができます。 **mailto:** を使って新しいメールの作成を開始できるのと同様に、**http:** を使って既定の Web ブラウザーを開くことができます。

このトピックでは、Windows に組み込まれている以下の URI スキームについて説明します。

| URI スキーム | 起動対象 |
| ----------:|----------|
|[bingmaps: ms でドライブを: および ms のウォーク-に。 ](#maps-app-uri-schemes) | マップ アプリ |
|[http:](#http-uri-scheme) | 既定の Web ブラウザー |
|[mailto:](#email-uri-scheme) | 既定のメール アプリ |
|[ms-call:](#call-app-uri-scheme) |  通話アプリ |
|[ms-chat:](#messaging-app-uri-scheme) | メッセージング アプリ |
|[ms ユーザー:](#people-app-uri-scheme) | People アプリ |
|[ms 写真:](#photos-app-uri-scheme) | フォト アプリ |
|[ms 設定:](#settings-app-uri-scheme) | 設定アプリ |
|[ms ストア。](#store-app-uri-scheme)  | ストア アプリ |
|[ms tonepicker:](#tone-picker-uri-scheme) | トーンの選択コントロール |
|[ms yellowpage:](#nearby-numbers-app-uri-scheme) | 近隣の施設検索アプリ |
|[msnweather:](#weather-app-uri-scheme) | 天気アプリ |

<br>
たとえば、次の URI は既定のブラウザーを開き、Bing の Web サイトを表示します。

`https://bing.com`

カスタム URI スキームを起動することもできます。 その URI を処理するアプリがインストールされていない場合は、ユーザーにインストールするアプリを推奨することができます。 詳しくは、「[URI を処理するアプリがない場合にアプリを推奨](#recommend-an-app-if-one-is-not-available-to-handle-the-uri)」をご覧ください。

一般的に、起動するアプリをアプリが選ぶことはできません。 どのアプリを起動するかはユーザーが決めます。 同じ URI スキームを処理するために、複数のアプリを登録できます。 この例外として、予約済みの URI スキームがあります。 予約済みの URI スキームの登録は無視されます。 予約済みの URI スキームの一覧については、「[URI のアクティブ化の処理](handle-uri-activation.md)」をご覧ください。 複数のアプリが同じ URI スキームを登録している可能性がある場合は、アプリで特定のアプリを起動することを推奨できます。 詳しくは、「[URI を処理するアプリがない場合にアプリを推奨](#recommend-an-app-if-one-is-not-available-to-handle-the-uri)」をご覧ください。

### <a name="call-launchuriasync-to-launch-a-uri"></a>LaunchUriAsync を呼び出して URI を起動

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

### <a name="recommend-an-app-if-one-is-not-available-to-handle-the-uri"></a>URI を処理するアプリがない場合にアプリを推奨

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

### <a name="set-remaining-view-preference"></a>残りの表示の基本設定

[  **LaunchUriAsync**](https://msdn.microsoft.com/library/windows/apps/hh701476) を呼び出すソース アプリは、URI の起動後も画面上に留まることを要求できます。 既定では、利用可能なスペース全体がソース アプリと URI を処理するターゲット アプリとで均等に共有されます。 ソース アプリでは、[**DesiredRemainingView**](https://msdn.microsoft.com/library/windows/apps/dn298314) プロパティを使って、利用可能なスペースをソース アプリのウィンドウがどの程度占めるかをオペレーティング システムに指示できます。 この **DesiredRemainingView** では、URI の起動後にソース アプリが画面上に留まる必要がなく、ターゲット アプリに完全に置き換わっても良いことも示せます。 このプロパティは呼び出し元アプリの優先ウィンドウのサイズだけを指定します。 画面に同時に表示されている可能性のある他のアプリの動作は指定しません。

**注**  は考慮は Windows で複数のさまざまな要素、たとえば、ソース アプリの最終的なウィンドウのサイズを決定する場合、ソース アプリの基本設定、画面、画面の向き、上のアプリの数。 [  **DesiredRemainingView**](https://msdn.microsoft.com/library/windows/apps/dn298314) を設定しても、ソース アプリの特定のウィンドウ動作が保証されるわけではありません。

```cs
// Set the desired remaining view.
var options = new Windows.System.LauncherOptions();
options.DesiredRemainingView = Windows.UI.ViewManagement.ViewSizePreference.UseLess;

// Launch the URI
var success = await Windows.System.Launcher.LaunchUriAsync(uriContoso, options);
```

## <a name="uri-schemes"></a>URI スキーム ##

各種 URI スキームについて以下に説明します。

### <a name="call-app-uri-scheme"></a>通話アプリの URI スキーム

使用して、 **ms 呼び出し。** 呼び出しのアプリを起動する URI スキームです。

| URI スキーム       | 結果                   |
|------------------|--------------------------|
| ms-call:settings | アプリ設定のページを呼び出します。 |

### <a name="email-uri-scheme"></a>メールの URI スキーム

使用して、 **mailto:** 既定のメール アプリを起動する URI スキームです。

| URI スキーム |結果                          |
|------------|---------------------------------|
| mailto:    | 既定のメール アプリを起動します。 |
| mailto:\[電子メール アドレス\] | メール アプリを起動し、宛先行で指定されているメール アドレスを使用して新しいメッセージを作成します。 メールは、ユーザーが [送信] をタップするまで送信されません。 |

### <a name="http-uri-scheme"></a>HTTP の URI スキーム

使用して、 **http:** 既定の web ブラウザーを起動する URI スキームです。

| URI スキーム | 結果                           |
|------------|-----------------------------------|
| http:      | 既定の Web ブラウザーを起動します。 |

### <a name="maps-app-uri-schemes"></a>マップ アプリの URI スキーム

使用して、 **bingmaps:**、 **ms でドライブを:**、および**ms-チュートリアル-に。** URI のスキームを[Windows マップ アプリを起動](launch-maps-app.md)特定のマップ、方向、および検索結果にします。 たとえば、次の URI は、Windows マップ アプリを開き、ニューヨークを中心とした地図を表示します。

`bingmaps:?cp=40.726966~-74.006076`

![Windows マップ アプリの例。](images/mapnyc.png)

詳しくは、「[Windows マップ アプリの起動](launch-maps-app.md)」をご覧ください。 独自のアプリでマップ コントロールを使うには、「[2D、3D、Streetside ビューでの地図の表示](https://msdn.microsoft.com/library/windows/apps/mt219695)」をご覧ください。

### <a name="messaging-app-uri-scheme"></a>メッセージング アプリの URI スキーム

使用して、 **ms チャット。** Windows メッセージング アプリを起動する URI スキームです。

| URI スキーム |結果 |
|------------|--------|
| ms-chat:   | メッセージング アプリを起動します。 |
| ms-chat:?ContactID={contacted}  |  特定の連絡先の情報を使ってメッセージング アプリケーションを起動することを許可します。   |
| ms-chat:?Body={body} | メッセージの内容として使用する文字列を使ってメッセージング アプリケーションを起動することを許可します。|
| ms-chat:?Addresses={address}&Body={body} | 特定のアドレスの情報とメッセージの内容として使用する文字列を使って、メッセージング アプリケーションを起動することを許可します。 注:アドレスは連結できます。 |
| ms-chat:?TransportId={transportId}  | 特定のトランスポート ID を使ってメッセージング アプリケーションを起動することを許可します。 |

### <a name="tone-picker-uri-scheme"></a>トーンの選択コントロールの URI スキーム

使用して、 **ms tonepicker:** 着信音、警報、およびシステムのトーンを選択する URI スキームです。 また、新しいトーンを保存したり、トーンの名前を表示したりできます。

| URI スキーム | 結果 |
|------------|---------|
| ms-tonepicker: | トーン、アラーム、システム音を選択します。 |

パラメーターは [ValueSet](https://msdn.microsoft.com/library/windows/apps/windows.foundation.collections.valueset.aspx) を介して LaunchURI API に渡されます。 詳しくは、「[ms-tonepicker URI スキームを使ったトーンの選択と保存](launch-ringtone-picker.md)」をご覧ください。

### <a name="nearby-numbers-app-uri-scheme"></a>近隣の施設検索アプリの URI スキーム

使用して、 **ms yellowpage:** 近くにある数字のアプリを起動する URI スキームです。

| URI スキーム | 結果 |
|------------|---------|
| ms yellowpage: でしょうか入力 =\[キーワード\]& メソッド =\[文字列または T9。\] | 近隣の施設検索アプリを起動します。<br>`input` 検索するキーワードを指します。<br>`method` 検索 (文字列または T9 検索) の種類を参照します。<br>`method` が `T9` (キーボードの種類) である場合、`keyword` は T9 キーボードの文字にマップされた数字の検索文字列になります。<br>`method` が `String` の場合は、`keyword` は検索するキーワードになります。 |

### <a name="people-app-uri-scheme"></a>People アプリの URI スキーム

使用して、 **ms ユーザー。** ユーザーのアプリを起動する URI スキーム。
詳しくは、「[People アプリの起動](launch-people-apps.md)」をご覧ください。

### <a name="photos-app-uri-scheme"></a>フォト アプリの URI スキーム

使用して、 **ms 写真。** 写真アプリ イメージを表示したり、動画の編集を起動する URI スキーム。 次に、例を示します。  
イメージを表示するには。 `ms-photos:viewer?fileName=c:\users\userName\Pictures\image.jpg`  
または、ビデオを編集するのには。 `ms-photos:videoedit?InputToken=123abc&Action=Trim&StartTime=01:02:03`  

> [!NOTE]
> ビデオを編集したり画像を表示するための URI は、デスクトップでのみ利用できます。

| URI スキーム |結果 |
|------------|--------|
| ms-photos:viewer?fileName={filename} | フォト アプリを起動して指定したイメージを表示します。ここで、{filename} は完全修飾パス名です。 たとえば次のようになります。`c:\users\userName\Pictures\ImageToView.jpg` |
| ms-photos:videoedit?InputToken={input token} | ファイルのトークンで表されるファイルのビデオ編集モードでフォト アプリを起動します。 **InputToken** は必須です。 [SharedStorageAccessManager](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.DataTransfer.SharedStorageAccessManager) を使用してファイルのトークンを取得します。 |
| ms-photos:videoedit?Action={action} | 写真アプリは場所のいずれかが {action} 指定のビデオ編集モードで開かれている省略可能なパラメーター:**SlowMotion**、 **FrameExtraction**、**トリミング**、**ビュー**、**インク**します。 何も指定しない場合の既定値は**表示**です。 |
| ms-photos:videoedit?StartTime={timespan} | ビデオの再生を開始する場所を指定するオプションのパラメーターです。 `{timespan}` 形式である必要があります`"hh:mm:ss.ffff"`します。 既定値を指定しない場合 `00:00:00.0000` |

### <a name="settings-app-uri-scheme"></a>設定アプリの URI スキーム

使用して、 **ms 設定。** URI スキームを[Windows 設定アプリを起動](launch-settings-app.md)します。 設定アプリの起動は、個人データにアクセスするアプリの開発の重要な部分です。 アプリが機密性の高いリソースにアクセスできない場合、そのリソースのプライバシー設定への便利なリンクをユーザーに提供することをお勧めします。 たとえば、次の URI は設定アプリを開き、カメラのプライバシー設定を表示します。

`ms-settings:privacy-webcam`

![カメラのプライバシー設定。](images/privacyawarenesssettingsapp.png)

詳しくは、「[Windows 設定アプリの起動](launch-settings-app.md)」と「[個人データにアクセスするアプリのガイドライン](https://msdn.microsoft.com/library/windows/apps/hh768223)」をご覧ください。

### <a name="store-app-uri-scheme"></a>ストア アプリの URI スキーム

使用して、 **ms-windows ストア。** URI スキームを[UWP アプリを起動](launch-store-app.md)します。 製品詳細ページ、レビューの製品ページ、検索ページを開きます。たとえば、次の URI は、UWP アプリを開いたし、ストアのホーム ページを起動します。

`ms-windows-store://home/`

詳しくは、「[UWP アプリの起動](launch-store-app.md)」をご覧ください。

### <a name="weather-app-uri-scheme"></a>天気アプリ URI スキーム

使用して、 **msnweather:** 天気アプリを起動する URI スキームです。

| URI スキーム | 結果 |
|------------|---------|
| msnweather://forecast?la=\[latitude\]&lo=\[longitude\] | 場所の地理的座標に基づいて、予測ページでのお天気アプリを起動します。<br>`latitude` 場所の緯度を指します。<br> `longitude` その場所の経度を表します。<br> |
