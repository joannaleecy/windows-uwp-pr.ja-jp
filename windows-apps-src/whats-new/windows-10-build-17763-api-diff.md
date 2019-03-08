---
title: Windows 10 ビルド 17763 API の変更点
description: 開発者は Windows 10 ビルド 17763 で新しいまたは変更された名前空間を識別するために、次の一覧を使用することができます。
keywords: 新機能については、何が起こって新しい、更新、Windows 10 の最新、api、17763、年 10 月
ms.date: 10/02/2018
ms.topic: article
ms.localizationpriority: medium
ms.custom: RS5
ms.openlocfilehash: 8fd6d2c41cd2f632f22819f452b2f203fd8ac309
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57596327"
---
# <a name="new-apis-in-windows-10-build-17763"></a>Windows 10 の新しい Api 17763 をビルドします。

新規および更新された API の名前空間に加えられた使用可能な開発者が Windows 10 ビルド 17763 (年 2018年 10 月とも呼ばれる更新プログラムまたはバージョンは 1809)。 このリリースで追加または変更された名前空間について公開されているドキュメントの完全な一覧を以下に示します。

Api については、以前のパブリック リリースで追加、参照してください[Windows 10 年 4 月の更新プログラムの新しい Api](windows-10-build-17134-api-diff.md)します。

## <a name="windowsai"></a>Windows.AI

### <a name="windowsaimachinelearninghttpsdocsmicrosoftcomuwpapiwindowsaimachinelearning"></a>[Windows.AI.MachineLearning](https://docs.microsoft.com/uwp/api/windows.ai.machinelearning)

#### <a name="ilearningmodelfeaturedescriptorhttpsdocsmicrosoftcomuwpapiwindowsaimachinelearningilearningmodelfeaturedescriptor"></a>[ILearningModelFeatureDescriptor](https://docs.microsoft.com/uwp/api/windows.ai.machinelearning.ilearningmodelfeaturedescriptor)

ILearningModelFeatureDescriptor <br> ILearningModelFeatureDescriptor.Description <br> ILearningModelFeatureDescriptor.IsRequired <br> ILearningModelFeatureDescriptor.Kind <br> ILearningModelFeatureDescriptor.Name

#### <a name="ilearningmodelfeaturevaluehttpsdocsmicrosoftcomuwpapiwindowsaimachinelearningilearningmodelfeaturevalue"></a>[ILearningModelFeatureValue](https://docs.microsoft.com/uwp/api/windows.ai.machinelearning.ilearningmodelfeaturevalue)

ILearningModelFeatureValue <br> ILearningModelFeatureValue.Kind

#### <a name="ilearningmodeloperatorproviderhttpsdocsmicrosoftcomuwpapiwindowsaimachinelearningilearningmodeloperatorprovider"></a>[ILearningModelOperatorProvider](https://docs.microsoft.com/uwp/api/windows.ai.machinelearning.ilearningmodeloperatorprovider)

ILearningModelOperatorProvider

#### <a name="imagefeaturedescriptorhttpsdocsmicrosoftcomuwpapiwindowsaimachinelearningimagefeaturedescriptor"></a>[ImageFeatureDescriptor](https://docs.microsoft.com/uwp/api/windows.ai.machinelearning.imagefeaturedescriptor)

ImageFeatureDescriptor <br> ImageFeatureDescriptor.BitmapAlphaMode <br> ImageFeatureDescriptor.BitmapPixelFormat <br> ImageFeatureDescriptor.Description <br> ImageFeatureDescriptor.Height <br> ImageFeatureDescriptor.IsRequired <br> ImageFeatureDescriptor.Kind <br> ImageFeatureDescriptor.Name <br> ImageFeatureDescriptor.Width

#### <a name="imagefeaturevaluehttpsdocsmicrosoftcomuwpapiwindowsaimachinelearningimagefeaturevalue"></a>[ImageFeatureValue](https://docs.microsoft.com/uwp/api/windows.ai.machinelearning.imagefeaturevalue)

ImageFeatureValue <br> ImageFeatureValue.CreateFromVideoFrame <br> ImageFeatureValue.Kind <br> ImageFeatureValue.VideoFrame

#### <a name="itensorhttpsdocsmicrosoftcomuwpapiwindowsaimachinelearningitensor"></a>[ITensor](https://docs.microsoft.com/uwp/api/windows.ai.machinelearning.itensor)

ITensor <br> ITensor.Shape <br> ITensor.TensorKind

#### <a name="learningmodelhttpsdocsmicrosoftcomuwpapiwindowsaimachinelearninglearningmodel"></a>[LearningModel](https://docs.microsoft.com/uwp/api/windows.ai.machinelearning.learningmodel)

LearningModel <br> LearningModel.Author <br> LearningModel.Close <br> LearningModel.Description <br> LearningModel.Domain <br> LearningModel.InputFeatures <br> LearningModel.LoadFromFilePath <br> LearningModel.LoadFromFilePath <br> LearningModel.LoadFromStorageFileAsync <br> LearningModel.LoadFromStorageFileAsync <br> LearningModel.LoadFromStream <br> LearningModel.LoadFromStream <br> LearningModel.LoadFromStreamAsync <br> LearningModel.LoadFromStreamAsync <br> LearningModel.Metadata <br> LearningModel.Name <br> LearningModel.OutputFeatures <br> LearningModel.Version

#### <a name="learningmodelbindinghttpsdocsmicrosoftcomuwpapiwindowsaimachinelearninglearningmodelbinding"></a>[LearningModelBinding](https://docs.microsoft.com/uwp/api/windows.ai.machinelearning.learningmodelbinding)

LearningModelBinding <br> LearningModelBinding.Bind <br> LearningModelBinding.Bind <br> LearningModelBinding.Clear <br> LearningModelBinding.First <br> LearningModelBinding.HasKey <br> LearningModelBinding。 #ctor <br> LearningModelBinding.Lookup <br> LearningModelBinding.Size <br> LearningModelBinding.Split

#### <a name="learningmodeldevicehttpsdocsmicrosoftcomuwpapiwindowsaimachinelearninglearningmodeldevice"></a>[LearningModelDevice](https://docs.microsoft.com/uwp/api/windows.ai.machinelearning.learningmodeldevice)

LearningModelDevice <br> LearningModelDevice.AdapterId <br> LearningModelDevice.CreateFromDirect3D11Device <br> LearningModelDevice.Direct3D11Device <br> LearningModelDevice。 #ctor

#### <a name="learningmodeldevicekindhttpsdocsmicrosoftcomuwpapiwindowsaimachinelearninglearningmodeldevicekind"></a>[LearningModelDeviceKind](https://docs.microsoft.com/uwp/api/windows.ai.machinelearning.learningmodeldevicekind)

LearningModelDeviceKind

#### <a name="learningmodelevaluationresulthttpsdocsmicrosoftcomuwpapiwindowsaimachinelearninglearningmodelevaluationresult"></a>[LearningModelEvaluationResult](https://docs.microsoft.com/uwp/api/windows.ai.machinelearning.learningmodelevaluationresult)

LearningModelEvaluationResult <br> LearningModelEvaluationResult.CorrelationId <br> LearningModelEvaluationResult.ErrorStatus <br> LearningModelEvaluationResult.Outputs <br> LearningModelEvaluationResult.Succeeded

#### <a name="learningmodelfeaturekindhttpsdocsmicrosoftcomuwpapiwindowsaimachinelearninglearningmodelfeaturekind"></a>[LearningModelFeatureKind](https://docs.microsoft.com/uwp/api/windows.ai.machinelearning.learningmodelfeaturekind)

LearningModelFeatureKind

#### <a name="learningmodelsessionhttpsdocsmicrosoftcomuwpapiwindowsaimachinelearninglearningmodelsession"></a>[LearningModelSession](https://docs.microsoft.com/uwp/api/windows.ai.machinelearning.learningmodelsession)

LearningModelSession <br> LearningModelSession.Close <br> LearningModelSession.Device <br> LearningModelSession.Evaluate <br> LearningModelSession.EvaluateAsync <br> LearningModelSession.EvaluateFeatures <br> LearningModelSession.EvaluateFeaturesAsync <br> LearningModelSession.EvaluationProperties <br> LearningModelSession。 #ctor <br> LearningModelSession。 #ctor <br> LearningModelSession.Model

#### <a name="mapfeaturedescriptorhttpsdocsmicrosoftcomuwpapiwindowsaimachinelearningmapfeaturedescriptor"></a>[MapFeatureDescriptor](https://docs.microsoft.com/uwp/api/windows.ai.machinelearning.mapfeaturedescriptor)

MapFeatureDescriptor <br> MapFeatureDescriptor.Description <br> MapFeatureDescriptor.IsRequired <br> MapFeatureDescriptor.KeyKind <br> MapFeatureDescriptor.Kind <br> MapFeatureDescriptor.Name <br> MapFeatureDescriptor.ValueDescriptor

#### <a name="sequencefeaturedescriptorhttpsdocsmicrosoftcomuwpapiwindowsaimachinelearningsequencefeaturedescriptor"></a>[SequenceFeatureDescriptor](https://docs.microsoft.com/uwp/api/windows.ai.machinelearning.sequencefeaturedescriptor)

SequenceFeatureDescriptor <br> SequenceFeatureDescriptor.Description <br> SequenceFeatureDescriptor.ElementDescriptor <br> SequenceFeatureDescriptor.IsRequired <br> SequenceFeatureDescriptor.Kind <br> SequenceFeatureDescriptor.Name

#### <a name="tensorbooleanhttpsdocsmicrosoftcomuwpapiwindowsaimachinelearningtensorboolean"></a>[TensorBoolean](https://docs.microsoft.com/uwp/api/windows.ai.machinelearning.tensorboolean)

TensorBoolean <br> TensorBoolean.Create <br> TensorBoolean.Create <br> TensorBoolean.CreateFromArray <br> TensorBoolean.CreateFromIterable <br> TensorBoolean.GetAsVectorView <br> TensorBoolean.Kind <br> TensorBoolean.Shape <br> TensorBoolean.TensorKind

#### <a name="tensordoublehttpsdocsmicrosoftcomuwpapiwindowsaimachinelearningtensordouble"></a>[TensorDouble](https://docs.microsoft.com/uwp/api/windows.ai.machinelearning.tensordouble)

TensorDouble <br> TensorDouble.Create <br> TensorDouble.Create <br> TensorDouble.CreateFromArray <br> TensorDouble.CreateFromIterable <br> TensorDouble.GetAsVectorView <br> TensorDouble.Kind <br> TensorDouble.Shape <br> TensorDouble.TensorKind

#### <a name="tensorfeaturedescriptorhttpsdocsmicrosoftcomuwpapiwindowsaimachinelearningtensorfeaturedescriptor"></a>[TensorFeatureDescriptor](https://docs.microsoft.com/uwp/api/windows.ai.machinelearning.tensorfeaturedescriptor)

TensorFeatureDescriptor <br> TensorFeatureDescriptor.Description <br> TensorFeatureDescriptor.IsRequired <br> TensorFeatureDescriptor.Kind <br> TensorFeatureDescriptor.Name <br> TensorFeatureDescriptor.Shape <br> TensorFeatureDescriptor.TensorKind

#### <a name="tensorfloathttpsdocsmicrosoftcomuwpapiwindowsaimachinelearningtensorfloat"></a>[TensorFloat](https://docs.microsoft.com/uwp/api/windows.ai.machinelearning.tensorfloat)

TensorFloat <br> TensorFloat.Create <br> TensorFloat.Create <br> TensorFloat.CreateFromArray <br> TensorFloat.CreateFromIterable <br> TensorFloat.GetAsVectorView <br> TensorFloat.Kind <br> TensorFloat.Shape <br> TensorFloat.TensorKind

#### <a name="tensorfloat16bithttpsdocsmicrosoftcomuwpapiwindowsaimachinelearningtensorfloat16bit"></a>[TensorFloat16Bit](https://docs.microsoft.com/uwp/api/windows.ai.machinelearning.tensorfloat16bit)

TensorFloat16Bit <br> TensorFloat16Bit.Create <br> TensorFloat16Bit.Create <br> TensorFloat16Bit.CreateFromArray <br> TensorFloat16Bit.CreateFromIterable <br> TensorFloat16Bit.GetAsVectorView <br> TensorFloat16Bit.Kind <br> TensorFloat16Bit.Shape <br> TensorFloat16Bit.TensorKind

#### <a name="tensorint16bithttpsdocsmicrosoftcomuwpapiwindowsaimachinelearningtensorint16bit"></a>[TensorInt16Bit](https://docs.microsoft.com/uwp/api/windows.ai.machinelearning.tensorint16bit)

TensorInt16Bit <br> TensorInt16Bit.Create <br> TensorInt16Bit.Create <br> TensorInt16Bit.CreateFromArray <br> TensorInt16Bit.CreateFromIterable <br> TensorInt16Bit.GetAsVectorView <br> TensorInt16Bit.Kind <br> TensorInt16Bit.Shape <br> TensorInt16Bit.TensorKind

#### <a name="tensorint32bithttpsdocsmicrosoftcomuwpapiwindowsaimachinelearningtensorint32bit"></a>[TensorInt32Bit](https://docs.microsoft.com/uwp/api/windows.ai.machinelearning.tensorint32bit)

TensorInt32Bit <br> TensorInt32Bit.Create <br> TensorInt32Bit.Create <br> TensorInt32Bit.CreateFromArray <br> TensorInt32Bit.CreateFromIterable <br> TensorInt32Bit.GetAsVectorView <br> TensorInt32Bit.Kind <br> TensorInt32Bit.Shape <br> TensorInt32Bit.TensorKind

#### <a name="tensorint64bithttpsdocsmicrosoftcomuwpapiwindowsaimachinelearningtensorint64bit"></a>[TensorInt64Bit](https://docs.microsoft.com/uwp/api/windows.ai.machinelearning.tensorint64bit)

TensorInt64Bit <br> TensorInt64Bit.Create <br> TensorInt64Bit.Create <br> TensorInt64Bit.CreateFromArray <br> TensorInt64Bit.CreateFromIterable <br> TensorInt64Bit.GetAsVectorView <br> TensorInt64Bit.Kind <br> TensorInt64Bit.Shape <br> TensorInt64Bit.TensorKind

#### <a name="tensorint8bithttpsdocsmicrosoftcomuwpapiwindowsaimachinelearningtensorint8bit"></a>[TensorInt8Bit](https://docs.microsoft.com/uwp/api/windows.ai.machinelearning.tensorint8bit)

TensorInt8Bit <br> TensorInt8Bit.Create <br> TensorInt8Bit.Create <br> TensorInt8Bit.CreateFromArray <br> TensorInt8Bit.CreateFromIterable <br> TensorInt8Bit.GetAsVectorView <br> TensorInt8Bit.Kind <br> TensorInt8Bit.Shape <br> TensorInt8Bit.TensorKind

#### <a name="tensorkindhttpsdocsmicrosoftcomuwpapiwindowsaimachinelearningtensorkind"></a>[TensorKind](https://docs.microsoft.com/uwp/api/windows.ai.machinelearning.tensorkind)

TensorKind

#### <a name="tensorstringhttpsdocsmicrosoftcomuwpapiwindowsaimachinelearningtensorstring"></a>[TensorString](https://docs.microsoft.com/uwp/api/windows.ai.machinelearning.tensorstring)

TensorString <br> TensorString.Create <br> TensorString.Create <br> TensorString.CreateFromArray <br> TensorString.CreateFromIterable <br> TensorString.GetAsVectorView <br> TensorString.Kind <br> TensorString.Shape <br> TensorString.TensorKind

#### <a name="tensoruint16bithttpsdocsmicrosoftcomuwpapiwindowsaimachinelearningtensoruint16bit"></a>[TensorUInt16Bit](https://docs.microsoft.com/uwp/api/windows.ai.machinelearning.tensoruint16bit)

TensorUInt16Bit <br> TensorUInt16Bit.Create <br> TensorUInt16Bit.Create <br> TensorUInt16Bit.CreateFromArray <br> TensorUInt16Bit.CreateFromIterable <br> TensorUInt16Bit.GetAsVectorView <br> TensorUInt16Bit.Kind <br> TensorUInt16Bit.Shape <br> TensorUInt16Bit.TensorKind

#### <a name="tensoruint32bithttpsdocsmicrosoftcomuwpapiwindowsaimachinelearningtensoruint32bit"></a>[TensorUInt32Bit](https://docs.microsoft.com/uwp/api/windows.ai.machinelearning.tensoruint32bit)

TensorUInt32Bit <br> TensorUInt32Bit.Create <br> TensorUInt32Bit.Create <br> TensorUInt32Bit.CreateFromArray <br> TensorUInt32Bit.CreateFromIterable <br> TensorUInt32Bit.GetAsVectorView <br> TensorUInt32Bit.Kind <br> TensorUInt32Bit.Shape <br> TensorUInt32Bit.TensorKind

#### <a name="tensoruint64bithttpsdocsmicrosoftcomuwpapiwindowsaimachinelearningtensoruint64bit"></a>[TensorUInt64Bit](https://docs.microsoft.com/uwp/api/windows.ai.machinelearning.tensoruint64bit)

TensorUInt64Bit <br> TensorUInt64Bit.Create <br> TensorUInt64Bit.Create <br> TensorUInt64Bit.CreateFromArray <br> TensorUInt64Bit.CreateFromIterable <br> TensorUInt64Bit.GetAsVectorView <br> TensorUInt64Bit.Kind <br> TensorUInt64Bit.Shape <br> TensorUInt64Bit.TensorKind

#### <a name="tensoruint8bithttpsdocsmicrosoftcomuwpapiwindowsaimachinelearningtensoruint8bit"></a>[TensorUInt8Bit](https://docs.microsoft.com/uwp/api/windows.ai.machinelearning.tensoruint8bit)

TensorUInt8Bit <br> TensorUInt8Bit.Create <br> TensorUInt8Bit.Create <br> TensorUInt8Bit.CreateFromArray <br> TensorUInt8Bit.CreateFromIterable <br> TensorUInt8Bit.GetAsVectorView <br> TensorUInt8Bit.Kind <br> TensorUInt8Bit.Shape <br> TensorUInt8Bit.TensorKind

## <a name="windowsapplicationmodel"></a>Windows.ApplicationModel

### <a name="windowsapplicationmodelcallshttpsdocsmicrosoftcomuwpapiwindowsapplicationmodelcalls"></a>[Windows.ApplicationModel.Calls](https://docs.microsoft.com/uwp/api/windows.applicationmodel.calls)

#### <a name="voipcallcoordinatorhttpsdocsmicrosoftcomuwpapiwindowsapplicationmodelcallsvoipcallcoordinator"></a>[VoipCallCoordinator](https://docs.microsoft.com/uwp/api/windows.applicationmodel.calls.voipcallcoordinator)

VoipCallCoordinator.ReserveCallResourcesAsync

### <a name="windowsapplicationmodelchathttpsdocsmicrosoftcomuwpapiwindowsapplicationmodelchat"></a>[Windows.ApplicationModel.Chat](https://docs.microsoft.com/uwp/api/windows.applicationmodel.chat)

#### <a name="chatcapabilitiesmanagerhttpsdocsmicrosoftcomuwpapiwindowsapplicationmodelchatchatcapabilitiesmanager"></a>[ChatCapabilitiesManager](https://docs.microsoft.com/uwp/api/windows.applicationmodel.chat.chatcapabilitiesmanager)

ChatCapabilitiesManager.GetCachedCapabilitiesAsync <br> ChatCapabilitiesManager.GetCapabilitiesFromNetworkAsync

#### <a name="rcsmanagerhttpsdocsmicrosoftcomuwpapiwindowsapplicationmodelchatrcsmanager"></a>[RcsManager](https://docs.microsoft.com/uwp/api/windows.applicationmodel.chat.rcsmanager)

RcsManager.TransportListChanged

### <a name="windowsapplicationmodeldatatransferhttpsdocsmicrosoftcomuwpapiwindowsapplicationmodeldatatransfer"></a>[Windows.ApplicationModel.DataTransfer](https://docs.microsoft.com/uwp/api/windows.applicationmodel.datatransfer)

#### <a name="clipboardhttpsdocsmicrosoftcomuwpapiwindowsapplicationmodeldatatransferclipboard"></a>[クリップボード](https://docs.microsoft.com/uwp/api/windows.applicationmodel.datatransfer.clipboard)

Clipboard.ClearHistory <br> Clipboard.DeleteItemFromHistory <br> Clipboard.GetHistoryItemsAsync <br> Clipboard.HistoryChanged <br> Clipboard.HistoryEnabledChanged <br> Clipboard.IsHistoryEnabled <br> Clipboard.IsRoamingEnabled <br> Clipboard.RoamingEnabledChanged <br> Clipboard.SetContentWithOptions <br> Clipboard.SetHistoryItemAsContent

#### <a name="clipboardcontentoptionshttpsdocsmicrosoftcomuwpapiwindowsapplicationmodeldatatransferclipboardcontentoptions"></a>[ClipboardContentOptions](https://docs.microsoft.com/uwp/api/windows.applicationmodel.datatransfer.clipboardcontentoptions)

ClipboardContentOptions <br> ClipboardContentOptions。 #ctor <br> ClipboardContentOptions.HistoryFormats <br> ClipboardContentOptions.IsAllowedInHistory <br> ClipboardContentOptions.IsRoamable <br> ClipboardContentOptions.RoamingFormats

#### <a name="clipboardhistorychangedeventargshttpsdocsmicrosoftcomuwpapiwindowsapplicationmodeldatatransferclipboardhistorychangedeventargs"></a>[ClipboardHistoryChangedEventArgs](https://docs.microsoft.com/uwp/api/windows.applicationmodel.datatransfer.clipboardhistorychangedeventargs)

ClipboardHistoryChangedEventArgs

#### <a name="clipboardhistoryitemhttpsdocsmicrosoftcomuwpapiwindowsapplicationmodeldatatransferclipboardhistoryitem"></a>[ClipboardHistoryItem](https://docs.microsoft.com/uwp/api/windows.applicationmodel.datatransfer.clipboardhistoryitem)

ClipboardHistoryItem <br> ClipboardHistoryItem.Content <br> ClipboardHistoryItem.Id <br> ClipboardHistoryItem.Timestamp

#### <a name="clipboardhistoryitemsresulthttpsdocsmicrosoftcomuwpapiwindowsapplicationmodeldatatransferclipboardhistoryitemsresult"></a>[ClipboardHistoryItemsResult](https://docs.microsoft.com/uwp/api/windows.applicationmodel.datatransfer.clipboardhistoryitemsresult)

ClipboardHistoryItemsResult <br> ClipboardHistoryItemsResult.Items <br> ClipboardHistoryItemsResult.Status

#### <a name="clipboardhistoryitemsresultstatushttpsdocsmicrosoftcomuwpapiwindowsapplicationmodeldatatransferclipboardhistoryitemsresultstatus"></a>[ClipboardHistoryItemsResultStatus](https://docs.microsoft.com/uwp/api/windows.applicationmodel.datatransfer.clipboardhistoryitemsresultstatus)

ClipboardHistoryItemsResultStatus

#### <a name="datapackagepropertysetviewhttpsdocsmicrosoftcomuwpapiwindowsapplicationmodeldatatransferdatapackagepropertysetview"></a>[DataPackagePropertySetView](https://docs.microsoft.com/uwp/api/windows.applicationmodel.datatransfer.datapackagepropertysetview)

DataPackagePropertySetView.IsFromRoamingClipboard

#### <a name="sethistoryitemascontentstatushttpsdocsmicrosoftcomuwpapiwindowsapplicationmodeldatatransfersethistoryitemascontentstatus"></a>[SetHistoryItemAsContentStatus](https://docs.microsoft.com/uwp/api/windows.applicationmodel.datatransfer.sethistoryitemascontentstatus)

SetHistoryItemAsContentStatus

### <a name="windowsapplicationmodelstorepreviewinstallcontrolhttpsdocsmicrosoftcomuwpapiwindowsapplicationmodelstorepreviewinstallcontrol"></a>[Windows.ApplicationModel.Store.Preview.InstallControl](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.preview.installcontrol)

#### <a name="appinstallationtoastnotificationmodehttpsdocsmicrosoftcomuwpapiwindowsapplicationmodelstorepreviewinstallcontrolappinstallationtoastnotificationmode"></a>[AppInstallationToastNotificationMode](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.preview.installcontrol.appinstallationtoastnotificationmode)

AppInstallationToastNotificationMode

#### <a name="appinstallitemhttpsdocsmicrosoftcomuwpapiwindowsapplicationmodelstorepreviewinstallcontrolappinstallitem"></a>[AppInstallItem](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.preview.installcontrol.appinstallitem)

AppInstallItem.CompletedInstallToastNotificationMode <br> AppInstallItem.InstallInProgressToastNotificationMode <br> AppInstallItem.PinToDesktopAfterInstall <br> AppInstallItem.PinToStartAfterInstall <br> AppInstallItem.PinToTaskbarAfterInstall

#### <a name="appinstallmanagerhttpsdocsmicrosoftcomuwpapiwindowsapplicationmodelstorepreviewinstallcontrolappinstallmanager"></a>[AppInstallManager](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.preview.installcontrol.appinstallmanager)

AppInstallManager.CanInstallForAllUsers

#### <a name="appinstalloptionshttpsdocsmicrosoftcomuwpapiwindowsapplicationmodelstorepreviewinstallcontrolappinstalloptions"></a>[AppInstallOptions](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.preview.installcontrol.appinstalloptions)

AppInstallOptions.CampaignId <br> AppInstallOptions.CompletedInstallToastNotificationMode <br> AppInstallOptions.ExtendedCampaignId <br> AppInstallOptions.InstallForAllUsers <br> AppInstallOptions.InstallInProgressToastNotificationMode <br> AppInstallOptions.PinToDesktopAfterInstall <br> AppInstallOptions.PinToStartAfterInstall <br> AppInstallOptions.PinToTaskbarAfterInstall <br> AppInstallOptions.StageButDoNotInstall

#### <a name="appupdateoptionshttpsdocsmicrosoftcomuwpapiwindowsapplicationmodelstorepreviewinstallcontrolappupdateoptions"></a>[AppUpdateOptions](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.preview.installcontrol.appupdateoptions)

AppUpdateOptions.AutomaticallyDownloadAndInstallUpdateIfFound

### <a name="windowsapplicationmodelstorepreviewhttpsdocsmicrosoftcomuwpapiwindowsapplicationmodelstorepreview"></a>[Windows.ApplicationModel.Store.Preview](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.preview)

#### <a name="deliveryoptimizationdownloadmodehttpsdocsmicrosoftcomuwpapiwindowsapplicationmodelstorepreviewdeliveryoptimizationdownloadmode"></a>[DeliveryOptimizationDownloadMode](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.preview.deliveryoptimizationdownloadmode)

DeliveryOptimizationDownloadMode

#### <a name="deliveryoptimizationdownloadmodesourcehttpsdocsmicrosoftcomuwpapiwindowsapplicationmodelstorepreviewdeliveryoptimizationdownloadmodesource"></a>[DeliveryOptimizationDownloadModeSource](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.preview.deliveryoptimizationdownloadmodesource)

DeliveryOptimizationDownloadModeSource

#### <a name="deliveryoptimizationsettingshttpsdocsmicrosoftcomuwpapiwindowsapplicationmodelstorepreviewdeliveryoptimizationsettings"></a>[DeliveryOptimizationSettings](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.preview.deliveryoptimizationsettings)

DeliveryOptimizationSettings <br> DeliveryOptimizationSettings.DownloadMode <br> DeliveryOptimizationSettings.DownloadModeSource <br> DeliveryOptimizationSettings.GetCurrentSettings

#### <a name="storeconfigurationhttpsdocsmicrosoftcomuwpapiwindowsapplicationmodelstorepreviewstoreconfiguration"></a>[StoreConfiguration](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.preview.storeconfiguration)

StoreConfiguration.IsPinToDesktopSupported <br> StoreConfiguration.IsPinToStartSupported <br> StoreConfiguration.IsPinToTaskbarSupported <br> StoreConfiguration.PinToDesktop <br> StoreConfiguration.PinToDesktopForUser

### <a name="windowsapplicationmodeluseractivitieshttpsdocsmicrosoftcomuwpapiwindowsapplicationmodeluseractivities"></a>[Windows.ApplicationModel.UserActivities](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities)

#### <a name="useractivityhttpsdocsmicrosoftcomuwpapiwindowsapplicationmodeluseractivitiesuseractivity"></a>[UserActivity](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.useractivity)

UserActivity.IsRoamable

### <a name="windowsapplicationmodelhttpsdocsmicrosoftcomuwpapiwindowsapplicationmodel"></a>[Windows.ApplicationModel](https://docs.microsoft.com/uwp/api/windows.applicationmodel)

#### <a name="appinstallerinfohttpsdocsmicrosoftcomuwpapiwindowsapplicationmodelappinstallerinfo"></a>[AppInstallerInfo](https://docs.microsoft.com/uwp/api/windows.applicationmodel.appinstallerinfo)

AppInstallerInfo <br> AppInstallerInfo.Uri

#### <a name="limitedaccessfeaturerequestresulthttpsdocsmicrosoftcomuwpapiwindowsapplicationmodellimitedaccessfeaturerequestresult"></a>[LimitedAccessFeatureRequestResult](https://docs.microsoft.com/uwp/api/windows.applicationmodel.limitedaccessfeaturerequestresult)

LimitedAccessFeatureRequestResult <br> LimitedAccessFeatureRequestResult.EstimatedRemovalDate <br> LimitedAccessFeatureRequestResult.FeatureId <br> LimitedAccessFeatureRequestResult.Status

#### <a name="limitedaccessfeatureshttpsdocsmicrosoftcomuwpapiwindowsapplicationmodellimitedaccessfeatures"></a>[LimitedAccessFeatures](https://docs.microsoft.com/uwp/api/windows.applicationmodel.limitedaccessfeatures)

LimitedAccessFeatures <br> LimitedAccessFeatures.TryUnlockFeature

#### <a name="limitedaccessfeaturestatushttpsdocsmicrosoftcomuwpapiwindowsapplicationmodellimitedaccessfeaturestatus"></a>[LimitedAccessFeatureStatus](https://docs.microsoft.com/uwp/api/windows.applicationmodel.limitedaccessfeaturestatus)

LimitedAccessFeatureStatus

#### <a name="packagehttpsdocsmicrosoftcomuwpapiwindowsapplicationmodelpackage"></a>[パッケージ](https://docs.microsoft.com/uwp/api/windows.applicationmodel.package)

Package.CheckUpdateAvailabilityAsync <br> Package.GetAppInstallerInfo

#### <a name="packageupdateavailabilityhttpsdocsmicrosoftcomuwpapiwindowsapplicationmodelpackageupdateavailability"></a>[PackageUpdateAvailability](https://docs.microsoft.com/uwp/api/windows.applicationmodel.packageupdateavailability)

PackageUpdateAvailability

#### <a name="packageupdateavailabilityresulthttpsdocsmicrosoftcomuwpapiwindowsapplicationmodelpackageupdateavailabilityresult"></a>[PackageUpdateAvailabilityResult](https://docs.microsoft.com/uwp/api/windows.applicationmodel.packageupdateavailabilityresult)

PackageUpdateAvailabilityResult <br> PackageUpdateAvailabilityResult.Availability <br> PackageUpdateAvailabilityResult.ExtendedError

## <a name="windowsdata"></a>Windows.Data

### <a name="windowsdatatexthttpsdocsmicrosoftcomuwpapiwindowsdatatext"></a>[Windows.Data.Text](https://docs.microsoft.com/uwp/api/windows.data.text)

#### <a name="textpredictiongeneratorhttpsdocsmicrosoftcomuwpapiwindowsdatatexttextpredictiongenerator"></a>[TextPredictionGenerator](https://docs.microsoft.com/uwp/api/windows.data.text.textpredictiongenerator)

TextPredictionGenerator.GetCandidatesAsync <br> TextPredictionGenerator.GetNextWordCandidatesAsync <br> TextPredictionGenerator.InputScope

#### <a name="textpredictionoptionshttpsdocsmicrosoftcomuwpapiwindowsdatatexttextpredictionoptions"></a>[TextPredictionOptions](https://docs.microsoft.com/uwp/api/windows.data.text.textpredictionoptions)

TextPredictionOptions

## <a name="windowsdevices"></a>含まれる windows devices

### <a name="windowsdevicesdisplaycorehttpsdocsmicrosoftcomuwpapiwindowsdevicesdisplaycore"></a>[Windows.Devices.Display.Core](https://docs.microsoft.com/uwp/api/windows.devices.display.core)

#### <a name="displayadapterhttpsdocsmicrosoftcomuwpapiwindowsdevicesdisplaycoredisplayadapter"></a>[DisplayAdapter](https://docs.microsoft.com/uwp/api/windows.devices.display.core.displayadapter)

DisplayAdapter <br> DisplayAdapter.DeviceInterfacePath <br> DisplayAdapter.FromId <br> DisplayAdapter.Id <br> DisplayAdapter.PciDeviceId <br> DisplayAdapter.PciRevision <br> DisplayAdapter.PciSubSystemId <br> DisplayAdapter.PciVendorId <br> DisplayAdapter.Properties <br> DisplayAdapter.SourceCount

#### <a name="displaybitsperchannelhttpsdocsmicrosoftcomuwpapiwindowsdevicesdisplaycoredisplaybitsperchannel"></a>[DisplayBitsPerChannel](https://docs.microsoft.com/uwp/api/windows.devices.display.core.displaybitsperchannel)

DisplayBitsPerChannel

#### <a name="displaydevicehttpsdocsmicrosoftcomuwpapiwindowsdevicesdisplaycoredisplaydevice"></a>[DisplayDevice](https://docs.microsoft.com/uwp/api/windows.devices.display.core.displaydevice)

DisplayDevice <br> DisplayDevice.CreatePeriodicFence <br> DisplayDevice.CreatePrimary <br> DisplayDevice.CreateScanoutSource <br> DisplayDevice.CreateSimpleScanout <br> DisplayDevice.CreateTaskPool <br> DisplayDevice.IsCapabilitySupported <br> DisplayDevice.WaitForVBlank

#### <a name="displaydevicecapabilityhttpsdocsmicrosoftcomuwpapiwindowsdevicesdisplaycoredisplaydevicecapability"></a>[DisplayDeviceCapability](https://docs.microsoft.com/uwp/api/windows.devices.display.core.displaydevicecapability)

DisplayDeviceCapability

#### <a name="displayfencehttpsdocsmicrosoftcomuwpapiwindowsdevicesdisplaycoredisplayfence"></a>[DisplayFence](https://docs.microsoft.com/uwp/api/windows.devices.display.core.displayfence)

DisplayFence

#### <a name="displaymanagerhttpsdocsmicrosoftcomuwpapiwindowsdevicesdisplaycoredisplaymanager"></a>[しましょう](https://docs.microsoft.com/uwp/api/windows.devices.display.core.displaymanager)

しましょう <br> DisplayManager.Changed <br> DisplayManager.Close <br> DisplayManager.Create <br> DisplayManager.CreateDisplayDevice <br> DisplayManager.Disabled <br> DisplayManager.Enabled <br> DisplayManager.GetCurrentAdapters <br> DisplayManager.GetCurrentTargets <br> DisplayManager.PathsFailedOrInvalidated <br> DisplayManager.ReleaseTarget <br> DisplayManager.Start <br> DisplayManager.Stop <br> DisplayManager.TryAcquireTarget <br> DisplayManager.TryAcquireTargetsAndCreateEmptyState <br> DisplayManager.TryAcquireTargetsAndCreateSubstate <br> DisplayManager.TryAcquireTargetsAndReadCurrentState <br> DisplayManager.TryReadCurrentStateForAllTargets

#### <a name="displaymanagerchangedeventargshttpsdocsmicrosoftcomuwpapiwindowsdevicesdisplaycoredisplaymanagerchangedeventargs"></a>[DisplayManagerChangedEventArgs](https://docs.microsoft.com/uwp/api/windows.devices.display.core.displaymanagerchangedeventargs)

DisplayManagerChangedEventArgs <br> DisplayManagerChangedEventArgs.GetDeferral <br> DisplayManagerChangedEventArgs.Handled

#### <a name="displaymanagerdisabledeventargshttpsdocsmicrosoftcomuwpapiwindowsdevicesdisplaycoredisplaymanagerdisabledeventargs"></a>[DisplayManagerDisabledEventArgs](https://docs.microsoft.com/uwp/api/windows.devices.display.core.displaymanagerdisabledeventargs)

DisplayManagerDisabledEventArgs <br> DisplayManagerDisabledEventArgs.GetDeferral <br> DisplayManagerDisabledEventArgs.Handled

#### <a name="displaymanagerenabledeventargshttpsdocsmicrosoftcomuwpapiwindowsdevicesdisplaycoredisplaymanagerenabledeventargs"></a>[DisplayManagerEnabledEventArgs](https://docs.microsoft.com/uwp/api/windows.devices.display.core.displaymanagerenabledeventargs)

DisplayManagerEnabledEventArgs <br> DisplayManagerEnabledEventArgs.GetDeferral <br> DisplayManagerEnabledEventArgs.Handled

#### <a name="displaymanageroptionshttpsdocsmicrosoftcomuwpapiwindowsdevicesdisplaycoredisplaymanageroptions"></a>[DisplayManagerOptions](https://docs.microsoft.com/uwp/api/windows.devices.display.core.displaymanageroptions)

DisplayManagerOptions

#### <a name="displaymanagerpathsfailedorinvalidatedeventargshttpsdocsmicrosoftcomuwpapiwindowsdevicesdisplaycoredisplaymanagerpathsfailedorinvalidatedeventargs"></a>[DisplayManagerPathsFailedOrInvalidatedEventArgs](https://docs.microsoft.com/uwp/api/windows.devices.display.core.displaymanagerpathsfailedorinvalidatedeventargs)

DisplayManagerPathsFailedOrInvalidatedEventArgs <br> DisplayManagerPathsFailedOrInvalidatedEventArgs.GetDeferral <br> DisplayManagerPathsFailedOrInvalidatedEventArgs.Handled

#### <a name="displaymanagerresulthttpsdocsmicrosoftcomuwpapiwindowsdevicesdisplaycoredisplaymanagerresult"></a>[DisplayManagerResult](https://docs.microsoft.com/uwp/api/windows.devices.display.core.displaymanagerresult)

DisplayManagerResult

#### <a name="displaymanagerresultwithstatehttpsdocsmicrosoftcomuwpapiwindowsdevicesdisplaycoredisplaymanagerresultwithstate"></a>[DisplayManagerResultWithState](https://docs.microsoft.com/uwp/api/windows.devices.display.core.displaymanagerresultwithstate)

DisplayManagerResultWithState <br> DisplayManagerResultWithState.ErrorCode <br> DisplayManagerResultWithState.ExtendedErrorCode <br> DisplayManagerResultWithState.State

#### <a name="displaymodeinfohttpsdocsmicrosoftcomuwpapiwindowsdevicesdisplaycoredisplaymodeinfo"></a>[DisplayModeInfo](https://docs.microsoft.com/uwp/api/windows.devices.display.core.displaymodeinfo)

DisplayModeInfo <br> DisplayModeInfo.GetWireFormatSupportedBitsPerChannel <br> DisplayModeInfo.IsInterlaced <br> DisplayModeInfo.IsStereo <br> DisplayModeInfo.IsWireFormatSupported <br> DisplayModeInfo.PresentationRate <br> DisplayModeInfo.Properties <br> DisplayModeInfo.SourcePixelFormat <br> DisplayModeInfo.SourceResolution <br> DisplayModeInfo.TargetResolution

#### <a name="displaymodequeryoptionshttpsdocsmicrosoftcomuwpapiwindowsdevicesdisplaycoredisplaymodequeryoptions"></a>[DisplayModeQueryOptions](https://docs.microsoft.com/uwp/api/windows.devices.display.core.displaymodequeryoptions)

DisplayModeQueryOptions

#### <a name="displaypathhttpsdocsmicrosoftcomuwpapiwindowsdevicesdisplaycoredisplaypath"></a>[DisplayPath](https://docs.microsoft.com/uwp/api/windows.devices.display.core.displaypath)

DisplayPath <br> DisplayPath.ApplyPropertiesFromMode <br> DisplayPath.FindModes <br> DisplayPath.IsInterlaced <br> DisplayPath.IsStereo <br> DisplayPath.PresentationRate <br> DisplayPath.Properties <br> DisplayPath.Rotation <br> DisplayPath.Scaling <br> DisplayPath.SourcePixelFormat <br> DisplayPath.SourceResolution <br> DisplayPath.Status <br> DisplayPath.Target <br> DisplayPath.TargetResolution <br> DisplayPath.View <br> DisplayPath.WireFormat

#### <a name="displaypathscalinghttpsdocsmicrosoftcomuwpapiwindowsdevicesdisplaycoredisplaypathscaling"></a>[DisplayPathScaling](https://docs.microsoft.com/uwp/api/windows.devices.display.core.displaypathscaling)

DisplayPathScaling

#### <a name="displaypathstatushttpsdocsmicrosoftcomuwpapiwindowsdevicesdisplaycoredisplaypathstatus"></a>[DisplayPathStatus](https://docs.microsoft.com/uwp/api/windows.devices.display.core.displaypathstatus)

DisplayPathStatus

#### <a name="displaypresentationratehttpsdocsmicrosoftcomuwpapiwindowsdevicesdisplaycoredisplaypresentationrate"></a>[DisplayPresentationRate](https://docs.microsoft.com/uwp/api/windows.devices.display.core.displaypresentationrate)

DisplayPresentationRate

#### <a name="displayprimarydescriptionhttpsdocsmicrosoftcomuwpapiwindowsdevicesdisplaycoredisplayprimarydescription"></a>[DisplayPrimaryDescription](https://docs.microsoft.com/uwp/api/windows.devices.display.core.displayprimarydescription)

DisplayPrimaryDescription <br> DisplayPrimaryDescription.ColorSpace <br> DisplayPrimaryDescription.CreateWithProperties <br> DisplayPrimaryDescription。 #ctor <br> DisplayPrimaryDescription.Format <br> DisplayPrimaryDescription.Height <br> DisplayPrimaryDescription.IsStereo <br> DisplayPrimaryDescription.MultisampleDescription <br> DisplayPrimaryDescription.Properties <br> DisplayPrimaryDescription.Width

#### <a name="displayrotationhttpsdocsmicrosoftcomuwpapiwindowsdevicesdisplaycoredisplayrotation"></a>[DisplayRotation](https://docs.microsoft.com/uwp/api/windows.devices.display.core.displayrotation)

DisplayRotation

#### <a name="displayscanouthttpsdocsmicrosoftcomuwpapiwindowsdevicesdisplaycoredisplayscanout"></a>[DisplayScanout](https://docs.microsoft.com/uwp/api/windows.devices.display.core.displayscanout)

DisplayScanout

#### <a name="displaysourcehttpsdocsmicrosoftcomuwpapiwindowsdevicesdisplaycoredisplaysource"></a>[DisplaySource](https://docs.microsoft.com/uwp/api/windows.devices.display.core.displaysource)

DisplaySource <br> DisplaySource.AdapterId <br> DisplaySource.GetMetadata <br> DisplaySource.SourceId

#### <a name="displaystatehttpsdocsmicrosoftcomuwpapiwindowsdevicesdisplaycoredisplaystate"></a>[DisplayState](https://docs.microsoft.com/uwp/api/windows.devices.display.core.displaystate)

DisplayState <br> DisplayState.CanConnectTargetToView <br> DisplayState.Clone <br> DisplayState.ConnectTarget <br> DisplayState.ConnectTarget <br> DisplayState.DisconnectTarget <br> DisplayState.GetPathForTarget <br> DisplayState.GetViewForTarget <br> DisplayState.IsReadOnly <br> DisplayState.IsStale <br> DisplayState.Properties <br> DisplayState.Targets <br> DisplayState.TryApply <br> DisplayState.TryFunctionalize <br> DisplayState.Views

#### <a name="displaystateapplyoptionshttpsdocsmicrosoftcomuwpapiwindowsdevicesdisplaycoredisplaystateapplyoptions"></a>[DisplayStateApplyOptions](https://docs.microsoft.com/uwp/api/windows.devices.display.core.displaystateapplyoptions)

DisplayStateApplyOptions

#### <a name="displaystatefunctionalizeoptionshttpsdocsmicrosoftcomuwpapiwindowsdevicesdisplaycoredisplaystatefunctionalizeoptions"></a>[DisplayStateFunctionalizeOptions](https://docs.microsoft.com/uwp/api/windows.devices.display.core.displaystatefunctionalizeoptions)

DisplayStateFunctionalizeOptions

#### <a name="displaystateoperationresulthttpsdocsmicrosoftcomuwpapiwindowsdevicesdisplaycoredisplaystateoperationresult"></a>[DisplayStateOperationResult](https://docs.microsoft.com/uwp/api/windows.devices.display.core.displaystateoperationresult)

DisplayStateOperationResult <br> DisplayStateOperationResult.ExtendedErrorCode <br> DisplayStateOperationResult.Status

#### <a name="displaystateoperationstatushttpsdocsmicrosoftcomuwpapiwindowsdevicesdisplaycoredisplaystateoperationstatus"></a>[DisplayStateOperationStatus](https://docs.microsoft.com/uwp/api/windows.devices.display.core.displaystateoperationstatus)

DisplayStateOperationStatus

#### <a name="displaysurfacehttpsdocsmicrosoftcomuwpapiwindowsdevicesdisplaycoredisplaysurface"></a>[DisplaySurface](https://docs.microsoft.com/uwp/api/windows.devices.display.core.displaysurface)

DisplaySurface

#### <a name="displaytargethttpsdocsmicrosoftcomuwpapiwindowsdevicesdisplaycoredisplaytarget"></a>[DisplayTarget](https://docs.microsoft.com/uwp/api/windows.devices.display.core.displaytarget)

DisplayTarget <br> DisplayTarget.Adapter <br> DisplayTarget.AdapterRelativeId <br> DisplayTarget.DeviceInterfacePath <br> DisplayTarget.IsConnected <br> DisplayTarget.IsEqual <br> DisplayTarget.IsSame <br> DisplayTarget.IsStale <br> DisplayTarget.IsVirtualModeEnabled <br> DisplayTarget.IsVirtualTopologyEnabled <br> DisplayTarget.MonitorPersistence <br> DisplayTarget.Properties <br> DisplayTarget.StableMonitorId <br> DisplayTarget.TryGetMonitor <br> DisplayTarget.UsageKind

#### <a name="displaytargetpersistencehttpsdocsmicrosoftcomuwpapiwindowsdevicesdisplaycoredisplaytargetpersistence"></a>[DisplayTargetPersistence](https://docs.microsoft.com/uwp/api/windows.devices.display.core.displaytargetpersistence)

DisplayTargetPersistence

#### <a name="displaytaskhttpsdocsmicrosoftcomuwpapiwindowsdevicesdisplaycoredisplaytask"></a>[DisplayTask](https://docs.microsoft.com/uwp/api/windows.devices.display.core.displaytask)

DisplayTask <br> DisplayTask.SetScanout <br> DisplayTask.SetWait

#### <a name="displaytaskpoolhttpsdocsmicrosoftcomuwpapiwindowsdevicesdisplaycoredisplaytaskpool"></a>[DisplayTaskPool](https://docs.microsoft.com/uwp/api/windows.devices.display.core.displaytaskpool)

DisplayTaskPool <br> DisplayTaskPool.CreateTask <br> DisplayTaskPool.ExecuteTask

#### <a name="displaytasksignalkindhttpsdocsmicrosoftcomuwpapiwindowsdevicesdisplaycoredisplaytasksignalkind"></a>[DisplayTaskSignalKind](https://docs.microsoft.com/uwp/api/windows.devices.display.core.displaytasksignalkind)

DisplayTaskSignalKind

#### <a name="displayviewhttpsdocsmicrosoftcomuwpapiwindowsdevicesdisplaycoredisplayview"></a>[DisplayView](https://docs.microsoft.com/uwp/api/windows.devices.display.core.displayview)

DisplayView <br> DisplayView.ContentResolution <br> DisplayView.Paths <br> DisplayView.Properties <br> DisplayView.SetPrimaryPath

#### <a name="displaywireformathttpsdocsmicrosoftcomuwpapiwindowsdevicesdisplaycoredisplaywireformat"></a>[DisplayWireFormat](https://docs.microsoft.com/uwp/api/windows.devices.display.core.displaywireformat)

DisplayWireFormat <br> DisplayWireFormat.BitsPerChannel <br> DisplayWireFormat.ColorSpace <br> DisplayWireFormat.CreateWithProperties <br> DisplayWireFormat。 #ctor <br> DisplayWireFormat.Eotf <br> DisplayWireFormat.HdrMetadata <br> DisplayWireFormat.PixelEncoding <br> DisplayWireFormat.Properties

#### <a name="displaywireformatcolorspacehttpsdocsmicrosoftcomuwpapiwindowsdevicesdisplaycoredisplaywireformatcolorspace"></a>[DisplayWireFormatColorSpace](https://docs.microsoft.com/uwp/api/windows.devices.display.core.displaywireformatcolorspace)

DisplayWireFormatColorSpace

#### <a name="displaywireformateotfhttpsdocsmicrosoftcomuwpapiwindowsdevicesdisplaycoredisplaywireformateotf"></a>[DisplayWireFormatEotf](https://docs.microsoft.com/uwp/api/windows.devices.display.core.displaywireformateotf)

DisplayWireFormatEotf

#### <a name="displaywireformathdrmetadatahttpsdocsmicrosoftcomuwpapiwindowsdevicesdisplaycoredisplaywireformathdrmetadata"></a>[DisplayWireFormatHdrMetadata](https://docs.microsoft.com/uwp/api/windows.devices.display.core.displaywireformathdrmetadata)

DisplayWireFormatHdrMetadata

#### <a name="displaywireformatpixelencodinghttpsdocsmicrosoftcomuwpapiwindowsdevicesdisplaycoredisplaywireformatpixelencoding"></a>[DisplayWireFormatPixelEncoding](https://docs.microsoft.com/uwp/api/windows.devices.display.core.displaywireformatpixelencoding)

DisplayWireFormatPixelEncoding

### <a name="windowsdevicesenumerationhttpsdocsmicrosoftcomuwpapiwindowsdevicesenumeration"></a>[Windows.Devices.Enumeration](https://docs.microsoft.com/uwp/api/windows.devices.enumeration)

#### <a name="deviceinformationpairinghttpsdocsmicrosoftcomuwpapiwindowsdevicesenumerationdeviceinformationpairing"></a>[DeviceInformationPairing](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformationpairing)

DeviceInformationPairing.TryRegisterForAllInboundPairingRequestsWithProtectionLevel

### <a name="windowsdeviceslightseffectshttpsdocsmicrosoftcomuwpapiwindowsdeviceslightseffects"></a>[Windows.Devices.Lights.Effects](https://docs.microsoft.com/uwp/api/windows.devices.lights.effects)

#### <a name="ilamparrayeffecthttpsdocsmicrosoftcomuwpapiwindowsdeviceslightseffectsilamparrayeffect"></a>[ILampArrayEffect](https://docs.microsoft.com/uwp/api/windows.devices.lights.effects.ilamparrayeffect)

ILampArrayEffect <br> ILampArrayEffect.ZIndex

#### <a name="lamparraybitmapeffecthttpsdocsmicrosoftcomuwpapiwindowsdeviceslightseffectslamparraybitmapeffect"></a>[LampArrayBitmapEffect](https://docs.microsoft.com/uwp/api/windows.devices.lights.effects.lamparraybitmapeffect)

LampArrayBitmapEffect <br> LampArrayBitmapEffect.BitmapRequested <br> LampArrayBitmapEffect.Duration <br> LampArrayBitmapEffect。 #ctor <br> LampArrayBitmapEffect.StartDelay <br> LampArrayBitmapEffect.SuggestedBitmapSize <br> LampArrayBitmapEffect.UpdateInterval <br> LampArrayBitmapEffect.ZIndex

#### <a name="lamparraybitmaprequestedeventargshttpsdocsmicrosoftcomuwpapiwindowsdeviceslightseffectslamparraybitmaprequestedeventargs"></a>[LampArrayBitmapRequestedEventArgs](https://docs.microsoft.com/uwp/api/windows.devices.lights.effects.lamparraybitmaprequestedeventargs)

LampArrayBitmapRequestedEventArgs <br> LampArrayBitmapRequestedEventArgs.SinceStarted <br> LampArrayBitmapRequestedEventArgs.UpdateBitmap

#### <a name="lamparrayblinkeffecthttpsdocsmicrosoftcomuwpapiwindowsdeviceslightseffectslamparrayblinkeffect"></a>[LampArrayBlinkEffect](https://docs.microsoft.com/uwp/api/windows.devices.lights.effects.lamparrayblinkeffect)

LampArrayBlinkEffect <br> LampArrayBlinkEffect.AttackDuration <br> LampArrayBlinkEffect.Color <br> LampArrayBlinkEffect.DecayDuration <br> LampArrayBlinkEffect。 #ctor <br> LampArrayBlinkEffect.Occurrences <br> LampArrayBlinkEffect.RepetitionDelay <br> LampArrayBlinkEffect.RepetitionMode <br> LampArrayBlinkEffect.StartDelay <br> LampArrayBlinkEffect.SustainDuration <br> LampArrayBlinkEffect.ZIndex

#### <a name="lamparraycolorrampeffecthttpsdocsmicrosoftcomuwpapiwindowsdeviceslightseffectslamparraycolorrampeffect"></a>[LampArrayColorRampEffect](https://docs.microsoft.com/uwp/api/windows.devices.lights.effects.lamparraycolorrampeffect)

LampArrayColorRampEffect <br> LampArrayColorRampEffect.Color <br> LampArrayColorRampEffect.CompletionBehavior <br> LampArrayColorRampEffect。 #ctor <br> LampArrayColorRampEffect.RampDuration <br> LampArrayColorRampEffect.StartDelay <br> LampArrayColorRampEffect.ZIndex

#### <a name="lamparraycustomeffecthttpsdocsmicrosoftcomuwpapiwindowsdeviceslightseffectslamparraycustomeffect"></a>[LampArrayCustomEffect](https://docs.microsoft.com/uwp/api/windows.devices.lights.effects.lamparraycustomeffect)

LampArrayCustomEffect <br> LampArrayCustomEffect.Duration <br> LampArrayCustomEffect。 #ctor <br> LampArrayCustomEffect.UpdateInterval <br> LampArrayCustomEffect.UpdateRequested <br> LampArrayCustomEffect.ZIndex

#### <a name="lamparrayeffectcompletionbehaviorhttpsdocsmicrosoftcomuwpapiwindowsdeviceslightseffectslamparrayeffectcompletionbehavior"></a>[LampArrayEffectCompletionBehavior](https://docs.microsoft.com/uwp/api/windows.devices.lights.effects.lamparrayeffectcompletionbehavior)

LampArrayEffectCompletionBehavior

#### <a name="lamparrayeffectplaylisthttpsdocsmicrosoftcomuwpapiwindowsdeviceslightseffectslamparrayeffectplaylist"></a>[LampArrayEffectPlaylist](https://docs.microsoft.com/uwp/api/windows.devices.lights.effects.lamparrayeffectplaylist)

LampArrayEffectPlaylist <br> LampArrayEffectPlaylist.Append <br> LampArrayEffectPlaylist.EffectStartMode <br> LampArrayEffectPlaylist.First <br> LampArrayEffectPlaylist.GetAt <br> LampArrayEffectPlaylist.GetMany <br> LampArrayEffectPlaylist.IndexOf <br> LampArrayEffectPlaylist。 #ctor <br> LampArrayEffectPlaylist.Occurrences <br> LampArrayEffectPlaylist.OverrideZIndex <br> LampArrayEffectPlaylist.Pause <br> LampArrayEffectPlaylist.PauseAll <br> LampArrayEffectPlaylist.RepetitionMode <br> LampArrayEffectPlaylist.Size <br> LampArrayEffectPlaylist.Start <br> LampArrayEffectPlaylist.StartAll <br> LampArrayEffectPlaylist.Stop <br> LampArrayEffectPlaylist.StopAll

#### <a name="lamparrayeffectstartmodehttpsdocsmicrosoftcomuwpapiwindowsdeviceslightseffectslamparrayeffectstartmode"></a>[LampArrayEffectStartMode](https://docs.microsoft.com/uwp/api/windows.devices.lights.effects.lamparrayeffectstartmode)

LampArrayEffectStartMode

#### <a name="lamparrayrepetitionmodehttpsdocsmicrosoftcomuwpapiwindowsdeviceslightseffectslamparrayrepetitionmode"></a>[LampArrayRepetitionMode](https://docs.microsoft.com/uwp/api/windows.devices.lights.effects.lamparrayrepetitionmode)

LampArrayRepetitionMode

#### <a name="lamparraysolideffecthttpsdocsmicrosoftcomuwpapiwindowsdeviceslightseffectslamparraysolideffect"></a>[LampArraySolidEffect](https://docs.microsoft.com/uwp/api/windows.devices.lights.effects.lamparraysolideffect)

LampArraySolidEffect <br> LampArraySolidEffect.Color <br> LampArraySolidEffect.CompletionBehavior <br> LampArraySolidEffect.Duration <br> LampArraySolidEffect。 #ctor <br> LampArraySolidEffect.StartDelay <br> LampArraySolidEffect.ZIndex

#### <a name="lamparrayupdaterequestedeventargshttpsdocsmicrosoftcomuwpapiwindowsdeviceslightseffectslamparrayupdaterequestedeventargs"></a>[LampArrayUpdateRequestedEventArgs](https://docs.microsoft.com/uwp/api/windows.devices.lights.effects.lamparrayupdaterequestedeventargs)

LampArrayUpdateRequestedEventArgs <br> LampArrayUpdateRequestedEventArgs.SetColor <br> LampArrayUpdateRequestedEventArgs.SetColorForIndex <br> LampArrayUpdateRequestedEventArgs.SetColorsForIndices <br> LampArrayUpdateRequestedEventArgs.SetSingleColorForIndices <br> LampArrayUpdateRequestedEventArgs.SinceStarted

### <a name="windowsdeviceslightshttpsdocsmicrosoftcomuwpapiwindowsdeviceslights"></a>[Windows.Devices.Lights](https://docs.microsoft.com/uwp/api/windows.devices.lights)

#### <a name="lamparrayhttpsdocsmicrosoftcomuwpapiwindowsdeviceslightslamparray"></a>[LampArray](https://docs.microsoft.com/uwp/api/windows.devices.lights.lamparray)

LampArray <br> LampArray.BoundingBox <br> LampArray.BrightnessLevel <br> LampArray.DeviceId <br> LampArray.FromIdAsync <br> LampArray.GetDeviceSelector <br> LampArray.GetIndicesForKey <br> LampArray.GetIndicesForPurposes <br> LampArray.GetLampInfo <br> LampArray.HardwareProductId <br> LampArray.HardwareVendorId <br> LampArray.HardwareVersion <br> LampArray.IsConnected <br> LampArray.IsEnabled <br> LampArray.LampArrayKind <br> LampArray.LampCount <br> LampArray.MinUpdateInterval <br> LampArray.RequestMessageAsync <br> LampArray.SendMessageAsync <br> LampArray.SetColor <br> LampArray.SetColorForIndex <br> LampArray.SetColorsForIndices <br> LampArray.SetColorsForKey <br> LampArray.SetColorsForKeys <br> LampArray.SetColorsForPurposes <br> LampArray.SetSingleColorForIndices <br> LampArray.SupportsVirtualKeys

#### <a name="lamparraykindhttpsdocsmicrosoftcomuwpapiwindowsdeviceslightslamparraykind"></a>[LampArrayKind](https://docs.microsoft.com/uwp/api/windows.devices.lights.lamparraykind)

LampArrayKind

#### <a name="lampinfohttpsdocsmicrosoftcomuwpapiwindowsdeviceslightslampinfo"></a>[LampInfo](https://docs.microsoft.com/uwp/api/windows.devices.lights.lampinfo)

LampInfo <br> LampInfo.BlueLevelCount <br> LampInfo.FixedColor <br> LampInfo.GainLevelCount <br> LampInfo.GetNearestSupportedColor <br> LampInfo.GreenLevelCount <br> LampInfo.Index <br> LampInfo.Position <br> LampInfo.Purposes <br> LampInfo.RedLevelCount <br> LampInfo.UpdateLatency

#### <a name="lamppurposeshttpsdocsmicrosoftcomuwpapiwindowsdeviceslightslamppurposes"></a>[LampPurposes](https://docs.microsoft.com/uwp/api/windows.devices.lights.lamppurposes)

LampPurposes

### <a name="windowsdevicespointofserviceproviderhttpsdocsmicrosoftcomuwpapiwindowsdevicespointofserviceprovider"></a>[Windows.Devices.PointOfService.Provider](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.provider)

#### <a name="barcodescannerdisablescannerrequesthttpsdocsmicrosoftcomuwpapiwindowsdevicespointofserviceproviderbarcodescannerdisablescannerrequest"></a>[BarcodeScannerDisableScannerRequest](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.provider.barcodescannerdisablescannerrequest)

BarcodeScannerDisableScannerRequest.ReportFailedAsync <br> BarcodeScannerDisableScannerRequest.ReportFailedAsync

#### <a name="barcodescannerenablescannerrequesthttpsdocsmicrosoftcomuwpapiwindowsdevicespointofserviceproviderbarcodescannerenablescannerrequest"></a>[BarcodeScannerEnableScannerRequest](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.provider.barcodescannerenablescannerrequest)

BarcodeScannerEnableScannerRequest.ReportFailedAsync <br> BarcodeScannerEnableScannerRequest.ReportFailedAsync

#### <a name="barcodescannerframereaderhttpsdocsmicrosoftcomuwpapiwindowsdevicespointofserviceproviderbarcodescannerframereader"></a>[BarcodeScannerFrameReader](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.provider.barcodescannerframereader)

BarcodeScannerFrameReader <br> BarcodeScannerFrameReader.Close <br> BarcodeScannerFrameReader.Connection <br> BarcodeScannerFrameReader.FrameArrived <br> BarcodeScannerFrameReader.StartAsync <br> BarcodeScannerFrameReader.StopAsync <br> BarcodeScannerFrameReader.TryAcquireLatestFrameAsync

#### <a name="barcodescannerframereaderframearrivedeventargshttpsdocsmicrosoftcomuwpapiwindowsdevicespointofserviceproviderbarcodescannerframereaderframearrivedeventargs"></a>[BarcodeScannerFrameReaderFrameArrivedEventArgs](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.provider.barcodescannerframereaderframearrivedeventargs)

BarcodeScannerFrameReaderFrameArrivedEventArgs <br> BarcodeScannerFrameReaderFrameArrivedEventArgs.GetDeferral

#### <a name="barcodescannergetsymbologyattributesrequesthttpsdocsmicrosoftcomuwpapiwindowsdevicespointofserviceproviderbarcodescannergetsymbologyattributesrequest"></a>[BarcodeScannerGetSymbologyAttributesRequest](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.provider.barcodescannergetsymbologyattributesrequest)

BarcodeScannerGetSymbologyAttributesRequest.ReportFailedAsync <br> BarcodeScannerGetSymbologyAttributesRequest.ReportFailedAsync

#### <a name="barcodescannerhidevideopreviewrequesthttpsdocsmicrosoftcomuwpapiwindowsdevicespointofserviceproviderbarcodescannerhidevideopreviewrequest"></a>[BarcodeScannerHideVideoPreviewRequest](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.provider.barcodescannerhidevideopreviewrequest)

BarcodeScannerHideVideoPreviewRequest.ReportFailedAsync <br> BarcodeScannerHideVideoPreviewRequest.ReportFailedAsync

#### <a name="barcodescannerproviderconnectionhttpsdocsmicrosoftcomuwpapiwindowsdevicespointofserviceproviderbarcodescannerproviderconnection"></a>[BarcodeScannerProviderConnection](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.provider.barcodescannerproviderconnection)

BarcodeScannerProviderConnection.CreateFrameReaderAsync <br> BarcodeScannerProviderConnection.CreateFrameReaderAsync <br> BarcodeScannerProviderConnection.CreateFrameReaderAsync

#### <a name="barcodescannersetactivesymbologiesrequesthttpsdocsmicrosoftcomuwpapiwindowsdevicespointofserviceproviderbarcodescannersetactivesymbologiesrequest"></a>[BarcodeScannerSetActiveSymbologiesRequest](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.provider.barcodescannersetactivesymbologiesrequest)

BarcodeScannerSetActiveSymbologiesRequest.ReportFailedAsync <br> BarcodeScannerSetActiveSymbologiesRequest.ReportFailedAsync

#### <a name="barcodescannersetsymbologyattributesrequesthttpsdocsmicrosoftcomuwpapiwindowsdevicespointofserviceproviderbarcodescannersetsymbologyattributesrequest"></a>[BarcodeScannerSetSymbologyAttributesRequest](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.provider.barcodescannersetsymbologyattributesrequest)

BarcodeScannerSetSymbologyAttributesRequest.ReportFailedAsync <br> BarcodeScannerSetSymbologyAttributesRequest.ReportFailedAsync

#### <a name="barcodescannerstartsoftwaretriggerrequesthttpsdocsmicrosoftcomuwpapiwindowsdevicespointofserviceproviderbarcodescannerstartsoftwaretriggerrequest"></a>[BarcodeScannerStartSoftwareTriggerRequest](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.provider.barcodescannerstartsoftwaretriggerrequest)

BarcodeScannerStartSoftwareTriggerRequest.ReportFailedAsync <br> BarcodeScannerStartSoftwareTriggerRequest.ReportFailedAsync

#### <a name="barcodescannerstopsoftwaretriggerrequesthttpsdocsmicrosoftcomuwpapiwindowsdevicespointofserviceproviderbarcodescannerstopsoftwaretriggerrequest"></a>[BarcodeScannerStopSoftwareTriggerRequest](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.provider.barcodescannerstopsoftwaretriggerrequest)

BarcodeScannerStopSoftwareTriggerRequest.ReportFailedAsync <br> BarcodeScannerStopSoftwareTriggerRequest.ReportFailedAsync

#### <a name="barcodescannervideoframehttpsdocsmicrosoftcomuwpapiwindowsdevicespointofserviceproviderbarcodescannervideoframe"></a>[BarcodeScannerVideoFrame](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.provider.barcodescannervideoframe)

BarcodeScannerVideoFrame <br> BarcodeScannerVideoFrame.Close <br> BarcodeScannerVideoFrame.Format <br> BarcodeScannerVideoFrame.Height <br> BarcodeScannerVideoFrame.PixelData <br> BarcodeScannerVideoFrame.Width

### <a name="windowsdevicespointofservicehttpsdocsmicrosoftcomuwpapiwindowsdevicespointofservice"></a>[Windows.Devices.PointOfService](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice)

#### <a name="barcodescannercapabilitieshttpsdocsmicrosoftcomuwpapiwindowsdevicespointofservicebarcodescannercapabilities"></a>[BarcodeScannerCapabilities](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescannercapabilities)

BarcodeScannerCapabilities.IsVideoPreviewSupported

#### <a name="claimedbarcodescannerhttpsdocsmicrosoftcomuwpapiwindowsdevicespointofserviceclaimedbarcodescanner"></a>[ClaimedBarcodeScanner](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner)

ClaimedBarcodeScanner.Closed

#### <a name="claimedbarcodescannerclosedeventargshttpsdocsmicrosoftcomuwpapiwindowsdevicespointofserviceclaimedbarcodescannerclosedeventargs"></a>[ClaimedBarcodeScannerClosedEventArgs](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescannerclosedeventargs)

ClaimedBarcodeScannerClosedEventArgs

#### <a name="claimedcashdrawerhttpsdocsmicrosoftcomuwpapiwindowsdevicespointofserviceclaimedcashdrawer"></a>[ClaimedCashDrawer](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedcashdrawer)

ClaimedCashDrawer.Closed

#### <a name="claimedcashdrawerclosedeventargshttpsdocsmicrosoftcomuwpapiwindowsdevicespointofserviceclaimedcashdrawerclosedeventargs"></a>[ClaimedCashDrawerClosedEventArgs](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedcashdrawerclosedeventargs)

ClaimedCashDrawerClosedEventArgs

#### <a name="claimedlinedisplayhttpsdocsmicrosoftcomuwpapiwindowsdevicespointofserviceclaimedlinedisplay"></a>[ClaimedLineDisplay](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedlinedisplay)

ClaimedLineDisplay.Closed

#### <a name="claimedlinedisplayclosedeventargshttpsdocsmicrosoftcomuwpapiwindowsdevicespointofserviceclaimedlinedisplayclosedeventargs"></a>[ClaimedLineDisplayClosedEventArgs](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedlinedisplayclosedeventargs)

ClaimedLineDisplayClosedEventArgs

#### <a name="claimedmagneticstripereaderhttpsdocsmicrosoftcomuwpapiwindowsdevicespointofserviceclaimedmagneticstripereader"></a>[ClaimedMagneticStripeReader](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedmagneticstripereader)

ClaimedMagneticStripeReader.Closed

#### <a name="claimedmagneticstripereaderclosedeventargshttpsdocsmicrosoftcomuwpapiwindowsdevicespointofserviceclaimedmagneticstripereaderclosedeventargs"></a>[ClaimedMagneticStripeReaderClosedEventArgs](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedmagneticstripereaderclosedeventargs)

ClaimedMagneticStripeReaderClosedEventArgs

#### <a name="claimedposprinterhttpsdocsmicrosoftcomuwpapiwindowsdevicespointofserviceclaimedposprinter"></a>[ClaimedPosPrinter](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedposprinter)

ClaimedPosPrinter.Closed

#### <a name="claimedposprinterclosedeventargshttpsdocsmicrosoftcomuwpapiwindowsdevicespointofserviceclaimedposprinterclosedeventargs"></a>[ClaimedPosPrinterClosedEventArgs](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedposprinterclosedeventargs)

ClaimedPosPrinterClosedEventArgs

### <a name="windowsdevicessensorshttpsdocsmicrosoftcomuwpapiwindowsdevicessensors"></a>[Windows.Devices.Sensors](https://docs.microsoft.com/uwp/api/windows.devices.sensors)

#### <a name="simpleorientationsensorhttpsdocsmicrosoftcomuwpapiwindowsdevicessensorssimpleorientationsensor"></a>[SimpleOrientationSensor](https://docs.microsoft.com/uwp/api/windows.devices.sensors.simpleorientationsensor)

SimpleOrientationSensor.FromIdAsync <br> SimpleOrientationSensor.GetDeviceSelector

### <a name="windowsdevicessmartcardshttpsdocsmicrosoftcomuwpapiwindowsdevicessmartcards"></a>[Windows.Devices.SmartCards](https://docs.microsoft.com/uwp/api/windows.devices.smartcards)

#### <a name="knownsmartcardappletidshttpsdocsmicrosoftcomuwpapiwindowsdevicessmartcardsknownsmartcardappletids"></a>[KnownSmartCardAppletIds](https://docs.microsoft.com/uwp/api/windows.devices.smartcards.knownsmartcardappletids)

KnownSmartCardAppletIds <br> KnownSmartCardAppletIds.PaymentSystemEnvironment <br> KnownSmartCardAppletIds.ProximityPaymentSystemEnvironment

#### <a name="smartcardappletidgrouphttpsdocsmicrosoftcomuwpapiwindowsdevicessmartcardssmartcardappletidgroup"></a>[SmartCardAppletIdGroup](https://docs.microsoft.com/uwp/api/windows.devices.smartcards.smartcardappletidgroup)

SmartCardAppletIdGroup.Description <br> SmartCardAppletIdGroup.Logo <br> SmartCardAppletIdGroup.Properties <br> SmartCardAppletIdGroup.SecureUserAuthenticationRequired

#### <a name="smartcardappletidgroupregistrationhttpsdocsmicrosoftcomuwpapiwindowsdevicessmartcardssmartcardappletidgroupregistration"></a>[SmartCardAppletIdGroupRegistration](https://docs.microsoft.com/uwp/api/windows.devices.smartcards.smartcardappletidgroupregistration)

SmartCardAppletIdGroupRegistration.SetPropertiesAsync <br> SmartCardAppletIdGroupRegistration.SmartCardReaderId

## <a name="windowsfoundation"></a>Windows.Foundation

### <a name="windowsfoundationhttpsdocsmicrosoftcomuwpapiwindowsfoundation"></a>[Windows.Foundation](https://docs.microsoft.com/uwp/api/windows.foundation)

#### <a name="guidhelperhttpsdocsmicrosoftcomuwpapiwindowsfoundationguidhelper"></a>[GuidHelper](https://docs.microsoft.com/uwp/api/windows.foundation.guidhelper)

GuidHelper <br> GuidHelper.CreateNewGuid <br> GuidHelper.Empty <br> GuidHelper.Equals

## <a name="windowsglobalization"></a>Windows.Globalization

### <a name="windowsglobalizationhttpsdocsmicrosoftcomuwpapiwindowsglobalization"></a>[Windows.Globalization](https://docs.microsoft.com/uwp/api/windows.globalization)

#### <a name="currencyidentifiershttpsdocsmicrosoftcomuwpapiwindowsglobalizationcurrencyidentifiers"></a>[CurrencyIdentifiers](https://docs.microsoft.com/uwp/api/windows.globalization.currencyidentifiers)

CurrencyIdentifiers.MRU <br> CurrencyIdentifiers.SSP <br> CurrencyIdentifiers.STN <br> CurrencyIdentifiers.VES

## <a name="windowsgraphics"></a>Windows.Graphics

### <a name="windowsgraphicscapturehttpsdocsmicrosoftcomuwpapiwindowsgraphicscapture"></a>[Windows.Graphics.Capture](https://docs.microsoft.com/uwp/api/windows.graphics.capture)

#### <a name="direct3d11captureframepoolhttpsdocsmicrosoftcomuwpapiwindowsgraphicscapturedirect3d11captureframepool"></a>[Direct3D11CaptureFramePool](https://docs.microsoft.com/uwp/api/windows.graphics.capture.direct3d11captureframepool)

Direct3D11CaptureFramePool.CreateFreeThreaded

#### <a name="graphicscaptureitemhttpsdocsmicrosoftcomuwpapiwindowsgraphicscapturegraphicscaptureitem"></a>[GraphicsCaptureItem](https://docs.microsoft.com/uwp/api/windows.graphics.capture.graphicscaptureitem)

GraphicsCaptureItem.CreateFromVisual

### <a name="windowsgraphicsdisplaycorehttpsdocsmicrosoftcomuwpapiwindowsgraphicsdisplaycore"></a>[Windows.Graphics.Display.Core](https://docs.microsoft.com/uwp/api/windows.graphics.display.core)

#### <a name="hdmidisplaymodehttpsdocsmicrosoftcomuwpapiwindowsgraphicsdisplaycorehdmidisplaymode"></a>[HdmiDisplayMode](https://docs.microsoft.com/uwp/api/windows.graphics.display.core.hdmidisplaymode)

HdmiDisplayMode.IsDolbyVisionLowLatencySupported

### <a name="windowsgraphicsholographichttpsdocsmicrosoftcomuwpapiwindowsgraphicsholographic"></a>[Windows.Graphics.Holographic](https://docs.microsoft.com/uwp/api/windows.graphics.holographic)

#### <a name="holographiccamerahttpsdocsmicrosoftcomuwpapiwindowsgraphicsholographicholographiccamera"></a>[HolographicCamera](https://docs.microsoft.com/uwp/api/windows.graphics.holographic.holographiccamera)

HolographicCamera.IsHardwareContentProtectionEnabled <br> HolographicCamera.IsHardwareContentProtectionSupported

#### <a name="holographicquadlayerupdateparametershttpsdocsmicrosoftcomuwpapiwindowsgraphicsholographicholographicquadlayerupdateparameters"></a>[HolographicQuadLayerUpdateParameters](https://docs.microsoft.com/uwp/api/windows.graphics.holographic.holographicquadlayerupdateparameters)

HolographicQuadLayerUpdateParameters.AcquireBufferToUpdateContentWithHardwareProtection <br> HolographicQuadLayerUpdateParameters.CanAcquireWithHardwareProtection

### <a name="windowsgraphicsimaginghttpsdocsmicrosoftcomuwpapiwindowsgraphicsimaging"></a>[Windows.Graphics.Imaging](https://docs.microsoft.com/uwp/api/windows.graphics.imaging)

#### <a name="bitmapdecoderhttpsdocsmicrosoftcomuwpapiwindowsgraphicsimagingbitmapdecoder"></a>[BitmapDecoder](https://docs.microsoft.com/uwp/api/windows.graphics.imaging.bitmapdecoder)

BitmapDecoder.HeifDecoderId <br> BitmapDecoder.WebpDecoderId

#### <a name="bitmapencoderhttpsdocsmicrosoftcomuwpapiwindowsgraphicsimagingbitmapencoder"></a>[BitmapEncoder](https://docs.microsoft.com/uwp/api/windows.graphics.imaging.bitmapencoder)

BitmapEncoder.HeifEncoderId

## <a name="windowsmanagement"></a>Windows.Management

### <a name="windowsmanagementdeploymenthttpsdocsmicrosoftcomuwpapiwindowsmanagementdeployment"></a>[Windows.Management.Deployment](https://docs.microsoft.com/uwp/api/windows.management.deployment)

#### <a name="packagemanagerhttpsdocsmicrosoftcomuwpapiwindowsmanagementdeploymentpackagemanager"></a>[PackageManager](https://docs.microsoft.com/uwp/api/windows.management.deployment.packagemanager)

PackageManager.DeprovisionPackageForAllUsersAsync

## <a name="windowsmedia"></a>Windows.Media

### <a name="windowsmediaaudiohttpsdocsmicrosoftcomuwpapiwindowsmediaaudio"></a>[Windows.Media.Audio](https://docs.microsoft.com/uwp/api/windows.media.audio)

#### <a name="createaudiodeviceinputnoderesulthttpsdocsmicrosoftcomuwpapiwindowsmediaaudiocreateaudiodeviceinputnoderesult"></a>[CreateAudioDeviceInputNodeResult](https://docs.microsoft.com/uwp/api/windows.media.audio.createaudiodeviceinputnoderesult)

CreateAudioDeviceInputNodeResult.ExtendedError

#### <a name="createaudiodeviceoutputnoderesulthttpsdocsmicrosoftcomuwpapiwindowsmediaaudiocreateaudiodeviceoutputnoderesult"></a>[CreateAudioDeviceOutputNodeResult](https://docs.microsoft.com/uwp/api/windows.media.audio.createaudiodeviceoutputnoderesult)

CreateAudioDeviceOutputNodeResult.ExtendedError

#### <a name="createaudiofileinputnoderesulthttpsdocsmicrosoftcomuwpapiwindowsmediaaudiocreateaudiofileinputnoderesult"></a>[CreateAudioFileInputNodeResult](https://docs.microsoft.com/uwp/api/windows.media.audio.createaudiofileinputnoderesult)

CreateAudioFileInputNodeResult.ExtendedError

#### <a name="createaudiofileoutputnoderesulthttpsdocsmicrosoftcomuwpapiwindowsmediaaudiocreateaudiofileoutputnoderesult"></a>[CreateAudioFileOutputNodeResult](https://docs.microsoft.com/uwp/api/windows.media.audio.createaudiofileoutputnoderesult)

CreateAudioFileOutputNodeResult.ExtendedError

#### <a name="createaudiographresulthttpsdocsmicrosoftcomuwpapiwindowsmediaaudiocreateaudiographresult"></a>[CreateAudioGraphResult](https://docs.microsoft.com/uwp/api/windows.media.audio.createaudiographresult)

CreateAudioGraphResult.ExtendedError

#### <a name="createmediasourceaudioinputnoderesulthttpsdocsmicrosoftcomuwpapiwindowsmediaaudiocreatemediasourceaudioinputnoderesult"></a>[CreateMediaSourceAudioInputNodeResult](https://docs.microsoft.com/uwp/api/windows.media.audio.createmediasourceaudioinputnoderesult)

CreateMediaSourceAudioInputNodeResult.ExtendedError

#### <a name="mixedrealityspatialaudioformatpolicyhttpsdocsmicrosoftcomuwpapiwindowsmediaaudiomixedrealityspatialaudioformatpolicy"></a>[MixedRealitySpatialAudioFormatPolicy](https://docs.microsoft.com/uwp/api/windows.media.audio.mixedrealityspatialaudioformatpolicy)

MixedRealitySpatialAudioFormatPolicy

#### <a name="setdefaultspatialaudioformatresulthttpsdocsmicrosoftcomuwpapiwindowsmediaaudiosetdefaultspatialaudioformatresult"></a>[SetDefaultSpatialAudioFormatResult](https://docs.microsoft.com/uwp/api/windows.media.audio.setdefaultspatialaudioformatresult)

SetDefaultSpatialAudioFormatResult <br> SetDefaultSpatialAudioFormatResult.Status

#### <a name="setdefaultspatialaudioformatstatushttpsdocsmicrosoftcomuwpapiwindowsmediaaudiosetdefaultspatialaudioformatstatus"></a>[SetDefaultSpatialAudioFormatStatus](https://docs.microsoft.com/uwp/api/windows.media.audio.setdefaultspatialaudioformatstatus)

SetDefaultSpatialAudioFormatStatus

#### <a name="spatialaudiodeviceconfigurationhttpsdocsmicrosoftcomuwpapiwindowsmediaaudiospatialaudiodeviceconfiguration"></a>[SpatialAudioDeviceConfiguration](https://docs.microsoft.com/uwp/api/windows.media.audio.spatialaudiodeviceconfiguration)

SpatialAudioDeviceConfiguration <br> SpatialAudioDeviceConfiguration.ActiveSpatialAudioFormat <br> SpatialAudioDeviceConfiguration.ConfigurationChanged <br> SpatialAudioDeviceConfiguration.DefaultSpatialAudioFormat <br> SpatialAudioDeviceConfiguration.DeviceId <br> SpatialAudioDeviceConfiguration.GetForDeviceId <br> SpatialAudioDeviceConfiguration.IsSpatialAudioFormatSupported <br> SpatialAudioDeviceConfiguration.IsSpatialAudioSupported <br> SpatialAudioDeviceConfiguration.SetDefaultSpatialAudioFormatAsync

#### <a name="spatialaudioformatconfigurationhttpsdocsmicrosoftcomuwpapiwindowsmediaaudiospatialaudioformatconfiguration"></a>[SpatialAudioFormatConfiguration](https://docs.microsoft.com/uwp/api/windows.media.audio.spatialaudioformatconfiguration)

SpatialAudioFormatConfiguration <br> SpatialAudioFormatConfiguration.GetDefault <br> SpatialAudioFormatConfiguration.MixedRealityExclusiveModePolicy <br> SpatialAudioFormatConfiguration.ReportConfigurationChangedAsync <br> SpatialAudioFormatConfiguration.ReportLicenseChangedAsync

#### <a name="spatialaudioformatsubtypehttpsdocsmicrosoftcomuwpapiwindowsmediaaudiospatialaudioformatsubtype"></a>[SpatialAudioFormatSubtype](https://docs.microsoft.com/uwp/api/windows.media.audio.spatialaudioformatsubtype)

SpatialAudioFormatSubtype <br> SpatialAudioFormatSubtype.DolbyAtmosForHeadphones <br> SpatialAudioFormatSubtype.DolbyAtmosForHomeTheater <br> SpatialAudioFormatSubtype.DolbyAtmosForSpeakers <br> SpatialAudioFormatSubtype.DTSHeadphoneX <br> SpatialAudioFormatSubtype.DTSXUltra <br> SpatialAudioFormatSubtype.WindowsSonic

### <a name="windowsmediacontrolhttpsdocsmicrosoftcomuwpapiwindowsmediacontrol"></a>[Windows.Media.Control](https://docs.microsoft.com/uwp/api/windows.media.control)

#### <a name="currentsessionchangedeventargshttpsdocsmicrosoftcomuwpapiwindowsmediacontrolcurrentsessionchangedeventargs"></a>[CurrentSessionChangedEventArgs](https://docs.microsoft.com/uwp/api/windows.media.control.currentsessionchangedeventargs)

CurrentSessionChangedEventArgs

#### <a name="globalsystemmediatransportcontrolssessionhttpsdocsmicrosoftcomuwpapiwindowsmediacontrolglobalsystemmediatransportcontrolssession"></a>[GlobalSystemMediaTransportControlsSession](https://docs.microsoft.com/uwp/api/windows.media.control.globalsystemmediatransportcontrolssession)

GlobalSystemMediaTransportControlsSession <br> GlobalSystemMediaTransportControlsSession.GetPlaybackInfo <br> GlobalSystemMediaTransportControlsSession.GetTimelineProperties <br> GlobalSystemMediaTransportControlsSession.MediaPropertiesChanged <br> GlobalSystemMediaTransportControlsSession.PlaybackInfoChanged <br> GlobalSystemMediaTransportControlsSession.SourceAppUserModelId <br> GlobalSystemMediaTransportControlsSession.TimelinePropertiesChanged <br> GlobalSystemMediaTransportControlsSession.TryChangeAutoRepeatModeAsync <br> GlobalSystemMediaTransportControlsSession.TryChangeChannelDownAsync <br> GlobalSystemMediaTransportControlsSession.TryChangeChannelUpAsync <br> GlobalSystemMediaTransportControlsSession.TryChangePlaybackPositionAsync <br> GlobalSystemMediaTransportControlsSession.TryChangePlaybackRateAsync <br> GlobalSystemMediaTransportControlsSession.TryChangeShuffleActiveAsync <br> GlobalSystemMediaTransportControlsSession.TryFastForwardAsync <br> GlobalSystemMediaTransportControlsSession.TryGetMediaPropertiesAsync <br> GlobalSystemMediaTransportControlsSession.TryPauseAsync <br> GlobalSystemMediaTransportControlsSession.TryPlayAsync <br> GlobalSystemMediaTransportControlsSession.TryRecordAsync <br> GlobalSystemMediaTransportControlsSession.TryRewindAsync <br> GlobalSystemMediaTransportControlsSession.TrySkipNextAsync <br> GlobalSystemMediaTransportControlsSession.TrySkipPreviousAsync <br> GlobalSystemMediaTransportControlsSession.TryStopAsync <br> GlobalSystemMediaTransportControlsSession.TryTogglePlayPauseAsync

#### <a name="globalsystemmediatransportcontrolssessionmanagerhttpsdocsmicrosoftcomuwpapiwindowsmediacontrolglobalsystemmediatransportcontrolssessionmanager"></a>[GlobalSystemMediaTransportControlsSessionManager](https://docs.microsoft.com/uwp/api/windows.media.control.globalsystemmediatransportcontrolssessionmanager)

GlobalSystemMediaTransportControlsSessionManager <br> GlobalSystemMediaTransportControlsSessionManager.CurrentSessionChanged <br> GlobalSystemMediaTransportControlsSessionManager.GetCurrentSession <br> GlobalSystemMediaTransportControlsSessionManager.GetSessions <br> GlobalSystemMediaTransportControlsSessionManager.RequestAsync <br> GlobalSystemMediaTransportControlsSessionManager.SessionsChanged

#### <a name="globalsystemmediatransportcontrolssessionmediapropertieshttpsdocsmicrosoftcomuwpapiwindowsmediacontrolglobalsystemmediatransportcontrolssessionmediaproperties"></a>[GlobalSystemMediaTransportControlsSessionMediaProperties](https://docs.microsoft.com/uwp/api/windows.media.control.globalsystemmediatransportcontrolssessionmediaproperties)

GlobalSystemMediaTransportControlsSessionMediaProperties <br> GlobalSystemMediaTransportControlsSessionMediaProperties.AlbumArtist <br> GlobalSystemMediaTransportControlsSessionMediaProperties.AlbumTitle <br> GlobalSystemMediaTransportControlsSessionMediaProperties.AlbumTrackCount <br> GlobalSystemMediaTransportControlsSessionMediaProperties.Artist <br> GlobalSystemMediaTransportControlsSessionMediaProperties.Genres <br> GlobalSystemMediaTransportControlsSessionMediaProperties.PlaybackType <br> GlobalSystemMediaTransportControlsSessionMediaProperties.Subtitle <br> GlobalSystemMediaTransportControlsSessionMediaProperties.Thumbnail <br> GlobalSystemMediaTransportControlsSessionMediaProperties.Title <br> GlobalSystemMediaTransportControlsSessionMediaProperties.TrackNumber

#### <a name="globalsystemmediatransportcontrolssessionplaybackcontrolshttpsdocsmicrosoftcomuwpapiwindowsmediacontrolglobalsystemmediatransportcontrolssessionplaybackcontrols"></a>[GlobalSystemMediaTransportControlsSessionPlaybackControls](https://docs.microsoft.com/uwp/api/windows.media.control.globalsystemmediatransportcontrolssessionplaybackcontrols)

GlobalSystemMediaTransportControlsSessionPlaybackControls <br> GlobalSystemMediaTransportControlsSessionPlaybackControls.IsChannelDownEnabled <br> GlobalSystemMediaTransportControlsSessionPlaybackControls.IsChannelUpEnabled <br> GlobalSystemMediaTransportControlsSessionPlaybackControls.IsFastForwardEnabled <br> GlobalSystemMediaTransportControlsSessionPlaybackControls.IsNextEnabled <br> GlobalSystemMediaTransportControlsSessionPlaybackControls.IsPauseEnabled <br> GlobalSystemMediaTransportControlsSessionPlaybackControls.IsPlaybackPositionEnabled <br> GlobalSystemMediaTransportControlsSessionPlaybackControls.IsPlaybackRateEnabled <br> GlobalSystemMediaTransportControlsSessionPlaybackControls.IsPlayEnabled <br> GlobalSystemMediaTransportControlsSessionPlaybackControls.IsPlayPauseToggleEnabled <br> GlobalSystemMediaTransportControlsSessionPlaybackControls.IsPreviousEnabled <br> GlobalSystemMediaTransportControlsSessionPlaybackControls.IsRecordEnabled <br> GlobalSystemMediaTransportControlsSessionPlaybackControls.IsRepeatEnabled <br> GlobalSystemMediaTransportControlsSessionPlaybackControls.IsRewindEnabled <br> GlobalSystemMediaTransportControlsSessionPlaybackControls.IsShuffleEnabled <br> GlobalSystemMediaTransportControlsSessionPlaybackControls.IsStopEnabled

#### <a name="globalsystemmediatransportcontrolssessionplaybackinfohttpsdocsmicrosoftcomuwpapiwindowsmediacontrolglobalsystemmediatransportcontrolssessionplaybackinfo"></a>[GlobalSystemMediaTransportControlsSessionPlaybackInfo](https://docs.microsoft.com/uwp/api/windows.media.control.globalsystemmediatransportcontrolssessionplaybackinfo)

GlobalSystemMediaTransportControlsSessionPlaybackInfo <br> GlobalSystemMediaTransportControlsSessionPlaybackInfo.AutoRepeatMode <br> GlobalSystemMediaTransportControlsSessionPlaybackInfo.Controls <br> GlobalSystemMediaTransportControlsSessionPlaybackInfo.IsShuffleActive <br> GlobalSystemMediaTransportControlsSessionPlaybackInfo.PlaybackRate <br> GlobalSystemMediaTransportControlsSessionPlaybackInfo.PlaybackStatus <br> GlobalSystemMediaTransportControlsSessionPlaybackInfo.PlaybackType

#### <a name="globalsystemmediatransportcontrolssessionplaybackstatushttpsdocsmicrosoftcomuwpapiwindowsmediacontrolglobalsystemmediatransportcontrolssessionplaybackstatus"></a>[GlobalSystemMediaTransportControlsSessionPlaybackStatus](https://docs.microsoft.com/uwp/api/windows.media.control.globalsystemmediatransportcontrolssessionplaybackstatus)

GlobalSystemMediaTransportControlsSessionPlaybackStatus

#### <a name="globalsystemmediatransportcontrolssessiontimelinepropertieshttpsdocsmicrosoftcomuwpapiwindowsmediacontrolglobalsystemmediatransportcontrolssessiontimelineproperties"></a>[GlobalSystemMediaTransportControlsSessionTimelineProperties](https://docs.microsoft.com/uwp/api/windows.media.control.globalsystemmediatransportcontrolssessiontimelineproperties)

GlobalSystemMediaTransportControlsSessionTimelineProperties <br> GlobalSystemMediaTransportControlsSessionTimelineProperties.EndTime <br> GlobalSystemMediaTransportControlsSessionTimelineProperties.LastUpdatedTime <br> GlobalSystemMediaTransportControlsSessionTimelineProperties.MaxSeekTime <br> GlobalSystemMediaTransportControlsSessionTimelineProperties.MinSeekTime <br> GlobalSystemMediaTransportControlsSessionTimelineProperties.Position <br> GlobalSystemMediaTransportControlsSessionTimelineProperties.StartTime

#### <a name="mediapropertieschangedeventargshttpsdocsmicrosoftcomuwpapiwindowsmediacontrolmediapropertieschangedeventargs"></a>[MediaPropertiesChangedEventArgs](https://docs.microsoft.com/uwp/api/windows.media.control.mediapropertieschangedeventargs)

MediaPropertiesChangedEventArgs

#### <a name="playbackinfochangedeventargshttpsdocsmicrosoftcomuwpapiwindowsmediacontrolplaybackinfochangedeventargs"></a>[PlaybackInfoChangedEventArgs](https://docs.microsoft.com/uwp/api/windows.media.control.playbackinfochangedeventargs)

PlaybackInfoChangedEventArgs

#### <a name="sessionschangedeventargshttpsdocsmicrosoftcomuwpapiwindowsmediacontrolsessionschangedeventargs"></a>[SessionsChangedEventArgs](https://docs.microsoft.com/uwp/api/windows.media.control.sessionschangedeventargs)

SessionsChangedEventArgs

#### <a name="timelinepropertieschangedeventargshttpsdocsmicrosoftcomuwpapiwindowsmediacontroltimelinepropertieschangedeventargs"></a>[TimelinePropertiesChangedEventArgs](https://docs.microsoft.com/uwp/api/windows.media.control.timelinepropertieschangedeventargs)

TimelinePropertiesChangedEventArgs

### <a name="windowsmediacorehttpsdocsmicrosoftcomuwpapiwindowsmediacore"></a>[Windows.Media.Core](https://docs.microsoft.com/uwp/api/windows.media.core)

#### <a name="mediastreamsamplehttpsdocsmicrosoftcomuwpapiwindowsmediacoremediastreamsample"></a>[MediaStreamSample](https://docs.microsoft.com/uwp/api/windows.media.core.mediastreamsample)

MediaStreamSample.CreateFromDirect3D11Surface <br> MediaStreamSample.Direct3D11Surface

### <a name="windowsmediadevicescorehttpsdocsmicrosoftcomuwpapiwindowsmediadevicescore"></a>[Windows.Media.Devices.Core](https://docs.microsoft.com/uwp/api/windows.media.devices.core)

#### <a name="cameraintrinsicshttpsdocsmicrosoftcomuwpapiwindowsmediadevicescorecameraintrinsics"></a>[CameraIntrinsics](https://docs.microsoft.com/uwp/api/windows.media.devices.core.cameraintrinsics)

CameraIntrinsics。 #ctor

### <a name="windowsmediaimporthttpsdocsmicrosoftcomuwpapiwindowsmediaimport"></a>[Windows.Media.Import](https://docs.microsoft.com/uwp/api/windows.media.import)

#### <a name="photoimportitemhttpsdocsmicrosoftcomuwpapiwindowsmediaimportphotoimportitem"></a>[PhotoImportItem](https://docs.microsoft.com/uwp/api/windows.media.import.photoimportitem)

PhotoImportItem.Path

### <a name="windowsmediamediapropertieshttpsdocsmicrosoftcomuwpapiwindowsmediamediaproperties"></a>[Windows.Media.MediaProperties](https://docs.microsoft.com/uwp/api/windows.media.mediaproperties)

#### <a name="imageencodingpropertieshttpsdocsmicrosoftcomuwpapiwindowsmediamediapropertiesimageencodingproperties"></a>[ImageEncodingProperties](https://docs.microsoft.com/uwp/api/windows.media.mediaproperties.imageencodingproperties)

ImageEncodingProperties.CreateHeif

#### <a name="mediaencodingsubtypeshttpsdocsmicrosoftcomuwpapiwindowsmediamediapropertiesmediaencodingsubtypes"></a>[MediaEncodingSubtypes](https://docs.microsoft.com/uwp/api/windows.media.mediaproperties.mediaencodingsubtypes)

MediaEncodingSubtypes.Heif

### <a name="windowsmediaprotectionplayreadyhttpsdocsmicrosoftcomuwpapiwindowsmediaprotectionplayready"></a>[Windows.Media.Protection.PlayReady](https://docs.microsoft.com/uwp/api/windows.media.protection.playready)

#### <a name="playreadystaticshttpsdocsmicrosoftcomuwpapiwindowsmediaprotectionplayreadyplayreadystatics"></a>[PlayReadyStatics](https://docs.microsoft.com/uwp/api/windows.media.protection.playready.playreadystatics)

PlayReadyStatics.HardwareDRMDisabledAtTime <br> PlayReadyStatics.HardwareDRMDisabledUntilTime <br> PlayReadyStatics.ResetHardwareDRMDisabled

## <a name="windowsnetworking"></a>Windows.Networking

### <a name="windowsnetworkingconnectivityhttpsdocsmicrosoftcomuwpapiwindowsnetworkingconnectivity"></a>[Windows.Networking.Connectivity](https://docs.microsoft.com/uwp/api/windows.networking.connectivity)

#### <a name="connectionprofilehttpsdocsmicrosoftcomuwpapiwindowsnetworkingconnectivityconnectionprofile"></a>[ConnectionProfile](https://docs.microsoft.com/uwp/api/windows.networking.connectivity.connectionprofile)

ConnectionProfile.CanDelete <br> ConnectionProfile.TryDeleteAsync

#### <a name="connectionprofiledeletestatushttpsdocsmicrosoftcomuwpapiwindowsnetworkingconnectivityconnectionprofiledeletestatus"></a>[ConnectionProfileDeleteStatus](https://docs.microsoft.com/uwp/api/windows.networking.connectivity.connectionprofiledeletestatus)

ConnectionProfileDeleteStatus

## <a name="windowsperception"></a>Windows.Perception

### <a name="windowsperceptionspatialpreviewhttpsdocsmicrosoftcomuwpapiwindowsperceptionspatialpreview"></a>[Windows.Perception.Spatial.Preview](https://docs.microsoft.com/uwp/api/windows.perception.spatial.preview)

#### <a name="spatialgraphinteroppreviewhttpsdocsmicrosoftcomuwpapiwindowsperceptionspatialpreviewspatialgraphinteroppreview"></a>[SpatialGraphInteropPreview](https://docs.microsoft.com/uwp/api/windows.perception.spatial.preview.spatialgraphinteroppreview)

SpatialGraphInteropPreview <br> SpatialGraphInteropPreview.CreateCoordinateSystemForNode <br> SpatialGraphInteropPreview.CreateCoordinateSystemForNode <br> SpatialGraphInteropPreview.CreateCoordinateSystemForNode <br> SpatialGraphInteropPreview.CreateLocatorForNode

### <a name="windowsperceptionspatialhttpsdocsmicrosoftcomuwpapiwindowsperceptionspatial"></a>[Windows.Perception.Spatial](https://docs.microsoft.com/uwp/api/windows.perception.spatial)

#### <a name="spatialanchorexporterhttpsdocsmicrosoftcomuwpapiwindowsperceptionspatialspatialanchorexporter"></a>[SpatialAnchorExporter](https://docs.microsoft.com/uwp/api/windows.perception.spatial.spatialanchorexporter)

SpatialAnchorExporter <br> SpatialAnchorExporter.GetAnchorExportSufficiencyAsync <br> SpatialAnchorExporter.GetDefault <br> SpatialAnchorExporter.RequestAccessAsync <br> SpatialAnchorExporter.TryExportAnchorAsync

#### <a name="spatialanchorexportpurposehttpsdocsmicrosoftcomuwpapiwindowsperceptionspatialspatialanchorexportpurpose"></a>[SpatialAnchorExportPurpose](https://docs.microsoft.com/uwp/api/windows.perception.spatial.spatialanchorexportpurpose)

SpatialAnchorExportPurpose

#### <a name="spatialanchorexportsufficiencyhttpsdocsmicrosoftcomuwpapiwindowsperceptionspatialspatialanchorexportsufficiency"></a>[SpatialAnchorExportSufficiency](https://docs.microsoft.com/uwp/api/windows.perception.spatial.spatialanchorexportsufficiency)

SpatialAnchorExportSufficiency <br> SpatialAnchorExportSufficiency.IsMinimallySufficient <br> SpatialAnchorExportSufficiency.RecommendedSufficiencyLevel <br> SpatialAnchorExportSufficiency.SufficiencyLevel

#### <a name="spatiallocationhttpsdocsmicrosoftcomuwpapiwindowsperceptionspatialspatiallocation"></a>[SpatialLocation](https://docs.microsoft.com/uwp/api/windows.perception.spatial.spatiallocation)

SpatialLocation.AbsoluteAngularAccelerationAxisAngle <br> SpatialLocation.AbsoluteAngularVelocityAxisAngle

### <a name="windowsperceptionhttpsdocsmicrosoftcomuwpapiwindowsperception"></a>[Windows.Perception](https://docs.microsoft.com/uwp/api/windows.perception)

#### <a name="perceptiontimestamphttpsdocsmicrosoftcomuwpapiwindowsperceptionperceptiontimestamp"></a>[PerceptionTimestamp](https://docs.microsoft.com/uwp/api/windows.perception.perceptiontimestamp)

PerceptionTimestamp.SystemRelativeTargetTime

#### <a name="perceptiontimestamphelperhttpsdocsmicrosoftcomuwpapiwindowsperceptionperceptiontimestamphelper"></a>[PerceptionTimestampHelper](https://docs.microsoft.com/uwp/api/windows.perception.perceptiontimestamphelper)

PerceptionTimestampHelper.FromSystemRelativeTargetTime

## <a name="windowsservices"></a>Windows.Services

### <a name="windowsservicescortanahttpsdocsmicrosoftcomuwpapiwindowsservicescortana"></a>[Windows.Services.Cortana](https://docs.microsoft.com/uwp/api/windows.services.cortana)

#### <a name="cortanaactionableinsightshttpsdocsmicrosoftcomuwpapiwindowsservicescortanacortanaactionableinsights"></a>[CortanaActionableInsights](https://docs.microsoft.com/uwp/api/windows.services.cortana.cortanaactionableinsights)

CortanaActionableInsights <br> CortanaActionableInsights.GetDefault <br> CortanaActionableInsights.GetForUser <br> CortanaActionableInsights.IsAvailableAsync <br> CortanaActionableInsights.ShowInsightsAsync <br> CortanaActionableInsights.ShowInsightsAsync <br> CortanaActionableInsights.ShowInsightsForImageAsync <br> CortanaActionableInsights.ShowInsightsForImageAsync <br> CortanaActionableInsights.ShowInsightsForTextAsync <br> CortanaActionableInsights.ShowInsightsForTextAsync <br> CortanaActionableInsights.User

#### <a name="cortanaactionableinsightsoptionshttpsdocsmicrosoftcomuwpapiwindowsservicescortanacortanaactionableinsightsoptions"></a>[CortanaActionableInsightsOptions](https://docs.microsoft.com/uwp/api/windows.services.cortana.cortanaactionableinsightsoptions)

CortanaActionableInsightsOptions <br> CortanaActionableInsightsOptions.ContentSourceWebLink <br> CortanaActionableInsightsOptions。 #ctor <br> CortanaActionableInsightsOptions.SurroundingText

### <a name="windowsservicesstorehttpsdocsmicrosoftcomuwpapiwindowsservicesstore"></a>[Windows.Services.Store](https://docs.microsoft.com/uwp/api/windows.services.store)

#### <a name="storeapplicensehttpsdocsmicrosoftcomuwpapiwindowsservicesstorestoreapplicense"></a>[StoreAppLicense](https://docs.microsoft.com/uwp/api/windows.services.store.storeapplicense)

StoreAppLicense.IsDiscLicense

#### <a name="storecontexthttpsdocsmicrosoftcomuwpapiwindowsservicesstorestorecontext"></a>[StoreContext](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext)

StoreContext.RequestRateAndReviewAppAsync <br> StoreContext.SetInstallOrderForAssociatedStoreQueueItemsAsync

#### <a name="storequeueitemhttpsdocsmicrosoftcomuwpapiwindowsservicesstorestorequeueitem"></a>[StoreQueueItem](https://docs.microsoft.com/uwp/api/windows.services.store.storequeueitem)

StoreQueueItem.CancelInstallAsync <br> StoreQueueItem.PauseInstallAsync <br> StoreQueueItem.ResumeInstallAsync

#### <a name="storerateandreviewresulthttpsdocsmicrosoftcomuwpapiwindowsservicesstorestorerateandreviewresult"></a>[StoreRateAndReviewResult](https://docs.microsoft.com/uwp/api/windows.services.store.storerateandreviewresult)

StoreRateAndReviewResult <br> StoreRateAndReviewResult.ExtendedError <br> StoreRateAndReviewResult.ExtendedJsonData <br> StoreRateAndReviewResult.Status <br> StoreRateAndReviewResult.WasUpdated

#### <a name="storerateandreviewstatushttpsdocsmicrosoftcomuwpapiwindowsservicesstorestorerateandreviewstatus"></a>[StoreRateAndReviewStatus](https://docs.microsoft.com/uwp/api/windows.services.store.storerateandreviewstatus)

StoreRateAndReviewStatus

## <a name="windowsstorage"></a>Windows.Storage

### <a name="windowsstorageproviderhttpsdocsmicrosoftcomuwpapiwindowsstorageprovider"></a>[Windows.Storage.Provider](https://docs.microsoft.com/uwp/api/windows.storage.provider)

#### <a name="storageprovidersyncrootinfohttpsdocsmicrosoftcomuwpapiwindowsstorageproviderstorageprovidersyncrootinfo"></a>[StorageProviderSyncRootInfo](https://docs.microsoft.com/uwp/api/windows.storage.provider.storageprovidersyncrootinfo)

StorageProviderSyncRootInfo.ProviderId

## <a name="windowssystem"></a>Windows.System

### <a name="windowssystemimplementationholographichttpsdocsmicrosoftcomuwpapiwindowssystemimplementationholographic"></a>[Windows.System.Implementation.Holographic](https://docs.microsoft.com/uwp/api/windows.system.implementation.holographic)

#### <a name="sysholographicdeploymentprogresshttpsdocsmicrosoftcomuwpapiwindowssystemimplementationholographicsysholographicdeploymentprogress"></a>[SysHolographicDeploymentProgress](https://docs.microsoft.com/uwp/api/windows.system.implementation.holographic.sysholographicdeploymentprogress)

SysHolographicDeploymentProgress

#### <a name="sysholographicdeploymentresulthttpsdocsmicrosoftcomuwpapiwindowssystemimplementationholographicsysholographicdeploymentresult"></a>[SysHolographicDeploymentResult](https://docs.microsoft.com/uwp/api/windows.system.implementation.holographic.sysholographicdeploymentresult)

SysHolographicDeploymentResult <br> SysHolographicDeploymentResult.DeploymentState <br> SysHolographicDeploymentResult.ExtendedError

#### <a name="sysholographicdeploymentstatehttpsdocsmicrosoftcomuwpapiwindowssystemimplementationholographicsysholographicdeploymentstate"></a>[SysHolographicDeploymentState](https://docs.microsoft.com/uwp/api/windows.system.implementation.holographic.sysholographicdeploymentstate)

SysHolographicDeploymentState

#### <a name="sysholographicdisplayhttpsdocsmicrosoftcomuwpapiwindowssystemimplementationholographicsysholographicdisplay"></a>[SysHolographicDisplay](https://docs.microsoft.com/uwp/api/windows.system.implementation.holographic.sysholographicdisplay)

SysHolographicDisplay <br> SysHolographicDisplay.DeviceId <br> SysHolographicDisplay.Display <br> SysHolographicDisplay.ExperienceMode <br> SysHolographicDisplay.LeftViewportParameters <br> SysHolographicDisplay.OutputAdapterId <br> SysHolographicDisplay.RightViewportParameters

#### <a name="sysholographicdisplayexperiencemodehttpsdocsmicrosoftcomuwpapiwindowssystemimplementationholographicsysholographicdisplayexperiencemode"></a>[SysHolographicDisplayExperienceMode](https://docs.microsoft.com/uwp/api/windows.system.implementation.holographic.sysholographicdisplayexperiencemode)

SysHolographicDisplayExperienceMode

#### <a name="sysholographicdisplaywatcherhttpsdocsmicrosoftcomuwpapiwindowssystemimplementationholographicsysholographicdisplaywatcher"></a>[SysHolographicDisplayWatcher](https://docs.microsoft.com/uwp/api/windows.system.implementation.holographic.sysholographicdisplaywatcher)

SysHolographicDisplayWatcher <br> SysHolographicDisplayWatcher.Added <br> SysHolographicDisplayWatcher.EnumerationCompleted <br> SysHolographicDisplayWatcher.Removed <br> SysHolographicDisplayWatcher.Start <br> SysHolographicDisplayWatcher.Status <br> SysHolographicDisplayWatcher.Stop <br> SysHolographicDisplayWatcher.Stopped <br> SysHolographicDisplayWatcher。 #ctor

#### <a name="sysholographicdisplaywatcherstatushttpsdocsmicrosoftcomuwpapiwindowssystemimplementationholographicsysholographicdisplaywatcherstatus"></a>[SysHolographicDisplayWatcherStatus](https://docs.microsoft.com/uwp/api/windows.system.implementation.holographic.sysholographicdisplaywatcherstatus)

SysHolographicDisplayWatcherStatus

#### <a name="sysholographicpreviewmediasourcehttpsdocsmicrosoftcomuwpapiwindowssystemimplementationholographicsysholographicpreviewmediasource"></a>[SysHolographicPreviewMediaSource](https://docs.microsoft.com/uwp/api/windows.system.implementation.holographic.sysholographicpreviewmediasource)

SysHolographicPreviewMediaSource <br> SysHolographicPreviewMediaSource.Create

#### <a name="sysholographicwindowingenvironmenthttpsdocsmicrosoftcomuwpapiwindowssystemimplementationholographicsysholographicwindowingenvironment"></a>[SysHolographicWindowingEnvironment](https://docs.microsoft.com/uwp/api/windows.system.implementation.holographic.sysholographicwindowingenvironment)

SysHolographicWindowingEnvironment <br> SysHolographicWindowingEnvironment.DeployAsync <br> SysHolographicWindowingEnvironment.GetDefault <br> SysHolographicWindowingEnvironment.GetDeploymentStateAsync <br> SysHolographicWindowingEnvironment.IsDeviceSetupComplete <br> SysHolographicWindowingEnvironment.IsLearningExperienceComplete <br> SysHolographicWindowingEnvironment.IsPreviewActive <br> SysHolographicWindowingEnvironment.IsPreviewActiveChanged <br> SysHolographicWindowingEnvironment.IsProtectedContentPresent <br> SysHolographicWindowingEnvironment.IsProtectedContentPresentChanged <br> SysHolographicWindowingEnvironment.IsSpeechPersonalizationSupported <br> SysHolographicWindowingEnvironment.SetIsSpeechPersonalizationEnabledAsync <br> SysHolographicWindowingEnvironment.StartAsync <br> SysHolographicWindowingEnvironment.Status <br> SysHolographicWindowingEnvironment.StatusChanged <br> SysHolographicWindowingEnvironment.StopAsync

#### <a name="sysholographicwindowingenvironmentcomponentkindhttpsdocsmicrosoftcomuwpapiwindowssystemimplementationholographicsysholographicwindowingenvironmentcomponentkind"></a>[SysHolographicWindowingEnvironmentComponentKind](https://docs.microsoft.com/uwp/api/windows.system.implementation.holographic.sysholographicwindowingenvironmentcomponentkind)

SysHolographicWindowingEnvironmentComponentKind

#### <a name="sysholographicwindowingenvironmentcomponentstatehttpsdocsmicrosoftcomuwpapiwindowssystemimplementationholographicsysholographicwindowingenvironmentcomponentstate"></a>[SysHolographicWindowingEnvironmentComponentState](https://docs.microsoft.com/uwp/api/windows.system.implementation.holographic.sysholographicwindowingenvironmentcomponentstate)

SysHolographicWindowingEnvironmentComponentState

#### <a name="sysholographicwindowingenvironmentcomponentstatushttpsdocsmicrosoftcomuwpapiwindowssystemimplementationholographicsysholographicwindowingenvironmentcomponentstatus"></a>[SysHolographicWindowingEnvironmentComponentStatus](https://docs.microsoft.com/uwp/api/windows.system.implementation.holographic.sysholographicwindowingenvironmentcomponentstatus)

SysHolographicWindowingEnvironmentComponentStatus

#### <a name="sysholographicwindowingenvironmentstatehttpsdocsmicrosoftcomuwpapiwindowssystemimplementationholographicsysholographicwindowingenvironmentstate"></a>[SysHolographicWindowingEnvironmentState](https://docs.microsoft.com/uwp/api/windows.system.implementation.holographic.sysholographicwindowingenvironmentstate)

SysHolographicWindowingEnvironmentState

#### <a name="sysholographicwindowingenvironmentstatushttpsdocsmicrosoftcomuwpapiwindowssystemimplementationholographicsysholographicwindowingenvironmentstatus"></a>[SysHolographicWindowingEnvironmentStatus](https://docs.microsoft.com/uwp/api/windows.system.implementation.holographic.sysholographicwindowingenvironmentstatus)

SysHolographicWindowingEnvironmentStatus <br> SysHolographicWindowingEnvironmentStatus.ComponentStatuses <br> SysHolographicWindowingEnvironmentStatus.State

#### <a name="sysspatialinputdevicehttpsdocsmicrosoftcomuwpapiwindowssystemimplementationholographicsysspatialinputdevice"></a>[SysSpatialInputDevice](https://docs.microsoft.com/uwp/api/windows.system.implementation.holographic.sysspatialinputdevice)

SysSpatialInputDevice <br> SysSpatialInputDevice.Handedness <br> SysSpatialInputDevice.HasPositionalTracking <br> SysSpatialInputDevice.TryGetBatteryReport

#### <a name="sysspatialinputdevicewatcherhttpsdocsmicrosoftcomuwpapiwindowssystemimplementationholographicsysspatialinputdevicewatcher"></a>[SysSpatialInputDeviceWatcher](https://docs.microsoft.com/uwp/api/windows.system.implementation.holographic.sysspatialinputdevicewatcher)

SysSpatialInputDeviceWatcher <br> SysSpatialInputDeviceWatcher.Added <br> SysSpatialInputDeviceWatcher.EnumerationCompleted <br> SysSpatialInputDeviceWatcher.Removed <br> SysSpatialInputDeviceWatcher.Start <br> SysSpatialInputDeviceWatcher.Status <br> SysSpatialInputDeviceWatcher.Stop <br> SysSpatialInputDeviceWatcher.Stopped <br> SysSpatialInputDeviceWatcher。 #ctor <br> SysSpatialInputDeviceWatcher.Updated

#### <a name="sysspatialinputdevicewatcherstatushttpsdocsmicrosoftcomuwpapiwindowssystemimplementationholographicsysspatialinputdevicewatcherstatus"></a>[SysSpatialInputDeviceWatcherStatus](https://docs.microsoft.com/uwp/api/windows.system.implementation.holographic.sysspatialinputdevicewatcherstatus)

SysSpatialInputDeviceWatcherStatus

#### <a name="sysspatiallocatorhttpsdocsmicrosoftcomuwpapiwindowssystemimplementationholographicsysspatiallocator"></a>[SysSpatialLocator](https://docs.microsoft.com/uwp/api/windows.system.implementation.holographic.sysspatiallocator)

SysSpatialLocator <br> SysSpatialLocator.GetFloorLocator

#### <a name="sysspatialstageboundarydispositionhttpsdocsmicrosoftcomuwpapiwindowssystemimplementationholographicsysspatialstageboundarydisposition"></a>[SysSpatialStageBoundaryDisposition](https://docs.microsoft.com/uwp/api/windows.system.implementation.holographic.sysspatialstageboundarydisposition)

SysSpatialStageBoundaryDisposition

#### <a name="sysspatialstagemanagerhttpsdocsmicrosoftcomuwpapiwindowssystemimplementationholographicsysspatialstagemanager"></a>[SysSpatialStageManager](https://docs.microsoft.com/uwp/api/windows.system.implementation.holographic.sysspatialstagemanager)

SysSpatialStageManager <br> SysSpatialStageManager.DoesAnyStageHaveBoundariesAsync <br> SysSpatialStageManager.GetBoundaryDisposition <br> SysSpatialStageManager.SetAndSaveNewStageAsync <br> SysSpatialStageManager.SetBoundaryEnabled <br> SysSpatialStageManager。 #ctor <br> SysSpatialStageManager.UpdateStageAnchorAsync

### <a name="windowssystempreviewhttpsdocsmicrosoftcomuwpapiwindowssystempreview"></a>[Windows.System.Preview](https://docs.microsoft.com/uwp/api/windows.system.preview)

#### <a name="hingestatehttpsdocsmicrosoftcomuwpapiwindowssystempreviewhingestate"></a>[HingeState](https://docs.microsoft.com/uwp/api/windows.system.preview.hingestate)

HingeState

#### <a name="twopanelhingeddeviceposturepreviewhttpsdocsmicrosoftcomuwpapiwindowssystempreviewtwopanelhingeddeviceposturepreview"></a>[TwoPanelHingedDevicePosturePreview](https://docs.microsoft.com/uwp/api/windows.system.preview.twopanelhingeddeviceposturepreview)

TwoPanelHingedDevicePosturePreview <br> TwoPanelHingedDevicePosturePreview.GetCurrentPostureAsync <br> TwoPanelHingedDevicePosturePreview.GetDefaultAsync <br> TwoPanelHingedDevicePosturePreview.PostureChanged

#### <a name="twopanelhingeddeviceposturepreviewreadinghttpsdocsmicrosoftcomuwpapiwindowssystempreviewtwopanelhingeddeviceposturepreviewreading"></a>[TwoPanelHingedDevicePosturePreviewReading](https://docs.microsoft.com/uwp/api/windows.system.preview.twopanelhingeddeviceposturepreviewreading)

TwoPanelHingedDevicePosturePreviewReading <br> TwoPanelHingedDevicePosturePreviewReading.HingeState <br> TwoPanelHingedDevicePosturePreviewReading.Panel1Id <br> TwoPanelHingedDevicePosturePreviewReading.Panel1Orientation <br> TwoPanelHingedDevicePosturePreviewReading.Panel2Id <br> TwoPanelHingedDevicePosturePreviewReading.Panel2Orientation <br> TwoPanelHingedDevicePosturePreviewReading.Timestamp

#### <a name="twopanelhingeddeviceposturepreviewreadingchangedeventargshttpsdocsmicrosoftcomuwpapiwindowssystempreviewtwopanelhingeddeviceposturepreviewreadingchangedeventargs"></a>[TwoPanelHingedDevicePosturePreviewReadingChangedEventArgs](https://docs.microsoft.com/uwp/api/windows.system.preview.twopanelhingeddeviceposturepreviewreadingchangedeventargs)

TwoPanelHingedDevicePosturePreviewReadingChangedEventArgs <br> TwoPanelHingedDevicePosturePreviewReadingChangedEventArgs.Reading

### <a name="windowssystemprofilesystemmanufacturershttpsdocsmicrosoftcomuwpapiwindowssystemprofilesystemmanufacturers"></a>[Windows.System.Profile.SystemManufacturers](https://docs.microsoft.com/uwp/api/windows.system.profile.systemmanufacturers)

#### <a name="systemsupportdeviceinfohttpsdocsmicrosoftcomuwpapiwindowssystemprofilesystemmanufacturerssystemsupportdeviceinfo"></a>[SystemSupportDeviceInfo](https://docs.microsoft.com/uwp/api/windows.system.profile.systemmanufacturers.systemsupportdeviceinfo)

SystemSupportDeviceInfo <br> SystemSupportDeviceInfo.FriendlyName <br> SystemSupportDeviceInfo.OperatingSystem <br> SystemSupportDeviceInfo.SystemFirmwareVersion <br> SystemSupportDeviceInfo.SystemHardwareVersion <br> SystemSupportDeviceInfo.SystemManufacturer <br> SystemSupportDeviceInfo.SystemProductName <br> SystemSupportDeviceInfo.SystemSku

#### <a name="systemsupportinfohttpsdocsmicrosoftcomuwpapiwindowssystemprofilesystemmanufacturerssystemsupportinfo"></a>[SystemSupportInfo](https://docs.microsoft.com/uwp/api/windows.system.profile.systemmanufacturers.systemsupportinfo)

SystemSupportInfo.LocalDeviceInfo

### <a name="windowssystemprofilehttpsdocsmicrosoftcomuwpapiwindowssystemprofile"></a>[Windows.System.Profile](https://docs.microsoft.com/uwp/api/windows.system.profile)

#### <a name="systemoutofboxexperiencestatehttpsdocsmicrosoftcomuwpapiwindowssystemprofilesystemoutofboxexperiencestate"></a>[SystemOutOfBoxExperienceState](https://docs.microsoft.com/uwp/api/windows.system.profile.systemoutofboxexperiencestate)

SystemOutOfBoxExperienceState

#### <a name="systemsetupinfohttpsdocsmicrosoftcomuwpapiwindowssystemprofilesystemsetupinfo"></a>[SystemSetupInfo](https://docs.microsoft.com/uwp/api/windows.system.profile.systemsetupinfo)

SystemSetupInfo <br> SystemSetupInfo.OutOfBoxExperienceState <br> SystemSetupInfo.OutOfBoxExperienceStateChanged

#### <a name="windowsintegritypolicyhttpsdocsmicrosoftcomuwpapiwindowssystemprofilewindowsintegritypolicy"></a>[WindowsIntegrityPolicy](https://docs.microsoft.com/uwp/api/windows.system.profile.windowsintegritypolicy)

WindowsIntegrityPolicy <br> WindowsIntegrityPolicy.CanDisable <br> WindowsIntegrityPolicy.IsDisableSupported <br> WindowsIntegrityPolicy.IsEnabled <br> WindowsIntegrityPolicy.IsEnabledForTrial <br> WindowsIntegrityPolicy.PolicyChanged

### <a name="windowssystemremotesystemshttpsdocsmicrosoftcomuwpapiwindowssystemremotesystems"></a>[Windows.System.RemoteSystems](https://docs.microsoft.com/uwp/api/windows.system.remotesystems)

#### <a name="remotesystemhttpsdocsmicrosoftcomuwpapiwindowssystemremotesystemsremotesystem"></a>[RemoteSystem](https://docs.microsoft.com/uwp/api/windows.system.remotesystems.remotesystem)

RemoteSystem.Apps

#### <a name="remotesystemapphttpsdocsmicrosoftcomuwpapiwindowssystemremotesystemsremotesystemapp"></a>[RemoteSystemApp](https://docs.microsoft.com/uwp/api/windows.system.remotesystems.remotesystemapp)

RemoteSystemApp <br> RemoteSystemApp.Attributes <br> RemoteSystemApp.DisplayName <br> RemoteSystemApp.Id <br> RemoteSystemApp.IsAvailableByProximity <br> RemoteSystemApp.IsAvailableBySpatialProximity

#### <a name="remotesystemappregistrationhttpsdocsmicrosoftcomuwpapiwindowssystemremotesystemsremotesystemappregistration"></a>[RemoteSystemAppRegistration](https://docs.microsoft.com/uwp/api/windows.system.remotesystems.remotesystemappregistration)

RemoteSystemAppRegistration <br> RemoteSystemAppRegistration.Attributes <br> RemoteSystemAppRegistration.GetDefault <br> RemoteSystemAppRegistration.GetForUser <br> RemoteSystemAppRegistration.SaveAsync <br> RemoteSystemAppRegistration.User

#### <a name="remotesystemconnectioninfohttpsdocsmicrosoftcomuwpapiwindowssystemremotesystemsremotesystemconnectioninfo"></a>[RemoteSystemConnectionInfo](https://docs.microsoft.com/uwp/api/windows.system.remotesystems.remotesystemconnectioninfo)

RemoteSystemConnectionInfo <br> RemoteSystemConnectionInfo.IsProximal <br> RemoteSystemConnectionInfo.TryCreateFromAppServiceConnection

#### <a name="remotesystemconnectionrequesthttpsdocsmicrosoftcomuwpapiwindowssystemremotesystemsremotesystemconnectionrequest"></a>[RemoteSystemConnectionRequest](https://docs.microsoft.com/uwp/api/windows.system.remotesystems.remotesystemconnectionrequest)

RemoteSystemConnectionRequest.CreateForApp <br> RemoteSystemConnectionRequest.RemoteSystemApp

#### <a name="remotesystemwebaccountfilterhttpsdocsmicrosoftcomuwpapiwindowssystemremotesystemsremotesystemwebaccountfilter"></a>[RemoteSystemWebAccountFilter](https://docs.microsoft.com/uwp/api/windows.system.remotesystems.remotesystemwebaccountfilter)

RemoteSystemWebAccountFilter <br> RemoteSystemWebAccountFilter.Account <br> RemoteSystemWebAccountFilter。 #ctor

### <a name="windowssystemupdatehttpsdocsmicrosoftcomuwpapiwindowssystemupdate"></a>[Windows.System.Update](https://docs.microsoft.com/uwp/api/windows.system.update)

#### <a name="systemupdateattentionrequiredreasonhttpsdocsmicrosoftcomuwpapiwindowssystemupdatesystemupdateattentionrequiredreason"></a>[SystemUpdateAttentionRequiredReason](https://docs.microsoft.com/uwp/api/windows.system.update.systemupdateattentionrequiredreason)

SystemUpdateAttentionRequiredReason

#### <a name="systemupdateitemhttpsdocsmicrosoftcomuwpapiwindowssystemupdatesystemupdateitem"></a>[SystemUpdateItem](https://docs.microsoft.com/uwp/api/windows.system.update.systemupdateitem)

SystemUpdateItem <br> SystemUpdateItem.Description <br> SystemUpdateItem.DownloadProgress <br> SystemUpdateItem.ExtendedError <br> SystemUpdateItem.Id <br> SystemUpdateItem.InstallProgress <br> SystemUpdateItem.Revision <br> SystemUpdateItem.State <br> SystemUpdateItem.Title

#### <a name="systemupdateitemstatehttpsdocsmicrosoftcomuwpapiwindowssystemupdatesystemupdateitemstate"></a>[SystemUpdateItemState](https://docs.microsoft.com/uwp/api/windows.system.update.systemupdateitemstate)

SystemUpdateItemState

#### <a name="systemupdatelasterrorinfohttpsdocsmicrosoftcomuwpapiwindowssystemupdatesystemupdatelasterrorinfo"></a>[SystemUpdateLastErrorInfo](https://docs.microsoft.com/uwp/api/windows.system.update.systemupdatelasterrorinfo)

SystemUpdateLastErrorInfo <br> SystemUpdateLastErrorInfo.ExtendedError <br> SystemUpdateLastErrorInfo.IsInteractive <br> SystemUpdateLastErrorInfo.State

#### <a name="systemupdatemanagerhttpsdocsmicrosoftcomuwpapiwindowssystemupdatesystemupdatemanager"></a>[SystemUpdateManager](https://docs.microsoft.com/uwp/api/windows.system.update.systemupdatemanager)

SystemUpdateManager <br> SystemUpdateManager.AttentionRequiredReason <br> SystemUpdateManager.BlockAutomaticRebootAsync <br> SystemUpdateManager.DownloadProgress <br> SystemUpdateManager.ExtendedError <br> SystemUpdateManager.GetAutomaticRebootBlockIds <br> SystemUpdateManager.GetFlightRing <br> SystemUpdateManager.GetUpdateItems <br> SystemUpdateManager.InstallProgress <br> SystemUpdateManager.IsSupported <br> SystemUpdateManager.LastErrorInfo <br> SystemUpdateManager.LastUpdateCheckTime <br> SystemUpdateManager.LastUpdateInstallTime <br> SystemUpdateManager.RebootToCompleteInstall <br> SystemUpdateManager.SetFlightRing <br> SystemUpdateManager.StartCancelUpdates <br> SystemUpdateManager.StartInstall <br> SystemUpdateManager.State <br> SystemUpdateManager.StateChanged <br> SystemUpdateManager.TrySetUserActiveHours <br> SystemUpdateManager.UnblockAutomaticRebootAsync <br> SystemUpdateManager.UserActiveHoursEnd <br> SystemUpdateManager.UserActiveHoursMax <br> SystemUpdateManager.UserActiveHoursStart

#### <a name="systemupdatemanagerstatehttpsdocsmicrosoftcomuwpapiwindowssystemupdatesystemupdatemanagerstate"></a>[SystemUpdateManagerState](https://docs.microsoft.com/uwp/api/windows.system.update.systemupdatemanagerstate)

SystemUpdateManagerState

#### <a name="systemupdatestartinstallactionhttpsdocsmicrosoftcomuwpapiwindowssystemupdatesystemupdatestartinstallaction"></a>[SystemUpdateStartInstallAction](https://docs.microsoft.com/uwp/api/windows.system.update.systemupdatestartinstallaction)

SystemUpdateStartInstallAction

### <a name="windowssystemuserprofilehttpsdocsmicrosoftcomuwpapiwindowssystemuserprofile"></a>[Windows.System.UserProfile](https://docs.microsoft.com/uwp/api/windows.system.userprofile)

#### <a name="assignedaccesssettingshttpsdocsmicrosoftcomuwpapiwindowssystemuserprofileassignedaccesssettings"></a>[AssignedAccessSettings](https://docs.microsoft.com/uwp/api/windows.system.userprofile.assignedaccesssettings)

AssignedAccessSettings <br> AssignedAccessSettings.GetDefault <br> AssignedAccessSettings.GetForUser <br> AssignedAccessSettings.IsEnabled <br> AssignedAccessSettings.IsSingleAppKioskMode <br> AssignedAccessSettings.User

### <a name="windowssystemhttpsdocsmicrosoftcomuwpapiwindowssystem"></a>[Windows.System](https://docs.microsoft.com/uwp/api/windows.system)

#### <a name="appurihandlerhosthttpsdocsmicrosoftcomuwpapiwindowssystemappurihandlerhost"></a>[AppUriHandlerHost](https://docs.microsoft.com/uwp/api/windows.system.appurihandlerhost)

AppUriHandlerHost <br> AppUriHandlerHost。 #ctor <br> AppUriHandlerHost。 #ctor <br> AppUriHandlerHost.Name

#### <a name="appurihandlerregistrationhttpsdocsmicrosoftcomuwpapiwindowssystemappurihandlerregistration"></a>[AppUriHandlerRegistration](https://docs.microsoft.com/uwp/api/windows.system.appurihandlerregistration)

AppUriHandlerRegistration <br> AppUriHandlerRegistration.GetAppAddedHostsAsync <br> AppUriHandlerRegistration.Name <br> AppUriHandlerRegistration.SetAppAddedHostsAsync <br> AppUriHandlerRegistration.User

#### <a name="appurihandlerregistrationmanagerhttpsdocsmicrosoftcomuwpapiwindowssystemappurihandlerregistrationmanager"></a>[AppUriHandlerRegistrationManager](https://docs.microsoft.com/uwp/api/windows.system.appurihandlerregistrationmanager)

AppUriHandlerRegistrationManager <br> AppUriHandlerRegistrationManager.GetDefault <br> AppUriHandlerRegistrationManager.GetForUser <br> AppUriHandlerRegistrationManager.TryGetRegistration <br> AppUriHandlerRegistrationManager.User

#### <a name="launcherhttpsdocsmicrosoftcomuwpapiwindowssystemlauncher"></a>[ランチャー](https://docs.microsoft.com/uwp/api/windows.system.launcher)

Launcher.LaunchFolderPathAsync <br> Launcher.LaunchFolderPathAsync <br> Launcher.LaunchFolderPathForUserAsync <br> Launcher.LaunchFolderPathForUserAsync

## <a name="windowsui"></a>Windows.UI

### <a name="windowsuiaccessibilityhttpsdocsmicrosoftcomuwpapiwindowsuiaccessibility"></a>[Windows.UI.Accessibility](https://docs.microsoft.com/uwp/api/windows.ui.accessibility)

#### <a name="screenreaderpositionchangedeventargshttpsdocsmicrosoftcomuwpapiwindowsuiaccessibilityscreenreaderpositionchangedeventargs"></a>[ScreenReaderPositionChangedEventArgs](https://docs.microsoft.com/uwp/api/windows.ui.accessibility.screenreaderpositionchangedeventargs)

ScreenReaderPositionChangedEventArgs <br> ScreenReaderPositionChangedEventArgs.IsReadingText <br> ScreenReaderPositionChangedEventArgs.ScreenPositionInRawPixels

#### <a name="screenreaderservicehttpsdocsmicrosoftcomuwpapiwindowsuiaccessibilityscreenreaderservice"></a>[ScreenReaderService](https://docs.microsoft.com/uwp/api/windows.ui.accessibility.screenreaderservice)

ScreenReaderService <br> ScreenReaderService.CurrentScreenReaderPosition <br> ScreenReaderService.ScreenReaderPositionChanged <br> ScreenReaderService。 #ctor

### <a name="windowsuicompositioninteractionshttpsdocsmicrosoftcomuwpapiwindowsuicompositioninteractions"></a>[Windows.UI.Composition.Interactions](https://docs.microsoft.com/uwp/api/windows.ui.composition.interactions)

#### <a name="interactionsourceconfigurationhttpsdocsmicrosoftcomuwpapiwindowsuicompositioninteractionsinteractionsourceconfiguration"></a>[InteractionSourceConfiguration](https://docs.microsoft.com/uwp/api/windows.ui.composition.interactions.interactionsourceconfiguration)

InteractionSourceConfiguration <br> InteractionSourceConfiguration.PositionXSourceMode <br> InteractionSourceConfiguration.PositionYSourceMode <br> InteractionSourceConfiguration.ScaleSourceMode

#### <a name="interactionsourceredirectionmodehttpsdocsmicrosoftcomuwpapiwindowsuicompositioninteractionsinteractionsourceredirectionmode"></a>[InteractionSourceRedirectionMode](https://docs.microsoft.com/uwp/api/windows.ui.composition.interactions.interactionsourceredirectionmode)

InteractionSourceRedirectionMode

#### <a name="interactiontrackerhttpsdocsmicrosoftcomuwpapiwindowsuicompositioninteractionsinteractiontracker"></a>[InteractionTracker](https://docs.microsoft.com/uwp/api/windows.ui.composition.interactions.interactiontracker)

InteractionTracker.IsInertiaFromImpulse <br> InteractionTracker.TryUpdatePosition <br> InteractionTracker.TryUpdatePositionBy

#### <a name="interactiontrackerclampingoptionhttpsdocsmicrosoftcomuwpapiwindowsuicompositioninteractionsinteractiontrackerclampingoption"></a>[InteractionTrackerClampingOption](https://docs.microsoft.com/uwp/api/windows.ui.composition.interactions.interactiontrackerclampingoption)

InteractionTrackerClampingOption

#### <a name="interactiontrackerinertiastateenteredargshttpsdocsmicrosoftcomuwpapiwindowsuicompositioninteractionsinteractiontrackerinertiastateenteredargs"></a>[InteractionTrackerInertiaStateEnteredArgs](https://docs.microsoft.com/uwp/api/windows.ui.composition.interactions.interactiontrackerinertiastateenteredargs)

InteractionTrackerInertiaStateEnteredArgs.IsInertiaFromImpulse

#### <a name="visualinteractionsourcehttpsdocsmicrosoftcomuwpapiwindowsuicompositioninteractionsvisualinteractionsource"></a>[VisualInteractionSource](https://docs.microsoft.com/uwp/api/windows.ui.composition.interactions.visualinteractionsource)

VisualInteractionSource.PointerWheelConfig

### <a name="windowsuicompositionhttpsdocsmicrosoftcomuwpapiwindowsuicomposition"></a>[Windows.UI.Composition](https://docs.microsoft.com/uwp/api/windows.ui.composition)

#### <a name="animationpropertyaccessmodehttpsdocsmicrosoftcomuwpapiwindowsuicompositionanimationpropertyaccessmode"></a>[AnimationPropertyAccessMode](https://docs.microsoft.com/uwp/api/windows.ui.composition.animationpropertyaccessmode)

AnimationPropertyAccessMode

#### <a name="animationpropertyinfohttpsdocsmicrosoftcomuwpapiwindowsuicompositionanimationpropertyinfo"></a>[AnimationPropertyInfo](https://docs.microsoft.com/uwp/api/windows.ui.composition.animationpropertyinfo)

AnimationPropertyInfo <br> AnimationPropertyInfo.AccessMode

#### <a name="booleankeyframeanimationhttpsdocsmicrosoftcomuwpapiwindowsuicompositionbooleankeyframeanimation"></a>[BooleanKeyFrameAnimation](https://docs.microsoft.com/uwp/api/windows.ui.composition.booleankeyframeanimation)

BooleanKeyFrameAnimation <br> BooleanKeyFrameAnimation.InsertKeyFrame

#### <a name="compositionanimationhttpsdocsmicrosoftcomuwpapiwindowsuicompositioncompositionanimation"></a>[CompositionAnimation](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionanimation)

CompositionAnimation.SetExpressionReferenceParameter

#### <a name="compositiongeometriccliphttpsdocsmicrosoftcomuwpapiwindowsuicompositioncompositiongeometricclip"></a>[CompositionGeometricClip](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositiongeometricclip)

CompositionGeometricClip <br> CompositionGeometricClip.Geometry <br> CompositionGeometricClip.ViewBox

#### <a name="compositiongradientbrushhttpsdocsmicrosoftcomuwpapiwindowsuicompositioncompositiongradientbrush"></a>[CompositionGradientBrush](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositiongradientbrush)

CompositionGradientBrush.MappingMode

#### <a name="compositionmappingmodehttpsdocsmicrosoftcomuwpapiwindowsuicompositioncompositionmappingmode"></a>[CompositionMappingMode](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionmappingmode)

CompositionMappingMode

#### <a name="compositionobjecthttpsdocsmicrosoftcomuwpapiwindowsuicompositioncompositionobject"></a>[CompositionObject](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionobject)

CompositionObject.PopulatePropertyInfo <br> CompositionObject.StartAnimationGroupWithIAnimationObject <br> CompositionObject.StartAnimationWithIAnimationObject

#### <a name="compositorhttpsdocsmicrosoftcomuwpapiwindowsuicompositioncompositor"></a>[コンポジター](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositor)

Compositor.CreateBooleanKeyFrameAnimation <br> Compositor.CreateGeometricClip <br> Compositor.CreateGeometricClip <br> Compositor.CreateRedirectVisual <br> Compositor.CreateRedirectVisual

#### <a name="ianimationobjecthttpsdocsmicrosoftcomuwpapiwindowsuicompositionianimationobject"></a>[IAnimationObject](https://docs.microsoft.com/uwp/api/windows.ui.composition.ianimationobject)

IAnimationObject <br> IAnimationObject.PopulatePropertyInfo

#### <a name="redirectvisualhttpsdocsmicrosoftcomuwpapiwindowsuicompositionredirectvisual"></a>[RedirectVisual](https://docs.microsoft.com/uwp/api/windows.ui.composition.redirectvisual)

RedirectVisual <br> RedirectVisual.Source

### <a name="windowsuiinputinkingpreviewhttpsdocsmicrosoftcomuwpapiwindowsuiinputinkingpreview"></a>[Windows.UI.Input.Inking.Preview](https://docs.microsoft.com/uwp/api/windows.ui.input.inking.preview)

#### <a name="palmrejectiondelayzonepreviewhttpsdocsmicrosoftcomuwpapiwindowsuiinputinkingpreviewpalmrejectiondelayzonepreview"></a>[PalmRejectionDelayZonePreview](https://docs.microsoft.com/uwp/api/windows.ui.input.inking.preview.palmrejectiondelayzonepreview)

PalmRejectionDelayZonePreview <br> PalmRejectionDelayZonePreview.Close <br> PalmRejectionDelayZonePreview.CreateForVisual <br> PalmRejectionDelayZonePreview.CreateForVisual

### <a name="windowsuiinputinkinghttpsdocsmicrosoftcomuwpapiwindowsuiinputinking"></a>[Windows.UI.Input.Inking](https://docs.microsoft.com/uwp/api/windows.ui.input.inking)

#### <a name="handwritinglineheighthttpsdocsmicrosoftcomuwpapiwindowsuiinputinkinghandwritinglineheight"></a>[HandwritingLineHeight](https://docs.microsoft.com/uwp/api/windows.ui.input.inking.handwritinglineheight)

HandwritingLineHeight

#### <a name="penandinksettingshttpsdocsmicrosoftcomuwpapiwindowsuiinputinkingpenandinksettings"></a>[PenAndInkSettings](https://docs.microsoft.com/uwp/api/windows.ui.input.inking.penandinksettings)

PenAndInkSettings <br> PenAndInkSettings.FontFamilyName <br> PenAndInkSettings.GetDefault <br> PenAndInkSettings.HandwritingLineHeight <br> PenAndInkSettings.IsHandwritingDirectlyIntoTextFieldEnabled <br> PenAndInkSettings.IsTouchHandwritingEnabled <br> PenAndInkSettings.PenHandedness <br> PenAndInkSettings.UserConsentsToHandwritingTelemetryCollection

#### <a name="penhandednesshttpsdocsmicrosoftcomuwpapiwindowsuiinputinkingpenhandedness"></a>[PenHandedness](https://docs.microsoft.com/uwp/api/windows.ui.input.inking.penhandedness)

PenHandedness

### <a name="windowsuinotificationshttpsdocsmicrosoftcomuwpapiwindowsuinotifications"></a>[Windows.UI.Notifications](https://docs.microsoft.com/uwp/api/windows.ui.notifications)

#### <a name="scheduledtoastnotificationshowingeventargshttpsdocsmicrosoftcomuwpapiwindowsuinotificationsscheduledtoastnotificationshowingeventargs"></a>[ScheduledToastNotificationShowingEventArgs](https://docs.microsoft.com/uwp/api/windows.ui.notifications.scheduledtoastnotificationshowingeventargs)

ScheduledToastNotificationShowingEventArgs <br> ScheduledToastNotificationShowingEventArgs.Cancel <br> ScheduledToastNotificationShowingEventArgs.GetDeferral <br> ScheduledToastNotificationShowingEventArgs.ScheduledToastNotification

#### <a name="toastnotifierhttpsdocsmicrosoftcomuwpapiwindowsuinotificationstoastnotifier"></a>[ToastNotifier](https://docs.microsoft.com/uwp/api/windows.ui.notifications.toastnotifier)

ToastNotifier.ScheduledToastNotificationShowing

### <a name="windowsuishellhttpsdocsmicrosoftcomuwpapiwindowsuishell"></a>[Windows.UI.Shell](https://docs.microsoft.com/uwp/api/windows.ui.shell)

#### <a name="securityappkindhttpsdocsmicrosoftcomuwpapiwindowsuishellsecurityappkind"></a>[SecurityAppKind](https://docs.microsoft.com/uwp/api/windows.ui.shell.securityappkind)

SecurityAppKind

#### <a name="securityappmanagerhttpsdocsmicrosoftcomuwpapiwindowsuishellsecurityappmanager"></a>[SecurityAppManager](https://docs.microsoft.com/uwp/api/windows.ui.shell.securityappmanager)

SecurityAppManager <br> SecurityAppManager.Register <br> SecurityAppManager。 #ctor <br> SecurityAppManager.Unregister <br> SecurityAppManager.UpdateState

#### <a name="securityappstatehttpsdocsmicrosoftcomuwpapiwindowsuishellsecurityappstate"></a>[SecurityAppState](https://docs.microsoft.com/uwp/api/windows.ui.shell.securityappstate)

SecurityAppState

#### <a name="securityappsubstatushttpsdocsmicrosoftcomuwpapiwindowsuishellsecurityappsubstatus"></a>[SecurityAppSubstatus](https://docs.microsoft.com/uwp/api/windows.ui.shell.securityappsubstatus)

SecurityAppSubstatus

#### <a name="taskbarmanagerhttpsdocsmicrosoftcomuwpapiwindowsuishelltaskbarmanager"></a>[TaskbarManager](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager)

TaskbarManager.IsSecondaryTilePinnedAsync <br> TaskbarManager.RequestPinSecondaryTileAsync <br> TaskbarManager.TryUnpinSecondaryTileAsync

### <a name="windowsuistartscreenhttpsdocsmicrosoftcomuwpapiwindowsuistartscreen"></a>[Windows.UI.StartScreen](https://docs.microsoft.com/uwp/api/windows.ui.startscreen)

#### <a name="startscreenmanagerhttpsdocsmicrosoftcomuwpapiwindowsuistartscreenstartscreenmanager"></a>[StartScreenManager](https://docs.microsoft.com/uwp/api/windows.ui.startscreen.startscreenmanager)

StartScreenManager.ContainsSecondaryTileAsync <br> StartScreenManager.TryRemoveSecondaryTileAsync

### <a name="windowsuitextcorehttpsdocsmicrosoftcomuwpapiwindowsuitextcore"></a>[Windows.UI.Text.Core](https://docs.microsoft.com/uwp/api/windows.ui.text.core)

#### <a name="coretextlayoutrequesthttpsdocsmicrosoftcomuwpapiwindowsuitextcorecoretextlayoutrequest"></a>[CoreTextLayoutRequest](https://docs.microsoft.com/uwp/api/windows.ui.text.core.coretextlayoutrequest)

CoreTextLayoutRequest.LayoutBoundsVisualPixels

### <a name="windowsuitexthttpsdocsmicrosoftcomuwpapiwindowsuitext"></a>[Windows.UI.Text](https://docs.microsoft.com/uwp/api/windows.ui.text)

#### <a name="richedittextdocumenthttpsdocsmicrosoftcomuwpapiwindowsuitextrichedittextdocument"></a>[RichEditTextDocument](https://docs.microsoft.com/uwp/api/windows.ui.text.richedittextdocument)

RichEditTextDocument.ClearUndoRedoHistory

### <a name="windowsuiviewmanagementcorehttpsdocsmicrosoftcomuwpapiwindowsuiviewmanagementcore"></a>[Windows.UI.ViewManagement.Core](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.core)

#### <a name="coreinputviewhttpsdocsmicrosoftcomuwpapiwindowsuiviewmanagementcorecoreinputview"></a>[CoreInputView](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.core.coreinputview)

CoreInputView.TryHide <br> CoreInputView.TryShow <br> CoreInputView.TryShow

#### <a name="coreinputviewkindhttpsdocsmicrosoftcomuwpapiwindowsuiviewmanagementcorecoreinputviewkind"></a>[CoreInputViewKind](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.core.coreinputviewkind)

CoreInputViewKind

### <a name="windowsuiwebuihttpsdocsmicrosoftcomuwpapiwindowsuiwebui"></a>[Windows.UI.WebUI](https://docs.microsoft.com/uwp/api/windows.ui.webui)

#### <a name="backgroundactivatedeventargshttpsdocsmicrosoftcomuwpapiwindowsuiwebuibackgroundactivatedeventargs"></a>[BackgroundActivatedEventArgs](https://docs.microsoft.com/uwp/api/windows.ui.webui.backgroundactivatedeventargs)

BackgroundActivatedEventArgs <br> BackgroundActivatedEventArgs.TaskInstance

#### <a name="backgroundactivatedeventhandlerhttpsdocsmicrosoftcomuwpapiwindowsuiwebuibackgroundactivatedeventhandler"></a>[BackgroundActivatedEventHandler](https://docs.microsoft.com/uwp/api/windows.ui.webui.backgroundactivatedeventhandler)

BackgroundActivatedEventHandler

#### <a name="newwebuiviewcreatedeventargshttpsdocsmicrosoftcomuwpapiwindowsuiwebuinewwebuiviewcreatedeventargs"></a>[NewWebUIViewCreatedEventArgs](https://docs.microsoft.com/uwp/api/windows.ui.webui.newwebuiviewcreatedeventargs)

NewWebUIViewCreatedEventArgs <br> NewWebUIViewCreatedEventArgs.ActivatedEventArgs <br> NewWebUIViewCreatedEventArgs.GetDeferral <br> NewWebUIViewCreatedEventArgs.HasPendingNavigate <br> NewWebUIViewCreatedEventArgs.WebUIView

#### <a name="webuiapplicationhttpsdocsmicrosoftcomuwpapiwindowsuiwebuiwebuiapplication"></a>[WebUIApplication](https://docs.microsoft.com/uwp/api/windows.ui.webui.webuiapplication)

WebUIApplication.BackgroundActivated <br> WebUIApplication.NewWebUIViewCreated

#### <a name="webuiviewhttpsdocsmicrosoftcomuwpapiwindowsuiwebuiwebuiview"></a>[WebUIView](https://docs.microsoft.com/uwp/api/windows.ui.webui.webuiview)

WebUIView <br> WebUIView.Activated <br> WebUIView.AddInitializeScript <br> WebUIView.ApplicationViewId <br> WebUIView.BuildLocalStreamUri <br> WebUIView.CanGoBack <br> WebUIView.CanGoForward <br> WebUIView.CapturePreviewToStreamAsync <br> WebUIView.CaptureSelectedContentToDataPackageAsync <br> WebUIView.Closed <br> WebUIView.ContainsFullScreenElement <br> WebUIView.ContainsFullScreenElementChanged <br> WebUIView.ContentLoading <br> WebUIView.CreateAsync <br> WebUIView.CreateAsync <br> WebUIView.DefaultBackgroundColor <br> WebUIView.DeferredPermissionRequests <br> WebUIView.DocumentTitle <br> WebUIView.DOMContentLoaded <br> WebUIView.FrameContentLoading <br> WebUIView.FrameDOMContentLoaded <br> WebUIView.FrameNavigationCompleted <br> WebUIView.FrameNavigationStarting <br> WebUIView.GetDeferredPermissionRequestById <br> WebUIView.GoBack <br> WebUIView.GoForward <br> WebUIView.IgnoreApplicationContentUriRulesNavigationRestrictions <br> WebUIView.InvokeScriptAsync <br> WebUIView.LongRunningScriptDetected <br> WebUIView.Navigate <br> WebUIView.NavigateToLocalStreamUri <br> WebUIView.NavigateToString <br> WebUIView.NavigateWithHttpRequestMessage <br> WebUIView.NavigationCompleted <br> WebUIView.NavigationStarting <br> WebUIView.NewWindowRequested <br> WebUIView.PermissionRequested <br> WebUIView.Refresh <br> WebUIView.ScriptNotify <br> WebUIView.Settings <br> WebUIView.Source <br> WebUIView.Stop <br> WebUIView.UnsafeContentWarningDisplaying <br> WebUIView.UnsupportedUriSchemeIdentified <br> WebUIView.UnviewableContentIdentified <br> WebUIView.WebResourceRequested

### <a name="windowsuixamlautomationpeershttpsdocsmicrosoftcomuwpapiwindowsuixamlautomationpeers"></a>[Windows.UI.Xaml.Automation.Peers](https://docs.microsoft.com/uwp/api/windows.ui.xaml.automation.peers)

#### <a name="appbarbuttonautomationpeerhttpsdocsmicrosoftcomuwpapiwindowsuixamlautomationpeersappbarbuttonautomationpeer"></a>[AppBarButtonAutomationPeer](https://docs.microsoft.com/uwp/api/windows.ui.xaml.automation.peers.appbarbuttonautomationpeer)

AppBarButtonAutomationPeer.Collapse <br> AppBarButtonAutomationPeer.Expand <br> AppBarButtonAutomationPeer.ExpandCollapseState

#### <a name="automationpeerhttpsdocsmicrosoftcomuwpapiwindowsuixamlautomationpeersautomationpeer"></a>[AutomationPeer](https://docs.microsoft.com/uwp/api/windows.ui.xaml.automation.peers.automationpeer)

AutomationPeer.IsDialog <br> AutomationPeer.IsDialogCore

#### <a name="menubarautomationpeerhttpsdocsmicrosoftcomuwpapiwindowsuixamlautomationpeersmenubarautomationpeer"></a>[MenuBarAutomationPeer](https://docs.microsoft.com/uwp/api/windows.ui.xaml.automation.peers.menubarautomationpeer)

MenuBarAutomationPeer <br> MenuBarAutomationPeer。 #ctor

#### <a name="menubaritemautomationpeerhttpsdocsmicrosoftcomuwpapiwindowsuixamlautomationpeersmenubaritemautomationpeer"></a>[MenuBarItemAutomationPeer](https://docs.microsoft.com/uwp/api/windows.ui.xaml.automation.peers.menubaritemautomationpeer)

MenuBarItemAutomationPeer <br> MenuBarItemAutomationPeer.Collapse <br> MenuBarItemAutomationPeer.Expand <br> MenuBarItemAutomationPeer.ExpandCollapseState <br> MenuBarItemAutomationPeer.Invoke <br> MenuBarItemAutomationPeer。 #ctor

### <a name="windowsuixamlautomationhttpsdocsmicrosoftcomuwpapiwindowsuixamlautomation"></a>[Windows.UI.Xaml.Automation](https://docs.microsoft.com/uwp/api/windows.ui.xaml.automation)

#### <a name="automationelementidentifiershttpsdocsmicrosoftcomuwpapiwindowsuixamlautomationautomationelementidentifiers"></a>[AutomationElementIdentifiers](https://docs.microsoft.com/uwp/api/windows.ui.xaml.automation.automationelementidentifiers)

AutomationElementIdentifiers.IsDialogProperty

#### <a name="automationpropertieshttpsdocsmicrosoftcomuwpapiwindowsuixamlautomationautomationproperties"></a>[オートメーション プロパティ](https://docs.microsoft.com/uwp/api/windows.ui.xaml.automation.automationproperties)

AutomationProperties.GetIsDialog <br> AutomationProperties.IsDialogProperty <br> AutomationProperties.SetIsDialog

### <a name="windowsuixamlcontrolsmapshttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsmaps"></a>[Windows.UI.Xaml.Controls.Maps](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps)

#### <a name="maptileanimationstatehttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsmapsmaptileanimationstate"></a>[MapTileAnimationState](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.maptileanimationstate)

MapTileAnimationState

#### <a name="maptilebitmaprequestedeventargshttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsmapsmaptilebitmaprequestedeventargs"></a>[MapTileBitmapRequestedEventArgs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.maptilebitmaprequestedeventargs)

MapTileBitmapRequestedEventArgs.FrameIndex

#### <a name="maptilesourcehttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsmapsmaptilesource"></a>[MapTileSource](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.maptilesource)

MapTileSource.AnimationState <br> MapTileSource.AnimationStateProperty <br> MapTileSource.AutoPlay <br> MapTileSource.AutoPlayProperty <br> MapTileSource.FrameCount <br> MapTileSource.FrameCountProperty <br> MapTileSource.FrameDuration <br> MapTileSource.FrameDurationProperty <br> MapTileSource.Pause <br> MapTileSource.Play <br> MapTileSource.Stop

#### <a name="maptileurirequestedeventargshttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsmapsmaptileurirequestedeventargs"></a>[MapTileUriRequestedEventArgs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.maptileurirequestedeventargs)

MapTileUriRequestedEventArgs.FrameIndex

### <a name="windowsuixamlcontrolsprimitiveshttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsprimitives"></a>[Windows.UI.Xaml.Controls.Primitives](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.primitives)

#### <a name="commandbarflyoutcommandbarhttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsprimitivescommandbarflyoutcommandbar"></a>[CommandBarFlyoutCommandBar](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.primitives.commandbarflyoutcommandbar)

CommandBarFlyoutCommandBar <br> CommandBarFlyoutCommandBar。 #ctor <br> CommandBarFlyoutCommandBar.FlyoutTemplateSettings

#### <a name="commandbarflyoutcommandbartemplatesettingshttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsprimitivescommandbarflyoutcommandbartemplatesettings"></a>[CommandBarFlyoutCommandBarTemplateSettings](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.primitives.commandbarflyoutcommandbartemplatesettings)

CommandBarFlyoutCommandBarTemplateSettings <br> CommandBarFlyoutCommandBarTemplateSettings.CloseAnimationEndPosition <br> CommandBarFlyoutCommandBarTemplateSettings.ContentClipRect <br> CommandBarFlyoutCommandBarTemplateSettings.CurrentWidth <br> CommandBarFlyoutCommandBarTemplateSettings.ExpandDownAnimationEndPosition <br> CommandBarFlyoutCommandBarTemplateSettings.ExpandDownAnimationHoldPosition <br> CommandBarFlyoutCommandBarTemplateSettings.ExpandDownAnimationStartPosition <br> CommandBarFlyoutCommandBarTemplateSettings.ExpandDownOverflowVerticalPosition <br> CommandBarFlyoutCommandBarTemplateSettings.ExpandedWidth <br> CommandBarFlyoutCommandBarTemplateSettings.ExpandUpAnimationEndPosition <br> CommandBarFlyoutCommandBarTemplateSettings.ExpandUpAnimationHoldPosition <br> CommandBarFlyoutCommandBarTemplateSettings.ExpandUpAnimationStartPosition <br> CommandBarFlyoutCommandBarTemplateSettings.ExpandUpOverflowVerticalPosition <br> CommandBarFlyoutCommandBarTemplateSettings.OpenAnimationEndPosition <br> CommandBarFlyoutCommandBarTemplateSettings.OpenAnimationStartPosition <br> CommandBarFlyoutCommandBarTemplateSettings.OverflowContentClipRect <br> CommandBarFlyoutCommandBarTemplateSettings.WidthExpansionAnimationEndPosition <br> CommandBarFlyoutCommandBarTemplateSettings.WidthExpansionAnimationStartPosition <br> CommandBarFlyoutCommandBarTemplateSettings.WidthExpansionDelta <br> CommandBarFlyoutCommandBarTemplateSettings.WidthExpansionMoreButtonAnimationEndPosition <br> CommandBarFlyoutCommandBarTemplateSettings.WidthExpansionMoreButtonAnimationStartPosition

#### <a name="flyoutbasehttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsprimitivesflyoutbase"></a>[FlyoutBase](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.primitives.flyoutbase)

FlyoutBase.AreOpenCloseAnimationsEnabled <br> FlyoutBase.AreOpenCloseAnimationsEnabledProperty <br> FlyoutBase.InputDevicePrefersPrimaryCommands <br> FlyoutBase.InputDevicePrefersPrimaryCommandsProperty <br> FlyoutBase.IsOpen <br> FlyoutBase.IsOpenProperty <br> FlyoutBase.ShowAt <br> FlyoutBase.ShowMode <br> FlyoutBase.ShowModeProperty <br> FlyoutBase.TargetProperty

#### <a name="flyoutshowmodehttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsprimitivesflyoutshowmode"></a>[FlyoutShowMode](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.primitives.flyoutshowmode)

FlyoutShowMode

#### <a name="flyoutshowoptionshttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsprimitivesflyoutshowoptions"></a>[FlyoutShowOptions](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.primitives.flyoutshowoptions)

FlyoutShowOptions <br> FlyoutShowOptions.ExclusionRect <br> FlyoutShowOptions。 #ctor <br> FlyoutShowOptions.Placement <br> FlyoutShowOptions.Position <br> FlyoutShowOptions.ShowMode

#### <a name="navigationviewitempresenterhttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsprimitivesnavigationviewitempresenter"></a>[NavigationViewItemPresenter](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.primitives.navigationviewitempresenter)

NavigationViewItemPresenter <br> NavigationViewItemPresenter.Icon <br> NavigationViewItemPresenter.IconProperty <br> NavigationViewItemPresenter。 #ctor

### <a name="windowsuixamlcontrolshttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrols"></a>[Windows.UI.Xaml.Controls](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls)

#### <a name="anchorrequestedeventargshttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsanchorrequestedeventargs"></a>[AnchorRequestedEventArgs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.anchorrequestedeventargs)

AnchorRequestedEventArgs <br> AnchorRequestedEventArgs.Anchor <br> AnchorRequestedEventArgs.AnchorCandidates

#### <a name="appbarelementcontainerhttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsappbarelementcontainer"></a>[AppBarElementContainer](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.appbarelementcontainer)

AppBarElementContainer <br> AppBarElementContainer。 #ctor <br> AppBarElementContainer.DynamicOverflowOrder <br> AppBarElementContainer.DynamicOverflowOrderProperty <br> AppBarElementContainer.IsCompact <br> AppBarElementContainer.IsCompactProperty <br> AppBarElementContainer.IsInOverflow <br> AppBarElementContainer.IsInOverflowProperty

#### <a name="autosuggestboxhttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsautosuggestbox"></a>[AutoSuggestBox](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.autosuggestbox)

AutoSuggestBox.Description <br> AutoSuggestBox.DescriptionProperty

#### <a name="backgroundsizinghttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsbackgroundsizing"></a>[BackgroundSizing](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.backgroundsizing)

BackgroundSizing

#### <a name="borderhttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsborder"></a>[境界線](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.border)

Border.BackgroundSizing <br> Border.BackgroundSizingProperty <br> Border.BackgroundTransition

#### <a name="calendardatepickerhttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolscalendardatepicker"></a>[CalendarDatePicker](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.calendardatepicker)

CalendarDatePicker.Description <br> CalendarDatePicker.DescriptionProperty

#### <a name="comboboxhttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolscombobox"></a>[ComboBox](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.combobox)

ComboBox.Description <br> ComboBox.DescriptionProperty <br> ComboBox.IsEditableProperty <br> ComboBox.Text <br> ComboBox.TextBoxStyle <br> ComboBox.TextBoxStyleProperty <br> ComboBox.TextProperty <br> ComboBox.TextSubmitted

#### <a name="comboboxtextsubmittedeventargshttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolscomboboxtextsubmittedeventargs"></a>[ComboBoxTextSubmittedEventArgs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.comboboxtextsubmittedeventargs)

ComboBoxTextSubmittedEventArgs <br> ComboBoxTextSubmittedEventArgs.Handled <br> ComboBoxTextSubmittedEventArgs.Text

#### <a name="commandbarflyouthttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolscommandbarflyout"></a>[CommandBarFlyout](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.commandbarflyout)

CommandBarFlyout <br> CommandBarFlyout。 #ctor <br> CommandBarFlyout.PrimaryCommands <br> CommandBarFlyout.SecondaryCommands

#### <a name="contentpresenterhttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolscontentpresenter"></a>[ContentPresenter](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.contentpresenter)

ContentPresenter.BackgroundSizing <br> ContentPresenter.BackgroundSizingProperty <br> ContentPresenter.BackgroundTransition

#### <a name="controlhttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolscontrol"></a>[制御](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.control)

Control.BackgroundSizing <br> Control.BackgroundSizingProperty <br> Control.CornerRadius <br> Control.CornerRadiusProperty

#### <a name="datatemplateselectorhttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsdatatemplateselector"></a>[DataTemplateSelector](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.datatemplateselector)

DataTemplateSelector.GetElement <br> DataTemplateSelector.RecycleElement

#### <a name="datepickerhttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsdatepicker"></a>[DatePicker](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.datepicker)

DatePicker.SelectedDate <br> DatePicker.SelectedDateChanged <br> DatePicker.SelectedDateProperty

#### <a name="datepickerselectedvaluechangedeventargshttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsdatepickerselectedvaluechangedeventargs"></a>[DatePickerSelectedValueChangedEventArgs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.datepickerselectedvaluechangedeventargs)

DatePickerSelectedValueChangedEventArgs <br> DatePickerSelectedValueChangedEventArgs.NewDate <br> DatePickerSelectedValueChangedEventArgs.OldDate

#### <a name="dropdownbuttonhttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsdropdownbutton"></a>[DropDownButton](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.dropdownbutton)

DropDownButton <br> DropDownButton。 #ctor

#### <a name="dropdownbuttonautomationpeerhttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsdropdownbuttonautomationpeer"></a>[DropDownButtonAutomationPeer](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.dropdownbuttonautomationpeer)

DropDownButtonAutomationPeer <br> DropDownButtonAutomationPeer.Collapse <br> DropDownButtonAutomationPeer。 #ctor <br> DropDownButtonAutomationPeer.Expand <br> DropDownButtonAutomationPeer.ExpandCollapseState

#### <a name="framehttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsframe"></a>[フレーム](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.frame)

Frame.IsNavigationStackEnabled <br> Frame.IsNavigationStackEnabledProperty <br> Frame.NavigateToType

#### <a name="gridhttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsgrid"></a>[グリッド](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.grid)

Grid.BackgroundSizing <br> Grid.BackgroundSizingProperty

#### <a name="iconsourceelementhttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsiconsourceelement"></a>[IconSourceElement](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.iconsourceelement)

IconSourceElement <br> IconSourceElement.IconSource <br> IconSourceElement。 #ctor <br> IconSourceElement.IconSourceProperty

#### <a name="iscrollanchorproviderhttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsiscrollanchorprovider"></a>[IScrollAnchorProvider](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.iscrollanchorprovider)

IScrollAnchorProvider <br> IScrollAnchorProvider.CurrentAnchor <br> IScrollAnchorProvider.RegisterAnchorCandidate <br> IScrollAnchorProvider.UnregisterAnchorCandidate

#### <a name="menubarhttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsmenubar"></a>[メニュー バー](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.menubar)

メニュー バー <br> MenuBar.Items <br> MenuBar.ItemsProperty <br> メニュー バー。 #ctor

#### <a name="menubaritemhttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsmenubaritem"></a>[MenuBarItem](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.menubaritem)

MenuBarItem <br> MenuBarItem.Items <br> MenuBarItem.ItemsProperty <br> MenuBarItem。 #ctor <br> MenuBarItem.Title <br> MenuBarItem.TitleProperty

#### <a name="menubaritemflyouthttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsmenubaritemflyout"></a>[MenuBarItemFlyout](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.menubaritemflyout)

MenuBarItemFlyout <br> MenuBarItemFlyout。 #ctor

#### <a name="navigationviewhttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsnavigationview"></a>[NavigationView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview)

NavigationView.ContentOverlay <br> NavigationView.ContentOverlayProperty <br> NavigationView.IsPaneVisible <br> NavigationView.IsPaneVisibleProperty <br> NavigationView.OverflowLabelMode <br> NavigationView.OverflowLabelModeProperty <br> NavigationView.PaneCustomContent <br> NavigationView.PaneCustomContentProperty <br> NavigationView.PaneDisplayMode <br> NavigationView.PaneDisplayModeProperty <br> NavigationView.PaneHeader <br> NavigationView.PaneHeaderProperty <br> NavigationView.SelectionFollowsFocus <br> NavigationView.SelectionFollowsFocusProperty <br> NavigationView.ShoulderNavigationEnabled <br> NavigationView.ShoulderNavigationEnabledProperty <br> NavigationView.TemplateSettings <br> NavigationView.TemplateSettingsProperty

#### <a name="navigationviewitemhttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsnavigationviewitem"></a>[NavigationViewItem](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewitem)

NavigationViewItem.SelectsOnInvoked <br> NavigationViewItem.SelectsOnInvokedProperty

#### <a name="navigationviewiteminvokedeventargshttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsnavigationviewiteminvokedeventargs"></a>[NavigationViewItemInvokedEventArgs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewiteminvokedeventargs)

NavigationViewItemInvokedEventArgs.InvokedItemContainer <br> NavigationViewItemInvokedEventArgs.RecommendedNavigationTransitionInfo

#### <a name="navigationviewoverflowlabelmodehttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsnavigationviewoverflowlabelmode"></a>[NavigationViewOverflowLabelMode](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewoverflowlabelmode)

NavigationViewOverflowLabelMode

#### <a name="navigationviewpanedisplaymodehttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsnavigationviewpanedisplaymode"></a>[NavigationViewPaneDisplayMode](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewpanedisplaymode)

NavigationViewPaneDisplayMode

#### <a name="navigationviewselectionchangedeventargshttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsnavigationviewselectionchangedeventargs"></a>[NavigationViewSelectionChangedEventArgs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewselectionchangedeventargs)

NavigationViewSelectionChangedEventArgs.RecommendedNavigationTransitionInfo <br> NavigationViewSelectionChangedEventArgs.SelectedItemContainer

#### <a name="navigationviewselectionfollowsfocushttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsnavigationviewselectionfollowsfocus"></a>[NavigationViewSelectionFollowsFocus](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewselectionfollowsfocus)

NavigationViewSelectionFollowsFocus

#### <a name="navigationviewshouldernavigationenabledhttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsnavigationviewshouldernavigationenabled"></a>[NavigationViewShoulderNavigationEnabled](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewshouldernavigationenabled)

NavigationViewShoulderNavigationEnabled

#### <a name="navigationviewtemplatesettingshttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsnavigationviewtemplatesettings"></a>[NavigationViewTemplateSettings](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewtemplatesettings)

NavigationViewTemplateSettings <br> NavigationViewTemplateSettings.BackButtonVisibility <br> NavigationViewTemplateSettings.BackButtonVisibilityProperty <br> NavigationViewTemplateSettings.LeftPaneVisibility <br> NavigationViewTemplateSettings.LeftPaneVisibilityProperty <br> NavigationViewTemplateSettings。 #ctor <br> NavigationViewTemplateSettings.OverflowButtonVisibility <br> NavigationViewTemplateSettings.OverflowButtonVisibilityProperty <br> NavigationViewTemplateSettings.PaneToggleButtonVisibility <br> NavigationViewTemplateSettings.PaneToggleButtonVisibilityProperty <br> NavigationViewTemplateSettings.SingleSelectionFollowsFocus <br> NavigationViewTemplateSettings.SingleSelectionFollowsFocusProperty <br> NavigationViewTemplateSettings.TopPadding <br> NavigationViewTemplateSettings.TopPaddingProperty <br> NavigationViewTemplateSettings.TopPaneVisibility <br> NavigationViewTemplateSettings.TopPaneVisibilityProperty

#### <a name="panelhttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolspanel"></a>[パネル](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.panel)

Panel.BackgroundTransition

#### <a name="passwordboxhttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolspasswordbox"></a>[PasswordBox](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.passwordbox)

PasswordBox.CanPasteClipboardContent <br> PasswordBox.CanPasteClipboardContentProperty <br> PasswordBox.Description <br> PasswordBox.DescriptionProperty <br> PasswordBox.PasteFromClipboard <br> PasswordBox.SelectionFlyout <br> PasswordBox.SelectionFlyoutProperty

#### <a name="relativepanelhttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsrelativepanel"></a>[RelativePanel](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.relativepanel)

RelativePanel.BackgroundSizing <br> RelativePanel.BackgroundSizingProperty

#### <a name="richeditboxhttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsricheditbox"></a>[RichEditBox](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.richeditbox)

RichEditBox.Description <br> RichEditBox.DescriptionProperty <br> RichEditBox.ProofingMenuFlyout <br> RichEditBox.ProofingMenuFlyoutProperty <br> RichEditBox.SelectionChanging <br> RichEditBox.SelectionFlyout <br> RichEditBox.SelectionFlyoutProperty <br> RichEditBox.TextDocument

#### <a name="richeditboxselectionchangingeventargshttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsricheditboxselectionchangingeventargs"></a>[RichEditBoxSelectionChangingEventArgs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.richeditboxselectionchangingeventargs)

RichEditBoxSelectionChangingEventArgs <br> RichEditBoxSelectionChangingEventArgs.Cancel <br> RichEditBoxSelectionChangingEventArgs.SelectionLength <br> RichEditBoxSelectionChangingEventArgs.SelectionStart

#### <a name="richtextblockhttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsrichtextblock"></a>[RichTextBlock](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.richtextblock)

RichTextBlock.CopySelectionToClipboard <br> RichTextBlock.SelectionFlyout <br> RichTextBlock.SelectionFlyoutProperty

#### <a name="scrollcontentpresenterhttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsscrollcontentpresenter"></a>[ScrollContentPresenter](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.scrollcontentpresenter)

ScrollContentPresenter.CanContentRenderOutsideBounds <br> ScrollContentPresenter.CanContentRenderOutsideBoundsProperty <br> ScrollContentPresenter.SizesContentToTemplatedParent <br> ScrollContentPresenter.SizesContentToTemplatedParentProperty

#### <a name="scrollviewerhttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsscrollviewer"></a>[ScrollViewer](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.scrollviewer)

ScrollViewer.AnchorRequested <br> ScrollViewer.CanContentRenderOutsideBounds <br> ScrollViewer.CanContentRenderOutsideBoundsProperty <br> ScrollViewer.CurrentAnchor <br> ScrollViewer.GetCanContentRenderOutsideBounds <br> ScrollViewer.HorizontalAnchorRatio <br> ScrollViewer.HorizontalAnchorRatioProperty <br> ScrollViewer.ReduceViewportForCoreInputViewOcclusions <br> ScrollViewer.ReduceViewportForCoreInputViewOcclusionsProperty <br> ScrollViewer.RegisterAnchorCandidate <br> ScrollViewer.SetCanContentRenderOutsideBounds <br> ScrollViewer.UnregisterAnchorCandidate <br> ScrollViewer.VerticalAnchorRatio <br> ScrollViewer.VerticalAnchorRatioProperty

#### <a name="splitbuttonhttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolssplitbutton"></a>[分割ボタン](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.splitbutton)

分割ボタン <br> SplitButton.Click <br> SplitButton.Command <br> SplitButton.CommandParameter <br> SplitButton.CommandParameterProperty <br> SplitButton.CommandProperty <br> SplitButton.Flyout <br> SplitButton.FlyoutProperty <br> SplitButton。 #ctor

#### <a name="splitbuttonautomationpeerhttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolssplitbuttonautomationpeer"></a>[SplitButtonAutomationPeer](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.splitbuttonautomationpeer)

SplitButtonAutomationPeer <br> SplitButtonAutomationPeer.Collapse <br> SplitButtonAutomationPeer.Expand <br> SplitButtonAutomationPeer.ExpandCollapseState <br> SplitButtonAutomationPeer.Invoke <br> SplitButtonAutomationPeer。 #ctor

#### <a name="splitbuttonclickeventargshttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolssplitbuttonclickeventargs"></a>[SplitButtonClickEventArgs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.splitbuttonclickeventargs)

SplitButtonClickEventArgs

#### <a name="stackpanelhttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsstackpanel"></a>[StackPanel](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.stackpanel)

StackPanel.BackgroundSizing <br> StackPanel.BackgroundSizingProperty

#### <a name="textblockhttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolstextblock"></a>[TextBlock](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.textblock)

TextBlock.CopySelectionToClipboard <br> TextBlock.SelectionFlyout <br> TextBlock.SelectionFlyoutProperty

#### <a name="textboxhttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolstextbox"></a>[TextBox](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.textbox)

TextBox.CanPasteClipboardContent <br> TextBox.CanPasteClipboardContentProperty <br> TextBox.CanRedo <br> TextBox.CanRedoProperty <br> TextBox.CanUndo <br> TextBox.CanUndoProperty <br> TextBox.ClearUndoRedoHistory <br> TextBox.CopySelectionToClipboard <br> TextBox.CutSelectionToClipboard <br> TextBox.Description <br> TextBox.DescriptionProperty <br> TextBox.PasteFromClipboard <br> TextBox.ProofingMenuFlyout <br> TextBox.ProofingMenuFlyoutProperty <br> TextBox.Redo <br> TextBox.SelectionChanging <br> TextBox.SelectionFlyout <br> TextBox.SelectionFlyoutProperty <br> TextBox.Undo

#### <a name="textboxselectionchangingeventargshttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolstextboxselectionchangingeventargs"></a>[TextBoxSelectionChangingEventArgs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.textboxselectionchangingeventargs)

TextBoxSelectionChangingEventArgs <br> TextBoxSelectionChangingEventArgs.Cancel <br> TextBoxSelectionChangingEventArgs.SelectionLength <br> TextBoxSelectionChangingEventArgs.SelectionStart

#### <a name="textcommandbarflyouthttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolstextcommandbarflyout"></a>[TextCommandBarFlyout](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.textcommandbarflyout)

TextCommandBarFlyout <br> TextCommandBarFlyout。 #ctor

#### <a name="timepickerhttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolstimepicker"></a>[TimePicker](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.timepicker)

TimePicker.SelectedTime <br> TimePicker.SelectedTimeChanged <br> TimePicker.SelectedTimeProperty

#### <a name="timepickerselectedvaluechangedeventargshttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolstimepickerselectedvaluechangedeventargs"></a>[TimePickerSelectedValueChangedEventArgs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.timepickerselectedvaluechangedeventargs)

TimePickerSelectedValueChangedEventArgs <br> TimePickerSelectedValueChangedEventArgs.NewTime <br> TimePickerSelectedValueChangedEventArgs.OldTime

#### <a name="togglesplitbuttonhttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolstogglesplitbutton"></a>[ToggleSplitButton](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.togglesplitbutton)

ToggleSplitButton <br> ToggleSplitButton.IsChecked <br> ToggleSplitButton.IsCheckedChanged <br> ToggleSplitButton。 #ctor

#### <a name="togglesplitbuttonautomationpeerhttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolstogglesplitbuttonautomationpeer"></a>[ToggleSplitButtonAutomationPeer](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.togglesplitbuttonautomationpeer)

ToggleSplitButtonAutomationPeer <br> ToggleSplitButtonAutomationPeer.Collapse <br> ToggleSplitButtonAutomationPeer.Expand <br> ToggleSplitButtonAutomationPeer.ExpandCollapseState <br> ToggleSplitButtonAutomationPeer.Toggle <br> ToggleSplitButtonAutomationPeer。 #ctor <br> ToggleSplitButtonAutomationPeer.ToggleState

#### <a name="togglesplitbuttonischeckedchangedeventargshttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolstogglesplitbuttonischeckedchangedeventargs"></a>[ToggleSplitButtonIsCheckedChangedEventArgs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.togglesplitbuttonischeckedchangedeventargs)

ToggleSplitButtonIsCheckedChangedEventArgs

#### <a name="tooltiphttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolstooltip"></a>[ツール ヒント](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.tooltip)

ToolTip.PlacementRect <br> ToolTip.PlacementRectProperty

#### <a name="treeviewhttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolstreeview"></a>[ツリー ビュー](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.treeview)

TreeView.CanDragItems <br> TreeView.CanDragItemsProperty <br> TreeView.CanReorderItems <br> TreeView.CanReorderItemsProperty <br> TreeView.ContainerFromItem <br> TreeView.ContainerFromNode <br> TreeView.DragItemsCompleted <br> TreeView.DragItemsStarting <br> TreeView.ItemContainerStyle <br> TreeView.ItemContainerStyleProperty <br> TreeView.ItemContainerStyleSelector <br> TreeView.ItemContainerStyleSelectorProperty <br> TreeView.ItemContainerTransitions <br> TreeView.ItemContainerTransitionsProperty <br> TreeView.ItemFromContainer <br> TreeView.ItemsSource <br> TreeView.ItemsSourceProperty <br> TreeView.ItemTemplate <br> TreeView.ItemTemplateProperty <br> TreeView.ItemTemplateSelector <br> TreeView.ItemTemplateSelectorProperty <br> TreeView.NodeFromContainer

#### <a name="treeviewcollapsedeventargshttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolstreeviewcollapsedeventargs"></a>[TreeViewCollapsedEventArgs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.treeviewcollapsedeventargs)

TreeViewCollapsedEventArgs.Item

#### <a name="treeviewdragitemscompletedeventargshttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolstreeviewdragitemscompletedeventargs"></a>[TreeViewDragItemsCompletedEventArgs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.treeviewdragitemscompletedeventargs)

TreeViewDragItemsCompletedEventArgs <br> TreeViewDragItemsCompletedEventArgs.DropResult <br> TreeViewDragItemsCompletedEventArgs.Items

#### <a name="treeviewdragitemsstartingeventargshttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolstreeviewdragitemsstartingeventargs"></a>[TreeViewDragItemsStartingEventArgs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.treeviewdragitemsstartingeventargs)

TreeViewDragItemsStartingEventArgs <br> TreeViewDragItemsStartingEventArgs.Cancel <br> TreeViewDragItemsStartingEventArgs.Data <br> TreeViewDragItemsStartingEventArgs.Items

#### <a name="treeviewexpandingeventargshttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolstreeviewexpandingeventargs"></a>[TreeViewExpandingEventArgs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.treeviewexpandingeventargs)

TreeViewExpandingEventArgs.Item

#### <a name="treeviewitemhttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolstreeviewitem"></a>[TreeViewItem](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.treeviewitem)

TreeViewItem.HasUnrealizedChildren <br> TreeViewItem.HasUnrealizedChildrenProperty <br> TreeViewItem.ItemsSource <br> TreeViewItem.ItemsSourceProperty

#### <a name="webviewhttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolswebview"></a>[WebView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.webview)

WebView.WebResourceRequested

#### <a name="webviewwebresourcerequestedeventargshttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolswebviewwebresourcerequestedeventargs"></a>[WebViewWebResourceRequestedEventArgs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.webviewwebresourcerequestedeventargs)

WebViewWebResourceRequestedEventArgs <br> WebViewWebResourceRequestedEventArgs.GetDeferral <br> WebViewWebResourceRequestedEventArgs.Request <br> WebViewWebResourceRequestedEventArgs.Response

### <a name="windowsuixamlcoredirecthttpsdocsmicrosoftcomuwpapiwindowsuixamlcoredirect"></a>[Windows.UI.Xaml.Core.Direct](https://docs.microsoft.com/uwp/api/windows.ui.xaml.core.direct)

#### <a name="ixamldirectobjecthttpsdocsmicrosoftcomuwpapiwindowsuixamlcoredirectixamldirectobject"></a>[IXamlDirectObject](https://docs.microsoft.com/uwp/api/windows.ui.xaml.core.direct.ixamldirectobject)

IXamlDirectObject

### <a name="windowsuixamlcoredirecthttpsdocsmicrosoftcomuwpapiwindowsuixamlcoredirect"></a>[Windows.UI.Xaml.Core.Direct](https://docs.microsoft.com/uwp/api/windows.ui.xaml.core.direct)

#### <a name="xamldirecthttpsdocsmicrosoftcomuwpapiwindowsuixamlcoredirectxamldirect"></a>[XamlDirect](https://docs.microsoft.com/uwp/api/windows.ui.xaml.core.direct.xamldirect)

XamlDirect <br> XamlDirect.AddEventHandler <br> XamlDirect.AddEventHandler <br> XamlDirect.AddToCollection <br> XamlDirect.ClearCollection <br> XamlDirect.ClearProperty <br> XamlDirect.CreateInstance <br> XamlDirect.GetBooleanProperty <br> XamlDirect.GetCollectionCount <br> XamlDirect.GetColorProperty <br> XamlDirect.GetCornerRadiusProperty <br> XamlDirect.GetDateTimeProperty <br> XamlDirect.GetDefault <br> XamlDirect.GetDoubleProperty <br> XamlDirect.GetDurationProperty <br> XamlDirect.GetEnumProperty <br> XamlDirect.GetGridLengthProperty <br> XamlDirect.GetInt32Property <br> XamlDirect.GetMatrix3DProperty <br> XamlDirect.GetMatrixProperty <br> XamlDirect.GetObject <br> XamlDirect.GetObjectProperty <br> XamlDirect.GetPointProperty <br> XamlDirect.GetRectProperty <br> XamlDirect.GetSizeProperty <br> XamlDirect.GetStringProperty <br> XamlDirect.GetThicknessProperty <br> XamlDirect.GetTimeSpanProperty <br> XamlDirect.GetXamlDirectObject <br> XamlDirect.GetXamlDirectObjectFromCollectionAt <br> XamlDirect.GetXamlDirectObjectProperty <br> XamlDirect.InsertIntoCollectionAt <br> XamlDirect.RemoveEventHandler <br> XamlDirect.RemoveFromCollection <br> XamlDirect.RemoveFromCollectionAt <br> XamlDirect.SetBooleanProperty <br> XamlDirect.SetColorProperty <br> XamlDirect.SetCornerRadiusProperty <br> XamlDirect.SetDateTimeProperty <br> XamlDirect.SetDoubleProperty <br> XamlDirect.SetDurationProperty <br> XamlDirect.SetEnumProperty <br> XamlDirect.SetGridLengthProperty <br> XamlDirect.SetInt32Property <br> XamlDirect.SetMatrix3DProperty <br> XamlDirect.SetMatrixProperty <br> XamlDirect.SetObjectProperty <br> XamlDirect.SetPointProperty <br> XamlDirect.SetRectProperty <br> XamlDirect.SetSizeProperty <br> XamlDirect.SetStringProperty <br> XamlDirect.SetThicknessProperty <br> XamlDirect.SetTimeSpanProperty <br> XamlDirect.SetXamlDirectObjectProperty

#### <a name="xamleventindexhttpsdocsmicrosoftcomuwpapiwindowsuixamlcoredirectxamleventindex"></a>[XamlEventIndex](https://docs.microsoft.com/uwp/api/windows.ui.xaml.core.direct.xamleventindex)

XamlEventIndex

#### <a name="xamlpropertyindexhttpsdocsmicrosoftcomuwpapiwindowsuixamlcoredirectxamlpropertyindex"></a>[XamlPropertyIndex](https://docs.microsoft.com/uwp/api/windows.ui.xaml.core.direct.xamlpropertyindex)

XamlPropertyIndex

#### <a name="xamltypeindexhttpsdocsmicrosoftcomuwpapiwindowsuixamlcoredirectxamltypeindex"></a>[XamlTypeIndex](https://docs.microsoft.com/uwp/api/windows.ui.xaml.core.direct.xamltypeindex)

XamlTypeIndex

### <a name="windowsuixamlhostinghttpsdocsmicrosoftcomuwpapiwindowsuixamlhosting"></a>[Windows.UI.Xaml.Hosting](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting)

#### <a name="desktopwindowxamlsourcehttpsdocsmicrosoftcomuwpapiwindowsuixamlhostingdesktopwindowxamlsource"></a>[DesktopWindowXamlSource](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting.desktopwindowxamlsource)

DesktopWindowXamlSource <br> DesktopWindowXamlSource.Close <br> DesktopWindowXamlSource.Content <br> DesktopWindowXamlSource。 #ctor <br> DesktopWindowXamlSource.GotFocus <br> DesktopWindowXamlSource.HasFocus <br> DesktopWindowXamlSource.NavigateFocus <br> DesktopWindowXamlSource.TakeFocusRequested

#### <a name="desktopwindowxamlsourcegotfocuseventargshttpsdocsmicrosoftcomuwpapiwindowsuixamlhostingdesktopwindowxamlsourcegotfocuseventargs"></a>[DesktopWindowXamlSourceGotFocusEventArgs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting.desktopwindowxamlsourcegotfocuseventargs)

DesktopWindowXamlSourceGotFocusEventArgs <br> DesktopWindowXamlSourceGotFocusEventArgs.Request

#### <a name="desktopwindowxamlsourcetakefocusrequestedeventargshttpsdocsmicrosoftcomuwpapiwindowsuixamlhostingdesktopwindowxamlsourcetakefocusrequestedeventargs"></a>[DesktopWindowXamlSourceTakeFocusRequestedEventArgs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting.desktopwindowxamlsourcetakefocusrequestedeventargs)

DesktopWindowXamlSourceTakeFocusRequestedEventArgs <br> DesktopWindowXamlSourceTakeFocusRequestedEventArgs.Request

#### <a name="windowsxamlmanagerhttpsdocsmicrosoftcomuwpapiwindowsuixamlhostingwindowsxamlmanager"></a>[WindowsXamlManager](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting.windowsxamlmanager)

WindowsXamlManager <br> WindowsXamlManager.Close <br> WindowsXamlManager.InitializeForCurrentThread

#### <a name="xamlsourcefocusnavigationreasonhttpsdocsmicrosoftcomuwpapiwindowsuixamlhostingxamlsourcefocusnavigationreason"></a>[XamlSourceFocusNavigationReason](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting.xamlsourcefocusnavigationreason)

XamlSourceFocusNavigationReason

#### <a name="xamlsourcefocusnavigationrequesthttpsdocsmicrosoftcomuwpapiwindowsuixamlhostingxamlsourcefocusnavigationrequest"></a>[XamlSourceFocusNavigationRequest](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting.xamlsourcefocusnavigationrequest)

XamlSourceFocusNavigationRequest <br> XamlSourceFocusNavigationRequest.CorrelationId <br> XamlSourceFocusNavigationRequest.HintRect <br> XamlSourceFocusNavigationRequest.Reason <br> XamlSourceFocusNavigationRequest。 #ctor <br> XamlSourceFocusNavigationRequest。 #ctor <br> XamlSourceFocusNavigationRequest。 #ctor

#### <a name="xamlsourcefocusnavigationresulthttpsdocsmicrosoftcomuwpapiwindowsuixamlhostingxamlsourcefocusnavigationresult"></a>[XamlSourceFocusNavigationResult](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting.xamlsourcefocusnavigationresult)

XamlSourceFocusNavigationResult <br> XamlSourceFocusNavigationResult.WasFocusMoved <br> XamlSourceFocusNavigationResult。 #ctor

### <a name="windowsuixamlinputhttpsdocsmicrosoftcomuwpapiwindowsuixamlinput"></a>[Windows.UI.Xaml.Input](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input)

#### <a name="canexecuterequestedeventargshttpsdocsmicrosoftcomuwpapiwindowsuixamlinputcanexecuterequestedeventargs"></a>[CanExecuteRequestedEventArgs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.canexecuterequestedeventargs)

CanExecuteRequestedEventArgs <br> CanExecuteRequestedEventArgs.CanExecute <br> CanExecuteRequestedEventArgs.Parameter

#### <a name="executerequestedeventargshttpsdocsmicrosoftcomuwpapiwindowsuixamlinputexecuterequestedeventargs"></a>[ExecuteRequestedEventArgs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.executerequestedeventargs)

ExecuteRequestedEventArgs <br> ExecuteRequestedEventArgs.Parameter

#### <a name="focusmanagerhttpsdocsmicrosoftcomuwpapiwindowsuixamlinputfocusmanager"></a>[FocusManager](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.focusmanager)

FocusManager.GettingFocus <br> FocusManager.GotFocus <br> FocusManager.LosingFocus <br> FocusManager.LostFocus

#### <a name="focusmanagergotfocuseventargshttpsdocsmicrosoftcomuwpapiwindowsuixamlinputfocusmanagergotfocuseventargs"></a>[FocusManagerGotFocusEventArgs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.focusmanagergotfocuseventargs)

FocusManagerGotFocusEventArgs <br> FocusManagerGotFocusEventArgs.CorrelationId <br> FocusManagerGotFocusEventArgs.NewFocusedElement

#### <a name="focusmanagerlostfocuseventargshttpsdocsmicrosoftcomuwpapiwindowsuixamlinputfocusmanagerlostfocuseventargs"></a>[FocusManagerLostFocusEventArgs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.focusmanagerlostfocuseventargs)

FocusManagerLostFocusEventArgs <br> FocusManagerLostFocusEventArgs.CorrelationId <br> FocusManagerLostFocusEventArgs.OldFocusedElement

#### <a name="gettingfocuseventargshttpsdocsmicrosoftcomuwpapiwindowsuixamlinputgettingfocuseventargs"></a>[GettingFocusEventArgs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.gettingfocuseventargs)

GettingFocusEventArgs.CorrelationId

#### <a name="losingfocuseventargshttpsdocsmicrosoftcomuwpapiwindowsuixamlinputlosingfocuseventargs"></a>[LosingFocusEventArgs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.losingfocuseventargs)

LosingFocusEventArgs.CorrelationId

#### <a name="standarduicommandhttpsdocsmicrosoftcomuwpapiwindowsuixamlinputstandarduicommand"></a>[StandardUICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.standarduicommand)

StandardUICommand <br> StandardUICommand.Kind <br> StandardUICommand.KindProperty <br> StandardUICommand。 #ctor <br> StandardUICommand。 #ctor

#### <a name="standarduicommandkindhttpsdocsmicrosoftcomuwpapiwindowsuixamlinputstandarduicommandkind"></a>[StandardUICommandKind](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.standarduicommandkind)

StandardUICommandKind

#### <a name="xamluicommandhttpsdocsmicrosoftcomuwpapiwindowsuixamlinputxamluicommand"></a>[XamlUICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.xamluicommand)

XamlUICommand <br> XamlUICommand.AccessKey <br> XamlUICommand.AccessKeyProperty <br> XamlUICommand.CanExecute <br> XamlUICommand.CanExecuteChanged <br> XamlUICommand.CanExecuteRequested <br> XamlUICommand.Command <br> XamlUICommand.CommandProperty <br> XamlUICommand.Description <br> XamlUICommand.DescriptionProperty <br> XamlUICommand.Execute <br> XamlUICommand.ExecuteRequested <br> XamlUICommand.IconSource <br> XamlUICommand.IconSourceProperty <br> XamlUICommand.KeyboardAccelerators <br> XamlUICommand.KeyboardAcceleratorsProperty <br> XamlUICommand.Label <br> XamlUICommand.LabelProperty <br> XamlUICommand.NotifyCanExecuteChanged <br> XamlUICommand。 #ctor

### <a name="windowsuixamlmarkuphttpsdocsmicrosoftcomuwpapiwindowsuixamlmarkup"></a>[Windows.UI.Xaml.Markup](https://docs.microsoft.com/uwp/api/windows.ui.xaml.markup)

#### <a name="fullxamlmetadataproviderattributehttpsdocsmicrosoftcomuwpapiwindowsuixamlmarkupfullxamlmetadataproviderattribute"></a>[FullXamlMetadataProviderAttribute](https://docs.microsoft.com/uwp/api/windows.ui.xaml.markup.fullxamlmetadataproviderattribute)

FullXamlMetadataProviderAttribute <br> FullXamlMetadataProviderAttribute。 #ctor

#### <a name="ixamlbindscopediagnosticshttpsdocsmicrosoftcomuwpapiwindowsuixamlmarkupixamlbindscopediagnostics"></a>[IXamlBindScopeDiagnostics](https://docs.microsoft.com/uwp/api/windows.ui.xaml.markup.ixamlbindscopediagnostics)

IXamlBindScopeDiagnostics <br> IXamlBindScopeDiagnostics.Disable

#### <a name="ixamltype2httpsdocsmicrosoftcomuwpapiwindowsuixamlmarkupixamltype2"></a>[IXamlType2](https://docs.microsoft.com/uwp/api/windows.ui.xaml.markup.ixamltype2)

IXamlType2 <br> IXamlType2.BoxedType

### <a name="windowsuixamlmediaanimationhttpsdocsmicrosoftcomuwpapiwindowsuixamlmediaanimation"></a>[Windows.UI.Xaml.Media.Animation](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.animation)

#### <a name="basicconnectedanimationconfigurationhttpsdocsmicrosoftcomuwpapiwindowsuixamlmediaanimationbasicconnectedanimationconfiguration"></a>[BasicConnectedAnimationConfiguration](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.animation.basicconnectedanimationconfiguration)

BasicConnectedAnimationConfiguration <br> BasicConnectedAnimationConfiguration。 #ctor

#### <a name="connectedanimationhttpsdocsmicrosoftcomuwpapiwindowsuixamlmediaanimationconnectedanimation"></a>[ConnectedAnimation](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.animation.connectedanimation)

ConnectedAnimation.Configuration

#### <a name="connectedanimationconfigurationhttpsdocsmicrosoftcomuwpapiwindowsuixamlmediaanimationconnectedanimationconfiguration"></a>[ConnectedAnimationConfiguration](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.animation.connectedanimationconfiguration)

ConnectedAnimationConfiguration

#### <a name="directconnectedanimationconfigurationhttpsdocsmicrosoftcomuwpapiwindowsuixamlmediaanimationdirectconnectedanimationconfiguration"></a>[DirectConnectedAnimationConfiguration](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.animation.directconnectedanimationconfiguration)

DirectConnectedAnimationConfiguration <br> DirectConnectedAnimationConfiguration。 #ctor

#### <a name="gravityconnectedanimationconfigurationhttpsdocsmicrosoftcomuwpapiwindowsuixamlmediaanimationgravityconnectedanimationconfiguration"></a>[GravityConnectedAnimationConfiguration](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.animation.gravityconnectedanimationconfiguration)

GravityConnectedAnimationConfiguration <br> GravityConnectedAnimationConfiguration。 #ctor

#### <a name="slidenavigationtransitioneffecthttpsdocsmicrosoftcomuwpapiwindowsuixamlmediaanimationslidenavigationtransitioneffect"></a>[SlideNavigationTransitionEffect](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.animation.slidenavigationtransitioneffect)

SlideNavigationTransitionEffect

#### <a name="slidenavigationtransitioninfohttpsdocsmicrosoftcomuwpapiwindowsuixamlmediaanimationslidenavigationtransitioninfo"></a>[SlideNavigationTransitionInfo](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.animation.slidenavigationtransitioninfo)

SlideNavigationTransitionInfo.Effect <br> SlideNavigationTransitionInfo.EffectProperty

### <a name="windowsuixamlmediahttpsdocsmicrosoftcomuwpapiwindowsuixamlmedia"></a>[Windows.UI.Xaml.Media](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media)

#### <a name="brushhttpsdocsmicrosoftcomuwpapiwindowsuixamlmediabrush"></a>[ブラシ](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.brush)

Brush.PopulatePropertyInfo <br> Brush.PopulatePropertyInfoOverride

### <a name="windowsuixamlnavigationhttpsdocsmicrosoftcomuwpapiwindowsuixamlnavigation"></a>[Windows.UI.Xaml.Navigation](https://docs.microsoft.com/uwp/api/windows.ui.xaml.navigation)

#### <a name="framenavigationoptionshttpsdocsmicrosoftcomuwpapiwindowsuixamlnavigationframenavigationoptions"></a>[FrameNavigationOptions](https://docs.microsoft.com/uwp/api/windows.ui.xaml.navigation.framenavigationoptions)

FrameNavigationOptions <br> FrameNavigationOptions。 #ctor <br> FrameNavigationOptions.IsNavigationStackEnabled <br> FrameNavigationOptions.TransitionInfoOverride

### <a name="windowsuixamlhttpsdocsmicrosoftcomuwpapiwindowsuixaml"></a>[Windows.UI.Xaml](https://docs.microsoft.com/uwp/api/windows.ui.xaml)

#### <a name="brushtransitionhttpsdocsmicrosoftcomuwpapiwindowsuixamlbrushtransition"></a>[BrushTransition](https://docs.microsoft.com/uwp/api/windows.ui.xaml.brushtransition)

BrushTransition <br> BrushTransition。 #ctor <br> BrushTransition.Duration

#### <a name="colorpaletteresourceshttpsdocsmicrosoftcomuwpapiwindowsuixamlcolorpaletteresources"></a>[ColorPaletteResources](https://docs.microsoft.com/uwp/api/windows.ui.xaml.colorpaletteresources)

ColorPaletteResources <br> ColorPaletteResources.Accent <br> ColorPaletteResources.AltHigh <br> ColorPaletteResources.AltLow <br> ColorPaletteResources.AltMedium <br> ColorPaletteResources.AltMediumHigh <br> ColorPaletteResources.AltMediumLow <br> ColorPaletteResources.BaseHigh <br> ColorPaletteResources.BaseLow <br> ColorPaletteResources.BaseMedium <br> ColorPaletteResources.BaseMediumHigh <br> ColorPaletteResources.BaseMediumLow <br> ColorPaletteResources.ChromeAltLow <br> ColorPaletteResources.ChromeBlackHigh <br> ColorPaletteResources.ChromeBlackLow <br> ColorPaletteResources.ChromeBlackMedium <br> ColorPaletteResources.ChromeBlackMediumLow <br> ColorPaletteResources.ChromeDisabledHigh <br> ColorPaletteResources.ChromeDisabledLow <br> ColorPaletteResources.ChromeGray <br> ColorPaletteResources.ChromeHigh <br> ColorPaletteResources.ChromeLow <br> ColorPaletteResources.ChromeMedium <br> ColorPaletteResources.ChromeMediumLow <br> ColorPaletteResources.ChromeWhite <br> ColorPaletteResources。 #ctor <br> ColorPaletteResources.ErrorText <br> ColorPaletteResources.ListLow <br> ColorPaletteResources.ListMedium

#### <a name="datatemplatehttpsdocsmicrosoftcomuwpapiwindowsuixamldatatemplate"></a>[DataTemplate](https://docs.microsoft.com/uwp/api/windows.ui.xaml.datatemplate)

DataTemplate.GetElement <br> DataTemplate.RecycleElement

#### <a name="debugsettingshttpsdocsmicrosoftcomuwpapiwindowsuixamldebugsettings"></a>[DebugSettings](https://docs.microsoft.com/uwp/api/windows.ui.xaml.debugsettings)

DebugSettings.FailFastOnErrors

#### <a name="effectiveviewportchangedeventargshttpsdocsmicrosoftcomuwpapiwindowsuixamleffectiveviewportchangedeventargs"></a>[EffectiveViewportChangedEventArgs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.effectiveviewportchangedeventargs)

EffectiveViewportChangedEventArgs <br> EffectiveViewportChangedEventArgs.BringIntoViewDistanceX <br> EffectiveViewportChangedEventArgs.BringIntoViewDistanceY <br> EffectiveViewportChangedEventArgs.EffectiveViewport <br> EffectiveViewportChangedEventArgs.MaxViewport

#### <a name="elementfactorygetargshttpsdocsmicrosoftcomuwpapiwindowsuixamlelementfactorygetargs"></a>[ElementFactoryGetArgs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.elementfactorygetargs)

ElementFactoryGetArgs <br> ElementFactoryGetArgs.Data <br> ElementFactoryGetArgs。 #ctor <br> ElementFactoryGetArgs.Parent

#### <a name="elementfactoryrecycleargshttpsdocsmicrosoftcomuwpapiwindowsuixamlelementfactoryrecycleargs"></a>[ElementFactoryRecycleArgs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.elementfactoryrecycleargs)

ElementFactoryRecycleArgs <br> ElementFactoryRecycleArgs.Element <br> ElementFactoryRecycleArgs。 #ctor <br> ElementFactoryRecycleArgs.Parent

#### <a name="frameworkelementhttpsdocsmicrosoftcomuwpapiwindowsuixamlframeworkelement"></a>[FrameworkElement](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement)

FrameworkElement.EffectiveViewportChanged <br> FrameworkElement.InvalidateViewport <br> FrameworkElement.IsLoaded

#### <a name="ielementfactoryhttpsdocsmicrosoftcomuwpapiwindowsuixamlielementfactory"></a>[IElementFactory](https://docs.microsoft.com/uwp/api/windows.ui.xaml.ielementfactory)

IElementFactory <br> IElementFactory.GetElement <br> IElementFactory.RecycleElement

#### <a name="scalartransitionhttpsdocsmicrosoftcomuwpapiwindowsuixamlscalartransition"></a>[ScalarTransition](https://docs.microsoft.com/uwp/api/windows.ui.xaml.scalartransition)

ScalarTransition <br> ScalarTransition.Duration <br> ScalarTransition。 #ctor

#### <a name="uielementhttpsdocsmicrosoftcomuwpapiwindowsuixamluielement"></a>[UIElement](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement)

UIElement.CanBeScrollAnchor <br> UIElement.CanBeScrollAnchorProperty <br> UIElement.CenterPoint <br> UIElement.OpacityTransition <br> UIElement.PopulatePropertyInfo <br> UIElement.PopulatePropertyInfoOverride <br> UIElement.Rotation <br> UIElement.RotationAxis <br> UIElement.RotationTransition <br> UIElement.Scale <br> UIElement.ScaleTransition <br> UIElement.StartAnimation <br> UIElement.StopAnimation <br> UIElement.TransformMatrix <br> UIElement.Translation <br> UIElement.TranslationTransition

#### <a name="vector3transitionhttpsdocsmicrosoftcomuwpapiwindowsuixamlvector3transition"></a>[Vector3Transition](https://docs.microsoft.com/uwp/api/windows.ui.xaml.vector3transition)

Vector3Transition <br> Vector3Transition.Components <br> Vector3Transition.Duration <br> Vector3Transition #ctor。

#### <a name="vector3transitioncomponentshttpsdocsmicrosoftcomuwpapiwindowsuixamlvector3transitioncomponents"></a>[Vector3TransitionComponents](https://docs.microsoft.com/uwp/api/windows.ui.xaml.vector3transitioncomponents)

Vector3TransitionComponents

## <a name="windowsweb"></a>Windows.Web

### <a name="windowswebuiinterophttpsdocsmicrosoftcomuwpapiwindowswebuiinterop"></a>[Windows.Web.UI.Interop](https://docs.microsoft.com/uwp/api/windows.web.ui.interop)

#### <a name="webviewcontrolhttpsdocsmicrosoftcomuwpapiwindowswebuiinteropwebviewcontrol"></a>[WebViewControl](https://docs.microsoft.com/uwp/api/windows.web.ui.interop.webviewcontrol)

WebViewControl.AddInitializeScript <br> WebViewControl.GotFocus <br> WebViewControl.LostFocus

### <a name="windowswebuihttpsdocsmicrosoftcomuwpapiwindowswebui"></a>[Windows.Web.UI](https://docs.microsoft.com/uwp/api/windows.web.ui)

#### <a name="iwebviewcontrol2httpsdocsmicrosoftcomuwpapiwindowswebuiiwebviewcontrol2"></a>[IWebViewControl2](https://docs.microsoft.com/uwp/api/windows.web.ui.iwebviewcontrol2)

IWebViewControl2 <br> IWebViewControl2.AddInitializeScript
