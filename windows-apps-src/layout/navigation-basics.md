---
Description: Navigation in Universal Windows Platform (UWP) apps is based on a flexible model of navigation structures, navigation elements, and system-level features.
title: Navigation design basics for Universal Windows Platform (UWP) apps
ms.assetid: B65D33BA-AAFE-434D-B6D5-1A0C49F59664
label: Navigation design basics
template: detail.hbs
---

#  Navigation design basics for UWP apps


\[ Updated for UWP apps on Windows 10. For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


Navigation in Universal Windows Platform (UWP) apps is based on a flexible model of navigation structures, navigation elements, and system-level features. Together, they enable a variety of intuitive user experiences for moving between apps, pages, and content.

In some cases, you might be able to fit all of your app's content and functionality onto a single page without requiring the user to do anything more than pan to navigate through that content. However, the majority of apps typically have multiple pages of content and functionality with which to explore, engage, and interact. When an app has more than one page, you need to provide the right navigation experience.

To be successful and make sense to users, multi-page navigation experiences in UWP apps include (described in detail later):

-   **The right navigation structure**

    Building a navigation structure that makes sense to the user is crucial to creating an intuitive navigation experience.

-   **Compatible navigation elements** that support the chosen structure.

    Navigation elements can help the user get to the content they want and can also let users know where they are within the app. However, they also take up space that could be used for content or commanding elements, so it's important to use the navigation elements that are right for your app's structure.

-   **Appropriate responses to system-level navigation features (such as Back)**

    To provide a consistent experience that feels intuitive, respond to system-level navigation features in predictable ways.

## <span id="Build_the_right_navigation_structure"></span><span id="build_the_right_navigation_structure"></span><span id="BUILD_THE_RIGHT_NAVIGATION_STRUCTURE"></span>Build the right navigation structure


Let's look at an app as a collection of groups of pages, with each page containing a unique set of content or functionality. For example, a photo app might have a page for taking photos, a page for image editing, and another page for managing your image library. The way you arrange these pages into groups defines the app's navigation structure. There are two common ways to arrange a group of pages:

<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left">In a hierarchy</th>
<th align="left">As peers</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p><img src="images/nav/nav-pages-hiearchy.png" alt="Pages arranged in a hierarchy" /></p></td>
<td align="left"><p><img src="images/nav/nav-pages-peer.png" alt="Pages arranged as peers" /></p></td>
</tr>
<tr class="even">
<td align="left"><p>Pages are organized into a tree-like structure. Each child page has only one parent, but a parent can have one or more child pages. To reach a child page, you travel through the parent.</p></td>
<td align="left"><p>Pages exist side-by-side. You can go from one page to another in any order.</p></td>
</tr>
</tbody>
</table>

 

A typical app will use both arrangements, with some portions being arranged as peers and some portions being arranged into hierarchies.

![an app with a hybrid structure](images/nav/nav-hybridstructure.png.png)

So, when should you arrange pages into hierarchies and when you should arrange them as peers? To answer that question we must consider the number of pages in the group, whether the pages should be traversed in a particular order, and the relationship between the pages. In general, flatter structures are easier to understand and faster to navigate, but sometimes it's appropriate to have a deep hierarchy.

<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<tbody>
<tr class="odd">
<td align="left"><p>We recommend using a hierarchical relationship when</p>
<ul>
<li><p>You expect the user to traverse the pages in a specific order. Arrange the hierarchy to enforce that order.</p></li>
<li><p>There is a clear parent-child relationship between one of the pages and the other pages in the group.</p></li>
<li><p>If there are more than 7 pages in the group.</p>
<p>When there are more than 7 pages in the group, it might be difficult for users to understand how the pages are unique or to understand their current location within the group. If you don't think that's an issue for your app, go ahead and make the pages peers. Otherwise, consider using a hierarchical structure to break the pages into two or more smaller groups. (A hub control can help you group pages into categories.)</p></li>
</ul></td>
<td align="left"><p>We recommend using a peer relationship when</p>
<ul>
<li>The pages can be viewed in any order.</li>
<li>The pages are clearly distinct from each other and don't have an obvious parent/child relationship.</li>
<li><p>There are fewer than 8 pages in the group.</p>
<p>When there are more than 7 pages in the group, it might be difficult for users to understand how the pages are unique or to understand their current location within the group. If you don't think that's an issue for your app, go ahead and make the pages peers. Otherwise, consider using a hierarchical structure to break the pages into two or more smaller groups. (A hub control can help you group pages into categories.)</p></li>
</ul></td>
</tr>
</tbody>
</table>

 

## <span id="Use_the_right_navigation_elements"></span><span id="use_the_right_navigation_elements"></span><span id="USE_THE_RIGHT_NAVIGATION_ELEMENTS"></span>Use the right navigation elements


Navigation elements can provide two services: they help the user get to the content they want, and some elements also let users know where they are within the app. However, they also take up space that the app could use for content or commanding elements, so it's important to use the navigation elements that are just right for your app's structure.

### <span id="Peer-to-peer_navigation_elements"></span><span id="peer-to-peer_navigation_elements"></span><span id="PEER-TO-PEER_NAVIGATION_ELEMENTS"></span>Peer-to-peer navigation elements

Peer-to-peer navigation elements enable navigation between pages in the same level of the same subtree.

![peer to peer navigation](images/nav/nav-lateralmovement.png)

For peer-to-peer navigation, we recommend using tabs or a navigation pane.

<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left">Navigation element</th>
<th align="left">Description</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p>[Tabs and pivot](../controls-and-patterns/tabs-pivot.md)</p>
<p><img src="images/nav/nav-tabs-sm-300.png" alt="Tab-based navigation" /></p></td>
<td align="left">Displays a persistent list of links to pages at the same level.
<p>Use tabs/pivots when:</p>
<ul>
<li><p>There are 2-5 pages.</p>
<p>(You can use tabs/pivots when there are more than 5 pages, but it might be difficult to fit all the tabs/pivots on the screen.)</p></li>
<li>You expect users to switch between pages frequently.</li>
</ul>
<p>This design for a restaurant-finding app uses tabs/pivots:</p>
<p><img src="images/food-truck-finder/uap-foodtruck-tabletphone-sbs-sm-400.png" alt="Example of an app using tabs/pivots pattern" /></p></td>
</tr>
<tr class="even">
<td align="left"><p>[Nav pane](../controls-and-patterns/nav-pane.md)</p>
<p><img src="images/nav/nav-navpane-4page-thumb.png" alt="A navigation pane" /></p></td>
<td align="left">Displays a list of links to top-level pages.
<p>Use a navigation pane when:</p>
<ul>
<li>You don't expect users to switch between pages frequently.</li>
<li>You want to conserve space at the expense of slowing down navigation operations.</li>
<li>The pages exist at the top level.</li>
</ul>
<p>This design for a smart home app features a nav pane:</p>
<p><img src="images/smart-home/uap-smarthome-tabletphone-sbs-sm-400.png" alt="Example of an app that uses a nav pane pattern" /></p>
<p></p></td>
</tr>
</tbody>
</table>

 

If your navigation structure has multiple levels, we recommend that peer-to-peer navigation elements only link to the peers within their current subtree. Consider the following illustration, which shows a navigation structure that has three levels:

![an app with two subtrees](images/nav/nav-subtrees.png)
-   For level 1, the peer-to-peer navigation element should provide access to pages A, B, C, and D.
-   At level 2, the peer-to-peer navigation elements for the A2 pages should only link to the other A2 pages. They should not link to level 2 pages in the C subtree.

![an app with two subtrees](images/nav/nav-subtrees2.png)

### <span id="Hierarchical_navigation_elements"></span><span id="hierarchical_navigation_elements"></span><span id="HIERARCHICAL_NAVIGATION_ELEMENTS"></span>Hierarchical navigation elements

Hierarchical navigation elements provide navigation between a parent page and its child pages.

![hiearchical navigation](images/nav/nav-verticalmovement.png)

<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left">Navigation element</th>
<th align="left">Description</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p>[Hub](../controls-and-patterns/hub.md)</p>
<p><img src="images/higsecone-hub-thumb.png" alt="Hub" /></p></td>
<td align="left">A hub is a special type of navigation control that provides previews/summaries of its child pages. Unlike the navigation pane or tabs, it provides navigation to these child pages through links and section headers embedded in the page itself.
<p>Use a hub when:</p>
<ul>
<li>You expect that users would want to view some of the content of the child pages without having to navigate to each one.</li>
</ul>
<p>Hubs promote discovery and exploration, which makes them well suited for media, news-reader, and shopping apps.</p>
<p></p></td>
</tr>
<tr class="even">
<td align="left"><p>[Master/details](../controls-and-patterns/master-details.md)</p>
<p><img src="images/higsecone-masterdetail-thumb.png" alt="Master/details" /></p></td>
<td align="left">Displays a list (master view) of item summaries. Selecting an item displays its corresponding items page in the details section.
<p>Use the Master/details element when:</p>
<ul>
<li>You expect users to switch between child items frequently.</li>
<li>You want to enable the user to perform high-level operations, such as deleting or sorting, on individual items or groups of items, and also want to enable the user to view or update the details for each item.</li>
</ul>
<p>Master/details elements are well suited for email inboxes, contact lists, and data entry.</p>
<p>This design for a stock-tracking app makes use of a master/details pattern:</p>
<p><img src="images/stock-tracker/uap-finance-tabletphone-sbs-sm.png" alt="Example of a stock trading app that has a master/details pattern" /></p></td>
</tr>
</tbody>
</table>

 

### <span id="Historical_navigation_elements"></span><span id="historical_navigation_elements"></span><span id="HISTORICAL_NAVIGATION_ELEMENTS"></span>Historical navigation elements

<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left">Navigation element</th>
<th align="left">Description</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left">Back</td>
<td align="left"><p>Lets the user traverse the navigation history within an app and, depending on the device, from app to app. For more info, see the [Make your app work well with system-level navigation features](#backnavigation) section that appears later in this article.</p></td>
</tr>
</tbody>
</table>

 

### <span id="Content-embedded_navigation_elements"></span><span id="content-embedded_navigation_elements"></span><span id="CONTENT-EMBEDDED_NAVIGATION_ELEMENTS"></span>Content-embedded navigation elements

<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left">Navigation element</th>
<th align="left">Description</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left">Hyperlinks and buttons</td>
<td align="left"><p>Content-embedded navigation elements appear in a page's content. Unlike other navigation elements, which should be consistent across the page's group or subtree, content-embedded navigation elements are unique from page to page.</p></td>
</tr>
</tbody>
</table>

 

### <span id="Combining_navigation_elements"></span><span id="combining_navigation_elements"></span><span id="COMBINING_NAVIGATION_ELEMENTS"></span>Combining navigation elements

You can combine navigation elements to create a navigation experience that's right for your app. For example, your app might use a nav pane to provide access to top-level pages and tabs to provide access to second-level pages.


\[This article contains information that is specific to UWP apps and Windows 10. For Windows 8.1 guidance, please download the [Windows 8.1 guidelines PDF](https://go.microsoft.com/fwlink/p/?linkid=258743).\]



 






<!--HONumber=Mar16_HO1-->


