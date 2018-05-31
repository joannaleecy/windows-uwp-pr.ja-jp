---
Description: The JavaScript API for the Microsoft Take a Test app allows you to do secure assessments. Take a Test provides a secure browser that prevents students from using other computer or internet resources during a test.
title: テスト JavaScript API。
author: PatrickFarley
ms.author: pafarley
ms.assetid: 9bff6318-504c-4d0e-ba80-1a5ea45743da
ms.date: 10/06/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 43edadfba169ddae85818f8ef1dbd1e7f4adba64
ms.sourcegitcommit: 6618517dc0a4e4100af06e6d27fac133d317e545
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/28/2018
ms.locfileid: "1691361"
---
# <a name="take-a-test-javascript-api"></a><span data-ttu-id="31838-103">テスト JavaScript API</span><span class="sxs-lookup"><span data-stu-id="31838-103">Take a Test JavaScript API</span></span>

<span data-ttu-id="31838-104">[テスト](https://technet.microsoft.com/edu/windows/take-tests-in-windows-10)は、重大な影響をもたらすテストに対応した、厳正なオンライン評価を提供するブラウザー ベースのアプリです。これにより、教育者はセキュリティ保護されたテスト環境を提供する方法ではなく、コンテンツの評価に集中することができます。</span><span class="sxs-lookup"><span data-stu-id="31838-104">[Take a Test](https://technet.microsoft.com/edu/windows/take-tests-in-windows-10) is a browser-based app that renders locked down online assessments for high-stakes testing, allowing educators to focus on the assessment content rather than how to provide a secure testing environment.</span></span> <span data-ttu-id="31838-105">これを実現するには、任意の Web アプリケーションで利用できる JavaScript API を使用します。</span><span class="sxs-lookup"><span data-stu-id="31838-105">To achieve this, it uses a JavaScript API that any web application can utilize.</span></span> <span data-ttu-id="31838-106">テスト API は、重要な共通学力テストの [SBAC ブラウザー API 標準](http://www.smarterapp.org/documents/SecureBrowserRequirementsSpecifications_0-3.pdf)に対応しています。</span><span class="sxs-lookup"><span data-stu-id="31838-106">The Take-a-test API supports the [SBAC browser API standard](http://www.smarterapp.org/documents/SecureBrowserRequirementsSpecifications_0-3.pdf) for high stakes common core testing.</span></span>

<span data-ttu-id="31838-107">アプリ自体の詳細については、「[テスト アプリ技術リファレンス](https://technet.microsoft.com/edu/windows/take-a-test-app-technical?f=255&MSPPError=-2147217396)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="31838-107">See the [Take a Test app technical reference](https://technet.microsoft.com/edu/windows/take-a-test-app-technical?f=255&MSPPError=-2147217396) for more information about the app itself.</span></span>

<span data-ttu-id="31838-108">トラブルシューティングについては、「[イベント ビューアーを使用して、Microsoft テストをトラブルシューティングする](troubleshooting.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="31838-108">For troubleshooting help, see [Troubleshoot Microsoft Take a Test with the event viewer](troubleshooting.md).</span></span>

## <a name="reference-documentation"></a><span data-ttu-id="31838-109">リファレンス ドキュメント</span><span class="sxs-lookup"><span data-stu-id="31838-109">Reference documentation</span></span>
<span data-ttu-id="31838-110">テスト API は、次の名前空間に存在します。</span><span class="sxs-lookup"><span data-stu-id="31838-110">The Take a Test APIs exist in the following namespaces.</span></span> <span data-ttu-id="31838-111">すべての API は、グローバルな `SecureBrowser` オブジェクトに依存する点に注意してください。</span><span class="sxs-lookup"><span data-stu-id="31838-111">Note that all of the APIs depend on a global `SecureBrowser` object.</span></span>

| <span data-ttu-id="31838-112">名前空間</span><span class="sxs-lookup"><span data-stu-id="31838-112">Namespace</span></span> | <span data-ttu-id="31838-113">説明</span><span class="sxs-lookup"><span data-stu-id="31838-113">Description</span></span> |
|-----------|-------------|
|[<span data-ttu-id="31838-114">セキュリティ名前空間</span><span class="sxs-lookup"><span data-stu-id="31838-114">security namespace</span></span>](#security-namespace)|<span data-ttu-id="31838-115">テストのためにデバイスをロックダウンし、テスト環境を強化できるようにする API が含まれます。</span><span class="sxs-lookup"><span data-stu-id="31838-115">Contains APIs that enable you to lock down the device for testing and enforce a testing environment.</span></span> |

> [!NOTE]
> <span data-ttu-id="31838-116">音声合成 (TTS) 名前空間は、Windows 10 バージョン 1709 以降で削除されました。</span><span class="sxs-lookup"><span data-stu-id="31838-116">The text-to-speech (TTS) namespace has been removed as of Windows 10 version 1709.</span></span> <span data-ttu-id="31838-117">[W3C Speech Api](https://dvcs.w3.org/hg/speech-api/raw-file/tip/webspeechapi.html) の実装である [Microsoft Edge 音声合成 API](https://blogs.windows.com/msedgedev/2016/06/01/introducing-speech-synthesis-api/) は、現在、音声合成の実装のための推奨されるソリューションです。</span><span class="sxs-lookup"><span data-stu-id="31838-117">The [Microsoft Edge Speech Synthesis API](https://blogs.windows.com/msedgedev/2016/06/01/introducing-speech-synthesis-api/), an implementation of the [W3C Speech Api](https://dvcs.w3.org/hg/speech-api/raw-file/tip/webspeechapi.html), is now the recommended solution for text-to-speech implementation.</span></span>

### <a name="security-namespace"></a><span data-ttu-id="31838-118">セキュリティ名前空間</span><span class="sxs-lookup"><span data-stu-id="31838-118">Security namespace</span></span>

<span data-ttu-id="31838-119">セキュリティ名前空間を使用すると、デバイスのロックダウン、ユーザー プロセスとシステム プロセスの一覧の確認、MAC および IP アドレスの取得、キャッシュされている Web リソースのクリアを行うことができます。</span><span class="sxs-lookup"><span data-stu-id="31838-119">The security namespace you to lock down the device, check the list of user and system processes, obtain MAC and IP addresses, and clear cached web resources.</span></span>

| <span data-ttu-id="31838-120">方法</span><span class="sxs-lookup"><span data-stu-id="31838-120">Method</span></span> | <span data-ttu-id="31838-121">説明</span><span class="sxs-lookup"><span data-stu-id="31838-121">Description</span></span>   |
|--------|---------------|
|[<span data-ttu-id="31838-122">lockDown</span><span class="sxs-lookup"><span data-stu-id="31838-122">lockDown</span></span>](#lockDown) | <span data-ttu-id="31838-123">テストのためにデバイスをロックダウンします。</span><span class="sxs-lookup"><span data-stu-id="31838-123">Locks down the device for testing.</span></span> |
|[<span data-ttu-id="31838-124">isEnvironmentSecure</span><span class="sxs-lookup"><span data-stu-id="31838-124">isEnvironmentSecure</span></span>](#isEnvironmentSecure) | <span data-ttu-id="31838-125">ロックダウン コンテキストがデバイスにまだ適用されるかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="31838-125">Determines whether the lockdown context is still applied to the device.</span></span> |
|[<span data-ttu-id="31838-126">getDeviceInfo</span><span class="sxs-lookup"><span data-stu-id="31838-126">getDeviceInfo</span></span>](#getDeviceInfo) | <span data-ttu-id="31838-127">テスト アプリケーションが実行されているプラットフォームの詳細を取得します。</span><span class="sxs-lookup"><span data-stu-id="31838-127">Gets details about the platform on which the testing application is running.</span></span> |
|[<span data-ttu-id="31838-128">examineProcessList</span><span class="sxs-lookup"><span data-stu-id="31838-128">examineProcessList</span></span>](#examineProcessList)|<span data-ttu-id="31838-129">実行中のユーザーとシステム プロセスの一覧を取得します。</span><span class="sxs-lookup"><span data-stu-id="31838-129">Gets the list of running user and system processes.</span></span>|
|[<span data-ttu-id="31838-130">close</span><span class="sxs-lookup"><span data-stu-id="31838-130">close</span></span>](#close) | <span data-ttu-id="31838-131">ブラウザーを閉じて、デバイスのロックを解除します。</span><span class="sxs-lookup"><span data-stu-id="31838-131">Closes the browser and unlocks the device.</span></span> |
|[<span data-ttu-id="31838-132">getPermissiveMode</span><span class="sxs-lookup"><span data-stu-id="31838-132">getPermissiveMode</span></span>](#getPermissiveMode)|<span data-ttu-id="31838-133">制限解除モードがオンまたはオフかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="31838-133">Checks if permissive mode is on or off.</span></span>|
|[<span data-ttu-id="31838-134">setPermissiveMode</span><span class="sxs-lookup"><span data-stu-id="31838-134">setPermissiveMode</span></span>](#setPermissiveMode)|<span data-ttu-id="31838-135">制限解除モードのオンとオフを切り替えます。</span><span class="sxs-lookup"><span data-stu-id="31838-135">Toggles permissive mode on or off.</span></span>|
|[<span data-ttu-id="31838-136">emptyClipBoard</span><span class="sxs-lookup"><span data-stu-id="31838-136">emptyClipBoard</span></span>](#emptyClipBoard)|<span data-ttu-id="31838-137">システム クリップボードがクリアされます。</span><span class="sxs-lookup"><span data-stu-id="31838-137">Clears the system clipboard.</span></span>|
|[<span data-ttu-id="31838-138">getMACAddress</span><span class="sxs-lookup"><span data-stu-id="31838-138">getMACAddress</span></span>](#getMACAddress)|<span data-ttu-id="31838-139">デバイスの MAC アドレスの一覧を取得します。</span><span class="sxs-lookup"><span data-stu-id="31838-139">Gets the list of MAC addresses for the device.</span></span>|
|[<span data-ttu-id="31838-140">getStartTime</span><span class="sxs-lookup"><span data-stu-id="31838-140">getStartTime</span></span>](#getStartTime) | <span data-ttu-id="31838-141">テスト アプリが開始された時刻を取得します。</span><span class="sxs-lookup"><span data-stu-id="31838-141">Gets the time that the testing app was started.</span></span> |
|[<span data-ttu-id="31838-142">getCapability</span><span class="sxs-lookup"><span data-stu-id="31838-142">getCapability</span></span>](#getCapability) | <span data-ttu-id="31838-143">機能が有効であるか、無効であるかを照会します。</span><span class="sxs-lookup"><span data-stu-id="31838-143">Queries whether a capability is enabled or disabled.</span></span> |
|[<span data-ttu-id="31838-144">setCapability</span><span class="sxs-lookup"><span data-stu-id="31838-144">setCapability</span></span>](#setCapability)|<span data-ttu-id="31838-145">指定された機能を有効または無効にします。</span><span class="sxs-lookup"><span data-stu-id="31838-145">Enables or disables the specified capability.</span></span>| 
|[<span data-ttu-id="31838-146">isRemoteSession</span><span class="sxs-lookup"><span data-stu-id="31838-146">isRemoteSession</span></span>](#isRemoteSession) | <span data-ttu-id="31838-147">現在のセッションがリモートからログインされているかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="31838-147">Checks if the current session is logged in remotely.</span></span> |
|[<span data-ttu-id="31838-148">isVMSession</span><span class="sxs-lookup"><span data-stu-id="31838-148">isVMSession</span></span>](#isVMSession) | <span data-ttu-id="31838-149">現在のセッションが、仮想マシンで実行されているかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="31838-149">Checks if the current session is running in a virtual machine.</span></span> |

---

<span id="lockDown"/>

### <a name="lockdown"></a><span data-ttu-id="31838-150">lockDown</span><span class="sxs-lookup"><span data-stu-id="31838-150">lockDown</span></span>
<span data-ttu-id="31838-151">デバイスをロックダウンします。</span><span class="sxs-lookup"><span data-stu-id="31838-151">Locks down the device.</span></span> <span data-ttu-id="31838-152">デバイスのロック解除にも使用します。</span><span class="sxs-lookup"><span data-stu-id="31838-152">Also used to unlock the device.</span></span> <span data-ttu-id="31838-153">テスト Web アプリケーションは、受講者がテストを開始できるようにする前にこの呼び出しを起動します。</span><span class="sxs-lookup"><span data-stu-id="31838-153">The testing web application will invoke this call prior to allowing students to start testing.</span></span> <span data-ttu-id="31838-154">この実装は、テスト環境をセキュリティで保護するために必要なすべてのアクションを実行するために必要です。</span><span class="sxs-lookup"><span data-stu-id="31838-154">The implementer is required to take any actions necessary to secure the testing environment.</span></span> <span data-ttu-id="31838-155">環境をセキュリティで保護するために実行する手順はデバイス固有です。この手順には、たとえば、画面のキャプチャを無効にする、保護モードのときにボイス チャットを無効にする、システム クリップボードをクリアする、キオスク モードに移行する、OSX 10.7 以降のデバイスでスペースを無効にするなどの側面が含まれます。テスト アプリケーションは、評価が開始する前にロックダウンを有効にし、受講者が評価を完了してセキュリティ保護されたテストを終了したときにロックダウンを無効にします。</span><span class="sxs-lookup"><span data-stu-id="31838-155">The steps taken to secure the environment are device specific and for example, include aspects such as disabling screen captures, disabling voice chat when in secure mode, clearing the system clipboard, entering into a kiosk mode, disabling Spaces in OSX 10.7+ devices, etc. The testing application will enable lockdown before an assessment commences and will disable the lockdown when the student has completed the assessment and is out of the secure test.</span></span>

**<span data-ttu-id="31838-156">構文</span><span class="sxs-lookup"><span data-stu-id="31838-156">Syntax</span></span>**  
`void SecureBrowser.security.lockDown(Boolean enable, Function onSuccess, Function onError);`

**<span data-ttu-id="31838-157">パラメーター</span><span class="sxs-lookup"><span data-stu-id="31838-157">Parameters</span></span>**  
* `enable`<span data-ttu-id="31838-158"> - **true** は、ロック画面上でテスト アプリを実行し、この[ドキュメント](https://technet.microsoft.com/edu/windows/take-a-test-app-technical?f=255&MSPPError=-2147217396)で説明されているポリシーを適用します。</span><span class="sxs-lookup"><span data-stu-id="31838-158"> - **true** to run the Take-a-Test app above the lock screen and apply policies discussed in this [document](https://technet.microsoft.com/edu/windows/take-a-test-app-technical?f=255&MSPPError=-2147217396).</span></span> <span data-ttu-id="31838-159">**false** は、アプリがロックダウンされていない場合は、ロック画面上で実行しているテスト アプリを停止して閉じます。アプリがロックダウンされている場合は、何も行われません。</span><span class="sxs-lookup"><span data-stu-id="31838-159">**false** stops running Take-a-Test above the lock screen and closes it unless the app is not locked down; in which case there is no effect.</span></span>  
* `onSuccess` <span data-ttu-id="31838-160">- [オプション] ロックダウンが正常に有効または無効にされた後で呼び出す関数です。</span><span class="sxs-lookup"><span data-stu-id="31838-160">- [optional] The function to call after the lockdown has been successfully enabled or disabled.</span></span> <span data-ttu-id="31838-161">`Function(Boolean currentlockdownstate)` という形式にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="31838-161">It must be of the form `Function(Boolean currentlockdownstate)`.</span></span>  
* `onError` <span data-ttu-id="31838-162">- [オプション] ロックダウン操作に失敗した場合に呼び出す関数です。</span><span class="sxs-lookup"><span data-stu-id="31838-162">- [optional] The function to call if the lockdown operation failed.</span></span> <span data-ttu-id="31838-163">`Function(Boolean currentlockdownstate)` という形式にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="31838-163">It must be of the form `Function(Boolean currentlockdownstate)`.</span></span>  

**<span data-ttu-id="31838-164">要件</span><span class="sxs-lookup"><span data-stu-id="31838-164">Requirements</span></span>**  
<span data-ttu-id="31838-165">Windows 10 バージョン 1709</span><span class="sxs-lookup"><span data-stu-id="31838-165">Windows 10, version 1709</span></span>

---

<span id="isEnvironmentSecure" />

### <a name="isenvironmentsecure"></a><span data-ttu-id="31838-166">isEnvironmentSecure</span><span class="sxs-lookup"><span data-stu-id="31838-166">isEnvironmentSecure</span></span>
<span data-ttu-id="31838-167">ロックダウン コンテキストがデバイスにまだ適用されるかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="31838-167">Determines whether the lockdown context is still applied to the device.</span></span> <span data-ttu-id="31838-168">テスト Web アプリケーションは、受講者がテストを開始できるようにする前に、また受講者がテスト内にいる場合に定期的にこれを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="31838-168">The testing web application will invoke this prior to allowing students to start testing and periodically when inside the test.</span></span>

**<span data-ttu-id="31838-169">構文</span><span class="sxs-lookup"><span data-stu-id="31838-169">Syntax</span></span>**  
`void SecureBrowser.security.isEnvironmentSecure(Function callback);`

**<span data-ttu-id="31838-170">パラメーター</span><span class="sxs-lookup"><span data-stu-id="31838-170">Parameters</span></span>**  
* `callback` <span data-ttu-id="31838-171">- この関数が完了したときに呼び出す関数です。</span><span class="sxs-lookup"><span data-stu-id="31838-171">- The function to call when this function completes.</span></span> <span data-ttu-id="31838-172">`Function(String state)` という形式にする必要があります。ここでは、`state` は 2 つのフィールドを含む JSON 文字列です。</span><span class="sxs-lookup"><span data-stu-id="31838-172">It must be of the form `Function(String state)` where `state` is a JSON string containing two fields.</span></span> <span data-ttu-id="31838-173">1 つ目は `secure` フィールドで、必要なすべてのロックが有効化 (または機能が無効化) され、テスト環境をセキュリティ保護できるようにする場合にのみ `true` を表示します。アプリがロックダウン モードに入ってから、いずれのロックも侵害されていません。</span><span class="sxs-lookup"><span data-stu-id="31838-173">The first is the `secure` field, which will show `true` only if all necessary locks have been enabled (or features disabled) to enable a secure testing environment, and none of these have been compromised since the app entered the lockdown mode.</span></span> <span data-ttu-id="31838-174">もう 1 つのフィールド `messageKey` には、その他の詳細またはベンダー固有の情報が含まれます。</span><span class="sxs-lookup"><span data-stu-id="31838-174">The other field, `messageKey`, includes other details or information that is vendor-specific.</span></span> <span data-ttu-id="31838-175">ここでの意図は、ベンダーがブール値 `secure` フラグを強化する追加の情報を含めることができるようにすることです。</span><span class="sxs-lookup"><span data-stu-id="31838-175">The intent here is to allow vendors to put additional information that augments the boolean `secure` flag:</span></span>

```JSON
{
    'secure' : "true/false",
    'messageKey' : "some message"
}
```

**<span data-ttu-id="31838-176">要件</span><span class="sxs-lookup"><span data-stu-id="31838-176">Requirements</span></span>**  
<span data-ttu-id="31838-177">Windows 10 バージョン 1709</span><span class="sxs-lookup"><span data-stu-id="31838-177">Windows 10, version 1709</span></span>

---

<span id="getDeviceInfo" />

### <a name="getdeviceinfo"></a><span data-ttu-id="31838-178">getDeviceInfo</span><span class="sxs-lookup"><span data-stu-id="31838-178">getDeviceInfo</span></span>
<span data-ttu-id="31838-179">テスト アプリケーションが実行されているプラットフォームの詳細を取得します。</span><span class="sxs-lookup"><span data-stu-id="31838-179">Gets details about the platform on which the testing application is running.</span></span> <span data-ttu-id="31838-180">これは、ユーザー エージェントから認識できるすべての情報を拡張するために使用されます。</span><span class="sxs-lookup"><span data-stu-id="31838-180">This is used to augment any information that was discernible from the user agent.</span></span>

**<span data-ttu-id="31838-181">構文</span><span class="sxs-lookup"><span data-stu-id="31838-181">Syntax</span></span>**  
`void SecureBrowser.security.getDeviceInfo(Function callback);`

**<span data-ttu-id="31838-182">パラメーター</span><span class="sxs-lookup"><span data-stu-id="31838-182">Parameters</span></span>**  
* `callback` <span data-ttu-id="31838-183">- この関数が完了したときに呼び出す関数です。</span><span class="sxs-lookup"><span data-stu-id="31838-183">- The function to call when this function completes.</span></span> <span data-ttu-id="31838-184">`Function(String infoObj)` という形式にする必要があります。ここでは、`infoObj` は複数のフィールドを含む JSON 文字列です。</span><span class="sxs-lookup"><span data-stu-id="31838-184">It must be of the form `Function(String infoObj)` where `infoObj` is a JSON string containing several fields.</span></span> <span data-ttu-id="31838-185">次のフィールドがサポートされる必要があります。</span><span class="sxs-lookup"><span data-stu-id="31838-185">The following fields must be supported:</span></span>
    * `os` <span data-ttu-id="31838-186">OS の種類を表します (例: Windows、macOS、Linux、iOS、Android)。</span><span class="sxs-lookup"><span data-stu-id="31838-186">represents the OS type (for example: Windows, macOS, Linux, iOS, Android, etc.)</span></span>
    * `name` <span data-ttu-id="31838-187">存在する場合、OS リリースの名前を表します (例: シエラ、Ubuntu)。</span><span class="sxs-lookup"><span data-stu-id="31838-187">represents the OS release name, if any (for example: Sierra, Ubuntu).</span></span>
    * `version` <span data-ttu-id="31838-188">OS バージョンを表します (例: 10.1、10 Pro)。</span><span class="sxs-lookup"><span data-stu-id="31838-188">represents the OS version (for example: 10.1, 10 Pro, etc.)</span></span>
    * `brand` <span data-ttu-id="31838-189">セキュリティで保護されたブラウザーのブランドを表します (例: OAKS、CA、SmarterApp)。</span><span class="sxs-lookup"><span data-stu-id="31838-189">represents the secure browser branding (for example: OAKS, CA, SmarterApp, etc.)</span></span>
    * `model` <span data-ttu-id="31838-190">モバイル デバイスのデバイス モデルのみを表します。デスクトップ ブラウザーに対しては null または未使用です。</span><span class="sxs-lookup"><span data-stu-id="31838-190">represents the device model for mobile devices only; null/unused for desktop browsers.</span></span>

**<span data-ttu-id="31838-191">要件</span><span class="sxs-lookup"><span data-stu-id="31838-191">Requirements</span></span>**  
<span data-ttu-id="31838-192">Windows 10 バージョン 1709</span><span class="sxs-lookup"><span data-stu-id="31838-192">Windows 10, version 1709</span></span>

---

<span id="examineProcessList" />

### <a name="examineprocesslist"></a><span data-ttu-id="31838-193">examineProcessList</span><span class="sxs-lookup"><span data-stu-id="31838-193">examineProcessList</span></span>
<span data-ttu-id="31838-194">ユーザーが所有するクライアント コンピューター上で実行されているすべてのプロセスの一覧を取得します。</span><span class="sxs-lookup"><span data-stu-id="31838-194">Gets the list of all processes running on the client machine owned by the user.</span></span> <span data-ttu-id="31838-195">テスト アプリケーションはこれを呼び出して一覧を確認し、テスト サイクル中にブラックリストの対象と見なされたプロセスの一覧と比較します。</span><span class="sxs-lookup"><span data-stu-id="31838-195">The testing application will invoke this to examine the list and compare it with a list of processes that have been deemed blacklisted during testing cycle.</span></span> <span data-ttu-id="31838-196">この呼び出しは、評価の開始時と、受講者が評価を受ける間に定期的に呼び出される必要があります。</span><span class="sxs-lookup"><span data-stu-id="31838-196">This call should be invoked both at the start of an assessment and periodically while the student is taking the assessment.</span></span> <span data-ttu-id="31838-197">ブラックリストに追加したプロセスが検出された場合は、テストの整合性を保つために評価を停止する必要があります。</span><span class="sxs-lookup"><span data-stu-id="31838-197">If a blacklisted process is detected, the assessment should be stopped to preserve test integrity.</span></span>

**<span data-ttu-id="31838-198">構文</span><span class="sxs-lookup"><span data-stu-id="31838-198">Syntax</span></span>**  
`void SecureBrowser.security.examineProcessList(String[] blacklistedProcessList, Function callback);`

**<span data-ttu-id="31838-199">パラメーター</span><span class="sxs-lookup"><span data-stu-id="31838-199">Parameters</span></span>**  
* `blacklistedProcessList` <span data-ttu-id="31838-200">- テスト アプリケーションがブラック リストに追加した評価の一覧です。</span><span class="sxs-lookup"><span data-stu-id="31838-200">- The list of processes that the testing application has blacklisted.</span></span>  
`callback` <span data-ttu-id="31838-201">- アクティブなプロセスが見つかった後で呼び出す関数です。</span><span class="sxs-lookup"><span data-stu-id="31838-201">- The function to invoke once the active processes have been found.</span></span> <span data-ttu-id="31838-202">`Function(String foundBlacklistedProcesses)` という形式にする必要があります。ここでは、`foundBlacklistedProcesses` は `"['process1.exe','process2.exe','processEtc.exe']"` という形式になります。</span><span class="sxs-lookup"><span data-stu-id="31838-202">It must be in the form: `Function(String foundBlacklistedProcesses)` where `foundBlacklistedProcesses` is in the form: `"['process1.exe','process2.exe','processEtc.exe']"`.</span></span> <span data-ttu-id="31838-203">ブラック リストに追加されたプロセスが見つからなかった場合は、空になります。</span><span class="sxs-lookup"><span data-stu-id="31838-203">It will be empty if no blacklisted processes were found.</span></span> <span data-ttu-id="31838-204">Null の場合、元の関数呼び出しでエラーが発生したことを示します。</span><span class="sxs-lookup"><span data-stu-id="31838-204">If it is null, this indicates that an error occurred in the original function call.</span></span>

<span data-ttu-id="31838-205">**解説** 一覧にはシステム プロセスは含まれません。</span><span class="sxs-lookup"><span data-stu-id="31838-205">**Remarks** The list does not include system processes.</span></span>

**<span data-ttu-id="31838-206">要件</span><span class="sxs-lookup"><span data-stu-id="31838-206">Requirements</span></span>**  
<span data-ttu-id="31838-207">Windows 10 バージョン 1709</span><span class="sxs-lookup"><span data-stu-id="31838-207">Windows 10, version 1709</span></span>

---

<span id="close"/>

### <a name="close"></a><span data-ttu-id="31838-208">close</span><span class="sxs-lookup"><span data-stu-id="31838-208">close</span></span>
<span data-ttu-id="31838-209">ブラウザーを閉じて、デバイスのロックを解除します。</span><span class="sxs-lookup"><span data-stu-id="31838-209">Closes the browser and unlocks the device.</span></span> <span data-ttu-id="31838-210">ユーザーがブラウザーを終了するときに、テスト アプリケーションでこれを呼び出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="31838-210">The testing application should invoke this when the user elects to exit the browser.</span></span>

**<span data-ttu-id="31838-211">構文</span><span class="sxs-lookup"><span data-stu-id="31838-211">Syntax</span></span>**  
`void SecureBrowser.security.close(restart);`

**<span data-ttu-id="31838-212">パラメーター</span><span class="sxs-lookup"><span data-stu-id="31838-212">Parameters</span></span>**  
* `restart` <span data-ttu-id="31838-213">- このパラメーターは無視されますが、指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="31838-213">- This parameter is ignored but must be provided.</span></span>

<span data-ttu-id="31838-214">**解説** Windows 10 バージョン 1607 では、最初にデバイスをロックダウンする必要があります。</span><span class="sxs-lookup"><span data-stu-id="31838-214">**Remarks** In Windows 10, version 1607, the device must be locked down initially.</span></span> <span data-ttu-id="31838-215">以降のバージョンでは、このメソッドは、デバイスがロックダウンされているかどうかに関係なく、ブラウザーを閉じます。</span><span class="sxs-lookup"><span data-stu-id="31838-215">In later versions, this method closes the browser regardless of whether the device is locked down.</span></span>

**<span data-ttu-id="31838-216">要件</span><span class="sxs-lookup"><span data-stu-id="31838-216">Requirements</span></span>**  
<span data-ttu-id="31838-217">Windows 10 バージョン 1709</span><span class="sxs-lookup"><span data-stu-id="31838-217">Windows 10, version 1709</span></span>

---

<span id="getPermissiveMode" />

### <a name="getpermissivemode"></a><span data-ttu-id="31838-218">getPermissiveMode</span><span class="sxs-lookup"><span data-stu-id="31838-218">getPermissiveMode</span></span>
<span data-ttu-id="31838-219">テスト Web アプリケーションは、制限解除モードがオンまたはオフかどうかを判断するためにこれを呼び出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="31838-219">The testing web application should invoke this to determine if permissive mode is on or off.</span></span> <span data-ttu-id="31838-220">制限解除モードで、ブラウザーは、いくつかのセキュリティで保護された厳格なフックを緩和し、支援技術がセキュリティ保護されたブラウザーで動作できるようにすることが求められます。</span><span class="sxs-lookup"><span data-stu-id="31838-220">In permissive mode, a browser is expected to relax some of its stringent security hooks to allow assistive technology to work with the secure browser.</span></span> <span data-ttu-id="31838-221">たとえば、他のアプリケーション UI がブラウザーの最上位に表示されるのを積極的に防止するブラウザーでは、制限解除モードのときにこれを緩和する必要があります。</span><span class="sxs-lookup"><span data-stu-id="31838-221">For example, browsers that aggressively prevent other application UIs from presenting on top of them might want to relax this when in permissive mode.</span></span> 

**<span data-ttu-id="31838-222">構文</span><span class="sxs-lookup"><span data-stu-id="31838-222">Syntax</span></span>**  
`void SecureBrowser.security.getPermissiveMode(Function callback)`

**<span data-ttu-id="31838-223">パラメーター</span><span class="sxs-lookup"><span data-stu-id="31838-223">Parameters</span></span>**  
* `callback` <span data-ttu-id="31838-224">- この呼び出しが完了したときに呼び出す関数です。</span><span class="sxs-lookup"><span data-stu-id="31838-224">- The function to invoke when this call completes.</span></span> <span data-ttu-id="31838-225">`Function(Boolean permissiveMode)` という形式にする必要があります。ここでは、`permissiveMode` はブラウザーが現在、制限解除モードであるかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="31838-225">It must be in the form: `Function(Boolean permissiveMode)` where `permissiveMode` indicates whether the browser is currently in permissive mode.</span></span> <span data-ttu-id="31838-226">定義されていないか null の場合は、Get 操作でエラーが発生しました。</span><span class="sxs-lookup"><span data-stu-id="31838-226">If it is undefined or null, an error occurred in the get operation.</span></span>

**<span data-ttu-id="31838-227">要件</span><span class="sxs-lookup"><span data-stu-id="31838-227">Requirements</span></span>**  
<span data-ttu-id="31838-228">Windows 10 バージョン 1709</span><span class="sxs-lookup"><span data-stu-id="31838-228">Windows 10, version 1709</span></span>

---

<span id="setPermissiveMode" />

### <a name="setpermissivemode"></a><span data-ttu-id="31838-229">setPermissiveMode</span><span class="sxs-lookup"><span data-stu-id="31838-229">setPermissiveMode</span></span>
<span data-ttu-id="31838-230">テストの Web アプリケーションには、寛容モードのオンとオフを切り替えるのにこれを呼び出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="31838-230">The testing web application should invoke this to toggle permissive mode on or off.</span></span> <span data-ttu-id="31838-231">制限解除モードで、ブラウザーは、いくつかのセキュリティで保護された厳格なフックを緩和し、支援技術がセキュリティ保護されたブラウザーで動作できるようにすることが求められます。</span><span class="sxs-lookup"><span data-stu-id="31838-231">In permissive mode, a browser is expected to relax some of its stringent security hooks to allow assistive technology to work with the secure browser.</span></span> <span data-ttu-id="31838-232">たとえば、他のアプリケーション UI がブラウザーの最上位に表示されるのを積極的に防止するブラウザーでは、制限解除モードのときにこれを緩和する必要があります。</span><span class="sxs-lookup"><span data-stu-id="31838-232">For example, browsers that aggressively prevent other application UIs from presenting on top of them might want to relax this when in permissive mode.</span></span> 

**<span data-ttu-id="31838-233">構文</span><span class="sxs-lookup"><span data-stu-id="31838-233">Syntax</span></span>**  
`void SecureBrowser.security.setPermissiveMode(Boolean enable, Function callback)`

**<span data-ttu-id="31838-234">パラメーター</span><span class="sxs-lookup"><span data-stu-id="31838-234">Parameters</span></span>**  
* `enable` <span data-ttu-id="31838-235">- 目的の制限解除モードの状態を示すための Boolean 値。</span><span class="sxs-lookup"><span data-stu-id="31838-235">- The Boolean value indicating the intended permissive mode status.</span></span>  
* `callback` <span data-ttu-id="31838-236">- この呼び出しが完了したときに呼び出す関数です。</span><span class="sxs-lookup"><span data-stu-id="31838-236">- The function to invoke when this call completes.</span></span> <span data-ttu-id="31838-237">`Function(Boolean permissiveMode)` という形式にする必要があります。ここでは、`permissiveMode` はブラウザーが現在、制限解除モードであるかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="31838-237">It must be in the form: `Function(Boolean permissiveMode)` where `permissiveMode` indicates whether the browser is currently in permissive mode.</span></span> <span data-ttu-id="31838-238">定義されていないか null の場合は、Set 操作でエラーが発生しました。</span><span class="sxs-lookup"><span data-stu-id="31838-238">If it is undefined or null, an error occurred in the set operation.</span></span>

**<span data-ttu-id="31838-239">要件</span><span class="sxs-lookup"><span data-stu-id="31838-239">Requirements</span></span>**  
<span data-ttu-id="31838-240">Windows 10 バージョン 1709</span><span class="sxs-lookup"><span data-stu-id="31838-240">Windows 10, version 1709</span></span>

---

<span id="emptyClipBoard"/>

### <a name="emptyclipboard"></a><span data-ttu-id="31838-241">emptyClipBoard</span><span class="sxs-lookup"><span data-stu-id="31838-241">emptyClipBoard</span></span>
<span data-ttu-id="31838-242">システム クリップボードがクリアされます。</span><span class="sxs-lookup"><span data-stu-id="31838-242">Clears the system clipboard.</span></span> <span data-ttu-id="31838-243">テスト アプリケーションは、これを呼び出して、システム クリップボードに保存されている可能性があるデータを強制的にクリアする必要があります。</span><span class="sxs-lookup"><span data-stu-id="31838-243">The testing application should invoke this to force clear any data that may be stored in the system clipboard.</span></span> <span data-ttu-id="31838-244">**[lockDown](#lockDown)** 関数もこの操作を実行します。</span><span class="sxs-lookup"><span data-stu-id="31838-244">The **[lockDown](#lockDown)** function also performs this operation.</span></span>

**<span data-ttu-id="31838-245">構文</span><span class="sxs-lookup"><span data-stu-id="31838-245">Syntax</span></span>**  
`void SecureBrowser.security.emptyClipBoard();`

**<span data-ttu-id="31838-246">要件</span><span class="sxs-lookup"><span data-stu-id="31838-246">Requirements</span></span>**  
<span data-ttu-id="31838-247">Windows 10 バージョン 1709</span><span class="sxs-lookup"><span data-stu-id="31838-247">Windows 10, version 1709</span></span>

---

<span id="getMACAddress" />

### <a name="getmacaddress"></a><span data-ttu-id="31838-248">getMACAddress</span><span class="sxs-lookup"><span data-stu-id="31838-248">getMACAddress</span></span>
<span data-ttu-id="31838-249">デバイスの MAC アドレスの一覧を取得します。</span><span class="sxs-lookup"><span data-stu-id="31838-249">Gets the list of MAC addresses for the device.</span></span> <span data-ttu-id="31838-250">テスト アプリケーションは、これを呼び出して診断で役立てる必要があります。</span><span class="sxs-lookup"><span data-stu-id="31838-250">The testing application should invoke this to assist in diagnostics.</span></span> 

**<span data-ttu-id="31838-251">構文</span><span class="sxs-lookup"><span data-stu-id="31838-251">Syntax</span></span>**  
`void SecureBrowser.security.getMACAddress(Function callback);`

**<span data-ttu-id="31838-252">パラメーター</span><span class="sxs-lookup"><span data-stu-id="31838-252">Parameters</span></span>**  
* `callback` <span data-ttu-id="31838-253">- この呼び出しが完了したときに呼び出す関数です。</span><span class="sxs-lookup"><span data-stu-id="31838-253">- The function to invoke when this call completes.</span></span> <span data-ttu-id="31838-254">`Function(String addressArray)` という形式にする必要があります。ここでは、`addressArray` は `"['00:11:22:33:44:55','etc']"` という形式です。</span><span class="sxs-lookup"><span data-stu-id="31838-254">It must be in the form: `Function(String addressArray)` where `addressArray` is in the form: `"['00:11:22:33:44:55','etc']"`.</span></span>

**<span data-ttu-id="31838-255">コメント</span><span class="sxs-lookup"><span data-stu-id="31838-255">Remarks</span></span>**  
<span data-ttu-id="31838-256">ファイアウォール/NAT/プロキシは通常、学校で使用されるため、テスト サーバー内でエンド ユーザーのコンピューターを区別するために、ソース IP アドレスに依存するのは困難です。</span><span class="sxs-lookup"><span data-stu-id="31838-256">It is difficult to rely on source IP addresses to distinguish between end user machines within the testing servers because firewalls/NATs/Proxies are commonly in use at the schools.</span></span> <span data-ttu-id="31838-257">MAC アドレスは、診断のために、一般的なファイアウォールの背後にあるエンド クライアント コンピューターをアプリが区別できるようにします。</span><span class="sxs-lookup"><span data-stu-id="31838-257">The MAC addresses allow the app to distinguish end client machines behind a common firewall for diagnostics purposes.</span></span>

**<span data-ttu-id="31838-258">要件</span><span class="sxs-lookup"><span data-stu-id="31838-258">Requirements</span></span>**  
<span data-ttu-id="31838-259">Windows 10 バージョン 1709</span><span class="sxs-lookup"><span data-stu-id="31838-259">Windows 10, version 1709</span></span>

---

<span id="getStartTime" />

### <a name="getstarttime"></a><span data-ttu-id="31838-260">getStartTime</span><span class="sxs-lookup"><span data-stu-id="31838-260">getStartTime</span></span>
<span data-ttu-id="31838-261">テスト アプリが開始された時刻を取得します。</span><span class="sxs-lookup"><span data-stu-id="31838-261">Gets the time that the testing app was started.</span></span>

**<span data-ttu-id="31838-262">構文</span><span class="sxs-lookup"><span data-stu-id="31838-262">Syntax</span></span>**  
`DateTime SecureBrowser.settings.getStartTime();`

**<span data-ttu-id="31838-263">戻り値</span><span class="sxs-lookup"><span data-stu-id="31838-263">Return</span></span>**  
<span data-ttu-id="31838-264">テスト アプリが開始された日時を示す DateTime オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="31838-264">A DateTime object indicating the time the testing app was started.</span></span>

**<span data-ttu-id="31838-265">要件</span><span class="sxs-lookup"><span data-stu-id="31838-265">Requirements</span></span>**  
<span data-ttu-id="31838-266">Windows 10 バージョン 1709</span><span class="sxs-lookup"><span data-stu-id="31838-266">Windows 10, version 1709</span></span>

---

<span id="getCapability"/>

### <a name="getcapability"></a><span data-ttu-id="31838-267">getCapability</span><span class="sxs-lookup"><span data-stu-id="31838-267">getCapability</span></span>
<span data-ttu-id="31838-268">機能が有効であるか、無効であるかを照会します。</span><span class="sxs-lookup"><span data-stu-id="31838-268">Queries whether a capability is enabled or disabled.</span></span> 

**<span data-ttu-id="31838-269">構文</span><span class="sxs-lookup"><span data-stu-id="31838-269">Syntax</span></span>**  
`Object SecureBrowser.security.getCapability(String feature)`

**<span data-ttu-id="31838-270">パラメーター</span><span class="sxs-lookup"><span data-stu-id="31838-270">Parameters</span></span>**  
`feature` <span data-ttu-id="31838-271">- 照会する機能を特定する文字列。</span><span class="sxs-lookup"><span data-stu-id="31838-271">- The string to determine which capability to query.</span></span> <span data-ttu-id="31838-272">有効な機能の文字列は、"screenMonitoring"、"printing"、"textSuggestions" (大文字と小文字を区別しない) です。</span><span class="sxs-lookup"><span data-stu-id="31838-272">Valid capability strings are "screenMonitoring", "printing", and "textSuggestions" (case insensitive).</span></span>

**<span data-ttu-id="31838-273">戻り値</span><span class="sxs-lookup"><span data-stu-id="31838-273">Return Value</span></span>**  
<span data-ttu-id="31838-274">この関数は、JavaScript Object または `{<feature>:true|false}` の形式のリテラルのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="31838-274">This function returns either a JavaScript Object or literal with the form: `{<feature>:true|false}`.</span></span> <span data-ttu-id="31838-275">照会した機能が有効である場合は **true**、機能が有効になっていないか、機能の文字列が正しくない場合は **false**。</span><span class="sxs-lookup"><span data-stu-id="31838-275">**true** if the queried capability is enabled, **false** if the capability is not enabled or the capability string is invalid.</span></span>

<span data-ttu-id="31838-276">**要件** Windows 10 バージョン 1703</span><span class="sxs-lookup"><span data-stu-id="31838-276">**Requirements** Windows 10, version 1703</span></span>

---

<span id="setCapability"/>

### <a name="setcapability"></a><span data-ttu-id="31838-277">setCapability</span><span class="sxs-lookup"><span data-stu-id="31838-277">setCapability</span></span>
<span data-ttu-id="31838-278">特定の機能をブラウザーで有効または無効にします。</span><span class="sxs-lookup"><span data-stu-id="31838-278">Enables or disables a specific capability on the browser.</span></span>

**<span data-ttu-id="31838-279">構文</span><span class="sxs-lookup"><span data-stu-id="31838-279">Syntax</span></span>**  
`void SecureBrowser.security.setCapability(String feature, String value, Function onSuccess, Function onError)`

**<span data-ttu-id="31838-280">パラメーター</span><span class="sxs-lookup"><span data-stu-id="31838-280">Parameters</span></span>**  
* `feature` <span data-ttu-id="31838-281">- 設定する機能を特定する文字列。</span><span class="sxs-lookup"><span data-stu-id="31838-281">- The string to determine which capability to set.</span></span> <span data-ttu-id="31838-282">有効な機能の文字列は、`"screenMonitoring"`、`"printing"`、`"textSuggestions"` (大文字と小文字を区別しない) です。</span><span class="sxs-lookup"><span data-stu-id="31838-282">Valid capability strings are `"screenMonitoring"`, `"printing"`, and `"textSuggestions"` (case insensitive).</span></span>  
* `value` <span data-ttu-id="31838-283">- 機能の目的の設定です。</span><span class="sxs-lookup"><span data-stu-id="31838-283">- The intended setting for the feature.</span></span> <span data-ttu-id="31838-284">`"true"` または `"false"` にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="31838-284">It must be either `"true"` or `"false"`.</span></span>  
* `onSuccess` <span data-ttu-id="31838-285">- [オプション] Set 操作の後に呼び出す関数は、正常に完了しました。</span><span class="sxs-lookup"><span data-stu-id="31838-285">- [optional] The function to call after the set operation has been completed successfully.</span></span> <span data-ttu-id="31838-286">`Function(String jsonValue)` という形式にする必要があります。ここでは、*jsonValue* は `{<feature>:true|false|undefined}` という形式です。</span><span class="sxs-lookup"><span data-stu-id="31838-286">It must be of the form `Function(String jsonValue)` where *jsonValue* is in the form: `{<feature>:true|false|undefined}`.</span></span>  
* `onError` <span data-ttu-id="31838-287">- [オプション] Set 操作に失敗した場合に呼び出す関数です。</span><span class="sxs-lookup"><span data-stu-id="31838-287">- [optional] The function to call if the set operation failed.</span></span> <span data-ttu-id="31838-288">`Function(String jsonValue)` という形式にする必要があります。ここでは、*jsonValue* は `{<feature>:true|false|undefined}` という形式です。</span><span class="sxs-lookup"><span data-stu-id="31838-288">It must be of the form `Function(String jsonValue)` where *jsonValue* is in the form: `{<feature>:true|false|undefined}`.</span></span>

**<span data-ttu-id="31838-289">コメント</span><span class="sxs-lookup"><span data-stu-id="31838-289">Remarks</span></span>**  
<span data-ttu-id="31838-290">対象となる機能がブラウザーに不明である場合、この関数は `undefined` の値をコールバック関数に渡します。</span><span class="sxs-lookup"><span data-stu-id="31838-290">If the targeted feature is unknown to the browser, this function will pass a value of `undefined` to the callback function.</span></span>

<span data-ttu-id="31838-291">**要件** Windows 10 バージョン 1703</span><span class="sxs-lookup"><span data-stu-id="31838-291">**Requirements** Windows 10, version 1703</span></span>

---

<span id="isRemoteSession"/>

### <a name="isremotesession"></a><span data-ttu-id="31838-292">isRemoteSession</span><span class="sxs-lookup"><span data-stu-id="31838-292">isRemoteSession</span></span>
<span data-ttu-id="31838-293">現在のセッションがリモートからログインされているかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="31838-293">Checks if the current session is logged in remotely.</span></span>

**<span data-ttu-id="31838-294">構文</span><span class="sxs-lookup"><span data-stu-id="31838-294">Syntax</span></span>**  
`Boolean SecureBrowser.security.isRemoteSession();`

**<span data-ttu-id="31838-295">戻り値</span><span class="sxs-lookup"><span data-stu-id="31838-295">Return value</span></span>**  
<span data-ttu-id="31838-296">現在のセッションがリモートの場合は **true**、それ以外の場合は **false** です。</span><span class="sxs-lookup"><span data-stu-id="31838-296">**true** if the current session is remote, otherwise **false**.</span></span>

**<span data-ttu-id="31838-297">要件</span><span class="sxs-lookup"><span data-stu-id="31838-297">Requirements</span></span>**  
<span data-ttu-id="31838-298">Windows 10 バージョン 1709</span><span class="sxs-lookup"><span data-stu-id="31838-298">Windows 10, version 1709</span></span>

---

<span id="isVMSession"/>

### <a name="isvmsession"></a><span data-ttu-id="31838-299">isVMSession</span><span class="sxs-lookup"><span data-stu-id="31838-299">isVMSession</span></span>
<span data-ttu-id="31838-300">現在のセッションが、仮想マシン内で実行されているかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="31838-300">Checks if the current session is running within a virtual machine.</span></span>

**<span data-ttu-id="31838-301">構文</span><span class="sxs-lookup"><span data-stu-id="31838-301">Syntax</span></span>**  
`Boolean SecureBrowser.security.isVMSession();`

**<span data-ttu-id="31838-302">戻り値</span><span class="sxs-lookup"><span data-stu-id="31838-302">Return value</span></span>**  
<span data-ttu-id="31838-303">現在のセッションが仮想マシンで実行されている場合は **true**、それ以外の場合は **false** です。</span><span class="sxs-lookup"><span data-stu-id="31838-303">**true** if the current session is running in a virtual machine, otherwise **false**.</span></span>

**<span data-ttu-id="31838-304">コメント</span><span class="sxs-lookup"><span data-stu-id="31838-304">Remarks</span></span>**  
<span data-ttu-id="31838-305">この API のチェックは、適切な API を実装している特定のハイパーバイザーで実行されている VM セッションのみを検出できます。</span><span class="sxs-lookup"><span data-stu-id="31838-305">This API check can only detect VM sessions that are running in certain hypervisors that implement the appropriate APIs</span></span>

**<span data-ttu-id="31838-306">要件</span><span class="sxs-lookup"><span data-stu-id="31838-306">Requirements</span></span>**  
<span data-ttu-id="31838-307">Windows 10 バージョン 1709</span><span class="sxs-lookup"><span data-stu-id="31838-307">Windows 10, version 1709</span></span>

---