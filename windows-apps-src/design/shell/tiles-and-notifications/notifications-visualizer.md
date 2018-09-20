---
author: andrewleader
Description: Notifications Visualizer is a new Universal Windows Platform (UWP) app in the Store that helps developers design adaptive live tiles for Windows 10.
title: Notifications Visualizer
ms.assetid: FCBB7BB1-2C79-484B-8FFC-26FE1934EC1C
template: detail.hbs
ms.author: mijacobs
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: af8b2489346e1ef81c5cae304802814b79b8b950
ms.sourcegitcommit: 4f6dc806229a8226894c55ceb6d6eab391ec8ab6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/20/2018
ms.locfileid: "4090556"
---
# <a name="notifications-visualizer"></a>Notifications Visualizer

 


Notifications Visualizer は、[Microsoft Store](https://www.microsoft.com/store/apps/notifications-visualizer/9nblggh5xsl1) の新しいユニバーサル Windows プラットフォーム (UWP) アプリで、Windows 10 のアダプティブ ライブ タイルと対話型トースト通知のデザインに役立ちます。


## <a name="overview"></a>概要

Notifications Visualizer では、Visual Studio の XAML エディター/デザイン ビューと同様、XML ペイロードを編集すると、タイルとトースト通知の視覚的なプレビューが即座に表示されます。 このアプリではエラーのチェックも行われます。これにより、有効なタイルまたはトースト通知のペイロードを作成できます。

次のアプリのスクリーンショットは、XML ペイロードと、選択したデバイス上で各サイズのタイルがどのように表示されるかを示しています。

![コードとタイルが示されている Notifications Visualizer アプリのエディター](images/notif-visualizer-001.png)

 

Notifications Visualizer を使うと、アプリ自体を編集、展開しなくても、アダプティブ タイルとトーストのペイロードを作成してテストすることができます。 適切な表示のペイロードが完成したら、そのペイロードをアプリに統合できます。 詳しくは、「[ローカル タイル通知の送信](sending-a-local-tile-notification.md)」および 「[ローカル トースト通知の送信](send-local-toast.md)」をご覧ください。

**注**   Notifications Visualizer では Windows のスタート メニューとトースト通知をシミュレートできますが、完全に正確なシミュレーションが常に行われるというわけではありません。また、このシミュレーションでは、一部の高度なペイロード プロパティがサポートされていません。 タイルやトーストを適切にデザインしたら、意図したとおりに表示されることを確認するために、タイルをスタート メニューにピン留めしたり、トーストを表示したりしてテストします。

 

## <a name="features"></a>機能

Notifications Visualizer にはさまざまなサンプル ペイロードが付属しており、アダプティブ ライブ タイルや対話型トーストの機能を実際に確認して、作成を開始する際の参考にすることができます。 さまざまなテキスト オプション、グループ/サブグループ、背景画像を試すことができます。また、さまざまなデバイスや画面にタイルがどのように対応するかを確認することもできます。 サンプルに変更を加えたら、今後利用するために、更新したペイロードをファイルに保存できます。

エディターでは、リアルタイムにエラーと警告が示されます。 たとえば、アプリのペイロードが 5 KB (プラットフォームの上限) より大きい場合、上限を超えていることを示す警告が Notifications Visualizer によって表示されます。 また誤った属性名や値に関する警告も示されるため、視覚的な問題のデバッグに役立ちます。

表示名、色、ロゴ、ShowName、バッジの値などのタイルのプロパティを制御することができます。 これらのオプションを使うと、タイルのプロパティとタイル通知のペイロードがどのように影響するのか、およびこれらのオプションによって生成される結果をすぐに理解できます。

次のアプリのスクリーンショットは、タイル エディターを示しています。

![タイルが示されている Notifications Visualizer のエディター](images/notif-visualizer-004.png)

 

## <a name="related-topics"></a>関連トピック

* [ストアでの Notifications Visualizer の入手](https://www.microsoft.com/store/apps/notifications-visualizer/9nblggh5xsl1)
* [アダプティブ タイルの作成](create-adaptive-tiles.md)
* [対話型トースト](adaptive-interactive-toasts.md)