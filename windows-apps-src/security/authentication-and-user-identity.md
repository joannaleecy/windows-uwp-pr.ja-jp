---
title: 認証とユーザー ID
description: ユニバーサル Windows プラットフォーム (UWP) のアプリには、Web 認証ブローカーを使う簡単なシングル サインオン (SSO) から、高度なセキュリティで保護された 2 要素認証に至るまで、ユーザー認証用にいくつかのオプションがあります。
ms.assetid: 53E36DDC-200A-4850-AAF0-07ECA3662BB9
author: PatrickFarley
ms.author: pafarley
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10、uwp、セキュリティ
ms.localizationpriority: medium
ms.openlocfilehash: 6f446299dcf1a0bcf93d483d13c926c6e4cd230f
ms.sourcegitcommit: 9a17266f208ec415fc718e5254d5b4c08835150c
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/28/2018
ms.locfileid: "2881725"
---
# <a name="authentication-and-user-identity"></a>認証とユーザー ID



ユニバーサル Windows プラットフォーム (UWP) のアプリには、[Web 認証ブローカー](web-authentication-broker.md) を使う簡単なシングル サインオン (SSO) から、高度なセキュリティで保護された 2 要素認証に至るまで、ユーザー認証用にいくつかのオプションがあります。

Facebook、Twitter、Flickr などのサード パーティ ID プロバイダーのサービスへの定期的なアプリの接続には、[Web 認証ブローカー](web-authentication-broker.md) を使います。 より便利にするには、[資格情報保管ボックス](credential-locker.md) を使って、ユーザーのログイン情報を保存してローミングします。

Windows 10 をご使用の企業では、[Microsoft Passport と Windows Hello](microsoft-passport.md) の使用を考慮することを強くお勧めします。これにより、高度なセキュリティで保護された 2 要素認証が有効になります。 Microsoft Passport を使用できない場合は、[スマート カード](smart-cards.md)と[指紋生体認証](fingerprint-biometrics.md)でセキュリティ層を追加できます。

<table>
<tr><th>トピック</th><th>説明</th></tr>
<tr><td><a href="credential-locker.md">資格情報保管ボックス</a></td><td>この記事では、アプリで資格情報保管ボックスを使ってユーザーの資格情報を安全に保管し取得する方法、およびユーザーの Microsoft アカウントを使ってデバイス間でこれらの資格情報をローミングする方法について説明します。</td></tr>

<tr><td><a href="fingerprint-biometrics.md">指紋生体認証</a> </td><td>この記事では、アプリに指紋生体認証を追加する方法について説明します。 特定の操作に対してユーザーの同意を得る必要がある場合は、指紋認証の要求を含めると、アプリのセキュリティを高めることができます。 たとえば、アプリ内購入を承認する前や制限されたリソースにアクセスする前に指紋認証を要求できます。 指紋認証は、<a href="https://msdn.microsoft.com/library/windows/apps/hh701356">Windows.Security.Credentials.UI</a> 名前空間の <a href="https://msdn.microsoft.com/library/windows/apps/dn279134">UserConsentVerifier</a> クラスを使って管理されます。</td></tr>
<tr><td><a href="microsoft-passport.md">Microsoft Passport と Windows Hello</a></td><td>この記事では、新しい Windows 10 の Microsoft Passport テクノロジについて説明します。また、開発者がこのテクノロジを実装してアプリやバックエンド サービスを保護する方法についても説明します。 従来の資格情報の脅威を軽減するこれらのテクノロジの特定の機能に着目し、Windows10 ロールアウトに含まれるこれらのテクノロジの設計と展開の方法について説明します。 </td></tr>
<tr><td><a href="microsoft-passport-login.md">Microsoft Passport ログイン アプリの作成</a></td><td>従来のユーザー名とパスワードの認証システムの代わりに Microsoft Passport を使う Windows 10 UWP (ユニバーサル Windows プラットフォーム) アプリの作成方法に関する詳しいチュートリアルのパート 1 です。</td></tr>
<tr><td><a href="microsoft-passport-login-auth-service.md">Microsoft Passport ログイン サービスの作成</a></td><td>Windows 10 UWP (ユニバーサル Windows プラットフォーム) アプリで従来のユーザー名とパスワードの認証システムの代わりに Microsoft Passport を使う方法に関する詳しいチュートリアルのパート 2 です。</td></tr>
<tr><td><a href="smart-cards.md">スマート カード</a></td><td>このトピックでは、アプリでスマート カードを使ってユーザーをセキュリティで保護されたネットワーク サービスに接続する方法のほか、物理スマート カード リーダーにアクセスする方法、仮想スマート カードの作成方法、スマート カードとの通信方法、ユーザーの認証方法、ユーザーの PIN のリセット方法、スマート カードの取り外しや切断の方法などについて説明します。</td></tr>
<tr><td><a href="share-certificates.md">アプリ間での証明書の共有</a></td><td>ユーザー ID とパスワードの組み合わせよりも安全な認証を必要とする UWP アプリでは、証明書を認証に使うことができます。 証明書認証は、ユーザーの認証時に高レベルの信頼性を提供します。 場合によっては、複数のアプリから複数のサービスのグループに対してユーザーを認証することがあります。 この記事では、1 つの証明書を使って複数のアプリを認証する方法と、セキュリティで保護された Web サービスにアクセスするための証明書をユーザーがインポートできる便利なコードを記述する方法について説明します。</td></tr>
<tr><td><a href="companion-device-unlock.md">コンパニオン IoT デバイスを使った Windows のロック解除</a></td><td>コンパニオン デバイスは、ユーザー認証のエクスペリエンスを強化するために、Windows 10 のデスクトップと組み合わせて使用できるデバイスです。 コンパニオン デバイス フレームワークを使用すると、コンパニオン デバイスは、Windows Hello を利用できない場合 (たとえば、Windows 10 のデスクトップに顔認証のカメラまたは指紋リーダーのデバイスがない場合など) でも、Microsoft Passport のための優れたエクスペリエンスを提供できます。</td></tr>
<tr><td><a href="web-account-manager.md">Web アカウント マネージャー</a></td><td>この記事では、新しい Windows 10 Web アカウント マネージャー API を使って、AccountsSettingsPane を表示し、ユニバーサル Windows プラットフォーム (UWP) アプリを外部の ID プロバイダー (Microsoft、Facebook など) に接続する方法について説明します。 ユーザーの Microsoft アカウントを使用するためのユーザーの許可を求める方法、アクセス トークンを取得する方法、基本的な操作 (プロファイル データの取得や OneDrive へのファイルのアップロードなど) を実行する方法について説明します。 </td></tr>
<tr><td><a href="web-authentication-broker.md">Web 認証ブローカー</a></td><td>この記事では、OpenID や OAuth などの認証プロトコルを使うオンライン ID プロバイダー (Facebook、Twitter、Flickr、Instagram など) にアプリを接続する方法について説明します。 <a href="https://msdn.microsoft.com/library/windows/apps/br212066">AuthenticateAsync</a> メソッドは、要求をオンライン ID プロバイダーに送信し、アプリがアクセスできるプロバイダー リソースを表すアクセス トークンを返します。</td></tr>
</table>

