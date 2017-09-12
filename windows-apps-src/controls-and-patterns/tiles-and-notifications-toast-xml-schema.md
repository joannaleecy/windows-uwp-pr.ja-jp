---
author: lex
Description: "この記事では、トースト通知のコンテンツの XML ペイロードにあるすべてのプロパティと要素を説明します。"
title: "トースト通知のコンテンツの XML スキーマ"
ms.assetid: AF49EFAC-447E-44C3-93C3-CCBEDCF07D22
label: Toast content XML schema
template: detail.hbs
ms.author: mijacobs
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10、UWP"
ms.openlocfilehash: ae140ebde954726d0ecf16d731010149aea2fbe5
ms.sourcegitcommit: 10d6736a0827fe813c3c6e8d26d67b20ff110f6c
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/22/2017
---
# <a name="toast-content-xml-schema"></a><span data-ttu-id="421cc-104">トースト通知のコンテンツの XML スキーマ</span><span class="sxs-lookup"><span data-stu-id="421cc-104">Toast content XML schema</span></span>

<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css"> 

<span data-ttu-id="421cc-105">ここでは、トースト通知のコンテンツの XML ペイロードにあるすべてのプロパティと要素を説明します。</span><span class="sxs-lookup"><span data-stu-id="421cc-105">The following describes all of the properties and elements within the toast content XML payload.</span></span>

<span data-ttu-id="421cc-106">次の XML スキーマで、"?" サフィックスは属性が省略可能であることを意味します。</span><span class="sxs-lookup"><span data-stu-id="421cc-106">In the following XML schemas, a "?" suffix means that an attribute is optional.</span></span>

## <a name="ltvisualgt-and-ltaudiogt"></a>&lt;<span data-ttu-id="421cc-107"><visual&gt; および &lt;audio></span><span class="sxs-lookup"><span data-stu-id="421cc-107">visual&gt; and &lt;audio</span></span>&gt;

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

**<span data-ttu-id="421cc-108">&lt;toast> 内の属性</span><span class="sxs-lookup"><span data-stu-id="421cc-108">Attributes in &lt;toast</span></span>&gt;**

<span data-ttu-id="421cc-109">launch?</span><span class="sxs-lookup"><span data-stu-id="421cc-109">launch?</span></span>

-   <span data-ttu-id="421cc-110">launch?</span><span class="sxs-lookup"><span data-stu-id="421cc-110">launch?</span></span> <span data-ttu-id="421cc-111"> = 文字列</span><span class="sxs-lookup"><span data-stu-id="421cc-111">= string</span></span>
-   <span data-ttu-id="421cc-112">この属性は省略可能です。</span><span class="sxs-lookup"><span data-stu-id="421cc-112">This is an optional attribute.</span></span>
-   <span data-ttu-id="421cc-113">トースト通知によってアプリケーションがアクティブ化されるときにアプリケーションに渡される文字列です。</span><span class="sxs-lookup"><span data-stu-id="421cc-113">A string that is passed to the application when it is activated by the toast.</span></span>
-   <span data-ttu-id="421cc-114">activationType の値に応じて、この値は、フォアグラウンドのアプリ、バックグラウンド タスクの内部、または元のアプリからプロトコル起動された他のアプリで取得することができます。</span><span class="sxs-lookup"><span data-stu-id="421cc-114">Depending on the value of activationType, this value can be received by the app in the foreground, inside the background task, or by another app that's protocol launched from the original app.</span></span>
-   <span data-ttu-id="421cc-115">この文字列の形式とコンテンツは、アプリ独自の使用方法に合わせて、アプリによって定義されます。</span><span class="sxs-lookup"><span data-stu-id="421cc-115">The format and contents of this string are defined by the app for its own use.</span></span>
-   <span data-ttu-id="421cc-116">ユーザーがトースト通知をタップまたはクリックし、関連するアプリを起動すると、そのアプリは既定の方法で起動されるのではなく、起動文字列によって、そのコンテキストがアプリに渡され、トースト通知のコンテンツに関連するビューがユーザーに表示されます。</span><span class="sxs-lookup"><span data-stu-id="421cc-116">When the user taps or clicks the toast to launch its associated app, the launch string provides the context to the app that allows it to show the user a view relevant to the toast content, rather than launching in its default way.</span></span>
-   <span data-ttu-id="421cc-117">ユーザーがトースト通知の本文ではなく操作をクリックしたことによってアクティブ化が行われた場合、&lt;toast&gt; タグ内に定義済みの "launch" ではなく、&lt;action&gt; タグ内に事前に定義されている "arguments" が取得されます。</span><span class="sxs-lookup"><span data-stu-id="421cc-117">If the activation is happened because user clicked on an action, instead of the body of the toast, the developer retrieves back the "arguments" pre-defined in that &lt;action&gt; tag, instead of "launch" pre-defined in the &lt;toast&gt; tag.</span></span>

<span data-ttu-id="421cc-118">duration?</span><span class="sxs-lookup"><span data-stu-id="421cc-118">duration?</span></span>

-   <span data-ttu-id="421cc-119">duration?</span><span class="sxs-lookup"><span data-stu-id="421cc-119">duration?</span></span> <span data-ttu-id="421cc-120"> = "short|long"</span><span class="sxs-lookup"><span data-stu-id="421cc-120">= "short|long"</span></span>
-   <span data-ttu-id="421cc-121">この属性は省略可能です。</span><span class="sxs-lookup"><span data-stu-id="421cc-121">This is an optional attribute.</span></span> <span data-ttu-id="421cc-122">既定値は "short" です。</span><span class="sxs-lookup"><span data-stu-id="421cc-122">Default value is "short".</span></span>
-   <span data-ttu-id="421cc-123">これは、特定のシナリオやアプリケーションの互換性のみを目的とした属性です。</span><span class="sxs-lookup"><span data-stu-id="421cc-123">This is only here for specific scenarios and appCompat.</span></span> <span data-ttu-id="421cc-124">アラーム シナリオでは、この属性は必要ありません。</span><span class="sxs-lookup"><span data-stu-id="421cc-124">You don't need this for the alarm scenario anymore.</span></span>
-   <span data-ttu-id="421cc-125">このプロパティを使うことはお勧めしません。</span><span class="sxs-lookup"><span data-stu-id="421cc-125">We don't recommend using this property.</span></span>

<span data-ttu-id="421cc-126">activationType?</span><span class="sxs-lookup"><span data-stu-id="421cc-126">activationType?</span></span>

-   <span data-ttu-id="421cc-127">activationType?</span><span class="sxs-lookup"><span data-stu-id="421cc-127">activationType?</span></span> <span data-ttu-id="421cc-128"> = "foreground | background | protocol | system"</span><span class="sxs-lookup"><span data-stu-id="421cc-128">= "foreground | background | protocol | system"</span></span>
-   <span data-ttu-id="421cc-129">この属性は省略可能です。</span><span class="sxs-lookup"><span data-stu-id="421cc-129">This is an optional attribute.</span></span>
-   <span data-ttu-id="421cc-130">既定値は "foreground" です。</span><span class="sxs-lookup"><span data-stu-id="421cc-130">The default value is "foreground".</span></span>

<span data-ttu-id="421cc-131">scenario?</span><span class="sxs-lookup"><span data-stu-id="421cc-131">scenario?</span></span>

-   <span data-ttu-id="421cc-132">scenario?</span><span class="sxs-lookup"><span data-stu-id="421cc-132">scenario?</span></span> <span data-ttu-id="421cc-133"> = "default | alarm | reminder | incomingCall"</span><span class="sxs-lookup"><span data-stu-id="421cc-133">= "default | alarm | reminder | incomingCall"</span></span>
-   <span data-ttu-id="421cc-134">この属性は省略可能です。既定値は "default" です。</span><span class="sxs-lookup"><span data-stu-id="421cc-134">This is an optional attribute, default value is "default".</span></span>
-   <span data-ttu-id="421cc-135">シナリオがアラーム、リマインダー、着信呼び出しの表示以外の場合、この属性は必要ありません。</span><span class="sxs-lookup"><span data-stu-id="421cc-135">You do not need this unless your scenario is to pop an alarm, reminder, or incoming call.</span></span>
-   <span data-ttu-id="421cc-136">通知を常に画面上に表示することのみを目的とする場合は、この属性を使わないでください。</span><span class="sxs-lookup"><span data-stu-id="421cc-136">Do not use this just for keeping your notification persistent on screen.</span></span>

**<span data-ttu-id="421cc-137">&lt;visual> 内の属性</span><span class="sxs-lookup"><span data-stu-id="421cc-137">Attributes in &lt;visual</span></span>&gt;**

<span data-ttu-id="421cc-138">lang?</span><span class="sxs-lookup"><span data-stu-id="421cc-138">lang?</span></span>

-   <span data-ttu-id="421cc-139">この省略可能な属性について詳しくは、[要素のスキーマに関するこの記事](https://msdn.microsoft.com/library/windows/apps/br230847)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="421cc-139">See [this element schema article](https://msdn.microsoft.com/library/windows/apps/br230847) for details on this optional attribute.</span></span>

<span data-ttu-id="421cc-140">baseUri?</span><span class="sxs-lookup"><span data-stu-id="421cc-140">baseUri?</span></span>

-   <span data-ttu-id="421cc-141">この省略可能な属性について詳しくは、[要素のスキーマに関するこの記事](https://msdn.microsoft.com/library/windows/apps/br230847)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="421cc-141">See [this element schema article](https://msdn.microsoft.com/library/windows/apps/br230847) for details on this optional attribute.</span></span>

<span data-ttu-id="421cc-142">addImageQuery?</span><span class="sxs-lookup"><span data-stu-id="421cc-142">addImageQuery?</span></span>

-   <span data-ttu-id="421cc-143">この省略可能な属性について詳しくは、[要素のスキーマに関するこの記事](https://msdn.microsoft.com/library/windows/apps/br230847)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="421cc-143">See [this element schema article](https://msdn.microsoft.com/library/windows/apps/br230847) for details on this optional attribute.</span></span>

**<span data-ttu-id="421cc-144">&lt;binding> 内の属性</span><span class="sxs-lookup"><span data-stu-id="421cc-144">Attributes in &lt;binding</span></span>&gt;**

<span data-ttu-id="421cc-145">template?</span><span class="sxs-lookup"><span data-stu-id="421cc-145">template?</span></span>

-   <span data-ttu-id="421cc-146">\[重要\] template?</span><span class="sxs-lookup"><span data-stu-id="421cc-146">\[Important\] template?</span></span> <span data-ttu-id="421cc-147"> = "ToastGeneric"</span><span class="sxs-lookup"><span data-stu-id="421cc-147">= "ToastGeneric"</span></span>
-   <span data-ttu-id="421cc-148">新しいアダプティブ通知と対話型通知の機能を使う場合は、従来のテンプレートではなく、必ず "ToastGeneric" テンプレートを使って作業を始めてください。</span><span class="sxs-lookup"><span data-stu-id="421cc-148">If you are using any of the new adaptive and interactive notification features, please make sure you start using "ToastGeneric" template instead of the legacy template.</span></span>
-   <span data-ttu-id="421cc-149">新しい操作で従来のテンプレートを使うと、現時点では動作する可能性があります。ただし、この方法は対象となる使用方法ではないため、今後も引き続き動作するかどうかは保証できません。</span><span class="sxs-lookup"><span data-stu-id="421cc-149">Using the legacy templates with the new actions might work now, but that is not the intended use case, and we cannot guarantee that will continue working.</span></span>

<span data-ttu-id="421cc-150">lang?</span><span class="sxs-lookup"><span data-stu-id="421cc-150">lang?</span></span>

-   <span data-ttu-id="421cc-151">この省略可能な属性について詳しくは、[要素のスキーマに関するこの記事](https://msdn.microsoft.com/library/windows/apps/br230847)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="421cc-151">See [this element schema article](https://msdn.microsoft.com/library/windows/apps/br230847) for details on this optional attribute.</span></span>

<span data-ttu-id="421cc-152">baseUri?</span><span class="sxs-lookup"><span data-stu-id="421cc-152">baseUri?</span></span>

-   <span data-ttu-id="421cc-153">この省略可能な属性について詳しくは、[要素のスキーマに関するこの記事](https://msdn.microsoft.com/library/windows/apps/br230847)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="421cc-153">See [this element schema article](https://msdn.microsoft.com/library/windows/apps/br230847) for details on this optional attribute.</span></span>

<span data-ttu-id="421cc-154">addImageQuery?</span><span class="sxs-lookup"><span data-stu-id="421cc-154">addImageQuery?</span></span>

-   <span data-ttu-id="421cc-155">この省略可能な属性について詳しくは、[要素のスキーマに関するこの記事](https://msdn.microsoft.com/library/windows/apps/br230847)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="421cc-155">See [this element schema article](https://msdn.microsoft.com/library/windows/apps/br230847) for details on this optional attribute.</span></span>

**<span data-ttu-id="421cc-156">&lt;text> 内の属性</span><span class="sxs-lookup"><span data-stu-id="421cc-156">Attributes in &lt;text</span></span>&gt;**

<span data-ttu-id="421cc-157">lang?</span><span class="sxs-lookup"><span data-stu-id="421cc-157">lang?</span></span>

-   <span data-ttu-id="421cc-158">この省略可能な属性について詳しくは、[要素のスキーマに関するこの記事](https://msdn.microsoft.com/library/windows/apps/br230847)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="421cc-158">See [this element schema article](https://msdn.microsoft.com/library/windows/apps/br230847) for details on this optional attribute.</span></span>

**<span data-ttu-id="421cc-159">&lt;image> 内の属性</span><span class="sxs-lookup"><span data-stu-id="421cc-159">Attributes in &lt;image</span></span>&gt;**

<span data-ttu-id="421cc-160">src</span><span class="sxs-lookup"><span data-stu-id="421cc-160">src</span></span>

-   <span data-ttu-id="421cc-161">この必須の属性について詳しくは、[要素のスキーマに関するこの記事](https://msdn.microsoft.com/library/windows/apps/br230844)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="421cc-161">See [this element schema article](https://msdn.microsoft.com/library/windows/apps/br230844) for details on this required attribute.</span></span>

<span data-ttu-id="421cc-162">placement?</span><span class="sxs-lookup"><span data-stu-id="421cc-162">placement?</span></span>

-   <span data-ttu-id="421cc-163">placement?</span><span class="sxs-lookup"><span data-stu-id="421cc-163">placement?</span></span> <span data-ttu-id="421cc-164"> = "inline" | "appLogoOverride"</span><span class="sxs-lookup"><span data-stu-id="421cc-164">= "inline" | "appLogoOverride"</span></span>
-   <span data-ttu-id="421cc-165">この属性は省略可能です。</span><span class="sxs-lookup"><span data-stu-id="421cc-165">This attribute is optional.</span></span>
-   <span data-ttu-id="421cc-166">この属性は、画像が表示される場所を指定します。</span><span class="sxs-lookup"><span data-stu-id="421cc-166">This specifies where this image will be displayed.</span></span>
-   <span data-ttu-id="421cc-167">"inline" は、トースト通知本文内のテキストの下に表示されることを意味します。"appLogoOverride" は、アプリケーション アイコン (トースト通知の左上隅に表示される) を置き換えることを意味します。</span><span class="sxs-lookup"><span data-stu-id="421cc-167">"inline" means inside the toast body, below the text; "appLogoOverride" means replace the application icon (that shows up on the top left corner of the toast).</span></span>
-   <span data-ttu-id="421cc-168">各 placement の値に指定できる画像は 1 つまでです。</span><span class="sxs-lookup"><span data-stu-id="421cc-168">You can have up to one image for each placement value.</span></span>

<span data-ttu-id="421cc-169">alt?</span><span class="sxs-lookup"><span data-stu-id="421cc-169">alt?</span></span>

-   <span data-ttu-id="421cc-170">この省略可能な属性について詳しくは、[要素のスキーマに関するこの記事](https://msdn.microsoft.com/library/windows/apps/br230844)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="421cc-170">See [this element schema article](https://msdn.microsoft.com/library/windows/apps/br230844) for details on this optional attribute.</span></span>

<span data-ttu-id="421cc-171">addImageQuery?</span><span class="sxs-lookup"><span data-stu-id="421cc-171">addImageQuery?</span></span>

-   <span data-ttu-id="421cc-172">この省略可能な属性について詳しくは、[要素のスキーマに関するこの記事](https://msdn.microsoft.com/library/windows/apps/br230844)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="421cc-172">See [this element schema article](https://msdn.microsoft.com/library/windows/apps/br230844) for details on this optional attribute.</span></span>

<span data-ttu-id="421cc-173">hint-crop?</span><span class="sxs-lookup"><span data-stu-id="421cc-173">hint-crop?</span></span>

-   <span data-ttu-id="421cc-174">hint-crop?</span><span class="sxs-lookup"><span data-stu-id="421cc-174">hint-crop?</span></span> <span data-ttu-id="421cc-175"> = "none" | "circle"</span><span class="sxs-lookup"><span data-stu-id="421cc-175">= "none" | "circle"</span></span>
-   <span data-ttu-id="421cc-176">この属性は省略可能です。</span><span class="sxs-lookup"><span data-stu-id="421cc-176">This attribute is optional.</span></span>
-   <span data-ttu-id="421cc-177">既定値は "none" であり、トリミングされないことを意味します。</span><span class="sxs-lookup"><span data-stu-id="421cc-177">"none" is the default value which means no cropping.</span></span>
-   <span data-ttu-id="421cc-178">"circle" を指定すると、画像が円形にトリミングされます。</span><span class="sxs-lookup"><span data-stu-id="421cc-178">"circle" crops the image to a circular shape.</span></span> <span data-ttu-id="421cc-179">連絡先のプロフィール画像、人物の画像などにこの属性を使います。</span><span class="sxs-lookup"><span data-stu-id="421cc-179">Use this for profile images of a contact, images of a person, and so on.</span></span>

**<span data-ttu-id="421cc-180">&lt;audio> 内の属性</span><span class="sxs-lookup"><span data-stu-id="421cc-180">Attributes in &lt;audio</span></span>&gt;**

<span data-ttu-id="421cc-181">src?</span><span class="sxs-lookup"><span data-stu-id="421cc-181">src?</span></span>

-   <span data-ttu-id="421cc-182">この省略可能な属性について詳しくは、[要素のスキーマに関するこの記事](https://msdn.microsoft.com/library/windows/apps/br230842)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="421cc-182">See [this element schema article](https://msdn.microsoft.com/library/windows/apps/br230842) for details on this optional attribute.</span></span>

<span data-ttu-id="421cc-183">loop?</span><span class="sxs-lookup"><span data-stu-id="421cc-183">loop?</span></span>

-   <span data-ttu-id="421cc-184">この省略可能な属性について詳しくは、[要素のスキーマに関するこの記事](https://msdn.microsoft.com/library/windows/apps/br230842)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="421cc-184">See [this element schema article](https://msdn.microsoft.com/library/windows/apps/br230842) for details on this optional attribute.</span></span>

<span data-ttu-id="421cc-185">silent?</span><span class="sxs-lookup"><span data-stu-id="421cc-185">silent?</span></span>

-   <span data-ttu-id="421cc-186">この省略可能な属性について詳しくは、[要素のスキーマに関するこの記事](https://msdn.microsoft.com/library/windows/apps/br230842)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="421cc-186">See [this element schema article](https://msdn.microsoft.com/library/windows/apps/br230842) for details on this optional attribute.</span></span>

## <a name="schemas-ltactiongt"></a><span data-ttu-id="421cc-187">スキーマ: &lt;action</span><span class="sxs-lookup"><span data-stu-id="421cc-187">Schemas: &lt;action</span></span>&gt;


<span data-ttu-id="421cc-188">次の XML スキーマで、"?" サフィックスは属性が省略可能であることを意味します。</span><span class="sxs-lookup"><span data-stu-id="421cc-188">In the following XML schemas, a "?" suffix means that an attribute is optional.</span></span>

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

**<span data-ttu-id="421cc-189">&lt;input> 内の属性</span><span class="sxs-lookup"><span data-stu-id="421cc-189">Attributes in &lt;input</span></span>&gt;**

<span data-ttu-id="421cc-190">id</span><span class="sxs-lookup"><span data-stu-id="421cc-190">id</span></span>

-   <span data-ttu-id="421cc-191">id = 文字列</span><span class="sxs-lookup"><span data-stu-id="421cc-191">id = string</span></span>
-   <span data-ttu-id="421cc-192">この属性は必須です。</span><span class="sxs-lookup"><span data-stu-id="421cc-192">This attribute is required.</span></span>
-   <span data-ttu-id="421cc-193">id 属性は必須の属性であり、アプリが (フォアグラウンドまたはバックグラウンドで) アクティブ化されたときにユーザー入力を取得するために使われます。</span><span class="sxs-lookup"><span data-stu-id="421cc-193">The id attribute is required and is used by developers to retrieve user inputs once the app is activated (in the foreground or background).</span></span>

<span data-ttu-id="421cc-194">type</span><span class="sxs-lookup"><span data-stu-id="421cc-194">type</span></span>

-   <span data-ttu-id="421cc-195">type = "text | selection"</span><span class="sxs-lookup"><span data-stu-id="421cc-195">type = "text | selection"</span></span>
-   <span data-ttu-id="421cc-196">この属性は必須です。</span><span class="sxs-lookup"><span data-stu-id="421cc-196">This attribute is required.</span></span>
-   <span data-ttu-id="421cc-197">この属性を使って、テキスト入力であるか、事前に定義された選択項目の一覧からの入力であるかを指定します。</span><span class="sxs-lookup"><span data-stu-id="421cc-197">It is used to specify a text input or input from a list of pre-defined selections.</span></span>
-   <span data-ttu-id="421cc-198">モバイルやデスクトップでは、この属性は、テキスト ボックスによる入力を使うか、リスト ボックスによる入力を使うかを指定します。</span><span class="sxs-lookup"><span data-stu-id="421cc-198">On mobile and desktop, this is to specify whether you want a textbox input or a listbox input.</span></span>

<span data-ttu-id="421cc-199">title?</span><span class="sxs-lookup"><span data-stu-id="421cc-199">title?</span></span>

-   <span data-ttu-id="421cc-200">title?</span><span class="sxs-lookup"><span data-stu-id="421cc-200">title?</span></span> <span data-ttu-id="421cc-201"> = 文字列</span><span class="sxs-lookup"><span data-stu-id="421cc-201">= string</span></span>
-   <span data-ttu-id="421cc-202">title 属性は省略可能です。開発者は、シェルの入力に対してタイトルを指定し、アフォーダンスがあるときに表示します。</span><span class="sxs-lookup"><span data-stu-id="421cc-202">The title attribute is optional and is for developers to specify a title for the input for shells to render when there is affordance.</span></span>
-   <span data-ttu-id="421cc-203">モバイルやデスクトップでは、入力の上にこのタイトルが表示されます。</span><span class="sxs-lookup"><span data-stu-id="421cc-203">For mobile and desktop, this title will be displayed above the input.</span></span>

<span data-ttu-id="421cc-204">placeHolderContent?</span><span class="sxs-lookup"><span data-stu-id="421cc-204">placeHolderContent?</span></span>

-   <span data-ttu-id="421cc-205">placeHolderContent?</span><span class="sxs-lookup"><span data-stu-id="421cc-205">placeHolderContent?</span></span> <span data-ttu-id="421cc-206"> = 文字列</span><span class="sxs-lookup"><span data-stu-id="421cc-206">= string</span></span>
-   <span data-ttu-id="421cc-207">placeHolderContent 属性は省略可能です。入力の種類が text の場合に、ヒントのテキストを灰色で表示します。</span><span class="sxs-lookup"><span data-stu-id="421cc-207">The placeHolderContent attribute is optional and is the grey-out hint text for text input type.</span></span> <span data-ttu-id="421cc-208">入力の種類が "text" 以外の場合、この属性は無視されます。</span><span class="sxs-lookup"><span data-stu-id="421cc-208">This attribute is ignored when the input type is not "text".</span></span>

<span data-ttu-id="421cc-209">defaultInput?</span><span class="sxs-lookup"><span data-stu-id="421cc-209">defaultInput?</span></span>

-   <span data-ttu-id="421cc-210">defaultInput?</span><span class="sxs-lookup"><span data-stu-id="421cc-210">defaultInput?</span></span> <span data-ttu-id="421cc-211"> = 文字列</span><span class="sxs-lookup"><span data-stu-id="421cc-211">= string</span></span>
-   <span data-ttu-id="421cc-212">defaultInput 属性は省略可能です。既定の入力値を指定するために使われます。</span><span class="sxs-lookup"><span data-stu-id="421cc-212">The defaultInput attribute is optional and is used to provide a default input value.</span></span>
-   <span data-ttu-id="421cc-213">入力の種類が "text" である場合、この属性は文字列入力として処理されます。</span><span class="sxs-lookup"><span data-stu-id="421cc-213">If the input type is "text", this will be treated as a string input.</span></span>
-   <span data-ttu-id="421cc-214">入力の種類が "selection" である場合、この属性は、入力の要素内で利用できるいずれかの選択項目の ID として処理されます。</span><span class="sxs-lookup"><span data-stu-id="421cc-214">If the input type is "selection", this is expected to be the id of one of the available selections inside this input's elements.</span></span>

**<span data-ttu-id="421cc-215">&lt;selection> 内の属性</span><span class="sxs-lookup"><span data-stu-id="421cc-215">Attributes in &lt;selection</span></span>&gt;**

<span data-ttu-id="421cc-216">id</span><span class="sxs-lookup"><span data-stu-id="421cc-216">id</span></span>

-   <span data-ttu-id="421cc-217">この属性は必須です。</span><span class="sxs-lookup"><span data-stu-id="421cc-217">This attribute is required.</span></span> <span data-ttu-id="421cc-218">ユーザーの選択項目を特定するために使われます。</span><span class="sxs-lookup"><span data-stu-id="421cc-218">It's used to identify user selections.</span></span> <span data-ttu-id="421cc-219">id はアプリに返されます。</span><span class="sxs-lookup"><span data-stu-id="421cc-219">The id is returned to your app.</span></span>

<span data-ttu-id="421cc-220">content</span><span class="sxs-lookup"><span data-stu-id="421cc-220">content</span></span>

-   <span data-ttu-id="421cc-221">この属性は必須です。</span><span class="sxs-lookup"><span data-stu-id="421cc-221">This attribute is required.</span></span> <span data-ttu-id="421cc-222">この selection 要素に対して表示する文字列を指定します。</span><span class="sxs-lookup"><span data-stu-id="421cc-222">It provides the string to display for this selection element.</span></span>

**<span data-ttu-id="421cc-223">&lt;action> 内の属性</span><span class="sxs-lookup"><span data-stu-id="421cc-223">Attributes in &lt;action</span></span>&gt;**

<span data-ttu-id="421cc-224">content</span><span class="sxs-lookup"><span data-stu-id="421cc-224">content</span></span>

-   <span data-ttu-id="421cc-225">content = 文字列</span><span class="sxs-lookup"><span data-stu-id="421cc-225">content = string</span></span>
-   <span data-ttu-id="421cc-226">content 属性は必須です。</span><span class="sxs-lookup"><span data-stu-id="421cc-226">The content attribute is required.</span></span> <span data-ttu-id="421cc-227">ボタンに表示されるテキスト文字列を指定します。</span><span class="sxs-lookup"><span data-stu-id="421cc-227">It provides the text string displayed on the button.</span></span>

<span data-ttu-id="421cc-228">arguments</span><span class="sxs-lookup"><span data-stu-id="421cc-228">arguments</span></span>

-   <span data-ttu-id="421cc-229">arguments = 文字列</span><span class="sxs-lookup"><span data-stu-id="421cc-229">arguments = string</span></span>
-   <span data-ttu-id="421cc-230">arguments 属性は必須です。</span><span class="sxs-lookup"><span data-stu-id="421cc-230">The arguments attribute it required.</span></span> <span data-ttu-id="421cc-231">この属性は、アプリによって定義されたデータを表します。ユーザーがこの action を実行し、アプリがアクティブ化された後で、アプリはこのデータを取得することができます。</span><span class="sxs-lookup"><span data-stu-id="421cc-231">It describes the app-defined data that the app can later retrieve once it is activated from user taking this action.</span></span>

<span data-ttu-id="421cc-232">activationType?</span><span class="sxs-lookup"><span data-stu-id="421cc-232">activationType?</span></span>

-   <span data-ttu-id="421cc-233">activationType?</span><span class="sxs-lookup"><span data-stu-id="421cc-233">activationType?</span></span> <span data-ttu-id="421cc-234"> = "foreground | background | protocol | system"</span><span class="sxs-lookup"><span data-stu-id="421cc-234">= "foreground | background | protocol | system"</span></span>
-   <span data-ttu-id="421cc-235">activationType 属性は省略可能です。既定値は "foreground" です。</span><span class="sxs-lookup"><span data-stu-id="421cc-235">The activationType attribute is optional and its default value is "foreground".</span></span>
-   <span data-ttu-id="421cc-236">この属性は、この action によって行われるアクティブ化の種類を表します (フォアグラウンド、バックグラウンド、プロトコル起動による別のアプリの起動、またはシステム操作の呼び出し)。</span><span class="sxs-lookup"><span data-stu-id="421cc-236">It describes the kind of activation this action will cause: foreground, background, or launching another app via protocol launch, or invoking a system action.</span></span>

<span data-ttu-id="421cc-237">imageUri?</span><span class="sxs-lookup"><span data-stu-id="421cc-237">imageUri?</span></span>

-   <span data-ttu-id="421cc-238">imageUri?</span><span class="sxs-lookup"><span data-stu-id="421cc-238">imageUri?</span></span> <span data-ttu-id="421cc-239"> = 文字列</span><span class="sxs-lookup"><span data-stu-id="421cc-239">= string</span></span>
-   <span data-ttu-id="421cc-240">imageUri は省略可能です。この action 用の画像アイコンを指定するために使われます。このアイコンは、テキスト コンテンツと共にボタン内に表示されます。</span><span class="sxs-lookup"><span data-stu-id="421cc-240">imageUri is optional and is used to provide an image icon for this action to display inside the button alone with the text content.</span></span>

<span data-ttu-id="421cc-241">hint-inputId</span><span class="sxs-lookup"><span data-stu-id="421cc-241">hint-inputId</span></span>

-   <span data-ttu-id="421cc-242">hint-inputId = 文字列</span><span class="sxs-lookup"><span data-stu-id="421cc-242">hint-inputId = string</span></span>
-   <span data-ttu-id="421cc-243">hint-inpudId 属性は必須です。</span><span class="sxs-lookup"><span data-stu-id="421cc-243">The hint-inpudId attribute is required.</span></span> <span data-ttu-id="421cc-244">特に、すばやく応答するシナリオで使われます。</span><span class="sxs-lookup"><span data-stu-id="421cc-244">It's specifically used for the quick reply scenario.</span></span>
-   <span data-ttu-id="421cc-245">値は、この属性に関連付ける必要がある入力要素の ID にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="421cc-245">The value needs to be the id of the input element desired to be associated with.</span></span>
-   <span data-ttu-id="421cc-246">モバイルやデスクトップでは、この属性によって、入力ボックスのすぐ横にボタンが配置されます。</span><span class="sxs-lookup"><span data-stu-id="421cc-246">In mobile and desktop, this will put the button right next to the input box.</span></span>

## <a name="attributes-for-system-handled-actions"></a><span data-ttu-id="421cc-247">システムによって処理される操作の属性</span><span class="sxs-lookup"><span data-stu-id="421cc-247">Attributes for system-handled actions</span></span>


<span data-ttu-id="421cc-248">アプリで再通知や通知の再スケジュールをバックグラウンド タスクとして処理しない場合は、システムで、再通知や通知を閉じるための操作を処理できます。</span><span class="sxs-lookup"><span data-stu-id="421cc-248">The system can handle actions for snoozing and dismissing notifications if you don't want your app to handle the snoozing/rescheduling of notifications as a background task.</span></span> <span data-ttu-id="421cc-249">システムによって処理される操作は、組み合わせることができます (または個別に指定することもできます)。ただし、閉じる操作を使わないで再通知の操作を実装することはお勧めしません。</span><span class="sxs-lookup"><span data-stu-id="421cc-249">System-handled actions can be combined (or individually specified), but we don't recommend implementing a snooze action without a dismiss action.</span></span>

<span data-ttu-id="421cc-250">システム コマンドの組み合わせ: SnoozeAndDismiss</span><span class="sxs-lookup"><span data-stu-id="421cc-250">System commands combo: SnoozeAndDismiss</span></span>

```
<toast>
  <visual>
  </visual>
  <actions hint-systemCommands="SnoozeAndDismiss" />
</toast>
```

<span data-ttu-id="421cc-251">システムによって処理される操作を個別に指定</span><span class="sxs-lookup"><span data-stu-id="421cc-251">Individual system-handled actions</span></span>

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

<span data-ttu-id="421cc-252">再通知や閉じる操作を個別に指定するには、次の手順に従います。</span><span class="sxs-lookup"><span data-stu-id="421cc-252">To construct individual snooze and dismiss actions, do the following:</span></span>

-   <span data-ttu-id="421cc-253">activationType = "system" を指定します。</span><span class="sxs-lookup"><span data-stu-id="421cc-253">Specify activationType = "system"</span></span>
-   <span data-ttu-id="421cc-254">arguments = "snooze" または arguments = "dismiss" を指定します。</span><span class="sxs-lookup"><span data-stu-id="421cc-254">Specify arguments = "snooze" | "dismiss"</span></span>
-   <span data-ttu-id="421cc-255">content を指定します。</span><span class="sxs-lookup"><span data-stu-id="421cc-255">Specify content:</span></span>
    -   <span data-ttu-id="421cc-256">"snooze" や "dismiss" のローカライズされた文字列を操作に対して表示する場合は、content に空の文字列を指定します (&lt;action content = ""/>)。</span><span class="sxs-lookup"><span data-stu-id="421cc-256">If you want localized strings of "snooze" and "dismiss" to be displayed on the actions, specify content to be an empty string: &lt;action content = ""/</span></span>&gt;
    -   <span data-ttu-id="421cc-257">カスタマイズした文字列が必要な場合は、その値を指定します (&lt;action content="Remind me later" />)。</span><span class="sxs-lookup"><span data-stu-id="421cc-257">If you want a customized string, just provide its value: &lt;action content="Remind me later" /</span></span>&gt;
-   <span data-ttu-id="421cc-258">input を指定します。</span><span class="sxs-lookup"><span data-stu-id="421cc-258">Specify input:</span></span>
    -   <span data-ttu-id="421cc-259">再通知の間隔をユーザーが選ぶのではなく、システム定義の時間間隔 (OS 全体で一貫しています) に応じて 1 回だけ再通知を行う場合は、&lt;input&gt; を指定しないでください。</span><span class="sxs-lookup"><span data-stu-id="421cc-259">If you don't want the user to select a snooze interval and instead just want your notification to snooze only once for a system-defined time interval (that is consistent across the OS), then don't construct any &lt;input&gt; at all.</span></span>
    -   <span data-ttu-id="421cc-260">再通知の間隔に関する選択項目を指定する場合:</span><span class="sxs-lookup"><span data-stu-id="421cc-260">If you want to provide snooze interval selections:</span></span>
        -   <span data-ttu-id="421cc-261">再通知の操作内に、hint-inputId を指定します。</span><span class="sxs-lookup"><span data-stu-id="421cc-261">Specify hint-inputId in the snooze action</span></span>
        -   <span data-ttu-id="421cc-262">input の id に、再通知の操作の hint-inputId と同じ値を指定します (&lt;input id="snoozeTime"&gt;&lt;/input&gt;&lt;action hint-inputId="snoozeTime"/>)。</span><span class="sxs-lookup"><span data-stu-id="421cc-262">Match the id of the input with the hint-inputId of the snooze action: &lt;input id="snoozeTime"&gt;&lt;/input&gt;&lt;action hint-inputId="snoozeTime"/</span></span>&gt;
        -   <span data-ttu-id="421cc-263">selection の id に、再通知の間隔を分単位で表す負以外の整数を指定します。&lt;selection id="240" /&gt; は、再通知の間隔が 4 時間であることを示します。</span><span class="sxs-lookup"><span data-stu-id="421cc-263">Specify selection id to be a nonNegativeInteger which represents snooze interval in minutes: &lt;selection id="240" /&gt; means snoozing for 4 hours</span></span>
        -   <span data-ttu-id="421cc-264">&lt;input&gt; の defaultInput の値が、&lt;selection&gt; 子要素の id のいずれかと一致することを確認します。</span><span class="sxs-lookup"><span data-stu-id="421cc-264">Make sure that the value of defaultInput in &lt;input&gt; matches with one of the ids of the &lt;selection&gt; children elements</span></span>
        -   <span data-ttu-id="421cc-265">&lt;selection&gt; の値は、最大で 5 つまで指定できます。</span><span class="sxs-lookup"><span data-stu-id="421cc-265">Provide up to (but no more than) 5 &lt;selection&gt; values</span></span>