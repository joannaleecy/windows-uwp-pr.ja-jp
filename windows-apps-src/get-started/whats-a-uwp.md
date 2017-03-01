---
author: GrantMeStrength
ms.assetid: C9787269-B54F-4FFA-A884-D4A3BF28F80D
title: "ユニバーサル Windows プラットフォーム (UWP) アプリとは"
description: "ユニバーサル Windows アプリと呼ばれるさまざまな種類のアプリ (Windows ストア アプリ、Windows Phone ストア アプリ、Windows ランタイム アプリ) について説明します。"
ms.author: jken
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
translationtype: Human Translation
ms.sourcegitcommit: c6b64cff1bbebc8ba69bc6e03d34b69f85e798fc
ms.openlocfilehash: 0507086a7c7ea67f43f61feef6dc5c8de5afe2e5
ms.lasthandoff: 02/07/2017

---

# <a name="whats-a-universal-windows-platform-uwp-app"></a>ユニバーサル Windows プラットフォーム (UWP) アプリとは

Windows プラットフォームを初めて使う場合や、これまで .NET、Windows フォーム、Silverlight を使っていた場合は、UWP  アプリが実際にはどのようなものか気になるかもしれません**。 

しかし、焦る必要はありません。すべてはすぐにわかります。 

ユニバーサル Windows プラットフォーム (UWP) アプリは、ユニバーサル Windows プラットフォーム (UWP) 上に構築された Windows エクスペリエンスであり、Windows 8 で Windows ランタイムとして初めて導入されました。 UWP アプリの中核となるのは、ユーザーがすべてのデバイスでモバイル *エクスペリエンス*を手に入れたい、目の前の作業に一番便利で効率的なデバイスを使いたいという考え方です。

Windows 10 を使うことで、UWP 用アプリの開発がこれまでよりも簡単になります。API セット、アプリ パッケージ、ストアをそれぞれ 1 つ使うだけで、すべての Windows 10 デバイス (PC、タブレット、電話、Xbox、HoloLens、Surface Hub など) で利用可能なアプリを作成できます。 また、多数の画面サイズや、さまざまな対話方式 (タッチ、マウスとキーボード、ゲーム コントローラー、ペン) をサポートすることも簡単になります。 さらに、C# と XAML を使いたくなければ使う必要はありません。 Unity や MonoGame での開発がお好みでも、 JavaScript がお好みでも 問題はありません。お好きな言語を使用できます。

つまり、使い慣れたプログラミング言語、フレームワーク、API を選んで作業に取り組み、すべてを 1 つのプロジェクトで管理して、まったく同じコードを現在存在するさまざまな Windows ハードウェアで動作させることができるのです。 UWP アプリが完成したら、ストアに公開して世界中に届けることができます。

![Windows デバイス](images/1894834-hig-device-primer-01-500.png)

##<a name="so-what-exactly-is-a-uwp-app"></a>それでは、UWP アプリとは厳密に**どのようなものでしょうか。


UWP アプリの一番の特徴は何でしょうか。 以下に、Windows 10 の UWP アプリの特徴をいくつか挙げます。

-   OS ではなくデバイス ファミリを対象にする。

    デバイス ファミリに基づいて、デバイス ファミリのデバイス全体で想定できる API、システム特性、動作を特定します。 ストアからアプリをインストールできる一連のデバイスも決定します。

-   アプリは .AppX パッケージ形式を使ってパッケージ化されて配布される。

    すべての UWP アプリは、AppX パッケージとして配布されます。 これにより、信頼できるインストール方法をユーザーに提供でき、アプリはシームレスに展開、更新できるようになります。

-   1 つのストアですべてのデバイスに対応する。

    アプリ開発者として登録した後、アプリをストアに提出し、すべてまたは特定のデバイス ファミリ向けに販売できます。 Windows デバイス向けのすべてのアプリを 1 か所で提出、管理できます。

-   デバイス ファミリに共通の API セットが用意されている。

    ユニバーサル Windows プラットフォーム (UWP) のコア API はすべての Windows デバイス ファミリに共通です。 アプリにコア API のみを使う場合は、そのアプリはいずれの Windows 10 デバイスでも動作します。

-   拡張機能 SDK によりアプリを特殊デバイスで機能アップする。

    拡張機能 SDK により、各デバイス ファミリに特化した API が追加されます。 アプリが特定のデバイス ファミリ向けであれば、これらの API を使ってそのデバイスで機能アップできます。 この場合でも、すべてのデバイスで動作するアプリ パッケージを 1 つ用意できますが、拡張 API を呼び出す前に、アプリが実行されるデバイス ファミリを確認するようにします。

-   アダプティブ コントロールおよび入力。

    UI 要素には *有効ピクセル* (「[UWP アプリ用レスポンシブ デザイン 101](https://msdn.microsoft.com/library/windows/apps/Dn958435)」を参照) が使われるため、UI はデバイスの画面のピクセル数に基づいて自動的に調整されます。 また、キーボード、マウス、タッチ、ペン、Xbox One コントローラーなど、さまざまな種類の入力デバイスで問題なく機能します。 アプリが実行される特定のデバイスや画面サイズに合わせて UI をさらに調整する場合は、新しく追加されたレイアウト パネルとツールが便利です。

UWP について詳しくは、「[ユニバーサル Windows プラットフォーム アプリのガイド](universal-application-platform-guide.md)」をご覧ください。

## <a name="use-a-language-you-already-know"></a>使い慣れた言語の使用


UWP アプリは、C#、Visual Basic と XAML、JavaScript と HTML、C++ と DirectX/Extensible Application Markup Language (XAML) など、使い慣れたプログラミング言語で作成できます。 ある言語で作ったコンポーネントを、別の言語で作ったアプリで使うこともできます。

UWP アプリは、オペレーティング システムに組み込まれているネイティブな API である Windows ランタイムを使います。 この API は C++ で実装され、C#、Visual Basic、C++、JavaScript の各言語で自然な形でサポートされます。

Microsoft Visual Studio 2015 には、各言語の UWP アプリ用テンプレートが用意されており、いずれのデバイス向けのアプリも 1 つのプロジェクトから作成できます。 作業が終わったら、Visual Studio 内でアプリ パッケージを生成し、Windows ストアに提出できます。これで、すべての Windows 10 デバイスのユーザーがそのアプリを利用できるようになります。

## <a name="uwp-apps-come-to-life-on-windows"></a>Windows での UWP アプリの実現


Windows では、アプリが、関連するリアルタイム情報をユーザーに表示し、ユーザーが何度も戻ってくるようにすることができます。 最新のアプリの経済活動において、アプリは、ユーザーの生活の中で常に最初に思い出されるように魅力的なものにしておく必要があります。 Windows では、ユーザーが繰り返しアプリを使うように、次のような多くのリソースを提供しています。

-   ライブ タイルとロック画面は、コンテキストに関連したタイムリーな情報をひとめでわかるように表示します。
-   プッシュ通知は、ユーザーが必要なときにリアルタイムの最新の通知に注目できるようにします。

-   アクション センターでは、ユーザーの操作を必要とする通知やコンテンツを整理して表示できます。

-   バックグラウンドの実行とトリガーにより、ユーザーが必要とするときだけアプリが有効になります。

-   アプリで音声と Bluetooth LE デバイスを使うと、ユーザーはそれらのデバイスを中心に広がる世界とインタラクトできるようになります。

最終的に、ローミング データと Windows 資格情報保管ボックスを使うと、ユーザーがアプリを実行するすべての Windows 画面で一貫したローミング エクスペリエンスを実現できます。 ローミング データを使うと、独自の同期インフラストラクチャを構築する必要なく、ユーザーの基本設定とその他の設定をクラウドに簡単に保存できます。 資格情報保管ボックスには、ユーザーの資格情報を保存できます。このボックスにおける最優先事項はセキュリティと信頼性です。

##  <a name="monetize-your-app-your-way"></a>好きな方法でアプリから収益を得る


Windows では、好きな方法で (電話、タブレット、PC、その他のデバイス) アプリから収益を得る方法を選ぶことができます。 ここでは、アプリとアプリが提供するサービスで収益を得るさまざまな方法について説明します。 必要なのは、ニーズに合った最適な方法を選ぶことだけです。

-   有料のダウンロードは最も簡単な方法です。 必要な作業は価格の指定だけです。
-   試用版はユーザーに購入前にアプリを試してもらうための効果的な方法であり、従来の試用オプションよりも目につきやすく、コンバージョンも簡単です。
-   アプリで収益を得るということに関して最も柔軟性が高いのは、アプリ内購入です。

## <a name="lets-get-started"></a>作業の開始


UWP について詳しくは、[ユニバーサル Windows プラットフォーム アプリのガイド](universal-application-platform-guide.md)をご覧ください。 その後、「[準備](get-set-up.md)」を確認のうえ、アプリの作成を始めるために必要なツールをダウンロードしてください。

## <a name="related-topics"></a>関連トピック


* [ユニバーサル Windows プラットフォーム アプリのガイド](universal-application-platform-guide.md)
* [準備](get-set-up.md)

## <a name="more-advanced-topics"></a>高度なトピック

* [.NET Native - ユニバーサル Windows プラットフォーム (UWP) 開発者にとっての意味](https://blogs.windows.com/buildingapps/2015/08/20/net-native-what-it-means-for-universal-windows-platform-uwp-developers/#TYsD3tJuBJpK3Hc7.97)
* [.NET でのユニバーサル Windows アプリ](https://blogs.msdn.microsoft.com/dotnet/2015/07/30/universal-windows-apps-in-net)
* [UWP アプリの .NET](https://msdn.microsoft.com/en-us/library/mt185501.aspx)

