---
author: jnHs
Description: Manage submission options such as publishing hold options, notes for certification, and more.
title: 申請オプションの管理
ms.author: wdg-dev-content
ms.date: 05/09/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, 公開の保留, 公開日, 申請を送信して公開, 制限付き機能の承認
ms.localizationpriority: medium
ms.openlocfilehash: 147f34c40cc5d2b612dcdd92edc0c76340cf58f7
ms.sourcegitcommit: c6d6f8b54253e79354f8db14e5cf3b113a3e5014
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/24/2018
ms.locfileid: "2843228"
---
# <a name="manage-submission-options"></a>申請オプションの管理

アプリの申請プロセスの **[Submission options]** (申請オプション) ページでは、製品の適切なテストに役立ち詳しい情報を提供できます。 これは、オプションの手順ですが、多くの申請で推奨されます。 公開プロセスを遅らせたい場合は、必要に応じて公開の保留オプションを設定することもできます。


## <a name="publishing-hold-options"></a>公開の保留オプション

既定では、認定に合格するとすぐに (または、**[価格と使用可能状況]** ページの [[スケジュール]](configure-precise-release-scheduling.md) ページで指定した日付に) 申請が公開されます。 必要に応じて、特定の日付まで、または手動で公開を指定するまで、公開の申請を保留にすることを選ぶことができます。 ここでは、このセクションのオプションについて説明します。 


### <a name="publish-your-submission-as-soon-as-it-passes-certification-or-per-dates-you-specify"></a>認定に合格したらすぐに (または指定した日付に) 申請を公開する

**[Publish this submission as soon as it passes certification (or per dates you selected in the Schedule section)]** (認定後すぐに (または [スケジュール] セクションで選択した日付に) この申請を公開) は既定でオンになっています。つまり、申請が認定に合格するとすぐに公開プロセスが始まることを意味します。ただし、**[価格と使用可能状況]** ページの [[スケジュール]](configure-precise-release-scheduling.md) セクションで日付を構成した場合を除きます。   

ほとんどの申請では、**[Publishing hold options]** (公開の保留オプション) セクションをこのオプションに設定したままにすることをお勧めします。 申請を公開する特定の日付を指定する場合、**[Publish this submission as soon as it passes certification (or per dates you selected in the Schedule section)]** (認定後すぐに (または [スケジュール] セクションで選択した日付に) この申請を公開) を使います。 このセクションを既定のオプションのままにすると、**[スケジュール]** セクションで設定した日付より前に申請が公開されることはありません。 [**スケジュール**] セクションで、選んだ日付をお使いの製品がストアの顧客に利用可能になったときに使用されます。


### <a name="publish-your-submission-manually"></a>手動で申請を公開する

まだリリース日を設定せず、手動で公開プロセスを開始するまで申請を非公開のままにする場合は、**[[今すぐ公開] を選ぶまで、この申請を公開しません]** を選択できます。 このオプションを選択した場合、開発者が指示するまで申請は公開されません。 送信パス証明書の後に証明書の状態] ページで、[**今すぐ発行**を選ぶか次のように、同じ方法で特定の日付を選択して公開できます。


### <a name="start-publishing-your-submission-on-a-certain-date"></a>特定の日に申請の公開を開始する

申請が特定の日付まで公開されないようにするには、**[この申請の公開を開始する日付]** を選びます。 このオプションを選ぶと、申請は指定された日付の当日またはその日以降に、できるだけ早くリリースされます。 日付は 24 時間以上先の日付にする必要があります。 日付と同時に、申請を公開し始める時刻を指定することもできます。 

まだ発行手順を入力していない限り、製品の送信後に、このリリース日を変更できます。 
 
前述のように、申請が公開される特定の日付を指定する場合、**[Publish this submission as soon as it passes certification (or per dates you selected in the Schedule section)]** (認定後すぐに (または [スケジュール] セクションで選択した日付に) この申請を公開) を使い、**[Publishing hold options]** (公開の保留オプション) を既定の選択に設定したままにします。 **[この申請の公開を開始する日付]** オプションを使うと、その日まで公開プロセスが開始されませんが、認定や公開が遅れると実際のリリース日が選択した日付より後になる可能性があります。 


## <a name="notes-for-certification"></a>認定の注意書き

アプリの提出時に、**[認定の注意書き]** セクションを使って、認定審査担当者に追加情報を提供することができます。 この情報は、アプリを正しく審査するために使用されます。 

詳しくは、「[認定の注意書き](notes-for-certification.md)」をご覧ください。


## <a name="restricted-capabilities"></a>制限付き機能

パッケージが[制限付き機能](../packaging/app-capability-declarations.md#restricted-capabilities)を宣言していることを検出した場合、承認を受け取るにはこのセクションで情報を提供する必要があります。 機能ごとに、アプリがその機能を宣言する必要がある理由とその使用方法をお聞かせください。 製品が機能を宣言する必要がある理由を理解できるように、必ずできる限り詳しく入力してください。 

認定プロセス中、テスターが提供された情報を確認し、その申請で機能の使用を承認するかどうかを判断します。 これにより、申請が認定プロセスを完了するまでの時間がいくらか長くなる可能性があります。 機能の使用が承認された場合、アプリの認定プロセスの残りの部分が続行されます。 一般に、アプリの更新プログラムを申請するときに機能の承認プロセスを繰り返す必要はありません (追加の機能を宣言する場合を除く)。 

機能の使用が承認されない場合、申請は認定に失敗し、認定レポートでフィードバックが提供されます。 その後、新しい申請を作成して機能を宣言しないパッケージをアップロードすることを選択できます。または、該当する場合は、機能の使用に関連する問題を解決し、新しい申請で承認をリクエストします。

めったに承認されない制限付き機能があることに注意してください。 各制限付き機能について詳しくは、「[アプリ機能の宣言](../packaging/app-capability-declarations.md#restricted-capabilities)」をご覧ください。

