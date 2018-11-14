---
author: lex
Description: The following article describes all of the properties and elements within the toast content XML payload.
title: トースト通知のコンテンツの XML スキーマ
ms.assetid: AF49EFAC-447E-44C3-93C3-CCBEDCF07D22
label: Toast content XML schema
template: detail.hbs
ms.author: mijacobs
ms.date: 05/19/2017
ms.topic: article
keywords: Windows 10、UWP
ms.localizationpriority: medium
ms.openlocfilehash: bcfc56264ab3063995fd9f2b06bd93e9406cd37e
ms.sourcegitcommit: 38f06f1714334273d865935d9afb80efffe97a17
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/09/2018
ms.locfileid: "6201412"
---
# <a name="toast-content-xml-schema"></a><span data-ttu-id="cfef3-103">トースト通知のコンテンツの XML スキーマ</span><span class="sxs-lookup"><span data-stu-id="cfef3-103">Toast content XML schema</span></span>

 

<span data-ttu-id="cfef3-104">ここでは、トースト通知のコンテンツの XML ペイロードにあるすべてのプロパティと要素を説明します。</span><span class="sxs-lookup"><span data-stu-id="cfef3-104">The following describes all of the properties and elements within the toast content XML payload.</span></span>

<span data-ttu-id="cfef3-105">次の XML スキーマで、"?" サフィックスは属性が省略可能であることを意味します。</span><span class="sxs-lookup"><span data-stu-id="cfef3-105">In the following XML schemas, a "?" suffix means that an attribute is optional.</span></span>

## <a name="ltvisualgt-and-ltaudiogt"></a><span data-ttu-id="cfef3-106">&lt;visual&gt; および &lt;audio&gt;</span><span class="sxs-lookup"><span data-stu-id="cfef3-106">&lt;visual&gt; and &lt;audio&gt;</span></span>

```
<toast launch? duration? activationType? scenario? >
  <visual lang? baseUri? addImageQuery? >
    <binding template? lang? baseUri? addImageQuery? >
      <text lang? hint-maxLines? >content</text>
      <image src placement? alt? addImageQuery? hint-crop? />
      <group>
        <subgroup hint-weight? hint-textStacking? >
          <text />
          <image />
        </subgroup>
      </group>
    </binding>
  </visual>
  <audio src? loop? silent? />
</toast>
```

**<span data-ttu-id="cfef3-107">&lt;toast&gt; 内の属性</span><span class="sxs-lookup"><span data-stu-id="cfef3-107">Attributes in &lt;toast&gt;</span></span>**

<span data-ttu-id="cfef3-108">launch?</span><span class="sxs-lookup"><span data-stu-id="cfef3-108">launch?</span></span>

-   <span data-ttu-id="cfef3-109">launch?</span><span class="sxs-lookup"><span data-stu-id="cfef3-109">launch?</span></span> <span data-ttu-id="cfef3-110"> = 文字列</span><span class="sxs-lookup"><span data-stu-id="cfef3-110">= string</span></span>
-   <span data-ttu-id="cfef3-111">この属性は省略可能です。</span><span class="sxs-lookup"><span data-stu-id="cfef3-111">This is an optional attribute.</span></span>
-   <span data-ttu-id="cfef3-112">トースト通知によってアプリケーションがアクティブ化されるときにアプリケーションに渡される文字列です。</span><span class="sxs-lookup"><span data-stu-id="cfef3-112">A string that is passed to the application when it is activated by the toast.</span></span>
-   <span data-ttu-id="cfef3-113">activationType の値に応じて、この値は、フォアグラウンドのアプリ、バックグラウンド タスクの内部、または元のアプリからプロトコル起動された他のアプリで取得することができます。</span><span class="sxs-lookup"><span data-stu-id="cfef3-113">Depending on the value of activationType, this value can be received by the app in the foreground, inside the background task, or by another app that's protocol launched from the original app.</span></span>
-   <span data-ttu-id="cfef3-114">この文字列の形式とコンテンツは、アプリ独自の使用方法に合わせて、アプリによって定義されます。</span><span class="sxs-lookup"><span data-stu-id="cfef3-114">The format and contents of this string are defined by the app for its own use.</span></span>
-   <span data-ttu-id="cfef3-115">ユーザーがトースト通知をタップまたはクリックし、関連するアプリを起動すると、そのアプリは既定の方法で起動されるのではなく、起動文字列によって、そのコンテキストがアプリに渡され、トースト通知のコンテンツに関連するビューがユーザーに表示されます。</span><span class="sxs-lookup"><span data-stu-id="cfef3-115">When the user taps or clicks the toast to launch its associated app, the launch string provides the context to the app that allows it to show the user a view relevant to the toast content, rather than launching in its default way.</span></span>
-   <span data-ttu-id="cfef3-116">ユーザーがトースト通知の本文ではなく操作をクリックしたことによってアクティブ化が行われた場合、&lt;toast&gt; タグ内に定義済みの "launch" ではなく、&lt;action&gt; タグ内に事前に定義されている "arguments" が取得されます。</span><span class="sxs-lookup"><span data-stu-id="cfef3-116">If the activation is happened because user clicked on an action, instead of the body of the toast, the developer retrieves back the "arguments" pre-defined in that &lt;action&gt; tag, instead of "launch" pre-defined in the &lt;toast&gt; tag.</span></span>

<span data-ttu-id="cfef3-117">duration?</span><span class="sxs-lookup"><span data-stu-id="cfef3-117">duration?</span></span>

-   <span data-ttu-id="cfef3-118">duration?</span><span class="sxs-lookup"><span data-stu-id="cfef3-118">duration?</span></span> <span data-ttu-id="cfef3-119"> = "short|long"</span><span class="sxs-lookup"><span data-stu-id="cfef3-119">= "short|long"</span></span>
-   <span data-ttu-id="cfef3-120">この属性は省略可能です。</span><span class="sxs-lookup"><span data-stu-id="cfef3-120">This is an optional attribute.</span></span> <span data-ttu-id="cfef3-121">既定値は "short" です。</span><span class="sxs-lookup"><span data-stu-id="cfef3-121">Default value is "short".</span></span>
-   <span data-ttu-id="cfef3-122">これは、特定のシナリオやアプリケーションの互換性のみを目的とした属性です。</span><span class="sxs-lookup"><span data-stu-id="cfef3-122">This is only here for specific scenarios and appCompat.</span></span> <span data-ttu-id="cfef3-123">アラーム シナリオでは、この属性は必要ありません。</span><span class="sxs-lookup"><span data-stu-id="cfef3-123">You don't need this for the alarm scenario anymore.</span></span>
-   <span data-ttu-id="cfef3-124">このプロパティを使うことはお勧めしません。</span><span class="sxs-lookup"><span data-stu-id="cfef3-124">We don't recommend using this property.</span></span>

<span data-ttu-id="cfef3-125">activationType?</span><span class="sxs-lookup"><span data-stu-id="cfef3-125">activationType?</span></span>

-   <span data-ttu-id="cfef3-126">activationType?</span><span class="sxs-lookup"><span data-stu-id="cfef3-126">activationType?</span></span> <span data-ttu-id="cfef3-127"> = "foreground | background | protocol | system"</span><span class="sxs-lookup"><span data-stu-id="cfef3-127">= "foreground | background | protocol | system"</span></span>
-   <span data-ttu-id="cfef3-128">この属性は省略可能です。</span><span class="sxs-lookup"><span data-stu-id="cfef3-128">This is an optional attribute.</span></span>
-   <span data-ttu-id="cfef3-129">既定値は "foreground" です。</span><span class="sxs-lookup"><span data-stu-id="cfef3-129">The default value is "foreground".</span></span>

<span data-ttu-id="cfef3-130">scenario?</span><span class="sxs-lookup"><span data-stu-id="cfef3-130">scenario?</span></span>

-   <span data-ttu-id="cfef3-131">scenario?</span><span class="sxs-lookup"><span data-stu-id="cfef3-131">scenario?</span></span> <span data-ttu-id="cfef3-132"> = "default | alarm | reminder | incomingCall"</span><span class="sxs-lookup"><span data-stu-id="cfef3-132">= "default | alarm | reminder | incomingCall"</span></span>
-   <span data-ttu-id="cfef3-133">この属性は省略可能です。既定値は "default" です。</span><span class="sxs-lookup"><span data-stu-id="cfef3-133">This is an optional attribute, default value is "default".</span></span>
-   <span data-ttu-id="cfef3-134">シナリオがアラーム、リマインダー、着信呼び出しの表示以外の場合、この属性は必要ありません。</span><span class="sxs-lookup"><span data-stu-id="cfef3-134">You do not need this unless your scenario is to pop an alarm, reminder, or incoming call.</span></span>
-   <span data-ttu-id="cfef3-135">通知を常に画面上に表示することのみを目的とする場合は、この属性を使わないでください。</span><span class="sxs-lookup"><span data-stu-id="cfef3-135">Do not use this just for keeping your notification persistent on screen.</span></span>

**<span data-ttu-id="cfef3-136">&lt;visual&gt; 内の属性</span><span class="sxs-lookup"><span data-stu-id="cfef3-136">Attributes in &lt;visual&gt;</span></span>**

<span data-ttu-id="cfef3-137">lang?</span><span class="sxs-lookup"><span data-stu-id="cfef3-137">lang?</span></span>

-   <span data-ttu-id="cfef3-138">この省略可能な属性について詳しくは、[要素のスキーマに関するこの記事](https://msdn.microsoft.com/library/windows/apps/br230847)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="cfef3-138">See [this element schema article](https://msdn.microsoft.com/library/windows/apps/br230847) for details on this optional attribute.</span></span>

<span data-ttu-id="cfef3-139">baseUri?</span><span class="sxs-lookup"><span data-stu-id="cfef3-139">baseUri?</span></span>

-   <span data-ttu-id="cfef3-140">この省略可能な属性について詳しくは、[要素のスキーマに関するこの記事](https://msdn.microsoft.com/library/windows/apps/br230847)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="cfef3-140">See [this element schema article](https://msdn.microsoft.com/library/windows/apps/br230847) for details on this optional attribute.</span></span>

<span data-ttu-id="cfef3-141">addImageQuery?</span><span class="sxs-lookup"><span data-stu-id="cfef3-141">addImageQuery?</span></span>

-   <span data-ttu-id="cfef3-142">この省略可能な属性について詳しくは、[要素のスキーマに関するこの記事](https://msdn.microsoft.com/library/windows/apps/br230847)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="cfef3-142">See [this element schema article](https://msdn.microsoft.com/library/windows/apps/br230847) for details on this optional attribute.</span></span>

**<span data-ttu-id="cfef3-143">&lt;binding&gt; 内の属性</span><span class="sxs-lookup"><span data-stu-id="cfef3-143">Attributes in &lt;binding&gt;</span></span>**

<span data-ttu-id="cfef3-144">template?</span><span class="sxs-lookup"><span data-stu-id="cfef3-144">template?</span></span>

-   <span data-ttu-id="cfef3-145">\[重要\] template?</span><span class="sxs-lookup"><span data-stu-id="cfef3-145">\[Important\] template?</span></span> <span data-ttu-id="cfef3-146"> = "ToastGeneric"</span><span class="sxs-lookup"><span data-stu-id="cfef3-146">= "ToastGeneric"</span></span>
-   <span data-ttu-id="cfef3-147">新しいアダプティブ通知と対話型通知の機能を使う場合は、従来のテンプレートではなく、必ず "ToastGeneric" テンプレートを使って作業を始めてください。</span><span class="sxs-lookup"><span data-stu-id="cfef3-147">If you are using any of the new adaptive and interactive notification features, please make sure you start using "ToastGeneric" template instead of the legacy template.</span></span>
-   <span data-ttu-id="cfef3-148">新しい操作で従来のテンプレートを使うと、現時点では動作する可能性があります。ただし、この方法は対象となる使用方法ではないため、今後も引き続き動作するかどうかは保証できません。</span><span class="sxs-lookup"><span data-stu-id="cfef3-148">Using the legacy templates with the new actions might work now, but that is not the intended use case, and we cannot guarantee that will continue working.</span></span>

<span data-ttu-id="cfef3-149">lang?</span><span class="sxs-lookup"><span data-stu-id="cfef3-149">lang?</span></span>

-   <span data-ttu-id="cfef3-150">この省略可能な属性について詳しくは、[要素のスキーマに関するこの記事](https://msdn.microsoft.com/library/windows/apps/br230847)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="cfef3-150">See [this element schema article](https://msdn.microsoft.com/library/windows/apps/br230847) for details on this optional attribute.</span></span>

<span data-ttu-id="cfef3-151">baseUri?</span><span class="sxs-lookup"><span data-stu-id="cfef3-151">baseUri?</span></span>

-   <span data-ttu-id="cfef3-152">この省略可能な属性について詳しくは、[要素のスキーマに関するこの記事](https://msdn.microsoft.com/library/windows/apps/br230847)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="cfef3-152">See [this element schema article](https://msdn.microsoft.com/library/windows/apps/br230847) for details on this optional attribute.</span></span>

<span data-ttu-id="cfef3-153">addImageQuery?</span><span class="sxs-lookup"><span data-stu-id="cfef3-153">addImageQuery?</span></span>

-   <span data-ttu-id="cfef3-154">この省略可能な属性について詳しくは、[要素のスキーマに関するこの記事](https://msdn.microsoft.com/library/windows/apps/br230847)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="cfef3-154">See [this element schema article](https://msdn.microsoft.com/library/windows/apps/br230847) for details on this optional attribute.</span></span>

**<span data-ttu-id="cfef3-155">&lt;text&gt; 内の属性</span><span class="sxs-lookup"><span data-stu-id="cfef3-155">Attributes in &lt;text&gt;</span></span>**

<span data-ttu-id="cfef3-156">lang?</span><span class="sxs-lookup"><span data-stu-id="cfef3-156">lang?</span></span>

-   <span data-ttu-id="cfef3-157">この省略可能な属性について詳しくは、[要素のスキーマに関するこの記事](https://msdn.microsoft.com/library/windows/apps/br230847)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="cfef3-157">See [this element schema article](https://msdn.microsoft.com/library/windows/apps/br230847) for details on this optional attribute.</span></span>

**<span data-ttu-id="cfef3-158">&lt;image&gt; 内の属性</span><span class="sxs-lookup"><span data-stu-id="cfef3-158">Attributes in &lt;image&gt;</span></span>**

<span data-ttu-id="cfef3-159">src</span><span class="sxs-lookup"><span data-stu-id="cfef3-159">src</span></span>

-   <span data-ttu-id="cfef3-160">この必須の属性について詳しくは、[要素のスキーマに関するこの記事](https://msdn.microsoft.com/library/windows/apps/br230844)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="cfef3-160">See [this element schema article](https://msdn.microsoft.com/library/windows/apps/br230844) for details on this required attribute.</span></span>

<span data-ttu-id="cfef3-161">placement?</span><span class="sxs-lookup"><span data-stu-id="cfef3-161">placement?</span></span>

-   <span data-ttu-id="cfef3-162">placement?</span><span class="sxs-lookup"><span data-stu-id="cfef3-162">placement?</span></span> <span data-ttu-id="cfef3-163"> = "inline" | "appLogoOverride"</span><span class="sxs-lookup"><span data-stu-id="cfef3-163">= "inline" | "appLogoOverride"</span></span>
-   <span data-ttu-id="cfef3-164">この属性は省略可能です。</span><span class="sxs-lookup"><span data-stu-id="cfef3-164">This attribute is optional.</span></span>
-   <span data-ttu-id="cfef3-165">この属性は、画像が表示される場所を指定します。</span><span class="sxs-lookup"><span data-stu-id="cfef3-165">This specifies where this image will be displayed.</span></span>
-   <span data-ttu-id="cfef3-166">"inline" は、トースト通知本文内のテキストの下に表示されることを意味します。"appLogoOverride" は、アプリケーション アイコン (トースト通知の左上隅に表示される) を置き換えることを意味します。</span><span class="sxs-lookup"><span data-stu-id="cfef3-166">"inline" means inside the toast body, below the text; "appLogoOverride" means replace the application icon (that shows up on the top left corner of the toast).</span></span>
-   <span data-ttu-id="cfef3-167">各 placement の値に指定できる画像は 1 つまでです。</span><span class="sxs-lookup"><span data-stu-id="cfef3-167">You can have up to one image for each placement value.</span></span>

<span data-ttu-id="cfef3-168">alt?</span><span class="sxs-lookup"><span data-stu-id="cfef3-168">alt?</span></span>

-   <span data-ttu-id="cfef3-169">この省略可能な属性について詳しくは、[要素のスキーマに関するこの記事](https://msdn.microsoft.com/library/windows/apps/br230844)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="cfef3-169">See [this element schema article](https://msdn.microsoft.com/library/windows/apps/br230844) for details on this optional attribute.</span></span>

<span data-ttu-id="cfef3-170">addImageQuery?</span><span class="sxs-lookup"><span data-stu-id="cfef3-170">addImageQuery?</span></span>

-   <span data-ttu-id="cfef3-171">この省略可能な属性について詳しくは、[要素のスキーマに関するこの記事](https://msdn.microsoft.com/library/windows/apps/br230844)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="cfef3-171">See [this element schema article](https://msdn.microsoft.com/library/windows/apps/br230844) for details on this optional attribute.</span></span>

<span data-ttu-id="cfef3-172">hint-crop?</span><span class="sxs-lookup"><span data-stu-id="cfef3-172">hint-crop?</span></span>

-   <span data-ttu-id="cfef3-173">hint-crop?</span><span class="sxs-lookup"><span data-stu-id="cfef3-173">hint-crop?</span></span> <span data-ttu-id="cfef3-174"> = "none" | "circle"</span><span class="sxs-lookup"><span data-stu-id="cfef3-174">= "none" | "circle"</span></span>
-   <span data-ttu-id="cfef3-175">この属性は省略可能です。</span><span class="sxs-lookup"><span data-stu-id="cfef3-175">This attribute is optional.</span></span>
-   <span data-ttu-id="cfef3-176">既定値は "none" であり、トリミングされないことを意味します。</span><span class="sxs-lookup"><span data-stu-id="cfef3-176">"none" is the default value which means no cropping.</span></span>
-   <span data-ttu-id="cfef3-177">"circle" を指定すると、画像が円形にトリミングされます。</span><span class="sxs-lookup"><span data-stu-id="cfef3-177">"circle" crops the image to a circular shape.</span></span> <span data-ttu-id="cfef3-178">連絡先のプロフィール画像、人物の画像などにこの属性を使います。</span><span class="sxs-lookup"><span data-stu-id="cfef3-178">Use this for profile images of a contact, images of a person, and so on.</span></span>

**<span data-ttu-id="cfef3-179">&lt;audio&gt; 内の属性</span><span class="sxs-lookup"><span data-stu-id="cfef3-179">Attributes in &lt;audio&gt;</span></span>**

<span data-ttu-id="cfef3-180">src?</span><span class="sxs-lookup"><span data-stu-id="cfef3-180">src?</span></span>

-   <span data-ttu-id="cfef3-181">この省略可能な属性について詳しくは、[要素のスキーマに関するこの記事](https://msdn.microsoft.com/library/windows/apps/br230842)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="cfef3-181">See [this element schema article](https://msdn.microsoft.com/library/windows/apps/br230842) for details on this optional attribute.</span></span>

<span data-ttu-id="cfef3-182">loop?</span><span class="sxs-lookup"><span data-stu-id="cfef3-182">loop?</span></span>

-   <span data-ttu-id="cfef3-183">この省略可能な属性について詳しくは、[要素のスキーマに関するこの記事](https://msdn.microsoft.com/library/windows/apps/br230842)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="cfef3-183">See [this element schema article](https://msdn.microsoft.com/library/windows/apps/br230842) for details on this optional attribute.</span></span>

<span data-ttu-id="cfef3-184">silent?</span><span class="sxs-lookup"><span data-stu-id="cfef3-184">silent?</span></span>

-   <span data-ttu-id="cfef3-185">この省略可能な属性について詳しくは、[要素のスキーマに関するこの記事](https://msdn.microsoft.com/library/windows/apps/br230842)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="cfef3-185">See [this element schema article](https://msdn.microsoft.com/library/windows/apps/br230842) for details on this optional attribute.</span></span>

## <a name="schemas-ltactiongt"></a><span data-ttu-id="cfef3-186">スキーマ: &lt;action&gt;</span><span class="sxs-lookup"><span data-stu-id="cfef3-186">Schemas: &lt;action&gt;</span></span>


<span data-ttu-id="cfef3-187">次の XML スキーマで、"?" サフィックスは属性が省略可能であることを意味します。</span><span class="sxs-lookup"><span data-stu-id="cfef3-187">In the following XML schemas, a "?" suffix means that an attribute is optional.</span></span>

```
<toast>
  <visual>
  </visual>
  <audio />
  <actions>
    <input id type title? placeHolderContent? defaultInput? >
      <selection id content />
    </input>
    <action content arguments activationType? imageUri? hint-inputId />
  </actions>
</toast>
```

**<span data-ttu-id="cfef3-188">&lt;input&gt; 内の属性</span><span class="sxs-lookup"><span data-stu-id="cfef3-188">Attributes in &lt;input&gt;</span></span>**

<span data-ttu-id="cfef3-189">id</span><span class="sxs-lookup"><span data-stu-id="cfef3-189">id</span></span>

-   <span data-ttu-id="cfef3-190">id = 文字列</span><span class="sxs-lookup"><span data-stu-id="cfef3-190">id = string</span></span>
-   <span data-ttu-id="cfef3-191">この属性は必須です。</span><span class="sxs-lookup"><span data-stu-id="cfef3-191">This attribute is required.</span></span>
-   <span data-ttu-id="cfef3-192">id 属性は必須の属性であり、アプリが (フォアグラウンドまたはバックグラウンドで) アクティブ化されたときにユーザー入力を取得するために使われます。</span><span class="sxs-lookup"><span data-stu-id="cfef3-192">The id attribute is required and is used by developers to retrieve user inputs once the app is activated (in the foreground or background).</span></span>

<span data-ttu-id="cfef3-193">type</span><span class="sxs-lookup"><span data-stu-id="cfef3-193">type</span></span>

-   <span data-ttu-id="cfef3-194">type = "text | selection"</span><span class="sxs-lookup"><span data-stu-id="cfef3-194">type = "text | selection"</span></span>
-   <span data-ttu-id="cfef3-195">この属性は必須です。</span><span class="sxs-lookup"><span data-stu-id="cfef3-195">This attribute is required.</span></span>
-   <span data-ttu-id="cfef3-196">この属性を使って、テキスト入力であるか、事前に定義された選択項目の一覧からの入力であるかを指定します。</span><span class="sxs-lookup"><span data-stu-id="cfef3-196">It is used to specify a text input or input from a list of pre-defined selections.</span></span>
-   <span data-ttu-id="cfef3-197">モバイルやデスクトップでは、この属性は、テキスト ボックスによる入力を使うか、リスト ボックスによる入力を使うかを指定します。</span><span class="sxs-lookup"><span data-stu-id="cfef3-197">On mobile and desktop, this is to specify whether you want a textbox input or a listbox input.</span></span>

<span data-ttu-id="cfef3-198">title?</span><span class="sxs-lookup"><span data-stu-id="cfef3-198">title?</span></span>

-   <span data-ttu-id="cfef3-199">title?</span><span class="sxs-lookup"><span data-stu-id="cfef3-199">title?</span></span> <span data-ttu-id="cfef3-200"> = 文字列</span><span class="sxs-lookup"><span data-stu-id="cfef3-200">= string</span></span>
-   <span data-ttu-id="cfef3-201">title 属性は省略可能です。開発者は、シェルの入力に対してタイトルを指定し、アフォーダンスがあるときに表示します。</span><span class="sxs-lookup"><span data-stu-id="cfef3-201">The title attribute is optional and is for developers to specify a title for the input for shells to render when there is affordance.</span></span>
-   <span data-ttu-id="cfef3-202">モバイルやデスクトップでは、入力の上にこのタイトルが表示されます。</span><span class="sxs-lookup"><span data-stu-id="cfef3-202">For mobile and desktop, this title will be displayed above the input.</span></span>

<span data-ttu-id="cfef3-203">placeHolderContent?</span><span class="sxs-lookup"><span data-stu-id="cfef3-203">placeHolderContent?</span></span>

-   <span data-ttu-id="cfef3-204">placeHolderContent?</span><span class="sxs-lookup"><span data-stu-id="cfef3-204">placeHolderContent?</span></span> <span data-ttu-id="cfef3-205"> = 文字列</span><span class="sxs-lookup"><span data-stu-id="cfef3-205">= string</span></span>
-   <span data-ttu-id="cfef3-206">placeHolderContent 属性は省略可能です。入力の種類が text の場合に、ヒントのテキストを灰色で表示します。</span><span class="sxs-lookup"><span data-stu-id="cfef3-206">The placeHolderContent attribute is optional and is the grey-out hint text for text input type.</span></span> <span data-ttu-id="cfef3-207">入力の種類が "text" 以外の場合、この属性は無視されます。</span><span class="sxs-lookup"><span data-stu-id="cfef3-207">This attribute is ignored when the input type is not "text".</span></span>

<span data-ttu-id="cfef3-208">defaultInput?</span><span class="sxs-lookup"><span data-stu-id="cfef3-208">defaultInput?</span></span>

-   <span data-ttu-id="cfef3-209">defaultInput?</span><span class="sxs-lookup"><span data-stu-id="cfef3-209">defaultInput?</span></span> <span data-ttu-id="cfef3-210"> = 文字列</span><span class="sxs-lookup"><span data-stu-id="cfef3-210">= string</span></span>
-   <span data-ttu-id="cfef3-211">defaultInput 属性は省略可能です。既定の入力値を指定するために使われます。</span><span class="sxs-lookup"><span data-stu-id="cfef3-211">The defaultInput attribute is optional and is used to provide a default input value.</span></span>
-   <span data-ttu-id="cfef3-212">入力の種類が "text" である場合、この属性は文字列入力として処理されます。</span><span class="sxs-lookup"><span data-stu-id="cfef3-212">If the input type is "text", this will be treated as a string input.</span></span>
-   <span data-ttu-id="cfef3-213">入力の種類が "selection" である場合、この属性は、入力の要素内で利用できるいずれかの選択項目の ID として処理されます。</span><span class="sxs-lookup"><span data-stu-id="cfef3-213">If the input type is "selection", this is expected to be the id of one of the available selections inside this input's elements.</span></span>

**<span data-ttu-id="cfef3-214">&lt;selection&gt; 内の属性</span><span class="sxs-lookup"><span data-stu-id="cfef3-214">Attributes in &lt;selection&gt;</span></span>**

<span data-ttu-id="cfef3-215">id</span><span class="sxs-lookup"><span data-stu-id="cfef3-215">id</span></span>

-   <span data-ttu-id="cfef3-216">この属性は必須です。</span><span class="sxs-lookup"><span data-stu-id="cfef3-216">This attribute is required.</span></span> <span data-ttu-id="cfef3-217">ユーザーの選択項目を特定するために使われます。</span><span class="sxs-lookup"><span data-stu-id="cfef3-217">It's used to identify user selections.</span></span> <span data-ttu-id="cfef3-218">id はアプリに返されます。</span><span class="sxs-lookup"><span data-stu-id="cfef3-218">The id is returned to your app.</span></span>

<span data-ttu-id="cfef3-219">content</span><span class="sxs-lookup"><span data-stu-id="cfef3-219">content</span></span>

-   <span data-ttu-id="cfef3-220">この属性は必須です。</span><span class="sxs-lookup"><span data-stu-id="cfef3-220">This attribute is required.</span></span> <span data-ttu-id="cfef3-221">この selection 要素に対して表示する文字列を指定します。</span><span class="sxs-lookup"><span data-stu-id="cfef3-221">It provides the string to display for this selection element.</span></span>

**<span data-ttu-id="cfef3-222">&lt;action&gt; 内の属性</span><span class="sxs-lookup"><span data-stu-id="cfef3-222">Attributes in &lt;action&gt;</span></span>**

<span data-ttu-id="cfef3-223">content</span><span class="sxs-lookup"><span data-stu-id="cfef3-223">content</span></span>

-   <span data-ttu-id="cfef3-224">content = 文字列</span><span class="sxs-lookup"><span data-stu-id="cfef3-224">content = string</span></span>
-   <span data-ttu-id="cfef3-225">content 属性は必須です。</span><span class="sxs-lookup"><span data-stu-id="cfef3-225">The content attribute is required.</span></span> <span data-ttu-id="cfef3-226">ボタンに表示されるテキスト文字列を指定します。</span><span class="sxs-lookup"><span data-stu-id="cfef3-226">It provides the text string displayed on the button.</span></span>

<span data-ttu-id="cfef3-227">arguments</span><span class="sxs-lookup"><span data-stu-id="cfef3-227">arguments</span></span>

-   <span data-ttu-id="cfef3-228">arguments = 文字列</span><span class="sxs-lookup"><span data-stu-id="cfef3-228">arguments = string</span></span>
-   <span data-ttu-id="cfef3-229">arguments 属性は必須です。</span><span class="sxs-lookup"><span data-stu-id="cfef3-229">The arguments attribute it required.</span></span> <span data-ttu-id="cfef3-230">この属性は、アプリによって定義されたデータを表します。ユーザーがこの action を実行し、アプリがアクティブ化された後で、アプリはこのデータを取得することができます。</span><span class="sxs-lookup"><span data-stu-id="cfef3-230">It describes the app-defined data that the app can later retrieve once it is activated from user taking this action.</span></span>

<span data-ttu-id="cfef3-231">activationType?</span><span class="sxs-lookup"><span data-stu-id="cfef3-231">activationType?</span></span>

-   <span data-ttu-id="cfef3-232">activationType?</span><span class="sxs-lookup"><span data-stu-id="cfef3-232">activationType?</span></span> <span data-ttu-id="cfef3-233"> = "foreground | background | protocol | system"</span><span class="sxs-lookup"><span data-stu-id="cfef3-233">= "foreground | background | protocol | system"</span></span>
-   <span data-ttu-id="cfef3-234">activationType 属性は省略可能です。既定値は "foreground" です。</span><span class="sxs-lookup"><span data-stu-id="cfef3-234">The activationType attribute is optional and its default value is "foreground".</span></span>
-   <span data-ttu-id="cfef3-235">この属性は、この action によって行われるアクティブ化の種類を表します (フォアグラウンド、バックグラウンド、プロトコル起動による別のアプリの起動、またはシステム操作の呼び出し)。</span><span class="sxs-lookup"><span data-stu-id="cfef3-235">It describes the kind of activation this action will cause: foreground, background, or launching another app via protocol launch, or invoking a system action.</span></span>

<span data-ttu-id="cfef3-236">imageUri?</span><span class="sxs-lookup"><span data-stu-id="cfef3-236">imageUri?</span></span>

-   <span data-ttu-id="cfef3-237">imageUri?</span><span class="sxs-lookup"><span data-stu-id="cfef3-237">imageUri?</span></span> <span data-ttu-id="cfef3-238"> = 文字列</span><span class="sxs-lookup"><span data-stu-id="cfef3-238">= string</span></span>
-   <span data-ttu-id="cfef3-239">imageUri は省略可能です。この action 用の画像アイコンを指定するために使われます。このアイコンは、テキスト コンテンツと共にボタン内に表示されます。</span><span class="sxs-lookup"><span data-stu-id="cfef3-239">imageUri is optional and is used to provide an image icon for this action to display inside the button alone with the text content.</span></span>

<span data-ttu-id="cfef3-240">hint-inputId</span><span class="sxs-lookup"><span data-stu-id="cfef3-240">hint-inputId</span></span>

-   <span data-ttu-id="cfef3-241">hint-inputId = 文字列</span><span class="sxs-lookup"><span data-stu-id="cfef3-241">hint-inputId = string</span></span>
-   <span data-ttu-id="cfef3-242">hint-inpudId 属性は必須です。</span><span class="sxs-lookup"><span data-stu-id="cfef3-242">The hint-inpudId attribute is required.</span></span> <span data-ttu-id="cfef3-243">特に、すばやく応答するシナリオで使われます。</span><span class="sxs-lookup"><span data-stu-id="cfef3-243">It's specifically used for the quick reply scenario.</span></span>
-   <span data-ttu-id="cfef3-244">値は、この属性に関連付ける必要がある入力要素の ID にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="cfef3-244">The value needs to be the id of the input element desired to be associated with.</span></span>
-   <span data-ttu-id="cfef3-245">モバイルやデスクトップでは、この属性によって、入力ボックスのすぐ横にボタンが配置されます。</span><span class="sxs-lookup"><span data-stu-id="cfef3-245">In mobile and desktop, this will put the button right next to the input box.</span></span>

## <a name="attributes-for-system-handled-actions"></a><span data-ttu-id="cfef3-246">システムによって処理される操作の属性</span><span class="sxs-lookup"><span data-stu-id="cfef3-246">Attributes for system-handled actions</span></span>


<span data-ttu-id="cfef3-247">アプリで再通知や通知の再スケジュールをバックグラウンド タスクとして処理しない場合は、システムで、再通知や通知を閉じるための操作を処理できます。</span><span class="sxs-lookup"><span data-stu-id="cfef3-247">The system can handle actions for snoozing and dismissing notifications if you don't want your app to handle the snoozing/rescheduling of notifications as a background task.</span></span> <span data-ttu-id="cfef3-248">システムによって処理される操作は、組み合わせることができます (または個別に指定することもできます)。ただし、閉じる操作を使わないで再通知の操作を実装することはお勧めしません。</span><span class="sxs-lookup"><span data-stu-id="cfef3-248">System-handled actions can be combined (or individually specified), but we don't recommend implementing a snooze action without a dismiss action.</span></span>

<span data-ttu-id="cfef3-249">システム コマンドの組み合わせ: SnoozeAndDismiss</span><span class="sxs-lookup"><span data-stu-id="cfef3-249">System commands combo: SnoozeAndDismiss</span></span>

```
<toast>
  <visual>
  </visual>
  <actions hint-systemCommands="SnoozeAndDismiss" />
</toast>
```

<span data-ttu-id="cfef3-250">システムによって処理される操作を個別に指定</span><span class="sxs-lookup"><span data-stu-id="cfef3-250">Individual system-handled actions</span></span>

```
<toast>
  <visual>
  </visual>
  <actions>
  <input id="snoozeTime" type="selection" defaultInput="10">
    <selection id="5" content="5 minutes" />
    <selection id="10" content="10 minutes" />
    <selection id="20" content="20 minutes" />
    <selection id="30" content="30 minutes" />
    <selection id="60" content="1 hour" />
  </input>
  <action activationType="system" arguments="snooze" hint-inputId="snoozeTime" content=""/>
  <action activationType="system" arguments="dismiss" content=""/>
  </actions>
</toast>
```

<span data-ttu-id="cfef3-251">再通知や閉じる操作を個別に指定するには、次の手順に従います。</span><span class="sxs-lookup"><span data-stu-id="cfef3-251">To construct individual snooze and dismiss actions, do the following:</span></span>

-   <span data-ttu-id="cfef3-252">activationType = "system" を指定します。</span><span class="sxs-lookup"><span data-stu-id="cfef3-252">Specify activationType = "system"</span></span>
-   <span data-ttu-id="cfef3-253">arguments = "snooze" または arguments = "dismiss" を指定します。</span><span class="sxs-lookup"><span data-stu-id="cfef3-253">Specify arguments = "snooze" | "dismiss"</span></span>
-   <span data-ttu-id="cfef3-254">content を指定します。</span><span class="sxs-lookup"><span data-stu-id="cfef3-254">Specify content:</span></span>
    -   <span data-ttu-id="cfef3-255">"snooze" (一時停止する) や "dismiss" (無視) に対応するローカライズされた文字列を操作に対して表示する場合は、content に空の文字列を指定します (&lt;action content = ""/&gt;)。</span><span class="sxs-lookup"><span data-stu-id="cfef3-255">If you want localized strings of "snooze" and "dismiss" to be displayed on the actions, specify content to be an empty string: &lt;action content = ""/&gt;</span></span>
    -   <span data-ttu-id="cfef3-256">カスタマイズした文字列を使用する場合は、その値を指定します (&lt;action content="Remind me later" /&gt;)。</span><span class="sxs-lookup"><span data-stu-id="cfef3-256">If you want a customized string, just provide its value: &lt;action content="Remind me later" /&gt;</span></span>
-   <span data-ttu-id="cfef3-257">input を指定します。</span><span class="sxs-lookup"><span data-stu-id="cfef3-257">Specify input:</span></span>
    -   <span data-ttu-id="cfef3-258">再通知の間隔をユーザーが選ぶのではなく、システム定義の時間間隔 (OS 全体で一貫しています) に応じて 1 回だけ再通知を行う場合は、&lt;input&gt; を指定しないでください。</span><span class="sxs-lookup"><span data-stu-id="cfef3-258">If you don't want the user to select a snooze interval and instead just want your notification to snooze only once for a system-defined time interval (that is consistent across the OS), then don't construct any &lt;input&gt; at all.</span></span>
    -   <span data-ttu-id="cfef3-259">再通知の間隔に関する選択項目を指定する場合:</span><span class="sxs-lookup"><span data-stu-id="cfef3-259">If you want to provide snooze interval selections:</span></span>
        -   <span data-ttu-id="cfef3-260">再通知の操作内に、hint-inputId を指定します。</span><span class="sxs-lookup"><span data-stu-id="cfef3-260">Specify hint-inputId in the snooze action</span></span>
        -   <span data-ttu-id="cfef3-261">input の id に、再通知の操作の hint-inputId と同じ値を指定します (&lt;input id="snoozeTime"&gt;&lt;/input&gt;&lt;action hint-inputId="snoozeTime"/&gt;)。</span><span class="sxs-lookup"><span data-stu-id="cfef3-261">Match the id of the input with the hint-inputId of the snooze action: &lt;input id="snoozeTime"&gt;&lt;/input&gt;&lt;action hint-inputId="snoozeTime"/&gt;</span></span>
        -   <span data-ttu-id="cfef3-262">selection の id に、再通知の間隔を分単位で表す負以外の整数を指定します。&lt;selection id="240" /&gt; は、再通知の間隔が 4 時間であることを示します。</span><span class="sxs-lookup"><span data-stu-id="cfef3-262">Specify selection id to be a nonNegativeInteger which represents snooze interval in minutes: &lt;selection id="240" /&gt; means snoozing for 4 hours</span></span>
        -   <span data-ttu-id="cfef3-263">&lt;input&gt; の defaultInput の値が、&lt;selection&gt; 子要素の id のいずれかと一致することを確認します。</span><span class="sxs-lookup"><span data-stu-id="cfef3-263">Make sure that the value of defaultInput in &lt;input&gt; matches with one of the ids of the &lt;selection&gt; children elements</span></span>
        -   <span data-ttu-id="cfef3-264">&lt;selection&gt; の値は、最大で 5 つまで指定できます。</span><span class="sxs-lookup"><span data-stu-id="cfef3-264">Provide up to (but no more than) 5 &lt;selection&gt; values</span></span>