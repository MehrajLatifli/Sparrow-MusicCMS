   M S B A M L   `   `   `  ????g  cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137akOclr-namespace:MahApps.Metro.IconPacks;assembly=MahApps.Metro.IconPacks.MaterialMahApps.Metro.IconPacks  5      I EMusicCMS Admin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:MusicCMS_Admin.Views.UserControls!MusicCMS_Admin.Views.UserControls 5      1   +MusicCMS_Admin.Views.UserControls.Player_UC   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      `IconOclr-namespace:MahApps.Metro.IconPacks;assembly=MahApps.Metro.IconPacks.Material     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      ;local/clr-namespace:MusicCMS_Admin.Views.UserControls  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5	      .??5      ? *  $Microsoft.Xaml.Behaviors.Interaction    Triggers  5   
   +  %Microsoft.Xaml.Behaviors.EventTrigger  5         	EventName$ Loaded??6   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     PassEventArgsToCommand$
 True??6J      Command 6(   ?? *LoadedCommand+6J   5      .+?5   
   ?? $??18q?5      ???#03bf69 ?? CornerRadius$ 20??5      ._?5      ??  ?? Orientation$ 
Horizontal=?6   .+?5      A? $??50??5      $??50??5      $??30,0,0,0q?5      ??5!      ?? 5"      -   5        Musicplayerimage??5"   %   5%      ?? 5(      $??
25,25,5,20q?5)       ? Cursor$
 Hand??5+         playerButton#??[  5,      ??5*      ?? *PreviousMusicCommand+.??5-      .   (MahApps.Metro.IconPacks.PackIconMaterial     Kind$ SkipPrevious=?6,     playerButtonIcon#??[ 6@   5.      ?? 50      $??	5,25,0,20q?51      $
 Hand??53      #??[  54      ??52      ?? *PlayPauseMusicCommand+.??55        -   5        	  Name$	 PlayPauseKind??56      $
 Play=?57      #??[ 58      59      ?? 5;      $??	5,25,0,20q?5<      $
 Hand??5>      #??[  5?      ??5=      ?? *NextMusicCommand+.??5@        $ SkipNext=?6,   #??[ 6<   5A      ?? 5C      $??
20,20,0,20q?6   .+?5F      ?? -   5        
 ??Name$
 	TitleText??5G      $??
0,-10,0,10q?5H       ?? Padding$ 15,5,0,1q?5I      $??14(?5J      $??SemiBold"?5K      
???????5L      ?? 5N      -   5         ??Name$ 
TimeSlider??5O      $	??450??5P      $??5q?5Q      $??Center=?5R      $
 Hand??5S       ?? IsMoveToPointEnabled$
 True??5T       ?? IsSelectionRangeEnabled$
 True??5U       ? LargeChange$
 0.05Q?5V       ? Maximum$	 100Q?5W       ? SmallChange$
 0.01Q?5X        SliderStyle1#???  5Y       ?? TickFrequency$ 0.0000000000000001Q?5Z        5]        5_      $ ValueChanged??6-   . 5`   "     $
 True??6g    68   ?? *PlayerMusicTimelineCommand+6g   5a      5e      ?? 5g      -   5        $
 MusicTimeText??5h      $ 15,0,0,1q?5i      $??14(?5j      $??SemiBold"?5k      
???????5l      5n      ?? 5p      $??20,25,20,20q?5q      $
 Hand??5s      #??[  5t      ??5r      ?? *MuteOrUnMuteVolumeCommand+.??5u        -   5        $	 MuteOrUnMuteVolumeKind??5v      $ 
VolumeMute=?5w      #??[ 5x      5y      ?? 5|      -   5        $ volueslider??5}      $??0??5~      $	??125??5      $??	0,25,0,20q?5?      $??Center=?5?      $
 Hand??5?      $
 True??5?      $
 0.05Q?5?      $ 1Q?5?      $
 0.01Q?5?      #???  5?      $ 0.0000000000000001Q?5?       ? Value 5?      ?? *VolumeDisplay+  5?        5?      $ ValueChanged??6)   . 5?        $
 True??6\    64   ?? *PlayerVolumeCommand+6\   5?      5?      5?      5?      5?      5?      