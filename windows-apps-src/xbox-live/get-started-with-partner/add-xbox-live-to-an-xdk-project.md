---
title: XDK プロジェクトに Xbox Live を追加する
author: KevinAsgari
description: 新規または既存の Xbox 開発キット (XDK) プロジェクトに Xbox Live を追加する方法について説明します。
ms.assetid: fc6f987c-1a87-4ff5-b063-891591aa6653
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, XDK
ms.localizationpriority: medium
ms.openlocfilehash: 5563966c6f877bf02b5e58751173e6c425b25bfa
ms.sourcegitcommit: 4f6dc806229a8226894c55ceb6d6eab391ec8ab6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/20/2018
ms.locfileid: "4082746"
---
# <a name="add-xbox-live-to-a-new-or-existing-xdk-project"></a>新規または既存の XDK プロジェクトに Xbox Live を追加する

このトピックでは、新規または既存の XDK プロジェクトに Xbox Live を追加する方法について説明します。

手順は次のとおりです。

- Xbox One 開発環境をセットアップする
- ID を取得する
- 開発機本体を構成する
- タイトル ID と SCID をバイナリに追加する


## <a name="setup-up-your-xbox-one-development-environment"></a>Xbox One 開発環境をセットアップする
最初に、XDK ドキュメントの「Xbox One 開発環境のセットアップ」セクションに従って本体をセットアップします。

## <a name="get-your-ids"></a>ID を取得する

Xbox Live サービスを有効にするには、開発キットとタイトルを構成するためのいくつかの ID を取得する必要があります。 これらは同じプロセスで行うことができます。

ID を取得するには、「[Xbox Live サービス構成](../xbox-live-service-configuration.md)」の手順を実行します。

## <a name="configure-your-development-console"></a>開発機本体を構成する

ID を取得した後、「[開発本体を構成する](configure-your-development-console.md)」のガイドに従って開発本体をセットアップします。

## <a name="add-the-titleid-and-scid-to-your-binary"></a>タイトル ID と SCID をバイナリに追加する
サンドボックスは開発キットごとにプラットフォーム レベルで構成されますが、タイトル ID と SCID は特定のバイナリにバインドされます。 タイトル ID と SCID をバイナリに追加するには、次のように、<Extensions> ノードに新しいノードを追加して、そのバイナリの Package.appxmanifest を修正します。

```
<Applications>
    ...
    <Application ...>
      ...
      <Extensions>
        <mx:Extension Category="xbox.live">
           <mx:XboxLive TitleId="<your titleID>" PrimaryServiceConfigId="<your SCID>" RequireXboxLive="<boolean indicating Live requirement>" />
        </mx:Extension>
      </Extensions>
   </Application>
</Applications>
```

AppxManifest.xml ファイルについて詳しくは、Visual Studio で Xbox One 開発用のプロジェクト テンプレートを参照してください。

アプリケーション マニフェスト スキーマについては、「アプリケーション マニフェスト スキーマ」をご覧ください。

**RequireXboxLive フラグ** RequireXboxLive フラグが true に設定されている場合は、Windows.Networking.Connectivity 接続レベルが XboxLiveAccess として返され、タイトルが Xbox Live の認証に合格しない限り、タイトルは起動しません。 この認証により、タイトルが最新のコンテンツ アップデートを取得したことが保証されます。 タイトルの実行中に接続が失われた場合、タイトルは一時停止されます。

"インターネットが必要" なタイトルのみが RequireXboxLive を true としてマークする必要があります。ただし、この方法でタイトルをマークしても、タイトルに必要なサービスが起動して稼働中であることは保証されないので、ご注意ください。
