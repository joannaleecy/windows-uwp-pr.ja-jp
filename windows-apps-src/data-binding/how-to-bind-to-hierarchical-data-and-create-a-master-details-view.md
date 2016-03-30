---
xx.xxxxxxx: YXYYYYYX-YYXY-YYYX-YYYX-YYYXYXYYYYXY
xxxxx: Xxxx xxxxxxxxxxxx xxxx xxx xxxxxx x xxxxxx/xxxxxxx xxxx
xxxxxxxxxxx: Xxx xxx xxxx x xxxxx-xxxxx xxxxxx/xxxxxxx (xxxx xxxxx xx xxxx-xxxxxxx) xxxx xx xxxxxxxxxxxx xxxx xx xxxxxxx xxxxx xxxxxxxx xx XxxxxxxxxxXxxxXxxxxx xxxxxxxxx xxxx xxx xxxxx xxxxxxxx xx x xxxxx.
---
# Xxxx xxxxxxxxxxxx xxxx xxx xxxxxx x xxxxxx/xxxxxxx xxxx

\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


> **Xxxx**  Xxxx xxx xxx [Xxxxxx/xxxxxx xxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619991).

Xxx xxx xxxx x xxxxx-xxxxx xxxxxx/xxxxxxx (xxxx xxxxx xx xxxx-xxxxxxx) xxxx xx xxxxxxxxxxxx xxxx xx xxxxxxx xxxxx xxxxxxxx xx [**XxxxxxxxxxXxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR209833) xxxxxxxxx xxxx xxx xxxxx xxxxxxxx xx x xxxxx. Xx xxxx xxxxx xx xxx xxx [{x:Xxxx} xxxxxx xxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/Mt204783) xxxxx xxxxxxxx, xxx xxx xxxx xxxxxxxx (xxx xxxx xxxxxxxxxx) [{Xxxxxxx} xxxxxx xxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/Mt204782) xxxxx xxxxxxxxx.

Xxx xxxxxx xxxxxxxxx xxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxx xx xx xxxxxxxx xx xxxxxxxxx xxxxxxx xxxxx xxxx x xxxx xxxxx x xxxxxxxxx xx x xxxxxx xxxx. Xxxx xx xxxxxx xxxx xxx xxxx xx xxxxxxx x xxxx xxxxxx xxxxxxxxxxxxxx xx xxxx xxxx xx xxxxx xxxxx xx x xxxxxxxxx. Xxxxxxx xxxxxx xx xx xxxxxxx xxxxxxxx xxxxxx xx xxxx xx x xxxxxx xxxx. Xxxx xx xxxxxx xxxx xxx xxxx xx xxxxxxx x xxx xxxxxx xxxxx xxxx xxx xxx xxxx xxxxxxx xxxxx xxxx xx xx xxxx xx xxxxxxxx. Xxxx xxxxx xxxxxxxxx xxx xx xxxxxxxxx xxxx xxxxxxxxxxx. Xxx [**XxxxxxxxxxXxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR209833) xxxxxxxxx xxxx xxxxx xx xxx xxxxxxx xxxxxxxxx xx xxxx xxxxxxxxxxxx xxxxx.

Xx'xx xxxxxx x xxxx xx x xxxxxx xxxx xxxxxxxxx xxxx xx xxxxxxxxx xxxx xxxxx xxx xxxxxxx, xxxxxxxxx, xxx xxxxx, xxx xxxxxxxx x xxxx xxxxxxx xxxx. Xxxx xxx xxxxxx xx xxxx xxxx xxx xxxx, xxx xxxxxxxxxx xxxxx xxxxxx xxxxxxxxxxxxx.

![xxxxxx/xxxxxxx xxxx xx x xxxxxx xxxxxxxxx](images/xaml-masterdetails.png)

## Xxxxxxxxxxxxx

Xxxx xxxxx xxxxxxx xxxx xxx xxxx xxx xx xxxxxx x xxxxx XXX xxx. Xxx xxxxxxxxxxxx xx xxxxxxxx xxxx xxxxx XXX xxx, xxx [Xxxxxx xxxx xxxxx XXX xxx xxxxx X# xx Xxxxxx Xxxxx](https://msdn.microsoft.com/library/windows/apps/Hh974581).

## Xxxxxx xxx xxxxxxx

Xxxxxx x xxx **Xxxxx Xxxxxxxxxxx (Xxxxxxx Xxxxxxxxx)** xxxxxxx. Xxxx xx "XxxxxxXxxxxxxXxxxxxx".

## Xxxxxx xxx xxxx xxxxx

Xxx x xxx xxxxx xx xxxx xxxxxxx, xxxx xx XxxxXxxxx.xx, xxx xxx xxxx xxxx xx xx. Xxxx xxxx xx xxxx xxxxxxx xxxxxx xxxxx.

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

## Xxxxxx xxx xxxx

Xxxx, xxxxxx xxx xxxxxxx xxxxxx xxxxx xxxx xxx xxxxx xxxx xxxxxxxxxx xxxx xxxx xx xxxxxx. Xx xx xxxx xx xxxxxx x xxxxxxxx xx xxxx **XxxxxxXxxx** xx **XxxxXxxx**.

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

Xxxxxxx, xxxxxxx xxx xxxxxxxx xx xxx XxxxXxxx.xxxx xxxx xxxx xxx xxxxxxxxx xxxxxx, xxxxx xxxxxxxx xxxxx [**XxxxxxxxxxXxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR209833) xxxxxxxxx xxx xxxxx xxxx xxxxxxxx xx x xxxxx. Xxx xxxxxxxxxx xxxxxxxx xxx xxxx xxxx xx xxx xxxxxxxxxxx **XxxxxxxxxxXxxxXxxxxx**, xxxxxxxxx xx xxx xxxxx xx xxx xxxxxxxxx.

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

Xxxx xxxx xx xxxxxxx xxxxxxxx xx xxx [**XxxxxxxxxxXxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR209833), xxx'xx xxxxxxxx xxxx xxx xxxx xx xxxx xx xxx xxxxxxx xxxx xx xxxxxxxx xxxxx xxx xxxx xxxxxx xx xxxxx xx xxx xxxxxxxxxx xxxxxx. Xxxxx'x xx xxxx xx xxxxxxx xxx **XxxxxxxXxxx** xxxxxxxx xx xxx xxxx xxx xxx xxxxxxx, xxxxxxxx xxx xxx xx xxxx xx xxxxx'x xxx xxxxxxxxx). Xxx xxxxxxx, xxx [**XxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR209365) xxxxxxxxxxxx xxx xxxx xxxx xxx xxx [**Xxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR209365-content) xxxxxxxx xxxxx xx xxx `Teams`**XxxxxxxxxxXxxxXxxxxx**. Xxxxxxx, xxx xxxxxxxx xx xxx [**XxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR242348) xxxx xx xxxxxxxxxx xx xxx `Team` xxxxx xxxxxxx xxx **XxxxxxxxxxXxxxXxxxxx** xxxxxxxxxxxxx xxxxxxxx xxx xxxxxxxxx xxxxxxxx xxxx xxxx xxx xxxxx xxxx xxxx xxxxxxxxx.

 

 

<!--HONumber=Mar16_HO1-->
