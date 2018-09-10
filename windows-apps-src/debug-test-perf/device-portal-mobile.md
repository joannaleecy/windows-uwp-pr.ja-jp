---
author: PatrickFarley
ms.assetid: 5c34c78e-9ff7-477b-87f6-a31367cd3f8b
title: モバイル用 Device Portal
description: Windows Device Portal で、モバイル デバイスの構成と管理をリモートから行う方法について説明します。
ms.author: pafarley
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, デバイス ポータル
ms.localizationpriority: medium
ms.openlocfilehash: 0531cbefef509f7bc323829031b366bec3c798d8
ms.sourcegitcommit: f5cf806a595969ecbb018c3f7eea86c7a34940f6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/10/2018
ms.locfileid: "3824456"
---
# <a name="device-portal-for-mobile"></a>モバイル用 Device Portal

Windows 10 Version 1511 以降では、モバイル デバイス ファミリで追加の開発者向け機能が利用できるようになりました。 これらの機能は、デバイスで開発者モードが有効になっている場合にのみ利用可能です。

開発者モードを有効にする方法については、「[デバイスを開発用に有効にする](../get-started/enable-your-device-for-development.md)」をご覧ください。

![Device Portal の設定](images/device-portal/mob-dev-mode-options.png)

## <a name="set-up-device-portal-on-windows-phone"></a>Windows Phone で Device Portal をセットアップする

### <a name="turn-on-device-discovery-and-pairing"></a>デバイスの検出とペアリングを有効にする

Device Portal に接続するには、電話の設定でデバイスの検出と Device Portal を有効にする必要があります。 これにより、使用している電話と、PC または他の Windows 10 デバイスをペアリングできます。 デバイスは両方ともワイヤード (有線) またはワイヤレスでネットワークの同じサブネットに接続されているか、または 2 台のデバイスが USB で接続されている必要があります。

初めて Device Portal に接続すると、大文字と小文字が区別される 6 文字のセキュリティ コードを入力するように求められます。 これにより電話に確実にアクセスでき、攻撃を受ける心配もなくなります。 電話の [ペアリング] ボタンを押してコードを生成および表示し、その 6 文字をブラウザー内のテキスト ボックスに入力します。

![開発者モードのデバイス検出設定](images/device-portal/mob-dev-mode-pairing.png)

Device Portal に接続するには、USB、ローカル ホスト、ローカル ネットワーク (VPN やテザリングを含む) の 3 つの方法のいずれかを使うことができます。

**Device Portal に接続するには**

1. ブラウザーで、使っている接続の種類に応じて次のアドレスを入力します。

    - USB:  `http://127.0.0.1:10080`

    電話が USB で PC に接続されている場合は、このアドレスを使います。 両方のデバイスに、Windows 10 バージョン 1511 以降が必要です。
    
    - Localhost:  `http://127.0.0.1`

    このアドレスは、Windows 10 Mobile の Microsoft Edge で電話上の Device Portal をローカルで表示するときに使います。
    
    - Local Network:  `https://<The IP address or hostname of the phone>`

    このアドレスは、ローカル ネットワーク経由で接続するときに使います。

    電話の IP アドレスは、電話の Device Portal の設定に表示されます。 認証とセキュリティで保護された通信には HTTPS が必要です。 ホスト名 ([設定]、[システム]、[バージョン情報] で編集可能) は、ローカル ネットワーク上の Device Portal (たとえば http://Phone360) にアクセスするためにも使われます。これは、IP アドレスが頻繁に変わる可能性のあるデバイスや、共有する必要のあるデバイスを使っている場合に便利です。 

2. 電話の [ペアリング] ボタンを押して、必要なセキュリティ コードを生成して表示します。

3. ブラウザーの Device Portal のパスワード ボックスに、6 文字のセキュリティ コードを入力します。

4. (省略可能) ブラウザーで [Remember my computer] (このコンピューターを記憶する) ボックスをオンにして、今後も使用できるようにこのペアリングを記憶します。

Windows Phone の開発者設定ページの [Device Portal] セクションを次に示します。

![Device Portal の設定](images/device-portal/mob-dev-mode-portal.png)

テスト ラボなど、保護された環境で Device Portal を使っている場合、ローカル ネットワーク上のすべてのユーザーを信頼していて、デバイス上に個人情報が保存されておらず、固有の要件もない場合は、認証を無効にできます。 これにより、暗号化されていない通信が有効化され、電話の IP アドレスを持つすべてのユーザーが制御できるようになります。

## <a name="tool-notes"></a>ツールに関する注意事項

## <a name="device-portal-pages"></a>Device Portal のページ
### <a name="processes"></a>プロセス

Windows Mobile Device Portal には、任意のプロセスを強制終了する機能はありません。 

モバイル デバイスの Device Portal では、標準のページのセットが提供されます。 詳しい説明については、「[Windows Device Portal の概要](device-portal.md)」をご覧ください。

- アプリ マネージャー
- アプリのエクスプローラー (分離ストレージ エクスプローラー)
- プロセス
- パフォーマンスのグラフ
- Windows イベント トレーシング (ETW)
- パフォーマンス トレース (WPR) 
- デバイス
- ネットワーク

## <a name="see-also"></a>関連項目

* [Windows Device Portal の概要](device-portal.md)
* [デバイス ポータル コア API リファレンス](https://docs.microsoft.com/windows/uwp/debug-test-perf/device-portal-api-core)