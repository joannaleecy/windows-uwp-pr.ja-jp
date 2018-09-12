---
Description: The JavaScript API for the Microsoft Take a Test app allows you to do secure assessments. Take a Test provides a secure browser that prevents students from using other computer or internet resources during a test.
title: テスト JavaScript API。
author: PatrickFarley
ms.author: pafarley
ms.assetid: 9bff6318-504c-4d0e-ba80-1a5ea45743da
ms.date: 08/08/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, 教育
ms.localizationpriority: medium
ms.openlocfilehash: 38596ad12ac309db5dc60e4a5183eee9bf8c7b7c
ms.sourcegitcommit: 2a63ee6770413bc35ace09b14f56b60007be7433
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3934567"
---
# <a name="take-a-test-javascript-api"></a><span data-ttu-id="678f7-103">テスト JavaScript API</span><span class="sxs-lookup"><span data-stu-id="678f7-103">Take a Test JavaScript API</span></span>

<span data-ttu-id="678f7-104">[テスト](https://technet.microsoft.com/edu/windows/take-tests-in-windows-10)はテストは、厳正なオンライン評価をロック ダウンをレンダリングするブラウザー ベースの UWP アプリ評価に集中する教育者のテスト環境をセキュリティ保護を提供する方法ではなくコンテンツを許可します。</span><span class="sxs-lookup"><span data-stu-id="678f7-104">[Take a Test](https://technet.microsoft.com/edu/windows/take-tests-in-windows-10) is a browser-based UWP app that renders locked-down online assessments for high-stakes testing, allowing educators to focus on the assessment content rather than how to provide a secure testing environment.</span></span> <span data-ttu-id="678f7-105">これを実現するには、任意の Web アプリケーションで利用できる JavaScript API を使用します。</span><span class="sxs-lookup"><span data-stu-id="678f7-105">To achieve this, it uses a JavaScript API that any web application can utilize.</span></span> <span data-ttu-id="678f7-106">テスト API は、重要な共通学力テストの [SBAC ブラウザー API 標準](http://www.smarterapp.org/documents/SecureBrowserRequirementsSpecifications_0-3.pdf)に対応しています。</span><span class="sxs-lookup"><span data-stu-id="678f7-106">The Take-a-test API supports the [SBAC browser API standard](http://www.smarterapp.org/documents/SecureBrowserRequirementsSpecifications_0-3.pdf) for high stakes common core testing.</span></span>

<span data-ttu-id="678f7-107">アプリ自体の詳細については、「[テスト アプリ技術リファレンス](https://technet.microsoft.com/edu/windows/take-a-test-app-technical?f=255&MSPPError=-2147217396)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="678f7-107">See the [Take a Test app technical reference](https://technet.microsoft.com/edu/windows/take-a-test-app-technical?f=255&MSPPError=-2147217396) for more information about the app itself.</span></span> <span data-ttu-id="678f7-108">トラブルシューティングについては、「[イベント ビューアーを使用して、Microsoft テストをトラブルシューティングする](troubleshooting.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="678f7-108">For troubleshooting help, see [Troubleshoot Microsoft Take a Test with the event viewer](troubleshooting.md).</span></span>

## <a name="reference-documentation"></a><span data-ttu-id="678f7-109">リファレンス ドキュメント</span><span class="sxs-lookup"><span data-stu-id="678f7-109">Reference documentation</span></span>
<span data-ttu-id="678f7-110">テスト API は、次の名前空間に存在します。</span><span class="sxs-lookup"><span data-stu-id="678f7-110">The Take a Test APIs exist in the following namespaces.</span></span> <span data-ttu-id="678f7-111">すべての API は、グローバルな `SecureBrowser` オブジェクトに依存する点に注意してください。</span><span class="sxs-lookup"><span data-stu-id="678f7-111">Note that all of the APIs depend on a global `SecureBrowser` object.</span></span>

| <span data-ttu-id="678f7-112">名前空間</span><span class="sxs-lookup"><span data-stu-id="678f7-112">Namespace</span></span> | <span data-ttu-id="678f7-113">説明</span><span class="sxs-lookup"><span data-stu-id="678f7-113">Description</span></span> |
|-----------|-------------|
|[<span data-ttu-id="678f7-114">セキュリティ名前空間</span><span class="sxs-lookup"><span data-stu-id="678f7-114">security namespace</span></span>](#security-namespace)|<span data-ttu-id="678f7-115">テストのためにデバイスをロックダウンし、テスト環境を強化できるようにする API が含まれます。</span><span class="sxs-lookup"><span data-stu-id="678f7-115">Contains APIs that enable you to lock down the device for testing and enforce a testing environment.</span></span> |

### <a name="security-namespace"></a><span data-ttu-id="678f7-116">セキュリティ名前空間</span><span class="sxs-lookup"><span data-stu-id="678f7-116">Security namespace</span></span>

<span data-ttu-id="678f7-117">セキュリティ名前空間を使用すると、デバイスをロックダウン、ユーザーとシステム プロセスの一覧の確認、MAC および IP アドレスの取得およびキャッシュされている web リソースのクリアできます。</span><span class="sxs-lookup"><span data-stu-id="678f7-117">The security namespace allows you to lock down the device, check the list of user and system processes, obtain MAC and IP addresses, and clear cached web resources.</span></span>

| <span data-ttu-id="678f7-118">メソッド</span><span class="sxs-lookup"><span data-stu-id="678f7-118">Method</span></span> | <span data-ttu-id="678f7-119">説明</span><span class="sxs-lookup"><span data-stu-id="678f7-119">Description</span></span>   |
|--------|---------------|
|[<span data-ttu-id="678f7-120">lockDown</span><span class="sxs-lookup"><span data-stu-id="678f7-120">lockDown</span></span>](#lockDown) | <span data-ttu-id="678f7-121">テストのためにデバイスをロックダウンします。</span><span class="sxs-lookup"><span data-stu-id="678f7-121">Locks down the device for testing.</span></span> |
|[<span data-ttu-id="678f7-122">isEnvironmentSecure</span><span class="sxs-lookup"><span data-stu-id="678f7-122">isEnvironmentSecure</span></span>](#isEnvironmentSecure) | <span data-ttu-id="678f7-123">ロックダウン コンテキストがデバイスにまだ適用されるかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="678f7-123">Determines whether the lockdown context is still applied to the device.</span></span> |
|[<span data-ttu-id="678f7-124">getDeviceInfo</span><span class="sxs-lookup"><span data-stu-id="678f7-124">getDeviceInfo</span></span>](#getDeviceInfo) | <span data-ttu-id="678f7-125">テスト アプリケーションが実行されているプラットフォームの詳細を取得します。</span><span class="sxs-lookup"><span data-stu-id="678f7-125">Gets details about the platform on which the testing application is running.</span></span> |
|[<span data-ttu-id="678f7-126">examineProcessList</span><span class="sxs-lookup"><span data-stu-id="678f7-126">examineProcessList</span></span>](#examineProcessList)|<span data-ttu-id="678f7-127">実行中のユーザーとシステム プロセスの一覧を取得します。</span><span class="sxs-lookup"><span data-stu-id="678f7-127">Gets the list of running user and system processes.</span></span>|
|[<span data-ttu-id="678f7-128">close</span><span class="sxs-lookup"><span data-stu-id="678f7-128">close</span></span>](#close) | <span data-ttu-id="678f7-129">ブラウザーを閉じて、デバイスのロックを解除します。</span><span class="sxs-lookup"><span data-stu-id="678f7-129">Closes the browser and unlocks the device.</span></span> |
|[<span data-ttu-id="678f7-130">getPermissiveMode</span><span class="sxs-lookup"><span data-stu-id="678f7-130">getPermissiveMode</span></span>](#getPermissiveMode)|<span data-ttu-id="678f7-131">制限解除モードがオンまたはオフかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="678f7-131">Checks if permissive mode is on or off.</span></span>|
|[<span data-ttu-id="678f7-132">setPermissiveMode</span><span class="sxs-lookup"><span data-stu-id="678f7-132">setPermissiveMode</span></span>](#setPermissiveMode)|<span data-ttu-id="678f7-133">制限解除モードのオンとオフを切り替えます。</span><span class="sxs-lookup"><span data-stu-id="678f7-133">Toggles permissive mode on or off.</span></span>|
|[<span data-ttu-id="678f7-134">emptyClipBoard</span><span class="sxs-lookup"><span data-stu-id="678f7-134">emptyClipBoard</span></span>](#emptyClipBoard)|<span data-ttu-id="678f7-135">システム クリップボードがクリアされます。</span><span class="sxs-lookup"><span data-stu-id="678f7-135">Clears the system clipboard.</span></span>|
|[<span data-ttu-id="678f7-136">getMACAddress</span><span class="sxs-lookup"><span data-stu-id="678f7-136">getMACAddress</span></span>](#getMACAddress)|<span data-ttu-id="678f7-137">デバイスの MAC アドレスの一覧を取得します。</span><span class="sxs-lookup"><span data-stu-id="678f7-137">Gets the list of MAC addresses for the device.</span></span>|
|[<span data-ttu-id="678f7-138">getStartTime</span><span class="sxs-lookup"><span data-stu-id="678f7-138">getStartTime</span></span>](#getStartTime) | <span data-ttu-id="678f7-139">テスト アプリが開始された時刻を取得します。</span><span class="sxs-lookup"><span data-stu-id="678f7-139">Gets the time that the testing app was started.</span></span> |
|[<span data-ttu-id="678f7-140">getCapability</span><span class="sxs-lookup"><span data-stu-id="678f7-140">getCapability</span></span>](#getCapability) | <span data-ttu-id="678f7-141">機能が有効であるか、無効であるかを照会します。</span><span class="sxs-lookup"><span data-stu-id="678f7-141">Queries whether a capability is enabled or disabled.</span></span> |
|[<span data-ttu-id="678f7-142">setCapability</span><span class="sxs-lookup"><span data-stu-id="678f7-142">setCapability</span></span>](#setCapability)|<span data-ttu-id="678f7-143">指定された機能を有効または無効にします。</span><span class="sxs-lookup"><span data-stu-id="678f7-143">Enables or disables the specified capability.</span></span>| 
|[<span data-ttu-id="678f7-144">isRemoteSession</span><span class="sxs-lookup"><span data-stu-id="678f7-144">isRemoteSession</span></span>](#isRemoteSession) | <span data-ttu-id="678f7-145">現在のセッションがリモートからログインされているかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="678f7-145">Checks if the current session is logged in remotely.</span></span> |
|[<span data-ttu-id="678f7-146">isVMSession</span><span class="sxs-lookup"><span data-stu-id="678f7-146">isVMSession</span></span>](#isVMSession) | <span data-ttu-id="678f7-147">現在のセッションが、仮想マシンで実行されているかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="678f7-147">Checks if the current session is running in a virtual machine.</span></span> |

---

<span id="lockDown"/>

### <a name="lockdown"></a><span data-ttu-id="678f7-148">lockDown</span><span class="sxs-lookup"><span data-stu-id="678f7-148">lockDown</span></span>
<span data-ttu-id="678f7-149">デバイスをロックダウンします。</span><span class="sxs-lookup"><span data-stu-id="678f7-149">Locks down the device.</span></span> <span data-ttu-id="678f7-150">デバイスのロック解除にも使用します。</span><span class="sxs-lookup"><span data-stu-id="678f7-150">Also used to unlock the device.</span></span> <span data-ttu-id="678f7-151">テスト Web アプリケーションは、受講者がテストを開始できるようにする前にこの呼び出しを起動します。</span><span class="sxs-lookup"><span data-stu-id="678f7-151">The testing web application will invoke this call prior to allowing students to start testing.</span></span> <span data-ttu-id="678f7-152">この実装は、テスト環境をセキュリティで保護するために必要なすべてのアクションを実行するために必要です。</span><span class="sxs-lookup"><span data-stu-id="678f7-152">The implementer is required to take any actions necessary to secure the testing environment.</span></span> <span data-ttu-id="678f7-153">環境をセキュリティで保護するために実行する手順はデバイス固有です。この手順には、たとえば、画面のキャプチャを無効にする、保護モードのときにボイス チャットを無効にする、システム クリップボードをクリアする、キオスク モードに移行する、OSX 10.7 以降のデバイスでスペースを無効にするなどの側面が含まれます。テスト アプリケーションは、評価が開始する前にロックダウンを有効にし、受講者が評価を完了してセキュリティ保護されたテストを終了したときにロックダウンを無効にします。</span><span class="sxs-lookup"><span data-stu-id="678f7-153">The steps taken to secure the environment are device specific and for example, include aspects such as disabling screen captures, disabling voice chat when in secure mode, clearing the system clipboard, entering into a kiosk mode, disabling Spaces in OSX 10.7+ devices, etc. The testing application will enable lockdown before an assessment commences and will disable the lockdown when the student has completed the assessment and is out of the secure test.</span></span>

**<span data-ttu-id="678f7-154">構文</span><span class="sxs-lookup"><span data-stu-id="678f7-154">Syntax</span></span>**  
`void SecureBrowser.security.lockDown(Boolean enable, Function onSuccess, Function onError);`

**<span data-ttu-id="678f7-155">パラメーター</span><span class="sxs-lookup"><span data-stu-id="678f7-155">Parameters</span></span>**  
* `enable`<span data-ttu-id="678f7-156"> - *\*true** は、ロック画面上でテスト アプリを実行し、この[ドキュメント](https://technet.microsoft.com/edu/windows/take-a-test-app-technical?f=255&MSPPError=-2147217396)で説明されているポリシーを適用します。</span><span class="sxs-lookup"><span data-stu-id="678f7-156"> - *\*true** to run the Take-a-Test app above the lock screen and apply policies discussed in this [document](https://technet.microsoft.com/edu/windows/take-a-test-app-technical?f=255&MSPPError=-2147217396).</span></span> <span data-ttu-id="678f7-157">**false** は、アプリがロックダウンされていない場合は、ロック画面上で実行しているテスト アプリを停止して閉じます。アプリがロックダウンされている場合は、何も行われません。</span><span class="sxs-lookup"><span data-stu-id="678f7-157">**false** stops running Take-a-Test above the lock screen and closes it unless the app is not locked down; in which case there is no effect.</span></span>  
* `onSuccess` <span data-ttu-id="678f7-158">- [オプション] ロックダウンが正常に有効または無効にされた後で呼び出す関数です。</span><span class="sxs-lookup"><span data-stu-id="678f7-158">- [optional] The function to call after the lockdown has been successfully enabled or disabled.</span></span> <span data-ttu-id="678f7-159">`Function(Boolean currentlockdownstate)` という形式にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="678f7-159">It must be of the form `Function(Boolean currentlockdownstate)`.</span></span>  
* `onError` <span data-ttu-id="678f7-160">- [オプション] ロックダウン操作に失敗した場合に呼び出す関数です。</span><span class="sxs-lookup"><span data-stu-id="678f7-160">- [optional] The function to call if the lockdown operation failed.</span></span> <span data-ttu-id="678f7-161">`Function(Boolean currentlockdownstate)` という形式にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="678f7-161">It must be of the form `Function(Boolean currentlockdownstate)`.</span></span>  

**<span data-ttu-id="678f7-162">要件</span><span class="sxs-lookup"><span data-stu-id="678f7-162">Requirements</span></span>**  
<span data-ttu-id="678f7-163">Windows 10 バージョン 1709</span><span class="sxs-lookup"><span data-stu-id="678f7-163">Windows 10, version 1709</span></span>

---

<span id="isEnvironmentSecure" />

### <a name="isenvironmentsecure"></a><span data-ttu-id="678f7-164">isEnvironmentSecure</span><span class="sxs-lookup"><span data-stu-id="678f7-164">isEnvironmentSecure</span></span>
<span data-ttu-id="678f7-165">ロックダウン コンテキストがデバイスにまだ適用されるかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="678f7-165">Determines whether the lockdown context is still applied to the device.</span></span> <span data-ttu-id="678f7-166">テスト Web アプリケーションは、受講者がテストを開始できるようにする前に、また受講者がテスト内にいる場合に定期的にこれを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="678f7-166">The testing web application will invoke this prior to allowing students to start testing and periodically when inside the test.</span></span>

**<span data-ttu-id="678f7-167">構文</span><span class="sxs-lookup"><span data-stu-id="678f7-167">Syntax</span></span>**  
`void SecureBrowser.security.isEnvironmentSecure(Function callback);`

**<span data-ttu-id="678f7-168">パラメーター</span><span class="sxs-lookup"><span data-stu-id="678f7-168">Parameters</span></span>**  
* `callback` <span data-ttu-id="678f7-169">- この関数が完了したときに呼び出す関数です。</span><span class="sxs-lookup"><span data-stu-id="678f7-169">- The function to call when this function completes.</span></span> <span data-ttu-id="678f7-170">`Function(String state)` という形式にする必要があります。ここでは、`state` は 2 つのフィールドを含む JSON 文字列です。</span><span class="sxs-lookup"><span data-stu-id="678f7-170">It must be of the form `Function(String state)` where `state` is a JSON string containing two fields.</span></span> <span data-ttu-id="678f7-171">1 つ目は `secure` フィールドで、必要なすべてのロックが有効化 (または機能が無効化) され、テスト環境をセキュリティ保護できるようにする場合にのみ `true` を表示します。アプリがロックダウン モードに入ってから、いずれのロックも侵害されていません。</span><span class="sxs-lookup"><span data-stu-id="678f7-171">The first is the `secure` field, which will show `true` only if all necessary locks have been enabled (or features disabled) to enable a secure testing environment, and none of these have been compromised since the app entered the lockdown mode.</span></span> <span data-ttu-id="678f7-172">もう 1 つのフィールド `messageKey` には、その他の詳細またはベンダー固有の情報が含まれます。</span><span class="sxs-lookup"><span data-stu-id="678f7-172">The other field, `messageKey`, includes other details or information that is vendor-specific.</span></span> <span data-ttu-id="678f7-173">ここでの意図は、ベンダーがブール値 `secure` フラグを強化する追加の情報を含めることができるようにすることです。</span><span class="sxs-lookup"><span data-stu-id="678f7-173">The intent here is to allow vendors to put additional information that augments the boolean `secure` flag:</span></span>

```JSON
{
    'secure' : "true/false",
    'messageKey' : "some message"
}
```

**<span data-ttu-id="678f7-174">要件</span><span class="sxs-lookup"><span data-stu-id="678f7-174">Requirements</span></span>**  
<span data-ttu-id="678f7-175">Windows 10 バージョン 1709</span><span class="sxs-lookup"><span data-stu-id="678f7-175">Windows 10, version 1709</span></span>

---

<span id="getDeviceInfo" />

### <a name="getdeviceinfo"></a><span data-ttu-id="678f7-176">getDeviceInfo</span><span class="sxs-lookup"><span data-stu-id="678f7-176">getDeviceInfo</span></span>
<span data-ttu-id="678f7-177">テスト アプリケーションが実行されているプラットフォームの詳細を取得します。</span><span class="sxs-lookup"><span data-stu-id="678f7-177">Gets details about the platform on which the testing application is running.</span></span> <span data-ttu-id="678f7-178">これは、ユーザー エージェントから認識できるすべての情報を拡張するために使用されます。</span><span class="sxs-lookup"><span data-stu-id="678f7-178">This is used to augment any information that was discernible from the user agent.</span></span>

**<span data-ttu-id="678f7-179">構文</span><span class="sxs-lookup"><span data-stu-id="678f7-179">Syntax</span></span>**  
`void SecureBrowser.security.getDeviceInfo(Function callback);`

**<span data-ttu-id="678f7-180">パラメーター</span><span class="sxs-lookup"><span data-stu-id="678f7-180">Parameters</span></span>**  
* `callback` <span data-ttu-id="678f7-181">- この関数が完了したときに呼び出す関数です。</span><span class="sxs-lookup"><span data-stu-id="678f7-181">- The function to call when this function completes.</span></span> <span data-ttu-id="678f7-182">`Function(String infoObj)` という形式にする必要があります。ここでは、`infoObj` は複数のフィールドを含む JSON 文字列です。</span><span class="sxs-lookup"><span data-stu-id="678f7-182">It must be of the form `Function(String infoObj)` where `infoObj` is a JSON string containing several fields.</span></span> <span data-ttu-id="678f7-183">次のフィールドがサポートされる必要があります。</span><span class="sxs-lookup"><span data-stu-id="678f7-183">The following fields must be supported:</span></span>
    * `os` <span data-ttu-id="678f7-184">OS の種類を表します (例: Windows、macOS、Linux、iOS、Android)。</span><span class="sxs-lookup"><span data-stu-id="678f7-184">represents the OS type (for example: Windows, macOS, Linux, iOS, Android, etc.)</span></span>
    * `name` <span data-ttu-id="678f7-185">存在する場合、OS リリースの名前を表します (例: シエラ、Ubuntu)。</span><span class="sxs-lookup"><span data-stu-id="678f7-185">represents the OS release name, if any (for example: Sierra, Ubuntu).</span></span>
    * `version` <span data-ttu-id="678f7-186">OS バージョンを表します (例: 10.1、10 Pro)。</span><span class="sxs-lookup"><span data-stu-id="678f7-186">represents the OS version (for example: 10.1, 10 Pro, etc.)</span></span>
    * `brand` <span data-ttu-id="678f7-187">セキュリティで保護されたブラウザーのブランドを表します (例: OAKS、CA、SmarterApp)。</span><span class="sxs-lookup"><span data-stu-id="678f7-187">represents the secure browser branding (for example: OAKS, CA, SmarterApp, etc.)</span></span>
    * `model` <span data-ttu-id="678f7-188">モバイル デバイスのデバイス モデルのみを表します。デスクトップ ブラウザーに対しては null または未使用です。</span><span class="sxs-lookup"><span data-stu-id="678f7-188">represents the device model for mobile devices only; null/unused for desktop browsers.</span></span>

**<span data-ttu-id="678f7-189">要件</span><span class="sxs-lookup"><span data-stu-id="678f7-189">Requirements</span></span>**  
<span data-ttu-id="678f7-190">Windows 10 バージョン 1709</span><span class="sxs-lookup"><span data-stu-id="678f7-190">Windows 10, version 1709</span></span>

---

<span id="examineProcessList" />

### <a name="examineprocesslist"></a><span data-ttu-id="678f7-191">examineProcessList</span><span class="sxs-lookup"><span data-stu-id="678f7-191">examineProcessList</span></span>
<span data-ttu-id="678f7-192">ユーザーが所有するクライアント コンピューター上で実行されているすべてのプロセスの一覧を取得します。</span><span class="sxs-lookup"><span data-stu-id="678f7-192">Gets the list of all processes running on the client machine owned by the user.</span></span> <span data-ttu-id="678f7-193">テスト アプリケーションはこれを呼び出して一覧を確認し、テスト サイクル中にブラックリストの対象と見なされたプロセスの一覧と比較します。</span><span class="sxs-lookup"><span data-stu-id="678f7-193">The testing application will invoke this to examine the list and compare it with a list of processes that have been deemed blacklisted during testing cycle.</span></span> <span data-ttu-id="678f7-194">この呼び出しは、評価の開始時と、受講者が評価を受ける間に定期的に呼び出される必要があります。</span><span class="sxs-lookup"><span data-stu-id="678f7-194">This call should be invoked both at the start of an assessment and periodically while the student is taking the assessment.</span></span> <span data-ttu-id="678f7-195">ブラックリストに追加したプロセスが検出された場合は、テストの整合性を保つために評価を停止する必要があります。</span><span class="sxs-lookup"><span data-stu-id="678f7-195">If a blacklisted process is detected, the assessment should be stopped to preserve test integrity.</span></span>

**<span data-ttu-id="678f7-196">構文</span><span class="sxs-lookup"><span data-stu-id="678f7-196">Syntax</span></span>**  
`void SecureBrowser.security.examineProcessList(String[] blacklistedProcessList, Function callback);`

**<span data-ttu-id="678f7-197">パラメーター</span><span class="sxs-lookup"><span data-stu-id="678f7-197">Parameters</span></span>**  
* `blacklistedProcessList` <span data-ttu-id="678f7-198">- テスト アプリケーションがブラック リストに追加した評価の一覧です。</span><span class="sxs-lookup"><span data-stu-id="678f7-198">- The list of processes that the testing application has blacklisted.</span></span>  
`callback` <span data-ttu-id="678f7-199">- アクティブなプロセスが見つかった後で呼び出す関数です。</span><span class="sxs-lookup"><span data-stu-id="678f7-199">- The function to invoke once the active processes have been found.</span></span> <span data-ttu-id="678f7-200">`Function(String foundBlacklistedProcesses)` という形式にする必要があります。ここでは、`foundBlacklistedProcesses` は `"['process1.exe','process2.exe','processEtc.exe']"` という形式になります。</span><span class="sxs-lookup"><span data-stu-id="678f7-200">It must be in the form: `Function(String foundBlacklistedProcesses)` where `foundBlacklistedProcesses` is in the form: `"['process1.exe','process2.exe','processEtc.exe']"`.</span></span> <span data-ttu-id="678f7-201">ブラック リストに追加されたプロセスが見つからなかった場合は、空になります。</span><span class="sxs-lookup"><span data-stu-id="678f7-201">It will be empty if no blacklisted processes were found.</span></span> <span data-ttu-id="678f7-202">Null の場合、元の関数呼び出しでエラーが発生したことを示します。</span><span class="sxs-lookup"><span data-stu-id="678f7-202">If it is null, this indicates that an error occurred in the original function call.</span></span>

<span data-ttu-id="678f7-203">**解説** 一覧にはシステム プロセスは含まれません。</span><span class="sxs-lookup"><span data-stu-id="678f7-203">**Remarks** The list does not include system processes.</span></span>

**<span data-ttu-id="678f7-204">要件</span><span class="sxs-lookup"><span data-stu-id="678f7-204">Requirements</span></span>**  
<span data-ttu-id="678f7-205">Windows 10 バージョン 1709</span><span class="sxs-lookup"><span data-stu-id="678f7-205">Windows 10, version 1709</span></span>

---

<span id="close"/>

### <a name="close"></a><span data-ttu-id="678f7-206">close</span><span class="sxs-lookup"><span data-stu-id="678f7-206">close</span></span>
<span data-ttu-id="678f7-207">ブラウザーを閉じて、デバイスのロックを解除します。</span><span class="sxs-lookup"><span data-stu-id="678f7-207">Closes the browser and unlocks the device.</span></span> <span data-ttu-id="678f7-208">ユーザーがブラウザーを終了するときに、テスト アプリケーションでこれを呼び出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="678f7-208">The testing application should invoke this when the user elects to exit the browser.</span></span>

**<span data-ttu-id="678f7-209">構文</span><span class="sxs-lookup"><span data-stu-id="678f7-209">Syntax</span></span>**  
`void SecureBrowser.security.close(restart);`

**<span data-ttu-id="678f7-210">パラメーター</span><span class="sxs-lookup"><span data-stu-id="678f7-210">Parameters</span></span>**  
* `restart` <span data-ttu-id="678f7-211">- このパラメーターは無視されますが、指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="678f7-211">- This parameter is ignored but must be provided.</span></span>

<span data-ttu-id="678f7-212">**解説** Windows 10 バージョン 1607 では、最初にデバイスをロックダウンする必要があります。</span><span class="sxs-lookup"><span data-stu-id="678f7-212">**Remarks** In Windows 10, version 1607, the device must be locked down initially.</span></span> <span data-ttu-id="678f7-213">以降のバージョンでは、このメソッドは、デバイスがロックダウンされているかどうかに関係なく、ブラウザーを閉じます。</span><span class="sxs-lookup"><span data-stu-id="678f7-213">In later versions, this method closes the browser regardless of whether the device is locked down.</span></span>

**<span data-ttu-id="678f7-214">要件</span><span class="sxs-lookup"><span data-stu-id="678f7-214">Requirements</span></span>**  
<span data-ttu-id="678f7-215">Windows 10 バージョン 1709</span><span class="sxs-lookup"><span data-stu-id="678f7-215">Windows 10, version 1709</span></span>

---

<span id="getPermissiveMode" />

### <a name="getpermissivemode"></a><span data-ttu-id="678f7-216">getPermissiveMode</span><span class="sxs-lookup"><span data-stu-id="678f7-216">getPermissiveMode</span></span>
<span data-ttu-id="678f7-217">テスト Web アプリケーションは、制限解除モードがオンまたはオフかどうかを判断するためにこれを呼び出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="678f7-217">The testing web application should invoke this to determine if permissive mode is on or off.</span></span> <span data-ttu-id="678f7-218">制限解除モードで、ブラウザーは、いくつかのセキュリティで保護された厳格なフックを緩和し、支援技術がセキュリティ保護されたブラウザーで動作できるようにすることが求められます。</span><span class="sxs-lookup"><span data-stu-id="678f7-218">In permissive mode, a browser is expected to relax some of its stringent security hooks to allow assistive technology to work with the secure browser.</span></span> <span data-ttu-id="678f7-219">たとえば、他のアプリケーション UI がブラウザーの最上位に表示されるのを積極的に防止するブラウザーでは、制限解除モードのときにこれを緩和する必要があります。</span><span class="sxs-lookup"><span data-stu-id="678f7-219">For example, browsers that aggressively prevent other application UIs from presenting on top of them might want to relax this when in permissive mode.</span></span> 

**<span data-ttu-id="678f7-220">構文</span><span class="sxs-lookup"><span data-stu-id="678f7-220">Syntax</span></span>**  
`void SecureBrowser.security.getPermissiveMode(Function callback)`

**<span data-ttu-id="678f7-221">パラメーター</span><span class="sxs-lookup"><span data-stu-id="678f7-221">Parameters</span></span>**  
* `callback` <span data-ttu-id="678f7-222">- この呼び出しが完了したときに呼び出す関数です。</span><span class="sxs-lookup"><span data-stu-id="678f7-222">- The function to invoke when this call completes.</span></span> <span data-ttu-id="678f7-223">`Function(Boolean permissiveMode)` という形式にする必要があります。ここでは、`permissiveMode` はブラウザーが現在、制限解除モードであるかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="678f7-223">It must be in the form: `Function(Boolean permissiveMode)` where `permissiveMode` indicates whether the browser is currently in permissive mode.</span></span> <span data-ttu-id="678f7-224">定義されていないか null の場合は、Get 操作でエラーが発生しました。</span><span class="sxs-lookup"><span data-stu-id="678f7-224">If it is undefined or null, an error occurred in the get operation.</span></span>

**<span data-ttu-id="678f7-225">要件</span><span class="sxs-lookup"><span data-stu-id="678f7-225">Requirements</span></span>**  
<span data-ttu-id="678f7-226">Windows 10 バージョン 1709</span><span class="sxs-lookup"><span data-stu-id="678f7-226">Windows 10, version 1709</span></span>

---

<span id="setPermissiveMode" />

### <a name="setpermissivemode"></a><span data-ttu-id="678f7-227">setPermissiveMode</span><span class="sxs-lookup"><span data-stu-id="678f7-227">setPermissiveMode</span></span>
<span data-ttu-id="678f7-228">テストの Web アプリケーションには、寛容モードのオンとオフを切り替えるのにこれを呼び出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="678f7-228">The testing web application should invoke this to toggle permissive mode on or off.</span></span> <span data-ttu-id="678f7-229">制限解除モードで、ブラウザーは、いくつかのセキュリティで保護された厳格なフックを緩和し、支援技術がセキュリティ保護されたブラウザーで動作できるようにすることが求められます。</span><span class="sxs-lookup"><span data-stu-id="678f7-229">In permissive mode, a browser is expected to relax some of its stringent security hooks to allow assistive technology to work with the secure browser.</span></span> <span data-ttu-id="678f7-230">たとえば、他のアプリケーション UI がブラウザーの最上位に表示されるのを積極的に防止するブラウザーでは、制限解除モードのときにこれを緩和する必要があります。</span><span class="sxs-lookup"><span data-stu-id="678f7-230">For example, browsers that aggressively prevent other application UIs from presenting on top of them might want to relax this when in permissive mode.</span></span> 

**<span data-ttu-id="678f7-231">構文</span><span class="sxs-lookup"><span data-stu-id="678f7-231">Syntax</span></span>**  
`void SecureBrowser.security.setPermissiveMode(Boolean enable, Function callback)`

**<span data-ttu-id="678f7-232">パラメーター</span><span class="sxs-lookup"><span data-stu-id="678f7-232">Parameters</span></span>**  
* `enable` <span data-ttu-id="678f7-233">- 目的の制限解除モードの状態を示すための Boolean 値。</span><span class="sxs-lookup"><span data-stu-id="678f7-233">- The Boolean value indicating the intended permissive mode status.</span></span>  
* `callback` <span data-ttu-id="678f7-234">- この呼び出しが完了したときに呼び出す関数です。</span><span class="sxs-lookup"><span data-stu-id="678f7-234">- The function to invoke when this call completes.</span></span> <span data-ttu-id="678f7-235">`Function(Boolean permissiveMode)` という形式にする必要があります。ここでは、`permissiveMode` はブラウザーが現在、制限解除モードであるかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="678f7-235">It must be in the form: `Function(Boolean permissiveMode)` where `permissiveMode` indicates whether the browser is currently in permissive mode.</span></span> <span data-ttu-id="678f7-236">定義されていないか null の場合は、Set 操作でエラーが発生しました。</span><span class="sxs-lookup"><span data-stu-id="678f7-236">If it is undefined or null, an error occurred in the set operation.</span></span>

**<span data-ttu-id="678f7-237">要件</span><span class="sxs-lookup"><span data-stu-id="678f7-237">Requirements</span></span>**  
<span data-ttu-id="678f7-238">Windows 10 バージョン 1709</span><span class="sxs-lookup"><span data-stu-id="678f7-238">Windows 10, version 1709</span></span>

---

<span id="emptyClipBoard"/>

### <a name="emptyclipboard"></a><span data-ttu-id="678f7-239">emptyClipBoard</span><span class="sxs-lookup"><span data-stu-id="678f7-239">emptyClipBoard</span></span>
<span data-ttu-id="678f7-240">システム クリップボードがクリアされます。</span><span class="sxs-lookup"><span data-stu-id="678f7-240">Clears the system clipboard.</span></span> <span data-ttu-id="678f7-241">テスト アプリケーションは、これを呼び出して、システム クリップボードに保存されている可能性があるデータを強制的にクリアする必要があります。</span><span class="sxs-lookup"><span data-stu-id="678f7-241">The testing application should invoke this to force clear any data that may be stored in the system clipboard.</span></span> <span data-ttu-id="678f7-242">**[lockDown](#lockDown)** 関数もこの操作を実行します。</span><span class="sxs-lookup"><span data-stu-id="678f7-242">The **[lockDown](#lockDown)** function also performs this operation.</span></span>

**<span data-ttu-id="678f7-243">構文</span><span class="sxs-lookup"><span data-stu-id="678f7-243">Syntax</span></span>**  
`void SecureBrowser.security.emptyClipBoard();`

**<span data-ttu-id="678f7-244">要件</span><span class="sxs-lookup"><span data-stu-id="678f7-244">Requirements</span></span>**  
<span data-ttu-id="678f7-245">Windows 10 バージョン 1709</span><span class="sxs-lookup"><span data-stu-id="678f7-245">Windows 10, version 1709</span></span>

---

<span id="getMACAddress" />

### <a name="getmacaddress"></a><span data-ttu-id="678f7-246">getMACAddress</span><span class="sxs-lookup"><span data-stu-id="678f7-246">getMACAddress</span></span>
<span data-ttu-id="678f7-247">デバイスの MAC アドレスの一覧を取得します。</span><span class="sxs-lookup"><span data-stu-id="678f7-247">Gets the list of MAC addresses for the device.</span></span> <span data-ttu-id="678f7-248">テスト アプリケーションは、これを呼び出して診断で役立てる必要があります。</span><span class="sxs-lookup"><span data-stu-id="678f7-248">The testing application should invoke this to assist in diagnostics.</span></span> 

**<span data-ttu-id="678f7-249">構文</span><span class="sxs-lookup"><span data-stu-id="678f7-249">Syntax</span></span>**  
`void SecureBrowser.security.getMACAddress(Function callback);`

**<span data-ttu-id="678f7-250">パラメーター</span><span class="sxs-lookup"><span data-stu-id="678f7-250">Parameters</span></span>**  
* `callback` <span data-ttu-id="678f7-251">- この呼び出しが完了したときに呼び出す関数です。</span><span class="sxs-lookup"><span data-stu-id="678f7-251">- The function to invoke when this call completes.</span></span> <span data-ttu-id="678f7-252">`Function(String addressArray)` という形式にする必要があります。ここでは、`addressArray` は `"['00:11:22:33:44:55','etc']"` という形式です。</span><span class="sxs-lookup"><span data-stu-id="678f7-252">It must be in the form: `Function(String addressArray)` where `addressArray` is in the form: `"['00:11:22:33:44:55','etc']"`.</span></span>

**<span data-ttu-id="678f7-253">コメント</span><span class="sxs-lookup"><span data-stu-id="678f7-253">Remarks</span></span>**  
<span data-ttu-id="678f7-254">ファイアウォール/NAT/プロキシは通常、学校で使用されるため、テスト サーバー内でエンド ユーザーのコンピューターを区別するために、ソース IP アドレスに依存するのは困難です。</span><span class="sxs-lookup"><span data-stu-id="678f7-254">It is difficult to rely on source IP addresses to distinguish between end user machines within the testing servers because firewalls/NATs/Proxies are commonly in use at the schools.</span></span> <span data-ttu-id="678f7-255">MAC アドレスは、診断のために、一般的なファイアウォールの背後にあるエンド クライアント コンピューターをアプリが区別できるようにします。</span><span class="sxs-lookup"><span data-stu-id="678f7-255">The MAC addresses allow the app to distinguish end client machines behind a common firewall for diagnostics purposes.</span></span>

**<span data-ttu-id="678f7-256">要件</span><span class="sxs-lookup"><span data-stu-id="678f7-256">Requirements</span></span>**  
<span data-ttu-id="678f7-257">Windows 10 バージョン 1709</span><span class="sxs-lookup"><span data-stu-id="678f7-257">Windows 10, version 1709</span></span>

---

<span id="getStartTime" />

### <a name="getstarttime"></a><span data-ttu-id="678f7-258">getStartTime</span><span class="sxs-lookup"><span data-stu-id="678f7-258">getStartTime</span></span>
<span data-ttu-id="678f7-259">テスト アプリが開始された時刻を取得します。</span><span class="sxs-lookup"><span data-stu-id="678f7-259">Gets the time that the testing app was started.</span></span>

**<span data-ttu-id="678f7-260">構文</span><span class="sxs-lookup"><span data-stu-id="678f7-260">Syntax</span></span>**  
`DateTime SecureBrowser.settings.getStartTime();`

**<span data-ttu-id="678f7-261">戻り値</span><span class="sxs-lookup"><span data-stu-id="678f7-261">Return</span></span>**  
<span data-ttu-id="678f7-262">テスト アプリが開始された日時を示す DateTime オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="678f7-262">A DateTime object indicating the time the testing app was started.</span></span>

**<span data-ttu-id="678f7-263">要件</span><span class="sxs-lookup"><span data-stu-id="678f7-263">Requirements</span></span>**  
<span data-ttu-id="678f7-264">Windows 10 バージョン 1709</span><span class="sxs-lookup"><span data-stu-id="678f7-264">Windows 10, version 1709</span></span>

---

<span id="getCapability"/>

### <a name="getcapability"></a><span data-ttu-id="678f7-265">getCapability</span><span class="sxs-lookup"><span data-stu-id="678f7-265">getCapability</span></span>
<span data-ttu-id="678f7-266">機能が有効であるか、無効であるかを照会します。</span><span class="sxs-lookup"><span data-stu-id="678f7-266">Queries whether a capability is enabled or disabled.</span></span> 

**<span data-ttu-id="678f7-267">構文</span><span class="sxs-lookup"><span data-stu-id="678f7-267">Syntax</span></span>**  
`Object SecureBrowser.security.getCapability(String feature)`

**<span data-ttu-id="678f7-268">パラメーター</span><span class="sxs-lookup"><span data-stu-id="678f7-268">Parameters</span></span>**  
`feature` <span data-ttu-id="678f7-269">- 照会する機能を特定する文字列。</span><span class="sxs-lookup"><span data-stu-id="678f7-269">- The string to determine which capability to query.</span></span> <span data-ttu-id="678f7-270">有効な機能の文字列は、"screenMonitoring"、"printing"、"textSuggestions" (大文字と小文字を区別しない) です。</span><span class="sxs-lookup"><span data-stu-id="678f7-270">Valid capability strings are "screenMonitoring", "printing", and "textSuggestions" (case insensitive).</span></span>

**<span data-ttu-id="678f7-271">戻り値</span><span class="sxs-lookup"><span data-stu-id="678f7-271">Return Value</span></span>**  
<span data-ttu-id="678f7-272">この関数は、JavaScript Object または `{<feature>:true|false}` の形式のリテラルのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="678f7-272">This function returns either a JavaScript Object or literal with the form: `{<feature>:true|false}`.</span></span> <span data-ttu-id="678f7-273">照会した機能が有効である場合は **true**、機能が有効になっていないか、機能の文字列が正しくない場合は **false**。</span><span class="sxs-lookup"><span data-stu-id="678f7-273">**true** if the queried capability is enabled, **false** if the capability is not enabled or the capability string is invalid.</span></span>

<span data-ttu-id="678f7-274">**要件** Windows 10 バージョン 1703</span><span class="sxs-lookup"><span data-stu-id="678f7-274">**Requirements** Windows 10, version 1703</span></span>

---

<span id="setCapability"/>

### <a name="setcapability"></a><span data-ttu-id="678f7-275">setCapability</span><span class="sxs-lookup"><span data-stu-id="678f7-275">setCapability</span></span>
<span data-ttu-id="678f7-276">特定の機能をブラウザーで有効または無効にします。</span><span class="sxs-lookup"><span data-stu-id="678f7-276">Enables or disables a specific capability on the browser.</span></span>

**<span data-ttu-id="678f7-277">構文</span><span class="sxs-lookup"><span data-stu-id="678f7-277">Syntax</span></span>**  
`void SecureBrowser.security.setCapability(String feature, String value, Function onSuccess, Function onError)`

**<span data-ttu-id="678f7-278">パラメーター</span><span class="sxs-lookup"><span data-stu-id="678f7-278">Parameters</span></span>**  
* `feature` <span data-ttu-id="678f7-279">- 設定する機能を特定する文字列。</span><span class="sxs-lookup"><span data-stu-id="678f7-279">- The string to determine which capability to set.</span></span> <span data-ttu-id="678f7-280">有効な機能の文字列は、`"screenMonitoring"`、`"printing"`、`"textSuggestions"` (大文字と小文字を区別しない) です。</span><span class="sxs-lookup"><span data-stu-id="678f7-280">Valid capability strings are `"screenMonitoring"`, `"printing"`, and `"textSuggestions"` (case insensitive).</span></span>  
* `value` <span data-ttu-id="678f7-281">- 機能の目的の設定です。</span><span class="sxs-lookup"><span data-stu-id="678f7-281">- The intended setting for the feature.</span></span> <span data-ttu-id="678f7-282">`"true"` または `"false"` にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="678f7-282">It must be either `"true"` or `"false"`.</span></span>  
* `onSuccess` <span data-ttu-id="678f7-283">- [オプション] Set 操作の後に呼び出す関数は、正常に完了しました。</span><span class="sxs-lookup"><span data-stu-id="678f7-283">- [optional] The function to call after the set operation has been completed successfully.</span></span> <span data-ttu-id="678f7-284">`Function(String jsonValue)` という形式にする必要があります。ここでは、*jsonValue* は `{<feature>:true|false|undefined}` という形式です。</span><span class="sxs-lookup"><span data-stu-id="678f7-284">It must be of the form `Function(String jsonValue)` where *jsonValue* is in the form: `{<feature>:true|false|undefined}`.</span></span>  
* `onError` <span data-ttu-id="678f7-285">- [オプション] Set 操作に失敗した場合に呼び出す関数です。</span><span class="sxs-lookup"><span data-stu-id="678f7-285">- [optional] The function to call if the set operation failed.</span></span> <span data-ttu-id="678f7-286">`Function(String jsonValue)` という形式にする必要があります。ここでは、*jsonValue* は `{<feature>:true|false|undefined}` という形式です。</span><span class="sxs-lookup"><span data-stu-id="678f7-286">It must be of the form `Function(String jsonValue)` where *jsonValue* is in the form: `{<feature>:true|false|undefined}`.</span></span>

**<span data-ttu-id="678f7-287">コメント</span><span class="sxs-lookup"><span data-stu-id="678f7-287">Remarks</span></span>**  
<span data-ttu-id="678f7-288">対象となる機能がブラウザーに不明である場合、この関数は `undefined` の値をコールバック関数に渡します。</span><span class="sxs-lookup"><span data-stu-id="678f7-288">If the targeted feature is unknown to the browser, this function will pass a value of `undefined` to the callback function.</span></span>

<span data-ttu-id="678f7-289">**要件** Windows 10 バージョン 1703</span><span class="sxs-lookup"><span data-stu-id="678f7-289">**Requirements** Windows 10, version 1703</span></span>

---

<span id="isRemoteSession"/>

### <a name="isremotesession"></a><span data-ttu-id="678f7-290">isRemoteSession</span><span class="sxs-lookup"><span data-stu-id="678f7-290">isRemoteSession</span></span>
<span data-ttu-id="678f7-291">現在のセッションがリモートからログインされているかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="678f7-291">Checks if the current session is logged in remotely.</span></span>

**<span data-ttu-id="678f7-292">構文</span><span class="sxs-lookup"><span data-stu-id="678f7-292">Syntax</span></span>**  
`Boolean SecureBrowser.security.isRemoteSession();`

**<span data-ttu-id="678f7-293">戻り値</span><span class="sxs-lookup"><span data-stu-id="678f7-293">Return value</span></span>**  
<span data-ttu-id="678f7-294">現在のセッションがリモートの場合は **true**、それ以外の場合は **false** です。</span><span class="sxs-lookup"><span data-stu-id="678f7-294">**true** if the current session is remote, otherwise **false**.</span></span>

**<span data-ttu-id="678f7-295">要件</span><span class="sxs-lookup"><span data-stu-id="678f7-295">Requirements</span></span>**  
<span data-ttu-id="678f7-296">Windows 10 バージョン 1709</span><span class="sxs-lookup"><span data-stu-id="678f7-296">Windows 10, version 1709</span></span>

---

<span id="isVMSession"/>

### <a name="isvmsession"></a><span data-ttu-id="678f7-297">isVMSession</span><span class="sxs-lookup"><span data-stu-id="678f7-297">isVMSession</span></span>
<span data-ttu-id="678f7-298">現在のセッションが、仮想マシン内で実行されているかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="678f7-298">Checks if the current session is running within a virtual machine.</span></span>

**<span data-ttu-id="678f7-299">構文</span><span class="sxs-lookup"><span data-stu-id="678f7-299">Syntax</span></span>**  
`Boolean SecureBrowser.security.isVMSession();`

**<span data-ttu-id="678f7-300">戻り値</span><span class="sxs-lookup"><span data-stu-id="678f7-300">Return value</span></span>**  
<span data-ttu-id="678f7-301">現在のセッションが仮想マシンで実行されている場合は **true**、それ以外の場合は **false** です。</span><span class="sxs-lookup"><span data-stu-id="678f7-301">**true** if the current session is running in a virtual machine, otherwise **false**.</span></span>

**<span data-ttu-id="678f7-302">コメント</span><span class="sxs-lookup"><span data-stu-id="678f7-302">Remarks</span></span>**  
<span data-ttu-id="678f7-303">この API のチェックは、適切な API を実装している特定のハイパーバイザーで実行されている VM セッションのみを検出できます。</span><span class="sxs-lookup"><span data-stu-id="678f7-303">This API check can only detect VM sessions that are running in certain hypervisors that implement the appropriate APIs</span></span>

**<span data-ttu-id="678f7-304">要件</span><span class="sxs-lookup"><span data-stu-id="678f7-304">Requirements</span></span>**  
<span data-ttu-id="678f7-305">Windows 10 バージョン 1709</span><span class="sxs-lookup"><span data-stu-id="678f7-305">Windows 10, version 1709</span></span>

---