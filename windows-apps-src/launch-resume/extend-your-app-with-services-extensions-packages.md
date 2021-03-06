---
title: サービス、拡張機能、パッケージでアプリを拡張する
description: ユニバーサル Windows プラットフォーム (UWP) ストア アプリが更新されるときに実行されるバック グラウンド タスクを作成する方法について説明します。
ms.date: 05/07/2018
ms.topic: article
keywords: Windows 10, UWP, 拡張, コンポーネント化, アプリ サービス, パッケージ, 拡張機能
ms.localizationpriority: medium
ms.openlocfilehash: 47ab6491d09775bf86f0f484fc96d85bd07f53a4
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57590677"
---
# <a name="extend-your-app-with-services-extensions-and-packages"></a>サービス、拡張機能、パッケージでアプリを拡張する

多くのテクノロジには Windows 10 を拡張すると、アプリを componentizing です。 このテーブルを使用するとする必要がありますの要件に応じて使用する必要がありますテクノロジを判断できます。 その後で、シナリオとテクノロジについて簡単に説明します。

| シナリオ                           | リソース パッケージ   | アセット パッケージ      | オプション パッケージ   | フラット バンドル        | アプリの拡張機能      | アプリ サービス        | ストリーミング インストール  |
|------------------------------------|:------------------:|:------------------:|:------------------:|:------------------:|:------------------:|:------------------:|:------------------:|
| サード パーティ コード プラグイン            |                    |                    |                    |                    | :heavy_check_mark: |                    |                    |
| インプロセス コード プラグイン              |                    |                    | :heavy_check_mark: |                    |                    |                    |                    |
| UX アセット (文字列/画像)         | :heavy_check_mark: | :heavy_check_mark: | :heavy_check_mark: |                    | :heavy_check_mark: |                    | :heavy_check_mark: |
| オンデマンド コンテンツ <br/> (例: 追加の階層) |      |                    | :heavy_check_mark: |                    | :heavy_check_mark: |                    | :heavy_check_mark: |
| ライセンスと取得の分離 |                    |                    | :heavy_check_mark: |                    | :heavy_check_mark: | :heavy_check_mark: |                    |
| アプリ内取得                 |                    |                    | :heavy_check_mark: |                    | :heavy_check_mark: |                    |                    |
| インストール時間の最適化              | :heavy_check_mark: |                    | :heavy_check_mark: |                    | :heavy_check_mark: |                    | :heavy_check_mark: |
| ディスク使用量の削減              | :heavy_check_mark: |                    | :heavy_check_mark: |                    |                    |                    |                    |
| パッケージ化の最適化                 |                    | :heavy_check_mark: | :heavy_check_mark: | :heavy_check_mark: |                    |                    |                    |
| 公開までの時間の短縮             | :heavy_check_mark: | :heavy_check_mark: | :heavy_check_mark: | :heavy_check_mark: |                    |                    |                    |

## <a name="scenario-descriptions-the-rows-in-the-table-above"></a>シナリオの説明 (上のテーブルの行)

**サード パーティ プラグイン**  

ストアからダウンロードしてアプリで実行できるコードです。 たとえば、Microsoft Edge ブラウザーの拡張機能などです。

**インプロセス コード プラグイン**  

アプリのプロセス内で実行されるコードです。 C++ でのみサポートされています。 コンテンツが含まれる場合もあります。 コードはプロセス内で実行されるため、より高いレベルの信頼が想定されます。 このようなサードパーティ製の拡張機能を公開するには、しないことができます。

**UX 資産 (文字列/イメージ)**  

ローカライズされた文字列、画像、その他の UI コンテンツなど、ロケールなどの要因を基準に分ける必要があるユーザー インターフェイス アセットです。

**オンデマンド コンテンツ**  

後でダウンロードするコンテンツです。 たとえば、新しいレベル、スキン、機能をダウンロードできるアプリ内購入などです。

**個別のライセンスと購入**  

アプリから独立してコンテンツのライセンス付与と取得を行うことができます。

**アプリ内購入**  

アプリ内部からコンテンツを取得するための、プログラムによるサポートがあるかどうかを示します。

**インストール時を最適化します。**

ストアからアプリを取得して実行を開始するまでにかかる時間を短縮する機能を提供します。

**ディスク使用量の削減** 必要なアプリやリソースのみを含めることでアプリのサイズを削減します。

**パッケージを最適化**大規模または複雑なアプリのアプリのパッケージ化プロセスを最適化します。

**公開までの時間の短縮** Microsoft Store、ローカル共有、または Web サーバーでアプリを公開するのにかかる時間を最小限に抑えます。

## <a name="technology-descriptions-the-columns-in-the-table-above"></a>テクノロジの説明 (上のテーブルの列)

**リソース パッケージ**

リソース パッケージは、アプリで複数のディスプレイ サイズとシステム言語に対応できるようにするアセットのみのパッケージです。 リソース パッケージは、ユーザー言語、システム スケール、および DirectX 機能をターゲットにしており、さまざまなユーザー シナリオに合わせてアプリを調整できます。 アプリ パッケージには複数のリソースが含まれている可能性がありますが、OS はユーザー デバイスごとに適切なリソースだけをダウンロードするため、帯域幅とディスク領域が節約されます。

**アセット パッケージ**アセット パッケージは、実行可能ファイルの共通の一元的なソースまたは非実行可能ファイルをアプリで使用するためです。 これらは、通常のプロセッサまたは言語固有のファイルです。 たとえば、1 つのアセット パッケージの画像のコレクション、および別のアセット パッケージのビデオが含まれる可能性があります。両方ともアプリで使用されます。 アーキテクチャのパッケージまたはリソースのパッケージが含まれるこれらの資産が、資産が複数回複製される、さまざまなアーキテクチャのパッケージ間で実行すること、アプリは、複数のアーキテクチャと複数の言語をサポートする場合ディスク領域。 アセット パッケージを使用している場合は、アプリ パッケージ全体に 1 回のみ含める必要があります。 詳細については、「[アセット パッケージの概要](../packaging/asset-packages.md)」を参照してください。

**省略可能なパッケージ**

オプション パッケージは、アプリ パッケージの元の機能を補完または拡張するために使用されます。 アプリを公開した後に、しばらく経ってからオプション パッケージ公開したり、アプリとオプション パッケージの両方を同時に公開したりすることができます。 オプション パッケージを利用してアプリを拡張することによって、別のアプリ パッケージとしてコンテンツを配信して収益を得られるメリットがあります。 オプション パッケージは一般的に、元のアプリ開発者によって開発されることを意図しています。それは、(アプリ拡張機能とは異なり) オプション パッケージがメイン アプリの ID を使用して実行されるためです。 オプション パッケージの定義方法に応じて、コード、アセット、またはコードとアセットの両方をオプション パッケージからメイン アプリに読み込むことができます。 利用できるライセンスを取得するコンテンツでアプリを強化する必要がある場合とは別に分散し、省略可能なパッケージが最適な選択肢があります。 実装の詳細については、「[オプション パッケージと関連セットの作成](https://docs.microsoft.com/windows/uwp/packaging/optional-packages)」を参照してください。

**フラット バンドル**
[フラット バンドル アプリ パッケージ](../packaging/flat-bundles.md)は通常のアプリ バンドルに似ていますが、フォルダー内にすべてのアプリ パッケージを含めるのではなく、フラット バンドルにはそれらのアプリ パッケージへの*参照*のみ含まれる点が異なります。 ファイル自体ではなくアプリ パッケージへの参照を含めることで、フラット バンドルはアプリをパッケージ化してダウンロードするのにかかる時間を短縮します。

**アプリ拡張機能**

[アプリの拡張機能](https://docs.microsoft.com/uwp/api/windows.applicationmodel.appextensions) で、他の UWP アプリから提供されるコンテンツをホストすることができます。 それらのアプリの読み取り専用コンテンツを検出、列挙し、アクセスすることもできます。

拡張機能がアプリでサポートされている場合、開発者はだれでもそのアプリの拡張機能を提出できます。 したがって、ホスト アプリは事前にテストされていない拡張機能を読み込む際に、堅牢であることが求められます。 拡張機能は信頼できないと見なされる必要があります。

アプリケーションで拡張機能のコードを読み込むことはできません。 コードを実行する必要がある場合は、アプリ サービスを検討してください。

**App Service**

Windows アプリのサービスは、別のユニバーサル Windows アプリにサービスを提供する UWP アプリを許可することで、アプリへの通信を有効にします。 アプリ サービスでは、同じデバイス上のアプリから呼び出せる UI を持たないサービスを作成できます。また、Windows 10 バージョン 1607 以降では、リモート デバイスからも呼び出せます。 詳しくは、「[アプリ サービスの作成と利用](https://docs.microsoft.com/windows/uwp/launch-resume/how-to-create-and-consume-an-app-service)」をご覧ください。

アプリ サービスは、他の UWP アプリにサービスを提供する UWP アプリです。 デバイス上の web サービスに似ています。 アプリ サービスは、バック グラウンド タスクとしてホスト アプリで実行され、そのサービスを他のアプリに提供することができます。 たとえば、アプリ サービスによって、他のアプリで使用できるバー コード スキャナー サービスが提供される場合があります。 また、アプリのエンタープライズ スイートに共通のスペル チェック アプリ サービスを備えておき、そのサービスを同じスイート内の他のアプリから利用可能にする場合もあるでしょう。

**UWP アプリのストリーミング インストール**

ストリーミング インストールは、ユーザーにアプリを配信する方法を最適化する手段です。 アプリ全体がダウンロードされるのを待ってからユーザーが使用できるようになるのではなく、必要な部分がダウンロードされた時点で、そのアプリを利用できます。 基本的なライセンス認証と起動に必要なセクションと、アプリの他の部分の追加コンテンツにアプリを分割するかどうかは、開発者の任意です。 詳しい情報と実装の詳細については、「[UWP アプリ ストリーミング インストール](https://docs.microsoft.com/windows/uwp/packaging/streaming-install)」を参照してください。

## <a name="see-also"></a>関連項目

[App Service の作成と利用](https://docs.microsoft.com/windows/uwp/launch-resume/how-to-create-and-consume-an-app-service)  
[アセット パッケージの概要](../packaging/asset-packages.md)  
[パッケージ レイアウトでパッケージの作成](../packaging/packaging-layout.md)  
[オプション パッケージと関連セットの作成](https://docs.microsoft.com/windows/uwp/packaging/optional-packages)  
[アセット パッケージとパッケージの圧縮を使用した開発](../packaging/package-folding.md)  
[UWP アプリ ストリーミング インストール](https://docs.microsoft.com/windows/uwp/packaging/streaming-install)  
[フラットなバンドルのアプリ パッケージ](../packaging/flat-bundles.md)  
[Windows.ApplicationModel.AppService 名前空間](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.AppService)  
[Windows.ApplicationModel.Extensions 名前空間](https://docs.microsoft.com/uwp/api/windows.applicationmodel.appextensions)  
