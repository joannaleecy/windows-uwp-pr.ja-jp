---
author: v-angraf
title: Xbox Device Portal REST API
description: Xbox One の UWP に関する API リファレンスです。
ms.author: v-angraf
ms.date: 10/25/2017
ms.topic: article
keywords: windows 10, uwp
ms.assetid: 5ae8e953-0465-487b-81dd-54a85c904daf
ms.localizationpriority: medium
ms.openlocfilehash: 894bc6f657f4a65072056a14171bf86b92cced38
ms.sourcegitcommit: 93c0a60cf531c7d9fe7b00e7cf78df86906f9d6e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/21/2018
ms.locfileid: "7566222"
---
# <a name="xbox-device-portal-rest-api"></a>Xbox Device Portal REST API

このセクションには、コンソールの構成と管理をリモートから行うために使用する Xbox Device Portal REST API に関するリファレンス トピックが記載されています。

| URI        | 説明 |
|------------|-------------|
|[/api/app/packagemanager/register](wdp-loose-folder-register-api.md)| ルース フォルダーに含まれているアプリを登録します。 |
|[/api/app/packagemanager/upload](wdp-folder-upload.md)| フォルダー全体を本体にアップロードします。 |
|[/ext/app/sshpins](uwp-sshpins-api.md)| 信頼されたすべての SSH ピンをリモートでクリアします。 Visual Studio UWP 開発では、PIN のペアリングをもう一度行う必要があります。 |
|[/ext/app/deployinfo](uwp-deployinfo-api.md)| 1 つ以上のインストール パッケージの展開情報を要求します。 |
|[/ext/fiddler](wdp-fiddler-api.md)| Fiddler のネットワーク トレースを有効または無効にします。 |
|[/ext/httpmonitor/sessions](wdp-httpMonitor-api.md)| Xbox でフォーカスのあるアプリから HTTP トラフィックを取得します。 |
|[/ext/networkcredential](uwp-networkcredentials-api.md)| ネットワーク資格情報を追加、削除、または更新します。 |
|[/ext/remoteinput](uwp-remoteinput-api.md)| キーボード、マウス、コントローラーの入力を Xbox にリモートで送信します。 |
|[/ext/remoteinput/controllers](uwp-remoteinput-controllers-api.md)| 接続された物理コントローラーの数を取得するか、またはすべての物理コントローラーをオフにします。 |
|[/ext/screenshot](wdp-media-capture-api.md)| 現在本体に表示されている画面の PNG 画像をキャプチャします。 |
|[/ext/settings](wdp-xboxsettings-api.md)| Xbox One 開発者向け設定にアクセスします。 |
|[/ext/smb/developerfolder](wdp-smb-api.md)| 開発用 PC のエクスプローラーを使用して、本体上にある開発者向けフォルダーにアクセスします。 |
|[/ext/user](wdp-user-management.md)| Xbox One 本体のユーザーを管理します。 |
|[/ext/xbox/info](wdp-xboxinfo-api.md)| Xbox One デバイスに関する情報を提供します。 |
|[/ext/xboxlive/sandbox](wdp-sandbox-api.md)| Xbox Live サンド ボックスを管理します。 |

## <a name="see-also"></a>参照

- [Xbox One の UWP](index.md)
- [Windows デバイス ポータル](../debug-test-perf/device-portal.md)