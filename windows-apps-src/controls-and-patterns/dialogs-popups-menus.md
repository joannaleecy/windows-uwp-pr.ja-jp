---
Description: A flyout is a lightweight popup that is used to temporarily show UI that is related to what the user is currently doing.
title: Context menus and dialogs
ms.assetid: 7CA2600C-A1DB-46AE-8F72-24C25E224417
label: Menus, dialogs, and popups
template: detail.hbs
---
# Menus, dialogs, and popups

Menus, dialogs, and popups display transient UI elements that appear when the user requests them or when something happens that requires notification or approval. 

<span class="sidebar_heading" style="font-weight: bold;">Important APIs</span>

-   [MenuFlyout class](https://msdn.microsoft.com/library/windows/apps/dn299030)
-   [Flyout class](https://msdn.microsoft.com/library/windows/apps/dn279496)

A context menu provides the user with instant actions. It can be filled with custom commands. Context menus can be dismissed by tapping or clicking somewhere outside the menu.

Dialogs are modal UI overlays that provide contextual app information. In most cases, dialogs block interactions with the app window until being explicitly dismissed, and often request some kind of action from the user.

A popup, also known as a flyout, is a lightweight contextual popup that displays UI related to what the user is doing. It includes placement and sizing logic, and can be used to show a menu, reveal a hidden control, show more detail about an item, or ask the user to confirm an action. Popups can be dismissed by tapping or clicking somewhere outside the popup.


## Is this the right control?

Context menus can be used for:

-   Contextual actions on text selections, such as Copy, Cut, Paste, Check Spelling, and so on.
-   Clipboard commands.
-   Custom commands.
-   Commands for an object that must be acted upon but that can't be selected or otherwise indicated.

Dialogs can be used for:

- Expressing important information that the user must read and acknowledge before proceeding.
- Requesting a clear action from the user or communicating an important message that the user should acknowledge. Examples include:
  - When the user's security might be compromised
  - When the user is about to permanently alter a valuable asset
  - When the user is about to delete a valuable asset
  - To confirm an in-app purchase
- Error messages that apply to the overall app context, such as a connectivity error.
- Questions, when the app needs to ask the user a blocking question, such as when the app can't choose on the user's behalf. A blocking question can't be ignored or postponed, and should offer the user well-defined choices.

Popups (flyouts) can be used for:

-   Contextual, transient UI.
-   Warnings and confirmations, including ones related to potentially destructive actions.
-   Displaying more information, such as details about an item on the screen.
-   Second-level menus.
-   Custom commands.


## Examples

Here's a typical single-pane context menu. This would be used for a shorter list of simple commands. Use separators as needed to group similar commands.

![Example of a typical context menu](images/controls_contextmenu_singlepane.png)

A cascading context menu would be used for a more comprehensive collection of commands. It features one flyout level and can scroll. Use separators as needed to group similar commands.

![Example of a cascading context menu](images/controls_contextmenu_cascading.png)

This is an example of a full-screen, single-button confirmation dialog. With this kind of dialog, the user is presented with a fair amount of information that they're expected to read before pressing the button to proceed.

![Example of a full-page, single-button dialog](images/controls_dialog_singlebutton.png)

Here's an example of a two-button dialog that presents the user with an A/B choice. Generally, the amount of information presented in this dialog is brief.

![Example of a full-button dialog](images/controls_dialog_twobutton.png)


## Usage guidance

**Context menus**
- Use a separator between groups of commands in a context menu to:
  - Distinguish groups of related commands.
  - Group together sets of commands.
  - Divide a predictable set of commands, such as clipboard commands (Cut / Copy / Paste), from app-specific or view-specific commands.
-   On laptops and desktops, context menus and tooltips aren't limited to the application window and can paint outside of it. If the app tries to render a context menu completely outside of its window, an exception will be thrown.

**Dialogs**
-   Clearly identify the issue or the user's objective in the first line of the dialog's text.
-   The dialog title is the main instruction and is optional.
    -   Use a short title to explain what people need to do with the dialog. Long titles do not wrap and are truncated.
    -   If you're using the dialog to deliver a simple message, error or question, you can optionally omit the title. Rely on the content text to deliver that core information.
    -   Make sure that the title relates directly to the button choices.
-   The dialog content contains the descriptive text and is required.
    -   Present the message, error, or blocking question as simply as possible.
    -   If a dialog title is used, use the content area to provide more detail or define terminology. Don't repeat the title with slightly different wording.
-   At least one dialog button must appear.
    -   Use buttons with text that identifies specific responses to the main instruction or content. An example is, "Do you want to allow AppName to access your location?", followed by "Allow" and "Block" buttons. Specific responses can be understood more quickly, resulting in efficient decision making.
-   Error dialogs display the error message in the dialog box, along with any pertinent information. The only button used in an error dialog should be “Close” or a similar action.
-   Don't use dialogs for errors that are contextual to a specific place on the page, such as validation errors (in password fields, for example), use the app's canvas itself to show inline errors.

**Popups**

-   As with other contextual UI, place a popup next to the point from which it's called.
    -   Specify the object to which you want the popup anchored, and the side of the object on which the popup will appear.
    -   Try to position the popup so that it doesn’t block important UI.
-   The popup should be dismissed as soon as something in it is selected.
-   Popup menus work best with just one level. Multiple popup menu levels are difficult to navigate and provide a poor user experience.

## Do's and don'ts

-   Keep context menu commands short. Longer commands end up being truncated.
-   Use sentence capitalization for each command name.
-   In any context menu, show the fewest possible number of commands.
-   If direct manipulation of a UI element is possible, avoid placing that command within a context menu. A context menu should be reserved for contextual commands that aren't otherwise discoverable on-screen.



## Related articles

**For developers**
- [**MenuFlyout class**](https://msdn.microsoft.com/library/windows/apps/dn299030)
- [**Flyout class**](https://msdn.microsoft.com/library/windows/apps/dn279496)


<!--HONumber=Mar16_HO4-->


