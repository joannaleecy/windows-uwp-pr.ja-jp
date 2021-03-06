---
Description: ユニバーサル Windows プラットフォーム (UWP) Api を使用して、Windows 10 ユーザー向けのデスクトップ アプリケーションを強化します。
Search.Product: eADQiWindows 10XVcnh
title: Windows 10 向けのデスクトップ アプリを強化する
ms.date: 04/19/2019
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.custom: 19H1
ms.openlocfilehash: 55e91c96b7a978f0c90365073aa655553d4a658a
ms.sourcegitcommit: fca0132794ec187e90b2ebdad862f22d9f6c0db8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/24/2019
ms.locfileid: "63805681"
---
# <a name="enhance-your-desktop-application-for-windows-10"></a>Windows 10 向けのデスクトップ アプリを強化する

Windows ランタイム Api を使用して、Windows 10 ユーザー向けに磨きをかける最新のエクスペリエンスを追加することができます。

最初に、プロジェクトをセットアップします。 次に、Windows 10 エクスペリエンスを追加します。 Windows 10 ユーザー向けに個別にビルドすることも、実行する Windows のバージョンに関係なくすべてのユーザー向けにまったく同じバイナリを配布することもできます。

## <a name="first-set-up-your-project"></a>最初に、プロジェクトをセットアップする

UWP API を使用するには、プロジェクトにいくつかの変更を加える必要があります。

### <a name="modify-a-net-project-to-use-windows-runtime-apis"></a>Windows ランタイム Api を使用する .NET プロジェクトを変更します。

**[参照マネージャー]** ダイアログ ボックスを開き、**[参照]** ボタンを選択して、**[すべてのファイル]** を選択します。

![[参照の追加] ダイアログ ボックス](images/desktop-to-uwp/browse-references.png)

次に、これらのファイルへの参照を追加します。

|ファイル|Location|
|--|--|
|System.Runtime.WindowsRuntime|C:\Windows\Microsoft.NET\Framework\v4.0.30319|
|System.Runtime.WindowsRuntime.UI.Xaml|C:\Windows\Microsoft.NET\Framework\v4.0.30319|
|System.Runtime.InteropServices.WindowsRuntime|C:\Windows\Microsoft.NET\Framework\v4.0.30319|
|windows.winmd|C:\Program Files (x86)\Windows Kits\10\UnionMetadata\\<*sdk version*>\Facade|
|Windows.Foundation.UniversalApiContract.winmd|C:\Program Files (x86)\Windows Kits\10\References\\<*sdk version*>\Windows.Foundation.UniversalApiContract\<*version*>|
|Windows.Foundation.FoundationContract.winmd|C:\Program Files (x86)\Windows Kits\10\References\\<*sdk version*>\Windows.Foundation.FoundationContract\<*version*>|

**[プロパティ]** ウィンドウで、各 *.winmd* ファイルの **[ローカルにコピー]** フィールドを **[False]** に設定します。

![[ローカルにコピー] フィールド](images/desktop-to-uwp/copy-local-field.png)

### <a name="modify-a-c-project-to-use-windows-runtime-apis"></a>Windows ランタイム Api を使用する C++ プロジェクトを変更します。

使用[C +/cli WinRT](https://docs.microsoft.com/windows/uwp/cpp-and-winrt-apis/) Windows ランタイム Api を使用します。 C++/WinRT は Windows ランタイム (WinRT) API の標準的な最新の C++17 言語プロジェクションで、ヘッダー ファイル ベースのライブラリとして実装され、最新の Windows API への最上位アクセス権を提供するように設計されています。

C++ プロジェクトを構成する/cli WinRT を参照してください[C + を追加する Windows デスクトップ アプリケーション プロジェクトを変更する/cli WinRT サポート](https://docs.microsoft.com/windows/uwp/cpp-and-winrt-apis/get-started#modify-a-windows-desktop-application-project-to-add-cwinrt-support)します。

## <a name="add-windows-10-experiences"></a>Windows 10 エクスペリエンスの追加

これで、Windows 10 でアプリケーションをユーザーが実行する際に便利になる最新のエクスペリエンスを追加する準備ができました。 次の設計フローを使用します。

:white_check_mark:**最初に、追加するどのようなエクスペリエンスを決定します。**

選択肢はたくさんあります。 たとえば、収益化 Api、またはアプリケーションに直接の注意を別のユーザーが投稿する新しい画像などを共有するには興味深いものがある場合を使用して、購買注文の流れを簡略化できます。

![トースト](images/desktop-to-uwp/toast.png)

ユーザーがメッセージを無視したり、非表示にした場合でも、ユーザーはアクション センターで再度メッセージを表示し、クリックすることで、アプリを開くことができます。 これにより、アプリケーションで engagement を向上し、アプリケーションをオペレーティング システムに深く統合表示の追加されたボーナスが。 このエクスペリエンスのコードについては、少し後で紹介します。

さまざまなアイデアを[デベロッパー センター](https://developer.microsoft.com/windows)で参照してください。

:white_check_mark:**強化または拡張するかどうかを決定します。**

マイクロソフトでは「強化」と「拡張」という用語をよく使用しています。ここで、少し時間を使って、それぞれの用語が厳密にどのような意味なのかを説明しましょう。

使用して、用語「拡張」デスクトップ アプリケーションから直接呼び出すことができる Windows ランタイム Api について説明します。 Windows 10 エクスペリエンスを選択した場合、エクスペリエンスの作成に必要な API を特定して、その API がこの[一覧](desktop-to-uwp-supported-api.md)にあるかどうかを確認します。 これは、デスクトップ アプリケーションから直接呼び出せる API の一覧です。 API がこの一覧に表示されていない場合、その API に関連付けられている機能が UWP プロセス内でしか実行できないことが理由です。 多くの場合、そのような API は、UWP マップ コントロールや Windows Hello のセキュリティの確認など、最新の UI を表示する機能があります。

しかし、このようなエクスペリエンスをアプリケーションに含める場合は、ソリューションに UWP プロジェクトを追加して、アプリケーションを「拡張」するようにします。 デスクトップ プロジェクトがアプリケーションのエントリ ポイントであることに変わりはありませんが、UWP プロジェクトを追加することで、この[一覧](desktop-to-uwp-supported-api.md)にないすべての API を利用できます。 デスクトップ アプリケーションは、アプリ サービスを利用して UWP プロセスと通信できます。そのセットアップ方法については、多数のガイダンスが用意されています。 UWP プロジェクトが必要なエクスペリエンスを追加するには、「[UWP による拡張](desktop-to-uwp-extend.md)」を参照してください。

:white_check_mark:**参照 API コントラクト**

デスクトップ アプリケーションから API を直接呼び出せる場合は、ブラウザーを開き、その API のリファレンス トピックを検索します。
API の概要の下に、その API の API コントラクトを説明する表があります。 以下に表の例を示します。

![API コントラクト表](images/desktop-to-uwp/contract-table.png)

.NET ベースのデスクトップ アプリの場合、その API コントラクトへの参照を追加します。その後、そのファイルの **[ローカルにコピー]** プロパティを **[False]** に設定します。 C++ ベースのプロジェクトの場合、**[追加のインクルード ディレクトリ]** に、このコントラクトを含むフォルダーのパスを追加します。

:white_check_mark:**お客様のエクスペリエンスを追加する Api を呼び出す**

以下に、前述の通知ウィンドウの表示に使用するコードを示します。 これらの API はこの[一覧](desktop-to-uwp-supported-api.md)にあるため、このコードをデスクトップ アプリケーションに追加してすぐに実行できます。

```csharp
using Windows.Foundation;
using Windows.System;
using Windows.UI.Notifications;
using Windows.Data.Xml.Dom;
...

private void ShowToast()
{
    string title = "featured picture of the day";
    string content = "beautiful scenery";
    string image = "https://picsum.photos/360/180?image=104";
    string logo = "https://picsum.photos/64?image=883";

    string xmlString =
    $@"<toast><visual>
       <binding template='ToastGeneric'>
       <text>{title}</text>
       <text>{content}</text>
       <image src='{image}'/>
       <image src='{logo}' placement='appLogoOverride' hint-crop='circle'/>
       </binding>
      </visual></toast>";

    XmlDocument toastXml = new XmlDocument();
    toastXml.LoadXml(xmlString);

    ToastNotification toast = new ToastNotification(toastXml);

    ToastNotificationManager.CreateToastNotifier().Show(toast);
}
```

```C++
using namespace Windows::Foundation;
using namespace Windows::System;
using namespace Windows::UI::Notifications;
using namespace Windows::Data::Xml::Dom;

void UWP::ShowToast()
{
    Platform::String ^title = "featured picture of the day";
    Platform::String ^content = "beautiful scenery";
    Platform::String ^image = "https://picsum.photos/360/180?image=104";
    Platform::String ^logo = "https://picsum.photos/64?image=883";

    Platform::String ^xmlString =
        L"<toast><visual><binding template='ToastGeneric'>" +
        L"<text>" + title + "</text>" +
        L"<text>"+ content + "</text>" +
        L"<image src='" + image + "'/>" +
        L"<image src='" + logo + "'" +
        L" placement='appLogoOverride' hint-crop='circle'/>" +
        L"</binding></visual></toast>";

    XmlDocument ^toastXml = ref new XmlDocument();

    toastXml->LoadXml(xmlString);

    ToastNotificationManager::CreateToastNotifier()->Show(ref new ToastNotification(toastXml));
}
```
通知の詳細については、「[アダプティブ トースト通知と対話型トースト通知](https://docs.microsoft.com/windows/uwp/design/shell/tiles-and-notifications/adaptive-interactive-toasts)」を参照してください。

## <a name="support-windows-xp-windows-vista-and-windows-78-install-bases"></a>Windows XP、Windows Vista、および Windows 7/8 インストール ベースのサポート

新しいブランチを作成し、別のコード ベースを管理することがなく、Windows 10 用のアプリケーションを最新化することができます。

Windows 10 ユーザー向けに個別のバイナリをビルドする場合は、条件付きコンパイルを使用します。 すべての Windows ユーザーに対して 1 組のバイナリをビルドして展開する場合は、ランタイム チェックを使用します。

各オプションを簡単に見ていきましょう。

### <a name="conditional-compilation"></a>条件付きコンパイル

1 つのコードベースを維持して、Windows 10 ユーザー向けだけに一連のバイナリをコンパイルします。

最初に、新しいビルド構成をプロジェクトに追加します。

![ビルド構成](images/desktop-to-uwp/build-config.png)

そのビルド構成の定数を作成する Windows ランタイム Api を呼び出すコードを識別するためにします。  

.NET ベースのプロジェクトの場合、この定数は**条件付きコンパイル定数**と呼ばれます。

![プリプロセッサ](images/desktop-to-uwp/compilation-constants.png)

C++ ベースのプロジェクトの場合、この定数は**プリプロセッサ定義**と呼ばれます。

![プリプロセッサ](images/desktop-to-uwp/pre-processor.png)

この定数を、任意の UWP コードのブロックの前に追加します。

```csharp

[System.Diagnostics.Conditional("_UWP")]
private void ShowToast()
{
 ...
}

```

```C++

#if _UWP
void UWP::ShowToast()
{
 ...
}
#endif

```

この定数がアクティブなビルド構成で定義されている場合のみ、コンパイラでこのコードがビルドされます。

### <a name="runtime-checks"></a>ランタイム チェック

ユーザーが実行する Windows のバージョンに関係なく、1 組のバイナリをすべての Windows ユーザー向けにコンパイルできます。 アプリケーションは Windows ランタイム Api、ユーザーが実行する場合にのみアプリケーションをパッケージ化されたアプリケーションとして Windows 10

ランタイム チェックをコードに追加する最も簡単な方法では、この Nuget パッケージをインストールします。[デスクトップ ブリッジ ヘルパー](https://www.nuget.org/packages/DesktopBridge.Helpers/)しを使用して、``IsRunningAsUWP()``メソッド ゲートを Windows ランタイム Api を呼び出すコードをすべてオフにします。 このブログの詳細については投稿を参照してください。[デスクトップ ブリッジ - アプリケーションのコンテキストを識別する](https://blogs.msdn.microsoft.com/appconsult/2016/11/03/desktop-bridge-identify-the-applications-context/)します。

## <a name="related-video"></a>関連ビデオ

<iframe src="https://mva.microsoft.com/en-US/training-courses-embed/developers-guide-to-the-desktop-bridge-17373/Demo-Use-UWP-APIs-in-Your-Code-3d78c6WhD_9506218965" width="636" height="480" allowFullScreen frameBorder="0"></iframe>

## <a name="related-samples"></a>関連するサンプル

* [Hello World サンプル](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/HelloWorldSample)
* [セカンダリ タイル](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/SecondaryTileSample)
* [ストア API サンプル](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/StoreSample)
* [WinForms アプリケーション UWP UpdateTask を実装します。](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/WinFormsUpdateTaskSample)
* [UWP サンプルへのブリッジのデスクトップ アプリ](https://github.com/Microsoft/DesktopBridgeToUWP-Samples)


## <a name="support-and-feedback"></a>サポートとフィードバック

**質問の回答を検索**

ご質問がある場合は、 Stack Overflow でお問い合わせください。 Microsoft のチームでは、これらの[タグ](https://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge)をチェックしています。 [こちら](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D)から質問することもできます。

**ご意見や機能を提案します。**

[UserVoice](https://wpdev.uservoice.com/forums/110705-universal-windows-platform/category/161895-desktop-bridge-centennial) のページをご覧ください。
