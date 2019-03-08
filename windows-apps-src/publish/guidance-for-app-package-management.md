---
Description: アプリのパッケージをユーザーが使用できるようになるしくみと、特定のパッケージ シナリオを管理する方法について説明します。
title: アプリ パッケージ管理のガイダンス
ms.assetid: 55405D0B-5C1E-43C8-91A1-4BFDD336E6AB
ms.date: 10/31/2018
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 0548ae9f9b3b33808cd7420eb542bcbac6a1a431
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57607367"
---
# <a name="guidance-for-app-package-management"></a>アプリ パッケージ管理のガイダンス

アプリのパッケージをユーザーが使用できるようになるしくみと、特定のパッケージ シナリオを管理する方法について説明します。

-   [OS のバージョンとパッケージの配布](#os-versions-and-package-distribution)
-   [以前に発行アプリを Windows 10 用のパッケージを追加します。](#adding-packages-for-windows-10-to-a-previously-published-app)
-   [Windows Phone 8.1 用パッケージの互換性の維持](#maintaining-package-compatibility-for-windows-phone-81)
-   [ストアからアプリを削除します。](#removing-an-app-from-the-store)
-   [以前でサポートされているデバイス ファミリ用のパッケージを削除します。](#removing-packages-for-a-previously-supported-device-family)


## <a name="os-versions-and-package-distribution"></a>OS のバージョンとパッケージの配布

さまざまなオペレーティング システムで異なる種類のパッケージを実行できます。 ユーザーのデバイスで複数のパッケージを実行できる場合、Microsoft Store は使用可能な最適のパッケージを提供します。

一般に、新しい OS バージョンでは、同じデバイス ファミリの以前の OS バージョンを対象にしたパッケージを実行できます。 Windows 10 デバイスは、すべてサポートされている OS バージョン (デバイス ファミリ) ごとに実行できます。 Windows 10 デスクトップ デバイスは、Windows 8.1 または Windows 8 用にビルドしたアプリを実行できます。Windows 10 mobile デバイスは、Windows Phone 8.1、Windows Phone 8、およびでも Windows Phone 用にビルドしたアプリを実行できる 7.x。 ただし、アプリに適用可能なデバイス ファミリを対象とする UWP パッケージが含まれていない場合、Windows 10 でのお客様はそれらのパッケージを取得のみです。

> [!IMPORTANT]
> 2018 年 10 月 31 日の時点で、新しく作成された製品が Windows 8.x/Windows を対象とするパッケージを含めることはできません Phone 8.x 以前のバージョン。 詳細については、「この[ブログの投稿](https://blogs.windows.com/buildingapps/2018/08/20/important-dates-regarding-apps-with-windows-phone-8-x-and-earlier-and-windows-8-8-1-packages-submitted-to-microsoft-store/)します。


## <a name="removing-an-app-from-the-store"></a>アプリを Microsoft Store から削除する

ユーザーへのアプリの提供を停止し、事実上 "非公開" にする必要が生じることがあります。 これを行うには、**[アプリの概要]** ページで **[アプリの提供を停止する]** をクリックします。 アプリを入手不可にすることを確認すると、そのアプリは数時間以内に Store に表示されなくなり、([プロモーション コード](generate-promotional-codes.md)があり、Windows 10 デバイスを使用している場合を除き) 新しいユーザーがアプリを入手することはできなくなります。

> [!IMPORTANT]
> このオプションは、申請時に選択した[表示](choose-visibility-options.md#discoverability)設定よりも優先されます。 

このオプションは、申請を作成し、**[購入の停止]** オプションと同時に **[この製品を Microsoft Store で提供しますが、検索はできないようにします]** を選択した場合と同じ効果があります。 ただし、新しい申請を作成する必要はありません。

アプリを既に持っているユーザーは使用し続けることができ、もう一度アプリをダウンロードできることに注意してください (後で新しいパッケージを申請した場合には更新プログラムを入手することもできます)。

アプリを利用できないようにした後でもわかります、パートナー センターで。 アプリをもう一度ユーザーに提供する場合は、[アプリの概要] ページで **[アプリを提供する]** をクリックします。 確認後、数時間以内に新しいユーザーがアプリを入手できるようになります (前回の申請時の設定により制限されている場合を除く)。

> [!NOTE]
> アプリの提供は継続しながら、特定の OS バージョンで新しいユーザーへの提供を終了する場合は、新しい申請を作成して、新規の取得を許可しない OS バージョン用のパッケージをすべて削除できます。 たとえば、Windows Phone 8.1 および Windows 10 では、パッケージが以前アプリケーションを Windows Phone 8.1 で新規のお客様に提供を保持したくない場合は、すべての Windows Phone 8.1 パッケージから削除、送信します。 更新プログラムがパブリッシュされると、Windows Phone 8.1 で新規のお客様はされないことを既にお持ちのお客様を引き続き使用できますが、アプリを取得できません)。 ただし、アプリは Windows 10 の新しいお客様に利用できます。


## <a name="removing-packages-for-a-previously-supported-device-family"></a>これまでサポートされていたデバイス ファミリ用のパッケージを削除する

特定のすべてのパッケージを削除する場合[デバイス ファミリ](https://docs.microsoft.com/uwp/extension-sdks/device-families-overview)アプリ以前サポートされていることを求められますの変更を保存する前に、意図したものは、このことを確認する、**パッケージ**ページ。

すべてのアプリは以前はサポートされているデバイス ファミリで実行できるパッケージを削除するための送信を発行するときに、新規のお客様はそのデバイス ファミリでアプリを取得できません。 そのデバイス ファミリ向けのパッケージを提供するための別の更新プログラムは、後でいつでも公開することができます。

特定のデバイス ファミリをサポートするパッケージをすべて削除した場合でも、該当する種類のデバイスにアプリを既にインストールしているユーザーは、そのアプリを使うことができますが、後で提供される更新プログラムを入手することになります。


<a name="adding-packages-for-windows-10-to-a-previously-published-app"></a>

## <a name="adding-packages-for-windows10-to-a-previously-published-app"></a>以前に発行アプリを Windows 10 用のパッケージを追加します。

Windows 用のみのパッケージに含まれるストアにアプリがあるかどうか 8.x および Windows Phone 8.x、し、Windows 10 用のアプリを更新し、新しい提出パッケージを作成し、UWP .msixupload または .appxupload パッケージ中を追加する、[パッケージ](upload-app-packages.md)手順。 アプリが認定プロセスを通過した後は、UWP パッケージは Windows 10 でのお客様が新しい取得に使用可能なあります。

> [!NOTE]
> Windows 10 で、顧客が、UWP パッケージを取得すると、以前の OS バージョンのパッケージを使用するようにその顧客をロールすることはできません。 

Windows 10 パッケージのバージョン番号を使用した Windows 8、Windows 8.1、および Windows Phone 8.1 のパッケージの場合よりも高いでなければならないことに注意してください。 詳しくは、「[パッケージ バージョンの番号付け](package-version-numbering.md)」をご覧ください。

Microsoft Store 用の UWP アプリのパッケージ化について詳しくは、「[アプリのパッケージ化](../packaging/index.md)」をご覧ください。
