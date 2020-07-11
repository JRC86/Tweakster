# Tweakster for Visual Studio

[![Build status](https://ci.appveyor.com/api/projects/status/4pha1svkn0aqg3u4?svg=true)](https://ci.appveyor.com/project/madskristensen/tweakster)

A collection of minor fixes and tweaks for Visual Studio to reduce the paper cuts and make you a happier developer

Download this extension from the [Marketplace](https://marketplace.visualstudio.com/items?itemName=MadsKristensen.KnownMonikersExplorer)
or get the [CI build](https://www.vsixgallery.com/extension/0c8bd9fa-77d5-4563-ab57-9e01608c3d04/).

----------------------------------------------

## Features
The list of features are coming from the [Visual Studio Developer Community](https://developercommunity.visualstudio.com/) where users are posting feature suggestions and problem report tickets. 

It's from those tickets inspiration for this extension came.ss

## Settings
You can enable or disable the various tweaks to your liking.

![Settings](art/settings.png)

### Auto save
From the ticket [Option to Auto Save the editor pages](https://developercommunity.visualstudio.com/idea/371187/option-to-auto-save-the-editor-pages.html).

Automatic saving of documents happen when the document loses focus. That could happen when you open a different document or clicks around in another tool window such as Solution Explorer. It will also save any changes to its containing project.

Projects are automatically saved when items are added, removed or renamed. 

### Don't copy empty lines
From the ticket [Please stop clearing the clipboard when you hit ctrl+c and nothing is selected](https://developercommunity.visualstudio.com/idea/693790/please-stop-clearing-the-clipboard-when-you-hit-ct.html).

When the caret is placed on an empty line and you hit *Copy* or *Ctrl+C* then the empty lines isn't copied to the clipboard like it normally would.

## License
[Apache 2.0](LICENSE)