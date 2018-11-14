---
title: Xbox Live サインインのトラブルシューティング
author: KevinAsgari
description: Xbox Live のサインインの問題をトラブルシューティングする方法について説明します。
ms.assetid: 87b70b4c-c9c1-48ba-bdea-b922b0236da4
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
keywords: xbox live, xbox, ゲーム, uwp, windows 10, xbox one, サインイン, トラブルシューティング
ms.localizationpriority: medium
ms.openlocfilehash: 49806ea48b8af691d5b161e21426c73d65712408
ms.sourcegitcommit: f2c9a050a9137a473f28b613968d5782866142c6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/10/2018
ms.locfileid: "6250618"
---
# <a name="troubleshooting-xbox-live-sign-in"></a>Xbox Live サインインのトラブルシューティング

サインインに問題が発生する場合、いくつかの原因が考えられます。  「[UWP ゲーム用 Visual Studio の概要](../../get-started-with-partner/get-started-with-visual-studio-and-uwp.md)」の手順に従うと、予期しないエラーが発生する可能性を最小限に抑えることができます。

## <a name="common-issues"></a>一般的な問題

### <a name="sandbox-problems"></a>サンドボックスの問題

一般的に言えば、サンドボックスの概念、およびサンドボックスと Xbox Live の関係をよく理解する必要があります。  詳細は、「[Xbox Live Sandboxes](../../xbox-live-sandboxes.md)」ガイドを参照してください。

簡単に言えば、サンドボックスはリテール リリースの前にコンテンツ分離とアクセス制御を行います。  開発サンドボックスへのアクセス権を持たないユーザーは、タイトルに関する読み書き操作を実行できません。  また、テストのために、異なるサンドボックスに異なるサービス構成を発行することもできます。

以下では、サンドボックスに関して注意する必要のあることについて説明します。

#### <a name="developer-account-doesnt-have-access-to-the-right-sandbox-for-run-time-access"></a>開発者アカウントでは実行時アクセス用の正しいサンドボックスにアクセスできない

* テスト アカウント (開発アカウントとも呼ばれます) または承認された開発者アカウントは、開発中のタイトルにサインインに使用する必要があります。  1 つを使用してサインインしようとしているか、他のテスト アカウントが XDP で作成されたことを確認[https://xdp.xboxlive.com/User/Contact/MyAccess?selectedMenu=devaccounts](https://xdp.xboxlive.com/User/Contact/MyAccess?selectedMenu=devaccounts)します。 パートナー センターでの xbox live の関連付けられている開発者アカウントを承認します。[https://partner.microsoft.com/en-us/xboxconfig/TestAccounts/Creator](https://partner.microsoft.com/en-us/xboxconfig/TestAccounts/Creator)
* アカウントには、タイトルが公開サンド ボックスへのアクセスを持っていることを確認します。  XDP で作成したテスト アカウントは、それを作成した XDP アカウントのアクセス許可を継承します。

#### <a name="your-device-is-not-on-the-correct-sandbox"></a>デバイスが正しいサンドボックス上にない

開発に使用するデバイスは、開発サンドボックスに設定されている必要があります。  Xbox One では、*Xbox One Manager* を使用してサンドボックスを設定できます。  Windows 10 Desktop の場合は、Xbox Live SDK インストールの Tools ディレクトリにある SwitchSandbox.cmd スクリプトを使用できます。

#### <a name="your-titles-service-configuration-is-not-published-to-the-correct-development-sandbox"></a>タイトルのサービス構成が正しい開発サンドボックスに発行されていない

タイトルのサービス構成が開発サンドボックスに発行されていることを確認します。  タイトルが同じサンドボックスに発行されていない場合、タイトルの特定の開発サンドボックスの Xbox Live にサインインできません。  詳細な方法については、[XDP のドキュメント](https://developer.xboxlive.com/en-us/xdphelp/development/xdpdocs/Pages/setting_up_service_configuration_03_31_16.aspx#PublishServiceConfig)を参照してください。 パートナー センター構成を公開する方法については[パートナー センターのドキュメント](../../get-started-with-creators/xbox-live-service-configuration-creators.md#publish-your-xbox-live-service-configuration)を読み取ることができます。

### <a name="ids-configured-incorrectly"></a>ID が正しく構成されていない

ゲームを構成するためには、複数の情報が ID に必要です。  詳しくは、作成しているタイトルの種類に応じて、「[UWP ゲーム用 Visual Studio の概要](../../get-started-with-partner/get-started-with-visual-studio-and-uwp.md)」と「[クロスプレイ ゲームの概要](../../get-started-with-partner/get-started-with-cross-play-games.md)」をご覧ください。

いくつか注意すべきことがあります。

* アプリの ID が XDP またはパートナー センターに正しく入力ことを確認します。
* PFN が XDP またはパートナー センターに正しく入力ことを確認します。
* 「[新規または既存の UWP プロジェクトに Xbox Live を追加する](../../get-started-with-partner/get-started-with-visual-studio-and-uwp.md)」ガイドで説明されているように、Visual Studio プロジェクトと同じディレクトリに xboxservices.config を 作成してあることを再確認します。
* appxmanifest で "Package Identity" が正しいことを確認します。  これは、パートナー センターで「パッケージ/Id/名」App Identity] セクションでとして示されます。

### <a name="title-id-or-scid-not-configured-correctly"></a>タイトル ID または SCID が正しく構成されていない

* UWP タイトルの場合、xboxservices.config ファイルでタイトル ID と SCID に正しい値を設定する必要があります。  また、このファイルが UTF8 で正しくエンコードされていることを確認します。  詳しくは、「[UWP ゲーム用 Visual Studio の概要](../../get-started-with-partner/get-started-with-visual-studio-and-uwp.md)」をご覧ください。 xboxservices.config ファイルでは、大文字と小文字が区別されます。
* XDK タイトルの場合は、これらの値は package.appxmanifest で設定します。
* UWP および XDK タイトルの構成の例は、Xbox Live SDK の Samples ディレクトリにあります。

## <a name="test-using-the-xbox-app"></a>Xbox アプリを使用したテスト

UWP アプリケーションを開発している場合、Xbox アプリを使用して一部の問題をデバッグできます。

1. SwitchSandbox.cmd スクリプトを使用して、デバイスのサンドボックスを開発サンドボックスに設定します。
2. Xbox アプリを開き、同じサンドボックスへのアクセス権があるテスト アカウントを使用してサインインを試みます。

正常にサインインできる場合は、デバイスで開発サンドボックスが正しく設定されいて、テスト アカウントにアクセス権があることが検証されたことを示します。

まだサインイン エラーが発生する場合は、サービス構成がサンドボックスに発行されていない、または xboxservices.config が正しくセットアップされていない可能性があります。 xboxservices.config ファイルでは、大文字と小文字が区別されます。

## <a name="debug-based-on-error-code"></a>エラー コードに基づくデバッグ

サインイン時に発生する可能性があるエラー コードの一部と、そのデバッグ手順を以下に示します。  エラー コードは次のスクリーンショットのように表示されます。

![0x8015DC12 サインイン エラーのスクリーンショット](../../images/troubleshooting/sign_in_error.png)

### <a name="0x80860003-the-application-is-either-disabled-or-incorrectly-configured"></a>0x80860003 アプリケーションが無効になっている、または正しく構成されていない

1. PFX ファイルを削除してみます。

![ソリューション エクスプローラーに表示された pfx ファイル](../../images/troubleshooting/pfx_file.png)

Visual Studio は自動的になっている場合、サインインしなかったパートナー センターでアプリのプロビジョニングに使用した Microsoft アカウントで Visual Studio に、個人の Microsoft アカウントまたはドメイン アカウントに基づいて署名 pfx ファイルを生成します。 appx パッケージをビルドするとき、Visual Studio はその自動生成 pfx を使用してパッケージに署名し、package.appxmanifest でパッケージ ID の "publisher" 部分を変更します。 その結果、生成されるビット (具体的には appxmanifest.xml) のパッケージ ID は意図したものと異なります。 

2. パートナー センターで、package.appxmanifest がタイトルと同じアプリケーション id に設定されていることを再確認してください。 次のスクリーンショットで示すように、プロジェクトを右クリックして [ストア]、[アプリケーションをストアと関連付ける...] の順に選択します。 または、package.appxmanifest を手動で編集します。 「[UWP ゲーム用 Visual Studio の概要](../../get-started-with-partner/get-started-with-visual-studio-and-uwp.md)」をご覧ください。

![Microsoft Store に関連付ける](../../images/troubleshooting/appxmanifest_binding.png)

### <a name="0x8015dc12-content-isolation-error"></a>0x8015DC12 コンテンツ分離エラー

このエラーは、デバイスまたはユーザーに指定されたタイトルへのアクセス権がないことを意味します。

1. テスト アカウントを使用してサインインしていない、またはサインインに使用したサンドボックスへのアクセス権がテスト アカウントにない可能性があります。 Please [XDP のドキュメント](https://developer.xboxlive.com/en-us/xdphelp/development/xdpdocs/Pages/creating_development_accounts_03_31_16.aspx)でテスト アカウントを作成する方法を再確認し、[パートナー センターのドキュメント](../../xbox-live-test-accounts.md)。 必要な場合は、適切なサンド ボックスへのアクセス権を持つ新しいテスト アカウントを作成します。

Windows 10 から古いアカウントを削除することが必要な場合があります。[スタート] メニューから [設定]、[アカウント] の順に選択して削除できます。

2. 使おうとしているサンドボックスに対してタイトルが発行されていることを再確認します。 これを行う方法については、 [XDP のドキュメント](https://developer.xboxlive.com/en-us/xdphelp/development/xdpdocs/Pages/setting_up_service_configuration_03_31_16.aspx#PublishServiceConfig)や[パートナー センターのドキュメント](../../xbox-live-service-configuration.md#sandbox-ids)を参照してください。

### <a name="0x87dd0005-unexpected-or-unknown-title"></a>0x87DD0005 予期しないタイトルまたは不明なタイトル

XDP で [Application ID Setup] と [Dev Center Binding] を再確認します。 方法については、「[Visual Studio の新規または既存の UWP プロジェクトに Xbox Live のサポートを追加する方法](https://docs.microsoft.com/windows-hardware/drivers/devapps/step-1--create-a-uwp-device-app#span-idassociateyourappwiththewindowsstorespanspan-idassociateyourappwiththewindowsstorespanspan-idassociateyourappwiththewindowsstorespanassociate-your-app-with-the-microsoft-store)」を参照してください。

### <a name="0x87dd000e-title-not-authorized"></a>0x87DD000E タイトルが承認されていない

デバイスが適切な開発サンドボックスに設定されていること、およびそのサンドボックスに対するアクセス権をユーザーが持っていることを確認します。 Xbox アプリでこれらを確認する方法の詳細については、「[Xbox アプリを使用したテスト](#test-xbox-app)」セクションを参照してください。

それでも問題が解決しない場合は、前に説明したようにデベロッパー センターのバインディングとアプリ ID の設定も確認してください。

ここで説明されていないエラーが発生する場合は、xbox::services::xbox_live_error_code ドキュメントのエラー一覧でエラー コードの詳細を参照してください。 XSAPI に含まれる errors.h も参照してください。

以上の手順を実行してもタイトルにサインインできない場合は、[フォーラム](http://forums.xboxlive.com)でサポート スレッドを投稿するか、担当の DAM に問い合わせてください。