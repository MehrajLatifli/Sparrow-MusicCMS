   M S B A M L   `   `   `  ???? g  cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137akOclr-namespace:MahApps.Metro.IconPacks;assembly=MahApps.Metro.IconPacks.MaterialMahApps.Metro.IconPacks  I EMusicCMS Admin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:MusicCMS_Admin.Views.UserControls!MusicCMS_Admin.Views.UserControls 1   +MusicCMS_Admin.Views.UserControls.Player_UC   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     `IconOclr-namespace:MahApps.Metro.IconPacks;assembly=MahApps.Metro.IconPacks.Material     @d2http://schemas.microsoft.com/expression/blend/2008     _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  ;local/clr-namespace:MusicCMS_Admin.Views.UserControls  Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  .??? *  $Microsoft.Xaml.Behaviors.Interaction    Triggers  +  %Microsoft.Xaml.Behaviors.EventTrigger     	EventName$ Loaded??*  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     PassEventArgsToCommand$
 True??   Command ?? *LoadedCommand+.+??? $??18q????#03bf69 ?? CornerRadius$ 20??._???  ?? Orientation$ 
Horizontal=?.+?A? $??50??$??50??$??30,0,0,0q????? -   Musicplayerimage???? $??
25,25,5,20q? ? Cursor$
 Hand??   playerButton#??[  ???? *PreviousMusicCommand+.??.   (MahApps.Metro.IconPacks.PackIconMaterial     Kind$ SkipPrevious=?  playerButtonIcon#??[ ?? $??	5,25,0,20q?$
 Hand??#??[  ???? *PlayPauseMusicCommand+.??  -   	  Name$	 PlayPauseKind??$
 Play=?#??[ ?? $??	5,25,0,20q?$
 Hand??#??[  ???? *NextMusicCommand+.??  $ SkipNext=?#??[ ?? $??
20,20,0,20q?.+??? -   
 ??Name$
 	TitleText??$??
0,-10,0,10q? ?? Padding$ 15,5,0,1q?$??14(?$??SemiBold"?
????????? -    ??Name$ 
TimeSlider??$	??450??$??5q?$??Center=?$
 Hand?? ?? IsMoveToPointEnabled$
 True?? ?? IsSelectionRangeEnabled$
 True?? ? LargeChange$
 0.05Q? ? Maximum$	 100Q? ? SmallChange$
 0.01Q?  SliderStyle1#???   ?? TickFrequency$ 0.0000000000000001Q?    $ ValueChanged??.   $
 True?? ?? *PlayerMusicTimelineCommand+?? -   $
 MusicTimeText??$ 15,0,0,1q?$??14(?$??SemiBold"?
????????? $??20,25,20,20q?$
 Hand??#??[  ???? *MuteOrUnMuteVolumeCommand+.??  -   $	 MuteOrUnMuteVolumeKind??$ 
VolumeMute=?#??[ ?? -   $ volueslider??$??0??$	??125??$??	0,25,0,20q?$??Center=?$
 Hand??$
 True??$
 0.05Q?$ 1Q?$
 0.01Q?#???  $ 0.0000000000000001Q? ? Value ?? *VolumeDisplay+    $ ValueChanged??.   $
 True?? ?? *PlayerVolumeCommand+