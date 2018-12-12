---
title: UWP アプリでの設定の保存と読み込み
description: ユニバーサル Windows プラットフォーム アプリでのアプリの設定の保存と読み込みについて説明します。
ms.date: 05/07/2018
ms.topic: article
keywords: 概要, uwp, windows 10, 学習トラック, 設定, 設定の保存, 設定の読み込み
ms.localizationpriority: medium
ms.custom: RS5
ms.openlocfilehash: 4aa56bf24d2dfa1fd4ae1947a5b0edf7f312ea2f
ms.sourcegitcommit: 49d58bc66c1c9f2a4f81473bcb25af79e2b1088d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8931900"
---
# <a name="save-and-load-settings-in-a-uwp-app"></a>UWP アプリでの設定の保存と読み込み

このトピックでは、ユニバーサル Windows プラットフォーム (UWP) アプリでの設定の読み込みと保存を開始するために知っておく必要があることについて説明します。 主な API を紹介し、詳細情報を確認できるリンクを提供します。

設定を使用して、アプリのユーザーによるカスタマイズが可能な部分を記憶します。 たとえば、ニュース リーダーでアプリの設定を使用して、表示するニュース ソースや記事を読むために使用するフォントを保存します。

ローカル設定およびローミング設定を含む、アプリの設定の保存と読み込みを行うためのコードについて説明します。

## <a name="what-do-you-need-to-know"></a>理解しておく必要があること

アプリの設定を使用して、ユーザー設定やアプリの状態などの構成データを保存します。  デバイスに固有の設定は、ローカルに保存されます。 アプリがインストールされているデバイスで適用される設定は、ローミング データ ストアに保存されます。 設定は、ユーザーが同じ Microsoft アカウントでサインインし、同じバージョンのアプリがインストールされているデバイス間でローミングされます。

次のデータ型は、整数、倍精度浮動小数点数、浮動小数点値、文字型、文字列、Points、DateTimes などの設定と一緒に使用できます。 1 つの単位として扱う必要がある複数の設定があるときに役立つ、[ApplicationDataCompositeValue](https://docs.microsoft.com/uwp/api/Windows.Storage.ApplicationDataCompositeValue) クラスのインスタンスも保存できます。 たとえば、アプリの閲覧ウィンドウでテキストを表示するためのフォント名とポイント サイズは、1 つの単位として保存/復元する必要があります。 これにより、ある設定が別の設定の前にローミングするときに遅延のために別の設定と同期されなくなることを防ぐことができます。

アプリの設定の保存または読み込みについて知っておく必要がある主な API を次に示します。

- [Windows.Storage.ApplicationData.Current.LocalSettings](https://docs.microsoft.com/uwp/api/Windows.Storage.ApplicationData#Windows_Storage_ApplicationData_LocalSettings) は、ローカル アプリ データ ストアからアプリケーションの設定コンテナーを取得します。 デバイス間でローミングするのに適切ではない設定は、このデバイスに固有の状態を表すか、または長すぎるため、ここに保存します。
- [Windows.Storage.ApplicationData.Current.RoamingSettings](https://docs.microsoft.com/uwp/api/windows.storage.applicationdata.roamingsettings#Windows_Storage_ApplicationData_RoamingSettings) は、ローミング アプリ データ ストアからアプリケーションの設定コンテナーを取得します。 このデータは、デバイス間でローミングします。
- [Windows.Storage.ApplicationDataContainer](https://docs.microsoft.com/uwp/api/windows.storage.applicationdatacontainer) は、アプリの設定をキーと値のペアとして表すコンテナーです。 このクラスを使用して設定値を作成して取得します。
- [Windows.Storage.ApplicationDataCompositeValue](https://docs.microsoft.com/uwp/api/Windows.Storage.ApplicationDataCompositeValue) は、単位としてシリアル化する必要がある複数のアプリの設定を表します。 これは、ある設定を別の設定とは別に更新するべきではない場合に役立ちます。

## <a name="save-app-settings"></a>アプリの設定の保存

この概要では、アプリ設定のローカルでの保存と読み込み、およびデバイス間での複合フォントまたはフォント サイズの設定のローミングという 2 つの簡単なシナリオについて説明します。

 ```csharp
// Save a setting locally on the device
ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
localSettings.Values["test setting"] = "a device specific setting";

// Save a composite setting that will be roamed between devices
ApplicationDataContainer roamingSettings = Windows.Storage.ApplicationData.Current.RoamingSettings;
Windows.Storage.ApplicationDataCompositeValue composite = new Windows.Storage.ApplicationDataCompositeValue();
composite["Font"] = "Calibri";
composite["FontSize"] = 11;
roamingSettings.Values["RoamingFontInfo"] = composite;
 ```

まず、`Windows.Storage.ApplicationData.Current.LocalSettings` でローカル設定データ ストアの **ApplicationDataContainer** を取得することで、ローカル デバイスに設定を保存します。 このインスタンスに割り当てるキー/値ペアのディクショナリは、ローカル デバイス設定データ ストアに保存されます。

同様のパターンを使用して、ローミング設定を保存します。 まず、`Windows.Storage.ApplicationData.Current.RoamingSettings` を使用してローミング設定データ ストアの **ApplicationDataContainer** を取得します。 次に、このインスタンスにキーと値のペアを割り当てます。  これらのキーと値のペアは、デバイス間で自動的にローミングされます。

上のコード スニペットでは、**ApplicationDataCompositeValue** は複数のキーと値のペアを格納します。 コンポジット値は、相互に同期しなくなることがあってはならない複数の設定があるときに役立ちます。 **ApplicationDataCompositeValue** を保存すると、単位として、または自動的に値が保存され読み込まれます。 これにより、関連する設定は個別ではなく単位としてローミングされるため、同期しなくなることはありません。

## <a name="load-app-settings"></a>アプリ設定の読み込み

```csharp
// load a setting that is local to the device
ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
String localValue = localSettings.Values["test setting"] as string;

// load a composite setting that roams between devices
ApplicationDataContainer roamingSettings = Windows.Storage.ApplicationData.Current.RoamingSettings;
Windows.Storage.ApplicationDataCompositeValue composite = (ApplicationDataCompositeValue)roamingSettings.Values["RoamingFontInfo"];
if (composite != null)
{
    String fontName = composite["Font"] as string;
    int fontSize = (int)composite["FontSize"];
}
```

`Windows.Storage.ApplicationData.Current.LocalSettings` を使用してローカル設定データ ストアの **ApplicationDataContainer** インスタンスをまず取得することで、ローカル デバイスから設定を読み込みます。 次に、それを使用してキーと値のペアを取得します。

同様のパターンに従って、ローミング設定を読み込みます。 まず、`Windows.Storage.ApplicationData.Current.RoamingSettings` を使用してローミング設定データ ストアから **ApplicationDataContainer** インスタンスを取得します。 そのインスタンスからキーと値のペアにアクセスします。 設定にアクセスしているデバイスにデータがまだローミングされていない場合は、null の **ApplicationDataContainer** を取得します。 上のコード例に `if (composite != null)` チェックインがあるのはこのためです。

## <a name="useful-apis-and-docs"></a>便利な API とドキュメント

API の簡単な概要と、アプリの設定の保存と読み込みを開始するために役立つその他の便利なドキュメントを次に示します。

### <a name="useful-apis"></a>便利な API

| API | 説明 |
|------|---------------|
| [ApplicationData.LocalSettings](https://msdn.microsoft.com/library/windows/apps/windows.storage.applicationdata.temporaryfolder) | ローカル アプリ データ ストアからアプリケーション設定コンテナーを取得します。 |
| [ApplicationData.RoamingSettings](https://docs.microsoft.com/uwp/api/windows.storage.applicationdata.roamingsettings) | ローミング アプリ データ ストアからアプリケーション設定コンテナーを取得します。 |
| [ApplicationDataContainer](https://docs.microsoft.com/uwp/api/windows.storage.applicationdatacontainer) | コンテナー階層の作成、削除、列挙、および移動をサポートするアプリの設定のコンテナーです。 |
| [Windows.UI.ApplicationSettings Namespace](https://docs.microsoft.com/uwp/api/windows.ui.applicationsettings) | Windows シェルの設定ウィンドウに表示されるアプリの設定を定義するために使用するクラスを指定します。 |

### <a name="useful-docs"></a>役立つドキュメント

| トピック | 説明 |
|-------|----------------|
| [アプリ設定のガイドライン](https://docs.microsoft.com/windows/uwp/design/app-settings/guidelines-for-app-settings) | アプリ設定を作成し表示する際のベスト プラクティスについて説明します。 |
| [設定と他のアプリ データを保存して取得する](https://docs.microsoft.com/windows/uwp/design/app-settings/store-and-retrieve-app-data#create-and-read-a-local-file) | ローミング設定など、設定の保存と取得に関するチュートリアルです。 |

## <a name="useful-code-samples"></a>役立つコード サンプル

| コード サンプル | 説明 |
|-----------------|---------------|
| [アプリケーション データ サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/ApplicationData) | 設定に焦点を当てたシナリオ 2-4 |
