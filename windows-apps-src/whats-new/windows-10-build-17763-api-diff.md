---
author: QuinnRadich
title: Windows 10 ビルド 17763 API の変更
description: 開発者は、次の一覧を使用して Windows 10 ビルド 17763 新規または変更された名前空間を確認するには
keywords: 新機能、新機能, 更新プログラム, Windows 10, 最新, api, 17763、年 10 月
ms.author: quradic
ms.date: 10/02/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
ms.localizationpriority: medium
ms.openlocfilehash: 3aa3e586e82fc5c2da78cc201f772112699a9035
ms.sourcegitcommit: 72835733ec429a5deb6a11da4112336746e5e9cf
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/19/2018
ms.locfileid: "5159962"
---
# <a name="new-apis-in-windows-10-build-17763"></a>Windows 10 の新しい Api 17763 をビルドします。

新規および更新された API 名前空間に加えられた利用可能な Windows 10 ビルド 17763 の開発者 (年 2018年 10 月とも呼ばれます Update またはバージョン 1809)。 このリリースで追加または変更された名前空間について公開されているドキュメントの完全な一覧を以下に示します。

前の一般リリースで追加された Api については、 [Windows 10 April Update の新しい Api](windows-10-build-17134-api-diff.md)を参照してください。

## <a name="windowsai"></a>Windows.AI

### [<a name="windowsaimachinelearning"></a>Windows.AI.MachineLearning](https://docs.microsoft.com/uwp/api/windows.ai.machinelearning)

#### [<a name="ilearningmodelfeaturedescriptor"></a>ILearningModelFeatureDescriptor](https://docs.microsoft.com/uwp/api/windows.ai.machinelearning.ilearningmodelfeaturedescriptor)

ILearningModelFeatureDescriptor <br> ILearningModelFeatureDescriptor.Description <br> ILearningModelFeatureDescriptor.IsRequired <br> ILearningModelFeatureDescriptor.Kind <br> ILearningModelFeatureDescriptor.Name

#### [<a name="ilearningmodelfeaturevalue"></a>ILearningModelFeatureValue](https://docs.microsoft.com/uwp/api/windows.ai.machinelearning.ilearningmodelfeaturevalue)

ILearningModelFeatureValue <br> ILearningModelFeatureValue.Kind

#### [<a name="ilearningmodeloperatorprovider"></a>ILearningModelOperatorProvider](https://docs.microsoft.com/uwp/api/windows.ai.machinelearning.ilearningmodeloperatorprovider)

ILearningModelOperatorProvider

#### [<a name="imagefeaturedescriptor"></a>ImageFeatureDescriptor](https://docs.microsoft.com/uwp/api/windows.ai.machinelearning.imagefeaturedescriptor)

ImageFeatureDescriptor <br> ImageFeatureDescriptor.BitmapAlphaMode <br> ImageFeatureDescriptor.BitmapPixelFormat <br> ImageFeatureDescriptor.Description <br> ImageFeatureDescriptor.Height <br> ImageFeatureDescriptor.IsRequired <br> ImageFeatureDescriptor.Kind <br> ImageFeatureDescriptor.Name <br> ImageFeatureDescriptor.Width

#### [<a name="imagefeaturevalue"></a>ImageFeatureValue](https://docs.microsoft.com/uwp/api/windows.ai.machinelearning.imagefeaturevalue)

ImageFeatureValue <br> ImageFeatureValue.CreateFromVideoFrame <br> ImageFeatureValue.Kind <br> ImageFeatureValue.VideoFrame

#### [<a name="itensor"></a>ITensor](https://docs.microsoft.com/uwp/api/windows.ai.machinelearning.itensor)

ITensor <br> ITensor.Shape <br> ITensor.TensorKind

#### [<a name="learningmodel"></a>LearningModel](https://docs.microsoft.com/uwp/api/windows.ai.machinelearning.learningmodel)

LearningModel <br> LearningModel.Author <br> LearningModel.Close <br> LearningModel.Description <br> LearningModel.Domain <br> LearningModel.InputFeatures <br> LearningModel.LoadFromFilePath <br> LearningModel.LoadFromFilePath <br> LearningModel.LoadFromStorageFileAsync <br> LearningModel.LoadFromStorageFileAsync <br> LearningModel.LoadFromStream <br> LearningModel.LoadFromStream <br> LearningModel.LoadFromStreamAsync <br> LearningModel.LoadFromStreamAsync <br> LearningModel.Metadata <br> LearningModel.Name <br> LearningModel.OutputFeatures <br> LearningModel.Version

#### [<a name="learningmodelbinding"></a>LearningModelBinding](https://docs.microsoft.com/uwp/api/windows.ai.machinelearning.learningmodelbinding)

LearningModelBinding <br> LearningModelBinding.Bind <br> LearningModelBinding.Bind <br> LearningModelBinding.Clear <br> LearningModelBinding.First <br> LearningModelBinding.HasKey <br> LearningModelBinding。 #ctor <br> LearningModelBinding.Lookup <br> LearningModelBinding.Size <br> LearningModelBinding.Split

#### [<a name="learningmodeldevice"></a>LearningModelDevice](https://docs.microsoft.com/uwp/api/windows.ai.machinelearning.learningmodeldevice)

LearningModelDevice <br> LearningModelDevice.AdapterId <br> LearningModelDevice.CreateFromDirect3D11Device <br> LearningModelDevice.Direct3D11Device <br> LearningModelDevice。 #ctor

#### [<a name="learningmodeldevicekind"></a>LearningModelDeviceKind](https://docs.microsoft.com/uwp/api/windows.ai.machinelearning.learningmodeldevicekind)

LearningModelDeviceKind

#### [<a name="learningmodelevaluationresult"></a>LearningModelEvaluationResult](https://docs.microsoft.com/uwp/api/windows.ai.machinelearning.learningmodelevaluationresult)

LearningModelEvaluationResult <br> LearningModelEvaluationResult.CorrelationId <br> LearningModelEvaluationResult.ErrorStatus <br> LearningModelEvaluationResult.Outputs <br> LearningModelEvaluationResult.Succeeded

#### [<a name="learningmodelfeaturekind"></a>LearningModelFeatureKind](https://docs.microsoft.com/uwp/api/windows.ai.machinelearning.learningmodelfeaturekind)

LearningModelFeatureKind

#### [<a name="learningmodelsession"></a>LearningModelSession](https://docs.microsoft.com/uwp/api/windows.ai.machinelearning.learningmodelsession)

LearningModelSession <br> LearningModelSession.Close <br> LearningModelSession.Device <br> LearningModelSession.Evaluate <br> LearningModelSession.EvaluateAsync <br> LearningModelSession.EvaluateFeatures <br> LearningModelSession.EvaluateFeaturesAsync <br> LearningModelSession.EvaluationProperties <br> LearningModelSession。 #ctor <br> LearningModelSession。 #ctor <br> LearningModelSession.Model

#### [<a name="mapfeaturedescriptor"></a>MapFeatureDescriptor](https://docs.microsoft.com/uwp/api/windows.ai.machinelearning.mapfeaturedescriptor)

MapFeatureDescriptor <br> MapFeatureDescriptor.Description <br> MapFeatureDescriptor.IsRequired <br> MapFeatureDescriptor.KeyKind <br> MapFeatureDescriptor.Kind <br> MapFeatureDescriptor.Name <br> MapFeatureDescriptor.ValueDescriptor

#### [<a name="sequencefeaturedescriptor"></a>SequenceFeatureDescriptor](https://docs.microsoft.com/uwp/api/windows.ai.machinelearning.sequencefeaturedescriptor)

SequenceFeatureDescriptor <br> SequenceFeatureDescriptor.Description <br> SequenceFeatureDescriptor.ElementDescriptor <br> SequenceFeatureDescriptor.IsRequired <br> SequenceFeatureDescriptor.Kind <br> SequenceFeatureDescriptor.Name

#### [<a name="tensorboolean"></a>TensorBoolean](https://docs.microsoft.com/uwp/api/windows.ai.machinelearning.tensorboolean)

TensorBoolean <br> TensorBoolean.Create <br> TensorBoolean.Create <br> TensorBoolean.CreateFromArray <br> TensorBoolean.CreateFromIterable <br> TensorBoolean.GetAsVectorView <br> TensorBoolean.Kind <br> TensorBoolean.Shape <br> TensorBoolean.TensorKind

#### [<a name="tensordouble"></a>TensorDouble](https://docs.microsoft.com/uwp/api/windows.ai.machinelearning.tensordouble)

TensorDouble <br> TensorDouble.Create <br> TensorDouble.Create <br> TensorDouble.CreateFromArray <br> TensorDouble.CreateFromIterable <br> TensorDouble.GetAsVectorView <br> TensorDouble.Kind <br> TensorDouble.Shape <br> TensorDouble.TensorKind

#### [<a name="tensorfeaturedescriptor"></a>TensorFeatureDescriptor](https://docs.microsoft.com/uwp/api/windows.ai.machinelearning.tensorfeaturedescriptor)

TensorFeatureDescriptor <br> TensorFeatureDescriptor.Description <br> TensorFeatureDescriptor.IsRequired <br> TensorFeatureDescriptor.Kind <br> TensorFeatureDescriptor.Name <br> TensorFeatureDescriptor.Shape <br> TensorFeatureDescriptor.TensorKind

#### [<a name="tensorfloat"></a>TensorFloat](https://docs.microsoft.com/uwp/api/windows.ai.machinelearning.tensorfloat)

TensorFloat <br> TensorFloat.Create <br> TensorFloat.Create <br> TensorFloat.CreateFromArray <br> TensorFloat.CreateFromIterable <br> TensorFloat.GetAsVectorView <br> TensorFloat.Kind <br> TensorFloat.Shape <br> TensorFloat.TensorKind

#### [<a name="tensorfloat16bit"></a>TensorFloat16Bit](https://docs.microsoft.com/uwp/api/windows.ai.machinelearning.tensorfloat16bit)

TensorFloat16Bit <br> TensorFloat16Bit.Create <br> TensorFloat16Bit.Create <br> TensorFloat16Bit.CreateFromArray <br> TensorFloat16Bit.CreateFromIterable <br> TensorFloat16Bit.GetAsVectorView <br> TensorFloat16Bit.Kind <br> TensorFloat16Bit.Shape <br> TensorFloat16Bit.TensorKind

#### [<a name="tensorint16bit"></a>TensorInt16Bit](https://docs.microsoft.com/uwp/api/windows.ai.machinelearning.tensorint16bit)

TensorInt16Bit <br> TensorInt16Bit.Create <br> TensorInt16Bit.Create <br> TensorInt16Bit.CreateFromArray <br> TensorInt16Bit.CreateFromIterable <br> TensorInt16Bit.GetAsVectorView <br> TensorInt16Bit.Kind <br> TensorInt16Bit.Shape <br> TensorInt16Bit.TensorKind

#### [<a name="tensorint32bit"></a>TensorInt32Bit](https://docs.microsoft.com/uwp/api/windows.ai.machinelearning.tensorint32bit)

TensorInt32Bit <br> TensorInt32Bit.Create <br> TensorInt32Bit.Create <br> TensorInt32Bit.CreateFromArray <br> TensorInt32Bit.CreateFromIterable <br> TensorInt32Bit.GetAsVectorView <br> TensorInt32Bit.Kind <br> TensorInt32Bit.Shape <br> TensorInt32Bit.TensorKind

#### [<a name="tensorint64bit"></a>TensorInt64Bit](https://docs.microsoft.com/uwp/api/windows.ai.machinelearning.tensorint64bit)

TensorInt64Bit <br> TensorInt64Bit.Create <br> TensorInt64Bit.Create <br> TensorInt64Bit.CreateFromArray <br> TensorInt64Bit.CreateFromIterable <br> TensorInt64Bit.GetAsVectorView <br> TensorInt64Bit.Kind <br> TensorInt64Bit.Shape <br> TensorInt64Bit.TensorKind

#### [<a name="tensorint8bit"></a>TensorInt8Bit](https://docs.microsoft.com/uwp/api/windows.ai.machinelearning.tensorint8bit)

TensorInt8Bit <br> TensorInt8Bit.Create <br> TensorInt8Bit.Create <br> TensorInt8Bit.CreateFromArray <br> TensorInt8Bit.CreateFromIterable <br> TensorInt8Bit.GetAsVectorView <br> TensorInt8Bit.Kind <br> TensorInt8Bit.Shape <br> TensorInt8Bit.TensorKind

#### [<a name="tensorkind"></a>TensorKind](https://docs.microsoft.com/uwp/api/windows.ai.machinelearning.tensorkind)

TensorKind

#### [<a name="tensorstring"></a>TensorString](https://docs.microsoft.com/uwp/api/windows.ai.machinelearning.tensorstring)

TensorString <br> TensorString.Create <br> TensorString.Create <br> TensorString.CreateFromArray <br> TensorString.CreateFromIterable <br> TensorString.GetAsVectorView <br> TensorString.Kind <br> TensorString.Shape <br> TensorString.TensorKind

#### [<a name="tensoruint16bit"></a>TensorUInt16Bit](https://docs.microsoft.com/uwp/api/windows.ai.machinelearning.tensoruint16bit)

TensorUInt16Bit <br> TensorUInt16Bit.Create <br> TensorUInt16Bit.Create <br> TensorUInt16Bit.CreateFromArray <br> TensorUInt16Bit.CreateFromIterable <br> TensorUInt16Bit.GetAsVectorView <br> TensorUInt16Bit.Kind <br> TensorUInt16Bit.Shape <br> TensorUInt16Bit.TensorKind

#### [<a name="tensoruint32bit"></a>TensorUInt32Bit](https://docs.microsoft.com/uwp/api/windows.ai.machinelearning.tensoruint32bit)

TensorUInt32Bit <br> TensorUInt32Bit.Create <br> TensorUInt32Bit.Create <br> TensorUInt32Bit.CreateFromArray <br> TensorUInt32Bit.CreateFromIterable <br> TensorUInt32Bit.GetAsVectorView <br> TensorUInt32Bit.Kind <br> TensorUInt32Bit.Shape <br> TensorUInt32Bit.TensorKind

#### [<a name="tensoruint64bit"></a>TensorUInt64Bit](https://docs.microsoft.com/uwp/api/windows.ai.machinelearning.tensoruint64bit)

TensorUInt64Bit <br> TensorUInt64Bit.Create <br> TensorUInt64Bit.Create <br> TensorUInt64Bit.CreateFromArray <br> TensorUInt64Bit.CreateFromIterable <br> TensorUInt64Bit.GetAsVectorView <br> TensorUInt64Bit.Kind <br> TensorUInt64Bit.Shape <br> TensorUInt64Bit.TensorKind

#### [<a name="tensoruint8bit"></a>TensorUInt8Bit](https://docs.microsoft.com/uwp/api/windows.ai.machinelearning.tensoruint8bit)

TensorUInt8Bit <br> TensorUInt8Bit.Create <br> TensorUInt8Bit.Create <br> TensorUInt8Bit.CreateFromArray <br> TensorUInt8Bit.CreateFromIterable <br> TensorUInt8Bit.GetAsVectorView <br> TensorUInt8Bit.Kind <br> TensorUInt8Bit.Shape <br> TensorUInt8Bit.TensorKind

## <a name="windowsapplicationmodel"></a>Windows.ApplicationModel

### [<a name="windowsapplicationmodelcalls"></a>Windows.ApplicationModel.Calls](https://docs.microsoft.com/uwp/api/windows.applicationmodel.calls)

#### [<a name="voipcallcoordinator"></a>VoipCallCoordinator](https://docs.microsoft.com/uwp/api/windows.applicationmodel.calls.voipcallcoordinator)

VoipCallCoordinator.ReserveCallResourcesAsync

### [<a name="windowsapplicationmodelchat"></a>Windows.ApplicationModel.Chat](https://docs.microsoft.com/uwp/api/windows.applicationmodel.chat)

#### [<a name="chatcapabilitiesmanager"></a>ChatCapabilitiesManager](https://docs.microsoft.com/uwp/api/windows.applicationmodel.chat.chatcapabilitiesmanager)

ChatCapabilitiesManager.GetCachedCapabilitiesAsync <br> ChatCapabilitiesManager.GetCapabilitiesFromNetworkAsync

#### [<a name="rcsmanager"></a>RcsManager](https://docs.microsoft.com/uwp/api/windows.applicationmodel.chat.rcsmanager)

RcsManager.TransportListChanged

### [<a name="windowsapplicationmodeldatatransfer"></a>Windows.ApplicationModel.DataTransfer](https://docs.microsoft.com/uwp/api/windows.applicationmodel.datatransfer)

#### [<a name="clipboard"></a>クリップボード](https://docs.microsoft.com/uwp/api/windows.applicationmodel.datatransfer.clipboard)

Clipboard.ClearHistory <br> Clipboard.DeleteItemFromHistory <br> Clipboard.GetHistoryItemsAsync <br> Clipboard.HistoryChanged <br> Clipboard.HistoryEnabledChanged <br> Clipboard.IsHistoryEnabled <br> Clipboard.IsRoamingEnabled <br> Clipboard.RoamingEnabledChanged <br> Clipboard.SetContentWithOptions <br> Clipboard.SetHistoryItemAsContent

#### [<a name="clipboardcontentoptions"></a>ClipboardContentOptions](https://docs.microsoft.com/uwp/api/windows.applicationmodel.datatransfer.clipboardcontentoptions)

ClipboardContentOptions <br> ClipboardContentOptions。 #ctor <br> ClipboardContentOptions.HistoryFormats <br> ClipboardContentOptions.IsAllowedInHistory <br> ClipboardContentOptions.IsRoamable <br> ClipboardContentOptions.RoamingFormats

#### [<a name="clipboardhistorychangedeventargs"></a>ClipboardHistoryChangedEventArgs](https://docs.microsoft.com/uwp/api/windows.applicationmodel.datatransfer.clipboardhistorychangedeventargs)

ClipboardHistoryChangedEventArgs

#### [<a name="clipboardhistoryitem"></a>ClipboardHistoryItem](https://docs.microsoft.com/uwp/api/windows.applicationmodel.datatransfer.clipboardhistoryitem)

ClipboardHistoryItem <br> ClipboardHistoryItem.Content <br> ClipboardHistoryItem.Id <br> ClipboardHistoryItem.Timestamp

#### [<a name="clipboardhistoryitemsresult"></a>ClipboardHistoryItemsResult](https://docs.microsoft.com/uwp/api/windows.applicationmodel.datatransfer.clipboardhistoryitemsresult)

ClipboardHistoryItemsResult <br> ClipboardHistoryItemsResult.Items <br> ClipboardHistoryItemsResult.Status

#### [<a name="clipboardhistoryitemsresultstatus"></a>ClipboardHistoryItemsResultStatus](https://docs.microsoft.com/uwp/api/windows.applicationmodel.datatransfer.clipboardhistoryitemsresultstatus)

ClipboardHistoryItemsResultStatus

#### [<a name="datapackagepropertysetview"></a>DataPackagePropertySetView](https://docs.microsoft.com/uwp/api/windows.applicationmodel.datatransfer.datapackagepropertysetview)

DataPackagePropertySetView.IsFromRoamingClipboard

#### [<a name="sethistoryitemascontentstatus"></a>SetHistoryItemAsContentStatus](https://docs.microsoft.com/uwp/api/windows.applicationmodel.datatransfer.sethistoryitemascontentstatus)

SetHistoryItemAsContentStatus

### [<a name="windowsapplicationmodelstorepreviewinstallcontrol"></a>Windows.ApplicationModel.Store.Preview.InstallControl](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.preview.installcontrol)

#### [<a name="appinstallationtoastnotificationmode"></a>AppInstallationToastNotificationMode](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.preview.installcontrol.appinstallationtoastnotificationmode)

AppInstallationToastNotificationMode

#### [<a name="appinstallitem"></a>AppInstallItem](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.preview.installcontrol.appinstallitem)

AppInstallItem.CompletedInstallToastNotificationMode <br> AppInstallItem.InstallInProgressToastNotificationMode <br> AppInstallItem.PinToDesktopAfterInstall <br> AppInstallItem.PinToStartAfterInstall <br> AppInstallItem.PinToTaskbarAfterInstall

#### [<a name="appinstallmanager"></a>AppInstallManager](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.preview.installcontrol.appinstallmanager)

AppInstallManager.CanInstallForAllUsers

#### [<a name="appinstalloptions"></a>AppInstallOptions](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.preview.installcontrol.appinstalloptions)

AppInstallOptions.CampaignId <br> AppInstallOptions.CompletedInstallToastNotificationMode <br> AppInstallOptions.ExtendedCampaignId <br> AppInstallOptions.InstallForAllUsers <br> AppInstallOptions.InstallInProgressToastNotificationMode <br> AppInstallOptions.PinToDesktopAfterInstall <br> AppInstallOptions.PinToStartAfterInstall <br> AppInstallOptions.PinToTaskbarAfterInstall <br> AppInstallOptions.StageButDoNotInstall

#### [<a name="appupdateoptions"></a>AppUpdateOptions](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.preview.installcontrol.appupdateoptions)

AppUpdateOptions.AutomaticallyDownloadAndInstallUpdateIfFound

### [<a name="windowsapplicationmodelstorepreview"></a>Windows.ApplicationModel.Store.Preview](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.preview)

#### [<a name="deliveryoptimizationdownloadmode"></a>DeliveryOptimizationDownloadMode](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.preview.deliveryoptimizationdownloadmode)

DeliveryOptimizationDownloadMode

#### [<a name="deliveryoptimizationdownloadmodesource"></a>DeliveryOptimizationDownloadModeSource](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.preview.deliveryoptimizationdownloadmodesource)

DeliveryOptimizationDownloadModeSource

#### [<a name="deliveryoptimizationsettings"></a>DeliveryOptimizationSettings](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.preview.deliveryoptimizationsettings)

DeliveryOptimizationSettings <br> DeliveryOptimizationSettings.DownloadMode <br> DeliveryOptimizationSettings.DownloadModeSource <br> DeliveryOptimizationSettings.GetCurrentSettings

#### [<a name="storeconfiguration"></a>StoreConfiguration](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.preview.storeconfiguration)

StoreConfiguration.IsPinToDesktopSupported <br> StoreConfiguration.IsPinToStartSupported <br> StoreConfiguration.IsPinToTaskbarSupported <br> StoreConfiguration.PinToDesktop <br> StoreConfiguration.PinToDesktopForUser

### [<a name="windowsapplicationmodeluseractivities"></a>Windows.ApplicationModel.UserActivities](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities)

#### [<a name="useractivity"></a>UserActivity](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.useractivity)

UserActivity.IsRoamable

### [<a name="windowsapplicationmodel"></a>Windows.ApplicationModel](https://docs.microsoft.com/uwp/api/windows.applicationmodel)

#### [<a name="appinstallerinfo"></a>AppInstallerInfo](https://docs.microsoft.com/uwp/api/windows.applicationmodel.appinstallerinfo)

AppInstallerInfo <br> AppInstallerInfo.Uri

#### [<a name="limitedaccessfeaturerequestresult"></a>LimitedAccessFeatureRequestResult](https://docs.microsoft.com/uwp/api/windows.applicationmodel.limitedaccessfeaturerequestresult)

LimitedAccessFeatureRequestResult <br> LimitedAccessFeatureRequestResult.EstimatedRemovalDate <br> LimitedAccessFeatureRequestResult.FeatureId <br> LimitedAccessFeatureRequestResult.Status

#### [<a name="limitedaccessfeatures"></a>LimitedAccessFeatures](https://docs.microsoft.com/uwp/api/windows.applicationmodel.limitedaccessfeatures)

LimitedAccessFeatures <br> LimitedAccessFeatures.TryUnlockFeature

#### [<a name="limitedaccessfeaturestatus"></a>LimitedAccessFeatureStatus](https://docs.microsoft.com/uwp/api/windows.applicationmodel.limitedaccessfeaturestatus)

LimitedAccessFeatureStatus

#### [<a name="package"></a>Package](https://docs.microsoft.com/uwp/api/windows.applicationmodel.package)

Package.CheckUpdateAvailabilityAsync <br> Package.GetAppInstallerInfo

#### [<a name="packageupdateavailability"></a>PackageUpdateAvailability](https://docs.microsoft.com/uwp/api/windows.applicationmodel.packageupdateavailability)

PackageUpdateAvailability

#### [<a name="packageupdateavailabilityresult"></a>PackageUpdateAvailabilityResult](https://docs.microsoft.com/uwp/api/windows.applicationmodel.packageupdateavailabilityresult)

PackageUpdateAvailabilityResult <br> PackageUpdateAvailabilityResult.Availability <br> PackageUpdateAvailabilityResult.ExtendedError

## <a name="windowsdata"></a>Windows.Data

### [<a name="windowsdatatext"></a>Windows.Data.Text](https://docs.microsoft.com/uwp/api/windows.data.text)

#### [<a name="textpredictiongenerator"></a>TextPredictionGenerator](https://docs.microsoft.com/uwp/api/windows.data.text.textpredictiongenerator)

TextPredictionGenerator.GetCandidatesAsync <br> TextPredictionGenerator.GetNextWordCandidatesAsync <br> TextPredictionGenerator.InputScope

#### [<a name="textpredictionoptions"></a>TextPredictionOptions](https://docs.microsoft.com/uwp/api/windows.data.text.textpredictionoptions)

TextPredictionOptions

## <a name="windowsdevices"></a>Windows.Devices

### [<a name="windowsdevicesdisplaycore"></a>Windows.Devices.Display.Core](https://docs.microsoft.com/uwp/api/windows.devices.display.core)

#### [<a name="displayadapter"></a>DisplayAdapter](https://docs.microsoft.com/uwp/api/windows.devices.display.core.displayadapter)

DisplayAdapter <br> DisplayAdapter.DeviceInterfacePath <br> DisplayAdapter.FromId <br> DisplayAdapter.Id <br> DisplayAdapter.PciDeviceId <br> DisplayAdapter.PciRevision <br> DisplayAdapter.PciSubSystemId <br> DisplayAdapter.PciVendorId <br> DisplayAdapter.Properties <br> DisplayAdapter.SourceCount

#### [<a name="displaybitsperchannel"></a>DisplayBitsPerChannel](https://docs.microsoft.com/uwp/api/windows.devices.display.core.displaybitsperchannel)

DisplayBitsPerChannel

#### [<a name="displaydevice"></a>DisplayDevice](https://docs.microsoft.com/uwp/api/windows.devices.display.core.displaydevice)

DisplayDevice <br> DisplayDevice.CreatePeriodicFence <br> DisplayDevice.CreatePrimary <br> DisplayDevice.CreateScanoutSource <br> DisplayDevice.CreateSimpleScanout <br> DisplayDevice.CreateTaskPool <br> DisplayDevice.IsCapabilitySupported <br> DisplayDevice.WaitForVBlank

#### [<a name="displaydevicecapability"></a>DisplayDeviceCapability](https://docs.microsoft.com/uwp/api/windows.devices.display.core.displaydevicecapability)

DisplayDeviceCapability

#### [<a name="displayfence"></a>DisplayFence](https://docs.microsoft.com/uwp/api/windows.devices.display.core.displayfence)

DisplayFence

#### [<a name="displaymanager"></a>ディスプレイ マネージャー](https://docs.microsoft.com/uwp/api/windows.devices.display.core.displaymanager)

ディスプレイ マネージャー <br> DisplayManager.Changed <br> DisplayManager.Close <br> DisplayManager.Create <br> DisplayManager.CreateDisplayDevice <br> DisplayManager.Disabled <br> DisplayManager.Enabled <br> DisplayManager.GetCurrentAdapters <br> DisplayManager.GetCurrentTargets <br> DisplayManager.PathsFailedOrInvalidated <br> DisplayManager.ReleaseTarget <br> DisplayManager.Start <br> DisplayManager.Stop <br> DisplayManager.TryAcquireTarget <br> DisplayManager.TryAcquireTargetsAndCreateEmptyState <br> DisplayManager.TryAcquireTargetsAndCreateSubstate <br> DisplayManager.TryAcquireTargetsAndReadCurrentState <br> DisplayManager.TryReadCurrentStateForAllTargets

#### [<a name="displaymanagerchangedeventargs"></a>DisplayManagerChangedEventArgs](https://docs.microsoft.com/uwp/api/windows.devices.display.core.displaymanagerchangedeventargs)

DisplayManagerChangedEventArgs <br> DisplayManagerChangedEventArgs.GetDeferral <br> DisplayManagerChangedEventArgs.Handled

#### [<a name="displaymanagerdisabledeventargs"></a>DisplayManagerDisabledEventArgs](https://docs.microsoft.com/uwp/api/windows.devices.display.core.displaymanagerdisabledeventargs)

DisplayManagerDisabledEventArgs <br> DisplayManagerDisabledEventArgs.GetDeferral <br> DisplayManagerDisabledEventArgs.Handled

#### [<a name="displaymanagerenabledeventargs"></a>DisplayManagerEnabledEventArgs](https://docs.microsoft.com/uwp/api/windows.devices.display.core.displaymanagerenabledeventargs)

DisplayManagerEnabledEventArgs <br> DisplayManagerEnabledEventArgs.GetDeferral <br> DisplayManagerEnabledEventArgs.Handled

#### [<a name="displaymanageroptions"></a>DisplayManagerOptions](https://docs.microsoft.com/uwp/api/windows.devices.display.core.displaymanageroptions)

DisplayManagerOptions

#### [<a name="displaymanagerpathsfailedorinvalidatedeventargs"></a>DisplayManagerPathsFailedOrInvalidatedEventArgs](https://docs.microsoft.com/uwp/api/windows.devices.display.core.displaymanagerpathsfailedorinvalidatedeventargs)

DisplayManagerPathsFailedOrInvalidatedEventArgs <br> DisplayManagerPathsFailedOrInvalidatedEventArgs.GetDeferral <br> DisplayManagerPathsFailedOrInvalidatedEventArgs.Handled

#### [<a name="displaymanagerresult"></a>DisplayManagerResult](https://docs.microsoft.com/uwp/api/windows.devices.display.core.displaymanagerresult)

DisplayManagerResult

#### [<a name="displaymanagerresultwithstate"></a>DisplayManagerResultWithState](https://docs.microsoft.com/uwp/api/windows.devices.display.core.displaymanagerresultwithstate)

DisplayManagerResultWithState <br> DisplayManagerResultWithState.ErrorCode <br> DisplayManagerResultWithState.ExtendedErrorCode <br> DisplayManagerResultWithState.State

#### [<a name="displaymodeinfo"></a>DisplayModeInfo](https://docs.microsoft.com/uwp/api/windows.devices.display.core.displaymodeinfo)

DisplayModeInfo <br> DisplayModeInfo.GetWireFormatSupportedBitsPerChannel <br> DisplayModeInfo.IsInterlaced <br> DisplayModeInfo.IsStereo <br> DisplayModeInfo.IsWireFormatSupported <br> DisplayModeInfo.PresentationRate <br> DisplayModeInfo.Properties <br> DisplayModeInfo.SourcePixelFormat <br> DisplayModeInfo.SourceResolution <br> DisplayModeInfo.TargetResolution

#### [<a name="displaymodequeryoptions"></a>DisplayModeQueryOptions](https://docs.microsoft.com/uwp/api/windows.devices.display.core.displaymodequeryoptions)

DisplayModeQueryOptions

#### [<a name="displaypath"></a>DisplayPath](https://docs.microsoft.com/uwp/api/windows.devices.display.core.displaypath)

DisplayPath <br> DisplayPath.ApplyPropertiesFromMode <br> DisplayPath.FindModes <br> DisplayPath.IsInterlaced <br> DisplayPath.IsStereo <br> DisplayPath.PresentationRate <br> DisplayPath.Properties <br> DisplayPath.Rotation <br> DisplayPath.Scaling <br> DisplayPath.SourcePixelFormat <br> DisplayPath.SourceResolution <br> DisplayPath.Status <br> DisplayPath.Target <br> DisplayPath.TargetResolution <br> DisplayPath.View <br> DisplayPath.WireFormat

#### [<a name="displaypathscaling"></a>DisplayPathScaling](https://docs.microsoft.com/uwp/api/windows.devices.display.core.displaypathscaling)

DisplayPathScaling

#### [<a name="displaypathstatus"></a>DisplayPathStatus](https://docs.microsoft.com/uwp/api/windows.devices.display.core.displaypathstatus)

DisplayPathStatus

#### [<a name="displaypresentationrate"></a>DisplayPresentationRate](https://docs.microsoft.com/uwp/api/windows.devices.display.core.displaypresentationrate)

DisplayPresentationRate

#### [<a name="displayprimarydescription"></a>DisplayPrimaryDescription](https://docs.microsoft.com/uwp/api/windows.devices.display.core.displayprimarydescription)

DisplayPrimaryDescription <br> DisplayPrimaryDescription.ColorSpace <br> DisplayPrimaryDescription.CreateWithProperties <br> DisplayPrimaryDescription。 #ctor <br> DisplayPrimaryDescription.Format <br> DisplayPrimaryDescription.Height <br> DisplayPrimaryDescription.IsStereo <br> DisplayPrimaryDescription.MultisampleDescription <br> DisplayPrimaryDescription.Properties <br> DisplayPrimaryDescription.Width

#### [<a name="displayrotation"></a>DisplayRotation](https://docs.microsoft.com/uwp/api/windows.devices.display.core.displayrotation)

DisplayRotation

#### [<a name="displayscanout"></a>DisplayScanout](https://docs.microsoft.com/uwp/api/windows.devices.display.core.displayscanout)

DisplayScanout

#### [<a name="displaysource"></a>DisplaySource](https://docs.microsoft.com/uwp/api/windows.devices.display.core.displaysource)

DisplaySource <br> DisplaySource.AdapterId <br> DisplaySource.GetMetadata <br> DisplaySource.SourceId

#### [<a name="displaystate"></a>DisplayState](https://docs.microsoft.com/uwp/api/windows.devices.display.core.displaystate)

DisplayState <br> DisplayState.CanConnectTargetToView <br> DisplayState.Clone <br> DisplayState.ConnectTarget <br> DisplayState.ConnectTarget <br> DisplayState.DisconnectTarget <br> DisplayState.GetPathForTarget <br> DisplayState.GetViewForTarget <br> DisplayState.IsReadOnly <br> DisplayState.IsStale <br> DisplayState.Properties <br> DisplayState.Targets <br> DisplayState.TryApply <br> DisplayState.TryFunctionalize <br> DisplayState.Views

#### [<a name="displaystateapplyoptions"></a>DisplayStateApplyOptions](https://docs.microsoft.com/uwp/api/windows.devices.display.core.displaystateapplyoptions)

DisplayStateApplyOptions

#### [<a name="displaystatefunctionalizeoptions"></a>DisplayStateFunctionalizeOptions](https://docs.microsoft.com/uwp/api/windows.devices.display.core.displaystatefunctionalizeoptions)

DisplayStateFunctionalizeOptions

#### [<a name="displaystateoperationresult"></a>DisplayStateOperationResult](https://docs.microsoft.com/uwp/api/windows.devices.display.core.displaystateoperationresult)

DisplayStateOperationResult <br> DisplayStateOperationResult.ExtendedErrorCode <br> DisplayStateOperationResult.Status

#### [<a name="displaystateoperationstatus"></a>DisplayStateOperationStatus](https://docs.microsoft.com/uwp/api/windows.devices.display.core.displaystateoperationstatus)

DisplayStateOperationStatus

#### [<a name="displaysurface"></a>DisplaySurface](https://docs.microsoft.com/uwp/api/windows.devices.display.core.displaysurface)

DisplaySurface

#### [<a name="displaytarget"></a>DisplayTarget](https://docs.microsoft.com/uwp/api/windows.devices.display.core.displaytarget)

DisplayTarget <br> DisplayTarget.Adapter <br> DisplayTarget.AdapterRelativeId <br> DisplayTarget.DeviceInterfacePath <br> DisplayTarget.IsConnected <br> DisplayTarget.IsEqual <br> DisplayTarget.IsSame <br> DisplayTarget.IsStale <br> DisplayTarget.IsVirtualModeEnabled <br> DisplayTarget.IsVirtualTopologyEnabled <br> DisplayTarget.MonitorPersistence <br> DisplayTarget.Properties <br> DisplayTarget.StableMonitorId <br> DisplayTarget.TryGetMonitor <br> DisplayTarget.UsageKind

#### [<a name="displaytargetpersistence"></a>DisplayTargetPersistence](https://docs.microsoft.com/uwp/api/windows.devices.display.core.displaytargetpersistence)

DisplayTargetPersistence

#### [<a name="displaytask"></a>DisplayTask](https://docs.microsoft.com/uwp/api/windows.devices.display.core.displaytask)

DisplayTask <br> DisplayTask.SetScanout <br> DisplayTask.SetWait

#### [<a name="displaytaskpool"></a>DisplayTaskPool](https://docs.microsoft.com/uwp/api/windows.devices.display.core.displaytaskpool)

DisplayTaskPool <br> DisplayTaskPool.CreateTask <br> DisplayTaskPool.ExecuteTask

#### [<a name="displaytasksignalkind"></a>DisplayTaskSignalKind](https://docs.microsoft.com/uwp/api/windows.devices.display.core.displaytasksignalkind)

DisplayTaskSignalKind

#### [<a name="displayview"></a>DisplayView](https://docs.microsoft.com/uwp/api/windows.devices.display.core.displayview)

DisplayView <br> DisplayView.ContentResolution <br> DisplayView.Paths <br> DisplayView.Properties <br> DisplayView.SetPrimaryPath

#### [<a name="displaywireformat"></a>DisplayWireFormat](https://docs.microsoft.com/uwp/api/windows.devices.display.core.displaywireformat)

DisplayWireFormat <br> DisplayWireFormat.BitsPerChannel <br> DisplayWireFormat.ColorSpace <br> DisplayWireFormat.CreateWithProperties <br> DisplayWireFormat。 #ctor <br> DisplayWireFormat.Eotf <br> DisplayWireFormat.HdrMetadata <br> DisplayWireFormat.PixelEncoding <br> DisplayWireFormat.Properties

#### [<a name="displaywireformatcolorspace"></a>DisplayWireFormatColorSpace](https://docs.microsoft.com/uwp/api/windows.devices.display.core.displaywireformatcolorspace)

DisplayWireFormatColorSpace

#### [<a name="displaywireformateotf"></a>DisplayWireFormatEotf](https://docs.microsoft.com/uwp/api/windows.devices.display.core.displaywireformateotf)

DisplayWireFormatEotf

#### [<a name="displaywireformathdrmetadata"></a>DisplayWireFormatHdrMetadata](https://docs.microsoft.com/uwp/api/windows.devices.display.core.displaywireformathdrmetadata)

DisplayWireFormatHdrMetadata

#### [<a name="displaywireformatpixelencoding"></a>DisplayWireFormatPixelEncoding](https://docs.microsoft.com/uwp/api/windows.devices.display.core.displaywireformatpixelencoding)

DisplayWireFormatPixelEncoding

### [<a name="windowsdevicesenumeration"></a>Windows.Devices.Enumeration](https://docs.microsoft.com/uwp/api/windows.devices.enumeration)

#### [<a name="deviceinformationpairing"></a>DeviceInformationPairing](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformationpairing)

DeviceInformationPairing.TryRegisterForAllInboundPairingRequestsWithProtectionLevel

### [<a name="windowsdeviceslightseffects"></a>Windows.Devices.Lights.Effects](https://docs.microsoft.com/uwp/api/windows.devices.lights.effects)

#### [<a name="ilamparrayeffect"></a>ILampArrayEffect](https://docs.microsoft.com/uwp/api/windows.devices.lights.effects.ilamparrayeffect)

ILampArrayEffect <br> ILampArrayEffect.ZIndex

#### [<a name="lamparraybitmapeffect"></a>LampArrayBitmapEffect](https://docs.microsoft.com/uwp/api/windows.devices.lights.effects.lamparraybitmapeffect)

LampArrayBitmapEffect <br> LampArrayBitmapEffect.BitmapRequested <br> LampArrayBitmapEffect.Duration <br> LampArrayBitmapEffect。 #ctor <br> LampArrayBitmapEffect.StartDelay <br> LampArrayBitmapEffect.SuggestedBitmapSize <br> LampArrayBitmapEffect.UpdateInterval <br> LampArrayBitmapEffect.ZIndex

#### [<a name="lamparraybitmaprequestedeventargs"></a>LampArrayBitmapRequestedEventArgs](https://docs.microsoft.com/uwp/api/windows.devices.lights.effects.lamparraybitmaprequestedeventargs)

LampArrayBitmapRequestedEventArgs <br> LampArrayBitmapRequestedEventArgs.SinceStarted <br> LampArrayBitmapRequestedEventArgs.UpdateBitmap

#### [<a name="lamparrayblinkeffect"></a>LampArrayBlinkEffect](https://docs.microsoft.com/uwp/api/windows.devices.lights.effects.lamparrayblinkeffect)

LampArrayBlinkEffect <br> LampArrayBlinkEffect.AttackDuration <br> LampArrayBlinkEffect.Color <br> LampArrayBlinkEffect.DecayDuration <br> LampArrayBlinkEffect。 #ctor <br> LampArrayBlinkEffect.Occurrences <br> LampArrayBlinkEffect.RepetitionDelay <br> LampArrayBlinkEffect.RepetitionMode <br> LampArrayBlinkEffect.StartDelay <br> LampArrayBlinkEffect.SustainDuration <br> LampArrayBlinkEffect.ZIndex

#### [<a name="lamparraycolorrampeffect"></a>LampArrayColorRampEffect](https://docs.microsoft.com/uwp/api/windows.devices.lights.effects.lamparraycolorrampeffect)

LampArrayColorRampEffect <br> LampArrayColorRampEffect.Color <br> LampArrayColorRampEffect.CompletionBehavior <br> LampArrayColorRampEffect。 #ctor <br> LampArrayColorRampEffect.RampDuration <br> LampArrayColorRampEffect.StartDelay <br> LampArrayColorRampEffect.ZIndex

#### [<a name="lamparraycustomeffect"></a>LampArrayCustomEffect](https://docs.microsoft.com/uwp/api/windows.devices.lights.effects.lamparraycustomeffect)

LampArrayCustomEffect <br> LampArrayCustomEffect.Duration <br> LampArrayCustomEffect。 #ctor <br> LampArrayCustomEffect.UpdateInterval <br> LampArrayCustomEffect.UpdateRequested <br> LampArrayCustomEffect.ZIndex

#### [<a name="lamparrayeffectcompletionbehavior"></a>LampArrayEffectCompletionBehavior](https://docs.microsoft.com/uwp/api/windows.devices.lights.effects.lamparrayeffectcompletionbehavior)

LampArrayEffectCompletionBehavior

#### [<a name="lamparrayeffectplaylist"></a>LampArrayEffectPlaylist](https://docs.microsoft.com/uwp/api/windows.devices.lights.effects.lamparrayeffectplaylist)

LampArrayEffectPlaylist <br> LampArrayEffectPlaylist.Append <br> LampArrayEffectPlaylist.EffectStartMode <br> LampArrayEffectPlaylist.First <br> LampArrayEffectPlaylist.GetAt <br> LampArrayEffectPlaylist.GetMany <br> LampArrayEffectPlaylist.IndexOf <br> LampArrayEffectPlaylist。 #ctor <br> LampArrayEffectPlaylist.Occurrences <br> LampArrayEffectPlaylist.OverrideZIndex <br> LampArrayEffectPlaylist.Pause <br> LampArrayEffectPlaylist.PauseAll <br> LampArrayEffectPlaylist.RepetitionMode <br> LampArrayEffectPlaylist.Size <br> LampArrayEffectPlaylist.Start <br> LampArrayEffectPlaylist.StartAll <br> LampArrayEffectPlaylist.Stop <br> LampArrayEffectPlaylist.StopAll

#### [<a name="lamparrayeffectstartmode"></a>LampArrayEffectStartMode](https://docs.microsoft.com/uwp/api/windows.devices.lights.effects.lamparrayeffectstartmode)

LampArrayEffectStartMode

#### [<a name="lamparrayrepetitionmode"></a>LampArrayRepetitionMode](https://docs.microsoft.com/uwp/api/windows.devices.lights.effects.lamparrayrepetitionmode)

LampArrayRepetitionMode

#### [<a name="lamparraysolideffect"></a>LampArraySolidEffect](https://docs.microsoft.com/uwp/api/windows.devices.lights.effects.lamparraysolideffect)

LampArraySolidEffect <br> LampArraySolidEffect.Color <br> LampArraySolidEffect.CompletionBehavior <br> LampArraySolidEffect.Duration <br> LampArraySolidEffect。 #ctor <br> LampArraySolidEffect.StartDelay <br> LampArraySolidEffect.ZIndex

#### [<a name="lamparrayupdaterequestedeventargs"></a>LampArrayUpdateRequestedEventArgs](https://docs.microsoft.com/uwp/api/windows.devices.lights.effects.lamparrayupdaterequestedeventargs)

LampArrayUpdateRequestedEventArgs <br> LampArrayUpdateRequestedEventArgs.SetColor <br> LampArrayUpdateRequestedEventArgs.SetColorForIndex <br> LampArrayUpdateRequestedEventArgs.SetColorsForIndices <br> LampArrayUpdateRequestedEventArgs.SetSingleColorForIndices <br> LampArrayUpdateRequestedEventArgs.SinceStarted

### [<a name="windowsdeviceslights"></a>Windows.Devices.Lights](https://docs.microsoft.com/uwp/api/windows.devices.lights)

#### [<a name="lamparray"></a>LampArray](https://docs.microsoft.com/uwp/api/windows.devices.lights.lamparray)

LampArray <br> LampArray.BoundingBox <br> LampArray.BrightnessLevel <br> LampArray.DeviceId <br> LampArray.FromIdAsync <br> LampArray.GetDeviceSelector <br> LampArray.GetIndicesForKey <br> LampArray.GetIndicesForPurposes <br> LampArray.GetLampInfo <br> LampArray.HardwareProductId <br> LampArray.HardwareVendorId <br> LampArray.HardwareVersion <br> LampArray.IsConnected <br> LampArray.IsEnabled <br> LampArray.LampArrayKind <br> LampArray.LampCount <br> LampArray.MinUpdateInterval <br> LampArray.RequestMessageAsync <br> LampArray.SendMessageAsync <br> LampArray.SetColor <br> LampArray.SetColorForIndex <br> LampArray.SetColorsForIndices <br> LampArray.SetColorsForKey <br> LampArray.SetColorsForKeys <br> LampArray.SetColorsForPurposes <br> LampArray.SetSingleColorForIndices <br> LampArray.SupportsVirtualKeys

#### [<a name="lamparraykind"></a>LampArrayKind](https://docs.microsoft.com/uwp/api/windows.devices.lights.lamparraykind)

LampArrayKind

#### [<a name="lampinfo"></a>LampInfo](https://docs.microsoft.com/uwp/api/windows.devices.lights.lampinfo)

LampInfo <br> LampInfo.BlueLevelCount <br> LampInfo.FixedColor <br> LampInfo.GainLevelCount <br> LampInfo.GetNearestSupportedColor <br> LampInfo.GreenLevelCount <br> LampInfo.Index <br> LampInfo.Position <br> LampInfo.Purposes <br> LampInfo.RedLevelCount <br> LampInfo.UpdateLatency

#### [<a name="lamppurposes"></a>LampPurposes](https://docs.microsoft.com/uwp/api/windows.devices.lights.lamppurposes)

LampPurposes

### [<a name="windowsdevicespointofserviceprovider"></a>Windows.Devices.PointOfService.Provider](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.provider)

#### [<a name="barcodescannerdisablescannerrequest"></a>BarcodeScannerDisableScannerRequest](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.provider.barcodescannerdisablescannerrequest)

BarcodeScannerDisableScannerRequest.ReportFailedAsync <br> BarcodeScannerDisableScannerRequest.ReportFailedAsync

#### [<a name="barcodescannerenablescannerrequest"></a>BarcodeScannerEnableScannerRequest](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.provider.barcodescannerenablescannerrequest)

BarcodeScannerEnableScannerRequest.ReportFailedAsync <br> BarcodeScannerEnableScannerRequest.ReportFailedAsync

#### [<a name="barcodescannerframereader"></a>BarcodeScannerFrameReader](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.provider.barcodescannerframereader)

BarcodeScannerFrameReader <br> BarcodeScannerFrameReader.Close <br> BarcodeScannerFrameReader.Connection <br> BarcodeScannerFrameReader.FrameArrived <br> BarcodeScannerFrameReader.StartAsync <br> BarcodeScannerFrameReader.StopAsync <br> BarcodeScannerFrameReader.TryAcquireLatestFrameAsync

#### [<a name="barcodescannerframereaderframearrivedeventargs"></a>BarcodeScannerFrameReaderFrameArrivedEventArgs](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.provider.barcodescannerframereaderframearrivedeventargs)

BarcodeScannerFrameReaderFrameArrivedEventArgs <br> BarcodeScannerFrameReaderFrameArrivedEventArgs.GetDeferral

#### [<a name="barcodescannergetsymbologyattributesrequest"></a>BarcodeScannerGetSymbologyAttributesRequest](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.provider.barcodescannergetsymbologyattributesrequest)

BarcodeScannerGetSymbologyAttributesRequest.ReportFailedAsync <br> BarcodeScannerGetSymbologyAttributesRequest.ReportFailedAsync

#### [<a name="barcodescannerhidevideopreviewrequest"></a>BarcodeScannerHideVideoPreviewRequest](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.provider.barcodescannerhidevideopreviewrequest)

BarcodeScannerHideVideoPreviewRequest.ReportFailedAsync <br> BarcodeScannerHideVideoPreviewRequest.ReportFailedAsync

#### [<a name="barcodescannerproviderconnection"></a>BarcodeScannerProviderConnection](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.provider.barcodescannerproviderconnection)

BarcodeScannerProviderConnection.CreateFrameReaderAsync <br> BarcodeScannerProviderConnection.CreateFrameReaderAsync <br> BarcodeScannerProviderConnection.CreateFrameReaderAsync

#### [<a name="barcodescannersetactivesymbologiesrequest"></a>BarcodeScannerSetActiveSymbologiesRequest](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.provider.barcodescannersetactivesymbologiesrequest)

BarcodeScannerSetActiveSymbologiesRequest.ReportFailedAsync <br> BarcodeScannerSetActiveSymbologiesRequest.ReportFailedAsync

#### [<a name="barcodescannersetsymbologyattributesrequest"></a>BarcodeScannerSetSymbologyAttributesRequest](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.provider.barcodescannersetsymbologyattributesrequest)

BarcodeScannerSetSymbologyAttributesRequest.ReportFailedAsync <br> BarcodeScannerSetSymbologyAttributesRequest.ReportFailedAsync

#### [<a name="barcodescannerstartsoftwaretriggerrequest"></a>BarcodeScannerStartSoftwareTriggerRequest](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.provider.barcodescannerstartsoftwaretriggerrequest)

BarcodeScannerStartSoftwareTriggerRequest.ReportFailedAsync <br> BarcodeScannerStartSoftwareTriggerRequest.ReportFailedAsync

#### [<a name="barcodescannerstopsoftwaretriggerrequest"></a>BarcodeScannerStopSoftwareTriggerRequest](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.provider.barcodescannerstopsoftwaretriggerrequest)

BarcodeScannerStopSoftwareTriggerRequest.ReportFailedAsync <br> BarcodeScannerStopSoftwareTriggerRequest.ReportFailedAsync

#### [<a name="barcodescannervideoframe"></a>BarcodeScannerVideoFrame](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.provider.barcodescannervideoframe)

BarcodeScannerVideoFrame <br> BarcodeScannerVideoFrame.Close <br> BarcodeScannerVideoFrame.Format <br> BarcodeScannerVideoFrame.Height <br> BarcodeScannerVideoFrame.PixelData <br> BarcodeScannerVideoFrame.Width

### [<a name="windowsdevicespointofservice"></a>Windows.Devices.PointOfService](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice)

#### [<a name="barcodescannercapabilities"></a>BarcodeScannerCapabilities](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescannercapabilities)

BarcodeScannerCapabilities.IsVideoPreviewSupported

#### [<a name="claimedbarcodescanner"></a>ClaimedBarcodeScanner](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner)

ClaimedBarcodeScanner.Closed

#### [<a name="claimedbarcodescannerclosedeventargs"></a>ClaimedBarcodeScannerClosedEventArgs](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescannerclosedeventargs)

ClaimedBarcodeScannerClosedEventArgs

#### [<a name="claimedcashdrawer"></a>ClaimedCashDrawer](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedcashdrawer)

ClaimedCashDrawer.Closed

#### [<a name="claimedcashdrawerclosedeventargs"></a>ClaimedCashDrawerClosedEventArgs](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedcashdrawerclosedeventargs)

ClaimedCashDrawerClosedEventArgs

#### [<a name="claimedlinedisplay"></a>ClaimedLineDisplay](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedlinedisplay)

ClaimedLineDisplay.Closed

#### [<a name="claimedlinedisplayclosedeventargs"></a>ClaimedLineDisplayClosedEventArgs](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedlinedisplayclosedeventargs)

ClaimedLineDisplayClosedEventArgs

#### [<a name="claimedmagneticstripereader"></a>ClaimedMagneticStripeReader](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedmagneticstripereader)

ClaimedMagneticStripeReader.Closed

#### [<a name="claimedmagneticstripereaderclosedeventargs"></a>ClaimedMagneticStripeReaderClosedEventArgs](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedmagneticstripereaderclosedeventargs)

ClaimedMagneticStripeReaderClosedEventArgs

#### [<a name="claimedposprinter"></a>ClaimedPosPrinter](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedposprinter)

ClaimedPosPrinter.Closed

#### [<a name="claimedposprinterclosedeventargs"></a>ClaimedPosPrinterClosedEventArgs](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedposprinterclosedeventargs)

ClaimedPosPrinterClosedEventArgs

### [<a name="windowsdevicessensors"></a>Windows.Devices.Sensors](https://docs.microsoft.com/uwp/api/windows.devices.sensors)

#### [<a name="simpleorientationsensor"></a>SimpleOrientationSensor](https://docs.microsoft.com/uwp/api/windows.devices.sensors.simpleorientationsensor)

SimpleOrientationSensor.FromIdAsync <br> SimpleOrientationSensor.GetDeviceSelector

### [<a name="windowsdevicessmartcards"></a>Windows.Devices.SmartCards](https://docs.microsoft.com/uwp/api/windows.devices.smartcards)

#### [<a name="knownsmartcardappletids"></a>KnownSmartCardAppletIds](https://docs.microsoft.com/uwp/api/windows.devices.smartcards.knownsmartcardappletids)

KnownSmartCardAppletIds <br> KnownSmartCardAppletIds.PaymentSystemEnvironment <br> KnownSmartCardAppletIds.ProximityPaymentSystemEnvironment

#### [<a name="smartcardappletidgroup"></a>SmartCardAppletIdGroup](https://docs.microsoft.com/uwp/api/windows.devices.smartcards.smartcardappletidgroup)

SmartCardAppletIdGroup.Description <br> SmartCardAppletIdGroup.Logo <br> SmartCardAppletIdGroup.Properties <br> SmartCardAppletIdGroup.SecureUserAuthenticationRequired

#### [<a name="smartcardappletidgroupregistration"></a>SmartCardAppletIdGroupRegistration](https://docs.microsoft.com/uwp/api/windows.devices.smartcards.smartcardappletidgroupregistration)

SmartCardAppletIdGroupRegistration.SetPropertiesAsync <br> SmartCardAppletIdGroupRegistration.SmartCardReaderId

## <a name="windowsfoundation"></a>Windows.Foundation

### [<a name="windowsfoundation"></a>Windows.Foundation](https://docs.microsoft.com/uwp/api/windows.foundation)

#### [<a name="guidhelper"></a>GuidHelper](https://docs.microsoft.com/uwp/api/windows.foundation.guidhelper)

GuidHelper <br> GuidHelper.CreateNewGuid <br> GuidHelper.Empty <br> GuidHelper.Equals

## <a name="windowsglobalization"></a>Windows.Globalization

### [<a name="windowsglobalization"></a>Windows.Globalization](https://docs.microsoft.com/uwp/api/windows.globalization)

#### [<a name="currencyidentifiers"></a>CurrencyIdentifiers](https://docs.microsoft.com/uwp/api/windows.globalization.currencyidentifiers)

CurrencyIdentifiers.MRU <br> CurrencyIdentifiers.SSP <br> CurrencyIdentifiers.STN <br> CurrencyIdentifiers.VES

## <a name="windowsgraphics"></a>Windows.Graphics

### [<a name="windowsgraphicscapture"></a>Windows.Graphics.Capture](https://docs.microsoft.com/uwp/api/windows.graphics.capture)

#### [<a name="direct3d11captureframepool"></a>Direct3D11CaptureFramePool](https://docs.microsoft.com/uwp/api/windows.graphics.capture.direct3d11captureframepool)

Direct3D11CaptureFramePool.CreateFreeThreaded

#### [<a name="graphicscaptureitem"></a>GraphicsCaptureItem](https://docs.microsoft.com/uwp/api/windows.graphics.capture.graphicscaptureitem)

GraphicsCaptureItem.CreateFromVisual

### [<a name="windowsgraphicsdisplaycore"></a>Windows.Graphics.Display.Core](https://docs.microsoft.com/uwp/api/windows.graphics.display.core)

#### [<a name="hdmidisplaymode"></a>HdmiDisplayMode](https://docs.microsoft.com/uwp/api/windows.graphics.display.core.hdmidisplaymode)

HdmiDisplayMode.IsDolbyVisionLowLatencySupported

### [<a name="windowsgraphicsholographic"></a>Windows.Graphics.Holographic](https://docs.microsoft.com/uwp/api/windows.graphics.holographic)

#### [<a name="holographiccamera"></a>HolographicCamera](https://docs.microsoft.com/uwp/api/windows.graphics.holographic.holographiccamera)

HolographicCamera.IsHardwareContentProtectionEnabled <br> HolographicCamera.IsHardwareContentProtectionSupported

#### [<a name="holographicquadlayerupdateparameters"></a>HolographicQuadLayerUpdateParameters](https://docs.microsoft.com/uwp/api/windows.graphics.holographic.holographicquadlayerupdateparameters)

HolographicQuadLayerUpdateParameters.AcquireBufferToUpdateContentWithHardwareProtection <br> HolographicQuadLayerUpdateParameters.CanAcquireWithHardwareProtection

### [<a name="windowsgraphicsimaging"></a>Windows.Graphics.Imaging](https://docs.microsoft.com/uwp/api/windows.graphics.imaging)

#### [<a name="bitmapdecoder"></a>BitmapDecoder](https://docs.microsoft.com/uwp/api/windows.graphics.imaging.bitmapdecoder)

BitmapDecoder.HeifDecoderId <br> BitmapDecoder.WebpDecoderId

#### [<a name="bitmapencoder"></a>BitmapEncoder](https://docs.microsoft.com/uwp/api/windows.graphics.imaging.bitmapencoder)

BitmapEncoder.HeifEncoderId

## <a name="windowsmanagement"></a>Windows.Management

### [<a name="windowsmanagementdeployment"></a>Windows.Management.Deployment](https://docs.microsoft.com/uwp/api/windows.management.deployment)

#### [<a name="packagemanager"></a>PackageManager](https://docs.microsoft.com/uwp/api/windows.management.deployment.packagemanager)

PackageManager.DeprovisionPackageForAllUsersAsync

## <a name="windowsmedia"></a>Windows.Media

### [<a name="windowsmediaaudio"></a>Windows.Media.Audio](https://docs.microsoft.com/uwp/api/windows.media.audio)

#### [<a name="createaudiodeviceinputnoderesult"></a>CreateAudioDeviceInputNodeResult](https://docs.microsoft.com/uwp/api/windows.media.audio.createaudiodeviceinputnoderesult)

CreateAudioDeviceInputNodeResult.ExtendedError

#### [<a name="createaudiodeviceoutputnoderesult"></a>CreateAudioDeviceOutputNodeResult](https://docs.microsoft.com/uwp/api/windows.media.audio.createaudiodeviceoutputnoderesult)

CreateAudioDeviceOutputNodeResult.ExtendedError

#### [<a name="createaudiofileinputnoderesult"></a>CreateAudioFileInputNodeResult](https://docs.microsoft.com/uwp/api/windows.media.audio.createaudiofileinputnoderesult)

CreateAudioFileInputNodeResult.ExtendedError

#### [<a name="createaudiofileoutputnoderesult"></a>CreateAudioFileOutputNodeResult](https://docs.microsoft.com/uwp/api/windows.media.audio.createaudiofileoutputnoderesult)

CreateAudioFileOutputNodeResult.ExtendedError

#### [<a name="createaudiographresult"></a>CreateAudioGraphResult](https://docs.microsoft.com/uwp/api/windows.media.audio.createaudiographresult)

CreateAudioGraphResult.ExtendedError

#### [<a name="createmediasourceaudioinputnoderesult"></a>CreateMediaSourceAudioInputNodeResult](https://docs.microsoft.com/uwp/api/windows.media.audio.createmediasourceaudioinputnoderesult)

CreateMediaSourceAudioInputNodeResult.ExtendedError

#### [<a name="mixedrealityspatialaudioformatpolicy"></a>MixedRealitySpatialAudioFormatPolicy](https://docs.microsoft.com/uwp/api/windows.media.audio.mixedrealityspatialaudioformatpolicy)

MixedRealitySpatialAudioFormatPolicy

#### [<a name="setdefaultspatialaudioformatresult"></a>SetDefaultSpatialAudioFormatResult](https://docs.microsoft.com/uwp/api/windows.media.audio.setdefaultspatialaudioformatresult)

SetDefaultSpatialAudioFormatResult <br> SetDefaultSpatialAudioFormatResult.Status

#### [<a name="setdefaultspatialaudioformatstatus"></a>SetDefaultSpatialAudioFormatStatus](https://docs.microsoft.com/uwp/api/windows.media.audio.setdefaultspatialaudioformatstatus)

SetDefaultSpatialAudioFormatStatus

#### [<a name="spatialaudiodeviceconfiguration"></a>SpatialAudioDeviceConfiguration](https://docs.microsoft.com/uwp/api/windows.media.audio.spatialaudiodeviceconfiguration)

SpatialAudioDeviceConfiguration <br> SpatialAudioDeviceConfiguration.ActiveSpatialAudioFormat <br> SpatialAudioDeviceConfiguration.ConfigurationChanged <br> SpatialAudioDeviceConfiguration.DefaultSpatialAudioFormat <br> SpatialAudioDeviceConfiguration.DeviceId <br> SpatialAudioDeviceConfiguration.GetForDeviceId <br> SpatialAudioDeviceConfiguration.IsSpatialAudioFormatSupported <br> SpatialAudioDeviceConfiguration.IsSpatialAudioSupported <br> SpatialAudioDeviceConfiguration.SetDefaultSpatialAudioFormatAsync

#### [<a name="spatialaudioformatconfiguration"></a>SpatialAudioFormatConfiguration](https://docs.microsoft.com/uwp/api/windows.media.audio.spatialaudioformatconfiguration)

SpatialAudioFormatConfiguration <br> SpatialAudioFormatConfiguration.GetDefault <br> SpatialAudioFormatConfiguration.MixedRealityExclusiveModePolicy <br> SpatialAudioFormatConfiguration.ReportConfigurationChangedAsync <br> SpatialAudioFormatConfiguration.ReportLicenseChangedAsync

#### [<a name="spatialaudioformatsubtype"></a>SpatialAudioFormatSubtype](https://docs.microsoft.com/uwp/api/windows.media.audio.spatialaudioformatsubtype)

SpatialAudioFormatSubtype <br> SpatialAudioFormatSubtype.DolbyAtmosForHeadphones <br> SpatialAudioFormatSubtype.DolbyAtmosForHomeTheater <br> SpatialAudioFormatSubtype.DolbyAtmosForSpeakers <br> SpatialAudioFormatSubtype.DTSHeadphoneX <br> SpatialAudioFormatSubtype.DTSXUltra <br> SpatialAudioFormatSubtype.WindowsSonic

### [<a name="windowsmediacontrol"></a>Windows.Media.Control](https://docs.microsoft.com/uwp/api/windows.media.control)

#### [<a name="currentsessionchangedeventargs"></a>CurrentSessionChangedEventArgs](https://docs.microsoft.com/uwp/api/windows.media.control.currentsessionchangedeventargs)

CurrentSessionChangedEventArgs

#### [<a name="globalsystemmediatransportcontrolssession"></a>GlobalSystemMediaTransportControlsSession](https://docs.microsoft.com/uwp/api/windows.media.control.globalsystemmediatransportcontrolssession)

GlobalSystemMediaTransportControlsSession <br> GlobalSystemMediaTransportControlsSession.GetPlaybackInfo <br> GlobalSystemMediaTransportControlsSession.GetTimelineProperties <br> GlobalSystemMediaTransportControlsSession.MediaPropertiesChanged <br> GlobalSystemMediaTransportControlsSession.PlaybackInfoChanged <br> GlobalSystemMediaTransportControlsSession.SourceAppUserModelId <br> GlobalSystemMediaTransportControlsSession.TimelinePropertiesChanged <br> GlobalSystemMediaTransportControlsSession.TryChangeAutoRepeatModeAsync <br> GlobalSystemMediaTransportControlsSession.TryChangeChannelDownAsync <br> GlobalSystemMediaTransportControlsSession.TryChangeChannelUpAsync <br> GlobalSystemMediaTransportControlsSession.TryChangePlaybackPositionAsync <br> GlobalSystemMediaTransportControlsSession.TryChangePlaybackRateAsync <br> GlobalSystemMediaTransportControlsSession.TryChangeShuffleActiveAsync <br> GlobalSystemMediaTransportControlsSession.TryFastForwardAsync <br> GlobalSystemMediaTransportControlsSession.TryGetMediaPropertiesAsync <br> GlobalSystemMediaTransportControlsSession.TryPauseAsync <br> GlobalSystemMediaTransportControlsSession.TryPlayAsync <br> GlobalSystemMediaTransportControlsSession.TryRecordAsync <br> GlobalSystemMediaTransportControlsSession.TryRewindAsync <br> GlobalSystemMediaTransportControlsSession.TrySkipNextAsync <br> GlobalSystemMediaTransportControlsSession.TrySkipPreviousAsync <br> GlobalSystemMediaTransportControlsSession.TryStopAsync <br> GlobalSystemMediaTransportControlsSession.TryTogglePlayPauseAsync

#### [<a name="globalsystemmediatransportcontrolssessionmanager"></a>GlobalSystemMediaTransportControlsSessionManager](https://docs.microsoft.com/uwp/api/windows.media.control.globalsystemmediatransportcontrolssessionmanager)

GlobalSystemMediaTransportControlsSessionManager <br> GlobalSystemMediaTransportControlsSessionManager.CurrentSessionChanged <br> GlobalSystemMediaTransportControlsSessionManager.GetCurrentSession <br> GlobalSystemMediaTransportControlsSessionManager.GetSessions <br> GlobalSystemMediaTransportControlsSessionManager.RequestAsync <br> GlobalSystemMediaTransportControlsSessionManager.SessionsChanged

#### [<a name="globalsystemmediatransportcontrolssessionmediaproperties"></a>GlobalSystemMediaTransportControlsSessionMediaProperties](https://docs.microsoft.com/uwp/api/windows.media.control.globalsystemmediatransportcontrolssessionmediaproperties)

GlobalSystemMediaTransportControlsSessionMediaProperties <br> GlobalSystemMediaTransportControlsSessionMediaProperties.AlbumArtist <br> GlobalSystemMediaTransportControlsSessionMediaProperties.AlbumTitle <br> GlobalSystemMediaTransportControlsSessionMediaProperties.AlbumTrackCount <br> GlobalSystemMediaTransportControlsSessionMediaProperties.Artist <br> GlobalSystemMediaTransportControlsSessionMediaProperties.Genres <br> GlobalSystemMediaTransportControlsSessionMediaProperties.PlaybackType <br> GlobalSystemMediaTransportControlsSessionMediaProperties.Subtitle <br> GlobalSystemMediaTransportControlsSessionMediaProperties.Thumbnail <br> GlobalSystemMediaTransportControlsSessionMediaProperties.Title <br> GlobalSystemMediaTransportControlsSessionMediaProperties.TrackNumber

#### [<a name="globalsystemmediatransportcontrolssessionplaybackcontrols"></a>GlobalSystemMediaTransportControlsSessionPlaybackControls](https://docs.microsoft.com/uwp/api/windows.media.control.globalsystemmediatransportcontrolssessionplaybackcontrols)

GlobalSystemMediaTransportControlsSessionPlaybackControls <br> GlobalSystemMediaTransportControlsSessionPlaybackControls.IsChannelDownEnabled <br> GlobalSystemMediaTransportControlsSessionPlaybackControls.IsChannelUpEnabled <br> GlobalSystemMediaTransportControlsSessionPlaybackControls.IsFastForwardEnabled <br> GlobalSystemMediaTransportControlsSessionPlaybackControls.IsNextEnabled <br> GlobalSystemMediaTransportControlsSessionPlaybackControls.IsPauseEnabled <br> GlobalSystemMediaTransportControlsSessionPlaybackControls.IsPlaybackPositionEnabled <br> GlobalSystemMediaTransportControlsSessionPlaybackControls.IsPlaybackRateEnabled <br> GlobalSystemMediaTransportControlsSessionPlaybackControls.IsPlayEnabled <br> GlobalSystemMediaTransportControlsSessionPlaybackControls.IsPlayPauseToggleEnabled <br> GlobalSystemMediaTransportControlsSessionPlaybackControls.IsPreviousEnabled <br> GlobalSystemMediaTransportControlsSessionPlaybackControls.IsRecordEnabled <br> GlobalSystemMediaTransportControlsSessionPlaybackControls.IsRepeatEnabled <br> GlobalSystemMediaTransportControlsSessionPlaybackControls.IsRewindEnabled <br> GlobalSystemMediaTransportControlsSessionPlaybackControls.IsShuffleEnabled <br> GlobalSystemMediaTransportControlsSessionPlaybackControls.IsStopEnabled

#### [<a name="globalsystemmediatransportcontrolssessionplaybackinfo"></a>GlobalSystemMediaTransportControlsSessionPlaybackInfo](https://docs.microsoft.com/uwp/api/windows.media.control.globalsystemmediatransportcontrolssessionplaybackinfo)

GlobalSystemMediaTransportControlsSessionPlaybackInfo <br> GlobalSystemMediaTransportControlsSessionPlaybackInfo.AutoRepeatMode <br> GlobalSystemMediaTransportControlsSessionPlaybackInfo.Controls <br> GlobalSystemMediaTransportControlsSessionPlaybackInfo.IsShuffleActive <br> GlobalSystemMediaTransportControlsSessionPlaybackInfo.PlaybackRate <br> GlobalSystemMediaTransportControlsSessionPlaybackInfo.PlaybackStatus <br> GlobalSystemMediaTransportControlsSessionPlaybackInfo.PlaybackType

#### [<a name="globalsystemmediatransportcontrolssessionplaybackstatus"></a>GlobalSystemMediaTransportControlsSessionPlaybackStatus](https://docs.microsoft.com/uwp/api/windows.media.control.globalsystemmediatransportcontrolssessionplaybackstatus)

GlobalSystemMediaTransportControlsSessionPlaybackStatus

#### [<a name="globalsystemmediatransportcontrolssessiontimelineproperties"></a>GlobalSystemMediaTransportControlsSessionTimelineProperties](https://docs.microsoft.com/uwp/api/windows.media.control.globalsystemmediatransportcontrolssessiontimelineproperties)

GlobalSystemMediaTransportControlsSessionTimelineProperties <br> GlobalSystemMediaTransportControlsSessionTimelineProperties.EndTime <br> GlobalSystemMediaTransportControlsSessionTimelineProperties.LastUpdatedTime <br> GlobalSystemMediaTransportControlsSessionTimelineProperties.MaxSeekTime <br> GlobalSystemMediaTransportControlsSessionTimelineProperties.MinSeekTime <br> GlobalSystemMediaTransportControlsSessionTimelineProperties.Position <br> GlobalSystemMediaTransportControlsSessionTimelineProperties.StartTime

#### [<a name="mediapropertieschangedeventargs"></a>MediaPropertiesChangedEventArgs](https://docs.microsoft.com/uwp/api/windows.media.control.mediapropertieschangedeventargs)

MediaPropertiesChangedEventArgs

#### [<a name="playbackinfochangedeventargs"></a>PlaybackInfoChangedEventArgs](https://docs.microsoft.com/uwp/api/windows.media.control.playbackinfochangedeventargs)

PlaybackInfoChangedEventArgs

#### [<a name="sessionschangedeventargs"></a>SessionsChangedEventArgs](https://docs.microsoft.com/uwp/api/windows.media.control.sessionschangedeventargs)

SessionsChangedEventArgs

#### [<a name="timelinepropertieschangedeventargs"></a>TimelinePropertiesChangedEventArgs](https://docs.microsoft.com/uwp/api/windows.media.control.timelinepropertieschangedeventargs)

TimelinePropertiesChangedEventArgs

### [<a name="windowsmediacore"></a>Windows.Media.Core](https://docs.microsoft.com/uwp/api/windows.media.core)

#### [<a name="mediastreamsample"></a>MediaStreamSample](https://docs.microsoft.com/uwp/api/windows.media.core.mediastreamsample)

MediaStreamSample.CreateFromDirect3D11Surface <br> MediaStreamSample.Direct3D11Surface

### [<a name="windowsmediadevicescore"></a>Windows.Media.Devices.Core](https://docs.microsoft.com/uwp/api/windows.media.devices.core)

#### [<a name="cameraintrinsics"></a>CameraIntrinsics](https://docs.microsoft.com/uwp/api/windows.media.devices.core.cameraintrinsics)

CameraIntrinsics。 #ctor

### [<a name="windowsmediaimport"></a>Windows.Media.Import](https://docs.microsoft.com/uwp/api/windows.media.import)

#### [<a name="photoimportitem"></a>PhotoImportItem](https://docs.microsoft.com/uwp/api/windows.media.import.photoimportitem)

PhotoImportItem.Path

### [<a name="windowsmediamediaproperties"></a>Windows.Media.MediaProperties](https://docs.microsoft.com/uwp/api/windows.media.mediaproperties)

#### [<a name="imageencodingproperties"></a>ImageEncodingProperties](https://docs.microsoft.com/uwp/api/windows.media.mediaproperties.imageencodingproperties)

ImageEncodingProperties.CreateHeif

#### [<a name="mediaencodingsubtypes"></a>MediaEncodingSubtypes](https://docs.microsoft.com/uwp/api/windows.media.mediaproperties.mediaencodingsubtypes)

MediaEncodingSubtypes.Heif

### [<a name="windowsmediaprotectionplayready"></a>Windows.Media.Protection.PlayReady](https://docs.microsoft.com/uwp/api/windows.media.protection.playready)

#### [<a name="playreadystatics"></a>PlayReadyStatics](https://docs.microsoft.com/uwp/api/windows.media.protection.playready.playreadystatics)

PlayReadyStatics.HardwareDRMDisabledAtTime <br> PlayReadyStatics.HardwareDRMDisabledUntilTime <br> PlayReadyStatics.ResetHardwareDRMDisabled

## <a name="windowsnetworking"></a>Windows.Networking

### [<a name="windowsnetworkingconnectivity"></a>Windows.Networking.Connectivity](https://docs.microsoft.com/uwp/api/windows.networking.connectivity)

#### [<a name="connectionprofile"></a>ConnectionProfile](https://docs.microsoft.com/uwp/api/windows.networking.connectivity.connectionprofile)

ConnectionProfile.CanDelete <br> ConnectionProfile.TryDeleteAsync

#### [<a name="connectionprofiledeletestatus"></a>ConnectionProfileDeleteStatus](https://docs.microsoft.com/uwp/api/windows.networking.connectivity.connectionprofiledeletestatus)

ConnectionProfileDeleteStatus

## <a name="windowsperception"></a>Windows.Perception

### [<a name="windowsperceptionspatialpreview"></a>Windows.Perception.Spatial.Preview](https://docs.microsoft.com/uwp/api/windows.perception.spatial.preview)

#### [<a name="spatialgraphinteroppreview"></a>SpatialGraphInteropPreview](https://docs.microsoft.com/uwp/api/windows.perception.spatial.preview.spatialgraphinteroppreview)

SpatialGraphInteropPreview <br> SpatialGraphInteropPreview.CreateCoordinateSystemForNode <br> SpatialGraphInteropPreview.CreateCoordinateSystemForNode <br> SpatialGraphInteropPreview.CreateCoordinateSystemForNode <br> SpatialGraphInteropPreview.CreateLocatorForNode

### [<a name="windowsperceptionspatial"></a>Windows.Perception.Spatial](https://docs.microsoft.com/uwp/api/windows.perception.spatial)

#### [<a name="spatialanchorexporter"></a>SpatialAnchorExporter](https://docs.microsoft.com/uwp/api/windows.perception.spatial.spatialanchorexporter)

SpatialAnchorExporter <br> SpatialAnchorExporter.GetAnchorExportSufficiencyAsync <br> SpatialAnchorExporter.GetDefault <br> SpatialAnchorExporter.RequestAccessAsync <br> SpatialAnchorExporter.TryExportAnchorAsync

#### [<a name="spatialanchorexportpurpose"></a>SpatialAnchorExportPurpose](https://docs.microsoft.com/uwp/api/windows.perception.spatial.spatialanchorexportpurpose)

SpatialAnchorExportPurpose

#### [<a name="spatialanchorexportsufficiency"></a>SpatialAnchorExportSufficiency](https://docs.microsoft.com/uwp/api/windows.perception.spatial.spatialanchorexportsufficiency)

SpatialAnchorExportSufficiency <br> SpatialAnchorExportSufficiency.IsMinimallySufficient <br> SpatialAnchorExportSufficiency.RecommendedSufficiencyLevel <br> SpatialAnchorExportSufficiency.SufficiencyLevel

#### [<a name="spatiallocation"></a>SpatialLocation](https://docs.microsoft.com/uwp/api/windows.perception.spatial.spatiallocation)

SpatialLocation.AbsoluteAngularAccelerationAxisAngle <br> SpatialLocation.AbsoluteAngularVelocityAxisAngle

### [<a name="windowsperception"></a>Windows.Perception](https://docs.microsoft.com/uwp/api/windows.perception)

#### [<a name="perceptiontimestamp"></a>PerceptionTimestamp](https://docs.microsoft.com/uwp/api/windows.perception.perceptiontimestamp)

PerceptionTimestamp.SystemRelativeTargetTime

#### [<a name="perceptiontimestamphelper"></a>PerceptionTimestampHelper](https://docs.microsoft.com/uwp/api/windows.perception.perceptiontimestamphelper)

PerceptionTimestampHelper.FromSystemRelativeTargetTime

## <a name="windowsservices"></a>Windows.Services

### [<a name="windowsservicescortana"></a>Windows.Services.Cortana](https://docs.microsoft.com/uwp/api/windows.services.cortana)

#### [<a name="cortanaactionableinsights"></a>CortanaActionableInsights](https://docs.microsoft.com/uwp/api/windows.services.cortana.cortanaactionableinsights)

CortanaActionableInsights <br> CortanaActionableInsights.GetDefault <br> CortanaActionableInsights.GetForUser <br> CortanaActionableInsights.IsAvailableAsync <br> CortanaActionableInsights.ShowInsightsAsync <br> CortanaActionableInsights.ShowInsightsAsync <br> CortanaActionableInsights.ShowInsightsForImageAsync <br> CortanaActionableInsights.ShowInsightsForImageAsync <br> CortanaActionableInsights.ShowInsightsForTextAsync <br> CortanaActionableInsights.ShowInsightsForTextAsync <br> CortanaActionableInsights.User

#### [<a name="cortanaactionableinsightsoptions"></a>CortanaActionableInsightsOptions](https://docs.microsoft.com/uwp/api/windows.services.cortana.cortanaactionableinsightsoptions)

CortanaActionableInsightsOptions <br> CortanaActionableInsightsOptions.ContentSourceWebLink <br> CortanaActionableInsightsOptions。 #ctor <br> CortanaActionableInsightsOptions.SurroundingText

### [<a name="windowsservicesstore"></a>Windows.Services.Store](https://docs.microsoft.com/uwp/api/windows.services.store)

#### [<a name="storeapplicense"></a>StoreAppLicense](https://docs.microsoft.com/uwp/api/windows.services.store.storeapplicense)

StoreAppLicense.IsDiscLicense

#### [<a name="storecontext"></a>StoreContext](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext)

StoreContext.RequestRateAndReviewAppAsync <br> StoreContext.SetInstallOrderForAssociatedStoreQueueItemsAsync

#### [<a name="storequeueitem"></a>StoreQueueItem](https://docs.microsoft.com/uwp/api/windows.services.store.storequeueitem)

StoreQueueItem.CancelInstallAsync <br> StoreQueueItem.PauseInstallAsync <br> StoreQueueItem.ResumeInstallAsync

#### [<a name="storerateandreviewresult"></a>StoreRateAndReviewResult](https://docs.microsoft.com/uwp/api/windows.services.store.storerateandreviewresult)

StoreRateAndReviewResult <br> StoreRateAndReviewResult.ExtendedError <br> StoreRateAndReviewResult.ExtendedJsonData <br> StoreRateAndReviewResult.Status <br> StoreRateAndReviewResult.WasUpdated

#### [<a name="storerateandreviewstatus"></a>StoreRateAndReviewStatus](https://docs.microsoft.com/uwp/api/windows.services.store.storerateandreviewstatus)

StoreRateAndReviewStatus

## <a name="windowsstorage"></a>Windows.Storage

### [<a name="windowsstorageprovider"></a>Windows.Storage.Provider](https://docs.microsoft.com/uwp/api/windows.storage.provider)

#### [<a name="storageprovidersyncrootinfo"></a>StorageProviderSyncRootInfo](https://docs.microsoft.com/uwp/api/windows.storage.provider.storageprovidersyncrootinfo)

StorageProviderSyncRootInfo.ProviderId

## <a name="windowssystem"></a>Windows.System

### [<a name="windowssystemimplementationholographic"></a>Windows.System.Implementation.Holographic](https://docs.microsoft.com/uwp/api/windows.system.implementation.holographic)

#### [<a name="sysholographicdeploymentprogress"></a>SysHolographicDeploymentProgress](https://docs.microsoft.com/uwp/api/windows.system.implementation.holographic.sysholographicdeploymentprogress)

SysHolographicDeploymentProgress

#### [<a name="sysholographicdeploymentresult"></a>SysHolographicDeploymentResult](https://docs.microsoft.com/uwp/api/windows.system.implementation.holographic.sysholographicdeploymentresult)

SysHolographicDeploymentResult <br> SysHolographicDeploymentResult.DeploymentState <br> SysHolographicDeploymentResult.ExtendedError

#### [<a name="sysholographicdeploymentstate"></a>SysHolographicDeploymentState](https://docs.microsoft.com/uwp/api/windows.system.implementation.holographic.sysholographicdeploymentstate)

SysHolographicDeploymentState

#### [<a name="sysholographicdisplay"></a>SysHolographicDisplay](https://docs.microsoft.com/uwp/api/windows.system.implementation.holographic.sysholographicdisplay)

SysHolographicDisplay <br> SysHolographicDisplay.DeviceId <br> SysHolographicDisplay.Display <br> SysHolographicDisplay.ExperienceMode <br> SysHolographicDisplay.LeftViewportParameters <br> SysHolographicDisplay.OutputAdapterId <br> SysHolographicDisplay.RightViewportParameters

#### [<a name="sysholographicdisplayexperiencemode"></a>SysHolographicDisplayExperienceMode](https://docs.microsoft.com/uwp/api/windows.system.implementation.holographic.sysholographicdisplayexperiencemode)

SysHolographicDisplayExperienceMode

#### [<a name="sysholographicdisplaywatcher"></a>SysHolographicDisplayWatcher](https://docs.microsoft.com/uwp/api/windows.system.implementation.holographic.sysholographicdisplaywatcher)

SysHolographicDisplayWatcher <br> SysHolographicDisplayWatcher.Added <br> SysHolographicDisplayWatcher.EnumerationCompleted <br> SysHolographicDisplayWatcher.Removed <br> SysHolographicDisplayWatcher.Start <br> SysHolographicDisplayWatcher.Status <br> SysHolographicDisplayWatcher.Stop <br> SysHolographicDisplayWatcher.Stopped <br> SysHolographicDisplayWatcher。 #ctor

#### [<a name="sysholographicdisplaywatcherstatus"></a>SysHolographicDisplayWatcherStatus](https://docs.microsoft.com/uwp/api/windows.system.implementation.holographic.sysholographicdisplaywatcherstatus)

SysHolographicDisplayWatcherStatus

#### [<a name="sysholographicpreviewmediasource"></a>SysHolographicPreviewMediaSource](https://docs.microsoft.com/uwp/api/windows.system.implementation.holographic.sysholographicpreviewmediasource)

SysHolographicPreviewMediaSource <br> SysHolographicPreviewMediaSource.Create

#### [<a name="sysholographicwindowingenvironment"></a>SysHolographicWindowingEnvironment](https://docs.microsoft.com/uwp/api/windows.system.implementation.holographic.sysholographicwindowingenvironment)

SysHolographicWindowingEnvironment <br> SysHolographicWindowingEnvironment.DeployAsync <br> SysHolographicWindowingEnvironment.GetDefault <br> SysHolographicWindowingEnvironment.GetDeploymentStateAsync <br> SysHolographicWindowingEnvironment.IsDeviceSetupComplete <br> SysHolographicWindowingEnvironment.IsLearningExperienceComplete <br> SysHolographicWindowingEnvironment.IsPreviewActive <br> SysHolographicWindowingEnvironment.IsPreviewActiveChanged <br> SysHolographicWindowingEnvironment.IsProtectedContentPresent <br> SysHolographicWindowingEnvironment.IsProtectedContentPresentChanged <br> SysHolographicWindowingEnvironment.IsSpeechPersonalizationSupported <br> SysHolographicWindowingEnvironment.SetIsSpeechPersonalizationEnabledAsync <br> SysHolographicWindowingEnvironment.StartAsync <br> SysHolographicWindowingEnvironment.Status <br> SysHolographicWindowingEnvironment.StatusChanged <br> SysHolographicWindowingEnvironment.StopAsync

#### [<a name="sysholographicwindowingenvironmentcomponentkind"></a>SysHolographicWindowingEnvironmentComponentKind](https://docs.microsoft.com/uwp/api/windows.system.implementation.holographic.sysholographicwindowingenvironmentcomponentkind)

SysHolographicWindowingEnvironmentComponentKind

#### [<a name="sysholographicwindowingenvironmentcomponentstate"></a>SysHolographicWindowingEnvironmentComponentState](https://docs.microsoft.com/uwp/api/windows.system.implementation.holographic.sysholographicwindowingenvironmentcomponentstate)

SysHolographicWindowingEnvironmentComponentState

#### [<a name="sysholographicwindowingenvironmentcomponentstatus"></a>SysHolographicWindowingEnvironmentComponentStatus](https://docs.microsoft.com/uwp/api/windows.system.implementation.holographic.sysholographicwindowingenvironmentcomponentstatus)

SysHolographicWindowingEnvironmentComponentStatus

#### [<a name="sysholographicwindowingenvironmentstate"></a>SysHolographicWindowingEnvironmentState](https://docs.microsoft.com/uwp/api/windows.system.implementation.holographic.sysholographicwindowingenvironmentstate)

SysHolographicWindowingEnvironmentState

#### [<a name="sysholographicwindowingenvironmentstatus"></a>SysHolographicWindowingEnvironmentStatus](https://docs.microsoft.com/uwp/api/windows.system.implementation.holographic.sysholographicwindowingenvironmentstatus)

SysHolographicWindowingEnvironmentStatus <br> SysHolographicWindowingEnvironmentStatus.ComponentStatuses <br> SysHolographicWindowingEnvironmentStatus.State

#### [<a name="sysspatialinputdevice"></a>SysSpatialInputDevice](https://docs.microsoft.com/uwp/api/windows.system.implementation.holographic.sysspatialinputdevice)

SysSpatialInputDevice <br> SysSpatialInputDevice.Handedness <br> SysSpatialInputDevice.HasPositionalTracking <br> SysSpatialInputDevice.TryGetBatteryReport

#### [<a name="sysspatialinputdevicewatcher"></a>SysSpatialInputDeviceWatcher](https://docs.microsoft.com/uwp/api/windows.system.implementation.holographic.sysspatialinputdevicewatcher)

SysSpatialInputDeviceWatcher <br> SysSpatialInputDeviceWatcher.Added <br> SysSpatialInputDeviceWatcher.EnumerationCompleted <br> SysSpatialInputDeviceWatcher.Removed <br> SysSpatialInputDeviceWatcher.Start <br> SysSpatialInputDeviceWatcher.Status <br> SysSpatialInputDeviceWatcher.Stop <br> SysSpatialInputDeviceWatcher.Stopped <br> SysSpatialInputDeviceWatcher。 #ctor <br> SysSpatialInputDeviceWatcher.Updated

#### [<a name="sysspatialinputdevicewatcherstatus"></a>SysSpatialInputDeviceWatcherStatus](https://docs.microsoft.com/uwp/api/windows.system.implementation.holographic.sysspatialinputdevicewatcherstatus)

SysSpatialInputDeviceWatcherStatus

#### [<a name="sysspatiallocator"></a>SysSpatialLocator](https://docs.microsoft.com/uwp/api/windows.system.implementation.holographic.sysspatiallocator)

SysSpatialLocator <br> SysSpatialLocator.GetFloorLocator

#### [<a name="sysspatialstageboundarydisposition"></a>SysSpatialStageBoundaryDisposition](https://docs.microsoft.com/uwp/api/windows.system.implementation.holographic.sysspatialstageboundarydisposition)

SysSpatialStageBoundaryDisposition

#### [<a name="sysspatialstagemanager"></a>SysSpatialStageManager](https://docs.microsoft.com/uwp/api/windows.system.implementation.holographic.sysspatialstagemanager)

SysSpatialStageManager <br> SysSpatialStageManager.DoesAnyStageHaveBoundariesAsync <br> SysSpatialStageManager.GetBoundaryDisposition <br> SysSpatialStageManager.SetAndSaveNewStageAsync <br> SysSpatialStageManager.SetBoundaryEnabled <br> SysSpatialStageManager。 #ctor <br> SysSpatialStageManager.UpdateStageAnchorAsync

### [<a name="windowssystempreview"></a>Windows.System.Preview](https://docs.microsoft.com/uwp/api/windows.system.preview)

#### [<a name="hingestate"></a>HingeState](https://docs.microsoft.com/uwp/api/windows.system.preview.hingestate)

HingeState

#### [<a name="twopanelhingeddeviceposturepreview"></a>TwoPanelHingedDevicePosturePreview](https://docs.microsoft.com/uwp/api/windows.system.preview.twopanelhingeddeviceposturepreview)

TwoPanelHingedDevicePosturePreview <br> TwoPanelHingedDevicePosturePreview.GetCurrentPostureAsync <br> TwoPanelHingedDevicePosturePreview.GetDefaultAsync <br> TwoPanelHingedDevicePosturePreview.PostureChanged

#### [<a name="twopanelhingeddeviceposturepreviewreading"></a>TwoPanelHingedDevicePosturePreviewReading](https://docs.microsoft.com/uwp/api/windows.system.preview.twopanelhingeddeviceposturepreviewreading)

TwoPanelHingedDevicePosturePreviewReading <br> TwoPanelHingedDevicePosturePreviewReading.HingeState <br> TwoPanelHingedDevicePosturePreviewReading.Panel1Id <br> TwoPanelHingedDevicePosturePreviewReading.Panel1Orientation <br> TwoPanelHingedDevicePosturePreviewReading.Panel2Id <br> TwoPanelHingedDevicePosturePreviewReading.Panel2Orientation <br> TwoPanelHingedDevicePosturePreviewReading.Timestamp

#### [<a name="twopanelhingeddeviceposturepreviewreadingchangedeventargs"></a>TwoPanelHingedDevicePosturePreviewReadingChangedEventArgs](https://docs.microsoft.com/uwp/api/windows.system.preview.twopanelhingeddeviceposturepreviewreadingchangedeventargs)

TwoPanelHingedDevicePosturePreviewReadingChangedEventArgs <br> TwoPanelHingedDevicePosturePreviewReadingChangedEventArgs.Reading

### [<a name="windowssystemprofilesystemmanufacturers"></a>Windows.System.Profile.SystemManufacturers](https://docs.microsoft.com/uwp/api/windows.system.profile.systemmanufacturers)

#### [<a name="systemsupportdeviceinfo"></a>SystemSupportDeviceInfo](https://docs.microsoft.com/uwp/api/windows.system.profile.systemmanufacturers.systemsupportdeviceinfo)

SystemSupportDeviceInfo <br> SystemSupportDeviceInfo.FriendlyName <br> SystemSupportDeviceInfo.OperatingSystem <br> SystemSupportDeviceInfo.SystemFirmwareVersion <br> SystemSupportDeviceInfo.SystemHardwareVersion <br> SystemSupportDeviceInfo.SystemManufacturer <br> SystemSupportDeviceInfo.SystemProductName <br> SystemSupportDeviceInfo.SystemSku

#### [<a name="systemsupportinfo"></a>SystemSupportInfo](https://docs.microsoft.com/uwp/api/windows.system.profile.systemmanufacturers.systemsupportinfo)

SystemSupportInfo.LocalDeviceInfo

### [<a name="windowssystemprofile"></a>Windows.System.Profile](https://docs.microsoft.com/uwp/api/windows.system.profile)

#### [<a name="systemoutofboxexperiencestate"></a>SystemOutOfBoxExperienceState](https://docs.microsoft.com/uwp/api/windows.system.profile.systemoutofboxexperiencestate)

SystemOutOfBoxExperienceState

#### [<a name="systemsetupinfo"></a>SystemSetupInfo](https://docs.microsoft.com/uwp/api/windows.system.profile.systemsetupinfo)

SystemSetupInfo <br> SystemSetupInfo.OutOfBoxExperienceState <br> SystemSetupInfo.OutOfBoxExperienceStateChanged

#### [<a name="windowsintegritypolicy"></a>WindowsIntegrityPolicy](https://docs.microsoft.com/uwp/api/windows.system.profile.windowsintegritypolicy)

WindowsIntegrityPolicy <br> WindowsIntegrityPolicy.CanDisable <br> WindowsIntegrityPolicy.IsDisableSupported <br> WindowsIntegrityPolicy.IsEnabled <br> WindowsIntegrityPolicy.IsEnabledForTrial <br> WindowsIntegrityPolicy.PolicyChanged

### [<a name="windowssystemremotesystems"></a>Windows.System.RemoteSystems](https://docs.microsoft.com/uwp/api/windows.system.remotesystems)

#### [<a name="remotesystem"></a>RemoteSystem](https://docs.microsoft.com/uwp/api/windows.system.remotesystems.remotesystem)

RemoteSystem.Apps

#### [<a name="remotesystemapp"></a>RemoteSystemApp](https://docs.microsoft.com/uwp/api/windows.system.remotesystems.remotesystemapp)

RemoteSystemApp <br> RemoteSystemApp.Attributes <br> RemoteSystemApp.DisplayName <br> RemoteSystemApp.Id <br> RemoteSystemApp.IsAvailableByProximity <br> RemoteSystemApp.IsAvailableBySpatialProximity

#### [<a name="remotesystemappregistration"></a>RemoteSystemAppRegistration](https://docs.microsoft.com/uwp/api/windows.system.remotesystems.remotesystemappregistration)

RemoteSystemAppRegistration <br> RemoteSystemAppRegistration.Attributes <br> RemoteSystemAppRegistration.GetDefault <br> RemoteSystemAppRegistration.GetForUser <br> RemoteSystemAppRegistration.SaveAsync <br> RemoteSystemAppRegistration.User

#### [<a name="remotesystemconnectioninfo"></a>RemoteSystemConnectionInfo](https://docs.microsoft.com/uwp/api/windows.system.remotesystems.remotesystemconnectioninfo)

RemoteSystemConnectionInfo <br> RemoteSystemConnectionInfo.IsProximal <br> RemoteSystemConnectionInfo.TryCreateFromAppServiceConnection

#### [<a name="remotesystemconnectionrequest"></a>RemoteSystemConnectionRequest](https://docs.microsoft.com/uwp/api/windows.system.remotesystems.remotesystemconnectionrequest)

RemoteSystemConnectionRequest.CreateForApp <br> RemoteSystemConnectionRequest.RemoteSystemApp

#### [<a name="remotesystemwebaccountfilter"></a>RemoteSystemWebAccountFilter](https://docs.microsoft.com/uwp/api/windows.system.remotesystems.remotesystemwebaccountfilter)

RemoteSystemWebAccountFilter <br> RemoteSystemWebAccountFilter.Account <br> RemoteSystemWebAccountFilter。 #ctor

### [<a name="windowssystemupdate"></a>Windows.System.Update](https://docs.microsoft.com/uwp/api/windows.system.update)

#### [<a name="systemupdateattentionrequiredreason"></a>SystemUpdateAttentionRequiredReason](https://docs.microsoft.com/uwp/api/windows.system.update.systemupdateattentionrequiredreason)

SystemUpdateAttentionRequiredReason

#### [<a name="systemupdateitem"></a>SystemUpdateItem](https://docs.microsoft.com/uwp/api/windows.system.update.systemupdateitem)

SystemUpdateItem <br> SystemUpdateItem.Description <br> SystemUpdateItem.DownloadProgress <br> SystemUpdateItem.ExtendedError <br> SystemUpdateItem.Id <br> SystemUpdateItem.InstallProgress <br> SystemUpdateItem.Revision <br> SystemUpdateItem.State <br> SystemUpdateItem.Title

#### [<a name="systemupdateitemstate"></a>SystemUpdateItemState](https://docs.microsoft.com/uwp/api/windows.system.update.systemupdateitemstate)

SystemUpdateItemState

#### [<a name="systemupdatelasterrorinfo"></a>SystemUpdateLastErrorInfo](https://docs.microsoft.com/uwp/api/windows.system.update.systemupdatelasterrorinfo)

SystemUpdateLastErrorInfo <br> SystemUpdateLastErrorInfo.ExtendedError <br> SystemUpdateLastErrorInfo.IsInteractive <br> SystemUpdateLastErrorInfo.State

#### [<a name="systemupdatemanager"></a>SystemUpdateManager](https://docs.microsoft.com/uwp/api/windows.system.update.systemupdatemanager)

SystemUpdateManager <br> SystemUpdateManager.AttentionRequiredReason <br> SystemUpdateManager.BlockAutomaticRebootAsync <br> SystemUpdateManager.DownloadProgress <br> SystemUpdateManager.ExtendedError <br> SystemUpdateManager.GetAutomaticRebootBlockIds <br> SystemUpdateManager.GetFlightRing <br> SystemUpdateManager.GetUpdateItems <br> SystemUpdateManager.InstallProgress <br> SystemUpdateManager.IsSupported <br> SystemUpdateManager.LastErrorInfo <br> SystemUpdateManager.LastUpdateCheckTime <br> SystemUpdateManager.LastUpdateInstallTime <br> SystemUpdateManager.RebootToCompleteInstall <br> SystemUpdateManager.SetFlightRing <br> SystemUpdateManager.StartCancelUpdates <br> SystemUpdateManager.StartInstall <br> SystemUpdateManager.State <br> SystemUpdateManager.StateChanged <br> SystemUpdateManager.TrySetUserActiveHours <br> SystemUpdateManager.UnblockAutomaticRebootAsync <br> SystemUpdateManager.UserActiveHoursEnd <br> SystemUpdateManager.UserActiveHoursMax <br> SystemUpdateManager.UserActiveHoursStart

#### [<a name="systemupdatemanagerstate"></a>SystemUpdateManagerState](https://docs.microsoft.com/uwp/api/windows.system.update.systemupdatemanagerstate)

SystemUpdateManagerState

#### [<a name="systemupdatestartinstallaction"></a>SystemUpdateStartInstallAction](https://docs.microsoft.com/uwp/api/windows.system.update.systemupdatestartinstallaction)

SystemUpdateStartInstallAction

### [<a name="windowssystemuserprofile"></a>Windows.System.UserProfile](https://docs.microsoft.com/uwp/api/windows.system.userprofile)

#### [<a name="assignedaccesssettings"></a>AssignedAccessSettings](https://docs.microsoft.com/uwp/api/windows.system.userprofile.assignedaccesssettings)

AssignedAccessSettings <br> AssignedAccessSettings.GetDefault <br> AssignedAccessSettings.GetForUser <br> AssignedAccessSettings.IsEnabled <br> AssignedAccessSettings.IsSingleAppKioskMode <br> AssignedAccessSettings.User

### [<a name="windowssystem"></a>Windows.System](https://docs.microsoft.com/uwp/api/windows.system)

#### [<a name="appurihandlerhost"></a>AppUriHandlerHost](https://docs.microsoft.com/uwp/api/windows.system.appurihandlerhost)

AppUriHandlerHost <br> AppUriHandlerHost。 #ctor <br> AppUriHandlerHost。 #ctor <br> AppUriHandlerHost.Name

#### [<a name="appurihandlerregistration"></a>AppUriHandlerRegistration](https://docs.microsoft.com/uwp/api/windows.system.appurihandlerregistration)

AppUriHandlerRegistration <br> AppUriHandlerRegistration.GetAppAddedHostsAsync <br> AppUriHandlerRegistration.Name <br> AppUriHandlerRegistration.SetAppAddedHostsAsync <br> AppUriHandlerRegistration.User

#### [<a name="appurihandlerregistrationmanager"></a>AppUriHandlerRegistrationManager](https://docs.microsoft.com/uwp/api/windows.system.appurihandlerregistrationmanager)

AppUriHandlerRegistrationManager <br> AppUriHandlerRegistrationManager.GetDefault <br> AppUriHandlerRegistrationManager.GetForUser <br> AppUriHandlerRegistrationManager.TryGetRegistration <br> AppUriHandlerRegistrationManager.User

#### [<a name="launcher"></a>ランチャー](https://docs.microsoft.com/uwp/api/windows.system.launcher)

Launcher.LaunchFolderPathAsync <br> Launcher.LaunchFolderPathAsync <br> Launcher.LaunchFolderPathForUserAsync <br> Launcher.LaunchFolderPathForUserAsync

## <a name="windowsui"></a>Windows.UI

### [<a name="windowsuiaccessibility"></a>Windows.UI.Accessibility](https://docs.microsoft.com/uwp/api/windows.ui.accessibility)

#### [<a name="screenreaderpositionchangedeventargs"></a>ScreenReaderPositionChangedEventArgs](https://docs.microsoft.com/uwp/api/windows.ui.accessibility.screenreaderpositionchangedeventargs)

ScreenReaderPositionChangedEventArgs <br> ScreenReaderPositionChangedEventArgs.IsReadingText <br> ScreenReaderPositionChangedEventArgs.ScreenPositionInRawPixels

#### [<a name="screenreaderservice"></a>ScreenReaderService](https://docs.microsoft.com/uwp/api/windows.ui.accessibility.screenreaderservice)

ScreenReaderService <br> ScreenReaderService.CurrentScreenReaderPosition <br> ScreenReaderService.ScreenReaderPositionChanged <br> ScreenReaderService。 #ctor

### [<a name="windowsuicompositioninteractions"></a>Windows.UI.Composition.Interactions](https://docs.microsoft.com/uwp/api/windows.ui.composition.interactions)

#### [<a name="interactionsourceconfiguration"></a>InteractionSourceConfiguration](https://docs.microsoft.com/uwp/api/windows.ui.composition.interactions.interactionsourceconfiguration)

InteractionSourceConfiguration <br> InteractionSourceConfiguration.PositionXSourceMode <br> InteractionSourceConfiguration.PositionYSourceMode <br> InteractionSourceConfiguration.ScaleSourceMode

#### [<a name="interactionsourceredirectionmode"></a>InteractionSourceRedirectionMode](https://docs.microsoft.com/uwp/api/windows.ui.composition.interactions.interactionsourceredirectionmode)

InteractionSourceRedirectionMode

#### [<a name="interactiontracker"></a>InteractionTracker](https://docs.microsoft.com/uwp/api/windows.ui.composition.interactions.interactiontracker)

InteractionTracker.IsInertiaFromImpulse <br> InteractionTracker.TryUpdatePosition <br> InteractionTracker.TryUpdatePositionBy

#### [<a name="interactiontrackerclampingoption"></a>InteractionTrackerClampingOption](https://docs.microsoft.com/uwp/api/windows.ui.composition.interactions.interactiontrackerclampingoption)

InteractionTrackerClampingOption

#### [<a name="interactiontrackerinertiastateenteredargs"></a>InteractionTrackerInertiaStateEnteredArgs](https://docs.microsoft.com/uwp/api/windows.ui.composition.interactions.interactiontrackerinertiastateenteredargs)

InteractionTrackerInertiaStateEnteredArgs.IsInertiaFromImpulse

#### [<a name="visualinteractionsource"></a>VisualInteractionSource](https://docs.microsoft.com/uwp/api/windows.ui.composition.interactions.visualinteractionsource)

VisualInteractionSource.PointerWheelConfig

### [<a name="windowsuicomposition"></a>Windows.UI.Composition](https://docs.microsoft.com/uwp/api/windows.ui.composition)

#### [<a name="animationpropertyaccessmode"></a>AnimationPropertyAccessMode](https://docs.microsoft.com/uwp/api/windows.ui.composition.animationpropertyaccessmode)

AnimationPropertyAccessMode

#### [<a name="animationpropertyinfo"></a>AnimationPropertyInfo](https://docs.microsoft.com/uwp/api/windows.ui.composition.animationpropertyinfo)

AnimationPropertyInfo <br> AnimationPropertyInfo.AccessMode

#### [<a name="booleankeyframeanimation"></a>BooleanKeyFrameAnimation](https://docs.microsoft.com/uwp/api/windows.ui.composition.booleankeyframeanimation)

BooleanKeyFrameAnimation <br> BooleanKeyFrameAnimation.InsertKeyFrame

#### [<a name="compositionanimation"></a>CompositionAnimation](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionanimation)

CompositionAnimation.SetExpressionReferenceParameter

#### [<a name="compositiongeometricclip"></a>CompositionGeometricClip](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositiongeometricclip)

CompositionGeometricClip <br> CompositionGeometricClip.Geometry <br> CompositionGeometricClip.ViewBox

#### [<a name="compositiongradientbrush"></a>CompositionGradientBrush](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositiongradientbrush)

CompositionGradientBrush.MappingMode

#### [<a name="compositionmappingmode"></a>CompositionMappingMode](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionmappingmode)

CompositionMappingMode

#### [<a name="compositionobject"></a>CompositionObject](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionobject)

CompositionObject.PopulatePropertyInfo <br> CompositionObject.StartAnimationGroupWithIAnimationObject <br> CompositionObject.StartAnimationWithIAnimationObject

#### [<a name="compositor"></a>Compositor](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositor)

Compositor.CreateBooleanKeyFrameAnimation <br> Compositor.CreateGeometricClip <br> Compositor.CreateGeometricClip <br> Compositor.CreateRedirectVisual <br> Compositor.CreateRedirectVisual

#### [<a name="ianimationobject"></a>IAnimationObject](https://docs.microsoft.com/uwp/api/windows.ui.composition.ianimationobject)

IAnimationObject <br> IAnimationObject.PopulatePropertyInfo

#### [<a name="redirectvisual"></a>RedirectVisual](https://docs.microsoft.com/uwp/api/windows.ui.composition.redirectvisual)

RedirectVisual <br> RedirectVisual.Source

### [<a name="windowsuiinputinkingpreview"></a>Windows.UI.Input.Inking.Preview](https://docs.microsoft.com/uwp/api/windows.ui.input.inking.preview)

#### [<a name="palmrejectiondelayzonepreview"></a>PalmRejectionDelayZonePreview](https://docs.microsoft.com/uwp/api/windows.ui.input.inking.preview.palmrejectiondelayzonepreview)

PalmRejectionDelayZonePreview <br> PalmRejectionDelayZonePreview.Close <br> PalmRejectionDelayZonePreview.CreateForVisual <br> PalmRejectionDelayZonePreview.CreateForVisual

### [<a name="windowsuiinputinking"></a>Windows.UI.Input.Inking](https://docs.microsoft.com/uwp/api/windows.ui.input.inking)

#### [<a name="handwritinglineheight"></a>HandwritingLineHeight](https://docs.microsoft.com/uwp/api/windows.ui.input.inking.handwritinglineheight)

HandwritingLineHeight

#### [<a name="penandinksettings"></a>PenAndInkSettings](https://docs.microsoft.com/uwp/api/windows.ui.input.inking.penandinksettings)

PenAndInkSettings <br> PenAndInkSettings.FontFamilyName <br> PenAndInkSettings.GetDefault <br> PenAndInkSettings.HandwritingLineHeight <br> PenAndInkSettings.IsHandwritingDirectlyIntoTextFieldEnabled <br> PenAndInkSettings.IsTouchHandwritingEnabled <br> PenAndInkSettings.PenHandedness <br> PenAndInkSettings.UserConsentsToHandwritingTelemetryCollection

#### [<a name="penhandedness"></a>PenHandedness](https://docs.microsoft.com/uwp/api/windows.ui.input.inking.penhandedness)

PenHandedness

### [<a name="windowsuinotifications"></a>Windows.UI.Notifications](https://docs.microsoft.com/uwp/api/windows.ui.notifications)

#### [<a name="scheduledtoastnotificationshowingeventargs"></a>ScheduledToastNotificationShowingEventArgs](https://docs.microsoft.com/uwp/api/windows.ui.notifications.scheduledtoastnotificationshowingeventargs)

ScheduledToastNotificationShowingEventArgs <br> ScheduledToastNotificationShowingEventArgs.Cancel <br> ScheduledToastNotificationShowingEventArgs.GetDeferral <br> ScheduledToastNotificationShowingEventArgs.ScheduledToastNotification

#### [<a name="toastnotifier"></a>ToastNotifier](https://docs.microsoft.com/uwp/api/windows.ui.notifications.toastnotifier)

ToastNotifier.ScheduledToastNotificationShowing

### [<a name="windowsuishell"></a>Windows.UI.Shell](https://docs.microsoft.com/uwp/api/windows.ui.shell)

#### [<a name="securityappkind"></a>SecurityAppKind](https://docs.microsoft.com/uwp/api/windows.ui.shell.securityappkind)

SecurityAppKind

#### [<a name="securityappmanager"></a>SecurityAppManager](https://docs.microsoft.com/uwp/api/windows.ui.shell.securityappmanager)

SecurityAppManager <br> SecurityAppManager.Register <br> SecurityAppManager。 #ctor <br> SecurityAppManager.Unregister <br> SecurityAppManager.UpdateState

#### [<a name="securityappstate"></a>SecurityAppState](https://docs.microsoft.com/uwp/api/windows.ui.shell.securityappstate)

SecurityAppState

#### [<a name="securityappsubstatus"></a>SecurityAppSubstatus](https://docs.microsoft.com/uwp/api/windows.ui.shell.securityappsubstatus)

SecurityAppSubstatus

#### [<a name="taskbarmanager"></a>TaskbarManager](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager)

TaskbarManager.IsSecondaryTilePinnedAsync <br> TaskbarManager.RequestPinSecondaryTileAsync <br> TaskbarManager.TryUnpinSecondaryTileAsync

### [<a name="windowsuistartscreen"></a>Windows.UI.StartScreen](https://docs.microsoft.com/uwp/api/windows.ui.startscreen)

#### [<a name="startscreenmanager"></a>StartScreenManager](https://docs.microsoft.com/uwp/api/windows.ui.startscreen.startscreenmanager)

StartScreenManager.ContainsSecondaryTileAsync <br> StartScreenManager.TryRemoveSecondaryTileAsync

### [<a name="windowsuitextcore"></a>Windows.UI.Text.Core](https://docs.microsoft.com/uwp/api/windows.ui.text.core)

#### [<a name="coretextlayoutrequest"></a>CoreTextLayoutRequest](https://docs.microsoft.com/uwp/api/windows.ui.text.core.coretextlayoutrequest)

CoreTextLayoutRequest.LayoutBoundsVisualPixels

### [<a name="windowsuitext"></a>Windows.UI.Text](https://docs.microsoft.com/uwp/api/windows.ui.text)

#### [<a name="richedittextdocument"></a>RichEditTextDocument](https://docs.microsoft.com/uwp/api/windows.ui.text.richedittextdocument)

RichEditTextDocument.ClearUndoRedoHistory

### [<a name="windowsuiviewmanagementcore"></a>Windows.UI.ViewManagement.Core](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.core)

#### [<a name="coreinputview"></a>CoreInputView](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.core.coreinputview)

CoreInputView.TryHide <br> CoreInputView.TryShow <br> CoreInputView.TryShow

#### [<a name="coreinputviewkind"></a>CoreInputViewKind](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.core.coreinputviewkind)

CoreInputViewKind

### [<a name="windowsuiwebui"></a>Windows.UI.WebUI](https://docs.microsoft.com/uwp/api/windows.ui.webui)

#### [<a name="backgroundactivatedeventargs"></a>BackgroundActivatedEventArgs](https://docs.microsoft.com/uwp/api/windows.ui.webui.backgroundactivatedeventargs)

BackgroundActivatedEventArgs <br> BackgroundActivatedEventArgs.TaskInstance

#### [<a name="backgroundactivatedeventhandler"></a>BackgroundActivatedEventHandler](https://docs.microsoft.com/uwp/api/windows.ui.webui.backgroundactivatedeventhandler)

BackgroundActivatedEventHandler

#### [<a name="newwebuiviewcreatedeventargs"></a>NewWebUIViewCreatedEventArgs](https://docs.microsoft.com/uwp/api/windows.ui.webui.newwebuiviewcreatedeventargs)

NewWebUIViewCreatedEventArgs <br> NewWebUIViewCreatedEventArgs.ActivatedEventArgs <br> NewWebUIViewCreatedEventArgs.GetDeferral <br> NewWebUIViewCreatedEventArgs.HasPendingNavigate <br> NewWebUIViewCreatedEventArgs.WebUIView

#### [<a name="webuiapplication"></a>WebUIApplication](https://docs.microsoft.com/uwp/api/windows.ui.webui.webuiapplication)

WebUIApplication.BackgroundActivated <br> WebUIApplication.NewWebUIViewCreated

#### [<a name="webuiview"></a>WebUIView](https://docs.microsoft.com/uwp/api/windows.ui.webui.webuiview)

WebUIView <br> WebUIView.Activated <br> WebUIView.AddInitializeScript <br> WebUIView.ApplicationViewId <br> WebUIView.BuildLocalStreamUri <br> WebUIView.CanGoBack <br> WebUIView.CanGoForward <br> WebUIView.CapturePreviewToStreamAsync <br> WebUIView.CaptureSelectedContentToDataPackageAsync <br> WebUIView.Closed <br> WebUIView.ContainsFullScreenElement <br> WebUIView.ContainsFullScreenElementChanged <br> WebUIView.ContentLoading <br> WebUIView.CreateAsync <br> WebUIView.CreateAsync <br> WebUIView.DefaultBackgroundColor <br> WebUIView.DeferredPermissionRequests <br> WebUIView.DocumentTitle <br> WebUIView.DOMContentLoaded <br> WebUIView.FrameContentLoading <br> WebUIView.FrameDOMContentLoaded <br> WebUIView.FrameNavigationCompleted <br> WebUIView.FrameNavigationStarting <br> WebUIView.GetDeferredPermissionRequestById <br> WebUIView.GoBack <br> WebUIView.GoForward <br> WebUIView.IgnoreApplicationContentUriRulesNavigationRestrictions <br> WebUIView.InvokeScriptAsync <br> WebUIView.LongRunningScriptDetected <br> WebUIView.Navigate <br> WebUIView.NavigateToLocalStreamUri <br> WebUIView.NavigateToString <br> WebUIView.NavigateWithHttpRequestMessage <br> WebUIView.NavigationCompleted <br> WebUIView.NavigationStarting <br> WebUIView.NewWindowRequested <br> WebUIView.PermissionRequested <br> WebUIView.Refresh <br> WebUIView.ScriptNotify <br> WebUIView.Settings <br> WebUIView.Source <br> WebUIView.Stop <br> WebUIView.UnsafeContentWarningDisplaying <br> WebUIView.UnsupportedUriSchemeIdentified <br> WebUIView.UnviewableContentIdentified <br> WebUIView.WebResourceRequested

### [<a name="windowsuixamlautomationpeers"></a>Windows.UI.Xaml.Automation.Peers](https://docs.microsoft.com/uwp/api/windows.ui.xaml.automation.peers)

#### [<a name="appbarbuttonautomationpeer"></a>AppBarButtonAutomationPeer](https://docs.microsoft.com/uwp/api/windows.ui.xaml.automation.peers.appbarbuttonautomationpeer)

AppBarButtonAutomationPeer.Collapse <br> AppBarButtonAutomationPeer.Expand <br> AppBarButtonAutomationPeer.ExpandCollapseState

#### [<a name="automationpeer"></a>AutomationPeer](https://docs.microsoft.com/uwp/api/windows.ui.xaml.automation.peers.automationpeer)

AutomationPeer.IsDialog <br> AutomationPeer.IsDialogCore

#### [<a name="menubarautomationpeer"></a>MenuBarAutomationPeer](https://docs.microsoft.com/uwp/api/windows.ui.xaml.automation.peers.menubarautomationpeer)

MenuBarAutomationPeer <br> MenuBarAutomationPeer。 #ctor

#### [<a name="menubaritemautomationpeer"></a>MenuBarItemAutomationPeer](https://docs.microsoft.com/uwp/api/windows.ui.xaml.automation.peers.menubaritemautomationpeer)

MenuBarItemAutomationPeer <br> MenuBarItemAutomationPeer.Collapse <br> MenuBarItemAutomationPeer.Expand <br> MenuBarItemAutomationPeer.ExpandCollapseState <br> MenuBarItemAutomationPeer.Invoke <br> MenuBarItemAutomationPeer。 #ctor

### [<a name="windowsuixamlautomation"></a>Windows.UI.Xaml.Automation](https://docs.microsoft.com/uwp/api/windows.ui.xaml.automation)

#### [<a name="automationelementidentifiers"></a>AutomationElementIdentifiers](https://docs.microsoft.com/uwp/api/windows.ui.xaml.automation.automationelementidentifiers)

AutomationElementIdentifiers.IsDialogProperty

#### [<a name="automationproperties"></a>AutomationProperties](https://docs.microsoft.com/uwp/api/windows.ui.xaml.automation.automationproperties)

AutomationProperties.GetIsDialog <br> AutomationProperties.IsDialogProperty <br> AutomationProperties.SetIsDialog

### [<a name="windowsuixamlcontrolsmaps"></a>Windows.UI.Xaml.Controls.Maps](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps)

#### [<a name="maptileanimationstate"></a>MapTileAnimationState](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.maptileanimationstate)

MapTileAnimationState

#### [<a name="maptilebitmaprequestedeventargs"></a>MapTileBitmapRequestedEventArgs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.maptilebitmaprequestedeventargs)

MapTileBitmapRequestedEventArgs.FrameIndex

#### [<a name="maptilesource"></a>MapTileSource](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.maptilesource)

MapTileSource.AnimationState <br> MapTileSource.AnimationStateProperty <br> MapTileSource.AutoPlay <br> MapTileSource.AutoPlayProperty <br> MapTileSource.FrameCount <br> MapTileSource.FrameCountProperty <br> MapTileSource.FrameDuration <br> MapTileSource.FrameDurationProperty <br> MapTileSource.Pause <br> MapTileSource.Play <br> MapTileSource.Stop

#### [<a name="maptileurirequestedeventargs"></a>MapTileUriRequestedEventArgs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.maptileurirequestedeventargs)

MapTileUriRequestedEventArgs.FrameIndex

### [<a name="windowsuixamlcontrolsprimitives"></a>Windows.UI.Xaml.Controls.Primitives](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.primitives)

#### [<a name="commandbarflyoutcommandbar"></a>CommandBarFlyoutCommandBar](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.primitives.commandbarflyoutcommandbar)

CommandBarFlyoutCommandBar <br> CommandBarFlyoutCommandBar。 #ctor <br> CommandBarFlyoutCommandBar.FlyoutTemplateSettings

#### [<a name="commandbarflyoutcommandbartemplatesettings"></a>CommandBarFlyoutCommandBarTemplateSettings](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.primitives.commandbarflyoutcommandbartemplatesettings)

CommandBarFlyoutCommandBarTemplateSettings <br> CommandBarFlyoutCommandBarTemplateSettings.CloseAnimationEndPosition <br> CommandBarFlyoutCommandBarTemplateSettings.ContentClipRect <br> CommandBarFlyoutCommandBarTemplateSettings.CurrentWidth <br> CommandBarFlyoutCommandBarTemplateSettings.ExpandDownAnimationEndPosition <br> CommandBarFlyoutCommandBarTemplateSettings.ExpandDownAnimationHoldPosition <br> CommandBarFlyoutCommandBarTemplateSettings.ExpandDownAnimationStartPosition <br> CommandBarFlyoutCommandBarTemplateSettings.ExpandDownOverflowVerticalPosition <br> CommandBarFlyoutCommandBarTemplateSettings.ExpandedWidth <br> CommandBarFlyoutCommandBarTemplateSettings.ExpandUpAnimationEndPosition <br> CommandBarFlyoutCommandBarTemplateSettings.ExpandUpAnimationHoldPosition <br> CommandBarFlyoutCommandBarTemplateSettings.ExpandUpAnimationStartPosition <br> CommandBarFlyoutCommandBarTemplateSettings.ExpandUpOverflowVerticalPosition <br> CommandBarFlyoutCommandBarTemplateSettings.OpenAnimationEndPosition <br> CommandBarFlyoutCommandBarTemplateSettings.OpenAnimationStartPosition <br> CommandBarFlyoutCommandBarTemplateSettings.OverflowContentClipRect <br> CommandBarFlyoutCommandBarTemplateSettings.WidthExpansionAnimationEndPosition <br> CommandBarFlyoutCommandBarTemplateSettings.WidthExpansionAnimationStartPosition <br> CommandBarFlyoutCommandBarTemplateSettings.WidthExpansionDelta <br> CommandBarFlyoutCommandBarTemplateSettings.WidthExpansionMoreButtonAnimationEndPosition <br> CommandBarFlyoutCommandBarTemplateSettings.WidthExpansionMoreButtonAnimationStartPosition

#### [<a name="flyoutbase"></a>FlyoutBase](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.primitives.flyoutbase)

FlyoutBase.AreOpenCloseAnimationsEnabled <br> FlyoutBase.AreOpenCloseAnimationsEnabledProperty <br> FlyoutBase.InputDevicePrefersPrimaryCommands <br> FlyoutBase.InputDevicePrefersPrimaryCommandsProperty <br> FlyoutBase.IsOpen <br> FlyoutBase.IsOpenProperty <br> FlyoutBase.ShowAt <br> FlyoutBase.ShowMode <br> FlyoutBase.ShowModeProperty <br> FlyoutBase.TargetProperty

#### [<a name="flyoutshowmode"></a>FlyoutShowMode](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.primitives.flyoutshowmode)

FlyoutShowMode

#### [<a name="flyoutshowoptions"></a>FlyoutShowOptions](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.primitives.flyoutshowoptions)

FlyoutShowOptions <br> FlyoutShowOptions.ExclusionRect <br> FlyoutShowOptions。 #ctor <br> FlyoutShowOptions.Placement <br> FlyoutShowOptions.Position <br> FlyoutShowOptions.ShowMode

#### [<a name="navigationviewitempresenter"></a>NavigationViewItemPresenter](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.primitives.navigationviewitempresenter)

NavigationViewItemPresenter <br> NavigationViewItemPresenter.Icon <br> NavigationViewItemPresenter.IconProperty <br> NavigationViewItemPresenter。 #ctor

### [<a name="windowsuixamlcontrols"></a>Windows.UI.Xaml.Controls](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls)

#### [<a name="anchorrequestedeventargs"></a>AnchorRequestedEventArgs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.anchorrequestedeventargs)

AnchorRequestedEventArgs <br> AnchorRequestedEventArgs.Anchor <br> AnchorRequestedEventArgs.AnchorCandidates

#### [<a name="appbarelementcontainer"></a>AppBarElementContainer](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.appbarelementcontainer)

AppBarElementContainer <br> AppBarElementContainer。 #ctor <br> AppBarElementContainer.DynamicOverflowOrder <br> AppBarElementContainer.DynamicOverflowOrderProperty <br> AppBarElementContainer.IsCompact <br> AppBarElementContainer.IsCompactProperty <br> AppBarElementContainer.IsInOverflow <br> AppBarElementContainer.IsInOverflowProperty

#### [<a name="autosuggestbox"></a>AutoSuggestBox](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.autosuggestbox)

AutoSuggestBox.Description <br> AutoSuggestBox.DescriptionProperty

#### [<a name="backgroundsizing"></a>BackgroundSizing](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.backgroundsizing)

BackgroundSizing

#### [<a name="border"></a>境界線](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.border)

Border.BackgroundSizing <br> Border.BackgroundSizingProperty <br> Border.BackgroundTransition

#### [<a name="calendardatepicker"></a>CalendarDatePicker](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.calendardatepicker)

CalendarDatePicker.Description <br> CalendarDatePicker.DescriptionProperty

#### [<a name="combobox"></a>ComboBox](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.combobox)

ComboBox.Description <br> ComboBox.DescriptionProperty <br> ComboBox.IsEditableProperty <br> ComboBox.Text <br> ComboBox.TextBoxStyle <br> ComboBox.TextBoxStyleProperty <br> ComboBox.TextProperty <br> ComboBox.TextSubmitted

#### [<a name="comboboxtextsubmittedeventargs"></a>ComboBoxTextSubmittedEventArgs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.comboboxtextsubmittedeventargs)

ComboBoxTextSubmittedEventArgs <br> ComboBoxTextSubmittedEventArgs.Handled <br> ComboBoxTextSubmittedEventArgs.Text

#### [<a name="commandbarflyout"></a>CommandBarFlyout](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.commandbarflyout)

CommandBarFlyout <br> CommandBarFlyout。 #ctor <br> CommandBarFlyout.PrimaryCommands <br> CommandBarFlyout.SecondaryCommands

#### [<a name="contentpresenter"></a>ContentPresenter](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.contentpresenter)

ContentPresenter.BackgroundSizing <br> ContentPresenter.BackgroundSizingProperty <br> ContentPresenter.BackgroundTransition

#### [<a name="control"></a>コントロール](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.control)

Control.BackgroundSizing <br> Control.BackgroundSizingProperty <br> Control.CornerRadius <br> Control.CornerRadiusProperty

#### [<a name="datatemplateselector"></a>DataTemplateSelector](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.datatemplateselector)

DataTemplateSelector.GetElement <br> DataTemplateSelector.RecycleElement

#### [<a name="datepicker"></a>DatePicker](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.datepicker)

DatePicker.SelectedDate <br> DatePicker.SelectedDateChanged <br> DatePicker.SelectedDateProperty

#### [<a name="datepickerselectedvaluechangedeventargs"></a>DatePickerSelectedValueChangedEventArgs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.datepickerselectedvaluechangedeventargs)

DatePickerSelectedValueChangedEventArgs <br> DatePickerSelectedValueChangedEventArgs.NewDate <br> DatePickerSelectedValueChangedEventArgs.OldDate

#### [<a name="dropdownbutton"></a>DropDownButton](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.dropdownbutton)

DropDownButton <br> DropDownButton。 #ctor

#### [<a name="dropdownbuttonautomationpeer"></a>DropDownButtonAutomationPeer](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.dropdownbuttonautomationpeer)

DropDownButtonAutomationPeer <br> DropDownButtonAutomationPeer.Collapse <br> DropDownButtonAutomationPeer。 #ctor <br> DropDownButtonAutomationPeer.Expand <br> DropDownButtonAutomationPeer.ExpandCollapseState

#### [<a name="frame"></a>フレーム](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.frame)

Frame.IsNavigationStackEnabled <br> Frame.IsNavigationStackEnabledProperty <br> Frame.NavigateToType

#### [<a name="grid"></a>グリッド](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.grid)

Grid.BackgroundSizing <br> Grid.BackgroundSizingProperty

#### [<a name="iconsourceelement"></a>IconSourceElement](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.iconsourceelement)

IconSourceElement <br> IconSourceElement.IconSource <br> IconSourceElement。 #ctor <br> IconSourceElement.IconSourceProperty

#### [<a name="iscrollanchorprovider"></a>IScrollAnchorProvider](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.iscrollanchorprovider)

IScrollAnchorProvider <br> IScrollAnchorProvider.CurrentAnchor <br> IScrollAnchorProvider.RegisterAnchorCandidate <br> IScrollAnchorProvider.UnregisterAnchorCandidate

#### [<a name="menubar"></a>メニュー バー](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.menubar)

メニュー バー <br> MenuBar.Items <br> MenuBar.ItemsProperty <br> メニュー バー。 #ctor

#### [<a name="menubaritem"></a>MenuBarItem](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.menubaritem)

MenuBarItem <br> MenuBarItem.Items <br> MenuBarItem.ItemsProperty <br> MenuBarItem。 #ctor <br> MenuBarItem.Title <br> MenuBarItem.TitleProperty

#### [<a name="menubaritemflyout"></a>MenuBarItemFlyout](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.menubaritemflyout)

MenuBarItemFlyout <br> MenuBarItemFlyout。 #ctor

#### [<a name="navigationview"></a>NavigationView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview)

NavigationView.ContentOverlay <br> NavigationView.ContentOverlayProperty <br> NavigationView.IsPaneVisible <br> NavigationView.IsPaneVisibleProperty <br> NavigationView.OverflowLabelMode <br> NavigationView.OverflowLabelModeProperty <br> NavigationView.PaneCustomContent <br> NavigationView.PaneCustomContentProperty <br> NavigationView.PaneDisplayMode <br> NavigationView.PaneDisplayModeProperty <br> NavigationView.PaneHeader <br> NavigationView.PaneHeaderProperty <br> NavigationView.SelectionFollowsFocus <br> NavigationView.SelectionFollowsFocusProperty <br> NavigationView.ShoulderNavigationEnabled <br> NavigationView.ShoulderNavigationEnabledProperty <br> NavigationView.TemplateSettings <br> NavigationView.TemplateSettingsProperty

#### [<a name="navigationviewitem"></a>NavigationViewItem](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewitem)

NavigationViewItem.SelectsOnInvoked <br> NavigationViewItem.SelectsOnInvokedProperty

#### [<a name="navigationviewiteminvokedeventargs"></a>NavigationViewItemInvokedEventArgs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewiteminvokedeventargs)

NavigationViewItemInvokedEventArgs.InvokedItemContainer <br> NavigationViewItemInvokedEventArgs.RecommendedNavigationTransitionInfo

#### [<a name="navigationviewoverflowlabelmode"></a>NavigationViewOverflowLabelMode](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewoverflowlabelmode)

NavigationViewOverflowLabelMode

#### [<a name="navigationviewpanedisplaymode"></a>NavigationViewPaneDisplayMode](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewpanedisplaymode)

NavigationViewPaneDisplayMode

#### [<a name="navigationviewselectionchangedeventargs"></a>NavigationViewSelectionChangedEventArgs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewselectionchangedeventargs)

NavigationViewSelectionChangedEventArgs.RecommendedNavigationTransitionInfo <br> NavigationViewSelectionChangedEventArgs.SelectedItemContainer

#### [<a name="navigationviewselectionfollowsfocus"></a>NavigationViewSelectionFollowsFocus](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewselectionfollowsfocus)

NavigationViewSelectionFollowsFocus

#### [<a name="navigationviewshouldernavigationenabled"></a>NavigationViewShoulderNavigationEnabled](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewshouldernavigationenabled)

NavigationViewShoulderNavigationEnabled

#### [<a name="navigationviewtemplatesettings"></a>NavigationViewTemplateSettings](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewtemplatesettings)

NavigationViewTemplateSettings <br> NavigationViewTemplateSettings.BackButtonVisibility <br> NavigationViewTemplateSettings.BackButtonVisibilityProperty <br> NavigationViewTemplateSettings.LeftPaneVisibility <br> NavigationViewTemplateSettings.LeftPaneVisibilityProperty <br> NavigationViewTemplateSettings。 #ctor <br> NavigationViewTemplateSettings.OverflowButtonVisibility <br> NavigationViewTemplateSettings.OverflowButtonVisibilityProperty <br> NavigationViewTemplateSettings.PaneToggleButtonVisibility <br> NavigationViewTemplateSettings.PaneToggleButtonVisibilityProperty <br> NavigationViewTemplateSettings.SingleSelectionFollowsFocus <br> NavigationViewTemplateSettings.SingleSelectionFollowsFocusProperty <br> NavigationViewTemplateSettings.TopPadding <br> NavigationViewTemplateSettings.TopPaddingProperty <br> NavigationViewTemplateSettings.TopPaneVisibility <br> NavigationViewTemplateSettings.TopPaneVisibilityProperty

#### [<a name="panel"></a>Panel](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.panel)

Panel.BackgroundTransition

#### [<a name="passwordbox"></a>PasswordBox](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.passwordbox)

PasswordBox.CanPasteClipboardContent <br> PasswordBox.CanPasteClipboardContentProperty <br> PasswordBox.Description <br> PasswordBox.DescriptionProperty <br> PasswordBox.PasteFromClipboard <br> PasswordBox.SelectionFlyout <br> PasswordBox.SelectionFlyoutProperty

#### [<a name="relativepanel"></a>RelativePanel](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.relativepanel)

RelativePanel.BackgroundSizing <br> RelativePanel.BackgroundSizingProperty

#### [<a name="richeditbox"></a>RichEditBox](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.richeditbox)

RichEditBox.Description <br> RichEditBox.DescriptionProperty <br> RichEditBox.ProofingMenuFlyout <br> RichEditBox.ProofingMenuFlyoutProperty <br> RichEditBox.SelectionChanging <br> RichEditBox.SelectionFlyout <br> RichEditBox.SelectionFlyoutProperty <br> RichEditBox.TextDocument

#### [<a name="richeditboxselectionchangingeventargs"></a>RichEditBoxSelectionChangingEventArgs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.richeditboxselectionchangingeventargs)

RichEditBoxSelectionChangingEventArgs <br> RichEditBoxSelectionChangingEventArgs.Cancel <br> RichEditBoxSelectionChangingEventArgs.SelectionLength <br> RichEditBoxSelectionChangingEventArgs.SelectionStart

#### [<a name="richtextblock"></a>RichTextBlock](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.richtextblock)

RichTextBlock.CopySelectionToClipboard <br> RichTextBlock.SelectionFlyout <br> RichTextBlock.SelectionFlyoutProperty

#### [<a name="scrollcontentpresenter"></a>ScrollContentPresenter](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.scrollcontentpresenter)

ScrollContentPresenter.CanContentRenderOutsideBounds <br> ScrollContentPresenter.CanContentRenderOutsideBoundsProperty <br> ScrollContentPresenter.SizesContentToTemplatedParent <br> ScrollContentPresenter.SizesContentToTemplatedParentProperty

#### [<a name="scrollviewer"></a>ScrollViewer](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.scrollviewer)

ScrollViewer.AnchorRequested <br> ScrollViewer.CanContentRenderOutsideBounds <br> ScrollViewer.CanContentRenderOutsideBoundsProperty <br> ScrollViewer.CurrentAnchor <br> ScrollViewer.GetCanContentRenderOutsideBounds <br> ScrollViewer.HorizontalAnchorRatio <br> ScrollViewer.HorizontalAnchorRatioProperty <br> ScrollViewer.ReduceViewportForCoreInputViewOcclusions <br> ScrollViewer.ReduceViewportForCoreInputViewOcclusionsProperty <br> ScrollViewer.RegisterAnchorCandidate <br> ScrollViewer.SetCanContentRenderOutsideBounds <br> ScrollViewer.UnregisterAnchorCandidate <br> ScrollViewer.VerticalAnchorRatio <br> ScrollViewer.VerticalAnchorRatioProperty

#### [<a name="splitbutton"></a>SplitButton](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.splitbutton)

SplitButton <br> SplitButton.Click <br> SplitButton.Command <br> SplitButton.CommandParameter <br> SplitButton.CommandParameterProperty <br> SplitButton.CommandProperty <br> SplitButton.Flyout <br> SplitButton.FlyoutProperty <br> SplitButton。 #ctor

#### [<a name="splitbuttonautomationpeer"></a>SplitButtonAutomationPeer](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.splitbuttonautomationpeer)

SplitButtonAutomationPeer <br> SplitButtonAutomationPeer.Collapse <br> SplitButtonAutomationPeer.Expand <br> SplitButtonAutomationPeer.ExpandCollapseState <br> SplitButtonAutomationPeer.Invoke <br> SplitButtonAutomationPeer。 #ctor

#### [<a name="splitbuttonclickeventargs"></a>SplitButtonClickEventArgs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.splitbuttonclickeventargs)

SplitButtonClickEventArgs

#### [<a name="stackpanel"></a>StackPanel](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.stackpanel)

StackPanel.BackgroundSizing <br> StackPanel.BackgroundSizingProperty

#### [<a name="textblock"></a>TextBlock](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.textblock)

TextBlock.CopySelectionToClipboard <br> TextBlock.SelectionFlyout <br> TextBlock.SelectionFlyoutProperty

#### [<a name="textbox"></a>TextBox](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.textbox)

TextBox.CanPasteClipboardContent <br> TextBox.CanPasteClipboardContentProperty <br> TextBox.CanRedo <br> TextBox.CanRedoProperty <br> TextBox.CanUndo <br> TextBox.CanUndoProperty <br> TextBox.ClearUndoRedoHistory <br> TextBox.CopySelectionToClipboard <br> TextBox.CutSelectionToClipboard <br> TextBox.Description <br> TextBox.DescriptionProperty <br> TextBox.PasteFromClipboard <br> TextBox.ProofingMenuFlyout <br> TextBox.ProofingMenuFlyoutProperty <br> TextBox.Redo <br> TextBox.SelectionChanging <br> TextBox.SelectionFlyout <br> TextBox.SelectionFlyoutProperty <br> TextBox.Undo

#### [<a name="textboxselectionchangingeventargs"></a>TextBoxSelectionChangingEventArgs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.textboxselectionchangingeventargs)

TextBoxSelectionChangingEventArgs <br> TextBoxSelectionChangingEventArgs.Cancel <br> TextBoxSelectionChangingEventArgs.SelectionLength <br> TextBoxSelectionChangingEventArgs.SelectionStart

#### [<a name="textcommandbarflyout"></a>TextCommandBarFlyout](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.textcommandbarflyout)

TextCommandBarFlyout <br> TextCommandBarFlyout。 #ctor

#### [<a name="timepicker"></a>TimePicker](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.timepicker)

TimePicker.SelectedTime <br> TimePicker.SelectedTimeChanged <br> TimePicker.SelectedTimeProperty

#### [<a name="timepickerselectedvaluechangedeventargs"></a>TimePickerSelectedValueChangedEventArgs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.timepickerselectedvaluechangedeventargs)

TimePickerSelectedValueChangedEventArgs <br> TimePickerSelectedValueChangedEventArgs.NewTime <br> TimePickerSelectedValueChangedEventArgs.OldTime

#### [<a name="togglesplitbutton"></a>ToggleSplitButton](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.togglesplitbutton)

ToggleSplitButton <br> ToggleSplitButton.IsChecked <br> ToggleSplitButton.IsCheckedChanged <br> ToggleSplitButton。 #ctor

#### [<a name="togglesplitbuttonautomationpeer"></a>ToggleSplitButtonAutomationPeer](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.togglesplitbuttonautomationpeer)

ToggleSplitButtonAutomationPeer <br> ToggleSplitButtonAutomationPeer.Collapse <br> ToggleSplitButtonAutomationPeer.Expand <br> ToggleSplitButtonAutomationPeer.ExpandCollapseState <br> ToggleSplitButtonAutomationPeer.Toggle <br> ToggleSplitButtonAutomationPeer。 #ctor <br> ToggleSplitButtonAutomationPeer.ToggleState

#### [<a name="togglesplitbuttonischeckedchangedeventargs"></a>ToggleSplitButtonIsCheckedChangedEventArgs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.togglesplitbuttonischeckedchangedeventargs)

ToggleSplitButtonIsCheckedChangedEventArgs

#### [<a name="tooltip"></a>ToolTip](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.tooltip)

ToolTip.PlacementRect <br> ToolTip.PlacementRectProperty

#### [<a name="treeview"></a>TreeView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.treeview)

TreeView.CanDragItems <br> TreeView.CanDragItemsProperty <br> TreeView.CanReorderItems <br> TreeView.CanReorderItemsProperty <br> TreeView.ContainerFromItem <br> TreeView.ContainerFromNode <br> TreeView.DragItemsCompleted <br> TreeView.DragItemsStarting <br> TreeView.ItemContainerStyle <br> TreeView.ItemContainerStyleProperty <br> TreeView.ItemContainerStyleSelector <br> TreeView.ItemContainerStyleSelectorProperty <br> TreeView.ItemContainerTransitions <br> TreeView.ItemContainerTransitionsProperty <br> TreeView.ItemFromContainer <br> TreeView.ItemsSource <br> TreeView.ItemsSourceProperty <br> TreeView.ItemTemplate <br> TreeView.ItemTemplateProperty <br> TreeView.ItemTemplateSelector <br> TreeView.ItemTemplateSelectorProperty <br> TreeView.NodeFromContainer

#### [<a name="treeviewcollapsedeventargs"></a>TreeViewCollapsedEventArgs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.treeviewcollapsedeventargs)

TreeViewCollapsedEventArgs.Item

#### [<a name="treeviewdragitemscompletedeventargs"></a>TreeViewDragItemsCompletedEventArgs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.treeviewdragitemscompletedeventargs)

TreeViewDragItemsCompletedEventArgs <br> TreeViewDragItemsCompletedEventArgs.DropResult <br> TreeViewDragItemsCompletedEventArgs.Items

#### [<a name="treeviewdragitemsstartingeventargs"></a>TreeViewDragItemsStartingEventArgs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.treeviewdragitemsstartingeventargs)

TreeViewDragItemsStartingEventArgs <br> TreeViewDragItemsStartingEventArgs.Cancel <br> TreeViewDragItemsStartingEventArgs.Data <br> TreeViewDragItemsStartingEventArgs.Items

#### [<a name="treeviewexpandingeventargs"></a>TreeViewExpandingEventArgs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.treeviewexpandingeventargs)

TreeViewExpandingEventArgs.Item

#### [<a name="treeviewitem"></a>TreeViewItem](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.treeviewitem)

TreeViewItem.HasUnrealizedChildren <br> TreeViewItem.HasUnrealizedChildrenProperty <br> TreeViewItem.ItemsSource <br> TreeViewItem.ItemsSourceProperty

#### [<a name="webview"></a>WebView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.webview)

WebView.WebResourceRequested

#### [<a name="webviewwebresourcerequestedeventargs"></a>WebViewWebResourceRequestedEventArgs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.webviewwebresourcerequestedeventargs)

WebViewWebResourceRequestedEventArgs <br> WebViewWebResourceRequestedEventArgs.GetDeferral <br> WebViewWebResourceRequestedEventArgs.Request <br> WebViewWebResourceRequestedEventArgs.Response

### [<a name="windowsuixamlcoredirect"></a>Windows.UI.Xaml.Core.Direct](https://docs.microsoft.com/uwp/api/windows.ui.xaml.core.direct)

#### [<a name="ixamldirectobject"></a>IXamlDirectObject](https://docs.microsoft.com/uwp/api/windows.ui.xaml.core.direct.ixamldirectobject)

IXamlDirectObject

### [<a name="windowsuixamlcoredirect"></a>Windows.UI.Xaml.Core.Direct](https://docs.microsoft.com/uwp/api/windows.ui.xaml.core.direct)

#### [<a name="xamldirect"></a>XamlDirect](https://docs.microsoft.com/uwp/api/windows.ui.xaml.core.direct.xamldirect)

XamlDirect <br> XamlDirect.AddEventHandler <br> XamlDirect.AddEventHandler <br> XamlDirect.AddToCollection <br> XamlDirect.ClearCollection <br> XamlDirect.ClearProperty <br> XamlDirect.CreateInstance <br> XamlDirect.GetBooleanProperty <br> XamlDirect.GetCollectionCount <br> XamlDirect.GetColorProperty <br> XamlDirect.GetCornerRadiusProperty <br> XamlDirect.GetDateTimeProperty <br> XamlDirect.GetDefault <br> XamlDirect.GetDoubleProperty <br> XamlDirect.GetDurationProperty <br> XamlDirect.GetEnumProperty <br> XamlDirect.GetGridLengthProperty <br> XamlDirect.GetInt32Property <br> XamlDirect.GetMatrix3DProperty <br> XamlDirect.GetMatrixProperty <br> XamlDirect.GetObject <br> XamlDirect.GetObjectProperty <br> XamlDirect.GetPointProperty <br> XamlDirect.GetRectProperty <br> XamlDirect.GetSizeProperty <br> XamlDirect.GetStringProperty <br> XamlDirect.GetThicknessProperty <br> XamlDirect.GetTimeSpanProperty <br> XamlDirect.GetXamlDirectObject <br> XamlDirect.GetXamlDirectObjectFromCollectionAt <br> XamlDirect.GetXamlDirectObjectProperty <br> XamlDirect.InsertIntoCollectionAt <br> XamlDirect.RemoveEventHandler <br> XamlDirect.RemoveFromCollection <br> XamlDirect.RemoveFromCollectionAt <br> XamlDirect.SetBooleanProperty <br> XamlDirect.SetColorProperty <br> XamlDirect.SetCornerRadiusProperty <br> XamlDirect.SetDateTimeProperty <br> XamlDirect.SetDoubleProperty <br> XamlDirect.SetDurationProperty <br> XamlDirect.SetEnumProperty <br> XamlDirect.SetGridLengthProperty <br> XamlDirect.SetInt32Property <br> XamlDirect.SetMatrix3DProperty <br> XamlDirect.SetMatrixProperty <br> XamlDirect.SetObjectProperty <br> XamlDirect.SetPointProperty <br> XamlDirect.SetRectProperty <br> XamlDirect.SetSizeProperty <br> XamlDirect.SetStringProperty <br> XamlDirect.SetThicknessProperty <br> XamlDirect.SetTimeSpanProperty <br> XamlDirect.SetXamlDirectObjectProperty

#### [<a name="xamleventindex"></a>XamlEventIndex](https://docs.microsoft.com/uwp/api/windows.ui.xaml.core.direct.xamleventindex)

XamlEventIndex

#### [<a name="xamlpropertyindex"></a>XamlPropertyIndex](https://docs.microsoft.com/uwp/api/windows.ui.xaml.core.direct.xamlpropertyindex)

XamlPropertyIndex

#### [<a name="xamltypeindex"></a>XamlTypeIndex](https://docs.microsoft.com/uwp/api/windows.ui.xaml.core.direct.xamltypeindex)

XamlTypeIndex

### [<a name="windowsuixamlhosting"></a>Windows.UI.Xaml.Hosting](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting)

#### [<a name="desktopwindowxamlsource"></a>DesktopWindowXamlSource](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting.desktopwindowxamlsource)

DesktopWindowXamlSource <br> DesktopWindowXamlSource.Close <br> DesktopWindowXamlSource.Content <br> DesktopWindowXamlSource。 #ctor <br> DesktopWindowXamlSource.GotFocus <br> DesktopWindowXamlSource.HasFocus <br> DesktopWindowXamlSource.NavigateFocus <br> DesktopWindowXamlSource.TakeFocusRequested

#### [<a name="desktopwindowxamlsourcegotfocuseventargs"></a>DesktopWindowXamlSourceGotFocusEventArgs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting.desktopwindowxamlsourcegotfocuseventargs)

DesktopWindowXamlSourceGotFocusEventArgs <br> DesktopWindowXamlSourceGotFocusEventArgs.Request

#### [<a name="desktopwindowxamlsourcetakefocusrequestedeventargs"></a>DesktopWindowXamlSourceTakeFocusRequestedEventArgs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting.desktopwindowxamlsourcetakefocusrequestedeventargs)

DesktopWindowXamlSourceTakeFocusRequestedEventArgs <br> DesktopWindowXamlSourceTakeFocusRequestedEventArgs.Request

#### [<a name="windowsxamlmanager"></a>WindowsXamlManager](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting.windowsxamlmanager)

WindowsXamlManager <br> WindowsXamlManager.Close <br> WindowsXamlManager.InitializeForCurrentThread

#### [<a name="xamlsourcefocusnavigationreason"></a>XamlSourceFocusNavigationReason](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting.xamlsourcefocusnavigationreason)

XamlSourceFocusNavigationReason

#### [<a name="xamlsourcefocusnavigationrequest"></a>XamlSourceFocusNavigationRequest](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting.xamlsourcefocusnavigationrequest)

XamlSourceFocusNavigationRequest <br> XamlSourceFocusNavigationRequest.CorrelationId <br> XamlSourceFocusNavigationRequest.HintRect <br> XamlSourceFocusNavigationRequest.Reason <br> XamlSourceFocusNavigationRequest。 #ctor <br> XamlSourceFocusNavigationRequest。 #ctor <br> XamlSourceFocusNavigationRequest。 #ctor

#### [<a name="xamlsourcefocusnavigationresult"></a>XamlSourceFocusNavigationResult](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting.xamlsourcefocusnavigationresult)

XamlSourceFocusNavigationResult <br> XamlSourceFocusNavigationResult.WasFocusMoved <br> XamlSourceFocusNavigationResult。 #ctor

### [<a name="windowsuixamlinput"></a>Windows.UI.Xaml.Input](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input)

#### [<a name="canexecuterequestedeventargs"></a>CanExecuteRequestedEventArgs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.canexecuterequestedeventargs)

CanExecuteRequestedEventArgs <br> CanExecuteRequestedEventArgs.CanExecute <br> CanExecuteRequestedEventArgs.Parameter

#### [<a name="executerequestedeventargs"></a>ExecuteRequestedEventArgs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.executerequestedeventargs)

ExecuteRequestedEventArgs <br> ExecuteRequestedEventArgs.Parameter

#### [<a name="focusmanager"></a>FocusManager](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.focusmanager)

FocusManager.GettingFocus <br> FocusManager.GotFocus <br> FocusManager.LosingFocus <br> FocusManager.LostFocus

#### [<a name="focusmanagergotfocuseventargs"></a>FocusManagerGotFocusEventArgs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.focusmanagergotfocuseventargs)

FocusManagerGotFocusEventArgs <br> FocusManagerGotFocusEventArgs.CorrelationId <br> FocusManagerGotFocusEventArgs.NewFocusedElement

#### [<a name="focusmanagerlostfocuseventargs"></a>FocusManagerLostFocusEventArgs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.focusmanagerlostfocuseventargs)

FocusManagerLostFocusEventArgs <br> FocusManagerLostFocusEventArgs.CorrelationId <br> FocusManagerLostFocusEventArgs.OldFocusedElement

#### [<a name="gettingfocuseventargs"></a>GettingFocusEventArgs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.gettingfocuseventargs)

GettingFocusEventArgs.CorrelationId

#### [<a name="losingfocuseventargs"></a>LosingFocusEventArgs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.losingfocuseventargs)

LosingFocusEventArgs.CorrelationId

#### [<a name="standarduicommand"></a>StandardUICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.standarduicommand)

StandardUICommand <br> StandardUICommand.Kind <br> StandardUICommand.KindProperty <br> StandardUICommand。 #ctor <br> StandardUICommand。 #ctor

#### [<a name="standarduicommandkind"></a>StandardUICommandKind](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.standarduicommandkind)

StandardUICommandKind

#### [<a name="xamluicommand"></a>XamlUICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.xamluicommand)

XamlUICommand <br> XamlUICommand.AccessKey <br> XamlUICommand.AccessKeyProperty <br> XamlUICommand.CanExecute <br> XamlUICommand.CanExecuteChanged <br> XamlUICommand.CanExecuteRequested <br> XamlUICommand.Command <br> XamlUICommand.CommandProperty <br> XamlUICommand.Description <br> XamlUICommand.DescriptionProperty <br> XamlUICommand.Execute <br> XamlUICommand.ExecuteRequested <br> XamlUICommand.IconSource <br> XamlUICommand.IconSourceProperty <br> XamlUICommand.KeyboardAccelerators <br> XamlUICommand.KeyboardAcceleratorsProperty <br> XamlUICommand.Label <br> XamlUICommand.LabelProperty <br> XamlUICommand.NotifyCanExecuteChanged <br> XamlUICommand。 #ctor

### [<a name="windowsuixamlmarkup"></a>Windows.UI.Xaml.Markup](https://docs.microsoft.com/uwp/api/windows.ui.xaml.markup)

#### [<a name="fullxamlmetadataproviderattribute"></a>FullXamlMetadataProviderAttribute](https://docs.microsoft.com/uwp/api/windows.ui.xaml.markup.fullxamlmetadataproviderattribute)

FullXamlMetadataProviderAttribute <br> FullXamlMetadataProviderAttribute。 #ctor

#### [<a name="ixamlbindscopediagnostics"></a>IXamlBindScopeDiagnostics](https://docs.microsoft.com/uwp/api/windows.ui.xaml.markup.ixamlbindscopediagnostics)

IXamlBindScopeDiagnostics <br> IXamlBindScopeDiagnostics.Disable

#### [<a name="ixamltype2"></a>IXamlType2](https://docs.microsoft.com/uwp/api/windows.ui.xaml.markup.ixamltype2)

IXamlType2 <br> IXamlType2.BoxedType

### [<a name="windowsuixamlmediaanimation"></a>Windows.UI.Xaml.Media.Animation](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.animation)

#### [<a name="basicconnectedanimationconfiguration"></a>BasicConnectedAnimationConfiguration](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.animation.basicconnectedanimationconfiguration)

BasicConnectedAnimationConfiguration <br> BasicConnectedAnimationConfiguration。 #ctor

#### [<a name="connectedanimation"></a>ConnectedAnimation](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.animation.connectedanimation)

ConnectedAnimation.Configuration

#### [<a name="connectedanimationconfiguration"></a>ConnectedAnimationConfiguration](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.animation.connectedanimationconfiguration)

ConnectedAnimationConfiguration

#### [<a name="directconnectedanimationconfiguration"></a>DirectConnectedAnimationConfiguration](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.animation.directconnectedanimationconfiguration)

DirectConnectedAnimationConfiguration <br> DirectConnectedAnimationConfiguration。 #ctor

#### [<a name="gravityconnectedanimationconfiguration"></a>GravityConnectedAnimationConfiguration](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.animation.gravityconnectedanimationconfiguration)

GravityConnectedAnimationConfiguration <br> GravityConnectedAnimationConfiguration。 #ctor

#### [<a name="slidenavigationtransitioneffect"></a>SlideNavigationTransitionEffect](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.animation.slidenavigationtransitioneffect)

SlideNavigationTransitionEffect

#### [<a name="slidenavigationtransitioninfo"></a>SlideNavigationTransitionInfo](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.animation.slidenavigationtransitioninfo)

SlideNavigationTransitionInfo.Effect <br> SlideNavigationTransitionInfo.EffectProperty

### [<a name="windowsuixamlmedia"></a>Windows.UI.Xaml.Media](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media)

#### [<a name="brush"></a>Brush](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.brush)

Brush.PopulatePropertyInfo <br> Brush.PopulatePropertyInfoOverride

### [<a name="windowsuixamlnavigation"></a>Windows.UI.Xaml.Navigation](https://docs.microsoft.com/uwp/api/windows.ui.xaml.navigation)

#### [<a name="framenavigationoptions"></a>FrameNavigationOptions](https://docs.microsoft.com/uwp/api/windows.ui.xaml.navigation.framenavigationoptions)

FrameNavigationOptions <br> FrameNavigationOptions。 #ctor <br> FrameNavigationOptions.IsNavigationStackEnabled <br> FrameNavigationOptions.TransitionInfoOverride

### [<a name="windowsuixaml"></a>Windows.UI.Xaml](https://docs.microsoft.com/uwp/api/windows.ui.xaml)

#### [<a name="brushtransition"></a>BrushTransition](https://docs.microsoft.com/uwp/api/windows.ui.xaml.brushtransition)

BrushTransition <br> BrushTransition。 #ctor <br> BrushTransition.Duration

#### [<a name="colorpaletteresources"></a>ColorPaletteResources](https://docs.microsoft.com/uwp/api/windows.ui.xaml.colorpaletteresources)

ColorPaletteResources <br> ColorPaletteResources.Accent <br> ColorPaletteResources.AltHigh <br> ColorPaletteResources.AltLow <br> ColorPaletteResources.AltMedium <br> ColorPaletteResources.AltMediumHigh <br> ColorPaletteResources.AltMediumLow <br> ColorPaletteResources.BaseHigh <br> ColorPaletteResources.BaseLow <br> ColorPaletteResources.BaseMedium <br> ColorPaletteResources.BaseMediumHigh <br> ColorPaletteResources.BaseMediumLow <br> ColorPaletteResources.ChromeAltLow <br> ColorPaletteResources.ChromeBlackHigh <br> ColorPaletteResources.ChromeBlackLow <br> ColorPaletteResources.ChromeBlackMedium <br> ColorPaletteResources.ChromeBlackMediumLow <br> ColorPaletteResources.ChromeDisabledHigh <br> ColorPaletteResources.ChromeDisabledLow <br> ColorPaletteResources.ChromeGray <br> ColorPaletteResources.ChromeHigh <br> ColorPaletteResources.ChromeLow <br> ColorPaletteResources.ChromeMedium <br> ColorPaletteResources.ChromeMediumLow <br> ColorPaletteResources.ChromeWhite <br> ColorPaletteResources。 #ctor <br> ColorPaletteResources.ErrorText <br> ColorPaletteResources.ListLow <br> ColorPaletteResources.ListMedium

#### [<a name="datatemplate"></a>DataTemplate](https://docs.microsoft.com/uwp/api/windows.ui.xaml.datatemplate)

DataTemplate.GetElement <br> DataTemplate.RecycleElement

#### [<a name="debugsettings"></a>DebugSettings](https://docs.microsoft.com/uwp/api/windows.ui.xaml.debugsettings)

DebugSettings.FailFastOnErrors

#### [<a name="effectiveviewportchangedeventargs"></a>EffectiveViewportChangedEventArgs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.effectiveviewportchangedeventargs)

EffectiveViewportChangedEventArgs <br> EffectiveViewportChangedEventArgs.BringIntoViewDistanceX <br> EffectiveViewportChangedEventArgs.BringIntoViewDistanceY <br> EffectiveViewportChangedEventArgs.EffectiveViewport <br> EffectiveViewportChangedEventArgs.MaxViewport

#### [<a name="elementfactorygetargs"></a>ElementFactoryGetArgs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.elementfactorygetargs)

ElementFactoryGetArgs <br> ElementFactoryGetArgs.Data <br> ElementFactoryGetArgs。 #ctor <br> ElementFactoryGetArgs.Parent

#### [<a name="elementfactoryrecycleargs"></a>ElementFactoryRecycleArgs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.elementfactoryrecycleargs)

ElementFactoryRecycleArgs <br> ElementFactoryRecycleArgs.Element <br> ElementFactoryRecycleArgs。 #ctor <br> ElementFactoryRecycleArgs.Parent

#### [<a name="frameworkelement"></a>FrameworkElement](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement)

FrameworkElement.EffectiveViewportChanged <br> FrameworkElement.InvalidateViewport <br> FrameworkElement.IsLoaded

#### [<a name="ielementfactory"></a>IElementFactory](https://docs.microsoft.com/uwp/api/windows.ui.xaml.ielementfactory)

IElementFactory <br> IElementFactory.GetElement <br> IElementFactory.RecycleElement

#### [<a name="scalartransition"></a>ScalarTransition](https://docs.microsoft.com/uwp/api/windows.ui.xaml.scalartransition)

ScalarTransition <br> ScalarTransition.Duration <br> ScalarTransition。 #ctor

#### [<a name="uielement"></a>UIElement](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement)

UIElement.CanBeScrollAnchor <br> UIElement.CanBeScrollAnchorProperty <br> UIElement.CenterPoint <br> UIElement.OpacityTransition <br> UIElement.PopulatePropertyInfo <br> UIElement.PopulatePropertyInfoOverride <br> UIElement.Rotation <br> UIElement.RotationAxis <br> UIElement.RotationTransition <br> UIElement.Scale <br> UIElement.ScaleTransition <br> UIElement.StartAnimation <br> UIElement.StopAnimation <br> UIElement.TransformMatrix <br> UIElement.Translation <br> UIElement.TranslationTransition

#### [<a name="vector3transition"></a>Vector3Transition](https://docs.microsoft.com/uwp/api/windows.ui.xaml.vector3transition)

Vector3Transition <br> Vector3Transition.Components <br> Vector3Transition.Duration <br> Vector3Transition #ctor。

#### [<a name="vector3transitioncomponents"></a>Vector3TransitionComponents](https://docs.microsoft.com/uwp/api/windows.ui.xaml.vector3transitioncomponents)

Vector3TransitionComponents

## <a name="windowsweb"></a>Windows.Web

### [<a name="windowswebuiinterop"></a>Windows.Web.UI.Interop](https://docs.microsoft.com/uwp/api/windows.web.ui.interop)

#### [<a name="webviewcontrol"></a>WebViewControl](https://docs.microsoft.com/uwp/api/windows.web.ui.interop.webviewcontrol)

WebViewControl.AddInitializeScript <br> WebViewControl.GotFocus <br> WebViewControl.LostFocus

### [<a name="windowswebui"></a>Windows.Web.UI](https://docs.microsoft.com/uwp/api/windows.web.ui)

#### [<a name="iwebviewcontrol2"></a>IWebViewControl2](https://docs.microsoft.com/uwp/api/windows.web.ui.iwebviewcontrol2)

IWebViewControl2 <br> IWebViewControl2.AddInitializeScript