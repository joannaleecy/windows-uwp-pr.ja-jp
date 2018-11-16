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
ms.sourcegitcommit: 9f8010fe67bb3372db1840de9f0be36097ed6258
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/16/2018
ms.locfileid: "7119612"
---
# <a name="bind-hierarchical-data-and-create-a-masterdetails-view"></a>階層データをバインドしてマスター/詳細ビューを作る方法



> **注:** も、[マスター/詳細のサンプル](http://go.microsoft.com/fwlink/p/?linkid=619991)をご覧ください。

チェーン内でバインドされた [**CollectionViewSource**](https://msdn.microsoft.com/library/windows/apps/BR209833) インスタンスに項目コントロールをバインドすることによって、階層データの複数レベルのマスター/詳細 (リスト/詳細とも呼ばれる) ビューを作成することができます。 このトピックでは、できる限り [{x:Bind} マークアップ拡張](https://msdn.microsoft.com/library/windows/apps/Mt204783)を使用し、必要に応じて、より柔軟な (ただし効率は低下する) [{Binding} マークアップ拡張](https://msdn.microsoft.com/library/windows/apps/Mt204782)を使います。

ユニバーサル Windows プラットフォーム (UWP) アプリでよく使われる構造の 1 つに、マスター一覧で項目を選んだらさまざまな詳細ページに移動するという形があります。 これは、階層のすべてのレベルで、各項目をリッチな視覚表現を使って表示する場合に便利です。 また、複数のレベルのデータを 1 ページに表示することもできます。 これは、ユーザーが関心のある項目にすばやくドリルダウンできるように、シンプルな一覧をいくつか表示する場合に便利です。 このトピックでは、この操作を実装する方法について説明します。 [**CollectionViewSource**](https://msdn.microsoft.com/library/windows/apps/BR209833) インスタンスは、現在の選択を各階層レベルで追跡します。

ここでは、リーグ、クラス、チームの一覧に階層化され、チーム詳細のビューを含むスポーツ チーム階層のビューを作ります。 いずれかの一覧で項目を選ぶと、後続するビューが自動的に更新されます。

![スポーツ階層のマスター/詳細ビュー](images/xaml-masterdetails.png)

## <a name="prerequisites"></a>前提条件

このトピックでは、基本的な UWP アプリを作成できることを前提としています。 初めて UWP アプリを作る場合の手順については、「[C# または Visual Basic を使った初めての UWP アプリの作成](https://msdn.microsoft.com/library/windows/apps/Hh974581)」をご覧ください。

## <a name="create-the-project"></a>プロジェクトの作成

最初に、**"新しいアプリケーション (Windows ユニバーサル)"** プロジェクトを新規作成します。 プロジェクトに "MasterDetailsBinding" という名前を付けます。

## <a name="create-the-data-model"></a>データ モデルを作る

プロジェクトに新しいクラスを追加して ViewModel.cs という名前を付け、次のコードを追加します。 これは、バインディング ソース クラスになります。

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

## <a name="create-the-view"></a>ビューを作る

次に、マークアップのページを表すクラスからバインディング ソース クラスを公開します。 これを行うには、**LeagueList** 型のプロパティを **MainPage** に追加します。

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

最後に、MainPage.xaml ファイルの内容を次のマークアップに置き換えます。このマークアップでは、3 つの [**CollectionViewSource**](https://msdn.microsoft.com/library/windows/apps/BR209833) インスタンスを宣言し、チェーンで一緒にバインドします。 これにより、階層内のレベルに応じて、後続するコントロールを適切な **CollectionViewSource** にバインドできるようになります。

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

[**CollectionViewSource**](https://msdn.microsoft.com/library/windows/apps/BR209833) に直接バインドすることによって、コレクション自体ではパスが見つからない、バインディング内の現在の項目にバインドすることを意味します。 バインディングのパスとして **CurrentItem** プロパティを指定する必要はありませんが、あいまいさがある場合は指定することもできます。 たとえば、チーム ビューを表す [**ContentControl**](https://msdn.microsoft.com/library/windows/apps/BR209365) で、[**Content**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.contentcontrol.content) プロパティが `Teams`**CollectionViewSource** にバインドされているとします。 しかし、**CollectionViewSource** が必要に応じてチームの一覧から現在選択されているチームを自動的に示すため、[**DataTemplate**](https://msdn.microsoft.com/library/windows/apps/BR242348) 内のコントロールは `Team` クラスのプロパティにバインドされます。

 

 

