---
description: どのような種類の入力でも、最善のエクスペリエンスが得られるように、そのような操作をコンテキスト コマンドを使って実装する方法。
title: コンテキスト コマンドの実行
ms.assetid: ''
label: Contextual commanding in collections
template: detail.hbs
ms.date: 10/25/2017
ms.topic: article
keywords: windows 10, uwp
pm-contact: chigy
design-contact: kimsea
dev-contact: niallm
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: 1d520f811c9929721bfcb9d1c83fbff6a4891091
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57658597"
---
# <a name="contextual-commanding-for-collections-and-lists"></a><span data-ttu-id="37f03-104">コレクションとリストのコンテキスト コマンドの実行</span><span class="sxs-lookup"><span data-stu-id="37f03-104">Contextual commanding for collections and lists</span></span>



<span data-ttu-id="37f03-105">多くのアプリに、リスト、グリッド、ツリーの形で、ユーザーが操作できるコンテンツのコレクションが含まれています。</span><span class="sxs-lookup"><span data-stu-id="37f03-105">Many apps contain collections of content in the form of lists, grids, and trees that users can manipulate.</span></span> <span data-ttu-id="37f03-106">たとえば、ユーザーは、項目の削除、名前の変更、フラグ付け、更新ができる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="37f03-106">For example, users might be able to delete, rename, flag, or refresh items.</span></span> <span data-ttu-id="37f03-107">この記事では、どのような種類の入力でも、最善のエクスペリエンスが得られるように、そのような操作をコンテキスト コマンドを使って実装する方法を説明します。</span><span class="sxs-lookup"><span data-stu-id="37f03-107">This article shows you how to use contextual commands to implement these sorts of actions in a way that provides the best possible experience for all input types.</span></span>  

> <span data-ttu-id="37f03-108">**重要な Api**:[ICommand インターフェイス](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Input.ICommand)、 [UIElement.ContextFlyout プロパティ](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.UIElement.ContextFlyout)、 [INotifyPropertyChanged インターフェイス](https://docs.microsoft.com/uwp/api/windows.ui.xaml.data.inotifypropertychanged)</span><span class="sxs-lookup"><span data-stu-id="37f03-108">**Important APIs**: [ICommand interface](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Input.ICommand), [UIElement.ContextFlyout property](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.UIElement.ContextFlyout), [INotifyPropertyChanged interface](https://docs.microsoft.com/uwp/api/windows.ui.xaml.data.inotifypropertychanged)</span></span>

![各種入力方法で、お気に入りのコマンドを実行する](images/ContextualCommand_AddFavorites.png)

## <a name="creating-commands-for-all-input-types"></a><span data-ttu-id="37f03-110">あらゆる種類の入力に対応するコマンドを作成する</span><span class="sxs-lookup"><span data-stu-id="37f03-110">Creating commands for all input types</span></span>

<span data-ttu-id="37f03-111">ユーザーは[さまざまなデバイスや入力方法](../devices/index.md)を使って UWP アプリを操作できるため、アプリでは入力方法に依存しないコンテキスト メニューと、各種入力方法専用のアクセラレータの両方でコマンドを公開する必要があります。</span><span class="sxs-lookup"><span data-stu-id="37f03-111">Because users can interact with a UWP app using [a broad range of devices and inputs](../devices/index.md), your app should expose commands though both input-agnostic context menus and input-specific accelerators.</span></span> <span data-ttu-id="37f03-112">両方を含めることで、入力方法やデバイスの種類に関わらず、コンテンツに対してコマンドをすばやく呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="37f03-112">Including both lets the user quickly invoke commands on content, regardless of input or device type.</span></span>

<span data-ttu-id="37f03-113">次の表に、いくつかの典型的なコレクションのコマンドと、これらのコマンドを公開する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="37f03-113">This table shows some typical collection commands and ways to expose those commands.</span></span> 

| <span data-ttu-id="37f03-114">コマンド</span><span class="sxs-lookup"><span data-stu-id="37f03-114">Command</span></span>          | <span data-ttu-id="37f03-115">入力方法を問わない</span><span class="sxs-lookup"><span data-stu-id="37f03-115">Input-agnostic</span></span> | <span data-ttu-id="37f03-116">マウス アクセラレータ</span><span class="sxs-lookup"><span data-stu-id="37f03-116">Mouse accelerator</span></span> | <span data-ttu-id="37f03-117">キーボード アクセラレータ</span><span class="sxs-lookup"><span data-stu-id="37f03-117">Keyboard accelerator</span></span> | <span data-ttu-id="37f03-118">タッチ アクセラレータ</span><span class="sxs-lookup"><span data-stu-id="37f03-118">Touch accelerator</span></span> |
| ---------------- | -------------- | ----------------- | -------------------- | ----------------- |
| <span data-ttu-id="37f03-119">項目の削除</span><span class="sxs-lookup"><span data-stu-id="37f03-119">Delete item</span></span>      | <span data-ttu-id="37f03-120">ショートカット メニュー</span><span class="sxs-lookup"><span data-stu-id="37f03-120">Context menu</span></span>   | <span data-ttu-id="37f03-121">ホバー ボタン</span><span class="sxs-lookup"><span data-stu-id="37f03-121">Hover button</span></span>      | <span data-ttu-id="37f03-122">DEL キー</span><span class="sxs-lookup"><span data-stu-id="37f03-122">DEL key</span></span>              | <span data-ttu-id="37f03-123">スワイプして削除</span><span class="sxs-lookup"><span data-stu-id="37f03-123">Swipe to delete</span></span>   |
| <span data-ttu-id="37f03-124">フラグの設定</span><span class="sxs-lookup"><span data-stu-id="37f03-124">Flag item</span></span>        | <span data-ttu-id="37f03-125">ショートカット メニュー</span><span class="sxs-lookup"><span data-stu-id="37f03-125">Context menu</span></span>   | <span data-ttu-id="37f03-126">ホバー ボタン</span><span class="sxs-lookup"><span data-stu-id="37f03-126">Hover button</span></span>      | <span data-ttu-id="37f03-127">Ctrl + Shift + G</span><span class="sxs-lookup"><span data-stu-id="37f03-127">Ctrl+Shift+G</span></span>         | <span data-ttu-id="37f03-128">スワイプしてフラグを設定</span><span class="sxs-lookup"><span data-stu-id="37f03-128">Swipe to flag</span></span>     |
| <span data-ttu-id="37f03-129">データの更新</span><span class="sxs-lookup"><span data-stu-id="37f03-129">Refresh data</span></span>     | <span data-ttu-id="37f03-130">ショートカット メニュー</span><span class="sxs-lookup"><span data-stu-id="37f03-130">Context menu</span></span>   | <span data-ttu-id="37f03-131">なし</span><span class="sxs-lookup"><span data-stu-id="37f03-131">N/A</span></span>               | <span data-ttu-id="37f03-132">F5 キー</span><span class="sxs-lookup"><span data-stu-id="37f03-132">F5 key</span></span>               | <span data-ttu-id="37f03-133">引っ張って更新</span><span class="sxs-lookup"><span data-stu-id="37f03-133">Pull to refresh</span></span>   |
| <span data-ttu-id="37f03-134">お気に入りに追加</span><span class="sxs-lookup"><span data-stu-id="37f03-134">Favorite an item</span></span> | <span data-ttu-id="37f03-135">ショートカット メニュー</span><span class="sxs-lookup"><span data-stu-id="37f03-135">Context menu</span></span>   | <span data-ttu-id="37f03-136">ホバー ボタン</span><span class="sxs-lookup"><span data-stu-id="37f03-136">Hover button</span></span>      | <span data-ttu-id="37f03-137">F、Ctrl + S</span><span class="sxs-lookup"><span data-stu-id="37f03-137">F, Ctrl+S</span></span>            | <span data-ttu-id="37f03-138">スワイプしてお気に入りに追加</span><span class="sxs-lookup"><span data-stu-id="37f03-138">Swipe to favorite</span></span> |


* <span data-ttu-id="37f03-139">**一般に、する必要があります項目のすべてのコマンドで使用できるように、項目の[コンテキスト メニュー](menus.md)します。**</span><span class="sxs-lookup"><span data-stu-id="37f03-139">**In general, you should make all commands for an item available in the item's [context menu](menus.md).**</span></span> <span data-ttu-id="37f03-140">コンテキスト メニューには、入力の種類にかかわらず、ユーザーがアクセスでき、ユーザーが実行できるコンテキスト コマンドの全部を含めてください。</span><span class="sxs-lookup"><span data-stu-id="37f03-140">Context menus are accessible to users regardless of input type, and should contain all of the contextual commands that user can perform.</span></span>

* <span data-ttu-id="37f03-141">**頻繁にアクセスされるコマンドは、入力のアクセラレータの使用を検討してください。**</span><span class="sxs-lookup"><span data-stu-id="37f03-141">**For frequently accessed commands, consider using input accelerators.**</span></span> <span data-ttu-id="37f03-142">入力アクセラレータを使うと、ユーザーの入力デバイスに応じて、すばやく操作を実行できます。</span><span class="sxs-lookup"><span data-stu-id="37f03-142">Input accelerators let the user perform actions quickly, based on their input device.</span></span> <span data-ttu-id="37f03-143">次のような入力アクセラレータがあります。</span><span class="sxs-lookup"><span data-stu-id="37f03-143">Input accelerators include:</span></span>
    - <span data-ttu-id="37f03-144">スワイプして操作 (タッチ アクセラレータ)</span><span class="sxs-lookup"><span data-stu-id="37f03-144">Swipe-to-action (touch accelerator)</span></span>
    - <span data-ttu-id="37f03-145">引っ張ってデータを更新 (タッチ アクセラレータ)</span><span class="sxs-lookup"><span data-stu-id="37f03-145">Pull to refresh data (touch accelerator)</span></span>
    - <span data-ttu-id="37f03-146">キーボード ショートカット (キーボード アクセラレータ)</span><span class="sxs-lookup"><span data-stu-id="37f03-146">Keyboard shortcuts (keyboard accelerator)</span></span>
    - <span data-ttu-id="37f03-147">アクセス キー (キーボード アクセラレータ)</span><span class="sxs-lookup"><span data-stu-id="37f03-147">Access keys (keyboard accelerator)</span></span>
    - <span data-ttu-id="37f03-148">マウスとペンのホバー ボタン (ポインター アクセラレータ)</span><span class="sxs-lookup"><span data-stu-id="37f03-148">Mouse & Pen hover buttons (pointer accelerator)</span></span>

> [!NOTE]
> <span data-ttu-id="37f03-149">ユーザーは、どの種類のデバイスからでも、すべてのコマンドにアクセスできる必要があります。</span><span class="sxs-lookup"><span data-stu-id="37f03-149">Users should be able to access all commands from any type of device.</span></span> <span data-ttu-id="37f03-150">たとえば、アプリのコマンドがホバー ボタン ポインター アクセラレータでしか公開されない場合、タッチ ユーザーはコマンドにアクセスできません。</span><span class="sxs-lookup"><span data-stu-id="37f03-150">For example, if your app’s commands are only exposed through hover button pointer accelerators, touch users won't be able to access them.</span></span> <span data-ttu-id="37f03-151">少なくとも、すべてのコマンドにアクセスできるコンテキスト メニューを使います。</span><span class="sxs-lookup"><span data-stu-id="37f03-151">At a minimum, use a context menu to provide access to all commands.</span></span>  

## <a name="example-the-podcastobject-data-model"></a><span data-ttu-id="37f03-152">以下に例を示します。PodcastObject データ モデル</span><span class="sxs-lookup"><span data-stu-id="37f03-152">Example: The PodcastObject data model</span></span>

<span data-ttu-id="37f03-153">推奨されるコマンド実行のデモとして、この記事では、ポッドキャスト アプリ用のポッドキャスト リストを作成します。</span><span class="sxs-lookup"><span data-stu-id="37f03-153">To demonstrate our commanding recommendations, this article creates a list of podcasts for a podcast app.</span></span> <span data-ttu-id="37f03-154">コード例では、ユーザーがリストから特定のポッドキャストを "お気に入り" に追加できるようにする方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="37f03-154">The example code demonstrate how to enable the user to "favorite" a particular podcast from a list.</span></span>

<span data-ttu-id="37f03-155">以下に、この記事で作業するポッドキャスト オブジェクトの定義を示します。</span><span class="sxs-lookup"><span data-stu-id="37f03-155">Here's the definition for the podcast object we'll be working with:</span></span> 

```csharp
public class PodcastObject : INotifyPropertyChanged
{
    // The title of the podcast
    public String Title { get; set; }

    // The podcast's description
    public String Description { get; set; }

    // Describes if the user has set this podcast as a favorite
    public bool IsFavorite
    {
        get
        {
            return _isFavorite;
        }
        set
        {
            _isFavorite = value;
            OnPropertyChanged("IsFavorite");
        }
    }
    private bool _isFavorite = false;

    public event PropertyChangedEventHandler PropertyChanged;

    private void OnPropertyChanged(String property)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
    }
}
```

<span data-ttu-id="37f03-156">PodcastObject は [INotifyPropertyChanged](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Data.INotifyPropertyChanged) を実装して、ユーザーが IsFavorite プロパティの設定を切り替えたときに、プロパティの変更に応答するようにしています。</span><span class="sxs-lookup"><span data-stu-id="37f03-156">Notice that the PodcastObject implements [INotifyPropertyChanged](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Data.INotifyPropertyChanged) to respond to property changes when the user toggles the IsFavorite property.</span></span>

## <a name="defining-commands-with-the-icommand-interface"></a><span data-ttu-id="37f03-157">ICommand インターフェイスを使ったコマンドの定義</span><span class="sxs-lookup"><span data-stu-id="37f03-157">Defining commands with the ICommand interface</span></span>

<span data-ttu-id="37f03-158">[ICommand インターフェイス](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Input.ICommand) を使うと、複数の入力の種類に利用できるコマンドを定義できます。</span><span class="sxs-lookup"><span data-stu-id="37f03-158">The [ICommand interface](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Input.ICommand) helps you to define a command that's  available for multiple input types.</span></span> <span data-ttu-id="37f03-159">たとえば、Delete キーが押されたときと、コンテキスト メニューで [削除] が右クリックされたときの 2 種類のイベント ハンドラーで同じ削除コマンドのコードを記述するのではなく、[ICommand](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Input.ICommand) として削除ロジックを 1 度実装したら、各種入力方法でこの削除ロジックを利用可能にできます。</span><span class="sxs-lookup"><span data-stu-id="37f03-159">For example, instead of writing the same code for a delete command in two different event handlers, one for when the user presses the Delete key and one for when the user right clicks "Delete" in a context menu, you can implement your delete logic once, as an [ICommand](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Input.ICommand),  and then make it available to different input types.</span></span>

<span data-ttu-id="37f03-160">"お気に入り" の操作を表す ICommand を定義する必要があります。</span><span class="sxs-lookup"><span data-stu-id="37f03-160">We need to define the ICommand that represents the "Favorite" action.</span></span> <span data-ttu-id="37f03-161">ポッドキャストをお気に入りに追加するには、コマンドの [Execute](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Input.ICommand.Execute) メソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="37f03-161">We will use the command's [Execute](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Input.ICommand.Execute) method to favorite a podcast.</span></span> <span data-ttu-id="37f03-162">特定のポッドキャストがコマンドのパラメーターを介して実行メソッドに渡されます。これは、CommandParameter プロパティを使ってバインドできます。</span><span class="sxs-lookup"><span data-stu-id="37f03-162">The particular podcast will be provided to the execute method via the command's parameter, which can be bound using the CommandParameter property.</span></span>

```csharp
public class FavoriteCommand: ICommand
{
    public event EventHandler CanExecuteChanged;

    public bool CanExecute(object parameter)
    {
        return true;
    }
    public void Execute(object parameter)
    {
        // Perform the logic to "favorite" an item.
        (parameter as PodcastObject).IsFavorite = true;
    }
}
```

<span data-ttu-id="37f03-163">複数のコレクションや要素で同じコマンドを使うには、コマンドをページやアプリのリソースとして保存します。</span><span class="sxs-lookup"><span data-stu-id="37f03-163">To use the same command with multiple collections and elements, you can store the command as a resource on the page or on the app.</span></span>

```xaml
<Application.Resources>
    <local:FavoriteCommand x:Key="favoriteCommand" />
</Application.Resources>
```

<span data-ttu-id="37f03-164">コマンドを実行するには、コマンドの [Execute](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Input.ICommand.Execute) メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="37f03-164">To execute the command, you call its [Execute](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Input.ICommand.Execute) method.</span></span>

```csharp
// Favorite the item using the defined command
var favoriteCommand = Application.Current.Resources["favoriteCommand"] as ICommand;
favoriteCommand.Execute(PodcastObject);
```


## <a name="creating-a-usercontrol-to-respond-to-a-variety-of-inputs"></a><span data-ttu-id="37f03-165">さまざまな入力に応答する UserControl の作成</span><span class="sxs-lookup"><span data-stu-id="37f03-165">Creating a UserControl to respond to a variety of inputs</span></span>

<span data-ttu-id="37f03-166">項目のリストがあり、各項目が複数の入力方法に応答する場合、項目の [UserControl](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.UserControl) を定義し、これを使って項目のコンテキスト メニューとイベント ハンドラーを定義することで、コードを簡潔にできます。</span><span class="sxs-lookup"><span data-stu-id="37f03-166">When you have a list of items and each of those items should respond to multiple inputs, you can simplify your code by defining a [UserControl](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.UserControl) for the item and using it to define your items' context menu and event handlers.</span></span> 

<span data-ttu-id="37f03-167">Visual Studio で UserControl を作る手順は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="37f03-167">To create a UserControl in Visual Studio:</span></span>
1. <span data-ttu-id="37f03-168">ソリューション エクスプローラーで、プロジェクトを右クリックします。</span><span class="sxs-lookup"><span data-stu-id="37f03-168">In the Solution Explorer, right click the project.</span></span> <span data-ttu-id="37f03-169">コンテキスト メニューが表示されます。</span><span class="sxs-lookup"><span data-stu-id="37f03-169">A context menu appears.</span></span>
2. <span data-ttu-id="37f03-170">**[追加]、[新しい項目]** の順に選びます。</span><span class="sxs-lookup"><span data-stu-id="37f03-170">Select **Add > New Item...**</span></span> <br /><span data-ttu-id="37f03-171">**[新しい項目の追加]** ダイアログが表示されます。</span><span class="sxs-lookup"><span data-stu-id="37f03-171">The **Add New Item** dialog appears.</span></span> 
3. <span data-ttu-id="37f03-172">項目の一覧から [UserControl] を選択します。</span><span class="sxs-lookup"><span data-stu-id="37f03-172">Select UserControl from the list of items.</span></span> <span data-ttu-id="37f03-173">任意の名前を付けて、**[追加]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="37f03-173">Give it the name you want and click **Add**.</span></span> <span data-ttu-id="37f03-174">Visual Studio によって UserControl のスタブが生成されます。</span><span class="sxs-lookup"><span data-stu-id="37f03-174">Visual Studio will generate a stub UserControl for you.</span></span> 

<span data-ttu-id="37f03-175">この記事のポッドキャストの例では、各ポッドキャストはリストにまとめられて表示され、さまざまな方法でポッドキャストを ”お気に入り” に追加できるようになります。</span><span class="sxs-lookup"><span data-stu-id="37f03-175">In our podcast example, each podcast will be displayed in a list, which will expose a variety of ways to "Favorite" a podcast.</span></span> <span data-ttu-id="37f03-176">ユーザーは次の操作によって、ポッドキャストを ”お気に入り” にすることができます。</span><span class="sxs-lookup"><span data-stu-id="37f03-176">The user will be able to perform the following actions to "Favorite" the podcast:</span></span>
- <span data-ttu-id="37f03-177">コンテキスト メニューの呼び出し</span><span class="sxs-lookup"><span data-stu-id="37f03-177">Invoke a context menu</span></span>
- <span data-ttu-id="37f03-178">キーボード ショートカットの実行</span><span class="sxs-lookup"><span data-stu-id="37f03-178">Perform keyboard shortcuts</span></span>
- <span data-ttu-id="37f03-179">ホバー ボタンの表示</span><span class="sxs-lookup"><span data-stu-id="37f03-179">Show a hover button</span></span>
- <span data-ttu-id="37f03-180">スワイプ ジェスチャの実行</span><span class="sxs-lookup"><span data-stu-id="37f03-180">Perform a swipe gesture</span></span>

<span data-ttu-id="37f03-181">これらの動作をカプセル化して、FavoriteCommand を使えるように、リスト内のポッドキャストを表す "PodcastUserControl" という名前の新しい [UserControl](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.UserControl) を作りましょう。</span><span class="sxs-lookup"><span data-stu-id="37f03-181">In order to encapsulate these behaviors and use the FavoriteCommand, let's create a new [UserControl](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.UserControl) named "PodcastUserControl" to represent a podcast in the list.</span></span>

<span data-ttu-id="37f03-182">PodcastUserControl は PodcastObject のフィールドを TextBlocks として表示し、さまざまなユーザーの操作に応答します。</span><span class="sxs-lookup"><span data-stu-id="37f03-182">The PodcastUserControl displays the fields of the PodcastObject as TextBlocks, and responds to various user interactions.</span></span> <span data-ttu-id="37f03-183">この記事では、この PodcastUserControl を参照し、拡張していきます。</span><span class="sxs-lookup"><span data-stu-id="37f03-183">We will reference and expand upon the PodcastUserControl throughout this article.</span></span>

<span data-ttu-id="37f03-184">**PodcastUserControl.xaml**</span><span class="sxs-lookup"><span data-stu-id="37f03-184">**PodcastUserControl.xaml**</span></span>
```xaml
<UserControl
    x:Class="ContextCommanding.PodcastUserControl"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
    mc:Ignorable="d"
    IsTabStop="True" UseSystemFocusVisuals="True"
    >
    <Grid Margin="12,0,12,0">
        <StackPanel>
            <TextBlock Text="{x:Bind PodcastObject.Title, Mode=OneWay}" Style="{StaticResource TitleTextBlockStyle}" />
            <TextBlock Text="{x:Bind PodcastObject.Description, Mode=OneWay}" Style="{StaticResource SubtitleTextBlockStyle}" />
            <TextBlock Text="{x:Bind PodcastObject.IsFavorite, Mode=OneWay}" Style="{StaticResource SubtitleTextBlockStyle}"/>
        </StackPanel>
    </Grid>
</UserControl>
```

<span data-ttu-id="37f03-185">**PodcastUserControl.xaml.cs**</span><span class="sxs-lookup"><span data-stu-id="37f03-185">**PodcastUserControl.xaml.cs**</span></span>
```csharp
public sealed partial class PodcastUserControl : UserControl
{
    public static readonly DependencyProperty PodcastObjectProperty =
        DependencyProperty.Register(
            "PodcastObject",
            typeof(PodcastObject),
            typeof(PodcastUserControl),
            new PropertyMetadata(null));

    public PodcastObject PodcastObject
    {
        get { return (PodcastObject)GetValue(PodcastObjectProperty); }
        set { SetValue(PodcastObjectProperty, value); }
    }

    public PodcastUserControl()
    {
        this.InitializeComponent();

        // TODO: We will add event handlers here.
    }
}
```

<span data-ttu-id="37f03-186">この PodcastUserControl では、PodcastObject への参照を DependencyProperty として維持しています。</span><span class="sxs-lookup"><span data-stu-id="37f03-186">Notice that the PodcastUserControl maintains a reference to the PodcastObject as a DependencyProperty.</span></span> <span data-ttu-id="37f03-187">これで、PodcastObjects を PodcastUserControl にバインドできるようになります。</span><span class="sxs-lookup"><span data-stu-id="37f03-187">This enables us to bind PodcastObjects to the PodcastUserControl.</span></span>

<span data-ttu-id="37f03-188">いくつか PodcastObjects を生成したら、PodcastObjects を ListView にバインドして、ポッドキャストのリストを作成できます。</span><span class="sxs-lookup"><span data-stu-id="37f03-188">After you have generated some PodcastObjects, you can create a list of podcasts by binding the PodcastObjects to a ListView.</span></span> <span data-ttu-id="37f03-189">PodcastUserControl オブジェクトは、PodcastObjects の視覚エフェクトを記述します。したがって、ListView の ItemTemplate を使って設定します。</span><span class="sxs-lookup"><span data-stu-id="37f03-189">The PodcastUserControl objects describe the visualization of the PodcastObjects, and are therefore set using the ListView's ItemTemplate.</span></span>

<span data-ttu-id="37f03-190">**MainPage.xaml**</span><span class="sxs-lookup"><span data-stu-id="37f03-190">**MainPage.xaml**</span></span>
```xaml
<ListView x:Name="ListOfPodcasts"
            ItemsSource="{x:Bind podcasts}">
    <ListView.ItemTemplate>
        <DataTemplate x:DataType="local:PodcastObject">
            <local:PodcastUserControl PodcastObject="{x:Bind Mode=OneWay}" />
        </DataTemplate>
    </ListView.ItemTemplate>
    <ListView.ItemContainerStyle>
        <!-- The PodcastUserControl will entirely fill the ListView item and handle tabbing within itself. -->
        <Style TargetType="ListViewItem" BasedOn="{StaticResource ListViewItemRevealStyle}">
            <Setter Property="HorizontalContentAlignment" Value="Stretch" />
            <Setter Property="Padding" Value="0"/>
            <Setter Property="IsTabStop" Value="False"/>
        </Style>
    </ListView.ItemContainerStyle>
</ListView>
```

## <a name="creating-context-menus"></a><span data-ttu-id="37f03-191">コンテキスト メニューの作成</span><span class="sxs-lookup"><span data-stu-id="37f03-191">Creating context menus</span></span>

<span data-ttu-id="37f03-192">コンテキスト メニューは、ユーザーの要求に応じて、コマンドやオプションの一覧を表示します。</span><span class="sxs-lookup"><span data-stu-id="37f03-192">Context menus display a list of commands or options when the user requests them.</span></span> <span data-ttu-id="37f03-193">コンテキスト メニューは、アタッチされた要素に関連するコンテキスト コマンドを提供します。また、通常、その項目固有のセカンダリ操作のために予約されています。</span><span class="sxs-lookup"><span data-stu-id="37f03-193">Context menus provide contextual commands related to their attached element, and are generally reserved for secondary actions specific to that item.</span></span>

![項目のコンテキスト メニューを表示する](images/ContextualCommand_RightClick.png)

<span data-ttu-id="37f03-195">ユーザーは、以下の "コンテキスト アクション" を使ってコンテキスト メニューを呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="37f03-195">The user can invoke context menus using these "context actions":</span></span>

| <span data-ttu-id="37f03-196">入力</span><span class="sxs-lookup"><span data-stu-id="37f03-196">Input</span></span>    | <span data-ttu-id="37f03-197">コンテキスト アクション</span><span class="sxs-lookup"><span data-stu-id="37f03-197">Context action</span></span>                          |
| -------- | --------------------------------------- |
| <span data-ttu-id="37f03-198">マウス</span><span class="sxs-lookup"><span data-stu-id="37f03-198">Mouse</span></span>    | <span data-ttu-id="37f03-199">右クリック</span><span class="sxs-lookup"><span data-stu-id="37f03-199">Right click</span></span>                             |
| <span data-ttu-id="37f03-200">キーボード</span><span class="sxs-lookup"><span data-stu-id="37f03-200">Keyboard</span></span> | <span data-ttu-id="37f03-201">Shift + F10、メニュー ボタン</span><span class="sxs-lookup"><span data-stu-id="37f03-201">Shift+F10, Menu button</span></span>                  |
| <span data-ttu-id="37f03-202">タッチ</span><span class="sxs-lookup"><span data-stu-id="37f03-202">Touch</span></span>    | <span data-ttu-id="37f03-203">項目を長押し</span><span class="sxs-lookup"><span data-stu-id="37f03-203">Long press on item</span></span>                      |
| <span data-ttu-id="37f03-204">ペン</span><span class="sxs-lookup"><span data-stu-id="37f03-204">Pen</span></span>      | <span data-ttu-id="37f03-205">バレル ボタンを押す、項目を長押し</span><span class="sxs-lookup"><span data-stu-id="37f03-205">Barrel button press, long press on item</span></span> |
| <span data-ttu-id="37f03-206">ゲームパッド</span><span class="sxs-lookup"><span data-stu-id="37f03-206">Gamepad</span></span>  | <span data-ttu-id="37f03-207">メニュー ボタン</span><span class="sxs-lookup"><span data-stu-id="37f03-207">Menu button</span></span>                             |

<span data-ttu-id="37f03-208">**入力の種類に関係なく、コンテキスト メニューを開くことがあるため、コンテキスト メニューはすべてのリスト項目に使用できるコンテキスト コマンドを含める必要があります。**</span><span class="sxs-lookup"><span data-stu-id="37f03-208">**Since the user can open a context menu regardless of input type, your context menu should contain all of the contextual commands available for the list item.**</span></span>

### <a name="contextflyout"></a><span data-ttu-id="37f03-209">ContextFlyout</span><span class="sxs-lookup"><span data-stu-id="37f03-209">ContextFlyout</span></span>

<span data-ttu-id="37f03-210">UIElement クラスによって定義される [ContextFlyout プロパティ](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.UIElement.ContextFlyout) を利用すると、すべての入力の種類で使えるコンテキスト メニューを簡単に作成できます。</span><span class="sxs-lookup"><span data-stu-id="37f03-210">The [ContextFlyout property](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.UIElement.ContextFlyout), defined by the UIElement class, makes it easy to create a context menu that works with all input types.</span></span> <span data-ttu-id="37f03-211">コンテキスト メニューを表すポップアップは MenuFlyout を使って提供します。上記で定義した “コンテキスト操作” をユーザーが実行すると、項目に対応する MenuFlyout が表示されます。</span><span class="sxs-lookup"><span data-stu-id="37f03-211">You provide a flyout representing your context menu using MenuFlyout, and when the user performs a “context action” as defined above, the MenuFlyout corresponding to the item will be displayed.</span></span>

<span data-ttu-id="37f03-212">ContextFlyout を PodcastUserControl に追加します。</span><span class="sxs-lookup"><span data-stu-id="37f03-212">We will add a ContextFlyout to the PodcastUserControl.</span></span> <span data-ttu-id="37f03-213">ContextFlyout として指定された MenuFlyout には、ポッドキャストをお気に入りに追加するための項目が 1 つだけ含まれています。</span><span class="sxs-lookup"><span data-stu-id="37f03-213">The MenuFlyout specified as the ContextFlyout contains a single item to favorite a podcast.</span></span> <span data-ttu-id="37f03-214">この MenuFlyoutItem では上記で定義した favoriteCommand を使い、CommandParamter が PodcastObject にバインドされていることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="37f03-214">Notice that this MenuFlyoutItem uses the favoriteCommand defined above, with the CommandParamter bound to the PodcastObject.</span></span>

<span data-ttu-id="37f03-215">**PodcastUserControl.xaml**</span><span class="sxs-lookup"><span data-stu-id="37f03-215">**PodcastUserControl.xaml**</span></span>
```xaml
<UserControl>
    <UserControl.ContextFlyout>
        <MenuFlyout>
            <MenuFlyoutItem Text="Favorite" Command="{StaticResource favoriteCommand}" CommandParameter="{x:Bind PodcastObject, Mode=OneWay}" />
        </MenuFlyout>
    </UserControl.ContextFlyout>
    <Grid Margin="12,0,12,0">
        <!-- ... -->
    </Grid>
</UserControl>

```

<span data-ttu-id="37f03-216">また、[ContextRequested イベント](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.UIElement.ContextRequested) を使って、コンテキスト操作に応答することもできます。</span><span class="sxs-lookup"><span data-stu-id="37f03-216">Note that you can also use the [ContextRequested event](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.UIElement.ContextRequested) to respond to context actions.</span></span> <span data-ttu-id="37f03-217">ContextRequested イベントは、ContextFlyout が指定されている場合は発生しません。</span><span class="sxs-lookup"><span data-stu-id="37f03-217">The ContextRequested event will not fire if a ContextFlyout has been specified.</span></span>

## <a name="creating-input-accelerators"></a><span data-ttu-id="37f03-218">入力アクセラレータの作成</span><span class="sxs-lookup"><span data-stu-id="37f03-218">Creating input accelerators</span></span>

<span data-ttu-id="37f03-219">コレクション内の各項目のコンテキスト コマンドをすべて含むコンテキスト メニューを用意することをお勧めしますが、よく実行される特定のコマンドをユーザーがすばやく実行できるようにすることも一案です。</span><span class="sxs-lookup"><span data-stu-id="37f03-219">Although each item in the collection should have a context menu containing all contextual commands, you might want to enable users to quickly perform a smaller set of frequently performed commands.</span></span> <span data-ttu-id="37f03-220">たとえば、メール アプリであれば、応答、アーカイブ、フォルダーへ移動、フラグの設定、削除などのセカンダリ コマンドをコンテキスト メニューに表示しますが、最もよく使われるコマンドは削除とフラグの設定です。</span><span class="sxs-lookup"><span data-stu-id="37f03-220">For example, a mailing app may have secondary commands like Reply, Archive, Move to Folder, Set Flag, and Delete which appear in a context menu, but the most common commands are Delete and Flag.</span></span> <span data-ttu-id="37f03-221">最もよく使われるコマンドを特定したら、入力ベースのアクセラレータを使って、これらのコマンドをユーザーが実行しやすくできます。</span><span class="sxs-lookup"><span data-stu-id="37f03-221">After you have identified which commands are most common, you can use input-based accelerators to make these commands easier for a user to perform.</span></span>

<span data-ttu-id="37f03-222">ポッドキャスト アプリでは、頻繁に実行されるコマンドは ”お気に入り” コマンドです。</span><span class="sxs-lookup"><span data-stu-id="37f03-222">In the podcast app, the frequently performed command is the "Favorite" command.</span></span>

### <a name="keyboard-accelerators"></a><span data-ttu-id="37f03-223">キーボード アクセラレータ</span><span class="sxs-lookup"><span data-stu-id="37f03-223">Keyboard accelerators</span></span>

#### <a name="shortcuts-and-direct-key-handling"></a><span data-ttu-id="37f03-224">ショートカットと直接キーの処理</span><span class="sxs-lookup"><span data-stu-id="37f03-224">Shortcuts and direct key handling</span></span>

![Ctrl キーと F キーを押して操作を実行](images/ContextualCommand_Keyboard.png)

<span data-ttu-id="37f03-226">コンテンツの種類に応じて、操作を実行する特定のキーの組み合わせを明らかにします。</span><span class="sxs-lookup"><span data-stu-id="37f03-226">Depending on the type of content, you may identify certain key combinations that should perform an action.</span></span> <span data-ttu-id="37f03-227">たとえば、メール アプリでは、選択されたメールの削除に Del キーが使われる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="37f03-227">In an email app, for example, the DEL key may be used to delete the email that is selected.</span></span> <span data-ttu-id="37f03-228">ポッドキャスト アプリでは、Ctrl + S や F キーによって、後で視聴するためにポッドキャストをお気に入りに追加する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="37f03-228">In a podcast app, the Ctrl+S or F keys could favorite a podcast for later.</span></span> <span data-ttu-id="37f03-229">Del キーで削除するなど、よく知られた一般的なキーボード ショートカットがあるコマンドもあれば、アプリまたはドメイン固有のショートカットがあるコマンドもあります。</span><span class="sxs-lookup"><span data-stu-id="37f03-229">Although some commands have common, well-known keyboard shortcuts like DEL to delete, other commands have app- or domain-specific shortcuts.</span></span> <span data-ttu-id="37f03-230">できればよく知られているショートカットを使用してください。または、ヒントでリマインダー テキストを表示してショートカット コマンドをユーザーに伝えることを検討してください。</span><span class="sxs-lookup"><span data-stu-id="37f03-230">Use well-known shortcuts if possible, or consider providing reminder text in a tooltip to teach the user about the shortcut command.</span></span>

<span data-ttu-id="37f03-231">[KeyDown](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.UIElement.KeyDownEvent) イベントを使うことで、アプリはユーザーがキーを押したときに応答できます。</span><span class="sxs-lookup"><span data-stu-id="37f03-231">Your app can respond when the user presses a key using the [KeyDown](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.UIElement.KeyDownEvent) event.</span></span> <span data-ttu-id="37f03-232">通常ユーザーは、押したキーを放すときではなく、キーを最初に押したときにアプリが応答するものと考えます。</span><span class="sxs-lookup"><span data-stu-id="37f03-232">In general, users expect that the app will respond when they first press the key down, rather than waiting until they release the key.</span></span>

<span data-ttu-id="37f03-233">次の例では、KeyDown ハンドラーを PodcastUserControl に追加して、ユーザーが Ctrl + S または F キーを押したときにポッドキャストをお気に入りに追加する方法を示しています。このコードでは、前と同じコマンドを使っています。</span><span class="sxs-lookup"><span data-stu-id="37f03-233">This example walks through how to add the KeyDown handler to the PodcastUserControl to favorite a podcast when the user presses Ctrl+S or F. It uses the same command as before.</span></span>

<span data-ttu-id="37f03-234">**PodcastUserControl.xaml.cs**</span><span class="sxs-lookup"><span data-stu-id="37f03-234">**PodcastUserControl.xaml.cs**</span></span>
```csharp
// Respond to the F and Ctrl+S keys to favorite the focused item.
protected override void OnKeyDown(KeyRoutedEventArgs e)
{
    var ctrlState = CoreWindow.GetForCurrentThread().GetKeyState(VirtualKey.Control);
    var isCtrlPressed = (ctrlState & CoreVirtualKeyStates.Down) == CoreVirtualKeyStates.Down || (ctrlState & CoreVirtualKeyStates.Locked) == CoreVirtualKeyStates.Locked;

    if (e.Key == Windows.System.VirtualKey.F || (e.Key == Windows.System.VirtualKey.S && isCtrlPressed))
    {
        // Favorite the item using the defined command
        var favoriteCommand = Application.Current.Resources["favoriteCommand"] as ICommand;
        favoriteCommand.Execute(PodcastObject);
    }
}
```

### <a name="mouse-accelerators"></a><span data-ttu-id="37f03-235">マウス アクセラレータ</span><span class="sxs-lookup"><span data-stu-id="37f03-235">Mouse accelerators</span></span>

![項目の上にマウス ポインターを重ねてボタンを表示](images/ContextualCommand_HovertoReveal.png)

<span data-ttu-id="37f03-237">右クリックのコンテキスト メニューはユーザーにとっておなじみですが、マウスのクリック 1 回で、よく使われるコマンドを実行できるようにしても便利です。</span><span class="sxs-lookup"><span data-stu-id="37f03-237">Users are familiar with right-click context menus, but you may wish to empower users to perform common commands using only a single click of the mouse.</span></span> <span data-ttu-id="37f03-238">このエクスペリエンスを実現するには、専用のボタンをコレクション項目のキャンバスに含めます。</span><span class="sxs-lookup"><span data-stu-id="37f03-238">To enable this experience, you can include dedicated buttons on your collection item's canvas.</span></span> <span data-ttu-id="37f03-239">ユーザーがマウスを使ってすばやく操作できるようにすると同時に、不要な表示をできる限りなくすには、特定のリスト項目内にポインターが置かれたときに、専用のボタンのみが表示されるようにすることができます。</span><span class="sxs-lookup"><span data-stu-id="37f03-239">To both empower users to act quickly using mouse, and to minimize visual clutter, you can choose to only reveal these buttons when the user has their pointer within a particular list item.</span></span>

<span data-ttu-id="37f03-240">次の例では、PodcastUserControl 内で直接定義したボタンによって、お気に入りコマンドを提示しています。</span><span class="sxs-lookup"><span data-stu-id="37f03-240">In this example, the Favorite command is represented by a button defined directly in the PodcastUserControl.</span></span> <span data-ttu-id="37f03-241">なお、この例のボタンでも、以前と同じ FavoriteCommand コマンドを使っています。</span><span class="sxs-lookup"><span data-stu-id="37f03-241">Note that the button in this example uses the same command, FavoriteCommand, as before.</span></span> <span data-ttu-id="37f03-242">このボタンの表示と非表示を切り替えるには、VisualStateManager を使って、ボタンの領域内にポインターが置かれたときと、領域からポインターが外れたときに、表示の状態を切り替えることができます。</span><span class="sxs-lookup"><span data-stu-id="37f03-242">To toggle visibility of this button, you can use the VisualStateManager to switch between visual states when the pointer enters and exits the control.</span></span>

<span data-ttu-id="37f03-243">**PodcastUserControl.xaml**</span><span class="sxs-lookup"><span data-stu-id="37f03-243">**PodcastUserControl.xaml**</span></span>
```xaml
<UserControl>
    <UserControl.ContextFlyout>
        <!-- ... -->
    </UserControl.ContextFlyout>
    <Grid Margin="12,0,12,0">
        <VisualStateManager.VisualStateGroups>
            <VisualStateGroup x:Name="HoveringStates">
                <VisualState x:Name="HoverButtonsShown">
                    <VisualState.Setters>
                        <Setter Target="hoverArea.Visibility" Value="Visible" />
                    </VisualState.Setters>
                </VisualState>
                <VisualState x:Name="HoverButtonsHidden" />
            </VisualStateGroup>
        </VisualStateManager.VisualStateGroups>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="*" />
            <ColumnDefinition Width="Auto" />
        </Grid.ColumnDefinitions>
        <StackPanel>
            <TextBlock Text="{x:Bind PodcastObject.Title, Mode=OneWay}" Style="{StaticResource TitleTextBlockStyle}" />
            <TextBlock Text="{x:Bind PodcastObject.Description, Mode=OneWay}" Style="{StaticResource SubtitleTextBlockStyle}" />
            <TextBlock Text="{x:Bind PodcastObject.IsFavorite, Mode=OneWay}" Style="{StaticResource SubtitleTextBlockStyle}"/>
        </StackPanel>
        <Grid Grid.Column="1" x:Name="hoverArea" Visibility="Collapsed" VerticalAlignment="Stretch">
            <AppBarButton Icon="OutlineStar" Label="Favorite" Command="{StaticResource favoriteCommand}" CommandParameter="{x:Bind PodcastObject, Mode=OneWay}" IsTabStop="False" VerticalAlignment="Stretch"  />
        </Grid>
    </Grid>
</UserControl>
```

<span data-ttu-id="37f03-244">ホバー ボタンは、マウス ポインターが項目に重なったら表示し、項目から外れたら非表示にします。</span><span class="sxs-lookup"><span data-stu-id="37f03-244">The hover buttons should appear and disappear when the mouse enters and exits the item.</span></span> <span data-ttu-id="37f03-245">マウス イベントに応答するには、PodcastUserControl で [PointerEntered](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.UIElement.PointerEnteredEvent) イベントと [PointerExited](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.UIElement.PointerExitedEvent) イベントを使います。</span><span class="sxs-lookup"><span data-stu-id="37f03-245">To respond to mouse events, you can use the [PointerEntered](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.UIElement.PointerEnteredEvent) and [PointerExited](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.UIElement.PointerExitedEvent) events on the PodcastUserControl.</span></span>

<span data-ttu-id="37f03-246">**PodcastUserControl.xaml.cs**</span><span class="sxs-lookup"><span data-stu-id="37f03-246">**PodcastUserControl.xaml.cs**</span></span>
```csharp
protected override void OnPointerEntered(PointerRoutedEventArgs e)
{
    base.OnPointerEntered(e);

    // Only show hover buttons when the user is using mouse or pen.
    if (e.Pointer.PointerDeviceType == Windows.Devices.Input.PointerDeviceType.Mouse || e.Pointer.PointerDeviceType == Windows.Devices.Input.PointerDeviceType.Pen)
    {
        VisualStateManager.GoToState(this, "HoverButtonsShown", true);
    }
}

protected override void OnPointerExited(PointerRoutedEventArgs e)
{
    base.OnPointerExited(e);

    VisualStateManager.GoToState(this, "HoverButtonsHidden", true);
}
```

<span data-ttu-id="37f03-247">ホバー状態で表示されたボタンは、ポインター入力でしかアクセスできません。</span><span class="sxs-lookup"><span data-stu-id="37f03-247">The buttons displayed in the hover state will only be accessible via the pointer input type.</span></span> <span data-ttu-id="37f03-248">このボタンはポインター入力でしか操作できないため、ボタンのアイコンを囲む余白を最小限にするか完全になくして、ポインター入力向けに最適化することもできます。</span><span class="sxs-lookup"><span data-stu-id="37f03-248">Because these buttons are limited to pointer input, you may choose to minimize or remove the padding around the icon of the button to optimize for pointer input.</span></span> <span data-ttu-id="37f03-249">余白をなくす場合は、ペンとマウスで操作できるように、ボタンのフットプリントを必ず 20 x 20 ピクセル以上にしてください。</span><span class="sxs-lookup"><span data-stu-id="37f03-249">If you choose to do so, ensure that the button footprint is at least 20x20px to remain usable with pen and mouse.</span></span>

### <a name="touch-accelerators"></a><span data-ttu-id="37f03-250">タッチ アクセラレータ</span><span class="sxs-lookup"><span data-stu-id="37f03-250">Touch accelerators</span></span>

#### <a name="swipe"></a><span data-ttu-id="37f03-251">スワイプ</span><span class="sxs-lookup"><span data-stu-id="37f03-251">Swipe</span></span>

![項目をスワイプしてコマンドを表示](images/ContextualCommand_Swipe.png)

<span data-ttu-id="37f03-253">スワイプによるコマンド実行は、タッチ デバイスを操作しているユーザーが、よく使われるセカンダリ操作をタッチを使って実行できるようにするタッチ アクセラレータです。</span><span class="sxs-lookup"><span data-stu-id="37f03-253">Swipe commanding is a touch accelerator that enables users on touch devices to perform common secondary actions using touch.</span></span> <span data-ttu-id="37f03-254">スワイプはタッチ ユーザーが、スワイプして削除やスワイプして呼び出すなどの一般的な操作を使って、コンテンツをすばやく自然に操作することを可能にします。</span><span class="sxs-lookup"><span data-stu-id="37f03-254">Swipe empowers touch users to quickly and naturally interact with content, using common actions like Swipe-to-Delete or Swipe-to-Invoke.</span></span> <span data-ttu-id="37f03-255">詳しくは、[スワイプによるコマンドの実行](swipe.md)についての記事をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="37f03-255">See the [swipe commanding](swipe.md) article to learn more.</span></span>

<span data-ttu-id="37f03-256">コレクションにスワイプを統合するためには、2 つのコンポーネントが必要です。SwipeItems のコマンドをホストします。SwipeControl には、項目をラップし、スワイプ操作では、これを選択します。</span><span class="sxs-lookup"><span data-stu-id="37f03-256">In order to integrate swipe into your collection, you need two components: SwipeItems, which hosts the commands; and a SwipeControl, which wraps the item and allows for swipe interaction.</span></span>

<span data-ttu-id="37f03-257">SwipeItems は、PodcastUserControl 内の Resource として定義できます。</span><span class="sxs-lookup"><span data-stu-id="37f03-257">The SwipeItems can be defined as a Resource in the PodcastUserControl.</span></span> <span data-ttu-id="37f03-258">次の例では、SwipeItems に、項目をお気に入りに追加するコマンドが含まれています。</span><span class="sxs-lookup"><span data-stu-id="37f03-258">In this example, SwipeItems contains a command to Favorite an item.</span></span>

```xaml
<UserControl.Resources>
    <SymbolIconSource x:Key="FavoriteIcon" Symbol="Favorite"/>
    <SwipeItems x:Key="RevealOtherCommands" Mode="Reveal">
        <SwipeItem IconSource="{StaticResource FavoriteIcon}" Text="Favorite" Background="Yellow" Invoked="SwipeItem_Invoked"/>
    </SwipeItems>
</UserControl.Resources>
```

<span data-ttu-id="37f03-259">SwipeControl は項目をラップし、ユーザーがスワイプ ジェスチャを使って項目を操作できるようにしています。</span><span class="sxs-lookup"><span data-stu-id="37f03-259">The SwipeControl wraps the item and allows the user to interact with it using the swipe gesture.</span></span> <span data-ttu-id="37f03-260">SwipeControl には、RightItems として SwipeItems への参照が含まれていることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="37f03-260">Notice that the SwipeControl contains a reference to the SwipeItems as its RightItems.</span></span> <span data-ttu-id="37f03-261">ユーザーが右から左へスワイプすると、お気に入りの項目が表示されます。</span><span class="sxs-lookup"><span data-stu-id="37f03-261">The Favorite item will show when the user swipes from right to left.</span></span>

```xaml
<SwipeControl x:Name="swipeContainer" RightItems="{StaticResource RevealOtherCommands}">
   <!-- The visual state groups moved from the Grid to the SwipeControl, since the SwipeControl wraps the Grid. -->
   <VisualStateManager.VisualStateGroups>
       <VisualStateGroup x:Name="HoveringStates">
           <VisualState x:Name="HoverButtonsShown">
               <VisualState.Setters>
                   <Setter Target="hoverArea.Visibility" Value="Visible" />
               </VisualState.Setters>
           </VisualState>
           <VisualState x:Name="HoverButtonsHidden" />
       </VisualStateGroup>
   </VisualStateManager.VisualStateGroups>
   <Grid Margin="12,0,12,0">
       <Grid.ColumnDefinitions>
           <ColumnDefinition Width="*" />
           <ColumnDefinition Width="Auto" />
       </Grid.ColumnDefinitions>
       <StackPanel>
           <TextBlock Text="{x:Bind PodcastObject.Title, Mode=OneWay}" Style="{StaticResource TitleTextBlockStyle}" />
           <TextBlock Text="{x:Bind PodcastObject.Description, Mode=OneWay}" Style="{StaticResource SubtitleTextBlockStyle}" />
           <TextBlock Text="{x:Bind PodcastObject.IsFavorite, Mode=OneWay}" Style="{StaticResource SubtitleTextBlockStyle}"/>
       </StackPanel>
       <Grid Grid.Column="1" x:Name="hoverArea" Visibility="Collapsed" VerticalAlignment="Stretch">
           <AppBarButton Icon="OutlineStar" Command="{StaticResource favoriteCommand}" CommandParameter="{x:Bind PodcastObject, Mode=OneWay}" IsTabStop="False" LabelPosition="Collapsed" VerticalAlignment="Stretch"  />
       </Grid>
   </Grid>
</SwipeControl>
```

<span data-ttu-id="37f03-262">ユーザーがスワイプしてお気に入りコマンドを呼び出すと、Invoked メソッドが呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="37f03-262">When the user swipes to invoke the Favorite command, the Invoked method is called.</span></span>

```csharp
private void SwipeItem_Invoked(SwipeItem sender, SwipeItemInvokedEventArgs args)
{
    // Favorite the item using the defined command
    var favoriteCommand = Application.Current.Resources["favoriteCommand"] as ICommand;
    favoriteCommand.Execute(PodcastObject);
}
```

#### <a name="pull-to-refresh"></a><span data-ttu-id="37f03-263">引っ張って更新</span><span class="sxs-lookup"><span data-stu-id="37f03-263">Pull to refresh</span></span>

<span data-ttu-id="37f03-264">引っ張って更新を使うと、タッチ操作でデータのコレクションを引き下げることで、より多くのデータを取得できます。</span><span class="sxs-lookup"><span data-stu-id="37f03-264">Pull to refresh lets a user pull down on a collection of data using touch in order to retrieve more data.</span></span> <span data-ttu-id="37f03-265">詳しくは、[引っ張って更新](pull-to-refresh.md)についての記事をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="37f03-265">See the [pull to refresh](pull-to-refresh.md) article to learn more.</span></span>

### <a name="pen-accelerators"></a><span data-ttu-id="37f03-266">ペン アクセラレータ</span><span class="sxs-lookup"><span data-stu-id="37f03-266">Pen accelerators</span></span>

<span data-ttu-id="37f03-267">ペン入力は、精度の高いポインター入力を実現します。</span><span class="sxs-lookup"><span data-stu-id="37f03-267">The pen input type provides the precision of pointer input.</span></span> <span data-ttu-id="37f03-268">ユーザーは、ペン ベースのアクセラレータを使って、コンテキスト メニューを開くなどの一般的な操作を実行できます。</span><span class="sxs-lookup"><span data-stu-id="37f03-268">Users can perform common actions such as opening context menus using pen-based accelerators.</span></span> <span data-ttu-id="37f03-269">コンテキスト メニューを開くには、バレル ボタンを押して画面をタップするか、コンテンツを長押しします。</span><span class="sxs-lookup"><span data-stu-id="37f03-269">To open a context menu, users can tap the screen with the barrel button pressed, or long press on the content.</span></span> <span data-ttu-id="37f03-270">また、マウスと同様に、ペンを使ってコンテンツにポインターを重ねて、ヒントを表示するなど、UI についての理解を深めたり、セカンダリのホバー操作を表示したりすることもできます。</span><span class="sxs-lookup"><span data-stu-id="37f03-270">Users can also use the pen to hover over content to get a deeper understanding of the UI like displaying tooltips, or to reveal secondary hover actions, similar to mouse.</span></span>

<span data-ttu-id="37f03-271">ペン入力用にアプリを最適化するには、[ペン操作とスタイラス操作](../input/pen-and-stylus-interactions.md)についての記事をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="37f03-271">To optimize your app for pen input, see the [pen and stylus interaction](../input/pen-and-stylus-interactions.md) article.</span></span>


## <a name="dos-and-donts"></a><span data-ttu-id="37f03-272">推奨と非推奨</span><span class="sxs-lookup"><span data-stu-id="37f03-272">Do's and don'ts</span></span>

* <span data-ttu-id="37f03-273">どの種類の UWP デバイスでも、ユーザーがすべてのコマンドにアクセスできるようにします。</span><span class="sxs-lookup"><span data-stu-id="37f03-273">Do make sure that users can access all commands from all types of UWP devices.</span></span>
* <span data-ttu-id="37f03-274">コレクション項目に対するコマンド全部にアクセスできるコンテキスト メニューを含めます。</span><span class="sxs-lookup"><span data-stu-id="37f03-274">Do include a context menu that provides access to all the commands available for a collection item.</span></span> 
* <span data-ttu-id="37f03-275">頻繁に使われるコマンドについては、入力アクセラレータを提供します。</span><span class="sxs-lookup"><span data-stu-id="37f03-275">Do provide input accelerators for frequently-used commands.</span></span> 
* <span data-ttu-id="37f03-276">コマンドの実装には [ICommand インターフェイス](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Input.ICommand) を使う。</span><span class="sxs-lookup"><span data-stu-id="37f03-276">Do use the [ICommand interface](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Input.ICommand) to implement commands.</span></span> 

## <a name="related-topics"></a><span data-ttu-id="37f03-277">関連トピック</span><span class="sxs-lookup"><span data-stu-id="37f03-277">Related topics</span></span>
* [<span data-ttu-id="37f03-278">ICommand インターフェイス</span><span class="sxs-lookup"><span data-stu-id="37f03-278">ICommand Interface</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Input.ICommand)
* [<span data-ttu-id="37f03-279">メニューおよびコンテキスト メニュー</span><span class="sxs-lookup"><span data-stu-id="37f03-279">Menus and Context Menus</span></span>](menus.md)
* [<span data-ttu-id="37f03-280">スワイプ</span><span class="sxs-lookup"><span data-stu-id="37f03-280">Swipe</span></span>](swipe.md)
* [<span data-ttu-id="37f03-281">引っ張って更新</span><span class="sxs-lookup"><span data-stu-id="37f03-281">Pull to refresh</span></span>](pull-to-refresh.md)
* [<span data-ttu-id="37f03-282">ペン、スタイラスの相互作用</span><span class="sxs-lookup"><span data-stu-id="37f03-282">Pen and stylus interaction</span></span>](../input/pen-and-stylus-interactions.md)
* [<span data-ttu-id="37f03-283">ゲームパッドと Xbox アプリを調整します。</span><span class="sxs-lookup"><span data-stu-id="37f03-283">Tailor your app for gamepad and Xbox</span></span>](../devices/designing-for-tv.md)
