---
author: mijacobs
Description: "Notifications Visualizer は、ストアの新しいユニバーサル Windows プラットフォーム (UWP) アプリで、Windows 10 のアダプティブ ライブ タイルをデザインする際に役立ちます。"
title: Notifications Visualizer
ms.assetid: FCBB7BB1-2C79-484B-8FFC-26FE1934EC1C
label: TBD
template: detail.hbs
ms.author: mijacobs
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: 04e1a2e4c2bff8c7d7f75604e5665c3525f72174
ms.sourcegitcommit: 10d6736a0827fe813c3c6e8d26d67b20ff110f6c
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/22/2017
---
# <a name="notifications-visualizer"></a>Notifications Visualizer

<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css"> 


Notifications Visualizer は、[ストア](https://www.microsoft.com/store/apps/notifications-visualizer/9nblggh5xsl1)の新しいユニバーサル Windows プラットフォーム (UWP) アプリで、Windows 10 のアダプティブ ライブ タイルをデザインする際に役立ちます。

## <a name="overview"></a>概要


Notifications Visualizer アプリでは、Visual Studio の XAML エディター/デザイン ビューと同様に、タイルの編集時に視覚的なプレビューが即座に表示されます。 このアプリではエラーのチェックも行われます。これにより、有効なタイルのペイロードを作成できます。

次のアプリのスクリーンショットは、XML ペイロードと、各サイズのタイルが選んだデバイス上でどのように表示されるかを示しています。

![コードとタイルが示されている Notifications Visualizer アプリのエディター](images/notif-visualizer-001.png)

 

Notifications Visualizer を使うと、アプリ自体の編集や展開を行わなくても、アダプティブ タイルのペイロードを作成しテストすることができます。 目的に合った視覚効果を得ることができるようにペイロードを作成したら、そのペイロードをアプリに統合できます。 詳しくは、「[ローカル タイル通知の送信](tiles-and-notifications-sending-a-local-tile-notification.md)」をご覧ください。

**注**   Notifications Visualizer では Windows のスタート メニューをシミュレートできますが、完全に正確なシミュレーションが常に行われるというわけではありません。また、このシミュレーションでは、[baseUri](https://msdn.microsoft.com/library/windows/apps/br208712) などの一部のプロパティがサポートされていません。 タイルを目的に合うようにデザインしたら、意図したとおりに表示されることを確認するために、タイルを実際の [スタート] メニューにピン留めしてテストします。

 

## <a name="features"></a>機能


Notifications Visualizer にはさまざまなサンプル ペイロードが付属しており、アダプティブ ライブ タイルを使ってできることを確認できます。これらのサンプル ペイロードは作業を始める際に役立ちます。 さまざまなテキスト オプション、グループ/サブグループ、背景画像を試すことができます。また、さまざまなデバイスや画面にタイルがどのように対応するかを確認することもできます。 サンプルに変更を加えたら、今後利用するために、更新したペイロードをファイルに保存できます。

エディターでは、リアルタイムにエラーと警告が示されます。 たとえば、アプリのペイロードが 5 KB (プラットフォームの上限) 未満に制限されている場合、ペイロードがこの制限を超えると、Notifications Visualizer から警告が示されます。 Notifications Visualizer では誤った属性名や値に関する警告も示され、視覚的な問題をデバッグする際に役立ちます。

表示名、色、ロゴ、ShowName、バッジの値などのタイルのプロパティを制御することができます。 これらのオプションを使うと、タイルのプロパティとタイル通知のペイロードがどのように影響するのか、およびこれらのオプションによって生成される結果をすぐに理解できます。

次のアプリのスクリーンショットは、タイル エディターを示しています。

![タイルが示されている Notifications Visualizer のエディター](images/notif-visualizer-004.png)

 

## <a name="related-topics"></a>関連トピック


* [ストアでの Notifications Visualizer の入手](https://www.microsoft.com/store/apps/notifications-visualizer/9nblggh5xsl1)
* [アダプティブ タイルの作成](tiles-and-notifications-create-adaptive-tiles.md)
* [アダプティブ タイル テンプレート: スキーマとドキュメント](tiles-and-notifications-adaptive-tiles-schema.md)
* [Tiles and toasts (タイルとトースト) (MSDN ブログ)](http://blogs.msdn.com/b/tiles_and_toasts/)