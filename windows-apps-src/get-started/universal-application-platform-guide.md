---
title: ユニバーサル Windows プラットフォーム (UWP) アプリとは
description: Windows 10 を搭載するさまざまなデバイスで実行できるユニバーサル Windows プラットフォーム (UWP) アプリについて説明します。
ms.assetid: 59849197-B5C7-493C-8581-ADD6F5F8800B
ms.date: 05/07/2018
ms.topic: article
keywords: Windows 10, UWP, ユニバーサル
ms.localizationpriority: medium
ms.openlocfilehash: 1a43cdd5c16e4ab7ec254c263df75c182ce3faba
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57618177"
---
# <a name="whats-a-universal-windows-platform-uwp-app"></a>ユニバーサル Windows プラットフォーム (UWP) アプリとは

![ユニバーサル Windows プラットフォーム アプリのさまざまなデバイスで実行、適応ユーザー インターフェイス、自然なユーザー入力、1 つのストア、パートナー センターのサポート、およびクラウド サービス](images/universalapps-overview.png)

UWP アプリには次のような特長があります。

- セキュリティで保護します。UWP アプリでは、どのデバイスのリソースとデータにアクセスを宣言します。 ユーザーは、そのアクセスを承認する必要があります。
- Windows 10 を実行しているすべてのデバイスで共通の API を使用できます。
- デバイス固有の機能を使用して、異なるデバイスの画面サイズ、解像度、DPI に合わせて UI を調整することができます。
- Windows 10 を実行するすべてのデバイス (または指定したデバイスのみ) で Microsoft Store から入手できます。 Microsoft Store では、アプリで収益を上げるいくつかの方法を提供します。
- コンピューターへのリスクや "コンピューターの劣化" を気にせずにインストールおよびアンインストールできます。
- 魅力的。ライブ タイル、プッシュ通知、Windows タイムラインや Cortana の前回終了した位置から再開を利用したユーザー アクティビティによって、ユーザーのエンゲージメントを高めます。
- C#、C++、Visual Basic、Javascript でプログラミング可能です。 UI 用に、XAML、HTML、または DirectX を使用します。

これらをさらに詳しく見てみましょう。

## <a name="secure"></a>セキュリテイ保護

UWP アプリでは、マイク、位置情報、Web カメラ、USB デバイス、ファイルなどへのアクセスに必要なデバイスの機能をマニフェストで宣言します。 アプリに機能が付与される前に、ユーザーがそのアクセスを確認して承認する必要があります。

## <a name="a-common-api-surface-across-all-devices"></a>すべてのデバイスに共通の API セット

Windows 10 では、ユニバーサル Windows プラットフォーム (UWP)、Windows 10 を実行するすべてのデバイスで共通のアプリ プラットフォームを提供するについて説明します。 UWP のコア API は、すべての Windows デバイスで同じです。 アプリは、コア Api のみを使用する場合、デスクトップ PC、Xbox、Mixed reality ヘッドセットを対象にするかに関係なくあらゆる Windows 10 デバイスで実行されなど。

C++/WinRT または C++/CX で記述された UWP アプリは UWP の一部である Win32 API にアクセスします。 これらの Win32 Api は、すべての Windows 10 デバイスで実装されます。

## <a name="extension-sdks-expose-the-unique-capabilities-of-specific-device-types"></a>拡張 SDK が特定のデバイスの種類に固有の機能を公開する

ユニバーサル API を対象としている場合、アプリは Windows 10 が動作しているすべてのデバイスで実行できます。 ただし、UWP アプリでデバイス固有の API を利用したい場合は、利用できます。

拡張 SDK では、さまざまなデバイスに特化した API を呼び出すことができます。 たとえば、UWP アプリで IoT デバイスをターゲットにしている場合、IoT デバイスに固有の機能をターゲットにしたプロジェクトに IoT 拡張 SDK を追加できます。 拡張 SDK の追加に関する詳細については、[デバイス ファミリの概要に関するページ](https://docs.microsoft.com/uwp/extension-sdks/device-families-overview#extension-sdks)の**拡張 SDK**のセクションを参照してください。

特定の種類のデバイスでのみ実行されることを想定し、Microsoft Store からの配布をその種類のデバイスのみに制限するようにアプリを記述することができます。 または、実行時に API の存在を条件付きでテストし、結果に応じてアプリの動作を調整できます。 詳細については、[デバイス ファミリの概要に関するページ](https://docs.microsoft.com/uwp/extension-sdks/device-families-overview#writing-code)の**コードの記述**のセクションを参照してください。<br>

次のビデオでは、デバイス ファミリとアダプティブ コードの作成に関する簡単な概要を示します。
<iframe src="https://channel9.msdn.com/Blogs/One-Dev-Minute/Introduction-to-UWP-and-Device-Families/player" width="640" height="360" allowFullScreen frameBorder="0"></iframe>

## <a name="adaptive-controls-and-input"></a>アダプティブ コントロールおよび入力

UI 要素は、そのレイアウトやスケールを調整することで、アプリが実行されている画面のサイズや DPI に対応します。 UWP アプリは、キーボード、マウス、タッチ、ペン、Xbox One コントローラーなど、さまざまな種類の入力デバイスで問題なく機能します。 特定の画面サイズやデバイスに合わせて UI をさらに調整する必要がある場合は、新しく追加されたレイアウト パネルとツールを使用して、アプリが実行されるさまざまなデバイスやフォーム ファクターに合わせて調整可能な UI を設計できます。

![Windows デバイス](images/1894834-hig-device-primer-01-500.png)

Windows では、UI を次の機能を備えた複数のデバイスを対象としたものにすることができます。

- UI をデバイスの画面の解像度に合わせて最適化するために役立つユニバーサル コントロールとレイアウト パネル。 たとえば、ボタンやスライダーなどのコントロールは、デバイスの画面サイズや DPI 密度に合わせて自動的に調整されます。 レイアウト パネルは、画面のサイズに基づいてコンテンツのレイアウトを調整するのに役立ちます。 デバイス間での解像度と DPI の相違を調整するアダプティブ スケーリング。
- 一般的な入力処理では、タッチ、ペン、マウス、キーボード、またはコントローラー (Microsoft Xbox コントローラーなど) による入力を受け取ることができます。
- さまざまな画面の解像度に合わせて変化する UI の設計に役立つツール。

アプリの UI の一部はデバイス間で自動的に対応します。 ただし、アプリのユーザー エクスペリエンスの設計は、アプリが実行されているデバイスへの対応が必要になる場合があります。 たとえば、フォト アプリが小型のハンドヘルド デバイスで実行されている場合、UI を片手での使用に適するように調整できます。 フォト アプリがデスクトップ コンピューターで実行されている場合、UI は広い画面スペースを利用するように調整する必要があります。

## <a name="theres-one-store-for-all-devices"></a>1 つのストアですべてのデバイスに対応する

統合アプリ ストアでは、PC、タブレット、Xbox、HoloLens、Surface Hub、モ ノのインターネット (IoT) デバイスなどの Windows 10 デバイスで使用可能なアプリをします。 開発者は、アプリをストアに提出し、すべての種類のデバイスまたは選択した種類のデバイス向けに販売できます。 Windows デバイス向けのすべてのアプリを 1 か所で提出、管理できます。 UWP の機能を使って最新化し、Microsoft Store での販売を希望する C++ デスクトップ アプリがある場合も 問題ありません。

UWP アプリは、詳細なテレメトリや分析のために [Application Insights](https://azure.microsoft.com/services/application-insights/) に統合されています。これは、ユーザーを理解し、アプリの品質を向上させるために欠かせないツールです。

### <a name="monetize-your-app"></a>アプリの収益の獲得

アプリを収益化する方法を選択できます。 アプリで収益を得る方法は多数あります。 必要なのは、ニーズに合った最適な方法を選ぶことだけです。たとえば、次のような方法があります。

- 有料のダウンロードは最も簡単な方法です。 必要な作業は価格の指定だけです。
- 試用版を使うとユーザーは購入前にアプリを試すことができ、従来の "フリーミアム" オプションよりも目につきやすく、コンバージョンも簡単です。
- セール価格はユーザーに対して動機付けとなります。
- アプリ内購入と広告も利用できます。

### <a name="apps-from-the-microsoft-store-provide-a-seamless-install-uninstall-and-upgrade-experience"></a>Microsoft Store からアプリのシームレスなインストール、アンインストール、アップグレードのエクスペリエンスを提供する

すべての UWP アプリは、ユーザー、デバイス、システムを保護するパッケージ システムを使用して配布されます。 UWP アプリはアプリで作成したドキュメント以外に何も残さずにアンインストールすることができるため、ユーザーはアプリをインストールしたことを後悔する必要はありません。

アプリはシームレスに展開および更新することができます。 ユーザーが必要に応じてコンテンツや拡張機能をダウンロードできるように、アプリのパッケージをモジュール化することができます。

## <a name="deliver-relevant-real-time-info-to-your-users-to-keep-them-coming-back"></a>関連するリアルタイム情報をユーザーに表示して繰り返し集客する

UWP アプリに対するユーザーのエンゲージメントを維持するためのさまざまな方法があります。

- ライブ タイルとロック画面タイルは、アプリからのコンテキストに関連したタイムリーな情報をひとめでわかるように表示します。
- プッシュ通知は、ユーザーがリアルタイムの通知に注目できるようにします。
- ユーザー アクティビティでは、異なるデバイスでも、アプリで前回中断したところから作業を始めることができます。
- アクション センターでは、アプリの通知を整理できます。
- バックグラウンドの実行とトリガーにより、ユーザーが必要とするときにアプリが有効になります。
- アプリで音声と Bluetooth LE デバイスを使うと、ユーザーはそれらのデバイスを中心に広がる世界とやり取りすることができます。
- 音声コマンド機能をアプリに追加するには、Cortana を統合します。

##  <a name="use-a-language-you-already-know"></a>使い慣れた言語の使用

UWP アプリは、オペレーティング システムによって提供されるネイティブな API である Windows ランタイムを使います。 この API は C++ で実装され、C#、Visual Basic、C++、JavaScript でサポートされます。 UWP アプリを作成するための一部のオプションを次に示します。

- XAML UI と、C#、VB、または C++
- DirectX UI と C++
- JavaScript と HTML

## <a name="links-to-help-you-get-going"></a>役に立つリンク

### <a name="get-set-up"></a>準備

「[準備](get-set-up.md)」を確認し、アプリの作成を始めるために必要なツールをダウンロードしてから、[初めてのアプリを作成](your-first-app.md)してください。

### <a name="design-your-app"></a>アプリをデザインする

Microsoft デザイン システムは Fluent と呼ばれます。 Fluent Design System は、すべての種類の Windows デバイスで適切に動作するアプリを作成するためのベスト プラクティスと組み合わされた、UWP 機能のセットです。 Fluent エクスペリエンスは、タブレット、ノート PC、デスクトップ、テレビから、仮想現実デバイスまで、さまざまなデバイスに対応し、自然に操作できます。 Fluent Design の概要については、[UWP アプリ向けの Fluent Design System に関するページ](https://docs.microsoft.com/windows/uwp/design/fluent-design-system)を参照してください。

適切な[設計](https://go.microsoft.com/fwlink/?LinkId=258848)とは、アプリの外観や機能に加えて、ユーザーによるアプリの操作方法を決定するプロセスです。 ユーザー エクスペリエンスは、ユーザーがアプリでどの程度満足するかを判断する場合に大きな役割を果たします。そのため、この手順は必ず守ってください。 [設計の基本に関するページ](https://developer.microsoft.com/en-us/windows/apps/design)では、ユニバーサル Windows アプリの設計を紹介します。 ユーザーを楽しませる UWP アプリの設計の情報については、「[デザイナー向けユニバーサル Windows プラットフォーム (UWP) アプリの紹介](https://msdn.microsoft.com/library/windows/apps/dn958439)」をご覧ください。 コーディングを開始する前に、ターゲットにするすべての異なるフォーム ファクターについてのアプリの使用についての操作エクスペリエンスを検討するために役立つ「[デバイスの基本情報](../design/devices/index.md)」をご覧ください。

さまざまなデバイスでの操作に加えて、複数のデバイスで動作する利点を取り入れるように [アプリの計画](https://msdn.microsoft.com/library/windows/apps/hh465427) を行います。 次に、例を示します。

- モバイル、小型画面デバイス、大型画面デバイスに対応するには、「[UWP アプリのナビゲーション デザインの基本](https://msdn.microsoft.com/library/windows/apps/dn958438)」を使用してワークフローをデザインします。 [ユーザー インターフェイスをレイアウトする](https://msdn.microsoft.com/library/windows/apps/dn958435)さまざまな画面サイズと解像度に対応します。

- 複数の入力の種類の対処方法を検討してください。 ユーザーが [Cortana](https://msdn.microsoft.com/library/windows/apps/dn974233)、[音声認識](https://msdn.microsoft.com/library/windows/apps/dn596121)、[タッチ操作](https://msdn.microsoft.com/library/windows/apps/hh465370)、[タッチ キーボード](https://msdn.microsoft.com/library/windows/apps/hh972345)などを使ってアプリを操作する方法については、「[操作のガイドライン](https://msdn.microsoft.com/library/windows/apps/dn611861)」をご覧ください。  または、従来の操作エクスペリエンスについて詳しくは、「[テキストとテキスト入力のガイドライン](https://msdn.microsoft.com/library/windows/apps/dn611864)」をご覧ください。

### <a name="add-services"></a>サービスの追加

- [クラウド サービス](https://go.microsoft.com/fwlink/?LinkId=526377)を使用して、デバイス間で同期します。
- アプリのエクスペリエンスをサポートするにあたって、[Web サービスに接続する](https://msdn.microsoft.com/library/windows/apps/xaml/hh761504)方法について説明します。
- アプリで音声コマンドに応答できるようにするために、[アプリに Cortana を追加する](https://mva.microsoft.com/training-courses/integrating-cortana-in-your-apps-8487?l=20D3s5Xz_5904984382)方法について説明します。
- [プッシュ通知](https://msdn.microsoft.com/library/windows/apps/mt187203)と[アプリ内購入](https://msdn.microsoft.com/library/windows/apps/mt219684)を計画に盛り込みます。 これらの機能はさまざまなデバイスで動作する必要があります。

### <a name="submit-your-app-to-the-store"></a>アプリをストアに提出する

[パートナー センター](https://partner.microsoft.com/dashboard)を管理し、すべての 1 つの場所での Windows デバイス向けアプリを送信することができます。 参照してください[発行の Windows アプリやゲーム](../publish/index.md)を Microsoft Store でのパブリケーション用のアプリケーションを送信する方法について説明します。

新しい機能が追加されたことで、より高度な管理が可能になった一方、プロセスは簡単になりました。 また、詳しい[分析レポート](https://msdn.microsoft.com/library/windows/apps/mt148522)に加えて、[支払いの詳細](https://msdn.microsoft.com/library/windows/apps/dn986925)も得られるようになりました。いずれも[アプリの宣伝と顧客エンゲージメントの獲得](https://msdn.microsoft.com/library/windows/apps/mt148526)に役立ちます。

別の入門資料については、「[Windows 10 デバイス向け Windows アプリのビルドの概要](https://msdn.microsoft.com/magazine/dn973012.aspx)」をご覧ください。

### <a name="more-advanced-topics"></a>高度なトピック

- アプリでのユーザー アクティビティが Windows タイムラインと Cortana の 前回終了した位置から再開機能に表示されるようにするには、[ユーザー アクティビティ](https://blogs.windows.com/buildingapps/2017/12/19/application-engagement-windows-timeline-user-activities/#tHuZ6tLPtCXqYKvw.97)の使用方法に関するページを参照してください。
- [UWP アプリのタイル、バッジ、通知](https://docs.microsoft.com/windows/uwp/design/shell/tiles-and-notifications/)の使用方法に関するページを参照してください。
- UWP アプリに利用可能な Win32 API の完全な一覧については、「[UWP アプリの API セット](https://msdn.microsoft.com/library/windows/desktop/mt186421)」と「[UWP アプリの DLL](https://msdn.microsoft.com/library/windows/desktop/mt186422)」をご覧ください。
- .NET UWP アプリの作成の概要については、[.NET でのユニバーサル Windows アプリに関するページ](https://blogs.msdn.microsoft.com/dotnet/2015/07/30/universal-windows-apps-in-net)を参照してください。
- UWP アプリで使用できる .NET 型の一覧については、「[UWP アプリの .NET](https://msdn.microsoft.com/library/mt185501.aspx)」を参照してください。
- [.NET ネイティブによるアプリのコンパイル](https://docs.microsoft.com/dotnet/framework/net-native/)
- [デスクトップ ブリッジ](https://developer.microsoft.com/windows/bridges/desktop)を使用して、既存のデスクトップ アプリに Windows 10 ユーザー向けの最新のエクスペリエンスを追加し、Microsoft Store で配布する方法について説明しています。

## <a name="how-the-universal-windows-platform-relates-to-windows-runtime-apis"></a>ユニバーサル Windows プラットフォームを Windows ランタイム Api に関連付ける方法
ユニバーサル Windows プラットフォーム (UWP) アプリをビルドしている場合は、多数の走行距離と外増減同義として"ユニバーサル Windows プラットフォーム (UWP)"と"Windows Runtime (WinRT)"という用語を扱うことの利便性を取得できます。 ですが、*は*テクノロジの内部で検索し、だけどのような違いがアイデアを判断することです。 について興味がある場合は、この最後のセクションでは、できます。

Windows ランタイム、および WinRT Api は Windows Api の進化したものです。 最初に、フラット、C スタイルの Win32 Api を使用して Windows のプログラム。 COM Api が追加されました ([DirectX](https://msdn.microsoft.com/library/windows/desktop/ee663274)顕著な例をされている)。 Windows フォーム、WPF、.NET、およびマネージ言語は、Windows アプリと API のテクノロジの独自のフレーバーを記述するは独自の方法になります。 Windows ランタイムが、実際には、COM の次のステージ 実際のアプリケーション バイナリ インターフェイス (ABI) 層では、COM では、そのルートが表示されます。 さまざまなプログラミング言語の優れた範囲から呼び出し可能である Windows ランタイムが設計されました。 各言語に非常に自然な方法で呼び出し可能。 このために、Windows ランタイムへのアクセスは言語プロジェクションとして知られる仕組みを使用して利用可能になっています。 Windows ランタイム言語プロジェクションはC#、Visual basic、C++ の標準に、JavaScript、という具合にします。 さらに、1 回パッケージ適切に (を参照してください[デスクトップ ブリッジ](/windows/uwp/porting/desktop-to-uwp-root))、アプリケーション モデルの優れた範囲のいずれかでビルドされたアプリから WinRT Api を呼び出すことができます。Win32、.NET、WinForms、および WPF します。

また、もちろん、UWP アプリから WinRT Api を呼び出すことができます。 UWP では、Windows ランタイムの上に構築されたアプリケーション モデルです。 技術的には、UWP のアプリケーション モデルの基に[CoreApplication](/uwp/api/windows.applicationmodel.core.coreapplication)、プログラミング言語の選択に応じて、ユーザーからその詳細が表示されないことができます。 値の提案の観点から、このトピックでは説明したよう、UWP に役立ち、選択する必要があります、Microsoft Store に発行して実行できる優れたさまざまなデバイス フォーム ファクターのいずれかにする 1 つのバイナリの書き込み。 UWP アプリのデバイスのリーチを呼び出すことで、アプリを制限することや、条件付きで呼び出すことに、UWP Api のサブセットに依存します。

うまくいけば、このセクションでは、Windows ランタイム Api、およびメカニズムとユニバーサル Windows プラットフォームのビジネス価値を基になるテクノロジ間の違いの説明で成功しています。
