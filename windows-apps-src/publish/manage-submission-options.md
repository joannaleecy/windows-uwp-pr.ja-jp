---
author: jnHs
Description: Manage submission options such as publishing hold options, notes for certification, and more.
title: 申請オプションの管理
ms.author: wdg-dev-content
ms.date: 04/03/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, 公開の保留, 公開日, 申請を送信して公開
ms.localizationpriority: high
ms.openlocfilehash: 4f18a4cae88f78b16ea43856cc6166c67a228c2c
ms.sourcegitcommit: 9f059b37e45099b4314c96a0b604449e966d3c3c
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/04/2018
---
# <a name="manage-submission-options"></a>申請オプションの管理

アプリの申請プロセスの **[Submission options]** (申請オプション) ページでは、製品の適切なテストに役立ち詳しい情報を提供できます。 これは、オプションの手順ですが、多くの申請で推奨されます。 公開プロセスを遅らせたい場合は、必要に応じて公開の保留オプションを設定することもできます。


## <a name="publishing-hold-options"></a>公開の保留オプション

既定では、認定に合格するとすぐに (または、**[価格と使用可能状況]** ページの [[スケジュール]](configure-precise-release-scheduling.md) ページで指定した日付に) 申請が公開されます。 必要に応じて、特定の日付まで、または手動で公開を指定するまで、公開の申請を保留にすることを選ぶことができます。 ここでは、このセクションのオプションについて説明します。


### <a name="publish-your-submission-as-soon-as-it-passes-certification-or-per-dates-you-specify"></a>認定に合格したらすぐに (または指定した日付に) 申請を公開する

**[Publish this submission as soon as it passes certification (or per dates you selected in the Schedule section)]** (認定後すぐに (または [スケジュール] セクションで選択した日付に) この申請を公開) は既定でオンになっています。つまり、申請が認定に合格するとすぐに公開プロセスが始まることを意味します。ただし、**[価格と使用可能状況]** ページの [[スケジュール]](configure-precise-release-scheduling.md) セクションで日付を構成した場合を除きます。   

ほとんどの申請では、**[Publishing hold options]** (公開の保留オプション) セクションをこのオプションに設定したままにすることをお勧めします。 申請を公開する特定の日付を指定する場合、**[Publish this submission as soon as it passes certification (or per dates you selected in the Schedule section)]** (認定後すぐに (または [スケジュール] セクションで選択した日付に) この申請を公開) を使います。 このセクションを既定のオプションのままにすると、**[スケジュール]** セクションで設定した日付より前に申請が公開されることはありません。 **[スケジュール]** セクションで選択した日付は、ユーザーが Microsoft Store でアプリを利用できるようになる時期を決定するために使われます。


### <a name="publish-your-submission-manually"></a>手動で申請を公開する

まだリリース日を設定せず、手動で公開プロセスを開始するまで申請を非公開のままにする場合は、**[[今すぐ公開] を選ぶまで、この申請を公開しません]** を選択できます。 このオプションを選択した場合、開発者が指示するまで申請は公開されません。 アプリが認定に合格した後、認定のステータス ページで **[今すぐ公開]** を選択するか、以下に説明するのと同じ方法で特定の日付を選択すると、申請を公開することができます。


### <a name="start-publishing-your-submission-on-a-certain-date"></a>特定の日に申請の公開を開始する

申請が特定の日付まで公開されないようにするには、**[この申請の公開を開始する日付]** を選びます。 このオプションを選ぶと、申請は指定された日付の当日またはその日以降に、できるだけ早くリリースされます。 日付は 24 時間以上先の日付にする必要があります。 日付と同時に、申請を公開し始める時刻を指定することもできます。 

アプリの提出後にこのリリース日を変更することができます。ただし [公開] ステップに入る前に限ります。 
 
前述のように、申請が公開される特定の日付を指定する場合、**[Publish this submission as soon as it passes certification (or per dates you selected in the Schedule section)]** (認定後すぐに (または [スケジュール] セクションで選択した日付に) この申請を公開) を使い、**[Publishing hold options]** (公開の保留オプション) を既定の選択に設定したままにします。 **[この申請の公開を開始する日付]** オプションを使うと、その日まで公開プロセスが開始されませんが、認定や公開が遅れると実際のリリース日が選択した日付より後になる可能性があります。 


## <a name="notes-for-certification"></a>認定の注意書き

アプリの提出時に、**[認定の注意書き]** ページを使って、認定審査担当者に追加情報を提供することができます。 この情報は、アプリを正しく審査するために使用されます。 

詳しくは、「[認定の注意書き](notes-for-certification.md)」をご覧ください。

