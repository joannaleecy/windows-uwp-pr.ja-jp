---
author: TylerMSFT
title: サービス、拡張機能、パッケージでアプリを拡張する
description: ユニバーサル Windows プラットフォーム (UWP) アプリが更新された際に実行されるバックグラウンド タスクの作成方法を説明します。
ms.author: twhitney
ms.date: 05/21/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, 拡張, コンポーネント化, アプリ サービス, パッケージ, 拡張機能
ms.localizationpriority: medium
ms.openlocfilehash: 2721f9d8f768cabb0e07c0cd2cfcfcbf9255cd70
ms.sourcegitcommit: 6618517dc0a4e4100af06e6d27fac133d317e545
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/28/2018
ms.locfileid: "1689618"
---
# <a name="extend-your-app-with-services-extensions-and-packages"></a>サービス、拡張機能、パッケージでアプリを拡張する

Windows 10 には、アプリの拡張とコンポーネント化に役立つさまざまなテクノロジがあります。 次の表は、シナリオで使用する必要があるテクノロジを判断するのに役立ちます。 その後で、シナリオとテクノロジについて簡単に説明します。


| シナリオ                           | リソース パッケージ | オプション パッケージ | アプリの拡張機能    | アプリ サービス      | ストリーミング インストール |
|------------------------------------|:----------------:|:----------------:|:----------------:|:----------------:|:-----------------:|
| サード パーティー コード プラグイン            |                  |                  | :heavy_check_mark: |                  |                   |
| インプロセス コード プラグイン              |                  | :heavy_check_mark: |                  |                  |                   |
| UX アセット (文字列/画像)         | :heavy_check_mark: | :heavy_check_mark: | :heavy_check_mark: |                  | :heavy_check_mark: |
| オンデマンド コンテンツ <br/> (例: 追加の階層) |    | :heavy_check_mark: | :heavy_check_mark: |                  | :heavy_check_mark: |
| ライセンスと取得の分離 |                  | :heavy_check_mark: | :heavy_check_mark: | :heavy_check_mark: |                   |
| アプリ内取得                 |                  | :heavy_check_mark: | :heavy_check_mark: |                  |                   |
| インストール時間の最適化              | :heavy_check_mark: | :heavy_check_mark: | :heavy_check_mark: |                  | :heavy_check_mark: |

## <a name="scenario-descriptions-rows-in-the-table"></a>シナリオの説明 (テーブルの行)

**サード パーティー プラグイン**  

ストアからダウンロードしてアプリで実行できるコードです。 たとえば、Microsoft Edge ブラウザーの拡張機能などです。

**インプロセス コード プラグイン**  

アプリのプロセス内で実行されるコードです。 C++ でのみサポートされています。 コンテンツが含まれる場合もあります。 コードはプロセス内で実行されるため、より高いレベルの信頼が想定されます。 サードパーティーのこの種の拡張機能は開かないようにすることもできます。

**UX アセット (文字列/画像)**  

ローカライズされた文字列、画像、その他の UI コンテンツなど、ロケールなどの要因を基準に分ける必要があるユーザー インターフェイス アセットです。

**オンデマンド コンテンツ**  

後でダウンロードするコンテンツです。 たとえば、新しいレベル、スキン、機能をダウンロードできるアプリ内購入などです。

**ライセンスと取得の分離**  

アプリから独立してコンテンツのライセンス付与と取得を行うことができます。

**アプリ内取得**  

アプリ内部からコンテンツを取得するための、プログラムによるサポートがあるかどうかを示します。

**インストール時間の最適化**

ストアからアプリを取得して実行を開始するまでにかかる時間を短縮する機能を提供します。

## <a name="technology-descriptions-columns-in-the-table"></a>テクノロジの説明 (テーブルの列)

**リソース パッケージ**

リソース パッケージは、アプリで複数のディスプレイ サイズとシステム言語に対応できるようにするアセットのみのパッケージです。 リソース パッケージは、ユーザー言語、システム スケール、および DirectX 機能をターゲットにしており、さまざまなユーザー シナリオに合わせてアプリを調整できます。 アプリ パッケージには複数のリソースが含まれている可能性がありますが、OS はユーザー デバイスごとに適切なリソースだけをダウンロードするため、帯域幅とディスク領域が節約されます。

**オプション パッケージ**

オプション パッケージは、アプリ パッケージの元の機能を補完または拡張するために使用されます。 アプリを公開した後に、しばらく経ってからオプション パッケージ公開したり、アプリとオプション パッケージの両方を同時に公開したりすることができます。 オプション パッケージを利用してアプリを拡張することによって、別のアプリ パッケージとしてコンテンツを配信して収益を得られるメリットがあります。 オプション パッケージは一般的に、元のアプリ開発者によって開発されることを意図しています。それは、(アプリ拡張機能とは異なり) オプション パッケージがメイン アプリの ID を使用して実行されるためです。 オプション パッケージの定義方法に応じて、コード、アセット、またはコードとアセットの両方をオプション パッケージからメイン アプリに読み込むことができます。 個別に収益化、ライセンス付与、および配信できるコンテンツでアプリを強化することを検討している場合は、オプション パッケージが適切です。 実装の詳細については、「[オプション パッケージと関連セットの作成](https://docs.microsoft.com/windows/uwp/packaging/optional-packages)」をご覧ください。

**アプリの拡張機能**

[アプリの拡張機能](https://docs.microsoft.com/uwp/api/windows.applicationmodel.appextensions) で、他の UWP アプリから提供されるコンテンツをホストすることができます。 それらのアプリの読み取り専用コンテンツを検出、列挙し、アクセスすることもできます。

拡張機能がアプリでサポートされている場合、開発者はだれでもそのアプリの拡張機能を提出できます。 したがって、ホスト アプリは事前にテストされていない拡張機能を読み込む際に、堅牢であることが求められます。 拡張機能は信頼できないと見なされる必要があります。

アプリケーションで拡張機能のコードを読み込むことはできません。 コードを実行する必要がある場合は、アプリ サービスを検討してください。

**アプリ サービス**

Windows アプリ サービスでは、UWP アプリからほかのユニバーサル Windows アプリにサービスを提供できるようにすることで、アプリ間通信を実現します。 アプリ サービスでは、同じデバイス上のアプリから呼び出せる UI を持たないサービスを作成できます。また、Windows 10 バージョン 1607 以降では、リモート デバイスからも呼び出せます。 詳しくは、「[アプリ サービスの作成と利用](https://docs.microsoft.com/windows/uwp/launch-resume/how-to-create-and-consume-an-app-service)」をご覧ください。

アプリ サービスは、他の UWP アプリにサービスを提供する UWP アプリです。 これは、デバイス上にある Web サービスのようなものです。 アプリ サービスは、バック グラウンド タスクとしてホスト アプリで実行され、そのサービスを他のアプリに提供することができます。 たとえば、アプリ サービスによって、他のアプリで使用できるバー コード スキャナー サービスが提供される場合があります。 また、アプリのエンタープライズ スイートに共通のスペル チェック アプリ サービスを備えておき、そのサービスを同じスイート内の他のアプリから利用可能にする場合もあるでしょう。

**UWP アプリ ストリーミング インストール**

ストリーミング インストールは、ユーザーにアプリを配信する方法を最適化する手段です。 アプリ全体がダウンロードされるのを待ってからユーザーが使用できるようになるのではなく、必要な部分がダウンロードされた時点で、そのアプリを利用できます。 基本的なライセンス認証と起動に必要なセクションと、アプリの他の部分の追加コンテンツにアプリを分割するかどうかは、開発者の任意です。 詳しい情報と実装の詳細については、「[UWP アプリ ストリーミング インストール](https://docs.microsoft.com/windows/uwp/packaging/streaming-install)」をご覧ください。

## <a name="see-also"></a>関連項目

[アプリ サービスの作成と利用](https://docs.microsoft.com/windows/uwp/launch-resume/how-to-create-and-consume-an-app-service)  
[オプション パッケージと関連セットの作成](https://docs.microsoft.com/windows/uwp/packaging/optional-packages)  
[Windows.ApplicationModel.Extensions 名前空間](https://docs.microsoft.com/uwp/api/windows.applicationmodel.appextensions)  
[UWP アプリ ストリーミング インストール](https://docs.microsoft.com/windows/uwp/packaging/streaming-install)  
[Windows.ApplicationModel.AppService 名前空間](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.AppService)    
