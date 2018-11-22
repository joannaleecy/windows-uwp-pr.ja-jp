---
author: Xansky
ms.assetid: 32572890-26E3-4FBB-985B-47D61FF7F387
description: Windows 10 バージョン 1607 より前のリリースを対象とする UWP アプリでのアプリ内購入と試用版を有効にする方法を説明します。
title: Windows.ApplicationModel.Store 名前空間を使用するアプリ内購入と試用版
ms.author: mhopkins
ms.date: 08/25/2017
ms.topic: article
keywords: UWP, アプリ内購入, IAP, アドオン, 試用版, Windows.ApplicationModel.Store
ms.localizationpriority: medium
ms.openlocfilehash: 28fe27cc4464598414fec11d6812e2e9ea377aff
ms.sourcegitcommit: 93c0a60cf531c7d9fe7b00e7cf78df86906f9d6e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/22/2018
ms.locfileid: "7581992"
---
# <a name="in-app-purchases-and-trials-using-the-windowsapplicationmodelstore-namespace"></a>Windows.ApplicationModel.Store 名前空間を使用するアプリ内購入と試用版

[Windows.ApplicationModel.Store](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.store.aspx) 名前空間のメンバーを使って、ユニバーサル Windows プラットフォーム (UWP) アプリにアプリ内購入機能や試用版機能を追加し、アプリの収益化に役立てることができます。 このような API では、アプリのライセンス情報にもアクセスできます。

このセクションの記事では、いくつかの一般的なシナリオにおいて **Windows.ApplicationModel.Store** 名前空間のメンバーを使用するための詳しいガイダンスとコード例を示します。 UWP アプリのアプリ内での購入に関する基本概念の概要については、「[アプリ内購入と試用版](in-app-purchases-and-trials.md)」をご覧ください。 **Windows.ApplicationModel.Store** 名前空間を使用した試用版とアプリ内購入の実装方法を示す完全なサンプルについては、[ストア サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/win10-1507/Samples/Store)をご覧ください。

> [!IMPORTANT]
> **Windows.ApplicationModel.Store** 名前空間は今後更新されず、新機能も追加されません。 Visual Studio でプロジェクトのターゲットを **Windows 10 Anniversary Edition (10.0、ビルド 14393)** 以降のリリースに設定している (つまり、Windows 10 Version 1607 以降をターゲットとしている) 場合は、代わりに [Windows.Services.Store](https://msdn.microsoft.com/library/windows/apps/windows.services.store.aspx) 名前空間を使うことをお勧めします。 詳しくは、「[アプリ内購入と試用版](https://msdn.microsoft.com/windows/uwp/monetize/in-app-purchases-and-trials)」をご覧ください。 **Windows.ApplicationModel.Store**名前空間は、[デスクトップ ブリッジ](https://developer.microsoft.com/windows/bridges/desktop)を使用する Windows デスクトップ アプリケーションで、またはアプリやパートナー センターで開発サンド ボックスを使用するゲームでサポートされていません (たとえば、このような場合にゲームのいずれかのXbox Live と統合)。 このような製品では、**Windows.Services.Store** 名前空間を使ってアプリ内購入と試用版を実装する必要があります。

## <a name="get-started-with-the-currentapp-and-currentappsimulator-classes"></a>CurrentApp クラスと CurrentAppSimulator クラスの概要

**Windows.ApplicationModel.Store** 名前空間へのメイン エントリ ポイントは、[CurrentApp](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.store.currentapp.aspx) クラスです。 このクラスには、現在のアプリとその利用可能なアドオンに関する情報の取得、現在のアプリまたはそのアドオンに関するライセンス情報の取得、現在のユーザー向けのアプリまたはアドオンの購入、およびその他のタスクを行う際に使用できる静的プロパティおよびメソッドが用意されています。

[CurrentApp](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.store.currentapp.aspx) クラスは Microsoft Store からデータを取得するため、アプリ内でこのクラスを使うには、開発者が開発者アカウントを持っていて、アプリが Microsoft Store で公開されている必要があります。 アプリをまだ Microsoft Store に提出していない場合は、このクラスのシミュレートされたバージョンである [CurrentAppSimulator](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.store.currentappsimulator.aspx) を使ってコードをテストすることができます。 アプリのテストが完了したら、Microsoft Store に提出する前に **CurrentAppSimulator** のインスタンスを **CurrentApp** に置き換える必要があります。 アプリで **CurrentAppSimulator** が使用されている場合は、認定が不合格になります。

**CurrentAppSimulator** を使う場合、アプリのライセンスとアプリ内製品の初期状態は、開発コンピューター上にある WindowsStoreProxy.xml という名前のローカル ファイルに記述されています。 このファイルについて詳しくは、「[CurrentAppSimulator での WindowsStoreProxy.xml ファイルの使用](#proxy)」をご覧ください。

**CurrentApp** と **CurrentAppSimulator** を使って実行できる一般的なタスクについて詳しくは、次の記事をご覧ください。

| トピック       | 説明                 |
|----------------------------|-----------------------------|
| [試用版での機能の除外または制限](exclude-or-limit-features-in-a-trial-version-of-your-app.md) | ユーザーがアプリを無料で使うことができる試用期間を設け、その期間中は一部の機能を除外または制限することで、アプリを通常版にアップグレードするようユーザーに促すことができます。 |
| [アプリ内製品購入の有効化](enable-in-app-product-purchases.md)      |  アプリが無料であるかどうかにかかわらず、コンテンツ、その他のアプリ、アプリの新機能 (ゲームの次のレベルのロック解除など) をアプリ内から直接販売できます。 ここでは、アプリ内で製品を販売できるようにする方法について説明します。  |
| [コンシューマブルなアプリ内製品購入の有効化](enable-consumable-in-app-product-purchases.md)      | ストアの商取引プラットフォームを使ってコンシューマブルなアプリ内製品 (購入、使用、再購入が可能なアイテム) をサポートすると、堅牢かつ信頼性の高いアプリ内購入エクスペリエンスを顧客に提供できます。 これは、購入して、特定のパワーアップを購入するために使うことができるゲーム内通貨 (ゴールド、コインなど) 用に特に便利です。 |
| [アプリ内製品の大規模なカタログの管理](manage-a-large-catalog-of-in-app-products.md)      |   アプリ内製品のカタログが大きくなる場合、カタログを管理するためにこのトピックで説明するプロセスを採用できます。    |
| [受領通知を使った製品購入の確認](use-receipts-to-verify-product-purchases.md)      |   製品購入が成功した各 Microsoft Store トランザクションでは、必要に応じてトランザクションの通知を返し、掲載製品と料金についての情報をユーザーに提供できます。 この情報は、ユーザーがアプリを購入したことや、Microsoft Store からアプリ内製品の購入が行われたことをアプリで確認する必要がある場合に役立ちます。 |

<span id="proxy" />

## <a name="using-the-windowsstoreproxyxml-file-with-currentappsimulator"></a>CurrentAppSimulator での WindowsStoreProxy.xml ファイルの使用

**CurrentAppSimulator** を使う場合、アプリのライセンスとアプリ内製品の初期状態は、開発コンピューター上にある WindowsStoreProxy.xml という名前のローカル ファイルに記述されています。 **CurrentAppSimulator** メソッドは、ライセンスの購入やアプリ内での購入処理などに応じてアプリの状態を変更しますが、更新されるのはメモリ内の **CurrentAppSimulator** オブジェクトの状態のみです。 WindowsStoreProxy.xml の内容は変更されません。 アプリを再起動すると、ライセンスの状態は、WindowsStoreProxy.xml に記述されている内容に戻ります。

WindowsStoreProxy.xml ファイルは、既定で %UserProfile%\AppData\Local\Packages\\&lt;Local\Packages&gt;\LocalState\Microsoft\Windows Store\ApiData に作成されます。 このファイルを編集して、シミュレートするシナリオを **CurrentAppSimulator** プロパティで定義できます。

このファイルの値を変更することは可能ですが、直接変更するのではなく、独自の WindowsStoreProxy.xml ファイルを (Visual Studio プロジェクトのデータ フォルダーに) 作成し、**CurrentAppSimulator** で使うことをお勧めします。 トランザクションをシミュレートするには、[ReloadSimulatorAsync](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.currentappsimulator.reloadsimulatorasync) を呼び出して、作成したファイルを読み込みます。 **ReloadSimulatorAsync** を呼び出して独自の WindowsStoreProxy.xml ファイルを読み込まない場合、**CurrentAppSimulator** は既定の WindowsStoreProxy.xml ファイルを作成して読み込みます (上書きはしません)。

> [!NOTE]
> **CurrentAppSimulator** は、**ReloadSimulatorAsync** が完了するまで完全には初期化されません。 **ReloadSimulatorAsync** は非同期メソッドであるため、1 つのスレッドで **CurrentAppSimulator** が照会されているときに、別のスレッドでそれが初期化されているといった競合状態が起こらないように注意する必要があります。 これにはフラグを使って初期化の完了を示すのも 1 つの方法です。 Microsoft Store からインストールされるアプリでは、**CurrentAppSimulator** ではなく **CurrentApp** を使う必要があります。これにより、**ReloadSimulatorAsync** が呼び出されなくなり、そのような競合状態は発生しなくなります。 このため、コードは同期と非同期の両方で動作するように設計する必要があります。


<span id="proxy-examples" />

### <a name="examples"></a>例

以下の例では、試用モードのアプリを記述する WindowsStoreProxy.xml ファイル (UTF-16 エンコード) を示します。このアプリは、2015 年 1 月 19 日午前 5 時 (UTC) に試用モードの有効期限が切れます。

> [!div class="tabbedCodeSnippets"]
```xml
<?xml version="1.0" encoding="UTF-16"?>
<CurrentApp>
  <ListingInformation>
    <App>
      <AppId>2B14D306-D8F8-4066-A45B-0FB3464C67F2</AppId>
      <LinkUri>http://apps.windows.microsoft.com/app/2B14D306-D8F8-4066-A45B-0FB3464C67F2</LinkUri>
      <CurrentMarket>en-US</CurrentMarket>
      <AgeRating>3</AgeRating>
      <MarketData xml:lang="en-us">
        <Name>App with a trial license</Name>
        <Description>Sample app for demonstrating trial license management</Description>
        <Price>4.99</Price>
        <CurrencySymbol>$</CurrencySymbol>
      </MarketData>
    </App>
  </ListingInformation>
  <LicenseInformation>
    <App>
      <IsActive>true</IsActive>
      <IsTrial>true</IsTrial>
      <ExpirationDate>2015-01-19T05:00:00.00Z</ExpirationDate>
    </App>
  </LicenseInformation>
  <Simulation SimulationMode="Automatic">
    <DefaultResponse MethodName="LoadListingInformationAsync_GetResult" HResult="E_FAIL"/>
  </Simulation>
</CurrentApp>
```

次の例では、購入済みのアプリを記述する WindowsStoreProxy.xml ファイル (UTF-16 エンコード) を示します。このアプリには、2015 年 1 月 19 日午前 5 時 (UTC) に有効期限が切れる機能と、コンシューマブルなアプリ内での購入があります。

> [!div class="tabbedCodeSnippets"]
```xml
<?xml version="1.0" encoding="utf-16" ?>
<CurrentApp>
  <ListingInformation>
    <App>
      <AppId>988b90e4-5d4d-4dea-99d0-e423e414ffbc</AppId>
      <LinkUri>http://apps.windows.microsoft.com/app/988b90e4-5d4d-4dea-99d0-e423e414ffbc</LinkUri>
      <CurrentMarket>en-us</CurrentMarket>
      <AgeRating>3</AgeRating>
      <MarketData xml:lang="en-us">
        <Name>App with several in-app products</Name>
        <Description>Sample app for demonstrating an expiring in-app product and a consumable in-app product</Description>
        <Price>5.99</Price>
        <CurrencySymbol>$</CurrencySymbol>
      </MarketData>
    </App>
    <Product ProductId="feature1" LicenseDuration="10" ProductType="Durable">
      <MarketData xml:lang="en-us">
        <Name>Expiring Item</Name>
        <Price>1.99</Price>
        <CurrencySymbol>$</CurrencySymbol>
      </MarketData>
    </Product>
    <Product ProductId="consumable1" LicenseDuration="0" ProductType="Consumable">
      <MarketData xml:lang="en-us">
        <Name>Consumable Item</Name>
        <Price>2.99</Price>
        <CurrencySymbol>$</CurrencySymbol>
      </MarketData>
    </Product>
  </ListingInformation>
  <LicenseInformation>
    <App>
      <IsActive>true</IsActive>
      <IsTrial>false</IsTrial>
    </App>
    <Product ProductId="feature1">
      <IsActive>true</IsActive>
      <ExpirationDate>2015-01-19T00:00:00.00Z</ExpirationDate>
    </Product>
  </LicenseInformation>
  <ConsumableInformation>
    <Product ProductId="consumable1" TransactionId="00000001-0000-0000-0000-000000000000" Status="Active"/>
  </ConsumableInformation>
</CurrentApp>
```


<span id="proxy-schema" />

### <a name="schema"></a>スキーマ

このセクションでは、WindowsStoreProxy.xml ファイルの構造を定義する XSD ファイルを示します。 WindowsStoreProxy.xml ファイルで作業するときに、このスキーマを Visual Studio の XML エディターに適用するには、次の操作を行います。

1. Visual Studio で WindowsStoreProxy.xml ファイルを開きます。
2. **[XML]** メニューの **[スキーマの作成]** をクリックします。 XML ファイルの内容に基づいて、WindowsStoreProxy.xsd 一時ファイルが作成されます。
3. その .xsd ファイルの内容を下記のスキーマと置き換えます。
4. 複数のアプリ プロジェクトに適用できる場所に、作成したファイルを保存します。
5. Visual Studio で、この WindowsStoreProxy.xml ファイルに切り替えます。
6. **[XML]** メニューで **[スキーマ]** をクリックし、一覧から WindowsStoreProxy.xsd ファイルの行を探します。 ファイルの場所が適切でない場合 (たとえば、一時ファイルがまだ表示されている場合) は、**[追加]** をクリックします。 適切なファイルに移動し、**[OK]** をクリックします。 一覧にそのファイルが表示されます。 そのスキーマの **[使用] ** 列にチェックマークが入っていることを確認します。

この操作を完了すると、WindowsStoreProxy.xml に加えた変更内容がスキーマに適用されます。 詳しくは、「[方法: 使用する XML スキーマを選択する](http://go.microsoft.com/fwlink/p/?LinkId=403014)」をご覧ください。

> [!div class="tabbedCodeSnippets"]
```xml
<?xml version="1.0" encoding="utf-8"?>
<xs:schema attributeFormDefault="unqualified" elementFormDefault="qualified" xmlns:xs="http://www.w3.org/2001/XMLSchema">
  <xs:import namespace="http://www.w3.org/XML/1998/namespace"/>
  <xs:element name="CurrentApp" type="CurrentAppDefinition"></xs:element>
  <xs:complexType name="CurrentAppDefinition">
    <xs:sequence>
      <xs:element name="ListingInformation" type="ListingDefinition" minOccurs="1" maxOccurs="1"/>
      <xs:element name="LicenseInformation" type="LicenseDefinition" minOccurs="1" maxOccurs="1"/>
      <xs:element name="ConsumableInformation" type="ConsumableDefinition" minOccurs="0" maxOccurs="1"/>
      <xs:element name="Simulation" type="SimulationDefinition" minOccurs="0" maxOccurs="1"/>
    </xs:sequence>
  </xs:complexType>
  <xs:simpleType name="ResponseCodes">
    <xs:restriction base="xs:string">
      <xs:enumeration value="S_OK">
        <xs:annotation>
          <xs:documentation>0x00000000</xs:documentation>
        </xs:annotation>
      </xs:enumeration>
      <xs:enumeration value="E_INVALIDARG">
        <xs:annotation>
          <xs:documentation>0x80070057</xs:documentation>
        </xs:annotation>
      </xs:enumeration>
      <xs:enumeration value="E_CANCELLED">
        <xs:annotation>
          <xs:documentation>0x800704C7</xs:documentation>
        </xs:annotation>
      </xs:enumeration>
      <xs:enumeration value="E_FAIL">
        <xs:annotation>
          <xs:documentation>0x80004005</xs:documentation>
        </xs:annotation>
      </xs:enumeration>
      <xs:enumeration value="E_OUTOFMEMORY">
        <xs:annotation>
          <xs:documentation>0x8007000E</xs:documentation>
        </xs:annotation>
      </xs:enumeration>
      <xs:enumeration value="ERROR_ALREADY_EXISTS">
        <xs:annotation>
          <xs:documentation>0x800700B7</xs:documentation>
        </xs:annotation>
      </xs:enumeration>
    </xs:restriction>
  </xs:simpleType>
  <xs:simpleType name="ConsumableStatus">
    <xs:restriction base="xs:string">
      <xs:enumeration value="Active"/>
      <xs:enumeration value="PurchaseReverted"/>
      <xs:enumeration value="PurchasePending"/>
      <xs:enumeration value="ServerError"/>
    </xs:restriction>
  </xs:simpleType>
  <xs:simpleType name="StoreMethodName">
    <xs:restriction base="xs:string">
      <xs:enumeration value="RequestAppPurchaseAsync_GetResult" id="RPPA"/>
      <xs:enumeration value="RequestProductPurchaseAsync_GetResult" id="RFPA"/>
      <xs:enumeration value="LoadListingInformationAsync_GetResult" id="LLIA"/>
      <xs:enumeration value="ReportConsumableFulfillmentAsync_GetResult" id="RPFA"/>
      <xs:enumeration value="LoadListingInformationByKeywordsAsync_GetResult" id="LLIKA"/>
      <xs:enumeration value="LoadListingInformationByProductIdAsync_GetResult" id="LLIPA"/>
      <xs:enumeration value="GetUnfulfilledConsumablesAsync_GetResult" id="GUC"/>
      <xs:enumeration value="GetAppReceiptAsync_GetResult" id="GARA"/>
    </xs:restriction>
  </xs:simpleType>
  <xs:simpleType name="SimulationMode">
    <xs:restriction base="xs:string">
      <xs:enumeration value="Interactive"/>
      <xs:enumeration value="Automatic"/>
    </xs:restriction>
  </xs:simpleType>
  <xs:complexType name="ListingDefinition">
    <xs:sequence>
      <xs:element name="App" type="AppListingDefinition"/>
      <xs:element name="Product" type="ProductListingDefinition" minOccurs="0" maxOccurs="unbounded"/>
    </xs:sequence>
  </xs:complexType>
  <xs:complexType name="ConsumableDefinition">
    <xs:sequence>
      <xs:element name="Product" type="ConsumableProductDefinition" minOccurs="0" maxOccurs="unbounded"/>
    </xs:sequence>
  </xs:complexType>
  <xs:complexType name="AppListingDefinition">
    <xs:sequence>
      <xs:element name="AppId" type="xs:string" minOccurs="1" maxOccurs="1"/>
      <xs:element name="LinkUri" type="xs:anyURI" minOccurs="1" maxOccurs="1"/>
      <xs:element name="CurrentMarket" type="xs:language" minOccurs="1" maxOccurs="1"/>
      <xs:element name="AgeRating" type="xs:unsignedInt" minOccurs="1" maxOccurs="1"/>
      <xs:element name="MarketData" type="MarketSpecificAppData" minOccurs="1" maxOccurs="unbounded"/>
    </xs:sequence>
  </xs:complexType>
  <xs:complexType name="MarketSpecificAppData">
    <xs:sequence>
      <xs:element name="Name" type="xs:string" minOccurs="1" maxOccurs="1"/>
      <xs:element name="Description" type="xs:string" minOccurs="1" maxOccurs="1"/>
      <xs:element name="Price" type="xs:float" minOccurs="1" maxOccurs="1"/>
      <xs:element name="CurrencySymbol" type="xs:string" minOccurs="1" maxOccurs="1"/>
      <xs:element name="CurrencyCode" type="xs:string" minOccurs="0" maxOccurs="1"/>
    </xs:sequence>
    <xs:attribute ref="xml:lang" use="required"/>
  </xs:complexType>
  <xs:complexType name="MarketSpecificProductData">
    <xs:sequence>
      <xs:element name="Name" type="xs:string" minOccurs="1" maxOccurs="1"/>
      <xs:element name="Price" type="xs:float" minOccurs="1" maxOccurs="1"/>
      <xs:element name="CurrencySymbol" type="xs:string" minOccurs="1" maxOccurs="1"/>
      <xs:element name="CurrencyCode" type="xs:string" minOccurs="0" maxOccurs="1"/>
      <xs:element name="Description" type="xs:string" minOccurs="0" maxOccurs="1"/>
      <xs:element name="Tag" type="xs:string" minOccurs="0" maxOccurs="1"/>
      <xs:element name="Keywords" type="KeywordDefinition" minOccurs="0" maxOccurs="1"/>
      <xs:element name="ImageUri" type="xs:anyURI" minOccurs="0" maxOccurs="1"/>
    </xs:sequence>
    <xs:attribute ref="xml:lang" use="required"/>
  </xs:complexType>
  <xs:complexType name="ProductListingDefinition">
    <xs:sequence>
      <xs:element name="MarketData" type="MarketSpecificProductData" minOccurs="1" maxOccurs="unbounded"/>
    </xs:sequence>
    <xs:attribute name="ProductId" use="required">
      <xs:simpleType>
        <xs:restriction base="xs:string">
          <xs:maxLength value="100"/>
          <xs:pattern value="[^,]*"/>
        </xs:restriction>
      </xs:simpleType>
    </xs:attribute>
    <xs:attribute name="LicenseDuration" type="xs:integer" use="optional"/>
    <xs:attribute name="ProductType" type="xs:string" use="optional"/>
  </xs:complexType>
  <xs:simpleType name="guid">
    <xs:restriction base="xs:string">
      <xs:pattern value="[\da-fA-F]{8}-[\da-fA-F]{4}-[\da-fA-F]{4}-[\da-fA-F]{4}-[\da-fA-F]{12}"/>
    </xs:restriction>
  </xs:simpleType>
  <xs:complexType name="ConsumableProductDefinition">
    <xs:attribute name="ProductId" use="required">
      <xs:simpleType>
        <xs:restriction base="xs:string">
          <xs:maxLength value="100"/>
          <xs:pattern value="[^,]*"/>
        </xs:restriction>
      </xs:simpleType>
    </xs:attribute>
    <xs:attribute name="TransactionId" type="guid" use="required"/>
    <xs:attribute name="Status" type="ConsumableStatus" use="required"/>
    <xs:attribute name="OfferId" type="xs:string" use="optional"/>
  </xs:complexType>
  <xs:complexType name="LicenseDefinition">
    <xs:sequence>
      <xs:element name="App" type="AppLicenseDefinition"/>
      <xs:element name="Product" type="ProductLicenseDefinition" minOccurs="0" maxOccurs="unbounded"/>
    </xs:sequence>
  </xs:complexType>
  <xs:complexType name="AppLicenseDefinition">
    <xs:sequence>
      <xs:element name="IsActive" type="xs:boolean" minOccurs="1" maxOccurs="1"/>
      <xs:element name="IsTrial" type="xs:boolean" minOccurs="1" maxOccurs="1"/>
      <xs:element name="ExpirationDate" type="xs:dateTime" minOccurs="0" maxOccurs="1"/>
    </xs:sequence>
  </xs:complexType>
  <xs:complexType name="ProductLicenseDefinition">
    <xs:sequence>
      <xs:element name="IsActive" type="xs:boolean" minOccurs="1" maxOccurs="1"/>
      <xs:element name="ExpirationDate" type="xs:dateTime" minOccurs="0" maxOccurs="1"/>
    </xs:sequence>
    <xs:attribute name="ProductId" type="xs:string" use="required"/>
    <xs:attribute name="OfferId" type="xs:string" use="optional"/>
  </xs:complexType>
  <xs:complexType name="SimulationDefinition" >
    <xs:sequence>
      <xs:element name="DefaultResponse" type="DefaultResponseDefinition" minOccurs="0" maxOccurs="unbounded"/>
    </xs:sequence>
    <xs:attribute name="SimulationMode" type="SimulationMode" use="optional"/>
  </xs:complexType>
  <xs:complexType name="DefaultResponseDefinition">
    <xs:attribute name="MethodName" type="StoreMethodName" use="required"/>
    <xs:attribute name="HResult" type="ResponseCodes" use="required"/>
  </xs:complexType>
  <xs:complexType name="KeywordDefinition">
    <xs:sequence>
      <xs:element name="Keyword" type="xs:string" minOccurs="0" maxOccurs="10"/>
    </xs:sequence>
  </xs:complexType>
</xs:schema>
```


<span id="proxy-descriptions" />

### <a name="element-and-attribute-descriptions"></a>要素と属性の説明

このセクションでは、WindowsStoreProxy.xml ファイル内の要素と属性について説明します。

このファイルのルート要素は、現在のアプリを表す **CurrentApp**要素です。 この要素には、次の子要素が含まれます。

|  要素  |  必須かどうか  |  数量  |  説明   |
|-------------|------------|--------|--------|
|  [ListingInformation](#listinginformation)  |    必須        |  1  |  アプリの登録情報のデータが含まれています。            |
|  [LicenseInformation](#licenseinformation)  |     必須       |   1    |   このアプリで利用可能なライセンスと永続的なアドオンが記述されています。     |
|  [ConsumableInformation](#consumableinformation)  |      必須ではない      |   0 または 1   |   このアプリで利用可能なコンシューマブルなアドオンが記述されています。      |
|  [Simulation](#simulation)  |     必須ではない       |      0 または 1      |   テストで、さまざまな [CurrentAppSimulator](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.store.currentappsimulator.aspx) メソッドを呼び出したときに行われる動作が記述されています。    |

<span id="listinginformation" />

#### <a name="listinginformation-element"></a>ListingInformation 要素

この要素には、アプリの登録情報のデータが含まれています。 **ListingInformation** は、**CurrentApp** 要素の必須の子要素です。

**ListingInformation** には、次の子要素が含まれます。

|  要素  |  必須かどうか  |  数量  |  説明   |
|-------------|------------|--------|--------|
|  [App](#app-child-of-listinginformation)  |    必須   |  1   |    アプリに関するデータを提供します。         |
|  [Product](#product-child-of-listinginformation)  |    必須ではない  |  0 以上   |      アプリのアドオンを記述します。     |     |

<span id="app-child-of-listinginformation"/>

#### <a name="app-element-child-of-listinginformation"></a>App 要素 (ListingInformation の子要素)

この要素は、アプリのライセンスを記述します。 **App** は、[ListingInformation](#listinginformation) 要素の必須の子要素です。

**App** には、次の子要素が含まれます。

|  要素  |  必須かどうか  |  数量  | 説明   |
|-------------|------------|--------|--------|
|  **AppId**  |    必須   |  1   |   ストアでアプリを識別する GUID です。 テストでは任意の GUID を使用できます。        |
|  **LinkUri**  |    必須  |  1   |    ストアの登録情報ページの URI です。 テストでは任意の有効な URI を使用できます。         |
|  **CurrentMarket**  |    必須  |  1   |    顧客の国/地域です。         |
|  **AgeRating**  |    必須  |  1   |     アプリの年齢区分の下限を表す整数です。 これは、アプリの提出時にパートナー センターで指定するのと同じ値です。 ストアで使われる値は、3、7、12、および 16 です。 これらの年齢区分について詳しくは、「[年齢区分](../publish/age-ratings.md)」をご覧ください。        |
|  [MarketData](#marketdata-child-of-app)  |    必須  |  1 以上      |    アプリに関する特定の国/地域向けの情報が含まれています。 アプリが掲載される国/地域ごとに、**MarketData**要素を含める必要があります。       |    |

<span id="marketdata-child-of-app"/>

#### <a name="marketdata-element-child-of-app"></a>MarketData 要素 (App の子要素)

この要素は、アプリに関する特定の国/地域向けの情報を提供します。 アプリが掲載される国/地域ごとに、**MarketData**要素を含める必要があります。 **MarketData** は、[App](#app-child-of-listinginformation) 要素の必須の子要素です。

**MarketData** には、次の子要素が含まれます。

|  要素  |  必須かどうか  |  数量  | 説明   |
|-------------|------------|--------|--------|
|  **Name**  |    必須   |  1   |   この国/地域でのアプリの名前です。        |
|  **Description**  |    必須  |  1   |      この国/地域向けのアプリの説明です。       |
|  **Price**  |    必須  |  1   |     この国/地域でのアプリの価格です。        |
|  **CurrencySymbol**  |    必須  |  1   |     この国/地域で使われている通貨記号です。        |
|  **CurrencyCode**  |    必須ではない  |  0 または 1      |      この国/地域で使われている通貨コードです。         |  |

**MarketData** には次の属性があります。

|  属性  |  必須かどうか  |  説明   |
|-------------|------------|----------------|
|  **xml:lang**  |    必須        |     市場データ情報を適用する国/地域を指定します。          |  |

<span id="product-child-of-listinginformation"/>

#### <a name="product-element-child-of-listinginformation"></a>Product 要素 (ListingInformation の子要素)

この要素は、アプリのアドオンを記述します。 **Product** は、[ListingInformation](#listinginformation) 要素のオプションの子要素であり、1 つ以上の [MarketData](#marketdata-child-of-product) 要素が含まれます。

**Product** には次の属性があります。

|  属性  |  必須かどうか  |  説明   |
|-------------|------------|----------------|
|  **ProductId**  |    必須        |    アプリがこのアドオンを特定するために使う文字列が含まれています。           |
|  **LicenseDuration**  |    必須ではない        |    アイテム購入後、ライセンスが有効な日数を示します。 製品の購入によって作成される新しいライセンスの有効期限は、購入日にライセンス期間を加算した日付です。 この属性は、**ProductType** 属性が **Durable** の場合のみ使用され、コンシューマブルなアドオンの場合には無視されます。           |
|  **ProductType**  |    必須ではない        |    アプリ内製品が永続的かどうかを識別する値が含まれています。 サポートされている値は、**Durable** (既定) と **Consumable** です。 永続的なアドオンについて詳しくは、[LicenseInformation](#licenseinformation) の下の [Product](#product-child-of-licenseinformation)要素をご覧ください。コンシューマブルなアドオンについて詳しくは、[ConsumableInformation](#consumableinformation) の [Product](#product-child-of-consumableinformation) 要素をご覧ください。           |  |

<span id="marketdata-child-of-product"/>

#### <a name="marketdata-element-child-of-product"></a>MarketData 要素 (Product の子要素)

この要素は、アドオンに関する特定の国/地域向けの情報を提供します。 アドオンが掲載される国/地域ごとに、**MarketData**要素を含める必要があります。 **MarketData** は、[Product](#product-child-of-listinginformation) 要素の必須の子要素です。

**MarketData** には、次の子要素が含まれます。

|  要素  |  必須かどうか  |  数量  | 説明   |
|-------------|------------|--------|--------|
|  **Name**  |    必須   |  1   |   この国/地域でのアドオンの名前です。        |
|  **Price**  |    必須  |  1   |     この国/地域でのアドオンの価格です。        |
|  **CurrencySymbol**  |    必須  |  1   |     この国/地域で使われている通貨記号です。        |
|  **CurrencyCode**  |    必須ではない  |  0 または 1      |      この国/地域で使われている通貨コードです。         |  
|  **説明**  |    必須ではない  |   0 または 1   |      この国/地域向けのアドオンの説明です。       |
|  **Tag**  |    必須ではない  |   0 または 1   |      アドオンの[カスタム開発者データ](../publish/enter-add-on-properties.md#custom-developer-data) (タグとも呼ばれます) です。       |
|  **Keywords**  |    必須ではない  |   0 または 1   |      アドオンの[キーワード](../publish/enter-add-on-properties.md#keywords)が含まれた最大 10 個の **Keyword** 要素を含みます。       |
|  **ImageUri**  |    必須ではない  |   0 または 1   |      アドオンの登録情報に表示する[画像の URI](../publish/create-add-on-store-listings.md#icon) です。           |  |

**MarketData** には次の属性があります。

|  属性  |  必須かどうか  |  説明   |
|-------------|------------|----------------|
|  **xml:lang**  |    必須        |     市場データ情報を適用する国/地域を指定します。          |  |

<span id="licenseinformation"/>

#### <a name="licenseinformation-element"></a>LicenseInformation 要素

この要素は、このアプリで利用可能なライセンスと永続的なアプリ内製品を記述します。 **LicenseInformation** は、**CurrentApp** 要素の必須の子要素です。

**LicenseInformation** には、次の子要素が含まれます。

|  要素  |  必須かどうか  |  数量  | 説明   |
|-------------|------------|--------|--------|
|  [App](#app-child-of-licenseinformation)  |    必須   |  1   |    アプリのライセンスを記述します。         |
|  [Product](#product-child-of-licenseinformation)  |    必須ではない  |  0 以上   |      アプリ内の永続的なアドオンのライセンスの状態を記述します。         |   |

次の表では、**App** 要素と **Product** 要素の下で値を組み合わせて、いくつかの一般的な条件をシミュレートする方法を示します。

|  シミュレートする条件  |  IsActive  |  IsTrial  | ExpirationDate   |
|-------------|------------|--------|--------|
|  完全なライセンスを保有  |    true   |  false  |    指定しません。 実際には有効期限が存在し、将来の日付を指定する場合でも、その要素は XML ファイルから省略することをお勧めします。 有効期限が存在し、過去の日付が指定されている場合、**IsActive** は無視され、false として扱われます。          |
|  試用期間中  |    true  |  true   |      &lt;将来の日付と時刻&gt; **IsTrial** が true であるため、この要素を指定する必要があります。 残りの試用期間に対応する有効期限は、現在の協定世界時 (UTC) を表示する Web サイトにアクセスして確認できます。         |
|  有効期限が切れた試用版  |    false  |  true   |      &lt;過去の日付と時刻&gt; **IsTrial** が true であるため、この要素を指定する必要があります。 UTC で表した "過去の" 有効期限は、現在の協定世界時 (UTC) を表示する Web サイトにアクセスして確認できます。         |
|  ライセンスが無効  |    false  | false       |     &lt;任意の値または省略&gt;          |  |

<span id="app-child-of-licenseinformation"/>

#### <a name="app-element-child-of-licenseinformation"></a>App 要素 (LicenseInformation の子要素)

この要素は、アプリのライセンスを記述します。 **App** は、[LicenseInformation](#licenseinformation) 要素の必須の子要素です。

**App** には、次の子要素が含まれます。

|  要素  |  必須かどうか  |  数量  | 説明   |
|-------------|------------|--------|--------|
|  **IsActive**  |    必須   |  1   |    このアプリの現在のライセンスの状態を記述します。 値 **true** はライセンスが有効であることを示し、**false** はライセンスが無効であることを示します。 この値はアプリが使用モードであるかどうかに関係なく、通常、**true** です。  ライセンスが無効な場合にアプリがどのように動作するかをテストするには、この値を **false** に設定します。           |
|  **IsTrial**  |    必須  |  1   |      このアプリが現在、試用期間中かどうかの状態を記述します。 値 **true** はアプリが試用期間中であることを示します。**false** は、アプリが購入済みであるか、試用期限が切れたために、アプリが試用期間中でないことを示します。         |
|  **ExpirationDate**  |    必須ではない  |  0 または 1       |     このアプリの試用期間が期限切れとなる日付 (協定世界時 (UTC)) です。 日付は、yyyy-mm-ddThh:mm:ss.ssZ の形式で表す必要があります。 たとえば、2015 年 1 月 19 日午前 5 時は、2015-01-19T05:00:00.00Z と表します。 この要素は、**IsTrial** が **true** の場合に必須です。 そうでない場合は、必須ではありません。          |  |

<span id="product-child-of-licenseinformation"/>

#### <a name="product-element-child-of-licenseinformation"></a>Product 要素 (LicenseInformation の子要素)

この要素は、アプリ内の永続的なアドオンのライセンスの状態を記述します。 **Product** は、[LicenseInformation](#licenseinformation) 要素のオプションの子要素です。

**Product** には、次の子要素が含まれます。

|  要素  |  必須かどうか  |  数量  | 説明   |
|-------------|------------|--------|--------|
|  **IsActive**  |    必須   |  1     |    このアドオンの現在のライセンスの状態を記述します。 値 **true** はアドオンを追加できることを示し、**false** はアドオンを使用できないか、購入していないことを示します。           |
|  **ExpirationDate**  |    必須ではない   |  0 または 1     |     協定世界時 (UTC) で表したアドオンの有効期限日です。 日付は、yyyy-mm-ddThh:mm:ss.ssZ の形式で表す必要があります。 たとえば、2015 年 1 月 19 日午前 5 時は、2015-01-19T05:00:00.00Z と表します。 この要素が存在する場合、アドオンには有効期限日があります。 存在しない場合、アドオンに有効期限はありません。  |  

**Product** には次の属性があります。

|  属性  |  必須かどうか  |  説明   |
|-------------|------------|----------------|
|  **ProductId**  |    必須        |   アプリがこのアドオンを特定するために使う文字列が含まれています。            |
|  **OfferId**  |     必須ではない       |   アプリが、このアドオンが属するカテゴリを特定するために使う文字列が含まれています。 これを使うことで、「[アプリ内製品の大規模なカタログの管理](manage-a-large-catalog-of-in-app-products.md)」で説明されている大規模なアイテムのカタログに対応できます。           |

<span id="simulation"/>

#### <a name="simulation-element"></a>Simulation 要素

この要素は、テストにおいて、さまざまな [CurrentAppSimulator](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.store.currentappsimulator.aspx) メソッドへの呼び出しがどのように動作するかを記述します。 **Simulation** は **CurrentApp** 要素のオプションの子要素であり、0 個以上の [DefaultResponse](#defaultresponse) 要素が含まれます。

**Simulation** には次の属性があります。

|  属性  |  必須かどうか  |  説明   |
|-------------|------------|----------------|
|  **SimulationMode**  |    必須ではない        |      値は **Interactive** か **Automatic** のいずれかです。 この属性を **Automatic** に設定すると、指定した HRESULT エラー コードがメソッドによって自動的に返されます。 これは自動化されたテスト ケースを実行する場合に使用できます。       |

<span id="defaultresponse"/>

#### <a name="defaultresponse-element"></a>DefaultResponse 要素

この要素は、**CurrentAppSimulator** メソッドによって返される既定のエラー コードを記述します。 **DefaultResponse** は、[Simulation](#simulation) 要素のオプションの子要素です。

**DefaultResponse** には次の属性があります。

|  属性  |  必須かどうか  |  説明   |
|-------------|------------|----------------|
|  **MethodName**  |    必須        |   この属性は、[スキーマ](#schema) の **StoreMethodName** 型で表示される列挙値のいずれかに割り当てます。 これらの各列挙値は、テストのときにアプリでエラー コードの戻り値をシミュレートする **CurrentAppSimulator** メソッドを表します。 たとえば、値 **RequestAppPurchaseAsync_GetResult** は、[RequestAppPurchaseAsync](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.currentappsimulator.requestapppurchaseasync) メソッドのエラー コードの戻り値をシミュレートすることを示します。            |
|  **HResult**  |     必須       |   この属性は、[スキーマ](#schema) の **ResponseCodes** 型で表示される列挙値のいずれかに割り当てます。 これらの各列挙値は、この **DefaultResponse** 要素の **MethodName** 属性に割り当てるメソッドに対して返すエラーコードを表します。           |

<span id="consumableinformation"/>

#### <a name="consumableinformation-element"></a>ConsumableInformation 要素

この要素は、このアプリで利用可能なコンシューマブルなアドオンを記述します。 **ConsumableInformation** は、**CurrentApp** 要素のオプションの子要素であり、0 個以上の [Product](#product-child-of-consumableinformation) 要素が含まれます。

<span id="product-child-of-consumableinformation"/>

#### <a name="product-element-child-of-consumableinformation"></a>Product 要素 (ConsumableInformation の子要素)

この要素は、コンシューマブルなアドオンを記述します。 **Product** は、[ConsumableInformation](#consumableinformation) 要素のオプションの子要素です。

**Product** には次の属性があります。

|  属性  |  必須かどうか  |  説明   |
|-------------|------------|----------------|
|  **ProductId**  |    必須        |   アプリがこのコンシューマブルなアドオンを特定するために使う文字列が含まれています。            |
|  **TransactionId**  |     必須       |   アプリが、フルフィルメントのプロセス全体を通じ、コンシューマブルの購入トランザクションを追跡するために使用する GUID (文字列) が含まれています。 詳しくは、「[コンシューマブルなアプリ内製品購入の有効化](enable-consumable-in-app-product-purchases.md)」をご覧ください。            |
|  **Status**  |      必須      |  アプリが、コンシューマブルのフルフィルメントの状態を示すために使う文字列が含まれています。 値は、**Active**、**PurchaseReverted**、**PurchasePending**、または **ServerError** です。             |
|  **OfferId**  |     必須ではない       |    アプリが、このコンシューマブルが属するカテゴリを特定するために使う文字列が含まれています。 これを使うことで、「[アプリ内製品の大規模なカタログの管理](manage-a-large-catalog-of-in-app-products.md)」で説明されている大規模なアイテムのカタログに対応できます。           |
