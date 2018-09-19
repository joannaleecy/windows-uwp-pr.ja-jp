---
title: Xbox Live SDK の新規事項 - August 2016
author: KevinAsgari
description: Xbox Live SDK の新規事項 - August 2016
ms.assetid: fa52e7bd-2c2c-4c25-94ab-761036a7ca79
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: xbox live, xbox, ゲーム, uwp, windows 10, xbox one
ms.localizationpriority: medium
ms.openlocfilehash: 892b04e780d25b07ac9ed12ff62f0f101761ce20
ms.sourcegitcommit: 68fcac3288d5698a13dbcbd57f51b30592f24860
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/19/2018
ms.locfileid: "4055743"
---
# <a name="whats-new-for-the-xbox-live-sdk---august-2016"></a>Xbox Live SDK の新規事項 - August 2016

June 2016 リリースで追加された内容については、「[新規事項 - June 2016](1606-whats-new.md)」を参照してください。

## <a name="os-and-tool-support"></a>OS とツールのサポート
Xbox Live SDK では、Windows 10 RTM [バージョン 10.0.10240] と Visual Studio 2015 RTM [バージョン 14.0.23107.0] がサポートされます。

## <a name="documentation"></a>ドキュメント
- UWP アプリケーションを作成していて、ゲームにユーザーを招待する機能を実装する場合は、「[マルチプレイヤー用に AppXManifest を構成する](../multiplayer/service-configuration/configure-your-appxmanifest-for-multiplayer.md)」に ```.appxmanifest``` で必要な変更についての説明があります。  これは、これまでに[フォーラム](https://forums.xboxlive.com)および記事「[ERA から UWP への Xbox Live コードの移植](../using-xbox-live/porting-xbox-live-code-from-xdk-to-uwp.md)」で解説されていたものです。
- 記事「[Social Manager の概要](../social-platform/intro-to-social-manager.md)」が更新され、最新の API の変更が反映されて、一部の関数のリターン コードの詳細が提供されるようになりました。

## <a name="unity-samples"></a>Unity のサンプル
UWP アプリケーションを作成する Unity デベロッパーのために、複数の新しいサンプルが追加されました。
- Social サンプルの Unity バージョンが Samples/Social/Unity ディレクトリにあります。
- また、接続ストレージの使用方法を説明するサンプルもあります。  サンプルについては、Samples/GameSave/Unity を参照してください。
AchievementsLeaderboard の Unity バージョンが Samples/AchievementsLeaderboard/Unity にあります。

## <a name="social-manager"></a>Social Manager
上で説明したドキュメントの更新に加えて、新しい API がいくつか追加されています。  以下ではそれについて説明します。詳細については social_manager.h を参照してください。

- 再作成しなくてもソーシャル グループを更新できる新しい API が追加されました。

```cpp
    _XSAPIIMP xbox_live_result<void> update_social_user_group(
        _In_ const std::shared_ptr<xbox_social_user_group>& group,
        _In_ const std::vector<string_t>& users
        );
```
- ソーシャル グループの更新の完了は、```social_user_group_updated``` イベントにより示されます。


## <a name="multiplayer"></a>マルチプレイヤー
セッションの参照が強化され、新しいマルチプレイヤー API を使用してそれを利用できます。

新しい API を使用すると、タグ、文字列、その他の多くのデータでフィルター処理を行うことができ、ユーザーはプレイしたいセッションをより簡単に検索できます。

数か月以内に詳細なドキュメントが公開されますが、簡単に説明しておくと、```set_search_handle``` を使用して "検索ハンドル" を MPSD セッションと関連付けることができるようになり、タイトルで呼び出すことでユーザーは堅牢なフィルタリング メカニズムを使用してセッションを検索できます。 ```get_search_handles```

新しい API は次のとおりです。  試してみて、問題がある場合は、[フォーラム](https://forums.xboxlive.com)でサポート スレッドを投稿するか、DAM に連絡してください。  これらの API の使用例を近日中に公開します。

```cpp
_XSAPIIMP pplx::task<xbox_live_result<void>> set_search_handle(
    _In_ multiplayer_search_handle_request searchHandleRequest
    );
```

```cpp
_XSAPIIMP pplx::task<xbox_live_result<std::vector<multiplayer_search_handle_details>>> get_search_handles(
    _In_ const string_t& serviceConfigurationId,
    _In_ const string_t& sessionTemplateName,
    _In_ const string_t& orderBy,
    _In_ bool orderAscending,
    _In_ const string_t& searchQuery
    );
```

```cpp
_XSAPIIMP pplx::task<xbox_live_result<void>> clear_search_handle(_In_ const string_t& handleId);
```

### <a name="xbox-integrated-multiplayer"></a>Xbox Integrated Multiplayer

Xbox Integrated Multiplayer (XIM) API のドキュメントが追加されました。  API 自体は Xbox Live SDK の今後のリリースで利用可能になりますが、ドキュメントとヘッダーはプレビュー用に利用できます。

XIM は、Xbox Live サービスの機能を使用してマルチプレイヤー リアルタイム ネットワークおよびチャット コミュニケーションをゲームに簡単に追加できる自己完結型のインターフェイスです。

ユーザーのフィードバックと問い合わせを促進するため、この API のプレビュー ドキュメントが提供されています。 Xfest 2016 では、前の手順では、この API を話しし、アーカイブされた[対象パートナー開発者サイトのプレゼンテーション資料](https://developer.xboxlive.com/en-us/platform/documentlibrary/events/Pages/Xfest2016.aspx)「ターン キー Multiplayer Networking and Chat」の説明を確認できます。 このプレビュー ドキュメントは C++ API 用だけであることに注意してください。 C# と同等の WinRT および他の言語については今年後半にリリースされます。

XIM の機能に関心がある場合、およびこのプロジェクトについてフィードバックまたは質問がある場合は、[Xbox デベロッパー フォーラム](https://forums.xboxlive.com/)に投稿するか、デベロッパー アカウント マネージャーにお問い合わせください。

この新しいドキュメントは、Xbox Live SDK の Docs ディレクトリの xbox_integrated_multiplayer.chm にあります。  プレビュー版のインクルード ファイルは、\include\xim\XboxIntegratedMultiplayer.h にあります。  
