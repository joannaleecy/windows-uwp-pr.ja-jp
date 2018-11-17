---
author: Xansky
description: サポートされている最新の Microsoft Advertising ライブラリを使用し、アプリで引き続きバナー広告を受信できるように、アプリを更新する方法について説明します。
title: バナー広告用の最新の Advertising ライブラリを使用するようにアプリを更新する
ms.author: mhopkins
ms.date: 08/23/2017
ms.topic: article
keywords: Windows 10, UWP, 広告, 宣伝, AdControl, AdMediatorControl, 移行
ms.assetid: f8d5b2ad-fcdb-4891-bd68-39eeabdf799c
ms.localizationpriority: medium
ms.openlocfilehash: 48fc818c1ae7a9a46912ff52c2b00b07f19c366e
ms.sourcegitcommit: 3257416aebb5a7b1515e107866806f8bd57845a8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/17/2018
ms.locfileid: "7170494"
---
# <a name="update-your-app-to-the-latest-advertising-libraries-for-banner-ads"></a>バナー広告用の最新の Advertising ライブラリを使用するようにアプリを更新する

2017 年 4 月 1 日の時点で、サポートされていない広告 SDK リリースを使うアプリにはバナー広告が提供されなくなりました。 ユニバーサル Windows プラットフォーム (UWP) アプリで **AdControl** を使用してバナー広告を表示している場合、この記事の情報を使用して、サポートされていない広告 SDK を使用しているかどうかを判断し、アプリをサポートされる SDK に移行します。

## <a name="overview"></a>概要

バナー広告を表示する UWP アプリでは、[Microsoft Advertising SDK](http://aka.ms/ads-sdk-uwp) で配布されている Advertising ライブラリの **AdControl** を使用する必要があります。 この SDK では、Interactive Advertising Bureau (IAB) の [Mobile Rich-media Ad Interface Definitions (MRAID) 1.0 仕様](http://www.iab.com/wp-content/uploads/2015/08/IAB_MRAID_VersionOne.pdf)を通じた HTML5 リッチ メディアの提供機能など、最小限の広告機能セットがサポートされています。 多くの広告主様がこれらの機能を必要とされており、Microsoft ではアプリ開発者にこれらのいずれかの SDK リリースの使用を求めることで、より魅力的なアプリのエコシステムを広告主様に提供し、開発者様の収益アップを図ります。

この SDK をリリースする前に、いくつかの古い広告 SDK リリースで **AdControl** クラスを提供していました。 これらの以前の広告 SDK リリースは、上記で説明した最小限の広告機能をサポートしていないため、サポートされなくなりました。 2017 年 4 月 1 日の時点で、サポートされていない広告 SDK リリースを使うアプリにはバナー広告が提供されなくなりました。 サポートされていない広告 SDK リリースを使うアプリがまだある場合、次の動作が発生します。

* アプリ内の **AdControl** コントロールにバナー広告が提供されず、これらのコントロールから広告収入を得ることができなくなります。

* アプリ内の **AdControl** から新しい広告が要求されると、コントロールの **ErrorOccurred** イベントが発生し、イベント引数の **ErrorCode** プロパティに **NoAdAvailable** という値が設定されます。

* そのアプリに関連付けられているすべての広告ユニットが非アクティブ化されます。 これらの非アクティブ化された広告ユニットは、DePartnerv センターのアカウントから削除することはできません。 アプリを更新して [Microsoft Advertising SDK](http://aka.ms/ads-sdk-uwp) を使う場合、これらの広告ユニットを無視して新しい広告ユニットを作成します。

* 複数のアプリで使われている広告ユニットにも、バナー広告が提供されなくなりました。 広告ユニットがそれぞれ 1 つのアプリだけで使われるようにしてください。

**AdControl** を使ってバナーを表示するアプリ (Microsoft Store に公開済みまたは開発中) が既にあり、アプリにより使われている広告 SDK がわからない場合は、この記事の手順に従って、アプリをサポートされている SDK に更新する必要があるかどうかを判断してください。 問題が発生した場合やサポートが必要な場合は、[サポートにお問い合わせください](http://go.microsoft.com/fwlink/?LinkId=393643)。

> [!NOTE]
> アプリが既に [Microsoft Advertising SDK](http://aka.ms/ads-sdk-uwp) (UWP アプリ用) を使用している場合、アプリをさらに変更を加える必要はありません。

## <a name="prerequisites"></a>前提条件

* **AdControl** を使用しているアプリの完全なソース コードおよび Visual Studio プロジェクト ファイル。
* アプリの .appx パッケージ。

> [!NOTE]
> アプリの .appx パッケージがなくなっていても、このアプリの構築に使用したバージョンの Visual Studio と Advertising SDK がインストールされた状態の開発用コンピューターがあれば、Visual Studio で .appx パッケージを再生成できます。

<span id="part-1" />

## <a name="part-1-determine-whether-you-need-to-update-your-uwp-app"></a>パート 1: UWP アプリを更新する必要があるかどうかを決定する

以下のセクションの手順に従い、アプリの更新が必要かどうかを調べます。

1. 元のファイルを損なわないようにアプリの .appx パッケージのコピーを作成し、コピーの名前を変更して .zip 拡張子を付け、このファイルの内容を抽出します。

2. アプリ パッケージから抽出した内容を確認します。
  * Microsoft.Advertising.dll ファイルがある場合は、アプリで以前の SDK が使用されているため、以下のセクションの手順に従ってプロジェクトを更新する必要があります。 [パート 2](update-your-app-to-the-latest-advertising-libraries.md#part-2) に進みます。
  * Microsoft.Advertising.dll ファイルがない場合は、最新の利用可能な Advertising SDK が既に UWP アプリで使用されているため、プロジェクトに変更を加える必要はありません。


<span id="part-2" />

## <a name="part-2-install-the-latest-sdk"></a>パート 2: 最新の SDK をインストールする

アプリで以前の SDK リリースが使用されている場合は、次の手順に従って、開発用コンピューターに最新の SDK がインストールされているかどうかを確認します。

1. 開発用コンピューターに Visual Studio 2015 以降のリリースがインストールされていることを確認します。
    > [!NOTE]
    > 開発用コンピューターで Visual Studio が開いている場合は、閉じてから、以下の手順を実行します。

1.  開発用コンピューターから、以前のバージョンの Microsoft Advertising SDK および Ad Mediator SDK をアンインストールします。

2.  **コマンド プロンプト** ウィンドウを開き、次のコマンドを実行することによって、Visual Studio と共にインストールされている以前の SDK のバージョンをすべて削除します。これらのバージョンは、コンピューターにインストールされているプログラムの一覧には表示されない可能性があります。
    ```syntax
    MsiExec.exe /x{5C87A4DB-31C7-465E-9356-71B485B69EC8}
    MsiExec.exe /x{6AB13C21-C3EC-46E1-8009-6FD5EBEE515B}
    MsiExec.exe /x{6AC81125-8485-463D-9352-3F35A2508C11}
    ```

3.  [Microsoft Advertising SDK](http://aka.ms/ads-sdk-uwp) をインストールします。

## <a name="part-3-update-your-project"></a>パート 3: プロジェクトを更新する

プロジェクトから Microsoft Advertising ライブラリへの既存の参照をすべて削除し、[これらの手順](install-the-microsoft-advertising-libraries.md#reference)に従って、必要な参照を追加します。 これにより、プロジェクトで適切なライブラリが確実に使用されるようになります。 既存のマークアップとコードを保持することもできます。

## <a name="part-4-test-and-republish-your-app"></a>パート 4: アプリのテストと再公開を行う

アプリをテストし、バナーが正常に提供されることを確認します。

アプリの以前のバージョンがある場合既にストアにアプリを再公開するパートナー センターで、更新されたアプリの[新しい申請を作成](../publish/app-submissions.md)します。
