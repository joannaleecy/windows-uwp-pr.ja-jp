---
author: jnHs
Description: "アドオンを提出するとき、[プロパティ] ページのオプションは、ユーザーに提供される場合のアドオン動作を決めるのに役立ちます。"
title: "アドオン プロパティの入力"
ms.assetid: 26D2139F-66FD-479E-940B-7491238ADCAE
ms.author: wdg-dev-content
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
translationtype: Human Translation
ms.sourcegitcommit: c6b64cff1bbebc8ba69bc6e03d34b69f85e798fc
ms.openlocfilehash: 186088f249c2e6fe116c970bd1969fcb59863ba6
ms.lasthandoff: 02/07/2017

---

# <a name="enter-add-on-properties"></a>アドオン プロパティの入力


アドオンを提出するとき、**[プロパティ]** ページのオプションは、ユーザーに提供される場合のアドオン動作を決めるのに役立ちます。

## <a name="product-type"></a>製品の種類

最初に[アドオンを作成する](set-your-add-on-product-id.md)ときに、製品の種類を選びます。 ここには、選んだ製品の種類が表示されますが、変更することはできません。

> **注** アドオンを公開していない場合、 別の製品の種類を選ぶ必要があるなら、提出を削除して、もう一度開始できます。 

選択した製品の種類に応じて、次のいずれかのフィールドが表示されます。

### <a name="product-lifetime"></a>製品の有効期限
製品の種類として **[永続的]** を選んだ場合、**[製品の有効期限]** がここに表示されます。 永続的なアドオンの **[製品の有効期限]** の既定値は、**[無期限]** です。つまり、アドオンの期限は切れません。 必要に応じて、設定した期間の後でアドオンの期限が切れるように **[製品の有効期限]** を設定できます (1 から 365 日間のオプションがあります)。 

### <a name="quantity"></a>数量
製品の種類に **[ストアで管理されるコンシューマブル]** を選択した場合、**[数量]** がここに表示されます。 1 ~ 1000000 の範囲の数値を入力する必要があります。 顧客が対象アドオンを入手するときにこの数量が付与されます。顧客によるアドオンの消費がアプリによって報告されるたびに、ストアが残量を追跡します。

## <a name="content-type"></a>コンテンツ タイプ

アドオンの製品の種類に関係なく、提供するコンテンツの種類を指定する必要があります。 ほとんどのアドオンでは、コンテンツの種類は **[ソフトウェアのダウンロード]** になります。 一覧の別のオプションがアドオンの説明として適している場合 (たとえば、音楽のダウンロードや電子書籍を提供している場合) は、代わりにそのオプションを選びます。 

アドオンのコンテンツの種類として利用可能なオプションを次に示します。

-   ソフトウェアのダウンロード
-   電子書籍
-   電子雑誌 1 冊
-   電子新聞 1 部
-   ミュージックのダウンロード
-   ミュージックのストリーミング
-   オンライン データ ストレージ/サービス
-   ビデオのダウンロード
-   ビデオのストリーミング
-   SaaS

## <a name="keywords"></a>キーワード

提出するアドオンごとに、それぞれ 30 文字以内のキーワードを最大 10 個指定するオプションがあります。 そうすると、アプリはキーワードと一致するアドオンを照会できます。 この機能を利用すると、アプリのコードで製品 ID を直接指定しなくても、アドオンを読み込むことができる画面をアプリで構築できるようになります。 その場合、アプリでコードを変更したり、アプリをもう一度提出したりしなくても、いつでもアドオンのキーワードを変更することができます。

> **注** キーワードは、Windows 8 と Windows 8.1 を対象とするパッケージでは使うことができません。

## <a name="custom-developer-data"></a>カスタムの開発者データ

**[カスタムの開発者データ]** フィールド (以前は**タグ**と呼ばれていました) に最大 3,000 文字を入力して、アプリ内製品について追加のコンテキストを指定できます。 通常、これは XML 文字列の形式ですが、このフィールドには任意の内容を入力できます。

このフィールドを照会するには、[Windows.Services.Store 名前空間](https://msdn.microsoft.com/en-us/library/windows/apps/windows.services.store.aspx)の [StoreSku.CustomDeveloperData](https://msdn.microsoft.com/en-us/library/windows/apps/windows.services.store.storesku.customdeveloperdata.aspx) プロパティを使用します  (または、[Windows.ApplicationModel.Store 名前空間](https://msdn.microsoft.com/en-us/library/windows/apps/windows.applicationmodel.store.aspx)を使用している場合は、[ProductListing.Tag](https://msdn.microsoft.com/en-us/library/windows/apps/windows.applicationmodel.store.productlisting.tag.aspx) プロパティを使用します)。

たとえば、ゲームのアドオンとして金貨入りの袋を販売するとします。 **[カスタムの開発者データ]** フィールドを使うと、アプリはこの金貨入りの袋を照会できます。 値 (ここでは、袋に入っている金貨の数) は、アプリのコードを変更したり、アプリをもう一度提出したりしなくても、アドオンの **[カスタムの開発者データ]** フィールドで情報を更新していつでも調整できます。

> **注:** **[カスタムの開発者データ]** フィールドは、Windows 8 と Windows 8.1 を対象とするパッケージでは使うことができません。

 

 

 





