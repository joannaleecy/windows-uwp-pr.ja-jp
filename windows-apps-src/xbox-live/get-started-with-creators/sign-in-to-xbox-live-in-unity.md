---
title: "Unity で Xbox Live にサインインする"
author: KevinAsgari
description: "Xbox Live プラグイン プレハブを使用して、Unity ゲームで Xbox Live アカウントにサインインする方法について説明します。"
ms.assetid: f5402d4c-894e-4879-969a-7e68699546c5
ms.author: kevinasg
ms.date: 04-04-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, クリエーター, サインイン"
ms.openlocfilehash: 8cfb9c7693c87fbd6df1766f9e16a1049f2c9320
ms.sourcegitcommit: a9e4be98688b3a6125fd5dd126190fcfcd764f95
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/21/2017
---
# <a name="sign-in-to-xbox-live-in-unity"></a>Unity で Xbox Live にサインインする

> **注:** 現在、実績とマルチプレイヤーがサポートされていないため、Xbox Live Unity プラグインは [Xbox Live クリエーターズ プログラム](../developer-program-overview.md)のメンバーに対してのみお勧めしています。

Xbox Live Unity プラグインを使用すると、Unity プロジェクトで Xbox Live に簡単にサインインできます。 付属のプレハブを使用したり、付属のスクリプトを独自のカスタム オブジェクトにアタッチしたりすることができます。

> **注:** このトピックでは、Xbox Live プラグインが Unity プロジェクトで既にセットアップされていることを前提としています。 その方法について詳しくは、「[Unity で Xbox Live を構成する](configure-xbox-live-in-unity.md)」をご覧ください。

## <a name="using-the-prefab"></a>プレハブの使用

**UserProfile** プレハブは最も重要な Xbox Live プレハブであり、**Xbox Live\Prefabs** にあります。 このプレハブにより、ユーザーは Xbox Live にログインでき、ユーザーのログイン後にはゲーマータグ、ゲーマーアイコン、およびゲーマースコアが表示されます。 通常、このプレハブは初期メニュー画面に表示するか、ゲームの起動時に自動的にトリガーされるようにします。 その他の Xbox Live プレハブを使用するには、UserProfile プレハブを含めるか、手動でサインイン API を呼び出す必要があります。 これを行う方法について詳しくは、**UserProfile.cs** スクリプトおよび以下のセクションをご覧ください。

シーンにプレハブをドラッグするだけで、設定はすべて完了します。

![&lt;ゲーマータグ&gt; &lt;ゲーマースコア&gt;](../images/unity/unity-userprofile-prefab.PNG)

Xbox Live プレハブを使用するには、少なくとも最初のシーンには、**XboxLiveServices** プレハブのインスタンスをドラッグする必要があります。 このプレハブでは、デバッグを目的として、Unity パッケージに含まれるさまざまなプレハブからのログ記録をオンまたはオフにすることができます。

再生モードになると、ボタン名が **[Sign In]** (サインイン) に変わります。

![サインイン](../images/unity/unity-sign-in.PNG)

ボタンをクリックすると、ユーザーのゲーマータグ、ゲーマーアイコン、およびゲーマースコアが表示されます。 エディターでは、これがプレースホルダー データになります。

![仮のユーザー 123456789](../images/unity/unity-game-fake-data.PNG)

実際の Xbox Live アカウントでログインするには、プロジェクトをビルドして Visual Studio から実行する必要があります。 詳しくは、「[Unity で Xbox Live を構成する](configure-xbox-live-in-unity.md)」をご覧ください。

## <a name="using-the-scripts"></a>スクリプトの使用

Xbox Live にサインインするときにプレハブで使用されるスクリプトは、**Xbox Live\Scripts\UserProfile.cs** です。 ここで注意すべき主なメソッドは、`SignInAsync` です。このメソッドにより `XboxLive.Instance.SignInAsync` が呼び出されます。

Unity のほとんどの Xbox Live 機能は、`XboxLive` スクリプト (**Xbox Live\Scripts\XboxLive.cs**) によって管理されます。  このオブジェクトは、Xbox Live 機能を使用するときにシーン内で自動的にインスタンス化され、`DontDestroyOnLoad` としてマークされることでゲームが動作している時間全体にわたって保持されます。

Xbox Live API を呼び出す必要があるスクリプトは、`XboxLive.Instance` のさまざまなプロパティを使用する必要があります。

* `Context` は、多くの Xbox Live サービスへのメイン エントリ ポイントを提供し、`SignInAsync` を使用してユーザーが認証された後に初期化されます。  詳しくは、[Xbox Live API のドキュメント](http://github.com/Microsoft/xbox-live-api-csharp)をご覧ください。

* `User` は、現在認証済みのユーザーへの参照を提供します。この参照は、さまざまなサービスを呼び出すときに使用できます。

ユーザーがサインインすると、そのユーザーに関する情報を取得することができます。 `UserProfile` の `LoadProfileInfo` メソッドをご覧になると、スクリプトによってユーザーの ID、ゲーマーアイコン、およびその他の情報がどのように取得されるかを確認できます。

## <a name="see-also"></a>関連項目

* [Unity で Xbox Live を構成する](configure-xbox-live-in-unity.md)
