   M S B A M L   `   `   `  ???? C  ?MusicCMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:MusicCMSMusicCMS  I)clr-namespace:MusicCMS.Views.UserControlsMusicCMS.Views.UserControls  9!clr-namespace:MusicCMS.ViewModelsMusicCMS.ViewModels  $    MusicCMS.Views.UserPanelWindow   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:Icon-http://metro.mahapps.com/winfx/xaml/iconpacks   <d2http://schemas.microsoft.com/expression/blend/2008   U QWpfAnimatedGif, Version=2.0.0.0, Culture=neutral, PublicKeyToken=9e7cd3b544a090dc,gif"http://wpfanimatedgif.codeplex.com  _	 [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors 	 "localclr-namespace:MusicCMS 	 Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006 	 b
 ^SharpVectors.Converters.Wpf, Version=1.8.1.0, Culture=neutral, PublicKeyToken=b532964b8548be771svgc&http://sharpvectors.codeplex.com/svgc/ 
 2uc)clr-namespace:MusicCMS.Views.UserControls 
 1	viewmodel!clr-namespace:MusicCMS.ViewModels 
   ? Title$  
User Panel??$
??1250??$	??900?? ? AllowsTransparency$
 True??
??????  ? 
ResizeMode$ NoResize=? ? WindowStartupLocation$ CenterScreen=? ? WindowStyle$
 None=?.???? 
???????$	??5pxq? ?? CornerRadius$ 40??* 	 $Microsoft.Xaml.Behaviors.Interaction   Triggers + 	 %Microsoft.Xaml.Behaviors.EventTrigger     	EventName$ 	MouseDown??* 	 $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 2 	 ,Microsoft.Xaml.Behaviors.InvokeCommandAction  	   PassEventArgsToCommand$
	 True??
   Command
 ?? *UserPanel_MouseDownCommand+???? .???  ? Offset$ 0Q? ? Color$ #30ad9a??? $ 1Q?$ #18c274??._??  ? ColumnDefinitions ?? $	??220 ??? $??1* ? ? RowDefinitions ?? $??* ??? $	??100 ?.+??? $??2??
???????$ 	40 0 0 40??._??? -    ??Name$ ButtonStackPanel??$??0,30,0,0q?.+??? $??
63,10,0,10q?$
??Left=? ?? Orientation$ 
Horizontal=??? $
??25px????    	menuTitle#??[  $??Library???? -    ??Name$ 
HomeButton?????#02be68
???????  
menuButton#??[ ???? *MenuButtonCommand+.??? .+??? $??0,0,0,2q?$
??Home??.  (MahApps.Metro.IconPacks.PackIconMaterial  -     Name$ homeicon??  menuButtonIcon#??[ $y?Visible=??? -   $ MusicButton??#??[ ???? *MenuButtonCommand+.??? .+??? $??0,0,0,2q?$??Music??  -   $ 	musicicon??#??[ ?? -   $ RadioButton??#??[ ???? *MenuButtonCommand+.??? .+??? $??0,0,0,2q?$??Radio??  -   $ 	radioicon??#??[ ?? -   $ PlaylistButton??#??[ ???? *MenuButtonCommand+.??? .+??? $??0,0,0,2q?$??Playlist??  -	   $ playlisticon??#??[ ?? $	??150??$	??100?? J? Opacity$ 1Q?._??? $)??#../Asserts/Images/Images/github.png???? $??295px???? $	??150??$	??100??$ 20??$ 1Q?._??? ??/ 
 )SharpVectors.Converters.SvgImageExtension  *0.../Asserts/Images/Logo/Mainlogo/LOGO00a85b.svg+?? $??2??$??01??$??	0,60,20,5q?
???????.+??  ?? $	??10* ??? $
??0.5* ??? $
??0.5* ?.+??? $??30??$
??Left=?$??Center=??? $??1?? ? Cursor$
 Hand??  	appButton#??[ ???? *MinimizeAppCommand+.??     Kind$ WindowMinimize=?  appButtonIcon#??[ ?? $??2??$
 Hand??#??[ ???? *ExitAppCommand+.??  $ WindowClose=?#??[ ? $??Stretch=?$??Stretch=? ?? $??2* ?$	??650???? $??1* ?$	??100??.+?)   #MusicCMS.Views.UserControls.Home_UC  -
     Name$ uControl_Home_UC??$??0??$y?Visible=?*   $MusicCMS.Views.UserControls.Music_UC  -     Name$ uControl_Music_UC??$??0??$y?Hidden=?+	   %MusicCMS.Views.UserControls.Player_UC	  -    	 Name$ uControl_Player_UC??$??1??$y?Visible=?*
   $MusicCMS.Views.UserControls.Radio_UC
  -    
 Name$ uControl_Radio_UC??$??0??$y?Hidden=?-   'MusicCMS.Views.UserControls.Playlist_UC  -     Name$ uControl_Playlist_UC??$??0??$y?Hidden=?