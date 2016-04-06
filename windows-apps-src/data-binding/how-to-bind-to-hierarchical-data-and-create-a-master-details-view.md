---
ms.assetid: 0C69521B-47E0-421F-857B-851B0E9605F2
title: 階層データをバインドしてマスター/詳細ビューを作る方法
description: チェーン内でバインドされた CollectionViewSource インスタンスに項目コントロールをバインドすることによって、階層データの複数レベルのマスター/詳細 (リスト/詳細とも呼ばれる) ビューを作成することができます。
---
# 階層データをバインドしてマスター/詳細ビューを作る方法

\[ Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください \]


> **注**  [マスター/詳細のサンプル](http://go.microsoft.com/fwlink/p/?linkid=619991)もご覧ください。

チェーン内でバインドされた [**CollectionViewSource**](https://msdn.microsoft.com/library/windows/apps/BR209833) インスタンスに項目コントロールをバインドすることによって、階層データの複数レベルのマスター/詳細 (リスト/詳細とも呼ばれる) ビューを作成することができます。 このトピックでは、できる限り [{x:Bind} マークアップ拡張](https://msdn.microsoft.com/library/windows/apps/Mt204783)を使用し、必要に応じて、より柔軟な (ただし効率は低下する) [{Binding} マークアップ拡張](https://msdn.microsoft.com/library/windows/apps/Mt204782)を使います。

ユニバーサル Windows プラットフォーム (UWP) アプリでよく使われる構造の 1 つに、マスター一覧で項目を選んだらさまざまな詳細ページに移動するという形があります。 これは、階層のすべてのレベルで、各項目をリッチな視覚表現を使って表示する場合に便利です。 また、複数のレベルのデータを 1 ページに表示することもできます。 これは、ユーザーが関心のある項目にすばやくドリルダウンできるように、シンプルな一覧をいくつか表示する場合に便利です。 このトピックでは、この操作を実装する方法について説明します。 [
            **CollectionViewSource**](https://msdn.microsoft.com/library/windows/apps/BR209833) インスタンスは、現在の選択を各階層レベルで追跡します。

ここでは、リーグ、クラス、チームの一覧に階層化され、チーム詳細のビューを含むスポーツ チーム階層のビューを作ります。 いずれかの一覧で項目を選ぶと、後続するビューが自動的に更新されます。

![スポーツ階層のマスター/詳細ビュー](images/xaml-masterdetails.png)

## 前提条件

このトピックでは、基本的な UWP アプリを作成できることを前提としています。 初めて UWP アプリを作る場合の手順については、「[C# または Visual Basic を使った初めての UWP アプリの作成](https://msdn.microsoft.com/library/windows/apps/Hh974581)」をご覧ください。

## プロジェクトの作成

最初に、**"新しいアプリケーション (Windows ユニバーサル)"** プロジェクトを新規作成します。 プロジェクトに "MasterDetailsBinding" という名前を付けます。

## データ モデルを作る

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
        public IEnumerable&lt;Team&gt; Teams { get; set; }
    }

    public class League
    {
        public string Name { get; set; }
        public IEnumerable&lt;Division&gt; Divisions { get; set; }
    }

    public class LeagueList : List&lt;League&gt;
    {
        public LeagueList()
        {
            this.AddRange(GetLeague().ToList());
        }

        public IEnumerable&lt;League&gt; GetLeague()
        {
            return from x in Enumerable.Range(1, 2)
                   select new League
                   {
                       Name = &quot;League &quot; + x,
                       Divisions = GetDivisions(x).ToList()
                   };
        }

        public IEnumerable&lt;Division&gt; GetDivisions(int x)
        {
            return from y in Enumerable.Range(1, 3)
                   select new Division
                   {
                       Name = String.Format(&quot;Division {0}-{1}&quot;, x, y),
                       Teams = GetTeams(x, y).ToList()
                   };
        }

        public IEnumerable&lt;Team&gt; GetTeams(int x, int y)
        {
            return from z in Enumerable.Range(1, 4)
                   select new Team
                   {
                       Name = String.Format(&quot;Team {0}-{1}-{2}&quot;, x, y, z),
                       Wins = 25 - (x * y * z),
                       Losses = x * y * z
                   };
        }
    }
}
```

## ビューを作る

次に、マークアップのページを表すクラスからバインディング ソース クラスを公開します。 これを行うには、**LeagueList** 型のプロパティを **MainPage** に追加します。

```cs
namespace MasterDetailsBinding
{
    /// &lt;summary&gt;
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// &lt;/summary&gt;
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

```xaml
<Page
    x:Class=&quot;MasterDetailsBinding.MainPage&quot;
    xmlns=&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;
    xmlns:x=&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot;
    xmlns:local=&quot;using:MasterDetailsBinding&quot;
    xmlns:d=&quot;http://schemas.microsoft.com/expression/blend/2008&quot;
    xmlns:mc=&quot;http://schemas.openxmlformats.org/markup-compatibility/2006&quot;
    mc:Ignorable=&quot;d&quot;>

    <Page.Resources>
        <CollectionViewSource x:Name=&quot;Leagues&quot;
            Source=&quot;{x:Bind ViewModel}&quot;/>
        <CollectionViewSource x:Name=&quot;Divisions&quot;
            Source=&quot;{Binding Divisions, Source={StaticResource Leagues}}&quot;/>
        <CollectionViewSource x:Name=&quot;Teams&quot;
            Source=&quot;{Binding Teams, Source={StaticResource Divisions}}&quot;/>

        <Style TargetType=&quot;TextBlock&quot;>
            <Setter Property=&quot;FontSize&quot; Value=&quot;15&quot;/>
            <Setter Property=&quot;FontWeight&quot; Value=&quot;Bold&quot;/>
        </Style>

        <Style TargetType=&quot;ListBox&quot;>
            <Setter Property=&quot;FontSize&quot; Value=&quot;15&quot;/>
        </Style>

        <Style TargetType=&quot;ContentControl&quot;>
            <Setter Property=&quot;FontSize&quot; Value=&quot;15&quot;/>
        </Style>

    </Page.Resources>

    <Grid Background=&quot;{ThemeResource ApplicationPageBackgroundThemeBrush}&quot;>

        <StackPanel Orientation=&quot;Horizontal&quot;>

            <!-- All Leagues view -->

            <StackPanel Margin=&quot;5&quot;>
                <TextBlock Text=&quot;All Leagues&quot;/>
                <ListBox ItemsSource=&quot;{Binding Source={StaticResource Leagues}}&quot; 
                    DisplayMemberPath=&quot;Name&quot;/>
            </StackPanel>

            <!-- League/Divisions view -->

            <StackPanel Margin=&quot;5&quot;>
                <TextBlock Text=&quot;{Binding Name, Source={StaticResource Leagues}}&quot;/>
                <ListBox ItemsSource=&quot;{Binding Source={StaticResource Divisions}}&quot; 
                    DisplayMemberPath=&quot;Name&quot;/>
            </StackPanel>

            <!-- Division/Teams view -->

            <StackPanel Margin=&quot;5&quot;>
                <TextBlock Text=&quot;{Binding Name, Source={StaticResource Divisions}}&quot;/>
                <ListBox ItemsSource=&quot;{Binding Source={StaticResource Teams}}&quot; 
                    DisplayMemberPath=&quot;Name&quot;/>
            </StackPanel>

            <!-- Team view -->

            <ContentControl Content=&quot;{Binding Source={StaticResource Teams}}&quot;>
                <ContentControl.ContentTemplate>
                    <DataTemplate>
                        <StackPanel Margin=&quot;5&quot;>
                            <TextBlock Text=&quot;{Binding Name}&quot; 
                                FontSize=&quot;15&quot; FontWeight=&quot;Bold&quot;/>
                            <StackPanel Orientation=&quot;Horizontal&quot; Margin=&quot;10,10&quot;>
                                <TextBlock Text=&quot;Wins:&quot; Margin=&quot;0,0,5,0&quot;/>
                                <TextBlock Text=&quot;{Binding Wins}&quot;/>
                            </StackPanel>
                            <StackPanel Orientation=&quot;Horizontal&quot; Margin=&quot;10,0&quot;>
                                <TextBlock Text=&quot;Losses:&quot; Margin=&quot;0,0,5,0&quot;/>
                                <TextBlock Text=&quot;{Binding Losses}&quot;/>
                            </StackPanel>
                        </StackPanel>
                    </DataTemplate>
                </ContentControl.ContentTemplate>
            </ContentControl>

        </StackPanel>

    </Grid>
</Page>
```

[
            **CollectionViewSource**](https://msdn.microsoft.com/library/windows/apps/BR209833) に直接バインドすることによって、コレクション自体ではパスが見つからない、バインディング内の現在の項目にバインドすることを意味します。 バインディングのパスとして **CurrentItem** プロパティを指定する必要はありませんが、あいまいさがある場合は指定することもできます。 たとえば、チーム ビューを表す [**ContentControl**](https://msdn.microsoft.com/library/windows/apps/BR209365) で、[**Content**](https://msdn.microsoft.com/library/windows/apps/BR209365-content) プロパティが `Teams`**CollectionViewSource** にバインドされているとします。 しかし、**CollectionViewSource** が必要に応じてチームの一覧から現在選択されているチームを自動的に示すため、[**DataTemplate**](https://msdn.microsoft.com/library/windows/apps/BR242348) 内のコントロールは `Team` クラスのプロパティにバインドされます。

 

 



<!--HONumber=Mar16_HO1-->


