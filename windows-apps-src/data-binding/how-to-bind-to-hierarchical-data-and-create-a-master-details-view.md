---
author: mcleblanc
ms.assetid: 0C69521B-47E0-421F-857B-851B0E9605F2
title: 階層データをバインドしてマスター/詳細ビューを作る方法
description: チェーン内でバインドされた CollectionViewSource インスタンスに項目コントロールをバインドすると、階層データの複数レベルのマスター/詳細 (リスト/詳細とも呼ばれる) ビューを作成することができます。
ms.author: markl
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 60d283f41c495f9612311e4b9b9da3df1a44d498
ms.sourcegitcommit: cd00bb829306871e5103db481cf224ea7fb613f0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/31/2018
ms.locfileid: "5868297"
---
# <a name="bind-hierarchical-data-and-create-a-masterdetails-view"></a><span data-ttu-id="d4488-104">階層データをバインドしてマスター/詳細ビューを作る方法</span><span class="sxs-lookup"><span data-stu-id="d4488-104">Bind hierarchical data and create a master/details view</span></span>



> <span data-ttu-id="d4488-105">**注:** も、[マスター/詳細のサンプル](http://go.microsoft.com/fwlink/p/?linkid=619991)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d4488-105">**Note**Also see the [Master/detail sample](http://go.microsoft.com/fwlink/p/?linkid=619991).</span></span>

<span data-ttu-id="d4488-106">チェーン内でバインドされた [**CollectionViewSource**](https://msdn.microsoft.com/library/windows/apps/BR209833) インスタンスに項目コントロールをバインドすることによって、階層データの複数レベルのマスター/詳細 (リスト/詳細とも呼ばれる) ビューを作成することができます。</span><span class="sxs-lookup"><span data-stu-id="d4488-106">You can make a multi-level master/details (also known as list-details) view of hierarchical data by binding items controls to [**CollectionViewSource**](https://msdn.microsoft.com/library/windows/apps/BR209833) instances that are bound together in a chain.</span></span> <span data-ttu-id="d4488-107">このトピックでは、できる限り [{x:Bind} マークアップ拡張](https://msdn.microsoft.com/library/windows/apps/Mt204783)を使用し、必要に応じて、より柔軟な (ただし効率は低下する) [{Binding} マークアップ拡張](https://msdn.microsoft.com/library/windows/apps/Mt204782)を使います。</span><span class="sxs-lookup"><span data-stu-id="d4488-107">In this topic we use the [{x:Bind} markup extension](https://msdn.microsoft.com/library/windows/apps/Mt204783) where possible, and the more flexible (but less performant) [{Binding} markup extension](https://msdn.microsoft.com/library/windows/apps/Mt204782) where necessary.</span></span>

<span data-ttu-id="d4488-108">ユニバーサル Windows プラットフォーム (UWP) アプリでよく使われる構造の 1 つに、マスター一覧で項目を選んだらさまざまな詳細ページに移動するという形があります。</span><span class="sxs-lookup"><span data-stu-id="d4488-108">One common structure for Universal Windows Platform (UWP) apps is to navigate to different details pages when a user makes a selection in a master list.</span></span> <span data-ttu-id="d4488-109">これは、階層のすべてのレベルで、各項目をリッチな視覚表現を使って表示する場合に便利です。</span><span class="sxs-lookup"><span data-stu-id="d4488-109">This is useful when you want to provide a rich visual representation of each item at every level in a hierarchy.</span></span> <span data-ttu-id="d4488-110">また、複数のレベルのデータを 1 ページに表示することもできます。</span><span class="sxs-lookup"><span data-stu-id="d4488-110">Another option is to display multiple levels of data on a single page.</span></span> <span data-ttu-id="d4488-111">これは、ユーザーが関心のある項目にすばやくドリルダウンできるように、シンプルな一覧をいくつか表示する場合に便利です。</span><span class="sxs-lookup"><span data-stu-id="d4488-111">This is useful when you want to display a few simple lists that let the user quickly drill down to an item of interest.</span></span> <span data-ttu-id="d4488-112">このトピックでは、この操作を実装する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="d4488-112">This topic describes how to implement this interaction.</span></span> <span data-ttu-id="d4488-113">[**CollectionViewSource**](https://msdn.microsoft.com/library/windows/apps/BR209833) インスタンスは、現在の選択を各階層レベルで追跡します。</span><span class="sxs-lookup"><span data-stu-id="d4488-113">The [**CollectionViewSource**](https://msdn.microsoft.com/library/windows/apps/BR209833) instances keep track of the current selection at each hierarchical level.</span></span>

<span data-ttu-id="d4488-114">ここでは、リーグ、クラス、チームの一覧に階層化され、チーム詳細のビューを含むスポーツ チーム階層のビューを作ります。</span><span class="sxs-lookup"><span data-stu-id="d4488-114">We'll create a view of a sports team hierarchy that is organized into lists for leagues, divisions, and teams, and includes a team details view.</span></span> <span data-ttu-id="d4488-115">いずれかの一覧で項目を選ぶと、後続するビューが自動的に更新されます。</span><span class="sxs-lookup"><span data-stu-id="d4488-115">When you select an item from any list, the subsequent views update automatically.</span></span>

![スポーツ階層のマスター/詳細ビュー](images/xaml-masterdetails.png)

## <a name="prerequisites"></a><span data-ttu-id="d4488-117">前提条件</span><span class="sxs-lookup"><span data-stu-id="d4488-117">Prerequisites</span></span>

<span data-ttu-id="d4488-118">このトピックでは、基本的な UWP アプリを作成できることを前提としています。</span><span class="sxs-lookup"><span data-stu-id="d4488-118">This topic assumes that you know how to create a basic UWP app.</span></span> <span data-ttu-id="d4488-119">初めて UWP アプリを作る場合の手順については、「[C# または Visual Basic を使った初めての UWP アプリの作成](https://msdn.microsoft.com/library/windows/apps/Hh974581)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d4488-119">For instructions on creating your first UWP app, see [Create your first UWP app using C# or Visual Basic](https://msdn.microsoft.com/library/windows/apps/Hh974581).</span></span>

## <a name="create-the-project"></a><span data-ttu-id="d4488-120">プロジェクトの作成</span><span class="sxs-lookup"><span data-stu-id="d4488-120">Create the project</span></span>

<span data-ttu-id="d4488-121">最初に、**"新しいアプリケーション (Windows ユニバーサル)"** プロジェクトを新規作成します。</span><span class="sxs-lookup"><span data-stu-id="d4488-121">Create a new **Blank Application (Windows Universal)** project.</span></span> <span data-ttu-id="d4488-122">プロジェクトに "MasterDetailsBinding" という名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="d4488-122">Name it "MasterDetailsBinding".</span></span>

## <a name="create-the-data-model"></a><span data-ttu-id="d4488-123">データ モデルを作る</span><span class="sxs-lookup"><span data-stu-id="d4488-123">Create the data model</span></span>

<span data-ttu-id="d4488-124">プロジェクトに新しいクラスを追加して ViewModel.cs という名前を付け、次のコードを追加します。</span><span class="sxs-lookup"><span data-stu-id="d4488-124">Add a new class to your project, name it ViewModel.cs, and add this code to it.</span></span> <span data-ttu-id="d4488-125">これは、バインディング ソース クラスになります。</span><span class="sxs-lookup"><span data-stu-id="d4488-125">This will be your binding source class.</span></span>

```cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterDetailsBinding
{
    public class Team
    {
        public string Name { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
    }

    public class Division
    {
        public string Name { get; set; }
        public IEnumerable<Team> Teams { get; set; }
    }

    public class League
    {
        public string Name { get; set; }
        public IEnumerable<Division> Divisions { get; set; }
    }

    public class LeagueList : List<League>
    {
        public LeagueList()
        {
            this.AddRange(GetLeague().ToList());
        }

        public IEnumerable<League> GetLeague()
        {
            return from x in Enumerable.Range(1, 2)
                   select new League
                   {
                       Name = "League " + x,
                       Divisions = GetDivisions(x).ToList()
                   };
        }

        public IEnumerable<Division> GetDivisions(int x)
        {
            return from y in Enumerable.Range(1, 3)
                   select new Division
                   {
                       Name = String.Format("Division {0}-{1}", x, y),
                       Teams = GetTeams(x, y).ToList()
                   };
        }

        public IEnumerable<Team> GetTeams(int x, int y)
        {
            return from z in Enumerable.Range(1, 4)
                   select new Team
                   {
                       Name = String.Format("Team {0}-{1}-{2}", x, y, z),
                       Wins = 25 - (x * y * z),
                       Losses = x * y * z
                   };
        }
    }
}
```

## <a name="create-the-view"></a><span data-ttu-id="d4488-126">ビューを作る</span><span class="sxs-lookup"><span data-stu-id="d4488-126">Create the view</span></span>

<span data-ttu-id="d4488-127">次に、マークアップのページを表すクラスからバインディング ソース クラスを公開します。</span><span class="sxs-lookup"><span data-stu-id="d4488-127">Next, expose the binding source class from the class that represents your page of markup.</span></span> <span data-ttu-id="d4488-128">これを行うには、**LeagueList** 型のプロパティを **MainPage** に追加します。</span><span class="sxs-lookup"><span data-stu-id="d4488-128">We do that by adding a property of type **LeagueList** to **MainPage**.</span></span>

```cs
namespace MasterDetailsBinding
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.ViewModel = new LeagueList();
        }
        public LeagueList ViewModel { get; set; }
    }
}
```

<span data-ttu-id="d4488-129">最後に、MainPage.xaml ファイルの内容を次のマークアップに置き換えます。このマークアップでは、3 つの [**CollectionViewSource**](https://msdn.microsoft.com/library/windows/apps/BR209833) インスタンスを宣言し、チェーンで一緒にバインドします。</span><span class="sxs-lookup"><span data-stu-id="d4488-129">Finally, replace the contents of the MainPage.xaml file with the following markup, which declares three [**CollectionViewSource**](https://msdn.microsoft.com/library/windows/apps/BR209833) instances and binds them together in a chain.</span></span> <span data-ttu-id="d4488-130">これにより、階層内のレベルに応じて、後続するコントロールを適切な **CollectionViewSource** にバインドできるようになります。</span><span class="sxs-lookup"><span data-stu-id="d4488-130">The subsequent controls can then bind to the appropriate **CollectionViewSource**, depending on its level in the hierarchy.</span></span>

```xml
<Page
    x:Class="MasterDetailsBinding.MainPage"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:local="using:MasterDetailsBinding"
    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
    mc:Ignorable="d">

    <Page.Resources>
        <CollectionViewSource x:Name="Leagues"
            Source="{x:Bind ViewModel}"/>
        <CollectionViewSource x:Name="Divisions"
            Source="{Binding Divisions, Source={StaticResource Leagues}}"/>
        <CollectionViewSource x:Name="Teams"
            Source="{Binding Teams, Source={StaticResource Divisions}}"/>

        <Style TargetType="TextBlock">
            <Setter Property="FontSize" Value="15"/>
            <Setter Property="FontWeight" Value="Bold"/>
        </Style>

        <Style TargetType="ListBox">
            <Setter Property="FontSize" Value="15"/>
        </Style>

        <Style TargetType="ContentControl">
            <Setter Property="FontSize" Value="15"/>
        </Style>

    </Page.Resources>

    <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">

        <StackPanel Orientation="Horizontal">

            <!-- All Leagues view -->

            <StackPanel Margin="5">
                <TextBlock Text="All Leagues"/>
                <ListBox ItemsSource="{Binding Source={StaticResource Leagues}}" 
                    DisplayMemberPath="Name"/>
            </StackPanel>

            <!-- League/Divisions view -->

            <StackPanel Margin="5">
                <TextBlock Text="{Binding Name, Source={StaticResource Leagues}}"/>
                <ListBox ItemsSource="{Binding Source={StaticResource Divisions}}" 
                    DisplayMemberPath="Name"/>
            </StackPanel>

            <!-- Division/Teams view -->

            <StackPanel Margin="5">
                <TextBlock Text="{Binding Name, Source={StaticResource Divisions}}"/>
                <ListBox ItemsSource="{Binding Source={StaticResource Teams}}" 
                    DisplayMemberPath="Name"/>
            </StackPanel>

            <!-- Team view -->

            <ContentControl Content="{Binding Source={StaticResource Teams}}">
                <ContentControl.ContentTemplate>
                    <DataTemplate>
                        <StackPanel Margin="5">
                            <TextBlock Text="{Binding Name}" 
                                FontSize="15" FontWeight="Bold"/>
                            <StackPanel Orientation="Horizontal" Margin="10,10">
                                <TextBlock Text="Wins:" Margin="0,0,5,0"/>
                                <TextBlock Text="{Binding Wins}"/>
                            </StackPanel>
                            <StackPanel Orientation="Horizontal" Margin="10,0">
                                <TextBlock Text="Losses:" Margin="0,0,5,0"/>
                                <TextBlock Text="{Binding Losses}"/>
                            </StackPanel>
                        </StackPanel>
                    </DataTemplate>
                </ContentControl.ContentTemplate>
            </ContentControl>

        </StackPanel>

    </Grid>
</Page>
```

<span data-ttu-id="d4488-131">[**CollectionViewSource**](https://msdn.microsoft.com/library/windows/apps/BR209833) に直接バインドすることによって、コレクション自体ではパスが見つからない、バインディング内の現在の項目にバインドすることを意味します。</span><span class="sxs-lookup"><span data-stu-id="d4488-131">Note that by binding directly to the [**CollectionViewSource**](https://msdn.microsoft.com/library/windows/apps/BR209833), you're implying that you want to bind to the current item in bindings where the path cannot be found on the collection itself.</span></span> <span data-ttu-id="d4488-132">バインディングのパスとして **CurrentItem** プロパティを指定する必要はありませんが、あいまいさがある場合は指定することもできます。</span><span class="sxs-lookup"><span data-stu-id="d4488-132">There's no need to specify the **CurrentItem** property as the path for the binding, although you can do that if there's any ambiguity.</span></span> <span data-ttu-id="d4488-133">たとえば、チーム ビューを表す [**ContentControl**](https://msdn.microsoft.com/library/windows/apps/BR209365) で、[**Content**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.contentcontrol.content) プロパティが `Teams`**CollectionViewSource** にバインドされているとします。</span><span class="sxs-lookup"><span data-stu-id="d4488-133">For example, the [**ContentControl**](https://msdn.microsoft.com/library/windows/apps/BR209365) representing the team view has its [**Content**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.contentcontrol.content) property bound to the `Teams`**CollectionViewSource**.</span></span> <span data-ttu-id="d4488-134">しかし、**CollectionViewSource** が必要に応じてチームの一覧から現在選択されているチームを自動的に示すため、[**DataTemplate**](https://msdn.microsoft.com/library/windows/apps/BR242348) 内のコントロールは `Team` クラスのプロパティにバインドされます。</span><span class="sxs-lookup"><span data-stu-id="d4488-134">However, the controls in the [**DataTemplate**](https://msdn.microsoft.com/library/windows/apps/BR242348) bind to properties of the `Team` class because the **CollectionViewSource** automatically supplies the currently selected team from the teams list when necessary.</span></span>

 

 

