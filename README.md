ScreenShot
=============

Screen printing utility.

**Use**

On launch, sits in the notification area and monitors for a defined key combination (default is `Alt-Win-S`) or (optionally) a right click on the application's icon.

To configure the utility, left click on the icon in the notification area.


**Er, why?**

When working remotely on corporate networks this gets around the problem of taking screenshots and using them on the remote site. This can be a problem where clipboard sharing has been locked down (such as on remote desktop connections), as the screenshots are normally taken and saved into the local clipboard, not the one in the remote session. It can then take couple of emails, possibly from a personal account, to get that screenshot back to be available for use within the remote network.

Instead, using this app, the screenshot is saved to the remote clipboard directly, and can be pasted directly into emails/documents and so on. 



**Requirements**

*Self-build*

The solution is built in VS2013 on .Net 4.5.1. The only NuGet package used is Newtonsoft.Json, therefore it should be easily downgraded to .Net 4 or 4.5.

To redistribute just take the contents of the bin/Release folder and zip/copy to target machine. There should be no other requirement to run, other than the presence of the relevant .Net framework version.


*Download package*

At present I don't have anywhere setup to host a downloadable binary, however I'll work to fix that soon.



