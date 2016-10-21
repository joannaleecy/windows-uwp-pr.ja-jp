---
author: mcleanbyron
ms.assetid: 37F2C162-4910-4336-BEED-8536C88DCA65
description: "Windows デベロッパー センター アカウントに登録するアプリのパッケージ フライトを管理するには、以下の Windows ストア申請 API のメソッドを使います。"
title: "Windows ストア申請 API を使用したパッケージ フライトの管理"
translationtype: Human Translation
ms.sourcegitcommit: 5f975d0a99539292e1ce91ca09dbd5fac11c4a49
ms.openlocfilehash: de1c23d721cee67d813520e3a23eb553cd90b7e9

---

# Windows ストア申請 API を使用したパッケージ フライトの管理




Windows デベロッパー センター アカウントに登録するアプリのパッケージ フライトを管理するには、以下の Windows ストア申請 API のメソッドを使います。 Windows ストア申請 API の概要については、「[Windows ストア サービスを使用した申請の作成と管理](create-and-manage-submissions-using-windows-store-services.md)」をご覧ください。この API を使用するための前提条件などの情報があります。

>**注:**&nbsp;&nbsp;これらのメソッドは、Windows ストア申請 API を使用するアクセス許可が付与された Windows デベロッパー センター アカウントにのみ使用できます。 すべてのアカウントでこのアクセス許可が有効になっているとは限りません。 以下のメソッドは、パッケージ フライトの取得、作成、または削除にしか使用できません。 パッケージ フライトの申請を作成するには、「[パッケージ フライトの申請の管理](manage-flight-submissions.md)」のメソッドをご覧ください。

| メソッド        | URI    | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| GET | ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}``` | Windows デベロッパー センター アカウントに登録するアプリのパッケージ フライトのデータを取得します。 詳しくは、「[パッケージ フライトの取得](get-a-flight.md)」をご覧ください。 |
| POST | ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights``` | 新しいパッケージ フライトを作成します。 詳しくは、「[パッケージ フライトの作成](create-a-flight.md)」をご覧ください。|
| DELETE | ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}``` | パッケージ フライトを削除します。 詳しくは、「[パッケージ フライトの削除](delete-a-flight.md)」をご覧ください。 |


## 前提条件

Windows ストア申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)がまだ満たされていない場合は、ここに記載されているメソッドを使用する前に前提条件を整えてください。

## 関連トピック

* [Windows ストア サービスを使用した申請の作成と管理](create-and-manage-submissions-using-windows-store-services.md)
* [パッケージ フライトの申請の管理](manage-flight-submissions.md)



<!--HONumber=Aug16_HO5-->


