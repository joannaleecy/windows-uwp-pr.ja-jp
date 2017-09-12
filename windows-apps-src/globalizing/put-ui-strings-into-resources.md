---
author: DelfCo
Description: "UI の文字列リソースをリソース ファイルに格納します。 その後、これらの文字列をコードやマークアップから参照できます。"
title: "UI 文字列をリソースに格納する"
ms.assetid: E420B9BB-C0F6-4EC0-BA3A-BA2875B69722
label: Put UI strings into resources
template: detail.hbs
ms.author: bobdel
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: a3e224fc51245a5f91c29da2d745a3740029cda9
ms.sourcegitcommit: 11664964e548a2af30d6e176c515cdbf330934ac
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/28/2017
---
# <a name="put-ui-strings-into-resources"></a><span data-ttu-id="e71f5-105">UI 文字列をリソースに格納する</span><span class="sxs-lookup"><span data-stu-id="e71f5-105">Put UI strings into resources</span></span>
<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css">

<span data-ttu-id="e71f5-106">UI の文字列リソースをリソース ファイルに格納します。</span><span class="sxs-lookup"><span data-stu-id="e71f5-106">Put string resources for your UI into resource files.</span></span> <span data-ttu-id="e71f5-107">その後、これらの文字列をコードやマークアップから参照できます。</span><span class="sxs-lookup"><span data-stu-id="e71f5-107">You can then reference those strings from your code or markup.</span></span>

<div class="important-apis" >
<b><span data-ttu-id="e71f5-108">重要な API</span><span class="sxs-lookup"><span data-stu-id="e71f5-108">Important APIs</span></span></b><br/>
<ul>
<li>[**<span data-ttu-id="e71f5-109">ApplicationModel.Resources.ResourceLoader</span><span class="sxs-lookup"><span data-stu-id="e71f5-109">ApplicationModel.Resources.ResourceLoader</span></span>**](https://msdn.microsoft.com/library/windows/apps/br206014)</li>
<li>[**<span data-ttu-id="e71f5-110">WinJS.Resources.processAll</span><span class="sxs-lookup"><span data-stu-id="e71f5-110">WinJS.Resources.processAll</span></span>**](https://msdn.microsoft.com/library/windows/apps/br211864)</li>
</ul>
</div>


<span data-ttu-id="e71f5-111">このトピックでは、いくつかの言語の文字列リソースをユニバーサル Windows アプリに追加する手順と、簡単なテスト方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="e71f5-111">This topic shows the steps to add several language string resources to your Universal Windows app, and how to briefly test it.</span></span>

## <a name="put-strings-into-resource-files-instead-of-putting-them-directly-in-code-or-markup"></a><span data-ttu-id="e71f5-112">文字列を、コードまたはマークアップに直接含める代わりに、リソース ファイルに格納します。</span><span class="sxs-lookup"><span data-stu-id="e71f5-112">Put strings into resource files, instead of putting them directly in code or markup.</span></span>


1.  <span data-ttu-id="e71f5-113">Visual Studio でソリューションを開きます (または新しいソリューションを作成します)。</span><span class="sxs-lookup"><span data-stu-id="e71f5-113">Open your solution (or create a new one) in Visual Studio.</span></span>

2.  <span data-ttu-id="e71f5-114">Visual Studio で package.appxmanifest を開き、**[アプリケーション]** タブに移動して、(この例の場合) 既定の言語を "en-US" に設定します。</span><span class="sxs-lookup"><span data-stu-id="e71f5-114">Open package.appxmanifest in Visual Studio, go to the **Application** tab, and (for this example) set the Default language to "en-US".</span></span> <span data-ttu-id="e71f5-115">ソリューションに複数の package.appxmanifest ファイルがある場合、各ファイルに対してこの手順を実行します。</span><span class="sxs-lookup"><span data-stu-id="e71f5-115">If there are multiple package.appxmanifest files in your solution, do this for each one.</span></span>
    <br><span data-ttu-id="e71f5-116">**注:** これにより、プロジェクトの既定の言語を指定します。</span><span class="sxs-lookup"><span data-stu-id="e71f5-116">**Note**  This specifies the default language for the project.</span></span> <span data-ttu-id="e71f5-117">既定の言語リソースは、ユーザーが優先する言語または表示言語がアプリケーションで提供される言語リソースに一致しない場合に使われます。</span><span class="sxs-lookup"><span data-stu-id="e71f5-117">The default language resources are used if the user's preferred language or display languages do not match the language resources provided in the application.</span></span>
3.  <span data-ttu-id="e71f5-118">リソース ファイルを格納するためのフォルダーを作ります。</span><span class="sxs-lookup"><span data-stu-id="e71f5-118">Create a folder to contain the resource files.</span></span>
    1.  <span data-ttu-id="e71f5-119">ソリューション エクスプローラーで、プロジェクト (ソリューションに複数のプロジェクトが含まれる場合は共有プロジェクト) を右クリックし、**[追加]** &gt; **[新しいフォルダー]** を順に選びます。</span><span class="sxs-lookup"><span data-stu-id="e71f5-119">In the Solution Explorer, right-click the project (the Shared project if your solution contains multiple projects) and select **Add** &gt; **New Folder**.</span></span>
    2.  <span data-ttu-id="e71f5-120">新しいフォルダーに "Strings" という名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="e71f5-120">Name the new folder "Strings".</span></span>
    3.  <span data-ttu-id="e71f5-121">ソリューション エクスプローラーに新しいフォルダーが表示されない場合は、プロジェクトが選ばれている状態で Microsoft Visual Studio のメニューの **[プロジェクト]** &gt; **[すべてのファイルを表示]** を順に選びます。</span><span class="sxs-lookup"><span data-stu-id="e71f5-121">If the new folder is not visible in Solution Explorer, select **Project** &gt; **Show All Files** from the Microsoft Visual Studio menu while the project is still selected.</span></span>

4.  <span data-ttu-id="e71f5-122">英語 (米国) 用のサブフォルダーとリソース ファイルを作ります。</span><span class="sxs-lookup"><span data-stu-id="e71f5-122">Create a sub-folder and a resource file for English (United States).</span></span>
    1.  <span data-ttu-id="e71f5-123">Strings フォルダーを右クリックし、その下に新しいフォルダーを追加します。</span><span class="sxs-lookup"><span data-stu-id="e71f5-123">Right-click the Strings folder and add a new folder beneath it.</span></span> <span data-ttu-id="e71f5-124">新しいフォルダーに "en-US" という名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="e71f5-124">Name it "en-US".</span></span> <span data-ttu-id="e71f5-125">リソース ファイルは、[BCP-47](http://go.microsoft.com/fwlink/p/?linkid=227302) 言語タグの名前を持つフォルダーに格納します。</span><span class="sxs-lookup"><span data-stu-id="e71f5-125">The resource file is to be placed in a folder that has been named for the [BCP-47](http://go.microsoft.com/fwlink/p/?linkid=227302) language tag.</span></span> <span data-ttu-id="e71f5-126">言語修飾子の詳しい情報と共通の言語タグの一覧は、「[修飾子を使ってリソースに名前を付ける方法](https://msdn.microsoft.com/library/windows/apps/xaml/hh965324)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e71f5-126">See [How to name resources using qualifiers](https://msdn.microsoft.com/library/windows/apps/xaml/hh965324) for details on the language qualifier and a list of common language tags.</span></span>
    2.  <span data-ttu-id="e71f5-127">en-US フォルダーを右クリックし、**[追加]** &gt; **[新しい項目]** の順に選びます。</span><span class="sxs-lookup"><span data-stu-id="e71f5-127">Right-click the en-US folder and select **Add** &gt; **New Item…**.</span></span>
    3.  <span data-ttu-id="e71f5-128">[リソース ファイル (.resw)] を選びます。</span><span class="sxs-lookup"><span data-stu-id="e71f5-128">Select "Resources File (.resw)".</span></span>

    4.  <span data-ttu-id="e71f5-129">**[追加]**をクリックします。</span><span class="sxs-lookup"><span data-stu-id="e71f5-129">Click **Add**.</span></span> <span data-ttu-id="e71f5-130">"Resources.resw" という既定の名前の付いたリソース ファイルが追加されます。</span><span class="sxs-lookup"><span data-stu-id="e71f5-130">This adds a resource file with the default name "Resources.resw".</span></span> <span data-ttu-id="e71f5-131">この既定のファイル名を使うことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="e71f5-131">We recommend that you use this default filename.</span></span> <span data-ttu-id="e71f5-132">アプリはリソースを他のファイルに分割できますが、そのファイルを正しく参照するように注意する必要があります (「[文字列リソースを読み込む方法](https://msdn.microsoft.com/library/windows/apps/xaml/hh965323)」をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="e71f5-132">Apps can partition their resources into other files, but you must be careful to refer to them correctly (see [How to load string resources](https://msdn.microsoft.com/library/windows/apps/xaml/hh965323)).</span></span>
    5.  <span data-ttu-id="e71f5-133">以前の .NET プロジェクトの文字列リソースだけを含む .resx ファイルがある場合は、**[追加]**、**[既存の項目]** の順に選び、.resx ファイルを追加し、.resw に名前を変更します。</span><span class="sxs-lookup"><span data-stu-id="e71f5-133">If you have .resx files with only string resources from previous .NET projects, select **Add** &gt; **Existing Item…**, add the .resx file, and rename it to .resw.</span></span>
    6.  <span data-ttu-id="e71f5-134">ファイルを開き、エディターを使ってこれらのリソースを追加します。</span><span class="sxs-lookup"><span data-stu-id="e71f5-134">Open the file and use the editor to add these resources:</span></span>


        <span data-ttu-id="e71f5-135">Strings/en-US/Resources.resw ![リソースの追加 (英語)](images/addresource-en-us.png) この例では、"Greeting.Text" と "Farewell" が、表示される文字列を特定しています。</span><span class="sxs-lookup"><span data-stu-id="e71f5-135">Strings/en-US/Resources.resw ![add resource, english](images/addresource-en-us.png) In this example, "Greeting.Text" and "Farewell" identify the strings that are to be displayed.</span></span> <span data-ttu-id="e71f5-136">"Greeting.Width" は "Greeting" 文字列の Width プロパティを特定しています。</span><span class="sxs-lookup"><span data-stu-id="e71f5-136">"Greeting.Width" identifies the Width property of the "Greeting" string.</span></span> <span data-ttu-id="e71f5-137">コメントは、文字列を他の言語にローカライズする翻訳者に特別な指示を伝えるのに便利です。</span><span class="sxs-lookup"><span data-stu-id="e71f5-137">The comments are a good place to provide any special instructions to translators who localize the strings to other languages.</span></span>

## <a name="associate-controls-to-resources"></a><span data-ttu-id="e71f5-138">リソースにコントロールを関連付けます。</span><span class="sxs-lookup"><span data-stu-id="e71f5-138">Associate controls to resources.</span></span>

<span data-ttu-id="e71f5-139">ローカライズされたテキストを必要とするすべてのコントロールを .resw ファイルに関連付ける必要があります。</span><span class="sxs-lookup"><span data-stu-id="e71f5-139">You need to associate every control that needs localized text with the .resw file.</span></span> <span data-ttu-id="e71f5-140">これを行うには、次に示すように XAML 要素の **x:Uid** 属性を使います。</span><span class="sxs-lookup"><span data-stu-id="e71f5-140">You do this using the **x:Uid** attribute on your XAML elements like this:</span></span>

```XML
<TextBlock x:Uid="Greeting" Text="" />
```

<span data-ttu-id="e71f5-141">リソース名には、**Uid** 属性値に加え、翻訳された言語を取得するプロパティ (この場合は Text プロパティ) を指定します。</span><span class="sxs-lookup"><span data-stu-id="e71f5-141">For the resource name, you give the **Uid** attribute value, plus you specify what property is to get the translated string (in this case the Text property).</span></span> <span data-ttu-id="e71f5-142">Greeting.Width など、異なる言語の他のプロパティ/値を指定できますが、このようなレイアウト関連のプロパティを指定する際には注意が必要です。</span><span class="sxs-lookup"><span data-stu-id="e71f5-142">You can specify other properties/values for different languages such as Greeting.Width, but be careful with such layout-related properties.</span></span> <span data-ttu-id="e71f5-143">デバイスの画面に基づいてコントロールを動的にレイアウトする必要があります。</span><span class="sxs-lookup"><span data-stu-id="e71f5-143">You should strive to allow the controls to lay out dynamically based on the device's screen.</span></span>

<span data-ttu-id="e71f5-144">AutomationProperties.Name などのアタッチされたプロパティは、resw ファイルでは異なる方法で処理されます。</span><span class="sxs-lookup"><span data-stu-id="e71f5-144">Note that attached properties are handled differently in resw files such as AutomationProperties.Name.</span></span> <span data-ttu-id="e71f5-145">次のように名前空間を明示的に書き出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="e71f5-145">You need to explicitly write out the namespace like this:</span></span>

```XML
MediumButton.[using:Windows.UI.Xaml.Automation]AutomationProperties.Name
```

## <a name="add-string-resource-identifiers-to-code-and-markup"></a><span data-ttu-id="e71f5-146">コードとマークアップに文字列リソース識別子を追加します。</span><span class="sxs-lookup"><span data-stu-id="e71f5-146">Add string resource identifiers to code and markup.</span></span>

<span data-ttu-id="e71f5-147">コードでは、文字列を動的に参照できます。</span><span class="sxs-lookup"><span data-stu-id="e71f5-147">In your code, you can dynamically reference strings:</span></span>

**<span data-ttu-id="e71f5-148">C#</span><span class="sxs-lookup"><span data-stu-id="e71f5-148">C#</span></span>**
```CSharp
var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
var str = loader.GetString("Farewell");
```

**<span data-ttu-id="e71f5-149">C++</span><span class="sxs-lookup"><span data-stu-id="e71f5-149">C++</span></span>**
```cpp
auto loader = ref new Windows::ApplicationModel::Resources::ResourceLoader();
auto str = loader->GetString("Farewell");
```


## <a name="add-folders-and-resource-files-for-two-additional-languages"></a><span data-ttu-id="e71f5-150">他の 2 つの言語用にフォルダーとリソース ファイルを追加します。</span><span class="sxs-lookup"><span data-stu-id="e71f5-150">Add folders and resource files for two additional languages.</span></span>


1.  <span data-ttu-id="e71f5-151">Strings フォルダーの下にドイツ語用の別のフォルダーを追加します。</span><span class="sxs-lookup"><span data-stu-id="e71f5-151">Add another folder under the Strings folder for German.</span></span> <span data-ttu-id="e71f5-152">フォルダーに Deutsch (Deutschland) を表す "de-DE" という名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="e71f5-152">Name the folder "de-DE" for Deutsch (Deutschland).</span></span>
2.  <span data-ttu-id="e71f5-153">[de-DE] フォルダー内に別のリソース ファイルを作り、次のように追加します。</span><span class="sxs-lookup"><span data-stu-id="e71f5-153">Create another resources file in the de-DE folder, and add the following:</span></span>

    <span data-ttu-id="e71f5-154">strings/de-DE/Resources.resw</span><span class="sxs-lookup"><span data-stu-id="e71f5-154">strings/de-DE/Resources.resw</span></span>

    ![リソースを追加する (ドイツ語)](images/addresource-de-de.png)


3.  <span data-ttu-id="e71f5-156">フォルダーをもう 1 つ作り、français (France) を表す "fr-FR" という名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="e71f5-156">Create one more folder named "fr-FR", for français (France).</span></span> <span data-ttu-id="e71f5-157">新規のリソース ファイルを作り、次のように追加します。</span><span class="sxs-lookup"><span data-stu-id="e71f5-157">Create a new resources file and add the following:</span></span>

    <span data-ttu-id="e71f5-158">strings/fr-FR/Resources.resw</span><span class="sxs-lookup"><span data-stu-id="e71f5-158">strings/fr-FR/Resources.resw</span></span>
    
    ![リソースを追加する (フランス語)](images/addresource-fr-fr.png)

## <a name="build-and-run-the-app"></a><span data-ttu-id="e71f5-160">アプリをビルドして実行します。</span><span class="sxs-lookup"><span data-stu-id="e71f5-160">Build and run the app.</span></span>


<span data-ttu-id="e71f5-161">既定の表示言語に対してアプリをテストします。</span><span class="sxs-lookup"><span data-stu-id="e71f5-161">Test the app for your default display language.</span></span>

1.  <span data-ttu-id="e71f5-162">F5 キーを押して、アプリをビルドし、実行します。</span><span class="sxs-lookup"><span data-stu-id="e71f5-162">Press F5 to build and run the app.</span></span>
2.  <span data-ttu-id="e71f5-163">"greeting" と "farewell" が、ユーザーの優先する言語で表示されることを確かめます。</span><span class="sxs-lookup"><span data-stu-id="e71f5-163">Note that the greeting and farewell are displayed in the user's preferred language.</span></span>
3.  <span data-ttu-id="e71f5-164">アプリを終了します。</span><span class="sxs-lookup"><span data-stu-id="e71f5-164">Exit the app.</span></span>

<span data-ttu-id="e71f5-165">他の言語に対してアプリをテストします。</span><span class="sxs-lookup"><span data-stu-id="e71f5-165">Test the app for the other languages.</span></span>

1.  <span data-ttu-id="e71f5-166">デバイスで **[設定]** を表示します。</span><span class="sxs-lookup"><span data-stu-id="e71f5-166">Bring up **Settings** on your device.</span></span>
2.  <span data-ttu-id="e71f5-167">**[時刻と言語]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="e71f5-167">Select **Time & language**.</span></span>
3.  <span data-ttu-id="e71f5-168">**[地域と言語]** (電話または電話エミュレーターでは **[言語]**) を選択します。</span><span class="sxs-lookup"><span data-stu-id="e71f5-168">Select **Region & language** (or on a phone or phone emulator, **Language**).</span></span>
4.  <span data-ttu-id="e71f5-169">前回アプリを実行したときに表示された言語は、一覧の中で最上位にリストされている言語 (英語、ドイツ語、またはフランス語) です。</span><span class="sxs-lookup"><span data-stu-id="e71f5-169">Note that the language that was displayed when you ran the app is the top language listed that is English, German, or French.</span></span> <span data-ttu-id="e71f5-170">最上位にリストされている言語がこれらのいずれでもない場合、アプリでサポートされているリスト内の次の言語にフォールバックされます。</span><span class="sxs-lookup"><span data-stu-id="e71f5-170">If your top language is not one of these three, the app falls back to the next one on the list that the app supports.</span></span>
5.  <span data-ttu-id="e71f5-171">これらの 3 つの言語のいずれかがコンピューターにインストールされていない場合は、**[言語の追加]** をクリックして、言語を一覧に追加します。</span><span class="sxs-lookup"><span data-stu-id="e71f5-171">If you do not have all three of these languages on your machine, add the missing ones by clicking **Add a language** and adding them to the list.</span></span>
6.  <span data-ttu-id="e71f5-172">別の言語でアプリをテストするには、一覧で言語を選択し、**[既定に設定]** をクリックします (電話または電話エミュレーターでは、一覧で言語を長押しして、最上位に来るまで **[上へ移動]** をタップします)。</span><span class="sxs-lookup"><span data-stu-id="e71f5-172">To test the app with another language, select the language in the list and click **Set as default** (or on a phone or phone emulator, tap and hold the language in the list and then tap **Move up** until it is at the top).</span></span> <span data-ttu-id="e71f5-173">その後、アプリを実行します。</span><span class="sxs-lookup"><span data-stu-id="e71f5-173">Then run the app.</span></span>

## <a name="related-topics"></a><span data-ttu-id="e71f5-174">関連トピック</span><span class="sxs-lookup"><span data-stu-id="e71f5-174">Related topics</span></span>


* [<span data-ttu-id="e71f5-175">修飾子を使ってリソースに名前を付ける方法</span><span class="sxs-lookup"><span data-stu-id="e71f5-175">How to name resources using qualifiers</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/hh965324)
* [<span data-ttu-id="e71f5-176">文字列リソースを読み込む方法</span><span class="sxs-lookup"><span data-stu-id="e71f5-176">How to load string resources</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/hh965323)
* [<span data-ttu-id="e71f5-177">BCP-47 言語タグに関するページ</span><span class="sxs-lookup"><span data-stu-id="e71f5-177">The BCP-47 language tag</span></span>](http://go.microsoft.com/fwlink/p/?linkid=227302)
 

 



