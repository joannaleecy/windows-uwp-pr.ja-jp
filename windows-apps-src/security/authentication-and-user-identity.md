---
title: "認証とユーザー ID"
description: "ユニバーサル Windows プラットフォーム (UWP) のアプリには、Web 認証ブローカーを使う簡単なシングル サインオン (SSO) から、高度なセキュリティで保護された 2 要素認証に至るまで、ユーザー認証用にいくつかのオプションがあります。"
ms.assetid: 53E36DDC-200A-4850-AAF0-07ECA3662BB9
author: awkoren
translationtype: Human Translation
ms.sourcegitcommit: 3c890ac8d8363982d9f014c36b6cba59bee39f20
ms.openlocfilehash: e748b319cdeda82aadaf8516e41883a3e32dc10c

---

# 認証とユーザー ID


\[ Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132) をご覧ください\]

ユニバーサル Windows プラットフォーム (UWP) のアプリには、[Web 認証ブローカー](web-authentication-broker.md) を使う簡単なシングル サインオン (SSO) から、高度なセキュリティで保護された 2 要素認証に至るまで、ユーザー認証用にいくつかのオプションがあります。

Facebook、Twitter、Flickr などのサード パーティ ID プロバイダーのサービスへの定期的なアプリの接続には、[Web 認証ブローカー](web-authentication-broker.md) を使います。 より便利にするには、[資格情報保管ボックス](credential-locker.md) を使って、ユーザーのログイン情報を保存してローミングします。

Windows 10 をご使用の企業では、[Microsoft Passport と Windows Hello](microsoft-passport.md) の使用を考慮することを強くお勧めします。これにより、高度なセキュリティで保護された 2 要素認証が有効になります。 Microsoft Passport を使用できない場合は、[スマート カード](smart-cards.md)と[指紋生体認証](fingerprint-biometrics.md)でセキュリティ層を追加できます。

<table>
<tr><th>トピック</th><th>説明</th></tr>
<tr><td>[資格情報保管ボックス](credential-locker.md)</td><td>この記事では、アプリで資格情報保管ボックスを使ってユーザーの資格情報を安全に保管し取得する方法、およびユーザーの Microsoft アカウントを使ってデバイス間でこれらの資格情報をローミングする方法について説明します。</td></tr>

<tr><td>[指紋生体認証](fingerprint-biometrics.md) </td><td>この記事では、アプリに指紋生体認証を追加する方法について説明します。 特定の操作に対してユーザーの同意を得る必要がある場合は、指紋認証の要求を含めると、アプリのセキュリティを高めることができます。 たとえば、アプリ内購入を承認する前や制限されたリソースにアクセスする前に指紋認証を要求できます。 指紋認証は、[Windows.Security.Credentials.UI](https://msdn.microsoft.com/library/windows/apps/hh701356) 名前空間の [UserConsentVerifier](https://msdn.microsoft.com/library/windows/apps/dn279134) クラスを使って管理されます。</td></tr>
<tr><td>[Microsoft Passport と Windows Hello](microsoft-passport.md)</td><td>この記事では、新しい Windows 10 の Microsoft Passport テクノロジについて説明します。また、開発者がこのテクノロジを実装してアプリやバックエンド サービスを保護する方法についても説明します。 従来の資格情報の脅威を軽減するこれらのテクノロジの特定の機能に着目し、Windows 10 ロールアウトに含まれるこれらのテクノロジの設計と展開の方法について説明します。 </td></tr>
<tr><td>[Microsoft Passport ログイン アプリの作成](microsoft-passport-login.md)</td><td>従来のユーザー名とパスワードの認証システムの代わりに Microsoft Passport を使う Windows 10 UWP (ユニバーサル Windows プラットフォーム) アプリの作成方法に関する詳しいチュートリアルのパート 1 です。</td></tr>
<tr><td>[Microsoft Passport ログイン サービスの作成](microsoft-passport-login-auth-service.md)</td><td>Windows 10 UWP (ユニバーサル Windows プラットフォーム) アプリで従来のユーザー名とパスワードの認証システムの代わりに Microsoft Passport を使う方法に関する詳しいチュートリアルのパート 2 です。</td></tr>
<tr><td>[スマート カード](smart-cards.md)</td><td>このトピックでは、アプリでスマート カードを使ってユーザーをセキュリティで保護されたネットワーク サービスに接続する方法のほか、物理スマート カード リーダーにアクセスする方法、仮想スマート カードの作成方法、スマート カードとの通信方法、ユーザーの認証方法、ユーザーの PIN のリセット方法、スマート カードの取り外しや切断の方法などについて説明します。</td></tr>
<tr><td>[アプリ間での証明書の共有](share-certificates.md)</td><td>ユーザー ID とパスワードの組み合わせよりも安全な認証を必要とする UWP アプリでは、証明書を認証に使うことができます。 証明書認証は、ユーザーの認証時に高レベルの信頼性を提供します。 場合によっては、複数のアプリから複数のサービスのグループに対してユーザーを認証することがあります。 この記事では、1 つの証明書を使って複数のアプリを認証する方法と、セキュリティで保護された Web サービスにアクセスするための証明書をユーザーがインポートできる便利なコードを記述する方法について説明します。</td></tr>
<tr><td>[コンパニオン IoT デバイスを使った Windows のロック解除](companion-device-unlock.md)</td><td>コンパニオン デバイスは、ユーザー認証のエクスペリエンスを強化するために、Windows 10 のデスクトップと組み合わせて使用できるデバイスです。 コンパニオン デバイス フレームワークを使用すると、コンパニオン デバイスは、Windows Hello を利用できない場合 (たとえば、Windows 10 のデスクトップに顔認証のカメラまたは指紋リーダーのデバイスがない場合など) でも、Microsoft Passport のための優れたエクスペリエンスを提供できます。</td></tr>
<tr><td>[Web アカウント マネージャー](web-account-manager.md)</td><td>この記事では、新しい Windows 10 Web アカウント マネージャー API を使用して、AccountsSettingsPane を表示し、ユニバーサル Windows プラットフォーム (UWP) アプリを外部の ID プロバイダー (Microsoft、Facebook など) に接続する方法について説明します。 ユーザーの Microsoft アカウントを使用するためのユーザーの許可を求める方法、アクセス トークンを取得する方法、基本的な操作 (プロファイル データの取得や OneDrive へのファイルのアップロードなど) を実行する方法について説明します。 </td></tr>
<tr><td>[Web 認証ブローカー](web-authentication-broker.md)</td><td>この記事では、OpenID や OAuth などの認証プロトコルを使うオンライン ID プロバイダー (Facebook、Twitter、Flickr、Instagram など) にアプリを接続する方法について説明します。 [AuthenticateAsync](https://msdn.microsoft.com/library/windows/apps/br212066) メソッドは、要求をオンライン ID プロバイダーに送信し、アプリがアクセスできるプロバイダー リソースを表すアクセス トークンを返します。</td></tr>
</table>




<!--HONumber=Jun16_HO4-->


