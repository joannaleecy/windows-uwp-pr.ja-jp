---
title: Windows ドキュメントの最新情報、2017 年 9 月 - UWP アプリの開発
description: 2017 年 9 月版の Windows 10 開発者向けドキュメントには、新しい機能、ビデオ、開発者向けガイダンスが追加されました
keywords: 最新情報, 更新, 機能, 開発者向けガイダンス, Windows 10, 1709
ms.date: 09/06/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: c3fe097be63fef790b9dcc4cedd6ee457e3c79f5
ms.sourcegitcommit: b5c9c18e70625ab770946b8243f3465ee1013184
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/28/2018
ms.locfileid: "7964145"
---
# <a name="whats-new-in-the-windows-developer-docs-in-september-2017"></a>Windows 開発者向けドキュメントの最新情報、2017 年 9 月

Windows 開発者向けドキュメントは、Windows プラットフォームで開発者に提供される新機能の情報を反映して継続的に更新されています。 ここに示す機能概要、開発者向けガイダンス、サンプルは最近公開されたもので、Windows 開発者向けの新しい情報や更新情報を含んでいます。

Fall Creators Update がすぐそこまで近づいているため、来月に発表される大量のドキュメントにも注目してください。

Windows 10 の[ツールと SDK をインストール](http://go.microsoft.com/fwlink/?LinkId=821431)すると、[新しいユニバーサル Windows アプリを作成](../get-started/your-first-app.md)したり、[Windows の既存のアプリ コード](../porting/index.md)がどのように使えるかを試したりすることができます。

## <a name="features"></a>機能

### <a name="xbox-live-creators-program"></a>Xbox Live クリエーターズ プログラム

Xbox Live クリエーターズ プログラムは現在実施中で、Windows 10 PC と Xbox One 本体上で実行できる UWP ゲームを簡単に作成して公開できます。 詳細については、「[Xbox Live クリエーターズ プログラムの概要](../xbox-live/get-started-with-creators/get-started-with-xbox-live-creators.md)」をご覧ください。

## <a name="developer-guidance"></a>開発者向けガイダンス

### <a name="xaml-basics-tutorials"></a>XAML の基本チュートリアル

新しい [PhotoLab サンプル](https://github.com/Microsoft/Windows-appsample-photo-lab)を加え、4 つの [XAML の基本チュートリアル](https://docs.microsoft.com/en-us/windows/uwp/get-started/xaml-basics-intro)が作成され、XAML のプログラミングの重要な 4 つの側面である、ユーザー インターフェイス、データ バインディング、カスタム スタイル、およびアダプティブ レイアウトについて説明しています。 各チュートリアル トラックは、部分的に完成したバージョンの PhotoLab サンプルから始まり、ステップ バイ ステップで、最終的なアプリの不足しているコンポーネントを 1 つ作成します。 

![PhotoLab サンプルのフォト ギャラリー ページのスクリーンショット](images/PhotoLab-gallery-page.png)  

新しい記事の簡単な概要を次に示します。

+ [**ユーザー インターフェイスを作成する**](https://docs.microsoft.com/en-us/windows/uwp/get-started/xaml-basics-ui): 基本的なフォト ギャラリー インターフェイスの作成方法について説明します。
+ [**データ バインディングを作成する**](https://docs.microsoft.com/en-us/windows/uwp/get-started/xaml-basics-data-binding): フォト ギャラリーにデータ バインディングを追加し、実際のイメージ データを設定する方法について説明します。
+ [**カスタム スタイルを作成する**](https://docs.microsoft.com/en-us/windows/uwp/get-started/xaml-basics-style): フォト編集メニューにしゃれたカスタム スタイルを追加する方法について説明します。
+ [**アダプティブ レイアウト作成する**](https://docs.microsoft.com/en-us/windows/uwp/get-started/xaml-basics-adaptive-layout): すべてのデバイスおよび画面サイズで適切な表示になるように、ギャラリー レイアウトをアダプティブにする方法について説明します。

### <a name="get-started-tutorials"></a>入門チュートリアル

更新された UWP のドキュメントの「概要」セクションが更新され、[チュートリアル セクションの新しいランディング ページ](https://docs.microsoft.com/windows/uwp/get-started/create-uwp-apps)が追加されました。 このセクションでは、入門用エクスペリエンスを簡単に見つけられるように構造が刷新および改善され、ユーザーは適切なチュートリアルを簡単に検索して使用できます。上記の XAML の基本チュートリアルも含まれます。

### <a name="voice-and-tone"></a>ボイスとトーン

新しい [UWP アプリでのトーンのボイスに関するガイダンス](https://docs.microsoft.com/windows/uwp/in-app-help/voice-and-tone)が追加され、アプリでテキストを記述するためのアドバイスを提供します。 作成する対象に関係なく、使用する言葉が親しみやすく、友好的で、有益であることが重要です。

## <a name="samples"></a>サンプル

### <a name="photolab-sample"></a>PhotoLab サンプル

[PhotoLab サンプル](https://github.com/Microsoft/windows-appsample-photo-lab)は、基本的なフォト ギャラリーとフォト編集エクスペリエンスを提供します。

![PhotoLab サンプルのフォト編集ページのスクリーンショット](images/PhotoLab-editing-page.png)  

### <a name="customer-orders"></a>顧客の注文

[顧客注文データベース](https://github.com/Microsoft/Windows-appsample-customers-orders-database) サンプルは、新しい .NET Core 2.0 と Entity Framework を使用するように更新されました。