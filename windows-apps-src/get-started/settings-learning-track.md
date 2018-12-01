---
title: UWP アプリでの設定の保存と読み込み
description: ユニバーサル Windows プラットフォーム アプリでのアプリの設定の保存と読み込みについて説明します。
ms.date: 05/07/2018
ms.topic: article
keywords: 概要, uwp, windows 10, 学習トラック, 設定, 設定の保存, 設定の読み込み
ms.localizationpriority: medium
ms.custom: RS5
ms.openlocfilehash: 4aa56bf24d2dfa1fd4ae1947a5b0edf7f312ea2f
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/30/2018
ms.locfileid: "8346350"
---
# <a name="save-and-load-settings-in-a-uwp-app"></a><span data-ttu-id="96a82-104">UWP アプリでの設定の保存と読み込み</span><span class="sxs-lookup"><span data-stu-id="96a82-104">Save and load settings in a UWP app</span></span>

<span data-ttu-id="96a82-105">このトピックでは、ユニバーサル Windows プラットフォーム (UWP) アプリでの設定の読み込みと保存を開始するために知っておく必要があることについて説明します。</span><span class="sxs-lookup"><span data-stu-id="96a82-105">This topic covers what you need to know to get started loading, and saving, settings in a Universal Windows Platform (UWP) app.</span></span> <span data-ttu-id="96a82-106">主な API を紹介し、詳細情報を確認できるリンクを提供します。</span><span class="sxs-lookup"><span data-stu-id="96a82-106">The main APIs are introduced, and links are provided to help you learn more.</span></span>

<span data-ttu-id="96a82-107">設定を使用して、アプリのユーザーによるカスタマイズが可能な部分を記憶します。</span><span class="sxs-lookup"><span data-stu-id="96a82-107">Use settings to remember the user-customizable aspects of your app.</span></span> <span data-ttu-id="96a82-108">たとえば、ニュース リーダーでアプリの設定を使用して、表示するニュース ソースや記事を読むために使用するフォントを保存します。</span><span class="sxs-lookup"><span data-stu-id="96a82-108">For example, a news reader could use app settings to save which news sources to display and what font to use for reading articles.</span></span>

<span data-ttu-id="96a82-109">ローカル設定およびローミング設定を含む、アプリの設定の保存と読み込みを行うためのコードについて説明します。</span><span class="sxs-lookup"><span data-stu-id="96a82-109">We’ll look at code to save and load app settings, including local and roaming settings.</span></span>

## <a name="what-do-you-need-to-know"></a><span data-ttu-id="96a82-110">理解しておく必要があること</span><span class="sxs-lookup"><span data-stu-id="96a82-110">What do you need to know</span></span>

<span data-ttu-id="96a82-111">アプリの設定を使用して、ユーザー設定やアプリの状態などの構成データを保存します。</span><span class="sxs-lookup"><span data-stu-id="96a82-111">Use app settings to store configuration data such as user preferences and app state.</span></span>  <span data-ttu-id="96a82-112">デバイスに固有の設定は、ローカルに保存されます。</span><span class="sxs-lookup"><span data-stu-id="96a82-112">Settings that are specific to the device are stored locally.</span></span> <span data-ttu-id="96a82-113">アプリがインストールされているデバイスで適用される設定は、ローミング データ ストアに保存されます。</span><span class="sxs-lookup"><span data-stu-id="96a82-113">Settings that apply on whichever device your app is installed on are stored in the roaming data store.</span></span> <span data-ttu-id="96a82-114">設定は、ユーザーが同じ Microsoft アカウントでサインインし、同じバージョンのアプリがインストールされているデバイス間でローミングされます。</span><span class="sxs-lookup"><span data-stu-id="96a82-114">Settings are roamed between devices on which the user is signed in with the same Microsoft Account and have the same version of the app installed.</span></span>

<span data-ttu-id="96a82-115">次のデータ型は、整数、倍精度浮動小数点数、浮動小数点値、文字型、文字列、Points、DateTimes などの設定と一緒に使用できます。</span><span class="sxs-lookup"><span data-stu-id="96a82-115">The following data types can be used with settings: integers, doubles, floats, chars, strings, Points, DateTimes, and more.</span></span> <span data-ttu-id="96a82-116">1 つの単位として扱う必要がある複数の設定があるときに役立つ、[ApplicationDataCompositeValue](https://docs.microsoft.com/uwp/api/Windows.Storage.ApplicationDataCompositeValue) クラスのインスタンスも保存できます。</span><span class="sxs-lookup"><span data-stu-id="96a82-116">You can also store instances of the [ApplicationDataCompositeValue](https://docs.microsoft.com/uwp/api/Windows.Storage.ApplicationDataCompositeValue) class which is useful when there are multiple settings that should be treated as a unit.</span></span> <span data-ttu-id="96a82-117">たとえば、アプリの閲覧ウィンドウでテキストを表示するためのフォント名とポイント サイズは、1 つの単位として保存/復元する必要があります。</span><span class="sxs-lookup"><span data-stu-id="96a82-117">For example, a font name and point size for displaying text in the reading pane of your app should be saved/restored as a single unit.</span></span> <span data-ttu-id="96a82-118">これにより、ある設定が別の設定の前にローミングするときに遅延のために別の設定と同期されなくなることを防ぐことができます。</span><span class="sxs-lookup"><span data-stu-id="96a82-118">This prevents one setting from getting out of sync with the other due to delays in roaming one setting before the other.</span></span>

<span data-ttu-id="96a82-119">アプリの設定の保存または読み込みについて知っておく必要がある主な API を次に示します。</span><span class="sxs-lookup"><span data-stu-id="96a82-119">Here are the main APIs you need to know about to save or load app settings:</span></span>

- <span data-ttu-id="96a82-120">[Windows.Storage.ApplicationData.Current.LocalSettings](https://docs.microsoft.com/uwp/api/Windows.Storage.ApplicationData#Windows_Storage_ApplicationData_LocalSettings) は、ローカル アプリ データ ストアからアプリケーションの設定コンテナーを取得します。</span><span class="sxs-lookup"><span data-stu-id="96a82-120">[Windows.Storage.ApplicationData.Current.LocalSettings](https://docs.microsoft.com/uwp/api/Windows.Storage.ApplicationData#Windows_Storage_ApplicationData_LocalSettings) gets the application settings container from the local app data store.</span></span> <span data-ttu-id="96a82-121">デバイス間でローミングするのに適切ではない設定は、このデバイスに固有の状態を表すか、または長すぎるため、ここに保存します。</span><span class="sxs-lookup"><span data-stu-id="96a82-121">Store settings here that are not appropriate to roam between devices because they represent state specific to this device, or are too big.</span></span>
- <span data-ttu-id="96a82-122">[Windows.Storage.ApplicationData.Current.RoamingSettings](https://docs.microsoft.com/uwp/api/windows.storage.applicationdata.roamingsettings#Windows_Storage_ApplicationData_RoamingSettings) は、ローミング アプリ データ ストアからアプリケーションの設定コンテナーを取得します。</span><span class="sxs-lookup"><span data-stu-id="96a82-122">[Windows.Storage.ApplicationData.Current.RoamingSettings](https://docs.microsoft.com/uwp/api/windows.storage.applicationdata.roamingsettings#Windows_Storage_ApplicationData_RoamingSettings) gets the application settings container from the roaming app data store.</span></span> <span data-ttu-id="96a82-123">このデータは、デバイス間でローミングします。</span><span class="sxs-lookup"><span data-stu-id="96a82-123">This data roams between devices.</span></span>
- <span data-ttu-id="96a82-124">[Windows.Storage.ApplicationDataContainer](https://docs.microsoft.com/uwp/api/windows.storage.applicationdatacontainer) は、アプリの設定をキーと値のペアとして表すコンテナーです。</span><span class="sxs-lookup"><span data-stu-id="96a82-124">[Windows.Storage.ApplicationDataContainer](https://docs.microsoft.com/uwp/api/windows.storage.applicationdatacontainer) is a container that represents app settings as key/value pairs.</span></span> <span data-ttu-id="96a82-125">このクラスを使用して設定値を作成して取得します。</span><span class="sxs-lookup"><span data-stu-id="96a82-125">Use this class to create and retrieve setting values.</span></span>
- <span data-ttu-id="96a82-126">[Windows.Storage.ApplicationDataCompositeValue](https://docs.microsoft.com/uwp/api/Windows.Storage.ApplicationDataCompositeValue) は、単位としてシリアル化する必要がある複数のアプリの設定を表します。</span><span class="sxs-lookup"><span data-stu-id="96a82-126">[Windows.Storage.ApplicationDataCompositeValue](https://docs.microsoft.com/uwp/api/Windows.Storage.ApplicationDataCompositeValue) represents multiple app settings that should be serialized as a unit.</span></span> <span data-ttu-id="96a82-127">これは、ある設定を別の設定とは別に更新するべきではない場合に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="96a82-127">This is useful when one setting shouldn't be updated independently of another.</span></span>

## <a name="save-app-settings"></a><span data-ttu-id="96a82-128">アプリの設定の保存</span><span class="sxs-lookup"><span data-stu-id="96a82-128">Save app settings</span></span>

<span data-ttu-id="96a82-129">この概要では、アプリ設定のローカルでの保存と読み込み、およびデバイス間での複合フォントまたはフォント サイズの設定のローミングという 2 つの簡単なシナリオについて説明します。</span><span class="sxs-lookup"><span data-stu-id="96a82-129">For this introduction, we will focus on two simple scenarios: saving and loading an app setting locally, and roaming a composite font/font size setting between devices.</span></span>

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

<span data-ttu-id="96a82-130">まず、`Windows.Storage.ApplicationData.Current.LocalSettings` でローカル設定データ ストアの **ApplicationDataContainer** を取得することで、ローカル デバイスに設定を保存します。</span><span class="sxs-lookup"><span data-stu-id="96a82-130">Save a setting to the local device, by first getting an **ApplicationDataContainer** for the local settings data store with `Windows.Storage.ApplicationData.Current.LocalSettings`.</span></span> <span data-ttu-id="96a82-131">このインスタンスに割り当てるキー/値ペアのディクショナリは、ローカル デバイス設定データ ストアに保存されます。</span><span class="sxs-lookup"><span data-stu-id="96a82-131">Key/value dictionary pairs that you assign to this instance are saved in the local device setting data store.</span></span>

<span data-ttu-id="96a82-132">同様のパターンを使用して、ローミング設定を保存します。</span><span class="sxs-lookup"><span data-stu-id="96a82-132">Save a roaming setting using a similar pattern.</span></span> <span data-ttu-id="96a82-133">まず、`Windows.Storage.ApplicationData.Current.RoamingSettings` を使用してローミング設定データ ストアの **ApplicationDataContainer** を取得します。</span><span class="sxs-lookup"><span data-stu-id="96a82-133">First get an **ApplicationDataContainer** for the roaming settings data store with `Windows.Storage.ApplicationData.Current.RoamingSettings`.</span></span> <span data-ttu-id="96a82-134">次に、このインスタンスにキーと値のペアを割り当てます。</span><span class="sxs-lookup"><span data-stu-id="96a82-134">Then assign key/value pairs to this instance.</span></span>  <span data-ttu-id="96a82-135">これらのキーと値のペアは、デバイス間で自動的にローミングされます。</span><span class="sxs-lookup"><span data-stu-id="96a82-135">Those key/value pairs will automatically roam between devices.</span></span>

<span data-ttu-id="96a82-136">上のコード スニペットでは、**ApplicationDataCompositeValue** は複数のキーと値のペアを格納します。</span><span class="sxs-lookup"><span data-stu-id="96a82-136">In the code snippet above, a  **ApplicationDataCompositeValue** stores multiple key/value pairs.</span></span> <span data-ttu-id="96a82-137">コンポジット値は、相互に同期しなくなることがあってはならない複数の設定があるときに役立ちます。</span><span class="sxs-lookup"><span data-stu-id="96a82-137">Composite values are useful when you have multiple settings that shouldn't get out of sync with each other.</span></span> <span data-ttu-id="96a82-138">**ApplicationDataCompositeValue** を保存すると、単位として、または自動的に値が保存され読み込まれます。</span><span class="sxs-lookup"><span data-stu-id="96a82-138">When you save a **ApplicationDataCompositeValue**, the values are saved and loaded as a unit, or atomically.</span></span> <span data-ttu-id="96a82-139">これにより、関連する設定は個別ではなく単位としてローミングされるため、同期しなくなることはありません。</span><span class="sxs-lookup"><span data-stu-id="96a82-139">This way settings that are related won't get out of sync because they are roamed as a unit instead of individually.</span></span>

## <a name="load-app-settings"></a><span data-ttu-id="96a82-140">アプリ設定の読み込み</span><span class="sxs-lookup"><span data-stu-id="96a82-140">Load app settings</span></span>

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

<span data-ttu-id="96a82-141">`Windows.Storage.ApplicationData.Current.LocalSettings` を使用してローカル設定データ ストアの **ApplicationDataContainer** インスタンスをまず取得することで、ローカル デバイスから設定を読み込みます。</span><span class="sxs-lookup"><span data-stu-id="96a82-141">Load a setting from the local device, by first getting an **ApplicationDataContainer** instance for the local settings data store with `Windows.Storage.ApplicationData.Current.LocalSettings`.</span></span> <span data-ttu-id="96a82-142">次に、それを使用してキーと値のペアを取得します。</span><span class="sxs-lookup"><span data-stu-id="96a82-142">Then use it to retrieve key/value pairs.</span></span>

<span data-ttu-id="96a82-143">同様のパターンに従って、ローミング設定を読み込みます。</span><span class="sxs-lookup"><span data-stu-id="96a82-143">Load a roaming setting by following a similar pattern.</span></span> <span data-ttu-id="96a82-144">まず、`Windows.Storage.ApplicationData.Current.RoamingSettings` を使用してローミング設定データ ストアから **ApplicationDataContainer** インスタンスを取得します。</span><span class="sxs-lookup"><span data-stu-id="96a82-144">First get an **ApplicationDataContainer** instance from the roaming settings data store with `Windows.Storage.ApplicationData.Current.RoamingSettings`.</span></span> <span data-ttu-id="96a82-145">そのインスタンスからキーと値のペアにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="96a82-145">Access key/value pairs from that instance.</span></span> <span data-ttu-id="96a82-146">設定にアクセスしているデバイスにデータがまだローミングされていない場合は、null の **ApplicationDataContainer** を取得します。</span><span class="sxs-lookup"><span data-stu-id="96a82-146">If the data hasn't roamed yet to the device that you are accessing the settings from, you'll get a null **ApplicationDataContainer**.</span></span> <span data-ttu-id="96a82-147">上のコード例に `if (composite != null)` チェックインがあるのはこのためです。</span><span class="sxs-lookup"><span data-stu-id="96a82-147">That's why there is a `if (composite != null)` check in the example code above.</span></span>

## <a name="useful-apis-and-docs"></a><span data-ttu-id="96a82-148">便利な API とドキュメント</span><span class="sxs-lookup"><span data-stu-id="96a82-148">Useful APIs and docs</span></span>

<span data-ttu-id="96a82-149">API の簡単な概要と、アプリの設定の保存と読み込みを開始するために役立つその他の便利なドキュメントを次に示します。</span><span class="sxs-lookup"><span data-stu-id="96a82-149">Here is a quick summary of APIs, and other useful documentation, to help get you started saving and loading app settings.</span></span>

### <a name="useful-apis"></a><span data-ttu-id="96a82-150">便利な API</span><span class="sxs-lookup"><span data-stu-id="96a82-150">Useful APIs</span></span>

| <span data-ttu-id="96a82-151">API</span><span class="sxs-lookup"><span data-stu-id="96a82-151">API</span></span> | <span data-ttu-id="96a82-152">説明</span><span class="sxs-lookup"><span data-stu-id="96a82-152">Description</span></span> |
|------|---------------|
| [<span data-ttu-id="96a82-153">ApplicationData.LocalSettings</span><span class="sxs-lookup"><span data-stu-id="96a82-153">ApplicationData.LocalSettings</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.storage.applicationdata.temporaryfolder) | <span data-ttu-id="96a82-154">ローカル アプリ データ ストアからアプリケーション設定コンテナーを取得します。</span><span class="sxs-lookup"><span data-stu-id="96a82-154">Gets the application settings container from the local app data store.</span></span> |
| [<span data-ttu-id="96a82-155">ApplicationData.RoamingSettings</span><span class="sxs-lookup"><span data-stu-id="96a82-155">ApplicationData.RoamingSettings</span></span>](https://docs.microsoft.com/uwp/api/windows.storage.applicationdata.roamingsettings) | <span data-ttu-id="96a82-156">ローミング アプリ データ ストアからアプリケーション設定コンテナーを取得します。</span><span class="sxs-lookup"><span data-stu-id="96a82-156">Gets the application settings container from the roaming app data store.</span></span> |
| [<span data-ttu-id="96a82-157">ApplicationDataContainer</span><span class="sxs-lookup"><span data-stu-id="96a82-157">ApplicationDataContainer</span></span>](https://docs.microsoft.com/uwp/api/windows.storage.applicationdatacontainer) | <span data-ttu-id="96a82-158">コンテナー階層の作成、削除、列挙、および移動をサポートするアプリの設定のコンテナーです。</span><span class="sxs-lookup"><span data-stu-id="96a82-158">A container for app settings that supports creating, deleting, enumerating, and traversing the container hierarchy.</span></span> |
| [<span data-ttu-id="96a82-159">Windows.UI.ApplicationSettings Namespace</span><span class="sxs-lookup"><span data-stu-id="96a82-159">Windows.UI.ApplicationSettings Namespace</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.applicationsettings) | <span data-ttu-id="96a82-160">Windows シェルの設定ウィンドウに表示されるアプリの設定を定義するために使用するクラスを指定します。</span><span class="sxs-lookup"><span data-stu-id="96a82-160">Provides classes that you'll use to define the app settings that appear in the settings pane of the Windows shell.</span></span> |

### <a name="useful-docs"></a><span data-ttu-id="96a82-161">役立つドキュメント</span><span class="sxs-lookup"><span data-stu-id="96a82-161">Useful docs</span></span>

| <span data-ttu-id="96a82-162">トピック</span><span class="sxs-lookup"><span data-stu-id="96a82-162">Topic</span></span> | <span data-ttu-id="96a82-163">説明</span><span class="sxs-lookup"><span data-stu-id="96a82-163">Description</span></span> |
|-------|----------------|
| [<span data-ttu-id="96a82-164">アプリ設定のガイドライン</span><span class="sxs-lookup"><span data-stu-id="96a82-164">Guidelines for app settings</span></span>](https://docs.microsoft.com/windows/uwp/design/app-settings/guidelines-for-app-settings) | <span data-ttu-id="96a82-165">アプリ設定を作成し表示する際のベスト プラクティスについて説明します。</span><span class="sxs-lookup"><span data-stu-id="96a82-165">Describes best practices for creating and displaying app settings.</span></span> |
| [<span data-ttu-id="96a82-166">設定と他のアプリ データを保存して取得する</span><span class="sxs-lookup"><span data-stu-id="96a82-166">Store and retrieve settings and other app data</span></span>](https://docs.microsoft.com/windows/uwp/design/app-settings/store-and-retrieve-app-data#create-and-read-a-local-file) | <span data-ttu-id="96a82-167">ローミング設定など、設定の保存と取得に関するチュートリアルです。</span><span class="sxs-lookup"><span data-stu-id="96a82-167">Walk-through for saving and retrieving settings, including roaming settings.</span></span> |

## <a name="useful-code-samples"></a><span data-ttu-id="96a82-168">役立つコード サンプル</span><span class="sxs-lookup"><span data-stu-id="96a82-168">Useful code samples</span></span>

| <span data-ttu-id="96a82-169">コード サンプル</span><span class="sxs-lookup"><span data-stu-id="96a82-169">Code sample</span></span> | <span data-ttu-id="96a82-170">説明</span><span class="sxs-lookup"><span data-stu-id="96a82-170">Description</span></span> |
|-----------------|---------------|
| [<span data-ttu-id="96a82-171">アプリケーション データ サンプル</span><span class="sxs-lookup"><span data-stu-id="96a82-171">Application data sample</span></span>](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/ApplicationData) | <span data-ttu-id="96a82-172">設定に焦点を当てたシナリオ 2-4</span><span class="sxs-lookup"><span data-stu-id="96a82-172">Scenarios 2-4 focus on settings</span></span> |
