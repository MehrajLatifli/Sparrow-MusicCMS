   M S B A M L   `   `   `  ???? g  cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137akOclr-namespace:MahApps.Metro.IconPacks;assembly=MahApps.Metro.IconPacks.MaterialMahApps.Metro.IconPacks  C ?MusicCMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullq=clr-namespace:MusicCMS.Views.Helper_Views.PlaylistMusic_Views/MusicCMS.Views.Helper_Views.PlaylistMusic_Views I   CMusicCMS.Views.Helper_Views.PlaylistMusic_Views.PlaylistMusicWindow   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     `IconOclr-namespace:MahApps.Metro.IconPacks;assembly=MahApps.Metro.IconPacks.Material     @d2http://schemas.microsoft.com/expression/blend/2008     _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  Ilocal=clr-namespace:MusicCMS.Views.Helper_Views.PlaylistMusic_Views  Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006    ? Title$  Playlist??$
??1250??$	??900?? ? AllowsTransparency$
 True??
??????  ? 
ResizeMode$ NoResize=? ? WindowStartupLocation$ CenterScreen=? ? WindowStyle$
 None=?.??? *  $Microsoft.Xaml.Behaviors.Interaction   Triggers +  %Microsoft.Xaml.Behaviors.EventTrigger     	EventName$ Loaded??*  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     PassEventArgsToCommand$
 True??	   Command	 ?? *LoadedCommand+  $ 	MouseDown??.   $
 True??	 ?? *&$PlaylistMusicWindow_MouseDownCommand+
 ? ColumnDefinitions
 ?? $??1* ? ? RowDefinitions ?? $??4* ?.+??? $??0??$??20q? ?? CornerRadius$ 20?????? .???  ? Offset$ 0Q? ? Color$ #30ad9a??? $ 1Q?$ #18c274?? J? Effect 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 20Q?   Opacity$	 0.4Q?   ShadowDepth$ 0Q?   Color$ #1fae7e??._?? .+??? $	??350??$	??250??$??	0,150,0,0q?$ 20?? J? Opacity$
 0.07Q?????  j? 
AlignmentX$ Center=? j? 
AlignmentY$ Center=? ?? ImageSource$6 0../../../Asserts/Images/Logo/Mainlogo/LOGOag.png??? 4  .System.Windows.Automation.AutomationProperties   AutomationId$ Grid1?? ?? $
??auto ??? $
??auto ??? $
??auto ?.+?? $??0??
 ?? $	??10* ??? $??* ?.+??? $??1??$??10q? ? Cursor$
 Hand??   	appButton#??[  ???? *ExitAppCommand+.??.   (MahApps.Metro.IconPacks.PackIconMaterial     Kind$ WindowClose=?  appButtonIcon#??[ ?? -    ??Name$ Searchborder??$??1??$	??420??$??50??$??10,10,10,10q?
?????? 
???????$??5q?$ 20??._??? -    ??Name$" SearchTextboxForMusicListbox??$	??410??$??10,0,0,0q?$??Right=?$??Center=? ?? AcceptsReturn$
 True?? ?? 
AcceptsTab$
 True??$
|?True??$??25(?$
??Bold"? ?? IsUndoEnabled$ False??  ?? 	MaxLength$  15??! ?? MaxLines$! 15??  TextBoxStyle1#???  " ?? TextWrapping$" WrapWithOverflow=?"# ?? VerticalScrollBarVisibility$# Disabled=?.??   $ TextChanged??.   $
 True??	 ?? *MusicSearchCommand+.???? $??2??$	??650??$??20,10,20,30q?$ ScrollViewer??  AppleStyleScrollBarStyle#???  $
??auto=?$y?Visible=?.???? -   $ ??Name$$ MusicListbox??
?????? $??0q?  _ListBoxItemStyle#??[ $??Disabled=?$??Disabled=????? *Musics+???? it??.R?? $??Center=?$??Center=????? .R?? .+??? $ border1??$	??800??$??75??$??0,20,0,0q?  ListboxItemBackRoundColor#??[   ListboxItemBorderColor#??[ $??5q?$ 20??._?? 
 ?? $
??0.5* ??? $??4* ??? $
??0.5* ?.+?A? $??0??$??50??$??50??$??5,0,0,0q????? imagelb?? ?? % ?? Path$% 
ImageMusic?& ?? Mode$& TwoWay=?' ?? UpdateSourceTrigger$' PropertyChanged=??? ( ??Name$( MusicNamelabel??$??1??$	??700??$
??auto??$??6,0,0,16q?$
??Left=?$??Bottom=?$??20(?$
??Bold"?  ListboxItemForeGroundColor#??[ ???? $% 	MusicName?$& TwoWay=?$' PropertyChanged=??? ) ??Name$) AddMusictoPlaylisCommand??$??2??$
??auto??$??5q?$
 Hand??$
{?True??  RegistrationButton#??[    $! PreviewMouseRightButtonDown??.   	 ?? * ?? RelativeSource* ?? + ?? Mode$+ FindAncestor=?, ?? AncestorLevel$, 1??- ?? AncestorTypeI  CMusicCMS.Views.Helper_Views.PlaylistMusic_Views.PlaylistMusicWindow"-  $*% $DataContext.AddMusictoPlaylisCommand?.   CommandParameter. ?? / ?? ElementName$/ MusicListbox??$% SelectedItem?.??? .+?  0  Name$0 AddmusicPlaylistKind??$ PlusBox=? 	 RegistrationButtonIcon#??[	 