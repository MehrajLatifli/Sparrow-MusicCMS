   M S B A M L   `   `   `  ????C  ?MusicCMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:MusicCMSMusicCMS  5	      I)clr-namespace:MusicCMS.Views.UserControlsMusicCMS.Views.UserControls  5      9!clr-namespace:MusicCMS.ViewModelsMusicCMS.ViewModels  5      $    MusicCMS.Views.UserPanelWindow   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:Icon-http://metro.mahapps.com/winfx/xaml/iconpacks   5      <d2http://schemas.microsoft.com/expression/blend/2008   5      U QWpfAnimatedGif, Version=2.0.0.0, Culture=neutral, PublicKeyToken=9e7cd3b544a090dc,gif"http://wpfanimatedgif.codeplex.com  5      _	 [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors 	 5      "localclr-namespace:MusicCMS 	 5	      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006 	 5
      b
 ^SharpVectors.Converters.Wpf, Version=1.8.1.0, Culture=neutral, PublicKeyToken=b532964b8548be771svgc&http://sharpvectors.codeplex.com/svgc/ 
 5      2uc)clr-namespace:MusicCMS.Views.UserControls 
 5      1	viewmodel!clr-namespace:MusicCMS.ViewModels 
 5        ? Title$  
User Panel??5      $
??1250??5      $	??900??5       ? AllowsTransparency$
 True??5      
??????  ? 
ResizeMode$ NoResize=?5       ? WindowStartupLocation$ CenterScreen=?5       ? WindowStyle$
 None=?5      .??5      ?? 
???????$	??5pxq?5   	    ?? CornerRadius$ 40??5   	   * 	 $Microsoft.Xaml.Behaviors.Interaction   Triggers 5   
   + 	 %Microsoft.Xaml.Behaviors.EventTrigger  5          	EventName$ 	MouseDown??6   * 	 $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5!      2 	 ,Microsoft.Xaml.Behaviors.InvokeCommandAction  	   PassEventArgsToCommand$
	 True??6W   
   Command
 6(   ?? *UserPanel_MouseDownCommand+6W   5"      ??5%   
   ?? 5'      .??5)      ?  ? Offset$ 0Q?6    ? Color$ #30ad9a??6*   ? 5*      $ 1Q?6   $ #18c274??6*   5,      ._?51   
   ?  ? ColumnDefinitions 53      ?? 55      $	??220 ?6#   ?? 56      $??1* ?6#    ? RowDefinitions 5:      ?? 5<      $??* ?6    ?? 5=      $	??100 ?6    .+?5H      ?? $??2??5I      
???????$ 	40 0 0 40??5K      ._?5M      ?? -   5         ??Name$ ButtonStackPanel??5M      $??0,30,0,0q?67   .+?5Q      ?? $??
63,10,0,10q?5R      $
??Left=?5S       ?? Orientation$ 
Horizontal=?5T      ?? 5V      $
??25px??6   ?? 5X         	menuTitle#??[  6    $??Library??6C   ?? 5Z      -   5         ??Name$ 
HomeButton??5[      ???#02be68
???????  
menuButton#??[ 5_      ??5]      ?? *MenuButtonCommand+.??5b      ? .+?5c      ?? $??0,0,0,2q?6(   $
??Home??69   .  (MahApps.Metro.IconPacks.PackIconMaterial  5d      -   5          Name$ homeicon??5e   !     menuButtonIcon#??[ 5f   !   $y?Visible=?5g   !   5h      5i      ?? 5k      -   5        $ MusicButton??5l      #??[ 5n      ??5m      ?? *MenuButtonCommand+.??5o      ? .+?5p      ?? $??0,0,0,2q?6(   $??Music??69     5q      -   5        $ 	musicicon??5q   4   #??[ 6G   5r      5s      ?? 5u      -   5        $ RadioButton??5v      #??[ 5x      ??5w      ?? *MenuButtonCommand+.??5y      ? .+?5z      ?? $??0,0,0,2q?6(   $??Radio??69     5{      -   5        $ 	radioicon??5{   4   #??[ 6G   5|      5}      ?? 5      -   5        $ PlaylistButton??5?      #??[ 5?      ??5?      ?? *MenuButtonCommand+.??5?      ? .+?5?      ?? $??0,0,0,2q?6(   $??Playlist??69     5?      -	   5        $ playlisticon??5?   4   #??[ 6J   5?      5?      ?? 5?      $	??150??5?      $	??100??5?       J? Opacity$ 1Q?5?      ._?5?      ?? $)??#../Asserts/Images/Images/github.png??6    5?      ?? 5?      $??295px??6   ?? 5?      $	??150??5?      $	??100??5?      $ 20??5?      $ 1Q?5?      ._?5?      ?? ??6    / 
 )SharpVectors.Converters.SvgImageExtension  *0.../Asserts/Images/Logo/Mainlogo/LOGO00a85b.svg+5?      5?      5?      ?? 5?      $??2??5?      $??01??5?      $??	0,60,20,5q?5?      
???????.+?5?      ?  5?      ?? 5?      $	??10* ?6+   ?? 5?      $
??0.5* ?6+   ?? 5?      $
??0.5* ?6+   .+?5?      ?? $??30??5?      $
??Left=?5?      $??Center=?5?      ?? 5?      $??1??5?       ? Cursor$
 Hand??5?        	appButton#??[ 5?      ??5?      ?? *MinimizeAppCommand+.??5?           Kind$ WindowMinimize=?60     appButtonIcon#??[ 6F   5?      ?? 5?      $??2??5?      $
 Hand??5?      #??[ 5?      ??5?      ?? *ExitAppCommand+.??5?        $ WindowClose=?60   #??[ 6C   5?      5?      ? 5?      $??Stretch=?6   $??Stretch=?65    5?      ?? 5?      $??2* ?6(   $	??650??64   ?? 5?      $??1* ?6(   $	??100??64   .+?5     )   #MusicCMS.Views.UserControls.Home_UC  -
   5          Name$ uControl_Home_UC??5     $??0??5     $y?Visible=?5     *   $MusicCMS.Views.UserControls.Music_UC  5     -   5          Name$ uControl_Music_UC??5     $??0??5	     $y?Hidden=?5
     +	   %MusicCMS.Views.UserControls.Player_UC	  5     -   5         	 Name$ uControl_Player_UC??5     $??1??5     $y?Visible=?5     *
   $MusicCMS.Views.UserControls.Radio_UC
  5     -   5         
 Name$ uControl_Radio_UC??5     $??0??5     $y?Hidden=?5     -   'MusicCMS.Views.UserControls.Playlist_UC  5     -   5          Name$ uControl_Playlist_UC??5     $??0??5     $y?Hidden=?5     5     5     5     5!     5$     